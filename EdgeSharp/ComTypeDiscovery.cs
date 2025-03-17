using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Task = Microsoft.Build.Utilities.Task;

namespace EdgeSharp
{
    public class ComTypeDiscovery : Task
    {
        [Required]
        public string ProgId { get; set; }
        
        [Required]
        public string OutputDirectory { get; set; }
        
        [Required]
        public string Namespace { get; set; }
        
        public override bool Execute()
        {
            try
            {
                // Create output directory if it doesn't exist
                Directory.CreateDirectory(OutputDirectory);
                
                Log.LogMessage(MessageImportance.High, $"Generating COM interop for ProgID: {ProgId}");
                
                // Get type from ProgID
                Type comType;
                try
                {
                    comType = Type.GetTypeFromProgID(ProgId, true);
                    if (comType == null)
                    {
                        Log.LogError($"Could not find COM type for ProgID: {ProgId}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogError($"Error getting COM type for ProgID '{ProgId}': {ex.Message}");
                    return false;
                }
                
                // Get COM type information
                string typeName = comType.Name;
                Guid clsid = comType.GUID;
                
                Log.LogMessage(MessageImportance.Normal, $"Found COM type: {typeName} ({clsid})");
                
                // Create instance to get type information through reflection
                object comObject;
                try
                {
                    comObject = Activator.CreateInstance(comType);
                }
                catch (Exception ex)
                {
                    Log.LogError($"Error creating instance of COM type '{typeName}': {ex.Message}");
                    return false;
                }
                
                try
                {
                    // Generate source files
                    HashSet<string> processedInterfaces = new HashSet<string>();
                    GenerateComInterfaces(comObject, OutputDirectory, Namespace, processedInterfaces);
                }
                finally
                {
                    // Release COM object
                    if (comObject != null)
                    {
                        try { Marshal.ReleaseComObject(comObject); } catch { /* ignore */ }
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError($"Error generating COM interop: {ex.Message}");
                Log.LogErrorFromException(ex, true);
                return false;
            }
        }
        
        private void GenerateComInterfaces(object comObject, string outputDir, string ns, HashSet<string> processedInterfaces)
        {
            // Get the COM object's type information
            Type comObjectType = comObject.GetType();
            
            // Get interfaces that this COM object implements
            Type[] interfaces = comObjectType.GetInterfaces();
            foreach (Type interfaceType in interfaces)
            {
                // Only process COM interfaces (that have GUIDs)
                GuidAttribute guidAttr = (GuidAttribute)Attribute.GetCustomAttribute(interfaceType, typeof(GuidAttribute));
                if (guidAttr != null)
                {
                    string interfaceName = interfaceType.Name;
                    
                    // Skip if already processed
                    if (processedInterfaces.Contains(interfaceName))
                        continue;
                    
                    processedInterfaces.Add(interfaceName);
                    Log.LogMessage(MessageImportance.Normal, $"Generating interface: {interfaceName}");
                    
                    // Generate source code for this interface
                    GenerateInterfaceSource(interfaceType, guidAttr.Value, outputDir, ns);
                    
                    // Generate parent interfaces if any
                    foreach (Type parentType in interfaceType.GetInterfaces())
                    {
                        GuidAttribute parentGuidAttr = (GuidAttribute)Attribute.GetCustomAttribute(parentType, typeof(GuidAttribute));
                        if (parentGuidAttr != null && !processedInterfaces.Contains(parentType.Name))
                        {
                            processedInterfaces.Add(parentType.Name);
                            GenerateInterfaceSource(parentType, parentGuidAttr.Value, outputDir, ns);
                        }
                    }
                }
            }
            
            // Try to access additional interfaces through dispatch interface
            try
            {
                // Try to get properties of the object that might return other COM objects
                foreach (PropertyInfo prop in comObjectType.GetProperties())
                {
                    try
                    {
                        // Skip indexed properties
                        if (prop.GetIndexParameters().Length > 0)
                            continue;
                            
                        // Try to get the property value
                        object propValue = prop.GetValue(comObject);
                        if (propValue != null && propValue is not string && propValue is not ValueType)
                        {
                            // Check if it's a COM object
                            if (Marshal.IsComObject(propValue))
                            {
                                try
                                {
                                    // Process this COM object
                                    GenerateComInterfaces(propValue, outputDir, ns, processedInterfaces);
                                }
                                finally
                                {
                                    // Release the COM object
                                    Marshal.ReleaseComObject(propValue);
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Ignore errors accessing properties
                    }
                }
            }
            catch
            {
                // Ignore errors accessing dispatch interface
            }
        }
        
        private void GenerateInterfaceSource(Type interfaceType, string guid, string outputDir, string ns)
        {
            StringBuilder sb = new StringBuilder();
            
            // Add file header
            sb.AppendLine("// Auto-generated COM interface");
            sb.AppendLine("// Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine();
            
            // Add using statements
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Runtime.InteropServices;");
            sb.AppendLine("using System.Runtime.InteropServices.Marshalling;");
            sb.AppendLine();
            
            // Add namespace
            sb.AppendLine($"namespace {ns}");
            sb.AppendLine("{");
            
            // Add interface definition with attributes
            sb.AppendLine("    [GeneratedComInterface]");
            sb.AppendLine($"    [Guid(\"{guid}\")]");
            sb.AppendLine($"    public partial interface {interfaceType.Name}");
            
            // Add parent interfaces
            var parentInterfaces = interfaceType.GetInterfaces();
            if (parentInterfaces.Length > 0)
            {
                sb.Append("        : ");
                for (int i = 0; i < parentInterfaces.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    sb.Append(parentInterfaces[i].Name);
                }
                sb.AppendLine();
            }
            
            sb.AppendLine("    {");
            
            // Add methods
            foreach (MethodInfo method in interfaceType.GetMethods())
            {
                // Skip methods from parent interfaces
                bool isInherited = false;
                foreach (var parentInterface in parentInterfaces)
                {
                    if (parentInterface.GetMethods().Any(m => m.Name == method.Name))
                    {
                        isInherited = true;
                        break;
                    }
                }
                
                if (isInherited)
                    continue;
                
                // Get return type
                string returnTypeName = GetTypeName(method.ReturnType);
                
                // Build parameter list
                StringBuilder paramsSb = new StringBuilder();
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterInfo param = parameters[i];
                    string paramType = GetTypeName(param.ParameterType);
                    
                    // Handle ref, out, and array parameters
                    if (param.IsOut && param.ParameterType.IsByRef)
                    {
                        paramType = "out " + paramType.Replace("&", "");
                    }
                    else if (param.ParameterType.IsByRef)
                    {
                        paramType = "ref " + paramType.Replace("&", "");
                    }
                    
                    paramsSb.Append(paramType);
                    paramsSb.Append(" ");
                    paramsSb.Append(param.Name);
                    
                    if (i < parameters.Length - 1)
                    {
                        paramsSb.Append(", ");
                    }
                }
                
                // Add method signature
                sb.AppendLine($"        {returnTypeName} {method.Name}({paramsSb});");
            }
            
            // Properties
            foreach (PropertyInfo prop in interfaceType.GetProperties())
            {
                // Skip properties from parent interfaces
                bool isInherited = false;
                foreach (var parentInterface in parentInterfaces)
                {
                    if (parentInterface.GetProperties().Any(p => p.Name == prop.Name))
                    {
                        isInherited = true;
                        break;
                    }
                }
                
                if (isInherited)
                    continue;
                
                string propType = GetTypeName(prop.PropertyType);
                
                sb.Append($"        {propType} {prop.Name} {{ ");
                
                if (prop.CanRead)
                    sb.Append("get; ");
                
                if (prop.CanWrite)
                    sb.Append("set; ");
                
                sb.AppendLine("}");
            }
            
            // Close interface and namespace
            sb.AppendLine("    }");
            sb.AppendLine("}");
            
            // Write to file
            string filePath = Path.Combine(outputDir, $"{interfaceType.Name}.cs");
            File.WriteAllText(filePath, sb.ToString());
        }
        
        private string GetTypeName(Type type)
        {
            // Handle array types
            if (type.IsArray)
            {
                return GetTypeName(type.GetElementType()) + "[]";
            }
            
            // Handle by-ref types
            if (type.IsByRef)
            {
                return GetTypeName(type.GetElementType()) + "&";
            }
            
            // Handle pointer types
            if (type.IsPointer)
            {
                return GetTypeName(type.GetElementType()) + "*";
            }
            
            // Handle generic types
            if (type.IsGenericType)
            {
                Type genericTypeDef = type.GetGenericTypeDefinition();
                Type[] genericArgs = type.GetGenericArguments();
                
                string baseName = genericTypeDef.Name;
                int backtickIndex = baseName.IndexOf('`');
                if (backtickIndex > 0)
                {
                    baseName = baseName.Substring(0, backtickIndex);
                }
                
                StringBuilder sb = new StringBuilder(baseName);
                sb.Append("<");
                
                for (int i = 0; i < genericArgs.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append(GetTypeName(genericArgs[i]));
                }
                
                sb.Append(">");
                return sb.ToString();
            }
            
            // Handle COM types
            if (type.IsCOMObject)
            {
                // Try to get a more specific interface if available
                GuidAttribute guidAttr = (GuidAttribute)Attribute.GetCustomAttribute(type, typeof(GuidAttribute));
                if (guidAttr != null)
                {
                    return type.Name;
                }
                
                return "object"; // fallback
            }
            
            // Handle primitive types
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return "bool";
                case TypeCode.Byte: return "byte";
                case TypeCode.Char: return "char";
                case TypeCode.Decimal: return "decimal";
                case TypeCode.Double: return "double";
                case TypeCode.Int16: return "short";
                case TypeCode.Int32: return "int";
                case TypeCode.Int64: return "long";
                case TypeCode.SByte: return "sbyte";
                case TypeCode.Single: return "float";
                case TypeCode.String: return "string";
                case TypeCode.UInt16: return "ushort";
                case TypeCode.UInt32: return "uint";
                case TypeCode.UInt64: return "ulong";
                default: 
                    // Check if it's a COM interface with a guid
                    GuidAttribute attr = (GuidAttribute)Attribute.GetCustomAttribute(type, typeof(GuidAttribute));
                    if (attr != null)
                    {
                        // Use just the name for COM interfaces
                        return type.Name;
                    }
                    
                    // Use full name for everything else
                    return type.FullName ?? type.Name;
            }
        }
    }
}
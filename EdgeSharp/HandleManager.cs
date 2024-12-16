using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace EdgeSharp
{
    public class HandleManager : IDisposable
    {
        private readonly IntPtr _processHandle;
        private const int ProcessHandleInformation = 51;
        private const int STATUS_INFO_LENGTH_MISMATCH = unchecked((int)0xC0000004L);
        private const int ObjectTypeInformation = 2;
        private const int DUPLICATE_SAME_ACCESS = 2;
        private const int DUPLICATE_CLOSE_SOURCE = 1;
        private const int STILL_ACTIVE = 259;

        private const uint PROCESS_ACCESS_FLAGS = 0x0400 | 0x0040; // Combining PROCESS_QUERY_INFORMATION and PROCESS_DUP_HANDLE

        public HandleManager(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                throw new ArgumentException($"No process with name {processName} is running.");
            }
            _processHandle = OpenProcess(PROCESS_ACCESS_FLAGS, false, processes[0].Id);

            if (_processHandle == IntPtr.Zero)
            {
                throw new Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());
            }
        }

        [SupportedOSPlatform("windows")]
        public void HandleZombieThreads()
        {
            IntPtr handleInfoPtr = IntPtr.Zero;
            int handleInfoSize = 0x10000;
            int returnLength = 0;

            try
            {
                handleInfoPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(handleInfoSize);
                while (true)
                {
                    int ntstatus = NtQueryInformationProcess(_processHandle, ProcessHandleInformation, handleInfoPtr, handleInfoSize, ref returnLength);
                    if (ntstatus == STATUS_INFO_LENGTH_MISMATCH)
                    {
                        handleInfoSize = returnLength;
                        System.Runtime.InteropServices.Marshal.FreeHGlobal(handleInfoPtr);
                        handleInfoPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(handleInfoSize);
                    }
                    else if (ntstatus >= 0)
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to query process handle information.");
                    }
                }

                var handleInfo = System.Runtime.InteropServices.Marshal.PtrToStructure<PROCESS_HANDLE_SNAPSHOT_INFORMATION>(handleInfoPtr);
                int handleCount = (int) handleInfo.NumberOfHandles;
                IntPtr handleArrayPtr = IntPtr.Add(handleInfoPtr, System.Runtime.InteropServices.Marshal.OffsetOf<PROCESS_HANDLE_SNAPSHOT_INFORMATION>("Handles").ToInt32());

                int handleEntrySize = System.Runtime.InteropServices.Marshal.SizeOf<PROCESS_HANDLE_TABLE_ENTRY_INFO>();

                // Process each handle entry in the array
                for (int i = 0; i < handleCount; i++)
                {
                    IntPtr currentHandlePtr = IntPtr.Add(handleArrayPtr, i * handleEntrySize);
                    var handleEntry = System.Runtime.InteropServices.Marshal.PtrToStructure<PROCESS_HANDLE_TABLE_ENTRY_INFO>(currentHandlePtr);

                    var handleType = GetHandleType(handleEntry.HandleValue);
                    if (handleType == "Thread")
                    {
                        Console.WriteLine("Found thread handle");
                        if (IsZombieThread(handleEntry.HandleValue))
                        {
                            Console.WriteLine("Thread is zombie");
                            if (!DuplicateHandle(_processHandle, handleEntry.HandleValue, IntPtr.Zero, out IntPtr dupHandle, 0, false, DUPLICATE_CLOSE_SOURCE))
                            {
                                int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                                throw new InvalidOperationException($"Failed to duplicate handle during closing. Error Code: {errorCode}");
                            }
                        }
                    }
                }
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(handleInfoPtr);
                GC.KeepAlive(_processHandle);
            }
        }

        public void Dispose()
        {
            if (_processHandle != IntPtr.Zero)
            {
                CloseHandle(_processHandle);
            }
        }

        private bool IsZombieThread(IntPtr handle)
        {
            uint pid = GetProcessIdOfThread(handle);
            if (pid == 0)
            {
                int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                string errorMessage = new Win32Exception(errorCode).Message;
                throw new InvalidOperationException($"Failed to get PID of thread handle to check exit status. Error Code: {errorCode}, Message: {errorMessage}");
            }
            Process threadProcess = Process.GetProcessById((int)pid);
            bool isZombie = threadProcess.ExitCode != STILL_ACTIVE;
            GC.KeepAlive(handle);
            return isZombie;
        }

        private string? GetHandleType(IntPtr handle)
        {
            int returnLength = 0;
            IntPtr objectTypePtr = IntPtr.Zero;
            IntPtr dupHandle = IntPtr.Zero;
            try
            {
                if (DuplicateHandle(_processHandle, handle, Process.GetCurrentProcess().Handle, out dupHandle, 0, false, DUPLICATE_SAME_ACCESS))
                {
                    NtQueryObject(dupHandle, ObjectTypeInformation, IntPtr.Zero, 0, ref returnLength);
                    objectTypePtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(returnLength);
                    try
                    {
                        if (NtQueryObject(dupHandle, ObjectTypeInformation, objectTypePtr, returnLength, ref returnLength) >= 0)
                        {
                            var objectTypeInfo = System.Runtime.InteropServices.Marshal.PtrToStructure<OBJECT_TYPE_INFORMATION>(objectTypePtr);
                            var handleType = System.Runtime.InteropServices.Marshal.PtrToStringUni(objectTypeInfo.Name.Buffer, objectTypeInfo.Name.Length / 2);
                            Console.WriteLine(handleType);
                            return handleType;
                        }
                        else
                        {
                            int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                            string errorMessage = new Win32Exception(errorCode).Message;
                            throw new InvalidOperationException($"Failed to query object type information. Error Code: {errorCode}, Message: {errorMessage}");
                        }
                    }
                    finally
                    {
                        System.Runtime.InteropServices.Marshal.FreeHGlobal(objectTypePtr);
                        CloseHandle(dupHandle);
                    }
                }
                else
                {
                    int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    string errorMessage = new Win32Exception(errorCode).Message;
                    throw new InvalidOperationException($"Failed to duplicate handle. Error Code: {errorCode}, Message: {errorMessage}");
                }
            }
            finally
            {
                GC.KeepAlive(handle);
                GC.KeepAlive(_processHandle);
                GC.KeepAlive(dupHandle);
                if (objectTypePtr != IntPtr.Zero)
                {
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(objectTypePtr);
                }
            }
        }

        // P/Invoke declarations
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, IntPtr processInformation, int processInformationLength, ref int returnLength);

        [DllImport("ntdll.dll")]
        private static extern int NtQueryObject(IntPtr handle, int objectInformationClass, IntPtr objectInformation, int objectInformationLength, ref int returnLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle, uint dwDesiredAccess, bool bInheritHandle, uint dwOptions);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetProcessIdOfThread(IntPtr threadHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_HANDLE_TABLE_ENTRY_INFO
        {
            public IntPtr HandleValue;
            public ulong HandleCount;
            public ulong PointerCount;
            public uint GrantedAccess;
            public uint ObjectTypeIndex;
            public uint HandleAttributes;
            public uint Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_HANDLE_SNAPSHOT_INFORMATION
        {
            public ulong NumberOfHandles;
            public ulong Reserved;
            public PROCESS_HANDLE_TABLE_ENTRY_INFO Handles; // Starting point for handle array
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct UNICODE_STRING
        {
            public ushort Length;
            public ushort MaximumLength;
            public IntPtr Buffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct OBJECT_TYPE_INFORMATION
        {
            public UNICODE_STRING Name;
            public uint TotalNumberOfHandles;
            public uint TotalNumberOfObjects;
        }
    }
}
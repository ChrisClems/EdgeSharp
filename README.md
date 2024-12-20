# EdgeSharp

EdgeSharp is a .NET library for interacting with Solid Edge. It is the spiritual successor to [SolidEdge.Community](https://github.com/SolidEdgeCommunity/SolidEdge.Community), built on modern versions of .NET.
## EdgeSharp is very much in an experimental and developmental stage. APIs will occassionally change and you may find edge use cases where things break for you where they worked for me. Feel free to submit issues with any questions.

As development progresses, features will be added as helper utilities, extension methods, and adapter interfaces based on patterns in my own workflow where I've benefitted from creating boilerplate snippets that I've reused in multiple projects. Old SolidEdge.Community extensions can be easily implemented. Feel free to open an issue with a link to the original code.

Initial COM code updated for .NET 6 was obtained from @DerekGooding.

## Examples

AppHelper utility class provides easy management of your application instance:

```C#
using EdgeSharp;

// Connect to a running Solid Edge application if found, if not launch one.
var app = AppHelper.Connect();

// Connect to a running Solid Edge application if found, if not return null.
var app = AppHelper.Connect(startIfNotRunning:false);

// Kill all Solid Edge processes running under the current Windows user.
var app.KillAllSolidEdgeProcs();
```

Application extension methods provide dead simple management of your application background state:

```C#
// Sets Application.Visible and DisplayAlerts to false, and DelayCompute to true
// (All background options have been flipped so that false will always be the "default" value in a visible application instance)
var backgroundOptions = (BackgroundOptions.Invisibile | BackgroundOptions.HideAlerts | BackgroundOptions.DelayCompute);
app.SetBackgroundOptions(backgroundOptions);
```

```C#
// Set and store background options using a simple bitmask.
var originalBackgroundState = app.GetBackgroundOptionsMask(); // returns a bitmask int representing the background options set
// Perform actions here in desired background state...
app.SetBackgroundOptionsMask(originalBackgroundState); // Resets all background options to the original state
```

Inline DoIdle() extension for passing lambdas for more concise use of DoIdle calls:

```C#
app.DoIdle((doc) => doc.Save())
```

Traverse all occurrences in an assmelby, performing a passed delegate on each occurrence as a SolidEdgeDocument:

```C#
void PrintOccurrenceName(IOccurrenceEsx occurrence)
{
    Console.WriteLine(occurrence.Name);
}
// Traverses every occurnece in an assembly recurisvely, running PrintDocumentName() to write the doc name to the console.
// More advanced functions can be done by document type detection and casting. More helpers to come.
assemblyDoc.TraverseOccurrencesWithAction(PrintOccurrenceName, recursive:true);
```

The IOcurrenceEsx interface in the above example is an adapter interface for Occurrence and SubOcurrence types so that one may iterate over occurrences within an assembly and access common methods between them without creating two separate code paths.

```C#
IOccurrenceEsx occurrenceAdapter = new OccurrenceAdapter(occurrence)
IOccurrenceEsx subOccurrenceAdapter = new SubOccurrenceAdapter(subOccurrence);
```

The same can be done with PartDocument and SheetMetalDocument types.

```C#
IPartDocumentEsx partDocumentAdapter = new PartDocumentAdapter(part)
IPartDocumentEsx sheetMetalDocumentAdapter = new SheetMetalDocumentAdapter(sheetMetalPart);
```

Open document without opening a window for it in the Solid Edge client, regardless of visiblity settings:

```C#
// Open file using the DocRelationAutoServer parameter to improve performance.
var backgroundDoc = app.Documents.OpenInBackground("path/to/file.par");
```

Return the full property set of a Solid Edge Document to a nested dictionary for easy parsing:

```C#
var propertySetDict = backgroundDoc.PropertySetsToDictionary();
```

See issues for feature roadmap.

## Build:

Build [Interop.SolidEdge](https://github.com/ChrisClems/Interop.SolidEdge) (That README update is an old placeholder, ignore it) using a machine with Solid Edge installed. Reference the Interop.SolidEdge.dll produced by that project in your EdgeSharp project. That should satisfy the dependencies of EdgeSharp.

Future versions aim to better integrate the interop library into the EdgeSharp build process.

# EdgeSharp

EdgeSharp is a .NET library for interacting with Solid Edge. It is the spiritual successor to [SolidEdge.Community](https://github.com/SolidEdgeCommunity/SolidEdge.Community), built on modern versions of .NET.
## EdgeSharp is in a very much experimental stage. Do not build apps on this library expecting API stability.

An initial set of helpers and extensions is being added from my personal library of mixed Solid Edge interop apps.

SolidEdge.Community extensions will be slowly ported as they're vetted for need in modern versions of Solid Edge.

Helpful use cases:

AppHelper class provides easy management of launching, connecting to, and stopping Solid Edge instances.

Application extensions provide functions for managing background app settings including setting and getting bitmasks for easy management of application background state.

Document extensions provide features like passing anonymous functions to an assembly traversing delegate to perform actions on all parts in an assembly.

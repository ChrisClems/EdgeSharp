﻿using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace EdgeSharp;

enum SERVERCALL
{
    SERVERCALL_ISHANDLED = 0,
    SERVERCALL_REJECTED = 1,
    SERVERCALL_RETRYLATER = 2
}

enum PENDINGMSG
{
    PENDINGMSG_CANCELCALL = 0,
    PENDINGMSG_WAITNOPROCESS = 1,
    PENDINGMSG_WAITDEFPROCESS = 2
}

[GeneratedComInterface]
[Guid("00000016-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
partial interface IMessageFilter
{
    [PreserveSig]
    int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);

    [PreserveSig]
    int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);

    [PreserveSig]
    int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);
}

/// <summary>
/// Class that implements the OLE IMessageFilter interface.
/// </summary>
[GeneratedComClass]
internal partial class OleMessageFilter : IMessageFilter
{
    [LibraryImport("Ole32.dll")]
    private static partial int CoRegisterMessageFilter(IMessageFilter newFilter, out IMessageFilter oldFilter);

    /// <summary>
    /// Private constructor.
    /// </summary>
    /// <remarks>
    /// Instance of this class is only created by Register().
    /// </remarks>
    private OleMessageFilter()
    {
    }

    /// <summary>
    /// Destructor.
    /// </summary>
    ~OleMessageFilter()
    {
        // Call Unregister() for good measure. It's fine if this gets called twice.
        Unregister();
    }

    /// <summary>
    /// Registers this instance of IMessageFilter with OLE to handle concurrency issues on the current thread. 
    /// </summary>
    /// <remarks>
    /// Only one message filter can be registered for each thread.
    /// Threads in multithreaded apartments cannot have message filters.
    /// Thread.CurrentThread.GetApartmentState() must equal ApartmentState.STA. In console applications, this can
    /// be achieved by applying the STAThreadAttribute to the Main() method. In WinForm applications, it is default.
    /// </remarks>
    private static void Register()
    {
        IMessageFilter newFilter = new OleMessageFilter();
        IMessageFilter oldFilter = null;

        // 1st check the current thread's apartment state. It must be STA!
        if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
        {
            // Call CoRegisterMessageFilter().
            System.Runtime.InteropServices.Marshal.ThrowExceptionForHR(
                CoRegisterMessageFilter(newFilter: newFilter, oldFilter: out oldFilter));
        }
        else
        {
            throw new System.Exception("The current thread's apartment state must be STA.");
        }
    }

    /// <summary>
    /// Unregisters a previous instance of IMessageFilter with OLE on the current thread. 
    /// </summary>
    /// <remarks>
    /// It is not necessary to call Unregister() unless you need to explicitly do so as it is handled
    /// in the destructor.
    /// </remarks>
    private static void Unregister()
    {
        IMessageFilter oldFilter = null;

        // Call CoRegisterMessageFilter().
        CoRegisterMessageFilter(newFilter: null, oldFilter: out oldFilter);
    }

    public int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
    {
        return (int)SERVERCALL.SERVERCALL_ISHANDLED;
    }

    public int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
    {
        // Cancel the outgoing call. This should be returned only under extreme conditions. Canceling a call that
        // has not replied or been rejected can create orphan transactions and lose resources. COM fails the original
        // call and returns RPC_E_CALL_CANCELLED.
        //return (int)NativeMethods.PENDINGMSG.PENDINGMSG_CANCELCALL;

        // Continue waiting for the reply, and do not dispatch the message unless it is a task-switching or
        // window-activation message. A subsequent message will trigger another call to MessagePending.
        //return (int)NativeMethods.PENDINGMSG.PENDINGMSG_WAITNOPROCESS;

        // Keyboard and mouse messages are no longer dispatched. However there are some cases where mouse and
        // keyboard messages could cause the system to deadlock, and in these cases, mouse and keyboard messages
        // are discarded. WM_PAINT messages are dispatched. Task-switching and activation messages are handled as before.
        return (int)PENDINGMSG.PENDINGMSG_WAITDEFPROCESS;
    }

    public int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
    {
        if (dwRejectType == (int)SERVERCALL.SERVERCALL_RETRYLATER)
        {
            // 0 ≤ value < 100
            // The call is to be retried immediately.
            return 99;

            // 100 ≤ value
            // COM will wait for this many milliseconds and then retry the call.
            // return 1000; // Wait 1 second before retrying the call.
        }

        // The call should be canceled. COM then returns RPC_E_CALL_REJECTED from the original method call.
        return -1;
    }
}
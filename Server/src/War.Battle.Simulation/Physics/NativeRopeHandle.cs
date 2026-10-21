using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace War.BattleServer;

/// <summary>Owns one native registry identity and releases its scene, joints and bodies together.</summary>
internal sealed class NativeRopeHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    internal NativeRopeHandle(IntPtr identity) : base(true)
    {
        SetHandle(identity);
    }

    protected override bool ReleaseHandle()
    {
        return NativeRopeMethods.Destroy(handle) == 0;
    }
}

/// <summary>Explicit C ABI; no native library loads until the adapter is deliberately constructed.</summary>
internal static class NativeRopeMethods
{
    private const string LibraryName = "WarRopePhysics";

    [DllImport(LibraryName, EntryPoint = "war_rope_abi_version", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int GetAbiVersion();

    [DllImport(LibraryName, EntryPoint = "war_rope_create", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int Create([In] float[] values, int length, int bodyCount, out IntPtr handle);

    [DllImport(LibraryName, EntryPoint = "war_rope_step", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int Step(NativeRopeHandle handle, float deltaTime);

    [DllImport(LibraryName, EntryPoint = "war_rope_set_aircraft_transform",
        CallingConvention = CallingConvention.Cdecl)]
    internal static extern int SetAircraftTransform(NativeRopeHandle handle, [In] float[] values, int length);

    [DllImport(LibraryName, EntryPoint = "war_rope_extend", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int Extend(NativeRopeHandle handle, [In] float[] values, int length, int expectedBodyCount);

    [DllImport(LibraryName, EntryPoint = "war_rope_snapshot", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int Snapshot(NativeRopeHandle handle, [Out] float[] values, int length);

    [DllImport(LibraryName, EntryPoint = "war_rope_destroy", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int Destroy(IntPtr handle);
}

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.VR;

/// <summary>
///   <para>Contains all functionality related to a VR device.</para>
/// </summary>
public sealed class VRDevice
{
	/// <summary>
	///   <para>Successfully detected a VR device in working order.</para>
	/// </summary>
	public static extern bool isPresent
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The name of the family of the loaded VR device.</para>
	/// </summary>
	public static extern string family
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Specific model of loaded VR device.</para>
	/// </summary>
	public static extern string model
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Native pointer to the VR device structure, if available.</para>
	/// </summary>
	/// <returns>
	///   <para>Native pointer to VR device if available, else 0.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern IntPtr GetNativePtr();
}

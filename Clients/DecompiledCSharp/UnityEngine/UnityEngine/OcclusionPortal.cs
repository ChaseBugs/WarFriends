using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>The portal for dynamically changing occlusion at runtime.</para>
/// </summary>
public sealed class OcclusionPortal : Component
{
	/// <summary>
	///   <para>Gets / sets the portal's open state.</para>
	/// </summary>
	public extern bool open
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}
}

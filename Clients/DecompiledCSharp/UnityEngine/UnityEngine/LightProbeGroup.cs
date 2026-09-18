using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Light Probe Group.</para>
/// </summary>
public sealed class LightProbeGroup : Component
{
	/// <summary>
	///   <para>Editor only function to access and modify probe positions.</para>
	/// </summary>
	public extern Vector3[] probePositions
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}
}

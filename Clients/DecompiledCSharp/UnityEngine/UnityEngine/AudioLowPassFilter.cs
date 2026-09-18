using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>The Audio Low Pass Filter filter passes low frequencies of an.</para>
/// </summary>
public sealed class AudioLowPassFilter : Behaviour
{
	/// <summary>
	///   <para>Lowpass cutoff frequency in hz. 10.0 to 22000.0. Default = 5000.0.</para>
	/// </summary>
	public extern float cutoffFrequency
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns or sets the current custom frequency cutoff curve.</para>
	/// </summary>
	public extern AnimationCurve customCutoffCurve
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Determines how much the filter's self-resonance is dampened.</para>
	/// </summary>
	public extern float lowpassResonanceQ
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}
}

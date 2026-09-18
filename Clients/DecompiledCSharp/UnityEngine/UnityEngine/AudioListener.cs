using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Representation of a listener in 3D space.</para>
/// </summary>
public sealed class AudioListener : Behaviour
{
	/// <summary>
	///   <para>Controls the game sound volume (0.0 to 1.0).</para>
	/// </summary>
	public static extern float volume
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The paused state of the audio system.</para>
	/// </summary>
	public static extern bool pause
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>This lets you set whether the Audio Listener should be updated in the fixed or dynamic update.</para>
	/// </summary>
	public extern AudioVelocityUpdateMode velocityUpdateMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void GetOutputDataHelper(float[] samples, int channel);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void GetSpectrumDataHelper(float[] samples, int channel, FFTWindow window);

	/// <summary>
	///   <para>Returns a block of the listener (master)'s output data.</para>
	/// </summary>
	/// <param name="numSamples"></param>
	/// <param name="channel"></param>
	[Obsolete("GetOutputData returning a float[] is deprecated, use GetOutputData and pass a pre allocated array instead.")]
	public static float[] GetOutputData(int numSamples, int channel)
	{
		float[] array = new float[numSamples];
		GetOutputDataHelper(array, channel);
		return array;
	}

	/// <summary>
	///   <para>Returns a block of the listener (master)'s output data.</para>
	/// </summary>
	/// <param name="samples"></param>
	/// <param name="channel"></param>
	public static void GetOutputData(float[] samples, int channel)
	{
		GetOutputDataHelper(samples, channel);
	}

	/// <summary>
	///   <para></para>
	/// </summary>
	/// <param name="numSamples"></param>
	/// <param name="channel"></param>
	/// <param name="window"></param>
	[Obsolete("GetSpectrumData returning a float[] is deprecated, use GetOutputData and pass a pre allocated array instead.")]
	public static float[] GetSpectrumData(int numSamples, int channel, FFTWindow window)
	{
		float[] array = new float[numSamples];
		GetSpectrumDataHelper(array, channel, window);
		return array;
	}

	/// <summary>
	///   <para>Returns a block of the listener (master)'s spectrum data.</para>
	/// </summary>
	/// <param name="samples"></param>
	/// <param name="channel"></param>
	/// <param name="window"></param>
	public static void GetSpectrumData(float[] samples, int channel, FFTWindow window)
	{
		GetSpectrumDataHelper(samples, channel, window);
	}
}

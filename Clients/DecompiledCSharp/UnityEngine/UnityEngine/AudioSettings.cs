using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Controls the global audio settings from script.</para>
/// </summary>
public sealed class AudioSettings
{
	/// <summary>
	///   <para>A delegate called whenever the global audio settings are changed, either by AudioSettings.Reset or by an external device change such as the OS control panel changing the sample rate or because the default output device was changed, for example when plugging in an HDMI monitor or a USB headset.</para>
	/// </summary>
	/// <param name="deviceWasChanged">True if the change was caused by an device change.</param>
	public delegate void AudioConfigurationChangeHandler(bool deviceWasChanged);

	/// <summary>
	///   <para>Returns the speaker mode capability of the current audio driver. (Read Only)</para>
	/// </summary>
	public static extern AudioSpeakerMode driverCapabilities
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Gets the current speaker mode. Default is 2 channel stereo.</para>
	/// </summary>
	public static extern AudioSpeakerMode speakerMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns the current time of the audio system.</para>
	/// </summary>
	public static extern double dspTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Get the mixer's current output rate.</para>
	/// </summary>
	public static extern int outputSampleRate
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public static event AudioConfigurationChangeHandler OnAudioConfigurationChanged;

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void GetDSPBufferSize(out int bufferLength, out int numBuffers);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Obsolete("AudioSettings.SetDSPBufferSize is deprecated and has been replaced by audio project settings and the AudioSettings.GetConfiguration/AudioSettings.Reset API.")]
	public static extern void SetDSPBufferSize(int bufferLength, int numBuffers);

	/// <summary>
	///   <para>Returns the current configuration of the audio device and system. The values in the struct may then be modified and reapplied via AudioSettings.Reset.</para>
	/// </summary>
	/// <returns>
	///   <para>The new configuration to be applied.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern AudioConfiguration GetConfiguration();

	/// <summary>
	///   <para>Performs a change of the device configuration. In response to this the AudioSettings.OnAudioConfigurationChanged delegate is invoked with the argument deviceWasChanged=false. It cannot be guaranteed that the exact settings specified can be used, but the an attempt is made to use the closest match supported by the system.</para>
	/// </summary>
	/// <param name="config">The new configuration to be used.</param>
	/// <returns>
	///   <para>True if all settings could be successfully applied.</para>
	/// </returns>
	public static bool Reset(AudioConfiguration config)
	{
		return INTERNAL_CALL_Reset(ref config);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_Reset(ref AudioConfiguration config);

	internal static void InvokeOnAudioConfigurationChanged(bool deviceWasChanged)
	{
		if (AudioSettings.OnAudioConfigurationChanged != null)
		{
			AudioSettings.OnAudioConfigurationChanged(deviceWasChanged);
		}
	}
}

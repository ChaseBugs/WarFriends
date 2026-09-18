using System.Runtime.CompilerServices;

namespace UnityEngine.Audio;

/// <summary>
///   <para>Object representing a group in the mixer.</para>
/// </summary>
public class AudioMixerGroup : Object
{
	public extern AudioMixer audioMixer
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal AudioMixerGroup()
	{
	}
}

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine.Experimental.Director;

/// <summary>
///   <para>Playable used to mix AnimationPlayables.</para>
/// </summary>
public class AnimationMixerPlayable : AnimationPlayable
{
	public AnimationMixerPlayable()
		: base(final: false)
	{
		m_Ptr = IntPtr.Zero;
		InstantiateEnginePlayable();
	}

	public AnimationMixerPlayable(bool final)
		: base(final: false)
	{
		m_Ptr = IntPtr.Zero;
		if (final)
		{
			InstantiateEnginePlayable();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void InstantiateEnginePlayable();

	/// <summary>
	///   <para>Automatically creates an AnimationClipPlayable for each supplied AnimationClip, then sets them as inputs to the mixer.</para>
	/// </summary>
	/// <param name="clips">AnimationClips to be used as inputs.</param>
	/// <returns>
	///   <para>Returns false if the creation of the AnimationClipPlayables failed, or if the connection failed.</para>
	/// </returns>
	public bool SetInputs(AnimationClip[] clips)
	{
		if (clips == null)
		{
			throw new NullReferenceException("Parameter clips was null. You need to pass in a valid array of clips.");
		}
		AnimationPlayable[] array = new AnimationPlayable[clips.Length];
		for (int i = 0; i < clips.Length; i++)
		{
			array[i] = new AnimationClipPlayable(clips[i]);
		}
		return base.SetInputs(array);
	}
}

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Stores keyframe based animations.</para>
/// </summary>
public sealed class AnimationClip : Motion
{
	/// <summary>
	///   <para>Animation length in seconds. (Read Only)</para>
	/// </summary>
	public extern float length
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal extern float startTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal extern float stopTime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Frame rate at which keyframes are sampled. (Read Only)</para>
	/// </summary>
	public extern float frameRate
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Sets the default wrap mode used in the animation state.</para>
	/// </summary>
	public extern WrapMode wrapMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>AABB of this Animation Clip in local space of Animation component that it is attached too.</para>
	/// </summary>
	public Bounds localBounds
	{
		get
		{
			INTERNAL_get_localBounds(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_localBounds(ref value);
		}
	}

	/// <summary>
	///   <para>Set to true if the AnimationClip will be used with the Legacy Animation component ( instead of the Animator ).</para>
	/// </summary>
	public new extern bool legacy
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns true if the animation contains curve that drives a humanoid rig.</para>
	/// </summary>
	public extern bool humanMotion
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Animation Events for this animation clip.</para>
	/// </summary>
	public AnimationEvent[] events
	{
		get
		{
			return (AnimationEvent[])GetEventsInternal();
		}
		set
		{
			SetEventsInternal(value);
		}
	}

	/// <summary>
	///   <para>Creates a new animation clip.</para>
	/// </summary>
	public AnimationClip()
	{
		Internal_CreateAnimationClip(this);
	}

	/// <summary>
	///   <para>Samples an animation at a given time for any animated properties.</para>
	/// </summary>
	/// <param name="go">The animated game object.</param>
	/// <param name="time">The time to sample an animation.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SampleAnimation(GameObject go, float time);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_CreateAnimationClip([Writable] AnimationClip self);

	/// <summary>
	///   <para>Assigns the curve to animate a specific property.</para>
	/// </summary>
	/// <param name="relativePath">Path to the game object this curve applies to. relativePath is formatted similar to a pathname, e.g. "rootspineleftArm".
	/// If relativePath is empty it refers to the game object the animation clip is attached to.</param>
	/// <param name="type">The class type of the component that is animated.</param>
	/// <param name="propertyName">The name or path to the property being animated.</param>
	/// <param name="curve">The animation curve.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetCurve(string relativePath, Type type, string propertyName, AnimationCurve curve);

	/// <summary>
	///   <para>In order to insure better interpolation of quaternions, call this function after you are finished setting animation curves.</para>
	/// </summary>
	public void EnsureQuaternionContinuity()
	{
		INTERNAL_CALL_EnsureQuaternionContinuity(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_EnsureQuaternionContinuity(AnimationClip self);

	/// <summary>
	///   <para>Clears all curves from the clip.</para>
	/// </summary>
	public void ClearCurves()
	{
		INTERNAL_CALL_ClearCurves(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_ClearCurves(AnimationClip self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_localBounds(out Bounds value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_localBounds(ref Bounds value);

	/// <summary>
	///   <para>Adds an animation event to the clip.</para>
	/// </summary>
	/// <param name="evt">AnimationEvent to add.</param>
	public void AddEvent(AnimationEvent evt)
	{
		AddEventInternal(evt);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void AddEventInternal(object evt);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void SetEventsInternal(Array value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern Array GetEventsInternal();
}

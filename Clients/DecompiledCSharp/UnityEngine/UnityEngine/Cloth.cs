using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>The Cloth class provides an interface to cloth simulation physics.</para>
/// </summary>
public sealed class Cloth : Component
{
	/// <summary>
	///   <para>Cloth's sleep threshold.</para>
	/// </summary>
	public extern float sleepThreshold
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Bending stiffness of the cloth.</para>
	/// </summary>
	public extern float bendingStiffness
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Stretching stiffness of the cloth.</para>
	/// </summary>
	public extern float stretchingStiffness
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Damp cloth motion.</para>
	/// </summary>
	public extern float damping
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>A constant, external acceleration applied to the cloth.</para>
	/// </summary>
	public Vector3 externalAcceleration
	{
		get
		{
			INTERNAL_get_externalAcceleration(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_externalAcceleration(ref value);
		}
	}

	/// <summary>
	///   <para>A random, external acceleration applied to the cloth.</para>
	/// </summary>
	public Vector3 randomAcceleration
	{
		get
		{
			INTERNAL_get_randomAcceleration(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_randomAcceleration(ref value);
		}
	}

	/// <summary>
	///   <para>Should gravity affect the cloth simulation?</para>
	/// </summary>
	public extern bool useGravity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("Deprecated. Cloth.selfCollisions is no longer supported since Unity 5.0.", true)]
	public extern bool selfCollision
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Is this cloth enabled?</para>
	/// </summary>
	public extern bool enabled
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The current vertex positions of the cloth object.</para>
	/// </summary>
	public extern Vector3[] vertices
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The current normals of the cloth object.</para>
	/// </summary>
	public extern Vector3[] normals
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The friction of the cloth when colliding with the character.</para>
	/// </summary>
	public extern float friction
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How much to increase mass of colliding particles.</para>
	/// </summary>
	public extern float collisionMassScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Enable continuous collision to improve collision stability.</para>
	/// </summary>
	public extern float useContinuousCollision
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Add one virtual particle per triangle to improve collision stability.</para>
	/// </summary>
	public extern float useVirtualParticles
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The cloth skinning coefficients used to set up how the cloth interacts with the skinned mesh.</para>
	/// </summary>
	public extern ClothSkinningCoefficient[] coefficients
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How much world-space movement of the character will affect cloth vertices.</para>
	/// </summary>
	public extern float worldVelocityScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How much world-space acceleration of the character will affect cloth vertices.</para>
	/// </summary>
	public extern float worldAccelerationScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Number of solver iterations per second.</para>
	/// </summary>
	public extern bool solverFrequency
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>An array of CapsuleColliders which this Cloth instance should collide with.</para>
	/// </summary>
	public extern CapsuleCollider[] capsuleColliders
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>An array of ClothSphereColliderPairs which this Cloth instance should collide with.</para>
	/// </summary>
	public extern ClothSphereColliderPair[] sphereColliders
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
	private extern void INTERNAL_get_externalAcceleration(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_externalAcceleration(ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_randomAcceleration(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_randomAcceleration(ref Vector3 value);

	/// <summary>
	///   <para>Clear the pending transform changes from affecting the cloth simulation.</para>
	/// </summary>
	public void ClearTransformMotion()
	{
		INTERNAL_CALL_ClearTransformMotion(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_ClearTransformMotion(Cloth self);

	/// <summary>
	///   <para>Fade the cloth simulation in or out.</para>
	/// </summary>
	/// <param name="enabled">Fading enabled or not.</param>
	/// <param name="interpolationTime"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetEnabledFading(bool enabled, [DefaultValue("0.5f")] float interpolationTime);

	[ExcludeFromDocs]
	public void SetEnabledFading(bool enabled)
	{
		float interpolationTime = 0.5f;
		SetEnabledFading(enabled, interpolationTime);
	}
}

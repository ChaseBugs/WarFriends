using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Joint that restricts the motion of a Rigidbody2D object to a single line.</para>
/// </summary>
public sealed class SliderJoint2D : AnchoredJoint2D
{
	/// <summary>
	///   <para>The angle of the line in space (in degrees).</para>
	/// </summary>
	public extern float angle
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should a motor force be applied automatically to the Rigidbody2D?</para>
	/// </summary>
	public extern bool useMotor
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should motion limits be used?</para>
	/// </summary>
	public extern bool useLimits
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Parameters for a motor force that is applied automatically to the Rigibody2D along the line.</para>
	/// </summary>
	public JointMotor2D motor
	{
		get
		{
			INTERNAL_get_motor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_motor(ref value);
		}
	}

	/// <summary>
	///   <para>Restrictions on how far the joint can slide in each direction along the line.</para>
	/// </summary>
	public JointTranslationLimits2D limits
	{
		get
		{
			INTERNAL_get_limits(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_limits(ref value);
		}
	}

	/// <summary>
	///   <para>Gets the state of the joint limit.</para>
	/// </summary>
	public extern JointLimitState2D limitState
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The angle (in degrees) referenced between the two bodies used as the constraint for the joint.</para>
	/// </summary>
	public extern float referenceAngle
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The current joint translation.</para>
	/// </summary>
	public extern float jointTranslation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The current joint speed.</para>
	/// </summary>
	public extern float jointSpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_motor(out JointMotor2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_motor(ref JointMotor2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_limits(out JointTranslationLimits2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_limits(ref JointTranslationLimits2D value);

	/// <summary>
	///   <para>Gets the motor force of the joint given the specified timestep.</para>
	/// </summary>
	/// <param name="timeStep">The time to calculate the motor force for.</param>
	public float GetMotorForce(float timeStep)
	{
		return INTERNAL_CALL_GetMotorForce(this, timeStep);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern float INTERNAL_CALL_GetMotorForce(SliderJoint2D self, float timeStep);
}

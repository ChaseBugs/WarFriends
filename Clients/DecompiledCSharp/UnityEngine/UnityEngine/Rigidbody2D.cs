using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Rigidbody physics component for 2D sprites.</para>
/// </summary>
public sealed class Rigidbody2D : Component
{
	/// <summary>
	///   <para>The position of the rigidbody.</para>
	/// </summary>
	public Vector2 position
	{
		get
		{
			INTERNAL_get_position(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_position(ref value);
		}
	}

	/// <summary>
	///   <para>The rotation of the rigdibody.</para>
	/// </summary>
	public extern float rotation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Linear velocity of the rigidbody.</para>
	/// </summary>
	public Vector2 velocity
	{
		get
		{
			INTERNAL_get_velocity(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_velocity(ref value);
		}
	}

	/// <summary>
	///   <para>Angular velocity in degrees per second.</para>
	/// </summary>
	public extern float angularVelocity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Mass of the rigidbody.</para>
	/// </summary>
	public extern float mass
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The center of mass of the rigidBody in local space.</para>
	/// </summary>
	public Vector2 centerOfMass
	{
		get
		{
			INTERNAL_get_centerOfMass(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_centerOfMass(ref value);
		}
	}

	/// <summary>
	///   <para>Gets the center of mass of the rigidBody in global space.</para>
	/// </summary>
	public Vector2 worldCenterOfMass
	{
		get
		{
			INTERNAL_get_worldCenterOfMass(out var value);
			return value;
		}
	}

	/// <summary>
	///   <para>The rigidBody rotational inertia.</para>
	/// </summary>
	public extern float inertia
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Coefficient of drag.</para>
	/// </summary>
	public extern float drag
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Coefficient of angular drag.</para>
	/// </summary>
	public extern float angularDrag
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The degree to which this object is affected by gravity.</para>
	/// </summary>
	public extern float gravityScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should this rigidbody be taken out of physics control?</para>
	/// </summary>
	public extern bool isKinematic
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should the rigidbody be prevented from rotating?</para>
	/// </summary>
	[Obsolete("The fixedAngle is no longer supported. Use constraints instead.")]
	public extern bool fixedAngle
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Controls whether physics will change the rotation of the object.</para>
	/// </summary>
	public extern bool freezeRotation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Controls which degrees of freedom are allowed for the simulation of this Rigidbody2D.</para>
	/// </summary>
	public extern RigidbodyConstraints2D constraints
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Indicates whether the rigid body should be simulated or not by the physics system.</para>
	/// </summary>
	public extern bool simulated
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Physics interpolation used between updates.</para>
	/// </summary>
	public extern RigidbodyInterpolation2D interpolation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The sleep state that the rigidbody will initially be in.</para>
	/// </summary>
	public extern RigidbodySleepMode2D sleepMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The method used by the physics engine to check if two objects have collided.</para>
	/// </summary>
	public extern CollisionDetectionMode2D collisionDetectionMode
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
	private extern void INTERNAL_get_position(out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_position(ref Vector2 value);

	/// <summary>
	///   <para>Moves the rigidbody to position.</para>
	/// </summary>
	/// <param name="position">The new position for the Rigidbody object.</param>
	public void MovePosition(Vector2 position)
	{
		INTERNAL_CALL_MovePosition(this, ref position);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_MovePosition(Rigidbody2D self, ref Vector2 position);

	/// <summary>
	///   <para>Rotates the rigidbody to angle (given in degrees).</para>
	/// </summary>
	/// <param name="angle">The new rotation angle for the Rigidbody object.</param>
	public void MoveRotation(float angle)
	{
		INTERNAL_CALL_MoveRotation(this, angle);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_MoveRotation(Rigidbody2D self, float angle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_velocity(out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_velocity(ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_centerOfMass(out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_centerOfMass(ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_worldCenterOfMass(out Vector2 value);

	/// <summary>
	///   <para>Is the rigidbody "sleeping"?</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsSleeping();

	/// <summary>
	///   <para>Is the rigidbody "awake"?</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsAwake();

	/// <summary>
	///   <para>Make the rigidbody "sleep".</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Sleep();

	/// <summary>
	///   <para>Disables the "sleeping" state of a rigidbody.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void WakeUp();

	/// <summary>
	///   <para>Check whether any of the collider(s) attached to this rigidbody are touching the collider or not.</para>
	/// </summary>
	/// <param name="collider">The collider to check if it is touching any of the collider(s) attached to this rigidbody.</param>
	/// <returns>
	///   <para>Whether the collider is touching any of the collider(s) attached to this rigidbody or not.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsTouching(Collider2D collider);

	/// <summary>
	///   <para>Checks whether any of the collider(s) attached to this rigidbody are touching any colliders on the specified layerMask or not.</para>
	/// </summary>
	/// <param name="layerMask">Any colliders on any of these layers count as touching.</param>
	/// <returns>
	///   <para>Whether any of the collider(s) attached to this rigidbody are touching any colliders on the specified layerMask or not.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsTouchingLayers([DefaultValue("Physics2D.AllLayers")] int layerMask);

	[ExcludeFromDocs]
	public bool IsTouchingLayers()
	{
		int layerMask = -1;
		return IsTouchingLayers(layerMask);
	}

	/// <summary>
	///   <para>Apply a force to the rigidbody.</para>
	/// </summary>
	/// <param name="force">Components of the force in the X and Y axes.</param>
	/// <param name="mode">The method used to apply the specified force.</param>
	public void AddForce(Vector2 force, [DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		INTERNAL_CALL_AddForce(this, ref force, mode);
	}

	[ExcludeFromDocs]
	public void AddForce(Vector2 force)
	{
		ForceMode2D mode = ForceMode2D.Force;
		INTERNAL_CALL_AddForce(this, ref force, mode);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_AddForce(Rigidbody2D self, ref Vector2 force, ForceMode2D mode);

	/// <summary>
	///   <para>Adds a force to the rigidbody2D relative to its coordinate system.</para>
	/// </summary>
	/// <param name="relativeForce">Components of the force in the X and Y axes.</param>
	/// <param name="mode">The method used to apply the specified force.</param>
	public void AddRelativeForce(Vector2 relativeForce, [DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		INTERNAL_CALL_AddRelativeForce(this, ref relativeForce, mode);
	}

	[ExcludeFromDocs]
	public void AddRelativeForce(Vector2 relativeForce)
	{
		ForceMode2D mode = ForceMode2D.Force;
		INTERNAL_CALL_AddRelativeForce(this, ref relativeForce, mode);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_AddRelativeForce(Rigidbody2D self, ref Vector2 relativeForce, ForceMode2D mode);

	/// <summary>
	///   <para>Apply a force at a given position in space.</para>
	/// </summary>
	/// <param name="force">Components of the force in the X and Y axes.</param>
	/// <param name="position">Position in world space to apply the force.</param>
	/// <param name="mode">The method used to apply the specified force.</param>
	public void AddForceAtPosition(Vector2 force, Vector2 position, [DefaultValue("ForceMode2D.Force")] ForceMode2D mode)
	{
		INTERNAL_CALL_AddForceAtPosition(this, ref force, ref position, mode);
	}

	[ExcludeFromDocs]
	public void AddForceAtPosition(Vector2 force, Vector2 position)
	{
		ForceMode2D mode = ForceMode2D.Force;
		INTERNAL_CALL_AddForceAtPosition(this, ref force, ref position, mode);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_AddForceAtPosition(Rigidbody2D self, ref Vector2 force, ref Vector2 position, ForceMode2D mode);

	/// <summary>
	///   <para>Apply a torque at the rigidbody's centre of mass.</para>
	/// </summary>
	/// <param name="torque">Torque to apply.</param>
	/// <param name="mode">The force mode to use.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void AddTorque(float torque, [DefaultValue("ForceMode2D.Force")] ForceMode2D mode);

	[ExcludeFromDocs]
	public void AddTorque(float torque)
	{
		ForceMode2D mode = ForceMode2D.Force;
		AddTorque(torque, mode);
	}

	/// <summary>
	///   <para>Get a local space point given the point point in rigidBody global space.</para>
	/// </summary>
	/// <param name="point">The global space point to transform into local space.</param>
	public Vector2 GetPoint(Vector2 point)
	{
		Rigidbody2D_CUSTOM_INTERNAL_GetPoint(this, point, out var value);
		return value;
	}

	private static void Rigidbody2D_CUSTOM_INTERNAL_GetPoint(Rigidbody2D rigidbody, Vector2 point, out Vector2 value)
	{
		INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetPoint(rigidbody, ref point, out value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetPoint(Rigidbody2D rigidbody, ref Vector2 point, out Vector2 value);

	/// <summary>
	///   <para>Get a global space point given the point relativePoint in rigidBody local space.</para>
	/// </summary>
	/// <param name="relativePoint">The local space point to transform into global space.</param>
	public Vector2 GetRelativePoint(Vector2 relativePoint)
	{
		Rigidbody2D_CUSTOM_INTERNAL_GetRelativePoint(this, relativePoint, out var value);
		return value;
	}

	private static void Rigidbody2D_CUSTOM_INTERNAL_GetRelativePoint(Rigidbody2D rigidbody, Vector2 relativePoint, out Vector2 value)
	{
		INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativePoint(rigidbody, ref relativePoint, out value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativePoint(Rigidbody2D rigidbody, ref Vector2 relativePoint, out Vector2 value);

	/// <summary>
	///   <para>Get a local space vector given the vector vector in rigidBody global space.</para>
	/// </summary>
	/// <param name="vector">The global space vector to transform into a local space vector.</param>
	public Vector2 GetVector(Vector2 vector)
	{
		Rigidbody2D_CUSTOM_INTERNAL_GetVector(this, vector, out var value);
		return value;
	}

	private static void Rigidbody2D_CUSTOM_INTERNAL_GetVector(Rigidbody2D rigidbody, Vector2 vector, out Vector2 value)
	{
		INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetVector(rigidbody, ref vector, out value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetVector(Rigidbody2D rigidbody, ref Vector2 vector, out Vector2 value);

	/// <summary>
	///   <para>Get a global space vector given the vector relativeVector in rigidBody local space.</para>
	/// </summary>
	/// <param name="relativeVector">The local space vector to transform into a global space vector.</param>
	public Vector2 GetRelativeVector(Vector2 relativeVector)
	{
		Rigidbody2D_CUSTOM_INTERNAL_GetRelativeVector(this, relativeVector, out var value);
		return value;
	}

	private static void Rigidbody2D_CUSTOM_INTERNAL_GetRelativeVector(Rigidbody2D rigidbody, Vector2 relativeVector, out Vector2 value)
	{
		INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativeVector(rigidbody, ref relativeVector, out value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativeVector(Rigidbody2D rigidbody, ref Vector2 relativeVector, out Vector2 value);

	/// <summary>
	///   <para>The velocity of the rigidbody at the point Point in global space.</para>
	/// </summary>
	/// <param name="point">The global space point to calculate velocity for.</param>
	public Vector2 GetPointVelocity(Vector2 point)
	{
		Rigidbody2D_CUSTOM_INTERNAL_GetPointVelocity(this, point, out var value);
		return value;
	}

	private static void Rigidbody2D_CUSTOM_INTERNAL_GetPointVelocity(Rigidbody2D rigidbody, Vector2 point, out Vector2 value)
	{
		INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetPointVelocity(rigidbody, ref point, out value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetPointVelocity(Rigidbody2D rigidbody, ref Vector2 point, out Vector2 value);

	/// <summary>
	///   <para>The velocity of the rigidbody at the point Point in local space.</para>
	/// </summary>
	/// <param name="relativePoint">The local space point to calculate velocity for.</param>
	public Vector2 GetRelativePointVelocity(Vector2 relativePoint)
	{
		Rigidbody2D_CUSTOM_INTERNAL_GetRelativePointVelocity(this, relativePoint, out var value);
		return value;
	}

	private static void Rigidbody2D_CUSTOM_INTERNAL_GetRelativePointVelocity(Rigidbody2D rigidbody, Vector2 relativePoint, out Vector2 value)
	{
		INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativePointVelocity(rigidbody, ref relativePoint, out value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Rigidbody2D_CUSTOM_INTERNAL_GetRelativePointVelocity(Rigidbody2D rigidbody, ref Vector2 relativePoint, out Vector2 value);
}

using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Parent class for collider types used with 2D gameplay.</para>
/// </summary>
public class Collider2D : Behaviour
{
	/// <summary>
	///   <para>Is this collider configured as a trigger?</para>
	/// </summary>
	public extern bool isTrigger
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Whether the collider is used by an attached effector or not.</para>
	/// </summary>
	public extern bool usedByEffector
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The local offset of the collider geometry.</para>
	/// </summary>
	public Vector2 offset
	{
		get
		{
			INTERNAL_get_offset(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_offset(ref value);
		}
	}

	/// <summary>
	///   <para>The Rigidbody2D attached to the Collider2D's GameObject.</para>
	/// </summary>
	public extern Rigidbody2D attachedRigidbody
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The number of separate shaped regions in the collider.</para>
	/// </summary>
	public extern int shapeCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The world space bounding area of the collider.</para>
	/// </summary>
	public Bounds bounds
	{
		get
		{
			INTERNAL_get_bounds(out var value);
			return value;
		}
	}

	internal extern ColliderErrorState2D errorState
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The PhysicsMaterial2D that is applied to this collider.</para>
	/// </summary>
	public extern PhysicsMaterial2D sharedMaterial
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
	private extern void INTERNAL_get_offset(out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_offset(ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_bounds(out Bounds value);

	/// <summary>
	///   <para>Check if a collider overlaps a point in space.</para>
	/// </summary>
	/// <param name="point">A point in world space.</param>
	public bool OverlapPoint(Vector2 point)
	{
		return INTERNAL_CALL_OverlapPoint(this, ref point);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_OverlapPoint(Collider2D self, ref Vector2 point);

	/// <summary>
	///   <para>Check whether this collider is touching the collider or not.</para>
	/// </summary>
	/// <param name="collider">The collider to check if it is touching this collider.</param>
	/// <returns>
	///   <para>Whether the collider is touching this collider or not.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsTouching(Collider2D collider);

	/// <summary>
	///   <para>Checks whether this collider is touching any colliders on the specified layerMask or not.</para>
	/// </summary>
	/// <param name="layerMask">Any colliders on any of these layers count as touching.</param>
	/// <returns>
	///   <para>Whether this collider is touching any collider on the specified layerMask or not.</para>
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
}

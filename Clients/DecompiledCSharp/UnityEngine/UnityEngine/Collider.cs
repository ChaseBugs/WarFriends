using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>A base class of all colliders.</para>
/// </summary>
public class Collider : Component
{
	/// <summary>
	///   <para>Enabled Colliders will collide with other colliders, disabled Colliders won't.</para>
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
	///   <para>The rigidbody the collider is attached to.</para>
	/// </summary>
	public extern Rigidbody attachedRigidbody
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is the collider a trigger?</para>
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
	///   <para>Contact offset value of this collider.</para>
	/// </summary>
	public extern float contactOffset
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The material used by the collider.</para>
	/// </summary>
	public extern PhysicMaterial material
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The shared physic material of this collider.</para>
	/// </summary>
	public extern PhysicMaterial sharedMaterial
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The world space bounding volume of the collider.</para>
	/// </summary>
	public Bounds bounds
	{
		get
		{
			INTERNAL_get_bounds(out var value);
			return value;
		}
	}

	/// <summary>
	///   <para>The closest point to the bounding box of the attached collider.</para>
	/// </summary>
	/// <param name="position"></param>
	public Vector3 ClosestPointOnBounds(Vector3 position)
	{
		return INTERNAL_CALL_ClosestPointOnBounds(this, ref position);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Vector3 INTERNAL_CALL_ClosestPointOnBounds(Collider self, ref Vector3 position);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_bounds(out Bounds value);

	private static bool Internal_Raycast(Collider col, Ray ray, out RaycastHit hitInfo, float maxDistance)
	{
		return INTERNAL_CALL_Internal_Raycast(col, ref ray, out hitInfo, maxDistance);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_Internal_Raycast(Collider col, ref Ray ray, out RaycastHit hitInfo, float maxDistance);

	public bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance)
	{
		return Internal_Raycast(this, ray, out hitInfo, maxDistance);
	}
}

using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Joint is the base class for all joints.</para>
/// </summary>
public class Joint : Component
{
	/// <summary>
	///   <para>A reference to another rigidbody this joint connects to.</para>
	/// </summary>
	public extern Rigidbody connectedBody
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The Direction of the axis around which the body is constrained.</para>
	/// </summary>
	public Vector3 axis
	{
		get
		{
			INTERNAL_get_axis(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_axis(ref value);
		}
	}

	/// <summary>
	///   <para>The Position of the anchor around which the joints motion is constrained.</para>
	/// </summary>
	public Vector3 anchor
	{
		get
		{
			INTERNAL_get_anchor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_anchor(ref value);
		}
	}

	/// <summary>
	///   <para>Position of the anchor relative to the connected Rigidbody.</para>
	/// </summary>
	public Vector3 connectedAnchor
	{
		get
		{
			INTERNAL_get_connectedAnchor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_connectedAnchor(ref value);
		}
	}

	/// <summary>
	///   <para>Should the connectedAnchor be calculated automatically?</para>
	/// </summary>
	public extern bool autoConfigureConnectedAnchor
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The force that needs to be applied for this joint to break.</para>
	/// </summary>
	public extern float breakForce
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The torque that needs to be applied for this joint to break.</para>
	/// </summary>
	public extern float breakTorque
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Enable collision between bodies connected with the joint.</para>
	/// </summary>
	public extern bool enableCollision
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Toggle preprocessing for this joint.</para>
	/// </summary>
	public extern bool enablePreprocessing
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
	private extern void INTERNAL_get_axis(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_axis(ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_anchor(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_anchor(ref Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_connectedAnchor(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_connectedAnchor(ref Vector3 value);
}

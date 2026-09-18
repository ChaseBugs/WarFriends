using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Describes a contact point where the collision occurs.</para>
/// </summary>
public struct ContactPoint
{
	internal Vector3 m_Point;

	internal Vector3 m_Normal;

	internal int m_ThisColliderInstanceID;

	internal int m_OtherColliderInstanceID;

	/// <summary>
	///   <para>The point of contact.</para>
	/// </summary>
	public Vector3 point => m_Point;

	/// <summary>
	///   <para>Normal of the contact point.</para>
	/// </summary>
	public Vector3 normal => m_Normal;

	/// <summary>
	///   <para>The first collider in contact at the point.</para>
	/// </summary>
	public Collider thisCollider => ColliderFromInstanceId(m_ThisColliderInstanceID);

	/// <summary>
	///   <para>The other collider in contact at the point.</para>
	/// </summary>
	public Collider otherCollider => ColliderFromInstanceId(m_OtherColliderInstanceID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Collider ColliderFromInstanceId(int instanceID);
}

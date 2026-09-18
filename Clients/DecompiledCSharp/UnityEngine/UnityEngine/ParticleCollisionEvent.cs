using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Information about a particle collision.</para>
/// </summary>
public struct ParticleCollisionEvent
{
	private Vector3 m_Intersection;

	private Vector3 m_Normal;

	private Vector3 m_Velocity;

	private int m_ColliderInstanceID;

	/// <summary>
	///   <para>Intersection point of the collision in world coordinates.</para>
	/// </summary>
	public Vector3 intersection => m_Intersection;

	/// <summary>
	///   <para>Geometry normal at the intersection point of the collision.</para>
	/// </summary>
	public Vector3 normal => m_Normal;

	/// <summary>
	///   <para>Incident velocity at the intersection point of the collision.</para>
	/// </summary>
	public Vector3 velocity => m_Velocity;

	/// <summary>
	///   <para>The Collider for the GameObject struck by the particles.</para>
	/// </summary>
	public Collider collider => InstanceIDToCollider(m_ColliderInstanceID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Collider InstanceIDToCollider(int instanceID);
}

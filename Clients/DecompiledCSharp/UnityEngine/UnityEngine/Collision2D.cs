using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Information returned by a collision in 2D physics.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public class Collision2D
{
	internal Rigidbody2D m_Rigidbody;

	internal Collider2D m_Collider;

	internal ContactPoint2D[] m_Contacts;

	internal Vector2 m_RelativeVelocity;

	internal bool m_Enabled;

	/// <summary>
	///   <para>Whether the collision was disabled or not.</para>
	/// </summary>
	public bool enabled => m_Enabled;

	/// <summary>
	///   <para>The incoming Rigidbody2D involved in the collision.</para>
	/// </summary>
	public Rigidbody2D rigidbody => m_Rigidbody;

	/// <summary>
	///   <para>The incoming Collider2D involved in the collision.</para>
	/// </summary>
	public Collider2D collider => m_Collider;

	/// <summary>
	///   <para>The Transform of the incoming object involved in the collision.</para>
	/// </summary>
	public Transform transform => (!(rigidbody != null)) ? collider.transform : rigidbody.transform;

	/// <summary>
	///   <para>The incoming GameObject involved in the collision.</para>
	/// </summary>
	public GameObject gameObject => (!(m_Rigidbody != null)) ? m_Collider.gameObject : m_Rigidbody.gameObject;

	/// <summary>
	///   <para>The specific points of contact with the incoming Collider2D.</para>
	/// </summary>
	public ContactPoint2D[] contacts => m_Contacts;

	/// <summary>
	///   <para>The relative linear velocity of the two colliding objects (Read Only).</para>
	/// </summary>
	public Vector2 relativeVelocity => m_RelativeVelocity;
}

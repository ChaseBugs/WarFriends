namespace UnityEngine;

/// <summary>
///   <para>Contact information for the wheel, reported by WheelCollider.</para>
/// </summary>
public struct WheelHit
{
	private Vector3 m_Point;

	private Vector3 m_Normal;

	private Vector3 m_ForwardDir;

	private Vector3 m_SidewaysDir;

	private float m_Force;

	private float m_ForwardSlip;

	private float m_SidewaysSlip;

	private Collider m_Collider;

	/// <summary>
	///   <para>The other Collider the wheel is hitting.</para>
	/// </summary>
	public Collider collider
	{
		get
		{
			return m_Collider;
		}
		set
		{
			m_Collider = value;
		}
	}

	/// <summary>
	///   <para>The point of contact between the wheel and the ground.</para>
	/// </summary>
	public Vector3 point
	{
		get
		{
			return m_Point;
		}
		set
		{
			m_Point = value;
		}
	}

	/// <summary>
	///   <para>The normal at the point of contact.</para>
	/// </summary>
	public Vector3 normal
	{
		get
		{
			return m_Normal;
		}
		set
		{
			m_Normal = value;
		}
	}

	/// <summary>
	///   <para>The direction the wheel is pointing in.</para>
	/// </summary>
	public Vector3 forwardDir
	{
		get
		{
			return m_ForwardDir;
		}
		set
		{
			m_ForwardDir = value;
		}
	}

	/// <summary>
	///   <para>The sideways direction of the wheel.</para>
	/// </summary>
	public Vector3 sidewaysDir
	{
		get
		{
			return m_SidewaysDir;
		}
		set
		{
			m_SidewaysDir = value;
		}
	}

	/// <summary>
	///   <para>The magnitude of the force being applied for the contact.</para>
	/// </summary>
	public float force
	{
		get
		{
			return m_Force;
		}
		set
		{
			m_Force = value;
		}
	}

	/// <summary>
	///   <para>Tire slip in the rolling direction. Acceleration slip is negative, braking slip is positive.</para>
	/// </summary>
	public float forwardSlip
	{
		get
		{
			return m_ForwardSlip;
		}
		set
		{
			m_Force = m_ForwardSlip;
		}
	}

	/// <summary>
	///   <para>Tire slip in the sideways direction.</para>
	/// </summary>
	public float sidewaysSlip
	{
		get
		{
			return m_SidewaysSlip;
		}
		set
		{
			m_SidewaysSlip = value;
		}
	}
}

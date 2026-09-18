namespace UnityEngine;

/// <summary>
///   <para>(Legacy Particle system).</para>
/// </summary>
public struct Particle
{
	private Vector3 m_Position;

	private Vector3 m_Velocity;

	private float m_Size;

	private float m_Rotation;

	private float m_AngularVelocity;

	private float m_Energy;

	private float m_StartEnergy;

	private Color m_Color;

	/// <summary>
	///   <para>The position of the particle.</para>
	/// </summary>
	public Vector3 position
	{
		get
		{
			return m_Position;
		}
		set
		{
			m_Position = value;
		}
	}

	/// <summary>
	///   <para>The velocity of the particle.</para>
	/// </summary>
	public Vector3 velocity
	{
		get
		{
			return m_Velocity;
		}
		set
		{
			m_Velocity = value;
		}
	}

	/// <summary>
	///   <para>The energy of the particle.</para>
	/// </summary>
	public float energy
	{
		get
		{
			return m_Energy;
		}
		set
		{
			m_Energy = value;
		}
	}

	/// <summary>
	///   <para>The starting energy of the particle.</para>
	/// </summary>
	public float startEnergy
	{
		get
		{
			return m_StartEnergy;
		}
		set
		{
			m_StartEnergy = value;
		}
	}

	/// <summary>
	///   <para>The size of the particle.</para>
	/// </summary>
	public float size
	{
		get
		{
			return m_Size;
		}
		set
		{
			m_Size = value;
		}
	}

	/// <summary>
	///   <para>The rotation of the particle.</para>
	/// </summary>
	public float rotation
	{
		get
		{
			return m_Rotation;
		}
		set
		{
			m_Rotation = value;
		}
	}

	/// <summary>
	///   <para>The angular velocity of the particle.</para>
	/// </summary>
	public float angularVelocity
	{
		get
		{
			return m_AngularVelocity;
		}
		set
		{
			m_AngularVelocity = value;
		}
	}

	/// <summary>
	///   <para>The color of the particle.</para>
	/// </summary>
	public Color color
	{
		get
		{
			return m_Color;
		}
		set
		{
			m_Color = value;
		}
	}
}

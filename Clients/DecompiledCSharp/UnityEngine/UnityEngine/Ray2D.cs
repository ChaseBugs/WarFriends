namespace UnityEngine;

/// <summary>
///   <para>A ray in 2D space.</para>
/// </summary>
public struct Ray2D(Vector2 origin, Vector2 direction)
{
	private Vector2 m_Origin = origin;

	private Vector2 m_Direction = direction.normalized;

	/// <summary>
	///   <para>The starting point of the ray in world space.</para>
	/// </summary>
	public Vector2 origin
	{
		get
		{
			return m_Origin;
		}
		set
		{
			m_Origin = value;
		}
	}

	/// <summary>
	///   <para>The direction of the ray in world space.</para>
	/// </summary>
	public Vector2 direction
	{
		get
		{
			return m_Direction;
		}
		set
		{
			m_Direction = value.normalized;
		}
	}

	/// <summary>
	///   <para>Get a point that lies a given distance along a ray.</para>
	/// </summary>
	/// <param name="distance">Distance of the desired point along the path of the ray.</param>
	public Vector2 GetPoint(float distance)
	{
		return m_Origin + m_Direction * distance;
	}

	public override string ToString()
	{
		return UnityString.Format("Origin: {0}, Dir: {1}", m_Origin, m_Direction);
	}

	public string ToString(string format)
	{
		return UnityString.Format("Origin: {0}, Dir: {1}", m_Origin.ToString(format), m_Direction.ToString(format));
	}
}

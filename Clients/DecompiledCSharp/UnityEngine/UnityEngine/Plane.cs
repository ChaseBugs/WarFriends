namespace UnityEngine;

/// <summary>
///   <para>Representation of a plane in 3D space.</para>
/// </summary>
public struct Plane
{
	private Vector3 m_Normal;

	private float m_Distance;

	/// <summary>
	///   <para>Normal vector of the plane.</para>
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
	///   <para>Distance from the origin to the plane.</para>
	/// </summary>
	public float distance
	{
		get
		{
			return m_Distance;
		}
		set
		{
			m_Distance = value;
		}
	}

	/// <summary>
	///   <para>Creates a plane.</para>
	/// </summary>
	/// <param name="inNormal"></param>
	/// <param name="inPoint"></param>
	public Plane(Vector3 inNormal, Vector3 inPoint)
	{
		m_Normal = Vector3.Normalize(inNormal);
		m_Distance = 0f - Vector3.Dot(inNormal, inPoint);
	}

	/// <summary>
	///   <para>Creates a plane.</para>
	/// </summary>
	/// <param name="inNormal"></param>
	/// <param name="d"></param>
	public Plane(Vector3 inNormal, float d)
	{
		m_Normal = Vector3.Normalize(inNormal);
		m_Distance = d;
	}

	/// <summary>
	///   <para>Creates a plane.</para>
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <param name="c"></param>
	public Plane(Vector3 a, Vector3 b, Vector3 c)
	{
		m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
		m_Distance = 0f - Vector3.Dot(m_Normal, a);
	}

	/// <summary>
	///   <para>Sets a plane using a point that lies within it along with a normal to orient it.</para>
	/// </summary>
	/// <param name="inNormal">The plane's normal vector.</param>
	/// <param name="inPoint">A point that lies on the plane.</param>
	public void SetNormalAndPosition(Vector3 inNormal, Vector3 inPoint)
	{
		normal = Vector3.Normalize(inNormal);
		distance = 0f - Vector3.Dot(inNormal, inPoint);
	}

	/// <summary>
	///   <para>Sets a plane using three points that lie within it.  The points go around clockwise as you look down on the top surface of the plane.</para>
	/// </summary>
	/// <param name="a">First point in clockwise order.</param>
	/// <param name="b">Second point in clockwise order.</param>
	/// <param name="c">Third point in clockwise order.</param>
	public void Set3Points(Vector3 a, Vector3 b, Vector3 c)
	{
		normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
		distance = 0f - Vector3.Dot(normal, a);
	}

	/// <summary>
	///   <para>Returns a signed distance from plane to point.</para>
	/// </summary>
	/// <param name="inPt"></param>
	public float GetDistanceToPoint(Vector3 inPt)
	{
		return Vector3.Dot(normal, inPt) + distance;
	}

	/// <summary>
	///   <para>Is a point on the positive side of the plane?</para>
	/// </summary>
	/// <param name="inPt"></param>
	public bool GetSide(Vector3 inPt)
	{
		return Vector3.Dot(normal, inPt) + distance > 0f;
	}

	/// <summary>
	///   <para>Are two points on the same side of the plane?</para>
	/// </summary>
	/// <param name="inPt0"></param>
	/// <param name="inPt1"></param>
	public bool SameSide(Vector3 inPt0, Vector3 inPt1)
	{
		float distanceToPoint = GetDistanceToPoint(inPt0);
		float distanceToPoint2 = GetDistanceToPoint(inPt1);
		if (distanceToPoint > 0f && distanceToPoint2 > 0f)
		{
			return true;
		}
		if (distanceToPoint <= 0f && distanceToPoint2 <= 0f)
		{
			return true;
		}
		return false;
	}

	public bool Raycast(Ray ray, out float enter)
	{
		float num = Vector3.Dot(ray.direction, normal);
		float num2 = 0f - Vector3.Dot(ray.origin, normal) - distance;
		if (Mathf.Approximately(num, 0f))
		{
			enter = 0f;
			return false;
		}
		enter = num2 / num;
		return enter > 0f;
	}
}

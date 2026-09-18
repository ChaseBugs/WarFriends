using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Represents an axis aligned bounding box.</para>
/// </summary>
public struct Bounds
{
	private Vector3 m_Center;

	private Vector3 m_Extents;

	/// <summary>
	///   <para>The center of the bounding box.</para>
	/// </summary>
	public Vector3 center
	{
		get
		{
			return m_Center;
		}
		set
		{
			m_Center = value;
		}
	}

	/// <summary>
	///   <para>The total size of the box. This is always twice as large as the extents.</para>
	/// </summary>
	public Vector3 size
	{
		get
		{
			return m_Extents * 2f;
		}
		set
		{
			m_Extents = value * 0.5f;
		}
	}

	/// <summary>
	///   <para>The extents of the box. This is always half of the size.</para>
	/// </summary>
	public Vector3 extents
	{
		get
		{
			return m_Extents;
		}
		set
		{
			m_Extents = value;
		}
	}

	/// <summary>
	///   <para>The minimal point of the box. This is always equal to center-extents.</para>
	/// </summary>
	public Vector3 min
	{
		get
		{
			return center - extents;
		}
		set
		{
			SetMinMax(value, max);
		}
	}

	/// <summary>
	///   <para>The maximal point of the box. This is always equal to center+extents.</para>
	/// </summary>
	public Vector3 max
	{
		get
		{
			return center + extents;
		}
		set
		{
			SetMinMax(min, value);
		}
	}

	/// <summary>
	///   <para>Creates new Bounds with a given center and total size. Bound extents will be half the given size.</para>
	/// </summary>
	/// <param name="center"></param>
	/// <param name="size"></param>
	public Bounds(Vector3 center, Vector3 size)
	{
		m_Center = center;
		m_Extents = size * 0.5f;
	}

	public override int GetHashCode()
	{
		return center.GetHashCode() ^ (extents.GetHashCode() << 2);
	}

	public override bool Equals(object other)
	{
		if (!(other is Bounds bounds))
		{
			return false;
		}
		return center.Equals(bounds.center) && extents.Equals(bounds.extents);
	}

	/// <summary>
	///   <para>Sets the bounds to the min and max value of the box.</para>
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	public void SetMinMax(Vector3 min, Vector3 max)
	{
		extents = (max - min) * 0.5f;
		center = min + extents;
	}

	/// <summary>
	///   <para>Grows the Bounds to include the point.</para>
	/// </summary>
	/// <param name="point"></param>
	public void Encapsulate(Vector3 point)
	{
		SetMinMax(Vector3.Min(min, point), Vector3.Max(max, point));
	}

	/// <summary>
	///   <para>Grow the bounds to encapsulate the bounds.</para>
	/// </summary>
	/// <param name="bounds"></param>
	public void Encapsulate(Bounds bounds)
	{
		Encapsulate(bounds.center - bounds.extents);
		Encapsulate(bounds.center + bounds.extents);
	}

	/// <summary>
	///   <para>Expand the bounds by increasing its size by amount along each side.</para>
	/// </summary>
	/// <param name="amount"></param>
	public void Expand(float amount)
	{
		amount *= 0.5f;
		extents += new Vector3(amount, amount, amount);
	}

	/// <summary>
	///   <para>Expand the bounds by increasing its size by amount along each side.</para>
	/// </summary>
	/// <param name="amount"></param>
	public void Expand(Vector3 amount)
	{
		extents += amount * 0.5f;
	}

	/// <summary>
	///   <para>Does another bounding box intersect with this bounding box?</para>
	/// </summary>
	/// <param name="bounds"></param>
	public bool Intersects(Bounds bounds)
	{
		return min.x <= bounds.max.x && max.x >= bounds.min.x && min.y <= bounds.max.y && max.y >= bounds.min.y && min.z <= bounds.max.z && max.z >= bounds.min.z;
	}

	private static bool Internal_Contains(Bounds m, Vector3 point)
	{
		return INTERNAL_CALL_Internal_Contains(ref m, ref point);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_Internal_Contains(ref Bounds m, ref Vector3 point);

	/// <summary>
	///   <para>Is point contained in the bounding box?</para>
	/// </summary>
	/// <param name="point"></param>
	public bool Contains(Vector3 point)
	{
		return Internal_Contains(this, point);
	}

	private static float Internal_SqrDistance(Bounds m, Vector3 point)
	{
		return INTERNAL_CALL_Internal_SqrDistance(ref m, ref point);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern float INTERNAL_CALL_Internal_SqrDistance(ref Bounds m, ref Vector3 point);

	/// <summary>
	///   <para>The smallest squared distance between the point and this bounding box.</para>
	/// </summary>
	/// <param name="point"></param>
	public float SqrDistance(Vector3 point)
	{
		return Internal_SqrDistance(this, point);
	}

	private static bool Internal_IntersectRay(ref Ray ray, ref Bounds bounds, out float distance)
	{
		return INTERNAL_CALL_Internal_IntersectRay(ref ray, ref bounds, out distance);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_Internal_IntersectRay(ref Ray ray, ref Bounds bounds, out float distance);

	/// <summary>
	///   <para>Does ray intersect this bounding box?</para>
	/// </summary>
	/// <param name="ray"></param>
	public bool IntersectRay(Ray ray)
	{
		float distance;
		return Internal_IntersectRay(ref ray, ref this, out distance);
	}

	public bool IntersectRay(Ray ray, out float distance)
	{
		return Internal_IntersectRay(ref ray, ref this, out distance);
	}

	private static Vector3 Internal_GetClosestPoint(ref Bounds bounds, ref Vector3 point)
	{
		return INTERNAL_CALL_Internal_GetClosestPoint(ref bounds, ref point);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Vector3 INTERNAL_CALL_Internal_GetClosestPoint(ref Bounds bounds, ref Vector3 point);

	/// <summary>
	///   <para>The closest point on the bounding box.</para>
	/// </summary>
	/// <param name="point">Arbitrary point.</param>
	/// <returns>
	///   <para>The point on the bounding box or inside the bounding box.</para>
	/// </returns>
	public Vector3 ClosestPoint(Vector3 point)
	{
		return Internal_GetClosestPoint(ref this, ref point);
	}

	/// <summary>
	///   <para>Returns a nicely formatted string for the bounds.</para>
	/// </summary>
	/// <param name="format"></param>
	public override string ToString()
	{
		return UnityString.Format("Center: {0}, Extents: {1}", m_Center, m_Extents);
	}

	/// <summary>
	///   <para>Returns a nicely formatted string for the bounds.</para>
	/// </summary>
	/// <param name="format"></param>
	public string ToString(string format)
	{
		return UnityString.Format("Center: {0}, Extents: {1}", m_Center.ToString(format), m_Extents.ToString(format));
	}

	public static bool operator ==(Bounds lhs, Bounds rhs)
	{
		return lhs.center == rhs.center && lhs.extents == rhs.extents;
	}

	public static bool operator !=(Bounds lhs, Bounds rhs)
	{
		return !(lhs == rhs);
	}
}

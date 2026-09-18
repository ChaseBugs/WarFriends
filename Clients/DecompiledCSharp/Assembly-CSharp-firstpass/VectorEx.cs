using UnityEngine;

public static class VectorEx
{
	public static Vector3 ReplaceX(this Vector3 lhs, float val)
	{
		lhs.x = val;
		return lhs;
	}

	public static Vector3 ReplaceY(this Vector3 lhs, float val)
	{
		lhs.y = val;
		return lhs;
	}

	public static Vector3 ReplaceZ(this Vector3 lhs, float val)
	{
		lhs.z = val;
		return lhs;
	}

	public static Vector3 ReplaceXY(this Vector3 lhs, float x, float y)
	{
		lhs.x = x;
		lhs.y = y;
		return lhs;
	}

	public static Vector3 ReplaceYZ(this Vector3 lhs, float y, float z)
	{
		lhs.y = y;
		lhs.z = z;
		return lhs;
	}

	public static Vector3 AddX(this Vector3 lhs, float val)
	{
		lhs.x += val;
		return lhs;
	}

	public static Vector3 AddY(this Vector3 lhs, float val)
	{
		lhs.y += val;
		return lhs;
	}

	public static Vector3 AddZ(this Vector3 lhs, float val)
	{
		lhs.z += val;
		return lhs;
	}

	public static Vector3 MultiplyXY(this Vector3 lhs, float multiplier)
	{
		lhs.x *= multiplier;
		lhs.y *= multiplier;
		return lhs;
	}

	public static Vector4 ReplaceX(this Vector4 lhs, float val)
	{
		lhs.x = val;
		return lhs;
	}

	public static Vector4 ReplaceZ(this Vector4 lhs, float val)
	{
		lhs.z = val;
		return lhs;
	}

	public static Vector4 ReplaceW(this Vector4 lhs, float val)
	{
		lhs.w = val;
		return lhs;
	}

	public static float PlanarDistance(this Vector3 lhs, Vector3 vec)
	{
		return Vector2.Distance(new Vector2(lhs.x, lhs.z), new Vector2(vec.x, vec.z));
	}

	public static Vector3 ClampMagnitude(this Vector3 vector, float minLength, float maxLength)
	{
		if ((double)vector.sqrMagnitude > (double)maxLength * (double)maxLength)
		{
			return vector.normalized * maxLength;
		}
		if ((double)vector.sqrMagnitude < (double)minLength * (double)minLength)
		{
			return vector.normalized * minLength;
		}
		return vector;
	}
}

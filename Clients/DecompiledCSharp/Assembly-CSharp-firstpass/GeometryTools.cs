using System;
using UnityEngine;

public static class GeometryTools
{
	public static float sign(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
	}

	public static int DetermineWindingOrder(Vector2[] vertices)
	{
		if (vertices.Length < 1)
		{
			return 0;
		}
		Vector2 vector = vertices[0];
		float num = 0f;
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector2 vector2 = vertices[i];
			Vector2 vector3 = vertices[(i + 1) % vertices.Length];
			Vector2 vector4 = vector - vector2;
			Vector2 vector5 = vector3 - vector2;
			float num2 = vector4.x * vector5.y - vector4.y * vector5.x;
			num += num2;
			vector = vector2;
		}
		double num3 = 0.0;
		for (int j = 0; j < vertices.Length; j++)
		{
			num3 += (double)((vertices[(j + 1) % vertices.Length].x - vertices[j].x) * (vertices[(j + 1) % vertices.Length].y + vertices[j].y));
		}
		return (!(num3 > 0.0)) ? 1 : 0;
	}

	public static Vector3[] BaseballFieldShape(float angle, float radius)
	{
		int num = Mathf.FloorToInt(Mathf.Clamp(angle / 5f, 3f, 35f));
		int num2 = num + 4;
		Vector3[] array = new Vector3[num2];
		for (int i = 0; i <= num; i++)
		{
			float num3 = -1f + 2f * (float)i / (float)num;
			Vector3 vector = Quaternion.AngleAxis(num3 * angle, Vector3.up) * Vector3.forward;
			Vector3 vector2 = radius * vector;
			array[i] = vector2;
		}
		ref Vector3 reference = ref array[num + 1];
		reference = 0.7f * (Quaternion.AngleAxis(1f * angle, Vector3.up) * Vector3.forward);
		ref Vector3 reference2 = ref array[num + 2];
		reference2 = 0.7f * (Quaternion.AngleAxis(-1f * angle, Vector3.up) * Vector3.forward);
		ref Vector3 reference3 = ref array[num + 3];
		reference3 = radius * 0.99f * (Quaternion.AngleAxis(-1f * angle, Vector3.up) * Vector3.forward);
		return array;
	}

	public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
	{
		return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
	}

	public static bool PointInTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
	{
		bool flag = sign(pt, v1, v2) < 0f;
		bool flag2 = sign(pt, v2, v3) < 0f;
		bool flag3 = sign(pt, v3, v1) < 0f;
		return flag == flag2 && flag2 == flag3;
	}

	public static bool ProcessIntersection(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4, ref Vector2 intersectionPoint, ref float t, ref bool coincident)
	{
		float num = (point4.x - point3.x) * (point1.y - point3.y) - (point4.y - point3.y) * (point1.x - point3.x);
		float num2 = (point2.x - point1.x) * (point1.y - point3.y) - (point2.y - point1.y) * (point1.x - point3.x);
		float num3 = (point4.y - point3.y) * (point2.x - point1.x) - (point4.x - point3.x) * (point2.y - point1.y);
		bool result = (coincident = false);
		if (Math.Abs(num3) <= 1E-05f)
		{
			if (Math.Abs(num) <= 1E-05f && Math.Abs(num2) <= 1E-05f)
			{
				result = (coincident = true);
				intersectionPoint = (point1 + point2) / 2f;
			}
		}
		else
		{
			num /= num3;
			num2 /= num3;
			if (num >= 0f && num <= 1f && num2 >= 0f && num2 <= 1f)
			{
				t = num2;
				result = true;
				intersectionPoint.x = point1.x + num * (point2.x - point1.x);
				intersectionPoint.y = point1.y + num * (point2.y - point1.y);
			}
		}
		return result;
	}

	public static Vector2 UVInterpolation(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 f, Vector2 uv1, Vector2 uv2, Vector2 uv3)
	{
		Vector3 vector = p1 - f;
		Vector3 vector2 = p2 - f;
		Vector3 vector3 = p3 - f;
		float magnitude = Vector3.Cross(p1 - p2, p1 - p3).magnitude;
		float num = Vector3.Cross(vector2, vector3).magnitude / magnitude;
		float num2 = Vector3.Cross(vector3, vector).magnitude / magnitude;
		float num3 = Vector3.Cross(vector, vector2).magnitude / magnitude;
		return uv1 * num + uv2 * num2 + uv3 * num3;
	}

	public static float DistanceToLine(Ray ray, Vector3 point)
	{
		return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
	}
}

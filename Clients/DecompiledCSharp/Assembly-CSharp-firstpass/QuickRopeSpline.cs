using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuickRopeSpline
{
	public List<Vector3> Points;

	public Vector3 Interpolate(float t)
	{
		if (Points.Count < 4)
		{
			return Vector3.zero;
		}
		int num = Points.Count - 3;
		int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
		float num3 = t * (float)num - (float)num2;
		Vector3 vector = Points[num2];
		Vector3 vector2 = Points[num2 + 1];
		Vector3 vector3 = Points[num2 + 2];
		Vector3 vector4 = Points[num2 + 3];
		return 0.5f * ((-vector + 3f * vector2 - 3f * vector3 + vector4) * (num3 * num3 * num3) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * (num3 * num3) + (-vector + vector3) * num3 + 2f * vector2);
	}

	public void DrawGizmo(float t, int precision, Color splineColor)
	{
		if (Points.Count >= 3)
		{
			Gizmos.color = splineColor;
			Vector3 to = Interpolate(0f);
			for (int i = 1; i <= 100; i++)
			{
				float t2 = (float)i / 100f;
				Vector3 vector = Interpolate(t2);
				Gizmos.DrawLine(vector, to);
				to = vector;
			}
			Gizmos.color = Color.white;
		}
	}
}

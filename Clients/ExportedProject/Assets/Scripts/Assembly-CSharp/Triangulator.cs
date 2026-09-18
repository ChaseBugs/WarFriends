using System.Collections.Generic;
using UnityEngine;

public static class Triangulator
{
	public static Vector3[] m_points;

	public static int[] Triangulate(Vector3[] points, out float area)
	{
		List<int> list = new List<int>();
		m_points = points;
		int num = m_points.Length;
		if (num < 3)
		{
			area = 0f;
			return list.ToArray();
		}
		int[] array = new int[num];
		area = Area();
		if (area > 0f)
		{
			for (int i = 0; i < num; i++)
			{
				array[i] = i;
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				array[j] = num - 1 - j;
			}
		}
		int num2 = num;
		int num3 = 2 * num2;
		int num4 = 0;
		int num5 = num2 - 1;
		while (num2 > 2)
		{
			if (num3-- <= 0)
			{
				return list.ToArray();
			}
			int num6 = num5;
			if (num2 <= num6)
			{
				num6 = 0;
			}
			num5 = num6 + 1;
			if (num2 <= num5)
			{
				num5 = 0;
			}
			int num7 = num5 + 1;
			if (num2 <= num7)
			{
				num7 = 0;
			}
			if (Snip(num6, num5, num7, num2, array))
			{
				int item = array[num6];
				int item2 = array[num5];
				int item3 = array[num7];
				list.Add(item);
				list.Add(item2);
				list.Add(item3);
				num4++;
				int num8 = num5;
				for (int k = num5 + 1; k < num2; k++)
				{
					array[num8] = array[k];
					num8++;
				}
				num2--;
				num3 = 2 * num2;
			}
		}
		list.Reverse();
		return list.ToArray();
	}

	private static float Area()
	{
		int num = m_points.Length;
		float num2 = 0f;
		int num3 = num - 1;
		int num4 = 0;
		while (num4 < num)
		{
			Vector2 vector = m_points[num3];
			Vector2 vector2 = m_points[num4];
			num2 += vector.x * vector2.y - vector2.x * vector.y;
			num3 = num4++;
		}
		return num2 * 0.5f;
	}

	private static bool Snip(int u, int v, int w, int n, int[] V)
	{
		Vector2 a = m_points[V[u]];
		Vector2 b = m_points[V[v]];
		Vector2 c = m_points[V[w]];
		if (Mathf.Epsilon > (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x))
		{
			return false;
		}
		for (int i = 0; i < n; i++)
		{
			if (i != u && i != v && i != w)
			{
				Vector2 p = m_points[V[i]];
				if (InsideTriangle(a, b, c, p))
				{
					return false;
				}
			}
		}
		return true;
	}

	private static bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
	{
		float num = C.x - B.x;
		float num2 = C.y - B.y;
		float num3 = A.x - C.x;
		float num4 = A.y - C.y;
		float num5 = B.x - A.x;
		float num6 = B.y - A.y;
		float num7 = P.x - A.x;
		float num8 = P.y - A.y;
		float num9 = P.x - B.x;
		float num10 = P.y - B.y;
		float num11 = P.x - C.x;
		float num12 = P.y - C.y;
		float num13 = num * num10 - num2 * num9;
		float num14 = num5 * num8 - num6 * num7;
		float num15 = num3 * num12 - num4 * num11;
		return num13 >= 0f && num15 >= 0f && num14 >= 0f;
	}
}

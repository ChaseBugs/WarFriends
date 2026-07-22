using System;
using UnityEngine;

public static class ScreenManager
{
	public static float BottomVisibleYLimit => 0f;

	public static bool isSmallScreen
	{
		get
		{
			if (SystemInfo.deviceModel.Contains("iPhone"))
			{
				return true;
			}
			if (Screen.dpi != 0f)
			{
				float num = (float)Screen.width / Screen.dpi;
				float num2 = (float)Screen.height / Screen.dpi;
				double num3 = Math.Sqrt(num * num + num2 * num2);
				return num3 < 5.599999904632568;
			}
			return false;
		}
	}

	public static float GetBottomYScreenInWorld()
	{
		return Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).y;
	}

	public static float GetLeftXScreenInWorld()
	{
		return Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
	}

	public static float GetRightXScreenInWorld()
	{
		return Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).x;
	}

	public static Vector2 GetScreenSize()
	{
		return new Vector2(Screen.width, Screen.height);
	}

	public static Vector2 getInputInWorldCoordinates()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	public static bool IsOutOfScreen(Vector3 point, float screenOffset)
	{
		Vector2 vector = Camera.main.WorldToViewportPoint(point);
		if (vector.x > 1f + screenOffset || vector.x < 0f - screenOffset || vector.y > 1f + screenOffset || vector.y < 0f - screenOffset)
		{
			return true;
		}
		return false;
	}

	public static Vector3 ClampInScreenXY(Camera c, Vector3 position, Bounds objectSize)
	{
		Vector3 result = position;
		Vector3 vector = c.ViewportToWorldPoint(new Vector2(0f, 0f));
		Vector3 vector2 = c.ViewportToWorldPoint(new Vector2(1f, 0f));
		Vector3 vector3 = c.ViewportToWorldPoint(new Vector2(1f, 1f));
		if (position.x - objectSize.extents.x < vector.x)
		{
			result.x = vector.x + objectSize.extents.x;
		}
		if (position.x + objectSize.extents.x > vector2.x)
		{
			result.x = vector2.x - objectSize.extents.x;
		}
		if (position.y - objectSize.extents.y < vector.y)
		{
			result.y = vector.y + objectSize.extents.y;
		}
		if (position.y + objectSize.extents.y > vector3.y)
		{
			result.y = vector3.y - objectSize.extents.y;
		}
		return result;
	}

	public static bool IsRendering(Camera c, Vector3 position, float objectWidth)
	{
		Vector3 vector = c.ViewportToWorldPoint(new Vector2(0f, 0f));
		Vector3 vector2 = c.ViewportToWorldPoint(new Vector2(1f, 0f));
		if (position.x + objectWidth < vector.x)
		{
			return false;
		}
		if (position.x - objectWidth > vector2.x)
		{
			return false;
		}
		return true;
	}
}

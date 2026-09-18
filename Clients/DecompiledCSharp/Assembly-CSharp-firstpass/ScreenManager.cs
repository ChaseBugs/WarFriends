using System;
using UnityEngine;

public static class ScreenManager
{
	public enum Aligment
	{
		TopRight,
		BottomRight,
		TopLeft,
		BottomLeft,
		TopCenter
	}

	public static float BottomVisibleYLimit => 0f;

	public static Vector3 MouseWorldPosiiton => Camera.main.ScreenToWorldPoint(Input.mousePosition);

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

	public static bool IsFullyVisible(tk2dSprite sprite)
	{
		return IsCoordinateVisible(GetBottomLeft(sprite)) && IsCoordinateVisible(GetBottomRight(sprite)) && IsCoordinateVisible(GetTopLeft(sprite)) && IsCoordinateVisible(GetTopRight(sprite));
	}

	public static bool IsPartlyVisible(tk2dSprite sprite)
	{
		return IsCoordinateVisible(GetBottomLeft(sprite)) || IsCoordinateVisible(GetBottomRight(sprite)) || IsCoordinateVisible(GetTopLeft(sprite)) || IsCoordinateVisible(GetTopRight(sprite));
	}

	public static bool IsPartlyVisibleOnlyX(tk2dSprite sprite)
	{
		bool flag = IsCoordinateVisibleOnlyX(GetTopLeft(sprite));
		bool flag2 = IsCoordinateVisibleOnlyX(GetTopRight(sprite));
		return flag || flag2;
	}

	public static bool IsCoordinateVisibleOnlyX(Vector2 position)
	{
		Vector2 vector = Camera.main.WorldToViewportPoint(position);
		if (vector.x < 1f && vector.x > 0f)
		{
			return true;
		}
		return false;
	}

	public static bool IsOutOfScreenLeft(tk2dSprite sprite, float xOffset)
	{
		Vector2 position = GetTopRight(sprite);
		return IsOutOfScreenLeft(position, xOffset);
	}

	public static bool IsOutOfScreenLeft(Vector2 position, float xOffset)
	{
		if (((Vector2)Camera.main.WorldToViewportPoint(position + new Vector2(xOffset, 0f))).x < 0f)
		{
			return true;
		}
		return false;
	}

	public static bool IsOutOfScreenLeft(tk2dSprite sprite)
	{
		Vector2 position = GetTopRight(sprite);
		return IsOutOfScreenLeft(position);
	}

	public static bool IsOutOfScreenLeft(Vector2 position)
	{
		if (((Vector2)Camera.main.WorldToViewportPoint(position)).x < 0f)
		{
			return true;
		}
		return false;
	}

	public static bool IsInScreenRight(tk2dBaseSprite sprite)
	{
		Vector2 position = GetTopRight(sprite);
		return IsInScreenRight(position);
	}

	public static bool IsInScreenRight(Vector2 position)
	{
		if (((Vector2)Camera.main.WorldToViewportPoint(position)).x < 1f)
		{
			return true;
		}
		return false;
	}

	public static bool IsOutOfScreenRight(tk2dSprite sprite)
	{
		Vector2 position = GetTopLeft(sprite);
		return IsOutOfScreenRight(position);
	}

	public static bool IsOutOfScreenRight(Vector2 position)
	{
		if (((Vector2)Camera.main.WorldToViewportPoint(position)).x > 0f)
		{
			return true;
		}
		return false;
	}

	public static Vector2 GetScreencoords(Vector3 worldCoords)
	{
		return Camera.main.WorldToScreenPoint(worldCoords);
	}

	public static bool AreOnSameSideOfScreenX(Vector2 vector1, Vector2 vector2)
	{
		return (IsOnLeftSideOfScreen(vector1) && IsOnLeftSideOfScreen(vector2)) || (!IsOnLeftSideOfScreen(vector1) && !IsOnLeftSideOfScreen(vector2));
	}

	public static bool IsOnLeftSideOfScreen(tk2dSprite sprite)
	{
		return IsOnLeftSideOfScreen(GetTopRight(sprite));
	}

	public static bool IsOnLeftSideOfScreen(Vector2 position)
	{
		return Camera.main.WorldToViewportPoint(position).x < 0.5f;
	}

	public static bool IsOnBottomSideOfScreen(tk2dSprite sprite)
	{
		return ((Vector2)Camera.main.WorldToViewportPoint(GetCenter(sprite))).y < 0.5f;
	}

	public static bool IsCoordinateVisible(Vector2 position)
	{
		Vector2 vector = Camera.main.WorldToViewportPoint(position);
		if (vector.x < 1f && vector.x > 0f && vector.y < 1f && vector.y > 0f)
		{
			return true;
		}
		return false;
	}

	public static Vector3 GetCenter(tk2dSprite sprite)
	{
		return sprite.transform.position + sprite.GetBounds().center;
	}

	public static Vector3 GetBottomLeft(tk2dSprite sprite)
	{
		return sprite.transform.position + new Vector3(sprite.GetBounds().min.x * sprite.gameObject.transform.lossyScale.x, sprite.GetBounds().min.y * sprite.gameObject.transform.lossyScale.y, sprite.GetBounds().min.z * sprite.gameObject.transform.lossyScale.z);
	}

	public static Vector3 GetBottomRight(tk2dSprite sprite)
	{
		Bounds bounds = sprite.GetBounds();
		return sprite.transform.position + new Vector3(bounds.max.x * sprite.gameObject.transform.lossyScale.x, bounds.min.y * sprite.gameObject.transform.lossyScale.y, 0f);
	}

	public static Vector3 GetTopLeft(tk2dSprite sprite)
	{
		Bounds bounds = sprite.GetBounds();
		return sprite.transform.position + new Vector3(bounds.min.x * sprite.gameObject.transform.lossyScale.x, bounds.max.y * sprite.gameObject.transform.lossyScale.y, 0f);
	}

	public static Vector3 GetTopRight(tk2dBaseSprite sprite)
	{
		return sprite.transform.position + new Vector3(sprite.GetBounds().max.x * sprite.gameObject.transform.lossyScale.x, sprite.GetBounds().max.y * sprite.gameObject.transform.lossyScale.y, sprite.GetBounds().max.z * sprite.gameObject.transform.lossyScale.z);
	}

	public static Vector3 GetSpritePosition(Aligment a, tk2dSprite sprite)
	{
		return a switch
		{
			Aligment.TopRight => GetTopRight(sprite), 
			Aligment.TopLeft => GetTopLeft(sprite), 
			Aligment.BottomLeft => GetBottomLeft(sprite), 
			Aligment.BottomRight => GetBottomRight(sprite), 
			Aligment.TopCenter => (GetTopLeft(sprite) + GetTopRight(sprite)) / 2f, 
			_ => GetBottomRight(sprite), 
		};
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
}

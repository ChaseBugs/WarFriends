using UnityEngine;

public static class ColorEx
{
	public static Color ReplaceR(this Color lhs, float val)
	{
		lhs.r = val;
		return lhs;
	}

	public static Color ReplaceG(this Color lhs, float val)
	{
		lhs.g = val;
		return lhs;
	}

	public static Color ReplaceB(this Color lhs, float val)
	{
		lhs.b = val;
		return lhs;
	}

	public static Color ReplaceA(this Color lhs, float val)
	{
		lhs.a = val;
		return lhs;
	}
}

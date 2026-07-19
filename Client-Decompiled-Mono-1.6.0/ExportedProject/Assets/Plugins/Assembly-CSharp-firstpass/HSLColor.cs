using UnityEngine;

public struct HSLColor
{
	public float h;

	public float s;

	public float l;

	public float a;

	public HSLColor(float h, float s, float l, float a)
	{
		this.h = h;
		this.s = s;
		this.l = l;
		this.a = a;
	}

	public HSLColor(float h, float s, float l)
	{
		this.h = h;
		this.s = s;
		this.l = l;
		a = 1f;
	}

	public HSLColor(Color c)
	{
		HSLColor hSLColor = FromRGBA(c);
		h = hSLColor.h;
		s = hSLColor.s;
		l = hSLColor.l;
		a = hSLColor.a;
	}

	public static HSLColor FromRGBA(Color c)
	{
		float num = c.a;
		float num2 = Mathf.Min(Mathf.Min(c.r, c.g), c.b);
		float num3 = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
		float num4 = (num2 + num3) / 2f;
		float num5;
		float num6;
		if (num2 == num3)
		{
			num5 = 0f;
			num6 = 0f;
		}
		else
		{
			float num7 = num3 - num2;
			num5 = ((!(num4 <= 0.5f)) ? (num7 / (2f - (num3 + num2))) : (num7 / (num3 + num2)));
			num6 = 0f;
			if (c.r == num3)
			{
				num6 = (c.g - c.b) / num7;
			}
			else if (c.g == num3)
			{
				num6 = 2f + (c.b - c.r) / num7;
			}
			else if (c.b == num3)
			{
				num6 = 4f + (c.r - c.g) / num7;
			}
			num6 = Mathf.Repeat(num6 * 60f, 360f);
		}
		return new HSLColor(num6, num5, num4, num);
	}

	public Color ToRGBA()
	{
		float num = a;
		float num2 = ((!(l <= 0.5f)) ? (l + s - l * s) : (l * (1f + s)));
		float n = 2f * l - num2;
		float r;
		float g;
		float b;
		if (s == 0f)
		{
			r = (g = (b = l));
		}
		else
		{
			r = Value(n, num2, h + 120f);
			g = Value(n, num2, h);
			b = Value(n, num2, h - 120f);
		}
		return new Color(r, g, b, num);
	}

	private static float Value(float n1, float n2, float hue)
	{
		hue = Mathf.Repeat(hue, 360f);
		if (hue < 60f)
		{
			return n1 + (n2 - n1) * hue / 60f;
		}
		if (hue < 180f)
		{
			return n2;
		}
		if (hue < 240f)
		{
			return n1 + (n2 - n1) * (240f - hue) / 60f;
		}
		return n1;
	}

	public static implicit operator HSLColor(Color src)
	{
		return FromRGBA(src);
	}

	public static implicit operator Color(HSLColor src)
	{
		return src.ToRGBA();
	}
}

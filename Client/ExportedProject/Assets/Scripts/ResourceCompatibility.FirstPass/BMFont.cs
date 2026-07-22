using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BMFont
{
	[HideInInspector]
	[SerializeField]
	private int mSize;

	[HideInInspector]
	[SerializeField]
	private int mBase;

	[HideInInspector]
	[SerializeField]
	private int mWidth;

	[HideInInspector]
	[SerializeField]
	private int mHeight;

	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	[HideInInspector]
	[SerializeField]
	private List<BMGlyph> mSaved;

	private Dictionary<int, BMGlyph> mDict;

	public bool isValid => false;

	public int charSize
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int baseOffset
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int texWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int texHeight
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int glyphCount => 0;

	public string spriteName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public BMGlyph GetGlyph(int index, bool createIfMissing)
	{
		return null;
	}

	public BMGlyph GetGlyph(int index)
	{
		return null;
	}

	public void Clear()
	{
	}

	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
	}
}

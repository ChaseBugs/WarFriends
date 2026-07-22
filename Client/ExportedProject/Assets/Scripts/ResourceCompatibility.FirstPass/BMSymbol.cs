using System;
using UnityEngine;

[Serializable]
public class BMSymbol
{
	public string sequence;

	public string spriteName;

	private UIAtlas.Sprite mSprite;

	private bool mIsValid;

	private int mLength;

	private int mOffsetX;

	private int mOffsetY;

	private int mWidth;

	private int mHeight;

	private int mAdvance;

	private Rect mUV;

	public int length => 0;

	public int offsetX => 0;

	public int offsetY => 0;

	public int width => 0;

	public int height => 0;

	public int advance => 0;

	public Rect uvRect => default(Rect);

	public void MarkAsDirty()
	{
	}

	public bool Validate(UIAtlas atlas)
	{
		return false;
	}
}

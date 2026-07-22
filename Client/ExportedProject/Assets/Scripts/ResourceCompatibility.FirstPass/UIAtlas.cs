using System;
using System.Collections.Generic;
using UnityEngine;

public class UIAtlas : MonoBehaviour
{
	[Serializable]
	public class Sprite
	{
		public string name;

		public Rect outer;

		public Rect inner;

		public bool rotated;

		public float paddingLeft;

		public float paddingRight;

		public float paddingTop;

		public float paddingBottom;

		public bool hasPadding => false;
	}

	public enum Coordinates
	{
		Pixels
	}

	[HideInInspector]
	[SerializeField]
	private Material material;

	[HideInInspector]
	[SerializeField]
	private List<Sprite> sprites;

	[HideInInspector]
	[SerializeField]
	private Coordinates mCoordinates;

	[HideInInspector]
	[SerializeField]
	private float mPixelSize;

	[HideInInspector]
	[SerializeField]
	private UIAtlas mReplacement;

	private int mPMA;

	private int mTextureScale;

	public string pngPath;

	public bool useBinaryData;

	[SerializeField]
	public int textureWidth;

	[SerializeField]
	public int textureHeight;

	public int TextureDimensinScale
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Material spriteMaterial
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool premultipliedAlpha => false;

	public List<Sprite> spriteList
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Texture texture => null;

	public Coordinates coordinates
	{
		get
		{
			return default(Coordinates);
		}
		set
		{
		}
	}

	public float pixelSize
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public UIAtlas replacement
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Sprite GetSprite(string name)
	{
		return null;
	}

	private static int CompareString(string a, string b)
	{
		return 0;
	}

	public BetterList<string> GetListOfSprites()
	{
		return null;
	}

	public BetterList<string> GetListOfSprites(string match)
	{
		return null;
	}

	private bool References(UIAtlas atlas)
	{
		return false;
	}

	public static bool CheckIfRelated(UIAtlas a, UIAtlas b)
	{
		return false;
	}

	public void MarkAsDirty()
	{
	}
}

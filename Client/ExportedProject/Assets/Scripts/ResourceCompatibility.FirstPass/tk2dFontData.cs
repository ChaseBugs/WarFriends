using System;
using System.Collections.Generic;
using UnityEngine;

public class tk2dFontData : MonoBehaviour
{
	public const int CURRENT_VERSION = 2;

	[HideInInspector]
	public int version;

	public float lineHeight;

	public tk2dFontChar[] chars;

	[SerializeField]
	private List<int> charDictKeys;

	[SerializeField]
	private List<tk2dFontChar> charDictValues;

	public string[] fontPlatforms;

	public string[] fontPlatformGUIDs;

	private tk2dFontData platformSpecificData;

	public bool hasPlatformData;

	public bool managedFont;

	public bool needMaterialInstance;

	public bool isPacked;

	public bool premultipliedAlpha;

	public tk2dSpriteCollectionData spriteCollection;

	public Dictionary<int, tk2dFontChar> charDict;

	public bool useDictionary;

	public tk2dFontKerning[] kerning;

	public float largestWidth;

	public Material material;

	[NonSerialized]
	public Material materialInst;

	public Texture2D gradientTexture;

	public bool textureGradients;

	public int gradientCount;

	public Vector2 texelSize;

	[HideInInspector]
	public float invOrthoSize;

	[HideInInspector]
	public float halfTargetHeight;

	public tk2dFontData inst => null;

	private void Init()
	{
	}

	public void ResetPlatformData()
	{
	}

	private void OnDestroy()
	{
	}

	public void InitDictionary()
	{
	}

	public void SetDictionary(Dictionary<int, tk2dFontChar> dict)
	{
	}
}

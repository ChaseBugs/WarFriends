using System;
using System.Collections.Generic;
using UnityEngine;

public class tk2dSpriteCollectionData : MonoBehaviour
{
	public const int CURRENT_VERSION = 3;

	public int version;

	public bool materialIdsValid;

	public bool needMaterialInstance;

	public tk2dSpriteDefinition[] spriteDefinitions;

	private Dictionary<string, int> spriteNameLookupDict;

	public bool premultipliedAlpha;

	public Material material;

	public Material[] materials;

	[NonSerialized]
	public Material[] materialInsts;

	public Texture[] textures;

	public bool allowMultipleAtlases;

	public string spriteCollectionGUID;

	public string spriteCollectionName;

	public string assetName;

	public bool loadable;

	public float invOrthoSize;

	public float halfTargetHeight;

	public int buildKey;

	public string dataGuid;

	public bool managedSpriteCollection;

	public bool hasPlatformData;

	public string[] spriteCollectionPlatforms;

	public string[] spriteCollectionPlatformGUIDs;

	private tk2dSpriteCollectionData platformSpecificData;

	public bool Transient { get; set; }

	public int Count => 0;

	public tk2dSpriteDefinition FirstValidDefinition => null;

	public int FirstValidDefinitionIndex => 0;

	public tk2dSpriteCollectionData inst => null;

	public int GetSpriteIdByName(string name)
	{
		return 0;
	}

	public int GetSpriteIdByName(string name, int defaultValue)
	{
		return 0;
	}

	public tk2dSpriteDefinition GetSpriteDefinition(string name)
	{
		return null;
	}

	public void InitDictionary()
	{
	}

	public bool IsValidSpriteId(int id)
	{
		return false;
	}

	public void InitMaterialIds()
	{
	}

	private void Init()
	{
	}

	public static tk2dSpriteCollectionData CreateFromTexture(Texture texture, tk2dSpriteCollectionSize size, string[] names, Rect[] regions, Vector2[] anchors)
	{
		return null;
	}

	public static tk2dSpriteCollectionData CreateFromTexturePacker(tk2dSpriteCollectionSize size, string texturePackerData, Texture texture)
	{
		return null;
	}

	public void ResetPlatformData()
	{
	}

	public void UnloadTextures()
	{
	}

	private void OnDestroy()
	{
	}
}

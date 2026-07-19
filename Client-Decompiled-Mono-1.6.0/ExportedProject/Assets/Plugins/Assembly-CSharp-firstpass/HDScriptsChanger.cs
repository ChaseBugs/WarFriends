using System;
using System.Collections.Generic;
using UnityEngine;

public class HDScriptsChanger : MonoBehaviour
{
	[Serializable]
	public class CollectionEntry
	{
		[SerializeField]
		public tk2dSpriteCollectionData HDCollection;

		[SerializeField]
		public tk2dSpriteCollectionData SDCollection;
	}

	public List<CollectionEntry> CollectionEntries;

	public bool disableInEditor = true;

	public int HDResolutionCutOff = 640;

	public bool test;

	public bool mTest;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			test = !test;
		}
		if (mTest != test)
		{
			mTest = test;
			if (test)
			{
				Debug.Log("SETTING HalfRes2xMS");
				QualitySettings.SetQualityLevel(1, false);
			}
			else
			{
				Debug.Log("SETTING FullRes2xMS");
				QualitySettings.SetQualityLevel(0, false);
			}
		}
	}

	private void Awake()
	{
		mTest = test;
	}

	private static UIFont LoadFont(string path)
	{
		UIFont uIFont = Resources.Load(path, typeof(UIFont)) as UIFont;
		LoadAtlas(uIFont.atlas);
		return uIFont;
	}

	private static UIAtlas LoadAtlas(string path)
	{
		UIAtlas atlas = Resources.Load(path, typeof(UIAtlas)) as UIAtlas;
		return LoadAtlas(atlas);
	}

	private static UIAtlas LoadAtlas(UIAtlas atlas)
	{
		if (atlas.useBinaryData)
		{
		}
		return atlas;
	}

	private void ChangeData(tk2dSpriteCollectionData SDCollection, tk2dSpriteCollectionData HDCollection)
	{
		SDCollection.version = HDCollection.version;
		SDCollection.materialIdsValid = HDCollection.materialIdsValid;
		SDCollection.spriteDefinitions = HDCollection.spriteDefinitions;
		SDCollection.premultipliedAlpha = HDCollection.premultipliedAlpha;
		SDCollection.material = HDCollection.material;
		SDCollection.materials = HDCollection.materials;
		SDCollection.textures = HDCollection.textures;
		SDCollection.allowMultipleAtlases = HDCollection.allowMultipleAtlases;
		SDCollection.spriteCollectionName = HDCollection.spriteCollectionName;
		SDCollection.loadable = HDCollection.loadable;
		SDCollection.invOrthoSize = HDCollection.invOrthoSize;
		SDCollection.halfTargetHeight = HDCollection.halfTargetHeight;
		SDCollection.buildKey = HDCollection.buildKey;
		SDCollection.managedSpriteCollection = HDCollection.managedSpriteCollection;
		SDCollection.hasPlatformData = HDCollection.hasPlatformData;
		SDCollection.spriteCollectionPlatforms = HDCollection.spriteCollectionPlatforms;
		SDCollection.spriteCollectionPlatformGUIDs = HDCollection.spriteCollectionPlatformGUIDs;
	}

	private void Start()
	{
	}
}

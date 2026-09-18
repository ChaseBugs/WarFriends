using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AtlasPreparer : Singleton<AtlasPreparer>
{
	public enum AtlasMode
	{
		Game,
		Menu,
		Both,
		Tutorial,
		Map
	}

	public enum ResourceMode
	{
		Resource,
		AssetBundle
	}

	[Serializable]
	public class TextureDatasNgui
	{
		public UIAtlas atlas;

		public AtlasMode mode = AtlasMode.Menu;

		public ResourceMode resourceMode = ResourceMode.AssetBundle;

		public bool translate;

		public Language language;

		public UIAtlas atlasReference;
	}

	[Serializable]
	public class TextureDatas2DToolkit
	{
		public Material material;

		public AtlasMode mode = AtlasMode.Menu;

		public string textureName;
	}

	public string buildTime;

	public UIFont font;

	public List<TextureDatasNgui> nGuiSpriteSheets = new List<TextureDatasNgui>();

	public List<TextureDatas2DToolkit> toolkitSrites = new List<TextureDatas2DToolkit>();

	public Texture2D substitueTexture;

	public bool test;

	private bool mBuildPrepared;

	protected override void Awake()
	{
		base.Awake();
		font.Clear();
		if (Application.isPlaying)
		{
			StartCoroutine(LoadImagesCoroutine());
		}
		if (Application.isPlaying)
		{
		}
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public static void Load2DToolkitTexture(string textureName)
	{
		foreach (TextureDatas2DToolkit toolkitSrite in Singleton<AtlasPreparer>.instance.toolkitSrites)
		{
			if (textureName == toolkitSrite.textureName)
			{
				string textureName2 = toolkitSrite.textureName;
				Texture2D mainTexture = Resources.Load<Texture2D>("GUI/2Dtoolkit/" + textureName2);
				toolkitSrite.material.mainTexture = mainTexture;
			}
		}
	}

	public static void UnLoad2DToolkitTexture(string textureName)
	{
		foreach (TextureDatas2DToolkit toolkitSrite in Singleton<AtlasPreparer>.instance.toolkitSrites)
		{
			if (textureName == toolkitSrite.textureName)
			{
				Resources.UnloadAsset(toolkitSrite.material.mainTexture);
				toolkitSrite.material.mainTexture = null;
			}
		}
	}

	private static void Load2DToolkitTexture(TextureDatas2DToolkit atlas)
	{
		string textureName = atlas.textureName;
		Texture2D mainTexture = Resources.Load<Texture2D>("GUI/2Dtoolkit/" + textureName);
		atlas.material.mainTexture = mainTexture;
	}

	private static void UnLoad2DToolkitTexture(TextureDatas2DToolkit atlas)
	{
		if (atlas.material.mainTexture != null)
		{
			Resources.UnloadAsset(atlas.material.mainTexture);
			atlas.material.mainTexture = null;
		}
	}

	public void PrepareBuild()
	{
		if (mBuildPrepared)
		{
			return;
		}
		Debug.Log("AtlasPreparer - PREPARING BUILD");
		for (int i = 0; i < nGuiSpriteSheets.Count; i++)
		{
			Debug.Log("AtlasPreparer - WHITENING ATLAS " + nGuiSpriteSheets[i].atlas.name);
			nGuiSpriteSheets[i].atlas.spriteMaterial.mainTexture = nGuiSpriteSheets[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit toolkitSrite in toolkitSrites)
		{
			toolkitSrite.material.mainTexture = null;
		}
	}

	public void UnloadTutorial()
	{
		foreach (TextureDatasNgui nGuiSpriteSheet in nGuiSpriteSheets)
		{
			if (nGuiSpriteSheet.mode == AtlasMode.Tutorial)
			{
				Debug.Log("AtlasPreparer - CLEARING ATLAS " + nGuiSpriteSheet.atlas.name);
				Texture mainTexture = nGuiSpriteSheet.atlas.spriteMaterial.mainTexture;
				nGuiSpriteSheet.atlas.spriteMaterial.mainTexture = substitueTexture;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public void UnloadMissionMaps()
	{
		foreach (TextureDatasNgui nGuiSpriteSheet in nGuiSpriteSheets)
		{
			if (nGuiSpriteSheet.mode == AtlasMode.Map)
			{
				Debug.Log("AtlasPreparer - CLEARING ATLAS " + nGuiSpriteSheet.atlas.name);
				Texture mainTexture = nGuiSpriteSheet.atlas.spriteMaterial.mainTexture;
				nGuiSpriteSheet.atlas.spriteMaterial.mainTexture = substitueTexture;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public void LoadTextureForAtlas(TextureDatasNgui data)
	{
		UIAtlas atlas = data.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		if (!data.translate || (data.translate && data.language == language))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("Assets/StreamingAssets/", string.Empty).Replace(".png", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("GUI/" + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 1f;
			if (data.atlasReference != null)
			{
				data.atlasReference.replacement = data.atlas;
			}
		}
	}

	public IEnumerator LoadMenuClearGameCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Game)
			{
				Texture texture = textureDatasNgui.atlas.spriteMaterial.mainTexture;
				textureDatasNgui.atlas.spriteMaterial.mainTexture = substitueTexture;
				Resources.UnloadAsset(texture);
			}
		}
		foreach (TextureDatas2DToolkit textureDatas2DToolkit in toolkitSrites)
		{
			if (textureDatas2DToolkit.mode == AtlasMode.Game)
			{
				UnLoad2DToolkitTexture(textureDatas2DToolkit);
			}
		}
		yield return StartCoroutine(LoadMenuCoroutine());
	}

	public IEnumerator ClearMenuLoadGameCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Menu)
			{
				Texture texture = textureDatasNgui.atlas.spriteMaterial.mainTexture;
				textureDatasNgui.atlas.spriteMaterial.mainTexture = substitueTexture;
				Resources.UnloadAsset(texture);
			}
		}
		foreach (TextureDatas2DToolkit textureDatas2DToolkit in toolkitSrites)
		{
			if (textureDatas2DToolkit.mode == AtlasMode.Menu)
			{
				UnLoad2DToolkitTexture(textureDatas2DToolkit);
			}
		}
		yield return StartCoroutine(LoadGameCoroutine());
	}

	private IEnumerator LoadImagesCoroutine()
	{
		yield return StartCoroutine(LoadCommonCoroutine());
		yield return StartCoroutine(LoadMenuCoroutine());
	}

	public IEnumerator LoadCommonCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Both && textureDatasNgui.resourceMode == ResourceMode.Resource)
			{
				LoadTextureForAtlas(textureDatasNgui);
			}
		}
		foreach (TextureDatasNgui textureDatasNgui2 in nGuiSpriteSheets)
		{
			if (textureDatasNgui2.mode == AtlasMode.Both && textureDatasNgui2.resourceMode == ResourceMode.AssetBundle)
			{
				yield return StartCoroutine(LoadTextureForAtlasCoroutine(textureDatasNgui2.atlas));
			}
		}
	}

	public IEnumerator LoadTutorialCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Tutorial && textureDatasNgui.resourceMode == ResourceMode.Resource)
			{
				LoadTextureForAtlas(textureDatasNgui);
			}
		}
		foreach (TextureDatasNgui textureDatasNgui2 in nGuiSpriteSheets)
		{
			if (textureDatasNgui2.mode == AtlasMode.Tutorial && textureDatasNgui2.resourceMode == ResourceMode.AssetBundle)
			{
				yield return StartCoroutine(LoadTextureForAtlasCoroutine(textureDatasNgui2.atlas));
			}
		}
	}

	public IEnumerator LoadMissionMapsCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Map && textureDatasNgui.resourceMode == ResourceMode.Resource)
			{
				LoadTextureForAtlas(textureDatasNgui);
			}
		}
		foreach (TextureDatasNgui textureDatasNgui2 in nGuiSpriteSheets)
		{
			if (textureDatasNgui2.mode == AtlasMode.Map && textureDatasNgui2.resourceMode == ResourceMode.AssetBundle)
			{
				yield return StartCoroutine(LoadTextureForAtlasCoroutine(textureDatasNgui2.atlas));
			}
		}
	}

	public IEnumerator LoadMenuCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Menu && textureDatasNgui.resourceMode == ResourceMode.Resource)
			{
				LoadTextureForAtlas(textureDatasNgui);
			}
		}
		foreach (TextureDatasNgui textureDatasNgui2 in nGuiSpriteSheets)
		{
			if (textureDatasNgui2.mode == AtlasMode.Menu && textureDatasNgui2.resourceMode == ResourceMode.AssetBundle)
			{
				yield return StartCoroutine(LoadTextureForAtlasCoroutine(textureDatasNgui2.atlas));
			}
		}
		foreach (TextureDatas2DToolkit textureDatas2DToolkit in toolkitSrites)
		{
			if (textureDatas2DToolkit.mode == AtlasMode.Menu)
			{
				Load2DToolkitTexture(textureDatas2DToolkit);
			}
		}
	}

	public IEnumerator LoadGameCoroutine()
	{
		foreach (TextureDatasNgui textureDatasNgui in nGuiSpriteSheets)
		{
			if (textureDatasNgui.mode == AtlasMode.Game && textureDatasNgui.resourceMode == ResourceMode.Resource)
			{
				LoadTextureForAtlas(textureDatasNgui);
			}
		}
		foreach (TextureDatasNgui textureDatasNgui2 in Singleton<AtlasPreparer>.instance.nGuiSpriteSheets)
		{
			if (textureDatasNgui2.mode == AtlasMode.Game && textureDatasNgui2.resourceMode == ResourceMode.AssetBundle)
			{
				yield return StartCoroutine(LoadTextureForAtlasCoroutine(textureDatasNgui2.atlas));
			}
		}
		foreach (TextureDatas2DToolkit textureDatas2DToolkit in toolkitSrites)
		{
			if (textureDatas2DToolkit.mode == AtlasMode.Game)
			{
				Load2DToolkitTexture(textureDatas2DToolkit);
			}
		}
	}

	public IEnumerator LoadTextureForAtlasCoroutine(UIAtlas atlas)
	{
		Debug.Log("AtlasPreparer - LOADING ATLAS FOR " + Screen.height + "px :\n " + atlas.name);
		string path = atlas.pngPath;
		string assetBundle = "GUI/" + path;
		assetBundle = assetBundle.ToLower();
		AssetBundleReference assetBundleRef = Singleton<AssetBundleManager>.instance.GetReference(assetBundle);
		while (assetBundleRef == null || !assetBundleRef.cached)
		{
			if (assetBundleRef == null)
			{
				assetBundleRef = Singleton<AssetBundleManager>.instance.GetReference(assetBundle);
			}
			yield return null;
		}
		AssetBundleLoadAssetOperation op = Singleton<AssetBundleManager>.instance.LoadAssetAsync(assetBundle, atlas.pngPath, typeof(Texture2D));
		yield return StartCoroutine(op);
		Texture2D texture = op.GetAsset<Texture2D>();
		atlas.spriteMaterial.mainTexture = texture;
		AssetBundleManager.UnloadAssetBundle(assetBundle);
		atlas.pixelSize = 1f;
		yield return null;
	}
}

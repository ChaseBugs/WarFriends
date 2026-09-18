using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class AssetBundleManager : Singleton<AssetBundleManager>
{
	private const string AssetBundlesPath = "/AssetBundles/";

	public List<AssetBundleReference> assetBundleReferences;

	private Dictionary<string, AssetBundleReference> mAssetBundleReferencesDic = new Dictionary<string, AssetBundleReference>();

	private string mLocaDownloadingUrl = string.Empty;

	private string[] mVariants = new string[0];

	private AssetBundleManifest m_AssetBundleManifest;

	private readonly Dictionary<string, LoadedAssetBundle> m_LoadedAssetBundles = new Dictionary<string, LoadedAssetBundle>();

	private readonly Dictionary<string, WWW> mDownloadingWwWs = new Dictionary<string, WWW>();

	private readonly Dictionary<string, string> mDownloadingErrors = new Dictionary<string, string>();

	private readonly List<AssetBundleLoadOperation> mInProgressOperations = new List<AssetBundleLoadOperation>();

	private readonly Dictionary<string, string[]> mDependencies = new Dictionary<string, string[]>();

	private static readonly List<string> assetBundlesToLoad = new List<string>();

	private static readonly List<AssetBundleReference> assetBundlesToDownload = new List<AssetBundleReference>();

	private string mCdnDownloadingUrl;

	private float mTotalSizeToDownload;

	private float mDownloaded;

	private bool mErrorOk;

	public string locaDownloadingUrl
	{
		get
		{
			return mLocaDownloadingUrl;
		}
		set
		{
			mLocaDownloadingUrl = value;
		}
	}

	public string cdnDownloadningURL
	{
		get
		{
			return mCdnDownloadingUrl;
		}
		set
		{
			mCdnDownloadingUrl = value;
		}
	}

	public string[] variants
	{
		get
		{
			return mVariants;
		}
		set
		{
			mVariants = value;
		}
	}

	public AssetBundleManifest AssetBundleManifestObject
	{
		set
		{
			m_AssetBundleManifest = value;
		}
	}

	public event Action AssetsDownloaded;

	protected IEnumerator Initialize()
	{
		base.Start();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		string platformFolderForAssetBundles = GetPlatformFolderForAssetBundles(Application.platform);
		string version = Singleton<CurrentBundleVersion>.instance.version.Replace('.', '_');
		string localRelativePath = GetLocalrelativePath();
		locaDownloadingUrl = localRelativePath + "/AssetBundles/" + platformFolderForAssetBundles + "/";
		cdnDownloadningURL = "https://d1etscvp7v93h1.cloudfront.net/" + version + "/AssetBundles/" + platformFolderForAssetBundles + "/";
		AssetBundleLoadManifestOperation request = Initialize(platformFolderForAssetBundles);
		if (request != null)
		{
			yield return StartCoroutine(request);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.RegisterPlayerDataLoadedRoutine(CamosManager.instance.PrepareAssets);
		Singleton<BeanstalkServerManager>.instance.RegisterPlayerDataLoadedRoutine(GameConfigurationManager.instance.PrepareConfigurations);
		foreach (AssetBundleReference assetBundleReference in assetBundleReferences)
		{
			mAssetBundleReferencesDic[assetBundleReference.name] = assetBundleReference;
		}
	}

	public static LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName, out string error)
	{
		return Singleton<AssetBundleManager>.instance.GetLoadedAssetBundleInternal(assetBundleName, out error);
	}

	private LoadedAssetBundle GetLoadedAssetBundleInternal(string assetBundleName, out string error)
	{
		if (mDownloadingErrors.TryGetValue(assetBundleName, out error))
		{
			return null;
		}
		LoadedAssetBundle value = null;
		m_LoadedAssetBundles.TryGetValue(assetBundleName, out value);
		if (value == null)
		{
			return null;
		}
		string[] value2 = null;
		if (!mDependencies.TryGetValue(assetBundleName, out value2))
		{
			return value;
		}
		string[] array = value2;
		foreach (string key in array)
		{
			if (mDownloadingErrors.TryGetValue(assetBundleName, out error))
			{
				return value;
			}
			m_LoadedAssetBundles.TryGetValue(key, out var value3);
			if (value3 == null)
			{
				return null;
			}
		}
		return value;
	}

	public AssetBundleLoadManifestOperation Initialize(string manifestAssetBundleName)
	{
		LoadAssetBundle(manifestAssetBundleName, isLoadingAssetBundleManifest: true);
		AssetBundleLoadManifestOperation assetBundleLoadManifestOperation = new AssetBundleLoadManifestOperation(manifestAssetBundleName, "AssetBundleManifest", typeof(AssetBundleManifest));
		mInProgressOperations.Add(assetBundleLoadManifestOperation);
		return assetBundleLoadManifestOperation;
	}

	private bool IsAssetBundleCached(AssetBundleReference bundleName)
	{
		if (m_AssetBundleManifest == null)
		{
			return false;
		}
		Hash128 assetBundleHash = m_AssetBundleManifest.GetAssetBundleHash(bundleName.name);
		return Caching.IsVersionCached(bundleName.url, assetBundleHash);
	}

	public AssetBundleReference GetReference(string bundleName)
	{
		mAssetBundleReferencesDic.TryGetValue(bundleName, out var value);
		return value;
	}

	public IEnumerator DownloadAllNeededAssets()
	{
		Screen.sleepTimeout = -1;
		while (m_AssetBundleManifest == null)
		{
			yield return null;
		}
		MiscTools.PrintMemoryInfo();
		string[] allAssets = m_AssetBundleManifest.GetAllAssetBundles();
		Debug.Log($"AssetBundleManifest downloaded assets count: {allAssets.Length}");
		assetBundlesToLoad.Clear();
		assetBundlesToDownload.Clear();
		string[] array = allAssets;
		foreach (string assetBundle in array)
		{
			AssetBundleReference reference = GetReference(assetBundle);
			if (reference == null)
			{
				Debug.LogError("Please add " + assetBundle + " to AssetBundleManager");
			}
			if (reference != null && reference.shouldBeDownloaded && !reference.cached)
			{
				assetBundlesToLoad.Add(assetBundle);
			}
		}
		mTotalSizeToDownload = 0f;
		mDownloaded = 0f;
		for (int index = 0; index < assetBundlesToLoad.Count; index++)
		{
			string bundle = assetBundlesToLoad[index];
			AssetBundleReference reference2 = GetReference(bundle);
			if (index % 10 == 0)
			{
				yield return new WaitForSeconds(0.05f);
			}
			if (reference2 != null)
			{
				if (IsAssetBundleCached(reference2))
				{
					reference2.cached = true;
					continue;
				}
				mTotalSizeToDownload += reference2.size;
				assetBundlesToDownload.Add(reference2);
			}
		}
		MiscTools.PrintArray(assetBundlesToDownload, string.Empty);
		if (!PlayerAnalytics.instance.tutorialFinished)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("001 LOADING ASSETS STARTED");
		}
		for (int j = 0; j < assetBundlesToDownload.Count; j++)
		{
			LoadingDialog.SetText(Localization.LocalizeFormat("ID_DOWNLOADINGFILES", j + 1, assetBundlesToDownload.Count), changeToDownloading: true);
			AssetBundleReference bundle2 = assetBundlesToDownload[j];
			yield return Singleton<AssetBundleManager>.instance.StartCoroutine(PrepareAssetBundle(bundle2, j));
			yield return new WaitForSeconds(0.01f);
		}
		if (!PlayerAnalytics.instance.tutorialFinished)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("002 LOADING ASSETS FINISHED");
		}
		if (this.AssetsDownloaded != null)
		{
			this.AssetsDownloaded();
		}
		MiscTools.PrintMemoryInfo();
		Screen.sleepTimeout = -2;
	}

	protected void LoadAssetBundle(string assetBundleName, bool isLoadingAssetBundleManifest = false)
	{
		if (!isLoadingAssetBundleManifest)
		{
			assetBundleName = RemapVariantName(assetBundleName);
		}
		if (!LoadAssetBundleInternal(assetBundleName, isLoadingAssetBundleManifest) && !isLoadingAssetBundleManifest)
		{
			LoadDependencies(assetBundleName);
		}
	}

	private string RemapVariantName(string assetBundleName)
	{
		string[] allAssetBundlesWithVariant = m_AssetBundleManifest.GetAllAssetBundlesWithVariant();
		if (Array.IndexOf(allAssetBundlesWithVariant, assetBundleName) < 0)
		{
			return assetBundleName;
		}
		string[] array = assetBundleName.Split('.');
		int num = int.MaxValue;
		int num2 = -1;
		for (int i = 0; i < allAssetBundlesWithVariant.Length; i++)
		{
			string[] array2 = allAssetBundlesWithVariant[i].Split('.');
			if (!(array2[0] != array[0]))
			{
				int num3 = Array.IndexOf(mVariants, array2[1]);
				if (num3 != -1 && num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
		}
		if (num2 != -1)
		{
			return allAssetBundlesWithVariant[num2];
		}
		return assetBundleName;
	}

	private bool LoadAssetBundleInternal(string assetBundleName, bool isLoadingAssetBundleManifest)
	{
		AssetBundleReference reference = GetReference(assetBundleName);
		if ((reference == null || !reference.cached) && !isLoadingAssetBundleManifest)
		{
			Debug.LogError("Load assetBundle which is not cached !!!: " + assetBundleName);
			return true;
		}
		LoadedAssetBundle value = null;
		m_LoadedAssetBundles.TryGetValue(assetBundleName, out value);
		if (value != null)
		{
			value.m_ReferencedCount++;
			return true;
		}
		if (mDownloadingWwWs.ContainsKey(assetBundleName))
		{
			return true;
		}
		WWW wWW = null;
		string url = ((!isLoadingAssetBundleManifest) ? reference.url : (mLocaDownloadingUrl + assetBundleName));
		wWW = ((!isLoadingAssetBundleManifest) ? WWW.LoadFromCacheOrDownload(url, m_AssetBundleManifest.GetAssetBundleHash(assetBundleName), 0u) : new WWW(url));
		mDownloadingWwWs.Add(assetBundleName, wWW);
		return false;
	}

	private IEnumerator PrepareAssetBundle(AssetBundleReference assetBundleReference, int index)
	{
		if (!assetBundleReference.cached)
		{
			yield return Singleton<AssetBundleManager>.instance.StartCoroutine(DownloadAssetBundle(assetBundleReference, index, 0));
			assetBundleReference.cached = true;
		}
	}

	private IEnumerator DownloadAssetBundle(AssetBundleReference assetBundle, int index, int depth)
	{
		mErrorOk = false;
		WWW download = null;
		download = WWW.LoadFromCacheOrDownload(assetBundle.url, m_AssetBundleManifest.GetAssetBundleHash(assetBundle.name), 0u);
		while (!download.isDone)
		{
			float now = mDownloaded + download.progress * assetBundle.size;
			LoadingDialog.SetText(Localization.LocalizeFormat("ID_DOWNLOADINGFILES", now.ToString("0.00"), mTotalSizeToDownload.ToString("0.00")), changeToDownloading: true);
			yield return null;
		}
		if (download.error != null)
		{
			string error = download.error;
			Debug.LogError($"Downloading assetBundle {assetBundle.name} failed with error: {error}, depth: {depth}");
			download.Dispose();
			if (depth == 5)
			{
				WarningDialog.ShowError(Localization.LocalizeFormat("ID_WARNING_FAILDOWNLOADINGASSET", assetBundle.name, error), string.Empty, 0f, delegate
				{
					mErrorOk = true;
				}, string.Empty);
				while (!mErrorOk)
				{
					yield return null;
				}
				yield return Singleton<AssetBundleManager>.instance.StartCoroutine(DownloadAssetBundle(assetBundle, index, 0));
			}
			else
			{
				yield return Singleton<AssetBundleManager>.instance.StartCoroutine(DownloadAssetBundle(assetBundle, index, depth + 1));
			}
		}
		else
		{
			mDownloaded += assetBundle.size;
			download.Dispose();
		}
	}

	protected void LoadDependencies(string assetBundleName)
	{
		if (m_AssetBundleManifest == null)
		{
			Debug.LogError("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
			return;
		}
		string[] allDependencies = m_AssetBundleManifest.GetAllDependencies(assetBundleName);
		if (allDependencies.Length != 0)
		{
			for (int i = 0; i < allDependencies.Length; i++)
			{
				allDependencies[i] = RemapVariantName(allDependencies[i]);
			}
			mDependencies.Add(assetBundleName, allDependencies);
			for (int j = 0; j < allDependencies.Length; j++)
			{
				LoadAssetBundleInternal(allDependencies[j], isLoadingAssetBundleManifest: false);
			}
		}
	}

	public static void UnloadAssetBundle(string assetBundleName, bool destroyAssets = false)
	{
		Singleton<AssetBundleManager>.instance.UnloadAssetBundleInternal(assetBundleName, destroyAssets);
		Singleton<AssetBundleManager>.instance.UnloadDependencies(assetBundleName);
	}

	protected void UnloadDependencies(string assetBundleName)
	{
		string[] value = null;
		if (mDependencies.TryGetValue(assetBundleName, out value))
		{
			string[] array = value;
			foreach (string assetBundleName2 in array)
			{
				UnloadAssetBundleInternal(assetBundleName2);
			}
			mDependencies.Remove(assetBundleName);
		}
	}

	protected void UnloadAssetBundleInternal(string assetBundleName, bool destroyAssets = false)
	{
		string error;
		LoadedAssetBundle loadedAssetBundle = GetLoadedAssetBundle(assetBundleName, out error);
		if (loadedAssetBundle != null && --loadedAssetBundle.m_ReferencedCount == 0)
		{
			loadedAssetBundle.m_AssetBundle.Unload(destroyAssets);
			m_LoadedAssetBundles.Remove(assetBundleName);
		}
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, WWW> mDownloadingWwW in mDownloadingWwWs)
		{
			WWW value = mDownloadingWwW.Value;
			if (value.error != null)
			{
				mDownloadingErrors.Add(mDownloadingWwW.Key, value.error);
				list.Add(mDownloadingWwW.Key);
				Debug.LogError($"Downloading assetBundle {mDownloadingWwW.Key} failed with error: {value.error}");
			}
			else if (value.isDone)
			{
				m_LoadedAssetBundles.Add(mDownloadingWwW.Key, new LoadedAssetBundle(value.assetBundle));
				list.Add(mDownloadingWwW.Key);
			}
		}
		foreach (string item in list)
		{
			WWW wWW = mDownloadingWwWs[item];
			mDownloadingWwWs.Remove(item);
			wWW.Dispose();
		}
		int num = 0;
		while (num < mInProgressOperations.Count)
		{
			if (!mInProgressOperations[num].Update())
			{
				mInProgressOperations.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
	}

	public static T LoadAssetImmediately<T>(string assetBundlePath) where T : UnityEngine.Object
	{
		int num = assetBundlePath.LastIndexOf('/');
		string assetBundleName = assetBundlePath.ToLower().Substring(0, num);
		string assetName = assetBundlePath.Substring(num + 1);
		return LoadAssetImmediately<T>(assetBundleName, assetName);
	}

	public static T LoadAssetImmediately<T>(string assetBundleName, string assetName) where T : UnityEngine.Object
	{
		Debug.LogError("ONLY EDITOR FEATURE");
		return (T)null;
	}

	public static AssetBundleLoadAssetOperation LoadAssetAsync(string assetBundlePath, Type type)
	{
		int num = assetBundlePath.LastIndexOf('/');
		string assetBundleName = assetBundlePath.ToLower().Substring(0, num);
		string assetName = assetBundlePath.Substring(num + 1);
		return Singleton<AssetBundleManager>.instance.LoadAssetAsync(assetBundleName, assetName, type);
	}

	public AssetBundleLoadAssetOperation LoadAssetAsync(string assetBundleName, string assetName, Type type)
	{
		AssetBundleLoadAssetOperation assetBundleLoadAssetOperation = null;
		AssetBundleReference reference = GetReference(assetBundleName);
		if (reference == null || !reference.cached)
		{
			Debug.LogError("Load assetBundle which is not cached !!!: " + assetBundleName);
			return new AssetBundleLoadAssetOperationSimulation(null);
		}
		LoadAssetBundle(assetBundleName);
		assetBundleLoadAssetOperation = new AssetBundleLoadAssetOperationFull(assetBundleName, assetName, type);
		mInProgressOperations.Add(assetBundleLoadAssetOperation);
		return assetBundleLoadAssetOperation;
	}

	public static AssetBundleLoadOperation LoadLevelAsync(string assetBundleName, string levelName)
	{
		return Singleton<AssetBundleManager>.instance.LoadLevelAsyncInternal(assetBundleName, levelName);
	}

	private AssetBundleLoadOperation LoadLevelAsyncInternal(string assetBundleName, string levelName)
	{
		AssetBundleLoadOperation assetBundleLoadOperation = null;
		LoadAssetBundle(assetBundleName);
		assetBundleLoadOperation = new AssetBundleLoadLevelOperation(assetBundleName, levelName);
		mInProgressOperations.Add(assetBundleLoadOperation);
		return assetBundleLoadOperation;
	}

	public string GetLocalrelativePath()
	{
		if (Application.isEditor)
		{
			return "file://" + Environment.CurrentDirectory.Replace("\\", "/");
		}
		if ((Application.platform == (RuntimePlatform)5 || Application.platform == (RuntimePlatform)3))
		{
			return Path.GetDirectoryName(Application.absoluteURL).Replace("\\", "/") + "/StreamingAssets";
		}
		if (Application.platform == RuntimePlatform.Android || Application.isConsolePlatform)
		{
			return Application.streamingAssetsPath;
		}
		return "file://" + Application.streamingAssetsPath;
	}

	private static string GetPlatformFolderForAssetBundles(RuntimePlatform platform)
	{
		switch (platform)
		{
		case RuntimePlatform.Android:
			return "Android";
		case RuntimePlatform.IPhonePlayer:
			return "iOS";
		case (RuntimePlatform)3:
		case (RuntimePlatform)5:
			return "WebPlayer";
		case RuntimePlatform.WindowsPlayer:
			return "Windows";
		case RuntimePlatform.OSXPlayer:
			return "OSX";
		default:
			return null;
		}
	}
}

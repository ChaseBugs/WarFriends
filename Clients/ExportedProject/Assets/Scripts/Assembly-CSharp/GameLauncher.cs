using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class GameLauncher : Core_BaseScript
{
	[Serializable]
	public class LogoScale
	{
		public int width;

		public int height;

		public float scale = 1f;
	}

	public GameObject chillingoLogo;

	public GameObject ourLogo;

	public UIAtlas splashes;

	public DownloadAssetsDialog downloadAssetsDialog;

	public bool downloadOBB;

	private AsyncOperation mAsync;

	public GameObject logo;

	public Camera splashCamera;

	public List<LogoScale> scales;

	protected override void Awake()
	{
		ObscuredPrefs.SetNewCryptoKey("CX6896566GD");
		base.Awake();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		foreach (LogoScale scale in scales)
		{
			if (Screen.width == scale.width && Screen.height == scale.height)
			{
				logo.transform.parent.localScale = new Vector3(scale.scale, scale.scale, 1f);
			}
		}
		StartCoroutine(ChangeSplashes());
	}

	private IEnumerator ChangeSplashes()
	{
		ourLogo.gameObject.SetActive(value: false);
		chillingoLogo.gameObject.SetActive(value: true);
		yield return new WaitForSeconds(1f);
		StartCoroutine(LoadMainScene());
		yield return new WaitForSeconds(2f);
		chillingoLogo.gameObject.SetActive(value: false);
		ourLogo.gameObject.SetActive(value: true);
		yield return new WaitForSeconds(1f);
		// Bundled assets and scene loading own startup; retired provider callbacks cannot gate activation.
		while (mAsync == null)
		{
			yield return null;
		}
		Debug.Log("Loading:  mAsync.allowSceneActivation = true");
		mAsync.allowSceneActivation = true;
	}

	private IEnumerator LoadMainScene()
	{
		// APK+OBB recovery already placed these assets in the Unity project. Keep downloadOBB serialized
		// for scene compatibility, but never contact Google Play or request storage permission to boot.
		Application.backgroundLoadingPriority = ThreadPriority.High;
		mAsync = Application.LoadLevelAsync("MainScene");
		mAsync.allowSceneActivation = false;
		yield return mAsync;
		UnityEngine.Object.Destroy(splashCamera.gameObject);
		Debug.Log("Main sceneLoaded");
		yield return null;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform tr = base.transform.GetChild(i);
			tr.gameObject.SetActive(value: false);
		}
		ourLogo.gameObject.SetActive(value: false);
		Resources.UnloadAsset(splashes.texture);
		yield return null;
		yield return null;
		yield return null;
		UnityEngine.Object.Destroy(base.gameObject);
	}

}

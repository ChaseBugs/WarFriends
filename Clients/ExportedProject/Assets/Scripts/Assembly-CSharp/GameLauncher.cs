using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Beebyte.Obfuscator;
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

	private string mExpPath;

	private string mMainPath;

	private bool mExtraPermissionGranted;

	private bool gcInit;

	private bool googlePlayInit;

	public GameObject logo;

	public Camera splashCamera;

	public List<LogoScale> scales;

	private bool mTermsShown;

	private bool mTermsCriteriaMet;

	protected override void Awake()
	{
		ObscuredPrefs.SetNewCryptoKey("CX6896566GD");
		base.Awake();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		InitTerms();
		Singleton<GameCenterProvider>.instance.Authenticated += OnGcAuthenticated;
		Singleton<GooglePlayGameService>.instance.LoggedInFromInit += OnGooglePlayAuthenticated;
		foreach (LogoScale scale in scales)
		{
			if (Screen.width == scale.width && Screen.height == scale.height)
			{
				logo.transform.parent.localScale = new Vector3(scale.scale, scale.scale, 1f);
			}
		}
		StartCoroutine(ChangeSplashes());
	}

	protected override void Start()
	{
		base.Start();
		Debug.Log("Chillingo: Start");
	}

	private void InitTerms()
	{
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "GameLaunch", "OnAgeVerificationCriteriaMet");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_NOT_MET, "GameLaunch", "OnAgeVerificationCriteriaNotMet");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.PENDING_DIALOG_DISPLAY, "GameLaunch", "OnAgeVerificationPendingDisplayed");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.COUNTRY_IS_REAL_NAME_SENSITIVE, "GameLaunch", "OnAgeVerificationRealNameSensitive");
		Terms.initialiseTermsSession(preCOPPA: false, useCustomSkin: false, Terms.ComplianceLevel.FULLY_COMPLIANT_ADULT_CONTENT, isChinaOnly: false);
	}

	[SkipRename]
	private void OnGcAuthenticated(bool isAuthenticated)
	{
		gcInit = true;
	}

	[SkipRename]
	private void OnGooglePlayAuthenticated(bool successs)
	{
		googlePlayInit = true;
	}

	[SkipRename]
	private void OnAgeVerificationPendingDisplayed(string str)
	{
		Debug.Log("Chillingo: On Age Verification Pending Dialog Display " + str);
		ShowTerms();
	}

	[SkipRename]
	private void OnAgeVerificationRealNameSensitive(string str)
	{
		Debug.Log("Chillingo: On Age Verification Country Is Real Name Sensitive " + str);
	}

	[SkipRename]
	private void OnAgeVerificationCriteriaMet(string str)
	{
		mTermsCriteriaMet = true;
		Debug.Log("Chillingo: On Age Verification Criteria Met " + str);
		Singleton<GooglePlayGameService>.instance.Init();
		InvokeAfter(delegate
		{
			Singleton<GameCenterProvider>.instance.Authenticate();
		}, (!mTermsShown) ? 0.5f : 3f);
		if (ObjectHolderOnSceneChange.instance != null)
		{
			FuseSDK.StartSession();
		}
	}

	[SkipRename]
	private void OnAgeVerificationCriteriaNotMet(string str)
	{
		Debug.Log("Chillingo: On Age Verification Criteria Not Met " + str);
	}

	private void ShowTerms()
	{
		Debug.Log("Show Terms");
		Terms.showTermsUI();
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
		while (!mTermsCriteriaMet)
		{
			yield return null;
		}
		float mTimeOutTime = Time.realtimeSinceStartup + 15f;
		float timeout = Time.realtimeSinceStartup + 5f;
		while (!googlePlayInit)
		{
			if (Time.realtimeSinceStartup > timeout)
			{
				Exception e = new Exception("Google Play Time out");
				Crittercism.LogHandledException(e);
				break;
			}
			yield return new WaitForSeconds(0.1f);
		}
		while (mAsync == null)
		{
			yield return null;
		}
		Debug.Log("Loading:  mAsync.allowSceneActivation = true");
		mAsync.allowSceneActivation = true;
	}

	private IEnumerator LoadMainScene()
	{
		if (downloadOBB)
		{
			mExpPath = GooglePlayDownloader.GetExpansionFilePath();
			mMainPath = GooglePlayDownloader.GetMainOBBPath(mExpPath);
			Debug.LogWarningFormat("OBB: Looking for file Exp '{0}' Main '{1}'", mExpPath ?? "null", mMainPath ?? "null");
			if (mMainPath != null)
			{
				mExtraPermissionGranted = true;
				try
				{
					FileStream fileStream = File.OpenRead(mMainPath);
					long numBytes = ((10 <= fileStream.Length) ? fileStream.Length : 10);
					if (numBytes > 0)
					{
						byte[] buffer = new byte[numBytes];
						int bytesRead = fileStream.Read(buffer, 0, (int)numBytes);
						Debug.LogWarning("OBB: Read Test - Bytes read " + bytesRead);
					}
					else
					{
						Debug.LogWarning("OBB: Read Test - No data to read!");
					}
				}
				catch (Exception ex)
				{
					Exception ex2 = ex;
					Debug.LogWarning("OBB: Read Test - Exception Caught\n" + ex2.ToString());
					mExtraPermissionGranted = false;
				}
				if (!mExtraPermissionGranted)
				{
					downloadAssetsDialog.Show();
					downloadAssetsDialog.SetPermissionTexts();
					while (!downloadAssetsDialog.result.HasValue)
					{
						yield return null;
					}
					if (downloadAssetsDialog.result.Value)
					{
						NoodlePermissionGranter.PermissionRequestCallback += OnPermissionRequestWithObbCallback;
						NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
						while (!mExtraPermissionGranted)
						{
							yield return null;
						}
					}
					else
					{
						Application.Quit();
					}
				}
			}
			if (mMainPath == null)
			{
				downloadAssetsDialog.Show();
				downloadAssetsDialog.SetDownloadTexts();
				while (!downloadAssetsDialog.result.HasValue)
				{
					yield return null;
				}
				if (downloadAssetsDialog.result.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += OnPermissionRequestCallback;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					yield return new WaitForRealSeconds(0.5f);
					downloadAssetsDialog.Show();
					downloadAssetsDialog.SetReallyDontDownloadTexts();
					while (!downloadAssetsDialog.result.HasValue)
					{
						yield return null;
					}
					if (downloadAssetsDialog.result.Value)
					{
						NoodlePermissionGranter.PermissionRequestCallback += OnPermissionRequestCallback;
						NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					}
					else
					{
						Application.Quit();
					}
				}
				while (mMainPath == null)
				{
					mMainPath = GooglePlayDownloader.GetMainOBBPath(mExpPath);
					yield return null;
				}
			}
			Debug.Log("Start loading www: " + DateTime.UtcNow);
		}
		Debug.Log("Start loading scene: " + DateTime.UtcNow);
		Application.backgroundLoadingPriority = ThreadPriority.High;
		mAsync = Application.LoadLevelAsync("MainScene");
		mAsync.allowSceneActivation = false;
		yield return mAsync;
		UnityEngine.Object.Destroy(splashCamera.gameObject);
		Singleton<GameCenterProvider>.instance.canLogoutEventLikeLoginFailed = true;
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

	private void OnPermissionRequestWithObbCallback(bool permissionGranted)
	{
		if (permissionGranted)
		{
			mExtraPermissionGranted = true;
		}
		else
		{
			StartCoroutine(RetryPermissionRequestOrExit());
		}
	}

	private void OnPermissionRequestCallback(bool permissionGranted)
	{
		Debug.Log("OnPermissionRequestCallback granted: " + permissionGranted);
		if (permissionGranted)
		{
			Debug.Log("Fetching OBB");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(RetryPermissionRequestOrExit());
		}
	}

	private IEnumerator RetryPermissionRequestOrExit()
	{
		downloadAssetsDialog.Show();
		downloadAssetsDialog.SetRetryOrExitTexts();
		while (!downloadAssetsDialog.result.HasValue)
		{
			yield return null;
		}
		if (downloadAssetsDialog.result.Value)
		{
			NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
		}
		else
		{
			Application.Quit();
		}
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			Debug.Log("Terms: OnApplicationPause close session");
			Terms.closeTermsSession();
		}
		else
		{
			Debug.Log("Terms: OnApplicationPause InitTerms");
			InitTerms();
		}
	}
}

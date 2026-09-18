using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingDialog : GuiElementSingle<LoadingDialog>
{
	public Action cancelClicked;

	[Header("Big Bottom")]
	public GameObject bigLook;

	[Header("-Center Title")]
	public UILabel loadingTitle;

	[Header("-Moving Sprite")]
	public UISprite loadingSprite;

	public TweenPosition positionTweener;

	[Header("-Bottom Text")]
	public UILabel loadingText;

	public TweenAlpha alphaTweener;

	[Header("Small Bottom")]
	public GameObject smallLook;

	[Header("-Center Title")]
	public UILabel loadingTitleSmallLook;

	[Header("-Moving Sprite")]
	public UISprite loadingSpriteSmallLook;

	public TweenPosition positionTweenerSmallLook;

	[Header("-Bottom Text")]
	public UILabel loadingTextSmallLook;

	public TweenAlpha alphaTweenerSmallLook;

	[Header("Bottom Button")]
	public UIButton loadingCancelButton;

	private RadicalRoutine mChangeHint;

	private int mMaxHint = 35;

	private string mLoadingTitle;

	private string mLoadingText;

	public bool isSmallLook { get; private set; }

	public string title
	{
		set
		{
			mLoadingTitle = value;
			if (bigLook.gameObject.activeSelf)
			{
				loadingTitle.text = value;
			}
			if (smallLook.gameObject.activeSelf)
			{
				loadingTitleSmallLook.text = mLoadingTitle + ((!string.IsNullOrEmpty(mLoadingText)) ? ("[FFFFFF] (" + mLoadingText + ")") : string.Empty);
			}
		}
	}

	public string loading
	{
		set
		{
			mLoadingText = value;
			if (bigLook.gameObject.activeSelf)
			{
				loadingText.text = value;
			}
			if (smallLook.gameObject.activeSelf)
			{
				loadingTextSmallLook.text = string.Empty;
				loadingTitleSmallLook.text = mLoadingTitle + ((!string.IsNullOrEmpty(mLoadingText)) ? ("[FFFFFF] (" + mLoadingText + ")") : string.Empty);
			}
		}
	}

	public static void SetLook(bool smallLook)
	{
		Debug.Log("Loading Dialog: Set look:" + smallLook);
		GuiElementSingle<LoadingDialog>.instance.smallLook.SetActive(smallLook);
		GuiElementSingle<LoadingDialog>.instance.bigLook.SetActive(!smallLook);
	}

	public static LoadingDialog ShowLoading(string title, bool showCancelButton = false, bool hideBackgroundElements = false, bool showInstantly = false)
	{
		Debug.Log($"Loading Dialog: Show loading dialog: {title} First Run:{Singleton<GameController>.instance.isFirstLoadingOfWarfriends} Time: {Time.realtimeSinceStartup}");
		GuiElementSingle<LoadingDialog>.instance.StopAllCoroutines();
		LoadingDialog loadingDialog = GuiElementSingle<LoadingDialog>.instance;
		loadingDialog.TurnOnShowingHints();
		loadingDialog.title = title;
		loadingDialog.loadingCancelButton.gameObject.SetActive(showCancelButton);
		loadingDialog.cancelClicked = null;
		if (hideBackgroundElements)
		{
			if (Singleton<GuiManager>.instance.currentScreen != null && Singleton<GuiManager>.instance.currentScreen.isShowed)
			{
				Singleton<GuiManager>.instance.HideGui(Singleton<GuiManager>.instance.currentScreen);
			}
			if (GuiElementSingle<Background>.instance.gameObject.activeSelf)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<Background>.instance);
			}
			if (GuiElementSingle<MenuHeader>.instance.gameObject.activeSelf)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<MenuHeader>.instance);
			}
			if (GuiElementSingle<HeaderLeagueButton>.instance.gameObject.activeSelf)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<HeaderLeagueButton>.instance);
			}
			if (GuiElementSingle<HeaderTicketsButton>.instance.gameObject.activeSelf)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<HeaderTicketsButton>.instance);
			}
			if (GuiElementSingle<HeaderDogtagButton>.instance.gameObject.activeSelf)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<HeaderDogtagButton>.instance);
			}
			if (GuiElementSingle<ChatGuiElement>.instance.gameObject.activeSelf)
			{
				Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<ChatGuiElement>.instance);
			}
		}
		if (!loadingDialog.isShowed)
		{
			if (showInstantly)
			{
				Singleton<GuiManager>.instance.ShowDialogInstant(loadingDialog);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(loadingDialog, 0f);
			}
		}
		loadingDialog.HideOtherDialogs();
		return loadingDialog;
	}

	public static void SetText(string text, bool changeToDownloading = false)
	{
		GuiElementSingle<LoadingDialog>.instance.TurnOffShowingHints();
		GuiElementSingle<LoadingDialog>.instance.loading = text;
		if (changeToDownloading)
		{
			GuiElementSingle<LoadingDialog>.instance.title = Localization.Localize("ID_DOWNLOADING");
		}
	}

	public static void SetHeader(string textHeader)
	{
		GuiElementSingle<LoadingDialog>.instance.title = textHeader;
	}

	public static void Hide()
	{
		Debug.Log("Loading Dialog: Hiding - Time: " + Time.realtimeSinceStartup);
		if (GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			GuiElementSingle<LoadingDialog>.instance.HideDialog();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(loadingCancelButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CancelClick));
		float num = UIRoot.list[0].activeWidth / 2f + loadingSprite.transform.localScale.x / 2f;
		positionTweener.from = new Vector3(0f - num, 248f, 0f);
		positionTweener.to = new Vector3(num, 248f, 0f);
		positionTweenerSmallLook.from = new Vector3(0f - num, 150f, 0f);
		positionTweenerSmallLook.to = new Vector3(num, 150f, 0f);
	}

	private void CancelClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Debug.Log("Loading Dialog: Cancel Clicked");
			GuiScreenSingle<CardSelectionScreen>.instance.CancelClickedInLoadingDialog();
			HideDialog();
			if (cancelClicked != null)
			{
				cancelClicked();
				cancelClicked = null;
			}
		}
	}

	public override void InitGUIValues()
	{
		positionTweener.Reset();
		positionTweenerSmallLook.Reset();
		if (mChangeHint != null)
		{
			StartCoroutine(RadicalRoutine.Run(mChangeHint.enumerator));
		}
	}

	private void TurnOnShowingHints()
	{
		if (Singleton<GameController>.instance.isFirstLoadingOfWarfriends)
		{
			TurnOffShowingHints();
		}
		else if (mChangeHint == null)
		{
			loading = string.Empty;
			loadingText.alpha = 1f;
			alphaTweener.enabled = true;
			alphaTweener.from = 1f;
			alphaTweener.to = 1f;
			SetNewRandomHint();
			StartCoroutine();
		}
	}

	private void SetNewRandomHint()
	{
		int num = UnityEngine.Random.Range(1, mMaxHint + 1);
		string text = "ID_HINT" + num;
		List<int> list = new List<int>();
		list.Add(16);
		list.Add(17);
		list.Add(18);
		list.Add(34);
		if (list.Contains(num))
		{
			text += "A";
		}
		if (bigLook.activeSelf)
		{
			loading = Localization.Localize(text);
		}
	}

	private void StartCoroutine()
	{
		mChangeHint = RadicalRoutine.Create(ChangeHint());
	}

	private void StopCoroutine()
	{
		if (mChangeHint != null)
		{
			mChangeHint.Cancel();
		}
		mChangeHint = null;
	}

	private IEnumerator ChangeHint()
	{
		while (true)
		{
			yield return new WaitForSeconds(6f);
			alphaTweener.Reset();
			alphaTweener.from = 1f;
			alphaTweener.to = 0f;
			yield return new WaitForSeconds(0.3f);
			SetNewRandomHint();
			alphaTweener.Reset();
			alphaTweener.from = 0f;
			alphaTweener.to = 1f;
			yield return new WaitForSeconds(0.3f);
		}
	}

	private void TurnOffShowingHints()
	{
		alphaTweener.enabled = false;
		loadingText.alpha = 1f;
		loading = string.Empty;
		StopCoroutine();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (GuiElementSingle<DialogCompareUnits>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.FadeOut(GuiElementSingle<DialogCompareUnits>.instance);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		StopCoroutine();
		SetLook(smallLook: false);
	}

	private void HideOtherDialogs()
	{
		if (GuiElementSingle<CantPauseDialog>.instance.isShowed)
		{
			GuiElementSingle<CantPauseDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Can't Pause\" to show loading");
		}
		if (GuiElementSingle<ReconnectDialog>.instance.isShowed)
		{
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Reconnect\" to show loading");
		}
		if (GuiElementSingle<EnableNotificationsDialog>.instance.isShowed)
		{
			GuiElementSingle<EnableNotificationsDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Enable Notifications\" to show loading");
		}
		if (GuiElementSingle<EnableNotificationsInSystemDialog>.instance.isShowed)
		{
			GuiElementSingle<EnableNotificationsInSystemDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Enable Notifications In System\" to show loading");
		}
		if (GuiElementSingle<FacebookDialog>.instance.isShowed)
		{
			GuiElementSingle<FacebookDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Facebook\" to show loading");
		}
		if (GuiElementSingle<IncreaseSquadRankDialog>.instance.isShowed)
		{
			GuiElementSingle<IncreaseSquadRankDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Increase Squad Rank\" to show loading");
		}
		if (GuiElementSingle<NotEnoughDialog>.instance.isShowed)
		{
			GuiElementSingle<NotEnoughDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Not Enough\" to show loading");
		}
		if (GuiElementSingle<PlayerProfileDialog>.instance.isShowed)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Player Profile\" to show loading");
		}
		if (GuiElementSingle<CreditsDialog>.instance.isShowed)
		{
			GuiElementSingle<CreditsDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Settings - Credits\" to show loading");
		}
		if (GuiElementSingle<LanguageDialog>.instance.isShowed)
		{
			GuiElementSingle<LanguageDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Settings - Language\" to show loading");
		}
		if (GuiElementSingle<PrivacyDialog>.instance.isShowed)
		{
			GuiElementSingle<PrivacyDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Settings - Privacy\" to show loading");
		}
		if (GuiElementSingle<RenameDialog>.instance.isShowed)
		{
			GuiElementSingle<RenameDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Settings - Rename\" to show loading");
		}
		if (GuiElementSingle<SquadDetailsDialog>.instance.isShowed)
		{
			GuiElementSingle<SquadDetailsDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Squad Details\" to show loading");
		}
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			GuiElementSingle<WaitingDialog>.instance.HideDialog();
			Debug.LogWarning("Loading Dialog: Hiding Game Dialog \"Waiting\" to show loading");
		}
	}

	public override void OnBack()
	{
		if (loadingCancelButton.gameObject.activeSelf)
		{
			CancelClick(loadingCancelButton.gameObject);
		}
	}
}

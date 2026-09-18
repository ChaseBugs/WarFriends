using System;
using UnityEngine;

public class DogtagDialog : GuiElementSingle<DogtagDialog>, IGuiDialog
{
	[Header("Shared")]
	public GameObject closeButton;

	public UILabel header;

	public UISprite background;

	[Header("Full Dogtags")]
	public GameObject fullVersionPart;

	public UILabel description_full;

	public GameObject okButton;

	public GameObject becomeVIPButton;

	[Header("Need Dogtags")]
	public GameObject refillingVersionPart;

	public UILabel description;

	public WinStreakCounter counter;

	public UILabel prizeLabel;

	[Header("-Refill Button")]
	public GameObject reffilButton;

	public GameObject refillButtonOverlay;

	public GameObject cannotPressButton;

	[Header("-Watch Video Button")]
	public GameObject watchVideoButton;

	public UISprite freeBackground;

	public UILabel freeLabel;

	public UILabel dogTagLabel;

	public UILabel watchVideoLabel;

	public UISprite watchVideoBorder;

	public GameObject cannotPressButtonVideo;

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += OnRewardVideoPreloaded;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += OnRewardVideoPreloaded;
		Singleton<VipManager>.instance.VipStatusChanged += OnVIPChanged;
		DogTagManager dogTagManager = Singleton<DogTagManager>.instance;
		dogTagManager.DogtagServerUpdate = (Action)Delegate.Combine(dogTagManager.DogtagServerUpdate, new Action(OnDogtagServerUpdate));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(reffilButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(RefillButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(watchVideoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(WatchVideoButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(closeButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener4 = UIEventListener.Get(okButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener5 = UIEventListener.Get(becomeVIPButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BecomeVIPClick));
		SetSizesOfFreeDogtag();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			if (action == DatabaseAction.RefillDogtags || action == DatabaseAction.AddVideoReward)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
				InitGUIValues();
			}
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (isShowed)
		{
			if (action == DatabaseAction.RefillDogtags || action == DatabaseAction.AddVideoReward)
			{
				InitGUIValues();
			}
		}
	}

	private void OnRewardVideoPreloaded()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void OnVIPChanged(bool vipStatus)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void OnDogtagServerUpdate()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void InstanceOnDogtagsChanged(int dogtags)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void RefillButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (Singleton<DogTagManager>.instance.isFull)
			{
				HideDialog();
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL"), Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL_TEXT"), fadeOutTime);
			}
			else if (Singleton<Wallet>.instance.CanBuyGold(Singleton<DogTagManager>.instance.dogtagRefillPrice))
			{
				Singleton<PurchaseProtection>.instance.RefillingDogtags();
				refillButtonOverlay.SetActive(Singleton<PurchaseProtection>.instance.dogtagRefillInProgress);
				Singleton<BeanstalkServerManager>.instance.RefillDogtags();
			}
			else
			{
				HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(Singleton<DogTagManager>.instance.dogtagRefillPrice, Localization.Localize("ID_DOGTAGSREFILL"));
				GuiElementSingle<InappScreen>.instance.routeToStore = "DogTags";
			}
		}
	}

	private void WatchVideoButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.ShowRewardedVideo(RewardType.Dogtag);
			HideDialog();
		}
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void BecomeVIPClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	private void SetSizesOfFreeDogtag()
	{
		freeBackground.transform.localScale = new Vector3(freeLabel.relativeSize.x * freeLabel.transform.localScale.x + 2f, 48f, 1f);
		dogTagLabel.transform.localPosition = new Vector3(-434f + freeBackground.transform.localScale.x, 6f, dogTagLabel.transform.localPosition.z);
		watchVideoLabel.text = Localization.Localize("ID_WATCHVIDEO");
		MiscTools.SetUILabelRescale(watchVideoLabel, 42f, 20f, 340);
		watchVideoBorder.transform.localScale = new Vector3(watchVideoLabel.relativeSize.x * watchVideoLabel.transform.localScale.x + 30f, 82f, 1f);
	}

	public override void InitGUIValues()
	{
		bool flag = Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CardSelectionScreen>.instance;
		bool isFull = Singleton<DogTagManager>.instance.isFull;
		bool isEmpty = Singleton<DogTagManager>.instance.isEmpty;
		bool flag2 = Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.Dogtag);
		float y = ((!isFull && flag2) ? 960f : 820f);
		int num = Singleton<DogTagManager>.instance.remainingTimeForNextDogtag;
		if (num == 0)
		{
			num = Singleton<DogTagManager>.instance.timeToGetDogtag;
		}
		background.transform.localScale = new Vector3(background.transform.localScale.x, y, 1f);
		fullVersionPart.SetActive(isFull);
		refillingVersionPart.SetActive(!isFull);
		if (isFull)
		{
			bool flag3 = Singleton<VipManager>.instance.IsVipActive();
			header.text = Localization.Localize("ID_DOGTAGSFULL");
			description.text = Localization.Localize((!flag3) ? "ID_YOURDOGTAGSAREFULLNOTVIP" : "ID_YOURDOGTAGSAREFULLMOVEALONG");
			description_full.text = description.text;
			becomeVIPButton.SetActive(!flag3);
			okButton.transform.localPosition = okButton.transform.localPosition.ReplaceX((!flag3) ? (-347f) : 0f);
		}
		else
		{
			prizeLabel.text = MiscTools.FormatBigNumber(Singleton<DogTagManager>.instance.dogtagRefillPrice);
			watchVideoButton.SetActive(flag2);
			refillButtonOverlay.SetActive(Singleton<PurchaseProtection>.instance.dogtagRefillInProgress);
			cannotPressButton.SetActive(flag);
			cannotPressButtonVideo.SetActive(flag && flag2);
			if (isEmpty)
			{
				header.text = Localization.Localize("ID_DOGTAGSREQUIRED");
				description.text = Localization.Localize("ID_YOUNEEDATLEASTONEDOGTAGTOPLAY");
				description_full.text = description.text;
			}
			else
			{
				header.text = Localization.Localize("ID_DOGTAGS");
				description.text = Localization.Localize("ID_WAITFORDOGTAGTOREFILL");
				description_full.text = description.text;
			}
		}
		if (num > 0 && !isFull)
		{
			counter.StartCounter(num);
			WinStreakCounter winStreakCounter = counter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(InitGUIValues));
			WinStreakCounter winStreakCounter2 = counter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(InitGUIValues));
		}
		else
		{
			counter.StopCounter();
			WinStreakCounter winStreakCounter3 = counter;
			winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(InitGUIValues));
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		counter.StopCounter();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIDraggablePanel.panelDisabled = true;
		TweenAlpha.Begin(refillButtonOverlay, 0.1f, 1f, 1f);
	}

	protected void OnApplicationPause(bool pause)
	{
		if (!pause)
		{
			counter.StopCounter();
			InitGUIValues();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton);
	}
}

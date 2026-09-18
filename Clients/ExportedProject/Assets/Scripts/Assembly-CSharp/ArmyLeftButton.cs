using System;
using UnityEngine;

public class ArmyLeftButton : Core_BaseScript
{
	[Header("Core")]
	public GameObject leftButton;

	public UISprite background;

	public BoxCollider backgroundCollider;

	public ArmyPowerAnimation armyPowerAnimation;

	public UITable promoteHintTable;

	public UILabel promoteHintText;

	public UISprite[] promoteHintStars;

	public UILabel deliveredHintText;

	[Header("-Empty")]
	public GameObject leftButtonEmptyPart;

	public UILabel leftButtonEmptyLabel;

	[Header("-Rented")]
	public GameObject leftButtonRentedPart;

	public UILabel leftButtonRentedLabel;

	[Header("-Upgrade")]
	public UIPanel leftButtonUpgradePanel;

	public GameObject leftButtonUpgradePart;

	public UILabel leftButtonUpgradeLabel;

	[Header("-Deliver now")]
	public UIPanel leftButtonDeliverNowPanel;

	public GameObject leftButtonDeliverNowPart;

	public UILabel leftButtonDeliverNowTimeLabel;

	public UILabel leftButtonDeliverNowInfoLabel;

	public UISprite leftButtonDeliverNowProgressBar;

	public UITable leftButtonDeliverNowPrizeTable;

	public UILabel leftButtonDeliverNowPrizeLabel;

	[Header("-Activate")]
	public UIPanel leftButtonActivatePanel;

	public GameObject leftButtonActivatePart;

	[Header("-Close")]
	public UIPanel leftButtonClosePanel;

	public GameObject leftButtonClosePart;

	public UISprite leftButtonCloseIcon;

	[Header("-Max")]
	public UIPanel leftButtonMaxPanel;

	public GameObject leftButtonMaxPart;

	public UILabel leftButtonMaxLabel;

	[Header("Upgrade Part")]
	public ArmyLeftPowerDialog powerDialog;

	[Header("AbilityPart")]
	public ArmyLeftAbilityDialog abilityDialog;

	[Header("BuffPart")]
	public ArmyLeftBuffDialog buffDialog;

	private LevelBehaviour mUnit;

	private float mDur = 0.3f;

	private int mLastRemainingTime = -1;

	private bool mDialogOpened;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(leftButtonUpgradePart.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LeftButtonUpgradeClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(leftButtonDeliverNowPart.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LeftButtonDeliverNowClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(leftButtonActivatePart.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LeftButtonActivateClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(leftButtonClosePart.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LeftButtonCloseClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(leftButtonMaxPart.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LeftButtonMaxClick));
		leftButtonDeliverNowPrizeTable.onReposition = delegate
		{
			float val = 0f - leftButtonDeliverNowPrizeTable.padding.x - (leftButtonDeliverNowPrizeLabel.transform.parent.transform.localPosition.x - leftButtonDeliverNowPrizeTable.padding.x) / 2f;
			leftButtonDeliverNowPrizeTable.transform.localPosition = leftButtonDeliverNowPrizeTable.transform.localPosition.ReplaceX(val);
		};
		powerDialog.InitControls();
		abilityDialog.InitControls();
		buffDialog.InitControls();
		int num = (int)UIRoot.list[0].activeWidth;
		int num2 = UIRoot.list[0].activeHeight - 364;
		background.transform.localScale = background.transform.localScale.ReplaceXY(num, num2);
		background.transform.localPosition = background.transform.localPosition.ReplaceY(-144f);
	}

	private void LeftButtonUpgradeClick(GameObject go)
	{
		if (mDialogOpened)
		{
			return;
		}
		mDialogOpened = true;
		powerDialog.ShowDialog();
		abilityDialog.ShowDialog();
		buffDialog.ShowDialog();
		ChangeLeftContent();
		TweenAlpha.Begin(leftButtonUpgradePanel.gameObject, mDur, 0f).onFinished = delegate
		{
			if (mDialogOpened)
			{
				leftButtonUpgradePart.SetActive(value: false);
			}
		};
		background.alpha = 0f;
		TweenAlpha.Begin(background.gameObject, mDur, 0f, 0.3f).onFinished = delegate
		{
			backgroundCollider.enabled = true;
		};
		leftButtonClosePart.SetActive(value: true);
		leftButtonClosePanel.alpha1 = 0.0005f;
		TweenAlpha.Begin(leftButtonClosePanel.gameObject, mDur, 1f).onFinished = null;
		TweenScale.Begin(leftButtonCloseIcon.gameObject, mDur, new Vector3(1f, 1f, 1f), new Vector3(50f, 50f, 1f)).method = UITweener.Method.EaseIn;
		TweenRotationSpecial.Begin(leftButtonCloseIcon.gameObject, mDur * 1.5f, Vector3.forward, 0f, 360f).method = UITweener.Method.Linear;
		GuiScreenSingle<ArmyScreen>.instance.armyRightContent.StatisticsBackgroundClick(go);
	}

	private void LeftButtonDeliverNowClick(GameObject go)
	{
		if (mUnit.upgradeSlots.deliveringSlot != null)
		{
			bool isSpecial = mUnit.upgradeSlots.deliveringSlot.isSpecial;
			int instantBuyPrice = mUnit.upgradeSlots.deliveringSlot.instantBuyPrice;
			if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, mUnit.unitName, NotEnoughDialog.Type.DELIVER);
				GuiElementSingle<InappScreen>.instance.routeToStore = "Unit_Upgrade";
				return;
			}
			int armyPowerX = LevelManager.instance.armyPowerX10;
			Singleton<Wallet>.instance.GoldSpentFake(instantBuyPrice);
			GuiScreenSingle<ArmyScreen>.instance.DeliverNowUnitUpgrade(mUnit, showAnimation: true);
			DisableClickOnButton(leftButtonDeliverNowPart);
			AnimateArmyPowerLeft(armyPowerX);
			AnimateButton(leftButtonDeliverNowPart, 0f);
			AnimateRestOfScreen(isSpecial);
		}
	}

	private void LeftButtonActivateClick(GameObject go)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool isSpecial = mUnit.upgradeSlots.deliveringSlot.isSpecial;
		GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(mUnit, showAnimation: true);
		DisableClickOnButton(leftButtonActivatePart);
		AnimateArmyPowerLeft(armyPowerX);
		AnimateButton(leftButtonActivatePart, 0f);
		AnimateRestOfScreen(isSpecial);
	}

	private void LeftButtonCloseClick(GameObject go)
	{
		if (!mDialogOpened)
		{
			return;
		}
		mDialogOpened = false;
		powerDialog.HideDialog();
		abilityDialog.HideDialog();
		buffDialog.HideDialog();
		if (mUnit.upgradeSlots.allUpgradesBought)
		{
			leftButtonMaxPart.SetActive(value: true);
			leftButtonMaxPanel.alpha1 = 0.0005f;
			TweenAlpha.Begin(leftButtonMaxPanel.gameObject, mDur, 1f).onFinished = null;
		}
		else if (mUnit.upgradeSlots.delivering)
		{
			leftButtonDeliverNowPart.SetActive(value: true);
			leftButtonDeliverNowPanel.alpha1 = 0.0005f;
			TweenAlpha.Begin(leftButtonDeliverNowPanel.gameObject, mDur, 1f).onFinished = delegate
			{
				EnableClickOnButton(leftButtonDeliverNowPart);
			};
		}
		else if (mUnit.upgradeSlots.deliveryActivationNeeded)
		{
			leftButtonActivatePart.SetActive(value: true);
			leftButtonActivatePanel.alpha1 = 0.0005f;
			TweenAlpha.Begin(leftButtonActivatePanel.gameObject, mDur, 1f).onFinished = delegate
			{
				EnableClickOnButton(leftButtonActivatePart);
			};
		}
		else
		{
			leftButtonUpgradePart.SetActive(value: true);
			leftButtonUpgradePanel.alpha1 = 0.0005f;
			TweenAlpha.Begin(leftButtonUpgradePanel.gameObject, mDur, 1f).onFinished = null;
		}
		backgroundCollider.enabled = false;
		TweenAlpha.Begin(background.gameObject, mDur, 0f).onFinished = null;
		TweenAlpha.Begin(leftButtonClosePanel.gameObject, mDur, 0f).onFinished = delegate
		{
			if (!mDialogOpened)
			{
				leftButtonClosePart.SetActive(value: false);
			}
		};
	}

	private void LeftButtonMaxClick(GameObject go)
	{
		if (mDialogOpened)
		{
			return;
		}
		mDialogOpened = true;
		powerDialog.ShowDialog();
		abilityDialog.ShowDialog();
		buffDialog.ShowDialog();
		ChangeLeftContent();
		TweenAlpha.Begin(leftButtonMaxPanel.gameObject, mDur, 0f).onFinished = delegate
		{
			if (mDialogOpened)
			{
				leftButtonMaxPart.SetActive(value: false);
			}
		};
		background.alpha = 0f;
		TweenAlpha.Begin(background.gameObject, mDur, 0f, 0.3f).onFinished = delegate
		{
			backgroundCollider.enabled = true;
		};
		leftButtonClosePart.SetActive(value: true);
		leftButtonClosePanel.alpha1 = 0.0005f;
		TweenAlpha.Begin(leftButtonClosePanel.gameObject, mDur, 1f).onFinished = null;
		TweenScale.Begin(leftButtonCloseIcon.gameObject, mDur, new Vector3(1f, 1f, 1f), new Vector3(50f, 50f, 1f)).method = UITweener.Method.EaseIn;
		TweenRotationSpecial.Begin(leftButtonCloseIcon.gameObject, mDur * 1.5f, Vector3.forward, 0f, 360f).method = UITweener.Method.Linear;
	}

	public void InitGUIValues()
	{
		powerDialog.InitGUIValues();
		abilityDialog.InitGUIValues();
		buffDialog.InitGUIValues();
		InstantHideUpgrades();
	}

	public void SelectUnit(LevelBehaviour selectedUnit)
	{
		mUnit = selectedUnit;
		powerDialog.SelectUnit(selectedUnit);
		abilityDialog.SelectUnit(selectedUnit);
		buffDialog.SelectUnit(selectedUnit);
	}

	public void UpdateLeftContent(bool changedUnit = true)
	{
		ChangeLeftContent();
		powerDialog.UpdateLeftContent(changedUnit);
		abilityDialog.UpdateLeftContent(changedUnit);
		buffDialog.UpdateLeftContent(changedUnit);
	}

	private void ChangeLeftContent()
	{
		UpgradeSlots.State unitState = mUnit.upgradeSlots.unitState;
		bool flag = unitState == UpgradeSlots.State.Delivering;
		bool flag2 = unitState == UpgradeSlots.State.Delivered;
		bool flag3 = unitState == UpgradeSlots.State.Locked || unitState == UpgradeSlots.State.NotBuyed;
		bool allUpgradesBought = mUnit.upgradeSlots.allUpgradesBought;
		bool flag4 = !flag3 && !mUnit.upgradeSlots.borrowed && !flag && !flag2 && !allUpgradesBought;
		if (flag3 || mUnit.upgradeSlots.borrowed)
		{
			InstantHideUpgrades();
		}
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.UpdateProgresses();
		leftButtonEmptyLabel.text = Localization.Localize((!mUnit.isSoldier) ? "ID_GUI_EMPTYUNITUPGRADE" : "ID_EMPTYUNITTRAIN");
		leftButtonRentedLabel.text = Localization.Localize((!mUnit.isSoldier) ? "ID_RENTEDUNIT" : "ID_RENTEDSOLDIER");
		leftButtonUpgradeLabel.text = Localization.Localize((!mUnit.isSoldier) ? "ID_UPGRADE" : "ID_TRAIN");
		MiscTools.SetUILabelRescale(leftButtonUpgradeLabel, 64f, 20f, 370);
		leftButtonMaxLabel.text = Localization.Localize((!mUnit.isSoldier) ? "ID_UNITMAXUPGRADED" : "ID_UNITMAXTRAINED");
		promoteHintTable.gameObject.SetActive((unitState == UpgradeSlots.State.Active || !mUnit.upgradeSlots.upgradeSlot.isDelivering) && mUnit.upgradeSlots.upgradeSlot.isTierFullUpgraded && !mUnit.upgradeSlots.isPromoteToNextTierLocked);
		if (promoteHintTable.gameObject.activeSelf)
		{
			int num = mUnit.upgradeSlots.actualTier + 1;
			promoteHintTable.repositionNow = true;
			promoteHintText.text = Localization.LocalizeFormat("ID_READYTOPROMOTETOTIER", num);
			for (int i = 0; i < promoteHintStars.Length; i++)
			{
				promoteHintStars[i].gameObject.SetActive(i < num);
			}
		}
		deliveredHintText.gameObject.SetActive(unitState == UpgradeSlots.State.Delivered);
		leftButtonEmptyPart.SetActive(!mDialogOpened && flag3);
		leftButtonRentedPart.SetActive(!mDialogOpened && mUnit.upgradeSlots.borrowed);
		leftButtonUpgradePart.SetActive(!mDialogOpened && flag4);
		leftButtonDeliverNowPart.SetActive(!mDialogOpened && flag && !mDialogOpened);
		leftButtonActivatePart.SetActive(!mDialogOpened && flag2 && !mDialogOpened);
		leftButtonMaxPart.SetActive(!mDialogOpened && allUpgradesBought);
		leftButtonClosePart.SetActive(mDialogOpened);
		FinishTweenBottomButtons();
	}

	private void FinishTweenBottomButtons()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
		{
			if (leftButtonUpgradePart.activeSelf)
			{
				ResetButton(leftButtonUpgradePanel.gameObject);
			}
			if (leftButtonDeliverNowPart.activeSelf)
			{
				ResetButton(leftButtonDeliverNowPanel.gameObject);
			}
			if (leftButtonActivatePart.activeSelf)
			{
				ResetButton(leftButtonActivatePanel.gameObject);
			}
			if (leftButtonMaxPart.activeSelf)
			{
				ResetButton(leftButtonMaxPanel.gameObject);
			}
			if (leftButtonClosePart.activeSelf)
			{
				ResetButton(leftButtonClosePanel.gameObject);
				TweenScale.Begin(leftButtonCloseIcon.gameObject, 0.01f, new Vector3(50f, 50f, 1f));
				TweenRotationSpecial.Begin(leftButtonCloseIcon.gameObject, 0.01f, Vector3.forward, 0f, 360f);
			}
		}
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		if (mDialogOpened)
		{
			if (mUnit.upgradeSlots.upgradeSlotSpecial.isDelivering)
			{
				abilityDialog.UpdateDeliveringTime(remainingTime, progress);
			}
			else
			{
				powerDialog.UpdateDeliveringTime(remainingTime, progress);
			}
			return;
		}
		remainingTime = ((!(remainingTime > 0f)) ? 0f : remainingTime);
		int num = MiscTools.RoundToInt(remainingTime);
		leftButtonDeliverNowProgressBar.fillAmount = Mathf.Clamp01(progress);
		leftButtonDeliverNowTimeLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
		string text = MiscTools.FormatBigNumber(mUnit.upgradeSlots.instantUnitDeliveryPrice);
		if (leftButtonDeliverNowPrizeLabel.text != text)
		{
			leftButtonDeliverNowPrizeLabel.text = text;
			leftButtonDeliverNowPrizeTable.repositionNow = true;
		}
		if (mLastRemainingTime == num)
		{
			return;
		}
		mLastRemainingTime = num;
		int num2 = MiscTools.RoundToInt(remainingTime % 6f);
		if (num2 == 2 && (leftButtonDeliverNowTimeLabel.alpha == 0f || leftButtonDeliverNowInfoLabel.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(leftButtonDeliverNowInfoLabel.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(leftButtonDeliverNowTimeLabel.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (leftButtonDeliverNowInfoLabel.alpha == 0f || leftButtonDeliverNowTimeLabel.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(leftButtonDeliverNowTimeLabel.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(leftButtonDeliverNowInfoLabel.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	public void DoAfterHide()
	{
		powerDialog.DoAfterHide();
		abilityDialog.DoAfterHide();
		buffDialog.DoAfterHide();
		InstantHideUpgrades();
	}

	private void InstantHideUpgrades()
	{
		mDialogOpened = false;
		powerDialog.InstantHideUpgrades();
		abilityDialog.InstantHideUpgrades();
		buffDialog.InstantHideUpgrades();
		TweenAlpha component = background.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		background.alpha = 0f;
		backgroundCollider.enabled = false;
	}

	private void ResetButton(GameObject button, bool setAlphaToOne = true)
	{
		if (!button.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = button.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = true;
		}
		if (setAlphaToOne)
		{
			UIPanel component2 = button.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1f;
			}
		}
		TweenAlpha component3 = button.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	private void DisableClickOnButton(GameObject button)
	{
		if (button.activeInHierarchy)
		{
			BoxCollider component = button.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private TweenAlpha AnimateButton(GameObject button, float toAlpha)
	{
		if (!button.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(button, mDur, toAlpha);
	}

	private void EnableClickOnButton(GameObject button)
	{
		if (button.activeInHierarchy)
		{
			BoxCollider component = button.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	private void AnimateArmyPowerLeft(int previousArmyPowerX10)
	{
		if (mUnit.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			armyPowerAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	private void AnimateRestOfScreen(bool isAbility)
	{
		if (!isAbility)
		{
			GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.progressBarsLeft[0].AnimateStat();
		}
		if (!isAbility)
		{
			GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.progressBarsLeft[1].AnimateStat();
		}
		if (isAbility)
		{
			GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.progressBarsLeft[2].AnimateStat();
		}
		GuiScreenSingle<ArmyScreen>.instance.armyRightContent.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}
}

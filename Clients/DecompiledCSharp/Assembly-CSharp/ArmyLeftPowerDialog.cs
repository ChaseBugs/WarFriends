using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmyLeftPowerDialog : Core_BaseScript
{
	[Header("Core")]
	public UIPanel upgradeDialogPanel;

	public GameObject upgradePart;

	public UITable unitLevelTable;

	public UISprite[] unitLevelStars;

	public UILabel unitLevelLabel;

	public ArmyUnitStatistics unitAttackStatistic;

	public ArmyUnitStatistics unitHealthStatistic;

	public ArmyPowerAnimation armyPowerAnimation;

	[Header("-Upgrade Button")]
	public GameObject unitButtonUpgradePart;

	public UITable unitButtonUpgradePrizeTable;

	public UILabel unitButtonUpgradePrizeLabel;

	public GameObject unitButtonUpgradeSalePart;

	public UILabel unitButtonUpgradeSalePercent;

	public WinStreakCounter unitButtonUpgradeSaleTimeCounter;

	[Header("-Deliver now Button")]
	public GameObject unitButtonDeliverPart;

	public UILabel unitButtonDeliverTimeLabel;

	public UILabel unitButtonDeliverInfoLabel;

	public UISprite unitButtonDeliverProgressBar;

	public UITable unitButtonDeliverPrizeTable;

	public UILabel unitButtonDeliverPrizeLabel;

	[Header("-Activate Button")]
	public GameObject unitButtonActivatePart;

	[Header("-Promote Button")]
	public GameObject unitButtonPromotePart;

	public BoxCollider unitButtonPromoteCollider;

	public UISprite unitButtonPromoteBackground;

	public UITable unitButtonPromoteTable;

	public UILabel unitButtonPromoteLabel;

	public UISprite[] unitButtonPromoteStars;

	public UISprite unitButtonPromoteBorder;

	public UILabel unitButtonPromoteFreeLabel;

	public UISprite unitButtonPromoteLockIcon;

	public UILabel unitButtonPromoteUnlockRank;

	public GameObject unitButtonPromoteHighlight;

	[Header("-Max Button")]
	public GameObject unitButtonMaxPart;

	public UILabel unitButtonMaxLabel;

	private LevelBehaviour mUnit;

	private bool mDialogOpened;

	private float mDur = 0.3f;

	private int mLastRemainingTime = -1;

	private bool mAnimating;

	public void ShowDialog()
	{
		if (mDialogOpened)
		{
			return;
		}
		mDialogOpened = true;
		upgradePart.SetActive(value: true);
		upgradeDialogPanel.alpha1 = 0.005f;
		TweenAlpha.Begin(upgradeDialogPanel.gameObject, mDur, 1f);
		TweenPosition.Begin(upgradePart, mDur / 2f, new Vector3(0f, -20f, 0f), new Vector3(0f, 20f, 0f)).onFinished = delegate
		{
			if (mDialogOpened)
			{
				TweenPosition.Begin(upgradePart, mDur / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		ChangeLeftContent();
		ResetDialogueButtons();
		UIPanel[] componentsInChildren = upgradePart.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, mDur, 1f).onFinished = null;
		}
	}

	public void HideDialog()
	{
		if (!mDialogOpened)
		{
			return;
		}
		mDialogOpened = false;
		TweenAlpha.Begin(upgradeDialogPanel.gameObject, mDur, 0f);
		TweenPosition.Begin(upgradePart, mDur / 2f, new Vector3(0f, 20f, 0f)).onFinished = delegate
		{
			if (!mDialogOpened)
			{
				upgradePart.SetActive(value: false);
			}
		};
		UIPanel[] componentsInChildren = upgradePart.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, mDur, 0f).onFinished = null;
		}
	}

	public void SelectUnit(LevelBehaviour selectedUnit)
	{
		mUnit = selectedUnit;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(unitButtonUpgradePart.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(UnitButtonUpgradeClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(unitButtonDeliverPart.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(UnitButtonDeliverClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(unitButtonActivatePart.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(UnitButtonActivateClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(unitButtonPromotePart.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(UnitButtonPromoteClick));
		unitButtonUpgradePrizeTable.onReposition = delegate
		{
			float val = 0f - unitButtonUpgradePrizeTable.padding.x - (unitButtonUpgradePrizeLabel.transform.parent.transform.localPosition.x - unitButtonUpgradePrizeTable.padding.x) / 2f;
			unitButtonUpgradePrizeTable.transform.localPosition = unitButtonUpgradePrizeTable.transform.localPosition.ReplaceX(val);
		};
		unitButtonDeliverPrizeTable.onReposition = delegate
		{
			float val = 0f - unitButtonDeliverPrizeTable.padding.x - (unitButtonDeliverPrizeLabel.transform.parent.transform.localPosition.x - unitButtonDeliverPrizeTable.padding.x) / 2f;
			unitButtonDeliverPrizeTable.transform.localPosition = unitButtonDeliverPrizeTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void UnitButtonUpgradeClick(GameObject go)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade);
		int num2 = mUnit.upgradeSlots.upgradeSlot.upgradePrice * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to upgrade {mUnit.upgradeSlots.GetSheetName()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mUnit.unitName, (!mUnit.isSoldier) ? NotEnoughDialog.Type.UPGRADE : NotEnoughDialog.Type.TRAIN);
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivered)
			{
				GuiScreenSingle<ArmyScreen>.instance.ActivateUnit(levelBehaviour);
				SetOtherToAnimate();
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.State.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, mUnit, isNextAbility: false);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(levelBehaviour, showAnimation: false);
				SetOtherToAnimate();
			}
		}
		Singleton<Wallet>.instance.WarBucksSpentFake(num2);
		GuiScreenSingle<ArmyScreen>.instance.UpgradeUnitUpgrade(mUnit, num);
		DisableClickOnButton(unitButtonUpgradePart);
		mAnimating = true;
	}

	private void UnitButtonDeliverClick(GameObject go)
	{
		int instantBuyPrice = mUnit.upgradeSlots.upgradeSlot.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, mUnit.unitName, NotEnoughDialog.Type.DELIVER);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Unit_Upgrade";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.GoldSpentFake(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.DeliverNowUnitUpgrade(mUnit, showAnimation: true);
		DisableClickOnButton(unitButtonDeliverPart);
		AnimateArmyPower(armyPowerX);
		mAnimating = true;
		AnimateRestOfScreen();
	}

	private void UnitButtonActivateClick(GameObject go)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(mUnit, showAnimation: true);
		DisableClickOnButton(unitButtonActivatePart);
		AnimateArmyPower(armyPowerX);
		mAnimating = true;
		AnimateRestOfScreen();
	}

	private void UnitButtonPromoteClick(GameObject go)
	{
		LevelBehaviour levelBehaviour = Singleton<ActiveUnitsManager>.instance.IsEnoughBoughtUnits(mUnit.unitType);
		if (levelBehaviour != null && mUnit.upgradeSlots.actualTier > mUnit.upgradeSlots.startTier)
		{
			GuiElementSingle<UnitPromotionLockedDialog>.instance.ShowDialog(mUnit, levelBehaviour);
		}
		else if (mUnit.upgradeSlots.unlockTierLevel <= LevelManager.instance.currentLevel.displayNumber)
		{
			GuiScreenSingle<ArmyScreen>.instance.PromoteUnit(mUnit);
			DisableClickOnButton(unitButtonPromotePart);
			if (mUnit.upgradeSlots.unitState == UpgradeSlots.State.Active)
			{
				SetOtherToAnimate();
			}
			GuiElementSingle<UnitPromotedDialog>.instance.ShowDialog(mUnit);
			mAnimating = true;
		}
	}

	private void SetOtherToAnimate()
	{
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.abilityDialog.UpdateLeftContent(changedUnit: false);
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.buffDialog.UpdateLeftContent(changedUnit: false);
	}

	public void UpdateLeftContent(bool changedUnit = true)
	{
		if (!mDialogOpened)
		{
			mAnimating = false;
			ChangeLeftContent();
			return;
		}
		if (changedUnit)
		{
			mAnimating = false;
			ChangeLeftContent();
			ResetDialogueButtons();
			return;
		}
		UpgradeSlots.State unitState = mUnit.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.State.Active || unitState == UpgradeSlots.State.Delivering || unitState == UpgradeSlots.State.Delivered)
		{
			TweenAlpha tweenAlpha = AnimateHideDialogButton();
			if (tweenAlpha == null)
			{
				ChangeLeftContent();
				ResetDialogueButtons();
				return;
			}
			mAnimating = true;
			tweenAlpha.onFinished = delegate
			{
				ChangeLeftContent();
				ResetDialogueButtons(setAlphaToOne: false);
				TweenAlpha tweenAlpha2 = AnimateShowDialogButton();
				if (tweenAlpha2 != null)
				{
					tweenAlpha2.onFinished = delegate
					{
						mAnimating = false;
					};
				}
				else
				{
					mAnimating = false;
				}
			};
		}
		else
		{
			UnitInfoUpdate();
		}
	}

	public void InitGUIValues()
	{
	}

	private void ChangeLeftContent()
	{
		UpgradeSlot upgradeSlot = mUnit.upgradeSlots.upgradeSlot;
		UpgradeSlots.State unitState = mUnit.upgradeSlots.unitState;
		bool isMaxUpgraded = upgradeSlot.isMaxUpgraded;
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.UpdateProgresses();
		UnitInfoUpdate();
		unitButtonDeliverPart.SetActive(unitState == UpgradeSlots.State.Delivering && upgradeSlot.isDelivering);
		unitButtonActivatePart.SetActive(unitState == UpgradeSlots.State.Delivered && upgradeSlot.isDelivering);
		unitButtonPromotePart.SetActive(upgradeSlot.isTierFullUpgraded && !isMaxUpgraded && (unitState == UpgradeSlots.State.Active || !upgradeSlot.isDelivering));
		unitButtonMaxPart.SetActive(isMaxUpgraded);
		unitButtonUpgradePart.SetActive(!unitButtonDeliverPart.activeSelf && !unitButtonActivatePart.activeSelf && !unitButtonPromotePart.activeSelf && !unitButtonMaxPart.activeSelf);
	}

	private void UnitInfoUpdate()
	{
		int actualUnitLevel = mUnit.upgradeSlots.actualUnitLevel;
		int actualMaxUnitLevel = mUnit.upgradeSlots.actualMaxUnitLevel;
		int actualTier = mUnit.upgradeSlots.actualTier;
		List<Tuple<string, float[]>> guiStatistics = mUnit.upgradeSlots.upgradeSlot.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[0];
		Tuple<string, float[]> tuple2 = guiStatistics[1];
		if (mUnit.upgradeSlots.borrowed)
		{
			tuple.Value2[2] = tuple.Value2[0];
			tuple2.Value2[2] = tuple2.Value2[0];
		}
		for (int i = 0; i < unitLevelStars.Length; i++)
		{
			unitLevelStars[i].gameObject.SetActive(i < actualTier);
		}
		unitLevelLabel.text = $"{actualUnitLevel}{Colours.stringGray} / {actualMaxUnitLevel}";
		unitLevelTable.repositionNow = true;
		bool bought = mUnit.upgradeSlots.bought;
		bool isDelivering = mUnit.upgradeSlots.unitState == UpgradeSlots.State.Delivering && !mUnit.upgradeSlots.deliveringSlot.isSpecial;
		unitAttackStatistic.Initialize(tuple, bought, isDelivering, isDamage: true);
		unitHealthStatistic.Initialize(tuple2, bought, isDelivering);
		SetSaleAndPrize();
		unitButtonDeliverPrizeLabel.text = string.Empty;
		TweenAlpha component = unitButtonDeliverTimeLabel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		unitButtonDeliverTimeLabel.alpha = 1f;
		TweenAlpha component2 = unitButtonDeliverInfoLabel.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		unitButtonDeliverInfoLabel.alpha = 0f;
		PromoteButtonLook();
		unitButtonMaxLabel.text = Localization.Localize((!mUnit.isSoldier) ? "ID_UNITPOWERFULLYUPGRADED" : "ID_UNITPOWERFULLYTRAINED");
	}

	public void SetSaleAndPrize()
	{
		if (!(mUnit == null) && mUnit.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade);
			int num2 = mUnit.upgradeSlots.upgradeSlot.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			unitButtonUpgradePrizeLabel.text = MiscTools.FormatBigNumber(num2);
			unitButtonUpgradePrizeTable.repositionNow = true;
			unitButtonUpgradeSalePart.SetActive(flag);
			if (flag)
			{
				unitButtonUpgradeSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				unitButtonUpgradeSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedUnitEndtime(mUnit, OfferBuyType.Upgrade), upperCaseCountdown: true);
				WinStreakCounter winStreakCounter = unitButtonUpgradeSaleTimeCounter;
				winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetSaleAndPrize));
				WinStreakCounter winStreakCounter2 = unitButtonUpgradeSaleTimeCounter;
				winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SetSaleAndPrize));
			}
			else
			{
				unitButtonUpgradeSaleTimeCounter.StopCountingTo();
				WinStreakCounter winStreakCounter3 = unitButtonUpgradeSaleTimeCounter;
				winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SetSaleAndPrize));
			}
		}
	}

	private void PromoteButtonLook()
	{
		int unlockTierLevel = mUnit.upgradeSlots.unlockTierLevel;
		int actualTier = mUnit.upgradeSlots.actualTier;
		bool isPromoteToNextTierLocked = mUnit.upgradeSlots.isPromoteToNextTierLocked;
		unitButtonPromoteBackground.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray143);
		unitButtonPromoteBorder.color = ((!isPromoteToNextTierLocked) ? Colours.gray229 : Colours.gray135);
		unitButtonPromoteLabel.color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.whiteToTier);
		unitButtonPromoteLabel.text = Localization.LocalizeFormat("ID_PROMOTETOTIER", actualTier + 1);
		for (int i = 0; i < unitButtonPromoteStars.Length; i++)
		{
			unitButtonPromoteStars[i].color = ((!isPromoteToNextTierLocked) ? Color.white : Colours.gray135);
			unitButtonPromoteStars[i].gameObject.SetActive(i <= actualTier);
		}
		unitButtonPromoteTable.repositionNow = true;
		unitButtonPromoteFreeLabel.gameObject.SetActive(!isPromoteToNextTierLocked);
		unitButtonPromoteLockIcon.gameObject.SetActive(isPromoteToNextTierLocked);
		unitButtonPromoteUnlockRank.gameObject.SetActive(isPromoteToNextTierLocked);
		if (isPromoteToNextTierLocked)
		{
			unitButtonPromoteUnlockRank.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), unlockTierLevel);
		}
		unitButtonPromoteHighlight.SetActive(!isPromoteToNextTierLocked);
		unitButtonPromoteCollider.enabled = !isPromoteToNextTierLocked;
	}

	private void ResetDialogueButtons(bool setAlphaToOne = true)
	{
		if (upgradePart.activeSelf)
		{
			ResetButton(unitButtonDeliverPart, setAlphaToOne);
			ResetButton(unitButtonActivatePart, setAlphaToOne);
			ResetButton(unitButtonPromotePart, setAlphaToOne);
			ResetButton(unitButtonMaxPart, setAlphaToOne);
			ResetButton(unitButtonUpgradePart, setAlphaToOne);
		}
	}

	private void ResetButton(GameObject button, bool setAlphaToOne = true)
	{
		if (!button.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = button.GetComponent<BoxCollider>();
		if (component == unitButtonPromoteCollider)
		{
			unitButtonPromoteCollider.enabled = !mUnit.upgradeSlots.isPromoteToNextTierLocked;
		}
		else if (component != null)
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

	private void AnimateArmyPower(int previousArmyPowerX10)
	{
		if (mUnit.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			armyPowerAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		remainingTime = ((!(remainingTime > 0f)) ? 0f : remainingTime);
		int num = MiscTools.RoundToInt(remainingTime);
		unitButtonDeliverProgressBar.fillAmount = Mathf.Clamp01(progress);
		unitButtonDeliverTimeLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
		string text = MiscTools.FormatBigNumber(mUnit.upgradeSlots.instantUnitDeliveryPrice);
		if (unitButtonDeliverPrizeLabel.text != text)
		{
			unitButtonDeliverPrizeLabel.text = text;
			unitButtonDeliverPrizeTable.repositionNow = true;
		}
		if (mLastRemainingTime == num)
		{
			return;
		}
		mLastRemainingTime = num;
		int num2 = MiscTools.RoundToInt(remainingTime % 6f);
		if (num2 == 2 && (unitButtonDeliverTimeLabel.alpha == 0f || unitButtonDeliverInfoLabel.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(unitButtonDeliverInfoLabel.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(unitButtonDeliverTimeLabel.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (unitButtonDeliverInfoLabel.alpha == 0f || unitButtonDeliverTimeLabel.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(unitButtonDeliverTimeLabel.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(unitButtonDeliverInfoLabel.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	public void DoAfterHide()
	{
		unitButtonUpgradeSaleTimeCounter.StopCountingTo();
		WinStreakCounter winStreakCounter = unitButtonUpgradeSaleTimeCounter;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetSaleAndPrize));
	}

	public void InstantHideUpgrades()
	{
		mDialogOpened = false;
		mAnimating = false;
		upgradePart.SetActive(value: false);
	}

	private void AnimateRestOfScreen()
	{
		unitAttackStatistic.AnimateStat();
		unitHealthStatistic.AnimateStat();
		GuiScreenSingle<ArmyScreen>.instance.armyRightContent.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}

	private TweenAlpha AnimateHideDialogButton()
	{
		return AnimateDialogButton(0f);
	}

	private TweenAlpha AnimateShowDialogButton()
	{
		return AnimateDialogButton(1f);
	}

	private TweenAlpha AnimateDialogButton(float toAlpha)
	{
		TweenAlpha tweenAlpha = unitButtonUpgradePart.GetComponent<TweenAlpha>();
		bool flag = false;
		if (upgradePart.activeSelf && mAnimating)
		{
			if (unitButtonUpgradePart.activeSelf)
			{
				tweenAlpha = AnimateButton(unitButtonUpgradePart, toAlpha);
				flag = true;
			}
			if (unitButtonDeliverPart.activeSelf)
			{
				tweenAlpha = AnimateButton(unitButtonDeliverPart, toAlpha);
				flag = true;
			}
			if (unitButtonActivatePart.activeSelf)
			{
				tweenAlpha = AnimateButton(unitButtonActivatePart, toAlpha);
				flag = true;
			}
			if (unitButtonPromotePart.activeSelf)
			{
				tweenAlpha = AnimateButton(unitButtonPromotePart, toAlpha);
				flag = true;
			}
			if (unitButtonMaxPart.activeSelf)
			{
				tweenAlpha = AnimateButton(unitButtonMaxPart, toAlpha);
				flag = true;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	private TweenAlpha AnimateButton(GameObject button, float toAlpha)
	{
		if (!button.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(button, mDur, toAlpha);
	}
}

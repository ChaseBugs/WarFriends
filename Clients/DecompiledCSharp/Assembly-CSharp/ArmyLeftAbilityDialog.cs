using System;
using UnityEngine;

public class ArmyLeftAbilityDialog : Core_BaseScript
{
	[Header("Core")]
	public UIPanel abilityDialogPanel;

	public GameObject abilityPart;

	public UILabel abilityLevelLabel;

	public UILabel abilityDescription;

	public ArmyUnitStatistics unitAbilityStatistic;

	public ArmyPowerAnimation armyPowerAbilityAnimation;

	[Header("-Locked Button")]
	public GameObject abilityButtonLockedPart;

	public UITable abilityButtonLockedTable;

	public UILabel abilityButtonLockedLabel;

	public UISprite[] abilityButtonLockedStars;

	[Header("-Upgrade Button")]
	public GameObject abilityButtonUpgradePart;

	public UITable abilityButtonUpgradePrizeTable;

	public UILabel abilityButtonUpgradePrizeLabel;

	public GameObject abilityButtonUpgradeSalePart;

	public UILabel abilityButtonUpgradeSalePercent;

	public WinStreakCounter abilityButtonUpgradeSaleTimeCounter;

	[Header("-Deliver now Button")]
	public GameObject abilityButtonDeliverPart;

	public UILabel abilityButtonDeliverTimeLabel;

	public UILabel abilityButtonDeliverInfoLabel;

	public UISprite abilityButtonDeliverProgressBar;

	public UITable abilityButtonDeliverPrizeTable;

	public UILabel abilityButtonDeliverPrizeLabel;

	[Header("-Activate Button")]
	public GameObject abilityButtonActivatePart;

	[Header("-Tier full Button")]
	public GameObject abilityButtonTierFullPart;

	public UITable abilityButtonTierFullTable;

	public UILabel abilityButtonTierFullLabel;

	public UISprite[] abilityButtonTierFullStars;

	[Header("-Max Button")]
	public GameObject abilityButtonMaxPart;

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
		abilityPart.SetActive(value: true);
		abilityDialogPanel.alpha1 = 0.0005f;
		TweenAlpha.Begin(abilityDialogPanel.gameObject, mDur, 1f);
		TweenPosition.Begin(abilityPart, mDur / 2f, new Vector3(-20f, 0f, 0f), new Vector3(20f, 0f, 0f)).onFinished = delegate
		{
			if (mDialogOpened)
			{
				TweenPosition.Begin(abilityPart, mDur / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		SetAbilityIcon();
		ChangeLeftContent();
		ResetDialogueButtons();
		UIPanel[] componentsInChildren = abilityPart.GetComponentsInChildren<UIPanel>(includeInactive: false);
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
		TweenAlpha.Begin(abilityDialogPanel.gameObject, mDur, 0f);
		TweenPosition.Begin(abilityPart, mDur / 2f, new Vector3(20f, 0f, 0f)).onFinished = delegate
		{
			if (!mDialogOpened)
			{
				abilityPart.SetActive(value: false);
			}
		};
		UIPanel[] componentsInChildren = abilityPart.GetComponentsInChildren<UIPanel>(includeInactive: false);
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
		UIEventListener uIEventListener = UIEventListener.Get(abilityButtonUpgradePart.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AbilityButtonUpgradeClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(abilityButtonDeliverPart.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AbilityButtonDeliverClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(abilityButtonActivatePart.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AbilityButtonActivateClick));
		abilityButtonUpgradePrizeTable.onReposition = delegate
		{
			float val = 0f - abilityButtonUpgradePrizeTable.padding.x - (abilityButtonUpgradePrizeLabel.transform.parent.transform.localPosition.x - abilityButtonUpgradePrizeTable.padding.x) / 2f;
			abilityButtonUpgradePrizeTable.transform.localPosition = abilityButtonUpgradePrizeTable.transform.localPosition.ReplaceX(val);
		};
		abilityButtonDeliverPrizeTable.onReposition = delegate
		{
			float val = 0f - abilityButtonDeliverPrizeTable.padding.x - (abilityButtonDeliverPrizeLabel.transform.parent.transform.localPosition.x - abilityButtonDeliverPrizeTable.padding.x) / 2f;
			abilityButtonDeliverPrizeTable.transform.localPosition = abilityButtonDeliverPrizeTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void AbilityButtonUpgradeClick(GameObject go)
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade);
		int num2 = mUnit.upgradeSlots.upgradeSlotSpecial.upgradePrice * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to upgrade {mUnit.upgradeSlots.GetSheetName()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mUnit.unitName, (!mUnit.isSoldier) ? NotEnoughDialog.Type.UPGRADESPECIAL : NotEnoughDialog.Type.TRAINSPECIAL);
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
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, mUnit, isNextAbility: true);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(levelBehaviour, showAnimation: false);
				SetOtherToAnimate();
			}
		}
		Singleton<Wallet>.instance.WarBucksSpentFake(num2);
		GuiScreenSingle<ArmyScreen>.instance.UpgradeUnitUpgrade(mUnit, num, isSpecial: true);
		DisableClickOnButton(abilityButtonUpgradePart);
		mAnimating = true;
	}

	private void AbilityButtonDeliverClick(GameObject go)
	{
		int instantBuyPrice = mUnit.upgradeSlots.upgradeSlotSpecial.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, mUnit.unitName, NotEnoughDialog.Type.DELIVERSPECIAL);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Unit_Upgrade";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.GoldSpentFake(instantBuyPrice);
		GuiScreenSingle<ArmyScreen>.instance.DeliverNowUnitUpgrade(mUnit, showAnimation: true);
		DisableClickOnButton(abilityButtonDeliverPart);
		AnimateArmyPowerAbility(armyPowerX);
		mAnimating = true;
		AnimateRestOfScreen();
	}

	private void AbilityButtonActivateClick(GameObject go)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(mUnit, showAnimation: true);
		DisableClickOnButton(abilityButtonActivatePart);
		AnimateArmyPowerAbility(armyPowerX);
		mAnimating = true;
		AnimateRestOfScreen();
	}

	private void SetOtherToAnimate()
	{
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.UpdateLeftContent(changedUnit: false);
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
			AbilityInfoUpdate();
		}
	}

	public void InitGUIValues()
	{
	}

	private void SetAbilityIcon()
	{
		if (abilityPart.activeSelf)
		{
			unitAbilityStatistic.InitializeAbilityIcon(mUnit.abilityIcon);
		}
	}

	private void ChangeLeftContent()
	{
		UpgradeSlotSpecial upgradeSlotSpecial = mUnit.upgradeSlots.upgradeSlotSpecial;
		UpgradeSlots.State unitState = mUnit.upgradeSlots.unitState;
		bool isMaxUpgraded = upgradeSlotSpecial.isMaxUpgraded;
		bool isTierFullUpgraded = upgradeSlotSpecial.isTierFullUpgraded;
		bool flag = !mUnit.upgradeSlots.upgradeSlotSpecial.isBought;
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.UpdateProgresses();
		AbilityInfoUpdate();
		abilityButtonLockedPart.SetActive(flag);
		abilityButtonDeliverPart.SetActive(unitState == UpgradeSlots.State.Delivering && upgradeSlotSpecial.isDelivering);
		abilityButtonActivatePart.SetActive(unitState == UpgradeSlots.State.Delivered && upgradeSlotSpecial.isDelivering);
		abilityButtonTierFullPart.SetActive(!flag && isTierFullUpgraded && !isMaxUpgraded);
		abilityButtonMaxPart.SetActive(!flag && isMaxUpgraded);
		abilityButtonUpgradePart.SetActive(!abilityButtonLockedPart.activeSelf && !abilityButtonDeliverPart.activeSelf && !abilityButtonActivatePart.activeSelf && !abilityButtonTierFullPart.activeSelf && !abilityButtonMaxPart.activeSelf);
	}

	private void AbilityInfoUpdate()
	{
		int startTier = mUnit.upgradeSlots.startTier;
		int actualTier = mUnit.upgradeSlots.actualTier;
		int boughtIndex = mUnit.upgradeSlots.upgradeSlotSpecial.boughtIndex;
		int actualMaxLevel = mUnit.upgradeSlots.upgradeSlotSpecial.actualMaxLevel;
		bool flag = !mUnit.upgradeSlots.upgradeSlotSpecial.isBought;
		Tuple<string, float[]> statistic = mUnit.upgradeSlots.upgradeSlotSpecial.guiStatistics[0];
		abilityLevelLabel.text = ((!flag) ? $"{mUnit.unitAbilityName} {boughtIndex} {Colours.stringGray}/ {actualMaxLevel}[-]" : mUnit.unitAbilityName);
		abilityDescription.text = mUnit.GetAbilityDescriptionWithColours(Colours.stringGrayAbi2);
		SetAbilityIcon();
		bool isBought = mUnit.upgradeSlots.bought && mUnit.upgradeSlots.upgradeSlotSpecial.isBought;
		bool isDelivering = mUnit.upgradeSlots.unitState == UpgradeSlots.State.Delivering && mUnit.upgradeSlots.deliveringSlot.isSpecial;
		unitAbilityStatistic.InitializeSpecial(statistic, isBought, isDelivering);
		abilityButtonLockedLabel.text = Localization.LocalizeFormat("ID_TIERX", startTier + 1);
		for (int i = 0; i < abilityButtonLockedStars.Length; i++)
		{
			abilityButtonLockedStars[i].gameObject.SetActive(i <= startTier);
		}
		abilityButtonLockedTable.repositionNow = true;
		SetAbilitySaleAndPrize();
		abilityButtonDeliverPrizeLabel.text = string.Empty;
		TweenAlpha component = abilityButtonDeliverTimeLabel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		abilityButtonDeliverTimeLabel.alpha = 1f;
		TweenAlpha component2 = abilityButtonDeliverInfoLabel.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		abilityButtonDeliverInfoLabel.alpha = 0f;
		abilityButtonTierFullLabel.text = Localization.LocalizeFormat("ID_TIERX", actualTier + 1);
		for (int j = 0; j < abilityButtonTierFullStars.Length; j++)
		{
			abilityButtonTierFullStars[j].gameObject.SetActive(j <= actualTier);
		}
		abilityButtonTierFullTable.repositionNow = true;
	}

	public void SetAbilitySaleAndPrize()
	{
		if (!(mUnit == null) && mUnit.upgradeSlots.upgradeSlotSpecial.isBought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade);
			int num2 = mUnit.upgradeSlots.upgradeSlotSpecial.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			abilityButtonUpgradePrizeLabel.text = MiscTools.FormatBigNumber(num2);
			abilityButtonUpgradePrizeTable.repositionNow = true;
			abilityButtonUpgradeSalePart.SetActive(flag);
			if (flag)
			{
				abilityButtonUpgradeSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				abilityButtonUpgradeSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedUnitEndtime(mUnit, OfferBuyType.Upgrade), upperCaseCountdown: true);
				WinStreakCounter winStreakCounter = abilityButtonUpgradeSaleTimeCounter;
				winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetAbilitySaleAndPrize));
				WinStreakCounter winStreakCounter2 = abilityButtonUpgradeSaleTimeCounter;
				winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SetAbilitySaleAndPrize));
			}
			else
			{
				abilityButtonUpgradeSaleTimeCounter.StopCountingTo();
				WinStreakCounter winStreakCounter3 = abilityButtonUpgradeSaleTimeCounter;
				winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SetAbilitySaleAndPrize));
			}
		}
	}

	private void ResetDialogueButtons(bool setAlphaToOne = true)
	{
		if (abilityPart.activeSelf)
		{
			ResetButton(abilityButtonLockedPart, setAlphaToOne);
			ResetButton(abilityButtonDeliverPart, setAlphaToOne);
			ResetButton(abilityButtonActivatePart, setAlphaToOne);
			ResetButton(abilityButtonTierFullPart, setAlphaToOne);
			ResetButton(abilityButtonMaxPart, setAlphaToOne);
			ResetButton(abilityButtonUpgradePart, setAlphaToOne);
		}
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

	private void AnimateArmyPowerAbility(int previousArmyPowerX10)
	{
		if (mUnit.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			Debug.Log($"Army Power Ability Animation from {previousArmyPowerX10} to {armyPowerX}");
			armyPowerAbilityAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		remainingTime = ((!(remainingTime > 0f)) ? 0f : remainingTime);
		int num = MiscTools.RoundToInt(remainingTime);
		abilityButtonDeliverProgressBar.fillAmount = Mathf.Clamp01(progress);
		abilityButtonDeliverTimeLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
		string text = MiscTools.FormatBigNumber(mUnit.upgradeSlots.instantUnitDeliveryPrice);
		if (abilityButtonDeliverPrizeLabel.text != text)
		{
			abilityButtonDeliverPrizeLabel.text = text;
			abilityButtonDeliverPrizeTable.repositionNow = true;
		}
		if (mLastRemainingTime == num)
		{
			return;
		}
		mLastRemainingTime = num;
		int num2 = MiscTools.RoundToInt(remainingTime % 6f);
		if (num2 == 2 && (abilityButtonDeliverTimeLabel.alpha == 0f || abilityButtonDeliverInfoLabel.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(abilityButtonDeliverInfoLabel.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(abilityButtonDeliverTimeLabel.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (abilityButtonDeliverInfoLabel.alpha == 0f || abilityButtonDeliverTimeLabel.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(abilityButtonDeliverTimeLabel.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(abilityButtonDeliverInfoLabel.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	public void DoAfterHide()
	{
		abilityButtonUpgradeSaleTimeCounter.StopCountingTo();
		WinStreakCounter winStreakCounter = abilityButtonUpgradeSaleTimeCounter;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetAbilitySaleAndPrize));
	}

	public void InstantHideUpgrades()
	{
		mDialogOpened = false;
		mAnimating = false;
		abilityPart.SetActive(value: false);
	}

	private void AnimateRestOfScreen()
	{
		unitAbilityStatistic.AnimateStat();
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
		TweenAlpha tweenAlpha = abilityButtonUpgradePart.GetComponent<TweenAlpha>();
		bool flag = false;
		if (abilityPart.activeSelf && mAnimating)
		{
			if (abilityButtonLockedPart.activeSelf)
			{
				tweenAlpha = AnimateButton(abilityButtonLockedPart, toAlpha);
				flag = true;
			}
			if (abilityButtonUpgradePart.activeSelf)
			{
				tweenAlpha = AnimateButton(abilityButtonUpgradePart, toAlpha);
				flag = true;
			}
			if (abilityButtonDeliverPart.activeSelf)
			{
				tweenAlpha = AnimateButton(abilityButtonDeliverPart, toAlpha);
				flag = true;
			}
			if (abilityButtonActivatePart.activeSelf)
			{
				tweenAlpha = AnimateButton(abilityButtonActivatePart, toAlpha);
				flag = true;
			}
			if (abilityButtonTierFullPart.activeSelf)
			{
				tweenAlpha = AnimateButton(abilityButtonTierFullPart, toAlpha);
				flag = true;
			}
			if (abilityButtonMaxPart.activeSelf)
			{
				tweenAlpha = AnimateButton(abilityButtonMaxPart, toAlpha);
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

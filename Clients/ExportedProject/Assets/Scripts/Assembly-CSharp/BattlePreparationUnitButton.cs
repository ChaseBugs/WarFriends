using System;
using System.Collections;
using UnityEngine;

public class BattlePreparationUnitButton : Core_BaseScript
{
	[Header("Core")]
	public GameObject armyButton;

	public UISprite unitIcon;

	[Header("-Sale Part")]
	public GameObject armySalePart;

	public UILabel armySalePercent;

	public UISprite armySaleTimeBackground;

	public WinStreakCounter armySaleTimeCounter;

	[Header("-New Unlock")]
	public GameObject unlockedUnitPart;

	public UITable unlockedUnitTable;

	public UILabel unlockedUnitNewLabel;

	public UISprite unlockedUnitNewBackground;

	public UILabel unlockedUnit;

	[Header("-Delivering Part")]
	public GameObject deliveringUnitPart;

	public UISprite progressUnit;

	public UILabel progressUnitLabel;

	[Header("-Notification")]
	public UILabel notificationArmyNumber;

	public GameObject notificationArmyGO;

	private RadicalRoutine mUpdatingUnit;

	private int mLastRemainingTimeUnit;

	private LevelBehaviour mBehaviour;

	private bool mDefendersBuyable;

	private bool mDefendersUpgradeable;

	private bool mRushersBuyable;

	private bool mRushersUpgradeable;

	private bool mShootersBuyable;

	private bool mShootersUpgradeable;

	private bool mExplosivesBuyable;

	private bool mExplosivesUpgradeable;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(armyButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		});
		unlockedUnitTable.onReposition = delegate
		{
			float val = 0f - unlockedUnitTable.padding.x - (unlockedUnit.transform.parent.localPosition.x - unlockedUnitTable.padding.x) / 2f;
			unlockedUnitTable.transform.localPosition = unlockedUnitTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void InitGUIValues()
	{
		SetArmyButton();
		NotificationArmy(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
	}

	public void DoAfterHide()
	{
		StopUnitUpdate();
	}

	public void SaleUnits()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.DiscountedUnitOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, OfferBuyType.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, OfferBuyType.Upgrade);
		int num5 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerRusher, OfferBuyType.Buy);
		int num6 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerRusher, OfferBuyType.Upgrade);
		int num7 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerShooter, OfferBuyType.Buy);
		int num8 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerShooter, OfferBuyType.Upgrade);
		int num9 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, OfferBuyType.Buy);
		int num10 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, OfferBuyType.Upgrade);
		bool flag = num > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed;
		bool flag2 = num2 > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		CheckBuyableAndUpgradeable();
		bool flag3 = num3 > 0 && mDefendersBuyable;
		bool flag4 = num4 > 0 && mDefendersUpgradeable;
		bool flag5 = num5 > 0 && mRushersBuyable;
		bool flag6 = num6 > 0 && mRushersUpgradeable;
		bool flag7 = num7 > 0 && mShootersBuyable;
		bool flag8 = num8 > 0 && mShootersUpgradeable;
		bool flag9 = num9 > 0 && mExplosivesBuyable;
		bool flag10 = num10 > 0 && mExplosivesUpgradeable;
		bool flag11 = num3 > 0 && num5 > 0 && num7 > 0 && num9 > 0;
		bool flag12 = num4 > 0 && num6 > 0 && num8 > 0 && num10 > 0;
		bool flag13 = flag11 && (mDefendersBuyable || mRushersBuyable || mShootersBuyable || mExplosivesBuyable);
		bool flag14 = flag12 && (mDefendersUpgradeable || mRushersUpgradeable || mShootersUpgradeable || mExplosivesUpgradeable);
		bool flag15 = !flag13 && (flag3 || flag5 || flag7 || flag9);
		bool flag16 = !flag14 && (flag4 || flag6 || flag8 || flag10);
		armySalePart.SetActive(flag || flag2 || flag13 || flag14 || flag15 || flag16);
		if (flag13 || flag14)
		{
			armySalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag13) ? num4 : num3);
			armySaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime(), upperCaseCountdown: true);
			WinStreakCounter winStreakCounter = armySaleTimeCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SaleUnits));
			WinStreakCounter winStreakCounter2 = armySaleTimeCounter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SaleUnits));
			armySaleTimeBackground.transform.localScale = armySaleTimeBackground.transform.localScale.ReplaceX(130f);
		}
		else if (flag15 || flag16)
		{
			armySaleTimeCounter.StopCountingTo();
			WinStreakCounter winStreakCounter3 = armySaleTimeCounter;
			winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SaleUnits));
			if (flag3 || flag4)
			{
				armySalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag3) ? num4 : num3);
				armySaleTimeCounter.counterLabel.text = Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.Defender].Value1);
			}
			else if (flag5 || flag6)
			{
				armySalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag5) ? num6 : num5);
				armySaleTimeCounter.counterLabel.text = Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerRusher].Value1);
			}
			else if (flag7 || flag8)
			{
				armySalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag7) ? num8 : num7);
				armySaleTimeCounter.counterLabel.text = Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerShooter].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					armySalePercent.text = string.Empty;
					armySaleTimeCounter.counterLabel.text = string.Empty;
					armySaleTimeBackground.transform.localScale = armySaleTimeBackground.transform.localScale.ReplaceX(130f);
					return;
				}
				armySalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag9) ? num10 : num9);
				armySaleTimeCounter.counterLabel.text = Localization.Localize(GameVariables.unitType[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			float num11 = armySaleTimeCounter.counterLabel.relativeSize.x * armySaleTimeCounter.counterLabel.transform.localScale.x;
			armySaleTimeBackground.transform.localScale = armySaleTimeBackground.transform.localScale.ReplaceX(num11 + 40f);
		}
		else if (flag || flag2)
		{
			armySalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag) ? num2 : num);
			armySaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime(), upperCaseCountdown: true);
			WinStreakCounter winStreakCounter4 = armySaleTimeCounter;
			winStreakCounter4.winStreakTimer = (Action)Delegate.Remove(winStreakCounter4.winStreakTimer, new Action(SaleUnits));
			WinStreakCounter winStreakCounter5 = armySaleTimeCounter;
			winStreakCounter5.winStreakTimer = (Action)Delegate.Combine(winStreakCounter5.winStreakTimer, new Action(SaleUnits));
			armySaleTimeBackground.transform.localScale = armySaleTimeBackground.transform.localScale.ReplaceX(130f);
		}
		else
		{
			armySaleTimeCounter.StopCountingTo();
			WinStreakCounter winStreakCounter6 = armySaleTimeCounter;
			winStreakCounter6.winStreakTimer = (Action)Delegate.Remove(winStreakCounter6.winStreakTimer, new Action(SaleUnits));
			armySaleTimeBackground.transform.localScale = armySaleTimeBackground.transform.localScale.ReplaceX(130f);
		}
	}

	private void CheckBuyableAndUpgradeable()
	{
		mDefendersBuyable = false;
		mDefendersUpgradeable = false;
		mRushersBuyable = false;
		mRushersUpgradeable = false;
		mShootersBuyable = false;
		mShootersUpgradeable = false;
		mExplosivesBuyable = false;
		mExplosivesUpgradeable = false;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				mDefendersBuyable |= behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed;
				mDefendersUpgradeable |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				mRushersBuyable |= behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed;
				mRushersUpgradeable |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				mShootersBuyable |= behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed;
				mShootersUpgradeable |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				mExplosivesBuyable |= behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed;
				mExplosivesUpgradeable |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	public void InitBlank()
	{
		unlockedUnitPart.SetActive(value: false);
		deliveringUnitPart.SetActive(value: false);
		NotificationArmy(0);
	}

	private void StartUnitUpdate()
	{
		StopUnitUpdate();
		mUpdatingUnit = RadicalRoutine.Create(UpdateUnitRoutine());
		StartCoroutine(RadicalRoutine.Run(mUpdatingUnit.enumerator));
	}

	private void StopUnitUpdate()
	{
		if (mUpdatingUnit != null)
		{
			mUpdatingUnit.Cancel();
			mUpdatingUnit = null;
		}
	}

	private IEnumerator UpdateUnitRoutine()
	{
		while (mBehaviour.upgradeSlots.remainingDeliveringSeconds > 0.0)
		{
			progressUnit.fillAmount = mBehaviour.upgradeSlots.progressDelivering;
			progressUnit.color = Colours.cyan;
			SetUpDeliveringUnitLabel((int)mBehaviour.upgradeSlots.remainingDeliveringSeconds);
			yield return new WaitForRealSeconds(0.333f);
		}
		progressUnit.fillAmount = 1f;
		progressUnit.color = Colours.blue;
		progressUnitLabel.text = ((mBehaviour.upgradeSlots.unitState != UpgradeSlots.State.UnitDelivered) ? Localization.Localize((!mBehaviour.isSoldier) ? "ID_UPGRADED" : "ID_TRAINED") : Localization.Localize("ID_PURCHASED"));
		progressUnitLabel.alpha = 1f;
		TweenAlpha.Begin(progressUnitLabel.gameObject, 0.01f, 1f);
		NotificationArmy(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
	}

	private void SetUpDeliveringUnitLabel(int remainingTime, bool instant = false)
	{
		if (mLastRemainingTimeUnit > remainingTime)
		{
			mLastRemainingTimeUnit = remainingTime;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(remainingTime, ref progressUnitLabel, instant);
		}
	}

	private void NotificationArmy(int number)
	{
		notificationArmyGO.SetActive(number > 0);
		notificationArmyNumber.text = MiscTools.FormatBigNumber(number);
	}

	public void SetUpUnitLook(LevelBehaviour unit)
	{
		unitIcon.spriteName = unit.upgradeSlots.iconName;
		unitIcon.MakePixelPerfect();
		unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(1.25f);
		Vector3 localPosition = unitIcon.transform.localPosition;
		localPosition.y = unit.prepareForBattleIconPositionY;
		unitIcon.transform.localPosition = localPosition;
	}

	private void SetArmyButton()
	{
		StopUnitUpdate();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			unlockedUnitPart.SetActive(value: false);
			deliveringUnitPart.SetActive(value: true);
			SetUpUnitLook(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.Delivered || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivered)
			{
				mLastRemainingTimeUnit = 0;
				progressUnit.fillAmount = 1f;
				progressUnit.color = Colours.blue;
				progressUnitLabel.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.State.UnitDelivered) ? Localization.Localize((!levelBehaviour.isSoldier) ? "ID_UPGRADED" : "ID_TRAINED") : Localization.Localize("ID_PURCHASED"));
				progressUnitLabel.alpha = 1f;
				TweenAlpha.Begin(progressUnitLabel.gameObject, 0.01f, 1f);
			}
			else
			{
				mLastRemainingTimeUnit = int.MaxValue;
				progressUnit.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				progressUnit.color = Colours.cyan;
				SetUpDeliveringUnitLabel((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds, instant: true);
				mBehaviour = levelBehaviour;
				StartUnitUpdate();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				unlockedUnitPart.SetActive(value: true);
				deliveringUnitPart.SetActive(value: false);
				SetUpUnitLook(levelBehaviour);
				unlockedUnit.text = levelBehaviour.unitName.ToUpperInvariant();
				MiscTools.SetUILabelRescale(unlockedUnit, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 88);
				float val = 16f + unlockedUnitNewLabel.relativeSize.x * unlockedUnitNewLabel.transform.localScale.x;
				unlockedUnitNewBackground.transform.localScale = unlockedUnitNewBackground.transform.localScale.ReplaceX(val);
				unlockedUnitTable.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				unlockedUnitPart.SetActive(value: false);
				deliveringUnitPart.SetActive(value: false);
				SetUpUnitLook(levelBehaviour);
			}
		}
	}
}

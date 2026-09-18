using System;
using UnityEngine;

public class ArmyRightContent : Core_BaseScript
{
	[Header("Content")]
	public UITable rightTable;

	[Header("-Deploy Statistics")]
	public GameObject deployStatisticsPart;

	public GameObject[] deployCostObjects;

	public UILabel deployCooldownLabel;

	[Header("-Army Unit Type")]
	public UILabel armyUnitTypeName;

	public UISprite armyUnitTypeBackground;

	public UISprite armyUnitTypeIcon;

	public UILabel armyUnitTypeDescription;

	public UILabel armyUnitDescription;

	[Header("-Army Rating - Unit Power")]
	public UILabel armyRatingLabel;

	public UILabel armyRatingMax;

	public BoxCollider armyRatingHintButton;

	public UISprite armyRatingHintBackground;

	public UILabel armyRatingCurrent;

	public UILabel armyRatingUpgrade;

	public UISprite armyRatingUpgradeBox;

	public UILabel armyRatingMaxedLabel;

	public UILabel armyRatingUpgradeAbility;

	public UISprite armyRatingUpgradeAbilityBox;

	public UILabel armyRatingAbilityMaxedLabel;

	public UILabel armyRatingUpgradeElite;

	public UISprite armyRatingUpgradeEliteBox;

	public UILabel armyRatingEliteMaxedLabel;

	public UILabel armyRatingSpecialLabel;

	public UISprite armyRatingSpecialIcon;

	public UILabel armyRatingBuffLabel;

	public UISprite armyRatingBuffIcon;

	public UISprite armyRatingBuffIconSmall;

	[Header("--Army Hint Statistics")]
	public BoxCollider armyHintBackground;

	public UIPanel armyHintPanel;

	public UILabel unitHintTitle;

	public UITable unitEnergyTable;

	public UILabel unitEnergyCost;

	public UISprite[] unitEnergyCostSprites;

	public UILabel unitDeployCooldown;

	public UILabel unitDeployAmount;

	public UILabel unitSpecificTitle;

	public UILabel unitSpecificLabel;

	public UILabel unitSpecificValue;

	public UILabel unitShotDamageName;

	public UILabel unitShotDamage;

	public UILabel unitRateOfFire;

	public UILabel unitAccuracy;

	public UILabel unitShotSpeed;

	public UILabel unitMovementSpeed;

	[Header("-Button")]
	public GameObject buttonPart;

	public UIButton rightButton;

	public BoxCollider rightButtonCollider;

	[Header("--Locked")]
	public GameObject buttonLockedPart;

	public UILabel lockedTillLevel;

	[Header("--Buy")]
	public GameObject buttonBuyPart;

	public UITable prizeTable;

	public UISprite warbucksIcon;

	public UISprite goldIcon;

	public UILabel buyUnitPrize;

	[Header("---Sale Part")]
	public GameObject salePart;

	public UILabel salePercent;

	public WinStreakCounter saleTimeCounter;

	[Header("--Deliver Now")]
	public GameObject buttonDeliverNowPart;

	public UILabel time1;

	public UILabel time2;

	public UISprite deliveringProgress;

	public UITable deliverPrizeTable;

	public UILabel deliverUnitPrize;

	[Header("--Activate")]
	public GameObject buttonActivatePart;

	private LevelBehaviour mUnit;

	private int mLastRemainingTime;

	private float mDur = 0.3f;

	private bool mShowedStats;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(rightButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(RightButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(armyRatingHintButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ArmyHintButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(armyHintBackground.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(StatisticsBackgroundClick));
		prizeTable.onReposition = delegate
		{
			float val = 0f - prizeTable.padding.x - (buyUnitPrize.transform.parent.transform.localPosition.x - prizeTable.padding.x) / 2f;
			prizeTable.transform.localPosition = prizeTable.transform.localPosition.ReplaceX(val);
		};
		rightTable.onReposition = delegate
		{
			armyHintPanel.transform.position = armyRatingHintButton.transform.position;
			float num = armyRatingLabel.relativeSize.x * armyRatingLabel.transform.localScale.x + 20f;
			num += armyRatingMax.relativeSize.x * armyRatingMax.transform.localScale.x + 20f + armyRatingHintBackground.transform.localScale.x / 2f;
			armyHintPanel.transform.localPosition = new Vector3(armyHintPanel.transform.localPosition.x + num, armyHintPanel.transform.localPosition.y + 4f, -24000f);
		};
		deliverPrizeTable.onReposition = delegate
		{
			float val = 0f - deliverPrizeTable.padding.x - (deliverUnitPrize.transform.parent.transform.localPosition.x - deliverPrizeTable.padding.x) / 2f;
			deliverPrizeTable.transform.localPosition = deliverPrizeTable.transform.localPosition.ReplaceX(val);
		};
		InstaHideHintStats();
	}

	public void StatisticsBackgroundClick(GameObject go)
	{
		HideHintStats(go == armyHintBackground.gameObject);
	}

	public void DoAfterHide()
	{
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
		InstaHideHintStats();
	}

	private void RightButtonClick(GameObject go)
	{
		switch (mUnit.upgradeSlots.unitState)
		{
		case UpgradeSlots.State.Locked:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: LOCKED\t\tbutton type: LEVEL UP");
			LevelManager.instance.DebugAddLevel();
			break;
		case UpgradeSlots.State.NotBuyed:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: NOT BOUGHT\t\tbutton type: BUY UNIT");
			BuyUnitClick();
			break;
		case UpgradeSlots.State.UnitDelivering:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER");
			DeliverNowUnitClick();
			GuiScreenSingle<ArmyScreen>.instance.circleCreator.deliveringAnimation = false;
			break;
		case UpgradeSlots.State.UnitDelivered:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT");
			ActivateUnitClick();
			GuiScreenSingle<ArmyScreen>.instance.circleCreator.PlayEndAnimation();
			break;
		default:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - should not happen");
			break;
		}
	}

	private void BuyUnitClick()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Buy);
		int num2 = mUnit.upgradeSlots.price * (100 - num) / 100;
		int num3 = mUnit.upgradeSlots.priceGold * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to buy {mUnit.upgradeSlots.GetSheetName()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mUnit.unitName);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Buy_Units";
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num3, mUnit.unitName);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Buy_Units";
			return;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			if (mUnit.upgradeSlots.priceGold > 0)
			{
				Debug.Log("Buying army unit for gold possible even when already upgrading");
			}
			else if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivered)
			{
				GuiScreenSingle<ArmyScreen>.instance.ActivateUnit(levelBehaviour);
			}
			else
			{
				if (levelBehaviour.upgradeSlots.unitState != UpgradeSlots.State.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogUnits(levelBehaviour, mUnit, isNextAbility: false);
					return;
				}
				GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(levelBehaviour, showAnimation: false);
			}
		}
		Singleton<Wallet>.instance.WarBucksSpentFake(num2);
		Singleton<Wallet>.instance.GoldSpentFake(num3);
		GuiScreenSingle<ArmyScreen>.instance.BuyUnit(mUnit, num);
	}

	private void DeliverNowUnitClick()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(mUnit.upgradeSlots.instantUnitDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(mUnit.upgradeSlots.instantUnitDeliveryPrice, mUnit.unitName, NotEnoughDialog.Type.DELIVER);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Unit_Upgrade";
		}
		else
		{
			Singleton<Wallet>.instance.GoldSpentFake(mUnit.upgradeSlots.instantUnitDeliveryPrice);
			GuiScreenSingle<ArmyScreen>.instance.InstantBuyUnit(mUnit);
		}
	}

	private void ActivateUnitClick()
	{
		GuiScreenSingle<ArmyScreen>.instance.ActivateUnit(mUnit);
	}

	public void SelectUnit(LevelBehaviour selectedUnit)
	{
		mUnit = selectedUnit;
		armyUnitTypeName.text = Localization.Localize(mUnit.unitTypeName);
		armyUnitTypeIcon.spriteName = mUnit.unitTypeIcon;
		armyUnitTypeIcon.MakePixelPerfect();
		armyUnitTypeDescription.text = Localization.Localize(mUnit.unitTypeDescription);
		armyUnitDescription.text = mUnit.unitDescription;
		float num = armyUnitDescription.relativeSize.y * armyUnitDescription.transform.localScale.y;
		armyUnitTypeBackground.transform.localScale = armyUnitTypeBackground.transform.localScale.ReplaceY(154f + num);
		rightTable.repositionNow = true;
		unitHintTitle.text = Localization.LocalizeFormat("ID_UNITDETAILEDSTATISTICS", mUnit.unitName.ToUpper());
		unitEnergyCost.text = Localization.LocalizeFormat("ID_ENERGYCOSTPERUNIT", Colours.stringWhite, mUnit.upgradeSlots.totalPower);
		for (int i = 0; i < unitEnergyCostSprites.Length; i++)
		{
			unitEnergyCostSprites[i].gameObject.SetActive(i < mUnit.upgradeSlots.totalPower);
		}
		unitEnergyTable.repositionNow = true;
		unitDeployCooldown.text = Localization.LocalizeFormat("ID_DEPLOYCOOLDOWNPERUNIT", Colours.stringWhite, MiscTools.FormatNumberAsSeconds(mUnit.upgradeSlots.coolDown));
		unitDeployAmount.text = Localization.LocalizeFormat("ID_DEPLOYAMOUNT", Colours.stringWhite, mUnit.upgradeSlots.spawns);
		bool flag = Singleton<GameVariables>.instance.isiPadResolution || mUnit.upgradeSlots.bought;
		deployStatisticsPart.SetActive(flag);
		if (flag)
		{
			for (int j = 0; j < deployCostObjects.Length; j++)
			{
				deployCostObjects[j].SetActive(j < mUnit.upgradeSlots.totalPower);
			}
			deployCooldownLabel.text = MiscTools.FormatNumberAsSeconds(mUnit.upgradeSlots.coolDown);
		}
	}

	public void UpdateRightContent(bool changedUnit = true)
	{
		if (changedUnit)
		{
			TweenPosition.Begin(rightButton.gameObject, mDur, rightButton.transform.localPosition.ReplaceX(25f));
			ChangeRightContent();
		}
		else if (mUnit.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed || mUnit.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivering || mUnit.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivered)
		{
			TweenPosition.Begin(rightButton.gameObject, mDur, rightButton.transform.localPosition.ReplaceX(705f)).onFinished = delegate
			{
				ChangeRightContent();
				TweenPosition.Begin(rightButton.gameObject, mDur, rightButton.transform.localPosition.ReplaceX(25f));
			};
		}
		else if (mUnit.upgradeSlots.unitState == UpgradeSlots.State.Active && (buttonDeliverNowPart.activeSelf || buttonActivatePart.activeSelf || buttonBuyPart.activeSelf))
		{
			TweenPosition.Begin(rightButton.gameObject, mDur, rightButton.transform.localPosition.ReplaceX(705f));
			TweenAlpha.Begin(rightTable.gameObject, mDur, 0f).onFinished = delegate
			{
				ChangeRightContent();
				TweenAlpha.Begin(rightTable.gameObject, mDur, 1f);
				rightButton.transform.localPosition = rightButton.transform.localPosition.ReplaceX(25f);
			};
		}
		else
		{
			UpdateUpgradableInformations();
		}
	}

	private void UpdateUpgradableInformations()
	{
		UpgradeSlots upgradeSlots = mUnit.upgradeSlots;
		UpgradeSlots.State unitState = upgradeSlots.unitState;
		int armyPowerX = upgradeSlots.armyPowerX10;
		int armyPowerX10Max = upgradeSlots.armyPowerX10Max;
		int armyPowerX2 = upgradeSlots.upgradeSlotSpecial.armyPowerX10;
		int armyPowerX3 = upgradeSlots.upgradeSlotElite.armyPowerX10;
		bool allUpgradesBought = upgradeSlots.allUpgradesBought;
		bool isMaxUpgraded = upgradeSlots.upgradeSlot.isMaxUpgraded;
		bool isMaxUpgraded2 = upgradeSlots.upgradeSlotSpecial.isMaxUpgraded;
		bool isUnlocked = upgradeSlots.upgradeSlotElite.isUnlocked;
		bool flag = isUnlocked && upgradeSlots.upgradeSlotElite.isMaxUpgraded;
		bool isBought = upgradeSlots.upgradeSlotSpecial.isBought;
		bool flag2 = isUnlocked && upgradeSlots.upgradeSlotElite.isBought;
		bool flag3 = unitState == UpgradeSlots.State.Active || unitState == UpgradeSlots.State.Delivered || unitState == UpgradeSlots.State.Delivering;
		bool flag4 = !isMaxUpgraded && !upgradeSlots.borrowed && flag3;
		bool flag5 = !isMaxUpgraded2 && isBought && !upgradeSlots.borrowed && flag3;
		bool flag6 = isUnlocked && !flag && flag2;
		bool flag7 = unitState == UpgradeSlots.State.Delivering;
		bool flag8 = flag7 && upgradeSlots.upgradeSlot.isDelivering;
		bool flag9 = flag7 && upgradeSlots.upgradeSlotSpecial.isDelivering;
		armyRatingCurrent.text = MiscTools.FormatBigNumber(armyPowerX);
		armyRatingSpecialLabel.gameObject.SetActive(isBought);
		armyRatingSpecialIcon.gameObject.SetActive(isBought);
		if (isBought)
		{
			armyRatingSpecialLabel.text = MiscTools.FormatBigNumber(armyPowerX2);
			armyRatingSpecialIcon.spriteName = mUnit.abilityIcon;
		}
		armyRatingBuffLabel.gameObject.SetActive(flag2);
		armyRatingBuffIcon.gameObject.SetActive(flag2);
		armyRatingBuffIconSmall.gameObject.SetActive(flag2);
		if (flag2)
		{
			armyRatingBuffLabel.text = MiscTools.FormatBigNumber(armyPowerX3);
			mUnit.SetUpEliteIcon(armyRatingBuffIcon, armyRatingBuffIconSmall);
		}
		armyRatingMax.text = ((!allUpgradesBought) ? Localization.LocalizeFormat("ID_MAXSTAT", MiscTools.FormatBigNumber(armyPowerX10Max)) : string.Empty);
		armyRatingUpgrade.text = ((!flag4) ? string.Empty : MiscTools.FormatFloatNumberSigned(upgradeSlots.armyPowerX10NextSlot - armyPowerX));
		armyRatingUpgradeAbility.text = ((!flag5) ? string.Empty : MiscTools.FormatFloatNumberSigned(upgradeSlots.armyPowerX10NextSpecialSlot - armyPowerX));
		armyRatingUpgradeElite.text = ((!flag6) ? string.Empty : MiscTools.FormatFloatNumberSigned(upgradeSlots.armyPowerX10NextEliteSlot - armyPowerX));
		if (flag8)
		{
			TweenColor component = armyRatingUpgrade.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			armyRatingUpgrade.color = Colours.greenDelivering;
		}
		else
		{
			armyRatingUpgrade.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(armyRatingUpgrade.gameObject, 0.6f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.PingPong;
		}
		if (flag9)
		{
			TweenColor component2 = armyRatingUpgradeAbility.gameObject.GetComponent<TweenColor>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			armyRatingUpgradeAbility.color = Colours.greenDelivering;
		}
		else
		{
			armyRatingUpgradeAbility.color = Colours.yellowUpgradeAnim1;
			TweenColor tweenColor2 = TweenColor.Begin(armyRatingUpgradeAbility.gameObject, 0.6f, Colours.yellowUpgradeAnim1, Colours.yellowUpgradeAnim2);
			tweenColor2.NumOfRepetitions = 0;
			tweenColor2.style = UITweener.Style.PingPong;
		}
		armyRatingUpgradeElite.color = Colours.greenUpgradeAnim1;
		TweenColor tweenColor3 = TweenColor.Begin(armyRatingUpgradeElite.gameObject, 0.6f, Colours.greenUpgradeAnim1, Colours.greenUpgradeAnim2);
		tweenColor3.NumOfRepetitions = 0;
		tweenColor3.style = UITweener.Style.PingPong;
		armyRatingMaxedLabel.gameObject.SetActive(isMaxUpgraded);
		armyRatingAbilityMaxedLabel.gameObject.SetActive(isMaxUpgraded2);
		armyRatingEliteMaxedLabel.gameObject.SetActive(flag);
		DeliveringAnimation(armyRatingUpgradeBox, flag8, flag8 || isMaxUpgraded);
		DeliveringAnimation(armyRatingUpgradeAbilityBox, flag9, flag9 || isMaxUpgraded2);
		DeliveringAnimation(armyRatingUpgradeEliteBox, play: false, flag);
		float num = armyRatingLabel.relativeSize.x * armyRatingLabel.transform.localScale.x + 20f;
		float val = armyRatingLabel.transform.localPosition.x + num;
		float num2 = armyRatingMax.relativeSize.x * armyRatingMax.transform.localScale.x;
		num += ((!(num2 > 0f)) ? 0f : (num2 + 20f));
		num += armyRatingHintBackground.transform.localScale.x / 2f;
		armyRatingMax.transform.localPosition = armyRatingMax.transform.localPosition.ReplaceX(val);
		armyRatingHintBackground.transform.localPosition = armyRatingHintBackground.transform.localPosition.ReplaceX(num);
		bool flag10 = upgradeSlots.unitSpecifics.Count > 0;
		bool flag11 = flag10 && upgradeSlots.isSpecificTime;
		unitSpecificTitle.gameObject.SetActive(flag10);
		unitSpecificLabel.text = ((!flag10) ? string.Empty : Localization.Localize(upgradeSlots.unitSpecifics[0].Value1));
		unitSpecificValue.text = ((!flag10) ? string.Empty : ((!flag11) ? MiscTools.FormatFloatNumberRoundZeroOrOne(upgradeSlots.unitSpecifics[0].Value2) : MiscTools.FormatNumberAsSeconds(upgradeSlots.unitSpecifics[0].Value2)));
		unitShotDamageName.text = upgradeSlots.shotDamageName;
		unitShotDamage.text = ((!(upgradeSlots.damage >= 0f)) ? Localization.Localize("ID_NA") : MiscTools.FormatFloatNumberRoundZeroOrOne(upgradeSlots.damage));
		unitRateOfFire.text = ((!(upgradeSlots.rateOfFire >= 0f)) ? Localization.Localize("ID_NA") : MiscTools.FormatNumberPerMinute(upgradeSlots.rateOfFire));
		unitAccuracy.text = ((!(upgradeSlots.accuracy >= 0f)) ? Localization.Localize("ID_NA") : MiscTools.FormatFloatNumberAsPercent(upgradeSlots.accuracy));
		unitShotSpeed.text = ((!(upgradeSlots.bulletSpeed >= 0f)) ? Localization.Localize("ID_NA") : MiscTools.FormatFloatNumberRoundZeroOrOne(upgradeSlots.bulletSpeed));
		unitMovementSpeed.text = ((!(upgradeSlots.movementSpeed >= 0f)) ? Localization.Localize("ID_NA") : MiscTools.FormatFloatNumberRoundZeroOrOne(upgradeSlots.movementSpeed));
	}

	private void DeliveringAnimation(UISprite sprite, bool play, bool show)
	{
		sprite.color = Color.white;
		if (!play)
		{
			TweenAlpha component = sprite.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			sprite.alpha = 1f;
			TweenScale component2 = sprite.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			sprite.transform.localScale = new Vector3(104f, 74f, 1f);
		}
		else
		{
			float num = 0.5f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(sprite.gameObject, 2f * num, 1f, 0f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(sprite.gameObject, 2f * num, new Vector3(104f, 74f, 1f), new Vector3(208f, 148f, 1f));
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		sprite.gameObject.SetActive(show);
	}

	private void ChangeRightContent()
	{
		UpgradeSlots.State unitState = mUnit.upgradeSlots.unitState;
		UpdateUpgradableInformations();
		buttonLockedPart.SetActive(unitState == UpgradeSlots.State.Locked);
		lockedTillLevel.text = Localization.LocalizeFormat("ID_GUI_UNLOCKEDAT", Colours.stringBlue, mUnit.upgradeSlots.unlockLevel.displayNumber);
		buttonBuyPart.SetActive(unitState == UpgradeSlots.State.NotBuyed);
		warbucksIcon.gameObject.SetActive(mUnit.upgradeSlots.price > 0);
		goldIcon.gameObject.SetActive(mUnit.upgradeSlots.priceGold > 0);
		SetSaleAndPrize();
		buttonDeliverNowPart.SetActive(unitState == UpgradeSlots.State.UnitDelivering);
		deliverUnitPrize.text = string.Empty;
		TweenAlpha component = time1.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		time1.alpha = 1f;
		TweenAlpha component2 = time2.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		time2.alpha = 0f;
		buttonActivatePart.SetActive(unitState == UpgradeSlots.State.UnitDelivered);
		rightButtonCollider.enabled = unitState != UpgradeSlots.State.Locked;
		UpdateCollider(unitState);
		buttonPart.SetActive(buttonLockedPart.activeSelf || buttonBuyPart.activeSelf || buttonDeliverNowPart.activeSelf || buttonActivatePart.activeSelf);
		rightTable.repositionNow = true;
		rightTable.transform.localPosition = rightTable.transform.localPosition.ReplaceY((!buttonPart.activeSelf) ? 312f : 270f);
	}

	public void SetSaleAndPrize()
	{
		if (!mUnit.upgradeSlots.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Buy);
			int num2 = mUnit.upgradeSlots.price + mUnit.upgradeSlots.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			buyUnitPrize.text = MiscTools.FormatBigNumber(num2);
			prizeTable.repositionNow = true;
			salePart.SetActive(flag);
			if (flag)
			{
				salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				saleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedUnitEndtime(mUnit, OfferBuyType.Buy), upperCaseCountdown: true);
				WinStreakCounter winStreakCounter = saleTimeCounter;
				winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetSaleAndPrize));
				WinStreakCounter winStreakCounter2 = saleTimeCounter;
				winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SetSaleAndPrize));
			}
			else
			{
				saleTimeCounter.StopCountingTo();
				WinStreakCounter winStreakCounter3 = saleTimeCounter;
				winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SetSaleAndPrize));
			}
		}
	}

	private void UpdateCollider(UpgradeSlots.State unitState)
	{
		switch (unitState)
		{
		case UpgradeSlots.State.Locked:
		case UpgradeSlots.State.UnitDelivering:
			rightButtonCollider.center = rightButtonCollider.center.ReplaceY(15f);
			rightButtonCollider.size = rightButtonCollider.size.ReplaceY(205f);
			break;
		case UpgradeSlots.State.NotBuyed:
		case UpgradeSlots.State.UnitDelivered:
			rightButtonCollider.center = rightButtonCollider.center.ReplaceY(0f);
			rightButtonCollider.size = rightButtonCollider.size.ReplaceY(180f);
			break;
		default:
			rightButtonCollider.center = rightButtonCollider.center.ReplaceY(0f);
			rightButtonCollider.size = rightButtonCollider.size.ReplaceY(1f);
			break;
		}
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		remainingTime = ((!(remainingTime > 0f)) ? 0f : remainingTime);
		deliveringProgress.fillAmount = Mathf.Clamp01(progress);
		time1.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
		string text = MiscTools.FormatBigNumber(mUnit.upgradeSlots.instantUnitDeliveryPrice);
		if (deliverUnitPrize.text != text)
		{
			deliverUnitPrize.text = text;
			deliverPrizeTable.repositionNow = true;
		}
		int num = MiscTools.RoundToInt(remainingTime);
		if (mLastRemainingTime == num)
		{
			return;
		}
		mLastRemainingTime = num;
		int num2 = MiscTools.RoundToInt(remainingTime % 6f);
		if (num2 == 2 && (time1.alpha == 0f || time2.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(time2.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(time1.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (time2.alpha == 0f || time1.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(time1.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(time2.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	public void AnimateUnitPower()
	{
		TweenScale tweenScale = TweenScale.Begin(armyRatingCurrent.gameObject, GuiScreenSingle<WeaponScreen>.instance.upgradeDur * 4f, new Vector3(62f, 62f, 1f), new Vector3(112f, 112f, 1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void ArmyHintButtonClick(GameObject go)
	{
		if (mShowedStats)
		{
			HideHintStats();
		}
		else
		{
			ShowHintStats();
		}
	}

	private void ShowHintStats()
	{
		if (!armyHintPanel.gameObject.activeSelf)
		{
			armyRatingHintBackground.spriteName = MiscTools.closeButtonSprite;
			armyHintPanel.alpha1 = 0f;
			armyHintPanel.gameObject.SetActive(value: true);
			mShowedStats = true;
			SoundsManager.Instance.PlayButtonClickedSound();
		}
		TweenAlpha.Begin(armyHintPanel.gameObject, 0.2f, 1f).onFinished = null;
	}

	private void HideHintStats(bool playSound = true)
	{
		if (armyHintPanel.gameObject.activeSelf)
		{
			if (playSound)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
			}
			TweenAlpha.Begin(armyHintPanel.gameObject, 0.2f, 0f).onFinished = delegate
			{
				InstaHideHintStats();
			};
		}
	}

	private void InstaHideHintStats()
	{
		armyRatingHintBackground.spriteName = MiscTools.infoButtonSprite;
		armyHintPanel.gameObject.SetActive(value: false);
		mShowedStats = false;
	}
}

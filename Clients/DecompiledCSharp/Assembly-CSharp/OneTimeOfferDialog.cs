using System;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeOfferDialog : GuiElementSingle<OneTimeOfferDialog>, IGuiDialog
{
	private enum DialogType
	{
		Unit,
		Weapon,
		PowerBand,
		Currency
	}

	[Header("Header")]
	public UILabel title;

	[Header("Content")]
	public CircleProgress circleCreator;

	[Header("-Weapon")]
	public GameObject weaponPart;

	[Header("--Left")]
	public UILabel weaponName;

	public List<ProgressBarRecordRentalDialog> weaponProgressBarsRight;

	[Header("--Middle")]
	public UISprite weaponIcon;

	[Header("--Right")]
	public UISprite weaponTypeIco;

	public UILabel weaponTypeDescription;

	public UITable weaponPowerTable;

	public UILabel weaponPower;

	public GameObject weaponPowerComparePart;

	public UILabel weaponPowerCompareValue;

	public UISprite weaponPowerCompareBackground;

	[Header("-Unit")]
	public GameObject unitPart;

	[Header("--Left")]
	public UILabel unitName;

	public List<ProgressBarArmyRecordRentalDialog> unitProgressBarsLeft;

	public BoxCollider abilityHintButton;

	public UISprite abilityHintButtonBackground;

	public UIPanel abilityHintDialog;

	public BoxCollider abilityHintDialogCollider;

	public UISprite abilityBackground;

	public UITable abilityTable;

	public UISprite abilityIcon;

	public UILabel abilityTitle;

	public UILabel abilityDescription;

	public GameObject abilityBottomItem;

	[Header("--Middle")]
	public UISprite unitIcon;

	[Header("--Right")]
	public GameObject armyUnitTypeParent;

	public UILabel armyUnitTypeName;

	public UISprite armyUnitTypeBackground;

	public UISprite armyUnitTypeIcon;

	public UILabel armyUnitTypeDescription;

	public UILabel armyUnitDescription;

	[Header("-Power Band")]
	public GameObject powerBandPart;

	[Header("--Left")]
	public UITable powerBandTable;

	public UILabel powerBandName;

	public UITable powerBandBonusTable;

	public UILabel powerBandBonusLabel;

	public UISprite powerBandBonusIcon;

	[Header("--Middle")]
	public UISprite powerBandIcon;

	[Header("--Right")]
	public UITable powerBandDescriptionTable;

	public UISprite powerBandDescriptionIcon;

	public UILabel powerBandDescriptionLabel;

	public UILabel powerBandActiveFor;

	[Header("-Currency")]
	public GameObject currencyPart;

	public CircleProgress secondCircleCreator;

	public UISprite leftCurrencyIcon;

	public UILabel leftCurrencyValue;

	public UISprite rightCurrencyIcon;

	public UILabel rightCurrencyValue;

	[Header("Bottom")]
	public UIButton buttonNo;

	[Header("-Upgrade")]
	public UIButton buttonUpgrade;

	public UITable upgradePrizeTable;

	public UILabel upgradePrize;

	[Header("-Buy")]
	public UIButton buttonBuy;

	public UITable prizeTable;

	public UISprite warbucksIcon;

	public UISprite goldIcon;

	public UILabel buyPrize;

	[Header("Early Unlock")]
	public GameObject earlyUnlockLevelPart;

	public UILabel earlyUnlockLevel;

	public UILabel earlyUnlockMiddle1;

	public UILabel earlyUnlockMiddle2;

	[Header("On Sale")]
	public GameObject salePart;

	public UILabel salePercent;

	public UITable saleBottomTable;

	public GameObject saleGoldIcon;

	public GameObject saleWarbucksIcon;

	public StrikethroughPrize strikethroughSetter;

	public UILabel saleRegularPrize;

	private string mItemId;

	private int mDiscount;

	private bool mIsUpgrade;

	private int mRegularPrize;

	private int mSalePrize;

	private bool mIsWarbucks;

	private bool mIsGold;

	private DialogType mCurrentType;

	private WeaponLevelsSetup mWeapon;

	private LevelBehaviour mUnit;

	private PlayerVisual mPowerBand;

	private static Dictionary<DialogType, Vector3> mSalePosition = new Dictionary<DialogType, Vector3>
	{
		{
			DialogType.Unit,
			new Vector3(820f, 200f, -5f)
		},
		{
			DialogType.Weapon,
			new Vector3(440f, 200f, -5f)
		},
		{
			DialogType.PowerBand,
			new Vector3(440f, 200f, -5f)
		},
		{
			DialogType.Currency,
			new Vector3(760f, -75f, -5f)
		}
	};

	private static Dictionary<DialogType, Vector3> mEarlyUnlockPosition = new Dictionary<DialogType, Vector3>
	{
		{
			DialogType.Unit,
			new Vector3(820f, -64f, -5f)
		},
		{
			DialogType.Weapon,
			new Vector3(726f, 200f, -5f)
		},
		{
			DialogType.PowerBand,
			new Vector3(726f, 200f, -5f)
		},
		{
			DialogType.Currency,
			new Vector3(820f, -64f, -5f)
		}
	};

	public void ShowDialog(string itemID, int sale, bool isUpgrade = false)
	{
		mItemId = itemID;
		mDiscount = sale;
		mIsUpgrade = isUpgrade;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonNo.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NoClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonUpgrade.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(UpgradeClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(buttonBuy.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BuyClick));
		UIEventListener.Get(abilityHintButton.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (abilityHintDialog.gameObject.activeSelf)
			{
				HideAbilityHint();
			}
			else
			{
				ShowAbilityHint();
			}
		};
		UIEventListener.Get(abilityHintDialogCollider.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HideAbilityHint();
		};
		prizeTable.onReposition = delegate
		{
			float val = 0f - prizeTable.padding.x - (buyPrize.transform.parent.transform.localPosition.x - prizeTable.padding.x) / 2f;
			prizeTable.transform.localPosition = prizeTable.transform.localPosition.ReplaceX(val);
		};
		upgradePrizeTable.onReposition = delegate
		{
			float val = 0f - upgradePrizeTable.padding.x - (upgradePrize.transform.parent.transform.localPosition.x - prizeTable.padding.x) / 2f;
			upgradePrizeTable.transform.localPosition = upgradePrizeTable.transform.localPosition.ReplaceX(val);
		};
		saleBottomTable.onReposition = delegate
		{
			float val = 763f - saleRegularPrize.transform.parent.transform.localPosition.x;
			saleBottomTable.transform.localPosition = saleBottomTable.transform.localPosition.ReplaceX(val);
		};
		abilityTable.onReposition = RepositedAbility;
		powerBandBonusTable.onReposition = delegate
		{
			powerBandTable.repositionNow = true;
		};
	}

	private void NoClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void UpgradeClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		if (mWeapon != null)
		{
			int num = mWeapon.upgradeSlots.upgradePrice * (100 - mDiscount) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, mWeapon.weaponName, NotEnoughDialog.Type.UPGRADE);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.WarBucksSpentFake(num);
				GuiScreenSingle<WeaponScreen>.instance.UpgradeWeaponUpgrade(mWeapon, mDiscount);
			}
		}
		else if (mUnit != null)
		{
			int num2 = mUnit.upgradeSlots.upgradeSlot.upgradePrice * (100 - mDiscount) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mUnit.unitName, (!mUnit.isSoldier) ? NotEnoughDialog.Type.UPGRADE : NotEnoughDialog.Type.TRAIN);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.WarBucksSpentFake(num2);
				GuiScreenSingle<ArmyScreen>.instance.UpgradeUnitUpgrade(mUnit, mDiscount);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void BuyClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		if (mWeapon != null)
		{
			int num = mWeapon.price * (100 - mDiscount) / 100;
			int num2 = mWeapon.priceGold * (100 - mDiscount) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, mWeapon.weaponName);
				flag = false;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, mWeapon.weaponName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.WarBucksSpentFake(num);
				Singleton<Wallet>.instance.GoldSpentFake(num2);
				GuiScreenSingle<WeaponScreen>.instance.BuyWeapon(mWeapon, mDiscount);
			}
		}
		else if (mUnit != null)
		{
			int num3 = mUnit.upgradeSlots.price * (100 - mDiscount) / 100;
			int num4 = mUnit.upgradeSlots.priceGold * (100 - mDiscount) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num3))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num3, mUnit.unitName);
				flag = false;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num4))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num4, mUnit.unitName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.WarBucksSpentFake(num3);
				Singleton<Wallet>.instance.GoldSpentFake(num4);
				GuiScreenSingle<ArmyScreen>.instance.BuyUnit(mUnit, mDiscount);
			}
		}
		else if (mPowerBand != null)
		{
			int num5 = mPowerBand.priceGold * (100 - mDiscount) / 100;
			if (!Singleton<Wallet>.instance.CanBuyGold(num5))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num5, mPowerBand.name);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.GoldSpentFake(num5);
				GuiScreenSingle<CamosScreen>.instance.BuyPlayerVisual(mPowerBand, mDiscount);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		ResetGui();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(mItemId))
		{
			InitializeWeapon(LevelManager.instance.Weapon(mItemId), mDiscount, mIsUpgrade);
			empty = MiscTools.FormatBigNumber(mSalePrize);
			empty2 = MiscTools.FormatBigNumber(mRegularPrize);
			empty3 = Localization.Localize((!mIsUpgrade) ? "ID_GETITCHEAPERNOW" : "ID_UPGRADEFORCHEAPER");
		}
		else if (LevelManager.instance.IsUnit(mItemId))
		{
			InitializeUnit(LevelManager.instance.Unit(mItemId), mDiscount, mIsUpgrade);
			empty = MiscTools.FormatBigNumber(mSalePrize);
			empty2 = MiscTools.FormatBigNumber(mRegularPrize);
			empty3 = Localization.Localize((!mIsUpgrade) ? "ID_GETITCHEAPERNOW" : "ID_UPGRADEFORCHEAPER");
		}
		else if (CamosManager.instance.IsPlayerVisual(mItemId) && CamosManager.instance.IsPowerBandIdPressent(mItemId))
		{
			InitializePowerBand(CamosManager.instance.GetPowerBand(mItemId), mDiscount);
			empty = MiscTools.FormatBigNumber(mSalePrize);
			empty2 = MiscTools.FormatBigNumber(mRegularPrize);
			empty3 = Localization.Localize((!mIsUpgrade) ? "ID_GETITCHEAPERNOW" : "ID_UPGRADEFORCHEAPER");
		}
		else
		{
			InitializeCurrency(0, 0);
			empty = "0$";
			empty2 = "0$";
			empty3 = Localization.Localize("ID_SPECIALDEALFORYOU");
		}
		InitializeSale(mDiscount, empty, empty2, mIsUpgrade);
		title.text = empty3;
		InstantHideAbilityHint();
	}

	private void ResetGui()
	{
		weaponPart.SetActive(value: false);
		unitPart.SetActive(value: false);
		powerBandPart.SetActive(value: false);
		currencyPart.SetActive(value: false);
		earlyUnlockLevelPart.SetActive(value: false);
		mWeapon = null;
		mUnit = null;
		mPowerBand = null;
		mIsWarbucks = false;
		mIsGold = false;
		mRegularPrize = 0;
		mSalePrize = 0;
		circleCreator.FillCircle(1f);
	}

	private void InitializeWeapon(WeaponLevelsSetup weapon, int discount, bool isUpgrade)
	{
		weaponPart.SetActive(value: true);
		mCurrentType = DialogType.Weapon;
		mWeapon = weapon;
		mRegularPrize = ((!isUpgrade) ? (weapon.price + weapon.priceGold) : weapon.upgradeSlots.upgradePrice);
		mIsWarbucks = isUpgrade || weapon.price > 0;
		mIsGold = !isUpgrade && weapon.priceGold > 0;
		mSalePrize = mRegularPrize * (100 - discount) / 100;
		int displayNumber = weapon.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		int index = 0;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & weapon.weaponCategory) == weapon.weaponCategory)
			{
				index = i;
			}
		}
		weaponName.text = weapon.weaponName.ToUpper();
		weaponProgressBarsRight[0].InitializeStat(weapon, PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup, 0);
		weaponProgressBarsRight[1].InitializeStat(weapon, PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup, 1);
		weaponProgressBarsRight[2].InitializeStat(weapon, PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup, 2);
		weaponIcon.spriteName = weapon.playerWeapon.iconName;
		weaponIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(500f / weaponIcon.transform.localScale.x, 460f / weaponIcon.transform.localScale.y);
		weaponIcon.transform.localScale = weaponIcon.transform.localScale.MultiplyXY(multiplier);
		weaponTypeIco.spriteName = PlayerInventory.instance.inventorySlots[index].iconName;
		weaponTypeIco.MakePixelPerfect();
		weaponTypeDescription.text = Localization.Localize(GameVariables.weaponCategoryIdRental[weapon.weaponCategory]);
		int weaponPowerX = weapon.weaponPowerX10;
		int weaponPowerX2 = PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup.weaponPowerX10;
		int num = Mathf.Max(0, weaponPowerX - weaponPowerX2);
		Debug.Log($"Weapon Power This: {weaponPowerX},   Equipped {PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup.weaponName}: {weaponPowerX2},   Difference: {num}");
		weaponPower.text = MiscTools.FormatBigNumber(weaponPowerX);
		weaponPowerComparePart.SetActive(num > 0);
		if (num > 0)
		{
			weaponPowerCompareValue.text = $"+{MiscTools.FormatBigNumber(num)}";
			weaponPowerCompareBackground.transform.localScale = weaponPowerCompareBackground.transform.localScale.ReplaceX(weaponPowerCompareValue.relativeSize.x * weaponPowerCompareValue.transform.localScale.x + 16f);
		}
		weaponPowerTable.repositionNow = true;
		earlyUnlockLevelPart.SetActive(flag);
		if (flag)
		{
			earlyUnlockLevel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MiscTools.SetUILabelRescale(earlyUnlockLevel, 30f, 20f, 142);
		}
	}

	private void InitializeUnit(LevelBehaviour unit, int discount, bool isUpgrade)
	{
		unitPart.SetActive(value: true);
		mCurrentType = DialogType.Unit;
		mUnit = unit;
		mRegularPrize = ((!isUpgrade) ? (unit.upgradeSlots.price + unit.upgradeSlots.priceGold) : unit.upgradeSlots.upgradeSlot.upgradePrice);
		mIsWarbucks = isUpgrade || unit.upgradeSlots.price > 0;
		mIsGold = !isUpgrade && unit.upgradeSlots.priceGold > 0;
		mSalePrize = mRegularPrize * (100 - discount) / 100;
		int displayNumber = unit.upgradeSlots.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		unitName.text = unit.unitName;
		unitProgressBarsLeft[0].InitializeStat(unit);
		unitProgressBarsLeft[1].InitializeStat(unit, attack: false);
		unitProgressBarsLeft[2].InitializeAbility(unit);
		SetCorrectAbilityHintIcon();
		abilityTitle.text = mUnit.unitAbilityName;
		abilityDescription.text = mUnit.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		abilityTable.repositionNow = true;
		unitIcon.spriteName = unit.upgradeSlots.iconName;
		unitIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(500f / unitIcon.transform.localScale.x, 460f / unitIcon.transform.localScale.y);
		unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(multiplier);
		armyUnitTypeName.text = Localization.Localize(mUnit.unitTypeName);
		armyUnitTypeIcon.spriteName = mUnit.unitTypeIcon;
		armyUnitTypeIcon.MakePixelPerfect();
		armyUnitTypeDescription.text = Localization.Localize(mUnit.unitTypeDescription);
		armyUnitDescription.text = mUnit.unitDescription;
		float num = 154f + armyUnitDescription.relativeSize.y * armyUnitDescription.transform.localScale.y;
		armyUnitTypeBackground.transform.localScale = armyUnitTypeBackground.transform.localScale.ReplaceY(num);
		armyUnitTypeParent.transform.localPosition = armyUnitTypeParent.transform.localPosition.ReplaceY(-180f + num);
		earlyUnlockLevelPart.SetActive(flag);
		if (flag)
		{
			earlyUnlockLevel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MiscTools.SetUILabelRescale(earlyUnlockLevel, 30f, 20f, 142);
		}
	}

	private void InitializePowerBand(PlayerVisual powerBand, int discount)
	{
		powerBandPart.SetActive(value: true);
		mCurrentType = DialogType.PowerBand;
		mPowerBand = powerBand;
		mRegularPrize = powerBand.priceWarbucks + powerBand.priceGold;
		mIsWarbucks = powerBand.priceWarbucks > 0;
		mIsGold = powerBand.priceGold > 0;
		mSalePrize = mRegularPrize * (100 - discount) / 100;
		int displayNumber = powerBand.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		powerBandName.text = powerBand.name.ToUpperInvariant();
		powerBandBonusTable.repositionNow = true;
		powerBandBonusIcon.spriteName = powerBand.decalMiniIcon;
		powerBandBonusIcon.MakePixelPerfect();
		powerBandBonusIcon.transform.localScale = powerBandBonusIcon.transform.localScale.MultiplyXY(1.5f);
		powerBandBonusIcon.color = powerBand.decalMiniIconColor;
		powerBandBonusLabel.text = powerBand.decalValueString;
		powerBandIcon.spriteName = powerBand.icon;
		powerBandIcon.MakePixelPerfect();
		powerBandIcon.transform.localScale = powerBandIcon.transform.localScale.MultiplyXY(1.5f);
		powerBandDescriptionTable.repositionNow = true;
		powerBandDescriptionIcon.spriteName = powerBand.decalMiniIcon;
		powerBandDescriptionIcon.MakePixelPerfect();
		powerBandDescriptionIcon.color = powerBand.decalMiniIconColor;
		powerBandDescriptionLabel.text = ((powerBand.decalType != 0) ? string.Empty : " ") + "    " + powerBand.description;
		powerBandActiveFor.text = Localization.LocalizeFormat("ID_GUI_POWERBANDON", Colours.stringBlue + MiscTools.FormatFloatNumberRoundZeroOrOne((float)powerBand.timeActive / 3600f));
		earlyUnlockLevelPart.SetActive(flag);
		if (flag)
		{
			earlyUnlockLevel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MiscTools.SetUILabelRescale(earlyUnlockLevel, 30f, 20f, 142);
		}
	}

	private void InitializeCurrency(int warbucks, int gold)
	{
		currencyPart.SetActive(value: true);
		mCurrentType = DialogType.Currency;
		leftCurrencyValue.text = MiscTools.FormatBigNumber(warbucks);
		rightCurrencyValue.text = MiscTools.FormatBigNumber(gold);
		secondCircleCreator.FillCircle(1f);
	}

	private void InitializeSale(int discount, string currentPrize, string previousPrize, bool isUpgrade = false)
	{
		salePart.transform.localPosition = mSalePosition[mCurrentType];
		earlyUnlockLevelPart.transform.localPosition = mEarlyUnlockPosition[mCurrentType];
		if (earlyUnlockLevelPart.activeSelf)
		{
			earlyUnlockMiddle1.text = Localization.Localize("ID_EARLYUNLOCK1");
			MiscTools.SetUILabelRescale(earlyUnlockMiddle1, 52f, 20f, 200);
			earlyUnlockMiddle2.text = Localization.Localize("ID_EARLYUNLOCK2");
			MiscTools.SetUILabelRescale(earlyUnlockMiddle2, 42f, 20f, 168);
		}
		buttonUpgrade.gameObject.SetActive(isUpgrade);
		buttonBuy.gameObject.SetActive(!isUpgrade);
		salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENT", discount);
		MiscTools.SetUILabelRescale(salePercent, 58f, 20f, 260);
		if (isUpgrade)
		{
			upgradePrize.text = currentPrize;
			upgradePrizeTable.repositionNow = true;
		}
		else
		{
			warbucksIcon.gameObject.SetActive(mIsWarbucks);
			goldIcon.gameObject.SetActive(mIsGold);
			buyPrize.text = currentPrize;
			prizeTable.repositionNow = true;
		}
		saleRegularPrize.text = previousPrize;
		saleGoldIcon.SetActive(mIsGold);
		saleWarbucksIcon.SetActive(mIsWarbucks);
		strikethroughSetter.SetUpStrikeThrought();
		saleBottomTable.repositionNow = true;
	}

	private void SetCorrectAbilityHintIcon()
	{
		if (abilityHintDialog.gameObject.activeSelf)
		{
			abilityIcon.spriteName = mUnit.abilityIcon;
			abilityIcon.MakePixelPerfect();
		}
	}

	private void RepositedAbility()
	{
		float num = Mathf.Abs(abilityBottomItem.transform.localPosition.y);
		abilityTable.transform.localPosition = abilityTable.transform.localPosition.ReplaceY(num + 30f);
		abilityBackground.transform.localScale = abilityBackground.transform.localScale.ReplaceY(num + 60f);
		abilityHintDialogCollider.center = abilityHintDialogCollider.center.ReplaceY(num / 2f + 30f);
		abilityHintDialogCollider.size = abilityHintDialogCollider.size.ReplaceY(num + 60f);
	}

	private void ShowAbilityHint()
	{
		abilityHintButtonBackground.spriteName = MiscTools.closeButtonSprite;
		abilityHintButtonBackground.MakePixelPerfect();
		abilityHintDialog.gameObject.SetActive(value: true);
		abilityHintDialog.alpha1 = 0.005f;
		SetCorrectAbilityHintIcon();
		TweenAlpha.Begin(abilityHintDialog.gameObject, 0.4f, 1f).onFinished = null;
		abilityHintDialog.transform.localPosition = new Vector3(478f, -180f, -5f);
		TweenPosition tweenPosition = TweenPosition.Begin(abilityHintDialog.gameObject, 0.25f, new Vector3(478f, -200f, -5f), new Vector3(478f, -170f, -5f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(abilityHintDialog.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideAbilityHint()
	{
		abilityHintButtonBackground.spriteName = MiscTools.infoButtonSprite;
		abilityHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(abilityHintDialog.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(abilityHintDialog.gameObject, 0.4f, new Vector3(478f, -180f, -5f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			InstantHideAbilityHint();
		};
	}

	private void InstantHideAbilityHint()
	{
		if (unitPart.activeSelf)
		{
			abilityHintButtonBackground.spriteName = MiscTools.infoButtonSprite;
			abilityHintButtonBackground.MakePixelPerfect();
		}
		abilityHintDialog.gameObject.SetActive(value: false);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		InstantHideAbilityHint();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		NoClick(buttonNo.gameObject);
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class RentalDialog : GuiElementSingle<RentalDialog>, IGuiDialog
{
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

	public GameObject powerBandTimeBox;

	public UILabel powerBandActiveFor;

	[Header("Bottom")]
	public UIButton buttonNo;

	public UIButton buttonTry;

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

	public GameObject saleBadge;

	public UILabel salePercent;

	public UITable saleBottomTable;

	public GameObject saleGoldIcon;

	public GameObject saleWarbucksIcon;

	public StrikethroughPrize strikethroughSetter;

	public UILabel saleRegularPrize;

	[Header("Animation")]
	public ArmyPowerAnimation armyPowerAnimation;

	private string mShowedItemID;

	private int mDiscount;

	private GameItem mRentalType;

	private bool mIsOnSale;

	private WeaponLevelsSetup mWeapon;

	private LevelBehaviour mUnit;

	private PlayerVisual mPowerBand;

	private int mSalePrize;

	private int mRegularPrize;

	private bool mIsWarbucks;

	private static Dictionary<GameItem, Vector3> mSalePosition = new Dictionary<GameItem, Vector3>
	{
		{
			GameItem.ArmyUnit,
			new Vector3(820f, 200f, -5f)
		},
		{
			GameItem.Weapon,
			new Vector3(440f, 200f, -5f)
		},
		{
			GameItem.PlayerVisual,
			new Vector3(440f, 200f, -5f)
		}
	};

	private static Dictionary<GameItem, Vector3> mEarlyUnlockPosition = new Dictionary<GameItem, Vector3>
	{
		{
			GameItem.ArmyUnit,
			new Vector3(820f, -64f, -5f)
		},
		{
			GameItem.Weapon,
			new Vector3(726f, 200f, -5f)
		},
		{
			GameItem.PlayerVisual,
			new Vector3(726f, 200f, -5f)
		}
	};

	public void ShowRentalDialog(string rentalID, int rentalDiscount, GameItem rentalType, bool isOnSale)
	{
		mShowedItemID = rentalID;
		mDiscount = rentalDiscount;
		mRentalType = rentalType;
		mIsOnSale = isOnSale;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonNo.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NoClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonTry.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(TryClick));
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
		saleBottomTable.onReposition = delegate
		{
			float val = 770f - saleRegularPrize.transform.parent.transform.localPosition.x;
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
			if (buttonBuy.gameObject.activeSelf)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Decline_Rental", mShowedItemID, -1, -1);
			}
			HideDialog();
		}
	}

	private void BuyClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			bool flag = false;
			switch (mRentalType)
			{
			case GameItem.Weapon:
				flag = LevelManager.instance.BuyRentalWeapon(mWeapon, mSalePrize);
				break;
			case GameItem.ArmyUnit:
				flag = LevelManager.instance.BuyRentalUnit(mUnit, mSalePrize);
				break;
			case GameItem.PlayerVisual:
				flag = LevelManager.instance.BuyRentalPowerBand(mPowerBand, mSalePrize);
				break;
			}
			if (flag)
			{
				Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Accept_Rental", mShowedItemID, mIsWarbucks ? mSalePrize : 0, (!mIsWarbucks) ? mSalePrize : 0);
				HideDialog();
			}
		}
	}

	private void TryClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.AcceptRentalOffer(buyDiscounted: false);
			switch (mRentalType)
			{
			case GameItem.Weapon:
				mWeapon.tryOutWeapon = true;
				LevelManager.instance.EquipRentalWeapon(mWeapon, onlyTry: true);
				break;
			case GameItem.ArmyUnit:
				mUnit.upgradeSlots.borrowed = true;
				LevelManager.instance.TryRentalUnit(mUnit);
				break;
			case GameItem.PlayerVisual:
				mPowerBand.tryOutVisual = true;
				LevelManager.instance.EquipRentalVisual(mPowerBand, onlyTry: true);
				break;
			}
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Try_Out_Rental", mShowedItemID, -1, -1);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		Initialize();
		armyPowerAnimation.InitializeAlphaZero();
		InstantHideAbilityHint();
		if (!mIsOnSale)
		{
			Singleton<EventTrackingManager>.instance.RegisterRentalEvent("Display_Rental", mShowedItemID, -1, -1);
		}
	}

	private void Initialize()
	{
		Debug.Log($"Rental Dialog called: type: \"{mRentalType}, \"ID: \"{mShowedItemID}\", discount: \"{mDiscount}%\", is sale: \"{mIsOnSale}\"");
		title.text = ((!mIsOnSale) ? Localization.Localize("ID_TRYFORFREE") : Localization.Localize("ID_ONETIMESPECIALOFFER"));
		title.color = ((!mIsOnSale) ? Colours.blue : Colours.goldTier);
		circleCreator.FillCircle(1f);
		ShowContent();
		switch (mRentalType)
		{
		case GameItem.Weapon:
			InitializeWeapon();
			break;
		case GameItem.ArmyUnit:
			InitializeUnit();
			break;
		case GameItem.PlayerVisual:
			InitializePowerBand();
			break;
		}
		saleBadge.transform.localPosition = mSalePosition[mRentalType];
		earlyUnlockLevelPart.transform.localPosition = mEarlyUnlockPosition[mRentalType];
		if (earlyUnlockLevelPart.activeSelf)
		{
			earlyUnlockMiddle1.text = Localization.Localize("ID_EARLYUNLOCK1");
			MiscTools.SetUILabelRescale(earlyUnlockMiddle1, 52f, 20f, 200);
			earlyUnlockMiddle2.text = Localization.Localize("ID_EARLYUNLOCK2");
			MiscTools.SetUILabelRescale(earlyUnlockMiddle2, 42f, 20f, 168);
		}
		InitializeSale();
	}

	private void ShowContent()
	{
		weaponPart.SetActive(mRentalType == GameItem.Weapon);
		unitPart.SetActive(mRentalType == GameItem.ArmyUnit);
		powerBandPart.SetActive(mRentalType == GameItem.PlayerVisual);
		salePart.SetActive(mIsOnSale);
		earlyUnlockLevelPart.SetActive(value: false);
	}

	private void InitializeWeapon()
	{
		mWeapon = LevelManager.instance.Weapon(mShowedItemID);
		if (mWeapon == null)
		{
			Debug.LogError($"Weapon {mShowedItemID} does not exists on client.");
			return;
		}
		mRegularPrize = mWeapon.price + mWeapon.priceGold;
		mIsWarbucks = mWeapon.price > 0;
		mSalePrize = MiscTools.RoundToInt((float)(mRegularPrize * (100 - mDiscount)) / 100f);
		int displayNumber = mWeapon.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		int index = 0;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & mWeapon.weaponCategory) == mWeapon.weaponCategory)
			{
				index = i;
			}
		}
		weaponName.text = mWeapon.weaponName.ToUpper();
		weaponProgressBarsRight[0].InitializeStat(mWeapon, PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup, 0);
		weaponProgressBarsRight[1].InitializeStat(mWeapon, PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup, 1);
		weaponProgressBarsRight[2].InitializeStat(mWeapon, PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup, 2);
		weaponIcon.spriteName = mWeapon.playerWeapon.iconName;
		weaponIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(500f / weaponIcon.transform.localScale.x, 460f / weaponIcon.transform.localScale.y);
		weaponIcon.transform.localScale = weaponIcon.transform.localScale.MultiplyXY(multiplier);
		weaponTypeIco.spriteName = PlayerInventory.instance.inventorySlots[index].iconName;
		weaponTypeIco.MakePixelPerfect();
		weaponTypeDescription.text = Localization.Localize(GameVariables.weaponCategoryIdRental[mWeapon.weaponCategory]);
		int weaponPowerX = mWeapon.weaponPowerX10;
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

	private void InitializeUnit()
	{
		mUnit = LevelManager.instance.Unit(mShowedItemID);
		if (mUnit == null)
		{
			Debug.LogError($"Unit {mShowedItemID} does not exists on client.");
			return;
		}
		mRegularPrize = mUnit.upgradeSlots.price + mUnit.upgradeSlots.priceGold;
		mIsWarbucks = mUnit.upgradeSlots.price > 0;
		mSalePrize = MiscTools.RoundToInt((float)(mRegularPrize * (100 - mDiscount)) / 100f);
		int displayNumber = mUnit.upgradeSlots.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		unitName.text = mUnit.unitName;
		unitProgressBarsLeft[0].InitializeStat(mUnit);
		unitProgressBarsLeft[1].InitializeStat(mUnit, attack: false);
		unitProgressBarsLeft[2].InitializeAbility(mUnit);
		SetCorrectAbilityHintIcon();
		abilityTitle.text = mUnit.unitAbilityName;
		abilityDescription.text = mUnit.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		abilityTable.repositionNow = true;
		unitIcon.spriteName = mUnit.upgradeSlots.iconName;
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

	private void InitializePowerBand()
	{
		mPowerBand = CamosManager.instance.GetPowerBand(mShowedItemID);
		if (mPowerBand == null)
		{
			Debug.LogError($"Power Band {mShowedItemID} does not exists on client.");
			return;
		}
		mRegularPrize = mPowerBand.priceWarbucks + mPowerBand.priceGold;
		mIsWarbucks = mPowerBand.priceWarbucks > 0;
		mSalePrize = MiscTools.RoundToInt((float)(mRegularPrize * (100 - mDiscount)) / 100f);
		int displayNumber = mPowerBand.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		powerBandName.text = mPowerBand.name.ToUpperInvariant();
		powerBandBonusTable.repositionNow = true;
		powerBandBonusIcon.spriteName = mPowerBand.decalMiniIcon;
		powerBandBonusIcon.MakePixelPerfect();
		powerBandBonusIcon.transform.localScale = powerBandBonusIcon.transform.localScale.MultiplyXY(1.5f);
		powerBandBonusIcon.color = mPowerBand.decalMiniIconColor;
		powerBandBonusLabel.text = mPowerBand.decalValueString;
		powerBandIcon.spriteName = mPowerBand.icon;
		powerBandIcon.MakePixelPerfect();
		powerBandIcon.transform.localScale = powerBandIcon.transform.localScale.MultiplyXY(1.5f);
		powerBandDescriptionTable.repositionNow = true;
		powerBandDescriptionIcon.spriteName = mPowerBand.decalMiniIcon;
		powerBandDescriptionIcon.MakePixelPerfect();
		powerBandDescriptionIcon.color = mPowerBand.decalMiniIconColor;
		powerBandDescriptionLabel.text = ((mPowerBand.decalType != 0) ? string.Empty : " ") + "    " + mPowerBand.description;
		powerBandActiveFor.text = Localization.LocalizeFormat("ID_GUI_POWERBANDON", Colours.stringBlue + MiscTools.FormatFloatNumberRoundZeroOrOne((float)mPowerBand.timeActive / 3600f));
		earlyUnlockLevelPart.SetActive(flag);
		if (flag)
		{
			earlyUnlockLevel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MiscTools.SetUILabelRescale(earlyUnlockLevel, 30f, 20f, 142);
		}
	}

	private void InitializeSale()
	{
		buttonTry.gameObject.SetActive(!mIsOnSale);
		buttonBuy.gameObject.SetActive(mIsOnSale);
		powerBandTimeBox.SetActive(mIsOnSale);
		if (mIsOnSale)
		{
			salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENT", mDiscount);
			MiscTools.SetUILabelRescale(salePercent, 58f, 20f, 130);
			warbucksIcon.gameObject.SetActive(mIsWarbucks);
			goldIcon.gameObject.SetActive(!mIsWarbucks);
			buyPrize.text = MiscTools.FormatBigNumber(mSalePrize);
			prizeTable.repositionNow = true;
			saleRegularPrize.text = MiscTools.FormatBigNumber(mRegularPrize);
			saleGoldIcon.SetActive(!mIsWarbucks);
			saleWarbucksIcon.SetActive(mIsWarbucks);
			strikethroughSetter.SetUpStrikeThrought();
			saleBottomTable.repositionNow = true;
		}
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
		mWeapon = null;
		mUnit = null;
		mPowerBand = null;
		armyPowerAnimation.StopAllAnimations();
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

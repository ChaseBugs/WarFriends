using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLeftContent : Core_BaseScript
{
	[Header("Header")]
	public UITable headerTable;

	[Header("-Line 1")]
	public UITable screenTable;

	public UILabel categoryName;

	[Header("-Line 2")]
	public UILabel weaponName;

	[Header("-Line 3")]
	public UITable levelTable;

	public UILabel weaponLevel;

	[Header("Statistics")]
	public List<WeaponStatProgressBar> progressBarsLeft;

	[Header("Button")]
	public GameObject leftCorner;

	public UIButton leftButton;

	public BoxCollider leftButtonCollider;

	[Header("-Empty")]
	public GameObject leftEmptyButtonPart;

	[Header("-Upgrade")]
	public GameObject leftUpgradeButtonPart;

	public UITable prizeTable;

	public UILabel prizeLabel;

	public UITable upgradeLevelTable;

	public UILabel newLevelAfterUpgrade;

	[Header("--Sale Part")]
	public GameObject salePart;

	public UILabel salePercent;

	public WinStreakCounter saleTimeCounter;

	[Header("-Deliver Now")]
	public GameObject leftDeliverNowButtonPart;

	public UILabel time1;

	public UILabel time2;

	public UISprite deliveringProgress;

	public UITable deliverPrizeTable;

	public UILabel deliverUpgradePrize;

	[Header("-Activate")]
	public GameObject leftActivateButtonPart;

	[Header("-Max")]
	public GameObject leftMaxButtonPart;

	[Header("-Rental")]
	public GameObject rentedButtonPart;

	[Header("-Minigun Upgrade")]
	public GameObject minigunUpgradePart;

	[Header("Animation")]
	public ArmyPowerAnimation armyPowerAnimation;

	private WeaponLevelsSetup mWeapon;

	private WeaponLevelsSetup mEquippedWeapon;

	private int mLastRemainingTime;

	private float mDur = 0.3f;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(leftButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LeftButtonClick));
		prizeTable.onReposition = delegate
		{
			float val = 0f - prizeTable.padding.x - (prizeLabel.transform.parent.transform.localPosition.x - prizeTable.padding.x) / 2f;
			prizeTable.transform.localPosition = prizeTable.transform.localPosition.ReplaceX(val);
		};
		screenTable.onReposition = OnRepositioned;
		levelTable.onReposition = OnRepositioned;
		deliverPrizeTable.onReposition = delegate
		{
			float val = 0f - deliverPrizeTable.padding.x - (deliverUpgradePrize.transform.parent.transform.localPosition.x - deliverPrizeTable.padding.x) / 2f;
			deliverPrizeTable.transform.localPosition = deliverPrizeTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void OnRepositioned()
	{
		headerTable.repositionNow = true;
	}

	public void DoAfterHide()
	{
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
	}

	private void LeftButtonClick(GameObject go)
	{
		if (mWeapon.tryOutWeapon)
		{
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon is rented - do nothing");
			return;
		}
		switch (mWeapon.weaponState)
		{
		case WeaponLevelsSetup.State.Active:
		{
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT ACTIVE\t\tbutton type: UPGRADE/MAX");
			int num = mWeapon.weaponLevel;
			int maxWeaponLevel = mWeapon.maxWeaponLevel;
			if (num < maxWeaponLevel)
			{
				UpgradeButtonClick();
			}
			break;
		}
		case WeaponLevelsSetup.State.Delivering:
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERING\t\tbutton type: DELIVER NOW");
			DeliverNowClick();
			break;
		case WeaponLevelsSetup.State.Delivered:
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERED\t\tbutton type: ACTIVATE");
			ActivationClick();
			break;
		default:
			Debug.Log("#PETER# Weapon Screen - LEFT BUTTON - weapon state: OTHER\t\tbutton type: EMPTY");
			break;
		}
	}

	private void UpgradeButtonClick()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(mWeapon, OfferBuyType.Upgrade);
		int num2 = mWeapon.upgradeSlots.upgradePrice * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to upgrade {mWeapon.GetSheetName()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mWeapon.weaponName, NotEnoughDialog.Type.UPGRADE);
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.WeaponDelivered)
			{
				GuiScreenSingle<WeaponScreen>.instance.ActivateWeapon(weaponLevelsSetup);
			}
			else
			{
				if (weaponLevelsSetup.weaponState != WeaponLevelsSetup.State.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogWeapons(weaponLevelsSetup, mWeapon);
					return;
				}
				GuiScreenSingle<WeaponScreen>.instance.ActivationWeaponUpgrade(weaponLevelsSetup, showAnimation: false);
			}
		}
		Singleton<Wallet>.instance.WarBucksSpentFake(num2);
		GuiScreenSingle<WeaponScreen>.instance.UpgradeWeaponUpgrade(mWeapon, num);
	}

	private void DeliverNowClick()
	{
		int instantBuyPrice = mWeapon.upgradeSlots.instantBuyPrice;
		if (!Singleton<Wallet>.instance.CanBuyGold(instantBuyPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(instantBuyPrice, mWeapon.weaponName, NotEnoughDialog.Type.DELIVER);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Weapon_Upgrade";
			return;
		}
		int armyPowerX = LevelManager.instance.armyPowerX10;
		Singleton<Wallet>.instance.GoldSpentFake(instantBuyPrice);
		GuiScreenSingle<WeaponScreen>.instance.DeliverNowWeaponUpgrade(mWeapon, showAnimation: true);
		AnimateArmyPower(armyPowerX);
		AnimateRestOfScreen();
	}

	private void ActivationClick()
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<WeaponScreen>.instance.ActivationWeaponUpgrade(mWeapon, showAnimation: true);
		AnimateArmyPower(armyPowerX);
		AnimateRestOfScreen();
	}

	public void SelectWeapon(WeaponLevelsSetup selectedWeapon)
	{
		mWeapon = selectedWeapon;
		PlayerInventory.InventorySlot inventorySlot = null;
		foreach (PlayerInventory.InventorySlot inventorySlot2 in PlayerInventory.instance.inventorySlots)
		{
			if (selectedWeapon.weaponCategory == (selectedWeapon.weaponCategory & inventorySlot2.category))
			{
				inventorySlot = inventorySlot2;
			}
		}
		mEquippedWeapon = PlayerInventory.instance.inventorySlots[inventorySlot.index].weaponLevelsSetup;
		categoryName.text = ((inventorySlot == null) ? Singleton<GameVariables>.instance.GetWeaponCategoryId(selectedWeapon.weaponCategory) : inventorySlot.name);
		screenTable.repositionNow = true;
		weaponName.text = mWeapon.weaponName.ToUpper();
		levelTable.repositionNow = true;
	}

	public void UpdateLeftContent(bool changedWeapon = true)
	{
		if (changedWeapon)
		{
			TweenPosition.Begin(leftCorner, mDur, new Vector3(60f, leftCorner.transform.localPosition.y, 0f));
			ChangeLeftContent();
		}
		else if (mWeapon.weaponState == WeaponLevelsSetup.State.Active || mWeapon.weaponState == WeaponLevelsSetup.State.Delivering || mWeapon.weaponState == WeaponLevelsSetup.State.Delivered)
		{
			TweenPosition.Begin(leftCorner, mDur, new Vector3(-620f, leftCorner.transform.localPosition.y, 0f)).onFinished = delegate
			{
				ChangeLeftContent();
				TweenPosition.Begin(leftCorner, mDur, new Vector3(60f, leftCorner.transform.localPosition.y, 0f));
			};
		}
		else
		{
			weaponLevel.text = $"{mWeapon.weaponLevel}{Colours.stringGray} / {mWeapon.maxWeaponLevel}";
		}
	}

	private void ChangeLeftContent()
	{
		WeaponLevelsSetup.State weaponState = mWeapon.weaponState;
		int num = mWeapon.weaponLevel;
		int maxWeaponLevel = mWeapon.maxWeaponLevel;
		weaponLevel.text = $"{num}{Colours.stringGray} / {maxWeaponLevel}";
		UpdateProgresses();
		leftActivateButtonPart.SetActive(weaponState == WeaponLevelsSetup.State.Delivered);
		leftDeliverNowButtonPart.SetActive(weaponState == WeaponLevelsSetup.State.Delivering);
		deliverUpgradePrize.text = string.Empty;
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
		leftUpgradeButtonPart.SetActive(num < maxWeaponLevel && weaponState == WeaponLevelsSetup.State.Active);
		SetSaleAndPrize();
		newLevelAfterUpgrade.text = (num + 1).ToString();
		upgradeLevelTable.repositionNow = true;
		bool flag = num == maxWeaponLevel && weaponState == WeaponLevelsSetup.State.Active;
		leftMaxButtonPart.SetActive(flag);
		bool flag2 = weaponState == WeaponLevelsSetup.State.Locked || weaponState == WeaponLevelsSetup.State.NotBuyed || weaponState == WeaponLevelsSetup.State.WeaponDelivering || weaponState == WeaponLevelsSetup.State.WeaponDelivered;
		leftEmptyButtonPart.SetActive(flag2);
		rentedButtonPart.SetActive(value: false);
		bool tryOutWeapon = mWeapon.tryOutWeapon;
		if (tryOutWeapon)
		{
			leftActivateButtonPart.SetActive(value: false);
			leftDeliverNowButtonPart.SetActive(value: false);
			leftUpgradeButtonPart.SetActive(value: false);
			leftMaxButtonPart.SetActive(value: false);
			leftEmptyButtonPart.SetActive(value: false);
			rentedButtonPart.SetActive(value: true);
			minigunUpgradePart.SetActive(value: false);
		}
		minigunUpgradePart.SetActive(value: false);
		bool flag3 = flag || flag2 || tryOutWeapon;
		leftButtonCollider.enabled = !flag3;
		UpdateButtonCollider(weaponState);
	}

	public void SetSaleAndPrize()
	{
		if (!mWeapon.bought)
		{
			return;
		}
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(mWeapon, OfferBuyType.Upgrade);
		int num2 = mWeapon.upgradeSlots.upgradePrice;
		bool flag = num > 0;
		if (flag)
		{
			num2 = num2 * (100 - num) / 100;
		}
		prizeLabel.text = MiscTools.FormatBigNumber(num2);
		prizeTable.repositionNow = true;
		salePart.SetActive(flag);
		if (flag)
		{
			salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			saleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(mWeapon, OfferBuyType.Upgrade), upperCaseCountdown: true);
			saleTimeCounter.winStreakTimer = delegate
			{
				SetSaleAndPrize();
			};
		}
		else
		{
			saleTimeCounter.StopCountingTo();
			saleTimeCounter.winStreakTimer = null;
		}
	}

	private void UpdateButtonCollider(WeaponLevelsSetup.State weaponState)
	{
		BoxCollider component = leftButton.GetComponent<BoxCollider>();
		component.size = new Vector3(580f, (weaponState != WeaponLevelsSetup.State.Delivering) ? 180f : 150f, 1f);
		component.center = new Vector3(0f, (weaponState != WeaponLevelsSetup.State.Delivering) ? 0f : (-15f), 0f);
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		remainingTime = ((!(remainingTime > 0f)) ? 0f : remainingTime);
		deliveringProgress.fillAmount = Mathf.Clamp01(progress);
		time1.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
		string text = MiscTools.FormatBigNumber(mWeapon.instantWeaponDeliveryPrice);
		if (deliverUpgradePrize.text != text)
		{
			deliverUpgradePrize.text = text;
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

	public void UpdateContentAfterEquip()
	{
		PlayerInventory.InventorySlot inventorySlot = null;
		foreach (PlayerInventory.InventorySlot inventorySlot2 in PlayerInventory.instance.inventorySlots)
		{
			if (mWeapon.weaponCategory == (mWeapon.weaponCategory & inventorySlot2.category))
			{
				inventorySlot = inventorySlot2;
			}
		}
		mEquippedWeapon = PlayerInventory.instance.inventorySlots[inventorySlot.index].weaponLevelsSetup;
		UpdateProgresses();
	}

	private void UpdateProgresses()
	{
		progressBarsLeft[0].InitializeStat(mWeapon, mEquippedWeapon, 0);
		progressBarsLeft[1].InitializeStat(mWeapon, mEquippedWeapon, 1);
		progressBarsLeft[2].InitializeStat(mWeapon, mEquippedWeapon, 2);
	}

	private void AnimateArmyPower(int previousArmyPowerX10)
	{
		if (mWeapon.GetSheetName() == mEquippedWeapon.GetSheetName())
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			armyPowerAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	private void AnimateRestOfScreen()
	{
		progressBarsLeft[0].AnimateStat();
		progressBarsLeft[1].AnimateStat();
		progressBarsLeft[2].AnimateStat();
		GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.AnimateWeaponPower();
		GuiScreenSingle<WeaponScreen>.instance.AnimateUpgrade();
	}
}

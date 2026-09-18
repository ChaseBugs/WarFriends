using System;
using UnityEngine;

public class WeaponRightContent : Core_BaseScript
{
	[Header("Weapon Detailed Stats")]
	public GameObject showButton;

	public UISprite hintButtonBackground;

	public UIPanel weaponHintPanel;

	public GameObject statsBackground;

	public UILabel weaponShotDamage;

	public UILabel weaponCriticalChance;

	public UILabel weaponBurstSize;

	public UILabel weaponTotalAmmo;

	public UILabel weaponAccuracy;

	public UILabel weaponRateOfFire;

	public UILabel weaponShotVelocity;

	[Header("Weapon Power")]
	public UILabel weaponPowerLabel;

	public UILabel weaponPower;

	public UILabel weaponMaxPower;

	public UILabel weaponUpgradePower;

	public UILabel weaponComparePower;

	public UISprite upgradeBorder;

	public UILabel maxText;

	[Header("Button")]
	public UIButton rightButton;

	public BoxCollider rightButtonCollider;

	[Header("-Locked")]
	public GameObject buttonLockedPart;

	public UILabel lockedTillLevel;

	[Header("-Buy")]
	public GameObject buttonBuyPart;

	public UITable prizeTable;

	public UISprite warbucksIcon;

	public UISprite goldIcon;

	public UILabel buyUnitPrize;

	[Header("--Sale Part")]
	public GameObject salePart;

	public UILabel salePercent;

	public WinStreakCounter saleTimeCounter;

	[Header("-Deliver Now")]
	public GameObject buttonDeliverNowPart;

	public UILabel time1;

	public UILabel time2;

	public UISprite deliveringProgress;

	public UITable deliverPrizeTable;

	public UILabel deliverUnitPrize;

	[Header("-Activate")]
	public GameObject buttonActivatePart;

	[Header("Pack Button")]
	public UIButton packButton;

	[Header("Equip Button")]
	public UIButton equipButton;

	public GameObject equipButtonOff;

	public UISprite equipButtonOnHighlight;

	public UISprite equipButtonOnIconInside;

	public UISprite equipButtonOnIconOutSide;

	public UILabel equipLabel;

	private WeaponLevelsSetup mWeapon;

	private WeaponLevelsSetup mEquippedWeapon;

	private int mLastRemainingTime;

	private float mDur = 0.3f;

	private bool mShowedStats;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(rightButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(RightButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(packButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PackButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(equipButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EquipWeaponClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(showButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HintButtonClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(statsBackground);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HintBackgroundClick));
		UITable uITable = prizeTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnPrizeTableReposition));
		UITable uITable2 = deliverPrizeTable;
		uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(OnDeliverPrizeTableReposition));
		InstaHideHintStats();
		weaponMaxPower.transform.localPosition = new Vector3(weaponPowerLabel.relativeSize.x * weaponPowerLabel.transform.localScale.x + 14f, weaponMaxPower.transform.localPosition.y, weaponMaxPower.transform.localPosition.z);
		InitializeEquipLabel();
	}

	private void OnPrizeTableReposition()
	{
		float val = 0f - prizeTable.padding.x - (buyUnitPrize.transform.parent.transform.localPosition.x - prizeTable.padding.x) / 2f;
		prizeTable.transform.localPosition = prizeTable.transform.localPosition.ReplaceX(val);
	}

	private void OnDeliverPrizeTableReposition()
	{
		float val = 0f - deliverPrizeTable.padding.x - (deliverUnitPrize.transform.parent.transform.localPosition.x - deliverPrizeTable.padding.x) / 2f;
		deliverPrizeTable.transform.localPosition = deliverPrizeTable.transform.localPosition.ReplaceX(val);
	}

	public void DoAfterHide()
	{
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
		InstaHideHintStats();
	}

	private void RightButtonClick(GameObject go)
	{
		switch (mWeapon.weaponState)
		{
		case WeaponLevelsSetup.State.Locked:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: LOCKED\t\tbutton type: LEVEL UP");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.State.NotBuyed:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: NOT BOUGHT\t\tbutton type: BUY UNIT");
			BuyWeaponClick();
			break;
		case WeaponLevelsSetup.State.WeaponDelivering:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER");
			DeliverNowWeaponClick();
			GuiScreenSingle<WeaponScreen>.instance.circleCreator.deliveringAnimation = false;
			break;
		case WeaponLevelsSetup.State.WeaponDelivered:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT");
			ActivateWeaponClick();
			GuiScreenSingle<WeaponScreen>.instance.circleCreator.PlayEndAnimation();
			break;
		default:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - should not happen");
			break;
		}
	}

	private void BuyWeaponClick()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(mWeapon, OfferBuyType.Buy);
		int num2 = mWeapon.price * (100 - num) / 100;
		int num3 = mWeapon.priceGold * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to buy {mWeapon.GetSheetName()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mWeapon.weaponName);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Buy_Weapons";
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num3, mWeapon.weaponName);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Buy_Weapons";
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			if (mWeapon.priceGold > 0)
			{
				Debug.Log("Weapon cost gold, we can buy it even if player is already upgrading");
			}
			else if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.WeaponDelivered)
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
		Singleton<Wallet>.instance.GoldSpentFake(num3);
		GuiScreenSingle<WeaponScreen>.instance.BuyWeapon(mWeapon, num);
	}

	private void DeliverNowWeaponClick()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(mWeapon.instantWeaponDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(mWeapon.instantWeaponDeliveryPrice, mWeapon.weaponName, NotEnoughDialog.Type.DELIVER);
			GuiElementSingle<InappScreen>.instance.routeToStore = "Weapon_Upgrade";
		}
		else
		{
			Singleton<Wallet>.instance.GoldSpentFake(mWeapon.instantWeaponDeliveryPrice);
			GuiScreenSingle<WeaponScreen>.instance.InstantBuyWeapon(mWeapon);
		}
	}

	private void ActivateWeaponClick()
	{
		GuiScreenSingle<WeaponScreen>.instance.ActivateWeapon(mWeapon);
	}

	private void EquipWeaponClick(GameObject go)
	{
		int num = -1;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & mWeapon.weaponCategory) == mWeapon.weaponCategory)
			{
				num = i;
			}
		}
		if (num == -1)
		{
			Debug.LogError("Player inventory got no slot for " + mWeapon.weaponCategory);
		}
		else if (!(PlayerInventory.instance.inventorySlots[num].weaponLevelsSetup == mWeapon))
		{
			GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(mWeapon, num);
		}
	}

	private void InitializeEquipLabel()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		equipLabel.text = text3;
		MiscTools.SetUILabelRescale(equipLabel, 57f, 20f, 294);
	}

	public void ShowEquipAnimation()
	{
		equipLabel.text = Localization.Localize("ID_GUI_EQUIPPED");
		float duration = 0.3f;
		TweenColor.Begin(equipLabel.gameObject, duration, Color.white);
		TweenAlphaHider.Begin(equipButtonOff, duration, 0f);
		TweenAlpha.Begin(equipButtonOnHighlight.gameObject, duration, 1f);
		TweenAlpha.Begin(equipButtonOnIconOutSide.gameObject, duration, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(equipButtonOnIconInside.gameObject, duration, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
		InitEquippedWeapon();
		UpdateWeaponPower();
		UpdateWeaponDetailedStats();
	}

	private void PackButtonClick(GameObject go)
	{
		if (mWeapon.purchasable == WeaponLevelsSetup.Purchasable.StarterPack)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.DialogType.STARTER_PACK);
		}
		else if (mWeapon.purchasable == WeaponLevelsSetup.Purchasable.ValuePack)
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
		}
		else if (mWeapon.purchasable == WeaponLevelsSetup.Purchasable.StarterAssignment)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<StarterAssignmentDialog>.instance, 0f);
		}
		else if (mWeapon.purchasableValue.StartsWith("elitepack") || mWeapon.purchasableValue.StartsWith("veteranpack"))
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(SpecialPackContent.CreatePackFromId(mWeapon.purchasableValue));
		}
		else
		{
			Debug.LogError($"Weapon {mWeapon.name} is purchasable through {mWeapon.purchasable}");
		}
	}

	private void HintButtonClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mShowedStats)
		{
			HideHintStats();
		}
		else
		{
			ShowHintStats();
		}
	}

	private void HintBackgroundClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHintStats();
	}

	private void ShowHintStats()
	{
		if (!weaponHintPanel.gameObject.activeSelf)
		{
			hintButtonBackground.spriteName = MiscTools.closeButtonSprite;
			weaponHintPanel.alpha1 = 0f;
			weaponHintPanel.gameObject.SetActive(value: true);
			mShowedStats = true;
		}
		TweenAlpha.Begin(weaponHintPanel.gameObject, 0.2f, 1f).onFinished = null;
	}

	private void HideHintStats()
	{
		if (weaponHintPanel.gameObject.activeSelf)
		{
			TweenAlpha.Begin(weaponHintPanel.gameObject, 0.2f, 0f).onFinished = delegate
			{
				InstaHideHintStats();
			};
		}
	}

	private void InstaHideHintStats()
	{
		hintButtonBackground.spriteName = MiscTools.infoButtonSprite;
		weaponHintPanel.gameObject.SetActive(value: false);
		mShowedStats = false;
	}

	public void SelectWeapon(WeaponLevelsSetup selectedWeapon)
	{
		mWeapon = selectedWeapon;
		PlayerInventory.InventorySlot inventorySlot = InitEquippedWeapon();
		InitEquipButton(inventorySlot != null && inventorySlot.weaponLevelsSetup == selectedWeapon);
		UpdateWeaponPower();
		UpdateWeaponDetailedStats();
	}

	public void InitEquipButton(bool isEquipedWeapon)
	{
		equipLabel.text = ((!isEquipedWeapon) ? Localization.Localize("ID_GUI_EQUIP") : Localization.Localize("ID_GUI_EQUIPPED"));
		equipLabel.color = ((!isEquipedWeapon) ? Color.black : Color.white);
		TweenAlphaHider.Begin(equipButtonOff, 0f, (!isEquipedWeapon) ? 1f : 0f);
		equipButtonOnHighlight.alpha = ((!isEquipedWeapon) ? 0f : 1f);
		equipButtonOnIconInside.alpha = ((!isEquipedWeapon) ? 0f : 1f);
		equipButtonOnIconOutSide.alpha = ((!isEquipedWeapon) ? 0f : 0.16f);
		if (!isEquipedWeapon)
		{
			TweenAlpha.Begin(equipButtonOnIconInside.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	public void UpdateRightContent(bool changedWeapon = true)
	{
		if (changedWeapon)
		{
			TweenPosition.Begin(rightButton.gameObject, mDur, new Vector3(265f, rightButton.transform.localPosition.y, 0f));
			ChangeRightContent();
			return;
		}
		if (mWeapon.weaponState == WeaponLevelsSetup.State.NotBuyed || mWeapon.weaponState == WeaponLevelsSetup.State.WeaponDelivering || mWeapon.weaponState == WeaponLevelsSetup.State.WeaponDelivered)
		{
			TweenPosition.Begin(rightButton.gameObject, mDur, new Vector3(885f, rightButton.transform.localPosition.y, 0f)).onFinished = delegate
			{
				ChangeRightContent();
				TweenPosition.Begin(rightButton.gameObject, mDur, new Vector3(265f, rightButton.transform.localPosition.y, 0f));
			};
		}
		else if (mWeapon.weaponState == WeaponLevelsSetup.State.Active && packButton.gameObject.activeSelf)
		{
			TweenPosition.Begin(packButton.gameObject, mDur, new Vector3(885f, packButton.transform.localPosition.y, 0f)).onFinished = delegate
			{
				rightButton.transform.localPosition = new Vector3(885f, rightButton.transform.localPosition.y, 0f);
				ChangeRightContent();
				TweenPosition.Begin(rightButton.gameObject, mDur, new Vector3(265f, rightButton.transform.localPosition.y, 0f));
				packButton.transform.localPosition = new Vector3(265f, packButton.transform.localPosition.y, 0f);
			};
		}
		else if (mWeapon.weaponState == WeaponLevelsSetup.State.Active && (buttonDeliverNowPart.activeSelf || buttonActivatePart.activeSelf || buttonBuyPart.activeSelf))
		{
			TweenPosition.Begin(rightButton.gameObject, mDur, new Vector3(885f, rightButton.transform.localPosition.y, 0f)).onFinished = delegate
			{
				equipButton.transform.localPosition = new Vector3(885f, equipButton.transform.localPosition.y, 0f);
				InitEquippedWeapon();
				ChangeRightContent();
				TweenPosition.Begin(equipButton.gameObject, mDur, new Vector3(265f, equipButton.transform.localPosition.y, 0f));
				rightButton.transform.localPosition = new Vector3(265f, rightButton.transform.localPosition.y, 0f);
			};
		}
		UpdateWeaponPower();
		UpdateWeaponDetailedStats();
	}

	private void UpdateWeaponPower()
	{
		int weaponPowerX = mWeapon.weaponPowerX10;
		int weaponPowerX10Max = mWeapon.weaponPowerX10Max;
		bool flag = !mWeapon.canBeUpgraded;
		bool flag2 = !flag && !mWeapon.tryOutWeapon && (mWeapon.weaponState == WeaponLevelsSetup.State.Active || mWeapon.weaponState == WeaponLevelsSetup.State.Delivered || mWeapon.weaponState == WeaponLevelsSetup.State.Delivering);
		bool flag3 = mWeapon.weaponState == WeaponLevelsSetup.State.Delivering;
		SetWeaponPower(MiscTools.FormatBigNumber(weaponPowerX));
		weaponMaxPower.text = ((!flag) ? Localization.LocalizeFormat("ID_MAXSTAT", MiscTools.FormatBigNumber(weaponPowerX10Max)) : string.Empty);
		float num = weaponPowerLabel.relativeSize.x * weaponPowerLabel.transform.localScale.x + 14f;
		num += weaponMaxPower.relativeSize.x * weaponMaxPower.transform.localScale.x + 14f;
		num += hintButtonBackground.transform.localScale.x / 2f;
		hintButtonBackground.transform.localPosition = new Vector3(num, hintButtonBackground.transform.localPosition.y, hintButtonBackground.transform.localPosition.z);
		float z = weaponHintPanel.transform.localPosition.z;
		weaponHintPanel.transform.position = hintButtonBackground.transform.position;
		weaponHintPanel.transform.localPosition = new Vector3(weaponHintPanel.transform.localPosition.x, weaponHintPanel.transform.localPosition.y + 4f, z);
		weaponUpgradePower.gameObject.SetActive(flag2);
		maxText.gameObject.SetActive(flag);
		if (flag2)
		{
			if (flag3)
			{
				TweenColor component = weaponUpgradePower.gameObject.GetComponent<TweenColor>();
				if (component != null)
				{
					component.enabled = false;
				}
				weaponUpgradePower.color = Colours.greenDelivering;
			}
			else
			{
				weaponUpgradePower.color = Colours.blueUpgradeAnim1;
				TweenColor tweenColor = TweenColor.Begin(weaponUpgradePower.gameObject, 0.6f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = UITweener.Style.PingPong;
			}
			weaponUpgradePower.text = MiscTools.FormatFloatNumberSigned(mWeapon.weaponPowerX10Next - weaponPowerX);
		}
		if (mWeapon == mEquippedWeapon || mEquippedWeapon == null)
		{
			weaponComparePower.gameObject.SetActive(value: false);
			weaponPower.color = Colours.blue;
			weaponMaxPower.color = Colours.gray;
		}
		else
		{
			int num2 = weaponPowerX - mEquippedWeapon.weaponPowerX10;
			int num3 = weaponPowerX10Max - mEquippedWeapon.weaponPowerX10Max;
			weaponComparePower.gameObject.SetActive(value: true);
			weaponComparePower.text = MiscTools.FormatFloatNumberSigned(num2);
			weaponComparePower.color = ((num2 == 0) ? Colours.blue : ((num2 <= 0) ? Colours.redWeaponStats : Colours.greenWeaponStats));
			weaponPower.color = weaponComparePower.color;
			weaponMaxPower.color = ((num3 == 0) ? Colours.blue : ((num3 <= 0) ? Colours.redWeaponStats : Colours.greenWeaponStats));
		}
		DeliveringAnimation(upgradeBorder, flag3, flag3 || flag, new Vector3(104f, 74f, 1f), new Vector3(208f, 148f, 1f));
	}

	private void UpdateWeaponDetailedStats()
	{
		weaponShotDamage.text = MiscTools.FormatFloatNumberRoundZeroOrOne(mWeapon.shotDamage);
		weaponShotDamage.color = MiscTools.CompareStats(mWeapon.shotDamage, (!(mEquippedWeapon == null)) ? mEquippedWeapon.shotDamage : mWeapon.shotDamage);
		weaponCriticalChance.text = MiscTools.FormatFloatNumberAsPercent(mWeapon.critical);
		weaponCriticalChance.color = MiscTools.CompareStats(mWeapon.critical, (!(mEquippedWeapon == null)) ? mEquippedWeapon.critical : mWeapon.critical);
		weaponBurstSize.text = MiscTools.FormatBigNumber(mWeapon.burstSize);
		weaponBurstSize.color = MiscTools.CompareStats(mWeapon.burstSize, (!(mEquippedWeapon == null)) ? mEquippedWeapon.burstSize : mWeapon.burstSize);
		weaponTotalAmmo.text = MiscTools.FormatBigNumber(mWeapon.totalAmmo);
		weaponTotalAmmo.color = MiscTools.CompareStats(mWeapon.totalAmmo, (!(mEquippedWeapon == null)) ? mEquippedWeapon.totalAmmo : mWeapon.totalAmmo);
		weaponAccuracy.text = MiscTools.FormatFloatNumberAsPercent(mWeapon.accuracy);
		weaponAccuracy.color = MiscTools.CompareStats(mWeapon.accuracy, (!(mEquippedWeapon == null)) ? mEquippedWeapon.accuracy : mWeapon.accuracy);
		weaponRateOfFire.text = ((!(mWeapon.rateOfFirePerMinute >= 0f)) ? Localization.Localize("ID_NA") : MiscTools.FormatNumberPerMinute(mWeapon.rateOfFirePerMinute));
		weaponRateOfFire.color = MiscTools.CompareStats(mWeapon.rateOfFirePerMinute, (!(mEquippedWeapon == null)) ? mEquippedWeapon.rateOfFirePerMinute : mWeapon.rateOfFirePerMinute);
		weaponShotVelocity.text = ((mWeapon.shotVelocity <= -1) ? Localization.Localize("ID_NA") : MiscTools.FormatBigNumber(mWeapon.shotVelocity));
		weaponShotVelocity.color = MiscTools.CompareStats(mWeapon.shotVelocity, (!(mEquippedWeapon == null)) ? mEquippedWeapon.shotVelocity : mWeapon.shotVelocity);
	}

	private void ChangeRightContent()
	{
		WeaponLevelsSetup.State weaponState = mWeapon.weaponState;
		UpdateWeaponDetailedStats();
		UpdateWeaponPower();
		rightButton.gameObject.SetActive(mWeapon.purchasableInShop && !mWeapon.bought);
		buttonLockedPart.SetActive(weaponState == WeaponLevelsSetup.State.Locked);
		lockedTillLevel.text = Localization.LocalizeFormat("ID_GUI_UNLOCKEDAT", Colours.stringBlue, mWeapon.unlockLevel.displayNumber);
		buttonBuyPart.SetActive(weaponState == WeaponLevelsSetup.State.NotBuyed && mWeapon.purchasableInShop);
		warbucksIcon.gameObject.SetActive(mWeapon.price > 0);
		goldIcon.gameObject.SetActive(mWeapon.priceGold > 0);
		SetSaleAndPrize();
		buttonDeliverNowPart.SetActive(weaponState == WeaponLevelsSetup.State.WeaponDelivering);
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
		buttonActivatePart.SetActive(weaponState == WeaponLevelsSetup.State.WeaponDelivered);
		packButton.gameObject.SetActive(!mWeapon.purchasableInShop && !mWeapon.bought);
		bool active = weaponState == WeaponLevelsSetup.State.Active || weaponState == WeaponLevelsSetup.State.Delivering || weaponState == WeaponLevelsSetup.State.Delivered;
		equipButton.gameObject.SetActive(active);
		rightButtonCollider.enabled = weaponState != WeaponLevelsSetup.State.Locked;
		UpdateCollider(weaponState);
	}

	public void SetSaleAndPrize()
	{
		if (!mWeapon.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedWeapon(mWeapon, OfferBuyType.Buy);
			int num2 = mWeapon.price + mWeapon.priceGold;
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
				saleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(mWeapon, OfferBuyType.Buy), upperCaseCountdown: true);
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

	private void UpdateCollider(WeaponLevelsSetup.State weaponState)
	{
		BoxCollider component = rightButton.GetComponent<BoxCollider>();
		switch (weaponState)
		{
		case WeaponLevelsSetup.State.Locked:
		case WeaponLevelsSetup.State.WeaponDelivering:
			component.center = new Vector3(0f, 15f, -0.5f);
			component.size = new Vector3(550f, 205f, 1f);
			break;
		case WeaponLevelsSetup.State.NotBuyed:
		case WeaponLevelsSetup.State.WeaponDelivered:
			component.center = new Vector3(0f, 0f, -0.5f);
			component.size = new Vector3(550f, 180f, 1f);
			break;
		default:
			component.center = new Vector3(0f, 0f, 0f);
			component.size = new Vector3(550f, 1f, 1f);
			break;
		}
	}

	private void DeliveringAnimation(UISprite sprite, bool play, bool show, Vector3 from, Vector3 to)
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
			sprite.transform.localScale = from;
		}
		else
		{
			float num = 0.5f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(sprite.gameObject, 2f * num, 1f, 0f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(sprite.gameObject, 2f * num, from, to);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		sprite.gameObject.SetActive(show);
	}

	public void UpdateDeliveringTime(float remainingTime, float progress)
	{
		remainingTime = ((!(remainingTime > 0f)) ? 0f : remainingTime);
		deliveringProgress.fillAmount = Mathf.Clamp01(progress);
		time1.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
		string text = MiscTools.FormatBigNumber(mWeapon.instantWeaponDeliveryPrice);
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

	public void AnimateWeaponPower()
	{
		TweenScale tweenScale = TweenScale.Begin(weaponPower.gameObject, GuiScreenSingle<WeaponScreen>.instance.upgradeDur * 4f, new Vector3(62f, 62f, 1f), new Vector3(112f, 112f, 1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void SetWeaponPower(string weaponPowerX10Formated)
	{
		if (GuiScreenSingle<WeaponScreen>.instance.isShowed && !GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
		{
			weaponPower.transform.localScale = new Vector3(62f, 62f, 1f);
			TweenScale component = weaponPower.GetComponent<TweenScale>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		weaponPower.text = weaponPowerX10Formated;
	}

	private PlayerInventory.InventorySlot InitEquippedWeapon()
	{
		PlayerInventory.InventorySlot inventorySlot = null;
		foreach (PlayerInventory.InventorySlot inventorySlot2 in PlayerInventory.instance.inventorySlots)
		{
			if (mWeapon.weaponCategory == (mWeapon.weaponCategory & inventorySlot2.category))
			{
				inventorySlot = inventorySlot2;
			}
		}
		mEquippedWeapon = ((inventorySlot != null) ? PlayerInventory.instance.inventorySlots[inventorySlot.index].weaponLevelsSetup : null);
		return inventorySlot;
	}
}

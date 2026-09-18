using System;
using System.Collections;
using UnityEngine;

public class OtherUpgradeDialog : GuiElementSingle<OtherUpgradeDialog>, IGuiDialog
{
	[Header("Header")]
	public UIButton closeButton;

	public UILabel headerLabel;

	[Header("Content")]
	public UILabel upgradingLabel;

	public UILabel progressLabel;

	public UISprite progressBar;

	[Header("Bottom")]
	public UIButton waitButton;

	public UIButton deliverNowButton;

	public UILabel deliverNowPrize;

	public UIButton activateButton;

	[Header("Animation")]
	public ArmyPowerAnimation armyPowerAnimation;

	private float mRemainingTime;

	private bool mStartedTimer;

	private RadicalRoutine mUpdate;

	private bool mIsWeaponDialog;

	private bool mIsProcessingSpecialSlot;

	private LevelBehaviour mProcessingUnit;

	private LevelBehaviour mNextUnit;

	private bool mIsNextAbility;

	private WeaponLevelsSetup mProcessingWeapon;

	private WeaponLevelsSetup mNextWeapon;

	private string[][] mUnitTranslations = new string[3][]
	{
		new string[4] { "ID_UNIT2UPGRADE_UNIT1BUY", "ID_UNIT2UPGRADE_UNIT1UPGRADE", "ID_UNIT2UPGRADE_UNIT1TRAIN", "ID_UNIT2UPGRADE_UNIT1ABILITYUPGRADE" },
		new string[4] { "ID_UNIT2TRAIN_UNIT1BUY", "ID_UNIT2TRAIN_UNIT1UPGRADE", "ID_UNIT2TRAIN_UNIT1TRAIN", "ID_UNIT2TRAIN_UNIT1ABILITYUPGRADE" },
		new string[4] { "ID_UNIT2UPGRADEABILITY_UNIT1BUY", "ID_UNIT2UPGRADEABILITY_UNIT1UPGRADE", "ID_UNIT2UPGRADEABILITY_UNIT1TRAIN", "ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE" }
	};

	private string[] mWeaponTranslations = new string[2] { "ID_WEAPON2UPGRADE_WEAPON1BUY", "ID_WEAPON2UPGRADE_WEAPON1UPGRADE" };

	public void ShowDialogUnits(LevelBehaviour processingUnit, LevelBehaviour nextUnit, bool isNextAbility)
	{
		UpgradeSlots.State unitState = processingUnit.upgradeSlots.unitState;
		switch (unitState)
		{
		case UpgradeSlots.State.UnitDelivered:
			GuiScreenSingle<ArmyScreen>.instance.ActivateUnit(processingUnit);
			return;
		case UpgradeSlots.State.Delivered:
			GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(processingUnit, showAnimation: false);
			return;
		case UpgradeSlots.State.Delivering:
			if (processingUnit.upgradeSlots.deliveringSlot == null)
			{
				Debug.LogError($"Unit {processingUnit.unitName} is not being delivered/upgrade/trained!!!");
				return;
			}
			break;
		}
		int num = 0;
		string text = processingUnit.unitName;
		if (processingUnit.upgradeSlots.deliveringSlot.isSpecial)
		{
			num = 2;
			text += $" - {processingUnit.unitAbilityName}";
		}
		else if (processingUnit.isSoldier)
		{
			num = 1;
		}
		int num2 = 1;
		string text2 = nextUnit.unitName;
		if (!nextUnit.upgradeSlots.bought)
		{
			num2 = 0;
		}
		else if (isNextAbility)
		{
			num2 = 3;
			text2 += $" - {nextUnit.unitAbilityName}";
		}
		else if (nextUnit.isSoldier)
		{
			num2 = 2;
		}
		mRemainingTime = (float)processingUnit.upgradeSlots.remainingDeliveringSeconds;
		mStartedTimer = true;
		mIsWeaponDialog = false;
		mProcessingUnit = processingUnit;
		mIsProcessingSpecialSlot = processingUnit.upgradeSlots.deliveringSlot != null && processingUnit.upgradeSlots.deliveringSlot.isSpecial;
		mNextUnit = nextUnit;
		mIsNextAbility = isNextAbility;
		string text3 = string.Empty;
		switch (unitState)
		{
		case UpgradeSlots.State.UnitDelivering:
			text3 = Localization.Localize("ID_PURCHASEINPROGRESS");
			break;
		case UpgradeSlots.State.Delivering:
			text3 = Localization.Localize((!processingUnit.isSoldier) ? "ID_UPGRADEINPROGRESS" : "ID_TRAININGINPROGRESS");
			break;
		}
		headerLabel.text = text3;
		MiscTools.SetUILabelRescale(headerLabel, 89f, 44f, 1030);
		upgradingLabel.text = Localization.LocalizeFormat(mUnitTranslations[num][num2], text2, text);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		StartUpdate();
	}

	public void ShowDialogWeapons(WeaponLevelsSetup processingWeapon, WeaponLevelsSetup nextWeapon)
	{
		WeaponLevelsSetup.State weaponState = processingWeapon.weaponState;
		switch (weaponState)
		{
		case WeaponLevelsSetup.State.WeaponDelivered:
			GuiScreenSingle<WeaponScreen>.instance.ActivateWeapon(processingWeapon);
			return;
		case WeaponLevelsSetup.State.Delivered:
			GuiScreenSingle<WeaponScreen>.instance.ActivationWeaponUpgrade(processingWeapon, showAnimation: false);
			return;
		}
		int num = 1;
		if (!nextWeapon.bought)
		{
			num = 0;
		}
		mRemainingTime = (float)processingWeapon.remainingDeliveringSeconds;
		mStartedTimer = true;
		mIsWeaponDialog = true;
		mProcessingWeapon = processingWeapon;
		mNextWeapon = nextWeapon;
		string text = string.Empty;
		switch (weaponState)
		{
		case WeaponLevelsSetup.State.WeaponDelivering:
			text = Localization.Localize("ID_PURCHASEINPROGRESS");
			break;
		case WeaponLevelsSetup.State.Delivering:
			text = Localization.Localize("ID_UPGRADEINPROGRESS");
			break;
		}
		headerLabel.text = text;
		MiscTools.SetUILabelRescale(headerLabel, 89f, 44f, 1030);
		upgradingLabel.text = Localization.LocalizeFormat(mWeaponTranslations[num], nextWeapon.weaponName, processingWeapon.weaponName);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		StartUpdate();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		StopUpdate();
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(waitButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(deliverNowButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DeliverNowButtonClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(activateButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ActivateButtonClick));
	}

	public override void InitGUIValues()
	{
		armyPowerAnimation.InitializeAlphaZero();
	}

	private void CloseDialog(GameObject go)
	{
		mStartedTimer = false;
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void DeliverNowButtonClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (mIsWeaponDialog)
		{
			if (DeliverNowWeapon())
			{
				NextWeaponProcess();
			}
		}
		else if (DeliverNowUnit())
		{
			NextUnitProcess();
		}
	}

	private void ActivateButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (mIsWeaponDialog)
			{
				ActivateWeapon();
				NextWeaponProcess();
			}
			else
			{
				ActivateUnit();
				NextUnitProcess();
			}
		}
	}

	private bool DeliverNowWeapon()
	{
		WeaponLevelsSetup.State weaponState = mProcessingWeapon.weaponState;
		int num = 0;
		string item = string.Empty;
		if (weaponState == WeaponLevelsSetup.State.WeaponDelivering)
		{
			num = mProcessingWeapon.instantWeaponDeliveryPrice;
			item = mProcessingWeapon.weaponName;
		}
		if (weaponState == WeaponLevelsSetup.State.Delivering)
		{
			num = mProcessingWeapon.upgradeSlots.instantBuyPrice;
			item = NameOfUpgrade(mProcessingWeapon);
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, item, NotEnoughDialog.Type.DELIVER);
			return false;
		}
		Singleton<Wallet>.instance.GoldSpentFake(num);
		if (weaponState == WeaponLevelsSetup.State.WeaponDelivering)
		{
			GuiScreenSingle<WeaponScreen>.instance.InstantBuyWeapon(mProcessingWeapon);
		}
		if (weaponState == WeaponLevelsSetup.State.Delivering)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			GuiScreenSingle<WeaponScreen>.instance.DeliverNowWeaponUpgrade(mProcessingWeapon, showAnimation: false);
			AnimateProcessingWeaponArmyPowerChange(armyPowerX);
		}
		mStartedTimer = false;
		mRemainingTime = 0f;
		return true;
	}

	private void ActivateWeapon()
	{
		WeaponLevelsSetup.State weaponState = mProcessingWeapon.weaponState;
		if (weaponState == WeaponLevelsSetup.State.WeaponDelivered)
		{
			GuiScreenSingle<WeaponScreen>.instance.ActivateWeapon(mProcessingWeapon);
		}
		if (weaponState == WeaponLevelsSetup.State.Delivered)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			GuiScreenSingle<WeaponScreen>.instance.ActivationWeaponUpgrade(mProcessingWeapon, showAnimation: false);
			AnimateProcessingWeaponArmyPowerChange(armyPowerX);
		}
	}

	private void NextWeaponProcess()
	{
		WeaponLevelsSetup.State weaponState = mNextWeapon.weaponState;
		if (weaponState == WeaponLevelsSetup.State.NotBuyed)
		{
			int num = Singleton<OfferManager>.instance.DiscountedWeapon(mNextWeapon, OfferBuyType.Buy);
			Singleton<Wallet>.instance.GoldSpentFake(mNextWeapon.priceGold * (100 - num) / 100);
			Singleton<Wallet>.instance.WarBucksSpentFake(mNextWeapon.price * (100 - num) / 100);
			GuiScreenSingle<WeaponScreen>.instance.BuyWeapon(mNextWeapon, num);
		}
		if (weaponState == WeaponLevelsSetup.State.Active)
		{
			int num2 = Singleton<OfferManager>.instance.DiscountedWeapon(mNextWeapon, OfferBuyType.Upgrade);
			int num3 = mNextWeapon.upgradeSlots.upgradePrice * (100 - num2) / 100;
			Singleton<Wallet>.instance.WarBucksSpentFake(num3);
			GuiScreenSingle<WeaponScreen>.instance.UpgradeWeaponUpgrade(mNextWeapon, num2);
		}
	}

	private bool DeliverNowUnit()
	{
		UpgradeSlots.State unitState = mProcessingUnit.upgradeSlots.unitState;
		int num = 0;
		string item = string.Empty;
		if (unitState == UpgradeSlots.State.UnitDelivering)
		{
			num = mProcessingUnit.upgradeSlots.instantUnitDeliveryPrice;
			item = mProcessingUnit.unitName;
		}
		if (unitState == UpgradeSlots.State.Delivering)
		{
			if (mProcessingUnit.upgradeSlots.deliveringSlot == null)
			{
				Debug.LogError("Current unit is not delivered at the moment!!!");
				return false;
			}
			num = mProcessingUnit.upgradeSlots.deliveringSlot.instantBuyPrice;
			item = NameOfUpgrade(mProcessingUnit);
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num))
		{
			if (mIsProcessingSpecialSlot)
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, item, NotEnoughDialog.Type.DELIVERSPECIAL);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, item, NotEnoughDialog.Type.DELIVER);
			}
			return false;
		}
		Singleton<Wallet>.instance.GoldSpentFake(num);
		if (unitState == UpgradeSlots.State.UnitDelivering)
		{
			GuiScreenSingle<ArmyScreen>.instance.InstantBuyUnit(mProcessingUnit);
		}
		if (unitState == UpgradeSlots.State.Delivering)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			GuiScreenSingle<ArmyScreen>.instance.DeliverNowUnitUpgrade(mProcessingUnit, showAnimation: false);
			AnimateProcessingUnitArmyPowerChange(armyPowerX);
		}
		mStartedTimer = false;
		mRemainingTime = 0f;
		return true;
	}

	private void ActivateUnit()
	{
		UpgradeSlots.State unitState = mProcessingUnit.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.State.UnitDelivered)
		{
			GuiScreenSingle<ArmyScreen>.instance.ActivateUnit(mProcessingUnit);
		}
		if (unitState == UpgradeSlots.State.Delivered)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			GuiScreenSingle<ArmyScreen>.instance.ActivationUnitUpgrade(mProcessingUnit, showAnimation: false);
			AnimateProcessingUnitArmyPowerChange(armyPowerX);
		}
	}

	private void NextUnitProcess()
	{
		UpgradeSlots.State unitState = mNextUnit.upgradeSlots.unitState;
		if (unitState == UpgradeSlots.State.NotBuyed)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(mNextUnit, OfferBuyType.Buy);
			Singleton<Wallet>.instance.GoldSpentFake(mNextUnit.upgradeSlots.priceGold * (100 - num) / 100);
			Singleton<Wallet>.instance.WarBucksSpentFake(mNextUnit.upgradeSlots.price * (100 - num) / 100);
			GuiScreenSingle<ArmyScreen>.instance.BuyUnit(mNextUnit, num);
		}
		if (unitState == UpgradeSlots.State.Active)
		{
			int num2 = Singleton<OfferManager>.instance.DiscountedUnit(mNextUnit, OfferBuyType.Upgrade);
			int num3 = mNextUnit.upgradeSlots.upgradeSlot.upgradePrice * (100 - num2) / 100;
			Singleton<Wallet>.instance.WarBucksSpentFake(num3);
			GuiScreenSingle<ArmyScreen>.instance.UpgradeUnitUpgrade(mNextUnit, num2, mIsNextAbility);
		}
	}

	private void AnimateProcessingWeaponArmyPowerChange(int previousArmyPowerX10)
	{
		int index = -1;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & mProcessingWeapon.weaponCategory) == mProcessingWeapon.weaponCategory)
			{
				index = i;
			}
		}
		if (!(PlayerInventory.instance.inventorySlots[index].weaponLevelsSetup.GetSheetName() != mProcessingWeapon.GetSheetName()))
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			GuiElementSingle<RentalDialog>.instance.armyPowerAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	private void AnimateProcessingUnitArmyPowerChange(int previousArmyPowerX10)
	{
		if (mProcessingUnit.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			GuiElementSingle<RentalDialog>.instance.armyPowerAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	private string NameOfUpgrade(LevelBehaviour unit)
	{
		if (unit.upgradeSlots.unitState == UpgradeSlots.State.Delivering && unit.upgradeSlots.deliveringSlot.isSpecial)
		{
			return string.Format("{0} {1}", unit.unitName, Localization.Localize("ID_ABILITYUPGRADE"));
		}
		return string.Format("{0} {1}", unit.unitName, Localization.Localize((!unit.isSoldier) ? "ID_UPGRADESMALL" : "ID_TRAINSMALL"));
	}

	private string NameOfUpgrade(WeaponLevelsSetup weapon)
	{
		return string.Format("{0} {1}", weapon.weaponName, Localization.Localize("ID_UPGRADESMALL"));
	}

	public void StartUpdate()
	{
		StopUpdate();
		mUpdate = RadicalRoutine.Create(AlternativeUpdate());
		StartCoroutine(RadicalRoutine.Run(mUpdate.enumerator));
	}

	private void StopUpdate()
	{
		if (mUpdate != null)
		{
			mUpdate.Cancel();
			mUpdate = null;
		}
	}

	private IEnumerator AlternativeUpdate()
	{
		while (isShowed && mStartedTimer)
		{
			yield return new WaitForRealSeconds(0.333f);
			mRemainingTime -= 0.333f;
			if (mRemainingTime > 0f)
			{
				UpdateDeliverNow();
				continue;
			}
			UpdateActivateNow();
			break;
		}
	}

	private void UpdateDeliverNow()
	{
		deliverNowButton.gameObject.SetActive(value: true);
		activateButton.gameObject.SetActive(value: false);
		if (mIsWeaponDialog)
		{
			WeaponLevelsSetup.State weaponState = mProcessingWeapon.weaponState;
			int num = 0;
			string text = string.Empty;
			if (weaponState == WeaponLevelsSetup.State.WeaponDelivering)
			{
				num = mProcessingWeapon.instantWeaponDeliveryPrice;
				text = mProcessingWeapon.weaponName;
			}
			if (weaponState == WeaponLevelsSetup.State.Delivering)
			{
				num = mProcessingWeapon.upgradeSlots.instantBuyPrice;
				text = NameOfUpgrade(mProcessingWeapon);
			}
			progressLabel.text = Localization.LocalizeFormat("ID_DELIVEREDTIME", text, Colours.stringWhite, MiscTools.PrintableTime(mRemainingTime, "ID_NOW", "ID_INTIME"));
			MiscTools.SetUILabelRescale(progressLabel, 37f, 20f, 770);
			progressBar.fillAmount = mProcessingWeapon.progressDelivering;
			deliverNowPrize.text = MiscTools.FormatBigNumber(num);
			return;
		}
		UpgradeSlots.State unitState = mProcessingUnit.upgradeSlots.unitState;
		int num2 = 0;
		string text2 = string.Empty;
		if (unitState == UpgradeSlots.State.UnitDelivering)
		{
			num2 = mProcessingUnit.upgradeSlots.instantUnitDeliveryPrice;
			text2 = mProcessingUnit.unitName;
		}
		if (unitState == UpgradeSlots.State.Delivering)
		{
			if (mProcessingUnit.upgradeSlots.deliveringSlot == null)
			{
				Debug.LogError("Current unit is not delivering at the moment!!!");
				return;
			}
			num2 = mProcessingUnit.upgradeSlots.deliveringSlot.instantBuyPrice;
			text2 = NameOfUpgrade(mProcessingUnit);
		}
		progressLabel.text = Localization.LocalizeFormat("ID_DELIVEREDTIME", text2, Colours.stringWhite, MiscTools.PrintableTime(mRemainingTime, "ID_NOW", "ID_INTIME"));
		MiscTools.SetUILabelRescale(progressLabel, 37f, 20f, 770);
		progressBar.fillAmount = mProcessingUnit.upgradeSlots.progressDelivering;
		deliverNowPrize.text = MiscTools.FormatBigNumber(num2);
	}

	private void UpdateActivateNow()
	{
		deliverNowButton.gameObject.SetActive(value: false);
		activateButton.gameObject.SetActive(value: true);
		mStartedTimer = false;
		mRemainingTime = 0f;
		if (mIsWeaponDialog)
		{
			WeaponLevelsSetup.State weaponState = mProcessingWeapon.weaponState;
			string text = string.Empty;
			if (weaponState == WeaponLevelsSetup.State.WeaponDelivered)
			{
				text = mProcessingWeapon.weaponName;
			}
			if (weaponState == WeaponLevelsSetup.State.Delivered)
			{
				text = NameOfUpgrade(mProcessingWeapon);
			}
			progressLabel.text = Localization.LocalizeFormat("ID_DELIVEREDTIME", text, Colours.stringWhite, Localization.Localize("ID_NOW"));
			MiscTools.SetUILabelRescale(progressLabel, 37f, 20f, 770);
		}
		else
		{
			UpgradeSlots.State unitState = mProcessingUnit.upgradeSlots.unitState;
			string text2 = string.Empty;
			if (unitState == UpgradeSlots.State.UnitDelivered)
			{
				text2 = mProcessingUnit.unitName;
			}
			if (unitState == UpgradeSlots.State.Delivered)
			{
				text2 = NameOfUpgrade(mProcessingUnit);
			}
			progressLabel.text = Localization.LocalizeFormat("ID_DELIVEREDTIME", text2, Colours.stringWhite, Localization.Localize("ID_NOW"));
			MiscTools.SetUILabelRescale(progressLabel, 37f, 20f, 770);
		}
		progressBar.fillAmount = 1f;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}

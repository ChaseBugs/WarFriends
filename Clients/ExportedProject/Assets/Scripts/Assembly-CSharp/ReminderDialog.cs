using System;
using UnityEngine;

public class ReminderDialog : GuiElementSingle<ReminderDialog>, IGuiDialog
{
	public enum ReminderTypes
	{
		VIPAlmostExpired,
		WeaponUpgrade,
		TryPowerBand,
		Customizations,
		OfferingCards,
		CardslotViaValuePack,
		UnitUpgrade
	}

	[Header("Background")]
	public UISprite background;

	[Header("Header")]
	public GameObject headerPart;

	public UILabel header;

	[Header("Content")]
	public UILabel desc;

	[Header("-VIP Almost Expired Icon")]
	public GameObject iconVipAlmostExpired;

	[Header("-Card Pack")]
	public GameObject cardsPackHolder;

	[Header("-Value Pack Card Slot")]
	public GameObject cardSlotHolder;

	[Header("-Weapons And Visuals")]
	public GameObject inCommonHolder;

	public UISprite inCommonIco;

	public UISprite glow;

	[Header("-Power Band Info")]
	public GameObject powerBandInfoHolder;

	public UISprite powerBandInfoBackground;

	public UISprite powerBandSmallIco;

	public UILabel powerBandValue;

	public UILabel powerBandType;

	[Header("Bottom Buttons")]
	public GameObject buttonsSetInCommon;

	public UIButton yesButton;

	public UILabel yesLabel;

	public UIButton noButton;

	[Header("Bottom Buttons VIP")]
	public GameObject buttonsSetVIP;

	public UIButton yesVIPButton;

	public UIButton noVIPButton;

	[Header("Atlases")]
	public UIAtlas weaponsAndUnitsAtlas;

	public UIAtlas visualsAtlas;

	public UIAtlas powerBandAtlas;

	private ReminderTypes mReminderTypes;

	private Action mYesAction;

	private Action mNoAction;

	private WeaponLevelsSetup mWeapon;

	private LevelBehaviour mUnit;

	private PlayerVisual mPlayerVisual;

	public void ShowVisualDialog(PlayerVisual visual, Action yesAction, Action noAction = null)
	{
		mPlayerVisual = visual;
		ReminderTypes type = ((!(visual.owner is PlayerVisualCategoryPowerBands)) ? ReminderTypes.Customizations : ReminderTypes.TryPowerBand);
		ShowDialog(type, yesAction, noAction);
	}

	public void ShowWeaponDialog(WeaponLevelsSetup weapon, Action yesAction, Action noAction = null)
	{
		mWeapon = weapon;
		ShowDialog(ReminderTypes.WeaponUpgrade, yesAction, noAction);
	}

	public void ShowUnitDialog(LevelBehaviour unit, Action yesAction, Action noAction = null)
	{
		mUnit = unit;
		ShowDialog(ReminderTypes.UnitUpgrade, yesAction, noAction);
	}

	public void ShowDialog(ReminderTypes type, Action yesAction, Action noAction = null)
	{
		mYesAction = yesAction;
		mNoAction = noAction;
		mReminderTypes = type;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(yesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(TrueClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(yesVIPButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(TrueClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(noButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FalseClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(noVIPButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FalseClick));
	}

	private void TrueClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (mYesAction != null)
			{
				mYesAction();
				mYesAction = null;
			}
			HideDialog();
		}
	}

	private void FalseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (mNoAction != null)
			{
				mNoAction();
				mNoAction = null;
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		cardSlotHolder.SetActive(value: false);
		cardsPackHolder.SetActive(value: false);
		inCommonHolder.SetActive(value: false);
		powerBandInfoHolder.SetActive(value: false);
		iconVipAlmostExpired.SetActive(value: false);
		buttonsSetVIP.SetActive(value: false);
		buttonsSetInCommon.SetActive(value: false);
		yesLabel.text = Localization.Localize("ID_GETITNOW");
		MiscTools.SetUILabelRescale(yesLabel, 50f, 20f, 560);
		SetHeight();
		switch (mReminderTypes)
		{
		case ReminderTypes.VIPAlmostExpired:
			InitializeVIPAlmostExpired();
			break;
		case ReminderTypes.WeaponUpgrade:
			InitializeWeaponUpgrade();
			break;
		case ReminderTypes.TryPowerBand:
			InitializeTryPowerBand();
			break;
		case ReminderTypes.Customizations:
			InitializeCustomizations();
			break;
		case ReminderTypes.OfferingCards:
			InitializeOfferingCards();
			break;
		case ReminderTypes.CardslotViaValuePack:
			InitializeCardslotViaValuePack();
			break;
		case ReminderTypes.UnitUpgrade:
			InitializeUnitUpgrade();
			break;
		}
		MiscTools.SetUILabelRescale(header, 83f, 40f, 1150);
	}

	private void InitializeVIPAlmostExpired()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_VIPALMOSTEXPIRED", Colours.stringYellow);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_YOURVIPMEMBERSHIP", Colours.stringYellow, Colours.stringBlue, Colours.stringWhite);
		iconVipAlmostExpired.SetActive(value: true);
		buttonsSetVIP.SetActive(value: true);
	}

	private void InitializeWeaponUpgrade()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_UPGRADEAVAILABLE", Colours.stringBlue);
		string weaponCategoryId = Singleton<GameVariables>.instance.GetWeaponCategoryId(mWeapon.weaponCategory, StringCase.UpperCase);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_WEAPONUPGRADEREADY", Localization.Localize(weaponCategoryId), Colours.stringBlue, mWeapon.weaponName, Colours.stringWhite, Colours.stringGreenCamos, mWeapon.maxWeaponLevel - mWeapon.weaponLevel);
		inCommonHolder.SetActive(value: true);
		inCommonIco.atlas = weaponsAndUnitsAtlas;
		inCommonIco.spriteName = mWeapon.playerWeapon.iconName;
		SetCommonIcon();
		buttonsSetInCommon.SetActive(value: true);
		yesLabel.text = Localization.Localize("ID_UPGRADENOW");
		MiscTools.SetUILabelRescale(yesLabel, 50f, 20f, 560);
	}

	private void InitializeTryPowerBand()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_RAISEYOURCHANCES", Colours.stringBlue);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_GETPOWERBANDTOINCREASE", Colours.stringBlue, mPlayerVisual.name.ToUpper(), Colours.stringWhite, Colours.stringGreenCamos, mPlayerVisual.decalShortName.ToLower());
		inCommonHolder.SetActive(value: true);
		inCommonIco.atlas = powerBandAtlas;
		inCommonIco.spriteName = mPlayerVisual.icon;
		SetCommonIcon(320f);
		powerBandInfoHolder.SetActive(value: true);
		powerBandSmallIco.spriteName = mPlayerVisual.decalMiniIcon;
		powerBandSmallIco.color = mPlayerVisual.decalMiniIconColor;
		powerBandValue.text = mPlayerVisual.decalValueString;
		powerBandType.text = mPlayerVisual.decalShortName;
		powerBandInfoBackground.transform.localScale = powerBandInfoBackground.transform.localScale.ReplaceX(powerBandType.relativeSize.x * powerBandType.transform.localScale.x + 40f);
		buttonsSetInCommon.SetActive(value: true);
	}

	private void InitializeCustomizations()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_SUITUPSOLDIER", Colours.stringBlue);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_THISAMAZINGCUSTOMIZATION", Colours.stringBlue, mPlayerVisual.name.ToUpper(), Colours.stringWhite);
		inCommonHolder.SetActive(value: true);
		inCommonIco.atlas = visualsAtlas;
		inCommonIco.spriteName = mPlayerVisual.icon;
		SetCommonIcon();
		buttonsSetInCommon.SetActive(value: true);
	}

	private void InitializeOfferingCards()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_GETCARDPACKS", Colours.stringBlue);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_GETVALUABLECARDPACKS", Colours.stringBlue, Colours.stringWhite);
		cardsPackHolder.SetActive(value: true);
		buttonsSetInCommon.SetActive(value: true);
	}

	private void InitializeCardslotViaValuePack()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_ADDAWARCARDSLOT", Colours.stringBlue);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_WARCARDSLOTSNOTENOUGH", Colours.stringBlue, Colours.stringWhite);
		cardSlotHolder.SetActive(value: true);
		buttonsSetInCommon.SetActive(value: true);
	}

	private void InitializeUnitUpgrade()
	{
		header.text = Localization.LocalizeFormat("ID_REMINDER_UPGRADEAVAILABLE", Colours.stringBlue);
		desc.text = Localization.LocalizeFormat("ID_REMINDER_UNITUPGRADEREADY", Colours.stringBlue, mUnit.unitName, Colours.stringWhite, mUnit.upgradeSlots.actualUnitLevel + 1);
		inCommonHolder.SetActive(value: true);
		inCommonIco.atlas = weaponsAndUnitsAtlas;
		inCommonIco.spriteName = mUnit.upgradeSlots.iconName;
		SetCommonIcon();
		buttonsSetInCommon.SetActive(value: true);
		yesLabel.text = Localization.Localize("ID_UPGRADENOW");
		MiscTools.SetUILabelRescale(yesLabel, 50f, 20f, 560);
	}

	private void SetCommonIcon(float maxSize = 360f)
	{
		inCommonIco.MakePixelPerfect();
		float multiplier = Mathf.Min(maxSize / inCommonIco.transform.localScale.x, maxSize / inCommonIco.transform.localScale.y);
		inCommonIco.transform.localScale = inCommonIco.transform.localScale.MultiplyXY(multiplier);
		float num = Mathf.Max(inCommonIco.transform.localScale.y, desc.relativeSize.y * desc.transform.localScale.y);
		glow.transform.localScale = glow.transform.localScale.ReplaceY(num + 60f);
		SetHeight(200f + num + 60f + 200f);
	}

	private void SetHeight(float height = 0f)
	{
		if (height < 500f)
		{
			height = ((mReminderTypes != ReminderTypes.UnitUpgrade && mReminderTypes != ReminderTypes.WeaponUpgrade) ? 880f : 800f);
		}
		background.transform.localScale = background.transform.localScale.ReplaceY(height);
		headerPart.transform.localPosition = headerPart.transform.localPosition.ReplaceY(height / 2f);
		buttonsSetInCommon.transform.localPosition = buttonsSetInCommon.transform.localPosition.ReplaceY((0f - height) / 2f + 200f);
		buttonsSetVIP.transform.localPosition = buttonsSetVIP.transform.localPosition.ReplaceY((0f - height) / 2f + 200f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		FalseClick(noButton.gameObject);
	}
}

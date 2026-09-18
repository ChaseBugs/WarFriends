using System;
using UnityEngine;

public class EliteUnitPreviewDialog : GuiElementSingle<EliteUnitPreviewDialog>, IGuiDialog
{
	[Header("Top")]
	public GameObject backButton;

	public GameObject closeButton;

	public UILabel unitNameLabel;

	[Header("Left")]
	public UILabel elitePartsHint;

	public UILabel arenaTimeLabel;

	[Header("Right")]
	public UISprite eliteIcon;

	public UISprite eliteBuffIcon;

	public UILabel buffNameLabel;

	public UILabel buffDescriptionLabel;

	public UISprite eliteUnitIcon;

	public UISprite eliteProgress;

	public UILabel elitePartsProgressLabel;

	private LevelBehaviour mUnit;

	private float mTimer;

	public void ShowDialog(LevelBehaviour unit)
	{
		mUnit = unit;
		if (mUnit.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.ShowAlert("HAS NO ELITE PARTS", "This unit cannot be showned, because it has not implemented elite buff.", 0f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		UpgradeSlotElite upgradeSlotElite = mUnit.upgradeSlots.upgradeSlotElite;
		int currentParts = upgradeSlotElite.currentParts;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		float progress = upgradeSlotElite.progress;
		int boughtIndex = upgradeSlotElite.boughtIndex;
		int actualMaxLevel = upgradeSlotElite.actualMaxLevel;
		bool flag = boughtIndex == actualMaxLevel;
		unitNameLabel.text = Localization.LocalizeFormat("ID_ELITEUNITNAME", mUnit.unitName.ToUpper());
		MiscTools.SetUILabelRescale(unitNameLabel, 126f, 20f, 1600);
		elitePartsHint.text = Localization.LocalizeFormat("ID_COLLECTELITEPARTSFROMARENALOOTBOXES", MiscTools.FormatBigNumber(upgradePriceParts), Colours.stringGreenArena, mUnit.unitElitePartsName, mUnit.unitName);
		mUnit.SetUpEliteIcon(eliteIcon, eliteBuffIcon);
		buffNameLabel.text = mUnit.unitBuffName;
		MiscTools.SetUILabelRescale(buffNameLabel, 57f, 20f, 510);
		buffDescriptionLabel.text = mUnit.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		eliteUnitIcon.spriteName = mUnit.upgradeSlots.iconNameElite;
		eliteUnitIcon.MakePixelPerfect();
		if (mUnit.isSoldier)
		{
			eliteUnitIcon.pivot = UIWidget.Pivot.Bottom;
			eliteUnitIcon.transform.localPosition = eliteUnitIcon.transform.localPosition.ReplaceY(-56f);
			float multiplier = 120f / eliteUnitIcon.transform.localScale.y;
			eliteUnitIcon.transform.localScale = eliteUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			eliteUnitIcon.pivot = UIWidget.Pivot.Center;
			eliteUnitIcon.transform.localPosition = eliteUnitIcon.transform.localPosition.ReplaceY(0f);
			float multiplier2 = Mathf.Min(174f / eliteUnitIcon.transform.localScale.x, 110f / eliteUnitIcon.transform.localScale.y);
			eliteUnitIcon.transform.localScale = eliteUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		eliteProgress.fillAmount = progress;
		elitePartsProgressLabel.text = ((!flag) ? $"{Colours.stringGreenArena}{MiscTools.FormatBigNumber(currentParts)}[-] {Colours.stringGray}/[-] {MiscTools.FormatBigNumber(upgradePriceParts)}" : $"{Colours.stringGreenArena}{MiscTools.FormatBigNumber(currentParts)}[-]");
		float seconds = fadeInTime * 0.5f;
		InvokeAfter(delegate
		{
			Singleton<LootBoxCameraArena>.instance.DisplayModel(mUnit, isLootboxReward: false);
		}, seconds);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
	}

	protected override void Update()
	{
		base.Update();
		mTimer += Time.deltaTime;
		if (mTimer > 0.333f)
		{
			mTimer -= 0.333f;
			arenaTimeLabel.text = WarArenaGui.CreateArenaEventTimeTextLowerCase();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(closeButton);
	}
}

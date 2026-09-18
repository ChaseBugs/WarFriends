using System;
using UnityEngine;

public class UnitPromotionLockedDialog : GuiElementSingle<UnitPromotionLockedDialog>, IGuiDialog
{
	[Header("Header")]
	public UIButton closeButton;

	[Header("Content")]
	public UISprite unitLeftIcon;

	public UILabel unitPromotionLockedLabel;

	public UISprite unitRightIcon;

	[Header("Buttons")]
	public UIButton viewUnitButton;

	public UILabel viewButtonLabel;

	private LevelBehaviour mUnitToPurchase;

	private LevelBehaviour mUnitToPromote;

	public void ShowDialog(LevelBehaviour unitToPromote, LevelBehaviour unitToPurchase)
	{
		mUnitToPurchase = unitToPurchase;
		mUnitToPromote = unitToPromote;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener4 = UIEventListener.Get(viewUnitButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				if (!(mUnitToPurchase == null))
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(mUnitToPurchase);
					if (GuiScreenSingle<ArmyScreen>.instance.isShowed)
					{
						GuiScreenSingle<ArmyScreen>.instance.InitGUIValues();
					}
					else
					{
						Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
					}
				}
			}
		});
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		if (!(mUnitToPromote == null) && !(mUnitToPurchase == null))
		{
			unitLeftIcon.spriteName = mUnitToPromote.upgradeSlots.iconName;
			unitLeftIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(350f / unitLeftIcon.transform.localScale.x, 340f / unitLeftIcon.transform.localScale.y);
			unitLeftIcon.transform.localScale = unitLeftIcon.transform.localScale.MultiplyXY(multiplier);
			unitRightIcon.spriteName = mUnitToPurchase.upgradeSlots.iconName;
			unitRightIcon.MakePixelPerfect();
			multiplier = Mathf.Min(350f / unitRightIcon.transform.localScale.x, 340f / unitRightIcon.transform.localScale.y);
			unitRightIcon.transform.localScale = new Vector3(multiplier * unitRightIcon.transform.localScale.x, multiplier * unitRightIcon.transform.localScale.y, 1f);
			unitPromotionLockedLabel.text = Localization.LocalizeFormat("ID_RECRUITUNITTOARMYTOPROMOTE", Colours.stringBlue, mUnitToPurchase.unitName.ToUpper(), Colours.stringWhite, mUnitToPromote.unitName.ToUpper(), Colours.stringGoldTier, mUnitToPromote.upgradeSlots.actualTier + 1);
			viewButtonLabel.text = Localization.LocalizeFormat("ID_VIEWUNIT", mUnitToPurchase.unitName.ToUpper());
			MiscTools.SetUILabelRescale(viewButtonLabel, 57f, 28f, 900);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mUnitToPurchase = null;
		mUnitToPromote = null;
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

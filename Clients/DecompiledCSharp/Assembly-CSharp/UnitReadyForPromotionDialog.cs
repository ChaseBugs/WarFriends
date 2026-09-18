using System;
using UnityEngine;

public class UnitReadyForPromotionDialog : GuiElementSingle<UnitReadyForPromotionDialog>, IGuiDialog
{
	[Header("Header")]
	public UIButton closeButton;

	[Header("Content")]
	public UISprite unitIcon;

	public UILabel unitReadyForPromotionLabel;

	[Header("Buttons")]
	public UIButton goToUnitButton;

	private LevelBehaviour mUnit;

	public void ShowDialog(LevelBehaviour unit)
	{
		mUnit = unit;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(goToUnitButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				HideDialog();
				if (!(mUnit == null))
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(mUnit);
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
		if (!(mUnit == null))
		{
			unitIcon.spriteName = mUnit.upgradeSlots.iconName;
			unitIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(350f / unitIcon.transform.localScale.x, 340f / unitIcon.transform.localScale.y);
			unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(multiplier);
			unitReadyForPromotionLabel.text = Localization.LocalizeFormat("ID_UNITCANBEPROMOTEDTOTIER", mUnit.unitName.ToUpper(), Colours.stringWhite, Colours.stringGoldTier, mUnit.upgradeSlots.actualTier + 1);
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
		mUnit = null;
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

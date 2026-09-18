using System;
using UnityEngine;

public class UnitPromotedDialog : GuiElementSingle<UnitPromotedDialog>, IGuiDialog
{
	[Header("Content")]
	public ParticleSystem particles;

	public UISprite unitIcon;

	public UILabel unitPromotedLabel;

	[Header("Buttons")]
	public UIButton rogerThatButton;

	private LevelBehaviour mUnit;

	public void ShowDialog(LevelBehaviour unit)
	{
		mUnit = unit;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(rogerThatButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(RogerClick));
	}

	private void RogerClick(GameObject go)
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
			unitPromotedLabel.text = Localization.LocalizeFormat("ID_UNITHASBEENPROMOTEDTOTIER", mUnit.unitName.ToUpper(), Colours.stringWhite, Colours.stringGoldTier, mUnit.upgradeSlots.actualTier);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		particles.Play();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		particles.Stop();
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
		RogerClick(rogerThatButton.gameObject);
	}
}

using System;
using UnityEngine;

public class ArenaCosmeticsDialog : GuiElementSingle<ArenaCosmeticsDialog>, IGuiDialog
{
	[SerializeField]
	[Header("Top")]
	private UILabel mTitle;

	[SerializeField]
	[Header("Middle")]
	private UILabel mText;

	[SerializeField]
	private UISprite mCrown;

	[Header("Bottom")]
	[SerializeField]
	private BoxCollider mButtonEquip;

	[SerializeField]
	private BoxCollider mButtonContinue;

	private PlayerVisual mVisualCrown;

	private int mWonBattles;

	public void ShowDialog(PlayerVisual crown, int wonBattles)
	{
		mVisualCrown = crown;
		mWonBattles = wonBattles;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonEquip.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EquipCrown));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void EquipCrown(GameObject go)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(mVisualCrown);
			HideDialog();
		}
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
		mTitle.text = mVisualCrown.name.ToUpper();
		mCrown.spriteName = mVisualCrown.icon;
		mCrown.MakePixelPerfect();
		mCrown.transform.localScale = mCrown.transform.localScale.MultiplyXY(1.7f);
		int num = (int)(mVisualCrown.remainingTime / 86400.0);
		mText.text = Localization.LocalizeFormat("ID_YOUMANAGEDTOWINXARENABATTLESYOU", Colours.stringGreenArena, MiscTools.FormatBigNumber(mWonBattles), mVisualCrown.name, MiscTools.PrintableTimeVipConvertSmall(num * 60 * 60 * 24));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(mButtonContinue.gameObject);
	}
}

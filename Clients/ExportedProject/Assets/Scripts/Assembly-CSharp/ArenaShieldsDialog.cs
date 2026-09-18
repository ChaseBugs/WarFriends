using System;
using UnityEngine;

public class ArenaShieldsDialog : GuiElementSingle<ArenaShieldsDialog>, IGuiDialog
{
	[Header("Core")]
	[SerializeField]
	private UILabel mText;

	[SerializeField]
	private GameObject mShield;

	[SerializeField]
	private BoxCollider mButtonContinue;

	private int mWins;

	private int mDays;

	public void ShowDialog(int wins, int seconds)
	{
		mWins = wins;
		mDays = Mathf.RoundToInt((float)seconds / 86400f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		mText.text = Localization.LocalizeFormat("ID_GOLDENSHIELDSDIALOGTEXT", mWins, MiscTools.PrintableTimeVipConvertSmall(mDays * 60 * 60 * 24));
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		mShield.SetActive(value: true);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		mShield.SetActive(value: false);
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

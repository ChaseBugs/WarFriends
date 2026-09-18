using System;
using Google2u;
using UnityEngine;

public class InstantBattleUnlockDialog : GuiElementSingle<InstantBattleUnlockDialog>, IGuiDialog
{
	[SerializeField]
	[Header("Middle Left")]
	private GameObject mHintLowLeft;

	[SerializeField]
	private UILabel mHintUpLeftText;

	[Header("Middle Right")]
	[SerializeField]
	private GameObject mHintLowRight;

	[SerializeField]
	private UILabel mHintUpRightText;

	[SerializeField]
	private UILabel mHintLowRightText;

	[Header("Bottom")]
	[SerializeField]
	private BoxCollider mButton;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleReload).FLOATVALUE;
		mHintUpLeftText.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT1", Colours.stringBlue, num);
		mHintUpRightText.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT2", num, Colours.stringBlue, instantBattleCost);
		mHintLowRightText.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT4", Colours.stringBlue, MiscTools.PrintableTime((float)num2 * 60f, "ID_READYTIME", string.Empty));
		float num3 = -376f;
		float num4 = 65f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(mButton.gameObject);
	}
}

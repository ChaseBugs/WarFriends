using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class ConvertToScrapsDialog : GuiElementSingle<ConvertToScrapsDialog>, IGuiDialog
{
	[Header("Top")]
	[SerializeField]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mTopText;

	[SerializeField]
	[Header("Middle")]
	private UISprite mUnitIcon;

	[SerializeField]
	private UILabel mUnitEliteParts;

	[SerializeField]
	private UITable mScrapsTable;

	[SerializeField]
	private UILabel mScrapsLabel;

	[Header("Bottom")]
	[SerializeField]
	private GameObject mBottomButton;

	private LevelBehaviour mUnit;

	private Action<bool> mDialogResponse;

	public void ShowDialog(LevelBehaviour unit, Action<bool> dialogResponse)
	{
		mUnit = unit;
		mDialogResponse = dialogResponse;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ConvertClick));
		mScrapsTable.onReposition = delegate
		{
			float val = 0f - mScrapsTable.padding.x - (mScrapsLabel.transform.parent.localPosition.x - mScrapsTable.padding.x) / 2f;
			mScrapsTable.transform.localPosition = mScrapsTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (mDialogResponse != null)
			{
				mDialogResponse(obj: false);
			}
			HideDialog();
		}
	}

	private void ConvertClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (mDialogResponse != null)
			{
				mDialogResponse(obj: true);
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		int currentParts = mUnit.upgradeSlots.upgradeSlotElite.currentParts;
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsSell).FLOATVALUE;
		int num = (int)((float)currentParts * (float)fLOATVALUE);
		mTopText.text = Localization.LocalizeFormat("ID_AREYOUSUREYOUWANTTOCONVERTPARTS", Colours.stringGreenArena, MiscTools.FormatBigNumber(currentParts), mUnit.unitElitePartsName, MiscTools.FormatBigNumber(num));
		mUnitIcon.spriteName = mUnit.upgradeSlots.iconNameElite;
		mUnitIcon.MakePixelPerfect();
		if (mUnit.isSoldier)
		{
			float multiplier = 126f / mUnitIcon.transform.localScale.y;
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(180f / mUnitIcon.transform.localScale.x, 116f / mUnitIcon.transform.localScale.y);
			mUnitIcon.transform.localScale = mUnitIcon.transform.localScale.MultiplyXY(multiplier2);
		}
		mUnitEliteParts.text = MiscTools.FormatBigNumber(currentParts);
		mScrapsLabel.text = MiscTools.FormatBigNumber(num);
		mScrapsTable.repositionNow = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mDialogResponse = null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(mBottomButton);
	}
}

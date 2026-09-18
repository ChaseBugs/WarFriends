using System;
using Google2u;
using UnityEngine;

public class VIPConfirmDialog : GuiElementSingle<VIPConfirmDialog>, IGuiDialog
{
	[SerializeField]
	[Header("Core")]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mVipTimeLabel;

	[SerializeField]
	private UILabel mTextLabel;

	[SerializeField]
	private GameObject mBuyButton;

	[SerializeField]
	private UITable mPriceTable;

	[SerializeField]
	private UILabel mGoldLabel;

	private VIP.rowIds mRowId;

	private Action<bool> mDialogResponse;

	public void ShowDialog(VIP.rowIds rowId, Action<bool> dialogResponse)
	{
		mRowId = rowId;
		mDialogResponse = dialogResponse;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<VIPConfirmDialog>.instance, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBuyButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyClick));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void BuyClick(GameObject go)
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

	public override void InitGUIValues()
	{
		mVipTimeLabel.text = MiscTools.PrintableTimeVipConvert(Singleton<GameVariables>.instance.vip.GetRow(mRowId).SECONDS);
		MiscTools.SetUILabelRescale(mVipTimeLabel, 47f, 20f, 230);
		int num = Singleton<OfferManager>.instance.DiscountedVIP();
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.vip.GetRow(mRowId).GOLD;
		if (flag)
		{
			num2 = num2 * (100 - num) / 100;
		}
		mGoldLabel.text = MiscTools.FormatBigNumber(num2);
		mPriceTable.repositionNow = true;
		mTextLabel.text = Localization.LocalizeFormat("ID_ACTIVATEXVIPFORYGOLD", mVipTimeLabel.text, mGoldLabel.text);
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
		CloseClick(mCloseButton);
	}
}

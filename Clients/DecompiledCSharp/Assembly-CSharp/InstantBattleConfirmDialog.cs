using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InstantBattleConfirmDialog : GuiElementSingle<InstantBattleConfirmDialog>, IGuiDialog
{
	[SerializeField]
	[Header("Top")]
	private BoxCollider mCloseButton;

	[Header("Middle")]
	[SerializeField]
	private UILabel mDescription;

	[SerializeField]
	[Header("Bottom")]
	private BoxCollider mBottomButton;

	[SerializeField]
	private UILabel mButtonText;

	[SerializeField]
	private UITable mPriceTable;

	[SerializeField]
	private UILabel mButtonPrice;

	private int mGoldCost;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NextBattleButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(mCloseButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseClick));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void NextBattleButtonClick(GameObject go)
	{
		if (Singleton<Wallet>.instance.CanBuyGold(mGoldCost))
		{
			Singleton<Wallet>.instance.GoldSpent(mGoldCost);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("IsPaid", mGoldCost.ToString()));
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.InstantBattle, list);
			int instantBattles = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
			GuiScreenSingle<InstantBattleResultsScreen>.instance.instantBattles = instantBattles;
			if (GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed)
			{
				GuiElementSingle<InstantBattleResultsDialog>.instance.PlayAgain();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
			}
			HideDialog();
		}
		else
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(mGoldCost, Localization.Localize("ID_INSTANTBATTLE"));
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
		mGoldCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		mButtonPrice.text = MiscTools.FormatBigNumber(mGoldCost);
		MiscTools.SetUILabelRescale(mButtonPrice, 59f, 20f, 650);
		mDescription.text = Localization.LocalizeFormat("ID_ACTIVATEXMOREINSTANTBATTLES", Colours.stringBlue, num, mButtonPrice.text);
		mButtonText.text = Localization.LocalizeFormat("ID_5SKIRMISHES", num);
		mPriceTable.repositionNow = true;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(mBottomButton.gameObject);
	}
}

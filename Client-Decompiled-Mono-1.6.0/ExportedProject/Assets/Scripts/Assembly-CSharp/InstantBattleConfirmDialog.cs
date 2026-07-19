using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class InstantBattleConfirmDialog : GuiElementSingle<InstantBattleConfirmDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Top")]
	private BoxCollider mCloseButton;

	[SerializeField]
	[Header("Middle")]
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

	private int NKFGNDFKGHC;

	public virtual void ILHPNHECBJG()
	{
		BMEGMMGDBEL(mBottomButton.gameObject);
	}

	private void ECDOKHBEKAH()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 1036f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKMMAEKBNMO));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mCloseButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		mPriceTable.onReposition = delegate
		{
			float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 2f;
			mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	public virtual void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JPIPLFGOOOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMEGMMGDBEL));
		UIEventListener uIEventListener3 = UIEventListener.Get(mCloseButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		mPriceTable.onReposition = OIBLDHPNCOC;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void OKMMGFMKJGG()
	{
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-58)).FLOATVALUE;
		mButtonPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MEJMLNDFDBP.COCBCFKJOJE(mButtonPrice, 1257f, 1677f, -117);
		UILabel uILabel = mDescription;
		object[] array = new object[7];
		array[1] = Colours.stringBlue;
		array[0] = num;
		array[6] = mButtonPrice.text;
		uILabel.text = Localization.LocalizeFormat("MoneyPackDeadline", array);
		UILabel uILabel2 = mButtonText;
		object[] array2 = new object[0];
		array2[1] = num;
		uILabel2.text = Localization.LocalizeFormat("CONFIRM", array2);
		mPriceTable.repositionNow = false;
	}

	private void JPIPLFGOOOC(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.CanBuyGold(NKFGNDFKGHC))
		{
			Singleton<Wallet>.instance.OFHCEFPOCMI(NKFGNDFKGHC);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("WarArenaData", NKFGNDFKGHC.ToString()));
			Singleton<BeanstalkServerManager>.instance.SendServerRequest((DatabaseAction)27, list);
			int fHNEBLGGJBM = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-169)).FLOATVALUE;
			GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = fHNEBLGGJBM;
			if (GuiElementSingle<InstantBattleResultsDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<InstantBattleResultsDialog>.instance.LAAOENFEEFF();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
			}
			HideDialog();
		}
		else
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(NKFGNDFKGHC, Localization.Localize("Main entity without photon view"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
		}
	}

	private void MNNDDFOKIKA()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 1422f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton.gameObject);
	}

	private void OPEIOMJOMDI()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 81f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void LMGBCIFHGFL()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 695f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	private void DMOBGFFMNFD(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void BMEGMMGDBEL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void PFLJKJCHCIF()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 668f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	private void CKMMAEKBNMO(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.CanBuyGold(NKFGNDFKGHC))
		{
			Singleton<Wallet>.instance.OFHCEFPOCMI(NKFGNDFKGHC);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("IsPaid", NKFGNDFKGHC.ToString()));
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.InstantBattle, list);
			int fHNEBLGGJBM = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
			GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM = fHNEBLGGJBM;
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
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(NKFGNDFKGHC, Localization.Localize("ID_INSTANTBATTLE"));
		}
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JPIPLFGOOOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMEGMMGDBEL));
		UIEventListener uIEventListener3 = UIEventListener.Get(mCloseButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BMEGMMGDBEL));
		mPriceTable.onReposition = LMGBCIFHGFL;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void CDHLMEPGPNJ()
	{
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-126)).FLOATVALUE;
		mButtonPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MEJMLNDFDBP.COCBCFKJOJE(mButtonPrice, 1215f, 1516f, 95);
		UILabel uILabel = mDescription;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		array[0] = num;
		array[2] = mButtonPrice.text;
		uILabel.text = Localization.LocalizeFormat("Claim Starter Assignment success!", array);
		UILabel uILabel2 = mButtonText;
		object[] array2 = new object[1];
		array2[1] = num;
		uILabel2.text = Localization.LocalizeFormat("ID_VISUALCATEGORYPARTS0", array2);
		mPriceTable.repositionNow = true;
	}

	public virtual void JCGDALOBGHO()
	{
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.CardCraftTimeSilver).FLOATVALUE;
		mButtonPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MEJMLNDFDBP.COCBCFKJOJE(mButtonPrice, 678f, 1698f, -133);
		UILabel uILabel = mDescription;
		object[] array = new object[1];
		array[0] = Colours.stringBlue;
		array[1] = num;
		array[7] = mButtonPrice.text;
		uILabel.text = Localization.LocalizeFormat("PA: number of sessions", array);
		UILabel uILabel2 = mButtonText;
		object[] array2 = new object[1];
		array2[1] = num;
		uILabel2.text = Localization.LocalizeFormat("ID_EMBLEM", array2);
		mPriceTable.repositionNow = false;
	}

	public override void InitGUIValues()
	{
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		mButtonPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MEJMLNDFDBP.COCBCFKJOJE(mButtonPrice, 59f, 20f, 650);
		mDescription.text = Localization.LocalizeFormat("ID_ACTIVATEXMOREINSTANTBATTLES", Colours.stringBlue, num, mButtonPrice.text);
		mButtonText.text = Localization.LocalizeFormat("ID_5SKIRMISHES", num);
		mPriceTable.repositionNow = true;
	}

	private void OIBLDHPNCOC()
	{
		float val = 0f - mPriceTable.padding.x - (mButtonPrice.transform.parent.localPosition.x - mPriceTable.padding.x) / 185f;
		mPriceTable.transform.localPosition = mPriceTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void DLCJLHFFLPJ()
	{
		DMOBGFFMNFD(mBottomButton.gameObject);
	}
}

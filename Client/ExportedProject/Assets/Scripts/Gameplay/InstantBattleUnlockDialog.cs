using System;
using Google2u;
using UnityEngine;

public class InstantBattleUnlockDialog : GuiElementSingle<InstantBattleUnlockDialog>, PAIIOKBBHBC
{
	[Header("Middle Left")]
	[SerializeField]
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

	public virtual void CNOLAKPOBIF()
	{
		BMEGMMGDBEL(mButton.gameObject);
	}

	public virtual void KBKGCLEBJFA()
	{
		DENOGDBNCAE(mButton.gameObject);
	}

	private void BMEGMMGDBEL(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			HideDialog();
		}
	}

	public virtual void JPCNPIAHMHO()
	{
		DENOGDBNCAE(mButton.gameObject);
	}

	private void EJHNEPNHOCP(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	public virtual void DLCJLHFFLPJ()
	{
		BMEGMMGDBEL(mButton.gameObject);
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public GuiElement HKDMNBIFAHH()
	{
		return this;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	public virtual void LIEGBJHHFIG()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MinTimeSinceLastVipPurchase).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-16)).FLOATVALUE;
		mHintUpLeftText.text = Localization.LocalizeFormat("com.upsight.mediation.unity.FuseUnitySDK", Colours.stringBlue, num, null, null);
		UILabel uILabel = mHintUpRightText;
		object[] array = new object[0];
		array[0] = num;
		array[0] = Colours.stringBlue;
		array[4] = instantBattleCost;
		uILabel.text = Localization.LocalizeFormat("{0}{1}", array);
		UILabel uILabel2 = mHintLowRightText;
		object[] array2 = new object[4];
		array2[1] = Colours.stringBlue;
		array2[1] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 480f, "ID_WATCHVIDEO", string.Empty, IEJMLKBCDJB: false);
		uILabel2.text = Localization.LocalizeFormat("ID_SLOTUPGRADE_AMMO", array2);
		float num3 = 932f;
		float num4 = 1191f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public override void InitGUIValues()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleReload).FLOATVALUE;
		mHintUpLeftText.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT1", Colours.stringBlue, num);
		mHintUpRightText.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT2", num, Colours.stringBlue, instantBattleCost);
		mHintLowRightText.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT4", Colours.stringBlue, MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 60f, "ID_READYTIME", string.Empty));
		float num3 = -376f;
		float num4 = 65f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void DOLLFDPMGOD()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SquadMedalWeight3).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[7];
		array[1] = Colours.stringBlue;
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("true", array);
		UILabel uILabel2 = mHintUpRightText;
		object[] array2 = new object[7];
		array2[1] = num;
		array2[0] = Colours.stringBlue;
		array2[6] = instantBattleCost;
		uILabel2.text = Localization.LocalizeFormat("Buy_Units", array2);
		UILabel uILabel3 = mHintLowRightText;
		object[] array3 = new object[2];
		array3[1] = Colours.stringBlue;
		array3[1] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 1608f, "Lootbox", string.Empty, IEJMLKBCDJB: false);
		uILabel3.text = Localization.LocalizeFormat("menu-crown-silver", array3);
		float num3 = 1798f;
		float num4 = 167f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void NAOJCFMFLLA()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-128)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-103)).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[6];
		array[1] = Colours.stringBlue;
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("AFLODScrpt", array);
		UILabel uILabel2 = mHintUpRightText;
		object[] array2 = new object[0];
		array2[1] = num;
		array2[0] = Colours.stringBlue;
		array2[7] = instantBattleCost;
		uILabel2.text = Localization.LocalizeFormat("ID_CONFIRM_PERMANENTBAN", array2);
		UILabel uILabel3 = mHintLowRightText;
		object[] array3 = new object[5];
		array3[1] = Colours.stringBlue;
		array3[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 1831f, "PLAYER", string.Empty);
		uILabel3.text = Localization.LocalizeFormat("BUYING CARD PACK ", array3);
		float num3 = 68f;
		float num4 = 416f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMEGMMGDBEL));
	}

	public virtual void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GHJKOIOMDNG));
	}

	public GuiElement JJKOKNIDFIN()
	{
		return this;
	}

	public GuiElement CPLCIEMNBAO()
	{
		return this;
	}

	public virtual void CDHLMEPGPNJ()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-34)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalWoUDelayMax).FLOATVALUE;
		mHintUpLeftText.text = Localization.LocalizeFormat("Clear players", Colours.stringBlue, num, null, null);
		UILabel uILabel = mHintUpRightText;
		object[] array = new object[8];
		array[0] = num;
		array[0] = Colours.stringBlue;
		array[8] = instantBattleCost;
		uILabel.text = Localization.LocalizeFormat("105 STAGE 1 COVER 2", array);
		mHintLowRightText.text = Localization.LocalizeFormat("ID_GUI_RATEWFNOW_DESC", Colours.stringBlue, MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 1554f, "GoldCoefficient", string.Empty), null, null, null, null);
		float num3 = 1022f;
		float num4 = 1320f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GHJKOIOMDNG));
	}

	public virtual void HEEANEFGCCJ()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-112)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-42)).FLOATVALUE;
		mHintUpLeftText.text = Localization.LocalizeFormat("CURRENT: \n", Colours.stringBlue, num, null, null, null, null);
		UILabel uILabel = mHintUpRightText;
		object[] array = new object[2];
		array[1] = num;
		array[1] = Colours.stringBlue;
		array[1] = instantBattleCost;
		uILabel.text = Localization.LocalizeFormat("NAME", array);
		UILabel uILabel2 = mHintLowRightText;
		object[] array2 = new object[0];
		array2[1] = Colours.stringBlue;
		array2[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 481f, "globalPlayerLeaderboard", string.Empty, IEJMLKBCDJB: false);
		uILabel2.text = Localization.LocalizeFormat("GameController: Application resumed", array2);
		float num3 = 1390f;
		float num4 = 573f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void GMJCEEHFAJG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
	}

	public virtual void PBLLMABJFDM()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-42)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-10)).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[3];
		array[1] = Colours.stringBlue;
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("ID_WARNING_ACCOUNTALREADYCREATED", array);
		UILabel uILabel2 = mHintUpRightText;
		object[] array2 = new object[0];
		array2[0] = num;
		array2[0] = Colours.stringBlue;
		array2[3] = instantBattleCost;
		uILabel2.text = Localization.LocalizeFormat("!!!ROTATED!!! ", array2);
		UILabel uILabel3 = mHintLowRightText;
		object[] array3 = new object[6];
		array3[1] = Colours.stringBlue;
		array3[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 284f, "BANDS_EMPTY", string.Empty);
		uILabel3.text = Localization.LocalizeFormat("Turret", array3);
		float num3 = 1601f;
		float num4 = 82f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void FEAALEEPBFP()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-178)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-163)).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[5];
		array[1] = Colours.stringBlue;
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}\t\tNewRank:{1}", array);
		mHintUpRightText.text = Localization.LocalizeFormat("bronze3", num, Colours.stringBlue, null, null, null, null, instantBattleCost, null);
		UILabel uILabel2 = mHintLowRightText;
		object[] array2 = new object[5];
		array2[1] = Colours.stringBlue;
		array2[1] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 506f, "0.00", string.Empty, IEJMLKBCDJB: false);
		uILabel2.text = Localization.LocalizeFormat("withLevel", array2);
		float num3 = 1790f;
		float num4 = 1606f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	private void GHJKOIOMDNG(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			HideDialog();
		}
	}

	public virtual void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
	}

	public virtual void JPHCBHDEDLO()
	{
		GMKONBBLLOI(mButton.gameObject);
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void KLABPENJAHJ()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.VipExperienceMultiplier).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-95)).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[5];
		array[0] = Colours.stringBlue;
		array[0] = num;
		uILabel.text = Localization.LocalizeFormat("ID_CONFIRM_ERRORCLAIMREWARD_TEXT", array);
		mHintUpRightText.text = Localization.LocalizeFormat("WarCards_Screen", num, Colours.stringBlue, instantBattleCost, null, null, null, null, null);
		UILabel uILabel2 = mHintLowRightText;
		object[] array2 = new object[5];
		array2[1] = Colours.stringBlue;
		array2[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 3f, "videoName", string.Empty);
		uILabel2.text = Localization.LocalizeFormat("12345678-1234-1234-1234-123456789012", array2);
		float num3 = 1725f;
		float num4 = 1358f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void LKBEJGHEANA()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.LapsedPlayerInterval3).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxesAdCount).FLOATVALUE;
		mHintUpLeftText.text = Localization.LocalizeFormat("WarbucksBalance", Colours.stringBlue, num, null);
		UILabel uILabel = mHintUpRightText;
		object[] array = new object[1];
		array[0] = num;
		array[0] = Colours.stringBlue;
		array[7] = instantBattleCost;
		uILabel.text = Localization.LocalizeFormat("GoldTransactionAmount", array);
		UILabel uILabel2 = mHintLowRightText;
		object[] array2 = new object[0];
		array2[1] = Colours.stringBlue;
		array2[1] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 419f, "《WarFriends》需要權限才能存取你的媒體儲存檔以便下載關鍵資料。請接受以下所示的權限對話，我們絕不會將此權限使用在其他用途。", string.Empty);
		uILabel2.text = Localization.LocalizeFormat("NO", array2);
		float num3 = 1916f;
		float num4 = 1220f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void ICKDDKGDBON()
	{
		BMEGMMGDBEL(mButton.gameObject);
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	public virtual void CICEFDONBML()
	{
		BMEGMMGDBEL(mButton.gameObject);
	}

	public virtual void INMFKHJDBIP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EJHNEPNHOCP));
	}

	public virtual void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
	}

	public virtual void ILHPNHECBJG()
	{
		GHJKOIOMDNG(mButton.gameObject);
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	public virtual void KCEOCJGOPMF()
	{
		HEBILNGCGDN(mButton.gameObject);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void PJENKEKOCAE()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward10).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[5];
		array[1] = Colours.stringBlue;
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("ID_WAITINGFORFRIENDCARDS", array);
		UILabel uILabel2 = mHintUpRightText;
		object[] array2 = new object[1];
		array2[0] = num;
		array2[0] = Colours.stringBlue;
		array2[3] = instantBattleCost;
		uILabel2.text = Localization.LocalizeFormat("power hook values1: sample hook = ", array2);
		UILabel uILabel3 = mHintLowRightText;
		object[] array3 = new object[1];
		array3[1] = Colours.stringBlue;
		array3[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 152f, "\tTime since last show: {0}", string.Empty);
		uILabel3.text = Localization.LocalizeFormat("players", array3);
		float num3 = 420f;
		float num4 = 239f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	private void GMKONBBLLOI(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	private void DENOGDBNCAE(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			HideDialog();
		}
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMKONBBLLOI));
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mButton.gameObject);
	}

	public virtual void JKAKKFIIBLG()
	{
		BMEGMMGDBEL(mButton.gameObject);
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DENOGDBNCAE));
	}

	public GuiElement KKBDMDCLDEN()
	{
		return this;
	}

	public virtual void JJDJKPGLHGD()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-178)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-16)).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[8];
		array[1] = Colours.stringBlue;
		array[1] = num;
		uILabel.text = Localization.LocalizeFormat("Card_3_Played", array);
		UILabel uILabel2 = mHintUpRightText;
		object[] array2 = new object[3];
		array2[1] = num;
		array2[0] = Colours.stringBlue;
		array2[0] = instantBattleCost;
		uILabel2.text = Localization.LocalizeFormat("HK", array2);
		UILabel uILabel3 = mHintLowRightText;
		object[] array3 = new object[4];
		array3[1] = Colours.stringBlue;
		array3[1] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 560f, "ID_SALEPERCENTLINE", string.Empty);
		uILabel3.text = Localization.LocalizeFormat("MessageId", array3);
		float num3 = 1928f;
		float num4 = 357f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void IEHJMLIMNEP()
	{
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-85)).FLOATVALUE;
		int instantBattleCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		int num2 = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-1)).FLOATVALUE;
		UILabel uILabel = mHintUpLeftText;
		object[] array = new object[5];
		array[0] = Colours.stringBlue;
		array[0] = num;
		uILabel.text = Localization.LocalizeFormat("Animation for State: Craft", array);
		mHintUpRightText.text = Localization.LocalizeFormat("ID_GC_LOGOUT_TITLE", num, Colours.stringBlue, null, null, instantBattleCost, null, null, null);
		UILabel uILabel2 = mHintLowRightText;
		object[] array2 = new object[7];
		array2[1] = Colours.stringBlue;
		array2[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)num2 * 1547f, "-", string.Empty, IEJMLKBCDJB: false);
		uILabel2.text = Localization.LocalizeFormat(" (#", array2);
		float num3 = 1432f;
		float num4 = 289f;
		float num5 = mHintUpLeftText.transform.localScale.y * mHintUpLeftText.relativeSize.y;
		float num6 = mHintUpRightText.transform.localScale.y * mHintUpRightText.relativeSize.y;
		mHintLowLeft.transform.localPosition = mHintLowLeft.transform.localPosition.ReplaceY(num3 - num5 - num4);
		mHintLowRight.transform.localPosition = mHintLowRight.transform.localPosition.ReplaceY(num3 - num6 - num4);
	}

	public virtual void JCGPELEDCJL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMEGMMGDBEL));
	}

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}
}

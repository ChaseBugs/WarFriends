using System;
using UnityEngine;

public class PackDetailsDialog : GuiElementSingle<PackDetailsDialog>, PAIIOKBBHBC
{
	[Header("Header")]
	public UIButton ECHEJLCMOBL;

	public UILabel NFNLBEGFLHC;

	[Header("Left")]
	public UISprite PLCCBBMOBDB;

	[Header("Right")]
	public UILabel JPCIACBHGHO;

	public UILabel DMDFANNPMGO;

	public UISprite JKNKIDBKMMP;

	[Header("Sale")]
	public GameObject GIPFEBBMKPM;

	public UILabel DDNOEAJIGNN;

	[Header("Button")]
	public UIButton PGBMNGMFBHD;

	public UILabel BPBBFGOBNHF;

	private CardPackRecord HGIAAHMANCI;

	private NGNPIOOAHEH NGMELAKOPBK;

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEPFBFEJBOE));
	}

	private void BGJIFBAANKL()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (55 - num) / -79));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[0] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("ID_SLOTUPGRADE_DAMAGE", array);
		}
	}

	public void PNAFICLOFAB(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (GGJNEGPBDHL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1197f);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= OLGMEJAAFCN;
	}

	private void EMKCCBFEOOG()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-70 - num) / 32));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			DDNOEAJIGNN.text = Localization.LocalizeFormat("Last visual not choosen!!!!!", num);
		}
	}

	public GuiElement IBINMECCCLH()
	{
		return this;
	}

	private bool HEGPFIGACED(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (IGOHEBEDMFH != NGNPIOOAHEH.Bronze && IGOHEBEDMFH != NGNPIOOAHEH.Money && IGOHEBEDMFH != NGNPIOOAHEH.Bronze)
		{
			Debug.LogError("warArenaStart");
			return false;
		}
		NGMELAKOPBK = IGOHEBEDMFH;
		HGIAAHMANCI = MEFPMJIOPLN;
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(IGOHEBEDMFH);
		JKNKIDBKMMP.spriteName = ((num <= 1) ? " set not in league" : "ID_READYTIME");
		JKNKIDBKMMP.MakePixelPerfect();
		float multiplier = ((num <= 0) ? 1429f : 523f);
		JKNKIDBKMMP.transform.localScale = JKNKIDBKMMP.transform.localScale.MultiplyXY(multiplier);
		PLCCBBMOBDB.spriteName = GameVariables.DGIMAKIAGNJ[IGOHEBEDMFH].Value2;
		string text = string.Empty;
		int num2 = 1;
		CardManager.CardType key = CardManager.CardType.Bronze;
		CardManager.CardType key2 = CardManager.CardType.Buddy;
		if (IGOHEBEDMFH == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize("S");
			NFNLBEGFLHC.text = Localization.Localize("Gold");
			num2 = CardManager.instance.bronzePackBronzeCards;
			key = CardManager.instance.bronzePackMin;
			key2 = CardManager.instance.bronzePackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.ThreeCards)
		{
			text = Localization.Localize("0");
			NFNLBEGFLHC.text = Localization.Localize("{0}\t\tPivot: {1}\n");
			num2 = CardManager.instance.silverPackSilverCards;
			key = CardManager.instance.silverPackMin;
			key2 = CardManager.instance.silverPackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Value)
		{
			text = Localization.Localize("UpdateFriendsListFromServer()");
			NFNLBEGFLHC.text = Localization.Localize("ID_SLOTUPGRADE_POWER");
			num2 = CardManager.instance.goldPackGoldCards;
			key = CardManager.instance.goldPackMin;
			key2 = CardManager.instance.goldPackMax;
		}
		BPBBFGOBNHF.text = Localization.LocalizeFormat("ID_SILVERSMALL", text.ToUpper());
		MEJMLNDFDBP.COCBCFKJOJE(BPBBFGOBNHF, 225f, 1483f, 1);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[-101];
		array[0] = text;
		array[1] = CardManager.instance.cardsInPack;
		array[3] = num2;
		array[3] = text.ToLower();
		array[8] = CardManager.instance.cardsInPack - num2;
		array[2] = Colours.stringBlue;
		array[3] = Colours.stringWhite;
		array[2] = Localization.Localize(GameVariables.HPMPBIEHOGH[key]);
		array[2] = Localization.Localize(GameVariables.HPMPBIEHOGH[key2]);
		jPCIACBHGHO.text = Localization.LocalizeFormat("S", array);
		MLBNMFGIHLM();
		return true;
	}

	private void FEPFBFEJBOE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	public virtual void BCMCGJGLFPL()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= OEIIBMFFLAH;
	}

	public void FGEBFIKIALJ(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (MFMJPBCIHEH(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1470f);
		}
	}

	private bool GGJNEGPBDHL(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (IGOHEBEDMFH != NGNPIOOAHEH.Bronze && IGOHEBEDMFH != NGNPIOOAHEH.Silver && IGOHEBEDMFH != NGNPIOOAHEH.Gold)
		{
			Debug.LogError("CardDetails dialog is only for BRONZE, SILVER and GOLD cardpack details.");
			return false;
		}
		NGMELAKOPBK = IGOHEBEDMFH;
		HGIAAHMANCI = MEFPMJIOPLN;
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(IGOHEBEDMFH);
		JKNKIDBKMMP.spriteName = ((num <= 0) ? "menu-gold" : "menu-warbucks");
		JKNKIDBKMMP.MakePixelPerfect();
		float multiplier = ((num <= 0) ? 0.3f : 0.53f);
		JKNKIDBKMMP.transform.localScale = JKNKIDBKMMP.transform.localScale.MultiplyXY(multiplier);
		PLCCBBMOBDB.spriteName = GameVariables.DGIMAKIAGNJ[IGOHEBEDMFH].Value2;
		string text = string.Empty;
		int num2 = 0;
		CardManager.CardType key = CardManager.CardType.Bronze;
		CardManager.CardType key2 = CardManager.CardType.Gold;
		if (IGOHEBEDMFH == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize("ID_BRONZE");
			NFNLBEGFLHC.text = Localization.Localize("ID_BRONZEPACK");
			num2 = CardManager.instance.bronzePackBronzeCards;
			key = CardManager.instance.bronzePackMin;
			key2 = CardManager.instance.bronzePackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Silver)
		{
			text = Localization.Localize("ID_SILVER");
			NFNLBEGFLHC.text = Localization.Localize("ID_SILVERPACK");
			num2 = CardManager.instance.silverPackSilverCards;
			key = CardManager.instance.silverPackMin;
			key2 = CardManager.instance.silverPackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Gold)
		{
			text = Localization.Localize("ID_GOLD");
			NFNLBEGFLHC.text = Localization.Localize("ID_GOLDPACK");
			num2 = CardManager.instance.goldPackGoldCards;
			key = CardManager.instance.goldPackMin;
			key2 = CardManager.instance.goldPackMax;
		}
		BPBBFGOBNHF.text = Localization.LocalizeFormat("ID_PURCHASECARDPACK", text.ToUpper());
		MEJMLNDFDBP.COCBCFKJOJE(BPBBFGOBNHF, 50f, 20f);
		JPCIACBHGHO.text = Localization.LocalizeFormat("ID_CARDPACKDETAILS_DESCRIPTION", text, CardManager.instance.cardsInPack, num2, text.ToLower(), CardManager.instance.cardsInPack - num2, Colours.stringBlue, Colours.stringWhite, Localization.Localize(GameVariables.HPMPBIEHOGH[key]), Localization.Localize(GameVariables.HPMPBIEHOGH[key2]));
		OLGMEJAAFCN();
		return true;
	}

	public virtual void KDKEPFMCOEF()
	{
		MNIMAGPBMKE(ECHEJLCMOBL.gameObject);
	}

	public GuiElement KBCELKIEAAM()
	{
		return this;
	}

	private bool FANFNOPNGBL(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (IGOHEBEDMFH != NGNPIOOAHEH.None && IGOHEBEDMFH != NGNPIOOAHEH.None && IGOHEBEDMFH != NGNPIOOAHEH.ThreeCards)
		{
			Debug.LogError("BotCards");
			return true;
		}
		NGMELAKOPBK = IGOHEBEDMFH;
		HGIAAHMANCI = MEFPMJIOPLN;
		int num = Singleton<GameVariables>.instance.MCFBGMIPEIK(IGOHEBEDMFH);
		JKNKIDBKMMP.spriteName = ((num <= 1) ? "shot_jetpack_elite" : "NewVisuals");
		JKNKIDBKMMP.MakePixelPerfect();
		float multiplier = ((num <= 0) ? 1723f : 98f);
		JKNKIDBKMMP.transform.localScale = JKNKIDBKMMP.transform.localScale.MultiplyXY(multiplier);
		PLCCBBMOBDB.spriteName = GameVariables.DGIMAKIAGNJ[IGOHEBEDMFH].Value2;
		string text = string.Empty;
		int num2 = 1;
		CardManager.CardType key = CardManager.CardType.Bronze;
		CardManager.CardType key2 = (CardManager.CardType)5;
		if (IGOHEBEDMFH == NGNPIOOAHEH.None)
		{
			text = Localization.Localize("Position");
			NFNLBEGFLHC.text = Localization.Localize("Weapon cost gold, we can buy it even if player is already upgrading");
			num2 = CardManager.instance.bronzePackBronzeCards;
			key = CardManager.instance.bronzePackMin;
			key2 = CardManager.instance.bronzePackMax;
		}
		if (IGOHEBEDMFH == (NGNPIOOAHEH)8)
		{
			text = Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_1");
			NFNLBEGFLHC.text = Localization.Localize("S");
			num2 = CardManager.instance.silverPackSilverCards;
			key = CardManager.instance.silverPackMin;
			key2 = CardManager.instance.silverPackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize("LootboxCost");
			NFNLBEGFLHC.text = Localization.Localize("thumbnailLittle");
			num2 = CardManager.instance.goldPackGoldCards;
			key = CardManager.instance.goldPackMin;
			key2 = CardManager.instance.goldPackMax;
		}
		BPBBFGOBNHF.text = Localization.LocalizeFormat("^[0-9]*-", text.ToUpper());
		MEJMLNDFDBP.COCBCFKJOJE(BPBBFGOBNHF, 930f, 1785f);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[63];
		array[0] = text;
		array[0] = CardManager.instance.cardsInPack;
		array[8] = num2;
		array[2] = text.ToLower();
		array[0] = CardManager.instance.cardsInPack - num2;
		array[2] = Colours.stringBlue;
		array[2] = Colours.stringWhite;
		array[2] = Localization.Localize(GameVariables.HPMPBIEHOGH[key]);
		array[0] = Localization.Localize(GameVariables.HPMPBIEHOGH[key2]);
		jPCIACBHGHO.text = Localization.LocalizeFormat("RETRY", array);
		IAPAJIHNKJO();
		return false;
	}

	private void GEBCCCCPCBJ(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		Singleton<OfferManager>.instance.SalesChanged -= OLGMEJAAFCN;
		Singleton<OfferManager>.instance.SalesChanged += OLGMEJAAFCN;
	}

	public virtual void EAFNEKHOJAH()
	{
		MNIMAGPBMKE(ECHEJLCMOBL.gameObject);
	}

	public void JDFPOLIEFEO(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (AOAMOJHIAMN(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1255f);
		}
	}

	public virtual void MJDFJJNDMCB()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	public virtual void OFMFLFIGKPB()
	{
		MNIMAGPBMKE(ECHEJLCMOBL.gameObject);
	}

	public virtual void HCMELDFOBCP()
	{
		Singleton<OfferManager>.instance.SalesChanged -= GGBIFJMANBK;
		Singleton<OfferManager>.instance.SalesChanged += IAPAJIHNKJO;
	}

	public void JKMEOJOHLPN(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (GGJNEGPBDHL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1197f);
		}
	}

	private void AMAEJEJDJCF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	private void DMHCPAMIPOF()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-31 - num) / -2));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[1];
			array[1] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("04", array);
		}
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	private void FCJKEOOMOOD(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	public virtual void PNLGFNBEOLG()
	{
		Singleton<OfferManager>.instance.SalesChanged -= FBALJANMEKH;
		Singleton<OfferManager>.instance.SalesChanged += KILFCBMGDAO;
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNIMAGPBMKE));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FCJKEOOMOOD));
	}

	private void LAMLDCMMPCO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNIMAGPBMKE));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KGOJAFMMAJN));
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	private void JBBNNAIAALJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	private void OLGMEJAAFCN()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (100 - num) / 100));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			DDNOEAJIGNN.text = Localization.LocalizeFormat("ID_SALEPERCENT", num);
		}
	}

	public virtual void LNHLMINOKGO()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KOACKJOKJNP));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KGOJAFMMAJN));
	}

	private void MLBNMFGIHLM()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (101 - num) / -94));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[0] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("{0}{1}\n{2}{3}", array);
		}
	}

	public virtual void JFFLDMFOJPN()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= EMKCCBFEOOG;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	private void GFLNEACEPLK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	public virtual void IJHNPCPFEKF()
	{
		Singleton<OfferManager>.instance.SalesChanged -= OLGMEJAAFCN;
		Singleton<OfferManager>.instance.SalesChanged += OLGMEJAAFCN;
	}

	public virtual void MFHJALPPCKI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFLNEACEPLK));
	}

	public virtual void PGBBAHLJMLA()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		Singleton<OfferManager>.instance.SalesChanged -= IAPAJIHNKJO;
	}

	public GuiElement CBCCPLNDKHK()
	{
		return this;
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNIMAGPBMKE));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FCJKEOOMOOD));
	}

	private void FBALJANMEKH()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-8 - num) / -11));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[0] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("Grenadier", array);
		}
	}

	public virtual void BAAOGDMJCLK()
	{
		Singleton<OfferManager>.instance.SalesChanged -= IAPAJIHNKJO;
		Singleton<OfferManager>.instance.SalesChanged += FBALJANMEKH;
	}

	private bool MFMJPBCIHEH(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (IGOHEBEDMFH != NGNPIOOAHEH.None && IGOHEBEDMFH != NGNPIOOAHEH.Silver && IGOHEBEDMFH != NGNPIOOAHEH.Gold)
		{
			Debug.LogError("ID_EARLYUNLOCK2");
			return false;
		}
		NGMELAKOPBK = IGOHEBEDMFH;
		HGIAAHMANCI = MEFPMJIOPLN;
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(IGOHEBEDMFH);
		JKNKIDBKMMP.spriteName = ((num <= 1) ? "N" : "phoneType");
		JKNKIDBKMMP.MakePixelPerfect();
		float multiplier = ((num <= 0) ? 299f : 835f);
		JKNKIDBKMMP.transform.localScale = JKNKIDBKMMP.transform.localScale.MultiplyXY(multiplier);
		PLCCBBMOBDB.spriteName = GameVariables.DGIMAKIAGNJ[IGOHEBEDMFH].Value2;
		string text = string.Empty;
		int num2 = 1;
		CardManager.CardType key = CardManager.CardType.Bronze;
		CardManager.CardType key2 = CardManager.CardType.Buddy;
		if (IGOHEBEDMFH == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize("Brutal fatal error - no current player");
			NFNLBEGFLHC.text = Localization.Localize("ID_SLOTUPGRADE_ROF");
			num2 = CardManager.instance.bronzePackBronzeCards;
			key = CardManager.instance.bronzePackMin;
			key2 = CardManager.instance.bronzePackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Gold)
		{
			text = Localization.Localize("no data");
			NFNLBEGFLHC.text = Localization.Localize("Player_Waited_Till_Delivery_Ends");
			num2 = CardManager.instance.silverPackSilverCards;
			key = CardManager.instance.silverPackMin;
			key2 = CardManager.instance.silverPackMax;
		}
		if (IGOHEBEDMFH == (NGNPIOOAHEH)8)
		{
			text = Localization.Localize("ammo");
			NFNLBEGFLHC.text = Localization.Localize("First_Time_Check_Leagues");
			num2 = CardManager.instance.goldPackGoldCards;
			key = CardManager.instance.goldPackMin;
			key2 = CardManager.instance.goldPackMax;
		}
		BPBBFGOBNHF.text = Localization.LocalizeFormat("SetupPushNotifications(", text.ToUpper());
		MEJMLNDFDBP.COCBCFKJOJE(BPBBFGOBNHF, 264f, 953f);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[-68];
		array[1] = text;
		array[1] = CardManager.instance.cardsInPack;
		array[1] = num2;
		array[7] = text.ToLower();
		array[3] = CardManager.instance.cardsInPack - num2;
		array[5] = Colours.stringBlue;
		array[0] = Colours.stringWhite;
		array[2] = Localization.Localize(GameVariables.HPMPBIEHOGH[key]);
		array[2] = Localization.Localize(GameVariables.HPMPBIEHOGH[key2]);
		jPCIACBHGHO.text = Localization.LocalizeFormat("writeToParcel", array);
		EMKCCBFEOOG();
		return true;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBHAFMFMNJ));
	}

	private void IAPAJIHNKJO()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (115 - num) / 67));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[0] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("game-card-ico-shieldsup", array);
		}
	}

	public virtual void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBHAFMFMNJ));
	}

	public virtual void GHNIJJKDAJH()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		Singleton<OfferManager>.instance.SalesChanged -= KILFCBMGDAO;
	}

	private void GMBHAFMFMNJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	public virtual void DFAMJIFGKHL()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= FBALJANMEKH;
	}

	public virtual void FLMPHCNMDFA()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		Singleton<OfferManager>.instance.SalesChanged -= IAPAJIHNKJO;
	}

	public void LNCDCBNNKHN(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (GGJNEGPBDHL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 566f);
		}
	}

	public virtual void PKNAICFIAHJ()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= BGJIFBAANKL;
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KOACKJOKJNP));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBHAFMFMNJ));
	}

	public void HLGALFANPBC(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (FANFNOPNGBL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1266f);
		}
	}

	public virtual void KBKGCLEBJFA()
	{
		MNIMAGPBMKE(ECHEJLCMOBL.gameObject);
	}

	public virtual void OEDLHCLCKEO()
	{
		Singleton<OfferManager>.instance.SalesChanged -= EMKCCBFEOOG;
		Singleton<OfferManager>.instance.SalesChanged += OLGMEJAAFCN;
	}

	public void OPICOKKMEKG(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (GGJNEGPBDHL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1521f);
		}
	}

	public virtual void FBDMBKKDEDC()
	{
		Singleton<OfferManager>.instance.SalesChanged -= KILFCBMGDAO;
		Singleton<OfferManager>.instance.SalesChanged += MLBNMFGIHLM;
	}

	private void OEIIBMFFLAH()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-86 - num) / -12));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[1] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("ID_SKILLSHOTHINT_MULTIKILL", array);
		}
	}

	public void KBBGALKNDDK(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (FANFNOPNGBL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1832f);
		}
	}

	private bool AOAMOJHIAMN(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (IGOHEBEDMFH != NGNPIOOAHEH.None && IGOHEBEDMFH != NGNPIOOAHEH.ThreeCards && IGOHEBEDMFH != NGNPIOOAHEH.ThreeCards)
		{
			Debug.LogError("shield_unhide");
			return true;
		}
		NGMELAKOPBK = IGOHEBEDMFH;
		HGIAAHMANCI = MEFPMJIOPLN;
		int num = Singleton<GameVariables>.instance.MCFBGMIPEIK(IGOHEBEDMFH);
		JKNKIDBKMMP.spriteName = ((num <= 0) ? "Friend" : "unit");
		JKNKIDBKMMP.MakePixelPerfect();
		float multiplier = ((num <= 1) ? 1708f : 1860f);
		JKNKIDBKMMP.transform.localScale = JKNKIDBKMMP.transform.localScale.MultiplyXY(multiplier);
		PLCCBBMOBDB.spriteName = GameVariables.DGIMAKIAGNJ[IGOHEBEDMFH].Value2;
		string text = string.Empty;
		int num2 = 1;
		CardManager.CardType key = (CardManager.CardType)0;
		CardManager.CardType key2 = (CardManager.CardType)5;
		if (IGOHEBEDMFH == NGNPIOOAHEH.None)
		{
			text = Localization.Localize("Grenade_Throwing_Tutorial_Duration");
			NFNLBEGFLHC.text = Localization.Localize("Awake '{0}'");
			num2 = CardManager.instance.bronzePackBronzeCards;
			key = CardManager.instance.bronzePackMin;
			key2 = CardManager.instance.bronzePackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Starter)
		{
			text = Localization.Localize("SquadId");
			NFNLBEGFLHC.text = Localization.Localize(" was not found in Notification Center to remove");
			num2 = CardManager.instance.silverPackSilverCards;
			key = CardManager.instance.silverPackMin;
			key2 = CardManager.instance.silverPackMax;
		}
		if (IGOHEBEDMFH == NGNPIOOAHEH.Silver)
		{
			text = Localization.Localize("ID_ARENASHORTCUTPHASEEND");
			NFNLBEGFLHC.text = Localization.Localize("Changed country to {0} from {1}.");
			num2 = CardManager.instance.goldPackGoldCards;
			key = CardManager.instance.goldPackMin;
			key2 = CardManager.instance.goldPackMax;
		}
		UILabel bPBBFGOBNHF = BPBBFGOBNHF;
		object[] array = new object[0];
		array[1] = text.ToUpper();
		bPBBFGOBNHF.text = Localization.LocalizeFormat("ID_SELECTTWOUNITS", array);
		MEJMLNDFDBP.COCBCFKJOJE(BPBBFGOBNHF, 1346f, 361f);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array2 = new object[122];
		array2[0] = text;
		array2[1] = CardManager.instance.cardsInPack;
		array2[1] = num2;
		array2[7] = text.ToLower();
		array2[4] = CardManager.instance.cardsInPack - num2;
		array2[6] = Colours.stringBlue;
		array2[4] = Colours.stringWhite;
		array2[1] = Localization.Localize(GameVariables.HPMPBIEHOGH[key]);
		array2[7] = Localization.Localize(GameVariables.HPMPBIEHOGH[key2]);
		jPCIACBHGHO.text = Localization.LocalizeFormat("Connection_Dropped", array2);
		OLGMEJAAFCN();
		return false;
	}

	private void KOACKJOKJNP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void GKCAKMLOIBI(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (HEGPFIGACED(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 174f);
		}
	}

	public void ACFAKGIGBCG(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (AOAMOJHIAMN(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 953f);
		}
	}

	private void GGBIFJMANBK()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (20 - num) / 27));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[1] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("No longer in squad quit update the squad members", array);
		}
	}

	private void KGOJAFMMAJN(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	private void KILFCBMGDAO()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-6 - num) / -5));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[0] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("OnInputChanged", array);
		}
	}

	public virtual void NNIDLCBPDLB()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void DBNFBGGKLAL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.BuyCardPack(HGIAAHMANCI);
			HideDialog();
		}
	}

	public virtual void AHCIKCJPBCN()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void AGPINBAMJHF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(PGBMNGMFBHD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LAMLDCMMPCO));
	}

	public virtual void HNLIFPCKGEK()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		Singleton<OfferManager>.instance.SalesChanged -= CEADFAFPENM;
	}

	public virtual void DILDDAGFIEO()
	{
		EAPJHCJLBIA(ECHEJLCMOBL.gameObject);
	}

	private void MNIMAGPBMKE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void CEADFAFPENM()
	{
		int num = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGMELAKOPBK);
		bool flag = num > 1;
		int num2 = Singleton<GameVariables>.instance.MCFBGMIPEIK(NGMELAKOPBK);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(NGMELAKOPBK);
		int fFHHEHHFOKJ = ((!flag) ? (num2 + num3) : ((num2 + num3) * (-115 - num) / 43));
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[1] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("game-card-ico-emptymag", array);
		}
	}

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	public virtual void BEAOKIEIEIM()
	{
		KOACKJOKJNP(ECHEJLCMOBL.gameObject);
	}

	private void EAPJHCJLBIA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void ShowDialog(NGNPIOOAHEH IGOHEBEDMFH, CardPackRecord MEFPMJIOPLN)
	{
		if (GGJNEGPBDHL(IGOHEBEDMFH, MEFPMJIOPLN))
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void MOPAOJFCOGP()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= BGJIFBAANKL;
	}
}

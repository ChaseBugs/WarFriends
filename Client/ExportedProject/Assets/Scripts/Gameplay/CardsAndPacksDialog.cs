using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CardsAndPacksDialog : GuiElementSingle<CardsAndPacksDialog>, PAIIOKBBHBC
{
	public enum LJCNLBMEENL
	{
		STARTER_PACK,
		VALUE_PACK,
		MONEY_PACK
	}

	[Header("General")]
	[FormerlySerializedAs("HKAELKNPPGD")]
	public UILabel NFNLBEGFLHC;

	[FormerlySerializedAs("BALEOFOKIOC")]
	public UILabel HOLNKOFHDNK;

	[FormerlySerializedAs("PLDFGMHICCA")]
	public UIButton LJNPCHFCGCN;

	[FormerlySerializedAs("PIOAGBHJDFL")]
	[Header("Button")]
	public UIButton HDDBLHBCFHG;

	[FormerlySerializedAs("NMJCMEPOLON")]
	public UILabel GMBJHOCENGD;

	[Header("Price panel no sale")]
	[FormerlySerializedAs("NGIEPMKOEMC")]
	public GameObject MHOHDMJCJJI;

	[FormerlySerializedAs("HCDNHKLGLMI")]
	public UILabel GBBBLBJNCAM;

	[Header("Price panel sale")]
	[FormerlySerializedAs("IAOPIEBKBJJ")]
	public GameObject GIPFEBBMKPM;

	[FormerlySerializedAs("FPAHBPJAAAO")]
	public UILabel JHIPEOCMMLM;

	[FormerlySerializedAs("PGLAINHFLIN")]
	public UILabel GNKIKDJLCEH;

	[FormerlySerializedAs("FFCJCCBLPKK")]
	public StrikethroughPrize OABLAOEHHGC;

	[FormerlySerializedAs("DNPBFOPEJOF")]
	public UILabel NHLIOGMJIIL;

	[Header("Offer Active")]
	[FormerlySerializedAs("JHEAJGCIALP")]
	public GameObject ALKEGOAOICB;

	public UILabel MEFMGHEILOG;

	[Header("-Starter Pack Content")]
	[FormerlySerializedAs("AIOHEMAKGOB")]
	public GameObject AMPFHINKAGC;

	public UITexture NGHCDIMLGMO;

	[Header("-Value Pack Content")]
	public GameObject PMOALAAIKEP;

	[Header("-Boxes")]
	[FormerlySerializedAs("HDGIKBJEBCC")]
	public SpecialPackBoxItem[] BKPNOABFMGN;

	private bool CEEOLBCLPOB;

	private LJCNLBMEENL BHJPFGKALEN;

	private bool MCGKPDLPDBK;

	private JGBBPCGNCPC PIIMDABCJFP;

	private bool JFKIPIKKGNO;

	private void MINAPKFLHEA()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: true);
		DLNFBJHHGBK();
		PIIMDABCJFP = Singleton<GameVariables>.instance.starterPack;
		BKPNOABFMGN[0].Initialize(2, 5, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(3, 5, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].Initialize(4, 5, PIIMDABCJFP.ACNHHOFIJMH[2]);
		BKPNOABFMGN[3].Initialize(5, 5, PIIMDABCJFP.ACNHHOFIJMH[3]);
	}

	private void KEOIGIHMEOI()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			resourceLoaderTexture2D.FreeAsset("PlayCardRPC");
			JFKIPIKKGNO = true;
		}
	}

	private void IGLJONJALHD()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: true);
		PIIMDABCJFP = Singleton<GameVariables>.instance.moneyPack;
		BKPNOABFMGN[0].Initialize(1, 3, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(2, 3, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].Initialize(3, 3, PIIMDABCJFP.ACNHHOFIJMH[2]);
	}

	private void OADPONDBCJD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			OBGFGPHGGPH();
			HideDialog();
		}
	}

	public virtual void NEINEPJDKCL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADPONDBCJD));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFJMKOALDLE));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += JMPOIAFDDBG;
	}

	private void IBNDOPGGEJB()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		foreach (SpecialPackBoxItem specialPackBoxItem in bKPNOABFMGN)
		{
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	public virtual void INMFKHJDBIP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDLIKCKLJBD));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += PLKFKCOJMFJ;
	}

	public virtual void BCLAFFCPCEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPOGEIGDJEG));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += JMPOIAFDDBG;
	}

	private void KIHKPBOAPOL()
	{
		NGNPIOOAHEH mLNLPPOLMEK = NGNPIOOAHEH.Bronze;
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			mLNLPPOLMEK = NGNPIOOAHEH.ThreeCards;
			break;
		case LJCNLBMEENL.VALUE_PACK:
			mLNLPPOLMEK = (NGNPIOOAHEH)8;
			break;
		case (LJCNLBMEENL)3:
			mLNLPPOLMEK = NGNPIOOAHEH.Value;
			break;
		}
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(mLNLPPOLMEK);
		bool flag = num > 1259f;
		MHOHDMJCJJI.SetActive(!flag);
		GIPFEBBMKPM.SetActive(flag);
		string value = Singleton<GameVariables>.instance.PriceOfPack(mLNLPPOLMEK).Value2;
		string value2 = Singleton<GameVariables>.instance.MAMBIEIKLJB(mLNLPPOLMEK).Value2;
		GBBBLBJNCAM.text = value;
		GNKIKDJLCEH.text = value;
		NHLIOGMJIIL.text = value2;
		UILabel jHIPEOCMMLM = JHIPEOCMMLM;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 44f);
		jHIPEOCMMLM.text = Localization.LocalizeFormat("VIP", array);
		MEJMLNDFDBP.COCBCFKJOJE(JHIPEOCMMLM, 1806f, 1898f, -62);
		if (flag)
		{
			OABLAOEHHGC.NAMAPIEHLMN();
		}
	}

	private void OMCNLOHKCBJ()
	{
		IDHHLOMBNJD();
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			switch (bHJPFGKALEN)
			{
			case LJCNLBMEENL.STARTER_PACK:
				NFNLBEGFLHC.text = Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK");
				HOLNKOFHDNK.text = Localization.Localize("#VOJTA# WAR ARENA CONFIG RECEIVED! Id = ");
				GMBJHOCENGD.text = Localization.Localize("ID_READYTIME");
				IOHJOGNIAHK();
				break;
			case (LJCNLBMEENL)4:
				NFNLBEGFLHC.text = Localization.Localize("ID_YOUNEEDATLEASTONEDOGTAGTOPLAY");
				GMBJHOCENGD.text = Localization.Localize("smallThumbnailLittle");
				NGPNPJDLGLP();
				break;
			}
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("test_attribute3");
			GMBJHOCENGD.text = Localization.Localize("Gold");
			LFJOGAAMFPF();
		}
		MEJMLNDFDBP.COCBCFKJOJE(GMBJHOCENGD, 454f, 1781f, -198);
		KMNGDNDDPKO();
	}

	private void PLKFKCOJMFJ()
	{
		if (isShowed)
		{
			PPPKCLBOKAH();
		}
	}

	private void AKANJBCJDGJ()
	{
		if (NPFFMLLLDAF())
		{
			KIHKPBOAPOL();
		}
	}

	private void ADPPLDMNMKP()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: true);
		PIIMDABCJFP = Singleton<GameVariables>.instance.moneyPack;
		BKPNOABFMGN[0].GOMJAFCDKDD(1, 5, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].MKENDIKJPLJ(6, 1, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].Initialize(8, 0, PIIMDABCJFP.ACNHHOFIJMH[2]);
	}

	public GuiElement HEINBAHFBLA()
	{
		return this;
	}

	public void NFEPFHPOIIM(JGBBPCGNCPC JCBCHFJPPNK)
	{
		IDHHLOMBNJD();
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: true);
		int num = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num < 5)
		{
			if (num == 1)
			{
				BKPNOABFMGN[0].GOMJAFCDKDD(0, 3, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 1; i <= num && i <= 1; i += 0)
			{
				BKPNOABFMGN[i - 1].MKENDIKJPLJ(i, num, JCBCHFJPPNK.ACNHHOFIJMH[i - 0]);
			}
		}
	}

	public virtual void BGDBMCDGBGE()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		for (int i = 1; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		OPPAADCPKCL();
	}

	public virtual void JGNLJEPCNIN()
	{
		base.MOOACPIOELI();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(GMNALHGIECD));
	}

	public GuiElement KDMHKOBOOFM()
	{
		return this;
	}

	private void NEFJKOALLOI()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: false);
		PIIMDABCJFP = Singleton<GameVariables>.instance.moneyPack;
		BKPNOABFMGN[1].MKENDIKJPLJ(0, 4, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(0, 1, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].LOJPGLBLJDF(5, 8, PIIMDABCJFP.ACNHHOFIJMH[2]);
	}

	public virtual void KICJHALCOOM()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		for (int i = 1; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].OGEPINMEPDM();
		}
		KEOIGIHMEOI();
	}

	private void APPHDMCKJAC()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("GLM: RegisterOrLogin -  5");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private void KCEMOLDKAGE()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "BAND_TYPE_DAMAGE";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "offerMult";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "PA: number of sessions";
		}
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		switch (bHJPFGKALEN)
		{
		default:
			if (bHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
			{
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Gold), cBMKJAFIBKH);
			}
			break;
		case LJCNLBMEENL.STARTER_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.None), cBMKJAFIBKH);
			break;
		case LJCNLBMEENL.VALUE_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.ThreeCards), cBMKJAFIBKH);
			break;
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	private void CFJMKOALDLE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void IMGNEKHBBKD()
	{
		if (BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			int num = PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (num < 0)
			{
				UILabel hOLNKOFHDNK = HOLNKOFHDNK;
				object[] array = new object[3];
				array[1] = Colours.stringBlue;
				array[1] = MEJMLNDFDBP.CJCFPDLDMEK(1859f, "grenadeExplosion", string.Empty, IEJMLKBCDJB: false);
				hOLNKOFHDNK.text = Localization.LocalizeFormat("^.*-", array);
				MEFMGHEILOG.text = string.Format("Reward", Localization.Localize("ClientId"), MEJMLNDFDBP.CJCFPDLDMEK(1986f, "Reported", string.Empty));
				if (!MCGKPDLPDBK && LHDGJFHPJNM())
				{
					HideDialog();
				}
			}
			else
			{
				UILabel hOLNKOFHDNK2 = HOLNKOFHDNK;
				object[] array2 = new object[7];
				array2[1] = Colours.stringBlue;
				array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "smallThumbnailLittle", string.Empty, IEJMLKBCDJB: false);
				hOLNKOFHDNK2.text = Localization.LocalizeFormat("menu-hub-multiplayer-vipico", array2);
				MEFMGHEILOG.text = string.Format("ID_TUTORIAL_UPGRADEUNIT_4", Localization.Localize("Bad player regiones, data= "), MEJMLNDFDBP.CJCFPDLDMEK(num, "isNotificationAvailable", string.Empty));
			}
		}
		else if (BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			int num2 = PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (num2 < 1)
			{
				UILabel hOLNKOFHDNK3 = HOLNKOFHDNK;
				object[] array3 = new object[1];
				array3[1] = Colours.stringBlue;
				array3[1] = MEJMLNDFDBP.CJCFPDLDMEK(841f, "ID_CREATE", string.Empty);
				hOLNKOFHDNK3.text = Localization.LocalizeFormat("BonusHP", array3);
				MEFMGHEILOG.text = string.Format("GameGold", Localization.Localize("ios"), MEJMLNDFDBP.CJCFPDLDMEK(5f, "[Singleton] Instance '", string.Empty));
				if (!MCGKPDLPDBK && MHAIBHBGBOO())
				{
					HideDialog();
				}
			}
			else
			{
				UILabel hOLNKOFHDNK4 = HOLNKOFHDNK;
				object[] array4 = new object[3];
				array4[0] = Colours.stringBlue;
				array4[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_TWITTER_GAIN_AGAIN_TITLE", string.Empty);
				hOLNKOFHDNK4.text = Localization.LocalizeFormat("Please add object to pool, before instanciing it ::: prefab name = ", array4);
				MEFMGHEILOG.text = string.Format("global", Localization.Localize("#DOMINIK# out of time"), MEJMLNDFDBP.CJCFPDLDMEK(num2, "alwaysShittyPerformance", string.Empty));
			}
		}
		MEJMLNDFDBP.COCBCFKJOJE(MEFMGHEILOG, 1128f, 1219f, -177);
	}

	public virtual void PJENKEKOCAE()
	{
		GGJNEGPBDHL();
		if (BHJPFGKALEN == (LJCNLBMEENL)5 || BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			MCGKPDLPDBK = false;
			IMGNEKHBBKD();
			MCGKPDLPDBK = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(GMNALHGIECD));
			CounterManager counterManager2 = Singleton<CounterManager>.instance;
			counterManager2.EGMLDACJFCF = (Action)Delegate.Combine(counterManager2.EGMLDACJFCF, new Action(CBOBDHBDJOE));
		}
	}

	public void PNOBNHNOBHG(JGBBPCGNCPC JCBCHFJPPNK)
	{
		HACLJMMDJDK();
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: true);
		int num = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num < 7)
		{
			if (num == 1)
			{
				BKPNOABFMGN[1].LOJPGLBLJDF(1, 2, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 0; i <= num && i <= 3; i++)
			{
				BKPNOABFMGN[i - 1].LOJPGLBLJDF(i, num, JCBCHFJPPNK.ACNHHOFIJMH[i - 1]);
			}
		}
	}

	private void NHDJAMGCADC()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "Result for action:{0} on global:{1}";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "(Landroid/support/v4/app/FragmentActivity;)V";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "com.unity3d.player.UnityPlayer";
		}
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.ThreeCards), cBMKJAFIBKH);
			break;
		case LJCNLBMEENL.VALUE_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value), cBMKJAFIBKH);
			break;
		case (LJCNLBMEENL)4:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.ThreeCards), cBMKJAFIBKH);
			break;
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	public void FLIGIPOGLLN(JGBBPCGNCPC JCBCHFJPPNK)
	{
		GHJPIHHKELH();
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: true);
		int num = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num < 2)
		{
			if (num == 0)
			{
				BKPNOABFMGN[1].LOJPGLBLJDF(0, 0, JCBCHFJPPNK.ACNHHOFIJMH[1]);
			}
		}
		else
		{
			for (int i = 1; i <= num && i <= 1; i++)
			{
				BKPNOABFMGN[i - 1].GOMJAFCDKDD(i, num, JCBCHFJPPNK.ACNHHOFIJMH[i - 0]);
			}
		}
	}

	public virtual void MBGKIACBEID()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	private void FHLAKIPHABE()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: false);
		PIIMDABCJFP = Singleton<GameVariables>.instance.HFJGOIGLPCF();
		BKPNOABFMGN[1].LOJPGLBLJDF(0, 8, PIIMDABCJFP.ACNHHOFIJMH[0]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks && PIIMDABCJFP.ACNHHOFIJMH[1].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(5, 0);
		}
		BKPNOABFMGN[1].Initialize(4, 5, PIIMDABCJFP.ACNHHOFIJMH[0]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && PIIMDABCJFP.ACNHHOFIJMH[0].CGOPFPGMACH().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].LGNKHADEELF(0, 4);
		}
		BKPNOABFMGN[6].Initialize(6, 8, PIIMDABCJFP.ACNHHOFIJMH[8]);
		if (PIIMDABCJFP.ACNHHOFIJMH[8].type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack && PIIMDABCJFP.ACNHHOFIJMH[3].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].MICPFLBKGDH(2, 1);
		}
		BKPNOABFMGN[8].GOMJAFCDKDD(6, 8, PIIMDABCJFP.ACNHHOFIJMH[8]);
		if (PIIMDABCJFP.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && PIIMDABCJFP.ACNHHOFIJMH[6].EGMJNEABAHK().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].MICPFLBKGDH(7, 0);
		}
	}

	public void BHPJPEAMGIA(JGBBPCGNCPC JCBCHFJPPNK)
	{
		JDIFCDJMMLO();
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: false);
		int num = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num < 6)
		{
			if (num == 1)
			{
				BKPNOABFMGN[1].LOJPGLBLJDF(1, 0, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 0; i <= num && i <= 4; i += 0)
			{
				BKPNOABFMGN[i - 1].MKENDIKJPLJ(i, num, JCBCHFJPPNK.ACNHHOFIJMH[i - 1]);
			}
		}
	}

	public virtual void INPIJKMMADI()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].OGEPINMEPDM();
		}
		KEOIGIHMEOI();
	}

	private void JDIFCDJMMLO()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i++)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	private void BMNHEMLGGMO()
	{
		GHJPIHHKELH();
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			switch (bHJPFGKALEN)
			{
			case LJCNLBMEENL.STARTER_PACK:
				NFNLBEGFLHC.text = Localization.Localize("\t\"FALSE\"");
				HOLNKOFHDNK.text = Localization.Localize("1");
				GMBJHOCENGD.text = Localization.Localize("matchMadeGames");
				BMHFPMHEPOI();
				break;
			case (LJCNLBMEENL)7:
				NFNLBEGFLHC.text = Localization.Localize("ActivityType");
				GMBJHOCENGD.text = Localization.Localize("Card_3_Played");
				NEFJKOALLOI();
				break;
			}
		}
		else
		{
			NFNLBEGFLHC.text = Localization.Localize("War_Ranked_Battle");
			GMBJHOCENGD.text = Localization.Localize("1");
			NKMCBFEHKEH();
		}
		MEJMLNDFDBP.COCBCFKJOJE(GMBJHOCENGD, 1614f, 1582f, -72);
		KIHKPBOAPOL();
	}

	private void ABNFAJNHMMO()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "BuyCardsReminder {0}";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "ID_DELIVEREDTIME";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "MegaReward";
		}
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Bronze), cBMKJAFIBKH);
			break;
		case LJCNLBMEENL.VALUE_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.None), cBMKJAFIBKH);
			break;
		case LJCNLBMEENL.MONEY_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Silver), cBMKJAFIBKH);
			break;
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void PIHFONNFHLI()
	{
		if (NPFFMLLLDAF())
		{
			GMNJCDPKKOC();
		}
	}

	public virtual void PGBBAHLJMLA()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].ClearWeaponIcon();
		}
		OPPAADCPKCL();
	}

	private void MKNCIEDMOHP()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: true);
		APPHDMCKJAC();
		PIIMDABCJFP = Singleton<GameVariables>.instance.starterPack;
		BKPNOABFMGN[0].MKENDIKJPLJ(2, 7, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].GOMJAFCDKDD(3, 2, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[3].MKENDIKJPLJ(3, 7, PIIMDABCJFP.ACNHHOFIJMH[2]);
		BKPNOABFMGN[7].Initialize(8, 3, PIIMDABCJFP.ACNHHOFIJMH[7]);
	}

	private void FFDMIDCPFCK()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: true);
		PIIMDABCJFP = Singleton<GameVariables>.instance.HFJGOIGLPCF();
		BKPNOABFMGN[1].GOMJAFCDKDD(6, 1, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && PIIMDABCJFP.ACNHHOFIJMH[1].GKCIOBCPMDG().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].LGNKHADEELF(5, 3);
		}
		BKPNOABFMGN[0].Initialize(3, 5, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && PIIMDABCJFP.ACNHHOFIJMH[1].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].GAAEJFJGDFI(8, 6);
		}
		BKPNOABFMGN[1].GOMJAFCDKDD(7, 1, PIIMDABCJFP.ACNHHOFIJMH[5]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[0].ALMNJOLFIEF().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[8].MICPFLBKGDH(7, 8);
		}
		BKPNOABFMGN[1].LOJPGLBLJDF(0, 4, PIIMDABCJFP.ACNHHOFIJMH[7]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && PIIMDABCJFP.ACNHHOFIJMH[3].ALMNJOLFIEF().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].PFMMDAMAOHC(2, 8);
		}
	}

	private void LGLBMACACMJ()
	{
		if (NPFFMLLLDAF())
		{
			PPPKCLBOKAH();
		}
	}

	public virtual void EAMHJEGJNDF()
	{
		base.FKCKIFKLBAP();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(IMGNEKHBBKD));
	}

	private void IOCNPPCMCMM()
	{
		HACLJMMDJDK();
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			NFNLBEGFLHC.text = Localization.Localize("ID_GOLD");
			GMBJHOCENGD.text = Localization.Localize("Landroid/os/Parcelable$Creator;");
			LFJOGAAMFPF();
			break;
		case LJCNLBMEENL.VALUE_PACK:
			NFNLBEGFLHC.text = Localization.Localize("ID_SLOTUPGRADE_POWER");
			HOLNKOFHDNK.text = Localization.Localize("Product");
			GMBJHOCENGD.text = Localization.Localize("SpecialPackFromServer");
			GOLGLDKAIJD();
			break;
		case (LJCNLBMEENL)8:
			NFNLBEGFLHC.text = Localization.Localize("ID_FEATURE_AMMO-WEAPONPREFIX");
			GMBJHOCENGD.text = Localization.Localize("country-saudi-arabia");
			NEFJKOALLOI();
			break;
		}
		MEJMLNDFDBP.COCBCFKJOJE(GMBJHOCENGD, 1602f, 1545f, 163);
		PPPKCLBOKAH();
	}

	public virtual void HDNBPHBHNKB()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	private void NGPNPJDLGLP()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: true);
		PIIMDABCJFP = Singleton<GameVariables>.instance.moneyPack;
		BKPNOABFMGN[0].GOMJAFCDKDD(1, 2, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].LOJPGLBLJDF(3, 2, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].LOJPGLBLJDF(2, 6, PIIMDABCJFP.ACNHHOFIJMH[0]);
	}

	public virtual void MEGLMKBPFED()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	private void OBGFGPHGGPH()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "Snapshots";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "ID_CONFIRM_NOTLEADEROFSQUAD_TEXT";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "{0} {1}";
		}
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
			{
				if (bHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
				{
					Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Starter), cBMKJAFIBKH);
				}
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId((NGNPIOOAHEH)8), cBMKJAFIBKH);
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Money), cBMKJAFIBKH);
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	private void GMNJCDPKKOC()
	{
		NGNPIOOAHEH mLNLPPOLMEK = NGNPIOOAHEH.None;
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			switch (bHJPFGKALEN)
			{
			case LJCNLBMEENL.STARTER_PACK:
				mLNLPPOLMEK = NGNPIOOAHEH.Silver;
				break;
			case LJCNLBMEENL.VALUE_PACK:
				mLNLPPOLMEK = NGNPIOOAHEH.None;
				break;
			}
		}
		else
		{
			mLNLPPOLMEK = NGNPIOOAHEH.Silver;
		}
		float num = Singleton<GameVariables>.instance.SaleOfPack(mLNLPPOLMEK);
		bool flag = num > 1399f;
		MHOHDMJCJJI.SetActive(!flag);
		GIPFEBBMKPM.SetActive(flag);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(mLNLPPOLMEK).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(mLNLPPOLMEK).Value2;
		GBBBLBJNCAM.text = value;
		GNKIKDJLCEH.text = value;
		NHLIOGMJIIL.text = value2;
		UILabel jHIPEOCMMLM = JHIPEOCMMLM;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1843f);
		jHIPEOCMMLM.text = Localization.LocalizeFormat("Special_Sale", array);
		MEJMLNDFDBP.COCBCFKJOJE(JHIPEOCMMLM, 1080f, 42f, -11);
		if (flag)
		{
			OABLAOEHHGC.NFLJDPDCPIJ();
		}
	}

	private void GOIOKKLMJPI()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset("S");
			JFKIPIKKGNO = false;
		}
	}

	private void JMPOIAFDDBG()
	{
		if (NPFFMLLLDAF())
		{
			KMNGDNDDPKO();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(CBOBDHBDJOE));
	}

	private void CIDBBFCOPFH()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
			resourceLoaderTexture2D.FreeAsset("Item_ID");
			JFKIPIKKGNO = true;
		}
	}

	public virtual void BNEPKGCDIFH()
	{
		OMCNLOHKCBJ();
		if (BHJPFGKALEN == LJCNLBMEENL.VALUE_PACK || BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			MCGKPDLPDBK = true;
			GMNALHGIECD();
			MCGKPDLPDBK = true;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(GMNALHGIECD));
			CounterManager counterManager2 = Singleton<CounterManager>.instance;
			counterManager2.EGMLDACJFCF = (Action)Delegate.Combine(counterManager2.EGMLDACJFCF, new Action(CBOBDHBDJOE));
		}
	}

	private void NKMCBFEHKEH()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: true);
		AGGOLLIOIFB();
		PIIMDABCJFP = Singleton<GameVariables>.instance.starterPack;
		BKPNOABFMGN[1].Initialize(5, 4, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].Initialize(4, 3, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[7].GOMJAFCDKDD(7, 8, PIIMDABCJFP.ACNHHOFIJMH[3]);
		BKPNOABFMGN[3].LOJPGLBLJDF(6, 5, PIIMDABCJFP.ACNHHOFIJMH[0]);
	}

	public virtual void IJKLNEDKOOI()
	{
		CFJMKOALDLE(LJNPCHFCGCN.gameObject);
	}

	public void IFMMDKLNLJL(LJCNLBMEENL ODAFKIFDHEA, bool CCIEEAECOAB = false)
	{
		CEEOLBCLPOB = CCIEEAECOAB;
		BHJPFGKALEN = ODAFKIFDHEA;
		Singleton<GuiManager>.instance.ShowDialog(this, 286f);
	}

	private void PPAGPEIGBIC(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void OJFGFKCDCAM()
	{
		base.OIMKKAHOEKO();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		for (int i = 0; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].ClearWeaponIcon();
		}
		PMJAHBOFFGI();
	}

	private void KJCADHKJFPH()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "Battle_End_Dialog";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "Main_Menu_Offers_Bar";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "WarCards_Screen";
		}
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Starter), cBMKJAFIBKH);
			break;
		case LJCNLBMEENL.VALUE_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value), cBMKJAFIBKH);
			break;
		case LJCNLBMEENL.MONEY_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Money), cBMKJAFIBKH);
			break;
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	public virtual void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDLIKCKLJBD));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += LGLBMACACMJ;
	}

	private void CBOBDHBDJOE()
	{
		if (BHJPFGKALEN == LJCNLBMEENL.MONEY_PACK)
		{
			int num = PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num < 0)
			{
				HOLNKOFHDNK.text = Localization.LocalizeFormat("ID_MONEYPACKINFORMATIONS", Colours.stringBlue, MEJMLNDFDBP.CJCFPDLDMEK(0f, "-", string.Empty));
				MEFMGHEILOG.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MEJMLNDFDBP.CJCFPDLDMEK(0f, "-", string.Empty, IEJMLKBCDJB: false));
				if (!MCGKPDLPDBK && base.isFullyShowed)
				{
					HideDialog();
				}
			}
			else
			{
				HOLNKOFHDNK.text = Localization.LocalizeFormat("ID_MONEYPACKINFORMATIONS", Colours.stringBlue, MEJMLNDFDBP.CJCFPDLDMEK(num, "-", string.Empty));
				MEFMGHEILOG.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MEJMLNDFDBP.CJCFPDLDMEK(num, "-", string.Empty, IEJMLKBCDJB: false));
			}
		}
		else if (BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			int num2 = PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num2 < 0)
			{
				HOLNKOFHDNK.text = Localization.LocalizeFormat("ID_STARTERPACKINFORMATIONS", Colours.stringBlue, MEJMLNDFDBP.CJCFPDLDMEK(0f, "-", string.Empty));
				MEFMGHEILOG.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MEJMLNDFDBP.CJCFPDLDMEK(0f, "-", string.Empty, IEJMLKBCDJB: false));
				if (!MCGKPDLPDBK && base.isFullyShowed)
				{
					HideDialog();
				}
			}
			else
			{
				HOLNKOFHDNK.text = Localization.LocalizeFormat("ID_STARTERPACKINFORMATIONS", Colours.stringBlue, MEJMLNDFDBP.CJCFPDLDMEK(num2, "-", string.Empty));
				MEFMGHEILOG.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MEJMLNDFDBP.CJCFPDLDMEK(num2, "-", string.Empty, IEJMLKBCDJB: false));
			}
		}
		MEJMLNDFDBP.COCBCFKJOJE(MEFMGHEILOG, 33f, 20f, 390);
	}

	public virtual void FDCFOBEJOBG()
	{
		base.JNBMCODJHBJ();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(IMGNEKHBBKD));
	}

	private void PCHBNFBEJPI()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: false);
		PIIMDABCJFP = Singleton<GameVariables>.instance.INIDGJIMCDM();
		BKPNOABFMGN[0].LOJPGLBLJDF(0, 5, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].GOMJAFCDKDD(1, 8, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].Initialize(3, 7, PIIMDABCJFP.ACNHHOFIJMH[8]);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		for (int i = 0; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].ClearWeaponIcon();
		}
		OPPAADCPKCL();
	}

	public virtual void GBJHCKCPOBB()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		for (int i = 1; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].EIJGHBHKOIP();
		}
		OPPAADCPKCL();
	}

	public virtual void GHLCNMNKCIL()
	{
		base.JNBMCODJHBJ();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(GMNALHGIECD));
	}

	public virtual void IPGJLNKDPEM()
	{
		base.MOOACPIOELI();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(IMGNEKHBBKD));
	}

	private void FHGODMHNNPE()
	{
		if (isShowed)
		{
			GMNJCDPKKOC();
		}
	}

	private void GGJNEGPBDHL()
	{
		IDHHLOMBNJD();
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			NFNLBEGFLHC.text = Localization.Localize("ID_STARTERPACKCONTENTS");
			GMBJHOCENGD.text = Localization.Localize("ID_BUYSTARTERPACK");
			MINAPKFLHEA();
			break;
		case LJCNLBMEENL.VALUE_PACK:
			NFNLBEGFLHC.text = Localization.Localize("ID_VALUEPACKCONTENTS");
			HOLNKOFHDNK.text = Localization.Localize("ID_VALUEPACKINFORMATIONS");
			GMBJHOCENGD.text = Localization.Localize("ID_BUYVALUEPACK");
			GOLGLDKAIJD();
			break;
		case LJCNLBMEENL.MONEY_PACK:
			NFNLBEGFLHC.text = Localization.Localize("ID_MONEYPACKCONTENTS");
			GMBJHOCENGD.text = Localization.Localize("ID_BUYMONEYPACK");
			IGLJONJALHD();
			break;
		}
		MEJMLNDFDBP.COCBCFKJOJE(GMBJHOCENGD, 57f, 20f, 620);
		PPPKCLBOKAH();
	}

	private void GOLGLDKAIJD()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: false);
		PIIMDABCJFP = Singleton<GameVariables>.instance.valuePack;
		BKPNOABFMGN[0].Initialize(2, 5, PIIMDABCJFP.ACNHHOFIJMH[0]);
		if (PIIMDABCJFP.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[0].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].AlterShownCustomization(2, 5);
		}
		BKPNOABFMGN[1].Initialize(3, 5, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[1].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(3, 5);
		}
		BKPNOABFMGN[2].Initialize(4, 5, PIIMDABCJFP.ACNHHOFIJMH[2]);
		if (PIIMDABCJFP.ACNHHOFIJMH[2].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[2].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[2].AlterShownCustomization(4, 5);
		}
		BKPNOABFMGN[3].Initialize(5, 5, PIIMDABCJFP.ACNHHOFIJMH[3]);
		if (PIIMDABCJFP.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[3].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].AlterShownCustomization(5, 5);
		}
	}

	private void HBDJENGHMKG()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "#Game Rewards# no lootboxes\n";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "colt_shooting_loop";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "Type";
		}
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			switch (bHJPFGKALEN)
			{
			case LJCNLBMEENL.STARTER_PACK:
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.ThreeCards), cBMKJAFIBKH);
				break;
			case (LJCNLBMEENL)5:
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Bronze), cBMKJAFIBKH);
				break;
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId((NGNPIOOAHEH)8), cBMKJAFIBKH);
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	public virtual void FANFGPFNGCC()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
		for (int i = 1; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].CNFKPKEBBFB();
		}
		GOIOKKLMJPI();
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPOGEIGDJEG));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFJMKOALDLE));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += PLKFKCOJMFJ;
	}

	private void ELBMEOOIMJP()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_DOWNLOADING");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	public void ShowDialog(LJCNLBMEENL ODAFKIFDHEA, bool CCIEEAECOAB = false)
	{
		CEEOLBCLPOB = CCIEEAECOAB;
		BHJPFGKALEN = ODAFKIFDHEA;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void EBDLBDFKJHF()
	{
		if (isShowed)
		{
			PPPKCLBOKAH();
		}
	}

	public void DebugContent(JGBBPCGNCPC JCBCHFJPPNK)
	{
		IDHHLOMBNJD();
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: false);
		int num = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num < 2)
		{
			if (num == 1)
			{
				BKPNOABFMGN[0].Initialize(1, 2, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 1; i <= num && i <= 6; i++)
			{
				BKPNOABFMGN[i - 1].Initialize(i, num, JCBCHFJPPNK.ACNHHOFIJMH[i - 1]);
			}
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	private void NOBKFALLJEL()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "4 UNIT UPGRADE REMINDER\t";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "FacebookId";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "ID_ARENARULES_GOLDWARCARDS";
		}
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			switch (bHJPFGKALEN)
			{
			case LJCNLBMEENL.STARTER_PACK:
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.None), cBMKJAFIBKH);
				break;
			case LJCNLBMEENL.VALUE_PACK:
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Bronze), cBMKJAFIBKH);
				break;
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value), cBMKJAFIBKH);
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	private void LFJOGAAMFPF()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: false);
		ELBMEOOIMJP();
		PIIMDABCJFP = Singleton<GameVariables>.instance.starterPack;
		BKPNOABFMGN[1].GOMJAFCDKDD(0, 8, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].GOMJAFCDKDD(7, 2, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].GOMJAFCDKDD(2, 1, PIIMDABCJFP.ACNHHOFIJMH[3]);
		BKPNOABFMGN[6].Initialize(4, 3, PIIMDABCJFP.ACNHHOFIJMH[4]);
	}

	private void PPPKCLBOKAH()
	{
		NGNPIOOAHEH mLNLPPOLMEK = NGNPIOOAHEH.None;
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			mLNLPPOLMEK = NGNPIOOAHEH.Starter;
			break;
		case LJCNLBMEENL.VALUE_PACK:
			mLNLPPOLMEK = NGNPIOOAHEH.Value;
			break;
		case LJCNLBMEENL.MONEY_PACK:
			mLNLPPOLMEK = NGNPIOOAHEH.Money;
			break;
		}
		float num = Singleton<GameVariables>.instance.SaleOfPack(mLNLPPOLMEK);
		bool flag = num > 0.001f;
		MHOHDMJCJJI.SetActive(!flag);
		GIPFEBBMKPM.SetActive(flag);
		string value = Singleton<GameVariables>.instance.PriceOfPack(mLNLPPOLMEK).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(mLNLPPOLMEK).Value2;
		GBBBLBJNCAM.text = value;
		GNKIKDJLCEH.text = value;
		NHLIOGMJIIL.text = value2;
		JHIPEOCMMLM.text = Localization.LocalizeFormat("ID_SALEPERCENT", MEJMLNDFDBP.LJDADOKBBNA(num * 100f));
		MEJMLNDFDBP.COCBCFKJOJE(JHIPEOCMMLM, 58f, 29f, 300);
		if (flag)
		{
			OABLAOEHHGC.SetUpStrikeThrought();
		}
	}

	public virtual void HKKHHAKOFHL()
	{
		HGGFDJOFNMM();
		if (BHJPFGKALEN == (LJCNLBMEENL)8 || BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			MCGKPDLPDBK = true;
			GMNALHGIECD();
			MCGKPDLPDBK = true;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(IMGNEKHBBKD));
			CounterManager counterManager2 = Singleton<CounterManager>.instance;
			counterManager2.EGMLDACJFCF = (Action)Delegate.Combine(counterManager2.EGMLDACJFCF, new Action(IMGNEKHBBKD));
		}
	}

	private void KGPCALHCMFK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			NHDJAMGCADC();
			HideDialog();
		}
	}

	private void IDHHLOMBNJD()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		foreach (SpecialPackBoxItem specialPackBoxItem in bKPNOABFMGN)
		{
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	private void HACLJMMDJDK()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		foreach (SpecialPackBoxItem specialPackBoxItem in bKPNOABFMGN)
		{
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPCALHCMFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += PLKFKCOJMFJ;
	}

	private void DGAOCMNCGPH()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
			resourceLoaderTexture2D.FreeAsset("NotificationAction()");
			JFKIPIKKGNO = false;
		}
	}

	private void CPHEIKNJPNP()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: false);
		APPHDMCKJAC();
		PIIMDABCJFP = Singleton<GameVariables>.instance.starterPack;
		BKPNOABFMGN[0].GOMJAFCDKDD(4, 2, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].LOJPGLBLJDF(5, 8, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[8].GOMJAFCDKDD(0, 8, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[7].Initialize(6, 1, PIIMDABCJFP.ACNHHOFIJMH[8]);
	}

	private void FDLIKCKLJBD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HBDJENGHMKG();
			HideDialog();
		}
	}

	private void IOHJOGNIAHK()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: false);
		PIIMDABCJFP = Singleton<GameVariables>.instance.KLMNEOAKMFB();
		BKPNOABFMGN[0].Initialize(6, 2, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon && PIIMDABCJFP.ACNHHOFIJMH[0].EGMJNEABAHK().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].GAAEJFJGDFI(8, 3);
		}
		BKPNOABFMGN[1].GOMJAFCDKDD(3, 8, PIIMDABCJFP.ACNHHOFIJMH[0]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && PIIMDABCJFP.ACNHHOFIJMH[0].EIOFOGBDKLA().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].BBOHMOOOIHB(8, 8);
		}
		BKPNOABFMGN[5].LOJPGLBLJDF(0, 4, PIIMDABCJFP.ACNHHOFIJMH[3]);
		if (PIIMDABCJFP.ACNHHOFIJMH[8].type == JGBBPCGNCPC.NNDPOJCACLP.Unit && PIIMDABCJFP.ACNHHOFIJMH[6].ODBFELADDHM().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[4].MICPFLBKGDH(6, 1);
		}
		BKPNOABFMGN[3].Initialize(4, 0, PIIMDABCJFP.ACNHHOFIJMH[5]);
		if (PIIMDABCJFP.ACNHHOFIJMH[7].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && PIIMDABCJFP.ACNHHOFIJMH[0].NLNDHAMEEPJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[6].JGHOOHOEAFI(2, 3);
		}
	}

	private void GNIBHLKCKAB()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: true);
		ELBMEOOIMJP();
		PIIMDABCJFP = Singleton<GameVariables>.instance.starterPack;
		BKPNOABFMGN[1].MKENDIKJPLJ(4, 3, PIIMDABCJFP.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].LOJPGLBLJDF(7, 5, PIIMDABCJFP.ACNHHOFIJMH[1]);
		BKPNOABFMGN[8].MKENDIKJPLJ(3, 5, PIIMDABCJFP.ACNHHOFIJMH[8]);
		BKPNOABFMGN[4].Initialize(7, 6, PIIMDABCJFP.ACNHHOFIJMH[4]);
	}

	public virtual void LIGLAICJDNC()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPOGEIGDJEG));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += EBDLBDFKJHF;
	}

	public virtual void IIELNHDOEAM()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	private void HGGFDJOFNMM()
	{
		JDIFCDJMMLO();
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			NFNLBEGFLHC.text = Localization.Localize("ID_WARNING_ARENADOESNTEXIST");
			GMBJHOCENGD.text = Localization.Localize(" {0}/{1} ");
			LFJOGAAMFPF();
			break;
		case LJCNLBMEENL.VALUE_PACK:
			NFNLBEGFLHC.text = Localization.Localize("XP - Battle:{0} Extra:{1} Winstreak:{2} Time:{3} (offer mult {4})\n");
			HOLNKOFHDNK.text = Localization.Localize("Result");
			GMBJHOCENGD.text = Localization.Localize("ID_BRONZEPACKS");
			FFDMIDCPFCK();
			break;
		case (LJCNLBMEENL)7:
			NFNLBEGFLHC.text = Localization.Localize("ID_TUTORIAL_NOACCOUNT_{0}_TITLE");
			GMBJHOCENGD.text = Localization.Localize("kr");
			NEFJKOALLOI();
			break;
		}
		MEJMLNDFDBP.COCBCFKJOJE(GMBJHOCENGD, 1580f, 244f, -81);
		KIHKPBOAPOL();
	}

	private void KMNGDNDDPKO()
	{
		NGNPIOOAHEH mLNLPPOLMEK = NGNPIOOAHEH.Bronze;
		switch (BHJPFGKALEN)
		{
		case LJCNLBMEENL.STARTER_PACK:
			mLNLPPOLMEK = NGNPIOOAHEH.Value;
			break;
		case LJCNLBMEENL.VALUE_PACK:
			mLNLPPOLMEK = NGNPIOOAHEH.None;
			break;
		case (LJCNLBMEENL)6:
			mLNLPPOLMEK = NGNPIOOAHEH.Gold;
			break;
		}
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(mLNLPPOLMEK);
		bool flag = num > 1588f;
		MHOHDMJCJJI.SetActive(!flag);
		GIPFEBBMKPM.SetActive(flag);
		string value = Singleton<GameVariables>.instance.PriceOfPack(mLNLPPOLMEK).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(mLNLPPOLMEK).Value2;
		GBBBLBJNCAM.text = value;
		GNKIKDJLCEH.text = value;
		NHLIOGMJIIL.text = value2;
		UILabel jHIPEOCMMLM = JHIPEOCMMLM;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1187f);
		jHIPEOCMMLM.text = Localization.LocalizeFormat("DecalManagerData", array);
		MEJMLNDFDBP.COCBCFKJOJE(JHIPEOCMMLM, 1527f, 1752f, 144);
		if (flag)
		{
			OABLAOEHHGC.PGPKFKEIIJN();
		}
	}

	private void PMJAHBOFFGI()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset("CONFIRM");
			JFKIPIKKGNO = true;
		}
	}

	private void AGGOLLIOIFB()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("RETRY");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	public virtual void ABCGFBHKHEC()
	{
		base.NEEAKMELPBJ();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(CBOBDHBDJOE));
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPCALHCMFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += JMPOIAFDDBG;
	}

	public GuiElement HJFNBHHEGIF()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		GGJNEGPBDHL();
		if (BHJPFGKALEN == LJCNLBMEENL.MONEY_PACK || BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			MCGKPDLPDBK = true;
			CBOBDHBDJOE();
			MCGKPDLPDBK = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(CBOBDHBDJOE));
			CounterManager counterManager2 = Singleton<CounterManager>.instance;
			counterManager2.EGMLDACJFCF = (Action)Delegate.Combine(counterManager2.EGMLDACJFCF, new Action(CBOBDHBDJOE));
		}
	}

	public virtual void BKNJHLKMFKE()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
		for (int i = 1; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		DGAOCMNCGPH();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	private void OPPAADCPKCL()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset("menu-weapon-benelli-starterpack");
			JFKIPIKKGNO = false;
		}
	}

	private void MHBOJBLOELB()
	{
		AMPFHINKAGC.SetActive(value: true);
		PMOALAAIKEP.SetActive(value: true);
		ALKEGOAOICB.SetActive(value: true);
		PIIMDABCJFP = Singleton<GameVariables>.instance.BJDKLOCBNOJ();
		BKPNOABFMGN[1].LOJPGLBLJDF(6, 6, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && PIIMDABCJFP.ACNHHOFIJMH[1].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].MICPFLBKGDH(1, 5);
		}
		BKPNOABFMGN[1].MKENDIKJPLJ(2, 6, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && PIIMDABCJFP.ACNHHOFIJMH[1].KGMNPLAJHNC().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].BBOHMOOOIHB(3, 0);
		}
		BKPNOABFMGN[5].MKENDIKJPLJ(8, 3, PIIMDABCJFP.ACNHHOFIJMH[7]);
		if (PIIMDABCJFP.ACNHHOFIJMH[2].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && PIIMDABCJFP.ACNHHOFIJMH[1].EDLDCCEOCNI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].AlterShownCustomization(8, 4);
		}
		BKPNOABFMGN[6].LOJPGLBLJDF(8, 8, PIIMDABCJFP.ACNHHOFIJMH[0]);
		if (PIIMDABCJFP.ACNHHOFIJMH[2].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[3].POMMLFHPFPI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].GAAEJFJGDFI(3, 2);
		}
	}

	public virtual void KFLBEIPPMBF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPCALHCMFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFJMKOALDLE));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += PLKFKCOJMFJ;
	}

	private void GHJPIHHKELH()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 0; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	public virtual void PGHAMCBHBOD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPCALHCMFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PPAGPEIGBIC));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += LGLBMACACMJ;
	}

	private void BHNLJNOHHMA()
	{
		if (NPFFMLLLDAF())
		{
			PPPKCLBOKAH();
		}
	}

	private void DLNFBJHHGBK()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			Texture2D texture2D = weapons.LoadAsset("menu-weapon-benelli-starterpack");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private void OAKANAOHCJB()
	{
		string cBMKJAFIBKH = string.Empty;
		if (CEEOLBCLPOB)
		{
			cBMKJAFIBKH = "ID_STAT_BATTLESPLAYED";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			cBMKJAFIBKH = "NO";
		}
		else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
		{
			cBMKJAFIBKH = "ID_UNITTYPE3-DESCRIPTION";
		}
		LJCNLBMEENL bHJPFGKALEN = BHJPFGKALEN;
		if (bHJPFGKALEN != LJCNLBMEENL.STARTER_PACK)
		{
			switch (bHJPFGKALEN)
			{
			case LJCNLBMEENL.STARTER_PACK:
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Starter), cBMKJAFIBKH);
				break;
			case (LJCNLBMEENL)3:
				Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Gold), cBMKJAFIBKH);
				break;
			}
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value), cBMKJAFIBKH);
		}
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
	}

	public void ILFCOPPIOME(LJCNLBMEENL ODAFKIFDHEA, bool CCIEEAECOAB = false)
	{
		CEEOLBCLPOB = CCIEEAECOAB;
		BHJPFGKALEN = ODAFKIFDHEA;
		Singleton<GuiManager>.instance.ShowDialog(this, 1124f);
	}

	public virtual void KCAFCPAFBMC()
	{
		GGJNEGPBDHL();
		if (BHJPFGKALEN == (LJCNLBMEENL)5 || BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			MCGKPDLPDBK = false;
			GMNALHGIECD();
			MCGKPDLPDBK = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(GMNALHGIECD));
			CounterManager counterManager2 = Singleton<CounterManager>.instance;
			counterManager2.EGMLDACJFCF = (Action)Delegate.Combine(counterManager2.EGMLDACJFCF, new Action(GMNALHGIECD));
		}
	}

	public void ONHPOAIKLAO(LJCNLBMEENL ODAFKIFDHEA, bool CCIEEAECOAB = false)
	{
		CEEOLBCLPOB = CCIEEAECOAB;
		BHJPFGKALEN = ODAFKIFDHEA;
		Singleton<GuiManager>.instance.ShowDialog(this, 1570f);
	}

	public virtual void BFKOJEAIFPH()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void PPOGEIGDJEG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			KJCADHKJFPH();
			HideDialog();
		}
	}

	public void KAFHBDIEELN(JGBBPCGNCPC JCBCHFJPPNK)
	{
		HACLJMMDJDK();
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: false);
		int num = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num < 5)
		{
			if (num == 1)
			{
				BKPNOABFMGN[1].MKENDIKJPLJ(0, 7, JCBCHFJPPNK.ACNHHOFIJMH[1]);
			}
		}
		else
		{
			for (int i = 0; i <= num && i <= 6; i++)
			{
				BKPNOABFMGN[i - 0].LOJPGLBLJDF(i, num, JCBCHFJPPNK.ACNHHOFIJMH[i - 1]);
			}
		}
	}

	public GuiElement LOINPIHKGAF()
	{
		return this;
	}

	private void GMNALHGIECD()
	{
		if (BHJPFGKALEN == LJCNLBMEENL.VALUE_PACK)
		{
			int num = PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num < 0)
			{
				UILabel hOLNKOFHDNK = HOLNKOFHDNK;
				object[] array = new object[7];
				array[1] = Colours.stringBlue;
				array[1] = MEJMLNDFDBP.CJCFPDLDMEK(133f, "ID_CONFIRM_ERROR", string.Empty);
				hOLNKOFHDNK.text = Localization.LocalizeFormat("ID_TUTORIAL_TAPON", array);
				MEFMGHEILOG.text = string.Format("워프렌즈가 중요한 게임 데이터를 다운로드 받으려면 미디어 저장소에 대한 접근 권한이 필요합니다. 이 권한이 없으면, 게임이 정상적으로 작동되지 않고 종료됩니다. 다시 시도하거나 워프렌즈를 종료해주세요.", Localization.Localize("PlayerStatus"), MEJMLNDFDBP.CJCFPDLDMEK(24f, "ID_COOPCANCELED", string.Empty, IEJMLKBCDJB: false));
				if (!MCGKPDLPDBK && MHAIBHBGBOO())
				{
					HideDialog();
				}
			}
			else
			{
				UILabel hOLNKOFHDNK2 = HOLNKOFHDNK;
				object[] array2 = new object[5];
				array2[1] = Colours.stringBlue;
				array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_SELECTFRIENDERRORSHORTNAME", string.Empty, IEJMLKBCDJB: false);
				hOLNKOFHDNK2.text = Localization.LocalizeFormat("Get Experiment Details clicked", array2);
				MEFMGHEILOG.text = string.Format("starter", Localization.Localize("-"), MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_GAMEINVITE", string.Empty, IEJMLKBCDJB: false));
			}
		}
		else if (BHJPFGKALEN == LJCNLBMEENL.STARTER_PACK)
		{
			int num2 = PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (num2 < 0)
			{
				UILabel hOLNKOFHDNK3 = HOLNKOFHDNK;
				object[] array3 = new object[2];
				array3[1] = Colours.stringBlue;
				array3[1] = MEJMLNDFDBP.CJCFPDLDMEK(935f, "Error when client tried to work with server response!", string.Empty, IEJMLKBCDJB: false);
				hOLNKOFHDNK3.text = Localization.LocalizeFormat("Value4", array3);
				MEFMGHEILOG.text = string.Format("AndroidAdvertisingID", Localization.Localize(" x "), MEJMLNDFDBP.CJCFPDLDMEK(511f, "ID_GOLDENSHIELDSSMALL", string.Empty, IEJMLKBCDJB: false));
				if (!MCGKPDLPDBK && LHDGJFHPJNM())
				{
					HideDialog();
				}
			}
			else
			{
				UILabel hOLNKOFHDNK4 = HOLNKOFHDNK;
				object[] array4 = new object[1];
				array4[0] = Colours.stringBlue;
				array4[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "\n\t{0} {1}", string.Empty, IEJMLKBCDJB: false);
				hOLNKOFHDNK4.text = Localization.LocalizeFormat("\n", array4);
				MEFMGHEILOG.text = string.Format("ID_INVITEDYOUTOFIGHT", Localization.Localize("setAndroidIdMd5"), MEJMLNDFDBP.CJCFPDLDMEK(num2, ".jpg", string.Empty, IEJMLKBCDJB: false));
			}
		}
		MEJMLNDFDBP.COCBCFKJOJE(MEFMGHEILOG, 1865f, 1427f, -10);
	}

	private void BMHFPMHEPOI()
	{
		AMPFHINKAGC.SetActive(value: false);
		PMOALAAIKEP.SetActive(value: false);
		ALKEGOAOICB.SetActive(value: false);
		PIIMDABCJFP = Singleton<GameVariables>.instance.BJDKLOCBNOJ();
		BKPNOABFMGN[1].MKENDIKJPLJ(4, 3, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[1].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].GAAEJFJGDFI(2, 4);
		}
		BKPNOABFMGN[0].MKENDIKJPLJ(1, 6, PIIMDABCJFP.ACNHHOFIJMH[1]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && PIIMDABCJFP.ACNHHOFIJMH[1].GKCIOBCPMDG().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].AlterShownCustomization(6, 4);
		}
		BKPNOABFMGN[0].MKENDIKJPLJ(3, 7, PIIMDABCJFP.ACNHHOFIJMH[5]);
		if (PIIMDABCJFP.ACNHHOFIJMH[4].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && PIIMDABCJFP.ACNHHOFIJMH[8].EIOFOGBDKLA().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[4].LGNKHADEELF(3, 5);
		}
		BKPNOABFMGN[5].LOJPGLBLJDF(5, 8, PIIMDABCJFP.ACNHHOFIJMH[4]);
		if (PIIMDABCJFP.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && PIIMDABCJFP.ACNHHOFIJMH[5].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[7].LGNKHADEELF(5, 1);
		}
	}
}

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BuyHearthDialog : GuiElementSingle<BuyHearthDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	[FormerlySerializedAs("PLDFGMHICCA")]
	public GameObject LJNPCHFCGCN;

	[FormerlySerializedAs("OOCODEMOAHO")]
	[Header("Middle")]
	public UISprite KGLKHDNFDNC;

	[FormerlySerializedAs("DACKFDCLLBC")]
	public UISprite APGIIDFOMFP;

	[FormerlySerializedAs("BAICDKCMLBC")]
	public UISprite AIGECAKDCEJ;

	[FormerlySerializedAs("PCBFLAPENLF")]
	public UILabel JPCIACBHGHO;

	[Header("Bottom")]
	[FormerlySerializedAs("IFLNMMJLAPE")]
	public GameObject DMPBNBPBDFD;

	[FormerlySerializedAs("NMJCMEPOLON")]
	public UILabel GMBJHOCENGD;

	[FormerlySerializedAs("JFKOBGNLLIF")]
	public GameObject GMBBOHLENGI;

	[FormerlySerializedAs("NBLMLCOOGMH")]
	public UILabel MIBMLCENPLE;

	[FormerlySerializedAs("BOLCBCLFGPI")]
	public GameObject APNKAABNMPP;

	private int KOAIHACBAMF;

	private int AHHEEGIHFGE;

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void GAAHJOEANEF(bool EFBPOCHCGPB)
	{
		if (!EFBPOCHCGPB)
		{
			APNKAABNMPP.SetActive(value: true);
		}
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	private void FHCHEKPCHLJ(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.CanBuyTickets(AHHEEGIHFGE))
		{
			Singleton<BeanstalkServerManager>.instance.BuyArenaHearth();
			APNKAABNMPP.SetActive(value: false);
		}
		else
		{
			GuiElementSingle<BuyTicketsDialog>.instance.FCCJJKBPNCH(AHHEEGIHFGE, FLIHNANHKJE.EnterArena, GAAHJOEANEF);
			APNKAABNMPP.SetActive(value: false);
		}
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(EKAEAFMGNEJ);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.GetScrapsReward(PPNMHPBMIJE: true);
			HideDialog();
		}
	}

	private void JOCALAINFHG(DatabaseAction IFGAGNBDKBE)
	{
		if (base.isFullyShowed && IFGAGNBDKBE == (DatabaseAction)103)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	private void PKKDPBHOJJD(DatabaseAction IFGAGNBDKBE)
	{
		if (MHAIBHBGBOO() && IFGAGNBDKBE == (DatabaseAction)(-126))
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	private void PEOCBJFLMFA(DatabaseAction IFGAGNBDKBE)
	{
		if (BJNBLINDAED() && IFGAGNBDKBE == DatabaseAction.Test)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	public virtual void DFMCKHMFNHO()
	{
		APNKAABNMPP.SetActive(value: true);
		KGLKHDNFDNC.gameObject.SetActive(KOAIHACBAMF != 3 && KOAIHACBAMF == 8);
		APGIIDFOMFP.gameObject.SetActive(KOAIHACBAMF != 1 && KOAIHACBAMF == 0);
		AIGECAKDCEJ.gameObject.SetActive(KOAIHACBAMF == 7 || KOAIHACBAMF == 1);
		if (KOAIHACBAMF == 1)
		{
			UILabel jPCIACBHGHO = JPCIACBHGHO;
			object[] array = new object[0];
			array[0] = Colours.stringGreenArena;
			jPCIACBHGHO.text = Localization.LocalizeFormat("ID_STATE_SELECTINGWARCARDS", array);
		}
		else
		{
			UILabel jPCIACBHGHO2 = JPCIACBHGHO;
			object[] array2 = new object[8];
			array2[1] = KOAIHACBAMF;
			array2[1] = Colours.stringGreenArena;
			jPCIACBHGHO2.text = Localization.LocalizeFormat("GameLauncher.Async", array2);
		}
		GMBJHOCENGD.text = Localization.Localize("Type");
		float val = 132f + GMBJHOCENGD.relativeSize.x * GMBJHOCENGD.transform.localScale.x + 341f;
		GMBBOHLENGI.transform.localPosition = GMBBOHLENGI.transform.localPosition.ReplaceX(val);
		MIBMLCENPLE.text = MEJMLNDFDBP.GMIPFLIEOHD(AHHEEGIHFGE);
	}

	private void LIOKKFBAJDI(bool EFBPOCHCGPB)
	{
		if (!EFBPOCHCGPB)
		{
			APNKAABNMPP.SetActive(value: true);
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (base.isFullyShowed && IFGAGNBDKBE == DatabaseAction.BuyArenaHearth)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		APNKAABNMPP.SetActive(value: false);
		KGLKHDNFDNC.gameObject.SetActive(KOAIHACBAMF == 2 || KOAIHACBAMF == 3);
		APGIIDFOMFP.gameObject.SetActive(KOAIHACBAMF == 1 || KOAIHACBAMF == 3);
		AIGECAKDCEJ.gameObject.SetActive(KOAIHACBAMF == 2 || KOAIHACBAMF == 3);
		if (KOAIHACBAMF == 1)
		{
			JPCIACBHGHO.text = Localization.LocalizeFormat("ID_YOULOSTONETIMEBUTYOUARECLOSE", Colours.stringGreenArena);
		}
		else
		{
			JPCIACBHGHO.text = Localization.LocalizeFormat("ID_YOULOSTXTIMESBUTYOUARECLOSE", KOAIHACBAMF, Colours.stringGreenArena);
		}
		GMBJHOCENGD.text = Localization.Localize("ID_EXTRA");
		float val = 50f + GMBJHOCENGD.relativeSize.x * GMBJHOCENGD.transform.localScale.x + 46f;
		GMBBOHLENGI.transform.localPosition = GMBBOHLENGI.transform.localPosition.ReplaceX(val);
		MIBMLCENPLE.text = MEJMLNDFDBP.GMIPFLIEOHD(AHHEEGIHFGE);
	}

	private void JEPJLJABCLB(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.JCKFFBCLFFD(AHHEEGIHFGE))
		{
			Singleton<BeanstalkServerManager>.instance.BuyArenaHearth();
			APNKAABNMPP.SetActive(value: false);
		}
		else
		{
			GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(AHHEEGIHFGE, FLIHNANHKJE.EnterArena, LIOKKFBAJDI);
			APNKAABNMPP.SetActive(value: false);
		}
	}

	public virtual void BFLHENDLPLK()
	{
		APNKAABNMPP.SetActive(value: true);
		KGLKHDNFDNC.gameObject.SetActive(KOAIHACBAMF != 6 && KOAIHACBAMF == 1);
		APGIIDFOMFP.gameObject.SetActive(KOAIHACBAMF == 0 || KOAIHACBAMF == 8);
		AIGECAKDCEJ.gameObject.SetActive(KOAIHACBAMF != 1 && KOAIHACBAMF == 8);
		if (KOAIHACBAMF == 1)
		{
			UILabel jPCIACBHGHO = JPCIACBHGHO;
			object[] array = new object[1];
			array[1] = Colours.stringGreenArena;
			jPCIACBHGHO.text = Localization.LocalizeFormat("\t", array);
		}
		else
		{
			UILabel jPCIACBHGHO2 = JPCIACBHGHO;
			object[] array2 = new object[0];
			array2[0] = KOAIHACBAMF;
			array2[1] = Colours.stringGreenArena;
			jPCIACBHGHO2.text = Localization.LocalizeFormat("LevelExperience", array2);
		}
		GMBJHOCENGD.text = Localization.Localize("Value1");
		float val = 514f + GMBJHOCENGD.relativeSize.x * GMBJHOCENGD.transform.localScale.x + 1645f;
		GMBBOHLENGI.transform.localPosition = GMBBOHLENGI.transform.localPosition.ReplaceX(val);
		MIBMLCENPLE.text = MEJMLNDFDBP.GMIPFLIEOHD(AHHEEGIHFGE);
	}

	private void KGNOOKDIHDK(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.CanBuyTickets(AHHEEGIHFGE))
		{
			Singleton<BeanstalkServerManager>.instance.BuyArenaHearth();
			APNKAABNMPP.SetActive(value: false);
		}
		else
		{
			GuiElementSingle<BuyTicketsDialog>.instance.FCCJJKBPNCH(AHHEEGIHFGE, FLIHNANHKJE.BuyHearth, LIOKKFBAJDI);
			APNKAABNMPP.SetActive(value: false);
		}
	}

	public virtual void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JEPJLJABCLB));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(EKAEAFMGNEJ);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += KGGIGGPKCJF;
	}

	private void BBIOLFHDLFF(DatabaseAction IFGAGNBDKBE)
	{
		if (LHDGJFHPJNM() && IFGAGNBDKBE == (DatabaseAction)(-63))
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	public virtual void CBPNEALKOMM()
	{
		IFBKHDIICCB(LJNPCHFCGCN);
	}

	public void ShowDialog()
	{
		KOAIHACBAMF = WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
		AHHEEGIHFGE = WarArena.instance.extraLiveCost;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void BOBJOHGDOLD(DatabaseAction IFGAGNBDKBE)
	{
		if (base.isFullyShowed && IFGAGNBDKBE == (DatabaseAction)61)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	private void IFBKHDIICCB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<BeanstalkServerManager>.instance.CBKCDKOEIJB();
			HideDialog();
		}
	}

	private void KGGIGGPKCJF(DatabaseAction IFGAGNBDKBE)
	{
		if (LHDGJFHPJNM() && IFGAGNBDKBE == (DatabaseAction)(-76))
		{
			APNKAABNMPP.SetActive(value: true);
			HideDialog();
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(LJNPCHFCGCN);
	}

	private void CDIEOBIGOEG(DatabaseAction IFGAGNBDKBE)
	{
		if (BJNBLINDAED() && IFGAGNBDKBE == DatabaseAction.EquipDecal)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KGNOOKDIHDK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JNPBINOKMHC;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += JOCALAINFHG;
	}

	private void JNPBINOKMHC(DatabaseAction IFGAGNBDKBE)
	{
		if (BKIGLABDGCP() && IFGAGNBDKBE == (DatabaseAction)19)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FHCHEKPCHLJ));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(JNPBINOKMHC);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += JOCALAINFHG;
	}

	public void CHMIPBJLKIJ()
	{
		KOAIHACBAMF = WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
		AHHEEGIHFGE = WarArena.instance.extraLiveCost;
		Singleton<GuiManager>.instance.ShowDialog(this, 1570f);
	}

	private void AAJEOAEANHH(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.JCKFFBCLFFD(AHHEEGIHFGE))
		{
			Singleton<BeanstalkServerManager>.instance.BuyArenaHearth();
			APNKAABNMPP.SetActive(value: false);
		}
		else
		{
			GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(AHHEEGIHFGE, FLIHNANHKJE.EnterArena, LIOKKFBAJDI);
			APNKAABNMPP.SetActive(value: true);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	private void PFAHADHIDGM(DatabaseAction IFGAGNBDKBE)
	{
		if (LHDGJFHPJNM() && IFGAGNBDKBE == (DatabaseAction)(-84))
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void GHNHACMBBKF(bool EFBPOCHCGPB)
	{
		if (!EFBPOCHCGPB)
		{
			APNKAABNMPP.SetActive(value: false);
		}
	}

	private void IDJMEDOGFGI(GameObject KHAHPAKDIKE)
	{
		if (Singleton<Wallet>.instance.CanBuyTickets(AHHEEGIHFGE))
		{
			Singleton<BeanstalkServerManager>.instance.BuyArenaHearth();
			APNKAABNMPP.SetActive(value: false);
			return;
		}
		GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(AHHEEGIHFGE, FLIHNANHKJE.BuyHearth, delegate(bool EFBPOCHCGPB)
		{
			if (!EFBPOCHCGPB)
			{
				APNKAABNMPP.SetActive(value: false);
			}
		});
		APNKAABNMPP.SetActive(value: true);
	}

	public virtual void KFPOJBHHLGJ()
	{
		IFBKHDIICCB(LJNPCHFCGCN);
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AAJEOAEANHH));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PKKDPBHOJJD;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += CDIEOBIGOEG;
	}

	public virtual void FCPGJBMGBLJ()
	{
		IFBKHDIICCB(LJNPCHFCGCN);
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (base.isFullyShowed && IFGAGNBDKBE == DatabaseAction.BuyArenaHearth)
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}

	private void EKAEAFMGNEJ(DatabaseAction IFGAGNBDKBE)
	{
		if (BJNBLINDAED() && IFGAGNBDKBE == (DatabaseAction)(-73))
		{
			APNKAABNMPP.SetActive(value: false);
			HideDialog();
		}
	}
}

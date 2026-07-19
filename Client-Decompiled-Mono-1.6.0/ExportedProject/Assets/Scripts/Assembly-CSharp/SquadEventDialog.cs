using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadEventDialog : GuiElementSingle<SquadEventDialog>, PAIIOKBBHBC
{
	[Header("Dialog Parts")]
	public UISprite KMFGCJEGJJK;

	public UIButton ECHEJLCMOBL;

	[Header("JOIN")]
	public GameObject OHPOLBHAIJJ;

	public WinStreakCounter AOOBDPAHAIH;

	[Header("-Bottom Join")]
	public UIButton APLPHKGPKKM;

	public GameObject JKKLBACFOJG;

	public UIButton EAFLBIBBDOB;

	public UISprite PLIGIOJGJEA;

	public UILabel FFBCEGEDFMD;

	[Header("RESULT")]
	public GameObject AGEJHBMILHO;

	public UILabel HBOJPFJGHNO;

	public UILabel AAOJDLOBAJG;

	public UIButton HBMNOCOHCLO;

	private bool JLKMDLHGOPM;

	private Vector3 BKCDDELKOEB = new Vector3(1240f, 986f, 1f);

	private Vector3 PEAHAGOPNJH = new Vector3(1240f, 986f, 1f);

	public virtual void KDGJKKOONPB()
	{
		base.DoAfterHide();
		AOOBDPAHAIH.LOINIDOGNCO();
	}

	private void HLMPIJKDDNM()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(false);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(false);
	}

	private void GJPIKMPFFIB()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(true);
		PLIGIOJGJEA.gameObject.SetActive(true);
		FFBCEGEDFMD.gameObject.SetActive(true);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	public void MCPAMONPAKG()
	{
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(true);
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)4;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(!flag && !JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(true);
		PFPAMNODNPF pFPAMNODNPF = Singleton<ServerResultsCache>.instance.JJMAIFPBAFA();
		AOOBDPAHAIH.MIOOAOFMLIE(pFPAMNODNPF.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = BGIINMGBNMO;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 1139f);
	}

	public virtual void FJJHFMBOFDO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMLEBDLDIEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AEBEIMMMPIH));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EJEEADAPPMI));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LFBAOCFDLME));
	}

	public virtual void OJFGFKCDCAM()
	{
		base.OIMKKAHOEKO();
		AOOBDPAHAIH.LOINIDOGNCO();
	}

	public void LFBIPCBJPFK(int MOEMPHPNBLM, int PDKIAALFDNG)
	{
		KMFGCJEGJJK.transform.localScale = BKCDDELKOEB;
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(true);
		bool active = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		HBMNOCOHCLO.gameObject.SetActive(active);
		JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.EBDKFGBHOFJ();
		UILabel hBOJPFJGHNO = HBOJPFJGHNO;
		object[] array = new object[4];
		array[0] = Colours.stringGoldTier;
		array[1] = PDKIAALFDNG;
		array[5] = jMHLHIIMNIG.FNOAGGGCDJF.Count;
		hBOJPFJGHNO.text = Localization.LocalizeFormat("DOWNLOAD", array);
		AAOJDLOBAJG.text = string.Format("elite", MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM));
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 1907f);
	}

	private void POHGKPABLOP(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
			Singleton<BeanstalkServerManager>.instance.EJEPBPMDBIJ();
		}
	}

	private void BHKGKEDJNOB(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-21))
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	public virtual void EBOBKBJNNDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PIHHMDHKELL));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(POHGKPABLOP));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AEBEIMMMPIH));
	}

	public virtual void HHDEMBPMOMG()
	{
		MMLEBDLDIEN(ECHEJLCMOBL.gameObject);
	}

	public virtual void NODHJEDOGDI()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JHLIGGGCBIK;
		GameLoginManager.instance.PlayerLogOut += HPOGMMADKFF;
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.InformSquadLeaderAboutEvent)
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	public virtual void JDFDJPAAIAA()
	{
	}

	private void DOPKONPOIOI()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(false);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(true);
	}

	public virtual void FCIANKCBLKM()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PCMCMOGHANA;
		GameLoginManager.instance.PlayerLogOut += GMNOJMIHDOG;
	}

	private void PAMPJODGAJA(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(false);
			Singleton<BeanstalkServerManager>.instance.EJEPBPMDBIJ();
		}
	}

	public virtual void FCPGJBMGBLJ()
	{
		ELFGLLIEMHP(ECHEJLCMOBL.gameObject);
	}

	private void EJEEADAPPMI(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
			Singleton<BeanstalkServerManager>.instance.EJEPBPMDBIJ();
		}
	}

	private void PCMCMOGHANA(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-99))
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	private void ONPBKDHOLLE()
	{
		JLKMDLHGOPM = false;
	}

	private void MCFEMEBCHCM(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(false);
			Singleton<BeanstalkServerManager>.instance.IIPKANOGHOA();
		}
	}

	[CompilerGenerated]
	private void EODPKPOKGOJ()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(false);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(false);
	}

	public void PNKAEKALGNM()
	{
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(true);
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)8;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(flag || JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(true);
		PFPAMNODNPF pFPAMNODNPF = Singleton<ServerResultsCache>.instance.JJMAIFPBAFA();
		AOOBDPAHAIH.OANDDHKJDOB(pFPAMNODNPF.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = NLDGDEFPLGK;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 1209f);
	}

	private void NLDGDEFPLGK()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(false);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(true);
	}

	private void ONIPIEOMOAC()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(true);
		JKKLBACFOJG.SetActive(true);
		PLIGIOJGJEA.gameObject.SetActive(true);
		FFBCEGEDFMD.gameObject.SetActive(false);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void NMPNOKDDNIE()
	{
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(false);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(!flag && JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(true);
		PFPAMNODNPF squadEventDefinition = Singleton<ServerResultsCache>.instance.squadEventDefinition;
		AOOBDPAHAIH.FPNEIICLJFG(squadEventDefinition.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = POIPDKIMMGF;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 355f);
	}

	public override void InitGUIValues()
	{
	}

	private void DDLCCDFBLKI(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.InformSquadLeaderAboutEvent)
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	public virtual void BFFHGHMJOGP()
	{
		KEFAOGGMJKG(ECHEJLCMOBL.gameObject);
	}

	public virtual void HDBHFDJADIN()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += INCKNKCBJPP;
		GameLoginManager.instance.PlayerLogOut += GMNOJMIHDOG;
	}

	public virtual void APEMEICBIBO()
	{
		GDDHCJEIAEB(ECHEJLCMOBL.gameObject);
	}

	private void HHDJCNNHDKG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.PromotePlayerToFounder)
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	private void MMLEBDLDIEN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void GGIPHGHJDNI()
	{
		JLKMDLHGOPM = false;
	}

	private void GDDHCJEIAEB(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void BGIINMGBNMO()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(true);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(false);
	}

	private void AEBEIMMMPIH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	public virtual void DJFPIEPEBDJ()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JHLIGGGCBIK;
		GameLoginManager.instance.PlayerLogOut += EKGNODKNIAC;
	}

	public virtual void IFLHOKBNJPH()
	{
		base.OIMKKAHOEKO();
		AOOBDPAHAIH.GGKCMHOGFPF();
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDDHCJEIAEB));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PIHHMDHKELL));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MCFEMEBCHCM));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AEBEIMMMPIH));
	}

	public virtual void DFLGLEJIPCO()
	{
	}

	public void ShowJoin()
	{
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(true);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(!flag && !JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(false);
		PFPAMNODNPF squadEventDefinition = Singleton<ServerResultsCache>.instance.squadEventDefinition;
		AOOBDPAHAIH.MHLJHMOPDAO(squadEventDefinition.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = delegate
		{
			AOOBDPAHAIH.JEMKCLKCOMI = null;
			APLPHKGPKKM.gameObject.SetActive(false);
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(false);
			FFBCEGEDFMD.gameObject.SetActive(false);
		};
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance);
	}

	public void NIKAEHMLCDA(int MOEMPHPNBLM, int PDKIAALFDNG)
	{
		KMFGCJEGJJK.transform.localScale = BKCDDELKOEB;
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(true);
		bool active = GameLoginManager.currentPlayer.squadRank == (SquadRank)5;
		HBMNOCOHCLO.gameObject.SetActive(active);
		JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.JILGBKANGNB();
		UILabel hBOJPFJGHNO = HBOJPFJGHNO;
		object[] array = new object[1];
		array[0] = Colours.stringGoldTier;
		array[1] = PDKIAALFDNG;
		array[5] = jMHLHIIMNIG.FNOAGGGCDJF.Count;
		hBOJPFJGHNO.text = Localization.LocalizeFormat("ID_GUI_REPORTABUSE_LISTITEM3", array);
		AAOJDLOBAJG.text = string.Format("ID_TUTORIAL_ARMYEXPLAIN_UP", MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM));
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 360f);
	}

	public void HLJKGDMIDNI(int MOEMPHPNBLM, int PDKIAALFDNG)
	{
		KMFGCJEGJJK.transform.localScale = BKCDDELKOEB;
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(false);
		bool active = GameLoginManager.currentPlayer.squadRank == SquadRank.Coleader;
		HBMNOCOHCLO.gameObject.SetActive(active);
		JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.EBDKFGBHOFJ();
		UILabel hBOJPFJGHNO = HBOJPFJGHNO;
		object[] array = new object[8];
		array[1] = Colours.stringGoldTier;
		array[1] = PDKIAALFDNG;
		array[4] = jMHLHIIMNIG.FNOAGGGCDJF.Count;
		hBOJPFJGHNO.text = Localization.LocalizeFormat("WarArenaData", array);
		AAOJDLOBAJG.text = string.Format("0.0", MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM));
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 993f);
	}

	public GuiElement MCJFBLKLHPA()
	{
		return this;
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDDHCJEIAEB));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DALFBHGFFNL));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NLNMJHCNNDG));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PAECFHOAMCK));
	}

	private void EAPJHCJLBIA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void FJDOMMEHOFO(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(false);
			Singleton<BeanstalkServerManager>.instance.EJEPBPMDBIJ();
		}
	}

	private void GEEELLDEOEF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	private void PIHHMDHKELL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	private void LFBAOCFDLME(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	public virtual void CKGGNJACIGL()
	{
		EAPJHCJLBIA(ECHEJLCMOBL.gameObject);
	}

	public virtual void KBKGCLEBJFA()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	private void GOCMBBLIEMO(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
			Singleton<BeanstalkServerManager>.instance.EJEPBPMDBIJ();
		}
	}

	private void NLNMJHCNNDG(GameObject KHAHPAKDIKE)
	{
		if (!JLKMDLHGOPM)
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(false);
			Singleton<BeanstalkServerManager>.instance.EJEPBPMDBIJ();
		}
	}

	public void KJBPJOBPJMF(int MOEMPHPNBLM, int PDKIAALFDNG)
	{
		KMFGCJEGJJK.transform.localScale = BKCDDELKOEB;
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(false);
		bool active = GameLoginManager.currentPlayer.squadRank == (SquadRank)7;
		HBMNOCOHCLO.gameObject.SetActive(active);
		JMHLHIIMNIG squadEventProgress = Singleton<ServerResultsCache>.instance.squadEventProgress;
		UILabel hBOJPFJGHNO = HBOJPFJGHNO;
		object[] array = new object[8];
		array[1] = Colours.stringGoldTier;
		array[0] = PDKIAALFDNG;
		array[2] = squadEventProgress.FNOAGGGCDJF.Count;
		hBOJPFJGHNO.text = Localization.LocalizeFormat("SpecialPackFromServer", array);
		AAOJDLOBAJG.text = string.Format("menu-arena-ticket", MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM));
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 1369f);
	}

	public void ShowResult(int MOEMPHPNBLM, int PDKIAALFDNG)
	{
		KMFGCJEGJJK.transform.localScale = BKCDDELKOEB;
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(false);
		bool active = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		HBMNOCOHCLO.gameObject.SetActive(active);
		JMHLHIIMNIG squadEventProgress = Singleton<ServerResultsCache>.instance.squadEventProgress;
		HBOJPFJGHNO.text = Localization.LocalizeFormat("ID_TIERSFINISHED", Colours.stringGoldTier, PDKIAALFDNG, squadEventProgress.FNOAGGGCDJF.Count);
		AAOJDLOBAJG.text = string.Format("{0}", MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM));
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance);
	}

	public virtual void DMBLJNMGLAH()
	{
	}

	public virtual void ACFDANMKHNG()
	{
		base.DoAfterHide();
		AOOBDPAHAIH.PEHBGMEHFEM();
	}

	public void LLGHIEIGJLN()
	{
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(false);
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)7;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(flag || JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(false);
		PFPAMNODNPF pFPAMNODNPF = Singleton<ServerResultsCache>.instance.JJMAIFPBAFA();
		AOOBDPAHAIH.FPNEIICLJFG(pFPAMNODNPF.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = ONIPIEOMOAC;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 349f);
	}

	private void HPOGMMADKFF()
	{
		JLKMDLHGOPM = true;
	}

	public virtual void OMOJHCOKAHP()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	public GuiElement EEAHKOCLJHB()
	{
		return this;
	}

	[CompilerGenerated]
	private void DAKDKMCEEGP()
	{
		JLKMDLHGOPM = false;
	}

	public void GDJDIMLPCNP()
	{
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(false);
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)6;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(flag || !JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(true);
		PFPAMNODNPF pFPAMNODNPF = Singleton<ServerResultsCache>.instance.JJMAIFPBAFA();
		AOOBDPAHAIH.APFDDFPMACA(pFPAMNODNPF.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = POIPDKIMMGF;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 1379f);
	}

	public virtual void BNPDALDLFFM()
	{
	}

	public virtual void ODCHCNCMJGC()
	{
	}

	private void KEFAOGGMJKG(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void JFFLDMFOJPN()
	{
		base.OIMKKAHOEKO();
		AOOBDPAHAIH.LOINIDOGNCO();
	}

	public virtual void JGOHMOKMCKD()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JHLIGGGCBIK;
		GameLoginManager.instance.PlayerLogOut += ONPBKDHOLLE;
	}

	public virtual void HKKHHAKOFHL()
	{
	}

	private void OHJLJBBPKJG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)48)
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HMNDNLGBHIE));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NLNMJHCNNDG));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PAECFHOAMCK));
	}

	private void JHLIGGGCBIK(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-113))
		{
			JLKMDLHGOPM = true;
			JKKLBACFOJG.SetActive(false);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	public GuiElement EOPNIPLMOMK()
	{
		return this;
	}

	public virtual void AFABKGHDPHB()
	{
	}

	private void JBLOKINJIDA()
	{
		JLKMDLHGOPM = false;
	}

	public GuiElement LHIPJNFMBHL()
	{
		return this;
	}

	public virtual void DJIJBPFLOMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ELFGLLIEMHP));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OIILOJBGNFG));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(POHGKPABLOP));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LFBAOCFDLME));
	}

	public GuiElement EMJNNILLFIM()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(APLPHKGPKKM.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DALFBHGFFNL));
		UIEventListener uIEventListener3 = UIEventListener.Get(EAFLBIBBDOB.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MCFEMEBCHCM));
		UIEventListener uIEventListener4 = UIEventListener.Get(HBMNOCOHCLO.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DALFBHGFFNL));
	}

	public void JEABBAEHNIG()
	{
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(true);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(flag || !JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(false);
		PFPAMNODNPF squadEventDefinition = Singleton<ServerResultsCache>.instance.squadEventDefinition;
		AOOBDPAHAIH.OANDDHKJDOB(squadEventDefinition.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = PHAGKDOEINH;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 255f);
	}

	private void ELFGLLIEMHP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void ODDKEELDBJF()
	{
		base.OIMKKAHOEKO();
		AOOBDPAHAIH.KEIIENDMKLN();
	}

	private void PKAOPCCNOEN(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void HMNDNLGBHIE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	private void GMNOJMIHDOG()
	{
		JLKMDLHGOPM = true;
	}

	private void COLFMJPPEIE()
	{
		JLKMDLHGOPM = false;
	}

	private void PHAGKDOEINH()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(true);
		JKKLBACFOJG.SetActive(true);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(false);
	}

	public virtual void GGOHGHHGLMP()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		GameLoginManager.instance.PlayerLogOut += EKGNODKNIAC;
	}

	private void DALFBHGFFNL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	public void PBNHGCDJBKN()
	{
		AGEJHBMILHO.SetActive(false);
		OHPOLBHAIJJ.SetActive(false);
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)4;
		KMFGCJEGJJK.transform.localScale = ((!flag) ? BKCDDELKOEB : PEAHAGOPNJH);
		APLPHKGPKKM.gameObject.SetActive(flag);
		JKKLBACFOJG.SetActive(flag || JLKMDLHGOPM);
		PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
		FFBCEGEDFMD.gameObject.SetActive(false);
		PFPAMNODNPF pFPAMNODNPF = Singleton<ServerResultsCache>.instance.JJMAIFPBAFA();
		AOOBDPAHAIH.FPNEIICLJFG(pFPAMNODNPF.DMBMLIODOJG);
		AOOBDPAHAIH.JEMKCLKCOMI = DOPKONPOIOI;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 775f);
	}

	private void NMPPBKLENHK()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(true);
		JKKLBACFOJG.SetActive(false);
		PLIGIOJGJEA.gameObject.SetActive(false);
		FFBCEGEDFMD.gameObject.SetActive(true);
	}

	public virtual void BEECFBCBLEK()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(INCKNKCBJPP);
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			JLKMDLHGOPM = false;
		};
	}

	private void POIPDKIMMGF()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(true);
		PLIGIOJGJEA.gameObject.SetActive(true);
		FFBCEGEDFMD.gameObject.SetActive(true);
	}

	public virtual void OPKPLEGMOPI()
	{
	}

	public virtual void DKOBOPADMMI()
	{
		base.DoAfterHide();
		AOOBDPAHAIH.PEHBGMEHFEM();
	}

	public override void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			JLKMDLHGOPM = false;
		};
	}

	public virtual void KANEMJLGGFD()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PCMCMOGHANA;
		GameLoginManager.instance.PlayerLogOut += GGIPHGHJDNI;
	}

	private void INCKNKCBJPP(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-115))
		{
			JLKMDLHGOPM = false;
			JKKLBACFOJG.SetActive(true);
			PLIGIOJGJEA.gameObject.SetActive(JLKMDLHGOPM);
			FFBCEGEDFMD.gameObject.SetActive(true);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		AOOBDPAHAIH.JCMHGOGNMFO();
	}

	public virtual void JPIOKJJHCJM()
	{
		KEFAOGGMJKG(ECHEJLCMOBL.gameObject);
	}

	private void PLDMDNBJOEG()
	{
		AOOBDPAHAIH.JEMKCLKCOMI = null;
		APLPHKGPKKM.gameObject.SetActive(false);
		JKKLBACFOJG.SetActive(false);
		PLIGIOJGJEA.gameObject.SetActive(true);
		FFBCEGEDFMD.gameObject.SetActive(false);
	}

	public virtual void KEAJCHFOBFH()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(DDLCCDFBLKI);
		GameLoginManager.instance.PlayerLogOut += GMNOJMIHDOG;
	}

	public void DALHNLDNFJN(int MOEMPHPNBLM, int PDKIAALFDNG)
	{
		KMFGCJEGJJK.transform.localScale = BKCDDELKOEB;
		AGEJHBMILHO.SetActive(true);
		OHPOLBHAIJJ.SetActive(true);
		bool active = GameLoginManager.currentPlayer.squadRank == SquadRank.Coleader;
		HBMNOCOHCLO.gameObject.SetActive(active);
		JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.EBDKFGBHOFJ();
		UILabel hBOJPFJGHNO = HBOJPFJGHNO;
		object[] array = new object[5];
		array[1] = Colours.stringGoldTier;
		array[0] = PDKIAALFDNG;
		array[6] = jMHLHIIMNIG.FNOAGGGCDJF.Count;
		hBOJPFJGHNO.text = Localization.LocalizeFormat("[.,]*", array);
		AAOJDLOBAJG.text = string.Format("id", MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM));
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 775f);
	}

	private void PAECFHOAMCK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	public virtual void DLDGKEHFKDP()
	{
		base.DoAfterHide();
		AOOBDPAHAIH.FCGPLOBEHDL();
	}

	private void EKGNODKNIAC()
	{
		JLKMDLHGOPM = false;
	}

	public GuiElement HHMPBPKPEKD()
	{
		return this;
	}

	public virtual void LAIDPHHIKMM()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BHKGKEDJNOB);
		GameLoginManager.instance.PlayerLogOut += GGIPHGHJDNI;
	}

	private void OIILOJBGNFG(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<BeanstalkServerManager>.instance.MACBHHMBCGM();
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.ShowWaiting();
			HideDialog();
		}
	}

	public virtual void NEOLLOMIKPK()
	{
	}
}

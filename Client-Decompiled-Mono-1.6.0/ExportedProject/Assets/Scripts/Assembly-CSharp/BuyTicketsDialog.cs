using System;
using System.Collections.Generic;
using UnityEngine;

public class BuyTicketsDialog : GuiElementSingle<BuyTicketsDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	public GameObject MGEGMLELNFD;

	public UISprite KMFGCJEGJJK;

	[Header("Top")]
	public GameObject LJNPCHFCGCN;

	[Header("Midlle")]
	public UILabel CNMDFMGELLH;

	public UILabel EKDGAOJHCEP;

	public GameObject IGMHCCHHCPK;

	[Header("Bottom")]
	public GameObject JMBPNBGCFIL;

	public GameObject MAKNJBNANFC;

	public UILabel JOBNOJIJMGK;

	public UILabel AGEEJIHGKID;

	public GameObject APNKAABNMPP;

	private Action<bool> CPHAENOIMEA;

	private long BBLPCPONEDJ;

	private long DCKPPHKICEH;

	private int NKFGNDFKGHC;

	private FLIHNANHKJE BHOFGKLNGAO;

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	private void ACLOANLBFDG(DatabaseAction IFGAGNBDKBE)
	{
		if (BJNBLINDAED() && IFGAGNBDKBE == (DatabaseAction)6)
		{
			APNKAABNMPP.SetActive(true);
			HideDialog();
		}
	}

	public virtual void NMHMFDOFDBC()
	{
		base.OIMKKAHOEKO();
		CPHAENOIMEA = null;
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MAKNJBNANFC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHBIAIGLFNP));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(ECDEFNLCJOC));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LOKKCEFHDKL;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ACLOANLBFDG;
	}

	public GuiElement FKCNDEANKNA()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		LPGKOKPMEGB();
		APNKAABNMPP.SetActive(false);
		long num = BBLPCPONEDJ - DCKPPHKICEH;
		if (num == 1)
		{
			CNMDFMGELLH.text = Localization.LocalizeFormat((BHOFGKLNGAO != FLIHNANHKJE.EnterArena) ? "ID_YOUNEED1TICKETFOREXTRAHEART" : "ID_YOUNEED1TICKETTOENTERARENA", Colours.stringGreenArena);
			JOBNOJIJMGK.text = Localization.Localize("ID_ONETICKET");
		}
		else
		{
			CNMDFMGELLH.text = Localization.LocalizeFormat((BHOFGKLNGAO != FLIHNANHKJE.EnterArena) ? "ID_YOUNEEDXTICKETSFOREXTRAHEART" : "ID_YOUNEEDXTICKETSTOENTERARENA", Colours.stringGreenArena, num);
			JOBNOJIJMGK.text = Localization.LocalizeFormat("ID_XTICKETS", num);
		}
		EKDGAOJHCEP.text = string.Format("{0}{1}[-] / {2}", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(DCKPPHKICEH), MEJMLNDFDBP.GMIPFLIEOHD(BBLPCPONEDJ));
		AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
	}

	private void LPLBGPDAPOF(DatabaseAction IFGAGNBDKBE)
	{
		if (LHDGJFHPJNM() && IFGAGNBDKBE == DatabaseAction.DebugAddSquadLevel)
		{
			APNKAABNMPP.SetActive(false);
			HideDialog();
		}
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public GuiElement EEAHKOCLJHB()
	{
		return this;
	}

	public virtual void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MAKNJBNANFC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHBIAIGLFNP));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(DOFFFMEGJOP));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LPLBGPDAPOF;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ACLOANLBFDG;
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MAKNJBNANFC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHBIAIGLFNP));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(DOFFFMEGJOP));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LPLBGPDAPOF);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	public virtual void HEEANEFGCCJ()
	{
		LPGKOKPMEGB();
		APNKAABNMPP.SetActive(false);
		long num = BBLPCPONEDJ - DCKPPHKICEH;
		if (num == 0)
		{
			CNMDFMGELLH.text = Localization.LocalizeFormat((BHOFGKLNGAO != FLIHNANHKJE.EnterArena) ? "ExceptionStacktrace" : "ID_FEATURE_RELOAD", Colours.stringGreenArena);
			JOBNOJIJMGK.text = Localization.Localize("added");
		}
		else
		{
			UILabel cNMDFMGELLH = CNMDFMGELLH;
			string keyFormat = ((BHOFGKLNGAO != FLIHNANHKJE.EnterArena) ? "game-card-ico-shieldgenerator" : "ID_PURCHASECARDPACK");
			object[] array = new object[7];
			array[1] = Colours.stringGreenArena;
			array[1] = num;
			cNMDFMGELLH.text = Localization.LocalizeFormat(keyFormat, array);
			UILabel jOBNOJIJMGK = JOBNOJIJMGK;
			object[] array2 = new object[0];
			array2[1] = num;
			jOBNOJIJMGK.text = Localization.LocalizeFormat("ID_SKILLSHOTHINT_VEHICLEDESTROYED", array2);
		}
		EKDGAOJHCEP.text = string.Format("ID_GUI_CHAT_SQUAD_PROMOTED", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(DCKPPHKICEH), MEJMLNDFDBP.GMIPFLIEOHD(BBLPCPONEDJ));
		AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
	}

	public virtual void CHAGJLIDGAH()
	{
		base.OIMKKAHOEKO();
		CPHAENOIMEA = null;
	}

	public virtual void HKPDDINMBAC()
	{
		base.DoAfterHide();
		CPHAENOIMEA = null;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		CPHAENOIMEA = null;
	}

	public void GONOICLIMKO(long MNPFLFLHIMC, FLIHNANHKJE FJLBLLLEELD, Action<bool> DPMLFJGIMHM = null)
	{
		BBLPCPONEDJ = MNPFLFLHIMC;
		DCKPPHKICEH = Singleton<Wallet>.instance.tickets;
		NKFGNDFKGHC = MEJMLNDFDBP.JNGCHKGIGIE(BBLPCPONEDJ - DCKPPHKICEH);
		CPHAENOIMEA = DPMLFJGIMHM;
		BHOFGKLNGAO = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyTicketsDialog>.instance, 1462f);
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (base.isFullyShowed && IFGAGNBDKBE == DatabaseAction.BuyArenaHearth)
		{
			APNKAABNMPP.SetActive(false);
			HideDialog();
		}
	}

	public void ShowDialog(long MNPFLFLHIMC, FLIHNANHKJE FJLBLLLEELD, Action<bool> DPMLFJGIMHM = null)
	{
		BBLPCPONEDJ = MNPFLFLHIMC;
		DCKPPHKICEH = Singleton<Wallet>.instance.tickets;
		NKFGNDFKGHC = MEJMLNDFDBP.JNGCHKGIGIE(BBLPCPONEDJ - DCKPPHKICEH);
		CPHAENOIMEA = DPMLFJGIMHM;
		BHOFGKLNGAO = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyTicketsDialog>.instance);
	}

	private void NKABLHINJOB(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(NKFGNDFKGHC))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(NKFGNDFKGHC, Localization.Localize("IOAJFNMOGOD"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		APNKAABNMPP.SetActive(true);
		if (BHOFGKLNGAO == FLIHNANHKJE.BuyHearth)
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.GetConfigurations, new List<Tuple<string, string>>
			{
				new Tuple<string, string>("GooglePlayLogin(", NKFGNDFKGHC.ToString())
			});
		}
		else if (BHOFGKLNGAO == FLIHNANHKJE.EnterArena)
		{
			DIENNAGJJOM.MLJOFHLFLPJ(NKFGNDFKGHC);
		}
	}

	public void FCCJJKBPNCH(long MNPFLFLHIMC, FLIHNANHKJE FJLBLLLEELD, Action<bool> DPMLFJGIMHM = null)
	{
		BBLPCPONEDJ = MNPFLFLHIMC;
		DCKPPHKICEH = Singleton<Wallet>.instance.tickets;
		NKFGNDFKGHC = MEJMLNDFDBP.JNGCHKGIGIE(BBLPCPONEDJ - DCKPPHKICEH);
		CPHAENOIMEA = DPMLFJGIMHM;
		BHOFGKLNGAO = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyTicketsDialog>.instance, 1417f);
	}

	public virtual void GBPEJMFMBJM()
	{
		base.OIMKKAHOEKO();
		CPHAENOIMEA = null;
	}

	private void PHBIAIGLFNP(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(NKFGNDFKGHC))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(NKFGNDFKGHC, Localization.Localize("ID_ARENATICKETSSMALL"));
			return;
		}
		APNKAABNMPP.SetActive(true);
		if (BHOFGKLNGAO == FLIHNANHKJE.BuyHearth)
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.BuyArenaHearth, new List<Tuple<string, string>>
			{
				new Tuple<string, string>("UsedGolds", NKFGNDFKGHC.ToString())
			});
		}
		else if (BHOFGKLNGAO == FLIHNANHKJE.EnterArena)
		{
			DIENNAGJJOM.PNHDGLHLNIE(NKFGNDFKGHC);
		}
	}

	public virtual void MMLOAKGDDGF()
	{
		base.DoAfterHide();
		CPHAENOIMEA = null;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (CPHAENOIMEA != null)
			{
				CPHAENOIMEA(false);
			}
			HideDialog();
		}
	}

	public GuiElement NIFFGPKMBKE()
	{
		return this;
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (base.isFullyShowed && IFGAGNBDKBE == DatabaseAction.BuyArenaHearth)
		{
			APNKAABNMPP.SetActive(false);
			HideDialog();
		}
	}

	private void LOKKCEFHDKL(DatabaseAction IFGAGNBDKBE)
	{
		if (MHAIBHBGBOO() && IFGAGNBDKBE == (DatabaseAction)(-8))
		{
			APNKAABNMPP.SetActive(true);
			HideDialog();
		}
	}

	private void KHAJHGBKIBB(DatabaseAction IFGAGNBDKBE)
	{
		if (LHDGJFHPJNM() && IFGAGNBDKBE == (DatabaseAction)27)
		{
			APNKAABNMPP.SetActive(false);
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void DOLLFDPMGOD()
	{
		LPGKOKPMEGB();
		APNKAABNMPP.SetActive(false);
		long num = BBLPCPONEDJ - DCKPPHKICEH;
		if (num == 1)
		{
			CNMDFMGELLH.text = Localization.LocalizeFormat((BHOFGKLNGAO != FLIHNANHKJE.EnterArena) ? "_TintColor" : "RETRY", Colours.stringGreenArena);
			JOBNOJIJMGK.text = Localization.Localize("ID_CONFIRM_EXITWARFRIENDS");
		}
		else
		{
			UILabel cNMDFMGELLH = CNMDFMGELLH;
			string keyFormat = ((BHOFGKLNGAO != FLIHNANHKJE.EnterArena) ? "\"NaN\"" : "ID_SQUADMEDALSSMALL");
			object[] array = new object[8];
			array[0] = Colours.stringGreenArena;
			array[0] = num;
			cNMDFMGELLH.text = Localization.LocalizeFormat(keyFormat, array);
			UILabel jOBNOJIJMGK = JOBNOJIJMGK;
			object[] array2 = new object[1];
			array2[1] = num;
			jOBNOJIJMGK.text = Localization.LocalizeFormat("bigURL", array2);
		}
		EKDGAOJHCEP.text = string.Format("Gold", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(DCKPPHKICEH), MEJMLNDFDBP.GMIPFLIEOHD(BBLPCPONEDJ));
		AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
	}

	public virtual void GLOINJNJBCP()
	{
		base.DoAfterHide();
		CPHAENOIMEA = null;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MAKNJBNANFC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHBIAIGLFNP));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(ECDEFNLCJOC));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	public GuiElement JPJGHDKECMA()
	{
		return this;
	}

	public virtual void LDBLJDJNJJN()
	{
		base.DoAfterHide();
		CPHAENOIMEA = null;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public void EMBNLMGLNFN(long MNPFLFLHIMC, FLIHNANHKJE FJLBLLLEELD, Action<bool> DPMLFJGIMHM = null)
	{
		BBLPCPONEDJ = MNPFLFLHIMC;
		DCKPPHKICEH = Singleton<Wallet>.instance.tickets;
		NKFGNDFKGHC = MEJMLNDFDBP.JNGCHKGIGIE(BBLPCPONEDJ - DCKPPHKICEH);
		CPHAENOIMEA = DPMLFJGIMHM;
		BHOFGKLNGAO = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyTicketsDialog>.instance, 1427f);
	}

	public virtual void HLBIJGPEPIO()
	{
		base.OIMKKAHOEKO();
		CPHAENOIMEA = null;
	}

	private void DOFFFMEGJOP(bool HIDPGIGEBIH)
	{
		APNKAABNMPP.SetActive(true);
		if (CPHAENOIMEA != null)
		{
			CPHAENOIMEA(HIDPGIGEBIH);
		}
		HideDialog();
	}

	private void ECDEFNLCJOC(bool HIDPGIGEBIH)
	{
		APNKAABNMPP.SetActive(false);
		if (CPHAENOIMEA != null)
		{
			CPHAENOIMEA(HIDPGIGEBIH);
		}
		HideDialog();
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MAKNJBNANFC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHBIAIGLFNP));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(DOFFFMEGJOP));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LOKKCEFHDKL);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	private void ANPDFAEBHBB()
	{
		bool flag = BHOFGKLNGAO == FLIHNANHKJE.BuyHearth;
		MGEGMLELNFD.transform.localPosition = MGEGMLELNFD.transform.localPosition.ReplaceY((!flag) ? 710f : 885f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!flag) ? 1695f : 608f);
		IGMHCCHHCPK.SetActive(flag);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY((!flag) ? 890f : 88f);
	}

	private void LPGKOKPMEGB()
	{
		bool flag = BHOFGKLNGAO == FLIHNANHKJE.BuyHearth;
		MGEGMLELNFD.transform.localPosition = MGEGMLELNFD.transform.localPosition.ReplaceY((!flag) ? (-76f) : (-182f));
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!flag) ? 980f : 692f);
		IGMHCCHHCPK.SetActive(!flag);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY((!flag) ? (-376f) : (-98f));
	}

	public virtual void GAGKEJAFBOH()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MAKNJBNANFC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NKABLHINJOB));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(DOFFFMEGJOP));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}
}

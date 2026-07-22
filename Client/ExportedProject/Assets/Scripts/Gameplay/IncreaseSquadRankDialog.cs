using System;
using UnityEngine;
using UnityEngine.Serialization;

public class IncreaseSquadRankDialog : GuiElementSingle<IncreaseSquadRankDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("EADMGHKNMNN")]
	[Header("Middle")]
	public UILabel JFHCIILADJL;

	[FormerlySerializedAs("JJABMEFIGGH")]
	public UILabel GEDJKICFLMI;

	[FormerlySerializedAs("PIOMCDMIHGK")]
	[Header("Bottom")]
	public UIButton NNJJENLFAEG;

	public virtual void IMKECOIFJFK()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(EDMJHPNJMLI);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CMJCNFHFMKE));
	}

	public virtual void JCGPELEDCJL()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(CBKOPKBPCFM);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
	}

	public virtual void KBPOHEMMNMM()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(NNJJENLFAEG.gameObject);
	}

	private void IJEFGHPENEE(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF() && IFGAGNBDKBE == DatabaseAction.DemotePlayer)
		{
			IOLJPFAAEPD();
		}
	}

	public virtual void CEOBPADJPIA()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += MGHKOALEPPD;
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public void BBGJMMKIGJG()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 185f);
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}

	public virtual void AIJEMOLBNEC()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(IJEFGHPENEE);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IOJEPFNAFJG));
	}

	public virtual void EBOBKBJNNDK()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(OEBCHDBJLIJ);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IOJEPFNAFJG));
	}

	public void HLGALFANPBC()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1323f);
	}

	private void CMJCNFHFMKE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void JJNLDFHEHJL(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void JOPPNGGBMCE()
	{
		JJNLDFHEHJL(NNJJENLFAEG.gameObject);
	}

	public virtual void BEAOKIEIEIM()
	{
		IOJEPFNAFJG(NNJJENLFAEG.gameObject);
	}

	public virtual void KPKONEJJKLO()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(EDMJHPNJMLI);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
	}

	private void EDJEBEHBDJF(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)96)
		{
			OFHLKDEJOLC();
		}
	}

	public virtual void LCMFDLLFBDC()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public void CBPJNPHOAFN()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 471f);
	}

	public virtual void DEFCMABOJGD()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public virtual void CBPNEALKOMM()
	{
		CMJCNFHFMKE(NNJJENLFAEG.gameObject);
	}

	public virtual void HFMAANHIDBJ()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	private void LCINHBLBFLD(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF() && IFGAGNBDKBE == DatabaseAction.DecalWasShown)
		{
			GOKEFDHBNOM();
		}
	}

	public virtual void BMIJKGBGALG()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public GuiElement LOINPIHKGAF()
	{
		return this;
	}

	public virtual void JKODFKNJOIB()
	{
		CPNCDECGEGG(NNJJENLFAEG.gameObject);
	}

	public virtual void MAEFFJLPNDK()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public virtual void CKGGNJACIGL()
	{
		HCBJHPHPNDI(NNJJENLFAEG.gameObject);
	}

	public GuiElement CCJFGBAEDBD()
	{
		return this;
	}

	public virtual void AHDJEJIKCAB()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	private void FILAGGGONPL()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			JFHCIILADJL.text = Localization.LocalizeFormat("NEW CONFIG WILL BE LOADED FROM PREFS:", aANECPGDMGM.IKJHAHJHLIH);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public virtual void CIPFBOJLIMJ()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	public virtual void CMFFEECPAED()
	{
		KOACKJOKJNP(NNJJENLFAEG.gameObject);
	}

	public virtual void FMEJLMMLBPD()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void INPIJKMMADI()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	public GuiElement GBCEJBCGGHP()
	{
		return this;
	}

	public virtual void INBNCNMGELB()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	private void CBKOPKBPCFM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == (DatabaseAction)(-107))
		{
			HMMDICNOBIE();
		}
	}

	public virtual void BCACBNHFMDA()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void LEDIDEJMNNK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void HFCANCNMGMH(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.GetSquads)
		{
			GOKEFDHBNOM();
		}
	}

	private void HMMDICNOBIE()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			UILabel jFHCIILADJL = JFHCIILADJL;
			object[] array = new object[1];
			array[1] = aANECPGDMGM.IKJHAHJHLIH;
			jFHCIILADJL.text = Localization.LocalizeFormat("qbz_idle", array);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public virtual void OALKHLOOGFA()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void CHJMEBCJPJD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void IOJEPFNAFJG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void EGNPMLEJLMJ()
	{
		BFJJOLGAFPC(NNJJENLFAEG.gameObject);
	}

	private void GOKEFDHBNOM()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName);
		if (aANECPGDMGM != null)
		{
			UILabel jFHCIILADJL = JFHCIILADJL;
			object[] array = new object[1];
			array[1] = aANECPGDMGM.IKJHAHJHLIH;
			jFHCIILADJL.text = Localization.LocalizeFormat("ID_DAILYMISSIONSUNLOCKEDHINT3TITLE", array);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	private void DCHDPJHPKNM()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName);
		if (aANECPGDMGM != null)
		{
			JFHCIILADJL.text = Localization.LocalizeFormat("ID_CURRENTSQUADRANK", aANECPGDMGM.IKJHAHJHLIH);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public virtual void NOMBEBADCKJ()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void IBNHJGLOHAE()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LCINHBLBFLD);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CHJMEBCJPJD));
	}

	public virtual void HHJDKKFKKIL()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public virtual void LGOJHGEFKKH()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void OEBCHDBJLIJ(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == (DatabaseAction)(-58))
		{
			OFHLKDEJOLC();
		}
	}

	private void CNDBHPKAFDF(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == (DatabaseAction)22)
		{
			HCDNHFGJHDD();
		}
	}

	private void BFJJOLGAFPC(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public GuiElement JPBIPBMAHBO()
	{
		return this;
	}

	private void HCDNHFGJHDD()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			UILabel jFHCIILADJL = JFHCIILADJL;
			object[] array = new object[1];
			array[1] = aANECPGDMGM.IKJHAHJHLIH;
			jFHCIILADJL.text = Localization.LocalizeFormat("ID_USEREXISTSFACEBOOKTEXT", array);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void OOLLHJHMOFJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1887f);
	}

	public override void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += EOGJKCAKCMH;
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public GuiElement KHNOCHHPLDF()
	{
		return this;
	}

	public void JOJEKLMOJOI()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1968f);
	}

	public virtual void GCGHNGDFAPI()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public void EBELHKPCLBI()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1226f);
	}

	public void KMPGLCKAEEN()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1014f);
	}

	public virtual void FAGDHCFOEAL()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	public virtual void EKECENANOBE()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public void FNGFBKPACAN()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1536f);
	}

	private void CPNCDECGEGG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void EDMJHPNJMLI(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.GetSquadsByExperience)
		{
			DCHDPJHPKNM();
		}
	}

	public virtual void LFBAOBONBKH()
	{
		CPNCDECGEGG(NNJJENLFAEG.gameObject);
	}

	public virtual void CFLBPMFEFAB()
	{
		GKOHJGFKPAH(NNJJENLFAEG.gameObject);
	}

	private void OFHLKDEJOLC()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName);
		if (aANECPGDMGM != null)
		{
			JFHCIILADJL.text = Localization.LocalizeFormat("BS: On Get New Assignemnts", aANECPGDMGM.IKJHAHJHLIH);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public virtual void EDFMOCGKHHH()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += EDMJHPNJMLI;
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCBJHPHPNDI));
	}

	private void LKKELGHLEPN(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void EIPIEOCIGKL()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	private void ECOBCAOEDPG()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			UILabel jFHCIILADJL = JFHCIILADJL;
			object[] array = new object[1];
			array[1] = aANECPGDMGM.IKJHAHJHLIH;
			jFHCIILADJL.text = Localization.LocalizeFormat("ID_CONFIRM_PROMOTETOLEADER_TEXT", array);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public virtual void KJBGADNDLGI()
	{
		KPHHBHIMPLH(NNJJENLFAEG.gameObject);
	}

	public virtual void FACKIKMABGK()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public virtual void DHMNIOHKIGC()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public virtual void BKMAJFCLLCI()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void KPHHBHIMPLH(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void EKBICIMBAKF()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void HEEANEFGCCJ()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = true;
	}

	public virtual void JFMOGGFMHHA()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(CNDBHPKAFDF);
		UIEventListener uIEventListener = UIEventListener.Get(NNJJENLFAEG.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void HCBJHPHPNDI(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void PAKCFABJKAG()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public virtual void AHMBANMKGEJ()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void IOLJPFAAEPD()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName);
		if (aANECPGDMGM != null)
		{
			UILabel jFHCIILADJL = JFHCIILADJL;
			object[] array = new object[0];
			array[1] = aANECPGDMGM.IKJHAHJHLIH;
			jFHCIILADJL.text = Localization.LocalizeFormat("{0} {1}/ {2}{3}", array);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public virtual void NFNMLPPDPAP()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public virtual void HHLOGFGGHHD()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public virtual void MMBMOHAFCHG()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public void DOLLPOPCANC()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 512f);
	}

	public virtual void DLDGKEHFKDP()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	public virtual void DFEHFDNHIAI()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public override void InitGUIValues()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public void OMCEGPODDHL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 162f);
	}

	public virtual void HHEEDIHHCEA()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public virtual void OBNCKIBJOGJ()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
	}

	public virtual void AGFDJGJALKD()
	{
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
	}

	public virtual void HCKAGMPIOAK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void EOGJKCAKCMH(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.GetSquadDetails)
		{
			DCHDPJHPKNM();
		}
	}

	private void MGHKOALEPPD(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF() && IFGAGNBDKBE == DatabaseAction.PromotePlayer)
		{
			HMMDICNOBIE();
		}
	}

	public virtual void MOPAOJFCOGP()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
	}

	private void KOACKJOKJNP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void NOPMIILDKHD()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			UILabel jFHCIILADJL = JFHCIILADJL;
			object[] array = new object[1];
			array[1] = aANECPGDMGM.IKJHAHJHLIH;
			jFHCIILADJL.text = Localization.LocalizeFormat("ID_FEATURE_MAGAZINE-WEAPONPREFIX", array);
			GEDJKICFLMI.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH).ToString();
		}
	}

	public void PCBDDAMEPCJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1922f);
	}
}

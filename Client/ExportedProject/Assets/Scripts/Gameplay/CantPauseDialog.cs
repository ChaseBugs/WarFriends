using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CantPauseDialog : GuiElementSingle<CantPauseDialog>, PAIIOKBBHBC
{
	[Header("Buttons")]
	[FormerlySerializedAs("APLHPCBEOJN")]
	public UIButton CDICAPMLOLF;

	[FormerlySerializedAs("KJDINAJFICI")]
	public UIButton FIOMODFAAPG;

	private void CHDFHABNECF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("damage"), Localization.Localize("{0}{1}{2}"), CGOJNBKGOFJ, 39f);
		}
	}

	private void JIBCMJCADIA(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_FORFEIT"), Localization.Localize("ID_CONFIRM_FORFEIT_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
			HideDialog();
		});
	}

	private void NHOCBIKIKOE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void IOFLIMABDOF(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
		HideDialog();
	}

	public virtual void JNLAEKOOMMH()
	{
	}

	private void MMLEBDLDIEN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	private void GGKPOOENEED(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void BCLAFFCPCEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EEDDACMHPPI));
		Singleton<GameController>.instance.CNPGMMPAGIE(DBCPGDNDEOG);
	}

	public virtual void HPJDOALKOGF()
	{
	}

	public virtual void HCAOABHNLID()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ECJHPNCIMKA));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LAFOONALLAG));
		Singleton<GameController>.instance.GameEnded += MEEAGBBDLOB;
	}

	private void NOHMMIJODKO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
		}
		HideDialog();
	}

	public GuiElement JJKOKNIDFIN()
	{
		return this;
	}

	private void FOIANHEJBHJ(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
		HideDialog();
	}

	public virtual void IODCFNOOAKM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKPDHCKFJPK));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ALOCPKDLMJO));
		Singleton<GameController>.instance.GameEnded += HAHNAGPGELH;
	}

	public virtual void DCNGEGFNAGG()
	{
		ECJHPNCIMKA(CDICAPMLOLF.gameObject);
	}

	private void AMMMAKHICNB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
		HideDialog();
	}

	private void JNDDOPAAAJM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void JPCNPIAHMHO()
	{
		AOIINFHNCAB(CDICAPMLOLF.gameObject);
	}

	public virtual void EJGCLLIGBCB()
	{
		GDKNMINIJMP(CDICAPMLOLF.gameObject);
	}

	private void MMKBCCDILBD(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement LGCLDIDHJHB()
	{
		return this;
	}

	public GuiElement NDOMPDOOJND()
	{
		return this;
	}

	private void AKGHOHDHLDO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("registerCustomProfileGeolocation"), Localization.Localize("はい"), AMMMAKHICNB, 429f);
		}
	}

	public override void InitGUIValues()
	{
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ELFGLLIEMHP));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFKIHLGMNLO));
		Singleton<GameController>.instance.GameEnded += GGKPOOENEED;
	}

	public virtual void JCEMKGHAHNE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCOFCKOOCAK));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MEFDJOFCFDD));
		Singleton<GameController>.instance.GameEnded += AFOFEACDGAN;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void MEEAGBBDLOB(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void FBNPDPDJOBP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMLEBDLDIEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JIBCMJCADIA));
		Singleton<GameController>.instance.CNPGMMPAGIE(NAEALJKFELI);
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void FFKPDEPHIMO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
		HideDialog();
	}

	public virtual void KJBGADNDLGI()
	{
		DHEPCFMAAPJ(CDICAPMLOLF.gameObject);
	}

	private void JJNLDFHEHJL(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void HAHNAGPGELH(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void MAGBDEKOOFO(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void NAEALJKFELI(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void HJGDBEBKBIG(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
		HideDialog();
	}

	private void DOLNKCGGLIC(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			ConfirmDialog.LGANINAGPLB(Localization.Localize("DESCARREGAR"), Localization.Localize("Leaderboard removed succesfully"), NOHMMIJODKO, 60f);
		}
	}

	private void CGOJNBKGOFJ(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
		}
		HideDialog();
	}

	public virtual void IBNHJGLOHAE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMLEBDLDIEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CHDFHABNECF));
		Singleton<GameController>.instance.GameEnded += HAHNAGPGELH;
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	public virtual void GKPGHCLMCDK()
	{
		BJNEDBNFAIH(CDICAPMLOLF.gameObject);
	}

	private void DBCPGDNDEOG(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void CFKIHLGMNLO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("GoldenSuitcase"), Localization.Localize("Level"), DKFLPCFELGD, 1003f);
		}
	}

	public virtual void GBLCNFADKHF()
	{
		ELFGLLIEMHP(CDICAPMLOLF.gameObject);
	}

	private void BCJIDPBMBIN(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public GuiElement HJFNBHHEGIF()
	{
		return this;
	}

	private void ELFGLLIEMHP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void BJNEDBNFAIH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void BNNADAGCCFL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			ConfirmDialog.BMBPFNKJHMF(Localization.Localize("metalExplosion"), Localization.Localize("."), FDHFMAAPNGO, 1960f);
		}
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDKNMINIJMP));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFKIHLGMNLO));
		Singleton<GameController>.instance.CNPGMMPAGIE(DBCPGDNDEOG);
	}

	private void ECJHPNCIMKA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void HCMELDFOBCP()
	{
	}

	private void KCGNMHMJOAL(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void GMOFOOGNOAH()
	{
	}

	private void MEKBOAGPDFB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
		HideDialog();
	}

	[CompilerGenerated]
	private void EEKMFMKNDBK(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
		HideDialog();
	}

	private void GCOFCKOOCAK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void ALOCPKDLMJO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("{0} {1}"), Localization.Localize("WarBucks"), NOHMMIJODKO, 383f);
		}
	}

	private void LAFOONALLAG(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_MAXCCUREACHED"), Localization.Localize("ActionId"), OHFHBDOJACE, 855f);
		}
	}

	private void CJBEDMCOGEJ(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
		HideDialog();
	}

	private void IJBLACCMPAL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void PKEJPFLBDOJ(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
		HideDialog();
	}

	public virtual void KFANFNCILJI()
	{
	}

	private void GEMEPHEMLDO(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCJIDPBMBIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MEFDJOFCFDD));
		Singleton<GameController>.instance.GameEnded += NAEALJKFELI;
	}

	private void GNPBMCPONBK(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITWARFRIENDS"), Localization.Localize(" "), DKFLPCFELGD, 725f);
		}
	}

	public virtual void OPEIFLGEBFI()
	{
	}

	public virtual void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NHOCBIKIKOE));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CHDFHABNECF));
		Singleton<GameController>.instance.CNPGMMPAGIE(KPPNCJBMDPE);
	}

	private void AOIINFHNCAB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void GGBGMIKAJKN(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void GDKNMINIJMP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void PLMGMJKHONH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("N"), Localization.Localize("ID_GUI_SQUADLEVELEDUP"), NOHMMIJODKO, 27f);
		}
	}

	private void DHDJCGHCNHP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void OHFHBDOJACE(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
		HideDialog();
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(CDICAPMLOLF.gameObject);
	}

	public virtual void NHKGKDBAKLH()
	{
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	private void DKFLPCFELGD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
		HideDialog();
	}

	public virtual void ODCHCNCMJGC()
	{
	}

	public virtual void AAFMLKNBILH()
	{
		BJNEDBNFAIH(CDICAPMLOLF.gameObject);
	}

	private void GPDICKLLDKD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
		HideDialog();
	}

	private void EOPLIKDIBEF(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void DFLGLEJIPCO()
	{
	}

	private void MMGLPPKHCCM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void EEDDACMHPPI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("service"), Localization.Localize("Warfriends"), HJGDBEBKBIG, 1757f);
		}
	}

	private void DHEPCFMAAPJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void DDIGHBOMGLN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("MaintenanceMessage"), Localization.Localize("PNManager: registration succeded: "), IOFLIMABDOF, 1854f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JIBCMJCADIA));
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	private void MEFDJOFCFDD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("author"), Localization.Localize("^\\D*"), IOFLIMABDOF, 1033f);
		}
	}

	public virtual void CDHLMEPGPNJ()
	{
	}

	private void HFNJOMFGDHM(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void FDHFMAAPNGO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
		HideDialog();
	}

	public virtual void EOMKJKMLNBA()
	{
		KFKEFLALEBC(CDICAPMLOLF.gameObject);
	}

	private void DCBMIGKHHLH(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	private void AFOFEACDGAN(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		HideDialog();
	}

	public virtual void PLAOCDOMCPP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CHDFHABNECF));
		Singleton<GameController>.instance.GameEnded += AFOFEACDGAN;
	}

	private void KFKEFLALEBC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void NKPDHCKFJPK(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void CHPAFPBJAEM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CDICAPMLOLF);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMLEBDLDIEN));
		UIEventListener uIEventListener2 = UIEventListener.Get(FIOMODFAAPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EEDDACMHPPI));
		Singleton<GameController>.instance.CNPGMMPAGIE(AFOFEACDGAN);
	}

	public virtual void OCACKBJDEHI()
	{
	}
}

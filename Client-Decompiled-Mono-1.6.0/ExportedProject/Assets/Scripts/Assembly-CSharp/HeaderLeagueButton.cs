using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class HeaderLeagueButton : GuiElementSingle<HeaderLeagueButton>
{
	[Header("Core")]
	public GameObject EJDBAIHFDCH;

	[Header("League Arc")]
	public LeagueArcGuiElement PJFGCMCKMJF;

	[Header("Hints")]
	public GameObject GBFNBEOKLDG;

	public UILabel GNCBNDEPGEP;

	public UITable MOEFDOJODKK;

	public UILabel NBACBIFHAFM;

	public UILabel CDAFCKNCFMB;

	private int MLBOCKOBLGH = 237;

	private bool BOPCKJNBALK;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> LGJCBPOPCPA;

	private void FDDBCEIGFHD(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (!GuiScreenSingle<EndScreen>.instance.isShowed || GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PJFGCMCKMJF.gameObject.activeInHierarchy))
		{
			KHLGCPNEPOL(OKHCCAIPHEG, FPECBPKHKOE);
		}
	}

	private void GGCPILKCGIK(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == DatabaseAction.SendRequestBuffer || IFGAGNBDKBE == (DatabaseAction)(-2) || IFGAGNBDKBE == (DatabaseAction)(-49)))
		{
			CCFJENHGIMN();
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == DatabaseAction.DebugChangeMedals || IFGAGNBDKBE == DatabaseAction.DebugChangeLeague || IFGAGNBDKBE == DatabaseAction.DebugChangeDivision))
		{
			PILDGJHBBIJ();
		}
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJFGCMCKMJF.NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFKLIPLNCJC));
		LeagueArcManager.instance.SorterPlayersLeague += BGIIFACNMNL;
		PJFGCMCKMJF.InitControls();
	}

	private void LMCOAIOPECF()
	{
		GNCBNDEPGEP.text = Localization.Localize("\tPush notification shown counter: {0}/{1}");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1325f);
		MOEFDOJODKK.gameObject.SetActive(false);
		NKNLPNANBCK();
	}

	public virtual void LEMNDNDGIOE()
	{
		if (!BOPCKJNBALK)
		{
			CCFJENHGIMN();
		}
		else if (!Singleton<GameController>.instance.isTutorial)
		{
			ICHADIIHADN(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.AJANKBIMBPE(), true);
		}
		EJDBAIHFDCH.SetActive(Singleton<GameController>.instance.isTutorial);
		HHJEDIPJDHE();
		BOPCKJNBALK = true;
	}

	private void PNOOCAPMLBK()
	{
		if (isShowed)
		{
			IJLNKHAJOPJ();
		}
	}

	public virtual void CCNJCLFHLFG()
	{
		base.InitEvents();
		PJFGCMCKMJF.InitEvents();
		Singleton<GameController>.instance.CNPGMMPAGIE(AGANJJLLOML);
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(PNOOCAPMLBK));
		SubscriptionManager.instance.SubscriptionStateChanged += PODOJOPCJBL;
	}

	private void MOLMNNACLHF(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = FPECBPKHKOE.Count;
		int num = Singleton<GameVariables>.instance.OEMLPPKCBLA(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.LOAOEHEJFJA(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-65)).FLOATVALUE;
		JBAGAHBOICJ jBAGAHBOICJ = Singleton<GameVariables>.instance.LeaguePositionType(flag, leagueTier, OKHCCAIPHEG, num, num2);
		int medalsBalance = FPECBPKHKOE[OKHCCAIPHEG - 0].medalsBalance;
		if (!flag)
		{
			if (OKHCCAIPHEG == 0)
			{
				GNCBNDEPGEP.text = Localization.Localize("ExplodeDamage");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1938f);
				MOEFDOJODKK.gameObject.SetActive(true);
			}
			else
			{
				int fFHHEHHFOKJ = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("menu-army-cat-explosive");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1380f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("ID_CLAIMING");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
			}
		}
		else if (OKHCCAIPHEG == 0)
		{
			GNCBNDEPGEP.text = Localization.Localize("thumbnailLittle");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(978f);
			MOEFDOJODKK.gameObject.SetActive(false);
		}
		else
		{
			switch (jBAGAHBOICJ)
			{
			case JBAGAHBOICJ.Stay:
			{
				int fFHHEHHFOKJ6 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 0;
				GNCBNDEPGEP.text = Localization.Localize("Message: squad player ended game -> get squad details to sync exp and stats");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1150f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("Unknown squad icon!");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ6);
				break;
			}
			case JBAGAHBOICJ.Demote:
			{
				int num3 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
				if (OKHCCAIPHEG <= num3)
				{
					int fFHHEHHFOKJ4 = FPECBPKHKOE[1].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("ID_CONFIRM_ERROR");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(382f);
					MOEFDOJODKK.gameObject.SetActive(false);
					NBACBIFHAFM.text = Localization.Localize("ID_ALIEN");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ4);
				}
				else
				{
					int fFHHEHHFOKJ5 = FPECBPKHKOE[num3 - 0].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("PlayerInfo");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1493f);
					MOEFDOJODKK.gameObject.SetActive(false);
					NBACBIFHAFM.text = Localization.Localize("ID_CONFIRM_LOGINFAILURE");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ5);
				}
				break;
			}
			default:
				if (jBAGAHBOICJ == JBAGAHBOICJ.Stay)
				{
					int fFHHEHHFOKJ2 = FPECBPKHKOE[num - 0].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("ID_WAIT");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(236f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("{0} {1}");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ2);
				}
				else
				{
					int fFHHEHHFOKJ3 = FPECBPKHKOE[num2 - 4].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("true");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(965f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("{0}{1}");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ3);
				}
				break;
			}
		}
		EHMJABNHJON();
	}

	private void LNKKLPDBIML()
	{
		float subscriptionPixels = GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = 1558f + subscriptionPixels;
		EJDBAIHFDCH.transform.localPosition = EJDBAIHFDCH.transform.localPosition.ReplaceX(val);
		int num = 24 + (int)subscriptionPixels;
		MLBOCKOBLGH = (int)UIHelper.activeWidthSafe - num;
	}

	private void MBFOKODFLDG()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			KDKFDKLNAAD();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			DADHMKMINHD();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			IJCBKNBLMAA();
		}
		else if (Singleton<ServerResultsCache>.instance.LKCGEKLNOHI())
		{
			CEPHFILNLMN();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			AINAKJIKHEA();
		}
		else
		{
			CFEAIEPBAKI();
		}
		GBFNBEOKLDG.transform.localPosition = GBFNBEOKLDG.transform.localPosition.ReplaceY(1254f);
		TweenPosition component = GBFNBEOKLDG.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	private void LDBLFKNJKJH(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.NPFFMLLLDAF())
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
		}
		else if (!GuiScreenSingle<CardSelectionScreen>.instance.isShowed && !Singleton<GameController>.instance.BAKCODKBCPJ() && !GuiScreenSingle<EndScreen>.instance.MJCDGCGLHEK())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF();
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
			if (flag)
			{
				GuiScreenSingle<LeaguesScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	private void GFOAOMAHDGP(MAPGBEOOFLL NDPMDKGJAFH, List<DatabasePlayer> FPECBPKHKOE, bool LDCEANJDPAH = false)
	{
		if (LDCEANJDPAH)
		{
			PJFGCMCKMJF.StopAnimations();
			PJFGCMCKMJF.InitializeTo(NDPMDKGJAFH);
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			NAEKPLFLIPL();
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			CEPHFILNLMN();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			if (FPECBPKHKOE == null)
			{
				FPECBPKHKOE = new List<DatabasePlayer>();
				FPECBPKHKOE.Add(GameLoginManager.currentPlayer);
			}
			int oKHCCAIPHEG = FPECBPKHKOE.FindIndex(HKJEIEGGCGJ) + 1;
			GJBAHKDMCNB(oKHCCAIPHEG, FPECBPKHKOE);
		}
		else
		{
			ILHNJEFHBFK();
		}
	}

	private void BGIIFACNMNL(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF() || GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PJFGCMCKMJF.gameObject.activeInHierarchy))
		{
			GJBAHKDMCNB(OKHCCAIPHEG, FPECBPKHKOE);
		}
	}

	private void JNBNLGFDODI()
	{
		GNCBNDEPGEP.text = Localization.Localize("ID_PLAYERLEAGUEPROCESSING");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(0f);
		MOEFDOJODKK.gameObject.SetActive(false);
		NMECECLCJGF();
	}

	private static bool NKMEJOBPEOD(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void IJCBKNBLMAA()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1883f);
		MOEFDOJODKK.gameObject.SetActive(true);
		EHMJABNHJON();
	}

	private void PPOMAGNADPO()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1848f);
		MOEFDOJODKK.gameObject.SetActive(true);
		NMECECLCJGF();
	}

	private void NGFJJLGBFGA()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			KDKFDKLNAAD();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			PPOMAGNADPO();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			AINAKJIKHEA();
		}
		else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			BJOMBLMPHOF();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			GJNMPLFBFEO();
		}
		else
		{
			OGGBJFBLOCD();
		}
		GBFNBEOKLDG.transform.localPosition = GBFNBEOKLDG.transform.localPosition.ReplaceY(1662f);
		TweenPosition component = GBFNBEOKLDG.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	private void APEPEHJLCLI(MAPGBEOOFLL NDPMDKGJAFH, List<DatabasePlayer> FPECBPKHKOE, bool LDCEANJDPAH = false)
	{
		if (LDCEANJDPAH)
		{
			PJFGCMCKMJF.StopAnimations();
			PJFGCMCKMJF.InitializeTo(NDPMDKGJAFH);
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			GHMKCNFAOJB();
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			JNBNLGFDODI();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			if (FPECBPKHKOE == null)
			{
				FPECBPKHKOE = new List<DatabasePlayer>();
				FPECBPKHKOE.Add(GameLoginManager.currentPlayer);
			}
			int oKHCCAIPHEG = FPECBPKHKOE.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id) + 1;
			KHLGCPNEPOL(oKHCCAIPHEG, FPECBPKHKOE);
		}
		else
		{
			ILHNJEFHBFK();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		PJFGCMCKMJF.InitEvents();
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(PNOOCAPMLBK));
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
	}

	private void FBCNMGGHFCN()
	{
		if (isShowed)
		{
			HHJEDIPJDHE();
		}
	}

	private void FIGHINBIGHD()
	{
		if (isShowed)
		{
			NKOOFKAINIK();
		}
	}

	private void AGANJJLLOML(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		BOPCKJNBALK = true;
	}

	private void CNFMOOMNKHP()
	{
		if (isShowed)
		{
			GMPMOAONOAL();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJFGCMCKMJF.NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFKLIPLNCJC));
		LeagueArcManager.instance.SorterPlayersLeague += FDDBCEIGFHD;
		PJFGCMCKMJF.InitControls();
	}

	private void BJOMBLMPHOF()
	{
		GNCBNDEPGEP.text = Localization.Localize("Name");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(663f);
		MOEFDOJODKK.gameObject.SetActive(true);
		NMECECLCJGF();
	}

	private void PKKEIHEJJFL()
	{
		if (isShowed)
		{
			HHJEDIPJDHE();
		}
	}

	private void CILJIAFBCCD()
	{
		if (isShowed)
		{
			GMPMOAONOAL();
		}
	}

	private void BFLFAMHJEKP(UITweener MGDJMGHCAAI)
	{
		if (LeagueArcManager.instance.GetWasDataUpdated())
		{
			APEPEHJLCLI(LeagueArcManager.instance.GetCurrentData(), LeagueArcManager.instance.GetCurrentPlayers(), true);
		}
		else
		{
			IJCBKNBLMAA();
		}
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(559f);
		TweenPosition.Begin(GBFNBEOKLDG, 1034f, pos).onFinished = null;
	}

	private void OAAIIKHLDKB(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (!GuiScreenSingle<EndScreen>.instance.isShowed || GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PJFGCMCKMJF.gameObject.activeInHierarchy))
		{
			HMKMGDMHGBG(OKHCCAIPHEG, FPECBPKHKOE);
		}
	}

	private static bool HKJEIEGGCGJ(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void KAHFDPDNGAB()
	{
		if (MOEFDOJODKK.gameObject.activeSelf)
		{
			int num = -109;
			float num2 = GNCBNDEPGEP.relativeSize.x * GNCBNDEPGEP.transform.localScale.x;
			float num3 = NBACBIFHAFM.relativeSize.x * NBACBIFHAFM.transform.localScale.x + CDAFCKNCFMB.relativeSize.x * CDAFCKNCFMB.transform.localScale.x;
			float a = (float)MLBOCKOBLGH / num2;
			float b = (float)(MLBOCKOBLGH - num) / num3;
			float gLIDDLHPAKL = Mathf.Clamp(Mathf.Min(a, b), 1528f, 1378f);
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, gLIDDLHPAKL, 562f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(NBACBIFHAFM, gLIDDLHPAKL, 886f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(CDAFCKNCFMB, gLIDDLHPAKL, 814f, MLBOCKOBLGH);
			MOEFDOJODKK.repositionNow = true;
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, 1488f, 751f, MLBOCKOBLGH);
		}
	}

	private static bool BNJNHELICOG(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void BNKBAJEFNGG()
	{
		if (isShowed)
		{
			KHIGDOCONHF();
		}
	}

	private void CFEAIEPBAKI()
	{
		GNCBNDEPGEP.text = Localization.Localize(")");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(706f);
		MOEFDOJODKK.gameObject.SetActive(false);
		MKLPFFMMFGC();
	}

	public virtual void AFICHGGNMJB()
	{
		base.InitEvents();
		PJFGCMCKMJF.IKHPOKNAGGN();
		Singleton<GameController>.instance.CNPGMMPAGIE(AGANJJLLOML);
		Singleton<BeanstalkServerManager>.instance.DataLoaded += GGCPILKCGIK;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(CNFMOOMNKHP));
		SubscriptionManager.instance.SubscriptionStateChanged += HJFKDBFPKKC;
	}

	private void NFPJJLIPALL()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(362f);
		MOEFDOJODKK.gameObject.SetActive(false);
		CACGACONKEB();
	}

	private void CEHBMAPNJBH()
	{
		if (NPFFMLLLDAF())
		{
			IJLNKHAJOPJ();
		}
	}

	public virtual void HNAKKKGDPOG()
	{
		base.InitEvents();
		PJFGCMCKMJF.IKHPOKNAGGN();
		Singleton<GameController>.instance.CNPGMMPAGIE(KPPNCJBMDPE);
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(CILJIAFBCCD));
		SubscriptionManager.instance.SubscriptionStateChanged += HJFKDBFPKKC;
	}

	public void DKGLEALNIGD()
	{
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(311f);
		TweenPosition.Begin(GBFNBEOKLDG, 1813f, pos, false).onFinished = delegate
		{
			if (LeagueArcManager.instance.GetWasDataUpdated())
			{
				APEPEHJLCLI(LeagueArcManager.instance.GetCurrentData(), LeagueArcManager.instance.GetCurrentPlayers(), true);
			}
			else
			{
				GHMKCNFAOJB();
			}
			Vector3 pos2 = GBFNBEOKLDG.transform.localPosition.ReplaceY(4f);
			TweenPosition.Begin(GBFNBEOKLDG, 0.5f, pos2).onFinished = null;
		};
	}

	private void LJMINJFIOHM()
	{
		GNCBNDEPGEP.text = Localization.Localize("grenadeExplosion");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(596f);
		MOEFDOJODKK.gameObject.SetActive(true);
		KAHFDPDNGAB();
	}

	private void OBEGMIODBOM()
	{
		GNCBNDEPGEP.text = Localization.Localize("}");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1626f);
		MOEFDOJODKK.gameObject.SetActive(false);
		CACGACONKEB();
	}

	private void BBBLGNMNBJA(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		}
		else if (!GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.isTutorial && !GuiScreenSingle<EndScreen>.instance.MJCDGCGLHEK())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF();
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
			if (flag)
			{
				GuiScreenSingle<LeaguesScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	private void NINHGHKDGDK(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.NPFFMLLLDAF())
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
		}
		else if (!GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.isTutorial && !GuiScreenSingle<EndScreen>.instance.MJCDGCGLHEK())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF();
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
			if (flag)
			{
				GuiScreenSingle<LeaguesScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	private void ICHADIIHADN(MAPGBEOOFLL NDPMDKGJAFH, List<DatabasePlayer> FPECBPKHKOE, bool LDCEANJDPAH = false)
	{
		if (LDCEANJDPAH)
		{
			PJFGCMCKMJF.ACLFHDDIBJH();
			PJFGCMCKMJF.InitializeTo(NDPMDKGJAFH);
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			DADHMKMINHD();
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			BJOMBLMPHOF();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			if (FPECBPKHKOE == null)
			{
				FPECBPKHKOE = new List<DatabasePlayer>();
				FPECBPKHKOE.Add(GameLoginManager.currentPlayer);
			}
			int oKHCCAIPHEG = FPECBPKHKOE.FindIndex(HKJEIEGGCGJ) + 0;
			LNBJFNHAIKJ(oKHCCAIPHEG, FPECBPKHKOE);
		}
		else
		{
			LJMINJFIOHM();
		}
	}

	private void JEAOHBHDNJI()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(755f);
		MOEFDOJODKK.gameObject.SetActive(true);
		MKLPFFMMFGC();
	}

	private void CEPHFILNLMN()
	{
		GNCBNDEPGEP.text = Localization.Localize("Current unit is not delivered at the moment!!!");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(43f);
		MOEFDOJODKK.gameObject.SetActive(false);
		KAHFDPDNGAB();
	}

	private void HJFKDBFPKKC()
	{
		if (isShowed)
		{
			KHIGDOCONHF();
		}
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJFGCMCKMJF.NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NINHGHKDGDK));
		LeagueArcManager.instance.GNMLAPECGJP(OAAIIKHLDKB);
		PJFGCMCKMJF.InitControls();
	}

	private void AINAKJIKHEA()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(449f);
		MOEFDOJODKK.gameObject.SetActive(false);
		NKNLPNANBCK();
	}

	private void KKEAOGBAGFL(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.NPFFMLLLDAF())
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
		}
		else if (!GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.DAIEAMEFGIE() && !GuiScreenSingle<EndScreen>.instance.MJCDGCGLHEK())
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF();
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			if (flag)
			{
				GuiScreenSingle<LeaguesScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	private void NNDELGLELPD(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = FPECBPKHKOE.Count;
		int num = Singleton<GameVariables>.instance.OEMLPPKCBLA(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.LeaguePositionDemote(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverPackMaxRarityCardsType).FLOATVALUE;
		JBAGAHBOICJ jBAGAHBOICJ = Singleton<GameVariables>.instance.LeaguePositionType(flag, leagueTier, OKHCCAIPHEG, num, num2);
		int medalsBalance = FPECBPKHKOE[OKHCCAIPHEG - 1].medalsBalance;
		if (!flag)
		{
			if (OKHCCAIPHEG == 0)
			{
				GNCBNDEPGEP.text = Localization.Localize("Automatic_Equip");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(895f);
				MOEFDOJODKK.gameObject.SetActive(true);
			}
			else
			{
				int fFHHEHHFOKJ = FPECBPKHKOE[0].medalsBalance - medalsBalance + 0;
				GNCBNDEPGEP.text = Localization.Localize("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot decline player");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(423f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("ID_TUTORIAL_NOACCOUNT_{0}_TITLE");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
			}
		}
		else if (OKHCCAIPHEG == 0)
		{
			GNCBNDEPGEP.text = Localization.Localize("Changed country to {0} from {1}.");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(198f);
			MOEFDOJODKK.gameObject.SetActive(true);
		}
		else if (jBAGAHBOICJ == JBAGAHBOICJ.Stay)
		{
			int fFHHEHHFOKJ2 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
			GNCBNDEPGEP.text = Localization.Localize("ID_NA");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(258f);
			MOEFDOJODKK.gameObject.SetActive(true);
			NBACBIFHAFM.text = Localization.Localize("\"}");
			CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ2);
		}
		else if (jBAGAHBOICJ == JBAGAHBOICJ.Stay)
		{
			int num3 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
			if (OKHCCAIPHEG <= num3)
			{
				int fFHHEHHFOKJ3 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("Can't shoot angle!!");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(866f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("ID_LEAVE_SPECTATE");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ3);
			}
			else
			{
				int fFHHEHHFOKJ4 = FPECBPKHKOE[num3 - 1].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("menu-arena-ticket");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(993f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("veteranpack1");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ4);
			}
		}
		else if (jBAGAHBOICJ == JBAGAHBOICJ.Stay)
		{
			int fFHHEHHFOKJ5 = FPECBPKHKOE[num - 0].medalsBalance - medalsBalance + 1;
			GNCBNDEPGEP.text = Localization.Localize("Sniper_Tutorial_Played");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(80f);
			MOEFDOJODKK.gameObject.SetActive(false);
			NBACBIFHAFM.text = Localization.Localize("ID_WARNING_TWITTERACCOUNTSUSPENDED");
			CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ5);
		}
		else
		{
			int fFHHEHHFOKJ6 = FPECBPKHKOE[num2 - 0].medalsBalance - medalsBalance + 0;
			GNCBNDEPGEP.text = Localization.Localize("currentDogtags: ");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1961f);
			MOEFDOJODKK.gameObject.SetActive(true);
			NBACBIFHAFM.text = Localization.Localize("http://localhost:3000/socket.io/");
			CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ6);
		}
		NMECECLCJGF();
	}

	private void IJLNKHAJOPJ()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			GHMKCNFAOJB();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			GHMKCNFAOJB();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			GHMKCNFAOJB();
		}
		else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			JNBNLGFDODI();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			GHMKCNFAOJB();
		}
		else
		{
			ILHNJEFHBFK();
		}
		GBFNBEOKLDG.transform.localPosition = GBFNBEOKLDG.transform.localPosition.ReplaceY(4f);
		TweenPosition component = GBFNBEOKLDG.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void PILDGJHBBIJ()
	{
		IJLNKHAJOPJ();
		PJFGCMCKMJF.InitGuiValues();
	}

	public void POKINAMFOGB()
	{
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(1394f);
		TweenPosition.Begin(GBFNBEOKLDG, 372f, pos, false).onFinished = delegate
		{
			if (LeagueArcManager.instance.GetWasDataUpdated())
			{
				APEPEHJLCLI(LeagueArcManager.instance.GetCurrentData(), LeagueArcManager.instance.GetCurrentPlayers(), true);
			}
			else
			{
				GHMKCNFAOJB();
			}
			Vector3 pos2 = GBFNBEOKLDG.transform.localPosition.ReplaceY(4f);
			TweenPosition.Begin(GBFNBEOKLDG, 0.5f, pos2).onFinished = null;
		};
	}

	private void NAEKPLFLIPL()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(420f);
		MOEFDOJODKK.gameObject.SetActive(false);
		KAHFDPDNGAB();
	}

	public void LNFBEKOKICP()
	{
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(1293f);
		TweenPosition.Begin(GBFNBEOKLDG, 131f, pos, false).onFinished = DEBNBDKNJNP;
	}

	public override void InitGUIValues()
	{
		if (!BOPCKJNBALK)
		{
			PILDGJHBBIJ();
		}
		else if (!Singleton<GameController>.instance.isTutorial)
		{
			APEPEHJLCLI(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.GetPreviousPlayers());
		}
		EJDBAIHFDCH.SetActive(!Singleton<GameController>.instance.isTutorial);
		HHJEDIPJDHE();
		BOPCKJNBALK = false;
	}

	private void HHJEDIPJDHE()
	{
		float subscriptionPixels = GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = 871f + subscriptionPixels;
		EJDBAIHFDCH.transform.localPosition = EJDBAIHFDCH.transform.localPosition.ReplaceX(val);
		int num = 1683 + (int)subscriptionPixels;
		MLBOCKOBLGH = (int)UIHelper.activeWidthSafe - num;
	}

	private void LDNDKKGALJJ()
	{
		float subscriptionPixels = GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = 386f + subscriptionPixels;
		EJDBAIHFDCH.transform.localPosition = EJDBAIHFDCH.transform.localPosition.ReplaceX(val);
		int num = -139 + (int)subscriptionPixels;
		MLBOCKOBLGH = (int)UIHelper.activeWidthSafe - num;
	}

	private void EDNLPDACCHB(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (!GuiScreenSingle<EndScreen>.instance.isShowed || GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PJFGCMCKMJF.gameObject.activeInHierarchy))
		{
			GJBAHKDMCNB(OKHCCAIPHEG, FPECBPKHKOE);
		}
	}

	private void CBLBNFMMKFA()
	{
		if (isShowed)
		{
			NGFJJLGBFGA();
		}
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		BOPCKJNBALK = true;
	}

	private void PODOJOPCJBL()
	{
		if (isShowed)
		{
			LDNDKKGALJJ();
		}
	}

	public void AnimateHint()
	{
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(120f);
		TweenPosition.Begin(GBFNBEOKLDG, 0.5f, pos).onFinished = delegate
		{
			if (LeagueArcManager.instance.GetWasDataUpdated())
			{
				APEPEHJLCLI(LeagueArcManager.instance.GetCurrentData(), LeagueArcManager.instance.GetCurrentPlayers(), true);
			}
			else
			{
				GHMKCNFAOJB();
			}
			Vector3 pos2 = GBFNBEOKLDG.transform.localPosition.ReplaceY(4f);
			TweenPosition.Begin(GBFNBEOKLDG, 0.5f, pos2).onFinished = null;
		};
	}

	private void NKOOFKAINIK()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			GJNMPLFBFEO();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			NFPJJLIPALL();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			GHMKCNFAOJB();
		}
		else if (Singleton<ServerResultsCache>.instance.HLFMPGHKOFE())
		{
			CEPHFILNLMN();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			AINAKJIKHEA();
		}
		else
		{
			NPAJPIKLBOF();
		}
		GBFNBEOKLDG.transform.localPosition = GBFNBEOKLDG.transform.localPosition.ReplaceY(420f);
		TweenPosition component = GBFNBEOKLDG.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	private void NMNJKEHNLOO()
	{
		GNCBNDEPGEP.text = Localization.Localize("Avg_fps");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(153f);
		MOEFDOJODKK.gameObject.SetActive(true);
		NMECECLCJGF();
	}

	private static bool MBNHOGMCBPL(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void ILHNJEFHBFK()
	{
		GNCBNDEPGEP.text = Localization.Localize("ID_PLAYPVPBATTLETOENTERLEAGUE");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(0f);
		MOEFDOJODKK.gameObject.SetActive(false);
		NMECECLCJGF();
	}

	public virtual void HGFBALANKEE()
	{
		base.InitEvents();
		PJFGCMCKMJF.IKHPOKNAGGN();
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(FJDBPEAFBHN);
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(FIGHINBIGHD));
		SubscriptionManager.instance.SubscriptionStateChanged += FBCNMGGHFCN;
	}

	private void BEPBILILOIK(MAPGBEOOFLL NDPMDKGJAFH, List<DatabasePlayer> FPECBPKHKOE, bool LDCEANJDPAH = false)
	{
		if (LDCEANJDPAH)
		{
			PJFGCMCKMJF.ACLFHDDIBJH();
			PJFGCMCKMJF.InitializeTo(NDPMDKGJAFH, true);
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			AINAKJIKHEA();
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			BJOMBLMPHOF();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			if (FPECBPKHKOE == null)
			{
				FPECBPKHKOE = new List<DatabasePlayer>();
				FPECBPKHKOE.Add(GameLoginManager.currentPlayer);
			}
			int oKHCCAIPHEG = FPECBPKHKOE.FindIndex(HKJEIEGGCGJ) + 0;
			MOLMNNACLHF(oKHCCAIPHEG, FPECBPKHKOE);
		}
		else
		{
			OBEGMIODBOM();
		}
	}

	private void KDKFDKLNAAD()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1560f);
		MOEFDOJODKK.gameObject.SetActive(true);
		CACGACONKEB();
	}

	private void IKNJCBJJLOK(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (!GuiScreenSingle<EndScreen>.instance.isShowed || GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PJFGCMCKMJF.gameObject.activeInHierarchy))
		{
			HMKMGDMHGBG(OKHCCAIPHEG, FPECBPKHKOE);
		}
	}

	private void FJDBPEAFBHN(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == (DatabaseAction)(-199) || IFGAGNBDKBE == (DatabaseAction)(-44) || IFGAGNBDKBE == (DatabaseAction)(-71)))
		{
			CCFJENHGIMN();
		}
	}

	private void OGGBJFBLOCD()
	{
		GNCBNDEPGEP.text = Localization.Localize("UseOnGetPlayerData");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(350f);
		MOEFDOJODKK.gameObject.SetActive(false);
		MKLPFFMMFGC();
	}

	private void GMPMOAONOAL()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			JEAOHBHDNJI();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			IJCBKNBLMAA();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			DADHMKMINHD();
		}
		else if (Singleton<ServerResultsCache>.instance.HLFMPGHKOFE())
		{
			BJOMBLMPHOF();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			PPOMAGNADPO();
		}
		else
		{
			OGGBJFBLOCD();
		}
		GBFNBEOKLDG.transform.localPosition = GBFNBEOKLDG.transform.localPosition.ReplaceY(1031f);
		TweenPosition component = GBFNBEOKLDG.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void NGOMHEHCDMG()
	{
		NGFJJLGBFGA();
		PJFGCMCKMJF.EPFKCOHPCAK();
	}

	public virtual void PDHNLAMPOBN()
	{
		if (!BOPCKJNBALK)
		{
			PILDGJHBBIJ();
		}
		else if (!Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			HHIJIIDFNMN(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.AJANKBIMBPE());
		}
		EJDBAIHFDCH.SetActive(!Singleton<GameController>.instance.isTutorial);
		LNKKLPDBIML();
		BOPCKJNBALK = true;
	}

	private void NPAJPIKLBOF()
	{
		GNCBNDEPGEP.text = Localization.Localize("ItemsOwned_Rarity_1");
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(825f);
		MOEFDOJODKK.gameObject.SetActive(false);
		NMECECLCJGF();
	}

	private void KFHKGMMCEHB(UITweener MGDJMGHCAAI)
	{
		if (LeagueArcManager.instance.GetWasDataUpdated())
		{
			APEPEHJLCLI(LeagueArcManager.instance.DEHPHBDDGGN(), LeagueArcManager.instance.IILLBIPGLJG());
		}
		else
		{
			JEAOHBHDNJI();
		}
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(644f);
		TweenPosition.Begin(GBFNBEOKLDG, 1199f, pos, false).onFinished = null;
	}

	private void KHLGCPNEPOL(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = FPECBPKHKOE.Count;
		int num = Singleton<GameVariables>.instance.LeaguePositionPromote(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.LeaguePositionDemote(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		JBAGAHBOICJ jBAGAHBOICJ = Singleton<GameVariables>.instance.LeaguePositionType(!flag, leagueTier, OKHCCAIPHEG, num, num2);
		int medalsBalance = FPECBPKHKOE[OKHCCAIPHEG - 1].medalsBalance;
		if (!flag)
		{
			if (OKHCCAIPHEG == 1)
			{
				GNCBNDEPGEP.text = Localization.Localize("ID_KEEPITUPYOUARENUMBERONE");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(0f);
				MOEFDOJODKK.gameObject.SetActive(false);
			}
			else
			{
				int fFHHEHHFOKJ = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ID_TOBENUMBERONE1");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(22f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("ID_TOBENUMBERONE2");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
			}
		}
		else if (OKHCCAIPHEG == 1)
		{
			GNCBNDEPGEP.text = Localization.Localize("ID_KEEPITUPYOUARENUMBERONE");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(0f);
			MOEFDOJODKK.gameObject.SetActive(false);
		}
		else
		{
			switch (jBAGAHBOICJ)
			{
			case JBAGAHBOICJ.Promote:
			{
				int fFHHEHHFOKJ6 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ID_TOBENUMBERONE1");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(22f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("ID_TOBENUMBERONE2");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ6);
				break;
			}
			case JBAGAHBOICJ.Top:
			{
				int num3 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
				if (OKHCCAIPHEG <= num3)
				{
					int fFHHEHHFOKJ4 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("ID_TOBENUMBERONE1");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(22f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("ID_TOBENUMBERONE2");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ4);
				}
				else
				{
					int fFHHEHHFOKJ5 = FPECBPKHKOE[num3 - 1].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("ID_GETAREWARD1");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(22f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("ID_GETAREWARD2");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ5);
				}
				break;
			}
			case JBAGAHBOICJ.Stay:
			{
				int fFHHEHHFOKJ3 = FPECBPKHKOE[num - 1].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ID_GETAPROMOTION1");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(22f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("ID_GETAPROMOTION2");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ3);
				break;
			}
			default:
			{
				int fFHHEHHFOKJ2 = FPECBPKHKOE[num2 - 2].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ID_AVOIDRELEGATION1");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(22f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("ID_AVOIDRELEGATION2");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ2);
				break;
			}
			}
		}
		NMECECLCJGF();
	}

	private void JFNHNEJFACA(UITweener MGDJMGHCAAI)
	{
		if (LeagueArcManager.instance.GetWasDataUpdated())
		{
			GFOAOMAHDGP(LeagueArcManager.instance.DEHPHBDDGGN(), LeagueArcManager.instance.IILLBIPGLJG(), true);
		}
		else
		{
			GHMKCNFAOJB();
		}
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(1454f);
		TweenPosition.Begin(GBFNBEOKLDG, 1038f, pos, false).onFinished = null;
	}

	private void CCNGJKKCPEO(MAPGBEOOFLL NDPMDKGJAFH, List<DatabasePlayer> FPECBPKHKOE, bool LDCEANJDPAH = false)
	{
		if (LDCEANJDPAH)
		{
			PJFGCMCKMJF.ACLFHDDIBJH();
			PJFGCMCKMJF.InitializeTo(NDPMDKGJAFH);
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			GHMKCNFAOJB();
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			BJOMBLMPHOF();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			if (FPECBPKHKOE == null)
			{
				FPECBPKHKOE = new List<DatabasePlayer>();
				FPECBPKHKOE.Add(GameLoginManager.currentPlayer);
			}
			int oKHCCAIPHEG = FPECBPKHKOE.FindIndex(MBNHOGMCBPL) + 1;
			NNDELGLELPD(oKHCCAIPHEG, FPECBPKHKOE);
		}
		else
		{
			CFEAIEPBAKI();
		}
	}

	private void KHIGDOCONHF()
	{
		float num = GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = 1191f + num;
		EJDBAIHFDCH.transform.localPosition = EJDBAIHFDCH.transform.localPosition.ReplaceX(val);
		int num2 = 171 + (int)num;
		MLBOCKOBLGH = (int)UIHelper.activeWidthSafe - num2;
	}

	public virtual void FAGMMFKPKHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJFGCMCKMJF.NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFKLIPLNCJC));
		LeagueArcManager.instance.SorterPlayersLeague += OAAIIKHLDKB;
		PJFGCMCKMJF.InitControls();
	}

	private void HHIJIIDFNMN(MAPGBEOOFLL NDPMDKGJAFH, List<DatabasePlayer> FPECBPKHKOE, bool LDCEANJDPAH = false)
	{
		if (LDCEANJDPAH)
		{
			PJFGCMCKMJF.ACLFHDDIBJH();
			PJFGCMCKMJF.InitializeTo(NDPMDKGJAFH, true);
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			GJNMPLFBFEO();
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			LMCOAIOPECF();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			if (FPECBPKHKOE == null)
			{
				FPECBPKHKOE = new List<DatabasePlayer>();
				FPECBPKHKOE.Add(GameLoginManager.currentPlayer);
			}
			int oKHCCAIPHEG = FPECBPKHKOE.FindIndex(BNJNHELICOG) + 0;
			KHLGCPNEPOL(oKHCCAIPHEG, FPECBPKHKOE);
		}
		else
		{
			LJMINJFIOHM();
		}
	}

	private void GJBAHKDMCNB(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = FPECBPKHKOE.Count;
		int num = Singleton<GameVariables>.instance.AKGHLMKODBJ(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.LOAOEHEJFJA(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastVipPurchase).FLOATVALUE;
		JBAGAHBOICJ jBAGAHBOICJ = Singleton<GameVariables>.instance.JLPCJHLPNNG(flag, leagueTier, OKHCCAIPHEG, num, num2);
		int medalsBalance = FPECBPKHKOE[OKHCCAIPHEG - 1].medalsBalance;
		if (!flag)
		{
			if (OKHCCAIPHEG == 0)
			{
				GNCBNDEPGEP.text = Localization.Localize("SetRewardedVideoUserID");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1086f);
				MOEFDOJODKK.gameObject.SetActive(true);
			}
			else
			{
				int fFHHEHHFOKJ = FPECBPKHKOE[1].medalsBalance - medalsBalance + 0;
				GNCBNDEPGEP.text = Localization.Localize("VIP - {0}\n");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(13f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("ID_FEATURE_RATE-DESCRIPTION");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
			}
		}
		else if (OKHCCAIPHEG == 0)
		{
			GNCBNDEPGEP.text = Localization.Localize("Awaiting players - Player was removed from awaiting members.");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1014f);
			MOEFDOJODKK.gameObject.SetActive(false);
		}
		else
		{
			switch (jBAGAHBOICJ)
			{
			case JBAGAHBOICJ.Promote:
			{
				int fFHHEHHFOKJ6 = FPECBPKHKOE[1].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("UNLOCKLEVEL");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(984f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("{0} doesn't contain data for wararena unit");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ6);
				break;
			}
			case (JBAGAHBOICJ)5:
			{
				int num3 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
				if (OKHCCAIPHEG <= num3)
				{
					int fFHHEHHFOKJ4 = FPECBPKHKOE[1].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("Youtube");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1643f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("ID_FACEBOOKCONNECT");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ4);
				}
				else
				{
					int fFHHEHHFOKJ5 = FPECBPKHKOE[num3 - 1].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("ID_GUI_INVITETOCOOP");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1631f);
					MOEFDOJODKK.gameObject.SetActive(false);
					NBACBIFHAFM.text = Localization.Localize("deviceLogin");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ5);
				}
				break;
			}
			case JBAGAHBOICJ.Stay:
			{
				int fFHHEHHFOKJ3 = FPECBPKHKOE[num - 1].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("EG");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1310f);
				MOEFDOJODKK.gameObject.SetActive(true);
				NBACBIFHAFM.text = Localization.Localize("Notification_YourSquadstatus");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ3);
				break;
			}
			default:
			{
				int fFHHEHHFOKJ2 = FPECBPKHKOE[num2 - 7].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ClearEntries");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(590f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("ID_CATEGORY_LOW_SG_SPECIAL");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ2);
				break;
			}
			}
		}
		KAHFDPDNGAB();
	}

	private void JOLBDFDEAAG(UITweener MGDJMGHCAAI)
	{
		if (LeagueArcManager.instance.GetWasDataUpdated())
		{
			APEPEHJLCLI(LeagueArcManager.instance.DEHPHBDDGGN(), LeagueArcManager.instance.IILLBIPGLJG(), true);
		}
		else
		{
			GJNMPLFBFEO();
		}
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(1931f);
		TweenPosition.Begin(GBFNBEOKLDG, 269f, pos, false).onFinished = null;
	}

	private void NKNLPNANBCK()
	{
		if (MOEFDOJODKK.gameObject.activeSelf)
		{
			int num = -118;
			float num2 = GNCBNDEPGEP.relativeSize.x * GNCBNDEPGEP.transform.localScale.x;
			float num3 = NBACBIFHAFM.relativeSize.x * NBACBIFHAFM.transform.localScale.x + CDAFCKNCFMB.relativeSize.x * CDAFCKNCFMB.transform.localScale.x;
			float a = (float)MLBOCKOBLGH / num2;
			float b = (float)(MLBOCKOBLGH - num) / num3;
			float gLIDDLHPAKL = Mathf.Clamp(Mathf.Min(a, b), 623f, 610f);
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, gLIDDLHPAKL, 52f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(NBACBIFHAFM, gLIDDLHPAKL, 1940f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(CDAFCKNCFMB, gLIDDLHPAKL, 883f, MLBOCKOBLGH);
			MOEFDOJODKK.repositionNow = true;
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, 1917f, 892f, MLBOCKOBLGH);
		}
	}

	private void NMECECLCJGF()
	{
		if (MOEFDOJODKK.gameObject.activeSelf)
		{
			int num = 52;
			float num2 = GNCBNDEPGEP.relativeSize.x * GNCBNDEPGEP.transform.localScale.x;
			float num3 = NBACBIFHAFM.relativeSize.x * NBACBIFHAFM.transform.localScale.x + CDAFCKNCFMB.relativeSize.x * CDAFCKNCFMB.transform.localScale.x;
			float a = (float)MLBOCKOBLGH / num2;
			float b = (float)(MLBOCKOBLGH - num) / num3;
			float gLIDDLHPAKL = Mathf.Clamp(Mathf.Min(a, b), 20f, 30f);
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, gLIDDLHPAKL, 20f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(NBACBIFHAFM, gLIDDLHPAKL, 20f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(CDAFCKNCFMB, gLIDDLHPAKL, 20f, MLBOCKOBLGH);
			MOEFDOJODKK.repositionNow = true;
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, 30f, 20f, MLBOCKOBLGH);
		}
	}

	private void EHMJABNHJON()
	{
		if (MOEFDOJODKK.gameObject.activeSelf)
		{
			int num = -127;
			float num2 = GNCBNDEPGEP.relativeSize.x * GNCBNDEPGEP.transform.localScale.x;
			float num3 = NBACBIFHAFM.relativeSize.x * NBACBIFHAFM.transform.localScale.x + CDAFCKNCFMB.relativeSize.x * CDAFCKNCFMB.transform.localScale.x;
			float a = (float)MLBOCKOBLGH / num2;
			float b = (float)(MLBOCKOBLGH - num) / num3;
			float gLIDDLHPAKL = Mathf.Clamp(Mathf.Min(a, b), 389f, 973f);
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, gLIDDLHPAKL, 222f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(NBACBIFHAFM, gLIDDLHPAKL, 502f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(CDAFCKNCFMB, gLIDDLHPAKL, 1747f, MLBOCKOBLGH);
			MOEFDOJODKK.repositionNow = false;
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, 1006f, 1127f, MLBOCKOBLGH);
		}
	}

	public virtual void NCMGAHLFKFN()
	{
		base.InitEvents();
		PJFGCMCKMJF.InitEvents();
		Singleton<GameController>.instance.CNPGMMPAGIE(AGANJJLLOML);
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(CEHBMAPNJBH));
		SubscriptionManager.instance.SubscriptionStateChanged += BNKBAJEFNGG;
	}

	private void CACGACONKEB()
	{
		if (MOEFDOJODKK.gameObject.activeSelf)
		{
			int num = -22;
			float num2 = GNCBNDEPGEP.relativeSize.x * GNCBNDEPGEP.transform.localScale.x;
			float num3 = NBACBIFHAFM.relativeSize.x * NBACBIFHAFM.transform.localScale.x + CDAFCKNCFMB.relativeSize.x * CDAFCKNCFMB.transform.localScale.x;
			float a = (float)MLBOCKOBLGH / num2;
			float b = (float)(MLBOCKOBLGH - num) / num3;
			float gLIDDLHPAKL = Mathf.Clamp(Mathf.Min(a, b), 93f, 1506f);
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, gLIDDLHPAKL, 342f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(NBACBIFHAFM, gLIDDLHPAKL, 560f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(CDAFCKNCFMB, gLIDDLHPAKL, 505f, MLBOCKOBLGH);
			MOEFDOJODKK.repositionNow = true;
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, 1118f, 1150f, MLBOCKOBLGH);
		}
	}

	public void DDDIBCMEDNF()
	{
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(1063f);
		TweenPosition.Begin(GBFNBEOKLDG, 1752f, pos).onFinished = BFLFAMHJEKP;
	}

	private void DKGCNNLBOBN(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		BOPCKJNBALK = true;
	}

	public virtual void DMBLJNMGLAH()
	{
		if (!BOPCKJNBALK)
		{
			CCFJENHGIMN();
		}
		else if (!Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			GFOAOMAHDGP(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.AJANKBIMBPE());
		}
		EJDBAIHFDCH.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE());
		KHIGDOCONHF();
		BOPCKJNBALK = false;
	}

	public virtual void BNPDALDLFFM()
	{
		if (!BOPCKJNBALK)
		{
			CCFJENHGIMN();
		}
		else if (!Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			BEPBILILOIK(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.AJANKBIMBPE());
		}
		EJDBAIHFDCH.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		LDNDKKGALJJ();
		BOPCKJNBALK = true;
	}

	public virtual void LKBEJGHEANA()
	{
		if (!BOPCKJNBALK)
		{
			NGOMHEHCDMG();
		}
		else if (!Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			ICHADIIHADN(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.AJANKBIMBPE(), true);
		}
		EJDBAIHFDCH.SetActive(Singleton<GameController>.instance.DAIEAMEFGIE());
		HHJEDIPJDHE();
		BOPCKJNBALK = true;
	}

	private void HIMEPFCAAEN()
	{
		IJLNKHAJOPJ();
		PJFGCMCKMJF.IDDLDDBKJJK();
	}

	public virtual void NEINEPJDKCL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJFGCMCKMJF.NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NINHGHKDGDK));
		LeagueArcManager.instance.GNMLAPECGJP(BGIIFACNMNL);
		PJFGCMCKMJF.InitControls();
	}

	private void GHMKCNFAOJB()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(0f);
		MOEFDOJODKK.gameObject.SetActive(false);
		NMECECLCJGF();
	}

	public virtual void HHJDKKFKKIL()
	{
		if (!BOPCKJNBALK)
		{
			NGOMHEHCDMG();
		}
		else if (!Singleton<GameController>.instance.isTutorial)
		{
			APEPEHJLCLI(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.AJANKBIMBPE());
		}
		EJDBAIHFDCH.SetActive(!Singleton<GameController>.instance.DAIEAMEFGIE());
		LNKKLPDBIML();
		BOPCKJNBALK = true;
	}

	[CompilerGenerated]
	private static bool EJJGLPLMJDM(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void PFKLIPLNCJC(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		}
		else if (!GuiScreenSingle<CardSelectionScreen>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !GuiScreenSingle<EndScreen>.instance.canShowLvlUp)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.isShowed;
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			if (flag)
			{
				GuiScreenSingle<LeaguesScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			}
		}
	}

	private void DEBNBDKNJNP(UITweener MGDJMGHCAAI)
	{
		if (LeagueArcManager.instance.GetWasDataUpdated())
		{
			BEPBILILOIK(LeagueArcManager.instance.DEHPHBDDGGN(), LeagueArcManager.instance.GetCurrentPlayers(), true);
		}
		else
		{
			NAEKPLFLIPL();
		}
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(1431f);
		TweenPosition.Begin(GBFNBEOKLDG, 609f, pos, false).onFinished = null;
	}

	private void GJNMPLFBFEO()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(760f);
		MOEFDOJODKK.gameObject.SetActive(true);
		MKLPFFMMFGC();
	}

	public virtual void ALDOOKEMKPN()
	{
		base.InitEvents();
		PJFGCMCKMJF.IKHPOKNAGGN();
		Singleton<GameController>.instance.GameEnded += DKGCNNLBOBN;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.BHLILOLJHMK = (Action)Delegate.Combine(serverResultsCache.BHLILOLJHMK, new Action(CILJIAFBCCD));
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
	}

	private void MKLPFFMMFGC()
	{
		if (MOEFDOJODKK.gameObject.activeSelf)
		{
			int num = 108;
			float num2 = GNCBNDEPGEP.relativeSize.x * GNCBNDEPGEP.transform.localScale.x;
			float num3 = NBACBIFHAFM.relativeSize.x * NBACBIFHAFM.transform.localScale.x + CDAFCKNCFMB.relativeSize.x * CDAFCKNCFMB.transform.localScale.x;
			float a = (float)MLBOCKOBLGH / num2;
			float b = (float)(MLBOCKOBLGH - num) / num3;
			float gLIDDLHPAKL = Mathf.Clamp(Mathf.Min(a, b), 146f, 1334f);
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, gLIDDLHPAKL, 1643f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(NBACBIFHAFM, gLIDDLHPAKL, 1794f, MLBOCKOBLGH);
			MEJMLNDFDBP.COCBCFKJOJE(CDAFCKNCFMB, gLIDDLHPAKL, 1942f, MLBOCKOBLGH);
			MOEFDOJODKK.repositionNow = false;
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(GNCBNDEPGEP, 1908f, 604f, MLBOCKOBLGH);
		}
	}

	private void CCFJENHGIMN()
	{
		NGFJJLGBFGA();
		PJFGCMCKMJF.EPFKCOHPCAK();
	}

	private void HMKMGDMHGBG(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = FPECBPKHKOE.Count;
		int num = Singleton<GameVariables>.instance.LeaguePositionPromote(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.LOAOEHEJFJA(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE;
		JBAGAHBOICJ jBAGAHBOICJ = Singleton<GameVariables>.instance.LeaguePositionType(!flag, leagueTier, OKHCCAIPHEG, num, num2);
		int medalsBalance = FPECBPKHKOE[OKHCCAIPHEG - 0].medalsBalance;
		if (!flag)
		{
			if (OKHCCAIPHEG == 0)
			{
				GNCBNDEPGEP.text = Localization.Localize("fuseData");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(913f);
				MOEFDOJODKK.gameObject.SetActive(false);
			}
			else
			{
				int fFHHEHHFOKJ = FPECBPKHKOE[1].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ClientPrice");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1692f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("//");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
			}
		}
		else if (OKHCCAIPHEG == 1)
		{
			GNCBNDEPGEP.text = Localization.Localize("ShotFrequencyMinCannon");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1109f);
			MOEFDOJODKK.gameObject.SetActive(true);
		}
		else
		{
			switch (jBAGAHBOICJ)
			{
			case JBAGAHBOICJ.Stay:
			{
				int fFHHEHHFOKJ6 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 0;
				GNCBNDEPGEP.text = Localization.Localize("#Notifications# Received a with data id = {0}");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(631f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("0");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ6);
				break;
			}
			case JBAGAHBOICJ.Promote:
			{
				int num3 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
				if (OKHCCAIPHEG <= num3)
				{
					int fFHHEHHFOKJ4 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("WarArenaConfig");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(833f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("ID_CONFIRM_ERROR");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ4);
				}
				else
				{
					int fFHHEHHFOKJ5 = FPECBPKHKOE[num3 - 0].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("N");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1370f);
					MOEFDOJODKK.gameObject.SetActive(false);
					NBACBIFHAFM.text = Localization.Localize("Prefabs to go through: {0} + {1}");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ5);
				}
				break;
			}
			default:
				if (jBAGAHBOICJ == JBAGAHBOICJ.Stay)
				{
					int fFHHEHHFOKJ2 = FPECBPKHKOE[num - 0].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("ItemRarity_3");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1105f);
					MOEFDOJODKK.gameObject.SetActive(false);
					NBACBIFHAFM.text = Localization.Localize("ID_READYTIME");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ2);
				}
				else
				{
					int fFHHEHHFOKJ3 = FPECBPKHKOE[num2 - 1].medalsBalance - medalsBalance + 0;
					GNCBNDEPGEP.text = Localization.Localize("friend name");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(947f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("ID_STATE_OPPONENTDOESNTWANTREMATCH");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ3);
				}
				break;
			}
		}
		NKNLPNANBCK();
	}

	private void DADHMKMINHD()
	{
		GNCBNDEPGEP.text = string.Empty;
		GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1353f);
		MOEFDOJODKK.gameObject.SetActive(false);
		CACGACONKEB();
	}

	private void LNBJFNHAIKJ(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = FPECBPKHKOE.Count;
		int num = Singleton<GameVariables>.instance.OEMLPPKCBLA(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.ILBMNKFEOCL(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-96)).FLOATVALUE;
		JBAGAHBOICJ jBAGAHBOICJ = Singleton<GameVariables>.instance.LeaguePositionType(!flag, leagueTier, OKHCCAIPHEG, num, num2);
		int medalsBalance = FPECBPKHKOE[OKHCCAIPHEG - 1].medalsBalance;
		if (!flag)
		{
			if (OKHCCAIPHEG == 0)
			{
				GNCBNDEPGEP.text = Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED_TEXT");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(966f);
				MOEFDOJODKK.gameObject.SetActive(true);
			}
			else
			{
				int fFHHEHHFOKJ = FPECBPKHKOE[1].medalsBalance - medalsBalance + 0;
				GNCBNDEPGEP.text = Localization.Localize("ID_REWARD");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(205f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot accept player");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
			}
		}
		else if (OKHCCAIPHEG == 1)
		{
			GNCBNDEPGEP.text = Localization.Localize("ID_GUI_MESSAGEFORYOU");
			GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1510f);
			MOEFDOJODKK.gameObject.SetActive(true);
		}
		else
		{
			switch (jBAGAHBOICJ)
			{
			case JBAGAHBOICJ.Promote:
			{
				int fFHHEHHFOKJ6 = FPECBPKHKOE[1].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("GLM: RegisterOrLogin -  playerAccount == NULL");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1691f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("Spend_Gold_On_Card_Packs");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ6);
				break;
			}
			case JBAGAHBOICJ.Top:
			{
				int num3 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
				if (OKHCCAIPHEG <= num3)
				{
					int fFHHEHHFOKJ4 = FPECBPKHKOE[0].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("SnapColt");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1665f);
					MOEFDOJODKK.gameObject.SetActive(false);
					NBACBIFHAFM.text = Localization.Localize("LLCCAALEHGN");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ4);
				}
				else
				{
					int fFHHEHHFOKJ5 = FPECBPKHKOE[num3 - 1].medalsBalance - medalsBalance + 1;
					GNCBNDEPGEP.text = Localization.Localize("Leaderboard removed succesfully");
					GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1644f);
					MOEFDOJODKK.gameObject.SetActive(true);
					NBACBIFHAFM.text = Localization.Localize("ID_TURRETBUILDTIME");
					CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ5);
				}
				break;
			}
			case JBAGAHBOICJ.Stay:
			{
				int fFHHEHHFOKJ3 = FPECBPKHKOE[num - 0].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("ID_GUI_SQUADDEMOTION");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(1652f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("ID_CONFIRM_ERROR");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ3);
				break;
			}
			default:
			{
				int fFHHEHHFOKJ2 = FPECBPKHKOE[num2 - 7].medalsBalance - medalsBalance + 1;
				GNCBNDEPGEP.text = Localization.Localize("GooglePlay");
				GNCBNDEPGEP.transform.localPosition = GNCBNDEPGEP.transform.localPosition.ReplaceY(495f);
				MOEFDOJODKK.gameObject.SetActive(false);
				NBACBIFHAFM.text = Localization.Localize("{0}{1}");
				CDAFCKNCFMB.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ2);
				break;
			}
			}
		}
		KAHFDPDNGAB();
	}

	[CompilerGenerated]
	private void BHBGEHOEFIA(UITweener MGDJMGHCAAI)
	{
		if (LeagueArcManager.instance.GetWasDataUpdated())
		{
			APEPEHJLCLI(LeagueArcManager.instance.GetCurrentData(), LeagueArcManager.instance.GetCurrentPlayers(), true);
		}
		else
		{
			GHMKCNFAOJB();
		}
		Vector3 pos = GBFNBEOKLDG.transform.localPosition.ReplaceY(4f);
		TweenPosition.Begin(GBFNBEOKLDG, 0.5f, pos).onFinished = null;
	}
}

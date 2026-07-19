using System;
using System.Collections.Generic;
using UnityEngine;

public class LeagueDialog : GuiElementSingle<LeagueDialog>, PAIIOKBBHBC
{
	private enum NKHJBLBAAEB
	{
		EnteredNormalLeague = 0,
		EnteredNormalLeagueFirstTime = 1,
		EnteredBeginnersLeague = 2,
		FinishedBeginnerLeagues = 3
	}

	[Header("Core")]
	public UILabel NFHEAEKGHNJ;

	[Header("Normal League")]
	public GameObject FINMIFPAMOB;

	public UILabel MOJBNLMNMDB;

	public UITexture OFBKFOHFJFA;

	public UILabel KBKEOJDDMEH;

	public UISprite HPFONLBPBCO;

	public UISprite PAAEHCPLNKK;

	public UILabel ODAOBKCLCMK;

	public UILabel GNMEBGHHPLF;

	[Header("Normal League First Time")]
	public GameObject GBHHKOGMNGB;

	public UILabel EJMOEOOKIGD;

	public LeagueArcGuiElement BDGGHODPFMA;

	public UITable NAMIHDBDELC;

	public UILabel COFHPEDAOOM;

	public UILabel GGLEFIMCBPF;

	public UILabel ECDBKOGDDBF;

	public UISprite FFNADCNPFIM;

	public UISprite FNMPGJDGHDM;

	public UILabel OLAJJEJPFGF;

	public UILabel ADDNGFEDJEM;

	[Header("Beginners League")]
	public GameObject PKNHNJMAOKG;

	public UILabel EBBOGIMHNAE;

	public UITexture ENHAMAGNOPE;

	public UITable LGAFGHAJAPE;

	public UITable MAMIGNILNPH;

	public UILabel[] FCIHCKJPIJP;

	public UILabel ONLHNMMEOOI;

	public UISprite EPJFKEGIPGB;

	public UISprite JFFBEAMIANF;

	public UILabel AHIBCBOKCIO;

	public UISprite DEEGLPABKBM;

	[Header("Finished Beginners League")]
	public GameObject FPEAMLHNKEL;

	public UITexture[] KDKLMCLOFLB;

	public UISprite EFIEBOAFJBM;

	public UILabel DLDONNODCCP;

	[Header("Bottom")]
	public GameObject DMPBNBPBDFD;

	public UILabel HLPPHFIEGBL;

	private NKHJBLBAAEB GPABKIOEGKM;

	private League KNNEGKLGBKO;

	private int DFBJMBEOOIE;

	private Dictionary<NKHJBLBAAEB, string> LCKFMNNBHDP = new Dictionary<NKHJBLBAAEB, string>
	{
		{
			NKHJBLBAAEB.EnteredNormalLeague,
			"ID_YOUVEENTEREDALEAGUE"
		},
		{
			NKHJBLBAAEB.EnteredNormalLeagueFirstTime,
			"ID_YOUVEENTEREDALEAGUE"
		},
		{
			NKHJBLBAAEB.EnteredBeginnersLeague,
			"ID_YOUVEENTEREDALEAGUE"
		},
		{
			NKHJBLBAAEB.FinishedBeginnerLeagues,
			"ID_CONGRATULATIONSROOKIE"
		}
	};

	private void KOACKJOKJNP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public void PJAAGHEPGGH(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = (GHFOEKMLDPI ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1484f);
	}

	public virtual void GEKFHJKIAMF()
	{
		KPHHBHIMPLH(DMPBNBPBDFD);
	}

	public void DEJOLGKMJIK(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredNormalLeague;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1866f);
	}

	public virtual void BGDBMCDGBGE()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	private void NKPDHCKFJPK(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void MOBMDLNHDKL()
	{
		LGAFGHAJAPE.repositionNow = true;
	}

	public void MHKEKOLAHDL(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeague : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1122f);
	}

	public virtual void GKPGHCLMCDK()
	{
		KOACKJOKJNP(DMPBNBPBDFD);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	private void JLPININPJGC()
	{
		LGAFGHAJAPE.repositionNow = true;
	}

	private void LBBBPJLKEPA()
	{
		LGAFGHAJAPE.repositionNow = true;
	}

	public void MPMIGJOEPFG(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = NKHJBLBAAEB.FinishedBeginnerLeagues;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 720f);
	}

	public virtual void HPJDOALKOGF()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)5);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)8);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 1885f, 500f, -9);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)6) ? "Battle_Performance" : "menu-sidetab-invite");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array5 = new object[6];
			array5[1] = Colours.stringBlue;
			array5[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array5[3] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("173432c2", array5);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>(" >" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (272f - (num5 + 37f)) / 1756f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array3 = new object[0];
			array3[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("PlayerData", array3);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array4 = new object[0];
			array4[0] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("boxOpen", array4);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.NoLeague) ? "GameCenterId" : "0");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (655f - (num4 + 164f)) / 196f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[1];
			array2[0] = Colours.stringBlue;
			array2[1] = text2;
			array2[5] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("Scripts search finished.", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 421f, 1074f, 98);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "Vip" || currentLanguage == "com.tune.unityutils.TuneUnityFirstPlaylistListener")
			{
				for (int i = 1; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(996f, 1113f, 1071f);
				}
			}
			MAMIGNILNPH.repositionNow = true;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("ID_ARENALOST" + text);
			ONLHNMMEOOI.text = Localization.LocalizeFormat("VipRewardForDay", MEJMLNDFDBP.GMIPFLIEOHD(num), text3, null);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 1285f, 65f, -149);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("dump", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1501f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 1695f;
			float val = 1051f * (num2 + 344f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("ID_GETFORPROMOTION2" + Singleton<GameVariables>.instance.CHOAELALEIC(0));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("ID_READYTIME" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[1];
			array[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("ID_INSTANTBATTLEHINT1", array);
			break;
		}
		}
	}

	private void KPHHBHIMPLH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void LBIJJNEOELO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(MOBMDLNHDKL));
	}

	private void OPHIKKAFEEJ()
	{
		LGAFGHAJAPE.repositionNow = false;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(IJDCKBFJMDO));
	}

	public virtual void EJLHAPDGBCL()
	{
		NKPDHCKFJPK(DMPBNBPBDFD);
	}

	private void IJDCKBFJMDO()
	{
		LGAFGHAJAPE.repositionNow = true;
	}

	public void HKGMGDCMOLI(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 822f);
	}

	public virtual void IOLNONPHCMM()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == NKHJBLBAAEB.FinishedBeginnerLeagues);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 193f, 1471f, -20);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)4) ? "SetHitByUnit , " : "REGISTER PREDEFINED ASSIGNMENT EVENT COMPLETED");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array6 = new object[6];
			array6[0] = Colours.stringBlue;
			array6[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array6[7] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("GetGameData(", array6);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("GameType" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (1909f - (num5 + 713f)) / 621f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array4 = new object[1];
			array4[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("0", array4);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array5 = new object[1];
			array5[1] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("ID_NUMMEMBERS", array5);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Bronze2) ? "OK" : "NextWithdraw");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (409f - (num4 + 1137f)) / 549f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 1);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[4];
			array2[0] = Colours.stringBlue;
			array2[1] = text2;
			array2[7] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat(" not found!", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 945f, 1160f, -144);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "ArenaUpcomingMessage" || currentLanguage == "totalMem")
			{
				for (int i = 0; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(412f, 1524f, 377f);
				}
			}
			MAMIGNILNPH.repositionNow = true;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("{0} {1}{2}" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array3 = new object[7];
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array3[0] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("weaponDelivery", array3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 1248f, 1419f, -89);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("nextSquadWars", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1156f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 1120f;
			float val = 1655f * (num2 + 1458f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("Overtime_Was_Already_Explained" + Singleton<GameVariables>.instance.CHOAELALEIC(7));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("champion" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[1];
			array[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("{0}\u00a0{1}", array);
			break;
		}
		}
	}

	public virtual void LFJGHLNJPHL()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)7);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 621f, 1309f, 90);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)5) ? "Beanstalk: On Update device token" : "{0} {1}/{2} {3}");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array5 = new object[3];
			array5[0] = Colours.stringBlue;
			array5[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array5[0] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("Buy_Weapon_At_Rank_Gold", array5);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("{0}98 FORGOT SPAWN" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (1619f - (num5 + 1886f)) / 473f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			EJMOEOOKIGD.text = Localization.LocalizeFormat("withAgencyId", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array4 = new object[0];
			array4[1] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("Total_Matchmaking_Battles", array4);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Bronze2) ? "damage" : "Cards");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (226f - (num4 + 1593f)) / 979f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 0);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[3];
			array2[1] = Colours.stringBlue;
			array2[0] = text2;
			array2[4] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("SquadMembers", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1366f, 1679f, 138);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "dec" || currentLanguage == "ID_WARSHOP_GOLD")
			{
				for (int i = 1; i < FCIHCKJPIJP.Length; i += 0)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(1136f, 465f, 812f);
				}
			}
			MAMIGNILNPH.repositionNow = false;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("ID_NEWLOOTBOXINBATTLES" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array3 = new object[3];
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array3[1] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("_MAX_", array3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 1544f, 362f, -173);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("engineer_run", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1904f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 1420f;
			float val = 628f * (num2 + 275f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("ArenaBattleEnd" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(6));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("weapon" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[0];
			array[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("SERVICE_MISSING_PERMISSION", array);
			break;
		}
		}
	}

	public virtual void IFLHOKBNJPH()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	private void KCOIBDOCFHN()
	{
		LGAFGHAJAPE.repositionNow = false;
	}

	public void AILFNJPKNCN(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)5;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 11f);
	}

	private void HFKLDKIEBGK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void BAAOGDMJCLK()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredBeginnersLeague);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)4);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 1908f, 1357f, 157);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)6) ? "{0}{1}[-] {2}/[-] {3}" : "Medals");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array6 = new object[4];
			array6[1] = Colours.stringBlue;
			array6[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array6[2] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("requestId", array6);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (1576f - (num5 + 9f)) / 625f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array4 = new object[0];
			array4[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("Medals/", array4);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array5 = new object[1];
			array5[1] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("FALSE", array5);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Silver1) ? "rocket" : "InAppHandlerIos: Need add new bundle");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1353f - (num4 + 1011f)) / 33f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE + 0);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[1];
			array2[0] = Colours.stringBlue;
			array2[0] = text2;
			array2[7] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("ID_WARNING_SERVERTIMEDOUT", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 32f, 1260f, 94);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "Beanstalk: Log Sent, Id = " || currentLanguage == "Directory \"{0}\" does not exists")
			{
				for (int i = 1; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(1672f, 965f, 809f);
				}
			}
			MAMIGNILNPH.repositionNow = true;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("ID_MAXSTAT" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array3 = new object[7];
			array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array3[0] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("FLOATVALUE", array3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 1013f, 1114f, -124);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("Dictionary created/cleared.\n", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1607f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 575f;
			float val = 851f * (num2 + 1773f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[1].mainTexture = Resources.Load<Texture>("Timestamp" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(5));
			KDKLMCLOFLB[1].mainTexture = Resources.Load<Texture>("connected" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[0];
			array[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("ID_REMINDER_UNITUPGRADEREADY", array);
			break;
		}
		}
	}

	public void BPEKJGNEEOA(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = NKHJBLBAAEB.FinishedBeginnerLeagues;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 247f);
	}

	public void EHHPMHILOBL(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)6;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1512f);
	}

	private void GDKNMINIJMP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void ILCKGHGDDJA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(MOBMDLNHDKL));
	}

	public void NAPDNCPIKNB(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = (GHFOEKMLDPI ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 349f);
	}

	private void PGBAOGEAKDP()
	{
		LGAFGHAJAPE.repositionNow = false;
	}

	public virtual void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BEFOEFGDOOE));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(OPHIKKAFEEJ));
	}

	public virtual void DOPDLKMCFMA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HFKLDKIEBGK));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(OPHIKKAFEEJ));
	}

	private void IDFEIDBGBKJ()
	{
		LGAFGHAJAPE.repositionNow = false;
	}

	private void DJJILCKNOFB()
	{
		LGAFGHAJAPE.repositionNow = false;
	}

	public void NNDJNNGIIAA(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1833f);
	}

	private void BEFOEFGDOOE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void FOBMALIKIFB()
	{
		LGAFGHAJAPE.repositionNow = true;
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	public virtual void CMFFEECPAED()
	{
		KOACKJOKJNP(DMPBNBPBDFD);
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	public void ABMIJIINFBH(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)7;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 959f);
	}

	public virtual void JMNHKBNACBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BEFOEFGDOOE));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(IJDCKBFJMDO));
	}

	public void BDBAHLOMBIL(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)7;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1977f);
	}

	public void NPMMKLFJMON(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredNormalLeague;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 113f);
	}

	public void KEBOKGAFBDB(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = NKHJBLBAAEB.FinishedBeginnerLeagues;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 83f);
	}

	public void CMMABNMFOFM(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.FinishedBeginnerLeagues;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1399f);
	}

	public void KKKOBJMJLCA(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 583f);
	}

	public virtual void JNPMCOCIICG()
	{
		BEFOEFGDOOE(DMPBNBPBDFD);
	}

	public override void OIMKKAHOEKO()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void GLOINJNJBCP()
	{
		base.OIMKKAHOEKO();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	public virtual void OEDLHCLCKEO()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)4);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)5);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 940f, 569f, -63);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)4) ? "ID_CONFIRM_JOININGSQUAD_TEXT" : "FuseSDK instance not initialized. Awake may not have been called.");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array3 = new object[0];
			array3[0] = Colours.stringBlue;
			array3[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array3[6] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("MONO HEAP SIZE: ", array3);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("WFX_BImpact" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (1434f - (num5 + 1051f)) / 1810f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			EJMOEOOKIGD.text = Localization.LocalizeFormat("de", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = true;
			COFHPEDAOOM.text = Localization.LocalizeFormat("SquadKickedFrom", MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO)));
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Silver3) ? "ADD GOOGLE PLAY ACCOUNT WITH " : "null");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1595f - (num4 + 990f)) / 605f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OMLHMLGCOBD(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array = new object[3];
			array[1] = Colours.stringBlue;
			array[1] = text2;
			array[2] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("dump", array);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1046f, 1974f, 7);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "MISSING PREFAB IN OBJECT POOL: " || currentLanguage == "ID_REMINDER_SUITUPSOLDIER")
			{
				for (int i = 0; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(308f, 1800f, 943f);
				}
			}
			MAMIGNILNPH.repositionNow = true;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("StartTime" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array2 = new object[1];
			array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array2[0] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("LeagueId", array2);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 154f, 688f, -11);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("UtcOffset", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 109f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 795f;
			float val = 1590f * (num2 + 507f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>(" set league " + Singleton<GameVariables>.instance.BeginnersLeagueIcon(3));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("game-card-ico-streakboost-full" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			DLDONNODCCP.text = Localization.LocalizeFormat("NumberOfMission", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			break;
		}
	}

	public virtual void NEECLAOCOKD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDKNMINIJMP));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(HABDNBPCFJD));
	}

	private void JEFIPPNIJLI()
	{
		LGAFGHAJAPE.repositionNow = false;
	}

	public virtual void BEAOKIEIEIM()
	{
		GKOHJGFKPAH(DMPBNBPBDFD);
	}

	public void DNOIOCBAAFE(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1409f);
	}

	public void DIIJHIMHDHK(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeague : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 259f);
	}

	public void ShowEnterToNormalLeague(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = (GHFOEKMLDPI ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(DMPBNBPBDFD);
	}

	public override void InitGUIValues()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredBeginnersLeague);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == NKHJBLBAAEB.FinishedBeginnerLeagues);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 87f, 42f, 1340);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != NKHJBLBAAEB.FinishedBeginnerLeagues) ? "ID_AWESOME" : "ID_CONTINUE");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			MOJBNLMNMDB.text = Localization.LocalizeFormat("ID_CONGRATULATIONSPLACEDINLEAGUE", Colours.stringBlue, GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1, Colours.stringWhite);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (714f - (num5 + 40f)) / 2f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			EJMOEOOKIGD.text = Localization.LocalizeFormat("ID_CONGRATULATIONSMOVEDTO", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = true;
			COFHPEDAOOM.text = Localization.LocalizeFormat("ID_TONORMALLEAGUEHINT2", MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO)));
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Silver3) ? "ID_TONORMALLEAGUEHINT3SILVER" : "ID_TONORMALLEAGUEHINT3BRONZE");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (714f - (num4 + 40f)) / 2f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 1);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			EBBOGIMHNAE.text = Localization.LocalizeFormat("ID_CONGRATULATIONSPLACEDINLEAGUE", Colours.stringBlue, text2, Colours.stringWhite);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 47f, 20f, 1340);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "ru" || currentLanguage == "fr")
			{
				for (int i = 0; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(26f, 26f, 1f);
				}
			}
			MAMIGNILNPH.repositionNow = true;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("Medals/" + text);
			ONLHNMMEOOI.text = Localization.LocalizeFormat("ID_XMEDALSTOADVANCETOY", MEJMLNDFDBP.GMIPFLIEOHD(num), text3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 37f, 20f, 650);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("{0} [9A9999]/[0BBCFF] {1}", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 2f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 2f;
			float val = -1f * (num2 + 18f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("Medals/" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(3));
			KDKLMCLOFLB[1].mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			DLDONNODCCP.text = Localization.LocalizeFormat("ID_PLAYBATTLETOENTERBRONZELEAGUE", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			break;
		}
	}

	public GuiElement GBCEJBCGGHP()
	{
		return this;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	public virtual void DJMCADMNEDH()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)6);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == NKHJBLBAAEB.FinishedBeginnerLeagues);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 1709f, 868f, -111);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)5) ? "GameCenterProvider function OnAuthenticated() called => GC: Authenticated with " : "ID_MAX");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array5 = new object[2];
			array5[1] = Colours.stringBlue;
			array5[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array5[4] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("Scripts", array5);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("ID_GETTOAVOIDRELEGATION2" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (508f - (num5 + 842f)) / 910f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array3 = new object[0];
			array3[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("ID_TUTORIAL_PROGRESS_COVER", array3);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array4 = new object[0];
			array4[0] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("false", array4);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Silver1) ? "_MatCap" : "GameCenterId");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1789f - (num4 + 183f)) / 508f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OMLHMLGCOBD(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 1);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array = new object[7];
			array[0] = Colours.stringBlue;
			array[0] = text2;
			array[6] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("SetHitByUnitRPC", array);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1906f, 192f, 80);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "OK" || currentLanguage == "ID_GUI_INVITETOFIGHT")
			{
				for (int i = 1; i < FCIHCKJPIJP.Length; i += 0)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(1969f, 375f, 1668f);
				}
			}
			MAMIGNILNPH.repositionNow = false;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>(" error (no ColumnNames)" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array2 = new object[1];
			array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array2[1] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("country", array2);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 206f, 1963f, 105);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("CheckDisable", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 35f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 237f;
			float val = 36f * (num2 + 1605f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("On Debug Add Level" + Singleton<GameVariables>.instance.CHOAELALEIC(2));
			KDKLMCLOFLB[1].mainTexture = Resources.Load<Texture>(" Special " + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			DLDONNODCCP.text = Localization.LocalizeFormat("http://", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			break;
		}
	}

	private void HABDNBPCFJD()
	{
		LGAFGHAJAPE.repositionNow = true;
	}

	public virtual void HKKHHAKOFHL()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)8);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)4);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 1216f, 1802f, -61);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)7) ? "Beanstalk: On Remove Login" : "S");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array5 = new object[3];
			array5[1] = Colours.stringBlue;
			array5[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array5[6] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("Has Gc Name!", array5);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("OpponentRank" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (1073f - (num5 + 1787f)) / 679f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array3 = new object[0];
			array3[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("PlayerLeagueProcessing", array3);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array4 = new object[0];
			array4[0] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("ID_CONFIRM_SQUADFULL_TEXT", array4);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Bronze1) ? "UnitReadyForPromotion {0} {1}" : "flawless");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1093f - (num4 + 1231f)) / 1906f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 0);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array = new object[8];
			array[0] = Colours.stringBlue;
			array[0] = text2;
			array[3] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1367f, 41f);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "ID_JOINSQUADDESCRIPTION3" || currentLanguage == "antialiasing")
			{
				for (int i = 0; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(77f, 179f, 740f);
				}
			}
			MAMIGNILNPH.repositionNow = false;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("ID_PHASECLOSED" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array2 = new object[0];
			array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array2[0] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("special", array2);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 778f, 1205f, 33);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format(" |", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1284f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 1467f;
			float val = 65f * (num2 + 842f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
			KDKLMCLOFLB[1].mainTexture = Resources.Load<Texture>("21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----" + Singleton<GameVariables>.instance.CHOAELALEIC(2));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("1" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			DLDONNODCCP.text = Localization.LocalizeFormat(" ", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			break;
		}
	}

	public void JKCLDFNOKLO(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 513f);
	}

	public void HNCOMPDEEFL(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredNormalLeagueFirstTime;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1880f);
	}

	public void CHOBKKEDHJF(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)7;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 657f);
	}

	public virtual void MHIFDHGPDCK()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)5);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredBeginnersLeague);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 1529f, 1381f, -166);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != NKHJBLBAAEB.FinishedBeginnerLeagues) ? "VipReward1" : "SessionManager: Skipping sessions update. Device not registered or is in tutorial");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array4 = new object[5];
			array4[1] = Colours.stringBlue;
			array4[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array4[5] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("[Crashlytics Init] CrashlyticsService->Ctor->Initialize->Before", array4);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("ammo" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (375f - (num5 + 772f)) / 1760f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OMLHMLGCOBD(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			EJMOEOOKIGD.text = Localization.LocalizeFormat("Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}.", GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array3 = new object[0];
			array3[1] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("Load assetBundle which is not cached !!!: ", array3);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Bronze2) ? "ID_WARNING_FAILTORESTORE" : "menu-event-gift");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1374f - (num4 + 1319f)) / 1649f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OMLHMLGCOBD(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 0);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 1);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[4];
			array2[0] = Colours.stringBlue;
			array2[0] = text2;
			array2[5] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("SquadPoints", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 371f, 841f, 8);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "Humvee" || currentLanguage == ", action already scheduled")
			{
				for (int i = 1; i < FCIHCKJPIJP.Length; i += 0)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(505f, 1535f, 1044f);
				}
			}
			MAMIGNILNPH.repositionNow = false;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("Tutorial_Step_Complete" + text);
			ONLHNMMEOOI.text = Localization.LocalizeFormat("IOAJFNMOGOD", MEJMLNDFDBP.GMIPFLIEOHD(num), text3, null, null, null, null);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 1013f, 1068f, 59);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("ItemsOwned_Rarity_4", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 523f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 428f;
			float val = 143f * (num2 + 1629f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("Weapon_Upgrade" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(4));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("FacebookId" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[0];
			array[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("Country", array);
			break;
		}
		}
	}

	public virtual void LKDFHKIAKAB()
	{
		GDKNMINIJMP(DMPBNBPBDFD);
	}

	public void CKFJBCBALDA(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.FinishedBeginnerLeagues;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 209f);
	}

	public GuiElement EBKJBKMFEKE()
	{
		return this;
	}

	public GuiElement HMLFKOLADFB()
	{
		return this;
	}

	public void MEAAGBEBNJA(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredBeginnersLeague;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1104f);
	}

	public void AJKADMBBBNC(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)7;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 679f);
	}

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	public void ShowEnterToBeginnersLeague(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredBeginnersLeague;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void LAIEEOIDANJ(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeague : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 386f);
	}

	public virtual void LMNNNHJKMFP()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)7);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)7);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 778f, 1773f, -6);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)6) ? "LeagueId" : "リトライ");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array6 = new object[3];
			array6[0] = Colours.stringBlue;
			array6[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array6[7] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("TuneListener trackerDidEnqueueUrl: ", array6);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("menu-assignments-type-crate" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (1556f - (num5 + 1974f)) / 1408f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.HNGCHCCBCBC(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OMLHMLGCOBD(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array4 = new object[0];
			array4[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("C2", array4);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array5 = new object[0];
			array5[1] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("ID_COMPLETEALLTENSTARTERASSIGNMENTS", array5);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Silver1) ? "{0}   {1}./{2}   {3}" : "}");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1039f - (num4 + 1594f)) / 1468f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OMLHMLGCOBD(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 0);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.JEEKKAONLOG(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[3];
			array2[0] = Colours.stringBlue;
			array2[0] = text2;
			array2[2] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat(";", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1497f, 1065f, 186);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "SoftBody" || currentLanguage == "/")
			{
				for (int i = 0; i < FCIHCKJPIJP.Length; i += 0)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(739f, 732f, 1004f);
				}
			}
			MAMIGNILNPH.repositionNow = true;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("FinishChoosingCardsRPC" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array3 = new object[6];
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array3[1] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("Price", array3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 186f, 1181f, 59);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("Skill", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1900f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 1001f;
			float val = 132f * (num2 + 698f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("!!!UNDER TABLE!!! " + Singleton<GameVariables>.instance.CHOAELALEIC(0));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("Buy_Weapon_Upgrade" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[0];
			array[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("{0} {1}", array);
			break;
		}
		}
	}

	public GuiElement DPPOMEPDHEK()
	{
		return this;
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
		UITable mAMIGNILNPH = MAMIGNILNPH;
		mAMIGNILNPH.onReposition = (UITable.OnReposition)Delegate.Combine(mAMIGNILNPH.onReposition, new UITable.OnReposition(IDFEIDBGBKJ));
	}

	public void PLFFCCMOCEC(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 751f);
	}

	public void ShowFinishedBeginnersLeague(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.FinishedBeginnerLeagues;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void MFPDIGEDLJG(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredNormalLeague;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 715f);
	}

	public virtual void JIHMFJANIHI()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredBeginnersLeague);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)4);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 1873f, 806f, 67);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != (NKHJBLBAAEB)6) ? "-{0}-{1}" : "ID_GUI_REPORTABUSE_LISTITEM4");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array6 = new object[3];
			array6[0] = Colours.stringBlue;
			array6[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array6[7] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("Take player life!", array6);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("ID_GOLD" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (397f - (num5 + 1758f)) / 1353f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array4 = new object[0];
			array4[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("damage", array4);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array5 = new object[0];
			array5[0] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("stand_up_crawl", array5);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Bronze3) ? "ID_HOURSAGO" : "ID_CONFIRM_JOININGSQUAD");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1034f - (num4 + 892f)) / 1314f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(DFBJMBEOOIE + 0);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 1);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[3];
			array2[1] = Colours.stringBlue;
			array2[1] = text2;
			array2[3] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("daily reward claimed", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1831f, 1207f, -81);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "opponentState.willHide = true" || currentLanguage == "ServerPrice")
			{
				for (int i = 0; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(698f, 1824f, 472f);
				}
			}
			MAMIGNILNPH.repositionNow = false;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("warbucks" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array3 = new object[1];
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array3[0] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("ID_WARNING_CANTSENDINVITE", array3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 794f, 1899f, 48);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("_#", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 1069f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 995f;
			float val = 1488f * (num2 + 871f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("antialiasing" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(1));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("ID_CONFIRM_JOININGSAMESQUAD" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[0];
			array[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("BattleId", array);
			break;
		}
		}
	}

	public void EMDNHHKDAED(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)8;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1315f);
	}

	public void JOFGADAAMDM(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)7;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 493f);
	}

	public virtual void MMBMOHAFCHG()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	public virtual void GBPEJMFMBJM()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
	}

	public virtual void JKPBJPFBAFJ()
	{
		GKOHJGFKPAH(DMPBNBPBDFD);
	}

	public virtual void KMCKIIFEKCA()
	{
		FINMIFPAMOB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeagueFirstTime);
		GBHHKOGMNGB.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		PKNHNJMAOKG.SetActive(GPABKIOEGKM == NKHJBLBAAEB.EnteredNormalLeague);
		FPEAMLHNKEL.SetActive(GPABKIOEGKM == (NKHJBLBAAEB)6);
		NFHEAEKGHNJ.text = Localization.Localize(LCKFMNNBHDP[GPABKIOEGKM]);
		MEJMLNDFDBP.COCBCFKJOJE(NFHEAEKGHNJ, 381f, 1855f, 190);
		HLPPHFIEGBL.text = Localization.Localize((GPABKIOEGKM != NKHJBLBAAEB.EnteredNormalLeagueFirstTime) ? "ID_CONFIRM_ERROR" : "./Assets/Prefabs");
		switch (GPABKIOEGKM)
		{
		case NKHJBLBAAEB.EnteredNormalLeague:
		{
			UILabel mOJBNLMNMDB = MOJBNLMNMDB;
			object[] array6 = new object[6];
			array6[1] = Colours.stringBlue;
			array6[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			array6[4] = Colours.stringWhite;
			mOJBNLMNMDB.text = Localization.LocalizeFormat("FacebookPassword", array6);
			OFBKFOHFJFA.mainTexture = Resources.Load<Texture>("#AccoutCheck# missing ID from server" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			float num5 = KBKEOJDDMEH.relativeSize.x * KBKEOJDDMEH.transform.localScale.x;
			float val3 = (366f - (num5 + 182f)) / 60f;
			HPFONLBPBCO.transform.localScale = HPFONLBPBCO.transform.localScale.ReplaceX(val3);
			PAAEHCPLNKK.transform.localScale = PAAEHCPLNKK.transform.localScale.ReplaceX(val3);
			ODAOBKCLCMK.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.FPBNDHGOINI(KNNEGKLGBKO));
			GNMEBGHHPLF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredNormalLeagueFirstTime:
		{
			UILabel eJMOEOOKIGD = EJMOEOOKIGD;
			object[] array4 = new object[0];
			array4[1] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			eJMOEOOKIGD.text = Localization.LocalizeFormat("repairBotHP", array4);
			BDGGHODPFMA.SetTutorialLook();
			NAMIHDBDELC.repositionNow = false;
			UILabel cOFHPEDAOOM = COFHPEDAOOM;
			object[] array5 = new object[0];
			array5[0] = MEJMLNDFDBP.JJBMMICPIIG(Singleton<GameVariables>.instance.LeagueGoUpPercent(KNNEGKLGBKO));
			cOFHPEDAOOM.text = Localization.LocalizeFormat("MessageId", array5);
			GGLEFIMCBPF.text = Localization.Localize((KNNEGKLGBKO >= League.Gold3) ? "_TintColor" : "*.prefab");
			float num4 = ECDBKOGDDBF.relativeSize.x * ECDBKOGDDBF.transform.localScale.x;
			float val2 = (1453f - (num4 + 1489f)) / 1661f;
			FFNADCNPFIM.transform.localScale = FFNADCNPFIM.transform.localScale.ReplaceX(val2);
			FNMPGJDGHDM.transform.localScale = FNMPGJDGHDM.transform.localScale.ReplaceX(val2);
			OLAJJEJPFGF.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(KNNEGKLGBKO));
			ADDNGFEDJEM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.OPAPBENHGMO(KNNEGKLGBKO));
			break;
		}
		case NKHJBLBAAEB.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(DFBJMBEOOIE + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(DFBJMBEOOIE + 0);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(DFBJMBEOOIE);
			float fillAmount = (float)medalsBalance / (float)num;
			UILabel eBBOGIMHNAE = EBBOGIMHNAE;
			object[] array2 = new object[7];
			array2[0] = Colours.stringBlue;
			array2[1] = text2;
			array2[1] = Colours.stringWhite;
			eBBOGIMHNAE.text = Localization.LocalizeFormat("ID_OVERTIMEKILL", array2);
			MEJMLNDFDBP.COCBCFKJOJE(EBBOGIMHNAE, 1726f, 1972f, -128);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "\n" || currentLanguage == "{0} Rookie {1}")
			{
				for (int i = 1; i < FCIHCKJPIJP.Length; i++)
				{
					FCIHCKJPIJP[i].transform.localScale = new Vector3(1960f, 279f, 1467f);
				}
			}
			MAMIGNILNPH.repositionNow = false;
			ENHAMAGNOPE.mainTexture = Resources.Load<Texture>("ID_CREATE" + text);
			UILabel oNLHNMMEOOI = ONLHNMMEOOI;
			object[] array3 = new object[0];
			array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(num);
			array3[1] = text3;
			oNLHNMMEOOI.text = Localization.LocalizeFormat("]", array3);
			MEJMLNDFDBP.COCBCFKJOJE(ONLHNMMEOOI, 1476f, 1063f, 162);
			EPJFKEGIPGB.fillAmount = fillAmount;
			AHIBCBOKCIO.text = string.Format("N", medalsBalance, num);
			float num2 = JFFBEAMIANF.transform.localScale.x / 732f;
			float num3 = AHIBCBOKCIO.relativeSize.x * AHIBCBOKCIO.transform.localScale.x / 1650f;
			float val = 791f * (num2 + 91f + num3);
			JFFBEAMIANF.transform.localPosition = JFFBEAMIANF.transform.localPosition.ReplaceX(val);
			DEEGLPABKBM.spriteName = spriteName;
			break;
		}
		case NKHJBLBAAEB.FinishedBeginnerLeagues:
		{
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("Too big response from server, Action: {0} Size: {1}kB" + Singleton<GameVariables>.instance.CHOAELALEIC(3));
			KDKLMCLOFLB[0].mainTexture = Resources.Load<Texture>("Title" + GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2);
			EFIEBOAFJBM.spriteName = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value2;
			UILabel dLDONNODCCP = DLDONNODCCP;
			object[] array = new object[0];
			array[0] = GameVariables.CAOGFCFGFPD[KNNEGKLGBKO].Value1;
			dLDONNODCCP.text = Localization.LocalizeFormat("forever", array);
			break;
		}
		}
	}

	public void HHENJNDKAMG(League NJFHKOHJNAG)
	{
		GPABKIOEGKM = NKHJBLBAAEB.EnteredBeginnersLeague;
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 664f);
	}

	public void KBONHDFEOED(League NJFHKOHJNAG, bool GHFOEKMLDPI)
	{
		GPABKIOEGKM = ((!GHFOEKMLDPI) ? NKHJBLBAAEB.EnteredNormalLeagueFirstTime : NKHJBLBAAEB.EnteredNormalLeague);
		KNNEGKLGBKO = NJFHKOHJNAG;
		Singleton<GuiManager>.instance.ShowDialog(this, 1548f);
	}

	public virtual void GHNIJJKDAJH()
	{
		base.OIMKKAHOEKO();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	public void FEPMIHIAGNE(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)8;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 166f);
	}

	public virtual void AHDJEJIKCAB()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[1].mainTexture = null;
	}

	public void GPOEJMHKIJK(int HNEFOLPHMHK)
	{
		GPABKIOEGKM = (NKHJBLBAAEB)8;
		DFBJMBEOOIE = HNEFOLPHMHK;
		Singleton<GuiManager>.instance.ShowDialog(this, 38f);
	}

	public virtual void MFBOBBCJLOD()
	{
		base.DoAfterHide();
		ENHAMAGNOPE.mainTexture = null;
		OFBKFOHFJFA.mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
		KDKLMCLOFLB[0].mainTexture = null;
	}
}

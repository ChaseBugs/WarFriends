using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class LeagueContent : Core_BaseScript
{
	public enum NKHJBLBAAEB
	{
		Header = 0,
		Player = 1,
		HeaderReward = 2,
		HeaderNoReward = 3
	}

	public class KJNEDPOJJOC
	{
		public JBAGAHBOICJ AHHJKNHKCCI;

		public NKHJBLBAAEB FJLBLLLEELD;

		public League DMHLCPCLECE;

		public League NENPBAAELDJ;

		public int EOHOJBOGNAO;

		public int KGONOPCNKLM;

		public int OKHCCAIPHEG;

		public DatabasePlayer KHLGDCHJJPB;

		public int MPHCNMDIPAI;

		public KJNEDPOJJOC(JBAGAHBOICJ JEPKMKDMDFE, NKHJBLBAAEB KPICOKPHMIC, int MOEMPHPNBLM)
		{
			AHHJKNHKCCI = JEPKMKDMDFE;
			FJLBLLLEELD = KPICOKPHMIC;
			EOHOJBOGNAO = MOEMPHPNBLM;
		}

		public KJNEDPOJJOC(JBAGAHBOICJ JEPKMKDMDFE, NKHJBLBAAEB KPICOKPHMIC, int ADOEFHHJOAJ, League CGHLINPNGEC, League BELCPODBMBE, int MDOPFNNFLFB, int HDDHJNKCEMH)
		{
			AHHJKNHKCCI = JEPKMKDMDFE;
			FJLBLLLEELD = KPICOKPHMIC;
			KGONOPCNKLM = ADOEFHHJOAJ;
			NENPBAAELDJ = CGHLINPNGEC;
			DMHLCPCLECE = BELCPODBMBE;
			MPHCNMDIPAI = MDOPFNNFLFB;
			OKHCCAIPHEG = HDDHJNKCEMH;
		}

		public KJNEDPOJJOC(JBAGAHBOICJ JEPKMKDMDFE, NKHJBLBAAEB KPICOKPHMIC, DatabasePlayer NMDBNHBDMJO, int MDOPFNNFLFB)
		{
			AHHJKNHKCCI = JEPKMKDMDFE;
			FJLBLLLEELD = KPICOKPHMIC;
			KHLGDCHJJPB = NMDBNHBDMJO;
			MPHCNMDIPAI = MDOPFNNFLFB;
		}
	}

	private sealed class HAJEIGIFBOO
	{
		internal bool PJIEFMBDLBE;

		internal LeagueContent BJGCPDNMHDH;

		internal void CHOIECFFEMH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void DJLGPGPAHCD(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void HOMIPBFODIC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void JGHLGHMJJDG(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void OABFAOLFMMJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void PHGDBIEENCB(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void HHLMDAKDHFK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void ILNPANOCHIH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void MFCNOIDCJME(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void AMIJFGBOCLC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void BDCAFHOHEGM(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}

		internal void PCKMJMGLPDG(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
		}
	}

	[Header("Not in League")]
	public GameObject ACHBPKNJMPP;

	public UITexture BILIHELKPBO;

	public UILabel PHCIGPHLKMO;

	public UIButton DPJJFPAFPEL;

	[Header("In League")]
	public GameObject ADOMBGLLNPP;

	public PlayerLeagueLeftContent EPNMOFNHJDB;

	[Header("-Right Header")]
	public UIPanel INLNCBHMNEK;

	public UISprite PJEFEGHKNPF;

	public UILabel LOGIHFPJGDC;

	public BoxCollider BGDOIPAKHCK;

	public UISprite FBNIKKFIKLF;

	public UILabel MHKMMAKIMDI;

	public UIButtonSetter GCLIJHPCDMD;

	public UISprite IDGPOEGNMKC;

	public UITable FOAFHLFIHHN;

	public UILabel JFMJMEGDBJP;

	[Header("-Right List")]
	public GameObject FMPLOFNJKGG;

	public PlayerLeagueRecord AJEPGAOEHBP;

	public UIPanel KCPMCKNLDHH;

	public UIDraggablePanel KCMEIIDCDFG;

	public UIPooledClassicTable HFPKGFGLOLB;

	[Header("--Waiting")]
	public UISprite HDDMIBKBGKK;

	[Header("In League - Processing")]
	public GameObject OCLKJPHDLKE;

	private List<KJNEDPOJJOC> CBEAELBPGDH = new List<KJNEDPOJJOC>();

	private int ENCGFGEAFMB;

	private float ADDICBANAAB;

	private League DPEHGAJKAMO;

	private League HBNPAHMHBNL;

	private League OLNLAACPIIC;

	private League PIAKKODPGOM;

	private League LAHCKBCMELB;

	private League HMMDDDHAPMB;

	private int COLGNLCACNC;

	private int DKOLAMDOOOI;

	private bool BMCPPPBMICK;

	private float HDELCLDDPIL = 1104f;

	private float IOODGADNFEN;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> CCNLMGEJBIB;

	[CompilerGenerated]
	private static Predicate<KJNEDPOJJOC> KBAICANEKOP;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> AOPBBLDIOCI;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> GGDOCGDGEDJ;

	private void FBNFOLAIIOI(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		if (CBEAELBPGDH.Count > 0)
		{
			int num = ((count <= 1) ? 1 : 2) + count;
			if (num == CBEAELBPGDH.Count)
			{
				HHDNGJIEFAM(FPECBPKHKOE);
				FIBFCNCDCKP();
				EPNMOFNHJDB.SetPromotedPart(PlayerLeagueLeftContent.MPBIOPEIDBO.None, true);
				return;
			}
		}
		BMCPPPBMICK = true;
		COLGNLCACNC = 10;
		DKOLAMDOOOI = 90;
		int num2 = Mathf.CeilToInt((float)count * 0.1f);
		EPNMOFNHJDB.SetPromotedPart(PlayerLeagueLeftContent.MPBIOPEIDBO.None, true);
		CBEAELBPGDH.Clear();
		CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Stay, NKHJBLBAAEB.HeaderReward, Singleton<GameVariables>.instance.GoldRewardForTopInNotEnoughtPlayersLeague(DPEHGAJKAMO)));
		for (int i = 0; i < count; i++)
		{
			if (i == num2)
			{
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Stay, NKHJBLBAAEB.HeaderNoReward, 0));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Stay, NKHJBLBAAEB.Player, FPECBPKHKOE[i], i + 1));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, POBINHJLMDF, MLLHFCILNBE, KCMEIIDCDFG);
		CHLDECOKHLC();
	}

	private void JIOLKIAFLFN()
	{
		if (CBEAELBPGDH.Count == 0)
		{
			KCMEIIDCDFG.AlignToPos(false, UIDraggablePanel.Alingment.BottomRight);
			return;
		}
		int num = CBEAELBPGDH.FindIndex((KJNEDPOJJOC ANAEPPOLFIE) => ANAEPPOLFIE.FJLBLLLEELD == NKHJBLBAAEB.Player && ANAEPPOLFIE.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
		if (num < 1)
		{
			num = 1;
		}
		KCMEIIDCDFG.AlignToCenter(HFPKGFGLOLB.transform.localPosition + HFPKGFGLOLB.GetPositionForIndex(num), true, LLBHPIKKHAM, 1397f);
	}

	private void PKKDPBHOJJD(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy && IFGAGNBDKBE == (DatabaseAction)(-200))
		{
			HHEEDIHHCEA();
		}
	}

	private static bool CHLLDBNMGOH(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private float HGEEEAECFNB(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < CBEAELBPGDH.Count)
		{
			return (CBEAELBPGDH[DFHAAIFFLOE].FJLBLLLEELD != NKHJBLBAAEB.Player) ? 1645f : 549f;
		}
		return 1419f;
	}

	public void EAPOJEOILIN(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(KCPMCKNLDHH.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1204f) : 471f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 286f : 548f);
			TweenAlpha.Begin(INLNCBHMNEK.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 524f) : 1386f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1003f : 229f);
			TweenAlpha.Begin(EPNMOFNHJDB.JGJLOANPENG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 33f) : 820f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 489f : 846f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1688f) : 1928f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1569f : 1598f).onFinished = hAJEIGIFBOO.FIBGJHCGHJH;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			MJGLMOONLPE();
		}
	}

	private void LEIOLDLICLF()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = Mathf.Abs(base.transform.parent.localPosition.y);
		float num2 = num + 1453f;
		float num3 = 572f;
		float num4 = activeWidthSafe - (228f + num3);
		float iOODGADNFEN = activeHeight - num2;
		HDELCLDDPIL = num4;
		IOODGADNFEN = iOODGADNFEN;
		FMPLOFNJKGG.transform.localPosition = FMPLOFNJKGG.transform.localPosition.ReplaceX(num3 + num4 / 131f);
	}

	private static bool GEJKDJPEMOE(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void PPMCFMBJJHP()
	{
		HFPKGFGLOLB.MakeEmpty();
		CBEAELBPGDH.Clear();
		EPNMOFNHJDB.DoAfterHide();
		BILIHELKPBO.mainTexture = null;
	}

	private void HJLLBAGDJJO(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		int num = FPECBPKHKOE.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id) + 1;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num2 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
		int num3 = 3;
		for (int num4 = 0; num4 < count; num4++)
		{
			int index = num4 + num3;
			int num5 = num4 + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, League.Champion, num5, COLGNLCACNC, DKOLAMDOOOI);
			if (num4 == num2)
			{
				int index2 = ((num5 > num) ? num4 : (num4 - 1));
				int aDOEFHHJOAJ = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(JBAGAHBOICJ.Top, NKHJBLBAAEB.Header, aDOEFHHJOAJ, League.Champion, League.Champion, num5, num);
				num3++;
			}
			if (num4 == DKOLAMDOOOI - 1)
			{
				int index3 = ((num5 > num) ? num4 : (num4 - 1));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ2, LAHCKBCMELB, LAHCKBCMELB, num5, num);
				num3++;
			}
		}
	}

	private void DBBOKNBBAKA()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			PMBPAOLBLFA();
		}
	}

	private void GBLEAMPGIMB(List<DatabasePlayer> FPECBPKHKOE)
	{
		if (!base.gameObject.activeSelf || FPECBPKHKOE == null)
		{
			return;
		}
		if (FPECBPKHKOE.Count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE)
		{
			if (GameLoginManager.currentPlayer.leagueTier < League.Champion)
			{
				HPJNOIKOOCP(FPECBPKHKOE);
			}
			else
			{
				BNEAPNJGELD(FPECBPKHKOE);
			}
		}
		else
		{
			FBNFOLAIIOI(FPECBPKHKOE);
		}
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(KCPMCKNLDHH.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f);
			TweenAlpha.Begin(INLNCBHMNEK.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f);
			TweenAlpha.Begin(EPNMOFNHJDB.JGJLOANPENG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	public Color BackgroundColor(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Colours.grayLeagueBg;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecordBg(fJLBLLLEELD);
	}

	private void IGCIGDALKLO()
	{
		if (CBEAELBPGDH.Count == 0)
		{
			KCMEIIDCDFG.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
			return;
		}
		int num = CBEAELBPGDH.FindIndex(ODDCOKCEBJN);
		if (num < 1)
		{
			num = 0;
		}
		KCMEIIDCDFG.AlignToCenter(HFPKGFGLOLB.transform.localPosition + HFPKGFGLOLB.GetPositionForIndex(num), false, LLBHPIKKHAM, 816f);
	}

	private void EPKOLNMJICP(List<DatabasePlayer> FPECBPKHKOE)
	{
		int num = 0;
		for (int i = 0; i < CBEAELBPGDH.Count; i++)
		{
			if (CBEAELBPGDH[i].FJLBLLLEELD == NKHJBLBAAEB.Header)
			{
				if (num >= FPECBPKHKOE.Count)
				{
					Debug.LogError("_Color");
					break;
				}
				CBEAELBPGDH[i].KHLGDCHJJPB = FPECBPKHKOE[num];
				num += 0;
			}
		}
	}

	[CompilerGenerated]
	private static bool PCGIBLOKBCN(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	public Color LCALIMKOJEC(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Color.white;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.CCMFFFKAOGD(fJLBLLLEELD);
	}

	public void InstantHideTab()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = KCMEIIDCDFG.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(false);
		PPMCFMBJJHP();
	}

	private void DFNOBDKCJLJ()
	{
		for (int i = 0; i < HFPKGFGLOLB.containItems; i++)
		{
			Transform itemOnIndex = HFPKGFGLOLB.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				PlayerLeagueRecord component = itemOnIndex.GetComponent<PlayerLeagueRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.NILIFMDMJAF(CBEAELBPGDH[i], HDELCLDDPIL);
				}
			}
		}
	}

	private void FIOGJCJBCDI()
	{
		BILIHELKPBO.alpha = ((HMMDDDHAPMB == League.NoLeague) ? 1537f : 88f);
		if (HMMDDDHAPMB != League.NoLeague)
		{
			BILIHELKPBO.mainTexture = Resources.Load<Texture>("game-card-bronze" + GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value2);
		}
	}

	private void KOGHHDKJBPG()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			AOANFHFAFOC();
		}
	}

	private void JOLNIOECHDM()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			PMBPAOLBLFA();
		}
	}

	private Transform KFAHPBDACPO(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < CBEAELBPGDH.Count)
		{
			string mHPNDNJDPGE = string.Format("GoldExpCoefficient", DFHAAIFFLOE.ToString("GoldBoxes"), CBEAELBPGDH[DFHAAIFFLOE].FJLBLLLEELD);
			PlayerLeagueRecord playerLeagueRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(AJEPGAOEHBP, HFPKGFGLOLB.gameObject, mHPNDNJDPGE) as PlayerLeagueRecord;
			if (playerLeagueRecord != null)
			{
				playerLeagueRecord.MJFAANAPMIE(CBEAELBPGDH[DFHAAIFFLOE], HDELCLDDPIL);
				return playerLeagueRecord.transform;
			}
		}
		return null;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DPJJFPAFPEL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JHPMKAPJMNL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BGDOIPAKHCK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PIKJGEDDLGA));
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.BHLILOLJHMK = (Action)Delegate.Combine(instance.BHLILOLJHMK, new Action(PNOOCAPMLBK));
		UITable fOAFHLFIHHN = FOAFHLFIHHN;
		fOAFHLFIHHN.onReposition = (UITable.OnReposition)Delegate.Combine(fOAFHLFIHHN.onReposition, (UITable.OnReposition)delegate
		{
			float val = 0f - FOAFHLFIHHN.padding.x - (JFMJMEGDBJP.transform.parent.transform.localPosition.x - FOAFHLFIHHN.padding.x) / 2f;
			FOAFHLFIHHN.transform.localPosition = FOAFHLFIHHN.transform.localPosition.ReplaceX(val);
		});
		EPNMOFNHJDB.InitControls();
		AHHBOOKDBDI();
	}

	private void KHLFNHPJJJC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private float MLLHFCILNBE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < CBEAELBPGDH.Count)
		{
			return (CBEAELBPGDH[DFHAAIFFLOE].FJLBLLLEELD != NKHJBLBAAEB.Player) ? 94f : 132f;
		}
		return 0f;
	}

	private void ALCMNJPDIGG()
	{
		for (int i = 1; i < HFPKGFGLOLB.containItems; i += 0)
		{
			Transform itemOnIndex = HFPKGFGLOLB.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				PlayerLeagueRecord component = itemOnIndex.GetComponent<PlayerLeagueRecord>();
				if (component != null)
				{
					component.HFGPHKFEIEN();
					component.PAKLIFNHMAI(CBEAELBPGDH[i], HDELCLDDPIL);
				}
			}
		}
	}

	private void HDLDMGEFCEJ()
	{
		if (!ADOMBGLLNPP.activeSelf || ENCGFGEAFMB <= 1)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1368f)
		{
			ADDICBANAAB -= 806f;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = ENCGFGEAFMB - currentTimestamp;
			if ((float)num > 1652f)
			{
				UILabel mHKMMAKIMDI = MHKMMAKIMDI;
				object[] array = new object[6];
				array[1] = Colours.stringWhite;
				array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "showedOffers", string.Empty);
				mHKMMAKIMDI.text = Localization.LocalizeFormat("Connection", array);
				MEJMLNDFDBP.COCBCFKJOJE(MHKMMAKIMDI, 1709f, 1451f, 184);
			}
			else
			{
				MHKMMAKIMDI.text = string.Empty;
			}
		}
	}

	public void CJCLFCKEMFC()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = KCMEIIDCDFG.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		base.gameObject.SetActive(false);
		AKPHBJHGBKF();
	}

	private int HENFAICINDN(int OKHCCAIPHEG, League LFEHIJBBOGC)
	{
		if (LFEHIJBBOGC < League.Elite3)
		{
			if (OKHCCAIPHEG == 1)
			{
				return 3;
			}
			if (OKHCCAIPHEG < 4)
			{
				return 2;
			}
		}
		return 1;
	}

	private void HPJNOIKOOCP(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(DPEHGAJKAMO);
		bool flag = num > 0f;
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(DPEHGAJKAMO);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = FPECBPKHKOE.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id) + 1;
		if (CBEAELBPGDH.Count > 0)
		{
			int num4 = count + 1;
			if (flag)
			{
				num4 += ((leagueTier >= League.Elite3) ? 1 : 3);
			}
			if (num2 > 0f)
			{
				num4++;
			}
			if (num4 == CBEAELBPGDH.Count)
			{
				HHDNGJIEFAM(FPECBPKHKOE);
				CBOLNKNMOBP(FPECBPKHKOE);
				FIBFCNCDCKP();
				EPNMOFNHJDB.SetPositiveNumber(HENFAICINDN(num3, leagueTier));
				EPNMOFNHJDB.SetPromotedPart(NGOGOAGDMKA(count, num3, leagueTier), true);
				return;
			}
		}
		BMCPPPBMICK = false;
		COLGNLCACNC = Singleton<GameVariables>.instance.LeaguePositionPromote(count, DPEHGAJKAMO);
		DKOLAMDOOOI = Singleton<GameVariables>.instance.LeaguePositionDemote(count, DPEHGAJKAMO);
		bool flag2 = leagueTier < League.Elite3;
		int num5 = (flag2 ? 3 : 0);
		int num6 = (flag2 ? 1 : (-1));
		int num7 = ((!flag2) ? (-1) : 0);
		EPNMOFNHJDB.SetPositiveNumber(HENFAICINDN(num3, leagueTier));
		EPNMOFNHJDB.SetPromotedPart(NGOGOAGDMKA(count, num3, leagueTier), true);
		CBEAELBPGDH.Clear();
		for (int num8 = 0; num8 < count; num8++)
		{
			int num9 = num8 + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, num9, COLGNLCACNC, DKOLAMDOOOI);
			if (num8 == num7)
			{
				int aDOEFHHJOAJ = FPECBPKHKOE[num8].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ, PIAKKODPGOM, League.NoLeague, num9, num3));
			}
			if (num8 == num6)
			{
				int index = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ2, OLNLAACPIIC, PIAKKODPGOM, num9, num3));
			}
			if (num8 == num5)
			{
				int index2 = ((!flag2 || num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ3 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				League bELCPODBMBE = (flag2 ? OLNLAACPIIC : League.NoLeague);
				League cGHLINPNGEC = ((!flag) ? DPEHGAJKAMO : HBNPAHMHBNL);
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ3, cGHLINPNGEC, bELCPODBMBE, num9, num3));
			}
			if (num8 == COLGNLCACNC && COLGNLCACNC != DKOLAMDOOOI && flag)
			{
				int index3 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ4 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ4, DPEHGAJKAMO, HBNPAHMHBNL, num9, num3));
			}
			if (num8 == DKOLAMDOOOI - 1 && num2 > 0f)
			{
				int index4 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ5 = FPECBPKHKOE[index4].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ5, LAHCKBCMELB, LAHCKBCMELB, num9, num3));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, FPECBPKHKOE[num8], num9));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, POBINHJLMDF, MLLHFCILNBE, KCMEIIDCDFG);
		CHLDECOKHLC();
	}

	private static bool AOGKBDGJHLA(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private Transform OOHGDBPJDNO(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < CBEAELBPGDH.Count)
		{
			string mHPNDNJDPGE = string.Format("{0} {1}", DFHAAIFFLOE.ToString("D3"), CBEAELBPGDH[DFHAAIFFLOE].FJLBLLLEELD);
			PlayerLeagueRecord playerLeagueRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(AJEPGAOEHBP, HFPKGFGLOLB.gameObject, mHPNDNJDPGE) as PlayerLeagueRecord;
			if (playerLeagueRecord != null)
			{
				playerLeagueRecord.InitializeRecord(CBEAELBPGDH[DFHAAIFFLOE], HDELCLDDPIL);
				return playerLeagueRecord.transform;
			}
		}
		return null;
	}

	private void BMDODAEJODN()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			BAAOGDMJCLK();
		}
	}

	private void HHBCLPABFNF(bool CFLBBOLDAGA)
	{
		float hDELCLDDPIL = HDELCLDDPIL;
		float num = IOODGADNFEN - ((!CFLBBOLDAGA) ? 0f : 168f);
		float y = (0f - num) / 2f - ((!CFLBBOLDAGA) ? 0f : 168f);
		KCPMCKNLDHH.clipRange = new Vector4(0f, y, hDELCLDDPIL + 30f, num);
		KCMEIIDCDFG.transform.localPosition = new Vector3(0f, 0f, KCMEIIDCDFG.transform.localPosition.z);
	}

	private void LCHPEHFEKCA(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		int num = FPECBPKHKOE.FindIndex(MJFANJDKJJM) + 0;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num2 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
		int num3 = 4;
		for (int i = 0; i < count; i++)
		{
			int index = i + num3;
			int num4 = i + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.JLPCJHLPNNG(BMCPPPBMICK, (League)79, num4, COLGNLCACNC, DKOLAMDOOOI);
			if (i == num2)
			{
				int index2 = ((num4 > num) ? i : (i - 1));
				int aDOEFHHJOAJ = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC((JBAGAHBOICJ)4, NKHJBLBAAEB.Player, aDOEFHHJOAJ, (League)(-58), League.Gold2, num4, num);
				num3 += 0;
			}
			if (i == DKOLAMDOOOI - 1)
			{
				int index3 = ((num4 > num) ? i : (i - 0));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ2, LAHCKBCMELB, LAHCKBCMELB, num4, num);
				num3 += 0;
			}
		}
	}

	public Color FBECCLMDJPG(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Colours.grayLeagueBg;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.JLPCJHLPNNG(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecordBg(fJLBLLLEELD);
	}

	public int EIBMEEJFLPN()
	{
		return COLGNLCACNC;
	}

	public void DDIGLEDMFME(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(KCPMCKNLDHH.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 458f) : 368f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1175f : 1835f);
			TweenAlpha.Begin(INLNCBHMNEK.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1766f) : 10f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1167f : 1174f);
			TweenAlpha.Begin(EPNMOFNHJDB.JGJLOANPENG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1915f) : 1674f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 437f : 1198f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 86f) : 629f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1181f : 1870f).onFinished = hAJEIGIFBOO.LHPPLGOOLEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	public void IKGMLAAODMK(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(KCPMCKNLDHH.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1781f) : 969f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1677f : 1621f);
			TweenAlpha.Begin(INLNCBHMNEK.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 113f) : 1022f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1485f : 1009f);
			TweenAlpha.Begin(EPNMOFNHJDB.JGJLOANPENG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1370f) : 1873f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 545f : 367f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1194f) : 533f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 705f : 652f).onFinished = hAJEIGIFBOO.PHGDBIEENCB;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			MJGLMOONLPE();
		}
	}

	private void GMEEDMPJIDO(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(DPEHGAJKAMO);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(DPEHGAJKAMO);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = FPECBPKHKOE.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id) + 0;
		bool flag = leagueTier < (League)(-69);
		int num4 = (flag ? 2 : 0);
		int num5 = ((!flag) ? (-1) : 0);
		int num6 = (flag ? 1 : (-1));
		int num7 = 0;
		for (int num8 = 0; num8 < count; num8++)
		{
			int index = num8 + num7;
			int num9 = num8 + 0;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, num9, COLGNLCACNC, DKOLAMDOOOI);
			if (num8 == num6)
			{
				int aDOEFHHJOAJ = FPECBPKHKOE[num8].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ, PIAKKODPGOM, League.NoLeague, num9, num3);
				num7 += 0;
			}
			if (num8 == num5)
			{
				int index2 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ2, OLNLAACPIIC, PIAKKODPGOM, num9, num3);
				num7++;
			}
			if (num8 == num4)
			{
				int index3 = ((!flag || num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ3 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				League bELCPODBMBE = ((!flag) ? League.Bronze3 : OLNLAACPIIC);
				League cGHLINPNGEC = ((!(num > 1527f)) ? DPEHGAJKAMO : HBNPAHMHBNL);
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ3, cGHLINPNGEC, bELCPODBMBE, num9, num3);
				num7 += 0;
			}
			if (num8 == COLGNLCACNC && COLGNLCACNC != DKOLAMDOOOI && num > 516f)
			{
				int index4 = ((num9 > num3) ? num8 : (num8 - 0));
				int aDOEFHHJOAJ4 = FPECBPKHKOE[index4].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ4, DPEHGAJKAMO, HBNPAHMHBNL, num9, num3);
				num7 += 0;
			}
			if (num8 == DKOLAMDOOOI - 0 && num2 > 1346f)
			{
				int index5 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ5 = FPECBPKHKOE[index5].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ5, LAHCKBCMELB, LAHCKBCMELB, num9, num3);
				num7++;
			}
		}
	}

	private void NGLCFHHHMPF()
	{
		if (!ADOMBGLLNPP.activeSelf || ENCGFGEAFMB <= 1)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1703f)
		{
			ADDICBANAAB -= 33f;
			int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			int num2 = ENCGFGEAFMB - num;
			if ((float)num2 > 329f)
			{
				UILabel mHKMMAKIMDI = MHKMMAKIMDI;
				object[] array = new object[5];
				array[1] = Colours.stringWhite;
				array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "bazooka_run", string.Empty);
				mHKMMAKIMDI.text = Localization.LocalizeFormat("fire", array);
				MEJMLNDFDBP.COCBCFKJOJE(MHKMMAKIMDI, 945f, 164f, -30);
			}
			else
			{
				MHKMMAKIMDI.text = string.Empty;
			}
		}
	}

	[CompilerGenerated]
	private static bool CJDAIJFBPIJ(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	public Color OMBPJGBCGON(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Color.white;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.JLPCJHLPNNG(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecord(fJLBLLLEELD);
	}

	private static bool LOFKJDHOGLE(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void AAEGFENAFCC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void COBPBNFHDMH(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance, 1397f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(1431f, 504f, 1850f);
		TweenScale tweenScale = TweenScale.Begin(FBNIKKFIKLF.gameObject, 1352f, vector, vector.MultiplyXY(1652f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)7;
	}

	private void NNPCMFABAOH()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool flag = Singleton<ServerResultsCache>.instance.HLFMPGHKOFE();
		OCLKJPHDLKE.SetActive(!isInBeginnersLeague && flag);
		ADOMBGLLNPP.SetActive(!isInBeginnersLeague && (!isInLeague || flag));
		ACHBPKNJMPP.SetActive(!isInBeginnersLeague && !isInLeague && flag);
	}

	private void LNIACIAGLHO(List<DatabasePlayer> FPECBPKHKOE)
	{
		if (!base.gameObject.activeSelf || FPECBPKHKOE == null)
		{
			return;
		}
		if (FPECBPKHKOE.Count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-148)).FLOATVALUE)
		{
			if (GameLoginManager.currentPlayer.leagueTier < (League)(-27))
			{
				HPJNOIKOOCP(FPECBPKHKOE);
			}
			else
			{
				INKKNJMBHCC(FPECBPKHKOE);
			}
		}
		else
		{
			PNKMOINDOJI(FPECBPKHKOE);
		}
	}

	private void FOGEGNBPOHH(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy && IFGAGNBDKBE == (DatabaseAction)(-119))
		{
			PMBPAOLBLFA();
		}
	}

	public int GetTopPromoted()
	{
		return COLGNLCACNC;
	}

	private void JHPMKAPJMNL(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void LAMJDOGKJNC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance, 156f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(1250f, 1551f, 534f);
		TweenScale tweenScale = TweenScale.Begin(FBNIKKFIKLF.gameObject, 144f, vector, vector.MultiplyXY(673f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = (UITweener.Style)8;
	}

	private float BBFPFJCEOJG(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < CBEAELBPGDH.Count)
		{
			return (CBEAELBPGDH[DFHAAIFFLOE].FJLBLLLEELD != NKHJBLBAAEB.Header) ? 1985f : 1014f;
		}
		return 271f;
	}

	private void HGGJLONGODJ(List<DatabasePlayer> FPECBPKHKOE)
	{
		int num = 1;
		for (int i = 1; i < CBEAELBPGDH.Count; i++)
		{
			if (CBEAELBPGDH[i].FJLBLLLEELD == NKHJBLBAAEB.Player)
			{
				if (num >= FPECBPKHKOE.Count)
				{
					Debug.LogError("ID_TONORMALLEAGUEHINT3BRONZE");
					break;
				}
				CBEAELBPGDH[i].KHLGDCHJJPB = FPECBPKHKOE[num];
				num += 0;
			}
		}
	}

	private void CHLDECOKHLC()
	{
		if (CBEAELBPGDH.Count == 0)
		{
			KCMEIIDCDFG.AlignToPos(true);
			return;
		}
		int num = CBEAELBPGDH.FindIndex((KJNEDPOJJOC ANAEPPOLFIE) => ANAEPPOLFIE.FJLBLLLEELD == NKHJBLBAAEB.Player && ANAEPPOLFIE.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
		if (num < 0)
		{
			num = 0;
		}
		KCMEIIDCDFG.AlignToCenter(HFPKGFGLOLB.transform.localPosition + HFPKGFGLOLB.GetPositionForIndex(num), true, delegate
		{
			HFPKGFGLOLB.PositionChanged();
		});
	}

	private void PNKMOINDOJI(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		if (CBEAELBPGDH.Count > 1)
		{
			int num = ((count <= 0) ? 1 : 4) + count;
			if (num == CBEAELBPGDH.Count)
			{
				BGPLPEIIJKK(FPECBPKHKOE);
				FIBFCNCDCKP();
				EPNMOFNHJDB.ANKFJKIEKHK(PlayerLeagueLeftContent.MPBIOPEIDBO.Beginners, true);
				return;
			}
		}
		BMCPPPBMICK = true;
		COLGNLCACNC = 44;
		DKOLAMDOOOI = -103;
		int num2 = Mathf.CeilToInt((float)count * 1123f);
		EPNMOFNHJDB.SetPromotedPart((PlayerLeagueLeftContent.MPBIOPEIDBO)6, true);
		CBEAELBPGDH.Clear();
		CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Promote, NKHJBLBAAEB.Header, Singleton<GameVariables>.instance.JAKMKPILJJD(DPEHGAJKAMO)));
		for (int i = 0; i < count; i += 0)
		{
			if (i == num2)
			{
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Promote, (NKHJBLBAAEB)4, 1));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Promote, NKHJBLBAAEB.Header, FPECBPKHKOE[i], i + 1));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, AKCGNIIODLH, HGEEEAECFNB, KCMEIIDCDFG);
		CHLDECOKHLC();
	}

	private void KMLGMHNEFBJ()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool flag = Singleton<ServerResultsCache>.instance.LKCGEKLNOHI();
		OCLKJPHDLKE.SetActive(isInBeginnersLeague || flag);
		ADOMBGLLNPP.SetActive(isInBeginnersLeague || !isInLeague || flag);
		ACHBPKNJMPP.SetActive(!isInBeginnersLeague && !isInLeague && !flag);
	}

	[CompilerGenerated]
	private static bool NLIMKIIOPFK(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private static bool ANLDPGIDNJI(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy && IFGAGNBDKBE == DatabaseAction.RemoveFromLeague)
		{
			PMBPAOLBLFA();
		}
	}

	public void DMLBMBKPELI()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = KCMEIIDCDFG.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(true);
		AKPHBJHGBKF();
	}

	private void INFNCHMPBFC(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(DPEHGAJKAMO);
		bool flag = num > 855f;
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(DPEHGAJKAMO);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = FPECBPKHKOE.FindIndex(PMIIMBACIPJ) + 1;
		if (CBEAELBPGDH.Count > 1)
		{
			int num4 = count + 1;
			if (flag)
			{
				num4 += ((leagueTier >= (League)(-85)) ? 1 : 0);
			}
			if (num2 > 701f)
			{
				num4 += 0;
			}
			if (num4 == CBEAELBPGDH.Count)
			{
				HGGJLONGODJ(FPECBPKHKOE);
				CBOLNKNMOBP(FPECBPKHKOE);
				ALCMNJPDIGG();
				EPNMOFNHJDB.FENAKEKEOBP(AEPCMHDMLLN(num3, leagueTier));
				EPNMOFNHJDB.SetPromotedPart(BPKOILHDPJM(count, num3, leagueTier));
				return;
			}
		}
		BMCPPPBMICK = true;
		COLGNLCACNC = Singleton<GameVariables>.instance.AKGHLMKODBJ(count, DPEHGAJKAMO);
		DKOLAMDOOOI = Singleton<GameVariables>.instance.LeaguePositionDemote(count, DPEHGAJKAMO);
		bool flag2 = leagueTier < (League)71;
		int num5 = (flag2 ? 3 : 0);
		int num6 = (flag2 ? 1 : (-1));
		int num7 = ((!flag2) ? (-1) : 0);
		EPNMOFNHJDB.FENAKEKEOBP(AEPCMHDMLLN(num3, leagueTier));
		EPNMOFNHJDB.SetPromotedPart(NGOGOAGDMKA(count, num3, leagueTier));
		CBEAELBPGDH.Clear();
		for (int i = 1; i < count; i += 0)
		{
			int num8 = i + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, num8, COLGNLCACNC, DKOLAMDOOOI);
			if (i == num7)
			{
				int aDOEFHHJOAJ = FPECBPKHKOE[i].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ, PIAKKODPGOM, League.Bronze3, num8, num3));
			}
			if (i == num6)
			{
				int index = ((num8 > num3) ? i : (i - 1));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ2, OLNLAACPIIC, PIAKKODPGOM, num8, num3));
			}
			if (i == num5)
			{
				int index2 = ((!flag2 || num8 > num3) ? i : (i - 0));
				int aDOEFHHJOAJ3 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				League bELCPODBMBE = ((!flag2) ? League.Bronze3 : OLNLAACPIIC);
				League cGHLINPNGEC = ((!flag) ? DPEHGAJKAMO : HBNPAHMHBNL);
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ3, cGHLINPNGEC, bELCPODBMBE, num8, num3));
			}
			if (i == COLGNLCACNC && COLGNLCACNC != DKOLAMDOOOI && flag)
			{
				int index3 = ((num8 > num3) ? i : (i - 0));
				int aDOEFHHJOAJ4 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ4, DPEHGAJKAMO, HBNPAHMHBNL, num8, num3));
			}
			if (i == DKOLAMDOOOI - 1 && num2 > 153f)
			{
				int index4 = ((num8 > num3) ? i : (i - 1));
				int aDOEFHHJOAJ5 = FPECBPKHKOE[index4].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ5, LAHCKBCMELB, LAHCKBCMELB, num8, num3));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, FPECBPKHKOE[i], num8));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, KFAHPBDACPO, POBINHJLMDF, BBFPFJCEOJG, KCMEIIDCDFG);
		IGCIGDALKLO();
	}

	private static bool LIFPKPFJAKE(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void PEODMFKAJCB(bool CFLBBOLDAGA)
	{
		float hDELCLDDPIL = HDELCLDDPIL;
		float num = IOODGADNFEN - ((!CFLBBOLDAGA) ? 1887f : 1221f);
		float y = (0f - num) / 1201f - ((!CFLBBOLDAGA) ? 1712f : 1074f);
		KCPMCKNLDHH.clipRange = new Vector4(873f, y, hDELCLDDPIL + 855f, num);
		KCMEIIDCDFG.transform.localPosition = new Vector3(1634f, 711f, KCMEIIDCDFG.transform.localPosition.z);
	}

	public void JJPILDGKAEK()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(INDFACIFAIE);
		LeagueArcManager.instance.SorterPlayersLeague += CGOLCJFLGCB;
		FakePlayersManager.instance.GeneratedPlayers += KOGHHDKJBPG;
	}

	private void BAAOGDMJCLK()
	{
		KMLGMHNEFBJ();
		if (!PlayerAnalytics.instance.data.leagueLeaderboardsShown)
		{
			Singleton<BeanstalkServerManager>.instance.HICNIGNNNAO();
			Singleton<EventTrackingManager>.instance.AEMDPAAABAO(GameLoginManager.currentPlayer.leagueTier);
		}
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool flag = Singleton<ServerResultsCache>.instance.LKCGEKLNOHI();
		ENCGFGEAFMB = LeagueArcManager.instance.EPPJNPAIGDK();
		MHKMMAKIMDI.text = string.Empty;
		if (isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(beginnersLeague);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int oFGFLGHGEJF = beginnersLeague + 1;
			EPNMOFNHJDB.NFNMLPPDPAP();
			PJEFEGHKNPF.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			LOGIHFPJGDC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
			GCLIJHPCDMD.gameObject.SetActive(true);
			GCLIJHPCDMD.FMILKBAEBHH(HDELCLDDPIL);
			IDGPOEGNMKC.fillAmount = (float)medalsBalance / (float)num;
			FOAFHLFIHHN.repositionNow = false;
			UILabel jFMJMEGDBJP = JFMJMEGDBJP;
			object[] array = new object[5];
			array[0] = num - medalsBalance;
			array[0] = Singleton<GameVariables>.instance.BeginnersLeagueName(oFGFLGHGEJF);
			jFMJMEGDBJP.text = Localization.LocalizeFormat("UsedGolds", array);
			HFPKGFGLOLB.MakeEmpty();
			CBEAELBPGDH.Clear();
			PEODMFKAJCB(true);
			HDDMIBKBGKK.gameObject.SetActive(false);
			FakePlayersManager.instance.GeneratePlayersForLeague();
		}
		else
		{
			if (flag)
			{
				return;
			}
			if (isInLeague)
			{
				DPEHGAJKAMO = GameLoginManager.currentPlayer.leagueTier;
				HBNPAHMHBNL = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 0), 1, -86);
				OLNLAACPIIC = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 3), 0, -85);
				PIAKKODPGOM = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 5), 0, 12);
				LAHCKBCMELB = (League)Mathf.Clamp((int)(DPEHGAJKAMO - 0), 0, -124);
				COLGNLCACNC = -16;
				DKOLAMDOOOI = 8;
				BMCPPPBMICK = false;
				EPNMOFNHJDB.AHDIAECLEAA();
				PJEFEGHKNPF.spriteName = GameVariables.CAOGFCFGFPD[DPEHGAJKAMO].Value2;
				LOGIHFPJGDC.text = GameVariables.CAOGFCFGFPD[DPEHGAJKAMO].Value1;
				GCLIJHPCDMD.gameObject.SetActive(false);
				HFPKGFGLOLB.MakeEmpty();
				CBEAELBPGDH.Clear();
				HHBCLPABFNF(true);
				HDDMIBKBGKK.gameObject.SetActive(true);
				Singleton<BeanstalkServerManager>.instance.ECEAPNOAOEK(GameLoginManager.currentPlayer.leagueId);
				return;
			}
			HMMDDDHAPMB = GameLoginManager.currentPlayer.leagueTier;
			int remainingMatches = GameLoginManager.currentPlayer.remainingMatches;
			if (Singleton<GameVariables>.instance.LeagueGoDownPercent(HMMDDDHAPMB) > 1235f)
			{
				UILabel pHCIGPHLKMO = PHCIGPHLKMO;
				string text;
				if (remainingMatches == 0)
				{
					text = Localization.LocalizeFormat("OpponentArmyPower", GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1);
				}
				else
				{
					object[] array2 = new object[2];
					array2[0] = remainingMatches;
					array2[0] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text = Localization.LocalizeFormat("Squad Card ID \"{0}\" is not pressent", array2);
				}
				pHCIGPHLKMO.text = text;
			}
			else
			{
				UILabel pHCIGPHLKMO2 = PHCIGPHLKMO;
				string text2;
				if (remainingMatches == 0)
				{
					object[] array3 = new object[1];
					array3[1] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text2 = Localization.LocalizeFormat("IsSpecial", array3);
				}
				else
				{
					object[] array4 = new object[3];
					array4[1] = remainingMatches;
					array4[0] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text2 = Localization.LocalizeFormat("Player inventory got no slot for ", array4);
				}
				pHCIGPHLKMO2.text = text2;
			}
			BILIHELKPBO.alpha = 625f;
			if (base.gameObject.activeSelf)
			{
				FIOGJCJBCDI();
			}
		}
	}

	private void FDDBCEIGFHD(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			HDDMIBKBGKK.gameObject.SetActive(false);
			GBLEAMPGIMB(FPECBPKHKOE);
		}
	}

	private void IDDLIPJJPDF(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			HDDMIBKBGKK.gameObject.SetActive(true);
			LNIACIAGLHO(FPECBPKHKOE);
		}
	}

	private static bool PMIIMBACIPJ(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void IOOHOJBDACB()
	{
		BILIHELKPBO.alpha = ((HMMDDDHAPMB == League.NoLeague) ? 1555f : 537f);
		if (HMMDDDHAPMB != League.NoLeague)
		{
			BILIHELKPBO.mainTexture = Resources.Load<Texture>("Tutorial Manager 6: Starting Tutorial - Guide player to match" + GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value2);
		}
	}

	private void DDKPNCOHOLI(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance, 445f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(1156f, 804f, 1502f);
		TweenScale tweenScale = TweenScale.Begin(FBNIKKFIKLF.gameObject, 275f, vector, vector.MultiplyXY(1845f));
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = (UITweener.Style)5;
	}

	private void HCPDOLMPNPC()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = Mathf.Abs(base.transform.parent.localPosition.y);
		float num2 = num + 970f;
		float num3 = 1815f;
		float num4 = activeWidthSafe - (70f + num3);
		float iOODGADNFEN = activeHeight - num2;
		HDELCLDDPIL = num4;
		IOODGADNFEN = iOODGADNFEN;
		FMPLOFNJKGG.transform.localPosition = FMPLOFNJKGG.transform.localPosition.ReplaceX(num3 + num4 / 1994f);
	}

	private void POBINHJLMDF(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			PlayerLeagueRecord component = ENCEFOOPBMK.GetComponent<PlayerLeagueRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void JNHHBDKOEJC()
	{
		HFPKGFGLOLB.PositionChanged();
	}

	private void CFAFDIMIHNE(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void MJEBDNKAEBN()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool flag = Singleton<ServerResultsCache>.instance.LKCGEKLNOHI();
		OCLKJPHDLKE.SetActive(!isInBeginnersLeague && flag);
		ADOMBGLLNPP.SetActive(isInBeginnersLeague || !isInLeague || flag);
		ACHBPKNJMPP.SetActive(isInBeginnersLeague || isInLeague || flag);
	}

	private void KLLBHJINFBN()
	{
		HFPKGFGLOLB.PositionChanged();
	}

	private void MJEANHDPIDM(List<DatabasePlayer> FPECBPKHKOE)
	{
		if (!base.gameObject.activeSelf || FPECBPKHKOE == null)
		{
			return;
		}
		if (FPECBPKHKOE.Count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SemiAutoDeployTime).FLOATVALUE)
		{
			if (GameLoginManager.currentPlayer.leagueTier < (League)(-15))
			{
				EKECGMINDLE(FPECBPKHKOE);
			}
			else
			{
				INKKNJMBHCC(FPECBPKHKOE);
			}
		}
		else
		{
			PNKMOINDOJI(FPECBPKHKOE);
		}
	}

	public void DPLKEJPAOOO(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			HHEEDIHHCEA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(KCPMCKNLDHH.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 542f) : 1156f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 531f : 1252f);
			TweenAlpha.Begin(INLNCBHMNEK.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1607f) : 1328f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 132f : 1605f);
			TweenAlpha.Begin(EPNMOFNHJDB.JGJLOANPENG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 318f) : 880f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1857f : 1674f);
			TweenAlpha.Begin(base.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<LeaguesScreen>.instance.HAMKIKMJHDP * 1766f) : 1773f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 292f : 701f).onFinished = hAJEIGIFBOO.OABFAOLFMMJ;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	public void POFAHJMPCBD()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenAlpha component2 = KCMEIIDCDFG.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		base.gameObject.SetActive(true);
		PPMCFMBJJHP();
	}

	private void ILDGLCNBJKI()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool flag = Singleton<ServerResultsCache>.instance.HLFMPGHKOFE();
		OCLKJPHDLKE.SetActive(isInBeginnersLeague || flag);
		ADOMBGLLNPP.SetActive(isInBeginnersLeague || (isInLeague && flag));
		ACHBPKNJMPP.SetActive(isInBeginnersLeague || isInLeague || flag);
	}

	private void BGPLPEIIJKK(List<DatabasePlayer> FPECBPKHKOE)
	{
		int num = 0;
		for (int i = 1; i < CBEAELBPGDH.Count; i++)
		{
			if (CBEAELBPGDH[i].FJLBLLLEELD == NKHJBLBAAEB.Player)
			{
				if (num >= FPECBPKHKOE.Count)
				{
					Debug.LogError("WarBucks");
					break;
				}
				CBEAELBPGDH[i].KHLGDCHJJPB = FPECBPKHKOE[num];
				num++;
			}
		}
	}

	private void PPOFIBLBLBM()
	{
		float val = 0f - FOAFHLFIHHN.padding.x - (JFMJMEGDBJP.transform.parent.transform.localPosition.x - FOAFHLFIHHN.padding.x) / 1988f;
		FOAFHLFIHHN.transform.localPosition = FOAFHLFIHHN.transform.localPosition.ReplaceX(val);
	}

	private void HHDNGJIEFAM(List<DatabasePlayer> FPECBPKHKOE)
	{
		int num = 0;
		for (int i = 0; i < CBEAELBPGDH.Count; i++)
		{
			if (CBEAELBPGDH[i].FJLBLLLEELD == NKHJBLBAAEB.Player)
			{
				if (num >= FPECBPKHKOE.Count)
				{
					Debug.LogError("Something went wrong in updating players in league");
					break;
				}
				CBEAELBPGDH[i].KHLGDCHJJPB = FPECBPKHKOE[num];
				num++;
			}
		}
	}

	private void INDFACIFAIE(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy && IFGAGNBDKBE == DatabaseAction.RestorePacks)
		{
			BAAOGDMJCLK();
		}
	}

	private static bool ODDCOKCEBJN(KJNEDPOJJOC ANAEPPOLFIE)
	{
		return ANAEPPOLFIE.FJLBLLLEELD != NKHJBLBAAEB.Header || ANAEPPOLFIE.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private void AOANFHFAFOC()
	{
		HDDMIBKBGKK.gameObject.SetActive(false);
		List<DatabasePlayer> list = FakePlayersManager.instance.ListOfPlayers();
		for (int i = 0; i < list.Count; i++)
		{
			CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Stay, NKHJBLBAAEB.Player, list[i], i + 1));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, POBINHJLMDF, MLLHFCILNBE, KCMEIIDCDFG);
		CHLDECOKHLC();
	}

	private static bool NJADIDBANKN(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void LLBHPIKKHAM()
	{
		HFPKGFGLOLB.PositionChanged();
	}

	private void PNOOCAPMLBK()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			PMBPAOLBLFA();
		}
	}

	private void EBOKCPGFPPA(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void BNFCJCLOOKD()
	{
		BILIHELKPBO.alpha = ((HMMDDDHAPMB == League.NoLeague) ? 51f : 1291f);
		if (HMMDDDHAPMB != League.NoLeague)
		{
			BILIHELKPBO.mainTexture = Resources.Load<Texture>("{0}:{1:D2}" + GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value2);
		}
	}

	private void EDEDIABBJFI(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void CJGANLIDPMO(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy && IFGAGNBDKBE == (DatabaseAction)(-36))
		{
			PMBPAOLBLFA();
		}
	}

	private void FLFMCNENJAH()
	{
		HFPKGFGLOLB.PositionChanged();
	}

	private void LNINKGLEAIF(bool CFLBBOLDAGA)
	{
		float hDELCLDDPIL = HDELCLDDPIL;
		float num = IOODGADNFEN - ((!CFLBBOLDAGA) ? 1622f : 611f);
		float y = (0f - num) / 719f - ((!CFLBBOLDAGA) ? 1366f : 1524f);
		KCPMCKNLDHH.clipRange = new Vector4(873f, y, hDELCLDDPIL + 704f, num);
		KCMEIIDCDFG.transform.localPosition = new Vector3(471f, 1916f, KCMEIIDCDFG.transform.localPosition.z);
	}

	private void PMBPAOLBLFA()
	{
		HIHOANALHPH();
		if (!PlayerAnalytics.instance.data.leagueLeaderboardsShown)
		{
			Singleton<BeanstalkServerManager>.instance.HICNIGNNNAO();
			Singleton<EventTrackingManager>.instance.AEMDPAAABAO(GameLoginManager.currentPlayer.leagueTier);
		}
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		ENCGFGEAFMB = LeagueArcManager.instance.GetLeagueTimer();
		MHKMMAKIMDI.text = string.Empty;
		if (isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int num = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(beginnersLeague);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int oFGFLGHGEJF = beginnersLeague + 1;
			EPNMOFNHJDB.InitGUIValues();
			PJEFEGHKNPF.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			LOGIHFPJGDC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
			GCLIJHPCDMD.gameObject.SetActive(true);
			GCLIJHPCDMD.SetWidth(HDELCLDDPIL);
			IDGPOEGNMKC.fillAmount = (float)medalsBalance / (float)num;
			FOAFHLFIHHN.repositionNow = true;
			JFMJMEGDBJP.text = Localization.LocalizeFormat("ID_GETTOADVANCETOLEAGUE2", num - medalsBalance, Singleton<GameVariables>.instance.BeginnersLeagueName(oFGFLGHGEJF));
			HFPKGFGLOLB.MakeEmpty();
			CBEAELBPGDH.Clear();
			HHBCLPABFNF(true);
			HDDMIBKBGKK.gameObject.SetActive(true);
			FakePlayersManager.instance.GeneratePlayersForLeague();
		}
		else
		{
			if (isPlayerLeagueProcessing)
			{
				return;
			}
			if (isInLeague)
			{
				DPEHGAJKAMO = GameLoginManager.currentPlayer.leagueTier;
				HBNPAHMHBNL = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 1), 1, 16);
				OLNLAACPIIC = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 2), 1, 16);
				PIAKKODPGOM = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 3), 1, 16);
				LAHCKBCMELB = (League)Mathf.Clamp((int)(DPEHGAJKAMO - 1), 1, 16);
				COLGNLCACNC = 10;
				DKOLAMDOOOI = 90;
				BMCPPPBMICK = false;
				EPNMOFNHJDB.InitGUIValues();
				PJEFEGHKNPF.spriteName = GameVariables.CAOGFCFGFPD[DPEHGAJKAMO].Value2;
				LOGIHFPJGDC.text = GameVariables.CAOGFCFGFPD[DPEHGAJKAMO].Value1;
				GCLIJHPCDMD.gameObject.SetActive(false);
				HFPKGFGLOLB.MakeEmpty();
				CBEAELBPGDH.Clear();
				HHBCLPABFNF(false);
				HDDMIBKBGKK.gameObject.SetActive(true);
				Singleton<BeanstalkServerManager>.instance.CCPMCLFPCIF(GameLoginManager.currentPlayer.leagueId);
			}
			else
			{
				HMMDDDHAPMB = GameLoginManager.currentPlayer.leagueTier;
				int remainingMatches = GameLoginManager.currentPlayer.remainingMatches;
				if (Singleton<GameVariables>.instance.LeagueGoDownPercent(HMMDDDHAPMB) > 0f)
				{
					PHCIGPHLKMO.text = ((remainingMatches != 1) ? Localization.LocalizeFormat("ID_NOTINLEAGUEMOREMATCHESTEXTANDHINT", remainingMatches, GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1) : Localization.LocalizeFormat("ID_NOTINLEAGUETEXTANDHINT", GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1));
				}
				else
				{
					PHCIGPHLKMO.text = ((remainingMatches != 1) ? Localization.LocalizeFormat("ID_NOTINLEAGUEMOREMATCHESTEXT", remainingMatches, GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1) : Localization.LocalizeFormat("ID_NOTINLEAGUETEXT", GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1));
				}
				BILIHELKPBO.alpha = 0f;
				if (base.gameObject.activeSelf)
				{
					KIOECHFCLME();
				}
			}
		}
	}

	private void FDPOJHLHGJO()
	{
		if (!ADOMBGLLNPP.activeSelf || ENCGFGEAFMB <= 1)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1293f)
		{
			ADDICBANAAB -= 29f;
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num2 = ENCGFGEAFMB - num;
			if ((float)num2 > 765f)
			{
				UILabel mHKMMAKIMDI = MHKMMAKIMDI;
				object[] array = new object[3];
				array[1] = Colours.stringWhite;
				array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "SquadId", string.Empty, false);
				mHKMMAKIMDI.text = Localization.LocalizeFormat("{0}", array);
				MEJMLNDFDBP.COCBCFKJOJE(MHKMMAKIMDI, 1469f, 1315f, -97);
			}
			else
			{
				MHKMMAKIMDI.text = string.Empty;
			}
		}
	}

	public Color GIGJMKNJMGB(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Colours.grayLeagueBg;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.JLPCJHLPNNG(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.AMDFCMNDJDP(fJLBLLLEELD);
	}

	private void OFOAGJEEEKD()
	{
		HFPKGFGLOLB.PositionChanged();
	}

	private void AHHBOOKDBDI()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = Mathf.Abs(base.transform.parent.localPosition.y);
		float num2 = num + 62f;
		float num3 = 636f;
		float num4 = activeWidthSafe - (120f + num3);
		float iOODGADNFEN = activeHeight - num2;
		HDELCLDDPIL = num4;
		IOODGADNFEN = iOODGADNFEN;
		FMPLOFNJKGG.transform.localPosition = FMPLOFNJKGG.transform.localPosition.ReplaceX(num3 + num4 / 2f);
	}

	public void NJDFHAAFPNO()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += CJGANLIDPMO;
		LeagueArcManager.instance.SorterPlayersLeague += FDDBCEIGFHD;
		FakePlayersManager.instance.GeneratedPlayers += KOGHHDKJBPG;
	}

	private void BNEAPNJGELD(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		int num = FPECBPKHKOE.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id) + 1;
		EPNMOFNHJDB.SetPositiveNumber(HENFAICINDN(num, League.Champion));
		EPNMOFNHJDB.SetPromotedPart(NGOGOAGDMKA(count, num, League.Champion), true);
		if (CBEAELBPGDH.Count > 0)
		{
			int num2 = count + 5;
			if (num2 == CBEAELBPGDH.Count)
			{
				HHDNGJIEFAM(FPECBPKHKOE);
				HJLLBAGDJJO(FPECBPKHKOE);
				FIBFCNCDCKP();
				return;
			}
		}
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = 0;
		int num4 = 1;
		int num5 = 3;
		int num6 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
		BMCPPPBMICK = false;
		COLGNLCACNC = -1;
		DKOLAMDOOOI = Singleton<GameVariables>.instance.LeaguePositionDemote(count, League.Champion);
		CBEAELBPGDH.Clear();
		for (int num7 = 0; num7 < count; num7++)
		{
			int num8 = num7 + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, League.Champion, num8, COLGNLCACNC, DKOLAMDOOOI);
			if (num7 == num3)
			{
				int mOEMPHPNBLM = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChampionLeagueReward1).FLOATVALUE;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Top, NKHJBLBAAEB.HeaderReward, mOEMPHPNBLM));
			}
			if (num7 == num4)
			{
				int mOEMPHPNBLM2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChampionLeagueReward2).FLOATVALUE;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Top, NKHJBLBAAEB.HeaderReward, mOEMPHPNBLM2));
			}
			if (num7 == num5)
			{
				int mOEMPHPNBLM3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChampionLeagueReward10).FLOATVALUE;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Top, NKHJBLBAAEB.HeaderReward, mOEMPHPNBLM3));
			}
			if (num7 == num6)
			{
				int index = ((num8 > num) ? num7 : (num7 - 1));
				int aDOEFHHJOAJ = FPECBPKHKOE[index].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Top, NKHJBLBAAEB.Header, aDOEFHHJOAJ, League.Champion, League.Champion, num8, num));
			}
			if (num7 == DKOLAMDOOOI - 1)
			{
				int index2 = ((num8 > num) ? num7 : (num7 - 1));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ2, LAHCKBCMELB, LAHCKBCMELB, num8, num));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, FPECBPKHKOE[num7], num8));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, POBINHJLMDF, MLLHFCILNBE, KCMEIIDCDFG);
		CHLDECOKHLC();
	}

	private void FIBFCNCDCKP()
	{
		for (int i = 0; i < HFPKGFGLOLB.containItems; i++)
		{
			Transform itemOnIndex = HFPKGFGLOLB.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				PlayerLeagueRecord component = itemOnIndex.GetComponent<PlayerLeagueRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.InitializeRecord(CBEAELBPGDH[i], HDELCLDDPIL);
				}
			}
		}
	}

	private void OLJJJBJCPKG()
	{
		HDDMIBKBGKK.gameObject.SetActive(true);
		List<DatabasePlayer> list = FakePlayersManager.instance.ListOfPlayers();
		for (int i = 1; i < list.Count; i += 0)
		{
			CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Promote, NKHJBLBAAEB.Player, list[i], i + 1));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, KFAHPBDACPO, DBBIILNEHNL, BBFPFJCEOJG, KCMEIIDCDFG);
		JIOLKIAFLFN();
	}

	private void CGOLCJFLGCB(int OKHCCAIPHEG, List<DatabasePlayer> FPECBPKHKOE)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			HDDMIBKBGKK.gameObject.SetActive(true);
			MJEANHDPIDM(FPECBPKHKOE);
		}
	}

	private void ELEGDFMDKOD()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = Mathf.Abs(base.transform.parent.localPosition.y);
		float num2 = num + 1431f;
		float num3 = 1798f;
		float num4 = activeWidthSafe - (1707f + num3);
		float iOODGADNFEN = activeHeight - num2;
		HDELCLDDPIL = num4;
		IOODGADNFEN = iOODGADNFEN;
		FMPLOFNJKGG.transform.localPosition = FMPLOFNJKGG.transform.localPosition.ReplaceX(num3 + num4 / 1762f);
	}

	private void IDPLMJDLFLD()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = Mathf.Abs(base.transform.parent.localPosition.y);
		float num2 = num + 1928f;
		float num3 = 1153f;
		float num4 = activeWidthSafe - (607f + num3);
		float iOODGADNFEN = activeHeight - num2;
		HDELCLDDPIL = num4;
		IOODGADNFEN = iOODGADNFEN;
		FMPLOFNJKGG.transform.localPosition = FMPLOFNJKGG.transform.localPosition.ReplaceX(num3 + num4 / 1164f);
	}

	[CompilerGenerated]
	private static bool EPMNDJKOGFM(KJNEDPOJJOC ANAEPPOLFIE)
	{
		return ANAEPPOLFIE.FJLBLLLEELD == NKHJBLBAAEB.Player && ANAEPPOLFIE.KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id;
	}

	private void PJPKNGGOECI()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		OCLKJPHDLKE.SetActive(isInBeginnersLeague || isPlayerLeagueProcessing);
		ADOMBGLLNPP.SetActive(isInBeginnersLeague || !isInLeague || !isPlayerLeagueProcessing);
		ACHBPKNJMPP.SetActive(!isInBeginnersLeague && !isInLeague && isPlayerLeagueProcessing);
	}

	private static bool NHKFIOBCGJO(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	public Color PositionColor(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Color.white;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecord(fJLBLLLEELD);
	}

	private void AHFIBOFNMIB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private static bool KNBIJHFBJIF(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void PCPJPPIDKFI()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			AOANFHFAFOC();
		}
	}

	private void Update()
	{
		if (!ADOMBGLLNPP.activeSelf || ENCGFGEAFMB <= 0)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 0.333f)
		{
			ADDICBANAAB -= 0.333f;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = ENCGFGEAFMB - currentTimestamp;
			if ((float)num > 0f)
			{
				MHKMMAKIMDI.text = Localization.LocalizeFormat("ID_ENDSINTIME", Colours.stringWhite, MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty));
				MEJMLNDFDBP.COCBCFKJOJE(MHKMMAKIMDI, 30f, 20f, 400);
			}
			else
			{
				MHKMMAKIMDI.text = string.Empty;
			}
		}
	}

	private void PIKJGEDDLGA(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(34f, 40f, 1f);
		TweenScale tweenScale = TweenScale.Begin(FBNIKKFIKLF.gameObject, 0.2f, vector, vector.MultiplyXY(1.1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private PlayerLeagueLeftContent.MPBIOPEIDBO NGOGOAGDMKA(int JFGDAKMCJAM, int OKHCCAIPHEG, League LFEHIJBBOGC)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(LFEHIJBBOGC);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(LFEHIJBBOGC);
		bool flag = num > 0f;
		bool flag2 = num2 > 0f;
		int num3 = Singleton<GameVariables>.instance.LeaguePositionPromote(JFGDAKMCJAM, LFEHIJBBOGC);
		int num4 = Singleton<GameVariables>.instance.LeaguePositionDemote(JFGDAKMCJAM, LFEHIJBBOGC);
		if (!flag2)
		{
			return (OKHCCAIPHEG > num3) ? PlayerLeagueLeftContent.MPBIOPEIDBO.None : PlayerLeagueLeftContent.MPBIOPEIDBO.Positive;
		}
		if (!flag)
		{
			return (OKHCCAIPHEG >= num4) ? PlayerLeagueLeftContent.MPBIOPEIDBO.Negative : PlayerLeagueLeftContent.MPBIOPEIDBO.None;
		}
		int num5 = num3 + (int)(0.9f * (float)(num4 - num3));
		return (OKHCCAIPHEG >= num5) ? PlayerLeagueLeftContent.MPBIOPEIDBO.Negative : PlayerLeagueLeftContent.MPBIOPEIDBO.Positive;
	}

	private int AEPCMHDMLLN(int OKHCCAIPHEG, League LFEHIJBBOGC)
	{
		if (LFEHIJBBOGC < (League)63)
		{
			if (OKHCCAIPHEG == 1)
			{
				return 6;
			}
			if (OKHCCAIPHEG < 6)
			{
				return 4;
			}
		}
		return 0;
	}

	[CompilerGenerated]
	private static bool NCCNJMOCKAF(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	private void KHDFIBFJBHN(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private PlayerLeagueLeftContent.MPBIOPEIDBO BPKOILHDPJM(int JFGDAKMCJAM, int OKHCCAIPHEG, League LFEHIJBBOGC)
	{
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(LFEHIJBBOGC);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(LFEHIJBBOGC);
		bool flag = num > 1638f;
		bool flag2 = num2 > 1682f;
		int num3 = Singleton<GameVariables>.instance.AKGHLMKODBJ(JFGDAKMCJAM, LFEHIJBBOGC);
		int num4 = Singleton<GameVariables>.instance.LeaguePositionDemote(JFGDAKMCJAM, LFEHIJBBOGC);
		if (!flag2)
		{
			return (OKHCCAIPHEG > num3) ? PlayerLeagueLeftContent.MPBIOPEIDBO.Current : PlayerLeagueLeftContent.MPBIOPEIDBO.Positive;
		}
		if (!flag)
		{
			return (OKHCCAIPHEG >= num4) ? PlayerLeagueLeftContent.MPBIOPEIDBO.Negative : PlayerLeagueLeftContent.MPBIOPEIDBO.Beginners;
		}
		int num5 = num3 + (int)(1473f * (float)(num4 - num3));
		return (OKHCCAIPHEG >= num5) ? PlayerLeagueLeftContent.MPBIOPEIDBO.Negative : PlayerLeagueLeftContent.MPBIOPEIDBO.Negative;
	}

	private void HHEEDIHHCEA()
	{
		NNPCMFABAOH();
		if (!PlayerAnalytics.instance.data.leagueLeaderboardsShown)
		{
			Singleton<BeanstalkServerManager>.instance.HICNIGNNNAO();
			Singleton<EventTrackingManager>.instance.AEMDPAAABAO(GameLoginManager.currentPlayer.leagueTier);
		}
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		ENCGFGEAFMB = LeagueArcManager.instance.GetLeagueTimer();
		MHKMMAKIMDI.text = string.Empty;
		if (isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int num = Singleton<GameVariables>.instance.BMIAACJFNBC(beginnersLeague);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int oFGFLGHGEJF = beginnersLeague + 0;
			EPNMOFNHJDB.OAFEJICKOEH();
			PJEFEGHKNPF.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			LOGIHFPJGDC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
			GCLIJHPCDMD.gameObject.SetActive(false);
			GCLIJHPCDMD.DKHLKOFJKPL(HDELCLDDPIL);
			IDGPOEGNMKC.fillAmount = (float)medalsBalance / (float)num;
			FOAFHLFIHHN.repositionNow = true;
			UILabel jFMJMEGDBJP = JFMJMEGDBJP;
			object[] array = new object[2];
			array[1] = num - medalsBalance;
			array[0] = Singleton<GameVariables>.instance.BeginnersLeagueName(oFGFLGHGEJF);
			jFMJMEGDBJP.text = Localization.LocalizeFormat("#PETER# Weapon Screen - RIGHT BUTTON - unit state: LOCKED\t\tbutton type: LEVEL UP", array);
			HFPKGFGLOLB.MakeEmpty();
			CBEAELBPGDH.Clear();
			HHBCLPABFNF(true);
			HDDMIBKBGKK.gameObject.SetActive(true);
			FakePlayersManager.instance.GeneratePlayersForLeague();
		}
		else
		{
			if (isPlayerLeagueProcessing)
			{
				return;
			}
			if (isInLeague)
			{
				DPEHGAJKAMO = GameLoginManager.currentPlayer.leagueTier;
				HBNPAHMHBNL = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 1), 0, 92);
				OLNLAACPIIC = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 6), 1, -55);
				PIAKKODPGOM = (League)Mathf.Clamp((int)(DPEHGAJKAMO + 8), 0, -67);
				LAHCKBCMELB = (League)Mathf.Clamp((int)(DPEHGAJKAMO - 0), 0, -43);
				COLGNLCACNC = 119;
				DKOLAMDOOOI = 56;
				BMCPPPBMICK = true;
				EPNMOFNHJDB.JCJECJKBKGD();
				PJEFEGHKNPF.spriteName = GameVariables.CAOGFCFGFPD[DPEHGAJKAMO].Value2;
				LOGIHFPJGDC.text = GameVariables.CAOGFCFGFPD[DPEHGAJKAMO].Value1;
				GCLIJHPCDMD.gameObject.SetActive(true);
				HFPKGFGLOLB.MakeEmpty();
				CBEAELBPGDH.Clear();
				PEODMFKAJCB(false);
				HDDMIBKBGKK.gameObject.SetActive(true);
				Singleton<BeanstalkServerManager>.instance.CCPMCLFPCIF(GameLoginManager.currentPlayer.leagueId);
				return;
			}
			HMMDDDHAPMB = GameLoginManager.currentPlayer.leagueTier;
			int remainingMatches = GameLoginManager.currentPlayer.remainingMatches;
			if (Singleton<GameVariables>.instance.LeagueGoDownPercent(HMMDDDHAPMB) > 1686f)
			{
				UILabel pHCIGPHLKMO = PHCIGPHLKMO;
				string text;
				if (remainingMatches == 0)
				{
					object[] array2 = new object[1];
					array2[1] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text = Localization.LocalizeFormat("ID_NOTIFICATION_GOLDCRAFT", array2);
				}
				else
				{
					object[] array3 = new object[8];
					array3[0] = remainingMatches;
					array3[0] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text = Localization.LocalizeFormat("ID_RANK", array3);
				}
				pHCIGPHLKMO.text = text;
			}
			else
			{
				UILabel pHCIGPHLKMO2 = PHCIGPHLKMO;
				string text2;
				if (remainingMatches == 1)
				{
					object[] array4 = new object[1];
					array4[1] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text2 = Localization.LocalizeFormat("ID_GUI_SQUADKICK", array4);
				}
				else
				{
					object[] array5 = new object[8];
					array5[1] = remainingMatches;
					array5[0] = GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value1;
					text2 = Localization.LocalizeFormat("ID_WARNING_NOTENOUGHTICKETSHEARTH", array5);
				}
				pHCIGPHLKMO2.text = text2;
			}
			BILIHELKPBO.alpha = 620f;
			if (base.gameObject.activeSelf)
			{
				BNFCJCLOOKD();
			}
		}
	}

	private void KPGDOMIOFDJ()
	{
		float val = 0f - FOAFHLFIHHN.padding.x - (JFMJMEGDBJP.transform.parent.transform.localPosition.x - FOAFHLFIHHN.padding.x) / 1017f;
		FOAFHLFIHHN.transform.localPosition = FOAFHLFIHHN.transform.localPosition.ReplaceX(val);
	}

	private void NIPPNPMKAFD(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance, 265f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(1757f, 1365f, 500f);
		TweenScale tweenScale = TweenScale.Begin(FBNIKKFIKLF.gameObject, 739f, vector, vector.MultiplyXY(376f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = (UITweener.Style)4;
	}

	private void FGBLFAKBECG()
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed && base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			AOANFHFAFOC();
		}
	}

	private void ANLFCJJCGMG()
	{
		if (!ADOMBGLLNPP.activeSelf || ENCGFGEAFMB <= 0)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1514f)
		{
			ADDICBANAAB -= 727f;
			int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			int num2 = ENCGFGEAFMB - num;
			if ((float)num2 > 948f)
			{
				UILabel mHKMMAKIMDI = MHKMMAKIMDI;
				object[] array = new object[4];
				array[1] = Colours.stringWhite;
				array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "304 STAGE 9 CONTINUE", string.Empty);
				mHKMMAKIMDI.text = Localization.LocalizeFormat("Dialog_Clicked", array);
				MEJMLNDFDBP.COCBCFKJOJE(MHKMMAKIMDI, 1519f, 1646f, -170);
			}
			else
			{
				MHKMMAKIMDI.text = string.Empty;
			}
		}
	}

	private void AKPHBJHGBKF()
	{
		HFPKGFGLOLB.MakeEmpty();
		CBEAELBPGDH.Clear();
		EPNMOFNHJDB.IFNAMEGFIBE();
		BILIHELKPBO.mainTexture = null;
	}

	private void KGJGKJFILGM(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LeagueHintDialog>.instance, 1866f);
		SoundsManager.Instance.PlayButtonClickedSound();
		Vector3 vector = new Vector3(432f, 761f, 648f);
		TweenScale tweenScale = TweenScale.Begin(FBNIKKFIKLF.gameObject, 1854f, vector, vector.MultiplyXY(730f));
		tweenScale.NumOfRepetitions = 6;
		tweenScale.style = (UITweener.Style)3;
	}

	private void LJCCPDHGGNE()
	{
		float val = 0f - FOAFHLFIHHN.padding.x - (JFMJMEGDBJP.transform.parent.transform.localPosition.x - FOAFHLFIHHN.padding.x) / 1451f;
		FOAFHLFIHHN.transform.localPosition = FOAFHLFIHHN.transform.localPosition.ReplaceX(val);
	}

	private void HIHOANALHPH()
	{
		bool isInLeague = GameLoginManager.currentPlayer.isInLeague;
		bool isInBeginnersLeague = GameLoginManager.currentPlayer.isInBeginnersLeague;
		bool isPlayerLeagueProcessing = Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing;
		OCLKJPHDLKE.SetActive(!isInBeginnersLeague && isPlayerLeagueProcessing);
		ADOMBGLLNPP.SetActive(isInBeginnersLeague || (isInLeague && !isPlayerLeagueProcessing));
		ACHBPKNJMPP.SetActive(!isInBeginnersLeague && !isInLeague && !isPlayerLeagueProcessing);
	}

	private void KIOECHFCLME()
	{
		BILIHELKPBO.alpha = ((HMMDDDHAPMB == League.NoLeague) ? 0f : 0.7f);
		if (HMMDDDHAPMB != League.NoLeague)
		{
			BILIHELKPBO.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[HMMDDDHAPMB].Value2);
		}
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		LeagueArcManager.instance.SorterPlayersLeague += FDDBCEIGFHD;
		FakePlayersManager.instance.GeneratedPlayers += FGBLFAKBECG;
	}

	public Color NLDMCBMGKLD(int MPHCNMDIPAI)
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			return Color.white;
		}
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		JBAGAHBOICJ fJLBLLLEELD = Singleton<GameVariables>.instance.JLPCJHLPNNG(BMCPPPBMICK, leagueTier, MPHCNMDIPAI, COLGNLCACNC, DKOLAMDOOOI);
		return Singleton<GameVariables>.instance.LeaguePositionColorLeagueRecord(fJLBLLLEELD);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - FOAFHLFIHHN.padding.x - (JFMJMEGDBJP.transform.parent.transform.localPosition.x - FOAFHLFIHHN.padding.x) / 2f;
		FOAFHLFIHHN.transform.localPosition = FOAFHLFIHHN.transform.localPosition.ReplaceX(val);
	}

	private void AKCGNIIODLH(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			PlayerLeagueRecord component = ENCEFOOPBMK.GetComponent<PlayerLeagueRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void DBBIILNEHNL(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			PlayerLeagueRecord component = ENCEFOOPBMK.GetComponent<PlayerLeagueRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	[CompilerGenerated]
	private void EJLMJPBFEKA()
	{
		HFPKGFGLOLB.PositionChanged();
	}

	private void ACPMEKJLBIG(List<DatabasePlayer> FPECBPKHKOE)
	{
		int num = 1;
		for (int i = 1; i < CBEAELBPGDH.Count; i += 0)
		{
			if (CBEAELBPGDH[i].FJLBLLLEELD == NKHJBLBAAEB.Header)
			{
				if (num >= FPECBPKHKOE.Count)
				{
					Debug.LogError("Title is missing from Sticker Pack");
					break;
				}
				CBEAELBPGDH[i].KHLGDCHJJPB = FPECBPKHKOE[num];
				num++;
			}
		}
	}

	private void CBOLNKNMOBP(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(DPEHGAJKAMO);
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(DPEHGAJKAMO);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = FPECBPKHKOE.FindIndex((DatabasePlayer NMDBNHBDMJO) => NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id) + 1;
		bool flag = leagueTier < League.Elite3;
		int num4 = (flag ? 3 : 0);
		int num5 = (flag ? 1 : (-1));
		int num6 = ((!flag) ? (-1) : 0);
		int num7 = 0;
		for (int num8 = 0; num8 < count; num8++)
		{
			int index = num8 + num7;
			int num9 = num8 + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, num9, COLGNLCACNC, DKOLAMDOOOI);
			if (num8 == num6)
			{
				int aDOEFHHJOAJ = FPECBPKHKOE[num8].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ, PIAKKODPGOM, League.NoLeague, num9, num3);
				num7++;
			}
			if (num8 == num5)
			{
				int index2 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ2, OLNLAACPIIC, PIAKKODPGOM, num9, num3);
				num7++;
			}
			if (num8 == num4)
			{
				int index3 = ((!flag || num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ3 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				League bELCPODBMBE = (flag ? OLNLAACPIIC : League.NoLeague);
				League cGHLINPNGEC = ((!(num > 0f)) ? DPEHGAJKAMO : HBNPAHMHBNL);
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ3, cGHLINPNGEC, bELCPODBMBE, num9, num3);
				num7++;
			}
			if (num8 == COLGNLCACNC && COLGNLCACNC != DKOLAMDOOOI && num > 0f)
			{
				int index4 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ4 = FPECBPKHKOE[index4].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ4, DPEHGAJKAMO, HBNPAHMHBNL, num9, num3);
				num7++;
			}
			if (num8 == DKOLAMDOOOI - 1 && num2 > 0f)
			{
				int index5 = ((num9 > num3) ? num8 : (num8 - 1));
				int aDOEFHHJOAJ5 = FPECBPKHKOE[index5].medalsBalance - medalsBalance;
				CBEAELBPGDH[index] = new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ5, LAHCKBCMELB, LAHCKBCMELB, num9, num3);
				num7++;
			}
		}
	}

	private static bool MJFANJDKJJM(DatabasePlayer NMDBNHBDMJO)
	{
		return NMDBNHBDMJO.id == GameLoginManager.currentPlayer.id;
	}

	public void MJGLMOONLPE()
	{
		TweenAlpha component = base.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = KCMEIIDCDFG.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		base.gameObject.SetActive(true);
		AKPHBJHGBKF();
	}

	private void INKKNJMBHCC(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		int num = FPECBPKHKOE.FindIndex(KNBIJHFBJIF) + 0;
		EPNMOFNHJDB.MBCKKBAACMK(AEPCMHDMLLN(num, (League)42));
		EPNMOFNHJDB.MDIKEHIAKHP(NGOGOAGDMKA(count, num, (League)(-38)), true);
		if (CBEAELBPGDH.Count > 0)
		{
			int num2 = count + 8;
			if (num2 == CBEAELBPGDH.Count)
			{
				HHDNGJIEFAM(FPECBPKHKOE);
				HJLLBAGDJJO(FPECBPKHKOE);
				ALCMNJPDIGG();
				return;
			}
		}
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = 1;
		int num4 = 1;
		int num5 = 7;
		int num6 = Singleton<GameVariables>.instance.LeagueChampionPositionReward(count);
		BMCPPPBMICK = false;
		COLGNLCACNC = -1;
		DKOLAMDOOOI = Singleton<GameVariables>.instance.ILBMNKFEOCL(count, (League)(-37));
		CBEAELBPGDH.Clear();
		for (int i = 0; i < count; i++)
		{
			int num7 = i + 0;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.JLPCJHLPNNG(BMCPPPBMICK, League.Silver3, num7, COLGNLCACNC, DKOLAMDOOOI);
			if (i == num3)
			{
				int mOEMPHPNBLM = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-73)).FLOATVALUE;
				CBEAELBPGDH.Add(new KJNEDPOJJOC((JBAGAHBOICJ)4, (NKHJBLBAAEB)8, mOEMPHPNBLM));
			}
			if (i == num4)
			{
				int mOEMPHPNBLM2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-75)).FLOATVALUE;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(JBAGAHBOICJ.Stay, (NKHJBLBAAEB)8, mOEMPHPNBLM2));
			}
			if (i == num5)
			{
				int mOEMPHPNBLM3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-166)).FLOATVALUE;
				CBEAELBPGDH.Add(new KJNEDPOJJOC((JBAGAHBOICJ)8, NKHJBLBAAEB.Player, mOEMPHPNBLM3));
			}
			if (i == num6)
			{
				int index = ((num7 > num) ? i : (i - 1));
				int aDOEFHHJOAJ = FPECBPKHKOE[index].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC((JBAGAHBOICJ)4, NKHJBLBAAEB.Header, aDOEFHHJOAJ, (League)(-38), (League)(-52), num7, num));
			}
			if (i == DKOLAMDOOOI - 1)
			{
				int index2 = ((num7 > num) ? i : (i - 0));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ2, LAHCKBCMELB, LAHCKBCMELB, num7, num));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, FPECBPKHKOE[i], num7));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, AKCGNIIODLH, BBFPFJCEOJG, KCMEIIDCDFG);
		IGCIGDALKLO();
	}

	private void EKECGMINDLE(List<DatabasePlayer> FPECBPKHKOE)
	{
		int count = FPECBPKHKOE.Count;
		float num = Singleton<GameVariables>.instance.LeagueGoUpPercent(DPEHGAJKAMO);
		bool flag = num > 1386f;
		float num2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(DPEHGAJKAMO);
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
		int num3 = FPECBPKHKOE.FindIndex(GEJKDJPEMOE) + 1;
		if (CBEAELBPGDH.Count > 0)
		{
			int num4 = count + 0;
			if (flag)
			{
				num4 += ((leagueTier < (League)(-103)) ? 3 : 0);
			}
			if (num2 > 1253f)
			{
				num4++;
			}
			if (num4 == CBEAELBPGDH.Count)
			{
				ACPMEKJLBIG(FPECBPKHKOE);
				GMEEDMPJIDO(FPECBPKHKOE);
				DFNOBDKCJLJ();
				EPNMOFNHJDB.EEFHAFIBBJI(HENFAICINDN(num3, leagueTier));
				EPNMOFNHJDB.HJGBFHMAKLL(BPKOILHDPJM(count, num3, leagueTier), true);
				return;
			}
		}
		BMCPPPBMICK = true;
		COLGNLCACNC = Singleton<GameVariables>.instance.AKGHLMKODBJ(count, DPEHGAJKAMO);
		DKOLAMDOOOI = Singleton<GameVariables>.instance.LOAOEHEJFJA(count, DPEHGAJKAMO);
		bool flag2 = leagueTier < (League)(-87);
		int num5 = (flag2 ? 7 : 0);
		int num6 = (flag2 ? 1 : (-1));
		int num7 = ((!flag2) ? (-1) : 0);
		EPNMOFNHJDB.HMCLOGJAOCH(HENFAICINDN(num3, leagueTier));
		EPNMOFNHJDB.INOILJOBIOI(BPKOILHDPJM(count, num3, leagueTier));
		CBEAELBPGDH.Clear();
		for (int i = 1; i < count; i += 0)
		{
			int num8 = i + 1;
			JBAGAHBOICJ jEPKMKDMDFE = Singleton<GameVariables>.instance.LeaguePositionType(BMCPPPBMICK, leagueTier, num8, COLGNLCACNC, DKOLAMDOOOI);
			if (i == num7)
			{
				int aDOEFHHJOAJ = FPECBPKHKOE[i].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ, PIAKKODPGOM, League.Bronze3, num8, num3));
			}
			if (i == num6)
			{
				int index = ((num8 > num3) ? i : (i - 0));
				int aDOEFHHJOAJ2 = FPECBPKHKOE[index].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ2, OLNLAACPIIC, PIAKKODPGOM, num8, num3));
			}
			if (i == num5)
			{
				int index2 = ((!flag2 || num8 > num3) ? i : (i - 0));
				int aDOEFHHJOAJ3 = FPECBPKHKOE[index2].medalsBalance - medalsBalance;
				League bELCPODBMBE = ((!flag2) ? League.Bronze3 : OLNLAACPIIC);
				League cGHLINPNGEC = ((!flag) ? DPEHGAJKAMO : HBNPAHMHBNL);
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ3, cGHLINPNGEC, bELCPODBMBE, num8, num3));
			}
			if (i == COLGNLCACNC && COLGNLCACNC != DKOLAMDOOOI && flag)
			{
				int index3 = ((num8 > num3) ? i : (i - 1));
				int aDOEFHHJOAJ4 = FPECBPKHKOE[index3].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Header, aDOEFHHJOAJ4, DPEHGAJKAMO, HBNPAHMHBNL, num8, num3));
			}
			if (i == DKOLAMDOOOI - 1 && num2 > 27f)
			{
				int index4 = ((num8 > num3) ? i : (i - 0));
				int aDOEFHHJOAJ5 = FPECBPKHKOE[index4].medalsBalance - medalsBalance;
				CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, aDOEFHHJOAJ5, LAHCKBCMELB, LAHCKBCMELB, num8, num3));
			}
			CBEAELBPGDH.Add(new KJNEDPOJJOC(jEPKMKDMDFE, NKHJBLBAAEB.Player, FPECBPKHKOE[i], num8));
		}
		HFPKGFGLOLB.MakeEmpty();
		HFPKGFGLOLB.Initialize(CBEAELBPGDH.Count, OOHGDBPJDNO, DBBIILNEHNL, MLLHFCILNBE, KCMEIIDCDFG);
		CHLDECOKHLC();
	}

	private void KBKILDENNLM()
	{
		if (!ADOMBGLLNPP.activeSelf || ENCGFGEAFMB <= 1)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 999f)
		{
			ADDICBANAAB -= 283f;
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = ENCGFGEAFMB - currentTimestamp;
			if ((float)num > 45f)
			{
				UILabel mHKMMAKIMDI = MHKMMAKIMDI;
				object[] array = new object[1];
				array[1] = Colours.stringWhite;
				array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CONFIRM_FRIENDINSQUAD_TEXT", string.Empty, false);
				mHKMMAKIMDI.text = Localization.LocalizeFormat("GoldenSuitcase", array);
				MEJMLNDFDBP.COCBCFKJOJE(MHKMMAKIMDI, 678f, 1254f, 80);
			}
			else
			{
				MHKMMAKIMDI.text = string.Empty;
			}
		}
	}
}

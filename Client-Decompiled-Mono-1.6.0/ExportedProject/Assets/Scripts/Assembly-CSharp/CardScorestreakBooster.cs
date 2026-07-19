using System.Runtime.CompilerServices;
using UnityEngine;

public class CardScorestreakBooster : Card
{
	public float ONCPAMMJEMB = 1.25f;

	public float CDMKEBONMKG = 60f;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private const string EJLCMBEKFFN = "game-card-ico-streakboost-full";

	private PlayerController MBIAKMPDOPG;

	private bool ALBPBCEAEOJ;

	protected override string mBonusName
	{
		get
		{
			return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1f);
		}
	}

	public override void DisconnectEvents()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 0f;
		}
	}

	protected void OFNEGNKMKKG()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1526f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("ID_DOWNLOADINGFILES", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(1351f);
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = 1006f;
		}
		BHABHIDDBLH = 832f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("1", false, true);
		}
	}

	private void ILEBMLBPINN()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = ONCPAMMJEMB;
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = ONCPAMMJEMB;
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = true;
	}

	protected void PHABEKGALCE()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1528f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("ID_WARNING_CLICKOKTORESEND", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = 848f;
		}
		else
		{
			Singleton<ScoreManager>.instance.CHMIBICBLKB(1958f);
		}
		BHABHIDDBLH = 1964f;
		NNDMKIACBBM = false;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("BlackMarketOffer", true);
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			ILEBMLBPINN();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	public virtual void GFDBGJLHODL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH(" NOT OK!", true);
		NGBJPCBHJKA();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CFIKIKCBGKI()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 54f;
		}
	}

	public virtual void GIHMPEHBEDP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			KLHAMOOEPCC();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	[SpecialName]
	protected virtual string EHPJDKFBDLL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 849f);
	}

	protected void BLOBBBLIJPI()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 484f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.CMGKLHJOLDD("WarFriends", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = 1371f;
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(1128f);
		}
		BHABHIDDBLH = 688f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("ID_CONFIRM_ERROR", true);
		}
	}

	protected void GPLKEOAHFJI()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1001f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("customFloat", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(677f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(1515f);
		}
		BHABHIDDBLH = 511f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.Show("ID_VISUALRARITY3", true, true);
		}
	}

	private void KLHAMOOEPCC()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	protected void JBGDAOIDBGF()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1681f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("#PETER# League Arc - start ignore on ", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(275f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(62f);
		}
		BHABHIDDBLH = 639f;
		NNDMKIACBBM = false;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("Adding MessageId after first", true, true);
		}
	}

	protected void Update()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-streakboost-full", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = 1f;
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = 1f;
		}
		BHABHIDDBLH = 0f;
		NNDMKIACBBM = false;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-streakboost-full", false);
		}
	}

	public virtual void OCNCHNBNCOL()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1116f;
		}
	}

	private void BFGCIMNEEDC()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = ONCPAMMJEMB;
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = ONCPAMMJEMB;
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = true;
	}

	public virtual void LABMEJPOIJI()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1131f;
		}
	}

	[SpecialName]
	protected virtual string LJCCCFOBHPC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1808f);
	}

	protected void MNFDMKFLAKO()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 190f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("ID_EMPTY", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(836f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(1004f);
		}
		BHABHIDDBLH = 457f;
		NNDMKIACBBM = false;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("special", false);
		}
	}

	public virtual void CGALPALBIDJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			PKAHDGFFBNA();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	public virtual void BIDGKKBHCBA()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1994f;
		}
	}

	[SpecialName]
	protected virtual string EMLGGCFKHME()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 550f);
	}

	public virtual void GEKMPGMEAGF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("Slon", true, true);
		ACEHIOEEKKD();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void GNOACDCIMDC()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.CHMIBICBLKB(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	private void ACEHIOEEKKD()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.CHMIBICBLKB(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	public virtual void BKIEPPLFCKM()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1272f;
		}
	}

	public virtual void EGNFLFADMPP()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1719f;
		}
	}

	public virtual void OCODHIGNMID()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 123f;
		}
	}

	[SpecialName]
	protected virtual string DMGHILGBHAB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 652f);
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("MaintenanceMessage", true, true);
		KLHAMOOEPCC();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EBHOEAKJNCI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			BFGCIMNEEDC();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	private void HHEGBOFPMGC()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.CHMIBICBLKB(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	[SpecialName]
	protected virtual string OJOHNDMBCHD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1713f);
	}

	[SpecialName]
	protected virtual string JEHGHDLNFIE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1374f);
	}

	public virtual void EHFGLMCNOJN()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 497f;
		}
	}

	public virtual void IJMDPLLHJNF()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1201f;
		}
	}

	[SpecialName]
	protected virtual string FBIDDJAGGAC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1079f);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-streakboost-full", true);
		ILEBMLBPINN();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DPCBCEAMGNK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("ID_NOHEROESINPREVIOUSARENA", true);
		NGBJPCBHJKA();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void OBMMOCOKHGP()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 778f;
		}
	}

	public virtual void FNOOEHLGHNL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			PKAHDGFFBNA();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	protected void KNIAAECLFFK()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 399f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("Spend_Warbucks_On_Player_Customizations", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = 1021f;
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(69f);
		}
		BHABHIDDBLH = 1452f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("bazooka_reload", false, true);
		}
	}

	private void HMILDANPGMH()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = ONCPAMMJEMB;
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = ONCPAMMJEMB;
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	public virtual void AKGODDNOGNO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			BFGCIMNEEDC();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	public virtual void KEDMNJPECDO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("ID_ARENARULES_SHOOTERSPROHIBITED", false);
		HMILDANPGMH();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PNLOEOGDGHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("warbucks", false, true);
		NGBJPCBHJKA();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KKKLOPOOINA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			HMILDANPGMH();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	[SpecialName]
	protected virtual string JPEMNICIAFO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1238f);
	}

	[SpecialName]
	protected virtual string FEGFLGDACBH()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 719f);
	}

	protected void NHEOMLPEBLC()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1463f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("ExpectedPrice", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(531f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(1317f);
		}
		BHABHIDDBLH = 1738f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("bad card visuals for", false, true);
		}
	}

	[SpecialName]
	protected virtual string ILDPDIOCDHK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1740f);
	}

	[SpecialName]
	protected virtual string MDGGACGAFJD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ONCPAMMJEMB - 1421f);
	}

	private void PKAHDGFFBNA()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	protected void OFDJHFMAJBI()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 573f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("NextWithdraw", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = 1088f;
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(407f);
		}
		BHABHIDDBLH = 348f;
		NNDMKIACBBM = false;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("ArenaPoorConnection", false, true);
		}
	}

	protected void CJBJGDCNLOG()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 50f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("ID_SILVERPACK", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(831f);
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = 224f;
		}
		BHABHIDDBLH = 1492f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("RunningOut", true);
		}
	}

	private void NGBJPCBHJKA()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = true;
	}

	public virtual void CBJDBAKNBAG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			PKAHDGFFBNA();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}
}

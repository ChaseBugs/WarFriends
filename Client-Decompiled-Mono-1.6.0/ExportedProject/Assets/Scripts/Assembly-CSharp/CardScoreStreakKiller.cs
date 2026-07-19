using UnityEngine;

public class CardScoreStreakKiller : Card
{
	public float ONCPAMMJEMB = 0.8f;

	public float CDMKEBONMKG = 60f;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private const string EJLCMBEKFFN = "game-card-ico-crateblocker";

	private PlayerController MBIAKMPDOPG;

	private bool ALBPBCEAEOJ;

	private void NOCFGGHIODL()
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

	protected void DIOAOBFDPMH()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1884f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("GetAllSquadMembers - squad {0} - force {1}", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(208f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(914f);
		}
		BHABHIDDBLH = 1733f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("ID_SALEPERCENTLINE", true, true);
		}
	}

	public virtual void EBCLHPLHBHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
			ILEBMLBPINN();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	private void JNKLNHLNKHK()
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

	public virtual void COGOPICCGKI()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1848f;
		}
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("Warp - can not find random point - returning agent destination", true);
		JNKLNHLNKHK();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NGBJPCBHJKA()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.bonusMultiplier = ONCPAMMJEMB;
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	public virtual void LJGNHPMMJJF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
			JNKLNHLNKHK();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	private void FOLIPJJDLDG()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.bonusMultiplierEnemy = ONCPAMMJEMB;
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = true;
	}

	private void PIHADIALNKN()
	{
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(ONCPAMMJEMB);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(ONCPAMMJEMB);
		}
		BHABHIDDBLH = CDMKEBONMKG;
		NNDMKIACBBM = false;
	}

	protected void GFPPJNOENLE()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1969f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("rookie3", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.LMFLBOIMAHP(421f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(1596f);
		}
		BHABHIDDBLH = 815f;
		NNDMKIACBBM = true;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("DatabaseMessage id: {0}\t\t type:{1} already in notification center", false, true);
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
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-crateblocker", BHABHIDDBLH / CDMKEBONMKG);
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
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-crateblocker", false);
		}
	}

	protected void IODGCIIDJEK()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1302f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			if (ALBPBCEAEOJ)
			{
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD("RETRY", BHABHIDDBLH / CDMKEBONMKG);
			}
			return;
		}
		if (MBIAKMPDOPG.isCurrentPlayer)
		{
			Singleton<ScoreManager>.instance.MMKMFONOPLG(1915f);
		}
		else
		{
			Singleton<ScoreManager>.instance.EKOOMCMFAAC(1693f);
		}
		BHABHIDDBLH = 831f;
		NNDMKIACBBM = false;
		if (ALBPBCEAEOJ)
		{
			MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK("accountName", true, true);
		}
	}

	public virtual void NPAMMCJAFLL()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1091f;
		}
	}

	public virtual void OCODHIGNMID()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1513f;
		}
	}

	public virtual void IAKCKOPFABO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
			NOCFGGHIODL();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	public virtual void ILGMMCAGIIM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("ID_SQUADREWARDGET", false, true);
		NGBJPCBHJKA();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KPDDNMLGBKF()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 829f;
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

	public virtual void CPALNIACCKB()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1720f;
		}
	}

	private void KGLLBAMBBHD()
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
		NNDMKIACBBM = true;
	}

	public virtual void AIBAOLCOMBM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("http://localhost:3000/socket.io/", false, true);
		ILEBMLBPINN();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CKLOEEJCAOH()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 886f;
		}
	}

	public virtual void EHFGLMCNOJN()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 706f;
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (!PhotonNetwork.offlineMode)
		{
			MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
			ILEBMLBPINN();
			ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		}
	}

	private void NKODIOMHOKH()
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

	public virtual void CCODFGNHBOJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("ID_DAILYGOLDBOOSTER", true);
		PIHADIALNKN();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void DisconnectEvents()
	{
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 0f;
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-crateblocker", true);
		ILEBMLBPINN();
		ALBPBCEAEOJ = PhotonNetwork.isMasterClient;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}

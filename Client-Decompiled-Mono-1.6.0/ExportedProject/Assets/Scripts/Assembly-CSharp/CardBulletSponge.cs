using UnityEngine;

public class CardBulletSponge : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-bulletsponge-full";

	private const float GNCDFDFKHBO = 60f;

	private const float LOAFENLDIFJ = 0.05f;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private PlayerController MBIAKMPDOPG;

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(1791f);
		BHABHIDDBLH = 1410f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("_New_User", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void BPNLIABHCPN()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1334f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("Card_3_Played", BHABHIDDBLH / 1823f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(419f);
			BHABHIDDBLH = 1534f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("1", true, true);
		}
	}

	protected void JAFBNNAACCL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1479f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("NewVisuals", BHABHIDDBLH / 153f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(1599f);
			BHABHIDDBLH = 1120f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("ItemsOwned_Rarity_3", false);
		}
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(798f);
		BHABHIDDBLH = 701f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("defendPosition", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void MMCIIOJDLHK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(740f);
		BHABHIDDBLH = 938f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("'x'0", false, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.KPLKPJJFBOI(118f);
		BHABHIDDBLH = 43f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("S", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void INHEEMEAIDJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1550f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("RENTAL OFFER", BHABHIDDBLH / 1941f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(643f);
			BHABHIDDBLH = 899f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("ID_SKILLSHOTHINT_EXPLOSIVEKILL", true);
		}
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.KPLKPJJFBOI(321f);
		BHABHIDDBLH = 1613f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("CONFIRM", true, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LEEFEJHDLGM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(949f);
		BHABHIDDBLH = 1813f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("facebookLevel", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void LMNEMMGCEFP()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1210f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.KPCGICBFFCO("game-card-ico-paralyzethese", BHABHIDDBLH / 1954f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(1122f);
			BHABHIDDBLH = 436f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("#account# logged to facebook result {0}", true);
		}
	}

	protected void PMOIOADCKPO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1804f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("ID_FACEBOOKINVITEFRIENDSTEXT-FIGHT", BHABHIDDBLH / 353f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1073f);
			BHABHIDDBLH = 1299f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("{0}{1}{2}", true);
		}
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(1521f);
		BHABHIDDBLH = 1393f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("playerLevel", true, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void MLOJPAEBLBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(601f);
		BHABHIDDBLH = 1858f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("ID_RETRY", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void FLDCHPBPKND()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1014f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("game-ico-blind", BHABHIDDBLH / 70f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(1334f);
			BHABHIDDBLH = 1640f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("VipReward1", false, true);
		}
	}

	protected void HKPIHGBKAHO()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1480f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("Z ", BHABHIDDBLH / 351f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(612f);
			BHABHIDDBLH = 521f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("registerCustomProfileDate", true, true);
		}
	}

	protected void JOCHCGHAIGH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1422f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("#PETER# Removing squad promote message - message time:{0}, server time:{1}, isInSquad:{2}", BHABHIDDBLH / 146f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(1230f);
			BHABHIDDBLH = 46f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("Total_Sessions", false, true);
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(0.05f);
		BHABHIDDBLH = 60f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-bulletsponge-full", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GAGEHEGFGOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.KPLKPJJFBOI(522f);
		BHABHIDDBLH = 866f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("ID_STAT_BATTLESPLAYED", false, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LOPOCGLOHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(1769f);
		BHABHIDDBLH = 1035f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("WENEEDTO", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NPGNJOGAEMK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.KPLKPJJFBOI(1824f);
		BHABHIDDBLH = 1108f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("Special pack content: type: {0} id: {1}{2}", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void MGAIKDBOPKI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 167f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("ID_LOADING", BHABHIDDBLH / 1530f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1612f);
			BHABHIDDBLH = 491f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("-", true, true);
		}
	}

	protected void CKFENMDKKPE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 624f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("N", BHABHIDDBLH / 1655f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(266f);
			BHABHIDDBLH = 1878f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("ID_NO", true);
		}
	}

	protected void DLJAGKBLJNC()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1378f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.EMOGLBGNDBD(" (#", BHABHIDDBLH / 1143f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(685f);
			BHABHIDDBLH = 777f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("확인", false);
		}
	}

	protected void HAMDMFGNIKD()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1281f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.DFNMNBFDDFD("Beanstalk: On Send Settings", BHABHIDDBLH / 388f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(1838f);
			BHABHIDDBLH = 635f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("ID_LVLNUMBER", false);
		}
	}

	protected void NKGLGNEJIOA()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1061f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("ID_CONFIRM_ERROR", BHABHIDDBLH / 1926f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1445f);
			BHABHIDDBLH = 746f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("ID_TWITTER_FOLLOWING_TEXT", true);
		}
	}

	public virtual void NPODFBNDOAK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(46f);
		BHABHIDDBLH = 663f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("#Mission Rewards# 5 Heroic Missions completed. Gained {0} warcards", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(749f);
		BHABHIDDBLH = 498f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.EOEDEJKJKMN("de", true, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void FMKLDIJPHIH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1975f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("ID_CONFIRM_ERROR", BHABHIDDBLH / 1868f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(893f);
			BHABHIDDBLH = 1367f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("setGravityForPopups", false);
		}
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(250f);
		BHABHIDDBLH = 145f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("Name", false, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void ANLFCJJCGMG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1169f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("before: critical: ", BHABHIDDBLH / 1334f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1136f);
			BHABHIDDBLH = 1735f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("ID_TUTORIAL_GO_BUY_ARMY_2", false);
		}
	}

	public virtual void CFPFCPGPOCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(1741f);
		BHABHIDDBLH = 132f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("ID_GUI_BRONZE", false, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void APHGOCOMCAJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(933f);
		BHABHIDDBLH = 145f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("menu-gold", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void AGMKIMGHPAL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(958f);
		BHABHIDDBLH = 981f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("XXd YYh", false, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(581f);
		BHABHIDDBLH = 1715f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("{0} {1}", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void OOCJOBIIKAH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1787f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("GameType", BHABHIDDBLH / 1075f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1357f);
			BHABHIDDBLH = 823f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK("Update of experience\t\t{0} -> {1}\t\t diff {2}, game rewards XP total {3}", true);
		}
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.KPLKPJJFBOI(774f);
		BHABHIDDBLH = 959f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK("NAME", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void JMHFNCOODKH()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 236f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.ONONEOAEOHL("Country", BHABHIDDBLH / 726f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(389f);
			BHABHIDDBLH = 70f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("BUY: ", true);
		}
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-bulletsponge-full", BHABHIDDBLH / 60f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(0f);
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-bulletsponge-full", false);
		}
	}

	protected void NBFMDCFFBIJ()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 191f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("Withdraw_Card", BHABHIDDBLH / 1368f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1608f);
			BHABHIDDBLH = 843f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("InstantBattleEnded: 3RD REWARD GOLD: ", false);
		}
	}

	protected void AOKEHEDCPFB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1395f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("id", BHABHIDDBLH / 1246f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(897f);
			BHABHIDDBLH = 553f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("GameLauncher.LoadMainScene", true);
		}
	}

	public virtual void IOKJMNMABHC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(1831f);
		BHABHIDDBLH = 970f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("ColumnNames", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JONIGCEPKLO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(135f);
		BHABHIDDBLH = 574f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("ID_GUI_EQUIP", false, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BHBDBJNOCMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(210f);
		BHABHIDDBLH = 199f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("ID_GETAPROMOTION1", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.KPLKPJJFBOI(511f);
		BHABHIDDBLH = 1528f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("ID_SQUADEVENT", false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(1306f);
		BHABHIDDBLH = 485f;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("TwitterLogin(", true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void GFPPJNOENLE()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1753f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION", BHABHIDDBLH / 897f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1945f);
			BHABHIDDBLH = 675f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("leagueMedals", false, true);
		}
	}

	public virtual void NJJBJAAHBNP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.SetNoDamageChance(49f);
		BHABHIDDBLH = 1461f;
		NNDMKIACBBM = false;
		MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("{0}{1}{2} {3}{4}", true, true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void CJBJGDCNLOG()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 430f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.KPCGICBFFCO("FuseSDK: Parsing error in _GameDataReceived", BHABHIDDBLH / 1560f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(1344f);
			BHABHIDDBLH = 1238f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("[-]", true);
		}
	}

	protected void CMELHMEBEFI()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1885f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("ID_CONFIRM_ERROR", BHABHIDDBLH / 334f);
				return;
			}
			MBIAKMPDOPG.KPLKPJJFBOI(314f);
			BHABHIDDBLH = 251f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("inappId", false, true);
		}
	}

	protected void GEICOLPLFDL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 995f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("リトライ", BHABHIDDBLH / 497f);
				return;
			}
			MBIAKMPDOPG.SetNoDamageChance(1798f);
			BHABHIDDBLH = 1186f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("ID", false, true);
		}
	}
}

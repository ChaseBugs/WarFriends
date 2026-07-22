using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardSoldierOnSteroids : Card
{
	private bool NAAEKCCBBCF;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool JAOOMCLDJFD;

	private SpawningManagerDeathMatch.ArmyUnitDefinition KDGKDOLCIHG;

	private const string JGMNNPFBOMO = "game-card-ico-meatheads-full";

	private bool KPJLBGMLOFL;

	private float BADJICBCOIM => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SoldierOnSteroidsCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(BADJICBCOIM));

	protected override string mBonusName => MEJMLNDFDBP.KEPEILBMDMD(BADJICBCOIM);

	private void CPMCKMNLDEF(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	public virtual string PNHDOJGPLFI()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(FNIEIFAHCNO());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void IFFEICMIOEL(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("SquadPoints");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LFMDACOAMCE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BPIEADADGEO));
			AIObject.AfterSpawned += HPAMNBICLHF;
		}
	}

	[SpecialName]
	public virtual string IBCHHANJMKL()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(HKOCJBLGEFK());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void EPOHPGJBHAP(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1286f + APGKFJKLANK();
				enemyController.destroyableObj.Refill();
				enemyController.ImproveAllWeapons(1929f + HOLEICILBPO());
				enemyController.cardIconIndicator.BIIHCAEKCOD(" TAB ", NABOFKMBMKH: true);
				KPJLBGMLOFL = false;
			}
		}
	}

	private void KOGGBBDCDFK(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1f + BADJICBCOIM;
				enemyController.destroyableObj.Refill();
				enemyController.ImproveAllWeapons(1f + BADJICBCOIM);
				enemyController.cardIconIndicator.Show("game-card-ico-meatheads-full", NABOFKMBMKH: true);
				KPJLBGMLOFL = true;
			}
		}
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HLBGBAFDOFL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string AECJOACIHOC()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(HKOCJBLGEFK()));
	}

	private void BPIEADADGEO(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	private void GEGOIAIIJEN(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	private void ICHHDOAFEJM(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("{0}:\t{1} = \"{2}\"\tfiles: {3}\n");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MNEPNFNPINI));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(IMBKHPFJIDE));
			AIObject.AfterSpawned += KHKHDJDECJL;
		}
	}

	private void OGIEAFEFKKO(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_STATE_SELECTINGWARCARDS");
			JAOOMCLDJFD = true;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(KNCCLKMDLFM));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(IMBKHPFJIDE));
			AIObject.AfterSpawned += FOOGOGMDEML;
		}
	}

	public virtual void MOIEAEMCOID()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LFMDACOAMCE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(CPMCKMNLDEF));
			AIObject.AfterSpawned -= AFBNLMFJPBK;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	private void GNHFENJFAGK(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("reload_grenadelauncher");
			JAOOMCLDJFD = true;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EKEKGIABHMO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PLNHJADEMCD));
			AIObject.AfterSpawned += HPAMNBICLHF;
		}
	}

	private void FNELCOMFAGH(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("DemotedPlayer");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MNEPNFNPINI));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned += FOOGOGMDEML;
		}
	}

	[SpecialName]
	private float FNIEIFAHCNO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadePlayerBehindShieldConstant).FLOATVALUE;
	}

	public virtual void LCHBPLMPGJP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			ICHHDOAFEJM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void PHCFCGIHFID(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 44f + BADJICBCOIM;
				enemyController.destroyableObj.Refill();
				enemyController.ImproveAllWeapons(1885f + HOLEICILBPO());
				enemyController.cardIconIndicator.JCJFMHGNIOF("ID_ERROR_SQUADMESSAGELONG", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				KPJLBGMLOFL = true;
			}
		}
	}

	private void NFJIALFNCPP(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1735f + APGKFJKLANK();
				enemyController.destroyableObj.APJEBOPJPLA();
				enemyController.ImproveAllWeapons(1514f + HOLEICILBPO());
				enemyController.cardIconIndicator.NNPILDOKNJO("ID_FEATURE_RATE-DESCRIPTION", NABOFKMBMKH: false);
				KPJLBGMLOFL = false;
			}
		}
	}

	public virtual void DPLHJLDDPEJ()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LFMDACOAMCE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PLPOAIAOOOP));
			AIObject.AfterSpawned -= EPOHPGJBHAP;
			NAAEKCCBBCF = true;
			JAOOMCLDJFD = true;
		}
	}

	[SpecialName]
	public virtual string JLPGKJOCDAN()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(BHBCEJFAELC());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void HHKFLIABFCA()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(FKNFPFJNHAH));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PLNHJADEMCD));
			AIObject.AfterSpawned -= NFKOAEILALE;
			NAAEKCCBBCF = true;
			JAOOMCLDJFD = false;
		}
	}

	public virtual void LGCPPPIGHDE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FNELCOMFAGH(CIOPAKLHFIL);
		}
	}

	private void FOOGOGMDEML(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1586f + APGKFJKLANK();
				enemyController.destroyableObj.OEAGCMGINCB();
				enemyController.ImproveAllWeapons(1868f + BHBCEJFAELC());
				enemyController.cardIconIndicator.FJILILFMPIF("Squad Emblem ", NABOFKMBMKH: false);
				KPJLBGMLOFL = false;
			}
		}
	}

	private void LBCLDOLIOFO(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void MEMDELDKFJI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DJFLNGFIDDN(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HCNMHANOHEB(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_WARNING_NOTENOUGHTWARCARDS");
			JAOOMCLDJFD = true;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MHFAKEJPEOK));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PLNHJADEMCD));
			AIObject.AfterSpawned += NFJIALFNCPP;
		}
	}

	private void PLNHJADEMCD(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	protected virtual string JBODIBOMMOD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(BADJICBCOIM);
	}

	[SpecialName]
	public virtual string JPLENCEGLKD()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(BHBCEJFAELC());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void KNCCLKMDLFM(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	[SpecialName]
	public virtual string HFOMPKLFFHC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(BHBCEJFAELC());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string OFHAGHOHJHP()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(FNIEIFAHCNO()));
	}

	public virtual void PPIOIELILIJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			IFFEICMIOEL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	protected virtual string AAGDFGNAOLO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(BADJICBCOIM);
	}

	public virtual void BLDICPPHHPA()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(OIGFBMHMMAP));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(PLPOAIAOOOP));
			AIObject.AfterSpawned -= PLJLMJGPHEK;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	private void FKNFPFJNHAH(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void NDOMLHBNDKF(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("ID_YOUHAVENOSILVERWARCARDSAVAILABLE");
			JAOOMCLDJFD = true;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LBCLDOLIOFO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BPIEADADGEO));
			AIObject.AfterSpawned += NFJIALFNCPP;
		}
	}

	private void MOIALIOGDLL(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("[CardSoldierOnSteroids] - used agan after spawning start, but before finish!!!");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned += KOGGBBDCDFK;
		}
	}

	private void MNEPNFNPINI(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void MHFAKEJPEOK(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void DJFLNGFIDDN(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("game-tutorial-minigunner");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(MNEPNFNPINI));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BLFLEOCKKHG));
			AIObject.AfterSpawned += EPOHPGJBHAP;
		}
	}

	[SpecialName]
	public virtual string CGCEEBCGCFH()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(FNIEIFAHCNO());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	private void AFBNLMFJPBK(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 161f + BADJICBCOIM;
				enemyController.destroyableObj.Refill();
				enemyController.ImproveAllWeapons(1367f + NHBGHMGECNB());
				enemyController.cardIconIndicator.GCLFBCIKNAH("PrepareBotForDeathMatch 1", NABOFKMBMKH: false);
				KPJLBGMLOFL = false;
			}
		}
	}

	private void LFMDACOAMCE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	[SpecialName]
	public virtual string PKCGGJCMCNO()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(APGKFJKLANK());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MOIALIOGDLL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KPICBOHEICI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			IFFEICMIOEL(CIOPAKLHFIL);
		}
	}

	private void PLPOAIAOOOP(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	private void LAAALDJHEIE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void NGHGGKJIBBP(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void CPALNIACCKB()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GDNIHEHMOIG));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BPIEADADGEO));
			AIObject.AfterSpawned -= AFMFPIAEOJE;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	public virtual void APFKNOLLLOB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NDOMLHBNDKF(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public virtual string ODEBOLFPJAL()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(BHBCEJFAELC()));
	}

	[SpecialName]
	protected virtual string MDDKAFEEAMM()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(NHBGHMGECNB());
	}

	private void HPAMNBICLHF(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 743f + FNIEIFAHCNO();
				enemyController.destroyableObj.OEAGCMGINCB();
				enemyController.ImproveAllWeapons(373f + HKOCJBLGEFK());
				enemyController.cardIconIndicator.NNPILDOKNJO("ID_LEAGUESTAYHINT2", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				KPJLBGMLOFL = true;
			}
		}
	}

	[SpecialName]
	protected virtual string FFKKODGACPG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(HOLEICILBPO());
	}

	private void AFMFPIAEOJE(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 826f + HKOCJBLGEFK();
				enemyController.destroyableObj.OEAGCMGINCB();
				enemyController.ImproveAllWeapons(1708f + HOLEICILBPO());
				enemyController.cardIconIndicator.GGHDIAFACAH("Scraps", NABOFKMBMKH: true);
				KPJLBGMLOFL = false;
			}
		}
	}

	private void GDNIHEHMOIG(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void HEBJPOCEMIL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			IFFEICMIOEL(CIOPAKLHFIL);
		}
	}

	public virtual void EBOJNIKJKPG()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(KNCCLKMDLFM));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned -= NFKOAEILALE;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MOIALIOGDLL(CIOPAKLHFIL);
		}
	}

	public override void DisconnectEvents()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LAAALDJHEIE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned -= KOGGBBDCDFK;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = false;
		}
	}

	private void KHKHDJDECJL(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1761f + FNIEIFAHCNO();
				enemyController.destroyableObj.Refill();
				enemyController.ImproveAllWeapons(1409f + HOLEICILBPO());
				enemyController.cardIconIndicator.GCLFBCIKNAH(" is selected: ", NABOFKMBMKH: true);
				KPJLBGMLOFL = false;
			}
		}
	}

	private void BMICFOAFFIP(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("NextDailyRewardLocalnotification");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LBCLDOLIOFO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BLFLEOCKKHG));
			AIObject.AfterSpawned += EPOHPGJBHAP;
		}
	}

	private void FHKDNNNHPIB(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void EKEKGIABHMO(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void BICMHBLIDAK(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void BLFLEOCKKHG(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	private void PNFJCJDKJAC(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			ONHOEFFDJBO(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void IMBKHPFJIDE(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC && JAOOMCLDJFD && BJOIGFEOMHN == KDGKDOLCIHG && KDGKDOLCIHG != null && KPJLBGMLOFL)
		{
			DisconnectEvents();
		}
	}

	public virtual void LABMEJPOIJI()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LBCLDOLIOFO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(GEGOIAIIJEN));
			AIObject.AfterSpawned -= PLJLMJGPHEK;
			NAAEKCCBBCF = true;
			JAOOMCLDJFD = false;
		}
	}

	[SpecialName]
	private float HOLEICILBPO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ShiedlsRefectionTime).FLOATVALUE;
	}

	private void PLJLMJGPHEK(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 998f + APGKFJKLANK();
				enemyController.destroyableObj.OEAGCMGINCB();
				enemyController.ImproveAllWeapons(1218f + BADJICBCOIM);
				enemyController.cardIconIndicator.GKAOMCGCDGE("Result for action:{0} on global:{1}", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				KPJLBGMLOFL = true;
			}
		}
	}

	private void OIGFBMHMMAP(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = false;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	private void NFKOAEILALE(AIObject KLHPCPKJGOC)
	{
		if (JAOOMCLDJFD && KLHPCPKJGOC.fraction == ODCLPMADGFC)
		{
			EnemyController enemyController = KLHPCPKJGOC as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1011f + APGKFJKLANK();
				enemyController.destroyableObj.OEAGCMGINCB();
				enemyController.ImproveAllWeapons(1348f + APGKFJKLANK());
				enemyController.cardIconIndicator.FJILILFMPIF("[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: ", NABOFKMBMKH: true);
				KPJLBGMLOFL = true;
			}
		}
	}

	public virtual void MEMEACLHAIL()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LFMDACOAMCE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BLFLEOCKKHG));
			AIObject.AfterSpawned -= PHCFCGIHFID;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	[SpecialName]
	public virtual string FKDIPLBJPLB()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(HOLEICILBPO());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string MOAEFOFDIMK()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(NHBGHMGECNB()));
	}

	public virtual void CJOCFGPDMLJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MOIALIOGDLL(CIOPAKLHFIL);
		}
	}

	private void ONHOEFFDJBO(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = true;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("NO");
			JAOOMCLDJFD = false;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(EKEKGIABHMO));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BLFLEOCKKHG));
			AIObject.AfterSpawned += KHKHDJDECJL;
		}
	}

	[SpecialName]
	private float BHBCEJFAELC()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-119)).FLOATVALUE;
	}

	[SpecialName]
	private float APGKFJKLANK()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-1)).FLOATVALUE;
	}

	private void MJJNDJBFGDI(GHPGNELIDBM CIOPAKLHFIL, SpawningManagerDeathMatch.ArmyUnitDefinition BJOIGFEOMHN)
	{
		if (CIOPAKLHFIL == ODCLPMADGFC)
		{
			JAOOMCLDJFD = true;
			KDGKDOLCIHG = BJOIGFEOMHN;
		}
	}

	[SpecialName]
	public virtual string NAGMHGGPJOE()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(NHBGHMGECNB());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void NMOKBODAKHB()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(NGHGGKJIBBP));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(IMBKHPFJIDE));
			AIObject.AfterSpawned -= HPAMNBICLHF;
			NAAEKCCBBCF = true;
			JAOOMCLDJFD = false;
		}
	}

	[SpecialName]
	public virtual string AGEDMHMPFKO()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(BHBCEJFAELC());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	private float NHBGHMGECNB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-65)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string IOLLOCGDADC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(FNIEIFAHCNO());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void EKBAEHKJCHL()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(LFMDACOAMCE));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(IMBKHPFJIDE));
			AIObject.AfterSpawned -= EPOHPGJBHAP;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	public virtual void BFOGJKKMHGJ()
	{
		if (NAAEKCCBBCF)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(FHKDNNNHPIB));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(BLFLEOCKKHG));
			AIObject.AfterSpawned -= KOGGBBDCDFK;
			NAAEKCCBBCF = false;
			JAOOMCLDJFD = true;
		}
	}

	[SpecialName]
	private float HKOCJBLGEFK()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-69)).FLOATVALUE;
	}

	private void HLBGBAFDOFL(GHPGNELIDBM CIOPAKLHFIL)
	{
		KPJLBGMLOFL = false;
		ODCLPMADGFC = CIOPAKLHFIL;
		KDGKDOLCIHG = null;
		if (JAOOMCLDJFD)
		{
			Debug.LogError("New Feature - Crafting shown!!");
			JAOOMCLDJFD = true;
		}
		if (!NAAEKCCBBCF)
		{
			NAAEKCCBBCF = false;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.JPGKPGFDAFM = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.JPGKPGFDAFM, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(KNCCLKMDLFM));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.AKKDJINOPDA = (Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.AKKDJINOPDA, new Action<GHPGNELIDBM, SpawningManagerDeathMatch.ArmyUnitDefinition>(IMBKHPFJIDE));
			AIObject.AfterSpawned += AFBNLMFJPBK;
		}
	}

	[SpecialName]
	protected virtual string PKMGDOFDEEA()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(HKOCJBLGEFK());
	}
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Newtonsoft.Json;
using UnityEngine;

public class CHEIFOOIMEH
{
	public List<Tuple<string, CardManager.BuddyCardData>> PHIGKPODHAN = new List<Tuple<string, CardManager.BuddyCardData>>();

	public string AAOAKDPIEII = string.Empty;

	public string CAAKEPHMPHI;

	public long LLIOOOGJFNI;

	public bool GKEOILLNCHG;

	public bool HMGOHGOLMJB;

	public League BMNDININJCE;

	public int GEIONCLKAGF;

	public int HNEFOLPHMHK;

	private DatabasePlayerInfo BJPFKEBIMCI;

	public int ADOEFHHJOAJ;

	public string MHPNDNJDPGE;

	public PhotonPlayer KIOGGEECBGB;

	public string ALIIBMLMNKA;

	public string[] CBBDICBLHMM;

	public Texture EBFDAICCJAK;

	private List<UnitUpgradeDefinition> MIBBFMONCEC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, UnitUpgradeDefinition> _003CHNBECACLHFM_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CEPHBBEIFGON_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CPFBNJFFOOFM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CCKBJDFCGBOM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerInventory.JIMOKIIJHNA[] _003CMMBOCOPGJCP_003Ek__BackingField;

	public int IOFBJPJPEMK;

	public WarArenaCrown FHCMFHABMLE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerVisualCategoryCamos.PlayerVisualCamo _003CKJPCMEIGMCE_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerVisualCategoryHelmets.PlayerVisualHelmet _003CJHJFIJPNBIM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory _003CJOGJPJHPAJA_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerVisualCategoryPowerBands.PlayerVisualPowerBand _003CLOCJJMDKKAL_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CAPEGBFLLMOM_003Ek__BackingField;

	public Dictionary<string, UnitUpgradeDefinition> HDDPODGBNIC
	{
		[CompilerGenerated]
		get
		{
			return _003CHNBECACLHFM_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHNBECACLHFM_003Ek__BackingField = value;
		}
	}

	public bool KMKHCNMIBFD
	{
		[CompilerGenerated]
		get
		{
			return _003CEPHBBEIFGON_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CEPHBBEIFGON_003Ek__BackingField = value;
		}
	}

	public int BCCDDJMPBLL
	{
		[CompilerGenerated]
		get
		{
			return _003CPFBNJFFOOFM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CPFBNJFFOOFM_003Ek__BackingField = value;
		}
	}

	public int AMFJHAPGIJN
	{
		[CompilerGenerated]
		get
		{
			return _003CCKBJDFCGBOM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCKBJDFCGBOM_003Ek__BackingField = value;
		}
	}

	public PlayerInventory.JIMOKIIJHNA[] GGKGGMNIDMI
	{
		[CompilerGenerated]
		get
		{
			return _003CMMBOCOPGJCP_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CMMBOCOPGJCP_003Ek__BackingField = value;
		}
	}

	public int IMOJCFKJKMN => 10 * AMFJHAPGIJN;

	public bool DBIEDLPHCAI => HNEFOLPHMHK > 0;

	public PlayerVisualCategoryCamos.PlayerVisualCamo NHOJPACPJEO
	{
		[CompilerGenerated]
		get
		{
			return _003CKJPCMEIGMCE_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CKJPCMEIGMCE_003Ek__BackingField = value;
		}
	}

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet POHFJHBABAF
	{
		[CompilerGenerated]
		get
		{
			return _003CJHJFIJPNBIM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CJHJFIJPNBIM_003Ek__BackingField = value;
		}
	}

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IPJIPGILEHF
	{
		[CompilerGenerated]
		get
		{
			return _003CJOGJPJHPAJA_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CJOGJPJHPAJA_003Ek__BackingField = value;
		}
	}

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand EOHJMNFLAIK
	{
		[CompilerGenerated]
		get
		{
			return _003CLOCJJMDKKAL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CLOCJJMDKKAL_003Ek__BackingField = value;
		}
	}

	public bool KAOFEOJMDJH
	{
		[CompilerGenerated]
		get
		{
			return _003CAPEGBFLLMOM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAPEGBFLLMOM_003Ek__BackingField = value;
		}
	}

	public static Hashtable MIKEHGFIGDE
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("maxMapId", Singleton<MapManager>.instance.unlockedmaps);
			hashtable.Add("mapId", (!Singleton<MapManager>.instance.isRandomMap) ? Singleton<MapManager>.instance.currentMap.id : 10);
			hashtable.Add("isRandomMap", Singleton<MapManager>.instance.isRandomMap ? 1 : 0);
			hashtable.Add("level", Singleton<GameController>.instance.mainController.playerLevel);
			hashtable.Add("playerID", GameLoginManager.instance.playerId);
			hashtable.Add("facebookID", GameLoginManager.instance.facebookId);
			hashtable.Add("playerVisuals", Singleton<GameController>.instance.mainController.equppedVisuals);
			hashtable.Add("weapons", Singleton<GameController>.instance.mainController.equippedWeapons);
			hashtable.Add("armyPower", LevelManager.instance.armyPower);
			hashtable.Add("defendPosition", Random.Range(0, 2));
			hashtable.Add("upgrades", JsonConvert.SerializeObject(Singleton<GameController>.instance.mainController.GetUnitsUpgrades()));
			hashtable.Add("league", (int)GameLoginManager.currentPlayer.leagueTier);
			hashtable.Add("isVIP", Singleton<VipManager>.instance.NOGEIPHFNPK());
			hashtable.Add("medals", GameLoginManager.instance.medals);
			hashtable.Add("isInLeague", GameLoginManager.currentPlayer.isInLeague);
			hashtable.Add("country", GameLoginManager.currentPlayer.country);
			hashtable.Add("leagueMedals", GameLoginManager.currentPlayer.medalsBalance);
			hashtable.Add("beginnersLeague", GameLoginManager.currentPlayer.beginnersLeague);
			hashtable.Add("matchMadeGames", StatsManager.instance.matchmadeGames);
			hashtable.Add("warArenaCrown", GameLoginManager.currentPlayer.warArenaCrown);
			hashtable.Add("goldShields", WarArena.instance.goldShieldsActive);
			Hashtable hashtable2 = hashtable;
			if (Singleton<GameController>.instance.isCoop)
			{
				hashtable2["defendPosition"] = ((!PhotonNetwork.isMasterClient) ? 1 : 0);
			}
			return hashtable2;
		}
	}

	public DatabasePlayerInfo FGDKPLIPFDA => BJPFKEBIMCI;

	public List<UnitUpgradeDefinition> KBBDGCLPOCJ
	{
		get
		{
			return MIBBFMONCEC;
		}
		set
		{
			MIBBFMONCEC = value;
			HDDPODGBNIC = new Dictionary<string, UnitUpgradeDefinition>();
			for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				HDDPODGBNIC[levelBehaviour.GetType().ToString()] = value[i];
			}
		}
	}

	[SpecialName]
	public void KNFAJEIHOGM(List<UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		MIBBFMONCEC = IDEBKDPMPGM;
		CBDGFGLHPPB(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			DIAJIKDOBLO()[levelBehaviour.GetType().ToString()] = IDEBKDPMPGM[i];
		}
	}

	public Dictionary<string, int> HDFCGKHDNFI()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (GGKGGMNIDMI != null)
		{
			for (int i = 0; i < GGKGGMNIDMI.Length; i++)
			{
				int ePNKPKHCKNG = GGKGGMNIDMI[i].EPNKPKHCKNG;
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG];
				dictionary[weaponLevelsSetup.DHHKOKKDDDO().Replace("Google2u.", string.Empty)] = ((GGKGGMNIDMI != null) ? GGKGGMNIDMI[i].DGPAEJJENDP : 0);
			}
		}
		return dictionary;
	}

	[SpecialName]
	public void LNCHDKEPMCN(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public DatabasePlayerInfo CLODFDOMBIK()
	{
		return BJPFKEBIMCI;
	}

	public Dictionary<string, int> NCBMCPDPGJM()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < PKNOMOCJEPB().Count; i += 0)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = HBOHEBDHLHP()[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace(")", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	public void MLPKIJKJKKJ(bool APEJCKDICLG)
	{
		if (BJPFKEBIMCI != null)
		{
			int value = (int)(0.05f * (float)Mathf.Abs(BJPFKEBIMCI.skill - PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ADOEFHHJOAJ));
			value = Mathf.Clamp(value, 7, 13);
			value = Random.Range(value - 2, value + 2);
			value = Mathf.Clamp(value, 7, 13);
			if (APEJCKDICLG)
			{
				BJPFKEBIMCI.statisticsData.battlesLostRanked++;
				BJPFKEBIMCI.skill -= value;
				ADOEFHHJOAJ -= value;
			}
			else
			{
				BJPFKEBIMCI.statisticsData.battlesWonRanked++;
				BJPFKEBIMCI.skill += value;
				BJPFKEBIMCI.statisticsData.maxMedals = Mathf.Max(BJPFKEBIMCI.statisticsData.maxMedals, BJPFKEBIMCI.skill);
				ADOEFHHJOAJ += value;
			}
			IOFBJPJPEMK++;
			if (BJPFKEBIMCI.statisticsData.mmmGames == 0)
			{
				BJPFKEBIMCI.beginnersLeague = 1;
			}
			BJPFKEBIMCI.statisticsData.mmmGames++;
			if (!BJPFKEBIMCI.isInBeginnersLeague && BJPFKEBIMCI.remainingMatches > 0)
			{
				GKEOILLNCHG = BJPFKEBIMCI.remainingMatches == 1;
				BJPFKEBIMCI.remainingMatches--;
			}
		}
	}

	public static CHEIFOOIMEH FNKEPILGJAO()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.FLOIAIBCEKM(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.ACNBPMENPEP(LevelManager.instance.armyPower);
		cHEIFOOIMEH.GNGLDJHHIHM(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KNFAJEIHOGM(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOIHCEPINJJ();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KKLLMAHAPKO(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = ((!GameLoginManager.currentPlayer.isInLeague) ? 1 : GameLoginManager.currentPlayer.medalsBalance);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.KMKHCNMIBFD = WarArena.instance.NNGLJEPPNKM();
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	public static CHEIFOOIMEH MBMBODIEJPK()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.PHBPHKGMPLG(LevelManager.instance.armyPower);
		cHEIFOOIMEH.GNGLDJHHIHM(PlayerInventory.instance.equippedWeapons);
		cHEIFOOIMEH.KNMGPJAHNMG(LevelManager.instance.GetUpgrades());
		cHEIFOOIMEH.FLOIAIBCEKM(LevelManager.instance.currentLevel.ABCCINJGPGD());
		return cHEIFOOIMEH;
	}

	public static CHEIFOOIMEH FGJLNMNLABN(PhotonPlayer KHLGDCHJJPB, GHPGNELIDBM CIOPAKLHFIL)
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = KHLGDCHJJPB.name;
		cHEIFOOIMEH.KIOGGEECBGB = KHLGDCHJJPB;
		cHEIFOOIMEH.LLIOOOGJFNI = (long)KHLGDCHJJPB.customProperties["Card_2_Played"];
		cHEIFOOIMEH.ALIIBMLMNKA = KHLGDCHJJPB.userId;
		cHEIFOOIMEH.ECFKOCPKODJ((PlayerInventory.JIMOKIIJHNA[])KHLGDCHJJPB.customProperties[", action = "]);
		cHEIFOOIMEH.IKNFFPLBHLO((int)KHLGDCHJJPB.customProperties["setGoogleAdvertisingId"]);
		cHEIFOOIMEH.AMFJHAPGIJN = (int)KHLGDCHJJPB.customProperties["ID_INSERTTHREESILVERORBRONZECARDS"];
		cHEIFOOIMEH.EBFDAICCJAK = ((CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction) ? Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP : Singleton<ArmyPreviewCamera>.instance.HICMLKAOEJL);
		cHEIFOOIMEH.KNMGPJAHNMG(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>((string)KHLGDCHJJPB.customProperties["acceptFriend"]));
		cHEIFOOIMEH.BMNDININJCE = (League)(int)KHLGDCHJJPB.customProperties[" WITHDRAWED {0}\n"];
		cHEIFOOIMEH.HMGOHGOLMJB = (bool)KHLGDCHJJPB.customProperties["bronze"];
		cHEIFOOIMEH.CBBDICBLHMM = (string[])KHLGDCHJJPB.customProperties["PromotedPlayerId"];
		cHEIFOOIMEH.ADOEFHHJOAJ = (int)KHLGDCHJJPB.customProperties["StarterPackDeadline"];
		cHEIFOOIMEH.OPHNIFBLHPP(IDEBKDPMPGM: false);
		cHEIFOOIMEH.GKEOILLNCHG = (bool)KHLGDCHJJPB.customProperties["LeagueId"];
		cHEIFOOIMEH.CAAKEPHMPHI = (string)KHLGDCHJJPB.customProperties["([,.!\\?-_:;]|\\s)"];
		cHEIFOOIMEH.GEIONCLKAGF = (int)KHLGDCHJJPB.customProperties["UnitReadyForPromotion {0} {1}"];
		cHEIFOOIMEH.HNEFOLPHMHK = (int)KHLGDCHJJPB.customProperties["22 / 22"];
		cHEIFOOIMEH.IOFBJPJPEMK = (int)KHLGDCHJJPB.customProperties["Display notifications"];
		cHEIFOOIMEH.FHCMFHABMLE = (WarArenaCrown)(int)KHLGDCHJJPB.customProperties["ID_FEATURE_RATE-FANCY"];
		cHEIFOOIMEH.FAGIFHMFAAB((bool)KHLGDCHJJPB.customProperties["Position"]);
		return cHEIFOOIMEH;
	}

	public static CHEIFOOIMEH JIIHHODDNLJ()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.BCCDDJMPBLL = Singleton<GameController>.instance.mainController.playerLevel;
		cHEIFOOIMEH.AMFJHAPGIJN = LevelManager.instance.armyPower;
		cHEIFOOIMEH.GGKGGMNIDMI = Singleton<GameController>.instance.mainController.equippedWeapons;
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KBBDGCLPOCJ = Singleton<GameController>.instance.mainController.GetUnitsUpgrades();
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOGEIPHFNPK();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KAOFEOJMDJH = false;
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.KMKHCNMIBFD = WarArena.instance.goldShieldsActive;
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public bool FOIPOEEMBCO()
	{
		return HNEFOLPHMHK > 1;
	}

	public static CHEIFOOIMEH KPGNGIOHAMA()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.GLMOLELPHMH(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.ACNBPMENPEP(LevelManager.instance.armyPower);
		cHEIFOOIMEH.GNGLDJHHIHM(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KBBDGCLPOCJ = Singleton<GameController>.instance.mainController.GetUnitsUpgrades();
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.FAKAOBDANNA();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.OOHAEAICMEL(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.ICJDPBPKBKA(WarArena.instance.NNGLJEPPNKM());
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public void IFEIEMFFMPE(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void ACLEGELJGCE(string NENEKFMLBMP)
	{
		KBBDGCLPOCJ = JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>(NENEKFMLBMP);
	}

	[SpecialName]
	public int MKLKHDBNJIM()
	{
		return 30 * PBAKDBHPGGO();
	}

	public static CHEIFOOIMEH AINECHENOHG()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.AMFJHAPGIJN = LevelManager.instance.armyPower;
		cHEIFOOIMEH.GGKGGMNIDMI = PlayerInventory.instance.equippedWeapons;
		cHEIFOOIMEH.KBBDGCLPOCJ = LevelManager.instance.GetUpgrades();
		cHEIFOOIMEH.BCCDDJMPBLL = LevelManager.instance.currentLevel.displayNumber;
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public void FHNKKPLLOPB(List<UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		MIBBFMONCEC = IDEBKDPMPGM;
		JPGJMNCIECC(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			BJGFFIJFNKJ()[levelBehaviour.GetType().ToString()] = IDEBKDPMPGM[i];
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet KMKOEGBLMIN()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	[SpecialName]
	public void LPGACOBNHOH(PlayerInventory.JIMOKIIJHNA[] IDEBKDPMPGM)
	{
		_003CMMBOCOPGJCP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int OEJKKJJFDFL()
	{
		return _003CPFBNJFFOOFM_003Ek__BackingField;
	}

	[SpecialName]
	public void ACNBPMENPEP(int IDEBKDPMPGM)
	{
		_003CCKBJDFCGBOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void MPNEMHDGBED(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet IECLHGHHILE()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	public void KJOICDPDOPB()
	{
		NHOJPACPJEO = null;
		IPJIPGILEHF = null;
		POHFJHBABAF = null;
		EOHJMNFLAIK = null;
	}

	[SpecialName]
	public void INLLAMGKOMM(PlayerInventory.JIMOKIIJHNA[] IDEBKDPMPGM)
	{
		_003CMMBOCOPGJCP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void ONLHFBHGAJE(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool KICDCKAAMAH()
	{
		return _003CEPHBBEIFGON_003Ek__BackingField;
	}

	[SpecialName]
	private void ICJDPBPKBKA(bool IDEBKDPMPGM)
	{
		_003CEPHBBEIFGON_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public static Hashtable JLFLBACPEGH()
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("factor: ", Singleton<MapManager>.instance.GBGMEFDNDIL());
		hashtable.Add("Squad Member record does not have DatabasePlayer", (!Singleton<MapManager>.instance.isRandomMap) ? Singleton<MapManager>.instance.NOPGGANHAFN().id : 6);
		hashtable.Add("SEND LOGS", (!Singleton<MapManager>.instance.isRandomMap) ? 1 : 0);
		hashtable.Add("country-norway", Singleton<GameController>.instance.mainController.playerLevel);
		hashtable.Add("ID_CONFIRM_SQUADNOTEMPTY", GameLoginManager.instance.playerId);
		hashtable.Add("Google2u.DBUpgradeSlots", GameLoginManager.instance.facebookId);
		hashtable.Add("ID_SLOTUPGRADE_ROF", Singleton<GameController>.instance.mainController.equppedVisuals);
		hashtable.Add("QUIT", Singleton<GameController>.instance.mainController.equippedWeapons);
		hashtable.Add(" AND ", LevelManager.instance.armyPower);
		hashtable.Add("Beanstalk: RESTORE PACKS", Random.Range(0, 6));
		hashtable.Add("ID_CONFIRM_SQUADFULL", JsonConvert.SerializeObject(Singleton<GameController>.instance.mainController.GetUnitsUpgrades()));
		hashtable.Add("ID_SLOTUPGRADE_DAMAGE", (int)GameLoginManager.currentPlayer.leagueTier);
		hashtable.Add("Swat", Singleton<VipManager>.instance.FAKAOBDANNA());
		hashtable.Add("NumberOfMission", GameLoginManager.instance.medals);
		hashtable.Add("ID_NOTIFICATION_LAPSED_VIP", GameLoginManager.currentPlayer.isInLeague);
		hashtable.Add("menu-weaponstats-burstsize", GameLoginManager.currentPlayer.country);
		hashtable.Add("\"NEGINFINITY\"", GameLoginManager.currentPlayer.medalsBalance);
		hashtable.Add("AtlasPreparer.LoadGameCoroutine", GameLoginManager.currentPlayer.beginnersLeague);
		hashtable.Add("hashCode", StatsManager.instance.matchmadeGames);
		hashtable.Add("OK", GameLoginManager.currentPlayer.warArenaCrown);
		hashtable.Add("Play_Card_Tutorial_Duration", WarArena.instance.CJDCEJCEHJE());
		Hashtable hashtable2 = hashtable;
		if (Singleton<GameController>.instance.isCoop)
		{
			hashtable2["ID_READYTIME"] = (PhotonNetwork.isMasterClient ? 1 : 0);
		}
		return hashtable2;
	}

	[SpecialName]
	public int OCPEHLIIGML()
	{
		return _003CPFBNJFFOOFM_003Ek__BackingField;
	}

	[SpecialName]
	public void OPHNIFBLHPP(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static CHEIFOOIMEH JCGIGDMKCDG()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.ACNBPMENPEP(LevelManager.instance.armyPower);
		cHEIFOOIMEH.LPGACOBNHOH(PlayerInventory.instance.equippedWeapons);
		cHEIFOOIMEH.KNFAJEIHOGM(LevelManager.instance.GetUpgrades());
		cHEIFOOIMEH.BCCDDJMPBLL = LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public void KMGLGLEKMNP(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void FAGIFHMFAAB(bool IDEBKDPMPGM)
	{
		_003CEPHBBEIFGON_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void ECFKOCPKODJ(PlayerInventory.JIMOKIIJHNA[] IDEBKDPMPGM)
	{
		_003CMMBOCOPGJCP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool BINFBHBEFJM()
	{
		return _003CAPEGBFLLMOM_003Ek__BackingField;
	}

	[SpecialName]
	public int CNNBDFHJIAK()
	{
		return _003CCKBJDFCGBOM_003Ek__BackingField;
	}

	[SpecialName]
	public bool NANMFGACLJA()
	{
		return _003CAPEGBFLLMOM_003Ek__BackingField;
	}

	[SpecialName]
	public void FLOIAIBCEKM(int IDEBKDPMPGM)
	{
		_003CPFBNJFFOOFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public DatabasePlayerInfo LFGDGAAFIKB()
	{
		return BJPFKEBIMCI;
	}

	[SpecialName]
	public void EFEJGFIHICA(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public Dictionary<string, UnitUpgradeDefinition> BJGFFIJFNKJ()
	{
		return _003CHNBECACLHFM_003Ek__BackingField;
	}

	[SpecialName]
	public Dictionary<string, UnitUpgradeDefinition> FEDLMGKKGKJ()
	{
		return _003CHNBECACLHFM_003Ek__BackingField;
	}

	public static CHEIFOOIMEH MDGGFOOHFGO(PhotonPlayer KHLGDCHJJPB, GHPGNELIDBM CIOPAKLHFIL)
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = KHLGDCHJJPB.name;
		cHEIFOOIMEH.KIOGGEECBGB = KHLGDCHJJPB;
		cHEIFOOIMEH.LLIOOOGJFNI = (long)KHLGDCHJJPB.customProperties["D4"];
		cHEIFOOIMEH.ALIIBMLMNKA = KHLGDCHJJPB.userId;
		cHEIFOOIMEH.INLLAMGKOMM((PlayerInventory.JIMOKIIJHNA[])KHLGDCHJJPB.customProperties["+{0}"]);
		cHEIFOOIMEH.EEINNIFGJKF((int)KHLGDCHJJPB.customProperties["tc"]);
		cHEIFOOIMEH.ACNBPMENPEP((int)KHLGDCHJJPB.customProperties["#PETER# League Arc "]);
		cHEIFOOIMEH.EBFDAICCJAK = ((CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction) ? Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP : Singleton<ArmyPreviewCamera>.instance.HICMLKAOEJL);
		cHEIFOOIMEH.NLAPKHLIEKC(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>((string)KHLGDCHJJPB.customProperties["game-card-ico-supersoldiers"]));
		cHEIFOOIMEH.BMNDININJCE = (League)(int)KHLGDCHJJPB.customProperties["TW_Follow"];
		cHEIFOOIMEH.HMGOHGOLMJB = (bool)KHLGDCHJJPB.customProperties["Purchase_Attempt"];
		cHEIFOOIMEH.CBBDICBLHMM = (string[])KHLGDCHJJPB.customProperties["Token"];
		cHEIFOOIMEH.ADOEFHHJOAJ = (int)KHLGDCHJJPB.customProperties[" OK!"];
		cHEIFOOIMEH.KJJJLNAADHC(IDEBKDPMPGM: false);
		cHEIFOOIMEH.GKEOILLNCHG = (bool)KHLGDCHJJPB.customProperties["N"];
		cHEIFOOIMEH.CAAKEPHMPHI = (string)KHLGDCHJJPB.customProperties["describeContents"];
		cHEIFOOIMEH.GEIONCLKAGF = (int)KHLGDCHJJPB.customProperties["D2"];
		cHEIFOOIMEH.HNEFOLPHMHK = (int)KHLGDCHJJPB.customProperties["\n"];
		cHEIFOOIMEH.IOFBJPJPEMK = (int)KHLGDCHJJPB.customProperties["Buy_Weapon_At_Rank"];
		cHEIFOOIMEH.FHCMFHABMLE = (WarArenaCrown)(int)KHLGDCHJJPB.customProperties["ID_STARTERASSIGNMENT"];
		cHEIFOOIMEH.FAGIFHMFAAB((bool)KHLGDCHJJPB.customProperties["ticketsSpent"]);
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public List<UnitUpgradeDefinition> HBOHEBDHLHP()
	{
		return MIBBFMONCEC;
	}

	[SpecialName]
	public DatabasePlayerInfo CBNGHDGDFMA()
	{
		return BJPFKEBIMCI;
	}

	[SpecialName]
	public Dictionary<string, UnitUpgradeDefinition> DIAJIKDOBLO()
	{
		return _003CHNBECACLHFM_003Ek__BackingField;
	}

	public void ANEPEAHMFIF(string NENEKFMLBMP)
	{
		KNFAJEIHOGM(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>(NENEKFMLBMP));
	}

	[SpecialName]
	public int BPNPPKPCFGN()
	{
		return _003CPFBNJFFOOFM_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand HPLMFHENLCP()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	public void BMJBCDGLPBE(bool APEJCKDICLG)
	{
		if (BJPFKEBIMCI != null)
		{
			int value = (int)(1980f * (float)Mathf.Abs(BJPFKEBIMCI.skill - PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ADOEFHHJOAJ));
			value = Mathf.Clamp(value, 2, 93);
			value = Random.Range(value - 6, value + 4);
			value = Mathf.Clamp(value, 4, 47);
			if (APEJCKDICLG)
			{
				BJPFKEBIMCI.statisticsData.battlesLostRanked++;
				BJPFKEBIMCI.skill -= value;
				ADOEFHHJOAJ -= value;
			}
			else
			{
				BJPFKEBIMCI.statisticsData.battlesWonRanked += 0;
				BJPFKEBIMCI.skill += value;
				BJPFKEBIMCI.statisticsData.maxMedals = Mathf.Max(BJPFKEBIMCI.statisticsData.maxMedals, BJPFKEBIMCI.skill);
				ADOEFHHJOAJ += value;
			}
			IOFBJPJPEMK += 0;
			if (BJPFKEBIMCI.statisticsData.mmmGames == 0)
			{
				BJPFKEBIMCI.beginnersLeague = 1;
			}
			BJPFKEBIMCI.statisticsData.mmmGames += 0;
			if (!BJPFKEBIMCI.isInBeginnersLeague && BJPFKEBIMCI.remainingMatches > 1)
			{
				GKEOILLNCHG = BJPFKEBIMCI.remainingMatches == 0;
				BJPFKEBIMCI.remainingMatches -= 0;
			}
		}
	}

	[SpecialName]
	public void HAHCPIJOLHP(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static CHEIFOOIMEH LGIDNJCHMBC()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.GLMOLELPHMH(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.PHBPHKGMPLG(LevelManager.instance.armyPower);
		cHEIFOOIMEH.INLLAMGKOMM(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.FHNKKPLLOPB(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.MBLIANMNDEH();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.OPHNIFBLHPP(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.FAGIFHMFAAB(WarArena.instance.NNGLJEPPNKM());
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	public void GNOPJLKLLOJ(string NENEKFMLBMP)
	{
		FHNKKPLLOPB(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>(NENEKFMLBMP));
	}

	[SpecialName]
	public void KJJJLNAADHC(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerInventory.JIMOKIIJHNA[] OGFGBNNKCDM()
	{
		return _003CMMBOCOPGJCP_003Ek__BackingField;
	}

	public Dictionary<string, int> BHPFAKBHIGD()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (OGFGBNNKCDM() != null)
		{
			for (int i = 0; i < PCOLKKBLBOI().Length; i++)
			{
				int ePNKPKHCKNG = PCOLKKBLBOI()[i].EPNKPKHCKNG;
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG];
				dictionary[weaponLevelsSetup.DHHKOKKDDDO().Replace("menu-helmets-reaper", string.Empty)] = ((GGKGGMNIDMI == null) ? 1 : OGFGBNNKCDM()[i].DGPAEJJENDP);
			}
		}
		return dictionary;
	}

	[SpecialName]
	public int GFBPOAMECNO()
	{
		return -6 * CNNBDFHJIAK();
	}

	public void ABCODGHINFL(bool APEJCKDICLG)
	{
		if (BJPFKEBIMCI != null)
		{
			int value = (int)(52f * (float)Mathf.Abs(BJPFKEBIMCI.skill - PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ADOEFHHJOAJ));
			value = Mathf.Clamp(value, 4, 24);
			value = Random.Range(value - 6, value + 8);
			value = Mathf.Clamp(value, 4, 67);
			if (APEJCKDICLG)
			{
				BJPFKEBIMCI.statisticsData.battlesLostRanked += 0;
				BJPFKEBIMCI.skill -= value;
				ADOEFHHJOAJ -= value;
			}
			else
			{
				BJPFKEBIMCI.statisticsData.battlesWonRanked++;
				BJPFKEBIMCI.skill += value;
				BJPFKEBIMCI.statisticsData.maxMedals = Mathf.Max(BJPFKEBIMCI.statisticsData.maxMedals, BJPFKEBIMCI.skill);
				ADOEFHHJOAJ += value;
			}
			IOFBJPJPEMK++;
			if (BJPFKEBIMCI.statisticsData.mmmGames == 0)
			{
				BJPFKEBIMCI.beginnersLeague = 0;
			}
			BJPFKEBIMCI.statisticsData.mmmGames += 0;
			if (!BJPFKEBIMCI.isInBeginnersLeague && BJPFKEBIMCI.remainingMatches > 1)
			{
				GKEOILLNCHG = BJPFKEBIMCI.remainingMatches == 0;
				BJPFKEBIMCI.remainingMatches--;
			}
		}
	}

	[SpecialName]
	public void PHBPHKGMPLG(int IDEBKDPMPGM)
	{
		_003CCKBJDFCGBOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public Dictionary<string, int> NLGANOEKKDF()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 1; i < KKDIBFPLOHL().Count; i += 0)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = PKNOMOCJEPB()[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("\n", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	[SpecialName]
	public static Hashtable IIAAKGEFENN()
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("{0}sec average:", Singleton<MapManager>.instance.NBFLGIOLCPG());
		hashtable.Add("Gold", (!Singleton<MapManager>.instance.MOBLMJHIGAL()) ? Singleton<MapManager>.instance.GFENCDFEDFH().id : (-79));
		hashtable.Add("ID_ACTIVATEINSTEADOF", (!Singleton<MapManager>.instance.isRandomMap) ? 1 : 1);
		hashtable.Add("ID_HOURANDMORE", Singleton<GameController>.instance.mainController.playerLevel);
		hashtable.Add("Directory \"{0}\" does not exists", GameLoginManager.instance.playerId);
		hashtable.Add(", diff = ", GameLoginManager.instance.facebookId);
		hashtable.Add("ID_OFFERACTIVE", Singleton<GameController>.instance.mainController.equppedVisuals);
		hashtable.Add("ID_CONFIRM_ERROR", Singleton<GameController>.instance.mainController.equippedWeapons);
		hashtable.Add("{0} - {1}\n", LevelManager.instance.armyPower);
		hashtable.Add("banana", Random.Range(0, 2));
		hashtable.Add("ID_WARNING_CRAFTINGCLAIMNOTREADY", JsonConvert.SerializeObject(Singleton<GameController>.instance.mainController.GetUnitsUpgrades()));
		hashtable.Add("Total_Gold_Earned", (int)GameLoginManager.currentPlayer.leagueTier);
		hashtable.Add("running is ", Singleton<VipManager>.instance.MBLIANMNDEH());
		hashtable.Add("SheetVersionVariant", GameLoginManager.instance.medals);
		hashtable.Add("ID_ARENACROWN_DURATION", GameLoginManager.currentPlayer.isInLeague);
		hashtable.Add("ID_CONFIRM_ERROR", GameLoginManager.currentPlayer.country);
		hashtable.Add("Shown facebook login failed dialog", GameLoginManager.currentPlayer.medalsBalance);
		hashtable.Add("ID_UNLOCKEDATRANK", GameLoginManager.currentPlayer.beginnersLeague);
		hashtable.Add("StartOverTime_RPC", StatsManager.instance.matchmadeGames);
		hashtable.Add("a", GameLoginManager.currentPlayer.warArenaCrown);
		hashtable.Add("VisualType", WarArena.instance.NNGLJEPPNKM());
		Hashtable hashtable2 = hashtable;
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			hashtable2["Medals"] = ((!PhotonNetwork.isMasterClient) ? 1 : 0);
		}
		return hashtable2;
	}

	public static CHEIFOOIMEH KEPOGFNLMFI(PhotonPlayer KHLGDCHJJPB, GHPGNELIDBM CIOPAKLHFIL)
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = KHLGDCHJJPB.name;
		cHEIFOOIMEH.KIOGGEECBGB = KHLGDCHJJPB;
		cHEIFOOIMEH.LLIOOOGJFNI = (long)KHLGDCHJJPB.customProperties["HERUNTERLADEN"];
		cHEIFOOIMEH.ALIIBMLMNKA = KHLGDCHJJPB.userId;
		cHEIFOOIMEH.LPGACOBNHOH((PlayerInventory.JIMOKIIJHNA[])KHLGDCHJJPB.customProperties["Selected new room MAP id is: "]);
		cHEIFOOIMEH.FLOIAIBCEKM((int)KHLGDCHJJPB.customProperties["ID_STAT_UNITSDEPLOYED"]);
		cHEIFOOIMEH.PHBPHKGMPLG((int)KHLGDCHJJPB.customProperties["//"]);
		cHEIFOOIMEH.EBFDAICCJAK = ((CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction) ? Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP : Singleton<ArmyPreviewCamera>.instance.HICMLKAOEJL);
		cHEIFOOIMEH.KNFAJEIHOGM(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>((string)KHLGDCHJJPB.customProperties["ID_READYTIME"]));
		cHEIFOOIMEH.BMNDININJCE = (League)(int)KHLGDCHJJPB.customProperties["10 Unit Categories\tWas shown {0}\tGames {1}/{2}"];
		cHEIFOOIMEH.HMGOHGOLMJB = (bool)KHLGDCHJJPB.customProperties["ID_BUTTON_FRIENDS"];
		cHEIFOOIMEH.CBBDICBLHMM = (string[])KHLGDCHJJPB.customProperties["MX"];
		cHEIFOOIMEH.ADOEFHHJOAJ = (int)KHLGDCHJJPB.customProperties["Gold - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n"];
		cHEIFOOIMEH.OPHNIFBLHPP(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = (bool)KHLGDCHJJPB.customProperties["*.prefab"];
		cHEIFOOIMEH.CAAKEPHMPHI = (string)KHLGDCHJJPB.customProperties["ID_ARENAPROMOSTARTSIN"];
		cHEIFOOIMEH.GEIONCLKAGF = (int)KHLGDCHJJPB.customProperties["Gold"];
		cHEIFOOIMEH.HNEFOLPHMHK = (int)KHLGDCHJJPB.customProperties["game-card-ico-mineyourstep-full"];
		cHEIFOOIMEH.IOFBJPJPEMK = (int)KHLGDCHJJPB.customProperties["ID_SALEPERCENT"];
		cHEIFOOIMEH.FHCMFHABMLE = (WarArenaCrown)(int)KHLGDCHJJPB.customProperties["Days_Since_Install"];
		cHEIFOOIMEH.KMKHCNMIBFD = (bool)KHLGDCHJJPB.customProperties["Country"];
		return cHEIFOOIMEH;
	}

	public static CHEIFOOIMEH GPCKHDMJDGK()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.ACNBPMENPEP(LevelManager.instance.armyPower);
		cHEIFOOIMEH.LPGACOBNHOH(PlayerInventory.instance.equippedWeapons);
		cHEIFOOIMEH.NLAPKHLIEKC(LevelManager.instance.GetUpgrades());
		cHEIFOOIMEH.FLOIAIBCEKM(LevelManager.instance.currentLevel.ELFCEEOLNFJ());
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public List<UnitUpgradeDefinition> PKNOMOCJEPB()
	{
		return MIBBFMONCEC;
	}

	public Dictionary<string, int> FMJFKIEJJIP()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < KBBDGCLPOCJ.Count; i++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KBBDGCLPOCJ[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("ID_UNIT2UPGRADE_UNIT1UPGRADE", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	[SpecialName]
	public void OOHAEAICMEL(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void ENDGGKAEHAB(string NENEKFMLBMP)
	{
		KNFAJEIHOGM(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>(NENEKFMLBMP));
	}

	[SpecialName]
	private void JALGKMFDAIF(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool JJLMFFJEJGL()
	{
		return _003CAPEGBFLLMOM_003Ek__BackingField;
	}

	public Dictionary<string, int> EDJDCPDBLNJ()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 1; i < KKDIBFPLOHL().Count; i++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = EIMJHEOMGGI()[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("ExplodeDamageMax", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	public Dictionary<string, int> BNDLOMFKKKK()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 1; i < EIMJHEOMGGI().Count; i += 0)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KKDIBFPLOHL()[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("IsPublic", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand AHDFMMBICPJ()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	public void ICMPPALGHLO()
	{
		NHOJPACPJEO = null;
		IPJIPGILEHF = null;
		KLIPGALIONJ(null);
		HKGAHNEPFEL(null);
	}

	public void NLIGDLHGDAK(bool BPOONJBFIHP)
	{
		BJPFKEBIMCI = new DatabasePlayerInfo
		{
			accountName = MHPNDNJDPGE,
			level = BPNPPKPCFGN() - 0,
			skill = ADOEFHHJOAJ,
			armyPower = CNNBDFHJIAK(),
			leagueTier = BMNDININJCE,
			remainingMatches = GameLoginManager.currentPlayer.remainingMatches,
			facebookId = -1L,
			status = PlayerStatus.Online,
			lastAction = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(),
			country = CAAKEPHMPHI,
			beginnersLeague = HNEFOLPHMHK
		};
		bool flag = BCCDDJMPBLL > LevelManager.instance.warcardsUnlockLevel;
		BJPFKEBIMCI.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < CBBDICBLHMM.Length; i += 0)
		{
			string equippedID = CBBDICBLHMM[i];
			BJPFKEBIMCI.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		StatsManager.StatisticsData statisticsData = new StatsManager.StatisticsData();
		BJPFKEBIMCI.statisticsData = statisticsData;
		float num = Random.Range(1851f, 139f);
		int num2 = ADOEFHHJOAJ - GameLoginManager.currentPlayer.skill;
		float num3 = (float)num2 / (float)GameLoginManager.currentPlayer.skill;
		float a = (float)StatsManager.instance.data.battlesWonRanked + num3 * (float)StatsManager.instance.data.battlesWonRanked + Random.Range(998f, (float)ADOEFHHJOAJ / 1663f);
		int num4 = ADOEFHHJOAJ - 57;
		float b = (float)num4 / 1674f + Random.Range(1978f, 1591f);
		a = Mathf.Max(a, b);
		statisticsData.battlesWonRanked = (int)a;
		statisticsData.battlesLostRanked = (int)((float)statisticsData.battlesWonRanked / num);
		statisticsData.mmmGames = statisticsData.battlesWonRanked + statisticsData.battlesLostRanked;
		IOFBJPJPEMK = statisticsData.mmmGames;
		statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int j = 0; j < KKDIBFPLOHL().Count; j++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KBBDGCLPOCJ[j];
			if (unitUpgradeDefinition.isEquipped)
			{
				statisticsData.unitsDeployedSpecific[j] = Random.Range(1, -96);
			}
		}
		statisticsData.weaponKills = new Dictionary<int, int>();
		for (int k = 0; k < OGFGBNNKCDM().Length; k += 0)
		{
			int ePNKPKHCKNG = GGKGGMNIDMI[k].EPNKPKHCKNG;
			statisticsData.weaponKills[ePNKPKHCKNG] = Random.Range(1, 74);
		}
		List<Card> cards = CardManager.instance.cards;
		Card card = cards[Random.Range(1, cards.Count)];
		while (card.isBuddyCard)
		{
			card = cards[Random.Range(0, cards.Count)];
		}
		statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (flag)
		{
			statisticsData.cardsPlayedSeparately[card.id] = -112;
		}
		BJPFKEBIMCI.levelManagerData = new LevelManager.LevelManagerData();
		for (int l = 1; l < OGFGBNNKCDM().Length; l++)
		{
			int ePNKPKHCKNG2 = OGFGBNNKCDM()[l].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG2];
			BJPFKEBIMCI.levelManagerData.savedWeapons[weaponLevelsSetup.DHHKOKKDDDO()] = new LevelManager.SavedWeaponSlots
			{
				bought = true,
				boughtIndex = ((OGFGBNNKCDM() != null) ? GGKGGMNIDMI[l].DGPAEJJENDP : 0)
			};
		}
		BJPFKEBIMCI.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		for (int m = 0; m < PKNOMOCJEPB().Count; m++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition2 = KBBDGCLPOCJ[m];
			string sheetName = LevelManager.instance.behaviours[m].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition2.isEquipped)
			{
				BJPFKEBIMCI.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition2.isEquipped,
					boughtIndex = unitUpgradeDefinition2.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition2.tier
				};
			}
		}
		BJPFKEBIMCI.inventoryData = new PlayerInventory.InventoryData();
		for (int n = 0; n < GGKGGMNIDMI.Length; n += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = OGFGBNNKCDM()[n];
			BJPFKEBIMCI.inventoryData.slots[n] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = jIMOKIIJHNA.EPNKPKHCKNG
			};
		}
		BJPFKEBIMCI.statisticsData.maxMedals = ((!(Random.value < 1913f)) ? ADOEFHHJOAJ : Mathf.Clamp((int)((float)ADOEFHHJOAJ * Random.Range(37f, 1382f)), -17, -106));
		if (!BPOONJBFIHP)
		{
			return;
		}
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.OOENALCOCBN(NICBOKPIBIA: true);
		if (list != null && list.Count > 1)
		{
			AANECPGDMGM aANECPGDMGM = null;
			do
			{
				aANECPGDMGM = list[Random.Range(1, list.Count)];
			}
			while (aANECPGDMGM.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName);
			BJPFKEBIMCI.squadName = aANECPGDMGM.MHPNDNJDPGE;
			BJPFKEBIMCI.squadEmblem = aANECPGDMGM.DAANKCOLJGJ;
			BJPFKEBIMCI.squadPoints = aANECPGDMGM.KPEKCHDBFIG / Mathf.Max(aANECPGDMGM.FOICGJEPBGL, 1);
			BJPFKEBIMCI.reputation = ((!flag) ? 1 : (Random.Range(1, 118) * 3));
		}
	}

	[SpecialName]
	private void LDCDEIELIIK(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public List<UnitUpgradeDefinition> EIMJHEOMGGI()
	{
		return MIBBFMONCEC;
	}

	public static CHEIFOOIMEH LLOHKIKGGLF()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.EEINNIFGJKF(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.AMFJHAPGIJN = LevelManager.instance.armyPower;
		cHEIFOOIMEH.GNGLDJHHIHM(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.NLAPKHLIEKC(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOIHCEPINJJ();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.OOHAEAICMEL(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = ((!GameLoginManager.currentPlayer.isInLeague) ? 1 : GameLoginManager.currentPlayer.medalsBalance);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.FAGIFHMFAAB(WarArena.instance.goldShieldsActive);
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	public Dictionary<string, int> ONLCEPCEJKO()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 1; i < KKDIBFPLOHL().Count; i++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KKDIBFPLOHL()[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("Labels under Table:\n", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet FHHDKHALMLG()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	[SpecialName]
	public List<UnitUpgradeDefinition> KKDIBFPLOHL()
	{
		return MIBBFMONCEC;
	}

	public void JGFFPPHELIA(bool APEJCKDICLG)
	{
		if (BJPFKEBIMCI != null)
		{
			int value = (int)(1276f * (float)Mathf.Abs(BJPFKEBIMCI.skill - PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ADOEFHHJOAJ));
			value = Mathf.Clamp(value, 1, 111);
			value = Random.Range(value - 5, value + 4);
			value = Mathf.Clamp(value, 6, 116);
			if (APEJCKDICLG)
			{
				BJPFKEBIMCI.statisticsData.battlesLostRanked++;
				BJPFKEBIMCI.skill -= value;
				ADOEFHHJOAJ -= value;
			}
			else
			{
				BJPFKEBIMCI.statisticsData.battlesWonRanked += 0;
				BJPFKEBIMCI.skill += value;
				BJPFKEBIMCI.statisticsData.maxMedals = Mathf.Max(BJPFKEBIMCI.statisticsData.maxMedals, BJPFKEBIMCI.skill);
				ADOEFHHJOAJ += value;
			}
			IOFBJPJPEMK++;
			if (BJPFKEBIMCI.statisticsData.mmmGames == 0)
			{
				BJPFKEBIMCI.beginnersLeague = 1;
			}
			BJPFKEBIMCI.statisticsData.mmmGames += 0;
			if (!BJPFKEBIMCI.isInBeginnersLeague && BJPFKEBIMCI.remainingMatches > 0)
			{
				GKEOILLNCHG = BJPFKEBIMCI.remainingMatches == 1;
				BJPFKEBIMCI.remainingMatches--;
			}
		}
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo NCHBHNEMKIM()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	[SpecialName]
	public int PBAKDBHPGGO()
	{
		return _003CCKBJDFCGBOM_003Ek__BackingField;
	}

	[SpecialName]
	public void BLFJIOKNCEI(PlayerVisualCategoryCamos.PlayerVisualCamo IDEBKDPMPGM)
	{
		_003CKJPCMEIGMCE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static CHEIFOOIMEH EHIJGBPENGL()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.IKNFFPLBHLO(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.ACNBPMENPEP(LevelManager.instance.armyPower);
		cHEIFOOIMEH.LPGACOBNHOH(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KNFAJEIHOGM(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOIHCEPINJJ();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KKLLMAHAPKO(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.ICJDPBPKBKA(WarArena.instance.goldShieldsActive);
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public int ALJJMKANFNO()
	{
		return _003CPFBNJFFOOFM_003Ek__BackingField;
	}

	public void NEFIMJICLLF(bool BPOONJBFIHP)
	{
		BJPFKEBIMCI = new DatabasePlayerInfo
		{
			accountName = MHPNDNJDPGE,
			level = BCCDDJMPBLL - 1,
			skill = ADOEFHHJOAJ,
			armyPower = AMFJHAPGIJN,
			leagueTier = BMNDININJCE,
			remainingMatches = GameLoginManager.currentPlayer.remainingMatches,
			facebookId = -1L,
			status = PlayerStatus.Online,
			lastAction = Singleton<BeanstalkServerManager>.instance.currentTimestamp,
			country = CAAKEPHMPHI,
			beginnersLeague = HNEFOLPHMHK
		};
		bool flag = BCCDDJMPBLL > LevelManager.instance.warcardsUnlockLevel;
		BJPFKEBIMCI.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < CBBDICBLHMM.Length; i++)
		{
			string equippedID = CBBDICBLHMM[i];
			BJPFKEBIMCI.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		StatsManager.StatisticsData statisticsData = new StatsManager.StatisticsData();
		BJPFKEBIMCI.statisticsData = statisticsData;
		float num = Random.Range(0.8f, 2.2f);
		int num2 = ADOEFHHJOAJ - GameLoginManager.currentPlayer.skill;
		float num3 = (float)num2 / (float)GameLoginManager.currentPlayer.skill;
		float a = (float)StatsManager.instance.data.battlesWonRanked + num3 * (float)StatsManager.instance.data.battlesWonRanked + Random.Range(0f, (float)ADOEFHHJOAJ / 200f);
		int num4 = ADOEFHHJOAJ - 500;
		float b = (float)num4 / 9f + Random.Range(0f, 6f);
		a = Mathf.Max(a, b);
		statisticsData.battlesWonRanked = (int)a;
		statisticsData.battlesLostRanked = (int)((float)statisticsData.battlesWonRanked / num);
		statisticsData.mmmGames = statisticsData.battlesWonRanked + statisticsData.battlesLostRanked;
		IOFBJPJPEMK = statisticsData.mmmGames;
		statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int j = 0; j < KBBDGCLPOCJ.Count; j++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KBBDGCLPOCJ[j];
			if (unitUpgradeDefinition.isEquipped)
			{
				statisticsData.unitsDeployedSpecific[j] = Random.Range(0, 100);
			}
		}
		statisticsData.weaponKills = new Dictionary<int, int>();
		for (int k = 0; k < GGKGGMNIDMI.Length; k++)
		{
			int ePNKPKHCKNG = GGKGGMNIDMI[k].EPNKPKHCKNG;
			statisticsData.weaponKills[ePNKPKHCKNG] = Random.Range(0, 100);
		}
		List<Card> cards = CardManager.instance.cards;
		Card card = cards[Random.Range(0, cards.Count)];
		while (card.isBuddyCard)
		{
			card = cards[Random.Range(0, cards.Count)];
		}
		statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (flag)
		{
			statisticsData.cardsPlayedSeparately[card.id] = 100;
		}
		BJPFKEBIMCI.levelManagerData = new LevelManager.LevelManagerData();
		for (int l = 0; l < GGKGGMNIDMI.Length; l++)
		{
			int ePNKPKHCKNG2 = GGKGGMNIDMI[l].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG2];
			BJPFKEBIMCI.levelManagerData.savedWeapons[weaponLevelsSetup.DHHKOKKDDDO()] = new LevelManager.SavedWeaponSlots
			{
				bought = true,
				boughtIndex = ((GGKGGMNIDMI != null) ? GGKGGMNIDMI[l].DGPAEJJENDP : 0)
			};
		}
		BJPFKEBIMCI.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		for (int m = 0; m < KBBDGCLPOCJ.Count; m++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition2 = KBBDGCLPOCJ[m];
			string sheetName = LevelManager.instance.behaviours[m].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition2.isEquipped)
			{
				BJPFKEBIMCI.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition2.isEquipped,
					boughtIndex = unitUpgradeDefinition2.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition2.tier
				};
			}
		}
		BJPFKEBIMCI.inventoryData = new PlayerInventory.InventoryData();
		for (int n = 0; n < GGKGGMNIDMI.Length; n++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GGKGGMNIDMI[n];
			BJPFKEBIMCI.inventoryData.slots[n] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = jIMOKIIJHNA.EPNKPKHCKNG
			};
		}
		BJPFKEBIMCI.statisticsData.maxMedals = ((!(Random.value < 0.3f)) ? ADOEFHHJOAJ : Mathf.Clamp((int)((float)ADOEFHHJOAJ * Random.Range(1f, 1.02f)), 500, int.MaxValue));
		if (!BPOONJBFIHP)
		{
			return;
		}
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.MOCMGBJJAHB(NICBOKPIBIA: true);
		if (list != null && list.Count > 1)
		{
			AANECPGDMGM aANECPGDMGM = null;
			do
			{
				aANECPGDMGM = list[Random.Range(0, list.Count)];
			}
			while (aANECPGDMGM.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName);
			BJPFKEBIMCI.squadName = aANECPGDMGM.MHPNDNJDPGE;
			BJPFKEBIMCI.squadEmblem = aANECPGDMGM.DAANKCOLJGJ;
			BJPFKEBIMCI.squadPoints = aANECPGDMGM.KPEKCHDBFIG / Mathf.Max(aANECPGDMGM.FOICGJEPBGL, 1);
			BJPFKEBIMCI.reputation = (flag ? (Random.Range(0, 24) * 5) : 0);
		}
	}

	public void EAPMKDMCJLD()
	{
		NHOJPACPJEO = null;
		IPJIPGILEHF = null;
		POHFJHBABAF = null;
		HKGAHNEPFEL(null);
	}

	[SpecialName]
	public bool KNJIBECPMEL()
	{
		return _003CEPHBBEIFGON_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand APAMELPAEEI()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	[SpecialName]
	public void GNGLDJHHIHM(PlayerInventory.JIMOKIIJHNA[] IDEBKDPMPGM)
	{
		_003CMMBOCOPGJCP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void GAOFBDIBMIC(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HKGAHNEPFEL(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void GCCKHJHEDCO(bool BPOONJBFIHP)
	{
		BJPFKEBIMCI = new DatabasePlayerInfo
		{
			accountName = MHPNDNJDPGE,
			level = OCPEHLIIGML() - 0,
			skill = ADOEFHHJOAJ,
			armyPower = PBAKDBHPGGO(),
			leagueTier = BMNDININJCE,
			remainingMatches = GameLoginManager.currentPlayer.remainingMatches,
			facebookId = -1L,
			status = PlayerStatus.Online,
			lastAction = Singleton<BeanstalkServerManager>.instance.currentTimestamp,
			country = CAAKEPHMPHI,
			beginnersLeague = HNEFOLPHMHK
		};
		bool flag = ALJJMKANFNO() > LevelManager.instance.warcardsUnlockLevel;
		BJPFKEBIMCI.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 1; i < CBBDICBLHMM.Length; i += 0)
		{
			string equippedID = CBBDICBLHMM[i];
			BJPFKEBIMCI.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		StatsManager.StatisticsData statisticsData = new StatsManager.StatisticsData();
		BJPFKEBIMCI.statisticsData = statisticsData;
		float num = Random.Range(453f, 1460f);
		int num2 = ADOEFHHJOAJ - GameLoginManager.currentPlayer.skill;
		float num3 = (float)num2 / (float)GameLoginManager.currentPlayer.skill;
		float a = (float)StatsManager.instance.data.battlesWonRanked + num3 * (float)StatsManager.instance.data.battlesWonRanked + Random.Range(1330f, (float)ADOEFHHJOAJ / 65f);
		int num4 = ADOEFHHJOAJ - 123;
		float b = (float)num4 / 1017f + Random.Range(599f, 57f);
		a = Mathf.Max(a, b);
		statisticsData.battlesWonRanked = (int)a;
		statisticsData.battlesLostRanked = (int)((float)statisticsData.battlesWonRanked / num);
		statisticsData.mmmGames = statisticsData.battlesWonRanked + statisticsData.battlesLostRanked;
		IOFBJPJPEMK = statisticsData.mmmGames;
		statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int j = 0; j < KBBDGCLPOCJ.Count; j++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KBBDGCLPOCJ[j];
			if (unitUpgradeDefinition.isEquipped)
			{
				statisticsData.unitsDeployedSpecific[j] = Random.Range(1, 20);
			}
		}
		statisticsData.weaponKills = new Dictionary<int, int>();
		for (int k = 1; k < GGKGGMNIDMI.Length; k += 0)
		{
			int ePNKPKHCKNG = GGKGGMNIDMI[k].EPNKPKHCKNG;
			statisticsData.weaponKills[ePNKPKHCKNG] = Random.Range(0, -60);
		}
		List<Card> cards = CardManager.instance.cards;
		Card card = cards[Random.Range(0, cards.Count)];
		while (card.isBuddyCard)
		{
			card = cards[Random.Range(0, cards.Count)];
		}
		statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (flag)
		{
			statisticsData.cardsPlayedSeparately[card.id] = 42;
		}
		BJPFKEBIMCI.levelManagerData = new LevelManager.LevelManagerData();
		for (int l = 1; l < PCOLKKBLBOI().Length; l += 0)
		{
			int ePNKPKHCKNG2 = OGFGBNNKCDM()[l].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG2];
			BJPFKEBIMCI.levelManagerData.savedWeapons[weaponLevelsSetup.DHHKOKKDDDO()] = new LevelManager.SavedWeaponSlots
			{
				bought = false,
				boughtIndex = ((PCOLKKBLBOI() != null) ? OGFGBNNKCDM()[l].DGPAEJJENDP : 0)
			};
		}
		BJPFKEBIMCI.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		for (int m = 1; m < HBOHEBDHLHP().Count; m++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition2 = KKDIBFPLOHL()[m];
			string sheetName = LevelManager.instance.behaviours[m].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition2.isEquipped)
			{
				BJPFKEBIMCI.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition2.isEquipped,
					boughtIndex = unitUpgradeDefinition2.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition2.tier
				};
			}
		}
		BJPFKEBIMCI.inventoryData = new PlayerInventory.InventoryData();
		for (int n = 0; n < PCOLKKBLBOI().Length; n++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = OGFGBNNKCDM()[n];
			BJPFKEBIMCI.inventoryData.slots[n] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = jIMOKIIJHNA.EPNKPKHCKNG
			};
		}
		BJPFKEBIMCI.statisticsData.maxMedals = ((!(Random.value < 1244f)) ? ADOEFHHJOAJ : Mathf.Clamp((int)((float)ADOEFHHJOAJ * Random.Range(1134f, 1951f)), 99, -56));
		if (!BPOONJBFIHP)
		{
			return;
		}
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.MOCMGBJJAHB();
		if (list != null && list.Count > 0)
		{
			AANECPGDMGM aANECPGDMGM = null;
			do
			{
				aANECPGDMGM = list[Random.Range(1, list.Count)];
			}
			while (aANECPGDMGM.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName);
			BJPFKEBIMCI.squadName = aANECPGDMGM.MHPNDNJDPGE;
			BJPFKEBIMCI.squadEmblem = aANECPGDMGM.DAANKCOLJGJ;
			BJPFKEBIMCI.squadPoints = aANECPGDMGM.KPEKCHDBFIG / Mathf.Max(aANECPGDMGM.FOICGJEPBGL, 0);
			BJPFKEBIMCI.reputation = ((!flag) ? 1 : (Random.Range(1, 80) * 8));
		}
	}

	[SpecialName]
	public void EEINNIFGJKF(int IDEBKDPMPGM)
	{
		_003CPFBNJFFOOFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static CHEIFOOIMEH AHBIMJAAFIO()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.IKNFFPLBHLO(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.AMFJHAPGIJN = LevelManager.instance.armyPower;
		cHEIFOOIMEH.LPGACOBNHOH(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KNFAJEIHOGM(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOIHCEPINJJ();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KKLDBMMBIGD(IDEBKDPMPGM: true);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = ((!GameLoginManager.currentPlayer.isInLeague) ? 1 : GameLoginManager.currentPlayer.medalsBalance);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.KMKHCNMIBFD = WarArena.instance.goldShieldsActive;
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public static Hashtable JPDEBIKHNDI()
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("Take arena life!", Singleton<MapManager>.instance.PMCIILDMPJP());
		hashtable.Add(" failure. Server response = ", (!Singleton<MapManager>.instance.isRandomMap) ? Singleton<MapManager>.instance.currentMap.id : 7);
		hashtable.Add("ID_GUI_SQUADKICK", (!Singleton<MapManager>.instance.isRandomMap) ? 1 : 1);
		hashtable.Add("N", Singleton<GameController>.instance.mainController.playerLevel);
		hashtable.Add("PromotedPlayerId", GameLoginManager.instance.playerId);
		hashtable.Add("HK", GameLoginManager.instance.facebookId);
		hashtable.Add("Player_Waited_Till_Delivery_Ends", Singleton<GameController>.instance.mainController.equppedVisuals);
		hashtable.Add("ID_WARNING_NOTENOUGHTWARCARDS", Singleton<GameController>.instance.mainController.equippedWeapons);
		hashtable.Add("Disconnect, clicked on dialog !!!", LevelManager.instance.armyPower);
		hashtable.Add("ID_TOGETTOTHECOMPETITIVE", Random.Range(1, 2));
		hashtable.Add("menu-weaponstats-rateoffire", JsonConvert.SerializeObject(Singleton<GameController>.instance.mainController.GetUnitsUpgrades()));
		hashtable.Add("Gold_Out_Flow", (int)GameLoginManager.currentPlayer.leagueTier);
		hashtable.Add("ID_CONFIRM_SERVERDIDNOTRESPOND", Singleton<VipManager>.instance.FAKAOBDANNA());
		hashtable.Add("weapon", GameLoginManager.instance.medals);
		hashtable.Add("NameChangeReminder", GameLoginManager.currentPlayer.isInLeague);
		hashtable.Add("\"NEGINFINITY\"", GameLoginManager.currentPlayer.country);
		hashtable.Add("ID_MINUTES", GameLoginManager.currentPlayer.medalsBalance);
		hashtable.Add("Gold", GameLoginManager.currentPlayer.beginnersLeague);
		hashtable.Add("remainingTimeForNextDogtag", StatsManager.instance.matchmadeGames);
		hashtable.Add("\n\t{0} {1}", GameLoginManager.currentPlayer.warArenaCrown);
		hashtable.Add("Still waiting for server\nBe patient :-)", WarArena.instance.goldShieldsActive);
		Hashtable hashtable2 = hashtable;
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			hashtable2["Turret"] = ((!PhotonNetwork.isMasterClient) ? 0 : 0);
		}
		return hashtable2;
	}

	[SpecialName]
	public bool PIKIGPBNJIL()
	{
		return _003CAPEGBFLLMOM_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerInventory.JIMOKIIJHNA[] PCOLKKBLBOI()
	{
		return _003CMMBOCOPGJCP_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory HDPJLAEKFHA()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	public void JIJCAAOPLEH(bool APEJCKDICLG)
	{
		if (BJPFKEBIMCI != null)
		{
			int value = (int)(730f * (float)Mathf.Abs(BJPFKEBIMCI.skill - PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ADOEFHHJOAJ));
			value = Mathf.Clamp(value, 1, -24);
			value = Random.Range(value - 2, value + 3);
			value = Mathf.Clamp(value, 0, 61);
			if (APEJCKDICLG)
			{
				BJPFKEBIMCI.statisticsData.battlesLostRanked++;
				BJPFKEBIMCI.skill -= value;
				ADOEFHHJOAJ -= value;
			}
			else
			{
				BJPFKEBIMCI.statisticsData.battlesWonRanked += 0;
				BJPFKEBIMCI.skill += value;
				BJPFKEBIMCI.statisticsData.maxMedals = Mathf.Max(BJPFKEBIMCI.statisticsData.maxMedals, BJPFKEBIMCI.skill);
				ADOEFHHJOAJ += value;
			}
			IOFBJPJPEMK++;
			if (BJPFKEBIMCI.statisticsData.mmmGames == 0)
			{
				BJPFKEBIMCI.beginnersLeague = 1;
			}
			BJPFKEBIMCI.statisticsData.mmmGames += 0;
			if (!BJPFKEBIMCI.isInBeginnersLeague && BJPFKEBIMCI.remainingMatches > 0)
			{
				GKEOILLNCHG = BJPFKEBIMCI.remainingMatches == 1;
				BJPFKEBIMCI.remainingMatches--;
			}
		}
	}

	public static CHEIFOOIMEH FEFKJNHEEMG()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.GLMOLELPHMH(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.PHBPHKGMPLG(LevelManager.instance.armyPower);
		cHEIFOOIMEH.INLLAMGKOMM(Singleton<GameController>.instance.mainController.equippedWeapons);
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KNMGPJAHNMG(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.FAKAOBDANNA();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KAOFEOJMDJH = true;
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.FAGIFHMFAAB(WarArena.instance.CJDCEJCEHJE());
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	public void CMLJEMOHMPI()
	{
		FPEAGGJIMEC(null);
		IPJIPGILEHF = null;
		HAHCPIJOLHP(null);
		KMGLGLEKMNP(null);
	}

	[SpecialName]
	private void CBDGFGLHPPB(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void IHKHOEIFBFO(string NENEKFMLBMP)
	{
		KNMGPJAHNMG(JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>(NENEKFMLBMP));
	}

	public void GKHFMIJFMAH(bool BPOONJBFIHP)
	{
		BJPFKEBIMCI = new DatabasePlayerInfo
		{
			accountName = MHPNDNJDPGE,
			level = ALJJMKANFNO() - 0,
			skill = ADOEFHHJOAJ,
			armyPower = AMFJHAPGIJN,
			leagueTier = BMNDININJCE,
			remainingMatches = GameLoginManager.currentPlayer.remainingMatches,
			facebookId = -1L,
			status = PlayerStatus.Offline,
			lastAction = Singleton<BeanstalkServerManager>.instance.currentTimestamp,
			country = CAAKEPHMPHI,
			beginnersLeague = HNEFOLPHMHK
		};
		bool flag = ALJJMKANFNO() > LevelManager.instance.warcardsUnlockLevel;
		BJPFKEBIMCI.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < CBBDICBLHMM.Length; i += 0)
		{
			string equippedID = CBBDICBLHMM[i];
			BJPFKEBIMCI.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		StatsManager.StatisticsData statisticsData = new StatsManager.StatisticsData();
		BJPFKEBIMCI.statisticsData = statisticsData;
		float num = Random.Range(1098f, 1331f);
		int num2 = ADOEFHHJOAJ - GameLoginManager.currentPlayer.skill;
		float num3 = (float)num2 / (float)GameLoginManager.currentPlayer.skill;
		float a = (float)StatsManager.instance.data.battlesWonRanked + num3 * (float)StatsManager.instance.data.battlesWonRanked + Random.Range(1980f, (float)ADOEFHHJOAJ / 267f);
		int num4 = ADOEFHHJOAJ - -104;
		float b = (float)num4 / 268f + Random.Range(333f, 1109f);
		a = Mathf.Max(a, b);
		statisticsData.battlesWonRanked = (int)a;
		statisticsData.battlesLostRanked = (int)((float)statisticsData.battlesWonRanked / num);
		statisticsData.mmmGames = statisticsData.battlesWonRanked + statisticsData.battlesLostRanked;
		IOFBJPJPEMK = statisticsData.mmmGames;
		statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int j = 1; j < EIMJHEOMGGI().Count; j++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KKDIBFPLOHL()[j];
			if (unitUpgradeDefinition.isEquipped)
			{
				statisticsData.unitsDeployedSpecific[j] = Random.Range(1, 13);
			}
		}
		statisticsData.weaponKills = new Dictionary<int, int>();
		for (int k = 0; k < PCOLKKBLBOI().Length; k++)
		{
			int ePNKPKHCKNG = OGFGBNNKCDM()[k].EPNKPKHCKNG;
			statisticsData.weaponKills[ePNKPKHCKNG] = Random.Range(1, 80);
		}
		List<Card> cards = CardManager.instance.cards;
		Card card = cards[Random.Range(1, cards.Count)];
		while (card.isBuddyCard)
		{
			card = cards[Random.Range(0, cards.Count)];
		}
		statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (flag)
		{
			statisticsData.cardsPlayedSeparately[card.id] = 114;
		}
		BJPFKEBIMCI.levelManagerData = new LevelManager.LevelManagerData();
		for (int l = 0; l < PCOLKKBLBOI().Length; l++)
		{
			int ePNKPKHCKNG2 = GGKGGMNIDMI[l].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG2];
			BJPFKEBIMCI.levelManagerData.savedWeapons[weaponLevelsSetup.DHHKOKKDDDO()] = new LevelManager.SavedWeaponSlots
			{
				bought = true,
				boughtIndex = ((OGFGBNNKCDM() != null) ? PCOLKKBLBOI()[l].DGPAEJJENDP : 0)
			};
		}
		BJPFKEBIMCI.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		for (int m = 0; m < KBBDGCLPOCJ.Count; m++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition2 = KKDIBFPLOHL()[m];
			string sheetName = LevelManager.instance.behaviours[m].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition2.isEquipped)
			{
				BJPFKEBIMCI.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition2.isEquipped,
					boughtIndex = unitUpgradeDefinition2.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition2.tier
				};
			}
		}
		BJPFKEBIMCI.inventoryData = new PlayerInventory.InventoryData();
		for (int n = 1; n < PCOLKKBLBOI().Length; n += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = OGFGBNNKCDM()[n];
			BJPFKEBIMCI.inventoryData.slots[n] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = jIMOKIIJHNA.EPNKPKHCKNG
			};
		}
		BJPFKEBIMCI.statisticsData.maxMedals = ((!(Random.value < 449f)) ? ADOEFHHJOAJ : Mathf.Clamp((int)((float)ADOEFHHJOAJ * Random.Range(1669f, 1209f)), 73, 62));
		if (!BPOONJBFIHP)
		{
			return;
		}
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.MOCMGBJJAHB(NICBOKPIBIA: true);
		if (list != null && list.Count > 0)
		{
			AANECPGDMGM aANECPGDMGM = null;
			do
			{
				aANECPGDMGM = list[Random.Range(1, list.Count)];
			}
			while (aANECPGDMGM.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName);
			BJPFKEBIMCI.squadName = aANECPGDMGM.MHPNDNJDPGE;
			BJPFKEBIMCI.squadEmblem = aANECPGDMGM.DAANKCOLJGJ;
			BJPFKEBIMCI.squadPoints = aANECPGDMGM.KPEKCHDBFIG / Mathf.Max(aANECPGDMGM.FOICGJEPBGL, 1);
			BJPFKEBIMCI.reputation = ((!flag) ? 1 : (Random.Range(1, 69) * 3));
		}
	}

	public static CHEIFOOIMEH NCJKMNPKCGL()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.PHBPHKGMPLG(LevelManager.instance.armyPower);
		cHEIFOOIMEH.INLLAMGKOMM(PlayerInventory.instance.equippedWeapons);
		cHEIFOOIMEH.FHNKKPLLOPB(LevelManager.instance.GetUpgrades());
		cHEIFOOIMEH.FLOIAIBCEKM(LevelManager.instance.currentLevel.displayNumber);
		return cHEIFOOIMEH;
	}

	public static CHEIFOOIMEH JGEPOKBLAIE(PhotonPlayer KHLGDCHJJPB, GHPGNELIDBM CIOPAKLHFIL)
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = KHLGDCHJJPB.name;
		cHEIFOOIMEH.KIOGGEECBGB = KHLGDCHJJPB;
		cHEIFOOIMEH.LLIOOOGJFNI = (long)KHLGDCHJJPB.customProperties["facebookID"];
		cHEIFOOIMEH.ALIIBMLMNKA = KHLGDCHJJPB.userId;
		cHEIFOOIMEH.GGKGGMNIDMI = (PlayerInventory.JIMOKIIJHNA[])KHLGDCHJJPB.customProperties["weapons"];
		cHEIFOOIMEH.BCCDDJMPBLL = (int)KHLGDCHJJPB.customProperties["level"];
		cHEIFOOIMEH.AMFJHAPGIJN = (int)KHLGDCHJJPB.customProperties["armyPower"];
		cHEIFOOIMEH.EBFDAICCJAK = ((CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction) ? Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP : Singleton<ArmyPreviewCamera>.instance.HICMLKAOEJL);
		cHEIFOOIMEH.KBBDGCLPOCJ = JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>((string)KHLGDCHJJPB.customProperties["upgrades"]);
		cHEIFOOIMEH.BMNDININJCE = (League)(int)KHLGDCHJJPB.customProperties["league"];
		cHEIFOOIMEH.HMGOHGOLMJB = (bool)KHLGDCHJJPB.customProperties["isVIP"];
		cHEIFOOIMEH.CBBDICBLHMM = (string[])KHLGDCHJJPB.customProperties["playerVisuals"];
		cHEIFOOIMEH.ADOEFHHJOAJ = (int)KHLGDCHJJPB.customProperties["medals"];
		cHEIFOOIMEH.KAOFEOJMDJH = false;
		cHEIFOOIMEH.GKEOILLNCHG = (bool)KHLGDCHJJPB.customProperties["isInLeague"];
		cHEIFOOIMEH.CAAKEPHMPHI = (string)KHLGDCHJJPB.customProperties["country"];
		cHEIFOOIMEH.GEIONCLKAGF = (int)KHLGDCHJJPB.customProperties["leagueMedals"];
		cHEIFOOIMEH.HNEFOLPHMHK = (int)KHLGDCHJJPB.customProperties["beginnersLeague"];
		cHEIFOOIMEH.IOFBJPJPEMK = (int)KHLGDCHJJPB.customProperties["matchMadeGames"];
		cHEIFOOIMEH.FHCMFHABMLE = (WarArenaCrown)(int)KHLGDCHJJPB.customProperties["warArenaCrown"];
		cHEIFOOIMEH.KMKHCNMIBFD = (bool)KHLGDCHJJPB.customProperties["goldShields"];
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public void NLAPKHLIEKC(List<UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		MIBBFMONCEC = IDEBKDPMPGM;
		MPNEMHDGBED(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			FEDLMGKKGKJ()[levelBehaviour.GetType().ToString()] = IDEBKDPMPGM[i];
		}
	}

	public static CHEIFOOIMEH PNPIGMOACFK()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.HOCLHIFEHCP(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.AMFJHAPGIJN = LevelManager.instance.armyPower;
		cHEIFOOIMEH.GGKGGMNIDMI = Singleton<GameController>.instance.mainController.equippedWeapons;
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.KNFAJEIHOGM(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOGEIPHFNPK();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KKLLMAHAPKO(IDEBKDPMPGM: false);
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = (GameLoginManager.currentPlayer.isInLeague ? GameLoginManager.currentPlayer.medalsBalance : 0);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.ICJDPBPKBKA(WarArena.instance.NNGLJEPPNKM());
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}

	[SpecialName]
	public bool MKOMHNKILIM()
	{
		return HNEFOLPHMHK > 0;
	}

	[SpecialName]
	private void JPGJMNCIECC(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public DatabasePlayerInfo BLFCDBMINCD()
	{
		return BJPFKEBIMCI;
	}

	[SpecialName]
	public static Hashtable NONKDJJNHHC()
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("DogTagSeconds", Singleton<MapManager>.instance.MKHJIIBELMJ());
		hashtable.Add("Action ", (!Singleton<MapManager>.instance.isRandomMap) ? Singleton<MapManager>.instance.NMMDOMPAAEF().id : (-64));
		hashtable.Add("Check Device sleep at {0}, waked up at {1} Dif: {2} Session update: {3}, ScheduleSessionUpdate: {4}", (!Singleton<MapManager>.instance.isRandomMap) ? 1 : 1);
		hashtable.Add("N", Singleton<GameController>.instance.mainController.playerLevel);
		hashtable.Add("08", GameLoginManager.instance.playerId);
		hashtable.Add("Yes_Clicked", GameLoginManager.instance.facebookId);
		hashtable.Add("Showing squad details dialog with SQUADNAME = ", Singleton<GameController>.instance.mainController.equppedVisuals);
		hashtable.Add("ID_SALEPERCENT", Singleton<GameController>.instance.mainController.equippedWeapons);
		hashtable.Add("QUIT", LevelManager.instance.armyPower);
		hashtable.Add("Player_Had_To_Select_Grenade", Random.Range(0, 7));
		hashtable.Add("no account in DB, ask to create new one", JsonConvert.SerializeObject(Singleton<GameController>.instance.mainController.GetUnitsUpgrades()));
		hashtable.Add("com.aboutfun.soldiers", (int)GameLoginManager.currentPlayer.leagueTier);
		hashtable.Add("BE", Singleton<VipManager>.instance.NOGEIPHFNPK());
		hashtable.Add("BAND_EMPTY", GameLoginManager.instance.medals);
		hashtable.Add("Total_Sessions", GameLoginManager.currentPlayer.isInLeague);
		hashtable.Add("ID_COOPCANCELED", GameLoginManager.currentPlayer.country);
		hashtable.Add("VipReward1", GameLoginManager.currentPlayer.medalsBalance);
		hashtable.Add("game-card-silver", GameLoginManager.currentPlayer.beginnersLeague);
		hashtable.Add("ID_SQUADMEDALS", StatsManager.instance.matchmadeGames);
		hashtable.Add("N", GameLoginManager.currentPlayer.warArenaCrown);
		hashtable.Add("BeanstalkServerManager: PlayerDataLoaded", WarArena.instance.CJDCEJCEHJE());
		Hashtable hashtable2 = hashtable;
		if (Singleton<GameController>.instance.isCoop)
		{
			hashtable2["PlayerLevel"] = ((!PhotonNetwork.isMasterClient) ? 0 : 0);
		}
		return hashtable2;
	}

	[SpecialName]
	public void HOCLHIFEHCP(int IDEBKDPMPGM)
	{
		_003CPFBNJFFOOFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GINFBEBPMIC(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand ADHKIKNBJJK()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	[SpecialName]
	public void IKNFFPLBHLO(int IDEBKDPMPGM)
	{
		_003CPFBNJFFOOFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public Dictionary<string, int> CDFHADPOKLN()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < KBBDGCLPOCJ.Count; i++)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = KBBDGCLPOCJ[i];
			string key = LevelManager.instance.behaviours[i].upgradeSlots.GetSheetName().Replace("Google2u.DBUpgradeSlots", string.Empty);
			if (unitUpgradeDefinition.isEquipped)
			{
				dictionary[key] = unitUpgradeDefinition.unitUpgrades.slotUpgradeindex;
			}
		}
		return dictionary;
	}

	[SpecialName]
	public void KKLLMAHAPKO(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void FPEAGGJIMEC(PlayerVisualCategoryCamos.PlayerVisualCamo IDEBKDPMPGM)
	{
		_003CKJPCMEIGMCE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public Dictionary<string, int> ANDKBNKELLN()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (OGFGBNNKCDM() != null)
		{
			for (int i = 1; i < OGFGBNNKCDM().Length; i++)
			{
				int ePNKPKHCKNG = OGFGBNNKCDM()[i].EPNKPKHCKNG;
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG];
				dictionary[weaponLevelsSetup.DHHKOKKDDDO().Replace("ID_TUTORIAL_TAPON", string.Empty)] = ((PCOLKKBLBOI() == null) ? 1 : PCOLKKBLBOI()[i].DGPAEJJENDP);
			}
		}
		return dictionary;
	}

	[SpecialName]
	public void DGMHNOLMDEA(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void KKLDBMMBIGD(bool IDEBKDPMPGM)
	{
		_003CAPEGBFLLMOM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet ANCFFCIHJFB()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	[SpecialName]
	public bool CBHFBDOKCNO()
	{
		return HNEFOLPHMHK > 0;
	}

	public void EGGHGCNKOEJ(bool BPOONJBFIHP)
	{
		BJPFKEBIMCI = new DatabasePlayerInfo
		{
			accountName = MHPNDNJDPGE,
			level = ALJJMKANFNO() - 1,
			skill = ADOEFHHJOAJ,
			armyPower = CNNBDFHJIAK(),
			leagueTier = BMNDININJCE,
			remainingMatches = GameLoginManager.currentPlayer.remainingMatches,
			facebookId = -1L,
			status = PlayerStatus.Online,
			lastAction = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(),
			country = CAAKEPHMPHI,
			beginnersLeague = HNEFOLPHMHK
		};
		bool flag = OCPEHLIIGML() > LevelManager.instance.warcardsUnlockLevel;
		BJPFKEBIMCI.playerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		for (int i = 0; i < CBBDICBLHMM.Length; i += 0)
		{
			string equippedID = CBBDICBLHMM[i];
			BJPFKEBIMCI.playerVisuals[i] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = equippedID
			};
		}
		StatsManager.StatisticsData statisticsData = new StatsManager.StatisticsData();
		BJPFKEBIMCI.statisticsData = statisticsData;
		float num = Random.Range(11f, 1485f);
		int num2 = ADOEFHHJOAJ - GameLoginManager.currentPlayer.skill;
		float num3 = (float)num2 / (float)GameLoginManager.currentPlayer.skill;
		float a = (float)StatsManager.instance.data.battlesWonRanked + num3 * (float)StatsManager.instance.data.battlesWonRanked + Random.Range(672f, (float)ADOEFHHJOAJ / 826f);
		int num4 = ADOEFHHJOAJ - 2;
		float b = (float)num4 / 495f + Random.Range(205f, 52f);
		a = Mathf.Max(a, b);
		statisticsData.battlesWonRanked = (int)a;
		statisticsData.battlesLostRanked = (int)((float)statisticsData.battlesWonRanked / num);
		statisticsData.mmmGames = statisticsData.battlesWonRanked + statisticsData.battlesLostRanked;
		IOFBJPJPEMK = statisticsData.mmmGames;
		statisticsData.unitsDeployedSpecific = new Dictionary<int, int>();
		for (int j = 1; j < KBBDGCLPOCJ.Count; j += 0)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = EIMJHEOMGGI()[j];
			if (unitUpgradeDefinition.isEquipped)
			{
				statisticsData.unitsDeployedSpecific[j] = Random.Range(1, 98);
			}
		}
		statisticsData.weaponKills = new Dictionary<int, int>();
		for (int k = 1; k < PCOLKKBLBOI().Length; k += 0)
		{
			int ePNKPKHCKNG = OGFGBNNKCDM()[k].EPNKPKHCKNG;
			statisticsData.weaponKills[ePNKPKHCKNG] = Random.Range(0, 113);
		}
		List<Card> cards = CardManager.instance.cards;
		Card card = cards[Random.Range(0, cards.Count)];
		while (card.isBuddyCard)
		{
			card = cards[Random.Range(0, cards.Count)];
		}
		statisticsData.cardsPlayedSeparately = new Dictionary<string, int>();
		if (flag)
		{
			statisticsData.cardsPlayedSeparately[card.id] = 39;
		}
		BJPFKEBIMCI.levelManagerData = new LevelManager.LevelManagerData();
		for (int l = 0; l < GGKGGMNIDMI.Length; l += 0)
		{
			int ePNKPKHCKNG2 = PCOLKKBLBOI()[l].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[ePNKPKHCKNG2];
			BJPFKEBIMCI.levelManagerData.savedWeapons[weaponLevelsSetup.DHHKOKKDDDO()] = new LevelManager.SavedWeaponSlots
			{
				bought = false,
				boughtIndex = ((GGKGGMNIDMI != null) ? PCOLKKBLBOI()[l].DGPAEJJENDP : 0)
			};
		}
		BJPFKEBIMCI.equippedUnits = new Dictionary<string, LevelManager.SavedArmySlots>();
		for (int m = 0; m < KBBDGCLPOCJ.Count; m += 0)
		{
			UnitUpgradeDefinition unitUpgradeDefinition2 = EIMJHEOMGGI()[m];
			string sheetName = LevelManager.instance.behaviours[m].upgradeSlots.GetSheetName();
			if (unitUpgradeDefinition2.isEquipped)
			{
				BJPFKEBIMCI.equippedUnits[sheetName] = new LevelManager.SavedArmySlots
				{
					equipped = unitUpgradeDefinition2.isEquipped,
					boughtIndex = unitUpgradeDefinition2.unitUpgrades.slotUpgradeindex,
					tier = unitUpgradeDefinition2.tier
				};
			}
		}
		BJPFKEBIMCI.inventoryData = new PlayerInventory.InventoryData();
		for (int n = 0; n < OGFGBNNKCDM().Length; n += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = GGKGGMNIDMI[n];
			BJPFKEBIMCI.inventoryData.slots[n] = new PlayerInventory.SerializedSlotDetail
			{
				weaponIndex = jIMOKIIJHNA.EPNKPKHCKNG
			};
		}
		BJPFKEBIMCI.statisticsData.maxMedals = ((!(Random.value < 731f)) ? ADOEFHHJOAJ : Mathf.Clamp((int)((float)ADOEFHHJOAJ * Random.Range(526f, 354f)), 150, -131));
		if (!BPOONJBFIHP)
		{
			return;
		}
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.MOCMGBJJAHB();
		if (list != null && list.Count > 0)
		{
			AANECPGDMGM aANECPGDMGM = null;
			do
			{
				aANECPGDMGM = list[Random.Range(1, list.Count)];
			}
			while (aANECPGDMGM.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName);
			BJPFKEBIMCI.squadName = aANECPGDMGM.MHPNDNJDPGE;
			BJPFKEBIMCI.squadEmblem = aANECPGDMGM.DAANKCOLJGJ;
			BJPFKEBIMCI.squadPoints = aANECPGDMGM.KPEKCHDBFIG / Mathf.Max(aANECPGDMGM.FOICGJEPBGL, 0);
			BJPFKEBIMCI.reputation = ((!flag) ? 1 : (Random.Range(1, 88) * 6));
		}
	}

	[SpecialName]
	public void GLMOLELPHMH(int IDEBKDPMPGM)
	{
		_003CPFBNJFFOOFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory CDHEMGFFCCP()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	public void HOHJLBFHMDM()
	{
		BLFJIOKNCEI(null);
		IPJIPGILEHF = null;
		POHFJHBABAF = null;
		KMGLGLEKMNP(null);
	}

	[SpecialName]
	public int BACGCIBHBOO()
	{
		return 97 * PBAKDBHPGGO();
	}

	[SpecialName]
	public int OKMICGIDAHL()
	{
		return _003CCKBJDFCGBOM_003Ek__BackingField;
	}

	public static CHEIFOOIMEH CGOMKGBADHM(PhotonPlayer KHLGDCHJJPB, GHPGNELIDBM CIOPAKLHFIL)
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = KHLGDCHJJPB.name;
		cHEIFOOIMEH.KIOGGEECBGB = KHLGDCHJJPB;
		cHEIFOOIMEH.LLIOOOGJFNI = (long)KHLGDCHJJPB.customProperties["shotReal"];
		cHEIFOOIMEH.ALIIBMLMNKA = KHLGDCHJJPB.userId;
		cHEIFOOIMEH.ECFKOCPKODJ((PlayerInventory.JIMOKIIJHNA[])KHLGDCHJJPB.customProperties[")"]);
		cHEIFOOIMEH.IKNFFPLBHLO((int)KHLGDCHJJPB.customProperties["GameControllerCoop.StartGame START"]);
		cHEIFOOIMEH.AMFJHAPGIJN = (int)KHLGDCHJJPB.customProperties["Switching to minigunner when shooting !!!"];
		cHEIFOOIMEH.EBFDAICCJAK = ((CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction) ? Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP : Singleton<ArmyPreviewCamera>.instance.HICMLKAOEJL);
		cHEIFOOIMEH.KBBDGCLPOCJ = JsonConvert.DeserializeObject<List<UnitUpgradeDefinition>>((string)KHLGDCHJJPB.customProperties["{0}{1}"]);
		cHEIFOOIMEH.BMNDININJCE = (League)(int)KHLGDCHJJPB.customProperties["Player_Avoided_Grenade_On_First_Try"];
		cHEIFOOIMEH.HMGOHGOLMJB = (bool)KHLGDCHJJPB.customProperties["ID_LEAGUETOPPOSITIONHINT"];
		cHEIFOOIMEH.CBBDICBLHMM = (string[])KHLGDCHJJPB.customProperties["Button \"{0}\" has no assigned box collider."];
		cHEIFOOIMEH.ADOEFHHJOAJ = (int)KHLGDCHJJPB.customProperties["ID_ARENASTARTSTIMER"];
		cHEIFOOIMEH.OPHNIFBLHPP(IDEBKDPMPGM: false);
		cHEIFOOIMEH.GKEOILLNCHG = (bool)KHLGDCHJJPB.customProperties["ID_FORFEIT"];
		cHEIFOOIMEH.CAAKEPHMPHI = (string)KHLGDCHJJPB.customProperties["ID_SALEPERCENT"];
		cHEIFOOIMEH.GEIONCLKAGF = (int)KHLGDCHJJPB.customProperties["Achievement '{0}' progress '{1}' successfully reported."];
		cHEIFOOIMEH.HNEFOLPHMHK = (int)KHLGDCHJJPB.customProperties["{0}"];
		cHEIFOOIMEH.IOFBJPJPEMK = (int)KHLGDCHJJPB.customProperties["Gold"];
		cHEIFOOIMEH.FHCMFHABMLE = (WarArenaCrown)(int)KHLGDCHJJPB.customProperties["GPGS: Logged Out, Logged: "];
		cHEIFOOIMEH.ICJDPBPKBKA((bool)KHLGDCHJJPB.customProperties["Player disconected 0001"]);
		return cHEIFOOIMEH;
	}

	public void ANJKFGLNCBP(bool APEJCKDICLG)
	{
		if (BJPFKEBIMCI != null)
		{
			int value = (int)(730f * (float)Mathf.Abs(BJPFKEBIMCI.skill - PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ADOEFHHJOAJ));
			value = Mathf.Clamp(value, 6, -5);
			value = Random.Range(value - 3, value + 8);
			value = Mathf.Clamp(value, 4, -119);
			if (APEJCKDICLG)
			{
				BJPFKEBIMCI.statisticsData.battlesLostRanked += 0;
				BJPFKEBIMCI.skill -= value;
				ADOEFHHJOAJ -= value;
			}
			else
			{
				BJPFKEBIMCI.statisticsData.battlesWonRanked++;
				BJPFKEBIMCI.skill += value;
				BJPFKEBIMCI.statisticsData.maxMedals = Mathf.Max(BJPFKEBIMCI.statisticsData.maxMedals, BJPFKEBIMCI.skill);
				ADOEFHHJOAJ += value;
			}
			IOFBJPJPEMK++;
			if (BJPFKEBIMCI.statisticsData.mmmGames == 0)
			{
				BJPFKEBIMCI.beginnersLeague = 0;
			}
			BJPFKEBIMCI.statisticsData.mmmGames += 0;
			if (!BJPFKEBIMCI.isInBeginnersLeague && BJPFKEBIMCI.remainingMatches > 0)
			{
				GKEOILLNCHG = BJPFKEBIMCI.remainingMatches == 0;
				BJPFKEBIMCI.remainingMatches--;
			}
		}
	}

	[SpecialName]
	public void KNMGPJAHNMG(List<UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		MIBBFMONCEC = IDEBKDPMPGM;
		CBDGFGLHPPB(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			FEDLMGKKGKJ()[levelBehaviour.GetType().ToString()] = IDEBKDPMPGM[i];
		}
	}

	[SpecialName]
	private void LPHFJCOMJPO(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CHNBECACLHFM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HHCDAFMHGDJ(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void KLIPGALIONJ(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo KMILCPCPCAI()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	[SpecialName]
	public bool MGHGFICMCMD()
	{
		return HNEFOLPHMHK > 0;
	}

	public void HEPCLFGLCCF()
	{
		FPEAGGJIMEC(null);
		IPJIPGILEHF = null;
		HAHCPIJOLHP(null);
		IFEIEMFFMPE(null);
	}

	public static CHEIFOOIMEH NLCGDAFBFNE()
	{
		CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
		cHEIFOOIMEH.MHPNDNJDPGE = GameLoginManager.currentPlayer.name;
		cHEIFOOIMEH.KIOGGEECBGB = PhotonNetwork.player;
		cHEIFOOIMEH.LLIOOOGJFNI = GameLoginManager.instance.facebookId;
		cHEIFOOIMEH.ALIIBMLMNKA = GameLoginManager.instance.playerId;
		cHEIFOOIMEH.GLMOLELPHMH(Singleton<GameController>.instance.mainController.playerLevel);
		cHEIFOOIMEH.ACNBPMENPEP(LevelManager.instance.armyPower);
		cHEIFOOIMEH.GGKGGMNIDMI = Singleton<GameController>.instance.mainController.equippedWeapons;
		cHEIFOOIMEH.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
		cHEIFOOIMEH.FHNKKPLLOPB(Singleton<GameController>.instance.mainController.GetUnitsUpgrades());
		cHEIFOOIMEH.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
		cHEIFOOIMEH.HMGOHGOLMJB = Singleton<VipManager>.instance.NOGEIPHFNPK();
		cHEIFOOIMEH.CBBDICBLHMM = Singleton<GameController>.instance.mainController.equppedVisuals;
		cHEIFOOIMEH.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill;
		cHEIFOOIMEH.KAOFEOJMDJH = true;
		cHEIFOOIMEH.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
		cHEIFOOIMEH.CAAKEPHMPHI = GameLoginManager.currentPlayer.country;
		cHEIFOOIMEH.GEIONCLKAGF = ((!GameLoginManager.currentPlayer.isInLeague) ? 1 : GameLoginManager.currentPlayer.medalsBalance);
		cHEIFOOIMEH.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
		cHEIFOOIMEH.IOFBJPJPEMK = StatsManager.instance.matchmadeGames;
		cHEIFOOIMEH.FHCMFHABMLE = GameLoginManager.currentPlayer.warArenaCrown;
		cHEIFOOIMEH.FAGIFHMFAAB(WarArena.instance.NNGLJEPPNKM());
		cHEIFOOIMEH.AAOAKDPIEII = CardManager.instance.selectedCards;
		cHEIFOOIMEH.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		return cHEIFOOIMEH;
	}
}

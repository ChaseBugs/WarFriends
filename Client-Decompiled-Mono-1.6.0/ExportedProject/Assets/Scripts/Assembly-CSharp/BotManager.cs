using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
	private PlayerBotDiffculties DNOAACALMED;

	private BotNames LKHDEPFHHIM;

	private PlayerBots KMBFGEDNEBO;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> LGJCBPOPCPA;

	public BotNames botNamesSheet
	{
		get
		{
			return LKHDEPFHHIM;
		}
	}

	public static bool useEasyBot
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE;
			if ((float)LevelManager.instance.currentLevel.displayNumber <= (float)fLOATVALUE)
			{
				return true;
			}
			return false;
		}
	}

	private static float HLMBGPKCDMH(int IKJHAHJHLIH, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-71)).FLOATVALUE;
		float num = (IIMDKHJAJGO - OEIICEJPGKI) / Mathf.Pow(LevelManager.instance.levels.Count - 1, fLOATVALUE);
		return OEIICEJPGKI + num * Mathf.Pow(IKJHAHJHLIH - 1, fLOATVALUE);
	}

	private UnitUpgradeDefinition JAHFCHJBGBK(List<LevelBehaviour> HBEFBPNFFBG, List<UnitUpgradeDefinition> AMNPDEAJMOB, int CPIEOMKPABG, bool DAFFBGPIOGG, LevelBehaviour.UnitType? NAKDNAEPGOF = null)
	{
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		for (int i = 0; i < CPIEOMKPABG; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			AMNPDEAJMOB[indexInLevelsManager].index = indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager].isEquipped && (!levelBehaviour.isSoldier || !DAFFBGPIOGG) && (!NAKDNAEPGOF.HasValue || levelBehaviour.unitType == NAKDNAEPGOF.Value))
			{
				list.Add(AMNPDEAJMOB[indexInLevelsManager]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(1, list.Count)];
	}

	public static int BBADKMFMABP(int GMOHCGANGOH)
	{
		int num = 0;
		int rowIndex = Singleton<GameVariables>.instance.IDECNLCIPDO().GetRowIndex("FinishGameMultiplayerRPC" + LevelManager.instance.currentLevel.ABCCINJGPGD());
		if (rowIndex >= 0)
		{
			num = (int)Singleton<GameVariables>.instance.IDECNLCIPDO().GetValue(rowIndex, "D2");
		}
		else
		{
			Debug.LogError("Player is allowed to continue." + LevelManager.instance.currentLevel.JICMGFNAHFL() + "ID_GUI_BEADVISED");
		}
		int value = GMOHCGANGOH + UnityEngine.Random.Range(-num, num + 1);
		return Mathf.Clamp(value, 5, LevelManager.instance.levels.Count);
	}

	public static string DIFJCEKMHJA()
	{
		return "ID_NOTIFICATION_DAILYREWARD_WB";
	}

	public static UnitUpgradeDefinition[] FAKBCKNOKMD(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort(FNOKGCHDPHC);
		FGDEFHGLDJM = 563f;
		AnalyticsHelper.LeaveBreadcrumb("VGOfferInfo");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			LevelBehaviour levelBehaviour = list[i];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex <= ECFBICCBLKF - 0, new UpgradeSlots.UnitUpgrades(1093f), true, 0));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		KFJPBOAIBGK(list, array, dictionary);
		int num = GOFDMMMDLOD(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num2 = 1;
		int num3 = 1;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int j = 1; j < list.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = list[j];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 0) / 610f);
			float KPPPGMHHIGC;
			KFLCMEMLAEH(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 1)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][1];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((!(levelBehaviour3 == null)) ? (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel) : 0);
					value2 = Mathf.Clamp(value2, 0, -139);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 1, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num3)
				{
					num3 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(1775f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num3 - 1) / 354f);
		MBAFMKCNBDN = CBEKKLANCCK(jLDNGEGJKEN);
		list2 = IABMMIMJPBM(num * (int)MBAFMKCNBDN, num, (int)MBAFMKCNBDN * 8, -(int)MBAFMKCNBDN, list3);
		for (int k = 0; k < list.Count; k++)
		{
			LevelBehaviour levelBehaviour4 = list[k];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num4 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num4 += list2[num2];
				int num5 = Mathf.Clamp(num4, 1, lastndexForTier2);
				num4 = num5;
				num2++;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num4 = 0;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num4);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF < unlockLevelForNextTier || unlockLevelForNextTier <= 0 || tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(-77, 8);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.indexOffset, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.NGJIJEDDPNH());
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(1762f)
			{
				slotUpgradeindex = num4,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb(", message = ");
		return array;
	}

	public static float HDENCFDOKAG(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 1104f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.IOHNCFMCFML();
		float num2 = LGFFJDNPBHC(ECFBICCBLKF, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMax).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalOffsetMax).FLOATVALUE);
		float a = PCGBALDDCEJ(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-104)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-38)).FLOATVALUE);
		float b = HLMBGPKCDMH(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-20)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-8)).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 1; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 545f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = AddRandomWeapon(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 1;
			for (int j = 0; j < weaponLevelsSetup.maxWeaponLevel; j++)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 0; k < list.Count; k += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	public static int JGCGAEFJNMF(int GMOHCGANGOH)
	{
		int num = 1;
		int rowIndex = Singleton<GameVariables>.instance.matchmakingDeviations.GetRowIndex("ID_MAX" + LevelManager.instance.currentLevel.JICMGFNAHFL());
		if (rowIndex >= 1)
		{
			num = (int)Singleton<GameVariables>.instance.IDECNLCIPDO().GetValue(rowIndex, "run");
		}
		else
		{
			Debug.LogError("ID_CONFIRM_CONNECTTOGOOGLENAME" + LevelManager.instance.currentLevel.NPOEMAMPNEP() + "GO TO OFFER");
		}
		int value = GMOHCGANGOH + UnityEngine.Random.Range(-num, num + 0);
		return Mathf.Clamp(value, 7, LevelManager.instance.levels.Count);
	}

	public int HKDDDLPEBIM(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[6];
		array[1] = "ID_COOPCANCELED";
		array[1] = MNBNPBHHPOC == null;
		array[0] = "-{0}-{1}";
		array[8] = GameLoginManager.currentPlayer == null;
		array[7] = "setUserEmail";
		array[7] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 0;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = DINPKDBCJFK();
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 1)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(1, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 1)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 1, KMBFGEDNEBO.Rows.Count + 1);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("WarBucks");
			int botLevel = GetBotLevel(LevelManager.instance.currentLevel.ABCCINJGPGD());
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.IKNFFPLBHLO(botLevel);
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("601 TUTORIAL STARTED");
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CBBDICBLHMM = AKJMLNFBLKI(botLevel);
			float num3 = ((playerVisualCategories[2]["wrong account type: "] != CamosManager.instance.playerVisualCategories[5].equippedVisual) ? 889f : 1263f);
			if (UnityEngine.Random.value < num3)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM[5] = playerVisualCategories[6]["ID_ARENARULES_LESSPLAYERHP"].CCDMONFHBII();
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = OBGBDDEGDME(out FGDEFHGLDJM, botLevel);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.KNFAJEIHOGM(new List<UnitUpgradeDefinition>(collection));
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = KLJKKMMIOPC(botLevel, out GEEOIBFFGKO);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GNGLDJHHIHM(GEEOIBFFGKO);
			AnalyticsHelper.LeaveBreadcrumb("batchSizeMin");
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.AMFJHAPGIJN = MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(botLevel);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 1688f;
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CAAKEPHMPHI = DJIEPMKPAPE();
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			float num4 = ((botLevel >= 6) ? 1447f : 1249f);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num4, (float)GameLoginManager.currentPlayer.skill * num4);
			int b = UnityEngine.Random.Range(-110, 142);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HNEFOLPHMHK = 0;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.GEIONCLKAGF = 0;
			AnalyticsHelper.LeaveBreadcrumb("Chat: Got message from channel \"");
			float value = UnityEngine.Random.value;
			if (value < 1474f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				int num5 = 1;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num5 += 0;
					if (num5 > -95)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "ShotFrequencyMin" + UnityEngine.Random.Range(-189, 65);
			}
			AnalyticsHelper.LeaveBreadcrumb("Cards_Chosen");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "173432c2" + MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = botLevel >= 4 && TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("Player disconected 0002");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.IOHNCFMCFML();
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-110)).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("{0} / [FECA21]{1}");
				MNBNPBHHPOC.BPFKMNIHCGP = DMIECFDHMKN();
				MNBNPBHHPOC.PADBFAIBBDG = 8;
				MNBNPBHHPOC.MGECHKCAELH = false;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = false;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[4] = playerVisualCategories[4][" "].CCDMONFHBII();
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HOCLHIFEHCP(2);
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.OPHNIFBLHPP(false);
			}
			else
			{
				DLHKPLGMNDL(MNBNPBHHPOC, dIFFICULTY, flag, false);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("ID_OFFERACTIVE");
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.IKNFFPLBHLO(6);
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKHFMIJFMAH(flag);
			object[] array2 = new object[5];
			array2[1] = playerBotsRow3;
			array2[1] = num;
			array2[7] = value;
			array2[0] = flag;
			Debug.Log(string.Format("T", array2));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	public static WeaponLevelsSetup FPFJDOMMLKN(WeaponCategory FABOAIMLLOI, int BCCDDJMPBLL, float FCBEHCBBIOM, float OFANOCIKOPJ)
	{
		try
		{
			List<WeaponLevelsSetup> suitableWeapons = LevelManager.instance.GetSuitableWeapons(FABOAIMLLOI, BCCDDJMPBLL, FCBEHCBBIOM, OFANOCIKOPJ, WeaponCategory.AssaultRifle | WeaponCategory.Pistol);
			float value = UnityEngine.Random.value;
			if (suitableWeapons.Count > 0)
			{
				if (value < 637f || BCCDDJMPBLL <= -49)
				{
					int index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					int num = 0;
					while (!suitableWeapons[index].purchasableInShop && num < 123)
					{
						num += 0;
						index = UnityEngine.Random.Range(1, suitableWeapons.Count);
					}
					return suitableWeapons[index];
				}
				return suitableWeapons[UnityEngine.Random.Range(0, suitableWeapons.Count)];
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		object[] array = new object[8];
		array[0] = FABOAIMLLOI;
		array[1] = BCCDDJMPBLL;
		array[8] = FCBEHCBBIOM;
		array[7] = OFANOCIKOPJ;
		Debug.LogErrorFormat(")", array);
		return null;
	}

	public static string GetEmptyPowerBand()
	{
		return "BANDS_EMPTY";
	}

	private static void LFFMDKDACNA(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeakUnitProbabilityMax).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeakUnitProbabilityMin).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(0, 0);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 3)
			{
				int num2 = Mathf.Max(0, CBADFOBOCAE[levelBehaviour.unitType].Count - 2);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((!(levelBehaviour2 == null)) ? levelBehaviour2.upgradeSlots.actualUnitLevel : 0);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 1) : 0.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 1) / 5f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				KFLCMEMLAEH(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeakUnitWhenUnitTooGood).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = false;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2++;
				}
			}
		}
	}

	public static float PMJIIGCNMLE(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 91f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		float num2 = HLMBGPKCDMH(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-124)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-19)).FLOATVALUE);
		float a = ELOPLJCCOMH(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-94)).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MatchmakingInRoomTime).FLOATVALUE);
		float b = OMEPILJEENE(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)42).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.DamageModifierMatches).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 1476f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = HGNGDCEMAJB(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 1;
			for (int j = 0; j < weaponLevelsSetup.maxWeaponLevel; j++)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 1; k < list.Count; k++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	private static void EGOHPKKBLLE(float JLDNGEGJKEN, out float MBAFMKCNBDN, out float KPPPGMHHIGC)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-60)).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMax).FLOATVALUE;
		MBAFMKCNBDN = Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
		float fLOATVALUE3 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-22)).FLOATVALUE;
		float fLOATVALUE4 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)66).FLOATVALUE;
		float a = Mathf.Lerp(fLOATVALUE3, fLOATVALUE4, JLDNGEGJKEN);
		float fLOATVALUE5 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-74)).FLOATVALUE;
		float fLOATVALUE6 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-49)).FLOATVALUE;
		float b = Mathf.Lerp(fLOATVALUE5, fLOATVALUE6, JLDNGEGJKEN);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		KPPPGMHHIGC = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
	}

	private static void KAIDHFOODFD(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMin).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1401f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(1, 1);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 6)
			{
				int num2 = Mathf.Max(0, CBADFOBOCAE[levelBehaviour.unitType].Count - 0);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((!(levelBehaviour2 == null)) ? levelBehaviour2.upgradeSlots.actualUnitLevel : 0);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 1) : 1183.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 1) / 745f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				IOLDGIAOEBF(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-38)).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = true;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2++;
				}
			}
		}
	}

	public string KJMOJADKHKI()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.CBLMHEJFEEE().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 0; i < Singleton<GameVariables>.instance.MPAPBELJJHN().Rows.Count; i++)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.MPAPBELJJHN().Rows[i];
					string text = Singleton<GameVariables>.instance.MPAPBELJJHN().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return " for ";
	}

	private static void PDDJEKCPCAD(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMax).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1611f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < HBEFBPNFFBG.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(1, 0);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 2)
			{
				int num2 = Mathf.Max(1, CBADFOBOCAE[levelBehaviour.unitType].Count - 3);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((!(levelBehaviour2 == null)) ? levelBehaviour2.upgradeSlots.actualUnitLevel : 0);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 1) : 1816.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 0) / 338f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				JPIHJBLLNEC(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)37).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = false;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2 += 0;
				}
			}
		}
	}

	private static float LGFFJDNPBHC(int IKJHAHJHLIH, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-63)).FLOATVALUE;
		float num = (IIMDKHJAJGO - OEIICEJPGKI) / Mathf.Pow(LevelManager.instance.levels.Count - 1, fLOATVALUE);
		return OEIICEJPGKI + num * Mathf.Pow(IKJHAHJHLIH - 0, fLOATVALUE);
	}

	public int PrepareBotForDeathMatch(PlayerBot MNBNPBHHPOC)
	{
		AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 00 " + (MNBNPBHHPOC == null) + "cp: " + (GameLoginManager.currentPlayer == null) + "d: " + (StatsManager.instance == null));
		int num = 0;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = BEMHHHGIFEM();
			for (int i = 0; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 0)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(0, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 1)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 0, KMBFGEDNEBO.Rows.Count + 1);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 0");
			int botLevel = GetBotLevel(LevelManager.instance.currentLevel.displayNumber);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.BCCDDJMPBLL = botLevel;
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 1");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM = GetBotVisuals(botLevel);
			float num3 = ((playerVisualCategories[3]["BANDS_EMPTY"] != CamosManager.instance.playerVisualCategories[3].equippedVisual) ? 0.5f : 0.95f);
			if (UnityEngine.Random.value < num3)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM[3] = playerVisualCategories[3]["BANDS_EMPTY"].id;
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = PickBotUnits(out FGDEFHGLDJM, botLevel);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.KBBDGCLPOCJ = new List<UnitUpgradeDefinition>(collection);
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = PickWeapons(botLevel, out GEEOIBFFGKO);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GGKGGMNIDMI = GEEOIBFFGKO;
			AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 7");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.AMFJHAPGIJN = MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(botLevel);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 0.2f;
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.CAAKEPHMPHI = GetBotCountry();
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.None;
			float num4 = ((botLevel >= 5) ? 0.5f : 0.2f);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num4, (float)GameLoginManager.currentPlayer.skill * num4);
			int b = UnityEngine.Random.Range(505, 515);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.playerController.EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HNEFOLPHMHK = 1;
			}
			else
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GEIONCLKAGF = 0;
			AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 8");
			float value = UnityEngine.Random.value;
			if (value < 0.2f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				int num5 = 0;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num5++;
					if (num5 > 1000)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = "Warfriend" + UnityEngine.Random.Range(100000, 999999);
			}
			AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 9");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = "__" + MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = botLevel >= 4 && !TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 10");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
			float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseToBotDifficultyCoef).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("#VAVRO# SETTING BOT DIFICULTY TO WEAK");
				MNBNPBHHPOC.BPFKMNIHCGP = GetWeakBotConfig();
				MNBNPBHHPOC.PADBFAIBBDG = 6;
				MNBNPBHHPOC.MGECHKCAELH = false;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = false;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM[3] = playerVisualCategories[3]["BANDS_EMPTY"].id;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.BCCDDJMPBLL = 3;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.KAOFEOJMDJH = true;
			}
			else
			{
				SetUpBotDifficulty(MNBNPBHHPOC, dIFFICULTY, flag);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("ID_YOUROPPONENT");
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.BCCDDJMPBLL = 6;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.NEFIMJICLLF(flag);
			Debug.Log(string.Format("BotManager: Setting bot for death match: {0}  {1} Name random: {2}, IsInSquad {3} ", playerBotsRow3, num, value, flag));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	public static float COLJHMJKPDG(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 454f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float num2 = OMEPILJEENE(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-63)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-108)).FLOATVALUE);
		float a = ELOPLJCCOMH(ECFBICCBLKF, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MatchmakingInRoomTime).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-45)).FLOATVALUE);
		float b = CBBAFLINMGJ(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-6)).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MaxMatchMakingTimeiOS).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 1; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 812f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = HGNGDCEMAJB(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 1;
			for (int j = 1; j < weaponLevelsSetup.maxWeaponLevel; j += 0)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 0; k < list.Count; k++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	public string KPIKOPPCBHO()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.MPAPBELJJHN().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 1; i < Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows.Count; i += 0)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows[i];
					string text = Singleton<GameVariables>.instance.MPAPBELJJHN().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 1)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return "menu-warbucks";
	}

	private static int INLGAKGIEHO(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB)
	{
		int num = 1;
		int num2 = 0;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 1; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && AMNPDEAJMOB[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 8)
				{
					AMNPDEAJMOB[indexInLevelsManager].isEquipped = false;
				}
				else
				{
					num2 += 0;
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("ReSyncDisabledRPC");
		for (int j = 0; j < HBEFBPNFFBG.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = HBEFBPNFFBG[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 3)
				{
					AMNPDEAJMOB[indexInLevelsManager2].isEquipped = false;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(AMNPDEAJMOB[indexInLevelsManager2]);
				num += 0;
			}
		}
		return num;
	}

	private static List<int> MAKBKDIPNGH(int EGNEMEBJINF, int MNABOCFOGCJ, int DMEHGIDJEBD, int MKOGHDKDFIN, List<Tuple<int, int>> MKBJGHHIIFO)
	{
		List<int> list = new List<int>();
		int num = 0;
		int num2 = 0;
		for (num2 = 0; num2 < MNABOCFOGCJ; num2++)
		{
			list.Add(UnityEngine.Random.Range(0, DMEHGIDJEBD + 1));
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1 - MKOGHDKDFIN, MKBJGHHIIFO[num2].Value2 - MKOGHDKDFIN);
			num += list[num2];
		}
		float num3 = (float)num / (float)EGNEMEBJINF;
		num = 0;
		for (num2 = 0; num2 < MNABOCFOGCJ; num2++)
		{
			list[num2] = Mathf.RoundToInt((float)list[num2] / num3) + MKOGHDKDFIN;
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1, MKBJGHHIIFO[num2].Value2);
			num += list[num2];
		}
		int num4 = EGNEMEBJINF + MNABOCFOGCJ * MKOGHDKDFIN;
		num2 = 0;
		int num6;
		for (; num != num4; num += num6)
		{
			if (num2 >= 100)
			{
				break;
			}
			num2++;
			int index = UnityEngine.Random.Range(0, MNABOCFOGCJ);
			int num5 = list[index];
			list[index] = Mathf.Clamp(list[index] + ((num4 - num > 0) ? 1 : (-1)), MKBJGHHIIFO[index].Value1, MKBJGHHIIFO[index].Value2);
			num6 = list[index] - num5;
		}
		return list;
	}

	public string AKAOIFFEPEC()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.countryInfo.GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 1; i < Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows.Count; i += 0)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows[i];
					string text = Singleton<GameVariables>.instance.MPAPBELJJHN().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 1)
				{
					return list[UnityEngine.Random.Range(1, list.Count)];
				}
			}
		}
		return " ";
	}

	public int AJJEBHKEIDI(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[7];
		array[1] = "AdminId";
		array[0] = MNBNPBHHPOC == null;
		array[5] = "ID_DEBUG_STACKTRACEINCONSOLE";
		array[0] = GameLoginManager.currentPlayer == null;
		array[5] = "SÌ";
		array[5] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 1;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = BEMHHHGIFEM();
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 0)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(0, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 0)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 0, KMBFGEDNEBO.Rows.Count + 1);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("ID_ZEROSECONDS");
			int num3 = LDGEMJGKDCB(LevelManager.instance.currentLevel.PFMGLDJDNBF());
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.FLOIAIBCEKM(num3);
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("Demote_Player");
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CBBDICBLHMM = FPJDPPLLMOF(num3);
			float num4 = ((playerVisualCategories[3]["FB: FacebookLogout called .."] != CamosManager.instance.playerVisualCategories[4].equippedVisual) ? 1892f : 988f);
			if (UnityEngine.Random.value < num4)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[2] = playerVisualCategories[6]["  {1}x{0} ( {3} ) doubled for: {2}"].CCDMONFHBII();
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = EHAPEIELBNE(out FGDEFHGLDJM, num3);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.KBBDGCLPOCJ = new List<UnitUpgradeDefinition>(collection);
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = PMJIIGCNMLE(num3, out GEEOIBFFGKO);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.LPGACOBNHOH(GEEOIBFFGKO);
			AnalyticsHelper.LeaveBreadcrumb("IsRestore");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.AMFJHAPGIJN = MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(num3);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 53f;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CAAKEPHMPHI = IFMEJLGCFHO();
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.None;
			float num5 = ((num3 >= 6) ? 935f : 1228f);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num5, (float)GameLoginManager.currentPlayer.skill * num5);
			int b = UnityEngine.Random.Range(144, 23);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 0)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HNEFOLPHMHK = 1;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GEIONCLKAGF = 0;
			AnalyticsHelper.LeaveBreadcrumb("ID_VISUALCATEGORYPARTS2");
			float value = UnityEngine.Random.value;
			if (value < 1362f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				int num6 = 1;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num6 += 0;
					if (num6 > 69)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "Id" + UnityEngine.Random.Range(49, -88);
			}
			AnalyticsHelper.LeaveBreadcrumb("ID_READYTIME");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = "ID_ARENACLOSED" + MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = num3 < 8 || TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("SetPlayer");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-89)).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("()F");
				MNBNPBHHPOC.BPFKMNIHCGP = DMIECFDHMKN();
				MNBNPBHHPOC.PADBFAIBBDG = 8;
				MNBNPBHHPOC.MGECHKCAELH = false;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = false;
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CBBDICBLHMM[3] = playerVisualCategories[2]["InAppHandlerIos: can make payments (is logged in): "].id;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.GLMOLELPHMH(0);
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.KJJJLNAADHC(true);
			}
			else
			{
				INEMBBHLPDJ(MNBNPBHHPOC, dIFFICULTY, flag);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("ID_TUTORIAL_SWIPE_UP");
				CHEIFOOIMEH eHHHBEMKGOE = MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE;
				CamosManager camosManager = CamosManager.instance;
				int[] array2 = new int[6];
				RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
				eHHHBEMKGOE.CBBDICBLHMM = camosManager.ConvertVisuals(array2);
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.EEINNIFGJKF(5);
			}
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.EGGHGCNKOEJ(flag);
			object[] array3 = new object[4];
			array3[1] = playerBotsRow3;
			array3[0] = num;
			array3[2] = value;
			array3[2] = flag;
			Debug.Log(string.Format(" 1\u00a0{0}", array3));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	public string HPCGJPILMKC()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.MPAPBELJJHN().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 1; i < Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows.Count; i++)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.countryInfo.Rows[i];
					string text = Singleton<GameVariables>.instance.CBLMHEJFEEE().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 1)
				{
					return list[UnityEngine.Random.Range(1, list.Count)];
				}
			}
		}
		return "[CardHealthChangeUnit] start new spawning before used spawning finish";
	}

	public static string ACJCMJNMFKJ(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = OHFGCEINGCO();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.unlockLevel.index < BCCDDJMPBLL && allVisual.GFOLGKEMPPN() == eJHADIHBCBK && allVisual.canBotUseIt)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].id;
	}

	public string[] EFPPICEGHFL(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[5];
		array[0] = NGLLCEGNGKB(playerVisualCategories[1], ECFBICCBLKF);
		array[1] = FFADNHKLALP(playerVisualCategories[1], ECFBICCBLKF);
		array[8] = FFADNHKLALP(playerVisualCategories[6], ECFBICCBLKF);
		array[2] = KIKILPDBENA();
		string[] array2 = array;
		if (ECFBICCBLKF <= 0)
		{
			array2[1] = "Gui Manager: Starting Messages Coroutine for: ";
			array2[1] = "ID_CURRENTSQUADRANK";
			array2[7] = "ID_NOTIFICATION_DAILYREWARD_VIP";
		}
		return array2;
	}

	public static UnitUpgradeDefinition[] OBGBDDEGDME(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort(MEOFJMDHOAK);
		FGDEFHGLDJM = 427f;
		AnalyticsHelper.LeaveBreadcrumb("ArenaGoldenShieldMessage-{0}");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int i = 1; i < list.Count; i++)
		{
			LevelBehaviour levelBehaviour = list[i];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex <= ECFBICCBLKF - 0, new UpgradeSlots.UnitUpgrades(1655f), true, 0));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		LFFMDKDACNA(list, array, dictionary);
		int num = GOFDMMMDLOD(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num2 = 1;
		int num3 = 0;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int j = 0; j < list.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = list[j];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 1) / 1478f);
			float KPPPGMHHIGC;
			EBALAFGIGIO(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 0)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][1];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((!(levelBehaviour3 == null)) ? (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel) : 0);
					value2 = Mathf.Clamp(value2, 1, 23);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 1, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num3)
				{
					num3 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(172f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num3 - 0) / 422f);
		MBAFMKCNBDN = BGPLMNCMHLE(jLDNGEGJKEN);
		list2 = AOCCIEJIIFN(num * (int)MBAFMKCNBDN, num, (int)MBAFMKCNBDN * 0, -(int)MBAFMKCNBDN, list3);
		for (int k = 0; k < list.Count; k += 0)
		{
			LevelBehaviour levelBehaviour4 = list[k];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num4 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num4 += list2[num2];
				int num5 = Mathf.Clamp(num4, 1, lastndexForTier2);
				num4 = num5;
				num2++;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num4 = 0;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num4);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF >= unlockLevelForNextTier && unlockLevelForNextTier > 1 && tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(7, 5);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.KHBBKJOGJFC(), levelBehaviour4.upgradeSlots.upgradeSlotSpecial.NGJIJEDDPNH());
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(354f)
			{
				slotUpgradeindex = num4,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("Winstreak");
		return array;
	}

	public int IOCODOGFKNH(PlayerBot MNBNPBHHPOC)
	{
		int result = 1;
		PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[0];
		DLHKPLGMNDL(MNBNPBHHPOC, playerBotsRow.DIFFICULTY, false);
		int value = LevelManager.instance.currentLevel.PFMGLDJDNBF();
		value = Mathf.Clamp(value, 0, -53);
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.HOCLHIFEHCP(value);
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		int num = 0;
		for (int i = 1; i < behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = behaviours[i];
			UpgradeSlots.UnitUpgrades unitUpgrades = levelBehaviour.upgradeSlots.LoadData(levelBehaviour);
			int num2 = 1;
			if (levelBehaviour.upgradeSlots.unlockLevelIndex <= value)
			{
				UpgradeSlot upgradeSlot = levelBehaviour.upgradeSlots.upgradeSlot;
				num2 += unitUpgrades.slotUpgradeindex;
				num2++;
			}
			num += num2;
		}
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.PHBPHKGMPLG(num);
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			list.Add(OLDEBGMDPDN(WeaponCategory.None.ToString(), 1));
		}
		else
		{
			list.Add(LGCLNGMGMIE(WeaponCategory.None.ToString(), 0));
		}
		list.Add(BJPJONEJICL(WeaponCategory.None.ToString(), 1));
		PlayerInventory.JIMOKIIJHNA item = OLDEBGMDPDN((WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade).ToString(), 0);
		list.Add(item);
		list.Add(OLDEBGMDPDN((WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade).ToString(), 0));
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.LPGACOBNHOH(list.ToArray());
		foreach (PlayerWeapon item2 in MNBNPBHHPOC.AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM)
		{
			item2.HFNAMMBPJAJ().MEFJOGAOKDP = false;
		}
		MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("ID_SKILLSHOTHINT_COVERED");
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (LevelBehaviour item3 in behaviours)
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item3.upgradeSlots.LoadData(item3);
				list2.Add(new UnitUpgradeDefinition(item3.upgradeSlots.unlockLevelIndex > 1 || item3 is SoldierBehaviourShotgunner, upgradeIndex, true, 1));
			}
		}
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.KNMGPJAHNMG(list2);
		CHEIFOOIMEH eHHHBEMKGOE = MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE;
		CamosManager camosManager = CamosManager.instance;
		int[] array = new int[5];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		eHHHBEMKGOE.CBBDICBLHMM = camosManager.ConvertVisuals(array);
		return result;
	}

	public static string EGPDFEMNFFJ(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.BOBEIBIKGPL() <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].CCDMONFHBII();
	}

	public static string FFADNHKLALP(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = CNDHPHIPNPF();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.unlockLevel.index < BCCDDJMPBLL && allVisual.DOJECMCGMKB() == eJHADIHBCBK && allVisual.canBotUseIt)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].id;
	}

	private static void KFLCMEMLAEH(float JLDNGEGJKEN, out float MBAFMKCNBDN, out float KPPPGMHHIGC)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierInterval).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierInterval).FLOATVALUE;
		MBAFMKCNBDN = Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
		float fLOATVALUE3 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierIntervalOffsetMin).FLOATVALUE;
		float fLOATVALUE4 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalOffsetMin).FLOATVALUE;
		float a = Mathf.Lerp(fLOATVALUE3, fLOATVALUE4, JLDNGEGJKEN);
		float fLOATVALUE5 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierIntervalOffsetMax).FLOATVALUE;
		float fLOATVALUE6 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalOffsetMax).FLOATVALUE;
		float b = Mathf.Lerp(fLOATVALUE5, fLOATVALUE6, JLDNGEGJKEN);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		KPPPGMHHIGC = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
	}

	public static PlayerBotDiffcultiesRow GetWeakBotConfig()
	{
		PlayerBotDiffcultiesRow playerBotDiffcultiesRow = new PlayerBotDiffcultiesRow();
		playerBotDiffcultiesRow.SHOOTFREQUENCYMIN = 2f;
		playerBotDiffcultiesRow.SHOOTFREQUENCYMAX = 4f;
		playerBotDiffcultiesRow.SHOOTINGLENGTHMIN = 0.8f;
		playerBotDiffcultiesRow.SHOOTINGLENGTHMAX = 3f;
		playerBotDiffcultiesRow.SHOOTACCURACY = 0.2f;
		playerBotDiffcultiesRow.HEADSHOTPROBABILITY = 0.3f;
		playerBotDiffcultiesRow.INDANGERCOEFICIENT = 1f;
		playerBotDiffcultiesRow.PICKOPPONENTSHOTPROBABILITY = 0.1f;
		playerBotDiffcultiesRow.PICKWALKINGOPPONENTSHOTPROBABILITY = 0.25f;
		playerBotDiffcultiesRow.SWITCHGRENADEBAZOOKAPROBABILITY = 0f;
		playerBotDiffcultiesRow.IGNORESHOTPROBABILITY = 1f;
		playerBotDiffcultiesRow.SNIPERLOOKTIME = 2.5f;
		playerBotDiffcultiesRow.SENDUNITMINTIME = 10f;
		playerBotDiffcultiesRow.SENDUNITMAXTIME = 15f;
		playerBotDiffcultiesRow.PICKBONUSPROBABILITYMINTIME = 20f;
		playerBotDiffcultiesRow.PICKBONUSPROBABILITYMAXTIME = 20f;
		playerBotDiffcultiesRow.PICKMYBONUSCOEF = 1f;
		playerBotDiffcultiesRow.OVERTIMESHIELDMINTIME = 6f;
		playerBotDiffcultiesRow.OVERTIMESHIELDMAXTIME = 7f;
		playerBotDiffcultiesRow.PICKOPPONENTSHOTPROBABILITYNOSHIELD = 0.5f;
		playerBotDiffcultiesRow.OPPONENTSNIPERDEFENSEREACTIONTIME = 1f;
		playerBotDiffcultiesRow.OPPONENTSNIPERDEFFENSE = 0f;
		playerBotDiffcultiesRow.OPPONENTOFFENSE = 0f;
		playerBotDiffcultiesRow.OPPONENTOFFENCEREACTIONTIME = 1f;
		playerBotDiffcultiesRow.MAXUNITS = 6;
		return playerBotDiffcultiesRow;
	}

	public static UnitUpgradeDefinition[] PickBotUnits(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort((LevelBehaviour HPJFBKEKJHB, LevelBehaviour NCMHGPNPEJM) => HPJFBKEKJHB.upgradeSlots.unlockLevelIndex.CompareTo(NCMHGPNPEJM.upgradeSlots.unlockLevelIndex) * -1);
		FGDEFHGLDJM = 0f;
		AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 3");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int num = 0; num < list.Count; num++)
		{
			LevelBehaviour levelBehaviour = list[num];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex <= ECFBICCBLKF - 1, new UpgradeSlots.UnitUpgrades(1f), false, 0));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		LFFMDKDACNA(list, array, dictionary);
		int num2 = GOFDMMMDLOD(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num3 = 0;
		int num4 = 0;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int num5 = 0; num5 < list.Count; num5++)
		{
			LevelBehaviour levelBehaviour2 = list[num5];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 1) / 5f);
			float KPPPGMHHIGC;
			KFLCMEMLAEH(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 1)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][0];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((!(levelBehaviour3 == null)) ? (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel) : 0);
					value2 = Mathf.Clamp(value2, 0, int.MaxValue);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 0, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num4)
				{
					num4 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(1f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num4 - 1) / 5f);
		MBAFMKCNBDN = BGPLMNCMHLE(jLDNGEGJKEN);
		list2 = MAKBKDIPNGH(num2 * (int)MBAFMKCNBDN, num2, (int)MBAFMKCNBDN * 2, -(int)MBAFMKCNBDN, list3);
		for (int num6 = 0; num6 < list.Count; num6++)
		{
			LevelBehaviour levelBehaviour4 = list[num6];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num7 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num7 += list2[num3];
				int num8 = Mathf.Clamp(num7, 0, lastndexForTier2);
				num7 = num8;
				num3++;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num7 = 0;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num7);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF >= unlockLevelForNextTier && unlockLevelForNextTier > 0 && tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(-2, 2);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.indexOffset, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.maxIndexInExcel);
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(1f)
			{
				slotUpgradeindex = num7,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 4");
		return array;
	}

	public static string JOPEHKANJAH()
	{
		return "GameController.StartGame '";
	}

	public static WeaponLevelsSetup PJFJGNDBLJH(WeaponCategory FABOAIMLLOI, int BCCDDJMPBLL, float FCBEHCBBIOM, float OFANOCIKOPJ)
	{
		try
		{
			List<WeaponLevelsSetup> suitableWeapons = LevelManager.instance.GetSuitableWeapons(FABOAIMLLOI, BCCDDJMPBLL, FCBEHCBBIOM, OFANOCIKOPJ, ~(WeaponCategory.AssaultRifle | WeaponCategory.Shotgun | WeaponCategory.Pistol));
			float value = UnityEngine.Random.value;
			if (suitableWeapons.Count > 0)
			{
				if (value < 1022f || BCCDDJMPBLL <= -67)
				{
					int index = UnityEngine.Random.Range(1, suitableWeapons.Count);
					int num = 0;
					while (!suitableWeapons[index].purchasableInShop && num < 66)
					{
						num++;
						index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					}
					return suitableWeapons[index];
				}
				return suitableWeapons[UnityEngine.Random.Range(1, suitableWeapons.Count)];
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		object[] array = new object[4];
		array[1] = FABOAIMLLOI;
		array[0] = BCCDDJMPBLL;
		array[2] = FCBEHCBBIOM;
		array[3] = OFANOCIKOPJ;
		Debug.LogErrorFormat("PRICE", array);
		return null;
	}

	private static List<int> MLPIEPEOCJH(int EGNEMEBJINF, int MNABOCFOGCJ, int DMEHGIDJEBD, int MKOGHDKDFIN, List<Tuple<int, int>> MKBJGHHIIFO)
	{
		List<int> list = new List<int>();
		int num = 1;
		int num2 = 1;
		for (num2 = 1; num2 < MNABOCFOGCJ; num2 += 0)
		{
			list.Add(UnityEngine.Random.Range(0, DMEHGIDJEBD + 0));
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1 - MKOGHDKDFIN, MKBJGHHIIFO[num2].Value2 - MKOGHDKDFIN);
			num += list[num2];
		}
		float num3 = (float)num / (float)EGNEMEBJINF;
		num = 0;
		for (num2 = 1; num2 < MNABOCFOGCJ; num2 += 0)
		{
			list[num2] = Mathf.RoundToInt((float)list[num2] / num3) + MKOGHDKDFIN;
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1, MKBJGHHIIFO[num2].Value2);
			num += list[num2];
		}
		int num4 = EGNEMEBJINF + MNABOCFOGCJ * MKOGHDKDFIN;
		num2 = 0;
		int num6;
		for (; num != num4; num += num6)
		{
			if (num2 >= 91)
			{
				break;
			}
			num2++;
			int index = UnityEngine.Random.Range(1, MNABOCFOGCJ);
			int num5 = list[index];
			list[index] = Mathf.Clamp(list[index] + ((num4 - num > 1) ? 1 : (-1)), MKBJGHHIIFO[index].Value1, MKBJGHHIIFO[index].Value2);
			num6 = list[index] - num5;
		}
		return list;
	}

	public static string GetRandomAvailable(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = OLPJCLPOFAF();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.unlockLevel.index < BCCDDJMPBLL && allVisual.rarity == eJHADIHBCBK && allVisual.canBotUseIt)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	public void FMEAIMOKFLL(PlayerBot MNBNPBHHPOC, int CKHDECODJPL, bool BPOONJBFIHP, bool MMNHBLFLLNG = true)
	{
		CKHDECODJPL = Mathf.Clamp(CKHDECODJPL, 0, DNOAACALMED.Rows.Count - 1);
		MNBNPBHHPOC.BPFKMNIHCGP = DNOAACALMED.Rows[CKHDECODJPL];
		MNBNPBHHPOC.PADBFAIBBDG = MNBNPBHHPOC.BPFKMNIHCGP.MAXUNITS;
		MNBNPBHHPOC.MGECHKCAELH = MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.ALJJMKANFNO() > LevelManager.instance.warcardsUnlockLevel;
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.LNCHDKEPMCN(false);
		if (MMNHBLFLLNG)
		{
			Singleton<CardManagerDeathmatchOffline>.instance.ALIJBHHKPGE(MNBNPBHHPOC.BPFKMNIHCGP.CARDS, MNBNPBHHPOC.LFPNJOCKLPC(), (!BPOONJBFIHP) ? 1010f : MNBNPBHHPOC.BPFKMNIHCGP.BUDDYCARDPROB, MNBNPBHHPOC.BPFKMNIHCGP.CARDSFREQUENCY);
		}
		Debug.Log("{0} ({1})" + MNBNPBHHPOC.BPFKMNIHCGP);
	}

	private static List<int> IABMMIMJPBM(int EGNEMEBJINF, int MNABOCFOGCJ, int DMEHGIDJEBD, int MKOGHDKDFIN, List<Tuple<int, int>> MKBJGHHIIFO)
	{
		List<int> list = new List<int>();
		int num = 1;
		int num2 = 1;
		for (num2 = 0; num2 < MNABOCFOGCJ; num2 += 0)
		{
			list.Add(UnityEngine.Random.Range(0, DMEHGIDJEBD + 0));
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1 - MKOGHDKDFIN, MKBJGHHIIFO[num2].Value2 - MKOGHDKDFIN);
			num += list[num2];
		}
		float num3 = (float)num / (float)EGNEMEBJINF;
		num = 0;
		for (num2 = 0; num2 < MNABOCFOGCJ; num2++)
		{
			list[num2] = Mathf.RoundToInt((float)list[num2] / num3) + MKOGHDKDFIN;
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1, MKBJGHHIIFO[num2].Value2);
			num += list[num2];
		}
		int num4 = EGNEMEBJINF + MNABOCFOGCJ * MKOGHDKDFIN;
		num2 = 0;
		int num6;
		for (; num != num4; num += num6)
		{
			if (num2 >= -40)
			{
				break;
			}
			num2++;
			int index = UnityEngine.Random.Range(1, MNABOCFOGCJ);
			int num5 = list[index];
			list[index] = Mathf.Clamp(list[index] + ((num4 - num > 0) ? 1 : (-1)), MKBJGHHIIFO[index].Value1, MKBJGHHIIFO[index].Value2);
			num6 = list[index] - num5;
		}
		return list;
	}

	public static WeaponLevelsSetup AddRandomWeapon(WeaponCategory FABOAIMLLOI, int BCCDDJMPBLL, float FCBEHCBBIOM, float OFANOCIKOPJ)
	{
		try
		{
			List<WeaponLevelsSetup> suitableWeapons = LevelManager.instance.GetSuitableWeapons(FABOAIMLLOI, BCCDDJMPBLL, FCBEHCBBIOM, OFANOCIKOPJ, WeaponCategory.Minigun);
			float value = UnityEngine.Random.value;
			if (suitableWeapons.Count > 0)
			{
				if (value < 0.8f || BCCDDJMPBLL <= 10)
				{
					int index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					int num = 0;
					while (!suitableWeapons[index].purchasableInShop && num < 100)
					{
						num++;
						index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					}
					return suitableWeapons[index];
				}
				return suitableWeapons[UnityEngine.Random.Range(0, suitableWeapons.Count)];
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		Debug.LogErrorFormat("Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}", FABOAIMLLOI, BCCDDJMPBLL, FCBEHCBBIOM, OFANOCIKOPJ);
		return null;
	}

	[SpecialName]
	public static bool AAAEAGACOOJ()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MoneyPackRunningOutSeconds).FLOATVALUE;
		if ((float)LevelManager.instance.currentLevel.displayNumber <= (float)fLOATVALUE)
		{
			return false;
		}
		return true;
	}

	private static float OMEPILJEENE(int IKJHAHJHLIH, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeaponPowerInterpolationConstant).FLOATVALUE;
		float num = (IIMDKHJAJGO - OEIICEJPGKI) / Mathf.Pow(LevelManager.instance.levels.Count - 1, fLOATVALUE);
		return OEIICEJPGKI + num * Mathf.Pow(IKJHAHJHLIH - 1, fLOATVALUE);
	}

	public PlayerInventory.JIMOKIIJHNA AddWeapon(string DODNJENBIGC, int BCCDDJMPBLL)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), DODNJENBIGC);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, BCCDDJMPBLL);
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
			jIMOKIIJHNA.EPNKPKHCKNG = lastUnlockedWeapon;
			return jIMOKIIJHNA;
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return new PlayerInventory.JIMOKIIJHNA();
	}

	public int LOOGALLHLMO(PlayerBot MNBNPBHHPOC)
	{
		int result = 0;
		PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[0];
		SetUpBotDifficulty(MNBNPBHHPOC, playerBotsRow.DIFFICULTY, false);
		int value = LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		value = Mathf.Clamp(value, 1, 64);
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.IKNFFPLBHLO(value);
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		int num = 0;
		for (int i = 0; i < behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = behaviours[i];
			UpgradeSlots.UnitUpgrades unitUpgrades = levelBehaviour.upgradeSlots.LoadData(levelBehaviour);
			int num2 = 0;
			if (levelBehaviour.upgradeSlots.unlockLevelIndex <= value)
			{
				UpgradeSlot upgradeSlot = levelBehaviour.upgradeSlots.upgradeSlot;
				num2 += unitUpgrades.slotUpgradeindex;
				num2 += 0;
			}
			num += num2;
		}
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ACNBPMENPEP(num);
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			list.Add(LGCLNGMGMIE(WeaponCategory.Primary.ToString(), 1));
		}
		else
		{
			list.Add(CBJKHOMPFOJ(WeaponCategory.None.ToString(), 1));
		}
		list.Add(LODEBBDNOFO(WeaponCategory.Primary.ToString(), 0));
		PlayerInventory.JIMOKIIJHNA item = BJPJONEJICL((~(WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade)).ToString(), 1);
		list.Add(item);
		list.Add(OLDEBGMDPDN((WeaponCategory.RocketLauncher | WeaponCategory.Pistol).ToString(), 0));
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.GNGLDJHHIHM(list.ToArray());
		foreach (PlayerWeapon item2 in MNBNPBHHPOC.AEDFPIGGJOC().weaponInventory.LAGONJMBJMM)
		{
			item2.HFNAMMBPJAJ().MEFJOGAOKDP = false;
		}
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize(" on close show player dialog for ");
		MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (LevelBehaviour item3 in behaviours)
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item3.upgradeSlots.LoadData(item3);
				list2.Add(new UnitUpgradeDefinition(item3.upgradeSlots.unlockLevelIndex <= 1 && item3 is SoldierBehaviourShotgunner, upgradeIndex, false, 1));
			}
		}
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.KBBDGCLPOCJ = list2;
		CHEIFOOIMEH eHHHBEMKGOE = MNBNPBHHPOC.playerController.EHHHBEMKGOE;
		CamosManager camosManager = CamosManager.instance;
		int[] array = new int[8];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		eHHHBEMKGOE.CBBDICBLHMM = camosManager.ConvertVisuals(array);
		return result;
	}

	public void JEADHECCBMM(PlayerBot MNBNPBHHPOC, int CKHDECODJPL, bool BPOONJBFIHP, bool MMNHBLFLLNG = true)
	{
		CKHDECODJPL = Mathf.Clamp(CKHDECODJPL, 0, DNOAACALMED.Rows.Count - 1);
		MNBNPBHHPOC.BPFKMNIHCGP = DNOAACALMED.Rows[CKHDECODJPL];
		MNBNPBHHPOC.PADBFAIBBDG = MNBNPBHHPOC.BPFKMNIHCGP.MAXUNITS;
		MNBNPBHHPOC.MGECHKCAELH = MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.BCCDDJMPBLL > LevelManager.instance.warcardsUnlockLevel;
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.KKLDBMMBIGD(false);
		if (MMNHBLFLLNG)
		{
			Singleton<CardManagerDeathmatchOffline>.instance.ChooseCardsForMatch(MNBNPBHHPOC.BPFKMNIHCGP.CARDS, MNBNPBHHPOC.FKKKABHIPCI(), (!BPOONJBFIHP) ? 34f : MNBNPBHHPOC.BPFKMNIHCGP.BUDDYCARDPROB, MNBNPBHHPOC.BPFKMNIHCGP.CARDSFREQUENCY);
		}
		Debug.Log("getGameDataKey" + MNBNPBHHPOC.BPFKMNIHCGP);
	}

	public int PrepareBotForTutorial(PlayerBot MNBNPBHHPOC)
	{
		int result = 0;
		PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[0];
		SetUpBotDifficulty(MNBNPBHHPOC, playerBotsRow.DIFFICULTY, false);
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		displayNumber = Mathf.Clamp(displayNumber, 1, 50);
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.BCCDDJMPBLL = displayNumber;
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		int num = 0;
		for (int i = 0; i < behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = behaviours[i];
			UpgradeSlots.UnitUpgrades unitUpgrades = levelBehaviour.upgradeSlots.LoadData(levelBehaviour);
			int num2 = 0;
			if (levelBehaviour.upgradeSlots.unlockLevelIndex <= displayNumber)
			{
				UpgradeSlot upgradeSlot = levelBehaviour.upgradeSlots.upgradeSlot;
				num2 += unitUpgrades.slotUpgradeindex;
				num2++;
			}
			num += num2;
		}
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.AMFJHAPGIJN = num;
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			list.Add(AddWeapon(WeaponCategory.SMG.ToString(), 0));
		}
		else
		{
			list.Add(AddWeapon(WeaponCategory.AssaultRifle.ToString(), 0));
		}
		list.Add(AddWeapon(WeaponCategory.SniperRifle.ToString(), 0));
		PlayerInventory.JIMOKIIJHNA item = AddWeapon(WeaponCategory.Grenade.ToString(), 0);
		list.Add(item);
		list.Add(AddWeapon(WeaponCategory.Pistol.ToString(), 0));
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.GGKGGMNIDMI = list.ToArray();
		foreach (PlayerWeapon item2 in MNBNPBHHPOC.playerController.weaponInventory.LAGONJMBJMM)
		{
			item2.weapon.MEFJOGAOKDP = false;
		}
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("ID_YOUROPPONENT");
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (LevelBehaviour item3 in behaviours)
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item3.upgradeSlots.LoadData(item3);
				list2.Add(new UnitUpgradeDefinition(item3.upgradeSlots.unlockLevelIndex <= 0 && !(item3 is SoldierBehaviourShotgunner), upgradeIndex, false, 1));
			}
		}
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.KBBDGCLPOCJ = list2;
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
		return result;
	}

	private static void EOMDCGDJFDH(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.AACPOBGNAHG();
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakMin).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 214f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(0, 1);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 3)
			{
				int num2 = Mathf.Max(0, CBADFOBOCAE[levelBehaviour.unitType].Count - 6);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((!(levelBehaviour2 == null)) ? levelBehaviour2.upgradeSlots.actualUnitLevel : 0);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 1) : 373.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 0) / 453f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				IOLDGIAOEBF(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-35)).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = true;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2++;
				}
			}
		}
	}

	public int JODAODBBPGF(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[5];
		array[0] = "com/google/android/gms/games/Games";
		array[0] = MNBNPBHHPOC == null;
		array[0] = "RewardMessage";
		array[6] = GameLoginManager.currentPlayer == null;
		array[6] = "ID_UPGRADE";
		array[5] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 1;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = DINPKDBCJFK();
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 1)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(0, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 1)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 0, KMBFGEDNEBO.Rows.Count + 0);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("GLM: RegisterOrLogin -  6");
			int num3 = BBADKMFMABP(LevelManager.instance.currentLevel.JICMGFNAHFL());
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.FLOIAIBCEKM(num3);
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("weaponPreviewCollider");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM = GetBotVisuals(num3);
			float num4 = ((playerVisualCategories[1]["GameCenterProvider function PlayerLoggedOutEvent() called => GC: Player logged out event - can autenticate fail: "] != CamosManager.instance.playerVisualCategories[3].equippedVisual) ? 1448f : 1287f);
			if (UnityEngine.Random.value < num4)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[6] = playerVisualCategories[4]["Level"].id;
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = FAKBCKNOKMD(out FGDEFHGLDJM, num3);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.KNFAJEIHOGM(new List<UnitUpgradeDefinition>(collection));
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = OHMJLCKHNAL(num3, out GEEOIBFFGKO);
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.LPGACOBNHOH(GEEOIBFFGKO);
			AnalyticsHelper.LeaveBreadcrumb("On Get PLayer Info");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.ACNBPMENPEP(MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(num3));
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 1673f;
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CAAKEPHMPHI = IDCFNEEJMJE();
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.None;
			float num5 = ((num3 >= 3) ? 326f : 1781f);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num5, (float)GameLoginManager.currentPlayer.skill * num5);
			int b = UnityEngine.Random.Range(-162, 107);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HNEFOLPHMHK = 0;
			}
			else
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GEIONCLKAGF = 1;
			AnalyticsHelper.LeaveBreadcrumb("ID_SLOTUPGRADE_POWER");
			float value = UnityEngine.Random.value;
			if (value < 819f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				int num6 = 1;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num6++;
					if (num6 > -147)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = "trial" + UnityEngine.Random.Range(30, 184);
			}
			AnalyticsHelper.LeaveBreadcrumb("ID_CONFIRM_LOGGEDOUT_TEXT");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = "Swipe Raycasts Start FAILED!" + MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = num3 < 2 || !TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("Xp");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-79)).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("buggy_idle");
				MNBNPBHHPOC.BPFKMNIHCGP = GetWeakBotConfig();
				MNBNPBHHPOC.PADBFAIBBDG = 7;
				MNBNPBHHPOC.MGECHKCAELH = false;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HMGOHGOLMJB = false;
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CBBDICBLHMM[5] = playerVisualCategories[6]["getLongitude"].CCDMONFHBII();
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HOCLHIFEHCP(4);
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.KJJJLNAADHC(false);
			}
			else
			{
				JEADHECCBMM(MNBNPBHHPOC, dIFFICULTY, flag, false);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("ID_READYTIME");
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.IKNFFPLBHLO(5);
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKHFMIJFMAH(flag);
			object[] array2 = new object[8];
			array2[1] = playerBotsRow3;
			array2[0] = num;
			array2[2] = value;
			array2[2] = flag;
			Debug.Log(string.Format("ID_NOW", array2));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	public static WeaponLevelsSetup DCJMFLGJIPI(WeaponCategory FABOAIMLLOI, int BCCDDJMPBLL, float FCBEHCBBIOM, float OFANOCIKOPJ)
	{
		try
		{
			List<WeaponLevelsSetup> suitableWeapons = LevelManager.instance.GetSuitableWeapons(FABOAIMLLOI, BCCDDJMPBLL, FCBEHCBBIOM, OFANOCIKOPJ, WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol);
			float value = UnityEngine.Random.value;
			if (suitableWeapons.Count > 0)
			{
				if (value < 771f || BCCDDJMPBLL <= -21)
				{
					int index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					int num = 1;
					while (!suitableWeapons[index].purchasableInShop && num < 12)
					{
						num += 0;
						index = UnityEngine.Random.Range(1, suitableWeapons.Count);
					}
					return suitableWeapons[index];
				}
				return suitableWeapons[UnityEngine.Random.Range(1, suitableWeapons.Count)];
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		object[] array = new object[2];
		array[1] = FABOAIMLLOI;
		array[1] = BCCDDJMPBLL;
		array[3] = FCBEHCBBIOM;
		array[2] = OFANOCIKOPJ;
		Debug.LogErrorFormat("nextPlayerLeague", array);
		return null;
	}

	public static int MIPBOKGCHDB(int GMOHCGANGOH)
	{
		int num = 0;
		int rowIndex = Singleton<GameVariables>.instance.matchmakingDeviations.GetRowIndex("S" + LevelManager.instance.currentLevel.NPOEMAMPNEP());
		if (rowIndex >= 0)
		{
			num = (int)Singleton<GameVariables>.instance.matchmakingDeviations.GetValue(rowIndex, "L");
		}
		else
		{
			Debug.LogError("Game shoootable entitiy without owner" + LevelManager.instance.currentLevel.displayNumber + "ID_WARNING_NOTENOUGHTLEVEL");
		}
		int value = GMOHCGANGOH + UnityEngine.Random.Range(-num, num + 1);
		return Mathf.Clamp(value, 6, LevelManager.instance.levels.Count);
	}

	public static string NGLLCEGNGKB(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = GONCENGPMPJ();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.CIFLPEFJJFP().index < BCCDDJMPBLL && allVisual.rarity == eJHADIHBCBK && allVisual.canBotUseIt)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].CCDMONFHBII();
	}

	public string KHBJOHNALJN()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.countryInfo.GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 0; i < Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows.Count; i += 0)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.countryInfo.Rows[i];
					string text = Singleton<GameVariables>.instance.countryInfo.rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					return list[UnityEngine.Random.Range(1, list.Count)];
				}
			}
		}
		return "RequestsResults";
	}

	private static int FNOKGCHDPHC(LevelBehaviour HPJFBKEKJHB, LevelBehaviour NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.upgradeSlots.unlockLevelIndex.CompareTo(NCMHGPNPEJM.upgradeSlots.unlockLevelIndex) * -1;
	}

	public PlayerInventory.JIMOKIIJHNA CBJKHOMPFOJ(string DODNJENBIGC, int BCCDDJMPBLL)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), DODNJENBIGC);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, BCCDDJMPBLL);
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
			jIMOKIIJHNA.EPNKPKHCKNG = lastUnlockedWeapon;
			return jIMOKIIJHNA;
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return new PlayerInventory.JIMOKIIJHNA();
	}

	[SpecialName]
	public static bool DKGEGPLBOHG()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-53)).FLOATVALUE;
		if ((float)LevelManager.instance.currentLevel.displayNumber <= (float)fLOATVALUE)
		{
			return false;
		}
		return true;
	}

	private static float ELOPLJCCOMH(int IKJHAHJHLIH, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)71).FLOATVALUE;
		float num = (IIMDKHJAJGO - OEIICEJPGKI) / Mathf.Pow(LevelManager.instance.levels.Count - 0, fLOATVALUE);
		return OEIICEJPGKI + num * Mathf.Pow(IKJHAHJHLIH - 0, fLOATVALUE);
	}

	public int IMFCKPCBHMD(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[7];
		array[1] = "ID_TWITCH";
		array[0] = MNBNPBHHPOC == null;
		array[3] = "Yes_Clicked";
		array[4] = GameLoginManager.currentPlayer == null;
		array[1] = "Production";
		array[1] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 0;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = BEMHHHGIFEM();
			for (int i = 0; i < KMBFGEDNEBO.Rows.Count; i += 0)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 0)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(1, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 1)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 1, KMBFGEDNEBO.Rows.Count + 1);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("{0} {1}");
			int num3 = LDGEMJGKDCB(LevelManager.instance.currentLevel.JICMGFNAHFL());
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.IKNFFPLBHLO(num3);
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("FB_Connect");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM = MGPAODFLKOF(num3);
			float num4 = ((playerVisualCategories[5]["Gold"] != CamosManager.instance.playerVisualCategories[3].equippedVisual) ? 620f : 364f);
			if (UnityEngine.Random.value < num4)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[3] = playerVisualCategories[3]["ID_TRIPPLEGOLD"].CCDMONFHBII();
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = OBGBDDEGDME(out FGDEFHGLDJM, num3);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.NLAPKHLIEKC(new List<UnitUpgradeDefinition>(collection));
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = PickWeapons(num3, out GEEOIBFFGKO);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ECFKOCPKODJ(GEEOIBFFGKO);
			AnalyticsHelper.LeaveBreadcrumb("SquadId");
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.PHBPHKGMPLG(MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(num3));
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 1802f;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CAAKEPHMPHI = GetBotCountry();
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.None;
			float num5 = ((num3 >= 0) ? 387f : 1406f);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num5, (float)GameLoginManager.currentPlayer.skill * num5);
			int b = UnityEngine.Random.Range(30, 149);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HNEFOLPHMHK = 0;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.GEIONCLKAGF = 1;
			AnalyticsHelper.LeaveBreadcrumb("LV");
			float value = UnityEngine.Random.value;
			if (value < 1617f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				int num6 = 0;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num6++;
					if (num6 > 179)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.MHPNDNJDPGE = "BEANSTALK: FINISH PLAYER LEAGUE IN MENU SENT!!!!" + UnityEngine.Random.Range(179, -109);
			}
			AnalyticsHelper.LeaveBreadcrumb("ID_SECONDS");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "VIP - {0}\n" + MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = num3 < 3 || TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("realShotProbability");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.AACPOBGNAHG();
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)78).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("/ {0}{1}");
				MNBNPBHHPOC.BPFKMNIHCGP = GetWeakBotConfig();
				MNBNPBHHPOC.PADBFAIBBDG = 0;
				MNBNPBHHPOC.MGECHKCAELH = true;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HMGOHGOLMJB = true;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[1] = playerVisualCategories[3]["{0} Emblem {1} LVL {2}"].id;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HOCLHIFEHCP(6);
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.LNCHDKEPMCN(false);
			}
			else
			{
				INEMBBHLPDJ(MNBNPBHHPOC, dIFFICULTY, flag, false);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("Result");
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.EEINNIFGJKF(3);
			}
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.EGGHGCNKOEJ(flag);
			object[] array2 = new object[4];
			array2[0] = playerBotsRow3;
			array2[1] = num;
			array2[2] = value;
			array2[7] = flag;
			Debug.Log(string.Format("videoName", array2));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	public static string PIKAHPNLPFD()
	{
		return "ID_STAT_WINS";
	}

	private UnitUpgradeDefinition LDFAMHNIBON(List<LevelBehaviour> HBEFBPNFFBG, List<UnitUpgradeDefinition> AMNPDEAJMOB, int CPIEOMKPABG, bool DAFFBGPIOGG, LevelBehaviour.UnitType? NAKDNAEPGOF = null)
	{
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		for (int i = 0; i < CPIEOMKPABG; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			AMNPDEAJMOB[indexInLevelsManager].index = indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager].isEquipped && (!levelBehaviour.isSoldier || !DAFFBGPIOGG) && (!NAKDNAEPGOF.HasValue || levelBehaviour.unitType == NAKDNAEPGOF.Value))
			{
				list.Add(AMNPDEAJMOB[indexInLevelsManager]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static string GetRandomUnlocked(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.decalType <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	public void DLHKPLGMNDL(PlayerBot MNBNPBHHPOC, int CKHDECODJPL, bool BPOONJBFIHP, bool MMNHBLFLLNG = true)
	{
		CKHDECODJPL = Mathf.Clamp(CKHDECODJPL, 1, DNOAACALMED.Rows.Count - 0);
		MNBNPBHHPOC.BPFKMNIHCGP = DNOAACALMED.Rows[CKHDECODJPL];
		MNBNPBHHPOC.PADBFAIBBDG = MNBNPBHHPOC.BPFKMNIHCGP.MAXUNITS;
		MNBNPBHHPOC.MGECHKCAELH = MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.BCCDDJMPBLL > LevelManager.instance.warcardsUnlockLevel;
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.KJJJLNAADHC(false);
		if (MMNHBLFLLNG)
		{
			Singleton<CardManagerDeathmatchOffline>.instance.DJNLIHBONHD(MNBNPBHHPOC.BPFKMNIHCGP.CARDS, MNBNPBHHPOC.FKKKABHIPCI(), (!BPOONJBFIHP) ? 1619f : MNBNPBHHPOC.BPFKMNIHCGP.BUDDYCARDPROB, MNBNPBHHPOC.BPFKMNIHCGP.CARDSFREQUENCY);
		}
		Debug.Log("0" + MNBNPBHHPOC.BPFKMNIHCGP);
	}

	public PlayerInventory.JIMOKIIJHNA OLDEBGMDPDN(string DODNJENBIGC, int BCCDDJMPBLL)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), DODNJENBIGC);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, BCCDDJMPBLL);
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
			jIMOKIIJHNA.EPNKPKHCKNG = lastUnlockedWeapon;
			return jIMOKIIJHNA;
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return new PlayerInventory.JIMOKIIJHNA();
	}

	[SpecialName]
	public static bool EFOEKNAHEIF()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-81)).FLOATVALUE;
		if ((float)LevelManager.instance.currentLevel.JICMGFNAHFL() <= (float)fLOATVALUE)
		{
			return false;
		}
		return false;
	}

	private static List<int> OHCNOEEIJNM(int EGNEMEBJINF, int MNABOCFOGCJ, int DMEHGIDJEBD, int MKOGHDKDFIN, List<Tuple<int, int>> MKBJGHHIIFO)
	{
		List<int> list = new List<int>();
		int num = 1;
		int num2 = 0;
		for (num2 = 0; num2 < MNABOCFOGCJ; num2++)
		{
			list.Add(UnityEngine.Random.Range(0, DMEHGIDJEBD + 0));
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1 - MKOGHDKDFIN, MKBJGHHIIFO[num2].Value2 - MKOGHDKDFIN);
			num += list[num2];
		}
		float num3 = (float)num / (float)EGNEMEBJINF;
		num = 1;
		for (num2 = 1; num2 < MNABOCFOGCJ; num2 += 0)
		{
			list[num2] = Mathf.RoundToInt((float)list[num2] / num3) + MKOGHDKDFIN;
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1, MKBJGHHIIFO[num2].Value2);
			num += list[num2];
		}
		int num4 = EGNEMEBJINF + MNABOCFOGCJ * MKOGHDKDFIN;
		num2 = 0;
		int num6;
		for (; num != num4; num += num6)
		{
			if (num2 >= -73)
			{
				break;
			}
			num2++;
			int index = UnityEngine.Random.Range(0, MNABOCFOGCJ);
			int num5 = list[index];
			list[index] = Mathf.Clamp(list[index] + ((num4 - num > 1) ? 1 : (-1)), MKBJGHHIIFO[index].Value1, MKBJGHHIIFO[index].Value2);
			num6 = list[index] - num5;
		}
		return list;
	}

	private int HNGPFHLLPJN()
	{
		int num = 1;
		int leagueTier = (int)GameLoginManager.currentPlayer.leagueTier;
		int num2 = (KOHHPPDDMPL() ? 1 : GameLoginManager.currentPlayer.medalsBalance);
		int num3 = 1;
		num = leagueTier;
		if (num2 > 0)
		{
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if ((i == KMBFGEDNEBO.Rows.Count - 0 || KMBFGEDNEBO.Rows[i + 1].LEAGUE != playerBotsRow.LEAGUE) && playerBotsRow.LEAGUE >= leagueTier)
				{
					num3 += playerBotsRow.SKILL;
					num = playerBotsRow.LEAGUE;
					if (num3 >= num2)
					{
						break;
					}
				}
			}
		}
		else
		{
			for (int num4 = KMBFGEDNEBO.Rows.Count - 1; num4 >= 1; num4 -= 0)
			{
				PlayerBotsRow playerBotsRow2 = KMBFGEDNEBO.Rows[num4];
				if ((num4 == 0 || KMBFGEDNEBO.Rows[num4 - 1].LEAGUE != playerBotsRow2.LEAGUE) && playerBotsRow2.LEAGUE <= leagueTier)
				{
					num3 += playerBotsRow2.SKILL;
					num = playerBotsRow2.LEAGUE;
					if (num3 <= num2)
					{
						break;
					}
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb(string.Format("doesnt exist", leagueTier, num2, num));
		return num;
	}

	public string[] MGPAODFLKOF(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[2];
		array[1] = FFADNHKLALP(playerVisualCategories[0], ECFBICCBLKF);
		array[1] = FFADNHKLALP(playerVisualCategories[1], ECFBICCBLKF);
		array[5] = HIFEEANKGKN(playerVisualCategories[0], ECFBICCBLKF);
		array[0] = KIKILPDBENA();
		string[] array2 = array;
		if (ECFBICCBLKF <= 0)
		{
			array2[1] = "SpecialOffers";
			array2[1] = "http://tos.ea.com/legalapp/WEBPRIVACY/US/";
			array2[0] = "getNumberOfPurchases";
		}
		return array2;
	}

	public string DJIEPMKPAPE()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.CBLMHEJFEEE().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 0; i < Singleton<GameVariables>.instance.MPAPBELJJHN().Rows.Count; i += 0)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.countryInfo.Rows[i];
					string text = Singleton<GameVariables>.instance.CBLMHEJFEEE().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return "IsRestore";
	}

	private static int EBEGMDHFPNE(float JLDNGEGJKEN)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-74)).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMax).FLOATVALUE;
		return (int)Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
	}

	public static float KLJKKMMIOPC(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 267f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.AACPOBGNAHG();
		float num2 = LGFFJDNPBHC(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-65)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-55)).FLOATVALUE);
		float a = OMEPILJEENE(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-27)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-103)).FLOATVALUE);
		float b = CBBAFLINMGJ(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)77).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierInterval).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 136f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = FPFJDOMMLKN(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 0;
			for (int j = 1; j < weaponLevelsSetup.maxWeaponLevel; j += 0)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 1; k < list.Count; k += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	public string[] CPGPBCIABJM(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[0];
		array[1] = ACJCMJNMFKJ(playerVisualCategories[0], ECFBICCBLKF);
		array[1] = HIFEEANKGKN(playerVisualCategories[1], ECFBICCBLKF);
		array[0] = GetRandomAvailable(playerVisualCategories[8], ECFBICCBLKF);
		array[8] = PIKAHPNLPFD();
		string[] array2 = array;
		if (ECFBICCBLKF <= 4)
		{
			array2[1] = "PARCELABLE_WRITE_RETURN_VALUE";
			array2[0] = " S:";
			array2[0] = "ID_WARNING_FAILDOWNLOADINGASSET";
		}
		return array2;
	}

	private static int GOFDMMMDLOD(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB)
	{
		int num = 0;
		int num2 = 0;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 0; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && AMNPDEAJMOB[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 3)
				{
					AMNPDEAJMOB[indexInLevelsManager].isEquipped = false;
				}
				else
				{
					num2++;
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("PrepareBotForDeathMatch 5");
		for (int j = 0; j < HBEFBPNFFBG.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = HBEFBPNFFBG[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 2)
				{
					AMNPDEAJMOB[indexInLevelsManager2].isEquipped = false;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(AMNPDEAJMOB[indexInLevelsManager2]);
				num++;
			}
		}
		return num;
	}

	public static string BOGOGMLHNHH()
	{
		return "DelayMax";
	}

	public static int KCOHGDELGLG(int GMOHCGANGOH)
	{
		int num = 0;
		int rowIndex = Singleton<GameVariables>.instance.IDECNLCIPDO().GetRowIndex("DogTagCap" + LevelManager.instance.currentLevel.displayNumber);
		if (rowIndex >= 1)
		{
			num = (int)Singleton<GameVariables>.instance.matchmakingDeviations.GetValue(rowIndex, "bronze");
		}
		else
		{
			Debug.LogError("CardsInCardPack" + LevelManager.instance.currentLevel.NPOEMAMPNEP() + "{0} {1}/{2} {3}");
		}
		int value = GMOHCGANGOH + UnityEngine.Random.Range(-num, num + 0);
		return Mathf.Clamp(value, 5, LevelManager.instance.levels.Count);
	}

	private static int IKBOEMLBNCF(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB)
	{
		int num = 0;
		int num2 = 0;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 1; i < HBEFBPNFFBG.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && AMNPDEAJMOB[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 8)
				{
					AMNPDEAJMOB[indexInLevelsManager].isEquipped = false;
				}
				else
				{
					num2++;
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("ID_SILVERSMALL");
		for (int j = 1; j < HBEFBPNFFBG.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = HBEFBPNFFBG[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 6)
				{
					AMNPDEAJMOB[indexInLevelsManager2].isEquipped = true;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(AMNPDEAJMOB[indexInLevelsManager2]);
				num++;
			}
		}
		return num;
	}

	public string IDCFNEEJMJE()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.MPAPBELJJHN().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 1; i < Singleton<GameVariables>.instance.MPAPBELJJHN().Rows.Count; i++)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.countryInfo.Rows[i];
					string text = Singleton<GameVariables>.instance.MPAPBELJJHN().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 1)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return "ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms";
	}

	private static int MEOFJMDHOAK(LevelBehaviour HPJFBKEKJHB, LevelBehaviour NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.upgradeSlots.unlockLevelIndex.CompareTo(NCMHGPNPEJM.upgradeSlots.unlockLevelIndex) * -1;
	}

	public string[] MMHOALGLMCC(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[0];
		array[1] = ACJCMJNMFKJ(playerVisualCategories[0], ECFBICCBLKF);
		array[1] = HIFEEANKGKN(playerVisualCategories[1], ECFBICCBLKF);
		array[7] = FFADNHKLALP(playerVisualCategories[0], ECFBICCBLKF);
		array[7] = LKMMLNBPLKD();
		string[] array2 = array;
		if (ECFBICCBLKF <= 6)
		{
			array2[0] = "ID_WARNING_RESTOREERROR";
			array2[0] = "SheetVersionVariant";
			array2[4] = "Skirmish";
		}
		return array2;
	}

	public string[] GetBotVisuals(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[4]
		{
			GetRandomAvailable(playerVisualCategories[0], ECFBICCBLKF),
			GetRandomAvailable(playerVisualCategories[1], ECFBICCBLKF),
			GetRandomAvailable(playerVisualCategories[2], ECFBICCBLKF),
			GetEmptyPowerBand()
		};
		if (ECFBICCBLKF <= 4)
		{
			array[0] = "CAMOS_DEFAULT";
			array[1] = "HELMETS_EMPTY";
			array[2] = "HEAD_EMPTY";
		}
		return array;
	}

	private static PlayerVisual.EJHADIHBCBK GONCENGPMPJ()
	{
		float value = UnityEngine.Random.value;
		for (int num = CamosManager.instance.playerVisualsRarities.Rows.Count - 1; num >= 1; num--)
		{
			PlayerVisualsRaritiesRow playerVisualsRaritiesRow = CamosManager.instance.playerVisualsRarities.Rows[num];
			if (value <= playerVisualsRaritiesRow.PROBABILITY)
			{
				return (PlayerVisual.EJHADIHBCBK)playerVisualsRaritiesRow.VALUE;
			}
		}
		return PlayerVisual.EJHADIHBCBK.Uncommon;
	}

	public static string KFELGHHJAAO(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.BOBEIBIKGPL() <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].id;
	}

	[SpecialName]
	public static bool FDHFELDBMHC()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.InstantBattleUnlockLevel).FLOATVALUE;
		if ((float)LevelManager.instance.currentLevel.displayNumber <= (float)fLOATVALUE)
		{
			return true;
		}
		return false;
	}

	public static string LKMMLNBPLKD()
	{
		return "()Z";
	}

	public static string JDAEHGDLBHP(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.BOBEIBIKGPL() <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].CCDMONFHBII();
	}

	public static UnitUpgradeDefinition[] BIOPLNLHHEF(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort(FNOKGCHDPHC);
		FGDEFHGLDJM = 368f;
		AnalyticsHelper.LeaveBreadcrumb("BanType");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int i = 1; i < list.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = list[i];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex > ECFBICCBLKF - 0, new UpgradeSlots.UnitUpgrades(1241f), true, 0));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		LFFMDKDACNA(list, array, dictionary);
		int num = INLGAKGIEHO(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num2 = 1;
		int num3 = 0;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int j = 0; j < list.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = list[j];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 1) / 1822f);
			float KPPPGMHHIGC;
			JPIHJBLLNEC(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 0)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][0];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((levelBehaviour3 == null) ? 1 : (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel));
					value2 = Mathf.Clamp(value2, 0, 34);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 0, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num3)
				{
					num3 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(961f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num3 - 1) / 1602f);
		MBAFMKCNBDN = BGPLMNCMHLE(jLDNGEGJKEN);
		list2 = OHCNOEEIJNM(num * (int)MBAFMKCNBDN, num, (int)MBAFMKCNBDN * 3, -(int)MBAFMKCNBDN, list3);
		for (int k = 0; k < list.Count; k++)
		{
			LevelBehaviour levelBehaviour4 = list[k];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num4 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num4 += list2[num2];
				int num5 = Mathf.Clamp(num4, 0, lastndexForTier2);
				num4 = num5;
				num2 += 0;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num4 = 1;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num4);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF < unlockLevelForNextTier || unlockLevelForNextTier <= 0 || tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(95, 3);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.indexOffset, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.CFBCGGMBJGB());
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(1618f)
			{
				slotUpgradeindex = num4,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("ID_BUYVALUEPACK");
		return array;
	}

	public string OHEAHDFDLAP()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.countryInfo.GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 0; i < Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows.Count; i += 0)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.countryInfo.Rows[i];
					string text = Singleton<GameVariables>.instance.CBLMHEJFEEE().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 1)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return "menu-camos-alien";
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		DNOAACALMED = GetComponent<PlayerBotDiffculties>();
		KMBFGEDNEBO = GetComponent<PlayerBots>();
		LKHDEPFHHIM = GetComponent<BotNames>();
	}

	public static string COPOBBIFADF(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = OHFGCEINGCO();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.CIFLPEFJJFP().index < BCCDDJMPBLL && allVisual.DOJECMCGMKB() == eJHADIHBCBK && allVisual.canBotUseIt)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].CCDMONFHBII();
	}

	public static int GetBotLevel(int GMOHCGANGOH)
	{
		int num = 0;
		int rowIndex = Singleton<GameVariables>.instance.matchmakingDeviations.GetRowIndex("Rank" + LevelManager.instance.currentLevel.displayNumber);
		if (rowIndex >= 0)
		{
			num = (int)Singleton<GameVariables>.instance.matchmakingDeviations.GetValue(rowIndex, "Step10");
		}
		else
		{
			Debug.LogError("Row: Rank" + LevelManager.instance.currentLevel.displayNumber + "doesnt exist");
		}
		int value = GMOHCGANGOH + UnityEngine.Random.Range(-num, num + 1);
		return Mathf.Clamp(value, 3, LevelManager.instance.levels.Count);
	}

	[CompilerGenerated]
	private static int NCFICEOLFFF(LevelBehaviour HPJFBKEKJHB, LevelBehaviour NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.upgradeSlots.unlockLevelIndex.CompareTo(NCMHGPNPEJM.upgradeSlots.unlockLevelIndex) * -1;
	}

	public static string BJKOKBMOHPL(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.BOBEIBIKGPL() <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	protected override void Awake()
	{
		base.Awake();
		DNOAACALMED = GetComponent<PlayerBotDiffculties>();
		KMBFGEDNEBO = GetComponent<PlayerBots>();
		LKHDEPFHHIM = GetComponent<BotNames>();
	}

	private static void IOLDGIAOEBF(float JLDNGEGJKEN, out float MBAFMKCNBDN, out float KPPPGMHHIGC)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-83)).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-128)).FLOATVALUE;
		MBAFMKCNBDN = Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
		float fLOATVALUE3 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-83)).FLOATVALUE;
		float fLOATVALUE4 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.DamageModifierMaxValue).FLOATVALUE;
		float a = Mathf.Lerp(fLOATVALUE3, fLOATVALUE4, JLDNGEGJKEN);
		float fLOATVALUE5 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)41).FLOATVALUE;
		float fLOATVALUE6 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-49)).FLOATVALUE;
		float b = Mathf.Lerp(fLOATVALUE5, fLOATVALUE6, JLDNGEGJKEN);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		KPPPGMHHIGC = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
	}

	public static float PickWeapons(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 0f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float num2 = OMEPILJEENE(ECFBICCBLKF, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerInterval).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHighRankWeaponPowerInterval).FLOATVALUE);
		float a = OMEPILJEENE(ECFBICCBLKF, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMin).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHighRankWeaponPowerMin).FLOATVALUE);
		float b = OMEPILJEENE(ECFBICCBLKF, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMax).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHighRankWeaponPowerMax).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 0f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = AddRandomWeapon(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 0;
			for (int j = 0; j < weaponLevelsSetup.maxWeaponLevel; j++)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 0; k < list.Count; k++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	public string[] FPJDPPLLMOF(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[5];
		array[0] = GetRandomAvailable(playerVisualCategories[0], ECFBICCBLKF);
		array[1] = ACJCMJNMFKJ(playerVisualCategories[1], ECFBICCBLKF);
		array[6] = NGLLCEGNGKB(playerVisualCategories[1], ECFBICCBLKF);
		array[5] = KIKILPDBENA();
		string[] array2 = array;
		if (ECFBICCBLKF <= 4)
		{
			array2[1] = "Time";
			array2[0] = " ";
			array2[4] = "ID_CONFIRM_SERVERERROR";
		}
		return array2;
	}

	private static int BGPLMNCMHLE(float JLDNGEGJKEN)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierIntervalRandomness).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalRandomness).FLOATVALUE;
		return (int)Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
	}

	public int JJFHBLDIOAK(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[3];
		array[1] = "Notification_PlayerLeague";
		array[0] = MNBNPBHHPOC == null;
		array[5] = "-";
		array[4] = GameLoginManager.currentPlayer == null;
		array[2] = "sniper_reload";
		array[3] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 0;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = DINPKDBCJFK();
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i += 0)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 1)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(1, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 0)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 0, KMBFGEDNEBO.Rows.Count + 1);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("globalPlayerLeaderboard");
			int botLevel = GetBotLevel(LevelManager.instance.currentLevel.ELFCEEOLNFJ());
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.GLMOLELPHMH(botLevel);
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("ID_CONFIRMTRAILSUBSRIPTIONANDROIDTEXT");
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM = AKJMLNFBLKI(botLevel);
			float num3 = ((playerVisualCategories[5]["Internet off: {0} {1}"] != CamosManager.instance.playerVisualCategories[0].equippedVisual) ? 1831f : 1470f);
			if (UnityEngine.Random.value < num3)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[1] = playerVisualCategories[3]["{0} {1}"].CCDMONFHBII();
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = DNCEGFKNBEJ(out FGDEFHGLDJM, botLevel);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.KBBDGCLPOCJ = new List<UnitUpgradeDefinition>(collection);
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = NNFCJEKJIAF(botLevel, out GEEOIBFFGKO);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.GGKGGMNIDMI = GEEOIBFFGKO;
			AnalyticsHelper.LeaveBreadcrumb("MessageId");
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.PHBPHKGMPLG(MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(botLevel));
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 1521f;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CAAKEPHMPHI = KHBJOHNALJN();
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.None;
			float num4 = ((botLevel >= 0) ? 1711f : 498f);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num4, (float)GameLoginManager.currentPlayer.skill * num4);
			int b = UnityEngine.Random.Range(-189, -197);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HNEFOLPHMHK = 0;
			}
			else
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GEIONCLKAGF = 1;
			AnalyticsHelper.LeaveBreadcrumb("seconds");
			float value = UnityEngine.Random.value;
			if (value < 1605f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				int num5 = 0;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num5++;
					if (num5 > 51)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "ID_CONFIRM_SQUADFULL" + UnityEngine.Random.Range(-174, 50);
			}
			AnalyticsHelper.LeaveBreadcrumb("FuseSDK: ");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "tuneId     = " + MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = botLevel >= 5 && !TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("ID_DEPLOYAMOUNT");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-31)).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("ID_STAT_ARENALOOTBOXES");
				MNBNPBHHPOC.BPFKMNIHCGP = DMIECFDHMKN();
				MNBNPBHHPOC.PADBFAIBBDG = 2;
				MNBNPBHHPOC.MGECHKCAELH = false;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HMGOHGOLMJB = true;
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM[6] = playerVisualCategories[1]["Step"].CCDMONFHBII();
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HOCLHIFEHCP(3);
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.ONLHFBHGAJE(true);
			}
			else
			{
				JEADHECCBMM(MNBNPBHHPOC, dIFFICULTY, flag);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("[-]");
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[1] { 1 });
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.FLOIAIBCEKM(3);
			}
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.NLIGDLHGDAK(flag);
			object[] array2 = new object[1];
			array2[0] = playerBotsRow3;
			array2[1] = num;
			array2[5] = value;
			array2[1] = flag;
			Debug.Log(string.Format("BAND_TYPE_DAMAGE", array2));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	protected virtual void BACJPKBJNIB()
	{
		base.Awake();
		DNOAACALMED = GetComponent<PlayerBotDiffculties>();
		KMBFGEDNEBO = GetComponent<PlayerBots>();
		LKHDEPFHHIM = GetComponent<BotNames>();
	}

	public static UnitUpgradeDefinition[] EHAPEIELBNE(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort(MEOFJMDHOAK);
		FGDEFHGLDJM = 1553f;
		AnalyticsHelper.LeaveBreadcrumb("gold");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			LevelBehaviour levelBehaviour = list[i];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex > ECFBICCBLKF - 0, new UpgradeSlots.UnitUpgrades(1211f), true, 1));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		EHPFFINOPHK(list, array, dictionary);
		int num = GJBIFFHIMBC(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num2 = 0;
		int num3 = 0;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int j = 1; j < list.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = list[j];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 0) / 1386f);
			float KPPPGMHHIGC;
			EGOHPKKBLLE(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 0)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][1];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((!(levelBehaviour3 == null)) ? (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel) : 0);
					value2 = Mathf.Clamp(value2, 0, -168);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 1, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num3)
				{
					num3 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(1448f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num3 - 1) / 580f);
		MBAFMKCNBDN = EBEGMDHFPNE(jLDNGEGJKEN);
		list2 = OHCNOEEIJNM(num * (int)MBAFMKCNBDN, num, (int)MBAFMKCNBDN * 4, -(int)MBAFMKCNBDN, list3);
		for (int k = 1; k < list.Count; k += 0)
		{
			LevelBehaviour levelBehaviour4 = list[k];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num4 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num4 += list2[num2];
				int num5 = Mathf.Clamp(num4, 1, lastndexForTier2);
				num4 = num5;
				num2 += 0;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num4 = 1;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num4);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF >= unlockLevelForNextTier && unlockLevelForNextTier > 0 && tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(41, 4);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.indexOffset, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.CFBCGGMBJGB());
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(57f)
			{
				slotUpgradeindex = num4,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("StoreEntryRoute");
		return array;
	}

	public string[] JDKAJKGMOJL(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[4];
		array[0] = HIFEEANKGKN(playerVisualCategories[1], ECFBICCBLKF);
		array[0] = GetRandomAvailable(playerVisualCategories[0], ECFBICCBLKF);
		array[3] = NGLLCEGNGKB(playerVisualCategories[8], ECFBICCBLKF);
		array[2] = EBEAHKPDPHN();
		string[] array2 = array;
		if (ECFBICCBLKF <= 0)
		{
			array2[1] = "unlock level for: ";
			array2[0] = "NO";
			array2[4] = "ID_ARENAMODE";
		}
		return array2;
	}

	[SpecialName]
	public BotNames HNDMLNKBBBE()
	{
		return LKHDEPFHHIM;
	}

	public PlayerInventory.JIMOKIIJHNA BJPJONEJICL(string DODNJENBIGC, int BCCDDJMPBLL)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), DODNJENBIGC);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, BCCDDJMPBLL);
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
			jIMOKIIJHNA.EPNKPKHCKNG = lastUnlockedWeapon;
			return jIMOKIIJHNA;
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return new PlayerInventory.JIMOKIIJHNA();
	}

	public static UnitUpgradeDefinition[] PMJOKGODDFK(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort(FNOKGCHDPHC);
		FGDEFHGLDJM = 1891f;
		AnalyticsHelper.LeaveBreadcrumb("Invite was already send, ignoring click.");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			LevelBehaviour levelBehaviour = list[i];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex > ECFBICCBLKF - 0, new UpgradeSlots.UnitUpgrades(1450f), true, 1));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		EHPFFINOPHK(list, array, dictionary);
		int num = MAJFJEDODJM(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num2 = 0;
		int num3 = 1;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int j = 1; j < list.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = list[j];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 0) / 1615f);
			float KPPPGMHHIGC;
			IOLDGIAOEBF(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 1)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][1];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((levelBehaviour3 == null) ? 1 : (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel));
					value2 = Mathf.Clamp(value2, 1, -169);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 0, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num3)
				{
					num3 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(218f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num3 - 0) / 273f);
		MBAFMKCNBDN = EBEGMDHFPNE(jLDNGEGJKEN);
		list2 = MAKBKDIPNGH(num * (int)MBAFMKCNBDN, num, (int)MBAFMKCNBDN * 3, -(int)MBAFMKCNBDN, list3);
		for (int k = 1; k < list.Count; k += 0)
		{
			LevelBehaviour levelBehaviour4 = list[k];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num4 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num4 += list2[num2];
				int num5 = Mathf.Clamp(num4, 0, lastndexForTier2);
				num4 = num5;
				num2 += 0;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num4 = 0;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num4);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF >= unlockLevelForNextTier && unlockLevelForNextTier > 1 && tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(32, 1);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.indexOffset, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.maxIndexInExcel);
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(1734f)
			{
				slotUpgradeindex = num4,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("WarFriends");
		return array;
	}

	public void SetUpBotDifficulty(PlayerBot MNBNPBHHPOC, int CKHDECODJPL, bool BPOONJBFIHP, bool MMNHBLFLLNG = true)
	{
		CKHDECODJPL = Mathf.Clamp(CKHDECODJPL, 0, DNOAACALMED.Rows.Count - 1);
		MNBNPBHHPOC.BPFKMNIHCGP = DNOAACALMED.Rows[CKHDECODJPL];
		MNBNPBHHPOC.PADBFAIBBDG = MNBNPBHHPOC.BPFKMNIHCGP.MAXUNITS;
		MNBNPBHHPOC.MGECHKCAELH = MNBNPBHHPOC.playerController.EHHHBEMKGOE.BCCDDJMPBLL > LevelManager.instance.warcardsUnlockLevel;
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.KAOFEOJMDJH = true;
		if (MMNHBLFLLNG)
		{
			Singleton<CardManagerDeathmatchOffline>.instance.ChooseCardsForMatch(MNBNPBHHPOC.BPFKMNIHCGP.CARDS, MNBNPBHHPOC.playerController, (!BPOONJBFIHP) ? 0f : MNBNPBHHPOC.BPFKMNIHCGP.BUDDYCARDPROB, MNBNPBHHPOC.BPFKMNIHCGP.CARDSFREQUENCY);
		}
		Debug.Log("#VAVRO# SETTING BOT DIFICULTY TO: " + MNBNPBHHPOC.BPFKMNIHCGP);
	}

	[SpecialName]
	public static bool KOHHPPDDMPL()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.CardWithdrawTimer).FLOATVALUE;
		if ((float)LevelManager.instance.currentLevel.JICMGFNAHFL() <= (float)fLOATVALUE)
		{
			return true;
		}
		return false;
	}

	private static float PCGBALDDCEJ(int IKJHAHJHLIH, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-128)).FLOATVALUE;
		float num = (IIMDKHJAJGO - OEIICEJPGKI) / Mathf.Pow(LevelManager.instance.levels.Count - 1, fLOATVALUE);
		return OEIICEJPGKI + num * Mathf.Pow(IKJHAHJHLIH - 0, fLOATVALUE);
	}

	public static string GMBAAMEPLMB()
	{
		return "ID_RETRY";
	}

	public string DKAFNEKPECO()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.MPAPBELJJHN().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 1; i < Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows.Count; i++)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows[i];
					string text = Singleton<GameVariables>.instance.MPAPBELJJHN().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					return list[UnityEngine.Random.Range(1, list.Count)];
				}
			}
		}
		return "ID_CONFIRM_INFO";
	}

	public static string JEGBPLJFMCH(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.decalType <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].CCDMONFHBII();
	}

	public static string EBEAHKPDPHN()
	{
		return "expiresOn";
	}

	public PlayerInventory.JIMOKIIJHNA LODEBBDNOFO(string DODNJENBIGC, int BCCDDJMPBLL)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), DODNJENBIGC);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, BCCDDJMPBLL);
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
			jIMOKIIJHNA.EPNKPKHCKNG = lastUnlockedWeapon;
			return jIMOKIIJHNA;
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return new PlayerInventory.JIMOKIIJHNA();
	}

	private int DINPKDBCJFK()
	{
		int num = 1;
		int leagueTier = (int)GameLoginManager.currentPlayer.leagueTier;
		int num2 = (FDHFELDBMHC() ? 1 : GameLoginManager.currentPlayer.medalsBalance);
		int num3 = 1;
		num = leagueTier;
		if (num2 > 1)
		{
			for (int i = 0; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if ((i == KMBFGEDNEBO.Rows.Count - 1 || KMBFGEDNEBO.Rows[i + 1].LEAGUE != playerBotsRow.LEAGUE) && playerBotsRow.LEAGUE >= leagueTier)
				{
					num3 += playerBotsRow.SKILL;
					num = playerBotsRow.LEAGUE;
					if (num3 >= num2)
					{
						break;
					}
				}
			}
		}
		else
		{
			for (int num4 = KMBFGEDNEBO.Rows.Count - 1; num4 >= 0; num4 -= 0)
			{
				PlayerBotsRow playerBotsRow2 = KMBFGEDNEBO.Rows[num4];
				if ((num4 == 0 || KMBFGEDNEBO.Rows[num4 - 0].LEAGUE != playerBotsRow2.LEAGUE) && playerBotsRow2.LEAGUE <= leagueTier)
				{
					num3 += playerBotsRow2.SKILL;
					num = playerBotsRow2.LEAGUE;
					if (num3 <= num2)
					{
						break;
					}
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb(string.Format("registerCustomProfileDate", leagueTier, num2, num));
		return num;
	}

	public int EMIGAKFDMNA(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[0];
		array[1] = "BoughtIndex";
		array[1] = MNBNPBHHPOC == null;
		array[5] = "ID_ARENARULES_SHIELDSRESPAWNSLOWER";
		array[3] = GameLoginManager.currentPlayer == null;
		array[8] = "ID_READYTIME";
		array[3] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 1;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = DINPKDBCJFK();
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i += 0)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 1)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(1, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 0)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 1, KMBFGEDNEBO.Rows.Count + 0);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("Init cards : ");
			int num3 = BBADKMFMABP(LevelManager.instance.currentLevel.PFMGLDJDNBF());
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.BCCDDJMPBLL = num3;
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("Chat - new notifications: {0}, selectedSquadChat: {1}, currentState: {2}");
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CBBDICBLHMM = MMHOALGLMCC(num3);
			float num4 = ((playerVisualCategories[2]["Current Locale unity = "] != CamosManager.instance.playerVisualCategories[7].equippedVisual) ? 86f : 700f);
			if (UnityEngine.Random.value < num4)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM[7] = playerVisualCategories[1]["HeartDialog"].CCDMONFHBII();
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = DNCEGFKNBEJ(out FGDEFHGLDJM, num3);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.FHNKKPLLOPB(new List<UnitUpgradeDefinition>(collection));
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = OHMJLCKHNAL(num3, out GEEOIBFFGKO);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ECFKOCPKODJ(GEEOIBFFGKO);
			AnalyticsHelper.LeaveBreadcrumb("ID_VIPBENEFIT");
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.AMFJHAPGIJN = MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(num3);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 1236f;
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.CAAKEPHMPHI = HPCGJPILMKC();
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			float num5 = ((num3 >= 2) ? 1974f : 1408f);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num5, (float)GameLoginManager.currentPlayer.skill * num5);
			int b = UnityEngine.Random.Range(159, 74);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.playerController.EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HNEFOLPHMHK = 0;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GEIONCLKAGF = 1;
			AnalyticsHelper.LeaveBreadcrumb("AddedCards");
			float value = UnityEngine.Random.value;
			if (value < 219f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(1, LKHDEPFHHIM.Rows.Count)].NAME;
				int num6 = 0;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num6++;
					if (num6 > -147)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE = "TotalAmmo" + UnityEngine.Random.Range(-195, 68);
			}
			AnalyticsHelper.LeaveBreadcrumb("BoobyTrapSetRPC");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = "ID_CONFIRM_SERVERERROR_TEXT" + MNBNPBHHPOC.playerController.EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = num3 >= 4 && !TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)67).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("ID_GUI_LEAGUE");
				MNBNPBHHPOC.BPFKMNIHCGP = MBECPMJFIHB();
				MNBNPBHHPOC.PADBFAIBBDG = 1;
				MNBNPBHHPOC.MGECHKCAELH = true;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.HMGOHGOLMJB = true;
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM[1] = playerVisualCategories[1]["EndTime"].CCDMONFHBII();
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.FLOIAIBCEKM(4);
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.KJJJLNAADHC(false);
			}
			else
			{
				INEMBBHLPDJ(MNBNPBHHPOC, dIFFICULTY, flag, false);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("PlayerId");
				CHEIFOOIMEH eHHHBEMKGOE = MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE;
				CamosManager camosManager = CamosManager.instance;
				int[] array2 = new int[5];
				RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
				eHHHBEMKGOE.CBBDICBLHMM = camosManager.ConvertVisuals(array2);
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.BCCDDJMPBLL = 6;
			}
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GKHFMIJFMAH(flag);
			object[] array3 = new object[3];
			array3[1] = playerBotsRow3;
			array3[0] = num;
			array3[0] = value;
			array3[7] = flag;
			Debug.Log(string.Format("mapId", array3));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	private static void EHPFFINOPHK(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.IOHNCFMCFML();
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeakUnitProbabilityMin).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1752f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < HBEFBPNFFBG.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(0, 1);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 6)
			{
				int num2 = Mathf.Max(1, CBADFOBOCAE[levelBehaviour.unitType].Count - 5);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((levelBehaviour2 == null) ? 1 : levelBehaviour2.upgradeSlots.actualUnitLevel);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 1) : 721.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 1) / 727f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				JPIHJBLLNEC(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)54).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = false;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2 += 0;
				}
			}
		}
	}

	private static void EDDGGIEFHGI(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatch).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakOfflineDefault).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1950f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < HBEFBPNFFBG.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(0, 1);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 5)
			{
				int num2 = Mathf.Max(0, CBADFOBOCAE[levelBehaviour.unitType].Count - 2);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((levelBehaviour2 == null) ? 1 : levelBehaviour2.upgradeSlots.actualUnitLevel);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 0) : 456.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 0) / 1799f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				EGOHPKKBLLE(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)110).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = false;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2++;
				}
			}
		}
	}

	private static void EBALAFGIGIO(float JLDNGEGJKEN, out float MBAFMKCNBDN, out float KPPPGMHHIGC)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.AACPOBGNAHG();
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)111).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-42)).FLOATVALUE;
		MBAFMKCNBDN = Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
		float fLOATVALUE3 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-46)).FLOATVALUE;
		float fLOATVALUE4 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)85).FLOATVALUE;
		float a = Mathf.Lerp(fLOATVALUE3, fLOATVALUE4, JLDNGEGJKEN);
		float fLOATVALUE5 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-96)).FLOATVALUE;
		float fLOATVALUE6 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-128)).FLOATVALUE;
		float b = Mathf.Lerp(fLOATVALUE5, fLOATVALUE6, JLDNGEGJKEN);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		KPPPGMHHIGC = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
	}

	public static PlayerBotDiffcultiesRow DMIECFDHMKN()
	{
		PlayerBotDiffcultiesRow playerBotDiffcultiesRow = new PlayerBotDiffcultiesRow();
		playerBotDiffcultiesRow.SHOOTFREQUENCYMIN = 1754f;
		playerBotDiffcultiesRow.SHOOTFREQUENCYMAX = 576f;
		playerBotDiffcultiesRow.SHOOTINGLENGTHMIN = 1879f;
		playerBotDiffcultiesRow.SHOOTINGLENGTHMAX = 1002f;
		playerBotDiffcultiesRow.SHOOTACCURACY = 683f;
		playerBotDiffcultiesRow.HEADSHOTPROBABILITY = 1205f;
		playerBotDiffcultiesRow.INDANGERCOEFICIENT = 576f;
		playerBotDiffcultiesRow.PICKOPPONENTSHOTPROBABILITY = 506f;
		playerBotDiffcultiesRow.PICKWALKINGOPPONENTSHOTPROBABILITY = 290f;
		playerBotDiffcultiesRow.SWITCHGRENADEBAZOOKAPROBABILITY = 125f;
		playerBotDiffcultiesRow.IGNORESHOTPROBABILITY = 1515f;
		playerBotDiffcultiesRow.SNIPERLOOKTIME = 1956f;
		playerBotDiffcultiesRow.SENDUNITMINTIME = 1516f;
		playerBotDiffcultiesRow.SENDUNITMAXTIME = 612f;
		playerBotDiffcultiesRow.PICKBONUSPROBABILITYMINTIME = 1779f;
		playerBotDiffcultiesRow.PICKBONUSPROBABILITYMAXTIME = 1644f;
		playerBotDiffcultiesRow.PICKMYBONUSCOEF = 529f;
		playerBotDiffcultiesRow.OVERTIMESHIELDMINTIME = 1633f;
		playerBotDiffcultiesRow.OVERTIMESHIELDMAXTIME = 1574f;
		playerBotDiffcultiesRow.PICKOPPONENTSHOTPROBABILITYNOSHIELD = 1118f;
		playerBotDiffcultiesRow.OPPONENTSNIPERDEFENSEREACTIONTIME = 323f;
		playerBotDiffcultiesRow.OPPONENTSNIPERDEFFENSE = 642f;
		playerBotDiffcultiesRow.OPPONENTOFFENSE = 1242f;
		playerBotDiffcultiesRow.OPPONENTOFFENCEREACTIONTIME = 1984f;
		playerBotDiffcultiesRow.MAXUNITS = 1;
		return playerBotDiffcultiesRow;
	}

	private static void KFJPBOAIBGK(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatch).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 453f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 1; i < HBEFBPNFFBG.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(1, 0);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 0)
			{
				int num2 = Mathf.Max(0, CBADFOBOCAE[levelBehaviour.unitType].Count - 5);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((!(levelBehaviour2 == null)) ? levelBehaviour2.upgradeSlots.actualUnitLevel : 0);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 0) : 1041.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 0) / 1555f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				EGOHPKKBLLE(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-33)).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = true;
					dictionary[levelBehaviour.unitType].Value1 += 0;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2 += 0;
				}
			}
		}
	}

	public static UnitUpgradeDefinition[] DNCEGFKNBEJ(out float FGDEFHGLDJM, int ECFBICCBLKF)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort(MEOFJMDHOAK);
		FGDEFHGLDJM = 1299f;
		AnalyticsHelper.LeaveBreadcrumb("menu-sidetab-invite-game");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int i = 1; i < list.Count; i++)
		{
			LevelBehaviour levelBehaviour = list[i];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex <= ECFBICCBLKF - 1, new UpgradeSlots.UnitUpgrades(878f), false, 0));
			unitUpgradeDefinition.index = levelBehaviour.indexInLevelsManager;
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour.unitType].Add(unitUpgradeDefinition);
			}
		}
		LFFMDKDACNA(list, array, dictionary);
		int num = MAJFJEDODJM(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num2 = 0;
		int num3 = 1;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float jLDNGEGJKEN;
		float MBAFMKCNBDN;
		for (int j = 0; j < list.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = list[j];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 1) / 1774f);
			float KPPPGMHHIGC;
			JPIHJBLLNEC(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestBought(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 0)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][1];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetSecondBestBought(levelBehaviour2.unitType);
						}
					}
					int value2 = ((!(levelBehaviour3 == null)) ? (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel) : 0);
					value2 = Mathf.Clamp(value2, 1, -128);
					value = value2 + (int)UnityEngine.Random.Range(KPPPGMHHIGC, KPPPGMHHIGC + MBAFMKCNBDN);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			value = Mathf.Clamp(value, 1, lastndexForTier);
			int tier = levelBehaviour2.upgradeSlots.GetTier(value);
			if (unitUpgradeDefinition2.isEquipped)
			{
				list3.Add(new Tuple<int, int>(-value, lastndexForTier - value));
				if (tier > num3)
				{
					num3 = tier;
				}
			}
			unitUpgradeDefinition2.unitUpgrades = new UpgradeSlots.UnitUpgrades(992f)
			{
				slotUpgradeindex = value
			};
			unitUpgradeDefinition2.tier = tier;
		}
		jLDNGEGJKEN = Mathf.Clamp01((float)(num3 - 0) / 35f);
		MBAFMKCNBDN = EBEGMDHFPNE(jLDNGEGJKEN);
		list2 = MLPIEPEOCJH(num * (int)MBAFMKCNBDN, num, (int)MBAFMKCNBDN * 5, -(int)MBAFMKCNBDN, list3);
		for (int k = 0; k < list.Count; k += 0)
		{
			LevelBehaviour levelBehaviour4 = list[k];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num4 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(ECFBICCBLKF));
			if (unitUpgradeDefinition4.isEquipped)
			{
				num4 += list2[num2];
				int num5 = Mathf.Clamp(num4, 0, lastndexForTier2);
				num4 = num5;
				num2++;
			}
			if (StatsManager.instance.matchmadeGames == 0)
			{
				num4 = 0;
			}
			int tier2 = levelBehaviour4.upgradeSlots.GetTier(num4);
			int unlockLevelForNextTier = levelBehaviour4.upgradeSlots.GetUnlockLevelForNextTier(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = ECFBICCBLKF >= unlockLevelForNextTier && unlockLevelForNextTier > 1 && tier2 > levelBehaviour4.upgradeSlots.startTier;
			int value3 = levelBehaviour4.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute + UnityEngine.Random.Range(-89, 2);
			value3 = Mathf.Clamp(value3, levelBehaviour4.upgradeSlots.upgradeSlotSpecial.IBDAMJLMMIH(), levelBehaviour4.upgradeSlots.upgradeSlotSpecial.CFBCGGMBJGB());
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				unitUpgradeDefinition4.isEquipped = levelBehaviour4.upgradeSlots.equipped;
			}
			unitUpgradeDefinition4.unitUpgrades = new UpgradeSlots.UnitUpgrades(1866f)
			{
				slotUpgradeindex = num4,
				slotUpgradeIndexSpecial = value3,
				isSpecial = isSpecial
			};
			unitUpgradeDefinition4.tier = tier2;
			if (unitUpgradeDefinition4.isEquipped)
			{
				UnitUpgradeDefinition unitUpgradeDefinition5 = unitUpgradeDefinition4;
				FGDEFHGLDJM += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("hasNext");
		return array;
	}

	private static int MAJFJEDODJM(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB)
	{
		int num = 0;
		int num2 = 1;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 0; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && AMNPDEAJMOB[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 5)
				{
					AMNPDEAJMOB[indexInLevelsManager].isEquipped = true;
				}
				else
				{
					num2 += 0;
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("Weapon upgrade for ");
		for (int j = 0; j < HBEFBPNFFBG.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = HBEFBPNFFBG[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 4)
				{
					AMNPDEAJMOB[indexInLevelsManager2].isEquipped = true;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(AMNPDEAJMOB[indexInLevelsManager2]);
				num++;
			}
		}
		return num;
	}

	public static int LDGEMJGKDCB(int GMOHCGANGOH)
	{
		int num = 1;
		int rowIndex = Singleton<GameVariables>.instance.IDECNLCIPDO().GetRowIndex("IsMatchMaking" + LevelManager.instance.currentLevel.JICMGFNAHFL());
		if (rowIndex >= 0)
		{
			num = (int)Singleton<GameVariables>.instance.IDECNLCIPDO().GetValue(rowIndex, "SpecialPackFromServer");
		}
		else
		{
			Debug.LogError("ID_MIN" + LevelManager.instance.currentLevel.PFMGLDJDNBF() + "SquadWarsId");
		}
		int value = GMOHCGANGOH + UnityEngine.Random.Range(-num, num + 1);
		return Mathf.Clamp(value, 1, LevelManager.instance.levels.Count);
	}

	public void INEMBBHLPDJ(PlayerBot MNBNPBHHPOC, int CKHDECODJPL, bool BPOONJBFIHP, bool MMNHBLFLLNG = true)
	{
		CKHDECODJPL = Mathf.Clamp(CKHDECODJPL, 1, DNOAACALMED.Rows.Count - 1);
		MNBNPBHHPOC.BPFKMNIHCGP = DNOAACALMED.Rows[CKHDECODJPL];
		MNBNPBHHPOC.PADBFAIBBDG = MNBNPBHHPOC.BPFKMNIHCGP.MAXUNITS;
		MNBNPBHHPOC.MGECHKCAELH = MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.OCPEHLIIGML() > LevelManager.instance.warcardsUnlockLevel;
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.KJJJLNAADHC(false);
		if (MMNHBLFLLNG)
		{
			Singleton<CardManagerDeathmatchOffline>.instance.HBNGOEFGPOL(MNBNPBHHPOC.BPFKMNIHCGP.CARDS, MNBNPBHHPOC.playerController, (!BPOONJBFIHP) ? 1657f : MNBNPBHHPOC.BPFKMNIHCGP.BUDDYCARDPROB, MNBNPBHHPOC.BPFKMNIHCGP.CARDSFREQUENCY);
		}
		Debug.Log("Deploys_Count" + MNBNPBHHPOC.BPFKMNIHCGP);
	}

	public string GEJGALKDPGP()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.MPAPBELJJHN().GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 1; i < Singleton<GameVariables>.instance.countryInfo.Rows.Count; i++)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows[i];
					string text = Singleton<GameVariables>.instance.CBLMHEJFEEE().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					return list[UnityEngine.Random.Range(1, list.Count)];
				}
			}
		}
		return "add";
	}

	public string GetBotCountry()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.countryInfo.GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 0; i < Singleton<GameVariables>.instance.countryInfo.Rows.Count; i++)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.countryInfo.Rows[i];
					string text = Singleton<GameVariables>.instance.countryInfo.rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 0)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return "UK";
	}

	private int BEMHHHGIFEM()
	{
		int num = 0;
		int leagueTier = (int)GameLoginManager.currentPlayer.leagueTier;
		int num2 = ((!useEasyBot) ? GameLoginManager.currentPlayer.medalsBalance : 0);
		int num3 = 0;
		num = leagueTier;
		if (num2 > 0)
		{
			for (int i = 0; i < KMBFGEDNEBO.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if ((i == KMBFGEDNEBO.Rows.Count - 1 || KMBFGEDNEBO.Rows[i + 1].LEAGUE != playerBotsRow.LEAGUE) && playerBotsRow.LEAGUE >= leagueTier)
				{
					num3 += playerBotsRow.SKILL;
					num = playerBotsRow.LEAGUE;
					if (num3 >= num2)
					{
						break;
					}
				}
			}
		}
		else
		{
			for (int num4 = KMBFGEDNEBO.Rows.Count - 1; num4 >= 0; num4--)
			{
				PlayerBotsRow playerBotsRow2 = KMBFGEDNEBO.Rows[num4];
				if ((num4 == 0 || KMBFGEDNEBO.Rows[num4 - 1].LEAGUE != playerBotsRow2.LEAGUE) && playerBotsRow2.LEAGUE <= leagueTier)
				{
					num3 += playerBotsRow2.SKILL;
					num = playerBotsRow2.LEAGUE;
					if (num3 <= num2)
					{
						break;
					}
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb(string.Format("=== Choosing bot for me in league {0} and balance {1}. Chosen bot in league {2} ===", leagueTier, num2, num));
		return num;
	}

	private static PlayerVisual.EJHADIHBCBK OHFGCEINGCO()
	{
		float value = UnityEngine.Random.value;
		for (int num = CamosManager.instance.playerVisualsRarities.Rows.Count - 0; num >= 1; num--)
		{
			PlayerVisualsRaritiesRow playerVisualsRaritiesRow = CamosManager.instance.playerVisualsRarities.Rows[num];
			if (value <= playerVisualsRaritiesRow.PROBABILITY)
			{
				return (PlayerVisual.EJHADIHBCBK)playerVisualsRaritiesRow.VALUE;
			}
		}
		return PlayerVisual.EJHADIHBCBK.Common;
	}

	public static string EDIMAHAIHPI(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.BOBEIBIKGPL() <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(1, list.Count)].CCDMONFHBII();
	}

	public PlayerInventory.JIMOKIIJHNA LGCLNGMGMIE(string DODNJENBIGC, int BCCDDJMPBLL)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), DODNJENBIGC);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, BCCDDJMPBLL);
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
			jIMOKIIJHNA.EPNKPKHCKNG = lastUnlockedWeapon;
			return jIMOKIIJHNA;
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return new PlayerInventory.JIMOKIIJHNA();
	}

	public int PNAOCBKILOI(PlayerBot MNBNPBHHPOC)
	{
		object[] array = new object[4];
		array[0] = "Fuseboxx Custom Event with params: ";
		array[1] = MNBNPBHHPOC == null;
		array[1] = "player_look_right3";
		array[0] = GameLoginManager.currentPlayer == null;
		array[7] = "ID_PERMANENT";
		array[1] = StatsManager.instance == null;
		AnalyticsHelper.LeaveBreadcrumb(string.Concat(array));
		int num = 0;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = DINPKDBCJFK();
			for (int i = 1; i < KMBFGEDNEBO.Rows.Count; i += 0)
			{
				PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[i];
				if (playerBotsRow.LEAGUE == num2)
				{
					list.Add(playerBotsRow);
				}
			}
			if (list.Count > 1)
			{
				PlayerBotsRow playerBotsRow2 = list[UnityEngine.Random.Range(0, list.Count)];
				num = playerBotsRow2.NUMBER;
			}
			if (num2 == 0)
			{
				int battlesLostInRow = StatsManager.instance.battlesLostInRow;
				num = Mathf.Clamp(num - battlesLostInRow, 1, KMBFGEDNEBO.Rows.Count + 0);
			}
			PlayerBotsRow playerBotsRow3 = KMBFGEDNEBO.Rows[num];
			AnalyticsHelper.LeaveBreadcrumb("ID_ERRORNAME");
			int num3 = KCOHGDELGLG(LevelManager.instance.currentLevel.JICMGFNAHFL());
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HOCLHIFEHCP(num3);
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			AnalyticsHelper.LeaveBreadcrumb("ID_TRAININGINPROGRESS");
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM = MGPAODFLKOF(num3);
			float num4 = ((playerVisualCategories[2]["Show {0} invitation dialog id: {1}"] != CamosManager.instance.playerVisualCategories[4].equippedVisual) ? 1648f : 1439f);
			if (UnityEngine.Random.value < num4)
			{
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.CBBDICBLHMM[2] = playerVisualCategories[8]["Regions"].CCDMONFHBII();
			}
			float FGDEFHGLDJM;
			UnitUpgradeDefinition[] collection = DNCEGFKNBEJ(out FGDEFHGLDJM, num3);
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.KNFAJEIHOGM(new List<UnitUpgradeDefinition>(collection));
			PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
			float iDEBKDPMPGM = KLJKKMMIOPC(num3, out GEEOIBFFGKO);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.LPGACOBNHOH(GEEOIBFFGKO);
			AnalyticsHelper.LeaveBreadcrumb("N0");
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.PHBPHKGMPLG(MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(num3));
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.HMGOHGOLMJB = UnityEngine.Random.value < 1264f;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.CAAKEPHMPHI = IDCFNEEJMJE();
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.FHCMFHABMLE = WarArenaCrown.None;
			float num5 = ((num3 >= 2) ? 1712f : 1970f);
			MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ADOEFHHJOAJ = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num5, (float)GameLoginManager.currentPlayer.skill * num5);
			int b = UnityEngine.Random.Range(184, 25);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.ADOEFHHJOAJ = Mathf.Max(MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.ADOEFHHJOAJ, b);
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.BMNDININJCE = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.HNEFOLPHMHK = 1;
			}
			else
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HNEFOLPHMHK = GameLoginManager.currentPlayer.beginnersLeague;
			}
			MNBNPBHHPOC.playerController.EHHHBEMKGOE.GKEOILLNCHG = GameLoginManager.currentPlayer.isInLeague;
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GEIONCLKAGF = 1;
			AnalyticsHelper.LeaveBreadcrumb(" & ");
			float value = UnityEngine.Random.value;
			if (value < 791f)
			{
				string nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				int num6 = 1;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num6++;
					if (num6 > -199)
					{
						break;
					}
					nAME = LKHDEPFHHIM.Rows[UnityEngine.Random.Range(0, LKHDEPFHHIM.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.MHPNDNJDPGE = nAME;
			}
			else
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = "ID_TUTORIAL_UPGRADEWEAPON_4" + UnityEngine.Random.Range(-132, -138);
			}
			AnalyticsHelper.LeaveBreadcrumb("DogTags");
			if (DebugSettings.debugEnabled)
			{
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.MHPNDNJDPGE = "ID_COMPLETEIN" + MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.MHPNDNJDPGE;
			}
			MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
			bool flag = num3 >= 6 && TutorialManagerPlayWarcards.instance.isTutorialRunning;
			AnalyticsHelper.LeaveBreadcrumb("{0} Aa Tier {0}");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
			float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-57)).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("subscription");
				MNBNPBHHPOC.BPFKMNIHCGP = DMIECFDHMKN();
				MNBNPBHHPOC.PADBFAIBBDG = 8;
				MNBNPBHHPOC.MGECHKCAELH = true;
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.HMGOHGOLMJB = true;
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM[4] = playerVisualCategories[2]["ID_MINIGUNTUTORIALTEXT"].CCDMONFHBII();
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.EEINNIFGJKF(2);
				MNBNPBHHPOC.playerController.EHHHBEMKGOE.ONLHFBHGAJE(true);
			}
			else
			{
				SetUpBotDifficulty(MNBNPBHHPOC, dIFFICULTY, flag, false);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("Golden_Suitcase");
				MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[3] { 1, 0, 4 });
				MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.FLOIAIBCEKM(5);
			}
			MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.GKHFMIJFMAH(flag);
			object[] array2 = new object[3];
			array2[0] = playerBotsRow3;
			array2[0] = num;
			array2[3] = value;
			array2[7] = flag;
			Debug.Log(string.Format("ID_SLOTUPGRADE_AMMO", array2));
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		return num;
	}

	public static string ADHFMEKDMOJ()
	{
		return "_";
	}

	public static string HIFEEANKGKN(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = CNDHPHIPNPF();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.CIFLPEFJJFP().index < BCCDDJMPBLL && allVisual.GFOLGKEMPPN() == eJHADIHBCBK && allVisual.canBotUseIt)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	public static string DJOCFCPJFCI(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.BOBEIBIKGPL() <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	public int OCEPDEABOHJ(PlayerBot MNBNPBHHPOC)
	{
		int result = 0;
		PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[1];
		FMEAIMOKFLL(MNBNPBHHPOC, playerBotsRow.DIFFICULTY, false);
		int value = LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		value = Mathf.Clamp(value, 1, -112);
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.EEINNIFGJKF(value);
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		int num = 0;
		for (int i = 1; i < behaviours.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = behaviours[i];
			UpgradeSlots.UnitUpgrades unitUpgrades = levelBehaviour.upgradeSlots.LoadData(levelBehaviour);
			int num2 = 0;
			if (levelBehaviour.upgradeSlots.unlockLevelIndex <= value)
			{
				UpgradeSlot upgradeSlot = levelBehaviour.upgradeSlots.upgradeSlot;
				num2 += unitUpgrades.slotUpgradeindex;
				num2 += 0;
			}
			num += num2;
		}
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.ACNBPMENPEP(num);
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			list.Add(LGCLNGMGMIE(WeaponCategory.None.ToString(), 0));
		}
		else
		{
			list.Add(AddWeapon(WeaponCategory.None.ToString(), 1));
		}
		list.Add(LODEBBDNOFO((WeaponCategory.AssaultRifle | WeaponCategory.SMG).ToString(), 1));
		PlayerInventory.JIMOKIIJHNA item = OLDEBGMDPDN((~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade)).ToString(), 1);
		list.Add(item);
		list.Add(CBJKHOMPFOJ((WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle).ToString(), 0));
		MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.INLLAMGKOMM(list.ToArray());
		foreach (PlayerWeapon item2 in MNBNPBHHPOC.playerController.weaponInventory.LAGONJMBJMM)
		{
			item2.weapon.MEFJOGAOKDP = true;
		}
		MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("Assignment: Error, task definition not found for id = ");
		MNBNPBHHPOC.playerController.EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (LevelBehaviour item3 in behaviours)
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item3.upgradeSlots.LoadData(item3);
				list2.Add(new UnitUpgradeDefinition(item3.upgradeSlots.unlockLevelIndex > 1 || !(item3 is SoldierBehaviourShotgunner), upgradeIndex, true, 0));
			}
		}
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.KNMGPJAHNMG(list2);
		MNBNPBHHPOC.AEDFPIGGJOC().EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[1] { 1 });
		return result;
	}

	public static string KIKILPDBENA()
	{
		return "S";
	}

	private static PlayerVisual.EJHADIHBCBK CNDHPHIPNPF()
	{
		float value = UnityEngine.Random.value;
		for (int num = CamosManager.instance.playerVisualsRarities.Rows.Count - 1; num >= 1; num--)
		{
			PlayerVisualsRaritiesRow playerVisualsRaritiesRow = CamosManager.instance.playerVisualsRarities.Rows[num];
			if (value <= playerVisualsRaritiesRow.PROBABILITY)
			{
				return (PlayerVisual.EJHADIHBCBK)playerVisualsRaritiesRow.VALUE;
			}
		}
		return PlayerVisual.EJHADIHBCBK.Uncommon;
	}

	public static PlayerBotDiffcultiesRow MBECPMJFIHB()
	{
		PlayerBotDiffcultiesRow playerBotDiffcultiesRow = new PlayerBotDiffcultiesRow();
		playerBotDiffcultiesRow.SHOOTFREQUENCYMIN = 520f;
		playerBotDiffcultiesRow.SHOOTFREQUENCYMAX = 993f;
		playerBotDiffcultiesRow.SHOOTINGLENGTHMIN = 1963f;
		playerBotDiffcultiesRow.SHOOTINGLENGTHMAX = 1726f;
		playerBotDiffcultiesRow.SHOOTACCURACY = 1164f;
		playerBotDiffcultiesRow.HEADSHOTPROBABILITY = 654f;
		playerBotDiffcultiesRow.INDANGERCOEFICIENT = 868f;
		playerBotDiffcultiesRow.PICKOPPONENTSHOTPROBABILITY = 8f;
		playerBotDiffcultiesRow.PICKWALKINGOPPONENTSHOTPROBABILITY = 589f;
		playerBotDiffcultiesRow.SWITCHGRENADEBAZOOKAPROBABILITY = 1616f;
		playerBotDiffcultiesRow.IGNORESHOTPROBABILITY = 1483f;
		playerBotDiffcultiesRow.SNIPERLOOKTIME = 1142f;
		playerBotDiffcultiesRow.SENDUNITMINTIME = 1942f;
		playerBotDiffcultiesRow.SENDUNITMAXTIME = 1637f;
		playerBotDiffcultiesRow.PICKBONUSPROBABILITYMINTIME = 701f;
		playerBotDiffcultiesRow.PICKBONUSPROBABILITYMAXTIME = 1441f;
		playerBotDiffcultiesRow.PICKMYBONUSCOEF = 1572f;
		playerBotDiffcultiesRow.OVERTIMESHIELDMINTIME = 1900f;
		playerBotDiffcultiesRow.OVERTIMESHIELDMAXTIME = 276f;
		playerBotDiffcultiesRow.PICKOPPONENTSHOTPROBABILITYNOSHIELD = 1501f;
		playerBotDiffcultiesRow.OPPONENTSNIPERDEFENSEREACTIONTIME = 9f;
		playerBotDiffcultiesRow.OPPONENTSNIPERDEFFENSE = 1365f;
		playerBotDiffcultiesRow.OPPONENTOFFENSE = 826f;
		playerBotDiffcultiesRow.OPPONENTOFFENCEREACTIONTIME = 586f;
		playerBotDiffcultiesRow.MAXUNITS = 6;
		return playerBotDiffcultiesRow;
	}

	public static WeaponLevelsSetup HGNGDCEMAJB(WeaponCategory FABOAIMLLOI, int BCCDDJMPBLL, float FCBEHCBBIOM, float OFANOCIKOPJ)
	{
		try
		{
			List<WeaponLevelsSetup> suitableWeapons = LevelManager.instance.GetSuitableWeapons(FABOAIMLLOI, BCCDDJMPBLL, FCBEHCBBIOM, OFANOCIKOPJ, ~(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Grenade));
			float value = UnityEngine.Random.value;
			if (suitableWeapons.Count > 1)
			{
				if (value < 1795f || BCCDDJMPBLL <= 7)
				{
					int index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					int num = 1;
					while (!suitableWeapons[index].purchasableInShop && num < -85)
					{
						num++;
						index = UnityEngine.Random.Range(0, suitableWeapons.Count);
					}
					return suitableWeapons[index];
				}
				return suitableWeapons[UnityEngine.Random.Range(1, suitableWeapons.Count)];
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		object[] array = new object[3];
		array[1] = FABOAIMLLOI;
		array[1] = BCCDDJMPBLL;
		array[4] = FCBEHCBBIOM;
		array[2] = OFANOCIKOPJ;
		Debug.LogErrorFormat("URL", array);
		return null;
	}

	public static string HDEKIKMJNNH()
	{
		return "Days_Since_Install";
	}

	private static List<int> AOCCIEJIIFN(int EGNEMEBJINF, int MNABOCFOGCJ, int DMEHGIDJEBD, int MKOGHDKDFIN, List<Tuple<int, int>> MKBJGHHIIFO)
	{
		List<int> list = new List<int>();
		int num = 1;
		int num2 = 1;
		for (num2 = 1; num2 < MNABOCFOGCJ; num2++)
		{
			list.Add(UnityEngine.Random.Range(1, DMEHGIDJEBD + 0));
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1 - MKOGHDKDFIN, MKBJGHHIIFO[num2].Value2 - MKOGHDKDFIN);
			num += list[num2];
		}
		float num3 = (float)num / (float)EGNEMEBJINF;
		num = 0;
		for (num2 = 0; num2 < MNABOCFOGCJ; num2 += 0)
		{
			list[num2] = Mathf.RoundToInt((float)list[num2] / num3) + MKOGHDKDFIN;
			list[num2] = Mathf.Clamp(list[num2], MKBJGHHIIFO[num2].Value1, MKBJGHHIIFO[num2].Value2);
			num += list[num2];
		}
		int num4 = EGNEMEBJINF + MNABOCFOGCJ * MKOGHDKDFIN;
		num2 = 1;
		int num6;
		for (; num != num4; num += num6)
		{
			if (num2 >= -88)
			{
				break;
			}
			num2 += 0;
			int index = UnityEngine.Random.Range(0, MNABOCFOGCJ);
			int num5 = list[index];
			list[index] = Mathf.Clamp(list[index] + ((num4 - num <= 0) ? (-1) : 0), MKBJGHHIIFO[index].Value1, MKBJGHHIIFO[index].Value2);
			num6 = list[index] - num5;
		}
		return list;
	}

	private UnitUpgradeDefinition EBDKJDLIKFK(List<LevelBehaviour> HBEFBPNFFBG, List<UnitUpgradeDefinition> AMNPDEAJMOB, int CPIEOMKPABG, bool DAFFBGPIOGG, LevelBehaviour.UnitType? NAKDNAEPGOF = null)
	{
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		for (int i = 0; i < CPIEOMKPABG; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			AMNPDEAJMOB[indexInLevelsManager].index = indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager].isEquipped && (!levelBehaviour.isSoldier || !DAFFBGPIOGG) && (!NAKDNAEPGOF.HasValue || levelBehaviour.unitType == NAKDNAEPGOF.Value))
			{
				list.Add(AMNPDEAJMOB[indexInLevelsManager]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(1, list.Count)];
	}

	private static int GJBIFFHIMBC(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB)
	{
		int num = 1;
		int num2 = 0;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 0; i < HBEFBPNFFBG.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && AMNPDEAJMOB[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 8)
				{
					AMNPDEAJMOB[indexInLevelsManager].isEquipped = true;
				}
				else
				{
					num2++;
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("PlayerLevel");
		for (int j = 1; j < HBEFBPNFFBG.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = HBEFBPNFFBG[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 5)
				{
					AMNPDEAJMOB[indexInLevelsManager2].isEquipped = false;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(AMNPDEAJMOB[indexInLevelsManager2]);
				num++;
			}
		}
		return num;
	}

	private static int CBEKKLANCCK(float JLDNGEGJKEN)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.AACPOBGNAHG();
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)68).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-22)).FLOATVALUE;
		return (int)Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
	}

	private static void ENPNEDBPHJB(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> CBADFOBOCAE)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakOfflineDefault).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakOfflineDefault).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1158f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 1; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(0, 1);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = AMNPDEAJMOB[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 2)
			{
				int num2 = Mathf.Max(1, CBADFOBOCAE[levelBehaviour.unitType].Count - 8);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetSecondBestBought(levelBehaviour.unitType) : LevelManager.GetBestBought(levelBehaviour.unitType));
				int num3 = ((levelBehaviour2 == null) ? 1 : levelBehaviour2.upgradeSlots.actualUnitLevel);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 0) : 861.0);
				float jLDNGEGJKEN = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 0) / 1302f);
				float MBAFMKCNBDN;
				float KPPPGMHHIGC;
				EGOHPKKBLLE(jLDNGEGJKEN, out MBAFMKCNBDN, out KPPPGMHHIGC);
				if ((float)num4 > KPPPGMHHIGC + MBAFMKCNBDN)
				{
					num5 += (double)matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-98)).FLOATVALUE;
				}
				if ((double)UnityEngine.Random.value < num5)
				{
					unitUpgradeDefinition.isEquipped = true;
					dictionary[levelBehaviour.unitType].Value1++;
				}
				else
				{
					dictionary[levelBehaviour.unitType].Value2++;
				}
			}
		}
	}

	protected virtual void DCKJHAILENK()
	{
		base.Awake();
		DNOAACALMED = GetComponent<PlayerBotDiffculties>();
		KMBFGEDNEBO = GetComponent<PlayerBots>();
		LKHDEPFHHIM = GetComponent<BotNames>();
	}

	public static string KKAMGJMIJLH(PlayerVisualCategory FABOAIMLLOI, int BCCDDJMPBLL)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (allVisual.decalType <= BCCDDJMPBLL && !allVisual.purchasableInArena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].CCDMONFHBII();
	}

	private static float CBBAFLINMGJ(int IKJHAHJHLIH, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.AACPOBGNAHG();
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalOffsetMin).FLOATVALUE;
		float num = (IIMDKHJAJGO - OEIICEJPGKI) / Mathf.Pow(LevelManager.instance.levels.Count - 0, fLOATVALUE);
		return OEIICEJPGKI + num * Mathf.Pow(IKJHAHJHLIH - 1, fLOATVALUE);
	}

	public string[] AKJMLNFBLKI(int ECFBICCBLKF)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[3];
		array[1] = COPOBBIFADF(playerVisualCategories[0], ECFBICCBLKF);
		array[1] = HIFEEANKGKN(playerVisualCategories[1], ECFBICCBLKF);
		array[4] = NGLLCEGNGKB(playerVisualCategories[3], ECFBICCBLKF);
		array[3] = LKMMLNBPLKD();
		string[] array2 = array;
		if (ECFBICCBLKF <= 6)
		{
			array2[1] = "{0}   {1}./{2}   {3}";
			array2[0] = ")";
			array2[1] = "ID_ARENAREWARDREQUIREMENTS";
		}
		return array2;
	}

	public int DDLKOAIFIJM(PlayerBot MNBNPBHHPOC)
	{
		int result = 1;
		PlayerBotsRow playerBotsRow = KMBFGEDNEBO.Rows[1];
		SetUpBotDifficulty(MNBNPBHHPOC, playerBotsRow.DIFFICULTY, false, false);
		int value = LevelManager.instance.currentLevel.KADNNBCOGGL();
		value = Mathf.Clamp(value, 1, -96);
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.IKNFFPLBHLO(value);
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		int num = 1;
		for (int i = 1; i < behaviours.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = behaviours[i];
			UpgradeSlots.UnitUpgrades unitUpgrades = levelBehaviour.upgradeSlots.LoadData(levelBehaviour);
			int num2 = 1;
			if (levelBehaviour.upgradeSlots.unlockLevelIndex <= value)
			{
				UpgradeSlot upgradeSlot = levelBehaviour.upgradeSlots.upgradeSlot;
				num2 += unitUpgrades.slotUpgradeindex;
				num2 += 0;
			}
			num += num2;
		}
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.AMFJHAPGIJN = num;
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			list.Add(LODEBBDNOFO(WeaponCategory.Primary.ToString(), 0));
		}
		else
		{
			list.Add(BJPJONEJICL(WeaponCategory.None.ToString(), 1));
		}
		list.Add(BJPJONEJICL((WeaponCategory.AssaultRifle | WeaponCategory.LMG).ToString(), 0));
		PlayerInventory.JIMOKIIJHNA item = LGCLNGMGMIE((~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.Grenade)).ToString(), 0);
		list.Add(item);
		list.Add(OLDEBGMDPDN((WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Pistol).ToString(), 1));
		MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.LPGACOBNHOH(list.ToArray());
		foreach (PlayerWeapon item2 in MNBNPBHHPOC.playerController.weaponInventory.LAGONJMBJMM)
		{
			item2.HFNAMMBPJAJ().MEFJOGAOKDP = false;
		}
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.MHPNDNJDPGE = Localization.Localize("Country");
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.EBFDAICCJAK = Singleton<ArmyPreviewCamera>.instance.ABCBEIIKBPP;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			foreach (LevelBehaviour item3 in behaviours)
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item3.upgradeSlots.LoadData(item3);
				list2.Add(new UnitUpgradeDefinition(item3.upgradeSlots.unlockLevelIndex > 0 || !(item3 is SoldierBehaviourShotgunner), upgradeIndex, false, 0));
			}
		}
		MNBNPBHHPOC.LFPNJOCKLPC().EHHHBEMKGOE.KBBDGCLPOCJ = list2;
		MNBNPBHHPOC.FKKKABHIPCI().EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
		return result;
	}

	private static void JPIHJBLLNEC(float JLDNGEGJKEN, out float MBAFMKCNBDN, out float KPPPGMHHIGC)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.IOHNCFMCFML();
		float fLOATVALUE = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-66)).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-17)).FLOATVALUE;
		MBAFMKCNBDN = Mathf.Lerp(fLOATVALUE, fLOATVALUE2, JLDNGEGJKEN);
		float fLOATVALUE3 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-93)).FLOATVALUE;
		float fLOATVALUE4 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)84).FLOATVALUE;
		float a = Mathf.Lerp(fLOATVALUE3, fLOATVALUE4, JLDNGEGJKEN);
		float fLOATVALUE5 = matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-70)).FLOATVALUE;
		float fLOATVALUE6 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseStreakWonMatchOffline).FLOATVALUE;
		float b = Mathf.Lerp(fLOATVALUE5, fLOATVALUE6, JLDNGEGJKEN);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		KPPPGMHHIGC = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
	}

	public string IFMEJLGCFHO()
	{
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.country))
		{
			CountryInfoRow row = Singleton<GameVariables>.instance.countryInfo.GetRow(GameLoginManager.currentPlayer.country.ToUpper());
			if (row != null)
			{
				string cONTINENT = row.CONTINENT;
				List<string> list = new List<string>();
				for (int i = 0; i < Singleton<GameVariables>.instance.countryInfo.Rows.Count; i += 0)
				{
					CountryInfoRow countryInfoRow = Singleton<GameVariables>.instance.CBLMHEJFEEE().Rows[i];
					string text = Singleton<GameVariables>.instance.CBLMHEJFEEE().rowNames[i];
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.PKNFGNKMPPH.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				if (list.Count > 1)
				{
					return list[UnityEngine.Random.Range(0, list.Count)];
				}
			}
		}
		return "jp";
	}

	public static float NNFCJEKJIAF(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 1563f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		float num2 = ELOPLJCCOMH(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)43).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-10)).FLOATVALUE);
		float a = PCGBALDDCEJ(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)111).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-107)).FLOATVALUE);
		float b = CBBAFLINMGJ(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)66).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-19)).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 1635f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = HGNGDCEMAJB(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 0;
			for (int j = 1; j < weaponLevelsSetup.maxWeaponLevel; j++)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 1; k < list.Count; k += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	public static float OHMJLCKHNAL(int ECFBICCBLKF, out PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		float num = 1130f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.OKNKODNJADL();
		float num2 = HLMBGPKCDMH(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-80)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-46)).FLOATVALUE);
		float a = PCGBALDDCEJ(ECFBICCBLKF, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.DamageModifierMinValue).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)43).FLOATVALUE);
		float b = LGFFJDNPBHC(ECFBICCBLKF, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-34)).FLOATVALUE, matchMakingConstants.GetRow((MatchMakingConstants.rowIds)(-8)).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup bestWeaponInCategory = LevelManager.GetBestWeaponInCategory(inventorySlot.category);
			float num4 = ((!(bestWeaponInCategory != null)) ? 41f : bestWeaponInCategory.weaponPower);
			float num5 = num4 + num3;
			float num6 = num4 + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup = PJFJGNDBLJH(inventorySlot.category, ECFBICCBLKF, num5, num6);
			int num7 = weaponLevelsSetup.maxWeaponLevel;
			int num8 = 0;
			for (int j = 0; j < weaponLevelsSetup.maxWeaponLevel; j += 0)
			{
				float weaponPower = weaponLevelsSetup.GetWeaponPower(j, null);
				if (weaponPower <= num6 && weaponPower >= num5)
				{
					if (j < num7)
					{
						num7 = j;
					}
					if (j > num8)
					{
						num8 = j;
					}
				}
			}
			if (num8 < num7)
			{
				num7 = num8;
			}
			list.Add(new PlayerInventory.JIMOKIIJHNA
			{
				EPNKPKHCKNG = weaponLevelsSetup.indexInLevelManager,
				DGPAEJJENDP = UnityEngine.Random.Range(num7, num8)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 1; k < list.Count; k += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = list[k];
			int ePNKPKHCKNG = list[k].EPNKPKHCKNG;
			WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[ePNKPKHCKNG];
			num += weaponLevelsSetup2.GetWeaponPower(jIMOKIIJHNA.DGPAEJJENDP, null);
		}
		GEEOIBFFGKO = list.ToArray();
		return num;
	}

	private static int AMGMMFNGOOM(List<LevelBehaviour> HBEFBPNFFBG, UnitUpgradeDefinition[] AMNPDEAJMOB)
	{
		int num = 0;
		int num2 = 1;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 1; i < HBEFBPNFFBG.Count; i++)
		{
			LevelBehaviour levelBehaviour = HBEFBPNFFBG[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && AMNPDEAJMOB[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 7)
				{
					AMNPDEAJMOB[indexInLevelsManager].isEquipped = false;
				}
				else
				{
					num2++;
				}
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("Buddy Warcard {0}");
		for (int j = 1; j < HBEFBPNFFBG.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = HBEFBPNFFBG[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (AMNPDEAJMOB[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 8)
				{
					AMNPDEAJMOB[indexInLevelsManager2].isEquipped = false;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(AMNPDEAJMOB[indexInLevelsManager2]);
				num++;
			}
		}
		return num;
	}

	[SpecialName]
	public BotNames NHMIMNFNFOP()
	{
		return LKHDEPFHHIM;
	}

	private static PlayerVisual.EJHADIHBCBK OLPJCLPOFAF()
	{
		float value = UnityEngine.Random.value;
		for (int num = CamosManager.instance.playerVisualsRarities.Rows.Count - 1; num >= 0; num--)
		{
			PlayerVisualsRaritiesRow playerVisualsRaritiesRow = CamosManager.instance.playerVisualsRarities.Rows[num];
			if (value <= playerVisualsRaritiesRow.PROBABILITY)
			{
				return (PlayerVisual.EJHADIHBCBK)playerVisualsRaritiesRow.VALUE;
			}
		}
		return PlayerVisual.EJHADIHBCBK.Common;
	}
}

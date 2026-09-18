using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class BotManager : Singleton<BotManager>
{
	private PlayerBotDiffculties mBotDiffculties;

	private BotNames mBotNames;

	private PlayerBots mBots;

	public BotNames botNamesSheet => mBotNames;

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

	protected override void Awake()
	{
		base.Awake();
		mBotDiffculties = GetComponent<PlayerBotDiffculties>();
		mBots = GetComponent<PlayerBots>();
		mBotNames = GetComponent<BotNames>();
	}

	public void SetUpBotDifficulty(PlayerBot bot, int botDifficulty, bool isInSquad, bool chooseCards = true)
	{
		botDifficulty = Mathf.Clamp(botDifficulty, 0, mBotDiffculties.Rows.Count - 1);
		bot.botConfig = mBotDiffculties.Rows[botDifficulty];
		bot.maxUnits = bot.botConfig.MAXUNITS;
		bot.canUseCards = bot.playerController.playerProperties.level > LevelManager.instance.warcardsUnlockLevel;
		bot.playerController.playerProperties.isBot = true;
		if (chooseCards)
		{
			Singleton<CardManagerDeathmatchOffline>.instance.ChooseCardsForMatch(bot.botConfig.CARDS, bot.playerController, (!isInSquad) ? 0f : bot.botConfig.BUDDYCARDPROB, bot.botConfig.CARDSFREQUENCY);
		}
		Debug.Log("#VAVRO# SETTING BOT DIFICULTY TO: " + bot.botConfig);
	}

	public int PrepareBotForTutorial(PlayerBot bot)
	{
		int result = 0;
		PlayerBotsRow playerBotsRow = mBots.Rows[0];
		SetUpBotDifficulty(bot, playerBotsRow.DIFFICULTY, isInSquad: false);
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		displayNumber = Mathf.Clamp(displayNumber, 1, 50);
		bot.playerController.playerProperties.level = displayNumber;
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
		bot.playerController.playerProperties.armyPower = num;
		List<PlayerInventory.EquippedWeapon> list = new List<PlayerInventory.EquippedWeapon>();
		if (Singleton<GameController>.instance.isTutorialStage3)
		{
			list.Add(AddWeapon(WeaponCategory.SMG.ToString(), 0));
		}
		else
		{
			list.Add(AddWeapon(WeaponCategory.AssaultRifle.ToString(), 0));
		}
		list.Add(AddWeapon(WeaponCategory.SniperRifle.ToString(), 0));
		PlayerInventory.EquippedWeapon item = AddWeapon(WeaponCategory.Grenade.ToString(), 0);
		list.Add(item);
		list.Add(AddWeapon(WeaponCategory.Pistol.ToString(), 0));
		bot.playerController.playerProperties.weapons = list.ToArray();
		foreach (PlayerWeapon usedWeapon in bot.playerController.weaponInventory.usedWeapons)
		{
			usedWeapon.weapon.friendKill = false;
		}
		bot.playerController.playerProperties.name = Localization.Localize("ID_YOUROPPONENT");
		bot.playerController.playerProperties.texture = Singleton<ArmyPreviewCamera>.instance.player2Texture;
		List<UnitUpgradeDefinition> list2 = new List<UnitUpgradeDefinition>();
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (LevelBehaviour item2 in behaviours)
			{
				UpgradeSlots.UnitUpgrades upgradeIndex = item2.upgradeSlots.LoadData(item2);
				list2.Add(new UnitUpgradeDefinition(item2.upgradeSlots.unlockLevelIndex <= 0 && !(item2 is SoldierBehaviourShotgunner), upgradeIndex, isNew: false, 1));
			}
		}
		bot.playerController.playerProperties.upgrades = list2;
		bot.playerController.playerProperties.playerVisuals = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
		return result;
	}

	public int PrepareBotForDeathMatch(PlayerBot bot)
	{
		Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 00 " + (bot == null) + "cp: " + (GameLoginManager.currentPlayer == null) + "d: " + (StatsManager.instance == null));
		int num = 0;
		try
		{
			List<PlayerBotsRow> list = new List<PlayerBotsRow>();
			int num2 = FindLeagueForBot();
			for (int i = 0; i < mBots.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = mBots.Rows[i];
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
				num = Mathf.Clamp(num - battlesLostInRow, 0, mBots.Rows.Count + 1);
			}
			PlayerBotsRow playerBotsRow3 = mBots.Rows[num];
			Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 0");
			int botLevel = GetBotLevel(LevelManager.instance.currentLevel.displayNumber);
			bot.playerController.playerProperties.level = botLevel;
			List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
			Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 1");
			bot.playerController.playerProperties.playerVisuals = GetBotVisuals(botLevel);
			float num3 = ((playerVisualCategories[3]["BANDS_EMPTY"] != CamosManager.instance.playerVisualCategories[3].equippedVisual) ? 0.5f : 0.95f);
			if (UnityEngine.Random.value < num3)
			{
				bot.playerController.playerProperties.playerVisuals[3] = playerVisualCategories[3]["BANDS_EMPTY"].id;
			}
			float botUnitPower;
			UnitUpgradeDefinition[] collection = PickBotUnits(out botUnitPower, botLevel);
			bot.playerController.playerProperties.upgrades = new List<UnitUpgradeDefinition>(collection);
			PlayerInventory.EquippedWeapon[] equippedWeapons;
			float value = PickWeapons(botLevel, out equippedWeapons);
			bot.playerController.playerProperties.weapons = equippedWeapons;
			Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 7");
			bot.playerController.playerProperties.armyPower = MiscTools.RoundToInt(botUnitPower) + MiscTools.RoundToInt(value) + LevelManager.instance.GetRankPower(botLevel);
			bot.playerController.playerProperties.isVip = UnityEngine.Random.value < 0.2f;
			bot.playerController.playerProperties.country = GetBotCountry();
			bot.playerController.playerProperties.warArenaCrown = WarArenaCrown.None;
			float num4 = ((botLevel >= 5) ? 0.5f : 0.2f);
			bot.playerController.playerProperties.medals = GameLoginManager.currentPlayer.skill + (int)UnityEngine.Random.Range((float)(-GameLoginManager.currentPlayer.skill) * num4, (float)GameLoginManager.currentPlayer.skill * num4);
			int b = UnityEngine.Random.Range(505, 515);
			bot.playerController.playerProperties.medals = Mathf.Max(bot.playerController.playerProperties.medals, b);
			bot.playerController.playerProperties.league = GameLoginManager.currentPlayer.leagueTier;
			if (StatsManager.instance.matchmadeGames < 1)
			{
				bot.playerController.playerProperties.beginnersLeague = 1;
			}
			else
			{
				bot.playerController.playerProperties.beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			}
			bot.playerController.playerProperties.isInLeague = GameLoginManager.currentPlayer.isInLeague;
			bot.playerController.playerProperties.leagueMedals = 0;
			Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 8");
			float value2 = UnityEngine.Random.value;
			if (value2 < 0.2f)
			{
				string nAME = mBotNames.Rows[UnityEngine.Random.Range(0, mBotNames.Rows.Count)].NAME;
				int num5 = 0;
				while (SavingLastSelected.instance.WasBotNameUsed(nAME))
				{
					num5++;
					if (num5 > 1000)
					{
						break;
					}
					nAME = mBotNames.Rows[UnityEngine.Random.Range(0, mBotNames.Rows.Count)].NAME;
				}
				SavingLastSelected.instance.AddUsedBotName(nAME);
				bot.playerController.playerProperties.name = nAME;
			}
			else
			{
				bot.playerController.playerProperties.name = "Warfriend" + UnityEngine.Random.Range(100000, 999999);
			}
			Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 9");
			if (DebugSettings.debugEnabled)
			{
				bot.playerController.playerProperties.name = "__" + bot.playerController.playerProperties.name;
			}
			bot.playerController.playerProperties.texture = Singleton<ArmyPreviewCamera>.instance.player2Texture;
			bool flag = botLevel >= 4 && !TutorialManagerPlayWarcards.instance.isTutorialRunning;
			Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 10");
			int dIFFICULTY = playerBotsRow3.DIFFICULTY;
			float deathMatchOfflineWinLooseStreak = StatsManager.instance.data.deathMatchOfflineWinLooseStreak;
			MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
			float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.winLooseToBotDifficultyCoef).FLOATVALUE;
			dIFFICULTY += (int)(deathMatchOfflineWinLooseStreak * fLOATVALUE);
			if (StatsManager.instance.matchmadeGames == 0)
			{
				Debug.Log("#VAVRO# SETTING BOT DIFICULTY TO WEAK");
				bot.botConfig = GetWeakBotConfig();
				bot.maxUnits = 6;
				bot.canUseCards = false;
				bot.playerController.playerProperties.isVip = false;
				bot.playerController.playerProperties.playerVisuals[3] = playerVisualCategories[3]["BANDS_EMPTY"].id;
				bot.playerController.playerProperties.level = 3;
				bot.playerController.playerProperties.isBot = true;
			}
			else
			{
				SetUpBotDifficulty(bot, dIFFICULTY, flag);
			}
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				bot.playerController.playerProperties.name = Localization.Localize("ID_YOUROPPONENT");
				bot.playerController.playerProperties.playerVisuals = CamosManager.instance.ConvertVisuals(new int[4] { 1, 0, 4, 0 });
				bot.playerController.playerProperties.level = 6;
			}
			bot.playerController.playerProperties.CreateFakeDataForBot(flag);
			Debug.Log($"BotManager: Setting bot for death match: {playerBotsRow3}  {num} Name random: {value2}, IsInSquad {flag} ");
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
		return num;
	}

	public static int GetBotLevel(int myLevel)
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
		int value = myLevel + UnityEngine.Random.Range(-num, num + 1);
		return Mathf.Clamp(value, 3, LevelManager.instance.levels.Count);
	}

	public static float PickWeapons(int botLevel, out PlayerInventory.EquippedWeapon[] equippedWeapons)
	{
		List<PlayerInventory.EquippedWeapon> list = new List<PlayerInventory.EquippedWeapon>();
		float num = 0f;
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float num2 = InterpolateWeaponPower(botLevel, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerInterval).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHighRankWeaponPowerInterval).FLOATVALUE);
		float a = InterpolateWeaponPower(botLevel, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMin).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHighRankWeaponPowerMin).FLOATVALUE);
		float b = InterpolateWeaponPower(botLevel, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowRankWeaponPowerMax).FLOATVALUE, matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHighRankWeaponPowerMax).FLOATVALUE);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float num3 = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			PlayerInventory.InventorySlot inventorySlot = PlayerInventory.instance.inventorySlots[i];
			WeaponLevelsSetup weaponLevelsSetup = inventorySlot.weaponLevelsSetup;
			float num4 = weaponLevelsSetup.weaponPower + num3;
			float num5 = weaponLevelsSetup.weaponPower + num3 + num2;
			WeaponLevelsSetup weaponLevelsSetup2 = AddRandomWeapon(inventorySlot.category, botLevel, num4, num5);
			int num6 = weaponLevelsSetup2.maxWeaponLevel;
			int num7 = 0;
			for (int j = 0; j < weaponLevelsSetup2.maxWeaponLevel; j++)
			{
				float weaponPower = weaponLevelsSetup2.GetWeaponPower(j);
				if (weaponPower <= num5 && weaponPower >= num4)
				{
					if (j < num6)
					{
						num6 = j;
					}
					if (j > num7)
					{
						num7 = j;
					}
				}
			}
			if (num7 < num6)
			{
				num6 = num7;
			}
			list.Add(new PlayerInventory.EquippedWeapon
			{
				weaponId = weaponLevelsSetup2.indexInLevelManager,
				weaponUpgrade = UnityEngine.Random.Range(num6, num7)
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		for (int k = 0; k < list.Count; k++)
		{
			PlayerInventory.EquippedWeapon equippedWeapon = list[k];
			int weaponId = list[k].weaponId;
			WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[weaponId];
			num += weaponLevelsSetup3.GetWeaponPower(equippedWeapon.weaponUpgrade);
		}
		equippedWeapons = list.ToArray();
		return num;
	}

	private static List<int> GetNRandomValuesWithSum(int sum, int n, int max, int offset, List<Tuple<int, int>> minMAx)
	{
		List<int> list = new List<int>();
		int num = 0;
		int num2 = 0;
		for (num2 = 0; num2 < n; num2++)
		{
			list.Add(UnityEngine.Random.Range(0, max + 1));
			list[num2] = Mathf.Clamp(list[num2], minMAx[num2].Value1 - offset, minMAx[num2].Value2 - offset);
			num += list[num2];
		}
		float num3 = (float)num / (float)sum;
		num = 0;
		for (num2 = 0; num2 < n; num2++)
		{
			list[num2] = Mathf.RoundToInt((float)list[num2] / num3) + offset;
			list[num2] = Mathf.Clamp(list[num2], minMAx[num2].Value1, minMAx[num2].Value2);
			num += list[num2];
		}
		int num4 = sum + n * offset;
		num2 = 0;
		int num6;
		for (; num != num4; num += num6)
		{
			if (num2 >= 100)
			{
				break;
			}
			num2++;
			int index = UnityEngine.Random.Range(0, n);
			int num5 = list[index];
			list[index] = Mathf.Clamp(list[index] + ((num4 - num > 0) ? 1 : (-1)), minMAx[index].Value1, minMAx[index].Value2);
			num6 = list[index] - num5;
		}
		return list;
	}

	public static UnitUpgradeDefinition[] PickBotUnits(out float botUnitPower, int botLevel)
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		list.AddRange(behaviours);
		list.Sort((LevelBehaviour a, LevelBehaviour b) => a.upgradeSlots.unlockLevelIndex.CompareTo(b.upgradeSlots.unlockLevelIndex) * -1);
		botUnitPower = 0f;
		Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 3");
		UnitUpgradeDefinition[] array = new UnitUpgradeDefinition[list.Count];
		for (int num = 0; num < list.Count; num++)
		{
			LevelBehaviour levelBehaviour = list[num];
			UnitUpgradeDefinition unitUpgradeDefinition = (array[levelBehaviour.indexInLevelsManager] = new UnitUpgradeDefinition(levelBehaviour.upgradeSlots.unlockLevelIndex <= botLevel - 1, new UpgradeSlots.UnitUpgrades(1f), isNew: false, 0));
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
		UnEquip(list, array, dictionary);
		int num2 = ValidateUnits(list, array);
		dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		List<int> list2 = new List<int>();
		int num3 = 0;
		int num4 = 0;
		List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
		float tierCoef;
		float tierInterval;
		for (int num5 = 0; num5 < list.Count; num5++)
		{
			LevelBehaviour levelBehaviour2 = list[num5];
			UnitUpgradeDefinition unitUpgradeDefinition2 = array[levelBehaviour2.indexInLevelsManager];
			tierCoef = Mathf.Clamp01((float)(levelBehaviour2.upgradeSlots.actualTier - 1) / 5f);
			GetUnitUpgradesRange(tierCoef, out tierInterval, out var tierIntervalOffset);
			int value = levelBehaviour2.upgradeSlots.boughtIndex + (int)UnityEngine.Random.Range(tierIntervalOffset, tierIntervalOffset + tierInterval);
			if (unitUpgradeDefinition2.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour2.unitType))
				{
					dictionary[levelBehaviour2.unitType] = new List<UnitUpgradeDefinition>();
				}
				dictionary[levelBehaviour2.unitType].Add(unitUpgradeDefinition2);
				if (!levelBehaviour2.upgradeSlots.equipped)
				{
					LevelBehaviour levelBehaviour3 = LevelManager.GetBestEquipped(levelBehaviour2.unitType);
					if (dictionary[levelBehaviour2.unitType].Count > 1)
					{
						UnitUpgradeDefinition unitUpgradeDefinition3 = dictionary[levelBehaviour2.unitType][0];
						if (!behaviours[unitUpgradeDefinition3.index].upgradeSlots.equipped)
						{
							levelBehaviour3 = LevelManager.GetWorstEquipped(levelBehaviour2.unitType);
						}
					}
					int value2 = ((!(levelBehaviour3 == null)) ? (levelBehaviour3.upgradeSlots.actualUnitLevel - levelBehaviour2.upgradeSlots.startUnitLevel) : 0);
					value2 = Mathf.Clamp(value2, 0, int.MaxValue);
					value = value2 + (int)UnityEngine.Random.Range(tierIntervalOffset, tierIntervalOffset + tierInterval);
				}
			}
			int lastndexForTier = levelBehaviour2.upgradeSlots.GetLastndexForTier(levelBehaviour2.upgradeSlots.GetMaxTierForLevel(botLevel));
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
		tierCoef = Mathf.Clamp01((float)(num4 - 1) / 5f);
		tierInterval = GetRandomnessInterval(tierCoef);
		list2 = GetNRandomValuesWithSum(num2 * (int)tierInterval, num2, (int)tierInterval * 2, -(int)tierInterval, list3);
		for (int num6 = 0; num6 < list.Count; num6++)
		{
			LevelBehaviour levelBehaviour4 = list[num6];
			UnitUpgradeDefinition unitUpgradeDefinition4 = array[levelBehaviour4.indexInLevelsManager];
			int num7 = unitUpgradeDefinition4.unitUpgrades.slotUpgradeindex;
			int lastndexForTier2 = levelBehaviour4.upgradeSlots.GetLastndexForTier(levelBehaviour4.upgradeSlots.GetMaxTierForLevel(botLevel));
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
			int unlockTierLevel = levelBehaviour4.upgradeSlots.GetUnlockTierLevel(levelBehaviour4.upgradeSlots.startTier);
			bool isSpecial = botLevel >= unlockTierLevel && unlockTierLevel > 0 && tier2 > levelBehaviour4.upgradeSlots.startTier;
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
				botUnitPower += levelBehaviour4.upgradeSlots.GetArmyPower(unitUpgradeDefinition5.unitUpgrades.slotUpgradeindex, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexSpecial, unitUpgradeDefinition5.tier, unitUpgradeDefinition5.unitUpgrades.slotUpgradeIndexElite, unitUpgradeDefinition5.unitUpgrades.isElite);
			}
		}
		Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 4");
		return array;
	}

	private static void UnEquip(List<LevelBehaviour> orderedBehaviours, UnitUpgradeDefinition[] botUpgrades, Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> categoryCounts)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		Dictionary<LevelBehaviour.UnitType, Tuple<int, int>> dictionary = new Dictionary<LevelBehaviour.UnitType, Tuple<int, int>>();
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeakUnitProbabilityMax).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeakUnitProbabilityMin).FLOATVALUE;
		float num = Mathf.Lerp(fLOATVALUE2, fLOATVALUE, 1f - deathmatchOfflineWinLooseStreakRatio);
		for (int i = 0; i < orderedBehaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = orderedBehaviours[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			if (!dictionary.ContainsKey(levelBehaviour.unitType))
			{
				dictionary[levelBehaviour.unitType] = new Tuple<int, int>(0, 0);
			}
			UnitUpgradeDefinition unitUpgradeDefinition = botUpgrades[indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped && levelBehaviour.upgradeSlots.unlockLevelIndex >= 3)
			{
				int num2 = Mathf.Max(0, categoryCounts[levelBehaviour.unitType].Count - 2);
				LevelBehaviour levelBehaviour2 = ((dictionary[levelBehaviour.unitType].Value2 != 0) ? LevelManager.GetWorstEquipped(levelBehaviour.unitType) : LevelManager.GetBestEquipped(levelBehaviour.unitType));
				int num3 = ((!(levelBehaviour2 == null)) ? levelBehaviour2.upgradeSlots.actualUnitLevel : 0);
				int num4 = levelBehaviour.upgradeSlots.startUnitLevel - num3;
				double num5 = ((dictionary[levelBehaviour.unitType].Value1 < num2) ? Math.Pow(num, dictionary[levelBehaviour.unitType].Value1 + 1) : 0.0);
				float tierCoef = Mathf.Clamp01((float)(levelBehaviour.upgradeSlots.actualTier - 1) / 5f);
				GetUnitUpgradesRange(tierCoef, out var tierInterval, out var tierIntervalOffset);
				if ((float)num4 > tierIntervalOffset + tierInterval)
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

	private static int ValidateUnits(List<LevelBehaviour> orderedBehaviours, UnitUpgradeDefinition[] botUpgrades)
	{
		int num = 0;
		int num2 = 0;
		Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<UnitUpgradeDefinition>>();
		for (int i = 0; i < orderedBehaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = orderedBehaviours[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			dictionary[levelBehaviour.unitType] = new List<UnitUpgradeDefinition>();
			if (!levelBehaviour.isSoldier && botUpgrades[indexInLevelsManager].isEquipped)
			{
				if (num2 >= 3)
				{
					botUpgrades[indexInLevelsManager].isEquipped = false;
				}
				else
				{
					num2++;
				}
			}
		}
		Crittercism.LeaveBreadcrumb("PrepareBotForDeathMatch 5");
		for (int j = 0; j < orderedBehaviours.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = orderedBehaviours[j];
			int indexInLevelsManager2 = levelBehaviour2.indexInLevelsManager;
			if (botUpgrades[indexInLevelsManager2].isEquipped)
			{
				if (dictionary[levelBehaviour2.unitType].Count >= 2)
				{
					botUpgrades[indexInLevelsManager2].isEquipped = false;
					continue;
				}
				dictionary[levelBehaviour2.unitType].Add(botUpgrades[indexInLevelsManager2]);
				num++;
			}
		}
		return num;
	}

	private static void GetUnitUpgradesRange(float tierCoef, out float tierInterval, out float tierIntervalOffset)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierInterval).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierInterval).FLOATVALUE;
		tierInterval = Mathf.Lerp(fLOATVALUE, fLOATVALUE2, tierCoef);
		float fLOATVALUE3 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierIntervalOffsetMin).FLOATVALUE;
		float fLOATVALUE4 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalOffsetMin).FLOATVALUE;
		float a = Mathf.Lerp(fLOATVALUE3, fLOATVALUE4, tierCoef);
		float fLOATVALUE5 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierIntervalOffsetMax).FLOATVALUE;
		float fLOATVALUE6 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalOffsetMax).FLOATVALUE;
		float b = Mathf.Lerp(fLOATVALUE5, fLOATVALUE6, tierCoef);
		float deathmatchOfflineWinLooseStreakRatio = StatsManager.instance.data.deathmatchOfflineWinLooseStreakRatio;
		tierIntervalOffset = Mathf.Lerp(a, b, deathmatchOfflineWinLooseStreakRatio);
	}

	private static int GetRandomnessInterval(float tierCoef)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botLowTierIntervalRandomness).FLOATVALUE;
		float fLOATVALUE2 = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botHightTierIntervalRandomness).FLOATVALUE;
		return (int)Mathf.Lerp(fLOATVALUE, fLOATVALUE2, tierCoef);
	}

	private int FindLeagueForBot()
	{
		int num = 0;
		int leagueTier = (int)GameLoginManager.currentPlayer.leagueTier;
		int num2 = ((!useEasyBot) ? GameLoginManager.currentPlayer.medalsBalance : 0);
		int num3 = 0;
		num = leagueTier;
		if (num2 > 0)
		{
			for (int i = 0; i < mBots.Rows.Count; i++)
			{
				PlayerBotsRow playerBotsRow = mBots.Rows[i];
				if ((i == mBots.Rows.Count - 1 || mBots.Rows[i + 1].LEAGUE != playerBotsRow.LEAGUE) && playerBotsRow.LEAGUE >= leagueTier)
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
			for (int num4 = mBots.Rows.Count - 1; num4 >= 0; num4--)
			{
				PlayerBotsRow playerBotsRow2 = mBots.Rows[num4];
				if ((num4 == 0 || mBots.Rows[num4 - 1].LEAGUE != playerBotsRow2.LEAGUE) && playerBotsRow2.LEAGUE <= leagueTier)
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
		Crittercism.LeaveBreadcrumb($"=== Choosing bot for me in league {leagueTier} and balance {num2}. Chosen bot in league {num} ===");
		return num;
	}

	private static float InterpolateWeaponPower(int rank, float from, float to)
	{
		MatchMakingConstants matchMakingConstants = Singleton<GameVariables>.instance.matchMakingConstants;
		float fLOATVALUE = matchMakingConstants.GetRow(MatchMakingConstants.rowIds.botWeaponPowerInterpolationConstant).FLOATVALUE;
		float num = (to - from) / Mathf.Pow(LevelManager.instance.levels.Count - 1, fLOATVALUE);
		return from + num * Mathf.Pow(rank - 1, fLOATVALUE);
	}

	private UnitUpgradeDefinition GetRandomEquipped(List<LevelBehaviour> orderedBehaviours, List<UnitUpgradeDefinition> botUpgrades, int maxIndex, bool isSoldier, LevelBehaviour.UnitType? unitType = null)
	{
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		for (int i = 0; i < maxIndex; i++)
		{
			LevelBehaviour levelBehaviour = orderedBehaviours[i];
			int indexInLevelsManager = levelBehaviour.indexInLevelsManager;
			botUpgrades[indexInLevelsManager].index = indexInLevelsManager;
			if (botUpgrades[indexInLevelsManager].isEquipped && (!levelBehaviour.isSoldier || !isSoldier) && (!unitType.HasValue || levelBehaviour.unitType == unitType.Value))
			{
				list.Add(botUpgrades[indexInLevelsManager]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public string[] GetBotVisuals(int botLevel)
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		string[] array = new string[4]
		{
			GetRandomAvailable(playerVisualCategories[0], botLevel),
			GetRandomAvailable(playerVisualCategories[1], botLevel),
			GetRandomAvailable(playerVisualCategories[2], botLevel),
			GetEmptyPowerBand()
		};
		if (botLevel <= 4)
		{
			array[0] = "CAMOS_DEFAULT";
			array[1] = "HELMETS_EMPTY";
			array[2] = "HEAD_EMPTY";
		}
		return array;
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
					if (countryInfoRow.CONTINENT == cONTINENT && GameVariables.countryCodes.ContainsKey(text))
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

	public static string GetRandomAvailable(PlayerVisualCategory category, int level)
	{
		PlayerVisual.Rarity rarity = GerRandomRarity();
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in category.allVisuals)
		{
			if (allVisual.unlockLevel.index < level && allVisual.rarity == rarity && allVisual.purchasable != PlayerVisual.Purchasable.Arena)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	private static PlayerVisual.Rarity GerRandomRarity()
	{
		float value = UnityEngine.Random.value;
		for (int num = CamosManager.instance.playerVisualsRarities.Rows.Count - 1; num >= 0; num--)
		{
			PlayerVisualsRaritiesRow playerVisualsRaritiesRow = CamosManager.instance.playerVisualsRarities.Rows[num];
			if (value <= playerVisualsRaritiesRow.PROBABILITY)
			{
				return (PlayerVisual.Rarity)playerVisualsRaritiesRow.VALUE;
			}
		}
		return PlayerVisual.Rarity.Common;
	}

	public static string GetEmptyPowerBand()
	{
		return "BANDS_EMPTY";
	}

	public static string GetRandomUnlocked(PlayerVisualCategory category, int level)
	{
		List<PlayerVisual> list = new List<PlayerVisual>();
		foreach (PlayerVisual allVisual in category.allVisuals)
		{
			if (allVisual.decalType <= level)
			{
				list.Add(allVisual);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].id;
	}

	public void PrepareBotForMission(PlayerBot bot, MissionDefinition missionDefinition)
	{
		MissionDefinitionBot bot2 = missionDefinition.bot;
		int difficulty = bot2.difficulty;
		int level = bot2.level;
		float hpReduction = bot2.hpReduction;
		bot.playerController.destroyableParts.maxHealth = (float)Singleton<GameVariables>.instance.balancetable.Rows[level].PLAYERHP * hpReduction;
		bot.playerController.destroyableParts.Refill();
		PlayerBotsRow playerBotsRow = mBots.Rows[0];
		foreach (PlayerBotsRow row in mBots.Rows)
		{
			if (row.NUMBER == difficulty)
			{
				playerBotsRow = row;
				break;
			}
		}
		SetUpBotDifficulty(bot, playerBotsRow.DIFFICULTY, isInSquad: false);
		bot.maxUnits = missionDefinition.maxUnits;
		int value = level;
		value = Mathf.Clamp(value, 0, 49);
		bot.playerController.playerProperties.level = value;
		List<PlayerInventory.EquippedWeapon> list = new List<PlayerInventory.EquippedWeapon>();
		list.Add(AddWeapon(playerBotsRow.PRIMARY, value));
		list.Add(AddWeapon(playerBotsRow.SECONDARY, value));
		PlayerInventory.EquippedWeapon equippedWeapon = AddWeapon(playerBotsRow.EXPLOSIVES, value);
		if (equippedWeapon.weaponId == 0)
		{
			equippedWeapon = AddWeapon(WeaponCategory.Grenade.ToString(), value);
		}
		list.Add(AddWeapon(WeaponCategory.Pistol.ToString(), value));
		list.Add(equippedWeapon);
		bot.playerController.playerProperties.weapons = list.ToArray();
		bot.playerController.playerProperties.name = bot2.name;
		bot.playerController.playerProperties.texture = Singleton<ArmyPreviewCamera>.instance.player2Texture;
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		BotMission botMission = MissionsManager.instance.currentMission as BotMission;
		bot.playerController.playerProperties.upgrades = botMission.GetUpgrades();
		bot.playerController.playerProperties.playerVisuals = bot2.botVisuals;
		bot.playerController.playerProperties.league = League.NoLeague;
		bot.playerController.playerProperties.isVip = false;
		bot.playerController.playerProperties.warArenaCrown = WarArenaCrown.None;
		Debug.Log(string.Concat("#VAVRO# setting bot for mission: ", playerBotsRow, "HP: ", bot.playerController.destroyableParts.maxHealth));
	}

	public static WeaponLevelsSetup AddRandomWeapon(WeaponCategory category, int level, float minPower, float maxPower)
	{
		try
		{
			List<WeaponLevelsSetup> suitableWeapons = LevelManager.instance.GetSuitableWeapons(category, level, minPower, maxPower, WeaponCategory.Minigun);
			if (suitableWeapons.Count > 0)
			{
				return suitableWeapons[UnityEngine.Random.Range(0, suitableWeapons.Count)];
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
		Debug.LogErrorFormat("Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}", category, level, minPower, maxPower);
		return null;
	}

	public PlayerInventory.EquippedWeapon AddWeapon(string enumName, int level)
	{
		try
		{
			WeaponCategory category = (WeaponCategory)(int)Enum.Parse(typeof(WeaponCategory), enumName);
			int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(category, level);
			PlayerInventory.EquippedWeapon equippedWeapon = new PlayerInventory.EquippedWeapon();
			equippedWeapon.weaponId = lastUnlockedWeapon;
			return equippedWeapon;
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
		return new PlayerInventory.EquippedWeapon();
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
}

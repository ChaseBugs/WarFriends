using System;
using System.Collections.Generic;
using UnityEngine;

namespace Google2u
{
public class Constants : Google2uComponentBase, IGoogle2uDB
{
	public enum rowIds
	{
		SinglePlayerScoreStreakRatio,
		MultiPlayerScoreStreakRatio,
		DeathMatchTime,
		ShieldRespawnRatePerSec,
		GoldCardRarity,
		SilverCardRarity,
		BronzePackBronzeCards,
		BronzePackGuaranteedCardsType,
		BronzePackMaxRarityCardsType,
		SilverPackSilverCards,
		SilverPackGuaranteedCardsType,
		SilverPackMaxRarityCardsType,
		GoldPackGoldCards,
		GoldPackGuaranteedCardsType,
		GoldPackMaxRarityCardsType,
		CardsInPack,
		GoldCoefficient,
		GoldExpCoefficient,
		WinstreakInterval,
		WinstreakReward1,
		WinstreakReward2,
		WinstreakReward3,
		WinstreakReward4,
		WinstreakReward5,
		WinstreakReward6,
		WinstreakReward7,
		WinstreakReward8,
		WinstreakReward9,
		WinstreakReward10,
		VipWarbucksMultiplier,
		VipExperienceMultiplier,
		FriendDamageCoeficient,
		VipGoldCardRewardChance,
		WarpathUnlockLevel,
		JoinSquadUnlockLevel,
		CreateSquadUnlockLevel,
		GoldCardRarityEarly,
		SilverCardRarityEarly,
		GoldCrateLowLevelProbability,
		GoldCrateLowLevelGoldMin,
		GoldCrateLowLevelGoldMax,
		ArmoredVehicleShotCoeficient,
		UnitToShieldCoef,
		PlayerExplosiveCoef,
		PlayerExplosiveOvertimeCoef,
		ShieldExplosionCoef,
		VipGoldMultiplier,
		VipDogtags,
		VipRunningOutSeconds,
		MinTimeSinceLastWeaponUpgrade,
		MinTimeSinceLastUnitUpgrade,
		MinLevelForCardsReminder,
		LowNumberOfCards,
		MinLevelForSquadJoinOrCreateReminder,
		MinTimeSinceLastVipPurchase,
		TutorialUpgradeWeaponAfterGames,
		TutorialUpgradeUnitAfterGames,
		StartingWarbucks,
		StartingGold,
		MaxEnergy,
		LapsedPlayerInterval3,
		LapsedPlayerInterval2,
		LapsedPlayerInterval1,
		GoldRewardFirstTimeSquad,
		FacebookLike,
		TwitterFollow,
		ShieldRepairTime,
		TaskReward1Min,
		TaskReward1Max,
		TaskReward2Min,
		TaskReward2Max,
		TaskReward3Min,
		TaskReward3Max,
		DogTagRefillTime,
		DogTagCap,
		WarbucksScalingBase,
		DestroyShieldsInOverTime,
		RepairShields,
		FacebookLoginReward,
		GooglePlayLoginReward,
		RateAppReward,
		MaxPingToConnectRegion,
		RateAppMaxShow,
		NotificationAllowReward,
		NotificationAllowWinsNeed,
		NotificationAllowHoursBetween,
		NotificationAllowMaxShow,
		ServerRentalSaleMin,
		ServerRentalSaleMax,
		ServerRentalVisualProbability,
		ServerRentalWeaponProbability,
		ServerRentalUnitProbability,
		ServerRentalUnitCanLockedCount,
		ServerRentalWeaponCanLockedCount,
		ServerRentalMaxUnits,
		ServerRentalMaxWeapons,
		ServerRentalMaxLockedFor,
		ServerRentalPowerbandDelayMin,
		ServerRentalPowerbandDelayMax,
		ServerRentalWoUDelayMin,
		ServerRentalWoUDelayMax,
		NameChangeReminderGamesAfterFbLogin,
		FacebookLoginReminder1After,
		FacebookLoginReminder2After,
		FacebookLoginReminder3After,
		TimeBetweenVIPreminderShown,
		TimeBetweenWeaponUpgradeReminderShown,
		TimeBetweenUnitUpgradeReminderShown,
		TimeBetweenSquadReminderShown,
		WarcardAdCount,
		WarcardAdInterval,
		DogtagAdCount,
		DogtagAdInterval,
		GoldenSuitcaseAdCount,
		GoldenSuitcaseAdInterval,
		GoldenSuitcaseAdTimeBetweenMinutes,
		GoldenSuitcase_VIPRewardChance,
		GoldenSuitcase_VIPRewardDuration,
		GoldenSuitcase_PowerbandRewardChance,
		GoldenSuitcase_PowerbandRewardDuration,
		GoldenSuitcase_GoldRewardChance,
		GoldenSuitcase_CardRewardChance,
		GoldenSuitcase_WBRewardChance,
		GoldenSuitcase_WBRewardMin,
		GoldenSuitcase_WBRewardMax,
		GoldenSuitcase_GoldRewardMin,
		GoldenSuitcase_GoldRewardMax,
		ServerRentalMaxLockedForWeapon,
		ArmyPowerWeaponConstant,
		EarlyPlayerLevelProgress,
		UnitCategoriesReminderAfterGames,
		SquadMedalWeight1,
		SquadMedalWeight2,
		SquadMedalWeight3,
		SquadMedalWeight4,
		SquadMedalWeight5,
		SquadMedalWeight6,
		LeaguePlacementMatches,
		SendUnitsCoolDown,
		CardWithdrawTimer,
		SquadWarsReminder,
		LeagueReminder,
		MatchmakingEasyBotTillLevel,
		EasyBotHpCoeficient,
		MoneyPackRunningOutSeconds,
		RateAppShowAfterBattles,
		RateAppShowAfterLevel,
		RateAppShowSecondTimeAfterLevel,
		StarterPackRunningOutSeconds,
		NotEnoughPlayersForPlayerLeague,
		CardCraftTimeSilver,
		CardCraftTimeGold,
		SquadWarsLowerSquadLimit,
		FullAutoDeployTime,
		SemiAutoDeployTime,
		SemiAutoDeployEnergy,
		WarBucksCreateSquadPrice,
		SecondRenameGoldCost,
		LootboxAfterBattles,
		LootboxesAdCount,
		LootboxesAdInterval,
		ChatMessagesLimit,
		GoldenSuitcase_LootboxRewardChance,
		GoldenSuitcase_LootboxRewardMin,
		GoldenSuitcase_LootboxRewardMax,
		GoldenSuitcaseUnlockLevel,
		SquadWarsLowSquadsTier2Reward,
		SquadWarsLowSquadsTier3Reward,
		SquadWarsLowSquadsTier4Reward,
		SquadWarsLowSquadsTier5Reward,
		SquadWarsLowSquadsNoReward,
		SquadWarsTier3Percentage,
		SquadWarsTier4Percentage,
		SquadWarsTier5Percentage,
		SquadWarsNoRewardPercentage,
		GetAllMessagesTimer,
		LootboxesUnlockLevel,
		MaxPingForChallenge,
		InstantBattleEnabled,
		InstantBattleUnlockLevel,
		InstantBattleMax,
		InstantBattleReload,
		InstantBattleCostMin,
		InstantBattleCostMax,
		TicketsToGold,
		GoldenSuitcaseTicketsChance,
		GoldenSuitcaseTicketsMin,
		GoldenSuitcaseTicketsMax,
		PartToScrapsSell,
		PartToScrapsUpgrade,
		GoldenSuitcaseScrapsChance,
		GoldenSuitcaseScrapsMin,
		GoldenSuitcaseScrapsMax,
		ChatTempLegacyVersion13
	}

	public string[] rowNames = new string[194]
	{
		"SinglePlayerScoreStreakRatio", "MultiPlayerScoreStreakRatio", "DeathMatchTime", "ShieldRespawnRatePerSec", "GoldCardRarity", "SilverCardRarity", "BronzePackBronzeCards", "BronzePackGuaranteedCardsType", "BronzePackMaxRarityCardsType", "SilverPackSilverCards",
		"SilverPackGuaranteedCardsType", "SilverPackMaxRarityCardsType", "GoldPackGoldCards", "GoldPackGuaranteedCardsType", "GoldPackMaxRarityCardsType", "CardsInPack", "GoldCoefficient", "GoldExpCoefficient", "WinstreakInterval", "WinstreakReward1",
		"WinstreakReward2", "WinstreakReward3", "WinstreakReward4", "WinstreakReward5", "WinstreakReward6", "WinstreakReward7", "WinstreakReward8", "WinstreakReward9", "WinstreakReward10", "VipWarbucksMultiplier",
		"VipExperienceMultiplier", "FriendDamageCoeficient", "VipGoldCardRewardChance", "WarpathUnlockLevel", "JoinSquadUnlockLevel", "CreateSquadUnlockLevel", "GoldCardRarityEarly", "SilverCardRarityEarly", "GoldCrateLowLevelProbability", "GoldCrateLowLevelGoldMin",
		"GoldCrateLowLevelGoldMax", "ArmoredVehicleShotCoeficient", "UnitToShieldCoef", "PlayerExplosiveCoef", "PlayerExplosiveOvertimeCoef", "ShieldExplosionCoef", "VipGoldMultiplier", "VipDogtags", "VipRunningOutSeconds", "MinTimeSinceLastWeaponUpgrade",
		"MinTimeSinceLastUnitUpgrade", "MinLevelForCardsReminder", "LowNumberOfCards", "MinLevelForSquadJoinOrCreateReminder", "MinTimeSinceLastVipPurchase", "TutorialUpgradeWeaponAfterGames", "TutorialUpgradeUnitAfterGames", "StartingWarbucks", "StartingGold", "MaxEnergy",
		"LapsedPlayerInterval3", "LapsedPlayerInterval2", "LapsedPlayerInterval1", "GoldRewardFirstTimeSquad", "FacebookLike", "TwitterFollow", "ShieldRepairTime", "TaskReward1Min", "TaskReward1Max", "TaskReward2Min",
		"TaskReward2Max", "TaskReward3Min", "TaskReward3Max", "DogTagRefillTime", "DogTagCap", "WarbucksScalingBase", "DestroyShieldsInOverTime", "RepairShields", "FacebookLoginReward", "GooglePlayLoginReward",
		"RateAppReward", "MaxPingToConnectRegion", "RateAppMaxShow", "NotificationAllowReward", "NotificationAllowWinsNeed", "NotificationAllowHoursBetween", "NotificationAllowMaxShow", "ServerRentalSaleMin", "ServerRentalSaleMax", "ServerRentalVisualProbability",
		"ServerRentalWeaponProbability", "ServerRentalUnitProbability", "ServerRentalUnitCanLockedCount", "ServerRentalWeaponCanLockedCount", "ServerRentalMaxUnits", "ServerRentalMaxWeapons", "ServerRentalMaxLockedFor", "ServerRentalPowerbandDelayMin", "ServerRentalPowerbandDelayMax", "ServerRentalWoUDelayMin",
		"ServerRentalWoUDelayMax", "NameChangeReminderGamesAfterFbLogin", "FacebookLoginReminder1After", "FacebookLoginReminder2After", "FacebookLoginReminder3After", "TimeBetweenVIPreminderShown", "TimeBetweenWeaponUpgradeReminderShown", "TimeBetweenUnitUpgradeReminderShown", "TimeBetweenSquadReminderShown", "WarcardAdCount",
		"WarcardAdInterval", "DogtagAdCount", "DogtagAdInterval", "GoldenSuitcaseAdCount", "GoldenSuitcaseAdInterval", "GoldenSuitcaseAdTimeBetweenMinutes", "GoldenSuitcase_VIPRewardChance", "GoldenSuitcase_VIPRewardDuration", "GoldenSuitcase_PowerbandRewardChance", "GoldenSuitcase_PowerbandRewardDuration",
		"GoldenSuitcase_GoldRewardChance", "GoldenSuitcase_CardRewardChance", "GoldenSuitcase_WBRewardChance", "GoldenSuitcase_WBRewardMin", "GoldenSuitcase_WBRewardMax", "GoldenSuitcase_GoldRewardMin", "GoldenSuitcase_GoldRewardMax", "ServerRentalMaxLockedForWeapon", "ArmyPowerWeaponConstant", "EarlyPlayerLevelProgress",
		"UnitCategoriesReminderAfterGames", "SquadMedalWeight1", "SquadMedalWeight2", "SquadMedalWeight3", "SquadMedalWeight4", "SquadMedalWeight5", "SquadMedalWeight6", "LeaguePlacementMatches", "SendUnitsCoolDown", "CardWithdrawTimer",
		"SquadWarsReminder", "LeagueReminder", "MatchmakingEasyBotTillLevel", "EasyBotHpCoeficient", "MoneyPackRunningOutSeconds", "RateAppShowAfterBattles", "RateAppShowAfterLevel", "RateAppShowSecondTimeAfterLevel", "StarterPackRunningOutSeconds", "NotEnoughPlayersForPlayerLeague",
		"CardCraftTimeSilver", "CardCraftTimeGold", "SquadWarsLowerSquadLimit", "FullAutoDeployTime", "SemiAutoDeployTime", "SemiAutoDeployEnergy", "WarBucksCreateSquadPrice", "SecondRenameGoldCost", "LootboxAfterBattles", "LootboxesAdCount",
		"LootboxesAdInterval", "ChatMessagesLimit", "GoldenSuitcase_LootboxRewardChance", "GoldenSuitcase_LootboxRewardMin", "GoldenSuitcase_LootboxRewardMax", "GoldenSuitcaseUnlockLevel", "SquadWarsLowSquadsTier2Reward", "SquadWarsLowSquadsTier3Reward", "SquadWarsLowSquadsTier4Reward", "SquadWarsLowSquadsTier5Reward",
		"SquadWarsLowSquadsNoReward", "SquadWarsTier3Percentage", "SquadWarsTier4Percentage", "SquadWarsTier5Percentage", "SquadWarsNoRewardPercentage", "GetAllMessagesTimer", "LootboxesUnlockLevel", "MaxPingForChallenge", "InstantBattleEnabled", "InstantBattleUnlockLevel",
		"InstantBattleMax", "InstantBattleReload", "InstantBattleCostMin", "InstantBattleCostMax", "TicketsToGold", "GoldenSuitcaseTicketsChance", "GoldenSuitcaseTicketsMin", "GoldenSuitcaseTicketsMax", "PartToScrapsSell", "PartToScrapsUpgrade",
		"GoldenSuitcaseScrapsChance", "GoldenSuitcaseScrapsMin", "GoldenSuitcaseScrapsMax", "ChatTempLegacyVersion13"
	};

	public Dictionary<string, int> namesToIndex = new Dictionary<string, int>
	{
		{ "SinglePlayerScoreStreakRatio", 0 },
		{ "MultiPlayerScoreStreakRatio", 1 },
		{ "DeathMatchTime", 2 },
		{ "ShieldRespawnRatePerSec", 3 },
		{ "GoldCardRarity", 4 },
		{ "SilverCardRarity", 5 },
		{ "BronzePackBronzeCards", 6 },
		{ "BronzePackGuaranteedCardsType", 7 },
		{ "BronzePackMaxRarityCardsType", 8 },
		{ "SilverPackSilverCards", 9 },
		{ "SilverPackGuaranteedCardsType", 10 },
		{ "SilverPackMaxRarityCardsType", 11 },
		{ "GoldPackGoldCards", 12 },
		{ "GoldPackGuaranteedCardsType", 13 },
		{ "GoldPackMaxRarityCardsType", 14 },
		{ "CardsInPack", 15 },
		{ "GoldCoefficient", 16 },
		{ "GoldExpCoefficient", 17 },
		{ "WinstreakInterval", 18 },
		{ "WinstreakReward1", 19 },
		{ "WinstreakReward2", 20 },
		{ "WinstreakReward3", 21 },
		{ "WinstreakReward4", 22 },
		{ "WinstreakReward5", 23 },
		{ "WinstreakReward6", 24 },
		{ "WinstreakReward7", 25 },
		{ "WinstreakReward8", 26 },
		{ "WinstreakReward9", 27 },
		{ "WinstreakReward10", 28 },
		{ "VipWarbucksMultiplier", 29 },
		{ "VipExperienceMultiplier", 30 },
		{ "FriendDamageCoeficient", 31 },
		{ "VipGoldCardRewardChance", 32 },
		{ "WarpathUnlockLevel", 33 },
		{ "JoinSquadUnlockLevel", 34 },
		{ "CreateSquadUnlockLevel", 35 },
		{ "GoldCardRarityEarly", 36 },
		{ "SilverCardRarityEarly", 37 },
		{ "GoldCrateLowLevelProbability", 38 },
		{ "GoldCrateLowLevelGoldMin", 39 },
		{ "GoldCrateLowLevelGoldMax", 40 },
		{ "ArmoredVehicleShotCoeficient", 41 },
		{ "UnitToShieldCoef", 42 },
		{ "PlayerExplosiveCoef", 43 },
		{ "PlayerExplosiveOvertimeCoef", 44 },
		{ "ShieldExplosionCoef", 45 },
		{ "VipGoldMultiplier", 46 },
		{ "VipDogtags", 47 },
		{ "VipRunningOutSeconds", 48 },
		{ "MinTimeSinceLastWeaponUpgrade", 49 },
		{ "MinTimeSinceLastUnitUpgrade", 50 },
		{ "MinLevelForCardsReminder", 51 },
		{ "LowNumberOfCards", 52 },
		{ "MinLevelForSquadJoinOrCreateReminder", 53 },
		{ "MinTimeSinceLastVipPurchase", 54 },
		{ "TutorialUpgradeWeaponAfterGames", 55 },
		{ "TutorialUpgradeUnitAfterGames", 56 },
		{ "StartingWarbucks", 57 },
		{ "StartingGold", 58 },
		{ "MaxEnergy", 59 },
		{ "LapsedPlayerInterval3", 60 },
		{ "LapsedPlayerInterval2", 61 },
		{ "LapsedPlayerInterval1", 62 },
		{ "GoldRewardFirstTimeSquad", 63 },
		{ "FacebookLike", 64 },
		{ "TwitterFollow", 65 },
		{ "ShieldRepairTime", 66 },
		{ "TaskReward1Min", 67 },
		{ "TaskReward1Max", 68 },
		{ "TaskReward2Min", 69 },
		{ "TaskReward2Max", 70 },
		{ "TaskReward3Min", 71 },
		{ "TaskReward3Max", 72 },
		{ "DogTagRefillTime", 73 },
		{ "DogTagCap", 74 },
		{ "WarbucksScalingBase", 75 },
		{ "DestroyShieldsInOverTime", 76 },
		{ "RepairShields", 77 },
		{ "FacebookLoginReward", 78 },
		{ "GooglePlayLoginReward", 79 },
		{ "RateAppReward", 80 },
		{ "MaxPingToConnectRegion", 81 },
		{ "RateAppMaxShow", 82 },
		{ "NotificationAllowReward", 83 },
		{ "NotificationAllowWinsNeed", 84 },
		{ "NotificationAllowHoursBetween", 85 },
		{ "NotificationAllowMaxShow", 86 },
		{ "ServerRentalSaleMin", 87 },
		{ "ServerRentalSaleMax", 88 },
		{ "ServerRentalVisualProbability", 89 },
		{ "ServerRentalWeaponProbability", 90 },
		{ "ServerRentalUnitProbability", 91 },
		{ "ServerRentalUnitCanLockedCount", 92 },
		{ "ServerRentalWeaponCanLockedCount", 93 },
		{ "ServerRentalMaxUnits", 94 },
		{ "ServerRentalMaxWeapons", 95 },
		{ "ServerRentalMaxLockedFor", 96 },
		{ "ServerRentalPowerbandDelayMin", 97 },
		{ "ServerRentalPowerbandDelayMax", 98 },
		{ "ServerRentalWoUDelayMin", 99 },
		{ "ServerRentalWoUDelayMax", 100 },
		{ "NameChangeReminderGamesAfterFbLogin", 101 },
		{ "FacebookLoginReminder1After", 102 },
		{ "FacebookLoginReminder2After", 103 },
		{ "FacebookLoginReminder3After", 104 },
		{ "TimeBetweenVIPreminderShown", 105 },
		{ "TimeBetweenWeaponUpgradeReminderShown", 106 },
		{ "TimeBetweenUnitUpgradeReminderShown", 107 },
		{ "TimeBetweenSquadReminderShown", 108 },
		{ "WarcardAdCount", 109 },
		{ "WarcardAdInterval", 110 },
		{ "DogtagAdCount", 111 },
		{ "DogtagAdInterval", 112 },
		{ "GoldenSuitcaseAdCount", 113 },
		{ "GoldenSuitcaseAdInterval", 114 },
		{ "GoldenSuitcaseAdTimeBetweenMinutes", 115 },
		{ "GoldenSuitcase_VIPRewardChance", 116 },
		{ "GoldenSuitcase_VIPRewardDuration", 117 },
		{ "GoldenSuitcase_PowerbandRewardChance", 118 },
		{ "GoldenSuitcase_PowerbandRewardDuration", 119 },
		{ "GoldenSuitcase_GoldRewardChance", 120 },
		{ "GoldenSuitcase_CardRewardChance", 121 },
		{ "GoldenSuitcase_WBRewardChance", 122 },
		{ "GoldenSuitcase_WBRewardMin", 123 },
		{ "GoldenSuitcase_WBRewardMax", 124 },
		{ "GoldenSuitcase_GoldRewardMin", 125 },
		{ "GoldenSuitcase_GoldRewardMax", 126 },
		{ "ServerRentalMaxLockedForWeapon", 127 },
		{ "ArmyPowerWeaponConstant", 128 },
		{ "EarlyPlayerLevelProgress", 129 },
		{ "UnitCategoriesReminderAfterGames", 130 },
		{ "SquadMedalWeight1", 131 },
		{ "SquadMedalWeight2", 132 },
		{ "SquadMedalWeight3", 133 },
		{ "SquadMedalWeight4", 134 },
		{ "SquadMedalWeight5", 135 },
		{ "SquadMedalWeight6", 136 },
		{ "LeaguePlacementMatches", 137 },
		{ "SendUnitsCoolDown", 138 },
		{ "CardWithdrawTimer", 139 },
		{ "SquadWarsReminder", 140 },
		{ "LeagueReminder", 141 },
		{ "MatchmakingEasyBotTillLevel", 142 },
		{ "EasyBotHpCoeficient", 143 },
		{ "MoneyPackRunningOutSeconds", 144 },
		{ "RateAppShowAfterBattles", 145 },
		{ "RateAppShowAfterLevel", 146 },
		{ "RateAppShowSecondTimeAfterLevel", 147 },
		{ "StarterPackRunningOutSeconds", 148 },
		{ "NotEnoughPlayersForPlayerLeague", 149 },
		{ "CardCraftTimeSilver", 150 },
		{ "CardCraftTimeGold", 151 },
		{ "SquadWarsLowerSquadLimit", 152 },
		{ "FullAutoDeployTime", 153 },
		{ "SemiAutoDeployTime", 154 },
		{ "SemiAutoDeployEnergy", 155 },
		{ "WarBucksCreateSquadPrice", 156 },
		{ "SecondRenameGoldCost", 157 },
		{ "LootboxAfterBattles", 158 },
		{ "LootboxesAdCount", 159 },
		{ "LootboxesAdInterval", 160 },
		{ "ChatMessagesLimit", 161 },
		{ "GoldenSuitcase_LootboxRewardChance", 162 },
		{ "GoldenSuitcase_LootboxRewardMin", 163 },
		{ "GoldenSuitcase_LootboxRewardMax", 164 },
		{ "GoldenSuitcaseUnlockLevel", 165 },
		{ "SquadWarsLowSquadsTier2Reward", 166 },
		{ "SquadWarsLowSquadsTier3Reward", 167 },
		{ "SquadWarsLowSquadsTier4Reward", 168 },
		{ "SquadWarsLowSquadsTier5Reward", 169 },
		{ "SquadWarsLowSquadsNoReward", 170 },
		{ "SquadWarsTier3Percentage", 171 },
		{ "SquadWarsTier4Percentage", 172 },
		{ "SquadWarsTier5Percentage", 173 },
		{ "SquadWarsNoRewardPercentage", 174 },
		{ "GetAllMessagesTimer", 175 },
		{ "LootboxesUnlockLevel", 176 },
		{ "MaxPingForChallenge", 177 },
		{ "InstantBattleEnabled", 178 },
		{ "InstantBattleUnlockLevel", 179 },
		{ "InstantBattleMax", 180 },
		{ "InstantBattleReload", 181 },
		{ "InstantBattleCostMin", 182 },
		{ "InstantBattleCostMax", 183 },
		{ "TicketsToGold", 184 },
		{ "GoldenSuitcaseTicketsChance", 185 },
		{ "GoldenSuitcaseTicketsMin", 186 },
		{ "GoldenSuitcaseTicketsMax", 187 },
		{ "PartToScrapsSell", 188 },
		{ "PartToScrapsUpgrade", 189 },
		{ "GoldenSuitcaseScrapsChance", 190 },
		{ "GoldenSuitcaseScrapsMin", 191 },
		{ "GoldenSuitcaseScrapsMax", 192 },
		{ "ChatTempLegacyVersion13", 193 }
	};

	public List<ConstantsRow> Rows = new List<ConstantsRow>();

	public override bool haveDictionary => true;

	public override int getColumnCount => 2;

	public override int GetRowIndex(string rowID)
	{
		if (namesToIndex.ContainsKey(rowID))
		{
			return namesToIndex[rowID];
		}
		return -1;
	}

	public override void AddRowGeneric(List<string> input)
	{
		Rows.Add(new ConstantsRow(input[0], input[1], input[2]));
	}

	public override int AddBlanckRowGeneric(string rowId)
	{
		if (namesToIndex.ContainsKey(rowId))
		{
			return -1;
		}
		namesToIndex.Add(rowId, Rows.Count);
		Rows.Add(new ConstantsRow());
		mRows = null;
		return namesToIndex[rowId];
	}

	public override int AddRowGenericRealyAdd(List<string> input)
	{
		if (namesToIndex.ContainsKey(input[0]))
		{
			return -1;
		}
		if (input.Count < 3)
		{
			return -3;
		}
		namesToIndex.Add(input[0], Rows.Count);
		Rows.Add(new ConstantsRow(input[0], input[1], input[2]));
		mRows = null;
		return namesToIndex[input[0]];
	}

	public override void CheckRows(List<string> rowIds)
	{
		int num = rowNames.Length;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in namesToIndex)
		{
			if (item.Value >= num && !rowIds.Contains(item.Key))
			{
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			int num2 = namesToIndex[item2];
			if (num2 == Rows.Count - 1)
			{
				namesToIndex.Remove(item2);
				Rows.RemoveAt(Rows.Count - 1);
				continue;
			}
			int num3 = Rows.Count - 1;
			string key = string.Empty;
			foreach (KeyValuePair<string, int> item3 in namesToIndex)
			{
				if (item3.Value == num3)
				{
					key = item3.Key;
					break;
				}
			}
			namesToIndex[key] = num2;
			Rows[num2] = Rows[num3];
			namesToIndex.Remove(item2);
			Rows.RemoveAt(Rows.Count - 1);
		}
		mRows = null;
	}

	public override void Clear()
	{
		Rows.Clear();
	}

	public IGoogle2uRow GetGenRow(string in_RowString)
	{
		IGoogle2uRow result = null;
		try
		{
			result = Rows[(int)Enum.Parse(typeof(rowIds), in_RowString)];
		}
		catch (ArgumentException)
		{
			Debug.LogError(in_RowString + " is not a member of the rowIds enumeration.");
		}
		return result;
	}

	public IGoogle2uRow GetGenRow(rowIds in_RowID)
	{
		IGoogle2uRow result = null;
		try
		{
			result = Rows[(int)in_RowID];
		}
		catch (KeyNotFoundException ex)
		{
			Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
		}
		return result;
	}

	public ConstantsRow GetRow(rowIds in_RowID)
	{
		ConstantsRow result = null;
		try
		{
			result = Rows[(int)in_RowID];
		}
		catch (KeyNotFoundException ex)
		{
			Debug.LogError(string.Concat(in_RowID, " not found: ", ex.Message));
		}
		return result;
	}

	public ConstantsRow GetRow(string in_RowString)
	{
		ConstantsRow result = null;
		if (namesToIndex.ContainsKey(in_RowString))
		{
			result = Rows[namesToIndex[in_RowString]];
		}
		else
		{
			Debug.LogError(in_RowString + " is not stored in translate dictionary.");
		}
		return result;
	}
}
}

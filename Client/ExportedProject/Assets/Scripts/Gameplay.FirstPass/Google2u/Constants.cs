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
			LastDayInappMultiplier,
			HitShakeFrequency,
			DogTagSubscriptionRefillTime,
			UpgradesSubscriptionMultiplierTime,
			VideoFeedIOSInAppVideo,
			VideoFeedAndroidInAppVideo,
			ChampionLeagueTopPlayersForReward,
			ChampionLeagueReward1,
			ChampionLeagueReward2,
			ChampionLeagueReward10
		}

		public string[] rowNames = new string[196]
		{
			"SinglePlayerScoreStreakRatio", "MultiPlayerScoreStreakRatio", "DeathMatchTime", "ShieldRespawnRatePerSec", "GoldCardRarity", "SilverCardRarity", "BronzePackBronzeCards", "BronzePackGuaranteedCardsType", "BronzePackMaxRarityCardsType", "SilverPackSilverCards",
			"SilverPackGuaranteedCardsType", "SilverPackMaxRarityCardsType", "GoldPackGoldCards", "GoldPackGuaranteedCardsType", "GoldPackMaxRarityCardsType", "CardsInPack", "GoldCoefficient", "GoldExpCoefficient", "WinstreakInterval", "WinstreakReward1",
			"WinstreakReward2", "WinstreakReward3", "WinstreakReward4", "WinstreakReward5", "WinstreakReward6", "WinstreakReward7", "WinstreakReward8", "WinstreakReward9", "WinstreakReward10", "VipWarbucksMultiplier",
			"VipExperienceMultiplier", "FriendDamageCoeficient", "VipGoldCardRewardChance", "WarpathUnlockLevel", "JoinSquadUnlockLevel", "CreateSquadUnlockLevel", "GoldCardRarityEarly", "SilverCardRarityEarly", "GoldCrateLowLevelProbability", "GoldCrateLowLevelGoldMin",
			"GoldCrateLowLevelGoldMax", "ArmoredVehicleShotCoeficient", "UnitToShieldCoef", "PlayerExplosiveCoef", "PlayerExplosiveOvertimeCoef", "ShieldExplosionCoef", "VipGoldMultiplier", "VipDogtags", "VipRunningOutSeconds", "MinTimeSinceLastWeaponUpgrade",
			"MinTimeSinceLastUnitUpgrade", "MinLevelForCardsReminder", "LowNumberOfCards", "MinLevelForSquadJoinOrCreateReminder", "MinTimeSinceLastVipPurchase", "TutorialUpgradeWeaponAfterGames", "TutorialUpgradeUnitAfterGames", "StartingWarbucks", "StartingGold", "MaxEnergy",
			"LapsedPlayerInterval3", "LapsedPlayerInterval2", "LapsedPlayerInterval1", "GoldRewardFirstTimeSquad", "FacebookLike", "TwitterFollow", "ShieldRepairTime", "DogTagRefillTime", "DogTagCap", "WarbucksScalingBase",
			"DestroyShieldsInOverTime", "RepairShields", "FacebookLoginReward", "GooglePlayLoginReward", "RateAppReward", "MaxPingToConnectRegion", "RateAppMaxShow", "NotificationAllowReward", "NotificationAllowWinsNeed", "NotificationAllowHoursBetween",
			"NotificationAllowMaxShow", "ServerRentalSaleMin", "ServerRentalSaleMax", "ServerRentalVisualProbability", "ServerRentalWeaponProbability", "ServerRentalUnitProbability", "ServerRentalUnitCanLockedCount", "ServerRentalWeaponCanLockedCount", "ServerRentalMaxUnits", "ServerRentalMaxWeapons",
			"ServerRentalMaxLockedFor", "ServerRentalPowerbandDelayMin", "ServerRentalPowerbandDelayMax", "ServerRentalWoUDelayMin", "ServerRentalWoUDelayMax", "NameChangeReminderGamesAfterFbLogin", "FacebookLoginReminder1After", "FacebookLoginReminder2After", "FacebookLoginReminder3After", "TimeBetweenVIPreminderShown",
			"TimeBetweenWeaponUpgradeReminderShown", "TimeBetweenUnitUpgradeReminderShown", "TimeBetweenSquadReminderShown", "WarcardAdCount", "WarcardAdInterval", "DogtagAdCount", "DogtagAdInterval", "GoldenSuitcaseAdCount", "GoldenSuitcaseAdInterval", "GoldenSuitcaseAdTimeBetweenMinutes",
			"GoldenSuitcase_VIPRewardChance", "GoldenSuitcase_VIPRewardDuration", "GoldenSuitcase_PowerbandRewardChance", "GoldenSuitcase_PowerbandRewardDuration", "GoldenSuitcase_GoldRewardChance", "GoldenSuitcase_CardRewardChance", "GoldenSuitcase_WBRewardChance", "GoldenSuitcase_WBRewardMin", "GoldenSuitcase_WBRewardMax", "GoldenSuitcase_GoldRewardMin",
			"GoldenSuitcase_GoldRewardMax", "ServerRentalMaxLockedForWeapon", "ArmyPowerWeaponConstant", "EarlyPlayerLevelProgress", "UnitCategoriesReminderAfterGames", "SquadMedalWeight1", "SquadMedalWeight2", "SquadMedalWeight3", "SquadMedalWeight4", "SquadMedalWeight5",
			"SquadMedalWeight6", "LeaguePlacementMatches", "SendUnitsCoolDown", "CardWithdrawTimer", "SquadWarsReminder", "LeagueReminder", "MatchmakingEasyBotTillLevel", "EasyBotHpCoeficient", "MoneyPackRunningOutSeconds", "RateAppShowAfterBattles",
			"RateAppShowAfterLevel", "RateAppShowSecondTimeAfterLevel", "StarterPackRunningOutSeconds", "NotEnoughPlayersForPlayerLeague", "CardCraftTimeSilver", "CardCraftTimeGold", "SquadWarsLowerSquadLimit", "FullAutoDeployTime", "SemiAutoDeployTime", "SemiAutoDeployEnergy",
			"WarBucksCreateSquadPrice", "SecondRenameGoldCost", "LootboxAfterBattles", "LootboxesAdCount", "LootboxesAdInterval", "ChatMessagesLimit", "GoldenSuitcase_LootboxRewardChance", "GoldenSuitcase_LootboxRewardMin", "GoldenSuitcase_LootboxRewardMax", "GoldenSuitcaseUnlockLevel",
			"SquadWarsLowSquadsTier2Reward", "SquadWarsLowSquadsTier3Reward", "SquadWarsLowSquadsTier4Reward", "SquadWarsLowSquadsTier5Reward", "SquadWarsLowSquadsNoReward", "SquadWarsTier3Percentage", "SquadWarsTier4Percentage", "SquadWarsTier5Percentage", "SquadWarsNoRewardPercentage", "GetAllMessagesTimer",
			"LootboxesUnlockLevel", "MaxPingForChallenge", "InstantBattleUnlockLevel", "InstantBattleMax", "InstantBattleReload", "InstantBattleCostMin", "InstantBattleCostMax", "TicketsToGold", "GoldenSuitcaseTicketsChance", "GoldenSuitcaseTicketsMin",
			"GoldenSuitcaseTicketsMax", "PartToScrapsSell", "PartToScrapsUpgrade", "GoldenSuitcaseScrapsChance", "GoldenSuitcaseScrapsMin", "GoldenSuitcaseScrapsMax", "LastDayInappMultiplier", "HitShakeFrequency", "DogTagSubscriptionRefillTime", "UpgradesSubscriptionMultiplierTime",
			"VideoFeedIOSInAppVideo", "VideoFeedAndroidInAppVideo", "ChampionLeagueTopPlayersForReward", "ChampionLeagueReward1", "ChampionLeagueReward2", "ChampionLeagueReward10"
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
			{ "DogTagRefillTime", 67 },
			{ "DogTagCap", 68 },
			{ "WarbucksScalingBase", 69 },
			{ "DestroyShieldsInOverTime", 70 },
			{ "RepairShields", 71 },
			{ "FacebookLoginReward", 72 },
			{ "GooglePlayLoginReward", 73 },
			{ "RateAppReward", 74 },
			{ "MaxPingToConnectRegion", 75 },
			{ "RateAppMaxShow", 76 },
			{ "NotificationAllowReward", 77 },
			{ "NotificationAllowWinsNeed", 78 },
			{ "NotificationAllowHoursBetween", 79 },
			{ "NotificationAllowMaxShow", 80 },
			{ "ServerRentalSaleMin", 81 },
			{ "ServerRentalSaleMax", 82 },
			{ "ServerRentalVisualProbability", 83 },
			{ "ServerRentalWeaponProbability", 84 },
			{ "ServerRentalUnitProbability", 85 },
			{ "ServerRentalUnitCanLockedCount", 86 },
			{ "ServerRentalWeaponCanLockedCount", 87 },
			{ "ServerRentalMaxUnits", 88 },
			{ "ServerRentalMaxWeapons", 89 },
			{ "ServerRentalMaxLockedFor", 90 },
			{ "ServerRentalPowerbandDelayMin", 91 },
			{ "ServerRentalPowerbandDelayMax", 92 },
			{ "ServerRentalWoUDelayMin", 93 },
			{ "ServerRentalWoUDelayMax", 94 },
			{ "NameChangeReminderGamesAfterFbLogin", 95 },
			{ "FacebookLoginReminder1After", 96 },
			{ "FacebookLoginReminder2After", 97 },
			{ "FacebookLoginReminder3After", 98 },
			{ "TimeBetweenVIPreminderShown", 99 },
			{ "TimeBetweenWeaponUpgradeReminderShown", 100 },
			{ "TimeBetweenUnitUpgradeReminderShown", 101 },
			{ "TimeBetweenSquadReminderShown", 102 },
			{ "WarcardAdCount", 103 },
			{ "WarcardAdInterval", 104 },
			{ "DogtagAdCount", 105 },
			{ "DogtagAdInterval", 106 },
			{ "GoldenSuitcaseAdCount", 107 },
			{ "GoldenSuitcaseAdInterval", 108 },
			{ "GoldenSuitcaseAdTimeBetweenMinutes", 109 },
			{ "GoldenSuitcase_VIPRewardChance", 110 },
			{ "GoldenSuitcase_VIPRewardDuration", 111 },
			{ "GoldenSuitcase_PowerbandRewardChance", 112 },
			{ "GoldenSuitcase_PowerbandRewardDuration", 113 },
			{ "GoldenSuitcase_GoldRewardChance", 114 },
			{ "GoldenSuitcase_CardRewardChance", 115 },
			{ "GoldenSuitcase_WBRewardChance", 116 },
			{ "GoldenSuitcase_WBRewardMin", 117 },
			{ "GoldenSuitcase_WBRewardMax", 118 },
			{ "GoldenSuitcase_GoldRewardMin", 119 },
			{ "GoldenSuitcase_GoldRewardMax", 120 },
			{ "ServerRentalMaxLockedForWeapon", 121 },
			{ "ArmyPowerWeaponConstant", 122 },
			{ "EarlyPlayerLevelProgress", 123 },
			{ "UnitCategoriesReminderAfterGames", 124 },
			{ "SquadMedalWeight1", 125 },
			{ "SquadMedalWeight2", 126 },
			{ "SquadMedalWeight3", 127 },
			{ "SquadMedalWeight4", 128 },
			{ "SquadMedalWeight5", 129 },
			{ "SquadMedalWeight6", 130 },
			{ "LeaguePlacementMatches", 131 },
			{ "SendUnitsCoolDown", 132 },
			{ "CardWithdrawTimer", 133 },
			{ "SquadWarsReminder", 134 },
			{ "LeagueReminder", 135 },
			{ "MatchmakingEasyBotTillLevel", 136 },
			{ "EasyBotHpCoeficient", 137 },
			{ "MoneyPackRunningOutSeconds", 138 },
			{ "RateAppShowAfterBattles", 139 },
			{ "RateAppShowAfterLevel", 140 },
			{ "RateAppShowSecondTimeAfterLevel", 141 },
			{ "StarterPackRunningOutSeconds", 142 },
			{ "NotEnoughPlayersForPlayerLeague", 143 },
			{ "CardCraftTimeSilver", 144 },
			{ "CardCraftTimeGold", 145 },
			{ "SquadWarsLowerSquadLimit", 146 },
			{ "FullAutoDeployTime", 147 },
			{ "SemiAutoDeployTime", 148 },
			{ "SemiAutoDeployEnergy", 149 },
			{ "WarBucksCreateSquadPrice", 150 },
			{ "SecondRenameGoldCost", 151 },
			{ "LootboxAfterBattles", 152 },
			{ "LootboxesAdCount", 153 },
			{ "LootboxesAdInterval", 154 },
			{ "ChatMessagesLimit", 155 },
			{ "GoldenSuitcase_LootboxRewardChance", 156 },
			{ "GoldenSuitcase_LootboxRewardMin", 157 },
			{ "GoldenSuitcase_LootboxRewardMax", 158 },
			{ "GoldenSuitcaseUnlockLevel", 159 },
			{ "SquadWarsLowSquadsTier2Reward", 160 },
			{ "SquadWarsLowSquadsTier3Reward", 161 },
			{ "SquadWarsLowSquadsTier4Reward", 162 },
			{ "SquadWarsLowSquadsTier5Reward", 163 },
			{ "SquadWarsLowSquadsNoReward", 164 },
			{ "SquadWarsTier3Percentage", 165 },
			{ "SquadWarsTier4Percentage", 166 },
			{ "SquadWarsTier5Percentage", 167 },
			{ "SquadWarsNoRewardPercentage", 168 },
			{ "GetAllMessagesTimer", 169 },
			{ "LootboxesUnlockLevel", 170 },
			{ "MaxPingForChallenge", 171 },
			{ "InstantBattleUnlockLevel", 172 },
			{ "InstantBattleMax", 173 },
			{ "InstantBattleReload", 174 },
			{ "InstantBattleCostMin", 175 },
			{ "InstantBattleCostMax", 176 },
			{ "TicketsToGold", 177 },
			{ "GoldenSuitcaseTicketsChance", 178 },
			{ "GoldenSuitcaseTicketsMin", 179 },
			{ "GoldenSuitcaseTicketsMax", 180 },
			{ "PartToScrapsSell", 181 },
			{ "PartToScrapsUpgrade", 182 },
			{ "GoldenSuitcaseScrapsChance", 183 },
			{ "GoldenSuitcaseScrapsMin", 184 },
			{ "GoldenSuitcaseScrapsMax", 185 },
			{ "LastDayInappMultiplier", 186 },
			{ "HitShakeFrequency", 187 },
			{ "DogTagSubscriptionRefillTime", 188 },
			{ "UpgradesSubscriptionMultiplierTime", 189 },
			{ "VideoFeedIOSInAppVideo", 190 },
			{ "VideoFeedAndroidInAppVideo", 191 },
			{ "ChampionLeagueTopPlayersForReward", 192 },
			{ "ChampionLeagueReward1", 193 },
			{ "ChampionLeagueReward2", 194 },
			{ "ChampionLeagueReward10", 195 }
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

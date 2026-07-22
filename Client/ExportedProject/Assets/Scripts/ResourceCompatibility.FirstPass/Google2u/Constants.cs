using System.Collections.Generic;

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
			VipPrestigeExperienceMultiplier,
			VipPrestigeDailyLimitMultiplier,
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
			GoldCrateMaxInOneMatch,
			GoldCrateMaxInOneDay,
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
			ShieldRepairTimeDelay,
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
			ServerRentalMaxLockedForWeapon,
			ServerRentalDialogAfter,
			ServerRentalRentDuration,
			ServerRentalOfferDuration,
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
			MechanicalUnitsGlobalCooldown,
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
			ChampionLeagueReward10,
			PlayerRankFactor,
			PlayerWeaponsFactor,
			PlayerUnitsFactor,
			MedalsMinReward,
			MedalsMaxReward,
			MedalsMinPenalty,
			MedalsMaxPenalty,
			MedalsBaseReward,
			MedalsBasePenalty,
			ServerRentalExtraTime,
			MaxVideoFeedsPerDay,
			GoldContextPriceReduction,
			MainMenuHeaderReminderTime,
			BecameRecruitReward,
			CardCraftTimeFromGold,
			MaximumNumberOfBuddyCards,
			ShowingOfFullPiggyBank,
			PiggyUnlockRank,
			MaxAdsShowed,
			PiggyBankDuration,
			CommanderMaxRecruits,
			AreTriggersEnabled,
			AugmentationsUnlockLevel,
			ShouldSubtractSquadPoints,
			NumOfVictoriesForPN,
			RankNeededForPNDialog,
			MissedSessionNotificationDividerOffset,
			MissedSessionNotificationTimeOffset,
			CarouselRemainingTime,
			CarouselRegularSwitchTime,
			CarouselSecondarySwitchTime,
			AdBoosterUnitTime,
			CooldownBetweenAdBoosters,
			DropCratesStartingLevel,
			BoosterNotificationWaitTime,
			BlackMarketVariantSalePercent,
			CarouselMaxBanners,
			BlackMarketStoreUnlockLevel,
			WeaponAugsUnlockLevel,
			TransitionRewardTier,
			DisableInapps,
			SWExtraPaidPercentage,
			CovertUnitUnlockLevel,
			SuperchargedUnlockLevel,
			ShotgunMaxDistance,
			LightMachinegunOffsetCoef,
			LightMachinegunDistance
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<ConstantsRow> Rows;

		public override bool haveDictionary => false;

		public override int getColumnCount => 0;

		public override int GetRowIndex(string rowID)
		{
			return 0;
		}

		public override void AddRowGeneric(List<string> input)
		{
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			return 0;
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			return 0;
		}

		public override void CheckRows(List<string> rowIds)
		{
		}

		public override void Clear()
		{
		}

		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			return null;
		}

		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			return null;
		}

		public ConstantsRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public ConstantsRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}

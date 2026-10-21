using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Persistence.Battles.Settlement;
using War.Persistence.Legacy.State;
using War.Protocol;

namespace War.Backend.Features.Battle.Settlement;

/// <summary>Derives rewards only from the accepted host outcome and allocation-frozen offline policy.</summary>
public static class BattleSettlementCalculator
{
    public static BattleSettlementPlan Calculate(BattleSettlementContext context, DateTime nowUtc)
    {
        BattleTerminalEvidenceValidator.ValidateSnapshot(context.Terminal);
        PvpBonusCurrencyManifestValidator.Validate(context.Terminal, context.Manifest);
        BattleSettlementEligibility.Validate(context.Terminal, context.Manifest);
        if (!context.Terminal.RewardEligible || nowUtc.Kind != DateTimeKind.Utc ||
            nowUtc < DateTime.UnixEpoch || nowUtc > DateTime.UnixEpoch.AddSeconds(int.MaxValue))
        {
            throw new InvalidDataException("Battle has no eligible reward policy or valid application time.");
        }
        BattleRewardPolicy policy = BattleRewardPolicy.Parse(context.Manifest.SettlementPolicyJson!);
        int now = (int)new DateTimeOffset(nowUtc).ToUnixTimeSeconds();
        var calculation = new Calculation(context, policy, policy.CreateProgression(), now);
        return new(context.Manifest.SettlementPolicyRevision!,
            Array.AsReadOnly(context.Players.Select(player => CalculatePlayer(calculation, player)).ToArray()));
    }

    private static BattleSettlementPlayerChange CalculatePlayer(Calculation calculation, LegacyPlayerDocument player)
    {
        LegacyPlayerEconomyAuthority.Validate(player);
        BattlePlayerState host = calculation.Context.Terminal.Players.Single(row => row.PlayerId == player.Id);
        bool won = calculation.Context.Terminal.WinnerPlayerId == player.Id;
        bool vip = player.Vip > calculation.Now;
        BattleRewardPolicy policy = calculation.Policy;
        if (player.Vip < 0 || player.VipStart < 0 || player.VipStart > calculation.Now ||
            (long)calculation.Now + policy.StreakSeconds > int.MaxValue)
        {
            throw new InvalidDataException("Invalid VIP authority or Client win-streak deadline.");
        }
        BattleWinStreak previous = BattleWinStreak.Read(player, calculation.Now);
        int activeWins = (long)previous.TimeStamp + policy.StreakSeconds > calculation.Now ? previous.WinCount : 0;
        var streak = won ? new BattleWinStreak(Math.Min(9, activeWins + 1), calculation.Now) : new BattleWinStreak(0, 0);
        int baseWarBucks = won ? policy.WinWarBucks : policy.LoseWarBucks;
        int streakWarBucks = won ? policy.StreakRewards[activeWins] : 0;
        int extraWarBucks = SumQuotes(calculation.Context.Terminal, player.Id, "warbucks");
        int gold = SumQuotes(calculation.Context.Terminal, player.Id, "gold");
        int timeXp = RemainingTimeXp(calculation, won);
        int xp = checked(RewardInt32.Scale(host.Score, vip ? policy.VipExperienceMultiplier : 1) +
            RewardInt32.Scale(timeXp, vip ? policy.VipExperienceMultiplier : 1));
        BattleRankAdvance advancement = calculation.Progression.Apply(
            new(player.Level, player.LevelExperience, player.Experience), xp);
        extraWarBucks = checked(extraWarBucks + advancement.WarBucksReward);
        gold = checked(gold + advancement.GoldReward);
        int warBucks = checked(RewardInt32.Scale(checked(baseWarBucks + extraWarBucks),
            vip ? policy.VipWarBucksMultiplier : 1) +
            RewardInt32.Scale(streakWarBucks, vip ? policy.VipWarBucksMultiplier : 1));
        int skill = Medals(player.Skill, won, policy);
        int balance = Medals(player.MedalsBalance, won, policy);
        var next = new BattleSettlementPlayerChange
        {
            PlayerId = player.Id, Gold = RewardBalance.Add(player.Gold,
                RewardInt32.Scale(gold, vip ? policy.VipGoldMultiplier : 1)),
            WarBucks = RewardBalance.Add(player.WarBucks, warBucks), Level = advancement.Rank.Level,
            LevelExperience = advancement.Rank.LevelExperience, Experience = advancement.Rank.Experience,
            ArmyPower = checked(player.ArmyPower + advancement.RankPowerIncrease), Skill = skill, MedalsBalance = balance,
            PlacementMatchesRequired = player.PlacementMatchesRequired,
            BattlesLostInRow = won ? 0 : checked(player.BattlesLostInRow + 1),
            WinStreakJson = JsonSerializer.Serialize(streak), ResponseJson = ""
        };
        JsonObject reward = CreateReward(new RewardParts
        {
            Xp = host.Score, TimeXp = timeXp, WarBucks = baseWarBucks, ExtraWarBucks = extraWarBucks,
            StreakWarBucks = streakWarBucks, Gold = gold, Vip = vip
        });
        JsonObject response = CreateResponse(next, streak, reward, calculation.Now);
        if (advancement.LevelsGained > 0)
        {
            response["Level"] = next.Level;
        }
        return next with { ResponseJson = response.ToJsonString() };
    }

    private static JsonObject CreateReward(RewardParts parts) => new()
    {
        ["Warbucks"] = new JsonObject { ["BattleRewards"] = parts.WarBucks, ["ExtraRewards"] = parts.ExtraWarBucks,
            ["Winstreak"] = parts.StreakWarBucks, ["League"] = 0 },
        ["Xp"] = new JsonObject { ["BattleRewards"] = parts.Xp, ["ExtraRewards"] = 0,
            ["Winstreak"] = 0, ["Time"] = parts.TimeXp },
        ["GameGold"] = new JsonObject { ["BattleRewards"] = parts.Gold, ["League"] = 0 },
        ["IsVip"] = parts.Vip
    };

    private static JsonObject CreateResponse(
        BattleSettlementPlayerChange next, BattleWinStreak streak, JsonObject reward, int now) => new()
    {
        ["Result"] = (int)DatabaseResult.Success, ["GameReward"] = reward, ["LevelExperience"] = next.LevelExperience,
        ["Skill"] = next.Skill, ["MedalsBalance"] = next.MedalsBalance,
        ["PlacementMatchesRequired"] = next.PlacementMatchesRequired,
        ["WinCount"] = streak.WinCount, ["TimeStamp"] = streak.TimeStamp, ["Time"] = now
    };

    private static int RemainingTimeXp(Calculation calculation, bool won)
    {
        if (!won)
        {
            return 0;
        }
        long elapsed = (long)(calculation.Context.Terminal.PerformanceDurationTicks / MatchManifest.TickRate);
        int remaining = (int)Math.Clamp(calculation.Context.Manifest.DurationSeconds - elapsed, 0, 999);
        return checked(remaining * calculation.Policy.TimeXpPerSecond);
    }

    private static int Medals(int current, bool won, BattleRewardPolicy policy) =>
        won ? checked(current + policy.WinMedals) : Math.Max(0, current - policy.LoseMedals);

    private static int SumQuotes(MatchSnapshot terminal, string playerId, string currency)
    {
        long total = terminal.PvpCurrencyQuotes.Where(quote => quote.RecipientPlayerId == playerId &&
            quote.Currency == currency).Sum(quote => (long)quote.Amount);
        if (total > int.MaxValue)
        {
            throw new InvalidDataException("Battle currency quotes exceed the Client reward domain.");
        }
        return (int)total;
    }

    private sealed record Calculation(BattleSettlementContext Context, BattleRewardPolicy Policy,
        BattleRankProgression Progression, int Now);

    private sealed record RewardParts
    {
        internal int Xp { get; init; }
        internal int TimeXp { get; init; }
        internal int WarBucks { get; init; }
        internal int ExtraWarBucks { get; init; }
        internal int StreakWarBucks { get; init; }
        internal int Gold { get; init; }
        internal bool Vip { get; init; }
    }
}

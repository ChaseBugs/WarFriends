using System.Text.Json.Nodes;
using War.Backend.Features.Battle.Settlement;
using War.Persistence;
using War.Persistence.Legacy.Progression;
using War.Persistence.Legacy.State;

namespace War.Backend.Legacy.Progression;

/// <summary>Owner-requested local-progress import. This is not a Worker-verified PvP result.</summary>
public sealed class OfflineBotSyncService(LegacyPlayerStore players, BattleRewardPolicy policy)
{
    private readonly BattleRankProgression _progression = policy.CreateProgression();
    public JsonObject DescribePolicy() => new()
    {
        ["WinWarBucks"] = policy.WinWarBucks, ["LoseWarBucks"] = policy.LoseWarBucks,
        ["MaximumExperience"] = 100_000, ["MaximumPendingBattles"] = 100
    };

    public Task<LegacyPlayerDocument> MergeAsync(LegacyPlayerDocument player, OfflineBotJournal journal,
        CancellationToken token) => players.MergeOfflineBotsAsync(player, journal, Apply, token);

    private void Apply(LegacyPlayerDocument player, OfflineBotOutcome battle)
    {
        // The owner requested merging locally played bot progression. Outcomes are
        // device assertions; currency amounts and rank thresholds remain server policy.
        // They never enter ranked medals, leagues, squads or Worker result receipts.
        BattleRankAdvance advancement = _progression.Apply(
            new BattleRankSnapshot(player.Level, player.LevelExperience, player.Experience), battle.Experience);
        int reward = battle.EndReason is 2 or 3 ? policy.WinWarBucks : policy.LoseWarBucks;
        player.WarBucks = RewardBalance.Add(player.WarBucks,
            checked(reward + advancement.WarBucksReward + battle.ExtraWarBucks));
        player.Gold = RewardBalance.Add(player.Gold, checked(advancement.GoldReward + battle.ExtraGold));
        player.Level = advancement.Rank.Level;
        player.LevelExperience = advancement.Rank.LevelExperience;
        player.Experience = advancement.Rank.Experience;
        player.ArmyPower = checked(player.ArmyPower + advancement.RankPowerIncrease);
    }
}

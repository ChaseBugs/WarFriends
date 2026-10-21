namespace War.Backend.Features.Battle.Settlement;

/// <summary>One computed successor; currency amounts are grants, not replacement balances.</summary>
public sealed record BattleRankAdvance
{
    public required BattleRankSnapshot Rank { get; init; }
    public required int LevelsGained { get; init; }
    public required int GoldReward { get; init; }
    public required int WarBucksReward { get; init; }
    public required int RankPowerIncrease { get; init; }
}

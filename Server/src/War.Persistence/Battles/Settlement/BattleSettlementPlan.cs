namespace War.Persistence.Battles.Settlement;

/// <summary>Policy identity and both participant successors are committed as one indivisible settlement.</summary>
public sealed record BattleSettlementPlan(
    string PolicyRevision, IReadOnlyList<BattleSettlementPlayerChange> Players);

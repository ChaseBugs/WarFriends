namespace War.Persistence.Battles.Settlement;

/// <summary>Authenticated result request; no Client reward or score assertion enters this boundary.</summary>
public sealed record BattleSettlementRequest(string MatchId, string PlayerId, string SessionHash, DateTime NowUtc);

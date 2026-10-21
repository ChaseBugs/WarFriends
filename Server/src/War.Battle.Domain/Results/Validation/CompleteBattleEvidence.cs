namespace War.BattleServer;

public sealed record CompleteBattleEvidence(string MatchId, string ManifestHash,
    BattleStatistics Statistics, ulong DurationTicks, IReadOnlyCollection<string> Ribbons,
    int CardActivations = 0, int ObjectiveCredits = 0);

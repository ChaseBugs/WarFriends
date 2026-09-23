namespace War.BattleServer;

public sealed record CompleteBattleEvidence(string MatchId, string ManifestHash,
    BattleStatistics Statistics, ulong DurationTicks, IReadOnlyCollection<string> Ribbons,
    int CardActivations = 0, int ObjectiveCredits = 0);

public static class CompleteBattleEvidenceValidator
{
    public static CompleteBattleEvidence Validate(CompleteBattleEvidence evidence)
    {
        if (evidence is null || !System.Text.RegularExpressions.Regex.IsMatch(evidence.MatchId ?? "", @"\A[a-zA-Z0-9_-]{1,64}\z") ||
            !System.Text.RegularExpressions.Regex.IsMatch(evidence.ManifestHash ?? "", @"\A[0-9a-f]{64}\z") ||
            evidence.DurationTicks > 10_000_000 || evidence.Ribbons is null || evidence.Ribbons.Count > 128 ||
            evidence.CardActivations < 0 || evidence.CardActivations > 4096 ||
            evidence.ObjectiveCredits < 0 || evidence.ObjectiveCredits > 4096)
            throw new InvalidDataException("Invalid complete battle evidence.");
        BattleStatisticsValidator.Validate(evidence.Statistics);
        var ledger = new BattleRibbonLedger();
        foreach (var ribbon in evidence.Ribbons) ledger.Record(ribbon);
        if (ledger.Count != evidence.Ribbons.Count) throw new InvalidDataException("Duplicate battle ribbon evidence.");
        return evidence;
    }
}

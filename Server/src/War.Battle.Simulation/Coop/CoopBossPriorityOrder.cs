namespace War.BattleServer;

internal sealed record CoopBossPriorityCandidate(
    string EntityId, float Danger, float HealthRatio, bool IsAi,
    bool HasBehaviour);

/// <summary>
/// Orders the fallback opponents in PlayerBot.PickPriorityTarget. The caller
/// still has to check weapon suitability, sight, and movement before firing.
/// </summary>
internal static class CoopBossPriorityOrder
{
    public static IReadOnlyList<CoopBossPriorityCandidate> Sort(
        IReadOnlyList<CoopBossPriorityCandidate> opponents)
    {
        ArgumentNullException.ThrowIfNull(opponents);
        if (opponents.Count > 256)
            throw new InvalidDataException("Too many boss target candidates.");

        var ordered = opponents.ToList();
        var identities = new HashSet<string>(StringComparer.Ordinal);
        foreach (CoopBossPriorityCandidate candidate in ordered)
        {
            if (string.IsNullOrWhiteSpace(candidate.EntityId) ||
                candidate.EntityId.Length > 128 ||
                !identities.Add(candidate.EntityId) ||
                !float.IsFinite(candidate.Danger) || candidate.Danger < 0 ||
                !float.IsFinite(candidate.HealthRatio) ||
                candidate.HealthRatio is < 0 or > 1)
                throw new InvalidDataException("Invalid boss target candidate.");
        }

        // List.Sort is not stable. Keep source order for equal priorities so
        // replay does not depend on the runtime's sorting implementation.
        return ordered.Select((candidate, index) => (candidate, index))
            .OrderByDescending(row => Priority(row.candidate))
            .ThenBy(row => row.index)
            .Select(row => row.candidate)
            .ToArray();
    }

    private static double Priority(CoopBossPriorityCandidate candidate)
    {
        // Non-AI opponents and AI without behaviour follow the configured
        // AI. DestroyableObject.healthRatio is the Client's divisor.
        if (!candidate.IsAi || !candidate.HasBehaviour)
            return double.NegativeInfinity;
        if (candidate.HealthRatio == 0)
            return candidate.Danger > 0 ? double.PositiveInfinity : 0;
        return candidate.Danger / candidate.HealthRatio;
    }
}

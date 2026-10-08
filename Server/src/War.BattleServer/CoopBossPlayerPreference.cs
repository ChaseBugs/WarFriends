namespace War.BattleServer;

internal sealed record CoopBossPlayerCandidate(
    string PlayerId, float HealthRatio, float ShieldHealthRatio,
    bool Walking, bool HasCurrentPoint);

/// <summary>
/// PlayerBot.PickTarget's first player preference pass. The caller supplies
/// active opposing players in source order and host-owned health/shield state.
/// A null result must continue to PickPriorityTarget; it is not a missed shot.
/// </summary>
internal static class CoopBossPlayerPreference
{
    public static string? Choose(
        CoopBossAttackTiming timing,
        IReadOnlyList<CoopBossPlayerCandidate> activePlayers,
        float underPressure, float randomValue)
    {
        ArgumentNullException.ThrowIfNull(timing);
        ArgumentNullException.ThrowIfNull(activePlayers);
        ValidateProbability(underPressure, "under-pressure fraction");
        if (!float.IsFinite(randomValue) || randomValue < 0 || randomValue >= 1)
            throw new InvalidDataException("Boss target draw is outside [0, 1).");
        if (activePlayers.Count is < 1 or > 2)
            throw new InvalidDataException("Boss preference needs one or two active allies.");

        var seenPlayers = new HashSet<string>(StringComparer.Ordinal);
        float cumulative = 0;
        foreach (CoopBossPlayerCandidate player in activePlayers)
        {
            if (!Guid.TryParseExact(player.PlayerId, "N", out Guid parsed) ||
                player.PlayerId != parsed.ToString("N") ||
                !seenPlayers.Add(player.PlayerId))
                throw new InvalidDataException("Boss target has an invalid player identity.");
            ValidateProbability(player.HealthRatio, "player health ratio");
            ValidateProbability(player.ShieldHealthRatio, "shield health ratio");
            if (!player.HasCurrentPoint)
                continue;

            float healthWeight = Math.Clamp(
                MathF.Pow(player.HealthRatio, 0.25f) + 0.1f, 0f, 1f);
            float chance = player.Walking
                ? timing.WalkingOpponentShotProbability
                : timing.OpponentShotProbability;
            chance *= 1f - underPressure;
            chance /= healthWeight;
            if (player.ShieldHealthRatio <= 0)
                chance = timing.OpponentWithoutShieldProbability *
                    (1f - underPressure * 0.2f);
            chance *= 1f / activePlayers.Count;

            // The Client uses strict comparisons, so an exact boundary
            // continues to the later priority-target path.
            if (randomValue > cumulative && randomValue < cumulative + chance)
                return player.PlayerId;
            cumulative += chance;
        }
        return null;
    }

    private static void ValidateProbability(float value, string name)
    {
        if (!float.IsFinite(value) || value < 0 || value > 1)
            throw new InvalidDataException($"Boss {name} is outside [0, 1].");
    }
}

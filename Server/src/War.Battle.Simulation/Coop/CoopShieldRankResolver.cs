namespace War.BattleServer;

/// <summary>
/// Shield.OnGameStarted runs on the scene master and calls
/// PlayerController.GetPlayer(fraction). For the allied fraction that lookup
/// returns the master's current player before searching the shared roster.
/// </summary>
internal static class CoopShieldRankResolver
{
    internal static int AlliedRank(MatchManifest manifest)
    {
        ArgumentNullException.ThrowIfNull(manifest);
        if (manifest.Mode != MatchManifest.CoopMissionMode ||
            string.IsNullOrEmpty(manifest.SceneMasterPlayerId))
            throw new InvalidDataException("Co-op shields need a scene-master player.");

        ParticipantManifest? master = manifest.Players.SingleOrDefault(player =>
            player.PlayerId == manifest.SceneMasterPlayerId);
        if (master?.Fraction != 2 || !master.ShieldLevel.HasValue)
            throw new InvalidDataException("Scene master has no trusted allied shield rank.");
        if (manifest.Players.Any(player => !player.ShieldLevel.HasValue))
            throw new InvalidDataException("Both co-op shield ranks must be allocated.");
        return master.ShieldLevel.Value;
    }

    internal static IReadOnlyList<ShieldMutation> InitialAlliedShields(
        MatchManifest manifest, CoopShieldStateCatalog missions,
        ShieldSourceCatalog policy, int firstCover)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(policy);
        if (firstCover is not (0 or 4) || !manifest.MissionIndex.HasValue)
            throw new InvalidDataException("Co-op shield positions need a source mission.");

        float baseHealth = policy.Health(AlliedRank(manifest));
        IReadOnlyList<CoopShieldStart> overrides =
            missions.ForMission(manifest.MissionIndex.Value).Player;
        var shields = new ShieldMutation[4];
        for (int index = 0; index < shields.Length; index++)
        {
            // Mission.OnAfterGameStarted uses the ordered fraction shields.
            // RefillTo first calculates healthRatio * maxHealthRatio * base HP,
            // then writes maxHealthRatio * base HP. Missing rows stay full.
            CoopShieldStart? start = index < overrides.Count ? overrides[index] : null;
            float maximum = start == null ? baseHealth :
                start.MaxHealthRatio * baseHealth;
            float health = start == null ? baseHealth :
                start.HealthRatio * start.MaxHealthRatio * baseHealth;
            if (!float.IsFinite(maximum) || !float.IsFinite(health) ||
                maximum < 0 || health < 0 || health > maximum * 10)
                throw new InvalidDataException("Co-op shield starting health overflow.");
            shields[index] = new ShieldMutation(firstCover + index, 2,
                health, maximum, Destroyed: false, Revision: 0);
        }
        return Array.AsReadOnly(shields);
    }
}

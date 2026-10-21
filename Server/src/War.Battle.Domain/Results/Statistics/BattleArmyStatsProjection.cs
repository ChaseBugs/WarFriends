using War.Protocol;

namespace War.BattleServer;

/// <summary>Projects source-shaped deployment totals from terminal evidence.</summary>
public static class BattleArmyStatsProjection
{
    /// <summary>Reads owner totals without treating delayed spawns as new deployments.</summary>
    public static IReadOnlyList<BattlePlayerArmyStats> FromPayload(
        byte[] payload,
        string matchId,
        string digest)
    {
        MatchSnapshot terminal = BattleTerminalEvidenceValidator.ValidatePayload(payload, matchId, digest);
        return terminal.Players.Select(ProjectPlayer).ToArray();
    }

    private static BattlePlayerArmyStats ProjectPlayer(BattlePlayerState player)
    {
        BattleArmyUnitStats[] units = player.ArmyUsage
            .GroupBy(row => row.UnitId, StringComparer.Ordinal)
            .Select(group => new BattleArmyUnitStats(
                group.Key,
                checked((int)group.Sum(row => (long)row.Deployments)),
                checked((int)group.Sum(row => (long)row.PlannedSpawns)),
                checked((int)group.Sum(row => (long)row.ConfirmedSpawns))))
            .OrderBy(row => row.UnitId, StringComparer.Ordinal)
            .ToArray();

        int unitsDeployed = checked(units.Sum(unit => unit.AcceptedDeployments));
        int unitsSpawned = checked(units.Sum(unit => unit.PlannedSpawns));
        return new BattlePlayerArmyStats(player.PlayerId, units, unitsDeployed, unitsSpawned);
    }
}

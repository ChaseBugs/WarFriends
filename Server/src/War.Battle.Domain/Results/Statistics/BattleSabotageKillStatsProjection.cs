using War.Protocol;

namespace War.BattleServer;

public static class BattleSabotageKillStatsProjection
{
    private static readonly HashSet<string> MechanicalUnits = new(StringComparer.Ordinal)
    {
        "ID_UNIT-HUMVEE", "ID_UNIT-BUGGY", "ID_UNIT-TRANSPORTER",
        "ID_UNIT-TANK", "ID_UNIT-HELICOPTER", "ID_UNIT-ASSAULTHELI",
        "ID_UNIT-DRONE", "ID_UNIT-MECH"
    };

    internal static bool SupportsVictim(string unitId) =>
        MechanicalUnits.Contains(unitId);

    public static IReadOnlyList<BattleSabotageKillStats> FromPayload(
        byte[] payload, string matchId, string digest)
    {
        MatchSnapshot terminal = BattleTerminalEvidenceValidator.ValidatePayload(
            payload, matchId, digest);
        var result = new List<BattleSabotageKillStats>();
        foreach (var player in terminal.Players)
        {
            var kills = terminal.DirectArmyKills.Where(row =>
                row.AttackerPlayerId == player.PlayerId &&
                row.Cause == "card-sabotage").ToArray();
            result.Add(new BattleSabotageKillStats(player.PlayerId,
                kills.Length, kills.Length, kills.Length,
                kills.Count(row => row.UnitId == "ID_UNIT-TANK")));
        }
        return result;
    }
}

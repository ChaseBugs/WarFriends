using War.Protocol;

namespace War.BattleServer;

public sealed record BattleArmyUnitStats(string UnitId,int AcceptedDeployments,
    int PlannedSpawns,int ConfirmedSpawns);
public sealed record BattlePlayerArmyStats(string PlayerId,IReadOnlyList<BattleArmyUnitStats> Units);

/// <summary>Source-unit-keyed deployment totals from complete terminal evidence.</summary>
public static class BattleArmyStatsProjection
{
    public static IReadOnlyList<BattlePlayerArmyStats> FromPayload(byte[] payload,string matchId,string digest)
    {
        MatchSnapshot terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        return terminal.Players.Select(player=>
        {
            var units=player.ArmyUsage.GroupBy(row=>row.UnitId,StringComparer.Ordinal)
                .Select(group=>new BattleArmyUnitStats(group.Key,
                    checked((int)group.Sum(row=>(long)row.Deployments)),
                    checked((int)group.Sum(row=>(long)row.PlannedSpawns)),
                    checked((int)group.Sum(row=>(long)row.ConfirmedSpawns))))
                .OrderBy(row=>row.UnitId,StringComparer.Ordinal).ToArray();
            return new BattlePlayerArmyStats(player.PlayerId,units);
        }).ToArray();
    }
}

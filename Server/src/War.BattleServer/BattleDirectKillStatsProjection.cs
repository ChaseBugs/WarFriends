namespace War.BattleServer;

/// <summary>Source-shaped subset from direct player-bullet army kills only.</summary>
public sealed record BattleDirectKillStats(string PlayerId,int DirectBulletKills,
    int DirectBulletVehiclesDestroyed,int DirectBulletTanksDestroyed);

public static class BattleDirectKillStatsProjection
{
    private static readonly HashSet<string> Soldiers=new(StringComparer.Ordinal)
    {
        "ID_UNIT-ASSAULT","ID_UNIT-SNIPER","ID_UNIT-ROCKETSOLDIER",
        "ID_UNIT-SHOTGUNNER","ID_UNIT-GRENADIER","ID_UNIT-PARATROOPER",
        "ID_UNIT-SWAT","ID_UNIT-MINIGUNNER","ID_UNIT-ENGINEER",
        "ID_UNIT-MACHINEGUNNER","ID_UNIT-SCIFI","ID_UNIT-FLAMETHROWER",
        "ID_UNIT-COMMANDO","ID_UNIT-GUNSLINGER","ID_UNIT-MORTAR","ID_UNIT-WARPER"
    };
    private static readonly HashSet<string> Vehicles=new(StringComparer.Ordinal)
    {
        "ID_UNIT-HELICOPTER","ID_UNIT-HUMVEE","ID_UNIT-DRONE","ID_UNIT-TANK",
        "ID_UNIT-BUGGY","ID_UNIT-ASSAULTHELI","ID_UNIT-TRANSPORTER","ID_UNIT-MECH"
    };

    public static IReadOnlyList<BattleDirectKillStats> FromPayload(
        byte[] payload,string matchId,string digest)
    {
        var terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        var known=ArmyOptionIdentityCatalog.All.Select(x=>x.UnitId).Distinct(StringComparer.Ordinal)
            .ToHashSet(StringComparer.Ordinal);
        if(known.Count!=24 || Soldiers.Overlaps(Vehicles) ||
           !known.SetEquals(Soldiers.Concat(Vehicles)))
            throw new InvalidDataException("Recovered direct-kill source families changed.");
        return terminal.Players.Select(player=>
        {
            var kills=terminal.DirectArmyKills.Where(x=>x.AttackerPlayerId==player.PlayerId).ToArray();
            return new BattleDirectKillStats(player.PlayerId,kills.Length,
                kills.Count(x=>Vehicles.Contains(x.UnitId)),
                kills.Count(x=>x.UnitId=="ID_UNIT-TANK"));
        }).ToArray();
    }
}

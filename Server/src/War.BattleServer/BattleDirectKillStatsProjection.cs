namespace War.BattleServer;

/// <summary>Read-only source-shaped candidates from confirmed player-owned army deaths.</summary>
public sealed record BattleDirectKillStats(string PlayerId,int DirectBulletKills,
    int DirectBulletVehiclesDestroyed,int DirectBulletTanksDestroyed,int DirectGrenadeKills,
    int DirectGrenadeVehiclesDestroyed,int DirectGrenadeTanksDestroyed,
    int DirectMineKills,int DirectMineVehiclesDestroyed,int DirectMineTanksDestroyed);

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
    private static readonly HashSet<string> GroundVehicles=new(StringComparer.Ordinal)
    {"ID_UNIT-HUMVEE","ID_UNIT-TANK","ID_UNIT-BUGGY","ID_UNIT-TRANSPORTER"};
    private static readonly HashSet<string> GrenadeVehicles=new(GroundVehicles,StringComparer.Ordinal)
    {"ID_UNIT-DRONE","ID_UNIT-HELICOPTER","ID_UNIT-ASSAULTHELI"};
    // The Mech has no host Land Mine body-blast path yet.
    private static readonly HashSet<string> MineVehicles=new(StringComparer.Ordinal)
    {
        "ID_UNIT-HUMVEE","ID_UNIT-TANK","ID_UNIT-BUGGY","ID_UNIT-TRANSPORTER",
        "ID_UNIT-DRONE","ID_UNIT-HELICOPTER","ID_UNIT-ASSAULTHELI"
    };

    internal static bool SupportsGrenadeVictim(string unitId)=>
        Soldiers.Contains(unitId)||GrenadeVehicles.Contains(unitId);
    internal static bool SupportsMineVictim(string unitId)=>
        Soldiers.Contains(unitId)||MineVehicles.Contains(unitId);

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
            var kills=terminal.DirectArmyKills.Where(x=>x.AttackerPlayerId==player.PlayerId&&
                x.Cause=="player-bullet").ToArray();
            var grenadeKills=terminal.DirectArmyKills.Where(x=>x.AttackerPlayerId==player.PlayerId&&
                x.Cause=="player-grenade").ToArray();
            var mineKills=terminal.DirectArmyKills.Where(x=>x.AttackerPlayerId==player.PlayerId&&
                x.Cause=="player-mine").ToArray();
            return new BattleDirectKillStats(player.PlayerId,kills.Length,
                kills.Count(x=>Vehicles.Contains(x.UnitId)),
                kills.Count(x=>x.UnitId=="ID_UNIT-TANK"),grenadeKills.Length,
                grenadeKills.Count(x=>GrenadeVehicles.Contains(x.UnitId)),
                grenadeKills.Count(x=>x.UnitId=="ID_UNIT-TANK"),mineKills.Length,
                mineKills.Count(x=>MineVehicles.Contains(x.UnitId)),
                mineKills.Count(x=>x.UnitId=="ID_UNIT-TANK"));
        }).ToArray();
    }
}

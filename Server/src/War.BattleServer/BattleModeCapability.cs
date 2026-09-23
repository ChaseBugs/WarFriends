namespace War.BattleServer;

public enum BattleModeCapability { Prototype, Rifle, Shotgun, Smg, Pistol, Lmg, Minigun, Sniper, Bazooka, Grenade, Mixed }

/// <summary>Explicit server capability gate. Unsupported recovered modes stay
/// closed until their authoritative rules and Client callbacks are implemented.</summary>
public static class BattleModeCapabilityPolicy
{
    public static BattleModeCapability Resolve(string mode) => mode switch
    {
        MatchManifest.PrototypeMode => BattleModeCapability.Prototype,
        MatchManifest.RifleCombatMode => BattleModeCapability.Rifle,
        MatchManifest.ShotgunCombatMode => BattleModeCapability.Shotgun,
        MatchManifest.SmgCombatMode => BattleModeCapability.Smg,
        MatchManifest.MixedCombatMode => BattleModeCapability.Mixed,
        MatchManifest.PistolCombatMode => BattleModeCapability.Pistol,
        MatchManifest.LmgCombatMode => BattleModeCapability.Lmg,
        MatchManifest.MinigunCombatMode => BattleModeCapability.Minigun,
        MatchManifest.SniperCombatMode => BattleModeCapability.Sniper,
        MatchManifest.BazookaCombatMode => BattleModeCapability.Bazooka,
        MatchManifest.GrenadeCombatMode => BattleModeCapability.Grenade,
        _ => throw new InvalidDataException("Battle mode is not implemented by this host.")
    };
}

namespace War.BattleServer;

// Prepared by trusted host loadout/pose code, never by a command payload.
internal sealed record PreparedProjectile(BulletFlight Flight, ResolvedPlayerDamage Damage,
    string WeaponSourceId = "");

namespace War.BattleServer;

/// <summary>Host-owned slot and current location used when entering grenade simulation from another class.</summary>
internal sealed record GrenadeWeaponSelection(
    WeaponManifest Weapon, int Upgrade, ulong Tick, RifleActorLocation Location);

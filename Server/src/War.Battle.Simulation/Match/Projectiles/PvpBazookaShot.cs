namespace War.BattleServer;

internal readonly record struct PvpBazookaShot(
    string WeaponSourceId,
    int Upgrade,
    PvpBazookaShotKind Kind,
    bool IsHalfDamage);

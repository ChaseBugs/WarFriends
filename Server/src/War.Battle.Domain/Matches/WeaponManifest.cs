namespace War.BattleServer;

// Operator/allocator input, NEVER a client command. Live modes remain unscored
// until full gameplay and durable outcome authority exist.
public sealed record WeaponManifest(
    string SourceId, int ClipSize, int ReserveAmmo, double CadenceSeconds, double ReloadSeconds);

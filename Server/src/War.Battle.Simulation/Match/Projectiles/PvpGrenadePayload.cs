namespace War.BattleServer;

/// <summary>Launch-bound grenade damage metadata, without exposing mutable flight state.</summary>
internal readonly record struct PvpGrenadePayload(GrenadeStage Stage, GrenadeBinding Binding, string WeaponSourceId);

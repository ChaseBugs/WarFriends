namespace War.BattleServer;

/// <summary>Immutable launch-bound explosion metadata, without a mutable flight handle.</summary>
internal readonly record struct PvpBazookaPayload(
    BazookaStage Stage,
    BazookaBinding Binding,
    string WeaponSourceId,
    bool IsHalfDamage);

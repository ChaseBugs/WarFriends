namespace War.BattleServer;

/// <summary>Immutable launch authority retained independently of the firing soldier's lifetime.</summary>
internal sealed record PvpArmyBulletPayload
{
    internal required ulong EntityKey { get; init; }

    internal required string OwnerPlayerId { get; init; }

    internal required int OwnerFraction { get; init; }

    internal required float Damage { get; init; }

    internal required float PoisonRatio { get; init; }

    internal required string UnitId { get; init; }

    internal required string SourceCardId { get; init; }

    internal required bool IsCosmetic { get; init; }

    internal ArmyPlayerDamagePolicy? PlayerPolicy { get; init; }
}

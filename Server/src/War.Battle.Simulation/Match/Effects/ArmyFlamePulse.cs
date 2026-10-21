namespace War.BattleServer;

/// <summary>Immutable identity of one committed flame pulse for world effects and replay receipts.</summary>
internal readonly record struct ArmyFlamePulse(
    ulong ProjectileId, ulong EntityKey, string OwnerPlayerId, int PulseIndex)
{
    internal static ArmyFlamePulse FromBurst(ArmyFlameBurst burst)
    {
        return new(burst.ProjectileId, burst.EntityKey, burst.OwnerPlayerId, burst.PulseIndex);
    }
}

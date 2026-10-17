namespace War.Persistence;

/// <summary>Supplies server-owned reservation policy and authenticated identity, never client loadout assertions.</summary>
public sealed record BattleRematchReservation(
    string SourceMatchId,
    string AuthenticatedPlayerId,
    string CompatibilityKey,
    DateTimeOffset ApplicationTime);

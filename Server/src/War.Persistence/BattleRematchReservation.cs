namespace War.Persistence;

/// <summary>Supplies server-owned reservation policy and authenticated identity, never client loadout assertions.</summary>
public sealed record BattleRematchReservation(
    string SourceMatchId,
    string AuthenticatedPlayerId,
    string CompatibilityKey,
    DateTimeOffset ApplicationTime)
{
    /// <summary>Supplies the validated frozen source order rather than the consent record's sorted membership.</summary>
    public IReadOnlyList<string>? PlayerOrder { get; init; }

    /// <summary>Freezes the validated Backend-generated admission payload with participant reservation.</summary>
    public byte[]? PreparedManifest { get; init; }
}

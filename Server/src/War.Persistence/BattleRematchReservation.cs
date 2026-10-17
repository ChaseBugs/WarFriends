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
}

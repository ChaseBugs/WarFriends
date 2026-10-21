namespace War.Persistence.Legacy.Squads;

/// <summary>Changes only membership and optional creation economy, never unrelated account fields.</summary>
public sealed record LegacySquadPlayerChange
{
    public required string PlayerId { get; init; }

    public required long ExpectedRevision { get; init; }

    public required string SquadId { get; init; }

    public required int Rank { get; init; }

    public long? WarBucks { get; init; }

    public int? CreationsCount { get; init; }
}

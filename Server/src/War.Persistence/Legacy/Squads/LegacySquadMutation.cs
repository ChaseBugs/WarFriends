namespace War.Persistence.Legacy.Squads;

/// <summary>A pure transition plan; failed outcomes must not carry writes.</summary>
public sealed record LegacySquadMutation
{
    public required int Result { get; init; }

    public LegacySquadDocument? Squad { get; init; }

    public LegacySquadDocument? OtherSquad { get; init; }

    public bool IsCreation { get; init; }

    public bool IsDeletion { get; init; }

    public IReadOnlyList<LegacySquadPlayerChange> Players { get; init; } = [];
}

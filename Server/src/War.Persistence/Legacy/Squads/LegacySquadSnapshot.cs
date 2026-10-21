namespace War.Persistence.Legacy.Squads;

/// <summary>One transactional view of accounts, roster and bounded reverse-membership proofs.</summary>
public sealed record LegacySquadSnapshot
{
    public required LegacyPlayerDocument Actor { get; init; }

    public LegacyPlayerDocument? Target { get; init; }

    public LegacySquadDocument? Squad { get; init; }

    public LegacySquadDocument? OtherSquad { get; init; }

    public required IReadOnlyList<string> ActorMemberships { get; init; }

    public required IReadOnlyList<string> TargetMemberships { get; init; }
}

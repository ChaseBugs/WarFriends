namespace War.Persistence.Legacy.Cards;

/// <summary>Describes a calculated transfer without performing persistence or transport work.</summary>
public sealed record LegacyCardPoolMutation
{
    public required int Result { get; init; }

    public int NextWithdraw { get; init; }

    public string? ActorCards { get; init; }

    public IReadOnlyDictionary<string, int>? ActorDeposits { get; init; }

    public IReadOnlyDictionary<string, int>? DonorDeposits { get; init; }

    public int? DonorReputation { get; init; }

    public bool NeedsSquadFence { get; init; }
}

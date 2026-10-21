namespace War.Persistence.Legacy.Cards;

/// <summary>Binds a direct card transfer to its authenticated actor and optional caller operation key.</summary>
public sealed record LegacyCardPoolOperation
{
    public required string ActorId { get; init; }

    public string? DonorId { get; init; }

    public required int ActionId { get; init; }

    public required string PayloadDigest { get; init; }

    public string? OperationId { get; init; }

    public required int NowUnixSeconds { get; init; }
}

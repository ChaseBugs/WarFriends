namespace War.Persistence.Legacy.Buffers;

/// <summary>Preserves the original delivery identity and absolute deadline behind a relative wire field.</summary>
public sealed record LegacyBufferedDelivery
{
    public required string Kind { get; init; }

    public required string ItemId { get; init; }

    public required int BoughtIndex { get; init; }

    public required long EndUnixSeconds { get; init; }
}

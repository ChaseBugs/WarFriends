namespace War.Persistence.Legacy.Buffers;

/// <summary>Publishes calculated subsystem changes, balances and the complete response together.</summary>
public sealed record LegacyBufferedMutation
{
    public required IReadOnlyDictionary<string, string> Serialized { get; init; }

    public required long Gold { get; init; }

    public required long WarBucks { get; init; }

    public required long Scraps { get; init; }

    public required int ArmyPower { get; init; }

    public required int Result { get; init; }

    public required string ResponseJson { get; init; }

    public LegacyBufferedDelivery? Delivery { get; init; }
}

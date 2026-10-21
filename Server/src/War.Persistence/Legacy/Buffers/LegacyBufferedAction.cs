namespace War.Persistence.Legacy.Buffers;

/// <summary>Binds a buffered effect to its player, position, action and exact payload digest.</summary>
public sealed record LegacyBufferedAction
{
    public required string PlayerId { get; init; }

    public required string BufferId { get; init; }

    public required int Index { get; init; }

    public required int ActionId { get; init; }

    public required string PayloadDigest { get; init; }
}

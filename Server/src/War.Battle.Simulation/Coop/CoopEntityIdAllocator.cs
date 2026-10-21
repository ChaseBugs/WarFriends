namespace War.BattleServer;

/// <summary>One match-wide ID sequence for mission actors and reserved secondary crew identities.</summary>
internal sealed class CoopEntityIdAllocator
{
    private const int MaximumBatchSize = 6;
    private ulong _nextId;

    internal CoopEntityIdAllocator(ulong firstId = 1)
    {
        if (firstId == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(firstId));
        }
        _nextId = firstId;
    }

    internal ulong Allocate()
    {
        RequireCapacity(1);
        return _nextId++;
    }

    internal IReadOnlyList<ulong> Reserve(int count)
    {
        if (count is < 1 or > MaximumBatchSize)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }
        RequireCapacity(count);
        var identities = new ulong[count];
        for (int index = 0; index < count; index++)
        {
            identities[index] = _nextId + (ulong)index;
        }
        _nextId += (ulong)count;
        return Array.AsReadOnly(identities);
    }

    private void RequireCapacity(int count)
    {
        // Leave the final value as an exhausted sentinel; the counter must never wrap to reserved ID zero.
        if ((ulong)count > ulong.MaxValue - _nextId)
        {
            throw new InvalidOperationException("Co-op actor identity sequence is exhausted.");
        }
    }
}

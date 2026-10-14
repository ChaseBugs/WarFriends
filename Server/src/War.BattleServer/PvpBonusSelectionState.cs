namespace War.BattleServer;

public enum PvpBonusSide { Allies = 1, Enemy = 2 }
public sealed record PvpBonusSelection(PvpBonusSource Prefab, int SourceIndex, bool UsedQueuedOverride)
{
    // The original upper-endpoint fallthrough can keep prefab 8 but send index
    // 9. Preserve that observation; it is not permission to publish an invalid RPC.
    public bool HasValidSourceIndex => SourceIndex == Prefab.Index;
}
internal sealed record PvpBonusWeightedChoice(float Total, int PrefabIndex, int SourceIndex);

/// <summary>Source manager selection history, called only by the serialized host actor.</summary>
public sealed class PvpBonusSelectionState
{
    private const int MaximumQueuedBonuses = 64;
    private readonly PvpBonusCatalog catalog;
    private readonly int maximumReceipts;
    private readonly Queue<int> allies = new();
    private readonly Queue<int> enemy = new();
    private readonly Dictionary<string, SavedEnqueue> enqueues = new(StringComparer.Ordinal);
    private readonly Dictionary<string, SavedSelection> selections = new(StringComparer.Ordinal);
    private sealed record SavedEnqueue(PvpBonusSide Side, int Index);
    private sealed record SavedSelection(PvpBonusSide Side, PvpBonusWeightContext Context, PvpBonusSelection Result);

    public int LastSourceIndex { get; private set; }
    public int ReceiptCount => enqueues.Count + selections.Count;

    public PvpBonusSelectionState(PvpBonusCatalog catalog, int maximumReceipts = 4096)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        if (maximumReceipts is < 1 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(maximumReceipts));
        this.catalog = catalog;
        this.maximumReceipts = maximumReceipts;
    }

    public int QueuedCount(PvpBonusSide side) => QueueFor(side).Count;

    public void EnqueueConfirmedBonus(string receiptId, PvpBonusSide side, int sourceIndex)
    {
        ValidateReceipt(receiptId);
        var queue = QueueFor(side);
        if (sourceIndex is < -1 or > 8)
            throw new ArgumentOutOfRangeException(nameof(sourceIndex));
        if (selections.ContainsKey(receiptId))
            throw new InvalidDataException("Selection receipt cannot become a queue mutation.");
        if (enqueues.TryGetValue(receiptId, out var previous))
        {
            if (previous.Side != side || previous.Index != sourceIndex)
                throw new InvalidDataException("Confirmed queue receipt changed its authority.");
            return;
        }
        EnsureReceiptCapacity();
        if (queue.Count == MaximumQueuedBonuses)
            throw new InvalidOperationException("Confirmed bonus queue capacity exhausted.");
        enqueues.Add(receiptId, new(side, sourceIndex));
        queue.Enqueue(sourceIndex);
    }

    public PvpBonusSelection SelectConfirmedBonus(string receiptId, PvpBonusSide side,
        PvpBonusWeightContext context, Func<float, float> hostDraw)
    {
        ValidateReceipt(receiptId);
        var queue = QueueFor(side);
        var weights = catalog.WeightsForSourceContext(context);
        ArgumentNullException.ThrowIfNull(hostDraw);
        if (enqueues.ContainsKey(receiptId))
            throw new InvalidDataException("Queue receipt cannot become a selection.");
        if (selections.TryGetValue(receiptId, out var previous))
        {
            if (previous.Side != side || previous.Context != context)
                throw new InvalidDataException("Confirmed selection receipt changed its authority.");
            return previous.Result;
        }
        EnsureReceiptCapacity();
        int queuedIndex = queue.Count == 0 ? -1 : queue.Peek();
        int prefabIndex;
        int sourceIndex;
        bool forced = queuedIndex >= 0;
        if (forced)
        {
            // Source queues bypass both probability gates and last-index exclusion.
            prefabIndex = queuedIndex;
            sourceIndex = queuedIndex;
        }
        else
        {
            float total = SourceTotal(weights, LastSourceIndex);
            var choice = SourceWeightedChoice(weights, LastSourceIndex, hostDraw(total));
            prefabIndex = choice.PrefabIndex;
            sourceIndex = choice.SourceIndex;
        }
        var result = new PvpBonusSelection(catalog.Rows[prefabIndex], sourceIndex, forced);
        selections.Add(receiptId, new(side, context, result));
        if (queue.Count > 0) queue.Dequeue();
        LastSourceIndex = sourceIndex;
        return result;
    }

    public void ClearQueuesForGameStart()
    {
        // The recovered GameStarted handler clears queues, not mLastBonusIndex.
        // Retain receipts so replay cannot restore an old game's queued effect.
        allies.Clear();
        enemy.Clear();
    }

    private Queue<int> QueueFor(PvpBonusSide side) => side switch
    {
        PvpBonusSide.Allies => allies,
        PvpBonusSide.Enemy => enemy,
        _ => throw new ArgumentOutOfRangeException(nameof(side))
    };

    private static void ValidateReceipt(string receiptId)
    {
        if (!Guid.TryParseExact(receiptId, "N", out _) || receiptId != receiptId.ToLowerInvariant())
            throw new InvalidDataException("Invalid confirmed bonus receipt identity.");
    }

    private void EnsureReceiptCapacity()
    {
        if (ReceiptCount == maximumReceipts)
            throw new InvalidOperationException("Confirmed bonus receipt capacity exhausted.");
    }

    internal static float SourceTotal(IReadOnlyList<float> weights, int lastIndex)
    {
        if (weights.Count != 9 || lastIndex is < 0 or > 9)
            throw new InvalidDataException("Invalid source selection state.");
        float total = 0;
        for (int index = 0; index < weights.Count; index++)
        {
            if (!float.IsFinite(weights[index]) || weights[index] < 0)
                throw new InvalidDataException("Invalid source bonus weight.");
            if (index != lastIndex) total += weights[index];
        }
        if (!float.IsFinite(total)) throw new InvalidDataException("Source bonus weight overflow.");
        return total;
    }

    internal static PvpBonusWeightedChoice SourceWeightedChoice(IReadOnlyList<float> weights,
        int lastIndex, float draw)
    {
        float total = SourceTotal(weights, lastIndex);
        if (!float.IsFinite(draw) || draw < 0 || draw > total)
            throw new ArgumentOutOfRangeException(nameof(draw));
        float cumulative = 0;
        int prefabIndex = 0;
        int sourceIndex;
        for (sourceIndex = 0; sourceIndex < weights.Count; sourceIndex++)
        {
            prefabIndex = sourceIndex;
            if (sourceIndex != lastIndex) cumulative += weights[sourceIndex];
            if (draw < cumulative) break;
        }
        return new(total, prefabIndex, sourceIndex);
    }
}

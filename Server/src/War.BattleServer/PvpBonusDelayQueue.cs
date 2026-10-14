using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpBonusDelayedRequest(string ReceiptId, string MatchId,
    string OwnerPlayerId, int BonusOrdinal, ulong IssueFrame);

/// <summary>
/// Source coroutine delay over host scaled-frame deltas. Maturity does not
/// select or spawn a crate; callers must resolve the owner/map at that time.
/// </summary>
public sealed class PvpBonusDelayQueue : IDisposable
{
    private const double DelaySeconds = 1.5;
    private readonly int maximumPending;
    private readonly int maximumReceipts;
    private readonly Dictionary<string, PvpBonusDelayedRequest> receipts = new(StringComparer.Ordinal);
    private readonly Dictionary<(string MatchId, string Owner), int> lastOrdinals = new();
    private readonly List<PendingBonus> pending = new();
    private sealed record PendingBonus(PvpBonusDelayedRequest Request, double Elapsed);
    private ulong lastFrame;
    private ulong latestIssueFrame;
    private int lastDeltaBits;
    private IReadOnlyList<PvpBonusDelayedRequest>? lastFrameResult;
    private bool disposed;

    public int PendingCount => pending.Count;
    public int ReceiptCount => receipts.Count;

    public PvpBonusDelayQueue(int maximumPending = 256, int maximumReceipts = 4096)
    {
        if (maximumPending is < 1 or > 256)
            throw new ArgumentOutOfRangeException(nameof(maximumPending));
        if (maximumReceipts is < 1 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(maximumReceipts));
        this.maximumPending = maximumPending;
        this.maximumReceipts = maximumReceipts;
    }

    public PvpBonusDelayedRequest ScheduleConfirmedBonus(string receiptId, string matchId,
        string ownerPlayerId, int bonusOrdinal, ulong issueFrame)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        ValidateGuid(receiptId);
        ValidateGuid(matchId);
        if (string.IsNullOrWhiteSpace(ownerPlayerId) || ownerPlayerId.Length > 128 ||
            ownerPlayerId.Any(char.IsControl) || char.IsWhiteSpace(ownerPlayerId[0]) ||
            char.IsWhiteSpace(ownerPlayerId[^1]))
            throw new InvalidDataException("Invalid confirmed bonus owner identity.");
        if (bonusOrdinal < 1) throw new ArgumentOutOfRangeException(nameof(bonusOrdinal));
        var request = new PvpBonusDelayedRequest(receiptId, matchId, ownerPlayerId, bonusOrdinal, issueFrame);
        if (receipts.TryGetValue(receiptId, out var previous))
        {
            if (previous != request)
                throw new InvalidDataException("Confirmed delayed bonus receipt changed its authority.");
            return previous;
        }
        if (issueFrame == 0 || lastFrame == ulong.MaxValue || issueFrame < latestIssueFrame ||
            (issueFrame != lastFrame && issueFrame != lastFrame + 1))
            throw new InvalidDataException("Bonus must be issued in the current ordered game frame.");
        var scope = (matchId, ownerPlayerId);
        int previousOrdinal = lastOrdinals.GetValueOrDefault(scope);
        if (previousOrdinal == int.MaxValue || bonusOrdinal != previousOrdinal + 1)
            throw new InvalidDataException("Confirmed bonus ordinals must be consecutive per match and owner.");
        if (receipts.Count == maximumReceipts || pending.Count == maximumPending)
            throw new InvalidOperationException("Confirmed bonus delay capacity exhausted.");

        receipts.Add(receiptId, request);
        lastOrdinals[scope] = bonusOrdinal;
        pending.Add(new(request, 0));
        latestIssueFrame = issueFrame;
        return request;
    }

    public IReadOnlyList<PvpBonusDelayedRequest> AdvanceFrame(ulong frameId, float scaledDeltaTime)
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        if (!float.IsFinite(scaledDeltaTime) || scaledDeltaTime < 0)
            throw new ArgumentOutOfRangeException(nameof(scaledDeltaTime));
        int deltaBits = BitConverter.SingleToInt32Bits(scaledDeltaTime);
        if (lastFrameResult != null && frameId == lastFrame)
        {
            if (deltaBits != lastDeltaBits)
                throw new InvalidDataException("Repeated delay frame changed its scaled delta.");
            return lastFrameResult;
        }
        if (lastFrame == ulong.MaxValue || frameId != lastFrame + 1)
            throw new InvalidDataException("Delay frames must be consecutive, starting at one.");

        var ready = new List<PvpBonusDelayedRequest>();
        var remaining = new List<PendingBonus>();
        foreach (var timer in pending)
        {
            // WaitAndCall yields in the issue frame. Do not count that frame's
            // delta again. Later deltas are already scaled by the host clock.
            double elapsed = timer.Elapsed;
            if (timer.Request.IssueFrame < frameId) elapsed += scaledDeltaTime;
            if (elapsed >= DelaySeconds)
                ready.Add(timer.Request);
            else
                remaining.Add(timer with {Elapsed = elapsed});
        }
        pending.Clear();
        pending.AddRange(remaining);
        lastFrameResult = new ReadOnlyCollection<PvpBonusDelayedRequest>(ready);
        lastFrame = frameId;
        lastDeltaBits = deltaBits;
        return lastFrameResult;
    }

    public void Dispose()
    {
        // Destruction of the coroutine's manager stops its waits. A game-end
        // notification alone does not destroy it and must not call Dispose.
        disposed = true;
        pending.Clear();
    }

    private static void ValidateGuid(string identity)
    {
        if (!Guid.TryParseExact(identity, "N", out _) || identity != identity.ToLowerInvariant())
            throw new InvalidDataException("Invalid confirmed delay receipt or match identity.");
    }
}

using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpOwnerStreakFrame(string OwnerPlayerId, PvpScoreStreakFrame Streak);
public sealed record PvpOwnerStreakSnapshot(string OwnerPlayerId, float Progress,
    int BonusesRequested, int GainReceiptCount);
public sealed record PvpBonusProgressFrame(ulong FrameId,
    IReadOnlyList<PvpOwnerStreakFrame> Players, IReadOnlyList<PvpBonusDelayedRequest> MaturedRequests);

/// <summary>
/// Atomic progress/delay transitions for one source view of a match. This is
/// not yet a MatchEngine scoring or crate-spawn adapter.
/// </summary>
public sealed class PvpBonusProgressCoordinator : IDisposable
{
    private readonly object gate = new();
    private readonly string matchId;
    private readonly string localOwnerId;
    private readonly string opponentOwnerId;
    private PvpScoreStreakProgress localProgress;
    private PvpScoreStreakProgress opponentProgress;
    private PvpBonusDelayQueue delays;
    private PvpBonusProgressFrame? lastFrame;
    private int lastDeltaBits;
    private bool lastRunning;
    private bool disposed;

    public PvpBonusProgressCoordinator(PvpSkillShotScoreCatalog scores, PvpScoreStreakPolicy policy,
        string matchId, string localOwnerId, string opponentOwnerId, bool dropsCrates,
        int maximumPending = 256, int maximumDelayReceipts = 4096)
    {
        PvpBonusDelayQueue.ValidateScope(matchId, localOwnerId);
        PvpBonusDelayQueue.ValidateScope(matchId, opponentOwnerId);
        if (localOwnerId == opponentOwnerId)
            throw new InvalidDataException("Source view requires distinct local/opponent owners.");
        this.matchId = matchId;
        this.localOwnerId = localOwnerId;
        this.opponentOwnerId = opponentOwnerId;
        // ScoreManager.Restart sets one ratio for both AddSkillshot branches.
        localProgress = new(scores, policy, dropsCrates);
        opponentProgress = new(scores, policy, dropsCrates);
        delays = new(maximumPending, maximumDelayReceipts);
    }

    public int PendingCount { get { lock (gate) return delays.PendingCount; } }
    public int DelayReceiptCount { get { lock (gate) return delays.ReceiptCount; } }

    public float RecordConfirmedSkillShot(string ownerId, string receiptId, int flags, float confirmedMultiplier)
    {
        lock (gate)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            return ProgressFor(ownerId).RecordConfirmedSkillShot(receiptId, flags, confirmedMultiplier);
        }
    }

    public PvpOwnerStreakSnapshot Snapshot(string ownerId)
    {
        lock (gate)
        {
            var progress = ProgressFor(ownerId);
            return new(ownerId, progress.Progress, progress.BonusesRequested, progress.ReceiptCount);
        }
    }

    public PvpBonusProgressFrame AdvanceFrame(ulong frameId, float scaledDelta, bool gameIsRunning)
    {
        lock (gate)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            if (!float.IsFinite(scaledDelta) || scaledDelta < 0)
                throw new ArgumentOutOfRangeException(nameof(scaledDelta));
            int deltaBits = BitConverter.SingleToInt32Bits(scaledDelta);
            if (lastFrame != null && lastFrame.FrameId == frameId)
            {
                if (deltaBits != lastDeltaBits || gameIsRunning != lastRunning)
                    throw new InvalidDataException("Repeated source frame changed its inputs.");
                return lastFrame;
            }

            // Prepare both players before publishing either. No gameplay
            // callback, selection or spawn runs inside this transaction.
            var nextLocal = localProgress.PrepareFrameCopy(frameId, scaledDelta, gameIsRunning, out var local);
            var nextOpponent = opponentProgress.PrepareFrameCopy(frameId, scaledDelta, gameIsRunning, out var opponent);
            var requests = new List<PvpBonusDelayedRequest>(2);
            AddRequest(requests, localOwnerId, local, frameId);
            AddRequest(requests, opponentOwnerId, opponent, frameId);
            var nextDelays = delays.PrepareFrameCopy(frameId, scaledDelta, requests, out var ready);
            var players = new ReadOnlyCollection<PvpOwnerStreakFrame>(
                new[] {new PvpOwnerStreakFrame(localOwnerId, local), new PvpOwnerStreakFrame(opponentOwnerId, opponent)});
            var result = new PvpBonusProgressFrame(frameId, players, ready);

            // Validation/capacity failures above discard all candidate state,
            // including threshold subtraction, ordinals and timer aging.
            localProgress = nextLocal;
            opponentProgress = nextOpponent;
            delays = nextDelays;
            lastFrame = result;
            lastDeltaBits = deltaBits;
            lastRunning = gameIsRunning;
            return result;
        }
    }

    private void AddRequest(List<PvpBonusDelayedRequest> requests, string ownerId,
        PvpScoreStreakFrame streak, ulong frameId)
    {
        if (!streak.BonusRequested) return;
        // These host identities are staged. Rejected frames discard them;
        // accepted frame replay uses the cached result instead of minting more.
        requests.Add(new(Guid.NewGuid().ToString("N"), matchId, ownerId, streak.BonusOrdinal, frameId));
    }

    private PvpScoreStreakProgress ProgressFor(string ownerId)
    {
        if (ownerId == localOwnerId) return localProgress;
        if (ownerId == opponentOwnerId) return opponentProgress;
        throw new InvalidDataException("Skill-shot owner is outside this source view.");
    }

    public void Dispose()
    {
        lock (gate)
        {
            disposed = true;
            delays.Dispose();
        }
    }
}

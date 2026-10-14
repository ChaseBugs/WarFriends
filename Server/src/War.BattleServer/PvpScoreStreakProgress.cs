namespace War.BattleServer;

public sealed record PvpScoreStreakFrame(float Progress, bool BonusRequested, int BonusOrdinal);

/// <summary>
/// One player's source progress. Feed host-confirmed skill shots and ordered
/// game frames; this state does not select, spawn, or grant bonus crates.
/// </summary>
public sealed class PvpScoreStreakProgress
{
    private readonly PvpSkillShotScoreCatalog catalog;
    private readonly PvpScoreStreakPolicy policy;
    private readonly float scoreRatio;
    private readonly int maximumReceipts;
    private Dictionary<string, SavedGain> receipts = new(StringComparer.Ordinal);
    private sealed record SavedGain(int Flags, int MultiplierBits, float ProgressAfter);
    private ulong lastFrame;
    private int lastDeltaBits;
    private bool lastRunning;
    private PvpScoreStreakFrame? lastFrameResult;

    public float Progress { get; private set; }
    public int BonusesRequested { get; private set; }
    public int ReceiptCount => receipts.Count;

    public PvpScoreStreakProgress(PvpSkillShotScoreCatalog catalog,
        PvpScoreStreakPolicy policy, bool dropsCrates, int maximumReceipts = 4096)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        ArgumentNullException.ThrowIfNull(policy);
        if (maximumReceipts is < 1 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(maximumReceipts));
        this.catalog = catalog;
        this.policy = policy;
        scoreRatio = policy.RatioForMatch(dropsCrates);
        this.maximumReceipts = maximumReceipts;
    }

    public float RecordConfirmedSkillShot(string receiptId, int flags, float confirmedMultiplier)
    {
        if (!Guid.TryParseExact(receiptId, "N", out _) || receiptId != receiptId.ToLowerInvariant())
            throw new InvalidDataException("Invalid confirmed progress receipt identity.");
        catalog.PointsForConfirmedFlags(flags);
        // MainScene serializes CRATEBLOCKER as zero, overriding its C# default
        // of 0.8; STREAKBOOST is 1.25. The caller must resolve active effects.
        if (confirmedMultiplier is not (0f or 1f or 1.25f))
            throw new ArgumentOutOfRangeException(nameof(confirmedMultiplier));
        int multiplierBits = BitConverter.SingleToInt32Bits(confirmedMultiplier);
        if (receipts.TryGetValue(receiptId, out var previous))
        {
            if (previous.Flags != flags || previous.MultiplierBits != multiplierBits)
                throw new InvalidDataException("Confirmed progress receipt changed its authority.");
            return previous.ProgressAfter;
        }
        if (receipts.Count == maximumReceipts)
            throw new InvalidOperationException("Confirmed progress receipt capacity exhausted.");

        float nextProgress = Progress;
        // Preserve each source definition's storage boundary. Summing points
        // first changes rounding when several rows match the same skill shot.
        foreach (var row in catalog.Rows)
        {
            if ((flags & row.Flag) == row.Flag)
                nextProgress = AddSourceGain(nextProgress, row.MultiplayerPoints, scoreRatio, confirmedMultiplier);
        }
        if (!float.IsFinite(nextProgress))
            throw new InvalidDataException("Score-streak progress overflow.");
        receipts.Add(receiptId, new SavedGain(flags, multiplierBits, nextProgress));
        Progress = nextProgress;
        return nextProgress;
    }

    public PvpScoreStreakFrame AdvanceFrame(ulong frameId, float gameDeltaTime, bool gameIsRunning)
    {
        if (!float.IsFinite(gameDeltaTime) || gameDeltaTime < 0)
            throw new ArgumentOutOfRangeException(nameof(gameDeltaTime));
        int deltaBits = BitConverter.SingleToInt32Bits(gameDeltaTime);
        if (lastFrameResult != null && frameId == lastFrame)
        {
            if (deltaBits != lastDeltaBits || gameIsRunning != lastRunning)
                throw new InvalidDataException("Repeated game frame changed its source inputs.");
            return lastFrameResult;
        }
        if (lastFrame == ulong.MaxValue || frameId != lastFrame + 1)
            throw new InvalidDataException("Game frames must be consecutive, starting at one.");

        var transition = UpdateSourceProgress(Progress, gameDeltaTime, gameIsRunning, policy);
        int nextOrdinal = transition.BonusRequested ? checked(BonusesRequested + 1) : BonusesRequested;
        var result = new PvpScoreStreakFrame(transition.Progress, transition.BonusRequested, nextOrdinal);
        Progress = result.Progress;
        BonusesRequested = nextOrdinal;
        lastFrame = frameId;
        lastDeltaBits = deltaBits;
        lastRunning = gameIsRunning;
        lastFrameResult = result;
        return result;
    }

    internal PvpScoreStreakProgress PrepareFrameCopy(ulong frameId, float delta,
        bool running, out PvpScoreStreakFrame result)
    {
        // AdvanceFrame changes only scalar frame state. Its receipt ledger is
        // read-only during preparation; the coordinator serializes all gains.
        var candidate = (PvpScoreStreakProgress)MemberwiseClone();
        result = candidate.AdvanceFrame(frameId, delta, running);
        return candidate;
    }

    internal PvpScoreStreakProgress PrepareConfirmedSkillShotCopy(string receiptId,
        int flags, float multiplier, out float result)
    {
        var candidate = (PvpScoreStreakProgress)MemberwiseClone();
        candidate.receipts = new Dictionary<string, SavedGain>(receipts, StringComparer.Ordinal);
        result = candidate.RecordConfirmedSkillShot(receiptId, flags, multiplier);
        return candidate;
    }

    internal static float AddSourceGain(float progress, int points, float ratio, float multiplier)
    {
        // Mono carries intermediate float arithmetic at promoted precision;
        // the original property assignment is the float storage boundary.
        return (float)((double)progress + (double)(float)points * ratio * multiplier);
    }

    internal static PvpScoreStreakFrame UpdateSourceProgress(float progress, float delta,
        bool running, PvpScoreStreakPolicy policy)
    {
        if (!running) return new(progress, false, 0);
        float nextProgress = (float)((double)progress - (double)delta * policy.ProgressLossPerSecond);
        // Mathf.Clamp compares strictly below zero. In particular, preserve
        // negative zero after a subnormal decay rather than normalize its bits.
        if (nextProgress < 0f) nextProgress = 0f;
        bool bonusRequested = nextProgress > policy.BonusThreshold;
        if (bonusRequested) nextProgress -= policy.BonusThreshold;
        return new(nextProgress, bonusRequested, 0);
    }
}

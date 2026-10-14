using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpOwnerStreakFrame(string OwnerPlayerId, PvpScoreStreakFrame Streak);
public sealed record PvpOwnerStreakSnapshot(string OwnerPlayerId, float Progress,
    int BonusesRequested, int GainReceiptCount);
public sealed record PvpOwnerScoreSnapshot(string OwnerPlayerId, int Score,
    IReadOnlyDictionary<int, int> Counts, int ReceiptCount);
public sealed record PvpConfirmedSkillShot(PvpSkillShotScoreReceipt Score, float Progress);
public sealed record PvpConfirmedPlayerDeath(PvpKillComboResult Combo,
    PvpConfirmedSkillShot? ScoredSkillShot);
public sealed record PvpComboSnapshot(int Streak, float LastKillTime, int ReceiptCount);
public sealed record PvpBonusProgressFrame(ulong FrameId,
    IReadOnlyList<PvpOwnerStreakFrame> Players, IReadOnlyList<PvpBonusDelayedRequest> MaturedRequests);

/// <summary>
/// Atomic progress/delay transitions for one source view of a match. This is
/// not yet a MatchEngine scoring or crate-spawn adapter.
/// </summary>
public sealed class PvpBonusProgressCoordinator : IDisposable
{
    public static PvpBonusProgressCoordinator CreateForOnlineManifest(
        BattleCombatContent content, MatchManifest manifest, string localOwnerId)
    {
        ArgumentNullException.ThrowIfNull(content);
        var admitted = MatchManifest.Validate(manifest);
        if (admitted.Mode is MatchManifest.PrototypeMode or MatchManifest.CoopMissionMode)
            throw new InvalidDataException("This source view requires an online PvP match.");
        content.ValidateAllocation(admitted);
        var local = admitted.Players.SingleOrDefault(player => player.PlayerId == localOwnerId)
            ?? throw new InvalidDataException("Local source-view owner is outside the admitted roster.");
        var opponent = admitted.Players.Single(player => player.PlayerId != localOwnerId);
        if (local.PlayerLevel is not int localLevel || opponent.PlayerLevel is not int opponentLevel)
            throw new InvalidDataException("Online crate policy requires both signed player ranks.");
        bool dropsCrates = content.PvpScoreStreak.DropsCratesForOnlineView(localLevel, opponentLevel);
        return new(content.PvpScores, content.PvpScoreStreak, admitted.MatchId,
            local.PlayerId, opponent.PlayerId, dropsCrates);
    }

    private readonly object gate = new();
    private readonly string matchId;
    private readonly string localOwnerId;
    private readonly string opponentOwnerId;
    private readonly PvpSkillShotScoreCatalog scores;
    private PvpScoreStreakProgress localProgress;
    private PvpScoreStreakProgress opponentProgress;
    private PvpSkillShotScoreState localScore;
    private PvpSkillShotScoreState opponentScore;
    private PvpKillComboState combo;
    private readonly Dictionary<string, ConfirmedDeathReceipt> deathReceipts = new(StringComparer.Ordinal);
    private sealed record ConfirmedDeathReceipt(string OwnerId, int BaseFlags, int GameTimeBits,
        bool IsEnemy, int MultiplierBits, PvpConfirmedPlayerDeath Result);
    private PvpBonusDelayQueue delays;
    private PvpBonusProgressFrame? lastFrame;
    private int lastDeltaBits;
    private bool lastRunning;
    private bool disposed;

    public PvpBonusProgressCoordinator(PvpSkillShotScoreCatalog scores, PvpScoreStreakPolicy policy,
        string matchId, string localOwnerId, string opponentOwnerId, bool dropsCrates,
        int maximumPending = 256, int maximumDelayReceipts = 4096,
        int maximumScoreReceipts = 4096, int maximumGainReceipts = 4096,
        int maximumComboReceipts = 4096)
    {
        PvpBonusDelayQueue.ValidateScope(matchId, localOwnerId);
        PvpBonusDelayQueue.ValidateScope(matchId, opponentOwnerId);
        if (localOwnerId == opponentOwnerId)
            throw new InvalidDataException("Source view requires distinct local/opponent owners.");
        this.matchId = matchId;
        this.scores = scores;
        this.localOwnerId = localOwnerId;
        this.opponentOwnerId = opponentOwnerId;
        // ScoreManager.Restart sets one ratio for both AddSkillshot branches.
        localProgress = new(scores, policy, dropsCrates, maximumGainReceipts);
        opponentProgress = new(scores, policy, dropsCrates, maximumGainReceipts);
        localScore = new(scores, maximumScoreReceipts);
        opponentScore = new(scores, maximumScoreReceipts);
        combo = new(scores, maximumComboReceipts);
        delays = new(maximumPending, maximumDelayReceipts);
    }

    public int PendingCount { get { lock (gate) return delays.PendingCount; } }
    public int DelayReceiptCount { get { lock (gate) return delays.ReceiptCount; } }

    public float RecordConfirmedSkillShot(string ownerId, string receiptId, int flags, float confirmedMultiplier)
        => RecordConfirmedSkillShotWithScore(ownerId, receiptId, flags, confirmedMultiplier).Progress;

    public PvpConfirmedSkillShot RecordConfirmedSkillShotWithScore(string ownerId,
        string receiptId, int flags, float confirmedMultiplier)
    {
        lock (gate)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            if (deathReceipts.ContainsKey(receiptId))
                throw new InvalidDataException("Death receipts must use the confirmed death transition.");
            var progress = ProgressFor(ownerId);
            var score = ScoreFor(ownerId);
            var nextScore = score.PrepareConfirmedSkillShotCopy(receiptId, flags, out var scored);
            var nextProgress = progress.PrepareConfirmedSkillShotCopy(receiptId, flags,
                confirmedMultiplier, out float gained);
            if (ownerId == localOwnerId)
            {
                localScore = nextScore;
                localProgress = nextProgress;
            }
            else
            {
                opponentScore = nextScore;
                opponentProgress = nextProgress;
            }
            return new(scored, gained);
        }
    }

    /// <summary>
    /// A host-confirmed, non-network player-owned death. The source updates
    /// its shared combo before testing whether the victim is an enemy.
    /// </summary>
    public PvpConfirmedPlayerDeath RecordConfirmedPlayerOwnedDeath(string ownerId,
        string receiptId, int baseFlags, float gameTime, bool isEnemy,
        float confirmedMultiplier)
    {
        lock (gate)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            var progress = ProgressFor(ownerId);
            var score = ScoreFor(ownerId);
            if ((baseFlags & (32 | 64 | 128)) != 0)
                throw new InvalidDataException("Base death flags already contain a combo result.");
            scores.PointsForConfirmedFlags(baseFlags);
            if (confirmedMultiplier is not (0f or 1f or 1.25f))
                throw new ArgumentOutOfRangeException(nameof(confirmedMultiplier));
            int timeBits = BitConverter.SingleToInt32Bits(gameTime);
            int multiplierBits = BitConverter.SingleToInt32Bits(confirmedMultiplier);
            if (deathReceipts.TryGetValue(receiptId, out var previous))
            {
                if (previous.OwnerId != ownerId || previous.BaseFlags != baseFlags ||
                    previous.GameTimeBits != timeBits || previous.IsEnemy != isEnemy ||
                    previous.MultiplierBits != multiplierBits)
                    throw new InvalidDataException("Confirmed death receipt changed its authority.");
                return previous.Result;
            }
            if (localScore.HasReceipt(receiptId) || opponentScore.HasReceipt(receiptId))
                throw new InvalidDataException("Death receipt was already used by a direct skill shot.");

            var nextCombo = combo.PrepareConfirmedKillCopy(receiptId, gameTime, out var comboResult);
            PvpConfirmedSkillShot? scoredShot = null;
            PvpSkillShotScoreState? nextScore = null;
            PvpScoreStreakProgress? nextProgress = null;
            if (isEnemy)
            {
                int flags = baseFlags | comboResult.ComboFlag;
                nextScore = score.PrepareConfirmedSkillShotCopy(receiptId, flags, out var scored);
                nextProgress = progress.PrepareConfirmedSkillShotCopy(receiptId, flags,
                    confirmedMultiplier, out float gained);
                scoredShot = new(scored, gained);
            }
            var result = new PvpConfirmedPlayerDeath(comboResult, scoredShot);
            deathReceipts.Add(receiptId, new(ownerId, baseFlags, timeBits, isEnemy,
                multiplierBits, result));
            combo = nextCombo;
            if (nextScore != null && nextProgress != null)
            {
                if (ownerId == localOwnerId)
                {
                    localScore = nextScore;
                    localProgress = nextProgress;
                }
                else
                {
                    opponentScore = nextScore;
                    opponentProgress = nextProgress;
                }
            }
            return result;
        }
    }

    public PvpComboSnapshot ComboSnapshot()
    {
        lock (gate) return new(combo.Streak, combo.LastKillTime, combo.ReceiptCount);
    }

    public PvpOwnerScoreSnapshot ScoreSnapshot(string ownerId)
    {
        lock (gate)
        {
            var score = ScoreFor(ownerId);
            return new(ownerId, score.Score, score.Counts, score.ReceiptCount);
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

    private PvpSkillShotScoreState ScoreFor(string ownerId)
    {
        if (ownerId == localOwnerId) return localScore;
        if (ownerId == opponentOwnerId) return opponentScore;
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

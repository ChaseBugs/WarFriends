using System.Buffers.Binary;

namespace War.BattleServer;

/// <summary>
/// Two allied participants share one source mission, AI spawn state, and objective.
/// This is battle authority only; network admission, AI damage, and rewards still
/// need Worker integration.
/// </summary>
public sealed class CoopMissionEngine
{
    private readonly HashSet<string> participants = new(StringComparer.Ordinal);
    private readonly HashSet<string> ready = new(StringComparer.Ordinal);
    private readonly Dictionary<string, int> participantScores = new(StringComparer.Ordinal);
    private readonly Dictionary<string, (ulong LastTick, int Count)> playerKillStreaks =
        new(StringComparer.Ordinal);
    private readonly MissionObjectiveState objective;
    private readonly MissionAutomaticSpawnState spawns;
    private readonly string missionType;
    private ulong? lastReadyTick;
    private bool bossRegistered;

    // AI spawns use small per-match IDs. The boss has a separate host-owned
    // identity so an ordinary AI death cannot satisfy KillOpponent.
    internal const ulong BossEntityId = 1UL << 63;

    public int MissionIndex => objective.MissionIndex;
    public int MapStage { get; }
    public string MissionType => missionType;
    public int ObjectiveTarget { get; }
    public bool Started => objective.StartTick.HasValue;
    public ulong StartTick => objective.StartTick ?? 0;
    public ulong DeadlineTick => objective.DeadlineTick ?? 0;
    public MissionOutcome Outcome => objective.Outcome;
    public IReadOnlyCollection<string> Participants => participants.ToArray();
    public int EnemyKills => objective.EnemyKills;
    public int Score => objective.Score;
    internal int ScoreFor(string playerId) =>
        participantScores.TryGetValue(playerId, out int score) ? score : 0;

    public CoopMissionEngine(
        MissionCatalog catalog, int missionIndex, Func<int, int>? chooseBehaviour = null)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        MissionRule rule = catalog.Get(missionIndex);
        MapStage = rule.MapStage;
        missionType = rule.MissionType;
        ObjectiveTarget = rule.Objective ?? 0;
        objective = catalog.CreateObjectiveState(missionIndex);
        spawns = catalog.CreateAutomaticSpawnState(missionIndex, chooseBehaviour);
    }

    public bool Admit(string playerId)
    {
        if (Started || participants.Count >= 2 || !IsCanonicalId(playerId))
            return false;
        if (!participants.Add(playerId))
            return false;
        participantScores.Add(playerId, 0);
        return true;
    }

    public bool MarkReady(string playerId, ulong tick)
    {
        if (!participants.Contains(playerId) || Started || tick > 10_000_000 ||
            lastReadyTick.HasValue && tick < lastReadyTick.Value)
            return false;
        ready.Add(playerId);
        lastReadyTick = tick;
        if (participants.Count == 2 && ready.Count == 2)
        {
            objective.Start(tick);
            spawns.Start(tick);
        }
        return true;
    }

    public bool Leave(string playerId)
    {
        if (!participants.Remove(playerId))
            return false;
        ready.Remove(playerId);
        if (Started && Outcome == MissionOutcome.InProgress)
        {
            objective.Fail();
            spawns.Finish();
        }
        return true;
    }

    public bool AdvanceTick(ulong tick)
    {
        if (!objective.AdvanceClock(tick))
            return false;
        spawns.Finish();
        return true;
    }

    public int? SelectAutomaticBehaviour(ulong tick)
    {
        return Outcome == MissionOutcome.InProgress
            ? spawns.SelectAutomaticBehaviour(tick) : null;
    }

    public bool ConfirmAutomaticSpawn(int behaviourIndex, ulong entityId, ulong tick)
    {
        return Outcome == MissionOutcome.InProgress &&
            spawns.ConfirmSpawn(behaviourIndex, entityId, tick);
    }

    public IReadOnlyList<int> DueTimedEvents(ulong tick)
    {
        return Outcome == MissionOutcome.InProgress ? spawns.DueTimedEvents(tick) : [];
    }

    public bool ConfirmTimedEventSpawn(int eventIndex, ulong entityId, ulong tick)
    {
        return Outcome == MissionOutcome.InProgress &&
            spawns.ConfirmTimedEventSpawn(eventIndex, entityId, tick);
    }

    public bool ConfirmAiDeath(ulong entityId, ulong tick)
    {
        if (!Started || Outcome != MissionOutcome.InProgress ||
            tick < objective.StartTick!.Value ||
            tick >= objective.DeadlineTick!.Value ||
            !spawns.ConfirmDeath(entityId))
            return false;

        if (missionType == "KillXEnemies")
        {
            // Entity IDs are unique for this mission. Encode one as the replay
            // receipt only after the host has confirmed that entity's death.
            string eventId = KillEventId(MissionIndex, entityId);
            if (!objective.RecordEnemyKill(eventId, tick))
                throw new InvalidDataException("Confirmed AI death failed mission objective replay.");
            if (Outcome != MissionOutcome.InProgress)
                spawns.Finish();
        }
        return true;
    }

    /// <summary>
    /// Records a Score-mission death only after host combat has established the
    /// killer and the source damage branch. No client score or flag is accepted.
    /// </summary>
    internal bool ConfirmAttributedAiDeath(ulong entityId, string creditedPlayerId,
        CoopEnemyKillCredit credit, CoopSkillShotScoreCatalog scores, ulong tick)
    {
        if (missionType != "Score" || !participants.Contains(creditedPlayerId) ||
            !Started || Outcome != MissionOutcome.InProgress ||
            tick < StartTick || tick >= DeadlineTick)
            return false;

        ArgumentNullException.ThrowIfNull(scores);
        int nextStreak = 0;
        int comboFlag = 0;
        if (credit == CoopEnemyKillCredit.Player)
        {
            bool hasPrevious = playerKillStreaks.TryGetValue(creditedPlayerId,
                out var previousKill);
            if (hasPrevious && tick < previousKill.LastTick)
                return false;
            bool continuesCombo = hasPrevious &&
                tick - previousKill.LastTick <
                    CoopSkillShotScoreCatalog.ComboWindowTicks;
            nextStreak = continuesCombo ? checked(previousKill.Count + 1) : 1;
            comboFlag = nextStreak switch
            {
                2 => CoopSkillShotScoreCatalog.DoubleKillFlag,
                3 => CoopSkillShotScoreCatalog.TripleKillFlag,
                > 3 => CoopSkillShotScoreCatalog.MultiKillFlag,
                _ => 0
            };
        }
        int earnedPoints = scores.PointsForConfirmedEnemyKill(credit, comboFlag);
        if (earnedPoints <= 0 || objective.Score > 1_000_000_000 - earnedPoints ||
            !spawns.ConfirmDeath(entityId))
            return false;

        string eventId = KillEventId(MissionIndex, entityId);
        if (!objective.RecordScore(eventId, earnedPoints, tick))
            throw new InvalidDataException("Confirmed skill-shot failed mission objective replay.");
        participantScores[creditedPlayerId] =
            checked(participantScores[creditedPlayerId] + earnedPoints);
        if (credit == CoopEnemyKillCredit.Player)
            playerKillStreaks[creditedPlayerId] = (tick, nextStreak);
        if (Outcome != MissionOutcome.InProgress)
            spawns.Finish();
        return true;
    }

    internal bool RegisterBoss(ulong entityId, ulong tick)
    {
        if (missionType != "KillOpponent" || !Started ||
            Outcome != MissionOutcome.InProgress || bossRegistered ||
            entityId != BossEntityId || tick < StartTick || tick >= DeadlineTick)
            return false;
        bossRegistered = true;
        return true;
    }

    internal bool ConfirmBossDeath(ulong entityId, ulong tick)
    {
        if (missionType != "KillOpponent" || !bossRegistered ||
            entityId != BossEntityId || Outcome != MissionOutcome.InProgress)
            return false;
        string eventId = KillEventId(MissionIndex, entityId);
        if (!objective.RecordBossKilled(eventId, tick))
            return false;
        spawns.Finish();
        return true;
    }

    private static string KillEventId(int missionIndex, ulong entityId)
    {
        Span<byte> bytes = stackalloc byte[16];
        BinaryPrimitives.WriteUInt64LittleEndian(bytes, entityId);
        BinaryPrimitives.WriteInt32LittleEndian(bytes[8..], missionIndex);
        BinaryPrimitives.WriteUInt32LittleEndian(bytes[12..], 0x4D495353); // MISS
        return new Guid(bytes).ToString("N");
    }

    private static bool IsCanonicalId(string? value)
    {
        return Guid.TryParseExact(value, "N", out Guid parsed) &&
            value == parsed.ToString("N");
    }
}

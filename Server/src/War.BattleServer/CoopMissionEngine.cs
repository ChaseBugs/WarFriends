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
        return participants.Add(playerId);
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

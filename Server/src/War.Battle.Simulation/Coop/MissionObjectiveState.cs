namespace War.BattleServer;

/// <summary>
/// Objective progress for one source-backed mission. Callers must supply events
/// confirmed by the battle simulation, never a player's claimed result or reward.
/// </summary>
public sealed class MissionObjectiveState
{
    private const int MaximumReceipts = 100_000;
    private readonly HashSet<string> acceptedEvents = new(StringComparer.Ordinal);
    private readonly MissionRule rule;
    private bool _isDeathCascadeActive;

    public int MissionIndex => rule.Index;
    public int EnemyKills { get; private set; }
    public int Score { get; private set; }
    public ulong? StartTick { get; private set; }
    public ulong? DeadlineTick { get; private set; }
    public MissionOutcome Outcome { get; private set; } = MissionOutcome.InProgress;

    internal MissionObjectiveState(MissionRule rule)
    {
        this.rule = rule ?? throw new ArgumentNullException(nameof(rule));
    }

    public bool Start(ulong tick)
    {
        if (StartTick.HasValue)
            return false;

        ulong durationTicks = checked((ulong)rule.TimeSeconds * MatchManifest.TickRate);
        ulong deadline = checked(tick + durationTicks);
        StartTick = tick;
        DeadlineTick = deadline;
        return true;
    }

    public bool RecordEnemyKill(string eventId, ulong tick)
    {
        if (rule.MissionType != "KillXEnemies" || !AcceptEvent(eventId, tick))
            return false;

        EnemyKills = checked(EnemyKills + 1);
        if (!_isDeathCascadeActive && EnemyKills >= rule.Objective)
            Outcome = MissionOutcome.Succeeded;
        return true;
    }

    public bool RecordScore(string eventId, int earnedScore, ulong tick)
    {
        if (rule.MissionType != "Score" || earnedScore <= 0 ||
            earnedScore > 1_000_000 || Score > 1_000_000_000 - earnedScore ||
            !AcceptEvent(eventId, tick))
            return false;

        Score += earnedScore;
        if (!_isDeathCascadeActive && Score >= rule.Objective)
            Outcome = MissionOutcome.Succeeded;
        return true;
    }

    public bool RecordBossKilled(string eventId, ulong tick)
    {
        if (rule.MissionType != "KillOpponent" || !AcceptEvent(eventId, tick))
            return false;

        Outcome = MissionOutcome.Succeeded;
        return true;
    }

    internal void BeginDeathCascade()
    {
        if (!StartTick.HasValue || Outcome != MissionOutcome.InProgress || _isDeathCascadeActive)
        {
            throw new InvalidOperationException("A death cascade requires one running objective.");
        }

        _isDeathCascadeActive = true;
    }

    internal void CompleteDeathCascade()
    {
        if (!_isDeathCascadeActive)
        {
            throw new InvalidOperationException("No death cascade is active.");
        }

        _isDeathCascadeActive = false;
        bool reachedTarget = rule.MissionType == "KillXEnemies" && EnemyKills >= rule.Objective ||
            rule.MissionType == "Score" && Score >= rule.Objective;
        if (reachedTarget)
        {
            Outcome = MissionOutcome.Succeeded;
        }
    }

    public bool AdvanceClock(ulong tick)
    {
        if (!DeadlineTick.HasValue || Outcome != MissionOutcome.InProgress ||
            tick < DeadlineTick.Value)
            return false;

        // SurviveMission.EndMission succeeds only after remainingTime reaches zero.
        Outcome = rule.MissionType == "SurviveXSeconds"
            ? MissionOutcome.Succeeded : MissionOutcome.Failed;
        return true;
    }

    public bool Fail()
    {
        if (!StartTick.HasValue || Outcome != MissionOutcome.InProgress)
            return false;
        Outcome = MissionOutcome.Failed;
        return true;
    }

    private bool AcceptEvent(string eventId, ulong tick)
    {
        if (!StartTick.HasValue || !DeadlineTick.HasValue ||
            Outcome != MissionOutcome.InProgress ||
            tick < StartTick.Value || tick >= DeadlineTick.Value ||
            acceptedEvents.Count >= MaximumReceipts ||
            !War.Shared.CanonicalGuid.IsCanonical(eventId))
            return false;

        return acceptedEvents.Add(eventId);
    }
}

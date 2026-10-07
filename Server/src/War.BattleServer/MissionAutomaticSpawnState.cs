namespace War.BattleServer;

/// <summary>
/// WaveManager's automatic limits and Mission's timed-event accounting.
/// The host creates AI entities; this state accepts only confirmed creations
/// and deaths, and never accepts a client-submitted spawn or kill.
/// </summary>
public sealed class MissionAutomaticSpawnState
{
    private readonly MissionRule mission;
    private readonly Func<int, int> chooseBehaviour;
    private readonly int[] generated;
    private readonly int[] eventUnits;
    private readonly int[] killed;
    private readonly int[] eventSpawned;
    private readonly Dictionary<ulong, int> liveEntities = [];
    private readonly HashSet<ulong> seenEntityIds = [];
    private readonly HashSet<int> pendingEvents = [];
    private ulong? startTick;
    private ulong? lastEventSecond;
    private ulong nextAutomaticTick;
    private ulong? pendingAutomaticTick;
    private int? pendingAutomaticBehaviour;
    private bool finished;

    // WaveManager checks realTimeWithoutPauses > lastGenTime + 0.25f.
    // At the Worker's 30 Hz fixed step, the first later tick is tick eight.
    private const ulong AutomaticIntervalTicks = MatchManifest.TickRate / 4 + 1;

    internal MissionAutomaticSpawnState(MissionRule mission, Func<int, int>? choice)
    {
        this.mission = mission;
        chooseBehaviour = choice ?? Random.Shared.Next;
        generated = new int[mission.Behaviours.Count];
        eventUnits = new int[mission.Behaviours.Count];
        killed = new int[mission.Behaviours.Count];
        eventSpawned = new int[mission.Events.Count];
    }

    public int LiveCount => generated.Sum() - killed.Sum();

    public bool Start(ulong tick)
    {
        if (startTick.HasValue || finished)
            return false;
        startTick = tick;
        nextAutomaticTick = checked(tick + AutomaticIntervalTicks);
        return true;
    }

    public void Finish()
    {
        finished = true;
        pendingEvents.Clear();
        pendingAutomaticTick = null;
        pendingAutomaticBehaviour = null;
    }

    public IReadOnlyList<int> EligibleBehaviourIndexes(ulong tick)
    {
        if (!ActiveAt(tick) || LiveCount >= mission.MaxUnitsAtOnce)
            return [];

        var eligible = new List<int>();
        for (int index = 0; index < mission.Behaviours.Count; index++)
        {
            MissionSpawnBehaviour behavior = mission.Behaviours[index];
            int living = generated[index] - killed[index];
            bool belowSceneLimit = behavior.SceneLimit == 0 ||
                living < behavior.SceneLimit;
            bool belowMissionLimit = behavior.MissionLimit == 0 ||
                generated[index] < behavior.MissionLimit + eventUnits[index];
            if (belowSceneLimit && belowMissionLimit)
                eligible.Add(index);
        }
        return eligible.AsReadOnly();
    }

    public bool ConfirmSpawn(int behaviourIndex, ulong entityId, ulong tick)
    {
        if (entityId == 0 || seenEntityIds.Contains(entityId) ||
            pendingAutomaticTick != tick ||
            pendingAutomaticBehaviour != behaviourIndex ||
            !EligibleBehaviourIndexes(tick).Contains(behaviourIndex))
            return false;

        pendingAutomaticTick = null;
        pendingAutomaticBehaviour = null;
        generated[behaviourIndex] = checked(generated[behaviourIndex] + 1);
        liveEntities.Add(entityId, behaviourIndex);
        seenEntityIds.Add(entityId);
        return true;
    }

    public int? SelectAutomaticBehaviour(ulong tick)
    {
        if (!ActiveAt(tick) || tick < nextAutomaticTick)
            return null;

        IReadOnlyList<int> eligible = EligibleBehaviourIndexes(tick);
        int? selected = null;
        if (eligible.Count > 0)
        {
            int choiceIndex = chooseBehaviour(eligible.Count);
            if (choiceIndex < 0 || choiceIndex >= eligible.Count)
                throw new InvalidDataException("Mission spawn choice is outside the eligible list.");
            selected = eligible[choiceIndex];
        }

        nextAutomaticTick = checked(tick + AutomaticIntervalTicks);
        pendingAutomaticTick = selected.HasValue ? tick : null;
        pendingAutomaticBehaviour = selected;
        return selected;
    }

    public IReadOnlyList<int> DueTimedEvents(ulong tick)
    {
        if (!ActiveAt(tick))
            return [];

        ulong elapsedSecond = (tick - startTick!.Value) / MatchManifest.TickRate;
        if (lastEventSecond.HasValue && elapsedSecond <= lastEventSecond.Value)
            return [];

        lastEventSecond = elapsedSecond;
        pendingEvents.Clear();
        for (int index = 0; index < mission.Events.Count; index++)
        {
            MissionTimedEvent timedEvent = mission.Events[index];
            int targetCount = timedEvent.Count == 0 ? 1 : timedEvent.Count;
            if (eventSpawned[index] < targetCount &&
                elapsedSecond >= timedEvent.TimeSeconds &&
                CanSpawnEventBehaviour(timedEvent.Behaviour))
                pendingEvents.Add(index);
        }
        return pendingEvents.Order().ToArray();
    }

    public bool ConfirmTimedEventSpawn(int eventIndex, ulong entityId, ulong tick)
    {
        if (entityId == 0 || seenEntityIds.Contains(entityId) ||
            !pendingEvents.Contains(eventIndex) || !ActiveAt(tick) ||
            lastEventSecond != (tick - startTick!.Value) / MatchManifest.TickRate)
            return false;

        MissionTimedEvent timedEvent = mission.Events[eventIndex];
        int behaviourIndex = FindBehaviour(timedEvent.Behaviour);
        if (!CanSpawnEventBehaviour(timedEvent.Behaviour))
            return false;

        pendingEvents.Remove(eventIndex);
        eventSpawned[eventIndex] = checked(eventSpawned[eventIndex] + 1);
        if (behaviourIndex >= 0)
        {
            generated[behaviourIndex] = checked(generated[behaviourIndex] + 1);
            eventUnits[behaviourIndex] = checked(eventUnits[behaviourIndex] + 1);
        }
        // -1 means the timed behavior was absent from WaveManager's list.
        liveEntities.Add(entityId, behaviourIndex);
        seenEntityIds.Add(entityId);
        return true;
    }

    public bool ConfirmDeath(ulong entityId)
    {
        if (!liveEntities.Remove(entityId, out int behaviourIndex))
            return false;
        if (behaviourIndex >= 0)
            killed[behaviourIndex] = checked(killed[behaviourIndex] + 1);
        return true;
    }

    private bool CanSpawnEventBehaviour(string name)
    {
        int index = FindBehaviour(name);
        if (index < 0)
            return true;

        // Mission.UpdateMission checks this without WaveManager's zero-is-infinite
        // exception. Preserve that source behavior for a matching timed event.
        int living = generated[index] - killed[index];
        return living < mission.Behaviours[index].SceneLimit;
    }

    private int FindBehaviour(string name)
    {
        for (int index = 0; index < mission.Behaviours.Count; index++)
        {
            if (string.Equals(mission.Behaviours[index].Name,
                name, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return -1;
    }

    private bool ActiveAt(ulong tick)
    {
        return startTick.HasValue && !finished && tick >= startTick.Value &&
            (tick - startTick.Value) / MatchManifest.TickRate < (ulong)mission.TimeSeconds;
    }
}

namespace War.BattleServer;

/// <summary>
/// The automatic-spawn limits from WaveManager.UpdateGeneration.
/// A caller must create the AI entity before confirming its spawn here.
/// Timed mission events and their extra allowances are not handled by this state.
/// </summary>
public sealed class MissionAutomaticSpawnState
{
    private readonly MissionRule mission;
    private readonly int[] generated;
    private readonly int[] killed;
    private readonly Dictionary<ulong, int> liveEntities = [];

    internal MissionAutomaticSpawnState(MissionRule mission)
    {
        this.mission = mission;
        generated = new int[mission.Behaviours.Count];
        killed = new int[mission.Behaviours.Count];
    }

    public int LiveCount => liveEntities.Count;

    public IReadOnlyList<int> EligibleBehaviourIndexes()
    {
        if (LiveCount >= mission.MaxUnitsAtOnce)
            return [];

        var eligible = new List<int>();
        for (int index = 0; index < mission.Behaviours.Count; index++)
        {
            MissionSpawnBehaviour behavior = mission.Behaviours[index];
            int living = generated[index] - killed[index];
            bool belowSceneLimit = behavior.SceneLimit == 0 ||
                living < behavior.SceneLimit;
            bool belowMissionLimit = behavior.MissionLimit == 0 ||
                generated[index] < behavior.MissionLimit;
            if (belowSceneLimit && belowMissionLimit)
                eligible.Add(index);
        }
        return eligible.AsReadOnly();
    }

    public bool ConfirmSpawn(int behaviourIndex, ulong entityId)
    {
        if (entityId == 0 || liveEntities.ContainsKey(entityId) ||
            !EligibleBehaviourIndexes().Contains(behaviourIndex))
            return false;

        // This records a host-created entity; no Client command can allocate one.
        generated[behaviourIndex] = checked(generated[behaviourIndex] + 1);
        liveEntities.Add(entityId, behaviourIndex);
        return true;
    }

    public bool ConfirmDeath(ulong entityId)
    {
        if (!liveEntities.Remove(entityId, out int behaviourIndex))
            return false;

        killed[behaviourIndex] = checked(killed[behaviourIndex] + 1);
        return true;
    }
}

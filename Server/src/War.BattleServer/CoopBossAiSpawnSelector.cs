namespace War.BattleServer;

/// <summary>
/// Source enemy spawn candidates for a BotMission on its multiplayer map.
/// Selection and entity creation remain host-owned in the future boss runtime.
/// </summary>
public sealed class CoopBossAiSpawnSelector
{
    private readonly RecoveredBattleMap map;
    private readonly ArmySpawnPointCatalog spawns;

    public CoopBossAiSpawnSelector(MissionCatalog missions,
        ArmySpawnPointCatalog spawns, RecoveredBattleMap map, int missionIndex)
    {
        ArgumentNullException.ThrowIfNull(missions);
        this.spawns = spawns ?? throw new ArgumentNullException(nameof(spawns));
        this.map = map ?? throw new ArgumentNullException(nameof(map));
        MissionRule mission = missions.Get(missionIndex);
        MissionMapRule expected = missions.MapForMission(missionIndex);
        if (mission.MissionType != "KillOpponent" ||
            map.Source != "Assets/Scenes/" + expected.Scene + ".unity" ||
            map.SourceHash != expected.SceneSha256)
            throw new InvalidDataException("Boss AI spawn map differs from the mission.");

        // A mission must be spawnable in full before it can start. The Client
        // routes each behavior through a named MapDefinition collection.
        foreach (MissionSpawnBehaviour behavior in mission.Behaviours)
            RequireCandidates(behavior.Name);
        foreach (MissionTimedEvent timedEvent in mission.Events)
            RequireCandidates(timedEvent.Behaviour);
    }

    public IReadOnlyList<ArmySpawnPoint> Candidates(string behaviour)
    {
        string collection = CoopAiSpawnSelector.CollectionFor(behaviour);
        return spawns.ForMap(map)
            .Where(point => point.Collection == collection &&
                point.Fraction == 1 &&
                (collection != "spawnPointsCollection" ||
                    point.ComponentType is "SpawnPoint" or "SpawnPointParachute"))
            .ToArray();
    }

    private void RequireCandidates(string behaviour)
    {
        if (Candidates(behaviour).Count == 0)
            throw new InvalidDataException(
                $"Boss scene {map.Source} has no enemy spawn for {behaviour}.");
    }
}

namespace War.BattleServer;

/// <summary>
/// Resolves a recovered mission unit to enemy spawn anchors in its source scene.
/// The Client chooses an accepted point; the host must make that choice
/// when it creates an AI entity so a client cannot place enemies on allied points.
/// </summary>
public sealed class CoopAiSpawnSelector
{
    private readonly CoopMapSpawnPoints map;

    public CoopAiSpawnSelector(
        MissionCatalog missions, CoopSpawnPointCatalog spawns, int missionIndex)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(spawns);
        map = spawns.MapForMission(missions, missionIndex);

        // Fail before play if a recovered mission requests a unit for which its
        // scene has no matching enemy collection.
        MissionRule mission = missions.Get(missionIndex);
        foreach (MissionSpawnBehaviour behaviour in mission.Behaviours)
            RequireCandidates(behaviour.Name);
        foreach (MissionTimedEvent timedEvent in mission.Events)
            RequireCandidates(timedEvent.Behaviour);
    }

    public IReadOnlyList<CoopSpawnPoint> Candidates(string behaviour)
    {
        string collection = CollectionFor(behaviour);
        CoopSpawnPoint[] matching = map.EnemySpawnPoints
            .Where(point => point.Collection == collection)
            .ToArray();
        if (collection != "spawnPointsCollection")
            return matching;

        // MainScene sets canUseParachute only for Parachuter. Its recovered
        // PickSpawnPoint returns the first accepted parachute anchor before
        // considering a random normal point. Other mission soldiers cannot
        // use the elevated parachute anchors, even if they share this list.
        if (behaviour == "Parachuter")
        {
            CoopSpawnPoint? parachute = matching.FirstOrDefault(point =>
                point.ComponentType == "SpawnPointParachute");
            if (parachute != null)
                return [parachute];
        }
        return matching.Where(point => point.ComponentType == "SpawnPoint")
            .ToArray();
    }

    private void RequireCandidates(string behaviour)
    {
        if (Candidates(behaviour).Count == 0)
            throw new InvalidDataException(
                $"Co-op scene {map.Scene} has no enemy spawn for {behaviour}.");
    }

    internal static string CollectionFor(string behaviour)
    {
        return behaviour.ToLowerInvariant() switch
        {
            "drone" => "spawnPointsCollectionDrones",
            // Recovered Mission.behavioursDictionary maps Helicopter to the
            // assault-helicopter behavior, DeployHeli to the transport heli.
            "helicopter" => "spawnPointsCollectionAssaultHelis",
            "deployheli" => "spawnPointsCollectionHelicopters",
            "humvee" or "buggy" or "tank" or "transporter" =>
                "spawnPointsCollectionCars",
            "assaulter" or "sniper" or "grenadier" or "shotgunner" or
            "parachuter" or "minigunner" or "rocketlauncher" or "swat" or
            "engineer" or "machinegunner" or "scifi" or "commando" or
            "flamethrower" or "gunslinger" or "warper" or "mortar" or "mech" =>
                "spawnPointsCollection",
            _ => throw new InvalidDataException(
                $"No recovered co-op spawn rule for {behaviour}.")
        };
    }
}

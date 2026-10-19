using War.BattleServer;

/// <summary>Checks source Normal/fraction filtering and ordered host choice for the no-free-point branch.</summary>
internal static class CoopCrewFallbackTests
{
    internal static int Run(MissionCatalog missions, CoopSpawnPointCatalog spawns)
    {
        var selector = new CoopAiSpawnSelector(missions, spawns, 0);
        CoopSpawnPoint[] expected = spawns.MapForMission(missions, 0).SpawnPoints.Where(point =>
            point.Collection == "spawnPointsCollection" && point.ComponentType == "SpawnPoint" &&
            point.Fraction == 1).ToArray();
        if (expected.Length == 0)
        {
            throw new Exception("Crew fallback fixture lost its enemy Normal spawns.");
        }
        for (int index = 0; index < expected.Length; index++)
        {
            CoopSpawnPoint selected = selector.SelectHelicopterCrewFallback(count =>
            {
                if (count != expected.Length)
                {
                    throw new Exception("Crew fallback included an allied, special or parachute spawn.");
                }
                return index;
            });
            if (selected != expected[index])
            {
                throw new Exception("Crew fallback changed the source spawn order.");
            }
        }
        foreach (int invalid in new[] { -1, expected.Length })
        {
            try
            {
                selector.SelectHelicopterCrewFallback(_ => invalid);
                throw new Exception("Crew fallback accepted an out-of-range host draw.");
            }
            catch (InvalidDataException)
            {
                // Invalid host choices cannot be clamped into a valid movement target.
            }
        }
        return expected.Length + 2;
    }
}

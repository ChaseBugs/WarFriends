using War.BattleServer;

internal static class CoopAirWaypointCatalogTests
{
    internal static int Run(string directory)
    {
        MissionCatalog missions = MissionCatalog.Load(Path.Combine(
            directory, "recovered-mission-catalog.json"));
        CoopSpawnPointCatalog spawns = CoopSpawnPointCatalog.Load(Path.Combine(
            directory, "recovered-coop-spawn-points.json"), missions);
        CoopAirWaypointCatalog routes = CoopAirWaypointCatalog.Load(Path.Combine(
            directory, "recovered-coop-air-waypoint-routes.json"), spawns);

        int checkedRoutes = 0;
        foreach (CoopMapSpawnPoints map in spawns.Maps)
        {
            foreach (CoopSpawnPoint spawn in map.SpawnPoints.Where(point =>
                point.Collection is "spawnPointsCollectionDrones" or
                    "spawnPointsCollectionAssaultHelis" or
                    "spawnPointsCollectionHelicopters"))
            {
                AirWaypointRoute route = routes.ForSpawn(map, spawn.ComponentFileId);
                if (route.Waypoints[route.JoinIndex].ComponentFileId <= 0 ||
                    route.PathComponentFileId <= 0)
                    throw new Exception("Co-op air path lost its source join.");
                checkedRoutes++;
            }
        }
        if (checkedRoutes != 23)
            throw new Exception("Co-op air route coverage changed.");

        CoopMapSpawnPoints desert = spawns.Maps[0];
        int[] dronePaths = desert.SpawnPoints
            .Where(point => point.Collection == "spawnPointsCollectionDrones")
            .Select(point => routes.ForSpawn(desert, point.ComponentFileId).PathComponentFileId)
            .ToArray();
        if (dronePaths.Length != 4 || dronePaths.Distinct().Count() != 2)
            throw new Exception("Desert drone anchors no longer share two reservable paths.");
        return checkedRoutes + 1;
    }
}

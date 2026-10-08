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

        CoopSpawnPoint[] anchors = desert.SpawnPoints.Where(point =>
            point.Collection == "spawnPointsCollectionDrones" && point.Fraction == 1).ToArray();
        var reservations = new CoopAirPathReservations(routes, desert);
        CoopSpawnPoint first = reservations.ChooseDrone(anchors, _ => 0)
            ?? throw new Exception("First Drone path was unavailable.");
        reservations.Reserve(1, first);
        CoopSpawnPoint second = reservations.ChooseDrone(anchors, _ => 0)
            ?? throw new Exception("Second Drone path was unavailable.");
        if (routes.ForSpawn(desert, first.ComponentFileId).PathComponentFileId ==
            routes.ForSpawn(desert, second.ComponentFileId).PathComponentFileId)
            throw new Exception("Two live co-op Drones selected the same path.");
        reservations.Reserve(2, second);
        if (reservations.ChooseDrone(anchors, _ => 0) != null)
            throw new Exception("An occupied co-op Drone path was offered again.");
        reservations.Release(1);
        if (reservations.ChooseDrone(anchors, _ => 0) == null ||
            reservations.PathFor(1) != null || reservations.PathFor(2) == null)
            throw new Exception("Co-op Drone death did not free exactly its path.");

        CoopMapSpawnPoints snow = spawns.Maps[1];
        CoopSpawnPoint[] assaultAnchors = snow.SpawnPoints.Where(point =>
            point.Collection == "spawnPointsCollectionAssaultHelis" &&
            point.Fraction == 1).ToArray();
        var assaultReservations = new CoopAirPathReservations(routes, snow);
        CoopSpawnPoint assault = assaultReservations.ChooseAssaultHelicopter(
            assaultAnchors, count => count - 1) ??
            throw new Exception("Co-op Assault Helicopter route was unavailable.");
        assaultReservations.Reserve(3, assault);
        if (assaultReservations.ChooseAssaultHelicopter(assaultAnchors, _ => 0) != null)
            throw new Exception("An occupied Assault Helicopter route was reused.");
        assaultReservations.Release(3);
        if (assaultReservations.ChooseAssaultHelicopter(assaultAnchors, _ => 0) == null)
            throw new Exception("Assault Helicopter death did not release its route.");

        CoopSpawnPoint[] transportAnchors = snow.SpawnPoints.Where(point =>
            point.Collection == "spawnPointsCollectionHelicopters" &&
            point.Fraction == 1).ToArray();
        CoopSpawnPoint transport = assaultReservations.ChooseTransportHelicopter(
            transportAnchors, _ => 0) ??
            throw new Exception("Co-op Transport Helicopter route was unavailable.");
        assaultReservations.Reserve(4, transport);
        if (assaultReservations.ChooseTransportHelicopter(transportAnchors, _ => 0) != null)
            throw new Exception("An occupied Transport Helicopter route was reused.");
        assaultReservations.Release(4);
        if (assaultReservations.ChooseTransportHelicopter(transportAnchors, _ => 0) == null)
            throw new Exception("Transport Helicopter death did not release its route.");
        return checkedRoutes + 11;
    }
}

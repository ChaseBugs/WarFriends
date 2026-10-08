namespace War.BattleServer;

/// <summary>
/// Owns the recovered air-unit path.usedByEntity rule for one co-op match.
/// Several scene anchors can join the same path, so reserving an anchor is
/// insufficient to keep two living drones off that path.
/// </summary>
internal sealed class CoopAirPathReservations
{
    private readonly CoopAirWaypointCatalog routes;
    private readonly CoopMapSpawnPoints map;
    private readonly Dictionary<int, ulong> ownersByPath = [];
    private readonly Dictionary<ulong, int> pathsByOwner = [];

    internal CoopAirPathReservations(CoopAirWaypointCatalog routes,
        CoopMapSpawnPoints map)
    {
        this.routes = routes ?? throw new ArgumentNullException(nameof(routes));
        this.map = map ?? throw new ArgumentNullException(nameof(map));
    }

    internal CoopSpawnPoint? ChooseDrone(
        IReadOnlyList<CoopSpawnPoint> anchors, Func<int, int> chooseIndex)
    {
        ArgumentNullException.ThrowIfNull(anchors);
        ArgumentNullException.ThrowIfNull(chooseIndex);
        var available = new List<CoopSpawnPoint>();
        foreach (CoopSpawnPoint anchor in anchors)
        {
            if (anchor.Collection != "spawnPointsCollectionDrones" ||
                anchor.Fraction != 1)
                throw new InvalidDataException("Co-op Drone candidate is not an enemy Drone anchor.");
            int pathId = routes.ForSpawn(map, anchor.ComponentFileId).PathComponentFileId;
            if (!ownersByPath.ContainsKey(pathId))
                available.Add(anchor);
        }
        if (available.Count == 0)
            return null;

        // Recovered Drone.Spawn chooses randomly among the first two only
        // when more than two anchors are free; otherwise it takes the first.
        if (available.Count <= 2)
            return available[0];
        int selected = chooseIndex(2);
        if (selected < 0 || selected >= 2)
            throw new InvalidDataException("Co-op Drone choice is outside its source candidates.");
        return available[selected];
    }

    internal CoopSpawnPoint? ChooseAssaultHelicopter(
        IReadOnlyList<CoopSpawnPoint> anchors, Func<int, int> chooseIndex)
    {
        ArgumentNullException.ThrowIfNull(anchors);
        ArgumentNullException.ThrowIfNull(chooseIndex);
        var available = new List<CoopSpawnPoint>();
        foreach (CoopSpawnPoint anchor in anchors)
        {
            if (anchor.Collection != "spawnPointsCollectionAssaultHelis" ||
                anchor.Fraction != 1)
                throw new InvalidDataException("Co-op Assault Helicopter candidate has the wrong identity.");
            int pathId = routes.ForSpawn(map, anchor.ComponentFileId).PathComponentFileId;
            if (!ownersByPath.ContainsKey(pathId))
                available.Add(anchor);
        }
        if (available.Count == 0)
            return null;

        // AssaultHelicopter.Spawn samples the entire available list.
        int selected = chooseIndex(available.Count);
        if (selected < 0 || selected >= available.Count)
            throw new InvalidDataException("Co-op Assault Helicopter choice is outside its source candidates.");
        return available[selected];
    }

    internal void Reserve(ulong entityId, CoopSpawnPoint anchor)
    {
        if (entityId == 0 || pathsByOwner.ContainsKey(entityId))
            throw new InvalidDataException("Co-op air unit has an invalid or repeated entity ID.");
        int pathId = routes.ForSpawn(map, anchor.ComponentFileId).PathComponentFileId;
        if (!ownersByPath.TryAdd(pathId, entityId))
            throw new InvalidDataException("Co-op air path is already reserved.");
        pathsByOwner.Add(entityId, pathId);
    }

    internal void Release(ulong entityId)
    {
        if (pathsByOwner.Remove(entityId, out int pathId))
            ownersByPath.Remove(pathId);
    }

    internal int? PathFor(ulong entityId) =>
        pathsByOwner.TryGetValue(entityId, out int pathId) ? pathId : null;
}

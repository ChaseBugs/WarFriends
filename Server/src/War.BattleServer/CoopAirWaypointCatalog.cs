using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Air routes extracted from the five co-op scenes. A path may have several join anchors.</summary>
public sealed class CoopAirWaypointCatalog
{
    private const string SourceSha256 = "deeae638d318bb330c395a275303a7ede3ea9ef7f3b5b32c5447f880f3029741";
    private const string SpawnSha256 = "aeed31ebccefbfb9b12d83c071f4face92c6cec241000b18929e7222f09d4402";
    private static readonly int[] ExpectedCounts = [5, 4, 4, 5, 5];
    private readonly IReadOnlyDictionary<string, IReadOnlyDictionary<int, AirWaypointRoute>> routes;

    private CoopAirWaypointCatalog(Dictionary<string, IReadOnlyDictionary<int, AirWaypointRoute>> routes)
    {
        this.routes = new ReadOnlyDictionary<string, IReadOnlyDictionary<int, AirWaypointRoute>>(routes);
    }

    public AirWaypointRoute ForSpawn(CoopMapSpawnPoints map, int spawnComponentFileId)
    {
        if (!routes.TryGetValue(map.Scene, out var mapRoutes) ||
            !mapRoutes.TryGetValue(spawnComponentFileId, out var route))
            throw new InvalidDataException("Unknown co-op air spawn route.");
        return route;
    }

    public static CoopAirWaypointCatalog Load(string path, CoopSpawnPointCatalog spawns)
    {
        ArgumentNullException.ThrowIfNull(spawns);
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != SourceSha256)
            throw new InvalidDataException("Co-op air route artifact differs from recovered scenes.");
        using var document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 32 });
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "spawnSourceSha256", "maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("spawnSourceSha256").GetString() != SpawnSha256)
            throw new InvalidDataException("Co-op air routes have the wrong spawn source.");

        JsonElement maps = root.GetProperty("maps");
        if (maps.ValueKind != JsonValueKind.Array || maps.GetArrayLength() != spawns.Maps.Count)
            throw new InvalidDataException("Co-op air routes need all five maps.");
        var accepted = new Dictionary<string, IReadOnlyDictionary<int, AirWaypointRoute>>(StringComparer.Ordinal);
        for (int index = 0; index < maps.GetArrayLength(); index++)
        {
            CoopMapSpawnPoints map = spawns.Maps[index];
            JsonElement entry = maps[index];
            RequireFields(entry, "scene", "sceneSha256", "routes");
            if (entry.GetProperty("scene").GetString() != map.Scene ||
                entry.GetProperty("sceneSha256").GetString() != map.SceneSha256)
                throw new InvalidDataException("Co-op air route map differs from its scene.");
            CoopSpawnPoint[] airSpawns = map.SpawnPoints.Where(IsAirSpawn).ToArray();
            JsonElement rows = entry.GetProperty("routes");
            if (rows.ValueKind != JsonValueKind.Array ||
                rows.GetArrayLength() != ExpectedCounts[index] ||
                rows.GetArrayLength() != airSpawns.Length)
                throw new InvalidDataException("Co-op air routes are incomplete.");
            var mapRoutes = new Dictionary<int, AirWaypointRoute>();
            var pathDefinitions = new Dictionary<int, (float Radius, DroneWaypoint[] Points)>();
            for (int routeIndex = 0; routeIndex < airSpawns.Length; routeIndex++)
            {
                CoopSpawnPoint spawn = airSpawns[routeIndex];
                JsonElement row = rows[routeIndex];
                RequireFields(row, "spawnComponentFileId", "collection", "fraction",
                    "pathComponentFileId", "joinWaypointFileId", "joinIndex",
                    "stopWaypointFileId", "stopIndex", "radius", "waypoints");
                int pathId = row.GetProperty("pathComponentFileId").GetInt32();
                if (row.GetProperty("spawnComponentFileId").GetInt32() != spawn.ComponentFileId ||
                    row.GetProperty("collection").GetString() != spawn.Collection ||
                    row.GetProperty("fraction").GetInt32() != spawn.Fraction || pathId <= 0)
                    throw new InvalidDataException("Co-op air spawn identity differs from source.");
                float radius = row.GetProperty("radius").GetSingle();
                JsonElement points = row.GetProperty("waypoints");
                if (!float.IsFinite(radius) || radius <= 0 || radius > 100 ||
                    points.ValueKind != JsonValueKind.Array || points.GetArrayLength() is < 2 or > 100)
                    throw new InvalidDataException("Invalid co-op air path dimensions.");
                var waypoints = new DroneWaypoint[points.GetArrayLength()];
                var waypointIds = new HashSet<int>();
                for (int pointIndex = 0; pointIndex < waypoints.Length; pointIndex++)
                {
                    JsonElement point = points[pointIndex];
                    RequireFields(point, "componentFileId", "transformFileId", "index",
                        "stayTime", "worldPosition", "transformChain");
                    int waypointId = point.GetProperty("componentFileId").GetInt32();
                    float stayTime = point.GetProperty("stayTime").GetSingle();
                    if (waypointId <= 0 || !waypointIds.Add(waypointId) ||
                        point.GetProperty("transformFileId").GetInt32() <= 0 ||
                        point.GetProperty("index").GetInt32() != pointIndex ||
                        !float.IsFinite(stayTime) || stayTime < 0 || stayTime > 3600)
                        throw new InvalidDataException("Invalid co-op air waypoint.");
                    waypoints[pointIndex] = new DroneWaypoint(waypointId,
                        ReadPosition(point.GetProperty("worldPosition")), stayTime);
                    // The extractor verifies every transform chain against the scene hash.
                    if (point.GetProperty("transformChain").ValueKind != JsonValueKind.Array ||
                        point.GetProperty("transformChain").GetArrayLength() == 0)
                        throw new InvalidDataException("Missing co-op air transform source.");
                }
                int joinIndex = row.GetProperty("joinIndex").GetInt32();
                int stopIndex = row.GetProperty("stopIndex").GetInt32();
                int joinId = row.GetProperty("joinWaypointFileId").GetInt32();
                int stopId = row.GetProperty("stopWaypointFileId").GetInt32();
                bool transport = spawn.Collection == "spawnPointsCollectionHelicopters";
                if (joinIndex < 0 || joinIndex >= waypoints.Length ||
                    waypoints[joinIndex].ComponentFileId != joinId ||
                    (transport ? stopIndex < 0 || stopIndex >= waypoints.Length ||
                                 stopIndex == joinIndex || waypoints[stopIndex].ComponentFileId != stopId
                               : stopIndex != -1 || stopId != 0))
                    throw new InvalidDataException("Invalid co-op air join or stop waypoint.");
                if (pathDefinitions.TryGetValue(pathId, out var existing) &&
                    (existing.Radius != radius || !existing.Points.SequenceEqual(waypoints)))
                    throw new InvalidDataException("Shared co-op air path has conflicting geometry.");
                pathDefinitions[pathId] = (radius, waypoints);
                mapRoutes.Add(spawn.ComponentFileId, new AirWaypointRoute(
                    spawn.ComponentFileId, pathId, joinIndex, stopIndex, radius,
                    Array.AsReadOnly(waypoints)));
            }
            accepted.Add(map.Scene, new ReadOnlyDictionary<int, AirWaypointRoute>(mapRoutes));
        }
        return new CoopAirWaypointCatalog(accepted);
    }

    private static bool IsAirSpawn(CoopSpawnPoint point) =>
        point.Collection is "spawnPointsCollectionDrones" or
            "spawnPointsCollectionAssaultHelis" or "spawnPointsCollectionHelicopters";

    private static Vector3 ReadPosition(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Array || value.GetArrayLength() != 3)
            throw new InvalidDataException("Invalid co-op air position.");
        var position = new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
        if (!float.IsFinite(position.X) || !float.IsFinite(position.Y) ||
            !float.IsFinite(position.Z) || position.Length() > 10000)
            throw new InvalidDataException("Invalid co-op air coordinates.");
        return position;
    }

    private static void RequireFields(JsonElement value, params string[] fields)
    {
        if (value.ValueKind != JsonValueKind.Object ||
            !value.EnumerateObject().Select(property => property.Name).Order()
                .SequenceEqual(fields.Order()))
            throw new InvalidDataException("Unexpected co-op air route fields.");
    }
}

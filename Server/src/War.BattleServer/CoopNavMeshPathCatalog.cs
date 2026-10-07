using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopDefendRoute
{
    public int From { get; }
    public int To { get; }
    public IReadOnlyList<Vector3> Corners { get; }

    internal CoopDefendRoute(int from, int to, Vector3[] corners)
    {
        From = from;
        To = to;
        Corners = new ReadOnlyCollection<Vector3>(corners);
    }
}

public sealed class CoopMapRoutes
{
    public int Stage { get; }
    public string Scene { get; }
    public IReadOnlyList<CoopDefendRoute> Routes { get; }

    internal CoopMapRoutes(int stage, string scene, CoopDefendRoute[] routes)
    {
        Stage = stage;
        Scene = scene;
        Routes = new ReadOnlyCollection<CoopDefendRoute>(routes);
    }

    public CoopDefendRoute Between(int from, int to)
    {
        if (from is < 0 or > 3 || to is < 0 or > 3 || from == to)
            throw new ArgumentOutOfRangeException(nameof(to));
        int index = from * 3 + (to < from ? to : to - 1);
        return Routes[index];
    }
}

/// <summary>Source-measured static paths, before dynamic player avoidance.</summary>
public sealed class CoopNavMeshPathCatalog
{
    public IReadOnlyList<CoopMapRoutes> Maps { get; }

    private CoopNavMeshPathCatalog(CoopMapRoutes[] maps)
    {
        Maps = new ReadOnlyCollection<CoopMapRoutes>(maps);
    }

    public CoopMapRoutes MapForMission(MissionCatalog missions, int missionIndex)
    {
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopMapRoutes map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene)
            throw new InvalidDataException("Co-op route scene differs from the mission.");
        return map;
    }

    public static CoopNavMeshPathCatalog Load(string path, MissionCatalog missions,
        CoopSpawnPointCatalog spawns, CoopNavMeshSourceCatalog navigation)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(spawns);
        ArgumentNullException.ThrowIfNull(navigation);
        string directory = Path.GetDirectoryName(path)!;
        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "spawnSourceSha256",
            "navigationSourceSha256", "maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("spawnSourceSha256").GetString() != Digest(
                Path.Combine(directory, "recovered-coop-spawn-points.json")) ||
            root.GetProperty("navigationSourceSha256").GetString() != Digest(
                Path.Combine(directory, "recovered-coop-navmesh-sources.json")))
            throw new InvalidDataException("Co-op routes differ from their source artifacts.");

        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 5)
            throw new InvalidDataException("Co-op route artifact needs five maps.");

        var maps = new CoopMapRoutes[5];
        for (int index = 0; index < maps.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireFields(entry, "stage", "scene", "sceneSha256",
                "navMeshSha256", "routes");
            MissionMapRule missionMap = missions.Maps[index];
            CoopMapSpawnPoints spawnMap = spawns.Maps[index];
            CoopNavMeshSource navMap = navigation.Maps[index];
            string scene = entry.GetProperty("scene").GetString() ?? "";
            if (entry.GetProperty("stage").GetInt32() != missionMap.Stage ||
                scene != missionMap.Scene || scene != spawnMap.Scene ||
                scene != navMap.Scene ||
                entry.GetProperty("sceneSha256").GetString() != missionMap.SceneSha256 ||
                entry.GetProperty("navMeshSha256").GetString() != navMap.Sha256)
                throw new InvalidDataException("Co-op routes have a mismatched source map.");

            JsonElement routeEntries = entry.GetProperty("routes");
            if (routeEntries.ValueKind != JsonValueKind.Array ||
                routeEntries.GetArrayLength() != 12)
                throw new InvalidDataException("Co-op map needs 12 ordered routes.");
            var routes = new CoopDefendRoute[12];
            int routeIndex = 0;
            for (int from = 0; from < 4; from++)
            for (int to = 0; to < 4; to++)
            {
                if (from == to) continue;
                JsonElement routeEntry = routeEntries[routeIndex];
                RequireFields(routeEntry, "from", "to", "corners");
                if (routeEntry.GetProperty("from").GetInt32() != from ||
                    routeEntry.GetProperty("to").GetInt32() != to)
                    throw new InvalidDataException("Co-op route order changed.");
                Vector3[] corners = ReadCorners(routeEntry.GetProperty("corners"));
                if (Vector3.Distance(corners[0], spawnMap.PlayerPositions[from].Position) > 0.25f ||
                    Vector3.Distance(corners[^1], spawnMap.PlayerPositions[to].Position) > 0.25f)
                    throw new InvalidDataException("Co-op route endpoint differs from its shield.");
                routes[routeIndex++] = new CoopDefendRoute(from, to, corners);
            }
            maps[index] = new CoopMapRoutes(missionMap.Stage, scene, routes);
        }
        return new CoopNavMeshPathCatalog(maps);
    }

    private static Vector3[] ReadCorners(JsonElement entries)
    {
        if (entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() is < 2 or > 16)
            throw new InvalidDataException("Co-op route has an invalid corner count.");
        var corners = new Vector3[entries.GetArrayLength()];
        for (int index = 0; index < corners.Length; index++)
        {
            JsonElement point = entries[index];
            if (point.ValueKind != JsonValueKind.Array || point.GetArrayLength() != 3)
                throw new InvalidDataException("Co-op route corner needs three coordinates.");
            var position = new Vector3(point[0].GetSingle(), point[1].GetSingle(),
                point[2].GetSingle());
            if (!float.IsFinite(position.X) || !float.IsFinite(position.Y) ||
                !float.IsFinite(position.Z) ||
                Math.Abs(position.X) > 10_000 || Math.Abs(position.Y) > 10_000 ||
                Math.Abs(position.Z) > 10_000)
                throw new InvalidDataException("Co-op route corner is outside the scene.");
            corners[index] = position;
        }
        return corners;
    }

    private static string Digest(string path) =>
        Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));

    private static void RequireFields(JsonElement entry, params string[] names)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != names.Length ||
            names.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op route artifact has unexpected fields.");
    }
}

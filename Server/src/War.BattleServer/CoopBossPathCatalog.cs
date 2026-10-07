using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopBossMapRoutes
{
    public int Stage { get; }
    public string Scene { get; }
    public IReadOnlyList<CoopDefendRoute> Routes { get; }

    internal CoopBossMapRoutes(int stage, string scene, CoopDefendRoute[] routes)
    {
        Stage = stage;
        Scene = scene;
        Routes = new ReadOnlyCollection<CoopDefendRoute>(routes);
    }

    public CoopDefendRoute Between(int from, int to)
    {
        if (from is < 0 or > 7 || to is < 0 or > 7 || from == to ||
            from / 4 != to / 4)
            throw new ArgumentOutOfRangeException(nameof(to));

        int localFrom = from % 4;
        int localTo = to % 4;
        int groupOffset = from < 4 ? 0 : 12;
        int routeIndex = groupOffset + localFrom * 3 +
            (localTo < localFrom ? localTo : localTo - 1);
        return Routes[routeIndex];
    }
}

/// <summary>Unity-measured paths between shields of the same boss-map faction.</summary>
public sealed class CoopBossPathCatalog
{
    private const string ReviewedArtifactSha256 =
        "12e42d2f5b492a5b8e499743096fb25c0ad5bc52ee512a9c098c866fd11eacee";

    public IReadOnlyList<CoopBossMapRoutes> Maps { get; }

    private CoopBossPathCatalog(CoopBossMapRoutes[] maps)
    {
        Maps = new ReadOnlyCollection<CoopBossMapRoutes>(maps);
    }

    public CoopBossMapRoutes MapForMission(MissionCatalog missions, int missionIndex)
    {
        MissionRule mission = missions.Get(missionIndex);
        if (mission.MissionType != "KillOpponent")
            throw new ArgumentOutOfRangeException(nameof(missionIndex));

        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopBossMapRoutes map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene)
            throw new InvalidDataException("Boss routes differ from the mission map.");
        return map;
    }

    public static CoopBossPathCatalog Load(string path, MissionCatalog missions,
        CoopBossAnchorCatalog anchors, ArmyNavMeshSourceCatalog navigation)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(anchors);
        ArgumentNullException.ThrowIfNull(navigation);

        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedArtifactSha256)
            throw new InvalidDataException("Boss routes differ from reviewed Unity paths.");

        string directory = Path.GetDirectoryName(Path.GetFullPath(path))!;
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "anchorSourceSha256",
            "navigationSourceSha256", "maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("anchorSourceSha256").GetString() != Digest(
                Path.Combine(directory, "recovered-coop-boss-anchors.json")) ||
            root.GetProperty("navigationSourceSha256").GetString() != Digest(
                Path.Combine(directory, "recovered-army-navmesh-sources.json")))
            throw new InvalidDataException("Boss routes differ from their source artifacts.");

        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 5)
            throw new InvalidDataException("Boss routes need five multiplayer maps.");

        var maps = new CoopBossMapRoutes[5];
        for (int mapIndex = 0; mapIndex < maps.Length; mapIndex++)
        {
            JsonElement entry = entries[mapIndex];
            RequireFields(entry, "stage", "scene", "sceneSha256",
                "navMeshSha256", "routes");
            MissionMapRule expected = missions.BossMaps[mapIndex];
            CoopBossMapAnchors sourceAnchors = anchors.Maps[mapIndex];
            string scene = entry.GetProperty("scene").GetString() ?? "";
            ArmyNavMeshSource sourceNavigation = navigation.Maps.Single(row =>
                row.Scene == "Assets/Scenes/" + scene + ".unity");
            if (entry.GetProperty("stage").GetInt32() != expected.Stage ||
                scene != expected.Scene || scene != sourceAnchors.Scene ||
                entry.GetProperty("sceneSha256").GetString() != expected.SceneSha256 ||
                entry.GetProperty("navMeshSha256").GetString() != sourceNavigation.Revision ||
                sourceNavigation.Scene != "Assets/Scenes/" + scene + ".unity" ||
                sourceNavigation.SceneRevision != expected.SceneSha256)
                throw new InvalidDataException("Boss route map differs from its source.");

            JsonElement routeEntries = entry.GetProperty("routes");
            if (routeEntries.ValueKind != JsonValueKind.Array ||
                routeEntries.GetArrayLength() != 24)
                throw new InvalidDataException("Boss map needs 24 faction routes.");

            var routes = new CoopDefendRoute[24];
            int routeIndex = 0;
            for (int group = 0; group < 2; group++)
            for (int localFrom = 0; localFrom < 4; localFrom++)
            for (int localTo = 0; localTo < 4; localTo++)
            {
                if (localFrom == localTo)
                    continue;
                int from = group * 4 + localFrom;
                int to = group * 4 + localTo;
                JsonElement routeEntry = routeEntries[routeIndex];
                RequireFields(routeEntry, "from", "to", "corners");
                if (routeEntry.GetProperty("from").GetInt32() != from ||
                    routeEntry.GetProperty("to").GetInt32() != to)
                    throw new InvalidDataException("Boss route order changed.");

                Vector3[] corners = ReadCorners(routeEntry.GetProperty("corners"));
                if (Vector3.Distance(corners[0], sourceAnchors.PlayerPositions[from].Position) > 0.25f ||
                    Vector3.Distance(corners[^1], sourceAnchors.PlayerPositions[to].Position) > 0.25f)
                    throw new InvalidDataException("Boss route endpoint differs from its shield.");
                routes[routeIndex++] = new CoopDefendRoute(from, to, corners);
            }
            maps[mapIndex] = new CoopBossMapRoutes(expected.Stage, scene, routes);
        }
        return new CoopBossPathCatalog(maps);
    }

    private static Vector3[] ReadCorners(JsonElement entries)
    {
        if (entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() is < 2 or > 16)
            throw new InvalidDataException("Boss route has an invalid corner count.");
        var corners = new Vector3[entries.GetArrayLength()];
        for (int index = 0; index < corners.Length; index++)
        {
            JsonElement point = entries[index];
            if (point.ValueKind != JsonValueKind.Array || point.GetArrayLength() != 3)
                throw new InvalidDataException("Boss route corner needs three coordinates.");
            var position = new Vector3(point[0].GetSingle(), point[1].GetSingle(),
                point[2].GetSingle());
            if (!float.IsFinite(position.X) || !float.IsFinite(position.Y) ||
                !float.IsFinite(position.Z) ||
                Math.Abs(position.X) > 10_000 || Math.Abs(position.Y) > 10_000 ||
                Math.Abs(position.Z) > 10_000)
                throw new InvalidDataException("Boss route corner is outside the scene.");
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
            throw new InvalidDataException("Boss route artifact has unexpected fields.");
    }
}

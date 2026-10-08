using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopPlayerAnchor(
    int Index, int ComponentFileId, int GameObjectFileId,
    int TransformFileId, bool Main, Vector3 Position)
{
    public Quaternion? SourceRotation { get; init; }
}

public sealed record CoopSpawnPoint(
    string Collection, int Order, int ComponentFileId, string ComponentType,
    int Fraction, int GameObjectFileId, int TransformFileId, Vector3 Position)
{
    public Quaternion? SourceRotation { get; init; }
}

public sealed class CoopMapSpawnPoints
{
    public int Stage { get; }
    public string Scene { get; }
    public string SceneSha256 { get; }
    public int MapDefinitionFileId { get; }
    public IReadOnlyList<CoopPlayerAnchor> PlayerPositions { get; }
    public IReadOnlyList<CoopSpawnPoint> SpawnPoints { get; }
    public IReadOnlyList<CoopSpawnPoint> EnemySpawnPoints { get; }

    internal CoopMapSpawnPoints(int stage, string scene, string sceneSha256,
        int mapDefinitionFileId, CoopPlayerAnchor[] players, CoopSpawnPoint[] spawns)
    {
        Stage = stage;
        Scene = scene;
        SceneSha256 = sceneSha256;
        MapDefinitionFileId = mapDefinitionFileId;
        PlayerPositions = new ReadOnlyCollection<CoopPlayerAnchor>(players);
        SpawnPoints = new ReadOnlyCollection<CoopSpawnPoint>(spawns);
        EnemySpawnPoints = new ReadOnlyCollection<CoopSpawnPoint>(
            spawns.Where(point => point.Fraction == 1).ToArray());
    }
}

/// <summary>Source scene anchors for future co-op AI placement and allied starts.</summary>
public sealed class CoopSpawnPointCatalog
{
    private const string SourceSha256 = "aeed31ebccefbfb9b12d83c071f4face92c6cec241000b18929e7222f09d4402";
    private static readonly int[] ExpectedSpawnCounts = [13, 13, 9, 14, 10];
    private static readonly HashSet<string> Collections = new(StringComparer.Ordinal)
    {
        "spawnPointsCollection", "spawnPointsCollectionDrones",
        "spawnPointsCollectionAssaultHelis", "spawnPointsCollectionCars",
        "spawnPointsCollectionHelicopters"
    };

    public IReadOnlyList<CoopMapSpawnPoints> Maps { get; }

    private CoopSpawnPointCatalog(CoopMapSpawnPoints[] maps)
    {
        Maps = new ReadOnlyCollection<CoopMapSpawnPoints>(maps);
    }

    public CoopMapSpawnPoints MapForMission(MissionCatalog missions, int missionIndex)
    {
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopMapSpawnPoints map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene || map.SceneSha256 != expected.SceneSha256)
            throw new InvalidDataException("Co-op spawn map differs from its mission scene.");
        return map;
    }

    public static CoopSpawnPointCatalog Load(string path, MissionCatalog missions)
    {
        ArgumentNullException.ThrowIfNull(missions);
        byte[] source = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(source)) != SourceSha256)
            throw new InvalidDataException("Co-op spawn artifact differs from the recovered source.");
        using var document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "maps");
        if (root.GetProperty("version").GetInt32() != 2)
            throw new InvalidDataException("Unknown co-op spawn artifact version.");
        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 5)
            throw new InvalidDataException("Co-op spawn artifact needs all five maps.");

        var maps = new CoopMapSpawnPoints[5];
        for (int index = 0; index < maps.Length; index++)
            maps[index] = ReadMap(entries[index], missions.Maps[index],
                ExpectedSpawnCounts[index]);
        return new CoopSpawnPointCatalog(maps);
    }

    private static CoopMapSpawnPoints ReadMap(
        JsonElement entry, MissionMapRule expected, int expectedSpawnCount)
    {
        RequireFields(entry, "stage", "scene", "sceneSha256",
            "mapDefinitionFileId", "playerPositions", "spawnPoints");
        int stage = entry.GetProperty("stage").GetInt32();
        string scene = entry.GetProperty("scene").GetString() ?? "";
        string hash = entry.GetProperty("sceneSha256").GetString() ?? "";
        int definitionId = PositiveId(entry, "mapDefinitionFileId");
        if (stage != expected.Stage || scene != expected.Scene ||
            hash != expected.SceneSha256)
            throw new InvalidDataException("Co-op spawn source scene does not match mission map.");

        CoopPlayerAnchor[] players = ReadPlayers(entry.GetProperty("playerPositions"));
        CoopSpawnPoint[] spawns = ReadSpawns(
            entry.GetProperty("spawnPoints"), expectedSpawnCount);
        return new CoopMapSpawnPoints(stage, scene, hash, definitionId, players, spawns);
    }

    private static CoopPlayerAnchor[] ReadPlayers(JsonElement entries)
    {
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 4)
            throw new InvalidDataException("Co-op map needs four allied defend positions.");
        var players = new CoopPlayerAnchor[4];
        var ids = new HashSet<int>();
        for (int index = 0; index < players.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireFields(entry, "index", "componentFileId", "gameObjectFileId",
                "transformFileId", "main", "worldPosition", "worldRotation");
            int componentId = PositiveId(entry, "componentFileId");
            if (entry.GetProperty("index").GetInt32() != index || !ids.Add(componentId))
                throw new InvalidDataException("Co-op defend positions are duplicated or unordered.");
            players[index] = new CoopPlayerAnchor(index, componentId,
                PositiveId(entry, "gameObjectFileId"),
                PositiveId(entry, "transformFileId"),
                entry.GetProperty("main").GetBoolean(),
                ReadPosition(entry.GetProperty("worldPosition")))
            {
                SourceRotation = ReadRotation(entry.GetProperty("worldRotation"))
            };
        }
        if (players.Count(player => player.Main) != 2)
            throw new InvalidDataException("Co-op map needs two main allied starts.");
        return players;
    }

    private static CoopSpawnPoint[] ReadSpawns(
        JsonElement entries, int expectedCount)
    {
        if (entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() != expectedCount)
            throw new InvalidDataException("Co-op map spawn collection is incomplete.");
        var points = new CoopSpawnPoint[expectedCount];
        var ids = new HashSet<int>();
        var nextOrder = new Dictionary<string, int>(StringComparer.Ordinal);
        for (int index = 0; index < points.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireFields(entry, "collection", "order", "componentFileId",
                "componentType", "fraction", "gameObjectFileId",
                "transformFileId", "worldPosition", "worldRotation");
            string collection = entry.GetProperty("collection").GetString() ?? "";
            string type = entry.GetProperty("componentType").GetString() ?? "";
            int order = entry.GetProperty("order").GetInt32();
            int componentId = PositiveId(entry, "componentFileId");
            int fraction = entry.GetProperty("fraction").GetInt32();
            if (!Collections.Contains(collection) ||
                !type.StartsWith("SpawnPoint", StringComparison.Ordinal) ||
                type.Length > 64 || fraction is not (1 or 2) ||
                order != nextOrder.GetValueOrDefault(collection) || !ids.Add(componentId))
                throw new InvalidDataException("Invalid co-op spawn identity or order.");
            nextOrder[collection] = order + 1;
            points[index] = new CoopSpawnPoint(collection, order, componentId,
                type, fraction, PositiveId(entry, "gameObjectFileId"),
                PositiveId(entry, "transformFileId"),
                ReadPosition(entry.GetProperty("worldPosition")))
            {
                SourceRotation = ReadRotation(entry.GetProperty("worldRotation"))
            };
        }
        if (!nextOrder.ContainsKey("spawnPointsCollection") ||
            !nextOrder.ContainsKey("spawnPointsCollectionDrones") ||
            !nextOrder.ContainsKey("spawnPointsCollectionCars") ||
            !nextOrder.ContainsKey("spawnPointsCollectionHelicopters"))
            throw new InvalidDataException("Co-op map lacks a required enemy spawn collection.");
        return points;
    }

    private static int PositiveId(JsonElement entry, string name)
    {
        int id = entry.GetProperty(name).GetInt32();
        if (id <= 0)
            throw new InvalidDataException($"Co-op {name} is not a source file ID.");
        return id;
    }

    private static Vector3 ReadPosition(JsonElement entry)
    {
        if (entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() != 3)
            throw new InvalidDataException("Co-op spawn position needs three coordinates.");
        var position = new Vector3(entry[0].GetSingle(), entry[1].GetSingle(),
            entry[2].GetSingle());
        if (!float.IsFinite(position.X) || !float.IsFinite(position.Y) ||
            !float.IsFinite(position.Z) ||
            Math.Abs(position.X) >= 10_000 || Math.Abs(position.Y) >= 10_000 ||
            Math.Abs(position.Z) >= 10_000)
            throw new InvalidDataException("Co-op spawn position is outside the scene.");
        return position;
    }

    private static Quaternion ReadRotation(JsonElement entry)
    {
        if (entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() != 4)
            throw new InvalidDataException("Co-op spawn rotation needs four coordinates.");
        var rotation = new Quaternion(entry[0].GetSingle(), entry[1].GetSingle(),
            entry[2].GetSingle(), entry[3].GetSingle());
        if (!float.IsFinite(rotation.X) || !float.IsFinite(rotation.Y) ||
            !float.IsFinite(rotation.Z) || !float.IsFinite(rotation.W) ||
            Math.Abs(rotation.LengthSquared() - 1) > 0.0002f)
            throw new InvalidDataException("Co-op spawn rotation must be a unit quaternion.");
        return rotation;
    }

    private static void RequireFields(JsonElement entry, params string[] names)
    {
        if (entry.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Co-op spawn record must be an object.");
        var required = new HashSet<string>(names, StringComparer.Ordinal);
        foreach (JsonProperty property in entry.EnumerateObject())
        {
            if (!required.Remove(property.Name))
                throw new InvalidDataException("Co-op spawn record has an extra or repeated field.");
        }
        if (required.Count != 0)
            throw new InvalidDataException("Co-op spawn record is missing a field.");
    }
}

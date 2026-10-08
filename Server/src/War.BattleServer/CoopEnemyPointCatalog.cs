using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopEnemyPoint(
    int Order, int ComponentFileId, string ComponentType,
    int GameObjectFileId, int TransformFileId,
    Vector3 TransformPosition, Quaternion Rotation,
    Vector3 Position, Vector3? SegmentStart, Vector3? SegmentEnd)
{
    public Vector3? CornerDirection { get; init; }
    public bool? CornerRightSide { get; init; }
}

public sealed record CoopMapEnemyPoints(
    int Stage, string Scene, string SceneSha256,
    int MapDefinitionFileId, int FloorTransformFileId,
    Vector3 FloorPosition, int CollectionComponentFileId,
    IReadOnlyList<CoopEnemyPoint> Points);

/// <summary>
/// Ordered enemy destination candidates from each recovered co-op scene.
/// Selection, occupancy, randomized obstacle placement, and NavMesh movement
/// remain separate host decisions.
/// </summary>
public sealed class CoopEnemyPointCatalog
{
    private const string ArtifactSha256 =
        "0f5f764d8fbd5848daab67ec87ba90e98f2368c6ef6ff8478d4963818def7972";
    private static readonly int[] ExpectedMapCounts = [26, 23, 25, 24, 32];
    private static readonly IReadOnlyDictionary<string, int> ExpectedTypes =
        new Dictionary<string, int>(StringComparer.Ordinal)
        {
            ["EnemyPointObstacle"] = 58,
            ["EnemyPointMinigunner"] = 20,
            ["EnemyPointEngineerTurret"] = 20,
            ["EnemyPointSwat"] = 10,
            ["EnemyPointCorner"] = 5,
            ["EnemyPointRusherSpare"] = 4,
            ["EnemyPointGunslinger"] = 4,
            ["EnemyPointMortar"] = 4,
            ["EnemyPointMech"] = 4,
            ["EnemyPointRusher"] = 1
        };

    public IReadOnlyList<CoopMapEnemyPoints> Maps { get; }

    private CoopEnemyPointCatalog(CoopMapEnemyPoints[] maps)
    {
        Maps = new ReadOnlyCollection<CoopMapEnemyPoints>(maps);
    }

    public CoopMapEnemyPoints MapForMission(
        MissionCatalog missions, int missionIndex)
    {
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopMapEnemyPoints map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene ||
            map.SceneSha256 != expected.SceneSha256)
            throw new InvalidDataException(
                "Co-op enemy points differ from the mission scene.");
        return map;
    }

    public static CoopEnemyPointCatalog Load(string path,
        MissionCatalog missions, CoopSpawnPointCatalog spawns)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(spawns);
        byte[] source = File.ReadAllBytes(path);
        if (source.Length is < 10_000 or > 250_000 ||
            Convert.ToHexStringLower(SHA256.HashData(source)) !=
                ArtifactSha256)
            throw new InvalidDataException(
                "Co-op enemy point artifact differs from source scenes.");

        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "maps");
        JsonElement entries = root.GetProperty("maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() != 5)
            throw new InvalidDataException("Co-op enemy point maps are incomplete.");

        var maps = new CoopMapEnemyPoints[5];
        var typeCounts = new Dictionary<string, int>(StringComparer.Ordinal);
        for (int index = 0; index < maps.Length; index++)
        {
            maps[index] = ReadMap(entries[index], missions.Maps[index],
                spawns.Maps[index], ExpectedMapCounts[index]);
            foreach (CoopEnemyPoint point in maps[index].Points)
            {
                typeCounts.TryGetValue(point.ComponentType, out int count);
                typeCounts[point.ComponentType] = count + 1;
            }
        }
        if (typeCounts.Count != ExpectedTypes.Count ||
            ExpectedTypes.Any(pair => !typeCounts.TryGetValue(pair.Key,
                out int count) || count != pair.Value))
            throw new InvalidDataException(
                "Co-op enemy point type inventory is incomplete.");
        return new CoopEnemyPointCatalog(maps);
    }

    private static CoopMapEnemyPoints ReadMap(JsonElement entry,
        MissionMapRule mission, CoopMapSpawnPoints spawns,
        int expectedCount)
    {
        RequireFields(entry, "stage", "scene", "sceneSha256",
            "mapDefinitionFileId", "floorTransformFileId",
            "floorWorldPosition", "collectionComponentFileId", "points");
        int stage = entry.GetProperty("stage").GetInt32();
        string scene = entry.GetProperty("scene").GetString() ?? "";
        string hash = entry.GetProperty("sceneSha256").GetString() ?? "";
        int definitionId = PositiveId(entry, "mapDefinitionFileId");
        int floorTransformId = PositiveId(entry, "floorTransformFileId");
        Vector3 floorPosition = Vector(entry.GetProperty("floorWorldPosition"));
        int collectionId = PositiveId(entry, "collectionComponentFileId");
        if (stage != mission.Stage || stage != spawns.Stage ||
            scene != mission.Scene || scene != spawns.Scene ||
            hash != mission.SceneSha256 || hash != spawns.SceneSha256 ||
            definitionId != spawns.MapDefinitionFileId)
            throw new InvalidDataException(
                "Co-op enemy points do not bind the source map.");

        JsonElement rows = entry.GetProperty("points");
        if (rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != expectedCount)
            throw new InvalidDataException(
                "Co-op enemy destination count changed.");
        var points = new CoopEnemyPoint[expectedCount];
        var componentIds = new HashSet<int>();
        var transformIds = new HashSet<int>();
        for (int index = 0; index < points.Length; index++)
        {
            points[index] = ReadPoint(rows[index], index);
            if (!componentIds.Add(points[index].ComponentFileId) ||
                !transformIds.Add(points[index].TransformFileId))
                throw new InvalidDataException(
                    "Duplicate co-op enemy destination identity.");
        }
        return new CoopMapEnemyPoints(stage, scene, hash, definitionId,
            floorTransformId, floorPosition, collectionId,
            new ReadOnlyCollection<CoopEnemyPoint>(points));
    }

    private static CoopEnemyPoint ReadPoint(JsonElement row, int order)
    {
        bool segment = row.TryGetProperty("segment", out JsonElement range);
        bool offset = row.TryGetProperty("effectivePosition", out JsonElement effective);
        bool corner = row.TryGetProperty("cornerDirection", out JsonElement direction);
        bool cornerSide = row.TryGetProperty("cornerRightSide", out JsonElement side);
        if (segment)
            RequireFields(row, "order", "componentFileId", "componentType",
                "gameObjectFileId", "transformFileId", "fraction",
                "worldPosition", "worldRotation", "positionKind", "segment");
        else if (offset)
            RequireFields(row, "order", "componentFileId", "componentType",
                "gameObjectFileId", "transformFileId", "fraction",
                "worldPosition", "worldRotation", "positionKind",
                "effectivePosition");
        else if (corner)
            RequireFields(row, "order", "componentFileId", "componentType",
                "gameObjectFileId", "transformFileId", "fraction",
                "worldPosition", "worldRotation", "positionKind",
                "cornerDirection", "cornerRightSide");
        else
            RequireFields(row, "order", "componentFileId", "componentType",
                "gameObjectFileId", "transformFileId", "fraction",
                "worldPosition", "worldRotation", "positionKind");
        string type = row.GetProperty("componentType").GetString() ?? "";
        string kind = row.GetProperty("positionKind").GetString() ?? "";
        if (row.GetProperty("order").GetInt32() != order ||
            row.GetProperty("fraction").GetInt32() != 1 ||
            !ExpectedTypes.ContainsKey(type) ||
            segment != (type == "EnemyPointObstacle") ||
            offset != (type == "EnemyPointEngineerTurret") ||
            corner != (type == "EnemyPointCorner") ||
            cornerSide != corner ||
            kind != (segment ? "segment" : "fixed"))
            throw new InvalidDataException(
                "Co-op enemy destination has invalid source identity.");

        Vector3 transform = Vector(row.GetProperty("worldPosition"));
        Quaternion rotation = Rotation(row.GetProperty("worldRotation"));
        Vector3 position = offset ? Vector(effective) : transform;
        Vector3? start = null;
        Vector3? end = null;
        if (segment)
        {
            RequireFields(range, "startTransformFileId",
                "endTransformFileId", "start", "end");
            int startId = PositiveId(range, "startTransformFileId");
            int endId = PositiveId(range, "endTransformFileId");
            start = Vector(range.GetProperty("start"));
            end = Vector(range.GetProperty("end"));
            if (startId == endId ||
                Vector3.Distance(start.Value, end.Value) is <= 0.01f or > 100f)
                throw new InvalidDataException(
                    "Co-op obstacle destination has an invalid segment.");
            position = (start.Value + end.Value) * 0.5f;
        }
        if (offset)
        {
            Vector3 expected = transform -
                Vector3.Transform(Vector3.UnitZ, rotation) * 0.2f;
            if (Vector3.Distance(position, expected) > 0.0001f)
                throw new InvalidDataException(
                    "Co-op engineer destination lost its source offset.");
        }
        Vector3? cornerDirection = corner ? Vector(direction) : null;
        if (cornerDirection.HasValue &&
            (cornerDirection.Value.LengthSquared() < 0.0001f ||
             side.ValueKind is not (JsonValueKind.True or JsonValueKind.False)))
            throw new InvalidDataException("Invalid co-op corner side or direction.");
        return new CoopEnemyPoint(order, PositiveId(row, "componentFileId"),
            type, PositiveId(row, "gameObjectFileId"),
            PositiveId(row, "transformFileId"), transform, rotation,
            position, start, end)
        {
            CornerDirection = cornerDirection,
            CornerRightSide = corner ? side.GetBoolean() : null
        };
    }

    private static Vector3 Vector(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Array || value.GetArrayLength() != 3)
            throw new InvalidDataException("Co-op enemy point needs a position.");
        var position = new Vector3(value[0].GetSingle(), value[1].GetSingle(),
            value[2].GetSingle());
        if (!PlayerHitbox.Finite(position) ||
            Vector3.Abs(position).X > 10_000 ||
            Vector3.Abs(position).Y > 10_000 ||
            Vector3.Abs(position).Z > 10_000)
            throw new InvalidDataException("Co-op enemy point is outside the scene.");
        return position;
    }

    private static Quaternion Rotation(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Array || value.GetArrayLength() != 4)
            throw new InvalidDataException("Co-op enemy point needs a rotation.");
        var rotation = new Quaternion(value[0].GetSingle(), value[1].GetSingle(),
            value[2].GetSingle(), value[3].GetSingle());
        if (!float.IsFinite(rotation.LengthSquared()) ||
            Math.Abs(rotation.LengthSquared() - 1f) > 0.0002f)
            throw new InvalidDataException("Invalid co-op enemy point rotation.");
        return Quaternion.Normalize(rotation);
    }

    private static int PositiveId(JsonElement entry, string name)
    {
        int id = entry.GetProperty(name).GetInt32();
        if (id <= 0)
            throw new InvalidDataException("Co-op source file ID must be positive.");
        return id;
    }

    private static void RequireFields(JsonElement entry, params string[] names)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != names.Length ||
            names.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException(
                "Co-op enemy point has unexpected fields.");
    }
}

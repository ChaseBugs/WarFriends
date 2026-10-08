using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// One exact Unity CalculatePath result for a recovered normal Assaulter
/// spawn and its initially selected enemy point. Obstacle segments are pinned
/// only at their start, midpoint, and end; arbitrary positions need planning.
/// </summary>
public sealed record CoopInfantryPathFixture(
    int Stage, int MissionIndex, int SpawnComponentFileId,
    int PointComponentFileId, float PointFraction,
    Vector3 RequestedStart, Vector3 RequestedEnd,
    Vector3 SampledStart, Vector3 SampledEnd,
    IReadOnlyList<Vector3> Corners, float Length);

public sealed class CoopInfantryPathFixtureCatalog
{
    private const string InputSha256 =
        "7c5e70124be48acd45f7722b7c2404001a52c7d4b057217af07c47f04d202a9e";
    private const string ReferenceSha256 =
        "42cc88552404158815a64d71f2c597752d2b8c10accf1b058bbc555abc0c92f7";

    public IReadOnlyList<CoopInfantryPathFixture> Cases { get; }

    private CoopInfantryPathFixtureCatalog(
        CoopInfantryPathFixture[] cases)
    {
        Cases = Array.AsReadOnly(cases);
    }

    public CoopInfantryPathFixture? ForExactSpawn(int stage,
        int spawnComponentFileId, int pointComponentFileId,
        Vector3 requestedStart, Vector3 requestedEnd)
    {
        return Cases.FirstOrDefault(path => path.Stage == stage &&
            path.SpawnComponentFileId == spawnComponentFileId &&
            path.PointComponentFileId == pointComponentFileId &&
            path.RequestedStart == requestedStart &&
            path.RequestedEnd == requestedEnd);
    }

    public static CoopInfantryPathFixtureCatalog Load(string directory,
        MissionCatalog missions, CoopNavMeshSourceCatalog navSources,
        CoopSpawnPointCatalog spawns, CoopEnemyPointCatalog enemyPoints)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(navSources);
        ArgumentNullException.ThrowIfNull(spawns);
        ArgumentNullException.ThrowIfNull(enemyPoints);
        string inputPath = Path.Combine(directory,
            "coop-infantry-normal-spawn-path-input.json");
        string referencePath = Path.Combine(directory,
            "coop-infantry-normal-spawn-path-reference.json");
        byte[] inputBytes = File.ReadAllBytes(inputPath);
        byte[] referenceBytes = File.ReadAllBytes(referencePath);
        if (Convert.ToHexStringLower(SHA256.HashData(inputBytes)) !=
                InputSha256 ||
            Convert.ToHexStringLower(SHA256.HashData(referenceBytes)) !=
                ReferenceSha256)
            throw new InvalidDataException(
                "Co-op Unity infantry paths differ from their pinned sources.");

        using JsonDocument inputDocument = JsonDocument.Parse(inputBytes);
        using JsonDocument referenceDocument = JsonDocument.Parse(
            referenceBytes);
        JsonElement inputs = ReadCases(inputDocument.RootElement);
        JsonElement references = ReadCases(referenceDocument.RootElement);
        var result = new CoopInfantryPathFixture[36];
        var stageCounts = new int[5];
        var identities = new HashSet<(int Stage, int Spawn, int Point,
            float Fraction)>();
        for (int index = 0; index < result.Length; index++)
        {
            JsonElement input = inputs[index];
            JsonElement reference = references[index];
            RequireFields(input, "stage", "missionIndex", "scene", "asset",
                "spawnComponentFileId", "pointComponentFileId",
                "pointPositionKind", "pointFraction", "start", "end");
            RequireFields(reference, "stage", "scene", "asset",
                "spawnComponentFileId", "pointComponentFileId",
                "startSampled", "endSampled", "sampledStart",
                "sampledEnd", "status", "corners");

            int missionIndex = input.GetProperty("missionIndex").GetInt32();
            MissionMapRule map = missions.MapForMission(missionIndex);
            CoopNavMeshSource nav = navSources.MapForMission(missions,
                missionIndex);
            CoopMapSpawnPoints mapSpawns = spawns.MapForMission(missions,
                missionIndex);
            CoopMapEnemyPoints mapPoints = enemyPoints.MapForMission(missions,
                missionIndex);
            int stage = input.GetProperty("stage").GetInt32();
            int spawnId = input.GetProperty("spawnComponentFileId").GetInt32();
            int pointId = input.GetProperty("pointComponentFileId").GetInt32();
            float fraction = input.GetProperty("pointFraction").GetSingle();
            CoopSpawnPoint spawn = mapSpawns.EnemySpawnPoints.Single(point =>
                point.ComponentFileId == spawnId);
            CoopEnemyPoint? point = CoopEnemyPointSelection.SelectOrdinary(
                mapPoints, 14, spawn.Position, new HashSet<int>());
            bool obstacle = point?.ComponentType == "EnemyPointObstacle";
            if (point == null || point.ComponentFileId != pointId ||
                stage != map.Stage || stage is < 1 or > 5 ||
                stage < (index == 0 ? 1 : result[index - 1].Stage) ||
                !identities.Add((stage, spawnId, pointId, fraction)) ||
                spawn.ComponentType != "SpawnPoint" || spawn.Fraction != 1 ||
                input.GetProperty("scene").GetString() != map.Scene ||
                input.GetProperty("asset").GetString() != nav.SourceAsset ||
                input.GetProperty("pointPositionKind").GetString() !=
                    (obstacle ? "segment" : "fixed") ||
                (obstacle ? fraction is not (0f or 0.5f or 1f) :
                    fraction != 0f))
                throw new InvalidDataException(
                    "Co-op infantry path input differs from the Client.");

            Vector3 requestedStart = ReadVector(input.GetProperty("start"));
            Vector3 requestedEnd = ReadVector(input.GetProperty("end"));
            Vector3 sourceEnd = CoopEnemyPointSelection.GeneratePosition(
                point, fraction);
            if (Vector3.Distance(requestedStart, spawn.Position) > 0.001f ||
                Vector3.Distance(requestedEnd, sourceEnd) > 0.001f ||
                reference.GetProperty("stage").GetInt32() != stage ||
                reference.GetProperty("scene").GetString() != map.Scene ||
                reference.GetProperty("asset").GetString() != nav.SourceAsset ||
                reference.GetProperty("spawnComponentFileId").GetInt32() !=
                    spawnId ||
                reference.GetProperty("pointComponentFileId").GetInt32() !=
                    pointId ||
                !reference.GetProperty("startSampled").GetBoolean() ||
                !reference.GetProperty("endSampled").GetBoolean() ||
                reference.GetProperty("status").GetString() != "PathComplete")
                throw new InvalidDataException(
                    "Co-op Unity path result differs from its input.");

            Vector3 sampledStart = ReadVector(
                reference.GetProperty("sampledStart"));
            Vector3 sampledEnd = ReadVector(
                reference.GetProperty("sampledEnd"));
            JsonElement cornerRows = reference.GetProperty("corners");
            if (cornerRows.ValueKind != JsonValueKind.Array ||
                cornerRows.GetArrayLength() is < 2 or > 64 ||
                Vector3.Distance(requestedStart, sampledStart) > 3f ||
                Vector3.Distance(requestedEnd, sampledEnd) > 3f)
                throw new InvalidDataException(
                    "Co-op Unity path has invalid sampled endpoints.");
            Vector3[] corners = cornerRows.EnumerateArray()
                .Select(ReadVector).ToArray();
            if (Vector3.Distance(corners[0], sampledStart) > 0.001f ||
                Vector3.Distance(corners[^1], sampledEnd) > 0.001f)
                throw new InvalidDataException(
                    "Co-op Unity path corners omit a sampled endpoint.");
            float length = 0;
            for (int corner = 1; corner < corners.Length; corner++)
                length += Vector3.Distance(corners[corner - 1],
                    corners[corner]);
            if (!float.IsFinite(length) || length is < 0.05f or > 1000f)
                throw new InvalidDataException("Co-op Unity path length is invalid.");
            result[index] = new CoopInfantryPathFixture(stage,
                missionIndex, spawnId, pointId, fraction,
                requestedStart, requestedEnd, sampledStart, sampledEnd,
                Array.AsReadOnly(corners), length);
            stageCounts[stage - 1]++;
        }
        if (!stageCounts.SequenceEqual([14, 9, 4, 7, 2]))
            throw new InvalidDataException("Co-op Unity path stages are incomplete.");
        return new CoopInfantryPathFixtureCatalog(result);
    }

    private static JsonElement ReadCases(JsonElement root)
    {
        RequireFields(root, "version", "cases");
        JsonElement cases = root.GetProperty("cases");
        if (root.GetProperty("version").GetInt32() != 2 ||
            cases.ValueKind != JsonValueKind.Array ||
            cases.GetArrayLength() != 36)
            throw new InvalidDataException("Co-op Unity path set is incomplete.");
        return cases;
    }

    private static Vector3 ReadVector(JsonElement element)
    {
        RequireFields(element, "x", "y", "z");
        Vector3 value = new(element.GetProperty("x").GetSingle(),
            element.GetProperty("y").GetSingle(),
            element.GetProperty("z").GetSingle());
        if (!PlayerHitbox.Finite(value) ||
            MathF.Abs(value.X) > 1000 || MathF.Abs(value.Y) > 1000 ||
            MathF.Abs(value.Z) > 1000)
            throw new InvalidDataException("Co-op Unity path vector is invalid.");
        return value;
    }

    private static void RequireFields(JsonElement element,
        params string[] names)
    {
        if (element.ValueKind != JsonValueKind.Object ||
            element.EnumerateObject().Count() != names.Length ||
            names.Any(name => !element.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op Unity path has unknown fields.");
    }
}

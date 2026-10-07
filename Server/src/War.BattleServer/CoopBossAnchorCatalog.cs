using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBossAnchor(
    int Index, int Fraction, bool Main, int ComponentFileId,
    int GameObjectFileId, int TransformFileId,
    Vector3 Position, Quaternion Rotation);

public sealed class CoopBossMapAnchors
{
    public int Stage { get; }
    public string Scene { get; }
    public string SceneSha256 { get; }
    public int MapDefinitionFileId { get; }
    public IReadOnlyList<CoopBossAnchor> PlayerPositions { get; }

    // BotMission.GetMainPlayerPoint returns the first matching main point.
    public CoopBossAnchor BossStart => PlayerPositions[1];
    public IReadOnlyList<CoopBossAnchor> AlliedStarts =>
        new ReadOnlyCollection<CoopBossAnchor>(
            [PlayerPositions[5], PlayerPositions[6]]);

    internal CoopBossMapAnchors(int stage, string scene, string sceneHash,
        int mapDefinitionFileId, CoopBossAnchor[] positions)
    {
        Stage = stage;
        Scene = scene;
        SceneSha256 = sceneHash;
        MapDefinitionFileId = mapDefinitionFileId;
        PlayerPositions = new ReadOnlyCollection<CoopBossAnchor>(positions);
    }
}

/// <summary>Reviewed source shield identities for BotMission multiplayer maps.</summary>
public sealed class CoopBossAnchorCatalog
{
    private const string ReviewedArtifactSha256 =
        "31f9b4cbb39e3e65dbac7eb547c04e6673d760af73c5e444b727ad5722bce71e";

    public IReadOnlyList<CoopBossMapAnchors> Maps { get; }

    private CoopBossAnchorCatalog(CoopBossMapAnchors[] maps)
    {
        Maps = new ReadOnlyCollection<CoopBossMapAnchors>(maps);
    }

    public CoopBossMapAnchors MapForMission(MissionCatalog missions, int missionIndex)
    {
        MissionRule mission = missions.Get(missionIndex);
        if (mission.MissionType != "KillOpponent")
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopBossMapAnchors map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene || map.SceneSha256 != expected.SceneSha256)
            throw new InvalidDataException("Boss anchors differ from the mission map.");
        return map;
    }

    public static CoopBossAnchorCatalog Load(string path, MissionCatalog missions)
    {
        ArgumentNullException.ThrowIfNull(missions);
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedArtifactSha256)
            throw new InvalidDataException("Boss anchors differ from recovered scenes.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "missionSourceSha256", "maps");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("missionSourceSha256").GetString() != missions.SourceSha256)
            throw new InvalidDataException("Boss anchors differ from the mission source.");
        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 5)
            throw new InvalidDataException("Boss anchors need five multiplayer maps.");

        var maps = new CoopBossMapAnchors[5];
        for (int mapIndex = 0; mapIndex < maps.Length; mapIndex++)
        {
            JsonElement entry = entries[mapIndex];
            RequireFields(entry, "stage", "scene", "sceneSha256",
                "mapDefinitionFileId", "playerPositions");
            MissionMapRule expected = missions.BossMaps[mapIndex];
            string scene = entry.GetProperty("scene").GetString() ?? "";
            string sceneHash = entry.GetProperty("sceneSha256").GetString() ?? "";
            int definitionId = PositiveId(entry, "mapDefinitionFileId");
            if (entry.GetProperty("stage").GetInt32() != expected.Stage ||
                scene != expected.Scene || sceneHash != expected.SceneSha256)
                throw new InvalidDataException("Boss anchor map identity changed.");
            JsonElement positions = entry.GetProperty("playerPositions");
            if (positions.ValueKind != JsonValueKind.Array ||
                positions.GetArrayLength() != 8)
                throw new InvalidDataException("Boss map needs eight defend positions.");
            var anchors = new CoopBossAnchor[8];
            var componentIds = new HashSet<int>();
            for (int index = 0; index < anchors.Length; index++)
            {
                JsonElement point = positions[index];
                RequireFields(point, "index", "fraction", "main",
                    "componentFileId", "gameObjectFileId", "transformFileId",
                    "worldPosition", "worldRotation");
                int fraction = point.GetProperty("fraction").GetInt32();
                bool main = point.GetProperty("main").GetBoolean();
                int componentId = PositiveId(point, "componentFileId");
                if (point.GetProperty("index").GetInt32() != index ||
                    fraction != (index < 4 ? 1 : 2) ||
                    main != (index is 1 or 2 or 5 or 6) ||
                    !componentIds.Add(componentId))
                    throw new InvalidDataException("Boss defend position order changed.");
                anchors[index] = new CoopBossAnchor(index, fraction, main,
                    componentId, PositiveId(point, "gameObjectFileId"),
                    PositiveId(point, "transformFileId"),
                    ReadPosition(point.GetProperty("worldPosition")),
                    ReadRotation(point.GetProperty("worldRotation")));
            }
            maps[mapIndex] = new CoopBossMapAnchors(expected.Stage, scene,
                sceneHash, definitionId, anchors);
        }
        return new CoopBossAnchorCatalog(maps);
    }

    private static int PositiveId(JsonElement entry, string name)
    {
        int id = entry.GetProperty(name).GetInt32();
        if (id <= 0)
            throw new InvalidDataException($"Boss {name} is not a source file ID.");
        return id;
    }

    private static Vector3 ReadPosition(JsonElement entry)
    {
        if (entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() != 3)
            throw new InvalidDataException("Boss position needs three coordinates.");
        var value = new Vector3(entry[0].GetSingle(), entry[1].GetSingle(),
            entry[2].GetSingle());
        if (!float.IsFinite(value.X) || !float.IsFinite(value.Y) ||
            !float.IsFinite(value.Z) ||
            Math.Abs(value.X) > 10_000 || Math.Abs(value.Y) > 10_000 ||
            Math.Abs(value.Z) > 10_000)
            throw new InvalidDataException("Boss position is outside the scene.");
        return value;
    }

    private static Quaternion ReadRotation(JsonElement entry)
    {
        if (entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() != 4)
            throw new InvalidDataException("Boss rotation needs four coordinates.");
        var value = new Quaternion(entry[0].GetSingle(), entry[1].GetSingle(),
            entry[2].GetSingle(), entry[3].GetSingle());
        if (!float.IsFinite(value.X) || !float.IsFinite(value.Y) ||
            !float.IsFinite(value.Z) || !float.IsFinite(value.W) ||
            Math.Abs(value.LengthSquared() - 1) > 0.001f)
            throw new InvalidDataException("Boss rotation is not a unit quaternion.");
        return value;
    }

    private static void RequireFields(JsonElement entry, params string[] fields)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != fields.Length ||
            fields.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Boss anchor record has unexpected fields.");
    }
}

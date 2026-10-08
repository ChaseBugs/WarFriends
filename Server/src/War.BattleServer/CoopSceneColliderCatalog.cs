using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopColliderTransform(
    int FileId, Vector3 LocalPosition, Quaternion LocalRotation,
    Vector3 LocalScale);

public sealed record CoopColliderShape(
    Vector3 Center, Vector3 Size, float Radius, float Height,
    int Direction, int MeshFileId, string MeshGuid, bool Convex);

public sealed record CoopSceneCollider(
    int ComponentFileId, string ComponentType, int GameObjectFileId,
    int TransformFileId, string GameObjectName, int Layer,
    bool Active, bool ActiveInHierarchy, bool Enabled, bool Trigger,
    IReadOnlyList<CoopColliderTransform> TransformChain,
    Vector3 WorldPosition, Quaternion WorldRotation, CoopColliderShape Shape);

public sealed record CoopSceneColliders(
    int Stage, string Scene, string SceneSha256,
    IReadOnlyList<CoopSceneCollider> Colliders);

/// <summary>
/// Native scene collider identities and transforms from the five co-op maps.
/// Mesh triangles and prefab-owned colliders are not present here. This catalog
/// must not be used as a complete bullet collision world.
/// </summary>
public sealed class CoopSceneColliderCatalog
{
    private const string SourceSha256 =
        "3f7fb2f2a3d0e90dda9796ecb79f8233964e52cdcd5c5e3350c2a08f92cdb20d";
    private static readonly int[] ExpectedCounts = [106, 201, 219, 107, 162];

    public IReadOnlyList<CoopSceneColliders> Maps { get; }

    private CoopSceneColliderCatalog(CoopSceneColliders[] maps)
    {
        Maps = new ReadOnlyCollection<CoopSceneColliders>(maps);
    }

    public CoopSceneColliders MapForMission(MissionCatalog missions, int missionIndex)
    {
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopSceneColliders map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene || map.SceneSha256 != expected.SceneSha256)
            throw new InvalidDataException("Co-op colliders differ from the mission scene.");
        return map;
    }

    public static CoopSceneColliderCatalog Load(string path, MissionCatalog missions)
    {
        ArgumentNullException.ThrowIfNull(missions);
        byte[] source = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(source)) != SourceSha256)
            throw new InvalidDataException("Co-op collider artifact differs from source.");
        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "maps");
        if (root.GetProperty("version").GetInt32() != 1)
            throw new InvalidDataException("Unknown co-op collider artifact version.");
        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 5)
            throw new InvalidDataException("Co-op collider artifact needs five maps.");

        var maps = new CoopSceneColliders[5];
        for (int index = 0; index < maps.Length; index++)
            maps[index] = ReadMap(entries[index], missions.Maps[index],
                ExpectedCounts[index]);
        return new CoopSceneColliderCatalog(maps);
    }

    private static CoopSceneColliders ReadMap(
        JsonElement entry, MissionMapRule expected, int expectedCount)
    {
        RequireFields(entry, "stage", "scene", "sceneSha256", "colliders");
        if (entry.GetProperty("stage").GetInt32() != expected.Stage ||
            entry.GetProperty("scene").GetString() != expected.Scene ||
            entry.GetProperty("sceneSha256").GetString() != expected.SceneSha256)
            throw new InvalidDataException("Co-op collider scene identity changed.");
        JsonElement rows = entry.GetProperty("colliders");
        if (rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != expectedCount)
            throw new InvalidDataException("Co-op scene collider set is incomplete.");
        var colliders = new CoopSceneCollider[expectedCount];
        int previousId = 0;
        for (int index = 0; index < colliders.Length; index++)
        {
            colliders[index] = ReadCollider(rows[index]);
            if (colliders[index].ComponentFileId <= previousId)
                throw new InvalidDataException("Co-op colliders are unordered or duplicated.");
            previousId = colliders[index].ComponentFileId;
        }
        return new CoopSceneColliders(expected.Stage, expected.Scene,
            expected.SceneSha256,
            new ReadOnlyCollection<CoopSceneCollider>(colliders));
    }

    internal static CoopSceneCollider ReadCollider(JsonElement row)
    {
        RequireFields(row, "componentFileId", "componentType",
            "gameObjectFileId", "transformFileId", "gameObjectName",
            "layer", "active", "activeInHierarchy", "enabled", "trigger", "transformChain",
            "worldPosition", "worldRotation", "shape");
        int componentId = PositiveId(row, "componentFileId");
        int gameObjectId = PositiveId(row, "gameObjectFileId");
        int transformId = PositiveId(row, "transformFileId");
        string name = row.GetProperty("gameObjectName").GetString() ?? "";
        int layer = row.GetProperty("layer").GetInt32();
        string kind = row.GetProperty("componentType").GetString() ?? "";
        if (name.Length is < 1 or > 128 || name.Any(char.IsControl) ||
            layer is < 0 or > 31 || kind is not
                ("MeshCollider" or "BoxCollider" or "CapsuleCollider" or
                 "SphereCollider"))
            throw new InvalidDataException("Invalid co-op collider identity.");

        JsonElement chainRows = row.GetProperty("transformChain");
        if (chainRows.ValueKind != JsonValueKind.Array ||
            chainRows.GetArrayLength() is < 1 or > 32)
            throw new InvalidDataException("Invalid co-op collider transform chain.");
        var chain = new CoopColliderTransform[chainRows.GetArrayLength()];
        var seen = new HashSet<int>();
        for (int index = 0; index < chain.Length; index++)
        {
            JsonElement local = chainRows[index];
            RequireFields(local, "fileId", "position", "rotation", "scale");
            int fileId = PositiveId(local, "fileId");
            if (!seen.Add(fileId))
                throw new InvalidDataException("Cyclic co-op collider transform.");
            Vector3 scale = ReadVector(local.GetProperty("scale"));
            if (scale.X == 0 || scale.Y == 0 || scale.Z == 0)
                throw new InvalidDataException("Degenerate co-op collider scale.");
            chain[index] = new CoopColliderTransform(fileId,
                ReadVector(local.GetProperty("position")),
                ReadRotation(local.GetProperty("rotation")), scale);
        }
        if (chain[0].FileId != transformId)
            throw new InvalidDataException("Co-op collider transform root changed.");
        bool active = row.GetProperty("active").GetBoolean();
        bool activeInHierarchy = row.GetProperty("activeInHierarchy").GetBoolean();
        if (activeInHierarchy && !active)
            throw new InvalidDataException("Inactive co-op object became active in hierarchy.");

        return new CoopSceneCollider(componentId, kind, gameObjectId,
            transformId, name, layer,
            active, activeInHierarchy,
            row.GetProperty("enabled").GetBoolean(),
            row.GetProperty("trigger").GetBoolean(),
            new ReadOnlyCollection<CoopColliderTransform>(chain),
            ReadVector(row.GetProperty("worldPosition")),
            ReadRotation(row.GetProperty("worldRotation")),
            ReadShape(kind, row.GetProperty("shape")));
    }

    private static CoopColliderShape ReadShape(string kind, JsonElement row)
    {
        if (kind == "MeshCollider")
        {
            RequireFields(row, "meshFileId", "meshGuid", "convex");
            int fileId = row.GetProperty("meshFileId").GetInt32();
            string guid = row.GetProperty("meshGuid").GetString() ?? "";
            if (fileId < 0 || (fileId == 0 ? guid.Length != 0 :
                guid.Length != 32 || guid.Any(c => !Uri.IsHexDigit(c))))
                throw new InvalidDataException("Invalid co-op collider mesh identity.");
            return new CoopColliderShape(default, default, 0, 0, 0,
                fileId, guid, row.GetProperty("convex").GetBoolean());
        }
        if (kind == "BoxCollider")
        {
            RequireFields(row, "size", "center");
            Vector3 size = ReadVector(row.GetProperty("size"));
            if (size.X <= 0 || size.Y <= 0 || size.Z <= 0)
                throw new InvalidDataException("Invalid co-op box collider size.");
            return new CoopColliderShape(ReadVector(row.GetProperty("center")),
                size, 0, 0, 0, 0, "", false);
        }
        if (kind == "SphereCollider")
        {
            RequireFields(row, "radius", "center");
            float sphereRadius = row.GetProperty("radius").GetSingle();
            if (!float.IsFinite(sphereRadius) || sphereRadius <= 0)
                throw new InvalidDataException("Invalid co-op sphere collider.");
            return new CoopColliderShape(ReadVector(row.GetProperty("center")),
                default, sphereRadius, 0, 0, 0, "", false);
        }
        RequireFields(row, "radius", "height", "direction", "center");
        float radius = row.GetProperty("radius").GetSingle();
        float height = row.GetProperty("height").GetSingle();
        int direction = row.GetProperty("direction").GetInt32();
        if (!float.IsFinite(radius) || !float.IsFinite(height) ||
            radius <= 0 || height <= 0 || direction is < 0 or > 2)
            throw new InvalidDataException("Invalid co-op capsule collider.");
        return new CoopColliderShape(ReadVector(row.GetProperty("center")),
            default, radius, height, direction, 0, "", false);
    }

    private static Vector3 ReadVector(JsonElement row)
    {
        if (row.ValueKind != JsonValueKind.Array || row.GetArrayLength() != 3)
            throw new InvalidDataException("Co-op collider vector needs three coordinates.");
        var value = new Vector3(row[0].GetSingle(), row[1].GetSingle(),
            row[2].GetSingle());
        if (!float.IsFinite(value.X) || !float.IsFinite(value.Y) ||
            !float.IsFinite(value.Z) || Vector3.Abs(value).Length() >= 10_000)
            throw new InvalidDataException("Co-op collider vector is outside source bounds.");
        return value;
    }

    private static Quaternion ReadRotation(JsonElement row)
    {
        if (row.ValueKind != JsonValueKind.Array || row.GetArrayLength() != 4)
            throw new InvalidDataException("Co-op collider rotation needs four coordinates.");
        var value = new Quaternion(row[0].GetSingle(), row[1].GetSingle(),
            row[2].GetSingle(), row[3].GetSingle());
        if (!float.IsFinite(value.X) || !float.IsFinite(value.Y) ||
            !float.IsFinite(value.Z) || !float.IsFinite(value.W) ||
            Math.Abs(value.LengthSquared() - 1) > 0.002f)
            throw new InvalidDataException("Co-op collider rotation is not normalized.");
        return value;
    }

    private static int PositiveId(JsonElement row, string name)
    {
        int id = row.GetProperty(name).GetInt32();
        if (id <= 0)
            throw new InvalidDataException($"Co-op collider {name} is not a source ID.");
        return id;
    }

    private static void RequireFields(JsonElement row, params string[] fields)
    {
        if (row.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Co-op collider record must be an object.");
        var required = new HashSet<string>(fields, StringComparer.Ordinal);
        foreach (JsonProperty property in row.EnumerateObject())
        {
            if (!required.Remove(property.Name))
                throw new InvalidDataException("Co-op collider has an extra field.");
        }
        if (required.Count != 0)
            throw new InvalidDataException("Co-op collider is missing a field.");
    }
}

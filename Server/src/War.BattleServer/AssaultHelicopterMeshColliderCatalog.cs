using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record AssaultHelicopterBodyMesh(int ColliderFileId,
    int PartComponentFileId, PlayerHitbox Hitbox);

/// <summary>
/// The five assigned convex body meshes from the independent Unity export.
/// Glass has a separate damage owner and is deliberately excluded here.
/// </summary>
internal sealed class AssaultHelicopterMeshColliderCatalog
{
    private sealed record Source(int ColliderFileId, int PartComponentFileId,
        Vector3 Center, Quaternion Rotation, TriangleMeshGeometry Geometry);
    private static readonly (int Collider, int Part, string Mesh)[] BodySources =
    [
        (6480903, 11439084, "049f0c1671103364e9d4f48c5287121f:4300000"),
        (6464753, 11497582, "727cd68b7be7e4a4d9cdb13e000e9a10:4300000"),
        (6433468, 11403601, "fbbdc6fcb5e77104f8d194a86fb4c319:4300000"),
        (6493588, 11452473, "7d4d9055779d8f3408ef22a5d9cdf4f6:4300000"),
        (6454546, 11488901, "ad736291141fa8f42b743a98921886a8:4300000")
    ];
    private readonly Source[] sources;

    private AssaultHelicopterMeshColliderCatalog(Source[] sources) => this.sources = sources;
    internal int Count => sources.Length;
    internal bool HasCollider(int fileId) => sources.Any(source => source.ColliderFileId == fileId);

    internal static AssaultHelicopterMeshColliderCatalog Load(string inventoryPath,
        string unityGeometryPath)
    {
        byte[] inventoryBytes = File.ReadAllBytes(inventoryPath);
        byte[] geometryBytes = File.ReadAllBytes(unityGeometryPath);
        if (inventoryBytes.Length > 500000 || geometryBytes.Length > 500000 ||
            Convert.ToHexStringLower(SHA256.HashData(inventoryBytes)) !=
                DroneColliderCatalog.VerifiedInventoryRevision ||
            Convert.ToHexStringLower(SHA256.HashData(geometryBytes)) !=
                "04ccfd36de95a12778a0009efc797e2109aee98295d15d6392752336a63871e6")
            throw new InvalidDataException("Assault Helicopter mesh export differs from verified source.");

        using var inventory = JsonDocument.Parse(inventoryBytes);
        using var geometry = JsonDocument.Parse(geometryBytes);
        var unit = inventory.RootElement.GetProperty("units").EnumerateArray().Single(row =>
            row.GetProperty("unitId").GetString() == "ID_UNIT-ASSAULTHELI");
        var exportedUnit = geometry.RootElement.GetProperty("units").EnumerateArray().Single(row =>
            row.GetProperty("source").GetString() == "Assets/GameObject/assaultHelicopter.prefab");
        if (unit.GetProperty("sha256").GetString() !=
                "3e8745b4b43f7c2e60110f34c9f8c2defc8fa65beb1bc8ac0396ccea17d04fe1" ||
            exportedUnit.GetProperty("sha256").GetString() != unit.GetProperty("sha256").GetString())
            throw new InvalidDataException("Assault Helicopter mesh prefab identity changed.");

        var sources = new Source[BodySources.Length];
        for (int index = 0; index < sources.Length; index++)
        {
            var expected = BodySources[index];
            var collider = unit.GetProperty("colliders").EnumerateArray().Single(row =>
                row.GetProperty("colliderFileId").GetInt32() == expected.Collider);
            var part = unit.GetProperty("components").EnumerateArray().Single(row =>
                row.GetProperty("componentFileId").GetInt32() == expected.Part);
            var exportedCollider = exportedUnit.GetProperty("colliders").EnumerateArray().Single(row =>
                row.GetProperty("componentFileId").GetInt32() == expected.Collider);
            var ancestors = collider.GetProperty("ancestorTransformFileIds");
            if (collider.GetProperty("type").GetString() != "Mesh" ||
                !collider.GetProperty("convex").GetBoolean() ||
                !collider.GetProperty("enabled").GetBoolean() ||
                collider.GetProperty("trigger").GetBoolean() ||
                collider.GetProperty("serializedLayer").GetInt32() != 8 ||
                !collider.GetProperty("activeAncestors").GetBoolean() ||
                ancestors.GetArrayLength() != 3 || ancestors[1].GetInt32() != 435975 ||
                ancestors[2].GetInt32() != 425385 ||
                part.GetProperty("gameObjectFileId").GetInt32() !=
                    collider.GetProperty("gameObjectFileId").GetInt32() ||
                part.GetProperty("ownerDestroyableObject").GetInt32() != 0 ||
                part.GetProperty("weight").GetSingle() != 1f ||
                exportedCollider.GetProperty("meshId").GetString() != expected.Mesh)
                throw new InvalidDataException("Assault Helicopter mesh lost its body owner.");

            Vector3 center = Vector(collider.GetProperty("restCenter"));
            Quaternion rotation = QuaternionValue(collider.GetProperty("restRotation"));
            Vector3 independentCenter = Vector(exportedCollider.GetProperty("center"));
            Quaternion independentRotation = QuaternionValue(
                exportedCollider.GetProperty("rotation"));
            if (!PlayerHitbox.Finite(center) ||
                !PlayerHitbox.Finite(independentCenter) ||
                Vector3.Distance(center, independentCenter) > .0002f ||
                !float.IsFinite(rotation.LengthSquared()) ||
                Math.Abs(rotation.LengthSquared() - 1f) > .001f ||
                !float.IsFinite(independentRotation.LengthSquared()) ||
                Math.Abs(independentRotation.LengthSquared() - 1f) > .001f ||
                Math.Abs(Quaternion.Dot(Quaternion.Normalize(rotation),
                    Quaternion.Normalize(independentRotation))) < .99999f)
                throw new InvalidDataException("Assault Helicopter mesh pose is invalid.");
            var mesh = geometry.RootElement.GetProperty("meshes").GetProperty(expected.Mesh);
            Vector3[] vertices = mesh.GetProperty("vertices").EnumerateArray()
                .Select(Vector).ToArray();
            int[] triangles = mesh.GetProperty("triangles").EnumerateArray()
                .Select(value => value.GetInt32()).ToArray();
            sources[index] = new(expected.Collider, expected.Part, center,
                Quaternion.Normalize(rotation), new TriangleMeshGeometry(vertices, triangles));
        }
        return new(sources);
    }

    internal IReadOnlyList<AssaultHelicopterBodyMesh> Place(Vector3 position,
        Quaternion rootRotation)
    {
        if (!PlayerHitbox.Finite(position) || !float.IsFinite(rootRotation.LengthSquared()) ||
            Math.Abs(rootRotation.LengthSquared() - 1f) > .001f)
            throw new InvalidDataException("Invalid Assault Helicopter body mesh root pose.");
        var placed = new AssaultHelicopterBodyMesh[sources.Length];
        for (int index = 0; index < sources.Length; index++)
        {
            var source = sources[index];
            Vector3 origin = position + Vector3.Transform(source.Center, rootRotation);
            Quaternion rotation = Quaternion.Normalize(rootRotation * source.Rotation);
            var hitbox = new PlayerHitbox(
                "Assets/GameObject/assaultHelicopter.prefab#" + source.ColliderFileId,
                1, origin, rotation, source.Geometry, position);
            placed[index] = new(source.ColliderFileId, source.PartComponentFileId, hitbox);
        }
        return Array.AsReadOnly(placed);
    }

    private static Vector3 Vector(JsonElement value) =>
        new(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    private static Quaternion QuaternionValue(JsonElement value) =>
        new(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(),
            value[3].GetSingle());
}

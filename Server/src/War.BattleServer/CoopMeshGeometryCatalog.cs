using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record CoopMeshGeometry(
    string Guid, string SourceAsset, string SourceSha256,
    IReadOnlyList<Vector3> Vertices, IReadOnlyList<int> Triangles);

/// <summary>
/// Unity 2018 mesh vertices and triangles referenced by native co-op scene
/// MeshColliders. Placement, trigger policy, prefab colliders, and animation
/// remain separate requirements before any shot becomes authoritative.
/// </summary>
public sealed class CoopMeshGeometryCatalog
{
    private const string SourceSha256 =
        "baece6f3eaffd22ad97465205c20c0755771ead83dcc5ae24210e724b911dcb7";
    private const string ColliderSourceSha256 =
        "3f7fb2f2a3d0e90dda9796ecb79f8233964e52cdcd5c5e3350c2a08f92cdb20d";
    private const string PrefabSourceSha256 =
        "e0dce5662aaf15d2287a0daa2c308759367d207dd5574cf56070b67abf0b560a";
    private const string PrefabColliderSourceSha256 =
        "4ab361718d06ca8c0ecd9d0bb1553ef4b2d3e1e1a22539f7cdcfc35e6d3bda70";
    private readonly IReadOnlyDictionary<string, CoopMeshGeometry> meshes;

    public int Count => meshes.Count;
    public int VertexCount { get; }
    public int TriangleCount { get; }

    private CoopMeshGeometryCatalog(
        Dictionary<string, CoopMeshGeometry> meshes,
        int vertexCount, int triangleCount)
    {
        this.meshes = new ReadOnlyDictionary<string, CoopMeshGeometry>(meshes);
        VertexCount = vertexCount;
        TriangleCount = triangleCount;
    }

    public CoopMeshGeometry Get(string guid)
    {
        return meshes.TryGetValue(guid, out CoopMeshGeometry? mesh)
            ? mesh
            : throw new InvalidDataException("Unknown co-op source mesh.");
    }

    public static CoopMeshGeometryCatalog Load(
        string path, CoopSceneColliderCatalog colliders)
    {
        ArgumentNullException.ThrowIfNull(colliders);
        string[] expectedGuids = colliders.Maps
            .SelectMany(map => map.Colliders)
            .Where(collider => collider.ComponentType == "MeshCollider" &&
                collider.Shape.MeshFileId != 0)
            .Select(collider => collider.Shape.MeshGuid)
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
        return LoadExpected(path, SourceSha256, ColliderSourceSha256,
            expectedGuids, 147, 14_885, 13_781);
    }

    public static CoopMeshGeometryCatalog LoadPrefabs(
        string path, CoopPrefabColliderCatalog colliders)
    {
        ArgumentNullException.ThrowIfNull(colliders);
        string[] expectedGuids = colliders.Prefabs
            .SelectMany(prefab => prefab.Colliders)
            .Where(collider => collider.ComponentType == "MeshCollider" &&
                collider.Shape.MeshFileId != 0)
            .Select(collider => collider.Shape.MeshGuid)
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
        return LoadExpected(path, PrefabSourceSha256,
            PrefabColliderSourceSha256, expectedGuids, 6, 176, 284);
    }

    private static CoopMeshGeometryCatalog LoadExpected(
        string path, string artifactSha256, string colliderSha256,
        string[] expectedGuids, int expectedMeshes,
        int expectedVertices, int expectedTriangles)
    {
        byte[] source = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(source)) != artifactSha256)
            throw new InvalidDataException("Co-op mesh geometry differs from Unity export.");
        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "client", "unity",
            "colliderSourceSha256", "meshes");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("unity").GetString() != "2018.3.0f2" ||
            root.GetProperty("colliderSourceSha256").GetString() !=
                colliderSha256)
            throw new InvalidDataException("Co-op mesh source provenance changed.");
        JsonElement rows = root.GetProperty("meshes");
        if (expectedGuids.Length != expectedMeshes ||
            rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != expectedGuids.Length)
            throw new InvalidDataException("Co-op mesh source set is incomplete.");

        var meshes = new Dictionary<string, CoopMeshGeometry>(StringComparer.Ordinal);
        int vertexCount = 0;
        int triangleCount = 0;
        for (int index = 0; index < expectedGuids.Length; index++)
        {
            CoopMeshGeometry mesh = ReadMesh(rows[index]);
            if (mesh.Guid != expectedGuids[index] ||
                !meshes.TryAdd(mesh.Guid, mesh))
                throw new InvalidDataException("Co-op mesh identity or order changed.");
            vertexCount = checked(vertexCount + mesh.Vertices.Count);
            triangleCount = checked(triangleCount + mesh.Triangles.Count / 3);
        }
        if (vertexCount != expectedVertices ||
            triangleCount != expectedTriangles)
            throw new InvalidDataException("Co-op mesh geometry count changed.");
        return new CoopMeshGeometryCatalog(meshes, vertexCount, triangleCount);
    }

    private static CoopMeshGeometry ReadMesh(JsonElement row)
    {
        RequireFields(row, "guid", "fileId", "source", "sourceSha256",
            "vertices", "triangles");
        string guid = row.GetProperty("guid").GetString() ?? "";
        string path = row.GetProperty("source").GetString() ?? "";
        string hash = row.GetProperty("sourceSha256").GetString() ?? "";
        if (!Regex.IsMatch(guid, "^[0-9a-f]{32}$") ||
            row.GetProperty("fileId").GetInt64() != 4300000 ||
            !path.StartsWith("Assets/Mesh/", StringComparison.Ordinal) ||
            !path.EndsWith(".asset", StringComparison.Ordinal) ||
            path.Contains("..", StringComparison.Ordinal) ||
            path.Length > 160 || !Regex.IsMatch(hash, "^[0-9a-f]{64}$"))
            throw new InvalidDataException("Invalid co-op mesh asset identity.");

        JsonElement points = row.GetProperty("vertices");
        JsonElement indices = row.GetProperty("triangles");
        if (points.ValueKind != JsonValueKind.Array ||
            points.GetArrayLength() is < 3 or > 100_000 ||
            indices.ValueKind != JsonValueKind.Array ||
            indices.GetArrayLength() is < 3 or > 300_000 ||
            indices.GetArrayLength() % 3 != 0)
            throw new InvalidDataException("Invalid co-op mesh geometry size.");
        var vertices = new Vector3[points.GetArrayLength()];
        for (int index = 0; index < vertices.Length; index++)
            vertices[index] = ReadVector(points[index]);
        var triangles = new int[indices.GetArrayLength()];
        for (int index = 0; index < triangles.Length; index++)
        {
            triangles[index] = indices[index].GetInt32();
            if (triangles[index] < 0 || triangles[index] >= vertices.Length)
                throw new InvalidDataException("Co-op mesh triangle is outside vertices.");
        }
        return new CoopMeshGeometry(guid, path, hash,
            new ReadOnlyCollection<Vector3>(vertices),
            new ReadOnlyCollection<int>(triangles));
    }

    private static Vector3 ReadVector(JsonElement row)
    {
        if (row.ValueKind != JsonValueKind.Array || row.GetArrayLength() != 3)
            throw new InvalidDataException("Co-op mesh vertex needs three coordinates.");
        var vertex = new Vector3(row[0].GetSingle(), row[1].GetSingle(),
            row[2].GetSingle());
        if (!float.IsFinite(vertex.X) || !float.IsFinite(vertex.Y) ||
            !float.IsFinite(vertex.Z) ||
            Math.Max(Math.Abs(vertex.X), Math.Max(Math.Abs(vertex.Y),
                Math.Abs(vertex.Z))) >= 10_000)
            throw new InvalidDataException("Co-op mesh vertex is outside source bounds.");
        return vertex;
    }

    private static void RequireFields(JsonElement row, params string[] fields)
    {
        if (row.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Co-op mesh record must be an object.");
        var required = new HashSet<string>(fields, StringComparer.Ordinal);
        foreach (JsonProperty property in row.EnumerateObject())
        {
            if (!required.Remove(property.Name))
                throw new InvalidDataException("Co-op mesh has an extra field.");
        }
        if (required.Count != 0)
            throw new InvalidDataException("Co-op mesh is missing a field.");
    }
}

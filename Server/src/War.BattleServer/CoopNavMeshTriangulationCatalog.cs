using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopNavMeshTriangulation
{
    public int Stage { get; }
    public string Scene { get; }
    public string SceneSha256 { get; }
    public string NavMeshSha256 { get; }
    public IReadOnlyList<Vector3> Vertices { get; }
    public IReadOnlyList<int> Indices { get; }

    internal CoopNavMeshTriangulation(CoopNavMeshSource source,
        Vector3[] vertices, int[] indices)
    {
        Stage = source.Stage;
        Scene = source.Scene;
        SceneSha256 = source.SceneSha256;
        NavMeshSha256 = source.Sha256;
        Vertices = new ReadOnlyCollection<Vector3>(vertices);
        Indices = new ReadOnlyCollection<int>(indices);
    }
}

/// <summary>
/// Unity 2018 CalculateTriangulation output for the five recovered co-op
/// NavMeshData assets. Geometry is pinned here; pathfinding is separate.
/// </summary>
public sealed class CoopNavMeshTriangulationCatalog
{
    private const string ArtifactSha256 =
        "87b0d457300a7e88bd7166d1a12e021f7ef73e1ba57b1e97831df4788fb314de";

    public IReadOnlyList<CoopNavMeshTriangulation> Maps { get; }

    private CoopNavMeshTriangulationCatalog(
        CoopNavMeshTriangulation[] maps)
    {
        Maps = new ReadOnlyCollection<CoopNavMeshTriangulation>(maps);
    }

    public CoopNavMeshTriangulation MapForMission(
        MissionCatalog missions, int missionIndex)
    {
        MissionMapRule expected = missions.MapForMission(missionIndex);
        CoopNavMeshTriangulation map = Maps[expected.Stage - 1];
        if (map.Scene != expected.Scene ||
            map.SceneSha256 != expected.SceneSha256)
            throw new InvalidDataException(
                "Co-op NavMesh triangles differ from the mission scene.");
        return map;
    }

    public static CoopNavMeshTriangulationCatalog Load(string manifestPath,
        MissionCatalog missions, CoopNavMeshSourceCatalog navigation)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(navigation);
        byte[] manifestBytes = File.ReadAllBytes(manifestPath);
        if (manifestBytes.Length is < 1_000 or > 8_192 ||
            Digest(manifestBytes) != ArtifactSha256)
            throw new InvalidDataException(
                "Co-op Unity triangulation manifest changed.");
        using JsonDocument document = JsonDocument.Parse(manifestBytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "unityVersion",
            "navigationSourceSha256", "maps");
        string directory = Path.GetDirectoryName(
            Path.GetFullPath(manifestPath))!;
        string sourcePath = Path.Combine(directory,
            "recovered-coop-navmesh-sources.json");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("unityVersion").GetString() != "2018.3.0f2" ||
            root.GetProperty("navigationSourceSha256").GetString() !=
                Digest(File.ReadAllBytes(sourcePath)))
            throw new InvalidDataException(
                "Co-op triangulation source manifest changed.");
        JsonElement entries = root.GetProperty("maps");
        if (entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() != 5 || navigation.Maps.Count != 5)
            throw new InvalidDataException(
                "Co-op triangulation needs five source maps.");

        var maps = new CoopNavMeshTriangulation[5];
        for (int index = 0; index < maps.Length; index++)
        {
            CoopNavMeshSource source = navigation.Maps[index];
            MissionMapRule mission = missions.Maps[index];
            JsonElement entry = entries[index];
            RequireFields(entry, "stage", "scene", "sceneSha256",
                "navMeshSha256", "file", "sha256", "vertices", "triangles");
            string filename = Path.GetFileNameWithoutExtension(
                source.PackagedAsset) + ".json";
            int vertexCount = entry.GetProperty("vertices").GetInt32();
            int triangleCount = entry.GetProperty("triangles").GetInt32();
            if (entry.GetProperty("stage").GetInt32() != source.Stage ||
                source.Stage != mission.Stage ||
                entry.GetProperty("scene").GetString() != source.Scene ||
                source.Scene != mission.Scene ||
                entry.GetProperty("sceneSha256").GetString() !=
                    source.SceneSha256 ||
                source.SceneSha256 != mission.SceneSha256 ||
                entry.GetProperty("navMeshSha256").GetString() !=
                    source.Sha256 ||
                entry.GetProperty("file").GetString() != filename ||
                vertexCount is < 100 or > 30_000 ||
                triangleCount is < 100 or > 33_333)
                throw new InvalidDataException(
                    "Co-op triangulation does not bind its source map.");

            string meshPath = Path.Combine(directory,
                "coop-navmesh-triangulation", filename);
            byte[] meshBytes = File.ReadAllBytes(meshPath);
            if (meshBytes.Length is < 10_000 or > 1_000_000 ||
                entry.GetProperty("sha256").GetString() != Digest(meshBytes))
                throw new InvalidDataException(
                    "Co-op triangulation bytes differ from Unity export.");
            using JsonDocument meshDocument = JsonDocument.Parse(meshBytes);
            JsonElement mesh = meshDocument.RootElement;
            RequireFields(mesh, "asset", "vertices", "indices", "areas");
            if (mesh.GetProperty("asset").GetString() !=
                    source.SourceAsset ||
                mesh.GetProperty("vertices").GetArrayLength() != vertexCount ||
                mesh.GetProperty("indices").GetArrayLength() !=
                    triangleCount * 3 ||
                mesh.GetProperty("areas").GetArrayLength() != triangleCount)
                throw new InvalidDataException(
                    "Co-op Unity mesh inventory is incomplete.");

            Vector3[] vertices = ReadVertices(
                mesh.GetProperty("vertices"), vertexCount);
            int[] indices = ReadIndices(mesh.GetProperty("indices"),
                vertices.Length, triangleCount * 3);
            foreach (JsonElement area in mesh.GetProperty("areas")
                         .EnumerateArray())
            {
                if (area.GetInt32() != 0)
                    throw new InvalidDataException(
                        "Co-op NavMesh has an unsupported walk area.");
            }
            maps[index] = new CoopNavMeshTriangulation(source,
                vertices, indices);
        }
        return new CoopNavMeshTriangulationCatalog(maps);
    }

    private static Vector3[] ReadVertices(JsonElement rows, int count)
    {
        var vertices = new Vector3[count];
        int index = 0;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            RequireFields(row, "x", "y", "z");
            var vertex = new Vector3(row.GetProperty("x").GetSingle(),
                row.GetProperty("y").GetSingle(),
                row.GetProperty("z").GetSingle());
            if (!PlayerHitbox.Finite(vertex) ||
                Vector3.Abs(vertex).X > 10_000 ||
                Vector3.Abs(vertex).Y > 10_000 ||
                Vector3.Abs(vertex).Z > 10_000)
                throw new InvalidDataException("Invalid co-op NavMesh vertex.");
            vertices[index++] = vertex;
        }
        return vertices;
    }

    private static int[] ReadIndices(JsonElement rows,
        int vertexCount, int count)
    {
        var indices = new int[count];
        int position = 0;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            int index = row.GetInt32();
            if (index < 0 || index >= vertexCount)
                throw new InvalidDataException(
                    "Co-op triangle references an unknown vertex.");
            indices[position++] = index;
        }
        return indices;
    }

    private static string Digest(byte[] bytes) =>
        Convert.ToHexStringLower(SHA256.HashData(bytes));

    private static void RequireFields(JsonElement row, params string[] names)
    {
        if (row.ValueKind != JsonValueKind.Object ||
            row.EnumerateObject().Count() != names.Length ||
            names.Any(name => !row.TryGetProperty(name, out _)))
            throw new InvalidDataException(
                "Co-op triangulation has unexpected fields.");
    }
}

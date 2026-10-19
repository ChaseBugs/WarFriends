using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Loads source-bound immutable polygon/detail surfaces; it does not select a Unity nearest polygon.</summary>
internal sealed class NavigationDetailCatalog
{
    private const string ManifestDigest = "ba29ce1669ebafb282bdc97e5e156e9c5b41053442e6f8819085fa88cfb2ad64";
    private const int MaximumArtifactBytes = 2_000_000;
    private const int ExpectedMaps = 5;
    private const int MaximumPolygonVertices = 6;
    internal sealed record Triangle(Vector3 First, Vector3 Second, Vector3 Third);
    internal sealed record Polygon(IReadOnlyList<Vector3> Boundary, IReadOnlyList<Triangle> Details);
    internal sealed record Map(string Name, IReadOnlyList<Polygon> Polygons);

    private NavigationDetailCatalog(Map[] maps)
    {
        Maps = Array.AsReadOnly(maps);
    }

    internal IReadOnlyList<Map> Maps { get; }

    internal static NavigationDetailCatalog Load(string contentDirectory)
    {
        byte[] manifest = ReadPinned(Path.Combine(contentDirectory,
            "recovered-coop-navmesh-detail.json"), ManifestDigest);
        using JsonDocument document = JsonDocument.Parse(manifest);
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 || root.GetProperty("tileVersion").GetInt32() != 16 ||
            root.GetProperty("maps").GetArrayLength() != ExpectedMaps)
        {
            throw new InvalidDataException("Navigation detail manifest identity changed.");
        }
        _ = ReadPinned(Path.Combine(contentDirectory, "recovered-coop-navmesh-sources.json"),
            Text(root, "sourceManifestSha256"));
        var maps = new List<Map>();
        foreach (JsonElement entry in root.GetProperty("maps").EnumerateArray())
        {
            maps.Add(LoadMap(contentDirectory, entry));
        }
        return new NavigationDetailCatalog(maps.ToArray());
    }

    private static Map LoadMap(string directory, JsonElement entry)
    {
        string filename = Text(entry, "file");
        byte[] artifact = ReadPinned(Path.Combine(directory, "coop-navmesh-detail", filename), Text(entry, "sha256"));
        using JsonDocument document = JsonDocument.Parse(artifact);
        JsonElement root = document.RootElement;
        byte[] source = ReadPinned(Path.Combine(directory, "coop-navmesh", Text(root, "source")),
            Text(entry, "sourceSha256"));
        if (Text(root, "sourceSha256") != Text(entry, "sourceSha256") ||
            root.GetProperty("tiles").GetArrayLength() != entry.GetProperty("tiles").GetInt32())
        {
            throw new InvalidDataException("Navigation detail source or tile count changed.");
        }
        var polygons = new List<Polygon>();
        var identities = new HashSet<(int, int, int)>();
        foreach (JsonElement tile in root.GetProperty("tiles").EnumerateArray())
        {
            VerifyTileSource(tile, source);
            int[] identity = Integers(tile.GetProperty("tile"));
            if (identity.Length != 3 || !identities.Add((identity[0], identity[1], identity[2])))
            {
                throw new InvalidDataException("Duplicate or incomplete navigation tile identity.");
            }
            for (int index = 0; index < tile.GetProperty("polygons").GetArrayLength(); index++)
            {
                polygons.Add(ReadPolygon(tile, index));
            }
        }
        if (polygons.Count != entry.GetProperty("polygons").GetInt32() ||
            polygons.Sum(polygon => polygon.Details.Count) != entry.GetProperty("detailTriangles").GetInt32())
        {
            throw new InvalidDataException("Navigation detail polygon or triangle totals changed.");
        }
        return new Map(Path.GetFileNameWithoutExtension(filename), polygons.AsReadOnly());
    }

    private static void VerifyTileSource(JsonElement tile, byte[] source)
    {
        int offset = tile.GetProperty("sourceOffset").GetInt32();
        int length = tile.GetProperty("bytes").GetInt32();
        bool isHex = Text(tile, "sourceEncoding") == "hex";
        int encodedLength = checked(length * (isHex ? 2 : 1));
        if (offset < 0 || length < 72 || encodedLength > source.Length || offset > source.Length - encodedLength)
        {
            throw new InvalidDataException("Navigation tile exceeds its pinned source payload.");
        }
        ReadOnlySpan<byte> stored = source.AsSpan(offset, encodedLength);
        byte[] payload = isHex ? Convert.FromHexString(System.Text.Encoding.ASCII.GetString(stored)) : stored.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(payload)) != Text(tile, "sha256"))
        {
            throw new InvalidDataException("Navigation tile payload digest changed.");
        }
    }

    private static Polygon ReadPolygon(JsonElement tile, int index)
    {
        int[] polygon = Integers(tile.GetProperty("polygons")[index]);
        int[] lane = Integers(tile.GetProperty("detailMeshes")[index]);
        if (polygon.Length != 14 || polygon[^1] is < 3 or > MaximumPolygonVertices || lane.Length != 4)
        {
            throw new InvalidDataException("Navigation polygon/detail lane shape changed.");
        }
        var vertices = new List<Vector3>();
        for (int vertex = 0; vertex < polygon[^1]; vertex++)
        {
            vertices.Add(Point(tile.GetProperty("vertices")[polygon[vertex]]));
        }
        Vector3[] boundary = vertices.ToArray();
        for (int vertex = 0; vertex < lane[2]; vertex++)
        {
            vertices.Add(Point(tile.GetProperty("detailVertices")[checked(lane[0] + vertex)]));
        }
        var triangles = new List<Triangle>();
        for (int triangle = 0; triangle < lane[3]; triangle++)
        {
            int[] row = Integers(tile.GetProperty("detailTriangles")[checked(lane[1] + triangle)]);
            if (row.Length != 4 || row.Take(3).Any(vertex => vertex < 0 || vertex >= vertices.Count))
            {
                throw new InvalidDataException("Navigation detail triangle exceeds its polygon vertices.");
            }
            triangles.Add(new Triangle(vertices[row[0]], vertices[row[1]], vertices[row[2]]));
        }
        return new Polygon(Array.AsReadOnly(boundary), triangles.AsReadOnly());
    }

    private static byte[] ReadPinned(string path, string digest)
    {
        var file = new FileInfo(path);
        if (file.Length is <= 0 or > MaximumArtifactBytes)
        {
            throw new InvalidDataException("Navigation detail artifact exceeds its bounded size.");
        }
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != digest)
        {
            throw new InvalidDataException("Navigation detail artifact digest changed.");
        }
        return bytes;
    }

    private static Vector3 Point(JsonElement point)
    {
        if (point.GetArrayLength() != 3)
        {
            throw new InvalidDataException("Navigation detail vertex requires three coordinates.");
        }
        var value = new Vector3(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle());
        if (!PlayerHitbox.Finite(value))
        {
            throw new InvalidDataException("Navigation detail vertex is not bounded and finite.");
        }
        return value;
    }

    private static int[] Integers(JsonElement row)
    {
        return row.EnumerateArray().Select(value => value.GetInt32()).ToArray();
    }

    private static string Text(JsonElement row, string field)
    {
        return row.GetProperty(field).GetString() ?? throw new InvalidDataException("Missing navigation identity.");
    }
}

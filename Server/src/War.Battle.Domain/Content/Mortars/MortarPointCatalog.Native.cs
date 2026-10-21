using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed partial class MortarPointCatalog
{
    private const string NativeRevision = "ab74aeff6a18b3c9c822089247600cec22df8fef1343cda59acbe58c2dc7c5d1";
    private const int NativePointCount = 40;
    private const float MaximumNativeHeightOffset = 0.5f;

    private static void AttachNativeSamples(string path, Dictionary<string, SourceMap> maps)
    {
        byte[] bytes = ReadArtifact(path);
        if (bytes.Length is < MinimumArtifactBytes or > MaximumArtifactBytes ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != NativeRevision)
        {
            throw new InvalidDataException("Mortar native NavMesh reference revision changed.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        Exact(root, "unityVersion", "points");
        if (root.GetProperty("unityVersion").GetString() != "2018.3.0f2" ||
            root.GetProperty("points").GetArrayLength() != NativePointCount)
        {
            throw new InvalidDataException("Mortar native reference requires all forty Unity observations.");
        }

        var samples = new Dictionary<(string Source, int Component), Vector3>();
        foreach (JsonElement row in root.GetProperty("points").EnumerateArray())
        {
            ReadNativeSample(row, maps, samples);
        }

        foreach (var (source, map) in maps.ToArray())
        {
            MortarPoint[] points = map.Points.Select(point => point with
            {
                NavMeshPosition = samples[(source, point.ComponentFileId)]
            }).ToArray();
            maps[source] = map with { Points = Array.AsReadOnly(points) };
        }
    }

    private static void ReadNativeSample(JsonElement row, Dictionary<string, SourceMap> maps,
        Dictionary<(string Source, int Component), Vector3> samples)
    {
        Exact(row, "source", "componentFileId", "isSampled", "position", "sampledPosition", "planarDistance");
        string source = row.GetProperty("source").GetString() ?? "";
        int component = row.GetProperty("componentFileId").GetInt32();
        MortarPoint? point = maps.GetValueOrDefault(source)?.Points.SingleOrDefault(candidate =>
            candidate.ComponentFileId == component);
        Vector3 authored = ReadNativePosition(row.GetProperty("position"));
        Vector3 sampled = ReadNativePosition(row.GetProperty("sampledPosition"));
        if (point == null || point.Position != authored || !row.GetProperty("isSampled").GetBoolean() ||
            row.GetProperty("planarDistance").GetSingle() != 0f ||
            sampled.X != authored.X || sampled.Z != authored.Z ||
            MathF.Abs(sampled.Y - authored.Y) > MaximumNativeHeightOffset ||
            !samples.TryAdd((source, component), sampled))
        {
            throw new InvalidDataException("Mortar native sample lost its authored point identity or vertical binding.");
        }
    }

    private static Vector3 ReadNativePosition(JsonElement coordinates)
    {
        float[] values = coordinates.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        if (values.Length != 3 || values.Any(value => !float.IsFinite(value) || MathF.Abs(value) > MaximumCoordinate))
        {
            throw new InvalidDataException("Mortar native position is malformed.");
        }

        return new Vector3(values[0], values[1], values[2]);
    }
}

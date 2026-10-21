using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Validates and freezes all ordinary Mortar destinations before host allocation.</summary>
public sealed partial class MortarPointCatalog
{
    private const string VerifiedRevision = "35142d2aece4eb37886f484d8dad66df31f187e949269df3de537bb2edae13f5";
    private const int MapCount = 5;
    private const int PointsPerFraction = 4;
    private const int MinimumArtifactBytes = 100;
    private const int MaximumArtifactBytes = 65536;
    private const int MaximumSourceOrder = 1024;
    private const int SourceBehaviorFileId = 41188;
    private const int SourcePointMask = 4096;
    private const int DigestLength = 64;
    private const float MaximumCoordinate = 10000f;
    private const float RotationTolerance = 0.001f;
    private readonly IReadOnlyDictionary<string, SourceMap> _maps;

    private MortarPointCatalog(Dictionary<string, SourceMap> maps)
    {
        _maps = maps;
    }

    /// <summary>Reads immutable source order; occupancy and nearest-point selection belong to the match.</summary>
    public IReadOnlyList<MortarPoint> ForMap(RecoveredBattleMap map)
    {
        ArgumentNullException.ThrowIfNull(map);
        return _maps.TryGetValue(map.Source, out var source) && source.Sha256 == map.SourceHash ? source.Points :
            throw new InvalidDataException("Mortar points do not contain this source map.");
    }

    /// <summary>Rejects altered bytes, scene provenance or incomplete point sets before publication.</summary>
    public static MortarPointCatalog Load(string path, IReadOnlyList<RecoveredBattleMap> maps)
    {
        byte[] bytes = ReadArtifact(path);
        if (bytes.Length is < MinimumArtifactBytes or > MaximumArtifactBytes ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != VerifiedRevision)
        {
            throw new InvalidDataException("Mortar point source revision differs from the verified extraction.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        Exact(root, "version", "unitSource", "maps");
        ValidateUnit(root.GetProperty("unitSource"));
        JsonElement sourceMaps = root.GetProperty("maps");
        if (root.GetProperty("version").GetInt32() != 1 || sourceMaps.GetArrayLength() != MapCount ||
            maps.Count != MapCount)
        {
            throw new InvalidDataException("Mortar requires the complete five-map source set.");
        }

        var accepted = new Dictionary<string, SourceMap>(StringComparer.Ordinal);
        for (int index = 0; index < MapCount; index++)
        {
            accepted.Add(maps[index].Source, new SourceMap(maps[index].SourceHash,
                ReadMap(sourceMaps[index], maps[index])));
        }

        string directory = Path.GetDirectoryName(Path.GetFullPath(path)) ??
            throw new InvalidDataException("Mortar point source directory is unavailable.");
        AttachNativeSamples(Path.Combine(directory, "mortar-points-unity-reference.json"), accepted);
        return new MortarPointCatalog(accepted);
    }

    private static IReadOnlyList<MortarPoint> ReadMap(JsonElement entry, RecoveredBattleMap map)
    {
        Exact(entry, "source", "sha256", "mapDefinitionFileId", "collectionComponentFileId", "points");
        if (entry.GetProperty("source").GetString() != map.Source ||
            entry.GetProperty("sha256").GetString() != map.SourceHash ||
            entry.GetProperty("mapDefinitionFileId").GetInt32() <= 0 ||
            entry.GetProperty("collectionComponentFileId").GetInt32() <= 0)
        {
            throw new InvalidDataException("Mortar destinations lost source scene/collection provenance.");
        }

        MortarPoint[] points = entry.GetProperty("points").EnumerateArray().Select(ReadPoint).ToArray();
        if (points.Count(point => point.Fraction == 1) != PointsPerFraction ||
            points.Count(point => point.Fraction == 2) != PointsPerFraction ||
            points.Select(point => point.ComponentFileId).Distinct().Count() != points.Length ||
            !points.Select(point => point.Order).SequenceEqual(points.Select(point => point.Order).Distinct().Order()))
        {
            throw new InvalidDataException("Mortar point counts, uniqueness or source order changed.");
        }

        return Array.AsReadOnly(points);
    }

    private static MortarPoint ReadPoint(JsonElement point)
    {
        Exact(point, "order", "componentFileId", "componentType", "gameObjectFileId", "transformFileId",
            "fraction", "worldPosition", "worldRotation");
        int order = point.GetProperty("order").GetInt32();
        int id = point.GetProperty("componentFileId").GetInt32();
        int fraction = point.GetProperty("fraction").GetInt32();
        float[] position = point.GetProperty("worldPosition").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        float[] rotation = point.GetProperty("worldRotation").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        if (order is < 0 or > MaximumSourceOrder || id <= 0 || fraction is not (1 or 2) ||
            point.GetProperty("componentType").GetString() != "EnemyPointMortar" ||
            point.GetProperty("gameObjectFileId").GetInt32() <= 0 ||
            point.GetProperty("transformFileId").GetInt32() <= 0 || position.Length != 3 || rotation.Length != 4 ||
            position.Concat(rotation).Any(value => !float.IsFinite(value) || MathF.Abs(value) > MaximumCoordinate) ||
            MathF.Abs(rotation.Sum(value => value * value) - 1f) > RotationTolerance)
        {
            throw new InvalidDataException("Invalid Mortar point identity or finite transform.");
        }

        Vector3 authoredPosition = new(position[0], position[1], position[2]);
        return new MortarPoint(order, id, fraction, authoredPosition, authoredPosition);
    }

    private static void ValidateUnit(JsonElement unit)
    {
        Exact(unit, "source", "sha256", "behaviorFileId", "enemyPointMask");
        string digest = unit.GetProperty("sha256").GetString() ?? "";
        if (unit.GetProperty("source").GetString() != "Assets/Scenes/MainScene.unity" ||
            digest.Length != DigestLength || digest.Any(character => !char.IsAsciiHexDigitLower(character)) ||
            unit.GetProperty("behaviorFileId").GetInt32() != SourceBehaviorFileId ||
            unit.GetProperty("enemyPointMask").GetInt32() != SourcePointMask)
        {
            throw new InvalidDataException("Mortar source point mask or unit provenance changed.");
        }
    }

    private static void Exact(JsonElement value, params string[] names)
    {
        if (value.ValueKind != JsonValueKind.Object || !value.EnumerateObject().Select(property => property.Name)
            .Order(StringComparer.Ordinal).SequenceEqual(names.Order(StringComparer.Ordinal)))
        {
            throw new InvalidDataException("Mortar source contains missing, duplicate or unknown fields.");
        }
    }

    private static byte[] ReadArtifact(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        if (stream.Length is < MinimumArtifactBytes or > MaximumArtifactBytes)
        {
            throw new InvalidDataException("Mortar point source size is outside the bounded artifact domain.");
        }

        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        if (stream.ReadByte() != -1)
        {
            throw new InvalidDataException("Mortar point source changed while reading.");
        }

        return bytes;
    }

    private sealed record SourceMap(string Sha256, IReadOnlyList<MortarPoint> Points);
}

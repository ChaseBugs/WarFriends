using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Validates and freezes all ordinary Gunslinger destinations before host allocation.</summary>
public sealed class GunslingerPointCatalog
{
    private const string VerifiedRevision = "2cedfa3154c81be469a9fde9f742eed1304ba3a4c3be511865d8d420be5ff059";
    private const int MapCount = 5;
    private const int PointsPerFraction = 3;
    private const int MinimumArtifactBytes = 100;
    private const int MaximumArtifactBytes = 65536;
    private const int MaximumSourceOrder = 1024;
    private const int SourceBehaviorFileId = 36243;
    private const int SourcePointMask = 2048;
    private const int DigestLength = 64;
    private const float MaximumCoordinate = 10000f;
    private const float RotationTolerance = 0.001f;
    private readonly IReadOnlyDictionary<string, SourceMap> _maps;

    private GunslingerPointCatalog(Dictionary<string, SourceMap> maps)
    {
        _maps = maps;
    }

    /// <summary>Reads immutable source order; occupancy and nearest-point selection belong to the match.</summary>
    public IReadOnlyList<GunslingerPoint> ForMap(RecoveredBattleMap map)
    {
        ArgumentNullException.ThrowIfNull(map);
        return _maps.TryGetValue(map.Source, out var source) && source.Sha256 == map.SourceHash ? source.Points :
            throw new InvalidDataException("Gunslinger points do not contain this source map.");
    }

    /// <summary>Rejects altered bytes, scene provenance or incomplete point sets before publication.</summary>
    public static GunslingerPointCatalog Load(string path, IReadOnlyList<RecoveredBattleMap> maps)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length is < MinimumArtifactBytes or > MaximumArtifactBytes ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != VerifiedRevision)
        {
            throw new InvalidDataException("Gunslinger point source revision differs from the verified extraction.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes, new JsonDocumentOptions { MaxDepth = 8 });
        JsonElement root = document.RootElement;
        Exact(root, "version", "unitSource", "maps");
        ValidateUnit(root.GetProperty("unitSource"));
        JsonElement sourceMaps = root.GetProperty("maps");
        if (root.GetProperty("version").GetInt32() != 1 || sourceMaps.GetArrayLength() != MapCount ||
            maps.Count != MapCount)
        {
            throw new InvalidDataException("Gunslinger requires the complete five-map source set.");
        }

        var accepted = new Dictionary<string, SourceMap>(StringComparer.Ordinal);
        for (int index = 0; index < MapCount; index++)
        {
            accepted.Add(maps[index].Source, new SourceMap(maps[index].SourceHash,
                ReadMap(sourceMaps[index], maps[index])));
        }

        return new GunslingerPointCatalog(accepted);
    }

    private static IReadOnlyList<GunslingerPoint> ReadMap(JsonElement entry, RecoveredBattleMap map)
    {
        Exact(entry, "source", "sha256", "mapDefinitionFileId", "collectionComponentFileId", "points");
        if (entry.GetProperty("source").GetString() != map.Source ||
            entry.GetProperty("sha256").GetString() != map.SourceHash ||
            entry.GetProperty("mapDefinitionFileId").GetInt32() <= 0 ||
            entry.GetProperty("collectionComponentFileId").GetInt32() <= 0)
        {
            throw new InvalidDataException("Gunslinger destinations lost source scene/collection provenance.");
        }

        GunslingerPoint[] points = entry.GetProperty("points").EnumerateArray().Select(ReadPoint).ToArray();
        if (points.Count(point => point.Fraction == 1) != PointsPerFraction ||
            points.Count(point => point.Fraction == 2) != PointsPerFraction ||
            points.Select(point => point.ComponentFileId).Distinct().Count() != points.Length ||
            !points.Select(point => point.Order).SequenceEqual(points.Select(point => point.Order).Distinct().Order()))
        {
            throw new InvalidDataException("Gunslinger point counts, uniqueness or source order changed.");
        }

        return Array.AsReadOnly(points);
    }

    private static GunslingerPoint ReadPoint(JsonElement point)
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
            point.GetProperty("componentType").GetString() != "EnemyPointGunslinger" ||
            point.GetProperty("gameObjectFileId").GetInt32() <= 0 ||
            point.GetProperty("transformFileId").GetInt32() <= 0 || position.Length != 3 || rotation.Length != 4 ||
            position.Concat(rotation).Any(value => !float.IsFinite(value) || MathF.Abs(value) > MaximumCoordinate) ||
            MathF.Abs(rotation.Sum(value => value * value) - 1f) > RotationTolerance)
        {
            throw new InvalidDataException("Invalid Gunslinger point identity or finite transform.");
        }

        return new GunslingerPoint(order, id, fraction, new Vector3(position[0], position[1], position[2]));
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
            throw new InvalidDataException("Gunslinger source point mask or unit provenance changed.");
        }
    }

    private static void Exact(JsonElement value, params string[] names)
    {
        if (value.ValueKind != JsonValueKind.Object || !value.EnumerateObject().Select(property => property.Name)
            .Order(StringComparer.Ordinal).SequenceEqual(names.Order(StringComparer.Ordinal)))
        {
            throw new InvalidDataException("Gunslinger source contains missing, duplicate or unknown fields.");
        }
    }

    private sealed record SourceMap(string Sha256, IReadOnlyList<GunslingerPoint> Points);
}

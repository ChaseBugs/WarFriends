using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// Original MapDefinition.spawnAreas in source list order. These are scene
/// BoxCollider world AABBs, which SpawnBonus samples independently by axis.
/// </summary>
public sealed class PvpBonusSpawnAreaCatalog
{
    private const string ReviewedSha256 =
        "9a21a16e2347e04647d9a4eb12d96962609154bcdd398838e5d82bf84c492d34";
    private readonly IReadOnlyDictionary<string, IReadOnlyList<PvpBonusSpawnArea>> byMapHash;

    private PvpBonusSpawnAreaCatalog(
        Dictionary<string, IReadOnlyList<PvpBonusSpawnArea>> areas)
    {
        byMapHash = new ReadOnlyDictionary<string, IReadOnlyList<PvpBonusSpawnArea>>(areas);
    }

    public IReadOnlyList<PvpBonusSpawnArea> ForMap(RecoveredBattleMap map)
    {
        ArgumentNullException.ThrowIfNull(map);
        return byMapHash.TryGetValue(map.SourceHash, out var areas)
            ? areas : throw new InvalidDataException("Map has no reviewed bonus spawn areas.");
    }

    public Vector3 Position(RecoveredBattleMap map, int areaOrder, Vector3 unitDraw)
    {
        var areas = ForMap(map);
        if (areaOrder < 0 || areaOrder >= areas.Count)
            throw new ArgumentOutOfRangeException(nameof(areaOrder));
        if (!Finite(unitDraw) || unitDraw.X is < 0 or > 1 ||
            unitDraw.Y is < 0 or > 1 || unitDraw.Z is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(unitDraw));
        var area = areas[areaOrder];
        // The caller owns the random draw. The source draws X, then Y, then Z
        // inside the selected BoxCollider.bounds; it does not sample its OBB.
        return new Vector3(
            Coordinate(area.BoundsMin.X, area.BoundsMax.X, unitDraw.X),
            Coordinate(area.BoundsMin.Y, area.BoundsMax.Y, unitDraw.Y),
            Coordinate(area.BoundsMin.Z, area.BoundsMax.Z, unitDraw.Z));
    }

    public static PvpBonusSpawnAreaCatalog Load(string path,
        IReadOnlyList<RecoveredBattleMap> maps)
    {
        ArgumentNullException.ThrowIfNull(maps);
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("PvP bonus spawn areas differ from reviewed Client scenes.");
        using var document = JsonDocument.Parse(bytes);
        var root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("maps").GetArrayLength() != maps.Count || maps.Count != 5)
            throw new InvalidDataException("Incomplete PvP bonus spawn maps.");
        var result = new Dictionary<string, IReadOnlyList<PvpBonusSpawnArea>>(StringComparer.Ordinal);
        foreach (var source in root.GetProperty("maps").EnumerateArray())
        {
            string scene = source.GetProperty("source").GetString() ?? "";
            string hash = source.GetProperty("sha256").GetString() ?? "";
            var map = maps.SingleOrDefault(candidate => candidate.Source == scene && candidate.SourceHash == hash)
                ?? throw new InvalidDataException("Bonus spawn scene does not bind the combat map.");
            var rows = source.GetProperty("areas");
            if (rows.GetArrayLength() != 2)
                throw new InvalidDataException("Incomplete source bonus spawn area pair.");
            var areas = new PvpBonusSpawnArea[2];
            var colliderIds = new HashSet<int>();
            int order = 0;
            foreach (var row in rows.EnumerateArray())
            {
                int collider = row.GetProperty("colliderFileId").GetInt32();
                if (row.GetProperty("order").GetInt32() != order ||
                    collider <= 0 || !colliderIds.Add(collider))
                    throw new InvalidDataException("Invalid ordered bonus spawn collider.");
                Vector3 min = ReadVector(row.GetProperty("boundsMin"));
                Vector3 max = ReadVector(row.GetProperty("boundsMax"));
                if (min.X >= max.X || min.Y >= max.Y || min.Z >= max.Z ||
                    !Finite(min) || !Finite(max) ||
                    Vector3.Max(Vector3.Abs(min), Vector3.Abs(max)).Length() > 10000)
                    throw new InvalidDataException("Invalid bonus spawn world bounds.");
                areas[order] = new(order, collider, min, max);
                order++;
            }
            if (!result.TryAdd(map.SourceHash, Array.AsReadOnly(areas)))
                throw new InvalidDataException("Duplicate bonus spawn map.");
        }
        return new PvpBonusSpawnAreaCatalog(result);
    }

    private static Vector3 ReadVector(JsonElement values)
    {
        if (values.ValueKind != JsonValueKind.Array || values.GetArrayLength() != 3)
            throw new InvalidDataException("Bonus spawn coordinate must have three axes.");
        return new(values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle());
    }

    private static bool Finite(Vector3 value) =>
        float.IsFinite(value.X) && float.IsFinite(value.Y) && float.IsFinite(value.Z);

    private static float Coordinate(float minimum, float maximum, float draw)
    {
        if (draw == 0) return minimum;
        if (draw == 1) return maximum;
        return minimum + (maximum - minimum) * draw;
    }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// CardGrenadesBurst uses Shield.hudIndicator.snapTransform as its spawn point.
/// That serialized transform differs from Shield.shotPosition on all five maps.
/// </summary>
internal sealed class CardGrenadeOriginCatalog
{
    private const string ReviewedSha256 =
        "3ffed2e73f7ddb656a117c00b04e4f578af3179c8e0ea50c679c5680b867d515";
    private readonly IReadOnlyDictionary<string, Vector3[]> positionsByMap;

    private CardGrenadeOriginCatalog(Dictionary<string, Vector3[]> positionsByMap)
    {
        this.positionsByMap = positionsByMap;
    }

    internal Vector3 ForCover(RecoveredBattleMap map, int coverIndex)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (!positionsByMap.TryGetValue(map.SourceHash, out var positions) ||
            coverIndex < 0 || coverIndex >= positions.Length)
            throw new InvalidDataException("Card grenade origin has no source cover.");
        return positions[coverIndex];
    }

    internal static CardGrenadeOriginCatalog Load(string path,
        IReadOnlyList<RecoveredBattleMap> maps)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("Card grenade origins differ from reviewed scenes.");
        using var document = JsonDocument.Parse(bytes);
        var root = document.RootElement;
        if (root.GetProperty("client").GetString() != "1.4.0" ||
            root.GetProperty("maps").GetArrayLength() != maps.Count || maps.Count != 5)
            throw new InvalidDataException("Incomplete card grenade map sources.");

        var result = new Dictionary<string, Vector3[]>(StringComparer.Ordinal);
        foreach (var source in root.GetProperty("maps").EnumerateArray())
        {
            string scene = source.GetProperty("source").GetString() ?? "";
            string hash = source.GetProperty("sha256").GetString() ?? "";
            var map = maps.SingleOrDefault(candidate =>
                candidate.Source == scene && candidate.SourceHash == hash) ??
                throw new InvalidDataException("Card grenade scene does not match its map.");
            var rows = source.GetProperty("origins");
            if (rows.GetArrayLength() != map.Covers.Count)
                throw new InvalidDataException("Incomplete card grenade cover origins.");
            var positions = new Vector3[map.Covers.Count];
            var componentIds = new HashSet<int>();
            int index = 0;
            foreach (var row in rows.EnumerateArray())
            {
                int snapId = row.GetProperty("snapTransformFileId").GetInt32();
                int shotId = row.GetProperty("shotPositionFileId").GetInt32();
                var axes = row.GetProperty("position");
                if (row.GetProperty("sourceIndex").GetInt32() != index ||
                    row.GetProperty("playerPointFileId").GetInt32() <= 0 ||
                    row.GetProperty("shieldFileId").GetInt32() <= 0 ||
                    row.GetProperty("hudIndicatorFileId").GetInt32() <= 0 ||
                    snapId <= 0 || shotId <= 0 || snapId == shotId ||
                    !componentIds.Add(snapId) || axes.GetArrayLength() != 3)
                    throw new InvalidDataException("Invalid source card grenade origin chain.");
                var position = new Vector3(axes[0].GetSingle(),
                    axes[1].GetSingle(), axes[2].GetSingle());
                if (!float.IsFinite(position.X) || !float.IsFinite(position.Y) ||
                    !float.IsFinite(position.Z) ||
                    Vector3.Distance(position, map.Covers[index].ShotPosition) is
                        < 0.01f or > 1f)
                    throw new InvalidDataException("Card grenade origin is outside its shield.");
                positions[index++] = position;
            }
            if (!result.TryAdd(map.SourceHash, positions))
                throw new InvalidDataException("Duplicate card grenade map.");
        }
        return new CardGrenadeOriginCatalog(result);
    }
}

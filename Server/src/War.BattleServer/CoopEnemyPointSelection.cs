using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSoldierPointMask(
    int BehaviorFileId, string BehaviorType, string UnitId, int Mask,
    float? MinimumPlayerDistance);

/// <summary>Serialized starting masks from MainScene, bound to the army catalog.</summary>
public sealed class CoopEnemyPointMaskCatalog
{
    private const string ArtifactSha256 =
        "af006a1b961d38addc05ca60e90aa63b881467145c7e88fe35e9afb481eb853b";

    public IReadOnlyList<CoopSoldierPointMask> Soldiers { get; }

    private CoopEnemyPointMaskCatalog(CoopSoldierPointMask[] soldiers)
    {
        Soldiers = Array.AsReadOnly(soldiers);
    }

    public static CoopEnemyPointMaskCatalog Load(string path, ArmyDeploymentCatalog army)
    {
        ArgumentNullException.ThrowIfNull(army);
        byte[] source = File.ReadAllBytes(path);
        if (source.Length is < 1_000 or > 10_000 ||
            Convert.ToHexStringLower(SHA256.HashData(source)) != ArtifactSha256)
            throw new InvalidDataException("Co-op soldier masks differ from MainScene.");

        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "soldiers");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() !=
                "d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43")
            throw new InvalidDataException("Co-op soldier mask source changed.");

        JsonElement rows = root.GetProperty("soldiers");
        ArmyDeploymentFamily[] soldierFamilies = army.Families
            .Where(family => family.IsSoldier).ToArray();
        if (rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != 16 || soldierFamilies.Length != 16)
            throw new InvalidDataException("Co-op soldier mask inventory changed.");

        var soldiers = new CoopSoldierPointMask[16];
        for (int index = 0; index < soldiers.Length; index++)
        {
            JsonElement row = rows[index];
            ArmyDeploymentFamily family = soldierFamilies[index];
            bool sniper = family.BehaviorType == "SoldierBehaviourSniper";
            if (sniper)
                RequireFields(row, "behaviorFileId", "behaviorType", "unitId",
                    "enemyPointMask", "minimumPlayerDistance");
            else
                RequireFields(row, "behaviorFileId", "behaviorType", "unitId",
                    "enemyPointMask");
            int mask = row.GetProperty("enemyPointMask").GetInt32();
            float? minimumDistance = sniper
                ? row.GetProperty("minimumPlayerDistance").GetSingle() : null;
            if (row.GetProperty("behaviorFileId").GetInt32() != family.BehaviorFileId ||
                row.GetProperty("behaviorType").GetString() != family.BehaviorType ||
                row.GetProperty("unitId").GetString() != family.UnitId ||
                mask is <= 0 or > 0x3FFF ||
                (sniper && minimumDistance != 6f))
                throw new InvalidDataException("Co-op soldier mask is not bound to its unit.");
            soldiers[index] = new CoopSoldierPointMask(family.BehaviorFileId,
                family.BehaviorType, family.UnitId, mask,
                minimumDistance);
        }
        return new CoopEnemyPointMaskCatalog(soldiers);
    }

    private static void RequireFields(JsonElement row, params string[] names)
    {
        if (row.ValueKind != JsonValueKind.Object ||
            row.EnumerateObject().Count() != names.Length ||
            names.Any(name => !row.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op soldier mask has unexpected fields.");
    }
}

/// <summary>
/// SpawningManager.GetPoint's ordinary nearest-free choice. Callers must supply
/// the behavior's current mask; several subclasses override acceptance or
/// change that mask during their lifecycle.
/// </summary>
public static class CoopEnemyPointSelection
{
    /// <summary>
    /// GetNextFreeEnemyPoint and the Sniper/SciFi overrides choose a random
    /// eligible point in source list order. SciFi first prefers points more
    /// than 1.8 units from its current position, then falls back to all.
    /// </summary>
    public static CoopEnemyPoint? SelectNext(
        CoopMapEnemyPoints map, int currentMask, int currentPointId,
        IReadOnlySet<int> occupiedComponentIds, Func<int, int> chooseIndex,
        Vector3? sniperOpponentPosition = null,
        float minimumPlayerDistance = 0,
        Vector3? sciFiPosition = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(occupiedComponentIds);
        ArgumentNullException.ThrowIfNull(chooseIndex);
        if (currentMask is <= 0 or > 0x3FFF || currentPointId <= 0 ||
            !float.IsFinite(minimumPlayerDistance) ||
            minimumPlayerDistance < 0 ||
            (minimumPlayerDistance > 0 && sniperOpponentPosition == null) ||
            (sniperOpponentPosition.HasValue &&
             !PlayerHitbox.Finite(sniperOpponentPosition.Value)) ||
            (sciFiPosition.HasValue &&
             !PlayerHitbox.Finite(sciFiPosition.Value)))
            throw new ArgumentOutOfRangeException(nameof(currentMask));

        var candidates = new List<CoopEnemyPoint>();
        foreach (CoopEnemyPoint point in map.Points)
        {
            int pointType = PointType(point.ComponentType);
            if (point.ComponentFileId == currentPointId ||
                (currentMask & pointType) != pointType ||
                occupiedComponentIds.Contains(point.ComponentFileId))
                continue;
            if (sniperOpponentPosition.HasValue &&
                Vector3.Distance(point.Position,
                    sniperOpponentPosition.Value) <= minimumPlayerDistance)
                continue;
            candidates.Add(point);
        }
        if (candidates.Count == 0)
            return null;
        if (sciFiPosition.HasValue)
        {
            List<CoopEnemyPoint> distant = candidates.Where(point =>
                Vector3.Distance(point.Position,
                    sciFiPosition.Value) > 1.8f).ToList();
            if (distant.Count > 0)
                candidates = distant;
        }
        int selectedIndex = chooseIndex(candidates.Count);
        if (selectedIndex < 0 || selectedIndex >= candidates.Count)
            throw new InvalidDataException(
                "Host co-op enemy point draw is outside the source list.");
        return candidates[selectedIndex];
    }

    /// <summary>
    /// SoldierBehaviourSciFi.GetInitPoint calls GetNearestFreePoint with the
    /// map floorTransform. Unlike GetPoint, this compares effective positions.
    /// </summary>
    public static CoopEnemyPoint? SelectNearestToFloor(
        CoopMapEnemyPoints map, int currentMask,
        IReadOnlySet<int> occupiedComponentIds)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(occupiedComponentIds);
        if (currentMask is <= 0 or > 0x3FFF)
            throw new ArgumentOutOfRangeException(nameof(currentMask));

        CoopEnemyPoint? selected = null;
        float nearestDistance = float.MaxValue;
        foreach (CoopEnemyPoint point in map.Points)
        {
            int pointType = PointType(point.ComponentType);
            if ((currentMask & pointType) != pointType ||
                occupiedComponentIds.Contains(point.ComponentFileId))
                continue;
            float distance = Vector3.Distance(point.Position,
                map.FloorPosition);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                selected = point;
            }
        }
        return selected;
    }

    /// <summary>
    /// Some soldiers override AcceptsPoint or change their mask before their
    /// initial GetPoint call. Rusher descendants use a separate shield-linked
    /// point list and must not enter this ordinary selection path.
    /// </summary>
    public static int InitialMask(CoopSoldierPointMask soldier, bool spawnedByCard)
    {
        ArgumentNullException.ThrowIfNull(soldier);
        return soldier.BehaviorType switch
        {
            "SoldierBehaviourEngineer" => 256,
            "SoldierBehaviourParachuter" when spawnedByCard => 6,
            "SoldierBehaviourSwat" when spawnedByCard => 32,
            "SoldierBehaviourParachuter" or "SoldierBehaviourSwat" =>
                throw new NotSupportedException(
                    "Ordinary Rusher initial points require the active player shield."),
            "SoldierBehaviourCommando" or "SoldierBehaviourFlamethrower" or
            "SoldierBehaviourShotgunner" or "SoldierBehaviourWarper" =>
                throw new NotSupportedException(
                    "Rusher initial points require the active player shield."),
            _ => soldier.Mask
        };
    }

    public static CoopEnemyPoint? SelectOrdinary(
        CoopMapEnemyPoints map, int currentMask, Vector3 soldierPosition,
        IReadOnlySet<int> occupiedComponentIds,
        Vector3? opposingPlayerPosition = null, float minimumPlayerDistance = 0)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(occupiedComponentIds);
        if (currentMask is <= 0 or > 0x3FFF ||
            !PlayerHitbox.Finite(soldierPosition) ||
            !float.IsFinite(minimumPlayerDistance) || minimumPlayerDistance < 0 ||
            (opposingPlayerPosition.HasValue &&
             !PlayerHitbox.Finite(opposingPlayerPosition.Value)) ||
            (minimumPlayerDistance > 0 && !opposingPlayerPosition.HasValue))
            throw new ArgumentOutOfRangeException(nameof(currentMask));

        CoopEnemyPoint? selected = null;
        float nearestDistance = float.MaxValue;
        foreach (CoopEnemyPoint point in map.Points)
        {
            int pointType = PointType(point.ComponentType);
            if ((currentMask & pointType) != pointType ||
                occupiedComponentIds.Contains(point.ComponentFileId))
                continue;

            // Sniper.GetInitPoint supplies the opponent transform and a strict
            // minimum. This check uses EnemyPoint.position, whereas the final
            // nearest-point comparison below uses the point transform.
            if (opposingPlayerPosition.HasValue &&
                Vector3.Distance(point.Position,
                    opposingPlayerPosition.Value) <= minimumPlayerDistance)
                continue;

            // The Client compares the point Transform, including for obstacle
            // segments whose final randomized position is decided later.
            float distance = Vector3.Distance(soldierPosition,
                point.TransformPosition);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                selected = point;
            }
        }
        return selected;
    }

    private static int PointType(string componentType) => componentType switch
    {
        "EnemyPointRusher" => 1,
        "EnemyPointObstacle" => 2,
        "EnemyPointCorner" => 4,
        "EnemyPointSwat" => 32,
        "EnemyPointMinigunner" => 128,
        "EnemyPointEngineerTurret" => 256,
        "EnemyPointRusherSpare" => 1024,
        "EnemyPointGunslinger" => 2048,
        "EnemyPointMortar" => 4096,
        "EnemyPointMech" => 8192,
        _ => throw new InvalidDataException("Unknown co-op enemy point type.")
    };

    /// <summary>
    /// EnemyPoint.GeneratePosition runs after SetFinalTarget reserves the
    /// point. Only obstacle points randomize; other subclasses use their
    /// validated fixed/effective position.
    /// </summary>
    public static Vector3 GeneratePosition(CoopEnemyPoint point,
        float obstacleFraction)
    {
        ArgumentNullException.ThrowIfNull(point);
        if (!float.IsFinite(obstacleFraction) ||
            obstacleFraction < 0 || obstacleFraction > 1)
            throw new ArgumentOutOfRangeException(nameof(obstacleFraction));
        if (point.ComponentType != "EnemyPointObstacle")
            return point.Position;
        if (point.SegmentStart is not Vector3 start ||
            point.SegmentEnd is not Vector3 end)
            throw new InvalidDataException("Obstacle destination lacks its segment.");
        return Vector3.Lerp(start, end, obstacleFraction);
    }
}

/// <summary>
/// Server-owned equivalent of EnemyPoint.enemyAtPoint. A target is reserved
/// before an enemy starts walking; releasing a dead or retargeted enemy frees it.
/// </summary>
public sealed class CoopEnemyPointReservations
{
    private readonly HashSet<int> knownPointIds;
    private readonly Dictionary<ulong, int> pointByEnemy = [];
    private readonly Dictionary<int, ulong> enemyByPoint = [];
    private readonly HashSet<int> blockedByTurret = [];

    public IReadOnlySet<int> OccupiedPointIds => enemyByPoint.Keys
        .Concat(blockedByTurret).ToHashSet();

    public CoopEnemyPointReservations(CoopMapEnemyPoints map)
    {
        ArgumentNullException.ThrowIfNull(map);
        knownPointIds = map.Points.Select(point => point.ComponentFileId)
            .ToHashSet();
        if (knownPointIds.Count != map.Points.Count)
            throw new InvalidDataException("Co-op map has duplicate destination IDs.");
    }

    public bool TryReserve(ulong enemyId, CoopEnemyPoint target)
    {
        ArgumentNullException.ThrowIfNull(target);
        if (enemyId == 0 || !knownPointIds.Contains(target.ComponentFileId))
            throw new ArgumentOutOfRangeException(nameof(enemyId));
        int pointId = target.ComponentFileId;
        if (blockedByTurret.Contains(pointId) ||
            enemyByPoint.TryGetValue(pointId, out ulong owner) &&
            owner != enemyId)
            return false;
        if (pointByEnemy.TryGetValue(enemyId, out int previousPoint))
        {
            if (previousPoint == pointId)
                return true;
            enemyByPoint.Remove(previousPoint);
        }
        pointByEnemy[enemyId] = pointId;
        enemyByPoint[pointId] = enemyId;
        return true;
    }

    public bool Release(ulong enemyId)
    {
        if (!pointByEnemy.Remove(enemyId, out int pointId))
            return false;
        enemyByPoint.Remove(pointId);
        return true;
    }

    public void SetEngineerTurret(CoopEnemyPoint point, bool present)
    {
        ArgumentNullException.ThrowIfNull(point);
        if (point.ComponentType != "EnemyPointEngineerTurret" ||
            !knownPointIds.Contains(point.ComponentFileId))
            throw new ArgumentException(
                "Point is not a turret destination on this map.", nameof(point));
        if (present)
            blockedByTurret.Add(point.ComponentFileId);
        else
            blockedByTurret.Remove(point.ComponentFileId);
    }
}

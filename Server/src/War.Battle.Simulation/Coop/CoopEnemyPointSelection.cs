using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// SpawningManager.GetPoint's ordinary nearest-free choice. Callers must supply
/// the behavior's current mask; several subclasses override acceptance or
/// change that mask during their lifecycle.
/// </summary>
public static class CoopEnemyPointSelection
{
    private const int SupportedPointMask = 0x3FFF;

    /// <summary>
    /// Selects an ordinary next point when the current seat belongs to another asset, not this scene point list.
    /// </summary>
    public static CoopEnemyPoint? SelectFromExternalPoint(CoopMapEnemyPoints map, int currentMask,
        IReadOnlySet<int> occupiedComponentIds, Func<int, int> chooseIndex)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(occupiedComponentIds);
        ArgumentNullException.ThrowIfNull(chooseIndex);
        if (currentMask is <= 0 or > SupportedPointMask)
        {
            throw new ArgumentOutOfRangeException(nameof(currentMask));
        }
        var candidates = new List<CoopEnemyPoint>();
        foreach (CoopEnemyPoint point in map.Points)
        {
            int pointType = PointType(point.ComponentType);
            if ((currentMask & pointType) == pointType && !occupiedComponentIds.Contains(point.ComponentFileId))
            {
                candidates.Add(point);
            }
        }
        if (candidates.Count == 0)
        {
            return null;
        }
        int selectedIndex = chooseIndex(candidates.Count);
        if (selectedIndex < 0 || selectedIndex >= candidates.Count)
        {
            throw new InvalidDataException("Host external-point draw is outside the source candidate list.");
        }
        // Unity compares object references here. A prefab-local seat file ID must not exclude an unrelated scene ID.
        return candidates[selectedIndex];
    }

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

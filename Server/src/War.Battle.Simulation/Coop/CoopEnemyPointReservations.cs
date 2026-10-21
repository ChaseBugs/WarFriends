using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

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

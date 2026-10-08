using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSoldierPointMask(
    int BehaviorFileId, string BehaviorType, string UnitId, int Mask);

/// <summary>Serialized starting masks from MainScene, bound to the army catalog.</summary>
public sealed class CoopEnemyPointMaskCatalog
{
    private const string ArtifactSha256 =
        "3b15abe0ddc40669154bd6ba5cc7b3a0011f60ed6f5758fbfd2b132ac09d0caf";

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
            RequireFields(row, "behaviorFileId", "behaviorType", "unitId",
                "enemyPointMask");
            int mask = row.GetProperty("enemyPointMask").GetInt32();
            if (row.GetProperty("behaviorFileId").GetInt32() != family.BehaviorFileId ||
                row.GetProperty("behaviorType").GetString() != family.BehaviorType ||
                row.GetProperty("unitId").GetString() != family.UnitId ||
                mask is <= 0 or > 0x3FFF)
                throw new InvalidDataException("Co-op soldier mask is not bound to its unit.");
            soldiers[index] = new CoopSoldierPointMask(family.BehaviorFileId,
                family.BehaviorType, family.UnitId, mask);
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

    public IReadOnlySet<int> OccupiedPointIds => enemyByPoint.Keys.ToHashSet();

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
        if (enemyByPoint.TryGetValue(pointId, out ulong owner) &&
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
}

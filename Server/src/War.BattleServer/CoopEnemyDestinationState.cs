using System.Numerics;

namespace War.BattleServer;

public sealed record CoopAssignedEnemyDestination(
    int PointComponentFileId, Vector3 Position);

/// <summary>
/// Initial enemy destination claims for one co-op map. The Client reserves
/// enemyAtPoint in EnemyController.SetFinalTarget before walking. Movement and
/// later behavior-specific retargeting are separate host transitions.
/// </summary>
public sealed class CoopEnemyDestinationState
{
    private readonly CoopMapEnemyPoints map;
    private readonly CoopEnemyPointMaskCatalog masks;
    private readonly CoopEnemyCombatCatalog combat;
    private readonly CoopEnemyPointReservations reservations;
    private readonly CoopMapRusherPoints? rusherPoints;
    private readonly HashSet<int> occupiedRusherPoints = [];
    private readonly Dictionary<ulong, int> rusherPointByEnemy = [];
    private readonly Func<float> chooseObstacleFraction;
    private readonly Func<int, int> chooseNextPoint;
    private readonly Dictionary<ulong, CoopAssignedEnemyDestination> assigned = [];
    private bool boundToMatch;

    public string Scene => map.Scene;
    public string SceneSha256 => map.SceneSha256;
    internal bool UsesCombat(CoopEnemyCombatCatalog source) =>
        ReferenceEquals(combat, source);

    public CoopEnemyDestinationState(CoopMapEnemyPoints map,
        CoopEnemyPointMaskCatalog masks, CoopEnemyCombatCatalog combat,
        Func<float>? chooseObstacleFraction = null,
        CoopMapRusherPoints? rusherPoints = null,
        Func<int, int>? chooseNextPoint = null)
    {
        this.map = map ?? throw new ArgumentNullException(nameof(map));
        this.masks = masks ?? throw new ArgumentNullException(nameof(masks));
        this.combat = combat ?? throw new ArgumentNullException(nameof(combat));
        reservations = new CoopEnemyPointReservations(map);
        if (rusherPoints != null &&
            (rusherPoints.Scene != map.Scene ||
             rusherPoints.SceneSha256 != map.SceneSha256))
            throw new InvalidDataException(
                "Shield-linked Rusher points differ from the enemy map.");
        this.rusherPoints = rusherPoints;
        this.chooseObstacleFraction = chooseObstacleFraction ?? Random.Shared.NextSingle;
        this.chooseNextPoint = chooseNextPoint ?? Random.Shared.Next;
    }

    public CoopAssignedEnemyDestination? ForEnemy(ulong entityId) =>
        assigned.GetValueOrDefault(entityId);

    internal string? PointTypeFor(ulong entityId)
    {
        CoopAssignedEnemyDestination? destination = ForEnemy(entityId);
        if (destination == null)
            return null;
        return map.Points.Single(point =>
            point.ComponentFileId == destination.PointComponentFileId)
            .ComponentType;
    }

    internal CoopAssignedEnemyDestination? RegenerateObstaclePosition(
        ulong entityId)
    {
        if (!assigned.TryGetValue(entityId,
                out CoopAssignedEnemyDestination? current))
            return null;
        CoopEnemyPoint point = map.Points.Single(candidate =>
            candidate.ComponentFileId == current.PointComponentFileId);
        if (point.ComponentType != "EnemyPointObstacle")
            return null;

        // EnemyController.SetFinalTarget calls GeneratePosition again while
        // keeping enemyAtPoint on this same obstacle component.
        Vector3 newPosition = CoopEnemyPointSelection.GeneratePosition(
            point, chooseObstacleFraction());
        var replacement = current with { Position = newPosition };
        assigned[entityId] = replacement;
        return replacement;
    }

    internal void BindToMatch()
    {
        if (boundToMatch)
            throw new InvalidOperationException(
                "Co-op destination state already belongs to a match.");
        boundToMatch = true;
    }

    public CoopAssignedEnemyDestination? TryAssignInitial(
        ulong entityId, string behaviour, bool spawnedByCard,
        Vector3 spawnPosition, int? targetPlayerPositionIndex = null,
        Vector3? sniperOpponentPosition = null)
    {
        if (entityId == 0 || !PlayerHitbox.Finite(spawnPosition))
            throw new ArgumentOutOfRangeException(nameof(entityId));
        if (assigned.ContainsKey(entityId))
            throw new InvalidOperationException("Enemy already owns a destination.");

        string unitId = combat.UnitIdFor(behaviour);
        CoopSoldierPointMask? soldier = masks.Soldiers.FirstOrDefault(row =>
            row.UnitId == unitId);
        if (soldier == null)
            return null;
        if (soldier.BehaviorType == "SoldierBehaviourSniper" &&
            sniperOpponentPosition == null)
            return null;
        if (IsShieldLinkedRusher(soldier, spawnedByCard))
            return AssignRusher(entityId, spawnPosition,
                targetPlayerPositionIndex);

        int mask = CoopEnemyPointSelection.InitialMask(soldier, spawnedByCard);
        CoopEnemyPoint? point = soldier.BehaviorType ==
            "SoldierBehaviourSciFi"
            ? CoopEnemyPointSelection.SelectNearestToFloor(
                map, mask, reservations.OccupiedPointIds)
            : CoopEnemyPointSelection.SelectOrdinary(
                map, mask, spawnPosition, reservations.OccupiedPointIds,
                sniperOpponentPosition, soldier.MinimumPlayerDistance ?? 0);
        if (point == null)
            return null;
        if (!reservations.TryReserve(entityId, point))
            throw new InvalidOperationException("Selected co-op point became occupied.");

        // GeneratePosition follows SetFinalTarget's reservation in the Client.
        try
        {
            float fraction = point.ComponentType == "EnemyPointObstacle"
                ? chooseObstacleFraction() : 0f;
            Vector3 position = CoopEnemyPointSelection.GeneratePosition(
                point, fraction);
            var destination = new CoopAssignedEnemyDestination(
                point.ComponentFileId, position);
            assigned.Add(entityId, destination);
            return destination;
        }
        catch
        {
            reservations.Release(entityId);
            throw;
        }
    }

    public bool Release(ulong entityId)
    {
        if (!assigned.Remove(entityId))
            return false;
        reservations.Release(entityId);
        if (rusherPointByEnemy.Remove(entityId, out int rusherPointId))
            occupiedRusherPoints.Remove(rusherPointId);
        return true;
    }

    /// <summary>
    /// Host AI calls this when the recovered behavior asks for a new point.
    /// It does not advance a soldier or decide when that behavior runs.
    /// </summary>
    public CoopAssignedEnemyDestination? TryRetarget(
        ulong entityId, string behaviour, bool spawnedByCard,
        Vector3 currentPosition, Vector3? sniperOpponentPosition = null)
    {
        if (!PlayerHitbox.Finite(currentPosition))
            throw new ArgumentOutOfRangeException(nameof(currentPosition));
        if (!assigned.TryGetValue(entityId, out CoopAssignedEnemyDestination? old))
            return null;
        string unitId = combat.UnitIdFor(behaviour);
        CoopSoldierPointMask? soldier = masks.Soldiers.FirstOrDefault(row =>
            row.UnitId == unitId);
        if (soldier == null || IsShieldLinkedRusher(soldier, spawnedByCard) ||
            (soldier.BehaviorType == "SoldierBehaviourSniper" &&
             sniperOpponentPosition == null))
            return null;

        int mask = CoopEnemyPointSelection.InitialMask(soldier, spawnedByCard);
        Vector3? sciFiPosition = soldier.BehaviorType ==
            "SoldierBehaviourSciFi" ? currentPosition : null;
        CoopEnemyPoint? next = CoopEnemyPointSelection.SelectNext(map, mask,
            old.PointComponentFileId, reservations.OccupiedPointIds,
            chooseNextPoint, sniperOpponentPosition,
            soldier.MinimumPlayerDistance ?? 0, sciFiPosition);
        if (next == null)
            return null;

        float fraction = next.ComponentType == "EnemyPointObstacle"
            ? chooseObstacleFraction() : 0f;
        Vector3 position = CoopEnemyPointSelection.GeneratePosition(next,
            fraction);
        if (!reservations.TryReserve(entityId, next))
            throw new InvalidOperationException("Selected co-op point became occupied.");
        var replacement = new CoopAssignedEnemyDestination(
            next.ComponentFileId, position);
        assigned[entityId] = replacement;
        return replacement;
    }

    public void ReleaseAll()
    {
        foreach (ulong entityId in assigned.Keys.ToArray())
            Release(entityId);
    }

    private static bool IsShieldLinkedRusher(
        CoopSoldierPointMask soldier, bool spawnedByCard)
    {
        if (soldier.BehaviorType is "SoldierBehaviourParachuter" or
            "SoldierBehaviourSwat")
            return !spawnedByCard;
        return soldier.BehaviorType is "SoldierBehaviourCommando" or
            "SoldierBehaviourFlamethrower" or "SoldierBehaviourShotgunner" or
            "SoldierBehaviourWarper";
    }

    public bool RequiresShieldTarget(string behaviour, bool spawnedByCard)
    {
        string unitId = combat.UnitIdFor(behaviour);
        CoopSoldierPointMask? soldier = masks.Soldiers.FirstOrDefault(row =>
            row.UnitId == unitId);
        return rusherPoints != null && soldier != null &&
            IsShieldLinkedRusher(soldier, spawnedByCard);
    }

    public bool RequiresSniperTarget(string behaviour)
    {
        string unitId = combat.UnitIdFor(behaviour);
        return masks.Soldiers.Any(soldier =>
            soldier.UnitId == unitId &&
            soldier.BehaviorType == "SoldierBehaviourSniper");
    }

    private CoopAssignedEnemyDestination? AssignRusher(
        ulong entityId, Vector3 spawnPosition, int? targetPlayerPositionIndex)
    {
        if (rusherPoints == null || targetPlayerPositionIndex == null)
            return null;
        CoopPlayerRusherPoints? target = rusherPoints.PlayerPoints
            .FirstOrDefault(player => player.PlayerPositionIndex ==
                targetPlayerPositionIndex.Value);
        if (target == null)
            throw new ArgumentOutOfRangeException(nameof(targetPlayerPositionIndex));

        CoopRusherPoint? point = CoopRusherPointCatalog.ChooseInitial(
            target, spawnPosition, occupiedRusherPoints,
            occupiedRusherPoints.Count);
        if (point != null)
        {
            if (!occupiedRusherPoints.Add(point.ComponentFileId))
                throw new InvalidOperationException("Rusher point was already reserved.");
            rusherPointByEnemy.Add(entityId, point.ComponentFileId);
            var destination = new CoopAssignedEnemyDestination(
                point.ComponentFileId, point.Position);
            assigned.Add(entityId, destination);
            return destination;
        }

        // SoldierBehaviourRusher replaces its mask with RusherSpare when no
        // shield-linked point is available or four are already occupied.
        CoopEnemyPoint? spare = CoopEnemyPointSelection.SelectOrdinary(
            map, 1024, spawnPosition, reservations.OccupiedPointIds);
        if (spare == null || !reservations.TryReserve(entityId, spare))
            return null;
        var fallback = new CoopAssignedEnemyDestination(
            spare.ComponentFileId, spare.Position);
        assigned.Add(entityId, fallback);
        return fallback;
    }
}

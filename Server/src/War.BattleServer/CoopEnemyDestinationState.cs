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
    private readonly Dictionary<ulong, CoopAssignedEnemyDestination> assigned = [];
    private bool boundToMatch;

    public string Scene => map.Scene;
    public string SceneSha256 => map.SceneSha256;
    internal bool UsesCombat(CoopEnemyCombatCatalog source) =>
        ReferenceEquals(combat, source);

    public CoopEnemyDestinationState(CoopMapEnemyPoints map,
        CoopEnemyPointMaskCatalog masks, CoopEnemyCombatCatalog combat,
        Func<float>? chooseObstacleFraction = null,
        CoopMapRusherPoints? rusherPoints = null)
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
    }

    public CoopAssignedEnemyDestination? ForEnemy(ulong entityId) =>
        assigned.GetValueOrDefault(entityId);

    internal void BindToMatch()
    {
        if (boundToMatch)
            throw new InvalidOperationException(
                "Co-op destination state already belongs to a match.");
        boundToMatch = true;
    }

    public CoopAssignedEnemyDestination? TryAssignInitial(
        ulong entityId, string behaviour, bool spawnedByCard,
        Vector3 spawnPosition, int? targetPlayerPositionIndex = null)
    {
        if (entityId == 0 || !PlayerHitbox.Finite(spawnPosition))
            throw new ArgumentOutOfRangeException(nameof(entityId));
        if (assigned.ContainsKey(entityId))
            throw new InvalidOperationException("Enemy already owns a destination.");

        string unitId = combat.UnitIdFor(behaviour);
        CoopSoldierPointMask? soldier = masks.Soldiers.FirstOrDefault(row =>
            row.UnitId == unitId);
        if (soldier == null || soldier.BehaviorType == "SoldierBehaviourSniper")
            return null;
        if (IsShieldLinkedRusher(soldier, spawnedByCard))
            return AssignRusher(entityId, spawnPosition,
                targetPlayerPositionIndex);

        int mask = CoopEnemyPointSelection.InitialMask(soldier, spawnedByCard);
        CoopEnemyPoint? point = CoopEnemyPointSelection.SelectOrdinary(
            map, mask, spawnPosition, reservations.OccupiedPointIds);
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

using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const ulong AssaulterPointRetryTicks = 5 * MatchManifest.TickRate;
    private const float AssaulterArrivalDistance = 0.04f;
    private readonly Dictionary<ulong, AssaulterWalk> _assaulterWalks = [];
    private readonly Dictionary<ulong, ulong> _assaulterPointRetries = [];

    /// <summary>Reads the normal Assaulter's shared, scene-bound destination reservation.</summary>
    internal CardUnitInitialPoint? AssaulterPoint(ulong entityKey)
    {
        return cardEnemyPoints?.Find(entityKey);
    }

    private void InitializeAssaulterNavigation(ulong entityKey)
    {
        if (!activeArmyEntities.TryGetValue(entityKey, out BattleArmyEntityState? entity) ||
            entity.UnitId != "ID_UNIT-ASSAULT" || entity.SourceCardId.Length != 0 ||
            cardEnemyPoints == null || armyCatalog == null)
        {
            throw new InvalidDataException("Normal Assaulter lost its source navigation authority.");
        }

        var position = new Vector3(entity.X, entity.Y, entity.Z);
        CardUnitInitialPoint? point = cardEnemyPoints.TryAssignAssaulter(entityKey, entity.OwnerFraction, position);
        if (point == null)
        {
            // GenerateInitPoint retries after five seconds; a fabricated destination
            // would bypass the source point mask and shared enemyAtPoint reservation.
            _assaulterPointRetries[entityKey] = checked(tick + AssaulterPointRetryTicks);
            return;
        }

        StartAssaulterWalk(entity, point, position);
        _assaulterPointRetries.Remove(entityKey);
    }

    private void StartAssaulterWalk(BattleArmyEntityState entity, CardUnitInitialPoint point, Vector3 position)
    {
        try
        {
            ArmyNavMeshCorridor route = PlanCardSoldierRoute(position, point.Position);
            float speed = ArmySpeed(entity.EntityKey) ?? armyCatalog!.EffectiveSpeed(entity.UnitId, 1f);
            var motion = new CardSoldierWalkState(point.ComponentFileId, route, armyCatalog!.InfantryAgent, speed);
            // SetFinalTarget resumes the source agent immediately. The host creates
            // this entity at the current tick; displacement starts in the next interval.
            _assaulterWalks.Add(entity.EntityKey, new AssaulterWalk(motion, checked(tick + 1)));
        }
        catch
        {
            cardEnemyPoints!.Release(entity.EntityKey);
            throw;
        }
    }

    private void AdvanceAssaulterNavigation()
    {
        foreach (var (entityKey, dueTick) in _assaulterPointRetries.OrderBy(row => row.Key).ToArray())
        {
            if (tick >= dueTick)
            {
                InitializeAssaulterNavigation(entityKey);
            }
        }

        foreach (var (entityKey, walk) in _assaulterWalks.OrderBy(row => row.Key).ToArray())
        {
            AdvanceAssaulterWalk(entityKey, walk);
        }
        AdvanceAssaulterCornerEntries();
    }

    private void AdvanceAssaulterWalk(ulong entityKey, AssaulterWalk walk)
    {
        if (!activeArmyEntities.TryGetValue(entityKey, out BattleArmyEntityState? entity) ||
            cardEnemyPoints?.Find(entityKey) is not { } point || point.ComponentFileId != walk.Motion.PointFileId)
        {
            throw new InvalidDataException("Normal Assaulter walk lost its entity or reserved point.");
        }

        if (tick < walk.FirstTick)
        {
            return;
        }

        walk.Motion.AdvanceTick();
        entity.X = walk.Motion.Position.X;
        entity.Y = walk.Motion.Position.Y;
        entity.Z = walk.Motion.Position.Z;
        entity.PositionTick = tick;
        var currentPosition = new Vector2(entity.X, entity.Z);
        var authoredPosition = new Vector2(point.Position.X, point.Position.Z);
        // EnemyPoint.IsEnemyPointReached compares with the authored point,
        // not merely the projected NavMesh endpoint.
        if (walk.Motion.Arrived && Vector2.Distance(currentPosition, authoredPosition) < AssaulterArrivalDistance)
        {
            _assaulterWalks.Remove(entityKey);
            EnterAssaulterCorner(entityKey, walk.Motion.Facing);
        }
    }

    private void RemoveAssaulterNavigation(ulong entityKey)
    {
        _assaulterWalks.Remove(entityKey);
        _assaulterPointRetries.Remove(entityKey);
        _assaulterCorners.Remove(entityKey);
        _settledAssaulterCorners.Remove(entityKey);
        cardEnemyPoints?.Release(entityKey);
    }

    private sealed record AssaulterWalk(CardSoldierWalkState Motion, ulong FirstTick);
}

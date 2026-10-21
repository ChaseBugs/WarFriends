using System.Numerics;

namespace War.BattleServer;

public sealed partial class CoopEnemyDestinationState
{
    private readonly Dictionary<ulong, CrewRetargetPlan> _crewRetargetPlans = new();

    /// <summary>Draws next-point geometry while preserving the old reservation until walk-clock validation.</summary>
    internal CrewRetargetPlan? PlanCrewRetarget(ulong entityId, Vector3 position)
    {
        if (!PlayerHitbox.Finite(position) || entityId == 0)
        {
            throw new InvalidDataException("Crew retarget requires a valid host actor and root.");
        }
        CoopAssignedEnemyDestination original = ForEnemy(entityId) ??
            throw new InvalidOperationException("Crew retarget requires an existing scene-point reservation.");
        CoopSoldierPointMask soldier = masks.Soldiers.Single(row => row.UnitId == combat.UnitIdFor("Assaulter"));
        int mask = CoopEnemyPointSelection.InitialMask(soldier, true);
        CoopEnemyPoint? point = CoopEnemyPointSelection.SelectNext(map, mask, original.PointComponentFileId,
            reservations.OccupiedPointIds, chooseNextPoint);
        if (point == null)
        {
            _crewRetargetPlans.Remove(entityId);
            return null;
        }
        float fraction = point.ComponentType == "EnemyPointObstacle" ? chooseObstacleFraction() : 0f;
        var destination = new CoopAssignedEnemyDestination(point.ComponentFileId,
            CoopEnemyPointSelection.GeneratePosition(point, fraction));
        var plan = new CrewRetargetPlan(this, entityId, original, new CrewRetargetCandidate(point, destination));
        _crewRetargetPlans[entityId] = plan;
        return plan;
    }

    internal void CommitCrewRetarget(CrewRetargetPlan plan)
    {
        ArgumentNullException.ThrowIfNull(plan);
        if (!ReferenceEquals(plan.Owner, this) ||
            !ReferenceEquals(_crewRetargetPlans.GetValueOrDefault(plan.EntityId), plan) ||
            !ReferenceEquals(ForEnemy(plan.EntityId), plan.Original) ||
            !reservations.TryReserve(plan.EntityId, plan.Point))
        {
            throw new InvalidOperationException("Crew retarget plan is stale, foreign or no longer free.");
        }
        assigned[plan.EntityId] = plan.Destination;
        _crewRetargetPlans.Remove(plan.EntityId);
    }

    /// <summary>Immutable source candidate bound to its original reservation and destination owner.</summary>
    internal sealed class CrewRetargetPlan
    {
        internal CoopEnemyDestinationState Owner { get; }
        internal ulong EntityId { get; }
        internal CoopAssignedEnemyDestination Original { get; }
        internal CoopEnemyPoint Point => Candidate.Point;
        internal CoopAssignedEnemyDestination Destination => Candidate.Destination;
        private CrewRetargetCandidate Candidate { get; }

        internal CrewRetargetPlan(CoopEnemyDestinationState owner, ulong entityId,
            CoopAssignedEnemyDestination original, CrewRetargetCandidate candidate)
        {
            Owner = owner;
            EntityId = entityId;
            Original = original;
            Candidate = candidate;
        }
    }

    internal sealed record CrewRetargetCandidate(CoopEnemyPoint Point, CoopAssignedEnemyDestination Destination);
}

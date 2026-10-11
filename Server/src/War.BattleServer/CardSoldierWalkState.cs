using System.Numerics;

namespace War.BattleServer;

/// <summary>One card soldier walking to a scene point or fallback spawn.</summary>
internal sealed class CardSoldierWalkState
{
    private readonly ArmyNavMeshMotionState? motion;
    private readonly Vector3 stationaryPosition;

    internal int PointFileId { get; }
    internal Vector3 Position => motion?.Position ?? stationaryPosition;
    internal bool Arrived => motion?.Arrived ?? true;
    internal Vector3? Facing { get; private set; }

    internal CardSoldierWalkState(int pointFileId, ArmyNavMeshCorridor route,
        ArmyAgentConfig agent, float movementSpeed)
    {
        ArgumentNullException.ThrowIfNull(route);
        ArgumentNullException.ThrowIfNull(agent);
        if (pointFileId <= 0 || !route.PlanarCovered ||
            route.SmoothedPoints.Count < 2 ||
            !float.IsFinite(movementSpeed) || movementSpeed <= 0f ||
            route.SmoothedPoints.Any(point => !PlayerHitbox.Finite(point)))
            throw new InvalidDataException("Card soldier needs a source destination.");
        PointFileId = pointFileId;
        float planarLength = 0f;
        for (int index = 1; index < route.SmoothedPoints.Count; index++)
        {
            Vector3 start = route.SmoothedPoints[index - 1];
            Vector3 end = route.SmoothedPoints[index];
            Vector2 direction = new(end.X - start.X, end.Z - start.Z);
            planarLength += direction.Length();
            if (Facing == null && direction.LengthSquared() > 0.00000001f)
            {
                direction = Vector2.Normalize(direction);
                Facing = new Vector3(direction.X, 0f, direction.Y);
            }
        }
        if (!float.IsFinite(planarLength))
            throw new InvalidDataException("Card soldier route length is invalid.");
        if (planarLength <= 0.04f)
        {
            // A parachute may touch down on its same-faction normal spawn.
            // NavMeshAgent.SetDestination then has no walking step to take.
            stationaryPosition = route.SmoothedPoints[^1];
            return;
        }
        motion = new ArmyNavMeshMotionState(route, agent, movementSpeed);
        stationaryPosition = motion.Position;
    }

    internal void AdvanceTick()
    {
        if (motion == null)
            return;
        Vector2 direction = motion.PlanarDirection;
        if (direction.LengthSquared() > 0.00000001f)
            Facing = new Vector3(direction.X, 0f, direction.Y);
        motion.AdvanceTick();
    }
}

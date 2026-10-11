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
            planarLength += Vector2.Distance(new(start.X, start.Z),
                new(end.X, end.Z));
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

    internal void AdvanceTick() => motion?.AdvanceTick();
}

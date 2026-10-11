using System.Numerics;

namespace War.BattleServer;

/// <summary>One card soldier walking to its reserved scene EnemyPoint.</summary>
internal sealed class CardSoldierWalkState
{
    private readonly ArmyNavMeshMotionState motion;

    internal int PointFileId { get; }
    internal Vector3 Position => motion.Position;
    internal bool Arrived => motion.Arrived;

    internal CardSoldierWalkState(int pointFileId, ArmyNavMeshCorridor route,
        ArmyAgentConfig agent, float movementSpeed)
    {
        if (pointFileId <= 0)
            throw new InvalidDataException("Card soldier needs a source destination.");
        PointFileId = pointFileId;
        motion = new ArmyNavMeshMotionState(route, agent, movementSpeed);
    }

    internal void AdvanceTick() => motion.AdvanceTick();
}

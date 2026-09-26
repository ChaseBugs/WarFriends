using System.Numerics;

namespace War.BattleServer;

/// <summary>Host NavMesh walk to one reserved EnemyPointMinigunner.</summary>
public sealed class ArmyMinigunnerMovementState
{
    private readonly ArmyNavMeshMotionState motion;
    public int PointFileId { get; }
    public Vector3 Position=>motion.Position;
    public Vector3 Destination { get; }
    public bool Arrived=>motion.Arrived;

    internal ArmyMinigunnerMovementState(int pointFileId,ArmyNavMeshCorridor route,
        ArmyAgentConfig agent,float speed)
    {
        if(pointFileId<=0||route==null||route.SmoothedPoints.Count<2)
            throw new InvalidDataException("Invalid Minigunner movement authority.");
        PointFileId=pointFileId;Destination=route.SmoothedPoints[^1];
        motion=new(route,agent,speed);
    }

    internal void AdvanceTick()=>motion.AdvanceTick();
}

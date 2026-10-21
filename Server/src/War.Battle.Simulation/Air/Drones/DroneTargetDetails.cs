using System.Numerics;
namespace War.BattleServer;

public sealed record DroneTargetDetails(IReadOnlyList<DroneShotTarget> Targets,bool IsPlayer,
    Vector3 Root,Vector3 AimForward,bool Hiding,Vector3 Velocity);

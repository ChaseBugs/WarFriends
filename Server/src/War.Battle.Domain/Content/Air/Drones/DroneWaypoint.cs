using System.Numerics;
namespace War.BattleServer;

public sealed record DroneWaypoint(int ComponentFileId,Vector3 Position,float StayTime);

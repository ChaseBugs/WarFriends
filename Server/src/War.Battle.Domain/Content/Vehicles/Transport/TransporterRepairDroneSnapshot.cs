using System.Numerics;

namespace War.BattleServer;

internal sealed record TransporterRepairDroneSnapshot(int PathIndex,Vector3 Position,float Health,
    float MaximumHealth,bool Active,ulong RespawnTick,int WaypointIndex,bool Forward,Quaternion Rotation,
    bool Falling,bool Crashed);

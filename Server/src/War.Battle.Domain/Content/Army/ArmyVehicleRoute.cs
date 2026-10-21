using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyVehicleRoute(int CircuitFileId,int TargetTransformFileId,bool SmoothRoute,
    bool IsLoop,IReadOnlyList<int> WaypointTransformFileIds,IReadOnlyList<Vector3> Positions);

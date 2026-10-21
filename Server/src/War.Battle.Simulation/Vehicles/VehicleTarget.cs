using System.Numerics;

namespace War.BattleServer;

public readonly record struct VehicleTarget(string OwnerPlayerId, string TargetPlayerId,
    Vector3 Origin, Vector3 Target, float Distance);

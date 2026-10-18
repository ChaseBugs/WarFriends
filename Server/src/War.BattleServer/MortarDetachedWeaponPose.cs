using System.Numerics;

namespace War.BattleServer;

/// <summary>Owns a preparation-time world transform until the recovered hand-return callback.</summary>
internal sealed record MortarDetachedWeaponPose(
    ulong PreparedTick,
    ulong HandReturnTick,
    Vector3 Position,
    Quaternion Rotation,
    Vector3 Scale);

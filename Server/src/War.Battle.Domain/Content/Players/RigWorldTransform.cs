using System.Numerics;

namespace War.BattleServer;

internal sealed record RigWorldTransform(Vector3 Position,Quaternion Rotation,Matrix4x4 Matrix);

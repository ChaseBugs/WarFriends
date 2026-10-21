using System.Numerics;

namespace War.BattleServer;

/// <summary>Unit-scale world body pose when the source constraint is created.</summary>
internal sealed record HelicopterRopeBodyPose(Vector3 Position, Quaternion Rotation);

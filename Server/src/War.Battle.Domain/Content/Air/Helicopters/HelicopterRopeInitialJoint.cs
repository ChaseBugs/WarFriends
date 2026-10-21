using System.Numerics;

namespace War.BattleServer;

/// <summary>Generated initial pose before physics changes a rope joint.</summary>
internal sealed record HelicopterRopeInitialJoint(Vector3 Position, Quaternion Rotation,
    HelicopterRopeBodySetup Body, HelicopterRopeConnectionSetup? Connection);

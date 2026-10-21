using System.Numerics;

namespace War.BattleServer;

/// <summary>Source spline geometry and the measured spacing used by subsequent extension commands.</summary>
internal sealed record HelicopterRopeInitialState(
    IReadOnlyList<HelicopterRopeInitialJoint> Joints, float InitialJointDistance);

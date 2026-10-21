using System.Numerics;

namespace War.BattleServer;

/// <summary>Connection intent; a physical adapter must configure anchors after placing both bodies.</summary>
internal sealed record HelicopterRopeConnectionSetup(int ConnectedJointIndex, HelicopterRopeAngularLimits AngularLimits)
{
    internal bool ShouldLockLinearMotion => true;
    internal bool ShouldLimitAngularMotion => true;
    internal bool ShouldAutoConfigureConnectedAnchor => true;
}

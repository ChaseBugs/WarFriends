using System.Numerics;

namespace War.BattleServer;

/// <summary>Recovered body settings shared by the generated rope joints.</summary>
internal sealed record HelicopterRopeBodySetup(float Mass, float Drag, float AngularDrag, bool ShouldUseGravity)
{
    internal bool IsKinematic => false;
    internal bool HasFrozenAxes => false;
}

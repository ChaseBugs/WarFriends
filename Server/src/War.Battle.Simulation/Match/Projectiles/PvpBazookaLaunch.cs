using System.Numerics;

namespace War.BattleServer;

internal sealed record PvpBazookaLaunch(string Owner, Vector3 Target, ulong LaunchTick, PvpBazookaShot Shot)
{
    internal bool IsFake => Shot.Kind == PvpBazookaShotKind.SecondaryFake;

    internal bool IsSecondary => Shot.Kind != PvpBazookaShotKind.PrimaryReal;
}

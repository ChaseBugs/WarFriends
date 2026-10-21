using System.Collections.ObjectModel;
using System.Numerics;

namespace War.BattleServer;

internal sealed record PlayerAimPoseDetails(
    RifleMuzzlePose? MovingTarget,
    IReadOnlyDictionary<int, RifleMuzzlePose> BodyTargets,
    WeaponRootPoseSource? WeaponRoots);

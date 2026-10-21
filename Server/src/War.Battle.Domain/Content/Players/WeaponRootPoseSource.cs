using System.Collections.ObjectModel;
using System.Numerics;

namespace War.BattleServer;

internal sealed record WeaponRootPoseSource(
    RigWorldTransform[] Rig,
    IReadOnlyDictionary<string, (int Node, string Path)> Bindings,
    Vector3? PlacedPosition = null,
    Quaternion? PlacedRotation = null);

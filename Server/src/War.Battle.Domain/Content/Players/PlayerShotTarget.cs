using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PlayerShotTarget(
    int TransformFileId, int Type, string Path, Vector3 ReferencePosition,
    string ParentPath, Vector3 LocalPosition, Quaternion LocalRotation);

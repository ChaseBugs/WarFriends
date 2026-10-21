using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopColliderTransform(
    int FileId, Vector3 LocalPosition, Quaternion LocalRotation,
    Vector3 LocalScale);

using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBossAnchor(
    int Index, int Fraction, bool Main, int ComponentFileId,
    int GameObjectFileId, int TransformFileId,
    Vector3 Position, Quaternion Rotation);

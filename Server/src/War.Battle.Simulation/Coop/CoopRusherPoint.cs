using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopRusherPoint(
    int Order, int ComponentFileId, int SourceIndex,
    int GameObjectFileId, int TransformFileId,
    Vector3 Position, Quaternion Rotation);

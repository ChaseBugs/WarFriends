using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopEnemyPoint(
    int Order, int ComponentFileId, string ComponentType,
    int GameObjectFileId, int TransformFileId,
    Vector3 TransformPosition, Quaternion Rotation,
    Vector3 Position, Vector3? SegmentStart, Vector3? SegmentEnd)
{
    public Vector3? CornerDirection { get; init; }
    public bool? CornerRightSide { get; init; }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>A source EnemyPoint eligible for a card-spawned Rusher soldier.</summary>
public sealed record CardUnitInitialPoint(int Order, int ComponentFileId,
    string ComponentType, int Fraction, Vector3 Position, Quaternion Rotation,
    Vector3? CornerDirection, bool? CornerRightSide);

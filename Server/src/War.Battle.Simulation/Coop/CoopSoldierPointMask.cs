using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSoldierPointMask(
    int BehaviorFileId, string BehaviorType, string UnitId, int Mask,
    float? MinimumPlayerDistance);

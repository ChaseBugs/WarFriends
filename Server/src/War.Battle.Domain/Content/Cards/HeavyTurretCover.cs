using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

public sealed record HeavyTurretCover(int Order,int PointComponentFileId,int Fraction,bool Main,
    IReadOnlyList<HeavyTurretPlacement> Slots);

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyMinigunnerPoint(int Order,int ComponentFileId,int TransformFileId,
    int Fraction,Vector3 Position);

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record LandMineHidingSlot(int Order,int ComponentFileId,int GameObjectFileId,
    int TransformFileId,int Fraction,Vector3 SourcePosition);

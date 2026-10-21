using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record DecoyObstacleSlot(int Order,int ComponentFileId,int GameObjectFileId,int Fraction,
    int StartTransformFileId,int EndTransformFileId,Vector3 Start,Vector3 End,Vector3 InitialMidpoint);

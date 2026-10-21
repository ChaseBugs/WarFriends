using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

public sealed record HeavyTurretPlacement(int Order,int ComponentFileId,int GameObjectFileId,
    int TransformFileId,Vector3 SourcePosition);

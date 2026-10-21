using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

public sealed record HeavyTurretCollider(int ComponentFileId,int TransformFileId,Vector3 Center,Vector3 Size,
    Quaternion Rotation,int DamagePartComponentFileId,float FlameWeight);

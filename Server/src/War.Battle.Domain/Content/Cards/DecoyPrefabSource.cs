using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record DecoyPrefabSource(string Source,string Sha256,int RootTransformFileId,
    int ShootableComponentFileId,int TargetTransformFileId,Vector3 TargetLocalPosition,
    int ColliderComponentFileId,Vector3 ColliderCenter,Vector3 ColliderSize,
    int DamageComponentFileId,float FlameCoefficient);

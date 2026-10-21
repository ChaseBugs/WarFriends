using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record RepairDronePrefabBinding(string Prefab,string Sha256,int ComponentFileId,
    int SteeringComponentFileId,int DamageComponentFileId,float FlameCoefficient,
    float BreakDistance,float BreakSpeed,bool InitialForward,bool Loop,
    float Mass,float Multiplier,float Speed,float CornerDelayTime,float HealIntervalSeconds,
    float RespawnMinimumSeconds,float RespawnMaximumSeconds,float DeadRadius,float HurtRadius,
    float ExplosionDamageRatio,float SplashDamageRatio,int ColliderFileId,Vector3 ColliderCenter,
    Vector3 ColliderSize,bool ColliderTrigger);

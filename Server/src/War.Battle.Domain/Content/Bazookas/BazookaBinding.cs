using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record BazookaBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShootOffset,float HoldSeconds,
    float FirstShotWaitSeconds,float DeadRadius,float HurtRadius,float Speed,float BehindShieldRatio,Vector3 ExplosionCoefficient,
    float AdditionalUpForce,float StopSeconds,int MissileType,bool CurvedTrajectory,Vector2 RotationRange,float RotationMagnitude,
    IReadOnlyList<BazookaCurveKey> RotationProfile,int ProjectileCount,float ProjectileDelaySeconds,string MuzzlePath,string? SecondaryMuzzlePath,string BulletRevision);

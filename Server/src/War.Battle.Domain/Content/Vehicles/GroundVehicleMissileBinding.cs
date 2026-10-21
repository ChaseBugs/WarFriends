using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleMissileBinding(int SetupComponentFileId,float Speed,float MinimumDamage,float HurtRadius,
    float DeadRadius,Vector3 ExplosionCoefficient,float AdditionalUpForce,float StopTime,int MissileType,
    bool CurvedTrajectory,Vector2 RotationRange,IReadOnlyList<BazookaCurveKey> RotationProfile,
    float BaseRotationMagnitude);

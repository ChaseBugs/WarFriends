using System.Numerics;

namespace War.BattleServer;

internal sealed record ShotgunRule(float NearHalfAngle,float FarHalfAngle,float Radius,
    float MinDamage,float MaxDamage,bool FlatY,bool OnlyMain);

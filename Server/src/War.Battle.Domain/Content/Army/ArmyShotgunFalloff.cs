using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyShotgunFalloff(string UnitId,float Radius,float ShotHalfAngle,float ShotHalfAngleNear,
    float MinimumDamageRatio,bool FlatY,
    bool ShotOnlyMainBullet,string Rule,string Source,string SourceSha256);

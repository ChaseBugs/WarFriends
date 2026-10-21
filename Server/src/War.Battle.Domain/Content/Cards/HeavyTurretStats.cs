using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.BattleServer;

public sealed record HeavyTurretStats(float Health,float Damage,int BatchMinimum,int BatchMaximum,
    float ShootMinimum,float ShootMaximum,float RealShotProbability);

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GrenadeStage(string SourceId,int Index,int Ammo,float CadenceSeconds,float ExplosionDamage,
    float MinimumDamage,float DeadRadius,float HurtRadius,float PlayerDamageRatio,float OvertimePlayerDamageRatio,
    float BehindShieldRatio);

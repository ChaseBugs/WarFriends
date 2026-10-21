using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record BazookaStage(string SourceId,int Index,int Ammo,float CadenceSeconds,float ExplosionDamage,float MinimumDamage,
    float PlayerDamageRatio,float OvertimePlayerDamageRatio);

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record MinigunStage(string SourceId,int Index,int Ammo,float Damage,float CadenceSeconds,
    float HeatSeconds,float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);

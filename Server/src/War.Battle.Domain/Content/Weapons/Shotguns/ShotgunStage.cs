using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record ShotgunStage(string SourceId,int Index,int ClipSize,int ReserveAmmo,
    float ReloadSeconds,float MinDamage,float MaxDamage,float CadenceSeconds,
    float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);

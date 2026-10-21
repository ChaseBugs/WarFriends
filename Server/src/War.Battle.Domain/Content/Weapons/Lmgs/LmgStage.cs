using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record LmgStage(string SourceId,int Index,int ClipSize,int ReserveAmmo,float ReloadSeconds,
    float Damage,float CadenceSeconds,float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio,
    int BurstSize,float BurstLockSeconds):IBurstStage;

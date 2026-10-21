using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record PistolStage(string SourceId,int Index,int ClipSize,float ReloadSeconds,float Damage,float CadenceSeconds,
    float CriticalProbability,float PlayerDamageRatio,float OvertimePlayerDamageRatio);

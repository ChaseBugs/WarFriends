using System.Numerics;

namespace War.BattleServer;

public readonly record struct WarCardEffectRequest(string CardId,Vector3 Target,float DurationSeconds,int Parameter,
    string? SourceCardId=null);

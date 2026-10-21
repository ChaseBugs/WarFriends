using War.Protocol;

namespace War.BattleServer;

/// <summary>Recovered MatchStats outcome fields, without rank or reward policy.</summary>
public sealed record BattleOutcomeMatchStats(string PlayerId,string GameEndReason,
    int BattlesWon,int BattlesLost,int BattlesLostInRowDelta);

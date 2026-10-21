namespace War.BattleServer;

public sealed record BattleResultHandoff(string MatchId,string ManifestHash,BattleStatistics Statistics,bool Scored);

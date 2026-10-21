namespace War.BattleServer.Transport.Control;

internal sealed record ReconnectControlRequest(string MatchId, string PlayerId, string RequestId);

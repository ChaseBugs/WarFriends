namespace War.BattleServer.Transport.Control;

internal sealed record CancelControlRequest(string MatchId, string? ManifestHash);

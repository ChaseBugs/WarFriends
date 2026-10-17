namespace War.Persistence;

/// <summary>Binds a cancellation to the server-owned match identity and exact frozen participant order.</summary>
public sealed record BattleReservedMatchCancellation(string PlayerId, string MatchId,
    IReadOnlyList<string> ExpectedPlayers, DateTimeOffset ApplicationTime);

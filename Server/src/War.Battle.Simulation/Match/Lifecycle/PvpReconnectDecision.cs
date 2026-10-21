namespace War.BattleServer;

/// <summary>A lifecycle decision; engine cleanup and terminal publication keep their existing order.</summary>
internal readonly record struct PvpReconnectDecision(
    PvpReconnectDisposition Disposition, string DisconnectedPlayerId, string WinnerPlayerId);

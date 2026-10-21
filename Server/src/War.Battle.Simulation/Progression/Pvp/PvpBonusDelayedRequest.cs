using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpBonusDelayedRequest(string ReceiptId, string MatchId,
    string OwnerPlayerId, int BonusOrdinal, ulong IssueFrame);

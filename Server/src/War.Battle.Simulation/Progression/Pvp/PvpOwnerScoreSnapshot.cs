using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpOwnerScoreSnapshot(string OwnerPlayerId, int Score,
    IReadOnlyDictionary<int, int> Counts, int ReceiptCount);

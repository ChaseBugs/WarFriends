using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpOwnerStreakSnapshot(string OwnerPlayerId, float Progress,
    int BonusesRequested, int GainReceiptCount);

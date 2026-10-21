using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpComboSnapshot(int Streak, float LastKillTime, int ReceiptCount);

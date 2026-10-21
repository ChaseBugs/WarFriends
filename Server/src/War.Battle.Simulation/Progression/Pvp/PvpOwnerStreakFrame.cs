using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpOwnerStreakFrame(string OwnerPlayerId, PvpScoreStreakFrame Streak);

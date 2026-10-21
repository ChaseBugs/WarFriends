using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpConfirmedSkillShot(PvpSkillShotScoreReceipt Score, float Progress);

using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpConfirmedPlayerDeath(PvpKillComboResult Combo,
    PvpConfirmedSkillShot? ScoredSkillShot);

using System.Numerics;

namespace War.BattleServer;

public sealed record PvpBonusBoxSnapshot(string BoxId, PvpBonusSpawnPlan Plan,
    PvpBonusBoxPhase Phase, PvpBonusBoxCollectionCandidate? Collection,
    Vector3 Position, float VerticalVelocity, float Health);

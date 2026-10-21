using System.Numerics;
using System.Security.Cryptography;

namespace War.BattleServer;

public sealed record PvpBonusSpawnPlan(PvpBonusDelayedRequest Request,
    int SourceIndex, int PrefabIndex, int AreaColliderFileId, Vector3 Position,
    MapHit? StaticSurfaceCandidate);

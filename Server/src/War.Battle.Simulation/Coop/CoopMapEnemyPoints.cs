using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopMapEnemyPoints(
    int Stage, string Scene, string SceneSha256,
    int MapDefinitionFileId, int FloorTransformFileId,
    Vector3 FloorPosition, int CollectionComponentFileId,
    IReadOnlyList<CoopEnemyPoint> Points);

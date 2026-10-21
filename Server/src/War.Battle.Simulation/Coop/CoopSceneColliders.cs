using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSceneColliders(
    int Stage, string Scene, string SceneSha256,
    IReadOnlyList<CoopSceneCollider> Colliders);

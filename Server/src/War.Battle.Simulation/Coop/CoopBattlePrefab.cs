using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBattlePrefab(
    string PoolField, string Guid, int PooledComponentFileId,
    string Source, string SourceSha256,
    IReadOnlyList<CoopSceneCollider> Colliders, int WheelColliderCount);

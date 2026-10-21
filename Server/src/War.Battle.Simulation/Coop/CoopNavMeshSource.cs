using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopNavMeshSource(
    int Stage, string Scene, string SceneSha256, string NavMeshGuid,
    string SourceAsset, string PackagedAsset, string Format,
    int Bytes, string Sha256);

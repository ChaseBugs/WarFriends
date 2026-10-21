using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record CoopMeshGeometry(
    string Guid, string SourceAsset, string SourceSha256,
    IReadOnlyList<Vector3> Vertices, IReadOnlyList<int> Triangles);

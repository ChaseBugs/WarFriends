using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopNavMeshTriangulation
{
    public int Stage { get; }
    public string Scene { get; }
    public string SceneSha256 { get; }
    public string NavMeshSha256 { get; }
    public IReadOnlyList<Vector3> Vertices { get; }
    public IReadOnlyList<int> Indices { get; }

    internal CoopNavMeshTriangulation(CoopNavMeshSource source,
        Vector3[] vertices, int[] indices)
    {
        Stage = source.Stage;
        Scene = source.Scene;
        SceneSha256 = source.SceneSha256;
        NavMeshSha256 = source.Sha256;
        Vertices = new ReadOnlyCollection<Vector3>(vertices);
        Indices = new ReadOnlyCollection<int>(indices);
    }
}

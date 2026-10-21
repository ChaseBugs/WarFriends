using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Unity-exported walkable triangles. Route evaluation is separate.</summary>
public sealed class ArmyNavMeshTriangulation
{
    public string Scene { get; }
    public string Revision { get; }
    public IReadOnlyList<Vector3> Vertices { get; }
    public IReadOnlyList<int> Indices { get; }
    internal ArmyNavMeshTriangulation(string scene,string revision,Vector3[] vertices,int[] indices)
    { Scene=scene;Revision=revision;Vertices=Array.AsReadOnly(vertices);Indices=Array.AsReadOnly(indices); }
}

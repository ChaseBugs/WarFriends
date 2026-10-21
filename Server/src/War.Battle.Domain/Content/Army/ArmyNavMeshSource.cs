using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Exact Unity NavMesh inputs; binary pathfinding is not implemented here.</summary>
public sealed record ArmyNavMeshSource(string Scene,string SceneRevision,string Guid,
    string Asset,int Bytes,string Revision);

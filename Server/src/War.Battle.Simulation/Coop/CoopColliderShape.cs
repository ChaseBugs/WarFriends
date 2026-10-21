using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopColliderShape(
    Vector3 Center, Vector3 Size, float Radius, float Height,
    int Direction, int MeshFileId, string MeshGuid, bool Convex);

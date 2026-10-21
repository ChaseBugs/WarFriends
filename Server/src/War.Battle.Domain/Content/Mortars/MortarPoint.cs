using System.Numerics;

namespace War.BattleServer;

/// <summary>An ordered, same-fraction Mortar destination from a recovered multiplayer scene.</summary>
public sealed record MortarPoint(int Order, int ComponentFileId, int Fraction, Vector3 Position,
    Vector3 NavMeshPosition);

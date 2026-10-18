using System.Numerics;

namespace War.BattleServer;

/// <summary>An ordered, same-fraction Gunslinger destination from a recovered multiplayer scene.</summary>
public sealed record GunslingerPoint(int Order, int ComponentFileId, int Fraction, Vector3 Position);

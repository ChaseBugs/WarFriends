using System.Numerics;

namespace War.BattleServer;

/// <summary>Trusted pre-flight rope origin and the current player's selected point.</summary>
internal sealed record HelicopterRopeLandingQuery(Vector3 RopeOrigin, Vector3 PlayerPoint);

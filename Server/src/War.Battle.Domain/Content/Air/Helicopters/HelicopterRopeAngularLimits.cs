using System.Numerics;

namespace War.BattleServer;

/// <summary>Recovered angular stops; the source locks each of the three linear axes.</summary>
internal sealed record HelicopterRopeAngularLimits(float MinimumX, float MaximumX, float MaximumY, float MaximumZ);

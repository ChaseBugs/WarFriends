using System.Numerics;

namespace War.BattleServer;

/// <summary>Source ShowRope projection and area-zero surface lookup, without inventing a failed sample height.</summary>
internal static class HelicopterRopeLanding
{
    internal const float SourceSampleRadius = 10f;

    internal static Vector3? Resolve(HelicopterRopeLandingQuery query,
        Func<Vector3, float, Vector3?> sampleSurface)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentNullException.ThrowIfNull(sampleSurface);
        if (!PlayerHitbox.Finite(query.RopeOrigin) || !PlayerHitbox.Finite(query.PlayerPoint))
        {
            throw new InvalidDataException("Helicopter landing requires bounded trusted world points.");
        }
        Vector3 sourcePosition = query.RopeOrigin;
        // A downward Ray intersects the horizontal player plane only below the rope origin.
        if (query.RopeOrigin.Y > query.PlayerPoint.Y)
        {
            sourcePosition.Y = query.PlayerPoint.Y;
        }
        Vector3? sampled = sampleSurface(sourcePosition, SourceSampleRadius);
        if (sampled is Vector3 surface && (!PlayerHitbox.Finite(surface) ||
            Vector3.DistanceSquared(sourcePosition, surface) > SourceSampleRadius * SourceSampleRadius))
        {
            throw new InvalidDataException("Helicopter landing sample is outside its trusted query radius.");
        }
        return sampled;
    }
}

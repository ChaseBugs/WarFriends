using System.Numerics;

namespace War.BattleServer;

/// <summary>Source-compared polygon-first sampling with detail height interpolation.</summary>
internal sealed class NavigationDetailSampler
{
    private const float MaximumRadius = 100f;
    private const float BoundaryDistanceSquared = 1e-10f;
    private const float DegenerateArea = 1e-12f;
    private const float BarycentricTolerance = 0.00001f;
    private readonly NavigationDetailCatalog.Map _map;

    internal NavigationDetailSampler(NavigationDetailCatalog.Map map)
    {
        ArgumentNullException.ThrowIfNull(map);
        _map = map;
    }

    internal Vector3? Sample(Vector3 point, float radius)
    {
        if (!PlayerHitbox.Finite(point) || !float.IsFinite(radius) || radius <= 0 || radius > MaximumRadius)
        {
            throw new InvalidDataException("Detail surface query requires a bounded point and radius.");
        }
        Vector3? selected = null;
        bool hasInterior = false;
        float bestDistance = radius * radius;
        foreach (NavigationDetailCatalog.Polygon polygon in _map.Polygons)
        {
            (Vector3 position, bool isInterior) = ProjectBoundary(point, polygon.Boundary);
            Vector3? candidate = InterpolateHeight(position, polygon.Details);
            if (candidate == null)
            {
                continue;
            }
            float distance = Vector3.DistanceSquared(point, candidate.Value);
            if (distance > radius * radius || (hasInterior && !isInterior))
            {
                continue;
            }
            if (selected == null || (isInterior && !hasInterior) || distance < bestDistance)
            {
                selected = candidate;
                bestDistance = distance;
                hasInterior = isInterior;
            }
        }
        return selected;
    }

    private static (Vector3 Position, bool IsInterior) ProjectBoundary(Vector3 point, IReadOnlyList<Vector3> boundary)
    {
        bool isInside = false;
        float bestDistance = float.PositiveInfinity;
        Vector3 nearest = default;
        for (int index = 0; index < boundary.Count; index++)
        {
            Vector3 first = boundary[index];
            Vector3 second = boundary[(index + 1) % boundary.Count];
            if ((first.Z > point.Z) != (second.Z > point.Z) &&
                point.X < (second.X - first.X) * (point.Z - first.Z) / (second.Z - first.Z) + first.X)
            {
                isInside = !isInside;
            }
            Vector3 edge = second - first;
            float length = edge.X * edge.X + edge.Z * edge.Z;
            float amount = length == 0 ? 0 : Math.Clamp(
                ((point.X - first.X) * edge.X + (point.Z - first.Z) * edge.Z) / length, 0, 1);
            Vector3 candidate = first + edge * amount;
            float distance = (point.X - candidate.X) * (point.X - candidate.X) +
                (point.Z - candidate.Z) * (point.Z - candidate.Z);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                nearest = candidate;
            }
        }
        bool isInterior = isInside || bestDistance <= BoundaryDistanceSquared;
        return (isInterior ? point : nearest, isInterior);
    }

    private static Vector3? InterpolateHeight(Vector3 point, IReadOnlyList<NavigationDetailCatalog.Triangle> triangles)
    {
        foreach (NavigationDetailCatalog.Triangle triangle in triangles)
        {
            Vector3 edgeA = triangle.Second - triangle.First;
            Vector3 edgeB = triangle.Third - triangle.First;
            Vector3 relative = point - triangle.First;
            float denominator = edgeA.X * edgeB.Z - edgeA.Z * edgeB.X;
            if (MathF.Abs(denominator) < DegenerateArea)
            {
                continue;
            }
            float second = (relative.X * edgeB.Z - relative.Z * edgeB.X) / denominator;
            float third = (edgeA.X * relative.Z - edgeA.Z * relative.X) / denominator;
            if (second >= -BarycentricTolerance && third >= -BarycentricTolerance &&
                second + third <= 1 + BarycentricTolerance)
            {
                return new Vector3(point.X, triangle.First.Y + second * edgeA.Y + third * edgeB.Y, point.Z);
            }
        }
        return null;
    }
}

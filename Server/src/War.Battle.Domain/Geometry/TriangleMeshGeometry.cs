using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Immutable triangles from a recovered Unity convex MeshCollider. The host keeps
/// source vertex order and tests the actual surface rather than its bounding box.
/// </summary>
internal sealed class TriangleMeshGeometry
{
    private readonly Vector3[] vertices;
    private readonly int[] triangles;
    internal Vector3 BoundsCenter { get; }
    internal Vector3 BoundsSize { get; }

    internal TriangleMeshGeometry(IReadOnlyList<Vector3> sourceVertices,
        IReadOnlyList<int> sourceTriangles)
    {
        if (sourceVertices.Count is < 4 or > 256 || sourceTriangles.Count is < 12 or > 1536 ||
            sourceTriangles.Count % 3 != 0 || sourceVertices.Any(vertex =>
                !PlayerHitbox.Finite(vertex)))
            throw new InvalidDataException("Invalid source mesh dimensions.");
        vertices = sourceVertices.ToArray();
        triangles = sourceTriangles.ToArray();
        for (int index = 0; index < triangles.Length; index += 3)
        {
            int a = triangles[index], b = triangles[index + 1], c = triangles[index + 2];
            if (a < 0 || b < 0 || c < 0 || a >= vertices.Length ||
                b >= vertices.Length || c >= vertices.Length ||
                Vector3.Cross(vertices[b] - vertices[a], vertices[c] - vertices[a])
                    .LengthSquared() < 1e-12f)
                throw new InvalidDataException("Source mesh contains an invalid triangle.");
        }
        Vector3 minimum = vertices.Aggregate(Vector3.Min);
        Vector3 maximum = vertices.Aggregate(Vector3.Max);
        BoundsCenter = (minimum + maximum) * .5f;
        BoundsSize = maximum - minimum;
        if (BoundsSize.X <= 0 || BoundsSize.Y <= 0 || BoundsSize.Z <= 0 ||
            BoundsSize.Length() > 20)
            throw new InvalidDataException("Source mesh bounds are invalid.");
    }

    internal float? Raycast(Vector3 origin, Vector3 direction, float maximumDistance)
    {
        float? nearest = null;
        for (int index = 0; index < triangles.Length; index += 3)
        {
            Vector3 a = vertices[triangles[index]];
            Vector3 b = vertices[triangles[index + 1]];
            Vector3 c = vertices[triangles[index + 2]];
            float? distance = RaycastTriangle(origin, direction, a, b, c);
            if (distance is >= 0 && distance <= maximumDistance &&
                (!nearest.HasValue || distance < nearest.Value))
                nearest = distance.Value;
        }
        return nearest;
    }

    private static float? RaycastTriangle(Vector3 origin, Vector3 direction,
        Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 edge1 = b - a, edge2 = c - a;
        Vector3 cross = Vector3.Cross(direction, edge2);
        float determinant = Vector3.Dot(edge1, cross);
        if (Math.Abs(determinant) < 1e-8f) return null;
        float inverse = 1f / determinant;
        Vector3 offset = origin - a;
        float u = Vector3.Dot(offset, cross) * inverse;
        if (u < 0 || u > 1) return null;
        float v = Vector3.Dot(direction, Vector3.Cross(offset, edge1)) * inverse;
        if (v < 0 || u + v > 1) return null;
        float distance = Vector3.Dot(edge2, Vector3.Cross(offset, edge1)) * inverse;
        return distance >= 0 ? distance : null;
    }

    internal float DistanceToSurface(Vector3 point)
    {
        float nearestSquared = float.PositiveInfinity;
        for (int index = 0; index < triangles.Length; index += 3)
        {
            Vector3 closest = ClosestPointOnTriangle(point,
                vertices[triangles[index]], vertices[triangles[index + 1]],
                vertices[triangles[index + 2]]);
            nearestSquared = Math.Min(nearestSquared, Vector3.DistanceSquared(point, closest));
        }
        return MathF.Sqrt(nearestSquared);
    }

    internal bool Contains(Vector3 point)
    {
        // A ray from an interior point of a closed convex mesh exits once.
        // Neighboring triangles can share that hit, so count unique distances.
        Vector3 direction = Vector3.Normalize(new Vector3(1f, .137f, .271f));
        var hits = new List<float>();
        for (int index = 0; index < triangles.Length; index += 3)
        {
            float? distance = RaycastTriangle(point, direction,
                vertices[triangles[index]], vertices[triangles[index + 1]],
                vertices[triangles[index + 2]]);
            if (distance is > 1e-5f) hits.Add(distance.Value);
        }
        hits.Sort();
        int distinct = 0;
        float previous = float.NegativeInfinity;
        foreach (float hit in hits)
        {
            if (hit - previous < 1e-4f) continue;
            distinct++;
            previous = hit;
        }
        return distinct % 2 == 1;
    }

    internal (Vector3 Min, Vector3 Max) WorldBounds(Vector3 origin, Quaternion rotation)
    {
        Vector3 minimum = new(float.PositiveInfinity);
        Vector3 maximum = new(float.NegativeInfinity);
        foreach (Vector3 vertex in vertices)
        {
            Vector3 world = origin + Vector3.Transform(vertex, rotation);
            minimum = Vector3.Min(minimum, world);
            maximum = Vector3.Max(maximum, world);
        }
        return (minimum, maximum);
    }

    // Ericson's closest-point regions for a triangle; deterministic for a
    // point on an edge or vertex as well as a point above its face.
    private static Vector3 ClosestPointOnTriangle(Vector3 point,
        Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 ab = b - a, ac = c - a, ap = point - a;
        float d1 = Vector3.Dot(ab, ap), d2 = Vector3.Dot(ac, ap);
        if (d1 <= 0 && d2 <= 0) return a;
        Vector3 bp = point - b;
        float d3 = Vector3.Dot(ab, bp), d4 = Vector3.Dot(ac, bp);
        if (d3 >= 0 && d4 <= d3) return b;
        float vc = d1 * d4 - d3 * d2;
        if (vc <= 0 && d1 >= 0 && d3 <= 0)
            return a + ab * (d1 / (d1 - d3));
        Vector3 cp = point - c;
        float d5 = Vector3.Dot(ab, cp), d6 = Vector3.Dot(ac, cp);
        if (d6 >= 0 && d5 <= d6) return c;
        float vb = d5 * d2 - d1 * d6;
        if (vb <= 0 && d2 >= 0 && d6 <= 0)
            return a + ac * (d2 / (d2 - d6));
        float va = d3 * d6 - d5 * d4;
        if (va <= 0 && d4 - d3 >= 0 && d5 - d6 >= 0)
            return b + (c - b) * ((d4 - d3) / ((d4 - d3) + (d5 - d6)));
        float denominator = 1f / (va + vb + vc);
        return a + ab * (vb * denominator) + ac * (vc * denominator);
    }
}

using System.Numerics;

namespace War.BattleServer;

public sealed record CoopNativeRayHit(
    int ComponentFileId, string ComponentType, int Layer,
    float Distance, Vector3 Position);

/// <summary>
/// Raycasts only the native colliders serialized in one co-op scene. It does
/// not include instantiated prefab colliders or mutable destroyed objects, so
/// callers must not use a clear result to authorize a player shot yet.
/// </summary>
public sealed class CoopNativeSceneRaycaster
{
    private sealed record PlacedCollider(
        CoopSceneCollider Source, Matrix4x4 Inverse,
        CoopMeshGeometry? Mesh);

    private readonly PlacedCollider[] colliders;

    public CoopNativeSceneRaycaster(
        CoopSceneColliders scene, CoopMeshGeometryCatalog geometry)
    {
        ArgumentNullException.ThrowIfNull(scene);
        ArgumentNullException.ThrowIfNull(geometry);
        var placed = new List<PlacedCollider>();
        foreach (CoopSceneCollider collider in scene.Colliders)
        {
            if (!collider.ActiveInHierarchy || !collider.Enabled ||
                collider.Trigger ||
                (collider.ComponentType == "MeshCollider" &&
                 collider.Shape.MeshFileId == 0))
                continue;
            Matrix4x4 world = Compose(collider.TransformChain);
            if (!Matrix4x4.Invert(world, out Matrix4x4 inverse))
                throw new InvalidDataException("Co-op collider transform cannot be inverted.");
            CoopMeshGeometry? mesh = collider.ComponentType == "MeshCollider"
                ? geometry.Get(collider.Shape.MeshGuid) : null;
            placed.Add(new PlacedCollider(collider, inverse, mesh));
        }
        colliders = placed.ToArray();
    }

    public CoopNativeRayHit? Raycast(
        Vector3 origin, Vector3 direction, float maxDistance,
        uint layerMask = uint.MaxValue,
        Func<int, bool>? colliderEnabled = null)
    {
        ValidateRay(origin, direction, maxDistance);
        Vector3 ray = Vector3.Normalize(direction);
        CoopNativeRayHit? nearest = null;
        foreach (PlacedCollider collider in colliders)
        {
            if ((layerMask & (1u << collider.Source.Layer)) == 0)
                continue;
            if (colliderEnabled != null &&
                !colliderEnabled(collider.Source.ComponentFileId))
                continue;
            CoopNativeRayHit? hit = Trace(collider, origin, ray,
                nearest?.Distance ?? maxDistance);
            if (hit == null)
                continue;
            if (nearest != null && hit.Distance == nearest.Distance &&
                collider.Source.ComponentFileId > nearest.ComponentFileId)
                continue;
            nearest = hit;
        }
        return nearest;
    }

    internal CoopNativeRayHit? RaycastCollider(
        int componentFileId, Vector3 origin, Vector3 direction,
        float maxDistance)
    {
        ValidateRay(origin, direction, maxDistance);
        PlacedCollider? collider = colliders.FirstOrDefault(candidate =>
            candidate.Source.ComponentFileId == componentFileId);
        return collider == null ? null : Trace(collider, origin,
            Vector3.Normalize(direction), maxDistance);
    }

    private static CoopNativeRayHit? Trace(
        PlacedCollider collider, Vector3 origin, Vector3 ray,
        float maxDistance)
    {
        Vector3 localOrigin = Vector3.Transform(origin, collider.Inverse);
        Vector3 localRay = Vector3.TransformNormal(ray, collider.Inverse);
        float? distance = RaycastShape(collider, localOrigin, localRay,
            maxDistance);
        if (distance is not float hitDistance || hitDistance < 0 ||
            hitDistance > maxDistance)
            return null;
        return new CoopNativeRayHit(collider.Source.ComponentFileId,
            collider.Source.ComponentType, collider.Source.Layer, hitDistance,
            origin + ray * hitDistance);
    }

    private static void ValidateRay(
        Vector3 origin, Vector3 direction, float maxDistance)
    {
        if (!PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(direction) ||
            direction.LengthSquared() < 1e-12f ||
            !float.IsFinite(maxDistance) || maxDistance is <= 0 or > 10_000)
            throw new ArgumentOutOfRangeException(nameof(direction));
    }

    private static Matrix4x4 Compose(
        IReadOnlyList<CoopColliderTransform> chain)
    {
        Matrix4x4 world = Matrix4x4.Identity;
        // The artifact lists the collider transform first, then its parents.
        // System.Numerics uses row vectors, so local matrices multiply in
        // that same child-to-parent order. This keeps negative/nonuniform
        // scale and the resulting shear rather than simplifying to a rotation.
        foreach (CoopColliderTransform transform in chain)
        {
            Matrix4x4 local =
                Matrix4x4.CreateScale(transform.LocalScale) *
                Matrix4x4.CreateFromQuaternion(transform.LocalRotation) *
                Matrix4x4.CreateTranslation(transform.LocalPosition);
            world *= local;
        }
        return world;
    }

    private static float? RaycastShape(
        PlacedCollider collider, Vector3 origin, Vector3 ray,
        float maxDistance)
    {
        CoopColliderShape shape = collider.Source.Shape;
        return collider.Source.ComponentType switch
        {
            "MeshCollider" => RaycastMesh(collider.Mesh!, origin, ray,
                maxDistance),
            "BoxCollider" => RaycastBox(origin - shape.Center, ray,
                shape.Size * 0.5f, maxDistance),
            "CapsuleCollider" => RaycastCapsule(origin - shape.Center, ray,
                shape.Radius, shape.Height, shape.Direction, maxDistance),
            "SphereCollider" => RaycastSphere(origin - shape.Center, ray,
                shape.Radius, maxDistance),
            _ => throw new InvalidDataException("Unknown co-op collider shape.")
        };
    }

    private static float? RaycastMesh(
        CoopMeshGeometry mesh, Vector3 origin, Vector3 ray,
        float maxDistance)
    {
        float? nearest = null;
        for (int index = 0; index < mesh.Triangles.Count; index += 3)
        {
            Vector3 a = mesh.Vertices[mesh.Triangles[index]];
            Vector3 b = mesh.Vertices[mesh.Triangles[index + 1]];
            Vector3 c = mesh.Vertices[mesh.Triangles[index + 2]];
            Vector3 edgeOne = b - a;
            Vector3 edgeTwo = c - a;
            Vector3 cross = Vector3.Cross(ray, edgeTwo);
            float determinant = Vector3.Dot(edgeOne, cross);
            // PhysX MeshCollider.Raycast ignores backfaces by default.
            if (determinant <= 1e-7f)
                continue;
            Vector3 fromA = origin - a;
            float sideOne = Vector3.Dot(fromA, cross);
            if (sideOne < 0 || sideOne > determinant)
                continue;
            Vector3 otherCross = Vector3.Cross(fromA, edgeOne);
            float sideTwo = Vector3.Dot(ray, otherCross);
            if (sideTwo < 0 || sideOne + sideTwo > determinant)
                continue;
            float distance = Vector3.Dot(edgeTwo, otherCross) / determinant;
            if (distance > 0 && distance <= (nearest ?? maxDistance))
                nearest = distance;
        }
        return nearest;
    }

    private static float? RaycastBox(
        Vector3 origin, Vector3 ray, Vector3 halfSize,
        float maxDistance)
    {
        if (Vector3.Abs(origin).X < halfSize.X &&
            Vector3.Abs(origin).Y < halfSize.Y &&
            Vector3.Abs(origin).Z < halfSize.Z)
            return null;
        float near = 0;
        float far = maxDistance;
        for (int axis = 0; axis < 3; axis++)
        {
            float position = Axis(origin, axis);
            float velocity = Axis(ray, axis);
            float half = Axis(halfSize, axis);
            if (Math.Abs(velocity) < 1e-9f)
            {
                if (position < -half || position > half)
                    return null;
                continue;
            }
            float first = (-half - position) / velocity;
            float second = (half - position) / velocity;
            near = Math.Max(near, Math.Min(first, second));
            far = Math.Min(far, Math.Max(first, second));
            if (near > far)
                return null;
        }
        return near > 0 ? near : null;
    }

    private static float? RaycastCapsule(
        Vector3 origin, Vector3 ray, float radius, float height,
        int axis, float maxDistance)
    {
        // Four recovered Humvee wheel capsules serialize a height slightly
        // below their diameter. Unity treats those as rounded spheres.
        float segmentHalf = MathF.Max(height, 2 * radius) * 0.5f - radius;
        float axialOrigin = Axis(origin, axis);
        float axialRay = Axis(ray, axis);
        Vector3 flatOrigin = SetAxis(origin, axis, 0);
        Vector3 flatRay = SetAxis(ray, axis, 0);
        float nearestAxis = Math.Clamp(axialOrigin, -segmentHalf, segmentHalf);
        if ((flatOrigin.LengthSquared() +
             (axialOrigin - nearestAxis) * (axialOrigin - nearestAxis)) <
            radius * radius)
            return null;

        float? nearest = null;
        float a = flatRay.LengthSquared();
        float b = 2 * Vector3.Dot(flatOrigin, flatRay);
        float c = flatOrigin.LengthSquared() - radius * radius;
        if (a > 1e-12f)
        {
            float discriminant = b * b - 4 * a * c;
            if (discriminant >= 0)
            {
                float distance = (-b - MathF.Sqrt(discriminant)) / (2 * a);
                float axialHit = axialOrigin + distance * axialRay;
                if (distance > 0 && distance <= maxDistance &&
                    Math.Abs(axialHit) <= segmentHalf)
                    nearest = distance;
            }
        }
        foreach (int side in new[] { -1, 1 })
        {
            Vector3 center = SetAxis(Vector3.Zero, axis, side * segmentHalf);
            Vector3 offset = origin - center;
            float sphereA = ray.LengthSquared();
            float sphereB = 2 * Vector3.Dot(offset, ray);
            float sphereC = offset.LengthSquared() - radius * radius;
            float discriminant = sphereB * sphereB - 4 * sphereA * sphereC;
            if (discriminant < 0)
                continue;
            float distance = (-sphereB - MathF.Sqrt(discriminant)) /
                (2 * sphereA);
            float axialHit = axialOrigin + distance * axialRay;
            if (distance > 0 && distance <= (nearest ?? maxDistance) &&
                side * axialHit >= segmentHalf)
                nearest = distance;
        }
        return nearest;
    }

    private static float? RaycastSphere(
        Vector3 origin, Vector3 ray, float radius, float maxDistance)
    {
        float radiusSquared = radius * radius;
        if (origin.LengthSquared() < radiusSquared)
            return null;
        float a = ray.LengthSquared();
        float b = 2 * Vector3.Dot(origin, ray);
        float c = origin.LengthSquared() - radiusSquared;
        float discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
            return null;
        float distance = (-b - MathF.Sqrt(discriminant)) / (2 * a);
        return distance > 0 && distance <= maxDistance ? distance : null;
    }

    private static float Axis(Vector3 value, int axis)
    {
        return axis switch { 0 => value.X, 1 => value.Y, _ => value.Z };
    }

    private static Vector3 SetAxis(Vector3 value, int axis, float coordinate)
    {
        return axis switch
        {
            0 => new Vector3(coordinate, value.Y, value.Z),
            1 => new Vector3(value.X, coordinate, value.Z),
            _ => new Vector3(value.X, value.Y, coordinate)
        };
    }
}

using System.Numerics;

namespace War.BattleServer;

internal sealed record CoopShotHit(
    float Distance, Vector3 Position, int? SceneColliderFileId,
    ulong? EnemyEntityId, int? EnemyPartFileId);

/// <summary>
/// Compares recovered scene geometry with host-placed enemy hitboxes. This is
/// a collision diagnostic, not a complete co-op bullet world: instantiated
/// prefab colliders and mutable cover still need lifecycle authority.
/// </summary>
internal sealed class CoopShotCollisionWorld
{
    private readonly CoopNativeSceneRaycaster scene;

    internal CoopShotCollisionWorld(CoopNativeSceneRaycaster scene)
    {
        this.scene = scene ?? throw new ArgumentNullException(nameof(scene));
    }

    internal CoopShotHit? Trace(Vector3 origin, Vector3 direction,
        float maximumDistance, uint layerMask,
        IReadOnlyList<DynamicShotTarget> enemyTargets)
    {
        ArgumentNullException.ThrowIfNull(enemyTargets);
        if (enemyTargets.Count > 512)
            throw new InvalidDataException("Too many co-op shot targets.");

        // The scene raycaster validates the ray and normalizes its direction.
        CoopNativeRayHit? sceneHit = scene.Raycast(origin, direction,
            maximumDistance, layerMask);
        CoopShotHit? nearest = sceneHit == null ? null : new CoopShotHit(
            sceneHit.Distance, sceneHit.Position,
            sceneHit.ComponentFileId, null, null);
        Vector3 ray = Vector3.Normalize(direction);

        var identities = new HashSet<(ulong EntityId, int PartFileId)>();
        foreach (DynamicShotTarget target in enemyTargets)
        {
            if (target == null || target.EntityId == 0 ||
                target.Layer is < 0 or > 31 || target.Hitbox == null ||
                target.PartComponentFileId <= 0 ||
                !identities.Add((target.EntityId, target.PartComponentFileId)))
                throw new InvalidDataException("Invalid co-op enemy hitbox identity.");
            if ((layerMask & (1u << target.Layer)) == 0)
                continue;

            float? distance = target.Hitbox.Raycast(origin, ray,
                maximumDistance);
            // Native scene geometry wins a distance tie, preventing a target
            // embedded in a wall from being treated as a clear hit.
            if (distance == null ||
                (nearest != null && distance.Value >= nearest.Distance))
                continue;
            nearest = new CoopShotHit(distance.Value,
                origin + ray * distance.Value, null,
                target.EntityId, target.PartComponentFileId);
        }
        return nearest;
    }
}

using System.Numerics;

namespace War.BattleServer;

internal sealed record CoopShotHit(
    float Distance, Vector3 Position, int? SceneColliderFileId,
    ulong? EnemyEntityId, int? EnemyPartFileId,
    string? EnemyPartPath = null, float PartWeight = 0);

internal sealed record CoopEnemyCollisionFrame(
    IReadOnlyList<DynamicShotTarget> Targets,
    IReadOnlyList<ulong> UnplacedEnemyIds,
    bool BossUnplaced = false);

/// <summary>
/// Compares recovered scene geometry with host-placed enemy hitboxes. This is
/// a collision diagnostic, not a complete co-op bullet world: instantiated
/// prefab colliders and mutable cover still need lifecycle authority.
/// </summary>
internal sealed class CoopShotCollisionWorld
{
    private readonly CoopNativeSceneRaycaster scene;
    internal string Scene => scene.Scene;
    internal string SceneSha256 => scene.SceneSha256;

    internal CoopShotCollisionWorld(CoopNativeSceneRaycaster scene)
    {
        this.scene = scene ?? throw new ArgumentNullException(nameof(scene));
    }

    internal CoopShotHit? Trace(Vector3 origin, Vector3 direction,
        float maximumDistance, uint layerMask,
        CoopEnemyCollisionFrame frame)
    {
        ArgumentNullException.ThrowIfNull(frame);
        IReadOnlyList<DynamicShotTarget> enemyTargets = frame.Targets;
        ArgumentNullException.ThrowIfNull(enemyTargets);
        ArgumentNullException.ThrowIfNull(frame.UnplacedEnemyIds);
        if (frame.UnplacedEnemyIds.Count != 0 || frame.BossUnplaced)
            throw new InvalidOperationException(
                "Co-op shot world is missing a live enemy collider.");
        if (enemyTargets.Count > 512)
            throw new InvalidDataException("Too many co-op shot targets.");

        // The scene raycaster validates the ray and normalizes its direction.
        CoopNativeRayHit? sceneHit = scene.Raycast(origin, direction,
            maximumDistance, layerMask);
        CoopShotHit? nearest = sceneHit == null ? null : new CoopShotHit(
            sceneHit.Distance, sceneHit.Position,
            sceneHit.ComponentFileId, null, null);
        Vector3 ray = Vector3.Normalize(direction);

        // Vehicles and air units retain serialized collider IDs. The sampled
        // infantry rig has no collider IDs in its pose artifact, so its three
        // parts use the source hierarchy path plus shape kind within one AI.
        var sourceParts = new HashSet<(ulong EntityId, int PartFileId)>();
        var infantryParts = new HashSet<
            (ulong EntityId, string Path, PlayerHitboxKind Kind)>();
        foreach (DynamicShotTarget target in enemyTargets)
        {
            if (target == null || target.EntityId == 0 ||
                target.Layer is < 0 or > 31 || target.Hitbox == null ||
                (target.ArmyInfantry && target.PartComponentFileId != 0) ||
                (target.PartComponentFileId <= 0 &&
                    !(target.ArmyInfantry && target.PartComponentFileId == 0 &&
                      target.Layer == 23)))
                throw new InvalidDataException("Invalid co-op enemy hitbox identity.");
            bool newIdentity = target.PartComponentFileId > 0
                ? sourceParts.Add((target.EntityId,
                    target.PartComponentFileId))
                : infantryParts.Add((target.EntityId,
                    target.Hitbox.SourcePath, target.Hitbox.Kind));
            if (!newIdentity)
                throw new InvalidDataException("Duplicate co-op enemy hitbox identity.");
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
                target.EntityId,
                target.PartComponentFileId > 0
                    ? target.PartComponentFileId : null,
                target.Hitbox.SourcePath, target.Hitbox.Weight);
        }
        return nearest;
    }
}

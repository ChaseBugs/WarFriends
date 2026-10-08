using System.Numerics;

namespace War.BattleServer;

internal sealed record CoopPlayerShotHit(
    float Distance, Vector3 Position, int? SceneColliderFileId,
    string? PlayerId, string? PlayerPartPath, float PartWeight,
    int? SceneLayer = null)
{
    internal ShotCollision ToBulletCollision()
    {
        bool sceneHit = SceneColliderFileId.HasValue;
        return new ShotCollision(Distance, Position,
            sceneHit ? $"scene/{SceneColliderFileId}" : PlayerPartPath!,
            PlayerId, PartWeight,
            Static: SceneLayer is 13 or 30,
            ColliderIndex: SceneColliderFileId,
            ColliderLayer: SceneLayer ?? 22);
    }
}

/// <summary>
/// Traces an enemy round against the recovered co-op scene and two host-owned
/// allied poses. Moving run poses can be supplied for inspection; live cover,
/// Unity 5.2 collision parity, and damage authority remain unresolved.
/// </summary>
internal sealed class CoopPlayerShotCollisionWorld
{
    private readonly CoopNativeSceneRaycaster scene;
    private readonly IReadOnlyDictionary<int, int> shieldCoverByCollider;
    internal string Scene { get; }
    internal string SceneSha256 { get; }

    internal int? CoverForShieldCollider(int componentFileId) =>
        shieldCoverByCollider.TryGetValue(componentFileId, out int coverIndex)
            ? coverIndex : null;

    internal CoopPlayerShotCollisionWorld(CoopSceneColliders source,
        CoopMapSpawnPoints spawns, CoopMeshGeometryCatalog geometry)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(spawns);
        ArgumentNullException.ThrowIfNull(geometry);
        if (source.Scene != spawns.Scene ||
            source.SceneSha256 != spawns.SceneSha256 ||
            spawns.PlayerPositions.Count != 4)
            throw new InvalidDataException(
                "Co-op shot world differs from its allied cover anchors.");

        var shieldCovers = new Dictionary<int, int>();
        foreach (CoopSceneCollider collider in source.Colliders.Where(
            row => row.GameObjectName == "riot_shield"))
        {
            if (collider.Layer != 24 ||
                collider.ComponentType != "BoxCollider" ||
                !collider.ActiveInHierarchy || !collider.Enabled ||
                collider.Trigger)
                throw new InvalidDataException(
                    "Co-op shield collider differs from the source scene.");
            CoopPlayerAnchor nearest = spawns.PlayerPositions.MinBy(
                anchor => Vector3.DistanceSquared(
                    anchor.Position, collider.WorldPosition))!;
            if (Vector3.Distance(nearest.Position,
                    collider.WorldPosition) > 0.2f ||
                !shieldCovers.TryAdd(collider.ComponentFileId,
                    nearest.Index))
                throw new InvalidDataException(
                    "Co-op shield collider has no unique cover identity.");
        }
        if (shieldCovers.Count != 4 ||
            shieldCovers.Values.Distinct().Count() != 4)
            throw new InvalidDataException(
                "Co-op shield collider set is incomplete.");
        shieldCoverByCollider = shieldCovers;
        Scene = source.Scene;
        SceneSha256 = source.SceneSha256;
        scene = new CoopNativeSceneRaycaster(source, geometry);
    }

    internal CoopPlayerShotHit? Trace(Vector3 origin, Vector3 direction,
        float maximumDistance, uint enemyBulletMask,
        IReadOnlyList<CollisionPlayer> players,
        IReadOnlyList<ShieldMutation>? alliedShields = null)
    {
        ArgumentNullException.ThrowIfNull(players);
        if (players.Count != 2 || players.Any(player =>
                player == null ||
                !Guid.TryParseExact(player.PlayerId, "N", out _) ||
                player.PlayerId != player.PlayerId.ToLowerInvariant() ||
                player.Pose == null ||
                player.Pose.Role != "gameplay" ||
                player.Pose.PoseKind == "serialized-reference-only" ||
                player.Layer != 22 || player.Fraction != 2) ||
            players[0].PlayerId == players[1].PlayerId)
            throw new InvalidDataException(
                "Co-op enemy ray needs two current allied poses.");

        Dictionary<int, bool>? shieldDestroyed = null;
        if (alliedShields != null)
        {
            if (alliedShields.Count != 4 || alliedShields.Any(shield =>
                    shield.OwnerFraction != 2 ||
                    !float.IsFinite(shield.Health) ||
                    !float.IsFinite(shield.MaxHealth) ||
                    shield.MaxHealth < 0 ||
                    shield.Health < 0 ||
                    shield.Health > shield.MaxHealth ||
                    (shield.Destroyed && shield.Health != 0) ||
                    !shieldCoverByCollider.Values.Contains(
                        shield.CoverIndex)) ||
                alliedShields.Select(shield => shield.CoverIndex)
                    .Distinct().Count() != 4)
                throw new InvalidDataException(
                    "Co-op ray needs the four current allied shields.");
            shieldDestroyed = alliedShields.ToDictionary(
                shield => shield.CoverIndex,
                shield => shield.Destroyed);
        }
        CoopNativeRayHit? sceneHit = scene.Raycast(origin, direction,
            maximumDistance, enemyBulletMask, colliderId =>
                !shieldCoverByCollider.TryGetValue(colliderId,
                    out int coverIndex) ||
                shieldDestroyed == null ||
                !shieldDestroyed[coverIndex]);
        CoopPlayerShotHit? nearest = sceneHit == null ? null : new(
            sceneHit.Distance, sceneHit.Position,
            sceneHit.ComponentFileId, null, null, 0, sceneHit.Layer);
        Vector3 ray = Vector3.Normalize(direction);

        foreach (CollisionPlayer player in players)
        {
            if ((enemyBulletMask & (1u << player.Layer)) == 0)
                continue;
            PlayerHit? hit = player.Pose.Raycast(origin, ray,
                maximumDistance);
            // A wall at the same distance wins over the player pose.
            if (hit == null ||
                (nearest != null && hit.Distance >= nearest.Distance))
                continue;
            nearest = new(hit.Distance, hit.Position, null,
                player.PlayerId, hit.PartPath, hit.Weight);
        }
        return nearest;
    }
}

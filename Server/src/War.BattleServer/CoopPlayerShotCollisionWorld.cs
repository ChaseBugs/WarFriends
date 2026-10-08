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
/// allied poses. This is diagnostic until moving poses, live cover, and the
/// Unity 5.2 collision differences are resolved.
/// </summary>
internal sealed class CoopPlayerShotCollisionWorld
{
    private readonly CoopNativeSceneRaycaster scene;
    internal string Scene { get; }
    internal string SceneSha256 { get; }

    internal CoopPlayerShotCollisionWorld(CoopSceneColliders source,
        CoopMeshGeometryCatalog geometry)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(geometry);
        Scene = source.Scene;
        SceneSha256 = source.SceneSha256;
        scene = new CoopNativeSceneRaycaster(source, geometry);
    }

    internal CoopPlayerShotHit? Trace(Vector3 origin, Vector3 direction,
        float maximumDistance, uint enemyBulletMask,
        IReadOnlyList<CollisionPlayer> players)
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

        CoopNativeRayHit? sceneHit = scene.Raycast(origin, direction,
            maximumDistance, enemyBulletMask);
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

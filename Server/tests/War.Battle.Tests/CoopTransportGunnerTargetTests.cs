using War.BattleServer;

/// <summary>Checks the separate transport soldier's source geometry and lifecycle.</summary>
internal static class CoopTransportGunnerTargetTests
{
    private const int ExpectedSoldierPartCount = 3;
    private const int EnemySoldierLayer = 23;
    private const float RayOriginOffset = 5;
    private const float RayDistance = 10;

    internal static void RequireLivingTargets(CoopMatchRuntime runtime, BattleCombatContent content, ulong entityId)
    {
        HelicopterGunnerSnapshot gunner = runtime.TransportGunner(entityId)
            ?? throw new Exception("The co-op transport gunner is missing.");
        HelicopterTurretRestPose seat = runtime.PlaceTransportGunner(entityId)
            ?? throw new Exception("The co-op transport gunner seat is missing.");
        IReadOnlyList<PlayerHitbox> expected = content.GroundVehicleWeapons.PassengerPoses
            .PlaceHelicopterGunner(seat, runtime.Snapshot().ServerTick - gunner.SpawnTick);
        IReadOnlyList<DynamicShotTarget> actual = runtime.PlaceRestingTransportGunnerTargets(entityId);
        if (actual.Count != ExpectedSoldierPartCount || expected.Count != actual.Count)
        {
            throw new Exception("The co-op gunner lost its three sampled soldier parts.");
        }

        for (int index = 0; index < actual.Count; index++)
        {
            DynamicShotTarget part = actual[index];
            PlayerHitbox source = expected[index];
            if (!part.HelicopterGunner || part.ArmyInfantry || part.HelicopterBody ||
                part.EntityId != entityId || part.Layer != EnemySoldierLayer || part.PartComponentFileId != 0 ||
                part.Hitbox.SourcePath != source.SourcePath || part.Hitbox.Center != source.Center ||
                part.Hitbox.Rotation != source.Rotation || part.Hitbox.Weight != source.Weight)
            {
                throw new Exception("The co-op gunner differs from its source seat, pose or damage identity.");
            }
        }

        if (runtime.CurrentEnemyCollisionFrame().Targets.Count(target =>
                target.EntityId == entityId && target.HelicopterGunner) != actual.Count)
        {
            throw new Exception("The diagnostic collision frame omitted the living transport gunner.");
        }
    }

    internal static void RequireNoTargets(CoopMatchRuntime runtime, ulong entityId)
    {
        if (runtime.PlaceRestingTransportGunnerTargets(entityId).Count != 0 ||
            runtime.CurrentEnemyCollisionFrame().Targets.Any(target =>
                target.EntityId == entityId && target.HelicopterGunner))
        {
            throw new Exception("A dead co-op gunner retained its soldier colliders.");
        }
    }

    internal static void RequireRayIdentity(CoopShotCollisionWorld world, IReadOnlyList<DynamicShotTarget> targets)
    {
        var origin = targets[0].Hitbox.Center - System.Numerics.Vector3.UnitZ * RayOriginOffset;
        var direction = System.Numerics.Vector3.UnitZ;
        const uint GunnerLayerMask = 1u << EnemySoldierLayer;
        var frame = new CoopEnemyCollisionFrame(targets, []);
        CoopShotHit? hit = world.Trace(origin, direction, RayDistance, GunnerLayerMask, frame);
        if (hit == null || !hit.IsHelicopterGunner || hit.EnemyEntityId != targets[0].EntityId ||
            hit.EnemyPartFileId != null || hit.EnemyPartPath == null || hit.PartWeight <= 0)
        {
            throw new Exception("A co-op gunner ray lost its separate soldier damage identity.");
        }

        foreach (DynamicShotTarget[] invalid in new[]
        {
            new[] { targets[0], targets[0] },
            new[] { targets[0] with { ArmyInfantry = true } },
            new[] { targets[0] with { GroundVehicleBody = true } }
        })
        {
            try
            {
                world.Trace(origin, direction, RayDistance, GunnerLayerMask, new CoopEnemyCollisionFrame(invalid, []));
                throw new Exception("A co-op gunner ray accepted duplicate or ambiguous soldier identity.");
            }
            catch (InvalidDataException)
            {
                // A sampled soldier cannot simultaneously be an infantry or vehicle body target.
            }
        }
    }
}

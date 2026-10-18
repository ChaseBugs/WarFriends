using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void RefreshGunslingerTarget(GunslingerShotAttempt attempt)
    {
        if (attempt.Prediction != null)
        {
            return;
        }

        AssaulterShotTarget selected = attempt.Aim.Target;
        if (selected.IsPlayer)
        {
            RefreshGunslingerPlayerTarget(attempt, selected);
            return;
        }

        if (selected.EntityId.StartsWith("decoy:", StringComparison.Ordinal))
        {
            DecoyMatchEntity? decoy = decoys.Snapshot().SingleOrDefault(row =>
                DroneDecoyId(row.EntityId) == selected.EntityId);
            if (decoy != null)
            {
                DecoyPrefabSource source = decoySource?.Prefab ??
                    throw new InvalidDataException("Gunslinger callback lost its Decoy source.");
                Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY,
                    MathF.Atan2(decoy.Facing.X, decoy.Facing.Z));
                attempt.LastTargetPosition = decoy.Position + Vector3.Transform(source.TargetLocalPosition, rotation);
                attempt.LastTargetVelocity = Vector3.Zero;
            }

            return;
        }

        BattleArmyEntityState? entity = activeArmyEntities.Values.SingleOrDefault(row =>
            DroneArmyId(row.EntityKey) == selected.EntityId);
        if (entity == null)
        {
            // Disabled source entities retain their last transform/velocity. Host
            // death captures that pose before removing the live geometry registry.
            return;
        }

        DroneShotTarget target = InfantryShotTargets(entity.EntityKey)?.Single(row =>
            row.TransformFileId == selected.TransformFileId) ??
            throw new InvalidDataException("Gunslinger callback lost its selected source transform.");
        attempt.LastTargetPosition = target.Position;
        // Match-owned observation initializes a newly spawned root at zero
        // velocity until its first pair of positions exists, just as the shared observer does.
        attempt.LastTargetVelocity = _armyObservedMotion.TryGetValue(entity.EntityKey, out ArmyObservedMotion? motion)
            ? motion.Velocity : Vector3.Zero;
    }

    private void RefreshGunslingerPlayerTarget(GunslingerShotAttempt attempt, AssaulterShotTarget selected)
    {
        Player player = Find(selected.OwnerPlayerId) ??
            throw new InvalidDataException("Gunslinger callback lost its selected player.");
        PlayerAimPose pose = rifleCombat?.Pose(selected.OwnerPlayerId) ??
            GrenadePlayerCombatPose(selected.OwnerPlayerId);
        Vector3? position;
        if (selected.ShotTargetType == AssaulterShieldMask)
        {
            // GameShootableEntityPlayer.GetShotTargets creates a new ShotTarget
            // referencing the selected cover's shotPosition. Moving later does
            // not rebind that object to the player's next cover or child target.
            int cover = selected.CapturedShieldCoverIndex ??
                throw new InvalidDataException("Gunslinger Shield callback lost its captured cover identity.");
            if (map == null || cover < 0 || cover >= map.Covers.Count)
            {
                throw new InvalidDataException("Gunslinger Shield callback references an invalid source cover.");
            }

            position = map.Covers[cover].ShotPosition;
        }
        else
        {
            position = selected.ShotTargetType == AssaulterMovingMask
                ? pose.MovingTarget?.Position : pose.BodyTargetPosition(selected.TransformFileId);
        }
        if (position.HasValue)
        {
            attempt.LastTargetPosition = position.Value;
        }

        attempt.LastTargetVelocity = HeavyTurretPlayerVelocity(player);
    }

    private void FreezeGunslingerTargetsForDeath(ulong entityKey)
    {
        string identity = DroneArmyId(entityKey);
        foreach (GunslingerShotAttempt attempt in _gunslingerAttempts.Values.Where(row =>
            !row.CompletedTick.HasValue && row.Prediction == null && row.Aim.Target.EntityId == identity))
        {
            RefreshGunslingerTarget(attempt);
        }
    }
}

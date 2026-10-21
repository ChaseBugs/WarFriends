using System.Numerics;

namespace War.BattleServer;

internal sealed record AssaulterPreparedAim(ulong ActorEntityKey, ulong AcquisitionTick,
    AssaulterShotTarget Target, AssaulterAimPrediction? MovingPrediction)
{
    internal Vector3 TargetPosition => MovingPrediction?.TargetPosition ?? Target.TransformPosition;
}

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, AssaulterWeaponAimState> _assaulterAimWeapons = [];

    /// <summary>Reads match-owned source weapon speed state; no packet supplies its multiplier.</summary>
    internal AssaulterWeaponAimState? AssaulterAimWeapon(ulong entityKey)
    {
        return _assaulterAimWeapons.GetValueOrDefault(entityKey);
    }

    /// <summary>Captures target-selection prediction independently of later callback motion and speed.</summary>
    internal AssaulterPreparedAim? CaptureAssaulterAim(ulong entityKey)
    {
        AssaulterShotTarget? target = SelectAssaulterShotTarget(entityKey);
        if (target == null)
        {
            return null;
        }

        AssaulterWeaponAimState weapon = AssaulterAimWeapon(entityKey) ??
            throw new InvalidDataException("Normal Assaulter lost its current weapon aim state.");
        AssaulterAimPrediction? prediction = null;
        if (target.IsPlayer && target.ShotTargetType == AssaulterMovingMask)
        {
            Player player = Find(target.OwnerPlayerId) ??
                throw new InvalidDataException("Assaulter moving target lost its source player.");
            Vector3 muzzle = StationarySoldierAcquisitionMuzzle(entityKey);
            prediction = weapon.SelectMovingPlayer(muzzle, target.TransformPosition, HeavyTurretPlayerVelocity(player));
        }

        return new AssaulterPreparedAim(entityKey, tick, target, prediction);
    }

    private Vector3 StationarySoldierAcquisitionMuzzle(ulong entityKey)
    {
        if (enemyMuzzles == null || !infantryAnimations.TryGetValue(entityKey, out var animation) ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) || tick < animation.StartTick)
        {
            throw new InvalidDataException("Assaulter acquisition lost its current source rig pose.");
        }

        float yaw = MathF.Atan2(animation.Facing.X, animation.Facing.Z);
        float seconds = (tick - animation.StartTick) / (float)MatchManifest.TickRate;
        CoopMuzzlePose pose = enemyMuzzles.Place(animation.Clip, new Vector3(entity.X, entity.Y, entity.Z),
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw), seconds);
        // Gun.ComputeFlyTimeToTarget uses spawnPoint, without Gun.Shoot's shotOffset.
        return pose.Position;
    }
}

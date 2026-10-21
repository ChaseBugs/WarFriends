using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float GrenadierAimingPaddingSeconds = 0.1f;
    private const float GrenadierGunPaddingSeconds = 0.1f;

    /// <summary>The host's latched target remains distinct from subsequent moving-player poses.</summary>
    internal CardGrenadierAim? CardGrenadierLatchedAim(ulong entityKey)
    {
        return grenadierShotTargets.GetValueOrDefault(entityKey);
    }

    /// <summary>Samples the published base pose at acquisition, before preparation or future firing poses.</summary>
    internal Vector3 CardGrenadierAcquisitionMuzzle(ulong entityKey)
    {
        if (enemyMuzzles == null || assaulterWeapon == null ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) || !IsGrenadier(entity) ||
            !infantryAnimations.TryGetValue(entityKey, out var animation) || tick < animation.StartTick)
        {
            throw new InvalidDataException("Grenadier acquisition has no current source rig authority.");
        }

        Vector3 position = new(entity.X, entity.Y, entity.Z);
        float yaw = MathF.Atan2(animation.Facing.X, animation.Facing.Z);
        float seconds = (tick - animation.StartTick) / (float)MatchManifest.TickRate;
        CoopMuzzlePose reference = enemyMuzzles.Place(animation.Clip, position,
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw), seconds);
        return GrenadierAcquisitionMuzzle.Place(reference, assaulterWeapon, GrenadierPrimaryWeapon.Instance);
    }
}

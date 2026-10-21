using System.Numerics;

using War.Protocol;
using War.Shared;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly MortarPreparedPoseSource? _mortarPreparedPoseSource;
    private readonly Dictionary<ulong, MortarDetachedWeaponPose> _mortarDetachedWeapons = [];

    /// <summary>Reads frozen host authority only while the source weapon is detached.</summary>
    internal MortarDetachedWeaponPose? MortarDetachedWeapon(ulong entityKey)
    {
        return _mortarDetachedWeapons.TryGetValue(entityKey, out var pose) && tick < pose.HandReturnTick ? pose : null;
    }

    private void CaptureMortarWeaponAttachment(ulong entityKey)
    {
        var source = _mortarPreparedPoseSource ??
            throw new InvalidDataException("Mortar preparation lost its native snap-point source.");
        var entity = activeArmyEntities[entityKey];
        Vector3 facing = (_mortarFacings.GetValueOrDefault(entityKey) ??
            throw new InvalidDataException("Mortar preparation lost its current source-facing tween.")).FacingAt(tick);
        var position = new Vector3(entity.X, entity.Y, entity.Z);
        MortarDetachedWeaponPose pose = source.Capture(tick,
            (_mortarConstruction[entityKey].EnteredTick, position, facing), _mortarBuildSeconds[entityKey],
            enemyPoses!.Clip("mortar_hide").Length);
        _mortarDetachedWeapons.Add(entityKey, pose);
    }

    private void ReturnMortarWeaponsToHands()
    {
        foreach (var (entityKey, pose) in _mortarDetachedWeapons.ToArray())
        {
            if (tick >= pose.HandReturnTick)
            {
                _mortarDetachedWeapons.Remove(entityKey);
            }
        }
    }

    private void ProjectMortarWeaponPose(BattleArmyEntityState actor)
    {
        MortarDetachedWeaponPose? frozen = MortarDetachedWeapon(actor.EntityKey);
        if (frozen == null)
        {
            actor.MortarWeaponPose = null;
            return;
        }
        var pose = new BattleMortarWeaponPose
        {
            PreparedTick = frozen.PreparedTick,
            HandReturnTick = frozen.HandReturnTick,
            ObservedTick = tick,
            X = frozen.Position.X,
            Y = frozen.Position.Y,
            Z = frozen.Position.Z,
            Rotation = new BattleJointRotation
            {
                X = frozen.Rotation.X, Y = frozen.Rotation.Y, Z = frozen.Rotation.Z, W = frozen.Rotation.W
            },
            ScaleX = frozen.Scale.X,
            ScaleY = frozen.Scale.Y,
            ScaleZ = frozen.Scale.Z
        };
        actor.MortarWeaponPose = pose;
        if (!MortarWeaponPosePolicy.IsValid(actor, tick))
        {
            throw new InvalidDataException("Mortar roster lost its valid captured world-pose authority.");
        }
    }
}

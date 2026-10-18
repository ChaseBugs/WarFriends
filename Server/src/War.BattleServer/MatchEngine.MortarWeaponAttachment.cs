using System.Numerics;

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
}

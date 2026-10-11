using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Places the card Sniper muzzle at the source Corner firing pose. The enemy
/// rig samples contain the attached Assaulter rifle; both weapons use the
/// same gun snap, so their pinned local muzzle difference can be applied to
/// the sampled pose.
/// </summary>
internal static class CardSniperMuzzlePose
{
    internal static Vector3 Place(CoopEnemyMuzzleCatalog enemyMuzzles,
        CoopAssaulterWeaponCatalog assaulterWeapon,
        ArmyWeaponBindingCatalog armyWeapons, CardUnitInitialPoint corner,
        Vector3 soldierPosition, Vector3 targetPosition)
    {
        ArgumentNullException.ThrowIfNull(enemyMuzzles);
        ArgumentNullException.ThrowIfNull(assaulterWeapon);
        ArgumentNullException.ThrowIfNull(armyWeapons);
        ArgumentNullException.ThrowIfNull(corner);

        if (corner.ComponentType != "EnemyPointCorner" ||
            corner.CornerRightSide is not bool rightSide ||
            corner.CornerDirection is not Vector3 direction ||
            !PlayerHitbox.Finite(soldierPosition) ||
            !PlayerHitbox.Finite(targetPosition) ||
            !CornerShotPolicy.CanExpose(direction, rightSide,
                soldierPosition, targetPosition))
            throw new InvalidDataException("Card Sniper cannot expose at this Corner.");

        Vector3 awayFromTarget = soldierPosition - targetPosition;
        awayFromTarget.Y = 0;
        if (awayFromTarget.LengthSquared() < 0.0001f)
            throw new InvalidDataException("Card Sniper has no firing direction.");

        // EnemyController.PrepareToShoot finishes its Corner rotation before
        // the 1.05-second callback. Its final orientation faces -vector.
        float yaw = MathF.Atan2(awayFromTarget.X, awayFromTarget.Z);
        Quaternion facing = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
        string clip = rightSide
            ? "player_fire_right_sniper" : "player_fire_left_sniper";
        CoopMuzzlePose sampledAssaulter = enemyMuzzles.Place(
            clip, soldierPosition, facing, 0.05f);

        ArmyWeaponMuzzle sniperRest = armyWeapons.Muzzle("ID_UNIT-SNIPER");
        Quaternion inverseGunSnap = Quaternion.Inverse(
            armyWeapons.GunSnapRotation);
        Quaternion sniperLocalRotation = Quaternion.Normalize(
            inverseGunSnap * sniperRest.RestRotation);
        // Both recovered weapon muzzles have the same local orientation.
        // Without that identity, a position-only offset would be unsound.
        if (MathF.Abs(Quaternion.Dot(sniperLocalRotation,
                Quaternion.Identity)) < .9999f)
            throw new InvalidDataException(
                "Card Sniper weapon muzzle changed its attachment rotation.");
        Vector3 sniperLocalMuzzle = Vector3.Transform(
            sniperRest.RestPosition - armyWeapons.GunSnapPosition,
            inverseGunSnap);
        Vector3 muzzleDifference = sniperLocalMuzzle -
            assaulterWeapon.MuzzleRestPosition;
        Vector3 sniperMuzzle = sampledAssaulter.Position +
            Vector3.Transform(muzzleDifference, sampledAssaulter.Rotation);
        if (!PlayerHitbox.Finite(sniperMuzzle) ||
            Vector3.Distance(sniperMuzzle, soldierPosition) > 5f)
            throw new InvalidDataException("Card Sniper animated muzzle left the soldier rig.");
        return sniperMuzzle;
    }
}

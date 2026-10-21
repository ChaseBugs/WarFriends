using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Places BazookaEnemy's Spawn transform on the recovered enemy firing rig.
/// The 30 Hz rig samples carry an Assaulter muzzle, so the source weapon's
/// local offset replaces that muzzle after the Corner animation is sampled.
/// </summary>
internal static class CardRocketMuzzlePose
{
    // BazookaEnemy.prefab: root 443158, RPG-7_LP 472700, Spawn 496729.
    // SoldierParts.AttachWeapons resets the root scale to one, while the
    // RPG child keeps its serialized 1.4 scale.
    private static readonly Quaternion WeaponRotation = Quaternion.Normalize(
        new Quaternion(3.0908623E-08f, -.7071068f,
            -.7071068f, -3.0908623E-08f));
    private static readonly Quaternion LauncherRotation = Quaternion.Normalize(
        new Quaternion(0, 0, -.7071068f, .7071068f));
    private static readonly Vector3 SpawnLocal =
        new(-.047f, -.0015f, .0344f);

    internal static Vector3 LocalSpawnPosition => Vector3.Transform(
        Vector3.Transform(SpawnLocal * 1.4f, LauncherRotation),
        WeaponRotation);

    internal static Vector3 Place(CoopEnemyMuzzleCatalog enemyMuzzles,
        CoopAssaulterWeaponCatalog assaulterWeapon,
        CardUnitInitialPoint corner, Vector3 soldierPosition,
        Vector3 targetPosition)
    {
        ArgumentNullException.ThrowIfNull(enemyMuzzles);
        ArgumentNullException.ThrowIfNull(assaulterWeapon);
        ArgumentNullException.ThrowIfNull(corner);

        if (corner.ComponentType != "EnemyPointCorner" ||
            corner.CornerDirection is not Vector3 direction ||
            corner.CornerRightSide is not bool rightSide ||
            !PlayerHitbox.Finite(soldierPosition) ||
            !PlayerHitbox.Finite(targetPosition) ||
            !CornerShotPolicy.CanExpose(direction, rightSide,
                soldierPosition, targetPosition))
            throw new InvalidDataException(
                "Card Rocket cannot fire from this Corner.");

        Vector3 awayFromTarget = soldierPosition - targetPosition;
        awayFromTarget.Y = 0;
        if (awayFromTarget.LengthSquared() < .0001f)
            throw new InvalidDataException("Card Rocket has no firing direction.");

        // PrepareToShoot turns the soldier toward the target before its
        // 0.7-second callback. ShootFromBazoka starts this side's clip there.
        float yaw = MathF.Atan2(awayFromTarget.X, awayFromTarget.Z);
        Quaternion facing = Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw);
        string clip = rightSide ? "bazooka_shoot_right" : "bazooka_shoot_left";
        CoopMuzzlePose sampledRifle = enemyMuzzles.Place(
            clip, soldierPosition, facing, 0f);

        Vector3 localDifference = LocalSpawnPosition -
            assaulterWeapon.MuzzleRestPosition;
        Vector3 muzzle = sampledRifle.Position +
            Vector3.Transform(localDifference, sampledRifle.Rotation);
        if (!PlayerHitbox.Finite(muzzle) ||
            Vector3.Distance(muzzle, soldierPosition) > 5f)
            throw new InvalidDataException(
                "Card Rocket muzzle left the recovered soldier rig.");
        return muzzle;
    }
}

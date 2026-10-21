namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void ApplyAssaulterEntityImpact(ArmyProjectileImpact impact, PvpArmyBulletPayload launch)
    {
        ShotCollision hit = impact.Collision;
        if (hit.ColliderIndex is int collider && barrels?.Contains(collider) == true)
        {
            ApplyBarrelDamage(launch.OwnerPlayerId, impact.ProjectileId, collider,
                launch.Damage, BarrelChainCause.Shot);
        }

        if (hit.DynamicEntityId is not ulong entityKey || launch.Damage <= 0f)
        {
            return;
        }

        string owner = launch.OwnerPlayerId;
        float damage = launch.Damage;
        if (hit.DynamicGrenadierGrenade)
        {
            if (ApplyCardGrenadierShot(owner, entityKey, damage * hit.PartWeight))
            {
                var shooter = Find(owner) ?? throw new InvalidDataException("Assaulter impact lost its owner.");
                shooter.ConfirmedEnemyHits = checked(shooter.ConfirmedEnemyHits + 1);
            }
        }
        else if (hit.DynamicDecoy)
        {
            ApplyDecoyProjectileImpact(owner, entityKey, damage, hit.PartWeight, impact.ProjectileId);
        }
        else if (hit.DynamicHeavyTurret)
        {
            ApplyHeavyTurretProjectileImpact(owner, entityKey, damage, hit.PartWeight, impact.ProjectileId);
        }
        else if (hit.DynamicPassengerRole is { } role)
        {
            ApplyGroundVehiclePassengerProjectileImpact(owner, entityKey, role, damage, hit.PartWeight);
        }
        else if (hit.DynamicRepairDronePathIndex is int path)
        {
            ApplyTransporterRepairDroneProjectileImpact(owner, entityKey, path, damage, hit.PartWeight);
        }
        else if (hit.DynamicArmyInfantry)
        {
            ApplyArmyProjectileImpact(owner, entityKey, damage, hit.PartWeight);
        }
        else if (hit.DynamicHelicopterGunner)
        {
            ApplyHelicopterGunnerProjectileImpact(owner, entityKey, damage, hit.PartWeight);
        }
        else if (hit.DynamicPartId is int part)
        {
            ApplyArmyBodyProjectileImpact(owner, entityKey, part, damage);
        }
        else
        {
            throw new InvalidDataException("Assaulter dynamic impact lost its source target kind.");
        }
    }
}

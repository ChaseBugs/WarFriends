using System.Numerics;
namespace War.BattleServer;

internal readonly record struct DroneDeathBlastHit(CombatDamageType Kind,float RawDamage);

// MissileExplode gates on closest collider bounds, but interpolates using the
// destroyable owner's transform. The caller must select source-valid overlaps.
internal static class DroneDeathBlast
{
    internal static ResolvedPlayerDamage PlayerDamageInput(DroneDeathBlastHit hit,
        ExplosionSourceCatalog policy,bool overtime)
    {
        ArgumentNullException.ThrowIfNull(policy);
        if(hit.Kind is not (CombatDamageType.Explosion or CombatDamageType.Shiver)||
           !float.IsFinite(hit.RawDamage)||hit.RawDamage<0||hit.RawDamage>5000000)
            throw new InvalidDataException("Invalid Drone death player blast.");
        return new(hit.RawDamage,hit.Kind,HasWeapon:false,FriendKill:true,
            FriendlyCoefficient:policy.Friendly,ExplosiveCoefficient:policy.PlayerNormal,
            ExplosiveOvertimeCoefficient:policy.PlayerOvertime,Overtime:overtime);
    }
    internal static DroneDeathBlastHit? Resolve(DroneDeathExplosion explosion,
        float closestBoundsDistance,Vector3 destroyableRoot)
    {
        ArgumentNullException.ThrowIfNull(explosion);
        if(!PlayerHitbox.Finite(explosion.Position)||!PlayerHitbox.Finite(destroyableRoot)||
           !float.IsFinite(closestBoundsDistance)||closestBoundsDistance<0||
           !float.IsFinite(explosion.Damage)||explosion.Damage<=0||explosion.Damage>5000000||
           !float.IsFinite(explosion.SplashDamage)||explosion.SplashDamage<0||
           explosion.SplashDamage>explosion.Damage||explosion.DeadRadius!=.7f||explosion.HurtRadius!=1.4f)
            throw new InvalidDataException("Invalid Drone death blast authority.");
        if(closestBoundsDistance<explosion.DeadRadius)
            return new(CombatDamageType.Explosion,explosion.Damage);
        if(closestBoundsDistance>explosion.HurtRadius)return null;
        float fraction=Math.Clamp(1-(Vector3.Distance(destroyableRoot,explosion.Position)-
            explosion.DeadRadius)/(explosion.HurtRadius-explosion.DeadRadius),0,1);
        return new(CombatDamageType.Shiver,explosion.SplashDamage+
            (explosion.Damage-explosion.SplashDamage)*fraction*fraction);
    }
}

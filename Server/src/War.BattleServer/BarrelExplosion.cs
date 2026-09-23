using System.Numerics;

namespace War.BattleServer;

internal enum BarrelExplosionHitKind { Explode, Shiver }
internal sealed record BarrelExplosionHit(BarrelExplosionHitKind Kind,float Damage);
internal sealed record BarrelPlayerExplosion(string PartPath,BarrelExplosionHitKind Kind,
    PlayerDamageResult Result);

/// <summary>Barrel.OnDeath -> Explosion.Explode scalar damage branches.
/// Caller must first reproduce Physics.OverlapSphere and its destroyable layer/tag filter.</summary>
internal static class BarrelExplosion
{
    internal const float DeadRadius=1.1f;
    internal const float HurtRadius=1.8f;
    internal const float InnerDamage=180f;
    internal const float OuterDamage=15f;
    internal static BarrelExplosionHit Resolve(float componentDistance,float colliderDistance)
    {
        if(!float.IsFinite(componentDistance) || componentDistance<0 ||
           !float.IsFinite(colliderDistance) || colliderDistance<0)
            throw new InvalidDataException("Invalid source explosion target distance.");
        if(componentDistance<DeadRadius)
            return new(BarrelExplosionHitKind.Explode,InnerDamage);
        // OverlapSphere has already selected the collider. Its bounds can
        // overlap the radius even when its transform center lies beyond it;
        // source Shiver still applies the clamped minimum 15 damage.
        float fraction=Math.Clamp(1f-(colliderDistance-DeadRadius)/(HurtRadius-DeadRadius),0f,1f);
        return new(BarrelExplosionHitKind.Shiver,OuterDamage+(InnerDamage-OuterDamage)*(fraction*fraction));
    }
    internal static BarrelPlayerExplosion? ResolvePlayer(Vector3 center,PlayerCollisionModel currentPose,
        PlayerCombatManifest victim,float health,bool overtime,float randomRoll,ExplosionSourceCatalog policy)
    {
        if(!PlayerHitbox.Finite(center) || currentPose.Role!="gameplay" ||
           currentPose.PoseKind=="serialized-reference-only")
            throw new InvalidDataException("Explosion requires a current host player pose.");
        // Explosion.Explode enumerates OverlapSphere colliders and keeps only the
        // first part of a multi-part owner. Unity's recovered rig returns its
        // body part before its head in the pinned overlap audit.
        var part=currentPose.Parts.FirstOrDefault(p=>p.OverlapsSphere(center,HurtRadius));
        if(part==null)return null;
        float distance=Vector3.Distance(part.TransformPosition,center);
        var scalar=Resolve(distance,distance);
        var type=scalar.Kind==BarrelExplosionHitKind.Explode ? CombatDamageType.Explosion : CombatDamageType.Shiver;
        var hit=new ResolvedPlayerDamage(scalar.Damage,type,PartWeight:part.Weight,HasWeapon:false,
            ExplosiveCoefficient:policy.PlayerNormal,ExplosiveOvertimeCoefficient:policy.PlayerOvertime,
            Overtime:overtime);
        return new(part.SourcePath,scalar.Kind,PlayerDamage.Resolve(victim,health,hit,false,false,randomRoll));
    }
}

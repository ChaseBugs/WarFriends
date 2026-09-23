using System.Numerics;

namespace War.BattleServer;

internal sealed record GrenadePlayerExplosion(string PartPath,CombatDamageType Kind,float RawDamage,
    PlayerDamageResult Result);
internal sealed record GrenadeDynamicExplosion(CombatDamageType Kind,float RawDamage);

// GrenadeAmmo.CreateExplosionInfo feeds the same recovered Explosion path as a
// missile, but the effective dead/hurt radii come from the selected upgrade
// stage and its player-radius coefficient is 0.7. Geometry overlap remains at
// the full hurt radius; the coefficient affects player distance falloff.
internal static class GrenadeExplosion
{
    internal const float PlayerRadiusCoefficient=.7f;

    internal static GrenadeDynamicExplosion ResolveDynamic(Vector3 origin,MapDynamicCollider collider,
        GrenadeStage stage)
    {
        if(!PlayerHitbox.Finite(origin)||collider==null||stage==null||stage.HurtRadius<=stage.DeadRadius)
            throw new InvalidDataException("Grenade explosion requires source dynamic authority.");
        float closest=Vector3.Distance(origin,Vector3.Clamp(origin,collider.BoundsMin,collider.BoundsMax));
        if(closest<stage.DeadRadius)return new(CombatDamageType.Explosion,stage.ExplosionDamage);
        float fraction=Math.Clamp(1-(Vector3.Distance(collider.TransformPosition,origin)-stage.DeadRadius)/
            (stage.HurtRadius-stage.DeadRadius),0,1);
        return new(CombatDamageType.Shiver,
            stage.MinimumDamage+(stage.ExplosionDamage-stage.MinimumDamage)*(fraction*fraction));
    }

    internal static GrenadePlayerExplosion? ResolvePlayer(Vector3 origin,PlayerCollisionModel pose,
        Vector3 playerRoot,PlayerCombatManifest victim,float health,GrenadeStage stage,bool shieldBetween,
        bool overtime,bool sameFraction,bool self,float randomRoll)
    {
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(playerRoot)||pose==null||pose.Role!="gameplay"||
           pose.PoseKind=="serialized-reference-only"||stage==null||stage.HurtRadius<=stage.DeadRadius)
            throw new InvalidDataException("Grenade explosion requires current host authority.");
        float playerDead=stage.DeadRadius*PlayerRadiusCoefficient;
        float playerHurt=stage.HurtRadius*PlayerRadiusCoefficient;
        var parts=pose.Parts.Where(p=>p.OverlapsSphere(origin,playerHurt))
            .Select(p=>(Part:p,Distance:p.DistanceToPoint(origin))).OrderBy(x=>x.Distance)
            .ThenBy(x=>x.Part.SourcePath,StringComparer.Ordinal).ToArray();
        if(parts.Length==0)return null;
        var selected=parts[0];float multiplier=shieldBetween?stage.BehindShieldRatio:1;
        float amount;CombatDamageType kind;
        if(selected.Distance<playerDead){amount=stage.ExplosionDamage*multiplier;kind=CombatDamageType.Explosion;}
        else
        {
            float fraction=Math.Clamp(1-(Vector3.Distance(playerRoot,origin)-playerDead)/(playerHurt-playerDead),0,1);
            amount=(stage.MinimumDamage+(stage.ExplosionDamage-stage.MinimumDamage)*(fraction*fraction))*multiplier;
            kind=CombatDamageType.Shiver;
        }
        var resolved=new ResolvedPlayerDamage(amount,kind,HasWeapon:true,FriendKill:true,
            PlayerCoefficient:stage.PlayerDamageRatio,PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio,
            Overtime:overtime);
        return new(selected.Part.SourcePath,kind,amount,
            PlayerDamage.Resolve(victim,health,resolved,sameFraction,self,randomRoll));
    }
}

using System.Numerics;

namespace War.BattleServer;

internal sealed record BazookaPlayerExplosion(string PartPath,CombatDamageType Kind,float RawDamage,
    PlayerDamageResult Result);
internal sealed record BazookaDynamicExplosion(CombatDamageType Kind,float RawDamage);

internal static class BazookaExplosion
{
    internal static BazookaDynamicExplosion ResolveDynamic(Vector3 origin,MapDynamicCollider collider,
        BazookaStage stage,BazookaBinding binding,bool halfDamage)
    {
        if(!PlayerHitbox.Finite(origin)||collider==null||stage==null||binding==null)
            throw new InvalidDataException("Bazooka explosion requires source dynamic authority.");
        float closest=Vector3.Distance(origin,Vector3.Clamp(origin,collider.BoundsMin,collider.BoundsMax));
        float multiplier=halfDamage?.5f:1;
        if(closest<binding.DeadRadius)return new(CombatDamageType.Explosion,stage.ExplosionDamage*multiplier);
        float fraction=Math.Clamp(1-(Vector3.Distance(collider.TransformPosition,origin)-binding.DeadRadius)/
            (binding.HurtRadius-binding.DeadRadius),0,1);
        return new(CombatDamageType.Shiver,
            (stage.MinimumDamage+(stage.ExplosionDamage-stage.MinimumDamage)*(fraction*fraction))*multiplier);
    }
    internal static BazookaPlayerExplosion? ResolvePlayer(Vector3 origin,PlayerCollisionModel pose,Vector3 playerRoot,
        PlayerCombatManifest victim,float health,BazookaStage stage,BazookaBinding binding,bool halfDamage,
        bool shieldBetween,bool overtime,bool sameFraction,bool self,float randomRoll)
    {
        if(!PlayerHitbox.Finite(origin)||!PlayerHitbox.Finite(playerRoot)||pose==null||pose.Role!="gameplay"||
           pose.PoseKind=="serialized-reference-only"||stage==null||binding==null)
            throw new InvalidDataException("Bazooka explosion requires current host authority.");
        var parts=pose.Parts.Where(p=>p.OverlapsSphere(origin,binding.HurtRadius))
            .Select(p=>(Part:p,Distance:p.DistanceToPoint(origin))).OrderBy(x=>x.Distance)
            .ThenBy(x=>x.Part.SourcePath,StringComparer.Ordinal).ToArray();
        if(parts.Length==0)return null;
        var selected=parts[0];float multiplier=(shieldBetween?binding.BehindShieldRatio:1)*(halfDamage?.5f:1);
        float amount;CombatDamageType kind;
        if(selected.Distance<binding.DeadRadius){amount=stage.ExplosionDamage*multiplier;kind=CombatDamageType.Explosion;}
        else
        {
            float fraction=Math.Clamp(1-(Vector3.Distance(playerRoot,origin)-binding.DeadRadius)/(binding.HurtRadius-binding.DeadRadius),0,1);
            amount=(stage.MinimumDamage+(stage.ExplosionDamage-stage.MinimumDamage)*(fraction*fraction))*multiplier;kind=CombatDamageType.Shiver;
        }
        var resolved=new ResolvedPlayerDamage(amount,kind,HasWeapon:true,FriendKill:true,
            PlayerCoefficient:stage.PlayerDamageRatio,PlayerOvertimeCoefficient:stage.OvertimePlayerDamageRatio,Overtime:overtime);
        return new(selected.Part.SourcePath,kind,amount,PlayerDamage.Resolve(victim,health,resolved,sameFraction,self,randomRoll));
    }
}

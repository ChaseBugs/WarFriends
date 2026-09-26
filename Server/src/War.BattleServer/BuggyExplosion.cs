using System.Numerics;

namespace War.BattleServer;

internal sealed record BuggyPlayerExplosion(string PartPath,CombatDamageType Kind,float RawDamage,
    PlayerDamageResult Result);
internal sealed record BuggyDynamicExplosion(CombatDamageType Kind,float RawDamage);

/// <summary>Recovered MissileExplode falloff for AICarBuggy's paired cannon missiles.</summary>
internal static class BuggyExplosion
{
    internal static BuggyDynamicExplosion ResolveDynamic(Vector3 origin,MapDynamicCollider collider,
        float explosionDamage,GroundVehicleMissileBinding binding)
    {
        Validate(origin,explosionDamage,binding);
        ArgumentNullException.ThrowIfNull(collider);
        float closest=Vector3.Distance(origin,Vector3.Clamp(origin,collider.BoundsMin,collider.BoundsMax));
        if(closest<binding.DeadRadius)return new(CombatDamageType.Explosion,explosionDamage);
        float fraction=Math.Clamp(1-(Vector3.Distance(collider.TransformPosition,origin)-binding.DeadRadius)/
            (binding.HurtRadius-binding.DeadRadius),0,1);
        return new(CombatDamageType.Shiver,binding.MinimumDamage+
            (explosionDamage-binding.MinimumDamage)*(fraction*fraction));
    }

    internal static BuggyPlayerExplosion? ResolvePlayer(Vector3 origin,PlayerCollisionModel pose,
        Vector3 playerRoot,PlayerCombatManifest victim,float health,float explosionDamage,
        GroundVehicleMissileBinding binding,ArmyPlayerDamagePolicy policy,bool shieldBetween,bool overtime,
        bool sameFraction,bool self,float randomRoll)
    {
        Validate(origin,explosionDamage,binding);
        if(!PlayerHitbox.Finite(playerRoot)||pose==null||pose.Role!="gameplay"||
           pose.PoseKind=="serialized-reference-only"||policy==null)
            throw new InvalidDataException("Buggy explosion requires current host authority.");
        var parts=pose.Parts.Where(p=>p.OverlapsSphere(origin,binding.HurtRadius))
            .Select(p=>(Part:p,Distance:p.DistanceToPoint(origin))).OrderBy(x=>x.Distance)
            .ThenBy(x=>x.Part.SourcePath,StringComparer.Ordinal).ToArray();
        if(parts.Length==0)return null;
        var selected=parts[0];float multiplier=shieldBetween?policy.BehindShieldRatio:1;
        float amount;CombatDamageType kind;
        if(selected.Distance<binding.DeadRadius)
        {amount=explosionDamage*multiplier;kind=CombatDamageType.Explosion;}
        else
        {
            float fraction=Math.Clamp(1-(Vector3.Distance(playerRoot,origin)-binding.DeadRadius)/
                (binding.HurtRadius-binding.DeadRadius),0,1);
            amount=(binding.MinimumDamage+(explosionDamage-binding.MinimumDamage)*fraction*fraction)*multiplier;
            kind=CombatDamageType.Shiver;
        }
        var resolved=new ResolvedPlayerDamage(amount,kind,HasWeapon:true,FriendKill:true,
            PlayerCoefficient:policy.PlayerDamageRatio,
            PlayerOvertimeCoefficient:policy.OvertimePlayerDamageRatio,Overtime:overtime);
        return new(selected.Part.SourcePath,kind,amount,
            PlayerDamage.Resolve(victim,health,resolved,sameFraction,self,randomRoll));
    }

    private static void Validate(Vector3 origin,float damage,GroundVehicleMissileBinding binding)
    {
        if(!PlayerHitbox.Finite(origin)||!float.IsFinite(damage)||damage<=0||damage>10_000_000||
           binding==null||binding.DeadRadius<=0||binding.HurtRadius<=binding.DeadRadius||
           !float.IsFinite(binding.MinimumDamage)||binding.MinimumDamage<0||binding.MinimumDamage>damage)
            throw new InvalidDataException("Buggy explosion requires source damage authority.");
    }
}

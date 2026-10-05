using System.Numerics;

namespace War.BattleServer;

internal sealed record LandMinePlayerExplosion(string PartPath,CombatDamageType Kind,float RawDamage);
internal sealed record LandMineDynamicExplosion(CombatDamageType Kind,float RawDamage);

internal static class LandMineExplosion
{
    internal static LandMineDynamicExplosion ResolveDynamic(Vector3 origin,float damage,
        LandMineSourceCatalog source,MapDynamicCollider collider)
    {
        if(!PlayerHitbox.Finite(origin)||!float.IsFinite(damage)||damage<=0||damage>10_000_000||
           source==null||collider==null||source.HurtRadius<=source.DeadRadius||
           !PlayerHitbox.Finite(collider.TransformPosition)||!PlayerHitbox.Finite(collider.BoundsMin)||
           !PlayerHitbox.Finite(collider.BoundsMax))
            throw new InvalidDataException("Land Mine dynamic explosion requires source authority.");
        float closest=Vector3.Distance(origin,Vector3.Clamp(origin,collider.BoundsMin,collider.BoundsMax));
        if(closest<source.DeadRadius)return new(CombatDamageType.Explosion,damage);
        // The recovered card writes equal damageAmount and explodeDamageAmount.
        // MissileExplode still takes its outer Shiver branch, but its falloff
        // interpolates between those equal values.
        return new(CombatDamageType.Shiver,damage);
    }
    internal static bool Triggered(Vector3 minePosition,LandMinePrefabSource prefab,PlayerCollisionModel pose)
    {
        if(!PlayerHitbox.Finite(minePosition)||prefab==null||pose==null||pose.Role!="gameplay"||
           pose.PoseKind=="serialized-reference-only")throw new InvalidDataException("Land Mine trigger requires current host authority.");
        return Triggered(minePosition,prefab,pose.Parts);
    }
    internal static bool Triggered(Vector3 minePosition,LandMinePrefabSource prefab,IReadOnlyList<PlayerHitbox> parts)
    {
        if(!PlayerHitbox.Finite(minePosition)||prefab==null||parts==null||parts.Count is <1 or >64)
            throw new InvalidDataException("Land Mine trigger requires current host authority.");
        var center=minePosition+prefab.TriggerCenter;
        return parts.Any(part=>part.OverlapsBox(center,prefab.TriggerSize,Quaternion.Identity));
    }

    internal static LandMinePlayerExplosion? Resolve(Vector3 minePosition,float damage,
        LandMineSourceCatalog source,PlayerCollisionModel pose,Vector3 root)
    {
        if(!PlayerHitbox.Finite(minePosition)||!PlayerHitbox.Finite(root)||!float.IsFinite(damage)||
           damage<=0||damage>10_000_000||source==null||pose==null||pose.Role!="gameplay"||
           pose.PoseKind=="serialized-reference-only")throw new InvalidDataException("Land Mine explosion requires current host authority.");
        return Resolve(minePosition,damage,source,pose.Parts,root);
    }
    internal static LandMinePlayerExplosion? Resolve(Vector3 minePosition,float damage,
        LandMineSourceCatalog source,IReadOnlyList<PlayerHitbox> parts,Vector3 root)
    {
        if(!PlayerHitbox.Finite(minePosition)||!PlayerHitbox.Finite(root)||!float.IsFinite(damage)||
           damage<=0||damage>10_000_000||source==null||parts==null||parts.Count is <1 or >64)
            throw new InvalidDataException("Land Mine explosion requires current host authority.");
        float dead=source.DeadRadius*source.PlayerRadiusCoefficient;
        float hurt=source.HurtRadius*source.PlayerRadiusCoefficient;
        var selected=parts.Where(part=>part.OverlapsSphere(minePosition,hurt))
            .Select(part=>(Part:part,Distance:part.DistanceToPoint(minePosition)))
            .OrderBy(x=>x.Distance).ThenBy(x=>x.Part.SourcePath,StringComparer.Ordinal).FirstOrDefault();
        if(selected.Part==null)return null;
        // CardLandmine writes the same value to damageAmount and
        // explodeDamageAmount, so the source falloff preserves that value.
        var kind=selected.Distance<dead?CombatDamageType.Explosion:CombatDamageType.Shiver;
        return new(selected.Part.SourcePath,kind,damage);
    }
}

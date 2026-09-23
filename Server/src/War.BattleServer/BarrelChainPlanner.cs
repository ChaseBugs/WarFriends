using System.Numerics;

namespace War.BattleServer;

internal enum BarrelChainCause { Shot, Explosion, Shiver }
internal sealed record BarrelChainTransition(int ColliderIndex,float Health,bool Destroyed,
    BarrelChainCause Cause,int? SourceBarrelIndex);
internal sealed record BarrelOtherTarget(int ColliderIndex,float Damage,BarrelChainCause Cause,int SourceBarrelIndex);
internal sealed record BarrelChainEffect(int ColliderIndex,float Damage,BarrelChainCause Cause,
    int? SourceBarrelIndex,float? Health,bool Destroyed);
internal sealed record BarrelChainPlan(IReadOnlyList<BarrelChainTransition> Barrels,
    IReadOnlyList<BarrelOtherTarget> OtherTargets,IReadOnlyList<BarrelChainEffect> OrderedEffects);

/// <summary>Previews the synchronous Barrel.OnDeath -> Explosion.Explode chain.
/// No state is published until every affected target family can be applied.</summary>
internal static class BarrelChainPlanner
{
    internal static BarrelChainPlan Plan(RecoveredBattleMap map,BarrelOverlapOrderCatalog overlaps,
        IReadOnlyList<BarrelMutation> current,int shotColliderIndex,float shotDamage,
        BarrelChainCause initialCause=BarrelChainCause.Shot)
    {
        if(!float.IsFinite(shotDamage) || shotDamage<=0 || shotDamage>1_000_000)
            throw new InvalidDataException("Invalid confirmed barrel shot damage.");
        if(current==null || current.Count is <1 or >29)
            throw new InvalidDataException("Invalid barrel chain state count.");
        var states=new Dictionary<int,BarrelMutation>();
        foreach(var row in current)
            if(row==null || !states.TryAdd(row.ColliderIndex,row))
                throw new InvalidDataException("Duplicate/null barrel chain state.");
        var expected=map.DynamicColliders.Where(c=>c.DynamicOwner.Split('/').Last()
            .StartsWith("barrel",StringComparison.OrdinalIgnoreCase))
            .Select(c=>c.ColliderIndex).ToHashSet();
        if(!states.ContainsKey(shotColliderIndex) ||
           !expected.SetEquals(states.Keys) ||
           current.Any(row=>!float.IsFinite(row.Health) || !float.IsFinite(row.MaxHealth) ||
               row.MaxHealth is <50 or >56 || row.Health>row.MaxHealth ||
               row.MaxHealth!=current[0].MaxHealth || row.Destroyed!=(row.Health<=0) ||
               row.Revision>uint.MaxValue-1024))
            throw new InvalidDataException("Invalid barrel chain starting authority.");
        var colliders=map.DynamicColliders.ToDictionary(row=>row.ColliderIndex);
        var mutations=new List<BarrelChainTransition>();
        var other=new List<BarrelOtherTarget>();
        var ordered=new List<BarrelChainEffect>();
        void Apply(int index,float amount,BarrelChainCause cause,int? origin,int depth)
        {
            if(depth>states.Count || ordered.Count>=1024)
                throw new InvalidDataException("Barrel chain exceeds source entity bound.");
            var before=states[index];
            if(before.Destroyed)return;
            float after=before.Health-amount;
            if(!float.IsFinite(after))throw new InvalidDataException("Barrel chain damage overflow.");
            bool destroyed=after<=0;
            states[index]=before with {Health=after,Destroyed=destroyed,Revision=checked(before.Revision+1)};
            mutations.Add(new(index,after,destroyed,cause,origin));
            ordered.Add(new(index,amount,cause,origin,after,destroyed));
            if(!destroyed)return;
            var center=colliders[index].TransformPosition;
            foreach(int target in overlaps.Targets(map,index))
            {
                if(!colliders.TryGetValue(target,out var collider))
                    throw new InvalidDataException("Barrel explosion target has no source collider.");
                float distance=Vector3.Distance(center,collider.TransformPosition);
                var hit=BarrelExplosion.Resolve(distance,distance);
                var kind=hit.Kind==BarrelExplosionHitKind.Explode ?
                    BarrelChainCause.Explosion:BarrelChainCause.Shiver;
                if(states.ContainsKey(target))Apply(target,hit.Damage,kind,index,depth+1);
                else
                {
                    // The sole nonbarrel hit in the pinned source-center audit is
                    // City's 1E+10-float-HP crane beam. Both source blast amounts
                    // are below one float ULP here, so its durable HP is unchanged.
                    // A newly selected environmental target needs its own lifecycle.
                    if(!map.Source.EndsWith("/City_Multiplayer.unity",StringComparison.Ordinal) ||
                       !collider.SourcePath.EndsWith("/beam",StringComparison.Ordinal) ||
                       1e10f-hit.Damage!=1e10f)
                        throw new InvalidDataException("Unmodeled barrel explosion target lifecycle.");
                    other.Add(new(target,hit.Damage,kind,index));
                    ordered.Add(new(target,hit.Damage,kind,index,null,false));
                }
            }
        }
        if(initialCause is not (BarrelChainCause.Shot or BarrelChainCause.Explosion or BarrelChainCause.Shiver))
            throw new InvalidDataException("Invalid initial barrel damage cause.");
        Apply(shotColliderIndex,shotDamage,initialCause,null,0);
        return new(Array.AsReadOnly(mutations.ToArray()),Array.AsReadOnly(other.ToArray()),
            Array.AsReadOnly(ordered.ToArray()));
    }
}

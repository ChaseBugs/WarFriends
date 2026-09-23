using System.Numerics;

namespace War.BattleServer;

internal sealed record BarrelExplosionPlayerState(string PlayerId,PlayerCollisionModel Pose,
    PlayerCombatManifest Combat,float Health,bool Dead);
internal sealed record BarrelExplosionPlayerEffect(int AfterEffectIndex,int SourceBarrelIndex,string PlayerId,
    string PartPath,BarrelExplosionHitKind Kind,PlayerDamageResult Damage);

/// <summary>Projects moving-player damage from every barrel death in a source-order chain.
/// The match can validate the whole result before committing any mutation.</summary>
internal static class BarrelPlayerChainResolver
{
    internal static IReadOnlyList<BarrelExplosionPlayerEffect> Resolve(RecoveredBattleMap map,
        BarrelChainPlan chain,IReadOnlyList<BarrelExplosionPlayerState> players,
        ExplosionSourceCatalog policy,Func<float> roll,bool overtime=false)
    {
        ArgumentNullException.ThrowIfNull(map);
        ArgumentNullException.ThrowIfNull(chain);
        ArgumentNullException.ThrowIfNull(policy);
        ArgumentNullException.ThrowIfNull(roll);
        if(players==null || players.Count!=2 ||
           players.Any(p=>p==null || !Guid.TryParseExact(p.PlayerId,"N",out _) ||
               p.PlayerId!=p.PlayerId.ToLowerInvariant() || p.Pose==null ||
               p.Pose.Role!="gameplay" || p.Pose.PoseKind=="serialized-reference-only" ||
               p.Combat==null || !float.IsFinite(p.Health) ||
               p.Health>p.Combat.MaxHealth || p.Dead!=(p.Health<=0)) ||
           players[0].PlayerId==players[1].PlayerId)
            throw new InvalidDataException("Invalid explosion player authority.");
        foreach(var player in players)PlayerDamage.Validate(player.Combat);
        var colliders=map.DynamicColliders.ToDictionary(c=>c.ColliderIndex);
        var health=players.ToDictionary(p=>p.PlayerId,p=>p.Health,StringComparer.Ordinal);
        var output=new List<BarrelExplosionPlayerEffect>();
        for(int stepIndex=0;stepIndex<chain.OrderedEffects.Count;stepIndex++)
        {
            var step=chain.OrderedEffects[stepIndex];
            if(!step.Health.HasValue || !step.Destroyed)continue;
            if(!colliders.TryGetValue(step.ColliderIndex,out var barrel) ||
               !barrel.DynamicOwner.Split('/').Last().StartsWith("barrel",StringComparison.OrdinalIgnoreCase))
                throw new InvalidDataException("Explosion has no source barrel origin.");
            Vector3 center=barrel.TransformPosition;
            // Stable roster order is the replacement host's explicit tie break
            // for moving-player colliders, whose Unity broadphase order can vary.
            foreach(var player in players)
            {
                float before=health[player.PlayerId];
                if(before<=0)continue;
                if(!player.Pose.Parts.Any(part=>part.OverlapsSphere(center,BarrelExplosion.HurtRadius)))
                    continue;
                var hit=BarrelExplosion.ResolvePlayer(center,player.Pose,player.Combat,
                    before,overtime,roll(),policy);
                if(hit==null)throw new InvalidDataException("Explosion player overlap changed during projection.");
                health[player.PlayerId]=hit.Result.Health;
                output.Add(new(stepIndex,step.ColliderIndex,player.PlayerId,hit.PartPath,hit.Kind,hit.Result));
                if(output.Count>58)throw new InvalidDataException("Explosion player effects exceed source bound.");
            }
        }
        return Array.AsReadOnly(output.ToArray());
    }
}

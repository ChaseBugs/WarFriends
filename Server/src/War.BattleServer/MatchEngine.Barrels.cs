using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void ApplyBarrelImpact(BulletImpact impact,float confirmedDamage)
    {
        if(barrels==null || map==null || rifleCombat==null || explosionPolicy==null || damageRoll==null ||
           impact.Hit.ColliderIndex is not int origin || !barrels.Contains(origin))
            return;
        ApplyBarrelDamage(impact.OwnerId,impact.ProjectileId,origin,confirmedDamage,BarrelChainCause.Shot);
    }
    private void ApplyBarrelDamage(string ownerId,ulong projectileId,int origin,float confirmedDamage,BarrelChainCause cause)
    {
        if(barrels==null || map==null || (rifleCombat==null&&grenadeCombat==null) || explosionPolicy==null || damageRoll==null || !barrels.Contains(origin))return;
        if(!float.IsFinite(confirmedDamage) || confirmedDamage<0)
            throw new InvalidDataException("Invalid barrel projectile damage.");
        if(confirmedDamage==0)return;
        var chain=barrels.PreviewDamageChain(origin,confirmedDamage,cause);
        if(chain.OrderedEffects.Count==0)return; // A flight cached before another blast removed it.
        var current=players.Select(p=>new BarrelExplosionPlayerState(p.Definition.PlayerId,
            rifleCombat?.Pose(p.Definition.PlayerId).Collision??grenadeCombat!.Collision(p.Definition.PlayerId),
            p.Definition.Combat!,p.Health,p.Dead)).ToArray();
        var playerEffects=BarrelPlayerChainResolver.Resolve(map,chain,current,explosionPolicy,damageRoll,overtime);
        int deaths=playerEffects.Count(x=>x.Damage.Dead);
        if(events.Count+chain.Barrels.Count+playerEffects.Count+deaths+1>MaximumRetainedEvents ||
           players.Any(p=>p.DamageRevision>ulong.MaxValue-(ulong)playerEffects.Count))
            throw new InvalidDataException("Barrel explosion exceeded reserved event authority.");
        var scene=map.DynamicColliders.ToDictionary(c=>c.ColliderIndex);
        var bindings=barrels.Snapshot().ToDictionary(b=>b.ColliderIndex);
        var eventRevisions=bindings.ToDictionary(x=>x.Key,x=>x.Value.Revision);
        // Validate every emitted position and source identity before the first write.
        foreach(var effect in chain.OrderedEffects.Where(x=>x.Health.HasValue))
            if(!scene.TryGetValue(effect.ColliderIndex,out var shape) ||
               !PlayerHitbox.Finite(shape.TransformPosition) ||
               !bindings.ContainsKey(effect.ColliderIndex))
                throw new InvalidDataException("Barrel event has no source scene object.");
        foreach(var effect in playerEffects)
            if(Find(effect.PlayerId)==null || !PlayerHitbox.Finite(scene[effect.SourceBarrelIndex].TransformPosition))
                throw new InvalidDataException("Explosion player event has no source origin.");
        barrels.CommitPlannedChain(origin,confirmedDamage,chain,cause);
        int cursor=0;
        for(int index=0;index<chain.OrderedEffects.Count;index++)
        {
            var effect=chain.OrderedEffects[index];
            if(effect.Health.HasValue)
            {
                stateRevision++;
                uint revision=++eventRevisions[effect.ColliderIndex];
                EmitBarrel(effect.Destroyed?MatchEventKind.BarrelDestroyed:MatchEventKind.BarrelDamaged,
                    ownerId,projectileId,effect,bindings[effect.ColliderIndex].GameObjectFileId,revision,
                    scene[effect.ColliderIndex].TransformPosition);
            }
            while(cursor<playerEffects.Count && playerEffects[cursor].AfterEffectIndex==index)
            {
                var hit=playerEffects[cursor++];
                var victim=Find(hit.PlayerId)!;
                victim.Health=hit.Damage.Health;
                victim.Dead=hit.Damage.Dead;
                victim.DamageRevision++;
                stateRevision++;
                Vector3 center=scene[hit.SourceBarrelIndex].TransformPosition;
                Emit(MatchEventKind.PlayerExplosionDamaged,"",victim.Definition.PlayerId,
                    projectileId,center,victim.Health,hit.Kind.ToString().ToLowerInvariant());
                events[^1].BarrelColliderIndex=hit.SourceBarrelIndex;
                events[^1].BarrelGameObjectFileId=bindings[hit.SourceBarrelIndex].GameObjectFileId;
                if(hit.Damage.Dead)
                {
                    victim.Route=null;victim.ReloadEnd=0;
                    Emit(MatchEventKind.PlayerDeath,"",victim.Definition.PlayerId,0,
                        victim.Position,victim.Health,"barrel-explosion");
                }
            }
        }
        if(players.All(p=>p.Dead))End("simultaneous-barrel-death","",false);
        else if(players.Any(p=>p.Dead))
            End("player-killed",players.Single(p=>!p.Dead).Definition.PlayerId,true);
    }
}

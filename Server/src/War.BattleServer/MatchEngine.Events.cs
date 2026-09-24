using System.Numerics;
using War.Protocol;
using War.Protocol.Transport;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const int MaximumRetainedEvents=512;
    private const int EventBatchSize=4;
    private readonly List<MatchEvent> events=[];
    private ulong lastEventId;

    // Each outstanding projectile may still create an impact and a death.
    // Reserve one more entry for the terminal marker before accepting a shot.
    private int PendingPoisonPulseCount=>armyPoisons.Values.Sum(x=>x.Remaining);
    private bool EventCapacityForShot(int newProjectiles=1,int additionalEvents=0) =>
        newProjectiles is >0 and <=8 && additionalEvents is >=0 and <=40 &&
        events.Count+players.Sum(p=>p.Army?.PendingCount??0)+
        PendingPoisonPulseCount+additionalEvents+
        (barrels?.MaximumEventsPerProjectile??2)*PendingProjectileCount+
        (barrels?.MaximumEventsPerProjectile??3)*newProjectiles+
        (shields==null?3:12)<=MaximumRetainedEvents;

    private bool EventCapacityForArmy(int count)=>count is >0 and <=8 &&
        events.Count+players.Sum(p=>p.Army?.PendingCount??0)+PendingPoisonPulseCount+count+
        (barrels?.MaximumEventsPerProjectile??2)*PendingProjectileCount+12<=MaximumRetainedEvents;

    private bool EventCapacityForArmyDeath()=>
        events.Count+players.Sum(p=>p.Army?.PendingCount??0)+PendingPoisonPulseCount+1+
        (barrels?.MaximumEventsPerProjectile??2)*PendingProjectileCount+12<=MaximumRetainedEvents;

    private void Emit(MatchEventKind kind,string actor,string target,ulong projectile,Vector3 position,float health,string reason)
    {
        if(events.Count>=MaximumRetainedEvents || !PlayerHitbox.Finite(position) || !float.IsFinite(health))
            throw new InvalidDataException("Battle event authority exceeded its bound.");
        events.Add(new MatchEvent {EventId=++lastEventId,Tick=tick,Kind=kind,
            ActorId=actor,TargetId=target,ProjectileId=projectile,
            X=position.X,Y=position.Y,Z=position.Z,Health=health,Reason=reason});
    }
    private void EmitShield(MatchEventKind kind,string actor,ShieldMutation shield,ulong projectile)
    {
        if(map==null || shield.CoverIndex<0 || shield.CoverIndex>=map.Covers.Count)
            throw new InvalidDataException("Unknown shield event cover.");
        string target=players.Single(p=>p.Definition.Fraction==shield.OwnerFraction).Definition.PlayerId;
        Emit(kind,actor,target,projectile,map.Covers[shield.CoverIndex].Position,shield.Health,"");
        events[^1].ShieldCoverIndex=shield.CoverIndex;
    }
    private void EmitBarrel(MatchEventKind kind,string actor,ulong projectile,
        BarrelChainEffect effect,int gameObjectFileId,uint revision,Vector3 position)
    {
        Emit(kind,actor,"",projectile,position,effect.Health!.Value,
            effect.Cause.ToString().ToLowerInvariant());
        var row=events[^1];
        row.BarrelColliderIndex=effect.ColliderIndex;
        row.BarrelGameObjectFileId=gameObjectFileId;
        row.SourceBarrelColliderIndex=effect.SourceBarrelIndex??-1;
        row.BarrelRevision=revision;
    }

    public MatchEventBatch EventBatch(string playerId,ulong after)
    {
        var batch=new MatchEventBatch {MatchId=MatchId,ManifestHash=ManifestHash,LatestEventId=lastEventId};
        var player=Find(playerId);
        if(player==null || !player.Admitted || after>lastEventId)
        { batch.Code="invalid-cursor";return batch; }
        ulong first=events.Count==0 ? lastEventId+1 : events[0].EventId;
        if(after<first-1)
        { batch.Code="cursor-expired";return batch; }
        if(after>player.EventAck)player.EventAck=after;
        ulong evict=players.Min(p=>p.EventAck);
        int count=0;
        while(count<events.Count && events[count].EventId<=evict)count++;
        if(count>0)events.RemoveRange(0,count);
        batch.Code="events";
        AppendFittingEvents(batch,events.Where(e=>e.EventId>after));
        player.LastSeen=hostTick;
        return batch;
    }

    internal static void AppendFittingEvents(MatchEventBatch batch,IEnumerable<MatchEvent> pending)
    {
        foreach(var row in pending.Take(EventBatchSize))
        {
            batch.Events.Add(row.Clone());
            var worstEnvelope=new Packet {Version=1,SessionId=ulong.MaxValue,
                Sequence=ulong.MaxValue,Ack=ulong.MaxValue,AckBits=uint.MaxValue,
                MatchEventBatch=batch};
            if(worstEnvelope.CalculateSize()+PacketCodec.MacBytes<=PacketCodec.MaximumDatagramBytes)
                continue;
            batch.Events.RemoveAt(batch.Events.Count-1);
            if(batch.Events.Count==0)throw new InvalidDataException("One combat event exceeds the UDP MTU.");
            break;
        }
    }
}

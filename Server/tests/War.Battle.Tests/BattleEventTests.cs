using System.Numerics;
using War.BattleServer;
using War.Protocol;

internal static class BattleEventTests
{
    internal static int Run()
    {
        int checks=0;
        void Check(bool ok,string label){if(!ok)throw new Exception(label);checks++;}
        string a=new string('a',32),b=new string('b',32),hash=new string('a',64);
        var weapon=new WeaponManifest("event-fixture",1000,0,.01,.1);
        var manifest=new MatchManifest("event-capacity","local-1","fixture",hash,hash,
            MatchManifest.PrototypeMode,10,60,120,
            [new(a,weapon,1,-1,0,new(100)),new(b,weapon,2,-1,0,new(100))]);
        var match=new MatchEngine(manifest);
        match.ConfigureProjectiles((id,owner,target,tick)=>new(
            new BulletFlight(id,owner,new(10000,1,true),Vector3.Zero,target,tick,(o,d,r)=>null),
            new ResolvedPlayerDamage(1,CombatDamageType.Shot)),()=>1);
        match.Admit(a);match.Admit(b);
        match.Command(a,new() {CommandId=1,Ready=new() {ManifestHash=match.ManifestHash}});
        match.Command(b,new() {CommandId=1,Ready=new() {ManifestHash=match.ManifestHash}});
        match.Advance(60);
        ulong command=2,tick=60;int accepted=0,ammo;
        while(true)
        {
            ammo=match.Snapshot().Players[0].ClipAmmo;
            var reply=match.Command(a,new() {CommandId=command++,Fire=new() {TargetX=1}});
            if(reply.Code=="event-backpressure")
            {
                Check(reply.Snapshot.Players[0].ClipAmmo==ammo && reply.Snapshot.Players[0].ShotsFired==(ulong)accepted,
                    "event capacity rejects before ammunition or shot publication");
                break;
            }
            Check(reply.Code=="shot-accepted","bounded fixture shot accepted before event limit");
            accepted++;
            if(accepted>512)throw new Exception("Event limit did not apply.");
            match.Advance(++tick);
        }
        Check(accepted>=500 && match.EventBatch(a,0).LatestEventId==(ulong)accepted,
            "event log backpressure preserves the full acknowledged prefix");
        ulong cursorA=0,cursorB=0;
        foreach(string player in new[] {a,b})
        {
            ulong cursor=0;
            for(int page=0;page<256;page++)
            {
                var batch=match.EventBatch(player,cursor);
                Check(batch.Code=="events" && batch.Events.Count<=4,"bounded event drain");
                if(batch.Events.Count==0)break;
                foreach(var row in batch.Events)
                {Check(row.EventId==++cursor && row.Kind==MatchEventKind.Shot,"ordered retained shot event");}
            }
            if(player==a)cursorA=cursor;else cursorB=cursor;
        }
        Check(cursorA==(ulong)accepted && cursorB==cursorA && match.EventBatch(a,0).Code=="cursor-expired",
            "both cursors release history without silently accepting a stale reconnect");
        var resumed=match.Command(a,new() {CommandId=command,Fire=new() {TargetX=1}});
        Check(resumed.Code=="shot-accepted" && resumed.Snapshot.Players[0].ClipAmmo==ammo-1,
            "both acknowledgements restore bounded shot capacity");
        return checks;
    }
}

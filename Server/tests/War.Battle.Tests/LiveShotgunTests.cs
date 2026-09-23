using System.Numerics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Client;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;

internal static class LiveShotgunTests
{
    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            Path.Combine(directory,"shotgun-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var left=map.Covers.First(c=>c.Main&&c.Fraction==1);
        var right=map.Covers.First(c=>c.Main&&c.Fraction==2);
        string one=new('a',32),two=new('b',32);
        var weapon=content.Shotguns!.CreateManifest("Google2u.Shotgun_SPAS",35);
        var manifest=new MatchManifest("shotgun-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.ShotgunRevision!,MatchManifest.ShotgunCombatMode,10,60,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1000),35,0),new(two,weapon,2,right.SourceIndex,1,new(1000),35,0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-shotgun-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-shotgun-outbox-"+Guid.NewGuid().ToString("N")),
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:ShotgunContentManifestPath"]=Path.Combine(directory,"shotgun-content-manifest.json")
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,
                MatchId=admission.MatchId,ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        Vector3 Head(CoverNode from,CoverNode other)
        {
            var direction=other.Position-from.Position;direction.Y=0;
            var aim=new PlayerAimState();aim.LookAt(direction,from.Rotation,0);
            aim.Advance(.1,.1f,from.Rotation);
            bool rightSide=Vector3.Dot(Vector3.UnitY,Vector3.Cross(
                Vector3.Transform(Vector3.UnitZ,from.Rotation),direction))>0;
            return content.Poses.SampleAimed(rightSide?"player_fire_right_shotgun":"player_fire_left_shotgun",
                .15,false,aim.BodyRotation,null).Place(from.Position,from.Rotation).Collision.Parts[1].Center;
        }
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(25));
            using var a=new MatchConnection(Grant(one,911));using var b=new MatchConnection(Grant(two,912));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted" &&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted","shotgun UDP peers admitted by signed grants");
            var absentBarrels=await a.PollBarrelsAsync(timeout.Token);
            Check(absentBarrels.SourceCount==0 && absentBarrels.Changed.Count==0 &&
                  absentBarrels.MatchId==manifest.MatchId &&
                  absentBarrels.ManifestHash==manifest.Digest(),
                  "authenticated barrel poll reports no unsigned scene-master authority");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply reply;
            do{await Task.Delay(100,timeout.Token);reply=await a.PollAsync(timeout.Token);}
            while(reply.Snapshot.Phase!=BattlePhase.Running);
            Check(reply.Snapshot.Shields.Count==8 && reply.Snapshot.Shields.All(s=>s.MaxHealth==560),
                "signed shotgun UDP allocation exposes rank-authored shields");
            var targetA=Head(right,left);var targetB=Head(left,right);
            var idleHead=content.Poses.SampleBlended("idle",0,true,"idle",0,true,0)
                .Place(right.Position,right.Rotation).Collision.Parts[1].Center;
            reply=await a.FireAsync(idleHead.X,idleHead.Y,idleHead.Z,timeout.Token);
            Check(reply.Code=="shot-scheduled","shotgun UDP click follows cover delay");
            for(int i=0;i<15;i++)
            {
                await Task.Delay(100,timeout.Token);
                reply=await a.PollAsync(timeout.Token);
                if(reply.Snapshot.Players[0].ShotsFired>0)break;
            }
            Check(reply.Snapshot.Players[0].ShotsFired==1 && reply.Snapshot.Players[0].ClipAmmo==weapon.ClipSize-1,
                "shotgun UDP volley consumes one shell");
            for(int i=0;i<15 && reply.Snapshot.Shields[right.SourceIndex].Revision==0;i++)
            {await Task.Delay(100,timeout.Token);reply=await a.PollAsync(timeout.Token);}
            Check(reply.Snapshot.Shields[right.SourceIndex].Revision>0 &&
                  reply.Snapshot.Shields[right.SourceIndex].Health<560,
                  "first UDP volley damages the idle defender shield: "+reply.Snapshot);
            for(int attempt=0;attempt<24 && reply.Snapshot.Players.All(p=>p.Health==1000);attempt++)
            {
                await b.FireAsync(targetB.X,targetB.Y,targetB.Z,timeout.Token);
                await Task.Delay(240,timeout.Token);
                reply=await a.FireAsync(targetA.X,targetA.Y,targetA.Z,timeout.Token);
            }
            Check(reply.Snapshot.Players.Any(p=>p.Health<1000) &&
                  reply.Snapshot.Players.Any(p=>p.ConfirmedPlayerHits>0),
                  "shotgun UDP impact changes authoritative health and hit credit");
            Check(reply.Snapshot.Shields.Any(s=>s.Revision>0),
                  "shotgun UDP snapshot includes confirmed shield damage");
            Check(reply.Snapshot.Players.All(p=>p.ConfirmedEnemyHits>=p.ConfirmedPlayerHits && p.ConfirmedEnemyHits<=(ulong)p.ShotsFired*8),
                  "shotgun UDP enemy-hit credit is bounded by host-fired projectiles");
            Check(reply.Snapshot.Players.All(p=>p.RiflePose!=null && p.RiflePose.Layers.Count>0),
                  "shotgun UDP peers receive source animation poses");
            async Task<List<MatchEvent>> ThroughImpact(MatchConnection peer)
            {
                var received=new List<MatchEvent>();ulong cursor=0;
                for(int page=0;page<128;page++)
                {
                    var batch=await peer.PollEventsAsync(cursor,timeout.Token);
                    Check(batch.Code=="events" && batch.Events.Count<=4,"shotgun UDP event page bounded");
                    foreach(var row in batch.Events)
                    {Check(row.EventId==cursor+1,"shotgun UDP event IDs contiguous");cursor=row.EventId;received.Add(row);}
                    if(received.Any(e=>e.Kind==MatchEventKind.ShieldDamaged))return received;
                    if(batch.Events.Count==0)break;
                }
                throw new Exception("Shotgun UDP shield event was not delivered.");
            }
            var eventsA=await ThroughImpact(a);
            var eventsB=await ThroughImpact(b);
            Check(eventsA.SequenceEqual(eventsB) && eventsA.Any(e=>e.Kind==MatchEventKind.Shot) &&
                  eventsA.Any(e=>e.Kind==MatchEventKind.Impact) &&
                  eventsA.Any(e=>e.Kind==MatchEventKind.ShieldDamaged && e.ShieldCoverIndex==right.SourceIndex),
                  "both UDP peers receive identical shotgun shot, impact and shield events");
            Check(!reply.Snapshot.RewardEligible,"shotgun UDP mode cannot grant rewards");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        return checks;
    }
    internal static async Task<int> RunOvertimeUdp(string directory)
    {
        int checks=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            Path.Combine(directory,"shotgun-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var left=map.Covers.First(c=>c.Main&&c.Fraction==1);
        var right=map.Covers.First(c=>c.Main&&c.Fraction==2);
        string one=new('a',32),two=new('b',32);
        var weapon=content.Shotguns!.CreateManifest("Google2u.Shotgun_SPAS",0);
        var manifest=new MatchManifest("shotgun-overtime-udp","local-1",
            Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,content.ShotgunRevision!,
            MatchManifest.ShotgunCombatMode,10,5,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1000),0,0),
             new(two,weapon,2,right.SourceIndex,1,new(1000),0,0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-overtime-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-overtime-outbox-"+Guid.NewGuid().ToString("N")),
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:ShotgunContentManifestPath"]=Path.Combine(directory,"shotgun-content-manifest.json")
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,
                MatchId=admission.MatchId,ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(18));
            using var a=new MatchConnection(Grant(one,941));using var b=new MatchConnection(Grant(two,942));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted" &&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "overtime UDP peers admitted by signed grants");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do
            {
                await Task.Delay(100,timeout.Token);
                state=await a.PollAsync(timeout.Token);
            } while(state.Snapshot.Phase!=BattlePhase.Running || state.Snapshot.EndTick!=0);
            var other=await b.PollAsync(timeout.Token);
            Check(state.Snapshot.Phase==BattlePhase.Running && !state.Snapshot.RewardEligible &&
                  state.Snapshot.Shields.Count==8 && state.Snapshot.Shields.All(s=>s.Destroyed) &&
                  other.Snapshot.Phase==BattlePhase.Running && other.Snapshot.EndTick==0 &&
                  other.Snapshot.Shields.All(s=>s.Destroyed),
                  "two UDP peers see live source overtime and destroyed shields");
            async Task<List<MatchEvent>> Drain(MatchConnection peer)
            {
                var rows=new List<MatchEvent>();ulong cursor=0;
                for(int page=0;page<16;page++)
                {
                    var batch=await peer.PollEventsAsync(cursor,timeout.Token);
                    Check(batch.Code=="events" && batch.Events.Count<=4,"overtime UDP page remains bounded");
                    if(batch.Events.Count==0)return rows;
                    rows.AddRange(batch.Events);cursor=batch.Events[^1].EventId;
                }
                throw new Exception("Overtime UDP event drain did not finish.");
            }
            var first=await Drain(a);var second=await Drain(b);
            Check(first.SequenceEqual(second) &&
                  first.Count(e=>e.Kind==MatchEventKind.OvertimeStarted)==1 &&
                  first.Count(e=>e.Kind==MatchEventKind.ShieldDestroyed)==8,
                  "both UDP peers replay the same single overtime and eight shield events");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        return checks;
    }
    internal static int Run(string directory)
    {
        int checks=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception(name);}
        var rifleOnly=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            Path.Combine(directory,"shotgun-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var left=map.Covers.First(c=>c.Main&&c.Fraction==1);
        var right=map.Covers.First(c=>c.Main&&c.Fraction==2);
        string one=new('a',32),two=new('b',32);
        string source="Google2u.Shotgun_SPAS";
        var weapon=content.Shotguns!.CreateManifest(source,0);
        var manifest=new MatchManifest("shotgun-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.ShotgunRevision!,MatchManifest.ShotgunCombatMode,10,60,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1000),0),new(two,weapon,2,right.SourceIndex,1,new(1000),0)]);
        Reject(()=>new MatchEngine(manifest,map,rifleOnly),"shotgun mode without its pinned package accepted");
        Reject(()=>new MatchEngine(manifest with { CatalogRevision=content.Revision },map,content),
            "rifle catalog revision accepted for shotgun match");
        Reject(()=>new MatchEngine(manifest with {Players=[manifest.Players[0] with
            {Weapon=weapon with {ClipSize=weapon.ClipSize+1}},manifest.Players[1]]},map,content),
            "allocator ammo assertion can override source shotgun level");
        foreach(var binding in content.Shotguns.Bindings)
        {
            var variant=content.Shotguns.CreateManifest(binding.SourceId,0);
            var allocation=manifest with {Players=[manifest.Players[0] with {Weapon=variant},manifest.Players[1]]};
            var admitted=new MatchEngine(allocation,map,content);
            Check(admitted.CombatPose(one).Muzzle(binding.SourceId).SourcePath==binding.MuzzlePath,
                "source shotgun variant selects its animated muzzle: "+binding.SourceId);
        }
        var match=new MatchEngine(manifest,map,content);
        Check(match.CombatPose(one).Muzzle(source).SourcePath==content.Shotguns.Binding(source).MuzzlePath,
            "live shotgun actor owns its animated muzzle");
        match.Admit(one);match.Admit(two);
        foreach(var id in new[]{one,two})match.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
        match.Advance(60);
        var aim=match.CombatPose(two).Collision.Parts[1].Center;
        var fire=new MatchCommand{CommandId=2,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}};
        Check(match.Command(one,fire).Code=="shot-scheduled" && match.Snapshot().Players[0].ClipAmmo==weapon.ClipSize,
            "covered shotgun click waits without spending a shell");
        Check(match.Command(one,fire).Code=="shot-scheduled","shotgun click receipt replays exactly");
        for(ulong tick=61;tick<=64;tick++)match.Advance(tick);
        var state=match.Snapshot();
        var muzzle=match.CombatPose(one).Muzzle(source).Position+content.Shotguns.Binding(source).ShotOffset;
        var enemyCenter=match.CombatPose(two).Collision.Parts[1].Center;
        var toward=enemyCenter-muzzle;
        var ray=Vector3.Normalize(toward);
        var collisionPlayers=new[]{new CollisionPlayer(one,match.CombatPose(one).Collision),
            new CollisionPlayer(two,match.CombatPose(two).Collision)};
        var shieldHit=new ShotCollisionWorld(map,collisionPlayers).Raycast(one,muzzle,ray,toward.Length()+1,
            content.Bindings.BulletMask(1));
        Check(shieldHit?.DynamicOwner==right.SourcePath+"/riot_shield" &&
              shieldHit.ColliderIndex==map.DynamicColliders.Single(c=>c.DynamicOwner==shieldHit.DynamicOwner).ColliderIndex,
            "City cover shot resolves the exact opposing shield owner");
        var cleared=new ShotCollisionWorld(map,collisionPlayers,owner=>owner!=shieldHit!.DynamicOwner)
            .Raycast(one,muzzle,ray,toward.Length()+1,content.Bindings.BulletMask(1));
        Check(cleared?.DynamicOwner!=shieldHit!.DynamicOwner,
            "host collision can remove only the destroyed shield owner: "+cleared);
        Check(cleared?.PlayerId==two,"cleared shield ray reaches the opposing player: "+cleared);
        Check(state.Players[0].ShotsFired==1 && state.Players[0].ClipAmmo==weapon.ClipSize-1 &&
              match.PendingProjectileCount>0,"delayed shotgun volley spends exactly one shell");
        Check(state.Players[0].RiflePose.Layers.Any(l=>(int)l.Clip is >=20 and <26),
            "source weapon type seven selects shotgun cover clips");
        var firstEvents=match.EventBatch(one,0);
        Check(firstEvents.Events.Any(e=>e.Kind==MatchEventKind.Shot),"live shotgun volley emits host shot events");
        ulong nextCommand=3;
        ulong peerCommand=2;
        for(ulong tick=65;tick<=240 && !match.Terminal;tick++)
        {
            match.Advance(tick);
            if(tick%8==0)
            {
                var current=match.CombatPose(two).Collision.Parts[1].Center;
                match.Command(one,new MatchCommand{CommandId=nextCommand++,Fire=new FireCommand
                    {TargetX=current.X,TargetY=current.Y,TargetZ=current.Z}});
                var reverse=match.CombatPose(one).Collision.Parts[1].Center;
                match.Command(two,new MatchCommand{CommandId=peerCommand++,Fire=new FireCommand
                    {TargetX=reverse.X,TargetY=reverse.Y,TargetZ=reverse.Z}});
            }
            if(match.Snapshot().Players.Any(p=>p.ConfirmedPlayerHits>0))break;
        }
        state=match.Snapshot();
        Check(state.Players.Any(p=>p.Health<1000) && state.Players.Any(p=>p.ConfirmedPlayerHits>0),
            "source shotgun pellets cause authoritative player damage and shooter hit credit: "+state);
        Check(!state.RewardEligible,"shotgun checkpoint remains unscored");
        var barrelManifest=manifest with {MatchId="shotgun-barrel-authority",SceneMasterPlayerId=one,
            Players=[manifest.Players[0] with {PlayerLevel=0},manifest.Players[1] with {PlayerLevel=42}]};
        Reject(()=>new MatchEngine(barrelManifest with {SceneMasterPlayerId=two,
            Players=[barrelManifest.Players[0],barrelManifest.Players[1] with {PlayerLevel=null}]},map,content),
            "missing scene-master rank accepted");
        Reject(()=>new MatchEngine(barrelManifest with {SceneMasterPlayerId=new string('c',32)},map,content),
            "unknown scene master accepted");
        Reject(()=>new MatchEngine(barrelManifest with {Players=[barrelManifest.Players[0] with {PlayerLevel=43},
            barrelManifest.Players[1]]},map,content),"past-end barrel level accepted");
        var barrelMatch=new MatchEngine(barrelManifest,map,content);
        barrelMatch.Admit(one);
        var initialBarrels=barrelMatch.BarrelBatch(one);
        Check(initialBarrels.SourceCount==2 && initialBarrels.MaxHealth==50 &&
              initialBarrels.Changed.Count==0 && initialBarrels.StateRevision==barrelMatch.Snapshot().StateRevision,
              "scene-master barrel read exposes source count and initial health without bloating pose snapshots");
        var tracker=new BarrelStateTracker(barrelManifest.MatchId,barrelMatch.ManifestHash,
            content.Barrels.ForMap(map).Select(x=>new BarrelSceneIdentity(x.ColliderIndex,x.GameObjectFileId)));
        tracker.Apply(initialBarrels);
        Check(tracker.Snapshot().Count==2 && tracker.Snapshot().All(x=>x.Health==50 && x.Revision==0),
            "portable client reconstructs untouched scene barrels from signed source identities");
        Check(barrelMatch.BarrelState.Count==content.Barrels.ForMap(map).Count &&
              barrelMatch.BarrelState.All(b=>b.MaxHealth==50f && b.Health==50f && !b.Destroyed && b.Revision==0),
              "signed scene master level initializes every City barrel without client-supplied HP");
        var barrelAuthority=new BarrelMatchSimulation(map,content.Barrels,content.BarrelPolicy,
            content.BarrelOverlap,barrelManifest);
        var barrelShape=map.DynamicColliders.Single(c=>c.ColliderIndex==barrelMatch.BarrelState[0].ColliderIndex);
        var barrelBoundsCenter=(barrelShape.BoundsMin+barrelShape.BoundsMax)/2;
        Check(barrelShape.Layer==0 && barrelAuthority.RuntimeLayer(barrelShape.ColliderIndex,0)==8 &&
              map.DynamicSphereCandidates(barrelBoundsCenter,.01f,1u<<8,
                  barrelAuthority.ColliderEnabled,barrelAuthority.RuntimeLayer).Any(c=>
                  c.Collider.ColliderIndex==barrelShape.ColliderIndex && c.Collider.Layer==8) &&
              !map.DynamicSphereCandidates(barrelBoundsCenter,.01f,1u<<0,
                  barrelAuthority.ColliderEnabled,barrelAuthority.RuntimeLayer).Any(c=>
                  c.Collider.ColliderIndex==barrelShape.ColliderIndex),
              "scene barrel runtime layer 8 replaces its serialized layer 0 for overlap selection");
        var chain=barrelAuthority.PreviewShotChain(barrelShape.ColliderIndex,100);
        var altered=chain with {OrderedEffects=[chain.OrderedEffects[0] with {Damage=99},
            ..chain.OrderedEffects.Skip(1)]};
        Reject(()=>barrelAuthority.CommitPlannedChain(barrelShape.ColliderIndex,100,altered),
            "mutated chain preview published barrel state");
        Check(barrelAuthority.Snapshot().All(b=>b.Health==50 && !b.Destroyed),
            "rejected chain preview leaves every barrel unchanged");
        barrelAuthority.CommitPlannedChain(barrelShape.ColliderIndex,100,chain);
        Check(barrelAuthority.Snapshot().Single(b=>b.ColliderIndex==barrelShape.ColliderIndex).Destroyed &&
              !barrelAuthority.ColliderEnabled(barrelShape.ColliderIndex) &&
              barrelAuthority.Snapshot().Where(b=>b.ColliderIndex==barrelShape.ColliderIndex)
                  .All(b=>b.Revision>=1),
              "validated chain commits source barrel death and suppresses its collider");
        var changed=initialBarrels.Clone();changed.StateRevision++;
        changed.Changed.AddRange(barrelAuthority.Snapshot().Where(x=>x.Revision>0).Select(x=>
            new BattleBarrelState {ColliderIndex=x.ColliderIndex,GameObjectFileId=x.GameObjectFileId,
                Health=x.Health,Destroyed=x.Destroyed,Revision=x.Revision}));
        tracker.Apply(changed);
        Check(tracker.Snapshot().Single(x=>x.ColliderIndex==barrelShape.ColliderIndex).Destroyed &&
              tracker.Snapshot().Count(x=>x.Revision==0)==2-changed.Changed.Count,
            "portable client maps changed barrel state to the recovered scene object");
        var spoof=changed.Clone();spoof.StateRevision++;
        spoof.Changed[0].GameObjectFileId++;
        void RejectView(Action action,string name)
        {try{action();}catch(InvalidOperationException){checks++;return;}throw new Exception(name);}
        RejectView(()=>tracker.Apply(spoof),"scene GameObject ID mismatch accepted in reconnect batch");
        RejectView(()=>tracker.Apply(initialBarrels),"stale barrel reconnect batch rolled back a destroyed object");
        Reject(()=>barrelAuthority.CommitPlannedChain(barrelShape.ColliderIndex,100,chain),
            "stale chain preview replayed after barrel death");
        var parkMap=content.Maps.Single(m=>m.Source.Contains("Park_Multiplayer",StringComparison.Ordinal));
        var parkLeft=parkMap.Covers.Single(c=>c.SourceIndex==1);
        var parkRight=parkMap.Covers.First(c=>c.Main&&c.Fraction==2);
        var rifleWeapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var parkManifest=barrelManifest with {MatchId="rifle-barrel-live",
            MapId=Path.GetFileNameWithoutExtension(parkMap.Source),MapRevision=parkMap.SourceHash,
            Mode=MatchManifest.RifleCombatMode,CatalogRevision=content.Revision,
            Players=[barrelManifest.Players[0] with {Weapon=rifleWeapon,WeaponUpgrade=0,StartCover=parkLeft.SourceIndex},
                barrelManifest.Players[1] with {Weapon=rifleWeapon,WeaponUpgrade=0,StartCover=parkRight.SourceIndex}]};
        var parkMatch=new MatchEngine(parkManifest,parkMap,content);
        parkMatch.Admit(one);parkMatch.Admit(two);
        foreach(var id in new[]{one,two})parkMatch.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=parkMatch.ManifestHash}});
        parkMatch.Advance(60);
        int liveBarrelIndex=82;
        var liveBarrel=parkMap.DynamicColliders.Single(x=>x.ColliderIndex==liveBarrelIndex);
        var barrelFire=parkMatch.Command(one,new MatchCommand{CommandId=2,
            Fire=new FireCommand{TargetX=liveBarrel.TransformPosition.X,
                TargetY=liveBarrel.TransformPosition.Y,TargetZ=liveBarrel.TransformPosition.Z}});
        for(ulong t=61;t<180 && !parkMatch.Terminal;t++)parkMatch.Advance(t);
        Check(parkMatch.BarrelState.Single(x=>x.ColliderIndex==liveBarrelIndex).Revision>0 &&
              parkMatch.BarrelBatch(one).Changed.Any(x=>x.ColliderIndex==liveBarrelIndex),
            "live rifle projectile reaches a source Park barrel: "+barrelFire.Code+" "+
            parkMatch.Snapshot().Players[0].LastGeometryHit);
        ulong parkTick=180,parkCommand=3;
        while(!parkMatch.BarrelState.Single(x=>x.ColliderIndex==liveBarrelIndex).Destroyed &&
              parkTick<720 && !parkMatch.Terminal)
        {
            parkMatch.Command(two,new MatchCommand{CommandId=0,Poll=new PollMatch()});
            parkMatch.Command(one,new MatchCommand{CommandId=parkCommand++,Fire=new FireCommand{
                TargetX=liveBarrel.TransformPosition.X,TargetY=liveBarrel.TransformPosition.Y,
                TargetZ=liveBarrel.TransformPosition.Z}});
            for(ulong t=parkTick;t<parkTick+30 && !parkMatch.Terminal;t++)parkMatch.Advance(t);
            parkTick+=30;
        }
        Check(parkMatch.BarrelState.Single(x=>x.ColliderIndex==liveBarrelIndex).Destroyed &&
              parkMatch.BarrelBatch(one).Changed.Single(x=>x.ColliderIndex==liveBarrelIndex).Destroyed,
            "repeated source rifle hits destroy Park barrel and project reconnect state");
        var parkEvents=new List<MatchEvent>();ulong parkCursor=0;
        while(true)
        {
            var batch=parkMatch.EventBatch(one,parkCursor);
            Check(batch.Code=="events","barrel event cursor remains readable");
            if(batch.Events.Count==0)break;
            parkEvents.AddRange(batch.Events);parkCursor=batch.Events[^1].EventId;
        }
        Check(parkEvents.Any(e=>e.Kind==MatchEventKind.BarrelDamaged &&
                  e.BarrelColliderIndex==liveBarrelIndex) &&
              parkEvents.Any(e=>e.Kind==MatchEventKind.BarrelDestroyed &&
                  e.BarrelColliderIndex==liveBarrelIndex && e.BarrelGameObjectFileId>0),
            "ordered combat cursor publishes barrel health and source-ID death event");
        var otherMaster=new MatchEngine(barrelManifest with {SceneMasterPlayerId=two},map,content);
        Check(otherMaster.BarrelState.All(b=>b.MaxHealth==content.BarrelPolicy.MaxHealth(42)) &&
              otherMaster.ManifestHash!=barrelMatch.ManifestHash,
              "scene-master identity changes source barrel health and signed allocation digest");
        var shieldManifest=manifest with {MatchId="shotgun-shield-live",
            Players=manifest.Players.Select(p=>p with {ShieldLevel=0}).ToArray()};
        Reject(()=>new MatchEngine(manifest with {Players=[manifest.Players[0] with {ShieldLevel=0},
            manifest.Players[1]]},map,content),"one-sided shield rank accepted");
        Reject(()=>new MatchEngine(shieldManifest with {Players=[shieldManifest.Players[0] with
            {ShieldLevel=44},shieldManifest.Players[1]]},map,content),"past-end shield rank accepted");
        var shieldHitProbe=new ShieldMatchSimulation(map,content.Shields,shieldManifest);
        string enemyShieldOwner=right.SourcePath+"/riot_shield";
        Check(shieldHitProbe.IsLiveEnemyShield(enemyShieldOwner,shieldManifest.Players[0].Fraction) &&
              shieldHitProbe.ApplyShot(enemyShieldOwner,shieldManifest.Players[0].Fraction,
                  source,0,0)==null &&
              shieldHitProbe.IsLiveEnemyShield(enemyShieldOwner,shieldManifest.Players[0].Fraction) &&
              !shieldHitProbe.IsLiveEnemyShield(enemyShieldOwner,right.Fraction),
              "zero-damage enemy shield contact remains a confirmed hit without a health event");
        var shieldMatch=new MatchEngine(shieldManifest,map,content);
        var overtimeDefinition=shieldManifest with {MatchId="shotgun-source-overtime",DurationSeconds=5};
        var overtimeMatch=new MatchEngine(overtimeDefinition,map,content);
        overtimeMatch.Admit(one);overtimeMatch.Admit(two);
        foreach(var id in new[]{one,two})overtimeMatch.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=overtimeMatch.ManifestHash}});
        overtimeMatch.Advance(60);
        for(ulong overtimeTick=61;overtimeTick<=210;overtimeTick++)overtimeMatch.Advance(overtimeTick);
        var overtimeState=overtimeMatch.Snapshot();
        Check(overtimeState.Phase==BattlePhase.Running && overtimeState.EndTick==0 &&
              overtimeState.Shields.Count==8 && overtimeState.Shields.All(s=>s.Destroyed && s.Health==0),
              "source DeathMatch clock enters live overtime and destroys all eight shields");
        Check(MatchOutcomeProjection.ForPlayer(overtimeState,one)==ClientGameEndReason.None &&
              MatchOutcomeProjection.ForPlayer(overtimeState,two)==ClientGameEndReason.None,
              "running overtime cannot project a finished Client outcome");
        var overtimeEvents=new List<MatchEvent>();ulong overtimeCursor=0;
        for(int page=0;page<8;page++)
        {
            var batch=overtimeMatch.EventBatch(one,overtimeCursor);
            overtimeEvents.AddRange(batch.Events);
            if(batch.Events.Count==0)break;
            overtimeCursor=batch.Events[^1].EventId;
        }
        Check(overtimeEvents.Count(e=>e.Kind==MatchEventKind.OvertimeStarted)==1 &&
              overtimeEvents.Count(e=>e.Kind==MatchEventKind.ShieldDestroyed)==8,
              "overtime transition and shield removals replay once in the ordered event stream");
        for(ulong overtimeTick=211;overtimeTick<=400;overtimeTick++)overtimeMatch.Advance(overtimeTick);
        Check(overtimeMatch.Snapshot().Phase==BattlePhase.Running &&
              overtimeMatch.Snapshot().Shields.All(s=>s.Destroyed),
              "overtime has no invented duration limit and disables shield repair");
        Check(shieldMatch.Snapshot().Shields.Count==8 &&
              shieldMatch.Snapshot().Shields.All(s=>s.MaxHealth==560 && s.Health==560),
              "trusted rank-zero allocation initializes all eight source shields");
        shieldMatch.Admit(one);shieldMatch.Admit(two);
        foreach(var id in new[]{one,two})shieldMatch.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=shieldMatch.ManifestHash}});
        shieldMatch.Advance(60);
        var shieldAim=shieldMatch.CombatPose(two).Collision.Parts[1].Center;
        shieldMatch.Command(one,new MatchCommand{CommandId=2,Fire=new FireCommand
            {TargetX=shieldAim.X,TargetY=shieldAim.Y,TargetZ=shieldAim.Z}});
        for(ulong shieldTick=61;shieldTick<=90;shieldTick++)shieldMatch.Advance(shieldTick);
        var shieldState=shieldMatch.Snapshot();
        Check(shieldState.Shields[right.SourceIndex].Health<560 &&
              shieldState.Shields[right.SourceIndex].Revision>0 &&
              shieldState.Players[1].Health==1000,
              "confirmed shotgun impact damages the rank-authorized shield before player health");
        Check(shieldState.Players[0].ConfirmedEnemyHits>0 && shieldState.Players[0].ConfirmedPlayerHits==0,
              "confirmed shield impacts count as enemy hits without player-hit credit");
        var shieldEvents=new List<MatchEvent>();ulong shieldCursor=0;
        for(int page=0;page<8;page++)
        {
            var batch=shieldMatch.EventBatch(one,shieldCursor);
            foreach(var row in batch.Events){shieldCursor=row.EventId;shieldEvents.Add(row);}
            if(batch.Events.Count==0)break;
        }
        Check(shieldEvents.Any(e=>e.Kind==MatchEventKind.ShieldDamaged &&
              e.ShieldCoverIndex==right.SourceIndex && e.Health==shieldState.Shields[right.SourceIndex].Health),
              "source cover shield damage reaches the ordered event stream");
        var packet=new Packet{Version=1,SessionId=1,Sequence=1,MatchReply=new MatchReply
            {CommandId=1,Code="state",Snapshot=shieldState}};
        Check(PacketCodec.Encode(packet,new byte[32]).Length<=1200,
              "eight live shield snapshots fit the authenticated UDP datagram");
        var strong=content.Shotguns.CreateManifest(source,35);
        var breakManifest=shieldManifest with {MatchId="shotgun-shield-break",
            Players=[shieldManifest.Players[0] with {Weapon=strong,WeaponUpgrade=35},shieldManifest.Players[1]]};
        var breakMatch=new MatchEngine(breakManifest,map,content);
        breakMatch.Admit(one);breakMatch.Admit(two);
        foreach(var id in new[]{one,two})breakMatch.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=breakMatch.ManifestHash}});
        breakMatch.Advance(60);
        ulong breakCommand=2,brokenTick=0;
        for(ulong currentTick=60;currentTick<500 && !breakMatch.Terminal;currentTick++)
        {
            if(currentTick>60)breakMatch.Advance(currentTick);
            if(currentTick%8==4)
            {
                var center=breakMatch.CombatPose(two).Collision.Parts[1].Center;
                breakMatch.Command(one,new MatchCommand{CommandId=breakCommand++,Fire=new FireCommand
                    {TargetX=center.X,TargetY=center.Y,TargetZ=center.Z}});
            }
            if(breakMatch.Snapshot().Shields[right.SourceIndex].Destroyed)
            {brokenTick=currentTick;break;}
        }
        Check(brokenTick>0 && breakMatch.Snapshot().Shields[right.SourceIndex].Health==0,
              "source high-stage shotgun destroys the correct live shield");
        var destroyedEvents=new List<MatchEvent>();ulong destroyedCursor=0;
        for(int page=0;page<128;page++)
        {
            var batch=breakMatch.EventBatch(one,destroyedCursor);
            foreach(var row in batch.Events){destroyedCursor=row.EventId;destroyedEvents.Add(row);}
            if(batch.Events.Count==0)break;
        }
        Check(destroyedEvents.Any(e=>e.Kind==MatchEventKind.ShieldDestroyed &&
              e.ShieldCoverIndex==right.SourceIndex),"shield destruction has a replayable event");
        for(ulong currentTick=brokenTick+1;currentTick<brokenTick+180;currentTick++)
        {
            breakMatch.Advance(currentTick);
            if(currentTick%8==4 && breakMatch.Snapshot().Players[1].Health==1000)
            {
                var center=breakMatch.CombatPose(two).Collision.Parts[1].Center;
                breakMatch.Command(one,new MatchCommand{CommandId=breakCommand++,Fire=new FireCommand
                    {TargetX=center.X,TargetY=center.Y,TargetZ=center.Z}});
            }
        }
        Check(breakMatch.Snapshot().Shields[right.SourceIndex].Destroyed &&
              breakMatch.Snapshot().Players[1].Health<1000 &&
              breakMatch.Snapshot().Players[0].ConfirmedPlayerHits>0,
              "destroyed shield stays absent and a later shot reaches its player before repair");
        breakMatch.Advance(brokenTick+180);
        Check(!breakMatch.Snapshot().Shields[right.SourceIndex].Destroyed &&
              breakMatch.Snapshot().Shields[right.SourceIndex].Health==560,
              "live shield restores collider and rank HP at six-second deadline");
        bool foundRepair=false;
        for(int page=0;page<128;page++)
        {
            var batch=breakMatch.EventBatch(one,destroyedCursor);
            foreach(var row in batch.Events)
            {
                destroyedCursor=row.EventId;
                if(row.Kind==MatchEventKind.ShieldRepaired && row.ShieldCoverIndex==right.SourceIndex && row.Health==560)
                    foundRepair=true;
            }
            if(batch.Events.Count==0)break;
        }
        Check(foundRepair,
              "source repair publishes a replayable owner-bound shield event");
        return checks;
    }
}

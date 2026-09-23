using System.Numerics;
using War.BattleServer;
using War.Protocol;
using War.Protocol.Transport;
using War.Client;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;

internal static class LiveRifleTests
{
    internal static async Task RunUnity(string directory,string unityExe,string projectPath)
    {
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[] {map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string[] ids=[new string('a',32),new string('b',32)];
        var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var famas=content.Stats.CreateManifest("Google2u.AssaultRifle_Famas",0);
        ParticipantManifest Player(string id,int fraction,CoverNode cover)=>new(id,weapon,fraction,cover.SourceIndex,1,new(1000),0)
        {
            WeaponSlots=[new WeaponSlotManifest(0,11,weapon,0),new WeaponSlotManifest(2,26,famas,0)]
        };
        var manifest=new MatchManifest("rifle-unity","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,content.Revision,
            MatchManifest.RifleCombatMode,120,60,120,
            [Player(ids[0],1,covers[0]),Player(ids[1],2,covers[1])]);
        string prefix=Path.Combine(Path.GetTempPath(),"war-rifle-unity-"+Guid.NewGuid().ToString("N"));
        string manifestFile=prefix+".json",grantsFile=prefix+".jsonl";
        string unityLog=Path.GetFullPath("Server/.local/unity-live-rifle.log");
        Directory.CreateDirectory(Path.GetDirectoryName(unityLog)!);
        await File.WriteAllTextAsync(manifestFile,JsonSerializer.Serialize(manifest));
        using var portProbe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;portProbe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var claim=new MatchAdmission {MatchId=manifest.MatchId,ServerId=manifest.ServerId,PlayerId=id,SessionId=session,
                ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            var grant=new MatchConnectionGrant {Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,MatchId=claim.MatchId,
                ManifestHash=claim.ManifestHash,ExpiresUnixSeconds=claim.ExpiresUnixSeconds,
                Ticket=tokens.Sign(claim),SessionKey=ByteString.CopyFrom(tokens.SessionKey(claim))};
            grant.PlayerViews.Add(View(ids[0],"Left",1));grant.PlayerViews.Add(View(ids[1],"Right",2));
            return grant;
        }
        BattlePlayerView View(string id,string name,int fraction)
        {
            var view=new BattlePlayerView {PlayerId=id,DisplayName=name,Level=1,ArmyPower=1,Country="US",Fraction=fraction,DefendPosition=0};
            view.VisualIds.Add(["v0","v1","v2","v3"]);
            view.Weapons.Add(new BattleWeaponView {Slot=0,WeaponIndex=11,SourceId="Google2u.AssaultRifle_AK47",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView {Slot=2,WeaponIndex=26,SourceId="Google2u.AssaultRifle_Famas",UpgradeIndex=0});
            return view;
        }
        await File.WriteAllLinesAsync(grantsFile,[JsonFormatter.Default.Format(Grant(ids[0],801)),JsonFormatter.Default.Format(Grant(ids[1],802))]);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=manifestFile,["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-rifle-unity-outbox-"+Guid.NewGuid().ToString("N"))
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        System.Diagnostics.Process? editor=null;
        try
        {
            await worker.StartAsync(CancellationToken.None);
            var start=new System.Diagnostics.ProcessStartInfo(unityExe)
            {UseShellExecute=false,CreateNoWindow=true,WindowStyle=System.Diagnostics.ProcessWindowStyle.Hidden};
            foreach(var arg in new[] {"-batchmode","-nographics","-projectPath",projectPath,"-executeMethod","SelfHostedLiveRifleAudit.Run","-logFile",unityLog})
                start.ArgumentList.Add(arg);
            start.Environment["WAR_RIFLE_LIVE_GRANTS_FILE"]=grantsFile;
            editor=System.Diagnostics.Process.Start(start)??throw new Exception("Unity did not start.");
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(105));
            await editor.WaitForExitAsync(timeout.Token);
            if(editor.ExitCode!=0 || !(await File.ReadAllTextAsync(unityLog)).Contains("UNITY_LIVE_RIFLE_PASSED"))
                throw new Exception("Unity live rifle audit failed; inspect "+unityLog);
            Console.WriteLine("PASS: two rendered recovered Unity rigs over live UDP; "+unityLog);
        }
        finally
        {
            if(editor!=null){if(!editor.HasExited)editor.Kill(true);editor.Dispose();}
            await worker.StopAsync(CancellationToken.None);
            File.Delete(grantsFile);File.Delete(manifestFile);
        }
    }
    internal static async Task<int> RunUdp(string directory)
    {
        int count=0;void Check(bool ok,string name) {if(!ok)throw new Exception(name);count++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var a=map.Covers.First(c=>c.Main&&c.Fraction==1);var b=map.Covers.First(c=>c.Main&&c.Fraction==2);
        string one=new string('a',32),two=new string('b',32);
        var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var manifest=new MatchManifest("rifle-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,content.Revision,
            MatchManifest.RifleCombatMode,10,60,120,[new(one,weapon,1,a.SourceIndex,1,new(1000),0),new(two,weapon,2,b.SourceIndex,1,new(1000),0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-rifle-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var portProbe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;portProbe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-rifle-udp-outbox-"+Guid.NewGuid().ToString("N"))
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        MatchConnectionGrant Grant(string player,ulong session,ulong generation=0)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var c=new MatchAdmission {MatchId=manifest.MatchId,ServerId=manifest.ServerId,PlayerId=player,SessionId=session,ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120,
                ConnectionGeneration=generation};
            return new() {Host="127.0.0.1",Port=(uint)port,PlayerId=player,SessionId=session,MatchId=c.MatchId,ManifestHash=c.ManifestHash,
                ExpiresUnixSeconds=c.ExpiresUnixSeconds,Ticket=tokens.Sign(c),SessionKey=ByteString.CopyFrom(tokens.SessionKey(c))};
        }
        Vector3 Head(CoverNode cover,CoverNode other)
        {
            var direction=other.Position-cover.Position;direction.Y=0;var aim=new PlayerAimState();aim.LookAt(direction,cover.Rotation,0);aim.Advance(.1,.1f,cover.Rotation);
            bool right=Vector3.Dot(Vector3.UnitY,Vector3.Cross(Vector3.Transform(Vector3.UnitZ,cover.Rotation),direction))>0;
            return content.Poses.SampleAimed(right?"player_fire_right3":"player_fire_left3",.15,false,aim.BodyRotation,null).Place(cover.Position,cover.Rotation).Collision.Parts[1].Center;
        }
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var ct=new CancellationTokenSource(TimeSpan.FromSeconds(15));
            using var peerA=new MatchConnection(Grant(one,701));using var peerB=new MatchConnection(Grant(two,702));
            Check((await peerA.ConnectAsync(ct.Token)).Code=="admitted","rifle UDP admission A");
            Check((await peerB.ConnectAsync(ct.Token)).Code=="admitted","rifle UDP admission B");
            await peerA.ReadyAsync(ct.Token);await peerB.ReadyAsync(ct.Token);
            MatchReply state;
            do { await Task.Delay(100,ct.Token);state=await peerA.PollAsync(ct.Token); } while(state.Snapshot.Phase!=BattlePhase.Running);
            var targetA=Head(b,a);var targetB=Head(a,b);
            var first=await peerA.FireAsync(targetA.X,targetA.Y,targetA.Z,ct.Token);
            Check(first.Code=="shot-scheduled" && first.Snapshot.Players[0].ShotsFired==0,"UDP first shot honors uncover delay");
            for(int attempt=0;attempt<24;attempt++)
            {
                await peerB.FireAsync(targetB.X,targetB.Y,targetB.Z,ct.Token);
                await Task.Delay(240,ct.Token);
                state=await peerA.FireAsync(targetA.X,targetA.Y,targetA.Z,ct.Token);
                if(state.Snapshot.Players.Any(p=>p.Health<1000))break;
            }
            Check(state.Snapshot.Players.Any(p=>p.Health<1000),"live UDP source rifle damage reaches SDK snapshot");
            Check(state.Snapshot.Players.Any(p=>p.ConfirmedPlayerHits>0) && state.Snapshot.Players.All(p=>p.ConfirmedPlayerHits<=p.ShotsFired),
                "live UDP confirms hits only after server projectile impact");
            Check(state.Snapshot.Players.All(p=>p.ConfirmedEnemyHits==p.ConfirmedPlayerHits),
                "live player-only UDP encounter attributes each confirmed enemy hit once");
            Check(state.Snapshot.Players.All(p=>p.RiflePose!=null && p.RiflePose.Layers.Count>0 && p.RiflePose.SampledTick<=state.Snapshot.ServerTick),"live UDP SDK receives authoritative sampled poses");
            var eventA=await peerA.PollEventsAsync(0,ct.Token);
            var eventReplay=await peerA.PollEventsAsync(0,ct.Token);
            var eventB=await peerB.PollEventsAsync(0,ct.Token);
            Check(eventA.Code=="events" && eventA.Events.Count>0 &&
                eventA.Events.SequenceEqual(eventReplay.Events) && eventA.Events.SequenceEqual(eventB.Events),
                "two UDP clients receive identical replayable combat event pages");
            Check(eventA.Events.Any(e=>e.Kind==MatchEventKind.Shot),"live UDP page includes host shot event");
            ulong processed=eventA.Events[^1].EventId;
            await peerA.PollEventsAsync(processed,ct.Token);
            using(var resumed=new MatchConnection(Grant(one,703,1)))
            {
                Check((await resumed.ConnectAsync(ct.Token)).Code=="admitted","new signed generation resumes live match");
                var restored=await resumed.PollEventsAsync(processed,ct.Token);
                Check(restored.Code=="events" && restored.Events.All(e=>e.EventId>processed),
                    "reconnected SDK resumes from the exact processed event cursor");
            }
            Check(!state.Snapshot.RewardEligible,"UDP rifle mode remains unscored");
        }
        finally {await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        return count;
    }
    internal static int Run(string directory)
    {
        int count=0;void Check(bool ok,string name) {if(!ok)throw new Exception(name);count++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=RecoveredBattleMap.Load(Path.Combine(directory,"recovered-battle-content.json")).Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var a=map.Covers.First(c=>c.Main && c.Fraction==1);var b=map.Covers.First(c=>c.Main && c.Fraction==2);
        string one=new string('a',32),two=new string('b',32);
        var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var manifest=new MatchManifest("rifle-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,content.Revision,
            MatchManifest.RifleCombatMode,10,60,120,[new(one,weapon,1,a.SourceIndex,1,new(1000),0),new(two,weapon,2,b.SourceIndex,1,new(1000),0)]);
        foreach(float unsupportedSpeed in new[] {.5f,2f})
        {
            var changed=manifest with {Players=[manifest.Players[0] with {MovementSpeed=unsupportedSpeed},manifest.Players[1]]};
            try { new MatchEngine(changed,map,content); throw new Exception("Unsupported rifle movement speed accepted."); }
            catch(InvalidDataException) { count++; }
        }
        var engine=new MatchEngine(manifest,map,content);engine.Admit(one);engine.Admit(two);
        var renderCases=new List<object>();
        void VerifyPose()
        {
            // Independent protocol-to-source mapping; reconstruct exactly the
            // collision geometry represented by a serialized client snapshot.
            string[] names=["idle","player_look_left3","player_fire_left3","player_left_coverBack3",
                "player_look_right3","player_fire_right3","player_right_coverBack3",
                "player_look_left_qbz","player_fire_left_qbz","player_left_coverBack_qbz",
                "player_look_right_qbz","player_fire_right_qbz","player_right_coverBack_qbz",
                "player_look_left_qbz2","player_fire_left_qbz2","player_left_coverBack_qbz2",
                "player_look_right_qbz2","player_fire_right_qbz2","player_right_coverBack_qbz2",
                "player_look_left_shotgun","player_fire_left_shotgun","player_left_coverBack_shotgun",
                "player_look_right_shotgun","player_fire_right_shotgun","player_right_coverBack_shotgun",
                "run","qbz_run","qbz2_run","shotgunner_run"];
            static Quaternion Q(PoseRotation q)=>new(q.X,q.Y,q.Z,q.W);
            var snapshot=MatchSnapshot.Parser.ParseFrom(engine.Snapshot().ToByteArray());
            foreach(var p in snapshot.Players)
            {
                var wire=p.RiflePose;
                var layers=wire.Layers.Select(l=>new RifleClipLayer(new(names[(int)l.Clip-1],l.Seconds,1,l.Loop),l.Weight)).ToArray();
                var reconstructed=(wire.UpperBodyLayer!=null ?
                    content.Poses.SampleWalkingShot(layers[0].Clip.Name,layers[0].Clip.Seconds,wire.UpperBodyLayer.Seconds,wire.UpperBodyLayer.Weight,
                        Q(wire.BodyLocalRotation),wire.UpperLocalRotation==null?null:Q(wire.UpperLocalRotation)) :
                    content.Poses.SampleLayers(layers,Q(wire.BodyLocalRotation),wire.UpperLocalRotation==null?null:Q(wire.UpperLocalRotation)))
                    .Place(new(p.PositionX,p.PositionY,p.PositionZ),Q(wire.RootRotation));
                var actual=engine.CombatPose(p.PlayerId);
                static float[] V(Vector3 v)=>[v.X,v.Y,v.Z];
                renderCases.Add(new {player=JsonFormatter.Default.Format(p),parts=actual.Collision.Parts.Select(part=>V(part.Center)).ToArray(),muzzle=V(actual.Muzzle(weapon.SourceId).Position)});
                Check(wire.SampledTick<=snapshot.ServerTick,"wire pose does not predict a future tick");
                for(int part=0;part<actual.Collision.Parts.Count;part++)
                    Check(Vector3.Distance(reconstructed.Collision.Parts[part].Center,actual.Collision.Parts[part].Center)<.000001f &&
                        Math.Abs(Quaternion.Dot(reconstructed.Collision.Parts[part].Rotation,actual.Collision.Parts[part].Rotation))>.999999f,"wire pose reproduces collision part");
                Check(Vector3.Distance(reconstructed.Muzzle(weapon.SourceId).Position,actual.Muzzle(weapon.SourceId).Position)<.000001f,"wire pose reproduces muzzle");
            }
            var packet=new Packet {Version=1,SessionId=ulong.MaxValue,Sequence=ulong.MaxValue,Ack=ulong.MaxValue,AckBits=uint.MaxValue,
                MatchReply=new() {CommandId=ulong.MaxValue,Code="moving-combat-not-supported",Snapshot=snapshot}};
            Check(War.Protocol.Transport.PacketCodec.Encode(packet,new byte[32]).Length<=1200,"pose snapshot fits authenticated datagram");
        }
        VerifyPose();
        foreach(string rifle in new[] {"AK47","M16","AK47Elite","QBZ95","Famas","FamasElite","QBZ95Elite",
            "SteyrAUG","G36","AKS47U","G36Elite"})
        {
            var sourceId="Google2u.AssaultRifle_"+rifle;
            var variant=manifest with {Players=[manifest.Players[0] with {Weapon=content.Stats.CreateManifest(sourceId,0)},manifest.Players[1]]};
            var admitted=new MatchEngine(variant,map,content);
            Check(admitted.CombatPose(one).Muzzle(sourceId).Position!=Vector3.Zero,"source rifle family initializes own muzzle: "+rifle);
            admitted.Admit(one);admitted.Admit(two);
            admitted.Command(one,new() {CommandId=1,Ready=new() {ManifestHash=admitted.ManifestHash}});
            admitted.Command(two,new() {CommandId=1,Ready=new() {ManifestHash=admitted.ManifestHash}});
            admitted.Advance(60);
            var aim=admitted.CombatPose(two).Collision.Parts[1].Center;
            var response=admitted.Command(one,new() {CommandId=2,Fire=new() {TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
            Check(response.Code=="shot-scheduled","source rifle enters cover firing path: "+rifle);
            admitted.Advance(61);
            int family=content.Bindings.Get(sourceId).AnimationFamily;
            int firstClip=family switch {0=>2,9=>8,13=>14,15=>20,_=>throw new Exception("Unknown rifle family.")};
            Check(admitted.Snapshot().Players[0].RiflePose.Layers.Any(l=>(int)l.Clip>=firstClip && (int)l.Clip<firstClip+6),
                "live wire pose uses selected weapon family: "+rifle);
            var move=admitted.Command(one,new() {CommandId=3,MoveCover=new() {Direction=1}});
            Check(move.Code=="moving","source rifle can start adjacent cover route: "+rifle);
            admitted.Advance(62);
            int runClip=family switch {0=>26,9=>27,13=>28,15=>29,_=>throw new Exception("Unknown run family.")};
            Check((int)admitted.Snapshot().Players[0].RiflePose.Layers.Single().Clip==runClip &&
                admitted.Snapshot().Players[0].ShotsFired==0,"moving retains deferred shot and selects source run pose: "+rifle);
        }
        var famas=content.Stats.CreateManifest("Google2u.AssaultRifle_Famas",0);
        ParticipantManifest TwoRifles(ParticipantManifest player)=>player with
        {
            WeaponSlots=[new WeaponSlotManifest(0,11,player.Weapon,0),new WeaponSlotManifest(2,26,famas,0)]
        };
        var switchManifest=MatchManifest.Validate(manifest with
            {MatchId="rifle-switch",Players=[TwoRifles(manifest.Players[0]),TwoRifles(manifest.Players[1])]});
        content.ValidateAllocation(switchManifest);
        var switching=new MatchEngine(switchManifest,map,content);switching.Admit(one);switching.Admit(two);
        switching.Command(one,new() {CommandId=1,Ready=new() {ManifestHash=switching.ManifestHash}});
        switching.Command(two,new() {CommandId=1,Ready=new() {ManifestHash=switching.ManifestHash}});
        switching.Advance(60);
        var selected=switching.Command(one,new() {CommandId=2,SwitchWeapon=new() {Slot=2}});
        int selectedDatagramBytes=new Packet {Version=1,SessionId=ulong.MaxValue,Sequence=ulong.MaxValue,
            Ack=ulong.MaxValue,MatchReply=selected}.CalculateSize()+32;
        Check(selected.Code=="weapon-selected" && selected.Snapshot.Players[0].ActiveWeaponSlot==2,
              "source-backed rifle slot switches to durable FAMAS authority");
        Check(selectedDatagramBytes<=PacketCodec.MaximumDatagramBytes,
              "source-backed weapon switch reply fits authenticated UDP datagram: "+selectedDatagramBytes);
        var switchAim=switching.CombatPose(two).Collision.Parts[1].Center;
        var switchShot=switching.Command(one,new() {CommandId=3,Fire=new()
            {TargetX=switchAim.X,TargetY=switchAim.Y,TargetZ=switchAim.Z}});
        Check(switchShot.Code=="shot-scheduled","switched source rifle enters its firing path");
        switching.Advance(61);
        int famasFamily=content.Bindings.Get(famas.SourceId).AnimationFamily;
        int famasFirst=famasFamily switch {0=>2,9=>8,13=>14,15=>20,_=>throw new Exception("Unknown FAMAS family.")};
        Check(switching.Snapshot().Players[0].RiflePose.Layers.Any(l=>(int)l.Clip>=famasFirst&&(int)l.Clip<famasFirst+6),
              "weapon switch replaces the recovered animation family");
        Check(switching.Command(one,new() {CommandId=4,MoveCover=new() {Direction=1}}).Code=="moving" &&
              switching.Command(one,new() {CommandId=5,SwitchWeapon=new() {Slot=0}}).Code=="moving",
              "weapon switching is rejected during authoritative cover movement");
        MatchCommand Ready()=>new() {CommandId=1,Ready=new() {ManifestHash=engine.ManifestHash}};
        engine.Command(one,Ready());engine.Command(two,Ready());engine.Advance(60);
        engine.Advance(60); // Repeated host observation does not double-step animation.
        MatchCommand Fire(ulong id,Vector3 target)=>new() {CommandId=id,Fire=new() {TargetX=target.X,TargetY=target.Y,TargetZ=target.Z}};
        var command=Fire(2,engine.CombatPose(two).Collision.Parts[1].Center);
        var scheduled=engine.Command(one,command);
        Check(scheduled.Code=="shot-scheduled" && scheduled.Snapshot.Players[0].ShotsFired==0,"live source first shot schedules without ammo debit");
        Check(engine.Command(one,command).Equals(scheduled),"scheduled command replay does not reschedule");
        VerifyPose(); // Instruction changes do not claim a pose before it is sampled.
        engine.Command(two,Fire(2,engine.CombatPose(one).Collision.Parts[1].Center));
        for(ulong tick=61;tick<=64;tick++)engine.Advance(tick);
        Check(engine.Snapshot().Players[0].ShotsFired==1,"delayed shot fires after source uncover wait");
        ulong id=3;
        for(ulong tick=65;tick<=240;tick++)
        {
            engine.Advance(tick);
            VerifyPose();
            if(tick%8==0)
            {
                engine.Command(one,Fire(id,engine.CombatPose(two).Collision.Parts[1].Center));
                engine.Command(two,Fire(id++,engine.CombatPose(one).Collision.Parts[1].Center));
            }
        }
        var result=engine.Snapshot();
        Check(result.Players.Any(p=>p.Health<1000),"source map live projectile collision causes health loss: "+result);
        Check(result.Players.Any(p=>p.ConfirmedPlayerHits>0) && result.Players.All(p=>p.ConfirmedPlayerHits<=p.ShotsFired),
            "confirmed impacts are owned by the actual shooter");
        Check(!result.RewardEligible,"live rifle checkpoint never grants rewards");
        var firstEvents=engine.EventBatch(one,0);
        var replayEvents=engine.EventBatch(one,0);
        Check(firstEvents.Code=="events" && firstEvents.Equals(replayEvents) && firstEvents.Events.Count is >0 and <=4,
            "same unacknowledged event cursor replays the exact first batch");
        List<MatchEvent> DrainEvents(string playerId)
        {
            var delivered=new List<MatchEvent>();ulong cursor=0;
            for(int page=0;page<256;page++)
            {
                var batch=engine.EventBatch(playerId,cursor);
                Check(batch.Code=="events" && batch.Events.Count<=4,"bounded event page");
                var packet=new Packet {Version=1,SessionId=ulong.MaxValue,Sequence=ulong.MaxValue,
                    MatchEventBatch=batch};
                Check(War.Protocol.Transport.PacketCodec.Encode(packet,new byte[32]).Length<=1200,
                    "event page fits authenticated datagram");
                if(batch.Events.Count==0)return delivered;
                foreach(var eventRow in batch.Events)
                {
                    Check(eventRow.EventId==cursor+1,"contiguous source event IDs");
                    cursor=eventRow.EventId;delivered.Add(eventRow);
                }
            }
            throw new Exception("Event drain did not terminate.");
        }
        var receivedA=DrainEvents(one);
        var receivedB=DrainEvents(two);
        Check(receivedA.Count==receivedB.Count && receivedA.Count>0 &&
            receivedA.Zip(receivedB).All(pair=>pair.First.Equals(pair.Second)),
            "both participants receive identical host-owned event history");
        Check(receivedA.Any(e=>e.Kind==MatchEventKind.Shot) && receivedA.Any(e=>e.Kind==MatchEventKind.Impact),
            "accepted shots and resolved impacts have separate event identities");
        Check(engine.EventBatch(one,0).Code=="cursor-expired" &&
            engine.EventBatch(one,(ulong)receivedA.Count+1).Code=="invalid-cursor",
            "acknowledged history expires explicitly and future cursors fail closed");
        var detached=engine.Snapshot();detached.Players[0].RiflePose.Layers.Clear();
        Check(engine.Snapshot().Players[0].RiflePose.Layers.Count>0,"snapshot cannot mutate pose authority");
        var largest=result.Clone();largest.MatchId=new string('m',64);largest.ServerTick=largest.StartTick=largest.EndTick=largest.StateRevision=ulong.MaxValue;
        largest.TerminalReason="opponent-disconnected";largest.WinnerPlayerId=one;
        foreach(var p in largest.Players)
        {
            p.ClipAmmo=p.ReserveAmmo=p.CoverIndex=int.MinValue;
            p.ReloadEndTick=p.NextFireTick=p.ShotsFired=p.LastCommandId=p.MoveEndTick=p.DamageRevision=ulong.MaxValue;
            p.PositionX=p.PositionY=p.PositionZ=p.Health=p.MaxHealth=float.MaxValue;
            p.Admitted=p.Ready=p.Moving=p.CombatEnabled=p.Dead=true;p.LastGeometryHit=new string('a',64);
            p.RiflePose=RiflePoseProjection.Create(ulong.MaxValue,Enumerable.Range(0,4).Select(_=>new RifleClipLayer(new("player_right_coverBack3",86400,1,true),.25f)).ToArray(),
                new(.5f,.5f,.5f,.5f),new(.5f,.5f,.5f,.5f),new(.5f,.5f,.5f,.5f),
                new(new("shootAdditive",86400,1,false),1));
        }
        var maximumPacket=new Packet {Version=1,SessionId=ulong.MaxValue,Sequence=ulong.MaxValue,Ack=ulong.MaxValue,AckBits=uint.MaxValue,
            MatchReply=new() {CommandId=ulong.MaxValue,Code="moving-combat-not-supported",Snapshot=largest}};
        Check(War.Protocol.Transport.PacketCodec.Encode(maximumPacket,new byte[32]).Length<=1200,
            "four-layer plus upper-body two-player worst-width pose envelope fits MTU: "+maximumPacket.CalculateSize());
        var maximumBarrels=new MatchBarrelBatch {MatchId=new string('m',64),
            ManifestHash=new string('a',64),StateRevision=ulong.MaxValue,SourceCount=10,MaxHealth=56};
        for(int i=0;i<10;i++)maximumBarrels.Changed.Add(new BattleBarrelState
        {ColliderIndex=int.MaxValue,GameObjectFileId=int.MaxValue,Health=float.MaxValue,
            Destroyed=true,Revision=uint.MaxValue});
        Check(War.Protocol.Transport.PacketCodec.Encode(new Packet {Version=1,SessionId=ulong.MaxValue,
            Sequence=ulong.MaxValue,Ack=ulong.MaxValue,AckBits=uint.MaxValue,
            MatchBarrelBatch=maximumBarrels},new byte[32]).Length<=1200,
            "all ten changed barrels fit their separate authenticated datagram");
        var maximumArmy=new MatchArmyEntityBatch {MatchId=new string('m',64),
            ManifestHash=new string('a',64),Revision=ulong.MaxValue,Code="entities",
            ActiveCount=10000,HasMore=true};
        for(int i=0;i<4;i++)maximumArmy.Entities.Add(new BattleArmyEntityState
        {EntityKey=ulong.MaxValue-(ulong)(3-i),OwnerPlayerId=new string('a',32),OwnerFraction=2,
            LocalEntityId=int.MaxValue,OptionIndex=47,UnitId="ID_UNIT-"+new string('A',40),
            SpawnComponentFileId=int.MaxValue,ReservationFileId=int.MaxValue,
            X=float.MaxValue,Y=float.MaxValue,Z=float.MaxValue,SpawnTick=ulong.MaxValue,
            MaxHealth=float.MaxValue,Health=float.MaxValue});
        Check(War.Protocol.Transport.PacketCodec.Encode(new Packet {Version=1,SessionId=ulong.MaxValue,
            Sequence=ulong.MaxValue,Ack=ulong.MaxValue,AckBits=uint.MaxValue,
            MatchArmyEntityBatch=maximumArmy},new byte[32]).Length<=1200,
            "four maximum-width army entities fit one authenticated UDP page");
        var maximumEvents=new MatchEventBatch {MatchId=new string('m',64),ManifestHash=new string('a',64),
            LatestEventId=ulong.MaxValue,Code="events"};
        for(int i=0;i<4;i++)maximumEvents.Events.Add(new MatchEvent {EventId=ulong.MaxValue-(ulong)(3-i),
            Tick=ulong.MaxValue,Kind=MatchEventKind.Terminal,ActorId=new string('a',32),TargetId=new string('b',32),
            ProjectileId=ulong.MaxValue,X=float.MaxValue,Y=float.MaxValue,Z=float.MaxValue,Health=float.MaxValue,
            Reason=new string('r',64)});
        var maximumEventPacket=new Packet {Version=1,SessionId=ulong.MaxValue,Sequence=ulong.MaxValue,
            Ack=ulong.MaxValue,AckBits=uint.MaxValue,MatchEventBatch=maximumEvents};
        Check(War.Protocol.Transport.PacketCodec.Encode(maximumEventPacket,new byte[32]).Length<=1200,
            "four-event worst-width page fits authenticated MTU");
        foreach(var row in maximumEvents.Events)
        {
            row.Kind=MatchEventKind.BarrelDestroyed;
            row.BarrelColliderIndex=int.MaxValue;
            row.BarrelGameObjectFileId=int.MaxValue;
            row.SourceBarrelColliderIndex=-1;
            row.BarrelRevision=uint.MaxValue;
        }
        Check(War.Protocol.Transport.PacketCodec.Encode(maximumEventPacket,new byte[32]).Length<=1200,
            "four source-ID barrel events fit authenticated MTU at worst field widths");
        foreach(var row in maximumEvents.Events)
        {
            row.Kind=MatchEventKind.ArmyDied;
            row.ArmyEntityId=int.MaxValue;row.ArmyOptionIndex=47;
            row.ArmyUnitId="ID_UNIT-"+new string('A',40);
            row.ArmySpawnComponentFileId=int.MaxValue;
            row.ArmyReservationFileId=int.MaxValue;
            row.ArmyEnergyRecipientId=new string('c',32);
        }
        Check(maximumEventPacket.CalculateSize()+War.Protocol.Transport.PacketCodec.MacBytes>1200,
            "four maximum-width army death events expose the fixed-count MTU gap");
        var fittedArmyEvents=new MatchEventBatch {MatchId=maximumEvents.MatchId,
            ManifestHash=maximumEvents.ManifestHash,LatestEventId=maximumEvents.LatestEventId,Code="events"};
        MatchEngine.AppendFittingEvents(fittedArmyEvents,maximumEvents.Events);
        var fittedPacket=new Packet {Version=1,SessionId=ulong.MaxValue,Sequence=ulong.MaxValue,
            Ack=ulong.MaxValue,AckBits=uint.MaxValue,MatchEventBatch=fittedArmyEvents};
        var remainingArmyEvents=maximumEvents.Events.Where(x=>x.EventId>fittedArmyEvents.Events[^1].EventId).ToArray();
        Check(fittedArmyEvents.Events.Count is >0 and <4 &&
              War.Protocol.Transport.PacketCodec.Encode(fittedPacket,new byte[32]).Length<=1200 &&
              remainingArmyEvents.Length==4-fittedArmyEvents.Events.Count &&
              remainingArmyEvents[0].EventId==fittedArmyEvents.Events[^1].EventId+1,
            "expanded event rows page below MTU without skipping the next cursor");
        var travel=engine.Command(one,new() {CommandId=id,MoveCover=new() {Direction=1}});
        Check(travel.Code=="moving" && travel.Snapshot.Players[0].Moving,"live rifle cover move uses source route");
        var walkingResponse=engine.Command(one,Fire(id+1,engine.CombatPose(two).Collision.Parts[1].Center));
        Check(walkingResponse.Code!="moving","walking rifle fire reaches normal cadence and ammo authorization");
        var startPosition=engine.Snapshot().Players[0];
        ulong arrival=travel.Snapshot.Players[0].MoveEndTick;
        bool observedRun=false;
        for(ulong step=241;step<=arrival;step++)
        {
            engine.Advance(step);
            var player=engine.Snapshot().Players[0];
            if(player.Moving)
            {
                int expected=content.Bindings.Get(weapon.SourceId).AnimationFamily switch {0=>26,9=>27,13=>28,15=>29,_=>0};
                Check(player.RiflePose.Layers.Count==1 && (int)player.RiflePose.Layers[0].Clip==expected,
                    "moving collider and SDK snapshot use source run clip");
                if(Vector3.Distance(new(player.PositionX,player.PositionY,player.PositionZ),new(startPosition.PositionX,startPosition.PositionY,startPosition.PositionZ))>.01f)
                {
                    VerifyPose();
                    if(!observedRun)
                    {
                        var current=engine.CombatPose(one);
                        var collision=new ShotCollisionWorld(null,[new(one,current.Collision),new(two,engine.CombatPose(two).Collision)]);
                        var head=current.Collision.Parts[1].Center;
                        Check(collision.Raycast(two,head+Vector3.UnitY*2,-Vector3.UnitY,4)?.PlayerId==one,
                            "moving run hitbox remains a host collision target");
                    }
                    observedRun=true;
                }
            }
        }
        Check(observedRun && !engine.Snapshot().Players[0].Moving && engine.Snapshot().Players[0].CoverIndex==2,
            "moving rifle reaches adjacent cover with sampled dynamic hitboxes");
        VerifyPose();
        var walking=new MatchEngine(manifest with {MatchId="rifle-walking"},map,content);
        walking.Admit(one);walking.Admit(two);
        walking.Command(one,new() {CommandId=1,Ready=new() {ManifestHash=walking.ManifestHash}});
        walking.Command(two,new() {CommandId=1,Ready=new() {ManifestHash=walking.ManifestHash}});
        walking.Advance(60);
        Check(walking.Command(one,new() {CommandId=2,MoveCover=new() {Direction=1}}).Code=="moving","walking test route admitted");
        walking.Advance(61);
        int startingAmmo=walking.Snapshot().Players[0].ClipAmmo;
        var walkingAim=walking.CombatPose(two).Collision.Parts[1].Center;
        var walkingTrigger=walking.Command(one,Fire(3,walkingAim));
        Check(walkingTrigger.Code=="shot-scheduled" && walkingTrigger.Snapshot.Players[0].ClipAmmo==startingAmmo,
            "first walking shot schedules before ammo debit: "+walkingTrigger.Code);
        walking.Advance(62);
        var walkingPose=walking.Snapshot().Players[0].RiflePose;
        Check(walkingPose.UpperBodyLayer!=null &&
            walkingPose.UpperBodyLayer.Weight>0,"moving snapshot carries source upper-body firing layer");
        for(ulong step=63;step<=65;step++)walking.Advance(step);
        Check(walking.Snapshot().Players[0].ShotsFired==1 && walking.Snapshot().Players[0].ClipAmmo==startingAmmo-1,
            "walking delayed shot consumes exactly one round");
        Check(!walking.Snapshot().RewardEligible,"walking shot remains unscored");
        var afterCover=new MatchEngine(manifest with {MatchId="rifle-walking-after-cover"},map,content);
        afterCover.Admit(one);afterCover.Admit(two);
        afterCover.Command(one,new() {CommandId=1,Ready=new() {ManifestHash=afterCover.ManifestHash}});
        afterCover.Command(two,new() {CommandId=1,Ready=new() {ManifestHash=afterCover.ManifestHash}});
        afterCover.Advance(60);
        Check(afterCover.Command(one,Fire(2,afterCover.CombatPose(two).Collision.Parts[1].Center)).Code=="shot-scheduled",
            "covered first click schedules");
        for(ulong step=61;step<=70;step++)afterCover.Advance(step);
        Check(afterCover.Snapshot().Players[0].ShotsFired==1,"covered first shot completes before swipe");
        Check(afterCover.Command(one,new() {CommandId=3,MoveCover=new() {Direction=1}}).Code=="moving",
            "post-shot swipe starts source cover route");
        afterCover.Advance(71);
        var afterCoverAim=afterCover.CombatPose(two).Collision.Parts[1].Center;
        var afterCoverClick=afterCover.Command(one,Fire(4,afterCoverAim));
        Check(afterCoverClick.Code=="shot-scheduled" && afterCoverClick.Snapshot.Players[0].ShotsFired==1,
            "clicked cover move resets first walking shot rather than firing immediately: "+afterCoverClick.Code);
        var pendingMove=new MatchEngine(manifest with {MatchId="rifle-pending-move"},map,content);
        pendingMove.Admit(one);pendingMove.Admit(two);
        pendingMove.Command(one,new() {CommandId=1,Ready=new() {ManifestHash=pendingMove.ManifestHash}});
        pendingMove.Command(two,new() {CommandId=1,Ready=new() {ManifestHash=pendingMove.ManifestHash}});
        pendingMove.Advance(60);
        var pendingTarget=pendingMove.CombatPose(two).Collision.Parts[1].Center;
        Check(pendingMove.Command(one,Fire(2,pendingTarget)).Code=="shot-scheduled","covered shot is pending before swipe");
        Check(pendingMove.Command(one,new() {CommandId=3,MoveCover=new() {Direction=1}}).Code=="moving",
            "swipe starts while covered shot is pending");
        int pendingAmmo=pendingMove.Snapshot().Players[0].ClipAmmo;
        for(ulong step=61;step<=65;step++)pendingMove.Advance(step);
        Check(pendingMove.Snapshot().Players[0].ShotsFired==1 && pendingMove.Snapshot().Players[0].ClipAmmo==pendingAmmo-1,
            "pending covered shot survives cover move and debits one round at source deadline");
        var lethalPlayers=manifest.Players.ToArray();
        lethalPlayers[0]=lethalPlayers[0] with {Combat=new PlayerCombatManifest(1)};
        var lethal=new MatchEngine(manifest with {MatchId="rifle-lethal",Players=lethalPlayers},map,content);
        lethal.Admit(one);lethal.Admit(two);
        lethal.Command(one,new() {CommandId=1,Ready=new() {ManifestHash=lethal.ManifestHash}});
        lethal.Command(two,new() {CommandId=1,Ready=new() {ManifestHash=lethal.ManifestHash}});
        lethal.Advance(60);
        lethal.Command(one,Fire(2,lethal.CombatPose(two).Collision.Parts[1].Center));
        lethal.Command(two,Fire(2,lethal.CombatPose(one).Collision.Parts[1].Center));
        for(ulong step=61,commandId=3;step<240&&!lethal.Terminal;step++)
        {
            lethal.Advance(step);
            if(!lethal.Terminal && step%8==0)
            {
                lethal.Command(one,Fire(commandId,lethal.CombatPose(two).Collision.Parts[1].Center));
                lethal.Command(two,Fire(commandId++,lethal.CombatPose(one).Collision.Parts[1].Center));
            }
        }
        var lethalResult=lethal.Snapshot();
        Check(lethalResult.TerminalReason=="player-killed" && lethalResult.WinnerPlayerId==two,
            "source projectile resolves lethal winner: "+lethalResult);
        Check(lethalResult.Players[1].ConfirmedPlayerKills==1 && lethalResult.Players[1].ConfirmedPlayerHits>=1 &&
            lethalResult.Players[0].ConfirmedPlayerKills==0 && !lethalResult.RewardEligible,
            "lethal impact credits exactly one kill to shooter without creating reward authority");
        var lethalEvents=lethal.EventBatch(one,0);
        Check(lethalEvents.Code=="events" && lethalEvents.LatestEventId>=3,
            "lethal match retains event cursor after terminal state");
        ulong lethalCursor=0;var lethalHistory=new List<MatchEvent>();
        for(int page=0;page<128;page++)
        {
            var batch=lethal.EventBatch(one,lethalCursor);
            if(batch.Events.Count==0)break;
            lethalHistory.AddRange(batch.Events);
            lethalCursor=batch.Events[^1].EventId;
        }
        Check(lethalHistory.Count(e=>e.Kind==MatchEventKind.PlayerDeath)==1 &&
            lethalHistory.Count(e=>e.Kind==MatchEventKind.Terminal)==1 &&
            lethalHistory[^2].Kind==MatchEventKind.PlayerDeath && lethalHistory[^1].Kind==MatchEventKind.Terminal,
            "lethal player death precedes one terminal event");
        string? renderOutput=Environment.GetEnvironmentVariable("WAR_RIFLE_RENDER_FIXTURE");
        foreach(int layerCount in new[] {2,4})
        {
            var layers=Enumerable.Range(0,layerCount).Select(i=>new RifleClipLayer(new("player_look_right3",i/30d,1,false),1f/layerCount)).ToArray();
            var root=Quaternion.CreateFromAxisAngle(Vector3.UnitY,.7f);var body=Quaternion.CreateFromAxisAngle(Vector3.UnitY,.2f);
            var upper=Quaternion.CreateFromAxisAngle(Vector3.UnitX,-.3f);var position=new Vector3(3,0,4);
            var sampled=content.Poses.SampleLayers(layers,body,upper).Place(position,root);
            var state=new BattlePlayerState {PlayerId=one,PositionX=3,PositionZ=4,RiflePose=RiflePoseProjection.Create(0,layers,root,body,upper)};
            static float[] V(Vector3 v)=>[v.X,v.Y,v.Z];
            renderCases.Add(new {player=JsonFormatter.Default.Format(state),parts=sampled.Collision.Parts.Select(p=>V(p.Center)).ToArray(),muzzle=V(sampled.Muzzle(weapon.SourceId).Position)});
        }
        foreach(var family in new[] {(Id:"Google2u.AssaultRifle_QBZ95",Suffix:"_qbz"),
            (Id:"Google2u.AssaultRifle_SteyrAUG",Suffix:"_qbz2"),(Id:"Google2u.AssaultRifle_G36",Suffix:"_shotgun")})
        foreach(var clip in new[] {"player_look_left","player_fire_left","player_left_coverBack",
            "player_look_right","player_fire_right","player_right_coverBack"})
        {
            var layers=new[] {new RifleClipLayer(new(clip+family.Suffix,.1,1,false),1)};
            var position=new Vector3(3,0,4);
            var sample=content.Poses.SampleLayers(layers,Quaternion.Identity).Place(position,Quaternion.Identity);
            var state=new BattlePlayerState {PlayerId=one,PositionX=3,PositionZ=4,
                RiflePose=RiflePoseProjection.Create(0,layers,Quaternion.Identity,Quaternion.Identity,null)};
            static float[] V(Vector3 v)=>[v.X,v.Y,v.Z];
            renderCases.Add(new {player=JsonFormatter.Default.Format(state),parts=sample.Collision.Parts.Select(p=>V(p.Center)).ToArray(),
                muzzle=V(sample.Muzzle(family.Id).Position),inventoryIndex=content.Bindings.Get(family.Id).InventoryIndex});
        }
        foreach(var family in new[] {(Id:"Google2u.AssaultRifle_AK47",Clip:"run"),
            (Id:"Google2u.AssaultRifle_QBZ95",Clip:"qbz_run"),
            (Id:"Google2u.AssaultRifle_SteyrAUG",Clip:"qbz2_run"),
            (Id:"Google2u.AssaultRifle_G36",Clip:"shotgunner_run")})
        {
            var layers=new[] {new RifleClipLayer(new(family.Clip,.2,1,true),1)};
            var position=new Vector3(3,0,4);
            var sample=content.Poses.SampleLayers(layers,Quaternion.Identity).Place(position,Quaternion.Identity);
            var state=new BattlePlayerState {PlayerId=one,PositionX=3,PositionZ=4,
                RiflePose=RiflePoseProjection.Create(0,layers,Quaternion.Identity,Quaternion.Identity,null)};
            static float[] V(Vector3 v)=>[v.X,v.Y,v.Z];
            renderCases.Add(new {player=JsonFormatter.Default.Format(state),parts=sample.Collision.Parts.Select(p=>V(p.Center)).ToArray(),
                muzzle=V(sample.Muzzle(family.Id).Position),inventoryIndex=content.Bindings.Get(family.Id).InventoryIndex});
        }
        if(!string.IsNullOrEmpty(renderOutput))File.WriteAllText(renderOutput,JsonSerializer.Serialize(new {sceneHash=content.Stats.SceneRevision,
            inventoryIndex=content.Bindings.Get(weapon.SourceId).InventoryIndex,cases=renderCases}));
        return count;
    }
}

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
using War.Protocol;

internal static class SniperCatalogTests
{
    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;void Check(bool value,string name){checks++;if(!value)throw new Exception("FAIL: "+name);}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,null,null,
            Path.Combine(directory,"sniper-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=content.Snipers!.CreateManifest("Google2u.SniperRifle_M24",0);
        var manifest=new MatchManifest("sniper-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.SniperRevision!,MatchManifest.SniperCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-sniper-"+Guid.NewGuid().ToString("N")+".json");
        string outbox=Path.Combine(Path.GetTempPath(),"war-sniper-outbox-"+Guid.NewGuid().ToString("N"));File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,["Battle:ResultOutboxPath"]=outbox,
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:SniperContentManifestPath"]=Path.Combine(directory,"sniper-content-manifest.json")
        }).Build();
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,MatchId=manifest.MatchId,ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(20));
            using var a=new MatchConnection(Grant(one,2991));using var b=new MatchConnection(Grant(two,2992));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&(await b.ConnectAsync(timeout.Token)).Code=="admitted","sniper UDP admission");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);MatchReply state;
            do{await Task.Delay(50,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Phase!=BattlePhase.Running);
            var target=content.Poses.SampleBlended("sniper_idle",0,true,"sniper_idle",0,true,0).Place(covers[1].Position,covers[1].Rotation).Collision.Parts[1].Center;
            Check((await a.SniperAimAsync(true,false,target.X,target.Y,target.Z,timeout.Token)).Code=="sniper-aiming","typed UDP sniper press");
            do{await Task.Delay(35,timeout.Token);state=await a.PollAsync(timeout.Token);}while(!state.Snapshot.Players[0].SniperScopeVisible);
            Check(state.Snapshot.Players[0].SniperAiming,"Worker publishes authoritative sniper scope gate");
            Check((await a.SniperAimAsync(false,false,0,0,0,timeout.Token)).Code=="shot-accepted","typed UDP sniper release");
            state=await a.PollAsync(timeout.Token);
            Check(!state.Snapshot.Players[0].SniperAiming&&!state.Snapshot.Players[0].SniperScopeVisible&&state.Snapshot.Players[0].ShotsFired==1&&state.Snapshot.Players[0].ClipAmmo==weapon.ClipSize-1,
                "Worker publishes one sniper shot and closes scope");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);if(Directory.Exists(outbox))Directory.Delete(outbox,true);}
        Console.WriteLine($"PASS: {checks} live sniper UDP assertions");return checks;
    }

    internal static int Run(string directory)
    {
        int checks=0;void Check(bool value,string name){checks++;if(!value)throw new Exception("FAIL: "+name);}
        var catalog=SniperCatalog.Load(Path.Combine(directory,"sniper-content-manifest.json"));
        Check(catalog.WeaponCount==8&&catalog.StageCount==428,"complete sniper package");
        var expected=new Dictionary<string,(int Count,int Index)>{{"Google2u.SniperRifle_AWMF",(46,21)},{"Google2u.SniperRifle_Dragunov",(36,14)},
            {"Google2u.SniperRifle_M110",(56,10)},{"Google2u.SniperRifle_M110Elite",(56,64)},{"Google2u.SniperRifle_M24",(26,2)},
            {"Google2u.SniperRifle_M90",(66,32)},{"Google2u.SniperRifle_M90Elite",(66,46)},{"Google2u.SniperRifle_MSR",(76,59)}};
        foreach(var pair in expected)
        {
            var binding=catalog.Binding(pair.Key);Check(binding.InventoryIndex==pair.Value.Index&&binding.AnimationFamily==10&&
                binding.ScopeShowSeconds==.17f&&binding.ZoomThresholdSeconds==.2f&&binding.ZoomMovementThreshold==750&&
                binding.Speed==80&&binding.CheckDistance==1,$"sniper binding {pair.Key}");
            Check(catalog.Stage(pair.Key,pair.Value.Count-1).Index==pair.Value.Count-1,$"sniper lane {pair.Key}");
        }
        var m24=catalog.Stage("Google2u.SniperRifle_M24",0);
        Check(m24.ClipSize==5&&m24.ReserveAmmo==12&&m24.ReloadSeconds==8.2f&&m24.Damage==95.2f&&m24.CadenceSeconds==2&&m24.CriticalProbability==.08f,
            "M24 source stage");
        var aim=new SniperAimState();var target=new Vector3(1,2,3);aim.Press(10,target,true);
        Check(aim.Release(15,.17f,false)==null,"sniper release before strict scope gate");
        aim.Press(10,target,true);aim.Update(new(4,5,6));Check(aim.Release(16,.17f,false)==new Vector3(4,5,6),"sniper release after scope gate");
        aim.Press(20,target,false);aim.Arm(25);Check(aim.Release(31,.17f,false)==target,"sniper scope gate begins when cooldown becomes ready");
        aim.Press(20,target,true);Check(aim.Release(30,.17f,true)==null&&!aim.Active,"sniper swipe cancellation");
        try{catalog.Stage("Google2u.SniperRifle_M24",26);throw new Exception("FAIL: sniper stage bound");}catch(InvalidDataException){checks++;}
        var shot=catalog.Prepare("Google2u.SniperRifle_M24",0,1,new string('a',32),Vector3.Zero,Vector3.UnitZ,10,0,(_,_,_)=>null);
        Check(shot.Damage.Amount==m24.Damage*catalog.Binding("Google2u.SniperRifle_M24").CriticalMultiplier&&shot.WeaponSourceId=="Google2u.SniperRifle_M24",
            "sniper projectile and critical authority");
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,null,null,
            Path.Combine(directory,"sniper-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=catalog.CreateManifest("Google2u.SniperRifle_M24",0);
        var matchManifest=new MatchManifest("sniper-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.SniperRevision!,MatchManifest.SniperCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        var match=new MatchEngine(matchManifest,map,content);match.Admit(one);match.Admit(two);
        match.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});
        match.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});match.Advance(60);
        Vector3 liveAim=match.CombatPose(two).Collision.Parts[1].Center;
        Check(match.Command(one,new(){CommandId=2,Fire=new(){TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="wrong-fire-mode",
            "sniper rejects ordinary fire transport");
        Check(match.Command(one,new(){CommandId=3,SniperAim=new(){Pressed=true,TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="sniper-aiming",
            "sniper press starts scoped gesture");
        match.Advance(61);match.Advance(62);match.Advance(63);match.Advance(64);match.Advance(65);
        Check(match.Command(one,new(){CommandId=4,SniperAim=new(){Pressed=false}}).Code=="sniper-cancelled"&&match.Snapshot().Players[0].ShotsFired==0,
            "sniper early release does not fire");
        Check(match.Command(one,new(){CommandId=5,SniperAim=new(){Pressed=true,TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="sniper-aiming",
            "sniper can aim again after cancellation");
        for(ulong tick=66;tick<=71;tick++)match.Advance(tick);
        Check(match.Command(one,new(){CommandId=6,SniperAim=new(){Pressed=false}}).Code=="shot-accepted"&&match.Snapshot().Players[0].ShotsFired==1&&match.Snapshot().Players[0].ClipAmmo==weapon.ClipSize-1,
            "scoped sniper release fires exactly one authoritative projectile");
        Check(match.Snapshot().Players[0].RiflePose.Layers.All(x=>(int)x.Clip is >=46 and <=53),
            "sniper family pose crosses protobuf boundary");
        Check(match.Command(one,new(){CommandId=7,SniperAim=new(){Pressed=true,TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="sniper-aiming",
            "sniper can begin aiming during weapon cooldown");
        for(ulong tick=72;tick<=131;tick++)match.Advance(tick);
        Check(match.Command(one,new(){CommandId=8,SniperAim=new(){Pressed=false}}).Code=="sniper-cancelled"&&match.Snapshot().Players[0].ShotsFired==1,
            "cooldown completion starts a fresh scope visibility gate");
        Check(match.Command(one,new(){CommandId=9,SniperAim=new(){Pressed=true,TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="sniper-aiming",
            "sniper cancellation resets gesture state");
        for(ulong tick=132;tick<=137;tick++)match.Advance(tick);
        Check(match.Command(one,new(){CommandId=10,SniperAim=new(){Pressed=false,Cancelled=true}}).Code=="sniper-cancelled"&&match.Snapshot().Players[0].ShotsFired==1,
            "sniper swipe release never fires");
        Console.WriteLine($"PASS: {checks} sniper catalog/gesture assertions");return checks;
    }
}

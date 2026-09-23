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

internal static class MinigunCatalogTests
{
    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;void Check(bool value,string name){checks++;if(!value)throw new Exception("FAIL: "+name);}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,null,
            Path.Combine(directory,"minigun-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=content.Minigun!.CreateManifest(0);
        var manifest=new MatchManifest("minigun-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.MinigunRevision!,MatchManifest.MinigunCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-minigun-"+Guid.NewGuid().ToString("N")+".json");
        string outbox=Path.Combine(Path.GetTempPath(),"war-minigun-outbox-"+Guid.NewGuid().ToString("N"));File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,["Battle:ResultOutboxPath"]=outbox,
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:MinigunContentManifestPath"]=Path.Combine(directory,"minigun-content-manifest.json")
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
            using var a=new MatchConnection(Grant(one,1991));using var b=new MatchConnection(Grant(two,1992));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&(await b.ConnectAsync(timeout.Token)).Code=="admitted","minigun UDP admission");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);MatchReply state;
            do{await Task.Delay(80,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Phase!=BattlePhase.Running);
            var target=content.Poses.SampleBlended("minigun_idle",0,true,"minigun_idle",0,true,0).Place(covers[1].Position,covers[1].Rotation).Collision.Parts[1].Center;
            Check((await a.MinigunHoldAsync(true,target.X,target.Y,target.Z,timeout.Token)).Code=="minigun-spinning","typed UDP minigun press");
            do{await Task.Delay(80,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Players[0].ShotsFired<2);
            Check(state.Snapshot.Players[0].MinigunHeld&&state.Snapshot.Players[0].ClipAmmo<weapon.ClipSize,"Worker publishes held minigun and finite ammo");
            Check((await a.MinigunHoldAsync(false,0,0,0,timeout.Token)).Code=="minigun-released","typed UDP minigun release");
            state=await a.PollAsync(timeout.Token);ulong shots=state.Snapshot.Players[0].ShotsFired;
            await Task.Delay(400,timeout.Token);state=await a.PollAsync(timeout.Token);
            Check(!state.Snapshot.Players[0].MinigunHeld&&state.Snapshot.Players[0].ShotsFired==shots,"release stops live Worker minigun");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);if(Directory.Exists(outbox))Directory.Delete(outbox,true);}
        Console.WriteLine($"PASS: {checks} live minigun UDP assertions");return checks;
    }

    internal static int Run(string directory)
    {
        int checks=0;void Check(bool value,string name){checks++;if(!value)throw new Exception("FAIL: "+name);}
        var catalog=MinigunCatalog.Load(Path.Combine(directory,"minigun-content-manifest.json"));
        Check(catalog.StageCount==36,"minigun complete stage lane");
        var first=catalog.Stage(0);var last=catalog.Stage(35);
        Check(first.Ammo==200&&first.Damage==19f&&first.HeatSeconds==2f,"minigun first stage source values");
        Check(last.Ammo==242&&last.Damage==183.6f&&last.HeatSeconds==2f,"minigun last stage source values");
        Check(first.CadenceSeconds==.1f&&first.CriticalProbability==0&&first.PlayerDamageRatio==.4085f&&first.OvertimePlayerDamageRatio==.33f,"minigun weapon definition");
        Check(catalog.Binding.InventoryIndex==25&&catalog.Binding.AnimationFamily==4&&catalog.Binding.SpinUpSeconds==.1f&&catalog.Binding.SerializedCoolDownSeconds==5f,"minigun scene binding");
        var manifest=catalog.CreateManifest(0);
        Check(manifest.ClipSize==200&&manifest.ReserveAmmo==0&&Math.Abs(manifest.CadenceSeconds-.1)<.000001,"minigun non-reloadable pool projection");
        try{catalog.Stage(36);throw new Exception("FAIL: minigun stage bound");}catch(InvalidDataException){checks++;}
        var state=new MinigunFireState();var target=new Vector3(1,2,3);state.Press(10,target);
        Check(state.Due(13,first,catalog.Binding)==null,"minigun strict spin-up boundary");
        Check(state.Due(14,first,catalog.Binding)==target,"minigun first accelerated shot");
        state.ShotAccepted(14,first);
        Check(state.Due(22,first,catalog.Binding)==null&&state.Due(23,first,catalog.Binding)==target,"minigun source dynamic lock");
        state.ShotAccepted(23,first);
        state.UpdateTarget(new Vector3(4,5,6));state.Release();
        Check(state.Due(100,first,catalog.Binding)==null,"minigun release stops fire");
        try{state.Press(1,new(float.NaN,0,0));throw new Exception("FAIL: minigun finite target");}catch(InvalidDataException){checks++;}
        var shot=catalog.Prepare(0,1,"00000000000000000000000000000001",Vector3.Zero,Vector3.UnitZ,10,0,(_,_,_)=>null);
        Check(shot.WeaponSourceId==MinigunCatalog.SourceId&&shot.Damage.Amount==19f&&shot.Flight.Position==catalog.Binding.ShotOffset,"minigun projectile authority");
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,null,
            Path.Combine(directory,"minigun-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=catalog.CreateManifest(0);
        var matchManifest=new MatchManifest("minigun-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.MinigunRevision!,MatchManifest.MinigunCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        var match=new MatchEngine(matchManifest,map,content);match.Admit(one);match.Admit(two);
        match.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});
        match.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});match.Advance(60);
        Vector3 aim=match.CombatPose(two).Collision.Parts[1].Center;
        Check(match.Command(one,new(){CommandId=2,Fire=new(){TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}}).Code=="wrong-fire-mode",
            "minigun rejects click-fire transport");
        Check(match.Command(one,new(){CommandId=3,MinigunHold=new(){Pressed=true,TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}}).Code=="minigun-spinning",
            "minigun press starts host spin-up");
        for(ulong tick=61;tick<=110&&match.Snapshot().Players[0].ShotsFired<2;tick++)match.Advance(tick);
        var firing=match.Snapshot().Players[0];
        Check(firing.ShotsFired>=2&&firing.ClipAmmo==weapon.ClipSize-(int)firing.ShotsFired,
            "held minigun automatically consumes finite source ammunition");
        ulong releaseTick=match.Snapshot().ServerTick,releasedShots=firing.ShotsFired;
        Check(match.Command(one,new(){CommandId=4,MinigunHold=new(){Pressed=false}}).Code=="minigun-released",
            "minigun release accepted");
        for(ulong tick=releaseTick+1;tick<=releaseTick+20;tick++)match.Advance(tick);
        Check(match.Snapshot().Players[0].ShotsFired==releasedShots,"minigun release stops automatic fire");
        Check(match.Snapshot().Players[0].RiflePose.Layers.All(x=>(int)x.Clip is >=38 and <=45),
            "minigun family pose crosses protobuf boundary");
        Console.WriteLine($"PASS: {checks} minigun catalog/fire-state assertions");return checks;
    }
}

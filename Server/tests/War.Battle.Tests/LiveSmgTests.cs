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

internal static class LiveSmgTests
{
    internal static async Task RunUnity(string directory,string unityExe,string projectPath)
    {
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            Path.Combine(directory,"shotgun-content-manifest.json"),
            Path.Combine(directory,"smg-content-manifest.json"),Path.Combine(directory,"pistol-content-manifest.json"),
            Path.Combine(directory,"lmg-content-manifest.json"),Path.Combine(directory,"minigun-content-manifest.json"),
            Path.Combine(directory,"sniper-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string[] ids=[new string('a',32),new string('b',32)];var rifle=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var cpw=content.Smgs!.CreateManifest("Google2u.SMG_CPW",0);
        var p90=content.Smgs.CreateManifest("Google2u.SMG_P90",0);
        var pistol=content.Pistols!.CreateManifest("Google2u.Pistol_DesertEagle",0);
        var lmg=content.Lmgs!.CreateManifest("Google2u.LMG_M249",0);
        var minigun=content.Minigun!.CreateManifest(0);
        var sniper=content.Snipers!.CreateManifest("Google2u.SniperRifle_M24",0);
        ParticipantManifest Player(string id,int fraction,CoverNode cover)=>new(id,rifle,fraction,cover.SourceIndex,1,new(1000),0)
        {WeaponSlots=[new WeaponSlotManifest(0,11,rifle,0),new WeaponSlotManifest(1,18,cpw,0),
            new WeaponSlotManifest(2,35,p90,0),new WeaponSlotManifest(3,0,pistol,0),new WeaponSlotManifest(4,16,lmg,0),
            new WeaponSlotManifest(5,25,minigun,0),new WeaponSlotManifest(6,2,sniper,0)]};
        var manifest=new MatchManifest("smg-unity","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.MixedRevision!,MatchManifest.MixedCombatMode,120,60,120,
            [Player(ids[0],1,covers[0]),Player(ids[1],2,covers[1])]);
        string prefix=Path.Combine(Path.GetTempPath(),"war-smg-unity-"+Guid.NewGuid().ToString("N"));
        string manifestFile=prefix+".json",grantsFile=prefix+".jsonl",outbox=prefix+"-outbox";
        string unityLog=Path.GetFullPath("Server/.local/unity-live-smg.log");Directory.CreateDirectory(Path.GetDirectoryName(unityLog)!);
        await File.WriteAllTextAsync(manifestFile,JsonSerializer.Serialize(manifest));
        using var portProbe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;portProbe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        BattlePlayerView View(string id,string name,int fraction)
        {
            var view=new BattlePlayerView{PlayerId=id,DisplayName=name,Level=1,ArmyPower=1,Country="US",Fraction=fraction,DefendPosition=0};
            view.VisualIds.Add(["v0","v1","v2","v3"]);
            view.Weapons.Add(new BattleWeaponView{Slot=0,WeaponIndex=11,SourceId="Google2u.AssaultRifle_AK47",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView{Slot=1,WeaponIndex=18,SourceId="Google2u.SMG_CPW",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView{Slot=2,WeaponIndex=35,SourceId="Google2u.SMG_P90",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView{Slot=3,WeaponIndex=0,SourceId="Google2u.Pistol_DesertEagle",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView{Slot=4,WeaponIndex=16,SourceId="Google2u.LMG_M249",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView{Slot=5,WeaponIndex=25,SourceId="Google2u.LMG_Minigun",UpgradeIndex=0});
            view.Weapons.Add(new BattleWeaponView{Slot=6,WeaponIndex=2,SourceId="Google2u.SniperRifle_M24",UpgradeIndex=0});return view;
        }
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();var claim=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            var grant=new MatchConnectionGrant{Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,MatchId=claim.MatchId,
                ManifestHash=claim.ManifestHash,ExpiresUnixSeconds=claim.ExpiresUnixSeconds,Ticket=tokens.Sign(claim),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(claim))};
            grant.PlayerViews.Add(View(ids[0],"Left",1));grant.PlayerViews.Add(View(ids[1],"Right",2));return grant;
        }
        await File.WriteAllLinesAsync(grantsFile,[JsonFormatter.Default.Format(Grant(ids[0],981)),JsonFormatter.Default.Format(Grant(ids[1],982))]);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=manifestFile,["Battle:ResultOutboxPath"]=outbox,
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:ShotgunContentManifestPath"]=Path.Combine(directory,"shotgun-content-manifest.json"),
            ["Battle:SmgContentManifestPath"]=Path.Combine(directory,"smg-content-manifest.json")
            ,["Battle:PistolContentManifestPath"]=Path.Combine(directory,"pistol-content-manifest.json")
            ,["Battle:LmgContentManifestPath"]=Path.Combine(directory,"lmg-content-manifest.json")
            ,["Battle:MinigunContentManifestPath"]=Path.Combine(directory,"minigun-content-manifest.json")
            ,["Battle:SniperContentManifestPath"]=Path.Combine(directory,"sniper-content-manifest.json")
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);System.Diagnostics.Process? editor=null;
        try
        {
            await worker.StartAsync(CancellationToken.None);
            var start=new System.Diagnostics.ProcessStartInfo(unityExe){UseShellExecute=false,CreateNoWindow=true,
                WindowStyle=System.Diagnostics.ProcessWindowStyle.Hidden};
            foreach(var arg in new[]{"-batchmode","-nographics","-projectPath",projectPath,"-executeMethod","SelfHostedLiveSmgAudit.Run","-logFile",unityLog})start.ArgumentList.Add(arg);
            start.Environment["WAR_SMG_LIVE_GRANTS_FILE"]=grantsFile;
            editor=System.Diagnostics.Process.Start(start)??throw new Exception("Unity did not start.");
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(105));await editor.WaitForExitAsync(timeout.Token);
            string log=await File.ReadAllTextAsync(unityLog);
            if(editor.ExitCode!=0||!log.Contains("UNITY_LIVE_SMG_PASSED"))throw new Exception("Unity live SMG audit failed; inspect "+unityLog);
            Console.WriteLine("PASS: recovered CPW/P90 Unity presentation over live UDP; "+unityLog);
        }
        finally
        {
            if(editor!=null){if(!editor.HasExited)editor.Kill(true);editor.Dispose();}await worker.StopAsync(CancellationToken.None);
            File.Delete(grantsFile);File.Delete(manifestFile);if(Directory.Exists(outbox))Directory.Delete(outbox,true);
        }
    }

    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,
            Path.Combine(directory,"smg-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=content.Smgs!.CreateManifest("Google2u.SMG_MP5",0);
        var manifest=new MatchManifest("smg-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.SmgRevision!,MatchManifest.SmgCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1000),0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-smg-"+Guid.NewGuid().ToString("N")+".json");
        string outbox=Path.Combine(Path.GetTempPath(),"war-smg-outbox-"+Guid.NewGuid().ToString("N"));
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,["Battle:ResultOutboxPath"]=outbox,
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:SmgContentManifestPath"]=Path.Combine(directory,"smg-content-manifest.json")
        }).Build();
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,PlayerId=id,
                SessionId=session,ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,MatchId=manifest.MatchId,
                ManifestHash=admission.ManifestHash,ExpiresUnixSeconds=admission.ExpiresUnixSeconds,
                Ticket=tokens.Sign(admission),SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(20));
            using var a=new MatchConnection(Grant(one,991));using var b=new MatchConnection(Grant(two,992));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&(await b.ConnectAsync(timeout.Token)).Code=="admitted",
                "SMG UDP peers admitted through signed grants");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);MatchReply state;
            do{await Task.Delay(80,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Phase!=BattlePhase.Running);
            var target=content.Poses.SampleBlended("idle",0,true,"idle",0,true,0).Place(covers[1].Position,covers[1].Rotation).Collision.Parts[1].Center;
            Check((await a.FireAsync(target.X,target.Y,target.Z,timeout.Token)).Code=="shot-scheduled","SMG UDP first shot scheduled");
            do{await Task.Delay(80,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Players[0].ShotsFired<3);
            Check(state.Snapshot.Players[0].ShotsFired==3&&state.Snapshot.Players[0].ClipAmmo==weapon.ClipSize-3,
                "live Worker emits one authoritative SMG burst without follow-up Client fire commands");
            Check(!state.Snapshot.RewardEligible&&state.Snapshot.Players.All(p=>p.RiflePose?.Layers.Count>0),
                "live SMG UDP state remains unscored and carries source poses");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);File.Delete(file);
            if(Directory.Exists(outbox))Directory.Delete(outbox,true);
        }
        return checks;
    }

    internal static int Run(string directory)
    {
        int checks=0;
        void Check(bool ok,string name){if(!ok)throw new Exception(name);checks++;}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception(name);}
        string combatPath=Path.Combine(directory,"combat-content-manifest.json");
        string smgPath=Path.Combine(directory,"smg-content-manifest.json");
        var rifleOnly=BattleCombatContent.Load(combatPath);
        var content=BattleCombatContent.Load(combatPath,Path.Combine(directory,"shotgun-content-manifest.json"),smgPath,
            Path.Combine(directory,"pistol-content-manifest.json"),Path.Combine(directory,"lmg-content-manifest.json"),
            Path.Combine(directory,"minigun-content-manifest.json"),Path.Combine(directory,"sniper-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var left=map.Covers.First(c=>c.Main&&c.Fraction==1);
        var right=map.Covers.First(c=>c.Main&&c.Fraction==2);
        string one=new('a',32),two=new('b',32),source="Google2u.SMG_MP5";
        var weapon=content.Smgs!.CreateManifest(source,0);
        var manifest=new MatchManifest("smg-live","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.SmgRevision!,MatchManifest.SmgCombatMode,10,60,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1000),0),new(two,weapon,2,right.SourceIndex,1,new(1000),0)]);
        Reject(()=>new MatchEngine(manifest,map,rifleOnly),"SMG mode without pinned package accepted");
        Reject(()=>new MatchEngine(manifest with {CatalogRevision=content.Revision},map,content),
            "base rifle revision accepted for SMG allocation");
        foreach(var binding in content.Smgs.Bindings)
        {
            var variant=content.Smgs.CreateManifest(binding.SourceId,0);
            var allocation=manifest with {Players=[manifest.Players[0] with {Weapon=variant},manifest.Players[1]]};
            var admitted=new MatchEngine(allocation,map,content);
            Check(admitted.CombatPose(one).Muzzle(binding.SourceId).SourcePath==binding.MuzzlePath,
                "SMG variant owns recovered animated muzzle: "+binding.SourceId);
        }
        var cpw=content.Smgs.CreateManifest("Google2u.SMG_CPW",0);
        var cpwManifest=manifest with {MatchId="smg-cpw-pose",Players=[manifest.Players[0] with {Weapon=cpw},manifest.Players[1] with {Weapon=cpw}]};
        var cpwMatch=new MatchEngine(cpwManifest,map,content);cpwMatch.Admit(one);cpwMatch.Admit(two);
        cpwMatch.Command(one,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=cpwMatch.ManifestHash}});
        cpwMatch.Command(two,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=cpwMatch.ManifestHash}});
        cpwMatch.Advance(60);Vector3 cpwAim=cpwMatch.CombatPose(two).Collision.Parts[1].Center;
        Check(cpwMatch.Command(one,new MatchCommand{CommandId=2,Fire=new FireCommand
            {TargetX=cpwAim.X,TargetY=cpwAim.Y,TargetZ=cpwAim.Z}}).Code=="shot-scheduled",
            "CPW enters recovered pistol-family cover fire");
        cpwMatch.Advance(61);
        Check(cpwMatch.Snapshot().Players[0].RiflePose.Layers.All(x=>(int)x.Clip is >=31 and <=36),
            "CPW pistol-family pose survives the protobuf boundary");

        var p90=content.Smgs.CreateManifest("Google2u.SMG_P90",0);
        ParticipantManifest TwoSmgs(ParticipantManifest player)=>player with
        {
            WeaponSlots=[new WeaponSlotManifest(0,17,player.Weapon,0),new WeaponSlotManifest(2,35,p90,0)]
        };
        var switchManifest=manifest with {MatchId="smg-switch",
            Players=[TwoSmgs(manifest.Players[0]),TwoSmgs(manifest.Players[1])]};
        var switching=new MatchEngine(switchManifest,map,content);switching.Admit(one);switching.Admit(two);
        switching.Command(one,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=switching.ManifestHash}});
        switching.Command(two,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=switching.ManifestHash}});
        switching.Advance(60);
        var selected=switching.Command(one,new MatchCommand{CommandId=2,SwitchWeapon=new SwitchWeaponCommand{Slot=2}});
        Check(selected.Code=="weapon-selected"&&selected.Snapshot.Players[0].ActiveWeaponSlot==2&&
              selected.Snapshot.Players[0].ClipAmmo==p90.ClipSize,
            "SMG slot switch selects source P90 authority with independent ammunition");
        Vector3 switchedAim=switching.CombatPose(two).Collision.Parts[1].Center;
        Check(switching.Command(one,new MatchCommand{CommandId=3,Fire=new FireCommand
            {TargetX=switchedAim.X,TargetY=switchedAim.Y,TargetZ=switchedAim.Z}}).Code=="shot-scheduled",
            "switched SMG enters its recovered burst path");
        for(ulong t=61;t<=90&&switching.Snapshot().Players[0].ShotsFired<3;t++)switching.Advance(t);
        Check(switching.Snapshot().Players[0].ShotsFired==3&&switching.Snapshot().Players[0].ClipAmmo==p90.ClipSize-3,
            "switched P90 completes its authoritative three-round burst");

        var rifle=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        var spas=content.Shotguns!.CreateManifest("Google2u.Shotgun_SPAS",0);
        ParticipantManifest Mixed(ParticipantManifest player)=>player with
        {
            Weapon=rifle,WeaponUpgrade=0,
            WeaponSlots=[new WeaponSlotManifest(0,11,rifle,0),new WeaponSlotManifest(1,18,cpw,0),
                new WeaponSlotManifest(2,4,spas,0)]
        };
        var mixedManifest=manifest with {MatchId="mixed-switch",Mode=MatchManifest.MixedCombatMode,
            CatalogRevision=content.MixedRevision!,Players=[Mixed(manifest.Players[0]),Mixed(manifest.Players[1])]};
        Reject(()=>new MatchEngine(mixedManifest,map,BattleCombatContent.Load(combatPath,null,smgPath)),
            "mixed mode without the shotgun package accepted");
        var mixed=new MatchEngine(mixedManifest,map,content);mixed.Admit(one);mixed.Admit(two);
        mixed.Command(one,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=mixed.ManifestHash}});
        mixed.Command(two,new MatchCommand{CommandId=1,Ready=new ReadyCommand{ManifestHash=mixed.ManifestHash}});mixed.Advance(60);
        Check(mixed.Command(one,new MatchCommand{CommandId=2,SwitchWeapon=new SwitchWeaponCommand{Slot=1}}).Code=="weapon-selected",
            "mixed loadout switches rifle to CPW authority");
        Vector3 mixedAim=mixed.CombatPose(two).Collision.Parts[1].Center;
        Check(mixed.Command(one,new MatchCommand{CommandId=3,Fire=new FireCommand
            {TargetX=mixedAim.X,TargetY=mixedAim.Y,TargetZ=mixedAim.Z}}).Code=="shot-scheduled",
            "mixed CPW uses burst firing path");
        for(ulong t=61;t<=90&&mixed.Snapshot().Players[0].ShotsFired<3;t++)mixed.Advance(t);
        Check(mixed.Snapshot().Players[0].ShotsFired==3,"mixed CPW completes three host rounds");
        Check(mixed.Command(one,new MatchCommand{CommandId=4,SwitchWeapon=new SwitchWeaponCommand{Slot=2}}).Code=="weapon-selected",
            "mixed loadout switches CPW to shotgun authority");
        var mixedShot=mixed.Command(one,new MatchCommand{CommandId=5,Fire=new FireCommand
            {TargetX=mixedAim.X,TargetY=mixedAim.Y,TargetZ=mixedAim.Z}});
        Check(mixedShot.Code is "shot-scheduled" or "uncovering" or "fire-now",
            "mixed shotgun enters its source firing path");

        var match=new MatchEngine(manifest,map,content);
        Check(match.Admit(one)&&match.Admit(two),"SMG peers admitted");
        foreach(var id in new[]{one,two})match.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
        match.Advance(60);
        Vector3 aim=match.CombatPose(two).Collision.Parts[1].Center;
        var first=match.Command(one,new MatchCommand{CommandId=2,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
        Check(first.Code=="shot-scheduled","covered SMG click follows recovered first-shot delay");
        ulong firstTick=0;
        for(ulong t=61;t<=90;t++)
        {
            match.Advance(t);
            if(firstTick==0&&match.Snapshot().Players[0].ShotsFired==1)firstTick=t;
            if(match.Snapshot().Players[0].ShotsFired==3)break;
        }
        var state=match.Snapshot();
        Check(firstTick>0&&state.ServerTick==firstTick+8,"SMG continuation fires at two recovered four-tick cadence intervals");
        Check(state.Players[0].ShotsFired==3&&state.Players[0].ClipAmmo==weapon.ClipSize-3,
            "one SMG click authoritatively consumes exactly one three-round burst");
        Check(state.Players[0].ConfirmedEnemyHits<=3&&state.Players[0].ConfirmedPlayerHits<=3,
            "SMG hit credit is bounded by host projectiles");
        for(ulong t=state.ServerTick+1;t<=state.ServerTick+4;t++)match.Advance(t);
        var locked=match.Command(one,new MatchCommand{CommandId=3,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
        Check(locked.Code=="burst-locked","SMG cannot restart at the strict source lock deadline");
        match.Advance(match.Snapshot().ServerTick+1);
        var next=match.Command(one,new MatchCommand{CommandId=4,Fire=new FireCommand{TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
        Check(next.Code is "shot-scheduled" or "uncovering" or "fire-now",
            "SMG can begin its next burst after the source lock deadline");
        Check(!state.RewardEligible,"SMG combat remains explicitly unscored");
        return checks;
    }
}

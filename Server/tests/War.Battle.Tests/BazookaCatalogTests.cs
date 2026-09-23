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

internal static class BazookaCatalogTests
{
    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;void Check(bool value,string name){checks++;if(!value)throw new Exception("FAIL: "+name);}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,null,null,null,
            Path.Combine(directory,"bazooka-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=content.Bazookas!.CreateManifest("Google2u.Bazooka_RPG7",0);
        var manifest=new MatchManifest("bazooka-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.BazookaRevision!,MatchManifest.BazookaCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-bazooka-"+Guid.NewGuid().ToString("N")+".json");
        string outbox=Path.Combine(Path.GetTempPath(),"war-bazooka-outbox-"+Guid.NewGuid().ToString("N"));File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,["Battle:ResultOutboxPath"]=outbox,
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:BazookaContentManifestPath"]=Path.Combine(directory,"bazooka-content-manifest.json")
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
            using var a=new MatchConnection(Grant(one,3991));using var b=new MatchConnection(Grant(two,3992));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&(await b.ConnectAsync(timeout.Token)).Code=="admitted","bazooka UDP admission");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);MatchReply state;
            do{await Task.Delay(35,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Phase!=BattlePhase.Running);
            var target=content.Poses.SampleBlended("bazooka_idle",0,true,"bazooka_idle",0,true,0).Place(covers[1].Position,covers[1].Rotation).Collision.Parts[1].Center;
            Check((await a.BazookaHoldAsync(true,target.X,target.Y,target.Z,timeout.Token)).Code=="bazooka-targeting","typed UDP bazooka hold");
            state=await a.PollAsync(timeout.Token);Check(state.Snapshot.Players[0].BazookaTargeting,"Worker publishes bazooka targeting state");
            do{await Task.Delay(35,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Players[0].ShotsFired==0);
            Check(!state.Snapshot.Players[0].BazookaTargeting&&state.Snapshot.Players[0].ShotsFired==1&&state.Snapshot.Players[0].ClipAmmo==weapon.ClipSize-1,
                "Worker launches one bazooka missile after host hold time");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);if(Directory.Exists(outbox))Directory.Delete(outbox,true);}
        Console.WriteLine($"PASS: {checks} live bazooka UDP assertions");return checks;
    }

    internal static int Run(string directory)
    {
        int checks=0;void Check(bool value,string name){checks++;if(!value)throw new Exception("FAIL: "+name);}
        var catalog=BazookaCatalog.Load(Path.Combine(directory,"bazooka-content-manifest.json"));
        Check(catalog.WeaponCount==7&&catalog.StageCount==412,"complete bazooka package");
        var expected=new Dictionary<string,(int Count,int Index)>{{"Google2u.Bazooka_FGM",(66,37)},{"Google2u.Bazooka_FGMElite",(66,57)},
            {"Google2u.Bazooka_HMV",(46,38)},{"Google2u.Bazooka_Hater",(76,58)},{"Google2u.Bazooka_M202",(76,42)},
            {"Google2u.Bazooka_Panzerfaust",(56,41)},{"Google2u.Bazooka_RPG7",(26,3)}};
        foreach(var pair in expected)
        {
            var binding=catalog.Binding(pair.Key);Check(binding.InventoryIndex==pair.Value.Index&&binding.AnimationFamily==2&&binding.HoldSeconds==.7f&&
                binding.FirstShotWaitSeconds==1&&binding.DeadRadius==.8f&&binding.HurtRadius==1.4f&&binding.Speed==4&&binding.MissileType==(pair.Key=="Google2u.Bazooka_M202"?1:3),$"bazooka binding {pair.Key}");
            Check(catalog.Stage(pair.Key,pair.Value.Count-1).Index==pair.Value.Count-1,$"bazooka lane {pair.Key}");
        }
        var rpg=catalog.Stage("Google2u.Bazooka_RPG7",0);Check(rpg.Ammo==7&&Math.Abs(rpg.CadenceSeconds-10)<.0001f&&Math.Abs(rpg.ExplosionDamage-224.24f)<.001f&&Math.Abs(rpg.MinimumDamage-22.42f)<.001f&&Math.Abs(rpg.PlayerDamageRatio-.88f)<.0001f&&Math.Abs(rpg.OvertimePlayerDamageRatio-.198f)<.0001f,"RPG7 source stage");
        var m202=catalog.Binding("Google2u.Bazooka_M202");Check(m202.CurvedTrajectory&&m202.ProjectileCount==4&&m202.ProjectileDelaySeconds==.1f&&m202.SecondaryMuzzlePath!=null&&m202.RotationRange==new Vector2(.5f,1),"M202 Fangs trajectory and volley");
        Check(catalog.CreateManifest("Google2u.Bazooka_RPG7",0) is {ClipSize:7,ReserveAmmo:0,ReloadSeconds:10},"bazooka finite non-reloadable pool");
        var hold=new BazookaHoldState();var target=new Vector3(1,2,3);hold.Press(10,target);
        Check(hold.Due(30,.7f)==null&&hold.Due(31,.7f)==target&&!hold.Active,"bazooka strict serialized hold gate");
        hold.Press(40,target);hold.Press(50,new(4,5,6));Check(hold.Due(61,.7f)==target,"bazooka hold retains initial source aim");
        hold.Press(70,target);hold.Cancel();Check(hold.Due(100,.7f)==null,"bazooka early release cancels shot");
        var straight=catalog.Binding("Google2u.Bazooka_RPG7");
        ShotCollision? Plane(Vector3 from,Vector3 ray,float range)
        {
            var unit=Vector3.Normalize(ray);if(unit.Z<=0||from.Z>=2)return null;float distance=(2-from.Z)/unit.Z;
            return distance<=range?new(distance,from+unit*distance,"test-plane",null,0,true):null;
        }
        var missile=new BazookaMissileFlight(1,new('a',32),straight,Vector3.Zero,new(0,0,10),0,false,.5f,.5f,1,Plane);BazookaMissileImpact? impact=null;
        for(ulong tick=1;tick<100&&impact==null;tick++)impact=missile.Advance(tick);
        Check(impact is {Fake:false,Collision.Static:true}&&Math.Abs(impact.Position.Z-2)<.0001f&&missile.Finished,"straight missile enables collision after source clearance");
        var curved=catalog.Binding("Google2u.Bazooka_M202");var fakeMissile=new BazookaMissileFlight(2,new('a',32),curved,Vector3.Zero,new(0,0,10),0,true,.5f,.5f,-1,(_,_,_)=>null);BazookaMissileImpact? expiry=null;bool departed=false;
        for(ulong tick=1;tick<200&&expiry==null;tick++){expiry=fakeMissile.Advance(tick);if(Math.Abs(fakeMissile.Position.X)>.001f||Math.Abs(fakeMissile.Position.Y)>.001f)departed=true;}
        Check(departed&&expiry is {Fake:true,Collision:null}&&fakeMissile.Finished,"curved fake M202 missile follows trajectory and expires as presentation-only impact");
        try{catalog.Stage("Google2u.Bazooka_RPG7",26);throw new Exception("FAIL: bazooka stage bound");}catch(InvalidDataException){checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),null,null,null,null,null,null,
            Path.Combine(directory,"bazooka-content-manifest.json"));
        Check(content.BazookaRevision!=null&&content.Poses.ClipNames.Count==61&&content.Poses.FrameCount==1065,"bazooka package binds expanded pose authority");
        var idle=content.Poses.SampleBlended("bazooka_idle",0,true,"bazooka_idle",0,true,0);
        Check(idle.Muzzle("Google2u.Bazooka_RPG7").SourcePath==catalog.Binding("Google2u.Bazooka_RPG7").MuzzlePath&&
            idle.Muzzle("Google2u.Bazooka_M202#secondary").SourcePath==m202.SecondaryMuzzlePath,"bazooka primary and Fangs secondary muzzles bind rig");
        var placed=idle.Place(Vector3.Zero,Quaternion.Identity).Collision;var body=placed.Parts[0];
        var inner=BazookaExplosion.ResolvePlayer(body.Center,placed,placed.RootPosition,new(1000),1000,rpg,straight,false,false,false,false,false,.5f);
        Check(inner is {Kind:CombatDamageType.Explosion}&&Math.Abs(inner.RawDamage-rpg.ExplosionDamage)<.001f&&Math.Abs(inner.Result.Damage-rpg.ExplosionDamage*rpg.PlayerDamageRatio)<.01f,
            "bazooka inner explosion applies recovered player coefficient");
        var shielded=BazookaExplosion.ResolvePlayer(body.Center,placed,placed.RootPosition,new(1000),1000,rpg,straight,false,true,false,false,false,.5f);
        Check(shielded!=null&&shielded.RawDamage==0&&shielded.Result.Health==1000,"bazooka shield-between ratio follows serialized zero authority");
        var half=BazookaExplosion.ResolvePlayer(body.Center,placed,placed.RootPosition,new(1000),1000,catalog.Stage("Google2u.Bazooka_M202",0),m202,true,false,false,false,false,.5f);
        Check(half!=null&&Math.Abs(half.RawDamage-catalog.Stage("Google2u.Bazooka_M202",0).ExplosionDamage*.5f)<.01f,"real M202 Fangs projectile applies source half damage");
        var map=content.Maps.Single(x=>x.Source.Contains("City_Multiplayer",StringComparison.Ordinal));var covers=new[]{map.Covers.First(x=>x.Main&&x.Fraction==1),map.Covers.First(x=>x.Main&&x.Fraction==2)};
        var shieldCollider=map.DynamicColliders.First(x=>x.DynamicOwner.EndsWith("/riot_shield",StringComparison.Ordinal));
        var dynamicInner=BazookaExplosion.ResolveDynamic((shieldCollider.BoundsMin+shieldCollider.BoundsMax)/2,
            shieldCollider,rpg,straight,false);
        Check(dynamicInner.Kind==CombatDamageType.Explosion&&Math.Abs(dynamicInner.RawDamage-rpg.ExplosionDamage)<.001f&&
            content.Shields.ExplosionCoefficient==2&&content.Shields.FriendDamageCoefficient==.5f,
            "bazooka dynamic overlap and recovered shield/friendly explosion coefficients");
        string one=new('a',32),two=new('b',32);var weapon=catalog.CreateManifest("Google2u.Bazooka_RPG7",0);
        var allocation=new MatchManifest("bazooka-validation","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            content.BazookaRevision!,MatchManifest.BazookaCombatMode,10,60,120,[new(one,weapon,1,covers[0].SourceIndex,1,new(1000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1000),0)]);
        content.ValidateAllocation(allocation);checks++;
        var shieldAllocation=allocation with {MatchId="bazooka-shield",Players=
            [allocation.Players[0] with {ShieldLevel=0},allocation.Players[1] with {ShieldLevel=0}]};
        var shieldSimulation=new ShieldMatchSimulation(map,content.Shields,shieldAllocation);
        string enemyShield=covers[1].SourcePath+"/riot_shield";float shieldBefore=shieldSimulation.Snapshot().Single(x=>x.OwnerFraction==2&&x.CoverIndex==covers[1].SourceIndex).Health;
        var shieldMutation=shieldSimulation.ApplyExplosion(enemyShield,1,"Google2u.Bazooka_RPG7",rpg.ExplosionDamage,0);
        Check(shieldMutation!=null&&Math.Abs(shieldBefore-shieldMutation.Health-rpg.ExplosionDamage*2)<.01f,
            "bazooka explosion applies source shield explosion and weapon coefficients");
        var shieldMatch=new MatchEngine(shieldAllocation,map,content);shieldMatch.Admit(one);shieldMatch.Admit(two);
        shieldMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=shieldMatch.ManifestHash}});
        shieldMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=shieldMatch.ManifestHash}});shieldMatch.Advance(60);
        var enemyShieldCollider=map.DynamicColliders.Single(x=>x.DynamicOwner==enemyShield);
        Vector3 shieldAim=(enemyShieldCollider.BoundsMin+enemyShieldCollider.BoundsMax)/2;
        Check(shieldMatch.Command(one,new(){CommandId=2,BazookaHold=new(){Pressed=true,TargetX=shieldAim.X,TargetY=shieldAim.Y,TargetZ=shieldAim.Z}}).Code=="bazooka-targeting",
            "host accepts bazooka aim at source enemy shield");
        float liveShieldBefore=shieldMatch.Snapshot().Shields.Single(x=>x.OwnerFraction==2&&x.CoverIndex==covers[1].SourceIndex).Health;
        for(ulong t=61;t<500&&!shieldMatch.Terminal&&shieldMatch.Snapshot().Shields.Single(x=>x.OwnerFraction==2&&x.CoverIndex==covers[1].SourceIndex).Health==liveShieldBefore;t++)shieldMatch.Advance(t);
        Check(shieldMatch.Snapshot().Shields.Single(x=>x.OwnerFraction==2&&x.CoverIndex==covers[1].SourceIndex).Health<liveShieldBefore,
            "live MatchEngine bazooka blast mutates authoritative enemy shield");
        var barrelAllocation=allocation with {MatchId="bazooka-barrel",SceneMasterPlayerId=one,Players=
            [allocation.Players[0] with {PlayerLevel=0},allocation.Players[1] with {PlayerLevel=0}]};
        var barrelSimulation=new BarrelMatchSimulation(map,content.Barrels,content.BarrelPolicy,content.BarrelOverlap,barrelAllocation);
        int barrelIndex=barrelSimulation.Snapshot()[0].ColliderIndex;
        var barrelPreview=barrelSimulation.PreviewDamageChain(barrelIndex,1,BarrelChainCause.Explosion);
        Check(barrelPreview.OrderedEffects.Count==1&&barrelPreview.OrderedEffects[0].Cause==BarrelChainCause.Explosion,
            "bazooka direct barrel damage retains explosion cause before any synchronous chain");
        var barrelMatch=new MatchEngine(barrelAllocation,map,content);barrelMatch.Admit(one);barrelMatch.Admit(two);
        barrelMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=barrelMatch.ManifestHash}});
        barrelMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=barrelMatch.ManifestHash}});barrelMatch.Advance(60);
        Vector3 backwards=-Vector3.Transform(Vector3.UnitZ,covers[0].Rotation);
        var barrelTarget=map.DynamicColliders.Where(x=>barrelSimulation.Contains(x.ColliderIndex))
            .Where(x=>Vector3.Dot(backwards,Vector3.Normalize(x.TransformPosition-covers[0].Position))>MathF.Cos(95*MathF.PI/180))
            .OrderBy(x=>Vector3.DistanceSquared(x.TransformPosition,covers[0].Position)).First();
        Check(barrelMatch.Command(one,new(){CommandId=2,BazookaHold=new(){Pressed=true,TargetX=barrelTarget.TransformPosition.X,
            TargetY=barrelTarget.TransformPosition.Y,TargetZ=barrelTarget.TransformPosition.Z}}).Code=="bazooka-targeting",
            "host accepts bazooka aim at source barrel");
        for(ulong t=61;t<500&&!barrelMatch.Terminal&&barrelMatch.BarrelState.All(x=>x.Revision==0);t++)barrelMatch.Advance(t);
        Check(barrelMatch.BarrelState.Any(x=>x.Revision>0),"live MatchEngine bazooka blast mutates authoritative barrel lifecycle");
        var match=new MatchEngine(allocation,map,content);match.Admit(one);match.Admit(two);
        match.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});
        match.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});match.Advance(60);
        Vector3 liveAim=match.CombatPose(two).Collision.Parts[1].Center;
        Check(match.Command(one,new(){CommandId=2,Fire=new(){TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="wrong-fire-mode",
            "bazooka rejects ordinary fire transport");
        Check(match.Command(one,new(){CommandId=3,BazookaHold=new(){Pressed=true,TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="bazooka-targeting"&&
            match.Snapshot().Players[0].BazookaTargeting,"bazooka hold starts authoritative target state");
        match.Advance(61);
        Check(match.Command(one,new(){CommandId=4,BazookaHold=new(){Pressed=false}}).Code=="bazooka-cancelled"&&
            match.Snapshot().Players[0].ShotsFired==0&&!match.Snapshot().Players[0].BazookaTargeting,
            "bazooka release before hold threshold cancels without ammunition");
        Check(match.Command(one,new(){CommandId=5,BazookaHold=new(){Pressed=true,TargetX=liveAim.X,TargetY=liveAim.Y,TargetZ=liveAim.Z}}).Code=="bazooka-targeting",
            "bazooka can restart hold after cancellation");
        for(ulong t=62;t<=83;t++)match.Advance(t);
        var fired=match.Snapshot().Players[0];
        Check(fired.ShotsFired==1&&fired.ClipAmmo==weapon.ClipSize-1&&!fired.BazookaTargeting&&match.PendingProjectileCount==1,
            "strict hold launches one server missile and consumes one finite round: shots="+fired.ShotsFired+" clip="+fired.ClipAmmo+" targeting="+fired.BazookaTargeting+" pending="+match.PendingProjectileCount+" phase="+match.Snapshot().Phase+" reason="+match.Snapshot().TerminalReason);
        match.Advance(84);
        Check(match.Snapshot().Players[0].RiflePose.Layers.All(x=>(int)x.Clip is >=54 and <=59),
            "bazooka pose family crosses protobuf boundary");
        float initialHealth=match.Snapshot().Players[1].Health;
        for(ulong t=85;t<500&&!match.Terminal&&match.Snapshot().Players[1].Health==initialHealth;t++)match.Advance(t);
        Check(match.Snapshot().Players[1].Health<initialHealth&&match.PendingProjectileCount==0,
            "host missile collision applies radial bazooka damage to current animated hitbox");
        var fangsWeapon=catalog.CreateManifest("Google2u.Bazooka_M202",0);
        var fangsManifest=allocation with {MatchId="bazooka-fangs",Players=
            [allocation.Players[0] with {Weapon=fangsWeapon},allocation.Players[1] with {Weapon=fangsWeapon}]};
        var fangs=new MatchEngine(fangsManifest,map,content);fangs.Admit(one);fangs.Admit(two);
        fangs.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=fangs.ManifestHash}});
        fangs.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=fangs.ManifestHash}});fangs.Advance(60);
        Vector3 fangsAim=fangs.CombatPose(two).Collision.Parts[1].Center;
        fangs.Command(one,new(){CommandId=2,BazookaHold=new(){Pressed=true,TargetX=fangsAim.X,TargetY=fangsAim.Y,TargetZ=fangsAim.Z}});
        ulong fangsTick=61;while(fangs.Snapshot().Players[0].ShotsFired==0)fangs.Advance(fangsTick++);
        Check(fangs.PendingProjectileCount==4&&fangs.Snapshot().Players[0].ClipAmmo==fangsWeapon.ClipSize-1,
            "M202 reserves one primary and three delayed missiles for one ammunition unit");
        for(int i=0;i<10;i++)fangs.Advance(fangsTick++);
        var published=new List<MatchEvent>();ulong cursor=0;
        while(true){var page=fangs.EventBatch(one,cursor);published.AddRange(page.Events);if(cursor==page.LatestEventId||page.Events.Count==0)break;cursor=page.Events[^1].EventId;}
        var fangsShots=published.Where(x=>x.Kind==MatchEventKind.Shot).ToArray();
        Check(fangsShots.Length==4&&fangsShots.Count(x=>x.Reason=="bazooka-fake")==2&&fangsShots.Count(x=>x.Reason=="bazooka")==2,
            "M202 publishes primary real, fake, real, fake source sequence");
        Console.WriteLine($"PASS: {checks} bazooka catalog/hold assertions");return checks;
    }
}

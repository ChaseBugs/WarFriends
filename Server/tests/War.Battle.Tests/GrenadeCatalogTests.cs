using War.BattleServer;
using System.Numerics;
using War.Protocol;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.Client;

internal static class GrenadeCatalogTests
{
    internal static int WriteRenderFixture(string directory,string output)
    {
        var catalog=GrenadeCatalog.Load(Path.Combine(directory,"grenade-content-manifest.json"));var cases=new List<object>();
        foreach(string clip in catalog.Poses.ClipNames)
        {
            float duration=catalog.Poses.Duration(clip);int count=(int)MathF.Ceiling(duration*30)+1;
            for(int i=0;i<count;i++)
            {
                float seconds=Math.Min(i/30f,duration);var frame=catalog.Poses.Sample(clip,seconds,false);
                string id=clip.Contains("grenadelauncher",StringComparison.Ordinal)?"Google2u.GrenadeLauncher_M320":"Google2u.Grenade_FRAG";
                var muzzle=clip=="throw_grenade_left"?frame.Left:frame.Right[id];
                var wire=RiflePoseProjection.Create((ulong)(i+1),[new(new(clip,seconds,1,false),1)],frame.Collision.RootRotation,Quaternion.Identity,null);
                var player=new BattlePlayerState{PlayerId=new('a',32),PositionX=frame.Collision.RootPosition.X,PositionY=frame.Collision.RootPosition.Y,
                    PositionZ=frame.Collision.RootPosition.Z,RiflePose=wire};
                cases.Add(new{player=JsonFormatter.Default.Format(player),muzzlePath=muzzle.SourcePath,
                    muzzle=new[]{muzzle.Position.X,muzzle.Position.Y,muzzle.Position.Z},parts=frame.Collision.Parts.Select(x=>new[]{x.Center.X,x.Center.Y,x.Center.Z}).ToArray()});
            }
        }
        File.WriteAllText(output,JsonSerializer.Serialize(new{sceneHash=catalog.SceneRevision,cases},new JsonSerializerOptions{WriteIndented=true}));
        Console.WriteLine("WROTE: "+output+" cases="+cases.Count);return cases.Count;
    }
    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;void Check(bool ok,string name){checks++;if(!ok)throw new Exception("FAIL: "+name);}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),grenadeManifestPath:Path.Combine(directory,"grenade-content-manifest.json"));
        var map=content.Maps.Single(x=>x.Source.Contains("City_Multiplayer",StringComparison.Ordinal));var covers=new[]{map.Covers.First(x=>x.Main&&x.Fraction==1),map.Covers.First(x=>x.Main&&x.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=content.Grenades!.CreateManifest("Google2u.Grenade_FRAG",0);
        var launcherWeapon=content.Grenades.CreateManifest("Google2u.GrenadeLauncher_M320",0);
        var manifest=new MatchManifest("grenade-udp","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,content.GrenadeRevision!,MatchManifest.GrenadeCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1_000_000),0),new(two,launcherWeapon,2,covers[1].SourceIndex,1,new(1_000_000),0)]);
        string file=Path.Combine(Path.GetTempPath(),"war-grenade-"+Guid.NewGuid().ToString("N")+".json"),outbox=Path.Combine(Path.GetTempPath(),"war-grenade-outbox-"+Guid.NewGuid().ToString("N"));File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>{{"Battle:SigningKey",key},{"Battle:ServerId",manifest.ServerId},{"Battle:Port",port.ToString()},
            {"Battle:MatchManifestPath",file},{"Battle:ResultOutboxPath",outbox},{"Battle:CombatContentManifestPath",Path.Combine(directory,"combat-content-manifest.json")},{"Battle:GrenadeContentManifestPath",Path.Combine(directory,"grenade-content-manifest.json")}}).Build();
        MatchConnectionGrant Grant(string id,ulong session){long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,MatchId=manifest.MatchId,ManifestHash=admission.ManifestHash,ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};}
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(20));using var a=new MatchConnection(Grant(one,4991));using var b=new MatchConnection(Grant(two,4992));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&(await b.ConnectAsync(timeout.Token)).Code=="admitted","grenade UDP admission");await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);MatchReply state;
            do{await Task.Delay(35,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Phase!=BattlePhase.Running);
            Vector3 start=covers[0].Position,delta=Vector3.Normalize(new Vector3(covers[1].Position.X-start.X,0,covers[1].Position.Z-start.Z))*7;
            Check((await a.GrenadeSwipeThrowAsync(start.X,start.Y,start.Z,start.X+delta.X,start.Y,start.Z+delta.Z,.05f,timeout.Token)).Code=="grenade-throwing","typed UDP grenade swipe");
            do{await Task.Delay(35,timeout.Token);state=await a.PollAsync(timeout.Token);}while(state.Snapshot.Players[0].ShotsFired==0);
            Check(state.Snapshot.Players[0].ShotsFired==1&&state.Snapshot.Players[0].ClipAmmo==weapon.ClipSize-1,"Worker launches one finite grenade after recovered animation delay");
            Vector3 launcherTarget=covers[0].Position;
            Check((await b.GrenadeLauncherThrowAsync(launcherTarget.X,launcherTarget.Y,launcherTarget.Z,timeout.Token)).Code=="grenade-throwing",
                "typed UDP M320 click target");
            do{await Task.Delay(35,timeout.Token);state=await b.PollAsync(timeout.Token);}while(state.Snapshot.Players[1].ShotsFired==0);
            Check(state.Snapshot.Players[1].ShotsFired==1&&state.Snapshot.Players[1].ClipAmmo==launcherWeapon.ClipSize-1&&
                  state.Snapshot.Projectiles.Any(x=>x.OwnerPlayerId==two),
                "Worker launches one finite M320 projectile with an authoritative snapshot");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);if(Directory.Exists(outbox))Directory.Delete(outbox,true);}
        Console.WriteLine($"PASS: {checks} live grenade UDP assertions");return checks;
    }
    internal static int Run(string directory)
    {
        int checks=0;void Check(bool ok,string name){checks++;if(!ok)throw new Exception("FAIL: "+name);}
        void Reject(Action action,string name){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception("FAIL: "+name);}
        var catalog=GrenadeCatalog.Load(Path.Combine(directory,"grenade-content-manifest.json"));
        Check(catalog.WeaponCount==8&&catalog.StageCount==398,"complete recovered grenade package");
        Check(catalog.Poses.ClipNames.Count==12&&catalog.Poses.FrameCount==289,
            "complete Unity-exported grenade and launcher pose package");
        var leftLaunch=catalog.Poses.Sample("throw_grenade_left",.6,false);
        var rightLaunch=catalog.Poses.Sample("throw_grenade_right",.6,false);
        Check(leftLaunch.Left.SourcePath==fragBindingPath(catalog)&&leftLaunch.Right.Count==8&&
              Vector3.Distance(leftLaunch.Left.Position,rightLaunch.Right["Google2u.Grenade_FRAG"].Position)>.1f,
            "source launch samples retain distinct left and right hand origins");
        var combat=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            grenadeManifestPath:Path.Combine(directory,"grenade-content-manifest.json"));
        Check(combat.Grenades?.WeaponCount==8&&combat.GrenadeRevision is {Length:64},
            "grenade package binds the pinned scene and equipped weapon muzzles");
        var posedTargets=combat.GrenadeShotTargets!.Place("grenadelauncher_idle",0,true,
            new(100,0,100),new Quaternion(0,-.7071068f,0,.7071068f));
        Check(posedTargets.Count==5&&posedTargets.Take(3).Select((position,index)=>
                Vector3.Distance(position,combat.PlayerShotTargets.Gameplay[index].ReferencePosition)<.0001f).All(x=>x),
            "Unity-sampled grenade target array preserves serialized root-child target positions");
        var expected=new Dictionary<string,(int Count,int Index,bool Swipe)>
        {
            ["Google2u.GrenadeLauncher_M320"]=(36,19,false),["Google2u.Grenade_FLASH"]=(36,7,true),
            ["Google2u.Grenade_FRAG"]=(26,5,true),["Google2u.Grenade_M84"]=(76,53,true),
            ["Google2u.Grenade_Molotov"]=(66,40,true),["Google2u.Grenade_POISON"]=(46,8,true),
            ["Google2u.Grenade_SMOKE"]=(56,6,true),["Google2u.Grenade_SMOKEElite"]=(56,62,true)
        };
        foreach(var pair in expected)
        {
            var binding=catalog.Binding(pair.Key);var first=catalog.Stage(pair.Key,0);
            Check(binding.InventoryIndex==pair.Value.Index&&binding.Swipe==pair.Value.Swipe&&
                binding.AnimationFamily==(pair.Value.Swipe?1:6)&&binding.Angle==(pair.Value.Swipe?45:30)&&
                binding.ThrowDistance==(pair.Value.Swipe?10:10.4f)&&binding.FuseSeconds==0,
                "grenade controller and ballistic binding: "+pair.Key);
            Check(catalog.Stage(pair.Key,pair.Value.Count-1).Index==pair.Value.Count-1&&first.PlayerDamageRatio==.792f&&
                first.OvertimePlayerDamageRatio==.198f&&first.BehindShieldRatio==(pair.Key=="Google2u.GrenadeLauncher_M320"?.04f:.06f),
                "grenade stage lane and player coefficients: "+pair.Key);
            Reject(()=>catalog.Stage(pair.Key,pair.Value.Count),"grenade stage overflow accepted: "+pair.Key);
        }
        var launcher=catalog.Stage("Google2u.GrenadeLauncher_M320",0);
        Check(launcher.Ammo==11&&launcher.CadenceSeconds==4.5f&&launcher.ExplosionDamage==133.25f&&launcher.MinimumDamage==6.66f&&
            launcher.DeadRadius==.6f&&Math.Abs(launcher.HurtRadius-.9f)<.0001f,"M320 stage-zero source values");
        var frag=catalog.Stage("Google2u.Grenade_FRAG",0);var fragBinding=catalog.Binding("Google2u.Grenade_FRAG");
        Check(frag.Ammo==8&&frag.CadenceSeconds==6.2f&&frag.DeadRadius==1&&frag.HurtRadius==1.7f&&fragBinding.FirstShotWaitSeconds==.6f,
            "FRAG definition radius and swipe delay override idle scene ammo defaults");
        Check(fragBinding.SwipeInput is {MaxDistance:7,MaxDistanceShot:10,MaxThrowTime:1,MinDistanceShot:1,MinThrowTime:.05f,ThrowFactor:.3f,DistanceThreshold:.5f},
            "source swipe gesture bounds");
        Check(catalog.Binding("Google2u.Grenade_Molotov").Effect==RecoveredGrenadeEffect.Molotov&&
            expected.Keys.Where(x=>x!="Google2u.Grenade_Molotov").All(x=>catalog.Binding(x).Effect==RecoveredGrenadeEffect.Frag),
            "serialized runtime selects Molotov only; named flash poison and smoke rows remain Frag in 1.4.0 scene");
        Check(catalog.CreateManifest("Google2u.Grenade_FRAG",0) is {ClipSize:8,ReserveAmmo:0,ReloadSeconds:6.2f},
            "grenade finite non-reloadable ammunition pool");
        var plan=GrenadeThrowPlanner.Plan(fragBinding,Vector3.Zero,Quaternion.Identity,Vector3.Zero,new(7,0,0),.05f);
        Check(plan.Target==new Vector3(10,0,0)&&plan.Right&&plan.ClampedHoldSeconds==.05f&&plan.ClampedSwipeDistance==7,
            "fast maximum swipe clamps to recovered ten-unit throw");
        var slow=GrenadeThrowPlanner.Plan(fragBinding,Vector3.Zero,Quaternion.Identity,Vector3.Zero,new(1,0,0),1);
        Check(slow.Target==new Vector3(1,0,0)&&slow.Right&&slow.ClampedHoldSeconds==1,
            "slow swipe clamps to recovered one-unit minimum throw");
        Reject(()=>GrenadeThrowPlanner.Plan(fragBinding,Vector3.Zero,Quaternion.Identity,Vector3.Zero,new(.5f,0,0),.2f),
            "source-equal grenade swipe threshold accepted");
        var velocity=GrenadeFlight.BallisticVelocity(new(0,1,0),new(0,1,10),45);
        Check(velocity.Z>0&&velocity.Y>0&&Math.Abs(velocity.X)<.0001f&&PlayerHitbox.Finite(velocity),
            "source ballistic launch velocity");
        ShotCollision? Ground(Vector3 from,Vector3 direction,float range)
        {
            var unit=Vector3.Normalize(direction);if(unit.Y>=0||from.Y<=0)return null;float distance=-from.Y/unit.Y;
            return distance<=range?new(distance,from+unit*distance,"ground",null,0,true):null;
        }
        var flight=new GrenadeFlight(1,new('a',32),fragBinding,new(0,1,0),new(0,1,10),0,Ground);GrenadeFlightImpact? impact=null;
        for(ulong tick=1;tick<450&&impact==null;tick++)impact=flight.Advance(tick);
        Check(impact is {Collision.Static:true}&&Math.Abs(impact.Position.Y)<.001f&&flight.Finished,
            "falling grenade enables collision and reaches source ground plane");
        var dynamic=new MapDynamicCollider(3,"barrel","barrel-owner",0,Vector3.Zero,new(-.1f),new(.1f));
        var inner=GrenadeExplosion.ResolveDynamic(Vector3.Zero,dynamic,frag);
        Check(inner.Kind==CombatDamageType.Explosion&&inner.RawDamage==frag.ExplosionDamage,
            "grenade inner radius applies full dynamic damage");
        var outer=GrenadeExplosion.ResolveDynamic(new(1.35f,0,0),dynamic,frag);
        Check(outer.Kind==CombatDamageType.Shiver&&outer.RawDamage>=frag.MinimumDamage&&outer.RawDamage<frag.ExplosionDamage,
            "grenade outer radius applies quadratic dynamic falloff");
        var idlePose=catalog.Poses.Sample("grenade_idle",0,true).Collision.Place(Vector3.Zero,Quaternion.Identity);var body=idlePose.Parts[0];
        var armyInner=GrenadeExplosion.ResolveArmy(body.Center,idlePose.RootPosition,[body],frag);
        Check(armyInner is {Kind:CombatDamageType.Explosion}&&armyInner.RawDamage==frag.ExplosionDamage&&
              GrenadeExplosion.ResolveArmy(body.Center+new Vector3(20,0,0),idlePose.RootPosition,[body],frag)==null,
            "source grenade overlaps a nearest infantry destroyable once and omits distant entities");
        var playerInner=GrenadeExplosion.ResolvePlayer(body.Center,idlePose,idlePose.RootPosition,new(1000),1000,frag,false,false,false,false,.5f);
        Check(playerInner is {Kind:CombatDamageType.Explosion}&&Math.Abs(playerInner.RawDamage-frag.ExplosionDamage)<.001f&&
              Math.Abs(playerInner.Result.Damage-frag.ExplosionDamage*frag.PlayerDamageRatio)<.01f,
            "grenade inner player blast applies recovered damage and player coefficient");
        var playerShielded=GrenadeExplosion.ResolvePlayer(body.Center,idlePose,idlePose.RootPosition,new(1000),1000,frag,true,false,false,false,.5f);
        Check(playerShielded!=null&&Math.Abs(playerShielded.RawDamage-frag.ExplosionDamage*frag.BehindShieldRatio)<.01f,
            "grenade player blast applies recovered behind-shield ratio");
        var map=combat.Maps.Single(x=>x.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
        var covers=new[]{map.Covers.First(x=>x.Main&&x.Fraction==1),map.Covers.First(x=>x.Main&&x.Fraction==2)};
        string one=new('a',32),two=new('b',32);var weapon=catalog.CreateManifest("Google2u.Grenade_FRAG",0);
        var allocation=new MatchManifest("grenade-kernel","local-1",Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,
            combat.GrenadeRevision!,MatchManifest.GrenadeCombatMode,10,60,120,
            [new(one,weapon,1,covers[0].SourceIndex,1,new(1000),0),new(two,weapon,2,covers[1].SourceIndex,1,new(1000),0)]);
        var simulation=new GrenadeMatchSimulation(allocation,map,catalog);
        var dynamicBody=new PlayerHitbox("source/dynamic-body",PlayerHitboxKind.Sphere,1,
            new(0,50,2),Vector3.Zero,Quaternion.Identity,.2f,Vector3.Zero,0);
        simulation.ConfigureDynamicTargets(_=>[new DynamicShotTarget(900,1,23,dynamicBody)]);
        Check(simulation.Trace(one,new(0,50,0),Vector3.UnitZ,4,uint.MaxValue) is
              {DynamicEntityId:900,DynamicPartId:1},
            "grenade flight traces host-owned moving unit geometry");
        var start=covers[0].Position;var command=new GrenadeThrowCommand{Swipe=true,SwipeStartX=start.X,SwipeStartY=start.Y,SwipeStartZ=start.Z,
            SwipeEndX=start.X+1,SwipeEndY=start.Y,SwipeEndZ=start.Z,HeldSeconds=.2f};
        var scheduled=simulation.Begin(one,command,60);
        Check(scheduled is {LaunchTick:79}&&simulation.Busy(one),"swipe animation schedules recovered float 0.6-second launch");
        IReadOnlyList<ScheduledGrenadeLaunch> due=[];for(ulong t=61;t<=79;t++)due=simulation.Advance(t);
        Check(due.Count==1&&!simulation.Busy(one)&&PlayerHitbox.Finite(simulation.Muzzle(due[0])),
            "grenade pose clock releases one finite animated hand origin");
        Reject(()=>new GrenadeMatchSimulation(allocation,map,catalog).Begin(one,new GrenadeThrowCommand{Swipe=true,TargetX=1,
            SwipeStartX=start.X,SwipeStartY=start.Y,SwipeStartZ=start.Z,SwipeEndX=start.X+1,SwipeEndY=start.Y,SwipeEndZ=start.Z,HeldSeconds=.2f},60),
            "swipe command accepted a competing client target");
        var launcherWeapon=catalog.CreateManifest("Google2u.GrenadeLauncher_M320",0);
        var launcherAllocation=allocation with{MatchId="grenade-launcher-kernel",Players=
            [allocation.Players[0] with{Weapon=launcherWeapon},allocation.Players[1] with{Weapon=launcherWeapon}]};
        var movingCover=map.Covers.First(x=>x.Fraction==1&&x.SourceIndex!=covers[0].SourceIndex&&
            Vector3.DistanceSquared(x.Position,covers[0].Position)>1);
        var movingSimulation=new GrenadeMatchSimulation(launcherAllocation,map,catalog);
        Vector3 halfway=Vector3.Lerp(covers[0].Position,movingCover.Position,.5f);
        movingSimulation.Advance(1,id=>id==one?new(halfway,covers[0].SourceIndex,true):
            new(covers[1].Position,covers[1].SourceIndex,false));
        Check(Vector3.Distance(movingSimulation.Collision(one).RootPosition,halfway)<.01f&&
              movingSimulation.Snapshot(one,1).Layers[0].Clip==
              RiflePoseProjection.Create(1,[new(new("run_grenadelauncher",0,1,true),1)],
                  Quaternion.Identity,Quaternion.Identity,null).Layers[0].Clip,
            "moving launcher collision and snapshot use recovered run clip at host position");
        movingSimulation.Advance(2,id=>id==one?new(movingCover.Position,movingCover.SourceIndex,false):
            new(covers[1].Position,covers[1].SourceIndex,false));
        Check(Vector3.Distance(movingSimulation.Collision(one).RootPosition,movingCover.Position)<.01f,
            "launcher idle collision follows authoritative arrival cover");
        var movedLaunch=movingSimulation.Begin(one,new GrenadeThrowCommand{TargetX=covers[1].Position.X,
            TargetY=covers[1].Position.Y,TargetZ=covers[1].Position.Z},2);
        Check(movedLaunch!=null&&Vector3.Distance(movingSimulation.Collision(one).RootPosition,movingCover.Position)<.01f,
            "post-move launcher gesture uses arrived player pose");
        int moveDirection=new[]{-1,1}.First(direction=>map.Adjacent(covers[0].SourceIndex,direction,1)>=0);
        int adjacent=map.Adjacent(covers[0].SourceIndex,moveDirection,1);
        var walkingGrenade=new MatchEngine(launcherAllocation with{MatchId="grenade-walking"},map,combat);
        walkingGrenade.Admit(one);walkingGrenade.Admit(two);
        walkingGrenade.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=walkingGrenade.ManifestHash}});
        walkingGrenade.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=walkingGrenade.ManifestHash}});
        walkingGrenade.Advance(60);
        var moveGrenade=walkingGrenade.Command(one,new(){CommandId=2,MoveCover=new(){Direction=moveDirection}});
        Check(moveGrenade.Code=="moving","grenade launcher enters recovered adjacent-cover route");
        bool sawMovingGrenade=false;
        for(ulong step=61;step<=moveGrenade.Snapshot.Players[0].MoveEndTick;step++)
        {
            walkingGrenade.Advance(step);
            var current=walkingGrenade.Snapshot().Players[0];
            if(current.Moving&&Vector3.Distance(new(current.PositionX,current.PositionY,current.PositionZ),covers[0].Position)>.01f)
            {Check((int)current.RiflePose.Layers[0].Clip==70,"moving launcher publishes source run animation");sawMovingGrenade=true;}
        }
        var arrived=walkingGrenade.Snapshot().Players[0];
        Check(sawMovingGrenade&&!arrived.Moving&&arrived.CoverIndex==adjacent&&
              (int)arrived.RiflePose.Layers[0].Clip==71,
            "grenade host movement and pose settle at the same cover");
        var launcherSimulation=new GrenadeMatchSimulation(launcherAllocation,map,catalog);
        Vector3 launcherTarget=covers[1].Position;
        var launcherScheduled=launcherSimulation.Begin(one,new GrenadeThrowCommand{TargetX=launcherTarget.X,
            TargetY=launcherTarget.Y,TargetZ=launcherTarget.Z},60);
        Check(launcherScheduled is {WeaponSourceId:"Google2u.GrenadeLauncher_M320"}&&!launcherScheduled.Right==
              (Vector3.Dot(Vector3.UnitY,Vector3.Cross(Vector3.Transform(Vector3.UnitZ,covers[0].Rotation),launcherTarget-start))<=0),
            "M320 click command selects its recovered launcher animation and target");
        IReadOnlyList<ScheduledGrenadeLaunch> launcherDue=[];
        for(ulong t=61;t<180&&launcherDue.Count==0;t++)launcherDue=launcherSimulation.Advance(t);
        Check(launcherDue.Count==1&&PlayerHitbox.Finite(launcherSimulation.Muzzle(launcherDue[0])),
            "M320 launcher animation releases one authoritative right-hand projectile origin");
        combat.ValidateAllocation(allocation);checks++;
        var shieldAllocation=allocation with{MatchId="grenade-shield",Players=[allocation.Players[0] with{ShieldLevel=0},allocation.Players[1] with{ShieldLevel=0}]};
        var shieldSimulation=new ShieldMatchSimulation(map,combat.Shields,shieldAllocation);string shieldOwner=covers[1].SourcePath+"/riot_shield";
        float shieldBefore=shieldSimulation.Snapshot().Single(x=>x.OwnerFraction==2&&x.CoverIndex==covers[1].SourceIndex).Health;
        var shieldMutation=shieldSimulation.ApplyExplosion(shieldOwner,1,"Google2u.Grenade_FRAG",frag.ExplosionDamage,0);
        Check(shieldMutation!=null&&Math.Abs(shieldBefore-shieldMutation.Health-frag.ExplosionDamage*combat.Shields.ExplosionCoefficient)<.01f,
            "grenade blast enters recovered shield explosion lifecycle");
        var match=new MatchEngine(allocation,map,combat);match.Admit(one);match.Admit(two);
        match.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});
        match.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});match.Advance(60);
        Check(match.Command(one,new(){CommandId=2,Fire=new(){TargetX=covers[1].Position.X,TargetY=covers[1].Position.Y,TargetZ=covers[1].Position.Z}}).Code=="wrong-fire-mode",
            "grenade mode rejects generic client-selected fire target");
        Vector3 swipeDirection=Vector3.Normalize(new Vector3(covers[1].Position.X-start.X,0,covers[1].Position.Z-start.Z))*7;
        var liveThrow=new GrenadeThrowCommand{Swipe=true,SwipeStartX=start.X,SwipeStartY=start.Y,SwipeStartZ=start.Z,
            SwipeEndX=start.X+swipeDirection.X,SwipeEndY=start.Y,SwipeEndZ=start.Z+swipeDirection.Z,HeldSeconds=.05f};
        Check(match.Command(one,new(){CommandId=3,GrenadeThrow=liveThrow}).Code=="grenade-throwing"&&match.PendingProjectileCount==0,
            "typed swipe starts authoritative animation before ammunition or projectile mutation");
        Check((int)match.Snapshot().Players[0].RiflePose.Layers[0].Clip is 60 or 61,
            "grenade throw pose crosses authoritative snapshot boundary");
        for(ulong t=61;t<=79;t++)match.Advance(t);
        var airborne=match.Snapshot();
        Check(airborne.Players[0].ShotsFired==1&&airborne.Players[0].ClipAmmo==weapon.ClipSize-1&&match.PendingProjectileCount==1&&
              airborne.Projectiles.Count==1&&airborne.Projectiles[0].Kind=="grenade"&&
              airborne.Projectiles[0].OwnerPlayerId==one&&airborne.Projectiles[0].ProjectileId>0&&
              float.IsFinite(airborne.Projectiles[0].VelocityX)&&float.IsFinite(airborne.Projectiles[0].VelocityY)&&float.IsFinite(airborne.Projectiles[0].VelocityZ),
            "animation release consumes one finite grenade and launches one host projectile");
        for(ulong t=80;t<550&&!match.Terminal&&match.PendingProjectileCount>0;t++)match.Advance(t);
        Check(match.PendingProjectileCount==0||match.Terminal,"host grenade reaches a bounded authoritative impact");
        var barrelAllocation=launcherAllocation with{MatchId="grenade-barrel",SceneMasterPlayerId=one,Players=
            [launcherAllocation.Players[0] with{PlayerLevel=0},launcherAllocation.Players[1] with{PlayerLevel=0}]};
        var barrelSimulation=new BarrelMatchSimulation(map,combat.Barrels,combat.BarrelPolicy,combat.BarrelOverlap,barrelAllocation);
        var barrelTarget=map.DynamicColliders.Where(x=>barrelSimulation.Contains(x.ColliderIndex))
            .OrderBy(x=>Vector3.DistanceSquared(x.TransformPosition,start)).First();
        var barrelMatch=new MatchEngine(barrelAllocation,map,combat);barrelMatch.Admit(one);barrelMatch.Admit(two);
        barrelMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=barrelMatch.ManifestHash}});
        barrelMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=barrelMatch.ManifestHash}});barrelMatch.Advance(60);
        Check(barrelMatch.Command(one,new(){CommandId=2,GrenadeThrow=new(){TargetX=barrelTarget.TransformPosition.X,
            TargetY=barrelTarget.TransformPosition.Y,TargetZ=barrelTarget.TransformPosition.Z}}).Code=="grenade-throwing",
            "host accepts typed M320 click at a source barrel");
        for(ulong t=61;t<550&&!barrelMatch.Terminal&&barrelMatch.BarrelState.All(x=>x.Revision==0);t++)barrelMatch.Advance(t);
        Check(barrelMatch.BarrelState.Any(x=>x.Revision>0),
            "live MatchEngine M320 explosion mutates the authoritative barrel chain");
        var infantryAllocation=allocation with {MatchId="grenade-infantry-kill",Players=[
            allocation.Players[0] with
            {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
             ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
             ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
             ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]},allocation.Players[1] with
            {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
             ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
             ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
             ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]}]};
        combat.ValidateAllocation(infantryAllocation);
        var infantryMatch=new MatchEngine(infantryAllocation,map,combat,armyChoice:_=>0);
        infantryMatch.Admit(one);infantryMatch.Admit(two);
        infantryMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=infantryMatch.ManifestHash}});
        infantryMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=infantryMatch.ManifestHash}});
        infantryMatch.Advance(60);
        var infantryOption=infantryMatch.ArmyBatch(two).OptionIndexes.First();
        var infantryDeploy=infantryMatch.Command(two,new(){CommandId=2,DeployArmy=new(){OptionIndex=infantryOption}}).Code;
        Check(infantryDeploy=="army-deploying",
            "grenade opponent deploys recovered Assault infantry through host authority: "+infantryDeploy);
        ulong infantryTick=60;
        while(infantryTick<300&&infantryMatch.ArmyEntityBatch(one,0,0).Entities.Count==0)
            infantryMatch.Advance(++infantryTick);
        var infantryVictim=infantryMatch.ArmyEntityBatch(one,0,0).Entities.First();
        var infantryBlast=infantryMatch.GroundVehicleShotTargets(one)
            .First(x=>x.ArmyInfantry&&x.EntityId==infantryVictim.EntityKey).Hitbox.Center;
        for(int blast=0;blast<12&&infantryMatch.ArmyHealth(infantryVictim.EntityKey)!=null;blast++)
            infantryMatch.ApplyPlayerGrenadeInfantryExplosion(one,infantryBlast,
                combat.Grenades!.Stage("Google2u.Grenade_FRAG",0));
        Check(infantryMatch.ArmyHealth(infantryVictim.EntityKey)==null,
            "trusted source grenade blast removes one opposed infantry entity through shared vitality");
        infantryMatch.Command(one,new(){CommandId=2,Forfeit=new()});
        var infantryTerminal=infantryMatch.TerminalEvidenceSnapshot();
        var infantryBytes=infantryTerminal.ToByteArray();
        Check(infantryMatch.Snapshot().DirectArmyKills.Count==0&&
              infantryTerminal.DirectArmyKills.Any(x=>x.EntityKey==infantryVictim.EntityKey&&
                  x.UnitId=="ID_UNIT-ASSAULT"&&x.AttackerPlayerId==one&&
                  x.VictimOwnerPlayerId==two&&x.Cause=="player-grenade")&&
              BattleDirectKillStatsProjection.FromPayload(infantryBytes,infantryMatch.MatchId,
                  War.Shared.TerminalResultDigest.Compute(infantryBytes))
                  .Single(x=>x.PlayerId==one) is {DirectBulletKills:0,DirectGrenadeKills:>0},
            "grenade infantry death persists private cause without inflating direct-bullet statistics");
        var friendlyAllocation=infantryAllocation with {MatchId="grenade-friendly-infantry"};
        var friendlyMatch=new MatchEngine(friendlyAllocation,map,combat,armyChoice:_=>0);
        friendlyMatch.Admit(one);friendlyMatch.Admit(two);
        friendlyMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=friendlyMatch.ManifestHash}});
        friendlyMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=friendlyMatch.ManifestHash}});
        friendlyMatch.Advance(60);
        int friendlyOption=friendlyMatch.ArmyBatch(one).OptionIndexes.First();
        Check(friendlyMatch.Command(one,new(){CommandId=2,DeployArmy=new(){OptionIndex=friendlyOption}})
            .Code=="army-deploying","grenade owner deploys friendly infantry through host authority");
        ulong friendlyTick=60;
        while(friendlyTick<300&&friendlyMatch.ArmyEntityBatch(one,0,0).Entities.Count==0)
            friendlyMatch.Advance(++friendlyTick);
        var friendlyVictim=friendlyMatch.ArmyEntityBatch(one,0,0).Entities.First();
        var friendlyPose=friendlyMatch.InfantryPose(friendlyVictim.EntityKey)!;
        var friendlyOrigin=friendlyPose.Parts[0].Center;
        var friendlyStage=combat.Grenades!.Stage("Google2u.Grenade_FRAG",0);
        var friendlyEffect=GrenadeExplosion.ResolveArmy(friendlyOrigin,
            new(friendlyVictim.X,friendlyVictim.Y,friendlyVictim.Z),friendlyPose.Parts,friendlyStage)!;
        float friendlyAmount=friendlyEffect.RawDamage*combat.Explosions.Friendly;
        float friendlyBefore=friendlyVictim.Health;
        friendlyMatch.ApplyPlayerGrenadeInfantryExplosion(one,friendlyOrigin,friendlyStage);
        float? friendlyAfter=friendlyMatch.ArmyHealth(friendlyVictim.EntityKey);
        float expectedHealth=friendlyBefore-Math.Max(0,friendlyAmount-friendlyVictim.Kevlar);
        Check((expectedHealth<=0?friendlyAfter==null:
              friendlyAfter!=null&&Math.Abs(friendlyAfter.Value-expectedHealth)<.01f),
            "friendly grenade infantry damage uses the recovered half-damage coefficient");
        friendlyMatch.Command(one,new(){CommandId=3,Forfeit=new()});
        Check(friendlyMatch.TerminalEvidenceSnapshot().DirectArmyKills.Count==0,
            "friendly infantry grenade death cannot claim direct-player kill credit");
        Console.WriteLine($"PASS: {checks} grenade catalog assertions");return checks;
        static string fragBindingPath(GrenadeCatalog value)=>value.Binding("Google2u.Grenade_FRAG").SwipeInput!.LeftMuzzlePath;
    }
}

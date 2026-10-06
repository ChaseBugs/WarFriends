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
        var repairAllocation=allocation with {MatchId="bazooka-repair-drone",Players=
            [allocation.Players[0] with
            {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
             ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
             ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
             ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]},allocation.Players[1] with
            {EquippedArmyUnitIds=["ID_UNIT-TRANSPORTER"],ArmyNormalUpgradeIndexes=[0],
             ArmySpecialUpgradeIndexes=[71],ArmyEliteUpgradeIndexes=[-1],
             ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
             ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]}]};
        content.ValidateAllocation(repairAllocation);
        (MatchEngine Match,BattleArmyEntityState Victim,DynamicShotTarget[] Bodies) AirTarget(
            string matchId,string unit)
        {
            var manifest=repairAllocation with {MatchId=matchId,Players=
                [repairAllocation.Players[0],repairAllocation.Players[1] with
                    {EquippedArmyUnitIds=[unit],ArmySpecialUpgradeIndexes=[-1]}]};
            content.ValidateAllocation(manifest);
            var match=new MatchEngine(manifest,map,content,armyChoice:_=>0);
            match.Admit(one);match.Admit(two);
            match.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});
            match.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=match.ManifestHash}});
            match.Advance(60);
            Check(match.Command(two,new(){CommandId=2,
                DeployArmy=new(){OptionIndex=match.ArmyBatch(two).OptionIndexes.First()}})
                .Code=="army-deploying","source air unit deploys for Bazooka blast: "+unit);
            ulong next=60;
            while(next<300&&match.ArmyEntityBatch(one,0,0).Entities.Count==0)
                match.Advance(++next);
            var victim=match.ArmyEntityBatch(one,0,0).Entities.Single();
            var bodies=match.GroundVehicleShotTargets(one).Where(value=>
                value.EntityId==victim.EntityKey&&
                (unit=="ID_UNIT-DRONE"?value.DroneRoot:value.HelicopterBody)).ToArray();
            Check(victim.UnitId==unit&&bodies.Length>0,
                "deployed air unit has source body collision: "+unit);
            return(match,victim,bodies);
        }
        var airRpg=content.Bazookas!.Stage("Google2u.Bazooka_RPG7",0);
        var airBinding=content.Bazookas.Binding("Google2u.Bazooka_RPG7");
        foreach(var airUnit in new[]{"ID_UNIT-DRONE","ID_UNIT-HELICOPTER"})
        {
            var (friendlyMatch,friendlyVictim,friendlyBodies)=AirTarget(
                "bazooka-air-friendly-"+airUnit[8..].ToLowerInvariant(),airUnit);
            Vector3 friendlyOrigin=friendlyBodies[0].Hitbox.Center;
            var friendlyEffect=BazookaExplosion.ResolveArmy(friendlyOrigin,
                new(friendlyVictim.X,friendlyVictim.Y,friendlyVictim.Z),
                friendlyBodies.Select(value=>value.Hitbox).ToArray(),airRpg,airBinding,true)!;
            friendlyMatch.ApplyPlayerBazookaAirBodyExplosion(two,friendlyOrigin,airRpg,airBinding,true);
            float? friendlyAirAfter=friendlyMatch.ArmyHealth(friendlyVictim.EntityKey);
            float expectedFriendly=friendlyVictim.Health-
                Math.Max(0,friendlyEffect.RawDamage*content.Explosions.Friendly-friendlyVictim.Kevlar);
            Check(expectedFriendly<=0?friendlyAirAfter==null:
                  friendlyAirAfter!=null&&Math.Abs(friendlyAirAfter.Value-expectedFriendly)<.01f,
                "friendly half-damage Bazooka blast uses one air-body owner: "+airUnit);

            var (enemyMatch,enemyVictim,enemyBodies)=AirTarget(
                "bazooka-air-enemy-"+airUnit[8..].ToLowerInvariant(),airUnit);
            Vector3 enemyOrigin=enemyBodies[0].Hitbox.Center;
            var enemyEffect=BazookaExplosion.ResolveArmy(enemyOrigin,
                new(enemyVictim.X,enemyVictim.Y,enemyVictim.Z),
                enemyBodies.Select(value=>value.Hitbox).ToArray(),airRpg,airBinding,false)!;
            Check(enemyEffect.Kind==CombatDamageType.Explosion&&
                  Math.Abs(enemyEffect.RawDamage-rpg.ExplosionDamage)<.01f,
                "Bazooka air blast selects one nearest body collider without bullet weight: "+airUnit);
            enemyMatch.ApplyPlayerBazookaAirBodyExplosion(one,enemyOrigin,airRpg,airBinding,false);
            float? enemyAfter=enemyMatch.ArmyHealth(enemyVictim.EntityKey);
            float expectedEnemy=enemyVictim.Health-
                Math.Max(0,enemyEffect.RawDamage-enemyVictim.Kevlar);
            Check(expectedEnemy<=0?enemyAfter==null:
                  enemyAfter!=null&&Math.Abs(enemyAfter.Value-expectedEnemy)<.01f,
                "opposing Bazooka blast damages source air-body vitality: "+airUnit);
            try
            {
                enemyMatch.ApplyPlayerBazookaAirBodyExplosion(one,enemyOrigin,
                    airRpg with {ExplosionDamage=1},airBinding,false);
                throw new Exception("FAIL: forged Bazooka air-body stage: "+airUnit);
            }
            catch(InvalidDataException){checks++;}
        }
        var infantryAllocation=repairAllocation with {MatchId="bazooka-infantry-blast"};
        var infantryMatch=new MatchEngine(infantryAllocation,map,content,armyChoice:_=>0);
        infantryMatch.Admit(one);infantryMatch.Admit(two);
        infantryMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=infantryMatch.ManifestHash}});
        infantryMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=infantryMatch.ManifestHash}});
        infantryMatch.Advance(60);
        Check(infantryMatch.Command(one,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=infantryMatch.ArmyBatch(one).OptionIndexes.First()}})
            .Code=="army-deploying","source Assault infantry deploys for Bazooka blast");
        ulong infantryTick=60;
        while(infantryTick<700&&infantryMatch.ArmyEntityBatch(one,0,0).Entities.Count==0)
            infantryMatch.Advance(++infantryTick);
        var infantry=infantryMatch.ArmyEntityBatch(one,0,0).Entities.Single();
        var infantryBox=infantryMatch.GroundVehicleShotTargets(two)
            .First(x=>x.EntityId==infantry.EntityKey&&x.ArmyInfantry).Hitbox;
        var infantryRpg=content.Bazookas!.Stage("Google2u.Bazooka_RPG7",0);
        var infantryBinding=content.Bazookas.Binding("Google2u.Bazooka_RPG7");
        var infantryBlast=BazookaExplosion.ResolveArmy(infantryBox.Center,
            new(infantry.X,infantry.Y,infantry.Z),[infantryBox],infantryRpg,infantryBinding,false);
        Check(infantryBlast is {Kind:CombatDamageType.Explosion}&&
              Math.Abs(infantryBlast.RawDamage-rpg.ExplosionDamage)<.01f,
            "Bazooka selects one infantry collider without bullet part weight");
        infantryMatch.ApplyPlayerBazookaInfantryExplosion(one,infantryBox.Center,
            infantryRpg,infantryBinding,true);
        float friendlyInfantry=infantryMatch.ArmyHealth(infantry.EntityKey)!.Value;
        Check(Math.Abs(infantry.Health-friendlyInfantry-rpg.ExplosionDamage*.25f)<.01f,
            "half-damage Bazooka blast applies friendly coefficient to one animated infantry owner");
        infantryMatch.ApplyPlayerBazookaInfantryExplosion(two,infantryBox.Center,
            infantryRpg,infantryBinding,false);
        Check(friendlyInfantry<rpg.ExplosionDamage&&
              infantryMatch.ArmyHealth(infantry.EntityKey)==null&&
              infantryMatch.GroundVehicleShotTargets(two)
                  .All(x=>x.EntityId!=infantry.EntityKey),
            "opposing Bazooka blast removes lethal infantry and its collision authority");
        try
        {
            infantryMatch.ApplyPlayerBazookaInfantryExplosion(two,infantryBox.Center,
                infantryRpg with {ExplosionDamage=1},infantryBinding,false);
            throw new Exception("FAIL: forged bazooka infantry stage");
        }
        catch(InvalidDataException){checks++;}
        var decoyAllocation=repairAllocation with {MatchId="bazooka-decoy-blast",
            SceneMasterPlayerId=one,Players=
            [repairAllocation.Players[0] with {PlayerLevel=0},
             repairAllocation.Players[1] with {PlayerLevel=0}]};
        var decoyMatch=new MatchEngine(decoyAllocation,map,content);
        decoyMatch.ConfigureBattleAllocations([
            new(one,["CardDecoy"],[],[0],[-1],[-1]),
            new(two,["CardDecoy"],[],[0],[71],[-1])]);
        decoyMatch.Admit(one);decoyMatch.Admit(two);
        foreach(var player in new[]{one,two})
        {
            int special=player==one?-1:71;
            string selection=decoyMatch.Command(player,new(){CommandId=1,SelectCards=new()
                {CardIds={"CardDecoy"},NormalUpgradeIndexes={0},
                 SpecialUpgradeIndexes={special},EliteUpgradeIndexes={-1}}}).Code;
            Check(selection=="cards-selected",
                "Bazooka match accepts source Decoy inventory: "+selection);
            decoyMatch.Command(player,new(){CommandId=2,
                Ready=new(){ManifestHash=decoyMatch.ManifestHash}});
        }
        decoyMatch.Advance(60);
        string enemyDecoyResult=decoyMatch.Command(two,new(){CommandId=3,UseDecoy=new()
            {RequestId=new string('d',32)}}).Code;
        Check(enemyDecoyResult=="decoy-spawned",
            "opponent deploys Decoys for Bazooka blast: "+enemyDecoyResult);
        var enemyDecoy=decoyMatch.Snapshot().Decoys.First(value=>value.OwnerPlayerId==two);
        Vector3 enemyDecoyOrigin=new(enemyDecoy.X,enemyDecoy.Y,enemyDecoy.Z);
        decoyMatch.ApplyPlayerBazookaDecoyExplosion(one,enemyDecoyOrigin,airRpg,airBinding,false);
        float? enemyDecoyAfter=decoyMatch.DecoyHealth(enemyDecoy.EntityId);
        float expectedEnemyDecoy=enemyDecoy.Health-airRpg.ExplosionDamage;
        Check(expectedEnemyDecoy<=0?enemyDecoyAfter==null:
              enemyDecoyAfter!=null&&Math.Abs(enemyDecoyAfter.Value-expectedEnemyDecoy)<.01f,
            "opposing Bazooka blast damages one Decoy root using source damage");
        Check(decoyMatch.Command(one,new(){CommandId=3,UseDecoy=new()
            {RequestId=new string('e',32)}}).Code=="decoy-spawned",
            "Bazooka owner deploys a separate friendly Decoy");
        var friendlyDecoy=decoyMatch.Snapshot().Decoys.First(value=>value.OwnerPlayerId==one);
        Vector3 friendlyDecoyOrigin=new(friendlyDecoy.X,friendlyDecoy.Y,friendlyDecoy.Z);
        decoyMatch.ApplyPlayerBazookaDecoyExplosion(one,friendlyDecoyOrigin,airRpg,airBinding,true);
        float? friendlyDecoyAfter=decoyMatch.DecoyHealth(friendlyDecoy.EntityId);
        float expectedFriendlyDecoy=friendlyDecoy.Health-
            airRpg.ExplosionDamage*.5f*content.Explosions.Friendly;
        Check(expectedFriendlyDecoy<=0?friendlyDecoyAfter==null:
              friendlyDecoyAfter!=null&&Math.Abs(friendlyDecoyAfter.Value-expectedFriendlyDecoy)<.01f,
            "half-damage Bazooka projectile and friendly coefficient both apply to Decoy");
        try
        {
            decoyMatch.ApplyPlayerBazookaDecoyExplosion(one,enemyDecoyOrigin,
                airRpg with {ExplosionDamage=1},airBinding,false);
            throw new Exception("FAIL: forged Bazooka Decoy stage");
        }
        catch(InvalidDataException){checks++;}
        for(int blast=0;blast<30&&decoyMatch.DecoyHealth(enemyDecoy.EntityId)!=null;blast++)
            decoyMatch.ApplyPlayerBazookaDecoyExplosion(one,enemyDecoyOrigin,
                airRpg,airBinding,false);
        Check(decoyMatch.DecoyHealth(enemyDecoy.EntityId)==null&&
              decoyMatch.DroneTargetSnapshot().All(value=>
                  value.Id!="decoy:"+enemyDecoy.EntityId),
            "lethal Bazooka blast removes Decoy health and Drone target authority");
        var naturalDecoyAllocation=decoyAllocation with {MatchId="bazooka-natural-decoy"};
        var naturalDecoy=new MatchEngine(naturalDecoyAllocation,map,content);
        naturalDecoy.ConfigureBattleAllocations([
            new(one,["CardDecoy"],[],[0],[-1],[-1]),
            new(two,["CardDecoy"],[],[0],[71],[-1])]);
        naturalDecoy.Admit(one);naturalDecoy.Admit(two);
        foreach(var player in new[]{one,two})
        {
            int special=player==one?-1:71;
            Check(naturalDecoy.Command(player,new(){CommandId=1,SelectCards=new()
                {CardIds={"CardDecoy"},NormalUpgradeIndexes={0},
                 SpecialUpgradeIndexes={special},EliteUpgradeIndexes={-1}}}).Code=="cards-selected",
                "normal Bazooka/Decoy match accepts trusted card selection");
            naturalDecoy.Command(player,new(){CommandId=2,
                Ready=new(){ManifestHash=naturalDecoy.ManifestHash}});
        }
        naturalDecoy.Advance(60);
        Check(naturalDecoy.Command(two,new(){CommandId=3,UseDecoy=new()
            {RequestId=new string('9',32)}}).Code=="decoy-spawned",
            "normal Bazooka match deploys opposing Decoys");
        var naturalDecoyTarget=naturalDecoy.Snapshot().Decoys
            .First(value=>value.OwnerPlayerId==two);
        float naturalDecoyBefore=naturalDecoyTarget.Health;
        bool naturalDecoyDamaged=false;
        ulong naturalDecoyTick=60,naturalDecoyCommand=3;
        for(;naturalDecoyTick<2500&&!naturalDecoy.Terminal;)
        {
            if(naturalDecoyTick%240==0)
            {
                var collider=naturalDecoy.GroundVehicleShotTargets(one).FirstOrDefault(value=>
                    value.Decoy&&value.EntityId==naturalDecoyTarget.EntityId);
                if(collider==null)break;
                Vector3 aim=collider.Hitbox.Center;
                naturalDecoy.Command(one,new(){CommandId=naturalDecoyCommand++,BazookaHold=new()
                    {Pressed=true,TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
            }
            naturalDecoy.Advance(++naturalDecoyTick);
            float? current=naturalDecoy.DecoyHealth(naturalDecoyTarget.EntityId);
            if(current==null||current<naturalDecoyBefore)
            {naturalDecoyDamaged=true;break;}
        }
        Check(naturalDecoyDamaged&&naturalDecoy.Snapshot().Players
                  .Single(value=>value.PlayerId==one).ShotsFired>0,
            "normal Bazooka hold, missile flight and impact damage a deployed Decoy");
        var turretAllocation=decoyAllocation with {MatchId="bazooka-heavy-turret-blast",Players=
            [decoyAllocation.Players[0] with {PlayerLevel=22},
             decoyAllocation.Players[1] with {PlayerLevel=22}]};
        var turretMatch=new MatchEngine(turretAllocation,map,content);
        turretMatch.ConfigureBattleAllocations([
            new(one,["CardHeavyTurret"],[],[0],[-1],[-1]),
            new(two,["CardHeavyTurret"],[],[0],[71],[-1])]);
        turretMatch.Admit(one);turretMatch.Admit(two);
        foreach(var player in new[]{one,two})
        {
            int special=player==one?-1:71;
            Check(turretMatch.Command(player,new(){CommandId=1,SelectCards=new()
                {CardIds={"CardHeavyTurret"},NormalUpgradeIndexes={0},
                 SpecialUpgradeIndexes={special},EliteUpgradeIndexes={-1}}}).Code=="cards-selected",
                "Bazooka match accepts source Heavy Turret inventory");
            turretMatch.Command(player,new(){CommandId=2,
                Ready=new(){ManifestHash=turretMatch.ManifestHash}});
        }
        turretMatch.Advance(60);
        Check(turretMatch.Command(two,new(){CommandId=3,UseHeavyTurret=new()
            {RequestId=new string('c',32)}}).Code=="heavy-turret-spawned",
            "opponent deploys Heavy Turret for Bazooka blast");
        var enemyTurret=turretMatch.Snapshot().HeavyTurrets.Single();
        var enemyTurretBoxes=turretMatch.GroundVehicleShotTargets(one)
            .Where(value=>value.HeavyTurret&&value.EntityId==enemyTurret.EntityId)
            .Select(value=>value.Hitbox).ToArray();
        Vector3 enemyTurretOrigin=enemyTurretBoxes[0].Center;
        var enemyTurretEffect=BazookaExplosion.ResolveArmy(enemyTurretOrigin,
            new(enemyTurret.X,enemyTurret.Y,enemyTurret.Z),enemyTurretBoxes,
            airRpg,airBinding,false)!;
        turretMatch.ApplyPlayerBazookaHeavyTurretExplosion(one,enemyTurretOrigin,
            airRpg,airBinding,false);
        float? enemyTurretAfter=turretMatch.HeavyTurretHealth(enemyTurret.EntityId);
        float expectedEnemyTurret=enemyTurret.Health-enemyTurretEffect.RawDamage;
        Check(enemyTurretBoxes.Length==3&&
              (expectedEnemyTurret<=0?enemyTurretAfter==null:
               enemyTurretAfter!=null&&Math.Abs(enemyTurretAfter.Value-expectedEnemyTurret)<.01f),
            "Bazooka blast damages one Heavy Turret owner across three joint colliders");
        Check(turretMatch.Command(one,new(){CommandId=3,UseHeavyTurret=new()
            {RequestId=new string('f',32)}}).Code=="heavy-turret-spawned",
            "Bazooka owner deploys a separate friendly Heavy Turret");
        var friendlyTurret=turretMatch.Snapshot().HeavyTurrets
            .Single(value=>value.OwnerPlayerId==one);
        var friendlyTurretBoxes=turretMatch.GroundVehicleShotTargets(two)
            .Where(value=>value.HeavyTurret&&value.EntityId==friendlyTurret.EntityId)
            .Select(value=>value.Hitbox).ToArray();
        Vector3 friendlyTurretOrigin=friendlyTurretBoxes[0].Center;
        var friendlyTurretEffect=BazookaExplosion.ResolveArmy(friendlyTurretOrigin,
            new(friendlyTurret.X,friendlyTurret.Y,friendlyTurret.Z),friendlyTurretBoxes,
            airRpg,airBinding,true)!;
        turretMatch.ApplyPlayerBazookaHeavyTurretExplosion(one,friendlyTurretOrigin,
            airRpg,airBinding,true);
        float? friendlyTurretAfter=turretMatch.HeavyTurretHealth(friendlyTurret.EntityId);
        float expectedFriendlyTurret=friendlyTurret.Health-
            friendlyTurretEffect.RawDamage*content.Explosions.Friendly;
        Check(expectedFriendlyTurret<=0?friendlyTurretAfter==null:
              friendlyTurretAfter!=null&&Math.Abs(friendlyTurretAfter.Value-expectedFriendlyTurret)<.01f,
            "half-damage Bazooka missile applies friendly coefficient to Heavy Turret once");
        try
        {
            turretMatch.ApplyPlayerBazookaHeavyTurretExplosion(one,enemyTurretOrigin,
                airRpg with {ExplosionDamage=1},airBinding,false);
            throw new Exception("FAIL: forged Bazooka Heavy Turret stage");
        }
        catch(InvalidDataException){checks++;}
        for(int blast=0;blast<30&&turretMatch.HeavyTurretHealth(enemyTurret.EntityId)!=null;blast++)
            turretMatch.ApplyPlayerBazookaHeavyTurretExplosion(one,enemyTurretOrigin,
                airRpg,airBinding,false);
        Check(turretMatch.HeavyTurretHealth(enemyTurret.EntityId)==null&&
              turretMatch.GroundVehicleShotTargets(one)
                  .All(value=>value.EntityId!=enemyTurret.EntityId),
            "lethal Bazooka blast removes Heavy Turret health and joint collision authority");
        var repairMatch=new MatchEngine(repairAllocation,map,content,armyChoice:_=>0);
        repairMatch.Admit(one);repairMatch.Admit(two);
        repairMatch.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=repairMatch.ManifestHash}});
        repairMatch.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=repairMatch.ManifestHash}});
        repairMatch.Advance(60);
        int repairOption=repairMatch.ArmyBatch(two).OptionIndexes.First();
        Check(repairMatch.Command(two,new(){CommandId=2,DeployArmy=new(){OptionIndex=repairOption}})
            .Code=="army-deploying","source Transporter deploys for bazooka repair-drone blast");
        ulong repairTick=60;
        while(repairTick<700&&repairMatch.ArmyEntityBatch(one,0,0).Entities.Count==0)
            repairMatch.Advance(++repairTick);
        var repairVehicle=repairMatch.ArmyEntityBatch(one,0,0).Entities.Single();
        var trustedRpg=content.Bazookas!.Stage("Google2u.Bazooka_RPG7",0);
        var trustedStraight=content.Bazookas.Binding("Google2u.Bazooka_RPG7");
        var passenger=repairMatch.VehiclePassengers(repairVehicle.EntityKey).First(x=>x.Active);
        var passengerBox=repairMatch.GroundVehicleShotTargets(one).First(x=>
            x.EntityId==repairVehicle.EntityKey&&x.PassengerRole==passenger.Role).Hitbox;
        float passengerBodyBefore=repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value;
        repairMatch.ApplyPlayerBazookaPassengerExplosion(two,passengerBox.Center,
            trustedRpg,trustedStraight,true);
        float passengerFriendlyHealth=repairMatch.VehiclePassengers(repairVehicle.EntityKey)
            .Single(x=>x.Role==passenger.Role).Health;
        Check(Math.Abs(passengerFriendlyHealth-(passenger.Health-rpg.ExplosionDamage*.25f))<.01f,
            "half-damage Bazooka blast applies the friendly coefficient once to an attached passenger");
        repairMatch.ApplyPlayerBazookaPassengerExplosion(one,passengerBox.Center,
            trustedRpg,trustedStraight,false);
        float passengerEnemyHealth=repairMatch.VehiclePassengers(repairVehicle.EntityKey)
            .Single(x=>x.Role==passenger.Role).Health;
        Check(Math.Abs(passengerEnemyHealth-(passengerFriendlyHealth-rpg.ExplosionDamage))<.01f&&
              Math.Abs(repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value-passengerBodyBefore)<.01f,
            "opposing Bazooka blast damages the passenger independently of the Transporter body");
        try
        {
            repairMatch.ApplyPlayerBazookaPassengerExplosion(one,passengerBox.Center,
                trustedRpg with {ExplosionDamage=1},trustedStraight,false);
            throw new Exception("FAIL: forged bazooka passenger stage");
        }
        catch(InvalidDataException){checks++;}
        var bodyBox=repairMatch.GroundVehicleShotTargets(one).First(x=>
            x.EntityId==repairVehicle.EntityKey&&x.GroundVehicleBody).Hitbox;
        float bodyBeforeBlast=repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value;
        float passengerBeforeBodyBlast=repairMatch.VehiclePassengers(repairVehicle.EntityKey)
            .Single(x=>x.Role==passenger.Role).Health;
        repairMatch.ApplyPlayerBazookaGroundVehicleExplosion(two,bodyBox.Center,
            trustedRpg,trustedStraight,true);
        float bodyAfterFriendlyBlast=repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value;
        Check(Math.Abs(bodyBeforeBlast-bodyAfterFriendlyBlast-rpg.ExplosionDamage*.25f)<.01f&&
              Math.Abs(repairMatch.Snapshot().Vehicles.Single().Health-bodyAfterFriendlyBlast)<.01f,
            "friendly half-damage Bazooka blast synchronizes Transporter body and vehicle registry");
        repairMatch.ApplyPlayerBazookaGroundVehicleExplosion(one,bodyBox.Center,
            trustedRpg,trustedStraight,false);
        float bodyAfterEnemyBlast=repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value;
        Check(Math.Abs(bodyAfterFriendlyBlast-bodyAfterEnemyBlast-rpg.ExplosionDamage)<.01f&&
              Math.Abs(repairMatch.VehiclePassengers(repairVehicle.EntityKey)
                  .Single(x=>x.Role==passenger.Role).Health-passengerBeforeBodyBlast)<.01f,
            "opposing Bazooka body blast leaves independently damaged passenger health unchanged");
        try
        {
            repairMatch.ApplyPlayerBazookaGroundVehicleExplosion(one,bodyBox.Center,
                trustedRpg with {ExplosionDamage=1},trustedStraight,false);
            throw new Exception("FAIL: forged bazooka vehicle stage");
        }
        catch(InvalidDataException){checks++;}
        var repairDrone=repairMatch.TransporterRepairDrones(repairVehicle.EntityKey)[0];
        var repairBox=repairMatch.GroundVehicleShotTargets(one).Single(x=>
            x.EntityId==repairVehicle.EntityKey&&x.RepairDronePathIndex==0).Hitbox;
        Vector3 repairCenter=repairBox.Center;
        var repairEffect=BazookaExplosion.ResolveArmy(repairCenter,repairDrone.Position,
            [repairBox],trustedRpg,trustedStraight,false);
        Check(repairEffect is {Kind:CombatDamageType.Explosion}&&
              Math.Abs(repairEffect.RawDamage-rpg.ExplosionDamage)<.001f,
            "bazooka blast selects the MiniDrone root without a part multiplier");
        float repairBefore=repairDrone.Health;
        float vehicleBefore=repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value;
        repairMatch.ApplyPlayerBazookaRepairDroneExplosion(two,repairCenter,trustedRpg,trustedStraight,true);
        float friendlyAfter=repairMatch.TransporterRepairDrones(repairVehicle.EntityKey)[0].Health;
        Check(Math.Abs(friendlyAfter-Math.Max(0,repairBefore-rpg.ExplosionDamage*.25f))<.01f&&
              Math.Abs(repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value-vehicleBefore)<.01f,
            "half-damage bazooka missile and same-faction coefficient both apply to repair drone");
        if(repairMatch.TransporterRepairDrones(repairVehicle.EntityKey)[0].Active)
        {
            repairMatch.ApplyPlayerBazookaRepairDroneExplosion(one,repairCenter,trustedRpg,trustedStraight,false);
            float opposingAfter=repairMatch.TransporterRepairDrones(repairVehicle.EntityKey)[0].Health;
            Check(Math.Abs(opposingAfter-Math.Max(0,friendlyAfter-rpg.ExplosionDamage))<.01f&&
                  Math.Abs(repairMatch.ArmyHealth(repairVehicle.EntityKey)!.Value-vehicleBefore)<.01f,
                "opposing bazooka blast damages only the host-owned repair-drone health");
        }
        try
        {
            repairMatch.ApplyPlayerBazookaRepairDroneExplosion(one,repairCenter,
                trustedRpg with {ExplosionDamage=1},trustedStraight,false);
            throw new Exception("FAIL: forged bazooka repair-drone stage");
        }
        catch(InvalidDataException){checks++;}
        for(int blast=0;blast<30&&repairMatch.ArmyHealth(repairVehicle.EntityKey)!=null;blast++)
            repairMatch.ApplyPlayerBazookaGroundVehicleExplosion(one,bodyBox.Center,
                trustedRpg,trustedStraight,false);
        Check(repairMatch.ArmyHealth(repairVehicle.EntityKey)==null&&
              repairMatch.Snapshot().Vehicles.All(x=>x.EntityId!=repairVehicle.EntityKey)&&
              repairMatch.GroundVehicleShotTargets(one).All(x=>x.EntityId!=repairVehicle.EntityKey),
            "lethal Bazooka body blast removes shared vehicle, passenger, and collision authority");
        var naturalRepairAllocation=repairAllocation with {MatchId="bazooka-natural-repair-drone"};
        var naturalRepair=new MatchEngine(naturalRepairAllocation,map,content,armyChoice:_=>0);
        naturalRepair.Admit(one);naturalRepair.Admit(two);
        naturalRepair.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=naturalRepair.ManifestHash}});
        naturalRepair.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=naturalRepair.ManifestHash}});
        naturalRepair.Advance(60);
        int naturalOption=naturalRepair.ArmyBatch(two).OptionIndexes.First();
        Check(naturalRepair.Command(two,new(){CommandId=2,
            DeployArmy=new(){OptionIndex=naturalOption}}).Code=="army-deploying",
            "normal bazooka match deploys source Transporter");
        ulong naturalTick=60;
        while(naturalTick<700&&naturalRepair.ArmyEntityBatch(one,0,0).Entities.Count==0)
            naturalRepair.Advance(++naturalTick);
        var naturalVehicle=naturalRepair.ArmyEntityBatch(one,0,0).Entities.Single();
        float naturalDroneBefore=naturalRepair.TransporterRepairDrones(naturalVehicle.EntityKey)[0].Health;
        bool naturalDroneDamaged=false;
        ulong bazookaCommand=2;
        for(;naturalTick<2500&&!naturalRepair.Terminal;)
        {
            if(naturalTick%240==0)
            {
                var droneTarget=naturalRepair.GroundVehicleShotTargets(one).FirstOrDefault(x=>
                    x.EntityId==naturalVehicle.EntityKey&&x.RepairDronePathIndex==0);
                if(droneTarget==null)break;
                Vector3 aim=droneTarget.Hitbox.Center;
                naturalRepair.Command(one,new(){CommandId=bazookaCommand++,BazookaHold=new()
                    {Pressed=true,TargetX=aim.X,TargetY=aim.Y,TargetZ=aim.Z}});
            }
            naturalRepair.Advance(++naturalTick);
            if(naturalRepair.TransporterRepairDrones(naturalVehicle.EntityKey)[0].Health<naturalDroneBefore)
            {naturalDroneDamaged=true;break;}
        }
        Check(naturalDroneDamaged&&naturalRepair.Snapshot().Players.Single(x=>x.PlayerId==one).ShotsFired>0,
            "normal bazooka hold, missile flight and impact damage a moving repair drone");
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
        var match=new MatchEngine(allocation,map,content,combatRandom:()=>.5f);match.Admit(one);match.Admit(two);
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
        float initialHealth=match.Snapshot().Players[1].Health;
        for(ulong t=62;t<=83;t++)match.Advance(t);
        var fired=match.Snapshot().Players[0];
        Check(fired.ShotsFired==1&&fired.ClipAmmo==weapon.ClipSize-1&&!fired.BazookaTargeting,
            "strict hold launches one server missile and consumes one finite round: shots="+fired.ShotsFired+" clip="+fired.ClipAmmo+" targeting="+fired.BazookaTargeting+" pending="+match.PendingProjectileCount+" phase="+match.Snapshot().Phase+" reason="+match.Snapshot().TerminalReason);
        match.Advance(84);
        Check(match.Snapshot().Players[0].RiflePose.Layers.All(x=>(int)x.Clip is >=54 and <=59),
            "bazooka pose family crosses protobuf boundary");
        for(ulong t=85;t<500&&!match.Terminal&&match.Snapshot().Players[1].Health==initialHealth;t++)match.Advance(t);
        Check(match.Snapshot().Players[1].Health<initialHealth&&match.PendingProjectileCount==0,
            "host missile collision applies radial bazooka damage to current animated hitbox: before="+
            initialHealth+" after="+match.Snapshot().Players[1].Health+" pending="+
            match.PendingProjectileCount+" phase="+match.Snapshot().Phase+" reason="+
            match.Snapshot().TerminalReason);
        var fangsWeapon=catalog.CreateManifest("Google2u.Bazooka_M202",0);
        var fangsManifest=allocation with {MatchId="bazooka-fangs",Players=
            [allocation.Players[0] with {Weapon=fangsWeapon},allocation.Players[1] with {Weapon=fangsWeapon}]};
        var fangs=new MatchEngine(fangsManifest,map,content);fangs.Admit(one);fangs.Admit(two);
        fangs.Command(one,new(){CommandId=1,Ready=new(){ManifestHash=fangs.ManifestHash}});
        fangs.Command(two,new(){CommandId=1,Ready=new(){ManifestHash=fangs.ManifestHash}});fangs.Advance(60);
        Vector3 fangsAim=fangs.CombatPose(two).Collision.Parts[1].Center;
        fangs.Command(one,new(){CommandId=2,BazookaHold=new(){Pressed=true,TargetX=fangsAim.X,TargetY=fangsAim.Y,TargetZ=fangsAim.Z}});
        ulong fangsTick=61;while(fangs.Snapshot().Players[0].ShotsFired==0)fangs.Advance(fangsTick++);
        Check(fangs.PendingProjectileCount is >=3 and <=4&&fangs.Snapshot().Players[0].ClipAmmo==fangsWeapon.ClipSize-1,
            "M202 reserves one primary and three delayed missiles for one ammunition unit: pending="+
            fangs.PendingProjectileCount+" tick="+fangsTick+" shots="+fangs.Snapshot().Players[0].ShotsFired);
        for(int i=0;i<10;i++)fangs.Advance(fangsTick++);
        var published=new List<MatchEvent>();ulong cursor=0;
        while(true){var page=fangs.EventBatch(one,cursor);published.AddRange(page.Events);if(cursor==page.LatestEventId||page.Events.Count==0)break;cursor=page.Events[^1].EventId;}
        var fangsShots=published.Where(x=>x.Kind==MatchEventKind.Shot).ToArray();
        Check(fangsShots.Length==4&&fangsShots.Count(x=>x.Reason=="bazooka-fake")==2&&fangsShots.Count(x=>x.Reason=="bazooka")==2,
            "M202 publishes primary real, fake, real, fake source sequence");
        Console.WriteLine($"PASS: {checks} bazooka catalog/hold assertions");return checks;
    }
}

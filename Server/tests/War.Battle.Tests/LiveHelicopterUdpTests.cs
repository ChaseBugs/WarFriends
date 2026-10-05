using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Client;
using War.Protocol;

internal static class LiveHelicopterUdpTests
{
    internal static async Task<int> Run(string directory)
    {
        int checks=0;
        void Check(bool yes,string name)
        {if(!yes)throw new Exception(name);checks++;}
        var oversized=new Packet { MatchReply=new MatchReply {Snapshot=new MatchSnapshot()} };
        for(ulong id=1;id<=60;id++)
            oversized.MatchReply.Snapshot.Projectiles.Add(new BattleProjectileState
            {ProjectileId=id,OwnerPlayerId=new string('a',32),Kind="helicopter-bullet",
             X=id,Y=id,Z=id,VelocityX=6,VelocityY=6,VelocityZ=6});
        Check(oversized.CalculateSize()+War.Protocol.Transport.PacketCodec.MacBytes>
              War.Protocol.Transport.PacketCodec.MaximumDatagramBytes,
              "overlapping presentation projectiles can exceed the UDP envelope");
        MatchEndpoint.FitSnapshotDatagram(oversized);
        Check(oversized.MatchReply.Snapshot.ProjectilesTruncated&&
              oversized.CalculateSize()+War.Protocol.Transport.PacketCodec.MacBytes<=
                  War.Protocol.Transport.PacketCodec.MaximumDatagramBytes&&
              oversized.MatchReply.Snapshot.Projectiles.Last().ProjectileId==60&&
              oversized.MatchReply.Snapshot.Projectiles[0].ProjectileId>1,
              "MTU fitting marks omission and preserves newest projectile transforms");
        var sourceRows=Enumerable.Range(1,60).Select(id=>new BattleProjectileState
        {ProjectileId=(ulong)id,OwnerPlayerId=new string('a',32),Kind="helicopter-bullet",
         X=id,Y=id,Z=id,VelocityX=6,VelocityY=6,VelocityZ=6}).ToArray();
        var projected=new List<ulong>();ulong pageCursor=0;int pageCount=0;
        while(true)
        {
            var envelope=new Packet {Version=1,SessionId=9401,Sequence=(ulong)pageCount+1,
                Ack=(ulong)pageCount+1};
            var batch=MatchEndpoint.PageProjectiles(new MatchProjectileBatch
                {MatchId="helicopter-live-udp",ManifestHash=new string('a',64)},
                77,500,sourceRows,pageCursor,envelope);
            Check(envelope.CalculateSize()+War.Protocol.Transport.PacketCodec.MacBytes<=
                  War.Protocol.Transport.PacketCodec.MaximumDatagramBytes,
                  "each frozen projectile scan page fits the UDP envelope");
            projected.AddRange(batch.Projectiles.Select(x=>x.ProjectileId));
            pageCount++;
            if(!batch.HasMore)break;
            pageCursor=batch.Projectiles.Last().ProjectileId;
        }
        Check(pageCount>1&&projected.SequenceEqual(Enumerable.Range(1,60).Select(x=>(ulong)x)),
              "bounded pages reconstruct every projectile exactly once in identity order");
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=content.Maps.Single(x=>x.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.First(x=>x.Main&&x.Fraction==1&&x.SourceIndex==2);
        var right=map.Covers.First(x=>x.Main&&x.Fraction==2);
        var rifle=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        string one=new('a',32),two=new('b',32);
        var manifest=MatchManifest.Validate(new MatchManifest("helicopter-live-udp","local-1",
            "Park_Multiplayer",map.SourceHash,content.Revision,
            MatchManifest.RifleCombatMode,10,600,120,
            [new(one,rifle,1,left.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]},
             new(two,rifle,2,right.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]}])
            {SceneMasterPlayerId=one});
        content.ValidateAllocation(manifest);
        string manifestFile=Path.Combine(Path.GetTempPath(),
            "war-helicopter-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(manifestFile,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;
        probe.Close();
        string signingKey=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(signingKey);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=signingKey,["Battle:ServerId"]=manifest.ServerId,
            ["Battle:Port"]=port.ToString(),["Battle:MatchManifestPath"]=manifestFile,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),
                "war-helicopter-outbox-"+Guid.NewGuid().ToString("N")),
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json")
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
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(300));
            using var a=new MatchConnection(Grant(one,9401));
            using var b=new MatchConnection(Grant(two,9402));
            async Task<T> ReadWithRetry<T>(Func<Task<T>> read)
            {
                for(int attempt=0;;attempt++)
                    try{return await read();}
                    catch(TimeoutException) when(attempt<2)
                    {await Task.Delay(50,timeout.Token);}
                    catch(TimeoutException e)
                    {throw new TimeoutException($"Helicopter UDP read timed out: worker={worker.Metrics}; task={worker.ExecuteTask?.Status}; failure={worker.ExecuteTask?.Exception}",e);}
            }
            async Task<MatchReply> MutationWithRetry(MatchConnection peer,Func<Task<MatchReply>> send)
            {
                try{return await send();}
                catch(TimeoutException)
                {
                    for(int attempt=0;;attempt++)
                        try{return await peer.RetryPendingAsync(timeout.Token);}
                        catch(TimeoutException) when(attempt<2)
                        {await Task.Delay(50,timeout.Token);}
                }
            }
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "two signed clients enter the real Helicopter Worker");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do{await Task.Delay(100,timeout.Token);state=await a.PollAsync(timeout.Token);}
            while(state.Snapshot.Phase!=BattlePhase.Running);
            Check((await b.PollArmyAsync(timeout.Token)).OptionIndexes.SequenceEqual([2,2,2])&&
                  (await b.DeployArmyAsync(2,timeout.Token)).Code=="army-deploying",
                  "Helicopter owner deploys only its server-issued source option");
            BattleArmyEntityState? helicopter=null;
            var rosterWatch=System.Diagnostics.Stopwatch.StartNew();
            while(rosterWatch.Elapsed<TimeSpan.FromSeconds(8)&&helicopter==null)
            {
                await Task.Delay(100,timeout.Token);
                var rows=await a.FetchArmyEntitiesAsync(timeout.Token);
                helicopter=rows.SingleOrDefault(x=>x.UnitId=="ID_UNIT-HELICOPTER");
            }
            Check(helicopter!=null&&helicopter.OwnerPlayerId==two&&
                  helicopter.HelicopterRotation!=null&&
                  MatchConnection.ValidHelicopterTurretPose(helicopter)&&
                  MatchConnection.ValidHelicopterGunner(helicopter)&&
                  helicopter.HelicopterGunnerHealth>0,
                  "opponent receives live Helicopter body, turret and gunner through paged UDP roster");
            var ownerRows=await b.FetchArmyEntitiesAsync(timeout.Token);
            Check(ownerRows.Any(x=>x.EntityKey==helicopter!.EntityKey&&
                  MatchConnection.ValidHelicopterTurretPose(x)&&
                  x.HelicopterGunnerSpawnTick==helicopter.HelicopterGunnerSpawnTick&&
                  x.HelicopterGunnerHealth==helicopter.HelicopterGunnerHealth),
                  "both clients resolve the same combat-authorized Helicopter entity");
            var leftConsumer=new MatchEventConsumer();
            var rightConsumer=new MatchEventConsumer();
            MatchEvent? fired=null;
            MatchEvent? otherFired=null;
            bool leftSawBullet=false,rightSawBullet=false;
            MatchProjectileBatch? liveProjectileScan=null;
            bool frozenScanReplayed=false;
            var fireWatch=System.Diagnostics.Stopwatch.StartNew();
            while(fireWatch.Elapsed<TimeSpan.FromSeconds(34)&&
                  (fired==null||otherFired==null||!leftSawBullet||!rightSawBullet))
            {
                await Task.Delay(125,timeout.Token);
                var leftPage=await a.PollEventsAsync(leftConsumer.LastEventId,timeout.Token);
                leftConsumer.Consume(leftPage);
                fired??=leftPage.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.HelicopterFired&&
                    x.HelicopterShot?.ArmyEntityKey==helicopter!.EntityKey);
                var rightPage=await b.PollEventsAsync(rightConsumer.LastEventId,timeout.Token);
                rightConsumer.Consume(rightPage);
                otherFired??=rightPage.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.HelicopterFired&&
                    x.HelicopterShot?.ArmyEntityKey==helicopter!.EntityKey);
                leftSawBullet|=(await a.PollAsync(timeout.Token)).Snapshot.Projectiles.Any(x=>
                    x.OwnerPlayerId==two&&(x.Kind=="helicopter-bullet"||x.Kind=="helicopter-fake-bullet"));
                if(leftSawBullet&&liveProjectileScan==null)
                {
                    ulong scanId=BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(),0);
                    if(scanId==0)scanId=1;
                    var first=await a.PollProjectilesAsync(scanId,0,timeout.Token);
                    var replayed=await a.PollProjectilesAsync(scanId,0,timeout.Token);
                    frozenScanReplayed=first.Code=="projectiles"&&
                        first.Projectiles.Count>0&&first.ToByteArray().SequenceEqual(replayed.ToByteArray());
                    liveProjectileScan=await ReadWithRetry(()=>a.FetchProjectilesAsync(timeout.Token));
                }
                rightSawBullet|=(await b.PollAsync(timeout.Token)).Snapshot.Projectiles.Any(x=>
                    x.OwnerPlayerId==two&&(x.Kind=="helicopter-bullet"||x.Kind=="helicopter-fake-bullet"));
            }
            Check(fired!=null&&fired.ActorId==two&&fired.TargetId=="player:"+one&&
                  fired.HelicopterShot is {ArmyEntityKey:>0,Speed:>0},
                  "real Worker emits source-backed Helicopter fire through authenticated UDP and SDK replay");
            Check(otherFired!=null&&otherFired.EventId==fired!.EventId,
                  "both authenticated clients consume the same Helicopter fire event");
            Check(fired!.HelicopterShot!.Speed==(fired.HelicopterShot.Fake?18f:6f),
                  "player-target real rounds use the recovered half-speed while fake rounds retain setup speed");
            Check(leftSawBullet&&rightSawBullet,
                  "both live UDP snapshots carry an in-flight Helicopter projectile");
            Check(liveProjectileScan!=null&&liveProjectileScan.Code=="projectiles"&&
                  liveProjectileScan.Projectiles.Any(x=>x.OwnerPlayerId==two&&
                      (x.Kind=="helicopter-bullet"||x.Kind=="helicopter-fake-bullet")),
                  "authenticated UDP projectile scan supplies in-flight Helicopter rows to the portable SDK");
            Check(frozenScanReplayed,
                  "retried projectile scan start replays the same frozen rows despite later Worker ticks");
            float initialHealth=state.Snapshot.Players.Single(x=>x.PlayerId==one).Health;
            int moveCount=0;
            ulong? leftHit=null,rightHit=null;
            int realFired=0,fakeFired=0;
            int truncatedSnapshots=0;
            float leftHealth=initialHealth,rightHealth=initialHealth;
            var damageWatch=System.Diagnostics.Stopwatch.StartNew();
            while(damageWatch.Elapsed<TimeSpan.FromSeconds(35))
            {
                await Task.Delay(200,timeout.Token);
                if(moveCount==0)
                {
                    var moved=await MutationWithRetry(a,()=>a.MoveCoverAsync(-1,timeout.Token));
                    if(moved.Code=="moving")moveCount++;
                }
                var leftPage=await ReadWithRetry(()=>a.PollEventsAsync(leftConsumer.LastEventId,timeout.Token));
                leftConsumer.Consume(leftPage);
                foreach(var eventRow in leftPage.Events)
                {
                    if(eventRow.Kind==MatchEventKind.HelicopterFired&&eventRow.HelicopterShot!=null)
                    {if(eventRow.HelicopterShot.Fake)fakeFired++;else realFired++;}
                }
                leftHit??=leftPage.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.Impact&&
                    x.Reason=="helicopter"&&x.TargetId==one)?.EventId;
                var rightPage=await ReadWithRetry(()=>b.PollEventsAsync(rightConsumer.LastEventId,timeout.Token));
                rightConsumer.Consume(rightPage);
                rightHit??=rightPage.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.Impact&&
                    x.Reason=="helicopter"&&x.TargetId==one)?.EventId;
                state=await ReadWithRetry(()=>a.PollAsync(timeout.Token));
                if(state.Snapshot.ProjectilesTruncated)truncatedSnapshots++;
                leftHealth=state.Snapshot.Players.Single(x=>x.PlayerId==one).Health;
                var rightState=await ReadWithRetry(()=>b.PollAsync(timeout.Token));
                if(rightState.Snapshot.ProjectilesTruncated)truncatedSnapshots++;
                rightHealth=rightState.Snapshot.Players.Single(x=>x.PlayerId==one).Health;
            }
            Check(moveCount>0&&realFired>0&&worker.IsReady,
                  $"overlapping Helicopter volleys retain a live UDP host and bounded visual snapshots (moves={moveCount}, real={realFired}, fake={fakeFired}, truncated={truncatedSnapshots}, worker={worker.Metrics})");
            if(leftHit.HasValue||rightHit.HasValue)
                Check(leftHit.HasValue&&leftHit==rightHit&&leftHealth<initialHealth&&rightHealth<initialHealth,
                      "an observed Helicopter player impact has the same identity and damage for both peers");
            float gunnerHealth=helicopter!.HelicopterGunnerHealth;
            uint gunnerHitsBefore=state.Snapshot.Players.Single(x=>x.PlayerId==one).ConfirmedEnemyHits;
            bool rifleDamagedGunner=false;
            int acceptedGunnerShots=0;
            int gunnerAimAttempt=0;
            var gunnerFireCodes=new Dictionary<string,int>(StringComparer.Ordinal);
            var gunnerWatch=System.Diagnostics.Stopwatch.StartNew();
            while(gunnerWatch.Elapsed<TimeSpan.FromSeconds(70)&&!rifleDamagedGunner)
            {
                var current=(await ReadWithRetry(()=>a.FetchArmyEntitiesAsync(timeout.Token))).Single(x=>
                    x.EntityKey==helicopter.EntityKey);
                var rotation=new Quaternion(current.HelicopterRotation.X,current.HelicopterRotation.Y,
                    current.HelicopterRotation.Z,current.HelicopterRotation.W);
                var seat=content.HelicopterCrewPoints.PlaceTurret(new(current.X,current.Y,current.Z),rotation);
                var parts=content.GroundVehicleWeapons.PassengerPoses.PlaceHelicopterGunner(seat,
                    current.PositionTick-current.HelicopterGunnerSpawnTick);
                var target=parts[gunnerAimAttempt++%parts.Count].Center;
                var shot=await MutationWithRetry(a,()=>a.FireAsync(target.X,target.Y,target.Z,timeout.Token));
                gunnerFireCodes[shot.Code]=gunnerFireCodes.GetValueOrDefault(shot.Code)+1;
                if(shot.Code is "shot-scheduled" or "shot-accepted")acceptedGunnerShots++;
                await Task.Delay(220,timeout.Token);
                current=(await ReadWithRetry(()=>a.FetchArmyEntitiesAsync(timeout.Token))).Single(x=>
                    x.EntityKey==helicopter.EntityKey);
                rifleDamagedGunner=current.HelicopterGunnerHealth<gunnerHealth;
                if((await ReadWithRetry(()=>a.PollAsync(timeout.Token))).Snapshot.Players.Single(x=>x.PlayerId==one).ClipAmmo==0)
                    await MutationWithRetry(a,()=>a.ReloadAsync(timeout.Token));
            }
            Check(rifleDamagedGunner&&acceptedGunnerShots>0,
                $"opposing UDP rifle fire reaches the recovered Helicopter gunner (shots={acceptedGunnerShots}, replies={string.Join(',',gunnerFireCodes.Select(x=>x.Key+':'+x.Value))})");
            var gunnerDeathWatch=System.Diagnostics.Stopwatch.StartNew();
            BattleArmyEntityState? deadGunner=null;
            while(gunnerDeathWatch.Elapsed<TimeSpan.FromSeconds(70)&&deadGunner==null)
            {
                var current=(await ReadWithRetry(()=>a.FetchArmyEntitiesAsync(timeout.Token))).Single(x=>
                    x.EntityKey==helicopter.EntityKey);
                if(current.HelicopterGunnerHealth==0){deadGunner=current;break;}
                var rotation=new Quaternion(current.HelicopterRotation.X,current.HelicopterRotation.Y,
                    current.HelicopterRotation.Z,current.HelicopterRotation.W);
                var seat=content.HelicopterCrewPoints.PlaceTurret(new(current.X,current.Y,current.Z),rotation);
                var parts=content.GroundVehicleWeapons.PassengerPoses.PlaceHelicopterGunner(seat,
                    current.PositionTick-current.HelicopterGunnerSpawnTick);
                var target=parts[gunnerAimAttempt++%parts.Count].Center;
                var shot=await MutationWithRetry(a,()=>a.FireAsync(target.X,target.Y,target.Z,timeout.Token));
                if(shot.Code is "shot-scheduled" or "shot-accepted")acceptedGunnerShots++;
                await Task.Delay(220,timeout.Token);
                if((await ReadWithRetry(()=>a.PollAsync(timeout.Token))).Snapshot.Players.Single(x=>x.PlayerId==one).ClipAmmo==0)
                    await MutationWithRetry(a,()=>a.ReloadAsync(timeout.Token));
            }
            Check(deadGunner!=null&&deadGunner.HelicopterGunnerHealth==0&&
                  deadGunner.HelicopterGunnerRespawnTick>deadGunner.PositionTick&&
                  MatchConnection.ValidHelicopterGunner(deadGunner)&&
                  (await ReadWithRetry(()=>a.PollAsync(timeout.Token))).Snapshot.Players.Single(x=>x.PlayerId==one)
                      .ConfirmedEnemyHits>gunnerHitsBefore,
                  $"opposing UDP rifle fire kills the source gunner with a host respawn deadline (shots={acceptedGunnerShots})");
            async Task<ulong?> GunnerImpact(MatchConnection peer,MatchEventConsumer consumer)
            {
                ulong? result=null;
                while(true)
                {
                    var page=await ReadWithRetry(()=>peer.PollEventsAsync(consumer.LastEventId,timeout.Token));
                    consumer.Consume(page);
                    result??=page.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.Impact&&
                        x.Reason=="helicopter-gunner"&&x.ActorId==one&&
                        x.TargetId=="army:"+helicopter!.EntityKey)?.EventId;
                    if(page.Events.Count==0)break;
                }
                return result;
            }
            ulong? leftGunnerImpact=await GunnerImpact(a,leftConsumer);
            ulong? rightGunnerImpact=await GunnerImpact(b,rightConsumer);
            Check(leftGunnerImpact.HasValue&&leftGunnerImpact==rightGunnerImpact,
                  "both peers replay the same source-bound gunner impact identity");
            var ownerDead=(await ReadWithRetry(()=>b.FetchArmyEntitiesAsync(timeout.Token))).Single(x=>
                x.EntityKey==helicopter.EntityKey);
            Check(ownerDead.HelicopterGunnerHealth==0&&
                  ownerDead.HelicopterGunnerRespawnTick==deadGunner!.HelicopterGunnerRespawnTick,
                  "both peers observe the same authoritative gunner death and respawn deadline");
            BattleArmyEntityState? respawned=null;
            var respawnWatch=System.Diagnostics.Stopwatch.StartNew();
            while(respawnWatch.Elapsed<TimeSpan.FromSeconds(20)&&respawned==null)
            {
                await Task.Delay(250,timeout.Token);
                var current=(await ReadWithRetry(()=>a.FetchArmyEntitiesAsync(timeout.Token))).Single(x=>
                    x.EntityKey==helicopter.EntityKey);
                if(current.HelicopterGunnerHealth>0)respawned=current;
            }
            var ownerRespawn=(await ReadWithRetry(()=>b.FetchArmyEntitiesAsync(timeout.Token))).Single(x=>
                x.EntityKey==helicopter.EntityKey);
            Check(respawned!=null&&respawned.HelicopterGunnerHealth==
                  respawned.HelicopterGunnerMaxHealth&&respawned.HelicopterGunnerRespawnTick==0&&
                  respawned.HelicopterGunnerSpawnTick>=deadGunner!.HelicopterGunnerRespawnTick&&
                  ownerRespawn.HelicopterGunnerHealth==respawned.HelicopterGunnerHealth&&
                  ownerRespawn.HelicopterGunnerSpawnTick==respawned.HelicopterGunnerSpawnTick,
                  "both UDP peers observe the source-deadline gunner respawn");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(manifestFile);}
        return checks;
    }
}

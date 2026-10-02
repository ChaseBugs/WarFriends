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

internal static class LiveHelicopterUdpTests
{
    internal static async Task<int> Run(string directory)
    {
        int checks=0;
        void Check(bool yes,string name)
        {if(!yes)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=content.Maps.Single(x=>x.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.First(x=>x.Main&&x.Fraction==1&&x.SourceIndex==2);
        var right=map.Covers.First(x=>x.Main&&x.Fraction==2);
        var rifle=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        string one=new('a',32),two=new('b',32);
        var manifest=MatchManifest.Validate(new MatchManifest("helicopter-live-udp","local-1",
            "Park_Multiplayer",map.SourceHash,content.Revision,
            MatchManifest.RifleCombatMode,10,90,90,
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
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(75));
            using var a=new MatchConnection(Grant(one,9401));
            using var b=new MatchConnection(Grant(two,9402));
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
                  MatchConnection.ValidHelicopterTurretPose(helicopter),
                  "opponent receives live Helicopter body and turret joints through paged UDP roster");
            var ownerRows=await b.FetchArmyEntitiesAsync(timeout.Token);
            Check(ownerRows.Any(x=>x.EntityKey==helicopter!.EntityKey&&
                  MatchConnection.ValidHelicopterTurretPose(x)),
                  "both clients resolve the same combat-authorized Helicopter entity");
            var leftConsumer=new MatchEventConsumer();
            var rightConsumer=new MatchEventConsumer();
            MatchEvent? fired=null;
            MatchEvent? otherFired=null;
            bool leftSawBullet=false,rightSawBullet=false;
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
            float initialHealth=state.Snapshot.Players.Single(x=>x.PlayerId==one).Health;
            int moveCount=0,moveDirection=1;
            double nextMoveAt=0;
            ulong? leftHit=null,rightHit=null;
            float leftHealth=initialHealth,rightHealth=initialHealth;
            var damageWatch=System.Diagnostics.Stopwatch.StartNew();
            while(damageWatch.Elapsed<TimeSpan.FromSeconds(35)&&
                  (leftHit==null||rightHit==null||leftHealth>=initialHealth||rightHealth>=initialHealth))
            {
                await Task.Delay(200,timeout.Token);
                if(damageWatch.Elapsed.TotalSeconds>=nextMoveAt)
                {
                    var moved=await a.MoveCoverAsync(moveDirection,timeout.Token);
                    if(moved.Code=="moving"){moveCount++;moveDirection=-moveDirection;}
                    nextMoveAt+=1.6;
                }
                var leftPage=await a.PollEventsAsync(leftConsumer.LastEventId,timeout.Token);
                leftConsumer.Consume(leftPage);
                leftHit??=leftPage.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.Impact&&
                    x.Reason=="helicopter"&&x.TargetId==one)?.EventId;
                var rightPage=await b.PollEventsAsync(rightConsumer.LastEventId,timeout.Token);
                rightConsumer.Consume(rightPage);
                rightHit??=rightPage.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.Impact&&
                    x.Reason=="helicopter"&&x.TargetId==one)?.EventId;
                state=await a.PollAsync(timeout.Token);
                leftHealth=state.Snapshot.Players.Single(x=>x.PlayerId==one).Health;
                rightHealth=(await b.PollAsync(timeout.Token)).Snapshot.Players
                    .Single(x=>x.PlayerId==one).Health;
            }
            Check(moveCount>0&&leftHit.HasValue&&leftHit==rightHit&&
                  leftHealth<initialHealth&&rightHealth<initialHealth,
                  $"legal cover movement exposes one host-resolved Helicopter player hit to both peers (moves={moveCount}, hits={leftHit}/{rightHit}, health={leftHealth}/{rightHealth}, initial={initialHealth})");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(manifestFile);}
        return checks;
    }
}

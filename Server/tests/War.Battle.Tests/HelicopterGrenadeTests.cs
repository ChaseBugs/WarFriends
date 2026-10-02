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

internal static class HelicopterGrenadeTests
{
    internal static async Task<int> RunUdp(string directory)
    {
        int checks=0;
        void Check(bool value,string name){if(!value)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            grenadeManifestPath:Path.Combine(directory,"grenade-content-manifest.json"));
        var map=content.Maps.Single(x=>x.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.First(x=>x.Main&&x.Fraction==1&&x.SourceIndex==2);
        var right=map.Covers.First(x=>x.Main&&x.Fraction==2);
        string one=new('a',32),two=new('b',32);
        var weapon=content.Grenades!.CreateManifest("Google2u.GrenadeLauncher_M320",0);
        var manifest=MatchManifest.Validate(new MatchManifest("helicopter-grenade-udp","local-1",
            "Park_Multiplayer",map.SourceHash,content.GrenadeRevision!,
            MatchManifest.GrenadeCombatMode,10,180,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1_000_000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]},
             new(two,weapon,2,right.SourceIndex,1,new(1_000_000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]}])
            {SceneMasterPlayerId=one});
        content.ValidateAllocation(manifest);
        string file=Path.Combine(Path.GetTempPath(),"war-helicopter-grenade-"+Guid.NewGuid().ToString("N")+".json");
        string outbox=Path.Combine(Path.GetTempPath(),"war-helicopter-grenade-outbox-"+Guid.NewGuid().ToString("N"));
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,["Battle:ResultOutboxPath"]=outbox,
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json"),
            ["Battle:GrenadeContentManifestPath"]=Path.Combine(directory,"grenade-content-manifest.json")
        }).Build();
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,
                MatchId=manifest.MatchId,ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(120));
            using var a=new MatchConnection(Grant(one,9511));
            using var b=new MatchConnection(Grant(two,9512));
            async Task<T> Read<T>(Func<Task<T>> action)
            {
                for(int attempt=0;;attempt++)
                    try{return await action();}
                    catch(TimeoutException) when(attempt<2){await Task.Delay(50,timeout.Token);}
            }
            async Task<MatchReply> Mutate(MatchConnection peer,Func<Task<MatchReply>> action)
            {
                try{return await action();}
                catch(TimeoutException)
                {
                    for(int attempt=0;;attempt++)
                        try{return await peer.RetryPendingAsync(timeout.Token);}
                        catch(TimeoutException) when(attempt<2){await Task.Delay(50,timeout.Token);}
                }
            }
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "two signed UDP peers enter grenade Helicopter match");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do{await Task.Delay(100,timeout.Token);state=await Read(()=>a.PollAsync(timeout.Token));}
            while(state.Snapshot.Phase!=BattlePhase.Running);
            Check((await Read(()=>b.PollArmyAsync(timeout.Token))).OptionIndexes.SequenceEqual([2,2,2])&&
                  (await Mutate(b,()=>b.DeployArmyAsync(2,timeout.Token))).Code=="army-deploying",
                "owner deploys source Helicopter over UDP");
            BattleArmyEntityState? helicopter=null;
            var deployWatch=System.Diagnostics.Stopwatch.StartNew();
            while(deployWatch.Elapsed<TimeSpan.FromSeconds(40)&&helicopter is not {HelicopterStopTick:>0})
            {
                await Task.Delay(120,timeout.Token);
                helicopter=(await Read(()=>a.FetchArmyEntitiesAsync(timeout.Token)))
                    .SingleOrDefault(x=>x.UnitId=="ID_UNIT-HELICOPTER");
            }
            Check(helicopter is {HelicopterStopTick:>0,HelicopterGunnerHealth:>0},
                "UDP roster carries live source gunner after Helicopter stop");
            float initial=helicopter!.HelicopterGunnerHealth;
            var q=helicopter.HelicopterRotation!;
            var seat=content.HelicopterCrewPoints.PlaceTurret(new(helicopter.X,helicopter.Y,helicopter.Z),
                new Quaternion(q.X,q.Y,q.Z,q.W));
            var target=content.GroundVehicleWeapons.PassengerPoses.PlaceHelicopterGunner(seat,
                helicopter.PositionTick-helicopter.HelicopterGunnerSpawnTick)
                .Single(x=>x.Weight==1.5f).Center+new Vector3(0,1.5f,0);
            Check((await Mutate(a,()=>a.GrenadeLauncherThrowAsync(target.X,target.Y,target.Z,timeout.Token)))
                .Code=="grenade-throwing","authenticated M320 click targets current gunner");
            float leftHealth=initial,rightHealth=initial;uint hits=0;
            var damageWatch=System.Diagnostics.Stopwatch.StartNew();
            while(damageWatch.Elapsed<TimeSpan.FromSeconds(30)&&leftHealth>=initial)
            {
                await Task.Delay(150,timeout.Token);
                var rows=await Read(()=>a.FetchArmyEntitiesAsync(timeout.Token));
                leftHealth=rows.Single(x=>x.EntityKey==helicopter.EntityKey).HelicopterGunnerHealth;
            }
            rightHealth=(await Read(()=>b.FetchArmyEntitiesAsync(timeout.Token)))
                .Single(x=>x.EntityKey==helicopter.EntityKey).HelicopterGunnerHealth;
            hits=(await Read(()=>a.PollAsync(timeout.Token))).Snapshot.Players
                .Single(x=>x.PlayerId==one).ConfirmedEnemyHits;
            Check(leftHealth<initial&&rightHealth<initial&&hits>0,
                $"real UDP M320 impact damages one source gunner for both peers ({leftHealth}/{rightHealth}/{initial}, hits={hits})");
            async Task<ulong?> Impact(MatchConnection peer)
            {
                var consumer=new MatchEventConsumer();ulong? found=null;
                while(true)
                {
                    var page=await Read(()=>peer.PollEventsAsync(consumer.LastEventId,timeout.Token));
                    consumer.Consume(page);
                    found??=page.Events.FirstOrDefault(x=>x.Kind==MatchEventKind.Impact&&
                        x.ActorId==one&&x.Reason=="grenade")?.EventId;
                    if(page.Events.Count==0)break;
                }
                return found;
            }
            ulong? leftImpact=await Impact(a),rightImpact=await Impact(b);
            Check(leftImpact.HasValue&&leftImpact==rightImpact,
                "both SDK peers replay the same real M320 explosion event");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(file);if(Directory.Exists(outbox))Directory.Delete(outbox,true);
        }
        return checks;
    }

    internal static int Run(string directory)
    {
        int checks=0;
        void Check(bool value,string name){if(!value)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"),
            grenadeManifestPath:Path.Combine(directory,"grenade-content-manifest.json"));
        var map=content.Maps.Single(x=>x.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.First(x=>x.Main&&x.Fraction==1&&x.SourceIndex==2);
        var right=map.Covers.First(x=>x.Main&&x.Fraction==2);
        string one=new('a',32),two=new('b',32);
        var weapon=content.Grenades!.CreateManifest("Google2u.GrenadeLauncher_M320",0);
        var manifest=MatchManifest.Validate(new MatchManifest("helicopter-grenade","local-1",
            "Park_Multiplayer",map.SourceHash,content.GrenadeRevision!,
            MatchManifest.GrenadeCombatMode,10,180,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1_000_000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]},
             new(two,weapon,2,right.SourceIndex,1,new(1_000_000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"],ArmyNormalUpgradeIndexes=[0],
                 ArmySpecialUpgradeIndexes=[-1],ArmyEliteUpgradeIndexes=[-1],
                 ArmyHealthFactors=[new ArmyHealthFactors(1,1)],ArmyDamageScales=[1],
                 ArmySpeedCoefficients=[1],ArmyAccuracyCoefficients=[1]}])
            {SceneMasterPlayerId=one});
        content.ValidateAllocation(manifest);
        var match=new MatchEngine(manifest,content:content);
        match.Admit(one);match.Admit(two);
        foreach(var id in new[]{one,two})match.Command(id,new MatchCommand{CommandId=1,
            Ready=new ReadyCommand{ManifestHash=match.ManifestHash}});
        match.Advance(60);
        Check(match.ArmyBatch(two).OptionIndexes.SequenceEqual([2,2,2])&&
              match.Command(two,new MatchCommand{CommandId=2,
                  DeployArmy=new DeployArmyCommand{OptionIndex=2}}).Code=="army-deploying",
              "grenade duel deploys source Helicopter");
        ulong tick=60;BattleArmyEntityState? helicopter=null;
        while(tick<1800&&!match.Terminal)
        {
            match.Advance(++tick);
            helicopter=match.ArmyEntityBatch(one,0,0).Entities.SingleOrDefault(x=>
                x.UnitId=="ID_UNIT-HELICOPTER");
            if(helicopter is {HelicopterStopTick:>0})break;
        }
        Check(helicopter is {HelicopterStopTick:>0,HelicopterGunnerHealth:>0},
            "live Helicopter gunner remains available after source stop");
        float initial=helicopter!.HelicopterGunnerHealth;
        var q=helicopter.HelicopterRotation!;
        var seat=content.HelicopterCrewPoints.PlaceTurret(new(helicopter.X,helicopter.Y,helicopter.Z),
            new Quaternion(q.X,q.Y,q.Z,q.W));
        var parts=content.GroundVehicleWeapons.PassengerPoses.PlaceHelicopterGunner(seat,
            helicopter.PositionTick-helicopter.HelicopterGunnerSpawnTick);
        var target=parts.Single(x=>x.Weight==1.5f).Center+new Vector3(0,1.5f,0);
        Check(match.Command(one,new MatchCommand{CommandId=2,GrenadeThrow=new GrenadeThrowCommand
            {TargetX=target.X,TargetY=target.Y,TargetZ=target.Z}}).Code=="grenade-throwing",
            "signed-equivalent source M320 click targets live gunner pose");
        bool damaged=false,impact=false;
        for(int i=0;i<450&&!match.Terminal&&!damaged;i++)
        {
            match.Advance(++tick);
            helicopter=match.ArmyEntityBatch(one,0,0).Entities.Single(x=>x.EntityKey==helicopter.EntityKey);
            damaged=helicopter.HelicopterGunnerHealth<initial;
        }
        ulong cursor=0;var finalEvents=new List<string>();
        while(true)
        {
            var page=match.EventBatch(one,cursor);
            foreach(var row in page.Events.Where(x=>x.Kind==MatchEventKind.Impact&&x.ActorId==one))
            {
                impact|=row.Reason=="grenade";
                finalEvents.Add($"{row.Reason}@({row.X:F2},{row.Y:F2},{row.Z:F2})");
            }
            if(page.Events.Count==0||page.Events[^1].EventId==page.LatestEventId)break;
            cursor=page.Events[^1].EventId;
        }
        Check(impact&&damaged&&match.Snapshot().Players.Single(x=>x.PlayerId==one).ConfirmedEnemyHits>0,
            $"real host M320 flight explodes near gunner and changes authoritative health: impact={impact} damaged={damaged} terminal={match.Terminal} health={helicopter.HelicopterGunnerHealth}/{initial} shots={match.Snapshot().Players.Single(x=>x.PlayerId==one).ShotsFired} events={string.Join(';',finalEvents)} target={target}");
        return checks;
    }
}

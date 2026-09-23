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

internal static class LiveBarrelUdpTests
{
    internal static async Task<int> Run(string directory)
    {
        int checks=0;
        void Check(bool yes,string name){if(!yes)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.Single(c=>c.SourceIndex==1);
        var right=map.Covers.First(c=>c.Main&&c.Fraction==2);
        var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        string one=new('a',32),two=new('b',32);
        var manifest=new MatchManifest("barrel-udp","local-1","Park_Multiplayer",map.SourceHash,
            content.Revision,MatchManifest.RifleCombatMode,10,60,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-ASSAULT"]},
             new(two,weapon,2,right.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-HELICOPTER"]}])
            {SceneMasterPlayerId=one};
        string file=Path.Combine(Path.GetTempPath(),"war-barrel-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,
            ["Battle:Port"]=port.ToString(),["Battle:MatchManifestPath"]=file,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-barrel-outbox-"+Guid.NewGuid().ToString("N")),
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json")
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        MatchConnectionGrant Grant(string id,ulong session,ulong generation=0)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120,
                ConnectionGeneration=generation};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,
                MatchId=admission.MatchId,ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(35));
            using var a=new MatchConnection(Grant(one,931));using var b=new MatchConnection(Grant(two,932));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted" &&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "two Park peers admitted with signed scene-master barrel authority");
            var tracker=new BarrelStateTracker(manifest.MatchId,manifest.Digest(),
                content.Barrels.ForMap(map).Select(x=>new BarrelSceneIdentity(x.ColliderIndex,x.GameObjectFileId)));
            var eventTracker=new BarrelStateTracker(manifest.MatchId,manifest.Digest(),
                content.Barrels.ForMap(map).Select(x=>new BarrelSceneIdentity(x.ColliderIndex,x.GameObjectFileId)));
            var initial=await a.PollBarrelsAsync(timeout.Token);tracker.Apply(initial);
            eventTracker.Apply(initial);
            Check(initial.SourceCount==10 && initial.MaxHealth==50 &&
                  tracker.Snapshot().All(x=>x.Revision==0),"UDP initial barrel projection uses source HP");
            Check((await a.PollArmyAsync(timeout.Token)).Code=="army-not-running",
                  "admitted player cannot draw a prestart army hand");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do{await Task.Delay(100,timeout.Token);state=await a.PollAsync(timeout.Token);}
            while(state.Snapshot.Phase!=BattlePhase.Running);
            var armyA=await a.PollArmyAsync(timeout.Token);
            var armyB=await b.PollArmyAsync(timeout.Token);
            Check(armyA.Code=="army-offers" && armyA.OptionIndexes.Count==3 &&
                  armyA.OptionIndexes.All(x=>x is 0 or 1) &&
                  armyB.Code=="army-offers" && armyB.OptionIndexes.SequenceEqual([2,2,2]) &&
                  armyA.Energy==8 && armyB.Energy==8,
                  "two authenticated peers receive only their own equipped source options");
            var armyReplay=await a.PollArmyAsync(timeout.Token);
            Check(armyReplay.OptionIndexes.SequenceEqual(armyA.OptionIndexes) &&
                  armyReplay.StateRevision>=armyA.StateRevision,
                  "retrying the army read retains the issued host hand");
            Check((await a.DeployArmyAsync(2,timeout.Token)).Code=="army-not-offered",
                  "a player cannot deploy the opposing helicopter option");
            int selectedArmy=1; // Both source Assault options are in the issued hand.
            int expectedSoldiers=content.Army.Option(selectedArmy).Count;
            Check((await a.DeployArmyAsync(selectedArmy,timeout.Token)).Code=="army-deploying",
                  "signed offered army option enters the host spawn schedule");
            await Task.Delay(1150,timeout.Token);
            var armyAfter=await a.PollArmyAsync(timeout.Token);
            Check(armyAfter.ActiveCount==expectedSoldiers && armyAfter.PendingCount==0 &&
                  armyAfter.Energy==8-content.Army.Option(selectedArmy).Power,
                  "scheduled units debit energy as they enter host entity state");
            var spawnStats=(await a.PollAsync(timeout.Token)).Snapshot;
            Check(spawnStats.Players[0].ConfirmedArmySpawns==expectedSoldiers &&
                  spawnStats.Players[1].ConfirmedArmySpawns==0 &&
                  spawnStats.Players.All(p=>p.ConfirmedArmyLosses==0),
                  "both UDP peers see only host-confirmed soldier spawns, not accepted clicks");
            var activeArmy=await a.FetchArmyEntitiesAsync(timeout.Token);
            var otherArmy=await b.FetchArmyEntitiesAsync(timeout.Token);
            Check(activeArmy.Count==expectedSoldiers && activeArmy.SequenceEqual(otherArmy) &&
                  activeArmy.All(x=>x.OwnerPlayerId==one && x.UnitId=="ID_UNIT-ASSAULT" &&
                    x.SpawnComponentFileId>0),
                  "both peers reconstruct the same complete active army entities");
            var armyPage=await a.PollArmyEntitiesAsync(0,0,timeout.Token);
            Check(armyPage.Code=="entities" && armyPage.ServerTick>=spawnStats.ServerTick &&
                  armyPage.Entities.Count>0 && armyPage.Entities.All(x=>
                    x.PositionTick>=x.SpawnTick && x.PositionTick<=armyPage.ServerTick),
                  "live UDP entity pages carry bounded position samples and a server tick");
            Check((await a.PollArmyEntitiesAsync(0,999,timeout.Token)).Code=="revision-changed",
                  "stale reconnect revision cannot be mixed into a new entity projection");
            var center=map.DynamicColliders.Single(x=>x.ColliderIndex==82).TransformPosition;
            MatchBarrelBatch current=initial;
            for(int i=0;i<25 && !current.Changed.Any(x=>x.ColliderIndex==82 && x.Destroyed);i++)
            {
                await b.PollAsync(timeout.Token);
                await a.FireAsync(center.X,center.Y,center.Z,timeout.Token);
                await Task.Delay(220,timeout.Token);
                current=await a.PollBarrelsAsync(timeout.Token);
                tracker.Apply(current);
            }
            Check(current.Changed.Any(x=>x.ColliderIndex==82 && x.Destroyed) &&
                  tracker.Snapshot().Single(x=>x.ColliderIndex==82).Destroyed,
                  "real two-peer UDP rifle fire destroys Park barrel and reconnect projection agrees");
            async Task<List<MatchEvent>> Events(MatchConnection peer)
            {
                var rows=new List<MatchEvent>();ulong cursor=0;
                while(true)
                {
                    var batch=await peer.PollEventsAsync(cursor,timeout.Token);
                    if(batch.Events.Count==0)return rows;
                    rows.AddRange(batch.Events);cursor=batch.Events[^1].EventId;
                }
            }
            var first=await Events(a);var second=await Events(b);
            var armyEvents=first.Where(x=>x.Kind==MatchEventKind.ArmySpawned).ToArray();
            var allowedSpawnIds=content.ArmySpawnPoints.ForMap(map).Where(p=>p.Fraction==1 &&
                p.Collection=="spawnPointsCollection").Select(p=>p.ComponentFileId).ToHashSet();
            Check(armyEvents.Length==expectedSoldiers && armyEvents.All(x=>x.ActorId==one &&
                  x.ArmyOptionIndex==selectedArmy && x.ArmyUnitId=="ID_UNIT-ASSAULT" &&
                  x.ArmyEntityId>0 && allowedSpawnIds.Contains(x.ArmySpawnComponentFileId)),
                  "both peers receive source-bound host soldier spawn records");
            Check(first.SequenceEqual(second) &&
                  first.Any(x=>x.Kind==MatchEventKind.BarrelDamaged && x.BarrelColliderIndex==82) &&
                  first.Any(x=>x.Kind==MatchEventKind.BarrelDestroyed && x.BarrelColliderIndex==82 &&
                      x.BarrelGameObjectFileId==tracker.Snapshot().Single(y=>y.ColliderIndex==82).GameObjectFileId &&
                      x.BarrelRevision>0),
                  "both UDP peers replay identical source-ID barrel damage and death events");
            var barrelEvents=first.Where(x=>x.Kind is MatchEventKind.BarrelDamaged or
                MatchEventKind.BarrelDestroyed).ToArray();
            foreach(var item in barrelEvents)eventTracker.ApplyEvent(item);
            Check(eventTracker.Snapshot().Zip(tracker.Snapshot()).All(pair=>
                    pair.First.ColliderIndex==pair.Second.ColliderIndex &&
                    pair.First.Health==pair.Second.Health && pair.First.Revision==pair.Second.Revision &&
                    pair.First.Destroyed==pair.Second.Destroyed),
                "ordered barrel events reconstruct the same complete state as the reconnect poll");
            var gapTracker=new BarrelStateTracker(manifest.MatchId,manifest.Digest(),
                content.Barrels.ForMap(map).Select(x=>new BarrelSceneIdentity(x.ColliderIndex,x.GameObjectFileId)));
            gapTracker.Apply(initial);
            var skipped=barrelEvents[0].Clone();skipped.BarrelRevision+=2;
            try{gapTracker.ApplyEvent(skipped);throw new Exception("missing barrel revision accepted");}
            catch(InvalidOperationException){checks++;}
            Check((await b.DeployArmyAsync(2,timeout.Token)).Code=="army-deploying",
                  "second player deploys its independently offered helicopter");
            await Task.Delay(220,timeout.Token);
            var firstPage=await b.PollArmyEntitiesAsync(0,0,timeout.Token);
            var secondPage=await b.PollArmyEntitiesAsync(firstPage.Entities[^1].EntityKey,
                firstPage.Revision,timeout.Token);
            var completeArmy=await b.FetchArmyEntitiesAsync(timeout.Token);
            var allSpawnStats=(await b.PollAsync(timeout.Token)).Snapshot;
            Check(firstPage.Code=="entities" && firstPage.Entities.Count==4 && firstPage.HasMore &&
                  secondPage.Code=="entities" && secondPage.Entities.Count==1 && !secondPage.HasMore &&
                  completeArmy.Count==5 && completeArmy.Any(x=>x.OwnerPlayerId==two &&
                      x.UnitId=="ID_UNIT-HELICOPTER" && x.ReservationFileId>0),
                  "five active units page below the UDP MTU with the helicopter route bound");
            Check(allSpawnStats.Players[0].ConfirmedArmySpawns==expectedSoldiers &&
                  allSpawnStats.Players[1].ConfirmedArmySpawns==1,
                  "host-confirmed soldier and helicopter spawn totals survive the shared UDP snapshot");
            using var resumed=new MatchConnection(Grant(one,933,1));
            Check((await resumed.ConnectAsync(timeout.Token)).Code=="admitted" &&
                  (await resumed.FetchArmyEntitiesAsync(timeout.Token)).SequenceEqual(completeArmy),
                  "new signed session rebuilds active entities without relying on event history");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        return checks;
    }
}

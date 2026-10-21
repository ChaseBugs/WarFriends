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

internal static class LiveRusherUdpTests
{
    internal static Task<int> RunShotgunnerOnly(string directory)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        var map = content.Maps.Single(value => value.Source.EndsWith(
            "Park_Multiplayer.unity", StringComparison.Ordinal));
        var left = map.Covers.First(cover => cover.Main && cover.Fraction == 1);
        var right = map.Covers.First(cover => cover.Main && cover.Fraction == 2);
        var weapon = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        return RunShotgunner(directory, content, map, left, right, weapon);
    }

    internal static Task<int> RunNormalSniperOnly(string directory)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory,
            "combat-content-manifest.json"));
        var map = content.Maps.Single(value => value.Source.EndsWith(
            "Park_Multiplayer.unity", StringComparison.Ordinal));
        var left = map.Covers.First(cover => cover.Main && cover.Fraction == 1);
        var right = map.Covers.First(cover => cover.Main && cover.Fraction == 2);
        var weapon = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        return RunNormalSniper(directory, content, map, left, right, weapon);
    }

    internal static async Task<int> Run(string directory)
    {
        int checks=0;
        void Check(bool yes,string name){if(!yes)throw new Exception(name);checks++;}
        var content=BattleCombatContent.Load(Path.Combine(directory,"combat-content-manifest.json"));
        var map=content.Maps.Single(m=>m.Source.EndsWith("Park_Multiplayer.unity",StringComparison.Ordinal));
        var left=map.Covers.First(c=>c.Main && c.Fraction==1);
        var right=map.Covers.First(c=>c.Main && c.Fraction==2);
        var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
        string one=new('a',32),two=new('b',32);
        var manifest=new MatchManifest("rusher-udp","local-1","Park_Multiplayer",map.SourceHash,
            content.Revision,MatchManifest.RifleCombatMode,10,60,120,
            [new(one,weapon,1,left.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-FLAMETHROWER"],
                 ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[-1],
                 ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],
                 ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[2f]},
             new(two,weapon,2,right.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-FLAMETHROWER"],
                 ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[-1],
                 ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],
                 ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],ArmyAccuracyCoefficients=[2f]}])
            {SceneMasterPlayerId=one};
        string file=Path.Combine(Path.GetTempPath(),"war-rusher-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,
            ["Battle:Port"]=port.ToString(),["Battle:MatchManifestPath"]=file,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-rusher-outbox-"+Guid.NewGuid().ToString("N")),
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
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(35));
            using var a=new MatchConnection(Grant(one,981));using var b=new MatchConnection(Grant(two,982));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted" &&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "two UDP peers admitted for source Rusher movement");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do{await Task.Delay(100,timeout.Token);state=await a.PollAsync(timeout.Token);}
            while(state.Snapshot.Phase!=BattlePhase.Running);
            var hand=await a.PollArmyAsync(timeout.Token);
            int option=hand.OptionIndexes.OrderByDescending(x=>content.Army.Option(x).Count).First();
            int count=content.Army.Option(option).Count;
            Check(hand.Code=="army-offers" && count>0 &&
                  (await a.DeployArmyAsync(option,timeout.Token)).Code=="army-deploying",
                  "host accepts one issued Rusher option");
            MatchArmyEntityBatch first;
            do
            {
                await Task.Delay(100,timeout.Token);
                first=await a.PollArmyEntitiesAsync(0,0,timeout.Token);
            }
            while(first.ActiveCount<(uint)count);
            Check(first.Code=="entities" && first.Entities.Count==count &&
                  first.Entities.All(x=>x.PositionTick>=x.SpawnTick),
                  "host publishes source-bound Rusher spawn rows");
            await Task.Delay(450,timeout.Token);
            var movedA=await a.PollArmyEntitiesAsync(0,first.Revision,timeout.Token);
            var movedB=await b.PollArmyEntitiesAsync(0,first.Revision,timeout.Token);
            Check(movedA.Code=="entities" && movedB.Code=="entities" &&
                  movedA.Revision==first.Revision && movedB.Revision==first.Revision &&
                  movedA.Entities.Count==count && movedB.Entities.Count==count &&
                  movedA.Entities.All(x=>x.PositionTick>x.SpawnTick &&
                    x.PositionTick<=movedA.ServerTick &&
                    first.Entities.Any(y=>y.EntityKey==x.EntityKey &&
                      (x.X!=y.X || x.Y!=y.Y || x.Z!=y.Z))) &&
                  movedA.Entities.Select(x=>x.EntityKey).SequenceEqual(movedB.Entities.Select(x=>x.EntityKey)),
                  "both UDP peers see advancing Rusher positions without reconnect revision churn");
            ulong cursor=0;bool flameShot=false,flameImpact=false,damaged=false;float? flameShotY=null;
            MatchArmyEntityBatch? flameShotEntities=null;
            while(!damaged)
            {
                await Task.Delay(100,timeout.Token);
                var snapshot=await b.PollAsync(timeout.Token);
                damaged=snapshot.Snapshot.Players.Single(x=>x.PlayerId==two).Health<1000;
                var events=await b.PollEventsAsync(cursor,timeout.Token);
                foreach(var row in events.Events)
                {
                    cursor=row.EventId;
                    if(row.Kind==MatchEventKind.Shot&&row.Reason=="army-flame")
                    {flameShot=true;flameShotY??=row.Y;}
                    if(row.Kind==MatchEventKind.Impact&&row.Reason=="army-flame")flameImpact=true;
                }
                if(flameShotY.HasValue&&flameShotEntities==null)
                    flameShotEntities=await b.PollArmyEntitiesAsync(0,0,timeout.Token);
            }
            Check(flameShot&&flameImpact&&damaged,
                  "live Flamethrower navigation produces authoritative shot, pulse impact, and player health loss");
            Check(flameShotY.HasValue&&flameShotEntities!=null&&flameShotEntities.Entities.Any(entity=>
                    Math.Abs(flameShotY.Value-entity.Y-
                        content.ArmyWeapons.Muzzle("ID_UNIT-FLAMETHROWER").RestPosition.Y)<.08f),
                  $"live flame shot event starts at the recovered weapon muzzle above its host unit root: shotY={flameShotY}, roots={string.Join(',',flameShotEntities?.Entities.Select(x=>x.Y)??[])}");
            var opposingHand=await b.PollArmyAsync(timeout.Token);
            int opposingOption=opposingHand.OptionIndexes.OrderByDescending(x=>
                content.Army.Option(x).Count).First();
            int opposingCount=content.Army.Option(opposingOption).Count;
            Check(opposingHand.Code=="army-offers" &&
                  (await b.DeployArmyAsync(opposingOption,timeout.Token)).Code=="army-deploying",
                  "opposing peer deploys its own trusted Rusher family");
            MatchArmyEntityBatch opposingPage;
            do
            {
                await Task.Delay(100,timeout.Token);
                opposingPage=await b.PollArmyEntitiesAsync(0,0,timeout.Token);
            }
            while(opposingPage.ActiveCount<(uint)(count+opposingCount));
            await Task.Delay(450,timeout.Token);
            var bothPeers=await a.FetchArmyEntitiesAsync(timeout.Token);
            Check(bothPeers.Count==count+opposingCount &&
                  bothPeers.Count(x=>x.OwnerPlayerId==one)==count &&
                  bothPeers.Count(x=>x.OwnerPlayerId==two)==opposingCount &&
                  bothPeers.All(x=>x.PositionTick>x.SpawnTick),
                  "live Worker publishes simultaneous opposing Rusher motion to the SDK");
            Check((await b.ForfeitAsync(timeout.Token)).Code == "forfeited",
                "the live Flame match reaches a normal terminal result");
            while (!worker.Outbox.HasIdentity(manifest.MatchId))
            {
                await Task.Delay(50, timeout.Token);
            }

            MatchSnapshot terminal = worker.Outbox.Pending().Single();
            BattlePlayerState flameOwner = terminal.Players.Single(player => player.PlayerId == one);
            Check(flameOwner.ConfirmedSkillShotCounts.Count == content.PvpScores.Rows.Count &&
                  flameOwner.ConfirmedSkillShotCounts.Single(row => row.Flag == 524288).Count >= 1,
                "a live Army Flame pulse persists the source ArmyPlayerHit counter");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        checks+=await RunCommando(directory,content,map,left,right,weapon);
        checks+=await RunShotgunner(directory,content,map,left,right,weapon);
        checks+=await RunNormalSniper(directory,content,map,left,right,weapon);
        return checks;
    }

    private static async Task<int> RunCommando(string directory,BattleCombatContent content,
        RecoveredBattleMap map,CoverNode left,CoverNode right,WeaponManifest weapon)
    {
        int checks=0;
        void Check(bool yes,string name){if(!yes)throw new Exception(name);checks++;}
        string one=new('c',32),two=new('d',32);
        ParticipantManifest Player(string id,int fraction,int cover,int special)=>new(id,weapon,fraction,cover,1,new(100000),0,0,0)
        {EquippedArmyUnitIds=["ID_UNIT-COMMANDO"],ArmyNormalUpgradeIndexes=[0],
         ArmySpecialUpgradeIndexes=[special],ArmyEliteUpgradeIndexes=[-1],
         ArmyHealthFactors=[new(1f,1f)],ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],
         ArmyAccuracyCoefficients=[2f]};
        var manifest=new MatchManifest("commando-udp","local-1","Park_Multiplayer",map.SourceHash,
            content.Revision,MatchManifest.RifleCombatMode,10,60,120,
            [Player(one,1,left.SourceIndex,71),Player(two,2,right.SourceIndex,-1)]){SceneMasterPlayerId=one};
        string file=Path.Combine(Path.GetTempPath(),"war-commando-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,["Battle:Port"]=port.ToString(),
            ["Battle:MatchManifestPath"]=file,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),"war-commando-outbox-"+Guid.NewGuid().ToString("N")),
            ["Battle:CombatContentManifestPath"]=Path.Combine(directory,"combat-content-manifest.json")
        }).Build();
        MatchConnectionGrant Grant(string id,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=id,SessionId=session,ManifestHash=manifest.Digest(),IssuedUnixSeconds=now,
                ExpiresUnixSeconds=now+120};
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=id,SessionId=session,
                MatchId=admission.MatchId,ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(35));
            using var a=new MatchConnection(Grant(one,991));using var b=new MatchConnection(Grant(two,992));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "two UDP peers admitted for Commando authority");
            await a.ReadyAsync(timeout.Token);await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do{await Task.Delay(100,timeout.Token);state=await a.PollAsync(timeout.Token);}
            while(state.Snapshot.Phase!=BattlePhase.Running);
            var hand=await a.PollArmyAsync(timeout.Token);
            int option=hand.OptionIndexes.OrderByDescending(x=>content.Army.Option(x).Count).First();
            Check((await a.DeployArmyAsync(option,timeout.Token)).Code=="army-deploying",
                  "live Commando deployment uses its trusted family-only offer");
            ulong cursor=0;var shots=new List<MatchEvent>();bool impact=false,damaged=false;
            var poisonByProjectile=new Dictionary<ulong,List<ulong>>();
            var poisonFlights = new HashSet<ulong>();
            while(shots.Count<3||!impact||!damaged||!poisonByProjectile.Values.Any(x=>x.Count==5))
            {
                await Task.Delay(100,timeout.Token);
                var snapshot=await b.PollAsync(timeout.Token);
                damaged=snapshot.Snapshot.Players.Single(x=>x.PlayerId==two).Health<100000;
                foreach (var projectile in snapshot.Snapshot.Projectiles.Where(row =>
                    row.Kind == "army-bullet" && row.OwnerPlayerId == one))
                {
                    Check(projectile.ArmyUnitId == "ID_UNIT-COMMANDO" &&
                          projectile.ArmySourceCardId.Length == 0 &&
                          projectile.ArmyPoison &&
                          MathF.Abs(MathF.Sqrt(
                              projectile.VelocityX * projectile.VelocityX +
                              projectile.VelocityY * projectile.VelocityY +
                              projectile.VelocityZ * projectile.VelocityZ) - 5f) < .001f,
                        "special Commando publishes its source poison bullet at speed five");
                    poisonFlights.Add(projectile.ProjectileId);
                }
                var events=await b.PollEventsAsync(cursor,timeout.Token);
                foreach(var row in events.Events)
                {
                    cursor=row.EventId;
                    if(row.Kind==MatchEventKind.Shot&&row.Reason=="army"&&row.ActorId==one)shots.Add(row);
                    if(row.Kind==MatchEventKind.Impact&&row.Reason=="army")impact=true;
                    if(row.Kind==MatchEventKind.Impact&&row.Reason=="army-poison")
                    {
                        if(!poisonByProjectile.TryGetValue(row.ProjectileId,out var ticks))
                            poisonByProjectile.Add(row.ProjectileId,ticks=[]);
                        ticks.Add(row.Tick);
                    }
                }
            }
            float Distance(MatchEvent x,MatchEvent y)=>MathF.Sqrt(
                MathF.Pow(x.X-y.X,2)+MathF.Pow(x.Y-y.Y,2)+MathF.Pow(x.Z-y.Z,2));
            Check(Distance(shots[0],shots[1])>.1f&&Distance(shots[0],shots[2])<.001f&&impact&&damaged,
                  "live Commando alternates source right/left muzzles and applies speed-five projectile damage");
            var completePoison=poisonByProjectile.Values.First(x=>x.Count==5);
            Check(poisonByProjectile.Keys.Any(poisonFlights.Contains),
                  "a host-published poison flight owns the later five-pulse receipt");
            Check(completePoison.Zip(completePoison.Skip(1),(aTick,bTick)=>bTick-aTick)
                      .All(delta=>delta==MatchManifest.TickRate),
                  "live special Commando hit stacks its own immediate plus four one-second poison pulses");
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        return checks;
    }

    private static async Task<int> RunShotgunner(string directory,BattleCombatContent content,
        RecoveredBattleMap map,CoverNode left,CoverNode right,WeaponManifest weapon)
    {
        int checks=0;
        void Check(bool condition,string message)
        {
            if(!condition)throw new Exception(message);
            checks++;
        }
        string owner=new('e',32),opponent=new('f',32);
        ParticipantManifest Player(string id,int fraction,int cover)=>
            new(id,weapon,fraction,cover,1,new(100000),0,0,0)
            {
                EquippedArmyUnitIds=["ID_UNIT-SHOTGUNNER"],
                ArmyNormalUpgradeIndexes=[0],ArmySpecialUpgradeIndexes=[-1],
                ArmyEliteUpgradeIndexes=[-1],ArmyHealthFactors=[new(1f,1f)],
                ArmyDamageScales=[1f],ArmySpeedCoefficients=[1f],
                ArmyAccuracyCoefficients=[2f]
            };
        var manifest=new MatchManifest("shotgunner-pellets-udp","local-1",
            "Park_Multiplayer",map.SourceHash,content.Revision,
            MatchManifest.RifleCombatMode,10,60,120,
            [Player(owner,1,left.SourceIndex),Player(opponent,2,right.SourceIndex)])
            {SceneMasterPlayerId=owner};
        string file=Path.Combine(Path.GetTempPath(),
            "war-shotgunner-udp-"+Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(file,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;
        probe.Close();
        string key=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(key);
        var config=new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string,string?>
            {
                ["Battle:SigningKey"]=key,["Battle:ServerId"]=manifest.ServerId,
                ["Battle:Port"]=port.ToString(),["Battle:MatchManifestPath"]=file,
                ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),
                    "war-shotgunner-outbox-"+Guid.NewGuid().ToString("N")),
                ["Battle:CombatContentManifestPath"]=Path.Combine(directory,
                    "combat-content-manifest.json")
            }).Build();
        MatchConnectionGrant Grant(string playerId,ulong session)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission
            {
                MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=playerId,SessionId=session,ManifestHash=manifest.Digest(),
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120
            };
            return new(){Host="127.0.0.1",Port=(uint)port,PlayerId=playerId,
                SessionId=session,MatchId=admission.MatchId,
                ManifestHash=admission.ManifestHash,
                ExpiresUnixSeconds=admission.ExpiresUnixSeconds,
                Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(45));
            using var a=new MatchConnection(Grant(owner,993));
            using var b=new MatchConnection(Grant(opponent,994));
            Check((await a.ConnectAsync(timeout.Token)).Code=="admitted"&&
                  (await b.ConnectAsync(timeout.Token)).Code=="admitted",
                  "two signed UDP peers admit the Shotgunner match");
            await a.ReadyAsync(timeout.Token);
            await b.ReadyAsync(timeout.Token);
            MatchReply state;
            do
            {
                await Task.Delay(100,timeout.Token);
                state=await a.PollAsync(timeout.Token);
            } while(state.Snapshot.Phase!=BattlePhase.Running);
            var hand=await a.PollArmyAsync(timeout.Token);
            int option=hand.OptionIndexes.First();
            Check((await a.DeployArmyAsync(option,timeout.Token)).Code=="army-deploying",
                  "the host deploys the recovered Shotgunner family");

            bool ownerSawBurst=false,opponentSawBurst=false,scanReplayed=false;
            var scanSamples = new HashSet<string>();
            var ownerBursts = new HashSet<string>(StringComparer.Ordinal);
            var opponentBursts = new HashSet<string>(StringComparer.Ordinal);
            var watch=System.Diagnostics.Stopwatch.StartNew();
            while(watch.Elapsed<TimeSpan.FromSeconds(35) &&
                  (!ownerSawBurst||!opponentSawBurst||!scanReplayed))
            {
                await Task.Delay(75,timeout.Token);
                var ownerPoll=a.PollAsync(timeout.Token);
                var remotePoll=b.PollAsync(timeout.Token);
                await Task.WhenAll(ownerPoll,remotePoll);
                var local=ownerPoll.Result;
                var remote=remotePoll.Result;
                var ownerRows = local.Snapshot.Projectiles.Where(row => row.OwnerPlayerId == owner &&
                    row.ArmyUnitId == "ID_UNIT-SHOTGUNNER").ToArray();
                if (ownerRows.Length == 5)
                {
                    ownerBursts.Add(string.Join(",", ownerRows.Select(row => row.ProjectileId)));
                }
                ownerSawBurst = ownerBursts.Overlaps(opponentBursts);
                var rows=remote.Snapshot.Projectiles
                    .Where(row=>row.OwnerPlayerId==owner&&
                        row.ArmyUnitId=="ID_UNIT-SHOTGUNNER").ToArray();
                if(rows.Length!=5)continue;
                opponentSawBurst=true;
                opponentBursts.Add(string.Join(",", rows.Select(row => row.ProjectileId)));
                ownerSawBurst = ownerBursts.Overlaps(opponentBursts);
                Check(rows.Count(row=>row.Kind=="army-bullet")==1&&
                      rows.Count(row=>row.Kind=="army-fake-bullet")==4&&
                      rows.All(row=>!row.ArmyPoison&&row.ArmySourceCardId.Length==0&&
                          MathF.Abs(MathF.Sqrt(row.VelocityX*row.VelocityX+
                              row.VelocityY*row.VelocityY+
                              row.VelocityZ*row.VelocityZ)-10f)<.001f),
                      "remote SDK receives one real and four harmless source-speed pellets");
                var scan = await ShotgunnerProjectileScanTest.VerifyAsync(b, remote.Snapshot, owner, timeout.Token);
                scanReplayed |= scan.ReplayedBurst;
                scanSamples.Add($"{remote.Snapshot.ServerTick}->{scan.SnapshotTick}:" +
                    $"active={scan.ActiveCount}, pellets={scan.PelletCount}");
            }
            Check(ownerSawBurst&&opponentSawBurst&&scanReplayed,
                  $"both UDP peers observe the same five pellets and a complete frozen scan replays its captured rows: " +
                  $"owner={ownerSawBurst}, opponent={opponentSawBurst}, scan={scanReplayed}; " +
                  string.Join("; ", scanSamples.Take(6)));
            Console.WriteLine("Shotgunner frozen scan observations: " + string.Join("; ", scanSamples.Take(6)));
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(file);
        }
        return checks;
    }

    private static async Task<int> RunNormalSniper(string directory,
        BattleCombatContent content, RecoveredBattleMap map,
        CoverNode left, CoverNode right, WeaponManifest weapon)
    {
        int checks = 0;
        void Check(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
            checks++;
        }

        string owner = new('1', 32);
        string opponent = new('2', 32);
        ParticipantManifest Player(string id, int fraction, int cover) =>
            new(id, weapon, fraction, cover, 1, new(100000), 0, 1, 0)
            {
                EquippedArmyUnitIds = ["ID_UNIT-SNIPER"],
                ArmyNormalUpgradeIndexes = [0],
                ArmySpecialUpgradeIndexes = [-1],
                ArmyEliteUpgradeIndexes = [-1],
                ArmyHealthFactors = [new(1f, 1f)],
                ArmyDamageScales = [1f],
                ArmySpeedCoefficients = [1f],
                ArmyAccuracyCoefficients = [1f]
            };
        var manifest = new MatchManifest("normal-sniper-udp", "local-1",
            "Park_Multiplayer", map.SourceHash, content.Revision,
            MatchManifest.RifleCombatMode, 10, 60, 120,
            [Player(owner, 1, left.SourceIndex),
             Player(opponent, 2, right.SourceIndex)])
            { SceneMasterPlayerId = owner };
        string file = Path.Combine(Path.GetTempPath(),
            "war-normal-sniper-udp-" + Guid.NewGuid().ToString("N") + ".json");
        File.WriteAllText(file, JsonSerializer.Serialize(manifest));

        using var probe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        int port = ((IPEndPoint)probe.Client.LocalEndPoint!).Port;
        probe.Close();
        string signingKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens = new MatchTokens(signingKey);
        var config = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string?>
            {
                ["Battle:SigningKey"] = signingKey,
                ["Battle:ServerId"] = manifest.ServerId,
                ["Battle:Port"] = port.ToString(),
                ["Battle:MatchManifestPath"] = file,
                ["Battle:ResultOutboxPath"] = Path.Combine(Path.GetTempPath(),
                    "war-normal-sniper-outbox-" + Guid.NewGuid().ToString("N")),
                ["Battle:CombatContentManifestPath"] = Path.Combine(directory,
                    "combat-content-manifest.json")
            }).Build();
        MatchConnectionGrant Grant(string playerId, ulong session)
        {
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission = new MatchAdmission
            {
                MatchId = manifest.MatchId,
                ServerId = manifest.ServerId,
                PlayerId = playerId,
                SessionId = session,
                ManifestHash = manifest.Digest(),
                IssuedUnixSeconds = now,
                ExpiresUnixSeconds = now + 120
            };
            return new()
            {
                Host = "127.0.0.1",
                Port = (uint)port,
                PlayerId = playerId,
                SessionId = session,
                MatchId = admission.MatchId,
                ManifestHash = admission.ManifestHash,
                ExpiresUnixSeconds = admission.ExpiresUnixSeconds,
                Ticket = tokens.Sign(admission),
                SessionKey = ByteString.CopyFrom(tokens.SessionKey(admission))
            };
        }

        using var worker = new NetworkWorker(config, NullLogger<NetworkWorker>.Instance,
            _ => 0);
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(110));
            using var local = new MatchConnection(Grant(owner, 995));
            using var remote = new MatchConnection(Grant(opponent, 996));
            Check((await local.ConnectAsync(timeout.Token)).Code == "admitted" &&
                  (await remote.ConnectAsync(timeout.Token)).Code == "admitted",
                "both signed UDP peers enter the ordinary Sniper match");
            await local.ReadyAsync(timeout.Token);
            await remote.ReadyAsync(timeout.Token);
            MatchReply state;
            do
            {
                await Task.Delay(100, timeout.Token);
                state = await local.PollAsync(timeout.Token);
            } while (state.Snapshot.Phase != BattlePhase.Running);

            var hand = await local.PollArmyAsync(timeout.Token);
            var initialOpponent = state.Snapshot.Players.Single(player =>
                player.PlayerId == opponent);
            float initialShieldHealth = state.Snapshot.Shields.Single(shield =>
                shield.CoverIndex == initialOpponent.CoverIndex).Health;
            int option = hand.OptionIndexes.First();
            Check(hand.Code == "army-offers" &&
                  (await local.DeployArmyAsync(option, timeout.Token)).Code == "army-deploying",
                "the Worker accepts a source-backed ordinary Sniper option");

            bool localSawFlight = false;
            bool remoteSawFlight = false;
            bool scanReplayed = false;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (watch.Elapsed < TimeSpan.FromSeconds(45) &&
                   (!localSawFlight || !remoteSawFlight || !scanReplayed))
            {
                await Task.Delay(75, timeout.Token);
                var localPoll = local.PollAsync(timeout.Token);
                var remotePoll = remote.PollAsync(timeout.Token);
                await Task.WhenAll(localPoll, remotePoll);
                var flight = remotePoll.Result.Snapshot.Projectiles.FirstOrDefault(row =>
                    row.OwnerPlayerId == owner && row.ArmyUnitId == "ID_UNIT-SNIPER" &&
                    row.ArmySourceCardId.Length == 0);
                if (flight == null) continue;

                remoteSawFlight = true;
                localSawFlight |= localPoll.Result.Snapshot.Projectiles.Any(row =>
                    row.ProjectileId == flight.ProjectileId);
                float speed = MathF.Sqrt(flight.VelocityX * flight.VelocityX +
                    flight.VelocityY * flight.VelocityY +
                    flight.VelocityZ * flight.VelocityZ);
                Check(flight.Kind == "army-bullet" && !flight.ArmyPoison &&
                      MathF.Abs(speed - content.ArmyWeapons.SniperProjectileSpeed) < .001f,
                    "remote SDK accepts the ordinary Sniper's source-speed bullet");

                ulong scanId = BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(), 0);
                if (scanId == 0) scanId = 1;
                var first = await remote.PollProjectilesAsync(scanId, 0, timeout.Token);
                var replay = await remote.PollProjectilesAsync(scanId, 0, timeout.Token);
                scanReplayed |= first.Code == "projectiles" && !first.HasMore &&
                    first.Projectiles.Any(row => row.ProjectileId == flight.ProjectileId) &&
                    first.ToByteArray().SequenceEqual(replay.ToByteArray());
            }
            Check(localSawFlight && remoteSawFlight && scanReplayed,
                "both UDP peers and a replayed scan retain one ordinary Sniper flight");

            bool bothSawShieldDamage = false;
            ulong localEventCursor = 0;
            ulong remoteEventCursor = 0;
            var localShots = new HashSet<ulong>();
            var remoteShots = new HashSet<ulong>();
            var localImpacts = new HashSet<ulong>();
            var remoteImpacts = new HashSet<ulong>();
            var localShieldHits = new HashSet<ulong>();
            var remoteShieldHits = new HashSet<ulong>();
            float lastLocalShieldHealth = initialShieldHealth;
            float lastRemoteShieldHealth = initialShieldHealth;
            float lastOpponentHealth = initialOpponent.Health;
            watch.Restart();
            while (watch.Elapsed < TimeSpan.FromSeconds(45) &&
                   !bothSawShieldDamage)
            {
                await Task.Delay(75, timeout.Token);
                var localPoll = local.PollAsync(timeout.Token);
                var remotePoll = remote.PollAsync(timeout.Token);
                var localEvents = local.PollEventsAsync(localEventCursor, timeout.Token);
                var remoteEvents = remote.PollEventsAsync(remoteEventCursor, timeout.Token);
                await Task.WhenAll(localPoll, remotePoll, localEvents, remoteEvents);

                foreach (var row in localEvents.Result.Events)
                {
                    localEventCursor = row.EventId;
                    if (row.Kind == MatchEventKind.Shot && row.ActorId == owner &&
                        row.Reason == "army") localShots.Add(row.ProjectileId);
                    if (row.Kind == MatchEventKind.Impact && row.Reason == "army")
                        localImpacts.Add(row.ProjectileId);
                    if (row.Kind == MatchEventKind.ShieldDamaged &&
                        row.TargetId == opponent) localShieldHits.Add(row.ProjectileId);
                }
                foreach (var row in remoteEvents.Result.Events)
                {
                    remoteEventCursor = row.EventId;
                    if (row.Kind == MatchEventKind.Shot && row.ActorId == owner &&
                        row.Reason == "army") remoteShots.Add(row.ProjectileId);
                    if (row.Kind == MatchEventKind.Impact && row.Reason == "army")
                        remoteImpacts.Add(row.ProjectileId);
                    if (row.Kind == MatchEventKind.ShieldDamaged &&
                        row.TargetId == opponent) remoteShieldHits.Add(row.ProjectileId);
                }
                float ShieldHealth(MatchReply reply) => reply.Snapshot.Shields
                    .Single(shield => shield.CoverIndex == initialOpponent.CoverIndex).Health;
                lastLocalShieldHealth = ShieldHealth(localPoll.Result);
                lastRemoteShieldHealth = ShieldHealth(remotePoll.Result);
                lastOpponentHealth = localPoll.Result.Snapshot.Players.Single(player =>
                    player.PlayerId == opponent).Health;
                bool sharedDamagingShot = localShieldHits.Any(id =>
                    remoteShieldHits.Contains(id) &&
                    localShots.Contains(id) && remoteShots.Contains(id) &&
                    localImpacts.Contains(id) && remoteImpacts.Contains(id));
                bothSawShieldDamage = sharedDamagingShot &&
                    ShieldHealth(localPoll.Result) < initialShieldHealth &&
                    ShieldHealth(localPoll.Result) == ShieldHealth(remotePoll.Result) &&
                    localPoll.Result.Snapshot.Players.Single(player =>
                        player.PlayerId == opponent).Health == initialOpponent.Health &&
                    remotePoll.Result.Snapshot.Players.Single(player =>
                        player.PlayerId == opponent).Health == initialOpponent.Health;
            }
            Check(bothSawShieldDamage,
                "both UDP peers receive the ordinary Sniper's shield damage without player damage: " +
                $"shots={localShots.Count}/{remoteShots.Count}, " +
                $"impacts={localImpacts.Count}/{remoteImpacts.Count}, " +
                $"shieldHits={localShieldHits.Count}/{remoteShieldHits.Count}, " +
                $"shield={initialShieldHealth}->{lastLocalShieldHealth}/{lastRemoteShieldHealth}, " +
                $"player={initialOpponent.Health}->{lastOpponentHealth}");
        }
        finally
        {
            await worker.StopAsync(CancellationToken.None);
            File.Delete(file);
        }
        return checks;
    }
}

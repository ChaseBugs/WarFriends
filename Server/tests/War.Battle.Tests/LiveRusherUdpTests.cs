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
                {EquippedArmyUnitIds=["ID_UNIT-SHOTGUNNER","ID_UNIT-SWAT","ID_UNIT-FLAMETHROWER"],
                 ArmyNormalUpgradeIndexes=[0,0,0],ArmySpecialUpgradeIndexes=[-1,-1,-1],
                 ArmyEliteUpgradeIndexes=[-1,-1,-1],ArmySpeedCoefficients=[1f,1f,1f]},
             new(two,weapon,2,right.SourceIndex,1,new(1000),0,0,0)
                {EquippedArmyUnitIds=["ID_UNIT-SHOTGUNNER","ID_UNIT-SWAT","ID_UNIT-FLAMETHROWER"],
                 ArmyNormalUpgradeIndexes=[0,0,0],ArmySpecialUpgradeIndexes=[-1,-1,-1],
                 ArmyEliteUpgradeIndexes=[-1,-1,-1],ArmySpeedCoefficients=[1f,1f,1f]}])
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
        }
        finally{await worker.StopAsync(CancellationToken.None);File.Delete(file);}
        return checks;
    }
}

using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using War.BattleServer;
using War.Client;
using War.Protocol;

internal static class LiveReplyTransferUdpTests
{
    internal static async Task<int> Run()
    {
        int checks=0;
        void Check(bool okay,string name)
        {if(!okay)throw new Exception(name);checks++;}
        string one=new('a',32),two=new('b',32),hash=new('c',64);
        var weapon=new WeaponManifest("fixture-rifle",2,3,0.1,0.2);
        var manifest=MatchManifest.Validate(new MatchManifest("large-reply-udp","local-1",
            "fixture-map",hash,hash,MatchManifest.PrototypeMode,10,90,30,
            [new ParticipantManifest(one,weapon),new ParticipantManifest(two,weapon)]));
        string manifestFile=Path.Combine(Path.GetTempPath(),"war-large-reply-"+
            Guid.NewGuid().ToString("N")+".json");
        File.WriteAllText(manifestFile,JsonSerializer.Serialize(manifest));
        using var probe=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));
        int port=((IPEndPoint)probe.Client.LocalEndPoint!).Port;probe.Close();
        string signingKey=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        var tokens=new MatchTokens(signingKey);
        var config=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>
        {
            ["Battle:SigningKey"]=signingKey,["Battle:ServerId"]=manifest.ServerId,
            ["Battle:Port"]=port.ToString(),["Battle:MatchManifestPath"]=manifestFile,
            ["Battle:ResultOutboxPath"]=Path.Combine(Path.GetTempPath(),
                "war-large-reply-outbox-"+Guid.NewGuid().ToString("N"))
        }).Build();
        using var worker=new NetworkWorker(config,NullLogger<NetworkWorker>.Instance);
        // Test-only fixture: ribbons are trusted host statistics, not client
        // intents. Seed them before the Worker thread starts to exercise the
        // actual oversized MatchEndpoint/NetworkWorker wire path.
        var router=(MatchRouter)typeof(NetworkWorker).GetField("match",
            BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(worker)!;
        var endpoints=(Dictionary<string,MatchEndpoint>)typeof(MatchRouter).GetField("matches",
            BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(router)!;
        var endpoint=endpoints[manifest.MatchId];
        var engine=(MatchEngine)typeof(MatchEndpoint).GetField("match",
            BindingFlags.Instance|BindingFlags.NonPublic)!.GetValue(endpoint)!;
        for(int i=0;i<128;i++)
            Check(engine.TryRecordRibbon("R"+i.ToString("D3")+new string('x',55)),
                "trusted host ribbon fixture remains within the recovered ledger cap");
        MatchConnectionGrant Grant(string playerId,ulong sessionId)
        {
            long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission=new MatchAdmission{MatchId=manifest.MatchId,ServerId=manifest.ServerId,
                PlayerId=playerId,SessionId=sessionId,ManifestHash=manifest.Digest(),
                IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120};
            return new MatchConnectionGrant{Host="127.0.0.1",Port=(uint)port,
                PlayerId=playerId,SessionId=sessionId,MatchId=manifest.MatchId,
                ManifestHash=admission.ManifestHash,ExpiresUnixSeconds=admission.ExpiresUnixSeconds,
                Ticket=tokens.Sign(admission),
                SessionKey=ByteString.CopyFrom(tokens.SessionKey(admission))};
        }
        try
        {
            await worker.StartAsync(CancellationToken.None);
            using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(30));
            using var a=new MatchConnection(Grant(one,9701));
            using var b=new MatchConnection(Grant(two,9702));
            var admitted=await a.ConnectAsync(timeout.Token);
            Check(admitted.Code=="admitted"&&admitted.Snapshot.RibbonIds.Count==128&&
                  admitted.TransferId==0&&worker.IsReady,
                  "first signed Client reassembles oversized admission reply from real Worker chunks");
            var other=await b.ConnectAsync(timeout.Token);
            Check(other.Code=="admitted"&&other.Snapshot.RibbonIds.SequenceEqual(admitted.Snapshot.RibbonIds),
                  "second signed Client obtains identical complete oversized authority");
            var poll=await a.PollAsync(timeout.Token);
            Check(poll.Snapshot.RibbonIds.SequenceEqual(admitted.Snapshot.RibbonIds)&&
                  poll.Snapshot.Players.Count==2,
                  "oversized poll transfers complete immutable match state");
            var ready=await a.ReadyAsync(timeout.Token);
            Check(ready.CommandId==1&&ready.Snapshot.Players.Single(x=>x.PlayerId==one).Ready&&
                  ready.Snapshot.RibbonIds.Count==128,
                  "mutation acknowledgement completes only after chunk reconstruction");
        }
        finally {await worker.StopAsync(CancellationToken.None);File.Delete(manifestFile);}
        return checks;
    }
}

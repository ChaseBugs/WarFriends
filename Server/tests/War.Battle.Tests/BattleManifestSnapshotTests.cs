using System.Text.Json.Nodes;
using System.Security.Cryptography;
using System.Buffers.Binary;
using Google.Protobuf;
using MongoDB.Driver;
using War.Backend;
using War.BattleServer;
using War.Persistence;
using War.Protocol;

internal static class BattleManifestSnapshotTests
{
    public static async Task Run(string uri)
    {
        string database="war_manifest_snapshot_test_"+Guid.NewGuid().ToString("N");
        var mongo=new MongoClient(uri);
        try
        {
            var store=new BattleManifestSnapshotStore(uri,database);
            string[] players=[new string('a',32),new string('b',32)];
            var queue=new BattleMatchQueueStore(uri,database);
            await queue.Initialize(CancellationToken.None);
            var now=DateTimeOffset.UtcNow;
            if((await queue.Join(players[0],"mixed.fixture",now,CancellationToken.None)).Code!="waiting")
                throw new Exception("First durable player did not wait.");
            var pair=await queue.Join(players[1],"mixed.fixture",now,CancellationToken.None);
            if(pair.Code!="paired"||pair.MatchId==null||pair.Players==null||
               !pair.Players.SequenceEqual(players))throw new Exception("Durable pair was not formed.");
            string match=pair.MatchId;
            var root=new DirectoryInfo(AppContext.BaseDirectory);
            while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/local-mixed-match-template.json")))root=root.Parent;
            if(root==null)throw new FileNotFoundException("Mixed template missing.");
            var template=JsonNode.Parse(await File.ReadAllBytesAsync(Path.Combine(root.FullName,"content/local-mixed-match-template.json")))!.AsObject();
            template["MatchId"]=match;
            byte[] first=System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(template);
            byte[] saved=await store.GetOrCreate(match,players,()=>Task.FromResult(first),CancellationToken.None);
            if(!saved.SequenceEqual(first))throw new Exception("Manifest snapshot first publication changed bytes.");
            template["AdmissionSeconds"]=11;
            byte[] changed=System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(template);
            var restarted=new BattleManifestSnapshotStore(uri,database);
            var existingPair=await new BattleMatchQueueStore(uri,database).Existing(players[0],CancellationToken.None);
            if(existingPair?.MatchId!=match||existingPair.Players==null||
               !existingPair.Players.SequenceEqual(players))throw new Exception("Paired roster did not survive restart.");
            int rebuilds=0;
            byte[] replay=await restarted.GetOrCreate(match,players,()=>{rebuilds++;return Task.FromResult(changed);},CancellationToken.None);
            if(rebuilds!=0||!replay.SequenceEqual(first))throw new Exception("Paired retry rebuilt its manifest after restart.");
            var collection=mongo.GetDatabase(database).GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots");
            await collection.UpdateOneAsync(x=>x.Id==match,Builders<BattleManifestSnapshotDocument>.Update.Set(x=>x.Manifest,changed));
            try {await restarted.GetOrCreate(match,players,()=>Task.FromResult(first),CancellationToken.None);
                throw new Exception("Corrupt manifest snapshot replayed.");}
            catch(InvalidDataException){}
            await collection.UpdateOneAsync(x=>x.Id==match,Builders<BattleManifestSnapshotDocument>.Update.Set(x=>x.Manifest,first));
            var resultStore=new BattleResultStore(uri,database);
            await resultStore.Initialize(CancellationToken.None);
            var acceptance=new BattleTerminalAcceptance(resultStore,queue,restarted);
            var terminal=new MatchSnapshot{MatchId=match,ManifestHash=MatchManifest.Parse(first).Digest(),
                Phase=BattlePhase.Aborted,TerminalReason="host-shutdown"};
            terminal.Players.Add(new BattlePlayerState{PlayerId=players[0]});
            terminal.Players.Add(new BattlePlayerState{PlayerId=new string('c',32)});
            (byte[] badPayload,string badDigest)=Evidence(terminal);
            try {await acceptance.Accept(match,badDigest,badPayload,CancellationToken.None);
                throw new Exception("Wrong terminal roster released the pair.");}
            catch(InvalidDataException){}
            if((await queue.Existing(players[0],CancellationToken.None))?.MatchId!=match)
                throw new Exception("Rejected terminal result changed queue ownership.");
            terminal.Players[1].PlayerId=players[1];
            (byte[] payload,string digest)=Evidence(terminal);
            if(await acceptance.Accept(match,digest,payload,CancellationToken.None)!="accepted" ||
               await queue.Existing(players[0],CancellationToken.None)!=null ||
               await queue.Existing(players[1],CancellationToken.None)!=null ||
               await acceptance.Accept(match,digest,payload,CancellationToken.None)!="already-accepted")
                throw new Exception("Accepted terminal result did not release and replay safely.");
            if((await queue.Join(players[0],"mixed.fixture",DateTimeOffset.UtcNow,CancellationToken.None)).Code!="waiting")
                throw new Exception("Released player could not queue again.");
            var rematch=await queue.Join(players[1],"mixed.fixture",DateTimeOffset.UtcNow,CancellationToken.None);
            if(rematch.Code!="paired"||rematch.MatchId==match)
                throw new Exception("Released players could not form a new match.");
            var otherQueue=new BattleMatchQueueStore(uri,database);
            string[] contenders=Enumerable.Range(1,12).Select(i=>i.ToString("x32")).ToArray();
            var admissions=await Task.WhenAll(contenders.Select((id,i)=>(i%2==0?queue:otherQueue)
                .Join(id,"concurrent.fixture",DateTimeOffset.UtcNow,CancellationToken.None)));
            if(admissions.Any(x=>x.Code is not ("waiting" or "paired")))
                throw new Exception("Concurrent queue admission returned an invalid state.");
            var durablePairs=await mongo.GetDatabase(database).GetCollection<BattlePairDocument>("battle_pairs")
                .Find(x=>x.CompatibilityKey=="concurrent.fixture").ToListAsync();
            var roster=durablePairs.SelectMany(x=>x.Players).ToArray();
            if(roster.Length!=roster.Distinct(StringComparer.Ordinal).Count() ||
               roster.Any(x=>!contenders.Contains(x,StringComparer.Ordinal)))
                throw new Exception("Concurrent Backend stores assigned one player to conflicting pairs.");
            var ticketRows=mongo.GetDatabase(database).GetCollection<BattleQueueTicketDocument>("battle_queue_tickets");
            var corruptPlayer=new string('d',32);
            var future=DateTime.UtcNow.AddMinutes(1);
            await ticketRows.InsertOneAsync(new BattleQueueTicketDocument{Id=Guid.NewGuid().ToString("N"),
                PlayerId=corruptPlayer,CompatibilityKey="corrupt.fixture",JoinedUtc=future,ExpiresUtc=future.AddSeconds(120)});
            if((await queue.Join(new string('e',32),"corrupt.fixture",DateTimeOffset.UtcNow,CancellationToken.None)).Code!="waiting")
                throw new Exception("Future-dated candidate entered a durable pair.");
            if(await queue.Existing(corruptPlayer,CancellationToken.None)!=null)
                throw new Exception("Rejected candidate acquired a durable pair.");
            var badJoined=DateTime.UtcNow.AddSeconds(-1);
            await ticketRows.InsertOneAsync(new BattleQueueTicketDocument{Id=Guid.NewGuid().ToString("N"),
                PlayerId=new string('f',32),CompatibilityKey="bad-lifetime.fixture",JoinedUtc=badJoined,
                ExpiresUtc=badJoined.AddSeconds(121)});
            try {await queue.Join(new string('1',32),"bad-lifetime.fixture",DateTimeOffset.UtcNow,CancellationToken.None);
                throw new Exception("Malformed candidate lifetime entered a durable pair.");}
            catch(InvalidDataException){}
            await mongo.GetDatabase(database).GetCollection<BattlePairDocument>("battle_pairs").InsertOneAsync(
                new BattlePairDocument{Id="bad-pair-id",MatchId="m"+Guid.NewGuid().ToString("N"),
                    CompatibilityKey="corrupt-pair.fixture",Players=[new string('2',32),new string('3',32)],
                    CreatedUtc=DateTime.UtcNow});
            try {await queue.Existing(new string('2',32),CancellationToken.None);
                throw new Exception("Malformed durable pair was replayed.");}
            catch(InvalidDataException){}
            Console.WriteLine("PASS: Mongo paired snapshot survives restart; proven terminal releases players for a distinct rematch");
        }
        finally {await mongo.DropDatabaseAsync(database);}
    }
    private static (byte[] Payload,string Digest) Evidence(MatchSnapshot snapshot)
    {
        byte[] payload=snapshot.ToByteArray();
        var framed=new byte[payload.Length+8];
        "WFR1"u8.CopyTo(framed);
        BinaryPrimitives.WriteInt32LittleEndian(framed.AsSpan(4,4),payload.Length);
        payload.CopyTo(framed,8);
        return (payload,Convert.ToHexStringLower(SHA256.HashData(framed)));
    }
}

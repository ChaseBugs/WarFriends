using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Persistence;

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
            Console.WriteLine("PASS: Mongo manifest snapshot survives restart, ignores changing profile data, and rejects tampering");
        }
        finally {await mongo.DropDatabaseAsync(database);}
    }
}

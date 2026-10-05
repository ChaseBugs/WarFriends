using System.Text.Json.Nodes;
using System.Security.Cryptography;
using System.Buffers.Binary;
using Google.Protobuf;
using MongoDB.Driver;
using War.Backend;
using War.BattleServer;
using War.Persistence;
using War.Protocol;
using War.Shared;

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
            foreach(var invalid in new[]{
                new Action<MatchSnapshot>(x=>x.CardActivations=4097),
                new Action<MatchSnapshot>(x=>{x.CardActivations=1;x.Players[0].ConfirmedCardsPlayed=0;}),
                new Action<MatchSnapshot>(x=>x.Players[0].ConfirmedCardsPlayed=1),
                new Action<MatchSnapshot>(x=>x.CardUsage.Add(new BattleCardUsage
                    {OwnerPlayerId=players[0],CardId="CardHeavyTurret",Count=1})),
                new Action<MatchSnapshot>(x=>{x.CardActivations=1;x.Players[0].ConfirmedCardsPlayed=1;
                    x.CardUsage.Add(new BattleCardUsage{OwnerPlayerId=players[0],CardId="CardUnknown",Count=1});}),
                new Action<MatchSnapshot>(x=>{x.CardActivations=2;x.Players[0].ConfirmedCardsPlayed=2;
                    x.CardUsage.Add(new BattleCardUsage{OwnerPlayerId=players[0],CardId="CardDecoy",Count=1});
                    x.CardUsage.Add(new BattleCardUsage{OwnerPlayerId=players[0],CardId="CardDecoy",Count=1});}),
                new Action<MatchSnapshot>(x=>{x.RibbonIds.Add("R1");x.RibbonIds.Add("R1");}),
                new Action<MatchSnapshot>(x=>x.PerformanceDurationTicks=10_000_001),
                new Action<MatchSnapshot>(x=>x.PerformanceDurationTicks=1),
                new Action<MatchSnapshot>(x=>{x.StartTick=1;x.EndTick=x.ServerTick=2;x.PerformanceStartTick=1;x.PerformanceDurationTicks=0;})})
            {
                var forged=terminal.Clone();invalid(forged);
                (byte[] forgedPayload,string forgedDigest)=Evidence(forged);
                try {await acceptance.Accept(match,forgedDigest,forgedPayload,CancellationToken.None);
                    throw new Exception("Incomplete performance authority entered terminal result storage.");}
                catch(InvalidDataException){}
            }
            if(await resultStore.Get(match,CancellationToken.None)!=null ||
               (await queue.Existing(players[0],CancellationToken.None))?.MatchId!=match)
                throw new Exception("Rejected performance evidence changed durable result or pair authority.");
            (byte[] payload,string digest)=Evidence(terminal);
            if(TerminalResultDigest.Compute(payload)!=digest)
                throw new Exception("Shared terminal digest differs from the Worker's framed record.");
            try {await resultStore.Accept(match,new string('f',64),payload,CancellationToken.None);
                throw new Exception("Direct durable result acceptance trusted a false digest.");}
            catch(InvalidDataException){}
            if(await resultStore.Accept(match,digest,payload,CancellationToken.None)!="accepted" ||
               (await queue.Existing(players[0],CancellationToken.None))?.MatchId!=match)
                throw new Exception("Result storage unexpectedly released an unreconciled queue pair.");
            var resumedAcceptance=new BattleTerminalAcceptance(new BattleResultStore(uri,database),
                new BattleMatchQueueStore(uri,database),new BattleManifestSnapshotStore(uri,database));
            if(await resumedAcceptance.Accept(match,digest,payload,CancellationToken.None)!="already-accepted" ||
               await queue.Existing(players[0],CancellationToken.None)!=null ||
               await queue.Existing(players[1],CancellationToken.None)!=null ||
               await acceptance.Accept(match,digest,payload,CancellationToken.None)!="already-accepted")
                throw new Exception("Stored terminal result did not release the pair after Backend restart.");
            if(await resultStore.ReconcileScored(match,digest,CancellationToken.None)!="scored" ||
               await resultStore.ReconcileScored(match,digest,CancellationToken.None)!="already-scored" ||
               (await resultStore.Get(match,CancellationToken.None))?.ScoredUtc==null)
                throw new Exception("Validated terminal result did not retain its idempotent score marker.");
            if((await queue.Join(players[0],"mixed.fixture",DateTimeOffset.UtcNow,CancellationToken.None)).Code!="waiting")
                throw new Exception("Released player could not queue again.");
            var rematch=await queue.Join(players[1],"mixed.fixture",DateTimeOffset.UtcNow,CancellationToken.None);
            if(rematch.Code!="paired"||rematch.MatchId==match)
                throw new Exception("Released players could not form a new match.");
            var rematchTemplate=JsonNode.Parse(first)!.AsObject();
            rematchTemplate["MatchId"]=rematch.MatchId;
            byte[] rematchManifest=System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(rematchTemplate);
            await store.GetOrCreate(rematch.MatchId!,players,()=>Task.FromResult(rematchManifest),CancellationToken.None);
            var rematchTerminal=new MatchSnapshot{MatchId=rematch.MatchId,ManifestHash=MatchManifest.Parse(rematchManifest).Digest(),
                Phase=BattlePhase.Aborted,TerminalReason="host-shutdown"};
            rematchTerminal.Players.Add(new BattlePlayerState{PlayerId=players[0]});
            rematchTerminal.Players.Add(new BattlePlayerState{PlayerId=players[1]});
            (byte[] rematchPayload,string rematchDigest)=Evidence(rematchTerminal);
            var malformedTerminal=rematchTerminal.Clone();
            malformedTerminal.TerminalReason="forged-result";
            (byte[] malformedPayload,string malformedDigest)=Evidence(malformedTerminal);
            try {await resultStore.Accept(rematch.MatchId!,malformedDigest,malformedPayload,CancellationToken.None);
                throw new Exception("Direct result-store acceptance trusted a digest over invalid terminal evidence.");}
            catch(InvalidDataException){}
            if(await resultStore.Get(rematch.MatchId!,CancellationToken.None)!=null)
                throw new Exception("Invalid direct result-store payload was persisted.");
            await resultStore.Accept(rematch.MatchId!,rematchDigest,rematchPayload,CancellationToken.None);
            var resultRows=mongo.GetDatabase(database).GetCollection<BattleResultDocument>("battle_results");
            await resultRows.UpdateOneAsync(x=>x.MatchId==rematch.MatchId,
                Builders<BattleResultDocument>.Update.Set(x=>x.Snapshot,new byte[]{1,2,3}));
            try {await resumedAcceptance.Accept(rematch.MatchId!,rematchDigest,rematchPayload,CancellationToken.None);
                throw new Exception("Damaged persisted terminal payload released its pair.");}
            catch(InvalidDataException){}
            try {await resultStore.Get(rematch.MatchId!,CancellationToken.None);
                throw new Exception("Damaged result was returned to a scoring reader.");}
            catch(InvalidDataException){}
            try {await resultStore.ReconcileScored(rematch.MatchId!,rematchDigest,CancellationToken.None);
                throw new Exception("Damaged result was marked scored.");}
            catch(InvalidDataException){}
            try {await resultStore.Prune(DateTimeOffset.UtcNow.AddDays(31),TimeSpan.FromDays(30),CancellationToken.None);
                throw new Exception("Archival removed a damaged result row.");}
            catch(InvalidDataException){}
            if((await queue.Existing(players[0],CancellationToken.None))?.MatchId!=rematch.MatchId)
                throw new Exception("Rejected persisted terminal payload changed pair ownership.");
            await resultRows.UpdateOneAsync(x=>x.MatchId==rematch.MatchId,
                Builders<BattleResultDocument>.Update.Set(x=>x.Snapshot,malformedPayload).Set(x=>x.Digest,malformedDigest));
            try {await resultStore.ReconcileScored(rematch.MatchId!,malformedDigest,CancellationToken.None);
                throw new Exception("Self-consistent invalid terminal evidence was marked scored.");}
            catch(InvalidDataException){}
            await resultRows.UpdateOneAsync(x=>x.MatchId==rematch.MatchId,
                Builders<BattleResultDocument>.Update.Set(x=>x.Snapshot,rematchPayload).Set(x=>x.Digest,rematchDigest));
            if(await resumedAcceptance.Accept(rematch.MatchId!,rematchDigest,rematchPayload,CancellationToken.None)!="already-accepted" ||
               await queue.Existing(players[0],CancellationToken.None)!=null)
                throw new Exception("Repaired terminal payload did not release the pair.");
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
            string cancelling=new string('4',32),opponent=new string('5',32);
            if((await queue.Join(cancelling,"cancel.fixture",DateTimeOffset.UtcNow,CancellationToken.None)).Code!="waiting" ||
               await queue.Cancel(cancelling,DateTimeOffset.UtcNow,CancellationToken.None)!="cancelled" ||
               await queue.Cancel(cancelling,DateTimeOffset.UtcNow,CancellationToken.None)!="not-queued")
                throw new Exception("Unpaired cancellation did not consume only its current ticket.");
            await queue.Join(cancelling,"cancel.fixture",DateTimeOffset.UtcNow,CancellationToken.None);
            var cancelPair=await queue.Join(opponent,"cancel.fixture",DateTimeOffset.UtcNow,CancellationToken.None);
            if(cancelPair.Code!="paired" || await queue.Cancel(cancelling,DateTimeOffset.UtcNow,CancellationToken.None)!="already-paired")
                throw new Exception("Cancellation dissolved a durable pair.");
            for(int i=0;i<32;i++)
            {
                string firstId=(1000+i).ToString("x32"),secondId=(2000+i).ToString("x32"),key="cancel-race."+i;
                await queue.Join(firstId,key,DateTimeOffset.UtcNow,CancellationToken.None);
                var join=otherQueue.Join(secondId,key,DateTimeOffset.UtcNow,CancellationToken.None);
                var cancel=queue.Cancel(firstId,DateTimeOffset.UtcNow,CancellationToken.None);
                await Task.WhenAll(join,cancel);
                var current=await queue.Existing(firstId,CancellationToken.None);
                if((cancel.Result=="cancelled" && current!=null) ||
                   (cancel.Result=="already-paired" && current?.MatchId!=join.Result.MatchId) ||
                   cancel.Result is not ("cancelled" or "already-paired"))
                    throw new Exception("Concurrent cancellation and pairing did not commit one ownership outcome.");
            }
            var expiryNow=DateTimeOffset.FromUnixTimeMilliseconds(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            string expiring=(3000).ToString("x32"),waiting=(3001).ToString("x32");
            if((await queue.Join(expiring,"expiry.fixture",expiryNow.AddSeconds(-120),CancellationToken.None)).Code!="waiting" ||
               (await otherQueue.Join(waiting,"expiry.fixture",expiryNow,CancellationToken.None)).Code!="waiting")
                throw new Exception("Half-open expiry admitted a stale queue ticket.");
            var renewed=await queue.Join(expiring,"expiry.fixture",expiryNow,CancellationToken.None);
            var retry=await otherQueue.Join(waiting,"expiry.fixture",expiryNow,CancellationToken.None);
            if(renewed.Code!="paired" || retry.MatchId!=renewed.MatchId ||
               (await queue.Existing(expiring,CancellationToken.None))?.MatchId!=renewed.MatchId)
                throw new Exception("Expired ticket renewal or paired retry lost durable match authority.");
            string changing=(3002).ToString("x32");
            await queue.Join(changing,"policy-old.fixture",expiryNow.AddSeconds(-120),CancellationToken.None);
            if((await queue.Join(changing,"policy-new.fixture",expiryNow,CancellationToken.None)).Code!="waiting" ||
               (await ticketRows.Find(x=>x.PlayerId==changing).FirstAsync()).CompatibilityKey!="policy-new.fixture")
                throw new Exception("Expired ticket retained an obsolete server compatibility key.");
            try {await queue.Join(changing,"policy-third.fixture",expiryNow,CancellationToken.None);
                throw new Exception("Active queue ticket accepted a different server compatibility key.");}
            catch(InvalidDataException){}
            var scoring=await Task.WhenAll(Enumerable.Range(0,8).Select(_=>
                new BattleResultStore(uri,database).ReconcileScored(rematch.MatchId!,rematchDigest,CancellationToken.None)));
            if(scoring.Count(x=>x=="scored")!=1 || scoring.Count(x=>x=="already-scored")!=7)
                throw new Exception("Concurrent result scoring did not retain one durable winner.");
            if(await resultStore.Prune(DateTimeOffset.UtcNow.AddDays(31),TimeSpan.FromDays(30),CancellationToken.None)!=2 ||
               await resultStore.Get(match,CancellationToken.None)!=null ||
               await resultStore.Get(rematch.MatchId!,CancellationToken.None)!=null)
                throw new Exception("Validated result archival did not remove the exact due rows.");
            Console.WriteLine("PASS: Mongo queue authority and exact-result scoring/archival survive concurrent stores and restart");
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

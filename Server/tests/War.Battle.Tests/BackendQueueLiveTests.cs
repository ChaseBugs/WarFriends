using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using War.Backend.Legacy;
using War.Client;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;
using War.Shared;
using MongoDB.Driver;

internal static class BackendQueueLiveTests
{
    public static async Task Run(string mongoUri)
    {
        var root=new DirectoryInfo(AppContext.BaseDirectory);
        while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/local-rifle-match-template.json")))root=root.Parent;
        if(root==null)throw new FileNotFoundException("Reviewed rifle template missing.");
        string directory=root.FullName,content=Path.Combine(directory,"content");
        string backendDll=Path.Combine(directory,"src/War.Backend/bin/Release/net10.0/War.Backend.dll");
        string workerDll=Path.Combine(directory,"src/War.BattleServer/bin/Release/net10.0/War.BattleServer.dll");
        if(!File.Exists(backendDll)||!File.Exists(workerDll))throw new FileNotFoundException("Build Release processes before the queue smoke.");
        string database="war_queue_live_"+Guid.NewGuid().ToString("N");
        string run=Path.Combine(directory,".local","queue-live-"+Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(run);
        int backendPort=FreeTcpPort(),controlPort=FreeTcpPort(),udpPort=FreeUdpPort();
        while(backendPort==controlPort||backendPort==udpPort||controlPort==udpPort)
        {backendPort=FreeTcpPort();controlPort=FreeTcpPort();udpPort=FreeUdpPort();}
        string signing=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        string control=Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        string backendUrl=$"http://127.0.0.1:{backendPort}/";
        var mongo=new MongoClient(mongoUri);
        Process? backend=null,worker=null;
        try
        {
            var legacy=new LegacyPlayerStore(mongoUri,database);
            var allocations=new BattleAllocationStore(mongoUri,database);
            await legacy.Initialize(CancellationToken.None);
            await allocations.Initialize(CancellationToken.None);
            string[] ids=[Guid.NewGuid().ToString("N"),Guid.NewGuid().ToString("N")];
            string[] tokens=[LegacyPlayerStore.NewToken(),LegacyPlayerStore.NewToken()];
            for(int i=0;i<2;i++)
            {
                string rifle="Google2u.AssaultRifle_AK47";
                var decals=new DecalManagerData();
                for(int slot=0;slot<4;slot++)decals.Slots[slot]=new SavedPlayerVisualSlot{EquippedId="VISUAL_"+slot};
                var inventory=new InventoryData();inventory.Slots[0]=new SerializedSlotDetail{Name=rifle,WeaponIndex=11};
                var levels=new LevelManagerData();levels.SavedWeapons[rifle]=new SavedWeaponSlots{Bought=true,BoughtIndex=0};
                var player=new LegacyPlayerDocument{Id=ids[i],Name="Queue"+i,Locale="en",Country="US",Level=1,
                    ArmyPower=1,LeagueId="1-local",SessionHash=LegacyPlayerStore.HashToken(tokens[i]),
                    SessionExpiresUtc=DateTime.UtcNow.AddHours(1),CreatedUtc=DateTime.UtcNow,
                    Serialized=new Dictionary<string,string>{["DecalManagerData"]=PlayerState.Write(decals),
                        ["InventoryData"]=PlayerState.Write(inventory),["LevelManagerData"]=PlayerState.Write(levels)}};
                await legacy.Insert(player,LegacyPlayerStore.NewPassword(),CancellationToken.None);
                await allocations.Put(new BattleAllocationProjection(ids[i],[],[],[],[],[]),CancellationToken.None);
            }
            var workerEnvironment=new Dictionary<string,string>
            {
                ["Battle__SigningKey"]=signing,["Battle__ControlKey"]=control,
                ["Battle__ServerId"]="local-1",["Battle__PublicHost"]="127.0.0.1",["Battle__BindAddress"]="127.0.0.1",
                ["Battle__Port"]=udpPort.ToString(),["Battle__ControlPort"]=controlPort.ToString(),
                ["Battle__CombatContentManifestPath"]=Path.Combine(content,"combat-content-manifest.json"),
                ["Battle__ResultOutboxPath"]=Path.Combine(run,"outbox"),
                ["Battle__BackendResultEndpoint"]=backendUrl+"internal/battle/results/accept"
            };
            var backendEnvironment=new Dictionary<string,string>
            {
                ["ASPNETCORE_ENVIRONMENT"]="Development",["ASPNETCORE_URLS"]=backendUrl,
                ["Mongo__Uri"]=mongoUri,["Mongo__Database"]=database,
                ["Battle__SigningKey"]=signing,["Battle__ControlKey"]=control,
                ["Battle__ServerId"]="local-1",["Battle__PublicHost"]="127.0.0.1",
                ["Battle__Port"]=udpPort.ToString(),["Battle__ControlPort"]=controlPort.ToString(),
                ["Battle__ControlEndpoint"]=$"http://127.0.0.1:{controlPort}/internal/matches",
                ["Battle__MatchmakingCompatibilityKey"]="unscored-rifle.fixture",
                ["Battle__MatchManifestTemplatePath"]=Path.Combine(content,"local-rifle-match-template.json"),
                ["Battle__CombatContentManifestPath"]=Path.Combine(content,"combat-content-manifest.json")
            };
            backend=Start(backendDll,run,"Backend",backendEnvironment);
            await Ready(backendUrl+"health/ready",backend);
            using var left=new BackendClient(new Uri(backendUrl),true);
            using var right=new BackendClient(new Uri(backendUrl),true);
            using var deadline=new CancellationTokenSource(TimeSpan.FromSeconds(45));
            var firstWaiting=await left.JoinMatchQueueAsync(tokens[0],deadline.Token);
            if(firstWaiting.Code!="waiting")throw new Exception("First player did not enter the durable queue.");
            try {await right.JoinMatchQueueAsync(tokens[1],deadline.Token);
                throw new Exception("Queue pairing succeeded while the Worker was unavailable.");}
            catch(HttpRequestException e) when(e.Message.Contains("Backend status 503",StringComparison.Ordinal)){}
            var queued=new BattleMatchQueueStore(mongoUri,database);
            var frozenPair=await queued.Existing(ids[0],deadline.Token);
            var frozen=frozenPair?.MatchId==null?null:
                await new BattleManifestSnapshotStore(mongoUri,database).Get(frozenPair.MatchId,ids,deadline.Token);
            if(frozenPair?.Players==null || frozenPair.MatchId==null ||
               !frozenPair.Players.SequenceEqual(ids,StringComparer.Ordinal) ||
               frozen==null ||
               (await new BattleGrantStore(mongoUri,database).GetForPlayer(frozenPair.MatchId,ids[0],
                   DateTimeOffset.UtcNow.ToUnixTimeSeconds(),deadline.Token))!=null)
                throw new Exception("Deferred provisioning did not retain one frozen, ungranted pair.");
            worker=Start(workerDll,run,"Worker",workerEnvironment);
            await Ready($"http://127.0.0.1:{controlPort}/health/ready",worker);
            using var controlHttp=new HttpClient();
            var registered=await new BattleMatchControlClient(controlHttp,Convert.FromBase64String(control))
                .RegisterAsync(new Uri($"http://127.0.0.1:{controlPort}/internal/matches"),frozen,
                    frozenPair.MatchId,ids,deadline.Token);
            if(registered.Code!="registered" ||
               (await new BattleGrantStore(mongoUri,database).GetForPlayer(frozenPair.MatchId,ids[0],
                   DateTimeOffset.UtcNow.ToUnixTimeSeconds(),deadline.Token))!=null)
                throw new Exception("Worker registration unexpectedly published a Backend player grant.");
            Stop(backend);
            backend=Start(backendDll,run,"BackendRestart",backendEnvironment);
            await Ready(backendUrl+"health/ready",backend);
            var first=left.FindMatchAsync(tokens[0],TimeSpan.FromSeconds(25),deadline.Token);
            var second=right.FindMatchAsync(tokens[1],TimeSpan.FromSeconds(25),deadline.Token);
            var grants=await Task.WhenAll(first,second);
            if(grants[0].MatchId!=frozenPair.MatchId||grants[0].MatchId!=grants[1].MatchId||
               grants[0].PlayerId!=ids[0]||grants[1].PlayerId!=ids[1]||
               grants.Any(x=>x.PlayerViews.Count!=2)||grants[0].ManifestHash!=grants[1].ManifestHash ||
               grants[0].SessionId!=registered.Grants[0].SessionId ||
               grants[1].SessionId!=registered.Grants[1].SessionId ||
               grants[0].Ticket!=registered.Grants[0].Ticket ||
               grants[1].Ticket!=registered.Grants[1].Ticket)
                throw new Exception("Live queue returned inconsistent player-only grants.");
            var inconsistent=grants.Select(x=>x.Clone()).ToArray();
            inconsistent[1].PlayerViews[0].DisplayName+="forged";
            try
            {
                await new BattleGrantStore(mongoUri,database).Publish(frozenPair.MatchId,
                    grants[0].ManifestHash,inconsistent,deadline.Token);
                throw new Exception("Mismatched grant views were accepted at publication.");
            }
            catch(InvalidDataException){}
            var sameFraction=grants.Select(x=>x.Clone()).ToArray();
            foreach(var grant in sameFraction)
                grant.PlayerViews[1].Fraction=grant.PlayerViews[0].Fraction;
            try
            {
                await new BattleGrantStore(mongoUri,database).Publish(frozenPair.MatchId,
                    grants[0].ManifestHash,sameFraction,deadline.Token);
                throw new Exception("One-fraction roster was accepted at grant publication.");
            }
            catch(InvalidDataException){}
            var splitHost=grants.Select(x=>x.Clone()).ToArray();
            splitHost[1].Host="127.0.0.2";
            try
            {
                await new BattleGrantStore(mongoUri,database).Publish(frozenPair.MatchId,
                    grants[0].ManifestHash,splitHost,deadline.Token);
                throw new Exception("One roster was assigned two battle hosts.");
            }
            catch(InvalidDataException){}
            var sharedKey=grants.Select(x=>x.Clone()).ToArray();
            sharedKey[1].SessionKey=sharedKey[0].SessionKey;
            try
            {
                await new BattleGrantStore(mongoUri,database).Publish(frozenPair.MatchId,
                    grants[0].ManifestHash,sharedKey,deadline.Token);
                throw new Exception("Two players were assigned one session key.");
            }
            catch(InvalidDataException){}
            var grantRows=mongo.GetDatabase(database).GetCollection<BattleGrantDocument>("battle_grants");
            var persistedGrant=await grantRows.Find(x=>x.MatchId==frozenPair.MatchId).FirstAsync(deadline.Token);
            var grantStore=new BattleGrantStore(mongoUri,database);
            if(await grantStore.Publish(frozenPair.MatchId,grants[0].ManifestHash,grants,deadline.Token)!="already-published")
                throw new Exception("Grant publication retry did not recognize the complete durable assignment.");
            await grantRows.UpdateOneAsync(x=>x.MatchId==frozenPair.MatchId,
                Builders<BattleGrantDocument>.Update.Set(x=>x.GrantB,new byte[]{1,2,3}),cancellationToken:deadline.Token);
            try
            {
                await grantStore.GetForPlayer(frozenPair.MatchId,ids[0],
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds(),deadline.Token);
                throw new Exception("Corrupt opposite-player grant was ignored on durable replay.");
            }
            catch(InvalidDataException){}
            try
            {
                await grantStore.Publish(frozenPair.MatchId,grants[0].ManifestHash,grants,deadline.Token);
                throw new Exception("Corrupt durable grant was accepted as a publication retry.");
            }
            catch(InvalidDataException){}
            await grantRows.UpdateOneAsync(x=>x.MatchId==frozenPair.MatchId,
                Builders<BattleGrantDocument>.Update.Set(x=>x.GrantB,persistedGrant.GrantB),cancellationToken:deadline.Token);
            var replay=await left.FindMatchAsync(tokens[0],TimeSpan.FromSeconds(25),deadline.Token);
            if(replay.MatchId!=grants[0].MatchId || replay.SessionId!=grants[0].SessionId ||
               replay.Ticket!=grants[0].Ticket || !replay.SessionKey.Equals(grants[0].SessionKey))
                throw new Exception("Dropped Client response changed the durable player-only grant.");
            using var peerA=new MatchConnection(grants[0]);using var peerB=new MatchConnection(grants[1]);
            if((await peerA.ConnectAsync(deadline.Token)).Code!="admitted" ||
               (await peerB.ConnectAsync(deadline.Token)).Code!="admitted")
                throw new Exception("Paired portable clients could not enter the UDP room.");
            await peerA.ReadyAsync(deadline.Token);await peerB.ReadyAsync(deadline.Token);
            MatchReply state;
            do {await Task.Delay(100,deadline.Token);state=await peerA.PollAsync(deadline.Token);}
            while(state.Snapshot.Phase!=BattlePhase.Running);
            long afterInitialTicket=grants[0].ExpiresUnixSeconds+1;
            var retained=await grantStore.GetAssignmentForPlayer(grants[0].MatchId,ids[0],
                afterInitialTicket,deadline.Token);
            if(retained?.SessionId!=grants[0].SessionId)
                throw new Exception("Battle assignment disappeared with its first 120-second ticket.");
            try
            {
                await grantStore.GetForPlayer(grants[0].MatchId,ids[0],afterInitialTicket,deadline.Token);
                throw new Exception("Expired initial ticket was delivered as a live grant.");
            }
            catch(InvalidDataException){}
            string reconnectRequestId=Guid.NewGuid().ToString("N");
            var resumedGrant=await left.ReconnectMatchAsync(grants[0].MatchId,
                reconnectRequestId,tokens[0],deadline.Token);
            var resumedRetry=await left.ReconnectMatchAsync(grants[0].MatchId,
                reconnectRequestId,tokens[0],deadline.Token);
            if(resumedGrant.SessionId==grants[0].SessionId ||
               resumedGrant.SessionId!=resumedRetry.SessionId ||
               resumedGrant.PlayerViews.Count!=2 ||
               !resumedGrant.PlayerViews.SequenceEqual(grants[0].PlayerViews) ||
               (await grantStore.GetForPlayer(grants[0].MatchId,ids[0],
                   DateTimeOffset.UtcNow.ToUnixTimeSeconds(),deadline.Token))?.SessionId!=resumedGrant.SessionId ||
               (await grantStore.GetForPlayer(grants[0].MatchId,ids[1],
                   DateTimeOffset.UtcNow.ToUnixTimeSeconds(),deadline.Token))?.SessionId!=grants[1].SessionId)
                throw new Exception("Backend reconnect did not durably rotate only the requesting player's grant.");
            if(await grantStore.Publish(grants[0].MatchId,grants[0].ManifestHash,
                [resumedGrant,grants[1]],deadline.Token)!="already-published")
                throw new Exception("Provisioning retry rejected a valid mixed-generation grant assignment.");
            using(var resumedPeer=new MatchConnection(resumedGrant))
            {
                var admission=await resumedPeer.ConnectAsync(deadline.Token);
                if(admission.Code!="admitted" || admission.Snapshot.Phase!=BattlePhase.Running)
                    throw new Exception("Backend-delivered replacement grant did not rejoin the running Worker match.");
            }
            if((await peerB.ForfeitAsync(deadline.Token)).Snapshot.Phase!=BattlePhase.Ended)
                throw new Exception("Live match did not publish terminal evidence.");
            var results=new BattleResultStore(mongoUri,database);
            var queue=new BattleMatchQueueStore(mongoUri,database);
            for(int attempt=0;attempt<100;attempt++)
            {
                if(await results.Get(grants[0].MatchId,deadline.Token)!=null &&
                   await queue.Existing(ids[0],deadline.Token)==null &&
                   await queue.Existing(ids[1],deadline.Token)==null)break;
                await Task.Delay(100,deadline.Token);
                if(attempt==99)throw new Exception("Worker terminal result did not release the durable pair.");
            }
            try {await left.MatchGrantAsync(grants[0].MatchId,tokens[0],deadline.Token);
                throw new Exception("Terminal match still delivered a stale player grant.");}
            catch(HttpRequestException e) when(e.Message.Contains("Backend status 404",StringComparison.Ordinal)){}
            var waiting=await left.JoinMatchQueueAsync(tokens[0],deadline.Token);
            var rematch=await right.JoinMatchQueueAsync(tokens[1],deadline.Token);
            if(waiting.Code!="waiting"||rematch.Code!="paired"||rematch.MatchId==grants[0].MatchId)
                throw new Exception("Live clients could not form a distinct rematch.");
            if((await left.MatchGrantAsync(rematch.MatchId,tokens[0],deadline.Token)).MatchId!=rematch.MatchId)
                throw new Exception("Active rematch grant was not available to its owner.");
            Stop(worker);
            worker=Start(workerDll,run,"WorkerRestart",workerEnvironment);
            await Ready($"http://127.0.0.1:{controlPort}/health/ready",worker);
            for(int attempt=0;attempt<100;attempt++)
            {
                if(await results.Get(rematch.MatchId,deadline.Token)!=null &&
                   await queue.Existing(ids[0],deadline.Token)==null &&
                   await queue.Existing(ids[1],deadline.Token)==null)break;
                await Task.Delay(100,deadline.Token);
                if(attempt==99)throw new Exception("Worker crash did not release its durable paired roster.");
            }
            try {await left.MatchGrantAsync(rematch.MatchId,tokens[0],deadline.Token);
                throw new Exception("Host-crash match still delivered a stale player grant.");}
            catch(HttpRequestException e) when(e.Message.Contains("Backend status 404",StringComparison.Ordinal)){}
            var afterCrashWait=await left.JoinMatchQueueAsync(tokens[0],deadline.Token);
            var afterCrashPair=await right.JoinMatchQueueAsync(tokens[1],deadline.Token);
            if(afterCrashWait.Code!="waiting" || afterCrashPair.Code!="paired" ||
               afterCrashPair.MatchId==rematch.MatchId)
                throw new Exception("Players could not requeue after Worker crash settlement.");
            Console.WriteLine("PASS: deferred pair, stable grants, terminal revocation, Worker crash recovery and rematch");
        }
        finally
        {
            Stop(backend);Stop(worker);
            await mongo.DropDatabaseAsync(database);
        }
    }

    private static int FreeTcpPort()
    {var listener=new TcpListener(IPAddress.Loopback,0);listener.Start();int port=((IPEndPoint)listener.LocalEndpoint).Port;listener.Stop();return port;}
    private static int FreeUdpPort()
    {using var socket=new UdpClient(new IPEndPoint(IPAddress.Loopback,0));return ((IPEndPoint)socket.Client.LocalEndPoint!).Port;}
    private static Process Start(string dll,string run,string label,IReadOnlyDictionary<string,string> environment)
    {
        var info=new ProcessStartInfo("dotnet") {UseShellExecute=false,CreateNoWindow=true,
            WindowStyle=ProcessWindowStyle.Hidden,WorkingDirectory=Path.GetDirectoryName(dll)!};
        info.ArgumentList.Add(dll);
        foreach(var (key,value) in environment)info.Environment[key]=value;
        info.RedirectStandardOutput=true;info.RedirectStandardError=true;
        var process=Process.Start(info)??throw new Exception(label+" did not start.");
        _=Pump(process.StandardOutput,Path.Combine(run,label+".log"));
        _=Pump(process.StandardError,Path.Combine(run,label+".error.log"));
        return process;
    }
    private static async Task Pump(StreamReader reader,string path)
    {await using var output=new FileStream(path,FileMode.Create,FileAccess.Write,FileShare.Read);
        await reader.BaseStream.CopyToAsync(output);}
    private static async Task Ready(string url,Process process)
    {
        using var http=new HttpClient{Timeout=TimeSpan.FromSeconds(1)};
        for(int i=0;i<100;i++)
        {
            if(process.HasExited)throw new Exception("Service exited before ready: "+url);
            try {if((await http.GetAsync(url)).IsSuccessStatusCode)return;}
            catch(HttpRequestException){}
            catch(TaskCanceledException){}
            await Task.Delay(100);
        }
        throw new Exception("Service did not become ready: "+url);
    }
    private static void Stop(Process? process)
    {if(process==null)return;try {if(!process.HasExited){process.Kill(true);process.WaitForExit(5000);}}finally{process.Dispose();}}
}

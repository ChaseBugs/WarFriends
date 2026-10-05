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
            var waiting=await left.JoinMatchQueueAsync(tokens[0],deadline.Token);
            var rematch=await right.JoinMatchQueueAsync(tokens[1],deadline.Token);
            if(waiting.Code!="waiting"||rematch.Code!="paired"||rematch.MatchId==grants[0].MatchId)
                throw new Exception("Live clients could not form a distinct rematch.");
            Console.WriteLine("PASS: deferred pair survived Backend restart, issued replay-stable grants, completed live Worker UDP, and rematched");
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

using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Channels;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;

namespace War.BattleServer;

public sealed record BattleWorkerMetrics(bool Ready,long Received,long Handled,long MalformedDrops,
    long UnownedDrops,long EndpointLimitDrops,long QueueFullDrops,int Pending,long TickBacklogs);

public sealed class NetworkWorker : BackgroundService
{
    private const int TickRate = 30;
    private const int PendingPerEndpointLimit = 16;
    private readonly ILogger<NetworkWorker> logger;
    private readonly BattleTickets tickets;
    private readonly string serverId;
    private readonly IPEndPoint bind;
    private readonly int mtuBytes;
    private readonly MatchRouter match;
    private readonly TerminalOutbox terminalOutbox;
    private readonly ActiveMatchJournal activeJournal;
    private readonly BackendResultForwarder? resultForwarder;
    private readonly Uri? resultEndpoint;
    private readonly BackendAllocationClient? allocationClient;
    private readonly Uri? allocationEndpoint;
    public TerminalOutbox Outbox => terminalOutbox;
    private readonly Channel<Datagram> incoming = Channel.CreateBounded<Datagram>(new BoundedChannelOptions(512) { SingleReader = true, SingleWriter = true, FullMode = BoundedChannelFullMode.Wait });
    private readonly object incomingGate = new();
    private readonly Dictionary<IPEndPoint,int> pendingByEndpoint = [];
    private readonly Dictionary<IPEndPoint,SenderRateWindow> rateByEndpoint = [];
    private Dictionary<ulong,IPEndPoint> activeMatchEndpoints = [];
    private long receivedDatagrams,handledDatagrams,malformedDrops,unownedDrops,
        endpointLimitDrops,queueFullDrops,tickBacklogs;
    private int pendingDatagrams;
    public BattleWorkerMetrics Metrics => new(IsReady,Interlocked.Read(ref receivedDatagrams),
        Interlocked.Read(ref handledDatagrams),Interlocked.Read(ref malformedDrops),
        Interlocked.Read(ref unownedDrops),Interlocked.Read(ref endpointLimitDrops),
        Interlocked.Read(ref queueFullDrops),Volatile.Read(ref pendingDatagrams),
        Interlocked.Read(ref tickBacklogs));
    private readonly Channel<Registration> registrations=Channel.CreateBounded<Registration>(new BoundedChannelOptions(32)
        {SingleReader=true,SingleWriter=false,FullMode=BoundedChannelFullMode.Wait});
    private readonly object controlGate=new();
    private readonly Dictionary<ulong, Session> sessions = [];
    private readonly Dictionary<ulong, long> closed = [];
    private ulong tick;
    private int ready;
    private int controlClosed;
    public bool IsReady=>Volatile.Read(ref ready)==1;
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        lock(controlGate)
        {
            Volatile.Write(ref ready,0);
            Volatile.Write(ref controlClosed,1);
            registrations.Writer.TryComplete();
        }
        return base.StopAsync(cancellationToken);
    }
    private sealed record Datagram(byte[] Bytes, IPEndPoint Endpoint, Packet Packet);
    private sealed record Registration(MatchManifest? Manifest,string? MatchId,string? PlayerId,string? RequestId,bool Cancel,CancellationToken Cancellation,
        TaskCompletionSource<MatchRegistrationResult> Completion);

    public Task<MatchRegistrationResult> RegisterMatch(MatchManifest manifest,CancellationToken ct)
    {
        var completion=new TaskCompletionSource<MatchRegistrationResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        return EnqueueRegistration(new Registration(manifest,null,null,null,false,ct,completion));
    }
    public Task<MatchRegistrationResult> RegisterReconnect(string matchId,string playerId,string requestId,CancellationToken ct)
    {
        var completion=new TaskCompletionSource<MatchRegistrationResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        return EnqueueRegistration(new Registration(null,matchId,playerId,requestId,false,ct,completion));
    }
    public Task<MatchRegistrationResult> CancelMatchBeforeStart(string matchId,CancellationToken ct)
    {
        var completion=new TaskCompletionSource<MatchRegistrationResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        return EnqueueRegistration(new Registration(null,matchId,null,null,true,ct,completion));
    }
    private Task<MatchRegistrationResult> EnqueueRegistration(Registration registration)
    {
        if(registration.Cancellation.IsCancellationRequested)
            return Task.FromCanceled<MatchRegistrationResult>(registration.Cancellation);
        lock(controlGate)
        {
            if(!IsReady)return Task.FromResult(new MatchRegistrationResult("control-unavailable",""));
            if(!registrations.Writer.TryWrite(registration))
                return Task.FromResult(new MatchRegistrationResult("control-capacity",""));
        }
        return registration.Completion.Task.WaitAsync(registration.Cancellation);
    }
    private sealed class Session(IPEndPoint endpoint, byte[] key, long expires)
    {
        public IPEndPoint Endpoint { get; } = endpoint;
        public byte[] Key { get; } = key;
        public long Expires { get; } = expires;
        public ReplayWindow Replay { get; } = new();
        public ulong Outgoing { get; set; }
    }
    private static BattleRuntimeConfig ResolveRuntime(IConfiguration config) =>
        BattleRuntimeConfigValidator.ValidateAndFreeze(new BattleRuntimeConfig(
            int.Parse(config["Battle:Port"] ?? "30000", System.Globalization.CultureInfo.InvariantCulture),
            int.Parse(config["Battle:MaxMatches"]??"32",System.Globalization.CultureInfo.InvariantCulture),
            TickRate,
            int.Parse(config["Battle:MtuBytes"]??"1200",System.Globalization.CultureInfo.InvariantCulture)));

    public NetworkWorker(IConfiguration config, ILogger<NetworkWorker> logger)
        : this(config, ResolveRuntime(config), logger) { }

    public NetworkWorker(IConfiguration config, BattleRuntimeConfig runtime, ILogger<NetworkWorker> logger)
    {
        this.logger = logger;
        tickets = new BattleTickets(config["Battle:SigningKey"] ?? throw new InvalidOperationException("Set Battle__SigningKey in BOTH processes."));
        serverId = config["Battle:ServerId"] ?? "local-1";
        runtime=BattleRuntimeConfigValidator.ValidateAndFreeze(runtime);
        int port=runtime.Port;
        int maxMatches=runtime.MaxMatches;
        mtuBytes=runtime.MtuBytes;
        mtuBytes=Math.Min(mtuBytes,PacketCodec.MaximumDatagramBytes);
        if (port is < 1 or > 65535 || !System.Text.RegularExpressions.Regex.IsMatch(serverId, @"\A[a-zA-Z0-9-]{1,64}\z")) throw new InvalidOperationException("Invalid battle endpoint configuration.");
        bind = new IPEndPoint(IPAddress.Parse(config["Battle:BindAddress"] ?? "127.0.0.1"), port);
        string? manifestPath = config["Battle:MatchManifestPath"];
        string? manifestDirectory = config["Battle:MatchManifestDirectory"];
        string? combatPath=config["Battle:CombatContentManifestPath"];
        string? shotgunPath=config["Battle:ShotgunContentManifestPath"];
        string? smgPath=config["Battle:SmgContentManifestPath"];
        string? pistolPath=config["Battle:PistolContentManifestPath"];
        string? lmgPath=config["Battle:LmgContentManifestPath"];
        string? minigunPath=config["Battle:MinigunContentManifestPath"];
        string? sniperPath=config["Battle:SniperContentManifestPath"];
        string? bazookaPath=config["Battle:BazookaContentManifestPath"];
        string? grenadePath=config["Battle:GrenadeContentManifestPath"];
        if((!string.IsNullOrEmpty(shotgunPath)||!string.IsNullOrEmpty(smgPath)||!string.IsNullOrEmpty(pistolPath)||!string.IsNullOrEmpty(lmgPath)||!string.IsNullOrEmpty(minigunPath)||!string.IsNullOrEmpty(sniperPath)||!string.IsNullOrEmpty(bazookaPath)||!string.IsNullOrEmpty(grenadePath)) && string.IsNullOrEmpty(combatPath))
            throw new InvalidDataException("Weapon content requires the pinned combat package.");
        var combat=string.IsNullOrEmpty(combatPath) ? null : BattleCombatContent.Load(combatPath,
            string.IsNullOrEmpty(shotgunPath)?null:shotgunPath,
            string.IsNullOrEmpty(smgPath)?null:smgPath,
            string.IsNullOrEmpty(pistolPath)?null:pistolPath,
            string.IsNullOrEmpty(lmgPath)?null:lmgPath,
            string.IsNullOrEmpty(minigunPath)?null:minigunPath,
            string.IsNullOrEmpty(sniperPath)?null:sniperPath,
            string.IsNullOrEmpty(bazookaPath)?null:bazookaPath,
            string.IsNullOrEmpty(grenadePath)?null:grenadePath);
        if (!string.IsNullOrEmpty(manifestPath) && !string.IsNullOrEmpty(manifestDirectory)) throw new InvalidDataException("Choose a single manifest or a manifest directory.");
        var files = !string.IsNullOrEmpty(manifestPath) ? new[] { manifestPath } :
            !string.IsNullOrEmpty(manifestDirectory) ? Directory.EnumerateFiles(manifestDirectory, "*.json").Take(33).Order(StringComparer.Ordinal).ToArray() : [];
        var maps = string.IsNullOrEmpty(config["Battle:ContentPath"]) ? null : RecoveredBattleMap.Load(config["Battle:ContentPath"]!);
        match = new MatchRouter(files.Select(MatchManifest.Read), serverId, config["Battle:SigningKey"]!, maps,combat,
            config["Battle:PublicHost"] ?? "127.0.0.1",(uint)port,maxMatches);
        string outboxPath=config["Battle:ResultOutboxPath"]??
            Path.Combine(AppContext.BaseDirectory,"battle-outbox");
        string? resultEndpointText=config["Battle:BackendResultEndpoint"];
        string? allocationEndpointText=config["Battle:BackendAllocationEndpoint"];
        string? resultKeyText=config["Battle:ControlKey"];
        resultEndpoint=null; resultForwarder=null; allocationEndpoint=null; allocationClient=null;
        if (!string.IsNullOrWhiteSpace(resultEndpointText))
        {
            if (!Uri.TryCreate(resultEndpointText, UriKind.Absolute, out var parsed) || parsed.Scheme is not ("http" or "https") || string.IsNullOrWhiteSpace(resultKeyText))
                throw new InvalidDataException("Backend result forwarding requires a valid endpoint and control key.");
            byte[] key=Convert.FromBase64String(resultKeyText);
            resultEndpoint=parsed; resultForwarder=new BackendResultForwarder(new HttpClient { Timeout=TimeSpan.FromSeconds(5) },key,serverId);
        }
        if (!string.IsNullOrWhiteSpace(allocationEndpointText))
        {
            if (!Uri.TryCreate(allocationEndpointText, UriKind.Absolute, out var parsed) || parsed.Scheme is not ("http" or "https") || string.IsNullOrWhiteSpace(resultKeyText))
                throw new InvalidDataException("Backend allocation loading requires a valid endpoint and control key.");
            byte[] key=Convert.FromBase64String(resultKeyText);
            allocationEndpoint=parsed; allocationClient=new BackendAllocationClient(new HttpClient {Timeout=TimeSpan.FromSeconds(5)},key,serverId);
        }
        activeJournal=new ActiveMatchJournal(Path.Combine(outboxPath,"active"));
        terminalOutbox=new TerminalOutbox(outboxPath,activeJournal.ActiveMatchIds());
        terminalOutbox.PruneAcknowledged(DateTimeOffset.UtcNow);
        if(match.MatchIds.Any(terminalOutbox.HasIdentity))
            throw new InvalidDataException("Startup match identity already has a durable terminal result.");
        int recovered=activeJournal.Recover(terminalOutbox,match.ContainsMatch);
        if(recovered>0)logger.LogWarning("Recovered {Count} abandoned runtime allocations as unscored host-crash results",recovered);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var socket = new Socket(bind.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(bind);
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
        Task receive = Receive(socket, linked.Token);
        logger.LogInformation("Protobuf UDP listening at {Endpoint}; {Rate} Hz; startup matches: {Count}", bind, TickRate, match.Count);
        lock(controlGate)
            if(!stoppingToken.IsCancellationRequested && Volatile.Read(ref controlClosed)==0)
                Volatile.Write(ref ready,1);
        long previous = Stopwatch.GetTimestamp();
        double accumulator = 0;
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (receive.IsCompleted) await receive;
                long now = Stopwatch.GetTimestamp();
                accumulator += (now - previous) / (double)Stopwatch.Frequency;
                previous = now;
                if (accumulator > 4.0 / TickRate) { accumulator = 4.0 / TickRate;
                    Interlocked.Increment(ref tickBacklogs);logger.LogWarning("Tick backlog capped"); }
                while (accumulator >= 1.0 / TickRate)
                {
                    accumulator -= 1.0 / TickRate;
                    tick++;
                    for(int i=0;i<8 && registrations.Reader.TryRead(out var registration);i++)
                    {
                        if(registration.Cancellation.IsCancellationRequested)
                        {registration.Completion.TrySetCanceled(registration.Cancellation);continue;}
                        if(registration.Cancel)
                        {
                            try
                            {
                                var result=match.CancelBeforeStart(registration.MatchId!);
                                if(result.Code is "cancelled-before-start" or "already-cancelled")PersistTerminals();
                                registration.Completion.TrySetResult(result);
                            }
                            catch(Exception e)
                            {
                                registration.Completion.TrySetException(e);
                                throw;
                            }
                            continue;
                        }
                        MatchRegistrationResult issued;
                        MatchManifest? effectiveManifest=registration.Manifest;
                        try
                        {
                            if(effectiveManifest!=null && effectiveManifest.Allocations==null && allocationClient!=null && allocationEndpoint!=null)
                                effectiveManifest=effectiveManifest with {Allocations=await allocationClient.ReadAsync(allocationEndpoint,
                                    effectiveManifest.Players.Select(x=>x.PlayerId),registration.Cancellation)};
                            issued=registration.Manifest!=null
                                ? terminalOutbox.HasIdentity(effectiveManifest!.MatchId)
                                    ? new MatchRegistrationResult("terminal-match-id","")
                                    : match.Register(effectiveManifest)
                                : match.Reconnect(registration.MatchId!,registration.PlayerId!,registration.RequestId!);
                        }
                        catch(Exception e) when(e is InvalidDataException or ArgumentException or OverflowException or HttpRequestException)
                        {registration.Completion.TrySetResult(new MatchRegistrationResult("invalid-manifest",""));continue;}
                        try
                        {
                            if(effectiveManifest!=null && issued.Code=="registered")
                                activeJournal.Begin(effectiveManifest,issued.ManifestHash);
                            registration.Completion.TrySetResult(issued);
                        }
                        catch(Exception e)
                        {
                            registration.Completion.TrySetException(e);
                            throw;
                        }
                    }
                    match.Advance(tick);
                    PersistTerminals();
                    if (resultForwarder != null && resultEndpoint != null && tick % (ulong)TickRate == 0)
                    {
                        try { await terminalOutbox.ForwardPendingAsync(resultForwarder, resultEndpoint, 16, stoppingToken); }
                        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { throw; }
                        catch (Exception e) { logger.LogWarning("Backend result forwarding deferred: {ErrorType}", e.GetType().Name); }
                    }
                    if(tick%(ulong)(TickRate*3600)==0)
                        terminalOutbox.PruneAcknowledged(DateTimeOffset.UtcNow);
                    for (int i = 0; i < 128 && incoming.Reader.TryRead(out var datagram); i++)
                    {
                        lock(incomingGate)
                        {
                            int pending=pendingByEndpoint[datagram.Endpoint];
                            if(pending==1)pendingByEndpoint.Remove(datagram.Endpoint);
                            else pendingByEndpoint[datagram.Endpoint]=pending-1;
                            Interlocked.Decrement(ref pendingDatagrams);
                        }
                        await Handle(socket, datagram, stoppingToken);
                        Interlocked.Increment(ref handledDatagrams);
                    }
                    long unix = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    foreach (ulong id in sessions.Where(x => x.Value.Expires <= unix).Select(x => x.Key).ToArray()) sessions.Remove(id);
                    foreach (ulong id in closed.Where(x => x.Value <= unix).Select(x => x.Key).ToArray()) closed.Remove(id);
                    // Tombstones are bounded by the admission cap; never reopen a closed ticket.
                }
                await Task.Delay(1, stoppingToken);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { }
        finally
        {
            lock(controlGate)
            {
                Volatile.Write(ref ready,0);
                Volatile.Write(ref controlClosed,1);
                registrations.Writer.TryComplete();
            }
            while(registrations.Reader.TryRead(out var abandoned))
                abandoned.Completion.TrySetResult(new MatchRegistrationResult("control-unavailable",""));
            linked.Cancel();
            try { await receive; }
            catch (OperationCanceledException) { }
            finally
            {
                int aborted=match.AbortForHostShutdown();
                PersistTerminals();
                if(aborted>0)logger.LogInformation("Persisted {Count} unscored host-shutdown results",aborted);
            }
        }
    }
    private async Task Receive(Socket socket, CancellationToken ct)
    {
        byte[] buffer = new byte[mtuBytes + 1];
        EndPoint any = new IPEndPoint(bind.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any, 0);
        while (!ct.IsCancellationRequested)
        {
            SocketReceiveFromResult received;
            try { received = await socket.ReceiveFromAsync(buffer, SocketFlags.None, any, ct); }
            catch (SocketException e) when (e.SocketErrorCode == SocketError.MessageSize)
            {Interlocked.Increment(ref malformedDrops);continue;}
            Interlocked.Increment(ref receivedDatagrams);
            if (!PacketMtuPolicy.Accept(received.ReceivedBytes,mtuBytes))
            {Interlocked.Increment(ref malformedDrops);continue;}
            byte[] bytes=buffer.AsSpan(0,received.ReceivedBytes).ToArray();
            Packet? packet=PacketCodec.ReadUntrusted(bytes);
            if(packet==null){Interlocked.Increment(ref malformedDrops);continue;}
            var endpoint=(IPEndPoint)received.RemoteEndPoint;
            if(IsMatchBody(packet.BodyCase))
            {
                var active=Volatile.Read(ref activeMatchEndpoints);
                if(active.TryGetValue(packet.SessionId,out var owner))
                {if(!owner.Equals(endpoint)){Interlocked.Increment(ref unownedDrops);continue;}}
                else if(packet.BodyCase!=Packet.BodyOneofCase.MatchHello)
                {Interlocked.Increment(ref unownedDrops);continue;}
            }
            // A single endpoint cannot occupy the whole fixed queue while
            // other matches need admission, commands, or reconnect polls.
            lock(incomingGate)
            {
                if(!rateByEndpoint.TryGetValue(endpoint,out var rate))
                {
                    if(rateByEndpoint.Count>=4096){Interlocked.Increment(ref endpointLimitDrops);continue;}
                    rateByEndpoint[endpoint]=rate=new SenderRateWindow();
                }
                if(!rate.Allow(tick)){Interlocked.Increment(ref malformedDrops);continue;}
                int pending=pendingByEndpoint.GetValueOrDefault(endpoint);
                if(pending>=PendingPerEndpointLimit)
                {Interlocked.Increment(ref endpointLimitDrops);continue;}
                if(incoming.Writer.TryWrite(new Datagram(bytes,endpoint,packet)))
                {pendingByEndpoint[endpoint]=pending+1;Interlocked.Increment(ref pendingDatagrams);}
                else Interlocked.Increment(ref queueFullDrops);
            }
        }
    }
    private async Task Handle(Socket socket, Datagram d, CancellationToken ct)
    {
        Packet packet=d.Packet;
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (IsMatchBody(packet.BodyCase) || match.Owns(packet.SessionId))
        {
            // Connectivity sessions cannot become match participants, even with
            // colliding IDs. Match keys and tickets use a separate signing domain.
            if (sessions.ContainsKey(packet.SessionId) || closed.ContainsKey(packet.SessionId)) return;
            byte[]? response = match.Handle(packet, d.Bytes, d.Endpoint, now);
            if(packet.BodyCase==Packet.BodyOneofCase.MatchHello && response!=null)
                Volatile.Write(ref activeMatchEndpoints,match.ActiveSessionEndpoints());
            PersistTerminals();
            if (response != null)
            {
                try { await socket.SendToAsync(response, SocketFlags.None, d.Endpoint, ct); }
                catch (SocketException e) { logger.LogDebug("Match UDP send failed: {Code}", e.SocketErrorCode); }
            }
            return;
        }
        if(!ValidProbeBody(packet))return;
        if (packet.BodyCase == Packet.BodyOneofCase.Hello && !sessions.ContainsKey(packet.SessionId))
        {
            if (sessions.Count + closed.Count >= 128 || closed.ContainsKey(packet.SessionId)) return;
            var claims = tickets.Validate(packet.Hello.Ticket, serverId, now);
            if (claims == null || claims.SessionId != packet.SessionId) return;
            byte[] key = tickets.SessionKey(packet.SessionId);
            if (!PacketCodec.Authenticate(d.Bytes, key)) return;
            sessions.Add(packet.SessionId, new Session(d.Endpoint, key, claims.ExpiresUnixSeconds));
        }
        if (!sessions.TryGetValue(packet.SessionId, out var session) || session.Expires <= now || !session.Endpoint.Equals(d.Endpoint) || !PacketCodec.Authenticate(d.Bytes, session.Key)) return;
        bool fresh = session.Replay.Accept(packet.Sequence);
        if (!fresh && packet.BodyCase != Packet.BodyOneofCase.Hello) return;
        var reply = new Packet { Version = 1, SessionId = packet.SessionId, Sequence = ++session.Outgoing, Ack = packet.Sequence };
        switch (packet.BodyCase)
        {
            case Packet.BodyOneofCase.Hello: reply.Welcome = new ServerHello { TickRate = TickRate, ServerId = serverId }; break;
            case Packet.BodyOneofCase.Ping: reply.Pong = new Pong { ClientTime = packet.Ping.ClientTime, ServerTick = tick }; break;
            case Packet.BodyOneofCase.Disconnect: sessions.Remove(packet.SessionId); closed[packet.SessionId] = session.Expires; return;
            default: return;
        }
        byte[] encoded = PacketCodec.Encode(reply, session.Key);
        try { await socket.SendToAsync(encoded, SocketFlags.None, d.Endpoint, ct); }
        catch (SocketException e) { logger.LogDebug("UDP send failed: {Code}", e.SocketErrorCode); }
    }
    private static bool IsMatchBody(Packet.BodyOneofCase body)
        => body is Packet.BodyOneofCase.MatchHello or Packet.BodyOneofCase.MatchCommand or
            Packet.BodyOneofCase.MatchReply or Packet.BodyOneofCase.MatchEventPoll or Packet.BodyOneofCase.MatchEventBatch or
            Packet.BodyOneofCase.MatchBarrelPoll or Packet.BodyOneofCase.MatchBarrelBatch or
            Packet.BodyOneofCase.MatchArmyPoll or Packet.BodyOneofCase.MatchArmyBatch or
            Packet.BodyOneofCase.MatchArmyEntityPoll or Packet.BodyOneofCase.MatchArmyEntityBatch;
    private static bool ValidProbeBody(Packet packet)
    {
        switch(packet.BodyCase)
        {
            case Packet.BodyOneofCase.Hello:
                return packet.Hello.Ticket.Length is >=10 and <=1024 &&
                    packet.Hello.CalculateSize()==new ClientHello {Ticket=packet.Hello.Ticket}.CalculateSize();
            case Packet.BodyOneofCase.Ping:
                return packet.Ping.CalculateSize()==new Ping {ClientTime=packet.Ping.ClientTime}.CalculateSize();
            case Packet.BodyOneofCase.Disconnect:
                return packet.Disconnect.Reason.Length<=128 &&
                    packet.Disconnect.CalculateSize()==new Disconnect {Reason=packet.Disconnect.Reason}.CalculateSize();
            default:return false;
        }
    }
    private void PersistTerminals()
    {
        foreach(var snapshot in match.UnpublishedTerminals())
        {
            terminalOutbox.Publish(snapshot);
            match.MarkTerminalPublished(snapshot.MatchId);
            activeJournal.Complete(snapshot.MatchId);
        }
    }
}

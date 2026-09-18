using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Channels;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;

namespace War.BattleServer;

public sealed class NetworkWorker : BackgroundService
{
    private const int TickRate = 30;
    private readonly ILogger<NetworkWorker> logger;
    private readonly BattleTickets tickets;
    private readonly string serverId;
    private readonly IPEndPoint bind;
    private readonly MatchRouter? match;
    private readonly Channel<Datagram> incoming = Channel.CreateBounded<Datagram>(new BoundedChannelOptions(512) { SingleReader = true, SingleWriter = true, FullMode = BoundedChannelFullMode.Wait });
    private readonly Dictionary<ulong, Session> sessions = [];
    private readonly Dictionary<ulong, long> closed = [];
    private ulong tick;
    private sealed record Datagram(byte[] Bytes, IPEndPoint Endpoint);
    private sealed class Session(IPEndPoint endpoint, byte[] key, long expires)
    {
        public IPEndPoint Endpoint { get; } = endpoint;
        public byte[] Key { get; } = key;
        public long Expires { get; } = expires;
        public ReplayWindow Replay { get; } = new();
        public ulong Outgoing { get; set; }
    }
    public NetworkWorker(IConfiguration config, ILogger<NetworkWorker> logger)
    {
        this.logger = logger;
        tickets = new BattleTickets(config["Battle:SigningKey"] ?? throw new InvalidOperationException("Set Battle__SigningKey in BOTH processes."));
        serverId = config["Battle:ServerId"] ?? "local-1";
        int port = int.Parse(config["Battle:Port"] ?? "30000", System.Globalization.CultureInfo.InvariantCulture);
        if (port is < 1 or > 65535 || !System.Text.RegularExpressions.Regex.IsMatch(serverId, @"\A[a-zA-Z0-9-]{1,64}\z")) throw new InvalidOperationException("Invalid battle endpoint configuration.");
        bind = new IPEndPoint(IPAddress.Parse(config["Battle:BindAddress"] ?? "127.0.0.1"), port);
        string? manifestPath = config["Battle:MatchManifestPath"];
        string? manifestDirectory = config["Battle:MatchManifestDirectory"];
        if (!string.IsNullOrEmpty(manifestPath) && !string.IsNullOrEmpty(manifestDirectory)) throw new InvalidDataException("Choose a single manifest or a manifest directory.");
        if (!string.IsNullOrEmpty(manifestPath) || !string.IsNullOrEmpty(manifestDirectory))
        {
            var files = !string.IsNullOrEmpty(manifestPath) ? new[] { manifestPath } : Directory.EnumerateFiles(manifestDirectory!, "*.json").Take(33).Order(StringComparer.Ordinal).ToArray();
            var maps = string.IsNullOrEmpty(config["Battle:ContentPath"]) ? null : RecoveredBattleMap.Load(config["Battle:ContentPath"]!);
            match = new MatchRouter(files.Select(MatchManifest.Read), serverId, config["Battle:SigningKey"]!, maps);
        }
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var socket = new Socket(bind.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(bind);
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
        Task receive = Receive(socket, linked.Token);
        logger.LogInformation("Protobuf UDP listening at {Endpoint}; {Rate} Hz; prototype match configured: {Match}", bind, TickRate, match != null);
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
                if (accumulator > 4.0 / TickRate) { accumulator = 4.0 / TickRate; logger.LogWarning("Tick backlog capped"); }
                while (accumulator >= 1.0 / TickRate)
                {
                    accumulator -= 1.0 / TickRate;
                    tick++;
                    match?.Advance(tick);
                    for (int i = 0; i < 128 && incoming.Reader.TryRead(out var datagram); i++) await Handle(socket, datagram, stoppingToken);
                    long unix = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    foreach (ulong id in sessions.Where(x => x.Value.Expires <= unix).Select(x => x.Key).ToArray()) sessions.Remove(id);
                    foreach (ulong id in closed.Where(x => x.Value <= unix).Select(x => x.Key).ToArray()) closed.Remove(id);
                    // Tombstones are bounded by the admission cap; never reopen a closed ticket.
                }
                await Task.Delay(1, stoppingToken);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { }
        finally { linked.Cancel(); try { await receive; } catch (OperationCanceledException) { } }
    }
    private async Task Receive(Socket socket, CancellationToken ct)
    {
        byte[] buffer = new byte[PacketCodec.MaximumDatagramBytes + 1];
        EndPoint any = new IPEndPoint(bind.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any, 0);
        while (!ct.IsCancellationRequested)
        {
            SocketReceiveFromResult received;
            try { received = await socket.ReceiveFromAsync(buffer, SocketFlags.None, any, ct); }
            catch (SocketException e) when (e.SocketErrorCode == SocketError.MessageSize) { continue; }
            if (received.ReceivedBytes <= PacketCodec.MacBytes || received.ReceivedBytes > PacketCodec.MaximumDatagramBytes) continue;
            // Fixed queue and MTU bound memory; no Task.Run per datagram.
            incoming.Writer.TryWrite(new Datagram(buffer.AsSpan(0, received.ReceivedBytes).ToArray(), (IPEndPoint)received.RemoteEndPoint));
        }
    }
    private async Task Handle(Socket socket, Datagram d, CancellationToken ct)
    {
        Packet? packet = PacketCodec.ReadUntrusted(d.Bytes);
        if (packet == null) return;
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (match != null && (packet.BodyCase is Packet.BodyOneofCase.MatchHello or Packet.BodyOneofCase.MatchCommand or Packet.BodyOneofCase.MatchReply || match.Owns(packet.SessionId)))
        {
            // Connectivity sessions cannot become match participants, even with
            // colliding IDs. Match keys and tickets use a separate signing domain.
            if (sessions.ContainsKey(packet.SessionId) || closed.ContainsKey(packet.SessionId)) return;
            byte[]? response = match.Handle(packet, d.Bytes, d.Endpoint, now);
            if (response != null)
            {
                try { await socket.SendToAsync(response, SocketFlags.None, d.Endpoint, ct); }
                catch (SocketException e) { logger.LogDebug("Match UDP send failed: {Code}", e.SocketErrorCode); }
            }
            return;
        }
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
}

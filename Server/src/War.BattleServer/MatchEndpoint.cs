using System.Net;
using War.Protocol;
using War.Protocol.Transport;

namespace War.BattleServer;

// One operator-provisioned match for the first vertical slice. No public match
// creation API. Two bounded sessions; no DB, rewards or production allocation.
public sealed class MatchEndpoint
{
    private readonly MatchEngine match;
    private readonly MatchTokens tokens;
    private readonly string serverId;
    private readonly Dictionary<ulong, Session> sessions = [];
    private readonly Dictionary<string, ulong> generations = new(StringComparer.Ordinal);
    public string MatchId => match.MatchId;
    private sealed class Session(string playerId, IPEndPoint endpoint, byte[] key)
    {
        public string PlayerId { get; } = playerId;
        public IPEndPoint Endpoint { get; } = endpoint;
        public byte[] Key { get; } = key;
        public ReplayWindow Replay { get; } = new();
        public ulong Outgoing;
        public ulong BudgetTick;
        public int UsedBudget;
    }
    private ulong tick;
    private ulong? terminalTick;
    public MatchEndpoint(MatchManifest manifest, string signingKey, RecoveredBattleMap? map = null)
    {
        match = new MatchEngine(manifest, map);
        serverId = manifest.ServerId;
        tokens = new MatchTokens(signingKey);
    }
    public bool Owns(ulong sessionId) => sessions.ContainsKey(sessionId);
    public void Advance(ulong nextTick)
    {
        tick = nextTick;
        if (terminalTick.HasValue && tick - terminalTick.Value > 120 * MatchManifest.TickRate) return;
        match.Advance(tick);
        if (match.Terminal) terminalTick ??= tick;
    }
    public byte[]? Handle(Packet packet, byte[] datagram, IPEndPoint endpoint, long unixNow)
    {
        if (terminalTick.HasValue && tick - terminalTick.Value > 120 * MatchManifest.TickRate) return null;
        if (packet.BodyCase == Packet.BodyOneofCase.MatchHello && !sessions.ContainsKey(packet.SessionId))
        {
            var claims = tokens.Validate(packet.MatchHello.Ticket, match, serverId, unixNow);
            if (claims == null || claims.SessionId != packet.SessionId) return null;
            byte[] key = tokens.SessionKey(claims);
            if (!PacketCodec.Authenticate(datagram, key)) return null;
            if (generations.TryGetValue(claims.PlayerId, out ulong generation))
            {
                if (claims.ConnectionGeneration <= generation || !match.Resume(claims.PlayerId)) return null;
                ulong old = sessions.Single(s => s.Value.PlayerId == claims.PlayerId).Key;
                sessions.Remove(old); // Revoke old key/endpoint before admitting the replacement.
            }
            else if (sessions.Count >= 2 || !match.Admit(claims.PlayerId)) return null;
            generations[claims.PlayerId] = claims.ConnectionGeneration;
            sessions.Add(packet.SessionId, new Session(claims.PlayerId, endpoint, key));
        }
        if (!sessions.TryGetValue(packet.SessionId, out var session) || !session.Endpoint.Equals(endpoint) || !PacketCodec.Authenticate(datagram, session.Key)) return null;
        // At most four authenticated commands per player/tick, in addition to the
        // host's global bounded receive queue. Excess traffic cannot refill budget.
        if (session.BudgetTick != tick) { session.BudgetTick = tick; session.UsedBudget = 0; }
        if (++session.UsedBudget > 4) return null;
        bool fresh = session.Replay.Accept(packet.Sequence);
        if (!fresh && packet.BodyCase != Packet.BodyOneofCase.MatchHello) return null;
        MatchReply response;
        switch (packet.BodyCase)
        {
            case Packet.BodyOneofCase.MatchHello:
                response = match.Reply(0, "admitted");
                break;
            case Packet.BodyOneofCase.MatchCommand:
                response = match.Command(session.PlayerId, packet.MatchCommand);
                break;
            default: return null;
        }
        return PacketCodec.Encode(new Packet
        {
            Version = 1, SessionId = packet.SessionId, Sequence = ++session.Outgoing,
            Ack = packet.Sequence, MatchReply = response
        }, session.Key);
    }
}

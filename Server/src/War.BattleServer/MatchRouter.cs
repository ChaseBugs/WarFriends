using System.Net;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Bounded set of trusted startup allocations. No public UDP allocation.
/// The future allocator can supply this same manifest contract through an internal API.</summary>
public sealed class MatchRouter
{
    private readonly Dictionary<string, MatchEndpoint> matches;
    public int Count => matches.Count;
    public MatchRouter(IEnumerable<MatchManifest> manifests, string serverId, string signingKey, IReadOnlyList<RecoveredBattleMap>? maps = null)
    {
        var all = manifests.Take(33).ToArray();
        if (all.Length is < 1 or > 32 || all.Any(m => m.ServerId != serverId) || all.Select(m => m.MatchId).Distinct(StringComparer.Ordinal).Count() != all.Length)
            throw new InvalidDataException("Expected 1..32 unique matches belonging to this host.");
        matches = all.ToDictionary(m => m.MatchId, m => new MatchEndpoint(m, signingKey,
            maps?.Single(map => Path.GetFileNameWithoutExtension(map.Source) == m.MapId)), StringComparer.Ordinal);
    }
    public bool Owns(ulong session) => matches.Values.Any(m => m.Owns(session));
    public void Advance(ulong tick) { foreach (var match in matches.Values) match.Advance(tick); }
    public byte[]? Handle(Packet packet, byte[] bytes, IPEndPoint endpoint, long now)
    {
        MatchEndpoint? match;
        if (packet.BodyCase == Packet.BodyOneofCase.MatchHello)
        {
            // Compatibility for the original single-match harness only. Multiple
            // allocations require an explicit ID, subsequently authenticated by ticket.
            if (packet.MatchHello.MatchId.Length == 0 && matches.Count == 1) match = matches.Values.Single();
            else if (!matches.TryGetValue(packet.MatchHello.MatchId, out match)) return null;
            if (Owns(packet.SessionId) && !match.Owns(packet.SessionId)) return null;
        }
        else match = matches.Values.FirstOrDefault(m => m.Owns(packet.SessionId));
        return match?.Handle(packet, bytes, endpoint, now);
    }
}

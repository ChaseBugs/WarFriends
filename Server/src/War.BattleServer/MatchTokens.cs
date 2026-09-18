using System.Security.Cryptography;
using System.Text;
using Google.Protobuf;
using War.Protocol;

namespace War.BattleServer;

// Server-only signing utility for trusted allocator integration and local tests.
// Separate domains prevent connectivity-probe tickets/keys authorizing a match.
public sealed class MatchTokens
{
    private readonly byte[] key;
    public MatchTokens(string base64Key)
    {
        key = Convert.FromBase64String(base64Key);
        if (key.Length != 32) throw new ArgumentException("Match signing key must contain 32 bytes.");
    }
    private byte[] Mac(string domain, byte[] payload) => HMACSHA256.HashData(key, Encoding.UTF8.GetBytes(domain).Concat(payload).ToArray());
    public byte[] SessionKey(MatchAdmission claims) => Mac("war/match/session/v1/", claims.ToByteArray());
    public string Sign(MatchAdmission claims)
    {
        byte[] bytes = claims.ToByteArray();
        return Convert.ToBase64String(bytes) + "." + Convert.ToBase64String(Mac("war/match/ticket/v1/", bytes));
    }
    public MatchAdmission? Validate(string ticket, MatchEngine match, string serverId, long now)
    {
        if (ticket.Length is < 10 or > 1024 || now < 0) return null;
        try
        {
            var parts = ticket.Split('.');
            if (parts.Length != 2) return null;
            var payload = Convert.FromBase64String(parts[0]);
            if (!CryptographicOperations.FixedTimeEquals(Mac("war/match/ticket/v1/", payload), Convert.FromBase64String(parts[1]))) return null;
            var c = MatchAdmission.Parser.ParseFrom(payload);
            if (c.ServerId != serverId || c.MatchId != match.MatchId || c.ManifestHash != match.ManifestHash ||
                !match.HasPlayer(c.PlayerId) || c.SessionId == 0 || c.ConnectionGeneration > 1000000 || c.IssuedUnixSeconds < 0 || c.IssuedUnixSeconds > now ||
                c.ExpiresUnixSeconds <= now || c.ExpiresUnixSeconds <= c.IssuedUnixSeconds ||
                c.ExpiresUnixSeconds - c.IssuedUnixSeconds > 120) return null;
            return c;
        }
        catch (Exception e) when (e is FormatException or InvalidProtocolBufferException) { return null; }
    }
}

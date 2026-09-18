using System.Security.Cryptography;
using System.Text;
using Google.Protobuf;
using War.Protocol;

namespace War.Infrastructure;

public sealed class BattleTickets
{
    public const int LifetimeSeconds = 120;
    private readonly byte[] key;
    public BattleTickets(string base64Key)
    {
        key = Convert.FromBase64String(base64Key);
        if (key.Length != 32) throw new ArgumentException("Battle signing key must contain exactly 32 random bytes.");
    }

    public byte[] SessionKey(ulong sessionId) => HMACSHA256.HashData(key, Encoding.UTF8.GetBytes("war/session/v1/" + sessionId.ToString(System.Globalization.CultureInfo.InvariantCulture)));
    public string Sign(TicketClaims claims)
    {
        byte[] payload = claims.ToByteArray();
        return Convert.ToBase64String(payload) + "." + Convert.ToBase64String(HMACSHA256.HashData(key, payload));
    }

    public TicketClaims? Validate(string ticket, string serverId, long now)
    {
        if (ticket.Length is < 10 or > 1024 || now < 0) return null;
        try
        {
            string[] parts = ticket.Split('.');
            if (parts.Length != 2) return null;
            byte[] payload = Convert.FromBase64String(parts[0]);
            if (!CryptographicOperations.FixedTimeEquals(HMACSHA256.HashData(key, payload), Convert.FromBase64String(parts[1]))) return null;
            TicketClaims claims = TicketClaims.Parser.ParseFrom(payload);
            if (claims.ServerId != serverId || claims.Purpose != "connectivity-probe" || claims.SessionId == 0 ||
                !Guid.TryParseExact(claims.PlayerId, "N", out _) || claims.IssuedUnixSeconds < 0 ||
                claims.IssuedUnixSeconds > now || claims.ExpiresUnixSeconds <= now ||
                claims.ExpiresUnixSeconds <= claims.IssuedUnixSeconds ||
                claims.ExpiresUnixSeconds - claims.IssuedUnixSeconds > LifetimeSeconds) return null;
            return claims;
        }
        catch (Exception e) when (e is FormatException or InvalidProtocolBufferException) { return null; }
    }
}

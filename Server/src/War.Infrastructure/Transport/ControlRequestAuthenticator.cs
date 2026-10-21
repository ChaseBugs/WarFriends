using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using War.BattleServer;

namespace War.Infrastructure;

/// <summary>Pure header/body MAC binding shared by both hosts; replay nonces remain a separate policy.</summary>
public sealed class ControlRequestAuthenticator
{
    private const long MaximumTimestamp = 253402300799;
    private const int ClockSkewSeconds = 30;
    private const int MacHexCharacters = 64;
    private readonly byte[] _key;
    private readonly TimeProvider _time;

    public ControlRequestAuthenticator(byte[] key, TimeProvider time)
    {
        TransportSecurityPolicy.ValidateKey(key, "Control signing key");
        _key = key.ToArray();
        _time = time ?? throw new ArgumentNullException(nameof(time));
    }

    public bool IsAuthorized(string timestampText, string macText, byte[] body, string domain)
    {
        if (!long.TryParse(timestampText, NumberStyles.None, CultureInfo.InvariantCulture, out long timestamp) ||
            timestamp < 0 || timestamp > MaximumTimestamp || macText is not { Length: MacHexCharacters } ||
            Math.Abs(_time.GetUtcNow().ToUnixTimeSeconds() - timestamp) > ClockSkewSeconds)
        {
            return false;
        }

        byte[] supplied;
        try
        {
            supplied = Convert.FromHexString(macText);
        }
        catch (FormatException)
        {
            return false;
        }
        byte[] prefix = Encoding.UTF8.GetBytes(domain + timestampText + "\n");
        byte[] payload = new byte[prefix.Length + body.Length];
        prefix.CopyTo(payload, 0);
        body.CopyTo(payload, prefix.Length);
        return CryptographicOperations.FixedTimeEquals(HMACSHA256.HashData(_key, payload), supplied);
    }
}

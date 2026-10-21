using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;

namespace War.Infrastructure;

/// <summary>Issues player-bound queue attempts without creating or replacing any queue state.</summary>
public sealed class BattleQueueAttemptTokens
{
    public const int LifetimeSeconds = War.Battle.Domain.Matchmaking.BattleQueueAttemptPolicy.LifetimeSeconds;
    private const long MaximumUnixSecond = 253402300799;
    private const byte FormatVersion = 1;
    private const int IssuedOffset = 1;
    private const int PlayerOffset = 9;
    private const int AttemptOffset = 25;
    private const int IdentityBytes = 16;
    private const int PayloadBytes = 41;
    private const int MacBytes = 32;
    private const int TokenBytes = PayloadBytes + MacBytes;
    private const int TokenCharacters = 98;
    private const string SigningDomain = "war/queue-attempt/v1/key";
    private readonly byte[] _signingKey;

    /// <summary>Derives a separate purpose key from a caller-owned 256-bit server secret.</summary>
    public BattleQueueAttemptTokens(byte[] serverKey)
    {
        if (serverKey is not { Length: MacBytes })
        {
            throw new InvalidDataException("Queue attempt signing requires a 256-bit server key.");
        }

        _signingKey = HMACSHA256.HashData(serverKey, Encoding.UTF8.GetBytes(SigningDomain));
    }

    /// <summary>Mints an opaque token; issuing it never admits or cancels another attempt.</summary>
    public string Issue(string playerId, long nowUnixSeconds)
    {
        ValidatePlayer(playerId);
        ValidateTime(nowUnixSeconds);
        if (nowUnixSeconds > MaximumUnixSecond - LifetimeSeconds)
        {
            throw new InvalidDataException("Queue attempt expiry exceeds supported server time.");
        }

        byte[] bytes = new byte[TokenBytes];
        bytes[0] = FormatVersion;
        BinaryPrimitives.WriteInt64LittleEndian(bytes.AsSpan(IssuedOffset), nowUnixSeconds);
        Convert.FromHexString(playerId).CopyTo(bytes, PlayerOffset);
        RandomNumberGenerator.Fill(bytes.AsSpan(AttemptOffset, IdentityBytes));
        HMACSHA256.HashData(_signingKey, bytes.AsSpan(0, PayloadBytes)).CopyTo(bytes, PayloadBytes);
        return Encode(bytes);
    }

    /// <summary>Rejects delayed admission at the exact half-open expiry boundary.</summary>
    public BattleQueueAttemptIdentity ValidateForJoin(string token, string playerId, long nowUnixSeconds)
    {
        var identity = ValidateForCancellation(token, playerId, nowUnixSeconds);
        if (nowUnixSeconds >= identity.ExpiresUnixSeconds)
        {
            throw new InvalidDataException("Queue attempt admission has expired.");
        }

        return identity;
    }

    /// <summary>Keeps an expired token usable only to identify its own existing cancellation authority.</summary>
    public BattleQueueAttemptIdentity ValidateForCancellation(string token, string playerId, long nowUnixSeconds)
    {
        ValidatePlayer(playerId);
        ValidateTime(nowUnixSeconds);
        byte[] bytes = Decode(token);
        byte[] expectedMac = HMACSHA256.HashData(_signingKey, bytes.AsSpan(0, PayloadBytes));
        if (!CryptographicOperations.FixedTimeEquals(expectedMac, bytes.AsSpan(PayloadBytes)))
        {
            throw new InvalidDataException("Invalid queue attempt signature.");
        }

        string owner = Convert.ToHexString(bytes.AsSpan(PlayerOffset, IdentityBytes)).ToLowerInvariant();
        long issued = BinaryPrimitives.ReadInt64LittleEndian(bytes.AsSpan(IssuedOffset));
        if (bytes[0] != FormatVersion || owner != playerId || issued < 0 ||
            issued > nowUnixSeconds || issued > MaximumUnixSecond - LifetimeSeconds)
        {
            throw new InvalidDataException("Invalid queue attempt owner or issuance time.");
        }

        string attemptId = Convert.ToHexString(bytes.AsSpan(AttemptOffset, IdentityBytes)).ToLowerInvariant();
        return new BattleQueueAttemptIdentity(owner, attemptId, issued, issued + LifetimeSeconds);
    }

    private static byte[] Decode(string token)
    {
        if (token == null || token.Length != TokenCharacters ||
            token.Any(character => !char.IsAsciiLetterOrDigit(character) && character is not ('-' or '_')))
        {
            throw new InvalidDataException("Invalid queue attempt encoding.");
        }

        byte[] bytes;
        try
        {
            bytes = Convert.FromBase64String(token.Replace('-', '+').Replace('_', '/') + "==");
        }
        catch (FormatException failure)
        {
            throw new InvalidDataException("Invalid queue attempt encoding.", failure);
        }

        if (bytes.Length != TokenBytes || Encode(bytes) != token)
        {
            throw new InvalidDataException("Noncanonical queue attempt encoding.");
        }

        return bytes;
    }

    private static string Encode(byte[] bytes)
    {
        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    private static void ValidatePlayer(string playerId)
    {
        if (!War.Shared.CanonicalGuid.IsCanonical(playerId))
        {
            throw new InvalidDataException("Invalid queue attempt player identity.");
        }
    }

    private static void ValidateTime(long nowUnixSeconds)
    {
        if (nowUnixSeconds < 0 || nowUnixSeconds > MaximumUnixSecond)
        {
            throw new InvalidDataException("Invalid queue attempt server time.");
        }
    }
}

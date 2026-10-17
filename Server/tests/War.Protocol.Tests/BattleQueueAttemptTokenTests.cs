using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;
using War.Infrastructure;

/// <summary>Checks queue attempt ownership, canonical encoding and delayed admission boundaries.</summary>
internal static class BattleQueueAttemptTokenTests
{
    private const long IssuedSecond = 1000;
    private const long MaximumUnixSecond = 253402300799;
    private const string PlayerId = "0123456789abcdef0123456789abcdef";
    private static readonly byte[] ServerKey = Enumerable.Repeat((byte)11, 32).ToArray();

    internal static int Run()
    {
        int checks = VerifyLifetimeAndOwnership();
        checks += VerifyTamperingAndEncoding();
        checks += VerifyInvalidAuthority();
        Console.WriteLine("PASS: " + checks + " player-bound queue attempt token checks");
        return checks;
    }

    private static int VerifyLifetimeAndOwnership()
    {
        var issuer = new BattleQueueAttemptTokens(ServerKey);
        string token = issuer.Issue(PlayerId, IssuedSecond);
        var identity = issuer.ValidateForJoin(token, PlayerId, IssuedSecond);
        Require(identity.PlayerId == PlayerId && identity.IssuedUnixSeconds == IssuedSecond &&
            identity.ExpiresUnixSeconds == IssuedSecond + BattleQueueAttemptTokens.LifetimeSeconds,
            "Issuance must retain exact player and server time.");
        Require(identity.AttemptId.Length == 32 &&
            issuer.ValidateForJoin(token, PlayerId, identity.ExpiresUnixSeconds - 1) == identity,
            "Admission remains valid immediately before expiry.");
        Reject(() => issuer.ValidateForJoin(token, PlayerId, identity.ExpiresUnixSeconds));
        Require(issuer.ValidateForCancellation(token, PlayerId, MaximumUnixSecond) == identity,
            "Expired credentials identify only their original cancellation scope.");
        Reject(() => issuer.ValidateForJoin(token, new string('f', 32), IssuedSecond));
        Reject(() => issuer.ValidateForCancellation(token, new string('f', 32), MaximumUnixSecond));
        Reject(() => issuer.ValidateForJoin(token, PlayerId, IssuedSecond - 1));
        Require(issuer.ValidateForJoin(issuer.Issue(PlayerId, IssuedSecond), PlayerId, IssuedSecond).AttemptId !=
            identity.AttemptId, "Fresh issuance must not reuse another attempt's nonce.");
        var restart = new BattleQueueAttemptTokens(ServerKey);
        Require(restart.ValidateForJoin(token, PlayerId, IssuedSecond) == identity,
            "The same server key validates identity across process restart.");
        byte[] mutableKey = ServerKey.ToArray();
        var copied = new BattleQueueAttemptTokens(mutableKey);
        mutableKey[0] ^= 1;
        Require(copied.ValidateForJoin(token, PlayerId, IssuedSecond) == identity,
            "Caller key mutation must not replace signing authority.");
        return 10;
    }

    private static int VerifyTamperingAndEncoding()
    {
        var issuer = new BattleQueueAttemptTokens(ServerKey);
        string token = issuer.Issue(PlayerId, IssuedSecond);
        byte[] bytes = Decode(token);
        for (int index = 0; index < bytes.Length; index++)
        {
            byte[] changed = bytes.ToArray();
            changed[index] ^= 1;
            Reject(() => issuer.ValidateForJoin(Encode(changed), PlayerId, IssuedSecond));
        }

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
        int lastIndex = alphabet.IndexOf(token[^1]);
        string noncanonical = token[..^1] + alphabet[lastIndex + 1];
        Require(Decode(noncanonical).SequenceEqual(bytes), "The padding-bit test must decode to the same bytes.");
        string[] malformed = ["", token + "=", " " + token, token[..^1], noncanonical, new string('!', 98)];
        foreach (string value in malformed)
        {
            Reject(() => issuer.ValidateForCancellation(value, PlayerId, IssuedSecond));
        }

        var wrongKey = new BattleQueueAttemptTokens(Enumerable.Repeat((byte)12, 32).ToArray());
        Reject(() => wrongKey.ValidateForJoin(token, PlayerId, IssuedSecond));
        return bytes.Length + malformed.Length + 2;
    }

    private static int VerifyInvalidAuthority()
    {
        var issuer = new BattleQueueAttemptTokens(ServerKey);
        Reject(() => new BattleQueueAttemptTokens([]));
        Reject(() => issuer.Issue(PlayerId.ToUpperInvariant(), IssuedSecond));
        Reject(() => issuer.Issue("invalid-player", IssuedSecond));
        Reject(() => issuer.Issue(PlayerId, -1));
        Reject(() => issuer.Issue(PlayerId, MaximumUnixSecond - BattleQueueAttemptTokens.LifetimeSeconds + 1));
        string token = issuer.Issue(PlayerId, IssuedSecond);
        Reject(() => issuer.ValidateForCancellation(token, PlayerId, -1));
        Reject(() => issuer.ValidateForCancellation(token, PlayerId, MaximumUnixSecond + 1));
        byte[] payload = Decode(token);
        payload[0] = 2;
        Reject(() => issuer.ValidateForJoin(Resign(payload), PlayerId, IssuedSecond));
        payload[0] = 1;
        BinaryPrimitives.WriteInt64LittleEndian(payload.AsSpan(1), -1);
        Reject(() => issuer.ValidateForJoin(Resign(payload), PlayerId, IssuedSecond));
        return 9;
    }

    private static string Resign(byte[] bytes)
    {
        byte[] key = HMACSHA256.HashData(ServerKey, Encoding.UTF8.GetBytes("war/queue-attempt/v1/key"));
        HMACSHA256.HashData(key, bytes.AsSpan(0, 41)).CopyTo(bytes, 41);
        return Encode(bytes);
    }

    private static byte[] Decode(string token)
    {
        return Convert.FromBase64String(token.Replace('-', '+').Replace('_', '/') + "==");
    }

    private static string Encode(byte[] bytes)
    {
        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("Invalid queue attempt authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

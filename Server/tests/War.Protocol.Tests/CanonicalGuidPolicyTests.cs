using System.Security.Cryptography;
using Google.Protobuf;
using War.Client;
using War.Infrastructure;
using War.Protocol;
using War.Shared;

namespace War.Protocol.Tests;

/// <summary>Checks exact identity semantics against the BCL without relying on its permissive parser alone.</summary>
internal static class CanonicalGuidPolicyTests
{
    private const string PlayerId = "abcdef0123456789abcdef0123456789";

    internal static int Run()
    {
        CheckReferenceCases();
        CheckEveryAsciiPosition();
        CheckValidationAllocations();
        CheckSignedProbeBoundary();
        CheckSdkGrantBoundary();
        return 5;
    }

    private static void CheckReferenceCases()
    {
        string?[] values = [null, "", PlayerId, new string('0', 32), Guid.NewGuid().ToString("N"),
            PlayerId[..31], PlayerId + "0", " " + PlayerId, PlayerId + " ", "\t" + PlayerId + "\n",
            PlayerId.ToUpperInvariant(), Guid.ParseExact(PlayerId, "N").ToString("D"),
            Guid.ParseExact(PlayerId, "N").ToString("B"), new string('ａ', 32), new string('٠', 32),
            new string('\0', 32), new string('\u200b', 32)];
        foreach (string? value in values)
        {
            bool expected = value?.Length == 32 && Guid.TryParseExact(value, "N", out Guid parsed) &&
                parsed.ToString("N") == value;
            Require(CanonicalGuid.IsCanonical(value) == expected, "Canonical GUID reference case disagrees.");
        }
        Require(Guid.TryParseExact(" " + PlayerId + " ", "N", out _),
            "The padding regression setup no longer reproduces the permissive BCL parser.");
    }

    private static void CheckEveryAsciiPosition()
    {
        char[] characters = PlayerId.ToCharArray();
        for (int position = 0; position < characters.Length; position++)
        {
            char original = characters[position];
            for (int code = 0; code < 128; code++)
            {
                characters[position] = (char)code;
                string candidate = new(characters);
                bool expected = Guid.TryParseExact(candidate, "N", out Guid parsed) &&
                    parsed.ToString("N") == candidate;
                Require(CanonicalGuid.IsCanonical(candidate) == expected,
                    $"Canonical GUID disagrees at position {position}, ASCII {code}.");
            }
            characters[position] = original;
        }
    }

    private static void CheckValidationAllocations()
    {
        string[] candidates = [PlayerId, " " + PlayerId, PlayerId.ToUpperInvariant(), new string('0', 32)];
        const int Repetitions = 1024;
        for (int index = 0; index < Repetitions; index++)
        {
            CanonicalGuid.IsCanonical(candidates[index % candidates.Length]);
        }

        long before = GC.GetAllocatedBytesForCurrentThread();
        int accepted = 0;
        for (int index = 0; index < Repetitions; index++)
        {
            if (CanonicalGuid.IsCanonical(candidates[index % candidates.Length]))
            {
                accepted++;
            }
        }
        long allocated = GC.GetAllocatedBytesForCurrentThread() - before;
        Require(accepted == Repetitions / 2 && allocated == 0,
            "Canonical identity validation allocated or changed the accepted set.");
    }

    private static void CheckSignedProbeBoundary()
    {
        byte[] key = Enumerable.Repeat((byte)7, 32).ToArray();
        var tickets = new BattleTickets(Convert.ToBase64String(key));
        var claims = new TicketClaims
        {
            PlayerId = PlayerId, ServerId = "identity-fixture", SessionId = 1,
            Purpose = "connectivity-probe", IssuedUnixSeconds = 1000, ExpiresUnixSeconds = 1120
        };
        Require(tickets.Validate(tickets.Sign(claims), claims.ServerId, 1000)?.PlayerId == PlayerId,
            "The valid probe ticket changed its player identity.");
        foreach (string invalid in new[] { " " + PlayerId + " ", PlayerId.ToUpperInvariant(), PlayerId + "\n" })
        {
            claims.PlayerId = invalid;
            RequireInvalid(() => tickets.Sign(claims));
            // Trusted test signing proves the reader independently rejects correctly MACed malformed claims.
            byte[] payload = claims.ToByteArray();
            string forged = Convert.ToBase64String(payload) + "." +
                Convert.ToBase64String(HMACSHA256.HashData(key, payload));
            Require(tickets.Validate(forged, claims.ServerId, 1000) == null,
                "A correctly signed noncanonical probe identity was accepted.");
        }
    }

    private static void CheckSdkGrantBoundary()
    {
        var grant = new MatchConnectionGrant
        {
            PlayerId = PlayerId, Host = "127.0.0.1", Port = 30000, SessionId = 1,
            SessionKey = ByteString.CopyFrom(new byte[32]), Ticket = "shape-only-test-ticket",
            MatchId = "opaque-match-id", ManifestHash = new string('a', 64),
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 120
        };
        MatchConnection.ValidateGrantEnvelope(grant);
        foreach (string invalid in new[] { " " + PlayerId + " ", PlayerId.ToUpperInvariant(), PlayerId + "\t" })
        {
            grant.PlayerId = invalid;
            try
            {
                MatchConnection.ValidateGrantEnvelope(grant);
                throw new InvalidOperationException("SDK accepted a noncanonical player before socket creation.");
            }
            catch (ArgumentException)
            {
                // The envelope is refused before MatchConnection can create a socket.
            }
        }
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("A signer issued a noncanonical player identity.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

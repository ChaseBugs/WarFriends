using System.Security.Cryptography;
using System.Text;
using Google.Protobuf;
using War.BattleServer;
using War.Protocol;
using War.Shared;

namespace War.Battle.Tests.Identity;

/// <summary>Checks exact ownership before admission, signing, terminal acceptance and local mutation.</summary>
internal static class CanonicalIdentityTests
{
    private const string PlayerA = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PlayerB = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private static readonly string[] Aliases = [" " + PlayerA + " ", PlayerA.ToUpperInvariant(), PlayerA + "\t"];

    internal static int Run()
    {
        CheckDistinctManifestIdentity();
        CheckAllocationIdentity();
        CheckCoverOwnership();
        CheckMatchSigning();
        CheckTerminalIdentity();
        return 5;
    }

    private static void CheckDistinctManifestIdentity()
    {
        MatchManifest valid = CreateManifest();
        MatchManifest.Validate(valid);
        Require(valid.MatchId == "opaque-identity-match", "Match IDs acquired an unrelated GUID restriction.");
        foreach (string alias in Aliases)
        {
            var duplicate = valid with { Players = [valid.Players[0], valid.Players[1] with { PlayerId = alias }] };
            RequireInvalid(() => MatchManifest.Validate(duplicate));
            RequireInvalid(() => new MatchEngine(duplicate));
        }
        RequireInvalid(() => MatchManifest.Validate(valid with { Players = [valid.Players[0], valid.Players[0]] }));
    }

    private static void CheckAllocationIdentity()
    {
        var allocation = new BattleAllocationProjection(PlayerA, [], [], [], [], []);
        Require(BattleAllocationProjection.Validate(allocation).PlayerId == PlayerA,
            "A canonical allocation changed identity.");
        foreach (string alias in Aliases)
        {
            allocation.PlayerId = alias;
            RequireInvalid(() => BattleAllocationProjection.Validate(allocation));
            Require(allocation.PlayerId == alias, "Allocation validation silently repaired an alias.");
        }
    }

    private static void CheckCoverOwnership()
    {
        var covers = new CoverOccupancyRegistry(2);
        Require(covers.TryClaim(0, PlayerA), "The canonical owner could not claim a cover.");
        foreach (string alias in Aliases)
        {
            Require(!covers.TryClaim(1, alias) && !covers.Release(0, alias) && covers.ReleasePlayer(alias) == 0,
                "A GUID alias claimed or released canonical cover ownership.");
            Require(covers.Snapshot().SequenceEqual([(0, PlayerA)]), "Rejected alias changed cover authority.");
        }
        Require(covers.Release(0, PlayerA) && covers.Count == 0, "The original owner could not release its cover.");
    }

    private static void CheckMatchSigning()
    {
        MatchManifest manifest = CreateManifest();
        var match = new MatchEngine(manifest);
        byte[] key = Enumerable.Repeat((byte)9, 32).ToArray();
        var tokens = new MatchTokens(Convert.ToBase64String(key));
        var claims = new MatchAdmission
        {
            MatchId = manifest.MatchId, ManifestHash = manifest.Digest(), PlayerId = PlayerA,
            ServerId = manifest.ServerId, SessionId = 1, IssuedUnixSeconds = 1000, ExpiresUnixSeconds = 1120
        };
        Require(tokens.Validate(tokens.Sign(claims), match, manifest.ServerId, 1000)?.PlayerId == PlayerA,
            "The canonical admission ticket no longer matches its roster.");
        foreach (string alias in Aliases)
        {
            claims.PlayerId = alias;
            RequireInvalid(() => tokens.Sign(claims));
            RequireInvalid(() => tokens.SessionKey(claims));
            byte[] payload = claims.ToByteArray();
            byte[] domain = Encoding.UTF8.GetBytes("war/match/ticket/v1/");
            byte[] signed = domain.Concat(payload).ToArray();
            string forged = Convert.ToBase64String(payload) + "." +
                Convert.ToBase64String(HMACSHA256.HashData(key, signed));
            Require(tokens.Validate(forged, match, manifest.ServerId, 1000) == null,
                "A correctly MACed alias entered the canonical match roster.");
        }
    }

    private static void CheckTerminalIdentity()
    {
        MatchManifest manifest = CreateManifest();
        byte[] original = AtomicTerminalAcceptanceTests.FinishBattle(manifest);
        string digest = TerminalResultDigest.Compute(original);
        BattleTerminalEvidenceValidator.ValidatePayload(original, manifest.MatchId, digest);
        foreach (string alias in Aliases)
        {
            MatchSnapshot terminal = MatchSnapshot.Parser.ParseFrom(original);
            terminal.Players[0].PlayerId = alias;
            byte[] malformed = terminal.ToByteArray();
            RequireInvalid(() => BattleTerminalEvidenceValidator.ValidatePayload(
                malformed, manifest.MatchId, TerminalResultDigest.Compute(malformed)));
            RequireInvalid(() => BattleTerminalPolicy.Validate("forfeit", alias, true, false));
        }
        Require(BattleTerminalEvidenceValidator.ValidatePayload(original, manifest.MatchId, digest)
            .Players[0].PlayerId == PlayerA, "Negative terminal checks damaged the original proof.");
    }

    private static MatchManifest CreateManifest()
    {
        var weapon = new WeaponManifest("source-rifle", 10, 20, 0.1, 1);
        return new MatchManifest("opaque-identity-match", "local-1", "opaque-map", new string('a', 64),
            new string('b', 64), MatchManifest.PrototypeMode, 10, 60, 60,
            [new ParticipantManifest(PlayerA, weapon), new ParticipantManifest(PlayerB, weapon)]);
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
        throw new InvalidOperationException("A canonical-identity boundary accepted an alias.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

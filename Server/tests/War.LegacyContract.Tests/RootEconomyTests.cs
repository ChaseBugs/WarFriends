using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using War.Backend.Legacy;
using War.Backend.Legacy.Accounts;
using War.Persistence;
using War.Persistence.Legacy.State;
using War.LegacyContract.Tests.Recovered;

namespace War.LegacyContract.Tests;

/// <summary>
/// Checks durable integer representations, root domains and source placement startup policy in memory.
/// </summary>
internal static class RootEconomyTests
{
    private static readonly string[] Int64Fields = ["Gold", "WarBucks", "Tickets", "Scraps", "Experience"];
    private static readonly string[] Int32Fields =
    [
        "Level", "LevelExperience", "ArmyPower", "Reputation", "Skill", "MedalsBalance", "BeginnersLeague",
        "PlacementMatchesRequired", "SquadPoints", "RenameCount", "SquadCreationsCount", "BattlesLostInRow", "Position",
        "Status", "LastAction"
    ];

    internal static int Run()
    {
        CheckBsonRepresentations();
        CheckRequiredFields();
        CheckDomains();
        CheckBoundaries();
        CheckPlacementPolicy();
        return 5;
    }

    private static void CheckBsonRepresentations()
    {
        BsonValue[] invalid = [new BsonString("0"), new BsonDouble(0), new BsonDouble(0.5),
            new BsonDouble(double.NaN), new BsonDouble(double.PositiveInfinity), new BsonDecimal128(0),
            BsonBoolean.False, BsonNull.Value, new BsonArray()];
        foreach (string field in Int64Fields.Concat(Int32Fields))
        {
            foreach (BsonValue value in invalid)
            {
                BsonDocument input = new LegacyPlayerDocument().ToBsonDocument();
                input[field] = value;
                RejectBson(input);
            }
        }

        BsonDocument exact = new LegacyPlayerDocument().ToBsonDocument();
        exact["Gold"] = new BsonInt32(7);
        exact["Skill"] = new BsonInt64(int.MaxValue);
        LegacyPlayerDocument accepted = BsonSerializer.Deserialize<LegacyPlayerDocument>(exact);
        Require(accepted.Gold == 7 && accepted.Skill == int.MaxValue,
            "Exact integer width compatibility was replaced by numeric/string coercion.");
        exact["Skill"] = new BsonInt64((long)int.MaxValue + 1);
        RejectBson(exact);
    }

    private static void CheckRequiredFields()
    {
        foreach (string field in Int64Fields.Concat(Int32Fields))
        {
            BsonDocument input = new LegacyPlayerDocument().ToBsonDocument();
            input.Remove(field);
            RejectBson(input);
        }
    }

    private static void CheckDomains()
    {
        Action<LegacyPlayerDocument>[] damaged =
        [
            player => player.Gold = -1, player => player.WarBucks = -1, player => player.Tickets = -1,
            player => player.Scraps = -1, player => player.Experience = -1, player => player.Level = -1,
            player => player.Level = 43, player => player.LevelExperience = -1, player => player.ArmyPower = -1,
            player => player.ArmyPower = int.MaxValue / 10 + 1, player => player.Reputation = -1,
            player => player.Skill = -1, player => player.MedalsBalance = -1,
            player => player.BeginnersLeague = -1, player => player.BeginnersLeague = 4,
            player => player.PlacementMatchesRequired = -1, player => player.PlacementMatchesRequired = 2,
            player => player.SquadPoints = -1, player => player.RenameCount = -1,
            player => player.SquadCreationsCount = -1, player => player.BattlesLostInRow = -1,
            player => player.Position = -1, player => player.Status = 3, player => player.LastAction = -1,
            player => player.LeagueId = "17-local1",
            player => player.LeagueId = "01-local1", player => player.LeagueId = "1-local1\n"
        ];
        foreach (Action<LegacyPlayerDocument> damage in damaged)
        {
            var player = new LegacyPlayerDocument();
            damage(player);
            Reject(() => LegacyPlayerEconomyAuthority.Validate(player));
        }
    }

    private static void CheckBoundaries()
    {
        Require(RecoveredRootOracle.MaximumLeague == 16 &&
            RecoveredRootOracle.Scale(int.MaxValue / 10) > 0 &&
            RecoveredRootOracle.Scale(int.MaxValue / 10 + 1) < 0,
            "Reviewed Client enum/scaling boundary changed without a root-authority review.");
        var player = new LegacyPlayerDocument
        {
            Gold = long.MaxValue,
            WarBucks = long.MaxValue,
            Tickets = long.MaxValue,
            Scraps = long.MaxValue,
            Experience = long.MaxValue,
            Level = 42,
            LevelExperience = int.MaxValue,
            ArmyPower = int.MaxValue / 10,
            Skill = 7,
            MedalsBalance = 11,
            BeginnersLeague = 3,
            PlacementMatchesRequired = 1,
            LeagueId = "16-local1"
        };
        LegacyPlayerDocument clone = BsonSerializer.Deserialize<LegacyPlayerDocument>(player.ToBson());
        LegacyPlayerEconomyAuthority.Validate(clone);
        Require(clone.Gold == long.MaxValue && clone.Experience == long.MaxValue && clone.Skill != clone.MedalsBalance,
            "Valid Int64 endpoints or independent global/division medals were rounded or conflated.");
        player.Level = 0;
        player.BeginnersLeague = 0;
        player.PlacementMatchesRequired = 0;
        player.LeagueId = "";
        LegacyPlayerEconomyAuthority.Validate(player);
    }

    private static void CheckPlacementPolicy()
    {
        LegacyStarterState source = LegacyStarterState.FromCatalog(RecoveredCatalogFixture.Catalog);
        Require(source.PlacementMatchesRequired == 1, "Recovered one-match placement was replaced by a fixed ten.");
        LegacyStarterPolicy policy = LegacyStarterPolicy.FromOptions(source);
        Reject(() => (policy with { PlacementMatchesRequired = 10 }).Validate());
    }

    private static void RejectBson(BsonDocument input)
    {
        try
        {
            BsonSerializer.Deserialize<LegacyPlayerDocument>(input);
        }
        catch (Exception exception) when (exception is FormatException or BsonSerializationException)
        {
            return;
        }

        throw new InvalidOperationException("Lossy/missing BSON authority was accepted: " + input);
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

        throw new InvalidOperationException("Out-of-domain root economy authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

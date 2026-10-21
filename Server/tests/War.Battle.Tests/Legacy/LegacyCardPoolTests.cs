using System.Text.Json;
using War.Backend.Legacy;
using War.Backend.Legacy.Cards;
using War.Persistence;
using War.Persistence.Legacy.Cards;

namespace War.Battle.Tests.Legacy;

/// <summary>Documents source cooldown units, donor reputation, conserved counts and malformed input.</summary>
internal static class LegacyCardPoolTests
{
    internal const string CardId = "SLOWMOVE";
    internal const int Now = 1700000000;

    internal static void Run()
    {
        LegacyCardPoolPolicy policy = LoadPolicy();
        var rules = new LegacyCardPoolRules(policy);
        Require(policy.CooldownSeconds == 14400, "The source cooldown must convert 240 minutes to seconds.");
        Require(policy.Reputation(CardId) == 45, "Gold-card donation reputation must be 45.");
        LegacyCardPoolSnapshot snapshot = CreateSnapshot();
        LegacyCardPoolMutation result = rules.Calculate(snapshot, Withdrawal(snapshot), Now);
        Require(result.Result == 1 && result.NextWithdraw == Now + 14400, "Wrong withdrawal cooldown.");
        Require(result.DonorReputation == 45 && result.DonorDeposits!.Count == 0,
            "The donor must lose one card and receive reputation.");
        Require(ReadAmount(result.ActorCards!) == 1, "The receiver must gain exactly one card.");

        CheckTransferRejections(rules);
        CheckDeposits(rules);
        CheckDamagedInventory(rules);
        CheckParser();
        Console.WriteLine("PASS: card-pool rules, conservation, cooldown, reputation and strict parser scenarios");
    }

    internal static LegacyCardPoolPolicy LoadPolicy()
    {
        DirectoryInfo? directory = new(AppContext.BaseDirectory);
        while (directory != null)
        {
            string path = Path.Combine(directory.FullName, "content/recovered-battle-content.json");
            if (File.Exists(path))
            {
                return LegacyCardPoolPolicy.FromCatalog(LegacyCatalog.Load(path));
            }

            directory = directory.Parent;
        }

        throw new FileNotFoundException("Missing card-pool source catalog.");
    }

    internal static LegacyCardPoolSnapshot CreateSnapshot()
    {
        string squadId = Guid.NewGuid().ToString("N");
        var actor = new LegacyPlayerDocument { Id = Guid.NewGuid().ToString("N"), SquadId = squadId };
        var donor = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"),
            SquadId = squadId,
            DepositedCards = new() { [CardId] = 1 }
        };
        var squad = new LegacySquadDocument
        {
            Id = squadId,
            Members = [new() { PlayerId = actor.Id }, new() { PlayerId = donor.Id }]
        };
        return new LegacyCardPoolSnapshot(actor, donor, squad);
    }

    internal static LegacyCardPoolIntent Withdrawal(LegacyCardPoolSnapshot snapshot) =>
        new(new Dictionary<string, int>(), new Dictionary<string, int>(), CardId, snapshot.Donor!.Id);

    internal static int ReadAmount(string json) =>
        JsonSerializer.Deserialize<CardManagerData>(json)!.CardData.GetValueOrDefault(CardId)?.Amount ?? 0;

    internal static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private static void CheckTransferRejections(LegacyCardPoolRules rules)
    {
        LegacyCardPoolSnapshot snapshot = CreateSnapshot();
        LegacyCardPoolIntent intent = Withdrawal(snapshot);
        snapshot.Actor.Serialized["CardManagerData"] = PlayerState.Write(new CardManagerData
        {
            NextWithdraw = Now + 10
        });
        Require(rules.Calculate(snapshot, intent, Now).Result == 106, "Active cooldown must refuse withdrawal.");
        snapshot.Actor.Serialized.Clear();
        Require(rules.Calculate(snapshot with { Donor = snapshot.Actor }, intent, Now).Result == 11301,
            "Self-withdrawal must not farm reputation.");
        snapshot.Squad!.Members.RemoveAt(1);
        Require(rules.Calculate(snapshot, intent, Now).Result == 11301, "Missing roster proof must refuse.");
        snapshot.Squad.Members.Add(new LegacySquadMember { PlayerId = snapshot.Donor!.Id });
        snapshot.Donor.Reputation = int.MaxValue;
        Require(rules.Calculate(snapshot, intent, Now).Result == 11301, "Reputation overflow must refuse.");
        snapshot.Donor.Reputation = 0;
        Require(rules.Calculate(snapshot, intent, int.MaxValue).Result == 11301, "Cooldown overflow must refuse.");
        snapshot.Actor.Serialized["CardManagerData"] = PlayerState.Write(new CardManagerData
        {
            CardData = new() { [CardId] = new() { Amount = int.MaxValue } }
        });
        Require(rules.Calculate(snapshot, intent, Now).Result == 11301, "Inventory overflow must refuse.");
        Require(snapshot.Donor.DepositedCards[CardId] == 1, "Rejected calculations must not mutate stock.");
    }

    private static void CheckDeposits(LegacyCardPoolRules rules)
    {
        LegacyCardPoolSnapshot snapshot = CreateSnapshot();
        snapshot.Actor.SquadId = "";
        snapshot.Actor.Serialized["CardManagerData"] = PlayerState.Write(new CardManagerData
        {
            CardData = new() { [CardId] = new() { Amount = 2 } }
        });
        var deposit = new LegacyCardPoolIntent(new Dictionary<string, int> { [CardId] = 1 },
            new Dictionary<string, int>(), null, null);
        LegacyCardPoolMutation result = rules.Calculate(snapshot, deposit, Now);
        Require(result.Result == 1 && ReadAmount(result.ActorCards!) == 1 &&
            result.ActorDeposits![CardId] == 1, "Own deposit must conserve total cards even while squadless.");
        snapshot.Actor.DepositedCards[CardId] = int.MaxValue;
        Require(rules.Calculate(snapshot, deposit, Now).Result == 11301, "Deposit overflow must refuse.");
        Require(rules.Calculate(snapshot, deposit with { Removed = deposit.Added }, Now).Result == 11301,
            "Overlapping opposite deltas must refuse.");
        var returned = deposit with { Added = deposit.Removed, Removed = deposit.Added };
        snapshot.Actor.DepositedCards[CardId] = 1;
        result = rules.Calculate(snapshot, returned, Now);
        Require(result.Result == 1 && ReadAmount(result.ActorCards!) == 3 && result.ActorDeposits!.Count == 0,
            "Own un-deposit must restore inventory without donor reputation.");
    }

    private static void CheckParser()
    {
        string valid = "{\"SLOWMOVE\":\"{\\\"amount\\\":1}\"}";
        Require(LegacyCardPoolParser.ParseAmounts(valid)[CardId] == 1, "Valid source encoding must parse.");
        string[] malformed = ["[]", "null", "{\"SLOWMOVE\":1}",
            "{\"SLOWMOVE\":\"{\\\"amount\\\":0}\"}",
            "{\"SLOWMOVE\":\"{\\\"amount\\\":-1}\"}",
            "{\"SLOWMOVE\":\"{\\\"amount\\\":1.5}\"}",
            "{\"SLOWMOVE\":\"{\\\"amount\\\":2147483648}\"}",
            "{\"SLOWMOVE\":\"{\\\"amount\\\":1,\\\"amount\\\":2}\"}",
            "{\"SLOWMOVE\":\"{}\"}", valid[..^1] + ",\"SLOWMOVE\":\"{\\\"amount\\\":2}\"}"];
        foreach (string json in malformed)
        {
            bool hasRejected = false;
            try
            {
                LegacyCardPoolParser.ParseAmounts(json);
            }
            catch (JsonException)
            {
                hasRejected = true;
            }

            Require(hasRejected, "Malformed card amounts must reject the entire intent: " + json);
        }
    }

    private static void CheckDamagedInventory(LegacyCardPoolRules rules)
    {
        string[] damaged = ["null", "[]", "{\"cardData\":null}",
            "{\"cardData\":{\"SLOWMOVE\":{\"amount\":-1}}}",
            "{\"cardData\":{\"SLOWMOVE\":{\"amount\":\"1\"}}}",
            "{\"nextWithdraw\":0,\"nextWithdraw\":10}", "{\"unknown\":1}"];
        foreach (string json in damaged)
        {
            LegacyCardPoolSnapshot snapshot = CreateSnapshot();
            snapshot.Actor.Serialized["CardManagerData"] = json;
            bool hasRejected = false;
            try
            {
                rules.Calculate(snapshot, Withdrawal(snapshot), Now);
            }
            catch (Exception exception) when (exception is JsonException or InvalidDataException)
            {
                hasRejected = true;
            }

            Require(hasRejected && snapshot.Donor!.DepositedCards[CardId] == 1,
                "Damaged inventory must fail before ownership changes: " + json);
        }
    }
}

using System.Text.Json;
using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

/// <summary>Checks non-granting account inventory projection before automatic matchmaking is enabled.</summary>
internal static class BattleAllocationSourceTests
{
    internal static int Run()
    {
        LegacyPlayerDocument player = CreatePlayer();
        BattleAllocationProjection empty = BattleAllocationSource.Project(player);
        Require(empty.CardIds.Count == 0 && empty.BuddyCardIds.Count == 0 &&
            empty.NormalUpgradeIndexes.Count == 4, "Fresh source defaults did not project an empty card inventory.");
        var cards = new CardManagerData();
        foreach (var identity in WarCardSourceIdentityCatalog.All)
        {
            cards.CardData.Add(identity.SourceCardId, new SavedCardData { Amount = 1 });
        }

        string first = cards.CardData.Keys.Order(StringComparer.Ordinal).First();
        cards.CardData[first].Amount = int.MaxValue;
        player.Serialized["CardManagerData"] = PlayerState.Write(cards);
        string before = player.Serialized["CardManagerData"];
        BattleAllocationProjection full = BattleAllocationSource.Project(player);
        Require(full.CardIds.SequenceEqual(cards.CardData.Keys.Order(StringComparer.Ordinal)) &&
            full.CardCounts[0] == int.MaxValue && full.CardIds.Count == WarCardSourceIdentityCatalog.All.Count,
            "Account projection lost source card identity, order, or quantity.");
        Require(player.Serialized["CardManagerData"] == before, "Account projection mutated durable inventory.");
        cards.CardData[first].Amount = 0;
        player.Serialized["CardManagerData"] = PlayerState.Write(cards);
        Require(!BattleAllocationSource.Project(player).CardIds.Contains(first), "Zero ownership granted a card.");
        CheckMalformed(player, first);
        return 5;
    }

    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        var players = new LegacyPlayerStore(uri, databaseName);
        await players.Initialize(deadline.Token);
        LegacyPlayerDocument player = CreatePlayer();
        var cards = new CardManagerData();
        foreach (var identity in WarCardSourceIdentityCatalog.All)
        {
            cards.CardData.Add(identity.SourceCardId, new SavedCardData { Amount = 2 });
        }

        player.Serialized["CardManagerData"] = PlayerState.Write(cards);
        await players.Insert(player, LegacyPlayerStore.NewPassword(), deadline.Token);
        var source = new BattleAllocationSource(players);
        BattleAllocationProjection projected = await source.GetAsync(player.Id, deadline.Token);
        var allocations = new BattleAllocationStore(uri, databaseName);
        await allocations.Put(projected, deadline.Token);
        BattleAllocationProjection saved = await allocations.Get(player.Id, deadline.Token)
            ?? throw new InvalidDataException("Projected account allocation is absent.");
        Require(saved.CardIds.SequenceEqual(projected.CardIds) && saved.CardCounts.All(count => count == 2) &&
            saved.NormalUpgradeIndexes.SequenceEqual(projected.NormalUpgradeIndexes),
            "Durable account-to-allocation projection lost inventory or army lanes.");
        Console.WriteLine("PASS: Mongo account inventory projects into durable battle allocation without card grants");
    }

    private static LegacyPlayerDocument CreatePlayer()
    {
        return new LegacyPlayerDocument
        {
            Id = new string('e', 32), Name = "AllocationSource", Country = "US", Locale = "en", Level = 1,
            CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            SessionExpiresUtc = DateTime.UtcNow.AddHours(1),
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
    }

    private static void CheckMalformed(LegacyPlayerDocument player, string identity)
    {
        string[] invalidStates =
        [
            "null", "[]", " ", "{\"cardData\":null}", "{\"cardData\":[]}",
            "{\"cardData\":{},\"cardData\":{}}", "{\"unexpected\":0}",
            "{\"extraSlot\":1}", "{\"nextWithdraw\":-1}", "{\"buddyCardData\":null}",
            "{\"buddyCardData\":{\"buddy\":{\"amount\":0}}}",
            "{\"buddyCardData\":{\"buddy\":{\"amount\":1}}}",
            "{\"cardData\":{\"UNKNOWN\":{\"amount\":0}}}"
        ];
        foreach (string json in invalidStates)
        {
            Reject(player, json);
        }

        foreach (string amount in new[] { "-1", "2147483648", "1.5", "true", "null", "\"1\"", "1e0" })
        {
            Reject(player, "{\"cardData\":{" + JsonSerializer.Serialize(identity) + ":{\"amount\":" + amount + "}}}");
        }

        string key = JsonSerializer.Serialize(identity);
        Reject(player, "{\"cardData\":{" + key + ":{\"amount\":1}," + key + ":{\"amount\":2}}}");
        Reject(player, new string(' ', 65536) + "{\"cardData\":{}}");
    }

    private static void Reject(LegacyPlayerDocument player, string json)
    {
        player.Serialized["CardManagerData"] = json;
        try
        {
            BattleAllocationSource.Project(player);
        }
        catch (InvalidDataException)
        {
            Require(player.Serialized["CardManagerData"] == json, "Rejected inventory was rewritten.");
            return;
        }

        throw new InvalidOperationException("Malformed or unsupported account inventory was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

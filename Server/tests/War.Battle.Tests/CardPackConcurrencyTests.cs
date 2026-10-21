using System.Globalization;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging.Abstractions;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using MongoDB.Driver;
using War.Battle.Tests.Support;

/// <summary>Runs competing source-priced card-pack buffers against one durable wallet.</summary>
internal static class CardPackConcurrencyTests
{
    private const int CardsPerPack = 3;

    internal static async Task RunAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        var catalog = LegacyCatalog.Load(FindContent());
        long price = catalog.Row("Google2u.CardPacks", "NAME", "THREE_CARDS")!["WARBUCKS"]!.Value.GetValue<long>();
        IMongoDatabase database = new MongoClient(uri).GetDatabase(databaseName);
        var players = new LegacyPlayerStore(database);
        string identity = Guid.NewGuid().ToString("N");
        await LegacyTestAccounts.InsertAsync(uri, databaseName, new LegacyPlayerDocument
        {
            Id = identity, Name = "PackRace", Level = 1, WarBucks = price, CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken())
        }, deadline.Token);
        var receipts = new LegacyBufferStore(uri, databaseName);
        await receipts.Initialize(deadline.Token);
        var processor = new LegacyBufferProcessor(receipts, catalog,
            NullLogger<LegacyBufferProcessor>.Instance);
        var first = await players.ById(identity, deadline.Token)
            ?? throw new InvalidDataException("Missing pack account.");
        var second = await players.ById(identity, deadline.Token)
            ?? throw new InvalidDataException("Missing pack account.");
        ParsedBuffer[] buffers = [CreateBuffer(), CreateBuffer()];
        JsonArray[] results = await Task.WhenAll(ApplyAsync(processor, first, buffers[0], deadline.Token),
            ApplyAsync(processor, second, buffers[1], deadline.Token));
        Require(results.Count(result => result[0]!["Result"]!.GetValue<int>() == (int)DatabaseResult.Success) == 1 &&
            results.Count(result => result[0]!["Result"]!.GetValue<int>() ==
                (int)DatabaseResult.NotEnoughWarbucks) == 1, "Competing buffers spent the same pack budget twice.");
        var saved = await players.ById(identity, deadline.Token)
            ?? throw new InvalidDataException("Missing pack account.");
        Require(saved.WarBucks == 0 && OrdinaryCardInventory.Read(saved.Serialized["CardManagerData"])
            .Values.Sum() == CardsPerPack, "Card-pack inventory and wallet debit did not conserve one purchase.");
        int winner = results[0][0]!["Result"]!.GetValue<int>() == (int)DatabaseResult.Success ? 0 : 1;
        await ApplyAsync(processor, saved, buffers[winner], deadline.Token);
        var replayed = await players.ById(identity, deadline.Token);
        Require(replayed!.WarBucks == 0 && OrdinaryCardInventory.Read(replayed.Serialized["CardManagerData"])
            .Values.Sum() == CardsPerPack, "Successful pack-buffer replay charged or granted twice.");
        JsonArray refusedReplay = await ApplyAsync(processor, replayed, buffers[1 - winner], deadline.Token);
        Require(refusedReplay[0]!["WarBucks"]!.GetValue<long>() == 0 &&
            OrdinaryCardInventory.Read(refusedReplay[0]!["CardManagerData"]!.GetValue<string>())
                .Values.Sum() == CardsPerPack, "Failed pack replay omitted the recovered Client's rollback fields.");
        await CheckOverflowAsync(database, processor, price, deadline.Token);
        await CheckBothAffordableAsync(database, processor, price, deadline.Token);
        Console.WriteLine("PASS: competing card-pack buffers conserve one wallet debit and one three-card grant");
    }

    private static async Task CheckOverflowAsync(IMongoDatabase database, LegacyBufferProcessor processor,
        long price, CancellationToken cancellationToken)
    {
        var players = new LegacyPlayerStore(database);
        var cards = new CardManagerData
        {
            CardData = OrdinaryCardIdentityCatalog.All.ToDictionary(identity => identity,
                _ => new SavedCardData { Amount = int.MaxValue }, StringComparer.Ordinal)
        };
        string inventory = PlayerState.Write(cards);
        var account = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "PackCapacity", Level = 1, WarBucks = price,
            CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            Serialized = new Dictionary<string, string> { ["CardManagerData"] = inventory }
        };
        await LegacyTestAccounts.InsertAsync(database, account, cancellationToken);
        JsonArray result = await ApplyAsync(processor, account, CreateBuffer(), cancellationToken);
        Require(result[0]!["Result"]!.GetValue<int>() == (int)DatabaseResult.CardPackNotFound,
            "An unrepresentable card-pack reward was accepted.");
        var saved = await players.ById(account.Id, cancellationToken);
        Require(saved!.WarBucks == price && saved.Serialized["CardManagerData"] == inventory,
            "Rejected card overflow charged the wallet or changed inventory.");
    }

    private static async Task CheckBothAffordableAsync(IMongoDatabase database, LegacyBufferProcessor processor,
        long price, CancellationToken cancellationToken)
    {
        var account = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "TwoPacks", Level = 1, WarBucks = checked(price * 2),
            CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken())
        };
        await LegacyTestAccounts.InsertAsync(database, account, cancellationToken);
        var players = new LegacyPlayerStore(database);
        var first = await players.ById(account.Id, cancellationToken);
        var second = await players.ById(account.Id, cancellationToken);
        JsonArray[] results = await Task.WhenAll(ApplyAsync(processor, first!, CreateBuffer(), cancellationToken),
            ApplyAsync(processor, second!, CreateBuffer(), cancellationToken));
        Require(results.All(result => result[0]!["Result"]!.GetValue<int>() == (int)DatabaseResult.Success),
            "A refreshed affordable pack request was incorrectly rejected after a conflict.");
        var saved = await players.ById(account.Id, cancellationToken);
        Require(saved!.WarBucks == 0 && OrdinaryCardInventory.Read(saved.Serialized["CardManagerData"])
            .Values.Sum() == CardsPerPack * 2, "Two affordable purchases lost a grant or wallet debit.");
    }

    private static async Task<JsonArray> ApplyAsync(LegacyBufferProcessor processor,
        LegacyPlayerDocument player, ParsedBuffer buffer, CancellationToken cancellationToken)
    {
        AppliedLegacyBuffer applied = await processor.ApplyAsync(player, buffer, cancellationToken);
        return applied.Results;
    }

    private static ParsedBuffer CreateBuffer()
    {
        return new ParsedBuffer(Guid.NewGuid().ToString("N"),
            [new BufferedRequest(0, DatabaseAction.BuyCardPack, "{\"cardPack\":\"THREE_CARDS\"}")]);
    }

    private static string FindContent()
    {
        DirectoryInfo? directory = new(AppContext.BaseDirectory);
        while (directory != null)
        {
            string path = Path.Combine(directory.FullName, "content/recovered-battle-content.json");
            if (File.Exists(path))
            {
                return path;
            }

            directory = directory.Parent;
        }

        throw new FileNotFoundException("Recovered pack catalog is absent.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

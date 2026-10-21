using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Logging.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Battle.Tests.Support;
using War.Protocol;
using War.Shared;

/// <summary>Checks atomic ordinary-card debit, result publication, pair release, and exact replay.</summary>
internal static class AtomicCardConsumptionTests
{
    private const string SourceCard = "SLOWMOVE";
    private const int StartingCopies = 3;

    internal static async Task RunAsync(string uri, string databaseName, CancellationToken cancellationToken)
    {
        IMongoDatabase database = new MongoClient(uri).GetDatabase(databaseName);
        var queue = new BattleMatchQueueStore(uri, databaseName);
        var results = new BattleResultStore(uri, databaseName);
        var players = new LegacyPlayerStore(uri, databaseName);
        var stores = new Stores(database, queue, results, players);
        Fixture fixture = await CreateFixtureAsync(queue, cancellationToken);
        await SaveFixtureAsync(database, fixture, cancellationToken);
        using var changes = await database.WatchAsync(
            new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>(),
            new ChangeStreamOptions { MaxAwaitTime = TimeSpan.FromSeconds(1) }, cancellationToken);
        Require(await results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
            fixture.Payload, cancellationToken) == "accepted", "Card-consuming result was not accepted.");
        await CheckTransactionAsync(changes, cancellationToken);
        var replay = await Task.WhenAll(
            results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
                fixture.Payload, cancellationToken),
            results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
                fixture.Payload, cancellationToken));
        Require(replay.All(code => code == "already-accepted"), "Concurrent card-result replay was not stable.");
        await CheckCountsAsync(database, fixture, StartingCopies - 1, cancellationToken);
        await CheckRollbackAsync(stores, cancellationToken);
        await CheckLastCopyAsync(stores, cancellationToken);
        await CheckMissingAllocationAsync(stores, cancellationToken);
        await CheckStaleSubsystemWriteAsync(stores, cancellationToken);
        Console.WriteLine("PASS: card debits/result/pair release share one transaction; " +
            "replay, rollback, and frozen-ownership rejection are safe");
    }

    private static async Task<Fixture> CreateFixtureAsync(BattleMatchQueueStore queue,
        CancellationToken cancellationToken)
    {
        MatchManifest pair = await AtomicTerminalAcceptanceTests.CreatePairAsync(queue, cancellationToken);
        var manifest = pair with
        {
            Allocations = pair.Players.Select(player => new BattleAllocationProjection(player.PlayerId,
                [SourceCard], [], [], [], []) { CardCounts = [StartingCopies] }).ToArray()
        };
        return FinishBattle(manifest, manifest.Allocations);
    }

    private static Fixture FinishBattle(MatchManifest manifest, BattleAllocationProjection[] allocations)
    {
        var host = new MatchEngine(manifest);
        host.ConfigureBattleAllocations(allocations);
        foreach (ParticipantManifest player in manifest.Players)
        {
            host.Admit(player.PlayerId);
            var hand = new SelectCardsCommand();
            hand.CardIds.Add(SourceCard);
            Require(host.Command(player.PlayerId, new MatchCommand { CommandId = 1, SelectCards = hand }).Code ==
                "cards-selected", "Card-debit fixture selection failed.");
            host.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 2, Ready = new ReadyCommand { ManifestHash = host.ManifestHash }
            });
        }

        host.Advance(2 * MatchManifest.TickRate);
        foreach (ParticipantManifest player in manifest.Players)
        {
            Require(host.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 3, UseSlowMove = new UseSlowMoveCommand { RequestId = Guid.NewGuid().ToString("N") }
            }).Code == "slow-move-active", "A selected source card did not activate through the real host command.");
        }

        host.Command(manifest.Players[0].PlayerId, new MatchCommand { CommandId = 4, Forfeit = new ForfeitCommand() });
        byte[] payload = host.TerminalEvidenceSnapshot().ToByteArray();
        return new Fixture(manifest, payload, TerminalResultDigest.Compute(payload));
    }

    private static async Task SaveFixtureAsync(IMongoDatabase database,
        Fixture fixture, CancellationToken cancellationToken)
    {
        foreach (ParticipantManifest player in fixture.Manifest.Players)
        {
            await LegacyTestAccounts.InsertAsync(database, new LegacyPlayerDocument
            {
                Id = player.PlayerId, Name = "CardDebit", CreatedUtc = DateTime.UtcNow,
                Serialized = new Dictionary<string, string> { ["CardManagerData"] = CardState(StartingCopies) }
            }, cancellationToken);
        }

        byte[] manifestBytes = JsonSerializer.SerializeToUtf8Bytes(fixture.Manifest);
        await database.GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots").InsertOneAsync(
            new BattleManifestSnapshotDocument
            {
                Id = fixture.Manifest.MatchId,
                Players = fixture.Manifest.Players.Select(player => player.PlayerId).ToArray(),
                Manifest = manifestBytes,
                Sha256 = Convert.ToHexStringLower(SHA256.HashData(manifestBytes)),
                CreatedUtc = DateTime.UtcNow
            }, cancellationToken: cancellationToken);
    }

    private static async Task CheckRollbackAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await CreateFixtureAsync(stores.Queue, cancellationToken);
        await SaveFixtureAsync(stores.Database, fixture, cancellationToken);
        string damagedPlayer = fixture.Manifest.Players[1].PlayerId;
        await LegacyTestAccounts.SetCardsForTestAsync(stores.Database, damagedPlayer, CardState(0), cancellationToken);
        try
        {
            await stores.Results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
                fixture.Payload, cancellationToken);
            throw new InvalidOperationException("Insufficient durable inventory was accepted.");
        }
        catch (InvalidDataException)
        {
            // The same terminal payload must remain retryable after explicit test repair of the damaged authority.
        }

        Require(await stores.Results.Get(fixture.Manifest.MatchId, cancellationToken) == null &&
            await stores.Queue.ForMatch(fixture.Manifest.MatchId, cancellationToken) != null,
            "Rejected consumption published a result or released its pair.");
        var first = await stores.Players.ById(fixture.Manifest.Players[0].PlayerId, cancellationToken);
        Require(OrdinaryCardInventory.Read(first!.Serialized["CardManagerData"])[SourceCard] == StartingCopies,
            "One player's inventory changed when the other player could not pay.");
        await LegacyTestAccounts.SetCardsForTestAsync(stores.Database, damagedPlayer,
            CardState(StartingCopies), cancellationToken);
        Require(await stores.Results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
            fixture.Payload, cancellationToken) == "accepted", "Rolled-back terminal proof could not retry.");
        await CheckCountsAsync(stores.Database, fixture, StartingCopies - 1, cancellationToken);
    }

    private static async Task CheckMissingAllocationAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture original = await CreateFixtureAsync(stores.Queue, cancellationToken);
        Fixture fixture = FinishBattle(original.Manifest with { Allocations = null }, original.Manifest.Allocations!);
        await SaveFixtureAsync(stores.Database, fixture, cancellationToken);
        try
        {
            await stores.Results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
                fixture.Payload, cancellationToken);
            throw new InvalidOperationException("Card settlement accepted an unfrozen inventory allocation.");
        }
        catch (InvalidDataException exception) when
            (exception.Message == "Confirmed card use has no frozen inventory allocation.")
        {
            // A locally configured inventory is not Backend admission evidence.
        }

        Require(await stores.Results.Get(fixture.Manifest.MatchId, cancellationToken) == null &&
            await stores.Queue.ForMatch(fixture.Manifest.MatchId, cancellationToken) != null,
            "Missing ownership proof changed result or pair authority.");
        await CheckCountsAsync(stores.Database, fixture, StartingCopies, cancellationToken);
    }

    private static async Task CheckLastCopyAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await CreateFixtureAsync(stores.Queue, cancellationToken);
        await SaveFixtureAsync(stores.Database, fixture, cancellationToken);
        foreach (ParticipantManifest player in fixture.Manifest.Players)
        {
            await LegacyTestAccounts.SetCardsForTestAsync(
                stores.Database, player.PlayerId, CardState(1), cancellationToken);
        }

        Require(await stores.Results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
            fixture.Payload, cancellationToken) == "accepted", "The final owned card could not be consumed.");
        await CheckCountsAsync(stores.Database, fixture, 0, cancellationToken);
    }

    private static async Task CheckStaleSubsystemWriteAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await CreateFixtureAsync(stores.Queue, cancellationToken);
        await SaveFixtureAsync(stores.Database, fixture, cancellationToken);
        string identity = fixture.Manifest.Players[0].PlayerId;
        var stale = await stores.Players.ById(identity, cancellationToken)
            ?? throw new InvalidDataException("Subsystem concurrency fixture account is absent.");
        await stores.Results.AcceptAndReleasePairAsync(fixture.Manifest.MatchId, fixture.Digest,
            fixture.Payload, cancellationToken);
        var receipts = new LegacyBufferStore(stores.Database);
        await receipts.Initialize(cancellationToken);
        var processor = new LegacyBufferProcessor(receipts, LegacyCatalog.Empty,
            NullLogger<LegacyBufferProcessor>.Instance);
        var buffer = new ParsedBuffer("after-battle-debit",
            [new BufferedRequest(0, DatabaseAction.BuyCardPack, "{\"cardPack\":\"THREE_CARDS\"}")]);
        AppliedLegacyBuffer refused = await processor.ApplyAsync(stale, buffer, cancellationToken);
        string rollback = refused.Results[0]!["CardManagerData"]!.GetValue<string>();
        Require(refused.Results[0]!["Result"]!.GetValue<int>() == (int)DatabaseResult.CardPackNotFound &&
            OrdinaryCardInventory.Read(rollback)[SourceCard] == StartingCopies - 1,
            "A buffered purchase replayed stale inventory over a committed battle debit.");
        var proposed = new Dictionary<string, string>
        {
            ["CardManagerData"] = CardState(StartingCopies + 1),
            ["CraftData"] = PlayerState.Write(new CraftData())
        };
        Require(!await stores.Players.TryReplaceSubsystemsAsync(stale, proposed, cancellationToken),
            "An earlier-read subsystem blob overwrote the committed battle debit.");
        await CheckCountsAsync(stores.Database, fixture, StartingCopies - 1, cancellationToken);
        var current = await stores.Players.ById(identity, cancellationToken)
            ?? throw new InvalidDataException("Subsystem concurrency fixture account disappeared.");
        Require(!current.Serialized.ContainsKey("CraftData"), "A rejected write published its companion subsystem.");
        proposed["CardManagerData"] = CardState(StartingCopies);
        bool[] writes = await Task.WhenAll(
            stores.Players.TryReplaceSubsystemsAsync(current, proposed, cancellationToken),
            stores.Players.TryReplaceSubsystemsAsync(current, proposed, cancellationToken));
        Require(writes.Count(committed => committed) == 1,
            "Two writers committed from the same subsystem snapshot.");
        var final = await stores.Players.ById(identity, cancellationToken);
        Require(OrdinaryCardInventory.Read(final!.Serialized["CardManagerData"])[SourceCard] == StartingCopies &&
            final.Serialized.ContainsKey("CraftData"), "Conditional subsystem update lost its combined publication.");
        Console.WriteLine("PASS: stale card subsystem writes cannot overwrite battle debits; one concurrent writer wins");
    }

    private static async Task CheckCountsAsync(IMongoDatabase database, Fixture fixture, int expected,
        CancellationToken cancellationToken)
    {
        foreach (ParticipantManifest player in fixture.Manifest.Players)
        {
            var account = await database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
                .Find(row => row.Id == player.PlayerId).SingleAsync(cancellationToken);
            string json = account.Serialized["CardManagerData"];
            OrdinaryCardInventory.Read(json);
            using JsonDocument document = JsonDocument.Parse(json);
            Require(document.RootElement.GetProperty("cardData").GetProperty(SourceCard)
                .GetProperty("amount").GetInt32() == expected,
                "A consuming account was charged more or less than one source card.");
        }
    }

    private static async Task CheckTransactionAsync(IChangeStreamCursor<ChangeStreamDocument<BsonDocument>> changes,
        CancellationToken cancellationToken)
    {
        var writes = new List<BsonDocument>();
        while (writes.Count < 4 && await changes.MoveNextAsync(cancellationToken))
        {
            writes.AddRange(changes.Current.Select(change => change.BackingDocument));
        }

        Require(writes.Count == 4 && writes.All(write => write.Contains("txnNumber")) &&
            writes.Count(write => write["ns"]["coll"] == "legacyPlayers" && write["operationType"] == "update") == 2 &&
            writes.Count(write => write["ns"]["coll"] == "battle_results" && write["operationType"] == "insert") == 1 &&
            writes.Count(write => write["ns"]["coll"] == "battle_pairs" && write["operationType"] == "delete") == 1 &&
            writes.All(write => write["txnNumber"] == writes[0]["txnNumber"] && write["lsid"] == writes[0]["lsid"]),
            "Both card debits, result insertion, and pair release did not share one Mongo transaction.");
    }

    private static string CardState(int amount)
    {
        return JsonSerializer.Serialize(new { cardData = new Dictionary<string, object>
            { [SourceCard] = new { amount } }, buddyCardData = new { }, extraSlot = false });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed record Fixture(MatchManifest Manifest, byte[] Payload, string Digest);

    private sealed record Stores(IMongoDatabase Database, BattleMatchQueueStore Queue,
        BattleResultStore Results, LegacyPlayerStore Players);
}

using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Persistence;
using War.Battle.Tests.Support;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy;

/// <summary>Checks real Mongo transactions, competing wallets, replay identity and failed publication.</summary>
internal static class LegacyBufferTransactionTests
{
    private const int PurchasePrice = 10;
    private const int DeadlineSeconds = 120;

    internal static async Task RunAsync(string uri)
    {
        var client = new MongoClient(uri);
        string databaseName = "war_buffer_transactions_" + Guid.NewGuid().ToString("N");
        IMongoDatabase database = client.GetDatabase(databaseName);
        var context = new TestContext(database);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(DeadlineSeconds));
        try
        {
            await context.Players.Initialize(deadline.Token);
            await context.Buffers.Initialize(deadline.Token);
            await CheckCompetingPurchasesAsync(context, deadline.Token);
            await CheckSameRequestReplayAsync(context, deadline.Token);
            await CheckFailedResponseReplayAsync(context, deadline.Token);
            await CheckAlteredRequestAsync(context, deadline.Token);
            await CheckReceiptFailureRollbackAsync(context, deadline.Token);
            await CheckHistoricalReceiptsAsync(context, deadline.Token);
            await CheckNoReceiptExpiryAsync(context, deadline.Token);
            await CheckCommittedPlayerAsync(context, deadline.Token);
            Console.WriteLine("PASS: 8 buffered transaction, replay, crash-boundary and projection scenarios");
        }
        finally
        {
            await client.DropDatabaseAsync(databaseName, CancellationToken.None);
        }
    }

    private static async Task CheckCompetingPurchasesAsync(TestContext context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.CreatePlayerAsync(PurchasePrice, cancellationToken);
        LegacyBufferedAction first = CreateAction(player.Id, "first");
        LegacyBufferedAction second = CreateAction(player.Id, "second");
        using var firstReads = new Barrier(2);
        int calculations = 0;

        LegacyBufferedMutation Calculate(LegacyPlayerDocument snapshot, LegacyBufferedAction request)
        {
            // Both first attempts must read the original wallet before either is allowed to write.
            if (Interlocked.Increment(ref calculations) <= 2)
            {
                bool hasBothReaders = firstReads.SignalAndWait(TimeSpan.FromSeconds(5), cancellationToken);
                Require(hasBothReaders, "Competing purchase setup did not reach both transaction reads.");
            }

            return CalculatePurchase(snapshot, request);
        }

        LegacyBufferedActionResult[] results = await Task.WhenAll(
            Task.Run(() => context.Buffers.ExecuteAsync(first,
                snapshot => Calculate(snapshot, first), cancellationToken), cancellationToken),
            Task.Run(() => context.Buffers.ExecuteAsync(second,
                snapshot => Calculate(snapshot, second), cancellationToken), cancellationToken));

        Require(calculations >= 3, "A conflicting transaction did not recalculate against the winner's commit.");
        Require(results.Count(result => ResultCode(result) == (int)DatabaseResult.Success) == 1,
            "Competing purchases did not produce exactly one successful grant.");
        Require(results.Count(result => ResultCode(result) == (int)DatabaseResult.NotEnoughWarbucks) == 1,
            "The losing purchase did not retain its insufficient-funds response.");
        LegacyPlayerDocument saved = await context.ReadPlayerAsync(player.Id, cancellationToken);
        Require(saved.WarBucks == 0 && saved.Serialized.Count == 2,
            "Wallet debit and both related inventory blobs were not conserved together.");
        Require(saved.Serialized["InventoryData"] == saved.Serialized["LevelManagerData"],
            "One purchase's inventory was mixed with a different purchase's level state.");
    }

    private static async Task CheckSameRequestReplayAsync(TestContext context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.CreatePlayerAsync(PurchasePrice, cancellationToken);
        LegacyBufferedAction request = CreateAction(player.Id, "same");

        LegacyBufferedActionResult[] replies = await Task.WhenAll(
            PurchaseAsync(context, request, cancellationToken), PurchaseAsync(context, request, cancellationToken));

        Require(replies[0].ResponseJson == replies[1].ResponseJson && ResultCode(replies[0]) == 1,
            "Concurrent delivery did not return the same committed response.");
        LegacyPlayerDocument saved = await context.ReadPlayerAsync(player.Id, cancellationToken);
        LegacyBufferReceipt receipt = await context.Buffers.Find(player.Id, request.BufferId, cancellationToken)
            ?? throw new InvalidDataException("Missing completed receipt.");
        Require(saved.WarBucks == 0 && saved.Revision == player.Revision + 1 && receipt.Entries.Count == 1,
            "Concurrent delivery charged twice or created duplicate receipt entries.");
        var restartedStore = new LegacyBufferStore(context.Database);
        LegacyBufferedActionResult recovered = await restartedStore.ExecuteAsync(request,
            _ => throw new InvalidOperationException("Committed request executed again after reply loss."),
            cancellationToken);
        Require(recovered.ResponseJson == replies[0].ResponseJson,
            "A restarted service could not recover the exact committed reply.");
    }

    private static async Task CheckFailedResponseReplayAsync(TestContext context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.CreatePlayerAsync(0, cancellationToken);
        LegacyBufferedAction request = CreateAction(player.Id, "refused");
        LegacyBufferedActionResult refused = await PurchaseAsync(context, request, cancellationToken);
        await LegacyTestAccounts.UpdateForTestAsync(context.Database, player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.WarBucks, PurchasePrice), cancellationToken);

        LegacyBufferedActionResult replay = await PurchaseAsync(context, request, cancellationToken);

        Require(replay.ResponseJson == refused.ResponseJson && ResultCode(replay) == 100,
            "A failed receipt was recalculated against a later wallet or lost its rollback fields.");
        Require(replay.Player.WarBucks == PurchasePrice && replay.Player.Serialized.Count == 0,
            "Replaying a failed request granted an item after the account gained funds.");
    }

    private static async Task CheckAlteredRequestAsync(TestContext context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.CreatePlayerAsync(PurchasePrice, cancellationToken);
        LegacyBufferedAction request = CreateAction(player.Id, "bound");
        await PurchaseAsync(context, request, cancellationToken);
        LegacyBufferedAction changedPayload = request with { PayloadDigest = new string('a', 64) };
        LegacyBufferedAction changedAction = request with { ActionId = (int)DatabaseAction.BuyUnit };

        LegacyBufferedActionResult payloadReply = await PurchaseAsync(context, changedPayload, cancellationToken);
        LegacyBufferedActionResult actionReply = await PurchaseAsync(context, changedAction, cancellationToken);

        Require(payloadReply.ResponseJson == null && actionReply.ResponseJson == null,
            "An altered payload or action borrowed another request's success receipt.");
        Require(actionReply.Player.Revision == player.Revision + 1 && actionReply.Player.WarBucks == 0,
            "A conflicting retry changed durable state.");
    }

    private static async Task CheckReceiptFailureRollbackAsync(TestContext context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.CreatePlayerAsync(PurchasePrice, cancellationToken);
        LegacyBufferedAction request = CreateAction(player.Id, "publication-fault");
        var rejectEntries = new BsonDocument("Entries.0", new BsonDocument("$exists", false));
        await SetReceiptValidatorAsync(context.Database, rejectEntries, cancellationToken);
        bool hasRejectedReceipt = false;
        try
        {
            await PurchaseAsync(context, request, cancellationToken);
        }
        catch (MongoWriteException exception) when (exception.WriteError.Code == 121)
        {
            hasRejectedReceipt = true;
        }
        finally
        {
            await SetReceiptValidatorAsync(context.Database, new BsonDocument(), cancellationToken);
        }

        LegacyPlayerDocument saved = await context.ReadPlayerAsync(player.Id, cancellationToken);
        LegacyBufferReceipt? receipt = await context.Buffers.Find(player.Id, request.BufferId, cancellationToken);
        Require(hasRejectedReceipt && saved.WarBucks == PurchasePrice && saved.Revision == player.Revision &&
            saved.Serialized.Count == 0 && receipt == null,
            "Receipt failure after the account write left an item, debit or stranded claim behind.");
        LegacyBufferedActionResult retry = await PurchaseAsync(context, request, cancellationToken);
        Require(ResultCode(retry) == 1 && retry.Player.WarBucks == 0,
            "The rolled-back request could not be retried exactly once.");
    }

    private static async Task CheckHistoricalReceiptsAsync(TestContext context, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument player = await context.CreatePlayerAsync(PurchasePrice, cancellationToken);
        foreach (int? historicalResult in new int?[] { null, 1 })
        {
            LegacyBufferedAction request = CreateAction(player.Id, Guid.NewGuid().ToString("N"));
            var receipt = new LegacyBufferReceipt
            {
                Id = player.Id + ":" + request.BufferId,
                PlayerId = player.Id,
                BufferId = request.BufferId,
                CreatedUtc = DateTime.UtcNow,
                Entries = [new LegacyBufferEntry { Index = 0, ActionId = request.ActionId, Result = historicalResult }]
            };
            await context.Receipts.InsertOneAsync(receipt, cancellationToken: cancellationToken);

            LegacyBufferedActionResult replay = await PurchaseAsync(context, request, cancellationToken);

            Require(replay.ResponseJson == null && replay.Player.WarBucks == PurchasePrice &&
                replay.Player.Revision == player.Revision, "An unbound historical receipt reopened a purchase.");
        }
    }

    private static async Task CheckNoReceiptExpiryAsync(TestContext context, CancellationToken cancellationToken)
    {
        var oldIndex = new CreateIndexModel<LegacyBufferReceipt>(
            Builders<LegacyBufferReceipt>.IndexKeys.Ascending(row => row.CreatedUtc),
            new CreateIndexOptions { Name = "old_buffer_expiry", ExpireAfter = TimeSpan.FromDays(30) });
        await context.Receipts.Indexes.CreateOneAsync(oldIndex, cancellationToken: cancellationToken);

        await context.Buffers.Initialize(cancellationToken);

        using IAsyncCursor<BsonDocument> cursor = await context.Receipts.Indexes.ListAsync(cancellationToken);
        List<BsonDocument> indexes = await cursor.ToListAsync(cancellationToken);
        Require(indexes.All(index => !index.Contains("expireAfterSeconds")),
            "Receipt expiry can reopen a request that the Client retained across restarts.");
        LegacyPlayerDocument player = await context.CreatePlayerAsync(PurchasePrice, cancellationToken);
        LegacyBufferedAction request = CreateAction(player.Id, "retained");
        LegacyBufferedActionResult original = await PurchaseAsync(context, request, cancellationToken);
        await context.Receipts.UpdateOneAsync(row => row.Id == player.Id + ":" + request.BufferId,
            Builders<LegacyBufferReceipt>.Update.Set(row => row.CreatedUtc, DateTime.UtcNow.AddDays(-90)),
            cancellationToken: cancellationToken);
        LegacyBufferedActionResult replay = await PurchaseAsync(context, request, cancellationToken);
        Require(replay.ResponseJson == original.ResponseJson && replay.Player.Revision == player.Revision + 1,
            "An old receipt was treated as expired or its action was re-applied.");
        await LegacyTestAccounts.UpdateForTestAsync(context.Database, player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.WarBucks, PurchasePrice), cancellationToken);
        LegacyBufferedActionResult fresh = await PurchaseAsync(context,
            CreateAction(player.Id, "fresh-after-old-replay"), cancellationToken);
        Require(ResultCode(fresh) == (int)DatabaseResult.Success,
            "The old replay fence incorrectly rejected a new legitimate buffer.");
    }

    private static async Task CheckCommittedPlayerAsync(TestContext context, CancellationToken cancellationToken)
    {
        const int GrenadePrice = 999;
        LegacyPlayerDocument stale = await context.CreatePlayerAsync(GrenadePrice * 2, cancellationToken);
        await LegacyTestAccounts.UpdateForTestAsync(context.Database, stale.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.WarBucks, GrenadePrice), cancellationToken);
        LegacyCatalog catalog = LegacyCatalog.Load(FindContent());
        var processor = new LegacyBufferProcessor(context.Buffers, catalog, NullLogger<LegacyBufferProcessor>.Instance);
        var buffer = new ParsedBuffer("fresh-projection",
            [new BufferedRequest(0, DatabaseAction.BuyWeapon, "{\"Name\":\"Google2u.Grenade_FRAG\"}")]);

        AppliedLegacyBuffer applied = await processor.ApplyAsync(stale, buffer, cancellationToken);

        Require(applied.Results[0]!["Result"]!.GetValue<int>() == 1 && applied.Player.WarBucks == 0 &&
            applied.Player.Revision == stale.Revision + 2,
            "Boot projection received the original stale account instead of the committed successor.");
        LevelManagerData levels = PlayerState.Read<LevelManagerData>(applied.Player.Serialized["LevelManagerData"]);
        Require(levels.SavedWeapons["Google2u.Grenade_FRAG"].Bought,
            "Committed projection lost the purchased weapon.");
    }

    private static Task<LegacyBufferedActionResult> PurchaseAsync(
        TestContext context, LegacyBufferedAction request, CancellationToken cancellationToken)
    {
        return context.Buffers.ExecuteAsync(request, player => CalculatePurchase(player, request), cancellationToken);
    }

    private static LegacyBufferedMutation CalculatePurchase(LegacyPlayerDocument player, LegacyBufferedAction request)
    {
        bool canAfford = player.WarBucks >= PurchasePrice;
        int result = (int)(canAfford ? DatabaseResult.Success : DatabaseResult.NotEnoughWarbucks);
        var inventory = new JsonObject { ["item"] = request.BufferId };
        var response = new JsonObject
        {
            ["ActionId"] = request.ActionId,
            ["Result"] = result,
            ["WarBucks"] = canAfford ? player.WarBucks - PurchasePrice : player.WarBucks,
            ["InventoryData"] = player.Serialized.GetValueOrDefault("InventoryData", "{}")
        };
        return new LegacyBufferedMutation
        {
            Serialized = canAfford ? new Dictionary<string, string>
            {
                ["InventoryData"] = inventory.ToJsonString(),
                ["LevelManagerData"] = inventory.ToJsonString()
            } : new Dictionary<string, string>(),
            Gold = player.Gold,
            WarBucks = canAfford ? player.WarBucks - PurchasePrice : player.WarBucks,
            Scraps = player.Scraps,
            ArmyPower = player.ArmyPower,
            Result = result,
            ResponseJson = response.ToJsonString()
        };
    }

    private static LegacyBufferedAction CreateAction(string playerId, string bufferId)
    {
        return new LegacyBufferedAction
        {
            PlayerId = playerId,
            BufferId = bufferId,
            Index = 0,
            ActionId = (int)DatabaseAction.BuyWeapon,
            PayloadDigest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(bufferId)))
        };
    }

    private static int ResultCode(LegacyBufferedActionResult reply)
    {
        return JsonNode.Parse(reply.ResponseJson!)!["Result"]!.GetValue<int>();
    }

    private static Task<BsonDocument> SetReceiptValidatorAsync(
        IMongoDatabase database, BsonDocument validator, CancellationToken cancellationToken)
    {
        return database.RunCommandAsync<BsonDocument>(new BsonDocument
        {
            ["collMod"] = "legacyBufferReceipts",
            ["validator"] = validator,
            ["validationLevel"] = "strict"
        }, cancellationToken: cancellationToken);
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

        throw new FileNotFoundException("Recovered economy catalog is absent.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class TestContext(IMongoDatabase database)
    {
        public IMongoDatabase Database { get; } = database;

        public LegacyPlayerStore Players { get; } = new(database);

        public LegacyBufferStore Buffers { get; } = new(database);

        public IMongoCollection<LegacyBufferReceipt> Receipts { get; } =
            database.GetCollection<LegacyBufferReceipt>("legacyBufferReceipts");

        public async Task<LegacyPlayerDocument> CreatePlayerAsync(long warBucks, CancellationToken cancellationToken)
        {
            var player = new LegacyPlayerDocument
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "BufferTransaction",
                WarBucks = warBucks,
                SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
                CreatedUtc = DateTime.UtcNow
            };
            await LegacyTestAccounts.InsertAsync(Database, player, cancellationToken);
            return player;
        }

        public async Task<LegacyPlayerDocument> ReadPlayerAsync(string identity, CancellationToken cancellationToken)
        {
            return await Players.ById(identity, cancellationToken)
                ?? throw new InvalidDataException("Test account disappeared.");
        }
    }
}

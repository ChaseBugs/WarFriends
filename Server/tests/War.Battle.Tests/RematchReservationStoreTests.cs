using System.Text.Json;

using MongoDB.Bson;
using MongoDB.Driver;

using War.BattleServer;
using War.Persistence;
using War.Shared;

/// <summary>Checks atomic participant reservation and cancellation fencing on a real replica set.</summary>
internal static class RematchReservationStoreTests
{
    internal static async Task RunAsync(string uri)
    {
        string databaseName = "war_rematch_reservation_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        try
        {
            var stores = new Stores
            {
                Queue = new BattleMatchQueueStore(uri, databaseName),
                Results = new BattleResultStore(uri, databaseName),
                First = new BattleRematchConsentStore(uri, databaseName),
                Second = new BattleRematchConsentStore(uri, databaseName),
                Database = mongo.GetDatabase(databaseName),
            };
            await stores.Queue.Initialize(deadline.Token);
            await stores.Results.Initialize(deadline.Token);
            await VerifyRequiredConsentAsync(stores, deadline.Token);
            await VerifyConcurrentReservationAsync(stores, deadline.Token);
            await VerifyCancellationRaceAsync(stores, deadline.Token);
            await VerifyBusyAndExpiredAsync(stores, deadline.Token);
            await VerifyExhaustedRevisionAsync(stores, deadline.Token);
            Console.WriteLine("PASS: atomic rematch reservation, concurrent replay, cancellation race, busy and expiry");
        }
        finally
        {
            await mongo.DropDatabaseAsync(databaseName);
        }
    }

    private static async Task<Fixture> PrepareAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await CreateAcceptedAsync(stores, cancellationToken);
        await stores.First.AcceptAsync(fixture.Request.SourceMatchId, fixture.Players[0],
            fixture.Request.ApplicationTime, cancellationToken);
        await stores.Second.AcceptAsync(fixture.Request.SourceMatchId, fixture.Players[1],
            fixture.Request.ApplicationTime, cancellationToken);
        return fixture;
    }

    private static async Task<Fixture> CreateAcceptedAsync(Stores stores, CancellationToken cancellationToken)
    {
        var manifest = await AtomicTerminalAcceptanceTests.CreatePairAsync(stores.Queue, cancellationToken);
        byte[] payload = AtomicTerminalAcceptanceTests.FinishBattle(manifest);
        string digest = TerminalResultDigest.Compute(payload);
        await stores.Results.Accept(manifest.MatchId, digest, payload, cancellationToken);
        string[] players = manifest.Players.Select(player => player.PlayerId).ToArray();
        Require(await stores.Queue.Release(manifest.MatchId, players, cancellationToken), "Fixture pair release failed.");
        var now = DateTimeOffset.UtcNow;
        return new Fixture(new BattleRematchReservation(manifest.MatchId, players[0], "rematch.fixture", now),
            players, digest, JsonSerializer.SerializeToUtf8Bytes(manifest));
    }

    private static async Task VerifyRequiredConsentAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await CreateAcceptedAsync(stores, cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request, cancellationToken) == null,
            "Missing consent must not reserve a battle.");
        await stores.First.AcceptAsync(fixture.Request.SourceMatchId, fixture.Players[0],
            fixture.Request.ApplicationTime, cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request, cancellationToken) == null,
            "One consent must not reserve both participants.");
        await stores.Second.AcceptAsync(fixture.Request.SourceMatchId, fixture.Players[1],
            fixture.Request.ApplicationTime, cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request with
        {
            AuthenticatedPlayerId = Guid.NewGuid().ToString("N"),
        }, cancellationToken) == null, "An outsider must not consume the participants' consent.");
        await stores.Second.CancelAsync(fixture.Request.SourceMatchId, fixture.Players[1],
            fixture.Request.ApplicationTime, cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request, cancellationToken) == null &&
            await stores.Queue.Existing(fixture.Players[0], cancellationToken) == null,
            "Cancellation before reservation must leave both participants unallocated.");
    }

    private static async Task VerifyConcurrentReservationAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await PrepareAsync(stores, cancellationToken);
        fixture = fixture with
        {
            Request = fixture.Request with
            {
                PlayerOrder = fixture.Players,
                PreparedManifest = JsonSerializer.SerializeToUtf8Bytes(MatchManifest.Parse(fixture.SourceManifest) with
                {
                    MatchId = "m" + Guid.NewGuid().ToString("N"),
                }),
            },
        };
        using var changes = await stores.Database.WatchAsync(
            new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>(),
            new ChangeStreamOptions { MaxAwaitTime = TimeSpan.FromSeconds(1) }, cancellationToken);
        var reserved = await Task.WhenAll(stores.First.ReserveAsync(fixture.Request, cancellationToken),
            stores.Second.ReserveAsync(fixture.Request, cancellationToken));
        Require(reserved.All(row => row.Status == "allocated" && row.Revision == 3) &&
            reserved[0].NextMatchId == reserved[1].NextMatchId && reserved[0].NextMatchId != fixture.Request.SourceMatchId,
            "Concurrent reservation must publish exactly one distinct match identity.");
        await VerifyTransactionAsync(changes, cancellationToken);
        var snapshots = stores.Database.GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots");
        var frozen = await snapshots.Find(row => row.Id == reserved[0].NextMatchId).SingleAsync(cancellationToken);
        Require(frozen.Manifest.SequenceEqual(fixture.Request.PreparedManifest ?? []),
            "The committed pair must already have its exact frozen admission payload.");
        Require(await TryReserveAsync(stores.First, fixture.Request with
        {
            CompatibilityKey = "changed-policy.fixture",
        }, cancellationToken) == null, "Reservation replay must not adopt a different compatibility policy.");
        var pair = await stores.Queue.ForMatch(reserved[0].NextMatchId, cancellationToken)
            ?? throw new InvalidDataException("The committed reservation pair is absent.");
        var players = pair.Players ?? throw new InvalidDataException("The committed reservation roster is absent.");
        Require(players.OrderBy(player => player).SequenceEqual(fixture.Players.OrderBy(player => player)),
            "The reserved roster must contain exactly the original participants.");
        Require(players.SequenceEqual(fixture.Players) && reserved[0].NextPlayers.SequenceEqual(fixture.Players),
            "The reserved pair and consent marker must retain the frozen source order.");
        Require(await TryReserveAsync(stores.First, fixture.Request with
        {
            PlayerOrder = fixture.Players.Reverse().ToArray(),
        }, cancellationToken) == null, "Reservation replay must not swap player slots.");
        var cancelled = await stores.Second.CancelAsync(fixture.Request.SourceMatchId, fixture.Players[1],
            fixture.Request.ApplicationTime, cancellationToken);
        Require(cancelled.Status == "allocated" && cancelled.NextMatchId == reserved[0].NextMatchId,
            "Cancellation after reservation must observe allocation rather than rewrite it as cancelled.");
        await stores.Queue.Release(reserved[0].NextMatchId, players, cancellationToken);
        var replay = await stores.First.ReserveAsync(fixture.Request with
        {
            ApplicationTime = fixture.Request.ApplicationTime.AddMinutes(1),
        }, cancellationToken);
        Require(replay.NextMatchId == reserved[0].NextMatchId &&
            await stores.Queue.ForMatch(replay.NextMatchId, cancellationToken) == null,
            "A consumed reservation must not recreate its released pair after expiry.");
        Require((await stores.Results.Get(fixture.Request.SourceMatchId, cancellationToken))?.Digest == fixture.Digest,
            "Reservation must preserve the old accepted result.");
    }

    private static async Task VerifyTransactionAsync(
        IChangeStreamCursor<ChangeStreamDocument<BsonDocument>> changes, CancellationToken cancellationToken)
    {
        var writes = new List<BsonDocument>();
        while (writes.Count < 3 && await changes.MoveNextAsync(cancellationToken))
        {
            foreach (var change in changes.Current)
            {
                if (change.CollectionNamespace.CollectionName is
                    "battle_pairs" or "battle_rematch_consents" or "battle_manifest_snapshots")
                {
                    writes.Add(change.BackingDocument);
                }
            }
        }
        Require(writes.Count == 3 && writes.All(write => write.Contains("txnNumber") &&
            write["txnNumber"] == writes[0]["txnNumber"] && write["lsid"] == writes[0]["lsid"]),
            "Consent, participant reservation and frozen manifest must share one committed Mongo transaction.");
    }

    private static async Task VerifyCancellationRaceAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await PrepareAsync(stores, cancellationToken);
        Task<BattleRematchConsentDocument?> reservation = TryReserveAsync(stores.First, fixture.Request, cancellationToken);
        Task<BattleRematchConsentDocument> cancellation = stores.Second.CancelAsync(fixture.Request.SourceMatchId,
            fixture.Players[1], fixture.Request.ApplicationTime, cancellationToken);
        await Task.WhenAll(new Task[] { reservation, cancellation });
        var current = await stores.First.ReadAsync(fixture.Request.SourceMatchId, fixture.Players[0],
            fixture.Request.ApplicationTime, cancellationToken);
        var pair = await stores.Queue.Existing(fixture.Players[0], cancellationToken);
        if (current?.Status == "allocated")
        {
            Require(reservation.Result?.NextMatchId == pair?.MatchId && cancellation.Result.Status == "allocated",
                "When reservation wins, cancellation must observe the same allocated match.");
            return;
        }
        Require(current?.Status == "cancelled" && pair == null && reservation.Result == null,
            "When cancellation wins, reservation must not create a pair.");
    }

    private static async Task VerifyBusyAndExpiredAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await PrepareAsync(stores, cancellationToken);
        await stores.Queue.Join(fixture.Players[0], "other-search", fixture.Request.ApplicationTime, cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request, cancellationToken) == null,
            "Reservation must not consume another matchmaking ticket.");
        var current = await stores.First.ReadAsync(fixture.Request.SourceMatchId, fixture.Players[0],
            fixture.Request.ApplicationTime, cancellationToken);
        Require(current?.Status == "ready" && current.NextMatchId == "", "A failed reservation must not consume consent.");
        await stores.Queue.Cancel(fixture.Players[0], fixture.Request.ApplicationTime, cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request with
        {
            ApplicationTime = fixture.Request.ApplicationTime.AddSeconds(BattleRematchConsentStore.ConsentDurationSeconds),
        }, cancellationToken) == null && await stores.Queue.Existing(fixture.Players[0], cancellationToken) == null,
            "Expired consent must not reserve a new battle.");
    }

    private static async Task<BattleRematchConsentDocument?> TryReserveAsync(
        BattleRematchConsentStore store, BattleRematchReservation request, CancellationToken cancellationToken)
    {
        try
        {
            return await store.ReserveAsync(request, cancellationToken);
        }
        catch (InvalidDataException)
        {
            // The caller asserts which competing authority must explain this rejection.
            return null;
        }
    }

    private static async Task VerifyExhaustedRevisionAsync(Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await PrepareAsync(stores, cancellationToken);
        var rows = stores.Database.GetCollection<BattleRematchConsentDocument>("battle_rematch_consents");
        await rows.UpdateOneAsync(row => row.Id == fixture.Request.SourceMatchId,
            Builders<BattleRematchConsentDocument>.Update.Set(row => row.Revision, long.MaxValue - 1),
            cancellationToken: cancellationToken);
        Require(await TryReserveAsync(stores.First, fixture.Request, cancellationToken) == null &&
            await stores.Queue.Existing(fixture.Players[0], cancellationToken) == null,
            "Exhausted consent revision must not publish a pair or unusable allocation marker.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    private sealed record Fixture(BattleRematchReservation Request, string[] Players, string Digest, byte[] SourceManifest);

    private sealed class Stores
    {
        internal required BattleMatchQueueStore Queue { get; init; }
        internal required BattleResultStore Results { get; init; }
        internal required BattleRematchConsentStore First { get; init; }
        internal required BattleRematchConsentStore Second { get; init; }
        internal required IMongoDatabase Database { get; init; }
    }
}

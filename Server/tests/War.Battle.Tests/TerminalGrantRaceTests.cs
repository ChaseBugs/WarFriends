using System.Text.Json;
using Google.Protobuf;
using MongoDB.Bson;
using MongoDB.Driver;
using War.BattleServer;
using War.Persistence;
using War.Protocol;
using War.Shared;

/// <summary>Checks committed grant/result ordering through real MongoDB change streams.</summary>
internal static class TerminalGrantRaceTests
{
    private const int ConcurrentCases = 12;
    private const int FixturePort = 30000;
    private const int SessionKeyBytes = 32;
    private const int TicketLifetimeSeconds = 120;

    internal static async Task RunAsync(string uri, string databaseName, CancellationToken cancellationToken)
    {
        var stores = new Stores(uri, databaseName);
        await stores.Grants.Initialize(cancellationToken);
        await VerifyOrderAsync(stores, PublicationOrder.GrantFirst, cancellationToken);
        await VerifyOrderAsync(stores, PublicationOrder.TerminalFirst, cancellationToken);
        for (int index = 0; index < ConcurrentCases; index++)
        {
            await VerifyOrderAsync(stores, PublicationOrder.Concurrent, cancellationToken);
        }

        Console.WriteLine("PASS: grant-first, terminal-first and 12 concurrent terminal/grant publication cases");
    }

    private static async Task VerifyOrderAsync(
        Stores stores, PublicationOrder order, CancellationToken cancellationToken)
    {
        var manifest = await AtomicTerminalAcceptanceTests.CreatePairAsync(stores.Queue, cancellationToken);
        await stores.Manifests.GetOrCreate(manifest.MatchId,
            manifest.Players.Select(player => player.PlayerId).ToArray(),
            () => Task.FromResult(JsonSerializer.SerializeToUtf8Bytes(manifest)), cancellationToken);
        byte[] payload = AtomicTerminalAcceptanceTests.FinishBattle(manifest);
        string digest = TerminalResultDigest.Compute(payload);
        var grants = CreateGrants(manifest);
        using var changes = await stores.Database.WatchAsync(
            new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>(),
            new ChangeStreamOptions { MaxAwaitTime = TimeSpan.FromSeconds(1) }, cancellationToken);
        async Task<string> PublishAsync() => await stores.Grants.PublishForActivePairAsync(
            manifest.MatchId, manifest.Digest(), grants, cancellationToken);
        async Task<string> AcceptAsync() => await stores.Results.AcceptAndReleasePairAsync(
            manifest.MatchId, digest, payload, cancellationToken);
        string published = await ExecuteOrderAsync(order, PublishAsync, AcceptAsync);
        Require(published is "published" or "cancelled", "Unexpected grant publication result.");
        Require(order != PublicationOrder.GrantFirst || published == "published", "Grant-first case lost its grant.");
        Require(order != PublicationOrder.TerminalFirst || published == "cancelled", "Terminal-first grant survived.");
        await VerifyCommitOrderAsync(changes, published == "published", cancellationToken);
        var stored = await stores.Grants.GetForPlayer(manifest.MatchId, grants[0].PlayerId,
            DateTimeOffset.UtcNow.ToUnixTimeSeconds(), cancellationToken);
        Require((stored != null) == (published == "published") &&
            await stores.Queue.ForMatch(manifest.MatchId, cancellationToken) == null,
            "Terminal acceptance must remove the pair and preserve only an earlier historical grant.");
    }

    private static async Task<string> ExecuteOrderAsync(
        PublicationOrder order, Func<Task<string>> publishAsync, Func<Task<string>> acceptAsync)
    {
        if (order == PublicationOrder.GrantFirst)
        {
            string published = await publishAsync();
            Require(await acceptAsync() == "accepted", "Grant-first result was not accepted.");
            return published;
        }

        if (order == PublicationOrder.TerminalFirst)
        {
            Require(await acceptAsync() == "accepted", "Terminal-first result was not accepted.");
            return await publishAsync();
        }

        var publication = publishAsync();
        var acceptance = acceptAsync();
        await Task.WhenAll(publication, acceptance);
        Require(await acceptance == "accepted", "Concurrent terminal result was not accepted.");
        return await publication;
    }

    private static async Task VerifyCommitOrderAsync(
        IChangeStreamCursor<ChangeStreamDocument<BsonDocument>> changes,
        bool hasGrant, CancellationToken cancellationToken)
    {
        BsonTimestamp? grantTime = null;
        BsonTimestamp? resultTime = null;
        bool removed = false;
        while ((!removed || resultTime == null || (hasGrant && grantTime == null)) &&
            await changes.MoveNextAsync(cancellationToken))
        {
            foreach (var change in changes.Current)
            {
                if (change.CollectionNamespace.CollectionName == "battle_grants" &&
                    change.OperationType == ChangeStreamOperationType.Insert)
                {
                    grantTime = change.ClusterTime;
                }
                else if (change.CollectionNamespace.CollectionName == "battle_results")
                {
                    resultTime = change.ClusterTime;
                }
                else if (change.CollectionNamespace.CollectionName == "battle_pairs" &&
                    change.OperationType == ChangeStreamOperationType.Delete)
                {
                    removed = true;
                }
            }
        }

        Require(removed && resultTime != null && (!hasGrant ||
            (grantTime != null && grantTime.CompareTo(resultTime) < 0)),
            "A grant must never commit after its accepted terminal result.");
    }

    private static MatchConnectionGrant[] CreateGrants(MatchManifest manifest)
    {
        var views = manifest.Players.Select((player, index) =>
        {
            var view = new BattlePlayerView
            {
                PlayerId = player.PlayerId, DisplayName = "PublicationFixture", Fraction = index + 1,
            };
            view.VisualIds.Add(["fixture-0", "fixture-1", "fixture-2", "fixture-3"]);
            view.Weapons.Add(new BattleWeaponView { SourceId = player.Weapon.SourceId });
            return view;
        }).ToArray();
        return manifest.Players.Select((player, index) =>
        {
            // Opaque storage fixtures are not Worker admission tickets or playable client grants.
            var grant = new MatchConnectionGrant
            {
                MatchId = manifest.MatchId, ManifestHash = manifest.Digest(), PlayerId = player.PlayerId,
                Host = "127.0.0.1", Port = FixturePort, SessionId = (ulong)index + 1,
                Ticket = "fixture-ticket-" + index,
                SessionKey = ByteString.CopyFrom(Enumerable.Repeat((byte)(index + 1), SessionKeyBytes).ToArray()),
                ExpiresUnixSeconds = DateTimeOffset.UtcNow.AddSeconds(TicketLifetimeSeconds).ToUnixTimeSeconds(),
            };
            grant.PlayerViews.Add(views);
            return grant;
        }).ToArray();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private enum PublicationOrder
    {
        GrantFirst,
        TerminalFirst,
        Concurrent,
    }

    private sealed class Stores
    {
        internal Stores(string uri, string databaseName)
        {
            Database = new MongoClient(uri).GetDatabase(databaseName);
            Queue = new BattleMatchQueueStore(uri, databaseName);
            Results = new BattleResultStore(uri, databaseName);
            Manifests = new BattleManifestSnapshotStore(uri, databaseName);
            Grants = new BattleGrantStore(uri, databaseName);
        }

        internal IMongoDatabase Database { get; }
        internal BattleMatchQueueStore Queue { get; }
        internal BattleResultStore Results { get; }
        internal BattleManifestSnapshotStore Manifests { get; }
        internal BattleGrantStore Grants { get; }
    }
}

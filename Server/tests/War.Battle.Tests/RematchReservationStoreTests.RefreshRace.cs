using System.Text.Json;

using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Shared;

internal static partial class RematchReservationStoreTests
{
    private const int RefreshRaceGateSeconds = 10;

    internal static async Task RunRefreshRaceAsync(string uri)
    {
        string databaseName = "war_rematch_refresh_race_" + Guid.NewGuid().ToString("N");
        var mongo = new MongoClient(uri);
        using var deadline = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        try
        {
            var stores = new Stores
            {
                Queue = new BattleMatchQueueStore(uri, databaseName),
                Results = new BattleResultStore(uri, databaseName),
                First = new BattleRematchConsentStore(uri, databaseName),
                Second = new BattleRematchConsentStore(uri, databaseName), Database = mongo.GetDatabase(databaseName)
            };
            await stores.Queue.Initialize(deadline.Token);
            await stores.Results.Initialize(deadline.Token);
            await VerifyRefreshWinsAsync(uri, stores, deadline.Token);
            Console.WriteLine("PASS: rematch reservation waits for inactive refresh " +
                "and rejects stale prepared authority");
        }
        finally
        {
            await mongo.DropDatabaseAsync(databaseName);
        }
    }

    private static async Task VerifyRefreshWinsAsync(string uri, Stores stores, CancellationToken cancellationToken)
    {
        RefreshRaceState state = await PrepareRefreshRaceAsync(uri, stores, cancellationToken);
        var observed = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var attempted = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var release = new ManualResetEventSlim();
        Task refresh = Task.Run(() => state.Preparation.RefreshInactiveAsync(state.PlayerId,
            state.ExpectedRevision, account =>
            {
                BattleAllocationProjection projection = BattleAllocationSource.Project(account);
                observed.TrySetResult(true);
                if (!release.Wait(TimeSpan.FromSeconds(RefreshRaceGateSeconds), cancellationToken))
                {
                    throw new TimeoutException("The refresh/rematch projection gate was not released.");
                }
                return projection;
            }, cancellationToken), cancellationToken);
        Task<BattleRematchConsentDocument?>? reservation = null;
        try
        {
            await observed.Task.WaitAsync(TimeSpan.FromSeconds(RefreshRaceGateSeconds), cancellationToken);
            BattleRematchConsentStore contender = CreateObservedStore(uri, stores, attempted);
            reservation = TryReserveAsync(contender, state.Source.Request, cancellationToken);
            await attempted.Task.WaitAsync(TimeSpan.FromSeconds(RefreshRaceGateSeconds), cancellationToken);
            Require(!reservation.IsCompleted && await stores.Queue.Existing(state.PlayerId, cancellationToken) == null,
                "Rematch reservation bypassed the in-flight inactive refresh.");
        }
        finally
        {
            release.Set();
        }
        await refresh;
        Require(reservation != null && await reservation == null,
            "Rematch reservation published a manifest prepared from the previous account generation.");
        var allocation = await new BattleAllocationStore(stores.Database).Get(state.PlayerId, cancellationToken)
            ?? throw new InvalidDataException("The refreshed allocation disappeared.");
        Require(allocation.CardCounts.Single() == 2 &&
            await stores.Queue.Existing(state.PlayerId, cancellationToken) == null,
            "The rejected rematch changed refreshed ownership or retained a partial pair.");
        byte[] prepared = state.Source.Request.PreparedManifest
            ?? throw new InvalidDataException("The refresh/rematch prepared fixture is absent.");
        string nextId = MatchManifest.Parse(prepared).MatchId;
        bool hasSnapshot = await stores.Database
            .GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots")
            .Find(row => row.Id == nextId).AnyAsync(cancellationToken);
        Require(!hasSnapshot, "Stale rematch reservation retained a partial frozen manifest.");
        List<LegacyPlayerDocument> accounts = await stores.Database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .Find(Builders<LegacyPlayerDocument>.Filter.In(row => row.Id, state.Source.Players))
            .ToListAsync(cancellationToken);
        Require(accounts.Count == state.Source.Players.Length && accounts.All(row => row.Revision ==
            (row.Id == state.PlayerId ? state.ExpectedRevision + 1 : 1)),
            "Rejected rematch reservation retained a partial account revision write.");
        BattleRematchConsentDocument? consent = await stores.First.ReadAsync(state.Source.Request.SourceMatchId,
            state.Source.Request.AuthenticatedPlayerId, state.Source.Request.ApplicationTime, cancellationToken);
        Require(consent?.Status == "ready", "Rejected rematch reservation consumed mutual consent.");
    }

    private static async Task<RefreshRaceState> PrepareRefreshRaceAsync(
        string uri, Stores stores, CancellationToken cancellationToken)
    {
        Fixture fixture = await PrepareAsync(stores, cancellationToken);
        var accounts = stores.Database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        await accounts.InsertManyAsync(fixture.Players.Select(playerId => new LegacyPlayerDocument
        {
            Id = playerId, Revision = 1, Level = 1, Name = "RematchRefreshRace", Country = "US", Locale = "en",
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        }), cancellationToken: cancellationToken);
        fixture = fixture with
        {
            Request = fixture.Request with
            {
                PlayerOrder = fixture.Players,
                PreparedManifest = JsonSerializer.SerializeToUtf8Bytes(MatchManifest.Parse(fixture.SourceManifest) with
                {
                    MatchId = "m" + Guid.NewGuid().ToString("N")
                }),
                ExpectedAccountRevisions = fixture.Players.Select(id => new BattleAccountRevision(id, 1)).ToArray()
            }
        };
        string target = fixture.Players.Order(StringComparer.Ordinal).First();
        var players = new LegacyPlayerStore(stores.Database);
        LegacyPlayerDocument account = await players.ById(target, cancellationToken)
            ?? throw new InvalidDataException("The refresh/rematch account is missing.");
        var allocations = new BattleAllocationStore(stores.Database);
        await allocations.Put(BattleAllocationSource.Project(account), cancellationToken);
        var cards = new CardManagerData();
        cards.CardData.Add("SLOWDOWN", new SavedCardData { Amount = 2 });
        await players.SetSerialized(target, "CardManagerData", PlayerState.Write(cards), cancellationToken);
        return new RefreshRaceState(fixture, target, account.Revision + 1,
            new BattleAllocationPreparationStore(uri, stores.Database.DatabaseNamespace.DatabaseName));
    }

    private static BattleRematchConsentStore CreateObservedStore(string uri, Stores stores,
        TaskCompletionSource<bool> attempted)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandStartedEvent>(command =>
        {
            if (command.CommandName == "update" && command.Command["update"] == "battle_admission_fences")
            {
                attempted.TrySetResult(true);
            }
        });
        var database = new MongoClient(settings).GetDatabase(stores.Database.DatabaseNamespace.DatabaseName);
        return new BattleRematchConsentStore(database, stores.Results);
    }

    private sealed record RefreshRaceState(Fixture Source, string PlayerId, long ExpectedRevision,
        BattleAllocationPreparationStore Preparation);
}

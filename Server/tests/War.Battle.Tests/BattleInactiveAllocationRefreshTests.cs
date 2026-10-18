using MongoDB.Driver;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;

/// <summary>Checks authoritative inactive refresh, retry preservation and active-owner rejection.</summary>
internal static class BattleInactiveAllocationRefreshTests
{
    private const int InitialOwnedCopies = 2;
    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        CancellationToken cancellationToken = deadline.Token;
        var fixture = new Fixture(uri, databaseName);
        await fixture.Players.Insert(new LegacyPlayerDocument
        {
            Id = fixture.PlayerId, Name = "InactiveRefresh", Country = "US", Locale = "en", Level = 1,
            CreatedUtc = DateTime.UtcNow, SessionExpiresUtc = DateTime.UtcNow.AddHours(1),
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        }, LegacyPlayerStore.NewPassword(), cancellationToken);
        await fixture.Players.SetSerialized(fixture.PlayerId, "CardManagerData",
            CardState(InitialOwnedCopies), cancellationToken);
        LegacyPlayerDocument initial = await ReadAccountAsync(fixture, cancellationToken);
        await fixture.Preparation.PrepareAsync(fixture.PlayerId, initial.Revision,
            BattleAllocationSource.Project, cancellationToken);
        await VerifyRefreshAndReplayAsync(fixture, cancellationToken);
        await VerifyActiveOwnerAsync(fixture, cancellationToken);
        await VerifyCorruptRevisionAsync(fixture, cancellationToken);
        Console.WriteLine("PASS: inactive refresh uses current inventory, preserves replay " +
            "and rejects active or corrupt authority");
    }

    private static async Task VerifyRefreshAndReplayAsync(Fixture fixture, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument before = await ReadAccountAsync(fixture, cancellationToken);
        BattleAllocationDocument prior = await ReadAllocationAsync(fixture, cancellationToken);
        await fixture.Players.SetSerialized(fixture.PlayerId, "CardManagerData", CardState(0), cancellationToken);
        await RejectAsync(() => fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, before.Revision,
            BattleAllocationSource.Project, cancellationToken));
        LegacyPlayerDocument changed = await ReadAccountAsync(fixture, cancellationToken);
        await fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, changed.Revision,
            BattleAllocationSource.Project, cancellationToken);
        BattleAllocationDocument refreshed = await ReadAllocationAsync(fixture, cancellationToken);
        LegacyPlayerDocument current = await ReadAccountAsync(fixture, cancellationToken);
        Require(refreshed.CardIds.Length == 0 && refreshed.Revision == prior.Revision + 1 &&
            current.Revision == changed.Revision + 1, "Inactive refresh restored spent cards or lost its revision binding.");
        await fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, current.Revision,
            BattleAllocationSource.Project, cancellationToken);
        Require((await ReadAccountAsync(fixture, cancellationToken)).Revision == current.Revision &&
            (await ReadAllocationAsync(fixture, cancellationToken)).Revision == refreshed.Revision,
            "An identical refresh advanced account or allocation authority.");
    }

    private static async Task VerifyActiveOwnerAsync(Fixture fixture, CancellationToken cancellationToken)
    {
        await fixture.Queue.Initialize(cancellationToken);
        await fixture.Queue.Join(fixture.PlayerId, "inactive-refresh.fixture", DateTimeOffset.UtcNow, cancellationToken);
        await fixture.Players.SetSerialized(fixture.PlayerId, "CardManagerData",
            CardState(InitialOwnedCopies), cancellationToken);
        LegacyPlayerDocument account = await ReadAccountAsync(fixture, cancellationToken);
        await RejectAsync(() => fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, account.Revision,
            BattleAllocationSource.Project, cancellationToken));
        Require((await ReadAllocationAsync(fixture, cancellationToken)).CardIds.Length == 0,
            "A waiting ticket allowed allocation refresh.");
        await fixture.Queue.CancelWithPairAsync(fixture.PlayerId, DateTimeOffset.UtcNow, cancellationToken);
        await fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, account.Revision,
            BattleAllocationSource.Project, cancellationToken);
        account = await ReadAccountAsync(fixture, cancellationToken);
        await fixture.Queue.Join(fixture.PlayerId, "inactive-refresh.fixture", DateTimeOffset.UtcNow, cancellationToken);
        BattlePairingResult pair = await fixture.Queue.Join(Guid.NewGuid().ToString("N"),
            "inactive-refresh.fixture", DateTimeOffset.UtcNow, cancellationToken);
        Require(pair.Code == "paired", "The refresh ownership fixture did not create a pair.");
        await RejectAsync(() => fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, account.Revision,
            BattleAllocationSource.Project, cancellationToken));
        Require((await ReadAccountAsync(fixture, cancellationToken)).Revision == account.Revision,
            "Rejected active refresh changed the account.");
        // This store-only fixture has no Worker and releases only its own synthetic pair.
        string matchId = pair.MatchId ?? throw new InvalidDataException("The refresh fixture match is absent.");
        IReadOnlyList<string> participants = pair.Players
            ?? throw new InvalidDataException("The refresh fixture roster is absent.");
        Require(await fixture.Queue.Release(matchId, participants, cancellationToken),
            "The refresh ownership fixture pair was not released.");
    }

    private static async Task VerifyCorruptRevisionAsync(Fixture fixture, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument account = await ReadAccountAsync(fixture, cancellationToken);
        await fixture.Documents.UpdateOneAsync(row => row.PlayerId == fixture.PlayerId,
            Builders<BattleAllocationDocument>.Update.Set(row => row.Revision, 0), cancellationToken: cancellationToken);
        await RejectAsync(() => fixture.Preparation.RefreshInactiveAsync(fixture.PlayerId, account.Revision,
            BattleAllocationSource.Project, cancellationToken));
        Require((await ReadAllocationAsync(fixture, cancellationToken)).Revision == 0 &&
            (await ReadAccountAsync(fixture, cancellationToken)).Revision == account.Revision,
            "Inactive refresh repaired corrupted authority or changed the account before rejection.");
    }

    private static string CardState(int amount)
    {
        var cards = new CardManagerData();
        cards.CardData.Add("SLOWDOWN", new SavedCardData { Amount = amount });
        return PlayerState.Write(cards);
    }

    private static async Task<LegacyPlayerDocument> ReadAccountAsync(Fixture fixture, CancellationToken cancellationToken)
    {
        return await fixture.Players.ById(fixture.PlayerId, cancellationToken)
            ?? throw new InvalidDataException("Inactive refresh account disappeared.");
    }

    private static Task<BattleAllocationDocument> ReadAllocationAsync(Fixture fixture, CancellationToken cancellationToken)
    {
        return fixture.Documents.Find(row => row.PlayerId == fixture.PlayerId).SingleAsync(cancellationToken);
    }

    private static async Task RejectAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidDataException("Invalid inactive allocation refresh was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    private sealed class Fixture
    {
        internal Fixture(string uri, string databaseName)
        {
            Players = new LegacyPlayerStore(uri, databaseName);
            Preparation = new BattleAllocationPreparationStore(uri, databaseName);
            Queue = new BattleMatchQueueStore(uri, databaseName);
            Documents = new MongoClient(uri).GetDatabase(databaseName)
                .GetCollection<BattleAllocationDocument>("battle_allocations");
        }

        internal string PlayerId { get; } = Guid.NewGuid().ToString("N");
        internal LegacyPlayerStore Players { get; }
        internal BattleAllocationPreparationStore Preparation { get; }
        internal BattleMatchQueueStore Queue { get; }
        internal IMongoCollection<BattleAllocationDocument> Documents { get; }
    }
}

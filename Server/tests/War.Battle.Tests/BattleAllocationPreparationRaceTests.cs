using MongoDB.Driver;
using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Battle.Tests.Support;
using War.Shared;

/// <summary>Forces inventory publication between the preparation read and account reservation.</summary>
internal static class BattleAllocationPreparationRaceTests
{
    private const int GateDeadlineSeconds = 10;

    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        CancellationToken cancellationToken = deadline.Token;
        var players = new LegacyPlayerStore(uri, databaseName);
        var allocations = new BattleAllocationStore(uri, databaseName);
        var preparation = new BattleAllocationPreparationStore(uri, databaseName);
        LegacyPlayerDocument player = CreatePlayer();
        await LegacyTestAccounts.InsertAsync(uri, databaseName, player, cancellationToken);

        var observed = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var release = new ManualResetEventSlim();
        Task pending = Task.Run(() => preparation.PrepareAsync(player.Id, player.Revision, snapshot =>
        {
            BattleAllocationProjection projected = BattleAllocationSource.Project(snapshot);
            observed.TrySetResult(true);
            if (!release.Wait(TimeSpan.FromSeconds(GateDeadlineSeconds), cancellationToken))
            {
                throw new TimeoutException("The inventory race did not release its prepared account read.");
            }
            return projected;
        }, cancellationToken), cancellationToken);

        try
        {
            await observed.Task.WaitAsync(TimeSpan.FromSeconds(GateDeadlineSeconds), cancellationToken);
            await LegacyTestAccounts.SetCardsForTestAsync(new MongoClient(uri).GetDatabase(databaseName),
                player.Id, PlayerState.Write(new CardManagerData()),
                cancellationToken);
        }
        finally
        {
            release.Set();
        }

        bool rejected = false;
        try
        {
            await pending;
        }
        catch (InvalidDataException)
        {
            rejected = true;
        }
        Require(rejected && await allocations.Get(player.Id, cancellationToken) == null,
            "Preparation published cards from before the concurrent inventory change.");
        LegacyPlayerDocument current = await players.ById(player.Id, cancellationToken)
            ?? throw new InvalidDataException("The inventory race account disappeared.");
        Require(current.Revision == player.Revision + 1, "Rejected preparation changed the winning account revision.");
        await preparation.PrepareAsync(player.Id, current.Revision, BattleAllocationSource.Project, cancellationToken);
        BattleAllocationProjection saved = await allocations.Get(player.Id, cancellationToken)
            ?? throw new InvalidDataException("Fresh preparation did not publish the winning inventory.");
        Require(saved.CardIds.Count == 0, "Fresh preparation restored cards removed by the winning inventory change.");
        Console.WriteLine("PASS: forced inventory/preparation race rejects stale cards and retries from current authority");
    }

    private static LegacyPlayerDocument CreatePlayer()
    {
        var cards = new CardManagerData();
        cards.CardData.Add(OrdinaryCardIdentityCatalog.All.First(), new SavedCardData { Amount = 2 });
        Dictionary<string, string> serialized = LegacyInitialLoadout.CreateSerializedState();
        serialized["CardManagerData"] = PlayerState.Write(cards);
        return new LegacyPlayerDocument
        {
            Id = new string('d', 32),
            Name = "PreparationRace",
            Country = "US",
            Locale = "en",
            Level = 1,
            CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            SessionExpiresUtc = DateTime.UtcNow.AddHours(1),
            Serialized = serialized
        };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}

using MongoDB.Driver;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;
using War.Battle.Tests.Support;

/// <summary>Checks atomic initial allocation against stale durable account revisions.</summary>
internal static class BattleAllocationPreparationTests
{
    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        CancellationToken cancellationToken = deadline.Token;
        var players = new LegacyPlayerStore(uri, databaseName);
        var allocations = new BattleAllocationStore(uri, databaseName);
        var preparation = new BattleAllocationPreparationStore(uri, databaseName);
        var player = new LegacyPlayerDocument
        {
            Id = new string('f', 32), Name = "Preparation", Country = "US", Locale = "en", Level = 1,
            CreatedUtc = DateTime.UtcNow,
            SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken()),
            SessionExpiresUtc = DateTime.UtcNow.AddHours(1),
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
        await LegacyTestAccounts.InsertAsync(uri, databaseName, player, cancellationToken);
        await LegacyTestAccounts.UpdateForTestAsync(new MongoClient(uri).GetDatabase(databaseName), player.Id,
            Builders<LegacyPlayerDocument>.Update.Inc(row => row.Gold, 1), cancellationToken);

        bool staleRejected = false;
        try
        {
            await preparation.PrepareAsync(player.Id, 1, BattleAllocationSource.Project, cancellationToken);
        }
        catch (InvalidDataException)
        {
            staleRejected = true;
        }
        Require(staleRejected && await allocations.Get(player.Id, cancellationToken) == null,
            "A stale account revision published initial battle authority.");

        await preparation.PrepareAsync(player.Id, 2, BattleAllocationSource.Project, cancellationToken);
        LegacyPlayerDocument current = await players.ById(player.Id, cancellationToken)
            ?? throw new InvalidDataException("Prepared account disappeared.");
        Require(current.Revision == 3 && await allocations.Get(player.Id, cancellationToken) != null,
            "Account reservation and initial allocation were not published together.");

        await preparation.PrepareAsync(player.Id, current.Revision, BattleAllocationSource.Project, cancellationToken);
        LegacyPlayerDocument replay = await players.ById(player.Id, cancellationToken)
            ?? throw new InvalidDataException("Replayed account disappeared.");
        Require(replay.Revision == current.Revision, "Preparation replay changed the durable account revision.");
        Console.WriteLine("PASS: stale account allocation rejected; atomic preparation and replay preserve authority");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}

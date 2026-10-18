using MongoDB.Driver;
using War.Backend;
using War.Persistence;

/// <summary>Checks that real queue and pair ownership prevent allocation preparation.</summary>
internal static class BattleAllocationPreparationOwnershipTests
{
    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        CancellationToken cancellationToken = deadline.Token;
        var queue = new BattleMatchQueueStore(uri, databaseName);
        var players = new LegacyPlayerStore(uri, databaseName);
        var preparation = new BattleAllocationPreparationStore(uri, databaseName);
        string first = new string('f', 32);
        string second = new string('d', 32);
        LegacyPlayerDocument before = await players.ById(first, cancellationToken)
            ?? throw new InvalidDataException("Prepared ownership fixture account is missing.");
        await queue.Initialize(cancellationToken);
        DateTimeOffset now = DateTimeOffset.UtcNow;
        BattlePairingResult waiting = await queue.Join(first, "preparation-ownership.fixture", now, cancellationToken);
        if (waiting.Code != "waiting")
        {
            throw new InvalidDataException("The ownership fixture did not create a waiting ticket.");
        }
        await RequireRejectedAsync(preparation, before, cancellationToken);
        BattlePairingResult paired = await queue.Join(second, "preparation-ownership.fixture", now, cancellationToken);
        if (paired.Code != "paired" || paired.MatchId == null)
        {
            throw new InvalidDataException("The ownership fixture did not commit a real queue pair.");
        }
        await RequireRejectedAsync(preparation, before, cancellationToken);
        LegacyPlayerDocument after = await players.ById(first, cancellationToken)
            ?? throw new InvalidDataException("The ownership fixture account disappeared.");
        if (after.Revision != before.Revision)
        {
            throw new InvalidDataException("Rejected active preparation changed account authority.");
        }

        // This store-only fixture has no Worker; remove its exact synthetic pair before later storage scenarios.
        var pairs = new MongoClient(uri).GetDatabase(databaseName).GetCollection<BattlePairDocument>("battle_pairs");
        DeleteResult deleted = await pairs.DeleteOneAsync(row => row.MatchId == paired.MatchId, cancellationToken);
        if (deleted.DeletedCount != 1)
        {
            throw new InvalidDataException("The synthetic ownership pair was not cleaned up exactly once.");
        }
        Console.WriteLine("PASS: waiting queue and paired battle ownership reject allocation preparation " +
            "without account writes");
    }

    private static async Task RequireRejectedAsync(BattleAllocationPreparationStore preparation,
        LegacyPlayerDocument account, CancellationToken cancellationToken)
    {
        try
        {
            await preparation.PrepareAsync(account.Id, account.Revision, BattleAllocationSource.Project, cancellationToken);
        }
        catch (InvalidDataException failure) when
            (failure.Message == "Active queue or battle ownership prevents allocation preparation.")
        {
            return;
        }
        throw new InvalidDataException("Active battle ownership allowed allocation preparation.");
    }
}

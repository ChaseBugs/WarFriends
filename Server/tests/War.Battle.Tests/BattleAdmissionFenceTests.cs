using MongoDB.Driver;
using War.Persistence;

/// <summary>Checks shared admission writes under competing transactions and malformed durable state.</summary>
internal static class BattleAdmissionFenceTests
{
    private const int CompetingTransactions = 8;

    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        CancellationToken cancellationToken = deadline.Token;
        var client = new MongoClient(uri);
        IMongoDatabase database = client.GetDatabase(databaseName);
        string playerId = new string('a', 32);
        await TouchAsync(client, database, playerId, cancellationToken);
        await Task.WhenAll(Enumerable.Range(0, CompetingTransactions).Select(_ =>
            TouchAsync(client, database, playerId, cancellationToken)));

        var fences = database.GetCollection<BattleAdmissionFenceDocument>("battle_admission_fences");
        BattleAdmissionFenceDocument current = await fences.Find(row => row.PlayerId == playerId)
            .SingleAsync(cancellationToken);
        if (current.Revision != CompetingTransactions + 1)
        {
            throw new InvalidDataException("Concurrent admission transactions lost a fence revision.");
        }

        await fences.UpdateOneAsync(row => row.PlayerId == playerId,
            Builders<BattleAdmissionFenceDocument>.Update.Set(row => row.Revision, 0),
            cancellationToken: cancellationToken);
        bool rejected = false;
        try
        {
            await TouchAsync(client, database, playerId, cancellationToken);
        }
        catch (InvalidDataException)
        {
            rejected = true;
        }
        current = await fences.Find(row => row.PlayerId == playerId).SingleAsync(cancellationToken);
        if (!rejected || current.Revision != 0)
        {
            throw new InvalidDataException("Admission fencing repaired damaged authority into a valid owner.");
        }
        Console.WriteLine("PASS: competing admission transactions conserve revisions and reject damaged fences");
    }

    private static async Task TouchAsync(MongoClient client, IMongoDatabase database, string playerId,
        CancellationToken cancellationToken)
    {
        using IClientSessionHandle session = await client.StartSessionAsync(cancellationToken: cancellationToken);
        await session.WithTransactionAsync(async (transaction, token) =>
        {
            await BattleAdmissionFence.AcquireAsync(database, transaction, [playerId], token);
            return true;
        }, new TransactionOptions(readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority),
            cancellationToken);
    }
}

using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Backend.Legacy;
using War.Persistence;

/// <summary>Publishes a successor between the two real database reads used for a manifest.</summary>
internal static class BattleManifestSnapshotRaceTests
{
    internal static async Task RunMongoAsync(string uri, string databaseName)
    {
        string playerId = new string('f', 32);
        var writer = new MongoClient(uri);
        IMongoDatabase database = writer.GetDatabase(databaseName);
        var players = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        LegacyPlayerDocument before = await players.Find(row => row.Id == playerId).SingleAsync();
        int publications = 0;
        Exception? publicationFailure = null;
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandSucceededEvent>(observed =>
        {
            if (observed.CommandName != "find" || Interlocked.CompareExchange(ref publications, 1, 0) != 0)
            {
                return;
            }
            try
            {
                // This separate client commits after the account response and before the allocation query.
                PublishSuccessor(writer, database, playerId);
            }
            catch (Exception failure)
            {
                publicationFailure = failure;
            }
        });

        var store = new BattleAllocationStore(new MongoClient(settings).GetDatabase(databaseName));
        IReadOnlyList<BattleAllocationAccountSnapshot> rows = await store.GetAccountSnapshotsAsync(
            [playerId, new string('d', 32)], CancellationToken.None);
        if (publicationFailure != null)
        {
            throw new InvalidOperationException("The between-query publication failed.", publicationFailure);
        }
        BattleAllocationAccountSnapshot captured = rows.Single(row => row.Account.Id == playerId);
        if (publications != 1 || captured.Account.Gold != before.Gold || captured.Allocation.CardIds.Count != 0)
        {
            throw new InvalidDataException("Paired manifest mixed its old account with successor allocation authority.");
        }
        LegacyPlayerDocument after = await players.Find(row => row.Id == playerId).SingleAsync();
        var current = await new BattleAllocationStore(database).Get(playerId, CancellationToken.None);
        if (after.Gold != before.Gold + 1 || current?.CardCounts.Single() != 2)
        {
            throw new InvalidDataException("The snapshot race did not actually commit its successor.");
        }
        Console.WriteLine("PASS: between-query successor publication cannot mix paired manifest snapshot generations");
    }

    private static void PublishSuccessor(MongoClient client, IMongoDatabase database, string playerId)
    {
        var cards = new CardManagerData();
        cards.CardData.Add("SLOWDOWN", new SavedCardData { Amount = 2 });
        using IClientSessionHandle session = client.StartSession();
        session.WithTransaction((transaction, cancellationToken) =>
        {
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers").UpdateOne(transaction,
                row => row.Id == playerId, Builders<LegacyPlayerDocument>.Update
                    .Inc(row => row.Gold, 1).Inc(row => row.Revision, 1)
                    .Set("Serialized.CardManagerData", PlayerState.Write(cards)), cancellationToken: cancellationToken);
            database.GetCollection<BattleAllocationDocument>("battle_allocations").UpdateOne(transaction,
                row => row.PlayerId == playerId, Builders<BattleAllocationDocument>.Update
                    .Set(row => row.CardIds, ["SLOWDOWN"]).Set(row => row.CardCounts, [2])
                    .Inc(row => row.Revision, 1), cancellationToken: cancellationToken);
            return true;
        }, new TransactionOptions(readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority));
    }
}

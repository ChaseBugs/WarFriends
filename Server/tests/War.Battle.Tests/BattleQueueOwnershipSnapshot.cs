using MongoDB.Bson;
using MongoDB.Driver;

/// <summary>Compares durable queue ownership without logging credentials or trusting HTTP codes alone.</summary>
internal sealed class BattleQueueOwnershipSnapshot
{
    private const int MaximumRowsPerCollection = 256;
    private static readonly string[] CollectionNames =
        ["battle_queue_tickets", "battle_pairs", "battle_queue_attempts"];
    private readonly Dictionary<string, BsonDocument[]> _rows;

    private BattleQueueOwnershipSnapshot(Dictionary<string, BsonDocument[]> rows)
    {
        _rows = rows;
    }

    internal static async Task<BattleQueueOwnershipSnapshot> CaptureAsync(
        IMongoDatabase database, CancellationToken cancellationToken)
    {
        var rows = new Dictionary<string, BsonDocument[]>();
        foreach (string name in CollectionNames)
        {
            var documents = await database.GetCollection<BsonDocument>(name)
                .Find(FilterDefinition<BsonDocument>.Empty)
                .Sort(Builders<BsonDocument>.Sort.Ascending("_id"))
                .Limit(MaximumRowsPerCollection + 1).ToListAsync(cancellationToken);
            if (documents.Count > MaximumRowsPerCollection)
            {
                throw new Exception("Queue restart fixture exceeded its bounded snapshot capacity.");
            }

            rows.Add(name, documents.ToArray());
        }

        return new BattleQueueOwnershipSnapshot(rows);
    }

    internal async Task VerifyUnchangedAsync(IMongoDatabase database, CancellationToken cancellationToken)
    {
        var afterRestart = await CaptureAsync(database, cancellationToken);
        foreach (string name in CollectionNames)
        {
            if (!_rows[name].SequenceEqual(afterRestart._rows[name]))
            {
                throw new Exception("Backend restart changed durable queue ownership in " + name + ".");
            }
        }
    }
}

using MongoDB.Driver;

namespace War.Persistence;

/// <summary>Provides shared transaction write conflicts for allocation, queue and rematch ownership.</summary>
public static class BattleAdmissionFence
{
    private const int MaximumParticipants = 2;
    private const int NamespaceExistsCode = 48;

    /// <summary>Creates the shared namespace before concurrent admission transactions start.</summary>
    public static async Task InitializeAsync(IMongoDatabase database, CancellationToken cancellationToken)
    {
        try
        {
            await database.CreateCollectionAsync("battle_admission_fences", cancellationToken: cancellationToken);
        }
        catch (MongoCommandException failure) when (failure.Code == NamespaceExistsCode)
        {
            // NamespaceExists means another startup already created this exact collection.
        }
    }

    /// <summary>Touches canonical participants in a stable order; the caller must own an active transaction.</summary>
    public static async Task AcquireAsync(IMongoDatabase database, IClientSessionHandle session,
        IReadOnlyList<string> playerIds, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(database);
        ArgumentNullException.ThrowIfNull(session);
        if (!session.IsInTransaction || playerIds == null || playerIds.Count is < 1 or > MaximumParticipants ||
            playerIds.Distinct(StringComparer.Ordinal).Count() != playerIds.Count ||
            playerIds.Any(id => !War.Shared.CanonicalGuid.IsCanonical(id)))
        {
            throw new InvalidDataException("Battle admission fencing requires a transaction and canonical participants.");
        }

        IMongoCollection<BattleAdmissionFenceDocument> fences = database
            .GetCollection<BattleAdmissionFenceDocument>("battle_admission_fences");
        foreach (string playerId in playerIds.Order(StringComparer.Ordinal))
        {
            BattleAdmissionFenceDocument? prior = await fences.Find(session, row => row.PlayerId == playerId)
                .SingleOrDefaultAsync(cancellationToken);
            if (prior == null)
            {
                await fences.InsertOneAsync(session, new BattleAdmissionFenceDocument { PlayerId = playerId, Revision = 1 },
                    cancellationToken: cancellationToken);
                continue;
            }
            if (prior.PlayerId != playerId || prior.Revision < 1 || prior.Revision == long.MaxValue)
            {
                throw new InvalidDataException("Invalid durable battle admission fence.");
            }

            UpdateResult changed = await fences.UpdateOneAsync(session,
                row => row.PlayerId == playerId && row.Revision == prior.Revision,
                Builders<BattleAdmissionFenceDocument>.Update.Inc(row => row.Revision, 1L),
                cancellationToken: cancellationToken);
            if (changed.ModifiedCount != 1)
            {
                throw new InvalidDataException("Battle admission ownership changed before reservation.");
            }
        }
    }
}

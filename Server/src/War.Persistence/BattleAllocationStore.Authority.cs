using MongoDB.Driver;
using War.Shared;

namespace War.Persistence;

public sealed partial class BattleAllocationStore
{
    /// <summary>Reads both participants' accounts and allocations at one transaction snapshot.</summary>
    public async Task<IReadOnlyList<BattleAllocationAccountSnapshot>> GetAccountSnapshotsAsync(
        IReadOnlyList<string> playerIds, CancellationToken cancellationToken)
    {
        if (playerIds == null || playerIds.Count != 2 || playerIds.Distinct(StringComparer.Ordinal).Count() != 2 ||
            playerIds.Any(id => !Guid.TryParseExact(id, "N", out Guid parsed) || parsed.ToString("N") != id))
        {
            throw new InvalidDataException("A canonical two-player authority roster is required.");
        }

        string[] identities = playerIds.ToArray();
        IMongoDatabase database = allocations.Database;
        var players = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        using IClientSessionHandle session = await database.Client.StartSessionAsync(
            cancellationToken: cancellationToken);
        return await session.WithTransactionAsync(async (transaction, token) =>
        {
            List<LegacyPlayerDocument> accounts = await players.Find(transaction,
                Builders<LegacyPlayerDocument>.Filter.In(row => row.Id, identities)).ToListAsync(token);
            List<BattleAllocationDocument> documents = await allocations.Find(transaction,
                Builders<BattleAllocationDocument>.Filter.In(row => row.PlayerId, identities)).ToListAsync(token);
            if (accounts.Count != identities.Length || documents.Count != identities.Length)
            {
                throw new InvalidDataException("The complete paired account/allocation snapshot is unavailable.");
            }

            var result = new List<BattleAllocationAccountSnapshot>();
            foreach (string identity in identities)
            {
                LegacyPlayerDocument account = accounts.Single(row => row.Id == identity);
                BattleAllocationDocument document = documents.Single(row => row.PlayerId == identity);
                BattleAllocationProjection allocation = BattleAllocationProjection.Validate(
                    new BattleAllocationProjection(document.PlayerId, document.CardIds, document.BuddyCardIds,
                        document.NormalUpgradeIndexes, document.SpecialUpgradeIndexes, document.EliteUpgradeIndexes)
                    {
                        CardCounts = document.CardCounts
                    });
                result.Add(new BattleAllocationAccountSnapshot(account, allocation));
            }
            return (IReadOnlyList<BattleAllocationAccountSnapshot>)result.AsReadOnly();
        }, new TransactionOptions(readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority),
            cancellationToken);
    }
}

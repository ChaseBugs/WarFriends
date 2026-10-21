using MongoDB.Driver;
using War.Persistence;

namespace War.Battle.Tests.Support;

/// <summary>Seeds trusted transport/gameplay fixtures without unnecessary password derivation.</summary>
internal static class LegacyTestAccounts
{
    /// <summary>Seeds or perturbs card inventory only inside an owned storage fixture.</summary>
    internal static Task SetCardsForTestAsync(
        IMongoDatabase database, string playerId, string json, CancellationToken cancellationToken) =>
        UpdateForTestAsync(database, playerId,
            Builders<LegacyPlayerDocument>.Update.Set("Serialized.CardManagerData", json), cancellationToken);

    /// <summary>Changes trusted fixture state and its revision without exposing a generic production writer.</summary>
    internal static Task UpdateForTestAsync(
        IMongoDatabase database,
        string playerId,
        UpdateDefinition<LegacyPlayerDocument> update,
        CancellationToken cancellationToken) =>
        database.GetCollection<LegacyPlayerDocument>("legacyPlayers").UpdateOneAsync(
            row => row.Id == playerId, update.Inc(row => row.Revision, 1), cancellationToken: cancellationToken);

    internal static Task InsertAsync(
        string uri, string databaseName, LegacyPlayerDocument player, CancellationToken cancellationToken) =>
        InsertAsync(new MongoClient(uri).GetDatabase(databaseName), player, cancellationToken);

    internal static Task InsertAsync(
        IMongoDatabase database, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(player.SessionHash))
        {
            player.SessionHash = LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken());
        }

        if (player.CreatedUtc == default)
        {
            player.CreatedUtc = DateTime.UtcNow;
        }

        if (player.SessionExpiresUtc == default)
        {
            player.SessionExpiresUtc = player.CreatedUtc.AddHours(1);
        }

        return database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .InsertOneAsync(player, cancellationToken: cancellationToken);
    }
}

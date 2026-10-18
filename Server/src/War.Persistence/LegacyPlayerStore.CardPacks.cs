using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    /// <summary>Publishes card inventory and wallet debit while the exact calculation inputs still match.</summary>
    public async Task<bool> TryPurchaseCardPackAsync(LegacyPlayerDocument snapshot,
        LegacyCardPackUpdate purchase, CancellationToken cancellationToken)
    {
        if (snapshot == null || snapshot.Serialized == null || purchase == null ||
            string.IsNullOrWhiteSpace(purchase.SerializedCards) || snapshot.Revision < 0 ||
            snapshot.Revision == long.MaxValue || snapshot.Gold < 0 || snapshot.WarBucks < 0 ||
            purchase.Gold < 0 || purchase.Gold > snapshot.Gold ||
            purchase.WarBucks < 0 || purchase.WarBucks > snapshot.WarBucks)
        {
            throw new InvalidDataException("Invalid card-pack wallet transition.");
        }

        const string CardPath = "Serialized.CardManagerData";
        var filters = Builders<LegacyPlayerDocument>.Filter;
        var filter = filters.Eq(player => player.Id, snapshot.Id) &
            filters.Eq(player => player.Gold, snapshot.Gold) &
            filters.Eq(player => player.WarBucks, snapshot.WarBucks) &
            filters.Eq(player => player.Level, snapshot.Level) &
            filters.Gte(player => player.Revision, 0) & filters.Lt(player => player.Revision, long.MaxValue);
        filter &= snapshot.Serialized.TryGetValue("CardManagerData", out string? previous)
            ? filters.Exists(CardPath) & filters.Eq(CardPath, previous)
            : filters.Exists(CardPath, false);
        var update = Builders<LegacyPlayerDocument>.Update.Set(CardPath, purchase.SerializedCards)
            .Set(player => player.Gold, purchase.Gold)
            .Set(player => player.WarBucks, purchase.WarBucks)
            .Inc(player => player.Revision, 1);
        UpdateResult result = await players.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        return result.ModifiedCount == 1;
    }
}

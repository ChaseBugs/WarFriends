using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.BattleServer;
using War.Protocol;

namespace War.Persistence;

public sealed partial class BattleResultStore
{
    private async Task ConsumeOrdinaryCardsAsync(IClientSessionHandle session, MatchManifest manifest,
        MatchSnapshot terminal, CancellationToken cancellationToken)
    {
        var accounts = _database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        var debits = new List<CardDebit>();
        foreach (var group in terminal.CardUsage.GroupBy(usage => usage.OwnerPlayerId))
        {
            var account = await accounts.Find(session, player => player.Id == group.Key)
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new InvalidDataException("Card consumption account is absent.");
            if (account.Serialized == null ||
                !account.Serialized.TryGetValue("CardManagerData", out string? previous) ||
                string.IsNullOrWhiteSpace(previous))
            {
                throw new InvalidDataException("Card consumption lacks durable ownership.");
            }

            IReadOnlyDictionary<string, int> owned = OrdinaryCardInventory.Read(previous);
            var root = JsonNode.Parse(previous)!.AsObject();
            foreach (BattleCardUsage usage in group)
            {
                ValidateCardDebit(manifest, terminal, usage);
                if (!owned.TryGetValue(usage.SourceCardId, out int count) || count < usage.Count)
                {
                    throw new InvalidDataException("Confirmed card use exceeds current durable ownership.");
                }

                // Card.RemoveCard preserves the zero-amount row; it never grants a replacement or refund.
                root["cardData"]![usage.SourceCardId]!["amount"] = checked(count - (int)usage.Count);
            }

            debits.Add(new CardDebit(group.Key, previous, root.ToJsonString()));
        }

        // Validate every consuming player before the first write. The result insert is the replay marker.
        foreach (CardDebit debit in debits)
        {
            var filter = Builders<LegacyPlayerDocument>.Filter.Eq(player => player.Id, debit.PlayerId) &
                Builders<LegacyPlayerDocument>.Filter.Eq("Serialized.CardManagerData", debit.Previous);
            var updated = await accounts.UpdateOneAsync(session, filter,
                Builders<LegacyPlayerDocument>.Update.Set("Serialized.CardManagerData", debit.Updated),
                cancellationToken: cancellationToken);
            if (updated.ModifiedCount != 1)
            {
                throw new InvalidDataException("Card consumption lost its durable inventory snapshot.");
            }
        }
    }

    private static void ValidateCardDebit(MatchManifest manifest, MatchSnapshot terminal, BattleCardUsage usage)
    {
        var allocation = manifest.Allocations?.SingleOrDefault(row => row.PlayerId == usage.OwnerPlayerId)
            ?? throw new InvalidDataException("Confirmed card use has no frozen inventory allocation.");
        string inventoryId = usage.SourceCardId;
        if (!allocation.CardIds.Contains(inventoryId, StringComparer.Ordinal))
        {
            // Legacy class aliases are unambiguous only for classes with one recovered source ID.
            if (!allocation.CardIds.Contains(usage.CardId, StringComparer.Ordinal) ||
                WarCardSourceIdentityCatalog.Resolve(usage.CardId) != usage.SourceCardId)
            {
                throw new InvalidDataException("Confirmed card use is absent from frozen ownership.");
            }

            inventoryId = usage.CardId;
        }

        var player = terminal.Players.Single(row => row.PlayerId == usage.OwnerPlayerId);
        int index = allocation.CardIds.Select((identity, ordinal) => (identity, ordinal))
            .Single(row => row.identity == inventoryId).ordinal;
        if (usage.Count != 1 || allocation.CardCounts[index] < usage.Count ||
            !player.SelectedCardIds.Contains(inventoryId))
        {
            throw new InvalidDataException("Card debit lacks a selected one-use hand receipt.");
        }
    }

    private sealed record CardDebit(string PlayerId, string Previous, string Updated);
}

using System.Text.Json.Nodes;
using System.Text.Json;
using War.Backend.Legacy.Time;
using War.Persistence.Legacy.State;
using War.Persistence;

namespace War.Backend.Legacy.Cards;

/// <summary>Owns the existing timed crafting admission and atomic subsystem commit.</summary>
public sealed class LegacyCraftingEndpoint
{
    private readonly LegacyPlayerStore _store;
    private readonly LegacyCatalog _catalog;

    public LegacyCraftingEndpoint(LegacyPlayerStore store, LegacyCatalog catalog)
    {
        _store = store;
        _catalog = catalog;
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.CraftCard"/> (176). No dedicated failure-branch case exists
    /// for this action in <c>ServerResponseHandler</c>, so a bare <c>Result</c> covers every
    /// refusal; only success needs a real field. <c>OnCraftCards</c> reads <c>mResponse["End"]</c>
    /// as an unguarded top-level index, so it is always emitted.
    /// </summary>
    /// <remarks>
    /// <c>CardCraftingManager.CraftWarcard</c> only ever offers exactly 3 cards of the *same*
    /// rarity — Bronze crafts into a random Silver (`CardCraftTimeSilver`, verified 30 minutes),
    /// Silver crafts into a random Gold (`CardCraftTimeGold`, verified 60 minutes); Gold has no
    /// higher tier and is never offered (`CardCraftingManager.canAnyWarcardBeCrafted` only checks
    /// Bronze/Silver counts). The constant names refer to the *output* tier, not the input — not a
    /// mismatch to "fix". Consumed cards are verified actually owned before being spent; a second
    /// `CraftCard` while one is already in progress reuses <c>AlreadyUpgrading</c>, the same "one
    /// timed slot" refusal already used for weapon/unit upgrade deliveries.
    /// </remarks>
    public async Task<IResult> CraftAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        string? cardsJson = request.Field("Cards");
        if (cardsJson == null)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        List<string>? cardIds;
        try
        {
            cardIds = JsonSerializer.Deserialize<List<string>>(cardsJson);
        }
        catch (JsonException)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }
        if (cardIds == null || cardIds.Count != 3)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        int? rarity = ReadInputRarity(cardIds);
        if (rarity == null)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        string craftBlobKey = rarity == 1 ? "CardCraftTimeSilver" : "CardCraftTimeGold";
        if (_catalog.ConstantInt(craftBlobKey) is not int minutes)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }

        var craft = PlayerState.Read<CraftData>(player.Serialized, "CraftData");
        int now = Now();
        if (craft.Cards.Count > 0 && craft.Start < craft.End)
        {
            return LegacyResponse.Failure(DatabaseResult.AlreadyUpgrading);
        }

        var cards = PlayerState.Read<CardManagerData>(player.Serialized, "CardManagerData");
        var consumedCounts = cardIds.GroupBy(id => id).ToDictionary(g => g.Key, g => g.Count());
        foreach (var (cardId, count) in consumedCounts)
        {
            if (!cards.CardData.TryGetValue(cardId, out var owned) || owned.Amount < count)
            {
                return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
            }
        }
        foreach (var (cardId, count) in consumedCounts)
        {
            cards.CardData[cardId].Amount -= count;
        }

        craft.Cards = cardIds;
        craft.Start = now;
        craft.End = now + minutes * 60;

        bool committed = await _store.TryReplaceSubsystemsAsync(player, new Dictionary<string, string>
        {
            ["CardManagerData"] = PlayerState.Write(cards),
            ["CraftData"] = PlayerState.Write(craft)
        }, cancellationToken);
        if (!committed)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["End"] = craft.End });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ClaimCraftedCard"/> (177). No dedicated failure-branch case
    /// exists for this action either. <c>OnClaimCraftedCard</c> reads <c>mResponse["CardId"]</c> as
    /// an unguarded top-level index, so it is always emitted on success. The awarded card is
    /// server-generated — a uniform random pick from the output rarity's pool, reusing the exact
    /// same <c>CardPoolsByRarity</c>/<c>PickCard</c> machinery <c>BuyCardPack</c> already verified —
    /// never a client assertion, since the request carries no fields at all to assert one with.
    /// </summary>
    public async Task<IResult> ClaimAsync(LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        var craft = PlayerState.Read<CraftData>(player.Serialized, "CraftData");
        if (craft.Cards.Count == 0)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        int now = Now();
        if (craft.End > now)
        {
            return LegacyResponse.Failure(DatabaseResult.TooSoonToActivate);
        }

        var inputRow = _catalog.Row("Google2u.CardDefinitions", "NAME", craft.Cards[0]);
        int inputRarity = inputRow == null ? 1 : LegacyBufferProcessor.RowInt(inputRow, "RARITY");
        int outputRarity = inputRarity == 1 ? 2 : 3;

        var pools = LegacyBufferProcessor.CardPoolsByRarity(_catalog);
        if (pools[outputRarity - 1].Count == 0)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
        string awardedCardId = LegacyBufferProcessor.PickCard(pools, outputRarity);

        var cards = PlayerState.Read<CardManagerData>(player.Serialized, "CardManagerData");
        if (!cards.CardData.TryGetValue(awardedCardId, out var slot))
        {
            slot = new SavedCardData();
            cards.CardData[awardedCardId] = slot;
        }
        slot.Amount++;
        craft.Cards = [];
        craft.Start = 0;
        craft.End = 0;

        bool committed = await _store.TryReplaceSubsystemsAsync(player, new Dictionary<string, string>
        {
            ["CardManagerData"] = PlayerState.Write(cards),
            ["CraftData"] = PlayerState.Write(craft)
        }, cancellationToken);
        if (!committed)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["CardId"] = awardedCardId });
    }

    private int? ReadInputRarity(IReadOnlyList<string> cardIds)
    {
        int? rarity = null;
        foreach (string cardId in cardIds)
        {
            var row = _catalog.Row("Google2u.CardDefinitions", "NAME", cardId);
            if (row == null)
            {
                return null;
            }

            int cardRarity = LegacyBufferProcessor.RowInt(row, "RARITY");
            if (cardRarity is not (1 or 2) || (rarity != null && rarity != cardRarity))
            {
                return null;
            }
            rarity = cardRarity;
        }
        return rarity;
    }

    private static int Now()
    {
        return LegacyClientTime.Read(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
    }
}

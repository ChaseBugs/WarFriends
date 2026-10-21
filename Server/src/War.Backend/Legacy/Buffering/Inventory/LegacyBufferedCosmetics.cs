using System.Text.Json.Nodes;
using War.Backend.Legacy.Progression;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedCosmetics
{
    /// <summary>
    /// Buys a cosmetic visual outright. Price, unlock level, VIP gating and purchasability come
    /// from <c>Google2u.PlayerVisuals</c> by the visual's <c>NAME</c> — the same authority model as
    /// <see cref="BuyWeapon"/>/<see cref="BuyUnit"/>.
    /// </summary>
    /// <remarks>
    /// <para>Unlike weapons/units, the client's own failure branch for this action passes back the
    /// *entire* <c>DecalManagerData</c> blob (<c>CamosManager.instance.LoadData(...)</c> on the
    /// whole string), not one item's state — so <see cref="DecalRollback"/> differs from
    /// <see cref="WeaponRollback"/>/<see cref="UnitRollback"/> in that respect.</para>
    /// <para><c>ExpiresOn</c> on success is a real, separate field from <c>Bought</c>: the client's
    /// success handler assigns it directly (<c>CamosManager.instance.data.visuals[DecalId].expiresOn
    /// = …</c>), and <c>PlayerVisual</c> uses it only for a time-limited rental/promotion window —
    /// a permanent purchase (everything this pass supports) reports <c>0</c>, which
    /// <c>remainingTime</c>/<c>startPromotion</c> correctly treat as "no active promo", while
    /// <c>Bought</c> stays true regardless.</para>
    /// <para><c>PARTS</c>/<c>DUPLICATEWARBUCKS</c> (an alternate parts-based unlock and a
    /// re-purchase-while-owned price) are not implemented — this pass covers a first, direct
    /// Warbucks/Gold purchase only.</para>
    /// </remarks>
    internal static (DatabaseResult, JsonObject) BuyDecal(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["Name"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        if (RowLong(payload, "discount") > 0)
        {
            return DecalRollback(request, state, DatabaseResult.NoDiscountFound);
        }

        var row = catalog.Row("Google2u.PlayerVisuals", "NAME", name);
        if (row == null)
        {
            return DecalRollback(request, state, DatabaseResult.PriceNotFound);
        }

        // BuyDecal's own evidenced failure set is NotEnoughWarbucks/NotEnoughLevel/NotEnoughGold/
        // DecalOnlyForVip (plus the generic NoDiscountFound) — DecalCategoryNotFound/DecalNotBought
        // belong to EquipDecal's failure set instead, so a non-shop-purchasable visual is folded
        // into PriceNotFound rather than reusing a code from a different action's evidenced set.
        if (!string.Equals(RowString(row, "PURCHASABLE"), "shop", StringComparison.OrdinalIgnoreCase))
        {
            return DecalRollback(request, state, DatabaseResult.PriceNotFound);
        }

        var existing = state.Decals.Visuals.GetValueOrDefault(name);
        if (existing is { ExpiresOn: < 0 })
        {
            throw new InvalidDataException("Stored cosmetic expiry exceeds the recovered Client field.");
        }

        if (existing is { Bought: true })
        {
            return DecalSuccess(request, name, existing.ExpiresOn);
        }

        if (row["ONLYFORVIP"]?.GetValue<bool>() == true && state.PlayerVip <= state.Now)
        {
            return DecalRollback(request, state, DatabaseResult.DecalOnlyForVip);
        }

        int requiredDisplayLevel = RowInt(row, "UNLOCKLEVEL");
        if (!LegacyRankGate.IsUnlocked(state.PlayerLevel, requiredDisplayLevel))
        {
            return DecalRollback(request, state, DatabaseResult.NotEnoughLevel);
        }

        long priceGold = RowLong(row, "PRICEGOLD");
        long priceWarbucks = RowLong(row, "PRICEWARBUCKS");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold))
            {
                return DecalRollback(request, state, DatabaseResult.NotEnoughGold);
            }
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks))
            {
                return DecalRollback(request, state, DatabaseResult.NotEnoughWarbucks);
            }
        }

        SavedPlayerVisual purchased = Slot(state.Decals.Visuals, name);
        purchased.Bought = true;
        purchased.ExpiresOn = 0;
        state.DecalsChanged();

        return DecalSuccess(request, name, 0);
    }

    private static (DatabaseResult, JsonObject) DecalSuccess(BufferedRequest request, string name, int expiresOn)
    {
        if (expiresOn < 0)
        {
            throw new InvalidDataException("Owned cosmetic expiry exceeds the recovered Client field.");
        }

        // ProcessBuffer indexes both fields even when this purchase does not change ownership.
        var success = Result(request.Action, DatabaseResult.Success);
        success["DecalId"] = name;
        success["ExpiresOn"] = expiresOn;
        return (DatabaseResult.Success, success);
    }

    private static (DatabaseResult, JsonObject) DecalRollback(
        BufferedRequest request, LegacyBufferedState state, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["DecalManagerData"] = PlayerState.Write(state.Decals);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }

    /// <summary>
    /// Equips an owned cosmetic. <c>CamosScreen.EquipPlayerVisual</c> sends the decal's bare
    /// <c>NAME</c> as <c>Request.data</c> — unlike <see cref="BuyDecal"/>, this is not a JSON
    /// payload.
    /// </summary>
    /// <remarks>
    /// <para><b>The slot a decal equips into is <c>Google2u.PlayerVisuals</c>' <c>CATEGORYID</c>
    /// field (0–3), not <c>CATEGORY</c>.</b> An earlier note in this file's history conflated the
    /// two: <c>CATEGORY</c> is <c>PlayerVisual.rarity</c> (Common..Legendary), a cosmetic-rarity
    /// label with no bearing on equip slots. <c>CATEGORYID</c> is the real
    /// <c>PlayerVisualCategory.categoryNumber</c> — confirmed two ways: the recovered
    /// <c>MainScene.unity</c> serializes exactly four <c>PlayerVisualCategory</c> components in
    /// <c>CamosManager.playerVisualCategories</c> order (index 0 <c>idPrefix: CAMOS_</c>, 1
    /// <c>HELMETS_</c>, 2 <c>HEAD_</c>, 3 <c>BANDS_</c>), and every exported <c>PlayerVisuals</c> row
    /// carries a <c>CATEGORYID</c> that matches its name's prefix exactly (e.g. every
    /// <c>CAMOS_*</c> row has <c>CATEGORYID=0</c>). <c>CamosManager.Equip()</c> writes
    /// <c>data.slots[owner.categoryNumber].equippedID = id</c>, so <c>CATEGORYID</c> is exactly the
    /// key this handler needs and requires no scene-order guesswork beyond what the client itself
    /// serializes.</para>
    /// <para><b>Ownership.</b> <c>PlayerVisual.isBought</c> also treats a Warbucks/Gold-free
    /// <c>PURCHASABLE=="shop"</c> item as always-owned (its <c>equipPart</c> button is enabled the
    /// same way a paid-and-bought item's is) — mirrored here so a zero-price cosmetic never needs an
    /// explicit purchase record. The <c>PARTS</c>-based duplicate-unlock clause of <c>isBought</c> is
    /// not reproduced, matching <see cref="BuyDecal"/>'s own scope note that the parts economy is not
    /// implemented yet. This pass does not seed any decal as pre-owned for a new account — the same
    /// gap already exists for starting weapons/units, not something this action should invent a fix
    /// for.</para>
    /// <para>Both evidenced failure codes reload the whole <c>DecalManagerData</c> blob, same as
    /// <see cref="BuyDecal"/>: <see cref="DatabaseResult.DecalCategoryNotFound"/> when the name does
    /// not resolve to a known catalog row at all (so no category can be determined), and
    /// <see cref="DatabaseResult.DecalNotBought"/> when the row resolves but the player does not own
    /// it.</para>
    /// </remarks>
    internal static (DatabaseResult, JsonObject) EquipDecal(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        string? name = request.Data;
        if (string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var row = catalog.Row("Google2u.PlayerVisuals", "NAME", name);
        if (row == null)
        {
            return EquipDecalRollback(request, state, DatabaseResult.DecalCategoryNotFound);
        }

        bool freeShopItem = RowLong(row, "PRICEGOLD") == 0 && RowLong(row, "PRICEWARBUCKS") == 0
            && string.Equals(RowString(row, "PURCHASABLE"), "shop", StringComparison.OrdinalIgnoreCase);
        var owned = state.Decals.Visuals.GetValueOrDefault(name);
        if (owned is not { Bought: true } && !freeShopItem)
        {
            return EquipDecalRollback(request, state, DatabaseResult.DecalNotBought);
        }

        int categoryId = RowInt(row, "CATEGORYID");
        if (!state.Decals.Slots.TryGetValue(categoryId, out var slot))
        {
            state.Decals.Slots[categoryId] = slot = new SavedPlayerVisualSlot();
        }
        slot.EquippedId = name;
        state.DecalsChanged();
        return Ok(request);
    }

    private static (DatabaseResult, JsonObject) EquipDecalRollback(
        BufferedRequest request, LegacyBufferedState state, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["DecalManagerData"] = PlayerState.Write(state.Decals);
        return (code, rollback);
    }
}

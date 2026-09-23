using System.Text.Json;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>One entry of the client's <c>Dictionary&lt;int, Request&gt;</c>.</summary>
/// <param name="Index">The dictionary key, which is the order the client queued the request in.</param>
/// <param name="Action">The <c>Request.action</c> field.</param>
/// <param name="Data">The <c>Request.data</c> field: either a bare string or a JSON document,
/// depending on the action. It is always transported as a JSON string.</param>
public sealed record BufferedRequest(int Index, DatabaseAction Action, string? Data);

/// <summary>A parsed buffer: the client's id for it and its requests in index order.</summary>
public sealed record ParsedBuffer(string BufferId, IReadOnlyList<BufferedRequest> Requests);

/// <summary>
/// Parses the two places buffered requests arrive: the <c>Requests</c> field of
/// <see cref="DatabaseAction.SendRequestBuffer"/>, and the <c>Buffers</c> field that
/// <see cref="DatabaseAction.GetPlayerData"/> carries for every buffer the client has not yet had
/// acknowledged.
/// </summary>
public static class LegacyBufferParser
{
    /// <summary>
    /// Guards against a client sending an unbounded buffer. The client's own buffers are formed
    /// from UI actions over a few seconds, so a legitimate one is small.
    /// </summary>
    public const int MaxRequestsPerBuffer = 256;

    /// <summary>Guards against an unbounded number of buffers replayed in one GetPlayerData.</summary>
    public const int MaxBuffers = 64;

    /// <summary>
    /// Parses <c>JsonConvert.SerializeObject(Dictionary&lt;int, Request&gt;)</c>, which is a JSON
    /// object whose keys are the integer indices: <c>{"0":{"action":104,"data":"M4A1"}}</c>.
    /// Returns requests sorted by index, which is the order the player performed them in.
    /// </summary>
    public static IReadOnlyList<BufferedRequest> ParseRequests(string? json)
    {
        var requests = new List<BufferedRequest>();
        if (string.IsNullOrEmpty(json)) return requests;
        if (JsonNode.Parse(json) is not JsonObject root) return requests;
        foreach (var (key, value) in root)
        {
            if (!int.TryParse(key, out int index) || value is not JsonObject entry) continue;
            // Newtonsoft writes the DatabaseAction enum as its integer by default.
            if (entry["action"]?.GetValue<int>() is not int actionId) continue;
            if (!Enum.IsDefined(typeof(DatabaseAction), actionId)) continue;
            requests.Add(new BufferedRequest(index, (DatabaseAction)actionId, entry["data"]?.GetValue<string>()));
            if (requests.Count > MaxRequestsPerBuffer) break;
        }
        requests.Sort((a, b) => a.Index.CompareTo(b.Index));
        return requests;
    }

    /// <summary>
    /// Parses <c>RequestBufferManager.GetJsonData()</c>, a JSON object of buffer id to serialized
    /// <c>RequestBuffer</c>. Only <c>requests</c> is needed; <c>alreadySent</c> is the client's own
    /// local bookkeeping and carries no authority here.
    /// </summary>
    public static IReadOnlyList<ParsedBuffer> ParseBuffers(string? json)
    {
        var buffers = new List<ParsedBuffer>();
        if (string.IsNullOrEmpty(json)) return buffers;
        if (JsonNode.Parse(json) is not JsonObject root) return buffers;
        foreach (var (bufferId, value) in root)
        {
            if (value is not JsonObject buffer || bufferId.Length is 0 or > 128) continue;
            var requests = ParseRequests(buffer["requests"]?.ToJsonString());
            if (requests.Count > 0) buffers.Add(new ParsedBuffer(bufferId, requests));
            if (buffers.Count >= MaxBuffers) break;
        }
        return buffers;
    }
}

/// <summary>
/// Applies buffered requests to a player, at most once each, and builds the results array the
/// client's <c>ProcessBuffer</c> consumes.
/// </summary>
/// <remarks>
/// <para><b>Result encoding.</b> Unlike <c>Player</c>/<c>PlayerData</c>, entries here are plain
/// JSON, not DynamoDB AttributeValues: <c>ProcessBuffer</c> reads them with <c>ParseIntToken</c>,
/// <c>ParseLongToken</c> and the single-argument <c>ParseString</c>. Nested blobs are JSON
/// documents escaped inside a string, because <c>LevelManager.UpdateWeapon</c> casts the token to
/// <c>string</c> before deserializing it.</para>
/// <para><b>On success the client needs only <c>ActionId</c> and <c>Result</c>.</b> Every other
/// field it reads on a success branch is null-guarded. The rollback fields are read on the failure
/// branches, so a failure result must carry the authoritative state the client should revert to.</para>
/// <para><b>Implemented actions are those whose effect is fully determined by the request and the
/// stored player state.</b> The economy actions additionally need the price/reward catalog from the
/// client's Google2u sheets; until that is imported, they return a failure rather than a fabricated
/// success, because a success the server did not actually apply would desynchronise the client's
/// wallet from the authoritative balance.</para>
/// </remarks>
public sealed class LegacyBufferProcessor(LegacyPlayerStore players, LegacyBufferStore buffers, LegacyCatalog catalog, ILogger<LegacyBufferProcessor> logger)
{
    /// <summary>
    /// Actions this server applies. Everything else in the client's 27-action buffered set is
    /// economy or cosmetic-catalog work this pass does not cover yet.
    /// </summary>
    private static readonly HashSet<DatabaseAction> Implemented =
    [
        DatabaseAction.WeaponWasShown,
        DatabaseAction.ArmyUnitWasShown,
        DatabaseAction.VisualWasShown,
        DatabaseAction.EquipWeapon,
        DatabaseAction.UpdateEquippedUnits,
        DatabaseAction.BuyWeapon,
        DatabaseAction.BuyUnit,
        DatabaseAction.BuyWeaponUpgrade,
        DatabaseAction.ActivateWeaponUpgrade,
        DatabaseAction.InstantWeaponUpgrade,
        DatabaseAction.BuyUnitUpgrade,
        DatabaseAction.ActivateUnitUpgrade,
        DatabaseAction.InstantUnitUpgrade,
        DatabaseAction.ActivateWeapon,
        DatabaseAction.InstantBuyWeapon,
        DatabaseAction.ActivateUnit,
        DatabaseAction.InstantBuyUnit,
        DatabaseAction.PromoteUnit,
        DatabaseAction.BuyDecal,
        DatabaseAction.EquipDecal,
        DatabaseAction.UpgradeEliteSlot,
        DatabaseAction.ConvertPartsToScraps,
        DatabaseAction.ConvertScrapsToParts,
        DatabaseAction.BuyCardPack,
        DatabaseAction.SaveLastSeenSquadChatTimeStamp
    ];

    /// <summary>
    /// Applies every request of one buffer in index order and returns the results array.
    /// </summary>
    public async Task<JsonArray> Apply(LegacyPlayerDocument player, ParsedBuffer buffer, CancellationToken ct)
    {
        var receipt = await buffers.Find(player.Id, buffer.BufferId, ct);
        var results = new JsonArray();
        var state = new WorkingState(player);

        foreach (var request in buffer.Requests)
        {
            var recorded = receipt?.Entries.FirstOrDefault(e => e.Index == request.Index);
            if (recorded is { Result: not null })
            {
                // Already applied on an earlier delivery of this buffer. Replay the same answer.
                results.Add(Result(request.Action, (DatabaseResult)recorded.Result.Value));
                continue;
            }

            if (!await buffers.TryClaim(player.Id, buffer.BufferId, request.Index, (int)request.Action, ct))
            {
                // Claimed but never completed: a previous attempt stopped between applying the
                // effect and recording it, so whether it landed is unknown. Re-applying could
                // double it, so report a failure and let the player retry deliberately.
                logger.LogWarning("Buffer {BufferId} request {Index} for player {PlayerId} was claimed but not completed; not re-applying.", buffer.BufferId, request.Index, player.Id);
                results.Add(Result(request.Action, DatabaseResult.ServerRespondedWithError));
                continue;
            }

            var outcome = Execute(request, state);
            await state.Flush(players, ct);
            await buffers.Complete(player.Id, buffer.BufferId, request.Index, (int)outcome.Code, ct);
            results.Add(outcome.Node);
        }
        return results;
    }

    private (DatabaseResult Code, JsonObject Node) Execute(BufferedRequest request, WorkingState state)
    {
        if (!Implemented.Contains(request.Action))
        {
            logger.LogInformation("Buffered action {Action} needs catalog data the server does not have; reporting failure rather than a hollow success.", request.Action);
            return (DatabaseResult.ServerMaintenance, Result(request.Action, DatabaseResult.ServerMaintenance));
        }
        try
        {
            return request.Action switch
            {
                DatabaseAction.WeaponWasShown => WeaponWasShown(request, state),
                DatabaseAction.ArmyUnitWasShown => ArmyUnitWasShown(request, state),
                DatabaseAction.VisualWasShown => VisualWasShown(request, state),
                DatabaseAction.EquipWeapon => EquipWeapon(request, state),
                DatabaseAction.UpdateEquippedUnits => UpdateEquippedUnits(request, state),
                DatabaseAction.BuyWeapon => BuyWeapon(request, state, catalog),
                DatabaseAction.BuyUnit => BuyUnit(request, state, catalog),
                DatabaseAction.BuyWeaponUpgrade => BuyWeaponUpgrade(request, state, catalog),
                DatabaseAction.ActivateWeaponUpgrade => ActivateWeaponUpgrade(request, state),
                DatabaseAction.InstantWeaponUpgrade => InstantWeaponUpgrade(request, state, catalog),
                DatabaseAction.BuyUnitUpgrade => BuyUnitUpgrade(request, state, catalog),
                DatabaseAction.ActivateUnitUpgrade => ActivateUnitUpgrade(request, state),
                DatabaseAction.InstantUnitUpgrade => InstantUnitUpgrade(request, state, catalog),
                DatabaseAction.ActivateWeapon => ActivateWeapon(request, state),
                DatabaseAction.InstantBuyWeapon => InstantBuyWeapon(request, state, catalog),
                DatabaseAction.ActivateUnit => ActivateUnit(request, state),
                DatabaseAction.InstantBuyUnit => InstantBuyUnit(request, state, catalog),
                DatabaseAction.PromoteUnit => PromoteUnit(request, state, catalog),
                DatabaseAction.BuyDecal => BuyDecal(request, state, catalog),
                DatabaseAction.EquipDecal => EquipDecal(request, state, catalog),
                DatabaseAction.UpgradeEliteSlot => UpgradeEliteSlot(request, state, catalog),
                DatabaseAction.ConvertPartsToScraps => ConvertPartsToScraps(request, state, catalog),
                DatabaseAction.ConvertScrapsToParts => ConvertScrapsToParts(request, state, catalog),
                DatabaseAction.BuyCardPack => BuyCardPack(request, state, catalog),
                DatabaseAction.SaveLastSeenSquadChatTimeStamp => SaveLastSeenSquadChatTimeStamp(request, state),
                _ => (DatabaseResult.ServerMaintenance, Result(request.Action, DatabaseResult.ServerMaintenance))
            };
        }
        catch (JsonException e)
        {
            logger.LogWarning("Buffered action {Action} carried unparsable data: {Error}", request.Action, e.GetType().Name);
            return (DatabaseResult.JsonFailure, Result(request.Action, DatabaseResult.JsonFailure));
        }
    }

    // The client sets savedWeapons[name].showed locally at WeaponScreen.cs:530; mirror it.
    private static (DatabaseResult, JsonObject) WeaponWasShown(BufferedRequest request, WorkingState state)
    {
        if (string.IsNullOrEmpty(request.Data)) return Fail(request, DatabaseResult.WrongPlayerData);
        Slot(state.Levels.SavedWeapons, request.Data).Showed = true;
        state.LevelsChanged();
        return Ok(request);
    }

    // The client sets savedArmies[name].showed locally at ArmyScreen.cs:398; mirror it.
    private static (DatabaseResult, JsonObject) ArmyUnitWasShown(BufferedRequest request, WorkingState state)
    {
        if (string.IsNullOrEmpty(request.Data)) return Fail(request, DatabaseResult.WrongPlayerData);
        Slot(state.Levels.SavedArmies, request.Data).Showed = true;
        state.LevelsChanged();
        return Ok(request);
    }

    // CamosScreen.WasShown clears notificate only; it does not touch showed. Mirror exactly.
    private static (DatabaseResult, JsonObject) VisualWasShown(BufferedRequest request, WorkingState state)
    {
        if (string.IsNullOrEmpty(request.Data)) return Fail(request, DatabaseResult.WrongPlayerData);
        Slot(state.Decals.Visuals, request.Data).Notificate = false;
        state.DecalsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Mirrors <c>PlayerAnalytics.lastSeenSquadChatTimestamp</c>'s setter (only ever advances, never
    /// regresses) by patching just this one field of the otherwise-unmodeled <c>PlayerAnalyticsData</c>
    /// blob — same targeted-field approach as <c>LegacyEndpoints.SetAnalyticsFlag</c>, so every other
    /// key already stored in that blob survives untouched.
    /// </summary>
    private static (DatabaseResult, JsonObject) SaveLastSeenSquadChatTimeStamp(BufferedRequest request, WorkingState state)
    {
        if (!int.TryParse(request.Data, out int timestamp)) return Fail(request, DatabaseResult.WrongPlayerData);
        if (timestamp > (state.Analytics["lastSeenSquadChatTimeStampDB"]?.GetValue<int>() ?? 0))
        {
            state.Analytics["lastSeenSquadChatTimeStampDB"] = timestamp;
            state.AnalyticsChanged();
        }
        return Ok(request);
    }

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
    private static (DatabaseResult, JsonObject) BuyDecal(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["Name"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        if (RowLong(payload, "discount") > 0) return DecalRollback(request, state, DatabaseResult.NoDiscountFound);

        var row = catalog.Row("Google2u.PlayerVisuals", "NAME", name);
        if (row == null) return DecalRollback(request, state, DatabaseResult.PriceNotFound);

        // BuyDecal's own evidenced failure set is NotEnoughWarbucks/NotEnoughLevel/NotEnoughGold/
        // DecalOnlyForVip (plus the generic NoDiscountFound) — DecalCategoryNotFound/DecalNotBought
        // belong to EquipDecal's failure set instead, so a non-shop-purchasable visual is folded
        // into PriceNotFound rather than reusing a code from a different action's evidenced set.
        if (!string.Equals(RowString(row, "PURCHASABLE"), "shop", StringComparison.OrdinalIgnoreCase))
            return DecalRollback(request, state, DatabaseResult.PriceNotFound);

        var existing = state.Decals.Visuals.GetValueOrDefault(name);
        if (existing is { Bought: true }) return Ok(request);

        if (row["ONLYFORVIP"]?.GetValue<bool>() == true && state.PlayerVip <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            return DecalRollback(request, state, DatabaseResult.DecalOnlyForVip);

        int unlockAtLevel = Math.Max(1, RowInt(row, "UNLOCKLEVEL"));
        if (state.PlayerLevel < unlockAtLevel) return DecalRollback(request, state, DatabaseResult.NotEnoughLevel);

        long priceGold = RowLong(row, "PRICEGOLD");
        long priceWarbucks = RowLong(row, "PRICEWARBUCKS");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold)) return DecalRollback(request, state, DatabaseResult.NotEnoughGold);
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks)) return DecalRollback(request, state, DatabaseResult.NotEnoughWarbucks);
        }

        Slot(state.Decals.Visuals, name).Bought = true;
        state.DecalsChanged();

        var success = Result(request.Action, DatabaseResult.Success);
        success["DecalId"] = name;
        success["ExpiresOn"] = 0;
        return (DatabaseResult.Success, success);
    }

    private static (DatabaseResult, JsonObject) DecalRollback(BufferedRequest request, WorkingState state, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["DecalManagerData"] = PlayerState.Write(state.Decals);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.BuyCardPack"/> (97). <c>CardManager.BuyCardPack</c>/
    /// <c>BuyThreeCards</c> both run their own client-side RNG *before* sending the request — the
    /// resulting card ids ride along in the payload's <c>cards</c> array purely as an assertion
    /// this handler never reads. Rewards must be server-owned, so the awarded cards are generated
    /// independently here from the same algorithm, using the server's own stored player level, not
    /// the client's local guess. A genuine client's UI never reconciles this: its success handler
    /// (`ServerResponseHandler`) reads <b>zero</b> response fields for this action, so whatever the
    /// client guessed locally stays on screen until the next full <c>GetPlayerData</c>, which is
    /// when the authoritative <c>CardManagerData</c> this handler writes actually reaches it. This
    /// mirrors how every other reward-granting action in this codebase treats client-reported
    /// outcomes: never authoritative, even when — as here — the wire contract has no way to correct
    /// the client immediately.
    /// </summary>
    /// <remarks>
    /// <para><c>Google2u.CardPacks</c> has exactly four rows — <c>BRONZE_CARDPACK</c>/
    /// <c>SILVER_CARDPACK</c>/<c>GOLD_CARDPACK</c> (priced in Gold) and <c>THREE_CARDS</c> (priced in
    /// Warbucks) — each just a <c>NAME</c>/<c>GOLD</c>/<c>WARBUCKS</c> price row with no composition
    /// data, so which cards a named pack can contain is a finite, evidenced mapping matched by name,
    /// not something read generically from the row (see <see cref="GenerateCardPack"/>).</para>
    /// <para>The evidenced failure set for this action is narrower than for weapons/units: only
    /// <c>NotEnoughWarbucks</c>/<c>CardPackNotFound</c>/<c>NoDiscountFound</c> are read by
    /// <c>ServerResponseHandler</c>'s case block for it. There is no <c>NotEnoughGold</c> case here
    /// at all — reused deliberately (not a naming mistake) as the insufficient-funds code even for
    /// the three Gold-priced packs, because it is the only code this action's block actually resyncs
    /// <c>CardManagerData</c>/the wallet for.</para>
    /// </remarks>
    private static (DatabaseResult, JsonObject) BuyCardPack(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? packName = payload?["cardPack"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(packName)) return Fail(request, DatabaseResult.WrongPlayerData);
        if (RowLong(payload, "discount") > 0) return CardPackRollback(request, state, DatabaseResult.NoDiscountFound);

        var packRow = catalog.Row("Google2u.CardPacks", "NAME", packName);
        if (packRow == null) return CardPackRollback(request, state, DatabaseResult.CardPackNotFound);

        var cardsWon = GenerateCardPack(packName, state.PlayerLevel, catalog);
        if (cardsWon == null) return CardPackRollback(request, state, DatabaseResult.CardPackNotFound);

        long priceGold = RowLong(packRow, "GOLD");
        long priceWarbucks = RowLong(packRow, "WARBUCKS");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold)) return CardPackRollback(request, state, DatabaseResult.NotEnoughWarbucks);
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks)) return CardPackRollback(request, state, DatabaseResult.NotEnoughWarbucks);
        }

        foreach (string cardName in cardsWon) Slot(state.Cards.CardData, cardName).Amount++;
        state.CardsChanged();
        return Ok(request);
    }

    private static (DatabaseResult, JsonObject) CardPackRollback(BufferedRequest request, WorkingState state, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["CardManagerData"] = PlayerState.Write(state.Cards);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }

    /// <summary>
    /// Reproduces <c>CardManager.GetCardsFromCardpack</c> (named packs) and
    /// <c>CardManager.BuyThreeCards</c> (<c>THREE_CARDS</c>) exactly, including the level-interpolated
    /// rarity roll (<c>GetRandomRarity</c>/<c>LevelManager.InterpolateNumbersBasedOnLevel</c>).
    /// Returns <c>null</c> for a pack name with no known composition (defensive only — the four rows
    /// in <c>Google2u.CardPacks</c> are exactly the four handled below).
    /// </summary>
    private static List<string>? GenerateCardPack(string packName, int playerLevel, LegacyCatalog catalog)
    {
        var pools = CardPoolsByRarity(catalog);
        if (pools[0].Count == 0 || pools[1].Count == 0 || pools[2].Count == 0) return null;

        // LevelManager.LowLevelTreshold/HighLevelTreshold — hardcoded client constants, not a
        // catalog row.
        double silverThreshold = Interpolate(playerLevel, 7, catalog.Constant("SilverCardRarityEarly") ?? 0, 10, catalog.Constant("SilverCardRarity") ?? 0);
        double goldThreshold = Interpolate(playerLevel, 7, catalog.Constant("GoldCardRarityEarly") ?? 0, 10, catalog.Constant("GoldCardRarity") ?? 0);
        int cardsInPack = catalog.ConstantInt("CardsInPack") ?? 10;

        var result = new List<string>(Math.Max(cardsInPack, 3));
        switch (packName)
        {
            case "BRONZE_CARDPACK":
            {
                int guaranteed = catalog.ConstantInt("BronzePackBronzeCards") ?? 0;
                for (int i = 0; i < guaranteed; i++) result.Add(PickCard(pools, 1));
                for (int i = guaranteed; i < cardsInPack; i++) result.Add(PickCard(pools, RandomRarity(1, 2, silverThreshold, goldThreshold)));
                break;
            }
            case "SILVER_CARDPACK":
            {
                int guaranteed = catalog.ConstantInt("SilverPackSilverCards") ?? 0;
                for (int i = 0; i < guaranteed; i++) result.Add(PickCard(pools, 2));
                for (int i = guaranteed; i < cardsInPack; i++) result.Add(PickCard(pools, RandomRarity(2, 3, silverThreshold, goldThreshold)));
                break;
            }
            case "GOLD_CARDPACK":
            {
                int guaranteed = catalog.ConstantInt("GoldPackGoldCards") ?? 0;
                for (int i = 0; i < guaranteed; i++) result.Add(PickCard(pools, 3));
                for (int i = guaranteed; i < cardsInPack; i++) result.Add(PickCard(pools, RandomRarity(2, 3, silverThreshold, goldThreshold)));
                break;
            }
            case "THREE_CARDS":
                // BuyThreeCards calls the parameterless AddRandomCard() three times — default
                // guaranteedRarity=Bronze/maxRarity=Gold, and it does not consult CardsInPack at all.
                for (int i = 0; i < 3; i++) result.Add(PickCard(pools, RandomRarity(1, 3, silverThreshold, goldThreshold)));
                break;
            default:
                return null;
        }
        return result;
    }

    private static double Interpolate(int level, int lowLevel, double lowValue, int highLevel, double highValue)
    {
        if (level <= lowLevel) return lowValue;
        if (level >= highLevel) return highValue;
        double t = (double)(level - lowLevel) / (highLevel - lowLevel);
        return (1 - t) * lowValue + t * highValue;
    }

    /// <summary>Reproduces <c>CardManager.GetRandomRarity</c> exactly: 1=Bronze, 2=Silver, 3=Gold.</summary>
    private static int RandomRarity(int guaranteedRarity, int maxRarity, double silverThreshold, double goldThreshold)
    {
        double min = 0, max = 1;
        if (guaranteedRarity == 2) min = silverThreshold;
        if (guaranteedRarity == 3) min = goldThreshold;
        if (maxRarity == 1) max = silverThreshold;
        if (maxRarity == 2) max = goldThreshold;
        double roll = min + Random.Shared.NextDouble() * (max - min);
        if (roll >= goldThreshold) return 3;
        return roll >= silverThreshold ? 2 : 1;
    }

    /// <summary>Internal (not private): also used by <c>LegacyEndpoints.ClaimCraftedCard</c> for the same uniform-pick-by-rarity RNG.</summary>
    internal static string PickCard(List<string>[] pools, int rarity)
    {
        var pool = pools[rarity - 1];
        return pool[Random.Shared.Next(pool.Count)];
    }

    /// <summary>
    /// <c>Google2u.CardDefinitions</c> rows filtered to <c>IMPLEMENTED=true</c> and grouped by
    /// <c>RARITY</c> (1=Bronze, 2=Silver, 3=Gold) — exactly <c>CardManager.OnPlayerDataLoaded</c>'s
    /// own population of <c>mCardsByQuality</c>. <c>FROMMISSION</c> is unrelated to pack pool
    /// membership and is not filtered on. Internal (not private): also used by
    /// <c>LegacyEndpoints.ClaimCraftedCard</c>.
    /// </summary>
    internal static List<string>[] CardPoolsByRarity(LegacyCatalog catalog)
    {
        var pools = new[] { new List<string>(), new List<string>(), new List<string>() };
        foreach (var row in catalog.Sheet("Google2u.CardDefinitions"))
        {
            if (row["IMPLEMENTED"]?.GetValue<bool>() != true) continue;
            int rarity = RowInt(row, "RARITY");
            if (rarity is < 1 or > 3) continue;
            if (RowString(row, "NAME") is string name) pools[rarity - 1].Add(name);
        }
        return pools;
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
    private static (DatabaseResult, JsonObject) EquipDecal(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        string? name = request.Data;
        if (string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var row = catalog.Row("Google2u.PlayerVisuals", "NAME", name);
        if (row == null) return EquipDecalRollback(request, state, DatabaseResult.DecalCategoryNotFound);

        bool freeShopItem = RowLong(row, "PRICEGOLD") == 0 && RowLong(row, "PRICEWARBUCKS") == 0
            && string.Equals(RowString(row, "PURCHASABLE"), "shop", StringComparison.OrdinalIgnoreCase);
        var owned = state.Decals.Visuals.GetValueOrDefault(name);
        if (owned is not { Bought: true } && !freeShopItem)
            return EquipDecalRollback(request, state, DatabaseResult.DecalNotBought);

        int categoryId = RowInt(row, "CATEGORYID");
        if (!state.Decals.Slots.TryGetValue(categoryId, out var slot))
            state.Decals.Slots[categoryId] = slot = new SavedPlayerVisualSlot();
        slot.EquippedId = name;
        state.DecalsChanged();
        return Ok(request);
    }

    private static (DatabaseResult, JsonObject) EquipDecalRollback(BufferedRequest request, WorkingState state, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["DecalManagerData"] = PlayerState.Write(state.Decals);
        return (code, rollback);
    }

    /// <summary>
    /// Moves a weapon into an inventory slot. The server checks ownership, which is why the client
    /// has a <see cref="DatabaseResult.WeaponNotBought"/> branch for this action carrying the state
    /// to revert to.
    /// </summary>
    private static (DatabaseResult, JsonObject) EquipWeapon(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["Name"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);
        if (!int.TryParse(payload["SlotIndex"]?.ToString(), out int slotIndex) || slotIndex is < 0 or > 32) return Fail(request, DatabaseResult.WrongPlayerData);
        int.TryParse(payload["Index"]?.ToString(), out int weaponIndex);

        if (!state.Levels.SavedWeapons.TryGetValue(name, out var weapon) || !(weapon.Bought || weapon.Borrowed))
        {
            // Hand back the authoritative weapon and inventory so the client reverts its slot.
            var rollback = Result(request.Action, DatabaseResult.WeaponNotBought);
            rollback["LevelName"] = name;
            rollback["Weapon"] = PlayerState.Write(weapon ?? new SavedWeaponSlots());
            rollback["InventoryData"] = PlayerState.Write(state.Inventory);
            return (DatabaseResult.WeaponNotBought, rollback);
        }

        state.Inventory.Slots[slotIndex] = new SerializedSlotDetail { Name = name, WeaponIndex = weaponIndex };
        state.InventoryChanged();
        state.RecordClientArmyPower(payload["ArmyPower"]);
        return Ok(request);
    }

    /// <summary>
    /// Replaces the equipped/was-equipped flags across the army. The client sends only the units
    /// that carry a flag, so units it omits must have theirs cleared.
    /// </summary>
    private static (DatabaseResult, JsonObject) UpdateEquippedUnits(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        if (payload?["equips"] is not JsonObject equips) return Fail(request, DatabaseResult.WrongPlayerData);

        // Reject the whole request if any named unit is not owned, and hand back the stored army so
        // the client can revert — this is the CantEquipUnit branch of its ProcessBuffer.
        foreach (var (unitName, _) in equips)
        {
            if (!state.Levels.SavedArmies.TryGetValue(unitName, out var unit) || !(unit.Bought || unit.Borrowed))
            {
                var stored = new JsonObject();
                foreach (var (name, slots) in state.Levels.SavedArmies) stored[name] = PlayerState.Write(slots);
                var rollback = Result(request.Action, DatabaseResult.CantEquipUnit);
                rollback["data"] = stored.ToJsonString();
                return (DatabaseResult.CantEquipUnit, rollback);
            }
        }

        foreach (var (_, slots) in state.Levels.SavedArmies)
        {
            slots.Equipped = false;
            slots.WasEquipped = false;
        }
        foreach (var (unitName, flags) in equips)
        {
            var slots = state.Levels.SavedArmies[unitName];
            slots.Equipped = flags?["equipped"]?.GetValue<bool>() ?? false;
            slots.WasEquipped = flags?["wasEquipped"]?.GetValue<bool>() ?? false;
        }
        state.LevelsChanged();
        state.RecordClientArmyPower(payload["armyPower"]);
        return Ok(request);
    }

    /// <summary>
    /// Buys a weapon outright. Price, unlock gating and purchasability come from the recovered
    /// <c>Google2u.WeaponUpgrades</c> catalog by the weapon's <c>NAME</c> — the client's own
    /// asserted <c>Warbucks</c>/<c>Gold</c>/<c>UnlockLevel</c> request fields are never trusted,
    /// the same authority model as every other buffered economy action.
    /// </summary>
    /// <remarks>
    /// <para>Scope: only <c>DELIVERTIME == 0</c> (instant) weapons. A weapon with a nonzero
    /// delivery time needs a separate completion action this pass does not implement, so it is
    /// refused with <see cref="DatabaseResult.ServerMaintenance"/> rather than starting a timer
    /// that can never finish.</para>
    /// <para>Any nonzero client-asserted <c>discount</c> is refused the same way: there is no
    /// verified server-side sale/event system yet to validate a discount percentage against.</para>
    /// <para><c>CANBEBOUGHT</c> is the row's level-gate field, not a boolean, despite the name —
    /// confirmed from <c>WeaponLevelsSetup.canBeBought =&gt; currentLevel.index &gt;=
    /// weaponUpgradesRow.CANBEBOUGHT - 1</c>. Re-buying an already-owned weapon is treated as an
    /// idempotent success (no charge), not an error: the shop UI never offers a buy action for a
    /// weapon already owned, so there is no evidenced failure code for that case to reuse.</para>
    /// </remarks>
    private static (DatabaseResult, JsonObject) BuyWeapon(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["Name"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        if (RowLong(payload, "discount") > 0) return WeaponRollback(request, state, name, DatabaseResult.NoDiscountFound);

        var row = catalog.Row("Google2u.WeaponUpgrades", "NAME", name);
        if (row == null) return WeaponRollback(request, state, name, DatabaseResult.PriceNotFound);

        if (!string.Equals(RowString(row, "PURCHASABLE"), "shop", StringComparison.OrdinalIgnoreCase))
            return WeaponRollback(request, state, name, DatabaseResult.WeaponNotBought);

        if (RowLong(row, "DELIVERTIME") > 0) return WeaponRollback(request, state, name, DatabaseResult.ServerMaintenance);

        var existing = state.Levels.SavedWeapons.GetValueOrDefault(name);
        if (existing is { Bought: true }) return Ok(request);

        int unlockAtLevel = Math.Max(1, RowInt(row, "CANBEBOUGHT"));
        if (state.PlayerLevel < unlockAtLevel) return WeaponRollback(request, state, name, DatabaseResult.NotEnoughLevel);

        long priceGold = RowLong(row, "PRICEGOLD");
        long priceWarbucks = RowLong(row, "PRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold)) return WeaponRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks)) return WeaponRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
        }

        Slot(state.Levels.SavedWeapons, name).Bought = true;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Confirms a pending weapon purchase delivery. Shares its response case with
    /// <see cref="BuyWeapon"/> (<c>WeaponWasShown</c>/<c>InstantBuyWeapon</c>/<c>ActivateWeapon</c>/
    /// <c>BuyWeapon</c>/<c>BuyWeaponUpgrade</c>/<c>InstantWeaponUpgrade</c>/
    /// <c>ActivateWeaponUpgrade</c> are all one client-side case block).
    /// </summary>
    /// <remarks>
    /// <c>WeaponLevelsSetup.Buy()</c> only sets <c>bought=true</c> immediately for a
    /// gold-priced weapon; a Warbucks-priced or free one instead starts a delivery
    /// (<c>weaponDeliveryTime = weaponUpgradesRow.DELIVERTIME</c>), and the client's own
    /// <c>BuyWeapon()</c> UI method unconditionally queues this action right after — calling the
    /// local <c>ActivateWeapon()</c> immediately when that delivery time is zero. Since every
    /// weapon in the current export has <c>DELIVERTIME == 0</c>, <see cref="BuyWeapon"/> already
    /// finishes the purchase itself; this handler's job is simply to be safe to call afterward —
    /// an already-bought weapon is an idempotent success, exactly like re-buying one.
    /// </remarks>
    private static (DatabaseResult, JsonObject) ActivateWeapon(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var weapon = state.Levels.SavedWeapons.GetValueOrDefault(name);
        if (weapon is { Bought: true }) return Ok(request);

        var delivery = state.Levels.WeaponDelivery;
        if (delivery.ItemId != name) return WeaponRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() < delivery.End) return WeaponRollback(request, state, name, DatabaseResult.TooSoonToActivate);

        Slot(state.Levels.SavedWeapons, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Pays Gold to confirm a pending weapon purchase delivery immediately. See <see cref="ActivateWeapon"/>.</summary>
    private static (DatabaseResult, JsonObject) InstantBuyWeapon(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var weapon = state.Levels.SavedWeapons.GetValueOrDefault(name);
        if (weapon is { Bought: true }) return Ok(request);

        var delivery = state.Levels.WeaponDelivery;
        if (delivery.ItemId != name) return WeaponRollback(request, state, name, DatabaseResult.WrongIndexToActivate);

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient || catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
            return WeaponRollback(request, state, name, DatabaseResult.ServerMaintenance);

        long remainingSeconds = Math.Max(0, delivery.End - DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price)) return WeaponRollback(request, state, name, DatabaseResult.NotEnoughGold);

        Slot(state.Levels.SavedWeapons, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// The rollback shape every BuyWeapon failure branch shares: the current (unpurchased)
    /// authoritative weapon slot and current wallet balances, so the client's optimistic UI
    /// change reverts to true server state instead of an echoed, unvalidated client guess.
    /// </summary>
    private static (DatabaseResult, JsonObject) WeaponRollback(BufferedRequest request, WorkingState state, string name, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["LevelName"] = name;
        rollback["Weapon"] = PlayerState.Write(state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots());
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }

    /// <summary>A sheet-row numeric field, tolerant of the JSON number being written as an integer
    /// or a double. Internal (not private): also used by <c>LegacyEndpoints</c>' card-crafting handlers.</summary>
    internal static long RowLong(JsonObject row, string field) =>
        row[field]?.AsValue().TryGetValue(out double value) == true ? (long)value : 0;

    internal static int RowInt(JsonObject row, string field) => (int)RowLong(row, field);

    internal static string? RowString(JsonObject row, string field) => row[field]?.GetValue<string>();

    /// <summary>
    /// Filters a per-unit upgrade sheet's rows to one upgrade track, reproducing
    /// <c>UpgradeSlot.maxPower</c>'s own <c>Tier / 10 == id</c> grouping: 0 is the normal track
    /// (<see cref="BuyUnitUpgrade"/>), 1 is <c>UpgradeSlotSpecial</c> (not implemented), 2 is
    /// <c>UpgradeSlotElite</c> (<see cref="UpgradeEliteSlot"/>). Confirmed against the recovered
    /// <c>DBUpgradeSlotsAssaulter</c> sheet, whose 136 rows split into exactly 101 track-0, 25
    /// track-1 and 6 track-2 rows in that contiguous order (plus 3 unused <c>TIER=-1</c> rows) —
    /// matching <c>Google2u.ArmyUpgrades</c>' own <c>STARTINGSPECIAL=101</c> for that unit exactly.
    /// A sheet with no <c>TIER</c> column at all (every weapon sheet) has no tracks, matching
    /// <c>UpgradeSlot.maxPower</c>'s own <c>!excel.HasColumn("Tier")</c> fallback of "every row
    /// belongs to the one track" — returned unfiltered regardless of the requested track id.
    /// </summary>
    private static IReadOnlyList<JsonObject> TrackRows(IReadOnlyList<JsonObject> sheet, int trackId)
    {
        if (sheet.Count == 0 || !sheet[0].ContainsKey("TIER")) return sheet;
        var result = new List<JsonObject>();
        foreach (var row in sheet)
        {
            long tier = RowLong(row, "TIER");
            if (tier >= 0 && tier / 10 == trackId) result.Add(row);
        }
        return result;
    }

    /// <summary>
    /// Buys an army unit outright. Same shape and authority model as <see cref="BuyWeapon"/>,
    /// priced from <c>Google2u.ArmyUpgrades</c> by the unit's <c>NAME</c> (its DBUpgradeSlots
    /// sheet type name, from <c>UpgradeSlots.GetSheetName()</c> = <c>excel.GetType().ToString()</c>).
    /// </summary>
    /// <remarks>
    /// Unlike weapons, unit rows carry no <c>PURCHASABLE</c> field at all — confirmed against the
    /// recovered <c>ArmyUpgrades</c> sheet — so there is no "not sold in the shop" gate to check;
    /// <c>CANBEBOUGHT</c> (again a level-gate index, not a boolean) is the only purchasability
    /// check. Same scope limits as <c>BuyWeapon</c>: instant delivery only, no discount validation.
    /// </remarks>
    private static (DatabaseResult, JsonObject) BuyUnit(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["Name"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        if (RowLong(payload, "discount") > 0) return UnitRollback(request, state, name, DatabaseResult.NoDiscountFound);

        var row = catalog.Row("Google2u.ArmyUpgrades", "NAME", name);
        if (row == null) return UnitRollback(request, state, name, DatabaseResult.PriceNotFound);

        if (RowLong(row, "DELIVERTIME") > 0) return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);

        var existing = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (existing is { Bought: true }) return Ok(request);

        int unlockAtLevel = Math.Max(1, RowInt(row, "CANBEBOUGHT"));
        if (state.PlayerLevel < unlockAtLevel) return UnitRollback(request, state, name, DatabaseResult.NotEnoughLevel);

        long priceGold = RowLong(row, "PRICEGOLD");
        long priceWarbucks = RowLong(row, "PRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold)) return UnitRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks)) return UnitRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
        }

        Slot(state.Levels.SavedArmies, name).Bought = true;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Confirms a pending unit purchase delivery. See <see cref="ActivateWeapon"/> — identical reasoning, unit side.</summary>
    private static (DatabaseResult, JsonObject) ActivateUnit(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (unit is { Bought: true }) return Ok(request);

        var delivery = state.Levels.UnitDelivery;
        if (delivery.ItemId != name) return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() < delivery.End) return UnitRollback(request, state, name, DatabaseResult.TooSoonToActivate);

        Slot(state.Levels.SavedArmies, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Pays Gold to confirm a pending unit purchase delivery immediately. See <see cref="ActivateUnit"/>.</summary>
    private static (DatabaseResult, JsonObject) InstantBuyUnit(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (unit is { Bought: true }) return Ok(request);

        var delivery = state.Levels.UnitDelivery;
        if (delivery.ItemId != name) return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient || catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
            return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);

        long remainingSeconds = Math.Max(0, delivery.End - DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price)) return UnitRollback(request, state, name, DatabaseResult.NotEnoughGold);

        Slot(state.Levels.SavedArmies, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Promotes a unit to its next tier. Priced by nothing but a level gate: unlike every other
    /// action in this file, <c>UpgradeSlots.PromoteUnit()</c> has <b>no response reader at all</b>
    /// in the recovered client (confirmed: zero matches for "PromoteUnit" anywhere in
    /// <c>ServerResponseHandler.cs</c>) — so the returned <c>Result</c> code only needs to land on
    /// the correct side of the client's <c>&gt; 10</c> success/failure split; no rollback fields
    /// are ever read.
    /// </summary>
    /// <remarks>
    /// Gate is the player's <c>Level</c> against <c>Google2u.ArmyUpgrades</c>'
    /// <c>UNLOCKTIER2..UNLOCKTIER6</c> (tier 6 is max — <c>UpgradeSlots.GetUnlockTierLevel</c>
    /// returns the sentinel <c>999</c> beyond it, which no player level can ever reach). Current
    /// tier is <c>SavedArmySlots.Tier</c> if nonzero, else the row's <c>STARTINGTIER</c> — matching
    /// <c>UpgradeSlots.actualTier</c>'s own "0 means not yet set" fallback.
    /// </remarks>
    private static (DatabaseResult, JsonObject) PromoteUnit(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var row = catalog.Row("Google2u.ArmyUpgrades", "NAME", name);
        if (row == null) return Fail(request, DatabaseResult.PriceNotFound);

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (unit is not { Bought: true }) return Fail(request, DatabaseResult.WrongIndexToActivate);

        int currentTier = unit.Tier != 0 ? unit.Tier : RowInt(row, "STARTINGTIER");
        int unlockAtLevel = GetUnlockTierLevel(row, currentTier);
        if (state.PlayerLevel < unlockAtLevel) return Fail(request, DatabaseResult.NotEnoughLevel);

        Slot(state.Levels.SavedArmies, name).Tier = currentTier + 1;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Reproduces <c>UpgradeSlots.GetUnlockTierLevel</c> exactly, including its tier-6-max sentinel.</summary>
    private static int GetUnlockTierLevel(JsonObject row, int tier) => tier switch
    {
        1 => RowInt(row, "UNLOCKTIER2"),
        2 => RowInt(row, "UNLOCKTIER3"),
        3 => RowInt(row, "UNLOCKTIER4"),
        4 => RowInt(row, "UNLOCKTIER5"),
        5 => RowInt(row, "UNLOCKTIER6"),
        > 5 => 999,
        _ => 0
    };

    /// <summary>
    /// Answers <see cref="DatabaseAction.UpgradeEliteSlot"/> (209). Confirmed by source: the elite
    /// track's per-level row (<see cref="TrackRows"/>, track 2) repurposes the same two price
    /// columns the normal track uses for currency: <c>NEXTUPGRADEPRICEGOLD</c> is actually the
    /// <b>Elite Parts</b> required (<c>UpgradeSlotElite.upgradePriceParts</c>), and
    /// <c>NEXTUPGRADEPRICE</c> is the <b>Warbucks</b> price to buy the level outright instead of
    /// grinding parts (<c>ArmyScreen.UpgradeUnitElite</c>) — column names are exactly as recovered,
    /// not renamed. <c>ArmyScreen.BuyUnitElite</c>/<c>UpgradeUnitElite</c> both always assert
    /// <c>SpentParts == upgradePriceParts</c> and decrement <c>currentParts</c> by that amount
    /// regardless of which path is used (clamped at 0 here — a defensive floor, not new gameplay
    /// logic, since the client's own unclamped local subtraction can go negative). No client-visible
    /// discount field exists for this action (unlike <c>BuyWeaponUpgrade</c>/<c>BuyUnitUpgrade</c>'s
    /// <c>discount</c>), so <c>SpentWarbucks</c> must be exactly <c>0</c> or the row's undiscounted
    /// price — <c>OfferManager.DiscountedUnit</c>'s special-offer system is untraced and out of
    /// scope, matching every other discount/offer path in this file. None of this action's evidenced
    /// failure branches (<c>WrongIndexToActivate</c>/<c>NotEnoughWarbucks</c>/<c>NotEnoughParts</c>/
    /// <c>IncorrectValuesOnClient</c>) read any response field — each just shows an error dialog and
    /// forces a relog, which re-syncs everything via a fresh <c>GetPlayerData</c> — so a bare
    /// <c>Result</c> is the entire failure contract, unlike most other economy actions in this file.
    /// </summary>
    private static (DatabaseResult, JsonObject) UpgradeEliteSlot(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var armyRow = catalog.Row("Google2u.ArmyUpgrades", "NAME", name);
        if (armyRow == null || RowInt(armyRow, "STARTINGELITE") <= 0) return Fail(request, DatabaseResult.WrongIndexToActivate);

        var eliteRows = TrackRows(catalog.Sheet(name), 2);
        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        if (RowInt(payload, "BoughtIndex") != unit.EliteSlot) return Fail(request, DatabaseResult.WrongIndexToActivate);
        if (eliteRows.Count == 0 || unit.EliteSlot >= eliteRows.Count) return Fail(request, DatabaseResult.WrongIndexToActivate);

        var row = eliteRows[unit.EliteSlot];
        long requiredParts = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long fullPrice = RowLong(row, "NEXTUPGRADEPRICE");

        if (RowLong(payload, "SpentParts") != requiredParts) return Fail(request, DatabaseResult.IncorrectValuesOnClient);
        long spentWarbucks = RowLong(payload, "SpentWarbucks");
        if (spentWarbucks != 0 && spentWarbucks != fullPrice) return Fail(request, DatabaseResult.IncorrectValuesOnClient);

        if (spentWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(spentWarbucks)) return Fail(request, DatabaseResult.NotEnoughWarbucks);
        }
        else if (unit.Parts < requiredParts)
        {
            return Fail(request, DatabaseResult.NotEnoughParts);
        }

        var slot = Slot(state.Levels.SavedArmies, name);
        slot.Parts = Math.Max(0, slot.Parts - (int)requiredParts);
        slot.EliteSlot++;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ConvertPartsToScraps"/> (208). Sells all of a unit's
    /// accumulated Elite Parts for Scraps at <c>Google2u.Constants.PartToScrapsSell</c> (verified
    /// <c>5</c>: 1 part = 5 scraps) — <c>ArmyLeftBuffDialog.BuffButtonConvertToScrapsClick</c> always
    /// converts the entire current amount, never a partial one, so the client's asserted
    /// <c>PartsToConvert</c>/<c>Scraps</c> must match the server's own stored parts count and
    /// recomputed total exactly, or the request is refused as <c>IncorrectPartsAmount</c> rather
    /// than trusting either client number.
    /// </summary>
    private static (DatabaseResult, JsonObject) ConvertPartsToScraps(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var armyRow = catalog.Row("Google2u.ArmyUpgrades", "NAME", name);
        if (armyRow == null || RowInt(armyRow, "STARTINGELITE") <= 0) return Fail(request, DatabaseResult.EliteSlotLocked);
        if (catalog.Constant("PartToScrapsSell") is not double sellRate) return Fail(request, DatabaseResult.ServerMaintenance);

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        int currentParts = unit.Parts;
        int expectedScraps = (int)((float)currentParts * (float)sellRate);
        if (currentParts <= 0 || RowInt(payload, "PartsToConvert") != currentParts || RowLong(payload, "Scraps") != expectedScraps)
            return Fail(request, DatabaseResult.IncorrectPartsAmount);

        Slot(state.Levels.SavedArmies, name).Parts = 0;
        state.AddScraps(expectedScraps);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ConvertScrapsToParts"/> (207). Fills a unit's Elite Parts
    /// the rest of the way to its current elite level's requirement, spending Scraps at
    /// <c>Google2u.Constants.PartToScrapsUpgrade</c> (verified <c>24</c> scraps per missing part) —
    /// <c>ArmyLeftBuffDialog.BuffButtonConvertToPartsClick</c> always fills the gap completely, so
    /// there is nothing to assert from the client: <c>Request.data</c> is just the unit's bare sheet
    /// name, matching <c>UpgradeSlots.GetSheetName()</c> being passed directly as <c>objData</c>, not
    /// wrapped in JSON like most other buffered payloads in this file.
    /// </summary>
    private static (DatabaseResult, JsonObject) ConvertScrapsToParts(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        string? name = request.Data;
        if (string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var armyRow = catalog.Row("Google2u.ArmyUpgrades", "NAME", name);
        if (armyRow == null || RowInt(armyRow, "STARTINGELITE") <= 0) return Fail(request, DatabaseResult.WrongIndexToActivate);

        var eliteRows = TrackRows(catalog.Sheet(name), 2);
        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        if (eliteRows.Count == 0 || unit.EliteSlot >= eliteRows.Count) return Fail(request, DatabaseResult.WrongIndexToActivate);

        var row = eliteRows[unit.EliteSlot];
        long upgradePriceParts = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long missingParts = upgradePriceParts - unit.Parts;
        if (missingParts <= 0) return Fail(request, DatabaseResult.WrongIndexToActivate);

        if (catalog.Constant("PartToScrapsUpgrade") is not double upgradeRate) return Fail(request, DatabaseResult.ServerMaintenance);
        long requiredScraps = (long)((float)missingParts * (float)upgradeRate);
        if (!state.TrySpendScraps(requiredScraps)) return Fail(request, DatabaseResult.NotEnoughScraps);

        Slot(state.Levels.SavedArmies, name).Parts = (int)upgradePriceParts;
        state.LevelsChanged();
        return Ok(request);
    }

    private static (DatabaseResult, JsonObject) UnitRollback(BufferedRequest request, WorkingState state, string name, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["LevelName"] = name;
        rollback["Unit"] = PlayerState.Write(state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots());
        rollback["unitDelivery"] = PlayerState.Write(state.Levels.UnitDelivery);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }

    /// <summary>
    /// Starts a timed unit upgrade delivery for the unit's <b>normal</b> upgrade track. Same
    /// pattern as <see cref="BuyWeaponUpgrade"/>: price/delivery time from the unit's own
    /// per-level <c>Google2u.DBUpgradeSlots&lt;Type&gt;</c> sheet (confirmed against
    /// <c>DBUpgradeSlotsAssaulter</c>: 136 rows, same <c>NEXTUPGRADEPRICE</c>/
    /// <c>NEXTUPGRADEPRICEGOLD</c>/<c>DELIVERYTIME</c> field names as the per-weapon sheets), at
    /// the row index equal to the unit's current <c>BoughtIndex</c>.
    /// </summary>
    /// <remarks>
    /// <para>The client also has a <b>special</b> upgrade track (<c>UpgradeSlots.upgradeSlotSpecial</c>,
    /// requested with <c>IsSpecial=1</c>, tracked by <c>SavedArmySlots.specialSlot</c>), priced from
    /// the <i>same</i> per-unit sheet at a different row range — see <see cref="TrackRows"/>. It
    /// remains refused here: reproducing <c>UpgradeSlots.actualMaxLevel</c>'s further tier-gating of
    /// that track (itself gated by <see cref="PromoteUnit"/>'s tier) is out of scope for this pass.
    /// </para>
    /// <para><b>Found and fixed a real bug while tracing that track</b>: the per-unit sheet's row
    /// count is <i>not</i> the normal track's true maximum whenever a unit also has special/elite
    /// rows appended after it (confirmed on <c>DBUpgradeSlotsAssaulter</c>: 136 raw rows split into
    /// 101 normal + 25 special + 6 elite + 3 unused padding, via the row's own <c>TIER</c> column —
    /// <c>UpgradeSlot.maxPower</c> counts only rows where <c>Tier / 10</c> matches the track).
    /// Using the raw row count as the ceiling would have let a sufficiently-leveled unit buy past
    /// its real normal-track max and silently price from a special/elite row instead. See
    /// <see cref="TrackRows"/>.</para>
    /// </remarks>
    private static (DatabaseResult, JsonObject) BuyUnitUpgrade(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);
        if (RowString(payload, "IsSpecial") == "1") return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);
        if (RowLong(payload, "discount") > 0) return UnitRollback(request, state, name, DatabaseResult.NoDiscountFound);

        var rows = TrackRows(catalog.Sheet(name), 0);
        if (rows.Count == 0) return UnitRollback(request, state, name, DatabaseResult.PriceNotFound);

        // Unlike the weapon-side failure set, the client's BuyUnit/upgrade case block has no
        // WeaponNotBought-equivalent code for "you don't own this" — the shop UI never offers an
        // upgrade action for an unowned unit. An unowned unit's BoughtIndex is always its zero
        // default, so a genuine client would never assert a match here either way; treat it as
        // the same state-mismatch case as an outdated BoughtIndex.
        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        if (!unit.Bought || RowInt(payload, "BoughtIndex") != unit.BoughtIndex) return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        if (unit.BoughtIndex >= rows.Count) return UnitRollback(request, state, name, DatabaseResult.AlreadyMaximumUpgrade);
        if (!string.IsNullOrEmpty(state.Levels.UnitDelivery.ItemId)) return UnitRollback(request, state, name, DatabaseResult.AlreadyUpgrading);

        var row = rows[unit.BoughtIndex];
        long priceGold = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long priceWarbucks = RowLong(row, "NEXTUPGRADEPRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold)) return UnitRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks)) return UnitRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
        }

        long deliverySeconds = RowLong(row, "DELIVERYTIME");
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var delivery = state.Levels.UnitDelivery;
        delivery.ItemId = name;
        delivery.BoughtIndex = unit.BoughtIndex;
        delivery.Start = now;
        delivery.End = now + deliverySeconds;
        delivery.ActivationNeeded = true;
        state.LevelsChanged();

        var success = Result(request.Action, DatabaseResult.Success);
        success["DeliveryTime"] = deliverySeconds;
        return (DatabaseResult.Success, success);
    }

    /// <summary>Completes a unit upgrade delivery once its timer has naturally elapsed. No charge.</summary>
    private static (DatabaseResult, JsonObject) ActivateUnitUpgrade(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var delivery = state.Levels.UnitDelivery;
        if (delivery.ItemId != name || delivery.BoughtIndex != RowInt(payload, "BoughtIndex"))
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() < delivery.End)
            return UnitRollback(request, state, name, DatabaseResult.TooSoonToActivate);

        Slot(state.Levels.SavedArmies, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Pays Gold to complete a unit upgrade delivery immediately. Same formula as <see cref="InstantWeaponUpgrade"/>.</summary>
    private static (DatabaseResult, JsonObject) InstantUnitUpgrade(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var delivery = state.Levels.UnitDelivery;
        if (delivery.ItemId != name || delivery.BoughtIndex != RowInt(payload, "BoughtIndex"))
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient || catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
            return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);

        long remainingSeconds = Math.Max(0, delivery.End - DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price)) return UnitRollback(request, state, name, DatabaseResult.NotEnoughGold);

        Slot(state.Levels.SavedArmies, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Starts a timed weapon upgrade delivery. Price and delivery time come from the weapon's own
    /// per-level Google2u sheet, whose type name is the same as the weapon's (e.g.
    /// <c>Google2u.AssaultRifle_AK47</c>), row <c>NEXTUPGRADEPRICE</c>/<c>NEXTUPGRADEPRICEGOLD</c>/
    /// <c>DELIVERYTIME</c> at the row index equal to the weapon's current <c>BoughtIndex</c>.
    /// </summary>
    /// <remarks>
    /// <para>This per-weapon sheet is a genuinely separate export from <c>Google2u.WeaponUpgrades</c>
    /// (the base weapon-info sheet) — confirmed from
    /// <c>WeaponLevelsSetup.uprgradesExcel = GetComponent&lt;Google2uComponentBase&gt;()</c>, a
    /// distinct component per weapon prefab. The map exporter captured essentially the full weapon
    /// (and, via <see cref="BuyUnitUpgrade"/>, unit) roster this way — an entirely unrecognised
    /// name is still the correct <see cref="DatabaseResult.PriceNotFound"/> case, not the expected
    /// common case. Field spelling is exactly as recovered: this sheet uses <c>DELIVERYTIME</c>,
    /// the base sheets use <c>DELIVERTIME</c> — not a typo to "fix".</para>
    /// <para>Only one weapon delivery is in flight at a time, matching the client's single shared
    /// <c>LevelManager.weaponDelivery</c> slot (not per-weapon): a second <c>BuyWeaponUpgrade</c>
    /// while one is pending is refused with <see cref="DatabaseResult.AlreadyUpgrading"/>. The
    /// client's own <c>BoughtIndex</c> assertion must match the server's stored value, or the
    /// request is stale relative to a change the server already applied
    /// (<see cref="DatabaseResult.WrongIndexToActivate"/>).</para>
    /// </remarks>
    private static (DatabaseResult, JsonObject) BuyWeaponUpgrade(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);
        if (RowLong(payload, "discount") > 0) return WeaponUpgradeRollback(request, state, name, DatabaseResult.NoDiscountFound);

        var rows = catalog.Sheet(name);
        if (rows.Count == 0) return WeaponUpgradeRollback(request, state, name, DatabaseResult.PriceNotFound);

        var weapon = state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots();
        if (!weapon.Bought) return WeaponUpgradeRollback(request, state, name, DatabaseResult.WeaponNotBought);
        if (RowInt(payload, "BoughtIndex") != weapon.BoughtIndex) return WeaponUpgradeRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        if (weapon.BoughtIndex >= rows.Count) return WeaponUpgradeRollback(request, state, name, DatabaseResult.AlreadyMaximumUpgrade);
        if (!string.IsNullOrEmpty(state.Levels.WeaponDelivery.ItemId)) return WeaponUpgradeRollback(request, state, name, DatabaseResult.AlreadyUpgrading);

        var row = rows[weapon.BoughtIndex];
        long priceGold = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long priceWarbucks = RowLong(row, "NEXTUPGRADEPRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold)) return WeaponUpgradeRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks)) return WeaponUpgradeRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
        }

        long deliverySeconds = RowLong(row, "DELIVERYTIME");
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var delivery = state.Levels.WeaponDelivery;
        delivery.ItemId = name;
        delivery.BoughtIndex = weapon.BoughtIndex;
        delivery.Start = now;
        delivery.End = now + deliverySeconds;
        delivery.ActivationNeeded = true;
        state.LevelsChanged();

        var success = Result(request.Action, DatabaseResult.Success);
        success["DeliveryTime"] = deliverySeconds;
        return (DatabaseResult.Success, success);
    }

    /// <summary>
    /// Completes a weapon upgrade delivery once its timer has naturally elapsed. No charge — the
    /// price was already paid when the delivery started (<see cref="BuyWeaponUpgrade"/>).
    /// </summary>
    private static (DatabaseResult, JsonObject) ActivateWeaponUpgrade(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var delivery = state.Levels.WeaponDelivery;
        if (delivery.ItemId != name || delivery.BoughtIndex != RowInt(payload, "BoughtIndex"))
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() < delivery.End)
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.TooSoonToActivate);

        Slot(state.Levels.SavedWeapons, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Pays Gold to complete a weapon upgrade delivery immediately, skipping the remaining wait.
    /// Price reproduces <c>MiscTools.ConvertTimeIntoGold</c>: <c>ceil(GoldCoefficient *
    /// minutes^GoldExpCoefficient * minutes)</c> over the seconds actually remaining, using the
    /// verified catalog constants — never the client's own <c>ExpectedPrice</c> assertion.
    /// </summary>
    private static (DatabaseResult, JsonObject) InstantWeaponUpgrade(BufferedRequest request, WorkingState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["LevelName"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);

        var delivery = state.Levels.WeaponDelivery;
        if (delivery.ItemId != name || delivery.BoughtIndex != RowInt(payload, "BoughtIndex"))
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.WrongIndexToActivate);

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient || catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.ServerMaintenance);

        long remainingSeconds = Math.Max(0, delivery.End - DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price)) return WeaponUpgradeRollback(request, state, name, DatabaseResult.NotEnoughGold);

        Slot(state.Levels.SavedWeapons, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Reproduces <c>MiscTools.ConvertTimeIntoGold</c> exactly.</summary>
    private static long ConvertTimeIntoGold(long seconds, double goldCoefficient, double goldExpCoefficient)
    {
        if (seconds <= 0) return 0;
        double minutes = seconds / 60.0;
        return (long)Math.Ceiling(goldCoefficient * Math.Pow(minutes, goldExpCoefficient) * minutes);
    }

    private static void ClearDelivery(ItemDelivery delivery)
    {
        delivery.ItemId = null;
        delivery.BoughtIndex = 0;
        delivery.Start = 0;
        delivery.End = 0;
        delivery.ActivationNeeded = false;
    }

    private static (DatabaseResult, JsonObject) WeaponUpgradeRollback(BufferedRequest request, WorkingState state, string name, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["LevelName"] = name;
        rollback["Weapon"] = PlayerState.Write(state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots());
        rollback["weaponDelivery"] = PlayerState.Write(state.Levels.WeaponDelivery);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }

    private static TSlot Slot<TSlot>(Dictionary<string, TSlot> map, string key) where TSlot : new()
    {
        if (!map.TryGetValue(key, out var slot)) map[key] = slot = new TSlot();
        return slot;
    }

    private static (DatabaseResult, JsonObject) Ok(BufferedRequest request) =>
        (DatabaseResult.Success, Result(request.Action, DatabaseResult.Success));

    private static (DatabaseResult, JsonObject) Fail(BufferedRequest request, DatabaseResult code) =>
        (code, Result(request.Action, code));

    private static JsonObject Result(DatabaseAction action, DatabaseResult result) =>
        new() { ["ActionId"] = (int)action, ["Result"] = (int)result };

    /// <summary>
    /// The player's blobs decoded once per buffer, with only the changed ones written back.
    /// </summary>
    private sealed class WorkingState(LegacyPlayerDocument document)
    {
        private LevelManagerData? levels;
        private InventoryData? inventory;
        private DecalManagerData? decals;
        private CardManagerData? cards;
        private JsonObject? analytics;
        private readonly HashSet<string> dirty = [];
        private int? clientArmyPower;
        private long goldDelta;
        private long warBucksDelta;
        private long scrapsDelta;

        public LevelManagerData Levels => levels ??= PlayerState.Read<LevelManagerData>(Blob("LevelManagerData"));
        public InventoryData Inventory => inventory ??= PlayerState.Read<InventoryData>(Blob("InventoryData"));
        public DecalManagerData Decals => decals ??= PlayerState.Read<DecalManagerData>(Blob("DecalManagerData"));
        public CardManagerData Cards => cards ??= PlayerState.Read<CardManagerData>(Blob("CardManagerData"));

        /// <summary>
        /// The raw, only-partially-modeled <c>PlayerAnalyticsData</c> blob. Read/write individual
        /// fields by name (see <see cref="SaveLastSeenSquadChatTimeStamp"/>) rather than round-tripping
        /// through a C# type that would silently drop every field this pass does not know about.
        /// </summary>
        public JsonObject Analytics => analytics ??= (JsonNode.Parse(Blob("PlayerAnalyticsData") ?? "") as JsonObject) ?? [];

        public void LevelsChanged() => dirty.Add("LevelManagerData");
        public void InventoryChanged() => dirty.Add("InventoryData");
        public void DecalsChanged() => dirty.Add("DecalManagerData");
        public void CardsChanged() => dirty.Add("CardManagerData");
        public void AnalyticsChanged() => dirty.Add("PlayerAnalyticsData");

        public int PlayerLevel => document.Level;

        /// <summary>The player's VIP expiration as a unix timestamp; 0 or past means not VIP.</summary>
        public long PlayerVip => document.Vip;
        public long CurrentGold => document.Gold + goldDelta;
        public long CurrentWarBucks => document.WarBucks + warBucksDelta;

        /// <summary>Debits Gold if the (already-pending) balance covers it. Never goes negative.</summary>
        public bool TrySpendGold(long amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            if (CurrentGold < amount) return false;
            goldDelta -= amount;
            return true;
        }

        /// <summary>Debits WarBucks if the (already-pending) balance covers it. Never goes negative.</summary>
        public bool TrySpendWarBucks(long amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            if (CurrentWarBucks < amount) return false;
            warBucksDelta -= amount;
            return true;
        }

        public long CurrentScraps => document.Scraps + scrapsDelta;

        /// <summary>Debits Scraps if the (already-pending) balance covers it. Never goes negative.</summary>
        public bool TrySpendScraps(long amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            if (CurrentScraps < amount) return false;
            scrapsDelta -= amount;
            return true;
        }

        public void AddScraps(long amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            scrapsDelta += amount;
        }

        /// <summary>
        /// Notes the army power the client asserted. It is stored for display and matchmaking
        /// continuity but is <b>not</b> authoritative: recomputing it needs the unit/weapon power
        /// values from the Google2u catalog. Until that lands, a client could understate or
        /// overstate it, so nothing that grants value may depend on it.
        /// </summary>
        public void RecordClientArmyPower(JsonNode? node)
        {
            if (node != null && int.TryParse(node.ToString(), out int power) && power >= 0) clientArmyPower = power;
        }

        private string? Blob(string key) => document.Serialized.GetValueOrDefault(key);

        public async Task Flush(LegacyPlayerStore store, CancellationToken ct)
        {
            foreach (string key in dirty)
            {
                string json = key switch
                {
                    "LevelManagerData" => PlayerState.Write(Levels),
                    "InventoryData" => PlayerState.Write(Inventory),
                    "DecalManagerData" => PlayerState.Write(Decals),
                    "CardManagerData" => PlayerState.Write(Cards),
                    "PlayerAnalyticsData" => Analytics.ToJsonString(),
                    _ => throw new InvalidOperationException($"No writer for blob '{key}'.")
                };
                document.Serialized[key] = json;
                await store.SetSerialized(document.Id, key, json, ct);
            }
            dirty.Clear();

            // Combined into one document write. Note: this collection has no cross-request
            // atomicity beyond the single-document update itself — the same limitation documented
            // on LegacyBufferStore's claim/complete pair applies here (a standalone Mongo can't
            // transact across concurrent requests for the same player). Buffer-index idempotency
            // prevents the same purchase from applying twice; it does not serialize two
            // *different*, concurrently-processed buffers spending against the same balance. A
            // Mongo replica set (already a stated prerequisite for economy settlement in
            // Server/README.md) is required before this is airtight under real concurrency.
            var updates = new List<UpdateDefinition<LegacyPlayerDocument>>();
            if (clientArmyPower is int power && power != document.ArmyPower)
            {
                updates.Add(Builders<LegacyPlayerDocument>.Update.Set(x => x.ArmyPower, power));
                document.ArmyPower = power;
                clientArmyPower = null;
            }
            if (goldDelta != 0)
            {
                updates.Add(Builders<LegacyPlayerDocument>.Update.Inc(x => x.Gold, goldDelta));
                document.Gold += goldDelta;
                goldDelta = 0;
            }
            if (warBucksDelta != 0)
            {
                updates.Add(Builders<LegacyPlayerDocument>.Update.Inc(x => x.WarBucks, warBucksDelta));
                document.WarBucks += warBucksDelta;
                warBucksDelta = 0;
            }
            if (scrapsDelta != 0)
            {
                updates.Add(Builders<LegacyPlayerDocument>.Update.Inc(x => x.Scraps, scrapsDelta));
                document.Scraps += scrapsDelta;
                scrapsDelta = 0;
            }
            if (updates.Count > 0) await store.Update(document.Id, Builders<LegacyPlayerDocument>.Update.Combine(updates), ct);
        }
    }
}

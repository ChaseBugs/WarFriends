using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;

namespace War.Backend.Legacy.Buffering.Cards;

internal static class LegacyBufferedCardPacks
{
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
    internal static (DatabaseResult, JsonObject) BuyCardPack(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? packName = LegacyBufferPayload.ReadString(payload?["cardPack"]);
        if (payload == null || string.IsNullOrEmpty(packName))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        if (RowLong(payload, "discount") > 0)
        {
            return CardPackRollback(request, state, DatabaseResult.NoDiscountFound);
        }

        var packRow = catalog.Row("Google2u.CardPacks", "NAME", packName);
        if (packRow == null)
        {
            return CardPackRollback(request, state, DatabaseResult.CardPackNotFound);
        }

        var cardsWon = GenerateCardPack(packName, state.PlayerLevel, catalog, state.Random);
        if (cardsWon == null)
        {
            return CardPackRollback(request, state, DatabaseResult.CardPackNotFound);
        }

        if (state.Cards.CardData == null || state.Cards.CardData.Values.Any(slot => slot == null || slot.Amount < 0))
        {
            return Fail(request, DatabaseResult.ServerMaintenance);
        }
        var rewards = cardsWon.GroupBy(identity => identity)
            .ToDictionary(group => group.Key, group => group.Count(), StringComparer.Ordinal);
        foreach (var reward in rewards)
        {
            int owned = state.Cards.CardData.TryGetValue(reward.Key, out var slot) ? slot.Amount : 0;
            if (owned > int.MaxValue - reward.Value)
            {
                return CardPackRollback(request, state, DatabaseResult.CardPackNotFound);
            }
        }

        long priceGold = RowLong(packRow, "GOLD");
        long priceWarbucks = RowLong(packRow, "WARBUCKS");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold))
            {
                return CardPackRollback(request, state, DatabaseResult.NotEnoughWarbucks);
            }
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks))
            {
                return CardPackRollback(request, state, DatabaseResult.NotEnoughWarbucks);
            }
        }

        foreach (var reward in rewards)
        {
            Slot(state.Cards.CardData, reward.Key).Amount += reward.Value;
        }
        state.CardsChanged();
        return Ok(request);
    }

    private static (DatabaseResult, JsonObject) CardPackRollback(
        BufferedRequest request, LegacyBufferedState state, DatabaseResult code)
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
    private static List<string>? GenerateCardPack(
        string packName, int playerLevel, LegacyCatalog catalog, Random random)
    {
        var pools = CardPoolsByRarity(catalog);
        if (pools[0].Count == 0 || pools[1].Count == 0 || pools[2].Count == 0)
        {
            return null;
        }

        // LevelManager.LowLevelTreshold/HighLevelTreshold — hardcoded client constants, not a
        // catalog row.
        double silverThreshold = Interpolate(playerLevel,
            (7, catalog.Constant("SilverCardRarityEarly") ?? 0), (10, catalog.Constant("SilverCardRarity") ?? 0));
        double goldThreshold = Interpolate(playerLevel,
            (7, catalog.Constant("GoldCardRarityEarly") ?? 0), (10, catalog.Constant("GoldCardRarity") ?? 0));
        int cardsInPack = catalog.ConstantInt("CardsInPack") ?? 10;

        var result = new List<string>(Math.Max(cardsInPack, 3));
        switch (packName)
        {
            case "BRONZE_CARDPACK":
            {
                int guaranteed = catalog.ConstantInt("BronzePackBronzeCards") ?? 0;
                for (int i = 0; i < guaranteed; i++)
                {
                    result.Add(PickCard(pools, 1, random));
                }
                for (int i = guaranteed; i < cardsInPack; i++)
                {
                    result.Add(PickCard(pools, RandomRarity(1, 2, (silverThreshold, goldThreshold), random), random));
                }
                break;
            }
            case "SILVER_CARDPACK":
            {
                int guaranteed = catalog.ConstantInt("SilverPackSilverCards") ?? 0;
                for (int i = 0; i < guaranteed; i++)
                {
                    result.Add(PickCard(pools, 2, random));
                }
                for (int i = guaranteed; i < cardsInPack; i++)
                {
                    result.Add(PickCard(pools, RandomRarity(2, 3, (silverThreshold, goldThreshold), random), random));
                }
                break;
            }
            case "GOLD_CARDPACK":
            {
                int guaranteed = catalog.ConstantInt("GoldPackGoldCards") ?? 0;
                for (int i = 0; i < guaranteed; i++)
                {
                    result.Add(PickCard(pools, 3, random));
                }
                for (int i = guaranteed; i < cardsInPack; i++)
                {
                    result.Add(PickCard(pools, RandomRarity(2, 3, (silverThreshold, goldThreshold), random), random));
                }
                break;
            }
            case "THREE_CARDS":
                // BuyThreeCards calls the parameterless AddRandomCard() three times — default
                // guaranteedRarity=Bronze/maxRarity=Gold, and it does not consult CardsInPack at all.
                for (int i = 0; i < 3; i++)
                {
                    result.Add(PickCard(pools, RandomRarity(1, 3, (silverThreshold, goldThreshold), random), random));
                }
                break;
            default:
                return null;
        }
        return result;
    }

    private static double Interpolate(int level, (int Level, double Value) low, (int Level, double Value) high)
    {
        if (level <= low.Level)
        {
            return low.Value;
        }
        if (level >= high.Level)
        {
            return high.Value;
        }
        double t = (double)(level - low.Level) / (high.Level - low.Level);
        return (1 - t) * low.Value + t * high.Value;
    }

    /// <summary>Reproduces <c>CardManager.GetRandomRarity</c> exactly: 1=Bronze, 2=Silver, 3=Gold.</summary>
    private static int RandomRarity(
        int guaranteedRarity, int maxRarity, (double Silver, double Gold) thresholds, Random random)
    {
        double min = 0, max = 1;
        if (guaranteedRarity == 2)
        {
            min = thresholds.Silver;
        }
        if (guaranteedRarity == 3)
        {
            min = thresholds.Gold;
        }
        if (maxRarity == 1)
        {
            max = thresholds.Silver;
        }
        if (maxRarity == 2)
        {
            max = thresholds.Gold;
        }
        double roll = min + random.NextDouble() * (max - min);
        if (roll >= thresholds.Gold)
        {
            return 3;
        }
        return roll >= thresholds.Silver ? 2 : 1;
    }

    /// <summary>
    /// >Internal (not private): also used by <c>LegacyCraftingEndpoint.ClaimAsync</c> for the same
    /// uniform-pick-by-rarity RNG.
    /// </summary>
    internal static string PickCard(List<string>[] pools, int rarity) => PickCard(pools, rarity, Random.Shared);

    private static string PickCard(List<string>[] pools, int rarity, Random random)
    {
        var pool = pools[rarity - 1];
        return pool[random.Next(pool.Count)];
    }

    /// <summary>
    /// <c>Google2u.CardDefinitions</c> rows filtered to <c>IMPLEMENTED=true</c> and grouped by
    /// <c>RARITY</c> (1=Bronze, 2=Silver, 3=Gold) — exactly <c>CardManager.OnPlayerDataLoaded</c>'s
    /// own population of <c>mCardsByQuality</c>. <c>FROMMISSION</c> is unrelated to pack pool
    /// membership and is not filtered on. Internal (not private): also used by
    /// <c>LegacyCraftingEndpoint.ClaimAsync</c>.
    /// </summary>
    internal static List<string>[] CardPoolsByRarity(LegacyCatalog catalog)
    {
        var pools = new[] { new List<string>(), new List<string>(), new List<string>() };
        foreach (var row in catalog.Sheet("Google2u.CardDefinitions"))
        {
            if (row["IMPLEMENTED"]?.GetValue<bool>() != true)
            {
                continue;
            }
            int rarity = RowInt(row, "RARITY");
            if (rarity is < 1 or > 3)
            {
                continue;
            }
            if (RowString(row, "NAME") is string name)
            {
                pools[rarity - 1].Add(name);
            }
        }
        return pools;
    }
}

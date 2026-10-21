using System.Text.Json.Nodes;
using War.Persistence;
using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Buffers;
using War.Persistence.Legacy.State;

namespace War.Backend.Legacy.Buffering;

/// <summary>One transaction attempt's decoded blobs and pending publication, never shared between requests.</summary>
internal sealed class LegacyBufferedState
{
    private readonly LegacyPlayerDocument _document;
    private readonly long _now;
    private readonly Random _random;
    private LevelManagerData? _levels;
    private InventoryData? _inventory;
    private DecalManagerData? _decals;
    private CardManagerData? _cards;
    private JsonObject? _analytics;
    private readonly HashSet<string> _dirty = [];
    private int? _clientArmyPower;
    private long _goldDelta;
    private long _warBucksDelta;
    private long _scrapsDelta;

    public LegacyBufferedState(LegacyPlayerDocument document, long now, Random random)
    {
        _document = document;
        _now = now;
        _random = random;
    }

    public LevelManagerData Levels =>
        _levels ??= PlayerState.Read<LevelManagerData>(_document.Serialized, "LevelManagerData");
    public InventoryData Inventory =>
        _inventory ??= PlayerState.Read<InventoryData>(_document.Serialized, "InventoryData");
    public DecalManagerData Decals =>
        _decals ??= PlayerState.Read<DecalManagerData>(_document.Serialized, "DecalManagerData");
    public CardManagerData Cards =>
        _cards ??= PlayerState.Read<CardManagerData>(_document.Serialized, "CardManagerData");

    /// <summary>
    /// Known analytics fields are checked by the shared contract. The JSON tree retains
    /// unmodeled metadata rather than serializing it through a partial DTO.
    /// </summary>
    public JsonObject Analytics => _analytics ??= LegacyAnalyticsState.Read(_document.Serialized);

    public void LevelsChanged() => _dirty.Add("LevelManagerData");
    public void InventoryChanged() => _dirty.Add("InventoryData");
    public void DecalsChanged() => _dirty.Add("DecalManagerData");
    public void CardsChanged() => _dirty.Add("CardManagerData");
    public void AnalyticsChanged() => _dirty.Add("PlayerAnalyticsData");

    public int PlayerLevel => _document.Level;

    /// <summary>The player's VIP expiration as a unix timestamp; 0 or past means not VIP.</summary>
    public long PlayerVip => _document.Vip;
    public long CurrentGold => checked(_document.Gold + _goldDelta);
    public long CurrentWarBucks => checked(_document.WarBucks + _warBucksDelta);

    public long Now => _now;

    public Random Random => _random;

    /// <summary>Debits Gold if the (already-pending) balance covers it. Never goes negative.</summary>
    public bool TrySpendGold(long amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        if (CurrentGold < amount)
        {
            return false;
        }
        _goldDelta -= amount;
        return true;
    }

    /// <summary>Debits WarBucks if the (already-pending) balance covers it. Never goes negative.</summary>
    public bool TrySpendWarBucks(long amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        if (CurrentWarBucks < amount)
        {
            return false;
        }
        _warBucksDelta -= amount;
        return true;
    }

    public long CurrentScraps => checked(_document.Scraps + _scrapsDelta);

    /// <summary>Debits Scraps if the (already-pending) balance covers it. Never goes negative.</summary>
    public bool TrySpendScraps(long amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        if (CurrentScraps < amount)
        {
            return false;
        }
        _scrapsDelta -= amount;
        return true;
    }

    public void AddScraps(long amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        _scrapsDelta = checked(_scrapsDelta + amount);
    }

    /// <summary>
    /// Notes the army power the client asserted. It is stored for display and matchmaking
    /// continuity but is <b>not</b> authoritative: recomputing it needs the unit/weapon power
    /// values from the Google2u catalog. Until that lands, a client could understate or
    /// overstate it, so nothing that grants value may depend on it.
    /// </summary>
    public void RecordClientArmyPower(JsonNode? node)
    {
        if (node != null && int.TryParse(node.ToString(), out int power) && power >= 0)
        {
            _clientArmyPower = power;
        }
    }

    public LegacyBufferedMutation BuildMutation(DatabaseAction action, DatabaseResult code, JsonObject response)
    {
        if (code != DatabaseResult.Success &&
            (_dirty.Count != 0 || _goldDelta != 0 || _warBucksDelta != 0 || _scrapsDelta != 0))
        {
            throw new InvalidDataException("A failed buffered action contains a pending mutation.");
        }

        var replacements = new Dictionary<string, string>(StringComparer.Ordinal);
        int armyPower = code == DatabaseResult.Success ? _clientArmyPower ?? _document.ArmyPower : _document.ArmyPower;
        LegacyPlayerEconomyAuthority.ValidateArmyPower(armyPower);
        foreach (string key in _dirty)
        {
            replacements[key] = key switch
            {
                "LevelManagerData" => PlayerState.Write(Levels),
                "InventoryData" => PlayerState.Write(Inventory),
                "DecalManagerData" => PlayerState.Write(Decals),
                "CardManagerData" => PlayerState.Write(Cards),
                "PlayerAnalyticsData" => LegacyAnalyticsState.Write(Analytics),
                _ => throw new InvalidOperationException($"No writer for blob '{key}'.")
            };
        }

        return new LegacyBufferedMutation
        {
            Serialized = replacements,
            Gold = CurrentGold,
            WarBucks = CurrentWarBucks,
            Scraps = CurrentScraps,
            ArmyPower = armyPower,
            Result = (int)code,
            ResponseJson = response.ToJsonString(),
            Delivery = BuildDeliveryMetadata(action, response)
        };
    }

    private LegacyBufferedDelivery? BuildDeliveryMetadata(DatabaseAction action, JsonObject response)
    {
        if (!response.ContainsKey("DeliveryTime"))
        {
            return null;
        }

        ItemDelivery delivery = action switch
        {
            DatabaseAction.BuyWeaponUpgrade => Levels.WeaponDelivery,
            DatabaseAction.BuyUnitUpgrade => Levels.UnitDelivery,
            _ => throw new InvalidDataException("Unsupported relative delivery response.")
        };
        return new LegacyBufferedDelivery
        {
            Kind = action == DatabaseAction.BuyWeaponUpgrade ? "weapon" : "unit",
            ItemId = delivery.ItemId ?? throw new InvalidDataException("Delivery item identity is absent."),
            BoughtIndex = delivery.BoughtIndex,
            EndUnixSeconds = delivery.End
        };
    }
}

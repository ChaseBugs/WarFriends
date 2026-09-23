using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.Backend.Legacy;

/// <summary>
/// Server-side models of the 1.4.0 client's serialized subsystem blobs.
/// </summary>
/// <remarks>
/// <para>Each type mirrors a client POCO field-for-field, and every JSON name is stated explicitly
/// rather than derived from a naming policy: the client serializes with Newtonsoft using its
/// public field names verbatim, so a policy that renamed even one field would silently produce a
/// blob the client deserializes into defaults. <c>equippedID</c> is the obvious trap.</para>
/// <para>These are modelled, not opaque, because the actions that mutate them — "was shown"
/// acknowledgements, equipping, buying — change fields *inside* the blob. A server that stored
/// the blob as a string could not apply them.</para>
/// <para>Scope: only the three blobs the implemented buffered actions touch. The other 13 remain
/// opaque strings in <see cref="Persistence.LegacyPlayerDocument.Serialized"/> and are echoed back
/// unchanged, which is correct until an implemented action needs to mutate one.</para>
/// </remarks>
public static class PlayerState
{
    /// <summary>
    /// Matches the client's <c>JsonConvert</c> defaults closely enough for these POCOs: fields are
    /// named explicitly, nulls are written (the client's guards test for JSON null, not absence),
    /// and numbers are plain.
    /// </summary>
    public static readonly JsonSerializerOptions Options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        // The client's Dictionary<int, T> blobs serialize their keys as JSON strings.
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public static T Read<T>(string? json) where T : new() =>
        string.IsNullOrEmpty(json) ? new T() : JsonSerializer.Deserialize<T>(json, Options) ?? new T();

    public static string Write<T>(T value) => JsonSerializer.Serialize(value, Options);
}

/// <summary>Mirrors <c>LevelManager.LevelManagerData</c> — the army and weapon loadout.</summary>
public sealed class LevelManagerData
{
    [JsonPropertyName("savedArmies")] public Dictionary<string, SavedArmySlots> SavedArmies { get; set; } = [];
    [JsonPropertyName("savedWeapons")] public Dictionary<string, SavedWeaponSlots> SavedWeapons { get; set; } = [];
    [JsonPropertyName("unitDelivery")] public ItemDelivery UnitDelivery { get; set; } = new();
    [JsonPropertyName("weaponDelivery")] public ItemDelivery WeaponDelivery { get; set; } = new();
}

/// <summary>Mirrors <c>LevelManager.SavedArmySlots</c>.</summary>
public sealed class SavedArmySlots
{
    [JsonPropertyName("bought")] public bool Bought { get; set; }
    [JsonPropertyName("boughtIndex")] public int BoughtIndex { get; set; }
    [JsonPropertyName("specialSlot")] public int SpecialSlot { get; set; }
    [JsonPropertyName("showed")] public bool Showed { get; set; }
    [JsonPropertyName("tier")] public int Tier { get; set; }
    [JsonPropertyName("borrowed")] public bool Borrowed { get; set; }
    [JsonPropertyName("wasEquipped")] public bool WasEquipped { get; set; }
    [JsonPropertyName("equipped")] public bool Equipped { get; set; }
    [JsonPropertyName("eliteSlot")] public int EliteSlot { get; set; }
    [JsonPropertyName("parts")] public int Parts { get; set; }
}

/// <summary>Mirrors <c>LevelManager.SavedWeaponSlots</c>.</summary>
public sealed class SavedWeaponSlots
{
    [JsonPropertyName("bought")] public bool Bought { get; set; }
    [JsonPropertyName("boughtIndex")] public int BoughtIndex { get; set; }
    [JsonPropertyName("showed")] public bool Showed { get; set; }
    [JsonPropertyName("borrowed")] public bool Borrowed { get; set; }
}

/// <summary>Mirrors <c>LevelManager.ItemDelivery</c> — an in-progress purchase or upgrade timer.</summary>
public sealed class ItemDelivery
{
    [JsonPropertyName("activationNeeded")] public bool ActivationNeeded { get; set; }
    [JsonPropertyName("boughtIndex")] public int BoughtIndex { get; set; }
    [JsonPropertyName("end")] public long End { get; set; }
    [JsonPropertyName("itemId")] public string? ItemId { get; set; }
    [JsonPropertyName("slotId")] public int SlotId { get; set; }
    [JsonPropertyName("start")] public long Start { get; set; }
}

/// <summary>Mirrors <c>PlayerInventory.InventoryData</c> — the equipped weapon slots.</summary>
public sealed class InventoryData
{
    [JsonPropertyName("slots")] public Dictionary<int, SerializedSlotDetail> Slots { get; set; } = [];
}

/// <summary>Mirrors <c>PlayerInventory.SerializedSlotDetail</c>.</summary>
public sealed class SerializedSlotDetail
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("weaponIndex")] public int WeaponIndex { get; set; }
}

/// <summary>Mirrors <c>CamosManager.DecalManagerData</c> — cosmetics owned and equipped.</summary>
public sealed class DecalManagerData
{
    [JsonPropertyName("visuals")] public Dictionary<string, SavedPlayerVisual> Visuals { get; set; } = [];
    [JsonPropertyName("slots")] public Dictionary<int, SavedPlayerVisualSlot> Slots { get; set; } = [];
    [JsonPropertyName("previousHeadDecal")] public string PreviousHeadDecal { get; set; } = "";
}

/// <summary>Mirrors <c>CamosManager.SavedPlayerVisual</c>.</summary>
public sealed class SavedPlayerVisual
{
    [JsonPropertyName("bought")] public bool Bought { get; set; }
    [JsonPropertyName("showed")] public bool Showed { get; set; }
    [JsonPropertyName("expiresOn")] public int ExpiresOn { get; set; }
    [JsonPropertyName("borrowed")] public bool Borrowed { get; set; }
    [JsonPropertyName("parts")] public int Parts { get; set; }
    [JsonPropertyName("notificate")] public bool Notificate { get; set; }
}

/// <summary>Mirrors <c>CamosManager.SavedPlayerVisualSlot</c>. Note the exact casing of the name.</summary>
public sealed class SavedPlayerVisualSlot
{
    [JsonPropertyName("equippedID")] public string? EquippedId { get; set; }
}

/// <summary>
/// Mirrors <c>CardManager.CardManagerData</c>. Only <c>cardData</c> is written by anything this
/// server implements (<c>BuyCardPack</c>); <c>buddyCardData</c>/<c>nextWithdraw</c>/
/// <c>nextBuddyDeposit</c>/<c>extraSlot</c> belong to Squad card-pool features (deposit/withdraw,
/// buddy cards) that remain deprioritized — modeled here anyway, not left opaque, so a future write
/// from this same round-trip never silently drops them.
/// </summary>
public sealed class CardManagerData
{
    [JsonPropertyName("cardData")] public Dictionary<string, SavedCardData> CardData { get; set; } = [];
    [JsonPropertyName("buddyCardData")] public Dictionary<string, SavedBuddyCardData> BuddyCardData { get; set; } = [];
    [JsonPropertyName("nextWithdraw")] public int NextWithdraw { get; set; }
    [JsonPropertyName("nextBuddyDeposit")] public int NextBuddyDeposit { get; set; }
    [JsonPropertyName("extraSlot")] public bool ExtraSlot { get; set; }
}

/// <summary>Mirrors <c>CardManager.CardData</c> — just a running count, no per-card unlock threshold.</summary>
public sealed class SavedCardData
{
    [JsonPropertyName("amount")] public int Amount { get; set; }
}

/// <summary>Mirrors <c>CardManager.BuddyCardData</c>. Not written by anything implemented yet.</summary>
public sealed class SavedBuddyCardData
{
    [JsonPropertyName("amount")] public int Amount { get; set; }
    [JsonPropertyName("buddyName")] public string? BuddyName { get; set; }
    [JsonPropertyName("equippedVisuals")] public Dictionary<int, SavedPlayerVisualSlot> EquippedVisuals { get; set; } = [];
    [JsonPropertyName("unityType")] public int UnitType { get; set; }
    [JsonPropertyName("primaryWeapon")] public int PrimaryWeapon { get; set; }
    [JsonPropertyName("secondaryWeapon")] public int SecondaryWeapon { get; set; }
    [JsonPropertyName("armypower")] public int ArmyPower { get; set; }
    [JsonPropertyName("level")] public int Level { get; set; }
}

/// <summary>
/// Mirrors <c>CardCraftingManager.CraftData</c>. <c>cards</c> holds exactly the 3 card ids fed into
/// <c>CraftCard</c> while a craft is in progress; <c>isCrafting</c> in the client is
/// <c>cards.Count &gt; 0 &amp;&amp; start &lt; end</c>, reproduced the same way server-side.
/// </summary>
public sealed class CraftData
{
    [JsonPropertyName("cards")] public List<string> Cards { get; set; } = [];
    [JsonPropertyName("start")] public int Start { get; set; }
    [JsonPropertyName("end")] public int End { get; set; }
}

/// <summary>
/// Mirrors <c>SettingsManager.Settings</c> — the notification toggles sent by <c>UpdateSettings</c>
/// (action 165) as a JSON string in the <c>Settings</c> field, and stored under this same simple
/// name as a <c>DatabaseSerializedObjectGeneric&lt;Settings&gt;</c> blob.
/// </summary>
public sealed class Settings
{
    [JsonPropertyName("challenge")] public bool Challenge { get; set; }
    [JsonPropertyName("squadStatus")] public bool SquadStatus { get; set; }
    [JsonPropertyName("squadEvents")] public bool SquadEvents { get; set; }
    [JsonPropertyName("maintenance")] public bool Maintenance { get; set; }
    [JsonPropertyName("playerLeague")] public bool PlayerLeague { get; set; }
    [JsonPropertyName("dailyRewardNotification")] public bool DailyRewardNotification { get; set; }
}

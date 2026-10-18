using System.Text.Json;
using War.Backend;
using War.Backend.Legacy;
using War.Persistence;

/// <summary>Checks every reviewed source pair and the persisted-to-battle projection boundary.</summary>
internal static class BattleClientWeaponIndexTests
{
    private const string RifleSourceId = "Google2u.AssaultRifle_AK47";
    private const int RifleLevelManagerIndex = 1;
    private const int RifleInventoryIndex = 11;
    private const int SourceWeaponCount = 66;
    private const int InventorySlotCount = 67;

    internal static int Run(string contentDirectory)
    {
        BattleClientWeaponIndices.Validate();
        using JsonDocument observation = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(contentDirectory, "../docs/client-starter-loadout-observation.json")));
        using JsonDocument graph = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(contentDirectory, "recovered-all-weapon-bindings.json")));
        var bindings = graph.RootElement.GetProperty("weapons").EnumerateArray().ToDictionary(
            row => row.GetProperty("id").GetString() ?? "", row => row.GetProperty("inventoryIndex").GetInt32());
        int checks = 0;
        foreach (JsonElement row in observation.RootElement.GetProperty("weapons").EnumerateArray())
        {
            string sourceId = row.GetProperty("sourceId").GetString() ?? "";
            int levelIndex = row.GetProperty("sourceOrder").GetInt32();
            int inventoryIndex = row.GetProperty("inventoryIndex").GetInt32();
            Require(BattleClientWeaponIndices.ResolveInventoryIndex(sourceId, levelIndex) == bindings[sourceId],
                "The persisted index did not resolve to the reviewed combat identity.");
            Require(BattleClientWeaponIndices.ResolveLevelManagerIndex(sourceId, inventoryIndex) == levelIndex,
                "The battle index did not resolve to the actual Client source order.");
            Reject(() => BattleClientWeaponIndices.ResolveInventoryIndex(
                sourceId, (levelIndex + 1) % SourceWeaponCount));
            Reject(() => BattleClientWeaponIndices.ResolveLevelManagerIndex(
                sourceId, (inventoryIndex + 1) % InventorySlotCount));
            checks += 4;
        }
        Reject(() => BattleClientWeaponIndices.ResolveInventoryIndex("missing-source", 0));
        Reject(() => BattleClientWeaponIndices.ResolveLevelManagerIndex("missing-source", 0));
        CheckProjection();
        return checks + 4;
    }

    private static void CheckProjection()
    {
        var inventory = new InventoryData();
        inventory.Slots[0] = new SerializedSlotDetail { Name = RifleSourceId, WeaponIndex = RifleLevelManagerIndex };
        var levels = new LevelManagerData();
        levels.SavedWeapons[RifleSourceId] = new SavedWeaponSlots { Bought = true };
        var decals = new DecalManagerData();
        string[] visuals = ["CAMOS_DEFAULT", "HELMETS_EMPTY", "HEAD_EMPTY", "BANDS_EMPTY"];
        for (int i = 0; i < visuals.Length; i++)
        {
            decals.Slots[i] = new SavedPlayerVisualSlot { EquippedId = visuals[i] };
        }
        var player = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "IndexTest", Country = "US", Level = 1,
            Serialized = new Dictionary<string, string>
            {
                ["InventoryData"] = PlayerState.Write(inventory),
                ["LevelManagerData"] = PlayerState.Write(levels),
                ["DecalManagerData"] = PlayerState.Write(decals)
            }
        };
        Require(BattlePlayerPresentationSource.Project(player).Weapons.Single().WeaponIndex == RifleInventoryIndex,
            "The presentation leaked a persisted LevelManager index into the battle view.");
        inventory.Slots[0].WeaponIndex = RifleInventoryIndex;
        player.Serialized["InventoryData"] = PlayerState.Write(inventory);
        Reject(() => BattlePlayerPresentationSource.Project(player));
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("A mismatched weapon identity/index pair was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

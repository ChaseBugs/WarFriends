using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSourceWeapon(
    int LevelManagerIndex, int ComponentFileId, int GameObjectFileId,
    string SheetName, int Category, int InventoryIndex, int UnlockLevelIndex);

public sealed record CoopBossWeaponSlot(
    string SourceCategory, int LevelManagerIndex,
    int InventoryIndex, string SheetName);

public sealed class CoopBossLoadout
{
    public int MissionIndex { get; }
    public int Level { get; }
    public IReadOnlyList<CoopBossWeaponSlot> Slots { get; }

    internal CoopBossLoadout(int missionIndex, int level, CoopBossWeaponSlot[] slots)
    {
        MissionIndex = missionIndex;
        Level = level;
        Slots = new ReadOnlyCollection<CoopBossWeaponSlot>(slots);
    }
}

/// <summary>Original OBB weapon order and BotManager's four boss choices.</summary>
public sealed class CoopBossLoadoutCatalog
{
    private const string ReviewedArtifactSha256 =
        "7206b1e4536c05be870b87054a013983a937bb42bed7b58debfd5a0b9df1b3b4";
    private const string MatchingObbSha256 =
        "078cd1c4ebaeef4a39646274a54d35ce05741bc15a2e13d95ae55340711b5125";

    public IReadOnlyList<CoopSourceWeapon> Weapons { get; }
    public IReadOnlyList<CoopBossLoadout> Missions { get; }

    private CoopBossLoadoutCatalog(CoopSourceWeapon[] weapons,
        CoopBossLoadout[] missions)
    {
        Weapons = new ReadOnlyCollection<CoopSourceWeapon>(weapons);
        Missions = new ReadOnlyCollection<CoopBossLoadout>(missions);
    }

    public CoopBossLoadout ForMission(int missionIndex)
    {
        if (missionIndex is < 4 or > 74 || missionIndex % 5 != 4)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return Missions[missionIndex / 5];
    }

    public static CoopBossLoadoutCatalog Load(string path, MissionCatalog missions,
        CoopBotRuleCatalog bots, CoopBossAttackTimingCatalog attacks,
        WeaponBindingGraphCatalog bindings)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(bots);
        ArgumentNullException.ThrowIfNull(attacks);
        ArgumentNullException.ThrowIfNull(bindings);
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedArtifactSha256)
            throw new InvalidDataException("Boss weapon order differs from the OBB.");

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "obbSha256",
            "attackSourceSha256", "levelManagerComponentFileId",
            "weaponUpgradesComponentFileId", "weapons", "missions");
        string attackPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(path))!,
            "recovered-coop-boss-attack-timing.json");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != missions.SourceSha256 ||
            root.GetProperty("obbSha256").GetString() != MatchingObbSha256 ||
            root.GetProperty("attackSourceSha256").GetString() != Digest(attackPath) ||
            root.GetProperty("levelManagerComponentFileId").GetInt32() != 45847 ||
            root.GetProperty("weaponUpgradesComponentFileId").GetInt32() != 45843)
            throw new InvalidDataException("Boss weapon source identity changed.");

        JsonElement weaponEntries = root.GetProperty("weapons");
        if (weaponEntries.ValueKind != JsonValueKind.Array ||
            weaponEntries.GetArrayLength() != 66 || bindings.Count != 66)
            throw new InvalidDataException("Boss weapon order needs 66 source weapons.");
        var weapons = new CoopSourceWeapon[66];
        var componentIds = new HashSet<int>();
        var inventoryIndexes = new HashSet<int>();
        var sheetNames = new HashSet<string>(StringComparer.Ordinal);
        for (int index = 0; index < weapons.Length; index++)
        {
            JsonElement entry = weaponEntries[index];
            RequireFields(entry, "levelManagerIndex", "componentFileId",
                "gameObjectFileId", "sheetName", "category",
                "inventoryIndex", "unlockLevelIndex");
            int componentId = entry.GetProperty("componentFileId").GetInt32();
            int gameObjectId = entry.GetProperty("gameObjectFileId").GetInt32();
            string name = entry.GetProperty("sheetName").GetString() ?? "";
            int category = entry.GetProperty("category").GetInt32();
            int inventoryIndex = entry.GetProperty("inventoryIndex").GetInt32();
            int unlockLevel = entry.GetProperty("unlockLevelIndex").GetInt32();
            if (entry.GetProperty("levelManagerIndex").GetInt32() != index ||
                componentId <= 0 || gameObjectId <= 0 ||
                !componentIds.Add(componentId) ||
                !sheetNames.Add(name) ||
                !inventoryIndexes.Add(inventoryIndex) ||
                category is not (1 or 2 or 4 or 8 or 16 or 32 or 64 or 128 or 256 or 512) ||
                unlockLevel is < 0 or > 49 ||
                bindings.Get(name).InventoryIndex != inventoryIndex)
                throw new InvalidDataException("Boss weapon order has a changed source row.");
            weapons[index] = new CoopSourceWeapon(index, componentId,
                gameObjectId, name, category, inventoryIndex, unlockLevel);
        }

        JsonElement missionEntries = root.GetProperty("missions");
        if (missionEntries.ValueKind != JsonValueKind.Array ||
            missionEntries.GetArrayLength() != 15)
            throw new InvalidDataException("Boss loadouts need fifteen missions.");
        var loadouts = new CoopBossLoadout[15];
        for (int index = 0; index < loadouts.Length; index++)
        {
            JsonElement entry = missionEntries[index];
            RequireFields(entry, "missionIndex", "level", "slots");
            int missionIndex = index * 5 + 4;
            int level = bots.ForMission(missionIndex).Level;
            CoopBossAttackTiming timing = attacks.ForMission(missionIndex);
            if (entry.GetProperty("missionIndex").GetInt32() != missionIndex ||
                entry.GetProperty("level").GetInt32() != level ||
                missions.Get(missionIndex).MissionType != "KillOpponent")
                throw new InvalidDataException("Boss loadout mission identity changed.");
            JsonElement slotEntries = entry.GetProperty("slots");
            if (slotEntries.ValueKind != JsonValueKind.Array ||
                slotEntries.GetArrayLength() != 4)
                throw new InvalidDataException("Boss loadout needs four ordered slots.");
            string[] categories = [timing.PrimaryCategory, timing.SecondaryCategory,
                timing.ExplosiveCategory, timing.PistolCategory];
            var slots = new CoopBossWeaponSlot[4];
            for (int slotIndex = 0; slotIndex < slots.Length; slotIndex++)
            {
                JsonElement slot = slotEntries[slotIndex];
                RequireFields(slot, "sourceCategory", "levelManagerIndex",
                    "inventoryIndex", "sheetName");
                string category = slot.GetProperty("sourceCategory").GetString() ?? "";
                CoopSourceWeapon selected = LastUnlockedWeapon(weapons,
                    CategoryValue(category), level);
                if (category != categories[slotIndex] ||
                    slot.GetProperty("levelManagerIndex").GetInt32() !=
                        selected.LevelManagerIndex ||
                    slot.GetProperty("inventoryIndex").GetInt32() !=
                        selected.InventoryIndex ||
                    slot.GetProperty("sheetName").GetString() != selected.SheetName)
                    throw new InvalidDataException("Boss weapon choice differs from the Client rule.");
                slots[slotIndex] = new CoopBossWeaponSlot(category,
                    selected.LevelManagerIndex, selected.InventoryIndex,
                    selected.SheetName);
            }
            loadouts[index] = new CoopBossLoadout(missionIndex, level, slots);
        }
        return new CoopBossLoadoutCatalog(weapons, loadouts);
    }

    private static CoopSourceWeapon LastUnlockedWeapon(
        IReadOnlyList<CoopSourceWeapon> weapons, int category, int level)
    {
        CoopSourceWeapon? chosen = null;
        int highestUnlock = -1;
        foreach (CoopSourceWeapon weapon in weapons)
        {
            if (weapon.Category != category || weapon.UnlockLevelIndex > level ||
                weapon.UnlockLevelIndex <= highestUnlock)
                continue;
            chosen = weapon;
            highestUnlock = weapon.UnlockLevelIndex;
        }
        if (chosen != null)
            return chosen;

        // The Client's fallback uses <=, so a later row wins an equal minimum.
        int lowestUnlock = int.MaxValue;
        foreach (CoopSourceWeapon weapon in weapons)
        {
            if (weapon.Category != category || weapon.UnlockLevelIndex > lowestUnlock)
                continue;
            chosen = weapon;
            lowestUnlock = weapon.UnlockLevelIndex;
        }
        return chosen ?? throw new InvalidDataException("Boss weapon category is empty.");
    }

    private static int CategoryValue(string name) => name.Trim() switch
    {
        "AssaultRifle" => 1,
        "SMG" => 2,
        "LMG" => 4,
        "SniperRifle" => 8,
        "RocketLauncher" => 16,
        "Shotgun" => 32,
        "Grenade" => 64,
        "Pistol" => 128,
        _ => throw new InvalidDataException("Unknown boss weapon category.")
    };

    private static string Digest(string path) =>
        Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));

    private static void RequireFields(JsonElement entry, params string[] fields)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != fields.Length ||
            fields.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Boss loadout artifact has unexpected fields.");
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using War.Protocol;

/// <summary>Captures source-backed starter state after the real isolated account bootstrap completes.</summary>
public static class UnityStarterLoadoutExport
{
    private const string OutputVariable = "WAR_STARTER_LOADOUT_OUTPUT";
    private const string ValidationMarker = "/Server/.local/";
    private static readonly string[] RuleSources =
    {
        "LevelManager.cs", "PlayerInventory.cs", "WeaponLevelsSetup.cs", "UpgradeSlots.cs",
        "ActiveUnitsManager.cs", "CamosManager.cs", "DatabaseSerializedObjectGeneric.cs",
        "GameController.cs", "UpgradeSlot.cs", "UpgradeSlotSpecial.cs", "UpgradeSlotElite.cs",
        "PlayerProperties.cs", "WeaponInventory.cs"
    };

    /// <summary>Exports loadout state and catalog metadata without account identity or credentials.</summary>
    public static void WriteIfRequested()
    {
        string requested = Environment.GetEnvironmentVariable(OutputVariable);
        if (string.IsNullOrEmpty(requested))
        {
            return;
        }
        string outputPath = ValidateOutputPath(requested);
        object result = CreateSnapshot();
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        string json = JsonConvert.SerializeObject(result, Formatting.Indented).Replace("\r\n", "\n");
        File.WriteAllText(outputPath, json + "\n", new UTF8Encoding(false));
        Debug.Log("UNITY_STARTER_LOADOUT_EXPORTED catalog and loadout only; path=" + outputPath);
    }

    private static object CreateSnapshot()
    {
        LevelManager levels = FindSceneComponent<LevelManager>();
        PlayerInventory inventory = FindSceneComponent<PlayerInventory>();
        CamosManager decals = FindSceneComponent<CamosManager>();
        GameController game = FindSceneComponent<GameController>();
        JObject serialized = CaptureSerialized(levels, inventory, decals);
        object[] weapons = levels.weaponLevelsSetups.Select(CreateWeaponRow).ToArray();
        object[] units = levels.behaviours.Select(CreateUnitRow).ToArray();
        int weaponIndexChecks = VerifyWeaponIndices(levels);
        bool hasMetadataSideEffects = !JToken.DeepEquals(serialized, CaptureSerialized(levels, inventory, decals));
        return new
        {
            schemaVersion = 1,
            scope = "fresh account after Splash/MainScene callbacks; observation only",
            source = CreateProvenance(),
            context = new
            {
                rankIndex = levels.currentLevel.index,
                serverRankIndex = GameLoginManager.currentPlayer.level,
                isTutorial = game.isTutorial
            },
            hasMetadataSideEffects,
            weaponIndexChecks,
            weapons,
            units,
            inventorySlots = inventory.inventorySlots.Select((slot, index) => new
            {
                sourceOrder = index, slotIndex = slot.index, category = (int)slot.category
            }).ToArray(),
            serialized
        };
    }

    private static int VerifyWeaponIndices(LevelManager levels)
    {
        int checks = 0;
        for (int i = 0; i < levels.weaponLevelsSetups.Count; i++)
        {
            WeaponLevelsSetup weapon = levels.weaponLevelsSetups[i];
            var view = new BattleWeaponView
            {
                SourceId = weapon.GetComponent<Google2uComponentBase>().GetType().ToString(),
                WeaponIndex = weapon.indexInWeaponInventory
            };
            if (PlayerProperties.ResolveBattleWeaponLevelIndex(view) != i)
            {
                throw new InvalidOperationException("A battle weapon resolved to the wrong LevelManager entry.");
            }
            checks++;
            view.WeaponIndex++;
            RequireRejectedWeapon(view);
            checks++;
        }
        RequireRejectedWeapon(new BattleWeaponView { SourceId = "missing-source", WeaponIndex = 0 });
        return checks + 1;
    }

    private static void RequireRejectedWeapon(BattleWeaponView view)
    {
        try
        {
            PlayerProperties.ResolveBattleWeaponLevelIndex(view);
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new InvalidOperationException("A mismatched or unknown battle weapon identity was accepted.");
    }

    private static object CreateWeaponRow(WeaponLevelsSetup weapon, int sourceOrder)
    {
        return new
        {
            sourceOrder,
            // GetSheetName caches this attached component type; it is internal to the runtime assembly.
            sourceId = weapon.GetComponent<Google2uComponentBase>().GetType().ToString(),
            inventoryIndex = weapon.indexInWeaponInventory,
            category = (int)weapon.weaponCategory,
            unlockRankIndex = weapon.unlockLevelIndex,
            minimumPurchaseRankIndex = weapon.weaponUpgradesRow.CANBEBOUGHT - 1,
            price = weapon.price,
            goldPrice = weapon.priceGold,
            isShopWeapon = weapon.purchasableInShop,
            isTutorialWeapon = weapon.isTutorialWeapon,
            isBought = weapon.bought,
            hasImplicitFreeOwnership = weapon.purchasableInShop && weapon.unlockLevelIndex == 0 &&
                weapon.price == 0 && weapon.priceGold == 0
        };
    }

    private static JObject CaptureSerialized(LevelManager levels, PlayerInventory inventory, CamosManager decals)
    {
        return new JObject
        {
            { "InventoryData", JObject.FromObject(inventory.data) },
            { "LevelManagerData", JObject.FromObject(levels.data) },
            { "DecalManagerData", JObject.FromObject(decals.data) }
        };
    }

    private static object CreateUnitRow(LevelBehaviour unit, int sourceOrder)
    {
        UpgradeSlots slots = unit.upgradeSlots;
        return new
        {
            sourceOrder,
            sourceId = slots.GetSheetName(),
            unitType = (int)unit.unitType,
            unlockRankIndex = slots.unlockLevelIndex,
            minimumPurchaseRankIndex = slots.armyUpgradesRow.CANBEBOUGHT - 1,
            price = slots.price,
            goldPrice = slots.priceGold,
            startingTier = slots.startTier,
            specialStartIndex = slots.armyUpgradesRow.STARTINGSPECIAL,
            eliteStartIndex = slots.armyUpgradesRow.STARTINGELITE,
            isTutorialUnit = slots.isTutorialUnit,
            isBought = slots.bought,
            canUseInBattle = slots.canUseInBattle,
            normalStageIndex = slots.boughtIndex,
            specialStageIndex = slots.upgradeSlotSpecial.boughtIndexAbsolute,
            isSpecialBought = slots.upgradeSlotSpecial.isBought,
            eliteStageIndex = slots.upgradeSlotElite.boughtIndexAbsolute,
            isEliteBought = slots.upgradeSlotElite.isBought,
            hasImplicitFreeOwnership = slots.unlockLevelIndex == 0 && slots.price == 0 && slots.priceGold == 0
        };
    }

    private static object CreateProvenance()
    {
        string scenePath = Path.Combine(Application.dataPath, "Scenes/MainScene.unity");
        var rules = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (string fileName in RuleSources)
        {
            rules.Add(fileName, Digest(Path.Combine(Application.dataPath, "Scripts/Assembly-CSharp/" + fileName)));
        }
        return new { unityVersion = Application.unityVersion, mainSceneSha256 = Digest(scenePath), ruleSha256 = rules };
    }

    private static T FindSceneComponent<T>() where T : Component
    {
        return Resources.FindObjectsOfTypeAll<T>().Single(component => component.gameObject.scene.IsValid());
    }

    private static string ValidateOutputPath(string requested)
    {
        string dataPath = Application.dataPath.Replace('\\', '/');
        int marker = dataPath.IndexOf(ValidationMarker, StringComparison.OrdinalIgnoreCase);
        if (marker < 0)
        {
            throw new InvalidOperationException("Starter export requires a disposable project under Server/.local.");
        }
        string validationRoot = dataPath.Substring(0, marker) + ValidationMarker;
        string outputPath = Path.GetFullPath(requested);
        if (!outputPath.Replace('\\', '/').StartsWith(validationRoot, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Starter export output must stay under Server/.local.");
        }
        return outputPath;
    }

    private static string Digest(string path)
    {
        using (SHA256 algorithm = SHA256.Create())
        using (FileStream input = File.OpenRead(path))
        {
            return BitConverter.ToString(algorithm.ComputeHash(input)).Replace("-", "").ToLowerInvariant();
        }
    }
}

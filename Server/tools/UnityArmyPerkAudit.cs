using System;
using System.IO;
using System.Linq;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

using Newtonsoft.Json.Linq;

namespace WarFriends.Validation
{
    /// <summary>Compares extracted perk recipes with the actual recovered selectors and implementations.</summary>
    public static class UnityArmyPerkAudit
    {
        private const int ExpectedFamilyCount = 24;
        private static int _checks;
        private static int _eliteCells;

        /// <summary>Runs on disposable scene objects without saving assets or changing account state.</summary>
        public static void Run()
        {
            try
            {
                if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
                {
                    throw new InvalidOperationException("Use a disposable validation project.");
                }
                EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
                JObject artifact = JObject.Parse(File.ReadAllText(FindArtifact()));
                LevelManager manager = UnityEngine.Object.FindObjectOfType<LevelManager>();
                JArray families = (JArray)artifact["families"];
                Require(manager != null && manager.behaviours.Count == ExpectedFamilyCount &&
                    families.Count == ExpectedFamilyCount, "The complete player unit set is required.");
                for (int index = 0; index < families.Count; index++)
                {
                    VerifyFamily(manager, (JObject)families[index], index);
                }
                Debug.Log("PASS: " + _checks + " recovered perk checks; " + _eliteCells + " elite column cells.");
                EditorApplication.Exit(0);
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                EditorApplication.Exit(1);
            }
        }

        private static string FindArtifact()
        {
            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            while (directory != null)
            {
                string path = Path.Combine(directory.FullName, "content/recovered-army-perks.json");
                if (File.Exists(path))
                {
                    return path;
                }
                directory = directory.Parent;
            }
            throw new FileNotFoundException("The recovered perk artifact is missing.");
        }

        private static void VerifyFamily(LevelManager manager, JObject row, int index)
        {
            LevelBehaviour behavior = manager.behaviours[index];
            Require(behavior.GetType().Name == row.Value<string>("behaviorType"), "The source unit order changed.");
            Require(behavior.upgradeSlots.GetSheetName() == row.Value<string>("sheet"), "The attached sheet changed.");
            Require((behavior.perkType == PerkType.Buff ? "ally" : "opponent") == row.Value<string>("faction"),
                "The source perk faction changed.");
            var actual = PerkUnitCategories.GetUnits(behavior.perkAffects);
            string[] expected = row["affectedUnitIds"].Values<string>().ToArray();
            foreach (LevelBehaviour target in manager.behaviours)
            {
                Require(actual.Contains(target.GetType()) == expected.Contains(target.unitDictionaryId),
                    "The exact source type selector differs from the extracted target set.");
            }
            JArray values = (JArray)row["eliteColumn"];
            if (values.Count == 0)
            {
                VerifyNoEffect(behavior);
                return;
            }
            Require(behavior.upgradeSlots.excel.RowsGeneric.Count == values.Count, "The elite column is incomplete.");
            for (int eliteIndex = 0; eliteIndex < values.Count; eliteIndex++)
            {
                VerifyCell(behavior, row, eliteIndex, values[eliteIndex].Value<float>());
                _eliteCells++;
            }
        }

        private static void VerifyCell(LevelBehaviour behavior, JObject row, int eliteIndex, float value)
        {
            var upgrades = new UpgradeSlots.UnitUpgrades(1f) { isElite = true, slotUpgradeIndexElite = eliteIndex };
            var definition = new UnitUpgradeDefinition(true, upgrades, false, 0);
            Perk actual = behavior.upgradeSlots.PerkImplementation(definition, new Perk());
            string coefficient = row["recipe"].Value<string>("coefficient");
            float multiplier = row["recipe"].Value<string>("operation") == "+" ? 1f + value : 1f - value;
            Require((float)actual.hpCoef == (coefficient == "hpCoef" ? multiplier : 1f) &&
                (float)actual.accuracyCoef == (coefficient == "accuracyCoef" ? multiplier : 1f) &&
                (float)actual.shotSpeedCoef == (coefficient == "shotSpeedCoef" ? multiplier : 1f) &&
                (float)actual.speedCoef == (coefficient == "speedCoef" ? multiplier : 1f),
                "The recovered implementation differs from the extracted binary32 formula.");
            string count = row["recipe"].Value<string>("countKind");
            Require(actual.buffCount == (count == "buffCount" ? 1 : 0) &&
                actual.debuffCount == (count == "debuffCount" ? 1 : 0), "The source perk count changed.");
        }

        private static void VerifyNoEffect(LevelBehaviour behavior)
        {
            Perk current = new Perk();
            Perk result = behavior.upgradeSlots.PerkImplementation(new UnitUpgradeDefinition(), current);
            Require(ReferenceEquals(result, current), "A source no-op perk unexpectedly changes its input.");
        }

        private static void Require(bool condition, string message)
        {
            _checks++;
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}

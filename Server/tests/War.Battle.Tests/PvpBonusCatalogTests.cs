using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

internal static class PvpBonusCatalogTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }
        var catalog = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json")).PvpBonuses;
        Check(catalog.Rows.Count == 9 && catalog.Rows[0].Name == "KillStreakBonusGold" &&
              catalog.Rows[1].Name == "KillStreakBonusAddHealth" && catalog.Rows[2].Name == "KillStreakBonusWarbucks",
            "bonus indices retain prefab order rather than the different Crates spreadsheet order");
        Check(catalog.Rows.Select(row => row.PrefabGuid).Distinct().Count() == 9 &&
              catalog.Rows.All(row => row.ComponentFileId == 11409266 && row.PrefabSha256.Length == 64),
            "all bonus rows retain distinct original prefab/component provenance");
        Check(catalog.LowAmmoThreshold == 0.1f &&
              catalog.GoldRewardRange(5) == new PvpBonusGoldRange(5, 10) &&
              catalog.GoldRewardRange(6) == new PvpBonusGoldRange(4, 8) &&
              catalog.GoldRewardRange(7) == new PvpBonusGoldRange(3, 7) &&
              catalog.GoldRewardRange(8) == new PvpBonusGoldRange(3, 6),
            "source Gold reward bounds use low-level interpolation and an exclusive upper draw");
        foreach (int invalidLevel in new[] {0, 44})
        {
            try { catalog.GoldRewardRange(invalidLevel);
                throw new Exception("Gold reward accepted an unsupported display level."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }

        byte[] referenceBytes = File.ReadAllBytes(Path.Combine(directory, "unity-pvp-bonus-reference.json"));
        Check(Convert.ToHexStringLower(SHA256.HashData(referenceBytes)) ==
              "9d73938fe2f31bb86cb4ab39421f1e77a833772e3c32b25e384f866e8abd68e7",
            "weight oracle uses the reviewed original-method Mono fixture");
        using var reference = JsonDocument.Parse(referenceBytes);
        Check(reference.RootElement.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
              reference.RootElement.GetProperty("codeSha256").GetString() ==
                  "7ea7e1169d91fe906a5dddc70c12efe36aba168f68230c22581665a0f68c5f86",
            "weight oracle pins the engine and all recovered probability/interpolation/gate methods");
        Check(reference.RootElement.GetProperty("samples").GetArrayLength() == 192,
            "oracle covers the complete reviewed condition matrix");
        foreach (var sample in reference.RootElement.GetProperty("samples").EnumerateArray())
        {
            var context = new PvpBonusWeightContext(sample.GetProperty("arena").GetBoolean(),
                sample.GetProperty("friendly").GetBoolean(), sample.GetProperty("localDisplayLevel").GetInt32(),
                sample.GetProperty("ownerLevelIndex").GetInt32(), sample.GetProperty("goldBonusesCollected").GetInt32(),
                sample.GetProperty("lowAmmo").GetBoolean());
            var weights = catalog.WeightsForSourceContext(context);
            var expected = sample.GetProperty("weightBits");
            for (int index = 0; index < weights.Count; index++)
                Check(BitConverter.SingleToInt32Bits(weights[index]) == expected[index].GetInt32(),
                    "original Mono weight bits: " + context + "/" + catalog.Rows[index].Name);
        }
        var normal = new PvpBonusWeightContext(false, false, 8, 7, 0, false);
        var baseWeights = catalog.WeightsForSourceContext(normal);
        Check(baseWeights.SequenceEqual(new float[] {10,20,30,20,35,35,10,5,25}),
            "ordinary source weights use the exact MainScene order");
        var friendly = catalog.WeightsForSourceContext(normal with { IsFriendlyDeathMatch = true });
        Check(friendly[0] == 0 && friendly[2] == 0 && friendly[7] == 0,
            "friendly DeathMatch closes Gold, Warbucks and card bonuses");
        Check(catalog.WeightsForSourceContext(normal with { LocalDisplayLevel = 5, GoldBonusesCollected = 20 })[0] == 25 &&
              catalog.WeightsForSourceContext(normal with { GoldBonusesCollected = 3 })[0] == 0,
            "Gold uses local display level and source analytics cap rather than owner level");
        Check(catalog.WeightsForSourceContext(normal with { OwnerLevelIndex = 6 })[7] == 0 && baseWeights[7] == 5,
            "card unlock uses strict owner level-index comparison");
        Check(catalog.WeightsForSourceContext(normal with { FirstTwoWeaponsHaveLowAmmo = true })[8] == 50 && baseWeights[8] == 25,
            "only the established first-two low-ammo condition doubles the ammo weight");
        foreach (var invalid in new[] {normal with {LocalDisplayLevel=0}, normal with {LocalDisplayLevel=44},
            normal with {OwnerLevelIndex=-1}, normal with {OwnerLevelIndex=43}, normal with {GoldBonusesCollected=-1}})
        {
            try { catalog.WeightsForSourceContext(invalid); throw new Exception("Invalid weight authority accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        try { ((IList<float>)baseWeights)[0] = 99; throw new Exception("Weights were mutable."); }
        catch (NotSupportedException) { checks++; }
        try { ((IList<PvpBonusSource>)catalog.Rows)[0] = catalog.Rows[1]; throw new Exception("Rows were mutable."); }
        catch (NotSupportedException) { checks++; }

        using var manifest = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory, "combat-content-manifest.json")));
        string scene = manifest.RootElement.GetProperty("SceneRevision").GetString()!;
        string content = manifest.RootElement.GetProperty("StatsRevision").GetString()!;
        string path = Path.Combine(directory, "recovered-pvp-bonus-catalog.json");
        foreach (var binding in new[] {(new string('0',64), content), (scene,new string('0',64))})
        {
            try { PvpBonusCatalog.Load(path, binding.Item1, binding.Item2); throw new Exception("Foreign bonus binding accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        string damaged = Path.Combine(Path.GetTempPath(), "war-pvp-bonus-"+Guid.NewGuid().ToString("N")+".json");
        try
        {
            File.WriteAllText(damaged, File.ReadAllText(path).Replace("30.0", "300.0", StringComparison.Ordinal));
            try { PvpBonusCatalog.Load(damaged, scene, content); throw new Exception("Changed bonus authority accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        finally { File.Delete(damaged); }
        return checks;
    }
}

using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

internal static class PvpBonusSpawnAreaTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        byte[] unityBytes = File.ReadAllBytes(Path.Combine(directory,
            "unity-pvp-bonus-spawn-areas-reference.json"));
        Check(Convert.ToHexStringLower(SHA256.HashData(unityBytes)) ==
              "9cf97a1caea83b0933240b001ee5a307fbe0a4c4d764ce1d3bcf9fa337e539d6",
            "Unity collider reference retains its reviewed fixture bytes");
        using var unityDocument = JsonDocument.Parse(unityBytes);
        var unityRoot = unityDocument.RootElement;
        Check(unityRoot.GetProperty("version").GetInt32() == 1 &&
              unityRoot.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
              unityRoot.GetProperty("areas").GetArrayLength() == 10,
            "isolated Unity probe covers every recovered multiplayer source area");
        var unityAreas = unityRoot.GetProperty("areas").EnumerateArray().ToArray();
        var expectedColliders = new[] {
            new[] {2111, 2094}, new[] {2745, 2744}, new[] {2166, 2155},
            new[] {2929, 2937}, new[] {2477, 2471}
        };
        for (int index = 0; index < content.Maps.Count; index++)
        {
            var map = content.Maps[index];
            var areas = content.PvpBonusSpawnAreas.ForMap(map);
            Check(areas.Select(area => area.ColliderFileId).SequenceEqual(expectedColliders[index]),
                "map spawn areas retain their source list order and collider identities");
            foreach (var area in areas)
            {
                var original = unityAreas[index * 2 + area.Order];
                Check(original.GetProperty("source").GetString() == map.Source &&
                      original.GetProperty("colliderFileId").GetInt32() == area.ColliderFileId &&
                      original.GetProperty("order").GetInt32() == area.Order &&
                      Near(area.BoundsMin, original.GetProperty("minimum")) &&
                      Near(area.BoundsMax, original.GetProperty("maximum")),
                    "exported source box matches isolated Unity BoxCollider.bounds on all three axes");
                Check(content.PvpBonusSpawnAreas.Position(map, area.Order, Vector3.Zero) == area.BoundsMin &&
                      content.PvpBonusSpawnAreas.Position(map, area.Order, Vector3.One) == area.BoundsMax,
                    "host draws sample all three BoxCollider.bounds axes, including endpoints");
                var midpoint = content.PvpBonusSpawnAreas.Position(map, area.Order,
                    new Vector3(0.5f));
                Check(midpoint == area.BoundsMin + (area.BoundsMax - area.BoundsMin) * 0.5f,
                    "half draws select the center of the source world AABB");
            }
        }
        var first = content.Maps[0];
        foreach (var invalid in new[] {new Vector3(float.NaN, 0, 0),
                     new Vector3(-0.01f, 0, 0), new Vector3(0, 1.01f, 0)})
        {
            try { content.PvpBonusSpawnAreas.Position(first, 0, invalid);
                throw new Exception("Invalid host random coordinate accepted."); }
            catch (ArgumentOutOfRangeException) { checks++; }
        }
        try { content.PvpBonusSpawnAreas.Position(first, 2, Vector3.Zero);
            throw new Exception("Absent source area accepted."); }
        catch (ArgumentOutOfRangeException) { checks++; }
        try { ((IList<PvpBonusSpawnArea>)content.PvpBonusSpawnAreas.ForMap(first)).Clear();
            throw new Exception("Source area list was mutable."); }
        catch (NotSupportedException) { checks++; }
        string altered = Path.Combine(Path.GetTempPath(),
            "war-bonus-areas-" + Guid.NewGuid().ToString("N") + ".json");
        try
        {
            string original = File.ReadAllText(Path.Combine(directory,
                "recovered-pvp-bonus-spawn-areas.json"));
            File.WriteAllText(altered, original.Replace("2111", "2112", StringComparison.Ordinal));
            try { PvpBonusSpawnAreaCatalog.Load(altered, content.Maps);
                throw new Exception("Edited source collider identity was accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        finally { File.Delete(altered); }
        return checks;
    }

    private static bool Near(Vector3 actual, JsonElement reference)
    {
        var unity = new Vector3(reference[0].GetSingle(), reference[1].GetSingle(),
            reference[2].GetSingle());
        return Vector3.Distance(actual, unity) <= 0.00002f;
    }
}

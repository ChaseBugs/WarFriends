using System.Numerics;
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
}

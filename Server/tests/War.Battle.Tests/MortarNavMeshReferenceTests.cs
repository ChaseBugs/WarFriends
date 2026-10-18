using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Compares bound destinations against forty native Unity NavMesh sampling observations.</summary>
internal static class MortarNavMeshReferenceTests
{
    private const string Revision = "ab74aeff6a18b3c9c822089247600cec22df8fef1343cda59acbe58c2dc7c5d1";
    private const int SourcePointCount = 40;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "mortar-points-unity-reference.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == Revision,
            "Mortar native reference bytes changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        Require(root.GetProperty("unityVersion").GetString() == "2018.3.0f2" &&
            root.GetProperty("points").GetArrayLength() == SourcePointCount,
            "Mortar native reference lost its Unity version or complete point set.");
        var seen = new HashSet<(string Source, int Component)>();
        int checks = 2;
        foreach (JsonElement row in root.GetProperty("points").EnumerateArray())
        {
            RecoveredBattleMap map = content.Maps.Single(candidate =>
                candidate.Source == row.GetProperty("source").GetString());
            int component = row.GetProperty("componentFileId").GetInt32();
            MortarPoint point = content.MortarPoints.ForMap(map).Single(candidate =>
                candidate.ComponentFileId == component);
            checks += CheckPoint(map, (point, row));
            checks += Require(seen.Add((map.Source, component)), "Mortar native point identity is duplicated.");
        }

        return checks;
    }

    private static int CheckPoint(RecoveredBattleMap map,
        (MortarPoint Point, JsonElement Row) source)
    {
        JsonElement row = source.Row;
        Vector3 position = ReadPosition(row.GetProperty("position"));
        Vector3 native = ReadPosition(row.GetProperty("sampledPosition"));
        Vector3 projected = source.Point.NavMeshPosition;
        return Require(position == source.Point.Position && row.GetProperty("isSampled").GetBoolean() &&
            row.GetProperty("planarDistance").GetSingle() == 0f && projected == native &&
            projected.X == position.X && projected.Z == position.Z,
            $"Mortar native projection differs on {map.Source}/{source.Point.ComponentFileId}: " +
            $"host={projected}, native={native}.");
    }

    private static Vector3 ReadPosition(JsonElement coordinates)
    {
        float[] values = coordinates.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        Require(values.Length == 3 && values.All(float.IsFinite), "Mortar reference position is malformed.");
        return new Vector3(values[0], values[1], values[2]);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}

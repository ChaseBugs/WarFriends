using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks complete pinned loading, immutable geometry, and source-captured detail heights.</summary>
internal static class NavigationDetailCatalogTests
{
    internal static int Run(string directory)
    {
        NavigationDetailCatalog catalog = NavigationDetailCatalog.Load(directory);
        if (catalog.Maps.Count != 5 || catalog.Maps.Sum(map => map.Polygons.Count) != 5693 ||
            catalog.Maps.Sum(map => map.Polygons.Sum(polygon => polygon.Details.Count)) != 26081)
        {
            throw new Exception("Navigation detail catalog is incomplete.");
        }
        VerifyImmutable(catalog.Maps[0].Polygons[0].Boundary);
        VerifyCorruption(directory);
        using JsonDocument capture = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-helicopter-landing-offset-unity-reference.json")));
        int checkedPositions = 0;
        foreach (JsonElement row in capture.RootElement.GetProperty("rows").EnumerateArray())
        {
            if (!row.GetProperty("found").GetBoolean())
            {
                continue;
            }
            JsonElement coordinates = row.GetProperty("position");
            var point = new Vector3(coordinates[0].GetSingle(), coordinates[1].GetSingle(), coordinates[2].GetSingle());
            NavigationDetailCatalog.Map map = catalog.Maps.Single(
                map => map.Name == row.GetProperty("map").GetString());
            if (!map.Polygons.Any(polygon => polygon.Details.Any(triangle => ContainsHeight(triangle, point))))
            {
                throw new Exception("Unity height is absent from the loaded .NET detail surface.");
            }
            checkedPositions++;
        }
        if (checkedPositions != 275)
        {
            throw new Exception("Navigation detail reference coverage changed.");
        }
        return checkedPositions + 3;
    }

    private static bool ContainsHeight(NavigationDetailCatalog.Triangle triangle, Vector3 point)
    {
        const float EdgeTolerance = 0.00001f;
        const float HeightTolerance = 0.0001f;
        Vector3 edgeA = triangle.Second - triangle.First;
        Vector3 edgeB = triangle.Third - triangle.First;
        Vector3 relative = point - triangle.First;
        float denominator = edgeA.X * edgeB.Z - edgeA.Z * edgeB.X;
        if (MathF.Abs(denominator) < 1e-12f)
        {
            return false;
        }
        float secondWeight = (relative.X * edgeB.Z - relative.Z * edgeB.X) / denominator;
        float thirdWeight = (edgeA.X * relative.Z - edgeA.Z * relative.X) / denominator;
        float height = triangle.First.Y + secondWeight * edgeA.Y + thirdWeight * edgeB.Y;
        return secondWeight >= -EdgeTolerance && thirdWeight >= -EdgeTolerance &&
            secondWeight + thirdWeight <= 1 + EdgeTolerance && MathF.Abs(point.Y - height) <= HeightTolerance;
    }

    private static void VerifyImmutable(IReadOnlyList<Vector3> boundary)
    {
        try
        {
            ((IList<Vector3>)boundary)[0] = Vector3.Zero;
            throw new Exception("Published navigation detail boundary is mutable.");
        }
        catch (NotSupportedException)
        {
            // Callers cannot modify source geometry through the published collection.
        }
    }

    private static void VerifyCorruption(string directory)
    {
        string temporary = Path.Combine(
            Path.GetTempPath(), "war-navigation-detail-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(Path.Combine(temporary, "coop-navmesh-detail"));
        try
        {
            foreach (string name in new[] { "recovered-coop-navmesh-detail.json", "recovered-coop-navmesh-sources.json" })
            {
                File.Copy(Path.Combine(directory, name), Path.Combine(temporary, name));
            }
            File.WriteAllText(Path.Combine(temporary, "coop-navmesh-detail", "NavMesh_7.json"), "{}");
            try
            {
                NavigationDetailCatalog.Load(temporary);
                throw new Exception("Damaged navigation detail artifact was accepted.");
            }
            catch (InvalidDataException)
            {
                // Rejection occurs before any catalog or partial map can be published.
            }
        }
        finally
        {
            File.Delete(Path.Combine(temporary, "coop-navmesh-detail", "NavMesh_7.json"));
            Directory.Delete(Path.Combine(temporary, "coop-navmesh-detail"));
            File.Delete(Path.Combine(temporary, "recovered-coop-navmesh-detail.json"));
            File.Delete(Path.Combine(temporary, "recovered-coop-navmesh-sources.json"));
            Directory.Delete(temporary);
        }
    }
}

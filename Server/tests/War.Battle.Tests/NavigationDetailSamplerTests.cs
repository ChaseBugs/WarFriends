using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares actual query-to-surface results on development and independent Unity sample positions.</summary>
internal static class NavigationDetailSamplerTests
{
    private const float SurfaceTolerance = 0.002f;
    private sealed record Reference(string Filename, string Digest, int Rows);

    internal static int Run(string directory)
    {
        NavigationDetailCatalog catalog = NavigationDetailCatalog.Load(directory);
        var samplers = catalog.Maps.ToDictionary(map => map.Name, map => new NavigationDetailSampler(map));
        var references = new[]
        {
            new Reference("recovered-helicopter-landing-offset-unity-reference.json",
                "01c66cae6eedc21c3a291e0a2a94c4b4cd783d46affa62adc16472169e45cd5b", 276),
            new Reference("recovered-helicopter-landing-holdout-unity-reference.json",
                "e43d48abf790fb58756d336ae33b0562492f5e929e5cfbb8412e0eb8df9ca757", 156),
        };
        int checks = 0;
        foreach (Reference reference in references)
        {
            checks += VerifyCapture(directory, reference, samplers);
        }
        return checks + VerifyCoopBinding(directory, catalog);
    }

    private static int VerifyCoopBinding(string directory, NavigationDetailCatalog details)
    {
        MissionCatalog missions = MissionCatalog.Load(Path.Combine(directory, "recovered-mission-catalog.json"));
        CoopNavMeshSourceCatalog sources = CoopNavMeshSourceCatalog.Load(
            Path.Combine(directory, "recovered-coop-navmesh-sources.json"), missions);
        CoopNavMeshTriangulationCatalog triangles = CoopNavMeshTriangulationCatalog.Load(
            Path.Combine(directory, "recovered-coop-navmesh-triangulation.json"), missions, sources);
        CoopNavMeshConnectivity connectivity = CoopNavMeshConnectivity.BuildWithDetails(triangles, details);
        Vector3 surface = triangles.Maps[0].Vertices[0];
        var query = new HelicopterRopeLandingQuery(surface + Vector3.UnitY * 8, surface);
        Vector3? actual = connectivity.SampleHelicopterLanding(missions, 0, query);
        if (actual == null || Vector3.Distance(actual.Value, surface) > SurfaceTolerance)
        {
            throw new Exception("Co-op landing did not use its digest-bound detail map.");
        }
        using JsonDocument reference = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,
            "recovered-helicopter-landing-unity-reference.json")));
        JsonElement directQuery = reference.RootElement.GetProperty("rows")[2];
        Vector3? crewSurface = connectivity.SampleHelicopterCrewLanding(
            missions, 0, Vector(directQuery.GetProperty("origin")));
        if (crewSurface == null || Vector3.Distance(crewSurface.Value,
            Vector(directQuery.GetProperty("position"))) > SurfaceTolerance)
        {
            throw new Exception("Crew landing did not use its direct marker query.");
        }
        try
        {
            CoopNavMeshConnectivity.Build(triangles).SampleHelicopterLanding(missions, 0, query);
            throw new Exception("Co-op landing silently fell back to approximate triangle sampling.");
        }
        catch (InvalidOperationException)
        {
            return 3;
        }
    }

    private static int VerifyCapture(string directory, Reference reference,
        IReadOnlyDictionary<string, NavigationDetailSampler> samplers)
    {
        string contents = File.ReadAllText(Path.Combine(directory, reference.Filename)).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents))) != reference.Digest)
        {
            throw new Exception("Navigation sampler reference changed.");
        }
        using JsonDocument document = JsonDocument.Parse(contents);
        JsonElement rows = document.RootElement.GetProperty("rows");
        if (rows.GetArrayLength() != reference.Rows)
        {
            throw new Exception("Navigation sampler reference is incomplete.");
        }
        foreach (JsonElement row in rows.EnumerateArray())
        {
            string name = row.GetProperty("map").GetString() ?? throw new Exception("Missing map identity.");
            if (name == "empty")
            {
                continue;
            }
            Vector3? actual = HelicopterRopeLanding.Resolve(new HelicopterRopeLandingQuery(
                Vector(row.GetProperty("origin")), Vector(row.GetProperty("player"))), samplers[name].Sample);
            bool found = row.GetProperty("found").GetBoolean();
            if (actual.HasValue != found || (found &&
                Vector3.Distance(actual.GetValueOrDefault(), Vector(row.GetProperty("position"))) > SurfaceTolerance))
            {
                throw new Exception($"Detail selection differs on {name} for query {row.GetProperty("query")}: " +
                    $"host {actual}, Unity {row.GetProperty("position")}.");
            }
        }
        Console.WriteLine($"PASS: polygon/detail sampling for {reference.Filename}: {reference.Rows - 1} map queries.");
        return reference.Rows - 1;
    }

    private static Vector3 Vector(JsonElement point)
    {
        return new Vector3(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle());
    }
}

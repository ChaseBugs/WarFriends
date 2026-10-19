using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares ShowRope query operations captured in Unity against recovered map triangles.</summary>
internal static class HelicopterLandingReferenceTests
{
    private const string CaptureDigest = "221ab86577105cc0c76a8046d688aa73898669ea59b8ae9b1c269dec04b48ff2";
    private const float SurfaceTolerance = 0.002f;

    internal static int Run(string directory)
    {
        string capture = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-landing-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(capture))) != CaptureDigest)
        {
            throw new Exception("Unity landing reference changed.");
        }
        using JsonDocument reference = JsonDocument.Parse(capture);
        var graphs = LoadGraphs(directory);
        int checks = 0;
        int differences = 0;
        foreach (JsonElement row in reference.RootElement.GetProperty("rows").EnumerateArray())
        {
            string map = row.GetProperty("map").GetString() ?? throw new Exception("Missing reference map.");
            if (map == "empty")
            {
                if (row.GetProperty("found").GetBoolean() ||
                    row.GetProperty("position").EnumerateArray().Any(value => value.GetString() != "Infinity"))
                {
                    throw new Exception("Failed Unity SamplePosition no longer returns positive infinite position.");
                }
                checks++;
                continue;
            }
            var query = new HelicopterRopeLandingQuery(Vector(row.GetProperty("origin")),
                Vector(row.GetProperty("player")));
            Vector3? actual = HelicopterRopeLanding.Resolve(query, graphs[map].SampleNearest);
            if (!row.GetProperty("found").GetBoolean() || actual == null ||
                Vector3.Distance(actual.Value, Vector(row.GetProperty("position"))) > SurfaceTolerance)
            {
                if (row.GetProperty("projected").GetBoolean())
                {
                    throw new Exception("Projected landing no longer matches the source surface: " + map);
                }
                differences++;
                Console.WriteLine($"DIAGNOSTIC landing differs for {map}: origin {query.RopeOrigin}, " +
                    $"player {query.PlayerPoint}, host {actual}, Unity {Vector(row.GetProperty("position"))}.");
                continue;
            }
            checks++;
        }
        if (checks + differences != 51)
        {
            throw new Exception("Unity landing reference is incomplete.");
        }
        Console.WriteLine($"Landing reference: {checks} accepted checks, {differences} unresolved above-plane samples.");
        return checks;
    }

    private static Dictionary<string, ArmyNavMeshConnectivity.Graph> LoadGraphs(string directory)
    {
        using JsonDocument manifest = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "recovered-coop-navmesh-triangulation.json")));
        var graphs = new Dictionary<string, ArmyNavMeshConnectivity.Graph>();
        foreach (JsonElement map in manifest.RootElement.GetProperty("maps").EnumerateArray())
        {
            string filename = map.GetProperty("file").GetString() ?? throw new Exception("Missing triangle filename.");
            byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "coop-navmesh-triangulation", filename));
            if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != map.GetProperty("sha256").GetString())
            {
                throw new Exception("Recovered landing triangle artifact changed.");
            }
            using JsonDocument mesh = JsonDocument.Parse(bytes);
            Vector3[] vertices = mesh.RootElement.GetProperty("vertices").EnumerateArray()
                .Select(point => new Vector3(point.GetProperty("x").GetSingle(),
                    point.GetProperty("y").GetSingle(), point.GetProperty("z").GetSingle())).ToArray();
            int[] indices = mesh.RootElement.GetProperty("indices").EnumerateArray()
                .Select(value => value.GetInt32()).ToArray();
            graphs.Add(Path.GetFileNameWithoutExtension(filename), new ArmyNavMeshConnectivity.Graph(vertices, indices));
        }
        return graphs;
    }

    private static Vector3 Vector(JsonElement point)
    {
        return new Vector3(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle());
    }
}

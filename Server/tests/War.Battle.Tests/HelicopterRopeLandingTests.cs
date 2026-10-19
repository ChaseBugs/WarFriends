using System.Numerics;
using War.BattleServer;

/// <summary>Exercises ShowRope projection against actual triangle nearest-surface lookup.</summary>
internal static class HelicopterRopeLandingTests
{
    internal static int Run()
    {
        var graph = new ArmyNavMeshConnectivity.Graph(new[]
        {
            new Vector3(-2, 0, -2), new Vector3(2, 0, -2), new Vector3(0, 0, 2),
            new Vector3(-2, 6, -2), new Vector3(2, 6, -2), new Vector3(0, 6, 2),
        }, new[] { 0, 1, 2, 3, 4, 5 });
        Vector3 origin = new(0, 8, 0);
        Vector3? lower = HelicopterRopeLanding.Resolve(
            new HelicopterRopeLandingQuery(origin, Vector3.Zero), graph.SampleNearest);
        Require(lower == Vector3.Zero);
        Vector3? upper = HelicopterRopeLanding.Resolve(
            new HelicopterRopeLandingQuery(origin, new Vector3(0, 6, 0)), graph.SampleNearest);
        Require(upper == new Vector3(0, 6, 0));
        Vector3? above = HelicopterRopeLanding.Resolve(
            new HelicopterRopeLandingQuery(origin, new Vector3(0, 20, 0)), graph.SampleNearest);
        Require(above == new Vector3(0, 6, 0));
        Vector3? missing = HelicopterRopeLanding.Resolve(
            new HelicopterRopeLandingQuery(new Vector3(50, 8, 0), Vector3.Zero), graph.SampleNearest);
        Require(missing == null);
        VerifyInvalidInputs(graph);
        return 6;
    }

    private static void VerifyInvalidInputs(ArmyNavMeshConnectivity.Graph graph)
    {
        foreach (Vector3 invalid in new[] { new Vector3(float.NaN, 0, 0), new Vector3(0, 10001, 0) })
        {
            try
            {
                HelicopterRopeLanding.Resolve(new HelicopterRopeLandingQuery(invalid, Vector3.Zero),
                    graph.SampleNearest);
                throw new Exception("Malformed rope landing origin was accepted.");
            }
            catch (InvalidDataException)
            {
                // Invalid source points must never reach surface or extension authority.
            }
        }
    }

    private static void Require(bool condition)
    {
        if (!condition)
        {
            throw new Exception("Helicopter ShowRope surface projection changed.");
        }
    }
}

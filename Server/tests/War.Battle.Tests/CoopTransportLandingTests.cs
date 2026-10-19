using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Exercises source-ordered arrival lookup in the real co-op runtime.</summary>
internal static class CoopTransportLandingTests
{
    internal static void Bind(CoopMatchRuntime runtime, string directory, MissionCatalog missions)
    {
        CoopNavMeshSourceCatalog sources = CoopNavMeshSourceCatalog.Load(
            Path.Combine(directory, "recovered-coop-navmesh-sources.json"), missions);
        CoopNavMeshTriangulationCatalog triangles = CoopNavMeshTriangulationCatalog.Load(
            Path.Combine(directory, "recovered-coop-navmesh-triangulation.json"), missions, sources);
        CoopNavMeshConnectivity navigation = CoopNavMeshConnectivity.BuildWithDetails(
            triangles, NavigationDetailCatalog.Load(directory));
        runtime.BindTransportLandingNavigation(navigation);
        try
        {
            runtime.BindTransportLandingNavigation(navigation);
            throw new Exception("Transport navigation binding was replaceable.");
        }
        catch (InvalidOperationException)
        {
            // Source geometry ownership is fixed before either participant is admitted.
        }
    }

    internal static void AdvanceAndVerify(CoopMatchRuntime runtime, BattleCoopEnemySpawn initial,
        ulong endTick, HelicopterCrewPointCatalog crewPoints)
    {
        BattleCoopEnemySpawn previous = initial;
        for (ulong next = initial.PoseTick + 1; next <= endTick; next++)
        {
            runtime.Advance(next);
            CoopMatchRuntime.TransportLanding? landing = runtime.TransportLandingFor(initial.EntityId);
            if (landing != null)
            {
                var position = new Vector3(previous.CurrentX, previous.CurrentY, previous.CurrentZ);
                BattleJointRotation source = previous.CurrentRotation;
                var rotation = new Quaternion(source.X, source.Y, source.Z, source.W);
                Vector3 expected = position + Vector3.Transform(crewPoints.Slots[0].RopeRestPosition, rotation);
                if (landing.StopTick != next || Vector3.Distance(landing.RopeOrigin, expected) > 0.000001f ||
                    landing.Surface == null)
                {
                    throw new Exception("Co-op arrival did not use the previous aircraft pose and a real surface.");
                }
                runtime.Advance(endTick);
                if (runtime.TransportLandingFor(initial.EntityId) != landing)
                {
                    throw new Exception("Co-op arrival decision changed on a later flight frame.");
                }
                return;
            }
            previous = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == initial.EntityId);
        }
        throw new Exception("Co-op transport did not produce its arrival landing decision.");
    }
}

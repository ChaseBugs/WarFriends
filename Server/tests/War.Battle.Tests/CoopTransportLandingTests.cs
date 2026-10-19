using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Exercises source-ordered arrival lookup in the real co-op runtime.</summary>
internal static class CoopTransportLandingTests
{
    private const float SourceActivationDelaySeconds = 2f;
    private const ulong NativeRegistryCapacity = 64;
    private const ulong SourceFirstDropDelayTicks = 5UL * MatchManifest.TickRate;
    private const ulong SourceDropSpacingTicks = 2UL * MatchManifest.TickRate;
    internal static void Bind(CoopMatchRuntime runtime, string directory, MissionCatalog missions)
    {
        CoopNavMeshSourceCatalog sources = CoopNavMeshSourceCatalog.Load(
            Path.Combine(directory, "recovered-coop-navmesh-sources.json"), missions);
        CoopNavMeshTriangulationCatalog triangles = CoopNavMeshTriangulationCatalog.Load(
            Path.Combine(directory, "recovered-coop-navmesh-triangulation.json"), missions, sources);
        CoopNavMeshConnectivity navigation = CoopNavMeshConnectivity.BuildWithDetails(
            triangles, NavigationDetailCatalog.Load(directory));
        runtime.BindTransportLandingNavigation(navigation);
        if (Environment.GetEnvironmentVariable("WAR_TEST_NATIVE_TRANSPORT_ROPES") == "1")
        {
            runtime.EnableTransportRopes();
            try
            {
                runtime.Advance(2);
                throw new Exception("Native runtime accepted catch-up without render observations.");
            }
            catch (InvalidOperationException)
            {
                if (runtime.Snapshot().ServerTick != 0)
                {
                    throw new Exception("Rejected native catch-up changed runtime time.");
                }
            }
        }
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

    internal static ulong AdvanceAndVerify(CoopMatchRuntime runtime, BattleCoopEnemySpawn initial,
        ulong endTick, HelicopterRopeDefinition rope)
    {
        BattleCoopEnemySpawn previous = initial;
        CoopMatchRuntime.TransportCrewBirth[] birthsAtSpawn = runtime.TransportCrewBirths(initial.EntityId).ToArray();
        if (runtime.HasNativeTransportRopes && (birthsAtSpawn.Length == 0 ||
            birthsAtSpawn.Any(birth => birth.SpawnTick != initial.SpawnTick)))
        {
            throw new Exception("Native transport did not publish its original crew births at spawn.");
        }
        for (ulong next = initial.PoseTick + 1; next <= endTick; next++)
        {
            AdvanceTo(runtime, next);
            if (runtime.TransportRopeSnapshot is HelicopterPhysicsWorldSnapshot ropes)
            {
                bool shouldBeActive = (float)(next / (double)MatchManifest.TickRate) >
                    (float)(initial.SpawnTick / (double)MatchManifest.TickRate) + SourceActivationDelaySeconds;
                if (ropes.Members.Any(member => member.Lease.EntityId == initial.EntityId) != shouldBeActive)
                {
                    throw new Exception("Runtime native rope activation differs from the source realtime deadline.");
                }
            }
            CoopMatchRuntime.TransportLanding? landing = runtime.TransportLandingFor(initial.EntityId);
            if (landing != null)
            {
                var position = new Vector3(previous.CurrentX, previous.CurrentY, previous.CurrentZ);
                BattleJointRotation source = previous.CurrentRotation;
                var rotation = new Quaternion(source.X, source.Y, source.Z, source.W);
                Vector3 expected = position + Vector3.Transform(rope.RootPosition, rotation);
                if (landing.StopTick != next || Vector3.Distance(landing.RopeOrigin, expected) > 0.000001f ||
                    landing.Surface == null)
                {
                    throw new Exception("Co-op arrival did not use the previous aircraft pose and a real surface.");
                }
                if (runtime.HasNativeTransportRopes)
                {
                    ulong slots = (ulong)runtime.TransportCrewMembers(initial.EntityId).Count;
                    endTick = Math.Max(endTick, landing.StopTick + SourceFirstDropDelayTicks +
                        SourceDropSpacingTicks * (slots - 1));
                }
                AdvanceTo(runtime, endTick);
                if (runtime.TransportLandingFor(initial.EntityId) != landing)
                {
                    throw new Exception("Co-op arrival decision changed on a later flight frame.");
                }
                if (!runtime.TransportCrewBirths(initial.EntityId).SequenceEqual(birthsAtSpawn))
                {
                    throw new Exception("Flight or drop rewrote the original crew birth evidence.");
                }
                return endTick;
            }
            previous = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == initial.EntityId);
        }
        throw new Exception("Co-op transport did not produce its arrival landing decision.");
    }

    internal static void AdvanceTo(CoopMatchRuntime runtime, ulong endTick)
    {
        if (!runtime.HasNativeTransportRopes)
        {
            runtime.Advance(endTick);
            return;
        }
        ulong current = runtime.Snapshot().ServerTick;
        for (ulong next = current + 1; next <= endTick; next++)
        {
            runtime.Advance(next, next / (double)MatchManifest.TickRate);
            runtime.RenderTransportRopes(1f / MatchManifest.TickRate);
        }
    }

    internal static void Finish(CoopMatchRuntime runtime, ulong entityId, HelicopterRopeDefinition definition)
    {
        if (!runtime.HasNativeTransportRopes)
        {
            return;
        }
        if (runtime.TransportRopeSnapshot?.Members.Any(member => member.Lease.EntityId == entityId) != false ||
            runtime.TransportCrewDrops(entityId).Count != 0 || runtime.TransportCrewBirths(entityId).Count != 0)
        {
            throw new Exception("Transport death retained its native scene.");
        }
        runtime.Dispose();
        runtime.Dispose();
        if (!runtime.Terminal || runtime.TransportRopeSnapshot != null ||
            runtime.Snapshot().TerminalReason != "host-shutdown")
        {
            throw new Exception("Runtime disposal did not close native scene ownership.");
        }
        using var replacement = new NativeHelicopterPhysicsWorld();
        var aircraft = new HelicopterRopeBodyPose(Vector3.Zero, Quaternion.Identity);
        for (ulong identity = 1; identity <= NativeRegistryCapacity; identity++)
        {
            replacement.Add(identity, definition.CreateInitial(aircraft), aircraft, definition.CreationRestRotation);
        }
        Console.WriteLine("PASS: co-op native activation, arrival, death, disposal and complete registry reuse.");
    }

    internal static void VerifyCrewDrops(CoopMatchRuntime runtime, ulong entityId, HelicopterCrewPointCatalog points)
    {
        if (!runtime.HasNativeTransportRopes)
        {
            return;
        }
        IReadOnlyList<CoopMatchRuntime.TransportCrewDrop> drops = runtime.TransportCrewDrops(entityId);
        IReadOnlyList<CoopMatchRuntime.TransportCrewBirth> births = runtime.TransportCrewBirths(entityId);
        IReadOnlyList<HelicopterCrewDescentSnapshot> descents = runtime.TransportCrewDescents(entityId);
        HelicopterPhysicsWorldSnapshot physics = runtime.TransportRopeSnapshot
            ?? throw new Exception("Crew drop fixture lost native world state.");
        HelicopterPhysicsMemberSnapshot rope = physics.Members.Single(member => member.Lease.EntityId == entityId);
        if (drops.Count == 0 || drops.Count != descents.Count || births.Count != drops.Count)
        {
            throw new Exception($"Crew drop boundary mismatch: captured {drops.Count}, descents {descents.Count}.");
        }
        foreach (CoopMatchRuntime.TransportCrewDrop drop in drops)
        {
            HelicopterCrewPoint slot = points.Slots[drop.Slot];
            Vector3 marker = drop.Aircraft.Position +
                Vector3.Transform(slot.RopeRestPosition, drop.Aircraft.Rotation);
            Vector3 root = drop.Aircraft.Position + Vector3.Transform(slot.RestPosition, drop.Aircraft.Rotation);
            CoopMatchRuntime.TransportCrewBirth birth = births.Single(entry => entry.Slot == drop.Slot);
            Vector3 birthPoint = birth.Aircraft.Position + Vector3.Transform(slot.RestPosition, birth.Aircraft.Rotation);
            if (drop.StartTick != descents.Single(descent => descent.Slot == drop.Slot).StartTick ||
                drop.Birth != birth || birth.SpawnTick >= drop.StartTick ||
                Vector3.Distance(birth.CrewPoint.Position, birthPoint) > 0.000001f ||
                Vector3.Distance(drop.RopeMarker, marker) > 0.000001f ||
                Vector3.Distance(drop.CrewPoint.Position, root) > 0.000001f || drop.LandingSurface == null ||
                drop.InitialPoolParentRotation != Quaternion.Identity || drop.SpawnResetRotation != Quaternion.Identity ||
                drop.RopeLease != rope.Lease || drop.PhysicsSequence == 0 ||
                drop.PhysicsSequence > physics.PhysicsSteps)
            {
                throw new Exception("Crew drop lost its marker, crew point, surface or live rope binding.");
            }
        }
        if (drops.All(drop => Vector3.Distance(drop.Birth.CrewPoint.Position, drop.CrewPoint.Position) < 0.1f))
        {
            throw new Exception("Crew birth fixture never separated the original spawn point from the later drop point.");
        }
        Console.WriteLine($"PASS: {drops.Count} source crew drop inputs bound to native rope and direct surface lookup.");
    }
}

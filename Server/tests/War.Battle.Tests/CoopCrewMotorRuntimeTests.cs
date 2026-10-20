using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Uses native descent roots and host corridors without asserting Unity steering equivalence.</summary>
internal static class CoopCrewMotorRuntimeTests
{
    private const ulong SpawnTick = 10UL * MatchManifest.TickRate;
    private const ulong MaximumFixtureTick = 2000;
    private const float SpeedTolerance = 0.001f;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        if (Environment.GetEnvironmentVariable("WAR_TEST_NATIVE_TRANSPORT_ROPES") != "1")
        {
            return;
        }
        using CoopMatchRuntime runtime = CoopCrewCompletionRuntimeTests.CreateTargetingRuntime(sources, directory,
            out _, (_ => 0, () => 0));
        CoopTransportLandingTests.Bind(runtime, directory, sources.Missions);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            runtime.Admit(player.PlayerId);
            runtime.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash },
            });
        }
        CoopTransportLandingTests.AdvanceTo(runtime, SpawnTick);
        ulong aircraftId = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.Behaviour == "DeployHeli").EntityId;
        var observer = new CoopTransportCrewDescentTests();
        CoopMatchRuntime.TransportCrewNavigationCommand? command = null;
        observer.Completed += (source, parent, slot) =>
        {
            if (slot != 0 || command != null)
            {
                return;
            }
            var descent = source.TransportCrewDescentSnapshots(parent).Single(row => row.Slot == slot);
            source.CompleteTransportCrewDescent(descent.ActorEntityId,
                new HelicopterCrewRetryObservation(descent.RenderFrame,
                    source.Snapshot().ServerTick / (float)MatchManifest.TickRate, descent.Pose.Position));
            command = source.TransportCrewNavigation(descent.ActorEntityId) ??
                throw new Exception("Native descent did not create crew navigation.");
            Require(command.StartPosition == descent.Pose.Position && source.BeginTransportCrewNavigation(command),
                "Crew motor did not retain the actual descent root.");
            Require(source.TryBeginTransportCrewMotor(command), "Actual descent root had no covered host route.");
            Require(!source.TryBeginTransportCrewMotor(command), "Crew path motor started twice.");
            Require(!source.TryBeginTransportCrewMotor(command with { }), "Copied navigation owned a path motor.");
            Reject(() => source.AdvanceTransportCrewMotor(command,
                new CoopMatchRuntime.TransportCrewMotorObservation(descent.RenderFrame, false)));
        };
        for (ulong next = SpawnTick + 1; next <= MaximumFixtureTick && command == null; next++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, next);
            observer.Observe(runtime, aircraftId, next);
        }
        VerifyArrival(runtime, command ?? throw new Exception("Crew motor fixture did not finish native descent."));
        Console.WriteLine("PASS: native crew descent root follows a host corridor into source point entry.");
    }

    private static void VerifyArrival(CoopMatchRuntime runtime, CoopMatchRuntime.TransportCrewNavigationCommand command)
    {
        for (ulong next = runtime.Snapshot().ServerTick + 1; next <= MaximumFixtureTick; next++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, next);
            var observation = new CoopMatchRuntime.TransportCrewMotorObservation(
                runtime.TransportRopeSnapshot!.RenderFrames, false);
            CoopMatchRuntime.TransportCrewMotorSample sample = runtime.AdvanceTransportCrewMotor(command, observation);
            Require(sample.Velocity.Length() <= command.MaximumSpeed + SpeedTolerance,
                "Crew motor exceeded its source movement speed.");
            Reject(() => runtime.AdvanceTransportCrewMotor(command, observation));
            if (sample.Arrival == null)
            {
                continue;
            }
            Require(EnemyPointArrivalPolicy.HasReached(sample.Position, command.Destination, false),
                "Generated root did not satisfy source arrival geometry.");
            TransportCrewPointEntry entry = runtime.EnterTransportCrewPoint(command, sample.Arrival,
                next / (float)MatchManifest.TickRate);
            Require(entry.IsCrawling && runtime.TransportCrewHiddenEntry(command) == entry,
                "Generated path arrival did not enter its source obstacle state.");
            VerifyPreparedTurn(runtime, command, sample, entry);
            return;
        }
        throw new Exception("Host crew path did not reach its authored point within the bounded fixture.");
    }

    private static void VerifyPreparedTurn(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command,
        CoopMatchRuntime.TransportCrewMotorSample sample, TransportCrewPointEntry entry)
    {
        ulong preparationTick = (ulong)MathF.Ceiling(entry.NextShootTime * MatchManifest.TickRate) + 1;
        CoopTransportLandingTests.AdvanceTo(runtime, preparationTick);
        float time = preparationTick / (float)MatchManifest.TickRate;
        var pending = new CoopMatchRuntime.TransportCrewObstacleObservation(
            new TransportCrewObstacleClock.Observation(runtime.TransportRopeSnapshot!.RenderFrames,
                time, false, true), sample.Position);
        Require(runtime.AdvanceTransportCrewObstacle(command, pending) ==
            TransportCrewObstacleClock.ActionKind.ShotPreparationRequired, "Motor crew shot was not due.");
        var target = runtime.AcquireTransportCrewTarget(command, pending, null).Target ??
            throw new Exception("Stationary motor crew did not acquire its source player target.");
        var prepared = runtime.PrepareTransportCrewShot(command, target, time);
        Vector3 facing = sample.PathFacing ?? throw new Exception("Moving crew route had no path facing.");
        Quaternion root = Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.Atan2(facing.X, facing.Z));
        var begin = new TransportCrewShotTurn.Observation(pending.Clock.Frame, root, 0);
        Reject(() => runtime.BeginTransportCrewShotTurn(command, prepared with { }, begin));
        runtime.BeginTransportCrewShotTurn(command, prepared, begin);
        Reject(() => runtime.BeginTransportCrewShotTurn(command, prepared, begin));
        for (ulong offset = 1; offset <= 8; offset++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, preparationTick + offset);
            var observation = new TransportCrewShotTurn.Observation(runtime.TransportRopeSnapshot!.RenderFrames,
                root, 1f / MatchManifest.TickRate);
            root = runtime.AdvanceTransportCrewShotTurn(command, observation);
            Reject(() => runtime.AdvanceTransportCrewShotTurn(command, observation));
        }
        Quaternion expected = CoopAssaulterShotRotation.Obstacle(sample.Position, target.PreparedAimPosition);
        Require(1 - MathF.Abs(Quaternion.Dot(root, expected)) < 0.000001f,
            "Motor crew did not reach its source obstacle preparation rotation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new Exception("Repeated crew motor tick was accepted.");
    }
}

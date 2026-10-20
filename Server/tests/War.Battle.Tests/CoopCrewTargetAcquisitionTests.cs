using System.Numerics;
using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

/// <summary>Exercises match-owned source targeting on native frames using synthetic crew roots/muzzles.</summary>
internal static class CoopCrewTargetAcquisitionTests
{
    private const ulong SpawnTick = 10UL * MatchManifest.TickRate;
    private const ulong MaximumFixtureTick = 2000;
    private const float SyntheticCrewDistance = 4f;
    private const float SyntheticMuzzleHeight = 0.2f;
    private const float CoroutineOrigin = 100f;
    private const int ShieldTargetMask = 2;
    private const int WholeBodyTargetMask = 9;
    private const int MovingTargetMask = 16;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        if (Environment.GetEnvironmentVariable("WAR_TEST_NATIVE_TRANSPORT_ROPES") != "1")
        {
            return;
        }
        RunCase(sources, directory, new Scenario(false, 0));
        RunCase(sources, directory, new Scenario(false, 0.99f));
        RunCase(sources, directory, new Scenario(true, 0.99f));
        RunCase(sources, directory, new Scenario(true, 0));
        Console.WriteLine(
            "PASS: crew source target acquisition, retained moving choice and server-derived preparation.");
    }

    private static void RunCase(CoopObstacleVolleyRuntimeTests.Sources sources, string directory, Scenario scenario)
    {
        string masterId = sources.Manifest.Players[1].PlayerId;
        sources = sources with
        {
            Manifest = sources.Manifest with
            {
                SceneMasterPlayerId = masterId,
                Players = sources.Manifest.Players.Select(player => player with { PlayerLevel = 0 }).ToArray(),
            },
        };
        int indexDraws = 0;
        using CoopMatchRuntime runtime = CoopCrewCompletionRuntimeTests.CreateTargetingRuntime(sources, directory,
            out _, (count => { indexDraws++; return 0; }, () => scenario.ShieldRoll));
        CoopTransportLandingTests.Bind(runtime, directory, sources.Missions);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            runtime.Admit(player.PlayerId);
            runtime.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash },
            });
        }
        CoopMatchRuntime.TransportCrewNavigationCommand command = CompleteCrew(runtime);
        if (scenario.Moving)
        {
            Require(runtime.Command(masterId, new MatchCommand
            {
                CommandId = 2, MoveCover = new MoveCoverCommand { Direction = -1 },
            }).Code == "moving", "Target fixture could not begin the source master route.");
            CoopTransportLandingTests.AdvanceTo(runtime, runtime.Snapshot().ServerTick + 2);
            Require(runtime.PlaceMovingPlayerPose(masterId) != null, "Moving target pose was not ready.");
        }
        else
        {
            CoopTransportLandingTests.AdvanceTo(runtime, runtime.Snapshot().ServerTick + 1);
        }
        BattlePlayerState playerState = runtime.Snapshot().Players.Single(player => player.PlayerId == masterId);
        Vector3 root = new Vector3(playerState.PositionX, playerState.PositionY, playerState.PositionZ) +
            runtime.PlayerAimForward(masterId) * SyntheticCrewDistance;
        TransportCrewPointEntry entry = runtime.TransportCrewHiddenEntry(command) ??
            throw new Exception("Crew target fixture has no obstacle entry.");
        var pending = new CoopMatchRuntime.TransportCrewObstacleObservation(
            new TransportCrewObstacleClock.Observation(runtime.TransportRopeSnapshot!.RenderFrames,
                entry.NextShootTime + 0.01f, false, true), root);
        Require(runtime.AdvanceTransportCrewObstacle(command, pending) ==
            TransportCrewObstacleClock.ActionKind.ShotPreparationRequired, "Crew shot window was not due.");
        VerifyAcquisition(runtime, command, pending, new AcquisitionFixture(masterId, scenario, () => indexDraws));
    }

    private static CoopMatchRuntime.TransportCrewNavigationCommand CompleteCrew(CoopMatchRuntime runtime)
    {
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
            var clock = new HelicopterCrewRetryObservation(descent.RenderFrame, 1.25f, descent.Pose.Position);
            CoopHelicopterExitTarget target = source.CompleteTransportCrewDescent(descent.ActorEntityId, clock);
            command = CoopCrewNavigationTests.VerifyIssued(source, descent.ActorEntityId, clock, target);
        };
        for (ulong tick = SpawnTick + 1; tick <= MaximumFixtureTick && command == null; tick++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, tick);
            observer.Observe(runtime, aircraftId, tick);
        }
        return command ?? throw new Exception("Crew target fixture did not finish native descent.");
    }

    private static void VerifyAcquisition(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command,
        CoopMatchRuntime.TransportCrewObstacleObservation pending,
        AcquisitionFixture fixture)
    {
        int beforeDraws = fixture.IndexDraws();
        byte[] before = runtime.Snapshot().ToByteArray();
        Reject(() => runtime.AcquireTransportCrewTarget(command with { }, pending, null));
        Reject(() => runtime.AcquireTransportCrewTarget(command, pending, new Vector3(float.NaN)));
        var initial = runtime.AcquireTransportCrewTarget(command, pending, null);
        int expectedDraws = fixture.Scenario.ShieldRoll == 0 ? 2 : 1;
        Require(fixture.IndexDraws() - beforeDraws == expectedDraws,
            "Crew target selection lost player or one-element shield draw ordering.");
        bool movingBody = fixture.Scenario.Moving && fixture.Scenario.ShieldRoll != 0;
        if (movingBody)
        {
            Require(initial.Target == null && initial.UnavailableReason == "weapon-muzzle-unavailable",
                "Missing moving acquisition muzzle became a different target or NoTarget result.");
        }
        Vector3 muzzle = pending.Position + Vector3.UnitY * SyntheticMuzzleHeight;
        CoopMatchRuntime.TransportCrewTargetPlan target =
            runtime.AcquireTransportCrewTarget(command, pending, muzzle).Target ??
                throw new Exception("Source target resolution did not produce a plan.");
        int expectedMask = fixture.Scenario.ShieldRoll == 0 ? ShieldTargetMask : WholeBodyTargetMask;
        if (movingBody)
        {
            expectedMask = MovingTargetMask;
        }
        Require(target.PlayerId == fixture.MasterId && target.TargetWasWalking == fixture.Scenario.Moving &&
            target.TargetMask == expectedMask &&
            fixture.IndexDraws() - beforeDraws == expectedDraws,
            "Retry rerolled the target or lost master/peer source registration order.");
        Require(ReferenceEquals(runtime.AcquireTransportCrewTarget(command, pending, muzzle).Target, target),
            "Resolved acquisition was not retained for this source action.");
        Require(movingBody ? target.PreparedAimPosition != target.TransformPosition :
            target.PreparedAimPosition == target.TransformPosition, "Moving lead or raw shield target changed.");
        Require(runtime.Snapshot().ToByteArray().AsSpan().SequenceEqual(before),
            "Acquisition manufactured published projectile or damage state.");
        Reject(() => runtime.PrepareTransportCrewShot(command, target with { }, CoroutineOrigin));
        var prepared = runtime.PrepareTransportCrewShot(command, target, CoroutineOrigin);
        var clock = runtime.TransportCrewObstacleState(command);
        Require(ReferenceEquals(prepared.Target, target) && prepared.Batch.Count > 0 &&
            ReferenceEquals(runtime.PrepareTransportCrewShot(command, target, CoroutineOrigin), prepared) &&
            clock == runtime.TransportCrewObstacleState(command),
            "Preparation did not bind its source target, batch and replay identity.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidOperationException or InvalidDataException)
        {
            return;
        }
        throw new Exception("Invalid crew target acquisition was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed record Scenario(bool Moving, float ShieldRoll);

    private sealed record AcquisitionFixture(string MasterId, Scenario Scenario, Func<int> IndexDraws);
}

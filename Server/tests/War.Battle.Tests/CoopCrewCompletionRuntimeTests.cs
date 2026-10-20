using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks source point handoff on the exact accepted native completion frame.</summary>
internal static class CoopCrewCompletionRuntimeTests
{
    private const int MissionIndex = 46;
    private const ulong SpawnTick = 10UL * MatchManifest.TickRate;
    private const ulong MaximumFixtureTick = 2000;
    private const ulong FixtureOccupantBase = 1UL << 62;
    private const int MaximumFixtureOccupants = 64;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        if (Environment.GetEnvironmentVariable("WAR_TEST_NATIVE_TRANSPORT_ROPES") != "1")
        {
            return;
        }

        RunAvailablePoint(sources, directory);
        RunBlockedPoints(sources, directory);
    }

    private static void RunAvailablePoint(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        using CoopMatchRuntime runtime = CreateRuntime(sources, directory, out CoopEnemyDestinationState destinations);
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
        bool completed = false;
        observer.Completed += (source, parent, slot) =>
        {
            if (slot == 0)
            {
                VerifyCompletion(source, destinations, parent, slot);
                completed = true;
            }
        };
        for (ulong tick = SpawnTick + 1; tick <= MaximumFixtureTick && !completed; tick++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, tick);
            observer.Observe(runtime, aircraftId, tick);
        }
        Require(completed, "No source completion callback reached its native frame.");
        ulong detachedId = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.EntityId == aircraftId)
            .CrewActors[0].EntityId;
        CoopMatchRuntime.TransportCrewNavigationCommand command = runtime.TransportCrewNavigation(detachedId) ??
            throw new Exception("Completion fixture lost the surviving navigation input.");
        runtime.Dispose();
        CoopCrewNavigationTests.VerifyRetired(runtime, command);
        Require(runtime.TransportCrewNavigation(detachedId) == null, "Shutdown retained crew navigation state.");
        Console.WriteLine("PASS: native crew completion reserves a point, releases its seat " +
            "and survives parent death.");
    }

    private static void RunBlockedPoints(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        using CoopMatchRuntime runtime = CreateRuntime(sources, directory, out CoopEnemyDestinationState destinations);
        CoopTransportLandingTests.Bind(runtime, directory, sources.Missions);
        var occupants = new List<ulong>();
        for (int index = 0; index < MaximumFixtureOccupants; index++)
        {
            ulong occupant = FixtureOccupantBase + (ulong)index;
            if (destinations.TryAssignHelicopterAssaulter(occupant) == null)
            {
                break;
            }
            occupants.Add(occupant);
        }
        Require(occupants.Count is > 0 and < MaximumFixtureOccupants,
            "Blocked-point fixture did not exhaust the bounded source point set.");
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
        HelicopterCrewRetryObservation? firstClock = null;
        ulong retryActorId = 0;
        bool secondCancelled = false;
        observer.Completed += (source, parent, slot) =>
        {
            var descent = source.TransportCrewDescentSnapshots(parent).Single(row => row.Slot == slot);
            HelicopterCrewRetryObservation clock = Clock(source, descent);
            CoopHelicopterExitTarget target = source.CompleteTransportCrewDescent(descent.ActorEntityId, clock);
            Require(target is CoopHelicopterFallbackTarget &&
                source.TransportCrewActor(descent.ActorEntityId) is { IsAttached: true } &&
                destinations.ForEnemy(descent.ActorEntityId) == null,
                "Full source points did not retain the seat while selecting a normal-spawn fallback.");
            CoopMatchRuntime.TransportCrewNavigationCommand command =
                CoopCrewNavigationTests.VerifyIssued(source, descent.ActorEntityId, clock, target);
            if (slot == 0)
            {
                firstClock = clock;
                retryActorId = descent.ActorEntityId;
            }
            else
            {
                float health = source.TransportCrewActor(descent.ActorEntityId)!.Value.Health;
                Require(source.ApplyHostEnemyDamage(descent.ActorEntityId, health, source.Snapshot().ServerTick) &&
                    source.TransportCrewExit(descent.ActorEntityId) == null,
                    "Fallback actor death retained its pending exit state.");
                Reject(() => source.AdvanceTransportCrewRetry(descent.ActorEntityId, clock));
                CoopCrewNavigationTests.VerifyRetired(source, command);
                Require(source.TransportCrewNavigation(descent.ActorEntityId) == null,
                    "Dead fallback actor retained its navigation input.");
                secondCancelled = true;
            }
        };
        for (ulong tick = SpawnTick + 1; tick <= MaximumFixtureTick && !secondCancelled; tick++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, tick);
            observer.Observe(runtime, aircraftId, tick);
        }
        Require(firstClock != null && secondCancelled, "Both blocked crew callbacks must reach the native runtime.");
        VerifyRetryDeadline(runtime, destinations, new RetryScenario(retryActorId, firstClock!, occupants[0]));
        VerifySurvival(runtime, aircraftId, retryActorId);
        Console.WriteLine("PASS: native crew fallback retains its seat, waits scaled time and cancels on actor death.");
    }

    private static void VerifyRetryDeadline(CoopMatchRuntime runtime, CoopEnemyDestinationState destinations,
        RetryScenario scenario)
    {
        ulong actorId = scenario.ActorId;
        HelicopterCrewRetryObservation origin = scenario.Origin;
        CoopMatchRuntime.TransportCrewNavigationCommand previous = runtime.TransportCrewNavigation(actorId) ??
            throw new Exception("Fallback retry lost its original navigation input.");
        CoopAssignedEnemyDestination released = destinations.ForEnemy(scenario.Occupant)!;
        float deadline = origin.ScaledTime + CoopHelicopterFallbackTarget.RetryDelayScaledSeconds;
        ulong startTick = runtime.Snapshot().ServerTick;
        for (ulong tick = startTick + 1; tick <= MaximumFixtureTick; tick++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, tick);
            // Release after normal wave processing so this check owns occupancy at callback time.
            Require(destinations.Release(scenario.Occupant), "Fixture occupant lost its reserved source point.");
            var observation = new HelicopterCrewRetryObservation(runtime.TransportRopeSnapshot!.RenderFrames,
                (float)(tick / (double)MatchManifest.TickRate), origin.Position);
            CoopAssignedEnemyDestination? assigned = runtime.AdvanceTransportCrewRetry(actorId, observation);
            if (observation.ScaledTime < deadline)
            {
                Require(assigned == null && runtime.TransportCrewActor(actorId) is { IsAttached: true },
                    "Crew fallback reserved a free point before its source scaled wait elapsed.");
                Require(destinations.TryAssignHelicopterAssaulter(scenario.Occupant)?.PointComponentFileId ==
                    released.PointComponentFileId, "Fixture could not restore its source point before the next frame.");
                continue;
            }
            Require(assigned?.PointComponentFileId == released.PointComponentFileId &&
                runtime.TransportCrewActor(actorId) is { IsAttached: false } &&
                runtime.TransportCrewExit(actorId) is CoopHelicopterEnemyTarget,
                $"Due crew retry expected point {released.PointComponentFileId}, " +
                $"got {assigned?.PointComponentFileId}; " +
                $"attached={runtime.TransportCrewActor(actorId)?.IsAttached}, tick={tick}, " +
                "ordinary owners=" + string.Join(",", runtime.Snapshot().Coop.EnemySpawns
                    .Where(row => destinations.ForEnemy(row.EntityId)?.PointComponentFileId ==
                        released.PointComponentFileId).Select(row => row.EntityId)));
            Reject(() => runtime.AdvanceTransportCrewRetry(actorId, observation));
            CoopCrewNavigationTests.VerifyRetired(runtime, previous);
            CoopCrewNavigationTests.VerifyIssued(runtime, actorId, observation, runtime.TransportCrewExit(actorId)!);
            return;
        }
        throw new Exception("Crew retry did not execute within the bounded source window.");
    }

    private static HelicopterCrewRetryObservation Clock(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewDescentSnapshot descent)
    {
        return new HelicopterCrewRetryObservation(descent.RenderFrame,
            (float)(runtime.Snapshot().ServerTick / (double)MatchManifest.TickRate), descent.Pose.Position);
    }

    private static CoopMatchRuntime CreateRuntime(CoopObstacleVolleyRuntimeTests.Sources sources,
        string directory, out CoopEnemyDestinationState destinations)
    {
        MissionMapRule map = sources.Missions.MapForMission(MissionIndex);
        MatchManifest manifest = sources.Manifest with
        {
            MatchId = "crew-completion", MissionIndex = MissionIndex, MapId = map.Scene,
            MapRevision = map.SceneSha256, DurationSeconds = sources.Missions.Get(MissionIndex).TimeSeconds,
        };
        CoopEnemyPointCatalog points = CoopEnemyPointCatalog.Load(
            Path.Combine(directory, "recovered-coop-enemy-points.json"), sources.Missions, sources.Spawns);
        destinations = new CoopEnemyDestinationState(points.MapForMission(sources.Missions, MissionIndex),
            sources.Masks, sources.Combat, chooseObstacleFraction: () => 0.5f, chooseNextPoint: _ => 0);
        return new CoopMatchRuntime(manifest, sources.Missions, sources.Spawns, sources.Routes, sources.Combat,
            chooseBehaviour: _ => 0, choosePoint: _ => 0, playerWeaponContent: sources.Content,
            enemyDestinations: destinations, coopAirWaypoints: CoopAirWaypointCatalog.Load(
                Path.Combine(directory, "recovered-coop-air-waypoint-routes.json"), sources.Spawns));
    }

    private static void VerifyCompletion(CoopMatchRuntime runtime, CoopEnemyDestinationState destinations,
        ulong aircraftId, int slot)
    {
        CoopMatchRuntime.TransportCrewDescentSnapshot descent = runtime.TransportCrewDescentSnapshots(aircraftId)
            .Single(row => row.Slot == slot);
        HelicopterCrewRetryObservation clock = Clock(runtime, descent);
        byte[] before = runtime.Snapshot().ToByteArray();
        Reject(() => runtime.CompleteTransportCrewDescent(
            descent.ActorEntityId, clock with { ScaledTime = float.NaN }));
        Reject(() => runtime.CompleteTransportCrewDescent(
            descent.ActorEntityId, clock with { Frame = clock.Frame - 1 }));
        Require(runtime.Snapshot().ToByteArray().AsSpan().SequenceEqual(before) &&
            destinations.ForEnemy(descent.ActorEntityId) == null,
            "Invalid completion clock changed source reservations or published state.");
        CoopCrewMotionLifetimeTests.Observation? motion =
            CoopCrewMotionLifetimeTests.Capture(runtime, aircraftId, slot);
        CoopHelicopterExitTarget target = runtime.CompleteTransportCrewDescent(descent.ActorEntityId, clock);
        Require(target is CoopHelicopterEnemyTarget point &&
            destinations.ForEnemy(descent.ActorEntityId) == point.Destination &&
            runtime.TransportCrewActor(descent.ActorEntityId) is { IsAttached: false, Health: > 0 } &&
            runtime.TransportCrewExit(descent.ActorEntityId) == target,
            "Completed native crew did not hand off its shared scene point and source seat.");
        CoopCrewMotionLifetimeTests.VerifyRetired(runtime, aircraftId, motion);
        CoopCrewNavigationTests.VerifyIssued(runtime, descent.ActorEntityId, clock, target);
        Reject(() => runtime.CompleteTransportCrewDescent(descent.ActorEntityId, clock));
        VerifySurvival(runtime, aircraftId, descent.ActorEntityId);
    }

    private static void VerifySurvival(CoopMatchRuntime runtime, ulong aircraftId, ulong actorId)
    {
        MatchSnapshot snapshot = runtime.Snapshot();
        BattleCoopEnemySpawn aircraft = snapshot.Coop.EnemySpawns.Single(row => row.EntityId == aircraftId);
        CoopMatchRuntime.TransportCrewNavigationCommand command = runtime.TransportCrewNavigation(actorId) ??
            throw new Exception("Detached actor lost its independent navigation input.");
        Require(runtime.ApplyHostEnemyDamage(aircraftId, aircraft.MaxHealth, snapshot.ServerTick) &&
            runtime.TransportCrewActor(actorId) is { IsAttached: false, Health: > 0 } &&
            runtime.TransportCrewExit(actorId) is CoopHelicopterEnemyTarget &&
            runtime.IsTransportCrewNavigationCurrent(command),
            "Source point handoff did not survive the original aircraft's death.");
    }

    private static void Reject(Action callback)
    {
        try
        {
            callback();
        }
        catch (Exception error) when (error is InvalidDataException or InvalidOperationException)
        {
            return;
        }
        throw new Exception("Malformed or replayed source completion was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed record RetryScenario(ulong ActorId, HelicopterCrewRetryObservation Origin, ulong Occupant);
}

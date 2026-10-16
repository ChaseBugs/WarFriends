using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Exercises post-volley same-segment movement through the isolated co-op scheduler.</summary>
internal static class CoopObstacleVolleyRuntimeTests
{
    private const ulong MaximumFixtureTick = 2000;
    private const float RoundHideSeconds = 0.5f;
    private const float CrawlCenterTolerance = 0.00002f;
    private const float SourceTurnSeconds = 0.2f;
    private const float RootRotationTolerance = 0.000001f;
    private const int LatestPointChangeSeconds = 19;
    private const int FreePointChangeSeconds = 10;
    private const int BusyPointChangeSeconds = 11;
    private const ulong PointRetryTicks = 10UL * MatchManifest.TickRate;

    internal sealed record Sources
    {
        internal required MatchManifest Manifest { get; init; }
        internal required MissionCatalog Missions { get; init; }
        internal required CoopSpawnPointCatalog Spawns { get; init; }
        internal required CoopNavMeshPathCatalog Routes { get; init; }
        internal required CoopEnemyCombatCatalog Combat { get; init; }
        internal required CoopMapEnemyPoints Map { get; init; }
        internal required CoopEnemyPointMaskCatalog Masks { get; init; }
        internal required CoopNavMeshConnectivity Navigation { get; init; }
        internal required BattleCombatContent Content { get; init; }
        internal int SpawnIndex { get; init; }
        internal int PointChangeSeconds { get; init; } = LatestPointChangeSeconds;
    }

    internal static void Run(Sources sources)
    {
        float shotFraction = 0f;
        bool hasReachedObstacle = false;
        CoopMatchRuntime runtime = CreateRuntime(sources, () => shotFraction,
            () => hasReachedObstacle ? 0f : 0.999f);
        runtime.Advance(8);
        ulong enemyId = runtime.Snapshot().Coop.EnemySpawns.First().EntityId;
        AdvanceUntilPrepared(runtime, enemyId, () => hasReachedObstacle = true);
        shotFraction = 0.999f;
        ulong preparedTick = runtime.InfantryShotWindup(enemyId)!.StartTick;
        VerifyStationaryRootTurn(runtime, enemyId);
        runtime.Advance(preparedTick + 6);
        Check(runtime.PlaceObstacleVolleyHitboxes(enemyId).Count == 3 &&
            runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "The runtime may expose source pose candidates without promoting them to hit authority.");
        CoopObstacleVolleySnapshot prepared = runtime.ObstacleVolleyState(enemyId)!;
        AdvanceUntilCompleted(runtime, enemyId);
        CoopInfantryShotWindup completed = runtime.InfantryShotWindup(enemyId)!;
        VerifyRoundMuzzleClocks(runtime, enemyId);
        CoopObstaclePosePlanExport.WriteIfRequested(sources.Content, completed,
            runtime.InfantryRoundIntents(enemyId));
        CoopObstacleVolleySnapshot clock = runtime.ObstacleVolleyState(enemyId)!;
        ulong moveTick = Math.Max(prepared.NextPositionTick, completed.CompletedTick!.Value + 1);
        Check(moveTick < clock.NextShotTick, "The fixture must leave a movement window before its next shot.");
        VerifyCrawlReturn(runtime, enemyId, sources.Content);
        runtime.Advance(moveTick - 1);
        Check(runtime.ObstacleRepositionStartedTick(enemyId) == null,
            "The completed volley must not move before its source position deadline.");
        VerifyDeferredMove(runtime, enemyId, moveTick);
        runtime.Advance(clock.NextShotTick);
        Check(runtime.InfantryShotWindup(enemyId)?.StartTick == clock.NextShotTick,
            "The source cooldown must start another volley after repositioning.");
        Console.WriteLine("PASS: co-op post-volley obstacle reposition runtime");
        VerifyMovingShotCase(sources);
        VerifyPointChange(sources with { PointChangeSeconds = FreePointChangeSeconds });
        VerifyOccupiedPointRetry(sources with { PointChangeSeconds = BusyPointChangeSeconds });
        CoopObstacleReservationRuntimeTests.Run(sources);
    }

    internal static void VerifyFirstShotAfterReposition(CoopMatchRuntime runtime, ulong enemyId,
        CoopInfantryPointArrival arrival)
    {
        runtime.Advance(arrival.FirstShootEligibleTick - 1);
        Check(runtime.InfantryShotWindup(enemyId) == null,
            "Early position changes must preserve the original first-shot deadline.");
        runtime.Advance(arrival.FirstShootEligibleTick);
        CoopInfantryShotWindup? windup = runtime.InfantryShotWindup(enemyId);
        Check(windup?.StartTick == arrival.FirstShootEligibleTick &&
            runtime.ObstacleVolleyState(enemyId)?.HasPendingShot == true,
            "An enemy that repositions first must still prepare its first shot at the source deadline.");
        runtime.Advance(arrival.FirstShootEligibleTick);
        Check(runtime.InfantryShotWindup(enemyId) == windup,
            "Replaying the initial shot tick must not prepare a duplicate volley.");
        AdvanceUntilCompleted(runtime, enemyId);
        IReadOnlyList<CoopInfantryRoundIntent> rounds = runtime.InfantryRoundIntents(enemyId);
        CoopObstacleVolleySnapshot clock = runtime.ObstacleVolleyState(enemyId)!;
        Check(rounds.Count > 0 && clock.IsCrawling && !clock.HasPendingShot &&
            clock.NextShotTick > rounds[^1].Tick,
            "The early-reposition enemy must emit its first volley and retain the source cooldown.");
        Check(runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "Scheduling the previously missing first shot must not fabricate collision authority.");
        Console.WriteLine("PASS: first co-op obstacle volley after pre-shot repositioning");
    }

    private static void VerifyPointChange(Sources sources)
    {
        CoopMatchRuntime runtime = CreateRuntime(sources, () => 0.999f, () => 0.999f);
        runtime.Advance(8);
        ulong enemyId = runtime.Snapshot().Coop.EnemySpawns.First().EntityId;
        while (runtime.InfantryPointArrival(enemyId) == null && runtime.Snapshot().ServerTick < MaximumFixtureTick)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }

        CoopInfantryPointArrival arrival = runtime.InfantryPointArrival(enemyId)!;
        CoopAssignedEnemyDestination original = runtime.EnemyDestination(enemyId)!;
        ulong changeTick = arrival.FirstObstacleChangeTick!.Value;
        runtime.Advance(changeTick - 1);
        ulong previousProjectileId = runtime.InfantryRoundIntents(enemyId).LastOrDefault()?.ProjectileId ?? 0;
        Check(runtime.EnemyDestination(enemyId)!.PointComponentFileId == original.PointComponentFileId,
            "The enemy must not abandon its reserved obstacle before the source point-change deadline.");
        while (runtime.EnemyDestination(enemyId)!.PointComponentFileId == original.PointComponentFileId &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }

        Check(runtime.EnemyDestination(enemyId)!.PointComponentFileId != original.PointComponentFileId &&
            runtime.InfantryPointArrival(enemyId) == null && runtime.InfantryShotWindup(enemyId) == null &&
            runtime.NextObstaclePointChangeTick(enemyId) == null && runtime.ObstacleVolleyState(enemyId) == null,
            "A source-ready point change must reserve a different point and restart the walking lifecycle.");
        Console.WriteLine("PASS: co-op obstacle source deadline changes the reserved enemy point");
        CoopObstaclePointLifecycleTests.Run(runtime, enemyId, sources, previousProjectileId);
    }

    private static void VerifyOccupiedPointRetry(Sources sources)
    {
        CoopMatchRuntime runtime = CreateRuntime(sources, () => 0.999f, () => 0.999f,
            out CoopEnemyDestinationState destinations);
        runtime.Advance(8);
        ulong enemyId = runtime.Snapshot().Coop.EnemySpawns.First().EntityId;
        while (runtime.InfantryPointArrival(enemyId) == null && runtime.Snapshot().ServerTick < MaximumFixtureTick)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }

        CoopAssignedEnemyDestination original = runtime.EnemyDestination(enemyId)!;
        ulong deadline = runtime.NextObstaclePointChangeTick(enemyId)!.Value;
        // Reserve every other source-compatible point to exercise the actual destination ledger's no-free result.
        for (int index = 0; index < sources.Map.Points.Count; index++)
        {
            if (destinations.TryAssignInitial(ulong.MaxValue - (ulong)index, "Assaulter", false,
                original.Position) == null)
            {
                break;
            }
        }

        while (runtime.NextObstaclePointChangeTick(enemyId) == deadline &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }

        Check(runtime.Snapshot().ServerTick > deadline &&
            runtime.NextObstaclePointChangeTick(enemyId) == deadline + PointRetryTicks &&
            runtime.EnemyDestination(enemyId)!.PointComponentFileId == original.PointComponentFileId,
            "A delayed no-free attempt must add ten seconds to its original deadline and retain the old point.");
        Console.WriteLine("PASS: occupied co-op points preserve the source retry deadline after a pending volley");
    }

    private static void VerifyMovingShotCase(Sources sources)
    {
        Sources movingSources = sources with { SpawnIndex = SelectLongObstacleSpawn(sources) };
        Check(TryMovingShot(movingSources, 0.1875f, 0f),
            "The pinned source fractions must produce a shot during obstacle repositioning.");
    }

    private static void VerifyCrawlReturn(CoopMatchRuntime runtime, ulong enemyId, BattleCombatContent content)
    {
        ulong lastRound = runtime.InfantryRoundIntents(enemyId)[^1].Tick;
        float deadline = (float)(lastRound / (double)MatchManifest.TickRate) + RoundHideSeconds;
        ulong returnTick = lastRound + 1;
        while ((float)(returnTick / (double)MatchManifest.TickRate) <= deadline)
        {
            returnTick++;
        }

        runtime.Advance(returnTick - 1);
        Check(runtime.ObstacleCrawlReturnTick(enemyId) == null,
            "The live source float deadline must not expire early or at equality.");
        runtime.Advance(returnTick);
        Check(runtime.ObstacleCrawlReturnTick(enemyId) == returnTick,
            "The first strictly later host float time must consume the return event.");
        BattleCoopEnemySpawn enemy = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.EntityId == enemyId);
        CoopInfantryShotWindup windup = runtime.InfantryShotWindup(enemyId)!;
        IReadOnlyList<PlayerHitbox> expected = content.EnemyPoses.Place("stand_up_crawl",
            new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ), windup.FinalRootRotation, 0f,
            $"coop/{enemyId}/");
        IReadOnlyList<PlayerHitbox> actual = runtime.PlaceObstacleVolleyHitboxes(enemyId);
        Check(actual.Count == expected.Count && actual.Zip(expected).All(pair =>
            pair.First.SourcePath == pair.Second.SourcePath &&
            Vector3.Distance(pair.First.Center, pair.Second.Center) < CrawlCenterTolerance),
            "The consumed live return must select the source crawl clip at its start.");
        runtime.Advance(returnTick);
        Check(runtime.ObstacleCrawlReturnTick(enemyId) == returnTick &&
            runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "Repeated observation must preserve the event without opening collision authority.");
    }

    private static void VerifyRoundMuzzleClocks(CoopMatchRuntime runtime, ulong enemyId)
    {
        IReadOnlyList<CoopInfantryRoundIntent> rounds = runtime.InfantryRoundIntents(enemyId);
        Check(rounds.Count > 1, "The source fixture must exercise a loop reset between real emitted rounds.");
        for (int index = 1; index < rounds.Count; index++)
        {
            float expectedSeconds = (rounds[index].Tick - rounds[index - 1].Tick) / (float)MatchManifest.TickRate;
            Check(rounds[index].ObservedLocalMuzzle?.FireClipSeconds == expectedSeconds &&
                rounds[index].ObservedWorldLaunchOrigin.HasValue,
                "Each later round must use the previous OnShot reset rather than the initial queue origin.");
        }
    }

    private static void VerifyStationaryRootTurn(CoopMatchRuntime runtime, ulong enemyId)
    {
        CoopInfantryShotWindup windup = runtime.InfantryShotWindup(enemyId)!;
        var expected = new CoopShotRootTween(SourceTurnSeconds);
        expected.Begin(windup.StartRootRotation, windup.FinalRootRotation);
        expected.AdvanceFrame(1f / MatchManifest.TickRate);
        runtime.Advance(windup.StartTick + 1);
        BattleCoopEnemySpawn enemy = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.EntityId == enemyId);
        var rotation = new Quaternion(enemy.CurrentRotation.X, enemy.CurrentRotation.Y,
            enemy.CurrentRotation.Z, enemy.CurrentRotation.W);
        Check(1f - Math.Abs(Quaternion.Dot(rotation, expected.Rotation)) < RootRotationTolerance,
            "A stationary obstacle root must publish its source tween rather than retain spawn rotation.");
    }

    private static int SelectLongObstacleSpawn(Sources sources)
    {
        IReadOnlyList<CoopSpawnPoint> candidates = new CoopAiSpawnSelector(sources.Missions,
            sources.Spawns, sources.Manifest.MissionIndex!.Value).Candidates("Assaulter");
        string unitId = sources.Combat.UnitIdFor("Assaulter");
        CoopSoldierPointMask soldier = sources.Masks.Soldiers.Single(row => row.UnitId == unitId);
        int mask = CoopEnemyPointSelection.InitialMask(soldier, false);
        int selectedIndex = -1;
        float longestSegment = 0;
        for (int index = 0; index < candidates.Count; index++)
        {
            CoopEnemyPoint? point = CoopEnemyPointSelection.SelectOrdinary(sources.Map, mask,
                candidates[index].Position, new HashSet<int>());
            if (point?.SegmentStart == null || point.SegmentEnd == null)
            {
                continue;
            }
            float length = Vector3.Distance(point.SegmentStart.Value, point.SegmentEnd.Value);
            if (length > longestSegment)
            {
                longestSegment = length;
                selectedIndex = index;
            }
        }
        Check(selectedIndex >= 0, "The recovered map must contain an ordinary obstacle segment.");
        return selectedIndex;
    }

    private static bool TryMovingShot(Sources sources, float nextShotFraction, float positionFraction)
    {
        float shotFraction = 0f;
        bool hasReachedObstacle = false;
        CoopMatchRuntime runtime = CreateRuntime(sources, () => shotFraction,
            () => hasReachedObstacle ? positionFraction : 0.999f);
        runtime.Advance(8);
        ulong enemyId = runtime.Snapshot().Coop.EnemySpawns.First().EntityId;
        AdvanceUntilPrepared(runtime, enemyId, () => hasReachedObstacle = true);
        shotFraction = nextShotFraction;
        CoopObstacleVolleySnapshot prepared = runtime.ObstacleVolleyState(enemyId)!;
        AdvanceUntilCompleted(runtime, enemyId);
        CoopInfantryShotWindup completed = runtime.InfantryShotWindup(enemyId)!;
        CoopObstacleVolleySnapshot clock = runtime.ObstacleVolleyState(enemyId)!;
        ulong moveTick = Math.Max(prepared.NextPositionTick, completed.CompletedTick!.Value + 1);
        if (moveTick >= clock.NextShotTick)
        {
            return false;
        }
        runtime.Advance(clock.NextShotTick);
        if (!runtime.IsObstacleRepositioning(enemyId))
        {
            return false;
        }
        Check(runtime.InfantryShotWindup(enemyId)?.StartTick == clock.NextShotTick,
            "A source-ready obstacle shot must start during same-segment movement.");
        Check(runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "An unverified moving-shot posture must remain outside collision authority.");
        CoopObstacleTurnPlanExport.WriteIfRequested(sources, runtime, enemyId);
        VerifyMovementContinues(runtime, enemyId, clock.NextShotTick);
        AdvanceUntilCompleted(runtime, enemyId);
        IReadOnlyList<CoopInfantryRoundIntent> movingRounds = runtime.InfantryRoundIntents(enemyId);
        Check(!runtime.IsObstacleRepositioning(enemyId) && movingRounds.Count > 0 &&
            movingRounds.All(round => round.ObservedLocalMuzzle != null &&
                round.ObservedWorldLaunchOrigin == null) && runtime.PlaceObstacleVolleyHitboxes(enemyId).Count == 0,
            "A moving volley must still emit rounds without publishing a fixed, unverified world root.");
        Console.WriteLine($"PASS: co-op moving obstacle shot at tick {clock.NextShotTick}");
        return true;
    }

    private static void VerifyMovementContinues(CoopMatchRuntime runtime, ulong enemyId, ulong shotTick)
    {
        BattleCoopEnemySpawn before = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == enemyId);
        runtime.Advance(shotTick + 1);
        BattleCoopEnemySpawn after = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == enemyId);
        Check(Vector3.Distance(new Vector3(before.CurrentX, before.CurrentY, before.CurrentZ),
            new Vector3(after.CurrentX, after.CurrentY, after.CurrentZ)) > 0 &&
            runtime.InfantryShotWindup(enemyId)?.StartTick == shotTick,
            "Preparing the source moving shot must not stop same-segment crawl movement.");
    }

    internal static CoopMatchRuntime CreateRuntime(Sources sources,
        Func<float> shotFraction, Func<float> repositionFraction)
    {
        return CreateRuntime(sources, shotFraction, repositionFraction, out _);
    }

    private static CoopMatchRuntime CreateRuntime(Sources sources,
        Func<float> shotFraction, Func<float> repositionFraction, out CoopEnemyDestinationState destinations)
    {
        int positionDraws = 0;
        destinations = new CoopEnemyDestinationState(sources.Map, sources.Masks, sources.Combat,
            chooseObstacleFraction: () =>
            {
                positionDraws++;
                if (positionDraws == 1)
                {
                    return 0.5f;
                }
                return positionDraws % 2 == 0 ? 1f : 0f;
            }, chooseNextPoint: _ => 0);
        var runtime = new CoopMatchRuntime(sources.Manifest, sources.Missions, sources.Spawns,
            sources.Routes, sources.Combat, chooseBehaviour: _ => 0,
            choosePoint: count => Math.Min(sources.SpawnIndex, count - 1),
            enemyDestinations: destinations, infantryNavigation: sources.Navigation,
            playerWeaponContent: sources.Content,
            chooseInfantryShotFraction: shotFraction,
            chooseInfantryRepositionFraction: repositionFraction,
            chooseEnemyPointChangeSeconds: () => sources.PointChangeSeconds,
            chooseInfantryPlayer: _ => 0, chooseInfantryShieldRoll: () => 0.5f,
            chooseInfantryBatchSize: (minimum, maximum) => maximum > minimum ? maximum - 1 : minimum,
            chooseInfantryRealShotRoll: () => 0f);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            runtime.Admit(player.PlayerId);
            runtime.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash }
            });
        }
        return runtime;
    }

    private static void AdvanceUntilPrepared(CoopMatchRuntime runtime, ulong enemyId, Action onArrival)
    {
        while (runtime.InfantryShotWindup(enemyId) == null &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            if (runtime.InfantryPointArrival(enemyId) != null)
            {
                onArrival();
            }
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }
        Check(runtime.ObstacleVolleyState(enemyId)?.HasPendingShot == true,
            "The fixture must prepare an obstacle volley.");
    }

    private static void AdvanceUntilCompleted(CoopMatchRuntime runtime, ulong enemyId)
    {
        while (runtime.ObstacleVolleyState(enemyId)?.HasPendingShot == true &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }
        Check(runtime.InfantryShotWindup(enemyId)?.CompletedTick != null,
            "The fixture must complete its first source volley.");
    }

    private static void VerifyDeferredMove(CoopMatchRuntime runtime, ulong enemyId, ulong moveTick)
    {
        runtime.Advance(moveTick);
        Check(runtime.ObstacleRepositionStartedTick(enemyId) == moveTick &&
            runtime.InfantryShotWindup(enemyId) == null,
            "Overdue movement must resume and discard the completed firing pose.");
        BattleCoopEnemySpawn before = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == enemyId);
        ulong? nextPosition = runtime.NextObstacleRepositionTick(enemyId);
        runtime.Advance(moveTick);
        Check(runtime.NextObstacleRepositionTick(enemyId) == nextPosition,
            "Replaying the movement tick must preserve its new deadline.");
        runtime.Advance(moveTick + 1);
        BattleCoopEnemySpawn after = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == enemyId);
        Check(Vector3.Distance(new Vector3(before.CurrentX, before.CurrentY, before.CurrentZ),
            new Vector3(after.CurrentX, after.CurrentY, after.CurrentZ)) > 0 &&
            runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(enemyId),
            "The regenerated segment destination must move without promoting unverified collision poses.");
    }

    private static void Check(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}

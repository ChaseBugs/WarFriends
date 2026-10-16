using War.BattleServer;
using War.Protocol;

/// <summary>Preserves launch evidence for an emitted bullet after its shooter dies or starts another volley.</summary>
internal static class CoopDiagnosticRoundLifetimeTests
{
    private const ulong MaximumFixtureTick = 2000;
    private const float LatePositionFraction = 0.999f;
    private const int CompletedHistoryLimit = 64;
    private const int TotalOriginLimit = 128;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources, CoopPlayerShotCollisionWorld world)
    {
        VerifyShooterDeath(CreateFixture(sources, world), world);
        VerifyNextVolleyAndEviction(CreateFixture(sources, world));
    }

    private static ShotFixture CreateFixture(CoopObstacleVolleyRuntimeTests.Sources sources,
        CoopPlayerShotCollisionWorld world)
    {
        CoopMatchRuntime runtime = CoopObstacleVolleyRuntimeTests.CreateRuntime(sources,
            () => 0f, () => LatePositionFraction);
        runtime.AttachDiagnosticWorld(world);
        runtime.Advance(8);
        ulong enemyId = runtime.Snapshot().Coop.EnemySpawns.First().EntityId;
        while (runtime.InfantryRoundIntents(enemyId).Count == 0 &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
        }

        CoopInfantryRoundIntent round = runtime.InfantryRoundIntents(enemyId).First();
        Require(runtime.ActiveDiagnosticFlightIds().Contains(round.ProjectileId) &&
            runtime.DiagnosticRoundOrigin(round.ProjectileId) == round,
            "An actual emitted flight must freeze its source round before leaving the muzzle.");
        return new ShotFixture(runtime, enemyId, round);
    }

    private static void VerifyShooterDeath(ShotFixture fixture, CoopPlayerShotCollisionWorld world)
    {
        CoopMatchRuntime runtime = fixture.Runtime;
        ulong enemyId = fixture.EnemyId;
        CoopInfantryRoundIntent round = fixture.Round;
        BattleCoopEnemySpawn enemy = runtime.Snapshot().Coop.EnemySpawns.Single(row => row.EntityId == enemyId);
        ulong deathTick = runtime.Snapshot().ServerTick;
        Require(runtime.ApplyHostEnemyDamage(enemyId, enemy.Health, deathTick),
            "The fixture must kill the shooter with host-confirmed damage after emission.");
        Require(runtime.InfantryRoundIntents(enemyId).Count == 0 && runtime.EnemyDestination(enemyId) == null &&
            runtime.DiagnosticRoundOrigin(round.ProjectileId) == round &&
            runtime.ActiveDiagnosticFlightIds().Contains(round.ProjectileId),
            "Death must clear future firing and reservations without deleting the emitted bullet's launch evidence.");
        runtime.Advance(deathTick + 1);
        Require(runtime.DiagnosticRoundOrigin(round.ProjectileId) == round &&
            !runtime.TrackDiagnosticAssaulterFlight(enemyId, round.RoundIndex, world),
            "The emitted bullet must keep its target binding while a dead shooter cannot emit it again.");
        Console.WriteLine("PASS: co-op emitted projectile evidence survives shooter death and rejects re-emission");
    }

    private static void VerifyNextVolleyAndEviction(ShotFixture fixture)
    {
        CoopMatchRuntime runtime = fixture.Runtime;
        ulong originalStart = runtime.InfantryShotWindup(fixture.EnemyId)!.StartTick;
        bool hasNextVolley = false;
        while (runtime.DiagnosticRoundOrigin(fixture.Round.ProjectileId) != null &&
            runtime.Snapshot().ServerTick < MaximumFixtureTick && !runtime.Terminal)
        {
            runtime.Advance(runtime.Snapshot().ServerTick + 1);
            hasNextVolley |= runtime.InfantryShotWindup(fixture.EnemyId)?.StartTick > originalStart;
            CoopInfantryRoundIntent? retained = runtime.DiagnosticRoundOrigin(fixture.Round.ProjectileId);
            Require(retained == null || retained == fixture.Round,
                "A subsequent volley must never replace an existing projectile's frozen launch evidence.");
            Require(runtime.DiagnosticRoundOriginCount <= TotalOriginLimit &&
                runtime.DiagnosticRoundOriginCount == runtime.ActiveDiagnosticFlightIds().Count +
                    runtime.DiagnosticFlightResults().Count,
                "Launch evidence must be conserved across active flights and bounded completed history.");
        }

        Require(hasNextVolley && runtime.DiagnosticFlightResults().Count == CompletedHistoryLimit &&
            runtime.DiagnosticFlightResults().All(result => result.ProjectileId != fixture.Round.ProjectileId) &&
            runtime.DiagnosticRoundOrigin(fixture.Round.ProjectileId) == null,
            "An old completed launch must retire with history eviction, after surviving the next volley.");
        Console.WriteLine("PASS: co-op launch evidence survives later volleys and retires with bounded history");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed record ShotFixture(CoopMatchRuntime Runtime, ulong EnemyId, CoopInfantryRoundIntent Round);
}

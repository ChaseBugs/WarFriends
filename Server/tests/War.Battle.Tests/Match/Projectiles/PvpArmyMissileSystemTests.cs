using System.Numerics;
using System.Reflection;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpArmyMissileSystemTests
{
    private const string Owner = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const ulong Entity = 7;
    private const float FlightSpeed = 30f;
    private static readonly ArmyCardRocketRuntime Missile = new(1, 10, FlightSpeed, 0.5f);
    private static readonly ArmyPlayerDamagePolicy PlayerPolicy = new(0.5f, 1, 1);
    private static readonly CardRocketLaunchAuthority Launch = new(Owner, Missile, PlayerPolicy);

    internal static int Run()
    {
        CheckPairedProjection();
        CheckCompletionOrder();
        CheckCaptureBoundary();
        CheckClockAndCollisionErrors();
        CheckFakeAndMortar();
        CheckImpactLifetimeAndIsolation();
        CheckCapturedTerminalClear();
        CheckCompiledOwnership();
        return 8;
    }

    private static void CheckPairedProjection()
    {
        var system = new PvpArmyMissileSystem();
        system.AddActive(9, Flight(9), Launch);
        ArmyMortarRuntime mortar = new(2, 20, FlightSpeed, 1, 0.5f);
        CardRocketLaunchAuthority mortarLaunch = Launch with { Mortar = mortar };
        system.AddActive(2, MortarFlight(2, mortar), mortarLaunch);
        Throws<ArgumentException>(() => system.AddActive(9, Flight(9), Launch with { OwnerPlayerId = "other" }));

        BattleProjectileState[] rows = system.CreateSnapshot().ToArray();
        Require(system.Count == 2 && rows.Select(row => row.ProjectileId).SequenceEqual(new ulong[] { 2, 9 }),
            "Missile snapshots must remain ID-sorted with one count per paired entry.");
        Require(rows[0].Kind == "army-mortar" && rows[0].ArmyUnitId == "ID_UNIT-MORTAR" &&
            rows[0].VelocityY == 0 && rows[1].Kind == "card-rocket" && rows[1].ArmyUnitId == "" &&
            rows.All(row => row.OwnerPlayerId == Owner && row.WeaponSourceId == ""),
            "Rocket/Mortar snapshot identity and overhead stationary velocity changed.");
        rows[1].X = 100;
        Require(system.CreateSnapshot().Last().X == 0 && system.FindLaunch(9) == Launch &&
            system.FindLaunch(2) == mortarLaunch && system.FindLaunch(99) == null,
            "Projection edits or a duplicate insertion must not alter stored launch authority.");
    }

    private static void CheckCompletionOrder()
    {
        var system = new PvpArmyMissileSystem();
        int laterQueries = 0;
        system.AddActive(9, Flight(9, trace: (origin, direction, distance) =>
        {
            laterQueries++;
            return Hit(origin, direction, distance);
        }), Launch);
        system.AddActive(2, Flight(2), Launch);
        AdvanceFrame(system, 1);
        PvpArmyMissileSystem.FlightFrame frame = system.BeginFlightFrame(2);

        Require(frame.TryAdvanceNext(out PvpArmyMissileStep first) && first.ProjectileId == 2 &&
            first.Impact?.ProjectileId == 2 && first.Launch == Launch,
            "The smallest captured missile ID must complete before world effects observe later entries.");
        Require(system.Count == 1 && system.FindLaunch(2) == null && laterQueries == 0 &&
            system.CreateImpactSnapshot().Single().ProjectileId == 2,
            "Completion must remove flight/authority and publish diagnostics before the world callback.");
        Require(frame.TryAdvanceNext(out PvpArmyMissileStep second) && second.ProjectileId == 9 &&
            laterQueries == 1 && system.Count == 0 && !frame.TryAdvanceNext(out _),
            "A world callback must run between independently captured flight advancements.");
    }

    private static void CheckCaptureBoundary()
    {
        var system = new PvpArmyMissileSystem();
        system.AddActive(1, Flight(1), Launch);
        AdvanceFrame(system, 1);
        PvpArmyMissileSystem.FlightFrame frame = system.BeginFlightFrame(2);
        system.AddActive(2, Flight(2, 1), Launch);

        Require(frame.TryAdvanceNext(out _) && !frame.TryAdvanceNext(out _) && system.Count == 1 &&
            system.CreateSnapshot().Single().Z == 0,
            "A captured frame must exclude a missile inserted by a later launch phase.");
        PvpArmyMissileSystem.FlightFrame next = system.BeginFlightFrame(2);
        Require(!system.HasImpacts && next.TryAdvanceNext(out PvpArmyMissileStep step) && step.Impact == null &&
            system.CreateSnapshot().Single().Z == 1,
            "The excluded flight must remain unadvanced until its own next captured source frame.");
    }

    private static void CheckClockAndCollisionErrors()
    {
        var skipped = new PvpArmyMissileSystem();
        skipped.AddActive(1, Flight(1), Launch);
        PvpArmyMissileSystem.FlightFrame badClock = skipped.BeginFlightFrame(2);
        Throws<InvalidOperationException>(() => badClock.TryAdvanceNext(out _));
        Require(skipped.Count == 1 && skipped.CreateSnapshot().Single().Z == 0 && !skipped.HasImpacts,
            "Skipped ticks must propagate the original clock error before changing the stored flight.");
        AdvanceFrame(skipped, 1);
        PvpArmyMissileSystem.FlightFrame duplicate = skipped.BeginFlightFrame(1);
        Throws<InvalidOperationException>(() => duplicate.TryAdvanceNext(out _));

        var invalidCollision = new PvpArmyMissileSystem();
        invalidCollision.AddActive(2, Flight(2, trace: (_, _, _) =>
            throw new InvalidDataException("fixture collision authority")), Launch);
        AdvanceFrame(invalidCollision, 1);
        PvpArmyMissileSystem.FlightFrame collision = invalidCollision.BeginFlightFrame(2);
        Throws<InvalidDataException>(() => collision.TryAdvanceNext(out _));
        Require(invalidCollision.Count == 1 && invalidCollision.FindLaunch(2) == Launch &&
            !invalidCollision.HasImpacts, "Collision authority errors must propagate before paired removal.");
    }

    private static void CheckFakeAndMortar()
    {
        var fakeSystem = new PvpArmyMissileSystem();
        var fake = new CardRocketMissileFlight(1, Entity, Missile, Vector3.Zero, Vector3.UnitZ, 0, true, Hit);
        fakeSystem.AddActive(1, fake, Launch);
        Require(fakeSystem.CreateSnapshot().Single().Kind == "card-rocket-fake", "Fake identity was lost.");
        AdvanceFrame(fakeSystem, 1);
        PvpArmyMissileSystem.FlightFrame final = fakeSystem.BeginFlightFrame(2);
        Require(final.TryAdvanceNext(out PvpArmyMissileStep step) && step.Impact is { IsFake: true } &&
            step.Launch == Launch && fakeSystem.Count == 0,
            "A cosmetic missile still completes and reports its launch identity without applying world damage here.");

        var mortarSystem = new PvpArmyMissileSystem();
        ArmyMortarRuntime mortar = new(2, 20, FlightSpeed, 1, 0.5f);
        mortarSystem.AddActive(2, MortarFlight(2, mortar), Launch with { Mortar = mortar });
        Vector3 origin = Vector3.UnitY * 5;
        AdvanceFrame(mortarSystem, 1);
        BattleProjectileState row = mortarSystem.CreateSnapshot().Single();
        Require(new Vector3(row.X, row.Y, row.Z) == origin && row.VelocityY == 0 && mortarSystem.Count == 1,
            "A negative-progress overhead Mortar must retain its source stop period before falling.");
    }

    private static void CheckImpactLifetimeAndIsolation()
    {
        var first = new PvpArmyMissileSystem();
        var second = new PvpArmyMissileSystem();
        first.AddActive(1, Flight(1), Launch);
        second.AddActive(1, Flight(1), Launch);
        AdvanceFrame(first, 1);
        AdvanceFrame(first, 2);
        CardRocketMissileImpact[] snapshot = first.CreateImpactSnapshot().ToArray();
        snapshot[0] = snapshot[0] with { ProjectileId = 99 };
        first.ClearFlights();
        Require(first.HasImpacts && first.CreateImpactSnapshot().Single().ProjectileId == 1 &&
            second.Count == 1 && !second.HasImpacts,
            "Terminal clear preserves detached last-frame impacts without changing another match.");
        first.BeginFlightFrame(3);
        Require(!first.HasImpacts && first.Count == 0,
            "The next running frame must clear diagnostics even when no missile remains active.");
    }

    private static void CheckCapturedTerminalClear()
    {
        var system = new PvpArmyMissileSystem();
        system.AddActive(1, Flight(1), Launch);
        system.AddActive(2, Flight(2), Launch);
        AdvanceFrame(system, 1);
        PvpArmyMissileSystem.FlightFrame frame = system.BeginFlightFrame(2);
        Require(frame.TryAdvanceNext(out _), "The first captured impact was absent.");
        system.ClearFlights();

        // The prior engine continues its captured loop after terminal cleanup. Preserve its missing-authority guard.
        Throws<InvalidDataException>(() => frame.TryAdvanceNext(out _));
        Require(system.Count == 0 && system.CreateImpactSnapshot().Select(row => row.ProjectileId)
            .SequenceEqual(new ulong[] { 1, 2 }),
            "A cleared captured impact must record diagnostics, then reject missing authority before world damage.");
    }

    private static void CheckCompiledOwnership()
    {
        FieldInfo[] fields = typeof(MatchEngine).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo owner = fields.Single(field => field.Name == "_armyMissiles");
        Require(owner.IsInitOnly && owner.FieldType == typeof(PvpArmyMissileSystem) &&
            !fields.Any(field => field.Name is "rocketFlights" or "rocketLaunches" or "rocketImpacts"),
            "The engine must retain one readonly missile owner without parallel writable dictionaries.");
        Require(typeof(PvpArmyMissileStep).IsValueType && typeof(PvpArmyMissileSystem.FlightFrame).IsValueType,
            "Captured observations and frame cursors must not allocate per-flight wrapper objects.");
        MethodInfo[] methods = typeof(PvpArmyMissileSystem).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        Require(methods.All(method => method.ReturnType != typeof(CardRocketMissileFlight)),
            "Queries must not expose a stored mutable missile flight.");
    }

    private static CardRocketMissileFlight Flight(ulong id, ulong launchTick = 0,
        Func<Vector3, Vector3, float, ShotCollision?>? trace = null)
    {
        return new(id, Entity, Missile, Vector3.Zero, Vector3.UnitZ, launchTick, false, trace ?? Hit);
    }

    private static CardRocketMissileFlight MortarFlight(ulong id, ArmyMortarRuntime weapon)
    {
        var launch = new MortarMissileLaunch
        {
            ProjectileId = id, SoldierEntityKey = Entity, Weapon = weapon,
            TargetPosition = Vector3.Zero, LaunchTick = 0, IsFake = false
        };
        return CardRocketMissileFlight.CreateMortar(launch, Hit);
    }

    private static ShotCollision Hit(Vector3 origin, Vector3 direction, float distance)
    {
        const float HitDistance = 0.1f;
        return new(HitDistance, origin + Vector3.Normalize(direction) * HitDistance, "fixture-wall", null, 1, true);
    }

    private static void AdvanceFrame(PvpArmyMissileSystem system, ulong tick)
    {
        PvpArmyMissileSystem.FlightFrame frame = system.BeginFlightFrame(tick);
        while (frame.TryAdvanceNext(out _))
        {
        }
    }

    private static void Throws<T>(Action action) where T : Exception
    {
        try
        {
            action();
        }
        catch (T)
        {
            return;
        }
        throw new InvalidOperationException($"Expected {typeof(T).Name}.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

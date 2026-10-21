using System.Numerics;
using System.Reflection;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpArmyBulletSystemTests
{
    private const string Owner = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string SourceCard = "fixture-source-card";
    private const ulong EntityKey = 7;
    private const float Speed = 30;

    internal static int Run()
    {
        CheckProjectionAndAuthority();
        CheckCompletionOrder();
        CheckCaptureBoundary();
        CheckDuplicateAndInvalidClock();
        CheckExceptionClassification();
        CheckCosmeticLifetime();
        CheckClearAndIsolation();
        CheckCompiledOwnership();
        return 8;
    }

    private static void CheckProjectionAndAuthority()
    {
        var system = new PvpArmyBulletSystem();
        PvpArmyBulletPayload poison = Payload() with { UnitId = "ID_UNIT-COMMANDO", PoisonRatio = 0.1f };
        system.AddActive(9, RealFlight(9), poison);
        system.AddActive(2, CosmeticFlight(2), Payload() with { IsCosmetic = true });

        BattleProjectileState[] rows = system.CreateSnapshot().ToArray();
        Require(system.Count == 2 && rows.Select(row => row.ProjectileId).SequenceEqual(new ulong[] { 2, 9 }),
            "Army snapshots must be ID-sorted independently of captured flight order.");
        Require(rows[0].Kind == "army-fake-bullet" && rows[1].Kind == "army-bullet" && rows[1].ArmyPoison &&
            rows.All(row => row.OwnerPlayerId == Owner && row.ArmySourceCardId == SourceCard &&
                row.WeaponSourceId == ""), "Army wire metadata changed during ownership extraction.");
        Require(system.FindPayload(9) == poison && system.FindSpeed(9) == Speed &&
            system.FindPayload(99) == null && system.FindSpeed(99) == null,
            "Detached metadata queries must describe exactly the active flight set.");
        rows[1].X = 100;
        PvpArmyBulletSystem.FlightFrame frame = system.BeginFlightFrame(1);
        frame.TryAdvanceNext(out _);
        Require(system.CreateSnapshot().Single(row => row.ProjectileId == 9).X == 0 && rows[1].X == 100,
            "Snapshot mutation or later flight motion changed another observation.");
    }

    private static void CheckCompletionOrder()
    {
        var system = new PvpArmyBulletSystem();
        int laterTraceCalls = 0;
        system.AddActive(9, RealFlight(9, Hit), Payload());
        system.AddActive(2, RealFlight(2, (origin, direction, distance) =>
        {
            laterTraceCalls++;
            return Hit(origin, direction, distance);
        }), Payload());
        PvpArmyBulletSystem.FlightFrame frame = system.BeginFlightFrame(1);

        Require(frame.TryAdvanceNext(out PvpArmyBulletStep first) && first.Impact?.ProjectileId == 9 &&
            first.Payload.EntityKey == EntityKey && !first.HasInvalidAuthority,
            "The first inserted flight must produce its launch-bound observation first.");
        Require(system.Count == 1 && system.FindPayload(9) == null && system.FindSpeed(9) == null &&
            laterTraceCalls == 0, "Completion must remove flight and authority before world impact application.");
        // A terminal impact can abandon this cursor here without advancing the later flight.
        Require(frame.TryAdvanceNext(out PvpArmyBulletStep second) && second.Impact?.ProjectileId == 2 &&
            laterTraceCalls == 1 && system.Count == 0 && !frame.TryAdvanceNext(out _),
            "Captured flights must advance exactly once, one world observation at a time.");
    }

    private static void CheckCaptureBoundary()
    {
        var system = new PvpArmyBulletSystem();
        system.AddActive(1, RealFlight(1, Hit), Payload());
        PvpArmyBulletSystem.FlightFrame captured = system.BeginFlightFrame(1);
        system.AddActive(2, RealFlight(2, Hit), Payload());

        Require(captured.TryAdvanceNext(out _) && !captured.TryAdvanceNext(out _) && system.Count == 1 &&
            system.FindPayload(2) != null, "A captured army frame included a flight inserted afterward.");
        PvpArmyBulletSystem.FlightFrame next = system.BeginFlightFrame(1);
        Require(next.TryAdvanceNext(out PvpArmyBulletStep step) && step.Impact?.ProjectileId == 2,
            "An excluded flight must remain available to the next independently captured frame.");
    }

    private static void CheckDuplicateAndInvalidClock()
    {
        var system = new PvpArmyBulletSystem();
        system.AddActive(1, RealFlight(1), Payload());
        PvpArmyBulletSystem.FlightFrame launch = system.BeginFlightFrame(0);
        Require(launch.TryAdvanceNext(out PvpArmyBulletStep initial) && initial.Impact == null &&
            !initial.HasInvalidAuthority, "Army launch-tick observation must keep the flight unadvanced.");
        PvpArmyBulletSystem.FlightFrame first = system.BeginFlightFrame(1);
        first.TryAdvanceNext(out _);
        BattleProjectileState position = system.CreateSnapshot().Single();
        PvpArmyBulletSystem.FlightFrame duplicate = system.BeginFlightFrame(1);
        duplicate.TryAdvanceNext(out _);
        Require(system.CreateSnapshot().Single().Equals(position), "A duplicate tick advanced an army flight.");

        system.AddActive(2, RealFlight(2), Payload());
        PvpArmyBulletSystem.FlightFrame invalid = system.BeginFlightFrame(3);
        Require(invalid.TryAdvanceNext(out PvpArmyBulletStep rejected) && rejected.HasInvalidAuthority &&
            rejected.Impact == null && !invalid.TryAdvanceNext(out _) && system.Count == 2,
            "A non-contiguous army tick must stop the captured frame without consuming later flights.");
    }

    private static void CheckExceptionClassification()
    {
        var system = new PvpArmyBulletSystem();
        system.AddActive(1, RealFlight(1, (_, _, _) => throw new InvalidOperationException("fixture")), Payload());
        PvpArmyBulletSystem.FlightFrame frame = system.BeginFlightFrame(1);
        try
        {
            frame.TryAdvanceNext(out _);
        }
        catch (InvalidOperationException)
        {
            Require(system.Count == 1, "An unclassified exception consumed the army flight.");
            return;
        }
        throw new InvalidOperationException("The owner changed the original army exception classification.");
    }

    private static void CheckCosmeticLifetime()
    {
        var system = new PvpArmyBulletSystem();
        system.AddActive(1, CosmeticFlight(1), Payload() with { IsCosmetic = true });
        PvpArmyBulletSystem.FlightFrame first = system.BeginFlightFrame(1);
        Require(first.TryAdvanceNext(out PvpArmyBulletStep step) && step.Impact == null &&
            step.Payload.IsCosmetic && system.Count == 1,
            "The source doubled cosmetic tween ended early or returned a real impact.");
        PvpArmyBulletSystem.FlightFrame second = system.BeginFlightFrame(2);
        Require(second.TryAdvanceNext(out PvpArmyBulletStep finished) && finished.Impact == null &&
            system.Count == 0 && system.FindPayload(1) == null,
            "Finished cosmetic trails must release their shared capacity and metadata together.");
    }

    private static void CheckClearAndIsolation()
    {
        var first = new PvpArmyBulletSystem();
        var second = new PvpArmyBulletSystem();
        PvpArmyBulletPayload launch = Payload();
        first.AddActive(1, RealFlight(1), launch);
        second.AddActive(1, RealFlight(1), launch with { Damage = 2 });
        PvpArmyBulletPayload? previous = first.FindPayload(1);
        first.Clear();

        Require(first.Count == 0 && !first.CreateSnapshot().Any() && first.FindPayload(1) == null &&
            first.FindSpeed(1) == null && previous == launch && second.Count == 1 &&
            second.FindPayload(1)?.Damage == 2,
            "Clearing one match changed another match or invalidated a detached launch observation.");
        PvpArmyBulletSystem.FlightFrame empty = first.BeginFlightFrame(1);
        Require(!empty.TryAdvanceNext(out _), "Cleared army flight state remained executable.");
    }

    private static void CheckCompiledOwnership()
    {
        const BindingFlags Fields = BindingFlags.Instance | BindingFlags.NonPublic;
        Require(typeof(MatchEngine).GetField("armyProjectiles", Fields) == null &&
            typeof(MatchEngine).GetField("armyProjectileAuthority", Fields) == null &&
            typeof(MatchEngine).GetField("_armyBullets", Fields)?.IsInitOnly == true,
            "The engine retained duplicate writable army flight or authority collections.");
        Require(typeof(PvpArmyBulletStep).IsValueType && typeof(PvpArmyBulletSystem.FlightFrame).IsValueType &&
            typeof(PvpArmyBulletSystem).GetNestedType("FlightState", BindingFlags.NonPublic)?.IsValueType == true &&
            typeof(PvpArmyBulletStep).GetProperties().All(property =>
                property.PropertyType != typeof(ArmyProjectileFlight)),
            "Army frame observations must not expose a mutable flight or allocate a step object.");
    }

    private static PvpArmyBulletPayload Payload()
    {
        return new PvpArmyBulletPayload
        {
            EntityKey = EntityKey,
            OwnerPlayerId = Owner,
            OwnerFraction = 1,
            Damage = 10,
            PoisonRatio = 0,
            UnitId = "ID_UNIT-ASSAULT",
            SourceCardId = SourceCard,
            IsCosmetic = false,
            PlayerPolicy = new ArmyPlayerDamagePolicy(0.1f, 1, 0.5f)
        };
    }

    private static ArmyProjectileFlight RealFlight(ulong id,
        Func<Vector3, Vector3, float, ShotCollision?>? trace = null)
    {
        return new(id, EntityKey, Vector3.Zero, Vector3.UnitZ * 10, Speed, 0, trace ?? ((_, _, _) => null));
    }

    private static ArmyProjectileFlight CosmeticFlight(ulong id)
    {
        return new(id, EntityKey, Vector3.Zero, Vector3.UnitZ, Speed, 0,
            (_, _, _) => throw new InvalidOperationException("Cosmetic flight queried collisions."),
            cosmeticTrail: true);
    }

    private static ShotCollision Hit(Vector3 origin, Vector3 direction, float distance)
    {
        return new(0, origin, "fixture/static", null, 0, true);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

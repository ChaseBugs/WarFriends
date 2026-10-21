using System.Numerics;
using System.Reflection;
using War.BattleServer;
using War.Protocol;
using static War.Battle.Tests.Match.Projectiles.PvpBazookaFixture;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpPlayerBazookaSystemTests
{
    internal static int Run()
    {
        CheckDueTimingAndReservationTransfer();
        CheckCapturedFlightOrderAndRemoval();
        CheckLaunchTickSkipAndInvalidFrameStop();
        CheckDetachedSnapshot();
        CheckClearRetainsCurveSequenceAndIsolation();
        CheckCompiledOwnership();
        return 6;
    }

    private static PvpBazookaLaunch Primary(ulong tick)
    {
        return new(First, Vector3.UnitZ, tick, new(M202, 0, PvpBazookaShotKind.PrimaryReal, true));
    }

    private static PvpBazookaPayload Payload()
    {
        BazookaCatalog catalog = Content.Bazookas!;
        return new(catalog.Stage(Rpg, 0), catalog.Binding(Rpg), Rpg, false);
    }

    private static BazookaMissileFlight Flight(ulong id, ulong tick)
    {
        BazookaBinding binding = Content.Bazookas!.Binding(Rpg) with { Speed = 1000, StopSeconds = 0 };
        return new(id, First, binding, Vector3.Zero, new Vector3(0, 0, 10), tick, false,
            0.5f, 0.5f, 1, (_, _, _) => null);
    }

    private static void CheckDueTimingAndReservationTransfer()
    {
        var system = new PvpPlayerBazookaSystem();
        system.AddActive(1, Flight(1, 100), Payload());
        system.ScheduleRemainingShots(Primary(100), Content.Bazookas!.Binding(M202));
        Require(system.Count == 4 && system.ScheduledCount == 3 && system.HasPendingLaunchFor(First) &&
            !system.HasPendingLaunchFor(Second), "M202 did not reserve its full owner-bound volley.");
        PvpPlayerBazookaSystem.DueLaunchFrame early = system.BeginDueLaunches(102);
        Require(!early.TryTakeNext(out _) && system.Count == 4, "A secondary missile launched before its deadline.");
        PvpPlayerBazookaSystem.DueLaunchFrame due = system.BeginDueLaunches(103);
        Require(due.TryTakeNext(out PvpBazookaLaunch fake) && fake.IsFake && fake.IsSecondary &&
            fake.Shot.IsHalfDamage && system.ScheduledCount == 2 && system.Count == 3,
            "A due reservation was not removed before the trusted launch callback.");
        system.AddActive(2, Flight(2, 103), Payload());
        Require(system.Count == 4 && !due.TryTakeNext(out _), "Reservation-to-flight transfer lost capacity.");
        PvpPlayerBazookaSystem.DueLaunchFrame later = system.BeginDueLaunches(109);
        Require(later.TryTakeNext(out PvpBazookaLaunch real) && !real.IsFake && real.IsSecondary &&
            real.LaunchTick == 106 && later.TryTakeNext(out PvpBazookaLaunch last) && last.IsFake &&
            last.LaunchTick == 109 && !later.TryTakeNext(out _) && !system.HasPendingLaunchFor(First),
            "The source secondary fake/real/fake order or inclusive due boundary changed.");
    }

    private static void CheckCapturedFlightOrderAndRemoval()
    {
        var system = new PvpPlayerBazookaSystem();
        system.AddActive(5, Flight(5, 0), Payload());
        system.AddActive(2, Flight(2, 0), Payload());
        PvpPlayerBazookaSystem.ActiveFrame frame = system.BeginActiveFrame(1);
        Require(frame.TryAdvanceNext(out PvpBazookaStep first) && first.Impact?.ProjectileId == 5 &&
            system.Count == 1, "A completed missile remained stored at impact dispatch or was ID-sorted.");
        system.AddActive(9, Flight(9, 1), Payload());
        Require(frame.TryAdvanceNext(out PvpBazookaStep second) && second.Impact?.ProjectileId == 2 &&
            !frame.TryAdvanceNext(out _) && system.Count == 1 && system.CreateSnapshot().Single().Z == 0,
            "A captured missile frame advanced a later insertion or lost its original entries.");
    }

    private static void CheckLaunchTickSkipAndInvalidFrameStop()
    {
        var system = new PvpPlayerBazookaSystem();
        system.AddActive(1, Flight(1, 100), Payload());
        PvpPlayerBazookaSystem.ActiveFrame launchFrame = system.BeginActiveFrame(100);
        Require(!launchFrame.TryAdvanceNext(out _) && system.Count == 1,
            "A newly launched missile advanced in its own launch tick.");
        system.AddActive(2, Flight(2, 100), Payload());
        PvpPlayerBazookaSystem.ActiveFrame skipped = system.BeginActiveFrame(102);
        Require(skipped.TryAdvanceNext(out PvpBazookaStep invalid) && invalid.HasInvalidAuthority &&
            !skipped.TryAdvanceNext(out _) && system.Count == 2 && system.CreateSnapshot().Last().Z == 0,
            "Invalid bazooka clock authority did not stop the frame before later missiles.");
    }

    private static void CheckDetachedSnapshot()
    {
        var system = new PvpPlayerBazookaSystem();
        system.AddActive(9, Flight(9, 0), Payload());
        system.AddActive(2, Flight(2, 0), Payload());
        BattleProjectileState[] snapshot = system.CreateSnapshot().ToArray();
        Require(snapshot.Select(row => row.ProjectileId).SequenceEqual(new ulong[] { 2, 9 }) &&
            snapshot.All(row => row.Kind == "bazooka" && row.WeaponSourceId == Rpg),
            "Missile projection lost ID ordering or launch-bound presentation identity.");
        snapshot[0].Z = 999;
        Require(system.CreateSnapshot().First().Z == 0, "A wire snapshot mutated live missile motion.");
    }

    private static void CheckClearRetainsCurveSequenceAndIsolation()
    {
        var first = new PvpPlayerBazookaSystem();
        var second = new PvpPlayerBazookaSystem();
        first.AddActive(1, Flight(1, 0), Payload());
        first.ScheduleRemainingShots(Primary(0), Content.Bazookas!.Binding(M202));
        second.AddActive(1, Flight(1, 0), Payload());
        Require(first.NextCurveSign() == 1, "The first curve no longer uses the original positive sign.");
        first.Clear();
        Require(first.Count == 0 && !first.HasActiveOrScheduled && !first.HasPendingLaunchFor(First) &&
            !first.CreateSnapshot().Any() && first.NextCurveSign() == -1 && second.Count == 1,
            "Clear leaked reservations, reset curve history or changed another match.");
    }

    private static void CheckCompiledOwnership()
    {
        const BindingFlags Fields = BindingFlags.Instance | BindingFlags.NonPublic;
        foreach (string name in new[] { "bazookaProjectiles", "scheduledBazookas", "bazookaCurveCounter" })
        {
            Require(typeof(MatchEngine).GetField(name, Fields) == null, "The engine retained bazooka state: " + name);
        }
        Require(typeof(PvpBazookaStep).IsValueType && typeof(PvpBazookaPayload).IsValueType &&
            typeof(PvpPlayerBazookaSystem.ActiveFrame).IsValueType &&
            typeof(PvpPlayerBazookaSystem.DueLaunchFrame).IsValueType,
            "A missile step introduced a reference cursor or per-step payload object.");
        Require(typeof(PvpBazookaPayload).GetProperties().All(property =>
            property.PropertyType != typeof(BazookaMissileFlight)), "Payload observations exposed live flight state.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

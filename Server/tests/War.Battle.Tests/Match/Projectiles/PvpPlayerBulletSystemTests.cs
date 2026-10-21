using System.Numerics;
using System.Reflection;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpPlayerBulletSystemTests
{
    private const string Owner = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Target = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string ShotgunSource = "Google2u.Shotgun_Fixture";

    internal static int Run()
    {
        CheckFrameOrderAndCompletionBeforeImpact();
        CheckInvalidStepStopsFrame();
        CheckClockExceptionsAreNotReclassified();
        CheckCosmeticExpiry();
        CheckDetachedProjectionOrder();
        CheckClearAndMatchIsolation();
        CheckCompiledOwnershipAndValueSteps();
        return 7;
    }

    private static void CheckFrameOrderAndCompletionBeforeImpact()
    {
        var system = new PvpPlayerBulletSystem();
        system.AddReal(2, Hit(2));
        system.AddReal(1, Hit(1));
        PvpPlayerBulletSystem.RealFrame frame = system.BeginRealFrame(1);
        Require(frame.TryAdvanceNext(out PvpBulletStep first) && first.ProjectileId == 2 && first.Impact != null &&
            system.Count == 1, "Insertion order changed or a completed shot was still stored at impact dispatch.");

        system.AddReal(3, Miss(3));
        Require(frame.TryAdvanceNext(out PvpBulletStep second) && second.ProjectileId == 1 && second.Impact != null &&
            system.Count == 1, "A captured frame lost its second original flight.");
        Require(!frame.TryAdvanceNext(out _) && system.CreateRealShotgunSnapshot().Single().Z == 0,
            "A flight inserted after frame capture advanced in that same frame.");
    }

    private static void CheckInvalidStepStopsFrame()
    {
        var system = new PvpPlayerBulletSystem();
        int calls = 0;
        ShotCollision? InvalidAfterLaunch(Vector3 origin, Vector3 direction, float range)
        {
            calls++;
            return calls == 1 ? null : new(float.NaN, origin, "fixture/invalid", Target, 1);
        }
        var flight = new BulletFlight(7, Owner, new(60, 0.2f, false), Vector3.Zero, Vector3.UnitZ, 0,
            InvalidAfterLaunch);
        system.AddReal(7, new(flight, new(1, CombatDamageType.Shot), ShotgunSource));
        system.AddReal(5, Hit(5));
        PvpPlayerBulletSystem.RealFrame frame = system.BeginRealFrame(1);
        Require(frame.TryAdvanceNext(out PvpBulletStep step) && step.HasInvalidAuthority && step.Impact == null,
            "Malformed collision geometry was accepted as a valid flight step.");
        Require(!frame.TryAdvanceNext(out _) && system.Count == 2 &&
            system.CreateRealShotgunSnapshot().Single(item => item.ProjectileId == 5).Z == 0,
            "An invalid step removed authority or advanced a later captured flight.");
    }

    private static void CheckClockExceptionsAreNotReclassified()
    {
        var system = new PvpPlayerBulletSystem();
        system.AddReal(1, Miss(1));
        PvpPlayerBulletSystem.RealFrame skipped = system.BeginRealFrame(2);
        ExpectException<InvalidOperationException>(() => skipped.TryAdvanceNext(out _));
        PvpPlayerBulletSystem.RealFrame outOfRange = system.BeginRealFrame(10_000_001);
        ExpectException<ArgumentOutOfRangeException>(() => outOfRange.TryAdvanceNext(out _));
        Require(system.Count == 1, "A rejected frame clock removed its flight.");
    }

    private static void CheckCosmeticExpiry()
    {
        var system = new PvpPlayerBulletSystem();
        system.AddCosmetic(1, Cosmetic(1));
        Require(system.AdvanceCosmetic(1) && system.Count == 1 &&
            system.CreateCosmeticSnapshot().Single().Kind == "shotgun-fake-bullet",
            "A presentation-only flight expired before its source duration.");
        Require(system.AdvanceCosmetic(2) && system.Count == 0 && !system.HasActiveFlights,
            "A finished presentation-only flight remained active.");
        system.AddCosmetic(2, Cosmetic(2));
        Require(!system.AdvanceCosmetic(10_000_001) && system.Count == 1,
            "An invalid cosmetic clock was accepted or discarded damaged authority.");
    }

    private static void CheckDetachedProjectionOrder()
    {
        var system = new PvpPlayerBulletSystem();
        system.AddReal(9, Miss(9));
        system.AddReal(4, Miss(4));
        system.AddReal(2, Miss(2) with { WeaponSourceId = "Google2u.LMG_Fixture" });
        system.AddCosmetic(3, Cosmetic(3));
        system.AddCosmetic(1, Cosmetic(1));
        BattleProjectileState[] real = system.CreateRealShotgunSnapshot().ToArray();
        BattleProjectileState[] cosmetic = system.CreateCosmeticSnapshot().ToArray();
        Require(real.Select(item => item.ProjectileId).SequenceEqual(new ulong[] { 4, 9 }) &&
            cosmetic.Select(item => item.ProjectileId).SequenceEqual(new ulong[] { 1, 3 }) && system.Count == 5,
            "Projection changed within-family sorting, family selection or total flight accounting.");
        real[0].Z = 999;
        cosmetic[0].WeaponSourceId = "mutated-observation";
        Require(system.CreateRealShotgunSnapshot().First().Z == 0 &&
            system.CreateCosmeticSnapshot().First().WeaponSourceId == ShotgunSource,
            "A returned protobuf observation mutated stored flight authority.");
    }

    private static void CheckClearAndMatchIsolation()
    {
        var first = new PvpPlayerBulletSystem();
        var second = new PvpPlayerBulletSystem();
        first.AddReal(1, Miss(1));
        first.AddCosmetic(2, Cosmetic(2));
        second.AddReal(1, Miss(1));
        first.Clear();
        first.Clear();
        Require(!first.HasActiveFlights && first.Count == 0 && !first.CreateRealShotgunSnapshot().Any() &&
            !first.CreateCosmeticSnapshot().Any() && second.Count == 1,
            "Terminal cleanup leaked flights or cleared another match's state.");
    }

    private static void CheckCompiledOwnershipAndValueSteps()
    {
        const BindingFlags Fields = BindingFlags.Instance | BindingFlags.NonPublic;
        Require(typeof(MatchEngine).GetField("projectiles", Fields) == null &&
            typeof(MatchEngine).GetField("shotgunFakeProjectiles", Fields) == null,
            "The engine retained independently mutable player-flight dictionaries.");
        foreach (string name in new[] { "_real", "_cosmetic" })
        {
            FieldInfo field = typeof(PvpPlayerBulletSystem).GetField(name, Fields)!;
            Require(field.IsPrivate && field.IsInitOnly, "Player flight storage escaped its owner: " + name);
        }
        Require(typeof(PvpBulletStep).IsValueType && typeof(PvpPlayerBulletSystem.RealFrame).IsValueType,
            "Flight stepping introduced a reference object per observation or boxed enumerator.");
        Require(!typeof(PvpBulletStep).GetProperties().Any(property =>
            property.PropertyType == typeof(BulletFlight) || property.PropertyType == typeof(PreparedProjectile)),
            "A flight step exposed its mutable prepared flight.");
    }

    private static PreparedProjectile Hit(ulong id)
    {
        ShotCollision? Trace(Vector3 origin, Vector3 direction, float range)
        {
            float distance = (1 - origin.Z) / direction.Z;
            return new(distance, origin + direction * distance, "fixture/player", Target, 1);
        }
        var flight = new BulletFlight(id, Owner, new(60, 0, true), Vector3.Zero, Vector3.UnitZ, 0, Trace);
        return new(flight, new(1, CombatDamageType.Shot), ShotgunSource);
    }

    private static PreparedProjectile Miss(ulong id)
    {
        var flight = new BulletFlight(id, Owner, new(60, 0, true), Vector3.Zero, Vector3.UnitZ, 0,
            (_, _, _) => null);
        return new(flight, new(1, CombatDamageType.Shot), ShotgunSource);
    }

    private static ShotgunFakePelletFlight Cosmetic(ulong id)
    {
        return new(id, Owner, ShotgunSource, Vector3.Zero, Vector3.UnitZ, 30, 0);
    }

    private static void ExpectException<TException>(Action action) where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException)
        {
            return;
        }
        throw new InvalidOperationException("The expected flight-clock exception was not propagated.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

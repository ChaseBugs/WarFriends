using System.Numerics;
using System.Reflection;
using War.BattleServer;
using War.Protocol;
using static War.Battle.Tests.Match.Projectiles.PvpGrenadeFixture;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpGrenadeStateTests
{
    internal static int Run()
    {
        CheckOrdinaryCompletionOrder();
        CheckOrdinaryClockAndSnapshot();
        CheckOrdinaryClearIsolation();
        CheckBonusTransferAndLateSharedSetup();
        CheckBonusPreflightFailure();
        CheckUnpublishedBonusFailure();
        CheckBonusFrameCaptureAndPublication();
        CheckCompiledOwnership();
        return 8;
    }

    private static GrenadeFlight PlayerFlight(ulong id)
    {
        return new(id, First, Content.Grenades!.Binding(Frag), Vector3.Zero, Vector3.UnitZ, 0,
            (origin, _, _) => new(0, origin, "fixture/ground", null, 0, true));
    }

    private static GrenadeFlight BonusFlight(ulong id)
    {
        return new(id, First, 45, 0, Vector3.Zero, Vector3.Zero, 0,
            (origin, _, _) => new(0, origin, "fixture/ground", null, 0, true), allowStationary: true);
    }

    private static PvpGrenadePayload Payload(string source = Frag)
    {
        return new(Content.Grenades!.Stage(source, 0), Content.Grenades.Binding(source), source);
    }

    private static void CheckOrdinaryCompletionOrder()
    {
        var system = new PvpPlayerGrenadeSystem();
        GrenadeFlight later = PlayerFlight(2);
        system.AddActive(9, PlayerFlight(9), Payload());
        system.AddActive(2, later, Payload());
        for (ulong tick = 1; tick <= 30; tick++)
        {
            PvpPlayerGrenadeSystem.FlightFrame frame = system.BeginFlightFrame(tick);
            while (frame.TryAdvanceNext(out PvpGrenadeStep step))
            {
                if (step.Impact == null)
                {
                    continue;
                }
                Require(step.Impact.ProjectileId == 9 && system.Count == 1 && later.CurrentTick == tick - 1,
                    "Ordinary collision changed insertion order or advanced later flights before dispatch.");
                system.Clear();
                return;
            }
        }
        throw new InvalidOperationException("The ordinary collision fixture did not hit its ground surface.");
    }

    private static void CheckOrdinaryClockAndSnapshot()
    {
        var system = new PvpPlayerGrenadeSystem();
        system.AddActive(9, PlayerFlight(9), Payload());
        system.AddActive(2, PlayerFlight(2), Payload(Molotov));
        PvpPlayerGrenadeSystem.FlightFrame sameTick = system.BeginFlightFrame(0);
        Require(!sameTick.TryAdvanceNext(out _), "An ordinary grenade advanced on its launch tick.");
        BattleProjectileState[] rows = system.CreateSnapshot().ToArray();
        Require(rows[0].ProjectileId == 2 && rows[0].Kind == "grenade-molotov" &&
            rows[1].ProjectileId == 9 && rows[1].Kind == "grenade" && rows.All(row => row.WeaponSourceId == ""),
            "Ordinary grenade projection changed sorting, effect identity or its existing source-field shape.");
        rows[0].Z = 999;
        Require(system.CreateSnapshot().First().Z == 0, "A wire observation mutated live grenade position.");
        PvpPlayerGrenadeSystem.FlightFrame skipped = system.BeginFlightFrame(2);
        Require(skipped.TryAdvanceNext(out PvpGrenadeStep invalid) && invalid.HasInvalidAuthority &&
            !skipped.TryAdvanceNext(out _) && system.Count == 2,
            "An invalid ordinary clock did not stop later captured flights.");
    }

    private static void CheckOrdinaryClearIsolation()
    {
        var first = new PvpPlayerGrenadeSystem();
        var second = new PvpPlayerGrenadeSystem();
        first.AddActive(1, PlayerFlight(1), Payload());
        second.AddActive(1, PlayerFlight(1), Payload());
        first.Clear();
        Require(first.Count == 0 && !first.CreateSnapshot().Any() && second.Count == 1,
            "Ordinary cleanup retained a flight or changed another match.");
    }

    private static PvpBonusGrenadeFlightSystem PendingBonus()
    {
        var system = new PvpBonusGrenadeFlightSystem();
        system.AddActive(BonusFlight(9));
        system.AddActive(BonusFlight(2));
        PvpBonusGrenadeFlightSystem.FlightFrame first = system.BeginFlightFrame(1);
        Require(!first.TryAdvanceNext(out _), "Stationary fallback collided before its descent collider was enabled.");
        first.PublishImpacts();
        PvpBonusGrenadeFlightSystem.FlightFrame second = system.BeginFlightFrame(2);
        var ids = new List<ulong>();
        while (second.TryAdvanceNext(out GrenadeFlightImpact impact))
        {
            ids.Add(impact.ProjectileId);
            Require(system.Count == 2 && system.Impacts.Count == 0,
                "Collision transfer freed its pending reservation or prematurely published frame observations.");
        }
        Require(ids.SequenceEqual(new ulong[] { 9, 2 }) && !system.CreateSnapshot().Any(),
            "Bonus collision changed insertion order or retained an already-collided flight.");
        second.PublishImpacts();
        return system;
    }

    private static void CheckBonusTransferAndLateSharedSetup()
    {
        PvpBonusGrenadeFlightSystem system = PendingBonus();
        IReadOnlyList<GrenadeFlightImpact> prior = system.Impacts;
        var clock = new PvpBonusGrenadeBurstClock(Content.PvpBonuses);
        clock.AdvanceFrame(1, 0);
        var policy = new PvpBonusGrenadeBurstPolicy(Content.PvpBonuses);
        var fallback = new PvpBonusGrenadeBurstPlan("fixture-box", First,
            policy.Plan(1, 0, Vector3.Zero, [], () => 0));
        clock.Schedule(fallback, 1);
        clock.AdvanceFrame(2, 1);
        IReadOnlyList<PvpBonusGrenadeExplosionQuote> quotes =
            system.PreparePendingExplosions(3, clock, Content.PvpBonuses);
        Require(quotes.Count == 2 && quotes.All(quote => quote.CollisionTick == 2 && quote.ExplosionTick == 3 &&
            quote.ExplosionDamage == 50 && quote.DirectDamage == 5) && system.Count == 0 && system.Impacts.Count == 0,
            "The next-frame explosion used launch-time setup or retained consumed collision authority.");
        Require(prior.Count == 2, "A later frame mutated a previously published collision view.");
        ExpectException<NotSupportedException>(() => ((IList<PvpBonusGrenadeExplosionQuote>)quotes).Clear());
        system.ResetIdleObservations();
        Require(system.Impacts.Count == 0 && system.Explosions.Count == 0,
            "An idle frame retained stale collision/explosion observations.");
    }

    private static void CheckBonusPreflightFailure()
    {
        PvpBonusGrenadeFlightSystem system = PendingBonus();
        IReadOnlyList<PvpBonusGrenadeExplosionQuote> previous = system.Explosions;
        var clock = new PvpBonusGrenadeBurstClock(Content.PvpBonuses);
        ExpectException<InvalidDataException>(() => system.PreparePendingExplosions(4, clock, Content.PvpBonuses));
        Require(system.Count == 2 && system.Impacts.Count == 0 && ReferenceEquals(previous, system.Explosions),
            "Failed quote preflight consumed pending authority or published a partial replacement.");
        Require(system.PreparePendingExplosions(3, clock, Content.PvpBonuses).Count == 2,
            "A rejected preparation lost the original pending collision set.");
    }

    private static void CheckUnpublishedBonusFailure()
    {
        var system = new PvpBonusGrenadeFlightSystem();
        system.AddActive(BonusFlight(1));
        var invalid = new GrenadeFlight(2, First, 45, 0, Vector3.Zero, Vector3.Zero, 0,
            (origin, _, _) => new(float.NaN, origin, "fixture/invalid", null, 0, true), allowStationary: true);
        system.AddActive(invalid);
        PvpBonusGrenadeFlightSystem.FlightFrame initial = system.BeginFlightFrame(1);
        Require(!initial.TryAdvanceNext(out _), "The failure fixture collided before descent.");
        initial.PublishImpacts();
        PvpBonusGrenadeFlightSystem.FlightFrame failing = system.BeginFlightFrame(2);
        Require(failing.TryAdvanceNext(out _) && system.Count == 2, "The first collision did not transfer authority.");
        ExpectException<InvalidDataException>(() => failing.TryAdvanceNext(out _));
        ExpectException<InvalidOperationException>(() => failing.PublishImpacts());
        Require(system.Impacts.Count == 0 && system.CreateSnapshot().Count() == 1 && system.Count == 2,
            "A partial flight failure published observations or discarded pending/active authority.");
    }

    private static void CheckBonusFrameCaptureAndPublication()
    {
        var system = new PvpBonusGrenadeFlightSystem();
        PvpBonusGrenadeFlightSystem.FlightFrame captured = system.BeginFlightFrame(1);
        system.AddActive(BonusFlight(1));
        Require(!captured.TryAdvanceNext(out _) && system.CreateSnapshot().Single().Y == 0,
            "A newly inserted flight entered an already captured bonus frame.");
        captured.PublishImpacts();
        ExpectException<InvalidOperationException>(() => captured.TryAdvanceNext(out _));
        PvpBonusGrenadeFlightSystem.FlightFrame skipped = system.BeginFlightFrame(2);
        ExpectException<InvalidOperationException>(() => skipped.TryAdvanceNext(out _));
        Require(system.Count == 1, "A rejected bonus clock removed its active flight.");
    }

    private static void CheckCompiledOwnership()
    {
        const BindingFlags Fields = BindingFlags.Instance | BindingFlags.NonPublic;
        foreach (string name in new[] { "grenadeProjectiles", "pvpGrenadeFlights", "pvpGrenadePendingExplosions",
            "pvpGrenadeImpacts", "pvpGrenadeExplosions" })
        {
            Require(typeof(MatchEngine).GetField(name, Fields) == null, "The engine retained grenade storage: " + name);
        }
        Require(typeof(PvpGrenadeStep).IsValueType && typeof(PvpGrenadePayload).IsValueType &&
            typeof(PvpPlayerGrenadeSystem.FlightFrame).IsValueType &&
            typeof(PvpBonusGrenadeFlightSystem.FlightFrame).IsValueType,
            "Grenade stepping introduced a reference cursor or per-step payload object.");
        Require(typeof(PvpGrenadePayload).GetProperties().All(property =>
            property.PropertyType != typeof(GrenadeFlight)),
            "Ordinary payload metadata exposed the mutable stored flight.");
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
        throw new InvalidOperationException("The expected grenade boundary exception was not propagated.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

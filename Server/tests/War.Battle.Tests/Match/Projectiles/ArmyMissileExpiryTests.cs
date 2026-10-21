using System.Numerics;
using War.BattleServer;

namespace War.Battle.Tests.Match.Projectiles;

internal static class ArmyMissileExpiryTests
{
    private const ulong ProjectileId = 7;
    private const ulong EntityKey = 9;
    private const int MaximumFrames = 20_000;
    private const float FastSpeed = 30f;
    private const float MortarHeight = 5f;
    private const float MortarStopSeconds = 1f;
    private const string Owner = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    internal static int Run()
    {
        Require(MatchManifest.TickRate == MissileExpiryReference.TickRate,
            "The source expiry fixtures require the reviewed thirty-Hz sampling interval.");
        MissileExpiryReference.VerifySource();
        (string Name, Action Check)[] groups =
        [
            ("real expiry", () => CheckExpiry(Rocket(1, FastSpeed))),
            ("fake expiry", () => CheckExpiry(Rocket(1, FastSpeed) with { IsFake = true })),
            ("Mortar expiry", () => CheckExpiry(Mortar())),
            ("strict boundary and arming", CheckBoundaryAndArming),
            ("expired callback exclusion", CheckExpiredCallbackExclusion),
            ("clock and collision guards", CheckAuthorityGuards),
            ("differential matrix", CheckMatrix),
            ("paired owner expiry", CheckOwnerExpiry)
        ];
        var failures = new List<string>();
        foreach ((string name, Action check) in groups)
        {
            try
            {
                check();
            }
            catch (Exception error) when (error is InvalidOperationException or InvalidDataException)
            {
                failures.Add(name + ": " + error.Message);
            }
        }
        Require(failures.Count == 0, string.Join("; ", failures));
        return groups.Length;
    }

    private static void CheckExpiry(Scenario scenario)
    {
        var source = new MissileExpiryReference(scenario.Start, scenario.Target, scenario.Speed, scenario.StopSeconds);
        int queries = 0;
        int expectedQueries = 0;
        CardRocketMissileFlight flight = CreateFlight(scenario, (origin, direction, distance) =>
        {
            queries++;
            return source.HasExpired ? Hit(origin, direction, distance) : null;
        });
        for (ulong tick = 1; tick <= MaximumFrames; tick++)
        {
            MissileExpiryReference.Frame expected = source.Advance();
            expectedQueries += expected.ShouldTrace ? 1 : 0;
            CardRocketMissileImpact? actual = flight.Advance(tick);
            Require(flight.Position == expected.Position && queries == expectedQueries,
                scenario.Name + " selected a collision or queried after the source had already expired.");
            Require(flight.Finished == expected.IsExpired, scenario.Name + " changed the source lifetime.");
            if (expected.IsExpired)
            {
                Require(actual is { Collision: null } && actual.Tick == tick && actual.Position == expected.Position &&
                    actual.ProjectileId == ProjectileId && actual.SoldierEntityKey == EntityKey &&
                    actual.IsFake == scenario.IsFake, scenario.Name + " changed expiry impact authority.");
                return;
            }
            Require(actual == null, scenario.Name + " completed before its source deadline.");
        }
        throw new InvalidOperationException(scenario.Name + " never expired within the bounded fixture.");
    }

    private static void CheckBoundaryAndArming()
    {
        int queries = 0;
        CardRocketMissileFlight flight = CreateFlight(Rocket(1, FastSpeed), (origin, direction, distance) =>
        {
            queries++;
            return queries == 2 ? Hit(origin, direction, distance) : null;
        });
        Require(flight.Advance(1) == null && queries == 0,
            "The first movement arms collision only after leaving the source half-unit sphere.");
        Require(flight.Advance(2) == null && queries == 1, "A pre-expiry null ray must preserve the flight.");
        Require(flight.Advance(3) is { Collision: not null } && queries == 2,
            "Exact progress three is still live and must permit a valid source collision.");

        int earlyQueries = 0;
        CardRocketMissileFlight early = CreateFlight(Rocket(1, FastSpeed), (origin, direction, distance) =>
        {
            earlyQueries++;
            return Hit(origin, direction, distance);
        });
        early.Advance(1);
        Require(early.Advance(2) is { Collision: not null } && earlyQueries == 1,
            "Expiry priority must not suppress an earlier valid collision.");
    }

    private static void CheckExpiredCallbackExclusion()
    {
        var source = new MissileExpiryReference(Vector3.Zero, Vector3.UnitZ, FastSpeed, 0);
        CardRocketMissileFlight flight = CreateFlight(Rocket(1, FastSpeed), (_, _, _) =>
        {
            if (source.HasExpired)
            {
                throw new InvalidDataException("An expired missile must never query collision authority.");
            }
            return null;
        });
        for (ulong tick = 1; tick <= 4; tick++)
        {
            MissileExpiryReference.Frame expected = source.Advance();
            CardRocketMissileImpact? impact = flight.Advance(tick);
            Require(expected.IsExpired == (impact != null), "Expiry changed while excluding a forbidden callback.");
        }
    }

    private static void CheckAuthorityGuards()
    {
        CardRocketMissileFlight skipped = CreateFlight(Rocket(1, FastSpeed), (_, _, _) => null);
        Throws<InvalidOperationException>(() => skipped.Advance(2));
        Require(skipped.Position == Vector3.Zero, "A skipped tick changed flight state before validation.");
        skipped.Advance(1);
        Throws<InvalidOperationException>(() => skipped.Advance(1));

        CardRocketMissileFlight damaged = CreateFlight(Rocket(1, FastSpeed), (origin, _, _) =>
            new ShotCollision(float.NaN, origin, "invalid-fixture", null, 1));
        damaged.Advance(1);
        Throws<InvalidDataException>(() => damaged.Advance(2));
        Throws<InvalidDataException>(() => CreateFlight(Rocket(float.NaN, FastSpeed), (_, _, _) => null));
        Throws<InvalidDataException>(() => CreateFlight(Rocket(1, float.PositiveInfinity), (_, _, _) => null));
        Throws<InvalidDataException>(() => CreateFlight(Rocket(1, CardRocketMissileFlight.MaximumSpeed + 1),
            (_, _, _) => null));
    }

    private static void CheckMatrix()
    {
        float[] distances = [0.25f, 1, 2, 10, 50, 100];
        float[] speeds = [0.5f, 3, FastSpeed, CardRocketMissileFlight.MaximumSpeed];
        foreach (float distance in distances)
        {
            foreach (float speed in speeds)
            {
                CheckExpiry(Rocket(distance, speed));
                CheckExpiry(Rocket(distance, speed) with { IsFake = true });
            }
        }
        CheckExpiry(Mortar());
        CheckExpiry(Mortar() with { IsFake = true });
    }

    private static void CheckOwnerExpiry()
    {
        var owner = new PvpArmyMissileSystem();
        var missile = new ArmyCardRocketRuntime(1, 10, FastSpeed, 0.5f);
        var launch = new CardRocketLaunchAuthority(Owner, missile, new(0.5f, 1, 1));
        ulong currentTick = 0;
        ShotCollision? Trace(Vector3 origin, Vector3 direction, float distance)
        {
            return currentTick == 4 ? Hit(origin, direction, distance) : null;
        }
        owner.AddActive(ProjectileId, CreateFlight(Rocket(1, FastSpeed), Trace), launch);
        for (ulong tick = 1; tick <= 4; tick++)
        {
            currentTick = tick;
            PvpArmyMissileSystem.FlightFrame frame = owner.BeginFlightFrame(tick);
            Require(frame.TryAdvanceNext(out _), "A paired missile disappeared before its source observation.");
        }
        CardRocketMissileImpact impact = owner.CreateImpactSnapshot().Single();
        Require(owner.Count == 0 && owner.FindLaunch(ProjectileId) == null && impact.Collision == null &&
            impact.Position == Vector3.UnitZ * 4 && impact.Tick == 4,
            "Paired completion must expose source expiry without collision authority to world effects.");
    }

    private static Scenario Rocket(float distance, float speed)
    {
        return new($"Rocket {distance}/{speed}", Vector3.Zero, Vector3.UnitZ * distance, speed);
    }

    private static Scenario Mortar()
    {
        return new("Mortar overhead", Vector3.UnitY * MortarHeight, Vector3.Zero, FastSpeed)
        {
            StopSeconds = MortarStopSeconds
        };
    }

    private static CardRocketMissileFlight CreateFlight(Scenario scenario,
        Func<Vector3, Vector3, float, ShotCollision?> trace)
    {
        if (scenario.StopSeconds > 0)
        {
            var launch = new MortarMissileLaunch
            {
                ProjectileId = ProjectileId, SoldierEntityKey = EntityKey,
                Weapon = new(1, 10, scenario.Speed, scenario.StopSeconds, 0.5f),
                TargetPosition = scenario.Target, LaunchTick = 0, IsFake = scenario.IsFake
            };
            return CardRocketMissileFlight.CreateMortar(launch, trace);
        }
        var missile = new ArmyCardRocketRuntime(1, 10, scenario.Speed, 0.5f);
        return new(ProjectileId, EntityKey, missile, scenario.Start, scenario.Target, 0, scenario.IsFake, trace);
    }

    private static ShotCollision Hit(Vector3 origin, Vector3 direction, float distance)
    {
        float hitDistance = Math.Min(distance * 0.5f, 0.1f);
        return new(hitDistance, origin + Vector3.Normalize(direction) * hitDistance, "synthetic-expiry-ray", null, 1);
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

    private sealed record Scenario(string Name, Vector3 Start, Vector3 Target, float Speed)
    {
        internal float StopSeconds { get; init; }

        internal bool IsFake { get; init; }
    }
}

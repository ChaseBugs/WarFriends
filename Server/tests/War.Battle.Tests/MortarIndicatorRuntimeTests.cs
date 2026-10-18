using System.Numerics;

using War.BattleServer;

/// <summary>Checks frozen host warning identity, independent flight lifetime and reusable weapon history.</summary>
internal static class MortarIndicatorRuntimeTests
{
    private const ulong FirstLaunchTick = 100;
    private const ulong RepeatedLaunchTick = 180;
    private const ulong FirstHiddenTick = 165;
    private const ulong RepeatedHiddenTick = 247;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run()
    {
        return CheckReuse() + CheckEarlyImpact() + CheckInvalidLaunches();
    }

    private static int CheckReuse()
    {
        var runtime = new MortarIndicatorRuntime(2, OwnerId, 1, FirstLaunchTick);
        MortarMissileLaunch first = Launch(1, FirstLaunchTick);
        runtime.BeginLaunch(first);
        MortarIndicatorObservation? frozen = null;
        int checks = 0;
        for (ulong tick = FirstLaunchTick; tick <= RepeatedHiddenTick; tick++)
        {
            if (tick == RepeatedLaunchTick)
            {
                runtime.BeginLaunch(Launch(2, tick) with { IsFake = true, TargetPosition = new(4f, 0f, 5f) });
            }
            runtime.Advance(tick);
            MortarIndicatorObservation? row = runtime.Observe();
            bool expected = tick < FirstHiddenTick || tick >= RepeatedLaunchTick && tick < RepeatedHiddenTick;
            checks += Require((row != null) == expected,
                "Host warning lost the native first/reused hidden boundary.");
            if (tick == FirstLaunchTick)
            {
                frozen = row;
            }
            if (row != null)
            {
                bool repeated = tick >= RepeatedLaunchTick;
                checks += Require(row.EntityKey == 2 && row.OwnerPlayerId == OwnerId && row.OwnerFraction == 1 &&
                    row.ObservedTick == tick && row.ProjectileId == (repeated ? 2u : 1u) &&
                    row.LaunchTick == (repeated ? RepeatedLaunchTick : FirstLaunchTick) && row.IsFake == repeated &&
                    row.Position == (repeated ? new Vector3(4f, 0.04f, 5f) : new Vector3(2f, 0.04f, 3f)),
                    "Host warning changed frozen target/owner metadata or lost the final fake target.");
            }
        }
        checks += Require(frozen != null && frozen.ObservedTick == FirstLaunchTick && frozen.ProjectileId == 1 &&
            frozen.Position == new Vector3(2f, 0.04f, 3f),
            "A retained observation aliased the next launch's mutable clock state.");
        return checks;
    }

    private static int CheckEarlyImpact()
    {
        MortarMissileLaunch launch = Launch(1, FirstLaunchTick);
        var runtime = new MortarIndicatorRuntime(2, OwnerId, 1, FirstLaunchTick);
        runtime.BeginLaunch(launch);
        runtime.Advance(FirstLaunchTick);
        var flight = CardRocketMissileFlight.CreateMortar(launch, (from, direction, _) =>
            new ShotCollision(0.01f, from + direction * 0.01f, "source-overhead-obstacle", null, 1f, Static: true));
        for (ulong tick = FirstLaunchTick + 1; tick < FirstHiddenTick; tick++)
        {
            runtime.Advance(tick);
            if (flight.Advance(tick) != null)
            {
                return Require(flight.Finished && runtime.Observe()?.ProjectileId == launch.ProjectileId,
                    "An early physical impact removed its still-running warning.");
            }
        }
        throw new InvalidOperationException("The source delayed flight did not meet the early-impact fixture.");
    }

    private static int CheckInvalidLaunches()
    {
        MortarMissileLaunch valid = Launch(1, FirstLaunchTick);
        MortarMissileLaunch[] invalid =
        {
            valid with { ProjectileId = 0 }, valid with { SoldierEntityKey = 3 },
            valid with { LaunchTick = FirstLaunchTick + 1 },
            valid with { TargetPosition = new(float.NaN, 0f, 0f) },
            valid with { Weapon = valid.Weapon with { StopTime = float.PositiveInfinity } }
        };
        int checks = 0;
        foreach (MortarMissileLaunch launch in invalid)
        {
            var runtime = new MortarIndicatorRuntime(2, OwnerId, 1, FirstLaunchTick);
            bool rejected = false;
            try
            {
                runtime.BeginLaunch(launch);
            }
            catch (InvalidDataException)
            {
                rejected = true;
            }
            checks += Require(rejected && runtime.Observe() == null,
                "A malformed launch changed warning authority.");
            runtime.BeginLaunch(valid);
            runtime.Advance(FirstLaunchTick);
            checks += Require(runtime.Observe()?.ProjectileId == valid.ProjectileId,
                "Rejected warning authority consumed the valid first launch.");
        }
        return checks;
    }

    private static MortarMissileLaunch Launch(ulong projectileId, ulong tick)
    {
        return new MortarMissileLaunch
        {
            ProjectileId = projectileId, SoldierEntityKey = 2, LaunchTick = tick,
            TargetPosition = new Vector3(2f, 0f, 3f), IsFake = false,
            Weapon = new ArmyMortarRuntime(10f, 100f, 20f, 2f, 0.5f)
        };
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}

using System.Numerics;
using War.BattleServer;

/// <summary>Checks overhead delay and collision suppression before the recovered missile starts descending.</summary>
internal static class MortarMissileFlightTests
{
    internal static int Run()
    {
        const ulong LaunchTick = 100;
        const float Speed = 20f;
        const float StopSeconds = 2f;
        var target = new Vector3(2f, -1f, 3f);
        var launch = new MortarMissileLaunch
        {
            ProjectileId = 1,
            SoldierEntityKey = 2,
            Weapon = new ArmyMortarRuntime(10f, 100f, Speed, StopSeconds, 0.5f),
            TargetPosition = target,
            LaunchTick = LaunchTick,
            IsFake = true
        };
        int traceCalls = 0;
        var flight = CardRocketMissileFlight.CreateMortar(launch, (_, _, _) =>
        {
            traceCalls++;
            return null;
        });
        Vector3 origin = target + Vector3.UnitY * 5f;
        Require(flight.Position == origin && flight.Velocity == Vector3.Zero && flight.IsFake,
            "Mortar must begin stationary above its captured target and retain its fake-shot flag.");

        // Stay clear of the binary32 transition frame: a delayed missile cannot trace while stationary.
        for (ulong elapsed = 1; elapsed <= 59; elapsed++)
        {
            Require(flight.Advance(LaunchTick + elapsed) == null && flight.Position == origin,
                "Mortar moved or impacted before its recovered stop interval.");
        }
        Require(traceCalls == 0, "Mortar traced collisions during the overhead delay.");

        for (ulong elapsed = 60; elapsed <= 65; elapsed++)
        {
            flight.Advance(LaunchTick + elapsed);
        }
        Require(flight.Position.Y < origin.Y && flight.Velocity == -Vector3.UnitY * Speed && traceCalls > 0,
            "Mortar did not descend and arm collision tracing after the source half-unit threshold.");
        return 62;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

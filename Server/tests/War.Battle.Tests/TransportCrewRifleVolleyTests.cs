using System.Numerics;
using War.BattleServer;

/// <summary>Checks source mask, fake-shot geometry, float cadence and an uncertain producer failure.</summary>
internal static class TransportCrewRifleVolleyTests
{
    internal static int Run()
    {
        var prediction = new AssaulterAimPrediction(new AssaulterAimInputs(Vector3.Zero,
            Vector3.UnitZ, Vector3.Zero, 5), Vector3.UnitZ);
        var weapon = new AssaulterWeaponFireClock(0.35f);
        var volley = new TransportCrewRifleVolley(new CoopInfantryShotBatch(2, 1), prediction, weapon, 10);
        int distanceDraws = 0;
        int sideDraws = 0;
        var draws = new TransportCrewRifleVolley.FakeDraws(
            () => { distanceDraws++; return 1; }, () => { sideDraws++; return 0; });
        var rounds = new List<TransportCrewRifleVolley.Round>();
        Require(volley.TryFire(new(11, 1, Vector3.Zero), draws, rounds.Add), "First round did not execute.");
        Require(rounds[0].Real && rounds[0].TargetPosition == Vector3.UnitZ && distanceDraws == 0 && sideDraws == 0,
            "Real round consumed fake draws or changed aim.");
        Require(!volley.TryFire(new(12, 1.35f, Vector3.Zero), draws, rounds.Add),
            "Cadence equality executed another round.");
        Require(volley.TryFire(new(13, MathF.BitIncrement(1.35f), Vector3.Zero), draws, rounds.Add),
            "First float after cadence failed.");
        Require(!rounds[1].Real && rounds[1].TargetPosition == new Vector3(-1, 0.5f, 1) &&
            distanceDraws == 1 && sideDraws == 1 && volley.IsComplete,
            "Fake round lost cross-product orientation, vertical offset or draw count.");
        Reject(() => volley.TryFire(new(14, 2, Vector3.Zero), draws, rounds.Add));

        var uncertain = new TransportCrewRifleVolley(new CoopInfantryShotBatch(1, 1), prediction, weapon, 20);
        int attempts = 0;
        Reject(() => uncertain.TryFire(new(21, 2, Vector3.Zero), draws, _ =>
        {
            attempts++;
            throw new InvalidOperationException("Synthetic producer failure after possible emission.");
        }));
        Reject(() => uncertain.TryFire(new(22, 3, Vector3.Zero), draws, _ => attempts++));
        Require(attempts == 1 && weapon.CanFire(3), "Failed emission was retried or changed source cadence.");
        return 9;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new Exception("Retired or uncertain volley execution was accepted.");
    }
}

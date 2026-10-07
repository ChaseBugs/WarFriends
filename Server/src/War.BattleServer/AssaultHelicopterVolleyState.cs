using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Keeps the two source BatchedWeapon preparations in their scheduled order.
/// A prepared mask does not create a projectile or authorize damage.
/// </summary>
internal sealed class AssaultHelicopterVolleyState
{
    internal sealed record PreparedVolley(
        AssaultHelicopterVolleyPlanner.Volley Plan,
        AssaultHelicopterShotTargetPolicy.Choice TargetChoice,
        IReadOnlyList<bool> FirstGunRealShots,
        IReadOnlyList<bool>? SecondGunRealShots,
        ulong SelectionTick,
        float SecondGunDueTime);
    internal sealed record RoundIntent(int GunIndex, int RoundIndex,
        bool IsReal, Vector3 Muzzle, float Time);

    private sealed class GunClock
    {
        private IReadOnlyList<bool>? realShots;
        private int nextRoundIndex;
        private float lastShotTime;

        internal void Replace(IReadOnlyList<bool> shots)
        {
            realShots = shots;
            nextRoundIndex = 0;
        }

        internal (int Index, bool IsReal)? TakeDueRound(float time)
        {
            if (realShots == null || nextRoundIndex >= realShots.Count ||
                time <= lastShotTime + AssaultHelicopterVolleyPlanner.GunCadenceSeconds)
                return null;

            int index = nextRoundIndex++;
            lastShotTime = time;
            return (index, realShots[index]);
        }
    }

    private readonly Queue<PreparedVolley> waitingForSecondGun = new();
    private readonly GunClock firstGun = new();
    private readonly GunClock secondGun = new();
    internal PreparedVolley? Latest { get; private set; }

    internal void PrepareFirstGun(float time, ulong tick, ArmyVehicleShotStats shot,
        AssaultHelicopterShotTargetPolicy.Choice targetChoice,
        Func<int, int> chooseIndex, Func<float> nextRandom)
    {
        if (!float.IsFinite(time) || time < 0 || waitingForSecondGun.Count >= 8 ||
            targetChoice == null)
            throw new InvalidDataException("Invalid Assault Helicopter volley queue authority.");

        var plan = AssaultHelicopterVolleyPlanner.Plan(shot, chooseIndex);
        var firstGunShots = AssaultHelicopterVolleyPlanner.SampleRealShots(
            plan.FirstGunCount, shot.ProbabilityOfRealShot, nextRandom);
        float dueTime = time + plan.SecondGunDelaySeconds;
        if (!float.IsFinite(dueTime) || dueTime <= time)
            throw new InvalidDataException("Assault Helicopter second-gun deadline overflowed.");

        var prepared = new PreparedVolley(plan, targetChoice, firstGunShots,
            null, tick, dueTime);
        waitingForSecondGun.Enqueue(prepared);
        firstGun.Replace(firstGunShots);
        Latest = prepared;
    }

    internal void PrepareDueSecondGuns(float time, ArmyVehicleShotStats shot,
        Func<float> nextRandom)
    {
        if (!float.IsFinite(time) || time < 0)
            throw new InvalidDataException("Invalid Assault Helicopter second-gun clock.");

        while (waitingForSecondGun.Count > 0 &&
               waitingForSecondGun.Peek().SecondGunDueTime <= time)
        {
            var pending = waitingForSecondGun.Dequeue();
            var secondGunShots = AssaultHelicopterVolleyPlanner.SampleRealShots(
                pending.Plan.SecondGunCount, shot.ProbabilityOfRealShot, nextRandom);
            secondGun.Replace(secondGunShots);
            if (ReferenceEquals(Latest, pending))
                Latest = pending with { SecondGunRealShots = secondGunShots };
        }
    }

    internal IReadOnlyList<RoundIntent> DueRoundIntents(float time, Vector3 rootPosition,
        Quaternion rootRotation, AssaultHelicopterWeaponCatalog weapons)
    {
        if (!float.IsFinite(time) || time < 0 || weapons == null)
            throw new InvalidDataException("Invalid Assault Helicopter gun clock authority.");

        var rounds = new List<RoundIntent>(2);
        AddDueRound(rounds, firstGun, 0, time, rootPosition, rootRotation, weapons);
        AddDueRound(rounds, secondGun, 1, time, rootPosition, rootRotation, weapons);
        return rounds.AsReadOnly();
    }

    private static void AddDueRound(List<RoundIntent> rounds, GunClock gun, int gunIndex,
        float time, Vector3 rootPosition, Quaternion rootRotation,
        AssaultHelicopterWeaponCatalog weapons)
    {
        Vector3 muzzle = weapons.Muzzle(gunIndex, rootPosition, rootRotation);
        var due = gun.TakeDueRound(time);
        if (due.HasValue)
            rounds.Add(new(gunIndex, due.Value.Index, due.Value.IsReal, muzzle, time));
    }
}

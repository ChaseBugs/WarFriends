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
        string TargetId,
        AssaultHelicopterShotTargetPolicy.Choice TargetChoice,
        Vector3 CapturedVelocity,
        Vector3 FirstAimPoint,
        Vector3? SecondAimPoint,
        IReadOnlyList<bool> FirstGunRealShots,
        IReadOnlyList<bool>? SecondGunRealShots,
        ulong SelectionTick,
        float SecondGunDueTime);
    internal sealed record RoundIntent(int GunIndex, int RoundIndex,
        bool IsReal, Vector3 Muzzle, Vector3 Target, float Time);

    private sealed class GunClock
    {
        private IReadOnlyList<bool>? realShots;
        private Vector3 target;
        private int nextRoundIndex;
        private float lastShotTime;

        internal void Replace(IReadOnlyList<bool> shots, Vector3 aimPoint)
        {
            if (!PlayerHitbox.Finite(aimPoint))
                throw new InvalidDataException("Invalid Assault Helicopter gun aim point.");
            realShots = shots;
            target = aimPoint;
            nextRoundIndex = 0;
        }

        internal (int Index, bool IsReal, Vector3 Target)? TakeDueRound(
            float time, Vector3 gunPosition, Func<float> nextRandom)
        {
            if (realShots == null || nextRoundIndex >= realShots.Count ||
                time <= lastShotTime + AssaultHelicopterVolleyPlanner.GunCadenceSeconds)
                return null;

            int index = nextRoundIndex++;
            lastShotTime = time;
            bool isReal = realShots[index];
            Vector3 aimPoint = isReal ? target : FakeAimPoint(gunPosition,
                target, nextRandom);
            return (index, isReal, aimPoint);
        }
    }

    private readonly Queue<PreparedVolley> waitingForSecondGun = new();
    private readonly GunClock firstGun = new();
    private readonly GunClock secondGun = new();
    internal PreparedVolley? Latest { get; private set; }

    internal void PrepareFirstGun(float time, ulong tick, ArmyVehicleShotStats shot,
        string targetId, AssaultHelicopterShotTargetPolicy.Choice targetChoice,
        Vector3 capturedVelocity, Vector3 firstAimPoint,
        Func<int, int> chooseIndex, Func<float> nextRandom)
    {
        if (!float.IsFinite(time) || time < 0 || waitingForSecondGun.Count >= 8 ||
            string.IsNullOrWhiteSpace(targetId) || targetChoice == null ||
            !PlayerHitbox.Finite(capturedVelocity) ||
            !PlayerHitbox.Finite(firstAimPoint))
            throw new InvalidDataException("Invalid Assault Helicopter volley queue authority.");

        var plan = AssaultHelicopterVolleyPlanner.Plan(shot, chooseIndex);
        var firstGunShots = AssaultHelicopterVolleyPlanner.SampleRealShots(
            plan.FirstGunCount, shot.ProbabilityOfRealShot, nextRandom);
        float dueTime = time + plan.SecondGunDelaySeconds;
        if (!float.IsFinite(dueTime) || dueTime <= time)
            throw new InvalidDataException("Assault Helicopter second-gun deadline overflowed.");

        var prepared = new PreparedVolley(plan, targetId, targetChoice,
            capturedVelocity, firstAimPoint, null, firstGunShots,
            null, tick, dueTime);
        waitingForSecondGun.Enqueue(prepared);
        firstGun.Replace(firstGunShots, firstAimPoint);
        Latest = prepared;
    }

    internal void PrepareDueSecondGuns(float time, ArmyVehicleShotStats shot,
        Func<float> nextRandom,
        Func<PreparedVolley, (Vector3 Target, Vector3 FirstGunMuzzle)?> refreshTarget)
    {
        if (!float.IsFinite(time) || time < 0 || refreshTarget == null)
            throw new InvalidDataException("Invalid Assault Helicopter second-gun clock.");

        while (waitingForSecondGun.Count > 0 &&
               waitingForSecondGun.Peek().SecondGunDueTime <= time)
        {
            var pending = waitingForSecondGun.Dequeue();
            var refreshed = refreshTarget(pending);
            if (!refreshed.HasValue)
            {
                if (ReferenceEquals(Latest, pending))
                    Latest = pending with { SecondGunRealShots = Array.Empty<bool>() };
                continue;
            }
            Vector3 secondAim = AssaultHelicopterAimPolicy.Second(
                refreshed.Value.FirstGunMuzzle, refreshed.Value.Target,
                pending.CapturedVelocity, shot.ShotSpeed,
                pending.TargetChoice.First.Type == 2);
            var secondGunShots = AssaultHelicopterVolleyPlanner.SampleRealShots(
                pending.Plan.SecondGunCount, shot.ProbabilityOfRealShot, nextRandom);
            secondGun.Replace(secondGunShots, secondAim);
            if (ReferenceEquals(Latest, pending))
                Latest = pending with
                {
                    SecondGunRealShots = secondGunShots,
                    SecondAimPoint = secondAim
                };
        }
    }

    internal IReadOnlyList<RoundIntent> DueRoundIntents(float time, Vector3 rootPosition,
        Quaternion rootRotation, AssaultHelicopterWeaponCatalog weapons,
        Func<float> nextRandom)
    {
        if (!float.IsFinite(time) || time < 0 || weapons == null ||
            nextRandom == null)
            throw new InvalidDataException("Invalid Assault Helicopter gun clock authority.");

        var rounds = new List<RoundIntent>(2);
        AddDueRound(rounds, firstGun, 0, time, rootPosition, rootRotation,
            weapons, nextRandom);
        AddDueRound(rounds, secondGun, 1, time, rootPosition, rootRotation,
            weapons, nextRandom);
        return rounds.AsReadOnly();
    }

    private static void AddDueRound(List<RoundIntent> rounds, GunClock gun, int gunIndex,
        float time, Vector3 rootPosition, Quaternion rootRotation,
        AssaultHelicopterWeaponCatalog weapons, Func<float> nextRandom)
    {
        Vector3 muzzle = weapons.Muzzle(gunIndex, rootPosition, rootRotation);
        var due = gun.TakeDueRound(time, muzzle, nextRandom);
        if (due.HasValue)
            rounds.Add(new(gunIndex, due.Value.Index, due.Value.IsReal,
                muzzle, due.Value.Target, time));
    }

    private static Vector3 FakeAimPoint(Vector3 gunPosition, Vector3 aimPoint,
        Func<float> nextRandom)
    {
        Vector3 sideways = Vector3.Cross(gunPosition - aimPoint, Vector3.UnitY);
        if (!PlayerHitbox.Finite(sideways))
            throw new InvalidDataException("Assault Helicopter fake direction overflowed.");
        sideways = sideways.LengthSquared() > 1e-10f
            ? Vector3.Normalize(sideways) : Vector3.Zero;
        float distanceSample = Sample(nextRandom);
        sideways *= .3f + .2f * distanceSample;
        if (Sample(nextRandom) < .5f) sideways = -sideways;
        Vector3 fakeTarget = aimPoint + sideways + new Vector3(0, .3f, 0);
        if (!PlayerHitbox.Finite(fakeTarget))
            throw new InvalidDataException("Assault Helicopter fake aim overflowed.");
        return fakeTarget;
    }

    private static float Sample(Func<float> nextRandom)
    {
        float value = nextRandom();
        if (!float.IsFinite(value) || value is < 0 or > 1)
            throw new InvalidDataException("Invalid Assault Helicopter fake-shot sample.");
        return value;
    }
}

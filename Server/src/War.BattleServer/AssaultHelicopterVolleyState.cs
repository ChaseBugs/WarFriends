namespace War.BattleServer;

/// <summary>
/// Keeps the two source BatchedWeapon preparations in their scheduled order.
/// A prepared mask does not create a projectile or authorize damage.
/// </summary>
internal sealed class AssaultHelicopterVolleyState
{
    internal sealed record PreparedVolley(
        AssaultHelicopterVolleyPlanner.Volley Plan,
        IReadOnlyList<bool> FirstGunRealShots,
        IReadOnlyList<bool>? SecondGunRealShots,
        ulong SelectionTick,
        float SecondGunDueTime);

    private readonly Queue<PreparedVolley> waitingForSecondGun = new();
    internal PreparedVolley? Latest { get; private set; }

    internal void PrepareFirstGun(float time, ulong tick, ArmyVehicleShotStats shot,
        Func<int, int> chooseIndex, Func<float> nextRandom)
    {
        if (!float.IsFinite(time) || time < 0 || waitingForSecondGun.Count >= 8)
            throw new InvalidDataException("Invalid Assault Helicopter volley queue authority.");

        var plan = AssaultHelicopterVolleyPlanner.Plan(shot, chooseIndex);
        var firstGunShots = AssaultHelicopterVolleyPlanner.SampleRealShots(
            plan.FirstGunCount, shot.ProbabilityOfRealShot, nextRandom);
        float dueTime = time + plan.SecondGunDelaySeconds;
        if (!float.IsFinite(dueTime) || dueTime <= time)
            throw new InvalidDataException("Assault Helicopter second-gun deadline overflowed.");

        var prepared = new PreparedVolley(plan, firstGunShots, null, tick, dueTime);
        waitingForSecondGun.Enqueue(prepared);
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
            if (ReferenceEquals(Latest, pending))
                Latest = pending with { SecondGunRealShots = secondGunShots };
        }
    }
}

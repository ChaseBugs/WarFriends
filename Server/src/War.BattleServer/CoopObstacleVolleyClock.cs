namespace War.BattleServer;

internal enum CoopObstacleAction
{
    None,
    Shoot,
    Reposition
}

/// <summary>Preserves EnemyController's obstacle shot-first branches and scaled-time deadlines.</summary>
internal sealed class CoopObstacleVolleyClock
{
    private const float MinimumPositionDelaySeconds = 2f;
    private const float PreparationPositionDelayRangeSeconds = 1f;
    private const float RepositionDelayRangeSeconds = 4f;

    private ulong _lastTransitionTick;

    internal ulong NextShotTick { get; private set; }

    internal ulong NextPositionTick { get; private set; }

    internal bool IsCrawling { get; private set; } = true;

    internal bool HasPendingShot { get; private set; }

    internal ulong? LastRepositionTick { get; private set; }

    internal CoopObstacleVolleyClock(ulong firstShotTick, ulong firstPositionTick)
    {
        NextShotTick = firstShotTick;
        NextPositionTick = firstPositionTick;
    }

    internal CoopObstacleAction Decide(ulong tick)
    {
        // ObstacleHidingUpdate tests the crawling shot branch before its else-if movement branch.
        if (IsCrawling && tick >= NextShotTick)
        {
            return CoopObstacleAction.Shoot;
        }
        if (!HasPendingShot && tick >= NextPositionTick)
        {
            return CoopObstacleAction.Reposition;
        }
        return CoopObstacleAction.None;
    }

    internal void BeginShot(ulong tick, float positionFraction)
    {
        RequireCurrentTick(tick);
        ValidateFraction(positionFraction);
        if (Decide(tick) != CoopObstacleAction.Shoot)
        {
            throw new InvalidOperationException("Obstacle shot is not ready.");
        }
        ulong positionTick = AfterDelay(tick, MinimumPositionDelaySeconds +
            PreparationPositionDelayRangeSeconds * positionFraction);
        NextPositionTick = positionTick;
        _lastTransitionTick = tick;
        IsCrawling = false;
        HasPendingShot = true;
    }

    internal void CompleteShot(ulong tick, ObstacleShotDelay delay)
    {
        RequireCurrentTick(tick);
        if (!HasPendingShot)
        {
            throw new InvalidOperationException("Obstacle has no pending volley.");
        }
        ValidateFraction(delay.Fraction);
        if (!float.IsFinite(delay.MinimumSeconds) || !float.IsFinite(delay.MaximumSeconds) ||
            delay.MinimumSeconds < 0 || delay.MaximumSeconds < delay.MinimumSeconds)
        {
            throw new InvalidDataException("Invalid source obstacle shot delay.");
        }
        float seconds = delay.MinimumSeconds +
            (delay.MaximumSeconds - delay.MinimumSeconds) * delay.Fraction;
        ulong shotTick = AfterDelay(tick, seconds);
        // EndShooting clears mWillShoot, then ReturnToPreviousStateFromShot restores crawling.
        NextShotTick = shotTick;
        _lastTransitionTick = tick;
        HasPendingShot = false;
        IsCrawling = true;
    }

    internal void Reposition(ulong tick, float positionFraction)
    {
        RequireCurrentTick(tick);
        ValidateFraction(positionFraction);
        if (Decide(tick) != CoopObstacleAction.Reposition)
        {
            throw new InvalidOperationException("Obstacle reposition is not ready.");
        }
        ulong positionTick = AfterDelay(tick, MinimumPositionDelaySeconds +
            RepositionDelayRangeSeconds * positionFraction);
        NextPositionTick = positionTick;
        LastRepositionTick = tick;
        _lastTransitionTick = tick;
    }

    private void RequireCurrentTick(ulong tick)
    {
        if (tick < _lastTransitionTick)
        {
            throw new InvalidOperationException("Obstacle state cannot move backward in time.");
        }
    }

    private static ulong AfterDelay(ulong tick, float seconds)
    {
        // Source deadlines use a strict mTime > deadline comparison at the host's 30 Hz boundary.
        ulong ticks = checked((ulong)Math.Floor(seconds * MatchManifest.TickRate) + 1);
        return checked(tick + ticks);
    }

    private static void ValidateFraction(float fraction)
    {
        if (!float.IsFinite(fraction) || fraction < 0 || fraction >= 1)
        {
            throw new InvalidDataException("Obstacle random fraction must be in [0, 1).");
        }
    }
}

internal sealed record ObstacleShotDelay(float MinimumSeconds, float MaximumSeconds, float Fraction);

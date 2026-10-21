namespace War.BattleServer;

/// <summary>Preserves the recovered animation controller's scaled float deadline and strict comparison.</summary>
internal sealed class CoopObstacleCrawlReturnClock
{
    private float _deadline;
    private float _lastObservedTime;

    internal float Deadline => _deadline;

    internal void RecordShot(float scaledTime, float hideAfter)
    {
        ValidateTime(scaledTime);
        if (!float.IsFinite(hideAfter) || hideAfter <= 0f)
        {
            throw new InvalidDataException("Obstacle hide duration must be positive and finite.");
        }

        // SoldierAnimationController.ShootFromCrawl assigns Time.time + hideAfter on every round.
        float deadline = scaledTime + hideAfter;
        if (!float.IsFinite(deadline) || deadline <= scaledTime)
        {
            throw new InvalidDataException("Obstacle hide deadline cannot advance the scaled float clock.");
        }

        _deadline = deadline;
        _lastObservedTime = scaledTime;
    }

    internal bool Update(float scaledTime)
    {
        ValidateTime(scaledTime);
        _lastObservedTime = scaledTime;
        if (_deadline == 0f || scaledTime <= _deadline)
        {
            return false;
        }

        // Update clears the timer before playing stand_up_crawl, so the event fires only once.
        _deadline = 0f;
        return true;
    }

    private void ValidateTime(float scaledTime)
    {
        if (!float.IsFinite(scaledTime) || scaledTime < 0f || scaledTime < _lastObservedTime)
        {
            throw new InvalidDataException("Obstacle scaled time must be finite, nonnegative and monotonic.");
        }
    }
}

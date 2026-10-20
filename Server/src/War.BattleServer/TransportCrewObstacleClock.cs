namespace War.BattleServer;

/// <summary>Preserves ObstacleHidingUpdate ordering while shot preparation still requires its own consumer.</summary>
internal sealed class TransportCrewObstacleClock
{
    private const float MinimumRepositionDelay = 2f;
    private const float RepositionDelayRange = 4f;

    private readonly TransportCrewPointEntry _entry;
    private ulong _lastFrame;
    private float _lastTime;
    private Observation? _pendingObservation;
    private bool _isRetired;

    internal float NextRepositionTime { get; private set; }

    internal ActionKind? PendingAction { get; private set; }

    internal float NextEnemyChangeTime { get; private set; }

    internal TransportCrewObstacleClock(TransportCrewPointEntry entry, ulong frame)
    {
        ArgumentNullException.ThrowIfNull(entry);
        if (!entry.IsCrawling || entry.NextRepositionTime is not float deadline)
        {
            throw new InvalidDataException("Obstacle updates require an obstacle-hiding entry.");
        }
        _entry = entry;
        NextRepositionTime = deadline;
        NextEnemyChangeTime = entry.NextEnemyChangeTime;
        _lastFrame = frame;
        _lastTime = entry.ControllerTime;
    }

    internal ActionKind Select(Observation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (observation.Frame <= _lastFrame || !float.IsFinite(observation.ControllerTime) ||
            observation.ControllerTime < _lastTime)
        {
            throw new InvalidDataException("Obstacle callbacks require increasing frames and coherent scaled time.");
        }
        if (_isRetired || PendingAction.HasValue)
        {
            throw new InvalidOperationException(
                "A required source action must be handled before later obstacle updates.");
        }
        if (observation.ControllerTime > _entry.NextShootTime)
        {
            // Source ignores mWillShoot in this first branch. Do not let a due reposition bypass it.
            return ActionKind.ShotPreparationRequired;
        }
        if (observation.ControllerTime > NextRepositionTime && !observation.IsPreparingShot)
        {
            return ActionKind.Reposition;
        }
        if (observation.ControllerTime > NextEnemyChangeTime && !observation.IsPreparingShot &&
            observation.CanChangePosition)
        {
            return ActionKind.PointChangeRequired;
        }
        return ActionKind.Waiting;
    }

    internal float RepositionDeadline(Observation observation, float fraction)
    {
        if (!float.IsFinite(fraction) || fraction is < 0 or > 1)
        {
            throw new InvalidDataException("Obstacle reposition draw must be a source float fraction.");
        }
        float delay = MinimumRepositionDelay + RepositionDelayRange * fraction;
        float deadline = observation.ControllerTime + delay;
        if (!float.IsFinite(deadline) || deadline <= observation.ControllerTime)
        {
            throw new InvalidDataException("Obstacle reposition exceeds source float time resolution.");
        }
        return deadline;
    }

    internal void Accept(Observation observation, float? nextRepositionTime = null)
    {
        ActionKind action = Select(observation);
        if (nextRepositionTime.HasValue && (action != ActionKind.Reposition ||
            !float.IsFinite(nextRepositionTime.Value) || nextRepositionTime.Value <= observation.ControllerTime))
        {
            throw new InvalidDataException("Only a due reposition may publish a later finite deadline.");
        }
        _lastFrame = observation.Frame;
        _lastTime = observation.ControllerTime;
        if (nextRepositionTime.HasValue)
        {
            NextRepositionTime = nextRepositionTime.Value;
        }
        if (action is ActionKind.ShotPreparationRequired or ActionKind.PointChangeRequired)
        {
            PendingAction = action;
            _pendingObservation = observation;
        }
    }

    internal void RequirePointChange(Observation observation)
    {
        if (_isRetired || PendingAction != ActionKind.PointChangeRequired ||
            !ReferenceEquals(_pendingObservation, observation))
        {
            throw new InvalidOperationException("Point change requires its exact pending source callback.");
        }
    }

    internal void CompleteBlockedPointChange(Observation observation)
    {
        RequirePointChange(observation);
        const float RetrySeconds = 10f;
        float deadline = NextEnemyChangeTime + RetrySeconds;
        if (!float.IsFinite(deadline) || deadline <= NextEnemyChangeTime)
        {
            throw new InvalidDataException("Point-change retry exceeds source float deadline resolution.");
        }
        // Source adds ten to the previous deadline; scheduling from current time would change late callbacks.
        NextEnemyChangeTime = deadline;
        PendingAction = null;
        _pendingObservation = null;
    }

    internal void CompleteSuccessfulPointChange(Observation observation)
    {
        RequirePointChange(observation);
        _isRetired = true;
        PendingAction = null;
        _pendingObservation = null;
    }

    internal enum ActionKind
    {
        Waiting,
        ShotPreparationRequired,
        Reposition,
        PointChangeRequired,
    }

    internal sealed record Observation(ulong Frame, float ControllerTime, bool IsPreparingShot, bool CanChangePosition);
}

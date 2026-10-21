using System.Numerics;

namespace War.BattleServer;

internal sealed record HelicopterCrewRetryObservation(ulong Frame, float ScaledTime, Vector3 Position);

internal enum HelicopterCrewRetryStatus
{
    Waiting,
    Assigned,
    Cancelled,
    Faulted,
}

/// <summary>Owns one fallback actor's scaled retries; actor life and movement remain caller-owned.</summary>
internal sealed class CoopHelicopterFallbackRetry
{
    private readonly ulong _entityId;
    private readonly CoopEnemyDestinationState _destinations;
    private readonly HelicopterCrewRetryClock _clock;

    internal CoopHelicopterFallbackRetry(ulong entityId, CoopEnemyDestinationState destinations,
        HelicopterCrewRetryObservation scheduled)
    {
        ArgumentNullException.ThrowIfNull(destinations);
        Validate(scheduled);
        if (entityId == 0 || destinations.ForEnemy(entityId) != null)
        {
            throw new InvalidOperationException("Fallback retry requires an unassigned host actor identity.");
        }
        _clock = new HelicopterCrewRetryClock(scheduled.Frame, scheduled.ScaledTime);
        _entityId = entityId;
        _destinations = destinations;
    }

    internal HelicopterCrewRetryStatus Status { get; private set; } = HelicopterCrewRetryStatus.Waiting;

    internal CoopAssignedEnemyDestination? Destination { get; private set; }

    /// <summary>Attempts nearest-point reservation only when the observed source wait becomes due.</summary>
    internal CoopAssignedEnemyDestination? Advance(HelicopterCrewRetryObservation observation)
    {
        Validate(observation);
        if (Status == HelicopterCrewRetryStatus.Faulted)
        {
            throw new InvalidOperationException("Faulted crew retry requires caller failure handling.");
        }
        if (Status != HelicopterCrewRetryStatus.Waiting ||
            !_clock.TryConsume(observation.Frame, observation.ScaledTime))
        {
            return Destination;
        }
        return AttemptReservation(observation.Position);
    }

    /// <summary>
    /// Cancels an unresolved wait; an assigned destination belongs to the actor's normal release lifecycle.
    /// </summary>
    internal void Cancel()
    {
        if (Status == HelicopterCrewRetryStatus.Waiting)
        {
            Status = HelicopterCrewRetryStatus.Cancelled;
        }
    }

    private CoopAssignedEnemyDestination? AttemptReservation(Vector3 currentPosition)
    {
        try
        {
            Destination = _destinations.RetryHelicopterAssaulterPoint(_entityId, currentPosition);
            if (Destination == null)
            {
                _clock.ScheduleNext();
            }
            else
            {
                Status = HelicopterCrewRetryStatus.Assigned;
            }
            return Destination;
        }
        catch
        {
            // Source callback failure cannot be silently converted into another successful wait or assignment.
            Status = HelicopterCrewRetryStatus.Faulted;
            throw;
        }
    }

    private static void Validate(HelicopterCrewRetryObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (!float.IsFinite(observation.ScaledTime) || observation.ScaledTime < 0 ||
            !PlayerHitbox.Finite(observation.Position))
        {
            throw new InvalidDataException("Crew retry requires a finite host pose and nonnegative scaled time.");
        }
    }
}

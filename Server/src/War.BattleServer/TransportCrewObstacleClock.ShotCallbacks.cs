namespace War.BattleServer;

internal sealed partial class TransportCrewObstacleClock
{
    private const float PreparationPositionMinimum = 2f;
    private const float CallbackPaddingSeconds = 0.05f;
    private const float MaximumClipSeconds = 60f;

    private float _lastCoroutineTime;
    private ulong? _shotStartedFrame;

    internal ShotCallbackTicket? CurrentShot { get; private set; }

    internal bool IsShooting { get; private set; }

    internal void RequireShotPreparation(Observation observation)
    {
        RequirePendingObservation(observation, ActionKind.ShotPreparationRequired);
    }

    /// <summary>Observes preparation signals without resolving targets or authorizing projectile damage.</summary>
    internal ShotCallbackTicket? ObservePreparation(Observation request, PreparationTiming timing,
        ArmyBaseShotStats shot, PreparationDraws draws)
    {
        RequireShotPreparation(request);
        ValidatePreparation(timing, draws);
        float nextShot = timing.Outcome == PreparationOutcome.CannotShoot ? NextShootTime :
            ShotDeadline(request.ControllerTime, shot, draws.ShotFraction.GetValueOrDefault());
        float positionDelay = PreparationPositionMinimum + draws.PositionFraction;
        float nextPosition = Deadline(request.ControllerTime, positionDelay);
        ShotCallbackTicket? ticket = null;
        if (timing.Outcome == PreparationOutcome.Prepared)
        {
            float delay = timing.ClipLength.GetValueOrDefault() + CallbackPaddingSeconds;
            ticket = new ShotCallbackTicket(request.Frame, Deadline(timing.CoroutineTime, delay));
        }

        // ObstacleHidingUpdate clears crawling even when PrepareToShoot returned false.
        NextShootTime = nextShot;
        NextRepositionTime = nextPosition;
        IsCrawling = false;
        HasPendingVolley = ticket != null;
        IsShooting = false;
        CurrentShot = ticket;
        _shotStartedFrame = null;
        _lastCoroutineTime = timing.CoroutineTime;
        PendingAction = null;
        _pendingObservation = null;
        return ticket;
    }

    internal void ObserveShotStarted(ShotCallbackTicket ticket, ShotObservation observation)
    {
        RequireShot(ticket, observation);
        if (IsShooting || observation.Frame <= ticket.ScheduledFrame ||
            observation.CoroutineTime < ticket.CoroutineDeadline)
        {
            throw new InvalidOperationException("Shot-start callback is early or already consumed.");
        }
        IsShooting = true;
        _shotStartedFrame = observation.Frame;
        // WaitForSeconds resumes after Update; this frame cannot run another obstacle/gameplay update.
        _lastFrame = observation.Frame;
        _lastTime = observation.ControllerTime;
        _lastCoroutineTime = observation.CoroutineTime;
    }

    internal void RequireShotEnd(ShotCallbackTicket ticket, ShotObservation observation)
    {
        RequireShot(ticket, observation);
        if (!IsShooting || _shotStartedFrame is not ulong started || observation.Frame <= started ||
            observation.Frame <= _lastFrame)
        {
            throw new InvalidOperationException(
                "EndShooting must follow the delayed start and precede this frame's AI update.");
        }
    }

    /// <summary>Observes EndShooting's flags and fresh delay, without claiming any rounds or hits occurred.</summary>
    internal void ObserveShotEnded(ShotCallbackTicket ticket, ShotObservation observation,
        ArmyBaseShotStats shot, float fraction)
    {
        RequireShotEnd(ticket, observation);
        float deadline = ShotDeadline(observation.ControllerTime, shot, fraction);
        NextShootTime = deadline;
        IsCrawling = true;
        HasPendingVolley = false;
        IsShooting = false;
        CurrentShot = null;
        _lastTime = observation.ControllerTime;
        _lastCoroutineTime = observation.CoroutineTime;
        // ShootingFromWeapon calls EndShooting before ObstacleHidingUpdate in this same Update.
    }

    private void RequireShot(ShotCallbackTicket ticket, ShotObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (_isRetired || !HasPendingVolley || !ReferenceEquals(CurrentShot, ticket) ||
            !float.IsFinite(observation.ControllerTime) || observation.ControllerTime < _lastTime ||
            !float.IsFinite(observation.CoroutineTime) || observation.CoroutineTime < _lastCoroutineTime ||
            observation.Frame < _lastFrame)
        {
            throw new InvalidOperationException("Shot callback requires its current ticket and coherent host clocks.");
        }
    }

    private static void ValidatePreparation(PreparationTiming timing, PreparationDraws draws)
    {
        ArgumentNullException.ThrowIfNull(timing);
        ArgumentNullException.ThrowIfNull(draws);
        bool prepared = timing.Outcome == PreparationOutcome.Prepared;
        bool drawsShot = timing.Outcome != PreparationOutcome.CannotShoot;
        if (!Enum.IsDefined(timing.Outcome) || !float.IsFinite(timing.CoroutineTime) || timing.CoroutineTime < 0 ||
            !IsFraction(draws.PositionFraction) || drawsShot != draws.ShotFraction.HasValue ||
            (draws.ShotFraction.HasValue && !IsFraction(draws.ShotFraction.Value)) ||
            prepared != timing.ClipLength.HasValue ||
            (timing.ClipLength.HasValue && (!float.IsFinite(timing.ClipLength.Value) ||
                timing.ClipLength.Value <= 0 || timing.ClipLength.Value > MaximumClipSeconds)))
        {
            throw new InvalidDataException("Observed preparation requires source timing and branch-specific draws.");
        }
    }

    private static float ShotDeadline(float time, ArmyBaseShotStats shot, float fraction)
    {
        ArgumentNullException.ThrowIfNull(shot);
        if (!IsFraction(fraction) || !float.IsFinite(shot.MinShootTime) ||
            !float.IsFinite(shot.MaxShootTime) || shot.MinShootTime < 0 || shot.MaxShootTime < shot.MinShootTime)
        {
            throw new InvalidDataException("Source shot callback requires validated card shot delays.");
        }
        return Deadline(time, shot.MinShootTime + (shot.MaxShootTime - shot.MinShootTime) * fraction);
    }

    private static float Deadline(float time, float delay)
    {
        float deadline = time + delay;
        if (!float.IsFinite(deadline) || deadline < time || (delay > 0 && deadline == time))
        {
            throw new InvalidDataException("Shot callback deadline exceeds source float time resolution.");
        }
        return deadline;
    }

    private static bool IsFraction(float value)
    {
        return float.IsFinite(value) && value is >= 0 and <= 1;
    }

    internal enum PreparationOutcome
    {
        CannotShoot,
        NoTarget,
        Prepared,
    }

    internal sealed record PreparationTiming(PreparationOutcome Outcome, float CoroutineTime, float? ClipLength);

    internal sealed record PreparationDraws(float? ShotFraction, float PositionFraction);

    internal sealed record ShotObservation(ulong Frame, float ControllerTime, float CoroutineTime);

    /// <summary>A host callback identity, never a projectile, round-count or damage receipt.</summary>
    internal sealed class ShotCallbackTicket
    {
        internal ulong ScheduledFrame { get; }
        internal float CoroutineDeadline { get; }

        internal ShotCallbackTicket(ulong scheduledFrame, float coroutineDeadline)
        {
            ScheduledFrame = scheduledFrame;
            CoroutineDeadline = coroutineDeadline;
        }
    }
}

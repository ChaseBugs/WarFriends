namespace War.BattleServer;

/// <summary>One due source physics quantum, dispatched before the current render update.</summary>
internal readonly record struct HelicopterPhysicsQuantum(
    HelicopterPhysicsMode Mode, float DeltaTime, ulong Sequence);

/// <summary>Match-owned fixed/render phase clock; physical debt survives mode changes and zero-delta frames.</summary>
internal sealed class HelicopterPhysicsFrameClock
{
    // Active recovered ProjectSettings/TimeManager.asset: Maximum Allowed Timestep = 0.2.
    private const float MaximumRenderDelta = 0.2f;
    private double _remainingSeconds;
    private HelicopterPhysicsMode _mode;
    private Phase _phase;

    internal ulong PhysicsSteps { get; private set; }
    internal ulong RenderFrames { get; private set; }
    internal ulong NominalPhysicsMilliseconds { get; private set; }
    internal double RemainingSeconds => _remainingSeconds;

    internal HelicopterPhysicsFrameClock(double initialRemainingSeconds = 0)
    {
        if (!double.IsFinite(initialRemainingSeconds) || initialRemainingSeconds < 0 ||
            initialRemainingSeconds >= HelicopterPhysicsTiming.NormalSeconds)
        {
            throw new InvalidDataException("Physics clock requires a finite initial sub-step remainder.");
        }
        _remainingSeconds = initialRemainingSeconds;
    }

    internal void SetPhysicsMode(HelicopterPhysicsMode mode)
    {
        RequireAvailable();
        _ = HelicopterPhysicsTiming.Seconds(mode);
        _mode = mode;
    }

    internal void BeginFrame(float scaledDeltaTime)
    {
        RequirePhase(Phase.Idle);
        if (!float.IsFinite(scaledDeltaTime) || scaledDeltaTime < 0 || scaledDeltaTime > MaximumRenderDelta)
        {
            throw new InvalidDataException("Physics clock requires a bounded finite scaled render delta.");
        }
        _remainingSeconds += scaledDeltaTime;
        _phase = Phase.Physics;
    }

    internal HelicopterPhysicsQuantum? TakePhysicsStep()
    {
        RequirePhase(Phase.Physics);
        float delta = HelicopterPhysicsTiming.Seconds(_mode);
        if (_remainingSeconds < delta)
        {
            _phase = Phase.Render;
            return null;
        }
        ulong nextStep = checked(PhysicsSteps + 1);
        ulong nextMilliseconds = checked(NominalPhysicsMilliseconds + HelicopterPhysicsTiming.Milliseconds(_mode));
        var quantum = new HelicopterPhysicsQuantum(_mode, delta, nextStep);
        _remainingSeconds -= delta;
        PhysicsSteps = nextStep;
        NominalPhysicsMilliseconds = nextMilliseconds;
        return quantum;
    }

    internal void CompleteRenderFrame()
    {
        RequirePhase(Phase.Render);
        ulong nextFrame = checked(RenderFrames + 1);
        RenderFrames = nextFrame;
        _phase = Phase.Idle;
    }

    /// <summary>Closes this clock after failed world execution; consumed physical work cannot be rolled back.</summary>
    internal void Fault()
    {
        _phase = Phase.Faulted;
    }

    private void RequirePhase(Phase expected)
    {
        RequireAvailable();
        if (_phase != expected)
        {
            throw new InvalidOperationException("Physics must drain before rendering, and frames cannot overlap.");
        }
    }

    private void RequireAvailable()
    {
        if (_phase == Phase.Faulted)
        {
            throw new InvalidOperationException("A failed physics clock cannot resume or replay consumed steps.");
        }
    }

    private enum Phase
    {
        Idle,
        Physics,
        Render,
        Faulted
    }
}

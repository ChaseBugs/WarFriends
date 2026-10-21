namespace War.BattleServer;

/// <summary>Observed component state and layer clocks; visibility and bone evaluation remain caller-owned.</summary>
internal sealed record HelicopterSlideMixerSnapshot(HelicopterSlideFadeSnapshot Layers,
    bool IsAnimationEnabled, ulong RenderFrames, ulong EvaluatedFrames);

/// <summary>Captured 30 Hz, speed-one idle/slide mixer with disabled-component observation and catch-up.</summary>
internal sealed class HelicopterSlideMixerState
{
    private const float FrameDelta = 1f / MatchManifest.TickRate;
    private const float FadeSeconds = 0.3f;
    private readonly float _initialIdlePhase;
    private readonly float _initialIdleWeight;
    private readonly float _initialSlideWeight;
    private float _lastEvaluatedTime;
    private float _idleWeight;
    private float _slideWeight;

    internal HelicopterSlideMixerSnapshot Current { get; private set; }

    internal HelicopterSlideMixerState(float initialIdlePhase) : this(FullyWeightedStart(initialIdlePhase))
    {
    }

    private HelicopterSlideMixerState(HelicopterSlideFadeSnapshot initial)
    {
        ArgumentNullException.ThrowIfNull(initial);
        ArgumentNullException.ThrowIfNull(initial.Idle);
        ArgumentNullException.ThrowIfNull(initial.Slide);
        if (!float.IsFinite(initial.Idle.RawTime) || initial.Idle.RawTime < 0 ||
            !float.IsFinite(initial.Idle.Weight) || initial.Idle.Weight is < 0 or > 1 || !initial.Idle.IsEnabled ||
            initial.Slide.RawTime != 0 || initial.Slide.Weight is not (0 or 1) || !initial.Slide.IsEnabled)
        {
            throw new InvalidDataException("Slide transition requires observed idle and newly enabled slide layers.");
        }
        _initialIdlePhase = initial.Idle.RawTime;
        _initialIdleWeight = initial.Idle.Weight;
        _idleWeight = initial.Idle.Weight;
        _initialSlideWeight = initial.Slide.Weight;
        _slideWeight = initial.Slide.Weight;
        Current = new HelicopterSlideMixerSnapshot(initial, true, 0, 0);
    }

    /// <summary>Starts from an enabled host-observed command boundary without inferring phase from spawn age.</summary>
    internal static HelicopterSlideMixerState FromObservedTransition(HelicopterSlideFadeSnapshot initial)
    {
        return new HelicopterSlideMixerState(initial);
    }

    private static HelicopterSlideFadeSnapshot FullyWeightedStart(float initialIdlePhase)
    {
        if (!float.IsFinite(initialIdlePhase) || initialIdlePhase < 0 || initialIdlePhase >= 1)
        {
            throw new InvalidDataException("Slide mixer requires a phase inside the captured ordinary idle loop.");
        }
        return new HelicopterSlideFadeSnapshot(new HelicopterFadeLayer(initialIdlePhase, 1, true),
            new HelicopterFadeLayer(0, 0, true));
    }

    internal HelicopterSlideMixerSnapshot AdvanceEnabledFrame()
    {
        ulong nextFrame = checked(Current.RenderFrames + 1);
        ulong nextEvaluation = checked(Current.EvaluatedFrames + 1);
        double elapsed = nextFrame * (double)FrameDelta;
        float time = (float)elapsed;
        // Re-enabling evaluates the elapsed interval once, rather than replaying every hidden frame.
        float evaluationDelta = Current.IsAnimationEnabled ? FrameDelta : time - _lastEvaluatedTime;
        float fadeFraction = evaluationDelta / FadeSeconds;
        float nextIdle = _idleWeight - _initialIdleWeight * fadeFraction;
        float idle = Math.Clamp(nextIdle, 0, 1);
        float slide = Math.Clamp(_slideWeight + (1f - _initialSlideWeight) * fadeFraction, 0, 1);
        // A positive outgoing weight that reaches exact zero remains enabled until the next overshoot.
        bool isIdleEnabled = Current.Layers.Idle.IsEnabled && _initialIdleWeight > 0 && nextIdle >= 0;
        var layers = new HelicopterSlideFadeSnapshot(
            new HelicopterFadeLayer(isIdleEnabled ? (float)(_initialIdlePhase + elapsed) : 0, idle, isIdleEnabled),
            new HelicopterFadeLayer(time, slide, true));
        Current = new HelicopterSlideMixerSnapshot(layers, true, nextFrame, nextEvaluation);
        _lastEvaluatedTime = time;
        _idleWeight = idle;
        _slideWeight = slide;
        return Current;
    }

    internal HelicopterSlideMixerSnapshot AdvanceDisabledFrame()
    {
        // The source component retains sampled layers and local bones while its global game clock continues.
        Current = Current with { IsAnimationEnabled = false, RenderFrames = checked(Current.RenderFrames + 1) };
        return Current;
    }
}

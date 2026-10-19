namespace War.BattleServer;

/// <summary>Observed component state and layer clocks; visibility policy and bone evaluation remain caller-owned.</summary>
internal sealed record HelicopterSlideMixerSnapshot(HelicopterSlideFadeSnapshot Layers,
    bool IsAnimationEnabled, ulong RenderFrames, ulong EvaluatedFrames);

/// <summary>Captured 30 Hz, speed-one idle/slide mixer with disabled-component observation and catch-up.</summary>
internal sealed class HelicopterSlideMixerState
{
    private const float FrameDelta = 1f / MatchManifest.TickRate;
    private const float FadeSeconds = 0.3f;
    private readonly float _initialIdlePhase;
    private float _lastEvaluatedTime;
    private float _idleWeight = 1f;
    private float _slideWeight;

    internal HelicopterSlideMixerState(float initialIdlePhase)
    {
        if (!float.IsFinite(initialIdlePhase) || initialIdlePhase < 0 || initialIdlePhase >= 1)
        {
            throw new InvalidDataException("Slide mixer requires a phase inside the captured ordinary idle loop.");
        }
        _initialIdlePhase = initialIdlePhase;
        Current = new HelicopterSlideMixerSnapshot(new HelicopterSlideFadeSnapshot(
            new HelicopterFadeLayer(initialIdlePhase, 1, true), new HelicopterFadeLayer(0, 0, true)), true, 0, 0);
    }

    internal HelicopterSlideMixerSnapshot Current { get; private set; }

    internal HelicopterSlideMixerSnapshot AdvanceEnabledFrame()
    {
        ulong nextFrame = checked(Current.RenderFrames + 1);
        ulong nextEvaluation = checked(Current.EvaluatedFrames + 1);
        double elapsed = nextFrame * (double)FrameDelta;
        float time = (float)elapsed;
        // Re-enabling evaluates the elapsed interval once, rather than replaying every hidden frame.
        float evaluationDelta = Current.IsAnimationEnabled ? FrameDelta : time - _lastEvaluatedTime;
        float idle = Math.Clamp(_idleWeight - evaluationDelta / FadeSeconds, 0, 1);
        float slide = Math.Clamp(_slideWeight + evaluationDelta / FadeSeconds, 0, 1);
        var layers = new HelicopterSlideFadeSnapshot(
            new HelicopterFadeLayer(idle > 0 ? (float)(_initialIdlePhase + elapsed) : 0, idle, idle > 0),
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

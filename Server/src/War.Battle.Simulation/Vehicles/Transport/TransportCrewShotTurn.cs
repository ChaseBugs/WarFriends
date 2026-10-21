using System.Numerics;

namespace War.BattleServer;

/// <summary>Retains one prepared root turn; the caller must observe its actual tween Update phase.</summary>
internal sealed class TransportCrewShotTurn
{
    private readonly CoopShotRootTween _tween;
    private readonly ulong _beginFrame;
    private ulong? _lastFrame;

    internal TransportCrewShotTurn(CoopShotRootTween tween, ulong beginFrame)
    {
        _tween = tween ?? throw new ArgumentNullException(nameof(tween));
        _beginFrame = beginFrame;
    }

    internal Quaternion Advance(Observation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (observation.Frame < _beginFrame || (_lastFrame.HasValue && observation.Frame <= _lastFrame.Value))
        {
            throw new InvalidOperationException("Crew turn requires a current, unconsumed tween Update frame.");
        }
        Quaternion rotation = CoopShotRootComposition.AfterFrame(_tween,
            observation.RootBeforeUpdate, observation.ScaledDeltaSeconds);
        _lastFrame = observation.Frame;
        return rotation;
    }

    internal sealed record Observation(ulong Frame, Quaternion RootBeforeUpdate, float ScaledDeltaSeconds);
}

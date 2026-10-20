using System.Numerics;

namespace War.BattleServer;

/// <summary>Ports NavigationAgent.Updatenavigation's stuck-path recovery prelude, not native agent motion.</summary>
internal sealed class NavigationAgentRecoveryState
{
    private const double MinimumPathEndDistance = 0.1;
    private const float MaximumStoppedVelocitySquared = 0.05f;

    private ulong? _lastFrame;

    internal Recovery? Observe(Observation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        if (_lastFrame.HasValue && observation.Frame <= _lastFrame.Value)
        {
            throw new InvalidOperationException("Agent recovery callback frames must increase.");
        }
        if (!Enum.IsDefined(observation.Status) || !PlayerHitbox.Finite(observation.PathEndPosition) ||
            !PlayerHitbox.Finite(observation.NativeDestination) || !PlayerHitbox.Finite(observation.RawVelocity))
        {
            throw new InvalidDataException("Agent recovery requires a valid raw native observation.");
        }

        Vector3 difference = observation.PathEndPosition - observation.NativeDestination;
        float distanceSquared = SquaredMagnitude(difference);
        float velocitySquared = SquaredMagnitude(observation.RawVelocity);
        if (!float.IsFinite(distanceSquared) || !float.IsFinite(velocitySquared))
        {
            throw new InvalidDataException("Agent recovery observation exceeds finite source arithmetic.");
        }

        // Preserve the source double literal and raw velocity; the wrapper getter has a different dead zone.
        float distance = MathF.Sqrt(distanceSquared);
        bool shouldRecover = !observation.WrapperIsStopped && observation.Status == PathStatus.Complete &&
            (double)distance > MinimumPathEndDistance && velocitySquared < MaximumStoppedVelocitySquared &&
            !observation.PathPending;
        _lastFrame = observation.Frame;
        return shouldRecover ? new Recovery(observation.Frame, observation.NativeDestination) : null;
    }

    private static float SquaredMagnitude(Vector3 value)
    {
        return value.X * value.X + value.Y * value.Y + value.Z * value.Z;
    }

    internal enum PathStatus
    {
        Complete = 0,
        Partial = 1,
        Invalid = 2,
    }

    internal enum Operation
    {
        Stop,
        ResetPath,
        SetDestination,
        Resume,
    }

    internal sealed record Observation
    {
        internal required ulong Frame { get; init; }
        internal required bool WrapperIsStopped { get; init; }
        internal required PathStatus Status { get; init; }
        internal required bool PathPending { get; init; }
        internal required Vector3 PathEndPosition { get; init; }
        internal required Vector3 NativeDestination { get; init; }
        internal required Vector3 RawVelocity { get; init; }
    }

    internal sealed record Recovery(ulong Frame, Vector3 NativeDestination)
    {
        private static readonly IReadOnlyList<Operation> SourceOperations = Array.AsReadOnly(new[]
        {
            Operation.Stop, Operation.ResetPath, Operation.SetDestination, Operation.Resume,
        });

        internal IReadOnlyList<Operation> Operations => SourceOperations;
    }
}

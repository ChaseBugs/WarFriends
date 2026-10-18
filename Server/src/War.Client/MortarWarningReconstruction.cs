using System;
using War.Protocol;
using War.Shared;

namespace War.Client
{
    /// <summary>Restores a sampled source warning to current authoritative match time, preserving reuse history.</summary>
    public static class MortarWarningReconstruction
    {
        private const ulong MaximumTick = 10_000_000;
        private const ulong MaximumReplayFrames = 30 * 60;
        private const float FrameSeconds = 1f / 30f;

        /// <summary>Returns null only when source playback hides the warning; old checkpoints require a fresh scan.</summary>
        public static BattleMortarWarningState AtTick(BattleMortarWarningState source, ulong currentTick)
        {
            if (source == null || currentTick < source.ObservedTick || currentTick > MaximumTick ||
                currentTick - source.ObservedTick > MaximumReplayFrames)
            {
                throw new InvalidOperationException("Warning reconstruction requires a recent nonfuture checkpoint.");
            }
            MortarWarningPolicy.Validate(new[] { source }, source.ObservedTick, source.ObserverFraction);
            MortarIndicatorClock clock = MortarIndicatorClock.FromCheckpoint(source.Clock);
            for (ulong frame = source.ObservedTick; frame < currentTick; frame++)
            {
                clock.Advance(FrameSeconds);
            }
            if (!clock.IsVisible)
            {
                return null;
            }
            BattleMortarWarningState result = source.Clone();
            result.ObservedTick = currentTick;
            result.RotationFactor = clock.RotationFactor;
            result.Scale = clock.Scale;
            result.Alpha = clock.Alpha;
            result.Clock = clock.Capture();
            return result;
        }
    }
}

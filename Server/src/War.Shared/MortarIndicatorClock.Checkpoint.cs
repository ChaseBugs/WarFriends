using System;
using War.Protocol;

namespace War.Shared
{
    public sealed partial class MortarIndicatorClock
    {
        private const float MaximumShrinkSpeed = 33_554_432f;
        private const float CheckpointTolerance = 0.00001f;

        /// <summary>Copies every stored source tween field needed for subsequent frame-exact updates.</summary>
        public BattleMortarWarningClockState Capture()
        {
            return new BattleMortarWarningClockState
            {
                HasBegun = _hasBegun, HasBlinkStarted = _hasBlinkStarted,
                SkipReactivationFrame = _skipReactivationFrame, Visible = IsVisible,
                Shrinking = IsShrinking, Blinking = IsBlinking, RotationFactor = RotationFactor,
                ShrinkFactor = ShrinkFactor, BlinkFactor = BlinkFactor, Scale = Scale, Alpha = Alpha,
                ShrinkSpeed = _shrinkSpeed, BlinkSpeed = _blinkSpeed, BlinkBoundaryCount = _blinkBoundaryCount
            };
        }

        /// <summary>Restores an independent validated source clock without replaying BeginShot or resetting history.</summary>
        public static MortarIndicatorClock FromCheckpoint(BattleMortarWarningClockState state)
        {
            ValidateCheckpoint(state);
            return new MortarIndicatorClock
            {
                _hasBegun = state.HasBegun, _hasBlinkStarted = state.HasBlinkStarted,
                _skipReactivationFrame = state.SkipReactivationFrame, IsVisible = state.Visible,
                IsShrinking = state.Shrinking, IsBlinking = state.Blinking,
                RotationFactor = state.RotationFactor, ShrinkFactor = state.ShrinkFactor,
                BlinkFactor = state.BlinkFactor, Scale = state.Scale, Alpha = state.Alpha,
                _shrinkSpeed = state.ShrinkSpeed, _blinkSpeed = state.BlinkSpeed,
                _blinkBoundaryCount = state.BlinkBoundaryCount
            };
        }

        private static void ValidateCheckpoint(BattleMortarWarningClockState state)
        {
            if (state == null || !UnitFactor(state.RotationFactor) || !UnitFactor(state.ShrinkFactor) ||
                !UnitFactor(state.BlinkFactor) || !Finite(state.Scale) || !Finite(state.Alpha) ||
                state.Scale < 0.65f - CheckpointTolerance || state.Scale > 1.5f + CheckpointTolerance ||
                state.Alpha < -CheckpointTolerance || state.Alpha > 0.35f + CheckpointTolerance ||
                !Finite(state.ShrinkSpeed) || state.ShrinkSpeed < 0f || state.ShrinkSpeed > MaximumShrinkSpeed ||
                !Finite(state.BlinkSpeed) || state.BlinkBoundaryCount < 0 ||
                state.BlinkBoundaryCount > BlinkBoundaryLimit + 1 ||
                state.Shrinking && (!state.HasBegun || state.ShrinkSpeed == 0f || state.Blinking) ||
                state.Blinking && (!state.HasBegun || !state.HasBlinkStarted ||
                    state.BlinkBoundaryCount < 1 || state.BlinkBoundaryCount > BlinkBoundaryLimit) ||
                state.HasBlinkStarted && (Math.Abs(state.BlinkSpeed) != 1f / BlinkSeconds ||
                    state.BlinkBoundaryCount < 1) ||
                !state.HasBlinkStarted && (state.BlinkSpeed != 0f || state.BlinkBoundaryCount != 0) ||
                state.Blinking && (state.ShrinkFactor != 1f ||
                    Math.Abs(state.Scale - MortarIndicatorTween.SampleScale(1f)) > CheckpointTolerance ||
                    Math.Abs(state.Alpha - MortarIndicatorTween.SampleAlpha(state.BlinkFactor)) > CheckpointTolerance) ||
                state.Shrinking && state.ShrinkFactor > 0f &&
                    Math.Abs(state.Scale - MortarIndicatorTween.SampleScale(state.ShrinkFactor)) > CheckpointTolerance ||
                !state.HasBegun && !IsInitialCheckpoint(state))
            {
                throw new InvalidOperationException("Malformed source Mortar warning clock checkpoint.");
            }
        }

        private static bool UnitFactor(float factor)
        {
            return Finite(factor) && factor >= 0f && factor <= 1f;
        }

        private static bool IsInitialCheckpoint(BattleMortarWarningClockState state)
        {
            return !state.HasBlinkStarted && !state.SkipReactivationFrame && !state.Visible &&
                !state.Shrinking && !state.Blinking && state.RotationFactor == 0f && state.ShrinkFactor == 0f &&
                state.BlinkFactor == 0f && state.Scale == 1f && state.Alpha == 0f && state.ShrinkSpeed == 0f;
        }
    }
}

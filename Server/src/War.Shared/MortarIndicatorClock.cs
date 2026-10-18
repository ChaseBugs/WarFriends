using System;

namespace War.Shared
{
    /// <summary>Replays recovered warning updates while preserving stored-float boundaries and source reuse.</summary>
    public sealed partial class MortarIndicatorClock
    {
        private const float MaximumStopSeconds = 1800f;
        private const float ShrinkLeadSeconds = 0.3f;
        private const float RotationSeconds = 2f;
        private const float BlinkSeconds = 0.1f;
        private const int BlinkBoundaryLimit = 5;
        private bool _hasBegun;
        private bool _hasBlinkStarted;
        private bool _skipReactivationFrame;
        private float _shrinkSpeed;
        private float _blinkSpeed;
        private int _blinkBoundaryCount;

        /// <summary>Gets whether the source warning remains active, independently of projectile membership.</summary>
        public bool IsVisible { get; private set; }

        /// <summary>Gets whether the source shrink tween still owns its completion callback.</summary>
        public bool IsShrinking { get; private set; }

        /// <summary>Gets whether the source color tween is blinking.</summary>
        public bool IsBlinking { get; private set; }

        /// <summary>Gets the normalized rotation factor retained by the original loop.</summary>
        public float RotationFactor { get; private set; }

        /// <summary>Gets the normalized shrink factor, including the source's immediate-duration zero state.</summary>
        public float ShrinkFactor { get; private set; }

        /// <summary>Gets the current forward or reverse blink factor.</summary>
        public float BlinkFactor { get; private set; }

        /// <summary>Gets the source uniform scale; restarting a positive shrink does not immediately sample zero.</summary>
        public float Scale { get; private set; } = 1f;

        /// <summary>Gets the source sprite alpha.</summary>
        public float Alpha { get; private set; }

        /// <summary>Matches OnInstancied hiding the old warning while retaining the cached tween startup history.</summary>
        public void HideForReuse()
        {
            IsVisible = false;
        }

        /// <summary>Starts or replaces the weapon's warning without allocating a second indicator.</summary>
        public void BeginShot(float stopSeconds)
        {
            if (!Finite(stopSeconds) || stopSeconds <= 0f || stopSeconds > MaximumStopSeconds)
            {
                throw new ArgumentOutOfRangeException(nameof(stopSeconds));
            }
            // Re-enabling an already-started inactive GameObject misses this frame's normal Update list.
            _skipReactivationFrame = _hasBegun && !IsVisible;
            _hasBegun = true;
            IsVisible = true;
            RotationFactor = 0f;
            ShrinkFactor = 0f;
            BlinkFactor = 0f;
            IsBlinking = false;
            Alpha = MortarIndicatorTween.SampleAlpha(0f);
            float duration = stopSeconds - ShrinkLeadSeconds;
            IsShrinking = duration > 0f;
            _shrinkSpeed = IsShrinking ? 1f / duration : 0f;
            if (!IsShrinking)
            {
                // TweenScale.Begin samples immediately before Mortar attaches onFinished; no blink is issued.
                Scale = MortarIndicatorTween.SampleScale(1f);
            }
        }

        /// <summary>Applies one observed frame delta; zero time is allowed when gameplay time is paused.</summary>
        public void Advance(float deltaSeconds)
        {
            if (!Finite(deltaSeconds) || deltaSeconds < 0f || deltaSeconds > 1f)
            {
                throw new ArgumentOutOfRangeException(nameof(deltaSeconds));
            }
            if (!IsVisible)
            {
                return;
            }
            if (_skipReactivationFrame)
            {
                _skipReactivationFrame = false;
                return;
            }
            RotationFactor += 1f / RotationSeconds * deltaSeconds;
            if (RotationFactor > 1f)
            {
                RotationFactor -= (float)Math.Floor(RotationFactor);
            }
            bool advanceBlink = IsBlinking;
            if (IsShrinking)
            {
                advanceBlink = AdvanceShrink(deltaSeconds);
            }
            if (advanceBlink)
            {
                AdvanceBlink(deltaSeconds);
            }
        }

        private bool AdvanceShrink(float deltaSeconds)
        {
            ShrinkFactor += _shrinkSpeed * deltaSeconds;
            bool completed = ShrinkFactor > 1f;
            if (completed)
            {
                ShrinkFactor = 1f;
                IsShrinking = false;
            }
            Scale = MortarIndicatorTween.SampleScale(ShrinkFactor);
            if (!completed)
            {
                return false;
            }
            IsBlinking = true;
            BlinkFactor = 0f;
            _blinkSpeed = 1f / BlinkSeconds;
            _blinkBoundaryCount = 1;
            bool firstActivation = !_hasBlinkStarted;
            _hasBlinkStarted = true;
            // The first enabled color component runs Start.Update immediately; later enables wait one frame.
            return firstActivation;
        }

        private void AdvanceBlink(float deltaSeconds)
        {
            BlinkFactor += _blinkSpeed * deltaSeconds;
            if (BlinkFactor > 1f)
            {
                if (CompleteBlinkBoundary())
                {
                    return;
                }
                BlinkFactor = 1f - (BlinkFactor - (float)Math.Floor(BlinkFactor));
                _blinkSpeed = -_blinkSpeed;
            }
            else if (BlinkFactor < 0f)
            {
                if (CompleteBlinkBoundary())
                {
                    return;
                }
                BlinkFactor = -BlinkFactor;
                BlinkFactor -= (float)Math.Floor(BlinkFactor);
                _blinkSpeed = -_blinkSpeed;
            }
            Alpha = MortarIndicatorTween.SampleAlpha(BlinkFactor);
        }

        private bool CompleteBlinkBoundary()
        {
            _blinkBoundaryCount++;
            if (_blinkBoundaryCount <= BlinkBoundaryLimit)
            {
                return false;
            }
            BlinkFactor = Math.Max(0f, Math.Min(1f, BlinkFactor));
            Alpha = MortarIndicatorTween.SampleAlpha(BlinkFactor);
            IsBlinking = false;
            IsVisible = false;
            return true;
        }

        private static bool Finite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}

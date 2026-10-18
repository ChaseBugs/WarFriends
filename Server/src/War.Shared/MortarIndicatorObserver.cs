using System;

namespace War.Shared
{
    /// <summary>Retains one observer's source warning history across ownership changes of a reused weapon.</summary>
    public sealed class MortarIndicatorObserver
    {
        private const int FirstFraction = 1;
        private const int LastFraction = 2;
        private readonly int _localFraction;
        private readonly MortarIndicatorClock _clock = new MortarIndicatorClock();
        private int _ownerFraction;

        /// <summary>Gets whether the observer currently sees the warning.</summary>
        public bool IsVisible => _clock.IsVisible;

        /// <summary>Gets whether the source shrink component remains enabled, including while hidden.</summary>
        public bool IsShrinking => _clock.IsShrinking;

        /// <summary>Gets whether the source blink component remains enabled, including while hidden.</summary>
        public bool IsBlinking => _clock.IsBlinking;

        /// <summary>Gets the source loop's retained rotation factor.</summary>
        public float RotationFactor => _clock.RotationFactor;

        /// <summary>Gets the source shrink factor.</summary>
        public float ShrinkFactor => _clock.ShrinkFactor;

        /// <summary>Gets the source blink factor.</summary>
        public float BlinkFactor => _clock.BlinkFactor;

        /// <summary>Gets the source uniform scale.</summary>
        public float Scale => _clock.Scale;

        /// <summary>Gets the source sprite alpha.</summary>
        public float Alpha => _clock.Alpha;

        /// <summary>Creates an independent history for one admitted local fraction.</summary>
        public MortarIndicatorObserver(int localFraction)
        {
            ValidateFraction(localFraction);
            _localFraction = localFraction;
        }

        /// <summary>Applies OnInstancied for a newly bound owner without resetting old tween startup state.</summary>
        public void AssignOwner(int ownerFraction)
        {
            ValidateFraction(ownerFraction);
            _ownerFraction = ownerFraction;
            _clock.HideForReuse();
        }

        /// <summary>Starts only opposing shots; allied calls preserve the source's early return.</summary>
        public void BeginShot(float stopSeconds)
        {
            if (_ownerFraction == 0)
            {
                throw new InvalidOperationException("Bind the source weapon owner before observing a shot.");
            }
            if (_ownerFraction != _localFraction)
            {
                _clock.BeginShot(stopSeconds);
            }
        }

        /// <summary>Advances this observer's existing warning without consulting another observer's state.</summary>
        public void Advance(float deltaSeconds)
        {
            _clock.Advance(deltaSeconds);
        }

        private static void ValidateFraction(int fraction)
        {
            if (fraction < FirstFraction || fraction > LastFraction)
            {
                throw new ArgumentOutOfRangeException(nameof(fraction));
            }
        }
    }
}

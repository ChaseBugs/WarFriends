using System;

namespace War.Shared
{
    /// <summary>Samples the recovered Mortar warning tweens without starting Unity gameplay components.</summary>
    public static class MortarIndicatorTween
    {
        private const float StartScale = 1.5f;
        private const float EndScale = 0.65f;
        private const float InitialAlpha = 0.35f;
        private const float FullRotationDegrees = 360f;
        private const float FullTurnRadians = (float)Math.PI * 2f;

        /// <summary>Samples the source's linear rotation before composing its 90-degree base rotation.</summary>
        public static float SampleRotationDegrees(float factor)
        {
            ValidateFactor(factor);
            return FullRotationDegrees * factor;
        }

        /// <summary>Samples the source EaseInOut shrink from 1.5 to 0.65.</summary>
        public static float SampleScale(float factor)
        {
            float eased = EaseInOut(factor);
            return StartScale * (1f - eased) + EndScale * eased;
        }

        /// <summary>Samples one forward blink lane; the source PingPong lifecycle reverses its factor.</summary>
        public static float SampleAlpha(float factor)
        {
            return InitialAlpha * (1f - EaseInOut(factor));
        }

        private static float EaseInOut(float factor)
        {
            ValidateFactor(factor);
            // UITweener uses this sine correction, not cosine interpolation or SmoothStep.
            return factor - (float)Math.Sin(factor * FullTurnRadians) / FullTurnRadians;
        }

        private static void ValidateFactor(float factor)
        {
            if (float.IsNaN(factor) || float.IsInfinity(factor) || factor < 0f || factor > 1f)
            {
                throw new ArgumentOutOfRangeException(nameof(factor));
            }
        }
    }
}

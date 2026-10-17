using War.Protocol;

namespace War.Client
{
    /// <summary>Contains an immutable reviewed source clip sample, excluding generated queue-state names.</summary>
    public sealed class InfantryAnimationClipView
    {
        /// <summary>Gets the original source clip identity.</summary>
        public string ClipName { get; }

        /// <summary>Gets the confirmed source sample time.</summary>
        public float TimeSeconds { get; }

        /// <summary>Gets the unit-interval base-layer weight.</summary>
        public float Weight { get; }

        /// <summary>Gets the reviewed source wrapping behavior.</summary>
        public BattleInfantryAnimationWrap Wrap { get; }

        internal InfantryAnimationClipView(BattleInfantryAnimationClip source)
        {
            ClipName = source.ClipName;
            TimeSeconds = source.TimeSeconds;
            Weight = source.Weight;
            Wrap = source.Wrap;
        }
    }
}

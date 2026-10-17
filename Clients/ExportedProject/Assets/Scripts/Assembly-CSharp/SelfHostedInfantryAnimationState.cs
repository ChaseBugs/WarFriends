using System;
using UnityEngine;

/// <summary>Describes one confirmed base-layer clip sample without local playback or gameplay authority.</summary>
public sealed class SelfHostedInfantryAnimationState
{
    /// <summary>Gets the reviewed source clip identity, excluding generated queue names.</summary>
    public string ClipName { get; private set; }

    /// <summary>Gets the confirmed time to sample without local advancement.</summary>
    public float TimeSeconds { get; private set; }

    /// <summary>Gets the base-layer blending weight.</summary>
    public float Weight { get; private set; }

    /// <summary>Gets the recovered clip wrapping behavior.</summary>
    public WrapMode WrapMode { get; private set; }

    /// <summary>Rejects invalid scalars before a sample can replace the current visual pose.</summary>
    public SelfHostedInfantryAnimationState(string clipName, float timeSeconds, float weight, WrapMode wrapMode)
    {
        if (string.IsNullOrEmpty(clipName) || clipName.EndsWith(" - Queued Clone", StringComparison.Ordinal))
        {
            throw new ArgumentException("A source clip identity is required, not a generated queue-state name.");
        }
        if (float.IsNaN(timeSeconds) || float.IsInfinity(timeSeconds) || timeSeconds < 0f ||
            float.IsNaN(weight) || float.IsInfinity(weight) || weight < 0f || weight > 1f)
        {
            throw new ArgumentOutOfRangeException("timeSeconds",
                "Finite nonnegative time and a unit weight are required.");
        }
        if (!Enum.IsDefined(typeof(WrapMode), wrapMode))
        {
            throw new ArgumentOutOfRangeException("wrapMode");
        }

        ClipName = clipName;
        TimeSeconds = timeSeconds;
        Weight = weight;
        WrapMode = wrapMode;
    }
}

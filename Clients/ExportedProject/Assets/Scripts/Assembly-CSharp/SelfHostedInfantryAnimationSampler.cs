using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Samples reviewed source clips on a script-free rig without advancing local animation time.</summary>
public sealed class SelfHostedInfantryAnimationSampler
{
    private static readonly string[] SupportedClips =
    {
        "run_0", "idle", "idle_1", "stand_up_crawl", "stand_up_begin", "rifle_shot_loop",
        "player_look_right3", "player_fire_right3", "player_right_coverBack3",
        "player_look_left3", "player_fire_left3", "player_left_coverBack3"
    };

    private readonly Dictionary<string, AnimationClip> _clips = new Dictionary<string, AnimationClip>();
    private readonly Animation _animation;

    /// <summary>Creates a disabled mixer and preserves exact source clip bindings rather than renamed copies.</summary>
    public SelfHostedInfantryAnimationSampler(GameObject animationRoot, Animation source)
    {
        if (animationRoot == null || source == null || animationRoot.GetComponent<Animation>() != null)
        {
            throw new ArgumentException("An unbound visual animation root and recovered source are required.");
        }

        foreach (string name in SupportedClips)
        {
            AnimationClip clip = source.GetClip(name);
            if (clip != null && clip.name == name)
            {
                _clips.Add(name, clip);
            }
        }

        _animation = animationRoot.AddComponent<Animation>();
        _animation.enabled = false;
        _animation.playAutomatically = false;
        _animation.wrapMode = source.wrapMode;
        foreach (KeyValuePair<string, AnimationClip> entry in _clips)
        {
            _animation.AddClip(entry.Value, entry.Key);
            if (_animation[entry.Key].clip != entry.Value)
            {
                throw new InvalidOperationException("The original source animation binding was not preserved.");
            }
        }
    }

    /// <summary>Validates the complete base-layer frame before changing any active mixer state.</summary>
    public void Sample(IReadOnlyList<SelfHostedInfantryAnimationState> states)
    {
        SelfHostedInfantryAnimationState[] frame = ValidateAndCopyFrame(states);
        _animation.Stop();
        foreach (SelfHostedInfantryAnimationState sample in frame)
        {
            AnimationState state = _animation[sample.ClipName];
            state.wrapMode = sample.WrapMode;
            state.blendMode = AnimationBlendMode.Blend;
            state.layer = 0;
            state.time = sample.TimeSeconds;
            state.speed = 0f;
            state.weight = sample.Weight;
            state.enabled = true;
        }

        _animation.Sample();
    }

    private SelfHostedInfantryAnimationState[] ValidateAndCopyFrame(
        IReadOnlyList<SelfHostedInfantryAnimationState> states)
    {
        if (states == null || states.Count == 0 || states.Count > _clips.Count)
        {
            throw new ArgumentException("A nonempty frame of available source clips is required.");
        }

        var names = new HashSet<string>();
        var frame = new SelfHostedInfantryAnimationState[states.Count];
        bool hasWeightedState = false;
        for (int index = 0; index < frame.Length; index++)
        {
            SelfHostedInfantryAnimationState state = states[index];
            if (state == null || !_clips.ContainsKey(state.ClipName) || !names.Add(state.ClipName))
            {
                throw new ArgumentException("Every frame needs unique reviewed source clip identities.");
            }

            hasWeightedState |= state.Weight > 0f;
            frame[index] = state;
        }
        if (!hasWeightedState)
        {
            throw new ArgumentException("An all-zero frame must not invent a default source pose.");
        }

        return frame;
    }
}

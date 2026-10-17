using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Measures whether a separate legacy Animation can reconstruct an observed mixer frame.</summary>
public sealed class UnityCoopRigReplayProbe
{
    /// <summary>Separates native queues, original-name ordinary states and the historical renamed-alias control.</summary>
    public enum QueueReplayMode
    {
        NativeQueue,
        OrdinaryBaseName,
        OrdinaryQueuedAlias
    }

    private const string QueuedSuffix = " - Queued Clone";
    private readonly Animation _animation;
    private readonly Transform[] _sourceTransforms;
    private readonly Transform[] _replayTransforms;
    private readonly QueueReplayMode _queueMode;
    private bool _clipIdentitiesMatch;
    private readonly SelfHostedInfantryAnimationSampler _runtimeSampler;

    /// <summary>Clones only the already stripped observation rig and disables autonomous animation.</summary>
    public UnityCoopRigReplayProbe(Transform source, QueueReplayMode queueMode = QueueReplayMode.NativeQueue)
    {
        _queueMode = queueMode;
        GameObject replay = UnityEngine.Object.Instantiate(source.gameObject);
        replay.SetActive(false);
        replay.name = "IndependentMixerReplay";
        if (replay.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new InvalidOperationException("The replay rig must contain no gameplay scripts.");
        }

        Animation copiedAnimation = replay.GetComponentInChildren<Animation>(true);
        GameObject animationRoot = copiedAnimation.gameObject;
        WrapMode wrapMode = copiedAnimation.wrapMode;
        UnityEngine.Object.DestroyImmediate(copiedAnimation);
        // A fresh mixer must not inherit the source's native queue or transition cache through Instantiate.
        if (queueMode == QueueReplayMode.OrdinaryBaseName)
        {
            _runtimeSampler = new SelfHostedInfantryAnimationSampler(animationRoot,
                source.GetComponentInChildren<Animation>(true));
            _animation = animationRoot.GetComponent<Animation>();
        }
        else
        {
            _animation = animationRoot.AddComponent<Animation>();
        }
        _animation.wrapMode = wrapMode;
        _animation.playAutomatically = false;
        _animation.enabled = false;
        _sourceTransforms = source.GetComponentsInChildren<Transform>(true);
        _replayTransforms = replay.GetComponentsInChildren<Transform>(true);
        if (_sourceTransforms.Length != _replayTransforms.Length)
        {
            throw new InvalidOperationException("The independent replay hierarchy changed.");
        }
    }

    /// <summary>Copies mixer scalars, samples the independent rig and reports local transform errors.</summary>
    public object Compare(Animation source)
    {
        if (_runtimeSampler != null)
        {
            return CompareRuntimeSampler(source);
        }

        var observedStates = new List<AnimationState>();
        var replayStates = new List<AnimationState>();
        _clipIdentitiesMatch = true;
        _animation.Stop();
        foreach (AnimationState state in source)
        {
            if (state.enabled)
            {
                observedStates.Add(state);
                replayStates.Add(CreateReplayState(state));
            }
        }

        for (int index = 0; index < observedStates.Count; index++)
        {
            ApplyState(replayStates[index], observedStates[index]);
            _clipIdentitiesMatch &= replayStates[index].clip == observedStates[index].clip;
        }

        _animation.Sample();
        return MeasurePose();
    }

    private object CompareRuntimeSampler(Animation source)
    {
        var states = new List<SelfHostedInfantryAnimationState>();
        _clipIdentitiesMatch = true;
        foreach (AnimationState state in source)
        {
            if (!state.enabled)
            {
                continue;
            }
            if (state.layer != 0 || state.blendMode != AnimationBlendMode.Blend)
            {
                throw new InvalidOperationException("The reviewed runtime sampler supports base-layer blending only.");
            }

            states.Add(new SelfHostedInfantryAnimationState(state.clip.name, state.time, state.weight, state.wrapMode));
            AnimationState replayState = _animation[state.clip.name];
            _clipIdentitiesMatch &= replayState != null && replayState.clip == state.clip;
        }

        _runtimeSampler.Sample(states);
        return MeasurePose();
    }

    private object MeasurePose()
    {
        float positionError = 0f;
        float rotationError = 0f;
        float relativeScaleError = 0f;
        string greatestPositionErrorTransform = string.Empty;
        string greatestRotationErrorTransform = string.Empty;
        Quaternion sourceRotation = Quaternion.identity;
        Quaternion replayRotation = Quaternion.identity;
        for (int index = 0; index < _sourceTransforms.Length; index++)
        {
            Transform original = _sourceTransforms[index];
            Transform replay = _replayTransforms[index];
            float distance = Vector3.Distance(original.localPosition, replay.localPosition);
            if (distance > positionError)
            {
                positionError = distance;
                greatestPositionErrorTransform = original.name;
            }
            float rotationDifference = RotationDifference(original.localRotation, replay.localRotation);
            if (rotationDifference > rotationError)
            {
                rotationError = rotationDifference;
                greatestRotationErrorTransform = original.name;
                sourceRotation = original.localRotation;
                replayRotation = replay.localRotation;
            }
            relativeScaleError = Mathf.Max(relativeScaleError,
                Vector3.Distance(original.localScale, replay.localScale) / Mathf.Max(1f, original.localScale.magnitude));
        }

        return new
        {
            positionError, rotationError, relativeScaleError, greatestPositionErrorTransform,
            greatestRotationErrorTransform,
            clipIdentitiesMatch = _clipIdentitiesMatch,
            sourceRotation = Coordinates(sourceRotation),
            replayRotation = Coordinates(replayRotation),
            transforms = _sourceTransforms.Length
        };
    }

    private static float[] Coordinates(Quaternion rotation)
    {
        return new[] { rotation.x, rotation.y, rotation.z, rotation.w };
    }

    /// <summary>Diagnoses the final observation using the source's own manual sampler, then restores its pose.</summary>
    public object CompareAfterSourceSample(Animation source)
    {
        var positions = new Vector3[_sourceTransforms.Length];
        var rotations = new Quaternion[_sourceTransforms.Length];
        var scales = new Vector3[_sourceTransforms.Length];
        for (int index = 0; index < _sourceTransforms.Length; index++)
        {
            positions[index] = _sourceTransforms[index].localPosition;
            rotations[index] = _sourceTransforms[index].localRotation;
            scales[index] = _sourceTransforms[index].localScale;
        }

        try
        {
            source.Sample();
            return Compare(source);
        }
        finally
        {
            for (int index = 0; index < _sourceTransforms.Length; index++)
            {
                _sourceTransforms[index].localPosition = positions[index];
                _sourceTransforms[index].localRotation = rotations[index];
                _sourceTransforms[index].localScale = scales[index];
            }
        }
    }

    private static float RotationDifference(Quaternion first, Quaternion second)
    {
        double dot = (double)first.x * second.x + (double)first.y * second.y +
            (double)first.z * second.z + (double)first.w * second.w;
        double firstNorm = (double)first.x * first.x + (double)first.y * first.y +
            (double)first.z * first.z + (double)first.w * first.w;
        double secondNorm = (double)second.x * second.x + (double)second.y * second.y +
            (double)second.z * second.z + (double)second.w * second.w;
        return (float)Math.Max(0d, 1d - Math.Abs(dot) / Math.Sqrt(firstNorm * secondNorm));
    }

    private AnimationState CreateReplayState(AnimationState observed)
    {
        AnimationClip clip = observed.clip;
        if (clip == null)
        {
            throw new InvalidOperationException("The observed mixer state has no clip.");
        }
        bool isQueued = observed.name.EndsWith(QueuedSuffix, StringComparison.Ordinal);
        string name = observed.name;
        if (isQueued && _queueMode != QueueReplayMode.OrdinaryQueuedAlias)
        {
            name = name.Substring(0, name.Length - QueuedSuffix.Length);
        }

        AnimationState target = _animation[name];
        if (target == null || target.clip != clip)
        {
            if (target != null)
            {
                _animation.RemoveClip(name);
            }

            _animation.AddClip(clip, name);
            target = _animation[name];
        }

        if (isQueued && _queueMode == QueueReplayMode.NativeQueue)
        {
            // A native queued state is not equivalent to an ordinary state given a queued-looking name.
            return _animation.PlayQueued(name, QueueMode.PlayNow, PlayMode.StopSameLayer);
        }

        return target;
    }

    private static void ApplyState(AnimationState target, AnimationState observed)
    {
        target.wrapMode = observed.wrapMode;
        target.blendMode = observed.blendMode;
        target.layer = observed.layer;
        target.time = observed.time;
        target.speed = observed.speed;
        target.weight = observed.weight;
        target.enabled = true;
    }
}

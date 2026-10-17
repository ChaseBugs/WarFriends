using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Measures whether a separate legacy Animation can reconstruct an observed mixer frame.</summary>
public sealed class UnityCoopRigReplayProbe
{
    private const string QueuedSuffix = " - Queued Clone";
    private readonly Animation _animation;
    private readonly Transform[] _sourceTransforms;
    private readonly Transform[] _replayTransforms;

    /// <summary>Clones only the already stripped observation rig and disables autonomous animation.</summary>
    public UnityCoopRigReplayProbe(Transform source)
    {
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
        _animation = animationRoot.AddComponent<Animation>();
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
        var activeNames = new HashSet<string>();
        foreach (AnimationState state in source)
        {
            if (state.enabled)
            {
                activeNames.Add(state.name);
            }
        }

        foreach (AnimationState state in _animation)
        {
            if (!activeNames.Contains(state.name))
            {
                state.enabled = false;
            }
        }

        foreach (AnimationState state in source)
        {
            if (state.enabled)
            {
                ApplyState(source, state);
            }
        }

        _animation.Sample();
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

    private void ApplyState(Animation source, AnimationState observed)
    {
        AnimationState target = _animation[observed.name];
        if (target == null)
        {
            string clipName = observed.name;
            if (clipName.EndsWith(QueuedSuffix, StringComparison.Ordinal))
            {
                clipName = clipName.Substring(0, clipName.Length - QueuedSuffix.Length);
            }

            AnimationClip clip = source.GetClip(clipName);
            if (clip == null)
            {
                throw new InvalidOperationException("Missing source replay clip: " + clipName);
            }

            _animation.AddClip(clip, observed.name);
            target = _animation[observed.name];
        }

        target.wrapMode = observed.wrapMode;
        target.blendMode = observed.blendMode;
        target.layer = observed.layer;
        target.time = observed.time;
        target.speed = observed.speed;
        target.weight = observed.weight;
        target.enabled = true;
    }
}

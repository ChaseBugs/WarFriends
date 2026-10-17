using System;
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

        _animation = replay.GetComponentInChildren<Animation>(true);
        _animation.Stop();
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
        foreach (AnimationState state in _animation)
        {
            state.enabled = false;
        }

        foreach (AnimationState state in source)
        {
            if (state.enabled)
            {
                ApplyState(source, state);
            }
        }

        _animation.Sample();
        float positionError = 0f;
        float rotationError = 0f;
        float relativeScaleError = 0f;
        string greatestPositionErrorTransform = string.Empty;
        string greatestRotationErrorTransform = string.Empty;
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
            }
            relativeScaleError = Mathf.Max(relativeScaleError,
                Vector3.Distance(original.localScale, replay.localScale) / Mathf.Max(1f, original.localScale.magnitude));
        }

        return new
        {
            positionError, rotationError, relativeScaleError, greatestPositionErrorTransform,
            greatestRotationErrorTransform,
            transforms = _sourceTransforms.Length
        };
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
        target.speed = 0f;
        target.weight = observed.weight;
        target.enabled = true;
    }
}

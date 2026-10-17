using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Compares observed gameplay-phase obstacle poses with an independent production sampler.</summary>
public sealed class UnityCoopObstacleRigReplayProbe
{
    private readonly Dictionary<Transform, Transform> _copies = new Dictionary<Transform, Transform>();
    private readonly SelfHostedInfantryAnimationSampler _sampler;

    /// <summary>Copies transforms without cloning the active source controller or any physics components.</summary>
    public UnityCoopObstacleRigReplayProbe(Transform root, Animation source)
    {
        var replay = new GameObject("InactiveObstacleGameplayReplay");
        replay.SetActive(false);
        replay.transform.localPosition = root.localPosition;
        replay.transform.localRotation = root.localRotation;
        SelfHostedVisualHierarchy.CopyRoot(root, replay.transform, _copies);
        _sampler = new SelfHostedInfantryAnimationSampler(_copies[source.transform].gameObject, source);
    }

    /// <summary>Samples only the observed enabled states and reports whole-hierarchy error without changing source.</summary>
    public object Compare(Animation source)
    {
        var states = new List<SelfHostedInfantryAnimationState>();
        float totalWeight = 0f;
        foreach (AnimationState state in source)
        {
            if (state.enabled)
            {
                states.Add(new SelfHostedInfantryAnimationState(state.clip.name, state.time, state.weight,
                    state.wrapMode));
                totalWeight += state.weight;
            }
        }
        _sampler.Sample(states);
        return MeasurePose(totalWeight);
    }

    private object MeasurePose(float totalWeight)
    {
        float maximumPositionError = 0f;
        float maximumRotationError = 0f;
        float maximumScaleError = 0f;
        string greatestPositionTransform = "";
        string greatestScaleTransform = "";
        foreach (KeyValuePair<Transform, Transform> pair in _copies)
        {
            float positionError = Vector3.Distance(pair.Key.localPosition, pair.Value.localPosition);
            if (positionError > maximumPositionError)
            {
                maximumPositionError = positionError;
                greatestPositionTransform = pair.Key.name;
            }
            float rotationError = 1f - Mathf.Abs(Quaternion.Dot(pair.Key.localRotation.normalized,
                pair.Value.localRotation.normalized));
            maximumRotationError = Mathf.Max(maximumRotationError, rotationError);
            float scaleError = RelativeScaleError(pair.Key.localScale, pair.Value.localScale);
            if (scaleError > maximumScaleError)
            {
                maximumScaleError = scaleError;
                greatestScaleTransform = pair.Key.name;
            }
        }
        return new
        {
            transforms = _copies.Count,
            totalWeight,
            maximumPositionError,
            maximumRotationError,
            maximumScaleError,
            greatestPositionTransform,
            greatestScaleTransform
        };
    }
    private static float RelativeScaleError(Vector3 source, Vector3 replay)
    {
        const float minimumScale = 0.000000000001f;
        float error = 0f;
        for (int axis = 0; axis < 3; axis++)
        {
            error = Mathf.Max(error, Mathf.Abs(source[axis] - replay[axis]) /
                Mathf.Max(Mathf.Abs(source[axis]), minimumScale));
        }
        return error;
    }

}

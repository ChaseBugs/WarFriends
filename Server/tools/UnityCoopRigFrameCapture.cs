using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Records observed rig transforms and mixer state without sampling or advancing animation.</summary>
public static class UnityCoopRigFrameCapture
{
    /// <summary>Captures the displayed local hierarchy independently of gameplay muzzle observations.</summary>
    public static object Capture(Transform root, Animation animation)
    {
        if (root == null || animation == null)
        {
            throw new ArgumentException("A source root and Animation are required.");
        }

        var transforms = new List<object>();
        CaptureTransform(root, "root", transforms);

        var states = new List<object>();
        foreach (AnimationState state in animation)
        {
            if (!state.enabled)
            {
                continue;
            }

            states.Add(new
            {
                name = state.name,
                clipName = state.clip.name,
                clipInstanceId = state.clip.GetInstanceID(),
                clipLength = state.clip.length,
                time = state.time,
                normalizedTime = state.normalizedTime,
                weight = state.weight,
                speed = state.speed,
                layer = state.layer,
                wrapMode = state.wrapMode.ToString(),
                blendMode = state.blendMode.ToString()
            });
        }

        return new { transforms, states };
    }

    private static void CaptureTransform(Transform transform, string path, List<object> rows)
    {
        Vector3 position = transform.localPosition;
        Quaternion rotation = transform.localRotation;
        Vector3 scale = transform.localScale;
        rows.Add(new
        {
            path,
            name = transform.name,
            position = new[] { position.x, position.y, position.z },
            rotation = new[] { rotation.x, rotation.y, rotation.z, rotation.w },
            scale = new[] { scale.x, scale.y, scale.z }
        });

        // Sibling indices keep duplicate source bone names unambiguous across captured frames.
        for (int index = 0; index < transform.childCount; index++)
        {
            CaptureTransform(transform.GetChild(index), path + "/" + index, rows);
        }
    }
}

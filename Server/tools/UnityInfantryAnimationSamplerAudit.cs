using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>Checks runtime sampler input rejection and pose preservation against recovered source geometry.</summary>
public static class UnityInfantryAnimationSamplerAudit
{
    private const string WalkingClip = "run_0";
    private static int _checks;

    /// <summary>Runs in a disposable Editor project without enabling gameplay or modifying source assets.</summary>
    public static void Run()
    {
        GameObject root = null;
        try
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
            Animation source = prefab.GetComponentInChildren<Animation>(true);
            root = new GameObject("RuntimeSamplerAudit");
            root.SetActive(false);
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
            GameObject animationRoot = copies[source.transform].gameObject;
            var sampler = new SelfHostedInfantryAnimationSampler(animationRoot, source);
            sampler.Sample(new[] { State(WalkingClip, 0.1f) });
            Animation playback = animationRoot.GetComponent<Animation>();
            Require(!playback.enabled && !playback.playAutomatically,
                "The runtime mixer must not advance on local time.");
            Require(playback[WalkingClip].clip == source.GetClip(WalkingClip),
                "The original source clip object must remain bound.");
            VerifyRejectedFrames(sampler, playback, root);
            sampler.Sample(new[] { State(WalkingClip, 0.2f) });
            Require(Mathf.Abs(playback[WalkingClip].time - 0.2f) < 0.00001f,
                "A later valid sample must still apply after rejected input.");
            File.WriteAllText("runtime-infantry-sampler-audit.json", "{\"checks\":" + _checks + "}");
            Debug.Log("PASS: " + _checks + " runtime infantry sampler checks.");
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (root != null)
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
        }
    }

    private static void VerifyRejectedFrames(SelfHostedInfantryAnimationSampler sampler, Animation playback,
        GameObject root)
    {
        var rejected = new Action[]
        {
            () => sampler.Sample(null),
            () => sampler.Sample(new SelfHostedInfantryAnimationState[0]),
            () => sampler.Sample(new[] { State(WalkingClip, 0.5f), State("unknown", 0.2f) }),
            () => sampler.Sample(new[] { State(WalkingClip, 0.5f), State(WalkingClip, 0.2f) }),
            () => sampler.Sample(new SelfHostedInfantryAnimationState[] { null }),
            () => sampler.Sample(new[] { new SelfHostedInfantryAnimationState(WalkingClip, 0.5f, 0f, WrapMode.Loop) }),
            () => State("run_0 - Queued Clone", 0.2f),
            () => State(WalkingClip, float.NaN),
            () => State(WalkingClip, float.PositiveInfinity),
            () => State(WalkingClip, -1f),
            () => new SelfHostedInfantryAnimationState(WalkingClip, 0f, float.NaN, WrapMode.Loop),
            () => new SelfHostedInfantryAnimationState(WalkingClip, 0f, -1f, WrapMode.Loop),
            () => new SelfHostedInfantryAnimationState(WalkingClip, 0f, 2f, WrapMode.Loop),
            () => new SelfHostedInfantryAnimationState(WalkingClip, 0f, 1f, (WrapMode)99)
        };
        Transform[] transforms = root.GetComponentsInChildren<Transform>(true);
        Quaternion[] rotations = transforms.Select(transform => transform.localRotation).ToArray();
        Vector3[] positions = transforms.Select(transform => transform.localPosition).ToArray();
        Vector3[] scales = transforms.Select(transform => transform.localScale).ToArray();
        foreach (Action action in rejected)
        {
            bool isRejected = false;
            try
            {
                action();
            }
            catch (ArgumentException)
            {
                isRejected = true;
            }

            Require(isRejected, "Malformed animation input must be rejected.");
            Require(playback[WalkingClip].enabled && playback[WalkingClip].time == 0.1f &&
                transforms.Select((transform, index) => transform.localRotation.Equals(rotations[index]) &&
                    transform.localPosition.Equals(positions[index]) && transform.localScale.Equals(scales[index]))
                    .All(equal => equal),
                "Rejected frames must preserve the last confirmed mixer state and bone pose.");
        }
    }

    private static SelfHostedInfantryAnimationState State(string clip, float seconds)
    {
        return new SelfHostedInfantryAnimationState(clip, seconds, 1f, WrapMode.Loop);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        _checks++;
    }
}

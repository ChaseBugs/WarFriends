using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks post-command zero-time fire poses separately from the preceding source observation.</summary>
[InitializeOnLoad]
public static class UnityCoopRoundResetAudit
{
    private const string Active = "WarFriends.CoopRoundResetAudit";
    private static int _checks;

    static UnityCoopRoundResetAudit()
    {
        if (SessionState.GetBool(Active, false))
        {
            EditorApplication.update += VerifyInPlayMode;
        }
    }

    /// <summary>Runs isolated source notification and runtime sampler comparisons without gameplay startup.</summary>
    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(Active, true);
        EditorApplication.isPlaying = true;
    }

    private static void VerifyInPlayMode()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }
        SessionState.SetBool(Active, false);
        EditorApplication.update -= VerifyInPlayMode;
        try
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
            VerifySide(prefab, true);
            VerifySide(prefab, false);
            File.WriteAllText("corner-round-reset-audit.json", "{\"checks\":" + _checks + "}");
            Debug.Log("PASS: " + _checks + " source post-command round-reset checks.");
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifySide(GameObject prefab, bool isRightSide)
    {
        GameObject sourceRoot = new GameObject("InactiveRoundResetSource");
        GameObject replayRoot = new GameObject("InactiveRoundResetReplay");
        sourceRoot.SetActive(false);
        replayRoot.SetActive(false);
        try
        {
            Animation definition = prefab.GetComponentInChildren<Animation>(true);
            var sourceCopies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(prefab.transform, sourceRoot.transform, sourceCopies);
            Animation source = sourceCopies[definition.transform].gameObject.AddComponent<Animation>();
            source.enabled = false;
            source.playAutomatically = false;
            foreach (AnimationState state in definition)
            {
                if (state.name == state.clip.name)
                {
                    source.AddClip(state.clip, state.name);
                }
            }
            var controller = new UnityCoopCornerVolleyProbe(source, isRightSide);
            var replayCopies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(sourceRoot.transform, replayRoot.transform, replayCopies);
            var sampler = new SelfHostedInfantryAnimationSampler(replayCopies[source.transform].gameObject, source);
            string fire = isRightSide ? "player_fire_right3" : "player_fire_left3";
            source.Stop();
            AnimationState queued = source.PlayQueued(fire, QueueMode.PlayNow);
            VerifyReset(source, controller, sampler, queued);
            source.Stop();
            source.Play(fire);
            VerifyReset(source, controller, sampler, source[fire]);
            if (isRightSide)
            {
                VerifyObstacle(source, controller, sampler);
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(sourceRoot);
            UnityEngine.Object.DestroyImmediate(replayRoot);
        }
    }

    private static void VerifyReset(Animation source, UnityCoopCornerVolleyProbe controller,
        SelfHostedInfantryAnimationSampler sampler, AnimationState before)
    {
        string fire = before.clip.name;
        before.wrapMode = WrapMode.ClampForever;
        before.time = 0.1f;
        source.Sample();
        controller.NotifyRound();
        Require(source[fire].enabled && source[fire].time == 0f,
            "Source notification must replace queued fire or restart ordinary fire at zero.");
        source.Sample();
        sampler.Sample(new[] { new SelfHostedInfantryAnimationState(fire, 0f, 1f, WrapMode.ClampForever) });
        Animation replay = FindReplayAnimation(source);
        CompareHierarchy(source.transform, replay.transform);
    }

    private static void VerifyObstacle(Animation source, UnityCoopCornerVolleyProbe controller,
        SelfHostedInfantryAnimationSampler sampler)
    {
        const string beginClip = "stand_up_begin";
        const string fireClip = "rifle_shot_loop";
        const string returnClip = "stand_up_crawl";
        const float seedSeconds = 0.1f;
        const float returnFraction = 0.25f;
        const float phaseTolerance = 0.00001f;

        source.Stop();
        source.Play(beginClip);
        source[beginClip].time = seedSeconds;
        controller.NotifyObstacleRound();
        Require(source[beginClip].enabled && source[beginClip].time == seedSeconds,
            "An obstacle notification must retain the playing preparation clock.");

        source.Stop();
        source.Play(returnClip);
        source[returnClip].normalizedTime = returnFraction;
        controller.NotifyObstacleRound();
        Require(Mathf.Abs(source[beginClip].normalizedTime - (1f - returnFraction)) < phaseTolerance,
            "Interrupted crawl must reverse into the remaining stand-up preparation.");

        source.Stop();
        AnimationState queued = source.PlayQueued(fireClip, QueueMode.PlayNow);
        VerifyObstacleReset(source, controller, sampler, queued);
        source.Stop();
        source.Play(fireClip);
        VerifyObstacleReset(source, controller, sampler, source[fireClip]);
    }

    private static void VerifyObstacleReset(Animation source, UnityCoopCornerVolleyProbe controller,
        SelfHostedInfantryAnimationSampler sampler, AnimationState before)
    {
        const string fireClip = "rifle_shot_loop";
        const float seedSeconds = 0.1f;
        before.wrapMode = WrapMode.ClampForever;
        before.time = seedSeconds;
        source.Sample();
        controller.NotifyObstacleRound();
        Require(source[fireClip].enabled && source[fireClip].time == 0f,
            "An obstacle notification must replace queued fire or restart ordinary fire at zero.");
        source.Sample();
        sampler.Sample(new[] { new SelfHostedInfantryAnimationState(fireClip, 0f, 1f, WrapMode.ClampForever) });
        CompareHierarchy(source.transform, FindReplayAnimation(source).transform);
    }

    private static Animation FindReplayAnimation(Animation source)
    {
        foreach (Animation animation in Resources.FindObjectsOfTypeAll<Animation>())
        {
            if (animation != source && animation.transform.root.name == "InactiveRoundResetReplay")
            {
                return animation;
            }
        }
        throw new InvalidOperationException("The runtime replay mixer is absent.");
    }

    private static void CompareHierarchy(Transform source, Transform replay)
    {
        Require(source.childCount == replay.childCount &&
            Vector3.Distance(source.localPosition, replay.localPosition) < 0.00001f &&
            Quaternion.Angle(source.localRotation, replay.localRotation) < 0.02f &&
            Vector3.Distance(source.localScale, replay.localScale) < 0.0001f,
            "The post-command sampled hierarchy must match the source zero-time evaluation.");
        for (int index = 0; index < source.childCount; index++)
        {
            CompareHierarchy(source.GetChild(index), replay.GetChild(index));
        }
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

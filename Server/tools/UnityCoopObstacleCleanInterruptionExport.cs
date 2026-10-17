using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes real crawl interruption methods at declared phases without normal AI or shot authority.</summary>
[InitializeOnLoad]
public static class UnityCoopObstacleCleanInterruptionExport
{
    private const string Active = "WarFriends.ObstacleCleanInterruptionExport";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string SourceEnemySha256 =
        "64b4db85d1c9a0bd46a690a86102a22f66feeab8d4157a4c87824ac3d5dbeb54";
    private const int CaptureRate = 30;
    private const int SampleCount = 13;
    private static readonly float[] ReturnFractions = { 0f, 0.25f, 0.5f, 0.75f, 1f, 2f };
    private static readonly List<object> Samples = new List<object>();
    private static Animation[] _animations;
    private static UnityCoopObstacleRigReplayProbe[] _replays;
    private static int _lastFrame = -1;
    private static int ManualFinalTick
    {
        get
        {
            string value = Environment.GetEnvironmentVariable("WAR_OBSTACLE_CLEAN_MANUAL_FINAL_TICK");
            if (string.IsNullOrEmpty(value) || value == "2")
            {
                return 2;
            }
            if (value == "1")
            {
                return 1;
            }
            throw new InvalidOperationException("The final manual diagnostic tick must be one or two.");
        }
    }
    private static bool SamplesSourceManually
    {
        get { return Environment.GetEnvironmentVariable("WAR_OBSTACLE_CLEAN_MANUAL_SAMPLE") == "1"; }
    }

    static UnityCoopObstacleCleanInterruptionExport()
    {
        if (SessionState.GetBool(Active, false))
        {
            EditorApplication.update += Observe;
        }
    }

    /// <summary>
    /// Starts empty-scene Play Mode to avoid recovered Editor Reset before private controller wiring.
    /// </summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_OBSTACLE_CLEAN_INTERRUPTION_OUTPUT")))
        {
            throw new InvalidOperationException("Set WAR_OBSTACLE_CLEAN_INTERRUPTION_OUTPUT.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(Active, true);
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused || Time.frameCount == _lastFrame)
        {
            return;
        }
        try
        {
            if (_animations == null)
            {
                Initialize();
            }
            _lastFrame = Time.frameCount;
            var scenarios = new List<object>();
            for (int index = 0; index < _animations.Length; index++)
            {
                scenarios.Add(ObserveScenario(index));
            }
            Samples.Add(new { tick = Samples.Count, scenarios });
            int requiredSamples = SamplesSourceManually ? ManualFinalTick + 1 : SampleCount;
            if (Samples.Count == requiredSamples)
            {
                Finish();
            }
        }
        catch (Exception error)
        {
            SessionState.SetBool(Active, false);
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static object ObserveScenario(int index)
    {
        Animation animation = _animations[index];
        object rig = UnityCoopRigFrameCapture.Capture(animation.transform.root, animation);
        object replay = _replays[index].Compare(animation);
        object manualRig = null;
        object manualReplay = null;
        if (SamplesSourceManually && Samples.Count == ManualFinalTick)
        {
            // This is the final diagnostic frame, so manual evaluation cannot contaminate a later observation.
            animation.Sample();
            manualRig = UnityCoopRigFrameCapture.Capture(animation.transform.root, animation);
            manualReplay = _replays[index].Compare(animation);
        }
        return new { returnFraction = ReturnFractions[index], rig, replay, manualRig, manualReplay };
    }

    private static void Initialize()
    {
        if (Hash(EnemyPath) != SourceEnemySha256)
        {
            throw new InvalidOperationException("Restore the original source prefab in the disposable project.");
        }
        Time.captureFramerate = CaptureRate;
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        Animation definition = prefab.GetComponentInChildren<Animation>(true);
        _animations = new Animation[ReturnFractions.Length];
        _replays = new UnityCoopObstacleRigReplayProbe[ReturnFractions.Length];
        for (int index = 0; index < ReturnFractions.Length; index++)
        {
            Animation source = CreateSource(prefab, definition, index);
            var controller = new UnityCoopObstacleOnlyProbe(source);
            source.Stop();
            source.Play("stand_up_crawl");
            source["stand_up_crawl"].normalizedTime = ReturnFractions[index];
            source.Sample();
            controller.NotifyObstacleRound();
            _animations[index] = source;
            _replays[index] = new UnityCoopObstacleRigReplayProbe(source.transform.root, source);
        }
    }

    private static Animation CreateSource(GameObject prefab, Animation definition, int index)
    {
        var root = new GameObject("ObstacleInterruptionSource" + index);
        root.SetActive(false);
        var copies = new Dictionary<Transform, Transform>();
        SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
        Animation animation = copies[definition.transform].gameObject.AddComponent<Animation>();
        animation.playAutomatically = false;
        animation.cullingType = AnimationCullingType.AlwaysAnimate;
        foreach (AnimationState state in definition)
        {
            if (state.name == state.clip.name)
            {
                animation.AddClip(state.clip, state.name);
            }
        }
        AttachWeapon(prefab, copies);
        root.SetActive(true);
        return animation;
    }

    private static void AttachWeapon(GameObject prefab, Dictionary<Transform, Transform> copies)
    {
        SoldierParts parts = prefab.GetComponentInChildren<SoldierParts>(true);
        GameObject weapon = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/AssaultRifleEnemy.prefab");
        var root = new GameObject(weapon.name);
        root.transform.SetParent(copies[parts.gunSnapPointNotScaled], false);
        root.transform.localRotation = weapon.transform.localRotation;
        SelfHostedVisualHierarchy.CopyRoot(weapon.transform, root.transform, new Dictionary<Transform, Transform>());
        root.transform.localScale = Vector3.one;
    }

    private static void Finish()
    {
        string output = Environment.GetEnvironmentVariable("WAR_OBSTACLE_CLEAN_INTERRUPTION_OUTPUT");
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unity = Application.unityVersion,
            captureRate = CaptureRate,
            phase = "Editor command after primed source sample; subsequent automatic Animation evaluation",
            controllerUpdateInvoked = false,
            samplesSourceManually = SamplesSourceManually,
            manualFinalTick = SamplesSourceManually ? (int?)ManualFinalTick : null,
            controllerInitialization = "obstacle-only wiring; no preceding idle or corner notification",
            probeSha256 = Hash("Assets/Editor/UnityCoopObstacleOnlyProbe.cs"),
            prefabSha256 = Hash(EnemyPath),
            controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            exporterSha256 = Hash("Assets/Editor/UnityCoopObstacleCleanInterruptionExport.cs"),
            samples = Samples
        }, Formatting.Indented));
        SessionState.SetBool(Active, false);
        EditorApplication.update -= Observe;
        Debug.Log("PASS: obstacle interruption observations: " + Samples.Count * ReturnFractions.Length);
        EditorApplication.Exit(0);
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

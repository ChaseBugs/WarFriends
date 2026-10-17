using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes all discrete crawl phases from zero through completed return at the host's fixed rate.</summary>
[InitializeOnLoad]
public static class UnityCoopObstacleFixedStepExport
{
    private const string SessionKey = "WarFriends.ObstacleFixedStepExport";
    private const int CaptureRate = 30;
    private const int ReturnPhaseCount = 17;
    private const int ObservationCount = 13;
    private static readonly List<object> Samples = new List<object>();
    private static Dictionary<string, string> _clipSha256;
    private static Animation[] _animations;
    private static UnityCoopObstacleRigReplayProbe[] _replays;
    private static int _lastFrame = -1;

    static UnityCoopObstacleFixedStepExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Enters isolated Play Mode before wiring inactive recovered controllers.</summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_OBSTACLE_FIXED_STEP_OUTPUT")))
        {
            throw new InvalidOperationException("Set WAR_OBSTACLE_FIXED_STEP_OUTPUT.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(SessionKey, true);
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
            for (int priorTick = 0; priorTick < ReturnPhaseCount; priorTick++)
            {
                Animation animation = _animations[priorTick];
                Samples.Add(new
                {
                    observationTick = Samples.Count / ReturnPhaseCount,
                    priorReturnTicks = priorTick,
                    rig = UnityCoopRigFrameCapture.Capture(animation.transform.root, animation),
                    replay = _replays[priorTick].Compare(animation)
                });
            }
            if (Samples.Count == ReturnPhaseCount * ObservationCount)
            {
                Finish();
            }
        }
        catch (Exception error)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static void Initialize()
    {
        const string sourceHash = "64b4db85d1c9a0bd46a690a86102a22f66feeab8d4157a4c87824ac3d5dbeb54";
        if (Hash("Assets/GameObject/enemy.prefab") != sourceHash)
        {
            throw new InvalidOperationException("The original prefab is required in the disposable project.");
        }
        _clipSha256 = ReadClipDigests();
        Time.captureFramerate = CaptureRate;
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
        Animation definition = prefab.GetComponentInChildren<Animation>(true);
        MethodInfo create = typeof(UnityCoopObstacleCleanInterruptionExport).GetMethod("CreateSource",
            BindingFlags.NonPublic | BindingFlags.Static);
        if (create == null)
        {
            throw new InvalidOperationException("The pinned script-free source builder is absent.");
        }
        _animations = new Animation[ReturnPhaseCount];
        _replays = new UnityCoopObstacleRigReplayProbe[ReturnPhaseCount];
        for (int tick = 0; tick < ReturnPhaseCount; tick++)
        {
            Animation source = (Animation)create.Invoke(null, new object[] { prefab, definition, tick });
            var controller = new UnityCoopObstacleOnlyProbe(source);
            source.Play("stand_up_crawl");
            source["stand_up_crawl"].time = tick / (float)CaptureRate;
            source.Sample();
            controller.NotifyObstacleRound();
            _animations[tick] = source;
            _replays[tick] = new UnityCoopObstacleRigReplayProbe(source.transform.root, source);
        }
    }

    private static void Finish()
    {
        foreach (KeyValuePair<string, string> current in ReadClipDigests())
        {
            if (_clipSha256[current.Key] != current.Value)
            {
                throw new InvalidOperationException("A source clip changed during the observation.");
            }
        }
        string output = Environment.GetEnvironmentVariable("WAR_OBSTACLE_FIXED_STEP_OUTPUT");
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unity = Application.unityVersion,
            captureRate = CaptureRate,
            phase = "Editor notification after priming exact fixed-step crawl time; automatic evaluation follows",
            controllerUpdateInvoked = false,
            clipSha256 = _clipSha256,
            prefabSha256 = Hash("Assets/GameObject/enemy.prefab"),
            exporterSha256 = Hash("Assets/Editor/UnityCoopObstacleFixedStepExport.cs"),
            builderSha256 = Hash("Assets/Editor/UnityCoopObstacleCleanInterruptionExport.cs"),
            controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            probeSha256 = Hash("Assets/Editor/UnityCoopObstacleOnlyProbe.cs"),
            samples = Samples
        }, Formatting.Indented));
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Observe;
        Debug.Log("PASS: fixed-step obstacle source observations: " + Samples.Count);
        EditorApplication.Exit(0);
    }

    private static Dictionary<string, string> ReadClipDigests()
    {
        var digests = new Dictionary<string, string>();
        foreach (string clip in new[] { "stand_up_crawl", "stand_up_begin", "rifle_shot_loop" })
        {
            digests.Add(clip, Hash("Assets/AnimationClip/" + clip + ".anim"));
        }
        return digests;
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

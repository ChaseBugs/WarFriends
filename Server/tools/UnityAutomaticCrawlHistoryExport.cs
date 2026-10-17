using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes crawl interruption after automatic fire/return history without seeking the crawl clip.</summary>
[InitializeOnLoad]
public static class UnityAutomaticCrawlHistoryExport
{
    private const string SessionKey = "WarFriends.AutomaticCrawlHistory";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string EnemyDigest = "64b4db85d1c9a0bd46a690a86102a22f66feeab8d4157a4c87824ac3d5dbeb54";
    private const int CaptureRate = 30;
    private const int FireWarmupFrames = 30;
    private const int PhaseCount = 17;
    private const int ObservationCount = 13;
    private static readonly List<object> Samples = new List<object>();
    private static readonly List<object> Origins = new List<object>();
    private static Actor[] _actors;
    private static Dictionary<string, string> _clipSha256;
    private static int _initialFrame;
    private static int? _returnFrame;
    private static int _lastFrame = -1;

    static UnityAutomaticCrawlHistoryExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Starts an empty isolated Play Mode scene before constructing script-free animated actors.</summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_AUTOMATIC_CRAWL_OUTPUT")))
        {
            throw new InvalidOperationException("Set WAR_AUTOMATIC_CRAWL_OUTPUT.");
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
            _lastFrame = Time.frameCount;
            if (_actors == null)
            {
                Initialize();
                return;
            }

            if (!_returnFrame.HasValue)
            {
                if (Time.frameCount - _initialFrame < FireWarmupFrames)
                {
                    return;
                }

                BeginReturn();
            }

            ObserveActors();
            if (Samples.Count == PhaseCount * ObservationCount)
            {
                Finish();
            }
        }
        catch (Exception failure)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void Initialize()
    {
        if (Hash(EnemyPath) != EnemyDigest)
        {
            throw new InvalidOperationException("Restore the original source prefab in the disposable project.");
        }

        Time.captureFramerate = CaptureRate;
        _clipSha256 = ReadClipDigests();
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        Animation definition = prefab.GetComponentInChildren<Animation>(true);
        MethodInfo create = typeof(UnityCoopObstacleCleanInterruptionExport).GetMethod(
            "CreateSource", BindingFlags.NonPublic | BindingFlags.Static);
        _actors = new Actor[PhaseCount];
        for (int phase = 0; phase < PhaseCount; phase++)
        {
            Animation source = (Animation)create.Invoke(null, new object[] { prefab, definition, phase });
            source.Stop();
            source["rifle_shot_loop"].wrapMode = WrapMode.ClampForever;
            source.Play("rifle_shot_loop");
            _actors[phase] = new Actor(source, new UnityCoopObstacleOnlyProbe(source));
        }

        _initialFrame = Time.frameCount;
    }

    private static void BeginReturn()
    {
        foreach (Actor actor in _actors)
        {
            actor.Source["stand_up_crawl"].wrapMode = WrapMode.ClampForever;
            // This is the recovered return operation; no Sample or time assignment primes its hierarchy.
            actor.Source.Play("stand_up_crawl");
        }

        _returnFrame = Time.frameCount;
    }

    private static void ObserveActors()
    {
        int elapsed = Time.frameCount - _returnFrame.Value;
        for (int phase = 0; phase < _actors.Length; phase++)
        {
            Actor actor = _actors[phase];
            if (!actor.NotificationFrame.HasValue && elapsed >= phase)
            {
                if (elapsed != phase)
                {
                    throw new InvalidOperationException("A source phase was skipped by the Editor observer.");
                }

                Origins.Add(new { priorReturnTicks = phase, rig = Capture(actor) });
                actor.Controller.NotifyObstacleRound();
                actor.NotificationFrame = Time.frameCount;
            }

            if (actor.NotificationFrame.HasValue && actor.Observations < ObservationCount)
            {
                Record(actor, phase);
            }
        }
    }

    private static void Record(Actor actor, int phase)
    {
        int observation = Time.frameCount - actor.NotificationFrame.Value;
        if (observation != actor.Observations)
        {
            throw new InvalidOperationException("An automatic observation frame was skipped.");
        }

        Samples.Add(new { priorReturnTicks = phase, observationTick = observation, rig = Capture(actor) });
        actor.Observations++;
    }

    private static object Capture(Actor actor)
    {
        return UnityCoopRigFrameCapture.Capture(actor.Source.transform.root, actor.Source);
    }

    private static void Finish()
    {
        foreach (KeyValuePair<string, string> current in ReadClipDigests())
        {
            if (_clipSha256[current.Key] != current.Value)
            {
                throw new InvalidOperationException("A source animation changed during observation.");
            }
        }

        string output = Environment.GetEnvironmentVariable("WAR_AUTOMATIC_CRAWL_OUTPUT");
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unity = Application.unityVersion,
            captureRate = CaptureRate,
            fireWarmupFrames = FireWarmupFrames,
            observedFireWarmupFrames = _returnFrame.Value - _initialFrame,
            phase = "Editor command after automatic fire; ordinary crawl Play; automatic return; source notification",
            manuallySamplesSource = false,
            seeksCrawlTime = false,
            controllerUpdateInvoked = false,
            prefabSha256 = Hash(EnemyPath),
            clipSha256 = _clipSha256,
            exporterSha256 = Hash("Assets/Editor/UnityAutomaticCrawlHistoryExport.cs"),
            builderSha256 = Hash("Assets/Editor/UnityCoopObstacleCleanInterruptionExport.cs"),
            probeSha256 = Hash("Assets/Editor/UnityCoopObstacleOnlyProbe.cs"),
            controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            captureSha256 = Hash("Assets/Editor/UnityCoopRigFrameCapture.cs"),
            origins = Origins,
            samples = Samples
        }, Formatting.Indented));
        SessionState.SetBool(SessionKey, false);
        Debug.Log("PASS: 221 automatic-return interruption observations; no manual source sampling or crawl seeking.");
        EditorApplication.Exit(0);
    }

    private static Dictionary<string, string> ReadClipDigests()
    {
        var result = new Dictionary<string, string>();
        foreach (string clip in new[] { "stand_up_crawl", "stand_up_begin", "rifle_shot_loop" })
        {
            result.Add(clip, Hash("Assets/AnimationClip/" + clip + ".anim"));
        }

        return result;
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }

    private sealed class Actor
    {
        internal Animation Source { get; private set; }

        internal UnityCoopObstacleOnlyProbe Controller { get; private set; }

        internal int? NotificationFrame { get; set; }

        internal int Observations { get; set; }

        internal Actor(Animation source, UnityCoopObstacleOnlyProbe controller)
        {
            Source = source;
            Controller = controller;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

using Newtonsoft.Json;

/// <summary>Observes the source one-argument CrossFade on stripped recovered rigs in Play Mode.</summary>
[InitializeOnLoad]
public static class UnityHelicopterFadeExport
{
    private const string ActiveKey = "WarFriends.HelicopterFadeProbe";
    private const string PalmKey = ActiveKey + ".Palm";
    private const string FinishedKey = ActiveKey + ".Finished";
    private const string ExitCodeKey = ActiveKey + ".ExitCode";
    private const string Source = "Assets/GameObject/enemy.prefab";
    private const string Controller = "Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs";
    private const string OutputVariable = "WAR_HELICOPTER_FADE_OUTPUT";
    private const string Idle = "idle";
    private const string Slide = "helicopter_jump_pose";
    private const int CaptureRate = 30;
    private const float Duration = 0.5f;
    private static readonly float[] IdlePhases = { 0f, 0.5f, 29f / CaptureRate };
    private static readonly List<object> Frames = new List<object>();
    private static Animation[] _animations;
    private static Transform[] _palms;
    private static float _startTime;
    private static int _lastFrame = -1;

    static UnityHelicopterFadeExport()
    {
        if (SessionState.GetBool(ActiveKey, false))
        {
            EditorApplication.update += Observe;
        }
        if (SessionState.GetBool(FinishedKey, false))
        {
            EditorApplication.update += ExitWhenStopped;
        }
    }

    /// <summary>Creates an isolated animation fixture without enabling gameplay or online services.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") ||
            string.IsNullOrEmpty(Environment.GetEnvironmentVariable(OutputVariable)))
        {
            throw new InvalidOperationException("Use a disposable project and an explicit output path.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(Source);
        for (int scenario = 0; scenario < IdlePhases.Length; scenario++)
        {
            GameObject enemy = UnityEngine.Object.Instantiate(prefab);
            enemy.name = "HelicopterFadeProbe" + scenario;
            enemy.transform.position = Vector3.zero;
            enemy.transform.rotation = Quaternion.identity;
            Transform palm = enemy.GetComponent<EnemyController>().mSoldierAnimationController.leftPalm;
            SessionState.SetString(PalmKey, AnimationUtility.CalculateTransformPath(palm, enemy.transform));
            CaptureSources(enemy.GetComponentInChildren<Animation>(true));
            StripGameplay(enemy);
        }
        SessionState.SetBool(ActiveKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void CaptureSources(Animation animation)
    {
        object[] clips = new[] { "idle_1", Slide, "T_pose" }.Select(name =>
        {
            AnimationState state = animation[name];
            string path = AssetDatabase.GetAssetPath(state.clip);
            return (object)new { name, source = path, sha256 = Hash(path), length = state.length,
                wrap = state.wrapMode.ToString() };
        }).ToArray();
        // Play Mode makes transient clip instances whose AssetDatabase paths are empty.
        SessionState.SetString(ActiveKey + ".Sources", JsonConvert.SerializeObject(clips));
    }

    private static void StripGameplay(GameObject enemy)
    {
        for (int pass = 0; pass < 5; pass++)
        {
            foreach (MonoBehaviour script in enemy.GetComponentsInChildren<MonoBehaviour>(true)
                .OrderBy(script => script is EnemyController ? 1 : 0))
            {
                if (script != null)
                {
                    UnityEngine.Object.DestroyImmediate(script);
                }
            }
        }
        if (enemy.GetComponentsInChildren<MonoBehaviour>(true).Any(script => script != null))
        {
            throw new InvalidOperationException("Gameplay script remains on fade probe.");
        }
        foreach (Rigidbody body in enemy.GetComponentsInChildren<Rigidbody>(true))
        {
            body.isKinematic = true;
            body.useGravity = false;
            body.detectCollisions = false;
        }
        foreach (Collider collider in enemy.GetComponentsInChildren<Collider>(true))
        {
            collider.enabled = false;
        }
    }

    private static void Observe()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused || _lastFrame == Time.frameCount)
        {
            return;
        }
        try
        {
            if (_animations == null)
            {
                StartPlayback();
            }
            _lastFrame = Time.frameCount;
            float elapsed = Time.time - _startTime;
            Frames.Add(new
            {
                frame = Time.frameCount, elapsed, deltaTime = Time.deltaTime,
                scenarios = _animations.Select((animation, scenario) => new
                {
                    idlePhase = IdlePhases[scenario],
                    palm = Values(_palms[scenario].position),
                    states = animation.Cast<AnimationState>()
                        .Where(state => state.enabled || state.name == Idle || state.name == Slide)
                        .Select(state => new { name = state.name, time = state.time, weight = state.weight,
                            enabled = state.enabled, speed = state.speed, layer = state.layer,
                            blendMode = state.blendMode.ToString() }).ToArray()
                }).ToArray()
            });
            if (elapsed >= Duration)
            {
                WriteReference();
                Finish(0);
            }
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            Finish(1);
        }
    }

    private static void StartPlayback()
    {
        Time.captureFramerate = CaptureRate;
        _animations = new Animation[IdlePhases.Length];
        _palms = new Transform[IdlePhases.Length];
        for (int scenario = 0; scenario < IdlePhases.Length; scenario++)
        {
            GameObject enemy = GameObject.Find("HelicopterFadeProbe" + scenario);
            Animation animation = enemy.GetComponentInChildren<Animation>(true);
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            animation.cullingType = AnimationCullingType.AlwaysAnimate;
            animation.Stop();
            AnimationState reset = animation["T_pose"];
            reset.enabled = true;
            reset.weight = 1;
            reset.normalizedTime = 1;
            animation.Sample();
            reset.enabled = false;
            animation.Play(Idle);
            animation[Idle].time = IdlePhases[scenario];
            animation.Sample();
            // This is the exact Animation call in the recovered RopeSlide method.
            animation.CrossFade(Slide);
            _animations[scenario] = animation;
            _palms[scenario] = enemy.transform.Find(SessionState.GetString(PalmKey, ""));
        }
        _startTime = Time.time;
    }

    private static void WriteReference()
    {
        var method = typeof(Animation).GetMethod("CrossFade", new[] { typeof(string) });
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            source = Source, sourceSha256 = Hash(Source),
            controller = Controller, controllerSha256 = Hash(Controller),
            captureRate = CaptureRate, physicsFrozen = true,
            fixture = "Fully weighted canonical idle alias, then one-argument CrossFade; no gameplay scripts.",
            clipSources = JsonConvert.DeserializeObject(SessionState.GetString(ActiveKey + ".Sources", "")),
            crossFadeIl = Convert.ToBase64String(method.GetMethodBody().GetILAsByteArray()),
            frames = Frames
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), reference);
        Debug.Log("PASS: native Helicopter fade observations=" + Frames.Count);
    }

    private static void Finish(int exitCode)
    {
        SessionState.SetBool(ActiveKey, false);
        SessionState.SetBool(FinishedKey, true);
        SessionState.SetInt(ExitCodeKey, exitCode);
        EditorApplication.update -= Observe;
        EditorApplication.update += ExitWhenStopped;
        EditorApplication.isPlaying = false;
    }

    private static void ExitWhenStopped()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }
        SessionState.SetBool(FinishedKey, false);
        EditorApplication.update -= ExitWhenStopped;
        EditorApplication.Exit(SessionState.GetInt(ExitCodeKey, 1));
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
        }
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }
}

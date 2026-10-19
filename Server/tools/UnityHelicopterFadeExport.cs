using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

/// <summary>Observes the source one-argument CrossFade on stripped recovered rigs in Play Mode.</summary>
[InitializeOnLoad]
public static class UnityHelicopterFadeExport
{
    private const string ActiveKey = "WarFriends.HelicopterFadeProbe";
    private const string PalmKey = ActiveKey + ".Palm";
    private const string FinishedKey = ActiveKey + ".Finished";
    private const string ExitCodeKey = ActiveKey + ".ExitCode";
    private const string VisibilityKey = ActiveKey + ".Visibility";
    private const string Source = "Assets/GameObject/enemy.prefab";
    private const string Controller = "Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs";
    private const string OutputVariable = "WAR_HELICOPTER_FADE_OUTPUT";
    private const string Idle = "idle";
    private const string Slide = "helicopter_jump_pose";
    private const int CaptureRate = 30;
    private const float Duration = 0.5f;
    private const float IdleResetDuration = 1.2f;
    private static readonly float[] IdlePhases = { 0f, 0.5f, 29f / CaptureRate };
    private static readonly List<object> Frames = new List<object>();
    private static readonly List<object> SlideCommands = new List<object>();
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
        SessionState.SetBool(VisibilityKey,
            Environment.GetEnvironmentVariable("WAR_HELICOPTER_FADE_VISIBILITY") == "1");
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
                    componentEnabled = animation.enabled,
                    palm = Values(_palms[scenario].position),
                    descent = UnityHelicopterDescentObservation.Capture(
                        animation.transform.root, _palms[scenario], scenario, Frames.Count),
                    states = animation.Cast<AnimationState>()
                        .Where(state => state.enabled || state.name == Idle || state.name == Slide)
                        .Select(state => new { name = state.name, time = state.time, weight = state.weight,
                            enabled = state.enabled, speed = state.speed, layer = state.layer,
                            blendMode = state.blendMode.ToString() }).ToArray()
                }).ToArray()
            });
            if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_TO_SLIDE") == "1")
            {
                if (Frames.Count == 3)
                {
                    InvokeRopeSlide(_animations[1], 1, 2);
                }
                if (Frames.Count == 11)
                {
                    InvokeRopeSlide(_animations[2], 2, 10);
                }
            }
            if (SessionState.GetBool(VisibilityKey, false) && (Frames.Count == 3 || Frames.Count == 7))
            {
                if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_TO_SLIDE") == "1")
                {
                    _animations[1].enabled = Frames.Count == 7;
                }
                else
                {
                    foreach (Animation animation in _animations)
                    {
                        animation.enabled = Frames.Count == 7;
                    }
                }
            }
            float duration = Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_RESET") == "1"
                ? IdleResetDuration : Duration;
            if (elapsed >= duration)
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
            if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_RESET") == "1")
            {
                StartIdleAfterReset(enemy, animation, scenario);
                _animations[scenario] = animation;
                _palms[scenario] = enemy.transform.Find(SessionState.GetString(PalmKey, ""));
                continue;
            }
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

    private static void StartIdleAfterReset(GameObject enemy, Animation animation, int scenario)
    {
        AnimationState previous = animation[Slide];
        previous.enabled = true;
        previous.weight = 1;
        previous.time = IdlePhases[scenario] * previous.length;
        animation.Sample();
        GameObject owner = new GameObject("InactiveIdleResetOwner");
        owner.SetActive(false);
        try
        {
            SoldierAnimationController controller = owner.AddComponent<SoldierAnimationController>();
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(Source);
            SoldierAnimationController source = prefab.GetComponent<EnemyController>().mSoldierAnimationController;
            SetControllerField(controller, "mAnimation", animation);
            BindResetRoot(controller, enemy.transform, source.rootBone, "");
            BindResetRoot(controller, enemy.transform, source.rootBoneInner, "Inner");
            controller.Reset();
            controller.Idle(Weapon.WeaponType.Riffle);
            if (scenario == 0 && Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_TO_SLIDE") == "1")
            {
                InvokeRopeSlide(animation, scenario, -1);
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
        // Isolate Reset-to-Idle mixer behaviour from unresolved renderer visibility in a headless capture.
        animation.cullingType = AnimationCullingType.AlwaysAnimate;
    }

    private static void BindResetRoot(SoldierAnimationController controller, Transform enemy,
        Transform sourceRoot, string suffix)
    {
        if (sourceRoot == null)
        {
            return;
        }
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(Source);
        string path = AnimationUtility.CalculateTransformPath(sourceRoot, prefab.transform);
        Transform root = enemy.Find(path);
        if (suffix == "Inner")
        {
            controller.rootBoneInner = root;
        }
        else
        {
            controller.rootBone = root;
        }
        SetControllerField(controller, "mRootPos" + suffix, sourceRoot.localPosition);
        SetControllerField(controller, "mRootRot" + suffix, sourceRoot.localRotation);
    }

    private static void SetControllerField(SoldierAnimationController controller, string name, object value)
    {
        var field = typeof(SoldierAnimationController).GetField(name,
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        field.SetValue(controller, value);
    }

    private static void InvokeRopeSlide(Animation animation, int scenario, int afterSample)
    {
        object[] before = TransitionLayers(animation);
        var owner = new GameObject("InactiveRopeSlideOwner");
        owner.SetActive(false);
        try
        {
            SoldierAnimationController controller = owner.AddComponent<SoldierAnimationController>();
            SetControllerField(controller, "mAnimation", animation);
            controller.RopeSlide();
            SlideCommands.Add(new { scenario, afterSample, before, after = TransitionLayers(animation) });
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static object[] TransitionLayers(Animation animation)
    {
        return new[] { Idle, Slide }.Select(name =>
        {
            AnimationState state = animation[name];
            return (object)new { name, time = state.time, weight = state.weight, enabled = state.enabled };
        }).ToArray();
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
            visibilityProbe = SessionState.GetBool(VisibilityKey, false),
            idleResetProbe = Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_RESET") == "1",
            idleToSlideProbe = Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_TO_SLIDE") == "1",
            descentControllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/EnemyController.cs"),
            descentNativeInputSha256 = UnityHelicopterDescentObservation.NativeInputDigest,
            fixture = FixtureDescription(),
            clipSources = JsonConvert.DeserializeObject(SessionState.GetString(ActiveKey + ".Sources", "")),
            crossFadeIl = Convert.ToBase64String(method.GetMethodBody().GetILAsByteArray()),
            commands = SlideCommands, frames = Frames
        }, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = new FixtureContractResolver()
        }).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), reference);
        Debug.Log("PASS: native Helicopter fade observations=" + Frames.Count);
    }

    private static string FixtureDescription()
    {
        if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_IDLE_RESET") == "1")
        {
            return "Original Reset then Idle(Riffle), stale sampled slide fractions; " +
                "AlwaysAnimate override, inactive temporary controller with source cached root fields.";
        }
        if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_FADE_DESCENT") == "1")
        {
            return "Animated rig plus inactive source HelicopterUpdate owner; supplied joints, no gameplay lifecycle.";
        }
        return "Fully weighted canonical idle alias, then one-argument CrossFade; no gameplay scripts.";
    }

    private static void Finish(int exitCode)
    {
        SessionState.SetBool(ActiveKey, false);
        SessionState.SetBool(FinishedKey, true);
        SessionState.SetInt(ExitCodeKey, exitCode);
        EditorApplication.update -= Observe;
        EditorApplication.update += ExitWhenStopped;
        // The JSON is already saved; do not retain sampled Unity objects across Play Mode asset unloading.
        Frames.Clear();
        SlideCommands.Clear();
        UnityHelicopterDescentObservation.Clear();
        _animations = null;
        _palms = null;
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

    private sealed class FixtureContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type type)
        {
            if (type.IsPrimitive || type.IsEnum || type == typeof(string) ||
                typeof(Newtonsoft.Json.Linq.JToken).IsAssignableFrom(type))
            {
                return base.CreateContract(type);
            }
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
            {
                return CreateArrayContract(type);
            }
            // The fixture only contains plain observation objects; avoid old Mono TypeDescriptor string converters.
            return CreateObjectContract(type);
        }
    }
}

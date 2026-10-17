// Run in the disposable Unity 2018 project, never in the active Client.
// Samples legacy Animation queue timing on the recovered enemy rig without
// enabling its Photon or gameplay scripts.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class UnityCoopAssaulterAnimationQueueExport
{
    private const string Active = "WarFriends.CoopAssaulterAnimationQueue";
    private const string Primed = "WarFriends.CoopAssaulterQueuePrimed";
    private const string WholeRig = "WarFriends.CoopAssaulterWholeRig";
    private const string CornerVolley = "WarFriends.CoopAssaulterCornerVolley";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string WeaponPath =
        "Assets/GameObject/AssaultRifleEnemy.prefab";

    private static readonly string[] StartClips =
        { "stand_up_begin", "player_look_right3", "player_look_left3" };
    private static readonly string[] FireClips =
        { "rifle_shot_loop", "player_fire_right3", "player_fire_left3" };
    private static readonly float[] FadeSeconds = { 0.05f, 0.02f, 0.02f };
    private static readonly string[] PriorClips =
        { "stand_up_crawl", "idle_1", "idle_1" };
    private static readonly float[] PriorNormalizedTimes = { 1f, 0.5f, 0.5f };
    private static readonly List<object>[] Frames =
        { new List<object>(), new List<object>(), new List<object>() };

    private static Animation[] animations;
    private static Transform[] muzzles;
    private static Transform[] roots;
    private static float startTime;
    private static UnityCoopCornerVolleyProbe[] volleyProbes;
    private static UnityCoopRigReplayProbe[] replayProbes;
    private static UnityCoopRigReplayProbe[] ordinaryQueueControls;
    private static UnityCoopRigReplayProbe[] ordinaryBaseControls;

    static UnityCoopAssaulterAnimationQueueExport()
    {
        if (SessionState.GetBool(Active, false))
            EditorApplication.update += Update;
    }

    public static void Run()
    {
        SessionState.SetBool(CornerVolley, false);
        Begin(false);
    }

    public static void RunPrimed()
    {
        SessionState.SetBool(CornerVolley, false);
        Begin(true);
    }

    /// <summary>Captures full local rig poses and mixer states from the source cover preparation.</summary>
    public static void RunWholeRig()
    {
        SessionState.SetBool(CornerVolley, false);
        Begin(true, true);
    }

    /// <summary>Observes source corner round resets and an interrupted cover return under a declared fixture.</summary>
    public static void RunCornerVolley()
    {
        SessionState.SetBool(CornerVolley, true);
        Begin(true, true);
    }

    private static void Begin(bool primed, bool wholeRig = false)
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(
                OutputVariable(primed, wholeRig))))
            throw new InvalidOperationException(
                "Set the co-op Assaulter queue output path.");

        var enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        var weaponPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath);
        if (enemyPrefab == null || weaponPrefab == null)
            throw new InvalidOperationException("Missing recovered source prefab.");

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        for (int i = 0; i < StartClips.Length; i++)
        {
            var enemy = (GameObject)PrefabUtility.InstantiatePrefab(enemyPrefab);
            enemy.name = "CoopAssaulterQueue" + i;
            enemy.transform.position = Vector3.zero;
            enemy.transform.rotation = Quaternion.identity;

            var parts = enemy.GetComponentInChildren<SoldierParts>(true);
            if (parts == null || parts.gunSnapPointNotScaled == null)
                throw new InvalidOperationException("Missing enemy gun attachment.");
            Transform snap = parts.gunSnapPointNotScaled;
            var weapon = (GameObject)PrefabUtility.InstantiatePrefab(weaponPrefab);
            weapon.transform.SetParent(snap, false);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = weaponPrefab.transform.localRotation;
            weapon.transform.localScale = Vector3.one;
            if (weapon.transform.Find("HK416/MachinegunMuzzleFlash") == null)
                throw new InvalidOperationException("Missing source rifle muzzle.");

            // RequireComponent can recreate a dependency while another
            // script is removed. Repeat until the stripped rig is stable.
            for (int pass = 0; pass < 5; pass++)
            {
                MonoBehaviour[] scripts = enemy
                    .GetComponentsInChildren<MonoBehaviour>(true)
                    .Where(script => script != null).ToArray();
                if (scripts.Length == 0)
                    break;
                foreach (MonoBehaviour script in scripts)
                    UnityEngine.Object.DestroyImmediate(script);
            }
            MonoBehaviour[] remaining = enemy
                .GetComponentsInChildren<MonoBehaviour>(true);
            if (remaining.Any(script => script != null))
                throw new InvalidOperationException("Gameplay script remains on probe rig: " +
                    string.Join(",", remaining.Where(script => script != null)
                        .Select(script => script.GetType().Name).ToArray()));
            if (wholeRig)
            {
                FreezeProbePhysics(enemy);
            }
        }
        SessionState.SetBool(Active, true);
        SessionState.SetBool(Primed, primed);
        SessionState.SetBool(WholeRig, wholeRig);
        EditorApplication.isPlaying = true;
    }

    private static void Update()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
            return;
        try
        {
            if (animations == null)
                StartPlayback();

            float seconds = Time.time - startTime;
            float duration = SessionState.GetBool(CornerVolley, false) ? 3f : 1.3f;
            for (int i = 0; i < animations.Length; i++)
            {
                Animation animation = animations[i];
                Transform muzzle = muzzles[i];
                Transform root = roots[i];
                object frame = new
                {
                    frame = Time.frameCount,
                    seconds,
                    position = Coordinates(root.InverseTransformPoint(muzzle.position)),
                    rotation = Rotation(Quaternion.Inverse(root.rotation) * muzzle.rotation),
                    states = animation.Cast<AnimationState>()
                        .Where(state => state.enabled ||
                            state.name == StartClips[i] ||
                            state.name == FireClips[i])
                        .Select(state => new
                        {
                            name = state.name,
                            time = state.time,
                            weight = state.weight,
                            enabled = state.enabled
                        }).ToArray()
                };
                if (SessionState.GetBool(WholeRig, false))
                {
                    object rig = UnityCoopRigFrameCapture.Capture(root, animation);
                    object replay = replayProbes[i].Compare(animation);
                    object ordinaryQueueControl = ordinaryQueueControls[i].Compare(animation);
                    object ordinaryBaseControl = ordinaryBaseControls[i].Compare(animation);
                    object manualSampleReplay = null;
                    if (seconds >= duration)
                    {
                        manualSampleReplay = replayProbes[i].CompareAfterSourceSample(animation);
                    }
                    object commands = null;
                    if (volleyProbes != null && volleyProbes[i] != null)
                    {
                        commands = volleyProbes[i].Advance(seconds);
                    }
                    Frames[i].Add(new
                    {
                        observation = frame,
                        commandsAfterObservation = commands,
                        replay,
                        ordinaryQueueControl,
                        ordinaryBaseControl,
                        manualSampleReplay,
                        rig
                    });
                }
                else
                {
                    Frames[i].Add(frame);
                }
            }
            if (seconds < duration)
                return;

            string output = Environment.GetEnvironmentVariable(
                OutputVariable(SessionState.GetBool(Primed, false), SessionState.GetBool(WholeRig, false)));
            var scenarios = Enumerable.Range(0, 3).Select(i => new
            {
                startClip = StartClips[i],
                startClipSha256 = Hash("Assets/AnimationClip/" + StartClips[i] + ".anim"),
                fireClip = FireClips[i],
                fireClipSha256 = Hash("Assets/AnimationClip/" + FireClips[i] + ".anim"),
                fadeSeconds = FadeSeconds[i],
                frames = Frames[i]
            }).ToArray();
            if (SessionState.GetBool(Primed, false))
            {
                var primedScenarios = Enumerable.Range(0, 3).Select(i => new
                {
                    priorClip = PriorClips[i],
                    priorClipSha256 = Hash("Assets/AnimationClip/" +
                        PriorClips[i] + ".anim"),
                    priorNormalizedTime = PriorNormalizedTimes[i],
                    startClip = StartClips[i],
                    startClipSha256 = Hash("Assets/AnimationClip/" + StartClips[i] + ".anim"),
                    fireClip = FireClips[i],
                    fireClipSha256 = Hash("Assets/AnimationClip/" + FireClips[i] + ".anim"),
                    fadeSeconds = FadeSeconds[i],
                    sourceBindings = UnityCoopClipBindingAudit.Capture(animations[i],
                        new[] { PriorClips[i], StartClips[i], FireClips[i] }),
                    frames = Frames[i]
                }).ToArray();
                File.WriteAllText(output, JsonConvert.SerializeObject(new
                {
                    version = 1,
                    unity = Application.unityVersion,
                    enemySha256 = Hash(EnemyPath),
                    weaponSha256 = Hash(WeaponPath),
                    captureRate = 30,
                    cornerVolleyFixture = SessionState.GetBool(CornerVolley, false),
                    physicsFrozen = SessionState.GetBool(WholeRig, false),
                    animationControllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
                    scenarios = primedScenarios
                }, Formatting.Indented));
            }
            else
            {
                File.WriteAllText(output, JsonConvert.SerializeObject(new
                {
                    version = 1,
                    unity = Application.unityVersion,
                    enemySha256 = Hash(EnemyPath),
                    weaponSha256 = Hash(WeaponPath),
                    captureRate = 30,
                    scenarios
                }, Formatting.Indented));
            }
            SessionState.SetBool(Active, false);
            SessionState.SetBool(Primed, false);
            SessionState.SetBool(WholeRig, false);
            SessionState.SetBool(CornerVolley, false);
            EditorApplication.update -= Update;
            Debug.Log("COOP_ASSAULTER_QUEUE_EXPORT_PASSED frames=" +
                Frames.Sum(rows => rows.Count));
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            SessionState.SetBool(Active, false);
            SessionState.SetBool(Primed, false);
            SessionState.SetBool(WholeRig, false);
            SessionState.SetBool(CornerVolley, false);
            EditorApplication.update -= Update;
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static void FreezeProbePhysics(GameObject root)
    {
        // Detached weapon rigid bodies must not contaminate animation-only transform observations.
        foreach (Rigidbody body in root.GetComponentsInChildren<Rigidbody>(true))
        {
            body.isKinematic = true;
            body.useGravity = false;
            body.detectCollisions = false;
        }
        foreach (Collider collider in root.GetComponentsInChildren<Collider>(true))
        {
            collider.enabled = false;
        }
    }

    private static string OutputVariable(bool isPrimed, bool isWholeRig)
    {
        if (isWholeRig)
        {
            return "WAR_COOP_ASSAULTER_RIG_OUTPUT";
        }
        if (isPrimed)
        {
            return "WAR_COOP_ASSAULTER_PRIMED_OUTPUT";
        }

        return "WAR_COOP_ASSAULTER_QUEUE_OUTPUT";
    }

    private static void StartPlayback()
    {
        Time.captureFramerate = 30;
        animations = new Animation[3];
        muzzles = new Transform[3];
        roots = new Transform[3];
        if (SessionState.GetBool(WholeRig, false))
        {
            replayProbes = new UnityCoopRigReplayProbe[3];
            ordinaryQueueControls = new UnityCoopRigReplayProbe[3];
            ordinaryBaseControls = new UnityCoopRigReplayProbe[3];
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = GameObject.Find("CoopAssaulterQueue" + i);
            if (enemy == null)
                throw new InvalidOperationException("Probe rig was not retained in Play Mode.");
            roots[i] = enemy.transform;
            animations[i] = enemy.GetComponentInChildren<Animation>(true);
            muzzles[i] = enemy.GetComponentsInChildren<Transform>(true)
                .Single(child => child.name == "MachinegunMuzzleFlash" &&
                    child.parent.name == "HK416");
            if (animations[i] == null)
                throw new InvalidOperationException("Missing recovered legacy Animation.");
            Animation animation = animations[i];
            animation.cullingType = AnimationCullingType.AlwaysAnimate;
            animation.Stop();
            if (replayProbes != null)
            {
                SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
                // Bind the independent hierarchy before prior-pose sampling changes any partial curve defaults.
                replayProbes[i] = new UnityCoopRigReplayProbe(roots[i]);
                ordinaryQueueControls[i] = new UnityCoopRigReplayProbe(roots[i],
                    UnityCoopRigReplayProbe.QueueReplayMode.OrdinaryQueuedAlias);
                ordinaryBaseControls[i] = new UnityCoopRigReplayProbe(roots[i],
                    UnityCoopRigReplayProbe.QueueReplayMode.OrdinaryBaseName);
            }
            if (SessionState.GetBool(Primed, false))
            {
                AnimationState prior = animation[PriorClips[i]];
                if (prior == null)
                    throw new InvalidOperationException("Missing recovered prior cover pose.");
                animation.Play(PriorClips[i]);
                prior.normalizedTime = PriorNormalizedTimes[i];
                prior.speed = 0;
                animation.Sample();
            }
            animation[StartClips[i]].normalizedTime = 0;
            animation.CrossFade(StartClips[i], FadeSeconds[i]);
            animation[FireClips[i]].wrapMode = WrapMode.ClampForever;
            animation.PlayQueued(FireClips[i]);
        }
        if (SessionState.GetBool(CornerVolley, false))
        {
            volleyProbes = new UnityCoopCornerVolleyProbe[3];
            volleyProbes[1] = new UnityCoopCornerVolleyProbe(animations[1], true);
            volleyProbes[2] = new UnityCoopCornerVolleyProbe(animations[2], false);
        }
        startTime = Time.time;
    }

    private static float[] Coordinates(Vector3 value) =>
        new[] { value.x, value.y, value.z };

    private static float[] Rotation(Quaternion value) =>
        new[] { value.x, value.y, value.z, value.w };

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
    }
}

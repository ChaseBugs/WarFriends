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
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string WeaponPath =
        "Assets/GameObject/AssaultRifleEnemy.prefab";

    private static readonly string[] StartClips =
        { "stand_up_begin", "player_look_right3", "player_look_left3" };
    private static readonly string[] FireClips =
        { "rifle_shot_loop", "player_fire_right3", "player_fire_left3" };
    private static readonly float[] FadeSeconds = { 0.05f, 0.02f, 0.02f };
    private static readonly List<object>[] Frames =
        { new List<object>(), new List<object>(), new List<object>() };

    private static Animation[] animations;
    private static Transform[] muzzles;
    private static Transform[] roots;
    private static float startTime;

    static UnityCoopAssaulterAnimationQueueExport()
    {
        if (SessionState.GetBool(Active, false))
            EditorApplication.update += Update;
    }

    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(
                "WAR_COOP_ASSAULTER_QUEUE_OUTPUT")))
            throw new InvalidOperationException(
                "Set WAR_COOP_ASSAULTER_QUEUE_OUTPUT.");

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
        }
        SessionState.SetBool(Active, true);
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
            for (int i = 0; i < animations.Length; i++)
            {
                Animation animation = animations[i];
                Transform muzzle = muzzles[i];
                Transform root = roots[i];
                Frames[i].Add(new
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
                });
            }
            if (seconds < 1.3f)
                return;

            string output = Environment.GetEnvironmentVariable(
                "WAR_COOP_ASSAULTER_QUEUE_OUTPUT");
            var scenarios = Enumerable.Range(0, 3).Select(i => new
            {
                startClip = StartClips[i],
                startClipSha256 = Hash("Assets/AnimationClip/" + StartClips[i] + ".anim"),
                fireClip = FireClips[i],
                fireClipSha256 = Hash("Assets/AnimationClip/" + FireClips[i] + ".anim"),
                fadeSeconds = FadeSeconds[i],
                frames = Frames[i]
            }).ToArray();
            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                version = 1,
                unity = Application.unityVersion,
                enemySha256 = Hash(EnemyPath),
                weaponSha256 = Hash(WeaponPath),
                captureRate = 30,
                scenarios
            }, Formatting.Indented));
            SessionState.SetBool(Active, false);
            EditorApplication.update -= Update;
            Debug.Log("COOP_ASSAULTER_QUEUE_EXPORT_PASSED frames=" +
                Frames.Sum(rows => rows.Count));
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            SessionState.SetBool(Active, false);
            EditorApplication.update -= Update;
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static void StartPlayback()
    {
        Time.captureFramerate = 30;
        animations = new Animation[3];
        muzzles = new Transform[3];
        roots = new Transform[3];
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
            animation[StartClips[i]].normalizedTime = 0;
            animation.CrossFade(StartClips[i], FadeSeconds[i]);
            animation[FireClips[i]].wrapMode = WrapMode.ClampForever;
            animation.PlayQueued(FireClips[i]);
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

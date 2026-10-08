// Run only in the disposable Unity 2018 project. Captures the recovered
// enemy rig's legacy Animation cover-back to idle queue in Play Mode.
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
public static class UnityCoopCornerQueueAudit
{
    private const string Active = "WarFriends.CornerQueueAudit";
    private const string PrefabPath = "Assets/GameObject/enemy.prefab";
    private static readonly string[] CoverClips =
        { "player_right_coverBack3", "player_left_coverBack3" };
    private static readonly List<object>[] Samples =
        { new List<object>(), new List<object>() };
    private static Animation[] animations;
    private static Collider[][] colliders;
    private static Transform[] roots;
    private static float startTime;

    static UnityCoopCornerQueueAudit()
    {
        if (SessionState.GetBool(Active, false))
            EditorApplication.update += Update;
    }

    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(
                "WAR_COOP_CORNER_QUEUE_OUTPUT")))
            throw new InvalidOperationException(
                "Set WAR_COOP_CORNER_QUEUE_OUTPUT.");
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
            PrefabPath);
        if (prefab == null)
            throw new InvalidOperationException("Missing recovered enemy prefab.");
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        for (int side = 0; side < CoverClips.Length; side++)
        {
            GameObject enemy = (GameObject)PrefabUtility.InstantiatePrefab(
                prefab);
            enemy.name = "CornerQueue" + side;
            for (int pass = 0; pass < 5; pass++)
            {
                MonoBehaviour[] scripts = enemy.GetComponentsInChildren
                    <MonoBehaviour>(true).Where(script => script != null)
                    .ToArray();
                if (scripts.Length == 0)
                    break;
                foreach (MonoBehaviour script in scripts)
                    UnityEngine.Object.DestroyImmediate(script);
            }
            if (enemy.GetComponentsInChildren<MonoBehaviour>(true)
                .Any(script => script != null))
                throw new InvalidOperationException(
                    "Gameplay script remains on the queue probe.");
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
            for (int side = 0; side < CoverClips.Length; side++)
            {
                Transform root = roots[side];
                Animation animation = animations[side];
                Samples[side].Add(new
                {
                    seconds,
                    states = animation.Cast<AnimationState>()
                        .Where(state => state.enabled)
                        .Select(state => new
                        {
                            name = state.name,
                            time = state.time,
                            weight = state.weight
                        }).ToArray(),
                    parts = colliders[side].Select(collider => new
                    {
                        path = RelativePath(root, collider.transform),
                        center = Values(root.InverseTransformPoint(
                            collider.transform.TransformPoint(
                                collider is BoxCollider box
                                    ? box.center
                                    : ((SphereCollider)collider).center))),
                        rotation = Values(Quaternion.Inverse(root.rotation) *
                            collider.transform.rotation)
                    }).ToArray()
                });
            }
            if (seconds < 1f)
                return;
            string output = Environment.GetEnvironmentVariable(
                "WAR_COOP_CORNER_QUEUE_OUTPUT");
            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                version = 1,
                client = "1.4.0",
                unity = Application.unityVersion,
                prefab = PrefabPath,
                prefabSha256 = Hash(PrefabPath),
                captureRate = 30,
                scenarios = Enumerable.Range(0, 2).Select(side => new
                {
                    coverClip = CoverClips[side],
                    coverClipSha256 = Hash("Assets/AnimationClip/" +
                        CoverClips[side] + ".anim"),
                    idleClip = "idle_1",
                    idleClipSha256 = Hash(
                        "Assets/AnimationClip/idle_1.anim"),
                    samples = Samples[side]
                }).ToArray()
            }, Formatting.Indented));
            SessionState.SetBool(Active, false);
            EditorApplication.update -= Update;
            Debug.Log("COOP_CORNER_QUEUE_AUDIT_PASSED");
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
        animations = new Animation[2];
        colliders = new Collider[2][];
        roots = new Transform[2];
        for (int side = 0; side < CoverClips.Length; side++)
        {
            GameObject enemy = GameObject.Find("CornerQueue" + side);
            if (enemy == null)
                throw new InvalidOperationException("Queue probe was lost.");
            roots[side] = enemy.transform;
            Animation animation = enemy.GetComponentInChildren<Animation>(
                true);
            if (animation == null || animation[CoverClips[side]] == null ||
                animation["idle_1"] == null)
                throw new InvalidOperationException(
                    "Recovered queue clips are missing.");
            animations[side] = animation;
            animation.cullingType = AnimationCullingType.AlwaysAnimate;
            animation.Stop();
            animation.Play(CoverClips[side]);
            animation.CrossFadeQueued("idle_1");
            Transform body = enemy.transform.Find(
                "character_assault_1/global_move/cartoon_guyHub001");
            Transform head = enemy.transform.Find(
                "character_assault_1/global_move/cartoon_guyHub001/cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003");
            if (body == null || head == null)
                throw new InvalidOperationException("Missing collision bones.");
            colliders[side] = new Collider[]
            {
                body.GetComponent<BoxCollider>(),
                body.GetComponent<SphereCollider>(),
                head.GetComponent<SphereCollider>()
            };
            if (colliders[side].Any(collider => collider == null))
                throw new InvalidOperationException("Missing source collider.");
        }
        startTime = Time.time;
    }

    private static string RelativePath(Transform root, Transform node)
    {
        if (node == root)
            return "enemy";
        return RelativePath(root, node.parent) + "/" + node.name;
    }

    private static float[] Values(Vector3 value) =>
        new[] { value.x, value.y, value.z };
    private static float[] Values(Quaternion value) =>
        new[] { value.x, value.y, value.z, value.w };

    private static string Hash(string path)
    {
        using (SHA256 sha = SHA256.Create())
            return BitConverter.ToString(sha.ComputeHash(
                File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
    }
}

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

public static class UnityCoopCornerPoseAudit
{
    private const string EnemyPrefab = "Assets/GameObject/enemy.prefab";
    private const int CornerComponentId = 1698;

    public static void Run()
    {
        string pointsPath = Environment.GetEnvironmentVariable(
            "WAR_COOP_CORNER_POINTS");
        string outputPath = Environment.GetEnvironmentVariable(
            "WAR_COOP_CORNER_OUTPUT");
        if (string.IsNullOrEmpty(pointsPath) ||
            string.IsNullOrEmpty(outputPath))
            throw new InvalidOperationException(
                "Set WAR_COOP_CORNER_POINTS and WAR_COOP_CORNER_OUTPUT.");

        JObject points = JObject.Parse(File.ReadAllText(pointsPath));
        JObject map = points["maps"].Children<JObject>().Single(row =>
            (string)row["scene"] == "Desert_New");
        JObject corner = map["points"].Children<JObject>().Single(row =>
            (int)row["componentFileId"] == CornerComponentId);
        Vector3 position = ReadVector(corner["worldPosition"]);
        Vector3 direction = ReadVector(corner["cornerDirection"]);
        if (direction.sqrMagnitude < 0.0001f ||
            Mathf.Abs(direction.y) > 0.0001f)
            throw new InvalidOperationException("Invalid source corner direction.");
        Quaternion rotation = Quaternion.LookRotation(-direction);

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
            EnemyPrefab);
        if (prefab == null)
            throw new InvalidOperationException("Missing source enemy prefab.");
        GameObject enemy = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        try
        {
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            Animation animation = enemy.GetComponentInChildren<Animation>(true);
            if (animation == null || animation["T_pose"] == null ||
                animation["idle_1"] == null)
                throw new InvalidOperationException("Missing source idle rig.");

            Transform body = enemy.transform.Find(
                "character_assault_1/global_move/cartoon_guyHub001");
            Transform head = enemy.transform.Find(
                "character_assault_1/global_move/cartoon_guyHub001/cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003");
            if (body == null || head == null)
                throw new InvalidOperationException("Missing source collision bones.");
            Collider[] colliders =
            {
                body.GetComponent<BoxCollider>(),
                body.GetComponent<SphereCollider>(),
                head.GetComponent<SphereCollider>()
            };
            if (colliders.Any(collider => collider == null))
                throw new InvalidOperationException("Missing source collider.");

            var samples = new List<object>();
            foreach (int afterArrivalTicks in new[] { 15, 21, 30 })
            {
                float seconds = afterArrivalTicks / 30f;
                Sample(animation, "T_pose", 1f);
                Sample(animation, "idle_1", seconds /
                    animation["idle_1"].length);
                Physics.SyncTransforms();
                samples.Add(new
                {
                    afterArrivalTicks,
                    parts = colliders.Select(collider => new
                    {
                        path = PathOf(collider.transform),
                        center = Values(collider.transform.TransformPoint(
                            collider is BoxCollider box
                                ? box.center
                                : ((SphereCollider)collider).center)),
                        rotation = Values(collider.transform.rotation)
                    }).ToArray()
                });
            }
            // Sample the actual NGUI component on this prefab. A fixed
            // target makes its easing and quaternion behavior reproducible.
            enemy.transform.rotation = rotation;
            Quaternion turnTarget = Quaternion.Euler(0f, -45f, 0f);
            TweenRotation turn = TweenRotation.Begin(enemy, 0.3f,
                turnTarget);
            // In this Edit Mode audit, AddComponent can reset local rotation
            // before Begin reads it. Pin the source state explicitly.
            turn.from = rotation.eulerAngles;
            enemy.transform.rotation = rotation;
            var turnSamples = new List<object>();
            for (int turnTick = 0; turnTick <= 9; turnTick++)
            {
                turn.Sample(turnTick / 9f, turnTick == 9);
                turnSamples.Add(new
                {
                    tick = turnTick,
                    rotation = Values(enemy.transform.rotation)
                });
            }
            string lookClip = (bool)corner["cornerRightSide"]
                ? "player_look_right3" : "player_look_left3";
            if (animation[lookClip] == null)
                throw new InvalidOperationException("Missing source look clip.");
            var uncoverSamples = new List<object>();
            foreach (int uncoverTick in new[] { 1, 4, 8, 9, 12, 15 })
            {
                float seconds = uncoverTick / 30f;
                Sample(animation, "T_pose", 1f);
                Sample(animation, lookClip, seconds /
                    animation[lookClip].length);
                turn.Sample(Mathf.Min(uncoverTick / 9f, 1f),
                    uncoverTick >= 9);
                Physics.SyncTransforms();
                uncoverSamples.Add(new
                {
                    tick = uncoverTick,
                    parts = colliders.Select(collider => new
                    {
                        path = PathOf(collider.transform),
                        center = Values(collider.transform.TransformPoint(
                            collider is BoxCollider box
                                ? box.center
                                : ((SphereCollider)collider).center)),
                        rotation = Values(collider.transform.rotation)
                    }).ToArray()
                });
            }
            string fireClip = (bool)corner["cornerRightSide"]
                ? "player_fire_right3" : "player_fire_left3";
            if (animation[fireClip] == null)
                throw new InvalidOperationException("Missing source fire clip.");
            var fireSamples = new List<object>();
            foreach (int shotTick in new[] { 16, 17, 20, 21 })
            {
                float fireSeconds = shotTick / 30f -
                    animation[lookClip].length;
                Sample(animation, "T_pose", 1f);
                Sample(animation, fireClip, fireSeconds /
                    animation[fireClip].length);
                turn.Sample(1f, true);
                Physics.SyncTransforms();
                fireSamples.Add(new
                {
                    tick = shotTick,
                    fireSeconds,
                    parts = colliders.Select(collider => new
                    {
                        path = PathOf(collider.transform),
                        center = Values(collider.transform.TransformPoint(
                            collider is BoxCollider box
                                ? box.center
                                : ((SphereCollider)collider).center)),
                        rotation = Values(collider.transform.rotation)
                    }).ToArray()
                });
            }
            string coverBackClip = (bool)corner["cornerRightSide"]
                ? "player_right_coverBack3" : "player_left_coverBack3";
            if (animation[coverBackClip] == null)
                throw new InvalidOperationException("Missing source cover-back clip.");
            var coverBackSamples = new List<object>();
            foreach (int coverTick in new[] { 22, 23, 28, 35 })
            {
                float coverSeconds = (coverTick - 22) / 30f;
                Sample(animation, "T_pose", 1f);
                Sample(animation, coverBackClip, coverSeconds /
                    animation[coverBackClip].length);
                turn.Sample(1f, true);
                Physics.SyncTransforms();
                coverBackSamples.Add(new
                {
                    tick = coverTick,
                    parts = colliders.Select(collider => new
                    {
                        path = PathOf(collider.transform),
                        center = Values(collider.transform.TransformPoint(
                            collider is BoxCollider box
                                ? box.center
                                : ((SphereCollider)collider).center)),
                        rotation = Values(collider.transform.rotation)
                    }).ToArray()
                });
            }
            File.WriteAllText(outputPath, JsonConvert.SerializeObject(new
            {
                version = 1,
                client = "1.4.0",
                prefab = EnemyPrefab,
                prefabSha256 = Hash(EnemyPrefab),
                scene = (string)map["scene"],
                sceneSha256 = (string)map["sceneSha256"],
                pointComponentFileId = CornerComponentId,
                position = Values(position),
                rotation = Values(rotation),
                samples,
                turnTarget = Values(turnTarget),
                turnSamples,
                lookClip,
                uncoverSamples,
                fireClip,
                fireSamples,
                coverBackClip,
                coverBackSamples
            }, Formatting.Indented));
            Debug.Log("COOP_CORNER_POSE_AUDIT_PASSED samples=" +
                samples.Count);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(enemy);
        }
    }

    private static void Sample(Animation animation, string name, float time)
    {
        AnimationState state = animation[name];
        animation.Stop();
        state.enabled = true;
        state.weight = 1;
        state.normalizedTime = time;
        animation.Sample();
        state.enabled = false;
    }

    private static Vector3 ReadVector(JToken values) => new Vector3(
        (float)values[0], (float)values[1], (float)values[2]);
    private static float[] Values(Vector3 value) => new[]
        { value.x, value.y, value.z };
    private static float[] Values(Quaternion value) => new[]
        { value.x, value.y, value.z, value.w };
    private static string PathOf(Transform node) => node.parent == null
        ? node.name : PathOf(node.parent) + "/" + node.name;
    private static string Hash(string path)
    {
        using (SHA256 sha = SHA256.Create())
            return BitConverter.ToString(sha.ComputeHash(
                File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
    }
}

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Reference-pose evidence only: does not pretend a serialized pose is an animated
// combat stance. No scene or prefab is saved.
public static class SelfHostedPlayerCollisionExport
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_PLAYER_COLLISION_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new InvalidOperationException("Set WAR_PLAYER_COLLISION_OUTPUT.");
        var previous = EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source = "Assets/Scenes/MainScene.unity";
            var scene = EditorSceneManager.OpenScene(source);
            var players = scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<PlayerController>(true)).ToArray();
            var controller = scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<GameController>(true)).Single();
            var models = new List<object>();
            foreach (var player in players)
            {
                var parts = player.GetComponentsInChildren<DestroyableObjectpart>(true);
                var rows = new List<object>();
                foreach (var part in parts)
                foreach (var collider in part.GetComponents<Collider>())
                {
                    var box = collider as BoxCollider;
                    var capsule = collider as CapsuleCollider;
                    var sphere = collider as SphereCollider;
                    if (box == null && capsule == null && sphere == null) throw new InvalidOperationException("Unsupported player collider " + collider.GetType());
                    // World shapes preserve Unity's actual lossyScale behavior.
                    var scale = collider.transform.lossyScale;
                    Vector3 absScale = new Vector3(Mathf.Abs(scale.x), Mathf.Abs(scale.y), Mathf.Abs(scale.z));
                    Vector3 center = collider.transform.TransformPoint(box != null ? box.center : capsule != null ? capsule.center : sphere.center);
                    Vector3 size = box != null ? Vector3.Scale(box.size, absScale) : Vector3.zero;
                    float radius = sphere != null ? sphere.radius * Mathf.Max(absScale.x, Mathf.Max(absScale.y, absScale.z)) : 0;
                    Vector3 axis = Vector3.zero;
                    float halfSegment = 0;
                    if (capsule != null)
                    {
                        int d = capsule.direction;
                        var localAxis = d == 0 ? Vector3.right : d == 1 ? Vector3.up : Vector3.forward;
                        axis = collider.transform.rotation * localAxis;
                        radius = capsule.radius * Mathf.Max(absScale[(d+1)%3], absScale[(d+2)%3]);
                        halfSegment = Mathf.Max(0, capsule.height * absScale[d] * 0.5f - radius);
                    }
                    // Clone only the collider for reference raycasts. Player rigs
                    // can be inactive, and ragdoll overlap must not choose the hit.
                    var probe = new GameObject("CollisionReferenceProbe");
                    var rays = new List<object>();
                    try
                    {
                        probe.transform.position = center;
                        probe.transform.rotation = collider.transform.rotation;
                        Collider copy;
                        if (box != null) { var c = probe.AddComponent<BoxCollider>(); c.size = size; copy = c; }
                        else if (capsule != null) { var c = probe.AddComponent<CapsuleCollider>(); c.direction = capsule.direction; c.radius = radius; c.height = 2*(halfSegment+radius); copy = c; }
                        else { var c = probe.AddComponent<SphereCollider>(); c.radius = radius; copy = c; }
                        Physics.SyncTransforms();
                        var directions = new[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.forward, Vector3.back, new Vector3(1,1,1).normalized, new Vector3(-1,1,1).normalized };
                        foreach (var direction in directions)
                        {
                            Vector3 origin = center + direction * 5;
                            RaycastHit hit;
                            bool found = copy.Raycast(new Ray(origin, -direction), out hit, 10);
                            rays.Add(new { origin = V(origin), direction = V(-direction), distance = 10, hit = found, hitDistance = found ? hit.distance : 0 });
                        }
                    }
                    finally { UnityEngine.Object.DestroyImmediate(probe); }
                    rows.Add(new { path = PathOf(collider.transform), type = collider.GetType().Name, weight = part.weight,
                        enabled = collider.enabled, active = collider.gameObject.activeInHierarchy, trigger = collider.isTrigger,
                        center = V(center), size = V(size), rotation = Q(collider.transform.rotation), radius = radius,
                        axis = V(axis), halfSegment = halfSegment, rays = rays });
                }
                models.Add(new { path = PathOf(player.transform), role = player == controller.mainPlayerController ? "gameplay" : "preview",
                    position = V(player.transform.position), rotation = Q(player.transform.rotation), parts = rows });
            }
            if (models.Count == 0) throw new InvalidOperationException("No recovered player collision models.");
            string digest;
            using (var sha = SHA256.Create()) digest = BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-", "").ToLowerInvariant();
            File.WriteAllText(output, JsonConvert.SerializeObject(new { client = "1.4.0", source = source, sha256 = digest,
                pose = "serialized-reference-only", models = models }, Formatting.Indented));
            Debug.Log("PLAYER_COLLISION_EXPORT_PASSED models=" + models.Count);
        }
        finally
        {
            if (previous.Any(s => s.isLoaded && s.isActive) && previous.All(s => !string.IsNullOrEmpty(s.path))) EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static float[] V(Vector3 v) { return new[] { v.x, v.y, v.z }; }
    private static float[] Q(Quaternion q) { return new[] { q.x, q.y, q.z, q.w }; }
    private static string PathOf(Transform t) { return t.parent == null ? t.name : PathOf(t.parent) + "/" + t.name; }
}

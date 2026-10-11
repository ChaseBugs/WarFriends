using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Disposable Editor measurement. No gameplay MonoBehaviour or Photon room runs.
public static class UnityParachuteFallExport
{
    public static void Run()
    {
        string input = Environment.GetEnvironmentVariable("WAR_PARACHUTE_SPAWNS_INPUT");
        string output = Environment.GetEnvironmentVariable("WAR_PARACHUTE_FALL_OUTPUT");
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(output))
            throw new InvalidOperationException("Set parachute spawn input and output paths.");

        const string prefabPath = "Assets/GameObject/parachute.prefab";
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null || prefab.GetComponent<Rigidbody>() == null ||
            prefab.GetComponentsInChildren<BoxCollider>(true).Length != 2)
            throw new InvalidOperationException("Recovered parachute prefab is incomplete.");
        Rigidbody sourceBody = prefab.GetComponent<Rigidbody>();
        MonoBehaviour parachuteScript = prefab.GetComponents<MonoBehaviour>()
            .Single(component => component != null &&
                component.GetType().Name == "Parachute");
        var parachuteFields = new SerializedObject(parachuteScript);
        BoxCollider[] sourceColliders = prefab
            .GetComponentsInChildren<BoxCollider>(true)
            .OrderBy(collider => collider.size.x).ToArray();

        bool previousAutoSimulation = Physics.autoSimulation;
        SceneSetup[] previousScenes = EditorSceneManager.GetSceneManagerSetup();
        var maps = new List<object>();
        try
        {
            Physics.autoSimulation = false;
            foreach (JToken mapRow in JObject.Parse(File.ReadAllText(input))["maps"])
            {
                string scenePath = (string)mapRow["source"];
                if (Digest(scenePath) != (string)mapRow["sha256"])
                    throw new InvalidOperationException("Scene digest changed: " + scenePath);
                EditorSceneManager.OpenScene(scenePath);
                Physics.SyncTransforms();
                var falls = new List<object>();
                foreach (JToken spawn in mapRow["points"].Where(point =>
                    (string)point["collection"] == "spawnPointsCollection" &&
                    (string)point["componentType"] == "SpawnPointParachute"))
                {
                    Vector3 sourcePosition = Vector(spawn["worldPosition"]);
                    Transform sourceTransform = FindSpawnTransform(sourcePosition);
                    GameObject bodyObject = MakeBody(prefab);
                    try
                    {
                        bodyObject.transform.SetPositionAndRotation(
                            sourceTransform.position, sourceTransform.rotation);
                        Rigidbody body = bodyObject.GetComponent<Rigidbody>();
                        body.velocity = Vector3.zero;
                        body.angularVelocity = Vector3.zero;
                        Physics.SyncTransforms();
                        Vector3 forward = sourceTransform.forward;
                        var frames = new List<object>();
                        object[] nearbyAtFirstImpulse = null;
                        int firstImpulseFrame = -1;
                        for (int frame = 0; frame <= 600; frame++)
                        {
                            frames.Add(new
                            {
                                frame,
                                position = Array(body.position),
                                velocity = Array(body.velocity),
                                rotation = new[] { body.rotation.x, body.rotation.y,
                                    body.rotation.z, body.rotation.w },
                                sleeping = body.IsSleeping()
                            });
                            if (frame == 600)
                                break;
                            float time = frame * Time.fixedDeltaTime;
                            float swaySign = (int)(time * 0.5f) % 2 == 0 ? 1f : -1f;
                            Vector3 desiredUp = (Vector3.up + 0.3f * swaySign *
                                Vector3.Cross(Vector3.up, forward)).normalized;
                            float tilt = Vector3.Angle(desiredUp,
                                bodyObject.transform.up) / 180f;
                            Vector3 torque = Vector3.Cross(Vector3.up, desiredUp) *
                                5f * tilt - body.angularVelocity;
                            Vector3 previousVelocity = body.velocity;
                            body.AddTorque(torque, ForceMode.VelocityChange);
                            body.AddForce(forward * 115f * 0.2f);
                            Physics.Simulate(Time.fixedDeltaTime);
                            Vector3 expectedVelocity = (previousVelocity +
                                (forward * 23f + Physics.gravity) *
                                Time.fixedDeltaTime) * 0.8f;
                            if (firstImpulseFrame < 0 &&
                                Vector3.Distance(expectedVelocity, body.velocity) > 0.01f)
                            {
                                firstImpulseFrame = frame + 1;
                                nearbyAtFirstImpulse = Physics.OverlapSphere(
                                    body.position, 2f, ~0,
                                    QueryTriggerInteraction.Ignore)
                                    .Where(collider => collider.transform.root !=
                                        bodyObject.transform)
                                    .Select(collider => new
                                    {
                                        path = HierarchyPath(collider.transform),
                                        type = collider.GetType().Name,
                                        layer = collider.gameObject.layer,
                                        distance = Vector3.Distance(body.position,
                                            collider.bounds.ClosestPoint(body.position))
                                    })
                                    .OrderBy(row => row.distance)
                                    .ThenBy(row => row.path, StringComparer.Ordinal)
                                    .Take(20).Cast<object>().ToArray();
                            }
                        }
                        falls.Add(new
                        {
                            componentFileId = (int)spawn["componentFileId"],
                            fraction = (int)spawn["fraction"],
                            origin = Array(sourcePosition),
                            forward = Array(forward),
                            firstImpulseFrame,
                            nearbyAtFirstImpulse,
                            frames
                        });
                    }
                    finally { UnityEngine.Object.DestroyImmediate(bodyObject); }
                }
                maps.Add(new { source = scenePath, sha256 = (string)mapRow["sha256"],
                    falls });
            }
            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                version = 1,
                unityVersion = Application.unityVersion,
                scenario = "parachute-prefab-force-and-scene-contact",
                prefabPath,
                prefabSha256 = Digest(prefabPath),
                prefabPhysics = new
                {
                    parachuteDrag = parachuteFields.FindProperty(
                        "parachuteDrag").floatValue,
                    speed = parachuteFields.FindProperty("speed").floatValue,
                    m_Mass = sourceBody.mass,
                    m_Drag = sourceBody.drag,
                    m_AngularDrag = sourceBody.angularDrag,
                    m_UseGravity = sourceBody.useGravity ? 1 : 0,
                    m_IsKinematic = sourceBody.isKinematic ? 1 : 0,
                    m_CollisionDetection = (int)sourceBody.collisionDetectionMode,
                    m_Size = sourceColliders.Select(collider =>
                        Array(collider.size)).ToArray(),
                    m_Center = sourceColliders.Select(collider =>
                        Array(collider.center)).ToArray()
                },
                fixedTimestep = Time.fixedDeltaTime,
                gravity = Array(Physics.gravity),
                maps
            }, Formatting.Indented) + "\n");
            Debug.Log("WAR_PARACHUTE_FALL_EXPORT_PASS");
        }
        finally
        {
            Physics.autoSimulation = previousAutoSimulation;
            if (previousScenes.Any(scene => scene.isLoaded) &&
                previousScenes.Any(scene => scene.isActive))
                EditorSceneManager.RestoreSceneManagerSetup(previousScenes);
            else
                EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        }
    }

    private static GameObject MakeBody(GameObject prefab)
    {
        var bodyObject = new GameObject("Parachute physics probe");
        bodyObject.layer = 15;
        Rigidbody body = bodyObject.AddComponent<Rigidbody>();
        EditorUtility.CopySerialized(prefab.GetComponent<Rigidbody>(), body);
        foreach (BoxCollider source in prefab.GetComponentsInChildren<BoxCollider>(true))
        {
            var child = new GameObject(source.name);
            child.layer = source.gameObject.layer;
            child.transform.SetParent(bodyObject.transform, false);
            child.transform.localPosition = source.transform.localPosition;
            child.transform.localRotation = source.transform.localRotation;
            child.transform.localScale = source.transform.localScale;
            BoxCollider collider = child.AddComponent<BoxCollider>();
            collider.center = source.center;
            collider.size = source.size;
            collider.isTrigger = source.isTrigger;
            collider.enabled = source.enabled;
        }
        return bodyObject;
    }

    private static Transform FindSpawnTransform(Vector3 position)
    {
        Transform[] matches = UnityEngine.Object.FindObjectsOfType<Transform>()
            .Where(transform => (transform.position - position).sqrMagnitude < 0.0001f &&
                transform.GetComponents<Component>().Any(component =>
                    component != null && component.GetType().Name == "SpawnPointParachute"))
            .ToArray();
        if (matches.Length != 1)
            throw new InvalidOperationException("Cannot bind source parachute spawn transform.");
        return matches[0];
    }

    private static string HierarchyPath(Transform transform)
    {
        var names = new List<string>();
        for (Transform current = transform; current != null;
             current = current.parent)
            names.Add(current.name);
        names.Reverse();
        return string.Join("/", names.ToArray());
    }

    private static Vector3 Vector(JToken values)
    {
        return new Vector3((float)values[0], (float)values[1], (float)values[2]);
    }

    private static float[] Array(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static string Digest(string path)
    {
        using (SHA256 sha = SHA256.Create())
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
    }
}

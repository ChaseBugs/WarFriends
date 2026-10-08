using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// Samples direct Collider.Raycast results from native co-op scene components.
/// Run in a disposable Unity 2018 project; no scene or asset is saved.
/// </summary>
public static class CoopSceneRayReferenceExport
{
    public static void Run()
    {
        string manifestPath = Environment.GetEnvironmentVariable(
            "WAR_COOP_COLLIDER_MANIFEST");
        string outputPath = Environment.GetEnvironmentVariable(
            "WAR_COOP_RAY_OUTPUT");
        if (string.IsNullOrEmpty(manifestPath) ||
            string.IsNullOrEmpty(outputPath))
            throw new InvalidOperationException(
                "Set WAR_COOP_COLLIDER_MANIFEST and WAR_COOP_RAY_OUTPUT.");
        JObject source = JObject.Parse(File.ReadAllText(manifestPath));
        var previous = EditorSceneManager.GetSceneManagerSetup();
        var maps = new List<object>();
        try
        {
            foreach (JToken map in source["maps"])
            {
                string name = (string)map["scene"];
                var scene = EditorSceneManager.OpenScene(
                    "Assets/Scenes/" + name + ".unity");
                JToken[] expected = map["colliders"].ToArray();
                var rows = new List<object>();
                var found = new HashSet<long>();
                foreach (Collider collider in scene.GetRootGameObjects()
                    .SelectMany(root => root.GetComponentsInChildren<Collider>(true)))
                {
                    JToken[] candidates = expected.Where(item =>
                        !found.Contains((long)item["componentFileId"]) &&
                        SameSource(collider, item)).OrderBy(item =>
                        Vector3.SqrMagnitude(collider.transform.position -
                            Vector(item["worldPosition"]))).ToArray();
                    if (candidates.Length == 0)
                        continue;
                    JToken manifest = candidates[0];
                    float distance = Vector3.Distance(
                        collider.transform.position,
                        Vector(manifest["worldPosition"]));
                    if (distance > 0.25f)
                        continue;
                    if (candidates.Length > 1 &&
                        Mathf.Abs(distance - Vector3.Distance(
                            collider.transform.position,
                            Vector(candidates[1]["worldPosition"]))) < 0.001f)
                        throw new InvalidOperationException(
                            "Ambiguous native collider " + name + "/" + collider.name);
                    long fileId = (long)manifest["componentFileId"];
                    if (!found.Add(fileId))
                        throw new InvalidOperationException(
                            "Duplicate native collider " + fileId);
                    if (!collider.enabled || !collider.gameObject.activeInHierarchy ||
                        collider.isTrigger || collider is MeshCollider &&
                        ((MeshCollider)collider).sharedMesh == null)
                        continue;
                    Bounds bounds = collider.bounds;
                    float offset = Mathf.Max(bounds.extents.magnitude + 1f, 2f);
                    Vector3[] axes = { Vector3.right, Vector3.up, Vector3.forward };
                    foreach (Vector3 axis in axes)
                    foreach (float side in new[] { -1f, 1f })
                    {
                        Vector3 origin = bounds.center + axis * side * offset;
                        Vector3 direction = -axis * side;
                        float range = offset * 2f;
                        RaycastHit hit;
                        bool foundHit = collider.Raycast(
                            new Ray(origin, direction), out hit, range);
                        rows.Add(new
                        {
                            componentFileId = fileId,
                            origin = Vector(origin),
                            direction = Vector(direction),
                            maxDistance = range,
                            hit = foundHit,
                            distance = foundHit ? hit.distance : 0f,
                            point = foundHit ? Vector(hit.point) : null
                        });
                    }
                }
                if (found.Count != expected.Length)
                    throw new InvalidOperationException(
                        "Unity did not resolve every native collider in " + name +
                        ": " + found.Count + "/" + expected.Length);
                maps.Add(new { scene = name, rays = rows });
            }
            Directory.CreateDirectory(Path.GetDirectoryName(
                Path.GetFullPath(outputPath)));
            File.WriteAllText(outputPath, JsonConvert.SerializeObject(new
            {
                version = 1,
                client = "1.4.0",
                unity = Application.unityVersion,
                maps
            }, Formatting.Indented));
            Debug.Log("COOP_SCENE_RAYS_EXPORTED maps=" + maps.Count +
                " output=" + outputPath);
        }
        finally
        {
            if (previous.Length > 0 && previous.All(
                    setup => !string.IsNullOrEmpty(setup.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else
                EditorSceneManager.NewScene(
                    NewSceneSetup.EmptyScene, NewSceneMode.Single);
        }
    }

    private static float[] Vector(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static Vector3 Vector(JToken value)
    {
        return new Vector3((float)value[0], (float)value[1], (float)value[2]);
    }

    private static bool SameSource(Collider collider, JToken source)
    {
        if (collider.GetType().Name != (string)source["componentType"] ||
            collider.gameObject.name != (string)source["gameObjectName"] ||
            collider.gameObject.layer != (int)source["layer"] ||
            collider.gameObject.activeSelf != (bool)source["active"] ||
            collider.gameObject.activeInHierarchy !=
                (bool)source["activeInHierarchy"] ||
            collider.enabled != (bool)source["enabled"] ||
            collider.isTrigger != (bool)source["trigger"])
            return false;
        JToken shape = source["shape"];
        MeshCollider mesh = collider as MeshCollider;
        if (mesh != null)
        {
            if (mesh.convex != (bool)shape["convex"])
                return false;
            if (mesh.sharedMesh == null)
                return (int)shape["meshFileId"] == 0;
            string guid;
            long fileId;
            return AssetDatabase.TryGetGUIDAndLocalFileIdentifier(
                mesh.sharedMesh, out guid, out fileId) &&
                guid == (string)shape["meshGuid"] &&
                fileId == (long)shape["meshFileId"];
        }
        BoxCollider box = collider as BoxCollider;
        if (box != null)
            return Vector3.Distance(box.center, Vector(shape["center"])) <
                       0.0001f &&
                   Vector3.Distance(box.size, Vector(shape["size"])) <
                       0.0001f;
        CapsuleCollider capsule = collider as CapsuleCollider;
        return capsule != null &&
            Vector3.Distance(capsule.center, Vector(shape["center"])) <
                0.0001f &&
            Mathf.Abs(capsule.radius - (float)shape["radius"]) < 0.0001f &&
            Mathf.Abs(capsule.height - (float)shape["height"]) < 0.0001f &&
            capsule.direction == (int)shape["direction"];
    }
}

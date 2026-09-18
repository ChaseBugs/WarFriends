using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Read-only export of recovered scene-bound battle content. No scene or
/// prefab is saved. Values keep their source identity/order; no balancing defaults.</summary>
public static class SelfHostedBattleExport
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_BATTLE_CONTENT_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new InvalidOperationException("Set WAR_BATTLE_CONTENT_OUTPUT.");
        var previous = EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var scenes = new List<object>();
            var meshes = new Dictionary<string, object>();
            foreach (string path in Directory.GetFiles("Assets/Scenes", "*_Multiplayer.unity").OrderBy(x => x, StringComparer.Ordinal))
            {
                var scene = EditorSceneManager.OpenScene(path);
                var maps = scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<MapDefinition>(true)).ToArray();
                if (maps.Length != 1) throw new InvalidOperationException("Expected one map definition: " + path);
                MapDefinition map = maps[0];
                var points = new List<object>();
                for (int i = 0; i < map.playersPositions.Count; i++)
                {
                    var point = map.playersPositions[i];
                    if (point.point == null || point.point.shield == null) throw new InvalidOperationException("Unresolved player point in " + path);
                    points.Add(new {
                        sourceIndex = i, fraction = (int)point.fraction, main = point.mainPosition,
                        path = Hierarchy(point.point.transform), position = Vector(point.point.transform.position),
                        rotation = Rotation(point.point.transform.rotation),
                        shotPosition = point.point.shield.shotPosition == null ? null : Vector(point.point.shield.shotPosition.position),
                        shieldBaseHealth = (float)point.point.shield.maxHealth
                    });
                }
                var colliders = new List<object>();
                foreach (var collider in scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<Collider>(true)))
                {
                    // Preserve shape and transform, rather than substituting a world AABB.
                    var box = collider as BoxCollider;
                    var sphere = collider as SphereCollider;
                    var capsule = collider as CapsuleCollider;
                    var mesh = collider as MeshCollider;
                    string meshId = null;
                    if (mesh != null && mesh.sharedMesh != null)
                    {
                        string guid; long fileId;
                        if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(mesh.sharedMesh, out guid, out fileId))
                            throw new InvalidOperationException("Mesh identity unavailable: " + Hierarchy(mesh.transform));
                        meshId = guid + ":" + fileId.ToString(CultureInfo.InvariantCulture);
                        if (!meshes.ContainsKey(meshId)) meshes.Add(meshId, new {
                            source = AssetDatabase.GetAssetPath(mesh.sharedMesh),
                            vertices = mesh.sharedMesh.vertices.Select(Vector).ToArray(), triangles = mesh.sharedMesh.triangles
                        });
                    }
                    colliders.Add(new {
                        path = Hierarchy(collider.transform), type = collider.GetType().Name,
                        layer = collider.gameObject.layer, enabled = collider.enabled,
                        active = collider.gameObject.activeInHierarchy, trigger = collider.isTrigger,
                        matrix = Matrix(collider.transform.localToWorldMatrix),
                        boxCenter = box == null ? null : Vector(box.center), boxSize = box == null ? null : Vector(box.size),
                        sphereCenter = sphere == null ? null : Vector(sphere.center), sphereRadius = sphere == null ? 0 : sphere.radius,
                        capsuleCenter = capsule == null ? null : Vector(capsule.center), capsuleRadius = capsule == null ? 0 : capsule.radius,
                        capsuleHeight = capsule == null ? 0 : capsule.height, capsuleDirection = capsule == null ? 0 : capsule.direction,
                        meshAsset = mesh == null || mesh.sharedMesh == null ? null : AssetDatabase.GetAssetPath(mesh.sharedMesh),
                        meshId = meshId,
                        meshConvex = mesh != null && mesh.convex,
                        dynamicOwner = collider.GetComponentInParent<DestroyableObject>() == null ? null : Hierarchy(collider.GetComponentInParent<DestroyableObject>().transform)
                    });
                }
                var paths = new List<object>();
                for (int from = 0; from < map.playersPositions.Count; from++)
                    foreach (int direction in new[] { -1, 1 })
                    {
                        int to = from + direction;
                        while (to >= 0 && to < map.playersPositions.Count && map.playersPositions[to].fraction != map.playersPositions[from].fraction) to += direction;
                        if (to < 0 || to >= map.playersPositions.Count) continue;
                        var nav = new UnityEngine.AI.NavMeshPath();
                        bool found = UnityEngine.AI.NavMesh.CalculatePath(map.playersPositions[from].point.transform.position, map.playersPositions[to].point.transform.position, UnityEngine.AI.NavMesh.AllAreas, nav);
                        paths.Add(new { from = from, to = to, complete = found && nav.status == UnityEngine.AI.NavMeshPathStatus.PathComplete, corners = nav.corners.Select(Vector).ToArray() });
                    }
                var validationRays = new List<object>();
                Physics.SyncTransforms();
                foreach (var point in map.playersPositions)
                {
                    AddRay(validationRays, point.point.transform.position + Vector3.up * 2, Vector3.down, 10);
                    foreach (var target in map.playersPositions)
                    {
                        if (target.fraction == point.fraction) continue;
                        Vector3 origin = point.point.shield.shotPosition.position;
                        Vector3 destination = target.point.shield.shotPosition.position;
                        AddRay(validationRays, origin, (destination-origin).normalized, Vector3.Distance(origin,destination)+1);
                    }
                }
                scenes.Add(new { source = path.Replace('\\','/'), sha256 = Hash(path), levelName = map.levelName, points = points, colliders = colliders, paths = paths, validationRays = validationRays });
            }
            var main = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var sheets = new List<object>();
            foreach (var component in main.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<MonoBehaviour>(true)))
            {
                if (component == null || component.GetType().Namespace != "Google2u") continue;
                FieldInfo rowsField = component.GetType().GetField("Rows");
                if (rowsField == null) continue;
                var rows = rowsField.GetValue(component) as IEnumerable;
                if (rows == null) continue;
                var values = new List<object>();
                foreach (object row in rows)
                {
                    var fields = new Dictionary<string, object>();
                    foreach (FieldInfo field in row.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public))
                    {
                        object value = field.GetValue(row);
                        if (field.FieldType.Name == "ObscuredInt") value = int.Parse(value.ToString(), CultureInfo.InvariantCulture);
                        else if (field.FieldType.Name == "ObscuredFloat") value = float.Parse(value.ToString(), CultureInfo.InvariantCulture);
                        fields.Add(field.Name, value);
                    }
                    values.Add(fields);
                }
                sheets.Add(new { type = component.GetType().FullName, path = Hierarchy(component.transform), rows = values });
            }
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(output)));
            File.WriteAllText(output, JsonConvert.SerializeObject(new {
                client = "1.4.0", unity = Application.unityVersion, mainSceneSha256 = Hash("Assets/Scenes/MainScene.unity"),
                maps = scenes, meshes = meshes, sheets = sheets,
                limitation = "Exported geometry/navigation requires validation before authoritative use. Shield health is serialized base health, not a final loadout calculation."
            }, Formatting.Indented));
            Debug.Log("BATTLE_CONTENT_EXPORTED maps=" + scenes.Count + " sheets=" + sheets.Count + " output=" + output);
        }
        finally
        {
            if (previous.Length > 0 && previous.All(s => !string.IsNullOrEmpty(s.path))) EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        }
    }
    private static float[] Vector(Vector3 v) { return new[] { v.x, v.y, v.z }; }
    private static void AddRay(List<object> rays, Vector3 origin, Vector3 direction, float distance)
    {
        RaycastHit hit;
        bool found = Physics.Raycast(origin, direction, out hit, distance, ~0, QueryTriggerInteraction.Ignore);
        rays.Add(new { origin = Vector(origin), direction = Vector(direction), distance = distance, hit = found,
            hitDistance = found ? hit.distance : 0, hitPath = found ? Hierarchy(hit.collider.transform) : null });
    }
    private static float[] Rotation(Quaternion q) { return new[] { q.x, q.y, q.z, q.w }; }
    private static float[] Matrix(Matrix4x4 m) { var values = new float[16]; for (int i = 0; i < 16; i++) values[i] = m[i]; return values; }
    private static string Hierarchy(Transform t) { return t.parent == null ? t.name : Hierarchy(t.parent) + "/" + t.name; }
    private static string Hash(string path) { using (var hash = SHA256.Create()) return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant(); }
}

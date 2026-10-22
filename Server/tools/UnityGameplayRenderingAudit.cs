using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks every authored gameplay scene and its default dynamic shield geometry.</summary>
public static class UnityGameplayRenderingAudit
{
    public sealed class SceneEntry
    {
        public string scene;
        public string batchRootId;
        public int shields;
        public UnityDesertRenderingAudit.Entry[] staticRenderers;
    }

    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use an owned disposable project.");
        }
        string output = Environment.GetEnvironmentVariable("WAR_GAMEPLAY_RENDER_OUTPUT");
        SceneEntry[] scenes = JsonConvert.DeserializeObject<SceneEntry[]>(
            File.ReadAllText(Path.Combine(output, "manifest.json")));
        foreach (string path in new[] {"Assets/Shader/T4M 4 Textures.shader", "Assets/Shader/T4M 4 Textures_Aztec.shader"})
        {
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        }
        var results = new List<object>();
        foreach (SceneEntry entry in scenes)
        {
            results.Add(VerifyScene(entry, output));
        }
        File.WriteAllText(Path.Combine(output, "scene-report.json"), JsonConvert.SerializeObject(results, Formatting.Indented));
        Debug.Log("GAMEPLAY_RENDER_AUDIT_PASS scenes=" + scenes.Length);
        EditorApplication.Exit(0);
    }

    private static object VerifyScene(SceneEntry entry, string output)
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/" + entry.scene + ".unity");
        GameObject[] roots = scene.GetRootGameObjects();
        if (roots.SelectMany(root => root.GetComponentsInChildren<Component>(true)).Any(component => component == null))
        {
            throw new InvalidOperationException("Missing script in " + entry.scene);
        }
        MeshRenderer[] renderers = roots.SelectMany(root => root.GetComponentsInChildren<MeshRenderer>(true)).ToArray();
        Dictionary<string, MeshRenderer> byPath = renderers.ToDictionary(renderer => PathOf(renderer.transform));
        foreach (UnityDesertRenderingAudit.Entry expected in entry.staticRenderers)
        {
            MeshRenderer renderer = byPath[expected.Path];
            if (!renderer.isPartOfStaticBatch || renderer.subMeshStartIndex != expected.Subsets[0])
            {
                throw new InvalidOperationException("Invalid recovered submesh in " + expected.Path);
            }
            var serialized = new SerializedObject(renderer);
            Transform batchRoot = (Transform)serialized.FindProperty("m_StaticBatchRoot").objectReferenceValue;
            if (batchRoot == null || !IsIdentity(batchRoot.localToWorldMatrix))
            {
                throw new InvalidOperationException("Baked world-space geometry has a nonidentity batch root.");
            }
        }
        Shield[] shields = roots.SelectMany(root => root.GetComponentsInChildren<Shield>(true)).ToArray();
        ValidateShields(shields, entry.shields);
        foreach (Shield shield in shields) ValidateShieldPixels(shield);
        MapDefinition map = roots.SelectMany(root => root.GetComponentsInChildren<MapDefinition>(true)).Single();
        CaptureScene(map, Path.Combine(output, entry.scene + ".png"));

        Material[] materials = renderers.SelectMany(renderer => renderer.sharedMaterials)
            .Where(material => material != null).Distinct().ToArray();
        ValidateShaders(materials);
        return new {
            entry.scene, staticRenderers = entry.staticRenderers.Length,
            dynamicShields = shields.Length, shieldModel = shields[0].GetComponent<MeshFilter>().sharedMesh.name,
            shaderErrors = 0, missingScripts = 0, shieldPixelChecks = shields.Length,
            shieldGeometry = DescribeShield(shields[0])
        };
    }

    private static object DescribeShield(Shield shield)
    {
        Mesh mesh = shield.GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;
        int[] indices = mesh.GetTriangles(0);
        var actual = new Bounds(vertices[0], Vector3.zero);
        foreach (Vector3 vertex in vertices) actual.Encapsulate(vertex);
        return new {
            vertices = vertices.Length, indices = indices.Length,
            distinctVertices = vertices.Distinct().Count(),
            firstVertices = vertices.Take(3).Select(vertex => vertex.ToString()).ToArray(),
            indexRange = new[] {indices.Min(), indices.Max()},
            storedBounds = mesh.bounds.ToString(), actualBounds = actual.ToString(),
            worldBounds = shield.GetComponent<Renderer>().bounds.ToString()
        };
    }

    private static void ValidateShields(Shield[] shields, int expected)
    {
        if (shields.Length != expected)
        {
            throw new InvalidOperationException("Shield count changed.");
        }
        foreach (Shield shield in shields)
        {
            MeshRenderer renderer = shield.GetComponent<MeshRenderer>();
            Mesh source = shield.shiedModels[0].GetComponent<MeshFilter>().sharedMesh;
            if (renderer.isPartOfStaticBatch || renderer.subMeshStartIndex != 0 ||
                shield.GetComponent<MeshFilter>().sharedMesh != source || source.vertexCount == 0 ||
                ((int)GameObjectUtility.GetStaticEditorFlags(shield.gameObject) & 5) != 0)
            {
                throw new InvalidOperationException("A default shield is missing or still statically batched.");
            }
        }
    }

    private static void ValidateShieldPixels(Shield shield)
    {
        MeshRenderer renderer = shield.GetComponent<MeshRenderer>();
        Material original = renderer.sharedMaterial;
        var solid = new Material(Shader.Find("Unlit/Color"));
        solid.color = Color.magenta;
        Camera camera = new GameObject("Default shield pixel audit").AddComponent<Camera>();
        camera.transform.position = renderer.bounds.center + shield.transform.up;
        camera.transform.LookAt(renderer.bounds.center);
        camera.orthographic = true;
        camera.orthographicSize = 0.4f;
        camera.nearClipPlane = 0.01f;
        camera.farClipPlane = 2;
        camera.cullingMask = 1 << shield.gameObject.layer;
        camera.useOcclusionCulling = false;
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.black;
        var target = new RenderTexture(128, 128, 24);
        var pixels = new Texture2D(128, 128, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            renderer.sharedMaterial = solid;
            camera.targetTexture = target;
            camera.Render();
            RenderTexture.active = target;
            pixels.ReadPixels(new Rect(0, 0, 128, 128), 0, 0);
            pixels.Apply();
            int visiblePixels = pixels.GetPixels32().Count(color => color.r > 200 && color.b > 200 && color.g < 50);
            if (visiblePixels < 1000)
            {
                throw new InvalidOperationException("Default shield was not drawn: " + PathOf(shield.transform));
            }
        }
        finally
        {
            renderer.sharedMaterial = original;
            RenderTexture.active = previous;
            UnityEngine.Object.DestroyImmediate(camera.gameObject);
            UnityEngine.Object.DestroyImmediate(solid);
            UnityEngine.Object.DestroyImmediate(target);
            UnityEngine.Object.DestroyImmediate(pixels);
        }
    }

    private static void ValidateShaders(Material[] materials)
    {
        MethodInfo errorsMethod = typeof(ShaderUtil).GetMethod("GetShaderErrors",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        foreach (Shader shader in materials.Select(material => material.shader).Distinct())
        {
            Array errors = (Array)errorsMethod.Invoke(null, new object[] {shader});
            if (!shader.isSupported || errors.Length != 0)
            {
                throw new InvalidOperationException("Shader failed: " + shader.name + " " + JsonConvert.SerializeObject(errors));
            }
        }
    }

    private static void CaptureScene(MapDefinition map, string path)
    {
        MapDefinition.DefendPosition point = map.playersPositions.FirstOrDefault(position => position.mainPosition)
            ?? map.playersPositions[0];
        Vector3 start = point.point.transform.position;
        Vector3 target = map.fieldArea != null ? map.fieldArea.bounds.center : start + point.point.transform.forward * 15;
        target.y = map.floorTransform.position.y + 1;
        Vector3 direction = target - start;
        direction.y = 0;
        direction.Normalize();
        Camera camera = new GameObject("Gameplay rendering audit camera").AddComponent<Camera>();
        camera.transform.position = start - direction * 7 + Vector3.up * 8;
        camera.transform.LookAt(target);
        camera.fieldOfView = 65;
        camera.farClipPlane = 300;
        camera.allowHDR = false;
        var targetTexture = new RenderTexture(960, 540, 24);
        var pixels = new Texture2D(960, 540, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            camera.targetTexture = targetTexture;
            camera.Render();
            RenderTexture.active = targetTexture;
            pixels.ReadPixels(new Rect(0, 0, 960, 540), 0, 0);
            pixels.Apply();
            File.WriteAllBytes(path, pixels.EncodeToPNG());
        }
        finally
        {
            RenderTexture.active = previous;
            UnityEngine.Object.DestroyImmediate(pixels);
            UnityEngine.Object.DestroyImmediate(targetTexture);
            UnityEngine.Object.DestroyImmediate(camera.gameObject);
        }
    }

    private static bool IsIdentity(Matrix4x4 matrix)
    {
        for (int row = 0; row < 4; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                if (Mathf.Abs(matrix[row, column] - Matrix4x4.identity[row, column]) > 0.00001f)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static string PathOf(Transform item)
    {
        if (item.parent == null)
        {
            return item.name;
        }
        return PathOf(item.parent) + "/" + item.name + "[" + item.GetSiblingIndex() + "]";
    }
}

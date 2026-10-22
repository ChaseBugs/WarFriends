using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Reproduces lost static batching and verifies the repaired Desert scene on a real graphics device.</summary>
public static class UnityDesertRenderingAudit
{
    public sealed class Entry
    {
        public string RendererId;
        public string Path;
        public int[] Subsets;
    }

    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use the owned disposable project.");
        }
        string output = Environment.GetEnvironmentVariable("WAR_DESERT_AUDIT_OUTPUT");
        JToken manifest = JToken.Parse(File.ReadAllText(Path.Combine(output, "manifest.json")));
        Entry[] entries = manifest[0]["scene"] == null
            ? manifest.ToObject<Entry[]>()
            : manifest.Single(row => (string)row["scene"] == "Desert_Multiplayer")["staticRenderers"].ToObject<Entry[]>();
        AssetDatabase.ImportAsset("Assets/Shader/T4M 4 Textures.shader",
            ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/Desert_Multiplayer.unity");
        Dictionary<string, MeshRenderer> renderers = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<MeshRenderer>(true))
            .ToDictionary(renderer => PathOf(renderer.transform));
        Transform batchRoot = scene.GetRootGameObjects().Single(root => root.name == "LevelRoot").transform;
        // The first checkpoint also batched eight mutable shields. Retain its
        // archived manifest while checking only the 223 actual static objects.
        entries = entries.Where(entry => renderers[entry.Path].GetComponent<Shield>() == null).ToArray();
        ValidateMetadata(entries, renderers, batchRoot);
        WriteGeometryReport(entries, renderers, output);
        Camera camera = CreateCamera();
        Capture(camera, Path.Combine(output, "after.png"));
        WriteShaderReport(renderers, output);
        SetBatchMetadata(entries, renderers, null);
        Capture(camera, Path.Combine(output, "before.png"));
        SetBatchMetadata(entries, renderers, batchRoot);
        Capture(camera, Path.Combine(output, "restored.png"));
        Debug.Log("DESERT_RENDER_AUDIT_PASS");
        EditorApplication.Exit(0);
    }

    private static void ValidateMetadata(
        Entry[] entries, Dictionary<string, MeshRenderer> renderers, Transform batchRoot)
    {
        if (entries.Length != 223 || batchRoot.localToWorldMatrix != Matrix4x4.identity)
        {
            throw new InvalidOperationException("The recovered static-batch source identity changed.");
        }
        foreach (Entry entry in entries)
        {
            MeshRenderer renderer = renderers[entry.Path];
            var serialized = new SerializedObject(renderer);
            SerializedProperty batch = serialized.FindProperty("m_StaticBatchInfo");
            if (!renderer.isPartOfStaticBatch || renderer.subMeshStartIndex != entry.Subsets[0] ||
                batch == null || batch.FindPropertyRelative("subMeshCount").intValue != entry.Subsets.Length ||
                serialized.FindProperty("m_StaticBatchRoot").objectReferenceValue != batchRoot)
            {
                throw new InvalidOperationException("Source static-batch metadata regressed: " + entry.Path);
            }
        }
    }

    private static void WriteGeometryReport(
        Entry[] entries, Dictionary<string, MeshRenderer> renderers, string output)
    {
        var rows = entries.Select(entry => {
            MeshRenderer renderer = renderers[entry.Path];
            Mesh mesh = renderer.GetComponent<MeshFilter>().sharedMesh;
            return new {
                entry.RendererId, entry.Path, entry.Subsets,
                mesh = AssetDatabase.GetAssetPath(mesh),
                vertices = mesh.vertexCount, subMeshes = mesh.subMeshCount,
                isBatched = renderer.isPartOfStaticBatch, startIndex = renderer.subMeshStartIndex,
                position = Vec(renderer.transform.position),
                bounds = Vec(renderer.bounds.center), extent = Vec(renderer.bounds.extents),
                shaders = renderer.sharedMaterials.Select(material => material.shader.name).ToArray()
            };
        }).ToArray();
        File.WriteAllText(Path.Combine(output, "geometry-report.json"),
            JsonConvert.SerializeObject(rows, Formatting.Indented));
    }

    private static void WriteShaderReport(Dictionary<string, MeshRenderer> renderers, string output)
    {
        Material terrain = renderers.Values.Single(renderer => renderer.name == "terrain_desert1").sharedMaterial;
        MethodInfo errorsMethod = typeof(ShaderUtil).GetMethod("GetShaderErrors",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        Array errors = (Array)errorsMethod.Invoke(null, new object[] {terrain.shader});
        string[] passes = Enumerable.Range(0, terrain.passCount).Select(terrain.GetPassName).ToArray();
        var control = (TextureImporter)AssetImporter.GetAtPath(
            AssetDatabase.GetAssetPath(terrain.GetTexture("_Control")));
        if (errors.Length != 0 || !passes.Contains("FORWARD") ||
            control.alphaIsTransparency || control.sRGBTexture)
        {
            throw new InvalidOperationException("Terrain shader compilation or control-data import regressed.");
        }
        File.WriteAllText(Path.Combine(output, "terrain-shader.json"), JsonConvert.SerializeObject(new {
            supported = terrain.shader.isSupported,
            passes, messages = errors,
            controlPreservesRgba = !control.alphaIsTransparency,
            controlIsLinearData = !control.sRGBTexture
        }, Formatting.Indented));
    }

    private static void SetBatchMetadata(
        Entry[] entries, Dictionary<string, MeshRenderer> renderers, Transform root)
    {
        foreach (Entry entry in entries)
        {
            var serialized = new SerializedObject(renderers[entry.Path]);
            SerializedProperty batch = serialized.FindProperty("m_StaticBatchInfo");
            batch.FindPropertyRelative("firstSubMesh").intValue = root == null ? 0 : entry.Subsets[0];
            batch.FindPropertyRelative("subMeshCount").intValue = root == null ? 0 : entry.Subsets.Length;
            serialized.FindProperty("m_StaticBatchRoot").objectReferenceValue = root;
            serialized.ApplyModifiedPropertiesWithoutUndo();
        }
    }

    private static Camera CreateCamera()
    {
        Camera camera = new GameObject("Desert Rendering Audit Camera").AddComponent<Camera>();
        camera.transform.position = new Vector3(0, 12, -20);
        camera.transform.LookAt(new Vector3(0, 0, 10));
        camera.fieldOfView = 60;
        camera.farClipPlane = 300;
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(0.68f, 0.8f, 0.88f, 1);
        camera.allowHDR = false;
        return camera;
    }

    private static float[] Vec(Vector3 value)
    {
        return new[] {value.x, value.y, value.z};
    }

    private static string PathOf(Transform item)
    {
        if (item.parent == null)
        {
            return item.name;
        }
        return PathOf(item.parent) + "/" + item.name + "[" + item.GetSiblingIndex() + "]";
    }

    private static void Capture(Camera camera, string path)
    {
        var target = new RenderTexture(1280, 720, 24);
        var pixels = new Texture2D(1280, 720, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            camera.targetTexture = target;
            camera.Render();
            RenderTexture.active = target;
            pixels.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
            pixels.Apply();
            File.WriteAllBytes(path, pixels.EncodeToPNG());
        }
        finally
        {
            RenderTexture.active = previous;
            camera.targetTexture = null;
            UnityEngine.Object.DestroyImmediate(pixels);
            UnityEngine.Object.DestroyImmediate(target);
        }
    }
}

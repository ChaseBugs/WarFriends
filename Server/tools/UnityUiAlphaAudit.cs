using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Run in a disposable project with a graphics device (never -nographics).
public static class UnityUiAlphaAudit
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_UI_AUDIT_OUTPUT");
        Directory.CreateDirectory(output);
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        string path = "Assets/Resources/gui/GuiAtlasCommon.png";
        TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(path);
        // Reproduce the old recovered-import settings even after production metadata is repaired.
        importer.alphaIsTransparency = true;
        importer.mipmapEnabled = true;
        importer.isReadable = true;
        importer.SaveAndReimport();
        int before = CountInvalidTransparentPixels(path);
        Capture(path, Path.Combine(output, "hand-before.png"));
        importer.alphaIsTransparency = false;
        importer.mipmapEnabled = false;
        importer.textureCompression = TextureImporterCompression.Uncompressed;
        importer.SaveAndReimport();
        int after = CountInvalidTransparentPixels(path);
        Capture(path, Path.Combine(output, "hand-after.png"));
        File.WriteAllText(Path.Combine(output, "alpha-report.txt"),
            "Nonblack zero-alpha pixels: before=" + before + ", after=" + after);
        if (before == 0 || after != 0)
            throw new InvalidOperationException("Premultiplied alpha regression was not reproduced and repaired.");
        Debug.Log("UI_ALPHA_AUDIT_PASS");
    }

    private static int CountInvalidTransparentPixels(string path)
    {
        int count = 0;
        foreach (Color32 pixel in AssetDatabase.LoadAssetAtPath<Texture2D>(path).GetPixels32())
            if (pixel.a == 0 && (pixel.r != 0 || pixel.g != 0 || pixel.b != 0)) count++;
        return count;
    }

    private static void Capture(string path, string output)
    {
        var root = new GameObject("UI alpha audit");
        var camera = root.AddComponent<Camera>();
        camera.orthographic = true;
        camera.orthographicSize = 1.25f;
        camera.transform.position = new Vector3(0, 0, -5);
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(0.12f, 0.18f, 0.22f, 1);
        var target = new RenderTexture(400, 500, 24);
        camera.targetTexture = target;
        var quad = new GameObject("Recovered hand");
        var mesh = new Mesh();
        mesh.vertices = new[] {new Vector3(-0.75f,-1,0), new Vector3(-0.75f,1,0), new Vector3(0.75f,1,0), new Vector3(0.75f,-1,0)};
        mesh.uv = new[] {new Vector2(0,286f/1024), new Vector2(0,522f/1024), new Vector2(177f/1024,522f/1024), new Vector2(177f/1024,286f/1024)};
        mesh.colors = new[] {Color.white,Color.white,Color.white,Color.white};
        mesh.triangles = new[] {0,1,2,2,3,0};
        quad.AddComponent<MeshFilter>().sharedMesh = mesh;
        var material = new Material(Shader.Find("Unlit/Premultiplied Colored"));
        material.mainTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
        quad.AddComponent<MeshRenderer>().sharedMaterial = material;
        camera.Render();
        RenderTexture.active = target;
        var image = new Texture2D(400,500,TextureFormat.RGB24,false);
        image.ReadPixels(new Rect(0,0,400,500),0,0);
        image.Apply();
        File.WriteAllBytes(output,image.EncodeToPNG());
        RenderTexture.active = null;
        UnityEngine.Object.DestroyImmediate(root);
        UnityEngine.Object.DestroyImmediate(quad);
        UnityEngine.Object.DestroyImmediate(mesh);
        UnityEngine.Object.DestroyImmediate(material);
        UnityEngine.Object.DestroyImmediate(image);
        UnityEngine.Object.DestroyImmediate(target);
    }
}

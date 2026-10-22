using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class UnityUiClippingAudit
{
    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        string output = Environment.GetEnvironmentVariable("WAR_UI_AUDIT_OUTPUT");
        int textures = 0;
        foreach (string path in File.ReadAllLines(Path.Combine(output, "texture-paths.txt")))
        {
            var importer = (TextureImporter)AssetImporter.GetAtPath(path);
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            if (importer == null || importer.alphaIsTransparency || importer.mipmapEnabled ||
                texture == null || (texture.format != TextureFormat.RGBA32 && texture.format != TextureFormat.RGB24))
                throw new InvalidOperationException("Invalid premultiplied atlas import: " + path);
            textures++;
        }
        int checks = 0;
        foreach (string family in new[] { "Premultiplied Colored", "Transparent Colored", "Transparent Colored (Packed)" })
        foreach (string mode in new[] { "AlphaClip", "SoftClip" })
        {
            string name = "Unlit/" + family + " (" + mode + ")";
            Shader shader = Shader.Find(name);
            if (shader == null || !shader.isSupported) throw new InvalidOperationException(name);
            var root = new GameObject("Clipping camera");
            Camera camera = root.AddComponent<Camera>();
            camera.orthographic = true;
            camera.orthographicSize = 1;
            camera.transform.position = new Vector3(3, 4, -5);
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
            var target = new RenderTexture(200,200,24);
            camera.targetTexture = target;
            var quad = new GameObject("Translated panel");
            quad.transform.position = new Vector3(3,4,0);
            var mesh = new Mesh();
            mesh.vertices = new[] {new Vector3(-1,-1,0),new Vector3(-1,1,0),new Vector3(1,1,0),new Vector3(1,-1,0)};
            mesh.uv = new[] {new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0)};
            mesh.colors = new[] {Color.white,Color.white,Color.white,Color.white};
            mesh.triangles = new[] {0,1,2,2,3,0};
            quad.AddComponent<MeshFilter>().sharedMesh = mesh;
            var texture = new Texture2D(2,2,TextureFormat.RGBA32,false);
            texture.SetPixels(new[] {Color.red,Color.green,Color.red,Color.green});
            texture.filterMode = FilterMode.Point;
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.Apply();
            var material = new Material(shader);
            material.mainTexture = texture;
            // These are the exact uniforms written by UIDrawCall.OnWillRenderObject.
            material.mainTextureOffset = new Vector2(-0.5f,0);
            material.mainTextureScale = new Vector2(2,2);
            material.SetVector("_ClipSharpness", new Vector4(5,5,0,0));
            quad.AddComponent<MeshRenderer>().sharedMaterial = material;
            camera.Render();
            RenderTexture.active = target;
            var image = new Texture2D(200,200,TextureFormat.RGB24,false);
            image.ReadPixels(new Rect(0,0,200,200),0,0);
            image.Apply();
            // Clip center is local x=.25, half-width=.5. UVs must remain unchanged.
            Color outside = image.GetPixel(50,100);
            Color left = image.GetPixel(95,100);
            Color right = image.GetPixel(140,100);
            if (outside.maxColorComponent > .05f || left.r < .9f || left.g > .05f || right.g < .9f || right.r > .05f)
                throw new InvalidOperationException("Panel-local clipping or atlas UVs failed: " + name);
            File.WriteAllBytes(Path.Combine(output, family.Replace(" ","-") + "-" + mode + ".png"),image.EncodeToPNG());
            checks++;
            RenderTexture.active = null;
            UnityEngine.Object.DestroyImmediate(root);
            UnityEngine.Object.DestroyImmediate(quad);
            UnityEngine.Object.DestroyImmediate(mesh);
            UnityEngine.Object.DestroyImmediate(texture);
            UnityEngine.Object.DestroyImmediate(material);
            UnityEngine.Object.DestroyImmediate(target);
            UnityEngine.Object.DestroyImmediate(image);
        }
        CheckReflection();
        File.WriteAllText(Path.Combine(output,"clipping-report.txt"),"PASS: " + checks + " translated-panel shader variants; " + textures + " uncompressed atlas imports; reflection UV2 and alpha mask");
        Debug.Log("UI_CLIPPING_AUDIT_PASS");
    }

    private static void CheckReflection()
    {
        var mesh = new Mesh();
        mesh.vertices = new[] {new Vector3(0,0,0),new Vector3(0,1,0),new Vector3(1,1,0),new Vector3(1,0,0)};
        mesh.uv = new[] {Vector2.zero,Vector2.zero,Vector2.zero,Vector2.zero};
        mesh.colors = new[] {Color.white,Color.white,Color.white,Color.white};
        mesh.triangles = new[] {0,1,2,2,3,0};
        var effect = new Texture2D(2,1,TextureFormat.RGBA32,false);
        effect.SetPixels(new[] {Color.clear,new Color(1,1,1,.5f)});
        effect.filterMode = FilterMode.Point;
        effect.wrapMode = TextureWrapMode.Clamp;
        effect.Apply();
        var material = new Material(Shader.Find("Unlit/GuiEffectShader"));
        material.mainTexture = Texture2D.whiteTexture;
        material.SetTexture("_EffectTex",effect);
        var target = new RenderTexture(32,32,0);
        var image = new Texture2D(32,32,TextureFormat.RGB24,false);
        for (int phase = 0; phase < 2; phase++)
        {
            Vector2 uv = new Vector2(phase == 0 ? .25f : .75f,.5f);
            mesh.uv2 = new[] {uv,uv,uv,uv};
            RenderTexture.active = target;
            GL.Clear(true,true,Color.black);
            GL.PushMatrix();
            GL.LoadOrtho();
            material.SetPass(0);
            Graphics.DrawMeshNow(mesh,Matrix4x4.identity);
            GL.PopMatrix();
            image.ReadPixels(new Rect(0,0,32,32),0,0);
            image.Apply();
            float brightness = image.GetPixel(16,16).r;
            if ((phase == 0 && brightness > .02f) || (phase == 1 && brightness < .2f))
                throw new InvalidOperationException("Reflection must use animated UV2 and its alpha mask.");
        }
        RenderTexture.active = null;
        UnityEngine.Object.DestroyImmediate(mesh);
        UnityEngine.Object.DestroyImmediate(effect);
        UnityEngine.Object.DestroyImmediate(material);
        UnityEngine.Object.DestroyImmediate(target);
        UnityEngine.Object.DestroyImmediate(image);
        Debug.Log("UI_REFLECTION_AUDIT_PASS");
    }
}

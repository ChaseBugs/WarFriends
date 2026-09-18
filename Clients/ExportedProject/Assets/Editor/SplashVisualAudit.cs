using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SplashVisualAudit
{
    public static void Run()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity");
        GameLauncher launcher = Object.FindObjectOfType<GameLauncher>();
        if (launcher == null || launcher.ourLogo == null || launcher.chillingoLogo == null || launcher.splashCamera == null)
            throw new System.Exception("Splash references are incomplete");
        foreach (UISprite sprite in Object.FindObjectsOfType<UISprite>())
        {
            if (sprite.atlas != launcher.splashes) continue;
            if (sprite.atlas.GetSprite(sprite.spriteName) == null)
                throw new System.Exception("Missing splash sprite: " + sprite.spriteName);
        }
        foreach (string panel in new[] { "ours", "chillingo" })
        {
            launcher.ourLogo.SetActive(panel == "ours");
            launcher.chillingoLogo.SetActive(panel == "chillingo");
            foreach (UIRoot root in Object.FindObjectsOfType<UIRoot>()) root.SendMessage("Update", SendMessageOptions.DontRequireReceiver);
            foreach (UIWidget widget in Object.FindObjectsOfType<UIWidget>()) widget.SendMessage("Update", SendMessageOptions.DontRequireReceiver);
            foreach (UIPanel ui in Object.FindObjectsOfType<UIPanel>()) ui.SendMessage("LateUpdate", SendMessageOptions.DontRequireReceiver);
            RenderTexture target = new RenderTexture(1280, 720, 24);
            launcher.splashCamera.targetTexture = target;
            launcher.splashCamera.Render();
            Debug.Log("SPLASH CAMERA " + launcher.splashCamera.transform.position);
            foreach (MeshRenderer renderer in Object.FindObjectsOfType<MeshRenderer>())
            {
                Debug.Log("SPLASH MESH " + renderer.name + " bounds=" + renderer.bounds + " texture=" + renderer.sharedMaterial.mainTexture + " vertices=" + renderer.GetComponent<MeshFilter>().sharedMesh.vertexCount);
                Mesh mesh = renderer.GetComponent<MeshFilter>().sharedMesh;
                Debug.Log("SPLASH UV " + string.Join(",", System.Array.ConvertAll(mesh.uv, x => x.ToString())) + " COLORS " + string.Join(",", System.Array.ConvertAll(mesh.colors32, x => x.ToString())) + " scale=" + renderer.sharedMaterial.mainTextureScale);
            }
            RenderTexture.active = target;
            Texture2D image = new Texture2D(1280, 720, TextureFormat.RGB24, false);
            image.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
            image.Apply();
            Directory.CreateDirectory("E:/Temp/WarFriends-compile/audit");
            File.WriteAllBytes("E:/Temp/WarFriends-compile/audit/splash-" + panel + ".png", image.EncodeToPNG());
            launcher.splashCamera.targetTexture = null;
            RenderTexture.active = null;
            Object.DestroyImmediate(image);
            Object.DestroyImmediate(target);
        }
        Debug.Log("SPLASH_VISUAL_AUDIT_COMPLETE");
    }
}

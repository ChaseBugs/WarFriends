using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Invokes source Reset/screen checks using a controlled real Camera without running actor gameplay.</summary>
public static class UnitySoldierAnimationResetExport
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    public static void Run()
    {
        GameObject cameraOwner = null;
        GameObject enemy = null;
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_SOLDIER_RESET_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            cameraOwner = new GameObject("InactiveResetCamera");
            cameraOwner.SetActive(false);
            Camera camera = cameraOwner.AddComponent<Camera>();
            camera.orthographic = true;
            camera.orthographicSize = 1;
            camera.aspect = 1;
            GameCamera gameCamera = cameraOwner.AddComponent<GameCamera>();
            typeof(Singleton<GameCamera>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, gameCamera);
            enemy = UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/GameObject/enemy.prefab"));
            enemy.SetActive(false);
            SoldierAnimationController controller = enemy.GetComponent<EnemyController>().mSoldierAnimationController;
            typeof(SoldierAnimationController).GetMethod("Awake", PrivateInstance).Invoke(controller, null);
            List<object> rows = Capture(controller, camera);
            Write(output, rows);
            Cleanup(enemy, cameraOwner);
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            Cleanup(enemy, cameraOwner);
            EditorApplication.Exit(1);
        }
    }

    private static List<object> Capture(SoldierAnimationController controller, Camera camera)
    {
        var rows = new List<object>();
        string[] operations = { "OnEnable", "Reset", "CheckIfInScreen", "Reset", "ForceInScreen",
            "CheckIfInScreen", "Reset",
            "CheckIfInScreen", "Reset", "CheckIfInScreen", "CheckIfInScreen", "CheckIfInScreen",
            "Pause", "Reset", "CheckIfInScreen", "Pause", "ForceInScreen", "CheckIfInScreen", "Resume",
            "Reset", "CheckIfInScreen", "Stop", "Reset", "CheckIfInScreen", "OnEnable", "Reset", "CheckIfInScreen" };
        float[] horizontal = { -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, 0.5f, 0.5f, -0.1f, 1.1f, 0.5f,
            -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, -0.2f, 0.5f, -0.2f, -0.2f, -0.2f,
            -0.2f, -0.2f, -0.2f };
        for (int index = 0; index < operations.Length; index++)
        {
            controller.transform.position = camera.ViewportToWorldPoint(new Vector3(horizontal[index], 0.5f, 10));
            Vector3 viewport = camera.WorldToViewportPoint(controller.transform.position);
            typeof(SoldierAnimationController).GetMethod(operations[index],
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(controller, null);
            Animation animation = (Animation)Get(controller, "mAnimation");
            rows.Add(new
            {
                operation = operations[index], viewport = new[] { viewport.x, viewport.y },
                enabled = animation.enabled, inScreen = (bool)Get(controller, "mInScreen"),
                forced = (bool)Get(controller, "mForceInScreen"), culling = animation.cullingType.ToString()
            });
        }
        return rows;
    }

    private static void Write(string output, List<object> rows)
    {
        string text = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            sourceSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            fixture = "Original controller methods, inactive actor, controlled Camera singleton; no actor lifecycle.",
            rows
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(output, text);
        Debug.Log("PASS: original soldier animation reset observations=" + rows.Count);
    }

    private static object Get(SoldierAnimationController controller, string field)
    {
        return typeof(SoldierAnimationController).GetField(field, PrivateInstance).GetValue(controller);
    }

    private static void Cleanup(GameObject enemy, GameObject camera)
    {
        typeof(Singleton<GameCamera>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, null);
        if (enemy != null)
        {
            UnityEngine.Object.DestroyImmediate(enemy);
        }
        if (camera != null)
        {
            UnityEngine.Object.DestroyImmediate(camera);
        }
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

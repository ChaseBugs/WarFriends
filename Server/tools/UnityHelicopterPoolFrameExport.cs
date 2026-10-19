using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes the scene pool frame and original parenting operations without running gameplay.</summary>
public static class UnityHelicopterPoolFrameExport
{
    private const string Scene = "Assets/Scenes/MainScene.unity";
    private const string Source = "Assets/Scripts/Assembly-CSharp/NetworkObjectPool.cs";

    public static void Run()
    {
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_HELICOPTER_POOL_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            EditorSceneManager.OpenScene(Scene);
            NetworkObjectPool[] pools = Resources.FindObjectsOfTypeAll<NetworkObjectPool>()
                .Where(pool => pool.gameObject.scene.IsValid()).ToArray();
            if (pools.Length != 1 || pools[0].name != "NetworkPool")
            {
                throw new InvalidOperationException("Expected the recovered scene's unique NetworkPool.");
            }
            object observation = Capture(pools[0]);
            string text = JsonConvert.SerializeObject(new
            {
                version = 1, client = "1.4.0", unity = Application.unityVersion,
                scene = Scene, sceneSha256 = Hash(Scene), source = Source, sourceSha256 = Hash(Source),
                fixture = "Edit Mode scene pool plus original parenting/reset operations; no pool lifecycle.",
                observation
            }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
            File.WriteAllText(output, text);
            Debug.Log("PASS: recovered helicopter pool parent observation.");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static object Capture(NetworkObjectPool pool)
    {
        var container = new GameObject("ObservedEnemyPool");
        container.transform.parent = pool.transform;
        var soldier = new GameObject("ObservedPooledSoldier");
        soldier.transform.SetPositionAndRotation(pool.transform.position, pool.transform.rotation);
        soldier.transform.parent = container.transform;
        object initialized = Pose(soldier.transform);
        // NetworkObjectPool.ReInstantiate resets world position/rotation but retains the pool parent.
        soldier.transform.SetPositionAndRotation(new Vector3(2, 10, 3), Quaternion.identity);
        object reused = Pose(soldier.transform);
        object result = new
        {
            poolName = pool.name, poolParent = pool.transform.parent == null ? null : pool.transform.parent.name,
            pool = Pose(pool.transform), container = Pose(container.transform), initialized, reused,
            poolComponents = pool.GetComponents<Component>()
                .Select(component => component.GetType().FullName).ToArray(),
            enemyEntries = pool.Entries.Where(entry => entry.Name == "enemy").Select(entry => new
            {
                entry.Name, entry.Count, prefab = AssetDatabase.GetAssetPath(entry.Prefab)
            }).ToArray()
        };
        UnityEngine.Object.DestroyImmediate(container);
        return result;
    }

    private static object Pose(Transform transform)
    {
        return new
        {
            position = Values(transform.position), rotation = Values(transform.rotation),
            scale = Values(transform.lossyScale), localPosition = Values(transform.localPosition),
            localRotation = Values(transform.localRotation)
        };
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

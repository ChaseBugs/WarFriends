using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Exports source animation/swapper observations from stripped rigs in a disposable project.</summary>
[InitializeOnLoad]
public static class UnityMortarPreparationExport
{
    private const string SessionKey = "WarFriends.MortarPreparationExport";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string WeaponPath = "Assets/GameObject/MortarEnemy.prefab";
    private const int MaximumStripPasses = 3;

    static UnityMortarPreparationExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Creates source rigs in both controller orders without activating gameplay services.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var world = new GameObject("MortarWorld");
        CreateRig("BeforeController").AddComponent<UnityMortarBeforeControllerProbe>().WorldRoot = world.transform;
        CreateRig("AfterController").AddComponent<UnityMortarPreparationProbe>().WorldRoot = world.transform;
        SessionState.SetInt(SessionKey + ".Count", 2);
        SessionState.SetString(SessionKey + ".Output", "mortar-preparation-reference.json");
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    /// <summary>Compares accumulated EnemyController time with the previous absolute-time probe.</summary>
    public static void RunAccumulated()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var world = new GameObject("MortarWorld");
        foreach (bool accumulated in new[] { false, true })
        {
            string suffix = accumulated ? "Accumulated" : "Absolute";
            var before = CreateRig("Before" + suffix).AddComponent<UnityMortarBeforeControllerProbe>();
            before.WorldRoot = world.transform;
            before.UseAccumulatedClock = accumulated;
            var after = CreateRig("After" + suffix).AddComponent<UnityMortarPreparationProbe>();
            after.WorldRoot = world.transform;
            after.UseAccumulatedClock = accumulated;
        }
        SessionState.SetInt(SessionKey + ".Count", 4);
        SessionState.SetString(SessionKey + ".Output", "mortar-accumulated-reference.json");
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static GameObject CreateRig(string name)
    {
        GameObject enemy = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        GameObject rig = (GameObject)PrefabUtility.InstantiatePrefab(enemy);
        rig.name = name;
        rig.transform.position = new Vector3(3f, -0.25f, 7f);
        rig.transform.rotation = Quaternion.Euler(0f, 37f, 0f);
        SoldierParts parts = rig.GetComponentInChildren<SoldierParts>(true);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath);
        GameObject weapon = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        weapon.transform.SetParent(parts.gunSnapPointNotScaled, false);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = prefab.transform.localRotation;
        weapon.transform.localScale = Vector3.one;
        var controller = rig.GetComponentInChildren<SoldierAnimationController>(true);
        var swapper = weapon.GetComponent<FakeRigidBodySwapper>();
        controller.enabled = false;
        for (int pass = 0; pass < MaximumStripPasses; pass++)
        {
            foreach (MonoBehaviour script in rig.GetComponentsInChildren<MonoBehaviour>(true)
                .Where(script => script != null && script != controller && script != swapper))
            {
                UnityEngine.Object.DestroyImmediate(script);
            }
        }
        foreach (NavMeshAgent agent in rig.GetComponentsInChildren<NavMeshAgent>(true))
        {
            agent.enabled = false;
        }
        foreach (Collider collider in rig.GetComponentsInChildren<Collider>(true))
        {
            collider.enabled = false;
        }
        foreach (Rigidbody body in rig.GetComponentsInChildren<Rigidbody>(true))
        {
            body.isKinematic = true;
            body.detectCollisions = false;
        }
        return rig;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        var probes = UnityEngine.Object.FindObjectsOfType<UnityMortarPreparationProbe>();
        if (probes.Length != SessionState.GetInt(SessionKey + ".Count", 2) ||
            probes.Any(probe => !probe.IsComplete))
        {
            return;
        }
        string[] sources =
        {
            EnemyPath, WeaponPath,
            "Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs",
            "Assets/Scripts/Assembly-CSharp/FakeRigidBodySwapper.cs",
            "Assets/Scripts/Assembly-CSharp/EnemyController.cs",
            "Assets/AnimationClip/mortar_down.anim", "Assets/AnimationClip/mortar_down_idle.anim",
            "Assets/AnimationClip/mortar_hide.anim", "Assets/AnimationClip/mortar_up.anim",
            "Assets/UnityMortarPreparationProbe.cs", "Assets/UnityMortarBeforeControllerProbe.cs",
            "Assets/Editor/UnityMortarPreparationExport.cs"
        };
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            SessionState.GetString(SessionKey + ".Output", "mortar-preparation-reference.json"));
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "Source animation/swapper methods and copied EnemyController float accumulation; " +
                "synthetic build/root turn, no full EnemyController or Photon execution.",
            captureRate = Time.captureFramerate,
            timeScale = Time.timeScale,
            sources = sources.Select(path => new { source = path, sha256 = Hash(path) }).ToArray(),
            scenarios = probes.OrderBy(probe => probe.name).Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveCompletion;
        Debug.Log("UNITY_MORTAR_PREPARATION_EXPORT_PASSED");
        EditorApplication.Exit(0);
    }

    private static string Hash(string path)
    {
        using (var hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

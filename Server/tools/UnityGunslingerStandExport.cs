using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Runs the native stand-animation observation only in a disposable Unity project.</summary>
[InitializeOnLoad]
public static class UnityGunslingerStandExport
{
    private const string SessionKey = "WarFriends.GunslingerStandExport";
    private const string OutputVariable = "WAR_GUNSLINGER_STAND_OUTPUT";
    private const string EnemyPath = "Assets/GameObject/enemy.prefab";
    private const string WeaponPath = "Assets/GameObject/AssaultRifleEnemy.prefab";
    private const int MaximumStripPasses = 3;
    private const int ExpectedProbeCount = 2;

    static UnityGunslingerStandExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Creates a stripped source rig and starts the real animation/coroutine observation.</summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(OutputVariable)))
        {
            throw new InvalidOperationException("Set " + OutputVariable + ".");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        GameObject before = CreateRig();
        before.name = "BeforeController";
        before.AddComponent<UnityGunslingerBeforeControllerProbe>();
        GameObject after = CreateRig();
        after.name = "AfterController";
        after.AddComponent<UnityGunslingerStandProbe>();
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static GameObject CreateRig()
    {
        GameObject enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(EnemyPath);
        GameObject rig = (GameObject)PrefabUtility.InstantiatePrefab(enemyPrefab);
        rig.transform.position = Vector3.zero;
        rig.transform.rotation = Quaternion.identity;
        SoldierParts parts = rig.GetComponentInChildren<SoldierParts>(true);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath);
        GameObject weapon = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        weapon.transform.SetParent(parts.gunSnapPointNotScaled, false);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = prefab.transform.localRotation;
        weapon.transform.localScale = Vector3.one;
        SoldierAnimationController controller = rig.GetComponentInChildren<SoldierAnimationController>(true);
        controller.enabled = false;
        for (int pass = 0; pass < MaximumStripPasses; pass++)
        {
            foreach (MonoBehaviour script in rig.GetComponentsInChildren<MonoBehaviour>(true)
                .Where(script => script != null && script != controller))
            {
                UnityEngine.Object.DestroyImmediate(script);
            }
        }
        foreach (NavMeshAgent agent in rig.GetComponentsInChildren<NavMeshAgent>(true))
        {
            agent.enabled = false;
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

        UnityGunslingerStandProbe[] probes = UnityEngine.Object.FindObjectsOfType<UnityGunslingerStandProbe>();
        if (probes.Any(probe => !string.IsNullOrEmpty(probe.Failure)))
        {
            Finish(1);
            return;
        }
        if (probes.Length != ExpectedProbeCount || probes.Any(probe => !probe.IsComplete))
        {
            return;
        }

        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), JsonConvert.SerializeObject(new
        {
            version = 2,
            unity = Application.unityVersion,
            captureRate = Time.captureFramerate,
            timeScale = Time.timeScale,
            controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            prefabSha256 = Hash(EnemyPath),
            weaponSha256 = Hash(WeaponPath),
            coroutineSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs"),
            probeSha256 = Hash("Assets/UnityGunslingerStandProbe.cs"),
            beforeProbeSha256 = Hash("Assets/UnityGunslingerBeforeControllerProbe.cs"),
            exporterSha256 = Hash("Assets/Editor/UnityGunslingerStandExport.cs"),
            clips = new[] { "colt_idle01", "colt_shooting_start", "colt_shooting_loop", "colt_shooting_stop" }
                .Select(clip => new { name = clip, sha256 = Hash("Assets/AnimationClip/" + clip + ".anim"),
                    runtimeLength = probes[0].GetComponentInChildren<Animation>(true).GetClip(clip).length }).ToArray(),
            scenarios = probes.OrderBy(probe => probe.name).Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented));
        Debug.Log("GUNSLINGER_STAND_EXPORT_PASSED");
        Finish(0);
    }

    private static void Finish(int exitCode)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveCompletion;
        EditorApplication.Exit(exitCode);
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
        }
    }
}

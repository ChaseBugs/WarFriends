using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs both native corner callback observations in a disposable source scene.</summary>
[InitializeOnLoad]
public static class UnityGrenadierCornerCallbackExport
{
    private const string SessionKey = "WarFriends.GrenadierCornerCallbackExport";
    private const string OutputVariable = "WAR_GRENADIER_CORNER_CALLBACK_OUTPUT";
    private const int ExpectedSides = 2;

    static UnityGrenadierCornerCallbackExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Prepares left and right source rigs and enters Play Mode with no Photon gameplay.</summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(OutputVariable)))
        {
            throw new InvalidOperationException("Set " + OutputVariable + ".");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        foreach (string side in new[] { "Right", "Left" })
        {
            GameObject rig = CreatePistolRig();
            rig.name = "GrenadierCornerCallback" + side;
            rig.transform.position = Vector3.zero;
            rig.transform.rotation = Quaternion.identity;
            rig.AddComponent<UnityGrenadierCornerCallbackProbe>();
        }

        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static GameObject CreatePistolRig()
    {
        GameObject rig = UnityCoopObstacleVolleyPoseExport.CreateSourceRig();
        Transform rifle = rig.GetComponentsInChildren<Transform>(true)
            .Single(node => node.name.StartsWith("AssaultRifleEnemy", StringComparison.Ordinal));
        Transform attachment = rifle.parent;
        UnityEngine.Object.DestroyImmediate(rifle.gameObject);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/PistolEnemy.prefab");
        GameObject pistol = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        pistol.transform.SetParent(attachment, false);
        pistol.transform.localPosition = Vector3.zero;
        pistol.transform.localRotation = prefab.transform.localRotation;
        pistol.transform.localScale = Vector3.one;
        for (int pass = 0; pass < 4; pass++)
        {
            foreach (MonoBehaviour script in pistol.GetComponentsInChildren<MonoBehaviour>(true))
            {
                UnityEngine.Object.DestroyImmediate(script);
            }
        }

        if (pistol.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new InvalidOperationException("Unexpected pistol gameplay remains on the native probe.");
        }

        return rig;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }

        UnityGrenadierCornerCallbackProbe[] probes = UnityEngine.Object.FindObjectsOfType<UnityGrenadierCornerCallbackProbe>();
        try
        {
            if (probes.Any(probe => !string.IsNullOrEmpty(probe.Failure)))
            {
                throw new InvalidOperationException("The corner callback observation failed.");
            }
            if (probes.Length != ExpectedSides || probes.Any(probe => !probe.IsComplete))
            {
                return;
            }

            Persist(probes);
            SessionState.SetBool(SessionKey, false);
            EditorApplication.update -= ObserveCompletion;
            Debug.Log("GRENADIER_CORNER_CALLBACK_EXPORT_PASSED sides=" + probes.Length);
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            SessionState.SetBool(SessionKey, false);
            EditorApplication.update -= ObserveCompletion;
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static void Persist(UnityGrenadierCornerCallbackProbe[] probes)
    {
        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), JsonConvert.SerializeObject(new
        {
            version = 1,
            unity = Application.unityVersion,
            captureRate = Time.captureFramerate,
            timeScale = Time.timeScale,
            controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            prefabSha256 = Hash("Assets/GameObject/enemy.prefab"),
            weaponSha256 = Hash("Assets/GameObject/PistolEnemy.prefab"),
            coroutineSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs"),
            probeSha256 = Hash("Assets/UnityGrenadierCornerCallbackProbe.cs"),
            exporterSha256 = Hash("Assets/Editor/UnityGrenadierCornerCallbackExport.cs"),
            rigFactorySha256 = Hash("Assets/Editor/UnityCoopObstacleVolleyPoseExport.cs"),
            clips = new[] { "player_look_right3", "player_look_left3", "player_fire_right3",
                "player_fire_left3", "idle_1" }.Select(clip => new
                {
                    name = clip,
                    sha256 = Hash("Assets/AnimationClip/" + clip + ".anim")
                }).ToArray(),
            scenarios = probes.OrderBy(probe => probe.name).Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented));
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

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
public static class UnityCoopCornerCallbackExport
{
    private const string SessionKey = "WarFriends.CornerCallbackExport";
    private const string OutputVariable = "WAR_COOP_CORNER_CALLBACK_OUTPUT";
    private const int ExpectedSides = 2;

    static UnityCoopCornerCallbackExport()
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
            GameObject rig = UnityCoopObstacleVolleyPoseExport.CreateSourceRig();
            rig.name = "CoopCornerCallback" + side;
            rig.transform.position = Vector3.zero;
            rig.transform.rotation = Quaternion.identity;
            rig.AddComponent<UnityCoopCornerCallbackProbe>();
        }

        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }

        UnityCoopCornerCallbackProbe[] probes = UnityEngine.Object.FindObjectsOfType<UnityCoopCornerCallbackProbe>();
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
            Debug.Log("COOP_CORNER_CALLBACK_EXPORT_PASSED sides=" + probes.Length);
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

    private static void Persist(UnityCoopCornerCallbackProbe[] probes)
    {
        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), JsonConvert.SerializeObject(new
        {
            version = 1,
            unity = Application.unityVersion,
            captureRate = Time.captureFramerate,
            timeScale = Time.timeScale,
            controllerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            prefabSha256 = Hash("Assets/GameObject/enemy.prefab"),
            weaponSha256 = Hash("Assets/GameObject/AssaultRifleEnemy.prefab"),
            coroutineSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs"),
            probeSha256 = Hash("Assets/UnityCoopCornerCallbackProbe.cs"),
            exporterSha256 = Hash("Assets/Editor/UnityCoopCornerCallbackExport.cs"),
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

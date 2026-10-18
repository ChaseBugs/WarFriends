using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs real floor contacts against recovered grenade methods in an isolated empty scene.</summary>
[InitializeOnLoad]
public static class UnityGrenadierFuseExport
{
    private const string SessionKey = "WarFriends.GrenadierFuseExport";
    private const string OutputVariable = "WAR_GRENADIER_FUSE_OUTPUT";
    private const int CaptureRate = 30;

    static UnityGrenadierFuseExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts six isolated contact/countdown observations without a Photon component.</summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(OutputVariable)))
        {
            throw new InvalidOperationException("Set " + OutputVariable + ".");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        Time.captureFramerate = CaptureRate;
        Time.fixedDeltaTime = 1f / CaptureRate;
        Time.timeScale = 1f;
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "FuseContactFloor";
        floor.layer = TagsAndLayers.staticlayerNum;
        floor.transform.position = new Vector3(0f, -0.5f, 0f);
        floor.transform.localScale = new Vector3(30f, 1f, 8f);
        float[] fuses = { 3f, 3f - 3f * 0.2f, 3f - 3f * 0.7f };
        int index = 0;
        foreach (bool recontact in new[] { false, true })
        {
            foreach (float fuse in fuses)
            {
                GameObject actor = new GameObject("FuseProbe_" + index);
                actor.transform.position = new Vector3(index++ * 2f - 5f, 0.4f, 0f);
                actor.AddComponent<SphereCollider>().radius = 0.1f;
                actor.AddComponent<Rigidbody>();
                UnityGrenadierFuseProbe probe = actor.AddComponent<UnityGrenadierFuseProbe>();
                probe.FuseSeconds = fuse;
                probe.HasRecontact = recontact;
            }
        }

        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        UnityGrenadierFuseProbe[] probes = UnityEngine.Object.FindObjectsOfType<UnityGrenadierFuseProbe>();
        if (probes.Length != 6)
        {
            return;
        }

        if (probes.Any(probe => probe.Failure != null))
        {
            Debug.LogError(string.Join("; ", probes.Select(probe => probe.Failure).ToArray()));
            Finish(1);
            return;
        }

        if (probes.Any(probe => !probe.IsComplete))
        {
            return;
        }

        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), JsonConvert.SerializeObject(new
        {
            version = 1, unity = Application.unityVersion, captureRate = Time.captureFramerate,
            fixedDeltaTime = Time.fixedDeltaTime, timeScale = Time.timeScale,
            grenadeSha256 = Hash("Assets/Scripts/Assembly-CSharp/GrenadeAmmoBase.cs"),
            timeManagerSha256 = Hash("Assets/Scripts/Assembly-CSharp/TimeManager.cs"),
            probeSha256 = Hash("Assets/UnityGrenadierFuseProbe.cs"),
            exporterSha256 = Hash("Assets/Editor/UnityGrenadierFuseExport.cs"),
            observations = probes.OrderBy(probe => probe.HasRecontact).ThenByDescending(probe => probe.FuseSeconds)
                .Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented));
        Debug.Log("GRENADIER_FUSE_EXPORT_PASSED");
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

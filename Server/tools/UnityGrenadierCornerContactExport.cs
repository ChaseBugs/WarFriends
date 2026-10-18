using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes recovered collision-entry callbacks while a Rigidbody rests against a floor and wall.</summary>
[InitializeOnLoad]
public static class UnityGrenadierCornerContactExport
{
    private const string SessionKey = "WarFriends.GrenadierCornerContactExport";
    private const string OutputVariable = "WAR_GRENADIER_CORNER_CONTACT_OUTPUT";
    private const int CaptureRate = 30;
    private const int ExpectedProbes = 2;

    static UnityGrenadierCornerContactExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts original contact/countdown execution in two isolated floor/wall fixtures.</summary>
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
        CreateSurface("CornerFloor", new Vector3(0f, -0.5f, 0f), new Vector3(8f, 1f, 8f));
        CreateSurface("CornerWall", new Vector3(0.7f, 1f, 0f), new Vector3(0.2f, 2f, 8f));
        float[] fuses = { 3f, 3f - 3f * 0.7f };
        for (int index = 0; index < fuses.Length; index++)
        {
            GameObject actor = new GameObject("CornerProbe_" + index);
            actor.transform.position = new Vector3(0.45f, 0.4f, index == 0 ? -1f : 1f);
            actor.AddComponent<SphereCollider>().radius = 0.1f;
            actor.AddComponent<Rigidbody>();
            UnityGrenadierFuseProbe probe = actor.AddComponent<UnityGrenadierFuseProbe>();
            probe.FuseSeconds = fuses[index];
            probe.InitialVelocity = Vector3.right;
            probe.ContactAcceleration = Vector3.right;
        }

        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void CreateSurface(string name, Vector3 position, Vector3 scale)
    {
        GameObject surface = GameObject.CreatePrimitive(PrimitiveType.Cube);
        surface.name = name;
        surface.layer = TagsAndLayers.staticlayerNum;
        surface.transform.position = position;
        surface.transform.localScale = scale;
    }

    private static void ObserveCompletion()
    {
        UnityGrenadierFuseProbe[] probes = UnityEngine.Object.FindObjectsOfType<UnityGrenadierFuseProbe>();
        if (probes.Length != ExpectedProbes)
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
            exporterSha256 = Hash("Assets/Editor/UnityGrenadierCornerContactExport.cs"),
            observations = probes.OrderByDescending(probe => probe.FuseSeconds)
                .Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented));
        Debug.Log("GRENADIER_CORNER_CONTACT_EXPORT_PASSED");
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

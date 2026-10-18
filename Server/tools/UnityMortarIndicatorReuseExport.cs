using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Exports original warning reuse across opposite viewers without starting Photon or combat.</summary>
[InitializeOnLoad]
public static class UnityMortarIndicatorReuseExport
{
    private const string SessionKey = "WarFriends.MortarIndicatorReuse";
    private const string WeaponPath = "Assets/GameObject/MortarEnemy.prefab";

    static UnityMortarIndicatorReuseExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Creates two observer-local copies of the same logical reused weapon.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        new GameObject("IndicatorWorld").AddComponent<MainSceneRoot>();
        var owners = new[] { CreatePlayer(Fractions.Enemies), CreatePlayer(Fractions.Allies) };
        Mortar prefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath).GetComponent<Mortar>();
        foreach (PlayerController local in owners)
        {
            var shell = new GameObject("InactiveReusedMortar" + local.mFraction);
            shell.SetActive(false);
            Mortar mortar = shell.AddComponent<Mortar>();
            shell.AddComponent<MissileSetup>().stopTime = 2f;
            mortar.indicator = UnityEngine.Object.Instantiate(prefab.indicator);
            mortar.indicator.SetActive(false);
            new GameObject("ReuseViewer" + local.mFraction).AddComponent<UnityMortarIndicatorReuseProbe>()
                .Configure(mortar, local, owners);
        }
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static PlayerController CreatePlayer(Fractions fraction)
    {
        var shell = new GameObject("InactiveViewer" + fraction);
        shell.SetActive(false);
        var player = shell.AddComponent<PlayerController>();
        player.mFraction = fraction;
        return player;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        var probes = UnityEngine.Object.FindObjectsOfType<UnityMortarIndicatorReuseProbe>();
        if (probes.Length != 2 || probes.Any(probe => !probe.IsComplete))
        {
            return;
        }
        string[] paths = { WeaponPath, "Assets/Scripts/Assembly-CSharp/Mortar.cs",
            "Assets/Scripts/Assembly-CSharp/Weapon.cs", "Assets/Scripts/Assembly-CSharp/PoolableObject.cs",
            "Assets/Scripts/Assembly-CSharp/TweenRotationSpecial.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/UITweener.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/TweenScale.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/TweenColorTk2d.cs",
            "Assets/UnityMortarIndicatorReuseProbe.cs", "Assets/Editor/UnityMortarIndicatorReuseExport.cs" };
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "mortar-indicator-reuse-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion, captureRate = Time.captureFramerate, timeScale = Time.timeScale,
            scope = "Original OnInstancied/setup/tween updates for two viewers; no pool allocation/free or Photon.",
            sources = paths.Select(path => new { source = path, sha256 = Hash(path) }).ToArray(),
            scenarios = probes.OrderBy(probe => probe.name).Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveCompletion;
        Debug.Log("UNITY_MORTAR_INDICATOR_REUSE_PASSED");
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

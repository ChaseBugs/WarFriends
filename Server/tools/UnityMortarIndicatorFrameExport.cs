using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs original Mortar warning tweens in Play Mode without activating recovered gameplay services.</summary>
[InitializeOnLoad]
public static class UnityMortarIndicatorFrameExport
{
    private const string SessionKey = "WarFriends.MortarIndicatorFrames";
    private const string WeaponPath = "Assets/GameObject/MortarEnemy.prefab";
    private const int ScenarioCount = 5;

    static UnityMortarIndicatorFrameExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts regular, source-speed, zero-shrink and negative-shrink scenarios.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        new GameObject("IndicatorWorld").AddComponent<MainSceneRoot>();
        PlayerController local = CreatePlayer("InactiveLocalPlayer", Fractions.Allies);
        PlayerController opponent = CreatePlayer("InactiveOpponent", Fractions.Enemies);
        Mortar prefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath).GetComponent<Mortar>();
        int index = 0;
        foreach (float stopSeconds in new[] { 2f, 1f / 0.43f, 0.3f, 0.2f, 4f })
        {
            var shell = new GameObject("InactiveMortarShell" + index);
            shell.SetActive(false);
            Mortar mortar = shell.AddComponent<Mortar>();
            shell.AddComponent<MissileSetup>().stopTime = stopSeconds;
            mortar.indicator = UnityEngine.Object.Instantiate(prefab.indicator);
            mortar.indicator.name = "NativeMortarIndicator" + index;
            mortar.indicator.SetActive(false);
            new GameObject("WarningProbe" + index).AddComponent<UnityMortarIndicatorProbe>()
                .Configure(mortar, local, opponent, stopSeconds);
            index++;
        }
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static PlayerController CreatePlayer(string name, Fractions fraction)
    {
        var shell = new GameObject(name);
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
        var probes = UnityEngine.Object.FindObjectsOfType<UnityMortarIndicatorProbe>();
        if (probes.Length != ScenarioCount || probes.Any(probe => !probe.IsComplete))
        {
            return;
        }
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "mortar-indicator-frame-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "Actual source Mortar setup/tween Update; isolated inactive players/weapon, no full combat.",
            captureRate = Time.captureFramerate, timeScale = Time.timeScale,
            sources = Sources().Select(path => new { source = path, sha256 = Hash(path) }).ToArray(),
            scenarios = probes.OrderBy(probe => probe.name).Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveCompletion;
        Debug.Log("UNITY_MORTAR_INDICATOR_FRAMES_PASSED");
        EditorApplication.Exit(0);
    }

    private static string[] Sources()
    {
        return new[] { WeaponPath, "Assets/Scripts/Assembly-CSharp/Mortar.cs",
            "Assets/Scripts/Assembly-CSharp/TweenRotationSpecial.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/UITweener.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/TweenScale.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/TweenColorTk2d.cs",
            "Assets/UnityMortarIndicatorProbe.cs", "Assets/Editor/UnityMortarIndicatorFrameExport.cs" };
    }

    private static string Hash(string path)
    {
        using (var hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}

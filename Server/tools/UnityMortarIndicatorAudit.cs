using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes the original Mortar indicator setup and tween sampling without gameplay services.</summary>
public static class UnityMortarIndicatorAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.NonPublic | BindingFlags.Instance;
    private const string WeaponPath = "Assets/GameObject/MortarEnemy.prefab";
    private const float StopSeconds = 2f;
    private static int _checks;

    /// <summary>Runs the recovered private method against isolated inactive player and weapon shells.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var shell = new GameObject("MortarIndicatorSourceShell");
        shell.SetActive(false);
        var localShell = new GameObject("InactiveLocalPlayer");
        localShell.SetActive(false);
        var world = new GameObject("IndicatorWorld");
        world.AddComponent<MainSceneRoot>();
        PlayerController previous = PlayerController.currentPlayer;
        try
        {
            var player = localShell.AddComponent<PlayerController>();
            player.mFraction = Fractions.Allies;
            PlayerController.currentPlayer = player;
            Mortar prefab = AssetDatabase.LoadAssetAtPath<GameObject>(WeaponPath).GetComponent<Mortar>();
            Mortar mortar = shell.AddComponent<Mortar>();
            mortar.indicator = UnityEngine.Object.Instantiate(prefab.indicator);
            mortar.indicator.name = "NativeMortarIndicator";
            mortar.indicator.SetActive(false);
            WriteObservation(mortar, world, player);
            Debug.Log("UNITY_MORTAR_INDICATOR_AUDIT_PASSED checks=" + _checks);
        }
        finally
        {
            PlayerController.currentPlayer = previous;
            UnityEngine.Object.DestroyImmediate(shell);
            UnityEngine.Object.DestroyImmediate(localShell);
            UnityEngine.Object.DestroyImmediate(world);
        }
        EditorApplication.Exit(0);
    }

    private static void WriteObservation(Mortar mortar, GameObject world, PlayerController player)
    {
        var setup = mortar.gameObject.AddComponent<MissileSetup>();
        setup.stopTime = StopSeconds;
        var target = new Vector3(3f, 0.24f, -7f);
        InvokeSetup(mortar, setup, target);
        Require(mortar.indicator.activeSelf && mortar.indicator.transform.parent == world.transform,
            "Opponent indicator was not activated under the source world root.");
        Require(Vector3.Distance(mortar.indicator.transform.position, target) < 0.00001f,
            "Indicator setup changed its supplied world target.");
        TweenRotationSpecial rotation = mortar.indicator.GetComponent<TweenRotationSpecial>();
        TweenScale scale = mortar.indicator.GetComponent<TweenScale>();
        TweenColorTk2d color = mortar.indicator.GetComponent<TweenColorTk2d>();
        typeof(TweenColorTk2d).GetMethod("Awake", PrivateInstance).Invoke(color, null);
        color.Sample(1f, true);
        var sprite = mortar.indicator.GetComponentInChildren<tk2dSprite>(true);
        Require(sprite != null && Mathf.Abs(sprite.color.a - 0.35f) < 0.00001f,
            "The source indicator sprite or initial alpha is absent.");
        Require(rotation.style == UITweener.Style.Loop && rotation.duration == 2f &&
            rotation.method == UITweener.Method.Linear && scale.duration == StopSeconds - 0.3f,
            "Source rotation or shrink configuration changed.");
        List<object> samples = SampleTransforms(mortar, rotation, scale);
        List<object> blinkSamples = SampleBlink(mortar, scale, color, sprite);
        mortar.owner = player;
        InvokeSetup(mortar, setup, target);
        Require(!mortar.indicator.activeSelf, "An allied Mortar displayed an enemy warning.");
        List<object> sources = SourceFingerprints();
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "mortar-indicator-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion, checks = _checks, stopSeconds = StopSeconds,
            scope = "Original setup, Sample and callback/repetition methods; no Play Mode frame timing proof.",
            scaleMethod = scale.method.ToString(), colorMethod = color.method.ToString(),
            samples, blinkSamples, sources
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
    }

    private static List<object> SampleTransforms(Mortar mortar, TweenRotationSpecial rotation, TweenScale scale)
    {
        var samples = new List<object>();
        foreach (float factor in new[] { 0f, 0.25f, 0.5f, 0.75f, 1f })
        {
            rotation.Sample(factor, false);
            scale.Sample(factor, false);
            samples.Add(new
            {
                factor,
                rotation = Vector(mortar.indicator.transform.localRotation),
                scale = Vector(mortar.indicator.transform.localScale)
            });
        }
        return samples;
    }

    private static List<object> SampleBlink(Mortar mortar, TweenScale scale, TweenColorTk2d color, tk2dSprite sprite)
    {
        scale.onFinished(scale);
        Require(color.style == UITweener.Style.PingPong && color.NumOfRepetitions == 5 &&
            color.duration == 0.1f && color.enabled,
            "The shrink completion did not configure the original blink callback.");
        var blinkSamples = new List<object>();
        foreach (float factor in new[] { 0f, 0.25f, 0.5f, 0.75f, 1f })
        {
            color.Sample(factor, false);
            blinkSamples.Add(new { factor, alpha = sprite.color.a });
        }
        MethodInfo repetition = typeof(UITweener).GetMethod("CheckRepetitions", PrivateInstance);
        for (int boundary = 1; boundary <= 5; boundary++)
        {
            bool finished = (bool)repetition.Invoke(color, null);
            Require(finished == (boundary == 5) && mortar.indicator.activeSelf == (boundary != 5),
                "Source repetition count no longer hides at its fifth blink boundary.");
        }
        return blinkSamples;
    }

    private static List<object> SourceFingerprints()
    {
        string[] paths =
        {
            WeaponPath, "Assets/Scripts/Assembly-CSharp/Mortar.cs",
            "Assets/Scripts/Assembly-CSharp/TweenRotationSpecial.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/UITweener.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/TweenScale.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/TweenColorTk2d.cs"
        };
        var sources = new List<object>();
        foreach (string path in paths)
        {
            using (var hash = SHA256.Create())
            {
                sources.Add(new { source = path, sha256 = BitConverter.ToString(
                    hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant() });
            }
        }
        return sources;
    }

    private static void InvokeSetup(Mortar mortar, MissileSetup setup, Vector3 target)
    {
        typeof(Mortar).GetMethod("StartIndicatorAnimation", PrivateInstance)
            .Invoke(mortar, new object[] { setup, target });
    }

    private static float[] Vector(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }

    private static float[] Vector(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        _checks++;
    }
}

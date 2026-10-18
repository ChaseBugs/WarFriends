using System;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

using Newtonsoft.Json;

/// <summary>Captures the real NGUI TweenRotation.Sample result without starting a game or retired services.</summary>
public static class UnityMortarFacingAudit
{
    private const int Steps = 6;
    private const float Duration = 0.2f;

    /// <summary>Samples ordinary yaw, wrap and half-turn cases in a disposable project.</summary>
    public static void Run()
    {
        string root = Directory.GetParent(Application.dataPath).FullName;
        if (!root.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }

        float[,] cases = { { 0, 90 }, { 90, 0 }, { 0, -90 }, { -90, 90 }, { 0, 180 },
            { 180, 0 }, { 170, -170 }, { -170, 170 }, { 45, 45 }, { 0, 0 },
            { 0, 5 }, { 0, 20 }, { 0, 30 }, { 0, 35 }, { 0, 36 }, { 0, 37 },
            { 0, 40 }, { 0, 45 }, { 0, 60 }, { 0, 120 }, { 0, 179 }, { 0, -179 } };
        var results = new List<object>();
        for (int index = 0; index < cases.GetLength(0); index++)
        {
            results.Add(Sample(cases[index, 0], cases[index, 1]));
        }
        foreach (float dot in new[] { 0.9499f, 0.95f, 0.9501f })
        {
            results.Add(Sample(0f, 2f * Mathf.Acos(dot) * Mathf.Rad2Deg));
        }

        string json = JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "TweenRotation.Begin/Sample; explicit factors, not native Update callback order.",
            cases = results
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Path.Combine(root, "mortar-facing-unity.json"), json);
        Debug.Log("UNITY_MORTAR_FACING_AUDIT_DONE cases=" + results.Count);
    }

    private static object Sample(float fromYaw, float toYaw)
    {
        var actor = new GameObject("DisposableMortarFacingProbe");
        try
        {
            // Editor AddComponent invokes UITweener.Reset; runtime component creation does not.
            // Add first so the probe's requested initial rotation is captured by Begin, not erased by Reset.
            actor.AddComponent<TweenRotation>();
            actor.transform.rotation = Quaternion.Euler(0f, fromYaw, 0f);
            Vector3 from = actor.transform.forward;
            Vector3 to = Quaternion.Euler(0f, toYaw, 0f) * Vector3.forward;
            TweenRotation tween = TweenRotation.Begin(actor, Duration, Quaternion.LookRotation(to));
            tween.ignoreTimeScale = false;
            if (tween.method != UITweener.Method.EaseInOut || tween.steeperCurves)
            {
                throw new InvalidOperationException("Unexpected NGUI default rotation policy.");
            }

            var samples = new List<object>();
            for (int step = 0; step <= Steps; step++)
            {
                tween.Sample(step / (float)Steps, step == Steps);
                Vector3 facing = actor.transform.forward;
                samples.Add(new { step, facing = new[] { facing.x, facing.y, facing.z } });
            }

            return new { fromYaw, toYaw, from = new[] { from.x, from.y, from.z },
                to = new[] { to.x, to.y, to.z }, samples };
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(actor);
        }
    }
}

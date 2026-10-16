using System;
using UnityEditor;
using UnityEngine;

/// <summary>Attaches the query observer only to an explicitly requested disposable rig.</summary>
[InitializeOnLoad]
public static class UnityCoopObstacleQueryInstaller
{
    static UnityCoopObstacleQueryInstaller()
    {
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_QUERY_OUTPUT")))
        {
            EditorApplication.update += AttachToRig;
        }
    }

    private static void AttachToRig()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }

        GameObject rig = GameObject.Find("ObstacleVolleyPoseProbe");
        if (rig == null)
        {
            return;
        }

        if (rig.GetComponent<UnityCoopObstacleQueryProbe>() == null)
        {
            if (Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_EMISSION_PHASE") == "update")
            {
                UnityCoopObstacleQueryProbe.ReadGameplayTick = () => UnityCoopObstacleVolleyPoseExport.GameplayTick;
                UnityCoopObstacleQueryProbe.EmitGameplayRound = UnityCoopObstacleVolleyPoseExport.EmitGameplayRound;
            }

            rig.AddComponent<UnityCoopObstacleQueryProbe>();
        }

        EditorApplication.update -= AttachToRig;
    }
}

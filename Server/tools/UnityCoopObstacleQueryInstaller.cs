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
                UnityCoopDelayedShotProbe delayProbe = null;
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_DELAY_OUTPUT")))
                {
                    if (Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_PREPARATION_PHASE") != "update")
                    {
                        throw new InvalidOperationException("The delay probe requires gameplay preparation.");
                    }

                    delayProbe = rig.AddComponent<UnityCoopDelayedShotProbe>();
                }

                UnityCoopObstacleQueryProbe.EmitGameplayRound = tick =>
                {
                    UnityCoopObstacleVolleyPoseExport.EmitGameplayRound(tick);
                    if (delayProbe != null)
                    {
                        delayProbe.ObserveGameplay(tick);
                    }
                };
            }

            rig.AddComponent<UnityCoopObstacleQueryProbe>();
        }

        EditorApplication.update -= AttachToRig;
    }
}

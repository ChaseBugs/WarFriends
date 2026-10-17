using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks the observed RPG blocking surface in the original recovered City scene.</summary>
public static class UnityPvpRpgOcclusionAudit
{
    private const string ScenePath = "Assets/Scenes/City_Multiplayer.unity";
    private const string SceneSha256 = "acaf878b188dbc17fca6795b5db7e9c7797b91dee0fcb6fb02d5e85d7cc11c4f";
    private const string BlockingPath = "LevelRoot/CityMap/Barriers/barrier 1 mat/tires";
    private const int StaticLayerMask = (1 << 13) | (1 << 30);
    private const float ProbeOffset = 0.1f;
    private const float PositionTolerance = 0.001f;
    private const float ExplosionRadius = 1.4f;
    private static readonly Vector3 ObservedImpact = new Vector3(-2.665122f, 0.27044466f, -0.47691548f);
    private static readonly Vector3 ObservedBox = new Vector3(-0.86121786f, 0.26820022f, -1.5879494f);

    /// <summary>Runs a controlled Physics ray; it does not run a match or spawn a missile.</summary>
    public static void Run()
    {
        try
        {
            RequireSourceScene();
            EditorSceneManager.OpenScene(ScenePath);
            Physics.SyncTransforms();
            VerifyBlockingSurface();
            Debug.Log("PASS: original City tires block the observed RPG path outside the crate explosion radius; " +
                "controlled source geometry only, no live gameplay.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void RequireSourceScene()
    {
        string sceneFile = Path.Combine(Application.dataPath, "Scenes/City_Multiplayer.unity");
        using (SHA256 hash = SHA256.Create())
        {
            string digest = BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(sceneFile)))
                .Replace("-", string.Empty).ToLowerInvariant();
            Require(digest == SceneSha256, "The scene differs from the source-bound host geometry.");
        }
    }

    private static void VerifyBlockingSurface()
    {
        Vector3 direction = (ObservedBox - ObservedImpact).normalized;
        Vector3 origin = ObservedImpact - direction * ProbeOffset;
        RaycastHit hit;
        Require(Physics.Raycast(origin, direction, out hit, ProbeOffset * 2f, StaticLayerMask),
            "The original scene must block the observed shot.");
        Require(GetPath(hit.transform) == BlockingPath, "The shot must hit the same source tires collider.");
        Require(Vector3.Distance(hit.point, ObservedImpact) < PositionTolerance,
            "The original Physics contact must match the host impact within the unchanged tolerance.");
        Require(Vector3.Distance(hit.point, ObservedBox) > ExplosionRadius,
            "The observed crate must remain outside the original RPG explosion radius.");
    }

    private static string GetPath(Transform transform)
    {
        var names = new List<string>();
        while (transform != null)
        {
            names.Add(transform.name);
            transform = transform.parent;
        }

        names.Reverse();
        return string.Join("/", names.ToArray());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}

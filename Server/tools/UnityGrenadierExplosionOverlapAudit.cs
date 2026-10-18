using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes the original explosion query's full-radius candidate and later bounds-distance inputs.</summary>
public static class UnityGrenadierExplosionOverlapAudit
{
    private const string OutputVariable = "WAR_GRENADIER_EXPLOSION_OVERLAP_OUTPUT";
    private const float HurtRadius = 1.2f;
    private const float PlayerRadiusRatio = 0.7f;

    /// <summary>Records actual Unity overlap/bounds geometry without invoking effects or damage dispatch.</summary>
    public static void Run()
    {
        try
        {
            string output = Environment.GetEnvironmentVariable(OutputVariable);
            if (string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("Set " + OutputVariable + ".");
            }

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            GameObject actor = new GameObject("RotatedExplosionCandidate");
            actor.layer = TagsAndLayers.destroyableEntitiesAlliesLayerNumber;
            actor.transform.rotation = Quaternion.Euler(0f, 45f, 0f);
            BoxCollider collider = actor.AddComponent<BoxCollider>();
            collider.size = new Vector3(2f, 0.1f, 0.1f);
            Physics.SyncTransforms();
            Vector3 explosion = new Vector3(0.8f, 0f, 0.8f);
            int mask = 1 << actor.layer;
            bool fullOverlap = Physics.OverlapSphere(explosion, HurtRadius, mask).Contains(collider);
            bool reducedOverlap = Physics.OverlapSphere(explosion, HurtRadius * PlayerRadiusRatio, mask)
                .Contains(collider);
            float boundsDistance = Vector3.Distance(explosion, collider.ClosestPointOnBounds(explosion));
            Vector3 outsideGate = new Vector3(0f, 0f, 1.65f);
            bool outsideFullOverlap = Physics.OverlapSphere(outsideGate, HurtRadius, mask).Contains(collider);
            float outsideBoundsDistance = Vector3.Distance(outsideGate, collider.ClosestPointOnBounds(outsideGate));
            if (!outsideFullOverlap || outsideBoundsDistance <= HurtRadius * PlayerRadiusRatio)
            {
                throw new InvalidOperationException("The native full-overlap/outside-player-gate case changed.");
            }

            if (!fullOverlap || reducedOverlap || boundsDistance >= 0.9f * PlayerRadiusRatio)
            {
                throw new InvalidOperationException("The native rotated-box boundary case changed.");
            }

            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                version = 1, unity = Application.unityVersion,
                inspectedExplosionSha256 = Hash("Assets/Scripts/Assembly-CSharp/Explosion.cs"),
                exporterSha256 = Hash("Assets/Editor/UnityGrenadierExplosionOverlapAudit.cs"),
                center = new[] { explosion.x, explosion.y, explosion.z },
                size = new[] { collider.size.x, collider.size.y, collider.size.z },
                rotationY = 45f, hurtRadius = HurtRadius, playerRadiusRatio = PlayerRadiusRatio,
                fullOverlap, reducedOverlap, boundsDistance,
                outsideGate = new[] { outsideGate.x, outsideGate.y, outsideGate.z },
                outsideFullOverlap, outsideBoundsDistance
            }, Formatting.Indented));
            Debug.Log("GRENADIER_EXPLOSION_OVERLAP_PASSED");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
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

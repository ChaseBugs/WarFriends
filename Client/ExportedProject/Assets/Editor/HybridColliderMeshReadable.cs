using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

// Enumerates every mesh referenced by a MeshCollider across all enabled build scenes and all
// prefabs, and writes their asset paths to Client/hybrid-collider-mesh-readable.txt.
//
// Non-convex MeshColliders whose GameObject carries a non-uniform (or negative) scale force
// Unity to bake a CPU-transformed copy of the collision mesh, which requires the mesh's vertex
// data to stay CPU-accessible. The AssetRipper-recovered collision meshes ship with
// m_IsReadable: 0, so Play Mode floods the console with:
//   "This MeshCollider (GameObject: 'x' Mesh: 'x_COL') requires the mesh to be marked as
//    readable in order to be usable with the given transform."
//
// Collision meshes are not always named "_COL" (e.g. ground_0, floor, barrel), so this scans
// actual MeshCollider.sharedMesh usage rather than filtering by name. The emitted list is fed to
// a surgical `m_IsReadable: 0 -> 1` edit of just those .asset files (no full re-serialization).
public static class HybridColliderMeshReadable
{
    public static void Run()
    {
        HashSet<string> colliderMeshPaths = new HashSet<string>(StringComparer.Ordinal);
        int colliderComponents = 0;

        foreach (EditorBuildSettingsScene buildScene in EditorBuildSettings.scenes)
        {
            if (!buildScene.enabled)
            {
                continue;
            }

            try
            {
                EditorSceneManager.OpenScene(buildScene.path, OpenSceneMode.Single);
                Scene scene = SceneManager.GetActiveScene();
                foreach (GameObject root in scene.GetRootGameObjects())
                {
                    colliderComponents += CollectFrom(root, colliderMeshPaths);
                }
            }
            catch (Exception error)
            {
                Debug.LogError("Collider-mesh scan failed for scene " + buildScene.path + ": " + error);
            }
        }

        foreach (string guid in AssetDatabase.FindAssets("t:Prefab"))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab != null)
            {
                colliderComponents += CollectFrom(prefab, colliderMeshPaths);
            }
        }

        List<string> sorted = colliderMeshPaths.OrderBy(value => value, StringComparer.Ordinal).ToList();
        string listPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-collider-mesh-readable.txt"));
        File.WriteAllLines(listPath, sorted);

        StringBuilder report = new StringBuilder();
        report.AppendLine("mesh_asset,is_readable");
        int notReadable = 0;
        foreach (string meshPath in sorted)
        {
            Mesh mesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);
            bool readable = mesh != null && mesh.isReadable;
            if (!readable)
            {
                notReadable++;
            }

            report.AppendLine(Csv(meshPath) + "," + (readable ? "true" : "false"));
        }

        string reportPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-collider-mesh-readable.csv"));
        File.WriteAllText(reportPath, report.ToString());

        Debug.Log("Collider-mesh list: " + listPath);
        Debug.Log("Collider-mesh totals: colliderComponents=" + colliderComponents +
            ", uniqueMeshes=" + sorted.Count + ", notReadable=" + notReadable);
        EditorApplication.Exit(0);
    }

    private static int CollectFrom(GameObject root, HashSet<string> meshPaths)
    {
        int count = 0;
        foreach (MeshCollider collider in root.GetComponentsInChildren<MeshCollider>(true))
        {
            count++;
            Mesh mesh = collider.sharedMesh;
            if (mesh == null)
            {
                continue;
            }

            string path = AssetDatabase.GetAssetPath(mesh);
            if (!string.IsNullOrEmpty(path))
            {
                meshPaths.Add(path);
            }
        }

        return count;
    }

    private static string Csv(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}

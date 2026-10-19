using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Exports serialized navigation tile fields without modifying recovered assets.</summary>
public static class UnityNavMeshTileExport
{
    public static void Run()
    {
        string directory = Environment.GetEnvironmentVariable("WAR_NAVMESH_TILE_OUTPUT");
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(directory))
        {
            throw new InvalidOperationException("Use a disposable project and an explicit tile output directory.");
        }
        Directory.CreateDirectory(directory);
        foreach (string name in new[] { "NavMesh_7", "NavMesh_1", "NavMesh", "NavMesh_0", "NavMesh_3" })
        {
            string path = "Assets/NavMeshData/" + name + ".asset";
            NavMeshData data = AssetDatabase.LoadAssetAtPath<NavMeshData>(path);
            if (data == null)
            {
                throw new InvalidOperationException("Missing recovered navigation asset: " + path);
            }
            File.WriteAllText(Path.Combine(directory, name + ".json"), EditorJsonUtility.ToJson(data, true));
        }
        EditorApplication.Exit(0);
    }
}

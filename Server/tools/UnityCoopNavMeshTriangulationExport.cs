// Run only in a disposable Unity 2018.3 project with recovered NavMeshData.
// This exporter never belongs in the active Client project.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public static class UnityCoopNavMeshTriangulationExport
{
    [Serializable]
    private sealed class MeshRows
    {
        public string asset;
        public Vector3[] vertices;
        public int[] indices;
        public int[] areas;
    }

    public static void Export()
    {
        string[] arguments = Environment.GetCommandLineArgs();
        int outputFlag = Array.IndexOf(arguments, "-coopTriangulationOutput");
        if (outputFlag < 0 || outputFlag + 1 >= arguments.Length)
            throw new InvalidOperationException(
                "Missing -coopTriangulationOutput directory.");
        string output = Path.GetFullPath(arguments[outputFlag + 1]);
        Directory.CreateDirectory(output);

        string[] assetNames =
        {
            "NavMesh_7", "NavMesh_1", "NavMesh", "NavMesh_0", "NavMesh_3"
        };
        foreach (string name in assetNames)
        {
            string assetPath = "Assets/NavMeshData/" + name + ".asset";
            NavMeshData data = AssetDatabase.LoadAssetAtPath<NavMeshData>(
                assetPath);
            if (data == null)
                throw new InvalidOperationException("Missing co-op " + assetPath);
            NavMeshDataInstance instance = NavMesh.AddNavMeshData(data);
            if (!instance.valid)
                throw new InvalidOperationException("Unity rejected " + assetPath);
            try
            {
                NavMeshTriangulation triangles = NavMesh.CalculateTriangulation();
                if (triangles.vertices == null || triangles.indices == null ||
                    triangles.areas == null || triangles.vertices.Length < 100 ||
                    triangles.indices.Length < 300 ||
                    triangles.indices.Length % 3 != 0 ||
                    triangles.areas.Length != triangles.indices.Length / 3)
                    throw new InvalidOperationException(
                        "Incomplete co-op triangulation: " + assetPath);
                foreach (int index in triangles.indices)
                {
                    if (index < 0 || index >= triangles.vertices.Length)
                        throw new InvalidOperationException(
                            "Invalid co-op triangle index: " + assetPath);
                }
                var rows = new MeshRows
                {
                    asset = assetPath,
                    vertices = triangles.vertices,
                    indices = triangles.indices,
                    areas = triangles.areas
                };
                File.WriteAllText(Path.Combine(output, name + ".json"),
                    UnityEngine.JsonUtility.ToJson(rows));
                Debug.Log("COOP_TRIANGULATION " + name + " vertices=" +
                    triangles.vertices.Length + " triangles=" +
                    triangles.indices.Length / 3);
            }
            finally
            {
                instance.Remove();
            }
        }
    }
}

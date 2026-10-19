using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Captures source ShowRope query operations only in a disposable recovered project.</summary>
public static class UnityHelicopterLandingExport
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_ROPE_LANDING_OUTPUT");
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
        {
            throw new InvalidOperationException("A disposable project and explicit landing output are required.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        NavMesh.RemoveAllNavMeshData();
        var rows = new List<object>();
        rows.Add(Query("empty", Vector3.up * 8, Vector3.zero));
        foreach (string name in new[] { "NavMesh_7", "NavMesh_1", "NavMesh", "NavMesh_0", "NavMesh_3" })
        {
            CaptureMap(name, rows);
        }
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            sourceMethod = "Helicopter.ShowRope",
            radius = 10,
            areaMask = 1,
            rows,
        }, Formatting.Indented));
        EditorApplication.Exit(0);
    }

    private static void CaptureMap(string name, List<object> rows)
    {
        string path = "Assets/NavMeshData/" + name + ".asset";
        NavMeshData data = AssetDatabase.LoadAssetAtPath<NavMeshData>(path);
        if (data == null)
        {
            throw new InvalidOperationException("Missing recovered navigation asset " + path);
        }
        NavMeshDataInstance instance = NavMesh.AddNavMeshData(data);
        try
        {
            Vector3[] vertices = NavMesh.CalculateTriangulation().vertices;
            for (int index = 0; index < 5; index++)
            {
                Vector3 surface = vertices[index * (vertices.Length - 1) / 4];
                rows.Add(Query(name, surface + Vector3.up * 8, surface));
                rows.Add(Query(name, surface + Vector3.up * 8, surface + Vector3.up * 20));
                if (Environment.GetEnvironmentVariable("WAR_ROPE_LANDING_EXTENDED") == "1")
                {
                    foreach (float height in new[] { 1f, 4f, 8f })
                    foreach (float offset in new[] { -0.5f, 0.5f, 2f })
                    {
                        Vector3 origin = surface + new Vector3(offset, height, 0);
                        rows.Add(Query(name, origin, origin + Vector3.up * 20));
                    }
                }
            }
        }
        finally
        {
            instance.Remove();
        }
    }

    private static object Query(string map, Vector3 origin, Vector3 player)
    {
        var plane = new Plane(Vector3.up, player);
        var ray = new Ray(origin, Vector3.down);
        float enter;
        bool projected = plane.Raycast(ray, out enter);
        Vector3 sourcePosition = projected ? ray.GetPoint(enter) : origin;
        NavMeshHit hit;
        bool found = NavMesh.SamplePosition(sourcePosition, out hit, 10, 1);
        return new
        {
            map,
            origin = Coordinates(origin),
            player = Coordinates(player),
            projected,
            query = Coordinates(sourcePosition),
            found,
            position = Coordinates(hit.position),
        };
    }

    private static float[] Coordinates(Vector3 point)
    {
        return new[] { point.x, point.y, point.z };
    }
}

using System;
using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>Compares native NavMesh sampling with the forty recovered Mortar destinations.</summary>
public static class UnityMortarPointAudit
{
    /// <summary>Uses source NavMesh assets in a disposable project without changing recovered scenes.</summary>
    public static void Run()
    {
        string root = Directory.GetParent(Application.dataPath).FullName;
        if (!root.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }

        JObject input = JObject.Parse(File.ReadAllText(Path.Combine(root, "mortar-points-input.json")));
        int[] assetNumbers = { 5, 8, 2, 6, 4 };
        var results = new List<object>();
        int mapIndex = 0;
        foreach (JToken map in input["maps"])
        {
            string asset = "Assets/NavMeshData/NavMesh_" + assetNumbers[mapIndex++] + ".asset";
            NavMeshData mesh = AssetDatabase.LoadAssetAtPath<NavMeshData>(asset);
            NavMeshDataInstance instance = NavMesh.AddNavMeshData(mesh);
            if (!instance.valid)
            {
                throw new InvalidOperationException("Missing or invalid source NavMesh: " + asset);
            }

            try
            {
                foreach (JToken point in map["points"])
                {
                    float[] coordinates = point["worldPosition"].ToObject<float[]>();
                    var position = new Vector3(coordinates[0], coordinates[1], coordinates[2]);
                    NavMeshHit hit;
                    bool isSampled = NavMesh.SamplePosition(position, out hit, 0.5f, NavMesh.AllAreas);
                    Vector3 offset = hit.position - position;
                    results.Add(new
                    {
                        source = (string)map["source"],
                        componentFileId = (int)point["componentFileId"],
                        isSampled,
                        position = coordinates,
                        sampledPosition = new[] { hit.position.x, hit.position.y, hit.position.z },
                        planarDistance = new Vector2(offset.x, offset.z).magnitude
                    });
                }
            }
            finally
            {
                instance.Remove();
            }
        }

        File.WriteAllText(Path.Combine(root, "mortar-points-unity.json"),
            JsonConvert.SerializeObject(new { unityVersion = Application.unityVersion, points = results },
                Formatting.Indented).Replace("\r\n", "\n") + "\n");
        Debug.Log("UNITY_MORTAR_POINT_AUDIT_DONE points=" + results.Count);
    }
}

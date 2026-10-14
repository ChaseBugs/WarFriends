using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class UnityPvpBonusSpawnAreaAudit
{
    [Serializable] private sealed class TransformRow
    {
        public int fileId;
        public float[] position, rotation, scale;
    }
    [Serializable] private sealed class Area
    {
        public int order, colliderFileId;
        public float[] localCenter, localSize, boundsMin, boundsMax;
        public TransformRow[] transformChain;
    }
    [Serializable] private sealed class Map
    {
        public string source, sha256;
        public Area[] areas;
    }
    [Serializable] private sealed class Source {public Map[] maps;}
    [Serializable] private sealed class ResultArea
    {
        public string source;
        public int order, colliderFileId;
        public float[] minimum, maximum;
    }
    [Serializable] private sealed class Result
    {
        public int version = 1;
        public string unityVersion;
        public ResultArea[] areas;
    }

    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_PVP_BONUS_AREAS_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new Exception("Missing output path.");
        var source = JsonUtility.FromJson<Source>(File.ReadAllText(
            Path.Combine(Application.dataPath, "Editor/source-bonus-areas.json")));
        if (source.maps.Length != 5) throw new Exception("Expected five source maps.");
        var results = new List<ResultArea>();
        foreach (var map in source.maps)
        foreach (var area in map.areas)
        {
            Transform parent = null;
            var objects = new List<GameObject>();
            for (int index = area.transformChain.Length - 1; index >= 0; index--)
            {
                var row = area.transformChain[index];
                var item = new GameObject("source-" + row.fileId);
                objects.Add(item);
                item.transform.SetParent(parent, false);
                item.transform.localPosition = Vector(row.position);
                item.transform.localRotation = new Quaternion(row.rotation[0],
                    row.rotation[1], row.rotation[2], row.rotation[3]);
                item.transform.localScale = Vector(row.scale);
                parent = item.transform;
            }
            var collider = parent.gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.center = Vector(area.localCenter);
            collider.size = Vector(area.localSize);
            var bounds = collider.bounds;
            Compare(bounds.min, Vector(area.boundsMin), map.source, area.order);
            Compare(bounds.max, Vector(area.boundsMax), map.source, area.order);
            results.Add(new ResultArea {source = map.source, order = area.order,
                colliderFileId = area.colliderFileId,
                minimum = Axes(bounds.min), maximum = Axes(bounds.max)});
            UnityEngine.Object.DestroyImmediate(objects[0]);
        }
        var result = new Result {unityVersion = Application.unityVersion,
            areas = results.ToArray()};
        File.WriteAllText(output, JsonUtility.ToJson(result, true).Replace("\r\n", "\n") + "\n",
            new UTF8Encoding(false));
        Debug.Log("PVP_BONUS_AREAS PASS: " + results.Count + " Unity BoxCollider bounds");
    }

    private static Vector3 Vector(float[] values) =>
        new Vector3(values[0], values[1], values[2]);
    private static float[] Axes(Vector3 value) => new[] {value.x, value.y, value.z};
    private static void Compare(Vector3 actual, Vector3 expected, string scene, int order)
    {
        if ((actual - expected).magnitude > 0.00002f)
            throw new Exception("Collider bounds differ: " + scene + " area " + order +
                " actual " + actual + " expected " + expected);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public static class BossPathCapture
{
    private const float SampleRadius = 0.25f;

    [Serializable]
    public sealed class Input
    {
        public MapInput[] maps;
    }

    [Serializable]
    public sealed class MapInput
    {
        public string scene;
        public string asset;
        public Vector3[] points;
    }

    [Serializable]
    public sealed class Output
    {
        public int version = 1;
        public List<MapOutput> maps = new List<MapOutput>();
    }

    [Serializable]
    public sealed class MapOutput
    {
        public string scene;
        public string asset;
        public List<Route> routes = new List<Route>();
    }

    [Serializable]
    public sealed class Route
    {
        public int from;
        public int to;
        public bool startSampled;
        public bool endSampled;
        public Vector3 sampledStart;
        public Vector3 sampledEnd;
        public string status;
        public Vector3[] corners;
    }

    public static void Run()
    {
        string directory = Environment.GetEnvironmentVariable("WAR_BOSS_PATH_RUN");
        Input input = JsonUtility.FromJson<Input>(File.ReadAllText(Path.Combine(directory, "input.json")));
        var output = new Output();
        foreach (MapInput map in input.maps)
        {
            output.maps.Add(CaptureMap(map));
        }
        File.WriteAllText(Path.Combine(directory, "native-paths.json"), JsonUtility.ToJson(output, true));
    }

    private static MapOutput CaptureMap(MapInput map)
    {
        NavMesh.RemoveAllNavMeshData();
        NavMeshData data = AssetDatabase.LoadAssetAtPath<NavMeshData>(map.asset);
        if (data == null || map.points.Length != 8)
        {
            throw new InvalidOperationException("Missing navigation data or ordered defend points: " + map.scene);
        }
        NavMeshDataInstance instance = NavMesh.AddNavMeshData(data);
        if (!instance.valid)
        {
            throw new InvalidOperationException("Could not load native navigation data: " + map.scene);
        }
        try
        {
            var result = new MapOutput { scene = map.scene, asset = map.asset };
            for (int start = 0; start < map.points.Length; start++)
            {
                for (int end = 0; end < map.points.Length; end++)
                {
                    // Recovered boss movement stays within its own four defend points.
                    if (start != end && (start < 4) == (end < 4))
                    {
                        result.routes.Add(CaptureRoute(map, start, end));
                    }
                }
            }
            return result;
        }
        finally
        {
            instance.Remove();
        }
    }

    private static Route CaptureRoute(MapInput map, int start, int end)
    {
        NavMeshHit startHit;
        NavMeshHit endHit;
        bool startSampled = NavMesh.SamplePosition(map.points[start], out startHit, SampleRadius, NavMesh.AllAreas);
        bool endSampled = NavMesh.SamplePosition(map.points[end], out endHit, SampleRadius, NavMesh.AllAreas);
        var path = new NavMeshPath();
        if (!startSampled || !endSampled ||
            !NavMesh.CalculatePath(startHit.position, endHit.position, NavMesh.AllAreas, path))
        {
            throw new InvalidOperationException("Could not calculate defend-point route: " + map.scene);
        }
        return new Route
        {
            from = start,
            to = end,
            startSampled = startSampled,
            endSampled = endSampled,
            sampledStart = startHit.position,
            sampledEnd = endHit.position,
            status = path.status.ToString(),
            corners = path.corners
        };
    }
}

// Execute only in a disposable Unity 2018.3 project containing the recovered
// co-op NavMesh assets. No Client scene or prefab is modified.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public static class UnityCoopNavMeshPathExport
{
    [Serializable] private sealed class Input { public int version; public MapInput[] maps; }
    [Serializable] private sealed class MapInput
    {
        public string scene;
        public string asset;
        public Vector3[] positions;
    }
    [Serializable] private sealed class Output { public int version; public MapOutput[] maps; }
    [Serializable] private sealed class MapOutput
    {
        public string scene;
        public string asset;
        public Route[] routes;
    }
    [Serializable] private sealed class Route
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

    public static void Export()
    {
        string[] arguments = Environment.GetCommandLineArgs();
        int inputIndex = Array.IndexOf(arguments, "-coopPathsInput");
        int outputIndex = Array.IndexOf(arguments, "-coopPathsOutput");
        if (inputIndex < 0 || inputIndex + 1 >= arguments.Length ||
            outputIndex < 0 || outputIndex + 1 >= arguments.Length)
            throw new InvalidOperationException("Missing co-op path input or output.");

        Input input = JsonUtility.FromJson<Input>(File.ReadAllText(arguments[inputIndex + 1]));
        if (input == null || input.version != 1 || input.maps == null ||
            input.maps.Length != 5)
            throw new InvalidDataException("Expected five co-op navigation maps.");

        var output = new Output { version = 1, maps = new MapOutput[5] };
        for (int mapIndex = 0; mapIndex < input.maps.Length; mapIndex++)
        {
            MapInput source = input.maps[mapIndex];
            if (source.positions == null || source.positions.Length != 4 ||
                !source.asset.StartsWith("Assets/NavMeshData/", StringComparison.Ordinal))
                throw new InvalidDataException("Invalid co-op map route input.");
            NavMeshData data = AssetDatabase.LoadAssetAtPath<NavMeshData>(source.asset);
            if (data == null)
                throw new InvalidDataException("Unity could not load " + source.asset);
            NavMeshDataInstance instance = NavMesh.AddNavMeshData(data);
            if (!instance.valid)
                throw new InvalidDataException("Unity rejected " + source.asset);
            try
            {
                var routes = new Route[12];
                int routeIndex = 0;
                for (int from = 0; from < 4; from++)
                for (int to = 0; to < 4; to++)
                {
                    if (from == to) continue;
                    var route = new Route { from = from, to = to,
                        corners = new Vector3[0], status = "SampleFailed" };
                    NavMeshHit startHit;
                    NavMeshHit endHit;
                    route.startSampled = NavMesh.SamplePosition(
                        source.positions[from], out startHit, 3f, NavMesh.AllAreas);
                    route.endSampled = NavMesh.SamplePosition(
                        source.positions[to], out endHit, 3f, NavMesh.AllAreas);
                    if (route.startSampled) route.sampledStart = startHit.position;
                    if (route.endSampled) route.sampledEnd = endHit.position;
                    if (route.startSampled && route.endSampled)
                    {
                        var path = new NavMeshPath();
                        NavMesh.CalculatePath(startHit.position, endHit.position,
                            NavMesh.AllAreas, path);
                        route.status = path.status.ToString();
                        route.corners = path.corners;
                    }
                    routes[routeIndex++] = route;
                }
                output.maps[mapIndex] = new MapOutput
                {
                    scene = source.scene,
                    asset = source.asset,
                    routes = routes
                };
            }
            finally { instance.Remove(); }
        }
        File.WriteAllText(arguments[outputIndex + 1], JsonUtility.ToJson(output, true));
        Debug.Log("COOP_NAVMESH_PATH_EXPORT completed five maps");
    }
}

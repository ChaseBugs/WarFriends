// Execute only in a disposable Unity 2018.3 project with recovered NavMeshData.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public static class UnityCoopInfantryPathSetExport
{
    [Serializable]
    private sealed class Input
    {
        public int version;
        public Case[] cases;
    }

    [Serializable]
    private sealed class Case
    {
        public int stage;
        public int missionIndex;
        public string scene;
        public string asset;
        public int spawnComponentFileId;
        public int pointComponentFileId;
        public Vector3 start;
        public Vector3 end;
    }

    [Serializable]
    private sealed class PathResult
    {
        public int stage;
        public string scene;
        public string asset;
        public int spawnComponentFileId;
        public int pointComponentFileId;
        public bool startSampled;
        public bool endSampled;
        public Vector3 sampledStart;
        public Vector3 sampledEnd;
        public string status;
        public Vector3[] corners;
    }

    [Serializable]
    private sealed class Output
    {
        public int version;
        public PathResult[] cases;
    }

    public static void Export()
    {
        string[] arguments = Environment.GetCommandLineArgs();
        int inputFlag = Array.IndexOf(arguments, "-coopPathSetInput");
        int outputFlag = Array.IndexOf(arguments, "-coopPathSetOutput");
        if (inputFlag < 0 || inputFlag + 1 >= arguments.Length ||
            outputFlag < 0 || outputFlag + 1 >= arguments.Length)
            throw new InvalidOperationException("Missing co-op path set paths.");

        Input input = UnityEngine.JsonUtility.FromJson<Input>(
            File.ReadAllText(arguments[inputFlag + 1]));
        if (input == null || input.version != 1 || input.cases == null ||
            input.cases.Length != 5)
            throw new InvalidOperationException("Expected five co-op map cases.");
        var output = new Output { version = 1, cases = new PathResult[5] };

        for (int index = 0; index < input.cases.Length; index++)
        {
            Case source = input.cases[index];
            if (source.stage != index + 1 ||
                !source.asset.StartsWith("Assets/NavMeshData/",
                    StringComparison.Ordinal))
                throw new InvalidOperationException("Co-op path map order changed.");
            NavMeshData mesh = AssetDatabase.LoadAssetAtPath<NavMeshData>(
                source.asset);
            if (mesh == null)
                throw new InvalidOperationException("Co-op NavMeshData is absent.");
            NavMeshDataInstance instance = NavMesh.AddNavMeshData(mesh);
            if (!instance.valid)
                throw new InvalidOperationException("Unity rejected co-op NavMeshData.");

            try
            {
                NavMeshHit startHit;
                NavMeshHit endHit;
                bool startSampled = NavMesh.SamplePosition(source.start,
                    out startHit, 3f, NavMesh.AllAreas);
                bool endSampled = NavMesh.SamplePosition(source.end,
                    out endHit, 3f, NavMesh.AllAreas);
                var result = new PathResult
                {
                    stage = source.stage,
                    scene = source.scene,
                    asset = source.asset,
                    spawnComponentFileId = source.spawnComponentFileId,
                    pointComponentFileId = source.pointComponentFileId,
                    startSampled = startSampled,
                    endSampled = endSampled,
                    status = "SampleFailed",
                    corners = new Vector3[0]
                };
                if (startSampled)
                    result.sampledStart = startHit.position;
                if (endSampled)
                    result.sampledEnd = endHit.position;
                if (startSampled && endSampled)
                {
                    var path = new NavMeshPath();
                    NavMesh.CalculatePath(startHit.position,
                        endHit.position, NavMesh.AllAreas, path);
                    result.status = path.status.ToString();
                    result.corners = path.corners;
                }
                output.cases[index] = result;
            }
            finally
            {
                instance.Remove();
            }
        }

        File.WriteAllText(arguments[outputFlag + 1],
            UnityEngine.JsonUtility.ToJson(output, true));
        Debug.Log("COOP_INFANTRY_PATH_SET exported five source map cases");
    }
}

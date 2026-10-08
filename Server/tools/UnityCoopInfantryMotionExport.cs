// Run only in a disposable Unity 2018.3 project with the recovered NavMeshData.
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[InitializeOnLoad]
public static class UnityCoopInfantryMotionExport
{
    [Serializable]
    private sealed class ProbeInput
    {
        public string asset;
        public Vector3 start;
        public Vector3 end;
        public float speed;
    }

    [Serializable]
    private sealed class MotionSample
    {
        public int frame;
        public float seconds;
        public Vector3 position;
        public Vector3 velocity;
        public Quaternion rotation;
        public float remainingDistance;
    }

    [Serializable]
    private sealed class MotionResult
    {
        public string asset;
        public string status;
        public Vector3 requestedStart;
        public Vector3 requestedEnd;
        public Vector3 sampledStart;
        public Vector3 sampledEnd;
        public string pathStatus;
        public Vector3[] corners;
        public float speed;
        public MotionSample[] samples;
    }

    private static ProbeInput input;
    private static string outputPath;
    private static NavMeshDataInstance navMesh;
    private static NavMeshAgent agent;
    private static Vector3 sampledStart;
    private static Vector3 sampledEnd;
    private static string pathStatus;
    private static Vector3[] corners;
    private static float startTime;
    private static int lastFrame = -1;
    private static readonly List<MotionSample> samples = new List<MotionSample>();

    static UnityCoopInfantryMotionExport()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
        EditorApplication.update += OnEditorUpdate;
    }

    public static void Begin()
    {
        ReadArguments();
        EditorApplication.isPlaying = true;
    }

    private static void ReadArguments()
    {
        string[] arguments = Environment.GetCommandLineArgs();
        int inputFlag = Array.IndexOf(arguments, "-coopMotionInput");
        int outputFlag = Array.IndexOf(arguments, "-coopMotionOutput");
        if (inputFlag < 0 || inputFlag + 1 >= arguments.Length ||
            outputFlag < 0 || outputFlag + 1 >= arguments.Length)
            throw new InvalidOperationException("Missing co-op motion paths.");

        input = UnityEngine.JsonUtility.FromJson<ProbeInput>(
            File.ReadAllText(arguments[inputFlag + 1]));
        outputPath = Path.GetFullPath(arguments[outputFlag + 1]);
        if (input == null || input.asset !=
            "Assets/NavMeshData/NavMesh_7.asset" || input.speed != 0.9f)
            throw new InvalidOperationException(
                "Co-op motion input is not the recovered Desert Assaulter probe.");
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.EnteredPlayMode)
            return;
        if (input == null)
            ReadArguments();
        NavMeshData mesh = AssetDatabase.LoadAssetAtPath<NavMeshData>(
            input.asset);
        if (mesh == null)
            throw new InvalidOperationException("Recovered co-op NavMesh is absent.");
        navMesh = NavMesh.AddNavMeshData(mesh);
        NavMeshHit startHit;
        NavMeshHit endHit;
        if (!navMesh.valid ||
            !NavMesh.SamplePosition(input.start, out startHit, 3f,
                NavMesh.AllAreas) ||
            !NavMesh.SamplePosition(input.end, out endHit, 3f,
                NavMesh.AllAreas))
            throw new InvalidOperationException("Co-op motion endpoints are off mesh.");

        sampledStart = startHit.position;
        sampledEnd = endHit.position;
        var route = new NavMeshPath();
        NavMesh.CalculatePath(sampledStart, sampledEnd, NavMesh.AllAreas,
            route);
        pathStatus = route.status.ToString();
        corners = route.corners;
        var actor = new GameObject("DisposableCoopAssaulterMotionProbe");
        actor.transform.position = sampledStart;
        agent = actor.AddComponent<NavMeshAgent>();
        agent.radius = 0.17f;
        agent.height = 0.52f;
        agent.speed = input.speed;
        agent.acceleration = 10f;
        agent.angularSpeed = 600f;
        agent.stoppingDistance = 0f;
        agent.autoBraking = true;
        agent.autoRepath = true;
        agent.obstacleAvoidanceType =
            ObstacleAvoidanceType.LowQualityObstacleAvoidance;
        if (!agent.Warp(sampledStart) || !agent.SetDestination(sampledEnd))
            throw new InvalidOperationException("Unity agent rejected the co-op route.");
        Application.targetFrameRate = 30;
        startTime = Time.time;
    }

    private static void OnEditorUpdate()
    {
        if (input == null || agent == null || !EditorApplication.isPlaying ||
            Time.frameCount == lastFrame)
            return;
        lastFrame = Time.frameCount;
        float seconds = Time.time - startTime;
        float remaining = agent.remainingDistance;
        if (float.IsNaN(remaining) || float.IsInfinity(remaining))
            remaining = -1f;
        samples.Add(new MotionSample
        {
            frame = Time.frameCount,
            seconds = seconds,
            position = agent.transform.position,
            velocity = agent.velocity,
            rotation = agent.transform.rotation,
            remainingDistance = remaining
        });

        Vector3 delta = agent.transform.position - sampledEnd;
        delta.y = 0;
        if ((delta.magnitude >= 0.04f || agent.pathPending) && seconds < 30f)
            return;

        string status = delta.magnitude < 0.04f ? "Arrived" : "TimedOut";
        var result = new MotionResult
        {
            asset = input.asset,
            status = status,
            requestedStart = input.start,
            requestedEnd = input.end,
            sampledStart = sampledStart,
            sampledEnd = sampledEnd,
            pathStatus = pathStatus,
            corners = corners,
            speed = input.speed,
            samples = samples.ToArray()
        };
        File.WriteAllText(outputPath, UnityEngine.JsonUtility.ToJson(result));
        Debug.Log("COOP_MOTION_DONE " + status + " samples=" + samples.Count);
        navMesh.Remove();
        EditorApplication.Exit(status == "Arrived" ? 0 : 1);
    }
}

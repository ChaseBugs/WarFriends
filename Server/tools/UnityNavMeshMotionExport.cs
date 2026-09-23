// Run only in the disposable Unity 2018.3 NavMesh project, never the Client.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[InitializeOnLoad]
public static class UnityNavMeshMotionExport
{
    [Serializable] private sealed class Input { public int version; public MapInput[] maps; }
    [Serializable] private sealed class MapInput
    { public string scene; public string asset; public CaseInput[] cases; }
    [Serializable] private sealed class CaseInput
    { public string id; public int spawnFileId; public int rusherFileId; public Vector3 start; public Vector3 end; }
    [Serializable] private sealed class Sample
    { public int frame; public float time; public Vector3 position; public Vector3 velocity; public float remainingDistance; }
    [Serializable] private sealed class Result
    { public string scene; public string asset; public string caseId; public string status;
      public float runtimeSpeed; public Vector3 sampledStart; public Vector3 sampledEnd;
      public Sample[] samples; }

    private static NavMeshDataInstance instance;
    private static NavMeshAgent agent;
    private static string output;
    private static string scene;
    private static string asset;
    private static string caseId;
    private static float runtimeSpeed=1f;
    private static Vector3 start;
    private static Vector3 end;
    private static Vector3 sampledStart;
    private static Vector3 sampledEnd;
    private static float beginTime;
    private static int lastFrame=-1;
    private static readonly List<Sample> samples=new List<Sample>();

    static UnityNavMeshMotionExport()
    {
        EditorApplication.playModeStateChanged+=StateChanged;
        EditorApplication.update+=Update;
    }

    public static void Begin()
    {
        ReadArguments();
        EditorApplication.isPlaying=true;
    }

    private static void ReadArguments()
    {
        var args=Environment.GetCommandLineArgs();
        int inputFlag=Array.IndexOf(args,"-navMeshMotionInput");
        int outputFlag=Array.IndexOf(args,"-navMeshMotionOutput");
        int caseFlag=Array.IndexOf(args,"-navMeshMotionCase");
        int sceneFlag=Array.IndexOf(args,"-navMeshMotionScene");
        int speedFlag=Array.IndexOf(args,"-navMeshMotionSpeed");
        if(inputFlag<0 || inputFlag+1>=args.Length || outputFlag<0 || outputFlag+1>=args.Length ||
           caseFlag<0 || caseFlag+1>=args.Length || sceneFlag<0 || sceneFlag+1>=args.Length)
            throw new InvalidOperationException("Missing NavMesh motion input, output, scene or case.");
        output=Path.GetFullPath(args[outputFlag+1]);
        caseId=args[caseFlag+1];
        if(speedFlag>=0)
        {
            if(speedFlag+1>=args.Length || !float.TryParse(args[speedFlag+1],
                NumberStyles.Float,CultureInfo.InvariantCulture,out runtimeSpeed) ||
                (runtimeSpeed!=.8f && runtimeSpeed!=.9f && runtimeSpeed!=1f))
                throw new InvalidOperationException("Unsupported source infantry runtime speed.");
        }
        string requestedScene=args[sceneFlag+1];
        var input=JsonUtility.FromJson<Input>(File.ReadAllText(args[inputFlag+1]));
        if(input==null || input.version!=1 || input.maps==null || input.maps.Length!=5)
            throw new InvalidDataException("Incomplete pinned NavMesh cases.");
        int found=0;
        foreach(var map in input.maps)
            foreach(var probe in map.cases)
                if(probe.id==caseId && map.scene==requestedScene)
                {scene=map.scene;asset=map.asset;start=probe.start;end=probe.end;found++;}
        if(found!=1 || Array.IndexOf(new[]{"Assets/NavMeshData/NavMesh_5.asset",
            "Assets/NavMeshData/NavMesh_8.asset","Assets/NavMeshData/NavMesh_2.asset",
            "Assets/NavMeshData/NavMesh_6.asset","Assets/NavMeshData/NavMesh_4.asset"},asset)<0)
            throw new InvalidDataException("Missing pinned motion case or map asset.");
    }

    private static void StateChanged(PlayModeStateChange state)
    {
        if(state!=PlayModeStateChange.EnteredPlayMode)return;
        if(output==null)ReadArguments();
        var mesh=AssetDatabase.LoadAssetAtPath<NavMeshData>(asset);
        if(mesh==null)throw new InvalidDataException("Missing source NavMeshData.");
        instance=NavMesh.AddNavMeshData(mesh);
        NavMeshHit first,last;
        if(!instance.valid || !NavMesh.SamplePosition(start,out first,3f,NavMesh.AllAreas) ||
           !NavMesh.SamplePosition(end,out last,3f,NavMesh.AllAreas))
            throw new InvalidDataException("Source motion endpoints cannot be sampled.");
        sampledStart=first.position;sampledEnd=last.position;
        var actor=new GameObject("DisposableInfantryMotionProbe");
        actor.transform.position=sampledStart;
        agent=actor.AddComponent<NavMeshAgent>();
        agent.radius=.17f;agent.height=.52f;agent.speed=runtimeSpeed;
        agent.acceleration=10f;
        agent.angularSpeed=600f;agent.stoppingDistance=0f;
        agent.autoBraking=true;agent.autoRepath=true;
        agent.obstacleAvoidanceType=ObstacleAvoidanceType.LowQualityObstacleAvoidance;
        if(!agent.Warp(sampledStart) || !agent.SetDestination(sampledEnd))
            throw new InvalidDataException("Unity agent rejected pinned route.");
        Application.targetFrameRate=30;
        beginTime=Time.time;
        Debug.Log("NAVMESH_MOTION_START "+caseId);
    }

    private static void Update()
    {
        if(output==null || !EditorApplication.isPlaying || agent==null ||
           Time.frameCount==lastFrame)return;
        lastFrame=Time.frameCount;
        float elapsed=Time.time-beginTime;
        float remaining=agent.remainingDistance;
        if(float.IsNaN(remaining) || float.IsInfinity(remaining))remaining=-1f;
        samples.Add(new Sample{frame=Time.frameCount,time=elapsed,position=agent.transform.position,
            velocity=agent.velocity,remainingDistance=remaining});
        var delta=agent.transform.position-sampledEnd;delta.y=0;
        if((delta.magnitude<.04f && !agent.pathPending) || elapsed>=30f)
        {
            string status=delta.magnitude<.04f ? "Arrived" : "TimedOut";
            File.WriteAllText(output,JsonUtility.ToJson(new Result{scene=scene,asset=asset,
                caseId=caseId,status=status,runtimeSpeed=runtimeSpeed,
                sampledStart=sampledStart,
                sampledEnd=sampledEnd,samples=samples.ToArray()}));
            Debug.Log("NAVMESH_MOTION_DONE "+status+" samples="+samples.Count);
            instance.Remove();
            EditorApplication.Exit(status=="Arrived" ? 0 : 1);
        }
    }
}

// Run only in the disposable Unity 2018.3 NavMesh project, never the Client.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[InitializeOnLoad]
public static class UnityNavMeshCrowdExport
{
    [Serializable] private sealed class Input
    { public int version; public string scene; public string asset; public CaseInput[] cases; }
    [Serializable] private sealed class CaseInput
    { public string id; public Vector3 start; public Vector3 end; public float speed; public int delayFrames;
      public bool stationary; }
    [Serializable] private sealed class Sample
    { public int frame; public float time; public Vector3 position; public Vector3 velocity; }
    [Serializable] private sealed class CaseResult
    { public string id; public Vector3 sampledStart; public Vector3 sampledEnd; public string status;
      public int spawnFrame; public Sample[] samples; }
    [Serializable] private sealed class Result
    { public int version; public string scene; public string asset; public CaseResult[] cases; }

    private static Input input;
    private static string output;
    private static NavMeshDataInstance instance;
    private static NavMeshAgent[] agents;
    private static Vector3[] sampledStart;
    private static Vector3[] sampledEnd;
    private static List<Sample>[] samples;
    private static float beginTime;
    private static int beginFrame;
    private static int lastFrame=-1;

    static UnityNavMeshCrowdExport()
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
        string[] args=Environment.GetCommandLineArgs();
        int inFlag=Array.IndexOf(args,"-navMeshCrowdInput");
        int outFlag=Array.IndexOf(args,"-navMeshCrowdOutput");
        if(inFlag<0 || outFlag<0 || inFlag+1>=args.Length || outFlag+1>=args.Length)
            throw new InvalidOperationException("Missing NavMesh crowd paths.");
        output=Path.GetFullPath(args[outFlag+1]);
        input=JsonUtility.FromJson<Input>(File.ReadAllText(args[inFlag+1]));
        if(input==null || input.version!=1 || input.cases==null ||
           (input.cases.Length!=2 && input.cases.Length!=3) ||
           input.scene!="Assets/Scenes/Park_Multiplayer.unity" ||
           input.asset!="Assets/NavMeshData/NavMesh_6.asset" ||
           input.cases.Select(row=>row.id).Distinct().Count()!=input.cases.Length ||
           !input.cases.Any(row=>!row.stationary))
            throw new InvalidDataException("Invalid pinned crowd case identities.");
        foreach(var row in input.cases)
            if(row.speed!=.9f || row.delayFrames<0 || row.delayFrames>30 ||
               string.IsNullOrEmpty(row.id))
                throw new InvalidDataException("Unexpected source infantry speed or case.");
    }

    private static void StateChanged(PlayModeStateChange state)
    {
        if(state!=PlayModeStateChange.EnteredPlayMode)return;
        if(output==null)ReadArguments();
        var mesh=AssetDatabase.LoadAssetAtPath<NavMeshData>(input.asset);
        if(mesh==null)throw new InvalidDataException("Missing source NavMeshData.");
        instance=NavMesh.AddNavMeshData(mesh);
        if(!instance.valid)throw new InvalidDataException("Invalid source NavMeshData.");
        agents=new NavMeshAgent[input.cases.Length];
        sampledStart=new Vector3[input.cases.Length];sampledEnd=new Vector3[input.cases.Length];
        samples=new List<Sample>[input.cases.Length];
        for(int i=0;i<input.cases.Length;i++)
        {
            var row=input.cases[i];NavMeshHit from,to;
            if(!NavMesh.SamplePosition(row.start,out from,3f,NavMesh.AllAreas) ||
               !NavMesh.SamplePosition(row.end,out to,3f,NavMesh.AllAreas))
                throw new InvalidDataException("Crowd endpoints cannot be sampled.");
            sampledStart[i]=from.position;sampledEnd[i]=to.position;
            samples[i]=new List<Sample>();
        }
        Application.targetFrameRate=30;
        beginTime=Time.time;beginFrame=Time.frameCount;
        Debug.Log("NAVMESH_CROWD_START");
    }

    private static void SpawnAgent(int i)
    {
        var row=input.cases[i];
        var actor=new GameObject("DisposableCrowdAgent"+i);
        actor.transform.position=sampledStart[i];
        var agent=actor.AddComponent<NavMeshAgent>();
        agent.radius=.17f;agent.height=.52f;agent.speed=row.speed;
        agent.acceleration=10f;agent.angularSpeed=600f;
        agent.stoppingDistance=0f;agent.autoBraking=true;agent.autoRepath=true;
        agent.obstacleAvoidanceType=ObstacleAvoidanceType.LowQualityObstacleAvoidance;
        if(!agent.Warp(sampledStart[i]) ||
           !row.stationary && !agent.SetDestination(sampledEnd[i]))
            throw new InvalidDataException("Unity agent rejected crowd route.");
        if(row.stationary)agent.Stop();
        agents[i]=agent;
    }

    private static void Update()
    {
        if(output==null || !EditorApplication.isPlaying || agents==null ||
           Time.frameCount==lastFrame)return;
        lastFrame=Time.frameCount;
        float elapsed=Time.time-beginTime;
        bool arrived=true;
        for(int i=0;i<input.cases.Length;i++)
        {
            if(agents[i]==null && Time.frameCount-beginFrame>=input.cases[i].delayFrames)
                SpawnAgent(i);
            if(agents[i]==null){arrived=false;continue;}
            var agent=agents[i];
            samples[i].Add(new Sample{frame=Time.frameCount,time=elapsed,
                position=agent.transform.position,velocity=agent.velocity});
            var delta=agent.transform.position-sampledEnd[i];delta.y=0;
            if(!input.cases[i].stationary &&
               (delta.magnitude>=.04f || agent.pathPending))arrived=false;
        }
        if(!arrived && elapsed<30f)return;
        var result=new Result{version=1,scene=input.scene,asset=input.asset,
            cases=new CaseResult[input.cases.Length]};
        for(int i=0;i<input.cases.Length;i++)
        {
            var delta=agents[i].transform.position-sampledEnd[i];delta.y=0;
            result.cases[i]=new CaseResult{id=input.cases[i].id,
                sampledStart=sampledStart[i],sampledEnd=sampledEnd[i],
                status=input.cases[i].stationary?"Stationary":
                    delta.magnitude<.04f?"Arrived":"TimedOut",
                spawnFrame=samples[i][0].frame,samples=samples[i].ToArray()};
        }
        File.WriteAllText(output,JsonUtility.ToJson(result));
        Debug.Log("NAVMESH_CROWD_DONE "+string.Join(" ",
            Array.ConvertAll(result.cases,row=>row.status)));
        instance.Remove();
        EditorApplication.Exit(arrived?0:1);
    }
}

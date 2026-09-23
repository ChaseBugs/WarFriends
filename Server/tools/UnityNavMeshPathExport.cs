// Execute in the disposable Unity 2018.3.0f2 NavMesh project, not the Client.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public static class UnityNavMeshPathExport
{
    [Serializable] private sealed class Input { public int version; public MapInput[] maps; }
    [Serializable] private sealed class MapInput
    { public string scene; public string asset; public CaseInput[] cases; }
    [Serializable] private sealed class CaseInput
    { public string id; public int spawnFileId; public int rusherFileId; public Vector3 start; public Vector3 end; }
    [Serializable] private sealed class MapResult
    { public string scene; public string asset; public CaseResult[] cases; }
    [Serializable] private sealed class CaseResult
    {
        public string id;
        public int spawnFileId;
        public int rusherFileId;
        public bool startSampled;
        public bool endSampled;
        public Vector3 sampledStart;
        public Vector3 sampledEnd;
        public string status;
        public Vector3[] corners;
    }

    public static void Export()
    {
        var args=Environment.GetCommandLineArgs();
        int inputFlag=Array.IndexOf(args,"-navMeshPathsInput");
        int outputFlag=Array.IndexOf(args,"-navMeshPathsOutput");
        if(inputFlag<0 || inputFlag+1>=args.Length || outputFlag<0 || outputFlag+1>=args.Length)
            throw new InvalidOperationException("Missing NavMesh path input/output arguments.");
        var input=JsonUtility.FromJson<Input>(File.ReadAllText(args[inputFlag+1]));
        if(input==null || input.version!=1 || input.maps==null || input.maps.Length!=5)
            throw new InvalidDataException("Incomplete pinned route probes.");
        string output=Path.GetFullPath(args[outputFlag+1]);
        Directory.CreateDirectory(output);
        int[] assetNumbers={5,8,2,6,4};
        for(int m=0;m<input.maps.Length;m++)
        {
            var row=input.maps[m];
            string name="NavMesh_"+assetNumbers[m];
            string asset="Assets/NavMeshData/"+name+".asset";
            if(row.asset!=asset || row.cases==null || row.cases.Length<64 || row.cases.Length>96)
                throw new InvalidDataException("Wrong NavMesh route map or case count.");
            var mesh=AssetDatabase.LoadAssetAtPath<NavMeshData>(asset);
            if(mesh==null)throw new InvalidDataException("Missing "+asset);
            var instance=NavMesh.AddNavMeshData(mesh);
            if(!instance.valid)throw new InvalidDataException("Unity rejected "+asset);
            try
            {
                var cases=new CaseResult[row.cases.Length];
                int complete=0,partial=0,failed=0;
                for(int i=0;i<cases.Length;i++)
                {
                    var probe=row.cases[i];
                    var result=new CaseResult{id=probe.id,spawnFileId=probe.spawnFileId,
                        rusherFileId=probe.rusherFileId,corners=new Vector3[0]};
                    NavMeshHit startHit,endHit;
                    result.startSampled=NavMesh.SamplePosition(probe.start,out startHit,3f,NavMesh.AllAreas);
                    result.endSampled=NavMesh.SamplePosition(probe.end,out endHit,3f,NavMesh.AllAreas);
                    if(result.startSampled)result.sampledStart=startHit.position;
                    if(result.endSampled)result.sampledEnd=endHit.position;
                    if(result.startSampled && result.endSampled)
                    {
                        var path=new NavMeshPath();
                        NavMesh.CalculatePath(startHit.position,endHit.position,NavMesh.AllAreas,path);
                        result.status=path.status.ToString();
                        result.corners=path.corners;
                    }
                    else result.status="SampleFailed";
                    if(result.status=="PathComplete")complete++;
                    else if(result.status=="PathPartial")partial++;
                    else failed++;
                    cases[i]=result;
                }
                File.WriteAllText(Path.Combine(output,name+".json"),
                    JsonUtility.ToJson(new MapResult{scene=row.scene,asset=asset,cases=cases}));
                Debug.Log("NAVMESH_PATH_EXPORT "+name+" complete="+complete+
                    " partial="+partial+" failed="+failed);
            }
            finally {instance.Remove();}
        }
    }
}

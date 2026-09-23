// Run only in a disposable Unity 2018.3.0f2 project containing the five
// recovered NavMeshData assets. Never install this tool in the recovered Client.
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public static class UnityNavMeshExport
{
    [Serializable]
    private sealed class MeshRows
    {
        public string asset;
        public Vector3[] vertices;
        public int[] indices;
        public int[] areas;
    }

    public static void Export()
    {
        var args=Environment.GetCommandLineArgs();
        int marker=Array.IndexOf(args,"-navMeshOutput");
        if(marker<0 || marker+1>=args.Length)
            throw new InvalidOperationException("Missing -navMeshOutput directory.");
        string output=Path.GetFullPath(args[marker+1]);
        Directory.CreateDirectory(output);
        int[] assets={5,8,2,6,4};
        foreach(int number in assets)
        {
            string name="NavMesh_"+number;
            string assetPath="Assets/NavMeshData/"+name+".asset";
            var data=AssetDatabase.LoadAssetAtPath<NavMeshData>(assetPath);
            if(data==null)throw new InvalidDataException("Missing recovered "+assetPath);
            var instance=NavMesh.AddNavMeshData(data);
            if(!instance.valid)throw new InvalidDataException("Unity rejected "+assetPath);
            try
            {
                var tri=NavMesh.CalculateTriangulation();
                if(tri.vertices==null || tri.indices==null || tri.areas==null ||
                   tri.vertices.Length<100 || tri.indices.Length<300 ||
                   tri.indices.Length%3!=0 || tri.areas.Length!=tri.indices.Length/3)
                    throw new InvalidDataException("Invalid Unity triangulation for "+assetPath);
                foreach(int index in tri.indices)
                    if(index<0 || index>=tri.vertices.Length)
                        throw new InvalidDataException("Invalid Unity triangle index.");
                var row=new MeshRows{asset=assetPath,vertices=tri.vertices,
                    indices=tri.indices,areas=tri.areas};
                File.WriteAllText(Path.Combine(output,name+".json"),JsonUtility.ToJson(row));
                Debug.Log("NAVMESH_EXPORT "+name+" vertices="+tri.vertices.Length+
                    " triangles="+tri.indices.Length/3);
            }
            finally {instance.Remove();}
        }
    }
}

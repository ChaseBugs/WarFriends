using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public static class SelfHostedAirGeometryExport
{
    public static void Run()
    {
        try
        {
            string output=Environment.GetEnvironmentVariable("WAR_AIR_GEOMETRY_OUTPUT");
            if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_AIR_GEOMETRY_OUTPUT.");
            var meshes=new Dictionary<string,object>();
            var units=new[]{"Helicopter","assaultHelicopter","dronePrototype"}.Select(name=>
            {
                string path="Assets/GameObject/"+name+".prefab";
                var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if(prefab==null)throw new InvalidOperationException("Missing air prefab "+path);
                var root=prefab.transform;
                var colliders=prefab.GetComponentsInChildren<Collider>(true).Select(c=>
                {
                    var box=c as BoxCollider;var sphere=c as SphereCollider;var capsule=c as CapsuleCollider;var mesh=c as MeshCollider;
                    if(box==null&&sphere==null&&capsule==null&&mesh==null)throw new InvalidOperationException("Unsupported air collider "+c.GetType());
                    string meshId=null;
                    if(mesh!=null&&mesh.sharedMesh!=null)
                    {
                        string guid;long id;
                        if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(mesh.sharedMesh,out guid,out id))throw new InvalidOperationException("Air mesh identity absent.");
                        meshId=guid+":"+id;
                        if(!meshes.ContainsKey(meshId))meshes.Add(meshId,new{source=AssetDatabase.GetAssetPath(mesh.sharedMesh),sha256=Digest(AssetDatabase.GetAssetPath(mesh.sharedMesh)),
                            vertices=mesh.sharedMesh.vertices.Select(V).ToArray(),triangles=mesh.sharedMesh.triangles});
                    }
                    Vector3 localCenter=box!=null?box.center:sphere!=null?sphere.center:capsule!=null?capsule.center:Vector3.zero;
                    return new{componentFileId=Id(c),type=c.GetType().Name,
                        center=V(root.InverseTransformPoint(c.transform.TransformPoint(localCenter))),
                        rotation=Q(Quaternion.Inverse(root.rotation)*c.transform.rotation),
                        scale=V(c.transform.lossyScale),enabled=c.enabled,trigger=c.isTrigger,meshId=meshId,
                        convex=mesh!=null&&mesh.convex};
                }).ToArray();
                var shootables=prefab.GetComponentsInChildren<GameShootableEntity>(true).Select(s=>new{
                    componentFileId=Id(s),targets=(s.targets!=null&&s.targets.Count>0?
                        s.targets.Select(t=>new{transformFileId=Id(t.transform),type=(int)t.type,position=V(root.InverseTransformPoint(t.transform.position))}):
                        s.shootTargets.Select(t=>new{transformFileId=Id(t),type=1,position=V(root.InverseTransformPoint(t.position))})).ToArray()}).ToArray();
                return new{source=path,sha256=Digest(path),colliders=colliders,shootables=shootables};
            }).ToArray();
            File.WriteAllText(output,JsonConvert.SerializeObject(new{client="1.4.0",units=units,meshes=meshes},Formatting.Indented)+"\n");
            Debug.Log("AIR_GEOMETRY_EXPORT_PASSED units="+units.Length+" colliders="+units.Sum(u=>u.colliders.Length)+" meshes="+meshes.Count);
            EditorApplication.Exit(0);
        }
        catch(Exception exception){Debug.LogError(exception);EditorApplication.Exit(1);}
    }
    private static long Id(UnityEngine.Object value)
    {string guid;long id;if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(value,out guid,out id))throw new InvalidOperationException("Air component identity absent.");return id;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
    private static string Digest(string path)
    {using(var hash=SHA256.Create())return string.Concat(hash.ComputeHash(File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Application.dataPath),path))).Select(b=>b.ToString("x2")));}
}

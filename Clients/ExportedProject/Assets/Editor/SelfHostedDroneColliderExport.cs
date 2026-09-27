using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
public static class SelfHostedDroneColliderExport
{
    public static void Run()
    {
        try
        {
            string output=Environment.GetEnvironmentVariable("WAR_DRONE_COLLIDER_OUTPUT");
            if(string.IsNullOrEmpty(output))throw new Exception("Set WAR_DRONE_COLLIDER_OUTPUT.");
            var prefab=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/dronePrototype.prefab");
            var samples=new List<object>();
            foreach(var rotation in new[]{Quaternion.identity,Quaternion.Euler(12,35,-7),Quaternion.Euler(-35,150,70),Quaternion.Euler(80,-100,-45)})
                foreach(var source in prefab.GetComponentsInChildren<Collider>(true))
                {
                    var root=new GameObject("DroneColliderProbe");
                    try
                    {
                        root.transform.position=new Vector3(2,3,4);root.transform.rotation=rotation;
                        var child=new GameObject("Collider");child.transform.SetParent(root.transform,false);
                        child.transform.localPosition=prefab.transform.InverseTransformPoint(source.transform.position);
                        child.transform.localRotation=Quaternion.Inverse(prefab.transform.rotation)*source.transform.rotation;
                        child.transform.localScale=source.transform.lossyScale;
                        Collider collider;
                        var box=source as BoxCollider;
                        if(box!=null){var copy=child.AddComponent<BoxCollider>();copy.center=box.center;copy.size=box.size;collider=copy;}
                        else{var sphere=(SphereCollider)source;var copy=child.AddComponent<SphereCollider>();copy.center=sphere.center;copy.radius=sphere.radius;collider=copy;}
                        Physics.SyncTransforms();
                        string guid;long id;AssetDatabase.TryGetGUIDAndLocalFileIdentifier(source,out guid,out id);
                        foreach(var axis in new[]{Vector3.right,Vector3.up,Vector3.forward})
                            foreach(float offset in new[]{0f,.1f,.5f})
                            {
                                var origin=root.transform.position-axis*2+Vector3.Cross(axis,Vector3.one).normalized*offset;
                                RaycastHit hit;bool success=collider.Raycast(new Ray(origin,axis),out hit,5);
                                samples.Add(new{position=V(root.transform.position),rotation=Q(rotation),colliderFileId=id,origin=V(origin),direction=V(axis),range=5f,hit=success,distance=success?(float?)hit.distance:null});
                            }
                    }
                    finally{UnityEngine.Object.DestroyImmediate(root);}
                }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,source="Assets/GameObject/dronePrototype.prefab",sha256=Digest("Assets/GameObject/dronePrototype.prefab"),probes=samples},Formatting.Indented)+"\n");
            Debug.Log("DRONE_COLLIDER_EXPORT_PASSED probes="+samples.Count);EditorApplication.Exit(0);
        }
        catch(Exception e){Debug.LogError(e);EditorApplication.Exit(1);}
    }
    private static string Digest(string path){using(var h=SHA256.Create())return string.Concat(h.ComputeHash(File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Application.dataPath),path))).Select(b=>b.ToString("x2")));}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}

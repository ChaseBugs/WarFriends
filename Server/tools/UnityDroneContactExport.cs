using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class UnityDroneContactExport
{
    public static void Run()
    {
        string input=Environment.GetEnvironmentVariable("WAR_DRONE_ROUTES_INPUT");
        string output=Environment.GetEnvironmentVariable("WAR_DRONE_CONTACT_OUTPUT");
        if(string.IsNullOrEmpty(input)||string.IsNullOrEmpty(output))throw new InvalidOperationException("Set contact export paths.");
        const string prefabPath="Assets/GameObject/dronePrototype.prefab";
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        var previous=EditorSceneManager.GetSceneManagerSetup();bool automatic=Physics.autoSimulation;
        var rows=new List<object>();
        try
        {
            Physics.autoSimulation=false;
            foreach(var map in JObject.Parse(File.ReadAllText(input))["maps"])
            {
                string source=(string)map["source"];
                if(Hash(source)!=(string)map["sha256"])throw new InvalidOperationException("Scene revision changed.");
                EditorSceneManager.OpenScene(source);
                foreach(int fraction in new[]{1,2})
                {
                    var route=map["routes"].First(r=>(string)r["collection"]=="spawnPointsCollectionDrones"&&
                        (int)r["fraction"]==fraction);
                    var waypoint=route["waypoints"].First();var xyz=waypoint["worldPosition"];
                    var drone=CopyGeometry(prefab.transform,null);
                    try
                    {
                        drone.layer=fraction==1?27:26;
                        drone.transform.position=new Vector3((float)xyz[0],(float)xyz[1],(float)xyz[2]);
                        drone.transform.rotation=Quaternion.identity;
                        var body=drone.AddComponent<Rigidbody>();EditorUtility.CopySerialized(prefab.GetComponent<Rigidbody>(),body);
                        var observer=drone.AddComponent<DroneCollisionObserver>();
                        body.isKinematic=false;body.velocity=Vector3.zero;body.angularVelocity=Vector3.zero;
                        Physics.SyncTransforms();var frames=new List<object>();
                        var sphere=drone.GetComponentsInChildren<SphereCollider>().Single();
                        var box=drone.GetComponent<BoxCollider>();int boxMask=0;
                        for(int layer=0;layer<32;layer++)
                            if(!Physics.GetIgnoreLayerCollision(drone.layer,layer))boxMask|=1<<layer;
                        int sphereMask=0;
                        for(int layer=0;layer<32;layer++)
                            if(!Physics.GetIgnoreLayerCollision(sphere.gameObject.layer,layer))sphereMask|=1<<layer;
                        for(int frame=0;frame<=150;frame++)
                        {
                            var center=sphere.transform.TransformPoint(sphere.center);
                            var scale=sphere.transform.lossyScale;
                            float radius=sphere.radius*Mathf.Max(Mathf.Abs(scale.x),Mathf.Abs(scale.y),Mathf.Abs(scale.z));
                            bool sphereMapOverlap=Physics.OverlapSphere(center,radius,sphereMask,QueryTriggerInteraction.Ignore)
                                .Any(c=>!c.transform.IsChildOf(drone.transform));
                            var boxCenter=box.transform.TransformPoint(box.center);
                            var boxSize=Vector3.Scale(box.size,box.transform.lossyScale);
                            bool boxMapOverlap=Physics.OverlapBox(boxCenter,boxSize*.5f,box.transform.rotation,
                                boxMask,QueryTriggerInteraction.Ignore).Any(c=>!c.transform.IsChildOf(drone.transform));
                            frames.Add(new{frame,position=Vec(body.position),velocity=Vec(body.velocity),
                                rotation=new[]{body.rotation.x,body.rotation.y,body.rotation.z,body.rotation.w},
                                angularVelocity=Vec(body.angularVelocity),sphereMapOverlap,
                                sphereCenter=Vec(center),sphereRadius=radius,sphereMask=((uint)sphereMask).ToString("x8"),
                                boxMapOverlap,boxCenter=Vec(boxCenter),boxSize=Vec(boxSize),
                                boxMask=((uint)boxMask).ToString("x8")});
                            if(frame<150){observer.Frame=frame+1;Physics.Simulate(Time.fixedDeltaTime);}
                        }
                        rows.Add(new{source,sourceSha256=Hash(source),fraction,
                            waypointFileId=(long)waypoint["componentFileId"],frames,collisionCallbacks=observer.Rows});
                    }
                    finally{UnityEngine.Object.DestroyImmediate(drone);}
                }
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,unityVersion=Application.unityVersion,
                prefabSource=prefabPath,prefabSha256=Hash(prefabPath),scenario="isolated-source-collider-fall-in-map",
                fixedTimestep=Time.fixedDeltaTime,rows},Formatting.Indented)+"\n");
            Debug.Log("WAR_DRONE_CONTACT_EXPORT_PASS");
        }
        finally
        {
            Physics.autoSimulation=automatic;
            if(previous.Any(s=>s.isLoaded)&&previous.Any(s=>s.isActive))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
        }
    }
    private static GameObject CopyGeometry(Transform source,Transform parent)
    {
        var result=new GameObject(source.name);result.layer=source.gameObject.layer;
        result.transform.SetParent(parent,false);result.transform.localPosition=source.localPosition;
        result.transform.localRotation=source.localRotation;result.transform.localScale=source.localScale;
        result.SetActive(source.gameObject.activeSelf);
        foreach(var collider in source.GetComponents<Collider>())
            EditorUtility.CopySerialized(collider,result.AddComponent(collider.GetType()));
        foreach(Transform child in source)CopyGeometry(child,result.transform);
        return result;
    }
    private static float[] Vec(Vector3 value){return new[]{value.x,value.y,value.z};}
    private static string Hash(string path)
    {using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
}

[ExecuteInEditMode]
public sealed class DroneCollisionObserver:MonoBehaviour
{
    public int Frame;
    public readonly List<object> Rows=new List<object>();
    private void OnCollisionEnter(Collision collision)
    {
        var body=GetComponent<Rigidbody>();var position=body.position;var rotation=body.rotation;
        Rows.Add(new{frame=Frame,other=Path(collision.collider.transform),layer=collision.collider.gameObject.layer,
            rootPosition=new[]{position.x,position.y,position.z},
            rootRotation=new[]{rotation.x,rotation.y,rotation.z,rotation.w},
            contacts=collision.contacts.Select(c=>new{position=new[]{c.point.x,c.point.y,c.point.z},
                normal=new[]{c.normal.x,c.normal.y,c.normal.z},separation=c.separation}).ToArray()});
    }
    private static string Path(Transform value)
    {string path=value.name;while(value.parent!=null){value=value.parent;path=value.name+"/"+path;}return path;}
}

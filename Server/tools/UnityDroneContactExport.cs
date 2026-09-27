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
                        for(int frame=0;frame<=150;frame++)
                        {
                            frames.Add(new{frame,position=Vec(body.position),velocity=Vec(body.velocity),
                                rotation=new[]{body.rotation.x,body.rotation.y,body.rotation.z,body.rotation.w},
                                angularVelocity=Vec(body.angularVelocity)});
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
        Rows.Add(new{frame=Frame,other=collision.collider.name,layer=collision.collider.gameObject.layer,
            contacts=collision.contacts.Select(c=>new{position=new[]{c.point.x,c.point.y,c.point.z},
                normal=new[]{c.normal.x,c.normal.y,c.normal.z},separation=c.separation}).ToArray()});
    }
}

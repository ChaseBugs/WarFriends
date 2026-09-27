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

// A fresh native body at the previously recorded pose separates contact history
// from the public pose/velocity inputs. Never saves the recovered scene.
public static class UnityDroneContactRestartExport
{
    public static void Run()
    {
        string input=Environment.GetEnvironmentVariable("WAR_DRONE_RESTART_INPUT");
        string output=Environment.GetEnvironmentVariable("WAR_DRONE_RESTART_OUTPUT");
        var oracle=JObject.Parse(File.ReadAllText(input));
        var row=oracle["rows"].Single(r=>(string)r["source"]=="Assets/Scenes/Snow_Multiplayer.unity"&&
            (int)r["fraction"]==2&&(float)r["initialRotation"][0]>.1f);
        if(Hash((string)row["source"])!=(string)row["sourceSha256"]||
           Hash((string)oracle["prefabSource"])!=(string)oracle["prefabSha256"])
            throw new InvalidOperationException("Restart oracle scene or prefab revision changed.");
        if((float)oracle["fixedTimestep"]!=Time.fixedDeltaTime||(string)oracle["unityVersion"]!=Application.unityVersion)
            throw new InvalidOperationException("Restart oracle runtime identity changed.");
        string startText=Environment.GetEnvironmentVariable("WAR_DRONE_RESTART_START");
        int start=string.IsNullOrEmpty(startText)?44:int.Parse(startText);
        if(start<0||start>44)throw new InvalidOperationException("Restart frame must precede frame45.");
        var before=row["frames"][start];
        var previous=EditorSceneManager.GetSceneManagerSetup();bool automatic=Physics.autoSimulation;
        GameObject drone=null;
        try
        {
            Physics.autoSimulation=false;
            var scene=EditorSceneManager.OpenScene((string)row["source"]);
            var prefab=AssetDatabase.LoadAssetAtPath<GameObject>((string)oracle["prefabSource"]);
            drone=UnityDroneContactExport.CopyGeometry(prefab.transform,null);drone.layer=26;
            drone.transform.position=Vec(before["position"]);
            var q=before["rotation"];drone.transform.rotation=new Quaternion((float)q[0],(float)q[1],(float)q[2],(float)q[3]);
            var body=drone.AddComponent<Rigidbody>();EditorUtility.CopySerialized(prefab.GetComponent<Rigidbody>(),body);
            var observer=drone.AddComponent<DroneCollisionObserver>();observer.CaptureStay=true;
            observer.SourceColliders=scene.GetRootGameObjects().Where(g=>g!=drone)
                .SelectMany(g=>g.GetComponentsInChildren<Collider>(true)).ToArray();
            body.isKinematic=false;body.velocity=Vec(before["velocity"]);body.angularVelocity=Vec(before["angularVelocity"]);
            Physics.SyncTransforms();var restartFrames=new List<object>();
            for(int frame=start;frame<=45;frame++)
            {
                restartFrames.Add(new{frame,position=Array(body.position),velocity=Array(body.velocity),
                    angularVelocity=Array(body.angularVelocity),rotation=new[]{body.rotation.x,body.rotation.y,body.rotation.z,body.rotation.w}});
                if(frame<45){observer.Frame=frame+1;Physics.Simulate(Time.fixedDeltaTime);}
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,unityVersion=Application.unityVersion,
                scenario="fresh-body-at-persistent-frame"+start,source=row["source"],sourceSha256=row["sourceSha256"],
                prefabSource=oracle["prefabSource"],prefabSha256=oracle["prefabSha256"],fixedTimestep=Time.fixedDeltaTime,
                before,originalAfter=row["frames"][45],freshAfter=new{position=Array(body.position),velocity=Array(body.velocity),
                    angularVelocity=Array(body.angularVelocity),rotation=new[]{body.rotation.x,body.rotation.y,body.rotation.z,body.rotation.w}},
                restartFrames,collisionCallbacks=observer.Rows},Formatting.Indented)+"\n");
            Debug.Log("WAR_DRONE_RESTART_EXPORT_PASS");
        }
        finally
        {
            if(drone!=null)UnityEngine.Object.DestroyImmediate(drone);
            Physics.autoSimulation=automatic;
            if(previous.Any(s=>s.isLoaded)&&previous.Any(s=>s.isActive))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
        }
    }
    static Vector3 Vec(JToken v){return new Vector3((float)v[0],(float)v[1],(float)v[2]);}
    static float[] Array(Vector3 v){return new[]{v.x,v.y,v.z};}
    static string Hash(string path)
    {using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
}

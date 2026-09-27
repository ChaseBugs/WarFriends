using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public static class UnityDroneImpulseExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_DRONE_IMPULSE_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set impulse output.");
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/dronePrototype.prefab");
        bool previous=Physics.autoSimulation;var rows=new List<object>();
        try
        {
            Physics.autoSimulation=false;
            foreach(var rotation in new[]{Quaternion.identity,Quaternion.Euler(10,45,10),Quaternion.Euler(-15,135,5)})
            {
                var drone=UnityDroneContactExport.CopyGeometry(prefab.transform,null);
                try
                {
                    drone.transform.position=new Vector3(0,100,0);drone.transform.rotation=rotation;
                    var body=drone.AddComponent<Rigidbody>();EditorUtility.CopySerialized(prefab.GetComponent<Rigidbody>(),body);
                    body.isKinematic=false;body.velocity=Vector3.zero;body.angularVelocity=Vector3.zero;
                    Physics.SyncTransforms();var root=body.position;
                    var point=root+new Vector3(.3f,.1f,.2f);var impulse=new Vector3(.1f,.2f,-.15f);
                    body.AddForceAtPosition(impulse,point,ForceMode.Impulse);Physics.Simulate(Time.fixedDeltaTime);
                    rows.Add(new{root=Vec(root),rotation=new[]{rotation.x,rotation.y,rotation.z,rotation.w},
                        point=Vec(point),impulse=Vec(impulse),velocity=Vec(body.velocity),angularVelocity=Vec(body.angularVelocity)});
                }
                finally{UnityEngine.Object.DestroyImmediate(drone);}
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,unityVersion=Application.unityVersion,
                scenario="source-body-impulse-at-world-point",fixedTimestep=Time.fixedDeltaTime,rows},Formatting.Indented)+"\n");
            Debug.Log("WAR_DRONE_IMPULSE_EXPORT_PASS");
        }
        finally{Physics.autoSimulation=previous;}
    }
    private static float[] Vec(Vector3 value){return new[]{value.x,value.y,value.z};}
}

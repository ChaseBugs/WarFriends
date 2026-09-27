using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

// Isolated free fall: no gameplay scripts, fabricated ground, or contact policy.
public static class UnityDroneFallExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_DRONE_FALL_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_DRONE_FALL_OUTPUT.");
        const string source="Assets/GameObject/dronePrototype.prefab";
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(source);
        if(prefab==null||prefab.GetComponent<Rigidbody>()==null)
            throw new InvalidOperationException("Missing source Drone Rigidbody.");
        var bodyObject=new GameObject("Drone free-fall oracle");
        bool previous=Physics.autoSimulation;
        try
        {
            var body=bodyObject.AddComponent<Rigidbody>();
            EditorUtility.CopySerialized(prefab.GetComponent<Rigidbody>(),body);
            body.position=new Vector3(0,100,0);body.rotation=Quaternion.identity;
            body.isKinematic=false;body.velocity=Vector3.zero;body.angularVelocity=Vector3.zero;
            Physics.autoSimulation=false;
            var frames=new List<object>();float step=Time.fixedDeltaTime;
            for(int frame=0;frame<=100;frame++)
            {
                frames.Add(new{frame,time=frame*step,
                    position=new[]{body.position.x,body.position.y,body.position.z},
                    velocity=new[]{body.velocity.x,body.velocity.y,body.velocity.z}});
                if(frame<100)Physics.Simulate(step);
            }
            string digest;
            using(var sha=SHA256.Create())digest=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source)))
                .Replace("-","").ToLowerInvariant();
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,source,sha256=digest,
                unityVersion=Application.unityVersion,scenario="isolated-zero-velocity-free-fall",
                fixedTimestep=step,gravity=new[]{Physics.gravity.x,Physics.gravity.y,Physics.gravity.z},
                mass=body.mass,drag=body.drag,angularDrag=body.angularDrag,frames},Formatting.Indented)+"\n");
            Debug.Log("WAR_DRONE_FALL_EXPORT_PASS");
        }
        finally{Physics.autoSimulation=previous;UnityEngine.Object.DestroyImmediate(bodyObject);}
    }
}

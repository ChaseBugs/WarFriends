using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

// Calls the recovered Helicopter.Steer method itself in a disposable editor
// project. No gameplay scene is opened or saved.
public static class UnityHelicopterSteerExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_HELICOPTER_STEER_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set steer export output.");
        const string path="Assets/GameObject/Helicopter.prefab";
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(path);
        var source=prefab.GetComponent<Helicopter>();
        if(source==null||source.breakDistance!=6f||source.breakSpeed!=2f||source.mass!=150f||source.loop)
            throw new InvalidOperationException("Source Helicopter serialized motion changed.");
        var rows=new System.Collections.Generic.List<object>();
        foreach(float x in new[]{0f,5f,8f})
        {
            var root=new GameObject("steer-oracle-root");
            var target=new GameObject("steer-oracle-target");
            var stop=new GameObject("steer-oracle-stop");
            try
            {
                var heli=root.AddComponent<Helicopter>();
                heli.breakDistance=source.breakDistance;heli.breakSpeed=source.breakSpeed;
                heli.mass=source.mass;heli.speed=source.speed;
                root.transform.position=new Vector3(x,0,0);
                target.transform.position=new Vector3(10,0,0);
                stop.transform.position=new Vector3(10,0,0);
                Set(heli,"mTransform",root.transform);
                Set(heli,"mTargetPoint",target.transform);
                Set(heli,"mStopPoint",stop.transform);
                Set(heli,"mVel",Vector3.zero);
                Set(heli,"mActual",0f);
                Set(heli,"mTimeStarted",true);
                Set(heli,"mTimeStart",Time.realtimeSinceStartup-.05f);
                var steer=heli.Steer();
                float delta=(float)Get(heli,"mTimeDelta");
                bool braking=(bool)Get(heli,"mIsBreaking");
                rows.Add(new{x,delta,steer=new[]{steer.x,steer.y,steer.z},braking});
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
                UnityEngine.Object.DestroyImmediate(target);
                UnityEngine.Object.DestroyImmediate(stop);
            }
        }
        File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,unityVersion=Application.unityVersion,
            source=path,prefabSha256=Hash(path),breakDistance=source.breakDistance,
            breakSpeed=source.breakSpeed,mass=source.mass,speed=source.speed,rows},Formatting.Indented)+"\n");
        Debug.Log("WAR_HELICOPTER_STEER_EXPORT_PASS");
    }
    static FieldInfo Field(string name)=>typeof(Helicopter).GetField(name,BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic)
        ??throw new InvalidOperationException("Recovered Helicopter field absent: "+name);
    static void Set(Helicopter instance,string name,object value)=>Field(name).SetValue(instance,value);
    static object Get(Helicopter instance,string name)=>Field(name).GetValue(instance);
    static string Hash(string path)
    {using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
}

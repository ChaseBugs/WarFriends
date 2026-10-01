using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

// Evaluates recovered Helicopter.Update orientation expressions with Unity math
// and the recovered GeometryTools.AngleSigned in a disposable editor project.
public static class UnityHelicopterOrientationExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_HELICOPTER_ORIENTATION_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set orientation export output.");
        const string path="Assets/GameObject/Helicopter.prefab";
        var source=AssetDatabase.LoadAssetAtPath<GameObject>(path).GetComponent<Helicopter>();
        if(source==null||source.multiplier!=50f)
            throw new InvalidOperationException("Recovered Helicopter bank multiplier changed.");
        var frames=new[]{
            new Frame(0,new Vector3(0,0,0),new Vector3(.2f,0,0),new Vector3(.01f,0,0),new Vector3(10,0,0),false),
            new Frame(1,new Vector3(.2f,0,0),new Vector3(.22f,.08f,.01f),new Vector3(.015f,.005f,.002f),new Vector3(10,0,0),false),
            new Frame(2,new Vector3(.42f,.08f,.01f),new Vector3(.22f,.06f,.07f),new Vector3(.001f,0,.02f),new Vector3(5,0,5),false),
            new Frame(3,new Vector3(5,0,5),new Vector3(.14f,.02f,.10f),new Vector3(-.004f,0,-.002f),new Vector3(6,0,6),true),
            new Frame(4,new Vector3(5.8f,0,5.9f),new Vector3(.02f,0,.01f),new Vector3(-.001f,0,0),new Vector3(6,0,6),true)
        };
        Quaternion horizontal=Quaternion.identity,vertical=Quaternion.identity;
        float angle=0f,delta=1f/30f;
        var rows=new System.Collections.Generic.List<object>();
        foreach(var frame in frames)
        {
            Vector3 forward=frame.breaking?frame.target-frame.position:frame.velocity;
            if(forward.y>0f&&!frame.breaking)forward.y*=-1f;
            else forward.y=0f;
            if(forward.sqrMagnitude>0f)
                vertical=Quaternion.Slerp(vertical,Quaternion.LookRotation(forward),
                    frame.breaking?delta*2f:delta*5f);
            if(frame.velocity.sqrMagnitude>0f&&frame.steering.sqrMagnitude>0f)
            {
                float num=frame.steering.magnitude/delta;
                angle=Mathf.Lerp(angle,GeometryTools.AngleSigned(frame.steering,frame.velocity,Vector3.up),delta*5f);
                Quaternion bank=Quaternion.AngleAxis(angle*source.multiplier*num,frame.velocity);
                if((!float.IsNaN(bank.x)&&!float.IsNaN(bank.y))||frame.breaking)
                    horizontal=Quaternion.Slerp(horizontal,frame.breaking?Quaternion.identity:bank,
                        frame.breaking?delta*.5f:delta);
            }
            Quaternion result=horizontal*vertical;
            rows.Add(new{id=frame.id,position=V(frame.position),velocity=V(frame.velocity),
                steering=V(frame.steering),target=V(frame.target),breaking=frame.breaking,
                rotation=Q(result)});
        }
        File.WriteAllBytes(output,System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new{version=1,client="1.4.0",
            unityVersion=Application.unityVersion,source=path,prefabSha256=Hash(path),
            multiplier=source.multiplier,frameDelta=delta,rows},Formatting.Indented)+"\n"));
        Debug.Log("WAR_HELICOPTER_ORIENTATION_EXPORT_PASS");
    }
    private sealed class Frame
    {
        public readonly int id;public readonly Vector3 position,velocity,steering,target;public readonly bool breaking;
        public Frame(int id,Vector3 position,Vector3 velocity,Vector3 steering,Vector3 target,bool breaking)
        {this.id=id;this.position=position;this.velocity=velocity;this.steering=steering;this.target=target;this.breaking=breaking;}
    }
    static float[] V(Vector3 value)=>new[]{value.x,value.y,value.z};
    static float[] Q(Quaternion value)=>new[]{value.x,value.y,value.z,value.w};
    static string Hash(string path)
    {using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
}

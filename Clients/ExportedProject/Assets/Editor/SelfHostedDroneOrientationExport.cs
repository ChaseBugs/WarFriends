using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

// Unity math oracle for recovered expressions, not a live Drone.Update trace.
public static class SelfHostedDroneOrientationExport
{
    public static void Run()
    {
        try
        {
            string output=Environment.GetEnvironmentVariable("WAR_DRONE_ORIENTATION_OUTPUT");
            if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_DRONE_ORIENTATION_OUTPUT.");
            var traces=new List<object>();
            foreach(float scale in new[]{1f,0.000001f,0f})
            {
                Quaternion vertical=Quaternion.identity,horizontal=Quaternion.identity;float angle=0;
                var frames=new List<object>();
                for(int i=0;i<180;i++)
                {
                    float dt=1f/30;Vector3 position=new Vector3(2,3,4);
                    Vector3 velocity=new Vector3(Mathf.Sin(i*.07f)*.02f,.003f,Mathf.Cos(i*.07f)*.02f)*scale;
                    Vector3 steering=new Vector3(Mathf.Cos(i*.11f)*.001f,0,Mathf.Sin(i*.11f)*.001f);
                    Vector3? target=i<60?(Vector3?)new Vector3(-3,1,0):i<120?null:(Vector3?)new Vector3(5,3,8);
                    angle=Mathf.Lerp(angle,GeometryTools.AngleSigned(steering,velocity,Vector3.up),dt*5);
                    float amount=steering.magnitude/dt;
                    if(!((angle>0&&angle<90)||(angle< -270&&angle> -360)))amount=-amount;
                    if(target.HasValue){Vector3 forward=position-target.Value;forward.y=0;
                        vertical=Quaternion.Slerp(vertical,Quaternion.LookRotation(forward),dt*5);}
                    horizontal=Quaternion.Slerp(horizontal,Quaternion.AngleAxis(amount*150000/60,Vector3.Cross(Vector3.up,velocity)),dt);
                    Quaternion rotation=vertical*horizontal;
                    frames.Add(new{position=V(position),velocity=V(velocity),steering=V(steering),deltaTime=dt,
                        lookTarget=target.HasValue?V(target.Value):null,rotation=new[]{rotation.x,rotation.y,rotation.z,rotation.w}});
                }
                traces.Add(new{scale=scale,frames=frames});
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,traces=traces},Formatting.Indented)+"\n");
            Debug.Log("DRONE_ORIENTATION_EXPORT_PASSED frames=540");EditorApplication.Exit(0);
        }
        catch(Exception e){Debug.LogError(e);EditorApplication.Exit(1);}
    }
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
}

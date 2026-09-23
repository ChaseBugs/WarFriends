using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

// Unity math oracle for the normal-time-scale procedural aiming port.
public static class SelfHostedAimExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_AIM_OUTPUT");
        if (string.IsNullOrEmpty(output)) throw new InvalidOperationException("Set WAR_AIM_OUTPUT.");
        var rows=new List<object>();
        foreach (float yaw in new[] { 0f,90f,-135f })
        foreach (var direction in new[] { Vector3.forward,Vector3.back,Vector3.right,Vector3.left,new Vector3(1,.5f,2),new Vector3(-2,-.3f,1) })
        {
            var parent=Quaternion.Euler(0,yaw,0);
            var body=Quaternion.Slerp(Quaternion.identity,Quaternion.LookRotation(direction)*Quaternion.Inverse(parent),10f/30);
            float angle=GeometryTools.AngleSigned(direction,parent*Vector3.forward,Vector3.up);
            float upper=Mathf.Clamp(angle,-70,70)*(12f/30);
            var excess=Quaternion.Slerp(Quaternion.identity,Quaternion.AngleAxis(-(angle-Mathf.Clamp(angle,-70,70)),Vector3.up),10f/30);
            rows.Add(new { direction=V(direction), parent=Q(parent), body=Q(body), upperAngle=upper,
                upperRotation=Q(Quaternion.AngleAxis(upper,Vector3.right)), excessBody=Q(excess) });
        }
        File.WriteAllText(output,JsonConvert.SerializeObject(new { client="1.4.0", unity=Application.unityVersion,
            interval=1f/30, rows=rows },Formatting.Indented));
        Debug.Log("AIM_EXPORT_PASSED rows="+rows.Count);
    }
    private static float[] V(Vector3 v) { return new[] { v.x,v.y,v.z }; }
    private static float[] Q(Quaternion q) { return new[] { q.x,q.y,q.z,q.w }; }
}

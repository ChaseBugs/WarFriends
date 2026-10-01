using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

// Isolated final-pose oracle for recovered TurretWeaponBasic.Aim expressions.
// Uses the actual Helicopter prefab hierarchy; no gameplay callbacks fire.
public static class UnityHelicopterTurretAimExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_HELICOPTER_TURRET_AIM_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set turret aim export output.");
        const string path="Assets/GameObject/Helicopter.prefab";
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if(prefab==null)throw new InvalidOperationException("Recovered Helicopter prefab absent.");
        var inputs=new[]{
            new Input(0,Vector3.zero,Quaternion.identity,new Vector3(-10,0,0)),
            new Input(1,Vector3.zero,Quaternion.identity,new Vector3(-8,2,4)),
            new Input(2,Vector3.zero,Quaternion.identity,new Vector3(2,0,0)),
            new Input(3,new Vector3(3,1,-2),Quaternion.Euler(0,20,15),new Vector3(-7,3,4)),
            new Input(4,Vector3.zero,Quaternion.identity,new Vector3(-5,0,9))
        };
        var rows=new List<object>();
        foreach(var input in inputs)
        {
            var root=UnityEngine.Object.Instantiate(prefab);
            try
            {
                root.transform.position=input.position;
                root.transform.rotation=input.rotation;
                var turret=root.GetComponent<Helicopter>().turret;
                if(turret==null||turret.maxShotRotation!=90f||turret.aimTime!=1f||
                   turret.seeEnemyTransform!=turret.jointVertical)
                    throw new InvalidOperationException("Recovered turret source contract changed.");
                Vector3 vector=input.target-turret.transform.position;
                Vector3 toDirection=vector;
                if(turret.jointVertical==null)toDirection.y=0;
                Quaternion.FromToRotation(turret.turretParent.forward,toDirection)
                    .ToAngleAxis(out float angle,out Vector3 axis);
                bool immediate=Vector3.Angle(turret.jontHorizontal.forward,vector)<2.5f&&
                    Mathf.Abs(angle)<turret.maxShotRotation;
                bool clipped=false;
                float seconds=0;
                if(!immediate)
                {
                    if(angle>turret.maxShotRotation&&angle<360f-turret.maxShotRotation)
                    {
                        angle=angle<180f?turret.maxShotRotation:360f-turret.maxShotRotation;
                        clipped=true;
                    }
                    Quaternion turn=Quaternion.AngleAxis(angle,axis);
                    Quaternion yaw=turn;
                    yaw.eulerAngles=new Vector3(0,turn.eulerAngles.y,0);
                    Quaternion horizontal=turret.jontHorizontal.parent.rotation*yaw;
                    float yawAngle=Quaternion.Angle(turret.jontHorizontal.localRotation,yaw);
                    if(yawAngle>180f)yawAngle=360f-yawAngle;
                    seconds=Mathf.Max(turret.aimTime*Mathf.Abs(yawAngle/360f),.1f);
                    Quaternion vertical=Quaternion.LookRotation(vector,Vector3.up);
                    turret.jontHorizontal.rotation=horizontal;
                    turret.jointVertical.rotation=vertical;
                }
                rows.Add(new{id=input.id,rootPosition=V(input.position),rootRotation=Q(input.rotation),
                    target=V(input.target),immediate,clipped,aimSeconds=seconds,
                    horizontalLocalRotation=Q(turret.jontHorizontal.localRotation),
                    verticalWorldRotation=Q(turret.jointVertical.rotation),
                    sightPosition=V(turret.seeEnemyTransform.position),
                    muzzlePosition=V(turret.batchedWeapon.weapon.spawnPoint.position)});
            }
            finally{UnityEngine.Object.DestroyImmediate(root);}
        }
        string digest=BitConverter.ToString(SHA256.Create().ComputeHash(File.ReadAllBytes(path)))
            .Replace("-","").ToLowerInvariant();
        string json=JsonConvert.SerializeObject(new{version=1,client="1.4.0",
            unityVersion=Application.unityVersion,source=path,prefabSha256=digest,rows},Formatting.Indented)+"\n";
        File.WriteAllBytes(output,System.Text.Encoding.UTF8.GetBytes(json));
        Debug.Log("WAR_HELICOPTER_TURRET_AIM_EXPORT_PASS");
    }
    private sealed class Input
    {
        internal readonly int id;
        internal readonly Vector3 position,target;
        internal readonly Quaternion rotation;
        internal Input(int id,Vector3 position,Quaternion rotation,Vector3 target)
        {this.id=id;this.position=position;this.rotation=rotation;this.target=target;}
    }
    private static float[] V(Vector3 v)=>new[]{v.x,v.y,v.z};
    private static float[] Q(Quaternion q)=>new[]{q.x,q.y,q.z,q.w};
}

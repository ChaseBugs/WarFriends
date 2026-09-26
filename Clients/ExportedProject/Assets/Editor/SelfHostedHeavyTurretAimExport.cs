using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public static class SelfHostedHeavyTurretAimExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_TURRET_AIM_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_TURRET_AIM_OUTPUT.");
        const string source="Assets/GameObject/HeavyTurret.prefab";
        var instance=UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(source));
        try
        {
            instance.transform.position=Vector3.zero;instance.transform.rotation=Quaternion.identity;
            var turret=instance.GetComponent<TurretWeaponBasic>();
            var spawn=turret.batchedWeapon.weapon.spawnPoint;
            var body=instance.GetComponent<GameShootableEntity>().shootTargets[0];
            var offset=((Gun)turret.batchedWeapon.weapon).shotOffset;
            var samples=new[] {new Vector3(0,0,10),new Vector3(10,0,0),new Vector3(-10,0,0),
                new Vector3(0,0,-10),new Vector3(4,3,8),new Vector3(-4,-3,8)}.Select(target=>
            {
                // Same joint endpoints as TurretWeaponBasic.Aim; Unity owns
                // Euler conversion and hierarchy/world transformation here.
                var q=Quaternion.FromToRotation(instance.transform.forward,target);
                q.eulerAngles=new Vector3(0,q.eulerAngles.y,0);
                turret.jontHorizontal.rotation=turret.jontHorizontal.parent.rotation*q;
                turret.jointVertical.rotation=Quaternion.LookRotation(target,Vector3.up);
                return new {target=V(target),sight=V(spawn.position),muzzle=V(spawn.position+offset),body=V(body.position),
                    colliders=instance.GetComponentsInChildren<BoxCollider>(true).Select(c=>new {
                        center=V(c.transform.TransformPoint(c.center)),rotation=Q(c.transform.rotation),size=V(Vector3.Scale(c.size,c.transform.lossyScale))}).ToArray()};
            }).ToArray();
            var tweenSamples=new[] {new Vector3(10,0,0),new Vector3(4,3,8),new Vector3(0,3,8),new Vector3(0,0,-10)}.Select(target=>
            {
                turret.jontHorizontal.localRotation=Quaternion.identity;turret.jointVertical.localRotation=Quaternion.identity;
                var q=Quaternion.FromToRotation(instance.transform.forward,target);
                q.eulerAngles=new Vector3(0,q.eulerAngles.y,0);
                float verticalDuration=Quaternion.Angle(turret.jontHorizontal.localRotation,q)/360f;
                float horizontalDuration=Mathf.Max(verticalDuration,.1f);
                var h=TweenRotation.Begin(turret.jontHorizontal.gameObject,horizontalDuration,
                    turret.jontHorizontal.parent.rotation*q,true);
                var v=TweenRotation.Begin(turret.jointVertical.gameObject,verticalDuration,Quaternion.LookRotation(target,Vector3.up),true);
                var frames=Enumerable.Range(0,Mathf.CeilToInt(horizontalDuration*30)+1).Select(step=>
                {
                    h.Sample(step/30f/horizontalDuration,false);
                    v.Sample(verticalDuration==0?1:step/30f/verticalDuration,false);
                    return new {step=step,sight=V(spawn.position),muzzle=V(spawn.position+offset),body=V(body.position),
                        colliders=instance.GetComponentsInChildren<BoxCollider>(true).Select(c=>new {
                            center=V(c.transform.TransformPoint(c.center)),rotation=Q(c.transform.rotation),size=V(Vector3.Scale(c.size,c.transform.lossyScale))}).ToArray()};
                }).ToArray();
                return new {target=V(target),frames=frames};
            }).ToArray();
            string hash;using(var sha=SHA256.Create())hash=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant();
            File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source=source,sha256=hash,samples=samples,tweenSamples=tweenSamples},Formatting.Indented));
            Debug.Log("HEAVY_TURRET_AIM_EXPORT_PASSED samples="+samples.Length);
        }
        finally {UnityEngine.Object.DestroyImmediate(instance);}
    }
    private static float[] V(Vector3 v)=>new[] {v.x,v.y,v.z};
    private static float[] Q(Quaternion q)=>new[] {q.x,q.y,q.z,q.w};
}

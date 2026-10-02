using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

// Exported only from a disposable Unity copy of the recovered 1.4.0 Client.
// Explosion.MissileExplode selects Collider.ClosestPointOnBounds and then uses
// the selected DestroyableObjectpart Transform for outer-radius falloff.
public static class UnityHelicopterGunnerExplosionExport
{
    private const string PrefabPath="Assets/GameObject/enemy.prefab";
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_GUNNER_EXPLOSION_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException(
            "Set WAR_GUNNER_EXPLOSION_OUTPUT.");
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(PrefabPath);
        if(prefab==null)throw new InvalidOperationException("Recovered enemy prefab is absent.");
        var enemy=(GameObject)PrefabUtility.InstantiatePrefab(prefab);
        try
        {
            enemy.transform.position=Vector3.zero;
            enemy.transform.rotation=Quaternion.identity;
            var animation=enemy.GetComponentInChildren<Animation>(true);
            var idle=animation==null?null:animation.GetClip("idle_1");
            if(idle==null||Mathf.Abs(idle.length-1f)>.00001f)
                throw new InvalidOperationException("Recovered gunner idle clip changed.");
            string guid;long fileId;
            if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(idle,out guid,out fileId)||fileId!=7400000)
                throw new InvalidOperationException("Recovered gunner clip identity changed.");
            var hub=enemy.transform.Find("character_assault_1/global_move/cartoon_guyHub001");
            var head=enemy.transform.Find("character_assault_1/global_move/cartoon_guyHub001/cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003");
            if(hub==null||head==null)throw new InvalidOperationException("Gunner collision bones are absent.");
            Collider[] parts={hub.GetComponent<BoxCollider>(),hub.GetComponent<SphereCollider>(),
                head.GetComponent<SphereCollider>()};
            if(parts.Any(x=>x==null))throw new InvalidOperationException("Gunner collision parts are absent.");
            string[] roles={"body-box","body-sphere","head"};
            var frames=new List<object>(31);
            for(int i=0;i<=30;i++)
            {
                Sample(animation,"T_pose",1f);
                Sample(animation,"idle_1",i/30f);
                Physics.SyncTransforms();
                frames.Add(new{tick=i,seconds=i/30f,parts=parts.Select((part,index)=>new{
                    role=roles[index],path=PathOf(part.transform),
                    transformPosition=V(enemy.transform.InverseTransformPoint(part.transform.position)),
                    boundsMin=V(enemy.transform.InverseTransformPoint(part.bounds.min)),
                    boundsMax=V(enemy.transform.InverseTransformPoint(part.bounds.max))
                }).ToArray()});
            }
            var artifact=new{version=1,client="1.4.0",source=PrefabPath,sha256=Hash(PrefabPath),
                clip=new{source="Assets/AnimationClip/idle_1.anim",guid=guid,fileId=fileId,
                    sha256=Hash("Assets/AnimationClip/idle_1.anim"),length=idle.length},
                sampleRate=30,frames=frames};
            File.WriteAllText(output,JsonConvert.SerializeObject(artifact,Formatting.Indented)+"\n");
            Debug.Log("UNITY_GUNNER_EXPLOSION_EXPORT_PASSED frames="+frames.Count);
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);throw;}
        finally{UnityEngine.Object.DestroyImmediate(enemy);}
    }
    private static void Sample(Animation animation,string name,float time)
    {
        var state=animation[name];
        if(state==null)throw new InvalidOperationException("Missing source animation "+name);
        animation.Stop();state.enabled=true;state.weight=1;state.normalizedTime=time;
        animation.Sample();state.enabled=false;
    }
    private static string Hash(string path)
    {using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
        .Replace("-","").ToLowerInvariant();}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static string PathOf(Transform t)
    {return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
}

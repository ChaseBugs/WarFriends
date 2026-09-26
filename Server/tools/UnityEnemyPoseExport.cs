using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public static class UnityEnemyPoseExport
{
    private const string Source="Assets/GameObject/enemy.prefab";
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_ENEMY_POSE_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_ENEMY_POSE_OUTPUT.");
        var prefab=AssetDatabase.LoadAssetAtPath<GameObject>(Source);
        if(prefab==null)throw new InvalidOperationException("Missing recovered enemy prefab.");
        var enemy=(GameObject)PrefabUtility.InstantiatePrefab(prefab);
        try
        {
            enemy.transform.position=Vector3.zero;enemy.transform.rotation=Quaternion.identity;
            var animation=enemy.GetComponentInChildren<Animation>(true);
            if(animation==null)throw new InvalidOperationException("Enemy prefab has no legacy Animation.");
            var states=animation.Cast<AnimationState>().OrderBy(x=>x.name,StringComparer.Ordinal).ToArray();
            if(states.Length<10)throw new InvalidOperationException("Enemy animation set is truncated.");
            var hub=enemy.transform.Find("character_assault_1/global_move/cartoon_guyHub001");
            var head=enemy.transform.Find("character_assault_1/global_move/cartoon_guyHub001/cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003");
            if(hub==null||head==null)throw new InvalidOperationException("Enemy collision bones are missing.");
            var bodyBox=hub.GetComponent<BoxCollider>();var bodySphere=hub.GetComponent<SphereCollider>();
            var headSphere=head.GetComponent<SphereCollider>();
            if(bodyBox==null||bodySphere==null||headSphere==null)
                throw new InvalidOperationException("Enemy collision primitives differ from recovered source: box="+
                    (bodyBox==null?"missing":bodyBox.isTrigger.ToString())+", bodySphere="+
                    (bodySphere==null?"missing":bodySphere.isTrigger.ToString())+", headSphere="+
                    (headSphere==null?"missing":headSphere.isTrigger.ToString()));
            var definitions=new[]{new Part("body-box",bodyBox,1f),new Part("body-sphere",bodySphere,1f),
                new Part("head",headSphere,1.5f)};
            var clips=new List<object>();
            foreach(var state in states)
            {
                if(state.clip==null||state.length<=0||state.length>60)throw new InvalidOperationException("Invalid enemy clip "+state.name);
                string path=AssetDatabase.GetAssetPath(state.clip),guid;long fileId;
                if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(state.clip,out guid,out fileId))
                    throw new InvalidOperationException("Missing clip identity "+state.name);
                int last=Mathf.CeilToInt(state.length*30);var frames=new List<object>(last+1);
                for(int i=0;i<=last;i++)
                {
                    Sample(animation,"T_pose",1f);
                    float seconds=Mathf.Min(i/30f,state.length);
                    Sample(animation,state.name,seconds/state.length);Physics.SyncTransforms();
                    frames.Add(new{seconds=seconds,parts=definitions.Select(x=>Shape(enemy.transform,x)).ToArray()});
                }
                clips.Add(new{name=state.name,source=path,guid=guid,fileId=fileId,sha256=Hash(path),
                    length=state.length,wrap=state.wrapMode.ToString(),frames=frames});
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=2,client="1.4.0",source=Source,
                sha256=Hash(Source),sampleRate=30,clips=clips},Formatting.Indented));
            Debug.Log("ENEMY_POSE_EXPORT_PASSED clips="+clips.Count);
        }
        finally { UnityEngine.Object.DestroyImmediate(enemy); }
    }
    private sealed class Part
    {
        internal readonly string Role;internal readonly Collider Collider;internal readonly float Weight;
        internal Part(string role,Collider collider,float weight){Role=role;Collider=collider;Weight=weight;}
    }
    private static object Shape(Transform root,Part part)
    {
        var box=part.Collider as BoxCollider;var sphere=part.Collider as SphereCollider;
        var scale=part.Collider.transform.lossyScale;scale=new Vector3(Mathf.Abs(scale.x),Mathf.Abs(scale.y),Mathf.Abs(scale.z));
        Vector3 center=part.Collider.transform.TransformPoint(box!=null?box.center:sphere.center);
        Quaternion inverse=Quaternion.Inverse(root.rotation);
        return new{role=part.Role,path=PathOf(part.Collider.transform),type=part.Collider.GetType().Name,
            weight=part.Weight,trigger=part.Collider.isTrigger,center=V(root.InverseTransformPoint(center)),
            rotation=Q(inverse*part.Collider.transform.rotation),
            size=V(box!=null?Vector3.Scale(box.size,scale):Vector3.zero),
            radius=sphere==null?0:sphere.radius*Mathf.Max(scale.x,Mathf.Max(scale.y,scale.z))};
    }
    private static void Sample(Animation animation,string name,float time)
    {
        var state=animation[name];if(state==null)throw new InvalidOperationException("Missing reset clip "+name);
        animation.Stop();state.enabled=true;state.weight=1;state.normalizedTime=time;animation.Sample();state.enabled=false;
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
}

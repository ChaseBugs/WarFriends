// Read-only Unity 2018 Editor oracle for the two gameplay player hit parts.
// Copy into an isolated project's Assets/Editor and run in batch mode.
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class WarPlayerExplosionOverlapAudit
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_PLAYER_EXPLOSION_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_PLAYER_EXPLOSION_OUTPUT.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source="Assets/Scenes/MainScene.unity";
            var scene=EditorSceneManager.OpenScene(source);
            var player=scene.GetRootGameObjects().SelectMany(root=>root.GetComponentsInChildren<GameController>(true))
                .Single().mainPlayerController;
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
            var animation=animator.GetComponent<Animation>();
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            foreach(var collider in player.ragdollColliders)collider.enabled=false;
            var parts=player.GetComponentsInChildren<DestroyableObjectpart>(true);
            if(parts.Length!=2)throw new InvalidOperationException("Expected two player hit parts.");
            var colliders=parts.Select(part=>part.GetComponent<Collider>()).ToArray();
            foreach(var collider in colliders){collider.enabled=true;collider.gameObject.layer=8;}
            var poses=new[]{"idle","player_fire_left3","run"}.Select(name=>
            {
                var state=animation[name];
                if(state==null)throw new InvalidOperationException("Missing source clip: "+name);
                return new[]{0f,.25f,.5f}.Select(time=>
                {
                    Sample(animation,"T_pose",1);
                    Sample(animation,name,time);
                    Physics.SyncTransforms();
                    var shapes=colliders.Select(collider=>
                    {
                        var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                        if(box==null && sphere==null)throw new InvalidOperationException("Unsupported source hit part.");
                        var scale=collider.transform.lossyScale;
                        scale=new Vector3(Mathf.Abs(scale.x),Mathf.Abs(scale.y),Mathf.Abs(scale.z));
                        return new {
                            kind=box!=null?"Box":"Sphere",
                            center=Vec(collider.transform.TransformPoint(box!=null?box.center:sphere.center)),
                            transformPosition=Vec(collider.transform.position),
                            size=Vec(box!=null?Vector3.Scale(box.size,scale):Vector3.zero),
                            rotation=Quat(collider.transform.rotation),
                            radius=sphere==null?0:sphere.radius*Mathf.Max(scale.x,Mathf.Max(scale.y,scale.z))
                        };
                    }).ToArray();
                    var offsets=new[]{Vector3.zero,Vector3.right*.75f,Vector3.up*1.25f,
                        Vector3.forward*1.75f,Vector3.right*2.25f};
                    var probes=colliders.SelectMany(collider=>
                    {
                        var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                        var center=collider.transform.TransformPoint(box!=null?box.center:sphere.center);
                        return offsets.SelectMany(offset=>new[]{1.1f,1.8f}.Select(radius=>
                        {
                            var position=center+offset;
                            var order=Physics.OverlapSphere(position,radius,1<<8)
                                .Select(hit=>Array.IndexOf(colliders,hit)).Where(index=>index>=0)
                                .Distinct().ToArray();
                            return new {center=Vec(position),radius,hits=order.OrderBy(index=>index).ToArray(),order};
                        }));
                    }).ToArray();
                    return new {name,time,shapes,probes};
                });
            }).SelectMany(rows=>rows).ToArray();
            string digest;
            using(var sha=SHA256.Create())digest=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source)))
                .Replace("-","").ToLowerInvariant();
            File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source,sha256=digest,poses},
                Formatting.Indented));
            Debug.Log("PLAYER_EXPLOSION_OVERLAP_AUDIT_PASSED poses="+poses.Length);
        }
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static void Sample(Animation animation,string name,float time)
    {
        animation.Stop();var state=animation[name];state.enabled=true;state.weight=1;
        state.normalizedTime=time;animation.Sample();state.enabled=false;
    }
    private static float[] Vec(Vector3 v)=>new[]{v.x,v.y,v.z};
    private static float[] Quat(Quaternion q)=>new[]{q.x,q.y,q.z,q.w};
}

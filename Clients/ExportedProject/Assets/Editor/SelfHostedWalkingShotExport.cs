using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor.SceneManagement;
using UnityEngine;

// Actual legacy Animation layer-4 mixing oracle for moving rifle fire.
public static class SelfHostedWalkingShotExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_WALKING_SHOT_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_WALKING_SHOT_OUTPUT.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            const string source="Assets/Scenes/MainScene.unity";
            var scene=EditorSceneManager.OpenScene(source);
            var player=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
            var animation=animator.GetComponent<Animation>();
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            var additive=animation["shootAdditive"];
            additive.layer=4;additive.blendMode=AnimationBlendMode.Blend;additive.wrapMode=WrapMode.ClampForever;
            additive.AddMixingTransform(animator.upperBody);
            var parts=player.GetComponentsInChildren<DestroyableObjectpart>(true).Select(p=>p.GetComponent<Collider>()).ToArray();
            var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
            var rifles=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<RifleLevelsSetup>(true)).
                Select(s=>new {Id=s.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().Namespace=="Google2u").GetType().FullName,
                    Muzzle=inventory.allWeapons[s.indexInWeaponInventory].GetComponent<Weapon>().spawnPoint}).
                Where(x=>x.Id.StartsWith("Google2u.AssaultRifle_",StringComparison.Ordinal)).ToArray();
            var cases=new List<object>();
            foreach(string run in new[] {"run","qbz_run","qbz2_run","shotgunner_run"})
            foreach(float weight in new[] {0f,.25f,.5f,.75f,1f})
            {
                animation.Stop();
                var reset=animation["T_pose"];reset.enabled=true;reset.weight=1;reset.time=reset.length;animation.Sample();reset.enabled=false;
                var baseState=animation[run];baseState.enabled=true;baseState.weight=1;baseState.time=.2f;
                additive.enabled=true;additive.weight=weight;additive.time=.1f;
                animation.Sample();
                cases.Add(new {run,runSeconds=.2f,additiveSeconds=.1f,weight,
                    parts=parts.Select(c=>new {path=PathOf(c.transform),center=V(c.transform.TransformPoint(c is BoxCollider?((BoxCollider)c).center:((SphereCollider)c).center)),rotation=Q(c.transform.rotation)}).ToArray(),
                    muzzles=rifles.Select(r=>new {id=r.Id,path=PathOf(r.Muzzle),position=V(r.Muzzle.position),rotation=Q(r.Muzzle.rotation)}).ToArray()});
                additive.enabled=false;baseState.enabled=false;
            }
            string hash;using(var sha=SHA256.Create())hash=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant();
            File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",source,sha256=hash,
                additiveSource="Assets/AnimationClip/shootAdditive.anim",cases},Formatting.Indented));
            Debug.Log("WALKING_SHOT_EXPORT_PASSED cases="+cases.Count);
        }
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}

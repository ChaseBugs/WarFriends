using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Read-only source oracle for the grenade-specific animation families. Kept
// separate from the rifle rig artifact so adding the left-hand throw point does
// not rewrite previously pinned rifle pose evidence.
public static class SelfHostedGrenadePoseExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_GRENADE_POSE_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_GRENADE_POSE_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity";var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var scene=EditorSceneManager.OpenScene(source);var roots=scene.GetRootGameObjects();
            var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
            var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);var animation=animator.GetComponent<Animation>();
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            var parts=player.GetComponentsInChildren<DestroyableObjectpart>(true);
            foreach(var c in player.ragdollColliders)c.enabled=false;
            foreach(var part in parts)part.GetComponent<Collider>().enabled=true;
            var targets=new SortedDictionary<string,Transform>(StringComparer.Ordinal);
            Transform left=null;
            foreach(var setup in levels.GetComponentsInChildren<GrenadeLevelsSetup>(true))
            {
                string id=setup.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().Namespace=="Google2u").GetType().FullName;
                if(id!="Google2u.GrenadeLauncher_M320"&&!id.StartsWith("Google2u.Grenade_",StringComparison.Ordinal))continue;
                var controller=inventory.allWeapons[setup.indexInWeaponInventory];var weapon=controller.GetComponent<Weapon>();
                targets.Add(id,weapon.spawnPoint);
                var swipe=controller as PlayerSwipeWeapon;
                if(swipe!=null)
                {
                    if(left==null)left=swipe.spawnPointLeft;
                    else if(left!=swipe.spawnPointLeft)throw new InvalidOperationException("Swipe grenades do not share the recovered left spawn.");
                    if(swipe.spawnPointRight!=weapon.spawnPoint)throw new InvalidOperationException("Swipe right spawn differs from weapon spawn.");
                }
            }
            if(targets.Count!=8||left==null)throw new InvalidOperationException("Incomplete grenade pose targets.");
            string[] names={"throw_grenade_left","throw_grenade_right","grenade_run","grenade_idle",
                "player_look_left_grenadelauncher","player_fire_left_grenadelauncher","player_left_coverBack_grenadelauncher",
                "player_look_right_grenadelauncher","player_fire_right_grenadelauncher","player_right_coverBack_grenadelauncher",
                "run_grenadelauncher","grenadelauncher_idle"};
            var clips=new List<object>();
            foreach(string name in names)
            {
                var state=animation[name];if(state==null||state.length<=0||state.length>60)throw new InvalidOperationException("Missing grenade clip "+name);
                string path=AssetDatabase.GetAssetPath(state.clip),guid;long fileId;
                if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(state.clip,out guid,out fileId))throw new InvalidOperationException("Missing grenade clip identity "+name);
                var frames=new List<object>();int last=Mathf.CeilToInt(state.length*30);
                for(int i=0;i<=last;i++)
                {
                    Sample(animation,"T_pose",1);float seconds=Mathf.Min(i/30f,state.length);Sample(animation,name,seconds/state.length);Physics.SyncTransforms();
                    var shapes=parts.Select(part=>
                    {
                        var collider=part.GetComponent<Collider>();var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                        if(box==null&&sphere==null)throw new InvalidOperationException("Unsupported grenade pose part.");
                        var scale=collider.transform.lossyScale;scale=new Vector3(Mathf.Abs(scale.x),Mathf.Abs(scale.y),Mathf.Abs(scale.z));
                        return new{path=PathOf(part.transform),type=collider.GetType().Name,weight=part.weight,enabled=collider.enabled,
                            active=collider.gameObject.activeInHierarchy,center=V(collider.transform.TransformPoint(box!=null?box.center:sphere.center)),
                            rotation=Q(collider.transform.rotation),size=V(box!=null?Vector3.Scale(box.size,scale):Vector3.zero),
                            radius=sphere==null?0:sphere.radius*Mathf.Max(scale.x,Mathf.Max(scale.y,scale.z))};
                    }).ToArray();
                    frames.Add(new{seconds=seconds,parts=shapes,left=new{path=PathOf(left),position=V(left.position),rotation=Q(left.rotation)},
                        right=targets.Select(t=>new{id=t.Key,path=PathOf(t.Value),position=V(t.Value.position),rotation=Q(t.Value.rotation)}).ToArray()});
                }
                clips.Add(new{name=name,source=path,guid=guid,fileId=fileId,sha256=Hash(path),length=state.length,wrap=state.wrapMode.ToString(),frames=frames});
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{client="1.4.0",source=source,sha256=Hash(source),sampleRate=30,
                playerPath=PathOf(player.transform),position=V(player.transform.position),rotation=Q(player.transform.rotation),
                leftSpawnPath=PathOf(left),clips=clips},Formatting.Indented));
            Debug.Log("GRENADE_POSE_EXPORT_PASSED clips="+clips.Count);EditorApplication.Exit(0);
        }
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static void Sample(Animation animation,string name,float normalized){animation.Stop();var state=animation[name];state.enabled=true;state.weight=1;state.normalizedTime=normalized;animation.Sample();state.enabled=false;}
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}

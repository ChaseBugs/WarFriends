using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Read-only export in a disposable copy of the recovered 1.4.0 Unity Client.
// It samples the five serialized gameplay targets alongside grenade poses.
public static class UnityGrenadeShotTargetExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_GRENADE_TARGET_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_GRENADE_TARGET_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity";
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var scene=EditorSceneManager.OpenScene(source);
            var player=scene.GetRootGameObjects()
                .SelectMany(g=>g.GetComponentsInChildren<GameController>(true))
                .Single().mainPlayerController;
            var shootable=player.GetComponent<GameShootableEntityPlayer>();
            if(shootable==null||shootable.targets==null||shootable.targets.Count!=5)
                throw new InvalidOperationException("Incomplete serialized player target array.");
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);
            var animation=animator.GetComponent<Animation>();
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            string[] names={"throw_grenade_left","throw_grenade_right","grenade_run","grenade_idle",
                "player_look_left_grenadelauncher","player_fire_left_grenadelauncher",
                "player_left_coverBack_grenadelauncher","player_look_right_grenadelauncher",
                "player_fire_right_grenadelauncher","player_right_coverBack_grenadelauncher",
                "run_grenadelauncher","grenadelauncher_idle"};
            var identity=shootable.targets.Select((t,i)=>new{
                index=i,type=(int)t.type,path=PathOf(t.transform)
            }).ToArray();
            var clips=new List<object>();
            foreach(string name in names)
            {
                var state=animation[name];
                if(state==null||state.length<=0||state.length>60)
                    throw new InvalidOperationException("Missing grenade clip "+name);
                string path=AssetDatabase.GetAssetPath(state.clip),guid;long fileId;
                if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(state.clip,out guid,out fileId))
                    throw new InvalidOperationException("Missing clip identity "+name);
                var frames=new List<object>();
                int last=Mathf.CeilToInt(state.length*30);
                for(int i=0;i<=last;i++)
                {
                    Sample(animation,"T_pose",1);
                    float seconds=Mathf.Min(i/30f,state.length);
                    Sample(animation,name,seconds/state.length);
                    frames.Add(new{seconds=seconds,positions=shootable.targets
                        .Select(t=>V(t.transform.position)).ToArray()});
                }
                clips.Add(new{name=name,source=path,guid=guid,fileId=fileId,
                    sha256=Hash(path),length=state.length,frames=frames});
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,client="1.4.0",
                source=source,sha256=Hash(source),sampleRate=30,
                playerPath=PathOf(player.transform),position=V(player.transform.position),
                rotation=Q(player.transform.rotation),targets=identity,clips=clips},Formatting.Indented)+"\n");
            Debug.Log("UNITY_GRENADE_SHOT_TARGET_EXPORT_PASSED clips="+clips.Count);
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);throw;}
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static void Sample(Animation animation,string name,float time)
    {animation.Stop();var state=animation[name];state.enabled=true;state.weight=1;state.normalizedTime=time;
        animation.Sample();state.enabled=false;}
    private static string Hash(string path)
    {using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
        .Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t)
    {return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] Q(Quaternion q){return new[]{q.x,q.y,q.z,q.w};}
}

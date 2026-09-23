using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Google.Protobuf;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedGrenadeRenderAudit
{
    public static void Run()
    {
        string path=Environment.GetEnvironmentVariable("WAR_GRENADE_RENDER_FIXTURE");
        if(string.IsNullOrEmpty(path))throw new InvalidOperationException("Set WAR_GRENADE_RENDER_FIXTURE.");
        var fixture=JObject.Parse(File.ReadAllText(path));const string source="Assets/Scenes/MainScene.unity";
        using(var sha=SHA256.Create())if(BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant()!=(string)fixture["sceneHash"])
            throw new InvalidOperationException("Grenade renderer fixture scene mismatch.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var scene=EditorSceneManager.OpenScene(source);var player=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            var animator=player.GetComponentInChildren<SoldierAnimationController>(true);var renderer=new SelfHostedRiflePoseRenderer(player.transform,animator);
            var parts=player.GetComponentsInChildren<DestroyableObjectpart>(true);var transforms=player.GetComponentsInChildren<Transform>(true)
                .GroupBy(PathOf,StringComparer.Ordinal).ToDictionary(g=>g.Key,g=>g.First(),StringComparer.Ordinal);int checks=0;
            foreach(var item in fixture["cases"])
            {
                var state=JsonParser.Default.Parse<BattlePlayerState>((string)item["player"]);renderer.Apply(state);
                Transform muzzle;if(!transforms.TryGetValue((string)item["muzzlePath"],out muzzle))throw new InvalidOperationException("Missing grenade muzzle path.");
                for(int i=0;i<parts.Length;i++)
                {
                    var collider=parts[i].GetComponent<Collider>();var box=collider as BoxCollider;var sphere=collider as SphereCollider;
                    Near(collider.transform.TransformPoint(box!=null?box.center:sphere.center),V(item["parts"][i]),"part "+i+" tick "+state.RiflePose.SampledTick);checks++;
                }
                Near(muzzle.position,V(item["muzzle"]),"muzzle tick "+state.RiflePose.SampledTick);checks++;
            }
            var inventory=player.ResolveSelfHostedInventory();var grenadeWeapon=inventory.allWeapons.First(x=>x.weapon is Grenade);
            inventory.usedWeapons=new List<PlayerWeapon>{grenadeWeapon};
            player.playerProperties.playerID=new string('a',32);
            var presentationRoot=new GameObject("SelfHostedProjectileAudit");
            var presenter=presentationRoot.AddComponent<SelfHostedProjectilePresenter>();presenter.Configure(player,player);
            var projectileSnapshot=new MatchSnapshot();projectileSnapshot.Projectiles.Add(new BattleProjectileState
            {ProjectileId=77,OwnerPlayerId=player.playerProperties.playerID,Kind="grenade",X=1,Y=2,Z=3,VelocityX=1,VelocityY=1,VelocityZ=0});
            presenter.Apply(projectileSnapshot);var projectile=GameObject.Find("SelfHostedProjectile_77");
            if(projectile==null||projectile.GetComponentsInChildren<MeshFilter>(true).All(x=>x.sharedMesh==null)||
               Vector3.Distance(projectile.transform.position,new Vector3(1,2,3))>.0001f)
                throw new InvalidOperationException("Authoritative grenade snapshot did not create its recovered projectile mesh.");
            checks++;UnityEngine.Object.DestroyImmediate(presentationRoot);
            if(checks<850)throw new InvalidOperationException("Incomplete grenade render fixture.");
            Debug.Log("GRENADE_RENDER_AUDIT_PASSED checks="+checks);EditorApplication.Exit(0);
        }
        finally
        {
            if(previous.Any(s=>s.isActive&&s.isLoaded)&&previous.All(s=>!string.IsNullOrEmpty(s.path)))EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }
    private static string PathOf(Transform t){return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static Vector3 V(JToken a){return new Vector3((float)a[0],(float)a[1],(float)a[2]);}
    private static void Near(Vector3 a,Vector3 b,string label){if(Vector3.Distance(a,b)>.0003f)throw new InvalidOperationException(label+": actual="+a.ToString("F6")+" expected="+b.ToString("F6"));}
}

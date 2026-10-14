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
            var behaviourManager=scene.GetRootGameObjects()
                .SelectMany(root=>root.GetComponentsInChildren<LevelBehaviourManager>(true))
                .Single();
            var presenter=presentationRoot.AddComponent<SelfHostedProjectilePresenter>();
            presenter.Configure(player,player,behaviourManager);
            var projectileSnapshot=new MatchSnapshot();projectileSnapshot.Projectiles.Add(new BattleProjectileState
            {ProjectileId=77,OwnerPlayerId=player.playerProperties.playerID,Kind="grenade",X=1,Y=2,Z=3,VelocityX=1,VelocityY=1,VelocityZ=0});
            presenter.Apply(projectileSnapshot);var projectile=GameObject.Find("SelfHostedProjectile_77");
            if(projectile==null||projectile.GetComponentsInChildren<MeshFilter>(true).All(x=>x.sharedMesh==null)||
               Vector3.Distance(projectile.transform.position,new Vector3(1,2,3))>.0001f)
                throw new InvalidOperationException("Authoritative grenade snapshot did not create its recovered projectile mesh.");
            checks++;
            presenter.Apply(new MatchSnapshot{ProjectilesTruncated=true});
            if(GameObject.Find("SelfHostedProjectile_77")==null)
                throw new InvalidOperationException("Truncated projectile snapshot retired a still-flying grenade visual.");
            checks++;
            var fullScan=new MatchProjectileBatch{Code="projectiles",ScanId=1,SnapshotTick=10,ActiveCount=1};
            fullScan.Projectiles.Add(new BattleProjectileState
            {ProjectileId=77,OwnerPlayerId=player.playerProperties.playerID,Kind="grenade",X=2,Y=3,Z=4});
            presenter.ApplyScan(fullScan);
            projectile=GameObject.Find("SelfHostedProjectile_77");
            if(projectile==null||Vector3.Distance(projectile.transform.position,new Vector3(2,3,4))>.0001f)
                throw new InvalidOperationException("Paged projectile scan did not restore complete visual position.");
            checks++;
            presenter.ApplyScan(new MatchProjectileBatch{Code="projectiles",ScanId=2,SnapshotTick=11});
            if(GameObject.Find("SelfHostedProjectile_77")!=null)
                throw new InvalidOperationException("Complete projectile scan retained an absent grenade visual.");
            checks++;
            var cardSnapshot=new MatchSnapshot();
            cardSnapshot.Projectiles.Add(new BattleProjectileState
            {ProjectileId=78,OwnerPlayerId=player.playerProperties.playerID,
                Kind="card-grenadier",X=3,Y=4,Z=5,
                VelocityX=1,VelocityY=2,VelocityZ=3});
            presenter.Apply(cardSnapshot);
            var cardVisual=GameObject.Find("SelfHostedProjectile_78");
            if(cardVisual==null||
                cardVisual.GetComponentsInChildren<MeshFilter>(true)
                    .All(mesh=>mesh.sharedMesh==null)||
                Vector3.Distance(cardVisual.transform.position,
                    new Vector3(3,4,5))>.0001f)
                throw new InvalidOperationException("Grenadier snapshot lacks its recovered grenade mesh.");
            checks++;
            presenter.ApplyEvent(new MatchEvent
            {Kind=MatchEventKind.Impact,Reason="card-grenadier",
                ProjectileId=78,X=3,Y=4,Z=5});
            if(GameObject.Find("SelfHostedProjectile_78")!=null)
                throw new InvalidOperationException("Grenadier impact retained its projectile visual.");
            checks++;

            // The Manager grenade belongs to the scene, not the player's
            // equipped weapon. Only its meshes may enter the presentation copy.
            var manager=scene.GetRootGameObjects()
                .SelectMany(root=>root.GetComponentsInChildren<KillStreakManager>(true))
                .Single();
            var managerGrenade=manager.GetComponent<Grenade>();
            if(managerGrenade==null||managerGrenade.bulletPrefab==null)
                throw new InvalidOperationException("Recovered Manager grenade prefab is absent.");
            var sourceMeshes=managerGrenade.bulletPrefab
                .GetComponentsInChildren<MeshFilter>(true)
                .Select(mesh=>mesh.sharedMesh).ToArray();
            var clusterSnapshot=new MatchSnapshot();
            clusterSnapshot.Projectiles.Add(new BattleProjectileState
            {ProjectileId=79,OwnerPlayerId=player.playerProperties.playerID,
                Kind="pvp-bonus-grenade",X=4,Y=5,Z=6,
                VelocityX=1,VelocityY=2,VelocityZ=3});
            presenter.Apply(clusterSnapshot);
            var clusterVisual=GameObject.Find("SelfHostedProjectile_79");
            if(clusterVisual==null||sourceMeshes.Length==0||
                !clusterVisual.GetComponentsInChildren<MeshFilter>(true)
                    .Select(mesh=>mesh.sharedMesh).SequenceEqual(sourceMeshes)||
                clusterVisual.GetComponentsInChildren<Collider>(true).Length!=0||
                clusterVisual.GetComponentsInChildren<Rigidbody>(true).Length!=0||
                clusterVisual.GetComponentsInChildren<GrenadeAmmoBase>(true).Length!=0||
                clusterVisual.GetComponentsInChildren<PhotonView>(true).Length!=0)
                throw new InvalidOperationException("Cluster Grenade visual kept gameplay authority or lost its source mesh.");
            checks++;
            clusterSnapshot.Projectiles[0].X=7;
            presenter.Apply(clusterSnapshot);
            if(Vector3.Distance(clusterVisual.transform.position,new Vector3(7,5,6))>.0001f)
                throw new InvalidOperationException("Cluster Grenade visual ignored the next host position.");
            checks++;
            presenter.ApplyEvent(new MatchEvent
            {Kind=MatchEventKind.Impact,Reason="pvp-bonus-grenade",
                ProjectileId=79,X=7,Y=5,Z=6});
            if(GameObject.Find("SelfHostedProjectile_79")!=null)
                throw new InvalidOperationException("Cluster Grenade impact retained its projectile visual.");
            checks++;
            UnityEngine.Object.DestroyImmediate(presentationRoot);
            if(checks<876)throw new InvalidOperationException("Incomplete grenade render fixture.");
            Debug.Log("GRENADE_RENDER_AUDIT_PASSED checks="+checks);EditorApplication.Exit(0);
        }
        catch(Exception exception)
        {
            Debug.LogError(exception);
            EditorApplication.Exit(1);
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

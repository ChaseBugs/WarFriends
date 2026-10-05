using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedShotgunProjectileRenderAudit
{
    public static void Run()
    {
        var previous=EditorSceneManager.GetSceneManagerSetup();
        GameObject host=null;
        try
        {
            var scene=EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var player=scene.GetRootGameObjects().SelectMany(x=>x.GetComponentsInChildren<GameController>(true))
                .Single().mainPlayerController;
            var inventory=player.ResolveSelfHostedInventory();
            var shotgun=inventory.allWeapons.First(x=>x!=null&&x.weapon!=null&&
                x.weapon.bulletPrefab is BulletShotGun).weapon;
            var main=(BulletShotGun)shotgun.bulletPrefab;
            if(main.bulletPrefab==null||!(shotgun.ammoSetup is ShotGunBulletSetup))
                throw new InvalidOperationException("Recovered shotgun pellet setup missing.");
            player.playerProperties.playerID=new string('a',32);
            host=new GameObject("SelfHostedShotgunProjectileRenderAudit");
            var presenter=host.AddComponent<SelfHostedProjectilePresenter>();
            presenter.Configure(player,player);
            var snapshot=new MatchSnapshot();
            snapshot.Projectiles.Add(new BattleProjectileState{ProjectileId=71,
                OwnerPlayerId=player.playerProperties.playerID,Kind="shotgun-bullet",
                X=1,Y=2,Z=3,VelocityZ=30});
            snapshot.Projectiles.Add(new BattleProjectileState{ProjectileId=72,
                OwnerPlayerId=player.playerProperties.playerID,Kind="shotgun-fake-bullet",
                X=2,Y=3,Z=4,VelocityZ=30});
            presenter.Apply(snapshot);
            foreach(var id in new ulong[]{71,72})
            {
                var visual=GameObject.Find("SelfHostedProjectile_"+id);
                Require(visual!=null,"missing pellet visual "+id);
                Require(visual.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh)
                    .SequenceEqual(main.bulletPrefab.GetComponentsInChildren<MeshFilter>(true)
                        .Select(x=>x.sharedMesh)),"source pellet mesh "+id);
                Require(visual.GetComponentsInChildren<Collider>(true).Length==0&&
                    visual.GetComponentsInChildren<Rigidbody>(true).Length==0&&
                    visual.GetComponentsInChildren<BulletBase>(true).Length==0,
                    "pellet visual has no damage or collision authority "+id);
                Require(visual.GetComponent<LineTrailRenderer>()!=null,
                    "source shotgun trail missing "+id);
            }
            presenter.Apply(new MatchSnapshot{ProjectilesTruncated=true});
            Require(GameObject.Find("SelfHostedProjectile_71")!=null&&
                GameObject.Find("SelfHostedProjectile_72")!=null,
                "truncated snapshot removed live pellets");
            presenter.Apply(new MatchSnapshot());
            Require(GameObject.Find("SelfHostedProjectile_71")==null&&
                GameObject.Find("SelfHostedProjectile_72")==null,
                "complete snapshot retained expired pellets");
            Debug.Log("UNITY_SHOTGUN_PROJECTILE_RENDER_PASSED real=True fake=True mesh=True trail=True removal=True");
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);}
        finally
        {
            if(host!=null)UnityEngine.Object.DestroyImmediate(host);
            if(previous.Any(x=>x.isActive&&x.isLoaded)&&previous.All(x=>!string.IsNullOrEmpty(x.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }

    private static void Require(bool ok,string message)
    {if(!ok)throw new InvalidOperationException("Shotgun projectile render audit: "+message);}
}

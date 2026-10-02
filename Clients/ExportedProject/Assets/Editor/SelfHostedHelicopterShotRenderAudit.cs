using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedHelicopterShotRenderAudit
{
    public static void Run()
    {
        var previous=EditorSceneManager.GetSceneManagerSetup();
        GameObject owner=null;
        try
        {
            var scene=EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var pool=scene.GetRootGameObjects().SelectMany(x=>x.GetComponentsInChildren<ObjectPoolDatabase>(true)).Single();
            var helicopter=pool.helicopter;
            Require(helicopter!=null&&helicopter.turret!=null&&
                helicopter.turret.batchedWeapon!=null&&
                helicopter.turret.batchedWeapon.weapon!=null,"source Helicopter weapon");
            var weapon=helicopter.turret.batchedWeapon.weapon;
            var bullet=weapon.bulletPrefab.gameObject;
            Require(weapon.ammoSetup is BulletSetup,"source BulletSetup");
            owner=new GameObject("SelfHostedHelicopterShotRenderAudit");
            var presenter=owner.AddComponent<SelfHostedProjectilePresenter>();
            var snapshot=new MatchSnapshot();snapshot.Projectiles.Add(new BattleProjectileState
            {ProjectileId=101,OwnerPlayerId="11111111111111111111111111111111",
                Kind="helicopter-fake-bullet",X=1,Y=2,Z=3});
            presenter.Apply(snapshot);
            var visual=GameObject.Find("SelfHostedProjectile_101");
            Require(visual!=null,"fake snapshot creates visual");
            Require(visual.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh)
                .SequenceEqual(bullet.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh)),
                "recovered bullet mesh identity");
            Require(visual.GetComponentsInChildren<Collider>(true).Length==0&&
                visual.GetComponentsInChildren<Rigidbody>(true).Length==0&&
                visual.GetComponentsInChildren<MonoBehaviour>(true).Length==0,
                "visual contains no collision or gameplay scripts");
            Require(Vector3.Distance(visual.transform.position,new Vector3(1,2,3))<.0001f,
                "host fake projectile snapshot position");
            presenter.Apply(new MatchSnapshot());
            Require(GameObject.Find("SelfHostedProjectile_101")==null,
                "visual removed after snapshot absence");
            Debug.Log("UNITY_HELICOPTER_SHOT_RENDER_PASSED mesh=True snapshot=True removal=True");
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);}
        finally
        {
            if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);
            if(previous.Any(x=>x.isActive&&x.isLoaded)&&previous.All(x=>!string.IsNullOrEmpty(x.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }

    private static void Require(bool condition,string message)
    {
        if(!condition)throw new InvalidOperationException("Helicopter shot render audit: "+message);
    }
}

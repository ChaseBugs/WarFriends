using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

// Runs in a disposable Unity project. Edit Mode does not initialize the
// recovered LineTrailRenderer, so this audit enters Play Mode first.
[InitializeOnLoad]
public static class SelfHostedHelicopterShotPlayAudit
{
    private const string Active="WarFriends.HelicopterShotPlayAudit";
    private static GameObject owner;
    private static Vector3 start;
    private static Vector3 realStart;
    private static int observedFrames;
    private static double deadline;

    static SelfHostedHelicopterShotPlayAudit()
    {
        if(SessionState.GetBool(Active,false))
        {deadline=EditorApplication.timeSinceStartup+45;EditorApplication.update+=Update;}
    }

    public static void Run()
    {
        var sourceScene=EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        var sourceModels=sourceScene.GetRootGameObjects()
            .SelectMany(x=>x.GetComponentsInChildren<BulletModels>(true)).Single();
        var meshes=new List<BulletModels.BulletMesh>(sourceModels.bulletmeshes);
        var helicopterPrefab=AssetDatabase.LoadAssetAtPath<GameObject>(
            "Assets/GameObject/Helicopter.prefab");
        if(helicopterPrefab==null||helicopterPrefab.GetComponent<Helicopter>()==null)
            throw new InvalidOperationException("Recovered Helicopter prefab is unavailable.");
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        var camera=new GameObject("AuditCamera");camera.tag="MainCamera";
        camera.AddComponent<Camera>();
        var pool=new GameObject("AuditPool").AddComponent<ObjectPoolDatabase>();
        pool.helicopter=helicopterPrefab.GetComponent<Helicopter>();
        var models=new GameObject("AuditBulletModels").AddComponent<BulletModels>();
        models.bulletmeshes=meshes;
        deadline=EditorApplication.timeSinceStartup+45;
        SessionState.SetBool(Active,true);
        EditorApplication.isPlaying=true;
    }

    private static void Update()
    {
        if(!SessionState.GetBool(Active,false))return;
        if(EditorApplication.timeSinceStartup>deadline&&deadline>0)
        {Fail(new TimeoutException("Helicopter shot Play Mode audit timed out."));return;}
        if(!EditorApplication.isPlaying||EditorApplication.isPaused)return;
        try
        {
            if(owner==null)
            {
                var pool=Singleton<ObjectPoolDatabase>.instance;
                var helicopter=pool==null?null:pool.helicopter;
                if(helicopter==null||Camera.main==null||Singleton<BulletModels>.instance==null)
                    throw new InvalidOperationException("Recovered pool, Helicopter, camera or bullet models are absent in Play Mode.");
                owner=new GameObject("HelicopterShotPlayAudit");
                var presenter=owner.AddComponent<SelfHostedProjectilePresenter>();
                presenter.ApplyEvent(new MatchEvent
                {
                    Kind=MatchEventKind.HelicopterFired,
                    ActorId="11111111111111111111111111111111",ProjectileId=901,
                    X=0,Y=0,Z=10,
                    HelicopterShot=new HelicopterShotPresentation
                    {ArmyEntityKey=81,MuzzleX=0,MuzzleY=0,MuzzleZ=0,Speed=18,Fake=true}
                });
                var visual=GameObject.Find("SelfHostedProjectile_901");
                var trail=visual==null?null:visual.GetComponent<LineTrailRenderer>();
                var setup=helicopter.turret.batchedWeapon.weapon.ammoSetup as BulletSetup;
                if(visual==null||trail==null||setup==null||
                   Mathf.Abs(trail.trailLength-setup.GetTrailSize())>.0001f||
                   Mathf.Abs(trail.disapearTime-setup.GetTrailSize()/18f)>.0001f||
                   visual.GetComponent<MeshFilter>().sharedMesh!=
                       Singleton<BulletModels>.instance.GetMesh(setup.fakeShotTexture)||
                   visual.GetComponentsInChildren<Collider>(true).Length!=0)
                    throw new InvalidOperationException("Helicopter fake shot lacks its source trail or script-free visual.");
                start=visual.transform.position;
                presenter.ApplyEvent(new MatchEvent
                {
                    Kind=MatchEventKind.HelicopterFired,
                    ActorId="11111111111111111111111111111111",ProjectileId=902,
                    X=0,Y=0,Z=10,
                    HelicopterShot=new HelicopterShotPresentation
                    {ArmyEntityKey=81,MuzzleX=0,MuzzleY=0,MuzzleZ=0,Speed=12,Shield=true}
                });
                var real=GameObject.Find("SelfHostedProjectile_902");
                var realTrail=real==null?null:real.GetComponent<LineTrailRenderer>();
                if(real==null||realTrail==null||
                   Mathf.Abs(realTrail.trailLength-setup.GetTrailSize()*2f)>.0001f||
                   Mathf.Abs(realTrail.disapearTime-setup.GetTrailSize()/12f)>.0001f||
                   real.GetComponent<MeshFilter>().sharedMesh!=
                       Singleton<BulletModels>.instance.GetMesh(setup.shieldShotTexture)||
                   real.GetComponentsInChildren<Collider>(true).Length!=0)
                    throw new InvalidOperationException("Helicopter real shield shot lacks its source trail or script-free visual.");
                realStart=real.transform.position;
                return;
            }
            observedFrames++;
            var flight=GameObject.Find("SelfHostedProjectile_901");
            var realFlight=GameObject.Find("SelfHostedProjectile_902");
            if((flight==null||realFlight==null)&&observedFrames<2)
                throw new InvalidOperationException("Helicopter shot disappeared before visual flight.");
            if(flight!=null&&realFlight!=null&&
               Vector3.Distance(flight.transform.position,start)>0.1f&&
               Vector3.Distance(realFlight.transform.position,realStart)>0.1f)
            {
                Success("UNITY_HELICOPTER_SHOT_PLAY_PASSED frames="+observedFrames+
                    " fakeDistance="+Vector3.Distance(flight.transform.position,start)+
                    " realDistance="+Vector3.Distance(realFlight.transform.position,realStart));
            }
            else if(observedFrames>120)
                throw new InvalidOperationException("Helicopter shot trail never advanced in Play Mode.");
        }
        catch(Exception error){Fail(error);}
    }

    private static void Success(string message)
    {
        SessionState.SetBool(Active,false);EditorApplication.update-=Update;
        Debug.Log(message);EditorApplication.Exit(0);
    }
    private static void Fail(Exception error)
    {
        SessionState.SetBool(Active,false);EditorApplication.update-=Update;
        Debug.LogException(error);EditorApplication.Exit(1);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedHelicopterRenderAudit
{
    public static void Run()
    {
        var previous=EditorSceneManager.GetSceneManagerSetup();
        GameObject owner=null,reference=null;
        try
        {
            var scene=EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var pool=scene.GetRootGameObjects().SelectMany(x=>x.GetComponentsInChildren<ObjectPoolDatabase>(true)).Single();
            var manager=scene.GetRootGameObjects().SelectMany(x=>x.GetComponentsInChildren<LevelBehaviourManager>(true)).Single();
            var prefab=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/Helicopter.prefab");
            var source=prefab==null?null:prefab.GetComponent<Helicopter>();
            Require(source!=null&&source.turret!=null&&source.turret.batchedWeapon!=null,
                "recovered Helicopter prefab");
            owner=new GameObject("SelfHostedHelicopterRenderAudit");
            var presenter=owner.AddComponent<SelfHostedHelicopterPresenter>();
            presenter.Configure(source,pool.enemy,manager.levelBehaviours[0].behaviour as SoldierBehaviour);
            var body=Quaternion.Euler(8,35,-6);
            var yaw=Quaternion.Euler(0,23,0);
            var vertical=Quaternion.Euler(-12,80,0);
            var row=new BattleArmyEntityState{EntityKey=4294967297,UnitId="ID_UNIT-HELICOPTER",
                X=2,Y=3,Z=4,HelicopterRotation=Q(body),
                SpawnTick=60,PositionTick=75,
                HelicopterTurretHorizontalLocal=Q(yaw),
                HelicopterTurretVerticalWorld=Q(vertical)};
            presenter.Apply(new List<BattleArmyEntityState>{row});
            var visual=GameObject.Find("SelfHostedHelicopter_4294967297");
            Require(visual!=null&&Vector3.Distance(visual.transform.position,new Vector3(2,3,4))<.0001f&&
                Quaternion.Angle(visual.transform.rotation,body)<.001f,"authoritative flight pose");
            var expected=prefab.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh);
            var actual=visual.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh);
            Require(actual.SequenceEqual(expected),"recovered mesh identities");
            Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length==0&&
                visual.GetComponentsInChildren<Collider>(true).Length==0&&
                visual.GetComponentsInChildren<Rigidbody>(true).Length==0,
                "visual contains no gameplay or collision components");
            reference=UnityEngine.Object.Instantiate(prefab);
            reference.transform.position=visual.transform.position;
            reference.transform.rotation=body;
            var turret=reference.GetComponent<Helicopter>().turret;
            turret.jontHorizontal.localRotation=yaw;
            turret.jointVertical.rotation=vertical;
            int rotorChecks=0;
            foreach(var tween in reference.GetComponentsInChildren<TweenRotationSpecial>(true))
            {
                if(tween.gameObject.name!="propeller_front"&&
                    tween.gameObject.name!="propeller_front (1)"&&
                    tween.gameObject.name!="propeller_tail")continue;
                float factor=(.5f/tween.duration)%1f;
                tween.Sample(factor,false);
                var visualRotor=visual.GetComponentsInChildren<Transform>(true)
                    .Single(x=>x.name==tween.gameObject.name);
                Require(Quaternion.Angle(visualRotor.localRotation,tween.transform.localRotation)<.001f,
                    "source rotor tween at host sample time: "+tween.gameObject.name);
                rotorChecks++;
            }
            Require(rotorChecks==3,"three recovered rotor tweens");
            var sourceMuzzle=turret.batchedWeapon.weapon.spawnPoint;
            var visualMuzzle=visual.GetComponentsInChildren<Transform>(true)
                .Single(x=>x.name==sourceMuzzle.name);
            Require(Vector3.Distance(sourceMuzzle.position,visualMuzzle.position)<.0002f,
                "recovered turret joints place the visual muzzle");
            row.HelicopterGunnerMaxHealth=621;
            row.HelicopterGunnerHealth=621;
            row.HelicopterGunnerSpawnTick=60;
            presenter.Apply(new List<BattleArmyEntityState>{row});
            var gunner=visual.GetComponentsInChildren<Transform>(true).Single(x=>x.name=="SelfHostedGunner");
            var bodySkin=gunner.GetComponentInChildren<SkinnedMeshRenderer>(true);
            Require(bodySkin!=null&&bodySkin.sharedMesh!=null&&bodySkin.sharedMesh.name=="camo_assault"&&
                bodySkin.bones.Length==20&&bodySkin.bones.All(x=>x!=null),"recovered gunner skin and skeleton");
            Require(gunner.GetComponentsInChildren<MeshFilter>(true).Count(x=>x.sharedMesh!=null&&
                x.sharedMesh.name=="assault_helm")>=1,"recovered gunner helmet");
            Require(gunner.GetComponentsInChildren<MonoBehaviour>(true).Length==0&&
                gunner.GetComponentsInChildren<Collider>(true).Length==0&&
                gunner.GetComponentsInChildren<Rigidbody>(true).Length==0,
                "gunner visual has no gameplay or collision components");
            row.HelicopterGunnerHealth=0;
            row.HelicopterGunnerRespawnTick=100;
            presenter.Apply(new List<BattleArmyEntityState>{row});
            Require(!gunner.gameObject.activeSelf,"host gunner death hides visual");
            row.PositionTick=100;
            row.HelicopterGunnerSpawnTick=100;
            row.HelicopterGunnerRespawnTick=0;
            row.HelicopterGunnerHealth=621;
            presenter.Apply(new List<BattleArmyEntityState>{row});
            Require(gunner.gameObject.activeSelf,"host gunner respawn restores visual");
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedHelicopter_4294967297")==null,
                "roster absence removes the visual");
            Debug.Log("UNITY_HELICOPTER_RENDER_PASSED meshes="+
                prefab.GetComponentsInChildren<MeshFilter>(true).Length+
                " turret=True rotors="+rotorChecks+" gunner=True removal=True");
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);}
        finally
        {
            if(reference!=null)UnityEngine.Object.DestroyImmediate(reference);
            if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);
            if(previous.Any(x=>x.isActive&&x.isLoaded)&&previous.All(x=>!string.IsNullOrEmpty(x.path)))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        }
    }

    private static BattleJointRotation Q(Quaternion q)
        =>new BattleJointRotation{X=q.x,Y=q.y,Z=q.z,W=q.w};
    private static void Require(bool condition,string message)
    {
        if(!condition)throw new InvalidOperationException("Helicopter render audit: "+message);
    }
}

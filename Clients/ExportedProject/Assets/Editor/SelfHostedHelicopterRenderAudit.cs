using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedHelicopterRenderAudit
{
    public static void Run()
    {
        GameObject owner=null,reference=null;
        try
        {
            var prefab=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/Helicopter.prefab");
            var source=prefab==null?null:prefab.GetComponent<Helicopter>();
            Require(source!=null&&source.turret!=null&&source.turret.batchedWeapon!=null,
                "recovered Helicopter prefab");
            owner=new GameObject("SelfHostedHelicopterRenderAudit");
            var presenter=owner.AddComponent<SelfHostedHelicopterPresenter>();
            presenter.Configure(source);
            var body=Quaternion.Euler(8,35,-6);
            var yaw=Quaternion.Euler(0,23,0);
            var vertical=Quaternion.Euler(-12,80,0);
            var row=new BattleArmyEntityState{EntityKey=4294967297,UnitId="ID_UNIT-HELICOPTER",
                X=2,Y=3,Z=4,HelicopterRotation=Q(body),
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
            var sourceMuzzle=turret.batchedWeapon.weapon.spawnPoint;
            var visualMuzzle=visual.GetComponentsInChildren<Transform>(true)
                .Single(x=>x.name==sourceMuzzle.name);
            Require(Vector3.Distance(sourceMuzzle.position,visualMuzzle.position)<.0002f,
                "recovered turret joints place the visual muzzle");
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedHelicopter_4294967297")==null,
                "roster absence removes the visual");
            Debug.Log("UNITY_HELICOPTER_RENDER_PASSED meshes="+
                prefab.GetComponentsInChildren<MeshFilter>(true).Length+" turret=True removal=True");
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);}
        finally
        {
            if(reference!=null)UnityEngine.Object.DestroyImmediate(reference);
            if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static BattleJointRotation Q(Quaternion q)
        =>new BattleJointRotation{X=q.x,Y=q.y,Z=q.z,W=q.w};
    private static void Require(bool condition,string message)
    {
        if(!condition)throw new InvalidOperationException("Helicopter render audit: "+message);
    }
}

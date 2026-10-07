using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedDroneRenderAudit
{
    public static void Run()
    {
        GameObject owner=null;
        try
        {
            var prefab=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/dronePrototype.prefab");
            var source=prefab.GetComponent<Drone>();
            owner=new GameObject("DroneRenderAudit");
            var presenter=owner.AddComponent<SelfHostedDronePresenter>();presenter.Configure(source);
            var expectedRotation=Quaternion.Euler(12,35,-7);
            var row=new BattleArmyEntityState{EntityKey=4294967297,UnitId="ID_UNIT-DRONE",X=2,Y=3,Z=4,
                SpawnTick=60,PositionTick=60,
                DroneRotation=new BattleJointRotation{X=expectedRotation.x,Y=expectedRotation.y,Z=expectedRotation.z,W=expectedRotation.w}};
            var rows=new List<BattleArmyEntityState>{row};presenter.Apply(rows);
            var visual=GameObject.Find("SelfHostedDrone_4294967297");
            Require(visual!=null&&visual.transform.position==new Vector3(2,3,4),"position");
            Require(Quaternion.Angle(visual.transform.rotation,expectedRotation)<.001f,"authoritative bank/heading rotation");
            Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length==0&&
                visual.GetComponentsInChildren<Collider>(true).Length==0,"no gameplay components");
            Require(visual.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh).SequenceEqual(
                prefab.GetComponentsInChildren<MeshFilter>(true).Select(x=>x.sharedMesh)),"mesh identities");
            var normal=visual.GetComponentsInChildren<Transform>(true).Single(x=>x.name==source.normalDrone.name);
            var elite=visual.GetComponentsInChildren<Transform>(true).Single(x=>x.name==source.eliteDrone.name);
            Require(normal.gameObject.activeSelf&&!elite.gameObject.activeSelf,"normal deployment variant");
            var materialNames=new HashSet<string>(source.visuals.renderedParts.Select(x=>x.name));
            materialNames.Add(source.visuals.mainRenderer.name);
            var targets=visual.GetComponentsInChildren<MeshRenderer>(true).Where(x=>materialNames.Contains(x.name)).ToArray();
            Require(targets.Length==materialNames.Count,"material scope");
            row.DroneTransparent=true;presenter.Apply(rows);
            Require(targets.All(x=>x.sharedMaterial==source.transparentMaterial),"transparent material");
            row.DroneTransparent=false;presenter.Apply(rows);
            Require(targets.All(x=>x.sharedMaterial==source.visuals.mainRenderer.sharedMaterial),"normal restoration");
            var nextRotation=Quaternion.Euler(12,75,-7);
            row.PositionTick=66;
            row.X=6;
            row.DroneRotation=new BattleJointRotation{X=nextRotation.x,Y=nextRotation.y,
                Z=nextRotation.z,W=nextRotation.w};
            row.DroneTransparent=true;
            presenter.Apply(rows);
            Require(Mathf.Abs(visual.transform.position.x-2)<.0001f&&
                targets.All(x=>x.sharedMaterial==source.transparentMaterial),
                "new pose waits while host transparency applies immediately");
            presenter.RenderAt(Time.realtimeSinceStartup+.12f,.016f);
            Require(Mathf.Abs(visual.transform.position.x-3.6f)<.1f&&
                Quaternion.Angle(visual.transform.rotation,expectedRotation)>1f&&
                Quaternion.Angle(visual.transform.rotation,nextRotation)>1f,
                "host-tick Drone position and rotation interpolate");
            presenter.RenderAt(Time.realtimeSinceStartup+1.4f,.016f);
            Require(Vector3.Distance(visual.transform.position,new Vector3(6,3,4))<.01f&&
                Quaternion.Angle(visual.transform.rotation,nextRotation)<.1f,
                "remote Drone visual settles on the host pose");
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedDrone_4294967297")==null,"roster removal");
            Debug.Log("UNITY_DRONE_RENDER_PASSED interpolation=True materialTargets="+targets.Length);
            EditorApplication.Exit(0);
        }
        catch(Exception e){Debug.LogError(e);EditorApplication.Exit(1);}
        finally{if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);}
    }
    private static void Require(bool value,string name){if(!value)throw new InvalidOperationException("Drone render audit failed: "+name);}
}

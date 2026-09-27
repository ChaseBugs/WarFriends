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
            var row=new BattleArmyEntityState{EntityKey=4294967297,UnitId="ID_UNIT-DRONE",X=2,Y=3,Z=4};
            var rows=new List<BattleArmyEntityState>{row};presenter.Apply(rows);
            var visual=GameObject.Find("SelfHostedDrone_4294967297");
            Require(visual!=null&&visual.transform.position==new Vector3(2,3,4),"position");
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
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedDrone_4294967297")==null,"roster removal");
            Debug.Log("UNITY_DRONE_RENDER_PASSED materialTargets="+targets.Length);
            EditorApplication.Exit(0);
        }
        catch(Exception e){Debug.LogError(e);EditorApplication.Exit(1);}
        finally{if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);}
    }
    private static void Require(bool value,string name){if(!value)throw new InvalidOperationException("Drone render audit failed: "+name);}
}

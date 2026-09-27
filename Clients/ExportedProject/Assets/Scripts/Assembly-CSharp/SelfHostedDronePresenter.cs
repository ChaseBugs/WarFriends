using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Normal deployed Drone visuals only. No local AI, collision, Photon or special timer.
public sealed class SelfHostedDronePresenter : MonoBehaviour
{
    private sealed class Visual { public GameObject Root; public List<MeshRenderer> MaterialTargets; }
    private readonly Dictionary<ulong,Visual> active=new Dictionary<ulong,Visual>();
    private Drone source;
    public void Configure(Drone prefab) { source=prefab; }
    public void Apply(IReadOnlyList<BattleArmyEntityState> rows)
    {
        if(rows==null)throw new ArgumentNullException("rows");
        var present=new HashSet<ulong>();
        foreach(var row in rows)
        {
            if(row.UnitId!="ID_UNIT-DRONE")continue;
            present.Add(row.EntityKey);Visual visual;
            if(!active.TryGetValue(row.EntityKey,out visual))
            {visual=Create(row.EntityKey);active.Add(row.EntityKey,visual);}
            visual.Root.transform.position=new Vector3(row.X,row.Y,row.Z);
            Material material=row.DroneTransparent?source.transparentMaterial:source.visuals.mainRenderer.sharedMaterial;
            foreach(var renderer in visual.MaterialTargets)renderer.sharedMaterial=material;
        }
        var stale=new List<ulong>();
        foreach(var pair in active)if(!present.Contains(pair.Key))stale.Add(pair.Key);
        foreach(var id in stale){DestroyVisual(active[id].Root);active.Remove(id);}
    }
    private Visual Create(ulong id)
    {
        if(source==null||source.visuals==null||source.visuals.mainRenderer==null||source.transparentMaterial==null)
            throw new InvalidOperationException("Recovered Drone visual/material bindings are absent.");
        var root=new GameObject("SelfHostedDrone_"+id);
        var map=new Dictionary<Transform,Transform>();
        Copy(source.transform,root.transform,true,map);
        map[source.normalDrone.transform].gameObject.SetActive(true);
        map[source.eliteDrone.transform].gameObject.SetActive(false);
        var targets=new List<MeshRenderer>();
        targets.Add(map[source.visuals.mainRenderer.transform].GetComponent<MeshRenderer>());
        foreach(var renderer in source.visuals.renderedParts)
            targets.Add(map[renderer.transform].GetComponent<MeshRenderer>());
        return new Visual{Root=root,MaterialTargets=targets};
    }
    private static void Copy(Transform from,Transform to,bool root,Dictionary<Transform,Transform> map)
    {
        map.Add(from,to);
        to.localScale=from.localScale;
        if(!root){to.localPosition=from.localPosition;to.localRotation=from.localRotation;to.gameObject.SetActive(from.gameObject.activeSelf);}
        var filter=from.GetComponent<MeshFilter>();var renderer=from.GetComponent<MeshRenderer>();
        if(filter!=null&&renderer!=null)
        {
            to.gameObject.AddComponent<MeshFilter>().sharedMesh=filter.sharedMesh;
            var copy=to.gameObject.AddComponent<MeshRenderer>();copy.sharedMaterials=renderer.sharedMaterials;
            copy.enabled=renderer.enabled;copy.shadowCastingMode=renderer.shadowCastingMode;copy.receiveShadows=renderer.receiveShadows;
        }
        for(int i=0;i<from.childCount;i++)
        {var child=from.GetChild(i);var obj=new GameObject(child.name);obj.transform.SetParent(to,false);Copy(child,obj.transform,false,map);}
    }
    private void OnDestroy(){foreach(var visual in active.Values)DestroyVisual(visual.Root);active.Clear();}
    private static void DestroyVisual(GameObject value)
    {if(Application.isPlaying)UnityEngine.Object.Destroy(value);else UnityEngine.Object.DestroyImmediate(value);}
}

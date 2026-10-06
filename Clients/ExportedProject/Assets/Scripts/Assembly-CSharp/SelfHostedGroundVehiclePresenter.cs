using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Recovered vehicle meshes only. The Worker owns movement, weapons, crew,
// collision and health; copied objects have no gameplay scripts or colliders.
public sealed class SelfHostedGroundVehiclePresenter : MonoBehaviour
{
    private readonly Dictionary<ulong,GameObject> active=new Dictionary<ulong,GameObject>();
    private readonly Dictionary<string,Transform> prefabs=new Dictionary<string,Transform>();

    public void Configure(ObjectPoolDatabase pool)
    {
        Configure(pool == null || pool.humvee == null ? null : pool.humvee.transform,
            pool == null || pool.tank == null ? null : pool.tank.transform,
            pool == null || pool.buggy == null ? null : pool.buggy.transform,
            pool == null || pool.transporter == null ? null : pool.transporter.transform);
    }

    public void Configure(Transform humvee,Transform tank,Transform buggy,Transform transporter)
    {
        prefabs.Clear();
        if(humvee!=null)prefabs.Add("ID_UNIT-HUMVEE",humvee);
        if(tank!=null)prefabs.Add("ID_UNIT-TANK",tank);
        if(buggy!=null)prefabs.Add("ID_UNIT-BUGGY",buggy);
        if(transporter!=null)prefabs.Add("ID_UNIT-TRANSPORTER",transporter);
    }

    public void Apply(MatchSnapshot snapshot)
    {
        if(snapshot==null)throw new ArgumentNullException("snapshot");
        var present=new HashSet<ulong>();
        foreach(BattleVehicleState vehicle in snapshot.Vehicles)
        {
            Transform prefab;
            if(!prefabs.TryGetValue(vehicle.UnitId,out prefab))
                throw new InvalidOperationException("Recovered ground-vehicle visual is absent: "+vehicle.UnitId);
            Vector3 facing=new Vector3(vehicle.FacingX,vehicle.FacingY,vehicle.FacingZ);
            if(Mathf.Abs(facing.sqrMagnitude-1f)>.001f||Mathf.Abs(facing.y)>.001f)
                throw new InvalidOperationException("Authoritative vehicle facing is invalid.");

            present.Add(vehicle.EntityId);
            GameObject visual;
            if(!active.TryGetValue(vehicle.EntityId,out visual))
            {
                visual=Create(prefab,vehicle.EntityId);
                active.Add(vehicle.EntityId,visual);
            }
            visual.transform.position=new Vector3(vehicle.X,vehicle.Y,vehicle.Z);
            visual.transform.rotation=Quaternion.LookRotation(facing,Vector3.up);
        }

        var removed=new List<ulong>();
        foreach(var pair in active)if(!present.Contains(pair.Key))removed.Add(pair.Key);
        foreach(ulong id in removed)
        {
            DestroyVisual(active[id]);
            active.Remove(id);
        }
    }

    private static GameObject Create(Transform prefab,ulong entityId)
    {
        var root=new GameObject("SelfHostedVehicle_"+entityId);
        CopyGeometry(prefab,root.transform,true);
        return root;
    }

    private static void CopyGeometry(Transform source,Transform target,bool root)
    {
        target.localScale=source.localScale;
        if(!root)
        {
            target.localPosition=source.localPosition;
            target.localRotation=source.localRotation;
            target.gameObject.SetActive(source.gameObject.activeSelf);
        }

        MeshFilter filter=source.GetComponent<MeshFilter>();
        MeshRenderer renderer=source.GetComponent<MeshRenderer>();
        if(filter!=null&&renderer!=null)
        {
            target.gameObject.AddComponent<MeshFilter>().sharedMesh=filter.sharedMesh;
            MeshRenderer copy=target.gameObject.AddComponent<MeshRenderer>();
            copy.sharedMaterials=renderer.sharedMaterials;
            copy.enabled=renderer.enabled;
            copy.shadowCastingMode=renderer.shadowCastingMode;
            copy.receiveShadows=renderer.receiveShadows;
        }

        for(int index=0;index<source.childCount;index++)
        {
            Transform child=source.GetChild(index);
            var childCopy=new GameObject(child.name);
            childCopy.transform.SetParent(target,false);
            CopyGeometry(child,childCopy.transform,false);
        }
    }

    private void OnDestroy()
    {
        foreach(GameObject visual in active.Values)DestroyVisual(visual);
        active.Clear();
    }

    private static void DestroyVisual(GameObject visual)
    {
        if(Application.isPlaying)UnityEngine.Object.Destroy(visual);
        else UnityEngine.Object.DestroyImmediate(visual);
    }
}

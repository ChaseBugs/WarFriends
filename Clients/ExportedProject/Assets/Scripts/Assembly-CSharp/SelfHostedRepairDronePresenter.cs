using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Displays the recovered MiniDrone mesh at the pose supplied by the battle host.
// Its old Photon, steering, damage and collision components are never copied.
public sealed class SelfHostedRepairDronePresenter : MonoBehaviour
{
    private readonly Dictionary<string, GameObject> active = new Dictionary<string, GameObject>();
    private Transform prefab;

    public void Configure(ObjectPoolDatabase pool)
    {
        Configure(pool == null || pool.miniDrone == null ? null : pool.miniDrone.transform);
    }

    public void Configure(Transform miniDrone)
    {
        prefab = miniDrone;
    }

    public void Apply(MatchSnapshot snapshot)
    {
        if (snapshot == null) throw new ArgumentNullException("snapshot");
        var present = new HashSet<string>();
        foreach (BattleVehicleState vehicle in snapshot.Vehicles)
        {
            foreach (BattleRepairDroneState drone in vehicle.RepairDrones)
            {
                string id = vehicle.EntityId + "_" + drone.PathIndex;
                if ((!drone.Active && !drone.Falling) || drone.Crashed) continue;
                if (prefab == null)
                    throw new InvalidOperationException("Recovered MiniDrone visual is absent.");
                Quaternion rotation = new Quaternion(drone.RotationX, drone.RotationY,
                    drone.RotationZ, drone.RotationW);
                if (Mathf.Abs(1f - (rotation.x * rotation.x + rotation.y * rotation.y +
                    rotation.z * rotation.z + rotation.w * rotation.w)) > .001f)
                    throw new InvalidOperationException("Authoritative repair-drone rotation is invalid.");
                if (!present.Add(id))
                    throw new InvalidOperationException("Duplicate repair-drone identity: " + id);

                GameObject visual;
                if (!active.TryGetValue(id, out visual))
                {
                    visual = Create(prefab, id);
                    active.Add(id, visual);
                }
                visual.transform.position = new Vector3(drone.X, drone.Y, drone.Z);
                visual.transform.rotation = rotation;
            }
        }

        var removed = new List<string>();
        foreach (var pair in active)
            if (!present.Contains(pair.Key)) removed.Add(pair.Key);
        foreach (string id in removed)
        {
            DestroyVisual(active[id]);
            active.Remove(id);
        }
    }

    private static GameObject Create(Transform source, string id)
    {
        var visual = new GameObject("SelfHostedRepairDrone_" + id);
        CopyGeometry(source, visual.transform, true);
        return visual;
    }

    private static void CopyGeometry(Transform source, Transform target, bool isRoot)
    {
        target.localScale = source.localScale;
        if (!isRoot)
        {
            target.localPosition = source.localPosition;
            target.localRotation = source.localRotation;
            target.gameObject.SetActive(source.gameObject.activeSelf);
        }

        MeshFilter filter = source.GetComponent<MeshFilter>();
        MeshRenderer renderer = source.GetComponent<MeshRenderer>();
        if (filter != null && renderer != null)
        {
            target.gameObject.AddComponent<MeshFilter>().sharedMesh = filter.sharedMesh;
            MeshRenderer copy = target.gameObject.AddComponent<MeshRenderer>();
            copy.sharedMaterials = renderer.sharedMaterials;
            copy.enabled = renderer.enabled;
            copy.shadowCastingMode = renderer.shadowCastingMode;
            copy.receiveShadows = renderer.receiveShadows;
        }

        for (int index = 0; index < source.childCount; index++)
        {
            Transform child = source.GetChild(index);
            var childCopy = new GameObject(child.name);
            childCopy.transform.SetParent(target, false);
            CopyGeometry(child, childCopy.transform, false);
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject visual in active.Values) DestroyVisual(visual);
        active.Clear();
    }

    private static void DestroyVisual(GameObject visual)
    {
        if (Application.isPlaying) UnityEngine.Object.Destroy(visual);
        else UnityEngine.Object.DestroyImmediate(visual);
    }
}

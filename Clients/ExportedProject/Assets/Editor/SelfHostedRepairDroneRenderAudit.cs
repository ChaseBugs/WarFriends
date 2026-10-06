using System;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedRepairDroneRenderAudit
{
    public static void Run()
    {
        GameObject owner = null;
        try
        {
            GameObject source = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/miniDrone.prefab");
            Require(source != null, "recovered prefab");
            owner = new GameObject("RepairDroneRenderAudit");
            var presenter = owner.AddComponent<SelfHostedRepairDronePresenter>();
            presenter.Configure(source.transform);

            var snapshot = new MatchSnapshot();
            var vehicle = new BattleVehicleState { EntityId = 52, UnitId = "ID_UNIT-TRANSPORTER" };
            var drone = new BattleRepairDroneState
            {
                PathIndex = 1, X = 3, Y = 4, Z = 5,
                RotationY = .7071068f, RotationW = .7071068f,
                Active = true, Health = 10, MaxHealth = 10
            };
            vehicle.RepairDrones.Add(drone);
            snapshot.Vehicles.Add(vehicle);
            presenter.Apply(snapshot);
            GameObject visual = GameObject.Find("SelfHostedRepairDrone_52_1");
            Require(visual != null, "active visual");
            Require(visual.transform.position == new Vector3(3, 4, 5), "host position");
            Require(Vector3.Dot(visual.transform.forward, Vector3.right) > .999f, "host rotation");
            MeshRenderer[] originalMeshes = source.GetComponentsInChildren<MeshRenderer>(true);
            MeshRenderer[] copiedMeshes = visual.GetComponentsInChildren<MeshRenderer>(true);
            Require(originalMeshes.Length > 0 && originalMeshes.Length == copiedMeshes.Length, "mesh count");
            for (int index = 0; index < originalMeshes.Length; index++)
                Require(originalMeshes[index].GetComponent<MeshFilter>().sharedMesh ==
                    copiedMeshes[index].GetComponent<MeshFilter>().sharedMesh, "mesh identity " + index);
            Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                visual.GetComponentsInChildren<Collider>(true).Length == 0, "visual-only copy");

            drone.Active = false;
            drone.Falling = true;
            presenter.Apply(snapshot);
            Require(GameObject.Find("SelfHostedRepairDrone_52_1") != null, "falling visible");
            drone.Crashed = true;
            presenter.Apply(snapshot);
            Require(GameObject.Find("SelfHostedRepairDrone_52_1") == null, "crashed removed");
            drone.Crashed = false;
            drone.Falling = false;
            drone.Active = true;
            presenter.Apply(snapshot);
            Require(GameObject.Find("SelfHostedRepairDrone_52_1") != null, "respawn visible");
            presenter.Apply(new MatchSnapshot());
            Require(GameObject.Find("SelfHostedRepairDrone_52_1") == null, "absent removed");

            Debug.Log("UNITY_REPAIR_DRONE_RENDER_PASSED meshIdentity=True pose=True lifecycle=True scriptFree=True");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogError(exception);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (owner != null) UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void Require(bool condition, string name)
    {
        if (!condition) throw new InvalidOperationException("Repair-drone render audit failed: " + name);
    }
}

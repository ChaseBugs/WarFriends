using System;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedLandMineRenderAudit
{
	public static void Run()
	{
		GameObject owner = null;
		try
		{
			GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/MineAmmo.prefab");
			MineAmmo source = prefab == null ? null : prefab.GetComponent<MineAmmo>();
			Require(source != null && source.mineModel != null, "recovered MineAmmo prefab");
			owner = new GameObject("SelfHostedLandMineRenderAudit");
			var presenter = owner.AddComponent<SelfHostedLandMinePresenter>();
			presenter.Configure(source);
			var snapshot = new MatchSnapshot();
			snapshot.LandMines.Add(new BattleLandMineState
			{
				EntityId = 71, RequestId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
				OwnerPlayerId = "11111111111111111111111111111111", OwnerFraction = 1,
				HidingComponentFileId = 3408, X = 2, Y = 3, Z = 4, Damage = 25
			});
			presenter.Apply(snapshot);
			GameObject visual = GameObject.Find("SelfHostedLandMine_71");
			Require(visual != null && visual.transform.position == new Vector3(2, 3, 4), "authoritative position");
			MeshFilter copied = visual.GetComponentInChildren<MeshFilter>();
			MeshFilter original = source.mineModel.GetComponent<MeshFilter>();
			Require(copied != null && copied.sharedMesh == original.sharedMesh, "recovered mesh identity");
			Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
				visual.GetComponentsInChildren<Collider>(true).Length == 0 &&
				visual.GetComponentsInChildren<Rigidbody>(true).Length == 0, "script-free visual");
			presenter.ApplyEvent(new MatchEvent { Kind = MatchEventKind.LandMineTriggered, ProjectileId = 71 });
			Require(GameObject.Find("SelfHostedLandMine_71") == null, "trigger event removal");
			snapshot.LandMines[0].EntityId = 72;
			presenter.Apply(snapshot);
			Require(GameObject.Find("SelfHostedLandMine_72") != null, "snapshot creation");
			presenter.Apply(new MatchSnapshot());
			Require(GameObject.Find("SelfHostedLandMine_72") == null, "snapshot reconciliation");
			Debug.Log("UNITY_LAND_MINE_RENDER_PASSED mesh=True scriptFree=True eventRemoval=True snapshotRemoval=True");
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

	private static void Require(bool value, string name)
	{
		if (!value) throw new InvalidOperationException("Land Mine render audit failed: " + name);
	}
}

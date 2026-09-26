using System;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedDecoyRenderAudit
{
	public static void Run()
	{
		GameObject owner = null;
		Texture2D blue = null;
		Texture2D red = null;
		try
		{
			GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/Decoy.prefab");
			Decoy source = prefab == null ? null : prefab.GetComponent<Decoy>();
			Require(source != null && source.bodyRenderer != null, "recovered Decoy prefab");
			owner = new GameObject("SelfHostedDecoyRenderAudit");
			var presenter = owner.AddComponent<SelfHostedDecoyPresenter>();
			string local = "11111111111111111111111111111111";
			blue = new Texture2D(1, 1); red = new Texture2D(1, 1);
			CardDecoy.mBlueTexture = blue; CardDecoy.mRedTexture = red;
			presenter.Configure(local, source);
			var snapshot = new MatchSnapshot();
			snapshot.Decoys.Add(new BattleDecoyState
			{
				EntityId = 41, RequestId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
				OwnerPlayerId = local, OwnerFraction = 1, ObstacleComponentFileId = 7,
				X = 2, Y = 3, Z = 4, FacingX = 1, FacingY = 0, FacingZ = 0,
				Health = 10, MaxHealth = 10
			});
			presenter.Apply(snapshot);
			GameObject visual = GameObject.Find("SelfHostedDecoy_41");
			Require(visual != null && visual.transform.position == new Vector3(2, 3, 4), "authoritative position");
			Require(Vector3.Dot(visual.transform.forward, Vector3.right) > 0.999f, "authoritative facing");
			MeshFilter copied = visual.GetComponentInChildren<MeshFilter>();
			MeshFilter original = source.bodyRenderer.GetComponent<MeshFilter>();
			Require(copied != null && copied.sharedMesh == original.sharedMesh, "recovered mesh identity");
			Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
				visual.GetComponentsInChildren<Collider>(true).Length == 0, "script-free visual");
			Require(visual.GetComponentInChildren<Renderer>().sharedMaterial.mainTexture == blue, "local texture");
			presenter.ApplyEvent(new MatchEvent { Kind = MatchEventKind.DecoyDestroyed, ProjectileId = 41 });
			Require(GameObject.Find("SelfHostedDecoy_41") == null, "destroy event removal");
			snapshot.Decoys.Clear();
			snapshot.Decoys.Add(new BattleDecoyState
			{
				EntityId = 42, RequestId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb",
				OwnerPlayerId = "22222222222222222222222222222222", OwnerFraction = 2,
				ObstacleComponentFileId = 8, FacingZ = 1, Health = 10, MaxHealth = 10
			});
			presenter.Apply(snapshot);
			Require(GameObject.Find("SelfHostedDecoy_42").GetComponentInChildren<Renderer>().sharedMaterial.mainTexture == red,
				"opponent texture");
			presenter.Apply(new MatchSnapshot());
			Require(GameObject.Find("SelfHostedDecoy_42") == null, "snapshot reconciliation");
			Debug.Log("UNITY_DECOY_RENDER_PASSED mesh=True scriptFree=True eventRemoval=True snapshotRemoval=True");
			EditorApplication.Exit(0);
		}
		catch (Exception exception)
		{
			Debug.LogError(exception);
			EditorApplication.Exit(1);
		}
		finally
		{
			CardDecoy.mBlueTexture = null; CardDecoy.mRedTexture = null;
			if (owner != null) UnityEngine.Object.DestroyImmediate(owner);
			if (blue != null) UnityEngine.Object.DestroyImmediate(blue);
			if (red != null) UnityEngine.Object.DestroyImmediate(red);
		}
	}

	private static void Require(bool value, string name)
	{
		if (!value) throw new InvalidOperationException("Decoy render audit failed: " + name);
	}
}

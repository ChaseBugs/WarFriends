using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Presentation only. The Worker owns placement, trigger collision, damage and removal.
// The visual copies the recovered MineAmmo mesh without Photon, physics or gameplay scripts.
public sealed class SelfHostedLandMinePresenter : MonoBehaviour
{
	private readonly Dictionary<ulong, GameObject> active = new Dictionary<ulong, GameObject>();
	private MineAmmo visualSource;

	public void Configure(MineAmmo source)
	{
		visualSource = source;
	}

	public void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null) return;
		HashSet<ulong> present = new HashSet<ulong>();
		foreach (BattleLandMineState state in snapshot.LandMines)
		{
			present.Add(state.EntityId);
			GameObject visual;
			if (!active.TryGetValue(state.EntityId, out visual))
			{
				visual = Create(state);
				active.Add(state.EntityId, visual);
			}
			visual.transform.position = new Vector3(state.X, state.Y, state.Z);
		}
		List<ulong> stale = new List<ulong>();
		foreach (KeyValuePair<ulong, GameObject> pair in active)
			if (!present.Contains(pair.Key)) stale.Add(pair.Key);
		foreach (ulong id in stale) Remove(id);
	}

	public void ApplyEvent(MatchEvent item)
	{
		if (item != null && item.Kind == MatchEventKind.LandMineTriggered)
		{
			if (Application.isPlaying)
				Explosion.PlayEffects(Explosion.ExplosionType.Big, new Vector3(item.X, item.Y, item.Z));
			Remove(item.ProjectileId);
		}
	}

	private GameObject Create(BattleLandMineState state)
	{
		if (visualSource == null || visualSource.mineModel == null)
			throw new System.InvalidOperationException("The recovered Land Mine visual is unavailable.");
		MeshFilter sourceFilter = visualSource.mineModel.GetComponent<MeshFilter>();
		if (sourceFilter == null) throw new System.InvalidOperationException("The recovered Land Mine mesh is unavailable.");
		GameObject root = new GameObject("SelfHostedLandMine_" + state.EntityId);
		GameObject body = new GameObject(visualSource.mineModel.gameObject.name);
		body.transform.SetParent(root.transform, false);
		body.transform.localPosition = visualSource.mineModel.transform.localPosition;
		body.transform.localRotation = visualSource.mineModel.transform.localRotation;
		body.transform.localScale = visualSource.mineModel.transform.localScale;
		body.AddComponent<MeshFilter>().sharedMesh = sourceFilter.sharedMesh;
		MeshRenderer renderer = body.AddComponent<MeshRenderer>();
		renderer.sharedMaterials = visualSource.mineModel.sharedMaterials;
		renderer.shadowCastingMode = visualSource.mineModel.shadowCastingMode;
		renderer.receiveShadows = visualSource.mineModel.receiveShadows;
		return root;
	}

	private void Remove(ulong entityId)
	{
		GameObject visual;
		if (!active.TryGetValue(entityId, out visual)) return;
		active.Remove(entityId);
		DestroyObject(visual);
	}

	private void OnDestroy()
	{
		foreach (GameObject visual in active.Values) DestroyObject(visual);
		active.Clear();
	}

	private static void DestroyObject(GameObject value)
	{
		if (value == null) return;
		if (Application.isPlaying) Object.Destroy(value); else Object.DestroyImmediate(value);
	}
}

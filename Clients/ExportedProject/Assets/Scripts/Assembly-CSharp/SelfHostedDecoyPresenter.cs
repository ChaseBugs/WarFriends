using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Presentation only. The Worker owns placement, collision, health and removal.
// These objects copy the recovered Decoy mesh without its Photon/gameplay scripts.
public sealed class SelfHostedDecoyPresenter : MonoBehaviour
{
	private readonly Dictionary<ulong, GameObject> active = new Dictionary<ulong, GameObject>();
	private string localPlayerId;
	private Decoy visualSource;

	public void Configure(string playerId, Decoy source = null)
	{
		localPlayerId = playerId;
		visualSource = source;
	}

	public void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null) return;
		HashSet<ulong> present = new HashSet<ulong>();
		foreach (BattleDecoyState state in snapshot.Decoys)
		{
			present.Add(state.EntityId);
			GameObject visual;
			if (!active.TryGetValue(state.EntityId, out visual))
			{
				visual = Create(state);
				active.Add(state.EntityId, visual);
			}
			visual.transform.position = new Vector3(state.X, state.Y, state.Z);
			Vector3 facing = new Vector3(state.FacingX, state.FacingY, state.FacingZ);
			if (facing.sqrMagnitude > 0.000001f)
				visual.transform.rotation = Quaternion.LookRotation(facing.normalized, Vector3.up);
		}
		List<ulong> stale = new List<ulong>();
		foreach (KeyValuePair<ulong, GameObject> pair in active)
			if (!present.Contains(pair.Key)) stale.Add(pair.Key);
		foreach (ulong id in stale) Remove(id);
	}

	public void ApplyEvent(MatchEvent item)
	{
		if (item != null && item.Kind == MatchEventKind.DecoyDestroyed)
			Remove(item.ProjectileId);
	}

	private GameObject Create(BattleDecoyState state)
	{
		Decoy source = visualSource != null ? visualSource :
			(Singleton<ObjectPoolDatabase>.instance == null ? null : Singleton<ObjectPoolDatabase>.instance.decoy);
		if (source == null || source.bodyRenderer == null)
			throw new System.InvalidOperationException("The recovered Decoy visual is unavailable.");
		GameObject root = new GameObject("SelfHostedDecoy_" + state.EntityId);
		GameObject body = new GameObject(source.bodyRenderer.gameObject.name);
		body.transform.SetParent(root.transform, false);
		body.transform.localPosition = source.bodyRenderer.transform.localPosition;
		body.transform.localRotation = source.bodyRenderer.transform.localRotation;
		body.transform.localScale = source.bodyRenderer.transform.localScale;
		MeshFilter sourceFilter = source.bodyRenderer.GetComponent<MeshFilter>();
		if (sourceFilter == null) throw new System.InvalidOperationException("The recovered Decoy mesh is unavailable.");
		body.AddComponent<MeshFilter>().sharedMesh = sourceFilter.sharedMesh;
		MeshRenderer renderer = body.AddComponent<MeshRenderer>();
		renderer.sharedMaterials = source.bodyRenderer.sharedMaterials;
		renderer.shadowCastingMode = source.bodyRenderer.shadowCastingMode;
		renderer.receiveShadows = source.bodyRenderer.receiveShadows;
		Texture texture = state.OwnerPlayerId == localPlayerId ? CardDecoy.mBlueTexture : CardDecoy.mRedTexture;
		if (texture != null) renderer.material.mainTexture = texture;
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

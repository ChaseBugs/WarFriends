using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Presentation only. Worker snapshots own placement, health, fire and removal.
// Visual children copy recovered meshes/materials without Photon or gameplay scripts.
public sealed class SelfHostedHeavyTurretPresenter : MonoBehaviour
{
	private sealed class Visual { public GameObject Root; public float Health; }
	private readonly Dictionary<ulong, Visual> active = new Dictionary<ulong, Visual>();
	private HeavyTurret source;

	public void Configure(HeavyTurret visualSource) { source = visualSource; }

	public void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null) return;
		HashSet<ulong> present = new HashSet<ulong>();
		foreach (BattleHeavyTurretState state in snapshot.HeavyTurrets)
		{
			present.Add(state.EntityId); Visual visual;
			if (!active.TryGetValue(state.EntityId, out visual))
			{
				visual = Create(state); active.Add(state.EntityId, visual);
			}
			visual.Root.transform.position = new Vector3(state.X, state.Y, state.Z);
			visual.Health = state.Health;
		}
		List<ulong> stale = new List<ulong>();
		foreach (KeyValuePair<ulong, Visual> pair in active) if (!present.Contains(pair.Key)) stale.Add(pair.Key);
		foreach (ulong id in stale) Remove(id, false, Vector3.zero);
	}

	public void ApplyEvent(MatchEvent item)
	{
		if (item == null) return;
		if (item.Kind == MatchEventKind.HeavyTurretDestroyed)
			Remove(item.ProjectileId, true, new Vector3(item.X, item.Y, item.Z));
	}

	private Visual Create(BattleHeavyTurretState state)
	{
		if (source == null) throw new System.InvalidOperationException("The recovered Heavy Turret visual is unavailable.");
		GameObject root = new GameObject("SelfHostedHeavyTurret_" + state.EntityId);
		CopyVisual(source.transform, root.transform, true);
		return new Visual { Root = root, Health = state.Health };
	}

	private static void CopyVisual(Transform from, Transform to, bool root)
	{
		if (!root) { to.localPosition = from.localPosition; to.localRotation = from.localRotation; to.localScale = from.localScale; }
		MeshFilter sourceFilter = from.GetComponent<MeshFilter>(); MeshRenderer sourceRenderer = from.GetComponent<MeshRenderer>();
		if (sourceFilter != null && sourceRenderer != null)
		{
			to.gameObject.AddComponent<MeshFilter>().sharedMesh = sourceFilter.sharedMesh;
			MeshRenderer renderer = to.gameObject.AddComponent<MeshRenderer>();
			renderer.sharedMaterials = sourceRenderer.sharedMaterials; renderer.enabled = sourceRenderer.enabled;
			renderer.shadowCastingMode = sourceRenderer.shadowCastingMode; renderer.receiveShadows = sourceRenderer.receiveShadows;
		}
		for (int i = 0; i < from.childCount; i++)
		{
			Transform childSource = from.GetChild(i); GameObject child = new GameObject(childSource.name);
			child.transform.SetParent(to, false); CopyVisual(childSource, child.transform, false);
		}
	}

	private void Remove(ulong id, bool effects, Vector3 position)
	{
		Visual visual; if (!active.TryGetValue(id, out visual)) return; active.Remove(id);
		if (effects && Application.isPlaying)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(position, Vector3.up, "metalExplosion", "grenadeExplosion");
			Explosion.PlayEffects(Explosion.ExplosionType.Medium, position);
		}
		DestroyVisual(visual.Root);
	}

	private void OnDestroy() { foreach (Visual visual in active.Values) DestroyVisual(visual.Root); active.Clear(); }
	private static void DestroyVisual(GameObject value)
	{ if (value == null) return; if (Application.isPlaying) Object.Destroy(value); else Object.DestroyImmediate(value); }
}

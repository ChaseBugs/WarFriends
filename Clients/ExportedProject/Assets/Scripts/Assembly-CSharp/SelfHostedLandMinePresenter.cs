using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Presentation only. The Worker owns placement, trigger collision, damage and removal.
// The visual copies the recovered MineAmmo mesh without Photon, physics or gameplay scripts.
public sealed class SelfHostedLandMinePresenter : MonoBehaviour
{
	private sealed class TimedVisual
	{
		public MeshRenderer Renderer;
		public MaterialPropertyBlock Properties = new MaterialPropertyBlock();
		public ulong ExpiresTick;
		public ulong ObservedTick;
		public float ObservedAt;
		public float LastUpdateAt;
		public float BlinkingTime;
		public bool BlinkOn;
	}

	private readonly Dictionary<ulong, GameObject> active = new Dictionary<ulong, GameObject>();
	private readonly Dictionary<ulong, TimedVisual> timed = new Dictionary<ulong, TimedVisual>();
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
			if (state.CardId == "CardMineYourStep")
			{
				TimedVisual indicator;
				if (!timed.TryGetValue(state.EntityId, out indicator))
				{
					indicator = new TimedVisual { Renderer = visual.GetComponentInChildren<MeshRenderer>(),
						LastUpdateAt = Time.realtimeSinceStartup };
					if (indicator.Renderer == null)
						throw new System.InvalidOperationException("The timed mine renderer is unavailable.");
				if (indicator.Renderer.sharedMaterials.Length < 2)
						throw new System.InvalidOperationException("The timed mine blink material is unavailable.");
					timed.Add(state.EntityId, indicator);
				}
				indicator.ExpiresTick = state.ExpiresTick;
				indicator.ObservedTick = snapshot.ServerTick;
				indicator.ObservedAt = Time.realtimeSinceStartup;
			}
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
			if (Application.isPlaying && item.Reason != "owner-disconnected")
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
		string name = state.CardId == "CardMineYourStep" ? "SelfHostedTimedMine_" : "SelfHostedLandMine_";
		GameObject root = new GameObject(name + state.EntityId);
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

	private void Update()
	{
		foreach (TimedVisual visual in timed.Values)
		{
			float now = Time.realtimeSinceStartup;
			float elapsed = now - visual.ObservedAt;
			ulong ticksRemaining = visual.ExpiresTick > visual.ObservedTick
				? visual.ExpiresTick - visual.ObservedTick : 0;
			float remaining = Mathf.Max(0f, (float)ticksRemaining / 30f - elapsed);
			float fraction = Mathf.Clamp01(remaining / 15f);
			float blinkInterval = fraction * 0.5f + 0.1f;
			float delta = Mathf.Max(0f, now - visual.LastUpdateAt);
			visual.LastUpdateAt = now;
			visual.BlinkingTime += visual.BlinkOn ? delta : -delta * 0.5f;
			if ((visual.BlinkOn && visual.BlinkingTime > blinkInterval) ||
				(!visual.BlinkOn && visual.BlinkingTime < 0f))
				visual.BlinkOn = !visual.BlinkOn;
			float pulse = visual.BlinkingTime / blinkInterval;
			visual.Properties.SetColor("_TintColor",
				Color.Lerp(Color.black, new Color(1f, 0.5f, 0.5f, 1f), pulse));
			visual.Renderer.SetPropertyBlock(visual.Properties, 1);
		}
	}

	private void Remove(ulong entityId)
	{
		GameObject visual;
		if (!active.TryGetValue(entityId, out visual)) return;
		active.Remove(entityId);
		timed.Remove(entityId);
		DestroyObject(visual);
	}

	private void OnDestroy()
	{
		foreach (GameObject visual in active.Values) DestroyObject(visual);
		active.Clear();
		timed.Clear();
	}

	private static void DestroyObject(GameObject value)
	{
		if (value == null) return;
		if (Application.isPlaying) Object.Destroy(value); else Object.DestroyImmediate(value);
	}
}

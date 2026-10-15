using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Copies only the recovered box mesh. The Worker owns its motion and lifetime.
public sealed class SelfHostedBonusBoxPresenter : MonoBehaviour
{
	private readonly Dictionary<string, GameObject> active =
		new Dictionary<string, GameObject>(StringComparer.Ordinal);
	private KillStreakBonusBox visualSource;
	private string localPlayerId;

	public void Configure(KillStreakBonusBox source, string playerId)
	{
		visualSource = source;
		localPlayerId = playerId;
	}

	public void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null) return;
		HashSet<string> present = new HashSet<string>(StringComparer.Ordinal);
		foreach (BattlePvpBonusBoxState box in snapshot.PvpBonusBoxes)
		{
			present.Add(box.BoxId);
			GameObject visual;
			if (!active.TryGetValue(box.BoxId, out visual))
			{
				visual = Create(box);
				active.Add(box.BoxId, visual);
			}
			visual.transform.position = new Vector3(box.X, box.Y, box.Z);
		}

		List<string> stale = new List<string>();
		foreach (KeyValuePair<string, GameObject> pair in active)
			if (!present.Contains(pair.Key)) stale.Add(pair.Key);
		foreach (string boxId in stale) Remove(boxId);
	}

	private GameObject Create(BattlePvpBonusBoxState box)
	{
		if (visualSource == null)
			throw new InvalidOperationException("The recovered bonus box visual is unavailable.");
		MeshFilter sourceMesh = visualSource.GetComponent<MeshFilter>();
		if (sourceMesh == null || sourceMesh.sharedMesh == null)
			throw new InvalidOperationException("The recovered bonus box mesh is unavailable.");

		GameObject visual = new GameObject("SelfHostedBonusBox_" + box.BoxId);
		visual.transform.rotation = visualSource.transform.rotation;
		visual.transform.localScale = visualSource.transform.localScale;
		visual.AddComponent<MeshFilter>().sharedMesh = sourceMesh.sharedMesh;
		MeshRenderer renderer = visual.AddComponent<MeshRenderer>();
		renderer.sharedMaterial = box.OwnerPlayerId == localPlayerId ?
			visualSource.blueMat : visualSource.redMat;
		return visual;
	}

	private void Remove(string boxId)
	{
		GameObject visual;
		if (!active.TryGetValue(boxId, out visual)) return;
		active.Remove(boxId);
		DestroyVisual(visual);
	}

	private void OnDestroy()
	{
		foreach (GameObject visual in active.Values) DestroyVisual(visual);
		active.Clear();
	}

	private static void DestroyVisual(GameObject visual)
	{
		if (visual == null) return;
		if (Application.isPlaying) UnityEngine.Object.Destroy(visual);
		else UnityEngine.Object.DestroyImmediate(visual);
	}
}

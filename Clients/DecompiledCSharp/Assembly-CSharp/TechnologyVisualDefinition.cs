using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TechnologyVisualDefinition
{
	private const bool useAssetBundles = false;

	public int level;

	public string materialTextrePathRed;

	public string materialTextrePathBlue;

	public List<UpgradeSlots.VisualSlotMesh> visualSlotMeshes;

	public int weaponNumber;

	public Texture2D materialTetxureRed { get; private set; }

	public Texture2D materialTetxureBlue { get; private set; }

	public IEnumerator LoadMineAsync()
	{
		if (materialTetxureBlue == null && !string.IsNullOrEmpty(materialTextrePathBlue))
		{
			materialTetxureBlue = Resources.Load<Texture2D>(materialTextrePathBlue);
		}
		yield break;
	}

	public void NullMine()
	{
		materialTetxureBlue = null;
	}

	public IEnumerator LoadOpponentAsync()
	{
		if (materialTetxureRed == null && !string.IsNullOrEmpty(materialTextrePathRed))
		{
			materialTetxureRed = Resources.Load<Texture2D>(materialTextrePathRed);
		}
		yield break;
	}

	public void NullOpponent()
	{
		materialTetxureRed = null;
	}

	public void UnloadAll()
	{
		if (materialTetxureBlue != null)
		{
			Resources.UnloadAsset(materialTetxureBlue);
		}
		if (materialTetxureRed != null)
		{
			Resources.UnloadAsset(materialTetxureRed);
		}
		materialTetxureBlue = null;
		materialTetxureRed = null;
	}
}

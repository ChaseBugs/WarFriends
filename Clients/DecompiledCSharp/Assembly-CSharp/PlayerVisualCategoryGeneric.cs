using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class PlayerVisualCategoryGeneric<T> : PlayerVisualCategory where T : PlayerVisual
{
	public List<T> visuals;

	private Dictionary<string, T> visualsDictionary = new Dictionary<string, T>();

	public T t_equippedVisual
	{
		get
		{
			if (CamosManager.instance.data.slots.ContainsKey(base.categoryNumber))
			{
				string equippedID = CamosManager.instance.data.slots[base.categoryNumber].equippedID;
				if (!string.IsNullOrEmpty(equippedID) && visualsDictionary.ContainsKey(equippedID))
				{
					return visualsDictionary[equippedID];
				}
				Debug.LogError("Equpped error: Category " + base.name + " doesnt contain " + (string.IsNullOrEmpty(equippedID) ? "Null" : equippedID));
			}
			else
			{
				Debug.LogError($"Category number {base.categoryNumber} is not present in CamosManager.instance.data.slots");
			}
			return visuals[0];
		}
	}

	public override IEnumerable<PlayerVisual> allVisuals => visuals.ToArray();

	public override int count => visuals.Count;

	public override PlayerVisual equippedVisual => t_equippedVisual;

	public override PlayerVisual this[string id]
	{
		get
		{
			if (!string.IsNullOrEmpty(id) && visualsDictionary.ContainsKey(id))
			{
				return visualsDictionary[id];
			}
			Debug.LogError("Category " + base.name + " doesnt contain " + (string.IsNullOrEmpty(id) ? "Null" : id));
			return visuals[0];
		}
	}

	public override void SetVisualIds()
	{
		foreach (T visual in visuals)
		{
			T current = visual;
			current.id = idPrefix + current.visualName;
		}
	}

	public override void InitVisuals()
	{
		int num = 0;
		foreach (T visual in visuals)
		{
			T current = visual;
			string id = idPrefix + current.visualName;
			current.id = id;
			visualsDictionary[current.id] = current;
			current.row = CamosManager.instance.visuals.GetRow(current.id);
			if (current.row == null)
			{
				Debug.LogError("Player visual Error: id not find: " + current.id);
				current.row = new PlayerVisualsRow("Name", "1", "0", "0", "0", "0", "0", "0", "0", "FALSE", "shop", "0", "0", "0");
			}
			current.owner = this;
			current.Initialize();
			num++;
			if (!CamosManager.instance.data.visuals.ContainsKey(current.id))
			{
				CamosManager.instance.data.visuals[current.id] = new CamosManager.SavedPlayerVisual();
			}
		}
	}

	public override IEnumerator PrepareAssets()
	{
		yield break;
	}
}

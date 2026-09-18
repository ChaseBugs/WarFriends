using System.Collections.Generic;
using System.Text;
using UnityEngine;

[ExecuteInEditMode]
public class LayersCheckerFor2D : Core_BaseScript
{
	private enum Type
	{
		Nothing,
		Root,
		Panel,
		Label,
		Sprite,
		Texture
	}

	private class Structure2D
	{
		public Type type;

		public string name;

		public int widgetDepth;

		public List<Structure2D> panels;

		public float relativeZ;

		public string otherInfo;

		public List<Structure2D> children;

		public void AddPanel(Structure2D item)
		{
			if (panels == null)
			{
				panels = new List<Structure2D>();
			}
			panels.Add(item);
		}

		public void AddChildren(Structure2D item)
		{
			if (children == null)
			{
				children = new List<Structure2D>();
			}
			children.Add(item);
		}

		public string PrintInfo()
		{
			if (type == Type.Panel)
			{
				return $"Panel   z:{relativeZ}\t\"{name}\"";
			}
			if (type == Type.Label)
			{
				return $"Label   z:{relativeZ}\t\"{name}\"    with depth:{widgetDepth} and font:{otherInfo}";
			}
			if (type == Type.Sprite)
			{
				return $"Sprite  z:{relativeZ}\t\"{name}\"    with depth:{widgetDepth} and atlas:{otherInfo}";
			}
			if (type == Type.Texture)
			{
				return $"Texture z:{relativeZ}\t\"{name}\"    with depth:{widgetDepth}";
			}
			return type.ToString();
		}
	}

	[Header("Task")]
	public bool createStructure;

	public bool prettyPrint;

	public bool printLayers;

	public bool checkZ;

	public bool checkDepths;

	private Structure2D mCurrentStructure;

	protected void Update()
	{
		if (createStructure)
		{
			createStructure = false;
			CreateStructure();
			Debug.Log("Structure Created");
		}
		if (prettyPrint)
		{
			prettyPrint = false;
			if (mCurrentStructure == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				PrettyPrint();
			}
		}
		if (printLayers)
		{
			printLayers = false;
			if (mCurrentStructure == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				PrintLayersOfPanel(mCurrentStructure);
			}
		}
		if (checkZ)
		{
			checkZ = false;
			if (mCurrentStructure == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				CheckLayerZ(mCurrentStructure);
			}
		}
		if (checkDepths)
		{
			checkDepths = false;
			if (mCurrentStructure == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				CheckDepth(mCurrentStructure);
			}
		}
	}

	private void CreateStructure()
	{
		mCurrentStructure = new Structure2D();
		mCurrentStructure.type = Type.Root;
		mCurrentStructure.name = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (IsDirectChildren(base.transform, componentsInChildren[i].transform))
				{
					mCurrentStructure.AddPanel(GetPanelData(componentsInChildren[i], shouldComputeZ: false));
				}
			}
		}
		else
		{
			mCurrentStructure.AddPanel(GetPanelData(component, shouldComputeZ: false));
		}
	}

	private bool IsDirectChildren(Transform parent, Transform child)
	{
		Transform parent2 = child.parent;
		while (parent2 != parent)
		{
			UIPanel component = parent2.GetComponent<UIPanel>();
			if (component != null)
			{
				return false;
			}
			parent2 = parent2.parent;
		}
		return true;
	}

	private float GetRelativeZ(Transform child)
	{
		float num = child.localPosition.z;
		Transform parent = child.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private Structure2D GetPanelData(UIPanel panel, bool shouldComputeZ = true)
	{
		Structure2D structure2D = new Structure2D();
		structure2D.type = Type.Panel;
		structure2D.name = panel.gameObject.name;
		if (shouldComputeZ)
		{
			structure2D.relativeZ = GetRelativeZ(panel.transform);
		}
		else
		{
			structure2D.relativeZ = panel.transform.localPosition.z;
		}
		UILabel[] componentsInChildren = panel.GetComponentsInChildren<UILabel>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (IsDirectChildren(panel.transform, componentsInChildren[i].transform))
			{
				structure2D.AddChildren(GetLabelData(componentsInChildren[i]));
			}
		}
		UISprite[] componentsInChildren2 = panel.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (IsDirectChildren(panel.transform, componentsInChildren2[j].transform))
			{
				structure2D.AddChildren(GetSpriteData(componentsInChildren2[j]));
			}
		}
		UITexture[] componentsInChildren3 = panel.GetComponentsInChildren<UITexture>(includeInactive: true);
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			if (IsDirectChildren(panel.transform, componentsInChildren3[k].transform))
			{
				structure2D.AddChildren(GetTextureData(componentsInChildren3[k]));
			}
		}
		UIPanel[] componentsInChildren4 = panel.GetComponentsInChildren<UIPanel>(includeInactive: true);
		for (int l = 0; l < componentsInChildren4.Length; l++)
		{
			if (!(componentsInChildren4[l].transform == panel.transform) && IsDirectChildren(panel.transform, componentsInChildren4[l].transform))
			{
				structure2D.AddPanel(GetPanelData(componentsInChildren4[l]));
			}
		}
		return structure2D;
	}

	private Structure2D GetLabelData(UILabel label)
	{
		Structure2D structure2D = new Structure2D();
		structure2D.type = Type.Label;
		structure2D.name = label.gameObject.name;
		structure2D.otherInfo = label.font.ToString();
		structure2D.widgetDepth = label.depth;
		structure2D.relativeZ = GetRelativeZ(label.transform);
		return structure2D;
	}

	private Structure2D GetSpriteData(UISprite sprite)
	{
		Structure2D structure2D = new Structure2D();
		structure2D.type = Type.Sprite;
		structure2D.name = sprite.gameObject.name;
		structure2D.otherInfo = ((!(sprite.atlas == null)) ? sprite.atlas.ToString() : "null");
		structure2D.widgetDepth = sprite.depth;
		structure2D.relativeZ = GetRelativeZ(sprite.transform);
		return structure2D;
	}

	private Structure2D GetTextureData(UITexture texture)
	{
		Structure2D structure2D = new Structure2D();
		structure2D.type = Type.Texture;
		structure2D.name = texture.gameObject.name;
		structure2D.otherInfo = string.Empty;
		structure2D.widgetDepth = texture.depth;
		structure2D.relativeZ = GetRelativeZ(texture.transform);
		return structure2D;
	}

	private void PrettyPrint()
	{
		if (mCurrentStructure.type != Type.Root)
		{
			Debug.Log("Error - first node is not ROOT but " + mCurrentStructure.type);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("ROOT:\n", 2000);
		if (mCurrentStructure.panels != null)
		{
			for (int i = 0; i < mCurrentStructure.panels.Count; i++)
			{
				stringBuilder.Append(PrintPanelData(1, mCurrentStructure.panels[i]));
				stringBuilder.Append("\n");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private string PrintChildData(int nestedLevel, Structure2D data)
	{
		StringBuilder stringBuilder = new StringBuilder(200);
		for (int i = 0; i < nestedLevel; i++)
		{
			stringBuilder.Append(" ");
		}
		stringBuilder.Append(data.PrintInfo());
		return stringBuilder.ToString();
	}

	private string PrintPanelData(int nestedLevel, Structure2D data)
	{
		StringBuilder stringBuilder = new StringBuilder(1000);
		for (int i = 0; i < nestedLevel; i++)
		{
			stringBuilder.Append(" ");
		}
		stringBuilder.Append(data.PrintInfo());
		stringBuilder.Append("\n");
		if (data.children != null)
		{
			for (int j = 0; j < data.children.Count; j++)
			{
				stringBuilder.Append(PrintChildData(nestedLevel + 1, data.children[j]));
				stringBuilder.Append("\n");
			}
		}
		if (data.panels != null)
		{
			for (int k = 0; k < data.panels.Count; k++)
			{
				stringBuilder.Append(PrintPanelData(nestedLevel + 1, data.panels[k]));
				stringBuilder.Append("\n");
			}
		}
		return stringBuilder.ToString();
	}

	private void PrintLayersOfPanel(Structure2D data, bool recursive = true)
	{
		if (data.type == Type.Panel)
		{
			List<Structure2D> list = new List<Structure2D>();
			for (int i = 0; i < data.children.Count; i++)
			{
				Structure2D structure2D = data.children[i];
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					flag |= structure2D.type == list[j].type && structure2D.otherInfo == list[j].otherInfo && Mathf.Abs(structure2D.relativeZ - list[j].relativeZ) < 0.1f;
				}
				if (!flag)
				{
					list.Add(structure2D);
				}
			}
			StringBuilder stringBuilder = new StringBuilder($"For panel \"{data.name}\" layers:\n", 1000);
			for (int k = 0; k < list.Count; k++)
			{
				stringBuilder.Append($" {list[k].type} - {list[k].otherInfo} in {list[k].relativeZ}\n");
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (recursive && data.panels != null)
		{
			for (int l = 0; l < data.panels.Count; l++)
			{
				PrintLayersOfPanel(data.panels[l], recursive);
			}
		}
	}

	private void CheckLayerZ(Structure2D data, bool recursive = true)
	{
		if (data.type == Type.Panel)
		{
			bool flag = false;
			List<Structure2D> list = new List<Structure2D>();
			for (int i = 0; i < data.children.Count; i++)
			{
				Structure2D structure2D = data.children[i];
				bool flag2 = false;
				if (structure2D.type != Type.Texture)
				{
					for (int j = 0; j < list.Count; j++)
					{
						flag2 |= structure2D.type == list[j].type && structure2D.otherInfo == list[j].otherInfo && Mathf.Abs(structure2D.relativeZ - list[j].relativeZ) < 0.1f;
					}
				}
				if (!flag2)
				{
					list.Add(structure2D);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				Structure2D structure2D2 = list[k];
				for (int l = k + 1; l < list.Count; l++)
				{
					Structure2D structure2D3 = list[l];
					if (structure2D2.type == structure2D3.type && structure2D2.otherInfo == structure2D3.otherInfo && Mathf.Abs(structure2D2.relativeZ - structure2D3.relativeZ) > 0.1f)
					{
						flag = true;
						Debug.LogErrorFormat("For {0} - {1} are objects in different Z\n{2} in {3} and {4} in {5}", structure2D2.type, structure2D2.otherInfo, structure2D2.name, structure2D2.relativeZ, structure2D3.name, structure2D3.relativeZ);
					}
				}
			}
			if (!flag)
			{
				Debug.LogFormat("Panel \"{0}\" has ok Z", data.name);
			}
		}
		if (recursive && data.panels != null)
		{
			for (int m = 0; m < data.panels.Count; m++)
			{
				CheckLayerZ(data.panels[m], recursive);
			}
		}
	}

	private void CheckDepth(Structure2D data, bool recursive = true)
	{
		if (data.type == Type.Panel)
		{
			bool flag = false;
			List<Structure2D> list = new List<Structure2D>();
			for (int i = 0; i < data.children.Count; i++)
			{
				Structure2D structure2D = data.children[i];
				for (int j = i + 1; j < data.children.Count; j++)
				{
					Structure2D structure2D2 = data.children[j];
					if (structure2D.type == structure2D2.type && structure2D.otherInfo == structure2D2.otherInfo && structure2D.widgetDepth == structure2D2.widgetDepth)
					{
						flag = true;
						Debug.LogErrorFormat("{0} - {1} objects in same depth\n{2} and {3} in depth {4}", structure2D.type, structure2D.otherInfo, structure2D.name, structure2D2.name, structure2D2.widgetDepth);
					}
				}
			}
			if (!flag)
			{
				Debug.LogFormat("Panel \"{0}\" has ok Depths", data.name);
			}
		}
		if (recursive && data.panels != null)
		{
			for (int k = 0; k < data.panels.Count; k++)
			{
				CheckDepth(data.panels[k], recursive);
			}
		}
	}
}

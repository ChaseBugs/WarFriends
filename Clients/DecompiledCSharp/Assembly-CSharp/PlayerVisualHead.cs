using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerVisualHead : PlayerVisual
{
	public enum HeadPart
	{
		Forhead = 1,
		Eyes = 2,
		Mouth = 4,
		All = 16777215
	}

	[Serializable]
	public class CamoTransform
	{
		public string camoName;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public static void SetTransform(GameObject gameObject, CamoTransform camoTransform)
		{
			if (camoTransform != null)
			{
				gameObject.transform.localPosition = camoTransform.position;
				gameObject.transform.localRotation = camoTransform.rotation;
				gameObject.transform.localScale = camoTransform.scale;
			}
			else
			{
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = Vector3.one;
			}
		}
	}

	public string path;

	[BitMask(typeof(HeadPart))]
	public HeadPart headPart;

	public List<CamoTransform> camoTransforms;

	public Dictionary<string, CamoTransform> camoTransformDict;

	public MeshRenderer mesh { get; private set; }

	public override void LoadPathsForEditor()
	{
		base.LoadPathsForEditor();
	}

	public override void Null()
	{
		base.Null();
		mesh = null;
	}

	public override void Load()
	{
		base.Load();
		if (mesh == null && !string.IsNullOrEmpty(path))
		{
			GameObject gameObject = Resources.Load<GameObject>(path);
			mesh = gameObject.GetComponent<MeshRenderer>();
		}
	}

	public override void ApplyVisual(ICharacter character, bool useHighRes = false)
	{
		base.ApplyVisual(character, useHighRes);
		Load();
	}

	public override void Initialize()
	{
		base.Initialize();
		camoTransformDict = new Dictionary<string, CamoTransform>();
		foreach (CamoTransform camoTransform in camoTransforms)
		{
			string key = CamosManager.instance.playerVisualCategories[0].idPrefix + camoTransform.camoName;
			camoTransformDict.Add(key, camoTransform);
		}
	}

	public MeshRenderer GetMesh()
	{
		return mesh;
	}
}

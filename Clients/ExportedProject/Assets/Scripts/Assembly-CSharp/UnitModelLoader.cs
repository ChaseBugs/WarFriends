using System.Collections.Generic;
using UnityEngine;

public class UnitModelLoader : Core_BaseScript
{
	public List<MeshFilter> modelParts;

	public List<SkinnedMeshRenderer> modelSkinnedParts;

	public virtual void LoadModel(GameObject unitModel)
	{
		if (unitModel != null)
		{
			MeshFilter[] componentsInChildren = unitModel.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter modelPart in modelParts)
			{
				string text = modelPart.name;
				MeshFilter[] array = componentsInChildren;
				foreach (MeshFilter meshFilter in array)
				{
					if (meshFilter.name == text)
					{
						modelPart.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(unitModel != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer modelSkinnedPart in modelSkinnedParts)
		{
			string text2 = modelSkinnedPart.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				if (skinnedMeshRenderer.name == text2)
				{
					modelSkinnedPart.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void Reset()
	{
		foreach (MeshFilter modelPart in modelParts)
		{
			modelPart.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer modelSkinnedPart in modelSkinnedParts)
		{
			modelSkinnedPart.sharedMesh = null;
		}
	}
}

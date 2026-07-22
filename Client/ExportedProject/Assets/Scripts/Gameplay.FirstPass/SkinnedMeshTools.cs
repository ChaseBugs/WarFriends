using UnityEngine;

public static class SkinnedMeshTools
{
	public static void ChangeSkins(SkinnedMeshRenderer fromRenderer, SkinnedMeshRenderer newRenderer)
	{
		if (fromRenderer != null && newRenderer != null)
		{
			Transform[] array = new Transform[fromRenderer.bones.Length];
			Transform parent = newRenderer.transform.parent;
			for (int i = 0; i < fromRenderer.bones.Length; i++)
			{
				array[i] = FindChildByName(fromRenderer.bones[i].name, parent);
			}
			newRenderer.bones = array;
			newRenderer.sharedMesh = fromRenderer.sharedMesh;
		}
	}

	private static Transform FindChildByName(string ThisName, Transform ThisGObj)
	{
		if (ThisGObj.name == ThisName)
		{
			return ThisGObj.transform;
		}
		foreach (Transform item in ThisGObj)
		{
			Transform transform = FindChildByName(ThisName, item);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}
}

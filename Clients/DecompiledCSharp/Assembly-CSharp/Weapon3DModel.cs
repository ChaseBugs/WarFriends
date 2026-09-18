using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3DModel : Core_BaseScript
{
	[Serializable]
	public class WeaponSlot
	{
		public Transform slotPosition;

		public int slotID;
	}

	public List<WeaponSlot> slots;

	public void UnloadWeapon()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("_BumpMap");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void Load()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("_BumpMap");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}
}

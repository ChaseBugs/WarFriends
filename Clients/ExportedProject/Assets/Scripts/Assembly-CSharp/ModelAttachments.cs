using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelAttachments : Core_BaseScript
{
	[Serializable]
	public class ModelAttachment
	{
		public Transform parent;

		public int id;

		internal MeshRenderer mPrefab;

		internal MeshRenderer mInstance;
	}

	public List<ModelAttachment> modelAttachments;

	private Dictionary<int, ModelAttachment> attachmentInstancies = new Dictionary<int, ModelAttachment>();

	public void HideAllAttachments()
	{
		foreach (KeyValuePair<int, ModelAttachment> attachmentInstancy in attachmentInstancies)
		{
			if (attachmentInstancy.Value.mInstance != null)
			{
				attachmentInstancy.Value.mInstance.gameObject.SetActive(value: false);
			}
		}
	}

	public void AddAttachment(MeshRenderer prefab, int slotId, Material sharedmat = null, PlayerVisualHead.CamoTransform camoTransform = null)
	{
		ModelAttachment value = null;
		if (attachmentInstancies.TryGetValue(slotId, out value))
		{
			MeshRenderer obj = value.mInstance;
			if (value.mPrefab != prefab)
			{
				if (value.mInstance != null)
				{
					UnityEngine.Object.Destroy(value.mInstance.gameObject);
				}
				value.mPrefab = prefab;
				obj = UnityEngine.Object.Instantiate(prefab);
				attachmentInstancies[slotId] = value;
			}
			AttachObject(value, obj, sharedmat, camoTransform);
			value.mInstance.gameObject.SetActive(value: true);
			return;
		}
		foreach (ModelAttachment modelAttachment in modelAttachments)
		{
			if (modelAttachment.id == slotId)
			{
				value = modelAttachment;
				break;
			}
		}
		if (value != null)
		{
			value.mPrefab = prefab;
			AttachObject(obj: value.mInstance = UnityEngine.Object.Instantiate(prefab), m: value, sharedmat: sharedmat, camoTransform: camoTransform);
			attachmentInstancies[slotId] = value;
			value.mInstance.gameObject.SetActive(value: true);
		}
	}

	public void SetAttachmentsMaterial(Material material)
	{
		foreach (KeyValuePair<int, ModelAttachment> attachmentInstancy in attachmentInstancies)
		{
			MeshRenderer[] componentsInChildren = attachmentInstancy.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = material;
			}
		}
	}

	private void AttachObject(ModelAttachment m, MeshRenderer obj, Material sharedmat, PlayerVisualHead.CamoTransform camoTransform)
	{
		m.mInstance = obj;
		obj.transform.parent = m.parent;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		obj.transform.localScale = Vector3.one;
		obj.gameObject.layer = base.gameObject.layer;
		obj.useLightProbes = true;
		if (sharedmat != null)
		{
			MeshRenderer[] componentsInChildren = obj.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = sharedmat;
				meshRenderer.useLightProbes = true;
			}
		}
	}

	public void NullTextures()
	{
		foreach (KeyValuePair<int, ModelAttachment> attachmentInstancy in attachmentInstancies)
		{
			MeshRenderer mInstance = attachmentInstancy.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = null;
			}
		}
	}
}

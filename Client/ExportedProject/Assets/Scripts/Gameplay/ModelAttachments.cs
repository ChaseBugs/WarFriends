using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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

	[FormerlySerializedAs("IHOEHGMFODF")]
	public List<ModelAttachment> BLHMGOMCDFG;

	private Dictionary<int, ModelAttachment> KOMKEICFCLI = new Dictionary<int, ModelAttachment>();

	public void PJEDDDLCHHJ()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	private void AIBGOMOFFDA(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = true;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = false;
			}
		}
	}

	private void INMDHPKDLLA(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = false;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = false;
			}
		}
	}

	private void JBACJKOMCEP(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = false;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = true;
			}
		}
	}

	public void JDJGJKNKBIC()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	private void AFOKMNKCAFG(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = true;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = false;
			}
		}
	}

	private void PMHEONMBBLH(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = true;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = true;
			}
		}
	}

	public void PADKBBBFNEA()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	public void IFMCHKEJPPE()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: false);
			}
		}
	}

	public void NMOADHMAAOE()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: false);
			}
		}
	}

	public void AJAFDBLABMA(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void BMDAFFNPDOM()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: true);
			}
		}
	}

	public void LEGDLNGKLGO(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void MLGBHGMAKGC()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: false);
			}
		}
	}

	public void HideAllAttachments()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: false);
			}
		}
	}

	public void BHPOACJHNEJ(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void ABJFHJGFPFF()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	public void LNCAEAGCJKM()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	public void ICJJOOFHEJC(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void SetAttachmentsMaterial(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void GCFEBGHLIMB(MeshRenderer ALMCIJEGBKF, int HJGAOIPBMFD, Material FBLEJALOJGL = null, PlayerVisualHead.CamoTransform AELGHBCCEEL = null)
	{
		ModelAttachment value = null;
		if (KOMKEICFCLI.TryGetValue(HJGAOIPBMFD, out value))
		{
			MeshRenderer eNCEFOOPBMK = value.mInstance;
			if (value.mPrefab != ALMCIJEGBKF)
			{
				if (value.mInstance != null)
				{
					UnityEngine.Object.Destroy(value.mInstance.gameObject);
				}
				value.mPrefab = ALMCIJEGBKF;
				eNCEFOOPBMK = UnityEngine.Object.Instantiate(ALMCIJEGBKF);
				KOMKEICFCLI[HJGAOIPBMFD] = value;
			}
			INLKGNJBHPA(value, eNCEFOOPBMK, FBLEJALOJGL, AELGHBCCEEL);
			value.mInstance.gameObject.SetActive(value: false);
			return;
		}
		foreach (ModelAttachment item in BLHMGOMCDFG)
		{
			if (item.id == HJGAOIPBMFD)
			{
				value = item;
				break;
			}
		}
		if (value != null)
		{
			value.mPrefab = ALMCIJEGBKF;
			INLKGNJBHPA(ENCEFOOPBMK: value.mInstance = UnityEngine.Object.Instantiate(ALMCIJEGBKF), FJNJGHGMFND: value, FBLEJALOJGL: FBLEJALOJGL, AELGHBCCEEL: AELGHBCCEEL);
			KOMKEICFCLI[HJGAOIPBMFD] = value;
			value.mInstance.gameObject.SetActive(value: true);
		}
	}

	public void KKBKBEHEFCP()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	public void GCHKDAIFKDG(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void HOPMMFHKFBO()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: true);
			}
		}
	}

	private void INLKGNJBHPA(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = false;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = false;
			}
		}
	}

	public void EHODOJBGHFE()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	public void NullTextures()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer mInstance = item.Value.mInstance;
			MeshRenderer[] componentsInChildren = mInstance.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = null;
			}
		}
	}

	public void AddAttachment(MeshRenderer ALMCIJEGBKF, int HJGAOIPBMFD, Material FBLEJALOJGL = null, PlayerVisualHead.CamoTransform AELGHBCCEEL = null)
	{
		ModelAttachment value = null;
		if (KOMKEICFCLI.TryGetValue(HJGAOIPBMFD, out value))
		{
			MeshRenderer eNCEFOOPBMK = value.mInstance;
			if (value.mPrefab != ALMCIJEGBKF)
			{
				if (value.mInstance != null)
				{
					UnityEngine.Object.Destroy(value.mInstance.gameObject);
				}
				value.mPrefab = ALMCIJEGBKF;
				eNCEFOOPBMK = UnityEngine.Object.Instantiate(ALMCIJEGBKF);
				KOMKEICFCLI[HJGAOIPBMFD] = value;
			}
			PMHEONMBBLH(value, eNCEFOOPBMK, FBLEJALOJGL, AELGHBCCEEL);
			value.mInstance.gameObject.SetActive(value: true);
			return;
		}
		foreach (ModelAttachment item in BLHMGOMCDFG)
		{
			if (item.id == HJGAOIPBMFD)
			{
				value = item;
				break;
			}
		}
		if (value != null)
		{
			value.mPrefab = ALMCIJEGBKF;
			PMHEONMBBLH(ENCEFOOPBMK: value.mInstance = UnityEngine.Object.Instantiate(ALMCIJEGBKF), FJNJGHGMFND: value, FBLEJALOJGL: FBLEJALOJGL, AELGHBCCEEL: AELGHBCCEEL);
			KOMKEICFCLI[HJGAOIPBMFD] = value;
			value.mInstance.gameObject.SetActive(value: true);
		}
	}

	private void IAANFGIKMAP(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = true;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = false;
			}
		}
	}

	public void IKIKNCMAPHP(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void GJBCHFFALBJ(Material FKAJIJIGNEN)
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			MeshRenderer[] componentsInChildren = item.Value.mInstance.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	private void HNFOABGOJKA(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = false;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = true;
			}
		}
	}

	private void OPOGMPJINAM(ModelAttachment FJNJGHGMFND, MeshRenderer ENCEFOOPBMK, Material FBLEJALOJGL, PlayerVisualHead.CamoTransform AELGHBCCEEL)
	{
		FJNJGHGMFND.mInstance = ENCEFOOPBMK;
		ENCEFOOPBMK.transform.parent = FJNJGHGMFND.parent;
		ENCEFOOPBMK.transform.localPosition = Vector3.zero;
		ENCEFOOPBMK.transform.localRotation = Quaternion.identity;
		ENCEFOOPBMK.transform.localScale = Vector3.one;
		ENCEFOOPBMK.gameObject.layer = base.gameObject.layer;
		ENCEFOOPBMK.useLightProbes = false;
		if (FBLEJALOJGL != null)
		{
			MeshRenderer[] componentsInChildren = ENCEFOOPBMK.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			MeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial = FBLEJALOJGL;
				meshRenderer.useLightProbes = false;
			}
		}
	}

	public void GOHNLIHKHED()
	{
		foreach (KeyValuePair<int, ModelAttachment> item in KOMKEICFCLI)
		{
			if (item.Value.mInstance != null)
			{
				item.Value.mInstance.gameObject.SetActive(value: false);
			}
		}
	}
}

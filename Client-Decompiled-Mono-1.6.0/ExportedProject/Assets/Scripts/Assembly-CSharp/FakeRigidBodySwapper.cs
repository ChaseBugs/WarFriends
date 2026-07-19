using System;
using System.Collections.Generic;
using UnityEngine;

public class FakeRigidBodySwapper : Core_BaseScript
{
	[Serializable]
	public class MeshFliterAndRenderer
	{
		public MeshFilter meshFilter;

		public Renderer meshRenderer;
	}

	public GameObject HNFHFKNFIPP;

	public GameObject OJGHLMLKGAN;

	public MeshFliterAndRenderer OJAPOOKMMPK;

	public MeshFliterAndRenderer OKGBANFPPAF;

	public GameObject CIPJHCFDLLJ;

	private Vector3 GMENJOACKEO;

	private Quaternion GEIMIFKAIJF;

	private Transform BLJCKNGLINF;

	private bool PJHFOJMDKOA;

	public void SnapTo(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
		CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
		CIPJHCFDLLJ.transform.localPosition = default(Vector3);
		CIPJHCFDLLJ.transform.localScale = Vector3.one;
	}

	public void Reset()
	{
		PJHFOJMDKOA = false;
		HNFHFKNFIPP.SetActive(true);
		OJGHLMLKGAN.SetActive(false);
		OJGHLMLKGAN.transform.localPosition = GMENJOACKEO;
		OJGHLMLKGAN.transform.localRotation = GEIMIFKAIJF;
		OJGHLMLKGAN.transform.parent = BLJCKNGLINF;
		OJGHLMLKGAN.transform.localScale = Vector3.one;
	}

	public void FJDJPNPEAOC(Mesh ECDKGHHNGEH)
	{
		MEBPMHDHIPJ();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
	}

	public void MAGLHAOFGHL(bool MOMOMPGBCKH)
	{
		if (!base.gameObject.activeInHierarchy || PJHFOJMDKOA)
		{
			return;
		}
		if (MOMOMPGBCKH)
		{
			OJGHLMLKGAN.SetActive(false);
			HNFHFKNFIPP.SetActive(true);
			OJGHLMLKGAN.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
			OJGHLMLKGAN.transform.localScale = Vector3.one;
			if (CIPJHCFDLLJ != null)
			{
				CIPJHCFDLLJ.transform.parent = OJGHLMLKGAN.transform;
				CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
				CIPJHCFDLLJ.transform.localPosition = default(Vector3);
				CIPJHCFDLLJ.transform.localScale = Vector3.one;
			}
		}
		else
		{
			OJGHLMLKGAN.SetActive(true);
			HNFHFKNFIPP.SetActive(false);
			if (CIPJHCFDLLJ != null)
			{
				CIPJHCFDLLJ.transform.parent = HNFHFKNFIPP.transform;
				CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
				CIPJHCFDLLJ.transform.localPosition = default(Vector3);
				CIPJHCFDLLJ.transform.localScale = Vector3.one;
			}
		}
	}

	public void Swap(bool MOMOMPGBCKH)
	{
		if (!base.gameObject.activeInHierarchy || PJHFOJMDKOA)
		{
			return;
		}
		if (MOMOMPGBCKH)
		{
			OJGHLMLKGAN.SetActive(true);
			HNFHFKNFIPP.SetActive(false);
			OJGHLMLKGAN.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
			OJGHLMLKGAN.transform.localScale = Vector3.one;
			if (CIPJHCFDLLJ != null)
			{
				CIPJHCFDLLJ.transform.parent = OJGHLMLKGAN.transform;
				CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
				CIPJHCFDLLJ.transform.localPosition = default(Vector3);
				CIPJHCFDLLJ.transform.localScale = Vector3.one;
			}
		}
		else
		{
			OJGHLMLKGAN.SetActive(false);
			HNFHFKNFIPP.SetActive(true);
			if (CIPJHCFDLLJ != null)
			{
				CIPJHCFDLLJ.transform.parent = HNFHFKNFIPP.transform;
				CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
				CIPJHCFDLLJ.transform.localPosition = default(Vector3);
				CIPJHCFDLLJ.transform.localScale = Vector3.one;
			}
		}
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		Init();
	}

	public void MKHNALDNOFJ(Mesh ECDKGHHNGEH)
	{
		Reset();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
	}

	public void SetMatCapTexture(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.SetTexture("_MatCap", EBFDAICCJAK);
		OKGBANFPPAF.meshRenderer.material.SetTexture("_MatCap", EBFDAICCJAK);
	}

	public void JHMCEKNMCOI(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
	}

	public void Init()
	{
		GMENJOACKEO = OJGHLMLKGAN.transform.localPosition;
		GEIMIFKAIJF = OJGHLMLKGAN.transform.localRotation;
		BLJCKNGLINF = OJGHLMLKGAN.transform.parent;
		if (OJAPOOKMMPK.meshFilter == null)
		{
			OJAPOOKMMPK.meshFilter = HNFHFKNFIPP.GetComponent<MeshFilter>();
			OJAPOOKMMPK.meshRenderer = HNFHFKNFIPP.GetComponent<Renderer>();
		}
		if (OKGBANFPPAF.meshFilter == null)
		{
			OKGBANFPPAF.meshFilter = OJGHLMLKGAN.GetComponent<MeshFilter>();
			OKGBANFPPAF.meshRenderer = OJGHLMLKGAN.GetComponent<Renderer>();
		}
	}

	private void OnDisable()
	{
		if (OJGHLMLKGAN != null)
		{
			OJGHLMLKGAN.SetActive(false);
		}
	}

	public void JINPGBKPGFH(Mesh ECDKGHHNGEH, List<Material> CMEOONLNCIJ)
	{
		Reset();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
	}

	public void FJBMNJFLLCK(Material[] CMEOONLNCIJ)
	{
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ;
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		LDPFPPBNCMF();
	}

	public void SetMesh(Mesh ECDKGHHNGEH, List<Material> CMEOONLNCIJ)
	{
		Reset();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
	}

	private void MIGEMOBNPGJ()
	{
		if (OJGHLMLKGAN != null)
		{
			OJGHLMLKGAN.SetActive(false);
		}
	}

	public void AMJAALPBGIK()
	{
		CIPJHCFDLLJ.transform.localPosition = -HNFHFKNFIPP.transform.localPosition;
		CIPJHCFDLLJ.transform.localRotation = Quaternion.Inverse(HNFHFKNFIPP.transform.localRotation);
		Vector3 localScale = HNFHFKNFIPP.transform.localScale;
		CIPJHCFDLLJ.transform.localScale = new Vector3(1327f / localScale.x, 1859f / localScale.y, 77f / localScale.z);
	}

	public void SetMaterials(Material[] CMEOONLNCIJ)
	{
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ;
	}

	public void DCNNIOCICMA()
	{
		PJHFOJMDKOA = true;
		OJGHLMLKGAN.SetActive(false);
		HNFHFKNFIPP.SetActive(false);
	}

	public void OCGALABKLNO(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
		CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
		CIPJHCFDLLJ.transform.localPosition = default(Vector3);
		CIPJHCFDLLJ.transform.localScale = Vector3.one;
	}

	public void CDPCNCCOIFF(bool MOMOMPGBCKH)
	{
		if (!base.gameObject.activeInHierarchy || PJHFOJMDKOA)
		{
			return;
		}
		if (MOMOMPGBCKH)
		{
			OJGHLMLKGAN.SetActive(true);
			HNFHFKNFIPP.SetActive(false);
			OJGHLMLKGAN.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
			OJGHLMLKGAN.transform.localScale = Vector3.one;
			if (CIPJHCFDLLJ != null)
			{
				CIPJHCFDLLJ.transform.parent = OJGHLMLKGAN.transform;
				CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
				CIPJHCFDLLJ.transform.localPosition = default(Vector3);
				CIPJHCFDLLJ.transform.localScale = Vector3.one;
			}
		}
		else
		{
			OJGHLMLKGAN.SetActive(true);
			HNFHFKNFIPP.SetActive(true);
			if (CIPJHCFDLLJ != null)
			{
				CIPJHCFDLLJ.transform.parent = HNFHFKNFIPP.transform;
				CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
				CIPJHCFDLLJ.transform.localPosition = default(Vector3);
				CIPJHCFDLLJ.transform.localScale = Vector3.one;
			}
		}
	}

	public void SetParent(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
	}

	public void Reposition()
	{
		CIPJHCFDLLJ.transform.localPosition = -HNFHFKNFIPP.transform.localPosition;
		CIPJHCFDLLJ.transform.localRotation = Quaternion.Inverse(HNFHFKNFIPP.transform.localRotation);
		Vector3 localScale = HNFHFKNFIPP.transform.localScale;
		CIPJHCFDLLJ.transform.localScale = new Vector3(1f / localScale.x, 1f / localScale.y, 1f / localScale.z);
	}

	public void PFNCEOKJNHA(Mesh ECDKGHHNGEH, List<Material> CMEOONLNCIJ)
	{
		MEBPMHDHIPJ();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
	}

	public void FOGOFKILPNI(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.mainTexture = EBFDAICCJAK;
		OKGBANFPPAF.meshRenderer.material.mainTexture = EBFDAICCJAK;
	}

	public void ECHIFPGEJBP(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
		CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
		CIPJHCFDLLJ.transform.localPosition = default(Vector3);
		CIPJHCFDLLJ.transform.localScale = Vector3.one;
	}

	public void CDLODKKNAEF()
	{
		PJHFOJMDKOA = false;
		OJGHLMLKGAN.SetActive(true);
		HNFHFKNFIPP.SetActive(true);
	}

	public void SetTexture(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.mainTexture = EBFDAICCJAK;
		OKGBANFPPAF.meshRenderer.material.mainTexture = EBFDAICCJAK;
	}

	public void LDPFPPBNCMF()
	{
		GMENJOACKEO = OJGHLMLKGAN.transform.localPosition;
		GEIMIFKAIJF = OJGHLMLKGAN.transform.localRotation;
		BLJCKNGLINF = OJGHLMLKGAN.transform.parent;
		if (OJAPOOKMMPK.meshFilter == null)
		{
			OJAPOOKMMPK.meshFilter = HNFHFKNFIPP.GetComponent<MeshFilter>();
			OJAPOOKMMPK.meshRenderer = HNFHFKNFIPP.GetComponent<Renderer>();
		}
		if (OKGBANFPPAF.meshFilter == null)
		{
			OKGBANFPPAF.meshFilter = OJGHLMLKGAN.GetComponent<MeshFilter>();
			OKGBANFPPAF.meshRenderer = OJGHLMLKGAN.GetComponent<Renderer>();
		}
	}

	public void LBCHIJHFKPN(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.mainTexture = EBFDAICCJAK;
		OKGBANFPPAF.meshRenderer.material.mainTexture = EBFDAICCJAK;
	}

	public void MEBPMHDHIPJ()
	{
		PJHFOJMDKOA = true;
		HNFHFKNFIPP.SetActive(true);
		OJGHLMLKGAN.SetActive(false);
		OJGHLMLKGAN.transform.localPosition = GMENJOACKEO;
		OJGHLMLKGAN.transform.localRotation = GEIMIFKAIJF;
		OJGHLMLKGAN.transform.parent = BLJCKNGLINF;
		OJGHLMLKGAN.transform.localScale = Vector3.one;
	}

	public void JOEHOEDHENA(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
	}

	protected override void Awake()
	{
		base.Awake();
		Init();
	}

	public void MDHDKNMMECA(Mesh ECDKGHHNGEH, List<Material> CMEOONLNCIJ)
	{
		Reset();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ.ToArray();
	}

	public void SetMesh(Mesh ECDKGHHNGEH)
	{
		Reset();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
	}

	public void JBMBJPJGJFB(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.mainTexture = EBFDAICCJAK;
		OKGBANFPPAF.meshRenderer.material.mainTexture = EBFDAICCJAK;
	}

	public void HKKNOEKNKFI(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.mainTexture = EBFDAICCJAK;
		OKGBANFPPAF.meshRenderer.material.mainTexture = EBFDAICCJAK;
	}

	public void OFMIEHACIAD()
	{
		CIPJHCFDLLJ.transform.localPosition = -HNFHFKNFIPP.transform.localPosition;
		CIPJHCFDLLJ.transform.localRotation = Quaternion.Inverse(HNFHFKNFIPP.transform.localRotation);
		Vector3 localScale = HNFHFKNFIPP.transform.localScale;
		CIPJHCFDLLJ.transform.localScale = new Vector3(443f / localScale.x, 712f / localScale.y, 890f / localScale.z);
	}

	public void CIJLKGLNIPO()
	{
		PJHFOJMDKOA = false;
		OJGHLMLKGAN.SetActive(true);
		HNFHFKNFIPP.SetActive(true);
	}

	public void CJAAEFCHJMG(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
		CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
		CIPJHCFDLLJ.transform.localPosition = default(Vector3);
		CIPJHCFDLLJ.transform.localScale = Vector3.one;
	}

	public void AOHALOBDMIL(Mesh ECDKGHHNGEH)
	{
		Reset();
		OJAPOOKMMPK.meshFilter.sharedMesh = ECDKGHHNGEH;
		OKGBANFPPAF.meshFilter.sharedMesh = ECDKGHHNGEH;
	}

	public void ADGOLGNCGCJ(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
		CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
		CIPJHCFDLLJ.transform.localPosition = default(Vector3);
		CIPJHCFDLLJ.transform.localScale = Vector3.one;
	}

	public void LMBFMKOBIGE(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
	}

	public void GFGEEFGMNDP()
	{
		PJHFOJMDKOA = false;
		HNFHFKNFIPP.SetActive(true);
		OJGHLMLKGAN.SetActive(false);
		OJGHLMLKGAN.transform.localPosition = GMENJOACKEO;
		OJGHLMLKGAN.transform.localRotation = GEIMIFKAIJF;
		OJGHLMLKGAN.transform.parent = BLJCKNGLINF;
		OJGHLMLKGAN.transform.localScale = Vector3.one;
	}

	public void FBJIOHLJHNM(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.SetTexture("PlayerId", EBFDAICCJAK);
		OKGBANFPPAF.meshRenderer.material.SetTexture("ID_WARNING_OFFEREXPIRED", EBFDAICCJAK);
	}

	public void Hide()
	{
		PJHFOJMDKOA = true;
		OJGHLMLKGAN.SetActive(false);
		HNFHFKNFIPP.SetActive(false);
	}

	public void OCLOCHAODNM(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.SetTexture("C5", EBFDAICCJAK);
		OKGBANFPPAF.meshRenderer.material.SetTexture("PhotonConnectionManager: Disconnect", EBFDAICCJAK);
	}

	public void GNIFNDNHODB(Material[] CMEOONLNCIJ)
	{
		OJAPOOKMMPK.meshRenderer.sharedMaterials = CMEOONLNCIJ;
		OKGBANFPPAF.meshRenderer.sharedMaterials = CMEOONLNCIJ;
	}

	protected virtual void KALEMFKOGLE()
	{
		base.Awake();
		LDPFPPBNCMF();
	}

	public void MMJJJBJKHFL(Texture2D EBFDAICCJAK)
	{
		OJAPOOKMMPK.meshRenderer.material.mainTexture = EBFDAICCJAK;
		OKGBANFPPAF.meshRenderer.material.mainTexture = EBFDAICCJAK;
	}

	public void CALKBBMOJED(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		LDPFPPBNCMF();
	}

	public void KGDLJPGAGLG(Transform IIMDKHJAJGO)
	{
		CIPJHCFDLLJ.transform.parent = IIMDKHJAJGO;
		CIPJHCFDLLJ.transform.localRotation = default(Quaternion);
		CIPJHCFDLLJ.transform.localPosition = default(Vector3);
		CIPJHCFDLLJ.transform.localScale = Vector3.one;
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		LDPFPPBNCMF();
	}
}

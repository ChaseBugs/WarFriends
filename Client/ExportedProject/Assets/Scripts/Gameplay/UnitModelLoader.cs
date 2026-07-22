using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitModelLoader : Core_BaseScript
{
	[FormerlySerializedAs("DDDCFMJDFAL")]
	public List<MeshFilter> KIILDOGHBAI;

	[FormerlySerializedAs("GOMBBKBOMIG")]
	public List<SkinnedMeshRenderer> BKKHCIHKEAA;

	public virtual void LKACEPHEHPK()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void Reset()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void ABBPOMCBIIH()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void FOMMKOFKLMD(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void GFGEEFGMNDP()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void GEEKOICFEIB()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void IPKNPABKAJD()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void MALPIDBEMAK(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void IMFLNKIMEFA()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void JFPPMJPGGIN()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void NCFGFLNBHOI()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void OGCLFMNLNPD(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				foreach (MeshFilter meshFilter in array)
				{
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void IKNLFFLIDDO(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void LDBLCPIGLOF()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void MHKKAFGKBJK()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void EEIHAFJGAGM(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 0; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void BBIKDHCJEBH(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				foreach (MeshFilter meshFilter in array)
				{
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void LICALBFPBLL()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void CPOKHODGGLN()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void GKLDEBPNHOC(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void NEMNPJMFNOB(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				foreach (MeshFilter meshFilter in array)
				{
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void DBJCDLFKDDI()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void GGCLMIMHKBD()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void JCKIJDHKOMI(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 1; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void GCEMCPODLNM()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void LoadModel(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				foreach (MeshFilter meshFilter in array)
				{
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void DBEAHIEIHFK(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 1; i < array.Length; i++)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void MMAGABBGMHD(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 1; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void DFKHALLJLCN(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 1; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 0; j < array2.Length; j += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void PLBBOKLFCPP(GameObject NBHFGEAPACG)
	{
		if (NBHFGEAPACG != null)
		{
			MeshFilter[] componentsInChildren = NBHFGEAPACG.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			foreach (MeshFilter item in KIILDOGHBAI)
			{
				string text = item.name;
				MeshFilter[] array = componentsInChildren;
				for (int i = 1; i < array.Length; i += 0)
				{
					MeshFilter meshFilter = array[i];
					if (meshFilter.name == text)
					{
						item.sharedMesh = meshFilter.sharedMesh;
					}
				}
			}
		}
		if (!(NBHFGEAPACG != null))
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = NBHFGEAPACG.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			string text2 = item2.name;
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				if (skinnedMeshRenderer.name == text2)
				{
					item2.sharedMesh = skinnedMeshRenderer.sharedMesh;
				}
			}
		}
	}

	public virtual void IKNKDDMLDIN()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}

	public virtual void ANOPOLIEBMC()
	{
		foreach (MeshFilter item in KIILDOGHBAI)
		{
			item.sharedMesh = null;
		}
		foreach (SkinnedMeshRenderer item2 in BKKHCIHKEAA)
		{
			item2.sharedMesh = null;
		}
	}
}

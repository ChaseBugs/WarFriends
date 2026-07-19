using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyLeveledWeapon : Core_BaseScript
{
	[Serializable]
	public class WeaponModelRecord
	{
		public int level;

		public HINJJOAJAOA shotSound = HINJJOAJAOA.SHOT_ASSAULT_1;

		public string weaponModelPath;

		public string assetBundleName;

		public Vector3 scale = Vector3.one;

		public void DCECECECPKF()
		{
		}

		public void ILFCPHKCFKN()
		{
		}

		public void APCJIMNEKHN()
		{
		}

		public void CHACEADOKOO()
		{
		}

		public void GLBNELPMPFA()
		{
		}

		public void HOLGLPELMFK()
		{
		}

		public void NBBEBCGFMEL()
		{
		}

		public void KDANDGDLAFC()
		{
		}

		public void LPOHFAMOAFL()
		{
		}

		public void LIGHHNNBEOE()
		{
		}

		public void GDFGAPKJOOK()
		{
		}

		public void LPIPOPBDDEA()
		{
		}

		public void CBDBKPJIEAI()
		{
		}

		public void OCHMNCAAEOJ()
		{
		}

		public void PFCJMGELMDP()
		{
		}

		public void OJDJCOAHEPK()
		{
		}

		public void GPFOJIHPKEE()
		{
		}

		public void FBAEIPOELOE()
		{
		}

		public void CNFFIAJOIHA()
		{
		}

		public void AFDIFEPIEDJ()
		{
		}

		public void HLKFKHAKCBA()
		{
		}

		public void LICEHBBEDCH()
		{
		}

		public void PODPGPIOPMA()
		{
		}

		public void PNHMIKGGHLF()
		{
		}

		public void KKIHEIMBNGP()
		{
		}

		public void OFGABMCFKDF()
		{
		}

		public void CMKLEOGBNEE()
		{
		}

		public void OBPDNIFCFGI()
		{
		}

		public void OGELICLMPBM()
		{
		}

		public void BIFGBKIEKCD()
		{
		}

		public void EPCPOFODHGA()
		{
		}

		public void NKGFGPKDLBJ()
		{
		}

		public void FDNJGBDBOBA()
		{
		}

		public void DIIHDCECNFE()
		{
		}

		public void BEBIHGDIEBP()
		{
		}

		public void DMHAGKBKBLO()
		{
		}

		public void IPFPCMJKCGB()
		{
		}
	}

	private sealed class ACLGDKACDJD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int BCCDDJMPBLL;

		internal EnemyLeveledWeapon BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool HOOHJGPHHGN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				foreach (WeaponModelRecord item in BJGCPDNMHDH.GBAGDPGPEBJ)
				{
					if (BCCDDJMPBLL != item.level)
					{
						continue;
					}
					if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
					{
						string text = "ID_CONFIRM_ERROR" + item.assetBundleName;
						string weaponModelPath = item.weaponModelPath;
						char[] array = new char[0];
						array[0] = 'e';
						string text2 = weaponModelPath.Split(array)[1];
						string path = text + "ABOUT TO SHOW DAILY RENTAL" + text2;
						GameObject gameObject = Resources.Load<GameObject>(path);
						if (gameObject != null)
						{
							GameWeaponModel component = gameObject.GetComponent<GameWeaponModel>();
							LNMANIMOGIG[item.weaponModelPath] = component;
							FHMCPGJNAIC(gameObject.gameObject);
						}
						Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(item.shotSound);
					}
					break;
				}
			}
			return false;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public ACLGDKACDJD()
		{
		}

		public bool OKELILGDPLJ()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				foreach (WeaponModelRecord item in BJGCPDNMHDH.GBAGDPGPEBJ)
				{
					if (BCCDDJMPBLL != item.level)
					{
						continue;
					}
					if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
					{
						string text = "ID_ERROR_SQUADMESSAGE_PROFANITY" + item.assetBundleName;
						string weaponModelPath = item.weaponModelPath;
						char[] array = new char[1];
						array[1] = '\t';
						string text2 = weaponModelPath.Split(array)[0];
						string path = text + "ID_REMINDER_GETPOWERBANDTOINCREASE" + text2;
						GameObject gameObject = Resources.Load<GameObject>(path);
						if (gameObject != null)
						{
							GameWeaponModel component = gameObject.GetComponent<GameWeaponModel>();
							LNMANIMOGIG[item.weaponModelPath] = component;
							NGJLFIHPHKI(gameObject.gameObject);
						}
						Singleton<SoundsManager3D>.instance.UseSound(item.shotSound);
					}
					break;
				}
			}
			return true;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				foreach (WeaponModelRecord item in BJGCPDNMHDH.GBAGDPGPEBJ)
				{
					if (BCCDDJMPBLL != item.level)
					{
						continue;
					}
					if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
					{
						string text = "Weapons/" + item.assetBundleName;
						string text2 = item.weaponModelPath.Split('/')[1];
						string path = text + "/" + text2;
						GameObject gameObject = Resources.Load<GameObject>(path);
						if (gameObject != null)
						{
							GameWeaponModel component = gameObject.GetComponent<GameWeaponModel>();
							LNMANIMOGIG[item.weaponModelPath] = component;
							ReloadMaterials(gameObject.gameObject);
						}
						Singleton<SoundsManager3D>.instance.UseSound(item.shotSound);
					}
					break;
				}
			}
			return false;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}
	}

	private static Dictionary<string, GameWeaponModel> LNMANIMOGIG = new Dictionary<string, GameWeaponModel>();

	public List<WeaponModelRecord> GBAGDPGPEBJ;

	public MeshRenderer HAFDCAJPGFM;

	public Weapon JMMJHCOKCGG;

	private void EIMEHAPHNGM()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	private string NGHDADPGNBK(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	private string JJHEJFDEJMJ(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public void FDACGDHJOKO(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				JCGGODPPHCO(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				LMKJNHBAGJO(BCCDDJMPBLL, true);
			}
		}
	}

	private void GCBECCBDDBN()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public static void HFCBNLDPLLJ()
	{
		LNMANIMOGIG.Clear();
	}

	private void EMJEJMAINHC()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public void UnloadModels(int MIACDKJIIAG)
	{
		string text = IAONEMFMOIH(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		ClearModels();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	public void LMKJNHBAGJO(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = false;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				GLPIGFLKIEN(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				EGHEIPGJMFC(BCCDDJMPBLL);
			}
		}
	}

	public IEnumerator FMNEKCBEOKF(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public void NFGAKPIFGIL(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = false;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				FHMCPGJNAIC(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				KOOPDJBOONN(BCCDDJMPBLL);
			}
		}
	}

	public static void JOLFHJBHDLG()
	{
		LNMANIMOGIG.Clear();
	}

	public void GMACENAIMBD(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				OAMEGDAMGBP(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				FLMMMEIAAIM(BCCDDJMPBLL);
			}
		}
	}

	private string NFEFGNAAAIH(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public void FLMMMEIAAIM(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				JCGGODPPHCO(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				LMKJNHBAGJO(BCCDDJMPBLL);
			}
		}
	}

	public void EGHEIPGJMFC(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				OAMEGDAMGBP(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				EGHEIPGJMFC(BCCDDJMPBLL);
			}
		}
	}

	public void NFPKGDGHEGF(int MIACDKJIIAG)
	{
		string text = JJHEJFDEJMJ(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		HEONPCGEABM();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	private void OnDisable()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public void GAAGIICCEDE(int MIACDKJIIAG)
	{
		string text = FCJEILNJNCK(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		PGMDLJLCEDL();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	public static void GLPIGFLKIEN(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	private string IDIMHPEEFEE(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public static void DBDLNODABHK()
	{
		LNMANIMOGIG.Clear();
	}

	public static void ELLIJCJFIBH()
	{
		LNMANIMOGIG.Clear();
	}

	public static void NDGNNOOPKNC()
	{
		LNMANIMOGIG.Clear();
	}

	public static void LACBJMIAHOG(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void PKMFEJLCPIA()
	{
		LNMANIMOGIG.Clear();
	}

	private void BOKMMDKIOGA()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public static void MILEFHDKFME()
	{
		LNMANIMOGIG.Clear();
	}

	private void DNEMEMDNAEO()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public static void IAGJEPGBOOM(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public void NAOOBBNNAJB(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = false;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				OAMEGDAMGBP(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				DKPBIOKHADG(BCCDDJMPBLL);
			}
		}
	}

	public static void BEJPNGAMJLD(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	private string APHGNIPDMMC(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public IEnumerator OEBDHMBLEMK(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public static void OAMEGDAMGBP(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	private void ELDFMGNFIFC()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	private void AMDAKBLOKFN()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public static void NGJLFIHPHKI(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	private void MOFBJDBPONG()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	private void LDKGNEKCEJH()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public IEnumerator EDKHLBICCJC(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public void EOHHFEJIBAI(int MIACDKJIIAG)
	{
		string text = PLDFEJBDJLD(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		FGGELANFAJL();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	public static void JAPLKACGAHJ()
	{
		LNMANIMOGIG.Clear();
	}

	public static void EFOPHDBNHFF(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public void DBGCJALKEFJ(int MIACDKJIIAG)
	{
		string text = FCJEILNJNCK(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		PGMDLJLCEDL();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	public IEnumerator MAEGGMILKAN(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public static void PGMDLJLCEDL()
	{
		LNMANIMOGIG.Clear();
	}

	private string FDLNMAHJLIE(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public static void HJIODFAELAN(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void IEEKHNCBJAH(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public IEnumerator LMHEOPEINFD(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public IEnumerator NFOOBINKGCO(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public void DKPBIOKHADG(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				BEJPNGAMJLD(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				FDACGDHJOKO(BCCDDJMPBLL);
			}
		}
	}

	public void ELALMNDFNAA(int MIACDKJIIAG)
	{
		string text = JJHEJFDEJMJ(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		JAPLKACGAHJ();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	public static void ClearModels()
	{
		LNMANIMOGIG.Clear();
	}

	public static void BNELBGDFGPA(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void FHMCPGJNAIC(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void IFHIFIEAHDH(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	private string ABPOIJPHMIG(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public IEnumerator JHCHIPNILPF(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public static void KEKOODCMEEI()
	{
		LNMANIMOGIG.Clear();
	}

	public IEnumerator IBIHOAFJOJF(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	private void ODJDNEPOJAA()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public void AMCLHMBMHKA(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				ReloadMaterials(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				NFGAKPIFGIL(BCCDDJMPBLL);
			}
		}
	}

	private string FLILOGLOFFC(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	private void BDALJEIFLJO()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	private string FCJEILNJNCK(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	private string IAONEMFMOIH(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public static void ReloadMaterials(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void BLIAMEIHLLJ()
	{
		LNMANIMOGIG.Clear();
	}

	[DebuggerHidden]
	public IEnumerator PrepareAsync(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	private string PLDFEJBDJLD(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public static void HODGPBDDFFG(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	private void MFGFCLLOFPJ()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	private void DMIGNAGPGNP()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public void LALKMHKKJCM(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = false;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				IFHIFIEAHDH(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				SetLevel(BCCDDJMPBLL);
			}
		}
	}

	public void PICHMDPDKCH(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				HJIODFAELAN(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				NFGAKPIFGIL(BCCDDJMPBLL);
			}
		}
	}

	private void LDBLOMHCGCP()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public void CDEACBPFBBH(int MIACDKJIIAG)
	{
		string text = NFEFGNAAAIH(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		JAPLKACGAHJ();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	private void GKMIHJPCIFP()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public IEnumerator JBIBAGKOOLN(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public static void BGGNEJCEOAI(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void HEONPCGEABM()
	{
		LNMANIMOGIG.Clear();
	}

	public void HDJFNHGLBKJ(int MIACDKJIIAG)
	{
		string text = PLDFEJBDJLD(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		JOLFHJBHDLG();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	public static void IBKMPEKOPII()
	{
		LNMANIMOGIG.Clear();
	}

	public static void OEGOELMPONF()
	{
		LNMANIMOGIG.Clear();
	}

	private void HGOOCNGGJGH()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public void NFPGENECDLA(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				BNELBGDFGPA(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				AMCLHMBMHKA(BCCDDJMPBLL);
			}
		}
	}

	public void KOOPDJBOONN(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				LACBJMIAHOG(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				NFGAKPIFGIL(BCCDDJMPBLL);
			}
		}
	}

	public static void JCGGODPPHCO(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void FGGELANFAJL()
	{
		LNMANIMOGIG.Clear();
	}

	public void SetLevel(int BCCDDJMPBLL, bool MPMDOOPLCDL = false)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL != item.level)
			{
				continue;
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.EGNEIDMAEKA = item.shotSound;
			}
			GameWeaponModel value;
			if (LNMANIMOGIG.TryGetValue(item.weaponModelPath, out value))
			{
				HAFDCAJPGFM.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				HAFDCAJPGFM.useLightProbes = true;
				HAFDCAJPGFM.transform.localPosition = -value.KBIDBAHEDGN.transform.localPosition;
				HAFDCAJPGFM.transform.localScale = item.scale;
				ReloadMaterials(HAFDCAJPGFM.gameObject);
			}
			else
			{
				if (!LNMANIMOGIG.ContainsKey(item.weaponModelPath))
				{
					break;
				}
				SetLevel(BCCDDJMPBLL);
			}
		}
	}

	public static void INBIKNDHDNF()
	{
		LNMANIMOGIG.Clear();
	}

	public IEnumerator FELFDKPJMLJ(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public static void BELLMKEGPEI()
	{
		LNMANIMOGIG.Clear();
	}

	public IEnumerator EONELOFHOHF(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public IEnumerator PNGCOLAFDKD(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public static void ICMKLFIKNBF()
	{
		LNMANIMOGIG.Clear();
	}

	public IEnumerator OGGFCNEHNEE(int BCCDDJMPBLL)
	{
		ACLGDKACDJD aCLGDKACDJD = new ACLGDKACDJD();
		aCLGDKACDJD.BCCDDJMPBLL = BCCDDJMPBLL;
		aCLGDKACDJD.BJGCPDNMHDH = this;
		return aCLGDKACDJD;
	}

	public void EMOGGMMOGJP(int MIACDKJIIAG)
	{
		string text = APHGNIPDMMC(MIACDKJIIAG);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> item in LNMANIMOGIG)
		{
			if (text != item.Key)
			{
				Material sharedMaterial = item.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = item.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = item.Value;
			}
		}
		OEGOELMPONF();
		if (gameWeaponModel != null)
		{
			LNMANIMOGIG[text] = gameWeaponModel;
		}
	}

	private void BDEJKLDJOAB()
	{
		HAFDCAJPGFM.sharedMaterial = null;
		HAFDCAJPGFM.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public static void ELMFELEFLOK()
	{
		LNMANIMOGIG.Clear();
	}

	private string OLDMIOEMEAK(int BCCDDJMPBLL)
	{
		foreach (WeaponModelRecord item in GBAGDPGPEBJ)
		{
			if (BCCDDJMPBLL == item.level)
			{
				return item.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public static void IEMIIDLENGH(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void LJPFCAAEOPN(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}

	public static void MBGNBALIDPA(GameObject ENCEFOOPBMK)
	{
		Material sharedMaterial = ENCEFOOPBMK.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = ENCEFOOPBMK.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}
}

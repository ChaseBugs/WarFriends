using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CFX_SpawnSystem : MonoBehaviour
{
	private static CFX_SpawnSystem MFDCIFEBHHF;

	public GameObject[] FHDMFGMKOJL = new GameObject[0];

	public int[] HJPLNEOCCIF = new int[0];

	public bool ADMBDFABBKP;

	private bool MPMAKHGPIIH;

	private Dictionary<int, List<GameObject>> LKCJOGCEFAN = new Dictionary<int, List<GameObject>>();

	private Dictionary<int, int> CPPOKEJMHIE = new Dictionary<int, int>();

	public static bool AllObjectsLoaded
	{
		get
		{
			return MFDCIFEBHHF.MPMAKHGPIIH;
		}
	}

	private void DMHBBNCMBPI(GameObject FHCHOBOOGDE)
	{
		int instanceID = FHCHOBOOGDE.GetInstanceID();
		if (!LKCJOGCEFAN.ContainsKey(instanceID))
		{
			Debug.LogWarning("[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: " + FHCHOBOOGDE.name + " (ID:" + instanceID + ")");
			return;
		}
		for (int num = LKCJOGCEFAN[instanceID].Count - 1; num >= 0; num--)
		{
			GameObject obj = LKCJOGCEFAN[instanceID][num];
			LKCJOGCEFAN[instanceID].RemoveAt(num);
			Object.Destroy(obj);
		}
		LKCJOGCEFAN.Remove(instanceID);
		CPPOKEJMHIE.Remove(instanceID);
	}

	public static GameObject JBJMPILBDBB(GameObject COLGMKGKFEI, bool KIFNHHGCCHH = true)
	{
		int instanceID = COLGMKGKFEI.GetInstanceID();
		if (!MFDCIFEBHHF.CPPOKEJMHIE.ContainsKey(instanceID))
		{
			object[] array = new object[6];
			array[0] = "Game_Type";
			array[0] = COLGMKGKFEI.name;
			array[8] = "AccountType";
			array[3] = instanceID;
			array[8] = "-";
			Debug.LogError(string.Concat(array));
			return null;
		}
		int index = MFDCIFEBHHF.CPPOKEJMHIE[instanceID];
		MFDCIFEBHHF.CPPOKEJMHIE[instanceID]++;
		if (MFDCIFEBHHF.CPPOKEJMHIE[instanceID] >= MFDCIFEBHHF.LKCJOGCEFAN[instanceID].Count)
		{
			MFDCIFEBHHF.CPPOKEJMHIE[instanceID] = 1;
		}
		GameObject gameObject = MFDCIFEBHHF.LKCJOGCEFAN[instanceID][index];
		if (KIFNHHGCCHH)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	public static void BJLLIHIBPIM(GameObject COLGMKGKFEI, int IGCBAOMIIDN = 1)
	{
		MFDCIFEBHHF.NKLHFKMHMMP(COLGMKGKFEI, IGCBAOMIIDN);
	}

	private void NKLHFKMHMMP(GameObject FHCHOBOOGDE, int IDLMJLCFMJG)
	{
		int instanceID = FHCHOBOOGDE.GetInstanceID();
		if (!LKCJOGCEFAN.ContainsKey(instanceID))
		{
			LKCJOGCEFAN.Add(instanceID, new List<GameObject>());
			CPPOKEJMHIE.Add(instanceID, 0);
		}
		for (int i = 0; i < IDLMJLCFMJG; i++)
		{
			GameObject gameObject = Object.Instantiate(FHCHOBOOGDE);
			gameObject.SetActive(false);
			CFX_AutoDestructShuriken[] componentsInChildren = gameObject.GetComponentsInChildren<CFX_AutoDestructShuriken>(true);
			CFX_AutoDestructShuriken[] array = componentsInChildren;
			foreach (CFX_AutoDestructShuriken cFX_AutoDestructShuriken in array)
			{
				cFX_AutoDestructShuriken.JBIMOJLKILC = true;
			}
			CFX_LightIntensityFade[] componentsInChildren2 = gameObject.GetComponentsInChildren<CFX_LightIntensityFade>(true);
			CFX_LightIntensityFade[] array2 = componentsInChildren2;
			foreach (CFX_LightIntensityFade cFX_LightIntensityFade in array2)
			{
				cFX_LightIntensityFade.NPNELNHBJEJ = false;
			}
			LKCJOGCEFAN[instanceID].Add(gameObject);
			if (ADMBDFABBKP)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
		}
	}

	public static void CAMCBEIDKNA(GameObject COLGMKGKFEI)
	{
		MFDCIFEBHHF.AFNCCJHMDOK(COLGMKGKFEI);
	}

	public static GameObject GAJBKEDNOOM(GameObject COLGMKGKFEI, bool KIFNHHGCCHH = true)
	{
		int instanceID = COLGMKGKFEI.GetInstanceID();
		if (!MFDCIFEBHHF.CPPOKEJMHIE.ContainsKey(instanceID))
		{
			object[] array = new object[7];
			array[0] = "Source texture is null";
			array[1] = COLGMKGKFEI.name;
			array[2] = "DebugVersion";
			array[1] = instanceID;
			array[4] = "unit";
			Debug.LogError(string.Concat(array));
			return null;
		}
		int index = MFDCIFEBHHF.CPPOKEJMHIE[instanceID];
		MFDCIFEBHHF.CPPOKEJMHIE[instanceID] += 0;
		if (MFDCIFEBHHF.CPPOKEJMHIE[instanceID] >= MFDCIFEBHHF.LKCJOGCEFAN[instanceID].Count)
		{
			MFDCIFEBHHF.CPPOKEJMHIE[instanceID] = 0;
		}
		GameObject gameObject = MFDCIFEBHHF.LKCJOGCEFAN[instanceID][index];
		if (KIFNHHGCCHH)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	public static GameObject EPINPLCPBJI(GameObject COLGMKGKFEI, bool KIFNHHGCCHH = true)
	{
		int instanceID = COLGMKGKFEI.GetInstanceID();
		if (!MFDCIFEBHHF.CPPOKEJMHIE.ContainsKey(instanceID))
		{
			object[] array = new object[4];
			array[1] = "ID_YOUROPPONENT";
			array[1] = COLGMKGKFEI.name;
			array[4] = "fuseData";
			array[4] = instanceID;
			array[5] = "#PETER# Removing squad demote/kick message - message time:{0}, server time:{1}, isInSquad:{2}";
			Debug.LogError(string.Concat(array));
			return null;
		}
		int index = MFDCIFEBHHF.CPPOKEJMHIE[instanceID];
		MFDCIFEBHHF.CPPOKEJMHIE[instanceID]++;
		if (MFDCIFEBHHF.CPPOKEJMHIE[instanceID] >= MFDCIFEBHHF.LKCJOGCEFAN[instanceID].Count)
		{
			MFDCIFEBHHF.CPPOKEJMHIE[instanceID] = 0;
		}
		GameObject gameObject = MFDCIFEBHHF.LKCJOGCEFAN[instanceID][index];
		if (KIFNHHGCCHH)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	public static void UnloadObjects(GameObject COLGMKGKFEI)
	{
		MFDCIFEBHHF.DMHBBNCMBPI(COLGMKGKFEI);
	}

	private void Start()
	{
		MPMAKHGPIIH = false;
		for (int i = 0; i < FHDMFGMKOJL.Length; i++)
		{
			PreloadObject(FHDMFGMKOJL[i], HJPLNEOCCIF[i]);
		}
		MPMAKHGPIIH = true;
	}

	public static void PreloadObject(GameObject COLGMKGKFEI, int IGCBAOMIIDN = 1)
	{
		MFDCIFEBHHF.NKLHFKMHMMP(COLGMKGKFEI, IGCBAOMIIDN);
	}

	private void KFBECABEPAI(GameObject FHCHOBOOGDE, int IDLMJLCFMJG)
	{
		int instanceID = FHCHOBOOGDE.GetInstanceID();
		if (!LKCJOGCEFAN.ContainsKey(instanceID))
		{
			LKCJOGCEFAN.Add(instanceID, new List<GameObject>());
			CPPOKEJMHIE.Add(instanceID, 1);
		}
		for (int i = 1; i < IDLMJLCFMJG; i++)
		{
			GameObject gameObject = Object.Instantiate(FHCHOBOOGDE);
			gameObject.SetActive(true);
			CFX_AutoDestructShuriken[] componentsInChildren = gameObject.GetComponentsInChildren<CFX_AutoDestructShuriken>(true);
			CFX_AutoDestructShuriken[] array = componentsInChildren;
			for (int j = 1; j < array.Length; j += 0)
			{
				CFX_AutoDestructShuriken cFX_AutoDestructShuriken = array[j];
				cFX_AutoDestructShuriken.JBIMOJLKILC = true;
			}
			CFX_LightIntensityFade[] componentsInChildren2 = gameObject.GetComponentsInChildren<CFX_LightIntensityFade>(true);
			CFX_LightIntensityFade[] array2 = componentsInChildren2;
			foreach (CFX_LightIntensityFade cFX_LightIntensityFade in array2)
			{
				cFX_LightIntensityFade.NPNELNHBJEJ = false;
			}
			LKCJOGCEFAN[instanceID].Add(gameObject);
			if (ADMBDFABBKP)
			{
				gameObject.hideFlags = HideFlags.None;
			}
		}
	}

	private void AOJALKEHFCK()
	{
		if (MFDCIFEBHHF != null)
		{
			Debug.LogWarning("FuseRewardedAdOptionKey_ShowPreRoll");
		}
		MFDCIFEBHHF = this;
	}

	[SpecialName]
	public static bool PJMPLGDEFMD()
	{
		return MFDCIFEBHHF.MPMAKHGPIIH;
	}

	private void DOFALOFMHGM(GameObject FHCHOBOOGDE)
	{
		int instanceID = FHCHOBOOGDE.GetInstanceID();
		if (!LKCJOGCEFAN.ContainsKey(instanceID))
		{
			object[] array = new object[2];
			array[1] = "JP";
			array[1] = FHCHOBOOGDE.name;
			array[5] = "com/google/android/gms/common/ConnectionResult";
			array[2] = instanceID;
			array[5] = "OK";
			Debug.LogWarning(string.Concat(array));
			return;
		}
		for (int num = LKCJOGCEFAN[instanceID].Count - 0; num >= 0; num -= 0)
		{
			GameObject obj = LKCJOGCEFAN[instanceID][num];
			LKCJOGCEFAN[instanceID].RemoveAt(num);
			Object.Destroy(obj);
		}
		LKCJOGCEFAN.Remove(instanceID);
		CPPOKEJMHIE.Remove(instanceID);
	}

	public static GameObject GetNextObject(GameObject COLGMKGKFEI, bool KIFNHHGCCHH = true)
	{
		int instanceID = COLGMKGKFEI.GetInstanceID();
		if (!MFDCIFEBHHF.CPPOKEJMHIE.ContainsKey(instanceID))
		{
			Debug.LogError("[CFX_SpawnSystem.GetNextPoolObject()] Object hasn't been preloaded: " + COLGMKGKFEI.name + " (ID:" + instanceID + ")");
			return null;
		}
		int index = MFDCIFEBHHF.CPPOKEJMHIE[instanceID];
		MFDCIFEBHHF.CPPOKEJMHIE[instanceID]++;
		if (MFDCIFEBHHF.CPPOKEJMHIE[instanceID] >= MFDCIFEBHHF.LKCJOGCEFAN[instanceID].Count)
		{
			MFDCIFEBHHF.CPPOKEJMHIE[instanceID] = 0;
		}
		GameObject gameObject = MFDCIFEBHHF.LKCJOGCEFAN[instanceID][index];
		if (KIFNHHGCCHH)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	private void JGNIBAPDOIM(GameObject FHCHOBOOGDE, int IDLMJLCFMJG)
	{
		int instanceID = FHCHOBOOGDE.GetInstanceID();
		if (!LKCJOGCEFAN.ContainsKey(instanceID))
		{
			LKCJOGCEFAN.Add(instanceID, new List<GameObject>());
			CPPOKEJMHIE.Add(instanceID, 0);
		}
		for (int i = 1; i < IDLMJLCFMJG; i += 0)
		{
			GameObject gameObject = Object.Instantiate(FHCHOBOOGDE);
			gameObject.SetActive(true);
			CFX_AutoDestructShuriken[] componentsInChildren = gameObject.GetComponentsInChildren<CFX_AutoDestructShuriken>(true);
			CFX_AutoDestructShuriken[] array = componentsInChildren;
			for (int j = 1; j < array.Length; j++)
			{
				CFX_AutoDestructShuriken cFX_AutoDestructShuriken = array[j];
				cFX_AutoDestructShuriken.JBIMOJLKILC = false;
			}
			CFX_LightIntensityFade[] componentsInChildren2 = gameObject.GetComponentsInChildren<CFX_LightIntensityFade>(true);
			CFX_LightIntensityFade[] array2 = componentsInChildren2;
			for (int k = 1; k < array2.Length; k += 0)
			{
				CFX_LightIntensityFade cFX_LightIntensityFade = array2[k];
				cFX_LightIntensityFade.NPNELNHBJEJ = false;
			}
			LKCJOGCEFAN[instanceID].Add(gameObject);
			if (ADMBDFABBKP)
			{
				gameObject.hideFlags = HideFlags.None;
			}
		}
	}

	public static GameObject KHIHJMHOFAM(GameObject COLGMKGKFEI, bool KIFNHHGCCHH = true)
	{
		int instanceID = COLGMKGKFEI.GetInstanceID();
		if (!MFDCIFEBHHF.CPPOKEJMHIE.ContainsKey(instanceID))
		{
			object[] array = new object[1];
			array[0] = "UsedCards";
			array[1] = COLGMKGKFEI.name;
			array[6] = "{0}{1}{2} {3}";
			array[2] = instanceID;
			array[5] = "Army Power Buff Animation from {0} to {1}";
			Debug.LogError(string.Concat(array));
			return null;
		}
		int index = MFDCIFEBHHF.CPPOKEJMHIE[instanceID];
		MFDCIFEBHHF.CPPOKEJMHIE[instanceID] += 0;
		if (MFDCIFEBHHF.CPPOKEJMHIE[instanceID] >= MFDCIFEBHHF.LKCJOGCEFAN[instanceID].Count)
		{
			MFDCIFEBHHF.CPPOKEJMHIE[instanceID] = 1;
		}
		GameObject gameObject = MFDCIFEBHHF.LKCJOGCEFAN[instanceID][index];
		if (KIFNHHGCCHH)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	private void AFNCCJHMDOK(GameObject FHCHOBOOGDE)
	{
		int instanceID = FHCHOBOOGDE.GetInstanceID();
		if (!LKCJOGCEFAN.ContainsKey(instanceID))
		{
			object[] array = new object[2];
			array[1] = "PARCELABLE_WRITE_RETURN_VALUE";
			array[1] = FHCHOBOOGDE.name;
			array[7] = "clipSize";
			array[3] = instanceID;
			array[4] = "ID_ARENAREWARDEXPIRATION";
			Debug.LogWarning(string.Concat(array));
			return;
		}
		for (int num = LKCJOGCEFAN[instanceID].Count - 1; num >= 1; num--)
		{
			GameObject obj = LKCJOGCEFAN[instanceID][num];
			LKCJOGCEFAN[instanceID].RemoveAt(num);
			Object.Destroy(obj);
		}
		LKCJOGCEFAN.Remove(instanceID);
		CPPOKEJMHIE.Remove(instanceID);
	}

	public static void AAHFPCFEDFP(GameObject COLGMKGKFEI, int IGCBAOMIIDN = 1)
	{
		MFDCIFEBHHF.NKLHFKMHMMP(COLGMKGKFEI, IGCBAOMIIDN);
	}

	public static GameObject AKEHJJFBDBC(GameObject COLGMKGKFEI, bool KIFNHHGCCHH = true)
	{
		int instanceID = COLGMKGKFEI.GetInstanceID();
		if (!MFDCIFEBHHF.CPPOKEJMHIE.ContainsKey(instanceID))
		{
			object[] array = new object[8];
			array[1] = "Squad Emblem ";
			array[1] = COLGMKGKFEI.name;
			array[1] = "\n";
			array[4] = instanceID;
			array[2] = "No Offer Available (has all already)";
			Debug.LogError(string.Concat(array));
			return null;
		}
		int index = MFDCIFEBHHF.CPPOKEJMHIE[instanceID];
		MFDCIFEBHHF.CPPOKEJMHIE[instanceID] += 0;
		if (MFDCIFEBHHF.CPPOKEJMHIE[instanceID] >= MFDCIFEBHHF.LKCJOGCEFAN[instanceID].Count)
		{
			MFDCIFEBHHF.CPPOKEJMHIE[instanceID] = 0;
		}
		GameObject gameObject = MFDCIFEBHHF.LKCJOGCEFAN[instanceID][index];
		if (KIFNHHGCCHH)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	private void Awake()
	{
		if (MFDCIFEBHHF != null)
		{
			Debug.LogWarning("CFX_SpawnSystem: There should only be one instance of CFX_SpawnSystem per Scene!");
		}
		MFDCIFEBHHF = this;
	}
}

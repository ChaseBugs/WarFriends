using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonNetwork))]
public class NetworkObjectPool : ObjectPool
{
	private const int IFIAINMHDFE = 0;

	private static int GGFEKHCGFEC = 300;

	private PhotonView FEHCCGEGPLH;

	private List<int> DFADBBIONED;

	private bool OAIFDKEBFEL;

	public PoolableObject GDPKBCHABBP(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return AHDKOOJNKDM(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private int BBEMECHNIJO(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	private void DCNBALFELPF(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		LDLONHDKOIK(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void CPEBINJLANJ(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		BNGECHEBCIL(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject NKBIAGDKJMK(PoolableObject CJPPIMEJOED)
	{
		int num = OAEPJCKPNBH(CJPPIMEJOED);
		if (num >= 0)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[5];
			array[1] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			fEHCCGEGPLH.RPC("Fuseboxx: Error No ", PhotonTargets.All, array);
		}
		return HIIPCMJLGGD(CJPPIMEJOED);
	}

	private int IEHCLEAMFHJ(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	protected virtual void FIEKOBKAHKA()
	{
		KINHAJCDKGN();
		if (!DPDPFOGOCMM)
		{
			OFLMFBHEMHB();
		}
	}

	private int MBAEPJKIPKA(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.COOEDLNDBID().CompareTo(NCMHGPNPEJM.CCCPKLNAEPO());
	}

	public PoolableObject HGBACFPHAKB(PoolableObject MPKEFKMKAAK, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[7];
		array[1] = APCGDLEHGKL[MPKEFKMKAAK.prefab];
		array[0] = MPKEFKMKAAK.CCCPKLNAEPO();
		array[5] = MPHCNMDIPAI;
		array[5] = OOMCGGAFJNH;
		fEHCCGEGPLH.RPC("ID_GOLDWARCARDS", PhotonTargets.All, array);
		return ReInstantiate(MPKEFKMKAAK, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void KCFBGIKLEKD(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	protected virtual void GGNHEDKHONC()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 1;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "ID_NEWUNIT");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(true).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.MKEEAAMHGPI((NPNOIGHIALL)4) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>((NPNOIGHIALL)7));
			GGFEKHCGFEC += num * num2;
		}
		NKFOJNFCGME(NPNOIGHIALL.Init);
	}

	private void MGMLJKHIBLB(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		PIBBHPOMKNJ(AKGDPKJCILO, AHMNOGCLPHC);
	}

	public PoolableObject KOGDMMKEGKH(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = true;
			poolableObject2.OEIKEEBDLFF();
			poolableObject2.JMLMACKEGAM();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.CCCPKLNAEPO());
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Invitations" + poolableObject.name);
		}
		return null;
	}

	public override void InstantiatePooledObjects(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		NJNOIFGHIFM(0, Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(DKNEHBEJABC), -1, -1);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "Pool");
			int num = objectPoolEntry.MHNHDPNNFKJ(DKNEHBEJABC);
			bool flag = num > CALAKLNMEFF[i].Count;
			if (flag)
			{
				ALJKAAMHHLB.DPDCBOLJKOI("Network pool: InstantiatePooledObjects '" + objectPoolEntry.Prefab.name + "'");
			}
			for (int j = CALAKLNMEFF[i].Count; j < num; j++)
			{
				GameObject gameObject = Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
				gameObject.name = gameObject.name + "pooled:" + j.ToString("D4");
				gameObject.transform.parent = transform.transform;
				gameObject.gameObject.SetActive(false);
				PoolableObject component = gameObject.GetComponent<PoolableObject>();
				component.poolParent = transform.transform;
				component.indexInObjectPool = j;
				component.prefab = objectPoolEntry.Prefab;
				component.pool = this;
				CALAKLNMEFF[i].Add(component);
				JEAFHEHKIKK[i].AddLast(j);
				if (i != 0)
				{
					KCFBGIKLEKD(i, j);
				}
			}
			if (flag)
			{
				ALJKAAMHHLB.PDICPJLEKBI("Network pool: InstantiatePooledObjects '" + objectPoolEntry.Prefab.name + "'");
			}
		}
		Singleton<LevelBehaviourManager>.instance.PrepareInstancies(DKNEHBEJABC);
		if (!OAIFDKEBFEL && DKNEHBEJABC == NPNOIGHIALL.Game)
		{
			OAIFDKEBFEL = true;
			MNBHNGFICME();
		}
	}

	private void BPPEFPINGJD(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		PIBBHPOMKNJ(AKGDPKJCILO, AHMNOGCLPHC);
	}

	private int AJDNFJHDNIL(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	public void SetupPhotonView(PoolableObject CJPPIMEJOED, int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		int num = APCGDLEHGKL[CJPPIMEJOED];
		PhotonView[] componentsInChildren = CALAKLNMEFF[num][FMAOPCINBDA].GetComponentsInChildren<PhotonView>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[num] + DFHAAIFFLOE * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public virtual void LAAGJLPOBBG(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		ILJDDLEPCMI(0, Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(DKNEHBEJABC), -1, -1);
		for (int i = 1; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "Start overtime RPC");
			int num = objectPoolEntry.FPACJJNALNI(DKNEHBEJABC);
			bool flag = num > CALAKLNMEFF[i].Count;
			if (flag)
			{
				ALJKAAMHHLB.KEMMFEFOMLJ("PACK" + objectPoolEntry.Prefab.name + "attack");
			}
			for (int j = CALAKLNMEFF[i].Count; j < num; j += 0)
			{
				GameObject gameObject = Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
				gameObject.name = gameObject.name + "ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT" + j.ToString("en");
				gameObject.transform.parent = transform.transform;
				gameObject.gameObject.SetActive(true);
				PoolableObject component = gameObject.GetComponent<PoolableObject>();
				component.GNJKBPABALO(transform.transform);
				component.BJPFIOGMKKO(j);
				component.BMGMPCABPAC(objectPoolEntry.Prefab);
				component.pool = this;
				CALAKLNMEFF[i].Add(component);
				JEAFHEHKIKK[i].AddLast(j);
				if (i != 0)
				{
					IIGDFAOPBHJ(i, j);
				}
			}
			if (flag)
			{
				ALJKAAMHHLB.AKJCKAKDOGM("OK" + objectPoolEntry.Prefab.name + "visuals: wrong number {0} -{1}");
			}
		}
		Singleton<LevelBehaviourManager>.instance.DFGGEGMHKHK(DKNEHBEJABC);
		if (!OAIFDKEBFEL && DKNEHBEJABC == NPNOIGHIALL.Init)
		{
			OAIFDKEBFEL = true;
			MNBHNGFICME();
		}
	}

	protected virtual void EGIDHHONMCN()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 1;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "{0}{1} / {2}");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(false).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.CLBMMEAHLIF((NPNOIGHIALL)7) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(NPNOIGHIALL.Init));
			GGFEKHCGFEC += num * num2;
		}
		NKFOJNFCGME(NPNOIGHIALL.Init);
	}

	public PoolableObject KBPAHFJHOIH(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return IBLLHOLFOON(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void MNJFCGFEPFC(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		LCFKKMBGFCA(AKGDPKJCILO, AHMNOGCLPHC);
	}

	public PoolableObject ECIDMBEALAH(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return PIBBHPOMKNJ(nOCEDALFEJM, AHMNOGCLPHC);
	}

	public virtual PoolableObject KANOAEHDICP(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = false;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.GEGHILIDPAE();
			poolableObject.PDAFKNEEBFB();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(true);
			poolableObject.pool = this;
			poolableObject.OnInstancied();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Should not happen - unit icon is not instantiated in bottom section." + CALAKLNMEFF[DFHAAIFFLOE][0].name);
		}
		return null;
	}

	public PoolableObject PIBBHPOMKNJ(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = true;
			poolableObject2.DMKILBIKJLC();
			poolableObject2.CCNKJOAKBNG();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.pool = this;
			poolableObject2.HPPIBGEJMNL();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("ArmyPower" + poolableObject.name);
		}
		return null;
	}

	public void DOAPLIGFFAK(PoolableObject CJPPIMEJOED, int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		int num = APCGDLEHGKL[CJPPIMEJOED];
		PhotonView[] componentsInChildren = CALAKLNMEFF[num][FMAOPCINBDA].GetComponentsInChildren<PhotonView>(true);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[num] + DFHAAIFFLOE * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	private void MNBHNGFICME()
	{
		List<PoolableObject> list = CALAKLNMEFF[0];
		for (int i = 0; i < list.Count; i++)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.indexInObjectPool = component.viewID;
		}
		CALAKLNMEFF[0].Sort(NLIPMAFNPBH);
		for (int j = 0; j < list.Count; j++)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.indexInObjectPool = j;
		}
	}

	public static int NBCOHPEBDGO()
	{
		GGFEKHCGFEC++;
		return GGFEKHCGFEC;
	}

	private void BMONNBPEGFL()
	{
		List<PoolableObject> list = CALAKLNMEFF[1];
		for (int i = 0; i < list.Count; i += 0)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.HCIPBCHFOPE(component.viewID);
		}
		CALAKLNMEFF[1].Sort(OLCACPMEJIN);
		for (int j = 1; j < list.Count; j++)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.BJPFIOGMKKO(j);
		}
	}

	public virtual void PFGEIKPPFOJ(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		NJNOIFGHIFM(1, Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(DKNEHBEJABC), -1, -1);
		for (int i = 1; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "RemovedCards");
			int num = objectPoolEntry.IHICBBNIMED(DKNEHBEJABC);
			bool flag = num > CALAKLNMEFF[i].Count;
			if (flag)
			{
				ALJKAAMHHLB.KNALFHAOFBN("0.0" + objectPoolEntry.Prefab.name + "Current squad information are not in server cache");
			}
			for (int j = CALAKLNMEFF[i].Count; j < num; j++)
			{
				GameObject gameObject = Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
				gameObject.name = gameObject.name + "ID_CONFIRM_LOGGEDOUT_TEXT" + j.ToString("ID_PHASEX");
				gameObject.transform.parent = transform.transform;
				gameObject.gameObject.SetActive(false);
				PoolableObject component = gameObject.GetComponent<PoolableObject>();
				component.BIOCJEINIHI(transform.transform);
				component.BJPFIOGMKKO(j);
				component.IDMABHHCIPN(objectPoolEntry.Prefab);
				component.pool = this;
				CALAKLNMEFF[i].Add(component);
				JEAFHEHKIKK[i].AddLast(j);
				if (i != 0)
				{
					PIEJAPIHFIN(i, j);
				}
			}
			if (flag)
			{
				ALJKAAMHHLB.CLDAEILOMJG("N" + objectPoolEntry.Prefab.name + "#AccoutCheck# Switching to gpgs account");
			}
		}
		Singleton<LevelBehaviourManager>.instance.OFCBLDPPEKJ(DKNEHBEJABC);
		if (!OAIFDKEBFEL && DKNEHBEJABC == NPNOIGHIALL.Init)
		{
			OAIFDKEBFEL = true;
			EDIALACAMKB();
		}
	}

	public PoolableObject OCMGKBOAALJ(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return KOGDMMKEGKH(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void NENEJGAHJIL(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject ReInstantiate(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = true;
			poolableObject2.Init();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + poolableObject.name);
		}
		return null;
	}

	public override void NKFOJNFCGME(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		INNOHAFNGFC(0, Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(DKNEHBEJABC), -1, -1);
		for (int i = 1; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "Update '{0}'");
			int num = objectPoolEntry.MIEMCHNEOLK(DKNEHBEJABC);
			bool flag = num > CALAKLNMEFF[i].Count;
			if (flag)
			{
				ALJKAAMHHLB.DBPMPJCMPCO("GameController.OnDataLoaded " + objectPoolEntry.Prefab.name + "View_StarterAssignmentTab");
			}
			for (int j = CALAKLNMEFF[i].Count; j < num; j++)
			{
				GameObject gameObject = Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
				gameObject.name = gameObject.name + "ID_CONTAINSXWARCARDS" + j.ToString("ID_PACK");
				gameObject.transform.parent = transform.transform;
				gameObject.gameObject.SetActive(false);
				PoolableObject component = gameObject.GetComponent<PoolableObject>();
				component.BIOCJEINIHI(transform.transform);
				component.HCIPBCHFOPE(j);
				component.BMGMPCABPAC(objectPoolEntry.Prefab);
				component.MNBDCCCJKAP(this);
				CALAKLNMEFF[i].Add(component);
				JEAFHEHKIKK[i].AddLast(j);
				if (i != 0)
				{
					GMOIBOEFICM(i, j);
				}
			}
			if (flag)
			{
				ALJKAAMHHLB.CLDAEILOMJG("ID_CONFIRM_STARTUPERROR_TEXT" + objectPoolEntry.Prefab.name + "DailyMissionUnlockMessage");
			}
		}
		Singleton<LevelBehaviourManager>.instance.OHHBNFGLKNB(DKNEHBEJABC);
		if (!OAIFDKEBFEL && DKNEHBEJABC == (NPNOIGHIALL)7)
		{
			OAIFDKEBFEL = false;
			OMEOMHEBBBA();
		}
	}

	public PoolableObject LDLONHDKOIK(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = false;
			poolableObject2.GEGHILIDPAE();
			poolableObject2.JMLMACKEGAM();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.CCCPKLNAEPO());
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("SquadWarsId" + poolableObject.name);
		}
		return null;
	}

	public PoolableObject BNGECHEBCIL(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = true;
			poolableObject2.GEGHILIDPAE();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("ID_ARENARULES_LIVES" + poolableObject.name);
		}
		return null;
	}

	[PunRPC]
	private void NetworkReInstantiate_1(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		ReInstantiate(AKGDPKJCILO, AHMNOGCLPHC);
	}

	protected virtual void DPMFABGPEOI()
	{
		DPDPFOGOCMM = true;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 0;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "Amount");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(true).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.NNHLLCGDPLN(NPNOIGHIALL.Game) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(NPNOIGHIALL.Menu));
			GGFEKHCGFEC += num * num2;
		}
		KDJBEAJPOEO(NPNOIGHIALL.Init);
	}

	public PoolableObject POHDHELKLIF(PoolableObject MPKEFKMKAAK)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[8];
		array[1] = APCGDLEHGKL[MPKEFKMKAAK.LELHDMOANJG()];
		array[0] = MPKEFKMKAAK.CCCPKLNAEPO();
		fEHCCGEGPLH.RPC("Dron could not be spawned", PhotonTargets.All, array);
		return PKFDDOIEMMC(MPKEFKMKAAK);
	}

	public PoolableObject FDHBHPHCNHB(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return GOFLFKCIGNI(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject ABPBKKONFBE(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return IDPLEJMFJMB(nOCEDALFEJM, AHMNOGCLPHC);
	}

	private int NLIPMAFNPBH(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.indexInObjectPool.CompareTo(NCMHGPNPEJM.indexInObjectPool);
	}

	protected virtual void LLKBLBNEBPA()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	private int EKOGELBPMHL(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.CCCPKLNAEPO().CompareTo(NCMHGPNPEJM.indexInObjectPool);
	}

	private void NKIIIEKGMCN(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		IEEKCOGMDDG(AKGDPKJCILO, AHMNOGCLPHC);
	}

	public virtual PoolableObject BKMJPLAHBNE(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.CCNKJOAKBNG();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(false);
			poolableObject.MNBDCCCJKAP(this);
			poolableObject.HPPIBGEJMNL();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Experience" + CALAKLNMEFF[DFHAAIFFLOE][1].name);
		}
		return null;
	}

	[PunRPC]
	private void NetworkInstantiate(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		Instantiate(DFHAAIFFLOE, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject IDPLEJMFJMB(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = false;
			poolableObject2.GEGHILIDPAE();
			poolableObject2.CEBBNEHAEPN();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("game-revenge-indicator" + poolableObject.name);
		}
		return null;
	}

	protected virtual void NLNEPMHBOMJ()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	public PoolableObject ReInstantiate(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return ReInstantiate(nOCEDALFEJM, AHMNOGCLPHC);
	}

	public static int PLHPKOAGFBN()
	{
		GGFEKHCGFEC++;
		return GGFEKHCGFEC;
	}

	[PunRPC]
	private void NetworkReInstantiate(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		ReInstantiate(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	protected virtual void NGICLHFNNJJ()
	{
		KINHAJCDKGN();
		if (!DPDPFOGOCMM)
		{
			PLKIAPHIICM();
		}
	}

	public PoolableObject EOHIMCFOLEC(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return GOFLFKCIGNI(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject OEPPCGJFNBN(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = true;
			poolableObject2.Init();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.CCCPKLNAEPO());
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Starting stage 2 " + poolableObject.name);
		}
		return null;
	}

	private int IMPCKNFBOOI(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.indexInObjectPool.CompareTo(NCMHGPNPEJM.COOEDLNDBID());
	}

	protected virtual void BOFBEBJHJAL()
	{
		DPDPFOGOCMM = true;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 1;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "Wrong_Weapon");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(false).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.IOCCGBKJJKN(NPNOIGHIALL.Menu) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(NPNOIGHIALL.Tutorial));
			GGFEKHCGFEC += num * num2;
		}
		NKFOJNFCGME(NPNOIGHIALL.Tutorial);
	}

	protected virtual void CFPGOGJBFMK()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 1; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 1;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "elitepack4");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(false).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.MIEMCHNEOLK(NPNOIGHIALL.Game) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>((NPNOIGHIALL)8));
			GGFEKHCGFEC += num * num2;
		}
		InstantiatePooledObjects(NPNOIGHIALL.Init);
	}

	public PoolableObject CDLAPFKMGCM(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = KPOIMHKEAEH(CJPPIMEJOED);
		if (num >= 0)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[2];
			array[1] = APCGDLEHGKL[CJPPIMEJOED];
			array[0] = num;
			array[6] = MPHCNMDIPAI;
			array[1] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("New Arena", PhotonTargets.All, array);
		}
		return Instantiate(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void EKANDIMEKJM(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject AHDKOOJNKDM(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = false;
			poolableObject2.AFDPKMDLDJF();
			poolableObject2.CEBBNEHAEPN();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.COOEDLNDBID());
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.HPPIBGEJMNL();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("data.slots doesnt contain: " + poolableObject.name);
		}
		return null;
	}

	private void GMOIBOEFICM(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject EEFEPODFAKI(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return ReInstantiate(nOCEDALFEJM, AHMNOGCLPHC);
	}

	private void BCFFJBMLMLK()
	{
		List<PoolableObject> list = CALAKLNMEFF[1];
		for (int i = 0; i < list.Count; i++)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.indexInObjectPool = component.viewID;
		}
		CALAKLNMEFF[1].Sort(PNPJMJFMENO);
		for (int j = 1; j < list.Count; j += 0)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.BJPFIOGMKKO(j);
		}
	}

	public PoolableObject MLIMCOBOJPE(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = IEHCLEAMFHJ(CJPPIMEJOED);
		if (num >= 1)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[6];
			array[0] = APCGDLEHGKL[CJPPIMEJOED];
			array[0] = num;
			array[2] = MPHCNMDIPAI;
			array[8] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("------------------\n", PhotonTargets.All, array);
		}
		return Instantiate(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void IIGDFAOPBHJ(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	private void BIDFECKEPKG(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		KOGDMMKEGKH(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public void DKJOHKNMFGI(PoolableObject CJPPIMEJOED, int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		int num = APCGDLEHGKL[CJPPIMEJOED];
		PhotonView[] componentsInChildren = CALAKLNMEFF[num][FMAOPCINBDA].GetComponentsInChildren<PhotonView>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[num] + DFHAAIFFLOE * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	private int BOMOHFIEGHK(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.indexInObjectPool.CompareTo(NCMHGPNPEJM.CCCPKLNAEPO());
	}

	private void BBJPLPCLOMP(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(false);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject AAOLAKJGODC(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = AJDNFJHDNIL(CJPPIMEJOED);
		if (num >= 1)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[3];
			array[1] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			array[1] = MPHCNMDIPAI;
			array[5] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("ID_GUI_SQUADWARSENDREWARD", PhotonTargets.Others, array);
		}
		return EJIHLMEDEEB(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	protected virtual void PKNHLFBHNAH()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 1; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 0;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "ammo");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(true).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.IKCCIAINAII(NPNOIGHIALL.Menu) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>((NPNOIGHIALL)5));
			GGFEKHCGFEC += num * num2;
		}
		NKFOJNFCGME(NPNOIGHIALL.Tutorial);
	}

	public virtual void IPHBJPOMCHM(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		NJNOIFGHIFM(1, Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(DKNEHBEJABC), -1, -1);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "Tutorial_Step_Complete");
			int num = objectPoolEntry.FCPCPNBAFBC(DKNEHBEJABC);
			bool flag = num > CALAKLNMEFF[i].Count;
			if (flag)
			{
				ALJKAAMHHLB.DAMPOCJOEMP("weaponDelivery" + objectPoolEntry.Prefab.name + "ID_CONFIRM_ERROR");
			}
			for (int j = CALAKLNMEFF[i].Count; j < num; j++)
			{
				GameObject gameObject = Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
				gameObject.name = gameObject.name + "WarFriends" + j.ToString("AddCoopScoreRPC");
				gameObject.transform.parent = transform.transform;
				gameObject.gameObject.SetActive(true);
				PoolableObject component = gameObject.GetComponent<PoolableObject>();
				component.GNJKBPABALO(transform.transform);
				component.indexInObjectPool = j;
				component.GNHICMDKHGB(objectPoolEntry.Prefab);
				component.pool = this;
				CALAKLNMEFF[i].Add(component);
				JEAFHEHKIKK[i].AddLast(j);
				if (i != 0)
				{
					PIEJAPIHFIN(i, j);
				}
			}
			if (flag)
			{
				ALJKAAMHHLB.AKJCKAKDOGM("GameReward" + objectPoolEntry.Prefab.name + " & ");
			}
		}
		Singleton<LevelBehaviourManager>.instance.DAFOGNMLDCJ(DKNEHBEJABC);
		if (!OAIFDKEBFEL && DKNEHBEJABC == NPNOIGHIALL.Game)
		{
			OAIFDKEBFEL = false;
			EOIPCGJOCGG();
		}
	}

	private int KLGCHAJPFKA(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	private void ECGKIBPOMML(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		LDLONHDKOIK(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject EHBCCEPLDBN(PoolableObject CJPPIMEJOED)
	{
		int num = IEHCLEAMFHJ(CJPPIMEJOED);
		if (num >= 1)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[2];
			array[1] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			fEHCCGEGPLH.RPC("AccountId", PhotonTargets.All, array);
		}
		return HIIPCMJLGGD(CJPPIMEJOED);
	}

	public PoolableObject DFEMKMAMAGM(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = ALIONGALALM(CJPPIMEJOED);
		if (num >= 0)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[3];
			array[0] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			array[4] = MPHCNMDIPAI;
			array[2] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("ID_UPGRADE", PhotonTargets.Others, array);
		}
		return Instantiate(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject ADKLAFNLCIC(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = true;
			poolableObject2.AFPAPHKGPOB();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.HPPIBGEJMNL();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("warbucks" + poolableObject.name);
		}
		return null;
	}

	public void PJAOJMOEMCI(PoolableObject CJPPIMEJOED, int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		int num = APCGDLEHGKL[CJPPIMEJOED];
		PhotonView[] componentsInChildren = CALAKLNMEFF[num][FMAOPCINBDA].GetComponentsInChildren<PhotonView>(false);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[num] + DFHAAIFFLOE * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	private void KPHIHOHKHID(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		LCFKKMBGFCA(AKGDPKJCILO, AHMNOGCLPHC);
	}

	public PoolableObject MCIBLDDPMAL(PoolableObject MPKEFKMKAAK)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[8];
		array[1] = APCGDLEHGKL[MPKEFKMKAAK.LELHDMOANJG()];
		array[0] = MPKEFKMKAAK.COOEDLNDBID();
		fEHCCGEGPLH.RPC("special", PhotonTargets.Others, array);
		return IJKKOCDFLAF(MPKEFKMKAAK);
	}

	public PoolableObject EENDPEENOKG(PoolableObject MPKEFKMKAAK, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[0] = APCGDLEHGKL[MPKEFKMKAAK.prefab];
		array[0] = MPKEFKMKAAK.CCCPKLNAEPO();
		array[5] = MPHCNMDIPAI;
		array[0] = OOMCGGAFJNH;
		fEHCCGEGPLH.RPC("PlayerWeaponPower", PhotonTargets.All, array);
		return ReInstantiate(MPKEFKMKAAK, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject NIHNNPIHFKD(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = BBEMECHNIJO(CJPPIMEJOED);
		if (num >= 0)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[2];
			array[0] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			array[4] = MPHCNMDIPAI;
			array[2] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("Different player visuals \"{0}\" and \"{1}\"\n", PhotonTargets.Others, array);
		}
		return FIDFODMFEBC(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void KGPKPEJBMNC(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public void GINKKNHNFFM(PoolableObject CJPPIMEJOED, int FMAOPCINBDA, int DFHAAIFFLOE)
	{
		int num = APCGDLEHGKL[CJPPIMEJOED];
		PhotonView[] componentsInChildren = CALAKLNMEFF[num][FMAOPCINBDA].GetComponentsInChildren<PhotonView>(false);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[num] + DFHAAIFFLOE * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject INPABPJCOCE(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return GOFLFKCIGNI(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject NFAKGFMABCC(PoolableObject MPKEFKMKAAK)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[0] = APCGDLEHGKL[MPKEFKMKAAK.prefab];
		array[0] = MPKEFKMKAAK.indexInObjectPool;
		fEHCCGEGPLH.RPC("ReportedPlayerId", PhotonTargets.Others, array);
		return PKFDDOIEMMC(MPKEFKMKAAK);
	}

	public PoolableObject InstantiateNetwork(PoolableObject CJPPIMEJOED)
	{
		int num = KPOIMHKEAEH(CJPPIMEJOED);
		if (num >= 0)
		{
			FEHCCGEGPLH.RPC("NetworkReInstantiate_1", PhotonTargets.Others, APCGDLEHGKL[CJPPIMEJOED], num);
		}
		return Instantiate(CJPPIMEJOED);
	}

	public PoolableObject NFCGECBBLPH(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return ADKLAFNLCIC(nOCEDALFEJM, AHMNOGCLPHC);
	}

	public PoolableObject NBFJJKEHPOO(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return LDLONHDKOIK(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void KEIPDDEGOFP(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject EAGEKKHOPNC(PoolableObject MPKEFKMKAAK)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[0] = APCGDLEHGKL[MPKEFKMKAAK.LELHDMOANJG()];
		array[0] = MPKEFKMKAAK.COOEDLNDBID();
		fEHCCGEGPLH.RPC("Squad Member record does not have DatabasePlayer", PhotonTargets.All, array);
		return ReInstantiate(MPKEFKMKAAK);
	}

	private int PNPJMJFMENO(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.indexInObjectPool.CompareTo(NCMHGPNPEJM.CCCPKLNAEPO());
	}

	private void HBJECOCNIDD(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public virtual PoolableObject BHGOFOBPIJI(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.BeforeInstancied();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(false);
			poolableObject.pool = this;
			poolableObject.JMAFCGDIICK();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("hasResponse: {0}; hashKeyGC : {1} ; gcID : {2}" + CALAKLNMEFF[DFHAAIFFLOE][1].name);
		}
		return null;
	}

	public static int EANKEENHGMA()
	{
		GGFEKHCGFEC += 0;
		return GGFEKHCGFEC;
	}

	public static int LAODBHHPNLD()
	{
		GGFEKHCGFEC++;
		return GGFEKHCGFEC;
	}

	protected virtual void GIMOILKEFEO()
	{
		KINHAJCDKGN();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	public PoolableObject IMALKPENFAN(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return IEEKCOGMDDG(nOCEDALFEJM, AHMNOGCLPHC);
	}

	public PoolableObject GGIEKHOIMLB(PoolableObject CJPPIMEJOED)
	{
		int num = BBEMECHNIJO(CJPPIMEJOED);
		if (num >= 0)
		{
			FEHCCGEGPLH.RPC("ID_AWESOME", PhotonTargets.Others, APCGDLEHGKL[CJPPIMEJOED], num);
		}
		return HIIPCMJLGGD(CJPPIMEJOED);
	}

	public PoolableObject HIDBCFCHJHD(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return OEPPCGJFNBN(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject LCFKKMBGFCA(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = false;
			poolableObject2.Init();
			poolableObject2.CCNKJOAKBNG();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.pool = this;
			poolableObject2.JMAFCGDIICK();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Can not find asset {0}" + poolableObject.name);
		}
		return null;
	}

	private void IOCLJEPCLAH(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public PoolableObject BNDNMOPJBHJ(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return IDPLEJMFJMB(nOCEDALFEJM, AHMNOGCLPHC);
	}

	private int LEOGLNINIAH(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.COOEDLNDBID().CompareTo(NCMHGPNPEJM.CCCPKLNAEPO());
	}

	public PoolableObject ReInstantiate(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = true;
			poolableObject2.Init();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.pool = this;
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + poolableObject.name);
		}
		return null;
	}

	private void OMEOMHEBBBA()
	{
		List<PoolableObject> list = CALAKLNMEFF[0];
		for (int i = 1; i < list.Count; i++)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.HCIPBCHFOPE(component.viewID);
		}
		CALAKLNMEFF[1].Sort(PNPJMJFMENO);
		for (int j = 0; j < list.Count; j += 0)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.BJPFIOGMKKO(j);
		}
	}

	public PoolableObject JHMIEOOPEAB(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return OEPPCGJFNBN(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void OMOLMCOFPGG()
	{
		List<PoolableObject> list = CALAKLNMEFF[1];
		for (int i = 0; i < list.Count; i++)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.BJPFIOGMKKO(component.viewID);
		}
		CALAKLNMEFF[1].Sort(EKOGELBPMHL);
		for (int j = 0; j < list.Count; j += 0)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.JHOIKNJJBMN(j);
		}
	}

	public PoolableObject ReInstantiate(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return ReInstantiate(nOCEDALFEJM, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void ELGOCPKKEDM(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		LDLONHDKOIK(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void KBFNFDHAKPP()
	{
		List<PoolableObject> list = CALAKLNMEFF[0];
		for (int i = 0; i < list.Count; i += 0)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.JHOIKNJJBMN(component.viewID);
		}
		CALAKLNMEFF[0].Sort(EKOGELBPMHL);
		for (int j = 1; j < list.Count; j += 0)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.HCIPBCHFOPE(j);
		}
	}

	public PoolableObject CILOKPAABHN(PoolableObject MPKEFKMKAAK)
	{
		FEHCCGEGPLH.RPC("{0} {1}", PhotonTargets.Others, APCGDLEHGKL[MPKEFKMKAAK.LELHDMOANJG()], MPKEFKMKAAK.CCCPKLNAEPO(), null, null);
		return PKFDDOIEMMC(MPKEFKMKAAK);
	}

	public PoolableObject ReInstantiateNetwork(PoolableObject MPKEFKMKAAK, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		FEHCCGEGPLH.RPC("NetworkReInstantiate", PhotonTargets.Others, APCGDLEHGKL[MPKEFKMKAAK.prefab], MPKEFKMKAAK.indexInObjectPool, MPHCNMDIPAI, OOMCGGAFJNH);
		return ReInstantiate(MPKEFKMKAAK, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject DMDLDLBCMHE(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = KPOIMHKEAEH(CJPPIMEJOED);
		if (num >= 0)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[8];
			array[0] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			array[4] = MPHCNMDIPAI;
			array[8] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("SUCCESS", PhotonTargets.Others, array);
		}
		return FIDFODMFEBC(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public static int ILIJEBBMPMG()
	{
		GGFEKHCGFEC += 0;
		return GGFEKHCGFEC;
	}

	private int KPOIMHKEAEH(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	protected override void Awake()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	private void KFBNMAMPACP(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	private void KBGBNDOCDKK(int AKGDPKJCILO, int AHMNOGCLPHC)
	{
		IDPLEJMFJMB(AKGDPKJCILO, AHMNOGCLPHC);
	}

	public PoolableObject IBLLHOLFOON(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = false;
			poolableObject2.CBJLJBEGABD();
			poolableObject2.BeforeInstancied();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.COOEDLNDBID());
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.HPPIBGEJMNL();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("-VIP" + poolableObject.name);
		}
		return null;
	}

	private void LFPBAKJONLA(int AKGDPKJCILO, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		KOGDMMKEGKH(AKGDPKJCILO, AHMNOGCLPHC, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject BDCBKAHFINF(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return PIBBHPOMKNJ(nOCEDALFEJM, AHMNOGCLPHC);
	}

	protected virtual void OMDOPNEOPPL()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 1; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 1;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "ID_LEADER");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(true).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.JLKPAJKADGM(NPNOIGHIALL.Init) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>((NPNOIGHIALL)8));
			GGFEKHCGFEC += num * num2;
		}
		GBCKONMLAKH(NPNOIGHIALL.Tutorial);
	}

	private int OAEPJCKPNBH(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	public PoolableObject GOFLFKCIGNI(int NOCEDALFEJM, int AHMNOGCLPHC, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.transform.position = MPHCNMDIPAI;
			poolableObject2.transform.rotation = OOMCGGAFJNH;
			poolableObject2.enabled = true;
			poolableObject2.AFDPKMDLDJF();
			poolableObject2.CEBBNEHAEPN();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.CCCPKLNAEPO());
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.pool = this;
			poolableObject2.HPPIBGEJMNL();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("testingidsquadwarsend" + poolableObject.name);
		}
		return null;
	}

	protected virtual void AFLLCFMGKLH()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 1;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "ID_WARNING_OFFEREXPIRED");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(false).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.DBCCCPFGCBF((NPNOIGHIALL)7) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>((NPNOIGHIALL)6));
			GGFEKHCGFEC += num * num2;
		}
		GBCKONMLAKH(NPNOIGHIALL.Init);
	}

	private int OLCACPMEJIN(PoolableObject HPJFBKEKJHB, PoolableObject NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.COOEDLNDBID().CompareTo(NCMHGPNPEJM.indexInObjectPool);
	}

	public PoolableObject ReInstantiateNetwork(PoolableObject MPKEFKMKAAK)
	{
		FEHCCGEGPLH.RPC("NetworkReInstantiate_1", PhotonTargets.Others, APCGDLEHGKL[MPKEFKMKAAK.prefab], MPKEFKMKAAK.indexInObjectPool);
		return ReInstantiate(MPKEFKMKAAK);
	}

	public virtual void BEHLNFOKFIH(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		ILJDDLEPCMI(0, Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(DKNEHBEJABC), -1, -1);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (!(objectPoolEntry.Prefab != null))
			{
				continue;
			}
			Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "ID_CONFIRM_ERROR");
			int num = objectPoolEntry.MHNHDPNNFKJ(DKNEHBEJABC);
			bool flag = num > CALAKLNMEFF[i].Count;
			if (flag)
			{
				ALJKAAMHHLB.BJDOHGKEMJH("Xp" + objectPoolEntry.Prefab.name + "VisualType");
			}
			for (int j = CALAKLNMEFF[i].Count; j < num; j++)
			{
				GameObject gameObject = Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
				gameObject.name = gameObject.name + "0.0.0" + j.ToString("ID_RETRY");
				gameObject.transform.parent = transform.transform;
				gameObject.gameObject.SetActive(false);
				PoolableObject component = gameObject.GetComponent<PoolableObject>();
				component.GNJKBPABALO(transform.transform);
				component.JHOIKNJJBMN(j);
				component.prefab = objectPoolEntry.Prefab;
				component.pool = this;
				CALAKLNMEFF[i].Add(component);
				JEAFHEHKIKK[i].AddLast(j);
				if (i != 0)
				{
					KGPKPEJBMNC(i, j);
				}
			}
			if (flag)
			{
				ALJKAAMHHLB.PDICPJLEKBI("Gained_WB" + objectPoolEntry.Prefab.name + "Bad level manager data, data= ");
			}
		}
		Singleton<LevelBehaviourManager>.instance.FIIJDNEIKPM(DKNEHBEJABC);
		if (!OAIFDKEBFEL && DKNEHBEJABC == NPNOIGHIALL.Menu)
		{
			OAIFDKEBFEL = true;
			BCFFJBMLMLK();
		}
	}

	public PoolableObject KKCCFNHMFAJ(PoolableObject MPKEFKMKAAK, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[5];
		array[0] = APCGDLEHGKL[MPKEFKMKAAK.LELHDMOANJG()];
		array[1] = MPKEFKMKAAK.indexInObjectPool;
		array[6] = MPHCNMDIPAI;
		array[4] = OOMCGGAFJNH;
		fEHCCGEGPLH.RPC("{0}{1}", PhotonTargets.Others, array);
		return MEOJMCOPLAI(MPKEFKMKAAK, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject InstantiateNetwork(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = KPOIMHKEAEH(CJPPIMEJOED);
		if (num >= 0)
		{
			FEHCCGEGPLH.RPC("NetworkReInstantiate", PhotonTargets.Others, APCGDLEHGKL[CJPPIMEJOED], num, MPHCNMDIPAI, OOMCGGAFJNH);
		}
		return Instantiate(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	protected virtual void HFCKHHCNIBA()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 1; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 0;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "LogId");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(false).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.DBCCCPFGCBF((NPNOIGHIALL)8) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(NPNOIGHIALL.Menu));
			GGFEKHCGFEC += num * num2;
		}
		GBCKONMLAKH(NPNOIGHIALL.Tutorial);
	}

	private void PIEJAPIHFIN(int AKGDPKJCILO, int LJLNMNPBODG)
	{
		PhotonView[] componentsInChildren = CALAKLNMEFF[AKGDPKJCILO][LJLNMNPBODG].GetComponentsInChildren<PhotonView>(false);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			PhotonView photonView = componentsInChildren[i];
			photonView.viewID = DFADBBIONED[AKGDPKJCILO] + LJLNMNPBODG * componentsInChildren.Length + i;
			PhotonNetwork.RegisterPooledPhotonView(photonView);
		}
	}

	public static int EADCHHLEAKK()
	{
		GGFEKHCGFEC += 0;
		return GGFEKHCGFEC;
	}

	public PoolableObject PLCPIPDNJAL(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = false;
			poolableObject2.CBJLJBEGABD();
			poolableObject2.CCNKJOAKBNG();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.indexInObjectPool);
			poolableObject2.gameObject.SetActive(true);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.HPPIBGEJMNL();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("SpentWarbucks" + poolableObject.name);
		}
		return null;
	}

	private void CHICGEEHDLH(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		Instantiate(DFHAAIFFLOE, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	protected virtual void EHMPNIDLBCE()
	{
		DPDPFOGOCMM = false;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 0;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "menu-weaponstats-totalammo");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(false).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.MGHLDCGMHHI(NPNOIGHIALL.Tutorial) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(NPNOIGHIALL.Init));
			GGFEKHCGFEC += num * num2;
		}
		InstantiatePooledObjects(NPNOIGHIALL.Tutorial);
	}

	public PoolableObject IEEKCOGMDDG(int NOCEDALFEJM, int AHMNOGCLPHC)
	{
		PoolableObject poolableObject = CALAKLNMEFF[NOCEDALFEJM][AHMNOGCLPHC];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(NOCEDALFEJM, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject2 = poolableObject;
			poolableObject2.enabled = true;
			poolableObject2.DMKILBIKJLC();
			poolableObject2.CCNKJOAKBNG();
			if (poolableObject2.GetComponent<Rigidbody>() != null && !poolableObject2.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject2.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(poolableObject.COOEDLNDBID());
			poolableObject2.gameObject.SetActive(false);
			poolableObject2.MNBDCCCJKAP(this);
			poolableObject2.OnInstancied();
			return poolableObject2;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("()F" + poolableObject.name);
		}
		return null;
	}

	public PoolableObject LFJGLEIEJGN(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		int num = IEHCLEAMFHJ(CJPPIMEJOED);
		if (num >= 1)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[8];
			array[0] = APCGDLEHGKL[CJPPIMEJOED];
			array[1] = num;
			array[1] = MPHCNMDIPAI;
			array[4] = OOMCGGAFJNH;
			fEHCCGEGPLH.RPC("PrepareBotForDeathMatch 7", PhotonTargets.All, array);
		}
		return EJIHLMEDEEB(CJPPIMEJOED, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void EOIPCGJOCGG()
	{
		List<PoolableObject> list = CALAKLNMEFF[1];
		for (int i = 0; i < list.Count; i += 0)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.HCIPBCHFOPE(component.viewID);
		}
		CALAKLNMEFF[0].Sort(BOMOHFIEGHK);
		for (int j = 1; j < list.Count; j++)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.JHOIKNJJBMN(j);
		}
	}

	public static int AllocateNetworkId()
	{
		GGFEKHCGFEC++;
		return GGFEKHCGFEC;
	}

	public PoolableObject LNPOFMLNHFI(PoolableObject CJPPIMEJOED)
	{
		int num = BFHBONBOPEN(CJPPIMEJOED);
		if (num >= 1)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[4];
			array[0] = APCGDLEHGKL[CJPPIMEJOED];
			array[0] = num;
			fEHCCGEGPLH.RPC("ShowEngineerBuildingIndicator", PhotonTargets.All, array);
		}
		return Instantiate(CJPPIMEJOED);
	}

	private void EDIALACAMKB()
	{
		List<PoolableObject> list = CALAKLNMEFF[1];
		for (int i = 0; i < list.Count; i += 0)
		{
			PoolableObject poolableObject = list[i];
			PhotonView component = poolableObject.GetComponent<PhotonView>();
			poolableObject.BJPFIOGMKKO(component.viewID);
		}
		CALAKLNMEFF[1].Sort(PNPJMJFMENO);
		for (int j = 0; j < list.Count; j++)
		{
			PoolableObject poolableObject2 = list[j];
			poolableObject2.HCIPBCHFOPE(j);
		}
	}

	public virtual PoolableObject FJFDDFGKJKG(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = false;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.BeforeInstancied();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(true);
			poolableObject.pool = this;
			poolableObject.JMAFCGDIICK();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("GameLaunch" + CALAKLNMEFF[DFHAAIFFLOE][0].name);
		}
		return null;
	}

	private int BFHBONBOPEN(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	protected override void EHKKAOLJMCF()
	{
		DPDPFOGOCMM = true;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		DFADBBIONED = new List<int>(LNHBALFMHOM.Count);
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			int num = 0;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "Pool");
				gameObject.transform.parent = base.transform;
				num = objectPoolEntry.Prefab.GetComponentsInChildren<PhotonView>(true).Length;
			}
			DFADBBIONED.Add(GGFEKHCGFEC);
			int num2 = ((i != 0) ? objectPoolEntry.MHNHDPNNFKJ(NPNOIGHIALL.Game) : Singleton<LevelBehaviourManager>.instance.EstimateBehaviourInstanceCount<SoldierBehaviour>(NPNOIGHIALL.Game));
			GGFEKHCGFEC += num * num2;
		}
		InstantiatePooledObjects(NPNOIGHIALL.Init);
	}

	private int ALIONGALALM(PoolableObject CJPPIMEJOED)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		int key = APCGDLEHGKL[CJPPIMEJOED];
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(key, out value);
		if (value.First == null)
		{
			return -1;
		}
		return (!isMasterClient) ? value.Last.Value : value.First.Value;
	}

	public PoolableObject DIBKCCLGBDB(PoolableObject CJPPIMEJOED, int AHMNOGCLPHC)
	{
		int nOCEDALFEJM = APCGDLEHGKL[CJPPIMEJOED];
		return ReInstantiate(nOCEDALFEJM, AHMNOGCLPHC);
	}

	public virtual PoolableObject APJKGKEAGBO(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.CCNKJOAKBNG();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(false);
			poolableObject.MNBDCCCJKAP(this);
			poolableObject.HPPIBGEJMNL();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("withAttribute3" + CALAKLNMEFF[DFHAAIFFLOE][1].name);
		}
		return null;
	}

	public override PoolableObject Instantiate(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.BeforeInstancied();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(true);
			poolableObject.pool = this;
			poolableObject.OnInstancied();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + CALAKLNMEFF[DFHAAIFFLOE][0].name);
		}
		return null;
	}

	protected virtual void AKKKDIBLICM()
	{
		OLBEOPKDEBJ();
		if (!DPDPFOGOCMM)
		{
			OFLMFBHEMHB();
		}
	}

	protected virtual void NLLLLJGKNIC()
	{
		OLBEOPKDEBJ();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	public virtual PoolableObject LPLMABPBGJE(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		LinkedList<int> value;
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][(!isMasterClient) ? value.Last.Value : value.First.Value];
			poolableObject.enabled = false;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.CCNKJOAKBNG();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if (isMasterClient)
			{
				value.RemoveFirst();
			}
			else
			{
				value.RemoveLast();
			}
			poolableObject.gameObject.SetActive(true);
			poolableObject.pool = this;
			poolableObject.HPPIBGEJMNL();
			return poolableObject;
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogError(" (#" + CALAKLNMEFF[DFHAAIFFLOE][1].name);
		}
		return null;
	}
}

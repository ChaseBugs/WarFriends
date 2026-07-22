using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;
using WarFriends.Legacy;

public class PlayerInventory : DatabaseSerializedObjectGeneric<PlayerInventory.InventoryData>
{
	public class JIMOKIIJHNA
	{
		public int EPNKPKHCKNG;

		public int DGPAEJJENDP;

		public bool GJNGLPOBFJI = true;

		public int FIPONKNHIAL = -1;
	}

	[Serializable]
	public class InventorySlot
	{
		public int index;

		public WeaponCategory category;

		public string dictionaryId;

		public string iconName;

		public string name => Localization.Localize(dictionaryId);

		public int weaponIndex
		{
			get
			{
				SerializedSlotDetail value = null;
				if (instance.data.slots.TryGetValue(index, out value))
				{
					return value.weaponIndex;
				}
				Debug.LogError("data.slots doesnt contain: " + index);
				return 0;
			}
			set
			{
				instance.data.slots[index].weaponIndex = value;
			}
		}

		public WeaponLevelsSetup weaponLevelsSetup => (weaponIndex >= 0) ? LevelManager.instance.weaponLevelsSetups[weaponIndex] : null;

		[SpecialName]
		public string DGFBOCCJJFN()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string PEBCDKANKPF()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void FNPKMGNKNDH(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int CGGDFMLBBLN()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("com/google/android/gms/common/ConnectionResult" + index);
			return 0;
		}

		[SpecialName]
		public WeaponLevelsSetup BIPKCHNEPGK()
		{
			return (BDPIPGIODBO() >= 0) ? LevelManager.instance.weaponLevelsSetups[HAJHACMACJB()] : null;
		}

		[SpecialName]
		public void LBMNNAGFJJF(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public WeaponLevelsSetup KBCDILLLFIJ()
		{
			return (AJJCLMAKAGJ() >= 0) ? LevelManager.instance.weaponLevelsSetups[GEJFEKCCINP()] : null;
		}

		[SpecialName]
		public void IFHGFLKICKG(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int HAJHACMACJB()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("ID_READYTIME" + index);
			return 1;
		}

		[SpecialName]
		public string HLBAJGPAHMI()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public int CPFHGEMOBAK()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError(" " + index);
			return 1;
		}

		[SpecialName]
		public void CPPFGEHLHJF(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int GPCHHHCMGIO()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("ID_CONFIRM_GAMEDIDNTEXIST" + index);
			return 0;
		}

		[SpecialName]
		public int LOLOJECDOGG()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("RegisterAge()" + index);
			return 1;
		}

		[SpecialName]
		public string PIMAHGPCIML()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string LHCAILLHHHL()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void HLBFKDDOLJM(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public void JJOACDBFEMD(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int GEHDGDJKOOI()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("Deploys_Count" + index);
			return 1;
		}

		[SpecialName]
		public void IHPLPABEKNL(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int OFCGMOELNDB()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("ID_READYTIME" + index);
			return 0;
		}

		[SpecialName]
		public WeaponLevelsSetup HHMKPPOAOBJ()
		{
			return (AJJCLMAKAGJ() >= 0) ? LevelManager.instance.weaponLevelsSetups[DHJJJMGJAON()] : null;
		}

		[SpecialName]
		public int GGNMIPJGBBN()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("BLABLA" + index);
			return 1;
		}

		[SpecialName]
		public int EKBLBOFOGAD()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("Level" + index);
			return 1;
		}

		[SpecialName]
		public WeaponLevelsSetup MOGCFBHKAFO()
		{
			return (EHHHJEENHEA() >= 1) ? LevelManager.instance.weaponLevelsSetups[GPCHHHCMGIO()] : null;
		}

		[SpecialName]
		public int DHJJJMGJAON()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("CardWasUsedOnline" + index);
			return 1;
		}

		[SpecialName]
		public WeaponLevelsSetup MJOAIHHAPFG()
		{
			return (IPCKMKAIIBL() >= 0) ? LevelManager.instance.weaponLevelsSetups[DHJJJMGJAON()] : null;
		}

		[SpecialName]
		public void DMNKNAKPFLM(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public void FFEGPEGFGBC(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public void DKNOFBDFMPK(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public string KOEHDDPKMFN()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void DPONAGHPPCD(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int GEJFEKCCINP()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("ID_ZEROSECONDS" + index);
			return 0;
		}

		[SpecialName]
		public WeaponLevelsSetup INHNFHEMNFF()
		{
			return (CPFHGEMOBAK() >= 1) ? LevelManager.instance.weaponLevelsSetups[NAMNJHBAMCO()] : null;
		}

		[SpecialName]
		public WeaponLevelsSetup NLBHEBNFBFN()
		{
			return (AHENJGNHHOL() >= 1) ? LevelManager.instance.weaponLevelsSetups[CEEBHGLGAIO()] : null;
		}

		[SpecialName]
		public void FGEEJHKPCDO(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public WeaponLevelsSetup PMJFFNLKKLB()
		{
			return (CEEBHGLGAIO() >= 0) ? LevelManager.instance.weaponLevelsSetups[GPCHHHCMGIO()] : null;
		}

		[SpecialName]
		public int CEEBHGLGAIO()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("getRewardedInfoForZoneID" + index);
			return 0;
		}

		[SpecialName]
		public int OLJPPBGBEPI()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("KochavaDeviceID" + index);
			return 0;
		}

		[SpecialName]
		public string NPIJFNIDNPA()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public WeaponLevelsSetup IDMPHABHMGI()
		{
			return (GPCHHHCMGIO() >= 1) ? LevelManager.instance.weaponLevelsSetups[LOLOJECDOGG()] : null;
		}

		[SpecialName]
		public int COAFAFHCJMK()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("PlayeScifiParticles" + index);
			return 0;
		}

		[SpecialName]
		public WeaponLevelsSetup JCPKCKIHFBI()
		{
			return (GEJFEKCCINP() >= 0) ? LevelManager.instance.weaponLevelsSetups[NAMNJHBAMCO()] : null;
		}

		[SpecialName]
		public int LDNJEBLJLCL()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("Region" + index);
			return 0;
		}

		[SpecialName]
		public WeaponLevelsSetup FPGNBPPHPKC()
		{
			return (GGNMIPJGBBN() >= 1) ? LevelManager.instance.weaponLevelsSetups[KNEJLHLKCGE()] : null;
		}

		[SpecialName]
		public WeaponLevelsSetup LMPIDJLMPLG()
		{
			return (COAFAFHCJMK() >= 1) ? LevelManager.instance.weaponLevelsSetups[GGNMIPJGBBN()] : null;
		}

		[SpecialName]
		public string ELJDAELLMCO()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public WeaponLevelsSetup JGDAEBDGJBM()
		{
			return (MECBBKHAACM() >= 0) ? LevelManager.instance.weaponLevelsSetups[IPCKMKAIIBL()] : null;
		}

		[SpecialName]
		public WeaponLevelsSetup CKJOBHNNFAM()
		{
			return (MECBBKHAACM() >= 1) ? LevelManager.instance.weaponLevelsSetups[AJJCLMAKAGJ()] : null;
		}

		[SpecialName]
		public string FBBEFEBKLOO()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string LMMKBNNGGBA()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public int IAINOHMADJC()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("ID_READYTIME" + index);
			return 1;
		}

		[SpecialName]
		public string LAGBFMEGECF()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public int LLPKJIPCFBE()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("Daily" + index);
			return 0;
		}

		[SpecialName]
		public void EGOKIGPCCIN(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public WeaponLevelsSetup NNACPNBKBJA()
		{
			return (IAINOHMADJC() >= 1) ? LevelManager.instance.weaponLevelsSetups[OLJPPBGBEPI()] : null;
		}

		[SpecialName]
		public string KABGBBJOMBA()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public WeaponLevelsSetup JBKEFFEKHEG()
		{
			return (GPCHHHCMGIO() >= 0) ? LevelManager.instance.weaponLevelsSetups[OFCGMOELNDB()] : null;
		}

		[SpecialName]
		public string DHFIECGHFCO()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void IFFJPBOGLGP(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int NAMNJHBAMCO()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("some_pub_sub3" + index);
			return 1;
		}

		[SpecialName]
		public string GMBBMIKOODB()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string MLFHKBCNAHG()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string HLLCFONBKLE()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public WeaponLevelsSetup ALEBNFNFOEP()
		{
			return (LLPKJIPCFBE() >= 1) ? LevelManager.instance.weaponLevelsSetups[LOLOJECDOGG()] : null;
		}

		[SpecialName]
		public void EJBFNCPMDLB(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public string IBAHBKAEHML()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void LHAKFGHKPDE(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public WeaponLevelsSetup LFBDANCEFGE()
		{
			return (CEEBHGLGAIO() >= 1) ? LevelManager.instance.weaponLevelsSetups[IPCKMKAIIBL()] : null;
		}

		[SpecialName]
		public string HPFHPKDJHJC()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public WeaponLevelsSetup ANOHEJKJAKG()
		{
			return (NAMNJHBAMCO() >= 0) ? LevelManager.instance.weaponLevelsSetups[LLPKJIPCFBE()] : null;
		}

		[SpecialName]
		public int AJJCLMAKAGJ()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("Init bot RPC" + index);
			return 0;
		}

		[SpecialName]
		public WeaponLevelsSetup DLNNBFIIJPA()
		{
			return (LLPKJIPCFBE() >= 1) ? LevelManager.instance.weaponLevelsSetups[NAMNJHBAMCO()] : null;
		}

		[SpecialName]
		public WeaponLevelsSetup ENBMDAIKKMM()
		{
			return (BDPIPGIODBO() >= 1) ? LevelManager.instance.weaponLevelsSetups[IAINOHMADJC()] : null;
		}

		[SpecialName]
		public int IPCKMKAIIBL()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("ID_HOUR_SMALL" + index);
			return 1;
		}

		[SpecialName]
		public void AGJEJOHIHKO(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int MECBBKHAACM()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("GameCenterId" + index);
			return 0;
		}

		[SpecialName]
		public int KNEJLHLKCGE()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("DOWNLOAD" + index);
			return 0;
		}

		[SpecialName]
		public string DNACMNBENLG()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void GOMPDOGNGPJ(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int EHHNOODADAA()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}" + index);
			return 1;
		}

		[SpecialName]
		public WeaponLevelsSetup JEHGKOGGBCP()
		{
			return (AHENJGNHHOL() >= 1) ? LevelManager.instance.weaponLevelsSetups[IAINOHMADJC()] : null;
		}

		[SpecialName]
		public string BMLJOFADDDI()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string CCBJNODHAAI()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string PHCDBKOGMDA()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void ECKGDJIMLFJ(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public int BDPIPGIODBO()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("FuseSDK: Error parsing RewardInfo. Returning default value." + index);
			return 1;
		}

		[SpecialName]
		public int EHHHJEENHEA()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("Beanstalk: " + index);
			return 1;
		}

		[SpecialName]
		public string NCFECNEKBPG()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public string KGBHICKFEBE()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public void JLMNKEFPBGD(int IDEBKDPMPGM)
		{
			instance.data.slots[index].weaponIndex = IDEBKDPMPGM;
		}

		[SpecialName]
		public string HBPCCEDFFEB()
		{
			return Localization.Localize(dictionaryId);
		}

		[SpecialName]
		public WeaponLevelsSetup BHDJIJGIHCL()
		{
			return (HAJHACMACJB() >= 1) ? LevelManager.instance.weaponLevelsSetups[BDPIPGIODBO()] : null;
		}

		[SpecialName]
		public int AHENJGNHHOL()
		{
			SerializedSlotDetail value = null;
			if (instance.data.slots.TryGetValue(index, out value))
			{
				return value.weaponIndex;
			}
			Debug.LogError("http://localhost:3000/socket.io/" + index);
			return 1;
		}
	}

	public class InventoryData
	{
		public Dictionary<int, SerializedSlotDetail> slots = new Dictionary<int, SerializedSlotDetail>();
	}

	public class SerializedSlotDetail
	{
		public string name;

		public int weaponIndex;
	}

	private static PlayerInventory mInstance;

	public List<InventorySlot> inventorySlots;

	public static PlayerInventory instance
	{
		get
		{
			mInstance = mInstance ?? ((PlayerInventory)SingletonSupport.FindOrCreate(typeof(PlayerInventory)));
			return mInstance;
		}
	}

	public JIMOKIIJHNA[] equippedWeapons
	{
		get
		{
			List<JIMOKIIJHNA> list = new List<JIMOKIIJHNA>();
			for (int i = 0; i < inventorySlots.Count; i++)
			{
				InventorySlot inventorySlot = inventorySlots[i];
				if (inventorySlot.weaponLevelsSetup != null)
				{
					list.Add(new JIMOKIIJHNA
					{
						EPNKPKHCKNG = inventorySlot.weaponIndex,
						DGPAEJJENDP = inventorySlot.weaponLevelsSetup.MGAGEKAAJOL.boughtIndex,
						GJNGLPOBFJI = true,
						FIPONKNHIAL = inventorySlot.weaponLevelsSetup.weaponFeature.index
					});
				}
			}
			return list.ToArray();
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
	}

	public void Init()
	{
		Debug.Log("PlayerInventory: Init");
		for (int i = 0; i < inventorySlots.Count; i++)
		{
			if (data.slots.ContainsKey(i))
			{
				continue;
			}
			int num = -1;
			int num2 = int.MaxValue;
			for (int j = 0; j < LevelManager.instance.weaponLevelsSetups.Count; j++)
			{
				if ((LevelManager.instance.weaponLevelsSetups[j].BHCEOOLEHHG & inventorySlots[i].category) == LevelManager.instance.weaponLevelsSetups[j].BHCEOOLEHHG && LevelManager.instance.weaponLevelsSetups[j].unlockLevelIndex < num2)
				{
					num2 = LevelManager.instance.weaponLevelsSetups[j].unlockLevelIndex;
					num = j;
				}
			}
			data.slots[i] = new SerializedSlotDetail
			{
				name = LevelManager.instance.weaponLevelsSetups[num].DHHKOKKDDDO(),
				weaponIndex = num
			};
		}
	}

	private void OnPlayerDataLoaded()
	{
	}

	public InventorySlot GetSlotForCategory(WeaponCategory category)
	{
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			if (category == (category & inventorySlot.category))
			{
				return inventorySlot;
			}
		}
		return null;
	}

	internal void LoadData(string inventoryData)
	{
		InventoryData inventoryData2 = JsonConvert.DeserializeObject<InventoryData>(inventoryData);
		foreach (KeyValuePair<int, SerializedSlotDetail> slot in inventoryData2.slots)
		{
			((InventoryData)SerializedObject).slots[slot.Key] = slot.Value;
		}
	}
}

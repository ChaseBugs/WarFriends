using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Scripting;

public class ShieldCosmeticsManager : DatabaseSerializedObjectGeneric<ShieldCosmeticsManager.ShieldData>
{
	public enum FCDJIAJHFEL
	{
		Unlocked,
		Arena,
		League,
		Collectible,
		Hidden
	}

	[Preserve]
	public class ShieldData
	{
		public Dictionary<string, ShieldCosmetic> all;

		public int[] equipped;

		public int[] prevEquipped;
	}

	[Serializable]
	public class ShieldCosmeticModel
	{
		[SerializeField]
		private int mShieldId;

		[SerializeField]
		private string mShieldName;

		[SerializeField]
		private string mShieldIcon;

		[SerializeField]
		private List<GameObject> mShieldModels;

		[SerializeField]
		private Material mMaterial;

		[SerializeField]
		private Material mAnimatedMaterial;

		[SerializeField]
		private Material mGlassMaterial;

		[SerializeField]
		private List<GameObject> mAnimatedModels;

		private ShieldsRow mRow;

		public ShieldsRow row
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FCDJIAJHFEL purchasable => default(FCDJIAJHFEL);

		public bool baseUnlocked => false;

		public bool isFromArena => false;

		public bool isFromLeague => false;

		public bool isCollectible => false;

		public int partsNeeded => 0;

		public bool hasDescription => false;

		public bool canBotEquip => false;

		public PlayerVisual.BJLIFLPNINI rarity => default(PlayerVisual.BJLIFLPNINI);

		public string rarityName => null;

		public string rarityNameFull => null;

		public GameObject JCACFBJCHPL(int DBEAHAFANGG)
		{
			return null;
		}

		public Material CNAHIHBAFFJ()
		{
			return null;
		}

		public GameObject PCJNBDLGIBI(int DBEAHAFANGG)
		{
			return null;
		}

		public Material JDJKGFOAACM()
		{
			return null;
		}

		public Material BLAPNPDCGJI()
		{
			return null;
		}

		public string HIBOGKMFPPO()
		{
			return null;
		}

		public string EPNBOCBFMOP()
		{
			return null;
		}

		public string KOGPBNGAHDC()
		{
			return null;
		}

		public int CFPBACEEKCN()
		{
			return 0;
		}
	}

	[Serializable]
	[Preserve]
	public class ShieldCosmetic
	{
		public int expire;

		public int parts;
	}

	[SerializeField]
	private List<ShieldCosmeticModel> mShieldCosmeticModels;

	private static ShieldCosmeticsManager DJDBDKFAKHN;

	private static Dictionary<League, int> KBGIENBFMKC;

	public static readonly List<string> HBKFHGFMAHI;

	private Shields HCILECDEMDF;

	[CompilerGenerated]
	private Action HPOFHKJOILB;

	[CompilerGenerated]
	private Action GHALELMEFMF;

	public static ShieldCosmeticsManager instance => null;

	public List<ShieldCosmeticModel> allShields => null;

	public List<ShieldCosmeticModel> allShieldsForBot => null;

	public event Action ShieldEquipped
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action ShieldAllEquipped
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	private void LLJGFMOCLDG()
	{
	}

	public void EquipAll(int GNIGACIKDJD)
	{
	}

	public void EquipIntoSlot(int GNIGACIKDJD, int PKELBCEPGLI)
	{
	}

	public void UpdateEquipGUI()
	{
	}

	public bool IsEquipped(ShieldCosmeticModel HMIIAANDMAO, int PKELBCEPGLI)
	{
		return false;
	}

	public bool IsEquippedAll(ShieldCosmeticModel HMIIAANDMAO)
	{
		return false;
	}

	public int GetOwnedParts(string GNIGACIKDJD)
	{
		return 0;
	}

	public bool IsCompletedParts(ShieldCosmeticModel HMIIAANDMAO)
	{
		return false;
	}

	private bool GPIDBGDBOEM(ShieldCosmeticModel HMIIAANDMAO)
	{
		return false;
	}

	public bool IsInInventory(ShieldCosmeticModel HMIIAANDMAO)
	{
		return false;
	}

	public ShieldCosmeticModel GetEquippedShield(int PONMBDNDEAM)
	{
		return null;
	}

	public ShieldCosmeticModel GetShieldById(int GNIGACIKDJD)
	{
		return null;
	}

	public int[] GetEquippedShields()
	{
		return null;
	}

	public int GetRemainingTime(string GNIGACIKDJD)
	{
		return 0;
	}

	private bool ONMANALKNFH(ShieldCosmeticModel HMIIAANDMAO)
	{
		return false;
	}

	public bool IsShieldOffered(int GNIGACIKDJD)
	{
		return false;
	}

	public bool IsShieldInEvent(int GNIGACIKDJD)
	{
		return false;
	}

	private int[] ELBAIBKIFKJ()
	{
		return null;
	}

	private void AFAMKNKDOMG()
	{
	}

	public void EquipShieldAllArena()
	{
	}

	private ShieldCosmeticModel MFPGEBHJIOJ()
	{
		return null;
	}

	public ShieldCosmeticModel GetLeagueShieldById(League DIBNIFJGDEH)
	{
		return null;
	}

	public void UpdateLeagueShields()
	{
	}
}

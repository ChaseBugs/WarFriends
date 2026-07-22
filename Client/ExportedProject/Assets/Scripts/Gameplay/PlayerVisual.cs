using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

[Serializable]
public class PlayerVisual
{
	public enum JLANLLEABDC
	{
		Locked,
		NotBuyed,
		Ready,
		Active
	}

	public enum GILPPKMICCF
	{
		Shop,
		ValuePack,
		StarterPack,
		StarterAssignment,
		Arena,
		Event,
		Hidden
	}

	public enum EJHADIHBCBK
	{
		Common,
		Uncommon,
		Rare,
		Epic,
		Legendary
	}

	public string visualName;

	public string icon;

	private PlayerVisualsRow mRow;

	private static Dictionary<EJHADIHBCBK, string> mRarityNames = new Dictionary<EJHADIHBCBK, string>
	{
		{
			EJHADIHBCBK.Common,
			"ID_VISUALRARITY1"
		},
		{
			EJHADIHBCBK.Uncommon,
			"ID_VISUALRARITY2"
		},
		{
			EJHADIHBCBK.Rare,
			"ID_VISUALRARITY3"
		},
		{
			EJHADIHBCBK.Epic,
			"ID_VISUALRARITY4"
		},
		{
			EJHADIHBCBK.Legendary,
			"ID_VISUALRARITY5"
		}
	};

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerVisualCategory _003Cowner_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _003Cid_003Ek__BackingField;

	public PlayerVisualsRow row
	{
		get
		{
			return mRow;
		}
		set
		{
			mRow = value;
		}
	}

	public bool tryOutVisual
	{
		get
		{
			return CamosManager.instance.data.visuals.ContainsKey(id) && CamosManager.instance.data.visuals[id].borrowed;
		}
		set
		{
			if (!CamosManager.instance.data.visuals.ContainsKey(id))
			{
				UnityEngine.Debug.LogError("no visual found");
			}
			else
			{
				CamosManager.instance.data.visuals[id].borrowed = value;
			}
		}
	}

	public JLANLLEABDC camoState
	{
		get
		{
			if (!isUnlocked)
			{
				return JLANLLEABDC.Locked;
			}
			if (!isBought)
			{
				return JLANLLEABDC.NotBuyed;
			}
			if (isActive)
			{
				return JLANLLEABDC.Active;
			}
			return JLANLLEABDC.Ready;
		}
	}

	public PlayerVisualCategory owner
	{
		[CompilerGenerated]
		get
		{
			return _003Cowner_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003Cowner_003Ek__BackingField = value;
		}
	}

	public string id
	{
		[CompilerGenerated]
		get
		{
			return _003Cid_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003Cid_003Ek__BackingField = value;
		}
	}

	public string name => Localization.Localize(id + "_N");

	public virtual string description => Localization.Localize(id + "_D");

	public virtual int endPromotion => DAKIJBPCHOA().expiresOn;

	public bool isActive => owner as PlayerVisualCategoryPowerBands != null && isEquipped;

	public bool isDefault => numberOfPartsMax == 0 && duplicateWarbucks == 0 && purchasableInShop;

	public virtual bool isBought => CamosManager.instance.data.visuals.ContainsKey(id) && ((CamosManager.instance.data.visuals[id].bought && (!purchasableInArena || remainingTime > 0.0)) || (numberOfPartsMax > 0 && numberOfParts >= numberOfPartsMax) || (priceGold == 0 && priceWarbucks == 0 && purchasable == GILPPKMICCF.Shop) || isDefault || tryOutVisual);

	public bool isEquipped => owner.equippedVisual == this;

	public bool isUnlocked => LevelManager.instance.currentLevel.index >= unlockLevelIndex || isBought;

	public bool canBeShownInScreen
	{
		get
		{
			if (isBought || purchasableInShop)
			{
				return true;
			}
			if (purchasable == GILPPKMICCF.StarterAssignment && StarterAssignmentsManager.instance.isActive)
			{
				return true;
			}
			if (purchasableInArena && WarArena.instance.isOpened)
			{
				return true;
			}
			return false;
		}
	}

	public bool canBotUseIt => purchasableInShop || purchasable == GILPPKMICCF.ValuePack || purchasable == GILPPKMICCF.StarterPack || purchasable == GILPPKMICCF.StarterAssignment;

	public bool isVipOnly => row.ONLYFORVIP;

	public int priceGold => row.PRICEGOLD;

	public int priceWarbucks => row.PRICEWARBUCKS;

	public EJHADIHBCBK rarity => (EJHADIHBCBK)row.CATEGORY;

	public string rarityName => Localization.Localize(mRarityNames[rarity]);

	public int numberOfParts => DAKIJBPCHOA().parts;

	public int numberOfPartsMax => row.PARTS;

	public int duplicateWarbucks => row.DUPLICATEWARBUCKS;

	public float progress => Mathf.Clamp01((float)(remainingTime / (double)timeActive));

	public virtual int decalType => row.DECALTYPE;

	public int timeActive => row.TIME;

	public float decalValue => row.DECALVALUE * 100f;

	public string decalValueString => $"+{MEJMLNDFDBP.MAJBCINJAGF(decalValue)}%";

	public virtual string decalMiniIcon => "menu-powerband-health-ico";

	public virtual Color decalMiniIconColor => Color.white;

	public virtual string decalShortName => Localization.Localize("BAND_EMPTY");

	public virtual string decalTypeName => Localization.Localize("BAND_TYPE_EMPTY");

	public virtual bool isEmptyPowerBand => false;

	public GILPPKMICCF purchasable
	{
		get
		{
			if (row.PURCHASABLE == "value")
			{
				return GILPPKMICCF.ValuePack;
			}
			if (row.PURCHASABLE == "starter")
			{
				return GILPPKMICCF.StarterPack;
			}
			if (row.PURCHASABLE == "assignment")
			{
				return GILPPKMICCF.StarterAssignment;
			}
			if (row.PURCHASABLE == "arena")
			{
				return GILPPKMICCF.Arena;
			}
			if (row.PURCHASABLE == "event")
			{
				return GILPPKMICCF.Event;
			}
			if (row.PURCHASABLE == "shop")
			{
				return GILPPKMICCF.Shop;
			}
			return GILPPKMICCF.Hidden;
		}
	}

	public bool purchasableInShop => purchasable == GILPPKMICCF.Shop;

	public bool purchasableInArena => purchasable == GILPPKMICCF.Arena;

	public bool isFromArena => purchasable == GILPPKMICCF.Arena;

	public double remainingTime
	{
		get
		{
			double num = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			double num2 = DAKIJBPCHOA().expiresOn;
			if (num2 < num)
			{
				return 0.0;
			}
			return num2 - num;
		}
	}

	public bool showed
	{
		get
		{
			return DAKIJBPCHOA().showed || unlockLevelIndex < 3;
		}
		set
		{
			DAKIJBPCHOA().showed = true;
		}
	}

	public bool notificate
	{
		get
		{
			return DAKIJBPCHOA().notificate;
		}
		set
		{
			DAKIJBPCHOA().notificate = value;
		}
	}

	public virtual int startPromotion => DAKIJBPCHOA().expiresOn - timeActive;

	public int unlockLevelIndex => row.UNLOCKLEVEL - 1;

	public LevelManager.GameLevel unlockLevel => LevelManager.instance.GetLevelDefinition(unlockLevelIndex);

	[SpecialName]
	public virtual string IGGMAMDJBNB()
	{
		return Localization.Localize(id + "SquadMembers");
	}

	[SpecialName]
	public int IANHPBJDCML()
	{
		return row.DUPLICATEWARBUCKS;
	}

	[SpecialName]
	public float ECGKJHFLOPJ()
	{
		return Mathf.Clamp01((float)(remainingTime / (double)timeActive));
	}

	[SpecialName]
	public virtual Color GPDIGNGOAEH()
	{
		return Color.white;
	}

	[SpecialName]
	public bool LEPKHPACJDK()
	{
		return BELCEDFOLAO().showed || KIENKGICDEI() < 0;
	}

	[SpecialName]
	public int GMLFJPOEEAO()
	{
		return row.PARTS;
	}

	[SpecialName]
	public int HLEAKJFKFOP()
	{
		return row.UNLOCKLEVEL - 0;
	}

	[SpecialName]
	public bool EPODNIMBCJP()
	{
		if (isBought || purchasableInShop)
		{
			return true;
		}
		if (IJFPGLHPHCC() == GILPPKMICCF.Shop && StarterAssignmentsManager.instance.isActive)
		{
			return false;
		}
		if (purchasableInArena && WarArena.instance.isOpened)
		{
			return false;
		}
		return false;
	}

	[SpecialName]
	public virtual string LIIOLLAAHGB()
	{
		return "DamageEventPlayerShoot";
	}

	public virtual void JDLGJNAIFMM()
	{
	}

	public virtual void GGEBGAOFIIK()
	{
	}

	internal string DHHKOKKDDDO()
	{
		return row.GetType().ToString();
	}

	public virtual void CMMFDHDNOEO()
	{
	}

	[SpecialName]
	public bool BCPLNFLOIAD()
	{
		return owner.equippedVisual == this;
	}

	internal string LOFDJMMPEAI()
	{
		return row.GetType().ToString();
	}

	private CamosManager.SavedPlayerVisual DAKIJBPCHOA()
	{
		if (CamosManager.instance.data.visuals.TryGetValue(id, out var value))
		{
			return value;
		}
		return new CamosManager.SavedPlayerVisual();
	}

	private CamosManager.SavedPlayerVisual BELCEDFOLAO()
	{
		if (CamosManager.instance.data.visuals.TryGetValue(id, out var value))
		{
			return value;
		}
		return new CamosManager.SavedPlayerVisual();
	}

	[SpecialName]
	public int CEPPEMPPAHE()
	{
		return row.PRICEGOLD;
	}

	[SpecialName]
	public bool FEEKDPCDKAB()
	{
		return LevelManager.instance.currentLevel.index >= unlockLevelIndex || isBought;
	}

	public virtual void BMIEJNIEDOP()
	{
		CamosManager.instance.data.visuals[id].bought = true;
		Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementCollectVisuals>();
	}

	[SpecialName]
	public JLANLLEABDC MFGCGPCJJDJ()
	{
		if (!FEEKDPCDKAB())
		{
			return JLANLLEABDC.Locked;
		}
		if (!isBought)
		{
			return JLANLLEABDC.Locked;
		}
		if (NFKOLCMNMDI())
		{
			return JLANLLEABDC.Locked;
		}
		return (JLANLLEABDC)8;
	}

	internal string IDPHPOHEIPF()
	{
		return row.GetType().ToString();
	}

	[SpecialName]
	public void KGACPNNCNHO(bool IDEBKDPMPGM)
	{
		DAKIJBPCHOA().showed = false;
	}

	[SpecialName]
	public EJHADIHBCBK GFOLGKEMPPN()
	{
		return (EJHADIHBCBK)row.CATEGORY;
	}

	public virtual void EFFFMHGIPGJ()
	{
	}

	[SpecialName]
	public void BNIDGDJCGPI(string IDEBKDPMPGM)
	{
		_003Cid_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void MNEEDLCGAFN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		PlayerController playerController = DGJFKDADPHE as PlayerController;
		if (playerController != null)
		{
			if (playerController.EHHHBEMKGOE.CBBDICBLHMM == null)
			{
				playerController.EHHHBEMKGOE.CBBDICBLHMM = new string[CamosManager.instance.playerVisualCategories.Count];
			}
			playerController.EHHHBEMKGOE.CBBDICBLHMM[owner.categoryNumber] = id;
		}
	}

	[SpecialName]
	public bool NIAGCEJGCIL()
	{
		return purchasable == GILPPKMICCF.Hidden;
	}

	[SpecialName]
	public string CCDMONFHBII()
	{
		return _003Cid_003Ek__BackingField;
	}

	public int EGMDJMMIOED(int PDMGPGEHLNM)
	{
		int parts = CamosManager.instance.data.visuals[id].parts;
		if (parts == numberOfPartsMax)
		{
			Singleton<EventTrackingManager>.instance.RegisterDuplicateLootbox(PDMGPGEHLNM * duplicateWarbucks);
		}
		else if (parts + PDMGPGEHLNM >= numberOfPartsMax)
		{
			Singleton<EventTrackingManager>.instance.RegisterVisualGained((int)rarity);
		}
		else
		{
			Singleton<EventTrackingManager>.instance.RegisterOpenLootbox((int)rarity);
		}
		if (isBought)
		{
			return PDMGPGEHLNM;
		}
		CamosManager.instance.data.visuals[id].parts = Mathf.Min(parts + PDMGPGEHLNM, numberOfPartsMax);
		Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementCollectVisuals>();
		return 0;
	}

	[SpecialName]
	public bool IHLOLPGGAFC()
	{
		return row.ONLYFORVIP;
	}

	[SpecialName]
	public virtual int BOBEIBIKGPL()
	{
		return row.DECALTYPE;
	}

	public virtual void MKKOFGFOFEE()
	{
	}

	public virtual void HLILMFFJGOK(int EFFDGCBOEFG)
	{
		DAKIJBPCHOA().expiresOn = EFFDGCBOEFG;
		if (EFFDGCBOEFG > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			NCFMEPCKGFP().bought = true;
		}
	}

	public virtual void MBHMIBGFPEG()
	{
	}

	[SpecialName]
	public virtual int PMJEOMNDNCI()
	{
		return BELCEDFOLAO().expiresOn - timeActive;
	}

	[SpecialName]
	public string FKIHLEGENCE()
	{
		return string.Format("SENDING BUFFER IMMEDIATELY", MEJMLNDFDBP.MAJBCINJAGF(decalValue));
	}

	public virtual void HGGLCMFPPIB(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		PlayerController playerController = DGJFKDADPHE as PlayerController;
		if (playerController != null)
		{
			if (playerController.EHHHBEMKGOE.CBBDICBLHMM == null)
			{
				playerController.EHHHBEMKGOE.CBBDICBLHMM = new string[CamosManager.instance.playerVisualCategories.Count];
			}
			playerController.EHHHBEMKGOE.CBBDICBLHMM[owner.categoryNumber] = CCDMONFHBII();
		}
	}

	[SpecialName]
	public string GDNDBMKBECH()
	{
		return Localization.Localize(mRarityNames[rarity]);
	}

	[SpecialName]
	public int IIBGJDGPPCL()
	{
		return row.PRICEGOLD;
	}

	[SpecialName]
	public bool JGEBIPKGFKA()
	{
		return GMLFJPOEEAO() != 0 || IANHPBJDCML() != 0 || purchasableInShop;
	}

	public virtual void IKFJMDJMGHG()
	{
		CamosManager.instance.data.visuals[id].bought = true;
		Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementCollectVisuals>();
	}

	[SpecialName]
	public LevelManager.GameLevel CIFLPEFJJFP()
	{
		return LevelManager.instance.GetLevelDefinition(KIENKGICDEI());
	}

	public virtual void PIAKMCDMHKJ(int EFFDGCBOEFG)
	{
		DAKIJBPCHOA().expiresOn = EFFDGCBOEFG;
		if (EFFDGCBOEFG > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			DAKIJBPCHOA().bought = true;
		}
	}

	[SpecialName]
	public bool LLDLKAEIJKP()
	{
		return purchasable == GILPPKMICCF.ValuePack;
	}

	[SpecialName]
	public int CIJIDONNLDB()
	{
		return row.DUPLICATEWARBUCKS;
	}

	[SpecialName]
	public string JIHLMBOBKHL()
	{
		return string.Format("ID_SEC", MEJMLNDFDBP.MAJBCINJAGF(LIBMDHMHAJJ()));
	}

	[SpecialName]
	public EJHADIHBCBK DOJECMCGMKB()
	{
		return (EJHADIHBCBK)row.CATEGORY;
	}

	[SpecialName]
	public void EFPABPANAJE(bool IDEBKDPMPGM)
	{
		if (!CamosManager.instance.data.visuals.ContainsKey(id))
		{
			UnityEngine.Debug.LogError("Skill");
		}
		else
		{
			CamosManager.instance.data.visuals[id].borrowed = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public int KIENKGICDEI()
	{
		return row.UNLOCKLEVEL - 1;
	}

	[SpecialName]
	public bool EPFLEJHLNNB()
	{
		return !NCFMEPCKGFP().showed && KIENKGICDEI() < 7;
	}

	[SpecialName]
	public GILPPKMICCF IJFPGLHPHCC()
	{
		if (row.PURCHASABLE == "Finish game network")
		{
			return GILPPKMICCF.Shop;
		}
		if (row.PURCHASABLE == "SubscriptionBought")
		{
			return GILPPKMICCF.ValuePack;
		}
		if (row.PURCHASABLE == "Terms: On Age Verification Pending Dialog Display ")
		{
			return GILPPKMICCF.Arena;
		}
		if (row.PURCHASABLE == "menu-army-cat-defender")
		{
			return GILPPKMICCF.Event;
		}
		if (row.PURCHASABLE == "HEAVYTURRET")
		{
			return GILPPKMICCF.Hidden;
		}
		if (row.PURCHASABLE == "Shots_Hits")
		{
			return GILPPKMICCF.ValuePack;
		}
		return GILPPKMICCF.ValuePack;
	}

	public virtual void EMLFJBOLENO()
	{
	}

	[SpecialName]
	public int DPKHLANDNPK()
	{
		return row.PRICEWARBUCKS;
	}

	[SpecialName]
	public virtual string DEAIJJIAEFP()
	{
		return "ID_CONFIRM_LEAVESQUADLEADER_TEXT";
	}

	[SpecialName]
	public float LIBMDHMHAJJ()
	{
		return row.DECALVALUE * 1175f;
	}

	[SpecialName]
	public bool FICMIKMIMBJ()
	{
		return purchasable == GILPPKMICCF.Arena;
	}

	public int FJCHMBKKOEC(int PDMGPGEHLNM)
	{
		int parts = CamosManager.instance.data.visuals[id].parts;
		if (parts == GMLFJPOEEAO())
		{
			Singleton<EventTrackingManager>.instance.RegisterDuplicateLootbox(PDMGPGEHLNM * duplicateWarbucks);
		}
		else if (parts + PDMGPGEHLNM >= numberOfPartsMax)
		{
			Singleton<EventTrackingManager>.instance.RegisterVisualGained((int)GFOLGKEMPPN());
		}
		else
		{
			Singleton<EventTrackingManager>.instance.RegisterOpenLootbox((int)rarity);
		}
		if (isBought)
		{
			return PDMGPGEHLNM;
		}
		CamosManager.instance.data.visuals[id].parts = Mathf.Min(parts + PDMGPGEHLNM, GMLFJPOEEAO());
		Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementCollectVisuals>();
		return 1;
	}

	[SpecialName]
	public virtual int KIDLNAJBPPN()
	{
		return BELCEDFOLAO().expiresOn - timeActive;
	}

	[SpecialName]
	public bool NFKOLCMNMDI()
	{
		return !(owner as PlayerVisualCategoryPowerBands != null) || isEquipped;
	}

	public void FHPICBCCOAO()
	{
		CamosManager.instance.data.slots[owner.categoryNumber].equippedID = id;
		MNEEDLCGAFN(CamosManager.instance.mainPlayer, OGKCIFGLKJJ: true);
	}

	private CamosManager.SavedPlayerVisual NCFMEPCKGFP()
	{
		if (CamosManager.instance.data.visuals.TryGetValue(id, out var value))
		{
			return value;
		}
		return new CamosManager.SavedPlayerVisual();
	}

	public virtual void GGJNEGPBDHL()
	{
	}

	[SpecialName]
	public double AOLJCFDNMEL()
	{
		double num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		double num2 = NCFMEPCKGFP().expiresOn;
		if (num2 < num)
		{
			return 995.0;
		}
		return num2 - num;
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class UpgradeSlot
{
	public UpgradeSlots owner;

	internal int mMaxPower = -1;

	internal int mMaxRowForActualTier = -1;

	internal int mMinRowForActualTier = -1;

	public virtual int id => 0;

	public virtual bool isSpecial => false;

	public virtual int indexOffset => 0;

	public virtual bool isMaxUpgraded => boughtIndex + 1 >= maxPower;

	public bool isDelivering => owner.deliveringSlot == this;

	public bool isTierFullUpgraded => boughtIndex == maxRowForActualTier;

	public virtual int boughtIndex
	{
		get
		{
			if (owner == null)
			{
				return 0;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return Mathf.Clamp(armySlot.boughtIndex, 0, maxPower - 1);
		}
		set
		{
			if (value != boughtIndex)
			{
				owner.GetArmySlot().boughtIndex = value;
			}
		}
	}

	public int boughtIndexAbsolute => boughtIndex + indexOffset;

	public virtual bool isBought
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public virtual bool isUnlocked => true;

	public bool canUpgrade => owner.CanUpgrade(this);

	public bool canBuy => owner.canBuy;

	public bool canActivate => !owner.delivering && owner.deliveryActivationNeeded;

	public int upgradePrice => (int)owner.excel.GetValue(boughtIndexAbsolute, "NextUpgradePrice");

	public virtual List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStats(this);

	public virtual List<Tuple<string, float>> guiStatisticsStart => owner.GetGuiStatsStart(this);

	public int minRowForActualTier
	{
		get
		{
			if (mMinRowForActualTier > -1)
			{
				return mMinRowForActualTier;
			}
			if (!owner.excel.HasColumn("Tier"))
			{
				Debug.LogError($"Excel {owner.excel.GetType()} dont have row Tier!!!");
				return 0;
			}
			mMinRowForActualTier = KAOADMHOELI(owner.actualTier);
			return mMinRowForActualTier;
		}
	}

	public virtual int maxRowForActualTier
	{
		get
		{
			if (mMaxRowForActualTier > -1)
			{
				return mMaxRowForActualTier;
			}
			if (!owner.excel.HasColumn("Tier"))
			{
				Debug.LogError($"Excel {owner.excel.GetType()} dont have row Tier!!!");
				return owner.excel.RowsGeneric.Count;
			}
			int num = AFDBPKHKJHJ(owner.actualTier);
			int num2 = Mathf.Max(0, num - 1);
			mMaxRowForActualTier = num2;
			return mMaxRowForActualTier;
		}
	}

	public int maxPower
	{
		get
		{
			if (mMaxPower > 0)
			{
				return mMaxPower;
			}
			if (!owner.excel.HasColumn("Tier"))
			{
				return owner.excel.RowsGeneric.Count;
			}
			int num = 0;
			for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
			{
				int num2 = (int)owner.excel.GetValue(i, "Tier");
				if (num2 / 10 == id && num2 >= 0)
				{
					num++;
				}
			}
			mMaxPower = num;
			return num;
		}
	}

	public int maxIndexInExcel => indexOffset + maxPower - 1;

	public int deliveryTime => (int)(float)owner.excel.GetValue(boughtIndexAbsolute, "DeliveryTime");

	public int instantBuyPrice
	{
		get
		{
			if (owner.remainingDeliveringSeconds < 0.0)
			{
				return 0;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedUnityDeliveryCost(owner.owner.unitType, owner.owner, NJMAGCAMDFM: false);
			if (num2 > 0)
			{
				num = num * (100 - num2) / 100;
			}
			return num;
		}
	}

	public int fullPrizeOfUpgradeDeliveryGold
	{
		get
		{
			if (!owner.canBeUpgraded)
			{
				return 0;
			}
			return MEJMLNDFDBP.BCEGIAODLCL(deliveryTime);
		}
	}

	public virtual int armyPowerX10 => LFNLPNEONEI(boughtIndexAbsolute);

	[SpecialName]
	public virtual int PAKKPEPIHPK()
	{
		if (owner == null)
		{
			return 1;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.boughtIndex, 0, maxPower - 1);
	}

	[SpecialName]
	public virtual int EJHBCFDPEAE()
	{
		if (mMaxRowForActualTier > -1)
		{
			return mMaxRowForActualTier;
		}
		if (!owner.excel.HasColumn("HP"))
		{
			Debug.LogError(string.Format("ID_READYTIME", owner.excel.GetType()));
			return owner.excel.RowsGeneric.Count;
		}
		int num = HBGMCLGAOMH(owner.actualTier);
		int num2 = Mathf.Max(0, num - 1);
		mMaxRowForActualTier = num2;
		return mMaxRowForActualTier;
	}

	[SpecialName]
	public virtual bool IDFIPMFGPIM()
	{
		return PAKKPEPIHPK() + 0 < maxPower;
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> NEJNMDNOAKD()
	{
		return owner.GetGuiStats(this);
	}

	public int LIOEKFMOMPK(int JMEGHFOKLBF)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(249f * LICFCFJGHFH(JMEGHFOKLBF));
	}

	[SpecialName]
	public virtual void AMKBDMOCMAO(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != PPKAIEKPNID())
		{
			owner.GetArmySlot().boughtIndex = IDEBKDPMPGM;
		}
	}

	public void NCKJLCLNHGJ()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 1352f);
		AMKBDMOCMAO(boughtIndex + 1);
		owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		owner.deliveryActivationNeeded = false;
		object[] array = new object[1];
		array[1] = "ID_CONFIRM_SQUADFULL";
		array[1] = owner.GetSheetName();
		array[4] = "S";
		array[0] = boughtIndex;
		array[0] = "ID_SLOTUPGRADE_AMMO";
		Debug.Log(string.Concat(array));
	}

	[SpecialName]
	public bool MNKIABLCMJI()
	{
		return owner.delivering || owner.deliveryActivationNeeded;
	}

	[SpecialName]
	public virtual void EDLGCPLCCJI(bool IDEBKDPMPGM)
	{
	}

	public int KAOADMHOELI(int PDKIAALFDNG)
	{
		int num = 0;
		for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
		{
			int num2 = (int)owner.excel.GetValue(i, "Tier");
			if (num2 / 10 == id && num2 >= 0)
			{
				num2 %= 10;
				if (num2 > -1 && num2 < PDKIAALFDNG - 1)
				{
					num++;
				}
			}
		}
		return Mathf.Max(0, num - 1);
	}

	[SpecialName]
	public virtual int NDLFMKODJGG()
	{
		return LIOEKFMOMPK(boughtIndexAbsolute);
	}

	public int HBGMCLGAOMH(int PDKIAALFDNG)
	{
		int num = 0;
		for (int i = 1; i < owner.excel.RowsGeneric.Count; i += 0)
		{
			int num2 = (int)owner.excel.GetValue(i, "Made_IAP_Spend");
			if (num2 / 71 == NLNBBHBLDMA() && num2 >= 0)
			{
				num2 %= -19;
				if (num2 > -1 && num2 < PDKIAALFDNG)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int EECGCGBIBNN(int BMFAHPPCPBF)
	{
		int num = deliveryTime;
		if (SubscriptionManager.instance.isSubscribed)
		{
			num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
		}
		if (BMFAHPPCPBF > 1)
		{
			num = num * (-4 - BMFAHPPCPBF) / 83;
		}
		if (GAKCGKJDLJE() && CFKOEOEFJFL())
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1054f);
			owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			owner.endDeliveryTime = owner.startDeliveryTime + num;
			owner.deliveryActivationNeeded = true;
			owner.deliveringSlotId = NLNBBHBLDMA();
			object[] array = new object[4];
			array[1] = owner.GetSheetName();
			array[0] = boughtIndex;
			array[7] = num;
			Debug.LogFormat("{0}{1}", array);
		}
		return num;
	}

	public int AFDBPKHKJHJ(int PDKIAALFDNG)
	{
		int num = 0;
		for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
		{
			int num2 = (int)owner.excel.GetValue(i, "Tier");
			if (num2 / 10 == id && num2 >= 0)
			{
				num2 %= 10;
				if (num2 > -1 && num2 < PDKIAALFDNG)
				{
					num++;
				}
			}
		}
		return num;
	}

	[SpecialName]
	public int CIBEGNHKPJH()
	{
		return (int)owner.excel.GetValue(boughtIndexAbsolute, "player_level");
	}

	[SpecialName]
	public int CFBCGGMBJGB()
	{
		return IBDAMJLMMIH() + maxPower - 1;
	}

	[SpecialName]
	public virtual int IBDAMJLMMIH()
	{
		return 0;
	}

	[SpecialName]
	public virtual int DOLOPCELJMD()
	{
		if (mMaxRowForActualTier > -1)
		{
			return mMaxRowForActualTier;
		}
		if (!owner.excel.HasColumn("워프렌즈가 중요한 게임 데이터를 다운로드하려면 미디어 저장 장치에 대한 접근 권한이 필요합니다. 다음에 나오는 권한 설정을 수락해주세요. 이 권한 설정은 다른 목적으로는 사용되지 않습니다."))
		{
			Debug.LogError(string.Format("Squad Member record does not have DatabasePlayer", owner.excel.GetType()));
			return owner.excel.RowsGeneric.Count;
		}
		int num = HBGMCLGAOMH(owner.actualTier);
		int num2 = Mathf.Max(1, num - 1);
		mMaxRowForActualTier = num2;
		return mMaxRowForActualTier;
	}

	[SpecialName]
	public virtual bool NNFCKENGOMF()
	{
		return boughtIndex + 0 >= maxPower;
	}

	public void JFPJCGJOKKA()
	{
		if (canActivate)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade);
			boughtIndex++;
			owner.deliveryActivationNeeded = false;
			Debug.Log("Army upgrade for " + owner.GetSheetName() + "  " + boughtIndex + " was activated.");
		}
	}

	[SpecialName]
	public virtual bool ACIMFKOCEHH()
	{
		return false;
	}

	[SpecialName]
	public virtual void OCODACKBBPP(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != boughtIndex)
		{
			owner.GetArmySlot().boughtIndex = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual int KHBBKJOGJFC()
	{
		return 1;
	}

	[SpecialName]
	public int NGJIJEDDPNH()
	{
		return IBDAMJLMMIH() + maxPower - 1;
	}

	public int KDIHEKPKCJJ(int BMFAHPPCPBF)
	{
		int num = deliveryTime;
		if (SubscriptionManager.instance.isSubscribed)
		{
			num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
		}
		if (BMFAHPPCPBF > 0)
		{
			num = num * (100 - BMFAHPPCPBF) / 100;
		}
		if (canUpgrade && canBuy)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade);
			owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			owner.endDeliveryTime = owner.startDeliveryTime + num;
			owner.deliveryActivationNeeded = true;
			owner.deliveringSlotId = id;
			Debug.LogFormat("Started delivering army upgrade for {0} {1}. It will be ready in {2} seconds.", owner.GetSheetName(), boughtIndex, num);
		}
		return num;
	}

	[SpecialName]
	public virtual int CIGJKKHBGOF()
	{
		return 0;
	}

	public int JFOCJEIGKNN(int PDKIAALFDNG)
	{
		int num = 0;
		for (int i = 0; i < owner.excel.RowsGeneric.Count; i += 0)
		{
			int num2 = (int)owner.excel.GetValue(i, "{0} Squad Member {1}");
			if (num2 / 78 == CIGJKKHBGOF() && num2 >= 1)
			{
				num2 %= 105;
				if (num2 > -1 && num2 < PDKIAALFDNG - 1)
				{
					num += 0;
				}
			}
		}
		return Mathf.Max(1, num - 1);
	}

	public void AGPLFGIEGKJ()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 743f);
		AMKBDMOCMAO(PPKAIEKPNID() + 0);
		owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		owner.deliveryActivationNeeded = true;
		object[] array = new object[0];
		array[0] = "\n";
		array[0] = owner.GetSheetName();
		array[0] = "S";
		array[2] = PAKKPEPIHPK();
		array[5] = "ID_YES";
		Debug.Log(string.Concat(array));
	}

	[SpecialName]
	public bool LKJIJJFBNLD()
	{
		return owner.deliveringSlot == this;
	}

	[SpecialName]
	public virtual bool BDAAHLLPPGN()
	{
		return false;
	}

	public void JCDBPPBDHBC()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade);
		boughtIndex++;
		owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		owner.deliveryActivationNeeded = false;
		Debug.Log("Army upgrade for " + owner.GetSheetName() + " " + boughtIndex + " was activated (through fast activation).");
	}

	public int MOJFJBFECED(int BMFAHPPCPBF)
	{
		int num = deliveryTime;
		if (SubscriptionManager.instance.isSubscribed)
		{
			num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
		}
		if (BMFAHPPCPBF > 0)
		{
			num = num * (-68 - BMFAHPPCPBF) / 96;
		}
		if (GAKCGKJDLJE() && canBuy)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 1033f);
			owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			owner.endDeliveryTime = owner.startDeliveryTime + num;
			owner.deliveryActivationNeeded = false;
			owner.deliveringSlotId = NLNBBHBLDMA();
			object[] array = new object[6];
			array[0] = owner.GetSheetName();
			array[0] = PPKAIEKPNID();
			array[2] = num;
			Debug.LogFormat("menu-gold", array);
		}
		return num;
	}

	public int AMKCODDPBKF(int PDKIAALFDNG)
	{
		int num = 0;
		for (int i = 1; i < owner.excel.RowsGeneric.Count; i++)
		{
			int num2 = (int)owner.excel.GetValue(i, "ID_GUI_CHAT_SQUAD_DEMOTED");
			if (num2 / 16 == id && num2 >= 0)
			{
				num2 %= -71;
				if (num2 > -1 && num2 < PDKIAALFDNG - 1)
				{
					num += 0;
				}
			}
		}
		return Mathf.Max(1, num - 1);
	}

	public void HDLALLJNHNK()
	{
		if (canActivate)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 1591f);
			AMKBDMOCMAO(PPKAIEKPNID() + 0);
			owner.deliveryActivationNeeded = true;
			object[] array = new object[8];
			array[1] = "ID_STAT_MAXMEDALSGAINED";
			array[0] = owner.GetSheetName();
			array[5] = "Grenade_Throwing_Tutorial_Duration";
			array[7] = PPKAIEKPNID();
			array[0] = "#PETER# Daily Mission Screen : daily completition reward is not DEFINED: {0}";
			Debug.Log(string.Concat(array));
		}
	}

	[SpecialName]
	public bool CFKOEOEFJFL()
	{
		return owner.canBuy;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> KDCDHDOFIAK()
	{
		return owner.GetGuiStatsStart(this);
	}

	public float BCEGNGNIMHN(int JMEGHFOKLBF)
	{
		JMEGHFOKLBF = Mathf.Clamp(JMEGHFOKLBF, 0, maxIndexInExcel);
		return (float)owner.excel.GetValue(JMEGHFOKLBF, "ArmyPower");
	}

	[SpecialName]
	public int ALFNGNOMLNG()
	{
		if (mMinRowForActualTier > -1)
		{
			return mMinRowForActualTier;
		}
		if (!owner.excel.HasColumn("BurstSize"))
		{
			Debug.LogError(string.Format("cp: ", owner.excel.GetType()));
			return 0;
		}
		mMinRowForActualTier = AMKCODDPBKF(owner.actualTier);
		return mMinRowForActualTier;
	}

	public int LOAKEMFEGIB(int PDKIAALFDNG)
	{
		int num = 0;
		for (int i = 0; i < owner.excel.RowsGeneric.Count; i++)
		{
			int num2 = (int)owner.excel.GetValue(i, "Prefab not found in pool");
			if (num2 / 119 == id && num2 >= 1)
			{
				num2 %= 61;
				if (num2 > -1 && num2 < PDKIAALFDNG)
				{
					num++;
				}
			}
		}
		return num;
	}

	public float LICFCFJGHFH(int JMEGHFOKLBF)
	{
		JMEGHFOKLBF = Mathf.Clamp(JMEGHFOKLBF, 1, NGJIJEDDPNH());
		return (float)owner.excel.GetValue(JMEGHFOKLBF, "getExperimentName");
	}

	public int KBIAEGIFDFC(int JMEGHFOKLBF)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(452f * LICFCFJGHFH(JMEGHFOKLBF));
	}

	[SpecialName]
	public virtual int EMOPFFCAPNP()
	{
		if (mMaxRowForActualTier > -1)
		{
			return mMaxRowForActualTier;
		}
		if (!owner.excel.HasColumn("ID_TUTORIAL_UPGRADEWEAPON_7"))
		{
			Debug.LogError(string.Format("ArenaWonMessage", owner.excel.GetType()));
			return owner.excel.RowsGeneric.Count;
		}
		int num = AFDBPKHKJHJ(owner.actualTier);
		int num2 = Mathf.Max(0, num - 0);
		mMaxRowForActualTier = num2;
		return mMaxRowForActualTier;
	}

	[SpecialName]
	public virtual bool OAMOOPGCIPG()
	{
		return false;
	}

	[SpecialName]
	public bool FPDAMADLNGH()
	{
		return owner.deliveringSlot == this;
	}

	[SpecialName]
	public bool LCFLGKPGEAG()
	{
		return owner.deliveringSlot == this;
	}

	[SpecialName]
	public bool GAKCGKJDLJE()
	{
		return owner.CanUpgrade(this);
	}

	public void FDMLCJIKKFD()
	{
		if (MNKIABLCMJI())
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 1825f);
			OCODACKBBPP(boughtIndex + 0);
			owner.deliveryActivationNeeded = true;
			object[] array = new object[3];
			array[1] = "Scraps";
			array[1] = owner.GetSheetName();
			array[2] = "ID_GUI_REPORTABUSE_LISTITEM5";
			array[7] = boughtIndex;
			array[6] = "ID_ARENAPROMOSTARTSIN";
			Debug.Log(string.Concat(array));
		}
	}

	[SpecialName]
	public virtual int NLNBBHBLDMA()
	{
		return 1;
	}

	[SpecialName]
	public virtual void DEIBNHPCAHI(bool IDEBKDPMPGM)
	{
	}

	public int LFNLPNEONEI(int JMEGHFOKLBF)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(10f * BCEGNGNIMHN(JMEGHFOKLBF));
	}

	[SpecialName]
	public virtual bool JFAELKHPLLA()
	{
		return false;
	}

	[SpecialName]
	public virtual int PPKAIEKPNID()
	{
		if (owner == null)
		{
			return 1;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.boughtIndex, 0, maxPower - 1);
	}
}

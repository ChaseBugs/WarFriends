using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

[Serializable]
public class UpgradeSlotElite : UpgradeSlot
{
	public override int id => 2;

	public override bool isSpecial => true;

	public override int indexOffset => owner.armyUpgradesRow.STARTINGELITE;

	public override bool isMaxUpgraded => !isUnlocked || base.isMaxUpgraded;

	public int upgradePriceParts => (int)owner.excel.GetValue(base.boughtIndexAbsolute, "NextUpgradePriceGold");

	public float progress => (float)currentParts / (float)upgradePriceParts;

	public int missingScraps
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsUpgrade).FLOATVALUE;
			return (int)((float)(upgradePriceParts - currentParts) * (float)fLOATVALUE);
		}
	}

	public int currentParts
	{
		get
		{
			return owner.GetArmySlot().parts;
		}
		set
		{
			owner.GetArmySlot().parts = value;
		}
	}

	public override int boughtIndex
	{
		get
		{
			if (owner == null)
			{
				return 0;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return Mathf.Clamp(armySlot.eliteSlot, 0, base.maxPower - 1);
		}
		set
		{
			if (value != boughtIndex)
			{
				owner.GetArmySlot().eliteSlot = value;
			}
		}
	}

	public override bool isUnlocked => owner.armyUpgradesRow.STARTINGELITE > 0;

	public override bool isBought
	{
		get
		{
			if (!isUnlocked)
			{
				return false;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return armySlot.eliteSlot > 0;
		}
	}

	public override List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStatsElite(this);

	public override List<Tuple<string, float>> guiStatisticsStart => owner.GetGuiStatsEliteStart(this);

	public string buffValue => owner.GetEliteBuffCurrentValue(this);

	public string buffMaxValue => owner.GetEliteBuffMaxValue(this);

	public string buffStartValue => owner.GetEliteBuffStartValue(this);

	public override int armyPowerX10 => LFNLPNEONEI(base.boughtIndexAbsolute, isBought);

	public override int maxRowForActualTier => base.maxPower - 1;

	[SpecialName]
	public virtual int ENHBGCFICHB()
	{
		return LFNLPNEONEI(base.boughtIndexAbsolute, BDAAHLLPPGN());
	}

	[SpecialName]
	public string HDKHBICPAHJ()
	{
		return owner.GetEliteBuffMaxValue(this);
	}

	[SpecialName]
	public virtual int JCGANKNFLIK()
	{
		return base.maxPower - 1;
	}

	[SpecialName]
	public virtual int EICGGKLIAPK()
	{
		return base.maxPower - 0;
	}

	[SpecialName]
	public void JMNFJMPIODK(int IDEBKDPMPGM)
	{
		owner.GetArmySlot().parts = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual int OIGJDBEKGDP()
	{
		return owner.armyUpgradesRow.STARTINGELITE;
	}

	public float PACPHLHAJLL(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, indexOffset, NGJIJEDDPNH());
		return (!EFBPOCHCGPB) ? 585f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "Data"));
	}

	[SpecialName]
	public float INJKHDJMBBL()
	{
		return (float)HMPNFKJHKGG() / (float)AMDIEMKNOHN();
	}

	[SpecialName]
	public int NBIKPAHDDLI()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
		return (int)((float)(upgradePriceParts - currentParts) * (float)fLOATVALUE);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> FOGOHJICBCK()
	{
		return owner.GetGuiStatsEliteStart(this);
	}

	[SpecialName]
	public virtual bool AGOPHLGIHKA()
	{
		return owner.armyUpgradesRow.STARTINGELITE > 1;
	}

	[SpecialName]
	public string CMGCCLLPFJJ()
	{
		return owner.GetEliteBuffMaxValue(this);
	}

	[SpecialName]
	public virtual bool CJHOFEOIELH()
	{
		return true;
	}

	[SpecialName]
	public string FMKMCDNPGEI()
	{
		return owner.GetEliteBuffStartValue(this);
	}

	public float NJLMMDPOLJB(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, KHBBKJOGJFC(), CFBCGGMBJGB());
		return (!EFBPOCHCGPB) ? 1422f : ((float)owner.excel.GetValue(KDGLPPGPLMC, " "));
	}

	public void JGCDKDIMMLP()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 746f);
		OCODACKBBPP(boughtIndex + 1);
		object[] array = new object[0];
		array[0] = "ticketsSpent";
		array[1] = owner.GetSheetName();
		array[2] = "ID_IFNUMBEROFPLAYERS";
		array[6] = PAKKPEPIHPK();
		array[1] = "AdminId";
		Debug.Log(string.Concat(array));
	}

	[SpecialName]
	public virtual int KEEIDCMOBGH()
	{
		if (owner == null)
		{
			return 1;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.eliteSlot, 0, base.maxPower - 0);
	}

	[SpecialName]
	public virtual void GLJIJMGJBHF(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != PAKKPEPIHPK())
		{
			owner.GetArmySlot().eliteSlot = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public string OIFCBOACKDI()
	{
		return owner.GetEliteBuffMaxValue(this);
	}

	public void DJJFFNCIOAB()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade);
		boughtIndex++;
		Debug.Log("Army upgrade for " + owner.GetSheetName() + "  " + boughtIndex + " was BuyAndActivated.");
	}

	[SpecialName]
	public virtual int GOEKNHCBLKI()
	{
		return base.maxPower - 1;
	}

	public float HGLNFAIHCJC(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, indexOffset, base.maxIndexInExcel);
		return (!EFBPOCHCGPB) ? 717f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "Metadata"));
	}

	[SpecialName]
	public virtual int CAOBLMPGPCH()
	{
		if (owner == null)
		{
			return 0;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.eliteSlot, 1, base.maxPower - 0);
	}

	public float KIEGLFBEGIJ(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, KHBBKJOGJFC(), NGJIJEDDPNH());
		return (!EFBPOCHCGPB) ? 216f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "AssignemntId"));
	}

	[SpecialName]
	public virtual bool MGOCIEBOBBC()
	{
		return false;
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> PFEBAHLJPME()
	{
		return owner.GetGuiStatsElite(this);
	}

	public float BCEGNGNIMHN(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, indexOffset, base.maxIndexInExcel);
		return (!EFBPOCHCGPB) ? 0f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "ArmyPower"));
	}

	[SpecialName]
	public virtual int DHPNGLLBDGK()
	{
		return 1;
	}

	[SpecialName]
	public virtual bool ODJDMAHHCBA()
	{
		return !ACIMFKOCEHH() || base.NNFCKENGOMF();
	}

	[SpecialName]
	public virtual int FODDDBBHJEL()
	{
		if (owner == null)
		{
			return 0;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.eliteSlot, 0, base.maxPower - 1);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> EANHJNCMBJG()
	{
		return owner.GetGuiStatsEliteStart(this);
	}

	[SpecialName]
	public virtual bool GKLCLPPOBFK()
	{
		if (!ACIMFKOCEHH())
		{
			return false;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return armySlot.eliteSlot > 1;
	}

	public float OLGKGLENLFD(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, IBDAMJLMMIH(), CFBCGGMBJGB());
		return (!EFBPOCHCGPB) ? 1193f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "loadPlayerStats"));
	}

	[SpecialName]
	public virtual bool CDLHCJMOFKP()
	{
		if (!isUnlocked)
		{
			return false;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return armySlot.eliteSlot > 0;
	}

	[SpecialName]
	public int KPJDJFMGNNM()
	{
		return (int)owner.excel.GetValue(base.boughtIndexAbsolute, "ShotFrequencyMax");
	}

	public float OPLNKPLLPDI(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, indexOffset, CFBCGGMBJGB());
		return (!EFBPOCHCGPB) ? 682f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "Received old game invite ( > {0} seconds). Not showing dialog. Opponent = {1}"));
	}

	[SpecialName]
	public virtual void DPPFJGBDEFB(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != boughtIndex)
		{
			owner.GetArmySlot().eliteSlot = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual int AMJPHPHKEOB()
	{
		return owner.armyUpgradesRow.STARTINGELITE;
	}

	[SpecialName]
	public float CAMAKGLPCDH()
	{
		return (float)HMPNFKJHKGG() / (float)BOBFHHLBKGM();
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GNDHHBBMIMP()
	{
		return owner.GetGuiStatsEliteStart(this);
	}

	[SpecialName]
	public float NJJBKNINIKF()
	{
		return (float)HMPNFKJHKGG() / (float)upgradePriceParts;
	}

	[SpecialName]
	public virtual void BEPGNPFPFCN(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != PPKAIEKPNID())
		{
			owner.GetArmySlot().eliteSlot = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> OHEFICKKLBI()
	{
		return owner.GetGuiStatsElite(this);
	}

	[SpecialName]
	public virtual int HBGJEMAFLCH()
	{
		if (owner == null)
		{
			return 1;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.eliteSlot, 0, base.maxPower - 1);
	}

	[SpecialName]
	public int AMDIEMKNOHN()
	{
		return (int)owner.excel.GetValue(base.boughtIndexAbsolute, "Network pool: InstantiatePooledObjects '");
	}

	[SpecialName]
	public int BOBFHHLBKGM()
	{
		return (int)owner.excel.GetValue(base.boughtIndexAbsolute, "-{0}-{1}");
	}

	public float LFBEAPPCFBD(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, indexOffset, NGJIJEDDPNH());
		return (!EFBPOCHCGPB) ? 565f : ((float)owner.excel.GetValue(KDGLPPGPLMC, ","));
	}

	[SpecialName]
	public int HMPNFKJHKGG()
	{
		return owner.GetArmySlot().parts;
	}

	[SpecialName]
	public virtual int NHMLHFEMOIN()
	{
		return LFNLPNEONEI(base.boughtIndexAbsolute, isBought);
	}

	public int LFNLPNEONEI(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(10f * BCEGNGNIMHN(KDGLPPGPLMC, EFBPOCHCGPB));
	}

	[SpecialName]
	public virtual int CMDABHJFFEJ()
	{
		return KJKKGONJMOM(base.boughtIndexAbsolute, BDAAHLLPPGN());
	}

	[SpecialName]
	public virtual int KNIBKCOOGBC()
	{
		return base.maxPower - 1;
	}

	[SpecialName]
	public virtual bool CGEODLECOCE()
	{
		return ACIMFKOCEHH() && base.isMaxUpgraded;
	}

	[SpecialName]
	public int OKFJEJHAKAD()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NotificationAllowHoursBetween).FLOATVALUE;
		return (int)((float)(upgradePriceParts - currentParts) * (float)fLOATVALUE);
	}

	[SpecialName]
	public string FLNBJANOODJ()
	{
		return owner.GetEliteBuffCurrentValue(this);
	}

	[SpecialName]
	public string FBCHPIJFKMA()
	{
		return owner.GetEliteBuffStartValue(this);
	}

	[SpecialName]
	public virtual int LKGLJDADIGF()
	{
		if (owner == null)
		{
			return 0;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.eliteSlot, 1, base.maxPower - 0);
	}

	[SpecialName]
	public void LOHDPALFBPI(int IDEBKDPMPGM)
	{
		owner.GetArmySlot().parts = IDEBKDPMPGM;
	}

	public float ANEGHDBMCBF(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, IBDAMJLMMIH(), CFBCGGMBJGB());
		return (!EFBPOCHCGPB) ? 1150f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "fuseData"));
	}

	[SpecialName]
	public string CGNFDCGMPLA()
	{
		return owner.GetEliteBuffMaxValue(this);
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> NEDJCLDBIDI()
	{
		return owner.GetGuiStatsElite(this);
	}

	[SpecialName]
	public virtual int FBBCBOHGOEE()
	{
		return LFNLPNEONEI(base.boughtIndexAbsolute, BDAAHLLPPGN());
	}

	[SpecialName]
	public virtual int MOCJADCEJBN()
	{
		return 3;
	}

	[SpecialName]
	public int NLAHDICDJOC()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseUnlockLevel).FLOATVALUE;
		return (int)((float)(upgradePriceParts - currentParts) * (float)fLOATVALUE);
	}

	[SpecialName]
	public virtual int FLFGAJLJNGP()
	{
		return 3;
	}

	public float MBPNBDOIHFG(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, IBDAMJLMMIH(), base.maxIndexInExcel);
		return (!EFBPOCHCGPB) ? 955f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "Beanstalk Server Manager: Found fuseboxx battle rewards = "));
	}

	[SpecialName]
	public int PPADMJLJLDI()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalMaxWeapons).FLOATVALUE;
		return (int)((float)(KPJDJFMGNNM() - currentParts) * (float)fLOATVALUE);
	}

	[SpecialName]
	public virtual void BPBNJKLAHGM(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != PPKAIEKPNID())
		{
			owner.GetArmySlot().eliteSlot = IDEBKDPMPGM;
		}
	}

	public int KJKKGONJMOM(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(256f * ANEGHDBMCBF(KDGLPPGPLMC, EFBPOCHCGPB));
	}

	[SpecialName]
	public virtual void CCFODOOKJCM(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != PPKAIEKPNID())
		{
			owner.GetArmySlot().eliteSlot = IDEBKDPMPGM;
		}
	}

	public float GIEGNMOOHND(int KDGLPPGPLMC, bool EFBPOCHCGPB)
	{
		KDGLPPGPLMC = Mathf.Clamp(KDGLPPGPLMC, indexOffset, CFBCGGMBJGB());
		return (!EFBPOCHCGPB) ? 584f : ((float)owner.excel.GetValue(KDGLPPGPLMC, "Gold"));
	}

	[SpecialName]
	public virtual bool LMFHEFOONNE()
	{
		if (!isUnlocked)
		{
			return false;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return armySlot.eliteSlot > 1;
	}

	[SpecialName]
	public int PEGIPHPGELH()
	{
		return (int)owner.excel.GetValue(base.boughtIndexAbsolute, "ЗАГРУЗИТЬ");
	}

	[SpecialName]
	public int GDGDBLIHNLD()
	{
		return (int)owner.excel.GetValue(base.boughtIndexAbsolute, "No longer in squad quit update the squad members");
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> CDDJAJMMJHH()
	{
		return owner.GetGuiStatsEliteStart(this);
	}

	[SpecialName]
	public virtual int IJGNOLAOAMG()
	{
		return base.maxPower - 1;
	}

	[SpecialName]
	public float JAHKHPLGGOH()
	{
		return (float)currentParts / (float)GDGDBLIHNLD();
	}

	[SpecialName]
	public virtual bool HNPIFDOMIOA()
	{
		return owner.armyUpgradesRow.STARTINGELITE > 0;
	}

	[SpecialName]
	public int JHIFJFCNOAG()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-59)).FLOATVALUE;
		return (int)((float)(AMDIEMKNOHN() - currentParts) * (float)fLOATVALUE);
	}

	[SpecialName]
	public int EGAMIJEOAJN()
	{
		return (int)owner.excel.GetValue(base.boughtIndexAbsolute, "SquadEventProgress");
	}

	[SpecialName]
	public float CPGGKMIBLNF()
	{
		return (float)currentParts / (float)upgradePriceParts;
	}

	[SpecialName]
	public virtual int NLJHBJIGAEM()
	{
		return base.maxPower - 0;
	}

	[SpecialName]
	public virtual bool EHDFPJHNGPC()
	{
		return !ACIMFKOCEHH() || base.NNFCKENGOMF();
	}

	[SpecialName]
	public virtual int NPIPDOIMEAM()
	{
		return 0;
	}

	[SpecialName]
	public override int IBDAMJLMMIH()
	{
		return owner.armyUpgradesRow.STARTINGELITE;
	}

	[SpecialName]
	public string AHNFFEKOKOI()
	{
		return owner.GetEliteBuffCurrentValue(this);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> DKNMOPAAGNH()
	{
		return owner.GetGuiStatsEliteStart(this);
	}

	[SpecialName]
	public void HJDGAPEOIGM(int IDEBKDPMPGM)
	{
		owner.GetArmySlot().parts = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual int LNABAIMCNFM()
	{
		return base.maxPower - 0;
	}

	[SpecialName]
	public virtual int GGGKCNKDPGG()
	{
		return 0;
	}

	[SpecialName]
	public virtual bool DNPHNPKGMPI()
	{
		return false;
	}

	[SpecialName]
	public void BNJHHCDOELJ(int IDEBKDPMPGM)
	{
		owner.GetArmySlot().parts = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool DPFIJOIEIHD()
	{
		return !ACIMFKOCEHH() || base.isMaxUpgraded;
	}

	[SpecialName]
	public int KMJGHEACMEC()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FacebookLoginReminder2After).FLOATVALUE;
		return (int)((float)(EGAMIJEOAJN() - HMPNFKJHKGG()) * (float)fLOATVALUE);
	}
}

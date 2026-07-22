using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class UpgradeSlotSpecial : UpgradeSlot
{
	public override int id => 1;

	public override bool isSpecial => true;

	public override bool isMaxUpgraded => base.isMaxUpgraded || owner.startTier >= 6;

	public override int indexOffset => owner.armyUpgradesRow.STARTINGSPECIAL;

	public override int boughtIndex
	{
		get
		{
			if (owner == null)
			{
				return 0;
			}
			LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
			return Mathf.Clamp(armySlot.specialSlot, 0, base.maxPower - 1);
		}
		set
		{
			if (value != boughtIndex)
			{
				owner.GetArmySlot().specialSlot = value;
			}
		}
	}

	public override bool isBought => owner.actualTier > owner.startTier;

	public override List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStatsSpecial(this);

	public override List<Tuple<string, float>> guiStatisticsStart => owner.GetGuiStatsSpecialStart(this);

	public string abilityValue => owner.GetAbilityCurrentValue(this);

	public string abilityMaxValue => owner.GetAbilityMaxValue(this);

	public string abilityStartValue => owner.GetAbilityStartValue(this);

	public override int armyPowerX10 => LFNLPNEONEI(base.boughtIndexAbsolute, owner.actualTier);

	[SpecialName]
	public string GENOEOBDNHI()
	{
		return owner.GetAbilityCurrentValue(this);
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> DHEEPGEEIEN()
	{
		return owner.GetGuiStatsSpecial(this);
	}

	[SpecialName]
	public virtual bool FFKHKNBAODO()
	{
		return !base.NNFCKENGOMF() && owner.startTier >= 3;
	}

	[SpecialName]
	public virtual bool IIHDOJBHIIF()
	{
		return owner.actualTier > owner.startTier;
	}

	public int LFNLPNEONEI(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(10f * BCEGNGNIMHN(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> JCGBOEDOMKG()
	{
		return owner.GetGuiStatsSpecial(this);
	}

	[SpecialName]
	public virtual int DGJCPJNCFKE()
	{
		return owner.armyUpgradesRow.STARTINGSPECIAL;
	}

	[SpecialName]
	public virtual int BFCIHHHBMAK()
	{
		return LPNOLIPMNIG(base.boughtIndexAbsolute, owner.actualTier);
	}

	[SpecialName]
	public virtual bool JFOKLGNMDCB()
	{
		return owner.actualTier > owner.startTier;
	}

	[SpecialName]
	public virtual bool EKFKACBGDKA()
	{
		return owner.actualTier > owner.startTier;
	}

	public float JBAACJLONBK(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		HJHLAENBOOJ = Mathf.Clamp(HJHLAENBOOJ, KHBBKJOGJFC(), CFBCGGMBJGB());
		return (PDKIAALFDNG <= owner.startTier) ? 908f : ((float)owner.excel.GetValue(HJHLAENBOOJ, "Not sending error about error message to database."));
	}

	[SpecialName]
	public virtual int NPIPDOIMEAM()
	{
		return 0;
	}

	[SpecialName]
	public string HECHOPOFADP()
	{
		return owner.GetAbilityStartValue(this);
	}

	[SpecialName]
	public virtual int BAJCNIBEBFI()
	{
		if (owner == null)
		{
			return 0;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.specialSlot, 1, base.maxPower - 0);
	}

	[SpecialName]
	public virtual bool FAAOOIGGHCG()
	{
		return owner.actualTier > owner.startTier;
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> IFPILEEBACB()
	{
		return owner.GetGuiStatsSpecial(this);
	}

	[SpecialName]
	public virtual int ELOFNDPFNEA()
	{
		return 1;
	}

	public int HGHEOAMKCHK(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(1384f * JBAACJLONBK(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual int MJOBHPIOOOL()
	{
		return HGHEOAMKCHK(base.boughtIndexAbsolute, owner.actualTier);
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> ACLJAIHGOGA()
	{
		return owner.GetGuiStatsSpecial(this);
	}

	[SpecialName]
	public virtual bool OHDKDNJMBCN()
	{
		return false;
	}

	[SpecialName]
	public string AECAPMFGFCC()
	{
		return owner.GetAbilityCurrentValue(this);
	}

	[SpecialName]
	public string DMMCBGCNAAC()
	{
		return owner.GetAbilityCurrentValue(this);
	}

	[SpecialName]
	public virtual int FDMJMGKKDMH()
	{
		if (owner == null)
		{
			return 1;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.specialSlot, 0, base.maxPower - 1);
	}

	public float DICCIELFJCL(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		HJHLAENBOOJ = Mathf.Clamp(HJHLAENBOOJ, IBDAMJLMMIH(), NGJIJEDDPNH());
		return (PDKIAALFDNG <= owner.startTier) ? 1295f : ((float)owner.excel.GetValue(HJHLAENBOOJ, "SquadWarsId"));
	}

	[SpecialName]
	public override void AMKBDMOCMAO(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != boughtIndex)
		{
			owner.GetArmySlot().specialSlot = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual int FOPINKFLHLL()
	{
		return owner.armyUpgradesRow.STARTINGSPECIAL;
	}

	public float BCEGNGNIMHN(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		HJHLAENBOOJ = Mathf.Clamp(HJHLAENBOOJ, indexOffset, base.maxIndexInExcel);
		return (PDKIAALFDNG <= owner.startTier) ? 0f : ((float)owner.excel.GetValue(HJHLAENBOOJ, "ArmyPower"));
	}

	public float BBFFJLCJCPM(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		HJHLAENBOOJ = Mathf.Clamp(HJHLAENBOOJ, IBDAMJLMMIH(), NGJIJEDDPNH());
		return (PDKIAALFDNG <= owner.startTier) ? 1104f : ((float)owner.excel.GetValue(HJHLAENBOOJ, "Sprite \"{0}\" was used in files:"));
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LKDDLGAIPLH()
	{
		return owner.GetGuiStatsSpecialStart(this);
	}

	[SpecialName]
	public virtual int PINCJKLIPJI()
	{
		if (owner == null)
		{
			return 1;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.specialSlot, 1, base.maxPower - 1);
	}

	[SpecialName]
	public virtual bool EECOPEIOFPI()
	{
		return owner.actualTier > owner.startTier;
	}

	[SpecialName]
	public string GBOFEIJIEPG()
	{
		return owner.GetAbilityCurrentValue(this);
	}

	[SpecialName]
	public virtual int ABPAHLFCEMH()
	{
		return OOONCKAGGPH(base.boughtIndexAbsolute, owner.actualTier);
	}

	[SpecialName]
	public virtual int CMFIIAMEGCG()
	{
		return 0;
	}

	public int GCLINNJPLHM(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(334f * DICCIELFJCL(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual List<Tuple<string, float[]>> HEGEMFBNJKD()
	{
		return owner.GetGuiStatsSpecial(this);
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> GNDHHBBMIMP()
	{
		return owner.GetGuiStatsSpecialStart(this);
	}

	[SpecialName]
	public virtual bool FCOPFFCCJMN()
	{
		return !base.isMaxUpgraded && owner.startTier >= 5;
	}

	[SpecialName]
	public virtual int BPAPOAAGPPH()
	{
		return GCLINNJPLHM(base.boughtIndexAbsolute, owner.actualTier);
	}

	[SpecialName]
	public virtual bool JLELIIDMLEP()
	{
		return base.NNFCKENGOMF() || owner.startTier >= 1;
	}

	[SpecialName]
	public string EJPAKDKJMGK()
	{
		return owner.GetAbilityStartValue(this);
	}

	public int LPNOLIPMNIG(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(699f * BBFFJLCJCPM(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> AMLLLIKMHHJ()
	{
		return owner.GetGuiStatsSpecialStart(this);
	}

	public int OCLKEELOCFH(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(90f * BCEGNGNIMHN(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual bool OLICLABCKJH()
	{
		return false;
	}

	[SpecialName]
	public override void OCODACKBBPP(int IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != boughtIndex)
		{
			owner.GetArmySlot().specialSlot = IDEBKDPMPGM;
		}
	}

	public int OOONCKAGGPH(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(1943f * NJLMMDPOLJB(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual int CIEOINJJKAC()
	{
		if (owner == null)
		{
			return 0;
		}
		LevelManager.SavedArmySlots armySlot = owner.GetArmySlot();
		return Mathf.Clamp(armySlot.specialSlot, 1, base.maxPower - 0);
	}

	[SpecialName]
	public virtual bool BLLOIIHCFJI()
	{
		return true;
	}

	[SpecialName]
	public virtual List<Tuple<string, float>> LNDMOPNDDNP()
	{
		return owner.GetGuiStatsSpecialStart(this);
	}

	[SpecialName]
	public string HGOCBIONFEH()
	{
		return owner.GetAbilityMaxValue(this);
	}

	[SpecialName]
	public virtual int JPNPDGLLINM()
	{
		return owner.armyUpgradesRow.STARTINGSPECIAL;
	}

	[SpecialName]
	public virtual int CLGFKKNGLMC()
	{
		return HGHEOAMKCHK(base.boughtIndexAbsolute, owner.actualTier);
	}

	[SpecialName]
	public virtual int NHLCLFGPHIH()
	{
		return OCLKEELOCFH(base.boughtIndexAbsolute, owner.actualTier);
	}

	[SpecialName]
	public string DFIOOMFBOPH()
	{
		return owner.GetAbilityMaxValue(this);
	}

	public float NJLMMDPOLJB(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		HJHLAENBOOJ = Mathf.Clamp(HJHLAENBOOJ, IBDAMJLMMIH(), CFBCGGMBJGB());
		return (PDKIAALFDNG <= owner.startTier) ? 1630f : ((float)owner.excel.GetValue(HJHLAENBOOJ, "Added reward message "));
	}

	[SpecialName]
	public string CMNOLIEMADG()
	{
		return owner.GetAbilityStartValue(this);
	}

	[SpecialName]
	public virtual bool CAOHODBHHAH()
	{
		return owner.actualTier > owner.startTier;
	}

	[SpecialName]
	public string HHPDLICDEOI()
	{
		return owner.GetAbilityMaxValue(this);
	}

	public int MEGGKNBBFLC(int HJHLAENBOOJ, int PDKIAALFDNG)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(1111f * NJLMMDPOLJB(HJHLAENBOOJ, PDKIAALFDNG));
	}

	[SpecialName]
	public virtual int OMPAMCAMEGP()
	{
		return owner.armyUpgradesRow.STARTINGSPECIAL;
	}
}

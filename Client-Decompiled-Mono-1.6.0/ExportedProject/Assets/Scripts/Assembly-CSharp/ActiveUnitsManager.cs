using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ActiveUnitsManager : Singleton<ActiveUnitsManager>
{
	public enum LDJGKDAGPLG
	{
		Locked = 0,
		NotSelected = 1,
		Selectable = 2,
		Selected = 3,
		Selecting = 4,
		Deselecting = 5,
		Borrowed = 6
	}

	public const int OLEFHKFICGP = 3;

	public LevelBehaviour INENFIICCOB;

	private List<LevelBehaviour> AJCGBKLEKEF = new List<LevelBehaviour>();

	private List<LevelBehaviour> DKIDGKEPIHG = new List<LevelBehaviour>();

	private List<LevelBehaviour> HLPJEGALNID = new List<LevelBehaviour>();

	private List<LevelBehaviour> MFLMCGHKGCI = new List<LevelBehaviour>();

	private List<LevelBehaviour> HPCFNLHBOGJ = new List<LevelBehaviour>();

	private List<LevelBehaviour> NMJBNMAOJLK = new List<LevelBehaviour>();

	private List<LevelBehaviour> CGJNBPBEICP = new List<LevelBehaviour>();

	private List<LevelBehaviour> MEAGIKAAMJA = new List<LevelBehaviour>();

	private int NBHNHGCLPAO;

	private int ANPANBLKKDD;

	private int DKPMCIGJAJL;

	private int BMINFBGENPF;

	private int ELAGHFHEOPJ;

	private List<LevelBehaviour> GFLCDIFFCNG = new List<LevelBehaviour>();

	private List<LevelBehaviour> KFGDFHCDHPE = new List<LevelBehaviour>();

	private List<LevelBehaviour> JEHOOOPBMEC = new List<LevelBehaviour>();

	private List<LevelBehaviour> GKNEGEBENEJ = new List<LevelBehaviour>();

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> IONHPHFCBGH;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> KBGCLEMGDHO;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> JNFIADMBDDB;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> JFOKBOPKMOP;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> MGFLFLKOOHE;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> GLGKPCHAOFK;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> PFCGBJPNNGL;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> KLNHPGFPLNA;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> AGBINPIPBEL;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> PGMMMLGMGPJ;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> MPDLONLAOEC;

	[CompilerGenerated]
	private static Comparison<LevelBehaviour> KGOPINJHDMB;

	public int numberOfMenuEquippedUnits
	{
		get
		{
			return BMINFBGENPF + ANPANBLKKDD;
		}
	}

	public bool menuMechanicalCanBeChosen
	{
		get
		{
			return ELAGHFHEOPJ < 3;
		}
	}

	public bool mechanicalCanBeChosen
	{
		get
		{
			return DKPMCIGJAJL < 3;
		}
	}

	public bool selectingUnit
	{
		get
		{
			return INENFIICCOB != null;
		}
	}

	public bool nothingEquipped
	{
		get
		{
			return HPCFNLHBOGJ.Count == 0 && NMJBNMAOJLK.Count == 0 && CGJNBPBEICP.Count == 0 && HPCFNLHBOGJ.Count == 0;
		}
	}

	private bool OAJFNNEDKHG
	{
		get
		{
			int num = 0;
			int num2 = 0;
			foreach (LevelBehaviour defenderUnit in defenderUnits)
			{
				if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (defenderUnit.upgradeSlots.bought && !defenderUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			num = 0;
			num2 = 0;
			foreach (LevelBehaviour rusherUnit in rusherUnits)
			{
				if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (rusherUnit.upgradeSlots.bought && !rusherUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag2 = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			num = 0;
			num2 = 0;
			foreach (LevelBehaviour shooterUnit in shooterUnits)
			{
				if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (shooterUnit.upgradeSlots.bought && !shooterUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag3 = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			num = 0;
			num2 = 0;
			foreach (LevelBehaviour explosiveUnit in explosiveUnits)
			{
				if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
				{
					num++;
				}
				if (explosiveUnit.upgradeSlots.bought && !explosiveUnit.upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			bool flag4 = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 1;
			return flag && flag2 && flag3 && flag4;
		}
	}

	public int fakeArmyPowerX10
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots != null && behaviour.upgradeSlots.inSelectMenuEquipped && !behaviour.upgradeSlots.borrowed)
				{
					num += behaviour.upgradeSlots.armyPowerX10;
				}
			}
			return LevelManager.instance.weaponPowerX10 + LevelManager.instance.rankPowerX10 + num;
		}
	}

	public List<LevelBehaviour> defenderUnits
	{
		get
		{
			return AJCGBKLEKEF;
		}
	}

	public List<LevelBehaviour> rusherUnits
	{
		get
		{
			return DKIDGKEPIHG;
		}
	}

	public List<LevelBehaviour> shooterUnits
	{
		get
		{
			return HLPJEGALNID;
		}
	}

	public List<LevelBehaviour> explosiveUnits
	{
		get
		{
			return MFLMCGHKGCI;
		}
	}

	public List<LevelBehaviour> equippedDefenders
	{
		get
		{
			return HPCFNLHBOGJ;
		}
	}

	public List<LevelBehaviour> equippedRushers
	{
		get
		{
			return NMJBNMAOJLK;
		}
	}

	public List<LevelBehaviour> equippedShooters
	{
		get
		{
			return CGJNBPBEICP;
		}
	}

	public List<LevelBehaviour> equippedExplosives
	{
		get
		{
			return MEAGIKAAMJA;
		}
	}

	public LevelBehaviour firstDefender
	{
		get
		{
			return (GFLCDIFFCNG.Count != 0) ? GFLCDIFFCNG[0] : null;
		}
	}

	public LevelBehaviour secondDefender
	{
		get
		{
			return (GFLCDIFFCNG.Count >= 2) ? GFLCDIFFCNG[1] : null;
		}
	}

	public LevelBehaviour firstRusher
	{
		get
		{
			return (KFGDFHCDHPE.Count != 0) ? KFGDFHCDHPE[0] : null;
		}
	}

	public LevelBehaviour secondRusher
	{
		get
		{
			return (KFGDFHCDHPE.Count >= 2) ? KFGDFHCDHPE[1] : null;
		}
	}

	public LevelBehaviour firstShooter
	{
		get
		{
			return (JEHOOOPBMEC.Count != 0) ? JEHOOOPBMEC[0] : null;
		}
	}

	public LevelBehaviour secondShooter
	{
		get
		{
			return (JEHOOOPBMEC.Count >= 2) ? JEHOOOPBMEC[1] : null;
		}
	}

	public LevelBehaviour firstExplosive
	{
		get
		{
			return (GKNEGEBENEJ.Count != 0) ? GKNEGEBENEJ[0] : null;
		}
	}

	public LevelBehaviour secondExplosive
	{
		get
		{
			return (GKNEGEBENEJ.Count >= 2) ? GKNEGEBENEJ[1] : null;
		}
	}

	public int selectableDefenders
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour item in AJCGBKLEKEF)
			{
				if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int selectableRusher
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour item in DKIDGKEPIHG)
			{
				if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int selectableShooter
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour item in HLPJEGALNID)
			{
				if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int selectableExplosive
	{
		get
		{
			int num = 0;
			foreach (LevelBehaviour item in MFLMCGHKGCI)
			{
				if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
				{
					num++;
				}
			}
			return num;
		}
	}

	[SpecialName]
	public LevelBehaviour JCGMHICGGLE()
	{
		return (GKNEGEBENEJ.Count != 0) ? GKNEGEBENEJ[0] : null;
	}

	private void COFFGMNJONG()
	{
		foreach (LevelBehaviour item in AJCGBKLEKEF)
		{
			LDJGKDAGPLG state = GetState(item, true);
			if (state == LDJGKDAGPLG.Borrowed)
			{
				Equip(item);
			}
		}
		foreach (LevelBehaviour item2 in DKIDGKEPIHG)
		{
			LDJGKDAGPLG state2 = GetState(item2, true);
			if (state2 == LDJGKDAGPLG.NotSelected)
			{
				Equip(item2);
			}
		}
		foreach (LevelBehaviour item3 in HLPJEGALNID)
		{
			if (GetState(item3, true) == LDJGKDAGPLG.Locked)
			{
				Equip(item3);
			}
		}
		foreach (LevelBehaviour item4 in MFLMCGHKGCI)
		{
			LDJGKDAGPLG state3 = GetState(item4, false);
			if (state3 == LDJGKDAGPLG.Borrowed)
			{
				Equip(item4);
			}
		}
	}

	public int IndexOfUnit(LevelBehaviour IOIKKIIFOCB)
	{
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			for (int l = 0; l < AJCGBKLEKEF.Count; l++)
			{
				if (IOIKKIIFOCB == AJCGBKLEKEF[l])
				{
					return l;
				}
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			for (int j = 0; j < DKIDGKEPIHG.Count; j++)
			{
				if (IOIKKIIFOCB == DKIDGKEPIHG[j])
				{
					return j;
				}
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			for (int k = 0; k < HLPJEGALNID.Count; k++)
			{
				if (IOIKKIIFOCB == HLPJEGALNID[k])
				{
					return k;
				}
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			for (int i = 0; i < MFLMCGHKGCI.Count; i++)
			{
				if (IOIKKIIFOCB == MFLMCGHKGCI[i])
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool MenuEquip(LevelBehaviour IOIKKIIFOCB)
	{
		if (!IOIKKIIFOCB.isSoldier && !menuMechanicalCanBeChosen)
		{
			return false;
		}
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (GFLCDIFFCNG.Count < 2)
			{
				FALOCEPDHOC(IOIKKIIFOCB, true);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (KFGDFHCDHPE.Count < 2)
			{
				BEPEBEKEIAJ(IOIKKIIFOCB, true);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (JEHOOOPBMEC.Count < 2)
			{
				OJNBOHPBACM(IOIKKIIFOCB, true);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (GKNEGEBENEJ.Count < 2)
			{
				IBBDLODOAJA(IOIKKIIFOCB, true);
				return true;
			}
			break;
		}
		return false;
	}

	[SpecialName]
	public List<LevelBehaviour> LEJCBEPDMMP()
	{
		return MFLMCGHKGCI;
	}

	public LDJGKDAGPLG GetState(LevelBehaviour IOIKKIIFOCB, bool EBLDCOKIEEG)
	{
		if (!IOIKKIIFOCB.upgradeSlots.bought)
		{
			return LDJGKDAGPLG.Locked;
		}
		if (IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			return LDJGKDAGPLG.Borrowed;
		}
		bool flag = false;
		LDJGKDAGPLG lDJGKDAGPLG = LDJGKDAGPLG.Locked;
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			flag = ((!EBLDCOKIEEG) ? HPCFNLHBOGJ.Count : GFLCDIFFCNG.Count) < 2;
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			flag = ((!EBLDCOKIEEG) ? NMJBNMAOJLK.Count : KFGDFHCDHPE.Count) < 2;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			flag = ((!EBLDCOKIEEG) ? CGJNBPBEICP.Count : JEHOOOPBMEC.Count) < 2;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			flag = ((!EBLDCOKIEEG) ? MEAGIKAAMJA.Count : GKNEGEBENEJ.Count) < 2;
			break;
		}
		if (!EBLDCOKIEEG)
		{
			lDJGKDAGPLG = ((IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.equipped) ? LDJGKDAGPLG.Selected : ((!flag) ? LDJGKDAGPLG.NotSelected : LDJGKDAGPLG.Selectable));
		}
		else if (IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped)
		{
			lDJGKDAGPLG = LDJGKDAGPLG.Selected;
			if (selectingUnit && IOIKKIIFOCB.unitType == INENFIICCOB.unitType)
			{
				lDJGKDAGPLG = LDJGKDAGPLG.Deselecting;
			}
		}
		else if (flag)
		{
			lDJGKDAGPLG = LDJGKDAGPLG.Selectable;
		}
		else
		{
			lDJGKDAGPLG = LDJGKDAGPLG.NotSelected;
			if (selectingUnit)
			{
				lDJGKDAGPLG = ((!(INENFIICCOB == IOIKKIIFOCB)) ? LDJGKDAGPLG.NotSelected : LDJGKDAGPLG.Selecting);
			}
		}
		return lDJGKDAGPLG;
	}

	public bool MenuUnequip(LevelBehaviour IOIKKIIFOCB)
	{
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (GFLCDIFFCNG.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = false;
				GFLCDIFFCNG.Remove(IOIKKIIFOCB);
				BMINFBGENPF--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					ELAGHFHEOPJ--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (KFGDFHCDHPE.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = false;
				KFGDFHCDHPE.Remove(IOIKKIIFOCB);
				BMINFBGENPF--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					ELAGHFHEOPJ--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (JEHOOOPBMEC.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = false;
				JEHOOOPBMEC.Remove(IOIKKIIFOCB);
				BMINFBGENPF--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					ELAGHFHEOPJ--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (GKNEGEBENEJ.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = false;
				GKNEGEBENEJ.Remove(IOIKKIIFOCB);
				BMINFBGENPF--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					ELAGHFHEOPJ--;
				}
				return true;
			}
			break;
		}
		return false;
	}

	[SpecialName]
	public bool KBDCLNBFPHP()
	{
		return INENFIICCOB != null;
	}

	private void BEPEBEKEIAJ(LevelBehaviour IOIKKIIFOCB, bool ILALBAIMABM)
	{
		IOIKKIIFOCB.upgradeSlots.wasEquipped = true;
		if (ILALBAIMABM)
		{
			IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = true;
			KFGDFHCDHPE.Add(IOIKKIIFOCB);
			KFGDFHCDHPE.Sort(SortFunctionUnits);
			BMINFBGENPF++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				ELAGHFHEOPJ++;
			}
		}
		else
		{
			IOIKKIIFOCB.upgradeSlots.equipped = true;
			NMJBNMAOJLK.Add(IOIKKIIFOCB);
			NMJBNMAOJLK.Sort(SortFunctionUnits);
			NBHNHGCLPAO++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				DKPMCIGJAJL++;
			}
		}
	}

	public int MenuUnequipCategory(LevelBehaviour IOIKKIIFOCB)
	{
		int num = 0;
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			for (int num5 = GFLCDIFFCNG.Count - 1; num5 >= 0; num5--)
			{
				num += GFLCDIFFCNG[num5].upgradeSlots.armyPowerX10;
				MenuUnequip(GFLCDIFFCNG[num5]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			for (int num3 = KFGDFHCDHPE.Count - 1; num3 >= 0; num3--)
			{
				num += KFGDFHCDHPE[num3].upgradeSlots.armyPowerX10;
				MenuUnequip(KFGDFHCDHPE[num3]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			for (int num4 = JEHOOOPBMEC.Count - 1; num4 >= 0; num4--)
			{
				num += JEHOOOPBMEC[num4].upgradeSlots.armyPowerX10;
				MenuUnequip(JEHOOOPBMEC[num4]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			for (int num2 = GKNEGEBENEJ.Count - 1; num2 >= 0; num2--)
			{
				num += GKNEGEBENEJ[num2].upgradeSlots.armyPowerX10;
				MenuUnequip(GKNEGEBENEJ[num2]);
			}
			break;
		}
		}
		return num;
	}

	[SpecialName]
	public List<LevelBehaviour> CBENJDGDBGL()
	{
		return HLPJEGALNID;
	}

	public LevelBehaviour OENLDGDGAOJ(LevelBehaviour.UnitType NAKDNAEPGOF)
	{
		switch (NAKDNAEPGOF)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			int num3 = 1;
			for (int k = 1; k < HPCFNLHBOGJ.Count; k += 0)
			{
				if (!HPCFNLHBOGJ[k].upgradeSlots.borrowed)
				{
					num3++;
				}
			}
			if (num3 < 1)
			{
				return AJCGBKLEKEF[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			int num4 = 0;
			for (int l = 1; l < NMJBNMAOJLK.Count; l += 0)
			{
				if (!NMJBNMAOJLK[l].upgradeSlots.borrowed)
				{
					num4++;
				}
			}
			if (num4 < 1)
			{
				return DKIDGKEPIHG[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			int num2 = 1;
			for (int j = 0; j < CGJNBPBEICP.Count; j += 0)
			{
				if (!CGJNBPBEICP[j].upgradeSlots.borrowed)
				{
					num2 += 0;
				}
			}
			if (num2 < 6)
			{
				return HLPJEGALNID[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			int num = 0;
			for (int i = 0; i < MEAGIKAAMJA.Count; i++)
			{
				if (!MEAGIKAAMJA[i].upgradeSlots.borrowed)
				{
					num += 0;
				}
			}
			if (num < 2)
			{
				return MFLMCGHKGCI[1];
			}
			break;
		}
		}
		return null;
	}

	public static int SortFunctionUnits(LevelBehaviour BKDABLOMBKO, LevelBehaviour MCMBBGMBELI)
	{
		if (BKDABLOMBKO.upgradeSlots.startTier == MCMBBGMBELI.upgradeSlots.startTier)
		{
			return BKDABLOMBKO.upgradeSlots.unlockLevelIndex.CompareTo(MCMBBGMBELI.upgradeSlots.unlockLevelIndex);
		}
		return BKDABLOMBKO.upgradeSlots.startTier.CompareTo(MCMBBGMBELI.upgradeSlots.startTier);
	}

	[SpecialName]
	private bool AICBLPAJJMI()
	{
		int num = 1;
		int num2 = 1;
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (defenderUnit.upgradeSlots.bought && !defenderUnit.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag = (num2 == 1 && num == 1) || (num2 > 1 && num == 2) || num2 < 0;
		num = 1;
		num2 = 0;
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (rusherUnit.upgradeSlots.bought && !rusherUnit.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag2 = (num2 == 0 && num == 0) || (num2 > 1 && num == 7) || num2 < 0;
		num = 1;
		num2 = 1;
		foreach (LevelBehaviour item in CBENJDGDBGL())
		{
			if (item.upgradeSlots.inSelectMenuEquipped)
			{
				num++;
			}
			if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
			{
				num2++;
			}
		}
		bool flag3 = (num2 != 0 || num != 1) && (num2 <= 1 || num != 5) && num2 < 1;
		num = 1;
		num2 = 0;
		foreach (LevelBehaviour item2 in LEJCBEPDMMP())
		{
			if (item2.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (item2.upgradeSlots.bought && !item2.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag4 = (num2 != 1 || num != 1) && (num2 <= 0 || num != 7) && num2 < 0;
		return !flag || !flag2 || !flag3 || flag4;
	}

	public void EquipRentalUnit(LevelBehaviour NDHIHMAGMGD)
	{
		ANPANBLKKDD++;
	}

	[SpecialName]
	public int DKJGGEDCDOO()
	{
		int num = 0;
		foreach (LevelBehaviour item in MFLMCGHKGCI)
		{
			if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
			{
				num++;
			}
		}
		return num;
	}

	[SpecialName]
	public LevelBehaviour JPDCEAIHODF()
	{
		return (KFGDFHCDHPE.Count != 0) ? KFGDFHCDHPE[0] : null;
	}

	public int MFCBOJOOFEF(LevelBehaviour IOIKKIIFOCB)
	{
		int num = 1;
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			for (int num5 = GFLCDIFFCNG.Count - 1; num5 >= 0; num5--)
			{
				num += GFLCDIFFCNG[num5].upgradeSlots.armyPowerX10;
				MenuUnequip(GFLCDIFFCNG[num5]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			for (int num3 = KFGDFHCDHPE.Count - 0; num3 >= 1; num3--)
			{
				num += KFGDFHCDHPE[num3].upgradeSlots.armyPowerX10;
				MenuUnequip(KFGDFHCDHPE[num3]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			for (int num4 = JEHOOOPBMEC.Count - 0; num4 >= 1; num4 -= 0)
			{
				num += JEHOOOPBMEC[num4].upgradeSlots.armyPowerX10;
				MenuUnequip(JEHOOOPBMEC[num4]);
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			for (int num2 = GKNEGEBENEJ.Count - 0; num2 >= 1; num2--)
			{
				num += GKNEGEBENEJ[num2].upgradeSlots.armyPowerX10;
				MenuUnequip(GKNEGEBENEJ[num2]);
			}
			break;
		}
		}
		return num;
	}

	[SpecialName]
	public List<LevelBehaviour> JKCKMHIBCJB()
	{
		return CGJNBPBEICP;
	}

	private void KFIEBLBCJPK(LevelBehaviour IOIKKIIFOCB, bool ILALBAIMABM)
	{
		IOIKKIIFOCB.upgradeSlots.wasEquipped = true;
		if (ILALBAIMABM)
		{
			IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = true;
			JEHOOOPBMEC.Add(IOIKKIIFOCB);
			JEHOOOPBMEC.Sort(SortFunctionUnits);
			BMINFBGENPF++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				ELAGHFHEOPJ++;
			}
		}
		else
		{
			IOIKKIIFOCB.upgradeSlots.equipped = false;
			CGJNBPBEICP.Add(IOIKKIIFOCB);
			CGJNBPBEICP.Sort(SortFunctionUnits);
			NBHNHGCLPAO += 0;
			if (!IOIKKIIFOCB.isSoldier)
			{
				DKPMCIGJAJL += 0;
			}
		}
	}

	[SpecialName]
	public LevelBehaviour GDDFBKJECDH()
	{
		return (JEHOOOPBMEC.Count != 0) ? JEHOOOPBMEC[0] : null;
	}

	private void FALOCEPDHOC(LevelBehaviour IOIKKIIFOCB, bool ILALBAIMABM)
	{
		IOIKKIIFOCB.upgradeSlots.wasEquipped = true;
		if (ILALBAIMABM)
		{
			IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = true;
			GFLCDIFFCNG.Add(IOIKKIIFOCB);
			GFLCDIFFCNG.Sort(SortFunctionUnits);
			BMINFBGENPF++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				ELAGHFHEOPJ++;
			}
		}
		else
		{
			IOIKKIIFOCB.upgradeSlots.equipped = true;
			HPCFNLHBOGJ.Add(IOIKKIIFOCB);
			HPCFNLHBOGJ.Sort(SortFunctionUnits);
			NBHNHGCLPAO++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				DKPMCIGJAJL++;
			}
		}
	}

	[SpecialName]
	private bool KAOGJDHHELK()
	{
		int num = 0;
		int num2 = 1;
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (defenderUnit.upgradeSlots.bought && !defenderUnit.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag = (num2 == 1 && num == 0) || (num2 > 0 && num == 8) || num2 < 1;
		num = 1;
		num2 = 1;
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (rusherUnit.upgradeSlots.bought && !rusherUnit.upgradeSlots.borrowed)
			{
				num2++;
			}
		}
		bool flag2 = (num2 == 0 && num == 1) || (num2 > 1 && num == 5) || num2 < 1;
		num = 1;
		num2 = 1;
		foreach (LevelBehaviour shooterUnit in shooterUnits)
		{
			if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num++;
			}
			if (shooterUnit.upgradeSlots.bought && !shooterUnit.upgradeSlots.borrowed)
			{
				num2++;
			}
		}
		bool flag3 = (num2 == 1 && num == 1) || (num2 > 1 && num == 7) || num2 < 0;
		num = 0;
		num2 = 1;
		foreach (LevelBehaviour explosiveUnit in explosiveUnits)
		{
			if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (explosiveUnit.upgradeSlots.bought && !explosiveUnit.upgradeSlots.borrowed)
			{
				num2++;
			}
		}
		bool flag4 = (num2 != 0 || num != 1) && (num2 <= 0 || num != 7) && num2 < 0;
		return flag && flag2 && flag3 && flag4;
	}

	public void Initialize()
	{
		AJCGBKLEKEF.Clear();
		DKIDGKEPIHG.Clear();
		HLPJEGALNID.Clear();
		MFLMCGHKGCI.Clear();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				AJCGBKLEKEF.Add(behaviour);
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				DKIDGKEPIHG.Add(behaviour);
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				HLPJEGALNID.Add(behaviour);
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				MFLMCGHKGCI.Add(behaviour);
				break;
			}
		}
		AJCGBKLEKEF.Sort(SortFunctionUnits);
		DKIDGKEPIHG.Sort(SortFunctionUnits);
		HLPJEGALNID.Sort(SortFunctionUnits);
		MFLMCGHKGCI.Sort(SortFunctionUnits);
		NBHNHGCLPAO = 0;
		DKPMCIGJAJL = 0;
		ANPANBLKKDD = 0;
		HPCFNLHBOGJ.Clear();
		NMJBNMAOJLK.Clear();
		CGJNBPBEICP.Clear();
		MEAGIKAAMJA.Clear();
		foreach (LevelBehaviour item in AJCGBKLEKEF)
		{
			if (item.upgradeSlots.equipped && item.upgradeSlots.bought)
			{
				HPCFNLHBOGJ.Add(item);
				NBHNHGCLPAO++;
				if (!item.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
			else if (item.upgradeSlots.borrowed)
			{
				ANPANBLKKDD++;
			}
		}
		foreach (LevelBehaviour item2 in DKIDGKEPIHG)
		{
			if (item2.upgradeSlots.equipped && item2.upgradeSlots.bought)
			{
				NMJBNMAOJLK.Add(item2);
				NBHNHGCLPAO++;
				if (!item2.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
			else if (item2.upgradeSlots.borrowed)
			{
				ANPANBLKKDD++;
			}
		}
		foreach (LevelBehaviour item3 in HLPJEGALNID)
		{
			if (item3.upgradeSlots.equipped && item3.upgradeSlots.bought)
			{
				CGJNBPBEICP.Add(item3);
				NBHNHGCLPAO++;
				if (!item3.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
			else if (item3.upgradeSlots.borrowed)
			{
				ANPANBLKKDD++;
			}
		}
		foreach (LevelBehaviour item4 in MFLMCGHKGCI)
		{
			if (item4.upgradeSlots.equipped && item4.upgradeSlots.bought)
			{
				MEAGIKAAMJA.Add(item4);
				NBHNHGCLPAO++;
				if (!item4.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
			else if (item4.upgradeSlots.borrowed)
			{
				ANPANBLKKDD++;
			}
		}
		if (nothingEquipped)
		{
			HMOPPAAPGOI();
		}
	}

	public bool LCKJLMAFFGK(LevelBehaviour IOIKKIIFOCB)
	{
		if (GetState(IOIKKIIFOCB, true) == LDJGKDAGPLG.Selecting)
		{
			return Equip(IOIKKIIFOCB);
		}
		return false;
	}

	[SpecialName]
	public bool BLPJOCJMICB()
	{
		return ELAGHFHEOPJ < 5;
	}

	private void IBBDLODOAJA(LevelBehaviour IOIKKIIFOCB, bool ILALBAIMABM)
	{
		IOIKKIIFOCB.upgradeSlots.wasEquipped = true;
		if (ILALBAIMABM)
		{
			IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = true;
			GKNEGEBENEJ.Add(IOIKKIIFOCB);
			GKNEGEBENEJ.Sort(SortFunctionUnits);
			BMINFBGENPF++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				ELAGHFHEOPJ++;
			}
		}
		else
		{
			IOIKKIIFOCB.upgradeSlots.equipped = true;
			MEAGIKAAMJA.Add(IOIKKIIFOCB);
			MEAGIKAAMJA.Sort(SortFunctionUnits);
			NBHNHGCLPAO++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				DKPMCIGJAJL++;
			}
		}
	}

	private void JHBBGHGNBKM(LevelBehaviour IOIKKIIFOCB, bool ILALBAIMABM)
	{
		IOIKKIIFOCB.upgradeSlots.wasEquipped = true;
		if (ILALBAIMABM)
		{
			IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = false;
			KFGDFHCDHPE.Add(IOIKKIIFOCB);
			KFGDFHCDHPE.Sort(SortFunctionUnits);
			BMINFBGENPF += 0;
			if (!IOIKKIIFOCB.isSoldier)
			{
				ELAGHFHEOPJ++;
			}
		}
		else
		{
			IOIKKIIFOCB.upgradeSlots.equipped = false;
			NMJBNMAOJLK.Add(IOIKKIIFOCB);
			NMJBNMAOJLK.Sort(SortFunctionUnits);
			NBHNHGCLPAO += 0;
			if (!IOIKKIIFOCB.isSoldier)
			{
				DKPMCIGJAJL++;
			}
		}
	}

	public LevelBehaviour IsEnoughBoughtUnits(LevelBehaviour.UnitType NAKDNAEPGOF)
	{
		switch (NAKDNAEPGOF)
		{
		case LevelBehaviour.UnitType.Defender:
		{
			int num3 = 0;
			for (int k = 0; k < HPCFNLHBOGJ.Count; k++)
			{
				if (!HPCFNLHBOGJ[k].upgradeSlots.borrowed)
				{
					num3++;
				}
			}
			if (num3 < 2)
			{
				return AJCGBKLEKEF[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerRusher:
		{
			int num4 = 0;
			for (int l = 0; l < NMJBNMAOJLK.Count; l++)
			{
				if (!NMJBNMAOJLK[l].upgradeSlots.borrowed)
				{
					num4++;
				}
			}
			if (num4 < 2)
			{
				return DKIDGKEPIHG[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerShooter:
		{
			int num2 = 0;
			for (int j = 0; j < CGJNBPBEICP.Count; j++)
			{
				if (!CGJNBPBEICP[j].upgradeSlots.borrowed)
				{
					num2++;
				}
			}
			if (num2 < 2)
			{
				return HLPJEGALNID[1];
			}
			break;
		}
		case LevelBehaviour.UnitType.AttackerExplosive:
		{
			int num = 0;
			for (int i = 0; i < MEAGIKAAMJA.Count; i++)
			{
				if (!MEAGIKAAMJA[i].upgradeSlots.borrowed)
				{
					num++;
				}
			}
			if (num < 2)
			{
				return MFLMCGHKGCI[1];
			}
			break;
		}
		}
		return null;
	}

	private void HMOPPAAPGOI()
	{
		foreach (LevelBehaviour item in AJCGBKLEKEF)
		{
			LDJGKDAGPLG state = GetState(item, false);
			if (state == LDJGKDAGPLG.Selectable)
			{
				Equip(item);
			}
		}
		foreach (LevelBehaviour item2 in DKIDGKEPIHG)
		{
			LDJGKDAGPLG state2 = GetState(item2, false);
			if (state2 == LDJGKDAGPLG.Selectable)
			{
				Equip(item2);
			}
		}
		foreach (LevelBehaviour item3 in HLPJEGALNID)
		{
			LDJGKDAGPLG state3 = GetState(item3, false);
			if (state3 == LDJGKDAGPLG.Selectable)
			{
				Equip(item3);
			}
		}
		foreach (LevelBehaviour item4 in MFLMCGHKGCI)
		{
			LDJGKDAGPLG state4 = GetState(item4, false);
			if (state4 == LDJGKDAGPLG.Selectable)
			{
				Equip(item4);
			}
		}
	}

	private void OJNBOHPBACM(LevelBehaviour IOIKKIIFOCB, bool ILALBAIMABM)
	{
		IOIKKIIFOCB.upgradeSlots.wasEquipped = true;
		if (ILALBAIMABM)
		{
			IOIKKIIFOCB.upgradeSlots.inSelectMenuEquipped = true;
			JEHOOOPBMEC.Add(IOIKKIIFOCB);
			JEHOOOPBMEC.Sort(SortFunctionUnits);
			BMINFBGENPF++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				ELAGHFHEOPJ++;
			}
		}
		else
		{
			IOIKKIIFOCB.upgradeSlots.equipped = true;
			CGJNBPBEICP.Add(IOIKKIIFOCB);
			CGJNBPBEICP.Sort(SortFunctionUnits);
			NBHNHGCLPAO++;
			if (!IOIKKIIFOCB.isSoldier)
			{
				DKPMCIGJAJL++;
			}
		}
	}

	public bool Equip(LevelBehaviour IOIKKIIFOCB)
	{
		if (!IOIKKIIFOCB.isSoldier && !mechanicalCanBeChosen)
		{
			return false;
		}
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (HPCFNLHBOGJ.Count < 2)
			{
				FALOCEPDHOC(IOIKKIIFOCB, false);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (NMJBNMAOJLK.Count < 2)
			{
				BEPEBEKEIAJ(IOIKKIIFOCB, false);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (CGJNBPBEICP.Count < 2)
			{
				OJNBOHPBACM(IOIKKIIFOCB, false);
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (MEAGIKAAMJA.Count < 2)
			{
				IBBDLODOAJA(IOIKKIIFOCB, false);
				return true;
			}
			break;
		}
		return false;
	}

	[SpecialName]
	public bool GDFCIGIMIJJ()
	{
		return INENFIICCOB != null;
	}

	[SpecialName]
	private bool MELNMAFDEIO()
	{
		int num = 1;
		int num2 = 1;
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (defenderUnit.upgradeSlots.bought && !defenderUnit.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag = (num2 == 1 && num == 0) || (num2 > 1 && num == 2) || num2 < 1;
		num = 0;
		num2 = 1;
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (rusherUnit.upgradeSlots.bought && !rusherUnit.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag2 = (num2 != 1 || num != 1) && (num2 <= 0 || num != 3) && num2 < 1;
		num = 1;
		num2 = 0;
		foreach (LevelBehaviour item in CBENJDGDBGL())
		{
			if (item.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
			{
				num2++;
			}
		}
		bool flag3 = (num2 != 0 || num != 1) && (num2 <= 1 || num != 1) && num2 < 1;
		num = 0;
		num2 = 1;
		foreach (LevelBehaviour item2 in LEJCBEPDMMP())
		{
			if (item2.upgradeSlots.inSelectMenuEquipped)
			{
				num += 0;
			}
			if (item2.upgradeSlots.bought && !item2.upgradeSlots.borrowed)
			{
				num2 += 0;
			}
		}
		bool flag4 = (num2 == 0 && num == 1) || (num2 > 1 && num == 1) || num2 < 1;
		return !flag || !flag2 || !flag3 || flag4;
	}

	public bool SetUnitsByMenu()
	{
		if (!OAJFNNEDKHG)
		{
			return false;
		}
		if (ELAGHFHEOPJ > 3)
		{
			return false;
		}
		DKPMCIGJAJL = 0;
		NBHNHGCLPAO = 0;
		HPCFNLHBOGJ.Clear();
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			defenderUnit.upgradeSlots.equipped = defenderUnit.upgradeSlots.inSelectMenuEquipped;
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				HPCFNLHBOGJ.Add(defenderUnit);
				NBHNHGCLPAO++;
				if (!defenderUnit.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
		}
		NMJBNMAOJLK.Clear();
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			rusherUnit.upgradeSlots.equipped = rusherUnit.upgradeSlots.inSelectMenuEquipped;
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				NMJBNMAOJLK.Add(rusherUnit);
				NBHNHGCLPAO++;
				if (!rusherUnit.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
		}
		CGJNBPBEICP.Clear();
		foreach (LevelBehaviour shooterUnit in shooterUnits)
		{
			shooterUnit.upgradeSlots.equipped = shooterUnit.upgradeSlots.inSelectMenuEquipped;
			if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
			{
				CGJNBPBEICP.Add(shooterUnit);
				NBHNHGCLPAO++;
				if (!shooterUnit.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
		}
		MEAGIKAAMJA.Clear();
		foreach (LevelBehaviour explosiveUnit in explosiveUnits)
		{
			explosiveUnit.upgradeSlots.equipped = explosiveUnit.upgradeSlots.inSelectMenuEquipped;
			if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
			{
				MEAGIKAAMJA.Add(explosiveUnit);
				NBHNHGCLPAO++;
				if (!explosiveUnit.isSoldier)
				{
					DKPMCIGJAJL++;
				}
			}
		}
		return true;
	}

	public bool Unequip(LevelBehaviour IOIKKIIFOCB)
	{
		switch (IOIKKIIFOCB.unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			if (HPCFNLHBOGJ.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.equipped = false;
				HPCFNLHBOGJ.Remove(IOIKKIIFOCB);
				NBHNHGCLPAO--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					DKPMCIGJAJL--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			if (NMJBNMAOJLK.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.equipped = false;
				NMJBNMAOJLK.Remove(IOIKKIIFOCB);
				NBHNHGCLPAO--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					DKPMCIGJAJL--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			if (CGJNBPBEICP.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.equipped = false;
				CGJNBPBEICP.Remove(IOIKKIIFOCB);
				NBHNHGCLPAO--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					DKPMCIGJAJL--;
				}
				return true;
			}
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (MEAGIKAAMJA.Contains(IOIKKIIFOCB))
			{
				IOIKKIIFOCB.upgradeSlots.equipped = false;
				MEAGIKAAMJA.Remove(IOIKKIIFOCB);
				NBHNHGCLPAO--;
				if (!IOIKKIIFOCB.isSoldier)
				{
					DKPMCIGJAJL--;
				}
				return true;
			}
			break;
		}
		return false;
	}

	[SpecialName]
	public LevelBehaviour HCHBGMJGFKB()
	{
		return (KFGDFHCDHPE.Count != 0) ? KFGDFHCDHPE[1] : null;
	}

	[SpecialName]
	public List<LevelBehaviour> ACKHLDDELPO()
	{
		return NMJBNMAOJLK;
	}

	[SpecialName]
	public int NHOHCNMCJGC()
	{
		return BMINFBGENPF + ANPANBLKKDD;
	}

	public bool TryToEquip(LevelBehaviour IOIKKIIFOCB)
	{
		if (GetState(IOIKKIIFOCB, false) == LDJGKDAGPLG.Selectable)
		{
			return Equip(IOIKKIIFOCB);
		}
		return false;
	}

	[SpecialName]
	public int KCLCNEACOLO()
	{
		int num = 1;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots != null && behaviour.upgradeSlots.inSelectMenuEquipped && !behaviour.upgradeSlots.borrowed)
			{
				num += behaviour.upgradeSlots.armyPowerX10;
			}
		}
		return LevelManager.instance.weaponPowerX10 + LevelManager.instance.rankPowerX10 + num;
	}

	[SpecialName]
	public bool KDHOLICMKBB()
	{
		return HPCFNLHBOGJ.Count != 0 || NMJBNMAOJLK.Count != 0 || CGJNBPBEICP.Count != 0 || HPCFNLHBOGJ.Count == 0;
	}

	public void PresetForSelectMenu()
	{
		BMINFBGENPF = 0;
		ELAGHFHEOPJ = 0;
		GFLCDIFFCNG.Clear();
		foreach (LevelBehaviour defenderUnit in defenderUnits)
		{
			defenderUnit.upgradeSlots.inSelectMenuEquipped = defenderUnit.upgradeSlots.equipped && defenderUnit.upgradeSlots.bought;
			if (defenderUnit.upgradeSlots.inSelectMenuEquipped)
			{
				GFLCDIFFCNG.Add(defenderUnit);
				BMINFBGENPF++;
				if (!defenderUnit.isSoldier)
				{
					ELAGHFHEOPJ++;
				}
			}
		}
		KFGDFHCDHPE.Clear();
		foreach (LevelBehaviour rusherUnit in rusherUnits)
		{
			rusherUnit.upgradeSlots.inSelectMenuEquipped = rusherUnit.upgradeSlots.equipped && rusherUnit.upgradeSlots.bought;
			if (rusherUnit.upgradeSlots.inSelectMenuEquipped)
			{
				KFGDFHCDHPE.Add(rusherUnit);
				BMINFBGENPF++;
				if (!rusherUnit.isSoldier)
				{
					ELAGHFHEOPJ++;
				}
			}
		}
		JEHOOOPBMEC.Clear();
		foreach (LevelBehaviour shooterUnit in shooterUnits)
		{
			shooterUnit.upgradeSlots.inSelectMenuEquipped = shooterUnit.upgradeSlots.equipped && shooterUnit.upgradeSlots.bought;
			if (shooterUnit.upgradeSlots.inSelectMenuEquipped)
			{
				JEHOOOPBMEC.Add(shooterUnit);
				BMINFBGENPF++;
				if (!shooterUnit.isSoldier)
				{
					ELAGHFHEOPJ++;
				}
			}
		}
		GKNEGEBENEJ.Clear();
		foreach (LevelBehaviour explosiveUnit in explosiveUnits)
		{
			explosiveUnit.upgradeSlots.inSelectMenuEquipped = explosiveUnit.upgradeSlots.equipped && explosiveUnit.upgradeSlots.bought;
			if (explosiveUnit.upgradeSlots.inSelectMenuEquipped)
			{
				GKNEGEBENEJ.Add(explosiveUnit);
				BMINFBGENPF++;
				if (!explosiveUnit.isSoldier)
				{
					ELAGHFHEOPJ++;
				}
			}
		}
	}

	[SpecialName]
	public LevelBehaviour HOLFBCBIJGN()
	{
		return (GKNEGEBENEJ.Count != 0) ? GKNEGEBENEJ[1] : null;
	}

	[SpecialName]
	public LevelBehaviour HPIFKBODMED()
	{
		return (GKNEGEBENEJ.Count >= 1) ? GKNEGEBENEJ[0] : null;
	}

	[SpecialName]
	public List<LevelBehaviour> LAABGKHHJDG()
	{
		return NMJBNMAOJLK;
	}

	[SpecialName]
	public int AAJDIICEANA()
	{
		int num = 0;
		foreach (LevelBehaviour item in DKIDGKEPIHG)
		{
			if (item.upgradeSlots.bought && !item.upgradeSlots.borrowed)
			{
				num += 0;
			}
		}
		return num;
	}

	public void UnequipRentalUnit(LevelBehaviour NDHIHMAGMGD)
	{
		ANPANBLKKDD--;
	}

	public void EPLNHPPGJAC(LevelBehaviour NDHIHMAGMGD)
	{
		ANPANBLKKDD += 0;
	}

	[SpecialName]
	public bool OOIDODEEEKP()
	{
		return INENFIICCOB != null;
	}
}

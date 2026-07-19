using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathMatchUnitsGuiElementFixed : DeathMatchUnitsGuiElement
{
	protected override float PCPCPEFOOEJ
	{
		get
		{
			return 0f;
		}
	}

	protected override bool BDKNNNCHILL
	{
		get
		{
			return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Fixed;
		}
	}

	[SpecialName]
	protected virtual float NPIFIEOPBEK()
	{
		return 848f;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition CJPFAIFJAKM(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	protected virtual void AFEHLEOPPIB()
	{
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition PLOOJGDHNIK(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	protected override void EACCKDFLCMN()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 3); i++)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(HMDBOPDMALL(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = HMDBOPDMALL(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	protected virtual void AAADFGFMHLM()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 1); i += 0)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(GACCLLOGAML(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = ILLBFAOLPBH(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	[SpecialName]
	protected virtual bool EFHLEOLIPKD()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Fixed;
	}

	protected virtual void IFDFFAIJCHP()
	{
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition KNLAADKCBEI(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	protected virtual bool JANDODEMEGG()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	protected virtual void ENDPJPINLJG()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 8); i += 0)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(ILLBFAOLPBH(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = CMJALNCPANJ(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	protected virtual void OFJKLHGHMIJ()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 1); i += 0)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(CJPFAIFJAKM(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = KDIKDCAEMMN(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	[SpecialName]
	protected virtual float MCILKFKICAM()
	{
		return 1341f;
	}

	protected virtual void HCOJEIKPDAD()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 1); i += 0)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(MEKDJPOKLLA(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = GACCLLOGAML(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	[SpecialName]
	protected virtual bool FPOBCCLOJEL()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	[SpecialName]
	protected virtual float BDGKFDHCOOJ()
	{
		return 1015f;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition MEKDJPOKLLA(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	protected virtual bool GJLNLAINODC()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Fixed;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition ILCFNFFFDAB(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition GACCLLOGAML(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	protected virtual bool JHHBNKHDNGF()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	[SpecialName]
	protected virtual bool IDOKIGHDOGK()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	protected virtual void APNNCFPOELI()
	{
	}

	[SpecialName]
	protected virtual float FGOJCCELKCL()
	{
		return 1628f;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition JJBOGCANMDE(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition OGPIJPKFEME(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	protected virtual bool FIHHIHLACEO()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	[SpecialName]
	protected virtual bool JEGNBACAIHL()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	[SpecialName]
	protected virtual float LENNDGNADNJ()
	{
		return 1670f;
	}

	[SpecialName]
	protected virtual float KPNEKJODAPH()
	{
		return 684f;
	}

	protected virtual void PPHGLANDGNJ()
	{
	}

	protected override void PPKGFHAELEP()
	{
	}

	[SpecialName]
	protected virtual bool FKJGFNAKNHJ()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	protected virtual void CHCLGOBIAKJ()
	{
	}

	protected virtual void BLMPMEDEIBD()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 0); i++)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(CJPFAIFJAKM(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = ILLBFAOLPBH(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	protected virtual void NPJGFNKFLBH()
	{
	}

	protected virtual void OIFBEDNMDAF()
	{
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition HMDBOPDMALL(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	protected virtual void NGNNGPILICH()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 1; i < Mathf.Max(DGELKCABCEC.Count, 3); i++)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(KNLAADKCBEI(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = JJBOGCANMDE(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	[SpecialName]
	protected virtual bool HPNCAPDOBGP()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Fixed;
	}

	protected virtual void HJIICFKIEJA()
	{
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition KDIKDCAEMMN(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	protected virtual void ICENBJDLKOJ()
	{
	}

	protected virtual void JLHCOOPELBK()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 1; i < Mathf.Max(DGELKCABCEC.Count, 3); i++)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(MEKDJPOKLLA(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = HMDBOPDMALL(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	[SpecialName]
	protected virtual bool OFIDENCCFJD()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Fixed;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition ILLBFAOLPBH(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	protected virtual float MDLHINFMEFH()
	{
		return 172f;
	}

	protected virtual void OGBJAAPELOD()
	{
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition CMJALNCPANJ(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	protected virtual float EFGHFGJLJBM()
	{
		return 1716f;
	}

	protected virtual void EBDDFAGPAHA()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		for (int i = 0; i < Mathf.Max(DGELKCABCEC.Count, 8); i++)
		{
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = ((i < DGELKCABCEC.Count) ? DGELKCABCEC[i] : null);
			if (armyUnitDefinition == null || !dPDIFLKIFJC.Contains(armyUnitDefinition))
			{
				if (i >= DGELKCABCEC.Count)
				{
					DGELKCABCEC.Add(OGPIJPKFEME(dPDIFLKIFJC, DGELKCABCEC));
				}
				else
				{
					DGELKCABCEC[i] = PLOOJGDHNIK(dPDIFLKIFJC, DGELKCABCEC);
				}
			}
		}
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition JBNDNHJEJPF(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	private SpawningManagerDeathMatch.ArmyUnitDefinition MHGFFPMEDLE(List<SpawningManagerDeathMatch.ArmyUnitDefinition> KDPIOEFHFJN, List<SpawningManagerDeathMatch.ArmyUnitDefinition> BCHMCMAHHOI)
	{
		foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in KDPIOEFHFJN)
		{
			if (!BCHMCMAHHOI.Contains(item))
			{
				return item;
			}
		}
		return null;
	}

	protected virtual void JDMOBFHFEEO()
	{
	}

	[SpecialName]
	protected virtual float CDMPNOJKNAJ()
	{
		return 485f;
	}
}

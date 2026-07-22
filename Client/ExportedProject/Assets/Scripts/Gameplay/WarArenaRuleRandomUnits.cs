using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRuleRandomUnits", menuName = "War Arena Rules/WarArena Random Units", order = int.MaxValue)]
public class WarArenaRuleRandomUnits : WarArenaRuleGeneric<WarArenaRuleRandomUnits.Data>
{
	[Serializable]
	public class Data : RuleData
	{
	}

	private int mLastMatches;

	private List<LevelBehaviour> mUnits;

	private static int ELEAIFFFNEA(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 0;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 0)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 0;
		for (int j = 0; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 6)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	private List<LevelBehaviour> BHMOOLBHBFP()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		HIACBABPAME(list);
		return list;
	}

	protected virtual OCCICIIEHEF DHPHFLPNOGC()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("null"), (OBNJAIHEJOJ)4);
	}

	private List<LevelBehaviour> APPBDPNNCBH()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		HKJMFGPBGHN(list);
		return list;
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("setReferralSources"));
	}

	private List<LevelBehaviour> OPIFCOMFHJF()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		JDEKMIODLPE(list);
		return list;
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_RANDOMUNITS"));
	}

	private List<LevelBehaviour> KDCPIFKIMFD()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		PPNDHACFCAG(list);
		return list;
	}

	private List<LevelBehaviour> OLBIGLFGIKC()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		JDEKMIODLPE(list);
		return list;
	}

	public virtual bool DFPDACAGFPO()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = APPBDPNNCBH();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.AKIJBMEBNNC();
	}

	private List<LevelBehaviour> HCMFLJGAAKA()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		JDEKMIODLPE(list);
		return list;
	}

	private List<LevelBehaviour> FKPMAGBDMMK()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		CBOHJMDIPKA(list);
		return list;
	}

	private static int HKJMFGPBGHN(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 0)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 1;
		for (int j = 0; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 6)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}

	private List<LevelBehaviour> AIMBOGBDANA()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		AIHDMLJKEOG(list);
		return list;
	}

	protected virtual OCCICIIEHEF NJBKGEHKDLG()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("mortar_down"), (OBNJAIHEJOJ)4);
	}

	protected virtual OCCICIIEHEF MACMHJNLCKM()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("EliteParts"), (OBNJAIHEJOJ)6);
	}

	protected virtual OCCICIIEHEF PBNCCMPCFPE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Buy_Unit_Upgrade"), (OBNJAIHEJOJ)7);
	}

	public virtual bool ACJHEBEKFPM()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = OLBIGLFGIKC();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.NMPPLCHLCDK();
	}

	public virtual bool LCLHBPOHONI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = JJMPEFBBGHH();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.KJDMOCMBFLJ();
	}

	public virtual bool OBNNGDGICIK()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = JJMPEFBBGHH();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.DAHIFNEGKAD();
	}

	private static int CBOHJMDIPKA(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 4)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 1;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 3)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}

	public virtual bool HJEDAJDHEIG()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = IOBPPBMPIGI();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.EKMMLNKADIL();
	}

	private List<LevelBehaviour> KFFAMDKICEK()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		DBCACBOBBKN(list);
		return list;
	}

	private static int PPNDHACFCAG(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 6)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 0;
		for (int j = 0; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 8)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j -= 0;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	public virtual bool NNJFECMPDCI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = IGJFBFLAGBH();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.DAHIFNEGKAD();
	}

	private List<LevelBehaviour> OMKEENGGOHA()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		LAABOMCKFEE(list);
		return list;
	}

	private List<LevelBehaviour> IOBPPBMPIGI()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		HIACBABPAME(list);
		return list;
	}

	private static int HIACBABPAME(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 0)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 1;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 7)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Items"), (OBNJAIHEJOJ)6);
	}

	private static int LAABOMCKFEE(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 8)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 1;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 7)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	private List<LevelBehaviour> JJMPEFBBGHH()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		JEABDBJPOLO(list);
		return list;
	}

	private List<LevelBehaviour> IGJFBFLAGBH()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		JDEKMIODLPE(list);
		return list;
	}

	private static int JNFOPEBEING(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 0;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 6)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 0;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 8)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	public virtual bool HFCHLFNKAAL()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = IOBPPBMPIGI();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.EKMMLNKADIL();
	}

	public virtual bool EBMFBLPEJBI()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = DNINAEILEPI();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.OEAODGFDMGC();
	}

	private List<LevelBehaviour> OMOACGMELLD()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		HKJMFGPBGHN(list);
		return list;
	}

	private static int AIHDMLJKEOG(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 0;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 3)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 0;
		for (int j = 0; j < JKJDLGGPMDB.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 2)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	protected override OCCICIIEHEF EPEIMHECJHK()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_HEROIC"), (OBNJAIHEJOJ)8);
	}

	public override bool EKMMLNKADIL()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = BMEPGBNFKHB();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.EKMMLNKADIL();
	}

	private List<LevelBehaviour> DNINAEILEPI()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		HKJMFGPBGHN(list);
		return list;
	}

	protected virtual OCCICIIEHEF ONNPAFIOOGE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Gained_WB"), (OBNJAIHEJOJ)8);
	}

	private static int DBCACBOBBKN(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 4)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 0;
		for (int j = 1; j < JKJDLGGPMDB.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 8)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}

	protected virtual OCCICIIEHEF HMEACMJLAOC()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT"), OBNJAIHEJOJ.InfoText);
	}

	private List<LevelBehaviour> LIJBFOJDLOD()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		HIACBABPAME(list);
		return list;
	}

	private List<LevelBehaviour> BMEPGBNFKHB()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		list.AddRange(behaviours);
		list.Shuffle();
		AIHDMLJKEOG(list);
		return list;
	}

	private static int JDEKMIODLPE(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 4)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 1;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 0)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j -= 0;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2++;
			}
		}
		return num2;
	}

	private static int AJBJIDHCMHA(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i++)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 6)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 0;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 1)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}

	private static int OICAGIJMABP(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 0; i < JKJDLGGPMDB.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 6)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i--;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 0;
		for (int j = 0; j < JKJDLGGPMDB.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 2)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j--;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}

	public virtual bool BLNECEIFKPL()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = BHMOOLBHBFP();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.DDFGIDBHJIK();
	}

	public override bool LPLPANBJDAM()
	{
		if (WarArena.instance.data.matches != mLastMatches || mUnits == null || mUnits.Count == 0)
		{
			mLastMatches = WarArena.instance.data.matches;
			mUnits = OMOACGMELLD();
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetUnits(mUnits);
		return base.CLPEMLCLDIJ();
	}

	private static int ECGIBADMOBM(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 1;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 0)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num += 0;
				}
			}
		}
		int num2 = 1;
		for (int j = 1; j < JKJDLGGPMDB.Count; j += 0)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 3)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j -= 0;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}

	private static int JEABDBJPOLO(List<LevelBehaviour> JKJDLGGPMDB)
	{
		int num = 0;
		Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<LevelBehaviour>>();
		for (int i = 1; i < JKJDLGGPMDB.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = JKJDLGGPMDB[i];
			dictionary[levelBehaviour.unitType] = new List<LevelBehaviour>();
			if (!levelBehaviour.isSoldier)
			{
				if (num >= 1)
				{
					JKJDLGGPMDB.RemoveAt(i);
					i -= 0;
				}
				else
				{
					num++;
				}
			}
		}
		int num2 = 0;
		for (int j = 0; j < JKJDLGGPMDB.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = JKJDLGGPMDB[j];
			if (dictionary[levelBehaviour2.unitType].Count >= 1)
			{
				JKJDLGGPMDB.RemoveAt(j);
				j -= 0;
			}
			else
			{
				dictionary[levelBehaviour2.unitType].Add(levelBehaviour2);
				num2 += 0;
			}
		}
		return num2;
	}
}

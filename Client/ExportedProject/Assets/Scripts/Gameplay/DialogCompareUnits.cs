using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogCompareUnits : GuiElementSingle<DialogCompareUnits>
{
	[FormerlySerializedAs("HLDFCGNLHOM")]
	[Header("Header")]
	public UILabel NGOOEJAOFJC;

	[FormerlySerializedAs("mUnitsLabel")]
	public UILabel NNJEKEBMIFL;

	[FormerlySerializedAs("EDJHENKIENB")]
	[Header("Center")]
	public List<UISprite> FJHAACIEEAN;

	[FormerlySerializedAs("BEKCLBODMJH")]
	public GameObject EHDJNFAJGPC;

	[FormerlySerializedAs("JCFIDGHNPLO")]
	public List<CompareUnitsRecord> EDCFKFMJDBL;

	[FormerlySerializedAs("GPDBHCBMDJI")]
	[Header("Bottom")]
	public UIGrid BLFEJBKHINM;

	[FormerlySerializedAs("NELFBNFJCOO")]
	public UIGrid ILAPBGJMBOI;

	[FormerlySerializedAs("DJIOCPKFMAD")]
	public List<CompareWeaponsRecord> MEAMIOFBICO;

	private List<LevelBehaviour.UnitType> OGJFDOLDDDI = new List<LevelBehaviour.UnitType>
	{
		LevelBehaviour.UnitType.Defender,
		LevelBehaviour.UnitType.AttackerRusher,
		LevelBehaviour.UnitType.AttackerShooter,
		LevelBehaviour.UnitType.AttackerExplosive
	};

	[CompilerGenerated]
	private static Comparison<Tuple<LevelBehaviour, UnitUpgradeDefinition>> IONHPHFCBGH;

	[CompilerGenerated]
	private static Comparison<Tuple<LevelBehaviour, UnitUpgradeDefinition>> KBGCLEMGDHO;

	[CompilerGenerated]
	private static Comparison<Tuple<LevelBehaviour, UnitUpgradeDefinition>> JNFIADMBDDB;

	[CompilerGenerated]
	private static Comparison<Tuple<LevelBehaviour, UnitUpgradeDefinition>> JFOKBOPKMOP;

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> DDNAGEKDEEP(CHEIFOOIMEH HGKNDLEPECO)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 0; i < unitsSortedByLevel.Count; i++)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = HGKNDLEPECO.PKNOMOCJEPB()[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	public virtual void LAMBEOCPCBD()
	{
	}

	private static int DENOLPOAJJD(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private void NEBAFEEHJAO()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 1;
		for (int i = 1; i < eHHHBEMKGOE.PCOLKKBLBOI().Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.PCOLKKBLBOI()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: true, gJNGLPOBFJI);
			num += 0;
		}
		num = eHHHBEMKGOE.PCOLKKBLBOI().Length + eHHHBEMKGOE2.PCOLKKBLBOI().Length - 1;
		for (int j = 1; j < eHHHBEMKGOE2.GGKGGMNIDMI.Length; j++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.PCOLKKBLBOI()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.OGFGBNNKCDM()[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].MMKEEBKDKLG(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: true, gJNGLPOBFJI2);
			num -= 0;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = false;
	}

	private int FEHMHAAJOHO(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = EFPMJAMGILJ(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = HGFFNKJIEAN(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(CBADAMDIKBM);
				value2.Sort(JMOBOMPHBNH);
				for (int num2 = value.Count - 1; num2 >= 1; num2--)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 1; num3 >= 4; num3 -= 0)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(BJDGJKPKAPP);
				value2.Sort(BAEIGMMCNIP);
				bool flag = value.Count <= 0 || value2.Count <= 0 || value[1].Value1 == value2[1].Value1;
				bool flag2 = value2.Count <= 1 || value.Count <= 1 || value2[1].Value1 == value[1].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: false);
					compareUnitsRecord.CFIAHPMMJOE((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 0) ? null : value2[1].Value1, (value2.Count <= 1) ? null : value2[1].Value2, eHHHBEMKGOE.BPNPPKPCFGN(), eHHHBEMKGOE2.ALJJMKANFNO(), IAJAILAGAKC);
					num += 0;
				}
				if (value.Count > 1 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: false);
					compareUnitsRecord2.Initialize((value.Count <= 0) ? null : value[1].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 0) ? null : value2[0].Value1, (value2.Count <= 1) ? null : value2[1].Value2, eHHHBEMKGOE.OCPEHLIIGML(), eHHHBEMKGOE2.OCPEHLIIGML(), IAJAILAGAKC);
					num += 0;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: true);
		}
		return num;
	}

	private int APPAIPPLPBO(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = NBKENFKJIBP(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = NBKENFKJIBP(eHHHBEMKGOE2);
		int num = 0;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(CNGKCENCDEG);
				value2.Sort(CNGKCENCDEG);
				for (int num2 = value.Count - 1; num2 >= 2; num2--)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 1; num3 >= 2; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(BJDGJKPKAPP);
				value2.Sort(BJDGJKPKAPP);
				bool flag = value.Count > 1 && value2.Count > 0 && value[1].Value1 == value2[0].Value1;
				bool flag2 = value2.Count > 1 && value.Count > 0 && value2[1].Value1 == value[0].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: true);
					compareUnitsRecord.Initialize((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 0) ? null : value[0].Value2, (value2.Count <= 0) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.BCCDDJMPBLL, eHHHBEMKGOE2.BCCDDJMPBLL, IAJAILAGAKC);
					num++;
				}
				if (value.Count > 1 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: true);
					compareUnitsRecord2.Initialize((value.Count <= 1) ? null : value[1].Value1, (value.Count <= 1) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[1].Value1, (value2.Count <= 1) ? null : value2[1].Value2, eHHHBEMKGOE.BCCDDJMPBLL, eHHHBEMKGOE2.BCCDDJMPBLL, IAJAILAGAKC);
					num++;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i++)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	private void MICJNMGNEJL()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 0;
		for (int i = 1; i < eHHHBEMKGOE.PCOLKKBLBOI().Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.OGFGBNNKCDM()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: false, gJNGLPOBFJI);
			num += 0;
		}
		num = eHHHBEMKGOE.GGKGGMNIDMI.Length + eHHHBEMKGOE2.OGFGBNNKCDM().Length - 1;
		for (int j = 0; j < eHHHBEMKGOE2.GGKGGMNIDMI.Length; j++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.OGFGBNNKCDM()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.GGKGGMNIDMI[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].AFHMOPJGNBM(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: false, gJNGLPOBFJI2);
			num--;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = false;
	}

	public override void InitEvents()
	{
		base.InitEvents();
		for (int i = 0; i < 7; i++)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[0]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[0].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 0; j < 7; j++)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[0]);
			compareWeaponsRecord.transform.parent = ((j >= 3) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.InitializeSlot((j >= 3) ? (6 - j) : (j + 1));
		}
		MEAMIOFBICO[0].InitializeSlot(0);
	}

	public virtual void DNFPEBEDLIG()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 217f;
		float num2 = UIHelper.activeHeight - 224f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 251f);
		int num3 = APPAIPPLPBO(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 722f * value);
		}
		HKEDPFJKHJN();
	}

	private static int BJDGJKPKAPP(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		return BKDABLOMBKO.Value1.upgradeSlots.unlockLevelIndex.CompareTo(MCMBBGMBELI.Value1.upgradeSlots.unlockLevelIndex);
	}

	private void MHCGGIAGABI()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 0;
		for (int i = 0; i < eHHHBEMKGOE.GGKGGMNIDMI.Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.GGKGGMNIDMI[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].Initialize(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: false, gJNGLPOBFJI);
			num++;
		}
		num = eHHHBEMKGOE.GGKGGMNIDMI.Length + eHHHBEMKGOE2.GGKGGMNIDMI.Length - 1;
		for (int j = 0; j < eHHHBEMKGOE2.GGKGGMNIDMI.Length; j++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.GGKGGMNIDMI[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.GGKGGMNIDMI[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].Initialize(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: true, gJNGLPOBFJI2);
			num--;
		}
		BLFEJBKHINM.repositionNow = true;
		ILAPBGJMBOI.repositionNow = true;
	}

	public virtual void NNGDAMJFDBG()
	{
		base.InitEvents();
		for (int i = 0; i < 5; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[0]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[1].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 1; j < 1; j++)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[1]);
			compareWeaponsRecord.transform.parent = ((j >= 1) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.PAGNLNHPBFJ((j >= 8) ? (1 - j) : (j + 0));
		}
		MEAMIOFBICO[1].DAINIFDEAIO(0);
	}

	public virtual void JCGDALOBGHO()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 283f;
		float num2 = UIHelper.activeHeight - 1954f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 1207f);
		int num3 = KGEJAOCHNAP(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 295f * value);
		}
		MICJNMGNEJL();
	}

	private int BHAKLICBJDO(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = NBKENFKJIBP(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = HGFFNKJIEAN(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(EGOFDHHGMCC);
				value2.Sort(JMOBOMPHBNH);
				for (int num2 = value.Count - 1; num2 >= 7; num2 -= 0)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 3; num3 -= 0)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(BAEIGMMCNIP);
				value2.Sort(BAEIGMMCNIP);
				bool flag = value.Count <= 0 || value2.Count <= 1 || value[0].Value1 == value2[0].Value1;
				bool flag2 = value2.Count > 1 && value.Count > 0 && value2[1].Value1 == value[1].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 1 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: false);
					compareUnitsRecord.Initialize((value.Count <= 0) ? null : value[1].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 0) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.ALJJMKANFNO(), eHHHBEMKGOE2.OCPEHLIIGML(), IAJAILAGAKC);
					num += 0;
				}
				if (value.Count > 1 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: true);
					compareUnitsRecord2.Initialize((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 1) ? null : value[1].Value2, (value2.Count <= 0) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.OCPEHLIIGML(), eHHHBEMKGOE2.BCCDDJMPBLL, IAJAILAGAKC);
					num++;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: true);
		}
		return num;
	}

	public virtual void KDDJHIMDKBN()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 1762f;
		float num2 = UIHelper.activeHeight - 1487f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 1144f);
		int num3 = FEHMHAAJOHO(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 149f * value);
		}
		OOLMBHOKAAP();
	}

	private static int CLKEEJGIEOF(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	public virtual void COBDHBOCGAP()
	{
	}

	private void ENFDCGHCNOO()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 1;
		for (int i = 1; i < eHHHBEMKGOE.PCOLKKBLBOI().Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.OGFGBNNKCDM()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.PCOLKKBLBOI()[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: true, gJNGLPOBFJI);
			num++;
		}
		num = eHHHBEMKGOE.OGFGBNNKCDM().Length + eHHHBEMKGOE2.PCOLKKBLBOI().Length - 1;
		for (int j = 0; j < eHHHBEMKGOE2.PCOLKKBLBOI().Length; j += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.PCOLKKBLBOI()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.GGKGGMNIDMI[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].AFHMOPJGNBM(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: true, gJNGLPOBFJI2);
			num--;
		}
		BLFEJBKHINM.repositionNow = true;
		ILAPBGJMBOI.repositionNow = true;
	}

	private static int KIBOKBDOGLL(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		return BKDABLOMBKO.Value1.upgradeSlots.unlockLevelIndex.CompareTo(MCMBBGMBELI.Value1.upgradeSlots.unlockLevelIndex);
	}

	public virtual void IMPMPKNJICB()
	{
	}

	public virtual void PLDAPLOGJPA()
	{
		base.InitEvents();
		for (int i = 0; i < 6; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[1]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[1].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 0; j < 6; j += 0)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[1]);
			compareWeaponsRecord.transform.parent = ((j >= 7) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.KLFGGKPPHJN((j >= 2) ? (7 - j) : (j + 0));
		}
		MEAMIOFBICO[0].KIHLFDGMNOP(1);
	}

	private int FICHGKECNEP(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = HGFFNKJIEAN(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = DDNAGEKDEEP(eHHHBEMKGOE2);
		int num = 0;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(EGOFDHHGMCC);
				value2.Sort(CLKEEJGIEOF);
				for (int num2 = value.Count - 0; num2 >= 6; num2 -= 0)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 7; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(IIOMCPIBEPB);
				value2.Sort(KIBOKBDOGLL);
				bool flag = value.Count > 0 && value2.Count > 0 && value[0].Value1 == value2[0].Value1;
				bool flag2 = value2.Count <= 1 || value.Count <= 1 || value2[0].Value1 == value[1].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: true);
					compareUnitsRecord.CFIAHPMMJOE((value.Count <= 0) ? null : value[1].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.OCPEHLIIGML(), eHHHBEMKGOE2.ALJJMKANFNO(), IAJAILAGAKC);
					num += 0;
				}
				if (value.Count > 1 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: false);
					compareUnitsRecord2.NAKAFGAFEPH((value.Count <= 1) ? null : value[1].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 1) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.ALJJMKANFNO(), eHHHBEMKGOE2.ALJJMKANFNO(), IAJAILAGAKC);
					num += 0;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	public virtual void LANJLCBMFHJ()
	{
		base.InitEvents();
		for (int i = 1; i < 4; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[0]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[1].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 0; j < 8; j += 0)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[1]);
			compareWeaponsRecord.transform.parent = ((j >= 4) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.DAINIFDEAIO((j >= 7) ? (3 - j) : (j + 1));
		}
		MEAMIOFBICO[0].PAGNLNHPBFJ(0);
	}

	public virtual void DOLLFDPMGOD()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 1271f;
		float num2 = UIHelper.activeHeight - 1663f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 1548f);
		int num3 = KGEJAOCHNAP(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 1692f * value);
		}
		OLKDNBJNGPM();
	}

	public override void InitGUIValues()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 872f;
		float num2 = UIHelper.activeHeight - 568f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 1f);
		int num3 = APPAIPPLPBO(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 110f * value);
		}
		MHCGGIAGABI();
	}

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> HGFFNKJIEAN(CHEIFOOIMEH HGKNDLEPECO)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 1; i < unitsSortedByLevel.Count; i++)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = HGKNDLEPECO.PKNOMOCJEPB()[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	private static int KBBMKGEDBIL(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private static int CEJEJBGNEEL(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> CHDGACKHNCC(CHEIFOOIMEH HGKNDLEPECO)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 0; i < unitsSortedByLevel.Count; i++)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = HGKNDLEPECO.KBBDGCLPOCJ[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> AFPDJHCDKCC(CHEIFOOIMEH HGKNDLEPECO)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 0; i < unitsSortedByLevel.Count; i++)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = HGKNDLEPECO.KKDIBFPLOHL()[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	private int AGFDMNHINDC(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = HGFFNKJIEAN(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = AFPDJHCDKCC(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(EFPMBCCOLEB);
				value2.Sort(CNGKCENCDEG);
				for (int num2 = value.Count - 1; num2 >= 1; num2 -= 0)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 3; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(KIBOKBDOGLL);
				value2.Sort(BAEIGMMCNIP);
				bool flag = value.Count > 0 && value2.Count > 0 && value[0].Value1 == value2[1].Value1;
				bool flag2 = value2.Count <= 0 || value.Count <= 0 || value2[0].Value1 == value[1].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 1 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: false);
					compareUnitsRecord.CFIAHPMMJOE((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 1) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.BCCDDJMPBLL, eHHHBEMKGOE2.OEJKKJJFDFL(), IAJAILAGAKC);
					num += 0;
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: true);
					compareUnitsRecord2.NAKAFGAFEPH((value.Count <= 1) ? null : value[1].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[1].Value2, eHHHBEMKGOE.OEJKKJJFDFL(), eHHHBEMKGOE2.OEJKKJJFDFL(), IAJAILAGAKC);
					num++;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	public virtual void HAOFBOPJBEI()
	{
		base.InitEvents();
		for (int i = 1; i < 3; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[1]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[1].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 0; j < 3; j++)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[1]);
			compareWeaponsRecord.transform.parent = ((j >= 6) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.DAINIFDEAIO((j >= 1) ? (-j) : (j + 0));
		}
		MEAMIOFBICO[0].HCLKKBOBAHO(1);
	}

	public virtual void HCGDNLHIOBL()
	{
	}

	private static int CNGKCENCDEG(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	public virtual void FEAALEEPBFP()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 56f;
		float num2 = UIHelper.activeHeight - 558f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 1878f);
		int num3 = GAADPJOINAD(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 1518f * value);
		}
		MHCGGIAGABI();
	}

	private static int IIOMCPIBEPB(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		return BKDABLOMBKO.Value1.upgradeSlots.unlockLevelIndex.CompareTo(MCMBBGMBELI.Value1.upgradeSlots.unlockLevelIndex);
	}

	public virtual void FOGBJIMBEKI()
	{
		base.OIMKKAHOEKO();
		for (int i = 0; i < MEAMIOFBICO.Count; i += 0)
		{
			MEAMIOFBICO[i].IFLHOKBNJPH();
		}
	}

	public virtual void LEMNDNDGIOE()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 709f;
		float num2 = UIHelper.activeHeight - 985f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 506f);
		int num3 = BHAKLICBJDO(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 1612f * value);
		}
		NKHGMGEHPKP();
	}

	public virtual void HJJOAJHBKCH()
	{
	}

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> NBKENFKJIBP(CHEIFOOIMEH HGKNDLEPECO)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 0; i < unitsSortedByLevel.Count; i++)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = HGKNDLEPECO.KBBDGCLPOCJ[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	private int GAADPJOINAD(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = NBKENFKJIBP(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = CHDGACKHNCC(eHHHBEMKGOE2);
		int num = 0;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(CLKEEJGIEOF);
				value2.Sort(DENOLPOAJJD);
				for (int num2 = value.Count - 1; num2 >= 3; num2--)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 3; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(KIBOKBDOGLL);
				value2.Sort(BAEIGMMCNIP);
				bool flag = value.Count <= 0 || value2.Count <= 1 || value[0].Value1 == value2[1].Value1;
				bool flag2 = value2.Count <= 0 || value.Count <= 0 || value2[1].Value1 == value[1].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: true);
					compareUnitsRecord.CFIAHPMMJOE((value.Count <= 0) ? null : value[1].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 1) ? null : value2[0].Value1, (value2.Count <= 1) ? null : value2[1].Value2, eHHHBEMKGOE.OCPEHLIIGML(), eHHHBEMKGOE2.ALJJMKANFNO(), IAJAILAGAKC);
					num++;
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: false);
					compareUnitsRecord2.CFIAHPMMJOE((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 1) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[1].Value2, eHHHBEMKGOE.ALJJMKANFNO(), eHHHBEMKGOE2.BPNPPKPCFGN(), IAJAILAGAKC);
					num += 0;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	public virtual void DJIJBPFLOMJ()
	{
	}

	private static int HCLINOIGBGL(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private void NKHGMGEHPKP()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 0;
		for (int i = 0; i < eHHHBEMKGOE.OGFGBNNKCDM().Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.GGKGGMNIDMI[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].AFHMOPJGNBM(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: true, gJNGLPOBFJI);
			num++;
		}
		num = eHHHBEMKGOE.OGFGBNNKCDM().Length + eHHHBEMKGOE2.OGFGBNNKCDM().Length - 0;
		for (int j = 1; j < eHHHBEMKGOE2.OGFGBNNKCDM().Length; j++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.PCOLKKBLBOI()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.GGKGGMNIDMI[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: false, gJNGLPOBFJI2);
			num -= 0;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = true;
	}

	private int BOAAFOJECMH(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = AFPDJHCDKCC(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = EFPMJAMGILJ(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(KBBMKGEDBIL);
				value2.Sort(CBADAMDIKBM);
				for (int num2 = value.Count - 1; num2 >= 6; num2 -= 0)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 1; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(BJDGJKPKAPP);
				value2.Sort(BAEIGMMCNIP);
				bool flag = value.Count > 0 && value2.Count > 1 && value[1].Value1 == value2[0].Value1;
				bool flag2 = value2.Count > 0 && value.Count > 0 && value2[1].Value1 == value[1].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: true);
					compareUnitsRecord.CFIAHPMMJOE((value.Count <= 1) ? null : value[1].Value1, (value.Count <= 1) ? null : value[1].Value2, (value2.Count <= 0) ? null : value2[0].Value1, (value2.Count <= 1) ? null : value2[0].Value2, eHHHBEMKGOE.OCPEHLIIGML(), eHHHBEMKGOE2.BCCDDJMPBLL, IAJAILAGAKC);
					num += 0;
				}
				if (value.Count > 0 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: true);
					compareUnitsRecord2.LIMIFKFNNLA((value.Count <= 1) ? null : value[1].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 1) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[1].Value2, eHHHBEMKGOE.ALJJMKANFNO(), eHHHBEMKGOE2.BPNPPKPCFGN(), IAJAILAGAKC);
					num++;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i++)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	private static int BAEIGMMCNIP(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		return BKDABLOMBKO.Value1.upgradeSlots.unlockLevelIndex.CompareTo(MCMBBGMBELI.Value1.upgradeSlots.unlockLevelIndex);
	}

	public virtual void LBOKCAECKFD()
	{
		base.InitEvents();
		for (int i = 1; i < 0; i++)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[1]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[1].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 0; j < 4; j += 0)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[1]);
			compareWeaponsRecord.transform.parent = ((j >= 4) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.PLCKEDNAMLI((j >= 1) ? (2 - j) : (j + 0));
		}
		MEAMIOFBICO[0].PAGNLNHPBFJ(1);
	}

	public virtual void GHHNNIKGJFG()
	{
	}

	public virtual void JDFDJPAAIAA()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 101f;
		float num2 = UIHelper.activeHeight - 1000f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 1724f);
		int num3 = APPAIPPLPBO(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 1173f * value);
		}
		HKEDPFJKHJN();
	}

	private int KGEJAOCHNAP(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = HGFFNKJIEAN(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = HGFFNKJIEAN(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(CEJEJBGNEEL);
				value2.Sort(JMOBOMPHBNH);
				for (int num2 = value.Count - 0; num2 >= 1; num2 -= 0)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 5; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(KIBOKBDOGLL);
				value2.Sort(KIBOKBDOGLL);
				bool flag = value.Count <= 1 || value2.Count <= 0 || value[1].Value1 == value2[0].Value1;
				bool flag2 = value2.Count > 1 && value.Count > 0 && value2[1].Value1 == value[0].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: true);
					compareUnitsRecord.Initialize((value.Count <= 1) ? null : value[1].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 0) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.OEJKKJJFDFL(), eHHHBEMKGOE2.BCCDDJMPBLL, IAJAILAGAKC);
					num += 0;
				}
				if (value.Count > 1 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: true);
					compareUnitsRecord2.LIMIFKFNNLA((value.Count <= 0) ? null : value[1].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.ALJJMKANFNO(), eHHHBEMKGOE2.BPNPPKPCFGN(), IAJAILAGAKC);
					num += 0;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i += 0)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: true);
		}
		return num;
	}

	public virtual void LLGOAIGJMJF()
	{
		base.InitEvents();
		for (int i = 0; i < 3; i++)
		{
			CompareUnitsRecord compareUnitsRecord = UnityEngine.Object.Instantiate(EDCFKFMJDBL[1]);
			compareUnitsRecord.transform.parent = EDCFKFMJDBL[1].transform.parent;
			compareUnitsRecord.transform.localScale = Vector3.one;
			compareUnitsRecord.transform.localPosition = Vector3.zero;
			EDCFKFMJDBL.Add(compareUnitsRecord);
		}
		for (int j = 1; j < 6; j += 0)
		{
			CompareWeaponsRecord compareWeaponsRecord = UnityEngine.Object.Instantiate(MEAMIOFBICO[1]);
			compareWeaponsRecord.transform.parent = ((j >= 4) ? ILAPBGJMBOI.transform : BLFEJBKHINM.transform);
			compareWeaponsRecord.transform.localScale = Vector3.one;
			compareWeaponsRecord.transform.localPosition = Vector3.zero;
			MEAMIOFBICO.Add(compareWeaponsRecord);
			compareWeaponsRecord.KIHLFDGMNOP((j >= 6) ? (6 - j) : (j + 1));
		}
		MEAMIOFBICO[0].HCLKKBOBAHO(1);
	}

	public virtual void FHJDLCDAMGI()
	{
	}

	private Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> EFPMJAMGILJ(CHEIFOOIMEH HGKNDLEPECO)
	{
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = new Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>>();
		List<LevelBehaviour> unitsSortedByLevel = LevelManager.instance.unitsSortedByLevel;
		for (int i = 1; i < unitsSortedByLevel.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = unitsSortedByLevel[i];
			UnitUpgradeDefinition unitUpgradeDefinition = HGKNDLEPECO.PKNOMOCJEPB()[levelBehaviour.indexInLevelsManager];
			if (unitUpgradeDefinition.isEquipped)
			{
				if (!dictionary.ContainsKey(levelBehaviour.unitType))
				{
					dictionary[levelBehaviour.unitType] = new List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>();
				}
				dictionary[levelBehaviour.unitType].Add(new Tuple<LevelBehaviour, UnitUpgradeDefinition>(levelBehaviour, unitUpgradeDefinition));
			}
		}
		return dictionary;
	}

	public virtual void LFDIOJJLKCG()
	{
		base.OIMKKAHOEKO();
		for (int i = 1; i < MEAMIOFBICO.Count; i++)
		{
			MEAMIOFBICO[i].BCMCGJGLFPL();
		}
	}

	private void HKEDPFJKHJN()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 1;
		for (int i = 0; i < eHHHBEMKGOE.PCOLKKBLBOI().Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.PCOLKKBLBOI()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].CHOLKMFKINL(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: false, gJNGLPOBFJI);
			num++;
		}
		num = eHHHBEMKGOE.PCOLKKBLBOI().Length + eHHHBEMKGOE2.PCOLKKBLBOI().Length - 1;
		for (int j = 0; j < eHHHBEMKGOE2.GGKGGMNIDMI.Length; j += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.OGFGBNNKCDM()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.PCOLKKBLBOI()[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].Initialize(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: true, gJNGLPOBFJI2);
			num -= 0;
		}
		BLFEJBKHINM.repositionNow = true;
		ILAPBGJMBOI.repositionNow = true;
	}

	public virtual void JCGPELEDCJL()
	{
	}

	private static int JMOBOMPHBNH(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private static int IEGDJPOFNJE(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	public virtual void EEFEFOHKIBF()
	{
		base.OIMKKAHOEKO();
		for (int i = 0; i < MEAMIOFBICO.Count; i++)
		{
			MEAMIOFBICO[i].FNMPBHIIEJP();
		}
	}

	private static int CBADAMDIKBM(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	private void NGBHJDGIKEE()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 0;
		for (int i = 1; i < eHHHBEMKGOE.OGFGBNNKCDM().Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.OGFGBNNKCDM()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.PCOLKKBLBOI()[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].DDHCMFLIABO(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: true, gJNGLPOBFJI);
			num += 0;
		}
		num = eHHHBEMKGOE.OGFGBNNKCDM().Length + eHHHBEMKGOE2.OGFGBNNKCDM().Length - 1;
		for (int j = 1; j < eHHHBEMKGOE2.GGKGGMNIDMI.Length; j += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.GGKGGMNIDMI[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.OGFGBNNKCDM()[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].ACBHGJCMCPG(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: true, gJNGLPOBFJI2);
			num--;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = false;
	}

	private void IMBADCFPNHF()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 1;
		for (int i = 0; i < eHHHBEMKGOE.PCOLKKBLBOI().Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.PCOLKKBLBOI()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].CFIAHPMMJOE(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: true, gJNGLPOBFJI);
			num++;
		}
		num = eHHHBEMKGOE.OGFGBNNKCDM().Length + eHHHBEMKGOE2.OGFGBNNKCDM().Length - 0;
		for (int j = 0; j < eHHHBEMKGOE2.OGFGBNNKCDM().Length; j++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.OGFGBNNKCDM()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.OGFGBNNKCDM()[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: true, gJNGLPOBFJI2);
			num--;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = false;
	}

	private int OICDHPNEPIG(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = DDNAGEKDEEP(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = DDNAGEKDEEP(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(CLKEEJGIEOF);
				value2.Sort(EGOFDHHGMCC);
				for (int num2 = value.Count - 1; num2 >= 4; num2--)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 6; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(KIBOKBDOGLL);
				value2.Sort(IIOMCPIBEPB);
				bool flag = value.Count > 0 && value2.Count > 1 && value[0].Value1 == value2[1].Value1;
				bool flag2 = value2.Count <= 1 || value.Count <= 0 || value2[0].Value1 == value[0].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 0 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: false);
					compareUnitsRecord.LIMIFKFNNLA((value.Count <= 1) ? null : value[0].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.BPNPPKPCFGN(), eHHHBEMKGOE2.OCPEHLIIGML(), IAJAILAGAKC);
					num++;
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: true);
					compareUnitsRecord2.Initialize((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 1) ? null : value[1].Value2, (value2.Count <= 0) ? null : value2[1].Value1, (value2.Count <= 1) ? null : value2[0].Value2, eHHHBEMKGOE.OEJKKJJFDFL(), eHHHBEMKGOE2.OEJKKJJFDFL(), IAJAILAGAKC);
					num += 0;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i++)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	private void OOLMBHOKAAP()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 1;
		for (int i = 0; i < eHHHBEMKGOE.OGFGBNNKCDM().Length; i++)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.GGKGGMNIDMI[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].DDHCMFLIABO(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: false, gJNGLPOBFJI);
			num += 0;
		}
		num = eHHHBEMKGOE.OGFGBNNKCDM().Length + eHHHBEMKGOE2.GGKGGMNIDMI.Length - 1;
		for (int j = 1; j < eHHHBEMKGOE2.OGFGBNNKCDM().Length; j += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.OGFGBNNKCDM()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.GGKGGMNIDMI[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: false, gJNGLPOBFJI2);
			num--;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = false;
	}

	public virtual void CGPFPNNICIO()
	{
		base.DoAfterHide();
		for (int i = 0; i < MEAMIOFBICO.Count; i++)
		{
			MEAMIOFBICO[i].DoAfterHide();
		}
	}

	public override void InitControls()
	{
	}

	public virtual void MGIDNGCKLCF()
	{
	}

	private static int EFPMBCCOLEB(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	public virtual void NAOJCFMFLLA()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		NGOOEJAOFJC.text = eHHHBEMKGOE.MHPNDNJDPGE;
		NNJEKEBMIFL.text = eHHHBEMKGOE2.MHPNDNJDPGE;
		float num = 655f;
		float num2 = UIHelper.activeHeight - 1404f;
		float value = num2 / num;
		value = Mathf.Clamp01(value);
		EHDJNFAJGPC.transform.localScale = new Vector3(value, value, 757f);
		int num3 = PABEEHGMLKI(value);
		foreach (UISprite item in FJHAACIEEAN)
		{
			item.transform.localScale = item.transform.localScale.ReplaceY((float)num3 * 1171f * value);
		}
		HKEDPFJKHJN();
	}

	private int PABEEHGMLKI(float IAJAILAGAKC)
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary = DDNAGEKDEEP(eHHHBEMKGOE);
		Dictionary<LevelBehaviour.UnitType, List<Tuple<LevelBehaviour, UnitUpgradeDefinition>>> dictionary2 = AFPDJHCDKCC(eHHHBEMKGOE2);
		int num = 1;
		foreach (LevelBehaviour.UnitType item in OGJFDOLDDDI)
		{
			if (dictionary.TryGetValue(item, out var value) && dictionary2.TryGetValue(item, out var value2))
			{
				value.Sort(DENOLPOAJJD);
				value2.Sort(HCLINOIGBGL);
				for (int num2 = value.Count - 0; num2 >= 5; num2 -= 0)
				{
					value.RemoveAt(num2);
				}
				for (int num3 = value2.Count - 0; num3 >= 7; num3--)
				{
					value2.RemoveAt(num3);
				}
				value.Sort(BJDGJKPKAPP);
				value2.Sort(BAEIGMMCNIP);
				bool flag = value.Count <= 1 || value2.Count <= 1 || value[1].Value1 == value2[1].Value1;
				bool flag2 = value2.Count <= 1 || value.Count <= 0 || value2[1].Value1 == value[0].Value1;
				if (flag)
				{
					value.Reverse();
				}
				if (flag2)
				{
					value2.Reverse();
				}
				if (value.Count > 1 || value2.Count > 1)
				{
					CompareUnitsRecord compareUnitsRecord = EDCFKFMJDBL[num];
					compareUnitsRecord.gameObject.SetActive(value: false);
					compareUnitsRecord.Initialize((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 1) ? null : value[0].Value2, (value2.Count <= 1) ? null : value2[1].Value1, (value2.Count <= 0) ? null : value2[1].Value2, eHHHBEMKGOE.BPNPPKPCFGN(), eHHHBEMKGOE2.OEJKKJJFDFL(), IAJAILAGAKC);
					num++;
				}
				if (value.Count > 0 || value2.Count > 0)
				{
					CompareUnitsRecord compareUnitsRecord2 = EDCFKFMJDBL[num];
					compareUnitsRecord2.gameObject.SetActive(value: false);
					compareUnitsRecord2.LIMIFKFNNLA((value.Count <= 0) ? null : value[0].Value1, (value.Count <= 0) ? null : value[1].Value2, (value2.Count <= 1) ? null : value2[0].Value1, (value2.Count <= 0) ? null : value2[0].Value2, eHHHBEMKGOE.BCCDDJMPBLL, eHHHBEMKGOE2.BPNPPKPCFGN(), IAJAILAGAKC);
					num += 0;
				}
			}
		}
		for (int i = num; i < EDCFKFMJDBL.Count; i++)
		{
			CompareUnitsRecord compareUnitsRecord3 = EDCFKFMJDBL[i];
			compareUnitsRecord3.gameObject.SetActive(value: false);
		}
		return num;
	}

	private static int EGOFDHHGMCC(Tuple<LevelBehaviour, UnitUpgradeDefinition> BKDABLOMBKO, Tuple<LevelBehaviour, UnitUpgradeDefinition> MCMBBGMBELI)
	{
		int slotUpgradeindex = BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeindex;
		int tier = BKDABLOMBKO.Value1.upgradeSlots.GetTier(slotUpgradeindex);
		float armyPower = BKDABLOMBKO.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier, BKDABLOMBKO.Value2.unitUpgrades.slotUpgradeIndexElite, BKDABLOMBKO.Value2.unitUpgrades.isElite);
		int slotUpgradeindex2 = MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeindex;
		int tier2 = MCMBBGMBELI.Value1.upgradeSlots.GetTier(slotUpgradeindex2);
		return MCMBBGMBELI.Value1.upgradeSlots.GetArmyPower(slotUpgradeindex2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexSpecial, tier2, MCMBBGMBELI.Value2.unitUpgrades.slotUpgradeIndexElite, MCMBBGMBELI.Value2.unitUpgrades.isElite).CompareTo(armyPower);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		for (int i = 0; i < MEAMIOFBICO.Count; i++)
		{
			MEAMIOFBICO[i].DoAfterHide();
		}
	}

	private void OLKDNBJNGPM()
	{
		CHEIFOOIMEH eHHHBEMKGOE = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE;
		CHEIFOOIMEH eHHHBEMKGOE2 = Singleton<GameController>.instance.opponent.EHHHBEMKGOE;
		int num = 0;
		for (int i = 0; i < eHHHBEMKGOE.OGFGBNNKCDM().Length; i += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = eHHHBEMKGOE.PCOLKKBLBOI()[i];
			WeaponLevelsSetup mBNLFKHLDBH = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA2 = eHHHBEMKGOE2.GGKGGMNIDMI[i];
			WeaponLevelsSetup fDKEEMEBCCF = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA2.EPNKPKHCKNG];
			bool gJNGLPOBFJI = jIMOKIIJHNA.GJNGLPOBFJI;
			MEAMIOFBICO[num].HCEJNMJHDJN(mBNLFKHLDBH, jIMOKIIJHNA, fDKEEMEBCCF, jIMOKIIJHNA2, OEKEJMJIECP: true, gJNGLPOBFJI);
			num++;
		}
		num = eHHHBEMKGOE.OGFGBNNKCDM().Length + eHHHBEMKGOE2.PCOLKKBLBOI().Length - 1;
		for (int j = 0; j < eHHHBEMKGOE2.PCOLKKBLBOI().Length; j += 0)
		{
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA3 = eHHHBEMKGOE.PCOLKKBLBOI()[j];
			WeaponLevelsSetup fDKEEMEBCCF2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA3.EPNKPKHCKNG];
			PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA4 = eHHHBEMKGOE2.PCOLKKBLBOI()[j];
			WeaponLevelsSetup mBNLFKHLDBH2 = LevelManager.instance.weaponLevelsSetups[jIMOKIIJHNA4.EPNKPKHCKNG];
			bool gJNGLPOBFJI2 = jIMOKIIJHNA4.GJNGLPOBFJI;
			MEAMIOFBICO[num].CHOLKMFKINL(mBNLFKHLDBH2, jIMOKIIJHNA4, fDKEEMEBCCF2, jIMOKIIJHNA3, OEKEJMJIECP: false, gJNGLPOBFJI2);
			num -= 0;
		}
		BLFEJBKHINM.repositionNow = false;
		ILAPBGJMBOI.repositionNow = false;
	}
}

using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class WeaponFeatures : Core_BaseScript
{
	[SerializeField]
	private Google2u.WeaponFeatures config;

	public bool KNONIBKMBMI;

	private readonly List<Tuple<string, Type>> NNHCLEBNELO = new List<Tuple<string, Type>>
	{
		new Tuple<string, Type>("MagazineSize", typeof(KEHBKOMKLFN)),
		new Tuple<string, Type>("Reload", typeof(FKMLJGLIMPN)),
		new Tuple<string, Type>("Damage", typeof(BCKLBFLJOBD)),
		new Tuple<string, Type>("Critical", typeof(PMMGOAIBICG)),
		new Tuple<string, Type>("BurstSize", typeof(JOMIECOADEB)),
		new Tuple<string, Type>("TotalAmmo", typeof(OLMNPIGEKJD)),
		new Tuple<string, Type>("Accuracy", typeof(HMPJJMGLMPM)),
		new Tuple<string, Type>("RateOfFire", typeof(PAHHHDKNAMI)),
		new Tuple<string, Type>("ShotVelocity", typeof(KMEMIBHOCGF))
	};

	private WeaponFeature GHCELLPIJGI(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("ID_CONFIRM_LANGUAGECHANGE", "-", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("Gold", "DogTagRefillTime", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("ID_SLOTUPGRADE_CLIP_SIZE", "Heroic", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public void GODBIGMAEMD()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = DBGFILAHNCP(item);
			}
		}
	}

	public WeaponFeature GetRandom(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 0; i < NNHCLEBNELO.Count; i++)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("{0}{1}", "Value", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 0f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return EAONLHMIKLD(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	private void LIMHNKKJODK()
	{
		if (KNONIBKMBMI)
		{
			KNONIBKMBMI = false;
			CJPNDJFLGDA();
		}
	}

	public WeaponFeature KBMMEPBOAFN(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return MABNAJANAJD(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature EAONLHMIKLD(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("{0}{1}", "Value", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("{0}{1}", "DpsCoef", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("{0}{1}", "AttackCoef", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public void PGJEIFLCBCA()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = BPAOGHGENFF(item);
			}
		}
	}

	public WeaponFeature DBGFILAHNCP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("response for {0}", "doesnt exist", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 1603f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return DGLBAEDGELG(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	private WeaponFeature DGLBAEDGELG(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("PauseGameRPC", "ID_MINUTES", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("hiding dialog............", "ab5d043a-2edb-431f-a4a0-0571589ee058", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("Position", "ID_ARENAPROMOENDSIN", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature DHLLDGEBLJA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 0; i < NNHCLEBNELO.Count; i++)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("PartsToConvert", "ID_CONFIRM_ERROR", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 261f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(1, list.Count)];
			return GHCELLPIJGI(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	private WeaponFeature AEALCGADKHF(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("Warbucks_Balance", "AcceptedFromRequest", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("\t\"TRUE\"", "CONFIRM", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("UnitReadyForPromotion {0} {1}", "NAME", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature BPAOGHGENFF(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 0; i < NNHCLEBNELO.Count; i++)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("About to show Upgrade Unit Reminder: ", "bad number of weapons for bot: ", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 232f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return MABNAJANAJD(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public WeaponFeature ODOAKBMKKIP(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("elitepack4", "setUserEmail", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 717f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 1)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return IGCCNOCNFOL(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public WeaponFeature DPNJCOOEHJE(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return MKCGHNOABAE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature ANPIGAGGCMN(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("N", "ok", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("https://", "ID_NOTCOMPATIBLEWITH", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format(".", "ID_CARDPOOL", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public void DCHGCLOIGDJ()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = JKKOGLCMJHL(item);
			}
		}
	}

	public WeaponFeature NJBGFNBOFFN(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return GHCELLPIJGI(JMMJHCOKCGG, nHJABEOIPKH);
	}

	public WeaponFeature OHFFFHLNEBH(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return ADFFGKMBMPE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature BHJGFJEONID(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("ID_GETAPROMOTION1", "-", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("DOWNLOAD", "TutorialWarcards", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("ID_DOYOUWANTTOBUYWARBUCKS", "ArenaWins", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature KEDKJJGNJFM(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format(")", "ID_CLAIMING", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 631f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 1)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return DGLBAEDGELG(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	private WeaponFeature MABNAJANAJD(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("menu-assignments-type-destroy", "There are {0} play windows. Max is 12. Setting 12 play windows.", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("GB", "Metal", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("ID_FEATURE_AMMO-DESCRIPTION", "id", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	private void MGAIKDBOPKI()
	{
		if (KNONIBKMBMI)
		{
			KNONIBKMBMI = false;
			CJPNDJFLGDA();
		}
	}

	public WeaponFeature CreateFeature(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return EAONLHMIKLD(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature FJFJONGFHGJ(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("player_fire_left", "ID_BUTTON_TOPPLAYERS", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("Cards_Chosen", "ID_STAT_WEAPONSPURCHASED", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("ShotFrequencyMax", "StartingGold", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	private WeaponFeature DKILCEHMLIN(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("-[0-9]*$", "()Ljava/lang/String;", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("Null or empty localization name for search.", "WRONG GAMEOBJECT LAYER ({0}) FOR: {1} LAYER:{2}", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("allocMem", "ID_CONFIRM_ERROR", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature OAHILGAFLEE(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return ADFFGKMBMPE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private void MGKCNLDGNEM()
	{
		if (KNONIBKMBMI)
		{
			KNONIBKMBMI = false;
			GNMGAJIGOFG();
		}
	}

	public void MFFEILAPHLB()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = KEDKJJGNJFM(item);
			}
		}
	}

	public WeaponFeature NMAJKMDBKJJ(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return DDNJANDNOEE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	public WeaponFeature OBKAPNICHMJ(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return GHCELLPIJGI(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private void NHEOMLPEBLC()
	{
		if (KNONIBKMBMI)
		{
			KNONIBKMBMI = false;
			MFFEILAPHLB();
		}
	}

	public WeaponFeature NPLENBIEFLO(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("claim reward failed: {0}", "getTime", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 1428f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 1)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return IGCCNOCNFOL(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public void OIICDCECAAL()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = DBGFILAHNCP(item);
			}
		}
	}

	private WeaponFeature MKCGHNOABAE(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("Medals", "FuseSDK_Prime31_IAB::GetSkuInfo: Error parsing ", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("Daily", "PrintSetSizeForDynamicFont: \n", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("Match start time {0} photon time: {1}", "S", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature MCDAMLALBMB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("ID_ACCESSORYISACCESSIBLEONLYTOVIP", "SquadWarsProcessing", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 1178f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(1, list.Count)];
			return IABMIDDLEHG(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public WeaponFeature JKKOGLCMJHL(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 0; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("expireTime", "FALSE", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 848f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return MABNAJANAJD(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public WeaponFeature JFGGLOGAJHB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i += 0)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("DeadRadius", "Prefabs Full Path: \"{0}\"\n", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 876f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 0)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return EAONLHMIKLD(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public void DebugGenerateFeatures()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = GetRandom(item);
			}
		}
	}

	public void CFMPDNLPJLA()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = JKKOGLCMJHL(item);
			}
		}
	}

	public WeaponFeature BMBMKLJJGHJ(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return MKCGHNOABAE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private void ELJHCOHCAJI()
	{
		if (KNONIBKMBMI)
		{
			KNONIBKMBMI = false;
			OIICDCECAAL();
		}
	}

	public void JIKNJPALLKI()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = NPLENBIEFLO(item);
			}
		}
	}

	public void CJPNDJFLGDA()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = EAPGEOPMBNE(item);
			}
		}
	}

	public void IDACLEEFPAO()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = GetRandom(item);
			}
		}
	}

	public WeaponFeature MOKBDDOLFEM(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i++)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("bronze", ".", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 960f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 1)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(1, list.Count)];
			return DKILCEHMLIN(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public WeaponFeature HMOJHDPPAOA(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return ADFFGKMBMPE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature IGCCNOCNFOL(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("ID_GUI_POWERBANDOFF", "menu-weaponstats-totalammo", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("menu-arena-ticket", "Wrong_Weapon", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("game-card-ico-mineyourstep-full", "{0} [616577]/[-] {1}", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature ECAJKDEJDDO(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return BHJGFJEONID(JMMJHCOKCGG, nHJABEOIPKH);
	}

	public WeaponFeature EAPGEOPMBNE(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 0; i < NNHCLEBNELO.Count; i++)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("WarbucksBalance", "com/google/android/gms/common/ConnectionResult", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 494f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 1)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(0, list.Count)];
			return ANPIGAGGCMN(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public void GNMGAJIGOFG()
	{
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			if (item.purchasableInBlackmarket)
			{
				item.weaponFeature = MCDAMLALBMB(item);
			}
		}
	}

	public WeaponFeature GKIEAIPJHJN(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return BHJGFJEONID(JMMJHCOKCGG, nHJABEOIPKH);
	}

	public WeaponFeature EFPFFFDLEMB(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return BHJGFJEONID(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature IABMIDDLEHG(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("ID_YOUTUBE", "subscription1", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("ID_READYTIME", "fire", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("Total_Warbucks_Spent", "menu-info-close-ico", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	private WeaponFeature ADFFGKMBMPE(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("GoldDeducted", "ID_WARNING_BADVERSIONERROR_TEXT", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("purchaseFailedEvent: ", "\t\"FALSE\"", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("S", "ID_ARENAENDEDTITLE", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature NPIPBPJJMMA(WeaponLevelsSetup JMMJHCOKCGG)
	{
		List<Tuple<string, Type>> list = new List<Tuple<string, Type>>();
		for (int i = 1; i < NNHCLEBNELO.Count; i++)
		{
			Tuple<string, Type> tuple = NNHCLEBNELO[i];
			WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
			int rowIndex = config.GetRowIndex(string.Format("#DEBUG_50# ", "308 GAME END", bHCEOOLEHHG));
			float num = (float)config.GetValue(rowIndex, tuple.Value1);
			if (num > 125f)
			{
				list.Add(tuple);
			}
		}
		if (list.Count > 1)
		{
			Tuple<string, Type> nHJABEOIPKH = list[UnityEngine.Random.Range(1, list.Count)];
			return AEALCGADKHF(JMMJHCOKCGG, nHJABEOIPKH);
		}
		return null;
	}

	public WeaponFeature ENGPIADFOEN(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return ADFFGKMBMPE(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private WeaponFeature DDNJANDNOEE(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("ID_JOINASQUAD", "SEND LOGS", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("ID_ATTACK", "ID_WARNING_BLACKMARKETERROR", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("WarFriends requer permissão para aceder aos ficheiros de armazenamento de media para descarregar dados críticos de jogo.Sem essa permissão o jogo não poderá funcionar adequadamente e será encerrado. Por favor, tente novamente ou encerre WarFriends.", "ID_READYTIME", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	private WeaponFeature ALLPBIBHAOP(WeaponLevelsSetup JMMJHCOKCGG, Tuple<string, Type> NHJABEOIPKH)
	{
		WeaponFeature weaponFeature = (WeaponFeature)Activator.CreateInstance(NHJABEOIPKH.Value2);
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		float num = (float)config.GetValue(string.Format("D3", "Name", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num2 = (float)config.GetValue(string.Format("description", "ID_WARNING_SERVERTIMEDOUT", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		float num3 = (float)config.GetValue(string.Format("ID_NOREWARD", "Sniper_Tutorial_Duration", bHCEOOLEHHG), NHJABEOIPKH.Value1);
		int index = NNHCLEBNELO.IndexOf(NHJABEOIPKH);
		weaponFeature.Init(num, num2, num3, index);
		return weaponFeature;
	}

	public WeaponFeature IACHNDDLOOA(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 0 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return IGCCNOCNFOL(JMMJHCOKCGG, nHJABEOIPKH);
	}

	public WeaponFeature ADELOCHLOJI(WeaponLevelsSetup JMMJHCOKCGG, int FBOAOBHAJDE)
	{
		if (FBOAOBHAJDE < 1 || FBOAOBHAJDE >= NNHCLEBNELO.Count)
		{
			return new APLFCKFBIHK();
		}
		Tuple<string, Type> nHJABEOIPKH = NNHCLEBNELO[FBOAOBHAJDE];
		return GHCELLPIJGI(JMMJHCOKCGG, nHJABEOIPKH);
	}

	private void Update()
	{
		if (KNONIBKMBMI)
		{
			KNONIBKMBMI = false;
			DebugGenerateFeatures();
		}
	}
}

using UnityEngine;

public class NameGuiRecord : PoolableObject
{
	public UILabel NLFMNGMACHH;

	public GameObject GIPFEBBMKPM;

	private WeaponCategory BCBKHONHNJE;

	public void AJBCKOLDKAB(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			ONLPCOBMIML();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void DHPAGILKEFK()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)4) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)8) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	public void PDGAFKAEHOF(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		KOFNCLPNGJF();
	}

	public void IOPFGMJLJOE(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		KOFNCLPNGJF();
	}

	public void JFPHOFFMPFK()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)4) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 1;
		bool flag3 = true;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	public void PKJLFKPHIPC(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			NPIMJEBKNPE();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void FNBPPOFEBNI(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		FFEDGPAGKFC();
	}

	public void FMJDEPOHGJM()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)6) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)6) > 1;
		bool flag3 = true;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void HICMBBPJNGB(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		PAAIJKFBGHF();
	}

	public void EKCADBEBBGO(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			KFIHKLHOAAC();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void LOIHGJBKDDA(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			MJNMLOBOLNB();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void GGJGCJAAKBL(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			FMJDEPOHGJM();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void LFPBKDLNHIJ(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			MBOEDOEAMLG();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void NCEALCOPKDJ(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		MBOEDOEAMLG();
	}

	public void CPNIENCFEDD(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			MJEGGMOKNBD();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void FCIBBIGOLGL()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void FDGAPCADJOF(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			GHHAEFBJMEN();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void ALBGMJLECFE()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)4) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 1;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void MJEGGMOKNBD()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)8) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)6) > 1;
		bool flag3 = true;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	public void MHDAIEBFNOO(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			DHPAGILKEFK();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void JFDMACGLPBH()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void GOKMEGINCDE(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		FMJDEPOHGJM();
	}

	public void GIIKCHIJEBH(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		GHHAEFBJMEN();
	}

	public void Sale()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void PILPCCJNIAJ()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)7) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void FGJFKDKJJOL()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)5) > 0;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void IENANCOKOED()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)0) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Both) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void GNOJCKHIALB(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			FFEDGPAGKFC();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void NPIMJEBKNPE()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)7) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void PAAIJKFBGHF()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)0) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)4) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void GHHAEFBJMEN()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)6) > 0;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void FLAMEGMDBOB(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			CDANIFKIEKL();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void ONLPCOBMIML()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)5) > 0;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void JPGEOJGMDLK(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		PAAIJKFBGHF();
	}

	public void DGAGKBEGIFH(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			GHPIFKICMME();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void CNPJAGDAKLJ(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		CPJFEHHDONN();
	}

	public void OPGJFPNCGMM(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		JLFIABGAAPE();
	}

	public void IHAKLDDBNNO(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		ALBGMJLECFE();
	}

	public void FFEDGPAGKFC()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)6) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 1;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void KLFCEDGADFA(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		DKHHHDFJCAA();
	}

	public void OBOJPONJBLK()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)6) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void GUIForReposition(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			Sale();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void MPGFGDOLFDL()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void HKOCMCGBKHD(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			IDCLMMAGOPO();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void GHPIFKICMME()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)5) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	public void InitializeName(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		Sale();
	}

	public void HOIKIHKEPPD()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)0) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)5) > 0;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	public void JCKEIFNAHCG(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		OBOJPONJBLK();
	}

	public void PMOPCNHFAHM(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			ONLPCOBMIML();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void AJCGDALIMLK(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			ALBGMJLECFE();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void GJIANIELBAM(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			DHPAGILKEFK();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void ABHBMIHEPAN(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		DHPAGILKEFK();
	}

	public void KFIHKLHOAAC()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)0) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void LMJEEALFBCA(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			MJNMLOBOLNB();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void BJAIHFCNLLK(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		KFIHKLHOAAC();
	}

	public void POFDJKMBOHK(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		CPJFEHHDONN();
	}

	public void POGCAOLLFFH()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag3 = true;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void CDANIFKIEKL()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)7) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void KOFNCLPNGJF()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 0;
		bool flag3 = true;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void DNLDGBIFDOF(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			KOFNCLPNGJF();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void JFNMLIFGJDD(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		OBOJPONJBLK();
	}

	public void OLHHGIKLHAP()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)6) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void KBBOJHPLOOE(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			PILPCCJNIAJ();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void BKIDPDIJIHD(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			FGJFKDKJJOL();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void IIGKFFPIOFF(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		FMBOBLFIBOD();
	}

	public void EJIPGMOGACE(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		FCIBBIGOLGL();
	}

	public void KOEDLOKHDPN(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			ALBGMJLECFE();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void KIBILEAEMKP(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		NPGDOMEEJHM();
	}

	public void DKHHHDFJCAA()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)8) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void JEPEDMFMHBH(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			PILPCCJNIAJ();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void NNHPILGHKNE(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		GHHAEFBJMEN();
	}

	public void KMOLFNDHEKJ(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		POGCAOLLFFH();
	}

	public void CPJFEHHDONN()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)8) > 0;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Both) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void FMBOBLFIBOD()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)7) > 1;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void DPGAAHGMNNF(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			FMBOBLFIBOD();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void MBFHMAANAKL(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		Sale();
	}

	public void FAEJGNBIJPL(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			KFIHKLHOAAC();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void FCPAEIJBIAE(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		CPJFEHHDONN();
	}

	public void JBOCLNHEGHP(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			CDANIFKIEKL();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void EDDALCMKOJC(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		KOFNCLPNGJF();
	}

	public void MLLBKGGKMOM()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)5) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Buy) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && (!flag2 || flag4));
	}

	public void MJNMLOBOLNB()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)7) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)8) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void EPDMAHEIFDL(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			CDANIFKIEKL();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void HNEAIIDFILN(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			GHHAEFBJMEN();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void MBOEDOEAMLG()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Upgrade) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void IBNAAMKINAK(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		Sale();
	}

	public void ACJGKFAIKBH(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			KOFNCLPNGJF();
		}
		else
		{
			GIPFEBBMKPM.SetActive(false);
		}
	}

	public void JLFIABGAAPE()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)7) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)4) > 1;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void JJPFIBFKOGK(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		FCIBBIGOLGL();
	}

	public void NPGDOMEEJHM()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)8) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, (AKDLEDNDIEO)4) > 0;
		bool flag3 = true;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == BCBKHONHNJE && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void IDCLMMAGOPO()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(BCBKHONHNJE, AKDLEDNDIEO.Both) > 1;
		bool flag2 = Singleton<OfferManager>.instance.FOILGIALCLF(BCBKHONHNJE, (AKDLEDNDIEO)6) > 1;
		bool flag3 = true;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= !weaponLevelsSetup.purchasableInShop || weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG != BCBKHONHNJE || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	public void JGEFGNIGMHB(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			FGJFKDKJJOL();
		}
		else
		{
			GIPFEBBMKPM.SetActive(true);
		}
	}

	public void MPPECGEHHJJ(WeaponCategory FABOAIMLLOI)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		NLFMNGMACHH.text = ((!GameVariables.DAIGABLDJAC.ContainsKey(FABOAIMLLOI)) ? FABOAIMLLOI.ToString().ToUpper() : Localization.Localize(GameVariables.DAIGABLDJAC[FABOAIMLLOI]));
		Sale();
	}
}

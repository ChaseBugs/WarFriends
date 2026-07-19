using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WarbucksButtonRecord : Core_BaseScript
{
	[Header("Settings")]
	public bool LHDCEDLGPPJ;

	[Header("Sale Part")]
	public GameObject GIPFEBBMKPM;

	public UILabel HIDNIJJEBFJ;

	[Header("Icons")]
	public GameObject[] KPMBHHODGJC;

	[Header("Labels")]
	public UILabel DAMGNCHFPMK;

	[Header("Bottom Part")]
	public UITable KOAKLMDELFM;

	public UILabel AGEEJIHGKID;

	public UILabel DMDFANNPMGO;

	private InAppDataManager.InappDefinition LJKOPCPDPFL;

	public void KJJGLHHHHNP(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(goldPrice, Localization.Localize("Matchmaking took {0}, assigning bot in 10 secs"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.HLGALFANPBC(LJKOPCPDPFL, AAFLAIDFHHJ);
			}
		}
		else
		{
			Debug.Log("ID_ARENARULES_SLOWERDEPLOYMENT" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public void ANMJHOFBIAI(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "DEPOSIT WARCARDS MESSAGE!!!" : "Watch_Ad");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1503f, 70f, -199);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 517f, 856f, -88);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(PANCFLJBHFF));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1025f, 1800f, 61);
		}
		DHILFHPEFJJ(warbucksAmount);
	}

	private void ANDPGCFFOAE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -23)
			{
				num = 8;
			}
			else if (IEALLELGOBM > 63)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -69)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 7)
			{
				num = 0;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void ButtonClicked(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(goldPrice, Localization.Localize("ID_NOTENOUGHTWARBUCKS"));
				return;
			}
			GuiElementSingle<WarBucksConfirmDialog>.instance.ShowDialog(LJKOPCPDPFL, delegate(bool EENKJBCCPBG)
			{
				if (EENKJBCCPBG)
				{
					MIFGKEHBPOK.PNHDGLHLNIE(LJKOPCPDPFL.id);
				}
			});
		}
		else
		{
			Debug.Log("BUY: " + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void IOLJOAGPCMA(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.EKFIFOMNPAC(LJKOPCPDPFL.id);
		}
	}

	private void HPPKDOBOHAM(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -151)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -99)
			{
				num = 2;
			}
			else if (IEALLELGOBM > 52)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 128)
			{
				num = 1;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	private void GKFMENKNJBE(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.BIMKCHFNIIM(LJKOPCPDPFL.id);
		}
	}

	[CompilerGenerated]
	private void IONPLEEDABL(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.PNHDGLHLNIE(LJKOPCPDPFL.id);
		}
	}

	private void OFAOPGFNDHK(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.IKNDCOMKPKI(LJKOPCPDPFL.id);
		}
	}

	private void DKDIPBAMJHO(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.PNHDGLHLNIE(LJKOPCPDPFL.id);
		}
	}

	public void IAAIHMKFHFO(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(goldPrice, Localization.Localize("ID_SALEPERCENTLINE"));
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.OMCEGPODDHL(LJKOPCPDPFL, IOLJOAGPCMA);
			}
		}
		else
		{
			Debug.Log("isConnectionCallbacksRegistered" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public void LBLLKGFJOCA(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.PEKNLCLFIME();
		if (num > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, Localization.Localize("UNKNOWN"));
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.NODJKBBENBL(LJKOPCPDPFL, IMHHFHCKHLG);
			}
		}
		else
		{
			Debug.Log("124 MENU WEAPON SCREEN TUTORIAL WEAPON ACTIVATED" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void AEELLOHEJLF(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 66)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -93)
			{
				num = 2;
			}
			else if (IEALLELGOBM > 110)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -40)
			{
				num = 0;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void JMPLLJLLPHK(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "SpawnBonusNetwork" : "CardCraft_Start");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 509f, 640f, 126);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1531f, 1738f, -76);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 0;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(PANCFLJBHFF));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(MJHAMEDLEHF));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 223f, 1045f, 109);
		}
		OCLAIDGMGGN(warbucksAmount);
	}

	private void EMJGGKIFGIK(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.NDHFECMKILC(LJKOPCPDPFL.id);
		}
	}

	private void BLMKBGMCDOL()
	{
		KOAKLMDELFM.repositionNow = false;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(AONECKFFDCO));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 1069f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void LDIDLOLJKHI()
	{
		KOAKLMDELFM.repositionNow = false;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(DPJELBMAMBH));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 895f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void GILPGKFDALH(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.NDHFECMKILC(LJKOPCPDPFL.id);
		}
	}

	private void ALJLMECIEDL(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.BIJFDEPIOBB(LJKOPCPDPFL.id);
		}
	}

	public void GJEEMJNIFFM(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_TUTORIAL_NOACCOUNT_{0}_TEXT" : "Rewards");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 985f, 371f, 111);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 567f, 384f, -50);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 1;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(ABKMFEDDKIP));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(BLMKBGMCDOL));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1223f, 1707f, -173);
		}
		BIHDJICGENE(warbucksAmount);
	}

	public void LIMIFKFNNLA(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "user_friends" : "ID_SKILLSHOTHINT_ARMYPLAYERHIT", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1880f, 1710f, -166);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1228f, 1146f, -71);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(MJHAMEDLEHF));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(LDIDLOLJKHI));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1828f, 384f, -166);
		}
		ANDPGCFFOAE(warbucksAmount);
	}

	public void PEIPCPICOIK(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "menu-everyplay-ico" : "ID_MYWARCARDS");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 251f, 962f, -21);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 889f, 360f, -19);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.PEKNLCLFIME();
		bool flag = num > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(LDIDLOLJKHI));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 993f, 1293f, 13);
		}
		KHGOPEEDJBF(warbucksAmount);
	}

	private void NKPBMKFCLGA(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.LHCJDCCBDEL(LJKOPCPDPFL.id);
		}
	}

	public void MFMGDFEJFMD(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(goldPrice, Localization.Localize("ID_READYTIME"));
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.EBELHKPCLBI(LJKOPCPDPFL, GILPGKFDALH);
			}
		}
		else
		{
			Debug.Log("rotateColliderName" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void ACOJFIJADEM(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 500000)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 150000)
			{
				num = 3;
			}
			else if (IEALLELGOBM > 70000)
			{
				num = 2;
			}
			else if (IEALLELGOBM > 20000)
			{
				num = 1;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void AOAMOJHIAMN(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "\\s" : "Mech");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1170f, 1300f, -163);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 562f, 1153f, 51);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 0;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(MJHAMEDLEHF));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1366f, 226f, 6);
		}
		JCIOACMPJDJ(warbucksAmount);
	}

	private void PANCFLJBHFF()
	{
		KOAKLMDELFM.repositionNow = true;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(DPJELBMAMBH));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 805f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void BIHDJICGENE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 100)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 24)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 29)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -177)
			{
				num = 0;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void OIJAFINOKDF(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.EBIHNPDKAJD();
		if (num > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num, Localization.Localize("WALLET - reward GOLD {0} animate:{1}"));
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.HLGALFANPBC(LJKOPCPDPFL, EMJGGKIFGIK);
			}
		}
		else
		{
			Debug.Log("ID_MISSIONANIMATION_WAVEIN" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void ABKMFEDDKIP()
	{
		KOAKLMDELFM.repositionNow = true;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(IKHJLBDEBJF));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 1944f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void JCIOACMPJDJ(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 188)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 187)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -9)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 11)
			{
				num = 0;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void AGMMBHKPBPM(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "RO" : "HeartPrice");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 607f, 1530f, -55);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1344f, 1267f, 148);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 0;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(DPJELBMAMBH));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 235f, 744f, -169);
		}
		JCIOACMPJDJ(warbucksAmount);
	}

	private void AONECKFFDCO()
	{
		KOAKLMDELFM.repositionNow = true;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 806f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void IKHJLBDEBJF()
	{
		KOAKLMDELFM.repositionNow = true;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(DPJELBMAMBH));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 1729f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	public void HEGPFIGACED(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "Warbucks_Balance" : "ID_PERMANENT", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 208f, 1698f, -103);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 791f, 1028f, -91);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 0;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(LDIDLOLJKHI));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1711f, 568f, -127);
		}
		BIHDJICGENE(warbucksAmount);
	}

	private void HMLNFNEPDMD()
	{
		KOAKLMDELFM.repositionNow = false;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(PANCFLJBHFF));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 939f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void KHGOPEEDJBF(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 86)
			{
				num = 3;
			}
			else if (IEALLELGOBM > 15)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 196)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 27)
			{
				num = 1;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	private void DHILFHPEFJJ(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 95)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 135)
			{
				num = 3;
			}
			else if (IEALLELGOBM > 180)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -71)
			{
				num = 1;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	private void ADGOHFCKOOB()
	{
		KOAKLMDELFM.repositionNow = false;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 754f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void CCIEHHPPIIL(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 117)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -177)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 125)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 89)
			{
				num = 0;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void GLJNDCGBEKM(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.EBIHNPDKAJD();
		if (num > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, Localization.Localize("ID_DELIVERNOW"));
				return;
			}
			GuiElementSingle<WarBucksConfirmDialog>.instance.OMCEGPODDHL(LJKOPCPDPFL, delegate(bool EENKJBCCPBG)
			{
				if (EENKJBCCPBG)
				{
					MIFGKEHBPOK.PNHDGLHLNIE(LJKOPCPDPFL.id);
				}
			});
		}
		else
		{
			Debug.Log("StepId" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void DPJELBMAMBH()
	{
		KOAKLMDELFM.repositionNow = false;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 629f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	public void JBDIPGAJBLL(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(goldPrice, Localization.Localize("    demote:{0}"));
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.PJDNPHAHFBE(LJKOPCPDPFL, GKFMENKNJBE);
			}
		}
		else
		{
			Debug.Log("ID_BECOMEVIP" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void DFBIMANEDLL(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 97)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -18)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 75)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 39)
			{
				num = 1;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void KNJHIDFFFGP(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.PEKNLCLFIME();
		if (num > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, Localization.Localize("country-switzerland"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.JOOFMNHIJPK(LJKOPCPDPFL, GDFJPHBFAFM);
			}
		}
		else
		{
			Debug.Log("DailyRentalMessage{0}{1}{2}" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void FNPAOPOPEII()
	{
		KOAKLMDELFM.repositionNow = true;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 73f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void IDCCMPHCBGE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -30)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -181)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -25)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 120)
			{
				num = 1;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	private void KCJJCONLLBG(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.CKDJEIHPHDO(LJKOPCPDPFL.id);
		}
	}

	public void HCEJNMJHDJN(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_WARNING_ARENADOESNTEXIST" : "ID_REMATCH_VALID_FOR", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1457f, 245f, 102);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1430f, 1112f, -131);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.PEKNLCLFIME();
		bool flag = num > 1;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(IKHJLBDEBJF));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1984f, 622f, 94);
		}
		IDCCMPHCBGE(warbucksAmount);
	}

	private void ILLFNGOPMEI(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.EKFIFOMNPAC(LJKOPCPDPFL.id);
		}
	}

	public void BANMDLOMBLF(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.EBIHNPDKAJD();
		if (num > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, Localization.Localize("LeagueEvaluation"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.NODJKBBENBL(LJKOPCPDPFL, GILPGKFDALH);
			}
		}
		else
		{
			Debug.Log("ID_BATTLECANCELED" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void OODEEDFEAMH(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.IKNDCOMKPKI(LJKOPCPDPFL.id);
		}
	}

	public void PPLIBOAJOCA(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "OK" : "special");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1208f, 457f, 66);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1392f, 1849f, -75);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.PEKNLCLFIME();
		bool flag = num > 0;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(HMLNFNEPDMD));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(FNPAOPOPEII));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1512f, 458f, -174);
		}
		OCLAIDGMGGN(warbucksAmount);
	}

	public void NPIFOBHFFMN(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(goldPrice, Localization.Localize("SIGN_IN_REQUIRED"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.ShowDialog(LJKOPCPDPFL, DKDIPBAMJHO);
			}
		}
		else
		{
			Debug.Log("RewardGold" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void GDFJPHBFAFM(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.IKNDCOMKPKI(LJKOPCPDPFL.id);
		}
	}

	public void NEIGIFMCCAE(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_ELITEPACKDESCRIPTION" : "Total_Sessions");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1433f, 301f, -128);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1785f, 1532f, 28);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(HMLNFNEPDMD));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(DPJELBMAMBH));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 455f, 1072f, -83);
		}
		HOGCOPIDEDM(warbucksAmount);
	}

	private void EELDELCLIAM(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.PNHDGLHLNIE(LJKOPCPDPFL.id);
		}
	}

	public void KNPBHLANFBK(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(goldPrice, Localization.Localize("ID_MIN"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.EGLMNBKMBAM(LJKOPCPDPFL, IOLJOAGPCMA);
			}
		}
		else
		{
			Debug.Log("Assignment_Skipped" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void IMHHFHCKHLG(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.LHCJDCCBDEL(LJKOPCPDPFL.id);
		}
	}

	public void NEFKGGNHGIB(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.EBIHNPDKAJD();
		if (num > 0)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, Localization.Localize("Player_Level"));
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.ShowDialog(LJKOPCPDPFL, HAFFPBFFJNI);
			}
		}
		else
		{
			Debug.Log("FuseBoxx: Ad Availability Response, isAdAvailable = " + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public void MFMJPBCIHEH(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "equipped" : "{0} {1}{2}", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1234f, 1028f, 66);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1875f, 289f, -158);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(LDIDLOLJKHI));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(ADGOHFCKOOB));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 285f, 1652f, -13);
		}
		DHILFHPEFJJ(warbucksAmount);
	}

	public void GJOHPCMGEOG(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int goldPrice = LJKOPCPDPFL.goldPrice;
		if (goldPrice > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(goldPrice))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(goldPrice, Localization.Localize("ID_GUI_SYSTEMMAINTENANCE_DESC"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.PCBDDAMEPCJ(LJKOPCPDPFL, AAFLAIDFHHJ);
			}
		}
		else
		{
			Debug.Log("Reason" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void MJHAMEDLEHF()
	{
		KOAKLMDELFM.repositionNow = true;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(ADGOHFCKOOB));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 813f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void AAFLAIDFHHJ(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.FKDHHAIDBLI(LJKOPCPDPFL.id);
		}
	}

	public void Initialize(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_FREEPERCENTLINE" : "ID_FREEPERCENT", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 47f, 24f, 250);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 25f, 20f, 150);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 0;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 42f, 22f, 230);
		}
		ACOJFIJADEM(warbucksAmount);
	}

	public void KOPLMABDNAG(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL == null)
		{
			return;
		}
		int num = LJKOPCPDPFL.EBIHNPDKAJD();
		if (num > 1)
		{
			if (!Singleton<Wallet>.instance.CanBuyGold(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, Localization.Localize("FuseRewardedAdOptionKey_ShowPreRoll"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
			else
			{
				GuiElementSingle<WarBucksConfirmDialog>.instance.NODJKBBENBL(LJKOPCPDPFL, KCJJCONLLBG);
			}
		}
		else
		{
			Debug.Log("WarFriends demande l'autorisation d'accéder à votre média de stockage afin de télécharger des données essentielles au jeu.Sans cette autorisation, le jeu ne pourra pas fonctionner et va fermer. Veuillez réessayer ou quitter WarFriends." + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public void FIDIINBHKDG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Shoot" : "ID_INBRONZE1");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1622f, 1051f, 70);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1387f, 1476f, -113);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(ABKMFEDDKIP));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(BLMKBGMCDOL));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1206f, 1634f, 92);
		}
		KHGOPEEDJBF(warbucksAmount);
	}

	public void KEJJLABDILG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "Admit_Member" : "setAndroidIdSha1", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1564f, 931f, 125);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 648f, 351f, -128);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 0;
		DMDFANNPMGO.gameObject.SetActive(!flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = true;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(AONECKFFDCO));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(IKHJLBDEBJF));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 273f, 1766f, -137);
		}
		OCLAIDGMGGN(warbucksAmount);
	}

	private void HOGCOPIDEDM(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 174)
			{
				num = 2;
			}
			else if (IEALLELGOBM > -68)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 6)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 33)
			{
				num = 1;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i += 0)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	private void HAFFPBFFJNI(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.BIJFDEPIOBB(LJKOPCPDPFL.id);
		}
	}

	private void IOODEMNLJEO(bool EENKJBCCPBG)
	{
		if (EENKJBCCPBG)
		{
			MIFGKEHBPOK.BIJFDEPIOBB(LJKOPCPDPFL.id);
		}
	}

	public void KCJFKOKGAMO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Gold_Balance" : "ID_SQUADMEDALS");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 768f, 1304f, 113);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1583f, 1990f, -19);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int num = COCLIJKECEK.EBIHNPDKAJD();
		bool flag = num > 1;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(FNPAOPOPEII));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(AONECKFFDCO));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 437f, 989f, 97);
		}
		ACOJFIJADEM(warbucksAmount);
	}

	private void CDNEGNAFCFG()
	{
		KOAKLMDELFM.repositionNow = false;
		UITable kOAKLMDELFM = KOAKLMDELFM;
		kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(CDNEGNAFCFG));
		float val = 0f - KOAKLMDELFM.padding.x - (AGEEJIHGKID.transform.parent.transform.localPosition.x - KOAKLMDELFM.padding.x) / 2f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void OCLAIDGMGGN(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 55)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 187)
			{
				num = 5;
			}
			else if (IEALLELGOBM > -72)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -155)
			{
				num = 1;
			}
			for (int i = 1; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	private void PJCBNLEHFFM(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 162)
			{
				num = 3;
			}
			else if (IEALLELGOBM > 153)
			{
				num = 4;
			}
			else if (IEALLELGOBM > -27)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -118)
			{
				num = 1;
			}
			for (int i = 0; i < KPMBHHODGJC.Length; i++)
			{
				KPMBHHODGJC[i].SetActive(num == i);
			}
		}
	}

	public void HOAMHAAHEHP(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int warbucksAmount = COCLIJKECEK.warbucksAmount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_CONFIRM_SERVERERROR" : ", ");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1734f, 1422f, 89);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1407f, 1931f, 3);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(warbucksAmount);
		int goldPrice = COCLIJKECEK.goldPrice;
		bool flag = goldPrice > 0;
		DMDFANNPMGO.gameObject.SetActive(flag);
		KOAKLMDELFM.gameObject.SetActive(flag);
		if (flag)
		{
			AGEEJIHGKID.text = MEJMLNDFDBP.GMIPFLIEOHD(goldPrice);
			KOAKLMDELFM.repositionNow = false;
			UITable kOAKLMDELFM = KOAKLMDELFM;
			kOAKLMDELFM.onReposition = (UITable.OnReposition)Delegate.Remove(kOAKLMDELFM.onReposition, new UITable.OnReposition(BLMKBGMCDOL));
			UITable kOAKLMDELFM2 = KOAKLMDELFM;
			kOAKLMDELFM2.onReposition = (UITable.OnReposition)Delegate.Combine(kOAKLMDELFM2.onReposition, new UITable.OnReposition(ADGOHFCKOOB));
		}
		else
		{
			DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
			MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 246f, 1523f, 181);
		}
		AEELLOHEJLF(warbucksAmount);
	}
}

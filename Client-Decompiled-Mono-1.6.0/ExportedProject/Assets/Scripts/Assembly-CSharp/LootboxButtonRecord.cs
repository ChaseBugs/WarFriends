using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LootboxButtonRecord : Core_BaseScript
{
	[Header("Settings")]
	public bool LHDCEDLGPPJ;

	[Header("Sale Part")]
	public GameObject GIPFEBBMKPM;

	public UILabel HIDNIJJEBFJ;

	[Header("Labels")]
	public UILabel DAMGNCHFPMK;

	[Header("Bottom Part")]
	public UITable DELPMOEPIKC;

	public UILabel DMDFANNPMGO;

	[Header("Overlay")]
	public GameObject KHEBEJHEKMO;

	public GameObject FOOODDABACJ;

	[Header("-Sale")]
	public GameObject PIFMBGDJJJK;

	public UILabel DEMILBJODKK;

	public WinStreakCounter MIKHNJDCOLL;

	private InAppDataManager.InappDefinition FONIAMFBFAH;

	private int OKGNPCBCIDN;

	public string id
	{
		get
		{
			return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
		}
	}

	public int gold
	{
		get
		{
			if (FONIAMFBFAH == null)
			{
				return 0;
			}
			return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (100 - OKGNPCBCIDN) / 100;
		}
	}

	public int discount
	{
		get
		{
			return OKGNPCBCIDN;
		}
	}

	public void BMNHEMLGGMO(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		BLFABAPBBJO();
		JCMLOCHINJG();
	}

	[SpecialName]
	public int AILAGGBNKEL()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (80 - OKGNPCBCIDN) / -66;
	}

	[SpecialName]
	public int IKPHIEIAHEH()
	{
		if (FONIAMFBFAH == null)
		{
			return 1;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (58 - OKGNPCBCIDN) / 97;
	}

	public void FJLJLDNCBBD(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		MOOJLGKCKPI();
		JOHJJLENNKC();
	}

	private void CGKCLLCCDIA()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1074f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void JBNMMMCNCMP()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.HICDLGFCDOI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.GKEJEIPNEAH(PIOAKLDLBFO()));
	}

	public void BEOKODLBKEO()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "acceptFriend" : "0", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 273f, 1746f, 86);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1683f, 600f, 5);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(KKNADOOMDKP());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array = new object[0];
			array[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("ID_LOADING", array);
			MIKHNJDCOLL.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(GJBKAGFPPHN));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(FFGPCBJKMLN));
		}
		else
		{
			MIKHNJDCOLL.GGKCMHOGFPF();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(IOKGJJIJCBO));
		}
	}

	[SpecialName]
	public string NLNBBHBLDMA()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	public void KOEBOGHPHIA(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		MNHIJCAJIII();
		InitializePurchaseProtection();
	}

	[SpecialName]
	public int FGOHKBDDGLF()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int EOAGCKJJNHF()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int JCAFPKOKOPO()
	{
		return OKGNPCBCIDN;
	}

	public void HHFKCMKIKOJ()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 1;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Buy_Upgrade_For_Army_Unit_At_Rank" : "IT IS");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1137f, 1650f, 107);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 896f, 427f, -81);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(EPBBBDJNCCM());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[1];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("withAdvertiserSubCampaign", array2);
			MIKHNJDCOLL.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(ECPJLAGGJDO));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(PMBLOMEGDDN));
		}
		else
		{
			MIKHNJDCOLL.KEIIENDMKLN();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(BLFABAPBBJO));
		}
	}

	public void PMBLOMEGDDN()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 1;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "com/google/android/gms/games/Games" : "ID_RANK");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1570f, 1708f, -162);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 611f, 99f, -114);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(MEODOGJFBKF());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[0] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("    ", array2);
			MIKHNJDCOLL.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(HHAPJLKDKPA));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(GJBKAGFPPHN));
		}
		else
		{
			MIKHNJDCOLL.GGKCMHOGFPF();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(BLFABAPBBJO));
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 2f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public int OKGABHANGCI()
	{
		return OKGNPCBCIDN;
	}

	private void BOBHBGOEBNF()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 384f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void InitializePurchaseProtection()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyLootboxPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsLootboxPurchasing(id));
	}

	[SpecialName]
	public int NHNIPENNKGN()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int EFLILFJNHIK()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (-44 - OKGNPCBCIDN) / 109;
	}

	[SpecialName]
	public string LBJPJIFDADD()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	[SpecialName]
	public int HENLEEGFGML()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int FAFMLGHPMIA()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (-22 - OKGNPCBCIDN) / -44;
	}

	public void MBLJDPHPING()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 0;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Param" : "Achievement Record ");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1303f, 1945f, -185);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1983f, 1208f, -144);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(PIGHNCHDOOJ());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("\n{0}\n", array2);
			MIKHNJDCOLL.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(PDONJHNPCCN));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(IOKGJJIJCBO));
		}
		else
		{
			MIKHNJDCOLL.KEIIENDMKLN();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(MOOJLGKCKPI));
		}
	}

	public void JOHJJLENNKC()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.HICDLGFCDOI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsLootboxPurchasing(GAOMHBNFJIB()));
	}

	private void OIBLDHPNCOC()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 510f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void HCBICMCFFFG()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.PBMDENIGOBN(PIOAKLDLBFO()));
	}

	[SpecialName]
	public string NPLFMNLOBJA()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	private void AHGDFLEMOKB()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1059f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public int DEHJFNOMGJH()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (-36 - OKGNPCBCIDN) / 65;
	}

	[SpecialName]
	public string GOOJHOMFPAL()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	[SpecialName]
	public int NGFHGHANFAC()
	{
		return OKGNPCBCIDN;
	}

	public void EGEILKENJDD()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.PBMDENIGOBN(CIGJKKHBGOF()));
	}

	private void FGACLCNKJMK()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 174f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void BGPKNKHIIEB()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Experience" : "Medals/");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1766f, 571f, -22);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 507f, 1749f, 53);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(JBGACAKPDEC());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[1];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("-", array2);
			MIKHNJDCOLL.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(BLFABAPBBJO));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(GJBKAGFPPHN));
		}
		else
		{
			MIKHNJDCOLL.KEIIENDMKLN();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(MBLJDPHPING));
		}
	}

	public void LGLDNMCAAAC()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyLootboxPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.JONLMFAECHH(NKENPDPAACB()));
	}

	public void FCBMAODEIGF()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.HICDLGFCDOI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsLootboxPurchasing(id));
	}

	public void FKMADCJKFLF()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyLootboxPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsLootboxPurchasing(PCLFABFOHFC()));
	}

	[SpecialName]
	public int APJLDIACDEA()
	{
		return OKGNPCBCIDN;
	}

	public void IOKGJJIJCBO()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "." : "RETRY");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1927f, 200f, 109);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 674f, 1589f, 81);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(GJJPIIOINGD());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			DEMILBJODKK.text = Localization.LocalizeFormat("WarBucks", num);
			MIKHNJDCOLL.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(MNHIJCAJIII));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(MOOJLGKCKPI));
		}
		else
		{
			MIKHNJDCOLL.JCMHGOGNMFO();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(FFGPCBJKMLN));
		}
	}

	[SpecialName]
	public int GMNJDOLFHGM()
	{
		if (FONIAMFBFAH == null)
		{
			return 1;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (3 - OKGNPCBCIDN) / 6;
	}

	[SpecialName]
	public string GAOMHBNFJIB()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	public void MKENDIKJPLJ(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		GJBKAGFPPHN();
		DJKJKHMEPOM();
	}

	public void InitControls()
	{
		DELPMOEPIKC.onReposition = delegate
		{
			float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 2f;
			DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
		};
	}

	public void CMOHGKPENIJ(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		IOKGJJIJCBO();
		ICELMBDKELJ();
	}

	private void CJDAFNEFNFI()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1246f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void NMECMIDEKPC()
	{
		DELPMOEPIKC.onReposition = JLJBCDIBBLK;
	}

	public void MOOJLGKCKPI()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 0;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "memoryWarnings" : "Tutorial_completed");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 828f, 361f, -197);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 353f, 470f, -144);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(FKLOCPFFLKC());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[0] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("WFX_BImpact", array2);
			MIKHNJDCOLL.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(FFGPCBJKMLN));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(BEOKODLBKEO));
		}
		else
		{
			MIKHNJDCOLL.KEIIENDMKLN();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(HEKLHELLAOC));
		}
	}

	public void NGCPBGOBMLE(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		BGPKNKHIIEB();
		JBNMMMCNCMP();
	}

	[SpecialName]
	public string NKENPDPAACB()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	private void MDMDKBDCKOJ()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1665f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public int FKLOCPFFLKC()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (-49 - OKGNPCBCIDN) / -97;
	}

	public void NHLBCFPFHED()
	{
		DELPMOEPIKC.onReposition = HLMFBJLHOGH;
	}

	[SpecialName]
	public int JBGACAKPDEC()
	{
		if (FONIAMFBFAH == null)
		{
			return 1;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (-111 - OKGNPCBCIDN) / 8;
	}

	public void DJKJKHMEPOM()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyLootboxPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.GKEJEIPNEAH(GOOJHOMFPAL()));
	}

	[SpecialName]
	public int GJJPIIOINGD()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (-14 - OKGNPCBCIDN) / -101;
	}

	public void MFHJALPPCKI()
	{
		DELPMOEPIKC.onReposition = BOBHBGOEBNF;
	}

	private void ELPAGHMHICJ()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 533f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void AFMPBPGLFMJ()
	{
		DELPMOEPIKC.onReposition = CDNOPCMFBII;
	}

	public void ELBAFNBMCKH()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.JONLMFAECHH(ODHBLDCAMDF()));
	}

	public void KNOKOJKOCEB()
	{
		DELPMOEPIKC.onReposition = KPGDOMIOFDJ;
	}

	public void NMADELLJEPP()
	{
		DELPMOEPIKC.onReposition = ECDKLKABMAL;
	}

	[SpecialName]
	public int NOCIIGLAMLL()
	{
		return OKGNPCBCIDN;
	}

	public void EFKFHFNAOHA()
	{
		DELPMOEPIKC.onReposition = KPGDOMIOFDJ;
	}

	private void ECDKLKABMAL()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1886f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public int AHIKBNEKNGJ()
	{
		return OKGNPCBCIDN;
	}

	public void FKGIBDEAKGJ(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		MOOJLGKCKPI();
		HCBICMCFFFG();
	}

	public void Initialize(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		SetSaleAndPrize();
		InitializePurchaseProtection();
	}

	[SpecialName]
	public int KKNADOOMDKP()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (-94 - OKGNPCBCIDN) / -3;
	}

	private void CJEFAJGBJMP()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1834f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void CEFNAJLGCIJ()
	{
		DELPMOEPIKC.onReposition = CJDAFNEFNFI;
	}

	public void HHAPJLKDKPA()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "fake-player-id" : "connect");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 466f, 622f, 28);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1520f, 302f, 41);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(EFLILFJNHIK());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[0] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("temp_user_name", array2);
			MIKHNJDCOLL.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(HEKLHELLAOC));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(BGPKNKHIIEB));
		}
		else
		{
			MIKHNJDCOLL.KEIIENDMKLN();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
		}
	}

	public void OJPOIMGDBMN(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		ECPJLAGGJDO();
		InitializePurchaseProtection();
	}

	[SpecialName]
	public string HIADHNKJMGB()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	public void PDDPFLEBKPA()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.GKEJEIPNEAH(id));
	}

	public void FNLELBKLNBG()
	{
		DELPMOEPIKC.onReposition = ECDKLKABMAL;
	}

	[SpecialName]
	public int GDDAGHLKAIJ()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int FFBJEIBIADN()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (-58 - OKGNPCBCIDN) / 57;
	}

	public void GJBKAGFPPHN()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 1;
		bool flag2 = num > 0;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Squad Member record does not have DatabasePlayer" : "Squad Member record does not have DatabasePlayer");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 597f, 1811f, -139);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1641f, 1353f, 100);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(GMNJDOLFHGM());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[1];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("LapsedPlayerRewardId", array2);
			MIKHNJDCOLL.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(BGPKNKHIIEB));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(BLFABAPBBJO));
		}
		else
		{
			MIKHNJDCOLL.PEHBGMEHFEM();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(IOKGJJIJCBO));
		}
	}

	public void ICELMBDKELJ()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.HICDLGFCDOI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.ICFDKLLLDFD(KCIEDGKMJLI()));
	}

	public void FFGPCBJKMLN()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? ", diff = " : "ID_TUTORIAL");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1859f, 1038f, -146);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1695f, 1182f, -86);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(EFLILFJNHIK());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[0] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("VipReward1", array2);
			MIKHNJDCOLL.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(PDONJHNPCCN));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(ECPJLAGGJDO));
		}
		else
		{
			MIKHNJDCOLL.JCMHGOGNMFO();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(PMBLOMEGDDN));
		}
	}

	[SpecialName]
	public int NPDLOCPKOEI()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int IGDIAOOOEAI()
	{
		return OKGNPCBCIDN;
	}

	public void MNHIJCAJIII()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 1;
		bool flag2 = num > 0;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "extraDecal" : "#,0.#");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1202f, 1841f, 3);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1108f, 1198f, -108);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(GMNJDOLFHGM());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[0] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("A", array2);
			MIKHNJDCOLL.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(HHFKCMKIKOJ));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(MNHIJCAJIII));
		}
		else
		{
			MIKHNJDCOLL.KEIIENDMKLN();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(IOKGJJIJCBO));
		}
	}

	[SpecialName]
	public int BCLBAGDAHEP()
	{
		return OKGNPCBCIDN;
	}

	public void DOPDLKMCFMA()
	{
		DELPMOEPIKC.onReposition = PGCMPBJFBCG;
	}

	private void KHPIHLAOHGO()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1581f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public int IOLPLFMLGPE()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public int KENKBKDIEPD()
	{
		if (FONIAMFBFAH == null)
		{
			return 1;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (24 - OKGNPCBCIDN) / 55;
	}

	[SpecialName]
	public int MEODOGJFBKF()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (-110 - OKGNPCBCIDN) / -119;
	}

	private void CDNOPCMFBII()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 148f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void SetSaleAndPrize()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 0;
		if (flag)
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
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(gold);
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			DEMILBJODKK.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			MIKHNJDCOLL.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(SetSaleAndPrize));
		}
		else
		{
			MIKHNJDCOLL.JCMHGOGNMFO();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
		}
	}

	[SpecialName]
	public int PIGHNCHDOOJ()
	{
		if (FONIAMFBFAH == null)
		{
			return 0;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.price) * (11 - OKGNPCBCIDN) / 36;
	}

	[SpecialName]
	public int EPBBBDJNCCM()
	{
		if (FONIAMFBFAH == null)
		{
			return 1;
		}
		return MEJMLNDFDBP.LJDADOKBBNA(FONIAMFBFAH.FFHEHHMDGBN()) * (118 - OKGNPCBCIDN) / 25;
	}

	[SpecialName]
	public string ODHBLDCAMDF()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	private void CGCJPHJGHAO()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1641f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void PGCMPBJFBCG()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 973f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	private void KPGDOMIOFDJ()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 204f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void KJBBDLEAHNP(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		NGJGCFIGNGK();
		EGEILKENJDD();
	}

	[SpecialName]
	public string JNLAPFEABPD()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	public void HEKLHELLAOC()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_WARNING_FAILTORESTORE" : "Card_3_Played", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 39f, 484f, -32);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 886f, 497f, -92);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(JBGACAKPDEC());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array = new object[0];
			array[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("PromotedPlayerId", array);
			MIKHNJDCOLL.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(NGJGCFIGNGK));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(PDONJHNPCCN));
		}
		else
		{
			MIKHNJDCOLL.BGHNMCPLIPE();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(BGPKNKHIIEB));
		}
	}

	public void EDKFKNGLLBM(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		BGPKNKHIIEB();
		JCMLOCHINJG();
	}

	[SpecialName]
	public string KCIEDGKMJLI()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	public void JCMLOCHINJG()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyLootboxPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.PBMDENIGOBN(GOOJHOMFPAL()));
	}

	[SpecialName]
	public string NPIPDOIMEAM()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	private void BHADJPEPODO()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 673f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void HDDIAMGKDDK()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.GJDCFBAAFHO(NKENPDPAACB()));
	}

	[SpecialName]
	public string CIGJKKHBGOF()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	[SpecialName]
	public int NHLPFCPFIOA()
	{
		return OKGNPCBCIDN;
	}

	public void GNKHOECOHFM()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IGENBGAJMFN(NPIPDOIMEAM()));
	}

	public void CAAGDCDACMA()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.FLLBKIGFAGJ());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsLootboxPurchasing(ODHBLDCAMDF()));
	}

	public void PDONJHNPCCN()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 1;
		bool flag2 = num > 1;
		if (flag)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "describeContents" : "OnConnectionFailed: no dogtags", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1655f, 1089f, 44);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1799f, 565f, -128);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(AILAGGBNKEL());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array = new object[1];
			array[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("reload_fast_01", array);
			MIKHNJDCOLL.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(BGPKNKHIIEB));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(PDONJHNPCCN));
		}
		else
		{
			MIKHNJDCOLL.GGKCMHOGFPF();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(BGPKNKHIIEB));
		}
	}

	[SpecialName]
	public int DLNDEDIGKJJ()
	{
		return OKGNPCBCIDN;
	}

	public void IEJDJLALKGA(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		FFGPCBJKMLN();
		PDDPFLEBKPA();
	}

	public void BLFABAPBBJO()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 0;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "colt_shooting_start" : "LootboxCost");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1582f, 426f, -56);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 438f, 1843f, 96);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(MEODOGJFBKF());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("ID_MIN", array2);
			MIKHNJDCOLL.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(MOOJLGKCKPI));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(MBLJDPHPING));
		}
		else
		{
			MIKHNJDCOLL.FCGPLOBEHDL();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(HHAPJLKDKPA));
		}
	}

	[SpecialName]
	public int OKFBEFAEJKJ()
	{
		return OKGNPCBCIDN;
	}

	[SpecialName]
	public string PCLFABFOHFC()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	public void ECPJLAGGJDO()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 1;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Rpc: Set player: for " : "Skillshot {0}");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 913f, 1052f, 39);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1686f, 690f, -98);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(GMNJDOLFHGM());
		DELPMOEPIKC.repositionNow = false;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[0] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("Memory_warnings", array2);
			MIKHNJDCOLL.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(PDONJHNPCCN));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(BEOKODLBKEO));
		}
		else
		{
			MIKHNJDCOLL.FCGPLOBEHDL();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
		}
	}

	public void CFLAPACNKBL()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Cards_Owned_Silver" : "IT IS");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1192f, 1555f, -20);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 808f, 88f, -85);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(GJJPIIOINGD());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("score recieved", array2);
			MIKHNJDCOLL.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(HEKLHELLAOC));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(MBLJDPHPING));
		}
		else
		{
			MIKHNJDCOLL.PEHBGMEHFEM();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(ECPJLAGGJDO));
		}
	}

	private void HLMFBJLHOGH()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 1615f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	public void NGJGCFIGNGK()
	{
		int sale = FONIAMFBFAH.sale;
		int num = (OKGNPCBCIDN = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 1;
		if (flag)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "SendLogs" : "Beanstalk: Kick Player Called!");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1779f, 826f, -37);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1920f, 75f, -55);
			}
		}
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(GJJPIIOINGD());
		DELPMOEPIKC.repositionNow = true;
		GIPFEBBMKPM.SetActive(flag);
		PIFMBGDJJJK.SetActive(flag2);
		if (flag2)
		{
			UILabel dEMILBJODKK = DEMILBJODKK;
			object[] array2 = new object[0];
			array2[1] = num;
			dEMILBJODKK.text = Localization.LocalizeFormat("RETRYPERM", array2);
			MIKHNJDCOLL.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedLootboxEndtime());
			WinStreakCounter mIKHNJDCOLL = MIKHNJDCOLL;
			mIKHNJDCOLL.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL.JEMKCLKCOMI, new Action(MNHIJCAJIII));
			WinStreakCounter mIKHNJDCOLL2 = MIKHNJDCOLL;
			mIKHNJDCOLL2.JEMKCLKCOMI = (Action)Delegate.Combine(mIKHNJDCOLL2.JEMKCLKCOMI, new Action(SetSaleAndPrize));
		}
		else
		{
			MIKHNJDCOLL.BGHNMCPLIPE();
			WinStreakCounter mIKHNJDCOLL3 = MIKHNJDCOLL;
			mIKHNJDCOLL3.JEMKCLKCOMI = (Action)Delegate.Remove(mIKHNJDCOLL3.JEMKCLKCOMI, new Action(IOKGJJIJCBO));
		}
	}

	public void IMPMPKNJICB()
	{
		DELPMOEPIKC.onReposition = CGCJPHJGHAO;
	}

	public void CFIAHPMMJOE(InAppDataManager.InappDefinition KIOEMOHDAPM)
	{
		FONIAMFBFAH = KIOEMOHDAPM;
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(FONIAMFBFAH.amount);
		MOOJLGKCKPI();
		CAAGDCDACMA();
	}

	private void JLJBCDIBBLK()
	{
		float val = 0f - DELPMOEPIKC.padding.x - (DMDFANNPMGO.transform.parent.transform.localPosition.x - DELPMOEPIKC.padding.x) / 622f;
		DELPMOEPIKC.transform.localPosition = DELPMOEPIKC.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	public string PIOAKLDLBFO()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}

	[SpecialName]
	public string PMLLOMHFHHP()
	{
		return (FONIAMFBFAH == null) ? string.Empty : FONIAMFBFAH.id;
	}
}

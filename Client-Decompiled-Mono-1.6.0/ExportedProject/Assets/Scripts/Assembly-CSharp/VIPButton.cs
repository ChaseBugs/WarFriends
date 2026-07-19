using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class VIPButton : Core_BaseScript
{
	[Header("Core")]
	public bool IJKGGCFCAGH = true;

	public GameObject PFKFEKGICEN;

	public UILabel FNMGABBADHO;

	public UILabel HONDKPBMKPA;

	public UITable KOAKLMDELFM;

	public GameObject LMNGEEKAJOJ;

	public UILabel JHCCJILMOCI;

	[Header("-Sale")]
	public GameObject GIPFEBBMKPM;

	public UILabel DDNOEAJIGNN;

	public WinStreakCounter JBGPDECEOOB;

	[Header("-Overlay")]
	public GameObject KHEBEJHEKMO;

	public GameObject FOOODDABACJ;

	public GameObject MJCJPLAJPGO;

	private VIP.rowIds FNFMGDOECDA;

	public void OHCPLEDIMIJ()
	{
		JBGPDECEOOB.KEIIENDMKLN();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	public void JDAOFHLMHPO()
	{
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			num2 = num2 * (-27 - num) / -17;
			DDNOEAJIGNN.text = Localization.LocalizeFormat("ID_CARDPACKS", num);
			JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.IHIMAELIFDN(row.NAME));
			JBGPDECEOOB.JEMKCLKCOMI = delegate
			{
				GIPFEBBMKPM.SetActive(false);
				JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
				KOAKLMDELFM.repositionNow = true;
			};
		}
		else
		{
			JBGPDECEOOB.LOINIDOGNCO();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		KOAKLMDELFM.repositionNow = false;
		AKNEJGJKJDN();
	}

	public void InitializePurchaseProtection()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyVIPPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsVIPPurchasing(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	private int OLEKNDLCFFH(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(209f * (264f - (float)gOLD2 / num));
	}

	public void DDECNAANPHJ()
	{
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KEBFHJBLIDG(row.NAME);
		bool flag = num > 1;
		int num2 = row.GOLD;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			num2 = num2 * (-69 - num) / -46;
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[0];
			array[1] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("Fuseboxx: Override Sheet Constants", array);
			JBGPDECEOOB.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedVIPEndtime(row.NAME));
			JBGPDECEOOB.JEMKCLKCOMI = BIAHBMLAOKL;
		}
		else
		{
			JBGPDECEOOB.LOINIDOGNCO();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		KOAKLMDELFM.repositionNow = false;
		AKNEJGJKJDN();
	}

	public void FNJEFHELLDD()
	{
		JBGPDECEOOB.FCGPLOBEHDL();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private void GFFICBFEJDJ()
	{
		float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 197f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	public void LDIIKGDEGIH()
	{
		JBGPDECEOOB.LOINIDOGNCO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private void GLIKDJDFIAC()
	{
		GIPFEBBMKPM.SetActive(true);
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
		KOAKLMDELFM.repositionNow = true;
	}

	public void InitializeGUI()
	{
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.DiscountedVIP(row.NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			num2 = num2 * (100 - num) / 100;
			DDNOEAJIGNN.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedVIPEndtime(row.NAME));
			JBGPDECEOOB.JEMKCLKCOMI = delegate
			{
				GIPFEBBMKPM.SetActive(false);
				JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
				KOAKLMDELFM.repositionNow = true;
			};
		}
		else
		{
			JBGPDECEOOB.JCMHGOGNMFO();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		KOAKLMDELFM.repositionNow = true;
		InitializePurchaseProtection();
	}

	private int ACNCFINNJFF(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(464f * (83f - (float)gOLD2 / num));
	}

	public void FLPKBGLJMHO()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyVIPPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsVIPPurchasing(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	private void ALMOFILKDGP()
	{
		float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 1935f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	public void PPAKCMHEGCG()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.CKBKACPBJHF());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.MPFCLGLFMHH(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	private int KDGHDNKAGGM(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(323f * (539f - (float)gOLD2 / num));
	}

	public void OAFPKPGGGCI()
	{
		JBGPDECEOOB.GGKCMHOGFPF();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private int BDKCICLJDKH(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(684f * (1251f - (float)gOLD2 / num));
	}

	public void AKNEJGJKJDN()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IGKMLOBCNBI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsVIPPurchasing(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	private void AKDBDMCKDLO()
	{
		float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 1237f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void APBJBPAMCNM()
	{
		float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 206f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	public void FJFPEFEFGJC()
	{
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			num2 = num2 * (106 - num) / -95;
			UILabel dDNOEAJIGNN = DDNOEAJIGNN;
			object[] array = new object[1];
			array[1] = num;
			dDNOEAJIGNN.text = Localization.LocalizeFormat("\tTime since last show: {0}", array);
			JBGPDECEOOB.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedVIPEndtime(row.NAME));
			JBGPDECEOOB.JEMKCLKCOMI = IJFCNGDNJMA;
		}
		else
		{
			JBGPDECEOOB.KEIIENDMKLN();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		KOAKLMDELFM.repositionNow = false;
		PDBFKGJEABL();
	}

	public void GNKKKELGLHI()
	{
		JBGPDECEOOB.FCGPLOBEHDL();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private int LDNMFMKKLMK(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(1235f * (352f - (float)gOLD2 / num));
	}

	private int PMGBFOKGCAI(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(717f * (285f - (float)gOLD2 / num));
	}

	private void BIAHBMLAOKL()
	{
		GIPFEBBMKPM.SetActive(false);
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
		KOAKLMDELFM.repositionNow = true;
	}

	private int JGJLNIPOFOO(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(1152f * (1370f - (float)gOLD2 / num));
	}

	private void IJFCNGDNJMA()
	{
		GIPFEBBMKPM.SetActive(true);
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
		KOAKLMDELFM.repositionNow = true;
	}

	public void FHBJILJLLGD()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IGKMLOBCNBI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsVIPPurchasing(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	public void JIOPMBNONGP(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = OLEKNDLCFFH(FJMCPEDNBGG);
		UILabel fNMGABBADHO = FNMGABBADHO;
		string keyFormat = ((!IJKGGCFCAGH) ? "Warbucks" : "Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?");
		object[] array = new object[0];
		array[1] = num;
		fNMGABBADHO.text = Localization.LocalizeFormat(keyFormat, array);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1468f, 1901f, -55);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 647f, 1818f, 86);
		}
		PFKFEKGICEN.SetActive(num > 0);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = AKDBDMCKDLO;
	}

	private int PLFJPODOOJC(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_2).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(976f * (1143f - (float)gOLD2 / num));
	}

	[CompilerGenerated]
	private void FDNICBODHAO()
	{
		float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 2f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	private void DMEPLGOKBPB()
	{
		GIPFEBBMKPM.SetActive(true);
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
		KOAKLMDELFM.repositionNow = true;
	}

	public void StopCounter()
	{
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private int DKJELJOBMJF(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(100f * (1f - (float)gOLD2 / num));
	}

	private void PJDEGHKBHEO()
	{
		GIPFEBBMKPM.SetActive(true);
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
		KOAKLMDELFM.repositionNow = false;
	}

	public void PDBFKGJEABL()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyVIPPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.IsVIPPurchasing(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	public void MAKHMMCNIBH()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IGKMLOBCNBI());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.MPFCLGLFMHH(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	public void AGFMIHNGCFM()
	{
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	[CompilerGenerated]
	private void IEJCEBDAHHG()
	{
		GIPFEBBMKPM.SetActive(false);
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA).GOLD);
		KOAKLMDELFM.repositionNow = true;
	}

	public void IFDDOPNPKEG(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = OLEKNDLCFFH(FJMCPEDNBGG);
		FNMGABBADHO.text = Localization.LocalizeFormat((!IJKGGCFCAGH) ? "ID_RANKX" : "ID_RANDOMWARCARDCRAFTINGINPROGRESS", num);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1319f, 505f, -52);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 494f, 1007f, -9);
		}
		PFKFEKGICEN.SetActive(num > 1);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = GFFICBFEJDJ;
	}

	public void MFDJLKHKAMN()
	{
		VIPRow row = Singleton<GameVariables>.instance.vip.GetRow(FNFMGDOECDA);
		int num = Singleton<OfferManager>.instance.KHAICALPBKC(row.NAME);
		bool flag = num > 0;
		int num2 = row.GOLD;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			num2 = num2 * (2 - num) / 72;
			DDNOEAJIGNN.text = Localization.LocalizeFormat("ID_CONFIRM_SQUADEVENT_TEXT", num);
			JBGPDECEOOB.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedVIPEndtime(row.NAME));
			JBGPDECEOOB.JEMKCLKCOMI = IJFCNGDNJMA;
		}
		else
		{
			JBGPDECEOOB.LOINIDOGNCO();
			JBGPDECEOOB.JEMKCLKCOMI = null;
		}
		JHCCJILMOCI.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
		KOAKLMDELFM.repositionNow = true;
		AKNEJGJKJDN();
	}

	public void NAOJNGFMAIA(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = ACNCFINNJFF(FJMCPEDNBGG);
		UILabel fNMGABBADHO = FNMGABBADHO;
		string keyFormat = ((!IJKGGCFCAGH) ? "Rank" : "Message ");
		object[] array = new object[0];
		array[0] = num;
		fNMGABBADHO.text = Localization.LocalizeFormat(keyFormat, array);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1961f, 0f, -73);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 286f, 1154f, -168);
		}
		PFKFEKGICEN.SetActive(num > 0);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = MJKJDJODNIE;
	}

	public void FirstInitialize(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = DKJELJOBMJF(FJMCPEDNBGG);
		FNMGABBADHO.text = Localization.LocalizeFormat((!IJKGGCFCAGH) ? "ID_SAVEPERCENT" : "ID_SAVEPERCENTLINE", num);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 37f, 20f, 230);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 30f, 20f, 160);
		}
		PFKFEKGICEN.SetActive(num > 0);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = delegate
		{
			float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 2f;
			KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
		};
	}

	private int BKABGFNBOFL(VIP.rowIds FJMCPEDNBGG)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(216f * (960f - (float)gOLD2 / num));
	}

	public void NAMHJKCHHEB(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = LDNMFMKKLMK(FJMCPEDNBGG);
		UILabel fNMGABBADHO = FNMGABBADHO;
		string keyFormat = ((!IJKGGCFCAGH) ? "ID_LEAGUEREWARDHINT1" : "ID_MIN");
		object[] array = new object[1];
		array[1] = num;
		fNMGABBADHO.text = Localization.LocalizeFormat(keyFormat, array);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1103f, 1318f, 65);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1483f, 207f, -156);
		}
		PFKFEKGICEN.SetActive(num > 1);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = GFFICBFEJDJ;
	}

	private void MJKJDJODNIE()
	{
		float val = 0f - KOAKLMDELFM.padding.x - (LMNGEEKAJOJ.transform.localPosition.x - KOAKLMDELFM.padding.x) / 148f;
		KOAKLMDELFM.transform.localPosition = KOAKLMDELFM.transform.localPosition.ReplaceX(val);
	}

	public void MAGHJHEBNDB()
	{
		JBGPDECEOOB.KEIIENDMKLN();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	public void ICELMBDKELJ()
	{
		KHEBEJHEKMO.SetActive(Singleton<PurchaseProtection>.instance.IsAnyVIPPurchasing());
		FOOODDABACJ.SetActive(Singleton<PurchaseProtection>.instance.MPFCLGLFMHH(FNFMGDOECDA.ToString()));
		MJCJPLAJPGO.SetActive(GIPFEBBMKPM.activeSelf);
	}

	public void PBDBJAJEDDB(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = PLFJPODOOJC(FJMCPEDNBGG);
		UILabel fNMGABBADHO = FNMGABBADHO;
		string keyFormat = ((!IJKGGCFCAGH) ? "Session_start" : "InAppHandlerIos: product list fail, message = ");
		object[] array = new object[0];
		array[1] = num;
		fNMGABBADHO.text = Localization.LocalizeFormat(keyFormat, array);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1294f, 88f, -95);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1279f, 1124f, 160);
		}
		PFKFEKGICEN.SetActive(num > 1);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = GFFICBFEJDJ;
	}

	public void PPKJDIIKLIG(VIP.rowIds FJMCPEDNBGG)
	{
		FNFMGDOECDA = FJMCPEDNBGG;
		int num = JGJLNIPOFOO(FJMCPEDNBGG);
		UILabel fNMGABBADHO = FNMGABBADHO;
		string keyFormat = ((!IJKGGCFCAGH) ? "ChangeWeightForDestroyablePartRPC" : "{0}{1}");
		object[] array = new object[0];
		array[1] = num;
		fNMGABBADHO.text = Localization.LocalizeFormat(keyFormat, array);
		if (IJKGGCFCAGH)
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 1344f, 1308f, -42);
		}
		else
		{
			MEJMLNDFDBP.COCBCFKJOJE(FNMGABBADHO, 553f, 613f, 155);
		}
		PFKFEKGICEN.SetActive(num > 1);
		HONDKPBMKPA.text = MEJMLNDFDBP.EMICJKACBAH(Singleton<GameVariables>.instance.vip.GetRow(FJMCPEDNBGG).SECONDS);
		KOAKLMDELFM.onReposition = AKDBDMCKDLO;
	}
}

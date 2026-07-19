using UnityEngine;

public class GoldDailyButtonRecord : GoldButtonRecord
{
	[Header("Daily Gold Top")]
	public BoxCollider PMAOBDMEKFD;

	[Header("Daily Gold Top")]
	public GameObject NJFLBCDAIKA;

	[Header("Daily Gold Icons")]
	public GameObject JMNHHDNIFIG;

	public GameObject KFIPDBAJFLI;

	public GameObject KHKFJCHKIPF;

	[Header("Daily Gold Middle")]
	public UILabel JPCIACBHGHO;

	[Header("Daily Gold Middle")]
	public GameObject DMPBNBPBDFD;

	public GameObject PJMBJEKKAOE;

	public virtual void PNDFAOIDMHL(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 438f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -101);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 75);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= -10);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[7];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("-{0}", array);
		POEKALOOMLC();
	}

	public virtual void KJJGLHHHHNP(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public void JIHDNMBGPLP()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void FKBIBACPFJE(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 491f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < 15);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -108);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 109);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[5];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("menu-arena-ticket", array);
		PODGMFMEJFF();
	}

	public virtual void AEBEBCHFDBM(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public virtual void BANMDLOMBLF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public void AEFDCPHEJHM()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 1);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void EDONECAJGFF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public override void FANFNOPNGBL(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1408f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -78);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 116);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -46);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[4];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("On War arena endeeeed!!", array);
		OLBFNMHJHPE();
	}

	public virtual void CIPKPHAGJMP(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 655f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -87);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < -6);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 40);
		JPCIACBHGHO.text = Localization.LocalizeFormat("mUsedDogtagsLocaly", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), daysFromDailyGoldInApp, null, null, null, null, null);
		DPKOBPPBCIJ();
	}

	public override void OMGCKCFKDJM(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1907f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -58);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < 35);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -70);
		JPCIACBHGHO.text = Localization.LocalizeFormat("ID_REPORTUSER_ITEM0", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), daysFromDailyGoldInApp, null, null, null, null, null);
		PDIFAAFJIGG();
	}

	public virtual void LOAFJDDELCF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public void CEPAIIEKCGM()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 8);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void PCEHPPEGMLM(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CPNGNJBNHPN(LJKOPCPDPFL);
	}

	public void PDIFAAFJIGG()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(flag && flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void BBOOKFJDJAF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.KLMGKBDODBJ(LJKOPCPDPFL);
	}

	public override void GGAHNKIKJKD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1001f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < 77);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < 67);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 110);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("WarBucks", array);
		JEMHFDGJJFF();
	}

	public void CIAFOLMENGP()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 3);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void ActualizeState()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void FPNFHONFNOD(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public virtual void MHJMENDLEKH(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public void APGNFCGKKDN()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void IBDBNKHDFDP()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 4);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void LPAILPNHLOC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CPNGNJBNHPN(LJKOPCPDPFL);
	}

	public void JEMHFDGJJFF()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(flag && flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void ABCFKFOPPKC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.KLMGKBDODBJ(LJKOPCPDPFL);
	}

	public virtual void LBOOCPOADAA(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.EMCKDMFGEIB(LJKOPCPDPFL);
	}

	public virtual void LNELPMIPCFE(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public void NNDFLGHGDPB()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 5);
		}
		GIPFEBBMKPM.SetActive(flag && flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public override void KJKJHJOMNHL(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public virtual void GLEAHEKMJFE(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.EMCKDMFGEIB(LJKOPCPDPFL);
	}

	public virtual void OGIPEHAIFDA(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 197f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -37);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -71);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -46);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[3];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("DeliveryTime", array);
		IBDBNKHDFDP();
	}

	public virtual void DGGAKEPNMFP(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CPNGNJBNHPN(LJKOPCPDPFL);
	}

	public virtual void GPOHJMMINME(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.EMCKDMFGEIB(LJKOPCPDPFL);
	}

	public override void Initialize(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 14);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 21);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 30);
		JPCIACBHGHO.text = Localization.LocalizeFormat("ID_COLLECTGOLDEVERYDAYFORDAYS", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), daysFromDailyGoldInApp);
		ActualizeState();
	}

	public virtual void AJGPIOGPGMK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CPNGNJBNHPN(LJKOPCPDPFL);
	}

	public virtual void ECLNLCLPFCI(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.ShowDialog(LJKOPCPDPFL);
	}

	public void MIIAGLCKLDE()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void MMKEEBKDKLG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 362f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 5);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < 30);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 2);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[3];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_ARENARULES_SILVERWARCARDS", array);
		AAFAEJBFMLP();
	}

	public override void OMNEGAAKOCF(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1698f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -33);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -46);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -36);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("A", array);
		CIAFOLMENGP();
	}

	public void OLBFNMHJHPE()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void BCOFLPMCBFJ(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 648f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < 67);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 97);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 26);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[8];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("com/google/android/gms/common/ConnectionResult", array);
		KAOKHMAODIB();
	}

	public void NNPNNCFAMHH()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 3);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void KHKFGKPOCEB()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 6);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public override void MIJHEIKFAAK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.KLMGKBDODBJ(LJKOPCPDPFL);
	}

	public void KGEOHHHINNA()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 5);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void ACBHGJCMCPG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 375f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 10);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < -12);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 14);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[8];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ProductPrice", array);
		IBDBNKHDFDP();
	}

	public virtual void ECKILBEMHNG(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.ShowDialog(LJKOPCPDPFL);
	}

	public virtual void KOBJDHJPDGD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 144f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 15);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -76);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 53);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("UtcOffset", array);
		JEMHFDGJJFF();
	}

	public void PKBIDCDBANM()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 3);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void GOMJAFCDKDD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1829f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -21);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < -25);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= -37);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[7];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("PA: transactions count = ", array);
		MEIHILKGNJL();
	}

	public void NBABMLFCFEF()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void CCLAAFENCOE(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CPNGNJBNHPN(LJKOPCPDPFL);
	}

	public virtual void LIMIFKFNNLA(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1727f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -10);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < -18);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -18);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[7];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_STAT_WINLOSSRATIO", array);
		KAOKHMAODIB();
	}

	public override void ButtonClicked(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.ShowDialog(LJKOPCPDPFL);
	}

	public virtual void CICHBMJECOM(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.ShowDialog(LJKOPCPDPFL);
	}

	public virtual void LCIPAMOFOPB(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.EMCKDMFGEIB(LJKOPCPDPFL);
	}

	public virtual void EGJEKJGAMOO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 718f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < 30);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 93);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -126);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_YOURDOGTAGSAREFULLNOTVIP", array);
		JIHDNMBGPLP();
	}

	public virtual void AIGECFENFFC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.KLMGKBDODBJ(LJKOPCPDPFL);
	}

	public void ILEJDAPFPCM()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public override void MPFPHNBAIKD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 743f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -51);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 35);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 94);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[5];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", array);
		MIIAGLCKLDE();
	}

	public virtual void GEGBFJHAPOE(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1451f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -46);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 94);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 16);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[5];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("()Lcom/google/android/gms/common/api/Result;", array);
		ILEJDAPFPCM();
	}

	public virtual void GJOIGNMPBCH(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1527f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -54);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 57);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -59);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[7];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("GameLoginManager: Facebook Logged", array);
		CNEGALLEOLF();
	}

	public virtual void CFIAHPMMJOE(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1844f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -75);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -59);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 6);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[2];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat(" ", array);
		PDIFAAFJIGG();
	}

	public virtual void GECGGJMDPIK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CPNGNJBNHPN(LJKOPCPDPFL);
	}

	public virtual void NPIFOBHFFMN(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public virtual void CAOCNECHOHF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public override void GJOHPCMGEOG(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.EMCKDMFGEIB(LJKOPCPDPFL);
	}

	public override void BMNHEMLGGMO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1603f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 94);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < 17);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -22);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[7];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("maxMapId", array);
		CNEGALLEOLF();
	}

	public virtual void KBKBFNJEBJK(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1170f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 101);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < -108);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 122);
		JPCIACBHGHO.text = Localization.LocalizeFormat("Items", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), daysFromDailyGoldInApp, null, null, null);
		PODGMFMEJFF();
	}

	public virtual void HIHAFDPJPKC(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1055f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -80);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 20);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= -55);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("menu-arena-ticket", array);
		CEPAIIEKCGM();
	}

	public virtual void HBDEPMJNLEK(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1463f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -70);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -102);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 82);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[7];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("resizing texture ", array);
		CNEGALLEOLF();
	}

	public void OECKAMIPOHH()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 2);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void CNEGALLEOLF()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(flag && flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void EMPIGGNJGDA()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 8);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void OGENLPKCFLO()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 6);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void OJJHCFFEFGI(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 30f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 28);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 86);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < 68);
		JPCIACBHGHO.text = Localization.LocalizeFormat("NOT ENOUGH GOLD FOR ARENA", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), daysFromDailyGoldInApp, null, null, null, null);
		EMPIGGNJGDA();
	}

	public virtual void BGCHDAGHAEH(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.KLMGKBDODBJ(LJKOPCPDPFL);
	}

	public override void NOONOBOELCG(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.CJNMLPANNPD(LJKOPCPDPFL);
	}

	public void KHAEAJNGOIM()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void POEKALOOMLC()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 5);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void PODGMFMEJFF()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 3);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void OGPMOIEBJCN()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp != null && dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 3);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void KAOKHMAODIB()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 2);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void AAFAEJBFMLP()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 1);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void LDEFAJEAKLK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public void KNCKMHJMJFI()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 4);
		}
		GIPFEBBMKPM.SetActive(flag && flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void JHFKJHKCMBP()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 6);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public void MEIHILKGNJL()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(true);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(!flag || flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void OBLJPCHJBGK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.ShowDialog(LJKOPCPDPFL);
	}

	public void DPKOBPPBCIJ()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 1;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 7);
		}
		GIPFEBBMKPM.SetActive(flag && flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void JAGCJCNPCKH(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 585f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -71);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= 55);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -42);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[5];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("LootBoxRotation", array);
		JHFKJHKCMBP();
	}

	public virtual void IPAMNPLMPOE(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<DailyGoldBoosterDialog>.instance.GGDDMHEOENG(LJKOPCPDPFL);
	}

	public void EJLCBFADKGN()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(!flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = !flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(PlayerAnalytics.instance.data.showDailyOneTimeOffer && daysFromDailyGoldInApp == 0);
		}
		GIPFEBBMKPM.SetActive(flag && !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}

	public virtual void PPLIBOAJOCA(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 260f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= 120);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < 8);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 121);
		JPCIACBHGHO.text = Localization.LocalizeFormat("BoughtIndex", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), daysFromDailyGoldInApp, null);
		IBDBNKHDFDP();
	}

	public virtual void PPKOJCFEPCB(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1386f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -89);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -100);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 10);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[4];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_MONEYPACKINFORMATIONS", array);
		NNPNNCFAMHH();
	}

	public virtual void AFHMOPJGNBM(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1376f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp < -79);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp < -57);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp < -15);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[6];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("Take player life!", array);
		JHFKJHKCMBP();
	}

	public override void KCJFKOKGAMO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(COCLIJKECEK.id);
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)amount / ((float)daysFromDailyGoldInApp + 1482f));
		JMNHHDNIFIG.SetActive(daysFromDailyGoldInApp >= -10);
		KFIPDBAJFLI.SetActive(daysFromDailyGoldInApp >= -36);
		KHKFJCHKIPF.SetActive(daysFromDailyGoldInApp >= 123);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = daysFromDailyGoldInApp;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_TOBENUMBERONE1", array);
		KHAEAJNGOIM();
	}

	public void FKBPLIPCPDN()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyInApp(LJKOPCPDPFL.id);
		int sale = LJKOPCPDPFL.sale;
		bool flag = sale > 0;
		bool flag2 = dailyInApp == null || dailyInApp.isActive;
		DMPBNBPBDFD.SetActive(flag2);
		PJMBJEKKAOE.SetActive(flag2);
		PMAOBDMEKFD.enabled = flag2;
		if (flag2)
		{
			NJFLBCDAIKA.SetActive(false);
		}
		else
		{
			int daysFromDailyGoldInApp = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDaysFromDailyGoldInApp(LJKOPCPDPFL.id);
			NJFLBCDAIKA.SetActive(!PlayerAnalytics.instance.data.showDailyOneTimeOffer || daysFromDailyGoldInApp == 2);
		}
		GIPFEBBMKPM.SetActive(!flag || !flag2);
		if (flag)
		{
			HIDNIJJEBFJ.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		}
	}
}

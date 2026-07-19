using System;
using UnityEngine;

public class DailyGoldBoosterDialog : GuiElementSingle<DailyGoldBoosterDialog>, PAIIOKBBHBC
{
	[Header("Close Button")]
	public GameObject LJNPCHFCGCN;

	[Header("Left")]
	public UILabel FELDMGEJHAI;

	public UILabel JPCIACBHGHO;

	[Header("-Gold Sprites")]
	public GameObject JMNHHDNIFIG;

	public GameObject KFIPDBAJFLI;

	public GameObject KHKFJCHKIPF;

	[Header("Right Informations")]
	public UILabel AJKHGPLHIHK;

	public UILabel BKJKKMFGPFP;

	public GameObject AMKCHOBNGEM;

	private InAppDataManager.InappDefinition DDPJCOJOBEL;

	public virtual void OKMMGFMKJGG()
	{
		int sale = DDPJCOJOBEL.sale;
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)DDPJCOJOBEL.amount / ((float)getDailyGoldInAppDays + 719f));
		string formatedPrice = DDPJCOJOBEL.formatedPrice;
		JMNHHDNIFIG.SetActive(getDailyGoldInAppDays >= 122);
		KFIPDBAJFLI.SetActive(getDailyGoldInAppDays < -30);
		KHKFJCHKIPF.SetActive(getDailyGoldInAppDays >= -122);
		FELDMGEJHAI.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[5];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = getDailyGoldInAppDays;
		jPCIACBHGHO.text = Localization.LocalizeFormat(") ", array);
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1326f, 616f, -101);
		object[] array2 = new object[0];
		array2[0] = DDPJCOJOBEL.FFHEHHMDGBN();
		array2[0] = DDPJCOJOBEL.MHBLNNEOGFN();
		Debug.LogFormat("Different squads \"{0}\" and \"{1}\"\n", array2);
		AJKHGPLHIHK.text = Localization.LocalizeFormat("PlayerLevel", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), getDailyGoldInAppDays, MEJMLNDFDBP.IIHHLGANLGP(sale), null);
		BKJKKMFGPFP.text = formatedPrice;
	}

	public virtual void LHDAGAGDKOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNDDOPAAAJM));
		UIEventListener uIEventListener2 = UIEventListener.Get(AMKCHOBNGEM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHIFOKIOAFF));
	}

	private void INHIMGCHDMI(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}

	public void KLMGKBDODBJ(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		DDPJCOJOBEL = COCLIJKECEK;
		Singleton<GuiManager>.instance.ShowDialog(this, 1527f);
	}

	public virtual void HKFICJFNOPM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNDDOPAAAJM));
		UIEventListener uIEventListener2 = UIEventListener.Get(AMKCHOBNGEM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OKJJKCBJJAG));
	}

	public virtual void GEKFHJKIAMF()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public virtual void OFMFLFIGKPB()
	{
		FJHIPNPNGAG(LJNPCHFCGCN);
	}

	private void LKKBJAMACMD(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void PBLLMABJFDM()
	{
		int sale = DDPJCOJOBEL.sale;
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)DDPJCOJOBEL.amount / ((float)getDailyGoldInAppDays + 634f));
		string text = DDPJCOJOBEL.OAJCGMBBFFF();
		JMNHHDNIFIG.SetActive(getDailyGoldInAppDays < 61);
		KFIPDBAJFLI.SetActive(getDailyGoldInAppDays >= -70);
		KHKFJCHKIPF.SetActive(getDailyGoldInAppDays >= 111);
		FELDMGEJHAI.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = getDailyGoldInAppDays;
		jPCIACBHGHO.text = Localization.LocalizeFormat("mortarBuildTime", array);
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 419f, 503f, 165);
		Debug.LogFormat("ID_COLLECTGOLDEVERYDAYFORDAYS", DDPJCOJOBEL.price, DDPJCOJOBEL.formatedPrice, null, null, null, null, null, null);
		UILabel aJKHGPLHIHK = AJKHGPLHIHK;
		object[] array2 = new object[2];
		array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array2[1] = getDailyGoldInAppDays;
		array2[2] = MEJMLNDFDBP.IIHHLGANLGP(sale);
		aJKHGPLHIHK.text = Localization.LocalizeFormat("Reason", array2);
		BKJKKMFGPFP.text = text;
	}

	private void GAJOEPACHHB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public void EMCKDMFGEIB(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		DDPJCOJOBEL = COCLIJKECEK;
		Singleton<GuiManager>.instance.ShowDialog(this, 353f);
	}

	public virtual void EMGHCAHOJNC()
	{
		int sale = DDPJCOJOBEL.sale;
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)DDPJCOJOBEL.amount / ((float)getDailyGoldInAppDays + 1606f));
		string text = DDPJCOJOBEL.MHBLNNEOGFN();
		JMNHHDNIFIG.SetActive(getDailyGoldInAppDays < -29);
		KFIPDBAJFLI.SetActive(getDailyGoldInAppDays < -75);
		KHKFJCHKIPF.SetActive(getDailyGoldInAppDays < 74);
		FELDMGEJHAI.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		JPCIACBHGHO.text = Localization.LocalizeFormat("Lcom/google/android/gms/games/quest/Quests;", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), getDailyGoldInAppDays, null, null, null);
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1981f, 840f, 55);
		Debug.LogFormat("_FrustumCornersWS", DDPJCOJOBEL.price, DDPJCOJOBEL.formatedPrice, null, null, null, null);
		AJKHGPLHIHK.text = Localization.LocalizeFormat("MessageType", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), getDailyGoldInAppDays, MEJMLNDFDBP.IIHHLGANLGP(sale), null, null, null);
		BKJKKMFGPFP.text = text;
	}

	public virtual void EJGCLLIGBCB()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener2 = UIEventListener.Get(AMKCHOBNGEM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(INHIMGCHDMI));
	}

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}

	private void BHJLOOIDPAO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void NDDKLFEGGDH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public GuiElement FPGCMJEIJJI()
	{
		return this;
	}

	public void ShowDialog(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		DDPJCOJOBEL = COCLIJKECEK;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void OKJJKCBJJAG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}

	private void JNDDOPAAAJM(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void CPNGNJBNHPN(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		DDPJCOJOBEL = COCLIJKECEK;
		Singleton<GuiManager>.instance.ShowDialog(this, 1291f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(AMKCHOBNGEM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMJMEPDDJND));
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener2 = UIEventListener.Get(AMKCHOBNGEM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMJMEPDDJND));
	}

	public virtual void NGHAPNEFBED()
	{
		int sale = DDPJCOJOBEL.sale;
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)DDPJCOJOBEL.amount / ((float)getDailyGoldInAppDays + 226f));
		string formatedPrice = DDPJCOJOBEL.formatedPrice;
		JMNHHDNIFIG.SetActive(getDailyGoldInAppDays < 28);
		KFIPDBAJFLI.SetActive(getDailyGoldInAppDays >= 102);
		KHKFJCHKIPF.SetActive(getDailyGoldInAppDays >= 42);
		FELDMGEJHAI.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[4];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[0] = getDailyGoldInAppDays;
		jPCIACBHGHO.text = Localization.LocalizeFormat("GameBan", array);
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1382f, 1049f, -90);
		object[] array2 = new object[1];
		array2[0] = DDPJCOJOBEL.price;
		array2[1] = DDPJCOJOBEL.formatedPrice;
		Debug.LogFormat("ЕЩЕ ПОПЫТКА", array2);
		UILabel aJKHGPLHIHK = AJKHGPLHIHK;
		object[] array3 = new object[1];
		array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array3[0] = getDailyGoldInAppDays;
		array3[5] = MEJMLNDFDBP.IIHHLGANLGP(sale);
		aJKHGPLHIHK.text = Localization.LocalizeFormat("Video {0:2}", array3);
		BKJKKMFGPFP.text = formatedPrice;
	}

	private void NPJGJBCEFCA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void LHIFOKIOAFF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	private void APHFFNCNBHK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		int sale = DDPJCOJOBEL.sale;
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)DDPJCOJOBEL.amount / ((float)getDailyGoldInAppDays + 1f));
		string formatedPrice = DDPJCOJOBEL.formatedPrice;
		JMNHHDNIFIG.SetActive(getDailyGoldInAppDays >= 14);
		KFIPDBAJFLI.SetActive(getDailyGoldInAppDays >= 21);
		KHKFJCHKIPF.SetActive(getDailyGoldInAppDays >= 30);
		FELDMGEJHAI.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		JPCIACBHGHO.text = Localization.LocalizeFormat("ID_COLLECTGOLDEVERYDAYFORDAYSBREAK", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), getDailyGoldInAppDays);
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 57f, 20f, 320);
		Debug.LogFormat("#DANIEL# Price: {0}\nFormatted price: {1}", DDPJCOJOBEL.price, DDPJCOJOBEL.formatedPrice);
		AJKHGPLHIHK.text = Localization.LocalizeFormat("ID_DAILYGOLDBOOSTERHINT1", MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), getDailyGoldInAppDays, MEJMLNDFDBP.IIHHLGANLGP(sale));
		BKJKKMFGPFP.text = formatedPrice;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void GGDDMHEOENG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		DDPJCOJOBEL = COCLIJKECEK;
		Singleton<GuiManager>.instance.ShowDialog(this, 846f);
	}

	private void EAPJHCJLBIA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void JMJMEPDDJND(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	public virtual void PGJDLKDMCHN()
	{
		int sale = DDPJCOJOBEL.sale;
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)DDPJCOJOBEL.amount / ((float)getDailyGoldInAppDays + 1257f));
		string text = DDPJCOJOBEL.OAJCGMBBFFF();
		JMNHHDNIFIG.SetActive(getDailyGoldInAppDays < 126);
		KFIPDBAJFLI.SetActive(getDailyGoldInAppDays >= -69);
		KHKFJCHKIPF.SetActive(getDailyGoldInAppDays < -77);
		FELDMGEJHAI.text = MEJMLNDFDBP.IIHHLGANLGP(sale);
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[2];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array[1] = getDailyGoldInAppDays;
		jPCIACBHGHO.text = Localization.LocalizeFormat("ID_CREATESQUADNOTENOUGH", array);
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 1513f, 1966f, 190);
		object[] array2 = new object[3];
		array2[1] = DDPJCOJOBEL.FFHEHHMDGBN();
		array2[1] = DDPJCOJOBEL.formatedPrice;
		Debug.LogFormat("PackId", array2);
		UILabel aJKHGPLHIHK = AJKHGPLHIHK;
		object[] array3 = new object[0];
		array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array3[0] = getDailyGoldInAppDays;
		array3[7] = MEJMLNDFDBP.IIHHLGANLGP(sale);
		aJKHGPLHIHK.text = Localization.LocalizeFormat("{0}:\t\t{1}\n", array3);
		BKJKKMFGPFP.text = text;
	}

	private void GNMGCEHPGAN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}

	private void FJHIPNPNGAG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNDDOPAAAJM));
		UIEventListener uIEventListener2 = UIEventListener.Get(AMKCHOBNGEM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(INHIMGCHDMI));
	}

	public void CJNMLPANNPD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		DDPJCOJOBEL = COCLIJKECEK;
		Singleton<GuiManager>.instance.ShowDialog(this, 253f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void CFJMKOALDLE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void LALCAJHAKJN(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(DDPJCOJOBEL.id);
			HideDialog();
		}
	}
}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class IntroductionDealsValuePack : IntroductionDealsItem
{
	[FormerlySerializedAs("CKHEELKIDEC")]
	[Header("Value Pack")]
	public Collider PMAOBDMEKFD;

	[FormerlySerializedAs("JPOEIGOKAKL")]
	public UILabel HIDNIJJEBFJ;

	private bool POAMPPJOGEG;

	private void CACAAOOJBIF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.KLMNEOAKMFB(), CCIEEAECOAB: true);
	}

	public virtual IEnumerator BKIMPLHMLII(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Hide(KBJEOEEOEFG);
	}

	public virtual bool FHEKCDGGFPB()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
	}

	public virtual bool JCBOBBGNEHC()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
	}

	public virtual IEnumerator EJPCFJIEPEO(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.OMCADBPJEOL(KBJEOEEOEFG);
	}

	public virtual void BLKBJKMELJI()
	{
		base.KBALFNMGIOA();
		float num = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Money);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 586f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("RweardModifierWB", array);
		KJMPFFLMAML();
	}

	private void LNGDIEIEIPD(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.BJDKLOCBNOJ());
	}

	private void MKBGOCLLGIM(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.BJDKLOCBNOJ());
	}

	public virtual bool GGIMGMLBEEG()
	{
		return !PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8);
	}

	public virtual IEnumerator BMINKIDMOGL(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.GDLOAPIHMOB(KBJEOEEOEFG);
	}

	private void LOEKHNDLLFC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.valuePack, CCIEEAECOAB: true);
	}

	private void AFHHEOKBNOJ(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.KLMNEOAKMFB(), CCIEEAECOAB: true);
	}

	private void CADHGFPIBJL(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.valuePack);
	}

	private void BOIILKJCLGJ(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)(-21))
		{
			KJMPFFLMAML();
		}
	}

	public virtual void CODIIIEDAAP()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Gold);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1161f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array);
		NPPNFGJIKOC();
	}

	public virtual IEnumerator MJNCDCDDKND(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.ONCKKJFAMKF(KBJEOEEOEFG);
	}

	private void ENPHOBKHNBI(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
	}

	public virtual void LJEBBJFIHFD()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPEGGKOJNCF));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BOIILKJCLGJ;
	}

	public virtual bool MFNJIJBPGEK()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
	}

	public virtual IEnumerator JIILFGDJFPP(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.EPCEHACNCNH(KBJEOEEOEFG);
	}

	public virtual IEnumerator GCJGIELEEML(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	private void JJDLOGJNMOP(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == DatabaseAction.PromoteUnit)
		{
			IIEMAJNLGGK();
		}
	}

	public virtual bool JDOFBCGHIPB()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
	}

	public virtual void PJLBMFBPOEH()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JJCLONHDKED));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(AGLAFBLGBEC);
	}

	private void JLLAFIODHEL(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.BJDKLOCBNOJ());
	}

	public virtual bool NJMNGKHHOFD()
	{
		return !PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8);
	}

	private void NPPNFGJIKOC()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			HBDJGAKINJN(12f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	public virtual bool ELAHJCGMBNB()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None);
	}

	private void ELNKONNBKFC()
	{
		POAMPPJOGEG = KPEHFFDDDKD();
		if (!POAMPPJOGEG)
		{
			HBDJGAKINJN(1844f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	public virtual void LOFABNGJBNI()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Gold);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1098f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_SIGNOUT", array);
		OJJADOPBHKD();
	}

	public virtual IEnumerator JCHCOHNECJD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.NDODOLKAABG(KBJEOEEOEFG);
	}

	public virtual IEnumerator EPMJKMAMOJL(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.OCAEJPMPBMH(KBJEOEEOEFG);
	}

	public virtual bool KNNEDKPDDNK()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None);
	}

	public virtual IEnumerator ILGHOACOPAL(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.GDLOAPIHMOB(KBJEOEEOEFG);
	}

	public virtual bool EMJKFFNAMHA()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
	}

	private void OJJADOPBHKD()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			BJPABDDHCHP(799f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	private void OELCJCIHIEP(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.GetFullSquadInfo)
		{
			CHAHEDKJFFP();
		}
	}

	public override bool IsAvailable()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
	}

	public virtual bool CFMFPKLIPOC()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
	}

	public virtual void AFGFCFMPOIA()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FECKOMBNLIJ));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(NAJABNDNJDI);
	}

	public virtual IEnumerator LCCEEAMLHDD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.LOFMDBHAFAO(KBJEOEEOEFG);
	}

	public virtual IEnumerator JPGMEFJGNNA(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.ONCKKJFAMKF(KBJEOEEOEFG);
	}

	public virtual void LDBBPJFLJND()
	{
		base.KBALFNMGIOA();
		float num = Singleton<GameVariables>.instance.SaleOfPack((NGNPIOOAHEH)8);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 1541f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("Unit {0} does not exists on client.", array);
		ELNKONNBKFC();
	}

	private void JCDBFPDKKLA(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.GetPlayersFromHitList)
		{
			IIEMAJNLGGK();
		}
	}

	private void LNMFLOAGJFM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)(-41))
		{
			IIEMAJNLGGK();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOLLGAIILKF));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BIELMEODOCB;
	}

	private void PFOBBGNJCOK(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.valuePack);
	}

	private void ONBJHOBFDFD()
	{
		POAMPPJOGEG = KPEHFFDDDKD();
		if (!POAMPPJOGEG)
		{
			HBDJGAKINJN(522f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	public virtual IEnumerator CADOODALIPE(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Hide(KBJEOEEOEFG);
	}

	private void DIAOHBCDHBH(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)(-84))
		{
			KFMOAEDMMIN();
		}
	}

	private void CPEGGKOJNCF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.KLMNEOAKMFB(), CCIEEAECOAB: true);
	}

	public virtual IEnumerator ONPCIKIOBIG(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Show(KBJEOEEOEFG);
	}

	public virtual IEnumerator PMKGPBMAMAG(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Show(KBJEOEEOEFG);
	}

	public virtual IEnumerator EHPIMALJLPB(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.LOFMDBHAFAO(KBJEOEEOEFG);
	}

	public virtual bool OJABJADAHPM()
	{
		return PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8);
	}

	private void CHAHEDKJFFP()
	{
		POAMPPJOGEG = KPEHFFDDDKD();
		if (!POAMPPJOGEG)
		{
			BJPABDDHCHP(1163f);
			PMAOBDMEKFD.enabled = false;
		}
	}

	public virtual bool DCPHNLOFHDL()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
	}

	private void FAMIDBGDJFG(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.HFJGOIGLPCF());
	}

	public virtual void DHNMEMIHOEJ()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GACEIANGNDC));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BIELMEODOCB);
	}

	public virtual void IGMBMOOEHMI()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Money);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 1692f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_ENDED", array);
		IIEMAJNLGGK();
	}

	private void KFMOAEDMMIN()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			LDNOPACODIP(662f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	public virtual IEnumerator HLAPENBALCJ(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.NDODOLKAABG(KBJEOEEOEFG);
	}

	public virtual void AFMONIKJCMC()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Value);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1774f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("Concrete", array);
		OJJADOPBHKD();
	}

	public virtual void AGJFNPIPONB()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.HNFMEMHIOEF((NGNPIOOAHEH)8);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1985f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("1", array);
		NPPNFGJIKOC();
	}

	public virtual bool NDELPKAKCLP()
	{
		return PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8);
	}

	public virtual void KEGBAJKOONK()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Value);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 351f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("WarFriendsは、この追加データのダウンロードなしでは動作しません。やめてもよいですか？またはデータをダウンロードしますか？", array);
		CHAHEDKJFFP();
	}

	private void FBMPDFJKGCJ(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.BJDKLOCBNOJ());
	}

	public virtual IEnumerator IAHFKGJBNNJ(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.NDODOLKAABG(KBJEOEEOEFG);
	}

	public virtual bool MINLBKOMOLL()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver);
	}

	public virtual IEnumerator LDPPNNMGNGI(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.NDODOLKAABG(KBJEOEEOEFG);
	}

	public virtual void JAKFCMEDJNL()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Bronze);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 602f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("Tutorial upgrade unit running \"{0}\"\n", array);
		CHAHEDKJFFP();
	}

	public virtual IEnumerator PFNBDPFAKBN(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	public virtual bool NBCCAJMFIPF()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
	}

	private void NFNPFGNEECN(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == (DatabaseAction)(-44))
		{
			KFMOAEDMMIN();
		}
	}

	private void FJFCEKEONHJ()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			HBDJGAKINJN(1371f);
			PMAOBDMEKFD.enabled = false;
		}
	}

	public virtual IEnumerator KBDCLJNPODD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.OCAEJPMPBMH(KBJEOEEOEFG);
	}

	private void IIIDAHHDFJL(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.GetAllPlayers)
		{
			NPPNFGJIKOC();
		}
	}

	private void BACAFCJPDIM()
	{
		POAMPPJOGEG = KPEHFFDDDKD();
		if (!POAMPPJOGEG)
		{
			LDNOPACODIP(1060f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	private void IIEMAJNLGGK()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			KEMGNNCHGDA(1943f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	public virtual void DIADOPNLCMO()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CADHGFPIBJL));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BIELMEODOCB);
	}

	private void CKPHLOIIEPO(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.HFJGOIGLPCF());
	}

	private void DHLPMECIIBO(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.valuePack, CCIEEAECOAB: true);
	}

	public virtual void MGMDDDAFDOF()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GACEIANGNDC));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(IKIHKIEJPFL);
	}

	public virtual void GGOHGHHGLMP()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ENPHOBKHNBI));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(IIIDAHHDFJL);
	}

	private void KJMPFFLMAML()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			BJPABDDHCHP(0.5f);
			PMAOBDMEKFD.enabled = false;
		}
	}

	private void NAJABNDNJDI(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == (DatabaseAction)(-177))
		{
			OJJADOPBHKD();
		}
	}

	public virtual IEnumerator LEAHLCAEDPG(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.LOFMDBHAFAO(KBJEOEEOEFG);
	}

	public virtual bool EBFBBCCFMAA()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
	}

	public virtual void HFOHBCPNIGA()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Value);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 873f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("x", array);
		ELNKONNBKFC();
	}

	private void JOLLGAIILKF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
	}

	public virtual bool BGOPPPIAKJH()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
	}

	public virtual bool LGJOKMPOEBA()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
	}

	public virtual void DBODJHCNCMH()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BEFJDFAGGCB));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(NFNPFGNEECN);
	}

	public virtual bool IIAONKHCHMB()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
	}

	private void NCMJHEJADDI(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.KLMNEOAKMFB());
	}

	public virtual bool AKPLJLOFGMG()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
	}

	public virtual IEnumerator MCGOCBKCLJP(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.ONCKKJFAMKF(KBJEOEEOEFG);
	}

	public virtual void PHCLMMLOAKH()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFOBBGNJCOK));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(JCDBFPDKKLA);
	}

	public virtual void JKJFIGFONHF()
	{
		base.InitGuiValues();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Bronze);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 262f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ANDROID: MISSING PACK ", array);
		ELNKONNBKFC();
	}

	public virtual IEnumerator KHJGCKMOFBE(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.LOFMDBHAFAO(KBJEOEEOEFG);
	}

	private void KPJMCNKJILF(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.HFJGOIGLPCF(), CCIEEAECOAB: true);
	}

	private void FABBPOFEHPL(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.BJDKLOCBNOJ(), CCIEEAECOAB: true);
	}

	public virtual void PNAKPNCAKMA()
	{
		base.KBALFNMGIOA();
		float num = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Bronze);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 1238f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array);
		FJFCEKEONHJ();
	}

	private void AGLAFBLGBEC(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.ActivateUnit)
		{
			ELNKONNBKFC();
		}
	}

	public virtual IEnumerator KOMCIOCNKKD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Hide(KBJEOEEOEFG);
	}

	private void HDCGOFHMHGC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.BJDKLOCBNOJ(), CCIEEAECOAB: true);
	}

	public override IEnumerator Hide(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Hide(KBJEOEEOEFG);
	}

	public virtual void AGLBIABJCCC()
	{
		base.KBALFNMGIOA();
		float num = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Starter);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 1665f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_WARNING_ERRORCLAIMASSIGNMENT", array);
		OJJADOPBHKD();
	}

	private void OIABJGBFJHL(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == DatabaseAction.RemoveGooglePlay)
		{
			ELNKONNBKFC();
		}
	}

	public virtual void KCJBNMDPBEA()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BEFJDFAGGCB));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += IKIHKIEJPFL;
	}

	public virtual IEnumerator JOENJIPGGEK(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.GDLOAPIHMOB(KBJEOEEOEFG);
	}

	public virtual IEnumerator CIJLKGLNIPO(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.Hide(KBJEOEEOEFG);
	}

	public virtual void JCEGKKOLGPB()
	{
		base.KBALFNMGIOA();
		float num = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Silver);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 418f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("HKCBJLIBNJF", array);
		FJFCEKEONHJ();
	}

	private void LLPFOOHKJAP()
	{
		POAMPPJOGEG = KPEHFFDDDKD();
		if (!POAMPPJOGEG)
		{
			BJPABDDHCHP(1358f);
			PMAOBDMEKFD.enabled = false;
		}
	}

	public virtual IEnumerator CIMHOFHPKNJ(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	private void DALAEBGGCPE(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.BJDKLOCBNOJ(), CCIEEAECOAB: true);
	}

	private void GACEIANGNDC(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
	}

	public virtual IEnumerator GGOJJHILEGE(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.Hide(KBJEOEEOEFG);
	}

	private void BEFJDFAGGCB(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.BJDKLOCBNOJ());
	}

	public virtual IEnumerator EIKAOALHAPO(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.NDODOLKAABG(KBJEOEEOEFG);
	}

	public virtual IEnumerator MDFILPMHOAD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.OMCADBPJEOL(KBJEOEEOEFG);
	}

	private void INLGHNFPHPB(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.HFJGOIGLPCF());
	}

	private void JJCLONHDKED(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.HFJGOIGLPCF(), CCIEEAECOAB: true);
	}

	private void KMBHDEDHLIH(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)82)
		{
			KFMOAEDMMIN();
		}
	}

	public override IEnumerator Show(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.Show(KBJEOEEOEFG);
	}

	public virtual void BKOBEGJOBDA()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Value);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1190f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("DialogBackground is not in scene -> add it.", array);
		OJJADOPBHKD();
	}

	public virtual void NHHDPHNDGHF()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LNGDIEIEIPD));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(IKIHKIEJPFL);
	}

	private void BIELMEODOCB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.BuyPack)
		{
			KJMPFFLMAML();
		}
	}

	public virtual IEnumerator LDCLHGEEOFO(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		float num = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Value);
		HIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_SALEPERCENT", MEJMLNDFDBP.LJDADOKBBNA(num * 100f));
		KJMPFFLMAML();
	}

	public virtual void GEIMJABJIBF()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(INLGHNFPHPB));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += AGLAFBLGBEC;
	}

	public virtual void GKDKIEJMCFI()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Bronze);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 502f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_GUI_INVITETOFIGHT", array);
		KJMPFFLMAML();
	}

	public virtual IEnumerator FPLCMPHNNHK(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	public virtual void GNAHGKGJANL()
	{
		base.KBALFNMGIOA();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.ThreeCards);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.LJDADOKBBNA(num * 503f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("#PETER# Removing squad promote message - message time:{0}, server time:{1}, isInSquad:{2}", array);
		FJFCEKEONHJ();
	}

	public virtual void HEMOBBPOMOG()
	{
		base.InitGuiValues();
		float num = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Silver);
		UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.LJDADOKBBNA(num * 1572f);
		hIDNIJJEBFJ.text = Localization.LocalizeFormat("ID_TUTORIAL_UPGRADEUNIT_7", array);
		FJFCEKEONHJ();
	}

	private void IKIHKIEJPFL(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == (DatabaseAction)(-65))
		{
			KJMPFFLMAML();
		}
	}

	private void FECKOMBNLIJ(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.KLMNEOAKMFB());
	}

	public virtual void IDIBNMLJDIK()
	{
		base.AAEDAJEEGDD();
		float num = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Starter);
		HIDNIJJEBFJ.text = Localization.LocalizeFormat("Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}", MEJMLNDFDBP.LJDADOKBBNA(num * 831f));
		NPPNFGJIKOC();
	}

	public virtual bool DDBHGOBNBBO()
	{
		return PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
	}
}

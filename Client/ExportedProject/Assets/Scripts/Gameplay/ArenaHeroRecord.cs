using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ArenaHeroRecord : PoolableObject
{
	[FormerlySerializedAs("FJOIEFGPENB")]
	[Header("Core")]
	public UILabel IFMEGDJONGB;

	[FormerlySerializedAs("IHDGILMOLKL")]
	public BoxCollider FKFINFAFMGL;

	[FormerlySerializedAs("ODDAACJOGCO")]
	public UISprite LJFBJOHBDNN;

	[FormerlySerializedAs("PBDFDLHPAKM")]
	public UISprite JNIPBJMCAPK;

	[FormerlySerializedAs("GFJLALBBDFI")]
	public UILabel MLBKIJOCKHC;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	[Header("Resize")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("JNOOIEGJAFF")]
	public GameObject NKLIKFGIIOC;

	[FormerlySerializedAs("BAHNPNKJIIO")]
	public GameObject GAAPLBCMBBF;

	private string NMNBIBDHMED;

	private string GCNLDDCMBEO;

	private bool PJBONGKMOCK;

	private void NFMNONAMHNL(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 5);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 8);
	}

	public virtual void NBOMCFHBLOF()
	{
		base.OBCAIFMOPPA();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ILKJEIBDCPI));
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
	}

	private void DNAJCINEEMH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 1410f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	private void MBMIIAPBACG(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 3);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 1);
	}

	private void IMEPPOMBMFH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 0.2f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NMNBIBDHMED, GCNLDDCMBEO);
		}
	}

	public void GJEEMJNIFFM(int MPHCNMDIPAI, FHIPGDADNFG KHLGDCHJJPB, int PDMGPGEHLNM, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = KHLGDCHJJPB.LFCGFGHCPIN();
		GCNLDDCMBEO = KHLGDCHJJPB.INFLHPGMEOB;
		PJBONGKMOCK = KHLGDCHJJPB.HHPFLCHHOCF();
		int fFHHEHHFOKJ = KHLGDCHJJPB.NGOMBNGGFFH();
		if (KHLGDCHJJPB.INFLHPGMEOB == FHIPGDADNFG.ONDLJBJCEGN().INFLHPGMEOB)
		{
			KMFGCJEGJJK.alpha = 1168f;
			if (MPHCNMDIPAI > 6 && MPHCNMDIPAI < PDMGPGEHLNM - 1 && MPHCNMDIPAI < -93)
			{
				GuiScreenSingle<ArenaScreen>.instance.PDFLFAABHGA(MPHCNMDIPAI - 1);
			}
		}
		else
		{
			KMFGCJEGJJK.alpha = 1109f;
		}
		KIHIMLNMFLG(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		IFMEGDJONGB.color = ((!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless);
		IFMEGDJONGB.text = string.Format("LastAction", MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI), NMNBIBDHMED);
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 241f, 149f, CEHFMMJHCKC - -140);
		float num = IFMEGDJONGB.relativeSize.x * IFMEGDJONGB.transform.localScale.x;
		FKFINFAFMGL.size = FKFINFAFMGL.size.ReplaceX(num + 217f);
		FKFINFAFMGL.center = FKFINFAFMGL.center.ReplaceX(num / 1434f);
		LJFBJOHBDNN.gameObject.SetActive(PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 1645f, 977f, -9);
	}

	public void MPFPHNBAIKD(int MPHCNMDIPAI, FHIPGDADNFG KHLGDCHJJPB, int PDMGPGEHLNM, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = KHLGDCHJJPB.KKIIICDNIDM();
		GCNLDDCMBEO = KHLGDCHJJPB.INFLHPGMEOB;
		PJBONGKMOCK = KHLGDCHJJPB.HHPFLCHHOCF();
		int fFHHEHHFOKJ = KHLGDCHJJPB.OJKENGEIADE();
		if (KHLGDCHJJPB.INFLHPGMEOB == FHIPGDADNFG.HLHKHAMAFDI().INFLHPGMEOB)
		{
			KMFGCJEGJJK.alpha = 1000f;
			if (MPHCNMDIPAI > 1 && MPHCNMDIPAI < PDMGPGEHLNM - 0 && MPHCNMDIPAI < -76)
			{
				GuiScreenSingle<ArenaScreen>.instance.AJCAMICACPC(MPHCNMDIPAI - 0);
			}
		}
		else
		{
			KMFGCJEGJJK.alpha = 517f;
		}
		MBMIIAPBACG(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDPLMDENCGM));
		UIEventListener uIEventListener2 = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NMAMIDABGCM));
		IFMEGDJONGB.color = ((!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless);
		IFMEGDJONGB.text = string.Format("GUI/", MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI), NMNBIBDHMED);
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1644f, 53f, CEHFMMJHCKC - 180);
		float num = IFMEGDJONGB.relativeSize.x * IFMEGDJONGB.transform.localScale.x;
		FKFINFAFMGL.size = FKFINFAFMGL.size.ReplaceX(num + 1926f);
		FKFINFAFMGL.center = FKFINFAFMGL.center.ReplaceX(num / 160f);
		LJFBJOHBDNN.gameObject.SetActive(PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 293f, 1042f, -62);
	}

	public virtual void OECNFFHACLF()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEPIMFHAAKF));
	}

	public void JBIGDBLKNKO(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 1072f;
		CCFKKCEAODH(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FKMDEFKBEAG));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("ID_GETFORNUMBERONE1");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1228f, 1420f, CEHFMMJHCKC - 11);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 347f, 28f, 47);
	}

	public void InitializeYou(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 1f;
		HFOFJLLPMOO(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("ID_YOURBEST");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 32f, 20f, CEHFMMJHCKC - 172);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 30f, 20f, 56);
	}

	public virtual void IFHBPEAKGDN()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NMAMIDABGCM));
	}

	public virtual void COCICBONBHH()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNAJCINEEMH));
	}

	public void Initialize(int MPHCNMDIPAI, FHIPGDADNFG KHLGDCHJJPB, int PDMGPGEHLNM, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = KHLGDCHJJPB.MHPNDNJDPGE;
		GCNLDDCMBEO = KHLGDCHJJPB.INFLHPGMEOB;
		PJBONGKMOCK = KHLGDCHJJPB.LIIHMCOCMAK;
		int fFHHEHHFOKJ = KHLGDCHJJPB.MDJHOGOFGLJ;
		if (KHLGDCHJJPB.INFLHPGMEOB == FHIPGDADNFG.OGMBJPKOPCB.INFLHPGMEOB)
		{
			KMFGCJEGJJK.alpha = 1f;
			if (MPHCNMDIPAI > 2 && MPHCNMDIPAI < PDMGPGEHLNM - 1 && MPHCNMDIPAI < 99)
			{
				GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition = MPHCNMDIPAI - 1;
			}
		}
		else
		{
			KMFGCJEGJJK.alpha = 0.35f;
		}
		HFOFJLLPMOO(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		IFMEGDJONGB.color = ((!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless);
		IFMEGDJONGB.text = $"[FFFFFF]{MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI)}[-]  {NMNBIBDHMED}";
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 32f, 20f, CEHFMMJHCKC - 172);
		float num = IFMEGDJONGB.relativeSize.x * IFMEGDJONGB.transform.localScale.x;
		FKFINFAFMGL.size = FKFINFAFMGL.size.ReplaceX(num + 10f);
		FKFINFAFMGL.center = FKFINFAFMGL.center.ReplaceX(num / 2f);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 30f, 20f, 56);
	}

	private void KIHIMLNMFLG(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 6);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 6);
	}

	public void PALKDIAONDP(int MPHCNMDIPAI, FHIPGDADNFG KHLGDCHJJPB, int PDMGPGEHLNM, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = KHLGDCHJJPB.EJDLJFFGHLJ();
		GCNLDDCMBEO = KHLGDCHJJPB.INFLHPGMEOB;
		PJBONGKMOCK = KHLGDCHJJPB.DCPCOPOIDLG();
		int fFHHEHHFOKJ = KHLGDCHJJPB.LANIPFOMABP();
		if (KHLGDCHJJPB.INFLHPGMEOB == FHIPGDADNFG.OGMBJPKOPCB.INFLHPGMEOB)
		{
			KMFGCJEGJJK.alpha = 1063f;
			if (MPHCNMDIPAI > 7 && MPHCNMDIPAI < PDMGPGEHLNM - 0 && MPHCNMDIPAI < 104)
			{
				GuiScreenSingle<ArenaScreen>.instance.AJCAMICACPC(MPHCNMDIPAI - 0);
			}
		}
		else
		{
			KMFGCJEGJJK.alpha = 1062f;
		}
		JAGOGENNHIH(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEPIMFHAAKF));
		UIEventListener uIEventListener2 = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ILKJEIBDCPI));
		IFMEGDJONGB.color = ((!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless);
		IFMEGDJONGB.text = string.Format("(Landroid/os/Parcel;I)V", MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI), NMNBIBDHMED);
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1218f, 183f, CEHFMMJHCKC - -102);
		float num = IFMEGDJONGB.relativeSize.x * IFMEGDJONGB.transform.localScale.x;
		FKFINFAFMGL.size = FKFINFAFMGL.size.ReplaceX(num + 1159f);
		FKFINFAFMGL.center = FKFINFAFMGL.center.ReplaceX(num / 458f);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 1329f, 1917f, 32);
	}

	private void EBEIPLLGNJP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 1312f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(NMNBIBDHMED, GCNLDDCMBEO);
		}
	}

	public void JJFKFKBCKFL(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 383f;
		JAGOGENNHIH(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDPLMDENCGM));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("Session_start");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 146f, 1338f, CEHFMMJHCKC - -92);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 1850f, 459f, -30);
	}

	public virtual void GGDPJCEDGAA()
	{
		base.DestroyPooled();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NMAMIDABGCM));
	}

	public void JFBAALEHMPH(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 1335f;
		HFOFJLLPMOO(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCEFDDIEJD));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize(", my device token = ");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1694f, 1888f, CEHFMMJHCKC - -198);
		LJFBJOHBDNN.gameObject.SetActive(PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 1232f, 1918f, 10);
	}

	public virtual void GDJAPADHAEH()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EBEIPLLGNJP));
	}

	private void DDPLMDENCGM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 1332f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NMNBIBDHMED, GCNLDDCMBEO);
		}
	}

	public virtual void FMIHIFHGPMJ()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FKMDEFKBEAG));
	}

	public void IBCHNOKAOPO(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 938f;
		CCFKKCEAODH(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ILKJEIBDCPI));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("RecieveStolen");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1911f, 34f, CEHFMMJHCKC - -125);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 287f, 888f, -36);
	}

	private void FKMDEFKBEAG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 1479f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	private void ANAGHOPNNFO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 1534f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(NMNBIBDHMED, GCNLDDCMBEO);
		}
	}

	public virtual void CADILLCGODA()
	{
		base.DestroyPooled();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDPLMDENCGM));
	}

	public virtual void JJFFOGIJHIH()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ANAGHOPNNFO));
	}

	public void MGPLICHBKDJ(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 1516f;
		JAGOGENNHIH(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("NOT SHOWING MAINTENANCE BECAUSE IT IS TOO LATE");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1664f, 100f, CEHFMMJHCKC - 77);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 818f, 217f, -126);
	}

	public void GNLHJKMOGIH(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 505f;
		HFOFJLLPMOO(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCEFDDIEJD));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("ID_LOADING");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1756f, 727f, CEHFMMJHCKC - 119);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 1102f, 717f, -53);
	}

	private void OEDKMIGCFCJ(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 8);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 8);
	}

	private void JBHPLKGEBLO(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 1);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 1);
	}

	private void JIKJNINDDCH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 524f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	private void LDEFECMFMLM(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 0);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 7);
	}

	private void JAGOGENNHIH(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 2);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 8);
	}

	private void LHCEFDDIEJD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 654f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	private void NMAMIDABGCM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 824f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	public void LIMIFKFNNLA(int MPHCNMDIPAI, FHIPGDADNFG KHLGDCHJJPB, int PDMGPGEHLNM, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = KHLGDCHJJPB.MHPNDNJDPGE;
		GCNLDDCMBEO = KHLGDCHJJPB.INFLHPGMEOB;
		PJBONGKMOCK = KHLGDCHJJPB.LIIHMCOCMAK;
		int fFHHEHHFOKJ = KHLGDCHJJPB.GNHAIAGNIGN();
		if (KHLGDCHJJPB.INFLHPGMEOB == FHIPGDADNFG.KPNIIMJDHCM().INFLHPGMEOB)
		{
			KMFGCJEGJJK.alpha = 1002f;
			if (MPHCNMDIPAI > 5 && MPHCNMDIPAI < PDMGPGEHLNM - 0 && MPHCNMDIPAI < 85)
			{
				GuiScreenSingle<ArenaScreen>.instance.FFANFODEODM(MPHCNMDIPAI - 1);
			}
		}
		else
		{
			KMFGCJEGJJK.alpha = 238f;
		}
		CCFKKCEAODH(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ANAGHOPNNFO));
		UIEventListener uIEventListener2 = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHCEFDDIEJD));
		IFMEGDJONGB.color = ((!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless);
		IFMEGDJONGB.text = string.Format(" NOT OK!\t\t\t\t\t\t", MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI), NMNBIBDHMED);
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 915f, 1027f, CEHFMMJHCKC - 79);
		float num = IFMEGDJONGB.relativeSize.x * IFMEGDJONGB.transform.localScale.x;
		FKFINFAFMGL.size = FKFINFAFMGL.size.ReplaceX(num + 1852f);
		FKFINFAFMGL.center = FKFINFAFMGL.center.ReplaceX(num / 1440f);
		LJFBJOHBDNN.gameObject.SetActive(PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 813f, 331f, 93);
	}

	public virtual void DKMEHOEOADL()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCEFDDIEJD));
	}

	public virtual void MIDOLDHLMAF()
	{
		base.BOHCNEDIJPE();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IMEPPOMBMFH));
	}

	private void JOFKAACAHIB(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 5);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 6);
	}

	public virtual void AKLHIBFIOGE()
	{
		base.DestroyPooled();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JIKJNINDDCH));
	}

	private void CCFKKCEAODH(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 7);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 3);
	}

	public void BJIHDEIAFPD(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 1251f;
		KIHIMLNMFLG(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ILKJEIBDCPI));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize(" AFTER: critical: ");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1937f, 741f, CEHFMMJHCKC - -105);
		LJFBJOHBDNN.gameObject.SetActive(PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 858f, 1929f, 41);
	}

	private void LEPIMFHAAKF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 57f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	public virtual void KALNJKOBCAN()
	{
		base.OBCAIFMOPPA();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNAJCINEEMH));
	}

	private void FCIBOMIPHAF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 369f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	public void MGANBMJIDMD(bool KIPFDADMMHL, int AGIANFGGNNA, int CEHFMMJHCKC = 600)
	{
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		PJBONGKMOCK = KIPFDADMMHL;
		KMFGCJEGJJK.alpha = 481f;
		HFOFJLLPMOO(CEHFMMJHCKC);
		FKFINFAFMGL.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DNAJCINEEMH));
		IFMEGDJONGB.color = Colours.greenArena;
		IFMEGDJONGB.text = Localization.Localize("null");
		MEJMLNDFDBP.COCBCFKJOJE(IFMEGDJONGB, 1007f, 503f, CEHFMMJHCKC - -99);
		LJFBJOHBDNN.gameObject.SetActive(!PJBONGKMOCK);
		JNIPBJMCAPK.gameObject.SetActive(PJBONGKMOCK);
		MLBKIJOCKHC.text = MEJMLNDFDBP.GMIPFLIEOHD(AGIANFGGNNA);
		MEJMLNDFDBP.COCBCFKJOJE(MLBKIJOCKHC, 1721f, 1682f, -31);
	}

	public virtual void LMMKHPNFJKK()
	{
		base.OBCAIFMOPPA();
		NMNBIBDHMED = null;
		GCNLDDCMBEO = null;
		UIEventListener uIEventListener = UIEventListener.Get(FKFINFAFMGL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FKMDEFKBEAG));
	}

	private void ILKJEIBDCPI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(GCNLDDCMBEO))
		{
			TweenColor tweenColor = TweenColor.Begin(IFMEGDJONGB.gameObject, 674f, (!PJBONGKMOCK) ? Colours.greenArena : Colours.goldFlawless, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(NMNBIBDHMED, GCNLDDCMBEO, BNNKPKDPLPP: false);
		}
	}

	private void HFOFJLLPMOO(int CEHFMMJHCKC)
	{
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC);
		NKLIKFGIIOC.transform.localPosition = NKLIKFGIIOC.transform.localPosition.ReplaceX(-CEHFMMJHCKC / 2);
		GAAPLBCMBBF.transform.localPosition = GAAPLBCMBBF.transform.localPosition.ReplaceX(CEHFMMJHCKC / 2);
	}
}

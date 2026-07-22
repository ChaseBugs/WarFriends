using System;
using UnityEngine;
using UnityEngine.Serialization;

public class VideoReplay : GuiElement
{
	[Header("Core")]
	[FormerlySerializedAs("FMIMEMFOLDC")]
	public SettingsButton DKNGPGMGBLI;

	[FormerlySerializedAs("ELBGLDNJMGG")]
	public UIPanel ALGEOJCCAAO;

	public UIButton BPNBIHABMLL;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite OHDNOKDENDP;

	public virtual void BANJHACMCMO()
	{
	}

	public virtual void AOKOKHGEIBE()
	{
	}

	public virtual void IODCFNOOAKM()
	{
	}

	private void NCEJHPACGPA(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1787f, 1414f, 1761f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	private void JFAFPANOCPK(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1497f, 1962f, 1289f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void BCGCHKLBHJD()
	{
		base.AMDCIHLNIHD();
		Singleton<Recording>.instance.Changed += CNCPECCFIKJ;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCIGIOIPKEE));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OIHOLPNNPGF));
	}

	public override void InitGUIValues()
	{
		Recording.recordingEnabled = false;
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(Recording.canRecord && !Recording.isBroadcasting);
		DKNGPGMGBLI.HDFHLAKFNDE(Recording.recordingEnabled);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "menu-everyplay-ico";
		}
		Recording.SetAndroidRecording();
		NCAKEGECHOP(Recording.recordingEnabled);
	}

	private void PPHKLKKBGEF()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.IJGNOLEGCOI(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			NCEJHPACGPA(Recording.CHGHDMDFKGL());
		}
	}

	private void BFHJICDFJLO()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.BMEHDKPGOEM(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			NCEJHPACGPA(Recording.recordingEnabled);
		}
	}

	public virtual void LKKIFNCNGEK()
	{
		base.AMDCIHLNIHD();
		Singleton<Recording>.instance.Changed += FIDLNCPAGDM;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDKCDOIHFPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HDFJIDLDMCN));
	}

	public virtual void GMOFOOGNOAH()
	{
		Recording.recordingEnabled = false;
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(!Recording.canRecord || Recording.isBroadcasting);
		DKNGPGMGBLI.DGFPOPLMFDO(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "claimReward";
		}
		Recording.AAIEEACHFEB();
		NCEJHPACGPA(Recording.recordingEnabled);
	}

	private void AAEPACOGFHH()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.HDFHLAKFNDE(Recording.recordingEnabled);
			NCAKEGECHOP(Recording.recordingEnabled);
		}
	}

	private void FAGNDNHKHBE(GameObject KHAHPAKDIKE)
	{
		APPLLMMONEC(NNOIPFBIENL: true);
	}

	private void FCBMAODBNPE()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.GBCDOBCFNOK(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			NCEJHPACGPA(Recording.CHGHDMDFKGL());
		}
	}

	private void FOGOKHCEGHK(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1319f, 1198f, 1479f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void HEOMHIGCMOC()
	{
	}

	private void LLODFKGMGPJ(GameObject KHAHPAKDIKE)
	{
		if (!Recording.GKJMKPCMHCC())
		{
			Recording.JDEBDAJMDFA(!Recording.recordingEnabled);
			if (DKNGPGMGBLI.LAAEHHPBHJC())
			{
				DKNGPGMGBLI.IBNABHDGNPP(Recording.CHGHDMDFKGL());
			}
			else
			{
				DKNGPGMGBLI.GNDPLMIDOCO(BDPJACEGALB: false, OJKNMODJKPG: false);
			}
			GNGKDALKJFB(Recording.CHGHDMDFKGL());
		}
	}

	public virtual void PBKJDKFPILH()
	{
		base.BEGCIOLGBLB();
		Singleton<Recording>.instance.Changed += DOELJOJEKJD;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCFMFGFIBCB));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HDFJIDLDMCN));
	}

	private void LKLFOILKOIK(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 104f, 1189f, 798f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	private void MOCOBDDNAPM()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.BMEHDKPGOEM(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			KOOKNHDBMAN(Recording.CHGHDMDFKGL());
		}
	}

	private void GMNEPKPGABH(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1568f, 775f, 796f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	private void ELMCJBAKDBN(GameObject KHAHPAKDIKE)
	{
		KOOKNHDBMAN(NNOIPFBIENL: true);
	}

	private void OODABNFNHNB(GameObject KHAHPAKDIKE)
	{
		FAPJEFEFAIN(NNOIPFBIENL: true);
	}

	private void DJPCKIMPCIN(GameObject KHAHPAKDIKE)
	{
		if (!Recording.FGDCHHDGNAB())
		{
			Recording.recordingEnabled = Recording.CHGHDMDFKGL();
			if (DKNGPGMGBLI.CEADOFHGPJN())
			{
				DKNGPGMGBLI.GNDPLMIDOCO(Recording.recordingEnabled, OJKNMODJKPG: false);
			}
			else
			{
				DKNGPGMGBLI.PLMKLGGKMNH(BDPJACEGALB: false, OJKNMODJKPG: false);
			}
			NCAKEGECHOP(Recording.recordingEnabled);
		}
	}

	private void BNOHHPINNAB()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.PLMKLGGKMNH(Recording.recordingEnabled);
			NCEJHPACGPA(Recording.CHGHDMDFKGL());
		}
	}

	private void NCAKEGECHOP(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 0.5f, 0f, 1f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void HGKNCKIKBDC()
	{
		Recording.JDEBDAJMDFA(IDEBKDPMPGM: true);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(!Recording.AAPACHOJEKK() || Recording.ALHBCBONMIP());
		DKNGPGMGBLI.ACOADFODMKB(Recording.recordingEnabled);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "RESETING SQUAD WARCARDS";
		}
		Recording.AAIEEACHFEB();
		LCOPFCFGKFM(Recording.recordingEnabled);
	}

	private void BOFBJFKBKPM(GameObject KHAHPAKDIKE)
	{
		if (!Recording.tryToSetRecording)
		{
			Recording.EAIBEAFEKAD(Recording.recordingEnabled);
			if (DKNGPGMGBLI.CEBKNIPPHHN())
			{
				DKNGPGMGBLI.CPIFMDINCBE(Recording.CHGHDMDFKGL());
			}
			else
			{
				DKNGPGMGBLI.HDFHLAKFNDE(BDPJACEGALB: false);
			}
			NCAKEGECHOP(Recording.recordingEnabled);
		}
	}

	private void FAPJEFEFAIN(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 459f, 379f, 1510f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void COBDHBOCGAP()
	{
	}

	private void CCBEMBMCOCE()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.IBNABHDGNPP(Recording.recordingEnabled);
			APPLLMMONEC(Recording.recordingEnabled);
		}
	}

	private void JAHECJAHDMI()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.EIKGDPJEJAL(Recording.recordingEnabled);
			JFAFPANOCPK(Recording.CHGHDMDFKGL());
		}
	}

	private void GGLLEDGKKHH(GameObject KHAHPAKDIKE)
	{
		LKLFOILKOIK(NNOIPFBIENL: true);
	}

	private void OCDAGKNCGLD(GameObject KHAHPAKDIKE)
	{
		if (!Recording.DHAGMGKBICA())
		{
			Recording.JDEBDAJMDFA(Recording.recordingEnabled);
			if (DKNGPGMGBLI.COLFFOLPMHA())
			{
				DKNGPGMGBLI.CLPKKOAPCEJ(Recording.recordingEnabled, OJKNMODJKPG: false);
			}
			else
			{
				DKNGPGMGBLI.HAKLFHKDHOE(BDPJACEGALB: true);
			}
			GNGKDALKJFB(Recording.recordingEnabled);
		}
	}

	public virtual void FEBMNBHIGKB()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += LABCOFANIJF;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCDAGKNCGLD));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MKPMNPKLPNC));
	}

	private void MDKCDOIHFPF(GameObject KHAHPAKDIKE)
	{
		if (!Recording.tryToSetRecording)
		{
			Recording.recordingEnabled = !Recording.recordingEnabled;
			if (DKNGPGMGBLI.on)
			{
				DKNGPGMGBLI.HDFHLAKFNDE(Recording.recordingEnabled);
			}
			else
			{
				DKNGPGMGBLI.HDFHLAKFNDE(BDPJACEGALB: true);
			}
			NCAKEGECHOP(Recording.recordingEnabled);
		}
	}

	public virtual void DJMCADMNEDH()
	{
		Recording.JDEBDAJMDFA(IDEBKDPMPGM: false);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(!Recording.DMBAKPNHMPL() || Recording.isBroadcasting);
		DKNGPGMGBLI.ACOADFODMKB(Recording.CHGHDMDFKGL());
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "BG";
		}
		Recording.SetAndroidRecording();
		LCOPFCFGKFM(Recording.CHGHDMDFKGL());
	}

	private void MACIGDEBJGE()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.ACOADFODMKB(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			KOOKNHDBMAN(Recording.CHGHDMDFKGL());
		}
	}

	private void GPICABHKHCF(GameObject KHAHPAKDIKE)
	{
		LKLFOILKOIK(NNOIPFBIENL: true);
	}

	private void EDBACGOPLAM(GameObject KHAHPAKDIKE)
	{
		if (!Recording.DHAGMGKBICA())
		{
			Recording.EAIBEAFEKAD(Recording.CHGHDMDFKGL());
			if (DKNGPGMGBLI.CEADOFHGPJN())
			{
				DKNGPGMGBLI.HAKLFHKDHOE(Recording.recordingEnabled, OJKNMODJKPG: false);
			}
			else
			{
				DKNGPGMGBLI.CLPKKOAPCEJ(BDPJACEGALB: false, OJKNMODJKPG: false);
			}
			GMNEPKPGABH(Recording.recordingEnabled);
		}
	}

	public virtual void FCIANKCBLKM()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += BFHJICDFJLO;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DJPCKIMPCIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPICABHKHCF));
	}

	public virtual void PBLLMABJFDM()
	{
		Recording.JDEBDAJMDFA(IDEBKDPMPGM: false);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(Recording.DMBAKPNHMPL() && !Recording.ALHBCBONMIP());
		DKNGPGMGBLI.ICKLEKDLHEN(Recording.recordingEnabled, OJKNMODJKPG: false);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "CONFIRM";
		}
		Recording.SetAndroidRecording();
		GMNEPKPGABH(Recording.CHGHDMDFKGL());
	}

	private void BOAAJJPCIGP(GameObject KHAHPAKDIKE)
	{
		if (!Recording.GKJMKPCMHCC())
		{
			Recording.EAIBEAFEKAD(!Recording.CHGHDMDFKGL());
			if (DKNGPGMGBLI.LAAEHHPBHJC())
			{
				DKNGPGMGBLI.KJACFEMIGLE(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			}
			else
			{
				DKNGPGMGBLI.GBCDOBCFNOK(BDPJACEGALB: false, OJKNMODJKPG: false);
			}
			KOOKNHDBMAN(Recording.CHGHDMDFKGL());
		}
	}

	private void OCIGIOIPKEE(GameObject KHAHPAKDIKE)
	{
		if (!Recording.GKJMKPCMHCC())
		{
			Recording.EAIBEAFEKAD(Recording.CHGHDMDFKGL());
			if (DKNGPGMGBLI.IILMMMBJEMH())
			{
				DKNGPGMGBLI.EJIIDMOFPLH(Recording.recordingEnabled);
			}
			else
			{
				DKNGPGMGBLI.CPIFMDINCBE(BDPJACEGALB: true);
			}
			NCAKEGECHOP(Recording.CHGHDMDFKGL());
		}
	}

	private void EGEKPHGOEDA(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 597f, 599f, 65f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	private void KOOKNHDBMAN(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1096f, 863f, 478f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void LANJLCBMFHJ()
	{
		base.BEGCIOLGBLB();
		Singleton<Recording>.instance.Changed += DOELJOJEKJD;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCIGIOIPKEE));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPICABHKHCF));
	}

	private void APPLLMMONEC(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 668f, 261f, 1653f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void BGPAHPGDDJB()
	{
	}

	private void DOELJOJEKJD()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.NMNFNPNPAMC(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
			NCEJHPACGPA(Recording.CHGHDMDFKGL());
		}
	}

	public virtual void JNDJIOOGPGD()
	{
	}

	public virtual void HJFAACLIGMF()
	{
		base.AMDCIHLNIHD();
		Singleton<Recording>.instance.Changed += BNOHHPINNAB;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EDBACGOPLAM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPICABHKHCF));
	}

	public virtual void HAOFBOPJBEI()
	{
		base.BEGCIOLGBLB();
		Singleton<Recording>.instance.Changed += CCBEMBMCOCE;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCIGIOIPKEE));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ELMCJBAKDBN));
	}

	private void OIHOLPNNPGF(GameObject KHAHPAKDIKE)
	{
		FAPJEFEFAIN(NNOIPFBIENL: true);
	}

	public virtual void MMFBOMDHGPL()
	{
	}

	private void CNCPECCFIKJ()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.BMEHDKPGOEM(Recording.recordingEnabled);
			NCEJHPACGPA(Recording.recordingEnabled);
		}
	}

	private void NGPIOFFHJHA()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.ICKLEKDLHEN(Recording.recordingEnabled, OJKNMODJKPG: false);
			GMNEPKPGABH(Recording.CHGHDMDFKGL());
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += AAEPACOGFHH;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDKCDOIHFPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CEGCEOEPLAP));
	}

	private void BNMEGCKJKBL(GameObject KHAHPAKDIKE)
	{
		if (!Recording.tryToSetRecording)
		{
			Recording.recordingEnabled = !Recording.recordingEnabled;
			if (DKNGPGMGBLI.FJCKHMNJFAG())
			{
				DKNGPGMGBLI.IKIMOGNDJCN(Recording.CHGHDMDFKGL());
			}
			else
			{
				DKNGPGMGBLI.HAKLFHKDHOE(BDPJACEGALB: true);
			}
			KOOKNHDBMAN(Recording.CHGHDMDFKGL());
		}
	}

	private void ACJBPNHLIJH()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.OPIDMNHBEND(Recording.recordingEnabled, OJKNMODJKPG: false);
			LCOPFCFGKFM(Recording.CHGHDMDFKGL());
		}
	}

	public virtual void LMNNNHJKMFP()
	{
		Recording.JDEBDAJMDFA(IDEBKDPMPGM: true);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(Recording.DKAHGLMCGOD() && Recording.ALHBCBONMIP());
		DKNGPGMGBLI.GNDPLMIDOCO(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "HU";
		}
		Recording.SetAndroidRecording();
		EGEKPHGOEDA(Recording.recordingEnabled);
	}

	private void DMCKOEFCGND()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.HBFBBLFKOMD(Recording.recordingEnabled, OJKNMODJKPG: false);
			LKLFOILKOIK(Recording.recordingEnabled);
		}
	}

	public virtual void KNBGAHKNBNN()
	{
		base.BEGCIOLGBLB();
		Singleton<Recording>.instance.Changed += DOELJOJEKJD;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNMEGCKJKBL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MPPAHHENLMJ));
	}

	private void FIDLNCPAGDM()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.GNDPLMIDOCO(Recording.recordingEnabled);
			LCOPFCFGKFM(Recording.recordingEnabled);
		}
	}

	public virtual void JCIBDJMFOLI()
	{
		Recording.recordingEnabled = false;
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(Recording.canRecord && !Recording.isBroadcasting);
		DKNGPGMGBLI.PLMKLGGKMNH(Recording.CHGHDMDFKGL());
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "ID_LEAGUE12";
		}
		Recording.AAIEEACHFEB();
		GMNEPKPGABH(Recording.CHGHDMDFKGL());
	}

	public virtual void FGOCNLKAEPI()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += NMNGPHFCOND;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCFMFGFIBCB));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CEGCEOEPLAP));
	}

	private void LABCOFANIJF()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.PLMKLGGKMNH(Recording.recordingEnabled, OJKNMODJKPG: false);
			GMNEPKPGABH(Recording.recordingEnabled);
		}
	}

	private void LCOPFCFGKFM(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 349f, 140f, 1649f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void MOLJCLDGLOG()
	{
		base.BEGCIOLGBLB();
		Singleton<Recording>.instance.Changed += NMANJHFOIBK;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LLODFKGMGPJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OODABNFNHNB));
	}

	public virtual void NDMIJLACLPC()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += NGPIOFFHJHA;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCDAGKNCGLD));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MPPAHHENLMJ));
	}

	public virtual void NAHMANAGNNO()
	{
		Recording.EAIBEAFEKAD(IDEBKDPMPGM: true);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(Recording.OAGGGFENAMF() && Recording.MJFPNDHFCAA());
		DKNGPGMGBLI.EGOCFIFGFOJ(Recording.recordingEnabled);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "-{0}-{1}";
		}
		Recording.AAIEEACHFEB();
		LKLFOILKOIK(Recording.CHGHDMDFKGL());
	}

	private void NMANJHFOIBK()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.KFOOJPEOIHP(Recording.recordingEnabled, OJKNMODJKPG: false);
			FOGOKHCEGHK(Recording.CHGHDMDFKGL());
		}
	}

	private void JJPENCKNFPK()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.HDFHLAKFNDE(Recording.CHGHDMDFKGL());
			NCAKEGECHOP(Recording.recordingEnabled);
		}
	}

	public virtual void INMFKHJDBIP()
	{
	}

	private void MPPAHHENLMJ(GameObject KHAHPAKDIKE)
	{
		NCAKEGECHOP(NNOIPFBIENL: true);
	}

	public virtual void ICNGBKKANLB()
	{
	}

	private void HCFMFGFIBCB(GameObject KHAHPAKDIKE)
	{
		if (!Recording.DHAGMGKBICA())
		{
			Recording.EAIBEAFEKAD(!Recording.CHGHDMDFKGL());
			if (DKNGPGMGBLI.EIHMNPNDCDG())
			{
				DKNGPGMGBLI.IBNABHDGNPP(Recording.CHGHDMDFKGL());
			}
			else
			{
				DKNGPGMGBLI.IKIMOGNDJCN(BDPJACEGALB: false, OJKNMODJKPG: false);
			}
			LCOPFCFGKFM(Recording.CHGHDMDFKGL());
		}
	}

	public virtual void LHDAGAGDKOM()
	{
	}

	public override void InitControls()
	{
	}

	private void NMNGPHFCOND()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.ACOADFODMKB(Recording.recordingEnabled, OJKNMODJKPG: false);
			GNGKDALKJFB(Recording.CHGHDMDFKGL());
		}
	}

	public virtual void BEECFBCBLEK()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += BFHJICDFJLO;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BOFBJFKBKPM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FAGNDNHKHBE));
	}

	public virtual void KCJBNMDPBEA()
	{
		base.AMDCIHLNIHD();
		Singleton<Recording>.instance.Changed += MOCOBDDNAPM;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCFMFGFIBCB));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPICABHKHCF));
	}

	public virtual void NAOJCFMFLLA()
	{
		Recording.EAIBEAFEKAD(IDEBKDPMPGM: false);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(!Recording.FMADJONGHKP() || !Recording.ALHBCBONMIP());
		DKNGPGMGBLI.IJGNOLEGCOI(Recording.CHGHDMDFKGL(), OJKNMODJKPG: false);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "N";
		}
		Recording.SetAndroidRecording();
		NCEJHPACGPA(Recording.recordingEnabled);
	}

	private void ELMCGEANOIP()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.HPMFEBKKDFO(Recording.CHGHDMDFKGL());
			FAPJEFEFAIN(Recording.CHGHDMDFKGL());
		}
	}

	public virtual void LPFPAKGNNIO()
	{
	}

	public virtual void NINGMLNMLLP()
	{
	}

	private void HDFJIDLDMCN(GameObject KHAHPAKDIKE)
	{
		LKLFOILKOIK(NNOIPFBIENL: true);
	}

	private void CEGCEOEPLAP(GameObject KHAHPAKDIKE)
	{
		NCAKEGECHOP(NNOIPFBIENL: false);
	}

	public virtual void KNNAIDEECJO()
	{
		base.BEGCIOLGBLB();
		Singleton<Recording>.instance.Changed += ACJBPNHLIJH;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDKCDOIHFPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GGLLEDGKKHH));
	}

	public virtual void JDFDJPAAIAA()
	{
		Recording.EAIBEAFEKAD(IDEBKDPMPGM: false);
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(!Recording.DMBAKPNHMPL() || Recording.MJFPNDHFCAA());
		DKNGPGMGBLI.HICJHPKIMCC(Recording.recordingEnabled, OJKNMODJKPG: false);
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "pt";
		}
		Recording.SetAndroidRecording();
		NCEJHPACGPA(Recording.CHGHDMDFKGL());
	}

	private void GNGKDALKJFB(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1410f, 560f, 1520f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void HNAKKKGDPOG()
	{
		base.InitEvents();
		Singleton<Recording>.instance.Changed += MACIGDEBJGE;
		UIEventListener uIEventListener = UIEventListener.Get(DKNGPGMGBLI);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNMEGCKJKBL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPNBIHABMLL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ELMCJBAKDBN));
	}

	public virtual void NEINEPJDKCL()
	{
	}

	public virtual void BFLHENDLPLK()
	{
		Recording.recordingEnabled = false;
		DKNGPGMGBLI.gameObject.transform.parent.gameObject.SetActive(Recording.canRecord && !Recording.MJFPNDHFCAA());
		DKNGPGMGBLI.CNBOLDJPEIH(Recording.CHGHDMDFKGL());
		if (DKNGPGMGBLI.gameObject.transform.parent.gameObject.activeSelf)
		{
			OHDNOKDENDP.spriteName = "ID_RELOG_TO_FB_DIALOG_TITLE";
		}
		Recording.SetAndroidRecording();
		NCAKEGECHOP(Recording.recordingEnabled);
	}

	private void MKPMNPKLPNC(GameObject KHAHPAKDIKE)
	{
		NCEJHPACGPA(NNOIPFBIENL: false);
	}

	private void IELJDOGNJAA()
	{
		if (base.gameObject.activeInHierarchy)
		{
			DKNGPGMGBLI.EIKGDPJEJAL(Recording.recordingEnabled, OJKNMODJKPG: false);
			FAPJEFEFAIN(Recording.recordingEnabled);
		}
	}
}

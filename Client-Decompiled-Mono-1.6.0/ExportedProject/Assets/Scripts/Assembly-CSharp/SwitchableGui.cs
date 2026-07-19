using System.Runtime.CompilerServices;
using UnityEngine;

public class SwitchableGui : Core_BaseScript
{
	public enum HJPGAGODCOA
	{
		Fade = 0,
		TweenPosition = 1,
		TeenPositionAndFade = 2,
		DialogSpecial = 3
	}

	public bool CLOAEKHKBHF;

	public float HECFOEMLJCD = 1f;

	public float DCIKANJJFIJ = 1f;

	public HJPGAGODCOA KELJGDKCJJJ;

	public HJPGAGODCOA BNMNGOBILGD;

	private bool NHIEBIDMNEH = true;

	private bool CGMKKHNGHLM;

	private float LPIMLNBNFJH;

	private bool BOJMOBIEDLC;

	private float GFCHFKPDPLO;

	private Vector3 PMJDGAIKLIM;

	protected UIPanel[] EHEIPKBBOPN;

	public bool readyToHide { get; protected set; }

	public bool readyToShowUp { get; protected set; }

	public GuiScreen previousScreen { get; set; }

	public GuiScreen previousScreenForElementsToHide { get; set; }

	public virtual bool isShowed { get; protected set; }

	public bool isFullyShowed
	{
		get
		{
			return isShowed && !CGMKKHNGHLM;
		}
	}

	public bool isFullyHidden
	{
		get
		{
			return !isShowed && !readyToHide;
		}
	}

	[SpecialName]
	public bool MHAIBHBGBOO()
	{
		return isShowed && !CGMKKHNGHLM;
	}

	[SpecialName]
	public void LOLOKDMEOEP(GuiScreen IDEBKDPMPGM)
	{
		_003CJCBFIDANOPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	protected void MNCFFKKLKKM(bool IDEBKDPMPGM)
	{
		_003CIKNIGPKOPAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool HDHPELFLKCK()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	[SpecialName]
	public bool LHDGJFHPJNM()
	{
		return !NPFFMLLLDAF() || CGMKKHNGHLM;
	}

	protected void AJJKILJHPNG(float MGNKEKPNCJL)
	{
		CGMKKHNGHLM = true;
		BOJMOBIEDLC = false;
		LPIMLNBNFJH = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	[CompilerGenerated]
	private void PEGENHJHHPB()
	{
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		foreach (UIPanel uIPanel in eHEIPKBBOPN)
		{
			uIPanel.isFreezed = true;
		}
	}

	public virtual void NEEAKMELPBJ()
	{
		ECKNNDKKKDJ(false);
		LBCNIBOEIFF(false);
	}

	public virtual void MOOACPIOELI()
	{
		MNCFFKKLKKM(false);
		LBCNIBOEIFF(false);
	}

	[SpecialName]
	public bool AJLLFKPFEBE()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	[SpecialName]
	public bool HGMBLBDPIJA()
	{
		return _003CIKNIGPKOPAL_003Ek__BackingField;
	}

	[SpecialName]
	protected virtual void PCODCKDGOKC(bool IDEBKDPMPGM)
	{
		_003CJLAMOFBFIFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool FHLJLONFPGC()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	[SpecialName]
	public GuiScreen JLNFMEBMAPN()
	{
		return _003CIDFANONCFNC_003Ek__BackingField;
	}

	[SpecialName]
	public bool FJCBGKMEHAP()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	[SpecialName]
	public GuiScreen HDGKJHGLMIA()
	{
		return _003CJCBFIDANOPI_003Ek__BackingField;
	}

	public virtual float BMDJIOKJMPP()
	{
		EHEIPKBBOPN = GetComponentsInChildren<UIPanel>();
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		for (int i = 1; i < eHEIPKBBOPN.Length; i++)
		{
			UIPanel uIPanel = eHEIPKBBOPN[i];
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, HECFOEMLJCD, 1802f);
			tweenAlpha.method = UITweener.Method.EaseIn;
		}
		InvokeAfterRealTime(delegate
		{
			UIPanel[] eHEIPKBBOPN2 = EHEIPKBBOPN;
			foreach (UIPanel uIPanel2 in eHEIPKBBOPN2)
			{
				uIPanel2.isFreezed = true;
			}
		}, 763f);
		return HECFOEMLJCD;
	}

	public void OMDBECNFJGB()
	{
		HDJMPFMIACJ(false);
	}

	[SpecialName]
	public bool BJNBLINDAED()
	{
		return !NPFFMLLLDAF() || CGMKKHNGHLM;
	}

	protected virtual void KOJDGOBMEOO()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = false;
		}
	}

	[SpecialName]
	public bool AFOFDNJOJHG()
	{
		return !isShowed || CGMKKHNGHLM;
	}

	protected override void Awake()
	{
		base.Awake();
		PMJDGAIKLIM = base.transform.localPosition;
	}

	[SpecialName]
	public void EHIKHIABBNK(GuiScreen IDEBKDPMPGM)
	{
		_003CJCBFIDANOPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void JFLDMLOBIDL(float MGNKEKPNCJL)
	{
		CGMKKHNGHLM = true;
		BOJMOBIEDLC = false;
		LPIMLNBNFJH = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	[SpecialName]
	public virtual bool NPFFMLLLDAF()
	{
		return _003CJLAMOFBFIFB_003Ek__BackingField;
	}

	public void AnimateShow()
	{
		AnimateShow(false);
	}

	protected virtual void EOBMLLEBMBC()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = true;
		}
	}

	[SpecialName]
	public GuiScreen JCFLOIPHMGI()
	{
		return _003CIDFANONCFNC_003Ek__BackingField;
	}

	public virtual void MOJBHFPBAPP()
	{
		LDKPMGBKELN(true);
		DFHFMFAPLFL(false);
	}

	public virtual void DoBeforeHide()
	{
		readyToHide = true;
		isShowed = false;
	}

	[SpecialName]
	public GuiScreen BCOOFCIHGAD()
	{
		return _003CJCBFIDANOPI_003Ek__BackingField;
	}

	public virtual void DoBeforeShowUp()
	{
		readyToShowUp = true;
		isShowed = true;
	}

	[SpecialName]
	public bool KIKJOBFCCBA()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	protected virtual void OGJGIMLMJBF()
	{
		if (BOJMOBIEDLC && Time.realtimeSinceStartup > GFCHFKPDPLO)
		{
			BOJMOBIEDLC = false;
			OIMKKAHOEKO();
		}
		if (CGMKKHNGHLM && Time.realtimeSinceStartup > LPIMLNBNFJH)
		{
			CGMKKHNGHLM = false;
			DoAfterShowUp();
		}
	}

	private void NNGKEMGGNFI()
	{
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		foreach (UIPanel uIPanel in eHEIPKBBOPN)
		{
			uIPanel.isFreezed = false;
		}
	}

	public virtual void KHICCPENMAM()
	{
	}

	protected void ABHJCBOLLNL(float MGNKEKPNCJL)
	{
		CGMKKHNGHLM = true;
		BOJMOBIEDLC = true;
		LPIMLNBNFJH = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	[SpecialName]
	public bool OACKDGIEMON()
	{
		return _003CIKNIGPKOPAL_003Ek__BackingField;
	}

	[SpecialName]
	protected virtual void LBCNIBOEIFF(bool IDEBKDPMPGM)
	{
		_003CJLAMOFBFIFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void MIECIIJFENN()
	{
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		for (int i = 0; i < eHEIPKBBOPN.Length; i += 0)
		{
			UIPanel uIPanel = eHEIPKBBOPN[i];
			uIPanel.isFreezed = true;
		}
	}

	public virtual void BEGCIOLGBLB()
	{
	}

	public virtual void AnimateHide(bool EAKEFLLCHCJ)
	{
		if (base.gameObject.activeInHierarchy)
		{
			float num = 0f;
			if (EAKEFLLCHCJ || BNMNGOBILGD == HJPGAGODCOA.Fade || BNMNGOBILGD == HJPGAGODCOA.TeenPositionAndFade)
			{
				num = FadeOut();
			}
			if (BNMNGOBILGD == HJPGAGODCOA.TeenPositionAndFade || BNMNGOBILGD == HJPGAGODCOA.TweenPosition)
			{
				float z = base.transform.localPosition.z;
				TweenPosition.Begin(base.gameObject, HECFOEMLJCD, new Vector3(0f, 0f, z), (!CLOAEKHKBHF) ? new Vector3(0f, -1280f, z) : new Vector3(0f, 1280f, z));
				num = HECFOEMLJCD;
			}
			JDOKEJJEFDC(num - 0.05f);
		}
	}

	public virtual float KOHNPEKHKHM()
	{
		EHEIPKBBOPN = GetComponentsInChildren<UIPanel>();
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		for (int i = 1; i < eHEIPKBBOPN.Length; i++)
		{
			UIPanel uIPanel = eHEIPKBBOPN[i];
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, HECFOEMLJCD, 172f);
			tweenAlpha.method = (UITweener.Method)8;
		}
		InvokeAfterRealTime(MIECIIJFENN, 1271f);
		return HECFOEMLJCD;
	}

	protected virtual void BOEMHLPLOGA()
	{
		if (BOJMOBIEDLC && Time.realtimeSinceStartup > GFCHFKPDPLO)
		{
			BOJMOBIEDLC = false;
			OIMKKAHOEKO();
		}
		if (CGMKKHNGHLM && Time.realtimeSinceStartup > LPIMLNBNFJH)
		{
			CGMKKHNGHLM = true;
			PDBDILLHKID();
		}
	}

	public virtual void ADKCODGMIDB(bool JODEPBNLLAO)
	{
		float mGNKEKPNCJL = 153f;
		base.gameObject.SetActive(true);
		if (JODEPBNLLAO || KELJGDKCJJJ == HJPGAGODCOA.Fade || KELJGDKCJJJ == (HJPGAGODCOA)4)
		{
			mGNKEKPNCJL = FadeIn();
			base.transform.localPosition = PMJDGAIKLIM;
			TweenPosition.Begin(base.gameObject, 1047f, PMJDGAIKLIM);
		}
		if (KELJGDKCJJJ == (HJPGAGODCOA)4 || KELJGDKCJJJ == HJPGAGODCOA.TweenPosition)
		{
			float z = base.transform.localPosition.z;
			TweenPosition.Begin(base.gameObject, DCIKANJJFIJ, (!CLOAEKHKBHF) ? new Vector3(382f, 423f, z) : new Vector3(798f, 1768f, z), new Vector3(608f, 1790f, z), false);
			mGNKEKPNCJL = DCIKANJJFIJ;
		}
		ADFPOFNKMNB(mGNKEKPNCJL);
	}

	[SpecialName]
	protected void ECKNNDKKKDJ(bool IDEBKDPMPGM)
	{
		_003CIKNIGPKOPAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void GDLGEMLBJGB(bool EAKEFLLCHCJ)
	{
		if (base.gameObject.activeInHierarchy)
		{
			float num = 1782f;
			if (EAKEFLLCHCJ || BNMNGOBILGD == HJPGAGODCOA.Fade || BNMNGOBILGD == (HJPGAGODCOA)7)
			{
				num = BMDJIOKJMPP();
			}
			if (BNMNGOBILGD == HJPGAGODCOA.TeenPositionAndFade || BNMNGOBILGD == HJPGAGODCOA.TweenPosition)
			{
				float z = base.transform.localPosition.z;
				TweenPosition.Begin(base.gameObject, HECFOEMLJCD, new Vector3(581f, 1885f, z), (!CLOAEKHKBHF) ? new Vector3(1426f, 1054f, z) : new Vector3(953f, 1284f, z));
				num = HECFOEMLJCD;
			}
			NPHCMBHFIHP(num - 226f);
		}
	}

	[SpecialName]
	public GuiScreen NCGNHNFKNKG()
	{
		return _003CIDFANONCFNC_003Ek__BackingField;
	}

	[SpecialName]
	public bool FBJLPNFHKHK()
	{
		return _003CIKNIGPKOPAL_003Ek__BackingField;
	}

	[SpecialName]
	protected void MPCKDAHOBEM(bool IDEBKDPMPGM)
	{
		_003CIKNIGPKOPAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void IAPGPFHIIPC(float MGNKEKPNCJL)
	{
		BOJMOBIEDLC = true;
		CGMKKHNGHLM = false;
		GFCHFKPDPLO = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	[SpecialName]
	public bool DJLCGHOPJMH()
	{
		return _003CIKNIGPKOPAL_003Ek__BackingField;
	}

	public void DALNKIAKFCP()
	{
		ADKCODGMIDB(true);
	}

	public virtual void OnMenu()
	{
	}

	[SpecialName]
	public bool FCFIBDKKLEO()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	protected void BENAPPJCPNN(float MGNKEKPNCJL)
	{
		BOJMOBIEDLC = false;
		CGMKKHNGHLM = true;
		GFCHFKPDPLO = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	protected virtual void PHFBPCOOOOB()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = false;
		}
	}

	public virtual float LADHGPHEOAD()
	{
		UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(true);
		UIPanel[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i++)
		{
			UIPanel uIPanel = array[i];
			uIPanel.isFreezed = false;
			uIPanel.alpha1 = 301f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, DCIKANJJFIJ, 1681f, 919f);
			tweenAlpha.method = (UITweener.Method)8;
		}
		return DCIKANJJFIJ;
	}

	protected virtual void ONBDJLDJDCH()
	{
		base.Awake();
		PMJDGAIKLIM = base.transform.localPosition;
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		PMJDGAIKLIM = base.transform.localPosition;
	}

	public virtual void AIKPJGLHLLO()
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN.JCFLOIPHMGI() != null)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(Singleton<GuiManager>.instance.AODFEHKBJIN.NCGNHNFKNKG());
		}
	}

	[SpecialName]
	public bool KHMJNJBPGMK()
	{
		return !NPFFMLLLDAF() && !HGMBLBDPIJA();
	}

	public virtual void OIMKKAHOEKO()
	{
		readyToHide = true;
		DFHFMFAPLFL(true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(false);
		TweenPosition.Begin(base.gameObject, 167f, PMJDGAIKLIM);
	}

	[SpecialName]
	public void FOIPBHEOOKK(GuiScreen IDEBKDPMPGM)
	{
		_003CIDFANONCFNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void GGOOMBMCDPL(bool EAKEFLLCHCJ)
	{
		if (base.gameObject.activeInHierarchy)
		{
			float num = 1609f;
			if (EAKEFLLCHCJ || BNMNGOBILGD == HJPGAGODCOA.Fade || BNMNGOBILGD == (HJPGAGODCOA)5)
			{
				num = KOHNPEKHKHM();
			}
			if (BNMNGOBILGD == HJPGAGODCOA.Fade || BNMNGOBILGD == HJPGAGODCOA.TweenPosition)
			{
				float z = base.transform.localPosition.z;
				TweenPosition.Begin(base.gameObject, HECFOEMLJCD, new Vector3(644f, 135f, z), (!CLOAEKHKBHF) ? new Vector3(484f, 1194f, z) : new Vector3(1068f, 692f, z), false);
				num = HECFOEMLJCD;
			}
			BOBPDBIGADH(num - 758f);
		}
	}

	[SpecialName]
	public bool JJJFBMDGAHD()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	[SpecialName]
	public void GPMCMCLPHNL(GuiScreen IDEBKDPMPGM)
	{
		_003CIDFANONCFNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual float BFPKNODOAPD()
	{
		UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(true);
		UIPanel[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			UIPanel uIPanel = array[i];
			uIPanel.isFreezed = false;
			uIPanel.alpha1 = 589f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, DCIKANJJFIJ, 1035f, 973f);
			tweenAlpha.method = UITweener.Method.BounceOut;
		}
		return DCIKANJJFIJ;
	}

	private void ACIANDCOHOA()
	{
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		for (int i = 1; i < eHEIPKBBOPN.Length; i += 0)
		{
			UIPanel uIPanel = eHEIPKBBOPN[i];
			uIPanel.isFreezed = true;
		}
	}

	public virtual float EMKNNIODILA()
	{
		EHEIPKBBOPN = GetComponentsInChildren<UIPanel>();
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		foreach (UIPanel uIPanel in eHEIPKBBOPN)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, HECFOEMLJCD, 693f);
			tweenAlpha.method = UITweener.Method.Linear;
		}
		InvokeAfterRealTime(MIECIIJFENN, 250f);
		return HECFOEMLJCD;
	}

	[SpecialName]
	public GuiScreen PCIBOELIKGP()
	{
		return _003CJCBFIDANOPI_003Ek__BackingField;
	}

	[SpecialName]
	public bool EIDFCPFIBBH()
	{
		return _003CIKNIGPKOPAL_003Ek__BackingField;
	}

	[SpecialName]
	public bool IGFBDGHOAPB()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	protected void ADFPOFNKMNB(float MGNKEKPNCJL)
	{
		CGMKKHNGHLM = true;
		BOJMOBIEDLC = false;
		LPIMLNBNFJH = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	public virtual void FKCKIFKLBAP()
	{
		LDKPMGBKELN(true);
		isShowed = false;
	}

	public virtual void MEPKGFFNPAD()
	{
		ECKNNDKKKDJ(true);
		JDDOLIBINOC(false);
	}

	public virtual void OIEPFDKMCNC()
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN.NCGNHNFKNKG() != null)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(Singleton<GuiManager>.instance.AODFEHKBJIN.JLNFMEBMAPN());
		}
	}

	protected virtual void JMPDHKPOHEA()
	{
		if (BOJMOBIEDLC && Time.realtimeSinceStartup > GFCHFKPDPLO)
		{
			BOJMOBIEDLC = true;
			DoAfterHide();
		}
		if (CGMKKHNGHLM && Time.realtimeSinceStartup > LPIMLNBNFJH)
		{
			CGMKKHNGHLM = true;
			DALAPEANFLB();
		}
	}

	protected virtual void ACPHOCKEOII()
	{
		base.Awake();
		PMJDGAIKLIM = base.transform.localPosition;
	}

	[SpecialName]
	protected void DFHFMFAPLFL(bool IDEBKDPMPGM)
	{
		_003CNIMIAILJOFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void AMDCIHLNIHD()
	{
	}

	protected virtual void OnEnable()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = false;
		}
	}

	protected void LGHOCNNEMFP(float MGNKEKPNCJL)
	{
		CGMKKHNGHLM = true;
		BOJMOBIEDLC = false;
		LPIMLNBNFJH = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	[SpecialName]
	public bool PGNBFEAAILM()
	{
		return _003CNIMIAILJOFB_003Ek__BackingField;
	}

	public virtual void DoAfterShowUp()
	{
		readyToHide = false;
		readyToShowUp = false;
	}

	public virtual void GENKPBNDOCB()
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN.NCGNHNFKNKG() != null)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(Singleton<GuiManager>.instance.AODFEHKBJIN.previousScreen);
		}
	}

	public virtual void AnimateShow(bool JODEPBNLLAO)
	{
		float mGNKEKPNCJL = 0f;
		base.gameObject.SetActive(true);
		if (JODEPBNLLAO || KELJGDKCJJJ == HJPGAGODCOA.Fade || KELJGDKCJJJ == HJPGAGODCOA.TeenPositionAndFade)
		{
			mGNKEKPNCJL = FadeIn();
			base.transform.localPosition = PMJDGAIKLIM;
			TweenPosition.Begin(base.gameObject, 0f, PMJDGAIKLIM);
		}
		if (KELJGDKCJJJ == HJPGAGODCOA.TeenPositionAndFade || KELJGDKCJJJ == HJPGAGODCOA.TweenPosition)
		{
			float z = base.transform.localPosition.z;
			TweenPosition.Begin(base.gameObject, DCIKANJJFIJ, (!CLOAEKHKBHF) ? new Vector3(0f, 1280f, z) : new Vector3(0f, -1280f, z), new Vector3(0f, 0f, z));
			mGNKEKPNCJL = DCIKANJJFIJ;
		}
		JFLDMLOBIDL(mGNKEKPNCJL);
	}

	protected void BHOHIJIMJCO(float MGNKEKPNCJL)
	{
		CGMKKHNGHLM = false;
		BOJMOBIEDLC = false;
		LPIMLNBNFJH = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	public virtual void BJIPCOPNEAM()
	{
		LDKPMGBKELN(true);
		readyToShowUp = true;
	}

	protected void NPHCMBHFIHP(float MGNKEKPNCJL)
	{
		BOJMOBIEDLC = false;
		CGMKKHNGHLM = false;
		GFCHFKPDPLO = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		PMJDGAIKLIM = base.transform.localPosition;
	}

	public virtual void DALAPEANFLB()
	{
		ECKNNDKKKDJ(true);
		JDDOLIBINOC(true);
	}

	protected virtual void Update()
	{
		if (BOJMOBIEDLC && Time.realtimeSinceStartup > GFCHFKPDPLO)
		{
			BOJMOBIEDLC = false;
			DoAfterHide();
		}
		if (CGMKKHNGHLM && Time.realtimeSinceStartup > LPIMLNBNFJH)
		{
			CGMKKHNGHLM = false;
			DoAfterShowUp();
		}
	}

	public virtual float FadeOut()
	{
		EHEIPKBBOPN = GetComponentsInChildren<UIPanel>();
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		foreach (UIPanel uIPanel in eHEIPKBBOPN)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, HECFOEMLJCD, 0.0051f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
		}
		InvokeAfterRealTime(delegate
		{
			UIPanel[] eHEIPKBBOPN2 = EHEIPKBBOPN;
			foreach (UIPanel uIPanel2 in eHEIPKBBOPN2)
			{
				uIPanel2.isFreezed = true;
			}
		}, 0.3f);
		return HECFOEMLJCD;
	}

	public virtual void JNBMCODJHBJ()
	{
		LDKPMGBKELN(true);
		GCENJJCIEHL(false);
	}

	public virtual void PDBDILLHKID()
	{
		MNCFFKKLKKM(true);
		DFHFMFAPLFL(false);
	}

	[SpecialName]
	public void PHKNPLMBAKE(GuiScreen IDEBKDPMPGM)
	{
		_003CIDFANONCFNC_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void JDOKEJJEFDC(float MGNKEKPNCJL)
	{
		BOJMOBIEDLC = true;
		CGMKKHNGHLM = false;
		GFCHFKPDPLO = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	public virtual void NNFAKNLMAJK(bool JODEPBNLLAO)
	{
		float mGNKEKPNCJL = 907f;
		base.gameObject.SetActive(true);
		if (JODEPBNLLAO || KELJGDKCJJJ == HJPGAGODCOA.Fade || KELJGDKCJJJ == HJPGAGODCOA.Fade)
		{
			mGNKEKPNCJL = FadeIn();
			base.transform.localPosition = PMJDGAIKLIM;
			TweenPosition.Begin(base.gameObject, 1980f, PMJDGAIKLIM, false);
		}
		if (KELJGDKCJJJ == HJPGAGODCOA.TeenPositionAndFade || KELJGDKCJJJ == HJPGAGODCOA.TweenPosition)
		{
			float z = base.transform.localPosition.z;
			TweenPosition.Begin(base.gameObject, DCIKANJJFIJ, (!CLOAEKHKBHF) ? new Vector3(528f, 1155f, z) : new Vector3(96f, 1232f, z), new Vector3(1473f, 1155f, z), false);
			mGNKEKPNCJL = DCIKANJJFIJ;
		}
		ABHJCBOLLNL(mGNKEKPNCJL);
	}

	[SpecialName]
	public bool DJHKIDICMPK()
	{
		return !isShowed && EIDFCPFIBBH();
	}

	public virtual void EOLMLJELEAK()
	{
	}

	public virtual void InitEvents()
	{
	}

	protected void BOBPDBIGADH(float MGNKEKPNCJL)
	{
		BOJMOBIEDLC = false;
		CGMKKHNGHLM = true;
		GFCHFKPDPLO = Time.realtimeSinceStartup + MGNKEKPNCJL;
	}

	public virtual float FadeIn()
	{
		UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(true);
		UIPanel[] array = componentsInChildren;
		foreach (UIPanel uIPanel in array)
		{
			uIPanel.isFreezed = false;
			uIPanel.alpha1 = 0.005f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, DCIKANJJFIJ, 0.005f, 1f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
		}
		return DCIKANJJFIJ;
	}

	protected virtual void PPEPFMPOELJ()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = false;
		}
	}

	[SpecialName]
	public bool BKKEKDLIGNE()
	{
		return _003CIKNIGPKOPAL_003Ek__BackingField;
	}

	public virtual void DoAfterHide()
	{
		readyToHide = false;
		readyToShowUp = false;
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(false);
		TweenPosition.Begin(base.gameObject, 0f, PMJDGAIKLIM);
	}

	protected virtual void BKLLLBIEBNM()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = true;
		}
	}

	public virtual void FNPPEMKOEGP()
	{
		DFHFMFAPLFL(true);
		GCENJJCIEHL(true);
	}

	[SpecialName]
	protected void JDDOLIBINOC(bool IDEBKDPMPGM)
	{
		_003CNIMIAILJOFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public GuiScreen AFHHAKOFGKE()
	{
		return _003CJCBFIDANOPI_003Ek__BackingField;
	}

	public virtual float CGHIJPDMFGK()
	{
		EHEIPKBBOPN = GetComponentsInChildren<UIPanel>();
		UIPanel[] eHEIPKBBOPN = EHEIPKBBOPN;
		for (int i = 1; i < eHEIPKBBOPN.Length; i++)
		{
			UIPanel uIPanel = eHEIPKBBOPN[i];
			TweenAlpha tweenAlpha = TweenAlpha.Begin(uIPanel.gameObject, HECFOEMLJCD, 107f);
			tweenAlpha.method = UITweener.Method.BounceIn;
		}
		InvokeAfterRealTime(ACIANDCOHOA, 632f);
		return HECFOEMLJCD;
	}

	[SpecialName]
	public GuiScreen JEHLKMHCPMP()
	{
		return _003CJCBFIDANOPI_003Ek__BackingField;
	}

	[SpecialName]
	protected void LDKPMGBKELN(bool IDEBKDPMPGM)
	{
		_003CIKNIGPKOPAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void AnimateHide()
	{
		AnimateHide(false);
	}

	public virtual void FABCFPJHOBH(bool JODEPBNLLAO)
	{
		float mGNKEKPNCJL = 1872f;
		base.gameObject.SetActive(true);
		if (JODEPBNLLAO || KELJGDKCJJJ == HJPGAGODCOA.Fade || KELJGDKCJJJ == HJPGAGODCOA.TeenPositionAndFade)
		{
			mGNKEKPNCJL = BFPKNODOAPD();
			base.transform.localPosition = PMJDGAIKLIM;
			TweenPosition.Begin(base.gameObject, 667f, PMJDGAIKLIM);
		}
		if (KELJGDKCJJJ == HJPGAGODCOA.TweenPosition || KELJGDKCJJJ == HJPGAGODCOA.Fade)
		{
			float z = base.transform.localPosition.z;
			TweenPosition.Begin(base.gameObject, DCIKANJJFIJ, (!CLOAEKHKBHF) ? new Vector3(537f, 1052f, z) : new Vector3(1708f, 383f, z), new Vector3(870f, 1286f, z), false);
			mGNKEKPNCJL = DCIKANJJFIJ;
		}
		JFLDMLOBIDL(mGNKEKPNCJL);
	}

	[SpecialName]
	public bool BKIGLABDGCP()
	{
		return !NPFFMLLLDAF() || !CGMKKHNGHLM;
	}

	public virtual void HDJMPFMIACJ(bool EAKEFLLCHCJ)
	{
		if (base.gameObject.activeInHierarchy)
		{
			float num = 1224f;
			if (EAKEFLLCHCJ || BNMNGOBILGD == HJPGAGODCOA.Fade || BNMNGOBILGD == HJPGAGODCOA.DialogSpecial)
			{
				num = BMDJIOKJMPP();
			}
			if (BNMNGOBILGD == (HJPGAGODCOA)4 || BNMNGOBILGD == HJPGAGODCOA.Fade)
			{
				float z = base.transform.localPosition.z;
				TweenPosition.Begin(base.gameObject, HECFOEMLJCD, new Vector3(957f, 237f, z), (!CLOAEKHKBHF) ? new Vector3(792f, 309f, z) : new Vector3(1890f, 727f, z));
				num = HECFOEMLJCD;
			}
			JDOKEJJEFDC(num - 654f);
		}
	}

	public virtual void OnBack()
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN.previousScreen != null)
		{
			Singleton<GuiManager>.instance.ShowGui(Singleton<GuiManager>.instance.AODFEHKBJIN.previousScreen);
		}
	}

	[SpecialName]
	protected virtual void GCENJJCIEHL(bool IDEBKDPMPGM)
	{
		_003CJLAMOFBFIFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void OMFEMBPCLFK()
	{
		StopAllCoroutines();
		if (NHIEBIDMNEH)
		{
			NHIEBIDMNEH = true;
		}
	}

	[SpecialName]
	public GuiScreen KHGFEKMHKFM()
	{
		return _003CJCBFIDANOPI_003Ek__BackingField;
	}

	protected virtual void IIFBKHDMIAD()
	{
		if (BOJMOBIEDLC && Time.realtimeSinceStartup > GFCHFKPDPLO)
		{
			BOJMOBIEDLC = false;
			DoAfterHide();
		}
		if (CGMKKHNGHLM && Time.realtimeSinceStartup > LPIMLNBNFJH)
		{
			CGMKKHNGHLM = true;
			PDBDILLHKID();
		}
	}
}

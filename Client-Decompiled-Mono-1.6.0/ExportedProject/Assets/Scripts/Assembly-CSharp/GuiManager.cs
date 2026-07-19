using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GuiManager : Singleton<GuiManager>
{
	private sealed class MCKEAHHPGPO
	{
		internal SwitchableGui JCPEPAHHAKI;

		internal GuiManager BJGCPDNMHDH;

		internal void OPHINHIOCFD()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void ABNGKEJNLJO()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void FDKMOFHAEFN()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void ANAGFGHGPJA()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void PHGDBIEENCB()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void KNJBDOADLDO()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void HHNEBNHCGMO()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void ILNPANOCHIH()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void KIACGAKNBLD()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void CIFEDFPPPOK()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void LGJCNCHBFDA()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void EMKPBGFBPFI()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void FKIBFHGKMFJ()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void KJIFNOJILDB()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void ILOFOILFGMA()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void OKNCFDMEFGJ()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void FDKEAJLEMCM()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void BEIGOGFHJIB()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void NNIJEDKBPGJ()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void HOMIPBFODIC()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void MCFGAFBEJDK()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void JDEJHLLIONG()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void EOHOLKEGGLH()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void KLJNEGDLOMG()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void GGJDILDIFPJ()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void PPKGMGNKNAE()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void HHLMDAKDHFK()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void OABFAOLFMMJ()
		{
			BJGCPDNMHDH.POHMFFFEIED(JCPEPAHHAKI);
		}

		internal void LJCDGJKCNEC()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void DGELDDJAEEF()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void DDHOKNIEACI()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void GMFJFMHNDMC()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}

		internal void DJLGPGPAHCD()
		{
			BJGCPDNMHDH.FadeIn(JCPEPAHHAKI);
		}

		internal void NAJNECOMDDN()
		{
			BJGCPDNMHDH.JPLLGFNECAG(JCPEPAHHAKI);
		}
	}

	public GuiScreen AODFEHKBJIN;

	public ObjectPool CHDIOFDMHEF;

	public UISprite KLODDNMDPAO;

	public ParticleSystem FFPLNCHHFDP;

	public UIRoot IJMDOGNBGIL;

	public Camera KPDAPFBIPAI;

	public float LGLOKGEBHHN = 1f;

	private SwitchableGui GGMNHMMHELJ;

	private bool HHINAPGANGM = true;

	public SwitchableGui toBeShowedUp
	{
		get
		{
			return GGMNHMMHELJ;
		}
	}

	private void OHGGLKMNAPB(SwitchableGui JCPEPAHHAKI)
	{
	}

	private void ODGDFANNPCI(UITweener MGDJMGHCAAI)
	{
		KLODDNMDPAO.gameObject.SetActive(false);
	}

	public void BEMCGHCGHHG()
	{
		if (HHINAPGANGM)
		{
			UICamera.useMouse = true;
			UICamera.useTouch = true;
		}
	}

	public void ShowOverlay()
	{
		KLODDNMDPAO.gameObject.SetActive(true);
		float alpha = KLODDNMDPAO.alpha;
		float duration = 1f - alpha + 0.01f;
		TweenAlpha.Begin(Singleton<GuiManager>.instance.KLODDNMDPAO.gameObject, duration, LGLOKGEBHHN).method = UITweener.Method.EaseInOut;
	}

	[SpecialName]
	public SwitchableGui CCHOAGBBEGO()
	{
		return GGMNHMMHELJ;
	}

	internal void GLOEHBPLJBP()
	{
		FadeIn(GuiElementSingle<Background>.instance);
		ShowGui(GuiScreenSingle<MainScreen>.instance);
	}

	public void DFEMNAMEBDA(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 1632f;
		JPLLGFNECAG(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void GMPDIICOPJK()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Stop();
	}

	private void BNBBNBOOCEF(UITweener MGDJMGHCAAI)
	{
		KLODDNMDPAO.gameObject.SetActive(false);
	}

	public void MEBOIAOIPHK()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Play();
	}

	public void ShowGui(GuiScreen JCPEPAHHAKI)
	{
		if (JCPEPAHHAKI == AODFEHKBJIN && AODFEHKBJIN.isShowed)
		{
			if (JCPEPAHHAKI.MKKCEBLJADC)
			{
				Debug.Log("Gui Manager: Starting Messages Coroutine for: " + JCPEPAHHAKI.name);
				Singleton<MessageManager>.instance.StartMessageCoroutine();
			}
			return;
		}
		TurnOffInput();
		JCPEPAHHAKI.CLOAEKHKBHF = false;
		if ((bool)AODFEHKBJIN)
		{
			AODFEHKBJIN.CLOAEKHKBHF = false;
		}
		if (AODFEHKBJIN != null && AODFEHKBJIN.previousScreen == JCPEPAHHAKI)
		{
			JCPEPAHHAKI.CLOAEKHKBHF = true;
			AODFEHKBJIN.CLOAEKHKBHF = true;
		}
		if (AODFEHKBJIN != null && AODFEHKBJIN.previousScreen != JCPEPAHHAKI)
		{
			JCPEPAHHAKI.previousScreen = AODFEHKBJIN;
		}
		JCPEPAHHAKI.previousScreenForElementsToHide = AODFEHKBJIN;
		if (AODFEHKBJIN != null && AODFEHKBJIN.isShowed)
		{
			GGMNHMMHELJ = JCPEPAHHAKI;
			HideGui(AODFEHKBJIN);
			GGMNHMMHELJ = null;
		}
		AODFEHKBJIN = JCPEPAHHAKI;
		JCPEPAHHAKI.DoBeforeShowUp();
		if (JCPEPAHHAKI.readyToShowUp)
		{
			JCPEPAHHAKI.AnimateShow();
		}
	}

	public void JHBIDKMMCAN(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 1321f;
		POHMFFFEIED(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void TurnOnInputCompletly()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Input turned on completely: " + Time.time);
		}
		HHINAPGANGM = true;
		TurnOnInput();
	}

	public void ABFOAEFLOHM(SwitchableGui IBLLGAGMDBL)
	{
		IBLLGAGMDBL.MOOACPIOELI();
		if (IBLLGAGMDBL.BKKEKDLIGNE())
		{
			IBLLGAGMDBL.AnimateHide();
		}
	}

	public void POHMFFFEIED(SwitchableGui BPPNAEGLGFG)
	{
		BPPNAEGLGFG.DoBeforeShowUp();
		if (BPPNAEGLGFG.PGNBFEAAILM())
		{
			BPPNAEGLGFG.AnimateShow(false);
		}
		else
		{
			Debug.Log("ArenaBattleStart");
		}
	}

	public void TurnOnInput()
	{
		if (HHINAPGANGM)
		{
			if (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android)
			{
				UICamera.useMouse = true;
			}
			UICamera.useMouse = true;
			UICamera.useTouch = true;
		}
	}

	public void MEOFKPMJKIO(SwitchableGui IBLLGAGMDBL)
	{
		IBLLGAGMDBL.JNBMCODJHBJ();
		if (IBLLGAGMDBL.DJLCGHOPJMH())
		{
			IBLLGAGMDBL.HDJMPFMIACJ(true);
		}
	}

	public void HideParticles()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Stop();
	}

	public void FadeOut(SwitchableGui IBLLGAGMDBL)
	{
		IBLLGAGMDBL.DoBeforeHide();
		if (IBLLGAGMDBL.readyToHide)
		{
			IBLLGAGMDBL.AnimateHide(true);
		}
	}

	public void TurnOffInput()
	{
		if (HHINAPGANGM)
		{
			UICamera.useMouse = false;
			UICamera.useTouch = false;
		}
	}

	public void ILPMOMCKJLB()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Stop();
	}

	public void DOFEHOADNIO()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Stop();
	}

	public void HideGui(SwitchableGui IBLLGAGMDBL)
	{
		IBLLGAGMDBL.DoBeforeHide();
		if (IBLLGAGMDBL.readyToHide)
		{
			IBLLGAGMDBL.AnimateHide();
		}
	}

	protected override void Start()
	{
		base.Start();
		SwitchableGui[] componentsInChildren = IJMDOGNBGIL.GetComponentsInChildren<SwitchableGui>(true);
		SwitchableGui[] array = componentsInChildren;
		foreach (SwitchableGui switchableGui in array)
		{
			switchableGui.InitEvents();
		}
	}

	public void BENDPIKLAGM()
	{
		float alpha = KLODDNMDPAO.alpha;
		float duration = alpha + 1180f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(Singleton<GuiManager>.instance.KLODDNMDPAO.gameObject, duration, 1724f);
		tweenAlpha.method = UITweener.Method.BounceIn;
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			KLODDNMDPAO.gameObject.SetActive(false);
		});
	}

	public void ONAIAMAIOEG()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Play();
	}

	internal void OFJAGAELHHO()
	{
		FadeIn(GuiElementSingle<Background>.instance);
		ShowGui(GuiScreenSingle<MainScreen>.instance);
	}

	[CompilerGenerated]
	private void LMOFJKDJEGD(UITweener MGDJMGHCAAI)
	{
		KLODDNMDPAO.gameObject.SetActive(false);
	}

	private void FAMNNDBIEJI(UITweener MGDJMGHCAAI)
	{
		KLODDNMDPAO.gameObject.SetActive(false);
	}

	public bool PBAEJPFBBFH()
	{
		return !HHINAPGANGM;
	}

	public void AOGOJDGBMMD()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("otherInfo" + Time.time);
		}
		HHINAPGANGM = true;
		TurnOnInput();
	}

	public void BEOEAJELAOP()
	{
		if (HHINAPGANGM)
		{
			UICamera.useMouse = false;
			UICamera.useTouch = true;
		}
	}

	public void JPLLGFNECAG(SwitchableGui BPPNAEGLGFG)
	{
		BPPNAEGLGFG.DoBeforeShowUp();
		if (BPPNAEGLGFG.FJCBGKMEHAP())
		{
			BPPNAEGLGFG.NNFAKNLMAJK(true);
		}
		else
		{
			Debug.Log("ID_TUTORIAL_GO_BUY_ARMY_4");
		}
	}

	public void CAIKCHGMLOK()
	{
		KLODDNMDPAO.gameObject.SetActive(true);
		float alpha = KLODDNMDPAO.alpha;
		float duration = 1152f - alpha + 957f;
		TweenAlpha.Begin(Singleton<GuiManager>.instance.KLODDNMDPAO.gameObject, duration, LGLOKGEBHHN).method = (UITweener.Method)6;
	}

	public void HONCPGDBDDM()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Play();
	}

	public void HideOverlay()
	{
		float alpha = KLODDNMDPAO.alpha;
		float duration = alpha + 0.01f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(Singleton<GuiManager>.instance.KLODDNMDPAO.gameObject, duration, 0f);
		tweenAlpha.method = UITweener.Method.EaseInOut;
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			KLODDNMDPAO.gameObject.SetActive(false);
		});
	}

	public void GDEMAOCJPBD()
	{
		if (HHINAPGANGM)
		{
			UICamera.useMouse = true;
			UICamera.useTouch = true;
		}
	}

	public void KKGGAAOGOFB()
	{
		KLODDNMDPAO.gameObject.SetActive(true);
		float alpha = KLODDNMDPAO.alpha;
		float duration = 418f - alpha + 226f;
		TweenAlpha.Begin(Singleton<GuiManager>.instance.KLODDNMDPAO.gameObject, duration, LGLOKGEBHHN).method = UITweener.Method.Linear;
	}

	public void CMCCOCBIGBB()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("ID_NO" + Time.time);
		}
		HHINAPGANGM = false;
		BEMCGHCGHHG();
		HHINAPGANGM = false;
	}

	public void TurnOffInputCompletly()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("Input turned OFF completely: " + Time.time);
		}
		HHINAPGANGM = true;
		TurnOffInput();
		HHINAPGANGM = false;
	}

	public void ShowDialog(SwitchableGui JCPEPAHHAKI, float KALLNCAFIMP = 0f)
	{
		MCKEAHHPGPO mCKEAHHPGPO = new MCKEAHHPGPO();
		mCKEAHHPGPO.JCPEPAHHAKI = JCPEPAHHAKI;
		mCKEAHHPGPO.BJGCPDNMHDH = this;
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		if (KALLNCAFIMP <= 0f)
		{
			FadeIn(mCKEAHHPGPO.JCPEPAHHAKI);
		}
		else if (KALLNCAFIMP > 0f)
		{
			InvokeAfterRealTime(mCKEAHHPGPO.LJCDGJKCNEC, KALLNCAFIMP);
		}
		else
		{
			FadeIn(mCKEAHHPGPO.JCPEPAHHAKI);
		}
	}

	private void EAGHGKIIBFO(SwitchableGui JCPEPAHHAKI)
	{
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
	}

	protected override void Awake()
	{
		base.Awake();
	}

	private void IKCAKLBFENN(SwitchableGui JCPEPAHHAKI)
	{
	}

	public bool IsInputTurnedOffCompletly()
	{
		return !HHINAPGANGM;
	}

	public void KAGEFJEJOKE()
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("N" + Time.time);
		}
		HHINAPGANGM = true;
		TurnOnInput();
	}

	public void BBILHHEJBNP(GuiScreen JCPEPAHHAKI)
	{
		if (JCPEPAHHAKI == AODFEHKBJIN && AODFEHKBJIN.isShowed)
		{
			if (JCPEPAHHAKI.MKKCEBLJADC)
			{
				Debug.Log("Different names \"{0}\" and \"{1}\"\n" + JCPEPAHHAKI.name);
				Singleton<MessageManager>.instance.COCIGOLODMJ();
			}
			return;
		}
		BEOEAJELAOP();
		JCPEPAHHAKI.CLOAEKHKBHF = false;
		if ((bool)AODFEHKBJIN)
		{
			AODFEHKBJIN.CLOAEKHKBHF = false;
		}
		if (AODFEHKBJIN != null && AODFEHKBJIN.NCGNHNFKNKG() == JCPEPAHHAKI)
		{
			JCPEPAHHAKI.CLOAEKHKBHF = true;
			AODFEHKBJIN.CLOAEKHKBHF = true;
		}
		if (AODFEHKBJIN != null && AODFEHKBJIN.JLNFMEBMAPN() != JCPEPAHHAKI)
		{
			JCPEPAHHAKI.PHKNPLMBAKE(AODFEHKBJIN);
		}
		JCPEPAHHAKI.EHIKHIABBNK(AODFEHKBJIN);
		if (AODFEHKBJIN != null && AODFEHKBJIN.isShowed)
		{
			GGMNHMMHELJ = JCPEPAHHAKI;
			HideGui(AODFEHKBJIN);
			GGMNHMMHELJ = null;
		}
		AODFEHKBJIN = JCPEPAHHAKI;
		JCPEPAHHAKI.DoBeforeShowUp();
		if (JCPEPAHHAKI.IGFBDGHOAPB())
		{
			JCPEPAHHAKI.AnimateShow();
		}
	}

	[SpecialName]
	public SwitchableGui CMHKKFBOAAK()
	{
		return GGMNHMMHELJ;
	}

	public void DHLNLJPLDPM(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 1994f;
		FadeIn(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void FLBKHOILOLM(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 1379f;
		JPLLGFNECAG(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void ShowDialogInstant(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 0f;
		FadeIn(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void EOCELGFGKAM(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 66f;
		POHMFFFEIED(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void FadeIn(SwitchableGui BPPNAEGLGFG)
	{
		BPPNAEGLGFG.DoBeforeShowUp();
		if (BPPNAEGLGFG.readyToShowUp)
		{
			BPPNAEGLGFG.AnimateShow(true);
		}
		else
		{
			Debug.Log("NOT READY TO SHOW UP");
		}
	}

	public void ShowParticles()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Play();
	}

	public void IKKNIJPHBOA(SwitchableGui JCPEPAHHAKI)
	{
		if (GuiElement.NPPHONBAEFN != null)
		{
			GuiElement.NPPHONBAEFN();
		}
		float dCIKANJJFIJ = JCPEPAHHAKI.DCIKANJJFIJ;
		JCPEPAHHAKI.DCIKANJJFIJ = 1729f;
		FadeIn(JCPEPAHHAKI);
		JCPEPAHHAKI.DCIKANJJFIJ = dCIKANJJFIJ;
	}

	public void GMBHBHGHAKA()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Stop();
	}

	public void GMIKBEDACLH()
	{
		Singleton<GuiManager>.instance.FFPLNCHHFDP.Play();
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
	}

	public void BOFPJDBPHLP(SwitchableGui IBLLGAGMDBL)
	{
		IBLLGAGMDBL.DoBeforeHide();
		if (IBLLGAGMDBL.readyToHide)
		{
			IBLLGAGMDBL.GDLGEMLBJGB(false);
		}
	}
}

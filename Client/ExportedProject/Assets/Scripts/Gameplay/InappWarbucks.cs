using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InappWarbucks : Core_BaseScript
{
	private sealed class HAJEIGIFBOO
	{
		internal bool PJIEFMBDLBE;

		internal InappWarbucks BJGCPDNMHDH;

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.CGPFPNNICIO();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK();
			}
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK(PDPDGCNHCFN: true);
			}
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.DKCOOAKKFKD();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK(PDPDGCNHCFN: true);
			}
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.CGPFPNNICIO();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO();
			}
		}

		internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.MHIGAEFCIAF();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK();
			}
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.MHIGAEFCIAF();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO();
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO();
			}
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.AHDJEJIKCAB();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK(PDPDGCNHCFN: true);
			}
		}

		internal void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.DKCOOAKKFKD();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK(PDPDGCNHCFN: true);
			}
		}

		internal void AMIJFGBOCLC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.AHDJEJIKCAB();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO(PDPDGCNHCFN: true);
			}
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.AHDJEJIKCAB();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK(PDPDGCNHCFN: true);
			}
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.DBMCMLINOPD();
			}
			else
			{
				BJGCPDNMHDH.DFGNJKMFGGK();
			}
		}
	}

	[Header("Core")]
	[FormerlySerializedAs("PEPKAHPAKGP")]
	public GameObject NINDIKFKGML;

	[FormerlySerializedAs("CJDANCOGIIP")]
	public GameObject BPGMFANIHNG;

	[FormerlySerializedAs("GDJGGIOPBEN")]
	public WarbucksButtonRecord[] CBKJJDMLEEM;

	[FormerlySerializedAs("ENMNKEOHAAD")]
	public WarbucksButtonRecord CGMPHMLAJFB;

	[FormerlySerializedAs("LJEIILMJBCO")]
	public UIPanel POOGLLBHFMP;

	[FormerlySerializedAs("GLKHBFOGJHI")]
	public UIDraggablePanel KFMEGNMFNPI;

	[FormerlySerializedAs("ECCNJBCFFIL")]
	public UIPanel[] NICJILKEIEG;

	public void InstantHideTab()
	{
		TweenAlpha component = POOGLLBHFMP.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		PPMCFMBJJHP();
	}

	private void HHJDKKFKKIL()
	{
		int i;
		for (i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].HOAMHAAHEHP(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.JMPLLJLLPHK(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		EOFCOOINNEO(PDPDGCNHCFN: true);
	}

	private void JJPOHBPKALI(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!NABOFKMBMKH) ? 0f : 1f);
			}
		}
	}

	public void EFKFHFNAOHA()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKJJDMLEEM[i].KNPBHLANFBK));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGMPHMLAJFB.GJOHPCMGEOG));
		Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.ProductLoadedAndComputed += AOJAGOCAGJN;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	public void OBLGPLAHNNM()
	{
		TweenAlpha component = POOGLLBHFMP.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(value: true);
		PPMCFMBJJHP();
	}

	public void DPGLPPFEOHO(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			IHLGGCNHCDG();
		}
		if (base.gameObject.activeSelf)
		{
			EFIEDCDMBFJ(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(POOGLLBHFMP.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 509f) : 1640f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1462f : 1361f).onFinished = hAJEIGIFBOO.ECPMEMNKMCB;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	public void BCLAFFCPCEH()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKJJDMLEEM[i].ButtonClicked));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGMPHMLAJFB.LBLLKGFJOCA));
		Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.ProductLoadedAndComputed += HFMDLOKKLEG;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void PMBPAOLBLFA()
	{
		int i;
		for (i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].Initialize(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.Initialize(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		EOFCOOINNEO(PDPDGCNHCFN: true);
	}

	private void DBMCMLINOPD()
	{
	}

	private void MHIGAEFCIAF()
	{
	}

	private void CJNKMHINPJD(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1600f) : 610f, (!NABOFKMBMKH) ? 378f : 1964f);
			}
		}
	}

	private void DOLLFDPMGOD()
	{
		int i;
		for (i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].KCJFKOKGAMO(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.KCJFKOKGAMO(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		DFGNJKMFGGK();
	}

	private void LMNNNHJKMFP()
	{
		int i;
		for (i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].JMPLLJLLPHK(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.AGMMBHKPBPM(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		EOFCOOINNEO(PDPDGCNHCFN: true);
	}

	public void HBIKDPNHHEG(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			LMNNNHJKMFP();
		}
		if (base.gameObject.activeSelf)
		{
			CJNKMHINPJD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(POOGLLBHFMP.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1819f) : 568f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1140f : 399f).onFinished = hAJEIGIFBOO.ECPMEMNKMCB;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			OMONPJKJJJM();
		}
	}

	private void CGPFPNNICIO()
	{
	}

	private void DKCOOAKKFKD()
	{
	}

	private void KDDJHIMDKBN()
	{
		int i;
		for (i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].ANMJHOFBIAI(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.GJEEMJNIFFM(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		DFGNJKMFGGK();
	}

	private void IHLGGCNHCDG()
	{
		int i;
		for (i = 1; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].AGMMBHKPBPM(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.MFMJPBCIHEH(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		DFGNJKMFGGK();
	}

	private void JCLBIBAHLGC()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			PMBPAOLBLFA();
		}
	}

	public void GFLLEMCAJGN()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKJJDMLEEM[i].MFMGDFEJFMD));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGMPHMLAJFB.KNPBHLANFBK));
		Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.ProductLoadedAndComputed += KBOCLIJOFOH;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	public void OMONPJKJJJM()
	{
		TweenAlpha component = POOGLLBHFMP.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		DKCOOAKKFKD();
	}

	private void DABIKOHOFBB(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1935f) : 427f, (!NABOFKMBMKH) ? 1993f : 997f);
			}
		}
	}

	public void HFNCDOAGONP(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			CJNKMHINPJD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(POOGLLBHFMP.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1522f) : 390f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1530f : 1194f).onFinished = hAJEIGIFBOO.ECPMEMNKMCB;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	public void InitControls()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKJJDMLEEM[i].ButtonClicked));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGMPHMLAJFB.ButtonClicked));
		Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.ProductLoadedAndComputed += JCLBIBAHLGC;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void OGKFDFILIBI(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 716f) : 1803f, (!NABOFKMBMKH) ? 1741f : 1583f);
			}
		}
	}

	private void HFMDLOKKLEG()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			LMNNNHJKMFP();
		}
	}

	private void CGBFFHNCOPD()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			HHJDKKFKKIL();
		}
	}

	private void EOFCOOINNEO(bool PDPDGCNHCFN = false)
	{
		KFMEGNMFNPI.AlignToPos(PDPDGCNHCFN);
	}

	public void PEPFALDMHLH(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			CJNKMHINPJD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(POOGLLBHFMP.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1191f) : 1389f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1456f : 1316f).onFinished = hAJEIGIFBOO.KJIFNOJILDB;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	private void JCIBDJMFOLI()
	{
		int i;
		for (i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].PEIPCPICOIK(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		}
		CGMPHMLAJFB.Initialize(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksInAppDefinitions[i]);
		EOFCOOINNEO(PDPDGCNHCFN: true);
	}

	public void HJJOAJHBKCH()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKJJDMLEEM[i].ButtonClicked));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGMPHMLAJFB.MFMGDFEJFMD));
		Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.ProductLoadedAndComputed += CGBFFHNCOPD;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	public void INBJGJOFJMK()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKJJDMLEEM[i].MFMGDFEJFMD));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CGMPHMLAJFB.KNPBHLANFBK));
		Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.ProductLoadedAndComputed += CGBFFHNCOPD;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void AOJAGOCAGJN()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			IHLGGCNHCDG();
		}
	}

	private void AHDJEJIKCAB()
	{
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			JJPOHBPKALI(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(POOGLLBHFMP.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	public void HKDCHMLHKEB(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			DABIKOHOFBB(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(POOGLLBHFMP.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 550f) : 1030f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 616f : 849f).onFinished = hAJEIGIFBOO.NDJOJHNIBFC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			OBLGPLAHNNM();
		}
	}

	private void DFGNJKMFGGK(bool PDPDGCNHCFN = false)
	{
		KFMEGNMFNPI.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void IMMJJKPJOGK()
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			HHJDKKFKKIL();
		}
	}

	private void EFIEDCDMBFJ(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1491f) : 1716f, (!NABOFKMBMKH) ? 1682f : 490f);
			}
		}
	}

	private void KBOCLIJOFOH()
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			JCIBDJMFOLI();
		}
	}

	private void PPMCFMBJJHP()
	{
	}
}

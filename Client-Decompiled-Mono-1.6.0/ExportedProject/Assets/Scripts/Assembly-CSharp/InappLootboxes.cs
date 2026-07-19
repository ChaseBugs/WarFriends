using System;
using UnityEngine;

public class InappLootboxes : Core_BaseScript
{
	private sealed class HAJEIGIFBOO
	{
		internal bool PJIEFMBDLBE;

		internal InappLootboxes BJGCPDNMHDH;

		internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
			else
			{
				BJGCPDNMHDH.CKONFJBHNDL();
			}
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.AKPHBJHGBKF();
			}
			else
			{
				BJGCPDNMHDH.HGGOBMNLBIJ();
			}
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.BMEBFFLHGME();
			}
			else
			{
				BJGCPDNMHDH.DIAPOHCJGOK();
			}
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.BGIMHNPAMPP();
			}
			else
			{
				BJGCPDNMHDH.HDBKEMNLOJD(true);
			}
		}

		internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.MMLOAKGDDGF();
			}
			else
			{
				BJGCPDNMHDH.CKONFJBHNDL(true);
			}
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.BGIMHNPAMPP();
			}
			else
			{
				BJGCPDNMHDH.CKONFJBHNDL();
			}
		}

		internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.FNMPBHIIEJP();
			}
			else
			{
				BJGCPDNMHDH.HGGOBMNLBIJ();
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO();
			}
		}

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.BMEBFFLHGME();
			}
			else
			{
				BJGCPDNMHDH.CKONFJBHNDL();
			}
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.NMHMFDOFDBC();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO(true);
			}
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO();
			}
		}

		internal void BDCAFHOHEGM(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.BMEBFFLHGME();
			}
			else
			{
				BJGCPDNMHDH.HDBKEMNLOJD();
			}
		}

		internal void KNJBDOADLDO(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(false);
				BJGCPDNMHDH.MMLOAKGDDGF();
			}
			else
			{
				BJGCPDNMHDH.CKONFJBHNDL();
			}
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(true);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.HGGOBMNLBIJ(true);
			}
		}
	}

	[Header("Core")]
	public GameObject NINDIKFKGML;

	public GameObject BPGMFANIHNG;

	public UIPanel ILKPDBKMAGE;

	public UIDraggablePanel PIDCGBIALAD;

	public UIPanel[] NICJILKEIEG;

	[Header("Buttons")]
	public LootboxButtonRecord[] CBKJJDMLEEM;

	public LootboxButtonRecord CGMPHMLAJFB;

	public void LHDAGAGDKOM()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KBGPHPHECAG));
			CBKJJDMLEEM[i].InitControls();
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DLMIHKICPHA));
		CGMPHMLAJFB.NMECMIDEKPC();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<OfferManager>.instance.SalesChanged += KHFKFJBLGDI;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void BNNJMPIHNCD(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1299f) : 1222f, (!NABOFKMBMKH) ? 1346f : 433f);
			}
		}
	}

	private void DKAAJKFNBCK(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight);
	}

	private void MNAMKJCJNBB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-77))
		{
			JEAOCIFPIGD();
		}
	}

	private void PNLGFNBEOLG()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].MKENDIKJPLJ(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[i]);
		}
		CGMPHMLAJFB.EDKFKNGLLBM(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[CBKJJDMLEEM.Length]);
		IAACPODIAIK();
		HJDNGDGCAKO(true);
	}

	private void FIOJBBDFPAJ(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 685f) : 160f, (!NABOFKMBMKH) ? 179f : 790f);
			}
		}
	}

	private void EIDHGBCKEEP(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 472f) : 1026f, (!NABOFKMBMKH) ? 1419f : 579f);
			}
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == DatabaseAction.BuyLootboxes)
		{
			JEAOCIFPIGD();
		}
	}

	private void PPCJOPCIGNH(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-54))
		{
			ODGELJKJKCN();
		}
	}

	private void NEHGGNGBHLE(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf)
		{
			ODGELJKJKCN();
		}
	}

	private void GCPDEEPCBOF()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].BMNHEMLGGMO(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[i]);
		}
		CGMPHMLAJFB.CMOHGKPENIJ(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[CBKJJDMLEEM.Length]);
		PGLJEJMOOJC();
		HJDNGDGCAKO(true);
	}

	private void NFNMLPPDPAP()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].OJPOIMGDBMN(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[i]);
		}
		CGMPHMLAJFB.NGCPBGOBMLE(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[CBKJJDMLEEM.Length]);
		NBLEHOGBPFA();
		DKAAJKFNBCK();
	}

	private void HDBKEMNLOJD(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight, true);
	}

	private void ODGELJKJKCN()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].CAAGDCDACMA();
		}
		CGMPHMLAJFB.DJKJKHMEPOM();
	}

	public void PFKNDAPDAMC(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(false);
			GCPDEEPCBOF();
		}
		if (base.gameObject.activeSelf)
		{
			JJPOHBPKALI(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(ILKPDBKMAGE.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1734f) : 1000f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 516f : 1492f).onFinished = hAJEIGIFBOO.OKNCFDMEFGJ;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			NACHKOLMLAA();
		}
	}

	private void HGGOBMNLBIJ(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN);
	}

	private void LHNFCBAHJPO()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].JCMLOCHINJG();
		}
		CGMPHMLAJFB.HCBICMCFFFG();
	}

	private void IOKGJJIJCBO()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].BEOKODLBKEO();
		}
		CGMPHMLAJFB.HEKLHELLAOC();
	}

	private void EOFCOOINNEO(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN);
	}

	private void JEAOCIFPIGD()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].InitializePurchaseProtection();
		}
		CGMPHMLAJFB.InitializePurchaseProtection();
	}

	public void NACHKOLMLAA()
	{
		TweenAlpha component = ILKPDBKMAGE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(true);
		NMHMFDOFDBC();
	}

	private void CDNFKJFMFMJ()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			IAACPODIAIK();
		}
	}

	private void MAKHMMCNIBH()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].CAAGDCDACMA();
		}
		CGMPHMLAJFB.PDDPFLEBKPA();
	}

	private void HMHDLJIIJKC(GameObject KHAHPAKDIKE)
	{
		LootboxButtonRecord component = KHAHPAKDIKE.GetComponent<LootboxButtonRecord>();
		if (component != null)
		{
			int num = component.FKLOCPFFLKC();
			int dBOLKNNJGMH = component.JCAFPKOKOPO();
			if (Singleton<Wallet>.instance.CanBuyGold(num))
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGamePhotoSound, 73f);
				Singleton<PurchaseProtection>.instance.HHOFINCBLCM(component.ODHBLDCAMDF());
				HLIDNLNIPOC();
				Singleton<BeanstalkServerManager>.instance.FCCLNIOHOPK(component.NPIPDOIMEAM(), num, dBOLKNNJGMH);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num, Localization.Localize("memoryWarnings"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
		}
		else
		{
			Debug.LogError("#VOJTA# WAR ARENA CONFIG RECEIVED! Id = " + KHAHPAKDIKE.name);
		}
	}

	private void CKONFJBHNDL(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN);
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

	private void CJNKMHINPJD(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 133f) : 481f, (!NABOFKMBMKH) ? 148f : 1548f);
			}
		}
	}

	private void BHKGKEDJNOB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-93))
		{
			CGAMLDJFPHG();
		}
	}

	public void NHLBCFPFHED()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CIBEFANEFDD));
			CBKJJDMLEEM[i].IMPMPKNJICB();
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KHGCJGHOHLO));
		CGMPHMLAJFB.IMPMPKNJICB();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PPCJOPCIGNH);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += NEHGGNGBHLE;
		Singleton<OfferManager>.instance.SalesChanged += CDNFKJFMFMJ;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void OLGMEJAAFCN()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].SetSaleAndPrize();
		}
		CGMPHMLAJFB.SetSaleAndPrize();
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf)
		{
			JEAOCIFPIGD();
		}
	}

	private void PMBPAOLBLFA()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].Initialize(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[i]);
		}
		CGMPHMLAJFB.Initialize(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.lootboxesDefinitions[CBKJJDMLEEM.Length]);
		OLGMEJAAFCN();
		EOFCOOINNEO(true);
	}

	public void OBLGPLAHNNM()
	{
		TweenAlpha component = ILKPDBKMAGE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(true);
		BGIMHNPAMPP();
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			JJPOHBPKALI(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(ILKPDBKMAGE.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	private void PGLJEJMOOJC()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].SetSaleAndPrize();
		}
		CGMPHMLAJFB.PDONJHNPCCN();
	}

	private void BGIMHNPAMPP()
	{
	}

	public void PAKBMJBJDNI(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			PNLGFNBEOLG();
		}
		if (base.gameObject.activeSelf)
		{
			CKPILANBPOF(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(ILKPDBKMAGE.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 32f) : 772f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1625f : 791f).onFinished = hAJEIGIFBOO.NNIJEDKBPGJ;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	private void CGAMLDJFPHG()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].ELBAFNBMCKH();
		}
		CGMPHMLAJFB.DJKJKHMEPOM();
	}

	private void DIIJGPIEOJO()
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			NBLEHOGBPFA();
		}
	}

	public void InstantHideTab()
	{
		TweenAlpha component = ILKPDBKMAGE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(false);
		PPMCFMBJJHP();
	}

	private void KHFKFJBLGDI()
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			PGLJEJMOOJC();
		}
	}

	private void MMLOAKGDDGF()
	{
	}

	private void CKPILANBPOF(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 970f) : 51f, (!NABOFKMBMKH) ? 1933f : 255f);
			}
		}
	}

	private void ENCIECLPFEJ()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			OLGMEJAAFCN();
		}
	}

	private void IAACPODIAIK()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].HHAPJLKDKPA();
		}
		CGMPHMLAJFB.SetSaleAndPrize();
	}

	public void DOMDAJKLILC(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			NFNMLPPDPAP();
		}
		if (base.gameObject.activeSelf)
		{
			CKPILANBPOF(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(ILKPDBKMAGE.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1499f) : 808f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 472f : 82f).onFinished = hAJEIGIFBOO.KNJBDOADLDO;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			NCJHEGOCPCL();
		}
	}

	public void PGHAMCBHBOD()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DLMIHKICPHA));
			CBKJJDMLEEM[i].AFMPBPGLFMJ();
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CIBEFANEFDD));
		CGMPHMLAJFB.CEFNAJLGCIJ();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LOKKCEFHDKL;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<OfferManager>.instance.SalesChanged += LHNIFHMNHOC;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void CIBEFANEFDD(GameObject KHAHPAKDIKE)
	{
		LootboxButtonRecord component = KHAHPAKDIKE.GetComponent<LootboxButtonRecord>();
		if (component != null)
		{
			int num = component.JBGACAKPDEC();
			int dBOLKNNJGMH = component.JCAFPKOKOPO();
			if (Singleton<Wallet>.instance.CanBuyGold(num))
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)82, 1192f);
				Singleton<PurchaseProtection>.instance.BuyingLootboxes(component.NLNBBHBLDMA());
				CGAMLDJFPHG();
				Singleton<BeanstalkServerManager>.instance.FCCLNIOHOPK(component.NPLFMNLOBJA(), num, dBOLKNNJGMH);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, Localization.Localize(", "));
			}
		}
		else
		{
			Debug.LogError("DailyAssignmentsReminder" + KHAHPAKDIKE.name);
		}
	}

	public void NCJHEGOCPCL()
	{
		TweenAlpha component = ILKPDBKMAGE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(false);
		NMHMFDOFDBC();
	}

	private void KBGPHPHECAG(GameObject KHAHPAKDIKE)
	{
		LootboxButtonRecord component = KHAHPAKDIKE.GetComponent<LootboxButtonRecord>();
		if (component != null)
		{
			int num = component.IKPHIEIAHEH();
			int dBOLKNNJGMH = component.NPDLOCPKOEI();
			if (Singleton<Wallet>.instance.CanBuyGold(num))
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-90), 1243f);
				Singleton<PurchaseProtection>.instance.HHOFINCBLCM(component.LBJPJIFDADD());
				CGAMLDJFPHG();
				Singleton<BeanstalkServerManager>.instance.FCCLNIOHOPK(component.id, num, dBOLKNNJGMH);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num, Localization.Localize("Buy_Pack"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
		}
		else
		{
			Debug.LogError("Coop" + KHAHPAKDIKE.name);
		}
	}

	private void FNMPBHIIEJP()
	{
	}

	private void LOKKCEFHDKL(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf && IFGAGNBDKBE == (DatabaseAction)(-139))
		{
			LHNFCBAHJPO();
		}
	}

	private void NBLEHOGBPFA()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].ECPJLAGGJDO();
		}
		CGMPHMLAJFB.MNHIJCAJIII();
	}

	private void LHNIFHMNHOC()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			IOKGJJIJCBO();
		}
	}

	public void AOKOBAOBDGM(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(true);
			NFNMLPPDPAP();
		}
		if (base.gameObject.activeSelf)
		{
			FIOJBBDFPAJ(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(ILKPDBKMAGE.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1593f) : 1282f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 924f : 513f).onFinished = hAJEIGIFBOO.NAJNECOMDDN;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			OBLGPLAHNNM();
		}
	}

	private void HJDNGDGCAKO(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN);
	}

	private void BMEBFFLHGME()
	{
	}

	private void FIALPJINCAI()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].BLFABAPBBJO();
		}
		CGMPHMLAJFB.MBLJDPHPING();
	}

	private void HLIDNLNIPOC()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			CBKJJDMLEEM[i].HDDIAMGKDDK();
		}
		CGMPHMLAJFB.CAAGDCDACMA();
	}

	private void JNBHDOBKJMP(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 560f) : 583f, (!NABOFKMBMKH) ? 857f : 1699f);
			}
		}
	}

	private void LPHIABAIILF()
	{
		for (int i = 1; i < CBKJJDMLEEM.Length; i += 0)
		{
			CBKJJDMLEEM[i].HEKLHELLAOC();
		}
		CGMPHMLAJFB.HEKLHELLAOC();
	}

	private void AKPHBJHGBKF()
	{
	}

	public void InitControls()
	{
		for (int i = 0; i < CBKJJDMLEEM.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CBKJJDMLEEM[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHGCJGHOHLO));
			CBKJJDMLEEM[i].InitControls();
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(CGMPHMLAJFB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KHGCJGHOHLO));
		CGMPHMLAJFB.InitControls();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<OfferManager>.instance.SalesChanged += ENCIECLPFEJ;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void AMNLMINIMPE(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight);
	}

	private void PAGNKBIBPFI(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf)
		{
			JEAOCIFPIGD();
		}
	}

	private void DIAPOHCJGOK(bool PDPDGCNHCFN = false)
	{
		PIDCGBIALAD.AlignToPos(PDPDGCNHCFN);
	}

	private void NMHMFDOFDBC()
	{
	}

	private void KHGCJGHOHLO(GameObject KHAHPAKDIKE)
	{
		LootboxButtonRecord component = KHAHPAKDIKE.GetComponent<LootboxButtonRecord>();
		if (component != null)
		{
			int gold = component.gold;
			int discount = component.discount;
			if (Singleton<Wallet>.instance.CanBuyGold(gold))
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BuyVIP);
				Singleton<PurchaseProtection>.instance.BuyingLootboxes(component.id);
				JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.FCCLNIOHOPK(component.id, gold, discount);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(gold, Localization.Localize("ID_LOOTBOXES"));
			}
		}
		else
		{
			Debug.LogError("Unkown Lootbox Button " + KHAHPAKDIKE.name);
		}
	}

	private void BDFPGMJLCJG()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			FIALPJINCAI();
		}
	}

	private void DLMIHKICPHA(GameObject KHAHPAKDIKE)
	{
		LootboxButtonRecord component = KHAHPAKDIKE.GetComponent<LootboxButtonRecord>();
		if (component != null)
		{
			int num = component.KENKBKDIEPD();
			int dBOLKNNJGMH = component.NOCIIGLAMLL();
			if (Singleton<Wallet>.instance.CanBuyGold(num))
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound, 1089f);
				Singleton<PurchaseProtection>.instance.BIENMIMLAEM(component.NKENPDPAACB());
				MAKHMMCNIBH();
				Singleton<BeanstalkServerManager>.instance.FCCLNIOHOPK(component.LBJPJIFDADD(), num, dBOLKNNJGMH);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num, Localization.Localize("{0} {1}"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			}
		}
		else
		{
			Debug.LogError("menu-wftv-mobcrush-ico" + KHAHPAKDIKE.name);
		}
	}

	private void PPMCFMBJJHP()
	{
	}
}

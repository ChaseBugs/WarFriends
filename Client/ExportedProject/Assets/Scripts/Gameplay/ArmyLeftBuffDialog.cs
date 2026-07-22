using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmyLeftBuffDialog : Core_BaseScript
{
	[FormerlySerializedAs("EFJHKJACCPP")]
	[Header("Core")]
	public UIPanel HPCKDMOJGAA;

	[FormerlySerializedAs("OCMLDDPLNGN")]
	public GameObject CEOENOGINLL;

	[FormerlySerializedAs("GBLBKMCKPID")]
	public UILabel KDIIAOLOKJE;

	[FormerlySerializedAs("CDFEKCFIJDG")]
	public UILabel NFHCAIGDBKJ;

	[FormerlySerializedAs("KFOPMOGEHDO")]
	public ArmyElitePerkHint MEDHBNIGJMP;

	[FormerlySerializedAs("OCHDIJMADJC")]
	public UISprite JBGFEFACAMO;

	[FormerlySerializedAs("DNFABNHKEFF")]
	public UISprite PPGKLPIGCEE;

	[FormerlySerializedAs("IHABADPIIAN")]
	public ArmyPowerAnimation OJMKGNOEAMI;

	[FormerlySerializedAs("IHADDAMIDKM")]
	[Header("Not implemented")]
	public GameObject CPONDKIPEFH;

	[FormerlySerializedAs("BDLPBBPJOAO")]
	[Header("Implemented")]
	public GameObject AMPIGMDIBEE;

	[FormerlySerializedAs("OKMIHAGBPNP")]
	public UILabel DLEFDEHDBCI;

	[FormerlySerializedAs("GFFHACKLBCO")]
	public ArmyUnitStatistics EEJNMEEDOOH;

	[Header("-Progress Bar")]
	[FormerlySerializedAs("JOMPOKMINOF")]
	public ArmyLeftBuffProgress EHAMCACFNHK;

	[FormerlySerializedAs("NPDEHMNJEMP")]
	[Header("-Convert to Scraps")]
	public GameObject EAJPPGOJDGN;

	[Header("-Convert to Parts")]
	[FormerlySerializedAs("KHFAMIBDIML")]
	public GameObject LJDKCPNMAFI;

	[FormerlySerializedAs("AFOEHKOMGHJ")]
	public UILabel GFHINOBJDOA;

	[FormerlySerializedAs("GDNDINFLBCB")]
	public UITable CKJKHGAAJOP;

	[FormerlySerializedAs("CKMLBIGAEJJ")]
	public UILabel FPODNLJCDFN;

	[FormerlySerializedAs("NAKHAMOJELP")]
	public UISprite[] OIEEABDKINI;

	[FormerlySerializedAs("LKHPHBAOCOL")]
	public UISprite LPGFGLCNLKL;

	[FormerlySerializedAs("JIKBIDGMHNA")]
	public TweenAlpha CHOKNMFJOJC;

	[FormerlySerializedAs("mBuffButtonLockedPart")]
	[Header("-Activate")]
	public GameObject IDFCJJLDIJC;

	[FormerlySerializedAs("HGJELGOLBDO")]
	[Header("-Upgrade")]
	public GameObject IFKLBIKNBNL;

	[FormerlySerializedAs("HMKADECGJON")]
	public UITable JMOINLNDICN;

	[FormerlySerializedAs("GFHNAAKMGIL")]
	public UILabel EDHFJKPPJGG;

	[FormerlySerializedAs("HBFCEIEKIKD")]
	public GameObject GIKLMCIJEMJ;

	[FormerlySerializedAs("HIAJMOMMMJN")]
	public UILabel ENDBPJCOPMO;

	[FormerlySerializedAs("OEJOIENMNNB")]
	public WinStreakCounter LOPJHBIKDKG;

	[Header("-Max")]
	[FormerlySerializedAs("mBuffButtonTierFullPart")]
	public GameObject JLGGIJKMAAE;

	[FormerlySerializedAs("mBuffButtonTierFullLabel")]
	public UILabel OIMCCOGJPGA;

	private LevelBehaviour IFFDIHCPKFE;

	private bool CNBJMDECEJG;

	private float JCAFFELIFAO = 0.3f;

	private bool JCKOBELDCGD;

	private bool IJAFILEMINJ;

	private bool OHAEHJIBLMG;

	private bool PNPNDIGNGAL;

	[CompilerGenerated]
	private void JICALAKPIDA(UITweener MKAPOHKFIJH)
	{
		if (!CNBJMDECEJG)
		{
			CEOENOGINLL.SetActive(value: false);
		}
	}

	private void CPIEGCEDKNK()
	{
		EEJNMEEDOOH.AnimateStat();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}

	private void EIENPLCLKBC(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (GuiScreenSingle<ArmyScreen>.instance.isShowed && base.gameObject.activeInHierarchy && !JCKOBELDCGD)
		{
			FPPPLPHDBMO();
			KIOOEACJNOD();
		}
	}

	private TweenAlpha OHJODAFJLMI()
	{
		return PIHLGCEAPIE(0f);
	}

	private void LOPDCKCHHFC(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	public void UpdateLeftContent(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = false;
			FPPPLPHDBMO();
		}
		else if (NOLODGKKCDH)
		{
			JCKOBELDCGD = false;
			FPPPLPHDBMO();
			KIOOEACJNOD();
		}
		else if (OHAEHJIBLMG || PNPNDIGNGAL)
		{
			TweenAlpha tweenAlpha = OHJODAFJLMI();
			if (tweenAlpha == null)
			{
				FPPPLPHDBMO();
				KIOOEACJNOD();
			}
			else
			{
				JCKOBELDCGD = true;
				if (PNPNDIGNGAL)
				{
					tweenAlpha.onFinished = delegate
					{
						JCKOBELDCGD = false;
					};
				}
				else
				{
					tweenAlpha.onFinished = delegate
					{
						FPPPLPHDBMO();
						KIOOEACJNOD(EOGFKBJCKHB: false);
						TweenAlpha tweenAlpha2 = EDJDPHGENOF();
						if (tweenAlpha2 != null)
						{
							tweenAlpha2.onFinished = delegate
							{
								JCKOBELDCGD = false;
							};
						}
						else
						{
							JCKOBELDCGD = false;
						}
					};
				}
			}
			OHAEHJIBLMG = false;
		}
		else
		{
			EKHICMLFNJP();
		}
	}

	public void InitControls()
	{
		Singleton<Wallet>.instance.ScrapsChanged += EIENPLCLKBC;
		UIEventListener uIEventListener = UIEventListener.Get(EAJPPGOJDGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CJMNAHEJMKA));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJDKCPNMAFI);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LOOKBNGBOAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(IDFCJJLDIJC);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFEBKOOCBMC));
		UIEventListener uIEventListener4 = UIEventListener.Get(IFKLBIKNBNL);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BEHFGHOIONB));
		CKJKHGAAJOP.onReposition = delegate
		{
			float val = 0f - CKJKHGAAJOP.padding.x - (FPODNLJCDFN.transform.parent.transform.localPosition.x - CKJKHGAAJOP.padding.x) / 2f;
			CKJKHGAAJOP.transform.localPosition = CKJKHGAAJOP.transform.localPosition.ReplaceX(val);
		};
		JMOINLNDICN.onReposition = delegate
		{
			float val = 0f - JMOINLNDICN.padding.x - (EDHFJKPPJGG.transform.parent.transform.localPosition.x - JMOINLNDICN.padding.x) / 2f;
			JMOINLNDICN.transform.localPosition = JMOINLNDICN.transform.localPosition.ReplaceX(val);
		};
		MEDHBNIGJMP.InitControls();
	}

	private void CIECFGJDOID(UITweener AECCHEAJGEP)
	{
		JCKOBELDCGD = false;
	}

	public void JIJEMHBPEDD(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		bool isUnlocked = DALNMKBABKH.upgradeSlots.upgradeSlotElite.isUnlocked;
		MEDHBNIGJMP.gameObject.SetActive(isUnlocked);
		if (isUnlocked)
		{
			MEDHBNIGJMP.HEGPFIGACED(DALNMKBABKH);
		}
	}

	private void FNIKLGEOJPI()
	{
		EEJNMEEDOOH.HBJPHKLEBHA();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.KIEBMLPFDBH();
		GuiScreenSingle<ArmyScreen>.instance.NHLFAGHPGGK();
	}

	public void DoAfterHide()
	{
		LOPJHBIKDKG.JCMHGOGNMFO();
		WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
		lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(SetEliteSaleAndPrize));
		MEDHBNIGJMP.DoAfterHide();
	}

	public void GCMDBMDNHLB(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		bool isUnlocked = DALNMKBABKH.upgradeSlots.upgradeSlotElite.isUnlocked;
		MEDHBNIGJMP.gameObject.SetActive(isUnlocked);
		if (isUnlocked)
		{
			MEDHBNIGJMP.EPAHIKLPNNB(DALNMKBABKH);
		}
	}

	private void JKOLBOFHBID(UITweener AECCHEAJGEP)
	{
		JCKOBELDCGD = true;
	}

	private void DIHDOLJHDLO(GameObject DGJCAIJPEIM)
	{
		if (DGJCAIJPEIM.activeInHierarchy)
		{
			BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	public void JCGDALOBGHO()
	{
		MEDHBNIGJMP.PGJDLKDMCHN();
	}

	public void HLGALFANPBC()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		OHAEHJIBLMG = true;
		PNPNDIGNGAL = false;
		CEOENOGINLL.SetActive(value: true);
		HPCKDMOJGAA.alpha1 = 178f;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 1860f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 120f, new Vector3(1105f, 233f, 896f), new Vector3(764f, 459f, 988f)).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		CKPGOICMEFO();
		OJKOPKONMAH();
		KIOOEACJNOD();
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: true);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 390f).onFinished = null;
		}
	}

	private void DLLKKEEIMLE()
	{
		EEJNMEEDOOH.KGGFEJKCILH();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.KIEBMLPFDBH();
		GuiScreenSingle<ArmyScreen>.instance.GMOCHILAJOE();
	}

	private void NJNNKHHFHEP()
	{
		EEJNMEEDOOH.IPLBLBKICGO();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.GMOCHILAJOE();
	}

	private void OJKOPKONMAH()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = isUnlocked && upgradeSlotElite.IDFIPMFGPIM();
		bool flag2 = !isUnlocked || upgradeSlotElite.JFAELKHPLLA();
		bool flag3 = !isUnlocked || upgradeSlotElite.HMPNFKJHKGG() >= upgradeSlotElite.KPJDJFMGNNM();
		bool flag4 = isUnlocked && upgradeSlotElite.HMPNFKJHKGG() > 1;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.BLEGKMEKOPE();
		MAHMLBABNJG();
		EAJPPGOJDGN.SetActive(!flag2 || flag4);
		LJDKCPNMAFI.SetActive(flag || !flag3);
		IDFCJJLDIJC.SetActive(!flag2 && flag3);
		IFKLBIKNBNL.SetActive(!flag2 || flag || flag3);
		JLGGIJKMAAE.SetActive(flag2 && flag);
		bool flag5 = flag2 && flag;
		EHAMCACFNHK.transform.localPosition = EHAMCACFNHK.transform.localPosition.ReplaceY((!flag5) ? 1436f : 516f);
		JLGGIJKMAAE.transform.localPosition = JLGGIJKMAAE.transform.localPosition.ReplaceY((!flag5) ? 370f : 758f);
	}

	private TweenAlpha ELMNGOIGPAL()
	{
		return DADHGDCJPGA(830f);
	}

	private void KIBINGMMAJA(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			Debug.LogFormat("Army Power Buff Animation from {0} to {1}", LFNBJLJPEGP, armyPowerX);
			OJMKGNOEAMI.StartAnimation(hONEKCJDJDN, armyPowerX, 0.05f);
		}
	}

	private void LOOKBNGBOAH(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.isAnimatingSpend)
		{
			JCKOBELDCGD = true;
			int missingScraps = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.missingScraps;
			int upgradePriceParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePriceParts;
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ConvertScrapsToParts, IFFDIHCPKFE.upgradeSlots.GetSheetName(), 0, 0, string.Empty);
			Singleton<EventTrackingManager>.instance.RegisterPartsGainedFromScraps(IFFDIHCPKFE.upgradeSlots.GetSheetName(), upgradePriceParts - currentParts);
			Singleton<Wallet>.instance.ScrapsSpent(missingScraps);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts = upgradePriceParts;
			SoundsManager.Instance.PlayButtonClickedSound();
			PNDNJFJMEJE(LJDKCPNMAFI);
			OHAEHJIBLMG = true;
			UpdateLeftContent();
		}
	}

	public void SelectUnit(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		bool isUnlocked = DALNMKBABKH.upgradeSlots.upgradeSlotElite.isUnlocked;
		MEDHBNIGJMP.gameObject.SetActive(isUnlocked);
		if (isUnlocked)
		{
			MEDHBNIGJMP.Initialize(DALNMKBABKH);
		}
	}

	private void KBBFDNELNJG()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		bool flag2 = flag && upgradeSlotElite.IDFIPMFGPIM();
		bool flag3 = flag && upgradeSlotElite.isBought;
		bool flag4 = !flag || upgradeSlotElite.HMPNFKJHKGG() >= upgradeSlotElite.KPJDJFMGNNM();
		bool flag5 = flag && upgradeSlotElite.HMPNFKJHKGG() > 0;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.ONCJPDCHMEE();
		MAHMLBABNJG();
		EAJPPGOJDGN.SetActive(!flag3 || flag5);
		LJDKCPNMAFI.SetActive(!flag2 && flag4);
		IDFCJJLDIJC.SetActive(!flag3 && flag4);
		IFKLBIKNBNL.SetActive(!flag3 || flag2 || flag4);
		JLGGIJKMAAE.SetActive(!flag3 || flag2);
		bool flag6 = flag3 && flag2;
		EHAMCACFNHK.transform.localPosition = EHAMCACFNHK.transform.localPosition.ReplaceY((!flag6) ? 22f : 902f);
		JLGGIJKMAAE.transform.localPosition = JLGGIJKMAAE.transform.localPosition.ReplaceY((!flag6) ? 1588f : 1227f);
	}

	private void BFPGPEEJLED(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.MDDPACGLIGL(IFFDIHCPKFE);
		PNDNJFJMEJE(IDFCJJLDIJC);
		KIBINGMMAJA(armyPowerX);
		CKNDPIGNLOG();
		PNPNDIGNGAL = false;
		EHAMCACFNHK.CFFBECGCDLN(536f);
	}

	private void JFPECNCBAFO(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = true;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.BuyUnitElite(IFFDIHCPKFE);
		GPIFPLLNNMA(IDFCJJLDIJC);
		KIBINGMMAJA(armyPowerX);
		CKNDPIGNLOG();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.ICOMGJKIBAI(710f);
	}

	private void GPIFPLLNNMA(GameObject DGJCAIJPEIM)
	{
		if (DGJCAIJPEIM.activeInHierarchy)
		{
			BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	public void PCALNGOCDKE(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		bool flag = DALNMKBABKH.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		MEDHBNIGJMP.gameObject.SetActive(flag);
		if (flag)
		{
			MEDHBNIGJMP.ACBHGJCMCPG(DALNMKBABKH);
		}
	}

	private void ANCGKPKLGDD(UITweener MKAPOHKFIJH)
	{
		if (!CNBJMDECEJG)
		{
			CEOENOGINLL.SetActive(value: true);
		}
	}

	private TweenAlpha PIHLGCEAPIE(float FFFGJJDIMEF)
	{
		TweenAlpha tweenAlpha = LJDKCPNMAFI.GetComponent<TweenAlpha>();
		bool flag = false;
		if (CEOENOGINLL.activeSelf && JCKOBELDCGD)
		{
			if (LJDKCPNMAFI.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(LJDKCPNMAFI, FFFGJJDIMEF);
				flag = true;
			}
			if (IDFCJJLDIJC.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(IDFCJJLDIJC, FFFGJJDIMEF);
				flag = true;
			}
			if (IFKLBIKNBNL.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(IFKLBIKNBNL, FFFGJJDIMEF);
				flag = true;
			}
			if (JLGGIJKMAAE.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(JLGGIJKMAAE, FFFGJJDIMEF);
				flag = true;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	public void HCAOABHNLID()
	{
		Singleton<Wallet>.instance.LIMNMFNEEDL(DMGHCOIOIMM);
		UIEventListener uIEventListener = UIEventListener.Get(EAJPPGOJDGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDFPNCGAMCH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJDKCPNMAFI);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OEEKOIIOAEJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IDFCJJLDIJC);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFEBKOOCBMC));
		UIEventListener uIEventListener4 = UIEventListener.Get(IFKLBIKNBNL);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FFOEPDJNACA));
		CKJKHGAAJOP.onReposition = delegate
		{
			float val = 0f - CKJKHGAAJOP.padding.x - (FPODNLJCDFN.transform.parent.transform.localPosition.x - CKJKHGAAJOP.padding.x) / 2f;
			CKJKHGAAJOP.transform.localPosition = CKJKHGAAJOP.transform.localPosition.ReplaceX(val);
		};
		JMOINLNDICN.onReposition = FKOPEJMHDHB;
		MEDHBNIGJMP.KPEJMMBDODD();
	}

	private void JGLEHPMGPHG(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.BuyUnitElite(IFFDIHCPKFE);
		GPIFPLLNNMA(IDFCJJLDIJC);
		NNDDEGONEAG(armyPowerX);
		DLLKKEEIMLE();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.HLODICOAKHE(1481f);
	}

	public void OPPAFPHDKNL()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		OHAEHJIBLMG = false;
		PNPNDIGNGAL = true;
		CEOENOGINLL.SetActive(value: true);
		HPCKDMOJGAA.alpha1 = 462f;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 1631f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 1197f, new Vector3(266f, 399f, 291f), new Vector3(66f, 1724f, 997f), useLocal: false).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		LDPNDEMHHON();
		OJKOPKONMAH();
		ADCAPGFOEPJ(EOGFKBJCKHB: false);
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 859f).onFinished = null;
		}
	}

	private void FKOPEJMHDHB()
	{
		float val = 0f - JMOINLNDICN.padding.x - (EDHFJKPPJGG.transform.parent.transform.localPosition.x - JMOINLNDICN.padding.x) / 755f;
		JMOINLNDICN.transform.localPosition = JMOINLNDICN.transform.localPosition.ReplaceX(val);
	}

	public void DOKNIFNNCDH()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		OHAEHJIBLMG = true;
		PNPNDIGNGAL = true;
		CEOENOGINLL.SetActive(value: true);
		HPCKDMOJGAA.alpha1 = 859f;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 395f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 243f, new Vector3(1489f, 459f, 1454f), new Vector3(1674f, 250f, 1010f), useLocal: false).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		CKPGOICMEFO();
		OGOGDIOICNB();
		ADCAPGFOEPJ(EOGFKBJCKHB: false);
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: false);
		for (int num = 1; num < componentsInChildren.Length; num += 0)
		{
			UIPanel uIPanel = componentsInChildren[num];
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 685f).onFinished = null;
		}
	}

	private void HONBONFEJCA(UITweener MKAPOHKFIJH)
	{
		if (!CNBJMDECEJG)
		{
			CEOENOGINLL.SetActive(value: true);
		}
	}

	private void DDCLNPKMJBP(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.DFLDFNEEFJF())
		{
			JCKOBELDCGD = false;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.NLAHDICDJOC();
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.GDGDBLIHNLD();
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.UniqueSquadNameSuccess, IFFDIHCPKFE.upgradeSlots.GetSheetName(), 0, 1, string.Empty);
			Singleton<EventTrackingManager>.instance.RegisterPartsGainedFromScraps(IFFDIHCPKFE.upgradeSlots.GetSheetName(), num2 - currentParts);
			Singleton<Wallet>.instance.ICDNGMDNDAN(num);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.LOHDPALFBPI(num2);
			SoundsManager.Instance.PlayButtonClickedSound();
			OGIOKBEMHKA(LJDKCPNMAFI);
			OHAEHJIBLMG = false;
			IFDPNOKDKMC();
		}
	}

	[CompilerGenerated]
	private void DAJIFOIEEFE(bool BLHPGCIDEBE)
	{
		if (BLHPGCIDEBE)
		{
			JCKOBELDCGD = true;
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsSell).FLOATVALUE;
			int num = (int)((float)currentParts * (float)fLOATVALUE);
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ConvertPartsToScraps, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"LevelName",
					IFFDIHCPKFE.upgradeSlots.GetSheetName()
				},
				{ "PartsToConvert", currentParts },
				{ "Scraps", num }
			}), 0, 0, string.Empty);
			Singleton<Wallet>.instance.AddScraps(num);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts = 0;
			OHAEHJIBLMG = true;
			UpdateLeftContent();
		}
	}

	private void BEHFGHOIONB(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice * (100 - num) / 100;
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADEELITE : NotEnoughDialog.NKHJBLBAAEB.TRAINELITE);
			return;
		}
		JCKOBELDCGD = true;
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.UpgradeUnitElite(IFFDIHCPKFE, num);
		PNDNJFJMEJE(IFKLBIKNBNL);
		KIBINGMMAJA(armyPowerX);
		CPIEGCEDKNK();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.AnimateSpend(0.6f);
	}

	public void IFDPNOKDKMC(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = true;
			FPPPLPHDBMO();
		}
		else if (NOLODGKKCDH)
		{
			JCKOBELDCGD = false;
			OGOGDIOICNB();
			ADCAPGFOEPJ();
		}
		else if (OHAEHJIBLMG || PNPNDIGNGAL)
		{
			TweenAlpha tweenAlpha = KJGNCCFNKND();
			if (tweenAlpha == null)
			{
				OGOGDIOICNB();
				ADCAPGFOEPJ(EOGFKBJCKHB: false);
			}
			else
			{
				JCKOBELDCGD = false;
				if (PNPNDIGNGAL)
				{
					tweenAlpha.onFinished = GIJMICDMIPE;
				}
				else
				{
					tweenAlpha.onFinished = delegate
					{
						FPPPLPHDBMO();
						KIOOEACJNOD(EOGFKBJCKHB: false);
						TweenAlpha tweenAlpha2 = EDJDPHGENOF();
						if (tweenAlpha2 != null)
						{
							tweenAlpha2.onFinished = delegate
							{
								JCKOBELDCGD = false;
							};
						}
						else
						{
							JCKOBELDCGD = false;
						}
					};
				}
			}
			OHAEHJIBLMG = true;
		}
		else
		{
			MAHMLBABNJG();
		}
	}

	private void PNDNJFJMEJE(GameObject DGJCAIJPEIM)
	{
		if (DGJCAIJPEIM.activeInHierarchy)
		{
			BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	public void PBAGIJOFIMD()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		OHAEHJIBLMG = false;
		PNPNDIGNGAL = true;
		CEOENOGINLL.SetActive(value: false);
		HPCKDMOJGAA.alpha1 = 1625f;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 1240f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 887f, new Vector3(201f, 1263f, 1906f), new Vector3(663f, 667f, 288f), useLocal: false).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		IEGEHKOIKNB();
		OGOGDIOICNB();
		ADCAPGFOEPJ(EOGFKBJCKHB: false);
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: true);
		for (int num = 0; num < componentsInChildren.Length; num += 0)
		{
			UIPanel uIPanel = componentsInChildren[num];
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 907f).onFinished = null;
		}
	}

	private void FHBLADBBEDG(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)4);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice * (54 - num) / 47;
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.TRAINSPECIAL : NotEnoughDialog.NKHJBLBAAEB.DELIVERSPECIAL);
			return;
		}
		JCKOBELDCGD = false;
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.KDHBBPANNJK(IFFDIHCPKFE, num);
		DIHDOLJHDLO(IFKLBIKNBNL);
		NNDDEGONEAG(armyPowerX);
		CPIEGCEDKNK();
		PNPNDIGNGAL = false;
		EHAMCACFNHK.ICOMGJKIBAI(1673f);
	}

	private TweenAlpha JCBHDJEBFMF(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	public void MMNLDIDPNPI()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 1045f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 569f, new Vector3(993f, 810f, 1154f)).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				CEOENOGINLL.SetActive(value: false);
			}
		};
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: true);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1117f).onFinished = null;
		}
	}

	private TweenAlpha PCHGELDHMLL(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	public void NNGCHECCPAD()
	{
		LOPJHBIKDKG.GGKCMHOGFPF();
		WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
		lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(KCAMPCEDKGH));
		MEDHBNIGJMP.APNLBLNDGCM();
	}

	private void GCCPDOGOIJI(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Both);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice * (-105 - num) / -77;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADESPECIAL : NotEnoughDialog.NKHJBLBAAEB.TRAINELITE);
			return;
		}
		JCKOBELDCGD = false;
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		GuiScreenSingle<ArmyScreen>.instance.FFECJLDGABC(IFFDIHCPKFE, num);
		PNDNJFJMEJE(IFKLBIKNBNL);
		NNDDEGONEAG(armyPowerX);
		CPIEGCEDKNK();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.AHDKBLBFBPA(1920f);
	}

	private void GDFPNCGAMCH(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.HCDEDBJPHIL())
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<ConvertToScrapsDialog>.instance.KLMGKBDODBJ(IFFDIHCPKFE, MDBLPHHBMLA);
		}
	}

	private TweenAlpha MEHNMAGOMNK(float FFFGJJDIMEF)
	{
		TweenAlpha tweenAlpha = LJDKCPNMAFI.GetComponent<TweenAlpha>();
		bool flag = true;
		if (CEOENOGINLL.activeSelf && JCKOBELDCGD)
		{
			if (LJDKCPNMAFI.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(LJDKCPNMAFI, FFFGJJDIMEF);
				flag = true;
			}
			if (IDFCJJLDIJC.activeSelf)
			{
				tweenAlpha = PCHGELDHMLL(IDFCJJLDIJC, FFFGJJDIMEF);
				flag = false;
			}
			if (IFKLBIKNBNL.activeSelf)
			{
				tweenAlpha = JCBHDJEBFMF(IFKLBIKNBNL, FFFGJJDIMEF);
				flag = true;
			}
			if (JLGGIJKMAAE.activeSelf)
			{
				tweenAlpha = IOHEFGFKPGL(JLGGIJKMAAE, FFFGJJDIMEF);
				flag = false;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	private void KBOKNFLJCCM(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true, bool LPFNJIJOIGN = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = LPFNJIJOIGN;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1343f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	public void MMLOAKGDDGF()
	{
		LOPJHBIKDKG.FCGPLOBEHDL();
		WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
		lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(LDOADIBCNPI));
		MEDHBNIGJMP.APNLBLNDGCM();
	}

	private void OGIOKBEMHKA(GameObject DGJCAIJPEIM)
	{
		if (DGJCAIJPEIM.activeInHierarchy)
		{
			BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private void OONMMIONBJM(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.PBOBGPFLEAM())
		{
			JCKOBELDCGD = false;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.NLAHDICDJOC();
			int upgradePriceParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePriceParts;
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.MessageWasShown, IFFDIHCPKFE.upgradeSlots.GetSheetName(), 0, 1, string.Empty);
			Singleton<EventTrackingManager>.instance.RegisterPartsGainedFromScraps(IFFDIHCPKFE.upgradeSlots.GetSheetName(), upgradePriceParts - num2);
			Singleton<Wallet>.instance.ScrapsSpent(num);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HJDGAPEOIGM(upgradePriceParts);
			SoundsManager.Instance.PlayButtonClickedSound();
			PNDNJFJMEJE(LJDKCPNMAFI);
			OHAEHJIBLMG = true;
			APDJJBILBIM(NOLODGKKCDH: false);
		}
	}

	private TweenAlpha HCNEAGMMHGN()
	{
		return DADHGDCJPGA(1898f);
	}

	private void NNDDEGONEAG(int LFNBJLJPEGP)
	{
		if (IFFDIHCPKFE.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN = armyPowerX - LFNBJLJPEGP;
			object[] array = new object[7];
			array[0] = LFNBJLJPEGP;
			array[0] = armyPowerX;
			Debug.LogFormat("#VOJTA# ERROR ACHIEVEMENT ALREADY CLAIMED!!", array);
			OJMKGNOEAMI.StartAnimation(hONEKCJDJDN, armyPowerX, 620f);
		}
	}

	private void PFOOFHEBCPB(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.MDDPACGLIGL(IFFDIHCPKFE);
		PNDNJFJMEJE(IDFCJJLDIJC);
		NNDDEGONEAG(armyPowerX);
		DLLKKEEIMLE();
		PNPNDIGNGAL = false;
		EHAMCACFNHK.HLODICOAKHE(912f);
	}

	[CompilerGenerated]
	private void DKBMIKLNLDM(UITweener AECCHEAJGEP)
	{
		JCKOBELDCGD = false;
	}

	private void LGCAKAAOOAI(UITweener IALJKEHIGBM)
	{
		KBBFDNELNJG();
		ADCAPGFOEPJ(EOGFKBJCKHB: false);
		TweenAlpha tweenAlpha = HCNEAGMMHGN();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
			};
		}
		else
		{
			JCKOBELDCGD = true;
		}
	}

	private void IFEBKOOCBMC(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = true;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.BuyUnitElite(IFFDIHCPKFE);
		PNDNJFJMEJE(IDFCJJLDIJC);
		KIBINGMMAJA(armyPowerX);
		CPIEGCEDKNK();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.AnimateSpend(0.6f);
	}

	private void OGOGDIOICNB()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = !isUnlocked || upgradeSlotElite.isMaxUpgraded;
		bool flag2 = isUnlocked && upgradeSlotElite.BDAAHLLPPGN();
		bool flag3 = !isUnlocked || upgradeSlotElite.currentParts >= upgradeSlotElite.AMDIEMKNOHN();
		bool flag4 = isUnlocked && upgradeSlotElite.currentParts > 1;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.UpdateProgresses();
		LCAEBPGBDMP();
		EAJPPGOJDGN.SetActive(!flag2 || flag4);
		LJDKCPNMAFI.SetActive(!flag && flag3);
		IDFCJJLDIJC.SetActive(flag2 || flag3);
		IFKLBIKNBNL.SetActive(flag2 && !flag && flag3);
		JLGGIJKMAAE.SetActive(flag2 && flag);
		bool flag5 = !flag2 || flag;
		EHAMCACFNHK.transform.localPosition = EHAMCACFNHK.transform.localPosition.ReplaceY((!flag5) ? 1415f : 670f);
		JLGGIJKMAAE.transform.localPosition = JLGGIJKMAAE.transform.localPosition.ReplaceY((!flag5) ? 1542f : 439f);
	}

	private void OKBMOFHDAME(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Both);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.CIBEGNHKPJH() * (-10 - num) / -110;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, IFFDIHCPKFE.isSoldier ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.TRAINSPECIAL);
			return;
		}
		JCKOBELDCGD = false;
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		GuiScreenSingle<ArmyScreen>.instance.FFECJLDGABC(IFFDIHCPKFE, num);
		DIHDOLJHDLO(IFKLBIKNBNL);
		KIBINGMMAJA(armyPowerX);
		DLLKKEEIMLE();
		PNPNDIGNGAL = false;
		EHAMCACFNHK.NFMIHHDNJKM(1912f);
	}

	public void NADMMJHGGOM()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = false;
		CEOENOGINLL.SetActive(value: false);
	}

	public void DOKBOONBGAJ(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		bool flag = DALNMKBABKH.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		MEDHBNIGJMP.gameObject.SetActive(flag);
		if (flag)
		{
			MEDHBNIGJMP.ACBHGJCMCPG(DALNMKBABKH);
		}
	}

	private void PBPOLIDHOFG(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.EFBAJKAPKPM())
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<ConvertToScrapsDialog>.instance.ShowDialog(IFFDIHCPKFE, MDBLPHHBMLA);
		}
	}

	private void MDBLPHHBMLA(bool BLHPGCIDEBE)
	{
		if (BLHPGCIDEBE)
		{
			JCKOBELDCGD = true;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-46)).FLOATVALUE;
			int num2 = (int)((float)num * (float)fLOATVALUE);
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.GenerateSpecialOffer, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"Server send time when unit upgrade will be delivered - Player already hit button DELIVERY NOW - update delivery time is being ignored!",
					IFFDIHCPKFE.upgradeSlots.GetSheetName()
				},
				{ "menu-arena-lootbox-gold", num },
				{ "playerInfo", num2 }
			}), 0, 0, string.Empty);
			Singleton<Wallet>.instance.AddScraps(num2);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.LOHDPALFBPI(0);
			OHAEHJIBLMG = true;
			APDJJBILBIM();
		}
	}

	private void JNPJMNCACHN()
	{
		if (CEOENOGINLL.activeSelf)
		{
			EEJNMEEDOOH.InitializeEliteIcon(IFFDIHCPKFE);
		}
	}

	[CompilerGenerated]
	private void MJMCMLMEOLP(UITweener MKAPOHKFIJH)
	{
		if (CNBJMDECEJG)
		{
			TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
		}
	}

	public void ILAKBCALDJK()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = true;
		CEOENOGINLL.SetActive(value: false);
	}

	private void FFOEPDJNACA(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)6);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice * (81 - num) / 111;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.TRAIN : NotEnoughDialog.NKHJBLBAAEB.BUY);
			return;
		}
		JCKOBELDCGD = true;
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		GuiScreenSingle<ArmyScreen>.instance.IBJCANAPMLH(IFFDIHCPKFE, num);
		OGIOKBEMHKA(IFKLBIKNBNL);
		KIBINGMMAJA(armyPowerX);
		NJNNKHHFHEP();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.KKBADFAMMGD(234f);
	}

	public void SetEliteSaleAndPrize()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			EDHFJKPPJGG.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			JMOINLNDICN.repositionNow = true;
			GIKLMCIJEMJ.SetActive(flag);
			if (flag)
			{
				ENDBPJCOPMO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				LOPJHBIKDKG.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade));
				WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
				lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(SetEliteSaleAndPrize));
				WinStreakCounter lOPJHBIKDKG2 = LOPJHBIKDKG;
				lOPJHBIKDKG2.JEMKCLKCOMI = (Action)Delegate.Combine(lOPJHBIKDKG2.JEMKCLKCOMI, new Action(SetEliteSaleAndPrize));
			}
			else
			{
				LOPJHBIKDKG.JCMHGOGNMFO();
				WinStreakCounter lOPJHBIKDKG3 = LOPJHBIKDKG;
				lOPJHBIKDKG3.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG3.JEMKCLKCOMI, new Action(SetEliteSaleAndPrize));
			}
		}
	}

	private void MAHMLBABNJG()
	{
		IJAFILEMINJ = false;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool flag = upgradeSlotElite.ACIMFKOCEHH();
		bool flag2 = flag && IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.isBought;
		CPONDKIPEFH.SetActive(flag);
		AMPIGMDIBEE.SetActive(flag);
		int num = (flag ? upgradeSlotElite.PAKKPEPIHPK() : 0);
		int num2 = ((!flag) ? 1 : upgradeSlotElite.EMOPFFCAPNP());
		KDIIAOLOKJE.text = Localization.Localize((!flag || !flag2) ? "Reward {0:D2}" : "special");
		JBGFEFACAMO.transform.localScale = JBGFEFACAMO.transform.localScale.ReplaceY((!flag) ? 860f : 1720f);
		PPGKLPIGCEE.transform.localScale = PPGKLPIGCEE.transform.localScale.ReplaceY((!flag) ? 1818f : 1936f);
		UILabel nFHCAIGDBKJ = NFHCAIGDBKJ;
		string text;
		if (flag)
		{
			object[] array = new object[6];
			array[1] = IFFDIHCPKFE.unitBuffName;
			array[1] = num;
			array[5] = Colours.stringGray;
			array[0] = num2;
			text = string.Format("ID_WARNING_CANNOTINVITE_TEXT", array);
		}
		else
		{
			text = Localization.Localize("ID_CRAFTABLEWARCARDS");
		}
		nFHCAIGDBKJ.text = text;
		if (flag)
		{
			Tuple<string, float[]> oDFAFEEGGJK = upgradeSlotElite.guiStatistics[1];
			int num3 = upgradeSlotElite.HMPNFKJHKGG();
			int num4 = upgradeSlotElite.GDGDBLIHNLD();
			long num5 = Singleton<Wallet>.instance.DKBGKFCCHCG();
			int num6 = upgradeSlotElite.NBIKPAHDDLI();
			IJAFILEMINJ = num5 < num6;
			DLEFDEHDBCI.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi2);
			LDPNDEMHHON();
			EEJNMEEDOOH.AFOGLAKGDKI(oDFAFEEGGJK, flag2);
			EHAMCACFNHK.FJLJLDNCBBD(IFFDIHCPKFE);
			SetEliteSaleAndPrize();
			GFHINOBJDOA.text = ((num4 <= num3) ? string.Empty : Localization.LocalizeFormat("N", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(num4 - num3), null, null, null, null, null));
			MEJMLNDFDBP.COCBCFKJOJE(GFHINOBJDOA, 849f, 27f, 170);
			FPODNLJCDFN.text = string.Format("ID_CONFIRM_OFFERTOOSHORTDURATION", num5, Colours.stringWhite, num6);
			CKJKHGAAJOP.repositionNow = true;
			OIEEABDKINI[1].color = ((!IJAFILEMINJ) ? Colours.grayButton : Color.white);
			OIEEABDKINI[0].color = ((!IJAFILEMINJ) ? Colours.grayButton : Color.white);
			CHOKNMFJOJC.enabled = IJAFILEMINJ;
			if (!IJAFILEMINJ)
			{
				LPGFGLCNLKL.alpha = 438f;
			}
			OIMCCOGJPGA.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "assault" : "SquadWarsId");
		}
	}

	private void OEEKOIIOAEJ(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.EFBAJKAPKPM())
		{
			JCKOBELDCGD = true;
			int missingScraps = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.missingScraps;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.EGAMIJEOAJN();
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)(-79), IFFDIHCPKFE.upgradeSlots.GetSheetName(), 1, 0, string.Empty);
			Singleton<EventTrackingManager>.instance.AFPPIFHEFGD(IFFDIHCPKFE.upgradeSlots.GetSheetName(), num - num2);
			Singleton<Wallet>.instance.CMBLGJLJFOG(missingScraps);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.BNJHHCDOELJ(num);
			SoundsManager.Instance.PlayButtonClickedSound();
			PNDNJFJMEJE(LJDKCPNMAFI);
			OHAEHJIBLMG = false;
			IFDPNOKDKMC(NOLODGKKCDH: false);
		}
	}

	private void LPGNENNLDBE()
	{
		float val = 0f - CKJKHGAAJOP.padding.x - (FPODNLJCDFN.transform.parent.transform.localPosition.x - CKJKHGAAJOP.padding.x) / 211f;
		CKJKHGAAJOP.transform.localPosition = CKJKHGAAJOP.transform.localPosition.ReplaceX(val);
	}

	private void OMNOFLEIEAM(UITweener IALJKEHIGBM)
	{
		KBBFDNELNJG();
		ADCAPGFOEPJ();
		TweenAlpha tweenAlpha = ELMNGOIGPAL();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = LOPDCKCHHFC;
		}
		else
		{
			JCKOBELDCGD = true;
		}
	}

	private void GIJMICDMIPE(UITweener AECCHEAJGEP)
	{
		JCKOBELDCGD = false;
	}

	private void FKNPOALIFEH(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.GJLADCENHAL())
		{
			JCKOBELDCGD = false;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JHIFJFCNOAG();
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.KPJDJFMGNNM();
			int num3 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.GetPlayersFromHitList, IFFDIHCPKFE.upgradeSlots.GetSheetName(), 0, 0, string.Empty, additionalParameter: true);
			Singleton<EventTrackingManager>.instance.AFPPIFHEFGD(IFFDIHCPKFE.upgradeSlots.GetSheetName(), num2 - num3);
			Singleton<Wallet>.instance.ICDNGMDNDAN(num);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HJDGAPEOIGM(num2);
			SoundsManager.Instance.PlayButtonClickedSound();
			DIHDOLJHDLO(LJDKCPNMAFI);
			OHAEHJIBLMG = true;
			IFDPNOKDKMC();
		}
	}

	private void FMJLDNNAFGD(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = true;
	}

	private TweenAlpha DADHGDCJPGA(float FFFGJJDIMEF)
	{
		TweenAlpha tweenAlpha = LJDKCPNMAFI.GetComponent<TweenAlpha>();
		bool flag = false;
		if (CEOENOGINLL.activeSelf && JCKOBELDCGD)
		{
			if (LJDKCPNMAFI.activeSelf)
			{
				tweenAlpha = BIMIINOHNPH(LJDKCPNMAFI, FFFGJJDIMEF);
				flag = true;
			}
			if (IDFCJJLDIJC.activeSelf)
			{
				tweenAlpha = PCHGELDHMLL(IDFCJJLDIJC, FFFGJJDIMEF);
				flag = true;
			}
			if (IFKLBIKNBNL.activeSelf)
			{
				tweenAlpha = PCHGELDHMLL(IFKLBIKNBNL, FFFGJJDIMEF);
				flag = false;
			}
			if (JLGGIJKMAAE.activeSelf)
			{
				tweenAlpha = BIMIINOHNPH(JLGGIJKMAAE, FFFGJJDIMEF);
				flag = false;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	public void APDJJBILBIM(bool NOLODGKKCDH = true)
	{
		if (!CNBJMDECEJG)
		{
			JCKOBELDCGD = false;
			FPPPLPHDBMO();
		}
		else if (NOLODGKKCDH)
		{
			JCKOBELDCGD = false;
			OGOGDIOICNB();
			ADCAPGFOEPJ();
		}
		else if (OHAEHJIBLMG || PNPNDIGNGAL)
		{
			TweenAlpha tweenAlpha = KJGNCCFNKND();
			if (tweenAlpha == null)
			{
				OJKOPKONMAH();
				ADCAPGFOEPJ(EOGFKBJCKHB: false);
			}
			else
			{
				JCKOBELDCGD = false;
				if (PNPNDIGNGAL)
				{
					tweenAlpha.onFinished = NKGDKBNDFIM;
				}
				else
				{
					tweenAlpha.onFinished = LGCAKAAOOAI;
				}
			}
			OHAEHJIBLMG = false;
		}
		else
		{
			EKHICMLFNJP();
		}
	}

	private void OPGDALOAGJI(bool BLHPGCIDEBE)
	{
		if (BLHPGCIDEBE)
		{
			JCKOBELDCGD = true;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.HMPNFKJHKGG();
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-106)).FLOATVALUE;
			int num2 = (int)((float)num * (float)fLOATVALUE);
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)(-183), JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"RowIDs",
					IFFDIHCPKFE.upgradeSlots.GetSheetName()
				},
				{ " AND ", num },
				{ "LeagueId", num2 }
			}), 0, 0, string.Empty, additionalParameter: true);
			Singleton<Wallet>.instance.AddScraps(num2);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JMNFJMPIODK(1);
			OHAEHJIBLMG = true;
			IFDPNOKDKMC(NOLODGKKCDH: false);
		}
	}

	private void MGCMOALEGJD(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true, bool LPFNJIJOIGN = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = LPFNJIJOIGN;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	private void PMBJFLDIOEB(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true, bool LPFNJIJOIGN = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = LPFNJIJOIGN;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.LHDGJFHPJNM())
			{
				component2.alpha1 = 259f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = true;
			component3.onFinished = null;
		}
	}

	private TweenAlpha NBEHNLGGKCC()
	{
		return DADHGDCJPGA(1930f);
	}

	public void GPPGJBIBECF(LevelBehaviour DALNMKBABKH)
	{
		IFFDIHCPKFE = DALNMKBABKH;
		bool flag = DALNMKBABKH.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		MEDHBNIGJMP.gameObject.SetActive(flag);
		if (flag)
		{
			MEDHBNIGJMP.CIPKPHAGJMP(DALNMKBABKH);
		}
	}

	private void GENHFAEHCNP()
	{
		EEJNMEEDOOH.EBKMGDMEOBC();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPMIJIHLPOM();
		GuiScreenSingle<ArmyScreen>.instance.BFEFIEHKEJB();
	}

	private void EKHICMLFNJP()
	{
		IJAFILEMINJ = false;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = isUnlocked && IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.isBought;
		CPONDKIPEFH.SetActive(!isUnlocked);
		AMPIGMDIBEE.SetActive(isUnlocked);
		int num = (isUnlocked ? upgradeSlotElite.boughtIndex : 0);
		int num2 = (isUnlocked ? upgradeSlotElite.maxRowForActualTier : 0);
		KDIIAOLOKJE.text = Localization.Localize((!isUnlocked || !flag) ? "ID_BUFF" : "ID_UPGRADE");
		JBGFEFACAMO.transform.localScale = JBGFEFACAMO.transform.localScale.ReplaceY((!isUnlocked) ? 640f : 823f);
		PPGKLPIGCEE.transform.localScale = PPGKLPIGCEE.transform.localScale.ReplaceY((!isUnlocked) ? 382f : 568f);
		NFHCAIGDBKJ.text = ((!isUnlocked) ? Localization.Localize("ID_NOTAVAILABLEATTHEMOMENT") : $"{IFFDIHCPKFE.unitBuffName} {num} {Colours.stringGray}/ {num2}[-]");
		if (isUnlocked)
		{
			Tuple<string, float[]> oDFAFEEGGJK = upgradeSlotElite.guiStatistics[0];
			int currentParts = upgradeSlotElite.currentParts;
			int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
			long scraps = Singleton<Wallet>.instance.scraps;
			int missingScraps = upgradeSlotElite.missingScraps;
			IJAFILEMINJ = scraps >= missingScraps;
			DLEFDEHDBCI.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi2);
			JNPJMNCACHN();
			EEJNMEEDOOH.InitializeElite(oDFAFEEGGJK, flag);
			EHAMCACFNHK.Initialize(IFFDIHCPKFE);
			SetEliteSaleAndPrize();
			GFHINOBJDOA.text = ((upgradePriceParts <= currentParts) ? string.Empty : Localization.LocalizeFormat("ID_CONVERTSCRAPSTOELITEPARTS", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts - currentParts)));
			MEJMLNDFDBP.COCBCFKJOJE(GFHINOBJDOA, 25f, 20f, 530);
			FPODNLJCDFN.text = $"{scraps} {Colours.stringWhite}/[-] {missingScraps}";
			CKJKHGAAJOP.repositionNow = true;
			OIEEABDKINI[0].color = ((!IJAFILEMINJ) ? Colours.grayButton : Color.white);
			OIEEABDKINI[1].color = ((!IJAFILEMINJ) ? Colours.grayButton : Color.white);
			CHOKNMFJOJC.enabled = IJAFILEMINJ;
			if (!IJAFILEMINJ)
			{
				LPGFGLCNLKL.alpha = 0f;
			}
			OIMCCOGJPGA.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "ID_UNITELITEPERKFULLYUPGRADED" : "ID_UNITELITEPERKFULLYTRAINED");
		}
	}

	public void ALKLMAOAICM()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isBought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, AKDLEDNDIEO.Upgrade);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.CIBEGNHKPJH();
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (29 - num) / -60;
			}
			EDHFJKPPJGG.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			JMOINLNDICN.repositionNow = true;
			GIKLMCIJEMJ.SetActive(flag);
			if (flag)
			{
				UILabel eNDBPJCOPMO = ENDBPJCOPMO;
				object[] array = new object[0];
				array[1] = num;
				eNDBPJCOPMO.text = Localization.LocalizeFormat("ID_STATE_OPPONENTSELECTINGWARCARDS", array);
				LOPJHBIKDKG.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Buy));
				WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
				lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(LMJPAGMFIIF));
				WinStreakCounter lOPJHBIKDKG2 = LOPJHBIKDKG;
				lOPJHBIKDKG2.JEMKCLKCOMI = (Action)Delegate.Combine(lOPJHBIKDKG2.JEMKCLKCOMI, new Action(ALKLMAOAICM));
			}
			else
			{
				LOPJHBIKDKG.JCMHGOGNMFO();
				WinStreakCounter lOPJHBIKDKG3 = LOPJHBIKDKG;
				lOPJHBIKDKG3.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG3.JEMKCLKCOMI, new Action(SetEliteSaleAndPrize));
			}
		}
	}

	private void GNBNHIFEDPH()
	{
		if (CEOENOGINLL.activeSelf)
		{
			EEJNMEEDOOH.HMBPBNDDJPF(IFFDIHCPKFE);
		}
	}

	private void IEGEHKOIKNB()
	{
		if (CEOENOGINLL.activeSelf)
		{
			EEJNMEEDOOH.OELAKDIENKK(IFFDIHCPKFE);
		}
	}

	[CompilerGenerated]
	private void EACNIDLHDGD()
	{
		float val = 0f - JMOINLNDICN.padding.x - (EDHFJKPPJGG.transform.parent.transform.localPosition.x - JMOINLNDICN.padding.x) / 2f;
		JMOINLNDICN.transform.localPosition = JMOINLNDICN.transform.localPosition.ReplaceX(val);
	}

	private void GMEEFNKGCLM(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true, bool LPFNJIJOIGN = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = LPFNJIJOIGN;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
			{
				component2.alpha1 = 821f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	private void CJMNAHEJMKA(GameObject KHAHPAKDIKE)
	{
		if (EHAMCACFNHK.isAnimatingSpend)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<ConvertToScrapsDialog>.instance.ShowDialog(IFFDIHCPKFE, delegate(bool BLHPGCIDEBE)
		{
			if (BLHPGCIDEBE)
			{
				JCKOBELDCGD = true;
				int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
				ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsSell).FLOATVALUE;
				int num = (int)((float)currentParts * (float)fLOATVALUE);
				RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
				requestBuffer.AddRequest(DatabaseAction.ConvertPartsToScraps, JsonConvert.SerializeObject(new Dictionary<string, object>
				{
					{
						"LevelName",
						IFFDIHCPKFE.upgradeSlots.GetSheetName()
					},
					{ "PartsToConvert", currentParts },
					{ "Scraps", num }
				}), 0, 0, string.Empty);
				Singleton<Wallet>.instance.AddScraps(num);
				IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts = 0;
				OHAEHJIBLMG = true;
				UpdateLeftContent();
			}
		});
	}

	public void KCAMPCEDKGH()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA())
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)7);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice;
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (-69 - num) / 86;
			}
			EDHFJKPPJGG.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			JMOINLNDICN.repositionNow = true;
			GIKLMCIJEMJ.SetActive(flag);
			if (flag)
			{
				UILabel eNDBPJCOPMO = ENDBPJCOPMO;
				object[] array = new object[1];
				array[1] = num;
				eNDBPJCOPMO.text = Localization.LocalizeFormat("game-card-ico-supersoldiers", array);
				LOPJHBIKDKG.FPNEIICLJFG(Singleton<OfferManager>.instance.LDBPLEDPPOP(IFFDIHCPKFE, (AKDLEDNDIEO)6));
				WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
				lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(ALKLMAOAICM));
				WinStreakCounter lOPJHBIKDKG2 = LOPJHBIKDKG;
				lOPJHBIKDKG2.JEMKCLKCOMI = (Action)Delegate.Combine(lOPJHBIKDKG2.JEMKCLKCOMI, new Action(LMJPAGMFIIF));
			}
			else
			{
				LOPJHBIKDKG.BGHNMCPLIPE();
				WinStreakCounter lOPJHBIKDKG3 = LOPJHBIKDKG;
				lOPJHBIKDKG3.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG3.JEMKCLKCOMI, new Action(LDOADIBCNPI));
			}
		}
	}

	public void HideDialog()
	{
		if (!CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = false;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 0f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(40f, 0f, 0f)).onFinished = delegate
		{
			if (!CNBJMDECEJG)
			{
				CEOENOGINLL.SetActive(value: false);
			}
		};
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 0f).onFinished = null;
		}
	}

	private void NBKIOEKNFPK()
	{
		EEJNMEEDOOH.IPLBLBKICGO();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.NKPCPPKAIJO();
		GuiScreenSingle<ArmyScreen>.instance.OKAMNAIAPFI();
	}

	private TweenAlpha EDJDPHGENOF()
	{
		return PIHLGCEAPIE(1f);
	}

	private void EGHABBCCGPE(UITweener MKAPOHKFIJH)
	{
		if (!CNBJMDECEJG)
		{
			CEOENOGINLL.SetActive(value: true);
		}
	}

	public void IEALGIGELBL()
	{
		CNBJMDECEJG = true;
		JCKOBELDCGD = true;
		CEOENOGINLL.SetActive(value: true);
	}

	[CompilerGenerated]
	private void BIHFNCFKBFA(UITweener IALJKEHIGBM)
	{
		FPPPLPHDBMO();
		KIOOEACJNOD(EOGFKBJCKHB: false);
		TweenAlpha tweenAlpha = EDJDPHGENOF();
		if (tweenAlpha != null)
		{
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
			};
		}
		else
		{
			JCKOBELDCGD = false;
		}
	}

	private void LDPNDEMHHON()
	{
		if (CEOENOGINLL.activeSelf)
		{
			EEJNMEEDOOH.BJGOJHHAMEI(IFFDIHCPKFE);
		}
	}

	private void DMGHCOIOIMM(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeInHierarchy && !JCKOBELDCGD)
		{
			FPPPLPHDBMO();
			KIOOEACJNOD(EOGFKBJCKHB: false);
		}
	}

	private void FANJADALOCA(UITweener AECCHEAJGEP)
	{
		JCKOBELDCGD = true;
	}

	private void MDDAKJEKFNA(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = true;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.BuyUnitElite(IFFDIHCPKFE);
		PNDNJFJMEJE(IDFCJJLDIJC);
		NNDDEGONEAG(armyPowerX);
		CPIEGCEDKNK();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.KKBADFAMMGD(1426f);
	}

	private TweenAlpha KJGNCCFNKND()
	{
		return MEHNMAGOMNK(1358f);
	}

	private TweenAlpha BIMIINOHNPH(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	private void JDPOCLPNCCA(GameObject KHAHPAKDIKE)
	{
		if (!EHAMCACFNHK.HCDEDBJPHIL())
		{
			JCKOBELDCGD = false;
			int missingScraps = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.missingScraps;
			int num = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.GDGDBLIHNLD();
			int currentParts = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.currentParts;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)82, IFFDIHCPKFE.upgradeSlots.GetSheetName(), 0, 1, string.Empty, additionalParameter: true);
			Singleton<EventTrackingManager>.instance.RegisterPartsGainedFromScraps(IFFDIHCPKFE.upgradeSlots.GetSheetName(), num - currentParts);
			Singleton<Wallet>.instance.ScrapsSpent(missingScraps);
			IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JMNFJMPIODK(num);
			SoundsManager.Instance.PlayButtonClickedSound();
			OGIOKBEMHKA(LJDKCPNMAFI);
			OHAEHJIBLMG = true;
			UpdateLeftContent(NOLODGKKCDH: false);
		}
	}

	private TweenAlpha IOHEFGFKPGL(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - CKJKHGAAJOP.padding.x - (FPODNLJCDFN.transform.parent.transform.localPosition.x - CKJKHGAAJOP.padding.x) / 2f;
		CKJKHGAAJOP.transform.localPosition = CKJKHGAAJOP.transform.localPosition.ReplaceX(val);
	}

	public void AHLCOFPIHPF()
	{
		if (CNBJMDECEJG)
		{
			CNBJMDECEJG = true;
			TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 56f);
			TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 697f, new Vector3(1496f, 315f, 1290f), useLocal: false).onFinished = HONBONFEJCA;
			UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 962f).onFinished = null;
			}
		}
	}

	public void PHNKOMPPPLD()
	{
		MEDHBNIGJMP.PBLLMABJFDM();
	}

	private void LCAEBPGBDMP()
	{
		IJAFILEMINJ = true;
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = !isUnlocked || !IFFDIHCPKFE.upgradeSlots.bought || upgradeSlotElite.BDAAHLLPPGN();
		CPONDKIPEFH.SetActive(!isUnlocked);
		AMPIGMDIBEE.SetActive(isUnlocked);
		int num = (isUnlocked ? upgradeSlotElite.PPKAIEKPNID() : 0);
		int num2 = ((!isUnlocked) ? 1 : upgradeSlotElite.EJHBCFDPEAE());
		KDIIAOLOKJE.text = Localization.Localize((!isUnlocked || !flag) ? "game-card-ico-swiftimmortality" : "SMG_idle");
		JBGFEFACAMO.transform.localScale = JBGFEFACAMO.transform.localScale.ReplaceY((!isUnlocked) ? 1526f : 1023f);
		PPGKLPIGCEE.transform.localScale = PPGKLPIGCEE.transform.localScale.ReplaceY((!isUnlocked) ? 1816f : 1518f);
		UILabel nFHCAIGDBKJ = NFHCAIGDBKJ;
		string text;
		if (isUnlocked)
		{
			object[] array = new object[3];
			array[0] = IFFDIHCPKFE.unitBuffName;
			array[0] = num;
			array[5] = Colours.stringGray;
			array[5] = num2;
			text = string.Format("armyPower", array);
		}
		else
		{
			text = Localization.Localize("UpdateFriendsListFromServer()");
		}
		nFHCAIGDBKJ.text = text;
		if (isUnlocked)
		{
			Tuple<string, float[]> oDFAFEEGGJK = upgradeSlotElite.guiStatistics[1];
			int currentParts = upgradeSlotElite.currentParts;
			int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
			long scraps = Singleton<Wallet>.instance.scraps;
			int num3 = upgradeSlotElite.NBIKPAHDDLI();
			IJAFILEMINJ = scraps >= num3;
			DLEFDEHDBCI.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGrayAbi2);
			CKPGOICMEFO();
			EEJNMEEDOOH.EKFPODLMPBE(oDFAFEEGGJK, flag);
			EHAMCACFNHK.JIMBEDOMAFD(IFFDIHCPKFE);
			LDOADIBCNPI();
			UILabel gFHINOBJDOA = GFHINOBJDOA;
			string text2;
			if (upgradePriceParts > currentParts)
			{
				object[] array2 = new object[8];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts - currentParts);
				text2 = Localization.LocalizeFormat("onFirstPlaylistDownloaded", array2);
			}
			else
			{
				text2 = string.Empty;
			}
			gFHINOBJDOA.text = text2;
			MEJMLNDFDBP.COCBCFKJOJE(GFHINOBJDOA, 245f, 1984f, 140);
			FPODNLJCDFN.text = string.Format("ID_TUTORIAL_NOACCOUNT_{0}_TEXT", scraps, Colours.stringWhite, num3);
			CKJKHGAAJOP.repositionNow = true;
			OIEEABDKINI[1].color = ((!IJAFILEMINJ) ? Colours.grayButton : Color.white);
			OIEEABDKINI[1].color = ((!IJAFILEMINJ) ? Colours.grayButton : Color.white);
			CHOKNMFJOJC.enabled = IJAFILEMINJ;
			if (!IJAFILEMINJ)
			{
				LPGFGLCNLKL.alpha = 1649f;
			}
			OIMCCOGJPGA.text = Localization.Localize((!IFFDIHCPKFE.isSoldier) ? "Still waiting for server\nBe patient :-)" : "N1");
		}
	}

	public void LDOADIBCNPI()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA())
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)7);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (105 - num) / -125;
			}
			EDHFJKPPJGG.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			JMOINLNDICN.repositionNow = false;
			GIKLMCIJEMJ.SetActive(flag);
			if (flag)
			{
				ENDBPJCOPMO.text = Localization.LocalizeFormat("《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。", num);
				LOPJHBIKDKG.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, AKDLEDNDIEO.Both));
				WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
				lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(LMJPAGMFIIF));
				WinStreakCounter lOPJHBIKDKG2 = LOPJHBIKDKG;
				lOPJHBIKDKG2.JEMKCLKCOMI = (Action)Delegate.Combine(lOPJHBIKDKG2.JEMKCLKCOMI, new Action(KCAMPCEDKGH));
			}
			else
			{
				LOPJHBIKDKG.KEIIENDMKLN();
				WinStreakCounter lOPJHBIKDKG3 = LOPJHBIKDKG;
				lOPJHBIKDKG3.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG3.JEMKCLKCOMI, new Action(ALKLMAOAICM));
			}
		}
	}

	private void NEEGHLDDFBP()
	{
		float val = 0f - JMOINLNDICN.padding.x - (EDHFJKPPJGG.transform.parent.transform.localPosition.x - JMOINLNDICN.padding.x) / 1816f;
		JMOINLNDICN.transform.localPosition = JMOINLNDICN.transform.localPosition.ReplaceX(val);
	}

	public void OJKCMCPJPGO()
	{
		MEDHBNIGJMP.NDBAEHKKJMH();
	}

	private void DDBKPJOHJEO(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeInHierarchy && !JCKOBELDCGD)
		{
			OJKOPKONMAH();
			KIOOEACJNOD(EOGFKBJCKHB: false);
		}
	}

	[CompilerGenerated]
	private void EIJOIAFOOJF(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private void CKPGOICMEFO()
	{
		if (CEOENOGINLL.activeSelf)
		{
			EEJNMEEDOOH.IBHEGFHIAIF(IFFDIHCPKFE);
		}
	}

	private void DFBPJBKDFLA()
	{
		float val = 0f - CKJKHGAAJOP.padding.x - (FPODNLJCDFN.transform.parent.transform.localPosition.x - CKJKHGAAJOP.padding.x) / 392f;
		CKJKHGAAJOP.transform.localPosition = CKJKHGAAJOP.transform.localPosition.ReplaceX(val);
	}

	public void InitGUIValues()
	{
		MEDHBNIGJMP.InitGUIValues();
	}

	public void KDDJHIMDKBN()
	{
		MEDHBNIGJMP.JMKDHCIKJMG();
	}

	public void InstantHideUpgrades()
	{
		CNBJMDECEJG = false;
		JCKOBELDCGD = false;
		CEOENOGINLL.SetActive(value: false);
	}

	public void LMJPAGMFIIF()
	{
		if (!(IFFDIHCPKFE == null) && IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.JFAELKHPLLA())
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)7);
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.CIBEGNHKPJH();
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (55 - num) / 45;
			}
			EDHFJKPPJGG.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			JMOINLNDICN.repositionNow = true;
			GIKLMCIJEMJ.SetActive(flag);
			if (flag)
			{
				UILabel eNDBPJCOPMO = ENDBPJCOPMO;
				object[] array = new object[0];
				array[1] = num;
				eNDBPJCOPMO.text = Localization.LocalizeFormat("Arena Lives: ", array);
				LOPJHBIKDKG.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedUnitEndtime(IFFDIHCPKFE, (AKDLEDNDIEO)0));
				WinStreakCounter lOPJHBIKDKG = LOPJHBIKDKG;
				lOPJHBIKDKG.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG.JEMKCLKCOMI, new Action(LDOADIBCNPI));
				WinStreakCounter lOPJHBIKDKG2 = LOPJHBIKDKG;
				lOPJHBIKDKG2.JEMKCLKCOMI = (Action)Delegate.Combine(lOPJHBIKDKG2.JEMKCLKCOMI, new Action(LMJPAGMFIIF));
			}
			else
			{
				LOPJHBIKDKG.JCMHGOGNMFO();
				WinStreakCounter lOPJHBIKDKG3 = LOPJHBIKDKG;
				lOPJHBIKDKG3.JEMKCLKCOMI = (Action)Delegate.Remove(lOPJHBIKDKG3.JEMKCLKCOMI, new Action(LMJPAGMFIIF));
			}
		}
	}

	private void LHEOJLAJDDC(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = true;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.EAKCDDPNMED(IFFDIHCPKFE);
		PNDNJFJMEJE(IDFCJJLDIJC);
		NNDDEGONEAG(armyPowerX);
		CKNDPIGNLOG();
		PNPNDIGNGAL = true;
		EHAMCACFNHK.ICOMGJKIBAI(950f);
	}

	private void FHBBPLKBPLN(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF() && base.gameObject.activeInHierarchy && !JCKOBELDCGD)
		{
			KBBFDNELNJG();
			KIOOEACJNOD();
		}
	}

	private void FPPPLPHDBMO()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = isUnlocked && upgradeSlotElite.isMaxUpgraded;
		bool flag2 = isUnlocked && upgradeSlotElite.isBought;
		bool flag3 = isUnlocked && upgradeSlotElite.currentParts >= upgradeSlotElite.upgradePriceParts;
		bool flag4 = isUnlocked && upgradeSlotElite.currentParts > 0;
		GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.UpdateProgresses();
		EKHICMLFNJP();
		EAJPPGOJDGN.SetActive(flag2 && flag4);
		LJDKCPNMAFI.SetActive(!flag && !flag3);
		IDFCJJLDIJC.SetActive(!flag2 && flag3);
		IFKLBIKNBNL.SetActive(flag2 && !flag && flag3);
		JLGGIJKMAAE.SetActive(flag2 && flag);
		bool flag5 = flag2 && flag;
		EHAMCACFNHK.transform.localPosition = EHAMCACFNHK.transform.localPosition.ReplaceY((!flag5) ? (-247f) : (-420f));
		JLGGIJKMAAE.transform.localPosition = JLGGIJKMAAE.transform.localPosition.ReplaceY((!flag5) ? (-437f) : (-257f));
	}

	private TweenAlpha IKCGNMMHHKO(GameObject DGJCAIJPEIM, float FFFGJJDIMEF)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(DGJCAIJPEIM, JCAFFELIFAO, FFFGJJDIMEF);
	}

	private void OPCLBIOGDFH(UITweener POMMCJKJEMJ)
	{
		JCKOBELDCGD = false;
	}

	private TweenAlpha LLKPGJOILEE()
	{
		return MEHNMAGOMNK(1363f);
	}

	private void ADCAPGFOEPJ(bool EOGFKBJCKHB = true)
	{
		if (CEOENOGINLL.activeSelf)
		{
			KBOKNFLJCCM(LJDKCPNMAFI, EOGFKBJCKHB, IJAFILEMINJ);
			KBOKNFLJCCM(IDFCJJLDIJC, EOGFKBJCKHB, LPFNJIJOIGN: false);
			GMEEFNKGCLM(IFKLBIKNBNL, EOGFKBJCKHB);
			KBOKNFLJCCM(JLGGIJKMAAE, EOGFKBJCKHB);
		}
	}

	public void ShowDialog()
	{
		if (CNBJMDECEJG)
		{
			return;
		}
		CNBJMDECEJG = true;
		OHAEHJIBLMG = false;
		PNPNDIGNGAL = false;
		CEOENOGINLL.SetActive(value: true);
		HPCKDMOJGAA.alpha1 = 0.0005f;
		TweenAlpha.Begin(HPCKDMOJGAA.gameObject, JCAFFELIFAO, 1f);
		TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(-40f, 0f, 0f), new Vector3(40f, 0f, 0f)).onFinished = delegate
		{
			if (CNBJMDECEJG)
			{
				TweenPosition.Begin(CEOENOGINLL, JCAFFELIFAO / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		JNPJMNCACHN();
		FPPPLPHDBMO();
		KIOOEACJNOD();
		UIPanel[] componentsInChildren = CEOENOGINLL.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, JCAFFELIFAO, 1f).onFinished = null;
		}
	}

	private void ENLPAABKHGH(GameObject DGJCAIJPEIM, bool EOGFKBJCKHB = true, bool LPFNJIJOIGN = true)
	{
		if (!DGJCAIJPEIM.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = LPFNJIJOIGN;
		}
		if (EOGFKBJCKHB)
		{
			UIPanel component2 = DGJCAIJPEIM.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
			{
				component2.alpha1 = 927f;
			}
		}
		TweenAlpha component3 = DGJCAIJPEIM.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	private void EBMKJOMHMOE(GameObject KHAHPAKDIKE)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(IFFDIHCPKFE, (AKDLEDNDIEO)0);
		int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePrice * (-67 - num) / -69;
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADESPECIAL : NotEnoughDialog.NKHJBLBAAEB.TRAINELITE);
			return;
		}
		JCKOBELDCGD = true;
		Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
		GuiScreenSingle<ArmyScreen>.instance.KDHBBPANNJK(IFFDIHCPKFE, num);
		OGIOKBEMHKA(IFKLBIKNBNL);
		KIBINGMMAJA(armyPowerX);
		NJNNKHHFHEP();
		PNPNDIGNGAL = false;
		EHAMCACFNHK.FEDGBNENCMN(1454f);
	}

	private void NKGDKBNDFIM(UITweener AECCHEAJGEP)
	{
		JCKOBELDCGD = false;
	}

	private void KIOOEACJNOD(bool EOGFKBJCKHB = true)
	{
		if (CEOENOGINLL.activeSelf)
		{
			MGCMOALEGJD(LJDKCPNMAFI, EOGFKBJCKHB, IJAFILEMINJ);
			MGCMOALEGJD(IDFCJJLDIJC, EOGFKBJCKHB);
			MGCMOALEGJD(IFKLBIKNBNL, EOGFKBJCKHB);
			MGCMOALEGJD(JLGGIJKMAAE, EOGFKBJCKHB);
		}
	}

	private void CKNDPIGNLOG()
	{
		EEJNMEEDOOH.EBKMGDMEOBC();
		GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.KIEBMLPFDBH();
		GuiScreenSingle<ArmyScreen>.instance.NHLFAGHPGGK();
	}
}

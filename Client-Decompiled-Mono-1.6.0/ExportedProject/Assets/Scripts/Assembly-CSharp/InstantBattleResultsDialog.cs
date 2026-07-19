using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class InstantBattleResultsDialog : GuiElementSingle<InstantBattleResultsDialog>, PAIIOKBBHBC
{
	private sealed class FIFOHGBPJOA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TweenAlpha AJOCDHFNLND;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private static UITweener.OnFinished LGJCBPOPCPA;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(0.45f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance);
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 0.2f, 0f, 1f);
				AJOCDHFNLND.style = UITweener.Style.PingPong;
				AJOCDHFNLND.NumOfRepetitions = 11;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LJCDGJKCNEC;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		private static void CHDOECNGOPM(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 236f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1558f)
			{
				num -= 1898f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.EGACIBHAMAF(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1688f), new NHOGNBCNIEK(num));
			TweenProgressBar.OBHFCFEKAPG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(762f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(441f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1142f);
				PHDOCKCBJOF = new WaitForSeconds(1386f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 304f, 1026f, 1763f);
				AJOCDHFNLND.style = UITweener.Style.Loop;
				AJOCDHFNLND.NumOfRepetitions = 54;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LKKLABBEOAG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public FIFOHGBPJOA()
		{
		}

		private static void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 224f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1634f)
			{
				num -= 1248f;
			}
			GuiElementSingle<MenuHeader>.instance.ADJJGJHMJJM();
			TweenProgressBar.DHKJOACDBNK(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(504f), new NHOGNBCNIEK(num));
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1719f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		private static void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1754f;
			float num = LevelManager.instance.GetProgress();
			if (num > 233f)
			{
				num -= 1730f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(580f), new NHOGNBCNIEK(num));
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1611f), new NHOGNBCNIEK(num));
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(660f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 584f);
				PHDOCKCBJOF = new WaitForSeconds(976f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 63f, 986f, 634f);
				AJOCDHFNLND.style = UITweener.Style.Loop;
				AJOCDHFNLND.NumOfRepetitions = 93;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LKKLABBEOAG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1514f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 469f);
				PHDOCKCBJOF = new WaitForSeconds(62f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1198f, 471f, 559f);
				AJOCDHFNLND.style = UITweener.Style.Loop;
				AJOCDHFNLND.NumOfRepetitions = 4;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = BBPKDMPNEDG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(673f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1686f);
				PHDOCKCBJOF = new WaitForSeconds(11f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 826f, 1565f, 1472f);
				AJOCDHFNLND.style = UITweener.Style.PingPong;
				AJOCDHFNLND.NumOfRepetitions = 17;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = BBPKDMPNEDG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		private static void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1f)
			{
				num -= 1f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(0f), new NHOGNBCNIEK(num));
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(0f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}
	}

	[Header("Header")]
	public UILabel NDBAGOOMIDJ;

	public UILabel NNGIOOFADMB;

	public UISprite ECJOCPDJLOK;

	public UISprite OAHDFGAKGAC;

	[Header("-Buttons")]
	public UIButton FNOFLJEOHGJ;

	public UIButton LJNPCHFCGCN;

	public BoxCollider LMMNICNFIPH;

	[Header("Rewards")]
	public SetInstantBattleRewards JPMFEINCHNP;

	public SetInstantBattleRewards HKDPDFLOEDK;

	public SetInstantBattleRewards AGBEGILONLK;

	[Header("Unlock")]
	public UILabel OIBCMHANALH;

	public UISprite ECDJAAAKMOF;

	public UISprite GHOAHINBKGH;

	public UISprite PAPLCDHJIBJ;

	public UILabel MBJFLBFDBIE;

	private bool MKALMODMIMP;

	private int EGIAFNOCILH;

	private int NKFGNDFKGHC;

	private Vector3 CFGDCEEECIH;

	private Vector3 JLOKBOPHPCK;

	private int OKILEJHOHKE;

	private int HFKNEFGKBOA;

	private int OJEBLFCHEPP;

	private int EPCCHIJDHCN;

	private List<Card> EDJFEIOCJNF;

	private AAAJDBAEIKL DDAFCFEFFFD;

	private Dictionary<string, object> AIJKOENIJFL;

	private TweenAnimator FNOMCHPCOHB;

	private bool GGJOPFNLPBJ;

	public override void InitGUIValues()
	{
		GGJOPFNLPBJ = false;
		JPMFEINCHNP.ResetValues();
		HKDPDFLOEDK.ResetValues();
		AGBEGILONLK.ResetValues();
		MKALMODMIMP = false;
		EGIAFNOCILH = GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM;
		if (EGIAFNOCILH > 1)
		{
			NDBAGOOMIDJ.text = Localization.LocalizeFormat("ID_XSKIRMISHESRESULT", EGIAFNOCILH);
		}
		else
		{
			NDBAGOOMIDJ.text = Localization.Localize("ID_SKIRMISHRESULT");
		}
		GHOAHINBKGH.gameObject.SetActive(true);
		OIBCMHANALH.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		ECDJAAAKMOF.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		LMMNICNFIPH.enabled = false;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 0f, Colours.graySkirmish);
		JPMFEINCHNP.InitializeWaiting();
		HKDPDFLOEDK.InitializeWaiting();
		AGBEGILONLK.InitializeWaiting();
		float num = NNGIOOFADMB.transform.localScale.x * NNGIOOFADMB.relativeSize.x;
		float val = (1320f - (num + 40f)) / 2f;
		Transform obj = OAHDFGAKGAC.transform;
		Vector3 localScale = ECJOCPDJLOK.transform.localScale.ReplaceX(val);
		ECJOCPDJLOK.transform.localScale = localScale;
		obj.localScale = localScale;
		InvokeAfter(delegate
		{
			MKALMODMIMP = true;
		}, 5f);
		if (InstantBattleManager.instance.BPPFFEPABLK)
		{
			FNFDPDJPAMO();
		}
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MBJFLBFDBIE.text = Localization.LocalizeFormat("ID_PLAYXMORESKIRMISHES", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE);
	}

	public virtual void FAGDHCFOEAL()
	{
		base.OIMKKAHOEKO();
		if (GGJOPFNLPBJ)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.DMGLCDBIBOE();
		}
	}

	private void FGCPMKDHPMK()
	{
		GGJOPFNLPBJ = false;
		HideDialog();
	}

	private void FCAEKAODIBN()
	{
		JKICNFCMCLB();
		JPMFEINCHNP.InitializeXP(OKILEJHOHKE, EGIAFNOCILH, (!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 584f);
		InvokeAfter(KBOMOLIGFEJ, 1567f);
		InvokeAfter(FOKFCAJOANH, 948f);
		if (LevelManager.instance.isLevelUp)
		{
			StartCoroutine(IAGKEDEOOIE());
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (GGJOPFNLPBJ)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.AfterDialogExit();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		ILKEPGHOAMI();
		if (GGJOPFNLPBJ)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.FlashScreen(null);
		}
	}

	private void FPKBHCOMKEG()
	{
		GHOAHINBKGH.gameObject.SetActive(false);
		LMMNICNFIPH.enabled = false;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 1004f, new Color(1423f, 758f, 1254f));
		TweenScale.Begin(OIBCMHANALH.gameObject, 500f, CFGDCEEECIH.MultiplyXY(725f));
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 275f, JLOKBOPHPCK.MultiplyXY(85f)).onFinished = delegate
		{
			TweenScale.Begin(OIBCMHANALH.gameObject, 0.2f, CFGDCEEECIH);
			TweenScale.Begin(ECDJAAAKMOF.gameObject, 0.2f, JLOKBOPHPCK);
		};
	}

	public void ALGIBAFCIIM()
	{
		HideDialog();
		GuiScreenSingle<InstantBattleResultsScreen>.instance.JEBEKLKGJAF();
	}

	private void FOKFCAJOANH()
	{
		switch (DDAFCFEFFFD)
		{
		case AAAJDBAEIKL.Gold:
			AGBEGILONLK.InitializeGold(OJEBLFCHEPP);
			TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 16f, new OLDCFKEJDPA(Singleton<Wallet>.instance.EFNHFKGEDHC() - OJEBLFCHEPP), new OLDCFKEJDPA(Singleton<Wallet>.instance.EFNHFKGEDHC()));
			break;
		case AAAJDBAEIKL.WarCard:
			AGBEGILONLK.InitializeWarcard(EDJFEIOCJNF);
			break;
		case AAAJDBAEIKL.Warbucks:
			AGBEGILONLK.InitializeWarbucks(EPCCHIJDHCN, 1);
			break;
		default:
			AGBEGILONLK.InitializeNoReward();
			break;
		}
	}

	private void GGMNLKAKKPJ()
	{
		HKDPDFLOEDK.KABDEDDJGAN(HFKNEFGKBOA, EGIAFNOCILH);
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1807f, new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.GCEAEGBNLMM()));
	}

	public GuiElement LLMDPKEJJHI()
	{
		return this;
	}

	public virtual void AMBDHDEBPJJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KICHFHDDHHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MMLEBDLDIEN));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DAJODKGBOML));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LNMIHMGFIBB;
	}

	private void PKANDCCOHID()
	{
		NCEHPMJEKNF();
		JPMFEINCHNP.InitializeXP(OKILEJHOHKE, EGIAFNOCILH, (!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 1f);
		InvokeAfter(delegate
		{
			HKDPDFLOEDK.InitializeWarbucks(HFKNEFGKBOA, EGIAFNOCILH);
			TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks));
		}, 0.15f);
		InvokeAfter(delegate
		{
			switch (DDAFCFEFFFD)
			{
			case AAAJDBAEIKL.Gold:
				AGBEGILONLK.InitializeGold(OJEBLFCHEPP);
				TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.gold - OJEBLFCHEPP), new OLDCFKEJDPA(Singleton<Wallet>.instance.gold));
				break;
			case AAAJDBAEIKL.WarCard:
				AGBEGILONLK.InitializeWarcard(EDJFEIOCJNF);
				break;
			case AAAJDBAEIKL.Warbucks:
				AGBEGILONLK.InitializeWarbucks(EPCCHIJDHCN);
				break;
			default:
				AGBEGILONLK.InitializeNoReward();
				break;
			}
		}, 0.3f);
		if (LevelManager.instance.isLevelUp)
		{
			StartCoroutine(IAGKEDEOOIE());
		}
	}

	private IEnumerator NAOLHFJBFDA()
	{
		return new FIFOHGBPJOA();
	}

	private void LHGBHJGHAPF()
	{
		OKILEJHOHKE = 1;
		HFKNEFGKBOA = 0;
		OJEBLFCHEPP = 0;
		DDAFCFEFFFD = AAAJDBAEIKL.Gold;
		AIJKOENIJFL = null;
	}

	[CompilerGenerated]
	private void HJJHMOHHDCJ()
	{
		HKDPDFLOEDK.InitializeWarbucks(HFKNEFGKBOA, EGIAFNOCILH);
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks));
	}

	private void CLJEAOOIIDK()
	{
		GGJOPFNLPBJ = true;
		HideDialog();
	}

	public void LDNKGFBLAGH()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 1548f);
	}

	public virtual void NFNMLPPDPAP()
	{
		GGJOPFNLPBJ = false;
		JPMFEINCHNP.ResetValues();
		HKDPDFLOEDK.ResetValues();
		AGBEGILONLK.ResetValues();
		MKALMODMIMP = false;
		EGIAFNOCILH = GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM;
		if (EGIAFNOCILH > 1)
		{
			UILabel nDBAGOOMIDJ = NDBAGOOMIDJ;
			object[] array = new object[1];
			array[1] = EGIAFNOCILH;
			nDBAGOOMIDJ.text = Localization.LocalizeFormat("HIDIING", array);
		}
		else
		{
			NDBAGOOMIDJ.text = Localization.Localize("com/google/android/gms/games/Games");
		}
		GHOAHINBKGH.gameObject.SetActive(false);
		OIBCMHANALH.transform.localScale = new Vector3(1243f, 1047f, 1520f);
		ECDJAAAKMOF.transform.localScale = new Vector3(428f, 1275f, 556f);
		LMMNICNFIPH.enabled = false;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 1248f, Colours.graySkirmish);
		JPMFEINCHNP.OIHHMFNHAGA();
		HKDPDFLOEDK.InitializeWaiting();
		AGBEGILONLK.InitializeWaiting();
		float num = NNGIOOFADMB.transform.localScale.x * NNGIOOFADMB.relativeSize.x;
		float val = (758f - (num + 1678f)) / 1097f;
		Transform obj = OAHDFGAKGAC.transform;
		Vector3 localScale = ECJOCPDJLOK.transform.localScale.ReplaceX(val);
		ECJOCPDJLOK.transform.localScale = localScale;
		obj.localScale = localScale;
		InvokeAfter(GCLHHPFPDNA, 1203f);
		if (InstantBattleManager.PHOOFIAOFPE().BPPFFEPABLK)
		{
			FPKFEBBOJDJ();
		}
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		UILabel mBJFLBFDBIE = MBJFLBFDBIE;
		object[] array2 = new object[1];
		array2[1] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMax).FLOATVALUE;
		mBJFLBFDBIE.text = Localization.LocalizeFormat("undefined", array2);
	}

	private IEnumerator FMNPGJONABO()
	{
		return new FIFOHGBPJOA();
	}

	private void PAINDBIEPPG()
	{
		GGJOPFNLPBJ = true;
		HideDialog();
	}

	public GuiElement LHHPBBPPIOE()
	{
		return this;
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.InstantBattle)
		{
			if (base.isFullyShowed)
			{
				GKOHJGFKPAH(base.gameObject);
			}
			else
			{
				PAINDBIEPPG();
			}
		}
	}

	[CompilerGenerated]
	private void EFPGNPILJLH(UITweener MPLNNICKPLB)
	{
		TweenScale.Begin(OIBCMHANALH.gameObject, 0.2f, CFGDCEEECIH);
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 0.2f, JLOKBOPHPCK);
	}

	private void KICHFHDDHHD(GameObject KHAHPAKDIKE)
	{
		if (MKALMODMIMP)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 596f);
		}
	}

	public void MGPCKMOHKGK()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 835f);
	}

	public virtual void IFLHOKBNJPH()
	{
		base.DoAfterHide();
		if (GGJOPFNLPBJ)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.LNPFOOIAAEP();
		}
	}

	private void FKMGJKEMANA(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.PromoteUnit && GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed && base.gameObject.activeInHierarchy)
		{
			FNFDPDJPAMO();
		}
	}

	public virtual void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KICHFHDDHHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MMKBCCDILBD));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LNMIHMGFIBB;
	}

	private void IJPJBGJCNHM(UITweener MPLNNICKPLB)
	{
		TweenScale.Begin(OIBCMHANALH.gameObject, 48f, CFGDCEEECIH);
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 556f, JLOKBOPHPCK);
	}

	public virtual void BGPAHPGDDJB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KICHFHDDHHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MMKBCCDILBD));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(FKMGJKEMANA);
	}

	public void CIAJGCLIEJF()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 756f);
	}

	public virtual void HHDEMBPMOMG()
	{
		if (MHAIBHBGBOO())
		{
			MMLEBDLDIEN(FNOFLJEOHGJ.gameObject);
		}
	}

	public virtual void JJDJKPGLHGD()
	{
		GGJOPFNLPBJ = true;
		JPMFEINCHNP.ResetValues();
		HKDPDFLOEDK.ResetValues();
		AGBEGILONLK.ResetValues();
		MKALMODMIMP = true;
		EGIAFNOCILH = GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM;
		if (EGIAFNOCILH > 0)
		{
			UILabel nDBAGOOMIDJ = NDBAGOOMIDJ;
			object[] array = new object[0];
			array[1] = EGIAFNOCILH;
			nDBAGOOMIDJ.text = Localization.LocalizeFormat("ID_GUI_SILVER", array);
		}
		else
		{
			NDBAGOOMIDJ.text = Localization.Localize("ID_ENDSINTIME");
		}
		GHOAHINBKGH.gameObject.SetActive(false);
		OIBCMHANALH.transform.localScale = new Vector3(1530f, 1427f, 1488f);
		ECDJAAAKMOF.transform.localScale = new Vector3(569f, 185f, 219f);
		LMMNICNFIPH.enabled = false;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 789f, Colours.graySkirmish);
		JPMFEINCHNP.OIHHMFNHAGA();
		HKDPDFLOEDK.InitializeWaiting();
		AGBEGILONLK.OIHHMFNHAGA();
		float num = NNGIOOFADMB.transform.localScale.x * NNGIOOFADMB.relativeSize.x;
		float val = (56f - (num + 332f)) / 177f;
		Transform obj = OAHDFGAKGAC.transform;
		Vector3 localScale = ECJOCPDJLOK.transform.localScale.ReplaceX(val);
		ECJOCPDJLOK.transform.localScale = localScale;
		obj.localScale = localScale;
		InvokeAfter(GCLHHPFPDNA, 711f);
		if (InstantBattleManager.KOFJHNLPKFH().BPPFFEPABLK)
		{
			FNFDPDJPAMO();
		}
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		UILabel mBJFLBFDBIE = MBJFLBFDBIE;
		object[] array2 = new object[0];
		array2[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-165)).FLOATVALUE;
		mBJFLBFDBIE.text = Localization.LocalizeFormat("MachineGunner", array2);
	}

	private void KLGIBLPPJBF()
	{
		HKDPDFLOEDK.KABDEDDJGAN(HFKNEFGKBOA, EGIAFNOCILH);
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1795f, new OLDCFKEJDPA(Singleton<Wallet>.instance.ODKBFHAFHMA() - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.GCEAEGBNLMM()));
	}

	public virtual void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGFOIBOHAHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(FKMGJKEMANA);
	}

	public virtual void JCGDALOBGHO()
	{
		GGJOPFNLPBJ = false;
		JPMFEINCHNP.ResetValues();
		HKDPDFLOEDK.ResetValues();
		AGBEGILONLK.ResetValues();
		MKALMODMIMP = true;
		EGIAFNOCILH = GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM;
		if (EGIAFNOCILH > 1)
		{
			UILabel nDBAGOOMIDJ = NDBAGOOMIDJ;
			object[] array = new object[0];
			array[1] = EGIAFNOCILH;
			nDBAGOOMIDJ.text = Localization.LocalizeFormat("ID_TUTORIAL_TAPON", array);
		}
		else
		{
			NDBAGOOMIDJ.text = Localization.Localize("score recieved");
		}
		GHOAHINBKGH.gameObject.SetActive(true);
		OIBCMHANALH.transform.localScale = new Vector3(1130f, 176f, 1772f);
		ECDJAAAKMOF.transform.localScale = new Vector3(1197f, 1486f, 802f);
		LMMNICNFIPH.enabled = false;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 318f, Colours.graySkirmish);
		JPMFEINCHNP.OIHHMFNHAGA();
		HKDPDFLOEDK.InitializeWaiting();
		AGBEGILONLK.OIHHMFNHAGA();
		float num = NNGIOOFADMB.transform.localScale.x * NNGIOOFADMB.relativeSize.x;
		float val = (608f - (num + 1014f)) / 197f;
		Transform obj = OAHDFGAKGAC.transform;
		Vector3 localScale = ECJOCPDJLOK.transform.localScale.ReplaceX(val);
		ECJOCPDJLOK.transform.localScale = localScale;
		obj.localScale = localScale;
		InvokeAfter(GCLHHPFPDNA, 1192f);
		if (InstantBattleManager.PEDEKOCAMFE().BPPFFEPABLK)
		{
			PGOHHPOLDML();
		}
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MBJFLBFDBIE.text = Localization.LocalizeFormat("ID_KILLEDBYYOURARMYUNIT", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE);
	}

	private void HEKOGCLAPNI()
	{
		switch (DDAFCFEFFFD)
		{
		case AAAJDBAEIKL.None:
			AGBEGILONLK.JNKBIAMAMJN(OJEBLFCHEPP);
			TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 412f, new OLDCFKEJDPA(Singleton<Wallet>.instance.gold - OJEBLFCHEPP), new OLDCFKEJDPA(Singleton<Wallet>.instance.FHLGDIIPHFN()));
			break;
		case AAAJDBAEIKL.Gold:
			AGBEGILONLK.InitializeWarcard(EDJFEIOCJNF);
			break;
		case AAAJDBAEIKL.WarCard:
			AGBEGILONLK.KABDEDDJGAN(EPCCHIJDHCN, 1);
			break;
		default:
			AGBEGILONLK.InitializeNoReward();
			break;
		}
	}

	public virtual void GEKFHJKIAMF()
	{
		if (AFOFDNJOJHG())
		{
			GKOHJGFKPAH(FNOFLJEOHGJ.gameObject);
		}
	}

	private void HFOEMDNJIPK(UITweener MPLNNICKPLB)
	{
		TweenScale.Begin(OIBCMHANALH.gameObject, 363f, CFGDCEEECIH);
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 147f, JLOKBOPHPCK);
	}

	private void KBOMOLIGFEJ()
	{
		HKDPDFLOEDK.InitializeWarbucks(HFKNEFGKBOA, EGIAFNOCILH);
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1212f, new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.GCEAEGBNLMM()));
	}

	private void DAJODKGBOML(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED() && MKALMODMIMP)
		{
			CACONPCADPA();
		}
	}

	private void GCLHHPFPDNA()
	{
		MKALMODMIMP = true;
	}

	public void NMPFOCAGAOD()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 901f);
	}

	private void ILKEPGHOAMI()
	{
		OKILEJHOHKE = 0;
		HFKNEFGKBOA = 0;
		OJEBLFCHEPP = 0;
		DDAFCFEFFFD = AAAJDBAEIKL.None;
		AIJKOENIJFL = null;
	}

	public void LEHIJGKJHCK(bool JJJOMBKNGKA)
	{
		MKALMODMIMP = JJJOMBKNGKA;
	}

	public void SetAnimationFinished(bool JJJOMBKNGKA)
	{
		MKALMODMIMP = JJJOMBKNGKA;
	}

	private void FBLDCDJLJIC(UITweener MPLNNICKPLB)
	{
		TweenScale.Begin(OIBCMHANALH.gameObject, 1057f, CFGDCEEECIH);
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 562f, JLOKBOPHPCK);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed && MKALMODMIMP)
		{
			PAINDBIEPPG();
		}
	}

	private void FPKFEBBOJDJ()
	{
		NKFGNDFKGHC = InstantBattleManager.AMKDNKHACMD().OCLBKLOCFKL;
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		OKILEJHOHKE = InstantBattleManager.FNLDKIIPJGD().OKILEJHOHKE;
		HFKNEFGKBOA = InstantBattleManager.IBKPDGILFDH().HFKNEFGKBOA;
		EPCCHIJDHCN = InstantBattleManager.LABMMBCEOLF().EPCCHIJDHCN;
		OJEBLFCHEPP = InstantBattleManager.OKBAIGKCPKA().OJEBLFCHEPP;
		EDJFEIOCJNF = InstantBattleManager.HFOPOJLNOII().EDJFEIOCJNF;
		EGIAFNOCILH = InstantBattleManager.instance.EGIAFNOCILH;
		DDAFCFEFFFD = InstantBattleManager.MFCCLPOAMEF().DDAFCFEFFFD;
		InstantBattleManager.LABMMBCEOLF().BPPFFEPABLK = true;
		PJFPBNMFANA();
	}

	private IEnumerator GHFCMEAFPHN()
	{
		return new FIFOHGBPJOA();
	}

	private void PJFPBNMFANA()
	{
		NCEHPMJEKNF();
		JPMFEINCHNP.InitializeXP(OKILEJHOHKE, EGIAFNOCILH, (!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 580f);
		InvokeAfter(LJGFKJHDPHC, 543f);
		InvokeAfter(HEKOGCLAPNI, 1842f);
		if (LevelManager.instance.isLevelUp)
		{
			StartCoroutine(GHFCMEAFPHN());
		}
	}

	public virtual void CEOBPADJPIA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KICHFHDDHHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MMKBCCDILBD));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DAJODKGBOML));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(FKMGJKEMANA);
	}

	public void ShowScreen()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance);
	}

	private void NCEHPMJEKNF()
	{
		GHOAHINBKGH.gameObject.SetActive(false);
		LMMNICNFIPH.enabled = true;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 0f, new Color(1f, 1f, 1f));
		TweenScale.Begin(OIBCMHANALH.gameObject, 0.2f, CFGDCEEECIH.MultiplyXY(1.2f));
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 0.2f, JLOKBOPHPCK.MultiplyXY(1.2f)).onFinished = delegate
		{
			TweenScale.Begin(OIBCMHANALH.gameObject, 0.2f, CFGDCEEECIH);
			TweenScale.Begin(ECDJAAAKMOF.gameObject, 0.2f, JLOKBOPHPCK);
		};
	}

	private void ADJAPMBOPKF()
	{
		MKALMODMIMP = false;
	}

	public void OJCAMGOOMIB(bool JJJOMBKNGKA)
	{
		MKALMODMIMP = JJJOMBKNGKA;
	}

	public void ELPNBBLJMAH()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 1155f);
	}

	[CompilerGenerated]
	private void DNCCGBGGHLH()
	{
		MKALMODMIMP = true;
	}

	private void FNFDPDJPAMO()
	{
		NKFGNDFKGHC = InstantBattleManager.instance.OCLBKLOCFKL;
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		OKILEJHOHKE = InstantBattleManager.instance.OKILEJHOHKE;
		HFKNEFGKBOA = InstantBattleManager.instance.HFKNEFGKBOA;
		EPCCHIJDHCN = InstantBattleManager.instance.EPCCHIJDHCN;
		OJEBLFCHEPP = InstantBattleManager.instance.OJEBLFCHEPP;
		EDJFEIOCJNF = InstantBattleManager.instance.EDJFEIOCJNF;
		EGIAFNOCILH = InstantBattleManager.instance.EGIAFNOCILH;
		DDAFCFEFFFD = InstantBattleManager.instance.DDAFCFEFFFD;
		InstantBattleManager.instance.BPPFFEPABLK = false;
		PKANDCCOHID();
	}

	private void MMLEBDLDIEN(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP() && MKALMODMIMP)
		{
			DKEPBDKDJML();
		}
	}

	public override void OnBack()
	{
		if (base.isFullyShowed)
		{
			GKOHJGFKPAH(FNOFLJEOHGJ.gameObject);
		}
	}

	private void NKNIHGNCINL()
	{
		HKDPDFLOEDK.KABDEDDJGAN(HFKNEFGKBOA, EGIAFNOCILH);
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1735f, new OLDCFKEJDPA(Singleton<Wallet>.instance.GCEAEGBNLMM() - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.GCEAEGBNLMM()));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void GAPLHKCCGKI()
	{
		HideDialog();
		GuiScreenSingle<InstantBattleResultsScreen>.instance.AAEBBKCPNOC();
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.InstantBattle && GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed && base.gameObject.activeInHierarchy)
		{
			FNFDPDJPAMO();
		}
	}

	private void NEFFEFJOCPE(GameObject KHAHPAKDIKE)
	{
		if (MKALMODMIMP)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1908f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKMMAEKBNMO));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void LNMIHMGFIBB(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.SendCrashReport && GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed && base.gameObject.activeInHierarchy)
		{
			PGOHHPOLDML();
		}
	}

	public virtual void PPLBJDJIIPN()
	{
		GGJOPFNLPBJ = false;
		JPMFEINCHNP.ResetValues();
		HKDPDFLOEDK.ResetValues();
		AGBEGILONLK.ResetValues();
		MKALMODMIMP = true;
		EGIAFNOCILH = GuiScreenSingle<InstantBattleResultsScreen>.instance.FHNEBLGGJBM;
		if (EGIAFNOCILH > 1)
		{
			NDBAGOOMIDJ.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", EGIAFNOCILH);
		}
		else
		{
			NDBAGOOMIDJ.text = Localization.Localize("Locale");
		}
		GHOAHINBKGH.gameObject.SetActive(false);
		OIBCMHANALH.transform.localScale = new Vector3(617f, 86f, 540f);
		ECDJAAAKMOF.transform.localScale = new Vector3(1227f, 53f, 1403f);
		LMMNICNFIPH.enabled = true;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 1559f, Colours.graySkirmish);
		JPMFEINCHNP.OIHHMFNHAGA();
		HKDPDFLOEDK.InitializeWaiting();
		AGBEGILONLK.OIHHMFNHAGA();
		float num = NNGIOOFADMB.transform.localScale.x * NNGIOOFADMB.relativeSize.x;
		float val = (696f - (num + 784f)) / 614f;
		Transform obj = OAHDFGAKGAC.transform;
		Vector3 localScale = ECJOCPDJLOK.transform.localScale.ReplaceX(val);
		ECJOCPDJLOK.transform.localScale = localScale;
		obj.localScale = localScale;
		InvokeAfter(delegate
		{
			MKALMODMIMP = true;
		}, 1204f);
		if (InstantBattleManager.PEDEKOCAMFE().BPPFFEPABLK)
		{
			FNFDPDJPAMO();
		}
		NKFGNDFKGHC = PlayerAnalytics.instance.data.GetInstantBattleCost();
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		MBJFLBFDBIE.text = Localization.LocalizeFormat("1", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_LootboxRewardMin).FLOATVALUE);
	}

	public void LAAOENFEEFF()
	{
		HideDialog();
		GuiScreenSingle<InstantBattleResultsScreen>.instance.JEBEKLKGJAF();
	}

	[CompilerGenerated]
	private void CMKMBKKILBE()
	{
		switch (DDAFCFEFFFD)
		{
		case AAAJDBAEIKL.Gold:
			AGBEGILONLK.InitializeGold(OJEBLFCHEPP);
			TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1f, new OLDCFKEJDPA(Singleton<Wallet>.instance.gold - OJEBLFCHEPP), new OLDCFKEJDPA(Singleton<Wallet>.instance.gold));
			break;
		case AAAJDBAEIKL.WarCard:
			AGBEGILONLK.InitializeWarcard(EDJFEIOCJNF);
			break;
		case AAAJDBAEIKL.Warbucks:
			AGBEGILONLK.InitializeWarbucks(EPCCHIJDHCN);
			break;
		default:
			AGBEGILONLK.InitializeNoReward();
			break;
		}
	}

	private void AIGOMNLMOKC(UITweener MPLNNICKPLB)
	{
		TweenScale.Begin(OIBCMHANALH.gameObject, 1566f, CFGDCEEECIH);
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 915f, JLOKBOPHPCK);
	}

	public virtual void LFBAOBONBKH()
	{
		if (base.isFullyShowed)
		{
			MMLEBDLDIEN(FNOFLJEOHGJ.gameObject);
		}
	}

	private void FBIGNLCGPBM()
	{
		switch (DDAFCFEFFFD)
		{
		case AAAJDBAEIKL.Gold:
			AGBEGILONLK.JNKBIAMAMJN(OJEBLFCHEPP);
			TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 478f, new OLDCFKEJDPA(Singleton<Wallet>.instance.FHLGDIIPHFN() - OJEBLFCHEPP), new OLDCFKEJDPA(Singleton<Wallet>.instance.FHLGDIIPHFN()));
			break;
		case AAAJDBAEIKL.WarCard:
			AGBEGILONLK.InitializeWarcard(EDJFEIOCJNF);
			break;
		case AAAJDBAEIKL.Warbucks:
			AGBEGILONLK.KABDEDDJGAN(EPCCHIJDHCN);
			break;
		default:
			AGBEGILONLK.InitializeNoReward();
			break;
		}
	}

	private void IBKBLLEDHCG()
	{
		GGJOPFNLPBJ = true;
		HideDialog();
	}

	private void MMKBCCDILBD(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM() && MKALMODMIMP)
		{
			DKEPBDKDJML();
		}
	}

	private void HAFDEFIDEGA()
	{
		MKALMODMIMP = true;
	}

	public virtual void MLAEGNJBKIM()
	{
		base.OIMKKAHOEKO();
		if (GGJOPFNLPBJ)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.DMGLCDBIBOE();
		}
	}

	private void LJGFKJHDPHC()
	{
		HKDPDFLOEDK.KABDEDDJGAN(HFKNEFGKBOA, EGIAFNOCILH);
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, 1302f, new OLDCFKEJDPA(Singleton<Wallet>.instance.warBucks - (HFKNEFGKBOA + EPCCHIJDHCN)), new OLDCFKEJDPA(Singleton<Wallet>.instance.ODKBFHAFHMA()));
	}

	private void CACONPCADPA()
	{
		GGJOPFNLPBJ = false;
		HideDialog();
	}

	private void PGOHHPOLDML()
	{
		NKFGNDFKGHC = InstantBattleManager.GIOMEGJMOOL().OCLBKLOCFKL;
		OIBCMHANALH.text = MEJMLNDFDBP.GMIPFLIEOHD(NKFGNDFKGHC);
		OKILEJHOHKE = InstantBattleManager.KHMBHIINOFD().OKILEJHOHKE;
		HFKNEFGKBOA = InstantBattleManager.KHMBHIINOFD().HFKNEFGKBOA;
		EPCCHIJDHCN = InstantBattleManager.PEDEKOCAMFE().EPCCHIJDHCN;
		OJEBLFCHEPP = InstantBattleManager.PEDEKOCAMFE().OJEBLFCHEPP;
		EDJFEIOCJNF = InstantBattleManager.instance.EDJFEIOCJNF;
		EGIAFNOCILH = InstantBattleManager.BNDNFHKPDLM().EGIAFNOCILH;
		DDAFCFEFFFD = InstantBattleManager.BJAMDMCBIEI().DDAFCFEFFFD;
		InstantBattleManager.KHMBHIINOFD().BPPFFEPABLK = true;
		PKANDCCOHID();
	}

	private void JKICNFCMCLB()
	{
		GHOAHINBKGH.gameObject.SetActive(true);
		LMMNICNFIPH.enabled = true;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 1979f, new Color(1294f, 1725f, 692f));
		TweenScale.Begin(OIBCMHANALH.gameObject, 355f, CFGDCEEECIH.MultiplyXY(839f));
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 1641f, JLOKBOPHPCK.MultiplyXY(1000f)).onFinished = MONGOMIFOHD;
	}

	private void JLMNDAHOBFG(GameObject KHAHPAKDIKE)
	{
		if (MKALMODMIMP)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1939f);
		}
	}

	[DebuggerHidden]
	private IEnumerator IAGKEDEOOIE()
	{
		return new FIFOHGBPJOA();
	}

	private void BAPOBABCOMH(GameObject KHAHPAKDIKE)
	{
		if (MKALMODMIMP)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1829f);
		}
	}

	public virtual void LHMMLMPFHOH()
	{
		if (BJNBLINDAED())
		{
			MMLEBDLDIEN(FNOFLJEOHGJ.gameObject);
		}
	}

	public GuiElement JJBEFGHBHCL()
	{
		return this;
	}

	private void CGFOIBOHAHD(GameObject KHAHPAKDIKE)
	{
		if (MKALMODMIMP)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 1101f);
		}
	}

	public virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LMMNICNFIPH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NEFFEFJOCPE));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BKJPHNPHGMI));
		CFGDCEEECIH = OIBCMHANALH.transform.localScale;
		JLOKBOPHPCK = ECDJAAAKMOF.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LNMIHMGFIBB;
	}

	private void BKJPHNPHGMI(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP() && MKALMODMIMP)
		{
			IBKBLLEDHCG();
		}
	}

	private void NAFDAABLKMO()
	{
		GHOAHINBKGH.gameObject.SetActive(true);
		LMMNICNFIPH.enabled = true;
		TweenColor.Begin(PAPLCDHJIBJ.gameObject, 462f, new Color(35f, 1233f, 586f));
		TweenScale.Begin(OIBCMHANALH.gameObject, 753f, CFGDCEEECIH.MultiplyXY(475f));
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 1958f, JLOKBOPHPCK.MultiplyXY(906f)).onFinished = AIGOMNLMOKC;
	}

	public virtual void FJFDJJJNCAJ()
	{
		base.DoAfterHide();
		if (GGJOPFNLPBJ)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.DMGLCDBIBOE();
		}
	}

	public void PlayAgain()
	{
		HideDialog();
		GuiScreenSingle<InstantBattleResultsScreen>.instance.ShowAgain();
	}

	private void CKMMAEKBNMO(GameObject KHAHPAKDIKE)
	{
		if (MKALMODMIMP)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance);
		}
	}

	private void MONGOMIFOHD(UITweener MPLNNICKPLB)
	{
		TweenScale.Begin(OIBCMHANALH.gameObject, 1642f, CFGDCEEECIH);
		TweenScale.Begin(ECDJAAAKMOF.gameObject, 376f, JLOKBOPHPCK);
	}

	private void CLIGBFLPGAJ()
	{
		MKALMODMIMP = false;
	}

	private void DKEPBDKDJML()
	{
		GGJOPFNLPBJ = true;
		HideDialog();
	}

	public virtual void FEGPCLBPIOI()
	{
		if (BJNBLINDAED())
		{
			BKJPHNPHGMI(FNOFLJEOHGJ.gameObject);
		}
	}
}
